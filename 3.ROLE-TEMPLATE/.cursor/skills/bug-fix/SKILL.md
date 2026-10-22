---
name: bug-fix
description: Debug by reproducing or tracing root cause first, then make minimal targeted fixes and validate behavior.
---

# Bug Fix

## Safety baseline

- Work only in the current project/workspace under `G:\`.
- If the workspace is not under `G:\`, stop before reading source and ask the user to open a project under `G:\`.
- Do not scan other drives and do not scan all of `G:\`.
- Do not access user profiles, Windows folders, AppData, browser data, SSH keys, or credential stores unless explicitly requested for a specific task.
- Preserve legacy compatibility; do not upgrade frameworks, packages, Bootstrap, DevExpress, C# language version, or SQL compatibility level without request.
- Never expose secrets. Mask suspicious values as `****`.
- Ask before destructive file, Git, SQL, deployment, or system-state changes.

## Process

1. Understand expected vs actual behavior.
2. Reproduce or inspect the failing path.
3. Trace inputs, state, dependencies, and recent changes.
4. Identify root cause before editing.
5. Make the smallest safe fix.
6. Validate with focused test/manual scenario.
