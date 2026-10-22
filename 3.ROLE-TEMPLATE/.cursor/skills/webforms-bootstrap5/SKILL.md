---
name: webforms-bootstrap5
description: Modernize ASP.NET Web Forms UI with Bootstrap 5 while preserving server controls, IDs, ViewState, and postback behavior.
---

# Webforms Bootstrap5

## Safety baseline

- Work only in the current project/workspace under `G:\`.
- If the workspace is not under `G:\`, stop before reading source and ask the user to open a project under `G:\`.
- Do not scan other drives and do not scan all of `G:\`.
- Do not access user profiles, Windows folders, AppData, browser data, SSH keys, or credential stores unless explicitly requested for a specific task.
- Preserve legacy compatibility; do not upgrade frameworks, packages, Bootstrap, DevExpress, C# language version, or SQL compatibility level without request.
- Never expose secrets. Mask suspicious values as `****`.
- Ask before destructive file, Git, SQL, deployment, or system-state changes.

## Rules

- Keep server control IDs and `runat="server"` intact.
- Add Bootstrap classes without breaking postback, validators, or JavaScript selectors.
- Do not upgrade Bootstrap version unless requested.
- Use responsive grid around existing controls.
- For `GridView`, apply table classes carefully and preserve generated columns/events.
- Check modal postback behavior, UpdatePanel compatibility, and MasterPage CSS/script order.
