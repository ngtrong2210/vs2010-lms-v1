# sql_quyen — ví dụ

## GEN — frmCostSource

**Form (`General/frmCostSource.cs`):**

```csharp
public const string PERMISSION_ADD = "GEN_CostSource_Add";
public const string PERMISSION_DELETE = "GEN_CostSource_Delete";
public const string PERMISSION_EDIT = "GEN_CostSource_Edit";
public const string PERMISSION_VIEW = "GEN_CostSource_View";
```

**SQL seed (rút gọn):**

| PermissionID | PermissionGroupID | Category |
|--------------|-------------------|----------|
| GEN_CostSource_View | frmcostsource | fam |
| GEN_CostSource_Add | frmcostsource | fam |
| GEN_CostSource_Edit | frmcostsource | fam |
| GEN_CostSource_Delete | frmcostsource | fam |

## FAM — frmDeviceKind

**Form:**

```csharp
public const string PERMISSION_VIEW = "FAM_DeviceKind_View";
// ...
```

**PermissionGroupID:** `frmdevicekind` (baseline)  
**Category:** `fam`  
**PermissionID:** `FAM_DeviceKind_View`, … — **PascalCase**, không `fam_devicekind_view`.

## GEN — frmUnit (export cũ vs form)

- Form C#: `GEN_Unit_Add`
- Export JSON cũ có thể ghi `gen_unit_add` — **patch mới phải theo form**, không copy lowercase từ dump.

## Màn chỉ xem

Báo cáo / popup:

```csharp
public const string PERMISSION_VIEW = "FAM_DeviceDetail_View";
```

Chỉ insert một dòng `_View`, OrderIndex 0.

## Đặt tên file

```
sql/quyền/20250918_SYS_Permission_frmCostSource_insert.sql
sql/patches/20250918_SYS_Permission_frmCostSource_insert.sql
```

`frmCostSource` trong tên file = PascalCase cho dễ đọc; `PermissionGroupID` trong DB vẫn `frmcostsource`.
