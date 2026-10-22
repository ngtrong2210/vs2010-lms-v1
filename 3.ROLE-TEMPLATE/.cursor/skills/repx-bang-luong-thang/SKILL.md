---
name: repx-bang-luong-thang
description: Tạo/sửa DevExpress .repx bảng lương tháng (Mẫu 1–3) cho TKSManager frmMonthSalary, đồng bộ cột với Excel và HRS_Employee_MonthSalary. Dùng khi user nói mẫu in lương, BangLuong_Mau, repx lương, CỘNG lệch cột, gán field in lương.
---

# REPX bảng lương tháng (Quy Nhơn / frmMonthSalary)

## Mục tiêu

Chỉ sửa file `.repx` trong `1.uiwn/bin/Debug/Report/Salary/` (và bản copy deploy nếu có). **Không sửa** `frmMonthSalary.cs` trừ khi user yêu cầu.

DevExpress **v11.1**, .NET Framework 4, serialize dạng `namespace XtraReportSerialization`.

## Bước 1 — Đọc code trước khi vẽ

1. `1.uiwn/TKSManager/Salary/frmMonthSalary.cs`:
   - `PrintMonthSalary(intMau)` → tên file `.repx`
   - `PrepareMonthSalaryOutputData` → filter (Mẫu 1: `ContractTypeID = 1`, Mẫu 2: `<> 1`, Mẫu 3: `IsSelected = 1`)
   - `ExportExcelMonthSalary` → `arrCols[]` ** là danh sách field chuẩn** cho từng mẫu
2. Tham số form set khi in: `par_THANG`, `par_NAM`, `par_NOW`, `pDepartment`, `pMonth`
3. Store: `HRS_Employee_MonthSalary` (cột trong SQL / lưới)

Chi tiết map cột từng mẫu: [mappings-reference.md](mappings-reference.md).

## Bước 2 — Chọn mẫu chuẩn kiến trúc

| Mẫu | File | Kiến trúc khuyến nghị |
|-----|------|------------------------|
| 2 | `BangLuong_Mau2_LuongBaoVe.repx` | **Chuẩn** — prefix `m2*`, A4 dọc, Weight số nguyên |
| 3 | `BangLuong_Mau3_BangKeChuyenKhoan.repx` | **Chuẩn** — prefix `m3*`, bảng rộng hơn |
| 1 | `BangLuong_Mau1_LuongNhanVien.repx` | **Legacy** — `tableCell*`, A3 ngang; nên refactor dần theo m2 |
| — | `BangLuong_LuongThang_NganHan.repx` | In menu cũ (`BangLuong_LuongThang_NganHan`), **không** trộn với Mau 1–3 |

**Mẫu mới hoặc sửa lớn:** copy cấu trúc từ Mau 2 hoặc 3 (cùng số cột), đổi prefix (`m1*`), header Excel, binding — **không** copy nguyên `BangLuong_LuongThang.repx`.

## Bước 3 — Quy ước layout (bắt buộc)

### Một “khối bảng” thống nhất

Cùng **LocationFloat.X** và **SizeF.Width** cho:

- Detail (`m*Detail`)
- PageHeader (`m*Header` + `m*IndexRow` nếu có)
- ReportFooter (`m*Total`)
- GroupHeader (`m*Group`) nếu có

Ví dụ Mau 2: `LocationFloat = 20F`, `Width = 765F`.

### Cột: cùng số ô, cùng Weight

- Mỗi hàng (`DetailRow`, `HeaderRow`, `IndexRow`, `TotalRow`) **cùng số** `XRTableCell`.
- **`Weight` từng cột copy y hệt** từ Detail sang Header và Total (Mau 2 dùng 42, 149, 101, …).
- **Không** gộp nhiều cột detail thành một ô total (trừ khi gộp có `Weight = tổng Weight các cột`) — lỗi hay gặp trên Mau 1 (`tableCell13` CỘNG).

### Hàng CỘNG

- Ô 1: trống (STT)
- Ô 2–4: trống hoặc một ô “CỘNG” **đúng Weight cột họ tên**; các cột text còn lại trống **từng ô một**
- Cột tiền: `DataBindings` + `Summary.Running = Report` + `FormatString` (vd `{0:#,##0}`)
- Cột ghi chú: để trống, **không** để text `tableCell45`
- Hệ số / %: có binding + `FormatString` (`{0:0.00}`), tránh Summary không field → hiện `None`

### Chữ ký

Canh theo **bề ngang bảng**, chia 3 phần bằng:

- `thirdW = tableWidth / 3`
- Label i: `X = tableLeft + i * thirdW`, `Width = thirdW`
- Ngày: bind `par_NOW`, đặt trên “HIỆU TRƯỞNG” (cột phải)

Mau 2 tham chiếu: `m2Signature0/1/2` (có thể tinh lại theo công thức trên).

### Format & font

- Tiền: `{0:#,##0}` hoặc `{0:###,###}` — **thống nhất trong một file**
- Font body: Times New Roman 9–9.5F; header đậm
- `BorderWidth = 1`; cột đầu: Left+Right+Bottom; cột giữa/cuối: Right+Bottom

### Tham số tiêu đề

- `THÁNG [Parameters.par_THANG] NĂM [Parameters.par_NAM]` hoặc tương đương
- Header trái/phải theo Excel mẫu (Gia Lai / Quốc hiệu) — xem file user đính kèm

## Bước 4 — Quy trình tạo mẫu mới

1. Xác định `intMau` và file `.repx` trong `PrintMonthSalary`.
2. Lấy danh sách cột từ `arrCols` (excel) + ảnh/chữ trên header từng cột.
3. Clone cấu trúc từ Mau 2/3 (số cột gần nhất).
4. Đặt tên control có prefix (`m1DetailCell0`…).
5. Gán binding đúng field; tiền thêm format.
6. Kiểm tra checklist (dưới).
7. In thử từ app — skill **không** thay DevExpress Designer preview.

## Checklist trước khi giao

- [ ] Số cột Detail = Header = Index (nếu có) = Total
- [ ] Weight từng cột khớp Detail trên mọi band bảng
- [ ] `LocationFloat.X` + `SizeF.Width` giống nhau giữa Detail/Header/Total
- [ ] Không còn `Text = "tableCellXX"` trên band in
- [ ] Summary tiền có `FormatString`; không Count/Sum sai cột text
- [ ] Field tồn tại trong `arrCols` / store (vd `DepartmentSubMoney` Mau 2)
- [ ] `par_THANG`, `par_NAM`, `par_NOW` khớp tên form set
- [ ] Xóa hoặc bỏ qua CalculatedField rác (copy từ mẫu cũ) nếu không dùng
- [ ] `XmlDataPath` rác có thể để nguyên (không ảnh hưởng runtime) — ưu tiên fix layout

## Lỗi thường gặp (Mau 1 legacy)

- Hàng CỘNG 19 cột / Detail 20 cột → lệch từ cột 5 trở đi
- Weight cột (9)–(14) hoán đổi → tổng tiền lệch header
- Chữ ký đặt tọa độ cũ (A3) trong khi bảng đã chỉnh
- Gộp CỘNG + Summary Count → cột hiển thị số lượng/`None` sai chỗ

Refactor Mau 1: tách sang `m1*` như Mau 2, A3 ngang giữ `PageWidth`/`Landscape` nhưng áp dụng cùng quy tắc Weight/Location.

## File output

- Đích: `1.uiwn/bin/Debug/Report/Salary/BangLuong_Mau*.repx`
- Sau build lại: đảm bảo copy vào output (project thường không link sẵn `.repx` trong csproj)

## Tài liệu thêm

- Map field từng mẫu: [mappings-reference.md](mappings-reference.md)
- REPX generic (script, margin): skill `repx-report-sync` / `repx-folder-workshop`
