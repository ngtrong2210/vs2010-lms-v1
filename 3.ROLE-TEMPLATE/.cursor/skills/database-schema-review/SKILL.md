---
name: database-schema-review
description: Review SQL Server schema, PK/FK relationships, indexes, constraints, and migration risk before database changes.
---

# Database Schema Review

## Safety baseline

- Work only in the current project/workspace under `G:\`.
- If the workspace is not under `G:\`, stop before reading source and ask the user to open a project under `G:\`.
- Do not scan other drives and do not scan all of `G:\`.
- Do not access user profiles, Windows folders, AppData, browser data, SSH keys, or credential stores unless explicitly requested for a specific task.
- Preserve legacy compatibility; do not upgrade frameworks, packages, Bootstrap, DevExpress, C# language version, or SQL compatibility level without request.
- Never expose secrets. Mask suspicious values as `****`.
- Ask before destructive file, Git, SQL, deployment, or system-state changes.

## Checklist

- Primary keys and business keys.
- Foreign keys and cascade behavior.
- Unique constraints and indexes.
- Nullability and defaults.
- Column types, lengths, collations.
- Dependencies: views, stored procedures, functions, reports, application code.

Summarize risks, recommended changes, and rollback considerations.
