# Claude AI Configuration for NAM SÀI GÒN -WB Project

## 📁 Cấu trúc

```
.claude/
├── settings.json          # Cấu hình chính (denylist, instructions)
├── README.md             # File này
└── skills/               # Các skill tùy chỉnh
    ├── using-superpowers.md  # Kích hoạt khả năng chuyên sâu
    ├── ponytail.md            # Giải quyết task nhanh
    ├── run-app.md             # Khởi động ứng dụng
    ├── find-code.md           # Tìm kiếm code
    ├── fix-bug.md             # Debug và fix lỗi
    ├── sql-helper.md          # Quản lý SQL
    ├── code-review.md         # Review code
    ├── add-feature.md         # Thêm tính năng mới
    └── project-info.md        # Thông tin dự án
```

## ⚙️ Cấu hình (settings.json)

### QUY TẮC TUYỆT ĐỐI (BẮT BUỘC TUÂN THỦ):

1. ❌ **CHỈ ĐƯỢC LÀM VIỆC TRÊN Ổ ĐĨA G**
   - Không truy cập ổ C, D, E, F, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z

2. ✅ **CHỈ LÀM VIỆC TRONG THƯ MỤC DỰ ÁN HIỆN TẠI**
   - Path: `G:\1.1-PROJECT-MAIN\NAM SÀI GÒN -WB`
   - Không lan man sang các thư mục khác trên ổ G

3. 🔒 **MỖI PROJECT ĐỘC LẬP**
   - Chỉ đọc/viết trong thư mục của project hiện tại
   - Không đọc thông tin từ project khác
   - Không truy cập thư mục project khác

4. 📝 **QUY TẮC LÀM VIỆC**
   - Ưu tiên đọc file trước khi edit
   - Kiểm tra lỗi cú pháp C# và ASPX
   - Hiểu cấu trúc solution .NET

## 🚀 Các Skill có sẵn

### 1. `/using-superpowers`
Kích hoạt khả năng phân tích sâu, tối ưu, review kiến trúc

### 2. `/ponytail`
Giải quyết task nhanh chóng và linh hoạt

### 3. `/run-app`
Khởi động ứng dụng Web hoặc WinForm để test

### 4. `/find-code`
Tìm kiếm file, class, method, text trong codebase

### 5. `/fix-bug`
Debug và sửa lỗi trong code

### 6. `/sql-helper`
Quản lý và làm việc với script SQL

### 7. `/code-review`
Review code để cải thiện chất lượng (low|medium|high|xhigh|max)

### 8. `/add-feature`
Thêm tính năng mới vào dự án

### 9. `/project-info`
Hiển thị thông tin tổng quan về dự án

## 📋 Cấu trúc dự án

```
NAM SÀI GÒN -WB/
├── 1.WEB/         # ASP.NET Web Forms Application
├── 2.WIN-FORM/    # Windows Forms Application
└── sql/           # SQL Scripts
```

## 💡 Cách sử dụng

Gọi skill bằng cách mention tên skill trong prompt:

```
/ponytail
Task: Tìm file Login.aspx
```

```
/code-review
Level: high
Path: 1.WEB/Pages/
```

```
/project-info
Detail: full
```

## 🔒 Security & Quy tắc truy cập

### Quy tắc truy cập:
- ✅ **CHỈ** được làm việc trên ổ đĩa G
- ✅ **CHỈ** được truy cập thư mục dự án hiện tại: `G:\1.1-PROJECT-MAIN\NAM SÀI GÒN -WB`
- ❌ **KHÔNG** được truy cập ổ C, D, E, F, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z
- ❌ **KHÔNG** được lan man sang các thư mục khác trên ổ G
- ❌ **KHÔNG** được đọc thông tin từ project khác

### Quy tắc làm việc:
- AI sẽ tuân thủ denylist trong settings.json
- Không tự động chạy lệnh nguy hiểm
- Luôn confirm trước khi sửa code quan trọng
- Mỗi project độc lập, không chia sẻ thông tin
