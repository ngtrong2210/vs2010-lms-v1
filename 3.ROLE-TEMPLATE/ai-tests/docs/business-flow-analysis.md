# Business Flow Analysis - LMS Web Forms Project
## Phase 02: Business Flow Analysis

**Project:** LMS (Learning Management System) - ASP.NET Web Forms
**Analysis Date:** 2026-10-22
**Analysis Status:** IN PROGRESS

---

## 1. Authentication Module Flow

### 1.1 Login Flow

**Entry Point:** `/login` → `Pages/Auth/Login.aspx`

**Preconditions:**
- User is not authenticated
- Session is empty or expired

**Input Fields:**
| Field | Type | Required | Validation | Max Length |
|-------|------|----------|------------|------------|
| Username | TextBox | Yes | RequiredFieldValidator | 100 |
| Password | TextBox | Yes | RequiredFieldValidator | 200 |
| Remember Me | CheckBox | No | None | N/A |

**Demo Accounts (UI-visible):**
| Role | Username | Password |
|------|----------|----------|
| Student | student | 123456 |
| Teacher | teacher | 123456 |
| Admin | admin | 123456 |

**Flow Steps:**
1. User enters username and password
2. Click "Đăng nhập" button
3. Client-side validation fires (RequiredFieldValidator)
4. Form POST to server (PostBack)
5. Server calls `ServiceRegistry.Auth.Login(username, password, out message)`
6. If user == null:
   - Display error message in `MessageText` label
   - Stay on login page
7. If user != null:
   - Call `UserSession.SignIn(user, RememberCheck.Checked)`
   - Clear session, abandon old session
   - Create FormsAuthenticationTicket
   - Set authentication cookie
   - Check return URL (if present)
   - If return URL is valid and allowed:
     - Redirect to return URL
   - Else:
     - If user.IsStudent → Redirect to `/lms/dashboard`
     - Else → Redirect to `/cms/dashboard`

**Return URL Validation:**
- Must be local URL (starts with `/`)
- Must not start with `/Pages/` (physical paths blocked)
- CMS paths only allowed for non-students
- LMS paths only allowed for students

**Expected Results:**
- Success: Redirect to appropriate dashboard
- Failure: Error message displayed, stay on login page

**Error Conditions:**
- Username empty → "Vui lòng nhập tên đăng nhập."
- Password empty → "Vui lòng nhập mật khẩu."
- Invalid credentials → Message from service
- System error → "Không thể đăng nhập. Vui lòng thử lại."

**Dependencies:**
- ServiceRegistry.Auth service
- SYS_Users object
- FormsAuthentication
- Session state

**ViewState Usage:**
- Unknown (minimal for login page)

**PostBack Type:**
- Full PostBack (standard form submit)

---

### 1.2 Logout Flow

**Entry Point:** `/logout` → `Pages/Auth/Logout.aspx`

**Preconditions:**
- User is authenticated
- Session contains user data

**Flow Steps:**
1. User clicks logout link/button
2. Server calls `UserSession.SignOut()`
3. FormsAuthentication.SignOut()
4. Session.Clear()
5. Session.Abandon()
6. Redirect to login page or home

**Expected Results:**
- Authentication cookie removed
- Session cleared
- Redirect to login page

**Dependencies:**
- UserSession.SignOut()
- FormsAuthentication

---

## 2. CMS Dashboard Flow

### 2.1 Dashboard Load Flow

**Entry Point:** `/cms/dashboard` → `Pages/Cms/Dashboard.aspx`

**Preconditions:**
- User is authenticated
- User is NOT student (IsStudent = false)
- User has CMS access permission

**Authorization:**
- Role-based: Non-students only
- Code enforcement in Login.ascx.cs redirect logic

**Data Loading:**
1. Page_Load fires
2. If !IsPostBack:
   - Call `ServiceRegistry.Reports.GetDataTable("Dashboard")`
   - Extract summary data (TotalCourses, TotalStudents, etc.)
   - Display statistics
   - Call `ServiceRegistry.Courses.GetDataSet("List", ...)`
   - Bind recent courses to DataGrid
   - Limit: 6 courses

**Displayed Metrics:**
- TotalCourses
- TotalStudents
- TotalLessons
- AverageScore
- QualityAverageScore
- TotalVideos
- TotalQuestions
- TotalTeachers
- CompletionRate (with progress bar)

**GridView Configuration:**
- Control: DataGrid (GridView)
- Paging: Not shown (limit to 6 items)
- Sorting: Unknown
- AutoPostBack: Unknown

**Refresh Action:**
- Button: RefreshButton
- Event: RefreshButton_Click
- Action: Reload dashboard data

**Error Handling:**
- Try-catch around data loading
- Display error message in ErrorText label
- Log error via WebLog.Error()

**Expected Results:**
- Dashboard loads with statistics
- Recent courses displayed
- No JavaScript errors
- No HTTP errors

**Error Conditions:**
- Service failure → "Không thể nạp số liệu dashboard."
- Database error → Logged, error message displayed

**Dependencies:**
- ServiceRegistry.Reports
- ServiceRegistry.Courses
- UserSession.Current (for ActorID and IsAdmin)

**PostBack Type:**
- Full PostBack (RefreshButton_Click)

**UpdatePanel:**
- Unknown (need to inspect)

---

## 3. CMS Course Management Flow

### 3.1 Course List Flow

**Entry Point:** `/cms/courses` → `Pages/Cms/Courses.aspx`

**Preconditions:**
- User is authenticated
- User is NOT student
- User has course management permission

**Page Title:** "Soạn nội dung môn học lớp"
**Page Description:** "Chọn đúng năm học, lớp và môn đã được phân công để xây dựng chương, bài học và bài tập."

**Filters:**
| Filter | Type | Options | Default |
|--------|------|---------|---------|
| Search | TextBox | Free text | Empty |
| Year | DropDownList | Dynamic from DB | "Tất cả năm học" |
| Semester | DropDownList | 1, 2, 3 (Học kỳ hè) | "Tất cả học kỳ" |
| Course Status | DropDownList | EMPTY, DRAFT, PUBLISHED, ARCHIVED | "Tất cả trạng thái" |

**Data Loading:**
1. Page_Load fires
2. If !IsPostBack:
   - Call `ServiceRegistry.Academic.GetDataSet("GetCatalog", ...)`
   - Extract years from DataTable[1]
   - Extract offerings from DataTable[8]
   - Bind years to YearFilterList
   - Filter offerings based on selected filters
   - Bind to DataGrid

**GridView Configuration:**
- Control: DataGrid (GridView)
- AutoGenerateColumns: false
- AllowPaging: true
- PageSize: 20
- Events:
  - OnPageIndexChanging: DataGrid_PageIndexChanging
  - OnRowCreated: DataGrid_RowCreated
  - OnRowCommand: DataGrid_RowCommand

**Columns:**
1. Year/Semester (TemplateField)
2. Class/Subject (TemplateField with icon)
3. Teacher Name (BoundField)
4. Content Status (TemplateField with badge)
5. Student Count (TemplateField)
6. Actions (TemplateField with buttons)

**Row Commands:**
- `OpenSettings` - Open course settings modal
- `EnsureWorkspace` - Create new course workspace

**Search/Filter Flow:**
1. User enters/selects filter values
2. Click "Áp dụng bộ lọc" button
3. SearchButton_Click fires
4. Reload data with filters
5. FilterOfferings() applies:
   - Year filter
   - Semester filter
   - Status filter
   - Search text (SubjectName, SubjectID, ClassName, TeacherName)
6. Bind filtered data to DataGrid

**Expected Results:**
- DataGrid displays filtered course list
- Pagination works (20 items per page)
- Search text matches subject/class/teacher
- Filters apply correctly

**Error Conditions:**
- Service failure → Display error in ErrorText
- No results → Display "Không có môn học lớp phù hợp bộ lọc."

**Dependencies:**
- ServiceRegistry.Academic
- ServiceRegistry.Courses
- UserSession.Current

**PostBack Type:**
- Search/Filter: Full PostBack
- Settings modal: Partial PostBack (UpdatePanel)

**UpdatePanel:**
- ID: CourseSettingsUpdatePanel
- UpdateMode: Conditional
- ChildrenAsTriggers: true
- Trigger: PostBackTrigger for CourseSettingsSaveButton

---

### 3.2 Course Settings Modal Flow

**Trigger:**
- User clicks "Thiết lập" button in GridView row
- CommandName: "OpenSettings"
- CommandArgument: OnlineCourseID

**Flow Steps:**
1. DataGrid_RowCommand fires
2. Parse courseId from CommandArgument
3. Call LoadCourseSettings(courseId)
4. Call ServiceRegistry.Courses.GetDataTable("Get", ...)
5. Populate modal fields:
   - ShortDescription
   - PassingScore
   - Status (DRAFT/PUBLISHED/ARCHIVED)
   - Hidden fields for other properties
6. CourseSettingsUpdatePanel.Update()
7. Show modal via JavaScript (hidden="hidden" removed)

**Modal Fields:**
| Field | Type | Validation | Notes |
|-------|------|------------|-------|
| ShortDescription | TextBox (MultiLine) | None | 3 rows |
| PassingScore | TextBox | Numeric, 0-100 | Decimal |
| Status | DropDownList | DRAFT/PUBLISHED/ARCHIVED | Required |

**Save Flow:**
1. User modifies fields
2. Click "Lưu thiết lập" button
3. CourseSettingsSaveButton_Click fires
4. Validate:
   - CourseSettingsIdValue must be valid long > 0
   - CourseSettingsTeacherIdValue must be valid long > 0
   - PassingScore must be decimal 0-100
5. If validation fails:
   - Show error message
   - Keep modal open
6. If validation passes:
   - Call ServiceRegistry.Courses.GetDataTable("Update", ...)
   - Parameters: Id, Code, Title, Slug, ThumbnailUrl, ShortDescription, Description, TeacherId, CategoryId, ClassSubjectId, Level, PassingScore, Status, ActorId, IsAdmin
   - Check result (first column value > 0)
   - If success:
     - Show success message
     - Close modal
     - Reload data
   - If failure:
     - Show error message
     - Keep modal open

**Expected Results:**
- Modal opens with current course data
- Fields populate correctly
- Save updates course in database
- Success/failure message displayed
- Modal closes on success

**Error Conditions:**
- Invalid courseId → "Không tìm thấy môn học lớp."
- Validation failure → "Thiết lập môn học không hợp lệ."
- Service failure → Error message from exception

**Dependencies:**
- ServiceRegistry.Courses
- Hidden fields for state management

**PostBack Type:**
- Partial PostBack (UpdatePanel)

---

### 3.3 Ensure Workspace Flow (Create Course)

**Trigger:**
- User clicks "Khởi tạo nội dung" button
- CommandName: "EnsureWorkspace"
- CommandArgument: ClassSubjectID

**Flow Steps:**
1. DataGrid_RowCommand fires
2. Parse classSubjectId from CommandArgument
3. Call ServiceRegistry.Academic.GetDataTable("EnsureWorkspace", ...)
4. Parameters: ClassSubjectID, ActorID, IsAdmin
5. Check result (Rows.Count > 0)
6. If success:
   - Show "Đã khởi tạo nội dung môn học lớp."
   - Reload data
7. If failure:
   - Show "Không thể khởi tạo nội dung môn học lớp."

**Expected Results:**
- New course workspace created
- Course appears in list with "Bản nháp" status
- "Soạn bài" button becomes available

**Error Conditions:**
- Service failure → Error message displayed
- Permission denied → Service should return error

**Dependencies:**
- ServiceRegistry.Academic

**PostBack Type:**
- Full PostBack (via GridView RowCommand)

---

## 4. Authorization Matrix

### 4.1 Role-Based Access Control

| Role | CMS Access | LMS Access | Notes |
|------|------------|------------|-------|
| Admin | Yes | Yes | Full access, admin menu visible |
| Teacher | Yes | Yes | Limited CMS access (inferred) |
| Student | No | Yes | LMS only, no CMS |

### 4.2 Page Access Rules

| Path | Admin | Teacher | Student | Guest | Enforcement |
|------|-------|---------|---------|-------|-------------|
| /login | Yes | Yes | Yes | Yes | Open |
| /logout | Yes | Yes | Yes | No | Auth required |
| /cms/dashboard | Yes | Yes | No | No | Code-based |
| /cms/courses | Yes | Yes | No | No | Code-based |
| /cms/* | Yes | Yes | No | No | Code-based |
| /lms/dashboard | Yes | Yes | Yes | No | Code-based |
| /lms/* | Yes | Yes | Yes | No | Code-based |
| /error | Yes | Yes | Yes | Yes | Open |
| /403 | Yes | Yes | Yes | Yes | Open |
| /404 | Yes | Yes | Yes | Yes | Open |

**Enforcement Mechanism:**
- Web.config: Allow all users (no deny rules)
- Code-based: Login.ascx.cs RedirectByRole()
- Master page: Cms.Master.cs AdminMenu.Visible = IsAdmin

**Unknown Items:**
- Teacher-specific permissions in CMS
- Student-specific restrictions in LMS
- Permission granularity within modules

---

## 5. LMS Module Flow (Preliminary)

### 5.1 LMS Dashboard Flow

**Entry Point:** `/lms/dashboard` → `Pages/Lms/Dashboard.aspx`

**Preconditions:**
- User is authenticated
- User.IsStudent = true (or allowed role)

**Authorization:**
- Students, Teachers, Admins allowed
- Redirect from login for students

**Expected Features (inferred):**
- Enrolled courses list
- Progress tracking
- Recent activity
- Upcoming lessons/assignments

**Status:** UNKNOWN - Need to analyze LMS/Dashboard.ascx.cs

---

## 6. ViewState Analysis

### 6.1 ViewState Usage by Module

| Module | ViewState Usage | Notes |
|--------|-----------------|-------|
| Login | Minimal | Simple form, no complex state |
| CMS Dashboard | Moderate | Dashboard statistics, filters |
| CMS Courses | High | Grid data, modal state, hidden fields |
| LMS Dashboard | UNKNOWN | To be analyzed |

### 6.2 ViewState Implications for Testing
- ViewState maintains form state across PostBack
- Test must account for ViewState persistence
- Hidden fields used for state management (e.g., CourseSettingsIdValue)
- ClientIDMode="AutoID" makes ViewState ID detection difficult

---

## 7. UpdatePanel / AJAX Analysis

### 7.1 Identified UpdatePanels

| Module | UpdatePanel ID | Triggers | Purpose |
|--------|----------------|----------|---------|
| CMS Courses | CourseSettingsUpdatePanel | CourseSettingsSaveButton (PostBackTrigger) | Modal settings form |

### 7.2 AJAX Behavior
- Partial PostBack for modal operations
- Full PostBack for main grid operations
- ScriptManager.RegisterAsyncPostBackControl for GridView buttons

**Testing Implications:**
- Modal operations require waiting for UpdatePanel update
- Main operations require full page load
- Network idle detection may differ

---

## 8. GridView Analysis

### 8.1 GridView Configurations

| Module | GridView ID | Paging | Sorting | RowCommand | PageSize |
|--------|--------------|---------|---------|------------|----------|
| CMS Dashboard | DataGrid | No | Unknown | No | 6 (fixed) |
| CMS Courses | DataGrid | Yes | Unknown | Yes | 20 |

### 8.2 GridView Events
- **PageIndexChanging:** Handle pagination
- **RowCreated:** Register async postback controls
- **RowCommand:** Handle button clicks within rows

**Testing Implications:**
- Pagination must be tested
- Row commands must be tested
- Sorting (if implemented) must be tested

---

## 9. Validation Analysis

### 9.1 Server-Side Validation

| Module | Validators | ValidationGroup |
|--------|------------|-----------------|
| Login | RequiredFieldValidator (x2), ValidationSummary | Login |
| CMS Courses | None in ASCX (manual validation in code-behind) | N/A |

### 9.2 Manual Validation (Code-Behind)

**CMS Courses.ascx.cs:**
- CourseSettingsSaveButton_Click:
  - ID validation (long > 0)
  - Teacher ID validation (long > 0)
  - Passing Score validation (decimal 0-100)

**Testing Implications:**
- Must test both validator-based and manual validation
- ValidationSummary displays aggregated errors
- Manual validation shows custom error messages

---

## 10. Error Handling Analysis

### 10.1 Error Display Patterns

| Module | Error Control | Error Message Pattern |
|--------|---------------|----------------------|
| Login | MessageText (Label) | Server.HtmlEncode(message) |
| CMS Dashboard | ErrorText (Label) | "Không thể nạp số liệu dashboard." |
| CMS Courses | ErrorText (Label), ActionMessageText (Label) | Custom messages from service/exception |

### 10.2 Exception Handling Pattern
```csharp
try {
    // Service call
}
catch (Exception ex) {
    WebLog.Error("Context message", ex);
    // Display error to user
}
```

**Testing Implications:**
- Error messages are user-friendly (not technical)
- Errors are logged via WebLog
- Errors are HTML-encoded before display

---

## 11. JavaScript Dependencies

### 11.1 Known JavaScript Files

| File | Purpose | Location |
|------|---------|----------|
| app.js | Main application logic | assets/lms/js/ |
| course-management-webforms.js | Course-specific logic | assets/lms/js/ |

### 11.2 JavaScript Features (Inferred)
- Password toggle (data-password-toggle)
- Demo account auto-fill (data-demo-login)
- Modal open/close (data-course-settings-close)
- Form handling

**Testing Implications:**
- Must wait for JavaScript to load
- May need to interact with JavaScript-driven elements
- Console should be checked for JS errors

---

## 12. Database Dependencies

### 12.1 Known Service Operations

| Service | Operation | Purpose |
|---------|-----------|---------|
| Auth | Login | Authenticate user |
| Auth | GetById | Get user by ID |
| Reports | Dashboard | Get dashboard statistics |
| Courses | List | List courses |
| Courses | Get | Get course by ID |
| Courses | Update | Update course |
| Academic | GetCatalog | Get academic catalog |
| Academic | EnsureWorkspace | Create course workspace |
| Notifications | List | Get notifications |

### 12.2 Database Tables (Inferred)

| Table | Purpose |
|-------|---------|
| SYS_Users | User accounts |
| Courses / OnlineCourses | Course data |
| ClassSubjects | Class-subject mapping |
| Years | Academic years |
| Subjects | Subject data |
| Classes | Class data |
| Chapters | Course chapters |
| Lessons | Course lessons |
| Enrollments | Student enrollments |
| Notifications | Notification data |

**Status:** UNKNOWN - Need database access to verify schema

---

## 13. Session Management Analysis

### 13.1 Session Keys

| Key | Type | Purpose |
|-----|------|---------|
| LMS.CURRENT_USER | SYS_Users object | Current authenticated user |

### 13.2 Session Lifecycle
- **Login:** Session cleared, abandoned, new session created
- **Logout:** Session cleared, abandoned
- **Timeout:** 120 minutes (InProc mode)
- **Access:** UserSession.Current property retrieves from session

**Testing Implications:**
- Session timeout must be tested
- Session state affects authorization
- May need to re-login after timeout

---

## 14. URL Routing Analysis

### 14.1 Known Virtual Paths

| Virtual Path | Physical Path | Purpose |
|---------------|---------------|---------|
| /login | Pages/Auth/Login.aspx | Login page |
| /logout | Pages/Auth/Logout.aspx | Logout page |
| /cms/dashboard | Pages/Cms/Dashboard.aspx | CMS dashboard |
| /cms/courses | Pages/Cms/Courses.aspx | Course management |
| /cms/courses/{id}/content | UNKNOWN | Course content editor |
| /lms/dashboard | Pages/Lms/Dashboard.aspx | LMS dashboard |
| /error | Pages/Errors/Error.aspx | Error page |
| /403 | Pages/Errors/Forbidden.aspx | 403 page |
| /404 | Pages/Errors/NotFound.aspx | 404 page |

### 14.2 URL Rewriting
- Library: UrlRewritingNet.UrlRewriter
- Config: urlrewrite.config (separate file)
- Pattern: UNKNOWN - Need to inspect config file

**Testing Implications:**
- Tests should use virtual paths, not physical paths
- Return URL validation checks for virtual path format

---

## 15. Unknown Items Requiring Further Investigation

| Item | Module | Priority | Notes |
|------|--------|----------|-------|
| LMS Dashboard flow | LMS | High | Not yet analyzed |
| LMS Course view flow | LMS | High | Not yet analyzed |
| LMS Lesson Player flow | LMS | High | Not yet analyzed |
| User Management flow | CMS | High | Not yet analyzed |
| Student Management flow | CMS | High | Not yet analyzed |
| Role Management flow | CMS | Medium | Not yet analyzed |
| Quiz Management flow | CMS | High | Not yet analyzed |
| Video Management flow | CMS | Medium | Not yet analyzed |
| Content Builder flow | CMS | High | Not yet analyzed |
| Profile Management flow | LMS | Medium | Not yet analyzed |
| Results viewing flow | LMS | Medium | Not yet analyzed |
| UpdatePanel usage in other modules | All | Medium | Only Courses analyzed |
| GridView sorting | All | Medium | Not yet confirmed |
| Password policy | Auth | High | Not yet known |
| File upload flows | CMS/LMS | Medium | Video/file uploads |
| Database schema | All | High | Need access |
| Stored procedures | All | High | Need access |
| CSRF token implementation | All | High | Not yet found |
| Teacher-specific permissions | CMS | Medium | Inferred only |

---

## 16. Test Strategy Implications

### 16.1 Selector Strategy
Based on analysis:
- Use name attributes with pattern matching: `input[name*="Username"]`
- Use CSS classes: `.form-control`, `.login-button`
- Use text content: `getByText('Đăng nhập')`
- Use data attributes: `[data-demo-login="student"]`
- Use hierarchical selectors: `.field-group > input`
- **Avoid:** Direct ID selectors

### 16.2 PostBack Handling
- **Full PostBack:** Wait for `page.waitForLoadState('networkidle')`
- **Partial PostBack (UpdatePanel):** Wait for element update or response
- **GridView PostBack:** Wait for grid refresh

### 16.3 Modal Handling
- Modal visibility controlled by `hidden` attribute
- JavaScript triggers modal open/close
- Must wait for modal to appear/disappear

### 16.4 Data-Driven Testing
- Filters can be tested with various combinations
- Year, Semester, Status filters have known values
- Search text can test various patterns

### 16.5 Authorization Testing
- Test login with each role
- Verify redirect to correct dashboard
- Test direct URL access with wrong role
- Test menu visibility by role

---

## 17. Next Steps (Phase 03)

1. **Complete business flow analysis** for remaining modules:
   - LMS Dashboard, Courses, LessonPlayer, Profile, Results
   - CMS Users, Students, Roles, QuizManagement
   - ContentBuilder, VideoLibrary

2. **Analyze remaining ASCX.cs files** for:
   - Event handlers
   - Validation rules
   - Service calls
   - Error handling

3. **Inspect database schema** (if access granted):
   - Table structures
   - Stored procedures
   - Constraints

4. **Generate test cases** based on business flows:
   - Functional tests
   - Validation tests
   - CRUD tests
   - Authorization tests
   - PostBack tests

---

**End of Phase 02: Business Flow Analysis (Partial)**
**Status:** Authentication, CMS Dashboard, CMS Courses analyzed
**Remaining:** LMS modules, other CMS modules
**Next Phase:** Phase 03 - Test Case Generation
