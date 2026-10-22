---
description: Hiển thị thông tin tổng quan về dự án
---

# Project Info

Hiển thị thông tin chi tiết về cấu trúc và nội dung dự án.

## Cách sử dụng

```
/project-info
Detail: basic|full|architecture
```

## QUY TẮC QUAN TRỌNG

- ❌ CHỈ đọc thông tin trong thư mục dự án hiện tại
- ❌ KHÔNG đọc thông tin từ các thư mục khác trên ổ G
- ❌ KHÔNG đọc thông tin từ project khác
- ✅ Chỉ làm việc trong `G:\1.1-PROJECT-MAIN\NAM SÀI GÒN -WB`

## Các mức độ chi tiết

### basic
- Cấu trúc thư mục chính (chỉ trong project)
- Số lượng file (chỉ trong project)
- Loại project (Web/WinForm)
- Công nghệ sử dụng

### full
- Tất cả thông tin basic
- Danh sách tất cả file (chỉ trong project)
- File config chính (chỉ trong project)
- Connection strings (chỉ trong project)
- Dependencies (chỉ trong project)

### architecture
- Đồ thị structure (chỉ project hiện tại)
- Các module chính (chỉ project hiện tại)
- Flow dữ liệu (chỉ project hiện tại)
- Architecture pattern (chỉ project hiện tại)

## Thông tin hiển thị

### Thư mục
- `1.WEB/`: ASP.NET Web Forms application
- `2.WIN-FORM/`: Windows Forms application
- `sql/`: SQL scripts

### File quan trọng
- Web.config (ASP.NET config)
- App.config (WinForm config)
- Global.asax
- *.sln (Solution file)
- *.csproj (Project files)

## Ví dụ

```
/project-info
Detail: full
```
