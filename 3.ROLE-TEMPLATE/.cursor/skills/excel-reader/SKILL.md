---
name: excel-reader
description: Read and understand Excel workbook structure, sheets, headers, merged cells, formulas, data types, and validation needs.
---

# Excel Reader

## Safety baseline

- Work only in the current project/workspace under `G:\`.
- If the workspace is not under `G:\`, stop before reading source and ask the user to open a project under `G:\`.
- Do not scan other drives and do not scan all of `G:\`.
- Do not access user profiles, Windows folders, AppData, browser data, SSH keys, or credential stores unless explicitly requested for a specific task.
- Preserve legacy compatibility; do not upgrade frameworks, packages, Bootstrap, DevExpress, C# language version, or SQL compatibility level without request.
- Never expose secrets. Mask suspicious values as `****`.
- Ask before destructive file, Git, SQL, deployment, or system-state changes.

## Process

- Identify workbook format and sheets.
- Detect header rows, data regions, merged cells, formulas, styles, filters, and print settings.
- Do not alter binary files blindly.
- Preserve formulas and formatting when recommending changes.
- Document column mapping and ambiguous cells.
