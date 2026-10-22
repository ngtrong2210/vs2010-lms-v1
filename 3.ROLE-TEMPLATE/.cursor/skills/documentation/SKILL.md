---
name: documentation
description: Write concise project documentation, setup notes, workflows, change notes, and technical guides for legacy enterprise projects.
---

# Documentation

## Safety baseline

- Work only in the current project/workspace under `G:\`.
- If the workspace is not under `G:\`, stop before reading source and ask the user to open a project under `G:\`.
- Do not scan other drives and do not scan all of `G:\`.
- Do not access user profiles, Windows folders, AppData, browser data, SSH keys, or credential stores unless explicitly requested for a specific task.
- Preserve legacy compatibility; do not upgrade frameworks, packages, Bootstrap, DevExpress, C# language version, or SQL compatibility level without request.
- Never expose secrets. Mask suspicious values as `****`.
- Ask before destructive file, Git, SQL, deployment, or system-state changes.

## Good documentation

- State purpose, scope, prerequisites, and steps.
- Include paths, commands, and configuration keys only when useful.
- Mask secrets and environment-specific credentials.
- Document legacy constraints and known risks.
- Keep docs close to related code when possible.
