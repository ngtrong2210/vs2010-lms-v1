# QA Test Plan - LMS Web Forms Automation
## Playwright Test Automation Project

---

## 1. Tổng quan dự án

### 1.1 Thông tin dự án
- **Tên dự án:** LMS (Learning Management System) - ASP.NET Web Forms
- **Framework:** .NET Framework 4.x (ASP.NET Web Forms)
- **Công cụ tự động hóa:** Playwright (Node.js/TypeScript)
- **Người thực hiện:** Senior QA Automation Engineer
- **Ngày tạo:** 2026-10-22

### 1.2 Mục tiêu test
- Phân tích và kiểm thử toàn bộ website bằng Playwright
- Kiểm tra các tính năng: CRUD, tìm kiếm, lọc, phân trang, phân quyền
- Kiểm tra các kỹ thuật ASP.NET Web Forms: PostBack, ViewState, UpdatePanel, GridView, Session, Validation
- Kiểm tra lỗi JavaScript, HTTP errors, AJAX errors
- Kiểm thử bảo mật cơ bản: XSS, SQL Injection, truy cập trái quyền, CSRF
- Tự động chạy test case, chụp screenshot, lưu trace và console log khi thất bại
- Xuất báo cáo chi tiết với Test ID, Module, Steps, Expected, Actual, PASS/FAIL

---

## 2. Cấu trúc dự án LMS

### 2.1 Sơ đồ thư mục
```
WEB-LMS-VS2010/
├── InformationWeb/              # Web Application
│   ├── Pages/
│   │   ├── Auth/               # Authentication Module
│   │   │   ├── Login.aspx
│   │   │   └── Logout.aspx
│   │   ├── Cms/                # CMS Module (Admin)
│   │   │   ├── Dashboard.aspx
│   │   │   ├── Courses.aspx
│   │   │   ├── Users.aspx
│   │   │   ├── Students.aspx
│   │   │   ├── Roles.aspx
│   │   │   ├── Reports.aspx
│   │   │   ├── Questions.aspx
│   │   │   ├── AssignmentGrading.aspx
│   │   │   ├── ContentBuilder.aspx
│   │   │   ├── VideoEditor.aspx
│   │   │   ├── VideoLibrary.aspx
│   │   │   ├── AcademicStructure.aspx
│   │   │   ├── CourseCategories.aspx
│   │   │   ├── CourseLibrary.aspx
│   │   │   ├── CourseEnrollments.aspx
│   │   │   ├── CourseProgress.aspx
│   │   │   ├── QuizManagement.aspx
│   │   │   ├── Settings.aspx
│   │   │   ├── Help.aspx
│   │   │   ├── Search.aspx
│   │   │   └── InteractiveContentTest.aspx
│   │   ├── Lms/                # LMS Module (Student/Instructor)
│   │   │   ├── Dashboard.aspx
│   │   │   ├── Courses.aspx
│   │   │   ├── Course.aspx
│   │   │   ├── LessonPlayer.aspx
│   │   │   ├── Profile.aspx
│   │   │   └── Results.aspx
│   │   └── Errors/             # Error Pages
│   │       ├── Error.aspx
│   │       ├── Forbidden.aspx
│   │       └── NotFound.aspx
│   ├── MasterPages/
│   ├── Controls/
│   ├── Handlers/
│   └── LmsInfrastructure/
├── LmsObject/                   # Business Objects
├── LmsService/                  # Business Logic
└── 2.SQL/                       # Database Scripts
```

### 2.2 Các module chính

| Module | Tên module | Trang chính | Mô tả |
|--------|------------|-------------|-------|
| AUTH | Authentication | Login.aspx | Đăng nhập, đăng xuất |
| CMS-DASH | CMS Dashboard | Dashboard.aspx | Trang quản trị tổng quan |
| CMS-COURSE | Course Management | Courses.aspx | Quản lý khóa học |
| CMS-USER | User Management | Users.aspx | Quản lý người dùng |
| CMS-STUDENT | Student Management | Students.aspx | Quản lý sinh viên |
| CMS-ROLE | Role Management | Roles.aspx | Quản lý vai trò |
| CMS-REPORT | Reports | Reports.aspx | Báo cáo thống kê |
| CMS-QUIZ | Quiz Management | QuizManagement.aspx | Quản lý bài kiểm tra |
| CMS-VIDEO | Video Management | VideoLibrary.aspx | Quản lý video |
| CMS-CONTENT | Content Builder | ContentBuilder.aspx | Xây dựng nội dung |
| LMS-DASH | LMS Dashboard | Dashboard.aspx | Dashboard người học |
| LMS-COURSE | Course View | Course.aspx | Xem khóa học |
| LMS-LESSON | Lesson Player | LessonPlayer.aspx | Phát bài học |
| LMS-PROFILE | User Profile | Profile.aspx | Hồ sơ người dùng |
| LMS-RESULT | Results | Results.aspx | Kết quả học tập |

---

## 3. Môi trường test

### 3.1 Thông tin môi trường
- **Môi trường Development:** [Điền URL]
- **Môi trường Staging:** [Điền URL]
- **Môi trường Production:** [Chỉ đọc, không test]

### 3.2 Tài khoản test
| Role | Username | Password | Mô tả |
|------|----------|----------|-------|
| Admin | [Điền] | [Điền] | Quản trị viên toàn quyền |
| Instructor | [Điền] | [Điền] | Giảng viên |
| Student | [Điền] | [Điền] | Sinh viên |
| Guest | [Điền] | [Điền] | Khách (nếu có) |

> **Lưu ý:** Cần bổ sung thông tin tài khoản và URL trước khi chạy test.

### 3.3 Dữ liệu test
- **Dữ liệu mẫu:** Sử dụng tài khoản và dữ liệu kiểm thử được cấp
- **Không xóa/thay đổi dữ liệu production**
- **Tạo data test riêng nếu cần**

---

## 4. Chiến lược test automation

### 4.1 Framework Playwright
- **Language:** TypeScript
- **Test Runner:** Playwright Test
- **Reporter:** HTML, JSON, Allure (optional)
- **Page Object Model:** Áp dụng POM pattern
- **Data-driven:** Sử dụng CSV/JSON cho test data

### 4.2 Xử lý ASP.NET Web Forms đặc thù
- **ClientID động:** Sử dụng selector không phụ thuộc vào ID động (CSS class, name attribute, data attributes, text content)
- **PostBack Full:** Đợi complete navigation hoặc page load
- **PostBack Partial (UpdatePanel):** Đợi AJAX response, check DOM updates
- **ViewState:** Không test trực tiếp, kiểm tra qua UI behavior
- **Session:** Test qua login state, timeout behavior
- **Validation:** Test server-side và client-side validation

### 4.3 Chiến lược selector
Ưu tiên theo thứ tự:
1. **data-testid / data-* attributes** (thêm nếu cần)
2. **CSS class name ổn định**
3. **name attribute**
4. **Text content ( getByText, getByRole )**
5. **CSS structure (parent > child)**
6. **ID pattern (regex cho dynamic ID)**

---

## 5. Test Cases - Authentication Module

### 5.1 Login functionality

| Test ID | Test Case | Steps | Expected Result | Priority |
|---------|-----------|-------|----------------|----------|
| AUTH-001 | Login với username/password hợp lệ | 1. Mở trang Login.aspx<br>2. Nhập username hợp lệ<br>3. Nhập password hợp lệ<br>4. Click button Login | Đăng nhập thành công, chuyển hướng đến Dashboard | High |
| AUTH-002 | Login với username sai | 1. Mở trang Login.aspx<br>2. Nhập username không tồn tại<br>3. Nhập password bất kỳ<br>4. Click button Login | Hiển thị thông báo lỗi "Username không tồn tại" | High |
| AUTH-003 | Login với password sai | 1. Mở trang Login.aspx<br>2. Nhập username hợp lệ<br>3. Nhập password sai<br>4. Click button Login | Hiển thị thông báo lỗi "Password không đúng" | High |
| AUTH-004 | Login với trường username rỗng | 1. Mở trang Login.aspx<br>2. Để trống username<br>3. Nhập password bất kỳ<br>4. Click button Login | Hiển thị validation error, không submit | High |
| AUTH-005 | Login với trường password rỗng | 1. Mở trang Login.aspx<br>2. Nhập username hợp lệ<br>3. Để trống password<br>4. Click button Login | Hiển thị validation error, không submit | High |
| AUTH-006 | Login với cả hai trường rỗng | 1. Mở trang Login.aspx<br>2. Để trống cả username và password<br>3. Click button Login | Hiển thị validation error, không submit | High |
| AUTH-007 | Login với SQL Injection | 1. Mở trang Login.aspx<br>2. Nhập username: `' OR '1'='1`<br>3. Nhập password bất kỳ<br>4. Click button Login | Server xử lý an toàn, không login được | High |
| AUTH-008 | Login với XSS payload | 1. Mở trang Login.aspx<br>2. Nhập username: `<script>alert(1)</script>`<br>3. Nhập password bất kỳ<br>4. Click button Login | Server sanitize, không execute script | High |
| AUTH-009 | Login với username có khoảng trắng thừa | 1. Mở trang Login.aspx<br>2. Nhập username có space đầu/cuối<br>3. Nhập password hợp lệ<br>4. Click button Login | Trim username, login thành công nếu đúng | Medium |
| AUTH-010 | Login với password có khoảng trắng thừa | 1. Mở trang Login.aspx<br>2. Nhập username hợp lệ<br>3. Nhập password có space đầu/cuối<br>4. Click button Login | Không trim password, login thất bại nếu sai | Medium |
| AUTH-011 | Login với username case-sensitive | 1. Mở trang Login.aspx<br>2. Nhập username với chữ hoa/thường khác<br>3. Nhập password hợp lệ<br>4. Click button Login | Login thành công (username không case-sensitive) hoặc thất bại (có case-sensitive) | Medium |
| AUTH-012 | Login với password case-sensitive | 1. Mở trang Login.aspx<br>2. Nhập username hợp lệ<br>3. Nhập password với chữ hoa/thường khác<br>4. Click button Login | Login thất bại (password case-sensitive) | High |
| AUTH-013 | Login sau khi logout | 1. Login thành công<br>2. Logout<br>3. Login lại với cùng tài khoản | Login thành công, session mới được tạo | High |
| AUTH-014 | Login với session timeout | 1. Login thành công<br>2. Đợi session timeout<br>3. Thực hiện action yêu cầu auth | Chuyển hướng về trang Login | High |
| AUTH-015 | Login với tài khoản bị khóa | 1. Mở trang Login.aspx<br>2. Nhập username bị khóa<br>3. Nhập password đúng<br>4. Click button Login | Hiển thị thông báo "Tài khoản bị khóa" | High |
| AUTH-016 | Login với tài khoản chưa kích hoạt | 1. Mở trang Login.aspx<br>2. Nhập username chưa kích hoạt<br>3. Nhập password đúng<br>4. Click button Login | Hiển thị thông báo "Tài khoản chưa kích hoạt" | Medium |
| AUTH-017 | Login với ký tự đặc biệt trong username | 1. Mở trang Login.aspx<br>2. Nhập username có ký tự đặc biệt<br>3. Nhập password hợp lệ<br>4. Click button Login | Validation hoặc login theo quy tắc hệ thống | Low |
| AUTH-018 | Login với ký tự đặc biệt trong password | 1. Mở trang Login.aspx<br>2. Nhập username hợp lệ<br>3. Nhập password có ký tự đặc biệt<br>4. Click button Login | Login thành công nếu password đúng | High |
| AUTH-019 | Login với Enter key | 1. Mở trang Login.aspx<br>2. Nhập username và password<br>3. Nhấn Enter | Form submit như click button Login | Medium |
| AUTH-020 | Login với browser back button sau logout | 1. Login<br>2. Logout<br>3. Click browser back | Không quay lại trang được bảo vệ, redirect về Login | High |

### 5.2 Logout functionality

| Test ID | Test Case | Steps | Expected Result | Priority |
|---------|-----------|-------|----------------|----------|
| AUTH-021 | Logout thành công | 1. Login thành công<br>2. Click link/button Logout | Đăng xuất, chuyển hướng về Login/Default | High |
| AUTH-022 | Session bị xóa sau logout | 1. Login<br>2. Logout<br>3. Truy cập trang yêu cầu auth | Chuyển hướng về Login, không thể truy cập | High |
| AUTH-023 | Logout từ multiple tabs | 1. Login<br>2. Mở tab mới, truy cập trang yêu cầu auth<br>3. Logout từ tab 1<br>4. Refresh tab 2 | Tab 2 cũng bị logout | High |
| AUTH-024 | CSRF protection cho logout | 1. Gửi request POST logout từ external site | Request bị từ chối hoặc có CSRF token validation | High |

---

## 6. Test Cases - CMS Dashboard Module

### 6.1 Dashboard loading và hiển thị

| Test ID | Test Case | Steps | Expected Result | Priority |
|---------|-----------|-------|----------------|----------|
| CMS-DASH-001 | Dashboard load thành công | 1. Login với quyền Admin<br>2. Truy cập Dashboard.aspx | Dashboard load, không có JavaScript error | High |
| CMS-DASH-002 | Dashboard hiển thị thống kê | 1. Login Admin<br>2. Truy cập Dashboard | Hiển thị các thống kê: users, courses, enrollments | High |
| CMS-DASH-003 | Dashboard không có lỗi HTTP | 1. Login Admin<br>2. Truy cập Dashboard<br>3. Check console/network | Không có 404, 500, hoặc HTTP errors | High |
| CMS-DASH-004 | Dashboard responsive | 1. Login Admin<br>2. Truy cập Dashboard<br>3. Test mobile/tablet/desktop | Layout hiển thị đúng trên các breakpoint | Medium |
| CMS-DASH-005 | Dashboard với PostBack | 1. Login Admin<br>2. Thực hiện action gây PostBack<br>3. Check ViewState | ViewState được maintain, UI không bị lỗi | High |

### 6.2 Dashboard navigation

| Test ID | Test Case | Steps | Expected Result | Priority |
|---------|-----------|-------|----------------|----------|
| CMS-DASH-006 | Navigation menu hoạt động | 1. Login Admin<br>2. Click các menu item | Chuyển hướng đúng trang | High |
| CMS-DASH-007 | Active menu item được highlight | 1. Login Admin<br>2. Navigate đến trang khác | Menu item tương ứng được active | Low |
| CMS-DASH-008 | Breadcrumb hiển thị đúng | 1. Login Admin<br>2. Navigate sâu vào trang con | Breadcrumb hiển thị path đúng | Medium |

---

## 7. Test Cases - CMS Course Management Module

### 7.1 Course CRUD

| Test ID | Test Case | Steps | Expected Result | Priority |
|---------|-----------|-------|----------------|----------|
| CMS-COURSE-001 | View danh sách courses | 1. Login Admin<br>2. Truy cập Courses.aspx | Hiển thị danh sách courses trong GridView | High |
| CMS-COURSE-002 | GridView phân trang hoạt động | 1. Login Admin<br>2. Truy cập Courses.aspx<br>3. Click các trang | GridView phân trang đúng, dữ liệu thay đổi | High |
| CMS-COURSE-003 | GridView sorting hoạt động | 1. Login Admin<br>2. Truy cập Courses.aspx<br>3. Click header column để sort | Dữ liệu được sort theo column | High |
| CMS-COURSE-004 | Tạo course mới - thành công | 1. Login Admin<br>2. Click "Add New Course"<br>3. Điền đầy đủ thông tin hợp lệ<br>4. Click Save | Course được tạo, hiển thị trong danh sách | High |
| CMS-COURSE-005 | Tạo course - thiếu required field | 1. Login Admin<br>2. Click "Add New Course"<br>3. Để trống required field<br>4. Click Save | Hiển thị validation error, không tạo | High |
| CMS-COURSE-006 | Tạo course - dữ liệu không hợp lệ | 1. Login Admin<br>2. Click "Add New Course"<br>3. Nhập dữ liệu invalid (số âm, text cho số)<br>4. Click Save | Validation error, không tạo | High |
| CMS-COURSE-007 | Tạo course - XSS trong tên | 1. Login Admin<br>2. Click "Add New Course"<br>3. Nhập tên: `<script>alert(1)</script>`<br>4. Click Save | Server sanitize, không execute script | High |
| CMS-COURSE-008 | Tạo course - SQL Injection | 1. Login Admin<br>2. Click "Add New Course"<br>3. Nhập SQL injection payload<br>4. Click Save | Server sanitize, không execute SQL | High |
| CMS-COURSE-009 | Edit course - thành công | 1. Login Admin<br>2. Click Edit trên course<br>3. Thay đổi thông tin<br>4. Click Save | Course được update, hiển thị thay đổi | High |
| CMS-COURSE-010 | Edit course - hủy bỏ | 1. Login Admin<br>2. Click Edit trên course<br>3. Thay đổi thông tin<br>4. Click Cancel | Không thay đổi, quay về danh sách | Medium |
| CMS-COURSE-011 | Delete course - xác nhận | 1. Login Admin<br>2. Click Delete trên course<br>3. Confirm dialog | Course được xóa, không còn trong danh sách | High |
| CMS-COURSE-012 | Delete course - hủy bỏ | 1. Login Admin<br>2. Click Delete trên course<br>3. Cancel dialog | Course không bị xóa | Medium |
| CMS-COURSE-013 | Delete course có enrollment | 1. Login Admin<br>2. Thử xóa course có sinh viên đăng ký | Warning hoặc ngăn chặn xóa | High |
| CMS-COURSE-014 | Search course theo tên | 1. Login Admin<br>2. Nhập tên course vào search box<br>3. Click Search | Hiển thị course phù hợp | High |
| CMS-COURSE-015 | Search course - không tìm thấy | 1. Login Admin<br>2. Nhập tên không tồn tại<br>3. Click Search | Hiển thị "Không tìm thấy" hoặc danh sách rỗng | Medium |
| CMS-COURSE-016 | Filter course theo category | 1. Login Admin<br>2. Chọn category từ dropdown<br>3. Click Filter | Hiển thị course trong category | High |
| CMS-COURSE-017 | Filter - xóa filter | 1. Login Admin<br>2. Apply filter<br>3. Click "Clear Filter" | Hiển thị tất cả courses | Medium |
| CMS-COURSE-018 | GridView RowCommand hoạt động | 1. Login Admin<br>2. Click các button trong GridView row (Edit, Delete, View) | Command được xử lý đúng | High |
| CMS-COURSE-019 | UpdatePanel Partial PostBack | 1. Login Admin<br>2. Thực hiện action trong UpdatePanel<br>3. Check network | Chỉ UpdatePanel được refresh, không full postback | High |
| CMS-COURSE-020 | ViewState được maintain sau PostBack | 1. Login Admin<br>2. Thực hiện PostBack<br>3. Check form values | ViewState giữ giá trị đúng | High |

---

## 8. Test Cases - CMS User Management Module

### 8.1 User CRUD

| Test ID | Test Case | Steps | Expected Result | Priority |
|---------|-----------|-------|----------------|----------|
| CMS-USER-001 | View danh sách users | 1. Login Admin<br>2. Truy cập Users.aspx | Hiển thị danh sách users | High |
| CMS-USER-002 | GridView phân trang users | 1. Login Admin<br>2. Truy cập Users.aspx<br>3. Click pagination | Phân trang hoạt động đúng | High |
| CMS-USER-003 | Tạo user mới - thành công | 1. Login Admin<br>2. Click "Add New User"<br>3. Điền thông tin hợp lệ<br>4. Click Save | User được tạo | High |
| CMS-USER-004 | Tạo user - username đã tồn tại | 1. Login Admin<br>2. Click "Add New User"<br>3. Nhập username đã tồn tại<br>4. Click Save | Error "Username đã tồn tại" | High |
| CMS-USER-005 | Tạo user - email không hợp lệ | 1. Login Admin<br>2. Click "Add New User"<br>3. Nhập email invalid<br>4. Click Save | Validation error cho email | High |
| CMS-USER-006 | Tạo user - password không đủ mạnh | 1. Login Admin<br>2. Click "Add New User"<br>3. Nhập password yếu<br>4. Click Save | Validation error cho password | High |
| CMS-USER-007 | Tạo user - gán role | 1. Login Admin<br>2. Click "Add New User"<br>3. Chọn role từ dropdown<br>4. Click Save | User được tạo với role đúng | High |
| CMS-USER-008 | Edit user - thay đổi role | 1. Login Admin<br>2. Click Edit user<br>3. Thay đổi role<br>4. Click Save | Role được update | High |
| CMS-USER-009 | Edit user - deactivate | 1. Login Admin<br>2. Click Edit user<br>3. Uncheck "Active"<br>4. Click Save | User bị deactivate, không thể login | High |
| CMS-USER-010 | Delete user - không có enrollment | 1. Login Admin<br>2. Click Delete user không có data<br>3. Confirm | User được xóa | High |
| CMS-USER-011 | Delete user - có enrollment/data | 1. Login Admin<br>2. Thử xóa user có data liên quan | Warning hoặc ngăn chặn | High |
| CMS-USER-012 | Search user theo username | 1. Login Admin<br>2. Nhập username vào search<br>3. Click Search | Hiển thị user phù hợp | High |
| CMS-USER-013 | Search user theo email | 1. Login Admin<br>2. Nhập email vào search<br>3. Click Search | Hiển thị user phù hợp | High |
| CMS-USER-014 | Filter user theo role | 1. Login Admin<br>2. Chọn role filter<br>3. Click Filter | Hiển thị user với role đó | High |
| CMS-USER-015 | Filter user theo status (Active/Inactive) | 1. Login Admin<br>2. Chọn status filter<br>3. Click Filter | Hiển thị user với status đó | Medium |

---

## 9. Test Cases - CMS Student Management Module

### 9.1 Student CRUD

| Test ID | Test Case | Steps | Expected Result | Priority |
|---------|-----------|-------|----------------|----------|
| CMS-STU-001 | View danh sách students | 1. Login Admin<br>2. Truy cập Students.aspx | Hiển thị danh sách sinh viên | High |
| CMS-STU-002 | Tạo student mới - thành công | 1. Login Admin<br>2. Click "Add New Student"<br>3. Điền thông tin hợp lệ<br>4. Click Save | Student được tạo | High |
| CMS-STU-003 | Tạo student - mã sinh viên trùng | 1. Login Admin<br>2. Click "Add New Student"<br>3. Nhập mã sinh viên đã tồn tại<br>4. Click Save | Error "Mã sinh viên đã tồn tại" | High |
| CMS-STU-004 | Edit student - cập nhật thông tin | 1. Login Admin<br>2. Click Edit student<br>3. Thay đổi thông tin<br>4. Click Save | Thông tin được update | High |
| CMS-STU-005 | Delete student - không có enrollment | 1. Login Admin<br>2. Click Delete student không có course<br>3. Confirm | Student được xóa | High |
| CMS-STU-006 | Delete student - có enrollment | 1. Login Admin<br>2. Thử xóa student đã đăng ký course | Warning hoặc ngăn chặn | High |
| CMS-STU-007 | Search student theo mã | 1. Login Admin<br>2. Nhập mã sinh viên<br>3. Click Search | Hiển thị student phù hợp | High |
| CMS-STU-008 | Search student theo tên | 1. Login Admin<br>2. Nhập tên sinh viên<br>3. Click Search | Hiển thị student phù hợp | High |
| CMS-STU-009 | Filter student theo lớp/khoa | 1. Login Admin<br>2. Chọn filter lớp/khoa<br>3. Click Filter | Hiển thị student phù hợp | Medium |

---

## 10. Test Cases - CMS Role Management Module

### 10.1 Role CRUD

| Test ID | Test Case | Steps | Expected Result | Priority |
|---------|-----------|-------|----------------|----------|
| CMS-ROLE-001 | View danh sách roles | 1. Login Admin<br>2. Truy cập Roles.aspx | Hiển thị danh sách roles | High |
| CMS-ROLE-002 | Tạo role mới - thành công | 1. Login Admin<br>2. Click "Add New Role"<br>3. Nhập tên role<br>4. Click Save | Role được tạo | High |
| CMS-ROLE-003 | Tạo role - tên trùng | 1. Login Admin<br>2. Click "Add New Role"<br>3. Nhập tên role đã tồn tại<br>4. Click Save | Error "Role đã tồn tại" | High |
| CMS-ROLE-004 | Edit role - cập nhật permissions | 1. Login Admin<br>2. Click Edit role<br>3. Check/uncheck permissions<br>4. Click Save | Permissions được update | High |
| CMS-ROLE-005 | Delete role - không có user | 1. Login Admin<br>2. Click Delete role không có user<br>3. Confirm | Role được xóa | High |
| CMS-ROLE-006 | Delete role - có user gán | 1. Login Admin<br>2. Thử xóa role có user | Warning hoặc ngăn chặn | High |
| CMS-ROLE-007 | Assign permissions cho role | 1. Login Admin<br>2. Edit role<br>3. Check các permissions<br>4. Click Save | Permissions được gán | High |

---

## 11. Test Cases - CMS Quiz Management Module

### 11.1 Quiz CRUD

| Test ID | Test Case | Steps | Expected Result | Priority |
|---------|-----------|-------|----------------|----------|
| CMS-QUIZ-001 | View danh sách quizzes | 1. Login Admin<br>2. Truy cập QuizManagement.aspx | Hiển thị danh sách quizzes | High |
| CMS-QUIZ-002 | Tạo quiz mới - thành công | 1. Login Admin<br>2. Click "Add New Quiz"<br>3. Điền thông tin quiz<br>4. Click Save | Quiz được tạo | High |
| CMS-QUIZ-003 | Thêm question vào quiz | 1. Login Admin<br>2. Edit quiz<br>3. Click "Add Question"<br>4. Điền thông tin question<br>5. Click Save | Question được thêm vào quiz | High |
| CMS-QUIZ-004 | Edit question trong quiz | 1. Login Admin<br>2. Edit quiz<br>3. Click Edit question<br>4. Thay đổi nội dung<br>5. Click Save | Question được update | High |
| CMS-QUIZ-005 | Delete question khỏi quiz | 1. Login Admin<br>2. Edit quiz<br>3. Click Delete question<br>4. Confirm | Question bị xóa khỏi quiz | High |
| CMS-QUIZ-006 | Quiz với các loại câu hỏi | 1. Login Admin<br>2. Tạo quiz với Multiple Choice<br>3. Tạo quiz với True/False<br>4. Tạo quiz với Essay | Các loại câu hỏi được tạo đúng | High |
| CMS-QUIZ-007 | Thiết lập thời gian làm quiz | 1. Login Admin<br>2. Edit quiz<br>3. Set time limit<br>4. Click Save | Time limit được lưu | Medium |
| CMS-QUIZ-008 | Thiết lập điểm cho câu hỏi | 1. Login Admin<br>2. Edit question<br>3. Set points<br>4. Click Save | Points được lưu | High |

---

## 12. Test Cases - LMS Module (Student/Instructor)

### 12.1 LMS Dashboard

| Test ID | Test Case | Steps | Expected Result | Priority |
|---------|-----------|-------|----------------|----------|
| LMS-DASH-001 | Dashboard load cho student | 1. Login với role Student<br>2. Truy cập LMS Dashboard | Dashboard load, hiển thị courses của student | High |
| LMS-DASH-002 | Dashboard load cho instructor | 1. Login với role Instructor<br>2. Truy cập LMS Dashboard | Dashboard load, hiển thị courses quản lý | High |
| LMS-DASH-003 | Dashboard không có lỗi JS | 1. Login Student/Instructor<br>2. Truy cập Dashboard<br>3. Check console | Không có JavaScript errors | High |

### 12.2 Course View

| Test ID | Test Case | Steps | Expected Result | Priority |
|---------|-----------|-------|----------------|----------|
| LMS-COURSE-001 | View danh sách courses đã đăng ký | 1. Login Student<br>2. Truy cập Courses.aspx | Hiển thị courses đã enroll | High |
| LMS-COURSE-002 | Xem chi tiết course | 1. Login Student<br>2. Click vào course | Hiển thị chi tiết course, lessons | High |
| LMS-COURSE-003 | Enroll vào course mới | 1. Login Student<br>2. Click "Enroll" trên course<br>3. Confirm | Course được thêm vào danh sách | High |
| LMS-COURSE-004 | Unenroll course | 1. Login Student<br>2. Click "Unenroll" từ course<br>3. Confirm | Course bị xóa khỏi danh sách | Medium |

### 12.3 Lesson Player

| Test ID | Test Case | Steps | Expected Result | Priority |
|---------|-----------|-------|----------------|----------|
| LMS-LESSON-001 | Xem lesson video | 1. Login Student<br>2. Mở lesson có video<br>3. Play video | Video phát được, controls hoạt động | High |
| LMS-LESSON-002 | Xem lesson content text | 1. Login Student<br>2. Mở lesson có content text | Content hiển thị đúng | High |
| LMS-LESSON-003 | Đánh dấu lesson completed | 1. Login Student<br>2. Xem lesson<br>3. Click "Mark as Complete" | Lesson được đánh dấu completed | High |
| LMS-LESSON-004 | Navigation giữa lessons | 1. Login Student<br>2. Xem lesson<br>3. Click "Next Lesson" | Chuyển đến lesson tiếp theo | High |
| LMS-LESSON-005 | Video player controls | 1. Login Student<br>2. Mở lesson video<br>3. Test play/pause/seek/volume | Các controls hoạt động đúng | Medium |

### 12.4 Profile

| Test ID | Test Case | Steps | Expected Result | Priority |
|---------|-----------|-------|----------------|----------|
| LMS-PROFILE-001 | View profile | 1. Login Student<br>2. Truy cập Profile.aspx | Hiển thị thông tin profile | High |
| LMS-PROFILE-002 | Update profile - thành công | 1. Login Student<br>2. Edit profile<br>3. Thay đổi thông tin<br>4. Click Save | Profile được update | High |
| LMS-PROFILE-003 | Change password - thành công | 1. Login Student<br>2. Click "Change Password"<br>3. Nhập old password, new password<br>4. Click Save | Password được thay đổi | High |
| LMS-PROFILE-004 | Change password - old password sai | 1. Login Student<br>2. Click "Change Password"<br>3. Nhập old password sai<br>4. Click Save | Error "Old password không đúng" | High |
| LMS-PROFILE-005 | Change password - new password không match | 1. Login Student<br>2. Click "Change Password"<br>3. Nhập new password không khớp<br>4. Click Save | Error "New password không khớp" | High |

### 12.5 Results

| Test ID | Test Case | Steps | Expected Result | Priority |
|---------|-----------|-------|----------------|----------|
| LMS-RESULT-001 | View quiz results | 1. Login Student<br>2. Truy cập Results.aspx | Hiển thị kết quả các quiz đã làm | High |
| LMS-RESULT-002 | View chi tiết kết quả quiz | 1. Login Student<br>2. Click vào result<br>3. Xem chi tiết | Hiển thị điểm, câu đúng/sai | High |
| LMS-RESULT-003 | View course progress | 1. Login Student<br>2. Truy cập Course Progress | Hiển thị % hoàn thành từng course | High |

---

## 13. Test Cases - Phân quyền (Authorization)

### 13.1 Role-based access control

| Test ID | Test Case | Steps | Expected Result | Priority |
|---------|-----------|-------|----------------|----------|
| AUTHZ-001 | Admin truy cập CMS Dashboard | 1. Login Admin<br>2. Truy cập CMS/Dashboard.aspx | Truy cập thành công | High |
| AUTHZ-002 | Student truy cập CMS Dashboard | 1. Login Student<br>2. Truy cập CMS/Dashboard.aspx | Redirect về Forbidden hoặc Login | High |
| AUTHZ-003 | Instructor truy cập CMS Dashboard | 1. Login Instructor<br>2. Truy cập CMS/Dashboard.aspx | Theo role permission (có thể cho phép hoặc từ chối) | High |
| AUTHZ-004 | Student truy cập LMS Dashboard | 1. Login Student<br>2. Truy cập LMS/Dashboard.aspx | Truy cập thành công | High |
| AUTHZ-005 | Admin truy cập LMS Dashboard | 1. Login Admin<br>2. Truy cập LMS/Dashboard.aspx | Truy cập thành công (admin có full quyền) | High |
| AUTHZ-006 | Truy cập trang không có quyền | 1. Login với role A<br>2. Truy cập trang yêu cầu role B | Redirect về Forbidden.aspx | High |
| AUTHZ-007 | Direct URL access khi chưa login | 1. Chưa login<br>2. Direct URL đến trang bảo vệ | Redirect về Login.aspx | High |
| AUTHZ-008 | Direct URL access sau logout | 1. Login<br>2. Logout<br>3. Direct URL đến trang bảo vệ | Redirect về Login.aspx | High |
| AUTHZ-009 | Menu items theo role | 1. Login với role X<br>2. Check menu | Chỉ hiển thị menu items phù hợp role | High |
| AUTHZ-010 | Button visibility theo role | 1. Login với role X<br>2. Check các action buttons | Chỉ hiển thị buttons phù hợp quyền | High |

---

## 14. Test Cases - Bảo mật (Security)

### 14.1 XSS (Cross-Site Scripting)

| Test ID | Test Case | Steps | Expected Result | Priority |
|---------|-----------|-------|----------------|----------|
| SEC-XSS-001 | XSS trong input text | 1. Nhập `<script>alert(1)</script>` vào input<br>2. Submit form | Server sanitize, không execute script | High |
| SEC-XSS-002 | XSS trong textarea | 1. Nhập XSS payload vào textarea<br>2. Submit form | Server sanitize, không execute script | High |
| SEC-XSS-003 | XSS trong URL parameter | 1. Thêm XSS vào URL param<br>2. Truy cập URL | Server encode hoặc sanitize | High |
| SEC-XSS-004 | Stored XSS | 1. Nhập XSS vào field lưu DB<br>2. Submit<br>3. View lại trang | XSS không execute khi render | High |
| SEC-XSS-005 | Reflected XSS | 1. Thêm XSS vào search input<br>2. Submit | XSS không reflect và execute | High |

### 14.2 SQL Injection

| Test ID | Test Case | Steps | Expected Result | Priority |
|---------|-----------|-------|----------------|----------|
| SEC-SQL-001 | SQL Injection trong login | 1. Nhập `' OR '1'='1` vào username<br>2. Submit | Server sanitize, không bypass auth | High |
| SEC-SQL-002 | SQL Injection trong search | 1. Nhập `' OR 1=1--` vào search<br>2. Submit | Server sanitize, không leak data | High |
| SEC-SQL-003 | SQL Injection trong ID parameter | 1. Thêm `' OR 1=1--` vào ID param URL<br>2. Truy cập | Server validate, không inject | High |
| SEC-SQL-004 | SQL Injection UNION-based | 1. Nhập `' UNION SELECT...` vào input<br>2. Submit | Server sanitize, không execute | High |

### 14.3 CSRF (Cross-Site Request Forgery)

| Test ID | Test Case | Steps | Expected Result | Priority |
|---------|-----------|-------|----------------|----------|
| SEC-CSRF-001 | CSRF token trong form | 1. View source của form POST<br>2. Check CSRF token | Form có __REQUESTVALIDATION hoặc anti-forgery token | High |
| SEC-CSRF-002 | CSRF token validation | 1. Gửi POST request thiếu token<br>2. Check response | Request bị từ chối | High |
| SEC-CSRF-003 | CSRF token invalid | 1. Gửi POST với token sai<br>2. Check response | Request bị từ chối | High |

### 14.4 Truy cập trái quyền (Unauthorized Access)

| Test ID | Test Case | Steps | Expected Result | Priority |
|---------|-----------|-------|----------------|----------|
| SEC-UNAUTH-001 | Access trang khác user | 1. Login User A<br>2. Try access URL của User B (nếu có user-specific URL) | Access bị từ chối | High |
| SEC-UNAUTH-002 | IDOR (Insecure Direct Object Reference) | 1. Login User A<br>2. Thay đổi ID trong URL sang ID của User B<br>3. Truy cập | Access bị từ chối hoặc chỉ data của User A | High |
| SEC-UNAUTH-003 | Force browse admin pages | 1. Login Student<br>2. Direct URL đến admin pages | Redirect về Forbidden/Login | High |

---

## 15. Test Cases - Error Handling

### 15.1 Error pages

| Test ID | Test Case | Steps | Expected Result | Priority |
|---------|-----------|-------|----------------|----------|
| ERR-001 | 404 Not Found page | 1. Truy cập URL không tồn tại | Hiển thị NotFound.aspx với thông báo rõ ràng | High |
| ERR-002 | 403 Forbidden page | 1. Truy cập trang không có quyền | Hiển thị Forbidden.aspx với thông báo rõ ràng | High |
| ERR-003 | 500 Error page | 1. Trigger server error (nếu có cách an toàn)<br>2. Hoặc check config | Hiển thị Error.aspx, không leak stack trace | High |
| ERR-004 | Custom error message user-friendly | 1. Trigger error page<br>2. Check message | Message thân thiện với user, không technical detail | Medium |

---

## 16. Test Cases - JavaScript & AJAX

### 16.1 JavaScript errors

| Test ID | Test Case | Steps | Expected Result | Priority |
|---------|-----------|-------|----------------|----------|
| JS-001 | Không có JS error trên load | 1. Truy cập từng trang<br>2. Check browser console | Không có JavaScript errors | High |
| JS-002 | Không có JS error trên interaction | 1. Thực hiện các actions (click, input, submit)<br>2. Check console | Không có JavaScript errors | High |
| JS-003 | jQuery/Bootstrap load thành công | 1. Truy cập trang<br>2. Check console | Các libraries load thành công, không 404 | High |
| JS-004 | Custom scripts không error | 1. Thực hiện actions sử dụng custom JS<br>2. Check console | Không có errors từ custom scripts | High |

### 16.2 AJAX errors

| Test ID | Test Case | Steps | Expected Result | Priority |
|---------|-----------|-------|----------------|----------|
| AJAX-001 | UpdatePanel PostBack thành công | 1. Thực hiện action trong UpdatePanel<br>2. Check network | Partial postback thành công, không full reload | High |
| AJAX-002 | AJAX error handling | 1. Trigger AJAX request (nếu có endpoint fail)<br>2. Check UI | Hiển thị error message thân thiện | Medium |
| AJAX-003 | AJAX timeout handling | 1. Simulate slow response<br>2. Check UI | Hiển thị timeout message hoặc loading state | Medium |

---

## 17. Test Cases - HTTP & Network

### 17.1 HTTP errors

| Test ID | Test Case | Steps | Expected Result | Priority |
|---------|-----------|-------|----------------|----------|
| HTTP-001 | Không có 404 cho static resources | 1. Truy cập trang<br>2. Check network tab | Tất cả CSS, JS, images load thành công | High |
| HTTP-002 | Không có 500 errors | 1. Thực hiện các actions<br>2. Check network | Không có server 500 errors | High |
| HTTP-003 | HTTPS (nếu có) | 1. Check protocol | Site sử dụng HTTPS (cho production) | High |
| HTTP-004 | Mixed content (nếu có HTTPS) | 1. Check network | Không có mixed content warnings | Medium |

---

## 18. Cấu trúc Project Playwright

### 18.1 Cấu trúc thư mục
```
playwright-lms-test/
├── package.json
├── playwright.config.ts
├── tsconfig.json
├── .env                          # Environment variables (URL, credentials)
├── .env.example                  # Template cho .env
├── data/                         # Test data
│   ├── users.json
│   ├── courses.json
│   └── quiz-data.json
├── pages/                        # Page Object Model
│   ├── base.page.ts
│   ├── auth/
│   │   ├── login.page.ts
│   │   └── logout.page.ts
│   ├── cms/
│   │   ├── dashboard.page.ts
│   │   ├── courses.page.ts
│   │   ├── users.page.ts
│   │   ├── students.page.ts
│   │   ├── roles.page.ts
│   │   ├── quiz-management.page.ts
│   │   └── ...
│   └── lms/
│       ├── dashboard.page.ts
│       ├── courses.page.ts
│       ├── lesson-player.page.ts
│       ├── profile.page.ts
│       └── results.page.ts
├── tests/                        # Test specs
│   ├── auth/
│   │   ├── login.spec.ts
│   │   └── logout.spec.ts
│   ├── cms/
│   │   ├── dashboard.spec.ts
│   │   ├── courses.spec.ts
│   │   ├── users.spec.ts
│   │   ├── students.spec.ts
│   │   ├── roles.spec.ts
│   │   ├── quiz-management.spec.ts
│   │   └── ...
│   ├── lms/
│   │   ├── dashboard.spec.ts
│   │   ├── courses.spec.ts
│   │   ├── lesson-player.spec.ts
│   │   ├── profile.spec.ts
│   │   └── results.spec.ts
│   ├── security/
│   │   ├── xss.spec.ts
│   │   ├── sql-injection.spec.ts
│   │   ├── csrf.spec.ts
│   │   └── authorization.spec.ts
│   └── performance/
│       └── load-time.spec.ts
├── utils/                        # Helper functions
│   ├── selectors.ts             # Selector helpers
│   ├── data-provider.ts          # Data-driven test helpers
│   ├── api-helpers.ts            # API helpers (nếu cần)
│   └── test-helpers.ts           # Common test utilities
├── fixtures/                     # Test fixtures
│   └── auth.fixture.ts           # Login fixture
├── reporters/                    # Custom reporters
│   └── custom-reporter.ts
├── screenshots/                  # Screenshots (generated)
├── traces/                       # Traces (generated)
└── test-results/                 # HTML reports (generated)
```

### 18.2 File playwright.config.ts
```typescript
import { defineConfig, devices } from '@playwright/test';

export default defineConfig({
  testDir: './tests',
  fullyParallel: true,
  forbidOnly: !!process.env.CI,
  retries: process.env.CI ? 2 : 0,
  workers: process.env.CI ? 1 : undefined,
  reporter: [
    ['html', { outputFolder: 'test-results/html-report' }],
    ['json', { outputFile: 'test-results/results.json' }],
    ['list'],
    ['junit', { outputFile: 'test-results/junit.xml' }]
  ],
  use: {
    baseURL: process.env.BASE_URL || 'http://localhost:8080',
    trace: 'on-first-retry',
    screenshot: 'only-on-failure',
    video: 'retain-on-failure',
    headless: true,
    actionTimeout: 30000,
    navigationTimeout: 30000,
  },
  projects: [
    {
      name: 'chromium',
      use: { ...devices['Desktop Chrome'] },
    },
    {
      name: 'firefox',
      use: { ...devices['Desktop Firefox'] },
    },
    {
      name: 'webkit',
      use: { ...devices['Desktop Safari'] },
    },
    {
      name: 'Mobile Chrome',
      use: { ...devices['Pixel 5'] },
    },
    {
      name: 'Mobile Safari',
      use: { ...devices['iPhone 12'] },
    },
  ],
  webServer: {
    command: 'echo "Web server should be running already"',
    port: 8080,
    reuseExistingServer: !process.env.CI,
  },
});
```

### 18.3 File .env.example
```env
# Environment Configuration
BASE_URL=http://localhost:8080/InformationWeb

# Test Credentials
ADMIN_USERNAME=admin
ADMIN_PASSWORD=Admin@123
INSTRUCTOR_USERNAME=instructor
INSTRUCTOR_PASSWORD=Instructor@123
STUDENT_USERNAME=student
STUDENT_PASSWORD=Student@123

# Test Settings
HEADLESS=true
BROWSER=chromium
TIMEOUT=30000
```

---

## 19. Thiết lập Playwright

### 19.1 Cài đặt Playwright
```bash
# Tạo project mới
npm init -y
npm install -D @playwright/test
npm install -D typescript
npm install -D @types/node
npx playwright install
npx playwright install-deps
```

### 19.2 Cấu hình TypeScript (tsconfig.json)
```json
{
  "compilerOptions": {
    "target": "ES2020",
    "module": "commonjs",
    "lib": ["ES2020", "DOM"],
    "strict": true,
    "esModuleInterop": true,
    "skipLibCheck": true,
    "forceConsistentCasingInFileNames": true,
    "moduleResolution": "node",
    "resolveJsonModule": true,
    "outDir": "./dist"
  },
  "include": ["tests/**/*", "pages/**/*", "utils/**/*", "fixtures/**/*"]
}
```

---

## 20. Kịch bản test mẫu

### 20.1 Login test mẫu (tests/auth/login.spec.ts)
```typescript
import { test, expect } from '@playwright/test';
import { LoginPage } from '../../pages/auth/login.page';

test.describe('Authentication - Login', () => {
  let loginPage: LoginPage;

  test.beforeEach(async ({ page }) => {
    loginPage = new LoginPage(page);
    await loginPage.goto();
  });

  test('AUTH-001: Login với username/password hợp lệ', async ({ page }) => {
    await loginPage.login(process.env.ADMIN_USERNAME!, process.env.ADMIN_PASSWORD!);
    await expect(page).toHaveURL(/.*Dashboard.*/);
    await expect(page.locator('body')).toContainText('Dashboard');
  });

  test('AUTH-002: Login với username sai', async ({ page }) => {
    await loginPage.login('invalid_user', process.env.ADMIN_PASSWORD!);
    await expect(loginPage.errorMessage).toBeVisible();
    await expect(loginPage.errorMessage).toContainText('Username không tồn tại');
  });

  test('AUTH-003: Login với password sai', async ({ page }) => {
    await loginPage.login(process.env.ADMIN_USERNAME!, 'wrong_password');
    await expect(loginPage.errorMessage).toBeVisible();
    await expect(loginPage.errorMessage).toContainText('Password không đúng');
  });

  test('AUTH-004: Login với trường username rỗng', async ({ page }) => {
    await loginPage.login('', process.env.ADMIN_PASSWORD!);
    await expect(loginPage.usernameError).toBeVisible();
  });

  test('AUTH-007: Login với SQL Injection', async ({ page }) => {
    await loginPage.login("' OR '1'='1", 'any_password');
    await expect(page).toHaveURL(/.*Login.*/);
    await expect(loginPage.errorMessage).toBeVisible();
  });

  test('AUTH-008: Login với XSS payload', async ({ page }) => {
    await loginPage.login('<script>alert(1)</script>', 'any_password');
    await expect(page).toHaveURL(/.*Login.*/);
    // Check that script is not executed
    const alerts = page.on('dialog', () => {});
    await expect(loginPage.errorMessage).toBeVisible();
  });
});
```

### 20.2 Page Object mẫu (pages/auth/login.page.ts)
```typescript
import { Page, Locator } from '@playwright/test';

export class LoginPage {
  readonly page: Page;
  readonly usernameInput: Locator;
  readonly passwordInput: Locator;
  readonly loginButton: Locator;
  readonly errorMessage: Locator;
  readonly usernameError: Locator;

  constructor(page: Page) {
    this.page = page;
    // Sử dụng selector không phụ thuộc vào ID động
    this.usernameInput = page.locator('input[name*="Username"], input[type="text"]').first();
    this.passwordInput = page.locator('input[name*="Password"], input[type="password"]').first();
    this.loginButton = page.locator('input[type="submit"], button[type="submit"]').first();
    this.errorMessage = page.locator('.error, .alert-danger, [id*="Error"]').first();
    this.usernameError = page.locator('text=Username is required, .field-validation-error').first();
  }

  async goto() {
    await this.page.goto('/Pages/Auth/Login.aspx');
  }

  async login(username: string, password: string) {
    await this.usernameInput.fill(username);
    await this.passwordInput.fill(password);
    await this.loginButton.click();
    // Đợi PostBack hoàn thành
    await this.page.waitForLoadState('networkidle');
  }
}
```

---

## 21. Execution Plan

### 21.1 Thứ tự thực hiện test
1. **Authentication Module** (AUTH-*) - Ưu tiên cao nhất
2. **Authorization Module** (AUTHZ-*) - Kiểm tra phân quyền
3. **CMS Dashboard** (CMS-DASH-*)
4. **CMS Course Management** (CMS-COURSE-*)
5. **CMS User Management** (CMS-USER-*)
6. **CMS Student Management** (CMS-STU-*)
7. **CMS Role Management** (CMS-ROLE-*)
8. **CMS Quiz Management** (CMS-QUIZ-*)
9. **LMS Module** (LMS-*)
10. **Security Tests** (SEC-*)
11. **Error Handling** (ERR-*)
12. **JavaScript & AJAX** (JS-*, AJAX-*)
13. **HTTP & Network** (HTTP-*)

### 21.2 Lịch trình test
| Tuần | Module | Trạng thái |
|------|--------|------------|
| Tuần 1 | Thiết lập môi trường, Authentication, Authorization | Todo |
| Tuần 2 | CMS Dashboard, Course Management | Todo |
| Tuần 3 | CMS User, Student, Role Management | Todo |
| Tuần 4 | CMS Quiz Management, LMS Module | Todo |
| Tuần 5 | Security Tests, Error Handling | Todo |
| Tuần 6 | JavaScript, AJAX, HTTP Tests | Todo |
| Tuần 7 | Regression Test, Fix | Todo |
| Tuần 8 | Final Report | Todo |

---

## 22. Báo cáo Test

### 22.1 Format báo cáo
Báo cáo sẽ bao gồm:
- Test ID
- Module
- Test Case Name
- Steps
- Expected Result
- Actual Result
- Status (PASS/FAIL)
- Failure Reason (nếu FAIL)
- Screenshot (nếu FAIL)
- Trace (nếu FAIL)
- Console Log (nếu FAIL)
- Execution Time

### 22.2 Xuất báo cáo
Sử dụng Playwright HTML Reporter:
```bash
npx playwright test --reporter=html
```

Hoặc custom reporter để xuất Excel/CSV:
```bash
npx playwright test --reporter=./reporters/custom-reporter.ts
```

### 22.3 Template báo cáo Markdown
```markdown
# Test Execution Report

## Summary
- Total Tests: [X]
- Passed: [X]
- Failed: [X]
- Skipped: [X]
- Pass Rate: [X]%

## Failed Tests
| Test ID | Module | Test Case | Failure Reason |
|---------|--------|-----------|----------------|
| AUTH-002 | Auth | Login với username sai | [Reason] |

## Detailed Results
[Link to HTML Report]
```

---

## 23. Đề xuất sửa lỗi

Khi test thất bại, sẽ ghi nhận:
1. **Bug ID:** [Auto-generated]
2. **Mô tả:** Chi tiết lỗi
3. **Steps to reproduce:** Các bước tái hiện
4. **Expected behavior:** Mong đợi
5. **Actual behavior:** Thực tế
6. **Severity:** Critical/High/Medium/Low
7. **Priority:** P1/P2/P3/P4
8. **Screenshot/Trace:** Đính kèm
9. **Đề xuất fix:** Gợi ý cách sửa (không tự sửa code)

---

## 24. Notes và Checklist

### 24.1 Pre-test Checklist
- [ ] URL test environment đã được cung cấp
- [ ] Tài khoản test đã được tạo (Admin, Instructor, Student)
- [ ] Database test đã được setup
- [ ] Playwright đã được cài đặt
- [ ] Environment variables đã được cấu hình (.env)
- [ ] Test data đã được chuẩn bị

### 24.2 During Test Checklist
- [ ] Chỉ sử dụng tài khoản và dữ liệu test
- [ ] Không xóa/thay đổi dữ liệu production
- [ ] Kiểm tra console cho JavaScript errors
- [ ] Kiểm tra network tab cho HTTP errors
- [ ] Chụp screenshot khi test fail
- [ ] Lưu trace khi test fail
- [ ] Ghi log console khi test fail

### 24.3 Post-test Checklist
- [ ] Xuất báo cáo HTML
- [ ] Xuất báo cáo JSON/Excel
- [ ] Review failed tests
- [ ] Document bugs
- [ ] Đề xuất fix cho bugs
- [ ] Clean up test data (nếu cần)

---

## 25. Rủi ro và Giải pháp

| Rủi ro | Mô tả | Giải pháp |
|--------|-------|-----------|
| ID động của ASP.NET controls | ASP.NET generate ID động (ctl00_...) | Sử dụng selector không phụ thuộc ID: class, name, text, data attributes |
| PostBack gây test unstable | Full/Partial PostBack có thể gây race condition | Sử dụng waitForLoadState, waitForSelector, waitForResponse |
| Session timeout | Session expire trong khi test | Kiểm tra session state, re-login nếu cần |
| Environment không ổn định | Test environment down hoặc slow | Retry mechanism, timeout configuration |
| Thiếu tài khoản test | Không có đủ tài khoản cho các roles | Yêu cầu bổ sung trước khi test |
| Dữ liệu test bị thay đổi | Test data bị sửa bởi quá trình khác | Sử dụng data test riêng, rollback sau test |

---

## 26. Tài liệu tham khảo

- [Playwright Documentation](https://playwright.dev/)
- [ASP.NET Web Forms Overview](https://learn.microsoft.com/en-us/aspnet/web-forms/)
- [OWASP Testing Guide](https://owasp.org/www-project-web-security-testing-guide/)
- [Page Object Model](https://playwright.dev/docs/pom)

---

## 27. Changelog

| Ngày | Version | Thay đổi | Người thực hiện |
|------|---------|----------|----------------|
| 2026-10-22 | 1.0 | Tạo test plan ban đầu | QA Automation Engineer |

---

## 28. Appendix

### 28.1 Glossary
- **PostBack:** ASP.NET mechanism để submit form về server
- **ViewState:** ASP.NET state management mechanism
- **UpdatePanel:** ASP.NET AJAX control cho partial page update
- **GridView:** ASP.NET data-bound control
- **Session:** Server-side state management
- **XSS:** Cross-Site Scripting
- **CSRF:** Cross-Site Request Forgery
- **IDOR:** Insecure Direct Object Reference
- **POM:** Page Object Model

### 28.2 Contact
- **QA Lead:** [Điền tên và email]
- **Developer Lead:** [Điền tên và email]
- **Project Manager:** [Điền tên và email]

---

**End of Document**
