---
name: repx-folder-workshop
description: Repair, normalize, compare, and generate DevExpress XtraReport .repx templates from a canonical sample and the application source that selects report filenames. Use when a user puts reference REPX files, broken or incomplete REPX files, source code, and change requirements into a per-job folder and asks Codex to fix bindings/scripts/layout/margins, create missing subject-count variants, or validate an REPX template family.
---

# REPX folder workshop

Process one isolated job folder at a time. Read the source and canonical sample before editing any `.repx` file.

Read [references/repx-patterns.md](references/repx-patterns.md) when adding/removing subject columns, repairing serialized control blocks, or comparing embedded scripts.

## Expected job folder

Prefer this structure:

```text
job-name/
├── yeu-cau.txt
├── mau-chuan/
│   └── *.repx
├── can-sua/
│   └── *.repx
├── source/
│   └── source files that build/select report names
└── ket-qua/
```

Accept a flat folder when necessary. Infer roles from the user's wording and filenames; do not require every subfolder to exist. If the canonical sample is ambiguous and choosing one would materially change the output, ask which file is canonical.

Use `scripts/new_job.ps1` to create a new isolated job directory. Never mix output from different jobs.

## Workflow

1. Read `yeu-cau.txt` and the user's message.
2. Inventory all `.repx` and relevant source files with `rg --files`.
3. Search the source for `.repx`, path construction, subject count, regulation, attempt/last-attempt flags, and report variants. Record the exact runtime filename patterns and required count range.
4. Identify the canonical sample(s). Treat them as the source of truth only for the properties within the requested scope. Do not blindly copy unrelated layout or business logic.
5. Run `node scripts/analyze_repx.js <job-folder>` to inventory bindings, expression-style `Text`, event wiring, scripts, page settings, and structural anomalies.
6. Decode and compare `resourceString`/`ScriptsSource` when the requested behavior depends on event handlers, thresholds, pass/fail colors, conversion of sentinel marks such as `-1` to `M`, or other report logic.
7. Separate count-dependent components from fixed components:
   - Count-dependent: subject headers, unit headers, mark cells, bindings such as `FinalSummary_n`, weights, sizes, positions, and `Cells.AddRange` membership.
   - Usually fixed: parameters predeclared for the maximum range, summary/footer controls, formatting rules, page settings, and embedded scripts.
8. Repair existing templates or generate missing variants. Prefer deriving a missing count from the nearest correct template. Apply the canonical script and its event wiring together when script behavior is in scope.
9. Write finished files to `ket-qua/` by default, preserving originals in `can-sua/`. Edit originals only when the user explicitly asks for in-place changes.
10. Run `node scripts/validate_repx.js <file-or-folder>...`. Resolve every validation failure before delivery.

## Safe editing rules

- Preserve encoding and CRLF/LF style.
- Use exact control blocks and bindings; avoid global replacements that can touch headers, formatting conditions, or unrelated tables.
- When changing margins/footer space, update both report `Margins` and the corresponding band `HeightF` values.
- Verify every event name exists in the decoded embedded script.
- Do not assume the number in a filename is the true subject count; verify it against source and table structure.
- For families with a minimum physical column count, distinguish physical placeholder columns from bound subject columns.
- Preserve unrelated user changes and report any residual drift not requested.

## Validation requirements

Confirm all of the following:

- Required filenames exist for every runtime path/count found in source.
- Each expected subject has the correct field binding and number format.
- No direct expression-style `Text="[Table....]"` remains where the canonical sample uses `DataBindings` plus an event handler.
- No wrong-field binding remains, such as `FinalExam_n` where `FinalSummary_n` is required.
- Every `XRTableCell` in `Cells.AddRange` is declared and instantiated.
- No leftover binding/header/parameter references a removed count.
- Braces are balanced and the embedded script can be extracted.
- Script hash matches the canonical sample when exact script synchronization is requested.

State clearly that visual rendering cannot be proven without a compatible DevExpress runtime.
