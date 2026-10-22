---
name: authentication-security
description: Review and improve session, authentication, authorization, password, role, cookie, and redirect security.
---

# Authentication Security

## Safety baseline

- Work only in the current project/workspace under `G:\`.
- If the workspace is not under `G:\`, stop before reading source and ask the user to open a project under `G:\`.
- Do not scan other drives and do not scan all of `G:\`.
- Do not access user profiles, Windows folders, AppData, browser data, SSH keys, or credential stores unless explicitly requested for a specific task.
- Preserve legacy compatibility; do not upgrade frameworks, packages, Bootstrap, DevExpress, C# language version, or SQL compatibility level without request.
- Never expose secrets. Mask suspicious values as `****`.
- Ask before destructive file, Git, SQL, deployment, or system-state changes.

## Checklist

- Validate login flow, logout, timeout, and session regeneration.
- Check role/permission enforcement on every sensitive action.
- Secure cookies: HttpOnly, Secure where HTTPS, SameSite as appropriate.
- Avoid open redirects.
- Do not log passwords/tokens.
- Do not expose secret config values.
