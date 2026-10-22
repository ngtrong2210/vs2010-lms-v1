---
name: large-project-workflow
description: Use when preparing or executing large project work, multi-file features, refactoring, module changes, architecture decisions, release preparation, or task planning in this project.
---
# Large Project Workflow
## Mục tiêu
Giữ dự án lớn ổn định khi AI sửa nhiều file hoặc thêm chức năng mới.
## Trước khi sửa
- Xác định đúng yêu cầu của user.
- Kiểm tra luồng hiện có trước khi đề xuất code mới.
- Tìm các file liên quan: `.aspx`, `.aspx.cs`, BLL, DAL, SQL, CSS, JS.
- Ưu tiên dùng pattern sẵn có trong project.
- Không tạo kiến trúc mới nếu kiến trúc hiện tại đủ dùng.
- Nếu task lớn hoặc mơ hồ, trình bày kế hoạch ngắn trước khi sửa.
## Phạm vi thay đổi
- Sửa đúng module liên quan.
- Không rewrite toàn bộ form/page nếu chỉ cần sửa một lỗi.
- Không đổi control ID, event, binding hoặc layout server-side nếu không cần.
- Không đổi database schema nếu user chưa yêu cầu.
- Không thêm package/dependency nếu không thật sự cần.
## Khi làm feature
- Chia nhỏ theo luồng: UI, code-behind, BLL, DAL, SQL, CSS/JS.
- Mỗi phần phải có mục tiêu rõ ràng.
- Giữ compatibility .NET Framework 4 và Visual Studio 2010.
- Không dùng syntax mới.
- Không dùng ES6 trong JavaScript.
## Khi fix bug
- Tìm root cause trước.
- Kiểm tra caller hoặc page khác có dùng chung hàm.
- Fix ở shared code nếu lỗi nằm ở shared code.
- Không chỉ vá ở một page nếu bug có thể lặp lại.
## Kiểm tra sau khi sửa
- Đọc lại các file vừa sửa.
- Kiểm tra lỗi compile dễ thấy.
- Kiểm tra luồng postback/bind dữ liệu.
- Kiểm tra SQL parameter.
- Kiểm tra UI không mất server control.
- Nêu rõ phần chưa chạy test được nếu môi trường thiếu.
