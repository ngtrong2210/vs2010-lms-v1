---
name: excel-export-csharp
description: Implement C# Excel export with DataTable, column mapping, templates, formatting, formulas, validation, and .NET Framework compatibility.
---

# Excel Export Csharp

## Safety baseline

- Work only in the current project/workspace under `G:\`.
- If the workspace is not under `G:\`, stop before reading source and ask the user to open a project under `G:\`.
- Do not scan other drives and do not scan all of `G:\`.
- Do not access user profiles, Windows folders, AppData, browser data, SSH keys, or credential stores unless explicitly requested for a specific task.
- Preserve legacy compatibility; do not upgrade frameworks, packages, Bootstrap, DevExpress, C# language version, or SQL compatibility level without request.
- Never expose secrets. Mask suspicious values as `****`.
- Ask before destructive file, Git, SQL, deployment, or system-state changes.

## Checklist

- Confirm existing library before adding dependencies.
- Do not add/upgrade packages without request.
- Map `DataTable` columns explicitly.
- Preserve template formatting, formulas, merged cells, and print settings.
- Validate dates, numeric formats, encoding, and required columns.
- Avoid Excel Interop on server/IIS.
