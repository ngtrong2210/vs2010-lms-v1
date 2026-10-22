---
name: aspnet-mvc
description: Develop ASP.NET MVC on .NET Framework with controllers, views, models, routing, validation, filters, and secure patterns.
---

# Aspnet MVC

## Safety baseline

- Work only in the current project/workspace under `G:\`.
- If the workspace is not under `G:\`, stop before reading source and ask the user to open a project under `G:\`.
- Do not scan other drives and do not scan all of `G:\`.
- Do not access user profiles, Windows folders, AppData, browser data, SSH keys, or credential stores unless explicitly requested for a specific task.
- Preserve legacy compatibility; do not upgrade frameworks, packages, Bootstrap, DevExpress, C# language version, or SQL compatibility level without request.
- Never expose secrets. Mask suspicious values as `****`.
- Ask before destructive file, Git, SQL, deployment, or system-state changes.

## Checklist

- Keep routing and action signatures compatible.
- Use view models instead of exposing persistence models when appropriate.
- Validate `ModelState` server-side.
- Use anti-forgery tokens for state-changing forms.
- Encode output by default; avoid raw HTML unless audited.
- Keep filters, authorization attributes, and areas in mind.
- Do not convert to ASP.NET Core patterns.
