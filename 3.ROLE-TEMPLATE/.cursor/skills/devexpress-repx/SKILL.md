---
name: devexpress-repx
description: Read, modify, and create DevExpress REPX reports while preserving DataSource, DataMember, ExpressionBindings, Parameters, bands, and page settings.
---

# Devexpress Repx

## Safety baseline

- Work only in the current project/workspace under `G:\`.
- If the workspace is not under `G:\`, stop before reading source and ask the user to open a project under `G:\`.
- Do not scan other drives and do not scan all of `G:\`.
- Do not access user profiles, Windows folders, AppData, browser data, SSH keys, or credential stores unless explicitly requested for a specific task.
- Preserve legacy compatibility; do not upgrade frameworks, packages, Bootstrap, DevExpress, C# language version, or SQL compatibility level without request.
- Never expose secrets. Mask suspicious values as `****`.
- Ask before destructive file, Git, SQL, deployment, or system-state changes.

## Critical rules

- Do not break existing bindings.
- Preserve `DataSource`, `DataMember`, `ExpressionBindings`, `Parameters`, calculated fields, bands, margins, paper kind, and page settings unless requested.
- Backup before changing templates.
- Prefer minimal XML changes.
- Check `XRLabel`, `XRTable`, bands, formatting strings, scripts, and parameter references.
