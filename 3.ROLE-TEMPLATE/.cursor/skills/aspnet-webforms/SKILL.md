---
name: aspnet-webforms
description: Work with ASP.NET Web Forms pages, code-behind, MasterPage, UserControl, ViewState, PostBack, GridView, UpdatePanel, Session, and Request/Response.
---

# Aspnet Webforms

## Safety baseline

- Work only in the current project/workspace under `G:\`.
- If the workspace is not under `G:\`, stop before reading source and ask the user to open a project under `G:\`.
- Do not scan other drives and do not scan all of `G:\`.
- Do not access user profiles, Windows folders, AppData, browser data, SSH keys, or credential stores unless explicitly requested for a specific task.
- Preserve legacy compatibility; do not upgrade frameworks, packages, Bootstrap, DevExpress, C# language version, or SQL compatibility level without request.
- Never expose secrets. Mask suspicious values as `****`.
- Ask before destructive file, Git, SQL, deployment, or system-state changes.

## Checklist

- Respect lifecycle: `Init`, `Load`, postback handling, `PreRender`.
- Preserve `runat="server"`, control IDs, event handlers, ViewState assumptions, and naming containers.
- Bind data only when appropriate, usually guarded by `!IsPostBack` unless intentional.
- Handle `GridView` events carefully: `RowDataBound`, `RowCommand`, paging, sorting.
- Avoid breaking `UpdatePanel` partial postbacks.
- Treat `Session`, `Request`, `Response`, query strings, and hidden fields as untrusted.
