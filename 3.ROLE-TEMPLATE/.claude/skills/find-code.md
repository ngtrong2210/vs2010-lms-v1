---
description: Tìm kiếm code, file, và class trong dự án
---

# Find Code

Tìm kiếm nhanh các file, class, method, hoặc đoạn code trong dự án.

## Cách sử dụng

```
/find-code
Type: file|class|method|text
Query: [từ khóa tìm kiếm]
Path: [đường dẫn tùy chọn trong thư mục dự án]
```

## QUY TẮC QUAN TRỌNG

- ❌ CHỈ tìm kiếm trong thư mục dự án hiện tại
- ❌ KHÔNG tìm kiếm ở các thư mục khác trên ổ G
- ❌ KHÔNG tìm kiếm trên các ổ đĩa khác (C, D, E, etc.)
- ✅ Chỉ làm việc trong `G:\1.1-PROJECT-MAIN\NAM SÀI GÒN -WB`

## Các loại tìm kiếm

### file
Tìm file theo tên hoặc extension
```
/find-code
Type: file
Query: Login.aspx
```

### class
Tìm class C#
```
/find-code
Type: class
Query: UserService
```

### method
Tìm method trong code
```
/find-code
Type: method
Query: GetUserById
```

### text
Tìm đoạn text trong code
```
/find-code
Type: text
Query: "connectionString"
```

## Kết quả

- Liệt kê các file tìm được (chỉ trong project hiện tại)
- Hiển thị context xung quanh
- Báo số lượng kết quả
- Gợi ý file liên quan (chỉ trong project)
