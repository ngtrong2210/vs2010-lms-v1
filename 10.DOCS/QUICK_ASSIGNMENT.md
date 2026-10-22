# PHÂN CÔNG TÁC CHO AI CHẠY SONG SONG

---

## 🎯 QUICK OVERVIEW

- **Total:** 4 Nhóm chính
- **Song song:** Có thể chạy 2-3 AI cùng lúc
- **Path project:** `G:\0.DỰ ÁN\2.LMS-VS2010\WEB-LMS-VS2010\1. WEB-LMS-VS2010`
- **Source mẫu:** `G:\0.DỰ ÁN\2.LMS-VS2010\WEB-LMS-VS2010\4.SOUREC-MẪU`

---

## 📋 PHÂN CÔNG (Copy paste từng phần cho AI)

---

### AI #1: CORE INFRASTRUCTURE
**Estimated:** 2 giờ

**Tác vụ:**
1. Tạo `LmsService/Core/SystemError.cs` - copy từ source mẫu
2. Tạo `LmsService/Core/SystemConfig.cs` - connection string helper
3. Review `LmsService/InputGuard.cs` - đảm bảo đầy đủ
4. Review `LmsObject/Base/*` - đảm bảo có GetDataTable/ExecNonQuery
5. Tạo/convert các partial classes:
   - `LmsObject/SYS_Users.cs` - review thêm custom methods
   - `LmsObject/SYS_Roles.cs` - tạo mới
   - `LmsObject/SYS_Permissions.cs` - tạo mới
   - `LmsObject/SYS_SystemSettings.cs` - tạo mới
   - `LmsObject/SYS_Notifications.cs` - tạo mới

**Template:** Xem file `MIGRATION_PLAN.md` section "Template Partial Class"

---

### AI #2: AUTH & USER MANAGEMENT
**Estimated:** 3.5 giờ

**Tác vụ:**
1. Convert `LmsService/AuthService.cs` sang pattern mới (static Table + UI Helpers)
2. Tạo `LmsService/Auth/UserService.cs` với:
   - static Table property
   - HaveNewData flag
   - InitDropDownList helper
   - Business logic methods
3. Tạo `LmsService/Auth/RoleService.cs` với:
   - static Table property
   - InitDropDownList helper
4. Tạo `LmsService/Auth/PermissionService.cs` với:
   - static Table property
   - InitDropDownList helper
5. Implement `InformationWeb/Pages/Auth/Login.aspx.cs`
6. Implement `InformationWeb/Pages/Auth/Logout.aspx.cs`
7. Tạo `InformationWeb/Pages/Auth/Register.aspx` + code-behind
8. Tạo `InformationWeb/Pages/Auth/ForgotPassword.aspx` + code-behind
9. Tạo `InformationWeb/Pages/Auth/ChangePassword.aspx` + code-behind
10. Tạo `InformationWeb/Pages/Cms/User/UserList.aspx` + code-behind
11. Tạo `InformationWeb/Pages/Cms/User/UserAdd.aspx` + code-behind
12. Tạo `InformationWeb/Pages/Cms/User/UserEdit.aspx` + code-behind
13. Tạo `InformationWeb/Pages/Cms/User/UserProfile.aspx` + code-behind

**Template:** Xem file `MIGRATION_PLAN.md` section "Template Service"

---

### AI #3: COURSE & CONTENT MANAGEMENT
**Estimated:** 4.5 giờ

**Tác vụ:**
1. Tạo các partial classes:
   - `LmsObject/LMS_Courses.cs`
   - `LmsObject/LMS_Categories.cs`
   - Review/convert `LmsObject/LMS_Enrollments.cs`
   - `LmsObject/LMS_Chapters.cs`
2. Tạo services:
   - `LmsService/Course/CourseService.cs` (static Table + UI Helpers)
   - `LmsService/Course/CategoryService.cs` (static Table + InitDropDownList)
   - `LmsService/Course/EnrollmentService.cs` (static Table)
   - `LmsService/Course/ChapterService.cs` (static Table)
3. Tạo CMS pages:
   - `InformationWeb/Pages/Cms/Course/CourseList.aspx` + code-behind
   - `InformationWeb/Pages/Cms/Course/CourseAdd.aspx` + code-behind
   - `InformationWeb/Pages/Cms/Course/CourseEdit.aspx` + code-behind
   - `InformationWeb/Pages/Cms/Course/CourseView.aspx` + code-behind
4. Implement/ tạo student pages:
   - Implement `InformationWeb/Pages/Lms/Courses.aspx.cs`
   - Implement `InformationWeb/Pages/Lms/Course.aspx.cs`
   - Tạo `InformationWeb/Pages/Lms/Enroll.aspx` + code-behind

**Template:** Xem file `MIGRATION_PLAN.md` section "Template Service"

---

### AI #4: LEARNING & QUIZ
**Estimated:** 7.5 giờ

**Tác vụ:**
1. Tạo/convert partial classes:
   - `LmsObject/LMS_Lessons.cs`
   - `LmsObject/LMS_Videos.cs`
   - Review/convert `LmsObject/LMS_InteractiveContents.cs`
   - Review/convert `LmsObject/LMS_Quizzes.cs`
   - Review/convert `LmsObject/LMS_Questions.cs`
   - Review/convert `LmsObject/LMS_QuizAttempts.cs`
   - `LmsObject/LMS_Assignments.cs`
2. Tạo/convert services:
   - `LmsService/Lesson/LessonService.cs` (static Table + UI Helpers)
   - Convert `LmsService/Lesson/ContentService.cs` sang pattern mới
   - Convert `LmsService/Quiz/QuizService.cs` sang pattern mới
   - Convert `LmsService/Quiz/QuestionService.cs` sang pattern mới
   - Tạo `LmsService/Quiz/QuizAttemptService.cs` (static Table)
   - Tạo `LmsService/Assignment/AssignmentService.cs` (static Table)
   - Tạo `LmsService/Assignment/SubmissionService.cs` (static Table)
3. Tạo CMS pages:
   - `InformationWeb/Pages/Cms/Lesson/LessonList.aspx` + code-behind
   - `InformationWeb/Pages/Cms/Lesson/LessonAdd.aspx` + code-behind
   - `InformationWeb/Pages/Cms/Lesson/LessonEdit.aspx` + code-behind
   - `InformationWeb/Pages/Cms/Lesson/LessonContent.aspx` + code-behind
   - `InformationWeb/Pages/Cms/Quiz/QuizList.aspx` + code-behind
   - `InformationWeb/Pages/Cms/Quiz/QuizAdd.aspx` + code-behind
   - `InformationWeb/Pages/Cms/Quiz/QuizEdit.aspx` + code-behind
   - `InformationWeb/Pages/Cms/Quiz/QuestionBank.aspx` + code-behind
4. Implement/ tạo student pages:
   - Implement `InformationWeb/Pages/Lms/LessonPlayer.aspx.cs`
   - Implement `InformationWeb/Pages/Lms/Results.aspx.cs`
   - Tạo `InformationWeb/Pages/Lms/QuizAttempt.aspx` + code-behind

**Template:** Xem file `MIGRATION_PLAN.md` section "Template Service"

---

## 🔄 THỨ TỰ CHẠY SONG SONG

### Lần 1 (Khởi động - 3 AI cùng chạy)
- AI #1: CORE INFRASTRUCTURE (đợi xong mới chạy tiếp)
- AI #2: AUTH SERVICES (chỉ phần 1-4, đợi AI #1 xong)
- AI #3: COURSE OBJECTS (chỉ phần 1, có thể chạy song song với AI #1)

### Lần 2 (Sau khi AI #1 xong - 3 AI cùng chạy)
- AI #1: AUTH PAGES (nhóm 2 phần 5-13)
- AI #2: COURSE SERVICES (nhóm 3 phần 2)
- AI #3: LEARNING OBJECTS (nhóm 4 phần 1)

### Lần 3 (Sau khi Lần 2 xong - 3 AI cùng chạy)
- AI #1: USER PAGES (nhóm 2 phần 10-13)
- AI #2: COURSE PAGES (nhóm 3 phần 3)
- AI #3: LEARNING SERVICES (nhóm 4 phần 2)

### Lần 4 (Sau khi Lần 3 xong - 3 AI cùng chạy)
- AI #1: STUDENT COURSE PAGES (nhóm 3 phần 4)
- AI #2: LEARNING PAGES (nhóm 4 phần 3)
- AI #3: STUDENT LEARNING PAGES (nhóm 4 phần 4)

---

## 📌 GHI CHÚ CHO MỖI AI

1. **Đọc file `MIGRATION_PLAN.md`** trước khi bắt đầu
2. **Copy template** từ file đó để đảm bảo consistency
3. **Source mẫu** nằm ở thư mục `4.SOUREC-MẪU` - tham khảo pattern
4. **KHÔNG SỬA** các file trong `LmsObject/Base/`
5. **Report progress** sau mỗi phần hoàn thành
6. **Test** theo flow: Data (LmsObject) → Service (LmsService) → Page (InformationWeb)

---

## ✅ CHECKLIST CUỐI CÙNG

Sau khi tất cả AI hoàn thành, kiểm tra:
- [ ] Tất cả services có static Table property
- [ ] Tất cả services có InitDropDownList helper
- [ ] Tất cả pages gọi đúng service
- [ ] Không có file nào bị conflict
- [ ] Build project thành công
