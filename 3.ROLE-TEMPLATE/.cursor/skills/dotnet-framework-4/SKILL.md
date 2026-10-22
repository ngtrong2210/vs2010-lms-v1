---
name: dotnet-framework-4
description: Guide changes for .NET Framework 4.x projects while preserving runtime, package, and language compatibility.
---

# Dotnet Framework 4

## Safety baseline

- Work only in the current project/workspace under `G:\`.
- If the workspace is not under `G:\`, stop before reading source and ask the user to open a project under `G:\`.
- Do not scan other drives and do not scan all of `G:\`.
- Do not access user profiles, Windows folders, AppData, browser data, SSH keys, or credential stores unless explicitly requested for a specific task.
- Preserve legacy compatibility; do not upgrade frameworks, packages, Bootstrap, DevExpress, C# language version, or SQL compatibility level without request.
- Never expose secrets. Mask suspicious values as `****`.
- Ask before destructive file, Git, SQL, deployment, or system-state changes.

## Rules

- Detect target framework from project files before using APIs.
- Do not upgrade framework or NuGet packages without request.
- Avoid APIs unavailable in the target framework.
- Keep `web.config`/`app.config` binding redirects consistent.
- Prefer minimal, compatible code over modern rewrites.
- Consider IIS, Web Forms/MVC pipeline, WinForms deployment, and DevExpress version constraints.
