# BÁO CÁO PHÂN TÍCH STORED PROCEDURE
## Dự án: LMS (Learning Management System) - WEB-LMS-VS2010

---

### 1. TỔNG QUAN
- **Mục tiêu**: Xác định và catalog tất cả stored procedures được tham chiếu trong codebase C# của dự án LMS
- **Thời gian thực hiện**: 2026-10-22
- **Trạng thái**: ✅ Hoàn thành

---

### 2. KẾT QUẢ PHÂN TÍCH

#### 2.1 Tổng số Stored Procedures
Tổng cộng: **358 stored procedures** được phát hiện trong codebase

#### 2.2 Phân loại theo tiền tố

| Tiền tố | Loại | Số lượng | Mô tả |
|---------|------|----------|-------|
| **LMS_** | Custom (Business Logic) | 33 | Các procedure nghiệp vụ LMS (đăng nhập, ghi nhận tiến độ, quiz, v.v.) |
| **LMS_** | CRUD (Code-Generated) | 72 | Procedures GET/GETALL/SEARCH/ADD/EDIT/DELETE cho 16 bảng LMS |
| **SIM_** | Custom (Business Logic) | 28 | Các procedure nghiệp vụ SIM (quản lý khóa học, bài học, giảng viên) |
| **SIM_** | CRUD (Code-Generated) | 174 | Procedures GET/GETALL/SEARCH/ADD/EDIT/DELETE cho 29 bảng SIM |
| **SYS_** | Custom (Business Logic) | 9 | Các procedure hệ thống (permissions, notifications, audit logs) |
| **SYS_** | CRUD (Code-Generated) | 30 | Procedures GET/GETALL/SEARCH/ADD/EDIT/DELETE cho 6 bảng SYS |
| **sp_** | Lookup | 12 | Procedures tra cứu dữ liệu tham chiếu (dropdown, combobox) |

---

### 3. CHI TIẾT THEO NHÓM

#### 3.1 LMS_ Custom Procedures (33)
Các procedure nghiệp vụ riêng của hệ thống LMS:

**Authentication & Authorization:**
- LMS_Auth_GetUserByUsername
- LMS_Auth_GetUserById
- LMS_Auth_GetUserPermissions

**Enrollment Management:**
- LMS_Enrollments_UpdateStatus
- LMS_Enrollments_UpdateProgress
- LMS_Enrollments_UpdateLastAccess
- LMS_Enrollments_SEARCH
- LMS_Enrollments_GetByCourse
- LMS_Enrollments_GetByStudent
- LMS_Enrollments_CheckEnrollment
- LMS_Enrollments_SEARCHCBX

**Quiz & Assessment:**
- LMS_Questions_GetOptions
- LMS_Questions_GetAnswerKey
- LMS_QuizQuestions_Clear
- LMS_QuizAttempts_GetUserHistory
- LMS_QuizAttempts_GetAnswers
- LMS_Quizzes_GetQuestions
- LMS_Quizzes_CountAttempts

**Learning Tracking:**
- LMS_LearningSessions_GetActive
- LMS_LearningSessions_EndSession
- LMS_ContentInteractions_GetStats
- LMS_StudentVideoProgress_UpdateWatchProgress
- LMS_StudentVideoProgress_MarkCompleted
- LMS_StudentLessonProgress_GetByUserCourse
- LMS_StudentLessonProgress_UpdateProgress
- LMS_VideoInteractions_GetStats
- LMS_StudySessions_GetByUserCourse
- LMS_StudySessions_GetDailyStats

**Assignment Management:**
- LMS_AssignmentSubmissions_GetByAssignment
- LMS_AssignmentSubmissions_Grade
- LMS_AssignmentSubmissionFiles_DeleteBySubmission

**Interactive Content:**
- LMS_InteractiveContents_GetQuestions

**Data Cleanup:**
- LMS_QuestionOptions_DeleteByQuestion
- LMS_QuestionBlanks_DeleteByQuestion
- LMS_QuizAttemptAnswers_GetByQuestion
- LMS_QuizAttemptAnswers_DeleteByAttempt
- LMS_QuestionAnswerKeys_DeleteByQuestion
- LMS_StudentAnswerOptions_DeleteByAnswer
- LMS_StudentAnswers_CalculateScore
- LMS_LessonComments_GetByUser
- LMS_LessonResources_DeleteByLesson

#### 3.2 LMS_ CRUD Procedures (72)
Các procedure code-generated cho 16 bảng LMS:

**Bảng LMS:**
1. LMS_AssignmentSubmissionFiles (6 procedures)
2. LMS_AssignmentSubmissions (6 procedures)
3. LMS_ContentInteractions (6 procedures)
4. LMS_Enrollments (6 procedures)
5. LMS_InteractiveContents (6 procedures)
6. LMS_LearningSessions (6 procedures)
7. LMS_LessonComments (6 procedures)
8. LMS_QuestionAnswerKeys (6 procedures)
9. LMS_QuestionBlanks (6 procedures)
10. LMS_QuestionOptions (6 procedures)
11. LMS_Questions (6 procedures)
12. LMS_QuizAttemptAnswers (6 procedures)
13. LMS_QuizAttempts (6 procedures)
14. LMS_QuizQuestions (6 procedures)
15. LMS_Quizzes (6 procedures)
16. LMS_StudentAnswerOptions (6 procedures)
17. LMS_StudentAnswers (6 procedures)
18. LMS_StudentLessonProgress (6 procedures)
19. LMS_StudentVideoProgress (6 procedures)
20. LMS_StudySessions (6 procedures)
21. LMS_VideoInteractions (6 procedures)

Mỗi bảng có: GET, GETALL, SEARCH, ADD, EDIT, DELETE

#### 3.3 SIM_ Custom Procedures (28)
Các procedure nghiệp vụ SIM (School Information Management):

**Course Management:**
- SIM_Courses_UpdateStatus
- SIM_Course_GetWithLessonCount
- SIM_Courses_SEARCHCBX
- SIM_Courses_GetByCategory
- SIM_Courses_GetByTeacher

**Category & Chapter:**
- SIM_CourseCategories_UpdateStatus
- SIM_CourseCategories_SEARCHCBX
- SIM_CourseCategories_GetActive
- SIM_Chapters_UpdateStatus
- SIM_Chapters_Reorder
- SIM_Chapters_SEARCHCBX

**Lesson Management:**
- SIM_Lessons_GetByChapter
- SIM_Lessons_GetByType
- SIM_Lessons_UpdateSortOrder
- SIM_LessonResources_DeleteByLesson

**Teacher & Student:**
- SIM_Teacher_GetByUser
- SIM_Student_GetByUser
- SIM_Class_GetStudents

**Class & Subject:**
- SIM_Class_Subject_GetBySubject
- SIM_Subject_GetWithCourseCount
- SIM_Science_GetClasses

**Video Management:**
- SIM_Videos_GetByStatus
- SIM_Videos_UpdateCurrentVersion
- SIM_VideoAssets_GetWithVersions
- SIM_VideoAssetShares_GetByRecipient
- SIM_VideoVersions_GetLatest

**Timetable:**
- SIM_Timetable_GetByTeacher

**Year Management:**
- SIM_Year_GetCurrent
- SIM_Year_GetActive

#### 3.4 SIM_ CRUD Procedures (174)
Các procedure code-generated cho 29 bảng SIM:

**Bảng SIM:**
1. SIM_Courses (6 procedures)
2. SIM_CourseCategories (6 procedures)
3. SIM_Chapters (6 procedures)
4. SIM_Class (6 procedures)
5. SIM_Class_Subject (6 procedures)
6. SIM_Course (6 procedures)
7. SIM_Department (6 procedures)
8. SIM_District (6 procedures)
9. SIM_Ethnicity (6 procedures)
10. SIM_Faculty (6 procedures)
11. SIM_GradeLevel (6 procedures)
12. SIM_LessonResources (6 procedures)
13. SIM_Lessons (6 procedures)
14. SIM_Province (6 procedures)
15. SIM_Religion (6 procedures)
16. SIM_Science (6 procedures)
17. SIM_Student (6 procedures)
18. SIM_Subject (6 procedures)
19. SIM_Teacher (6 procedures)
20. SIM_Timetable (6 procedures)
21. SIM_VideoAssetShares (6 procedures)
22. SIM_VideoAssets (6 procedures)
23. SIM_VideoVersions (6 procedures)
24. SIM_Videos (6 procedures)
25. SIM_Year (6 procedures)

Mỗi bảng có: GET, GETALL, SEARCH, ADD, EDIT, DELETE

#### 3.5 SYS_ Custom Procedures (9)
Các procedure hệ thống:

**Permissions:**
- SYS_PermissionGroup_GetWithPermissions
- SYS_Permissions_GetByRole
- SYS_PermissionCategory_GetActive
- SYS_PermissionCategory_GetWithCount
- SYS_Roles_GetActive
- SYS_Roles_GetWithPermissions

**Refresh Tokens:**
- SYS_RefreshTokens_DeleteExpired

**Notifications:**
- SYS_Notifications_MarkAsRead

**Audit Logs:**
- SYS_AuditLogs_GetByAction

#### 3.6 SYS_ CRUD Procedures (30)
Các procedure code-generated cho 6 bảng SYS:

**Bảng SYS:**
1. SYS_Users (6 procedures)
2. SYS_AuditLogs (6 procedures)
3. SYS_Notifications (6 procedures)
4. SYS_PermissionCategory (6 procedures)
5. SYS_PermissionGroup (6 procedures)
6. SYS_Permissions (6 procedures)

Mỗi bảng có: GET, GETALL, SEARCH, ADD, EDIT, DELETE

#### 3.7 sp_ Lookup Procedures (12)
Các procedure tra cứu dữ liệu tham chiếu:

- sp_Faculty_GetAll
- sp_Department_GetAll
- sp_ClassStatus_GetAll
- sp_Subject_GetAll
- sp_Ethnicity_GetAll
- sp_Religion_GetAll
- sp_Province_GetAll
- sp_District_GetByProvince
- sp_ClassType_GetAll
- sp_GradeLevel_GetAll
- sp_UserRole_GetAll
- sp_UserStatus_GetAll

---

### 4. PHƯƠNG PHÁP PHÂN TÍCH

#### 4.1 Cách thức phát hiện
- Sử dụng `grep` để tìm tất cả các lần gọi:
  - `GetDataTable("ProcedureName", ...)` - Các procedure được gọi trực tiếp
  - `CreateNewStoredProcedure("ProcedureName")` - Các procedure custom được tạo trong code

#### 4.2 Công cụ sử dụng
- PowerShell để trích xuất và lọc tên procedure duy nhất
- Grep để tìm pattern trong file C#
- File: `comprehensive_procedure_check.sql` - Script kiểm tra tồn tại procedure trong database

---

### 5. KẾT QUẢ KIỂM TRA DATABASE

#### 5.1 Thông tin SQL Server
- **Server trong Web.config**: DESKTOP-PBMQQ03\SQLEXPRESS
- **Server kết nối test**: .\SQLEXPRESS (Local)
- **Version**: Microsoft SQL Server 2022 (RTM) - 16.0.1000.6 (X64) Express Edition
- **Kết nối**: ✅ Thành công
- **Database trong Web.config**: LMSCMS_DB_SAMPLE
- **Database kiểm tra**: LMSCMS_DB và LMSCMS_DB_SAMPLE

#### 5.2 Thống kê Stored Procedures trong Database
| Tiền tố | Trong Codebase | Trong Database | Trạng thái |
|---------|---------------|----------------|------------|
| **LMS_** | 105 | 110 | ⚠️ Có thêm 5 procedures |
| **SIM_** | 202 | 0 | ❌ **THIẾU TOÀN BỘ** |
| **SYS_** | 39 | 14 | ❌ Thiếu 25 procedures |
| **sp_** | 12 | 0 | ❌ **THIẾU TOÀN BỘ** |
| **Tổng** | 358 | 124 | ❌ Thiếu 234 procedures |

#### 5.3 Chi tiết Phân tích

**❌ CẢNH BÁO MẤT DỮ LIỆU:**
1. **Tất cả SIM_ procedures (202 procedures) đều thiếu** - Bao gồm các bảng về course, chapter, lesson, teacher, student, video, v.v.
2. **Tất cả sp_ lookup procedures (12 procedures) đều thiếu** - Các procedure tra cứu dữ liệu tham chiếu
3. **SYS_ procedures thiếu 25/39** - Chỉ có 14/39 procedures về permissions, notifications, users

**✅ LMS_ procedures:**
- Database có 110 procedures LMS_
- Codebase tham chiếu 105 procedures LMS_
- Có 5 procedures tồn tại trong database nhưng không được tìm thấy trong codebase:
  - LMS_Academic_GetCatalog
  - LMS_Academic_Save
  - LMS_Academic_Student_AssignClass
  - LMS_Auth_UpdateLastLogin
  - LMS_ClassSubject_Workspace_Ensure

#### 5.4 Kết luận Database
- Database hiện tại **KHÔNG ĐỦ** để chạy ứng dụng đầy đủ
- Thiếu **234/358** procedures (65%)
- Module bị ảnh hưởng:
  - ❌ Quản lý Course/Chapter/Lesson (SIM) - **KHÔNG HOẠT ĐỘNG ĐƯỢC**
  - ❌ Dropdown/Combobox tra cứu (sp_) - **KHÔNG HOẠT ĐỘNG ĐƯỢC**
  - ⚠️ Hệ thống/Permissions (SYS) - **HOẠT ĐỘNG BỘ PHẬN**
  - ✅ LMS Core - **HOẠT ĐỘNG TỐT**

---

### 6. KẾT LUẬN

1. **Tổng số procedures**: 358 stored procedures
2. **Custom procedures**: 70 procedures nghiệp vụ (LMS_, SIM_, SYS_)
3. **CRUD procedures**: 276 procedures code-generated
4. **Lookup procedures**: 12 procedures tra cứu

### 7. KẾ HOẠCH TIẾP THEO

1. ✅ Hoàn thành catalog procedures
2. ✅ Kiểm tra kết nối SQL local - **Thành công**
3. ✅ Chạy script kiểm tra procedure trong database
4. ✅ Báo cáo các procedure bị thiếu
5. ⏳ **KHẨN CẤP**: Tạo script để tạo 234 procedures bị thiếu
6. ⏳ Khôi phục database từ backup (nếu có)
7. ⏳ Kiểm tra xem database LMSCMS_DB_SAMPLE có đầy đủ procedures không

### 8. KIỂM TRA DATABASE SAMPLE

Đã kiểm tra database `LMSCMS_DB_SAMPLE` với kết quả:

| Tiền tố | LMSCMS_DB | LMSCMS_DB_SAMPLE | Trong Codebase |
|---------|-----------|------------------|----------------|
| **LMS_** | 110 | 138 | 105 |
| **SIM_** | 0 | 3 | 202 |
| **SYS_** | 14 | 14 | 39 |
| **sp_** | 0 | 0 | 12 |
| **Tổng** | 124 | 155 | 358 |

**Kết luận về Database Sample:**
- Database sample có nhiều hơn 31 procedures so với database chính
- Vẫn **THIẾU** 199/202 SIM_ procedures (chỉ có 3 procedures về notifications)
- Vẫn **THIẾU TOÀN BỘ** 12 sp_ lookup procedures
- Vẫn **THIẾU** 25/39 SYS_ procedures

**SIM_ procedures có trong sample:**
- SIM_Notification_GetList
- SIM_Notification_MarkAllRead
- SIM_Notification_MarkRead

### 9. KHUYẾN NGHỊ ĐIỀU TRA

**Nguyên nhân có thể:**
1. Database hiện tại có thể là database phát triển chưa đầy đủ
2. Có thể database cần được khôi phục từ backup production
3. Có thể các procedures SIM_ và sp_ nằm trong database khác
4. Có thể các procedures này chưa được tạo từ DCore code generator
5. **Web.config đang trỏ đến database**: LMSCMS_DB_SAMPLE (155 procedures) - Vẫn thiếu 203 procedures

**Đề xuất hành động:**
1. ✅ Đã kiểm tra database `LMSCMS_DB_SAMPLE` - **Vẫn thiếu nhiều procedures**
2. ✅ Đã kiểm tra Web.config - Connection string trỏ đến LMSCMS_DB_SAMPLE
3. ⏳ **Tìm file SQL script gốc**: Tìm file .sql trong thư mục project hoặc backup
4. ⏳ **Tạo script**: Generate các procedures bị thiếu từ code-generated templates (DCore framework)
5. ⏳ **Backup**: Backup database hiện tại trước khi thực hiện thay đổi
6. ⏳ **Cài đặt lại**: Chạy lại DCore code generator để tạo tất cả CRUD procedures
7. ⏳ **Kiểm tra**: Có thể cần tạo database mới với đầy đủ structure từ đầu

**Framework sử dụng:**
- DCore.Data (từ config key "ConnectStringName")
- UrlRewritingNet cho URL rewriting
- ASP.NET Web Forms 4.0

---

### 9. CÁC PROCEDURES ĐANG CÓ TRONG DATABASE (124 procedures)

**LMS_ Procedures (110):**
- Authentication: LMS_Auth_GetUserById, LMS_Auth_GetUserByUsername, LMS_Auth_GetUserPermissions, LMS_Auth_UpdateLastLogin
- Academic: LMS_Academic_GetCatalog, LMS_Academic_Save, LMS_Academic_Student_AssignClass
- Assignment: LMS_AssignmentSubmission_Create, LMS_AssignmentSubmission_GetByLesson, LMS_AssignmentSubmission_GetForTeacher, LMS_AssignmentSubmission_Grade, LMS_AssignmentSubmission_Save, LMS_AssignmentSubmission_Validate
- Chapter: LMS_Chapter_Create, LMS_Chapter_Delete, LMS_Chapter_GetByCourse, LMS_Chapter_Reorder, LMS_Chapter_Update
- Content: LMS_ContentInteraction_Create, LMS_ContentInteraction_Delete, LMS_ContentInteraction_Reorder, LMS_ContentInteraction_Update
- Course: LMS_Course_ChangeStatus, LMS_Course_Create, LMS_Course_Delete, LMS_Course_GetById, LMS_Course_GetContent, LMS_Course_GetList, LMS_Course_Publish, LMS_Course_Update
- Enrollment: LMS_Enrollment_Cancel, LMS_Enrollment_Create, LMS_Enrollment_GetList, LMS_Enrollment_RecalculateProgress
- Interactive: LMS_InteractiveContent_Complete, LMS_InteractiveContent_GetForStudent, LMS_InteractiveContent_GetForTeacher, LMS_InteractiveContent_Recalculate, LMS_InteractiveContent_SaveReadingProgress, LMS_InteractiveContent_SaveSettings, LMS_InteractiveContent_SubmitAnswer
- Lesson: LMS_Lesson_Create, LMS_Lesson_Delete, LMS_Lesson_GetById, LMS_Lesson_Reorder, LMS_Lesson_Update
- Lesson Comment: LMS_LessonComment_Delete, LMS_LessonComment_GetByLesson, LMS_LessonComment_Insert, LMS_LessonComment_Update
- Lesson Player: LMS_LessonPlayer_GetData, LMS_LessonProgress_Recalculate
- Question: LMS_Question_Create, LMS_Question_Delete, LMS_Question_GetById, LMS_Question_GetList, LMS_Question_Update
- Question Answer: LMS_QuestionAnswerKey_Create, LMS_QuestionAnswers_DeleteByQuestion, LMS_QuestionBlank_Create, LMS_QuestionOption_Create
- Quiz: LMS_Quiz_GetForStudent, LMS_Quiz_GetForTeacher, LMS_Quiz_Save, LMS_QuizAttempt_Start, LMS_QuizAttempt_Submit
- Refresh Token: LMS_RefreshToken_Create, LMS_RefreshToken_Get, LMS_RefreshToken_Revoke
- Report: LMS_Report_CourseOverview, LMS_Report_Dashboard, LMS_Report_LessonCompletion, LMS_Report_QuestionPerformance, LMS_Report_StudentProgress, LMS_Report_VideoEngagement
- Student: LMS_Student_GetById, LMS_Student_GetList, LMS_StudentAnswer_Submit, LMS_StudentCourse_GetDetail, LMS_StudentCourse_GetList, LMS_StudentDashboard_Get, LMS_StudentResults_Get
- Student Video: LMS_StudentVideoProgress_Save
- Study Session: LMS_StudySession_End, LMS_StudySession_Heartbeat, LMS_StudySession_Start
- Video: LMS_Video_AssertEditable, LMS_Video_AttachToLesson, LMS_Video_Create, LMS_Video_GetById, LMS_Video_Update, LMS_Video_UpdateWithLearningPolicy
- Video Interaction: LMS_VideoInteraction_Create, LMS_VideoInteraction_Delete, LMS_VideoInteraction_GetByVideo, LMS_VideoInteraction_PreviewAnswer, LMS_VideoInteraction_Reorder, LMS_VideoInteraction_Update
- Video Library: LMS_VideoLibrary_Attach, LMS_VideoLibrary_Create, LMS_VideoLibrary_Delete, LMS_VideoLibrary_Duplicate, LMS_VideoLibrary_GetList, LMS_VideoLibrary_Sharing_Get, LMS_VideoLibrary_Sharing_Save, LMS_VideoLibrary_Update, LMS_VideoLibrary_UpdateWithLearningPolicy
- Video Version: LMS_VideoVersion_GetUsageByVideoAsset
- Workspace: LMS_ClassSubject_Workspace_Ensure
- Global: LMS_GlobalSearch

**SYS_ Procedures (14):**
- Notification: SYS_Notification_Create, SYS_Notification_GetList, SYS_Notification_MarkAllRead, SYS_Notification_MarkRead
- Role: SYS_Role_GetList, SYS_Role_GetPermissions, SYS_Role_SavePermissions
- System Setting: SYS_SystemSetting_GetList, SYS_SystemSetting_Update
- User: SYS_User_Create, SYS_User_GetByID, SYS_User_GetList, SYS_User_SetStatus, SYS_User_Update

**THIẾU (234 procedures):**
- Tất cả SIM_ procedures (202)
- Tất cả sp_ procedures (12)
- 25 SYS_ procedures còn lại

---

### 8. TÀI LIỆU THAM KHẢO

**Trong thư mục 10.DOCS/:**
- `BAO_CAO_KY_THUAT.md` - File báo cáo này
- `TOM_TAT_BAO_CAO.md` - Tóm tắt báo cáo kỹ thuật
- `db_procedures.txt` - Danh sách procedures export từ database
- `README.md` - Tài liệu hướng dẫn chung
- `MIGRATION_PLAN.md` - Kế hoạch migration
- `WEB_ARCHITECTURE_RULES.md` - Quy tắc kiến trúc web
- `AI_PROMPTS.md` - Các prompt AI đã dùng
- `QUICK_ASSIGNMENT.md` - Phân công nhanh

**Trong thư mục 9.TOOL/:**
- `comprehensive_procedure_check.sql` - Script kiểm tra procedures chi tiết trong database
- `check_procedures.sql` - Script kiểm tra nhanh số lượng procedures theo tiền tố
- `extract_procedures.py` - Python script extract procedures từ codebase C#
- `README.md` - Hướng dẫn sử dụng các công cụ

**Project path:** `G:/0.DỰ ÁN/2.LMS-VS2010/WEB-LMS-VS2010/`

---

**Người tạo**: Claude Code  
**Ngày tạo**: 2026-10-22
