---
name: safe-git-archive
description: Safely archive a project with Git: verify G drive workspace, .gitignore, staged diff, secrets, commit confirmation, and optional push confirmation.
disable-model-invocation: true
---

# Safe Git Archive

## Safety baseline

- Work only in the current project/workspace under `G:\`.
- If the workspace is not under `G:\`, stop before reading source and ask the user to open a project under `G:\`.
- Do not scan other drives and do not scan all of `G:\`.
- Do not access user profiles, Windows folders, AppData, browser data, SSH keys, or credential stores unless explicitly requested for a specific task.
- Preserve legacy compatibility; do not upgrade frameworks, packages, Bootstrap, DevExpress, C# language version, or SQL compatibility level without request.
- Never expose secrets. Mask suspicious values as `****`.
- Ask before destructive file, Git, SQL, deployment, or system-state changes.

Use only when the user explicitly says `LƯU TRỮ`, `lưu trữ project`, `commit project`, `backup project lên git`, `đẩy project lên github`, `lưu project này`, or `archive project`. Do not invoke automatically.

## Required workflow

1. Confirm the current project is under `G:\`. If not, stop before reading source.
2. Run read-only Git status and remote checks.
3. Inspect `.gitignore` for Visual Studio, .NET, ASP.NET, WinForms, MVC, SQL Server, DevExpress, Node, Zed, Windows, and secret patterns.
4. Review candidate files before staging. Do not run blind `git add -A`.
5. Refuse sensitive file names: `.env`, `.env.*`, `*.key`, `*.pem`, `*.pfx`, `*.p12`, `*.cer`, `*.crt`, `id_rsa`, `id_ed25519`, `credentials.json`, `secrets.json`, `secrets.*`, `connectionStrings.config`, `*.PublishSettings`, `*.pubxml.user`, `*.user`, `*.suo`.
6. Run `git diff --cached` after staging and scan for `password`, `pwd`, `secret`, `client_secret`, `api_key`, `apikey`, `access_token`, `refresh_token`, `private_key`, Bearer tokens, JWT-like strings, and connection strings with credentials.
7. If any secret is suspected, stop, report file/line, and mask value as `****`.
8. Show files prepared for commit and propose a short imperative commit message.
9. Ask for confirmation before commit.
10. Ask again before push.
11. Never force push, rewrite history, or delete branches.

## Repository boundary

`ZED-CODE-FULL` stores only skills, rules, templates, documentation, and safe scripts. Do not push user project source into this repository.
