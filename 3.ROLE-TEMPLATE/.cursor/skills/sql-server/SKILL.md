---
name: sql-server
description: Work with SQL Server and T-SQL queries, joins, transactions, stored procedures, functions, indexes, and safe database practices.
---

# SQL Server

## Safety baseline

- Work only in the current project/workspace under `G:\`.
- If the workspace is not under `G:\`, stop before reading source and ask the user to open a project under `G:\`.
- Do not scan other drives and do not scan all of `G:\`.
- Do not access user profiles, Windows folders, AppData, browser data, SSH keys, or credential stores unless explicitly requested for a specific task.
- Preserve legacy compatibility; do not upgrade frameworks, packages, Bootstrap, DevExpress, C# language version, or SQL compatibility level without request.
- Never expose secrets. Mask suspicious values as `****`.
- Ask before destructive file, Git, SQL, deployment, or system-state changes.

## Rules

- Understand schema, keys, data volume, and constraints before changes.
- Prefer parameterized queries.
- Avoid destructive operations without explicit confirmation.
- For data modifications, use `sql-safe-update` pattern.
- Consider transactions, isolation, locks, deadlocks, and indexes.
