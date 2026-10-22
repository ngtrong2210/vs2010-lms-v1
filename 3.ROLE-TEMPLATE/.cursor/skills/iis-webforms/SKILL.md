---
name: iis-webforms
description: Configure and troubleshoot IIS for ASP.NET Web Forms/MVC on .NET Framework, app pools, handlers, permissions, and deployment issues.
---

# IIS Webforms

## Safety baseline

- Work only in the current project/workspace under `G:\`.
- If the workspace is not under `G:\`, stop before reading source and ask the user to open a project under `G:\`.
- Do not scan other drives and do not scan all of `G:\`.
- Do not access user profiles, Windows folders, AppData, browser data, SSH keys, or credential stores unless explicitly requested for a specific task.
- Preserve legacy compatibility; do not upgrade frameworks, packages, Bootstrap, DevExpress, C# language version, or SQL compatibility level without request.
- Never expose secrets. Mask suspicious values as `****`.
- Ask before destructive file, Git, SQL, deployment, or system-state changes.

## Checklist

- App pool .NET CLR version and integrated/classic pipeline.
- Application root and virtual directory.
- File/folder permissions for upload/log/temp/report folders.
- Handler/module mappings.
- Web.config inheritance and transforms.
- Request limits and timeout settings.
- Static content MIME types.

Ask before changing IIS settings or recycling app pools.
