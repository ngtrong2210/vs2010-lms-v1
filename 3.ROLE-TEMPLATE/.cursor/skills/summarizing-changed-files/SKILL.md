---
name: summarizing-changed-files
description: Use when finishing coding, SQL, document, or workspace changes and preparing a final response or handoff, especially after editing files, stored procedures, patches, tests, or generated artifacts.
---

# Summarizing Changed Files

## Core Rule

When the task involved changing files, the final response must include a concise changed-files summary. The user should be able to see exactly what was touched, why it was touched, and which deployable artifact matters most.

## What To Include

Add a short section such as `Files changed` or weave it into the final answer when the task is tiny. Include:

- Each changed file path, using clickable file links when available.
- A one-line purpose for each file.
- For SQL/stored procedure work, name both the full dump/store file and the separate runnable patch file; if an object was altered, name the CREATE-definition archive file (not a DB backup table).
- Any verification command that was run and its result.
- Any verification that could not run, with the actual blocker.

If no files were changed, say that clearly instead of inventing a list.

## Keep It Useful

Prefer a compact list over a long narrative. Group related files together when it helps scanning, for example `C# UI`, `SQL`, and `Tests`. Do not paste large diffs unless the user asks for them.

## Common Mistakes

| Mistake | Fix |
|---|---|
| Saying only "done" | Include the changed-files summary before closing. |
| Mentioning tests but not files | List the files and then verification. |
| SQL patch exists but is buried | Call out the patch file explicitly as the file to copy/run. |
| Build/test failed | Report the failure and the blocker plainly. |
