---
name: winforms-refactor
description: Refactor legacy WinForms safely with small steps, preserving designer code, events, bindings, and behavior.
---

# Winforms Refactor

## Safety baseline

- Work only in the current project/workspace under `G:\`.
- If the workspace is not under `G:\`, stop before reading source and ask the user to open a project under `G:\`.
- Do not scan other drives and do not scan all of `G:\`.
- Do not access user profiles, Windows folders, AppData, browser data, SSH keys, or credential stores unless explicitly requested for a specific task.
- Preserve legacy compatibility; do not upgrade frameworks, packages, Bootstrap, DevExpress, C# language version, or SQL compatibility level without request.
- Never expose secrets. Mask suspicious values as `****`.
- Ask before destructive file, Git, SQL, deployment, or system-state changes.

## Process

1. Identify current behavior and event flow.
2. Extract pure helper methods where low risk.
3. Keep control names, event signatures, and designer wiring unchanged.
4. Avoid changing UI layout and business logic in the same step.
5. Validate with focused manual/test scenarios.

Avoid rewriting whole forms or moving designer-dependent code.
