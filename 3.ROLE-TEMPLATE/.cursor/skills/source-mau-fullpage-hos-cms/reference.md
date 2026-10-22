# Reference — Full Page từ source mẫu

## Canonical example (About / ve-tam-duc)

| Vai trò | Path |
|---------|------|
| Source mẫu | `z.Source-mẫu/ve-tam-duc/` |
| HOS control | `HOS/Controls/Information/About/SectionAboutUs.ascx` |
| HOS CSS inc | `HOS/Controls/Information/About/SectionAboutUs.css.inc` |
| HOS CSS file | `HOS/assets/cus/css/about.css` |
| HOS JS | `HOS/assets/cus/js/about-page.js` |
| HOS media | `HOS/Media/About/` |
| CMS builder | `CMS/Controls/AboutPage/` |
| CMS media | `CMS/Media/About/` |
| SQL hub | `SQL/CHUYENDOI/00_HUONG_DAN_CHAY_ABOUT_FULL_PAGE.txt` |
| Tools | `tools/generate-about-*.js` |

## Các Full Page đã có (copy pattern)

| Page | shellClass | CMS control | Handler import/basecss |
|------|------------|-------------|-------------------------|
| About | `.about-page` | `AboutPage` | Có |
| Khoa | `.khoa-phong-page` | `KhoaPage` | Chưa — nên nâng cấp giống About |
| Tiêm Chủng | `.tiem-chung-page` | `3Landing/TiemChung` | Có |
| Ban Lãnh Đạo | `.ban-lanh-dao-page` | `3Landing/BanLanhDao` | Có (generator riêng) |

**Page mới:** bám **About** (HTML-first + handler) hơn Khoa (fetch browser cũ).

## Cấu trúc HTML CMS bắt buộc

```html
<div class="{shellClass}">
  <div class="{shellBodyClass}">
    <!-- toàn bộ section từ mẫu -->
  </div>
</div>
```

GrapesJS `ensureShell()` / handler `Normalize*Shell` phải khớp class trên.

## CSS scoping (generate-about-css.js)

- `:root`, `body`, `html` → `.{shellClass}`
- `@keyframes`, `@font-face`: **không** prefix selector
- `@media`: scope nội dung bên trong block
- `url(../images/` → `url(/Media/{TenPage}/`
- Header file generated:

```css
@import url("https://fonts.googleapis.com/css2?family=Lexend:...&family=Be+Vietnam+Pro:...&display=swap");
```

Trên HOS: `@import` nằm **đầu** block `<style id="baseStyleId">` — OK.

Trên CMS iframe: dùng **link** riêng (`about-cms-fonts`), strip `@import` khỏi chuỗi inject.

## JS

1. Copy logic mẫu gần nguyên văn (jQuery-compatible, không ES6 module).
2. Scope init: chỉ chạy khi `document.querySelector('.{shellClass}')`.
3. Tích hợp HOS: Lenis/sticky/reveal nếu site đã có global hook (xem cuối `about-page.js`).
4. Không nhét JS vào CMS HTML seed (seed chỉ markup + class animation).

## Ảnh

1. Copy từ `z.Source-mẫu/.../images/` → `HOS/Media/{TenPage}/` và `CMS/Media/{TenPage}/`.
2. Replace path trong HTML/CSS/JS generators.
3. Placeholder SVG/PNG nếu mẫu thiếu file — liệt kê cho user.

## CMS Handler actions

```
GET  ?action=get
GET  ?action=versions
POST ?action=save
POST ?action=restore
GET  ?action=basecss      → { BaseCss: "..." }
GET  ?action=import&url=&languageId= → { Html, BaseCss }
```

`LoadBundledBaseCss`: `Server.MapPath("~/Controls/.../{ten-page}-base.css")`.

`ResolveFrontendUri`: absolute URL hoặc `CMSGlobal.WebsiteRoot` + path; cho phép localhost dev.

## CMS JS — load order (tránh treo editor)

```
requestJson get
  → state html/project/css
  → runWhenEditorReady
       → loadLanguage (HTML ≥30 ký tự trước ProjectJson)
       → loadBaseCssOnly (handler basecss)
       → refreshEditorCanvas
       → setBusy(false)
```

Không `await` fetch HOS từ browser trước `loadLanguage`.

## SQL seed guards

Sai: `LIKE '%class="ceo-section"%'` khi HTML là `class="section ceo-section"`.

Đúng: `LIKE '%ceo-section%'` (marker class substring).

## Deploy checklist (copy cho user)

**CMS**

- `bin/InformationCMS.dll` (rebuild sau sửa handler)
- `Controls/{TenPage}Page/*` (ascx, js, base.css, ashx)
- `Pages/{TenPage}Page/Edit.aspx`
- `Media/{TenPage}/`

**HOS**

- Section ascx + css.inc
- `assets/cus/css/`, `assets/cus/js/`
- `Media/{TenPage}/`

**SQL**

- Theo `00_HUONG_DAN_*` của page

## Anti-patterns

| Tránh | Làm thay |
|-------|----------|
| Fetch HOS trực tiếp từ CMS JS | Handler `import` |
| `@import` font sau CSS trong iframe | `<link id="*-cms-fonts">` |
| Font trang khác (Fraunces Khoa) vào About | Font đúng mẫu HTML |
| ProjectJson-only load | HTML-first |
| SELECT * trong SP mới | Cột cụ thể, patch file riêng |
| Sửa tay css.inc trên HOS | Sửa mẫu + chạy generator |

## User message mẫu

User: *“Đây là folder mẫu `z.Source-mẫu/ten-dich-vu`, tạo HOS + CMS builder, ảnh Media/TenDichVu”*

Agent:

1. Đọc skill này + metadata table.
2. Phân tích html/css/js/img.
3. Tạo/cập nhật generators + HOS + CMS + SQL.
4. Chạy generators + validation checklist.
5. Trả danh sách file copy + thứ tự SQL.
