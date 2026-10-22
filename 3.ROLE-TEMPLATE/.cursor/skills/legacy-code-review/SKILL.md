---
name: legacy-code-review
description: Review legacy code with priority on compatibility, business behavior, low-risk improvements, and avoiding wholesale rewrites.
---

# Legacy Code Review

## Safety baseline

- Work only in the current project/workspace under `G:\`.
- If the workspace is not under `G:\`, stop before reading source and ask the user to open a project under `G:\`.
- Do not scan other drives and do not scan all of `G:\`.
- Do not access user profiles, Windows folders, AppData, browser data, SSH keys, or credential stores unless explicitly requested for a specific task.
- Preserve legacy compatibility; do not upgrade frameworks, packages, Bootstrap, DevExpress, C# language version, or SQL compatibility level without request.
- Never expose secrets. Mask suspicious values as `****`.
- Ask before destructive file, Git, SQL, deployment, or system-state changes.

## Principles

- Respect working behavior and business rules.
- Avoid rewrite suggestions unless necessary.
- Identify high-risk areas before edits.
- Prefer small, reversible improvements.
- Note compatibility constraints and hidden dependencies.
