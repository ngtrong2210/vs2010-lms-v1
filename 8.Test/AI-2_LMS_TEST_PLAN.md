# AI-2: LMS TEST PLAN
## Module: Học viên (Student)
**Ngày tạo:** 2026-09-01
**Phiên bản:** 1.0

---

## 📋 TỔNG QUAN

### Mục tiêu test
- Test toàn bộ luồng học viên của hệ thống LMS
- Kiểm tra chức năng menu, nút, và view loading module LMS
- Xác nhận tính ổn định của từng trang học viên

### Thông tin hệ thống
- **Project Path:** `G:\0.DỰ ÁN\2.LMS-VS2010\WEB-LMS-VS2010\1. WEB-LMS-VS2010`
- **Solution:** WEB-LMS-VS2010.sln
- **Framework:** ASP.NET WebForms + C#
- **Database:** SQL Server

### Tài khoản test mặc định
- **Username:** [Tài khoản học viên - tạo mới hoặc dùng tài khoản test]
- **Password:** [Mật khẩu tương ứng]

---

## 📝 LMS TEST CASES

### 🔐 TEST 1: ĐĂNG NHẬP HỌC VIÊN
**File:** `InformationWeb/Pages/Auth/Login.aspx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 1.1 | Mở trang `/login` | Hiển thị form đăng nhập | ⬜ |
| 1.2 | Nhập username học viên | Field điền thành công | ⬜ |
| 1.3 | Nhập password | Field điền thành công | ⬜ |
| 1.4 | Click nút "Đăng nhập" | Chuyển hướng đến `/lms/dashboard` | ⬜ |
| 1.5 | Kiểm tra URL | URL = `/lms/dashboard` | ⬜ |
| 1.6 | Kiểm tra hiển thị navbar | Navbar LMS hiển thị | ⬜ |

---

### 📊 TEST 2: LMS DASHBOARD (TRANG CHỦ)
**File:** `InformationWeb/Pages/Lms/Dashboard.aspx`
**Control:** `InformationWeb/Controls/Lms/Dashboard.ascx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 2.1 | Check page load | Trang load không lỗi | ⬜ |
| 2.2 | Check danh sách môn học | Hiển thị môn học đang học | ⬜ |
| 2.3 | Check tiến độ học tập | Hiển thị tiến độ (progress bar) | ⬜ |
| 2.4 | Check thống kê cards | Hiển thị số môn học, giờ học... | ⬜ |
| 2.5 | Check menu item active | Menu "Trang chủ" active | ⬜ |
| 2.6 | Check thông báo | Panel thông báo hiển thị nếu có | ⬜ |
| 2.7 | Click card môn học | Chuyển đến trang chi tiết môn học | ⬜ |

---

### 📚 TEST 3: DANH SÁCH MÔN HỌC
**File:** `InformationWeb/Pages/Lms/Courses.aspx`
**Control:** `InformationWeb/Controls/Lms/Courses.ascx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 3.1 | Click menu "Môn học" | Chuyển đến `/lms/courses` | ⬜ |
| 3.2 | Check page load | Trang load không lỗi | ⬜ |
| 3.3 | Check grid/list courses | Hiển thị danh sách môn học | ⬜ |
| 3.4 | Check filter môn học | Filter hiển thị và hoạt động | ⬜ |
| 3.5 | Check search box | Search box hoạt động | ⬜ |
| 3.6 | Enter keyword search | Grid filter theo keyword | ⬜ |
| 3.7 | Click card môn học | Chuyển đến `/lms/course/[id]` | ⬜ |
| 3.8 | Check nút "Tiếp tục học" | Nút hiển thị trên môn học đang học | ⬜ |

---

### 📖 TEST 4: CHI TIẾT MÔN HỌC
**File:** `InformationWeb/Pages/Lms/CourseDetail.aspx`
**Control:** `InformationWeb/Controls/Lms/CourseDetail.ascx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 4.1 | Open `/lms/course/[id]` | Trang load không lỗi | ⬜ |
| 4.2 | Check thông tin môn học | Hiển thị tên, mô tả, giảng viên | ⬜ |
| 4.3 | Check danh sách lessons | Hiển thị các bài học (lessons) | ⬜ |
| 4.4 | Check progress bar | Hiển thị tiến độ hoàn thành | ⬜ |
| 4.5 | Click lesson | Chuyển đến `/lms/lesson/[id]` | ⬜ |
| 4.6 | Check nút "Bắt đầu học" | Nút hiển thị nếu chưa học | ⬜ |
| 4.7 | Check nút "Tiếp tục" | Nút hiển thị nếu đang học | ⬜ |

---

### 🎥 TEST 5: LESSON - XEM BÀI GIẢNG
**File:** `InformationWeb/Pages/Lms/Lesson.aspx`
**Control:** `InformationWeb/Controls/Lms/Lesson.ascx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 5.1 | Open `/lms/lesson/[id]` | Trang load không lỗi | ⬜ |
| 5.2 | Check video player | Player hiển thị nếu có video | ⬜ |
| 5.3 | Check content text | Nội dung bài học hiển thị | ⬜ |
| 5.4 | Check nút "Play" video | Video phát khi click | ⬜ |
| 5.5 | Check nút "Pause" | Video dừng khi click | ⬜ |
| 5.6 | Check timeline video | Timeline hoạt động, có thể seek | ⬜ |
| 5.7 | Check nút "Đánh dấu hoàn thành" | Nút hiển thị và click được | ⬜ |
| 5.8 | Click "Đánh dấu hoàn thành" | Lesson đánh dấu hoàn thành | ⬜ |
| 5.9 | Check nút "Lesson tiếp theo" | Nút hiển thị | ⬜ |
| 5.10 | Click "Lesson tiếp theo" | Chuyển đến lesson kế tiếp | ⬜ |

---

### 📝 TEST 6: LESSON - TÀI LIỆU TẢI XUỐNG
**File:** `InformationWeb/Pages/Lms/Lesson.aspx`
**Control:** `InformationWeb/Controls/Lms/Lesson.ascx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 6.1 | Scroll đến section tài liệu | Section tài liệu hiển thị | ⬜ |
| 6.2 | Check list files | Danh sách file hiển thị | ⬜ |
| 6.3 | Check nút "Download" | Nút hiển thị trên từng file | ⬜ |
| 6.4 | Click "Download" | File download hoặc mở | ⬜ |
| 6.5 | Check nút "Preview" | Nút hiển thị nếu preview được | ⬜ |
| 6.6 | Click "Preview" | Modal preview hiển thị | ⬜ |

---

### ❓ TEST 7: QUIZ - LÀM BÀI KIỂM TRA
**File:** `InformationWeb/Pages/Lms/Quiz.aspx`
**Control:** `InformationWeb/Controls/Lms/Quiz.ascx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 7.1 | Open `/lms/quiz/[id]` | Trang load không lỗi | ⬜ |
| 7.2 | Check thông tin quiz | Hiển thị tên, thời gian, số câu hỏi | ⬜ |
| 7.3 | Check nút "Bắt đầu làm" | Nút hiển thị | ⬜ |
| 7.4 | Click "Bắt đầu làm" | Quiz bắt đầu, timer đếm ngược | ⬜ |
| 7.5 | Check câu hỏi hiển thị | Câu hỏi hiển thị | ⬜ |
| 7.6 | Check đáp án options | Options hiển thị (cho trắc nghiệm) | ⬜ |
| 7.7 | Select đáp án | Option được chọn | ⬜ |
| 7.8 | Check nút "Câu tiếp theo" | Nút hiển thị | ⬜ |
| 7.9 | Click "Câu tiếp theo" | Chuyển đến câu kế tiếp | ⬜ |
| 7.10 | Check nút "Câu trước" | Nút hiển thị | ⬜ |
| 7.11 | Click "Câu trước" | Quay lại câu trước | ⬜ |
| 7.12 | Check nút "Nộp bài" | Nút hiển thị ở câu cuối | ⬜ |
| 7.13 | Click "Nộp bài" | Confirm hiển thị | ⬜ |
| 7.14 | Confirm nộp bài | Bài nộp thành công, hiển thị kết quả | ⬜ |

---

### ✅ TEST 8: QUIZ - XEM KẾT QUẢ
**File:** `InformationWeb/Pages/Lms/QuizResult.aspx`
**Control:** `InformationWeb/Controls/Lms/QuizResult.ascx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 8.1 | Sau khi nộp quiz | Trang kết quả hiển thị | ⬜ |
| 8.2 | Check điểm số | Điểm số hiển thị | ⬜ |
| 8.3 | Check percent | Tỷ lệ điểm hiển thị | ⬜ |
| 8.4 | Check trạng thái pass/fail | Pass/Fail hiển thị | ⬜ |
| 8.5 | Check chi tiết từng câu | Danh sách câu + đáp án đúng/sai hiển thị | ⬜ |
| 8.6 | Check nút "Làm lại" | Nút hiển thị nếu cho phép làm lại | ⬜ |
| 8.7 | Check nút "Về môn học" | Nút hiển thị | ⬜ |
| 8.8 | Click "Về môn học" | Chuyển về course detail | ⬜ |

---

### 📤 TEST 9: BÀI TẬP - NỘP ASSIGNMENT
**File:** `InformationWeb/Pages/Lms/Assignment.aspx`
**Control:** `InformationWeb/Controls/Lms/Assignment.ascx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 9.1 | Open `/lms/assignment/[id]` | Trang load không lỗi | ⬜ |
| 9.2 | Check thông tin assignment | Hiển thị tiêu đề, mô tả, deadline | ⬜ |
| 9.3 | Check textarea đáp án | Textarea hiển thị | ⬜ |
| 9.4 | Check nút "Upload file" | Nút hiển thị | ⬜ |
| 9.5 | Click "Upload file" | File picker mở | ⬜ |
| 9.6 | Select file | File được chọn | ⬜ |
| 9.7 | Điền đáp án text | Textarea điền được | ⬜ |
| 9.8 | Check nút "Nộp bài" | Nút hiển thị | ⬜ |
| 9.9 | Click "Nộp bài" | Confirm hiển thị | ⬜ |
| 9.10 | Confirm nộp bài | Bài nộp thành công | ⬜ |
| 9.11 | Check trạng thái "Đã nộp" | Status hiển thị | ⬜ |

---

### 📋 TEST 10: ASSIGMENT - XEM KẾT QUẢ CHẤM
**File:** `InformationWeb/Pages/Lms/AssignmentResult.aspx`
**Control:** `InformationWeb/Controls/Lms/AssignmentResult.ascx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 10.1 | Mở lại assignment đã nộp | Trang hiển thị | ⬜ |
| 10.2 | Check trạng thái chấm | Hiển thị "Chưa chấm" hoặc "Đã chấm" | ⬜ |
| 10.3 | Nếu đã chấm: Check điểm | Điểm số hiển thị | ⬜ |
| 10.4 | Nếu đã chấm: Check nhận xét | Nhận xét từ giảng viên hiển thị | ⬜ |
| 10.5 | Check file đã nộp | File hiển thị, có thể download | ⬜ |
| 10.6 | Check nút "Nộp lại" | Nút hiển thị nếu cho phép nộp lại | ⬜ |

---

### 📊 TEST 11: TIẾN ĐỘ HỌC TẬP
**File:** `InformationWeb/Pages/Lms/Progress.aspx`
**Control:** `InformationWeb/Controls/Lms/Progress.ascx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 11.1 | Click menu "Tiến độ" | Chuyển đến `/lms/progress` | ⬜ |
| 11.2 | Check page load | Trang load không lỗi | ⬜ |
| 11.3 | Check tổng quan progress | Chart/table tổng quan hiển thị | ⬜ |
| 11.4 | Check progress từng môn | Danh sách môn + progress hiển thị | ⬜ |
| 11.5 | Check filter môn học | Filter hoạt động | ⬜ |
| 11.6 | Click row môn học | Hiển thị chi tiết progress môn đó | ⬜ |
| 11.7 | Check thống kê thời gian | Tổng giờ học hiển thị | ⬜ |
| 11.8 | Check số bài đã hoàn thành | Số liệu hiển thị | ⬜ |

---

### 👤 TEST 12: HỒ SƠ HỌC VIÊN
**File:** `InformationWeb/Pages/Lms/Profile.aspx`
**Control:** `InformationWeb/Controls/Lms/Profile.ascx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 12.1 | Click menu avatar/user | Dropdown menu hiển thị | ⬜ |
| 12.2 | Click "Hồ sơ" | Chuyển đến `/lms/profile` | ⬜ |
| 12.3 | Check page load | Trang load không lỗi | ⬜ |
| 12.4 | Check thông tin cá nhân | Tên, email, avatar hiển thị | ⬜ |
| 12.5 | Check nút "Chỉnh sửa" | Nút hiển thị | ⬜ |
| 12.6 | Click "Chỉnh sửa" | Form edit hiển thị | ⬜ |
| 12.7 | Điền thông tin mới | Field hoạt động | ⬜ |
| 12.8 | Click "Lưu" | Lưu thành công | ⬜ |
| 12.9 | Check nút "Đổi mật khẩu" | Nút hiển thị | ⬜ |
| 12.10 | Click "Đổi mật khẩu" | Form đổi mật khẩu hiển thị | ⬜ |
| 12.11 | Điền mật khẩu cũ + mới | Field hoạt động | ⬜ |
| 12.12 | Click "Lưu" | Đổi mật khẩu thành công | ⬜ |

---

### 🔍 TEST 13: TÌM KIẾM
**File:** `InformationWeb/Pages/Lms/Search.aspx`
**Control:** `InformationWeb/Controls/Lms/Search.ascx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 13.1 | Click search icon navbar | Search box hiển thị | ⬜ |
| 13.2 | Enter keyword | Input điền thành công | ⬜ |
| 13.3 | Click "Tìm kiếm" hoặc Enter | Kết quả hiển thị | ⬜ |
| 13.4 | Check filter tabs | Tabs (Tất cả, Môn học, Lesson...) hiển thị | ⬜ |
| 13.5 | Click tab filter | Filter hoạt động | ⬜ |
| 13.6 | Click kết quả tìm kiếm | Chuyển đến trang tương ứng | ⬜ |

---

### 🔔 TEST 14: THÔNG BÁO
**File:** `InformationWeb/Pages/Lms/Notifications.aspx`
**Control:** `InformationWeb/Controls/Lms/Notifications.ascx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 14.1 | Click bell icon navbar | Panel thông báo hiển thị | ⬜ |
| 14.2 | Check list notifications | Danh sách thông báo hiển thị | ⬜ |
| 14.3 | Check nút "Xem tất cả" | Nút hiển thị | ⬜ |
| 14.4 | Click "Xem tất cả" | Chuyển đến `/lms/notifications` | ⬜ |
| 14.5 | Check page load | Trang load không lỗi | ⬜ |
| 14.6 | Check phân loại thông báo | Tabs (Tất cả, Chưa đọc, Đã đọc) hiển thị | ⬜ |
| 14.7 | Click thông báo | Đánh dấu đã đọc, mở chi tiết | ⬜ |
| 14.8 | Check nút "Đánh dấu đã đọc tất cả" | Nút hiển thị | ⬜ |
| 14.9 | Click "Đánh dấu đã đọc tất cả" | Tất cả thông báo đã đọc | ⬜ |

---

### 🚪 TEST 15: ĐĂNG XUẤT LMS
**File:** `InformationWeb/Pages/Auth/Logout.aspx`

| Step | Action | Expected Result | Status |
|------|--------|-----------------|--------|
| 15.1 | Click menu avatar/user | Dropdown menu hiển thị | ⬜ |
| 15.2 | Click "Đăng xuất" | Confirm hiển thị | ⬜ |
| 15.3 | Confirm đăng xuất | Chuyển đến `/logout` | ⬜ |
| 15.4 | Check redirect | Redirect về `/login` | ⬜ |
| 15.5 | Check session cleared | Session cleared, phải login lại | ⬜ |

---

## 🔗 CROSS-MODULE TESTS (CÙNG AI-1)

### TEST 1: ADMIN TẠO MÔN HỌC → HỌC VIÊN THẤY MÔN HỌC
| Step | Action | Expected Result | AI |
|------|--------|-----------------|-----|
| 1 | Chờ AI-1 tạo môn học | Môn học tạo thành công | AI-1 |
| 2 | Chờ AI-1 gán học viên | Gán thành công | AI-1 |
| 3 | Học viên đăng nhập | Đăng nhập thành công | AI-2 |
| 4 | Học viên mở danh sách môn học | Thấy môn học mới | AI-2 |
| 5 | Học viên click môn học | Mở chi tiết môn học | AI-2 |

### TEST 2: ADMIN TẠO QUIZ → HỌC VIÊN LÀM QUIZ
| Step | Action | Expected Result | AI |
|------|--------|-----------------|-----|
| 1 | Chờ AI-1 tạo quiz | Quiz tạo thành công | AI-1 |
| 2 | Chờ AI-1 gán quiz vào lesson | Gán thành công | AI-1 |
| 3 | Học viên mở lesson | Lesson hiển thị quiz | AI-2 |
| 4 | Học viên click quiz | Quiz mở, có thể làm | AI-2 |
| 5 | Học viên làm và nộp quiz | Nộp thành công, kết quả hiển thị | AI-2 |
| 6 | Chờ AI-1 xem kết quả | Kết quả hiển thị ở Reports | AI-1 |

### TEST 3: ADMIN CHẤM BÀI → HỌC VIÊN XEM KẾT QUẢ
| Step | Action | Expected Result | AI |
|------|--------|-----------------|-----|
| 1 | Học viên nộp assignment | Nộp thành công | AI-2 |
| 2 | Chờ AI-1 chấm điểm | Admin chấm thành công | AI-1 |
| 3 | Học viên mở lại assignment | Điểm và nhận xét hiển thị | AI-2 |
| 4 | Học viên xem thống kê | Điểm cập nhật trong progress | AI-2 |

---

## 📊 REPORTING FORMAT

### Mẫu báo cáo:

```markdown
## BÁO CÁO TEST - AI-2 (LMS)
**Ngày:** [DD/MM/YYYY]
**Thời gian bắt đầu:** [HH:MM]
**Thời gian kết thúc:** [HH:MM]

### TỔNG QUAN
- Tổng số test case: 15
- Đã test: [X]
- Pass: [Y]
- Fail: [Z]
- Skip: [W]

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

## 📌 GHI CHÚ

### Quy tắc test:
1. **Sequential:** Test theo thứ tự từ trên xuống
2. **Stop on error:** Nếu gặp lỗi nghiêm trọng, dừng và ghi nhận
3. **Detail:** Ghi chi tiết actual result khi khác expected
4. **Navigation:** Luôn kiểm tra URL sau mỗi action chuyển trang
5. **Loading:** Chờ page load hoàn toàn trước khi check element
6. **Edge cases:** Test với dữ liệu rỗng, dữ liệu đặc biệt

### Priority:
- **P0 (Critical):** Login, Navigation, Core flow
- **P1 (High):** Learning flow (Lesson, Quiz, Assignment)
- **P2 (Medium):** Progress, Profile, Notifications
- **P3 (Low):** UI polish, Animation

### Đồng bộ với AI-1:
- Khi test cross-module, cần báo hiệu cho AI-1 khi hoàn thành step
- Chờ AI-1 hoàn thành step trước khi tiếp tục
- Ghi nhận trạng thái sync trong báo cáo

---

## 🎯 CHECKLIST HOÀN THÀNH

- [ ] Test 1: Đăng nhập học viên
- [ ] Test 2: LMS Dashboard
- [ ] Test 3: Danh sách môn học
- [ ] Test 4: Chi tiết môn học
- [ ] Test 5: Lesson - Xem bài giảng
- [ ] Test 6: Lesson - Tài liệu tải xuống
- [ ] Test 7: Quiz - Làm bài kiểm tra
- [ ] Test 8: Quiz - Xem kết quả
- [ ] Test 9: Assignment - Nộp bài
- [ ] Test 10: Assignment - Xem kết quả chấm
- [ ] Test 11: Tiến độ học tập
- [ ] Test 12: Hồ sơ học viên
- [ ] Test 13: Tìm kiếm
- [ ] Test 14: Thông báo
- [ ] Test 15: Đăng xuất LMS

---

**File này dành riêng cho AI-2 test LMS Module.**
