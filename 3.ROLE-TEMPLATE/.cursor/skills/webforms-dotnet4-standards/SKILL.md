---
name: webforms-dotnet4-standards
description: Use when editing ASP.NET WebForms C# code-behind, .aspx, .ascx, BLL, DAL, Web.config, validation, postback, GridView, Repeater, or server controls in this project.
---
# ASP.NET WebForms .NET 4 Standards
## Phạm vi
Áp dụng cho project ASP.NET WebForms chạy .NET Framework 4 và Visual Studio 2010.
Áp dụng khi sửa:
- `.aspx`
- `.aspx.cs`
- `.ascx`
- `.ascx.cs`
- BLL
- DAL
- `Web.config`
## Nguyên tắc bắt buộc
- Luôn tương thích Visual Studio 2010.
- Không dùng C# hiện đại.
- Không dùng `async`/`await`.
- Không dùng string interpolation.
- Ưu tiên `String.Format()`.
- Không viết SQL trực tiếp trong code-behind.
- Mọi truy cập database phải đi qua DAL.
- Giữ kiến trúc 3 lớp: Presentation, BLL, DAL.
- Giữ nguyên naming convention hiện có.
- Sửa ít nhất có thể, không rewrite module không liên quan.
## WebForms
- Luôn kiểm tra `Page.IsPostBack` trước khi load dữ liệu lần đầu.
- Giữ nguyên `ID`, `runat`, event, binding, validation control và postback.
- Không đổi designer nếu không bắt buộc.
- Không thêm inline server code nếu xử lý được trong code-behind.
- Bind `GridView` và `Repeater` bằng `DataSource` rồi `DataBind()`.
- Tránh ViewState nếu không cần.
## Code-behind
- Code-behind chỉ xử lý UI flow, validate input, gọi BLL.
- Không chứa SQL.
- Không chứa business rule lớn nếu có thể đưa sang BLL.
- Bắt lỗi thân thiện, không show raw exception ra UI.
- Giữ logging hiện có nếu project đang có.
## Validation
- Validate required fields.
- Validate kiểu dữ liệu.
- Validate độ dài input.
- Không tin dữ liệu từ `Request`, QueryString, Form hoặc Session.
## Output khi sửa code
- Giải thích logic chính trước.
- Khi đưa code cho user, ưu tiên full method code.
- Giữ indentation và format hiện có.
