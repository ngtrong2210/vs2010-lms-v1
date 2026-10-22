---
name: winform-hos
description: >-
  Kiến trúc và quy trình WinForms trong thư mục hos — Form (StudentManager),
  SimsObject (DAO/DCore), SimsService/SystemService (lookup, lưới, setting).
  Use when tạo/sửa form WinForm, màn hình StudentManager, SimsObject, SimsService,
  FormBase IForm, GetDataTable store, InitLookUpEdit, @hos.
---

# WinForm — cơ chế `hos/` (Form + Object + Service)

Phạm vi: solution WinForms dưới **`hos/`** (C# .NET Framework 4, VS2010, DevExpress/Dg controls).

## Cấu trúc project

| Project | Vai trò | Gọi từ form |
|---------|---------|-------------|
| **StudentManager** | UI: `frm*.cs`, `*.Designer.cs`, `*.resx` | — |
| **SimsObject** | DAO entity: `SIM_*` (partial `Base/` + method store) | `new SIM_Student()` … |
| **SimsService** | Cache + `InitLookUpEdit` cho combobox/lưới danh mục SIM | `SIM_ClassService.InitLookUpEdit(...)` |
| **SystemService** (ref) | Lưới cột, setting hệ thống | `SYS_GridColumnService`, `SYS_SettingService` |
| **GeneralService** / **GeneralObject** | Danh mục GEN (dân tộc, tôn giáo, …) | `GEN_EthnicityService.InitLookUpEdit(...)` |

**Luồng chuẩn:** Form → **SimsObject** (đọc/ghi DB qua store). **Service** chỉ cho dữ liệu tham chiếu dùng lại nhiều nơi (lookup), **không** thay DAO cho nghiệp vụ màn hình.

SQL: patch store → skill **sql-store-patches**; patch lưới → skill **winform-luoi-sql**.

## Form — khung bắt buộc

```csharp
public partial class frmTenForm : FormBase, IForm
{
    public const string PERMISSION_EDIT = "frmTenForm_Edit";  // hoặc SIM_Module_Action
    public const string PERMISSION_VIEW = "frmTenForm_View";

    private static frmTenForm _instance = null;
    public static frmTenForm Instance { get { ... } }

    public void Run(bool isShowDialog)
    {
        FormManager.Run(Instance, isShowDialog);
    }
}
```

- **Quyền:** `UserSession.HasPermission(PERMISSION_*)`; lọc khoa: `UserSession.GetScienceFilter(PERMISSION_VIEW)`.
- **Region:** Consts → Variables → IForm Members → Support Functions → Form Actions (+ event paste/lưới nếu có).
- **Singleton** + `FormManager.Run` — menu hệ thống mở form qua `Run`, không `new` trực tiếp ngoài Instance.
- Đăng ký file trong **`StudentManager.csproj`**: `.cs`, `.Designer.cs`, `.resx`.

### Load dữ liệu (thread UI)

```csharp
private void frm_Load(object sender, EventArgs e)
{
    CheckPermission();
    new Thread(LoadReferenceData).Start();  // combobox, UClass
}

private void btnSearch_Click(object sender, EventArgs e)
{
    if (IsValidData())
        new Thread(LoadData).Start();
}

public void LoadData()
{
    if (InvokeRequired)
        Invoke(new MethodInvoker(LoadData));
    else
    {
        SIM_Student obj = new SIM_Student();
        dtbData = obj.GetDataTable("SIM_StoreName_Search", "@ClassID", uClass.ClassIDEditValue);
        // ...
    }
}
```

- Mọi chạm control sau load → **Invoke** nếu từ thread phụ.
- `LoadReferenceData`: `uClass.InitData()` / `RefrehData()` khi `bolIsRefresh`; gán `ClassFilter`, `ScienceFilter` trước Init.

### Lưới DevExpress (DgGrid)

```csharp
private const string GRID_QUERY_NAME = "SIM_StudentContractInfo_Search";

gcData.DataSource = dtbData;
SystemService.SYS_GridColumnService.InitGridColumn(gvData, GRID_QUERY_NAME, bolIsRefresh);
gvData.BestFitColumns();
```

- `QueryName` = tên store Search + hằng form (xem **winform-luoi-sql**).
- Sửa lưới: `gvData.OptionsBehavior.Editable = bolAllowEdit`; `ValidateRow` bật nút Lưu.
- Export: `gvData.QuickExportToExcel()`.

### Tìm theo lớp — `UClass1`

Pattern màn báo cáo/nhập theo lớp (vd. `frmThongTinHopDong`, `frmGraduationSummary`):

- `uClass.ClassFilter = "ClassType = 0"`;
- `uClass.ScienceFilter = UserSession.GetScienceFilter(PERMISSION_VIEW)`;
- Validate: `uClass.IsValidData()` + bắt buộc `ClassIDEditValue`.

### Panel “dán xuống lưới”

- Nút mũi tên (`btnSet*`, image `right2`): gán vào dòng **đang chọn** (`gvData.GetSelectedRows()`).
- Số tự tăng (tiền tố + Số TT): copy logic `frmGraduationSummary.btnSetCerNo_Click` — pad theo độ dài chuỗi Số TT (`01` → `02`…).
- Sau gán: `btnSave.Enabled = true`.

## SimsObject (DAO)

- Class **`partial`**: `Base/SIM_*Base.cs` (property, CRUD codegen) + `SIM_*.cs` (method nghiệp vụ).
- Gọi store:
  - **Search/list:** `GetDataTable("StoreName", "@Param", value, ...)`
  - **Update một nghiệp vụ:** method `UpdateXxx()` → `CreateNewStoredProcedure` + `AddParameter` + `ExecNonQuery`
- **Transaction nhiều bảng:**

```csharp
SIM_Student obj = new SIM_Student();
obj.BeginTransaction();

SIM_Class objClass = new SIM_Class();
objClass.IDB = obj.IDB;
// ... set property, objClass.UpdateContractInfo()

SIM_Student item = new SIM_Student();
item.IDB = obj.IDB;
// ... item.UpdateContractNo()

obj.CommitTransaction();  // lỗi → RollBackTransaction()
```

- Lỗi: method trả `false`, form đọc `obj.ErrorException`; hiển thị `ErrorManager.Error` / `MessageManager.Warning` — không show raw exception cho user.
- **Không** viết SQL trong form; **không** thêm service trung gian chỉ để gọi 1 store nếu chưa có convention sẵn (ưu tiên method trên `SIM_*` như `UpdateContractNo`).

### Thêm nghiệp vụ mới

```
- [ ] Patch SQL store trong sql/patches/ (sql-store-patches)
- [ ] Method trên SIM_* (hoặc entity đúng bảng) gọi đúng tên param store
- [ ] Form gọi method; kiểm tra param (@ModifiedBy vs @UpdatedUser)
```

## SimsService / GeneralService

- **Mục đích:** `static Table` cache + `HaveNewData` + **`InitLookUpEdit(DgLookUpEdit | ULookUpEdit, condition)`**.
- DAO bên trong service: `new SIM_Class(); dtbTable = obj.GetDataTable("SIM_Class_SearchCBX");` + dòng trống `--Chọn--`.
- Form **LoadReferenceData** gọi các `InitLookUpEdit` cần thiết; sau khi sửa danh mục gốc set `XxxService.HaveNewData = true` (nếu project đang dùng cache).
- **Không** đặt logic lưu lưới/search phức tạp trong Service trừ khi đã có sẵn class Service nghiệp vụ (vd. `SIM_SubjectMarkService`) — đọc file cùng module trước khi tạo mới.

## SystemService

| API | Dùng khi |
|-----|----------|
| `SYS_GridColumnService.InitGridColumn` | Mọi lưới cấu hình DB |
| `SYS_SettingService.GetStringValue` | Header báo cáo, đường dẫn ảnh, Report_Place |
| `SYS_SettingService.CurrentDateTime` | In ấn |

## Quyền & menu DB

- Hằng form: `frmTenForm_View`, `_Edit`, `_Add`, `_Delete` hoặc `SIM_Module_Action` — **trùng** mã đăng ký trên DB menu/phân quyền.
- User cần script/menu riêng nếu form mới (agent liệt kê mã quyền đã khai báo).

## Mẫu tham chiếu trong repo

| Form | Pattern |
|------|---------|
| `hos/StudentManager/Report/frmThongTinHopDong.cs` | UClass, lưới Search store, panel dán, transaction Class + Student |
| `hos/StudentManager/Graduation/frmGraduationSummary.cs` | Lưới động, tiền tố + số TT tăng dần |
| `hos/StudentManager/Graduation/frmExamDate.cs` | CRUD master, `SIM_ExamDate` + InitGridColumn |
| `hos/StudentManager/Student/frmStudent.cs` | Form lớn, nhiều Service InitLookUpEdit, quyền chi tiết |

## Checklist agent — form mới

```
- [ ] 1. Xác định entity SIM_* và store (Search / Update)
- [ ] 2. Patch SQL (store + SYS_GridColumn nếu có lưới)
- [ ] 3. Method SimsObject; csproj SimsObject nếu file mới
- [ ] 4. frm + Designer + resx; csproj StudentManager
- [ ] 5. PERMISSION_* + CheckPermission + IsValidData
- [ ] 6. LoadReferenceData (Service/UClass) + LoadData (Object)
- [ ] 7. Lưu/transaction; MessageManager thành công
- [ ] 8. Báo user: chạy patch SQL, đăng ký quyền/menu
```

## C# / UI (hos)

- .NET 4: không `async/await`, không string interpolation; `String.Format`.
- Control: `Control.UTextEdit`, `UDateEdit`, `DgButton`, `DgGridControl`/`DgGridView`; giữ tên control Designer.
- **Không** regenerate `InitializeComponent` toàn bộ khi chỉ thêm vài control.

## Skill liên quan

- **winform-luoi-sql** — `SYS_GridColumn`
- **sql-store-patches** — stored procedure
- **format-sql** — format câu SQL trong patch
