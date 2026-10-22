# QUY TẮC CẤU TRÚC WEB LMS
## Dựa trên kiến trúc 3-layer (Data - Business - Presentation)
## Pattern theo source mẫu (SimsObject/SimsService)

---

## 📐 TỔNG QUAN CẤU TRÚC DỰ ÁN

```
WEB-LMS-VS2010/
├── LmsObject/              # DATA LAYER - Lớp truy cập dữ liệu
├── LmsService/            # BUSINESS LAYER - Lớp nghiệp vụ + UI Helpers
├── InformationWeb/        # PRESENTATION LAYER - Giao diện Web Forms
└── WEB_ARCHITECTURE_RULES.md  # File quy tắc này
```

---

## 🎯 3 LAYER ARCHITECTURE

```
┌─────────────────────────────────────────────────────────┐
│                  InformationWeb (Presentation)           │
│  - Web Forms Pages (.aspx + .aspx.cs)                    │
│  - User Controls (.ascx + .ascx.cs)                      │
│  - Master Pages (.master)                                │
│  - Handlers (.ashx)                                      │
└──────────────────────┬──────────────────────────────────┘
                       │ GỌI LmsService (UI helpers, caching)
                       │ GỌI TRỰC TIẾP LmsObject (data methods)
                       ▼
┌─────────────────────────────────────────────────────────┐
│                   LmsService (Business)                  │
│  - Services theo module (Auth, User, Course...)          │
│  - UI Helpers (Init controls, caching)                   │
│  - Business Logic (tính toán, xử lý nghiệp vụ)           │
│  - Validation (InputGuard)                               │
└──────────────────────┬──────────────────────────────────┘
                       │ GỌI LmsObject
                       │ GỌI DCore TRỰC TIẾP (trong partial class)
                       ▼
┌─────────────────────────────────────────────────────────┐
│                    LmsObject (Data)                      │
│  - Base/ (Auto-generated CRUD)                           │
│  - Partial classes (Custom logic + DCore calls)         │
│  - Direct database access via DCore                      │
└──────────────────────┬──────────────────────────────────┘
                       │ SQL STORED PROCEDURES
                       ▼
                    Database
```

---

## LAYER 1: LmsObject (Data Layer)

### Cấu trúc thư mục
```
LmsObject/
├── Base/                    # File auto-generated (KHÔNG SỬA)
│   ├── SYS_UsersBase.cs
│   ├── LMS_CoursesBase.cs
│   ├── LMS_QuizzesBase.cs
│   └── ... (tất cả object từ database)
│
└── [ObjectName].cs          # Partial class (SỬA Ở ĐÂY)
    ├── SYS_Users.cs
    ├── LMS_Courses.cs
    ├── LMS_Quizzes.cs
    └── ...
```

### Quy tắc cho Base/ (Auto-generated)
- ✅ **KHÔNG BAO GIỜ SỬA** file trong thư mục `Base/`
- ✅ File được sinh tự động từ database
- ✅ Khi đổi database schema, chạy generator để update
- ✅ Mỗi file có cấu trúc:
  - Member Variables (private fields)
  - Properties (public getters/setters)
  - Parse methods (IDataReader, DataRow)
  - CRUD methods (Get, Add, Update, Delete)
  - Transaction methods (BeginTransaction, Commit, Rollback)
  - Static constants (Table, Store, Parameter, Column names)

### Quy tắc cho Partial Class
- ✅ **Có thể gọi DCore.Data trực tiếp** trong partial class
- ✅ Sử dụng `partial class` để mở rộng
- ✅ Có thể thêm:
  - Custom stored procedure calls
  - Business logic phức tạp
  - Helper methods
  - Computed properties
  - Custom queries

### Ví dụ Partial Class đúng (Pattern theo source mẫu)
```csharp
// LmsObject/SYS_Users.cs
using System;
using System.Data;
using DCore;

namespace LmsObject
{
    /// <summary>
    /// Phần mở rộng nghiệp vụ của SYS_Users. Generator không ghi đè file này.
    /// </summary>
    public partial class SYS_Users
    {
        /// <summary>
        /// Lấy danh sách user theo điều kiện
        /// Store: SYS_Users_Search
        /// </summary>
        public DataTable Search(string condition)
        {
            return GetDataTable("[SYS_Users_Search]", "@Condition", condition);
        }

        /// <summary>
        /// Cập nhật trạng thái user
        /// Store: SYS_Users_UpdateStatus
        /// </summary>
        public bool UpdateStatus()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SYS_Users_UpdateStatus");
                objIData.AddParameter(P_UserID, this.lngUserID);
                objIData.AddParameter(P_Status, this.intStatus);
                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật trạng thái user", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        /// <summary>
        /// Custom query với params
        /// </summary>
        public DataTable SearchByRole(string role, int? status)
        {
            return GetDataTable("SYS_Users_SearchByRole",
                "@Role", role,
                "@Status", status);
        }
    }
}
```

### Quy tắc gọi Database từ LmsObject
```csharp
// ✅ ĐÚNG - Sử dụng GetDataTable helper
SYS_Users user = new SYS_Users();
DataTable table = user.GetDataTable("SYS_Users_GETALL");

// ✅ ĐÚNG - Sử dụng Base methods
user.UserID = 1;
if (user.Get())
{
    // Lấy thành công
}

// ✅ ĐÚNG - Add/Update/Delete
user.Username = "newuser";
user.Add();  // hoặc user.Update(), user.Delete()

// ✅ ĐÚNG - Gọi DCore trực tiếp trong partial class
if (!bolIsExistIData)
    objIData = DCore.Data.CreateData();
objIData.CreateNewStoredProcedure("CustomStore");
objIData.ExecNonQuery();
```

---

## LAYER 2: LmsService (Business Layer)

### Cấu trúc thư mục
```
LmsService/
├── Core/                    # Core services
│   ├── InputGuard.cs        # Validation helper
│   ├── CacheService.cs      # Cache management
│   └── SystemError.cs       # Error logging
│
├── Auth/                    # Authentication & Authorization
│   ├── AuthService.cs
│   ├── PermissionService.cs
│   └── RefreshTokenService.cs
│
├── User/                    # User management
│   ├── UserService.cs
│   ├── RoleService.cs
│   └── ProfileService.cs
│
├── Course/                  # Course management
│   ├── CourseService.cs
│   ├── CategoryService.cs
│   └── EnrollmentService.cs
│
├── Lesson/                  # Lesson & Content
│   ├── LessonService.cs
│   ├── ContentService.cs
│   └── InteractionService.cs
│
├── Quiz/                    # Quiz & Questions
│   ├── QuizService.cs
│   ├── QuestionService.cs
│   └── QuizAttemptService.cs
│
├── Assignment/              # Assignments
│   ├── AssignmentService.cs
│   └── SubmissionService.cs
│
├── Notification/            # Notifications
│   └── NotificationService.cs
│
└── System/                  # System settings
    ├── SettingService.cs
    └── AuditLogService.cs
```

### Quy tắc đặt tên Service
- ✅ Tên file: `[Module]Service.cs`
- ✅ Namespace: `LmsService.[Module]`
- ✅ Class: `public partial class [Module]Service`
- ✅ Mỗi service quản lý 1 nhóm object liên quan

### Quy tắc viết Service
1. **GỌI LmsObject để truy cập dữ liệu**
2. **Caching dữ liệu với static DataTable**
3. **UI Helper methods (init controls, filters)**
4. **Business logic (tính toán, xử lý nghiệp vụ)**
5. **Validation với InputGuard (nếu cần)**
6. **Exception handling với SystemError**

### Template Service chuẩn (Pattern theo source mẫu)
```csharp
using System;
using System.Data;
using LmsObject;

namespace LmsService.User
{
    public partial class UserService
    {
        static bool bolHaveNewData = false;
        static DataTable dtbTable = null;

        /// <summary>
        /// Static Table với caching
        /// </summary>
        public static DataTable Table
        {
            get
            {
                if (dtbTable == null || bolHaveNewData)
                {
                    SYS_Users userObj = new SYS_Users();
                    dtbTable = userObj.GetDataTable("SYS_Users_SearchCBX");
                    DataRow drw = dtbTable.NewRow();
                    dtbTable.Rows.InsertAt(drw, 0); // thêm dòng trống
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

        /// <summary>
        /// Khởi tạo DropDownList. Chú ý data chỉ được load một lần.
        /// </summary>
        public static void InitDropDownList(System.Web.UI.WebControls.DropDownList ddl, string condition = "")
        {
            DataTable dtbCopy = null;
            if (!string.IsNullOrEmpty(condition))
            {
                dtbCopy = Table.Copy();
                dtbCopy.DefaultView.RowFilter = "(" + condition + ") or UserID is null";
            }
            else
            {
                dtbCopy = Table;
            }

            ddl.DataSource = dtbCopy;
            ddl.DataTextField = SYS_Users.C_Username;
            ddl.DataValueField = SYS_Users.C_UserID;
            ddl.DataBind();
            ddl.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Chọn--", ""));
        }

        #endregion

        #region Business Logic

        /// <summary>
        /// Tính toán chỉ số hoạt động user
        /// </summary>
        public static int CalculateActivityScore(int? loginCount, int? postCount)
        {
            if (loginCount == null) loginCount = 0;
            if (postCount == null) postCount = 0;

            return (loginCount.Value * 1) + (postCount.Value * 5);
        }

        #endregion

        #region Data Access Methods

        /// <summary>
        /// Lấy user theo ID
        /// </summary>
        public SYS_Users GetUserById(long userId)
        {
            SYS_Users userObj = new SYS_Users();
            userObj.UserID = userId;
            if (userObj.Get())
            {
                return userObj;
            }
            return null;
        }

        /// <summary>
        /// Tìm kiếm user
        /// </summary>
        public DataTable SearchUsers(string keyword)
        {
            SYS_Users userObj = new SYS_Users();
            return userObj.GetDataTable("SYS_Users_Search", "@Keyword", keyword);
        }

        #endregion
    }
}
```

### Quy tắc Caching
```csharp
// ✅ ĐÚNG - Static DataTable với flag
static bool bolHaveNewData = false;
static DataTable dtbTable = null;

public static DataTable Table
{
    get
    {
        if (dtbTable == null || bolHaveNewData)
        {
            // Load từ database
            SYS_Users userObj = new SYS_Users();
            dtbTable = userObj.GetDataTable("SYS_Users_SearchCBX");
            bolHaveNewData = false;
        }
        return dtbTable;
    }
}

// Khi data thay đổi, set flag
UserService.HaveNewData = true;
```

### Quy tắc Validation
```csharp
// Validate với InputGuard (nếu cần)
username = InputGuard.RequiredText(username, 100, "tên đăng nhập");
email = InputGuard.Email(email, "email");
password = InputGuard.RequiredText(password, 200, "mật khẩu");
```

### Quy tắc Exception Handling
```csharp
try
{
    // Xử lý nghiệp vụ
}
catch (Exception ex)
{
    new SystemError(SystemConfig.ConnectionString, "Mô tả lỗi", ex);
    return false;
}
```

---

## LAYER 3: InformationWeb (Presentation Layer)

### Cấu trúc thư mục
```
InformationWeb/
├── Pages/                   # Các trang theo module
│   ├── Auth/               # Đăng nhập, đăng xuất
│   ├── Lms/                # Các trang LMS chính
│   ├── Cms/                # Quản trị CMS
│   └── Errors/             # Trang lỗi
│
├── MasterPages/            # Master pages
├── Controls/               # User controls
├── Handlers/               # HTTP Handlers
├── LmsInfrastructure/      # Infrastructure (Session, Config...)
├── assets/                 # CSS, JS, Images
├── Media/                  # Media files
└── uploads/                # Upload files
```

### Quy tắc gọi từ Presentation
- ✅ **GỌI LmsService** (UI helpers, caching, business logic)
- ✅ **GỌI TRỰC TIẾP LmsObject** (data methods đơn giản)
- ❌ **KHÔNG GỌI TRỰC TIẾP DCore/Data**

### Ví dụ Page đúng (Pattern theo source mẫu)
```csharp
// InformationWeb/Pages/Lms/CourseList.aspx.cs
using System;
using System.Data;
using LmsService.Course;
using LmsObject;

namespace InformationWeb.Pages.Lms
{
    public partial class CourseList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCourses();
                InitDropDownLists();
            }
        }

        private void LoadCourses()
        {
            // ✅ ĐÚNG - Gọi Service (có caching)
            DataTable courses = CourseService.Table;

            if (courses != null)
            {
                gvCourses.DataSource = courses;
                gvCourses.DataBind();
            }
        }

        private void InitDropDownLists()
        {
            // ✅ ĐÚNG - Gọi Service UI helper
            CourseService.InitDropDownList(ddlCategory, "IsActive = 1");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // ✅ ĐÚNG - Gọi trực tiếp LmsObject cho custom query
            LMS_Courses courseObj = new LMS_Courses();
            DataTable results = courseObj.GetDataTable("LMS_Courses_Search",
                "@Keyword", txtKeyword.Text,
                "@CategoryID", ddlCategory.SelectedValue);

            gvCourses.DataSource = results;
            gvCourses.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            // ✅ ĐÚNG - Gọi Service method
            CourseService courseService = new CourseService();
            bool success = courseService.AddCourse(/* params */);

            if (success)
            {
                CourseService.HaveNewData = true; // Refresh cache
                LoadCourses();
            }
        }
    }
}
```

### Quy tắc code-behind
- ✅ Code-behind chứa logic giao diện
- ✅ Gọi Service cho UI helpers và caching
- ✅ Gọi trực tiếp LmsObject cho data methods đơn giản
- ✅ Hiển thị dữ liệu lên controls
- ✅ Set `HaveNewData = true` khi data thay đổi

---

## 📋 CHECKLIST KHI TẠO TÍNH NĂNG MỚI

### Bước 1: Database
- [ ] Tạo/modify table trong database
- [ ] Tạo stored procedures (GET, GETALL, SEARCH, ADD, EDIT, DELETE)
- [ ] Test stored procedures

### Bước 2: LmsObject (Data Layer)
- [ ] Chạy generator để tạo file Base mới
- [ ] Kiểm tra file trong `Base/` (KHÔNG SỬA)
- [ ] Tạo file partial class nếu cần custom methods
- [ ] Thêm custom data access methods vào partial class
- [ ] Có thể gọi DCore.Data trực tiếp trong partial class

### Bước 3: LmsService (Business Layer)
- [ ] Tạo thư mục module nếu chưa có
- [ ] Tạo file `[Module]Service.cs` (partial class)
- [ ] Implement static Table property với caching
- [ ] Implement UI Helper methods (Init controls)
- [ ] Implement Business Logic methods (tính toán)
- [ ] Implement Data Access methods (gọi LmsObject)
- [ ] Test service

### Bước 4: InformationWeb (Presentation Layer)
- [ ] Tạo page/control trong thư mục phù hợp
- [ ] Gọi Service UI helpers để init controls
- [ ] Gọi Service.Table cho dữ liệu có caching
- [ ] Gọi trực tiếp LmsObject cho custom queries
- [ ] Set HaveNewData = true khi data thay đổi
- [ ] Test giao diện

---

## ⚠️ QUY TẮC QUAN TRỌNG

### LUÔN LUÔN NHỚ
1. **Base files không sửa** (Chỉ sửa partial class)
2. **Partial class có thể gọi DCore trực tiếp**
3. **Service dùng static DataTable với caching**
4. **Service cung cấp UI Helpers (init controls)**
5. **Presentation có thể gọi Service hoặc LmsObject trực tiếp**
6. **Set HaveNewData = true khi data thay đổi**
7. **Exception handling với SystemError**

### NẾU VI PHẠM
- Code khó maintain
- Logic lộn xộn
- Bug khó tìm
- Không tái sử dụng được

---

## 🔄 VÍ DỤ FLOW ĐÚNG

### Ví dụ 1: Load danh sách courses (có caching)

```
1. Presentation (CourseList.aspx.cs)
   ↓ Gọi CourseService.Table
2. Business (CourseService.Table)
   ↓ Kiểm tra bolHaveNewData
   ↓ Nếu true hoặc null:
   ↓   Gọi LMS_Courses.GetDataTable("LMS_Courses_SearchCBX")
   ↓   Lưu vào static dtbTable
   ↓ Set bolHaveNewData = false
   ↓ Return dtbTable
3. Presentation
   ↓ Bind data vào GridView
```

### Ví dụ 2: User đăng nhập

```
1. Presentation (Login.aspx.cs)
   ↓ Gọi AuthService.Login(username, password)
2. Business (AuthService.Login())
   ↓ Validate với InputGuard
   ↓ Gọi SYS_Users.SearchByUsername(username)
3. Data (SYS_Users partial class)
   ↓ GetDataTable("SYS_Users_SearchByUsername")
   ↓ Return DataTable
4. Business (AuthService)
   ↓ Verify password
   ↓ Load permissions
   ↓ Return user
5. Presentation (Login.aspx.cs)
   ↓ Save to Session
   ↓ Redirect to dashboard
```

### Ví dụ 3: Thêm course mới

```
1. Presentation (CourseAdd.aspx.cs)
   ↓ Lấy data từ form
   ↓ Gọi CourseService.AddCourse(course)
2. Business (CourseService.AddCourse())
   ↓ Validate với InputGuard
   ↓ Gọi LMS_Courses.Add()
3. Data (LMS_CoursesBase)
   ↓ Execute stored procedure
   ↓ Return true/false
4. Business
   ↓ Nếu thành công: CourseService.HaveNewData = true
   ↓ Return result
5. Presentation
   ↓ Nếu thành công: Redirect về list
   ↓ Nếu thất bại: Hiển thị lỗi
```

---

## 📚 TÀI LIỆU THAM KHẢO

### Mẫu tham khảo
- `4.SOUREC-MẪU/SimsObject/` - Cấu trúc Data Layer mẫu (WinForms)
- `4.SOUREC-MẪU/SimsService/` - Cấu trúc Business Layer mẫu (WinForms)
- `InformationWeb/` - Cấu trúc Presentation Layer (Web Forms)

### Các helper quan trọng
- `DCore.Data` - Data access framework
- `InputGuard` - Validation helper
- `SystemError` - Error logging
- `SystemConfig.ConnectionString` - Connection string

---

## 📝 GHI CHÚ

- Quy tắc này áp dụng cho toàn bộ dự án WEB-LMS-VS2010
- Khi có thay đổi, update file này và thông báo cho team
- Mọi dev phải đọc và tuân thủ quy tắc này

---

**Phiên bản:** 1.0  
**Ngày tạo:** 2026  
**Áp dụng cho:** WEB-LMS-VS2010
