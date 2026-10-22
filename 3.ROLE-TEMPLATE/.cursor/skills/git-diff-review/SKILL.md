---
name: git-diff-review
description: Review Git changes before commit for intent, sensitive files, secrets, risky deletions, and unintended modifications.
---

# Git Diff Review

## Safety baseline

- Work only in the current project/workspace under `G:\`.
- If the workspace is not under `G:\`, stop before reading source and ask the user to open a project under `G:\`.
- Do not scan other drives and do not scan all of `G:\`.
- Do not access user profiles, Windows folders, AppData, browser data, SSH keys, or credential stores unless explicitly requested for a specific task.
- Preserve legacy compatibility; do not upgrade frameworks, packages, Bootstrap, DevExpress, C# language version, or SQL compatibility level without request.
- Never expose secrets. Mask suspicious values as `****`.
- Ask before destructive file, Git, SQL, deployment, or system-state changes.

## Checklist

- Show changed files summary.
- Identify generated/binary/sensitive files.
- Review diff for accidental secrets and credentials.
- Check for unintended large rewrites, deletions, or formatting churn.
- Suggest a concise commit message if safe.

Do not commit. Use `safe-git-archive` for commit workflow.
