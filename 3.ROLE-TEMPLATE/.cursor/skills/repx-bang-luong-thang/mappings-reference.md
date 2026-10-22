# Map cột — frmMonthSalary ↔ REPX

Nguồn: `PrepareMonthSalaryOutputData`, `ExportExcelMonthSalary` → `arrCols`, store `HRS_Employee_MonthSalary`.

## Tham số in (PrintMonthSalary)

| Parameter | Nguồn |
|-----------|--------|
| `par_THANG` | `dtmDate.Month` |
| `par_NAM` | `dtmDate.Year` |
| `par_NOW` | `DateTime.Now` dd/MM/yyyy |
| `pDepartment` | `lookupDepartmentID.Text` |
| `pMonth` | (có trên một số mẫu cũ) |

## Mẫu 1 — `BangLuong_Mau1_LuongNhanVien.repx`

Filter: `ContractTypeID = 1`. Khổ **A3 ngang** (~1563px bảng, `LocationFloat.X ≈ 44.40472`).

| # | Field (arrCols / in) | Ghi chú |
|---|----------------------|--------|
| A | `Order` | STT |
| B | `DeptOrder` | STT phòng/khoa |
| C | `Fullname` | |
| D | `SpecialJob` | Chức danh |
| E | `BankAccount` | |
| 6 | `SalaryRatio` | `{0:0.00}` |
| 7 | `PositionSub` | |
| 8 | `OverFrameSub` | |
| 9 | `TaskSub` | |
| 10 | `ToxicSub` | |
| 11 | `TeacherSub` | |
| 12 | `SpecialSub` | |
| 13 | `DepartmentSub` | |
| 14 | `InsuSalary` | `{0:###,###}` |
| 15 | `TotalSalary` | |
| 16 | `InsuMoney` | |
| 17 | `DeductedSalary` | |
| 18 | `DeltaMoney` | Truy thu/truy lĩnh |
| 19 | `NetSalary` | |
| 20 | `Description` | Ghi chú |

Excel export còn `DepartmentName` (group), không bắt buộc trên từng dòng detail.

**Chuẩn hóa:** refactor `m1DetailCell0..19` + Total 20 cột, Weight đồng bộ (xem Mau 2).

## Mẫu 2 — `BangLuong_Mau2_LuongBaoVe.repx` (reference)

Filter: `ContractTypeID <> 1`. **A4 dọc**, `tableLeft=20`, `tableWidth=765`.

Weights (dùng cho Header/Detail/Total):  
`42, 149, 101, 82, 74, 92, 74, 96, 55`

| Cell | Field | Format |
|------|-------|--------|
| 0 | `Order` | |
| 1 | `Fullname` | |
| 2 | `PositionName` | |
| 3 | `UnitSalary` | `{0:#,##0}` |
| 4 | `DepartmentSubMoney` | `{0:#,##0}` |
| 5 | `InsuMoney` | `{0:#,##0}` |
| 6 | `DeltaMoney` | `{0:#,##0}` |
| 7 | `NetSalary` | `{0:#,##0}` |
| 8 | `Description` | |

Total: CỘNG ở cột 1; cột 2 trống; cột 3–7 Sum; cột 8 trống.

Excel `arrCols` còn: `DeptOrder`, `DepartmentName`, `SalaryLevel`, `SalaryRatio`, `TotalSalary`, `DeductedSalary`, `RealSalary` — bổ sung detail nếu user đưa Excel mới; hiện REPX user vẽ 9 cột theo sheet LUONG BAO VE.

## Mẫu 3 — `BangLuong_Mau3_BangKeChuyenKhoan.repx` (reference)

Filter: `IsSelected = 1`. **A4**, `tableLeft=20`, `tableWidth=1090`.

Weights: `55, 205, 130, 135, 120, 95, 85, 100, 115, 50` (10 cột).

| Cell | Field | Format |
|------|-------|--------|
| 0 | (STT / group) | Record number hoặc trống |
| 1 | `Fullname` | |
| 2 | `SpecialJob` | (hoặc chức danh theo Excel) |
| 3 | `BankAccount` | |
| 4 | `NetSalary` | `{0:#,##0}` |
| 5 | `UnionFee` | `{0:#,##0}` |
| 6 | (cột trống / placeholder fee) | kiểm tra Total bind |
| 7 | (AdvanceOffset / TaskFee tùy bản) | xem binding trong file |
| 8 | `RealSalary` | `{0:#,##0}` |
| 9 | `Description` | |

Total row: bind `NetSalary`, `UnionFee`, `AdvanceOffset`, `TaskFee`, `RealSalary` — **cùng Weight** với detail.

Group: `DepartmentName` trên `m3Group*`.

Excel export ngắn: `Order`, `Fullname`, `BankAccount`, `PersonID`, `DepartmentName`, `NetSalary`, `RealSalary` — REPX chi tiết hơn Excel export; ưu tiên **layout Excel in** user gửi.

## `BangLuong_LuongThang_NganHan.repx`

Dùng khi in `BangLuong_LuongThang_NganHan` từ menu lương (radio HĐ ngắn). Cùng họ legacy `tableCell*` / A3 như `BangLuong_LuongThang.repx`. Sửa riêng nếu user yêu cầu; **không** dùng làm base cho Mau 1–3.

## SQL gợi ý (tính tiền)

- `UnitSalary` ← `con.Salary`
- `DepartmentSubMoney` ← `Round(UnitSalary * d, 0)`
- `InsuMoney` ← 10.5% trên lương BH
- `NetSalary` ← Total − Insu + Delta
- `RealSalary` ← Net − Union − Advance + TaskFee (expression trên grid khi chưa khóa)
