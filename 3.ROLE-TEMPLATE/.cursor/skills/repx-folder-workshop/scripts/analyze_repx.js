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
  const decoded = Buffer.from(base64, 'base64');
  return {
    base64,
    decoded,
    hash: crypto.createHash('sha256').update(base64).digest('hex'),
    text: decoded.toString('utf8'),
  };
}

function uniqueSorted(values) {
  return [...new Set(values)].sort((a, b) => {
    if (typeof a === 'number' && typeof b === 'number') return a - b;
    return String(a).localeCompare(String(b));
  });
}

function analyze(file) {
  const text = fs.readFileSync(file, 'utf8');
  const bindings = [];
  for (const block of text.matchAll(/this\.(\w+)\.DataBindings\.AddRange\([\s\S]*?\{([\s\S]*?)\}\);/g)) {
    for (const binding of block[2].matchAll(/XRBinding\("Text",\s*null,\s*"Table\.FinalSummary_(\d+)"(?:,\s*"([^"]*)")?\)/g)) {
      bindings.push({ cell: block[1], subject: Number(binding[1]), format: binding[2] || '' });
    }
  }
  const direct = [...text.matchAll(/this\.(\w+)\.Text\s*=\s*"\[Table\.FinalSummary_(\d+)(?:!([^\]]+))?\]";/g)]
    .map((m) => ({ cell: m[1], subject: Number(m[2]), format: m[3] || '' }));
  const wiring = [...text.matchAll(/this\.(\w+)\.Scripts\.On(\w+)\s*=\s*"([^"]+)";/g)]
    .map((m) => ({ cell: m[1], event: m[2], handler: m[3] }));
  const wrongFinalExam = [...text.matchAll(/Table\.FinalExam_(\d+)/g)].map((m) => Number(m[1]));
  const resource = extractResource(text);
  const margins = text.match(/this\.Margins\s*=\s*new System\.Drawing\.Printing\.Margins\(([^;]+)\);/);
  const heights = {};
  for (const m of text.matchAll(/this\.(topMarginBand1|bottomMarginBand1|ReportFooter)\.HeightF\s*=\s*([^;]+);/g)) {
    heights[m[1]] = m[2];
  }

  return {
    file,
    finalSummaryBindings: bindings,
    finalSummarySubjects: uniqueSorted(bindings.map((x) => x.subject)),
    directFinalSummaryExpressions: direct,
    eventWiring: wiring,
    wrongFinalExamSubjects: uniqueSorted(wrongFinalExam),
    script: resource ? {
      sha256: resource.hash,
      decodedBytes: resource.decoded.length,
      handlers: uniqueSorted([...resource.text.matchAll(/(?:private|public|protected)\s+void\s+(\w+)\s*\(/g)].map((m) => m[1])),
    } : null,
    margins: margins ? margins[1].trim() : null,
    bandHeights: heights,
  };
}

const args = process.argv.slice(2);
if (!args.length) {
  console.error('Usage: node analyze_repx.js <file-or-folder>...');
  process.exit(2);
}

try {
  const files = [];
  for (const arg of args) collectFiles(arg, files);
  const result = [...new Set(files)].sort().map(analyze);
  process.stdout.write(`${JSON.stringify(result, null, 2)}\n`);
} catch (error) {
  console.error(error.message);
  process.exit(1);
}
