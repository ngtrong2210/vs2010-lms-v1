# Audit nhanh (các file user đã vẽ)

Cập nhật theo trạng thái repo `bin/Debug/Report/Salary/`.

## BangLuong_Mau2_LuongBaoVe.repx — OK (reference)

- Prefix `m2*`, 9 cột, Weight đồng bộ Header/Detail/Total.
- Binding khớp sheet bảo vệ: `UnitSalary`, `DepartmentSubMoney`, `InsuMoney`, `DeltaMoney`, `NetSalary`.
- A4 dọc, bảng 765px @ X=20.
- Còn: CalculatedField legacy (TIEN_*…) — nên xóa khi refactor sạch; chữ ký có thể canh lại bằng `tableLeft + i*width/3`.

## BangLuong_Mau3_BangKeChuyenKhoan.repx — OK (reference)

- Prefix `m3*`, 10 cột, Weight số nguyên (55…50).
- Group `DepartmentName`, Total bind nhiều khoản phí → RealSalary.
- Kiểm tra cột 6–7 detail có binding đủ với Total (UnionFee, AdvanceOffset, TaskFee).

## BangLuong_Mau1_LuongNhanVien.repx — cần refactor

- Legacy `tableCell*` / `table3` footer, A3 ngang 1563px.
- Footer từng sửa (footerCellSpecial/Bank, Weight) nhưng **chưa** theo pattern `m1*` như Mau 2/3.
- Rủi ro: PageHeader phức tạp (table6–10, label lồng), dễ lệch CỘNG.
- Hướng xử lý: clone cấu trúc 20 cột từ mapping Mau 1, đặt `m1Detail`/`m1Total` cùng Weight từng cột detail hiện tại (copy từ `tableCell3…42`).

## BangLuong_LuongThang_NganHan.repx — legacy

- Gần bản `BangLuong_LuongThang.repx`, không phải Mau 2.
- Chỉ dùng cho menu in HĐ ngắn cũ; không đồng bộ với `PrintMonthSalary(2)`.

## So sánh nhanh

| Tiêu chí | Mau 2/3 | Mau 1 / NganHan |
|----------|---------|------------------|
| Đặt tên control | m2/m3 prefix | tableCell* |
| Weight Total = Detail | Có | Hay lệch |
| Khổ giấy | A4 | A3 (Mau 1) |
| Footer chữ ký | m*Signature | label8/7/xrLabel26 tọa độ cũ |
