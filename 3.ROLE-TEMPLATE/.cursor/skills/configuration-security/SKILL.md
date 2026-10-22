---
name: configuration-security
description: Inspect web.config/app.config and related settings for security issues while masking secrets and avoiding exposure.
---

# Configuration Security

## Safety baseline

- Work only in the current project/workspace under `G:\`.
- If the workspace is not under `G:\`, stop before reading source and ask the user to open a project under `G:\`.
- Do not scan other drives and do not scan all of `G:\`.
- Do not access user profiles, Windows folders, AppData, browser data, SSH keys, or credential stores unless explicitly requested for a specific task.
- Preserve legacy compatibility; do not upgrade frameworks, packages, Bootstrap, DevExpress, C# language version, or SQL compatibility level without request.
- Never expose secrets. Mask suspicious values as `****`.
- Ask before destructive file, Git, SQL, deployment, or system-state changes.

## Rules

- Do not display raw connection strings, passwords, keys, or tokens.
- Mask sensitive values as `****`.
- Check debug mode, customErrors, compilation, authentication, authorization, cookies, request limits, and connection string handling.
- Check transform/publish profiles for credential leakage.
- Recommend secure storage without forcing upgrades.
