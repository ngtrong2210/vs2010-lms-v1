# KẾ HOẠCH SỬA ĐỔI CẤU TRÚC DANH MỤC CHƯƠNG/BÀI HỌC
## (Flexible Chapter/Lesson Structure)

---

## 1. MỤC TIÊU (OBJECTIVES)

### 1.1. Vấn đề hiện tại
- Cấu trúc hiện tại: **Chương → Bài học** (2 cấp)
- Hạn chế: Không đủ linh hoạt cho các loại nội dung khác nhau
- Không hỗ trợ: Bài kiểm tra, bài học tương tác, tài liệu bổ sung nằm riêng biệt

### 1.2. Mục tiêu mới
- Cấu trúc linh hoạt: **Chương → Bài học 1 → Bài học 2...n-1 → Danh sách các bài kiểm tra, bài học tương tác...**
- Hỗ trợ nhiều loại nội dung trong cùng một chapter
- Tăng tính linh hoạt cho giáo viên khi xây dựng nội dung

---

## 2. PHƯƠNG ÁN THIẾT KẾ (DESIGN APPROACHES)

### 2.1. Phương án A: Thêm bảng `LessonContent` (Content Items trong Lesson)
```
Chương (SIM_Chapters)
  └── Bài học (SIM_Lessons)
        └── Nội dung bài học (SIM_LessonContent)
              ├── Video
              ├── Tài liệu
              ├── Quiz
              ├── Bài tập tương tác
              └── Tài liệu bổ sung
```

**Ưu điểm:**
- Không làm thay đổi cấu trúc hiện tại nhiều
- Lesson vẫn là đơn vị chính
- Dễ quản lý sort order

**Nhược điểm:**
- Tăng 1 tầng hierarchy
- Cần migrate dữ liệu hiện tại

---

### 2.2. Phương án B: Unified Content Table (Khuyến nghị)
```
Chương (SIM_Chapters)
  └── Nội dung (SIM_ContentItems) - unified table
        ├── Type: LESSON
        ├── Type: QUIZ
        ├── Type: INTERACTIVE
        ├── Type: DOCUMENT
        └── Type: VIDEO
```

**Ưu điểm:**
- Linh hoạt nhất
- Dễ thêm loại nội dung mới
- Sort order đồng nhất
- Không cần bảng riêng cho Quiz, Interactive

**Nhược điểm:**
- Cần migrate dữ liệu lớn
- Cần sửa nhiều stored procedure

---

### 2.3. Phương án C: Hybrid Approach (Khuyến nghị - Tối ưu nhất)
```
Chương (SIM_Chapters)
  └── Bài học (SIM_Lessons) - giữ nguyên
        └── Nội dung (SIM_ContentItems) - đã có, mở rộng
              ├── Type: VIDEO
              ├── Type: DOCUMENT
              ├── Type: QUIZ
              └── Type: INTERACTIVE

Ngoài ra:
  └── Quiz độc lập (SIM_Quizzes) - có thể gán vào Chapter
  └── Interactive Content (SIM_InteractiveContent) - có thể gán vào Chapter
```

**Ưu điểm:**
- Giữ nguyên cấu trúc Lesson hiện tại
- Mở rộng ContentItems đã có
- Quiz/Interactive có thể gán trực tiếp vào Chapter
- Ít ảnh hưởng đến hệ thống hiện tại

**Nhược điểm:**
- Cần quản lý 2 nguồn nội dung (Lesson-ContentItems và Chapter-Quizzes)

---

## 3. CHỌN PHƯƠNG ÁN: PHƯƠNG ÁN C (HYBRID)

### 3.1. Lý do chọn
- Ít ảnh hưởng đến dữ liệu hiện tại
- Mở rộng dần dần
- Linh hoạt cho tương lai
- Giữ nguyên stored procedure hiện tại

---

## 4. THIẾT KẾ CƠ SỞ DỮ LIỆU (DATABASE DESIGN)

### 4.1. Bảng hiện tại (giữ nguyên)

#### SIM_Chapters
```sql
ChapterID (PK)
CourseID (FK)
Title
Description
SortOrder
Status
CreatedAt
UpdatedAt
IsDeleted
```

#### SIM_Lessons
```sql
LessonID (PK)
CourseID (FK)
ChapterID (FK)
Title
Description
LessonType (VIDEO, DOCUMENT, MIXED)
SortOrder
DurationMinutes
VideoID (FK)
Status
CreatedAt
UpdatedAt
IsDeleted
```

#### SIM_ContentItems (đã có, mở rộng)
```sql
ContentItemID (PK)
LessonID (FK)
ChapterID (FK) -- THÊM: cho phép gán trực tiếp vào Chapter
Title
Description
ContentType -- MỞ RỘNG: VIDEO, DOCUMENT, QUIZ, INTERACTIVE, ASSESSMENT
ContentUrl
VideoAssetID (FK)
SortOrder
Status
CreatedAt
UpdatedAt
IsDeleted
```

#### SIM_Quizzes (đã có, mở rộng)
```sql
QuizID (PK)
LessonID (FK) -- NULL
ChapterID (FK) -- THÊM: cho phép gán trực tiếp vào Chapter
CourseID (FK)
Title
Description
PassingScore
TimeLimitMinutes
MaxAttempts
RandomizeQuestions
ShowResultsImmediately
Status
CreatedAt
UpdatedAt
IsDeleted
```

### 4.2. Bảng mới (nếu cần)

#### SIM_InteractiveContent (THÊM MỚI)
```sql
InteractiveContentID (PK)
CourseID (FK)
ChapterID (FK)
LessonID (FK) -- NULL
Title
Description
InteractiveType (H5P, SCORM, CUSTOM, DRAG_DROP, FLASHCARD)
ContentUrl
ConfigJson (Max) -- lưu cấu hình tương tác
ThumbnailUrl
DurationMinutes
SortOrder
Status
CreatedAt
UpdatedAt
IsDeleted
```

#### SIM_ContentSequences (THÊM MỚI - Optional)
```sql
SequenceID (PK)
ChapterID (FK)
SequenceType (ALL_LESSONS_FIRST, THEN_QUIZ, MIXED, CUSTOM)
ConfigJson (Max) -- cấu hình thứ tự hiển thị
CreatedAt
UpdatedAt
```

---

## 5. SQL SCRIPTS (SQL THAY ĐỔI)

### 5.1. Add Columns to Existing Tables

```sql
-- Add ChapterID to SIM_ContentItems
ALTER TABLE dbo.SIM_ContentItems
ADD ChapterID BigInt NULL;

ALTER TABLE dbo.SIM_ContentItems
ADD CONSTRAINT FK_ContentItems_Chapters
FOREIGN KEY (ChapterID) REFERENCES dbo.SIM_Chapters(ChapterID);

-- Add ChapterID to SIM_Quizzes
ALTER TABLE dbo.SIM_Quizzes
ADD ChapterID BigInt NULL;

ALTER TABLE dbo.SIM_Quizzes
ADD CONSTRAINT FK_Quizzes_Chapters
FOREIGN KEY (ChapterID) REFERENCES dbo.SIM_Chapters(ChapterID);

-- Create SIM_InteractiveContent table
CREATE TABLE dbo.SIM_InteractiveContent
(
	InteractiveContentID BigInt IDENTITY(1,1) NOT NULL PRIMARY KEY,
	CourseID BigInt NOT NULL,
	ChapterID BigInt NULL,
	LessonID BigInt NULL,
	Title NVarChar(255) NOT NULL,
	Description NVarChar(Max) NULL,
	InteractiveType NVarChar(50) NOT NULL, -- H5P, SCORM, CUSTOM, DRAG_DROP, FLASHCARD
	ContentUrl NVarChar(500) NULL,
	ConfigJson NVarChar(Max) NULL,
	ThumbnailUrl NVarChar(500) NULL,
	DurationMinutes Int NULL,
	SortOrder Int DEFAULT 0,
	Status NVarChar(50) DEFAULT 'DRAFT',
	CreatedAt DateTime DEFAULT GetDate(),
	UpdatedAt DateTime DEFAULT GetDate(),
	IsDeleted Bit DEFAULT 0,

	CONSTRAINT FK_InteractiveContent_Courses FOREIGN KEY (CourseID) REFERENCES dbo.SIM_Courses(CourseID),
	CONSTRAINT FK_InteractiveContent_Chapters FOREIGN KEY (ChapterID) REFERENCES dbo.SIM_Chapters(ChapterID),
	CONSTRAINT FK_InteractiveContent_Lessons FOREIGN KEY (LessonID) REFERENCES dbo.SIM_Lessons(LessonID)
);

-- Create Indexes
CREATE INDEX IX_InteractiveContent_CourseID ON dbo.SIM_InteractiveContent(CourseID);
CREATE INDEX IX_InteractiveContent_ChapterID ON dbo.SIM_InteractiveContent(ChapterID);
CREATE INDEX IX_InteractiveContent_LessonID ON dbo.SIM_InteractiveContent(LessonID);
CREATE INDEX IX_InteractiveContent_Status ON dbo.SIM_InteractiveContent(Status);
```

### 5.2. Migration Script (dữ liệu hiện tại)

```sql
-- Không cần migrate dữ liệu hiện tại vì giữ nguyên cấu trúc
-- Chỉ cần thêm tính năng mới
```

---

## 6. STORED PROCEDURES (CẦN TẠO MỚI)

### 6.1. Interactive Content Procedures

```sql
-- LMS_InteractiveContent_Create
-- LMS_InteractiveContent_Update
-- LMS_InteractiveContent_Delete
-- LMS_InteractiveContent_GetById
-- LMS_InteractiveContent_GetByChapter
-- LMS_InteractiveContent_GetByCourse
```

### 6.2. Chapter Content Procedures (tổng hợp)

```sql
-- LMS_Chapter_GetAllContent (Lấy tất cả nội dung trong chapter: Lessons, Quizzes, Interactive)
-- LMS_Chapter_ReorderContent (Sắp xếp lại thứ tự nội dung trong chapter)
```

### 6.3. Content Items Procedures (cập nhật)

```sql
-- Cập nhật LMS_ContentItem_Create để hỗ trợ ChapterID
-- Cập nhật LMS_ContentItem_Update để hỗ trợ ChapterID
```

---

## 7. GIAO DIỆN WEB (WEB INTERFACE)

### 7.1. Trang quản lý Chapter (CMS)

**File:** `InformationWeb/CMS/CourseChapterManagement.aspx`

**UI Components:**
- Accordion/Tree view hiển thị cấu trúc Chapter
- Nút "Add Lesson" (giữ nguyên)
- Nút "Add Quiz" (mới)
- Nút "Add Interactive Content" (mới)
- Drag & drop để reorder
- Icon phân loại:
  - 📚 Lesson
  - 📝 Quiz
  - 🎮 Interactive
  - 📄 Document

**CSS Classes (sử dụng CSS hiện tại):**
- `.lms-accordion` (đã có)
- `.lms-tree-view` (đã có)
- `.lms-content-item` (mới)
- `.lms-content-item--lesson` (mới)
- `.lms-content-item--quiz` (mới)
- `.lms-content-item--interactive` (mới)
- `.lms-drag-handle` (mới)

### 7.2. Trang học tập (LMS)

**File:** `InformationWeb/LMS/LessonPlayer.aspx`

**UI Components:**
- Sidebar hiển thị cấu trúc Chapter
- Tab/Launcher chọn loại nội dung
- Progress bar tổng hợp (Lesson + Quiz + Interactive)

**CSS Classes:**
- `.lms-sidebar` (đã có)
- `.lms-content-launcher` (mới)
- `.lms-progress-bar` (đã có)

---

## 8. CSS KHUÔN MẪU (CSS TEMPLATES)

### 8.1. File CSS mới cần tạo

```css
/* InformationWeb/assets/lms/css/components/chapter-content.css */

.lms-chapter-content {
  /* Container cho tất cả nội dung trong chapter */
}

.lms-content-item {
  display: flex;
  align-items: center;
  padding: 12px 16px;
  border-bottom: 1px solid var(--border-color);
  transition: background-color 0.2s;
}

.lms-content-item:hover {
  background-color: var(--hover-bg);
}

.lms-content-item--lesson {
  border-left: 4px solid var(--primary-color);
}

.lms-content-item--quiz {
  border-left: 4px solid var(--quiz-color, #ff6b6b);
}

.lms-content-item--interactive {
  border-left: 4px solid var(--interactive-color, #4ecdc4);
}

.lms-content-item--document {
  border-left: 4px solid var(--document-color, #95e1d3);
}

.lms-content-item__icon {
  width: 24px;
  height: 24px;
  margin-right: 12px;
  display: flex;
  align-items: center;
  justify-content: center;
}

.lms-content-item__title {
  flex: 1;
  font-weight: 500;
}

.lms-content-item__meta {
  font-size: 0.875rem;
  color: var(--text-muted);
}

.lms-content-item__actions {
  display: flex;
  gap: 8px;
}

.lms-drag-handle {
  cursor: move;
  padding: 4px;
  opacity: 0.5;
}

.lms-drag-handle:hover {
  opacity: 1;
}
```

### 8.2. Tuân thủ CSS hiện tại

**Sử dụng CSS Variables từ `core/tokens.css`:**
- `--primary-color`
- `--border-color`
- `--hover-bg`
- `--text-muted`

**Sử dụng Components từ `components/`:**
- `.lms-accordion`
- `.lms-button`
- `.lms-icon`

---

## 9. ASP.NET WEBFORMS PAGES

### 9.1. Pages cần tạo/sửa

#### CMS Pages:
1. `CMS/CourseChapterManagement.aspx` (sửa)
   - Thêm controls cho Quiz/Interactive
   - Thêm drag & drop functionality

2. `CMS/InteractiveContentEditor.aspx` (tạo mới)
   - Form thêm/sửa Interactive Content
   - Upload H5P/SCORM
   - Config JSON editor

3. `CMS/ChapterContentOrder.aspx` (tạo mới)
   - UI sắp xếp lại nội dung trong chapter

#### LMS Pages:
1. `LMS/LessonPlayer.aspx` (sửa)
   - Sidebar hiển thị tất cả loại nội dung
   - Tab launcher cho quiz/interactive

2. `LMS/InteractivePlayer.aspx` (tạo mới)
   - Player cho nội dung tương tác (H5P/SCORM)

---

## 10. SERVICE LAYER CHANGES (CẬP NHẬT)

### 10.1. File Service cần sửa

#### ✅ ContentService.cs (Quan trọng nhất)
**File:** `LmsService/ModuleServices.cs` - Class `ContentService`

**Thêm mapping cho stored procedures mới:**
```csharp
public sealed class ContentService : ModuleService
{
    public ContentService() : base(Map(
        // ... existing mappings ...
        "ChapterList", "dbo.LMS_Chapter_GetByCourse",
        "ChapterCreate", "dbo.LMS_Chapter_Create",
        "ChapterUpdate", "dbo.LMS_Chapter_Update",
        "ChapterDelete", "dbo.LMS_Chapter_Delete",
        "ChapterReorder", "dbo.LMS_Chapter_Reorder",

        // NEW: Interactive Content mappings
        "InteractiveContentCreate", "dbo.LMS_InteractiveContent_Create",
        "InteractiveContentUpdate", "dbo.LMS_InteractiveContent_Update",
        "InteractiveContentDelete", "dbo.LMS_InteractiveContent_Delete",
        "InteractiveContentGetById", "dbo.LMS_InteractiveContent_GetById",
        "InteractiveContentGetByChapter", "dbo.LMS_InteractiveContent_GetByChapter",
        "InteractiveContentGetByCourse", "dbo.LMS_InteractiveContent_GetByCourse",

        // NEW: Chapter content aggregation
        "ChapterGetAllContent", "dbo.LMS_Chapter_GetAllContent",
        "ChapterReorderContent", "dbo.LMS_Chapter_ReorderContent",

        // ... rest of existing mappings ...
    )) { }
}
```

#### ✅ QuizService.cs (Tùy chọn)
**File:** `LmsService/ModuleServices.cs` - Class `QuizService`

Nếu cần hỗ trợ Quiz gắn trực tiếp vào Chapter:
```csharp
public sealed class QuizService : ModuleService
{
    public QuizService() : base(Map(
        // ... existing mappings ...
        "QuizCreate", "dbo.LMS_Quiz_Create", // Cần update stored procedure để hỗ trợ ChapterID
        "QuizUpdate", "dbo.LMS_Quiz_Update", // Cần update stored procedure để hỗ trợ ChapterID
        // ... rest of existing mappings ...
    )) { }
}
```

#### ✅ LearningService.cs (Tùy chọn)
**File:** `LmsService/ModuleServices.cs` - Class `LearningService`

Thêm mapping để lấy nội dung chapter mới:
```csharp
public sealed class LearningService : ModuleService
{
    public LearningService() : base(Map(
        // ... existing mappings ...
        "ChapterContent", "dbo.LMS_Chapter_GetAllContent", // NEW
        // ... rest of existing mappings ...
    )) { }
}
```

#### ✅ ServiceRegistry.cs (Tùy chọn)
**File:** `LmsService/ServiceRegistry.cs`

Nếu tạo service mới riêng biệt cho Interactive Content:
```csharp
public static class ServiceRegistry
{
    // ... existing services ...
    public static ContentService Content { get { return new ContentService(); } }
    public static InteractiveContentService InteractiveContent { get { return new InteractiveContentService(); } } // NEW
    // ... rest of existing services ...
}
```

### 10.2. File Service KHÔNG cần sửa

- ❌ **ModuleService.cs** - Base class trừu tượng, chỉ framework
- ❌ **AuthService.cs** - Đăng nhập/permissions, không liên quan
- ❌ **LessonCommentService.cs** - Comments trên lesson
- ❌ **NotificationService.cs** - Thông báo hệ thống
- ❌ **QuestionService.cs** - Câu hỏi quiz
- ❌ **StudentService.cs** - Quản lý học viên
- ❌ **SystemAdministrationService.cs** - Admin
- ❌ **TeachingService.cs** - Chấm điểm bài tập

### 10.3. Business Logic Classes (Tạo mới)

```csharp
// Models/ChapterContentModel.cs
public class ChapterContentItem
{
    public long ContentID { get; set; }
    public string ContentType { get; set; } // LESSON, QUIZ, INTERACTIVE, DOCUMENT
    public string Title { get; set; }
    public int SortOrder { get; set; }
    public string IconClass { get; set; }
    public string ThumbnailUrl { get; set; }
    public string SubType { get; set; } // H5P, SCORM, DRAG_DROP, FLASHCARD
    public int? DurationMinutes { get; set; }
}

// Services/ChapterContentService.cs (Optional - wrapper class)
public class ChapterContentService
{
    private readonly ContentService _contentService;

    public ChapterContentService()
    {
        _contentService = new ContentService();
    }

    public List<ChapterContentItem> GetChapterContent(long chapterId)
    {
        var table = _contentService.GetDataTable("ChapterGetAllContent", "@ChapterID", chapterId);
        // Map DataTable to List<ChapterContentItem>
    }

    public void ReorderContent(long chapterId, List<long> contentIds)
    {
        // Gọi stored procedure LMS_Chapter_ReorderContent
    }
}
```

---

## 11. THỨ TỰ THỰC HIỆN (IMPLEMENTATION ORDER)

### Phase 1: Database (SQL)
1. ✅ Tạo stored procedures còn thiếu (đang làm)
2. ⬜ Thêm columns vào bảng hiện tại (ChapterID vào SIM_ContentItems, SIM_Quizzes)
3. ⬜ Tạo bảng SIM_InteractiveContent
4. ⬜ Tạo stored procedures cho Interactive Content (7 procedures)
5. ⬜ Tạo stored procedures LMS_Chapter_GetAllContent
6. ⬜ Tạo stored procedures LMS_Chapter_ReorderContent

### Phase 2: Service Layer (C#)
1. ⬜ Cập nhật ContentService.cs - thêm mapping cho 8 stored procedures mới
2. ⬜ (Tùy chọn) Cập nhật QuizService.cs - hỗ trợ ChapterID
3. ⬜ (Tùy chọn) Cập nhật LearningService.cs - thêm ChapterGetAllContent
4. ⬜ (Tùy chọn) Tạo InteractiveContentService.cs (nếu muốn service riêng)
5. ⬜ Cập nhật ServiceRegistry.cs (nếu tạo service mới)

### Phase 3: CSS
1. ⬜ Tạo `chapter-content.css` trong `assets/lms/css/components/`
2. ⬜ Review và tuân thủ CSS variables từ `core/tokens.css`
3. ⬜ Test responsive

### Phase 4: CMS Pages
1. ⬜ Sửa `CourseChapterManagement.aspx` - thêm controls Quiz/Interactive
2. ⬜ Tạo `InteractiveContentEditor.aspx` - form thêm/sửa Interactive Content
3. ⬜ Tạo `ChapterContentOrder.aspx` - UI sắp xếp lại nội dung
4. ⬜ Implement drag & drop (jQuery UI Sortable)

### Phase 5: LMS Pages
1. ⬜ Sửa `LessonPlayer.aspx` - sidebar hiển thị tất cả loại nội dung
2. ⬜ Tạo `InteractivePlayer.aspx` - player cho H5P/SCORM
3. ⬜ Implement progress tracking tổng hợp

### Phase 6: Testing
1. ⬜ Test database changes
2. ⬜ Test service layer (gọi stored procedures)
3. ⬜ Test CMS interface
4. ⬜ Test LMS interface
5. ⬜ Test drag & drop
6. ⬜ Test interactive content playback

---

## 12. RỦI RO VÀ GIẢI PHÁP (RISKS & MITIGATION)

### 12.1. Rủi ro
- Dữ liệu hiện tại bị ảnh hưởng
- CSS không đồng nhất
- Performance khi load nhiều nội dung
- Drag & drop không hoạt động trên mobile

### 12.2. Giải pháp
- Backup database trước khi alter tables
- Sử dụng CSS variables từ tokens.css
- Implement lazy loading/pagination
- Test trên multiple devices

---

## 13. LIÊN KẾT SQL (SQL CONNECTION)

```
Data Source=DESKTOP-PBMQQ03\SQLEXPRESS;
Initial Catalog=LMSCMS_DB;
User ID=sa;
Password=nQY3n9EGcjT#pju;
TrustServerCertificate=True;
```

**Lưu ý:** SQL sẽ được thực hiện trực tiếp trên SQL Local, không cần tạo file .sql

---

## 14. TÀI LIỆU THAM KHẢO (REFERENCES)

- CSS Framework: Bootstrap 5 (đã có)
- jQuery UI Sortable (cho drag & drop)
- H5P Integration (cho interactive content)
- SCORM Player (cho SCORM packages)

---

## 15. XÁC NHẬN (APPROVAL)

- [ ] Database Schema Approved
- [ ] CSS Design Approved
- [ ] UI Mockup Approved
- [ ] Implementation Plan Approved

---

**Ngày tạo:** 2025-01-16
**Người tạo:** AI Agent
**Trạng thái:** PENDING APPROVAL
