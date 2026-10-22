---
name: report-template
description: Define consistent report/template standards for layout, data binding, parameters, formatting, naming, and validation.
---

# Report Template

## Safety baseline

- Work only in the current project/workspace under `G:\`.
- If the workspace is not under `G:\`, stop before reading source and ask the user to open a project under `G:\`.
- Do not scan other drives and do not scan all of `G:\`.
- Do not access user profiles, Windows folders, AppData, browser data, SSH keys, or credential stores unless explicitly requested for a specific task.
- Preserve legacy compatibility; do not upgrade frameworks, packages, Bootstrap, DevExpress, C# language version, or SQL compatibility level without request.
- Never expose secrets. Mask suspicious values as `****`.
- Ask before destructive file, Git, SQL, deployment, or system-state changes.

## Standards

- Clear naming for report, bands, controls, and parameters.
- Stable data field mapping.
- Consistent fonts, margins, headers, footers, page numbers, and date formats.
- Separate template changes from business logic changes.
- Include sample data validation.
