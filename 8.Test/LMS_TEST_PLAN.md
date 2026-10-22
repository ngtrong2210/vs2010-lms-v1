# LMS - TEST PLAN FULL FLOW
## Dự án: Hệ thống quản lý học tập trực tuyến Thiên Hà Số
**Ngày tạo:** 2026-09-01
**Phiên bản:** 1.0

---

## 📋 TỔNG QUAN

### Mục tiêu test
- Test toàn bộ luồng người dùng của hệ thống LMS
- Kiểm tra chức năng menu, nút, và view loading
- Xác nhận tính ổn định của từng module

### Thông tin hệ thống
- **Project Path:** `G:\0.DỰ ÁN\2.LMS-VS2010\WEB-LMS-VS2010\1. WEB-LMS-VS2010`
- **Solution:** WEB-LMS-VS2010.sln
- **Framework:** ASP.NET WebForms + C#
- **Database:** SQL Server

### Tài khoản test mặc định
- **Username:** admin
- **Password:** 123456

---

## 🤖 PHÂN CÔNG CHO 2 AI

### 📌 AI-1: TEST CMS MODULE (QUẢN TRỊ VIÊN)
**Phạm vi:** Test toàn bộ trang quản trị admin
**Menu chính:**
- Dashboard (Bảng điều khiển)
- Cơ cấu đào tạo
- Soạn môn học lớp
- Thư viện video
- Ngân hàng câu hỏi
- Danh sách học viên
- Chấm và trả bài
- Tiến độ và báo cáo
- Người dùng (Admin only)
- Phân quyền (Admin only)
- Cài đặt (Admin only)

### 📌 AI-2: TEST LMS MODULE (HỌC VIÊN)
**Phạm vi:** Test toàn bộ trang học tập học viên
**Menu chính:**
- Dashboard (Tổng quan học tập)
- Môn học của tôi
- Kết quả
- Hồ sơ
- Lesson Player (Trình phát bài giảng)

---

## 📝 AI-1: CMS TEST CASES

### 🔐 TEST 1: ĐĂNG NHẬP ADMIN
**File:** `InformationWeb/Pages/Auth/Login.aspx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 1.1 | Mở trang `/login` | Hiển thị form đăng nhập | ⬜ |
| 1.2 | Nhập username: `admin` | Field điền thành công | ⬜ |
| 1.3 | Nhập password: `123456` | Field điền thành công | ⬜ |
| 1.4 | Click nút "Đăng nhập" | Chuyển hướng đến `/cms/dashboard` | ⬜ |
| 1.5 | Kiểm tra URL | URL = `/cms/dashboard` | ⬜ |
| 1.6 | Kiểm tra hiển thị sidebar | Sidebar CMS hiển thị | ⬜ |

---

### 📊 TEST 2: CMS DASHBOARD
**File:** `InformationWeb/Pages/Cms/Dashboard.aspx`
**Control:** `InformationWeb/Controls/Cms/Dashboard.ascx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 2.1 | Check page load | Trang load không lỗi | ⬜ |
| 2.2 | Check thống kê cards | Hiển thị các card thống kê | ⬜ |
| 2.3 | Check menu item active | Menu "Bảng điều khiển" active | ⬜ |
| 2.4 | Check topbar user info | Hiển thị tên admin | ⬜ |
| 2.5 | Click nút sidebar toggle | Sidebar thu gọn/mở rộng | ⬜ |
| 2.6 | Click notification bell | Panel thông báo hiển thị | ⬜ |

---

### 🏛️ TEST 3: CƠ CẤU ĐÀO TẠO
**File:** `InformationWeb/Pages/Cms/AcademicStructure.aspx`
**Control:** `InformationWeb/Controls/Cms/AcademicStructure.ascx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 3.1 | Click menu "Cơ cấu đào tạo" | Chuyển đến `/cms/academic` | ⬜ |
| 3.2 | Check page load | Trang load không lỗi | ⬜ |
| 3.3 | Check tree structure | Hiển thị cây cấu trúc | ⬜ |
| 3.4 | Check nút "Thêm mới" | Nút hiển thị và click được | ⬜ |
| 3.5 | Check nút "Sửa" | Nút hiển thị trên từng item | ⬜ |
| 3.6 | Check nút "Xóa" | Nút hiển thị và có confirm | ⬜ |
| 3.7 | Click "Thêm mới" | Modal/form thêm hiển thị | ⬜ |
| 3.8 | Điền form thêm | Các field hoạt động | ⬜ |
| 3.9 | Click "Lưu" | Lưu thành công, reload list | ⬜ |

---

### 📚 TEST 4: SOẠN MÔN HỌC LỚP
**File:** `InformationWeb/Pages/Cms/Courses.aspx`
**Control:** `InformationWeb/Controls/Cms/Courses.ascx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 4.1 | Click menu "Soạn môn học lớp" | Chuyển đến `/cms/courses` | ⬜ |
| 4.2 | Check page load | Trang load không lỗi | ⬜ |
| 4.3 | Check grid/list courses | Hiển thị danh sách môn học | ⬜ |
| 4.4 | Check nút "Thêm môn học" | Nút hiển thị | ⬜ |
| 4.5 | Check nút "Chỉnh sửa" | Nút hiển thị trên từng row | ⬜ |
| 4.6 | Check nút "Xóa" | Nút hiển thị và có confirm | ⬜ |
| 4.7 | Click "Thêm môn học" | Form thêm môn học hiển thị | ⬜ |
| 4.8 | Điền tên môn học | Field hoạt động | ⬜ |
| 4.9 | Điền mô tả | Field hoạt động | ⬜ |
| 4.10 | Select category | Dropdown hoạt động | ⬜ |
| 4.11 | Click "Lưu" | Lưu thành công | ⬜ |
| 4.12 | Click tab "Bài giảng" | Tab chuyển thành công | ⬜ |
| 4.13 | Click "Thêm bài giảng" | Form thêm bài giảng hiển thị | ⬜ |
| 4.14 | Điền thông tin bài giảng | Field hoạt động | ⬜ |
| 4.15 | Click "Lưu" | Lưu thành công | ⬜ |

---

### 🎥 TEST 5: THƯ VIỆN VIDEO
**File:** `InformationWeb/Pages/Cms/VideoLibrary.aspx`
**Control:** `InformationWeb/Controls/Cms/VideoLibrary.ascx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 5.1 | Click menu "Thư viện video" | Chuyển đến `/cms/videos` | ⬜ |
| 5.2 | Check page load | Trang load không lỗi | ⬜ |
| 5.3 | Check grid videos | Hiển thị danh sách video | ⬜ |
| 5.4 | Check nút "Upload video" | Nút hiển thị | ⬜ |
| 5.5 | Click "Upload video" | Form upload hiển thị | ⬜ |
| 5.6 | Select file | File picker mở | ⬜ |
| 5.7 | Điền tiêu đề | Field hoạt động | ⬜ |
| 5.8 | Click "Upload" | Upload tiến trình hiển thị | ⬜ |
| 5.9 | Check nút "Sửa" | Nút hiển thị trên từng video | ⬜ |
| 5.10 | Check nút "Xóa" | Nút hiển thị và có confirm | ⬜ |
| 5.11 | Click nút "Video Editor" | Chuyển đến `/cms/video-editor` | ⬜ |

---

### 🎬 TEST 6: VIDEO EDITOR
**File:** `InformationWeb/Pages/Cms/VideoEditor.aspx`
**Control:** `InformationWeb/Controls/Cms/VideoEditor.ascx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 6.1 | Open `/cms/video-editor` | Trang load không lỗi | ⬜ |
| 6.2 | Check video player | Player hiển thị | ⬜ |
| 6.3 | Check timeline | Timeline hiển thị | ⬜ |
| 6.4 | Check nút "Play/Pause" | Nút hoạt động | ⬜ |
| 6.5 | Check nút "Cut" | Nút hiển thị | ⬜ |
| 6.6 | Check nút "Save" | Nút hiển thị | ⬜ |
| 6.7 | Check nút "Export" | Nút hiển thị | ⬜ |

---

### ❓ TEST 7: NGÂN HÀNG CÂU HỎI
**File:** `InformationWeb/Pages/Cms/Questions.aspx`
**Control:** `InformationWeb/Controls/Cms/Questions.ascx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 7.1 | Click menu "Ngân hàng câu hỏi" | Chuyển đến `/cms/questions` | ⬜ |
| 7.2 | Check page load | Trang load không lỗi | ⬜ |
| 7.3 | Check grid questions | Hiển thị danh sách câu hỏi | ⬜ |
| 7.4 | Check filter dropdown | Filter hiển thị | ⬜ |
| 7.5 | Check nút "Thêm câu hỏi" | Nút hiển thị | ⬜ |
| 7.6 | Click "Thêm câu hỏi" | Form thêm hiển thị | ⬜ |
| 7.7 | Select loại câu hỏi | Dropdown hoạt động (Trắc nghiệm, Tự luận...) | ⬜ |
| 7.8 | Điền nội dung câu hỏi | Textarea hoạt động | ⬜ |
| 7.9 | Điền đáp án | Field hoạt động | ⬜ |
| 7.10 | Click "Lưu" | Lưu thành công | ⬜ |
| 7.11 | Check nút "Sửa" | Nút hiển thị | ⬜ |
| 7.12 | Check nút "Xóa" | Nút hiển thị và có confirm | ⬜ |

---

### 📝 TEST 8: QUIZ MANAGEMENT
**File:** `InformationWeb/Pages/Cms/QuizManagement.aspx`
**Control:** `InformationWeb/Controls/Cms/QuizManagement.ascx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 8.1 | Click menu "Quiz Management" | Chuyển đến `/cms/quiz` | ⬜ |
| 8.2 | Check page load | Trang load không lỗi | ⬜ |
| 8.3 | Check grid quizzes | Hiển thị danh sách quiz | ⬜ |
| 8.4 | Check nút "Tạo quiz" | Nút hiển thị | ⬜ |
| 8.5 | Click "Tạo quiz" | Form tạo quiz hiển thị | ⬜ |
| 8.6 | Điền tên quiz | Field hoạt động | ⬜ |
| 8.7 | Select môn học | Dropdown hoạt động | ⬜ |
| 8.8 | Select câu hỏi từ ngân hàng | Multi-select hoạt động | ⬜ |
| 8.9 | Set thời gian làm bài | Field hoạt động | ⬜ |
| 8.10 | Click "Lưu" | Lưu thành công | ⬜ |
| 8.11 | Check nút "Preview" | Nút hiển thị, mở preview | ⬜ |

---

### 👨‍🎓 TEST 9: DANH SÁCH HỌC VIÊN
**File:** `InformationWeb/Pages/Cms/Students.aspx`
**Control:** `InformationWeb/Controls/Cms/Students.ascx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 9.1 | Click menu "Danh sách học viên" | Chuyển đến `/cms/students` | ⬜ |
| 9.2 | Check page load | Trang load không lỗi | ⬜ |
| 9.3 | Check grid students | Hiển thị danh sách học viên | ⬜ |
| 9.4 | Check search box | Search box hoạt động | ⬜ |
| 9.5 | Enter keyword search | Grid filter theo keyword | ⬜ |
| 9.6 | Check nút "Thêm học viên" | Nút hiển thị | ⬜ |
| 9.7 | Click "Thêm học viên" | Form thêm hiển thị | ⬜ |
| 9.8 | Điền thông tin học viên | Các field hoạt động | ⬜ |
| 9.9 | Click "Lưu" | Lưu thành công | ⬜ |
| 9.10 | Click row học viên | Hiển thị chi tiết | ⬜ |
| 9.11 | Check nút "Gán môn học" | Nút hiển thị | ⬜ |
| 9.12 | Click "Gán môn học" | Modal gán môn học hiển thị | ⬜ |

---

### 📋 TEST 10: ENROLLMENTS (PHÂN LỚP)
**File:** `InformationWeb/Pages/Cms/Enrollments.aspx`
**Control:** `InformationWeb/Controls/Cms/Enrollments.ascx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 10.1 | Click menu "Phân lớp" | Chuyển đến `/cms/enrollments` | ⬜ |
| 10.2 | Check page load | Trang load không lỗi | ⬜ |
| 10.3 | Check grid enrollments | Hiển thị danh sách phân lớp | ⬜ |
| 10.4 | Check filter môn học | Filter hoạt động | ⬜ |
| 10.5 | Check filter lớp | Filter hoạt động | ⬜ |
| 10.6 | Check nút "Phân lớp mới" | Nút hiển thị | ⬜ |
| 10.7 | Click "Phân lớp mới" | Form phân lớp hiển thị | ⬜ |
| 10.8 | Select học viên | Dropdown hoạt động | ⬜ |
| 10.9 | Select môn học | Dropdown hoạt động | ⬜ |
| 10.10 | Click "Lưu" | Lưu thành công | ⬜ |

---

### ✅ TEST 11: CHẤM VÀ TRẢ BÀI
**File:** `InformationWeb/Pages/Cms/AssignmentGrading.aspx`
**Control:** `InformationWeb/Controls/Cms/AssignmentGrading.ascx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 11.1 | Click menu "Chấm và trả bài" | Chuyển đến `/cms/assignments` | ⬜ |
| 11.2 | Check page load | Trang load không lỗi | ⬜ |
| 11.3 | Check grid submissions | Hiển thị danh sách bài nộp | ⬜ |
| 11.4 | Check filter status | Filter hoạt động (Chưa chấm, Đã chấm) | ⬜ |
| 11.5 | Click row bài nộp | Hiển thị chi tiết bài làm | ⬜ |
| 11.6 | Check textarea nhận xét | Textarea hoạt động | ⬜ |
| 11.7 | Check input điểm số | Input hoạt động | ⬜ |
| 11.8 | Nhập điểm số | Field điền thành công | ⬜ |
| 11.9 | Nhập nhận xét | Textarea điền thành công | ⬜ |
| 11.10 | Click "Lưu điểm" | Lưu thành công | ⬜ |
| 11.11 | Click "Gửi phản hồi" | Gửi thành công | ⬜ |

---

### 📊 TEST 12: TIẾN ĐỘ VÀ BÁO CÁO
**File:** `InformationWeb/Pages/Cms/Reports.aspx`
**Control:** `InformationWeb/Controls/Cms/Reports.ascx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 12.1 | Click menu "Tiến độ và báo cáo" | Chuyển đến `/cms/reports` | ⬜ |
| 12.2 | Check page load | Trang load không lỗi | ⬜ |
| 12.3 | Check charts | Biểu đồ hiển thị | ⬜ |
| 12.4 | Check filter thời gian | Filter hoạt động | ⬜ |
| 12.5 | Check filter môn học | Filter hoạt động | ⬜ |
| 12.6 | Check nút "Xuất báo cáo" | Nút hiển thị | ⬜ |
| 12.7 | Click "Xuất báo cáo" | File download hoặc mở | ⬜ |
| 12.8 | Check table chi tiết | Table hiển thị dữ liệu | ⬜ |

---

### 👥 TEST 13: NGƯỜI DÙNG (ADMIN ONLY)
**File:** `InformationWeb/Pages/Cms/Users.aspx`
**Control:** `InformationWeb/Controls/Cms/Users.ascx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 13.1 | Click menu "Người dùng" | Chuyển đến `/cms/users` | ⬜ |
| 13.2 | Check page load | Trang load không lỗi | ⬜ |
| 13.3 | Check grid users | Hiển thị danh sách users | ⬜ |
| 13.4 | Check nút "Thêm user" | Nút hiển thị | ⬜ |
| 13.5 | Click "Thêm user" | Form thêm user hiển thị | ⬜ |
| 13.6 | Điền username | Field hoạt động | ⬜ |
| 13.7 | Điền email | Field hoạt động | ⬜ |
| 13.8 | Select role | Dropdown hoạt động | ⬜ |
| 13.9 | Click "Lưu" | Lưu thành công | ⬜ |
| 13.10 | Check nút "Reset password" | Nút hiển thị | ⬜ |
| 13.11 | Click "Reset password" | Confirm hiển thị, reset thành công | ⬜ |

---

### 🔐 TEST 14: PHÂN QUYỀN (ADMIN ONLY)
**File:** `InformationWeb/Pages/Cms/Roles.aspx`
**Control:** `InformationWeb/Controls/Cms/Roles.ascx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 14.1 | Click menu "Phân quyền" | Chuyển đến `/cms/roles` | ⬜ |
| 14.2 | Check page load | Trang load không lỗi | ⬜ |
| 14.3 | Check grid roles | Hiển thị danh sách roles | ⬜ |
| 14.4 | Check nút "Thêm role" | Nút hiển thị | ⬜ |
| 14.5 | Click "Thêm role" | Form thêm role hiển thị | ⬜ |
| 14.6 | Điền tên role | Field hoạt động | ⬜ |
| 14.7 | Check permissions checkbox | Checkbox hiển thị | ⬜ |
| 14.8 | Select permissions | Checkbox hoạt động | ⬜ |
| 14.9 | Click "Lưu" | Lưu thành công | ⬜ |
| 14.10 | Click role existing | Hiển thị chi tiết permissions | ⬜ |

---

### ⚙️ TEST 15: CÀI ĐẶT (ADMIN ONLY)
**File:** `InformationWeb/Pages/Cms/Settings.aspx`
**Control:** `InformationWeb/Controls/Cms/Settings.ascx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 15.1 | Click menu "Cài đặt" | Chuyển đến `/cms/settings` | ⬜ |
| 15.2 | Check page load | Trang load không lỗi | ⬜ |
| 15.3 | Check form settings | Form hiển thị | ⬜ |
| 15.4 | Check site name field | Field hiển thị, điền được | ⬜ |
| 15.5 | Check logo upload | Upload hoạt động | ⬜ |
| 15.6 | Check email settings | Fields hiển thị | ⬜ |
| 15.7 | Check timezone dropdown | Dropdown hoạt động | ⬜ |
| 15.8 | Click "Lưu thay đổi" | Lưu thành công, toast hiển thị | ⬜ |

---

### 🔍 TEST 16: TÌM KIẾM
**File:** `InformationWeb/Pages/Cms/Search.aspx`
**Control:** `InformationWeb/Controls/Cms/Search.ascx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 16.1 | Click search icon topbar | Chuyển đến `/cms/search` | ⬜ |
| 16.2 | Check page load | Trang load không lỗi | ⬜ |
| 16.3 | Check search input | Input hiển thị | ⬜ |
| 16.4 | Enter keyword | Input điền thành công | ⬜ |
| 16.5 | Click "Tìm kiếm" hoặc Enter | Kết quả hiển thị | ⬜ |
| 16.6 | Check filter tabs | Tabs (Tất cả, Môn học, Học viên...) hiển thị | ⬜ |
| 16.7 | Click tab filter | Filter hoạt động | ⬜ |

---

### 📂 TEST 17: COURSE CATEGORIES
**File:** `InformationWeb/Pages/Cms/CourseCategories.aspx`
**Control:** `InformationWeb/Controls/Cms/CourseCategories.ascx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 17.1 | Open `/cms/course-categories` | Trang load không lỗi | ⬜ |
| 17.2 | Check tree categories | Tree hiển thị | ⬜ |
| 17.3 | Check nút "Thêm danh mục" | Nút hiển thị | ⬜ |
| 17.4 | Click "Thêm danh mục" | Form thêm hiển thị | ⬜ |
| 17.5 | Điền tên danh mục | Field hoạt động | ⬜ |
| 17.6 | Click "Lưu" | Lưu thành công | ⬜ |

---

### 📖 TEST 18: COURSE LIBRARY
**File:** `InformationWeb/Pages/Cms/CourseLibrary.aspx`
**Control:** `InformationWeb/Controls/Cms/CourseLibrary.ascx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 18.1 | Open `/cms/course-library` | Trang load không lỗi | ⬜ |
| 18.2 | Check grid courses | Grid hiển thị | ⬜ |
| 18.3 | Check nút "Import" | Nút hiển thị | ⬜ |
| 18.4 | Check nút "Export" | Nút hiển thị | ⬜ |

---

### 📈 TEST 19: COURSE PROGRESS
**File:** `InformationWeb/Pages/Cms/CourseProgress.aspx`
**Control:** `InformationWeb/Controls/Cms/CourseProgress.ascx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 19.1 | Open `/cms/course-progress` | Trang load không lỗi | ⬜ |
| 19.2 | Check progress table | Table hiển thị | ⬜ |
| 19.3 | Check filter student | Filter hoạt động | ⬜ |
| 19.4 | Check filter course | Filter hoạt động | ⬜ |

---

### 🎨 TEST 20: CONTENT BUILDER
**File:** `InformationWeb/Pages/Cms/ContentBuilder.aspx`
**Control:** `InformationWeb/Controls/Cms/ContentBuilder.ascx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 20.1 | Open `/cms/content-builder` | Trang load không lỗi | ⬜ |
| 20.2 | Check editor toolbar | Toolbar hiển thị | ⬜ |
| 20.3 | Check content area | Area hiển thị | ⬜ |
| 20.4 | Click nút "Bold" | Text in đậm | ⬜ |
| 20.5 | Click nút "Insert Image" | Image picker mở | ⬜ |
| 20.6 | Click "Lưu" | Lưu thành công | ⬜ |

---

### 🚪 TEST 21: ĐĂNG XUẤT CMS
**File:** `InformationWeb/Pages/Auth/Logout.aspx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 21.1 | Click nút logout topbar | Chuyển đến `/logout` | ⬜ |
| 21.2 | Check redirect | Redirect về `/login` | ⬜ |
| 21.3 | Check session cleared | Session cleared, phải login lại | ⬜ |

---

## 📝 AI-2: LMS TEST CASES

### 🔐 TEST 1: ĐĂNG NHẬP HỌC VIÊN
**File:** `InformationWeb/Pages/Auth/Login.aspx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 1.1 | Mở trang `/login` | Hiển thị form đăng nhập | ⬜ |
| 1.2 | Nhập username học viên | Field điền thành công | ⬜ |
| 1.3 | Nhập password: `123456` | Field điền thành công | ⬜ |
| 1.4 | Click nút "Đăng nhập" | Chuyển hướng đến `/lms/dashboard` | ⬜ |
| 1.5 | Kiểm tra URL | URL = `/lms/dashboard` | ⬜ |
| 1.6 | Kiểm tra navbar LMS | Navbar học viên hiển thị | ⬜ |

---

### 📊 TEST 2: LMS DASHBOARD
**File:** `InformationWeb/Pages/Lms/Dashboard.aspx`
**Control:** `InformationWeb/Controls/Lms/Dashboard.ascx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 2.1 | Check page load | Trang load không lỗi | ⬜ |
| 2.2 | Check welcome section | Hiển thị "Chào [Tên học viên]" | ⬜ |
| 2.3 | Check progress ring | Hiển thị % tiến độ | ⬜ |
| 2.4 | Check stat cards | Cards (Môn học, Hoàn thành...) hiển thị | ⬜ |
| 2.5 | Check "Tiếp tục học" button | Button hiển thị, click được | ⬜ |
| 2.6 | Click "Tiếp tục học" | Chuyển đến bài học gần nhất | ⬜ |
| 2.7 | Check enrolled courses list | List môn học đã đăng ký hiển thị | ⬜ |
| 2.8 | Check card môn học | Card hiển thị (Tên, tiến độ, ảnh) | ⬜ |
| 2.9 | Click "Mở môn học" | Chuyển đến trang môn học | ⬜ |
| 2.10 | Check notification bell | Bell hiển thị, badge count | ⬜ |
| 2.11 | Click notification bell | Panel thông báo hiển thị | ⬜ |

---

### 📚 TEST 3: MÔN HỌC CỦA TÔI
**File:** `InformationWeb/Pages/Lms/Courses.aspx`
**Control:** `InformationWeb/Controls/Lms/Courses.ascx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 3.1 | Click menu "Môn học của tôi" | Chuyển đến `/lms/courses` | ⬜ |
| 3.2 | Check page load | Trang load không lỗi | ⬜ |
| 3.3 | Check grid/list courses | Hiển thị danh sách môn học | ⬜ |
| 3.4 | Check filter category | Filter dropdown hoạt động | ⬜ |
| 3.5 | Check search box | Search box hoạt động | ⬜ |
| 3.6 | Enter keyword search | Grid filter theo keyword | ⬜ |
| 3.7 | Check card course info | Hiển thị (Tên, mô tả, tiến độ) | ⬜ |
| 3.8 | Click card course | Chuyển đến trang chi tiết môn học | ⬜ |
| 3.9 | Check progress bar | Progress bar hiển thị % | ⬜ |

---

### 📖 TEST 4: CHI TIẾT MÔN HỌC
**File:** `InformationWeb/Pages/Lms/Course.aspx`
**Control:** `InformationWeb/Controls/Lms/Course.ascx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 4.1 | Open `/lms/course?id=1` | Trang load không lỗi | ⬜ |
| 4.2 | Check course header | Hiển thị tên môn học | ⬜ |
| 4.3 | Check course description | Hiển thị mô tả | ⬜ |
| 4.4 | Check instructor info | Hiển thị thông tin giảng viên | ⬜ |
| 4.5 | Check syllabus list | List bài giảng hiển thị | ⬜ |
| 4.6 | Check lesson status | Icons (Đã học, Đang học, Chưa học) hiển thị | ⬜ |
| 4.7 | Click lesson "Đang học" | Chuyển đến Lesson Player | ⬜ |
| 4.8 | Click lesson "Chưa học" | Chuyển đến Lesson Player | ⬜ |
| 4.9 | Check "Bắt đầu học" button | Button hiển thị cho môn mới | ⬜ |

---

### 🎬 TEST 5: LESSON PLAYER
**File:** `InformationWeb/Pages/Lms/LessonPlayer.aspx`
**Control:** `InformationWeb/Controls/Lms/LessonPlayer.ascx`

| Step | Action | Expected Result | Status |
|------|------|-----------------|--------|
| 5.1 | Open `/lms/lesson?id=1` | Trang load không lỗi | ⬜ |
| 5.2 | Check video player | Player hiển thị | ⬜ |
| 5.3 | Click "Play" | Video phát | ⬜ |
| 5.4 | Click "Pause" | Video dừng | ⬜ |
| 5.5 | Check progress bar | Progress bar cập nhật | ⬜ |
| 5.6 | Check volume control | Volume điều chỉnh được | ⬜ |
| 5.7 | Check fullscreen button | Fullscreen hoạt động | ⬜ |
| 5.8 | Check lesson content area | Nội dung bài học hiển thị | ⬜ |
| 5.9 | Check attachments list | File đính kèm hiển thị (nếu có) | ⬜ |
| 5.10 | Click attachment | Download/mở file | ⬜ |
| 5.11 | Check navigation buttons | "Bài trước", "Bài sau" hiển thị | ⬜ |
| 5.12 | Click "Bài trước" | Chuyển đến bài trước | ⬜ |
| 5.13 | Click "Bài sau" | Chuyển đến bài sau | ⬜ |
| 5.14 | Check "Đánh dấu hoàn thành" button | Button hiển thị | ⬜ |
| 5.15 | Click "Đánh dấu hoàn thành" | Lesson đánh dấu hoàn thành | ⬜ |
| 5.16 | Check quiz section (nếu có) | Quiz hiển thị sau bài học | ⬜ |
| 5.17 | Click "Bắt đầu quiz" | Quiz form hiển thị | ⬜ |
| 5.18 | Select answer | Option selected | ⬜ |
| 5.19 | Click "Nộp bài" | Kết quả hiển thị | ⬜ |

---

### 📊 TEST 6: KẾT QUẢ
**File:** `InformationWeb/Pages/Lms/Results.aspx`
**Control:** `InformationWeb/Controls/Lms/Results.ascx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 6.1 | Click menu "Kết quả" | Chuyển đến `/lms/results` | ⬜ |
| 6.2 | Check page load | Trang load không lỗi | ⬜ |
| 6.3 | Check results table | Table hiển thị kết quả các môn | ⬜ |
| 6.4 | Check columns (Môn học, Điểm, Ngày nộp) | Columns hiển thị đúng | ⬜ |
| 6.5 | Check filter môn học | Filter dropdown hoạt động | ⬜ |
| 6.6 | Check filter thời gian | Date picker hoạt động | ⬜ |
| 6.7 | Click row kết quả | Hiển thị chi tiết | ⬜ |
| 6.8 | Check badge trạng thái | Badge (Đạt, Chưa đạt) hiển thị | ⬜ |
| 6.9 | Check nút "Xem chi tiết" | Nút hiển thị, click được | ⬜ |
| 6.10 | Click "Xem chi tiết" | Modal chi tiết hiển thị | ⬜ |

---

### 👤 TEST 7: HỒ SƠ HỌC VIÊN
**File:** `InformationWeb/Pages/Lms/Profile.aspx`
**Control:** `InformationWeb/Controls/Lms/Profile.ascx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 7.1 | Click avatar hoặc menu profile | Chuyển đến `/lms/profile` | ⬜ |
| 7.2 | Check page load | Trang load không lỗi | ⬜ |
| 7.3 | Check profile info | Hiển thị (Tên, Email, Mã SV) | ⬜ |
| 7.4 | Check avatar image | Avatar hiển thị | ⬜ |
| 7.5 | Check nút "Đổi avatar" | Nút hiển thị, click được | ⬜ |
| 7.6 | Click "Đổi avatar" | File picker mở | ⬜ |
| 7.7 | Select file | File selected | ⬜ |
| 7.8 | Click "Lưu" | Avatar cập nhật | ⬜ |
| 7.9 | Check form chỉnh sửa thông tin | Form hiển thị | ⬜ |
| 7.10 | Điền tên mới | Field hoạt động | ⬜ |
| 7.11 | Điền email mới | Field hoạt động | ⬜ |
| 7.12 | Điền số điện thoại | Field hoạt động | ⬜ |
| 7.13 | Click "Lưu thay đổi" | Lưu thành công, toast hiển thị | ⬜ |
| 7.14 | Check section "Đổi mật khẩu" | Section hiển thị | ⬜ |
| 7.15 | Nhập mật khẩu cũ | Field hoạt động | ⬜ |
| 7.16 | Nhập mật khẩu mới | Field hoạt động | ⬜ |
| 7.17 | Nhập xác nhận mật khẩu | Field hoạt động | ⬜ |
| 7.18 | Click "Đổi mật khẩu" | Đổi thành công, thông báo hiển thị | ⬜ |

---

### 🔔 TEST 8: THÔNG BÁO
**Location:** Navbar LMS

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 8.1 | Check notification bell | Bell hiển thị với badge count | ⬜ |
| 8.2 | Click notification bell | Panel thông báo mở | ⬜ |
| 8.3 | Check notification list | List thông báo hiển thị | ⬜ |
| 8.4 | Check notification item | Hiển thị (Tiêu đề, Thời gian) | ⬜ |
| 8.5 | Click notification item | Đánh dấu đã đọc, chuyển đến liên kết | ⬜ |
| 8.6 | Click "Đọc tất cả" | Tất cả đánh dấu đã đọc | ⬜ |
| 8.7 | Click outside panel | Panel đóng | ⬜ |

---

### 📱 TEST 9: RESPONSIVE DESIGN (MOBILE)
**Device:** Mobile view

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 9.1 | View on mobile viewport | Layout thích ứng | ⬜ |
| 9.2 | Check navbar toggle | Hamburger menu hiển thị | ⬜ |
| 9.3 | Click hamburger menu | Menu dropdown mở | ⬜ |
| 9.4 | Click menu item | Menu đóng, chuyển trang | ⬜ |
| 9.5 | Check card layout | Cards stack vertical | ⬜ |
| 9.6 | Check video player | Player responsive | ⬜ |
| 9.7 | Check forms | Forms responsive | ⬜ |

---

### 🎯 TEST 10: QUIZ FLOW (LUỒNG LÀM BÀI TEST)
**Flow:** Từ Lesson Player đến Quiz

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 10.1 | Mở Lesson có quiz | Lesson load | ⬜ |
| 10.2 | Hoàn thành lesson content | Content hiển thị | ⬜ |
| 10.3 | Click "Bắt đầu quiz" | Quiz form hiển thị | ⬜ |
| 10.4 | Check question display | Câu hỏi hiển thị | ⬜ |
| 10.5 | Check options | Các đáp án hiển thị | ⬜ |
| 10.6 | Select option | Option selected | ⬜ |
| 10.7 | Click "Tiếp theo" | Chuyển câu tiếp theo | ⬜ |
| 10.8 | Check question counter | "Câu X/Y" hiển thị | ⬜ |
| 10.9 | Check timer (nếu có) | Timer đếm ngược | ⬜ |
| 10.10 | Answer all questions | Hoàn thành tất cả câu | ⬜ |
| 10.11 | Click "Nộp bài" | Confirm hiển thị | ⬜ |
| 10.12 | Confirm submit | Kết quả hiển thị | ⬜ |
| 10.13 | Check score | Điểm hiển thị | ⬜ |
| 10.14 | Check correct/incorrect | Đáp án đúng/sai hiển thị | ⬜ |
| 10.15 | Click "Xem lại" | Review answers hiển thị | ⬜ |
| 10.16 | Click "Quay lại môn học" | Chuyển về trang môn học | ⬜ |

---

### 🔄 TEST 11: CONTINUE LEARNING FLOW
**Flow:** Tiếp tục học từ dashboard

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 11.1 | Mở LMS Dashboard | Dashboard load | ⬜ |
| 11.2 | Check "Tiếp tục học" button | Button hiển thị | ⬜ |
| 11.3 | Click "Tiếp tục học" | Chuyển đến lesson gần nhất | ⬜ |
| 11.4 | Check lesson resume | Video resume tại vị trí cũ | ⬜ |
| 11.5 | Hoàn thành lesson | Lesson complete | ⬜ |
| 11.6 | Click "Bài tiếp theo" | Chuyển lesson tiếp theo | ⬜ |
| 11.7 | Check progress update | Progress cập nhật | ⬜ |

---

### 🚪 TEST 12: ĐĂNG XUẤT LMS
**File:** `InformationWeb/Pages/Auth/Logout.aspx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 12.1 | Click nút logout navbar | Chuyển đến `/logout` | ⬜ |
| 12.2 | Check redirect | Redirect về `/login` | ⬜ |
| 12.3 | Check session cleared | Session cleared, phải login lại | ⬜ |

---

## 🔗 CROSS-MODULE TESTS (BOTH AI)

### TEST 1: ADMIN TẠO MÔN HỌC → HỌC VIÊN THẤY MÔN HỌC
| Step | Action | Expected Result | AI |
|------|--------|-----------------|-----|
| 1 | Admin tạo môn học mới | Môn học tạo thành công | AI-1 |
| 2 | Admin gán học viên vào môn | Gán thành công | AI-1 |
| 3 | Học viên đăng nhập | Login thành công | AI-2 |
| 4 | Học viên mở "Môn học của tôi" | Môn học mới hiển thị | AI-2 |

### TEST 2: ADMIN TẠO QUIZ → HỌC VIÊN LÀM QUIZ
| Step | Action | Expected Result | AI |
|------|--------|-----------------|-----|
| 1 | Admin tạo quiz | Quiz tạo thành công | AI-1 |
| 2 | Admin gán quiz vào lesson | Gán thành công | AI-1 |
| 3 | Học viên mở lesson | Lesson load | AI-2 |
| 4 | Học viên làm quiz | Quiz hiển thị, làm được | AI-2 |
| 5 | Học viên nộp bài | Kết quả hiển thị | AI-2 |
| 6 | Admin xem kết quả | Kết quả hiển thị ở Reports | AI-1 |

### TEST 3: ADMIN CHẤM BÀI → HỌC VIÊN XEM KẾT QUẢ
| Step | Action | Expected Result | AI |
|------|--------|-----------------|-----|
| 1 | Học viên nộp assignment | Nộp thành công | AI-2 |
| 2 | Admin mở "Chấm và trả bài" | List bài nộp hiển thị | AI-1 |
| 3 | Admin chấm điểm | Chấm thành công | AI-1 |
| 4 | Học viên mở "Kết quả" | Điểm cập nhật | AI-2 |

---

## 📊 REPORTING FORMAT

### Mẫu báo cáo cho AI:

```markdown
## BÁO CÁO TEST - [AI-1 / AI-2]
**Ngày:** [DD/MM/YYYY]
**Thời gian bắt đầu:** [HH:MM]
**Thời gian kết thúc:** [HH:MM]

### TỔNG QUAN
- Tổng số test case: [X]
- Đã test: [Y]
- Pass: [Z]
- Fail: [W]
- Skip: [V]

### CHI TIẾT CÁC TEST CASE

#### [Tên Module]
| Test | Action | Expected | Actual | Status |
|------|--------|----------|--------|--------|
| 1.1 | [Action] | [Expected] | [Actual] | ✅/❌ |

### VẤN ĐỀ PHÁT HIỆN
1. [Mô tả lỗi]
   - File: [File path]
   - Step: [Step số]
   - Severity: [High/Medium/Low]

### GỢI Ý CẢI THIỆN
1. [Gợi ý]
```

---

## 📌 GHI CHÚ CHO AI

### Quy tắc test:
1. **Sequential:** Test theo thứ tự từ trên xuống
2. **Stop on error:** Nếu gặp lỗi nghiêm trọng, dừng và ghi nhận
3. **Screenshot:** Chụp màn hình khi gặp lỗi (nếu có thể)
4. **Detail:** Ghi chi tiết actual result khi khác expected
5. **Navigation:** Luôn kiểm tra URL sau mỗi action chuyển trang
6. **Loading:** Chờ page load hoàn toàn trước khi check element
7. **Responsive:** Test trên cả desktop và mobile view
8. **Edge cases:** Test với dữ liệu rỗng, dữ liệu đặc biệt

### Priority:
- **P0 (Critical):** Login, Navigation, Core flow
- **P1 (High):** CRUD operations, Quiz flow
- **P2 (Medium):** Filter, Search, Export
- **P3 (Low):** UI polish, Animation

---

## 🎯 CHECKLIST HOÀN THÀNH

### AI-1 Checklist:
- [ ] Test 1: Đăng nhập Admin
- [ ] Test 2: CMS Dashboard
- [ ] Test 3: Cơ cấu đào tạo
- [ ] Test 4: Soạn môn học lớp
- [ ] Test 5: Thư viện video
- [ ] Test 6: Video Editor
- [ ] Test 7: Ngân hàng câu hỏi
- [ ] Test 8: Quiz Management
- [ ] Test 9: Danh sách học viên
- [ ] Test 10: Enrollments
- [ ] Test 11: Chấm và trả bài
- [ ] Test 12: Tiến độ và báo cáo
- [ ] Test 13: Người dùng
- [ ] Test 14: Phân quyền
- [ ] Test 15: Cài đặt
- [ ] Test 16: Tìm kiếm
- [ ] Test 17: Course Categories
- [ ] Test 18: Course Library
- [ ] Test 19: Course Progress
- [ ] Test 20: Content Builder
- [ ] Test 21: Đăng xuất CMS

### AI-2 Checklist:
- [ ] Test 1: Đăng nhập Học viên
- [ ] Test 2: LMS Dashboard
- [ ] Test 3: Môn học của tôi
- [ ] Test 4: Chi tiết môn học
- [ ] Test 5: Lesson Player
- [ ] Test 6: Kết quả
- [ ] Test 7: Hồ sơ học viên
- [ ] Test 8: Thông báo
- [ ] Test 9: Responsive Design
- [ ] Test 10: Quiz Flow
- [ ] Test 11: Continue Learning Flow
- [ ] Test 12: Đăng xuất LMS

---

**Tài liệu này được tạo để hỗ trợ 2 AI test song song toàn bộ luồng LMS system.**
