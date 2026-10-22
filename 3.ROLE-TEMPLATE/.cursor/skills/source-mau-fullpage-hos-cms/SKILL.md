---
name: source-mau-fullpage-hos-cms
description: >-
  Tạo hoặc sync trang Full Page HOS + CMS GrapesJS builder từ thư mục mẫu
  (HTML/CSS/JS/ảnh) trong z.Source-mẫu. Giữ màu, cấu trúc, font, JS/animation.
  Ảnh vào Media/TenPage. Dùng khi user gửi source mẫu, tạo page mới, đồng bộ ve-tam-duc,
  About/Khoa/TiemChung builder, hoặc regenerate từ file mẫu.
---

# Full Page từ source mẫu (HOS + CMS Builder)

## Đầu vào từ user

User chỉ cần đặt **một thư mục mẫu** (hoặc chỉ đường dẫn) dạng:

```
z.Source-mẫu/{ten-page}/
  index.html          (hoặc *.html chính)
  css/                (style.css hoặc tương đương)
  js/                 (script trang)
  images/             (ảnh local trong mẫu)
```

Trước khi code, **xác nhận metadata** (hỏi nếu thiếu):

| Tham số | Ví dụ About | Ghi chú |
|---------|-------------|---------|
| `TenPage` | `About` | PascalCase, tên module |
| `ten-page` | `about` | slug file/tool |
| `shellClass` | `about-page` | wrapper bắt buộc trong HTML CMS |
| `shellBodyClass` | `about-page-body` | con trực tiếp (nếu mẫu có) |
| `baseStyleId` | `about-page-base-style` | `<style id="...">` trên HOS |
| `hosRoute` | `/ve-chung-toi-tam-duc/` | URL frontend |
| `mediaFolder` | `About` | `Media/{mediaFolder}/` |
| `sqlPrefix` | `CMS_AboutPage` | bảng + SP |
| `fallbackPageCode` | `AboutUs` | INFO content cũ (nếu có) |

**Nguyên tắc bất biến**

- Giữ **màu, layout, font, hover/reveal/animation** như mẫu (không “làm đẹp” thêm).
- Ảnh: copy → `HOS/Media/{TenPage}/` và `CMS/Media/{TenPage}/`; URL trong HTML/CSS là **`/Media/{TenPage}/...`** (không `../images/`).
- CSS scoped dưới **`.{shellClass}`**; không prefix `@keyframes`; `@media` scope bên trong.
- CMS: **HTML ưu tiên hơn ProjectJson** khi load editor; handler **`import` + `basecss`** (server), không fetch HOS từ browser.
- Font trong iframe editor: **`<link>` Google Fonts** trong canvas (xem About v16), không rely `@import` sau CSS khác.
- Stack: .NET 4, WebForms, VS2010, ADO.NET, SQL patch riêng (`sql-store-patches` skill).

## Luồng tổng thể

```
Source mẫu
  → tools/generate-* (css, js, seed SQL, optional INFO sync)
  → HOS (Section + css.inc + js + cmsTemplate)
  → SQL (schema → seed → kiểm tra)
  → CMS (Builder ascx + js + handler + about-base.css tương đương)
  → Deploy + test editor + frontend VI/EN + 3 device
```

## Bước 1 — Phân tích mẫu

1. Đọc `index.html`: phần nào là **nội dung trang** (section) vs **chrome site** (header/footer/transition/mini-cta) — chỉ đưa section vào CMS seed.
2. Liệt kê **font** trong HTML link + CSS `font-family` → một URL Google Fonts chung (như mẫu `index.html`, không copy font trang khác như Khoa Fraunces nếu mẫu không dùng).
3. Liệt kê **ảnh** trong HTML/CSS; map sang `/Media/{TenPage}/`.
4. Liệt kê **JS**: tách phần chỉ chạy trên full page (Lenis, sticky, reveal, tilt…) vs global site.
5. Ghi **marker section** cho SQL guard (vd. `%ceo-section%`, `%letterhead-section%`) — class thật có thể là `section ceo-section`.

## Bước 2 — Generators (`tools/`)

Clone pattern từ About (chuẩn sau fix 2026):

| Script | Output chính |
|--------|----------------|
| `generate-{ten-page}-css.js` | `HOS/.../Section*.css.inc`, `HOS/assets/cus/css/{ten-page}.css`, `CMS/Controls/{TenPage}Page/{ten-page}-base.css` |
| `generate-{ten-page}-js.js` | `HOS/assets/cus/js/{ten-page}-page.js` (+ hook HOS nếu cần) |
| `generate-{ten-page}-fullpage-seed.js` | `SQL/CHUYENDOI/02_CMS_*_Insert_NoiDungHienTai.sql` |
| `generate-{ten-page}-info-sync.js` | (tuỳ chọn) fallback INFO cũ |

Chạy (sau khi sửa mẫu):

```bash
node tools/generate-{ten-page}-css.js
node tools/generate-{ten-page}-js.js
node tools/generate-{ten-page}-fullpage-seed.js
```

Validate CSS generator: không `.about-page }` lệch; `@keyframes` không bị prefix; `@media` cân bằng `{}`.

## Bước 3 — HOS

**Mẫu tham chiếu:** `HOS/Controls/Information/About/SectionAboutUs.ascx` (+ `.ascx.cs`).

1. UserControl render:
   - `HasFullPage` → HTML/CSS từ SP CMS published.
   - Else → fallback INFO (nếu có).
2. `<style id="{baseStyleId}">` + include `*.css.inc`.
3. Wrapper: `<div class="{shellClass}"><div class="{shellBodyClass}">` …
4. `cmsTemplate=1` + `languageId`: CORS header, trả HTML sạch cho CMS import; không master chrome.
5. Register script `{ten-page}-page.js` khi full page (giống About).
6. Copy ảnh mẫu → `HOS/Media/{TenPage}/`.

## Bước 4 — SQL

**Mẫu:** `SQL/CHUYENDOI/01_CMS_AboutFullPage_Schema_Procedures.sql`, `02_*_Insert_*`, `00_HUONG_DAN_*`.

1. Patch riêng từng SP (skill `sql-store-patches`), format SQL project.
2. Seed HTML: cắt đúng range section; escape Unicode/Nvarchar; guard `RAISERROR` dùng `%class-marker%` linh hoạt.
3. Thứ tự deploy: xem file `00_HUONG_DAN_*` của page.

## Bước 5 — CMS Builder

**Mẫu ưu tiên:** `CMS/Controls/AboutPage/` (handler import/basecss) + tham khảo `TiemChung` cho canvas font.

| Thành phần | Pattern |
|------------|---------|
| `Pages/{TenPage}Page/Edit.aspx` | host builder |
| `{TenPage}PageBuilder.ascx` | GrapesJS + toolbar + flow 4 bước |
| `{ten-page}-page-builder.js` | `runWhenEditorReady`, `loadLanguage` ưu tiên HTML ≥30 ký tự, `readBundledBaseCss`, `readFrontend` → handler |
| `{TenPage}PageHandler.ashx.cs` | get, save, versions, restore, **import**, **basecss** |
| `{ten-page}-base.css` | copy từ generator; handler `MapPath` đọc file |
| `InformationCMS.csproj` | Content include js, ascx, **base.css**, handler |

Handler `import`: server `WebClient` fetch HOS `?cmsTemplate=1&languageId=`; extract root `.{shellClass}`; sanitize HTML.

Editor canvas:

- `ensureCanvasFonts(doc)` + URL font **trùng HOS/mẫu**.
- `stripFontImportsFromCss` khi inject `baseCss` vào `<style>`.
- `injectBaseCss` + reveal overrides (`.reveal`, `.lazy-fade`, …) để preview không “đen/trống”.

Thêm link vào `CMS/Pages/FullPage/List.aspx` (+ `.cs` URL frontend).

## Bước 6 — Kiểm tra (bắt buộc)

```text
[ ] node generators chạy không lỗi
[ ] SQL guard/insert pass trên DB dev
[ ] HOS: route mở đúng giao diện mẫu (màu/font/JS)
[ ] CMS: Edit load không kẹt "Đang xử lý"; canvas có nội dung
[ ] CMS: action=basecss trả CSS; action=import trả Html (rebuild DLL)
[ ] Font iframe = font HOS (Lexend/Be Vietnam Pro cho About)
[ ] Ảnh 200 OK /Media/{TenPage}/...
[ ] Lưu nháp + xuất bản + frontend nhận version mới
[ ] Ctrl+F5 sau deploy (bump ?v= trên ascx)
```

## Khi user chỉ gửi “thư mục mẫu mới”

1. Đặt vào `z.Source-mẫu/{folder}/`.
2. Nếu **page mới hoàn toàn**: nhân bản About/TiemChung → đổi tên theo bảng metadata; tạo SQL schema mới; đăng ký FullPage List.
3. Nếu **cập nhật page có sẵn** (vd. About): chỉ chạy lại generators + deploy file generated + SQL 02 (version mới).
4. Liệt kê file cần copy production cho user (HOS, CMS, SQL, Media).

## Tài liệu chi tiết

- Checklist file path, anti-patterns, ví dụ About: [reference.md](reference.md)
