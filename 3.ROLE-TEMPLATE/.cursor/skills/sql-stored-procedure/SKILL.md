---
name: sql-stored-procedure
description: Write or refactor SQL Server stored procedures safely with parameters, transactions, error handling, and compatibility.
---

# SQL Stored Procedure

## Safety baseline

- Work only in the current project/workspace under `G:\`.
- If the workspace is not under `G:\`, stop before reading source and ask the user to open a project under `G:\`.
- Do not scan other drives and do not scan all of `G:\`.
- Do not access user profiles, Windows folders, AppData, browser data, SSH keys, or credential stores unless explicitly requested for a specific task.
- Preserve legacy compatibility; do not upgrade frameworks, packages, Bootstrap, DevExpress, C# language version, or SQL compatibility level without request.
- Never expose secrets. Mask suspicious values as `****`.
- Ask before destructive file, Git, SQL, deployment, or system-state changes.

## Checklist

- Validate parameters and defaults.
- Keep result set shape compatible with callers.
- Use `SET NOCOUNT ON` when appropriate.
- Use transactions for multi-step modifications.
- Use `TRY...CATCH` when project style supports it.
- Avoid dynamic SQL; if needed, use `sp_executesql` with parameters.
