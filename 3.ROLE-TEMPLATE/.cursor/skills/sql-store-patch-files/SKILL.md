---
name: sql-store-patch-files
description: Use when editing SQL stored procedures, store scripts, database functions, or large SQL dump files in this workspace and a deployable patch file should be kept separately.
---

# SQL Store Patch Files

## Overview

When changing a stored procedure or SQL function in a large dump file, also create a small deployable patch file for that changed object. The patch file makes the database change easy to review and run without hunting through a full export.

## Workflow

1. Identify each changed database object name, such as `SIM_Class_SearchForPermission`.
2. Create one SQL patch file per changed object in the same dated SQL folder as the source script when possible.
3. Prefix the patch filename with the next zero-padded sequence number already present in that folder:
   - If no numbered patch exists, start with `001-`.
   - If `001-...sql` and `002-...sql` exist, use `003-`.
4. Use a descriptive filename:
   - `001-alter-SIM_Class_SearchForPermission-add-ManagerTeacherID.sql`
   - `002-alter-ACC_ExampleStore-fix-date-filter.sql`
5. Prefer `ALTER PROCEDURE` / `ALTER FUNCTION` for existing objects. Include `SET ANSI_NULLS`, `SET QUOTED_IDENTIFIER`, and `GO` separators when the local scripts use them.
6. Before altering an existing object, save its old definition as a separate `.sql` file containing the original `CREATE PROCEDURE` / `CREATE FUNCTION` / `CREATE VIEW`. This is a **CREATE-definition archive**, not a database backup; keep it outside the numbered deploy sequence.
7. Never create `dbo.Backup_*` tables, use `SELECT ... INTO Backup_*`, copy business tables, or store object definitions in database tables. A newly created table is not a backup.
8. Keep the patch focused on the one changed object. Do not copy unrelated stores from the full dump.
9. Mention the patch and CREATE-definition archive filenames in the final response, and note whether the large dump file was also updated.

## Common Mistakes

- Leaving a store change only inside `full - store.sql`, which makes deployment easy to miss.
- Combining multiple unrelated store changes into one patch file.
- Forgetting the numeric prefix, which makes execution order unclear.
- Adding the sequence number after the descriptive name instead of at the beginning.
- Calling a newly created table a backup instead of saving the original executable `CREATE` definition as a `.sql` file.
