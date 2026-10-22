---
description: Thêm tính năng mới vào dự án ASP.NET hoặc WinForm
---

# Add Feature

Thêm tính năng mới vào dự án một cách có cấu trúc.

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
/add-feature
Type: web|winform
Feature: [mô tả tính năng]
```

## Quy trình

1. **Phân tích yêu cầu**: Hiểu rõ tính năng cần thêm (chỉ trong project)
2. **Tìm vị trí**: Xác định nơi cần thêm code (chỉ trong project)
3. **Thiết kế**: Đề xuất cấu trúc code (chỉ cho project hiện tại)
4. **Implement**: Viết code (khi được xác nhận) (chỉ trong project)
5. **Test**: Kiểm tra tính năng (chỉ trong project)

## Các loại tính năng

### Web (ASP.NET)
- Thêm page mới (.aspx) (chỉ trong project)
- Thêm user control (.ascx) (chỉ trong project)
- Thêm API/Handler (chỉ trong project)
- Thêm CSS/JS (chỉ trong project)
- Thêm master page (chỉ trong project)

### WinForm
- Thêm form mới (chỉ trong project)
- Thêm control (chỉ trong project)
- Thêm event handler (chỉ trong project)
- Thêm dialog (chỉ trong project)

## Checklist

- [ ] Code behind (C#) (chỉ trong project)
- [ ] UI (ASPX or Designer) (chỉ trong project)
- [ ] CSS (nếu cần) (chỉ trong project)
- [ ] JavaScript (nếu cần) (chỉ trong project)
- [ ] Database (nếu cần) (chỉ trong project)
- [ ] Config (nếu cần) (chỉ trong project)

## Ví dụ

```
/add-feature
Type: web
Feature: Thêm trang đăng ký user mới với validation
```
