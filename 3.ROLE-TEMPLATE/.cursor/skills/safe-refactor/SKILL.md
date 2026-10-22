---
name: safe-refactor
description: Refactor code in small, behavior-preserving steps with dependency analysis, focused validation, and minimal risk.
---

# Safe Refactor

## Safety baseline

- Work only in the current project/workspace under `G:\`.
- If the workspace is not under `G:\`, stop before reading source and ask the user to open a project under `G:\`.
- Do not scan other drives and do not scan all of `G:\`.
- Do not access user profiles, Windows folders, AppData, browser data, SSH keys, or credential stores unless explicitly requested for a specific task.
- Preserve legacy compatibility; do not upgrade frameworks, packages, Bootstrap, DevExpress, C# language version, or SQL compatibility level without request.
- Never expose secrets. Mask suspicious values as `****`.
- Ask before destructive file, Git, SQL, deployment, or system-state changes.

## Workflow

- Identify current behavior and callers.
- Keep public APIs stable unless requested.
- Make small steps with clear intent.
- Do not mix formatting-only, behavior, and architecture changes unnecessarily.
- Validate after each meaningful step when possible.

Ask before large structural changes, schema changes, framework upgrades, or risky deletions.
