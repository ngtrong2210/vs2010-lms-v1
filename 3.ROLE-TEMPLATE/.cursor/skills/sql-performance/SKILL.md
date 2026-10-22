---
name: sql-performance
description: Analyze SQL Server performance: indexes, execution plans, joins, CTEs, temp tables, stored procedures, functions, and query optimization.
---

# SQL Performance

## Safety baseline

- Work only in the current project/workspace under `G:\`.
- If the workspace is not under `G:\`, stop before reading source and ask the user to open a project under `G:\`.
- Do not scan other drives and do not scan all of `G:\`.
- Do not access user profiles, Windows folders, AppData, browser data, SSH keys, or credential stores unless explicitly requested for a specific task.
- Preserve legacy compatibility; do not upgrade frameworks, packages, Bootstrap, DevExpress, C# language version, or SQL compatibility level without request.
- Never expose secrets. Mask suspicious values as `****`.
- Ask before destructive file, Git, SQL, deployment, or system-state changes.

## Process

1. Capture query/procedure and expected parameters.
2. Inspect joins, predicates, sorting, grouping, scalar functions, CTE/temp table use.
3. Check indexes against predicates and join keys.
4. Look for non-sargable expressions and implicit conversions.
5. Recommend measured changes with validation plan.
