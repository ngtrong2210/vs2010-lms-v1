---
description: Debug và fix lỗi trong code C# và ASPX
---

# Fix Bug

Phát hiện và sửa lỗi trong dự án ASP.NET hoặc WinForm.

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
/fix-bug
File: [path/to/file]
Error: [mô tả lỗi hoặc error message]
```

## Quy trình

1. **Đọc file**: Đọc file chứa lỗi (chỉ trong project)
2. **Phân tích**: Hiểu logic và tìm nguyên nhân (chỉ trong project)
3. **Đề xuất fix**: Đưa ra giải pháp (chỉ cho project hiện tại)
4. **Áp dụng**: Sửa code (khi được xác nhận) (chỉ trong project)
5. **Kiểm tra**: Verify fix (chỉ trong project)

## Các loại lỗi thường gặp

- **Compile Error**: Lỗi biên dịch C# (chỉ trong project)
- **Runtime Error**: Lỗi khi chạy (chỉ trong project)
- **SQL Error**: Lỗi query database (chỉ trong project)
- **NullReference**: Lỗi null reference (chỉ trong project)
- **Connection Error**: Lỗi kết nối DB (chỉ trong project)
- **ViewState Error**: Lỗi ASP.NET ViewState (chỉ trong project)

## Ví dụ

```
/fix-bug
File: 1.WEB/Pages/Login.aspx.cs
Error: Object reference not set to an instance of an object
```
