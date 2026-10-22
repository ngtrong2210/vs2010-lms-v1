---
name: word-template
description: Create or adjust Word templates while preserving styles, fields, tables, headers, footers, and generated document compatibility.
---

# Word Template

## Safety baseline

- Work only in the current project/workspace under `G:\`.
- If the workspace is not under `G:\`, stop before reading source and ask the user to open a project under `G:\`.
- Do not scan other drives and do not scan all of `G:\`.
- Do not access user profiles, Windows folders, AppData, browser data, SSH keys, or credential stores unless explicitly requested for a specific task.
- Preserve legacy compatibility; do not upgrade frameworks, packages, Bootstrap, DevExpress, C# language version, or SQL compatibility level without request.
- Never expose secrets. Mask suspicious values as `****`.
- Ask before destructive file, Git, SQL, deployment, or system-state changes.

## Rules

- Backup template before editing.
- Preserve styles, numbering, fields, bookmarks, tables, headers/footers, and page setup.
- Keep placeholders stable for generating code.
- Validate with sample data and check pagination.
