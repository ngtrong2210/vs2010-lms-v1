---
name: devexpress-report
description: Design DevExpress reports for WinForms/.NET Framework with datasets, parameters, layout bands, formatting, and preview/export behavior.
---

# Devexpress Report

## Safety baseline

- Work only in the current project/workspace under `G:\`.
- If the workspace is not under `G:\`, stop before reading source and ask the user to open a project under `G:\`.
- Do not scan other drives and do not scan all of `G:\`.
- Do not access user profiles, Windows folders, AppData, browser data, SSH keys, or credential stores unless explicitly requested for a specific task.
- Preserve legacy compatibility; do not upgrade frameworks, packages, Bootstrap, DevExpress, C# language version, or SQL compatibility level without request.
- Never expose secrets. Mask suspicious values as `****`.
- Ask before destructive file, Git, SQL, deployment, or system-state changes.

## Checklist

- Confirm DevExpress version; do not upgrade without request.
- Define data source shape and parameters.
- Design bands: report header, page header, detail, group, footer.
- Use expression bindings compatible with project version.
- Validate print/export settings, margins, fonts, paper size, and localization.
