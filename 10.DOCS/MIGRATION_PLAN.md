# KẾ HOẠCH CHUYỂN ĐỔI WEB LMS SANG CẤU TRÚC MỚI
## Theo pattern của source mẫu (SimsObject/SimsService)

---

## 📊 TỔNG QUAN

### Cấu trúc hiện tại
- **LmsObject**: ~35 object files (partial class đang dùng pattern cũ)
- **LmsService**: ~6 service files (dùng ModuleService pattern - cần chuyển)
- **InformationWeb**: ~10 pages (đang skeleton - cần implement)

### Cấu trúc mục tiêu
- **LmsObject**: Base + Partial class với custom data access methods
- **LmsService**: Module services với static Table caching + UI Helpers
- **InformationWeb**: Pages với logic giao diện

---

## 🎯 CHIẾN LƯỢC CHIA NHÓM ĐỂ CHẠY SONG SONG

### 4 NHÓM CHÍNH (có thể chạy song song với 2-3 AI)

| Nhóm | Mô tả | Tác vụ | AI có thể chạy song song |
|------|-------|--------|--------------------------|
| **1. CORE** | Core infrastructure | Core services, helpers | ✅ AI #1 |
| **2. AUTH** | Authentication & Authorization | User, Role, Permission | ✅ AI #2 |
| **3. COURSE** | Course & Content management | Course, Category, Enrollment | ✅ AI #3 |
| **4. LEARNING** | Learning & Quiz | Lesson, Quiz, Assignment, Progress | ✅ AI #4 |

---

## 📋 CHI TIẾT TỪNG NHÓM

---

## NHÓM 1: CORE INFRASTRUCTURE (AI #1)

### 1.1. LmsService - Core Services
```
LmsService/Core/
├── InputGuard.cs           # ✅ ĐÃ CÓ - giữ nguyên
├── SystemError.cs          # ❌ Cần tạo (copy từ source mẫu)
├── SystemConfig.cs         # ❌ Cần tạo (connection string helper)
└── CacheService.cs         # ❌ Cần tạo (optional - dùng static DataTable pattern)
```

**Tác vụ:**
- [ ] Tạo `SystemError.cs` - copy từ source mẫu (4.SOUREC-MẪU)
- [ ] Tạo `SystemConfig.cs` - connection string management
- [ ] Review `InputGuard.cs` - đảm bảo đầy đủ methods

**Estimated time:** 30 phút

---

### 1.2. LmsObject - Base Review
```
LmsObject/Base/
├── SYS_UsersBase.cs
├── SYS_RolesBase.cs
├── SYS_PermissionsBase.cs
├── SYS_SystemSettingsBase.cs
└── ... (không sửa)
```

**Tác vụ:**
- [ ] Kiểm tra Base files - đảm bảo có GetDataTable/ExecNonQuery
- [ ] Nếu thiếu, bổ sung từ source mẫu

**Estimated time:** 15 phút

---

### 1.3. LmsObject - Partial Classes cho System Objects
```
LmsObject/
├── SYS_Users.cs            # ✅ ĐÃ CÓ - cần review theo pattern mới
├── SYS_Roles.cs            # ❌ Cần tạo/convert
├── SYS_Permissions.cs      # ❌ Cần tạo/convert
├── SYS_SystemSettings.cs   # ❌ Cần tạo/convert
└── SYS_Notifications.cs    # ❌ Cần tạo/convert
```

**Tác vụ:**
- [ ] Review `SYS_Users.cs` - thêm custom methods theo pattern mới
- [ ] Tạo `SYS_Roles.cs` với custom methods
- [ ] Tạo `SYS_Permissions.cs` với custom methods
- [ ] Tạo `SYS_SystemSettings.cs` với custom methods
- [ ] Tạo `SYS_Notifications.cs` với custom methods

**Estimated time:** 1 giờ

---

## NHÓM 2: AUTH & USER MANAGEMENT (AI #2)

### 2.1. LmsService - Auth Services
```
LmsService/Auth/
├── AuthService.cs          # ✅ ĐÃ CÓ - cần convert sang pattern mới
├── UserService.cs          # ❌ Cần tạo
├── RoleService.cs          # ❌ Cần tạo
└── PermissionService.cs    # ❌ Cần tạo
```

**Tác vụ:**
- [ ] Convert `AuthService.cs` sang pattern mới (static Table + UI Helpers)
- [ ] Tạo `UserService.cs` với:
  - static Table property
  - HaveNewData flag
  - InitDropDownList helper
  - Business logic methods
- [ ] Tạo `RoleService.cs` với:
  - static Table property
  - InitDropDownList helper
  - Business logic methods
- [ ] Tạo `PermissionService.cs` với:
  - static Table property
  - InitDropDownList helper
  - Business logic methods

**Estimated time:** 1.5 giờ

---

### 2.2. InformationWeb - Auth Pages
```
InformationWeb/Pages/Auth/
├── Login.aspx              # ✅ ĐÃ CÓ - cần implement
├── Logout.aspx             # ✅ ĐÃ CÓ - cần implement
├── Register.aspx           # ❌ Cần tạo
├── ForgotPassword.aspx     # ❌ Cần tạo
└── ChangePassword.aspx     # ❌ Cần tạo
```

**Tác vụ:**
- [ ] Implement `Login.aspx.cs` - gọi AuthService + UserService
- [ ] Implement `Logout.aspx.cs` - session cleanup
- [ ] Tạo `Register.aspx` + code-behind
- [ ] Tạo `ForgotPassword.aspx` + code-behind
- [ ] Tạo `ChangePassword.aspx` + code-behind

**Estimated time:** 2 giờ

---

### 2.3. InformationWeb - User Management Pages
```
InformationWeb/Pages/Cms/User/
├── UserList.aspx           # ❌ Cần tạo
├── UserAdd.aspx            # ❌ Cần tạo
├── UserEdit.aspx           # ❌ Cần tạo
└── UserProfile.aspx        # ❌ Cần tạo
```

**Tác vụ:**
- [ ] Tạo `UserList.aspx` + code-behind (gọi UserService.Table)
- [ ] Tạo `UserAdd.aspx` + code-behind (gọi UserService + set HaveNewData)
- [ ] Tạo `UserEdit.aspx` + code-behind
- [ ] Tạo `UserProfile.aspx` + code-behind

**Estimated time:** 2 giờ

---

## NHÓM 3: COURSE & CONTENT MANAGEMENT (AI #3)

### 3.1. LmsObject - Course Objects
```
LmsObject/
├── LMS_Courses.cs          # ❌ Cần tạo
├── LMS_Categories.cs       # ❌ Cần tạo
├── LMS_Enrollments.cs      # ❌ Cần tạo/convert
└── LMS_Chapters.cs         # ❌ Cần tạo
```

**Tác vụ:**
- [ ] Tạo `LMS_Courses.cs` với custom methods
- [ ] Tạo `LMS_Categories.cs` với custom methods
- [ ] Review/convert `LMS_Enrollments.cs`
- [ ] Tạo `LMS_Chapters.cs` với custom methods

**Estimated time:** 1 giờ

---

### 3.2. LmsService - Course Services
```
LmsService/Course/
├── CourseService.cs        # ❌ Cần tạo (convert từ ModuleServices)
├── CategoryService.cs      # ❌ Cần tạo
├── EnrollmentService.cs    # ❌ Cần tạo
└── ChapterService.cs       # ❌ Cần tạo
```

**Tác vụ:**
- [ ] Tạo `CourseService.cs` với:
  - static Table property
  - HaveNewData flag
  - InitDropDownList helper
  - Business logic methods
- [ ] Tạo `CategoryService.cs` với:
  - static Table property
  - InitDropDownList helper
- [ ] Tạo `EnrollmentService.cs` với:
  - static Table property
  - Business logic methods
- [ ] Tạo `ChapterService.cs` với:
  - static Table property
  - Business logic methods

**Estimated time:** 1.5 giờ

---

### 3.3. InformationWeb - Course Pages
```
InformationWeb/Pages/Cms/Course/
├── CourseList.aspx         # ❌ Cần tạo
├── CourseAdd.aspx          # ❌ Cần tạo
├── CourseEdit.aspx         # ❌ Cần tạo
└── CourseView.aspx         # ❌ Cần tạo
```

**Tác vụ:**
- [ ] Tạo `CourseList.aspx` + code-behind (gọi CourseService.Table)
- [ ] Tạo `CourseAdd.aspx` + code-behind
- [ ] Tạo `CourseEdit.aspx` + code-behind
- [ ] Tạo `CourseView.aspx` + code-behind

**Estimated time:** 2 giờ

---

### 3.4. InformationWeb - Student Course Pages
```
InformationWeb/Pages/Lms/
├── Courses.aspx            # ✅ ĐÃ CÓ - cần implement
├── Course.aspx             # ✅ ĐÃ CÓ - cần implement
└── Enroll.aspx             # ❌ Cần tạo
```

**Tác vụ:**
- [ ] Implement `Courses.aspx.cs` - gọi CourseService
- [ ] Implement `Course.aspx.cs` - chi tiết course
- [ ] Tạo `Enroll.aspx` + code-behind

**Estimated time:** 1.5 giờ

---

## NHÓM 4: LEARNING & QUIZ (AI #4)

### 4.1. LmsObject - Learning Objects
```
LmsObject/
├── LMS_Lessons.cs          # ❌ Cần tạo
├── LMS_Videos.cs           # ❌ Cần tạo
├── LMS_InteractiveContents.cs  # ❌ Cần tạo/convert
├── LMS_Quizzes.cs          # ❌ Cần tạo/convert
├── LMS_Questions.cs        # ❌ Cần tạo/convert
├── LMS_QuizAttempts.cs     # ❌ Cần tạo/convert
└── LMS_Assignments.cs      # ❌ Cần tạo
```

**Tác vụ:**
- [ ] Tạo `LMS_Lessons.cs` với custom methods
- [ ] Tạo `LMS_Videos.cs` với custom methods
- [ ] Review/convert `LMS_InteractiveContents.cs`
- [ ] Review/convert `LMS_Quizzes.cs`
- [ ] Review/convert `LMS_Questions.cs`
- [ ] Review/convert `LMS_QuizAttempts.cs`
- [ ] Tạo `LMS_Assignments.cs` với custom methods

**Estimated time:** 2 giờ

---

### 4.2. LmsService - Learning Services
```
LmsService/Lesson/
├── LessonService.cs        # ❌ Cần tạo
└── ContentService.cs       # ❌ Cần tạo (convert từ ModuleServices)

LmsService/Quiz/
├── QuizService.cs          # ❌ Cần tạo (convert từ ModuleServices)
├── QuestionService.cs      # ❌ Cần tạo (convert từ ModuleServices)
└── QuizAttemptService.cs   # ❌ Cần tạo

LmsService/Assignment/
├── AssignmentService.cs    # ❌ Cần tạo
└── SubmissionService.cs    # ❌ Cần tạo
```

**Tác vụ:**
- [ ] Tạo `LessonService.cs` với static Table + UI Helpers
- [ ] Convert `ContentService.cs` sang pattern mới
- [ ] Convert `QuizService.cs` sang pattern mới
- [ ] Convert `QuestionService.cs` sang pattern mới
- [ ] Tạo `QuizAttemptService.cs` với static Table
- [ ] Tạo `AssignmentService.cs` với static Table
- [ ] Tạo `SubmissionService.cs` với static Table

**Estimated time:** 2.5 giờ

---

### 4.3. InformationWeb - Learning Pages
```
InformationWeb/Pages/Cms/Lesson/
├── LessonList.aspx         # ❌ Cần tạo
├── LessonAdd.aspx          # ❌ Cần tạo
├── LessonEdit.aspx         # ❌ Cần tạo
└── LessonContent.aspx      # ❌ Cần tạo

InformationWeb/Pages/Cms/Quiz/
├── QuizList.aspx           # ❌ Cần tạo
├── QuizAdd.aspx            # ❌ Cần tạo
├── QuizEdit.aspx           # ❌ Cần tạo
└── QuestionBank.aspx       # ❌ Cần tạo
```

**Tác vụ:**
- [ ] Tạo `LessonList.aspx` + code-behind
- [ ] Tạo `LessonAdd.aspx` + code-behind
- [ ] Tạo `LessonEdit.aspx` + code-behind
- [ ] Tạo `LessonContent.aspx` + code-behind
- [ ] Tạo `QuizList.aspx` + code-behind
- [ ] Tạo `QuizAdd.aspx` + code-behind
- [ ] Tạo `QuizEdit.aspx` + code-behind
- [ ] Tạo `QuestionBank.aspx` + code-behind

**Estimated time:** 3 giờ

---

### 4.4. InformationWeb - Student Learning Pages
```
InformationWeb/Pages/Lms/
├── LessonPlayer.aspx       # ✅ ĐÃ CÓ - cần implement
├── Results.aspx            # ✅ ĐÃ CÓ - cần implement
└── QuizAttempt.aspx        # ❌ Cần tạo
```

**Tác vụ:**
- [ ] Implement `LessonPlayer.aspx.cs` - player video + interactions
- [ ] Implement `Results.aspx.cs` - show results
- [ ] Tạo `QuizAttempt.aspx` + code-behind

**Estimated time:** 2 giờ

---

## 🔄 THỨ TỰ THỰC HIỆN

### Phase 1: Foundation (Có thể chạy song song 2-3 AI)
- AI #1: Nhóm 1 (CORE) - ~2 giờ
- AI #2: Nhóm 2.1 (Auth Services) - ~1.5 giờ
- AI #3: Nhóm 3.1 (Course Objects) - ~1 giờ

### Phase 2: Core Features (Có thể chạy song song 2-3 AI)
- AI #1: Nhóm 2.2 (Auth Pages) - ~2 giờ
- AI #2: Nhóm 3.2 (Course Services) - ~1.5 giờ
- AI #3: Nhóm 4.1 (Learning Objects) - ~2 giờ

### Phase 3: CMS Features (Có thể chạy song song 2-3 AI)
- AI #1: Nhóm 2.3 (User Pages) - ~2 giờ
- AI #2: Nhóm 3.3 (Course Pages) - ~2 giờ
- AI #3: Nhóm 4.2 (Learning Services) - ~2.5 giờ

### Phase 4: Student Features (Có thể chạy song song 2-3 AI)
- AI #1: Nhóm 3.4 (Student Course Pages) - ~1.5 giờ
- AI #2: Nhóm 4.3 (Learning Pages) - ~3 giờ
- AI #3: Nhóm 4.4 (Student Learning Pages) - ~2 giờ

---

## 📝 TEMPLATE CHO MỖI AI

### Template Service (copy từ source mẫu)
```csharp
using System;
using System.Data;
using LmsObject;

namespace LmsService.[Module]
{
    public partial class [Module]Service
    {
        static bool bolHaveNewData = false;
        static DataTable dtbTable = null;

        public static DataTable Table
        {
            get
            {
                if (dtbTable == null || bolHaveNewData)
                {
                    [ObjectName] obj = new [ObjectName]();
                    dtbTable = obj.GetDataTable("[StoreName]");
                    DataRow drw = dtbTable.NewRow();
                    dtbTable.Rows.InsertAt(drw, 0);
                    bolHaveNewData = false;
                }
                return dtbTable;
            }
            set { dtbTable = value; }
        }

        public static bool HaveNewData
        {
            get { return bolHaveNewData; }
            set { bolHaveNewData = value; }
        }

        #region UI Helpers

        public static void InitDropDownList(System.Web.UI.WebControls.DropDownList ddl, string condition = "")
        {
            DataTable dtbCopy = null;
            if (!string.IsNullOrEmpty(condition))
            {
                dtbCopy = Table.Copy();
                dtbCopy.DefaultView.RowFilter = "(" + condition + ") or [IDColumn] is null";
            }
            else
            {
                dtbCopy = Table;
            }

            ddl.DataSource = dtbCopy;
            ddl.DataTextField = [ObjectName].C_[DisplayColumn];
            ddl.DataValueField = [ObjectName].C_[IDColumn];
            ddl.DataBind();
            ddl.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Chọn--", ""));
        }

        #endregion

        #region Business Logic

        // Add business logic methods here

        #endregion

        #region Data Access

        // Add data access methods here

        #endregion
    }
}
```

### Template Partial Class (LmsObject)
```csharp
using System;
using System.Data;
using DCore;

namespace LmsObject
{
    public partial class [ObjectName]
    {
        public DataTable Search(string condition)
        {
            return GetDataTable("[StoreName_Search]", "@Condition", condition);
        }

        public bool UpdateStatus()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("[StoreName_UpdateStatus]");
                objIData.AddParameter(P_[IDColumn], this.[IDProperty]);
                objIData.AddParameter(P_Status, this.intStatus);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật trạng thái", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }
    }
}
```

---

## ✅ CHECKLIST SAU KHI HOÀN THÀNH

### Nhóm 1 (CORE)
- [ ] SystemError.cs đã tạo
- [ ] SystemConfig.cs đã tạo
- [ ] SYS_Users.cs đã review
- [ ] Các System object partial classes đã tạo

### Nhóm 2 (AUTH)
- [ ] AuthService.cs đã convert
- [ ] UserService.cs đã tạo
- [ ] RoleService.cs đã tạo
- [ ] PermissionService.cs đã tạo
- [ ] Auth pages đã implement
- [ ] User pages đã tạo

### Nhóm 3 (COURSE)
- [ ] Course objects đã tạo
- [ ] Course services đã tạo
- [ ] Course pages đã tạo
- [ ] Student course pages đã implement

### Nhóm 4 (LEARNING)
- [ ] Learning objects đã tạo/convert
- [ ] Learning services đã tạo/convert
- [ ] Learning pages đã tạo
- [ ] Student learning pages đã implement

---

## 📌 GHI CHÚ QUAN TRỌNG

1. **Thứ tự dependency:**
   - Core phải hoàn thành trước
   - Auth phụ thuộc vào Core
   - Course/Learning có thể chạy song song sau khi Core xong

2. **Chạy song song:**
   - Phase 1: 3 AI có thể chạy song song (AI #1 Core, AI #2 Auth, AI #3 Course)
   - Phase 2+: 2-3 AI có thể chạy song song tùy resource

3. **File không sửa:**
   - LmsObject/Base/* - KHÔNG SỬA
   - Chỉ sửa/đối tạo partial class ngoài Base/

4. **Testing:**
   - Mỗi nhóm hoàn thành nên test trước khi merge
   - Test theo flow: Data → Service → Page
