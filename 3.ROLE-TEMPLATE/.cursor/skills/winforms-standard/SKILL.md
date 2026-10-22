---
name: winforms-standard
description: Build and maintain WinForms forms, events, controls, DataGridView, binding, validation, threading, and responsive UI behavior.
---

# Winforms Standard

## Safety baseline

- Work only in the current project/workspace under `G:\`.
- If the workspace is not under `G:\`, stop before reading source and ask the user to open a project under `G:\`.
- Do not scan other drives and do not scan all of `G:\`.
- Do not access user profiles, Windows folders, AppData, browser data, SSH keys, or credential stores unless explicitly requested for a specific task.
- Preserve legacy compatibility; do not upgrade frameworks, packages, Bootstrap, DevExpress, C# language version, or SQL compatibility level without request.
- Never expose secrets. Mask suspicious values as `****`.
- Ask before destructive file, Git, SQL, deployment, or system-state changes.

## Checklist

- Keep designer-generated code in `.Designer.cs` unless intentionally making designer-compatible layout edits.
- Preserve control names used by event handlers and bindings.
- Validate input before database/file operations.
- Use `DataSource`, `BindingSource`, and `DataTable` consistently.
- Preserve `DataGridView` columns, types, formatting, and selection behavior.
- Avoid blocking UI thread; use compatible async pattern or `BackgroundWorker`.
- Update UI only from UI thread.
