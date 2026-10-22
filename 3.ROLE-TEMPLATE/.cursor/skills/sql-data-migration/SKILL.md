---
name: sql-data-migration
description: Plan and write SQL Server data migrations with explicit scope, transaction, validation queries, rollback, and user confirmation.
disable-model-invocation: true
---

# SQL Data Migration

## Safety baseline

- Work only in the current project/workspace under `G:\`.
- If the workspace is not under `G:\`, stop before reading source and ask the user to open a project under `G:\`.
- Do not scan other drives and do not scan all of `G:\`.
- Do not access user profiles, Windows folders, AppData, browser data, SSH keys, or credential stores unless explicitly requested for a specific task.
- Preserve legacy compatibility; do not upgrade frameworks, packages, Bootstrap, DevExpress, C# language version, or SQL compatibility level without request.
- Never expose secrets. Mask suspicious values as `****`.
- Ask before destructive file, Git, SQL, deployment, or system-state changes.

Use only when explicitly requested. Do not invoke automatically.

## Workflow

1. Define source, target, row count estimate, and business rule.
2. Confirm backup exists.
3. Write validation queries before migration.
4. Use transaction.
5. Include `SELECT BEFORE` and `SELECT AFTER`.
6. Provide rollback script or `ROLLBACK` option.
7. Do not auto-commit high-risk migrations.
8. Ask before running any migration script.
