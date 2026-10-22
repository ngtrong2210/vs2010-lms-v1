---
name: project-analyzer
description: Analyze project architecture, dependencies, frameworks, data flow, and risk before making significant code changes.
---

# Project Analyzer

## Safety baseline

- Work only in the current project/workspace under `G:\`.
- If the workspace is not under `G:\`, stop before reading source and ask the user to open a project under `G:\`.
- Do not scan other drives and do not scan all of `G:\`.
- Do not access user profiles, Windows folders, AppData, browser data, SSH keys, or credential stores unless explicitly requested for a specific task.
- Preserve legacy compatibility; do not upgrade frameworks, packages, Bootstrap, DevExpress, C# language version, or SQL compatibility level without request.
- Never expose secrets. Mask suspicious values as `****`.
- Ask before destructive file, Git, SQL, deployment, or system-state changes.

## Process

- Confirm project is under `G:\` and scope to current workspace.
- Identify solution/project files, target framework, app type, major dependencies.
- Map layers: UI, business logic, data access, reports, config.
- Identify database/report/template dependencies.
- Summarize risks and suggested change plan.

Do not scan outside the current project.
