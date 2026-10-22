---
name: word-reader
description: Read and analyze Word documents including headings, paragraphs, tables, fields, placeholders, and template structure.
---

# Word Reader

## Safety baseline

- Work only in the current project/workspace under `G:\`.
- If the workspace is not under `G:\`, stop before reading source and ask the user to open a project under `G:\`.
- Do not scan other drives and do not scan all of `G:\`.
- Do not access user profiles, Windows folders, AppData, browser data, SSH keys, or credential stores unless explicitly requested for a specific task.
- Preserve legacy compatibility; do not upgrade frameworks, packages, Bootstrap, DevExpress, C# language version, or SQL compatibility level without request.
- Never expose secrets. Mask suspicious values as `****`.
- Ask before destructive file, Git, SQL, deployment, or system-state changes.

## Checklist

- Identify headings, sections, paragraphs, tables, fields, bookmarks, placeholders, headers/footers.
- Preserve numbering, styles, page breaks, and fields.
- Do not edit binary content blindly.
- Report template structure and data mapping clearly.
