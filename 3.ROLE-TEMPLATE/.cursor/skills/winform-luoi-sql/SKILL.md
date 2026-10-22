---
name: winform-luoi-sql
description: >-
  Tạo/sửa patch SQL cấu hình lưới WinForms (SYS_GridColumn), đồng bộ QueryName
  với store và InitGridColumn, FieldName PascalCase theo cột Select. Use when
  user nói lưới sql, SYS_GridColumn, InitGridColumn, cột lưới WinForm, grid
  column patch, thêm form lưới, queryname lưới.
---

# WinForm — patch SQL lưới (SYS_GridColumn)

Dùng cùng **sql-store-patches**: mỗi lưới mới = **một file patch riêng**, không gom vào file JSON/SQL tổng.

## Quy ước bắt buộc

| Mục | Quy tắc |
|-----|---------|
| **QueryName** | **Trùng tên store** và chuỗi truyền `InitGridColumn` (vd. `SIM_StudentContractInfo_Search`) — **không** viết thường kiểu `sim_...` trừ khi form đã dùng vậy |
| **FieldName** | **PascalCase**, **trùng alias/cột** trong `Select` của store (DataTable bind lưới) — vd. `StudentCode`, `StartAt` |
| **Caption** | Tiếng Việt, **viết hoa chữ cái đầu** từ: `Mã SV`, `Họ đệm`, `Ngày sinh` — cột ẩn ID có thể caption `ID` |
| **GridColumnID** | Cột **IDENTITY** — **không** insert; không bật `IDENTITY_INSERT` |
| **Form C#** | `SYS_GridColumnService.InitGridColumn(gvData, "<QueryName>", bolIsRefresh)` — hằng `GRID_QUERY_NAME` = cùng QueryName |

Tham chiếu baseline (export cũ có thể viết thường): `sql/winform/SYS_GridColumn.sql` — chỉ để gợi ý width/format; **FieldName/QueryName mới luôn theo store + form hiện tại**.

## Thư mục & tên file patch

```
sql/patches/YYYYMMDD_SYS_GridColumn_<QueryName>_insert.sql
```

Ví dụ: `20250916_SYS_GridColumn_SIM_StudentContractInfo_Search_insert.sql`

## Template patch

```sql
/*
	Patch  : SYS_GridColumn - <QueryName>
	Date   : YYYY-MM-DD
	Module : WinForm / <mô tả form>
	Mô tả  : Cột lưới — FieldName trùng store Select
*/

Set Nocount On;
Go

Delete From SYS_GridColumn
Where QueryName = '<QueryName>';
Go

Insert Into SYS_GridColumn
(
	QueryName,
	FieldName,
	Caption,
	Width,
	Editable,
	Visible,
	VisibleIndex,
	HAlignment,
	FormatString,
	Banded,
	FixedType
)
Values
(N'<QueryName>', N'StudentID', N'ID', 0, 0, 0, 0, 2, N'', null, null);
-- ... mỗi cột một dòng Values, VisibleIndex tăng dần
Go
```

### Gợi ý cột thường dùng

- **Ẩn khóa:** `StudentID` — `Visible = 0`, `Width = 0`
- **Căn:** `HAlignment = 2` (giữa) cho mã, ngày, số; `null` hoặc `1` cho tên/họ
- **Số tiền:** `FormatString = N'#,###'`
- **Ngày trên lưới sửa được:** `FormatString = N'd'` hoặc để trống tùy project
- **Editable:** `1` chỉ cột user sửa trên lưới; `0` cột chỉ đọc

## Quy trình agent

```
Task Progress:
- [ ] 1. Đọc store Search (Select list) — lấy danh sách cột + thứ tự hiển thị
- [ ] 2. Kiểm tra form: GetDataTable store name, InitGridColumn query name, DataRow["Column"]
- [ ] 3. Tạo patch Delete + Insert (không GridColumnID)
- [ ] 4. Cập nhật hằng GRID_QUERY_NAME / strQueryName trên form nếu cần
- [ ] 5. Báo user: chạy patch trên DB → F5 / mở lại form (bolIsRefresh lần đầu sau đổi cột)
```

## Đồng bộ với store DAO

- Store SP: patch riêng (`sql-store-patches`)
- Lưới: patch **SYS_GridColumn** riêng (skill này)
- Tham số store ↔ C#: tên param khớp (`@ModifiedBy` vs `@UpdatedUser`) — kiểm tra khi lỗi "parameter not supplied"

## Lỗi thường gặp

| Lỗi | Xử lý |
|-----|--------|
| `Cannot insert explicit value for identity column GridColumnID` | Bỏ cột `GridColumnID` khỏi Insert |
| Lưới không hiện cột / sai caption | QueryName hoặc FieldName không khớp store/form |
| Cột bind sai khi sửa | FieldName phải PascalCase như `drw["ContractNo"]` |

## Báo user sau khi xong

1. Đường dẫn file patch SYS_GridColumn
2. Nhắc chạy SSMS trên đúng database
3. Form cần test: tìm kiếm, sửa cột editable, lưu
