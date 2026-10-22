---
name: csharp-legacy
description: Write C# compatible with legacy projects and older compilers, avoiding unsupported syntax and risky rewrites.
---

# Csharp Legacy

## Safety baseline

- Work only in the current project/workspace under `G:\`.
- If the workspace is not under `G:\`, stop before reading source and ask the user to open a project under `G:\`.
- Do not scan other drives and do not scan all of `G:\`.
- Do not access user profiles, Windows folders, AppData, browser data, SSH keys, or credential stores unless explicitly requested for a specific task.
- Preserve legacy compatibility; do not upgrade frameworks, packages, Bootstrap, DevExpress, C# language version, or SQL compatibility level without request.
- Never expose secrets. Mask suspicious values as `****`.
- Ask before destructive file, Git, SQL, deployment, or system-state changes.

## Compatibility rules

- Avoid modern syntax unless already supported: records, nullable refs, target-typed `new`, `using var`, file-scoped namespaces, switch expressions.
- Prefer explicit types and simple control flow when compatibility is unclear.
- Preserve public APIs, serialization names, designer patterns, and event signatures.
- Do not convert large areas to LINQ if it changes behavior or debugging.
