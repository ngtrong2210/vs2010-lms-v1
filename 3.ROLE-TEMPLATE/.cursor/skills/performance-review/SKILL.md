---
name: performance-review
description: Find performance bottlenecks in C#, SQL Server, ASP.NET Web Forms/MVC, WinForms, and reporting code.
---

# Performance Review

## Safety baseline

- Work only in the current project/workspace under `G:\`.
- If the workspace is not under `G:\`, stop before reading source and ask the user to open a project under `G:\`.
- Do not scan other drives and do not scan all of `G:\`.
- Do not access user profiles, Windows folders, AppData, browser data, SSH keys, or credential stores unless explicitly requested for a specific task.
- Preserve legacy compatibility; do not upgrade frameworks, packages, Bootstrap, DevExpress, C# language version, or SQL compatibility level without request.
- Never expose secrets. Mask suspicious values as `****`.
- Ask before destructive file, Git, SQL, deployment, or system-state changes.

## Areas

- C#: loops, allocations, blocking calls, repeated database calls.
- SQL: scans, missing indexes, non-sargable predicates, parameter sniffing.
- Web: ViewState size, session use, N+1 queries, caching.
- WinForms: UI thread blocking, large grids, inefficient binding.
- Reports: heavy expressions, data volume, repeated subreports.
