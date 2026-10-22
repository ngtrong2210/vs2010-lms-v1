---
name: tach-nen-chu-ky-zed
description: "Use when tách nền chữ ký số in the ZED project folder, especially CD21 IN/OUT signature images, tach_nen, PNG nền trong suốt, canvas CD21, blue ink, or ID-based output names."
---

# Tách Nền Chữ Ký ZED

## Overview

Use the existing ZED signature rules instead of guessing. The project keeps source photos in `IN`, final transparent PNG files in `OUT`, and CD21 outputs usually use a `1844x853` transparent canvas with blue ink.

Project root:

```text
G:\1.1-PROJECT-MAIN\ZED\9.LƯU TRỮ-KHÁC\tách nên chữ ký số
```

## Rules Found In The Project

| Topic | Rule |
|---|---|
| Input | Source JPG/PNG stays in `CD21\IN` or the relevant source folder. Do not replace the source photo. |
| Output | Final PNG goes to the sibling `OUT` folder unless the user explicitly names another destination. |
| Filename | Use the first 12-digit ID in the source filename, e.g. `024079013357.jpg` -> `024079013357.png`. |
| CD21 canvas | Prefer `1844x853`, matching most `CD21\Các khoaa\OUT-ALL` files and `CD21\OUT\027082010271.png`. |
| General sample canvas | The common sample set in `chữ ký mẫu đã tách nền` is mostly `1663x782`; use it only when working from that sample family, not ordinary CD21 batch output. |
| Ink color | Default blue is `RGB(12, 73, 151)` / `#0c4997`. Some old files use nearby blues; keep blue unless the user asks for black. |
| Recommended style | The project guide recommends `chu-ky-tach-nen-dam-in-kim-net-mong-hon.png` for electronic documents. For CD21 batch work, start with thinner readable strokes. |
| Transparency | Final files must be `RGBA` with real alpha; no white paper background. |

## Workflow

Use `G:\.codex\skills\signature-background-removal\scripts\process_signatures.py` for ordinary photographed signatures.

Important: the helper deletes existing files in its `--out-dir` before writing. Never pass a shared folder such as `CD21\OUT` directly as `--out-dir`. Export to a temporary folder first, inspect `_preview.jpg`, then copy only the final PNG into `OUT`.

Recommended CD21 command shape:

```powershell
$tempRoot = 'G:\.codex\visualizations\<date>\<task>\signature-work'
$srcDir = Join-Path $tempRoot 'src'
$outDir = Join-Path $tempRoot 'out'
New-Item -ItemType Directory -Force -Path $srcDir, $outDir | Out-Null
Copy-Item -LiteralPath '<CD21\IN\source.jpg>' -Destination (Join-Path $srcDir '<source.jpg>') -Force

& 'C:\Users\trong\.cache\codex-runtimes\codex-primary-runtime\dependencies\python\python.exe' `
  'G:\.codex\skills\signature-background-removal\scripts\process_signatures.py' `
  --source-dir $srcDir `
  --sample 'G:\1.1-PROJECT-MAIN\ZED\9.LƯU TRỮ-KHÁC\tách nên chữ ký số\CD21\OUT\027082010271.png' `
  --out-dir $outDir `
  --stroke-size 1 `
  --smooth-radius 0.4
```

Use `--stroke-size 1` for "ít đậm", "mảnh hơn", or ordinary CD21 signatures. Use `--stroke-size 3` if the preview looks too light. Avoid `--stroke-size 5` unless the user asks for bold/heavy strokes.

## Visual QA

Always inspect `_preview.jpg` before copying to `OUT`.

Check:

- Signature is horizontal and upright.
- Paper background is gone.
- Blue strokes are readable but not overly bold.
- Long underline or tail is not cropped.
- The signature is centered on the transparent canvas.

If the preview is wrong:

| Symptom | Fix |
|---|---|
| Too bold | Rerun with smaller `--stroke-size`, usually `1`. |
| Too faint | Rerun with `--stroke-size 3`. |
| Jagged edge | Use `--smooth-radius 0.4` to `0.6`. |
| Wrong direction | Rerun with `--rotate ID=90`, `--rotate ID=-90`, or `--rotate ID=180`. |
| Wrong canvas | Confirm the sample PNG; CD21 ordinary output should use `CD21\OUT\027082010271.png` as sample. |

## Final Verification

After copying to `OUT`, verify with PIL:

```powershell
$code = @'
from pathlib import Path
from PIL import Image
p = Path(r'<final OUT png>')
im = Image.open(p).convert('RGBA')
a = im.getchannel('A')
print('exists', p.exists())
print('size', im.size)
print('mode', im.mode)
print('alpha_extrema', a.getextrema())
print('alpha_bbox', a.getbbox())
'@
$code | & 'C:\Users\trong\.cache\codex-runtimes\codex-primary-runtime\dependencies\python\python.exe' -
```

Expected for CD21: `size (1844, 853)`, `mode RGBA`, and `alpha_extrema (0, 255)`. Also confirm no accidental PNG remains in `IN` unless the user requested it.
