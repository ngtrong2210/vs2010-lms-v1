'use strict';

const fs = require('fs');
const path = require('path');
const crypto = require('crypto');

function collectFiles(inputPath, out) {
  const resolved = path.resolve(inputPath);
  if (!fs.existsSync(resolved)) throw new Error(`Path not found: ${resolved}`);
  const stat = fs.statSync(resolved);
  if (stat.isFile()) {
    if (resolved.toLowerCase().endsWith('.repx')) out.push(resolved);
    return;
  }
  for (const entry of fs.readdirSync(resolved, { withFileTypes: true })) {
    collectFiles(path.join(resolved, entry.name), out);
  }
}

function extractResource(text) {
  const marker = 'string resourceString = ';
  const start = text.indexOf(marker);
  if (start < 0) return null;
  const tail = text.slice(start + marker.length);
  const end = tail.indexOf(';');
  if (end < 0) return null;
  const chunks = [...tail.slice(0, end).matchAll(/"([^"]*)"/g)].map((m) => m[1]);
  if (!chunks.length) return null;
  const base64 = chunks.join('');
  return {
    hash: crypto.createHash('sha256').update(base64).digest('hex'),
    text: Buffer.from(base64, 'base64').toString('utf8'),
  };
}

function setFrom(text, regex, group = 1) {
  return new Set([...text.matchAll(regex)].map((m) => m[group]));
}

function difference(left, right) {
  return [...left].filter((item) => !right.has(item)).sort();
}

function validate(file, canonicalHash) {
  const text = fs.readFileSync(file, 'utf8');
  const errors = [];
  const warnings = [];
  const declared = setFrom(text, /private DevExpress\.XtraReports\.UI\.XRTableCell (\w+);/g);
  const instantiated = setFrom(text, /this\.(\w+) = new DevExpress\.XtraReports\.UI\.XRTableCell\(\);/g);
  const inAddRange = new Set();
  for (const range of text.matchAll(/Cells\.AddRange\([\s\S]*?\{([\s\S]*?)\}\);/g)) {
    for (const cell of range[1].matchAll(/this\.(\w+)/g)) inAddRange.add(cell[1]);
  }

  const missingDeclarations = difference(inAddRange, declared);
  const missingInstantiations = difference(inAddRange, instantiated);
  if (missingDeclarations.length) errors.push(`Cells.AddRange without declaration: ${missingDeclarations.join(', ')}`);
  if (missingInstantiations.length) errors.push(`Cells.AddRange without instantiation: ${missingInstantiations.join(', ')}`);

  const openBraces = (text.match(/\{/g) || []).length;
  const closeBraces = (text.match(/\}/g) || []).length;
  if (openBraces !== closeBraces) errors.push(`Unbalanced braces: ${openBraces} open, ${closeBraces} close`);

  const resource = extractResource(text);
  if (!resource) {
    warnings.push('Embedded resourceString not found or could not be decoded');
  } else {
    const handlerNames = new Set([...resource.text.matchAll(/(?:private|public|protected)\s+void\s+(\w+)\s*\(/g)].map((m) => m[1]));
    const wiring = [...text.matchAll(/\.Scripts\.On(\w+)\s*=\s*"([^"]+)";/g)]
      .map((m) => ({ event: m[1], handler: m[2] }));
    const missingTextHandlers = [...new Set(wiring
      .filter((x) => x.event === 'TextChanged' && !handlerNames.has(x.handler))
      .map((x) => x.handler))].sort();
    const missingOtherHandlers = [...new Set(wiring
      .filter((x) => x.event !== 'TextChanged' && !handlerNames.has(x.handler))
      .map((x) => x.handler))].sort();
    if (missingTextHandlers.length) errors.push(`OnTextChanged handlers absent from ScriptsSource: ${missingTextHandlers.join(', ')}`);
    if (missingOtherHandlers.length) warnings.push(`Other wired handlers absent from ScriptsSource: ${missingOtherHandlers.join(', ')}`);
    if (canonicalHash && resource.hash !== canonicalHash) errors.push(`Embedded script differs from canonical: ${resource.hash}`);
  }

  const directExpressions = [...text.matchAll(/this\.(\w+)\.Text\s*=\s*"\[Table\.FinalSummary_(\d+)(?:![^\]]+)?\]";/g)];
  if (directExpressions.length) {
    warnings.push(`Direct FinalSummary expressions: ${directExpressions.map((m) => `${m[1]}=>${m[2]}`).join(', ')}`);
  }

  const bindingCells = [];
  for (const block of text.matchAll(/this\.(\w+)\.DataBindings\.AddRange\([\s\S]*?\{([\s\S]*?)\}\);/g)) {
    for (const binding of block[2].matchAll(/XRBinding\("Text",\s*null,\s*"Table\.FinalSummary_(\d+)"/g)) {
      bindingCells.push({ cell: block[1], subject: Number(binding[1]) });
    }
  }
  const wiredCells = setFrom(text, /this\.(\w+)\.Scripts\.OnTextChanged\s*=/g);
  const unwired = bindingCells.filter((x) => !wiredCells.has(x.cell));
  if (unwired.length) warnings.push(`FinalSummary bindings without OnTextChanged: ${unwired.map((x) => `${x.cell}=>${x.subject}`).join(', ')}`);

  const subjects = [...new Set(bindingCells.map((x) => x.subject))].sort((a, b) => a - b);
  if (subjects.length) {
    const gaps = [];
    for (let n = subjects[0]; n <= subjects[subjects.length - 1]; n += 1) {
      if (!subjects.includes(n)) gaps.push(n);
    }
    if (gaps.length) warnings.push(`Missing FinalSummary subject indexes inside range: ${gaps.join(', ')}`);
  }

  return { file, errors, warnings, scriptHash: resource ? resource.hash : null };
}

const args = process.argv.slice(2);
let canonicalPath = null;
const inputs = [];
for (let i = 0; i < args.length; i += 1) {
  if (args[i] === '--canonical') {
    canonicalPath = args[++i];
    if (!canonicalPath) {
      console.error('--canonical requires a .repx path');
      process.exit(2);
    }
  } else {
    inputs.push(args[i]);
  }
}
if (!inputs.length) {
  console.error('Usage: node validate_repx.js [--canonical sample.repx] <file-or-folder>...');
  process.exit(2);
}

try {
  let canonicalHash = null;
  if (canonicalPath) {
    const canonicalText = fs.readFileSync(path.resolve(canonicalPath), 'utf8');
    const canonicalResource = extractResource(canonicalText);
    if (!canonicalResource) throw new Error(`Canonical resourceString not found: ${canonicalPath}`);
    canonicalHash = canonicalResource.hash;
  }

  const files = [];
  for (const input of inputs) collectFiles(input, files);
  const results = [...new Set(files)].sort().map((file) => validate(file, canonicalHash));
  let failed = false;
  for (const result of results) {
    const status = result.errors.length ? 'FAIL' : result.warnings.length ? 'WARN' : 'OK';
    console.log(`${status} ${result.file}`);
    for (const error of result.errors) console.log(`  ERROR: ${error}`);
    for (const warning of result.warnings) console.log(`  WARN: ${warning}`);
    if (result.errors.length) failed = true;
  }
  process.exitCode = failed ? 1 : 0;
} catch (error) {
  console.error(error.message);
  process.exit(1);
}
