---
description: Review code để cải thiện chất lượng và tìm lỗi
---

# Code Review

Review code C#, ASPX để đảm bảo chất lượng và best practices.

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
/code-review
Level: low|medium|high|xhigh|max
Path: [đường dẫn file hoặc folder trong project]
```

## Các mức độ review

### low
- Kiểm tra syntax cơ bản (chỉ trong project)
- Tìm lỗi rõ ràng (chỉ trong project)
- Quick scan (chỉ trong project)

### medium
- Kiểm tra logic (chỉ trong project)
- Best practices cơ bản (chỉ trong project)
- Naming convention (chỉ trong project)

### high
- Deep analysis (chỉ trong project)
- Performance check (chỉ trong project)
- Security review (chỉ trong project)
- Code smell detection (chỉ trong project)

### xhigh
- Full architecture review (chỉ project hiện tại)
- Design pattern check (chỉ project hiện tại)
- Dependency analysis (chỉ project hiện tại)
- Comprehensive testing (chỉ project hiện tại)

### max
- Maximum scrutiny (chỉ project hiện tại)
- All checks + optimization (chỉ project hiện tại)
- Refactoring suggestions (chỉ project hiện tại)
- Documentation review (chỉ project hiện tại)

## Các tiêu chí review

- ✅ Correctness: Code đúng logic (chỉ trong project)
- ✅ Reuse: Tái sử dụng code có sẵn (chỉ trong project)
- ✅ Simplification: Code đơn giản, dễ hiểu (chỉ trong project)
- ✅ Efficiency: Tối ưu hiệu năng (chỉ trong project)
- ✅ Security: Không có lỗ hổng (chỉ trong project)
- ✅ Maintainability: Dễ bảo trì (chỉ trong project)

## Ví dụ

```
/code-review
Level: high
Path: 1.WEB/Pages/
```
