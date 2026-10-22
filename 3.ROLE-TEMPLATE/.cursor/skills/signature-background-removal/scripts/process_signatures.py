from __future__ import annotations

import argparse
import re
import sys
from collections import deque
from pathlib import Path

import numpy as np
from PIL import Image, ImageDraw, ImageFilter


BLUE = (12, 73, 151)
IMAGE_EXTS = {".jpg", ".jpeg", ".png", ".bmp", ".tif", ".tiff"}

if hasattr(sys.stdout, "reconfigure"):
    sys.stdout.reconfigure(encoding="utf-8", errors="replace")


def remove_small_components(alpha: np.ndarray, minimum_area: int = 70) -> np.ndarray:
    mask = alpha >= 170
    height, width = mask.shape
    seen = np.zeros_like(mask, dtype=bool)
    kept_core = np.zeros_like(mask, dtype=bool)

    for sy, sx in np.argwhere(mask):
        if seen[sy, sx]:
            continue
        queue = deque([(int(sy), int(sx))])
        seen[sy, sx] = True
        component: list[tuple[int, int]] = []

        while queue:
            y, x = queue.popleft()
            component.append((y, x))
            y0, y1 = max(0, y - 1), min(height - 1, y + 1)
            x0, x1 = max(0, x - 1), min(width - 1, x + 1)
            for ny in range(y0, y1 + 1):
                for nx in range(x0, x1 + 1):
                    if not seen[ny, nx] and mask[ny, nx]:
                        seen[ny, nx] = True
                        queue.append((ny, nx))

        if len(component) >= minimum_area:
            ys, xs = zip(*component)
            kept_core[np.asarray(ys), np.asarray(xs)] = True

    halo = np.asarray(
        Image.fromarray((kept_core * 255).astype(np.uint8), "L").filter(ImageFilter.MaxFilter(5))
    ) > 0
    return np.where(halo, alpha, 0).astype(np.uint8)


def blue_alpha(source: Path) -> np.ndarray:
    rgb = np.asarray(Image.open(source).convert("RGB"), dtype=np.float32)
    r, g, b = rgb[..., 0], rgb[..., 1], rgb[..., 2]
    score = 0.68 * (b - r) + 0.32 * (b - g)
    t = np.clip((score - 3.5) / 34.0, 0.0, 1.0)
    t = t * t * (3.0 - 2.0 * t)
    alpha = np.rint(255.0 * np.power(t, 0.82)).astype(np.uint8)
    return remove_small_components(alpha)


def dark_alpha(source: Path) -> np.ndarray:
    rgb = np.asarray(Image.open(source).convert("RGB"), dtype=np.float32)
    r, g, b = rgb[..., 0], rgb[..., 1], rgb[..., 2]
    lum = 0.299 * r + 0.587 * g + 0.114 * b
    paper = float(np.percentile(lum, 88))
    t = np.clip(((paper - lum) - 25.0) / 45.0, 0.0, 1.0)
    t = t * t * (3.0 - 2.0 * t)
    alpha = np.rint(255.0 * np.power(t, 0.78)).astype(np.uint8)
    return remove_small_components(alpha)


def dilate(alpha: np.ndarray, size: int = 5) -> np.ndarray:
    if size <= 1:
        result = alpha.copy()
    else:
        result = np.asarray(
            Image.fromarray(alpha, "L").filter(ImageFilter.MaxFilter(size)), dtype=np.uint8
        )
    return np.minimum(255, np.rint(result.astype(np.float32) * 1.12)).astype(np.uint8)


def bounds(alpha: np.ndarray, margin: int = 24) -> tuple[int, int, int, int]:
    ys, xs = np.nonzero(alpha >= 8)
    if not len(xs):
        raise RuntimeError("No ink detected")
    height, width = alpha.shape
    return (
        max(0, int(xs.min()) - margin),
        max(0, int(ys.min()) - margin),
        min(width, int(xs.max()) + margin + 1),
        min(height, int(ys.max()) + margin + 1),
    )


def rgba_image(alpha: np.ndarray, crop: tuple[int, int, int, int]) -> Image.Image:
    left, top, right, bottom = crop
    a = alpha[top:bottom, left:right]
    rgba = np.full((a.shape[0], a.shape[1], 4), 255, dtype=np.uint8)
    visible = a > 0
    rgba[visible, 0], rgba[visible, 1], rgba[visible, 2] = BLUE
    rgba[..., 3] = a
    return Image.fromarray(rgba, "RGBA")


def smooth_alpha(image: Image.Image, radius: float) -> Image.Image:
    if radius <= 0:
        return image
    rgba = image.convert("RGBA")
    r, g, b, a = rgba.split()
    softened = a.filter(ImageFilter.GaussianBlur(radius))
    return Image.merge("RGBA", (r, g, b, softened))


def alpha_metrics(alpha: np.ndarray) -> tuple[int, int, int] | None:
    try:
        ink_alpha = dilate(alpha)
        left, top, right, bottom = bounds(ink_alpha)
    except RuntimeError:
        return None
    visible_area = int((ink_alpha >= 8).sum())
    bbox_area = (right - left) * (bottom - top)
    strong_area = int((ink_alpha >= 170).sum())
    return visible_area, bbox_area, strong_area


def select_alpha(source: Path) -> np.ndarray:
    blue = blue_alpha(source)
    dark = dark_alpha(source)
    blue_metrics = alpha_metrics(blue)
    dark_metrics = alpha_metrics(dark)

    if blue_metrics is None:
        return dark
    if dark_metrics is None:
        return blue

    blue_area, blue_bbox, _ = blue_metrics
    dark_area, dark_bbox, _ = dark_metrics
    blue_density = blue_area / blue_bbox if blue_bbox else 0.0
    dark_density = dark_area / dark_bbox if dark_bbox else 0.0

    if blue_density > 0.75 and dark_density < blue_density:
        return dark

    dark_not_bloated = dark_bbox <= blue_bbox * 3.0 and dark_area <= blue_area * 12.0
    dark_adds_clear_ink = blue_area * 1.4 < dark_area < blue_area * 3.0
    if dark_not_bloated and (blue_area < 10000 or dark_adds_clear_ink):
        return dark
    return blue


def output_name(source: Path, used: set[str]) -> str:
    matches = re.findall(r"\d{12}", source.stem)
    base = matches[0] if matches else re.sub(r"[^A-Za-z0-9_-]+", "-", source.stem).strip("-")
    base = base or "chu-ky"
    candidate = f"{base}.png"
    if candidate not in used:
        used.add(candidate)
        return candidate
    index = 1
    while True:
        candidate = f"{base}-{index}.png"
        if candidate not in used:
            used.add(candidate)
            return candidate
        index += 1


def parse_rotations(values: list[str]) -> dict[str, int]:
    rotations: dict[str, int] = {}
    for value in values:
        key, angle_text = value.split("=", 1)
        angle = int(angle_text)
        if angle not in {-90, 90, 180}:
            raise ValueError(f"Unsupported rotation angle: {value}")
        rotations[key.removesuffix(".png")] = angle
    return rotations


def make_preview(files: list[Path], preview: Path) -> None:
    thumb_w, thumb_h = 720, 190
    panels: list[Image.Image] = []
    for path in files:
        im = Image.open(path).convert("RGBA")
        scale = min((thumb_w - 20) / im.width, (thumb_h - 42) / im.height)
        thumb = im.resize((round(im.width * scale), round(im.height * scale)), Image.Resampling.LANCZOS)
        panel = Image.new("RGB", (thumb_w, thumb_h), "white")
        panel.paste(thumb, ((thumb_w - thumb.width) // 2, 30 + (thumb_h - 42 - thumb.height) // 2), thumb)
        ImageDraw.Draw(panel).text((8, 8), path.name, fill=(0, 0, 0))
        panels.append(panel)

    sheet = Image.new("RGB", (thumb_w, thumb_h * len(panels)), (232, 232, 232))
    for index, panel in enumerate(panels):
        sheet.paste(panel, (0, index * thumb_h))
    sheet.save(preview, quality=92, optimize=True)


def process(
    source_dir: Path,
    sample: Path,
    out_dir: Path,
    rotations: dict[str, int],
    min_ink_width: int,
    min_ink_height: int,
    stroke_size: int,
    smooth_radius: float,
) -> None:
    out_dir.mkdir(parents=True, exist_ok=True)
    for existing in out_dir.iterdir():
        if existing.is_file():
            existing.unlink()

    sample_image = Image.open(sample).convert("RGBA")
    canvas_size = sample_image.size
    sample_bbox = sample_image.getchannel("A").getbbox()
    if not sample_bbox:
        raise RuntimeError("Sample image has no visible ink")
    target_w = sample_bbox[2] - sample_bbox[0]
    target_h = sample_bbox[3] - sample_bbox[1]

    used: set[str] = set()
    outputs: list[Path] = []
    for source in sorted(p for p in source_dir.iterdir() if p.is_file() and p.suffix.lower() in IMAGE_EXTS):
        alpha = select_alpha(source)
        ink_alpha = dilate(alpha, stroke_size)
        ink = rgba_image(ink_alpha, bounds(ink_alpha))

        out_name = output_name(source, used)
        rotation_key = Path(out_name).stem
        if rotation_key in rotations:
            ink = ink.rotate(rotations[rotation_key], expand=True)
        elif ink.height > ink.width:
            ink = ink.rotate(90, expand=True)

        max_fit_scale = min(target_w / ink.width, target_h / ink.height)
        min_readable_scale = 1.0
        if min_ink_width and ink.width < min_ink_width:
            min_readable_scale = max(min_readable_scale, min_ink_width / ink.width)
        if min_ink_height and ink.height < min_ink_height:
            min_readable_scale = max(min_readable_scale, min_ink_height / ink.height)
        scale = min(max_fit_scale, min_readable_scale)
        if scale != 1.0:
            ink = ink.resize((round(ink.width * scale), round(ink.height * scale)), Image.Resampling.LANCZOS)
            ink = ink.filter(ImageFilter.UnsharpMask(radius=1.2, percent=115, threshold=3))
        ink = smooth_alpha(ink, smooth_radius)

        canvas = Image.new("RGBA", canvas_size, (255, 255, 255, 0))
        canvas.alpha_composite(ink, ((canvas.width - ink.width) // 2, (canvas.height - ink.height) // 2))
        output = out_dir / out_name
        canvas.save(output, optimize=True)
        outputs.append(output)

    make_preview(outputs, out_dir / "_preview.jpg")
    print(f"PROCESSED {len(outputs)}")
    print(f"CANVAS {canvas_size[0]}x{canvas_size[1]}")
    print(f"PREVIEW {out_dir / '_preview.jpg'}")


def main() -> None:
    parser = argparse.ArgumentParser()
    parser.add_argument("--source-dir", type=Path, required=True)
    parser.add_argument("--sample", type=Path, required=True)
    parser.add_argument("--out-dir", type=Path)
    parser.add_argument("--rotate", action="append", default=[])
    parser.add_argument("--min-ink-width", type=int, default=0)
    parser.add_argument("--min-ink-height", type=int, default=0)
    parser.add_argument("--stroke-size", type=int, default=5)
    parser.add_argument("--smooth-radius", type=float, default=0.0)
    args = parser.parse_args()
    source_dir = args.source_dir.resolve()
    out_dir = args.out_dir.resolve() if args.out_dir else source_dir / "out"
    process(
        source_dir,
        args.sample.resolve(),
        out_dir,
        parse_rotations(args.rotate),
        args.min_ink_width,
        args.min_ink_height,
        args.stroke_size,
        args.smooth_radius,
    )


if __name__ == "__main__":
    main()
