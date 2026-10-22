# PROMPT CHO TỪNG AI CHẠY SONG SONG

Copy từng phần dưới đây và paste cho từng AI để thực hiện.

---

## 🤖 AI #1: CORE INFRASTRUCTURE

```
Bạn là chuyên gia chuyển đổi architecture web application .NET (WebForms).

Tôi có project LMS Web đang cần chuyển đổi sang pattern mới (tương tự source mẫu).

## THÔNG TIN PROJECT
- Path: G:\0.DỰ ÁN\2.LMS-VS2010\WEB-LMS-VS2010\1. WEB-LMS-VS2010
- Source mẫu tham khảo: G:\0.DỤ ÁN\2.LMS-VS2010\WEB-LMS-VS2010\4.SOUREC-MẪU
- Docs: G:\0.DỤ ÁN\2.LMS-VS2010\WEB-LMS-VS2010\10.DOCS

## TÁC VỤ CỦA BẠN (CORE INFRASTRUCTURE)

### 1. Tạo Core Services
Đọc file source mẫu ở thư mục 4.SOUREC-MẪU để tìm:
- SystemError.cs
- SystemConfig.cs

Sau đó tạo:
- LmsService/Core/SystemError.cs
- LmsService/Core/SystemConfig.cs

### 2. Review InputGuard
- Review file LmsService/InputGuard.cs
- Đảm bảo có đầy đủ validation methods

### 3. Review Base Objects
- Review các file trong LmsObject/Base/
- Đảm bảo có GetDataTable và ExecNonQuery methods
- Nếu thiếu, bổ sung từ source mẫu

### 4. Tạo/convert Partial Classes cho System Objects
Với mỗi object sau, tạo/convert partial class với custom methods:
- LmsObject/SYS_Users.cs (đã có, review thêm custom methods)
- LmsObject/SYS_Roles.cs (tạo mới)
- LmsObject/SYS_Permissions.cs (tạo mới)
- LmsObject/SYS_SystemSettings.cs (tạo mới)
- LmsObject/SYS_Notifications.cs (tạo mới)

## TEMPLATE CODE
Đọc file 10.DOCS/MIGRATION_PLAN.md section "Template Partial Class" để tham khảo pattern.

## QUY TẮC QUAN TRỌNG
1. KHÔNG SỬA các file trong LmsObject/Base/
2. Chỉ tạo/đối chỉnh partial class ở thư mục LmsObject/ (ngoài Base/)
3. Tham khảo pattern từ source mẫu ở 4.SOUREC-MẪU
4. Báo cáo progress sau khi hoàn thành từng phần

Bắt đầu thực hiện và báo cáo khi hoàn thành.
```

---

## 🤖 AI #2: AUTH & USER MANAGEMENT

```
Bạn là chuyên gia chuyển đổi architecture web application .NET (WebForms).

Tôi có project LMS Web đang cần chuyển đổi sang pattern mới (tương tự source mẫu).

## THÔNG TIN PROJECT
- Path: G:\0.DỤ ÁN\2.LMS-VS2010\WEB-LMS-VS2010\1. WEB-LMS-VS2010
- Source mẫu tham khảo: G:\0.DỤ ÁN\2.LMS-VS2010\WEB-LMS-VS2010\4.SOUREC-MẪU
- Docs: G:\0.DỤ ÁN\2.LMS-VS2010\WEB-LMS-VS2010\10.DOCS

## TÁC VỤ CỦA BẠN (AUTH & USER MANAGEMENT)

### 1. Convert AuthService sang pattern mới
File hiện tại: LmsService/AuthService.cs
Convert sang pattern mới với:
- static Table property
- HaveNewData flag
- InitDropDownList helper
- Business logic methods

### 2. Tạo Auth Services
Tạo các service với pattern mới:
- LmsService/Auth/UserService.cs
- LmsService/Auth/RoleService.cs
- LmsService/Auth/PermissionService.cs

Mỗi service cần có:
- static Table property
- HaveNewData flag
- InitDropDownList helper
- Business logic methods

### 3. Implement Auth Pages
- Implement InformationWeb/Pages/Auth/Login.aspx.cs
- Implement InformationWeb/Pages/Auth/Logout.aspx.cs
- Tạo InformationWeb/Pages/Auth/Register.aspx + code-behind
- Tạo InformationWeb/Pages/Auth/ForgotPassword.aspx + code-behind
- Tạo InformationWeb/Pages/Auth/ChangePassword.aspx + code-behind

### 4. Tạo User Management Pages
Tạo thư mục InformationWeb/Pages/Cms/User/ và tạo:
- UserList.aspx + code-behind
- UserAdd.aspx + code-behind
- UserEdit.aspx + code-behind
- UserProfile.aspx + code-behind

## TEMPLATE CODE
Đọc file 10.DOCS/MIGRATION_PLAN.md section "Template Service" để tham khảo pattern.

## QUY TẮC QUAN TRỌNG
1. KHÔNG SỬA các file trong LmsObject/Base/
2. Tham khảo pattern từ source mẫu ở 4.SOUREC-MẪU
3. Pages phải gọi đúng service tương ứng
4. Báo cáo progress sau khi hoàn thành từng phần

Bắt đầu thực hiện và báo cáo khi hoàn thành.
```

---

## 🤖 AI #3: COURSE & CONTENT MANAGEMENT

```
Bạn là chuyên gia chuyển đổi architecture web application .NET (WebForms).

Tôi có project LMS Web đang cần chuyển đổi sang pattern mới (tương tự source mẫu).

## THÔNG TIN PROJECT
- Path: G:\0.DỤ ÁN\2.LMS-VS2010\WEB-LMS-VS2010\1. WEB-LMS-VS2010
- Source mẫu tham khảo: G:\0.DỤ ÁN\2.LMS-VS2010\WEB-LMS-VS2010\4.SOUREC-MẪU
- Docs: G:\0.DỤ ÁN\2.LMS-VS2010\WEB-LMS-VS2010\10.DOCS

## TÁC VỤ CỦA BẠN (COURSE & CONTENT MANAGEMENT)

### 1. Tạo Partial Classes cho Course Objects
Tạo/convert các partial class:
- LmsObject/LMS_Courses.cs
- LmsObject/LMS_Categories.cs
- LmsObject/LMS_Enrollments.cs (review/convert file hiện có)
- LmsObject/LMS_Chapters.cs

### 2. Tạo Course Services
Tạo thư mục LmsService/Course/ và tạo:
- CourseService.cs (static Table + UI Helpers)
- CategoryService.cs (static Table + InitDropDownList)
- EnrollmentService.cs (static Table)
- ChapterService.cs (static Table)

### 3. Tạo CMS Course Pages
Tạo thư mục InformationWeb/Pages/Cms/Course/ và tạo:
- CourseList.aspx + code-behind
- CourseAdd.aspx + code-behind
- CourseEdit.aspx + code-behind
- CourseView.aspx + code-behind

### 4. Implement/ Tạo Student Course Pages
- Implement InformationWeb/Pages/Lms/Courses.aspx.cs
- Implement InformationWeb/Pages/Lms/Course.aspx.cs
- Tạo InformationWeb/Pages/Lms/Enroll.aspx + code-behind

## TEMPLATE CODE
Đọc file 10.DOCS/MIGRATION_PLAN.md section "Template Service" để tham khảo pattern.

## QUY TẮC QUAN TRỌNG
1. KHÔNG SỬA các file trong LmsObject/Base/
2. Tham khảo pattern từ source mẫu ở 4.SOUREC-MẪU
3. Pages phải gọi đúng service tương ứng
4. Báo cáo progress sau khi hoàn thành từng phần

Bắt đầu thực hiện và báo cáo khi hoàn thành.
```

---

## 🤖 AI #4: LEARNING & QUIZ

```
Bạn là chuyên gia chuyển đổi architecture web application .NET (WebForms).

Tôi có project LMS Web đang cần chuyển đổi sang pattern mới (tương tự source mẫu).

## THÔNG TIN PROJECT
- Path: G:\0.DỤ ÁN\2.LMS-VS2010\WEB-LMS-VS2010\1. WEB-LMS-VS2010
- Source mẫu tham khảo: G:\0.DỤ ÁN\2.LMS-VS2010\WEB-LMS-VS2010\4.SOUREC-MẪU
- Docs: G:\0.DỤ ÁN\2.LMS-VS2010\WEB-LMS-VS2010\10.DOCS

## TÁC VỤ CỦA BẠN (LEARNING & QUIZ)

### 1. Tạo/convert Partial Classes cho Learning Objects
- LmsObject/LMS_Lessons.cs
- LmsObject/LMS_Videos.cs
- LmsObject/LMS_InteractiveContents.cs (review/convert file hiện có)
- LmsObject/LMS_Quizzes.cs (review/convert file hiện có)
- LmsObject/LMS_Questions.cs (review/convert file hiện có)
- LmsObject/LMS_QuizAttempts.cs (review/convert file hiện có)
- LmsObject/LMS_Assignments.cs

### 2. Tạo/convert Learning Services
Tạo thư mục LmsService/Lesson/ và tạo:
- LessonService.cs (static Table + UI Helpers)
- ContentService.cs (convert file hiện có sang pattern mới)

Tạo thư mục LmsService/Quiz/ và tạo:
- QuizService.cs (convert file hiện có sang pattern mới)
- QuestionService.cs (convert file hiện có sang pattern mới)
- QuizAttemptService.cs (static Table)

Tạo thư mục LmsService/Assignment/ và tạo:
- AssignmentService.cs (static Table)
- SubmissionService.cs (static Table)

### 3. Tạo CMS Learning Pages
Tạo thư mục InformationWeb/Pages/Cms/Lesson/ và tạo:
- LessonList.aspx + code-behind
- LessonAdd.aspx + code-behind
- LessonEdit.aspx + code-behind
- LessonContent.aspx + code-behind

Tạo thư mục InformationWeb/Pages/Cms/Quiz/ và tạo:
- QuizList.aspx + code-behind
- QuizAdd.aspx + code-behind
- QuizEdit.aspx + code-behind
- QuestionBank.aspx + code-behind

### 4. Implement/ Tạo Student Learning Pages
- Implement InformationWeb/Pages/Lms/LessonPlayer.aspx.cs
- Implement InformationWeb/Pages/Lms/Results.aspx.cs
- Tạo InformationWeb/Pages/Lms/QuizAttempt.aspx + code-behind

## TEMPLATE CODE
Đọc file 10.DOCS/MIGRATION_PLAN.md section "Template Service" để tham khảo pattern.

## QUY TẮC QUAN TRỌNG
1. KHÔNG SỬA các file trong LmsObject/Base/
2. Tham khảo pattern từ source mẫu ở 4.SOUREC-MẪU
3. Pages phải gọi đúng service tương ứng
4. Báo cáo progress sau khi hoàn thành từng phần

Bắt đầu thực hiện và báo cáo khi hoàn thành.
```

---

## 🔄 THỨ TỰ CHẠY SONG SONG

### Lần 1 (Khởi động)
- Chạy AI #1 (CORE) trước - nó là dependency cho các AI khác
- Có thể chạy AI #3 (COURSE OBJECTS) song song với AI #1 (không phụ thuộc)

### Lần 2 (Sau khi AI #1 xong)
- Chạy AI #2 (AUTH SERVICES)
- Chạy AI #3 (COURSE SERVICES)
- Chạy AI #4 (LEARNING OBJECTS)

### Lần 3 (Sau khi Lần 2 xong)
- Chạy AI #2 (AUTH PAGES)
- Chạy AI #3 (COURSE PAGES)
- Chạy AI #4 (LEARNING SERVICES)

### Lần 4 (Sau khi Lần 3 xong)
- Chạy AI #2 (USER PAGES)
- Chạy AI #3 (STUDENT COURSE PAGES)
- Chạy AI #4 (LEARNING PAGES + STUDENT LEARNING PAGES)

---

## 📌 GHI CHÚ QUAN TRỌNG CHO TẤT CẢ AI

1. Đọc file 10.DOCS/MIGRATION_PLAN.md trước khi bắt đầu
2. Đọc file 10.DOCS/WEB_ARCHITECTURE_RULES.md để hiểu quy tắc coding
3. Tham khảo pattern từ 4.SOUREC-MẪU
4. KHÔNG SỬA file trong LmsObject/Base/
5. Báo cáo progress sau mỗi phần hoàn thành
6. Test theo flow: Data → Service → Page
