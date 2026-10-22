# KẾ HOẠCH CHI TIẾT: SỬA GIAO DIỆN INFORMATIONWEB THEO DESIGN SYSTEM

## TỔNG QUAN

**Đích đến**: Cập nhật toàn bộ giao diện InformationWeb (CMS & LMS) để tuân thủ Design System theo file `DESIGN_SYSTEM.md`

**Phạm vi**: 
- 2 Master Pages (Cms.Master, Lms.Master)
- Tất cả các trang CMS (16 trang)
- Tất cả các trang LMS (5 trang)
- CSS Components & Pages
- Controls/User Controls

**Nguyên tắc**:
1. Tuân thủ 100% Design System (màu sắc, typography, spacing, icons, components)
2. Không hardcode giá trị - dùng CSS variables
3. Phân chia thành các cụm công việc rõ ràng
4. Từng bước có thể test độc lập

---

## CỤM 1: THIẾT LẬP CSS VARIABLES & BASE STYLES

### 1.1. Tạo file CSS Variables (CSS Tokens)

**File cần tạo/modifikasi**: `assets/lms/css/core/design-tokens.css`

**Công việc**:
- [ ] Thêm tất cả CSS variables từ Design System
- [ ] Brand Colors (brand-green, brand-blue, brand-secondary, brand-red, brand-yellow, brand-success)
- [ ] Theme Colors (theme-navy, theme-sidebar)
- [ ] Text Colors (text-primary, text-secondary, text-muted, text-disabled, text-on-primary)
- [ ] Surface Colors (surface, page, soft-surface, soft-green, soft-blue, soft-yellow)
- [ ] Neutral Colors (neutral-line, neutral-line-strong)
- [ ] Typography Tokens (font-family, font-size scale, font-weight, line-height)
- [ ] Spacing Tokens (spacing-xs đến spacing-8xl)
- [ ] Border Radius Tokens (radius-xs đến radius-full)
- [ ] Shadow Tokens (shadow-xs đến shadow-2xl)
- [ ] Z-Index Tokens (z-index-base đến z-index-notification)

**Tham khảo**: Dán từ `DESIGN_SYSTEM.md` section "CSS Variables Reference" (dòng 3324-3398)

**Kết quả mong đợi**: File `design-tokens.css` chứa đầy đủ CSS variables

---

### 1.2. Cập nhật file Base CSS

**File cần modifikasi**: `assets/lms/css/core/base.css`

**Công việc**:
- [ ] Import `design-tokens.css` ở đầu file
- [ ] Cập nhật typography hệ thống theo Design System
- [ ] Áp dụng font-family: 'Be Vietnam Pro'
- [ ] Cập nhật typography hierarchy (page-title, section-title, card-title, eyebrow, etc.)
- [ ] Cập nhật form styles theo Design System
- [ ] Cập nhật button styles theo Design System
- [ ] Cập nhật table styles theo Design System

**Tham khảo**: 
- Typography system từ `DESIGN_SYSTEM.md` dòng 274-810
- Components từ dòng 2132-3157

**Kết quả mong đợi**: Base styles tuân thủ Design System

---

### 1.3. Cập nhật file Index CSS (Entry Point)

**File cần modifikasi**: `assets/lms/css/index.css`

**Công việc**:
- [ ] Import `design-tokens.css` đầu tiên
- [ ] Import `base.css` thứ hai
- [ ] Import tất cả component CSS theo thứ tự
- [ ] Import page-specific CSS cuối cùng

**Kết quả mong đợi**: File import CSS đúng thứ tự, có design tokens

---

## CỤM 2: CẬP NHẬT MASTER PAGES

### 2.1. Cập nhật Cms.Master (CMS Admin Layout)

**File cần modifikasi**: `MasterPages/Cms.Master`

**Công việc**:

#### 2.1.1. Head Section
- [ ] Thêm Google Fonts link cho Be Vietnam Pro
```html
<link rel="preconnect" href="https://fonts.googleapis.com">
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
<link href="https://fonts.googleapis.com/css2?family=Be+Vietnam+Pro:wght@400;500;600;700&display=swap" rel="stylesheet">
```
- [ ] Thêm Material Icons link (nếu cần)
- [ ] Đảm bảo import CSS files đúng thứ tự

#### 2.1.2. Sidebar
- [ ] Cập nhật brand logo styling theo Design System
- [ ] Cập nhật sidebar background: `--theme-sidebar` (#183b59)
- [ ] Cập nhật sidebar icon styling
- [ ] Cập nhật menu label typography: `--font-size-xs`, `--font-weight-semibold`
- [ ] Cập nhật sidebar link typography: `--font-size-ui`, `--font-weight-medium`
- [ ] Cập nhật sidebar hover/active states theo Design System
- [ ] Cập nhật sidebar width: `--sidebar-width` (252px)

#### 2.1.3. Topbar
- [ ] Cập nhật topbar height: `--topbar-height` (68px)
- [ ] Cập nhật topbar background: `--header` (#ffffff)
- [ ] Cập nhật topbar typography theo Design System
- [ ] Cập nhật search input styling
- [ ] Cập nhật notification button styling
- [ ] Cập nhật user avatar styling
- [ ] Cập nhật logout button: `btn-action-delete`

#### 2.1.4. Main Content Area
- [ ] Cập nhật page background: `--page` (#f3f5f7)
- [ ] Cập nhật content padding theo spacing scale
- [ ] Cập nhật typography trong content area

#### 2.1.5. Mobile Menu (Offcanvas)
- [ ] Cập nhật offcanvas styling theo Design System
- [ ] Cập nhật mobile menu typography
- [ ] Cập nhật mobile menu icon styling

**Tham khảo**: Design System - Layout Spacing, Typography, Buttons, Icons

**Kết quả mong đợi**: Cms.Master hoàn toàn tuân thủ Design System

---

### 2.2. Cập nhật Lms.Master (LMS Student Layout)

**File cần modifikasi**: `MasterPages/Lms.Master`

**Công việc**:

#### 2.2.1. Head Section
- [ ] Thêm Google Fonts link cho Be Vietnam Pro (như Cms.Master)
- [ ] Thêm Material Icons link (nếu cần)
- [ ] Đảm bảo import CSS files đúng thứ tự

#### 2.2.2. Learning Strip
- [ ] Cập nhật background color theo theme colors
- [ ] Cập nhật typography theo Design System
- [ ] Cập nhật icon styling

#### 2.2.3. Navbar
- [ ] Cập nhật brand logo styling
- [ ] Cập nhật navbar background: `--header` (#ffffff)
- [ ] Cập nhật nav link typography: `--font-size-ui`, `--font-weight-medium`
- [ ] Cập nhật nav link hover/active states
- [ ] Cập heights và spacing theo spacing scale

#### 2.2.4. User Actions (Right side)
- [ ] Cập nhật notification button styling
- [ ] Cập nhật avatar styling theo Design System
- [ ] Cập nhật profile link typography
- [ ] Cập nhật logout button: `btn-action-delete`

#### 2.2.5. Main Content Area
- [ ] Cập nhật page background: `--page` (#f3f5f7)
- [ ] Cập nhật content padding theo spacing scale
- [ ] Cập nhật typography trong content area

#### 2.2.6. Footer
- [ ] Cập nhật footer background: `--theme-navy` (#102f4d)
- [ ] Cập nhật footer typography
- [ ] Cập nhật footer spacing

**Tham khảo**: Design System - Layout Spacing, Typography, Buttons, Icons

**Kết quả mong đợi**: Lms.Master hoàn toàn tuân thủ Design System

---

## CỤM 3: CẬP NHẬT CSS COMPONENTS

### 3.1. Component: Action Buttons

**File cần modifikasi**: `assets/lms/css/components/action-buttons.css`

**Công việc**:
- [ ] Cập nhật `btn-primary` theo Design System (brand-green)
- [ ] Cập nhật `btn-secondary` theo Design System (brand-blue)
- [ ] Cập nhật `btn-success` theo Design System (brand-success)
- [ ] Cập nhật `btn-danger` theo Design System (brand-red)
- [ ] Cập nhật tất cả action buttons CMS:
  - `btn-action-create` (brand-green)
  - `btn-action-view` (brand-blue)
  - `btn-action-edit` (brand-secondary)
  - `btn-action-delete` (brand-red)
  - `btn-action-save` (brand-success)
  - `btn-action-cancel` (neutral)
  - `btn-action-refresh` (brand-blue)
  - `btn-action-filter` (brand-blue)
  - `btn-action-upload` (brand-secondary)
  - `btn-action-export` (brand-success)
  - `btn-action-copy` (brand-yellow)
- [ ] Cập nhật button sizes (btn-sm, btn-lg)
- [ ] Cập nhật button states (hover, focus, disabled)
- [ ] Cập nhật button typography: `--font-size-ui`, `--font-weight-semibold`
- [ ] Cập nhật button padding theo spacing scale
- [ ] Cập nhật button border-radius: `--control-radius` (5px)

**Tham khảo**: Design System - Buttons section (dòng 2134-2475)

**Kết quả mong đợi**: Tất cả buttons tuân thủ Design System

---

### 3.2. Component: Forms

**File cần modifikasi**: `assets/lms/css/components/forms.css`

**Công việc**:
- [ ] Cập nhật `form-label` typography: `--font-size-ui`, `--font-weight-semibold`
- [ ] Cập nhật `form-control` styling:
  - Border color: `--neutral-line-strong`
  - Border-radius: `--control-radius`
  - Font size: `--font-size-ui`
  - Placeholder color: `--text-disabled`
- [ ] Cập nhật `form-select` styling như form-control
- [ ] Cập nhật `form-control` hover state
- [ ] Cập nhật `form-control` focus state với border-color và box-shadow
- [ ] Cập nhật `form-check-input` styling
- [ ] Cập nhật `input-group-text` styling
- [ ] Cập nhật form states (valid, invalid, disabled, readonly)
- [ ] Cập nhật form spacing theo spacing scale

**Tham khảo**: Design System - Forms section (dòng 2739-2849)

**Kết quả mong đợi**: Tất cả form elements tuân thủ Design System

---

### 3.3. Component: Surfaces (Cards)

**File cần modifikasi**: `assets/lms/css/components/surfaces.css`

**Công việc**:
- [ ] Cập nhật `app-card` styling:
  - Background: `--surface` (#ffffff)
  - Border-radius: `--card-radius` (5px)
  - Box-shadow theo Design System
  - Hover state với shadow-md
- [ ] Cập nhật `card-header` styling:
  - Padding theo spacing scale
  - Typography theo Design System
- [ ] Cập nhật `card-title` typography: `--font-size-base`, `--font-weight-semibold`
- [ ] Cập nhật `card-body` padding theo spacing scale
- [ ] Cập nhật `card-footer` styling
- [ ] Cập nhật `stat` card styling (dashboard stats)
- [ ] Cập nhật `course` card styling (LMS course cards)

**Tham khảo**: Design System - Cards section (dòng 2476-2688)

**Kết quả mong đợi**: Tất cả cards tuân thủ Design System

---

### 3.4. Component: Data Display (Tables, Badges, Progress)

**File cần modifikasi**: `assets/lms/css/components/data-display.css`

**Công việc**:

#### 3.4.1. Tables
- [ ] Cập nhật `table` styling:
  - Header background: `--eduvers-base` (hoặc brand-green)
  - Header typography: `--font-size-sm`, `--font-weight-semibold`
  - Header text color: #fff
  - Cell padding theo spacing scale
  - Border color: `--neutral-line`
  - Row hover background: soft-green
- [ ] Cập nhật table border-radius trên header
- [ ] Cập nhật table responsive styling

#### 3.4.2. Badges
- [ ] Cập nhật `badge` base styling:
  - Border-radius: 4px
  - Padding theo spacing scale
  - Font size: `--font-size-xs`
  - Font weight: `--font-weight-semibold`
- [ ] Cập nhật `badge-success`, `badge-warning`, `badge-danger`, `badge-info`
- [ ] Cập nhật `badge-soft-success`, `badge-soft-primary`, `badge-soft-warning`, `badge-soft-danger`

#### 3.4.3. Progress Bars
- [ ] Cập nhật `progress` background: #e8edeb
- [ ] Cập nhật `progress-bar` background: `--brand-green`
- [ ] Cập nhật border-radius: 3px

#### 3.4.4. Avatars
- [ ] Cập nhật `avatar` styling:
  - Border-radius: 50%
  - Background: `--soft-green`
  - Color: `--brand-green`
  - Font weight: `--font-weight-bold`
- [ ] Cập nhật avatar sizes (sm, lg)

**Tham khảo**: Design System - Tables (dòng 2851-2957), Badges (dòng 2690-2737), Progress (dòng 2958-2986), Avatars (dòng 2988-3022)

**Kết quả mong đợi**: Data display components tuân thủ Design System

---

### 3.5. Component: Typography

**File cần modifikasi**: `assets/lms/css/components/typography.css`

**Công việc**:
- [ ] Đảm bảo typography hierarchy đã được áp dụng trong base.css
- [ ] Cập nhật page-title: `--font-size-2xl`, `--font-weight-bold`
- [ ] Cập nhật page-subtitle: `--font-size-ui`, `--font-weight-normal`, `--text-secondary`
- [ ] Cập nhật section-title: `--font-size-lg`, `--font-weight-semibold`
- [ ] Cập nhật card-title: `--font-size-base`, `--font-weight-semibold`
- [ ] Cập nhật eyebrow: `--font-size-xs`, `--font-weight-semibold`
- [ ] Cập nhật body text: `--font-size-base`, `--font-weight-normal`
- [ ] Cập nhật tiny text: `--font-size-xs`, `--text-muted`
- [ ] Cập nhật line-height theo Design System

**Tham khảo**: Design System - Typography section (dòng 274-810)

**Kết quả mong đợi**: Typography hoàn toàn tuân thủ Design System

---

### 3.6. Component: Page Header

**File cần modifikasi**: `assets/lms/css/components/page-header.css`

**Công việc**:
- [ ] Cập nhật page header styling
- [ ] Cập nhật page title typography
- [ ] Cập nhật page subtitle/description
- [ ] Cập nhật page actions (buttons)
- [ ] Cập nhật breadcrumb styling
- [ ] Cập nhật spacing theo spacing scale

**Kết quả mong đợi**: Page header tuân thủ Design System

---

### 3.7. Component: Filter Bar

**File cần modifikasi**: `assets/lms/css/components/filter-bar.css`

**Công việc**:
- [ ] Cập nhật filter bar container styling
- [ ] Cập nhật search input styling
- [ ] Cập nhật filter dropdown/select styling
- [ ] Cập nhật filter buttons styling
- [ ] Cập nhật spacing giữa các elements
- [ ] Cập nhật responsive behavior

**Kết quả mong đợi**: Filter bar tuân thủ Design System

---

### 3.8. Component: Pagination

**File cần modifikasi**: `assets/lms/css/components/pagination.css`

**Công việc**:
- [ ] Cập nhật pagination container styling
- [ ] Cập nhật pagination button styling
- [ ] Cập nhật active state styling
- [ ] Cập nhật disabled state styling
- [ ] Cập nhật spacing

**Kết quả mong đợi**: Pagination tuân thủ Design System

---

### 3.9. Component: Feedback States

**File cần modifikasi**: `assets/lms/css/components/feedback-states.css`

**Công việc**:
- [ ] Cập nhật alert styling (success, danger, warning, info)
- [ ] Cập nhật empty state styling
- [ ] Cập nhật loading state (spinner)
- [ ] Cập nhật icon styling trong alerts
- [ ] Cập nhật typography theo Design System

**Tham khảo**: Design System - Alerts (dòng 3024-3056), Loading States (dòng 3058-3074), Empty States (dòng 3076-3132)

**Kết quả mong đợi**: Feedback states tuân thủ Design System

---

### 3.10. Component: Notification Center

**File cần modifikasi**: `assets/lms/css/components/notification-center.css`

**Công việc**:
- [ ] Cập nhật notification button styling
- [ ] Cập nhật notification badge/count styling
- [ ] Cập nhật notification panel styling
- [ ] Cập nhật notification item styling
- [ ] Cập nhật typography và spacing

**Kết quả mong đợi**: Notification center tuân thủ Design System

---

### 3.11. Component: CMS Page Actions

**File cần modifikasi**: `assets/lms/css/components/cms-page-actions.css`

**Công việc**:
- [ ] Cập nhật page actions container
- [ ] Cập nhật action buttons styling
- [ ] Cập nhật button spacing
- [ ] Cập nhật responsive behavior

**Kết quả mong đợi**: CMS page actions tuân thủ Design System

---

### 3.12. Component: Confirm Dialog

**File cần modifikasi**: `assets/lms/css/components/confirm-dialog.css`

**Công việc**:
- [ ] Cập nhật modal styling theo Design System
- [ ] Cập nhật modal header typography
- [ ] Cập nhật modal body typography và spacing
- [ ] Cập nhật modal footer buttons
- [ ] Cập nhật modal border-radius: `--radius-md` (12px)
- [ ] Cập nhật modal z-index: `--z-index-modal` (1400)

**Tham khảo**: Design System - Z-Index section (dòng 1937-2130)

**Kết quả mong đợi**: Confirm dialog tuân thủ Design System

---

### 3.13. Component: Overlays

**File cần modifikasi**: `assets/lms/css/components/overlays.css`

**Công việc**:
- [ ] Cập nhật overlay/backdrop styling
- [ ] Cập nhật modal backdrop z-index: `--z-index-modal-backdrop` (1300)
- [ ] Cập nhật overlay colors và transitions

**Kết quả mong đợi**: Overlays tuân thủ Design System

---

### 3.14. Component: Controls

**File cần modifikasi**: `assets/lms/css/components/controls.css`

**Công việc**:
- [ ] Cập nhật all custom controls styling
- [ ] Cập nhật toggle switches
- [ ] Cập nhật custom checkboxes/radios
- [ ] Cập nhật custom dropdowns
- [ ] Cập nhật tất cả theo Design System

**Kết quả mong đợi**: Custom controls tuân thủ Design System

---

### 3.15. Component: YouTube Video Player

**File cần modifikasi**: `assets/lms/css/components/youtube-video-player.css`

**Công việc**:
- [ ] Cập nhật video player container styling
- [ ] Cập nhật video player controls styling
- [ ] Cập nhật spacing và border-radius

**Kết quả mong đợi**: Video player tuân thủ Design System

---

## CỤM 4: CẬP NHẬT CSS PAGES - CMS

### 4.1. Page: CMS Dashboard

**File cần modifikasi**: `assets/lms/css/pages/cms/dashboard.css`

**Công việc**:
- [ ] Cập nhật stat cards styling
- [ ] Cập nhật chart containers styling
- [ ] Cập nhật typography trong dashboard
- [ ] Cập nhật spacing giữa các sections
- [ ] Cập nhật responsive grid

**Tham khảo**: Design System - Stat Cards (dòng 2550-2622)

**Kết quả mong đợi**: CMS Dashboard tuân thủ Design System

---

### 4.2. Page: CMS Generic

**File cần modifikasi**: `assets/lms/css/pages/cms/generic.css`

**Công việc**:
- [ ] Cập nhật generic page layout
- [ ] Cập nhật page content spacing
- [ ] Cập nhật typography
- [ ] Cập nhật cards và containers

**Kết quả mong đợi**: Generic CMS pages tuân thủ Design System

---

### 4.3. Page: CMS Students

**File cần modifikasi**: `assets/lms/css/pages/cms/students.css`

**Công việc**:
- [ ] Cập nhật student list styling
- [ ] Cập nhật student cards styling
- [ ] Cập nhật filter và search styling
- [ ] Cập nhật table styling cho student list
- [ ] Cập nhật action buttons styling

**Kết quả mong đợi**: Students page tuân thủ Design System

---

### 4.4. Page: CMS Course Management

**File cần modifikasi**: `assets/lms/css/pages/cms/course-management.css`

**Công việc**:
- [ ] Cập nhật course list styling
- [ ] Cập nhật course cards styling
- [ ] Cập nhật course detail styling
- [ ] Cập nhật curriculum/lesson list styling
- [ ] Cập nhật filter và search styling

**Tham khảo**: Design System - Course Cards (dòng 2624-2688)

**Kết quả mong đợi**: Course management pages tuân thủ Design System

---

### 4.5. Page: CMS Academic Structure

**File cần modifikasi**: `assets/lms/css/pages/cms/academic-structure.css`

**Công việc**:
- [ ] Cập nhật academic tree/structure styling
- [ ] Cập nhật node styling
- [ ] Cập nhật connectors styling
- [ ] Cập nhật typography
- [ ] Cập nhật spacing

**Kết quả mong đợi**: Academic structure page tuân thủ Design System

---

### 4.6. Page: CMS Academic Timetable

**File cần modifikasi**: `assets/lms/css/pages/cms/academic-timetable.css`

**Công việc**:
- [ ] Cập nhật timetable grid styling
- [ ] Cập nhật timetable cell styling
- [ ] Cập nhật typography
- [ ] Cập nhật colors cho different time slots

**Kết quả mong đợi**: Academic timetable page tuân thủ Design System

---

### 4.7. Page: CMS Academic Dialogs

**File cần modifikasi**: `assets/lms/css/pages/cms/academic-dialogs.css`

**Công việc**:
- [ ] Cập nhật dialog/modal styling
- [ ] Cập nhật form styling trong dialogs
- [ ] Cập nhật buttons styling
- [ ] Cập nhật typography

**Kết quả mong đợi**: Academic dialogs tuân thủ Design System

---

### 4.8. Page: CMS Reports

**File cần modifikasi**: `assets/lms/css/pages/cms/reports.css`

**Công việc**:
- [ ] Cập nhật report containers styling
- [ ] Cập nhật chart containers styling
- [ ] Cập nhật data tables styling
- [ ] Cập nhật filters styling
- [ ] Cập nhật typography

**Kết quả mong đợi**: Reports page tuân thủ Design System

---

### 4.9. Page: CMS Global Search

**File cần modifikasi**: `assets/lms/css/pages/cms/global-search.css`

**Công việc**:
- [ ] Cập nhật search input styling
- [ ] Cập nhật search results styling
- [ ] Cập nhật result item styling
- [ ] Cập nhật typography
- [ ] Cập nhật spacing

**Kết quả mong đợi**: Global search page tuân thủ Design System

---

### 4.10. Page: CMS System Management

**File cần modifikasi**: `assets/lms/css/pages/cms/system-management.css`

**Công việc**:
- [ ] Cập nhật system settings forms styling
- [ ] Cập nhật configuration tables styling
- [ ] Cập nhật action buttons styling
- [ ] Cập nhật typography

**Kết quả mong đợi**: System management page tuân thủ Design System

---

### 4.11. Page: CMS Video Editor

**File cần modifikasi**: `assets/lms/css/pages/cms/video-editor.css`

**Công việc**:
- [ ] Cập nhật video editor layout
- [ ] Cập nhật video player styling
- [ ] Cập nhật controls styling
- [ ] Cập nhật timeline styling
- [ ] Cập nhật action buttons styling

**Kết quả mong đợi**: Video editor page tuân thủ Design System

---

## CỤM 5: CẬP NHẬT CSS PAGES - LMS

### 5.1. Page: LMS Dashboard

**File cần modifikasi**: `assets/lms/css/pages/lms/dashboard.css`

**Công việc**:
- [ ] Cập nhật course cards styling
- [ ] Cập nhật progress bars styling
- [ ] Cập nhật stat cards styling
- [ ] Cập nhật typography
- [ ] Cập nhật spacing

**Tham khảo**: Design System - Course Cards (dòng 2624-2688)

**Kết quả mong đợi**: LMS Dashboard tuân thủ Design System

---

### 5.2. Page: LMS Simple

**File cần modifikasi**: `assets/lms/css/pages/lms/simple.css`

**Công việc**:
- [ ] Cập nhật simple page layout
- [ ] Cập nhật content styling
- [ ] Cập nhật typography
- [ ] Cập nhật spacing

**Kết quả mong đợi**: Simple LMS pages tuân thủ Design System

---

### 5.3. Page: LMS Results

**File cần modifikasi**: `assets/lms/css/pages/lms/results.css`

**Công việc**:
- [ ] Cập nhật results cards styling
- [ ] Cập nhật score displays styling
- [ ] Cập nhật charts styling
- [ ] Cập nhật tables styling
- [ ] Cập nhật typography

**Kết quả mong đợi**: Results page tuân thủ Design System

---

## CỤM 6: CẬP NHẬT CSS PAGES - ERRORS

### 6.1. Page: Error Pages

**File cần modifikasi**: `assets/lms/css/pages/errors/error.css`

**Công việc**:
- [ ] Cập nhật error page layout
- [ ] Cập nhật error message typography
- [ ] Cập nhật error icon styling
- [ ] Cập nhật action buttons styling
- [ ] Cập nhật spacing

**Kết quả mong đợi**: Error pages tuân thủ Design System

---

## CỤM 7: CẬP NHẬT CSS CORE

### 7.1. Core: Utilities

**File cần modifikasi**: `assets/lms/css/core/utilities.css`

**Công việc**:
- [ ] Đảm bảo utility classes sử dụng CSS variables
- [ ] Cập nhật spacing utilities (m, p, gap classes)
- [ ] Cập nhật text utilities
- [ ] Cập nhật color utilities
- [ ] Cập nhật display utilities
- [ ] Cập nhật flexbox utilities

**Kết quả mong đợi**: Utility classes tuân thủ Design System

---

### 7.2. Core: Responsive

**File cần modifikasi**: `assets/lms/css/core/responsive.css`

**Công việc**:
- [ ] Cập nhật responsive breakpoints theo Design System
- [ ] Cập nhật responsive typography (mobile font sizes)
- [ ] Cập nhật responsive sidebar behavior
- [ ] Cập nhật responsive tables
- [ ] Cập nhật responsive grid

**Tham khảo**: Design System - Responsive Design section (dòng 3160-3199)

**Kết quả mong đợi**: Responsive styles tuân thủ Design System

---

## CỤM 8: CẬP NHẬT CONTROLS & USER CONTROLS

### 8.1. Controls: CMS Dashboard

**File cần modifikasi**: `Controls/Cms/Dashboard.ascx`

**Công việc**:
- [ ] Cập nhật HTML structure theo Design System
- [ ] Cập nhật class names tuân thủ Design System
- [ ] Cập nhật typography classes
- [ ] Cập nhật button classes
- [ ] Cập nhật card classes

**Kết quả mong đợi**: Dashboard control tuân thủ Design System

---

### 8.2. Controls: LMS Dashboard

**File cần modifikasi**: `Controls/Lms/Dashboard.ascx`

**Công việc**:
- [ ] Cập nhật HTML structure theo Design System
- [ ] Cập nhật class names tuân thủ Design System
- [ ] Cập nhật typography classes
- [ ] Cập nhật button classes
- [ ] Cập nhật card classes

**Kết quả mong đợi**: LMS Dashboard control tuân thủ Design System

---

### 8.3. Các Controls khác

**Công việc**:
- [ ] Review và cập nhật tất cả controls trong thư mục `Controls/`
- [ ] Đảm bảo tất cả sử dụng đúng class names từ Design System
- [ ] Cập nhật typography, buttons, forms, cards styling

**Kết quả mong đợi**: Tất cả controls tuân thủ Design System

---

## CỤM 9: CẬP NHẬT ASPX PAGES

### 9.1. CMS Pages

**Danh sách trang CMS cần kiểm tra**:
- `Pages/Cms/Dashboard.aspx`
- `Pages/Cms/AcademicStructure.aspx`
- `Pages/Cms/AssignmentGrading.aspx`
- `Pages/Cms/ContentBuilder.aspx`
- `Pages/Cms/Courses.aspx`
- `Pages/Cms/Enrollments.aspx`
- `Pages/Cms/Questions.aspx`
- `Pages/Cms/Reports.aspx`
- `Pages/Cms/Roles.aspx`
- `Pages/Cms/Search.aspx`
- `Pages/Cms/Students.aspx`
- `Pages/Cms/Users.aspx`
- `Pages/Cms/VideoEditor.aspx`
- `Pages/Cms/VideoLibrary.aspx`
- `Pages/Cms/CourseCategories.aspx`
- `Pages/Cms/CourseLibrary.aspx`
- `Pages/Cms/CourseEnrollments.aspx`
- `Pages/Cms/CourseProgress.aspx`
- `Pages/Cms/QuizManagement.aspx`
- `Pages/Cms/Settings.aspx`
- `Pages/Cms/Help.aspx`
- `Pages/Cms/InteractiveContentTest.aspx`

**Công việc cho mỗi trang**:
- [ ] Kiểm tra và cập nhật inline styles (nếu có)
- [ ] Đảm bảo sử dụng đúng class names
- [ ] Kiểm tra typography trong page content
- [ ] Kiểm tra button classes
- [ ] Kiểm tra form classes

**Kết quả mong đợi**: Tất cả CMS pages tuân thủ Design System

---

### 9.2. LMS Pages

**Danh sách trang LMS cần kiểm tra**:
- `Pages/Lms/Dashboard.aspx`
- `Pages/Lms/Courses.aspx`
- `Pages/Lms/Course.aspx`
- `Pages/Lms/LessonPlayer.aspx`
- `Pages/Lms/Profile.aspx`
- `Pages/Lms/Results.aspx`

**Công việc cho mỗi trang**:
- [ ] Kiểm tra và cập nhật inline styles (nếu có)
- [ ] Đảm bảo sử dụng đúng class names
- [ ] Kiểm tra typography trong page content
- [ ] Kiểm tra button classes
- [ ] Kiểm tra form classes

**Kết quả mong đợi**: Tất cả LMS pages tuân thủ Design System

---

### 9.3. Error Pages

**Danh sách trang Error cần kiểm tra**:
- `Pages/Errors/Error.aspx`
- `Pages/Errors/Forbidden.aspx`
- `Pages/Errors/NotFound.aspx`

**Công việc cho mỗi trang**:
- [ ] Kiểm tra và cập nhật inline styles
- [ ] Đảm bảo sử dụng đúng class names
- [ ] Kiểm tra typography
- [ ] Kiểm tra button classes

**Kết quả mong đợi**: Error pages tuân thủ Design System

---

### 9.4. Auth Pages

**Danh sách trang Auth cần kiểm tra**:
- `Pages/Auth/Login.aspx`
- `Pages/Auth/Logout.aspx`

**Công việc cho mỗi trang**:
- [ ] Kiểm tra và cập nhật inline styles
- [ ] Đảm bảo sử dụng đúng class names
- [ ] Kiểm tra typography
- [ ] Kiểm tra form classes
- [ ] Kiểm tra button classes

**Kết quả mong đợi**: Auth pages tuân thủ Design System

---

## CỤM 10: XÓA/CẬP NHẬT CSS CŨ

### 10.1. Eduvers CSS

**File cần kiểm tra**: `assets/lms/eduvers/css/style.css`

**Công việc**:
- [ ] Review và loại bỏ các styles conflicts với Design System
- [ ] Giữ lại chỉ các styles đặc thù của Eduvers không có trong Design System
- [ ] Đảm bảo không overwriting Design System styles

**Kết quả mong đợi**: Eduvers CSS không conflict với Design System

---

### 10.2. Eduvers Responsive CSS

**File cần kiểm tra**: `assets/lms/eduvers/css/responsive.css`

**Công việc**:
- [ ] Review và cập nhật responsive styles
- [ ] Đảm bảo tuân thủ Design System breakpoints
- [ ] Loại bỏ conflicts

**Kết quả mong đợi**: Eduvers responsive CSS tuân thủ Design System

---

### 10.3. Webforms CSS

**File cần kiểm tra**: `assets/lms/css/webforms.css`

**Công việc**:
- [ ] Review và cập nhật styles
- [ ] Đảm bảo tuân thủ Design System
- [ ] Loại bỏ conflicts

**Kết quả mong đợi**: Webforms CSS tuân thủ Design System

---

## CỤM 11: TESTING & VALIDATION

### 11.1. Visual Testing

**Công việc**:
- [ ] Test tất cả CMS pages trong browser
- [ ] Test tất cả LMS pages trong browser
- [ ] Test responsive behavior trên mobile/tablet/desktop
- [ ] Test hover states
- [ ] Test focus states
- [ ] Test disabled states
- [ ] Test modal/dialog behavior
- [ ] Test notification center
- [ ] Test dropdowns

**Kết quả mong đợi**: Tất cả pages hiển thị đúng theo Design System

---

### 11.2. Accessibility Testing

**Công việc**:
- [ ] Test color contrast ratios
- [ ] Test keyboard navigation
- [ ] Test screen reader compatibility
- [ ] Test ARIA labels
- [ ] Test focus indicators

**Tham khảo**: Design System - Accessibility section (dòng 3201-3237)

**Kết quả mong đợi**: Accessibility tuân thủ WCAG AA

---

### 11.3. Cross-browser Testing

**Công việc**:
- [ ] Test trên Chrome
- [ ] Test trên Firefox
- [ ] Test trên Edge
- [ ] Test trên Safari (nếu có)

**Kết quả mong đợi**: Consistent across browsers

---

## CỤM 12: DOCUMENTATION

### 12.1. Update Design System Reference

**Công việc**:
- [ ] Cập nhật file này với các changes đã thực hiện
- [ ] Document các custom styles đã thêm (nếu có)
- [ ] Document các exceptions hoặc deviations (nếu có)

**Kết quả mong đợi**: Documentation đầy đủ

---

### 12.2. Create Migration Guide

**Công việc**:
- [ ] Tạo guide cho developers về cách sử dụng Design System
- [ ] Document các CSS variables mới
- [ ] Document các class names mới
- [ ] Document best practices

**Kết quả mong đợi**: Migration guide cho team

---

## THỨ TỰ THỰC HIỆN ĐỀ XUẤT

### Phase 1: Foundation (Cụm 1-2)
1. Tạo CSS Variables file
2. Cập nhật Base CSS
3. Cập nhật Index CSS
4. Cập nhật Cms.Master
5. Cập nhật Lms.Master

### Phase 2: Components (Cụm 3)
6. Cập nhật tất cả component CSS files
7. Test components standalone

### Phase 3: Pages - CMS (Cụm 4)
8. Cập nhật tất cả CMS page CSS files
9. Test CMS pages

### Phase 4: Pages - LMS & Errors (Cụm 5-6)
10. Cập nhật LMS page CSS files
11. Cập nhật Error page CSS files
12. Test LMS và Error pages

### Phase 5: Core & Controls (Cụm 7-8)
13. Cập nhật Core CSS files
14. Cập nhật Controls
15. Test controls

### Phase 6: ASPX Pages (Cụm 9)
16. Kiểm tra và cập nhật tất cả ASPX pages
17. Test tất cả pages

### Phase 7: Cleanup (Cụm 10)
18. Xóa/cập nhật CSS cũ
19. Loại bỏ conflicts

### Phase 8: Testing & Documentation (Cụm 11-12)
20. Visual testing
21. Accessibility testing
22. Cross-browser testing
23. Documentation

---

## CHECKLIST HOÀN THÀNH

- [ ] Cụm 1: Thiết lập CSS Variables & Base Styles
- [ ] Cụm 2: Cập nhật Master Pages
- [ ] Cụm 3: Cập nhật CSS Components
- [ ] Cụm 4: Cập nhật CSS Pages - CMS
- [ ] Cụm 5: Cập nhật CSS Pages - LMS
- [ ] Cụm 6: Cập nhật CSS Pages - Errors
- [ ] Cụm 7: Cập nhật CSS Core
- [ ] Cụm 8: Cập nhật Controls & User Controls
- [ ] Cụm 9: Cập nhật ASPX Pages
- [ ] Cụm 10: Xóa/Cập nhật CSS cũ
- [ ] Cụm 11: Testing & Validation
- [ ] Cụm 12: Documentation

---

## NOTES

1. **Backup**: Trước khi bắt đầu, backup toàn bộ thư mục `assets/lms/css/`
2. **Git**: Commit sau khi hoàn thành mỗi cụm
3. **Testing**: Test sau mỗi phase trước khi tiếp tục
4. **Communication**: Coordinate với team về changes
5. **Rollback**: Giữ capability để rollback nếu cần

---

## LIÊN KẾT THAM KHẢO

- Design System: `G:\0.DỰ ÁN\2.LMS-VS2010\WEB-LMS-VS2010\5.Template-deign\DESIGN_SYSTEM.md`
- Project: `G:\0.DỰ ÁN\2.LMS-VS2010\WEB-LMS-VS2010\1. WEB-LMS-VS2010\InformationWeb`
- Plan: `G:\0.DỰ ÁN\2.LMS-VS2010\WEB-LMS-VS2010\7.Plan-Modifly-project\KE-HOACH-SUA-GIAO-DIEN-INFO-WEB.md`

---

**Ngày tạo**: 2026-10-22
**Phiên bản**: 1.0
**Trạng thái**: Ready to execute
