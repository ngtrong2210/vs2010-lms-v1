---
name: file-upload-security
description: Secure ASP.NET file upload and download flows against unsafe extensions, path traversal, execution, overwrite, and content risks.
---

# File Upload Security

## Safety baseline

- Work only in the current project/workspace under `G:\`.
- If the workspace is not under `G:\`, stop before reading source and ask the user to open a project under `G:\`.
- Do not scan other drives and do not scan all of `G:\`.
- Do not access user profiles, Windows folders, AppData, browser data, SSH keys, or credential stores unless explicitly requested for a specific task.
- Preserve legacy compatibility; do not upgrade frameworks, packages, Bootstrap, DevExpress, C# language version, or SQL compatibility level without request.
- Never expose secrets. Mask suspicious values as `****`.
- Ask before destructive file, Git, SQL, deployment, or system-state changes.

## Upload checklist

- Use extension allowlist and server-side validation.
- Generate safe file names; never trust client file name.
- Store outside executable web root when possible.
- Limit file size and validate content type/signature where practical.
- Prevent overwrite and path traversal.

## Download checklist

- Authorize access before serving.
- Normalize and constrain paths to allowed directory.
