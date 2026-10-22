---
name: data-validation
description: Implement validation across client, server, and database layers for C#, Web Forms/MVC, WinForms, and SQL Server.
---

# Data Validation

## Safety baseline

- Work only in the current project/workspace under `G:\`.
- If the workspace is not under `G:\`, stop before reading source and ask the user to open a project under `G:\`.
- Do not scan other drives and do not scan all of `G:\`.
- Do not access user profiles, Windows folders, AppData, browser data, SSH keys, or credential stores unless explicitly requested for a specific task.
- Preserve legacy compatibility; do not upgrade frameworks, packages, Bootstrap, DevExpress, C# language version, or SQL compatibility level without request.
- Never expose secrets. Mask suspicious values as `****`.
- Ask before destructive file, Git, SQL, deployment, or system-state changes.

## Layers

- Client/UI: fast feedback, required fields, format hints.
- Server: authoritative validation, authorization-aware checks, business rules.
- Database: constraints, lengths, nullability, uniqueness where appropriate.

Treat all external input as untrusted and validate type, range, length, format, and dependencies.
