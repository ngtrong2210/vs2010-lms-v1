---
description: Khởi động và chạy ứng dụng ASP.NET hoặc WinForm
---

# Run App

Khởi động ứng dụng để test và xem kết quả.

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
/run-app
Target: web|winform
```

## Chức năng

### cho Web (ASP.NET)
- Mở solution file (.sln) (chỉ trong project)
- Build project (chỉ trong project)
- Khởi động IIS Express hoặc Development Server (chỉ cho project)
- Mở browser tại localhost

### cho WinForm
- Build project (chỉ trong project)
- Chạy executable (chỉ trong project)
- Test UI và functionality (chỉ project hiện tại)

## Quy trình

1. Tìm file .sln hoặc .csproj (chỉ trong project)
2. Build solution (dotnet build hoặc MSBuild) (chỉ trong project)
3. Khởi động server hoặc chạy exe (chỉ cho project)
4. Mở browser hoặc ứng dụng
5. Báo kết quả

## Ví dụ

```
/run-app
Target: web
```
