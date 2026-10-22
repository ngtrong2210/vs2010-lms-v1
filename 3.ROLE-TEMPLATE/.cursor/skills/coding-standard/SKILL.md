---
name: coding-standard
description: Apply C# legacy coding conventions consistent with the existing project style, naming, structure, and compatibility constraints.
---

# Coding Standard

## Safety baseline

- Work only in the current project/workspace under `G:\`.
- If the workspace is not under `G:\`, stop before reading source and ask the user to open a project under `G:\`.
- Do not scan other drives and do not scan all of `G:\`.
- Do not access user profiles, Windows folders, AppData, browser data, SSH keys, or credential stores unless explicitly requested for a specific task.
- Preserve legacy compatibility; do not upgrade frameworks, packages, Bootstrap, DevExpress, C# language version, or SQL compatibility level without request.
- Never expose secrets. Mask suspicious values as `****`.
- Ask before destructive file, Git, SQL, deployment, or system-state changes.

## Rules

- Follow existing project style over generic preferences.
- Keep naming consistent for controls, fields, methods, DTOs, and database objects.
- Use explicit, readable code suitable for legacy maintenance.
- Avoid large formatting-only diffs.
- Preserve comments that explain business rules.
