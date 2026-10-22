---
name: sql-quyen
description: >-
  Tạo patch SQL phân quyền WinForms (SYS_PermissionGroup, SYS_Permission) khớp
  hằng PERMISSION_* trên form. Use when user nói quyền, phân quyền, SYS_Permission,
  PermissionGroup, sql/quyền, thêm form mới cần quyền, GEN_/FAM_ permission, sql_quyen.
---

# SQL quyền — SYS_Permission / SYS_PermissionGroup

Áp dụng mọi project SIMS / WinForms dùng `UserSession.HasPermission(...)`.

Dùng cùng **sql-store-patches**: một form (một nhóm quyền) = **một file patch**, không sửa file JSON dump tổng.

## Thư mục

| Loại | Đường dẫn |
|------|-----------|
| Patch deploy | `sql/patches/YYYYMMDD_SYS_Permission_<FormKey>_insert.sql` |
| Tham chiếu / quyền | `sql/quyền/` — copy patch hoặc export `SYS_Permission*.sql` |
| Baseline (chỉ đọc) | `sql/quyền/SYS_Permission.sql`, `SYS_PermissionGroup.sql`, `SYS_PermissionCategory.sql` |

Nếu project chưa có `sql/quyền/` → tạo khi thêm quyền form đầu tiên.

## Quy tắc bắt buộc

### 1. PermissionID = hằng C# (copy verbatim)

Đọc form `#region Consts`:

```csharp
public const string PERMISSION_VIEW = "GEN_CostSource_View";
public const string PERMISSION_ADD = "GEN_CostSource_Add";
public const string PERMISSION_EDIT = "GEN_CostSource_Edit";
public const string PERMISSION_DELETE = "GEN_CostSource_Delete";
```

**PermissionID trong SQL phải trùng từng ký tự** (`GEN_CostSource_View`, không `gen_costsource_view`).

`HasPermission` so khớp **phân biệt hoa thường** — sai casing = mất quyền trên form.

Prefix theo module form: `GEN_`, `FAM_`, `ACC_`, `SIM_`, … lấy từ code, không tự đặt.

### 2. PermissionGroupID

- **Lowercase**, tên form không namespace: `frmCostSource` → `frmcostsource`, `frmUnit` → `frmunit`.
- Khớp export cũ trong `SYS_PermissionGroup.sql` (JSON).

### 3. PermissionCategoryID

Lấy từ form **cùng loại** trong baseline:

| Loại màn | Category thường gặp |
|----------|---------------------|
| Danh mục General (nhãn, tỉnh, …) | `declaration` |
| Danh mục tài sản FAM | `fam` |
| Kho / đvt (vd. frmUnit) | `stockmanager` |
| Học vụ / SIM | `learning`, `schedule`, … |

Tra `SYS_PermissionGroup.sql`: tìm group gần giống (vd. `frmdevicekind` → `fam`).

### 4. Bốn quyền CRUD lưới (pattern GEN/FAM danh mục)

| PermissionID suffix | PermissionName | OrderIndex |
|---------------------|----------------|------------|
| `_View` | xem | 0 |
| `_Add` | thêm | 1 |
| `_Edit` | sửa | 2 |
| `_Delete` | xóa | 3 |

Màn chỉ xem báo cáo: thường chỉ `_View` (OrderIndex 0).

Cột insert `SYS_Permission` (mặc định danh mục):

- `HaveInScience`, `HaveInSubjectGroup`, `HaveInOffice`, `HaveInStore` = `0`
- `IsActived` = `1`, `IsDeleted` = `0`

Form FAM có `HaveInScience = true` trên View → copy từ group tương tự trong baseline.

### 5. PermissionGroupName

Tiêu đề tiếng Việt, **chữ cái đầu câu** (vd. `Nguồn kinh phí`, `Đơn vị tính`). Trùng `Text` form hoặc tên nghiệp vụ.

### 6. OrderIndex (group)

Số thứ tự trong category; xem group cùng `PermissionCategoryID` trong baseline, +1 nếu cần.

## Quy trình agent

```
Task Progress:
- [ ] 1. Đọc frm*.cs — PERMISSION_VIEW/ADD/EDIT/DELETE
- [ ] 2. Xác định PermissionGroupID (lowercase), tên group, category
- [ ] 3. Grep sql/quyền — group/permission đã tồn tại chưa
- [ ] 4. Tạo patch Insert (Not Exists) + block UPDATE id sai nếu đã deploy nhầm
- [ ] 5. Ghi file sql/quyền + bản copy sql/patches (nội dung giống nhau)
- [ ] 6. Nhắc user: F5 SSMS → gán quyền cho Role → menu (nếu có)
```

## Template patch

```sql
/*
	Patch  : SYS_PermissionGroup + SYS_Permission — <PermissionGroupID>
	Date   : YYYY-MM-DD
	Module : <Project/Form>
	Form   : <frmName.cs> — PermissionID copy từ PERMISSION_*
	Category : <PermissionCategoryID>
*/

Set Nocount On;
Go

/* Optional: sửa PermissionID sai casing đã insert trước đó */
-- Update SYS_Permission Set PermissionID = N'<Dung>' Where PermissionID = N'<Sai>';

If Not Exists (
	Select 1 From SYS_PermissionGroup
	Where SYS_PermissionGroup.PermissionGroupID = N'<groupLower>'
)
Begin
	Insert Into SYS_PermissionGroup (
		PermissionGroupID, PermissionGroupName, PermissionCategoryID, OrderIndex
	)
	Values (N'<groupLower>', N'<Tên hiển thị>', N'<category>', <order>);
End
Go

Insert Into SYS_Permission (
	PermissionID, PermissionName, PermissionGroupID,
	HaveInScience, HaveInSubjectGroup, IsActived, IsDeleted,
	OrderIndex, HaveInOffice, HaveInStore
)
Select seed.PermissionID, seed.PermissionName, seed.PermissionGroupID,
	0, 0, 1, 0, seed.OrderIndex, 0, 0
From ( Values
	(N'<Module>_View', N'xem', N'<groupLower>', 0),
	(N'<Module>_Add', N'thêm', N'<groupLower>', 1),
	(N'<Module>_Edit', N'sửa', N'<groupLower>', 2),
	(N'<Module>_Delete', N'xóa', N'<groupLower>', 3)
) As seed (PermissionID, PermissionName, PermissionGroupID, OrderIndex)
Where Not Exists (
	Select 1 From SYS_Permission existing
	Where existing.PermissionID = seed.PermissionID
);
Go
```

## Ví dụ chuẩn (frmCostSource)

- Group: `frmcostsource`, tên `Nguồn kinh phí`, category `fam`
- IDs: `GEN_CostSource_View`, `_Add`, `_Edit`, `_Delete`
- File mẫu: `sql/quyền/20250918_SYS_Permission_frmCostSource_insert.sql`

## Lỗi thường gặp

| Lỗi | Cách xử lý |
|-----|------------|
| Form không cho sửa/xóa dù đã tick quyền | PermissionID SQL ≠ hằng `PERMISSION_*` (thường do viết thường) |
| Không thấy nhóm trên màn phân quyền | Thiếu `SYS_PermissionGroup` hoặc sai `PermissionCategoryID` |
| Trùng key khi chạy lại patch | Dùng `Not Exists`; không insert trùng PermissionID |

## SQL format

Viết SQL theo skill **format-sql** (Select/From/Where, một cột một dòng).

## Sau khi deploy

1. Chạy patch trên đúng database.
2. Phân quyền **Role** (SYS_RolePermission / màn hình quyền hệ thống).
3. Đăng ký menu gọi `frmXxx.Instance.Run(...)` nếu form mới.

Chi tiết thêm: [examples.md](examples.md)
