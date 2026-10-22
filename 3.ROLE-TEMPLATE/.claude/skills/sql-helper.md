---
description: Quản lý và chạy script SQL trong thư mục sql
---

# SQL Helper

Giúp làm việc với file SQL trong thư mục `sql/` của dự án.

## QUY TẮC TUYỆT ĐỐI (BẮT BUỘC TUÂN THỦ):

1. ❌ **CHỈ ĐƯỢC LÀM VIỆC TRÊN Ổ ĐĨA G**
   - Không truy cập ổ C, D, E, F, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z

2. ✅ **CHỈ LÀM VIỆC TRONG THƯ MỤC DỰ ÁN HIỆN TẠI**
   - Path: `G:\1.1-PROJECT-MAIN\NAM SÀI GÒN -WB`
   - Không lan man sang các thư mục khác trên ổ G

3. 🔒 **MỖI PROJECT ĐỘC LẬP**
   - Chỉ đọc/viết trong thư mục của project hiện tại
   - Không đọc thông tin từ project khác
   - Không truy cập thư mục project khác

## Cách sử dụng

```
/sql-helper
Action: read|run|analyze
File: [file.sql]
```

## Các hành động

### read
Đọc và hiểu script SQL (chỉ trong project)
```
/sql-helper
Action: read
File: sql/create-table.sql
```

### analyze
Phân tích script SQL, kiểm tra syntax (chỉ trong project)
```
/sql-helper
Action: analyze
File: sql/data-insert.sql
```

### create
Tạo script SQL mới (chỉ trong project)
```
/sql-helper
Action: create
Type: table|view|procedure|data
Name: [tên]
```

## Chức năng

- Đọc file SQL từ thư mục `sql/` (chỉ trong project)
- Phân tích cú pháp SQL (chỉ trong project)
- Kiểm tra potential issues (chỉ trong project)
- Gợi ý tối ưu query (chỉ cho project hiện tại)
- Tạo script SQL mới (chỉ trong project)

## Lưu ý

- Chỉ làm việc với file trong thư mục `sql/` của project hiện tại
- Không kết nối trực tiếp database (chỉ tạo/đọc script)
- Backup script trước khi sửa
- Không truy cập thư mục sql của project khác
