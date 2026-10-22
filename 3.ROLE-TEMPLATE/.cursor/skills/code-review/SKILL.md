---
name: code-review
description: Review C# code for correctness, maintainability, security, compatibility, and testability without changing source unless asked.
---

# Code Review

## Safety baseline

- Work only in the current project/workspace under `G:\`.
- If the workspace is not under `G:\`, stop before reading source and ask the user to open a project under `G:\`.
- Do not scan other drives and do not scan all of `G:\`.
- Do not access user profiles, Windows folders, AppData, browser data, SSH keys, or credential stores unless explicitly requested for a specific task.
- Preserve legacy compatibility; do not upgrade frameworks, packages, Bootstrap, DevExpress, C# language version, or SQL compatibility level without request.
- Never expose secrets. Mask suspicious values as `****`.
- Ask before destructive file, Git, SQL, deployment, or system-state changes.

## Review focus

- Correctness and edge cases.
- Security risks and secret exposure.
- Legacy compatibility.
- Readability and maintainability.
- Error handling and validation.
- Performance risks.

Group findings by severity with file/line, explanation, and minimal recommended fix.
