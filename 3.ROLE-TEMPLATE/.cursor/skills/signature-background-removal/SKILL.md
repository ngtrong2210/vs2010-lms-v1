---
name: signature-background-removal
description: Use when batch-processing photographed or scanned signature image folders into transparent PNGs with normalized canvas size, blue ink styling, ID-based filenames, and manual orientation checks.
---

# Signature Background Removal

## Overview

Convert a folder of signature photos/scans into one transparent PNG per source image. Match the user's reference signature style: blue ink, strong readable strokes, the same canvas width and height as the sample image, and no upscaling that makes small signatures blurry.

## Workflow

1. Use the helper script in `scripts/process_signatures.py`.
2. Pass the source folder and a reference transparent PNG with the desired canvas size.
3. Inspect the generated `_preview.jpg` before claiming completion.
4. If any signature is sideways or upside down, rerun with `--rotate ID=ANGLE`, where `ANGLE` is one of `90`, `-90`, or `180`.
5. If signatures are too tiny in the fixed canvas, rerun with `--min-ink-width` and `--min-ink-height` so the visible ink is scaled up before centering.
6. Remove the preview only after visual QA is done unless the user asks to keep it.

Recommended command shape:

```powershell
& 'C:\Users\trong\.cache\codex-runtimes\codex-primary-runtime\dependencies\python\python.exe' `
  'G:\.codex\skills\signature-background-removal\scripts\process_signatures.py' `
  --source-dir '<folder containing source jpg/png signatures>' `
  --sample '<reference transparent png>' `
  --out-dir '<source folder>\out'
```

## Output Rules

- Create/use an `out` folder inside the source folder unless the user gives another output path.
- Output exactly one `.png` per source image.
- Name files from the first 12-digit number found in the source filename:
  - `CD21041- 033093014536.jpg` -> `033093014536.png`
  - `CD21051- 060082011394-TRAN PHU QUY.jpg` -> `060082011394.png`
  - `CD21011, 052085008938.jpg` -> `052085008938.png`
- If an output name already exists in the same run, append `-1`, `-2`, etc.
- Use the sample image's canvas size for every output.
- Crop to ink, scale down only when needed to fit the sample's visible ink box, and center on a transparent canvas.
- Keep alpha transparency; do not leave white paper in the final PNG.

## Visual QA

Always inspect `_preview.jpg` on a white background before finalizing. The most common errors are:

| Symptom | Fix |
|---|---|
| Signature still vertical | Rerun with `--rotate ID=90` or `--rotate ID=-90` |
| Signature upside down | Rerun with `--rotate ID=180` |
| Signature too tiny in the canvas | Rerun with `--min-ink-width 650 --min-ink-height 220`, then inspect preview |
| Ink is too bold | Rerun with a smaller `--stroke-size`, for example `--stroke-size 3` |
| Ink is thinner but should look larger | Combine smaller `--stroke-size` with larger min ink values, for example `--min-ink-width 760 --min-ink-height 270` |
| Edges look jagged after upscaling | Add light alpha smoothing, for example `--smooth-radius 0.6` |
| Small signature blown up and blurry | Lower the min-ink values; do not exceed the sample ink box |
| Wrong filename | Confirm the source filename contains a 12-digit ID |

After QA, verify:

```powershell
Get-ChildItem '<out>' -File
```

and with PIL confirm all PNGs share the sample size and alpha has `(0, 255)`.
