---
name: deployment-check
description: Run a deployment checklist for IIS/.NET Framework apps with config, files, database, backup, rollback, and explicit confirmation.
disable-model-invocation: true
---

# Deployment Check

## Safety baseline

- Work only in the current project/workspace under `G:\`.
- If the workspace is not under `G:\`, stop before reading source and ask the user to open a project under `G:\`.
- Do not scan other drives and do not scan all of `G:\`.
- Do not access user profiles, Windows folders, AppData, browser data, SSH keys, or credential stores unless explicitly requested for a specific task.
- Preserve legacy compatibility; do not upgrade frameworks, packages, Bootstrap, DevExpress, C# language version, or SQL compatibility level without request.
- Never expose secrets. Mask suspicious values as `****`.
- Ask before destructive file, Git, SQL, deployment, or system-state changes.

Use only when explicitly requested. Do not invoke automatically.

## Checklist

- Confirm environment: dev/test/staging/production.
- Confirm backup and rollback plan.
- Check build output, config transforms, connection strings masked, permissions, app pool, .NET CLR version, pipeline mode.
- Check database scripts use safe transaction patterns.
- Check static assets and report/templates included.
- Ask before any command that modifies IIS/server state or deploys files.

Never automatically deploy.
