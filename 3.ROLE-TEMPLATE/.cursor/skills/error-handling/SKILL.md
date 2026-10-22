---
name: error-handling
description: Design exception handling and logging for .NET Framework apps without swallowing errors or leaking sensitive data.
---

# Error Handling

## Safety baseline

- Work only in the current project/workspace under `G:\`.
- If the workspace is not under `G:\`, stop before reading source and ask the user to open a project under `G:\`.
- Do not scan other drives and do not scan all of `G:\`.
- Do not access user profiles, Windows folders, AppData, browser data, SSH keys, or credential stores unless explicitly requested for a specific task.
- Preserve legacy compatibility; do not upgrade frameworks, packages, Bootstrap, DevExpress, C# language version, or SQL compatibility level without request.
- Never expose secrets. Mask suspicious values as `****`.
- Ask before destructive file, Git, SQL, deployment, or system-state changes.

## Checklist

- Catch exceptions at meaningful boundaries.
- Do not swallow errors silently.
- Log actionable context without secrets or personal data.
- Preserve stack traces with `throw;` instead of `throw ex;`.
- Show user-friendly messages while keeping details in logs.
- For transactions, rollback on failure.
