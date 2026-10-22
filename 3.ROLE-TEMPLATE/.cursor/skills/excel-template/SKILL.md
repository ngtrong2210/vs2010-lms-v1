---
name: excel-template
description: Create or adjust Excel templates while preserving formatting, formulas, merged cells, validation, and print settings.
---

# Excel Template

## Safety baseline

- Work only in the current project/workspace under `G:\`.
- If the workspace is not under `G:\`, stop before reading source and ask the user to open a project under `G:\`.
- Do not scan other drives and do not scan all of `G:\`.
- Do not access user profiles, Windows folders, AppData, browser data, SSH keys, or credential stores unless explicitly requested for a specific task.
- Preserve legacy compatibility; do not upgrade frameworks, packages, Bootstrap, DevExpress, C# language version, or SQL compatibility level without request.
- Never expose secrets. Mask suspicious values as `****`.
- Ask before destructive file, Git, SQL, deployment, or system-state changes.

## Rules

- Backup before modification.
- Identify placeholders, formulas, named ranges, merged cells, page setup, and print area.
- Keep formulas and formatting stable.
- Avoid changing positions used by code unless code is updated too.
- Validate output with representative data.
