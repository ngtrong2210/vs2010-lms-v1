---
name: quynhon-css-architecture
description: Use when editing or adding CSS, inline styles, ASP.NET WebForms markup, layout, header, menu, color, responsive UI, or visual presentation inside this WEB-New-QuyNhon project.
---
# Quy Nhon CSS Architecture
## Phạm Vi
Skill này chỉ áp dụng trong project `WEB-New-QuyNhon`.
Áp dụng khi sửa hoặc thêm:
- `.css`
- `.aspx`
- `.ascx`
- inline `style`
- header, menu, banner, button, card, section, responsive layout
## Nguyên Tắc Chính
Khi thêm CSS mới phải bám theo cấu trúc CSS hiện có của project.
Ưu tiên sửa trong đúng file CSS/module CSS đang quản lý khu vực đó.
Không tự tạo phong cách mới nếu project đã có class, biến màu, spacing, border-radius, button, section style tương ứng.
Không rewrite lại toàn bộ CSS.
Không đổi HTML/control server-side nếu chỉ cần chỉnh giao diện.
## Màu Sắc Project
Dùng biến màu hiện có trong `1.HOS/InformationWeb/assets/css/style.css`:
- Màu chính xanh: `var(--tanspot-black)` tương ứng `#0a63ad`
- Màu nhấn đỏ: `var(--tanspot-base)` tương ứng `#dc3545`
- Trắng: `var(--tanspot-white)`
- Xám chữ: `var(--tanspot-gray)`
- Border: `var(--tanspot-bdr-color)`
Nếu cần RGB, dùng biến `--tanspot-*-rgb` có sẵn.
Không hard-code lại `#023374` hoặc `#FD5523`.
## Không Thêm Hiệu Ứng Ngoài Mẫu
Không tự thêm gradient mới.
Không tự thêm line/trang trí gạch ngang mới.
Không tự thêm shadow mạnh, glow, blur, radial shape, animation mới nếu khu vực đó không có sẵn.
Không tạo theme màu khác ngoài màu project.
Nếu file cũ đã có gradient/shape, chỉ sửa khi user yêu cầu hoặc cần đồng bộ màu, không nhân rộng sang khu vực mới.
## Cấu Trúc CSS
Giữ cách đặt class theo block hiện có, ví dụ:
- `main-menu__...`
- `blog-one__...`
- `services-two__...`
- `faq-one__...`
Khi thêm class mới cho một block, đặt theo prefix của block đó.
Ví dụ sửa header thì dùng `main-menu__...`, không tạo prefix lạ như `custom-header-new`.
## Khi Sửa WebForms
Giữ nguyên `ID`, `runat`, event, binding, server control.
Không sửa code-behind hoặc designer nếu chỉ chỉnh CSS.
Không thêm inline server code.
Không đổi cấu trúc postback.
## Checklist Trước Khi Sửa
- Xem class/CSS hiện có của khu vực cần sửa.
- Tìm biến màu trong `:root` trước khi dùng mã màu.
- Ưu tiên reuse class/project pattern.
- Không thêm gradient/line/trang trí mới.
- Sau khi sửa, quét lại màu cũ nếu có đổi màu.
## Red Flags
Nếu đang định viết `linear-gradient`, `radial-gradient`, `box-shadow` mạnh, đường line trang trí, màu mới ngoài palette, hoặc class prefix mới, phải dừng lại và kiểm tra lại cấu trúc project trước.
