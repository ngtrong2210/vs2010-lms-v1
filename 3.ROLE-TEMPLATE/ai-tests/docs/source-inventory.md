# Source Inventory - LMS Web Forms Project
## Phase 01: Source Discovery

**Project:** LMS (Learning Management System) - ASP.NET Web Forms
**Framework:** .NET Framework 4.0
**Database:** SQL Server (LMSCMS_DB)
**Discovery Date:** 2026-10-22
**Discovery Status:** COMPLETED

---

## 1. Project Information

### 1.1 Basic Configuration
- **Target Framework:** .NET Framework 4.0
- **Project Type:** ASP.NET Web Forms Application
- **Language:** C#
- **Database:** SQL Server (SQLEXPRESS)
- **Database Name:** LMSCMS_DB
- **Authentication Mode:** Forms Authentication
- **Session Mode:** InProc
- **Session Timeout:** 120 minutes
- **ClientID Mode:** AutoID (dynamic IDs)

### 1.2 Connection String
```
Data Source=DESKTOP-PBMQQ03\SQLEXPRESS
Initial Catalog=LMSCMS_DB
User ID=sa
Password=nQY3n9EGcjT#pju
TrustServerCertificate=True
```

### 1.3 Key Web.config Settings
- **Authentication:** Forms Authentication
  - Cookie Name: `.THIENHASO.AUTH`
  - Login URL: `~/login`
  - Default URL: `~/lms/dashboard`
  - Timeout: 120 minutes
  - Sliding Expiration: true
- **Authorization:** Allow all users (role-based enforced in code)
- **Request Validation:** Enabled (mode="2.0")
- **ViewState:** Enabled (default)
- **Event Validation:** Enabled
- **HTTP Cookies:** HttpOnly enabled, SSL not required (requireSSL="false")
- **Custom Errors:** RemoteOnly
  - 403 → ~/403
  - 404 → ~/404
- **Security Headers:**
  - X-Content-Type-Options: nosniff
  - X-Frame-Options: SAMEORIGIN
  - Referrer-Policy: strict-origin-when-cross-origin

### 1.4 URL Rewriting
- **Library:** UrlRewritingNet.UrlRewriter
- **Config File:** urlrewrite.config
- **Purpose:** Friendly URL routing

---

## 2. File Inventory

### 2.1 ASPX Pages (33 files)

#### 2.1.1 Authentication Module (Pages/Auth)
| File | Path | Description |
|------|------|-------------|
| Login.aspx | Pages/Auth/Login.aspx | Login page (uses Login.ascx) |
| Logout.aspx | Pages/Auth/Logout.aspx | Logout page (uses Logout.ascx) |

#### 2.1.2 CMS Module (Pages/Cms) - 19 files
| File | Path | Description |
|------|------|-------------|
| Dashboard.aspx | Pages/Cms/Dashboard.aspx | Admin dashboard (uses Dashboard.ascx) |
| Courses.aspx | Pages/Cms/Courses.aspx | Course management (uses Courses.ascx) |
| Users.aspx | Pages/Cms/Users.aspx | User management (uses Users.ascx) |
| Students.aspx | Pages/Cms/Students.aspx | Student management (uses Students.ascx) |
| Roles.aspx | Pages/Cms/Roles.aspx | Role management (uses Roles.ascx) |
| Reports.aspx | Pages/Cms/Reports.aspx | Reports (uses Reports.ascx) |
| Questions.aspx | Pages/Cms/Questions.aspx | Question bank (uses Questions.ascx) |
| AssignmentGrading.aspx | Pages/Cms/AssignmentGrading.aspx | Assignment grading (uses AssignmentGrading.ascx) |
| ContentBuilder.aspx | Pages/Cms/ContentBuilder.aspx | Content builder (uses ContentBuilder.ascx) |
| VideoEditor.aspx | Pages/Cms/VideoEditor.aspx | Video editor (uses VideoEditor.ascx) |
| VideoLibrary.aspx | Pages/Cms/VideoLibrary.aspx | Video library (uses VideoLibrary.ascx) |
| AcademicStructure.aspx | Pages/Cms/AcademicStructure.aspx | Academic structure (uses AcademicStructure.ascx) |
| CourseCategories.aspx | Pages/Cms/CourseCategories.aspx | Course categories (uses CourseCategories.ascx) |
| CourseLibrary.aspx | Pages/Cms/CourseLibrary.aspx | Course library (uses CourseLibrary.ascx) |
| CourseEnrollments.aspx | Pages/Cms/CourseEnrollments.aspx | Course enrollments (uses CourseEnrollments.ascx) |
| CourseProgress.aspx | Pages/Cms/CourseProgress.aspx | Course progress (uses CourseProgress.ascx) |
| QuizManagement.aspx | Pages/Cms/QuizManagement.aspx | Quiz management (uses QuizManagement.ascx) |
| Settings.aspx | Pages/Cms/Settings.aspx | System settings (uses Settings.ascx) |
| Help.aspx | Pages/Cms/Help.aspx | Help page (uses Help.ascx) |
| Search.aspx | Pages/Cms/Search.aspx | Search (uses Search.ascx) |
| InteractiveContentTest.aspx | Pages/Cms/InteractiveContentTest.aspx | Interactive content test |

#### 2.1.3 LMS Module (Pages/Lms) - 6 files
| File | Path | Description |
|------|------|-------------|
| Dashboard.aspx | Pages/Lms/Dashboard.aspx | Student dashboard (uses Dashboard.ascx) |
| Courses.aspx | Pages/Lms/Courses.aspx | Student course list (uses Courses.ascx) |
| Course.aspx | Pages/Lms/Course.aspx | Course detail (uses Course.ascx) |
| LessonPlayer.aspx | Pages/Lms/LessonPlayer.aspx | Lesson player (uses LessonPlayer.ascx) |
| Profile.aspx | Pages/Lms/Profile.aspx | User profile (uses Profile.ascx) |
| Results.aspx | Pages/Lms/Results.aspx | Test results (uses Results.ascx) |

#### 2.1.4 Error Pages (Pages/Errors) - 3 files
| File | Path | Description |
|------|------|-------------|
| Error.aspx | Pages/Errors/Error.aspx | General error page (uses Error.ascx) |
| Forbidden.aspx | Pages/Errors/Forbidden.aspx | 403 Forbidden (uses Forbidden.ascx) |
| NotFound.aspx | Pages/Errors/NotFound.aspx | 404 Not Found (uses NotFound.ascx) |

#### 2.1.5 Root
| File | Path | Description |
|------|------|-------------|
| Default.aspx | Default.aspx | Default landing page |

### 2.2 ASCX User Controls (31 files)

#### 2.2.1 Authentication Controls (Controls/Auth)
| File | Path | Description |
|------|------|-------------|
| Login.ascx | Controls/Auth/Login.ascx | Login control with username/password fields |
| Logout.ascx | Controls/Auth/Logout.ascx | Logout control |

#### 2.2.2 CMS Controls (Controls/Cms) - 19 files
| File | Path | Description |
|------|------|-------------|
| Dashboard.ascx | Controls/Cms/Dashboard.ascx | Admin dashboard with statistics |
| Courses.ascx | Controls/Cms/Courses.ascx | Course CRUD operations |
| Users.ascx | Controls/Cms/Users.ascx | User CRUD operations |
| Students.ascx | Controls/Cms/Students.ascx | Student CRUD operations |
| Roles.ascx | Controls/Cms/Roles.ascx | Role management |
| Reports.ascx | Controls/Cms/Reports.ascx | Reports viewer |
| Questions.ascx | Controls/Cms/Questions.ascx | Question bank management |
| AssignmentGrading.ascx | Controls/Cms/AssignmentGrading.ascx | Assignment grading |
| ContentBuilder.ascx | Controls/Cms/ContentBuilder.ascx | Content builder |
| VideoEditor.ascx | Controls/Cms/VideoEditor.ascx | Video editor |
| VideoLibrary.ascx | Controls/Cms/VideoLibrary.ascx | Video library |
| AcademicStructure.ascx | Controls/Cms/AcademicStructure.ascx | Academic structure |
| CourseCategories.ascx | Controls/Cms/CourseCategories.ascx | Course categories |
| CourseLibrary.ascx | Controls/Cms/CourseLibrary.ascx | Course library |
| CourseEnrollments.ascx | Controls/Cms/CourseEnrollments.ascx | Course enrollments |
| CourseProgress.ascx | Controls/Cms/CourseProgress.ascx | Course progress tracking |
| QuizManagement.ascx | Controls/Cms/QuizManagement.ascx | Quiz management |
| Settings.ascx | Controls/Cms/Settings.ascx | System settings |
| Help.ascx | Controls/Cms/Help.ascx | Help content |
| Search.ascx | Controls/Cms/Search.ascx | Search functionality |

#### 2.2.3 LMS Controls (Controls/Lms) - 5 files
| File | Path | Description |
|------|------|-------------|
| Dashboard.ascx | Controls/Lms/Dashboard.ascx | Student dashboard |
| Courses.ascx | Controls/Lms/Courses.ascx | Student course list |
| Course.ascx | Controls/Lms/Course.ascx | Course detail view |
| LessonPlayer.ascx | Controls/Lms/LessonPlayer.ascx | Lesson/video player |
| Profile.ascx | Controls/Lms/Profile.ascx | User profile management |
| Results.ascx | Controls/Lms/Results.ascx | Test results display |

#### 2.2.4 Error Controls (Controls/Errors) - 3 files
| File | Path | Description |
|------|------|-------------|
| Error.ascx | Controls/Errors/Error.ascx | General error display |
| Forbidden.ascx | Controls/Errors/Forbidden.ascx | 403 Forbidden display |
| NotFound.ascx | Controls/Errors/NotFound.ascx | 404 Not Found display |

### 2.3 Master Pages (2 files)
| File | Path | Description |
|------|------|-------------|
| Cms.Master | MasterPages/Cms.Master | CMS master page with admin menu |
| Lms.Master | MasterPages/Lms.Master | LMS master page for students/instructors |

### 2.4 Infrastructure Files (7 files)
| File | Path | Description |
|------|------|-------------|
| WebLog.cs | LmsInfrastructure/WebLog.cs | Logging utility |
| WebData.cs | LmsInfrastructure/WebData.cs | Data binding utilities |
| UserSession.cs | LmsInfrastructure/UserSession.cs | Session management |
| CmsStorePage.cs | LmsInfrastructure/CmsStorePage.cs | CMS page base class |
| StudentStorePage.cs | LmsInfrastructure/StudentStorePage.cs | Student page base class |
| PageBases.cs | LmsInfrastructure/PageBases.cs | Page base classes |
| LmsRouteConfig.cs | LmsInfrastructure/LmsRouteConfig.cs | Routing configuration |

---

## 3. Authentication & Authorization Analysis

### 3.1 Authentication Mechanism
- **Type:** Forms Authentication
- **Cookie:** `.THIENHASO.AUTH`
- **Login Service:** `ServiceRegistry.Auth.Login(username, password, out message)`
- **User Object:** `SYS_Users` (from LmsObject namespace)
- **Session Key:** `"LMS.CURRENT_USER"`
- **Session Storage:** InProc

### 3.2 User Roles (Inferred from code)
Based on `UserSession.cs` and `Login.ascx.cs`:
- **Admin:** Full access to CMS
- **Student:** Access to LMS only
- **Teacher/Instructor:** (inferred from demo accounts)

**Role Detection Logic:**
```csharp
user.IsStudent  // Boolean property in SYS_Users
user.IsAdmin    // Boolean property in SYS_Users
user.Role       // String property in SYS_Users
```

### 3.3 Authorization Rules
**From Login.ascx.cs - RedirectByRole():**
- Students → `~/lms/dashboard`
- Non-students (Admin/Teacher) → `~/cms/dashboard`

**From Cms.Master.cs:**
- `AdminMenu.Visible = UserSession.Current.IsAdmin`
- Only admins see admin menu items

**From Web.config Location Paths:**
- `/Pages/Auth` - Allow all users
- `/Pages/Lms` - No explicit restriction (enforced in code)
- `/Pages/Cms` - No explicit restriction (enforced in code)
- `/Pages/Errors` - No explicit restriction

### 3.4 Demo Test Accounts (from Login.ascx)
| Role | Username | Password |
|------|----------|----------|
| Student | student | 123456 |
| Teacher | teacher | 123456 |
| Admin | admin | 123456 |

> **Note:** These are demo accounts visible in the UI. Should verify if they exist in database.

---

## 4. ASP.NET Web Forms Features Analysis

### 4.1 PostBack Mechanism
- **Standard PostBack:** Used in most forms (Button Click events)
- **PostBack Detection:** `if (!IsPostBack)` pattern in Page_Load
- **ViewState:** Enabled by default

### 4.2 ClientID Mode
- **Setting:** `clientIDMode="AutoID"` in Web.config
- **Impact:** Controls have dynamic IDs like `ctl00$MainContent$UsernameText`
- **Testing Challenge:** Cannot rely on stable IDs for selectors

### 4.3 Validation Controls
**From Login.ascx:**
- `RequiredFieldValidator` for username
- `RequiredFieldValidator` for password
- `ValidationSummary` for displaying all errors
- `ValidationGroup="Login"` for grouping

### 4.4 GridView Usage
**From Dashboard.ascx.cs:**
- `DataGrid` control for displaying course list
- Paging support (inferred from Page/PageSize parameters)
- Sorting support (likely implemented)

### 4.5 Session Management
- **Mode:** InProc
- **Timeout:** 120 minutes
- **Storage:** Session["LMS.CURRENT_USER"] = SYS_Users object
- **Session Clear:** Called on login (clear previous) and logout

### 4.6 UpdatePanel / AJAX
- **Status:** UNKNOWN - Need to inspect individual ASCX files
- **Library:** System.Web.Extensions referenced in Web.config
- **ScriptModule:** Registered in httpModules

---

## 5. Business Logic Layer

### 5.1 Service Registry
**Namespace:** `LmsService`
**Pattern:** Service Registry pattern with GetDataTable/GetDataSet methods

**Known Services:**
- `ServiceRegistry.Auth` - Authentication service
- `ServiceRegistry.Reports` - Reports service
- `ServiceRegistry.Courses` - Course service
- `ServiceRegistry.Notifications` - Notification service

**Service Method Pattern:**
```csharp
ServiceRegistry.{ServiceName}.GetDataTable("OperationName", Values("Param1", value1, "Param2", value2))
ServiceRegistry.{ServiceName}.GetDataSet("OperationName", Values(...))
```

### 5.2 Data Access Layer
**Namespace:** `LmsObject`
**Known Objects:**
- `SYS_Users` - User entity

**Database:** SQL Server with stored procedures (inferred from service pattern)

### 5.3 Helper Classes
**WebData.cs:**
- `WebData.Text(row, "ColumnName")` - Safe data extraction
- `WebData.Bind(control, dataTable, emptyText, errorText)` - Data binding

**WebLog.cs:**
- `WebLog.Error(message, exception)` - Error logging

---

## 6. JavaScript & Client-Side Analysis

### 6.1 JavaScript Files (from ASCX references)
- `app.js?v=20260901-ui6` - Main application script
- Likely contains:
  - Password toggle functionality
  - Demo account auto-fill
  - Form validation helpers
  - AJAX handling

### 6.2 Client-Side Validation
- **ASP.NET Validation:** Server-side validators with client-side scripts
- **Custom Validation:** Password toggle button (data-password-toggle)
- **Demo Account Fill:** JavaScript buttons with data-demo-login attribute

### 6.3 CSS Frameworks
- Bootstrap (CSS framework)
- Bootstrap Icons
- Custom LMS CSS files

---

## 7. URL Routing Analysis

### 7.1 URL Rewriting
- **Library:** UrlRewritingNet.UrlRewriter
- **Config:** urlrewrite.config (separate file)
- **Purpose:** Friendly URLs

### 7.2 Known Routes (from Web.config)
- `/login` → Pages/Auth/Login.aspx
- `/lms/dashboard` → Pages/Lms/Dashboard.aspx
- `/cms/dashboard` → Pages/Cms/Dashboard.aspx
- `/error` → Pages/Errors/Error.aspx
- `/403` → Pages/Errors/Forbidden.aspx
- `/404` → Pages/Errors/NotFound.aspx

### 7.3 Physical vs Virtual Paths
- **Physical:** `/Pages/...` (blocked for return URL)
- **Virtual:** `/cms/...`, `/lms/...` (friendly URLs)

---

## 8. Security Analysis

### 8.1 Input Validation
- **Request Validation:** Enabled (mode="2.0")
- **Server-Side Validation:** RequiredFieldValidator controls
- **HTML Encoding:** `Server.HtmlEncode()` used for output

### 8.2 Authentication Security
- **Password:** TextMode="Password" (masked input)
- **Remember Me:** Persistent cookie option
- **Session:** Abandoned on login (clear previous session)
- **Return URL:** Validated to prevent open redirect (IsLocalUrl check)

### 8.3 Cookie Security
- **HttpOnly:** Enabled
- **Secure:** Only on HTTPS connections (currently false)
- **SameSite:** Not explicitly set (browser default)

### 8.4 CSRF Protection
- **Status:** UNKNOWN - Need to check for anti-forgery tokens
- **ViewState MAC:** Likely enabled (default)

### 8.5 Security Headers
- X-Content-Type-Options: nosniff
- X-Frame-Options: SAMEORIGIN
- Referrer-Policy: strict-origin-when-cross-origin

### 8.6 Known Vulnerabilities / Risks
1. **SSL Not Required:** requireSSL="false" in httpCookies
2. **Debug Mode:** debug="true" in compilation (should be false in production)
3. **SQL Connection:** Credentials in Web.config (should use encrypted config)
4. **ClientID AutoID:** Makes automation testing harder
5. **Request Validation Mode="2.0":** Allows some HTML content (potential XSS risk)

---

## 9. Database Analysis

### 9.1 Database Connection
- **Server:** DESKTOP-PBMQQ03\SQLEXPRESS
- **Database:** LMSCMS_DB
- **Authentication:** SQL Server (sa account)
- **Status:** LOCAL DEVELOPMENT INSTANCE

### 9.2 Known Tables (Inferred)
- **SYS_Users** - User accounts
- **Courses** - Course data
- **Enrollments** - Student enrollments
- **Lessons** - Lesson content
- **Questions** - Question bank
- **Quiz** - Quiz data
- **Notifications** - Notification system

### 9.3 Stored Procedures (Inferred)
Based on service pattern:
- Auth_Login
- Reports_Dashboard
- Courses_List
- Notifications_List

**Status:** UNKNOWN - Need database access to verify

---

## 10. Module Structure Summary

### 10.1 Authentication Module
**Pages:** Login, Logout
**Controls:** Login, Logout
**Entry Point:** /login
**Default Redirect:**
- Students → /lms/dashboard
- Admin/Teacher → /cms/dashboard

### 10.2 CMS Module (Admin)
**Pages:** 19 pages
**Master Page:** Cms.Master
**Entry Point:** /cms/dashboard
**Features:**
- Dashboard with statistics
- Course management
- User management
- Student management
- Role management
- Reports
- Quiz management
- Video management
- Content builder
- Settings

### 10.3 LMS Module (Student/Instructor)
**Pages:** 6 pages
**Master Page:** Lms.Master
**Entry Point:** /lms/dashboard
**Features:**
- Student dashboard
- Course browsing
- Lesson player
- Profile management
- Results viewing

### 10.4 Error Handling Module
**Pages:** Error, Forbidden, NotFound
**Master Page:** None (standalone)
**Entry Points:** /error, /403, /404

---

## 11. Test Automation Considerations

### 11.1 Selector Strategy
**Challenge:** Dynamic ClientIDs (AutoID mode)

**Recommended Selectors:**
1. **Name attribute:** `input[name*="Username"]` (pattern matching)
2. **CSS class:** `.form-control`, `.login-button`
3. **Text content:** `getByText('Đăng nhập')`
4. **ARIA labels:** `[aria-label="..."]`
5. **Data attributes:** `[data-demo-login="student"]`
6. **Parent-child relationships:** `.field-group > input`

**Avoid:**
- Direct ID selectors like `#ctl00_MainContent_UsernameText`

### 11.2 PostBack Handling
**Full PostBack:**
- Wait for navigation: `page.waitForLoadState('networkidle')`
- Wait for URL change
- Wait for specific element to appear/disappear

**Partial PostBack (UpdatePanel):**
- Wait for AJAX response: `page.waitForResponse()`
- Wait for element update: `page.waitForSelector()`
- Check for loading indicators

### 11.3 Session Management
- Login fixture for test setup
- Session timeout handling (120 minutes)
- Logout after test suite

### 11.4 ViewState Handling
- Not directly testable
- Verify through UI state persistence
- Check hidden fields if needed

### 11.5 Validation Testing
- Client-side: Check validation messages before submit
- Server-side: Submit invalid data, check response
- ValidationSummary: Check error container

---

## 12. Unknown Items Requiring Further Investigation

| Item | Status | Priority |
|------|--------|----------|
| UpdatePanel usage | UNKNOWN | Medium |
- Specific stored procedures | UNKNOWN | High |
- Complete database schema | UNKNOWN | High |
- CSRF token implementation | UNKNOWN | High |
- File upload functionality | UNKNOWN | Medium |
- Video player implementation | UNKNOWN | Medium |
- Session timeout behavior | UNKNOWN | Medium |
- Password policy requirements | UNKNOWN | High |
- Role-based menu structure | UNKNOWN | Medium |
- AJAX endpoints | UNKNOWN | Medium |
- Error logging details | UNKNOWN | Low |

---

## 13. Next Steps (Phase 02)

1. **Deep dive into each ASCX control** to identify:
   - Event handlers
   - AutoPostBack controls
   - UpdatePanel usage
   - GridView configurations
   - Validation rules

2. **Analyze MasterPages** for:
   - Menu structure
   - Navigation logic
   - Common scripts

3. **Inspect database schema** (if access granted):
   - Table structures
   - Stored procedures
   - Constraints

4. **Map business flows** for each module:
   - URL patterns
   - Input/output
   - Validation rules
   - Error conditions

---

## 14. Appendix

### 14.1 File Count Summary
- ASPX Pages: 33
- ASCX Controls: 31
- Master Pages: 2
- Infrastructure Files: 7
- **Total Analyzed:** 73 files

### 14.2 Key Namespaces
- `InformationWeb.Pages.Auth`
- `InformationWeb.Pages.Cms`
- `InformationWeb.Pages.Lms`
- `InformationWeb.Pages.Errors`
- `InformationWeb.Controls.Auth`
- `InformationWeb.Controls.Cms`
- `InformationWeb.Controls.Lms`
- `InformationWeb.Controls.Errors`
- `InformationWeb.MasterPages`
- `InformationWeb.LmsInfrastructure`
- `LmsObject`
- `LmsService`

### 14.3 Dependencies
- System.Web
- System.Web.UI
- System.Web.UI.WebControls
- System.Web.Security
- UrlRewritingNet.UrlRewriter
- Custom: LmsObject, LmsService

---

**End of Phase 01: Source Discovery**
**Next Phase:** Phase 02 - Business Flow Analysis
