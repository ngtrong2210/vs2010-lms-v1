# AI REFACTOR GUIDE - CHUẨN HÓA CẤU TRÚC THEO LMSOBJECT

---

## 📋 MỤC TIÊU

Tài liệu này hướng dẫn AI cách refactor code từ **Cách 1 (ServiceRegistry.Content)** sang **Cách 2 (LmsObject)** để tuân thủ kiến trúc n-tier của dự án WEB-LMS-VS2010.

**Khi nhận yêu cầu refactor, AI phải:**

1. Đọc tài liệu này trước
2. Tìm code đang dùng `ServiceRegistry.Content`
3. Tạo method nghiệp vụ trong `LmsObject`
4. Thay thế code trong Presentation layer
5. Test và verify

---

## 🔍 BƯỚC 1: TÌM CODE CẦN REFACTOR

### Tìm kiếm

Grep để tìm tất cả chỗ dùng `ServiceRegistry.Content`:

```bash
grep -r "ServiceRegistry.Content" InformationWeb/
```

Hoặc tìm cụ thể:

```bash
grep -r "ServiceRegistry.Content.GetDataTable" InformationWeb/
grep -r "ServiceRegistry.Content.ExecNonQuery" InformationWeb/
```

### Phân tích

Mỗi kết quả cần phân tích:

- **File nào đang gọi?** → Presentation layer (InformationWeb)
- **Stored procedure nào?** → Ví dụ: `"InteractionList"`, `"InteractionUpdate"`
- **Object nào tương ứng?** → Ví dụ: `SIM_Videos`, `LMS_InteractiveContents`
- **Có cần caching không?** → Nếu load dropdown/lisbox nhiều lần → Cần Service

---

## 📝 BƯỚC 2: TẠO METHOD NGHIỆP VỤ TRONG LMSOBJECT

### Xác định file LmsObject

Dựa trên stored procedure để xác định object:

| Stored Procedure | Object LmsObject | File |
|------------------|------------------|------|
| `InteractionList` | `SIM_Videos` | `LmsObject/SIM_Videos.cs` |
| `UserList` | `SYS_Users` | `LmsObject/SYS_Users.cs` |
| `CourseList` | `LMS_Courses` | `LmsObject/LMS_Courses.cs` |

### Template Method GetDataTable

```csharp
/// <summary>
    /// [Mô tả chức năng]
    /// Store: [Tên stored procedure]
    /// </summary>
    /// <param name="param1">[Mô tả param1]</param>
    /// <param name="param2">[Mô tả param2]</param>
    /// <returns>DataTable kết quả</returns>
    public DataTable [MethodName](type? param1, type? param2, ...)
    {
        return GetDataTable("[StoredProcedureName]",
            "@Param1", param1,
            "@Param2", param2,
            // ... các tham số khác
        );
    }
```

### Template Method ExecNonQuery

```csharp
/// <summary>
/// [Mô tả chức năng]
/// Store: [Tên stored procedure]
/// </summary>
/// <param name="param1">[Mô tả param1]</param>
/// <param name="param2">[Mô tả param2]</param>
/// <returns>true nếu thành công, false nếu thất bại</returns>
public bool [MethodName](type? param1, type? param2, ...)
{
    if (!bolIsExistIData)
        objIData = DCore.Data.CreateData();
    try
    {
        objIData.CreateNewStoredProcedure("[StoredProcedureName]");
        objIData.AddParameter("@Param1", param1);
        objIData.AddParameter("@Param2", param2);
        // ... các tham số khác
        objIData.ExecNonQuery();
        return true;
    }
    catch (Exception objEx)
    {
        if (bolIsExistIData)
            this.RollBackTransaction();
        new SystemError(SystemConfig.ConnectionString, "[Mô tả lỗi]", objEx);
        this.objErrorException = objEx;
        return false;
    }
    finally
    {
        if (!bolIsExistIData)
            objIData.Disconnect();
    }
}
```

### Ví dụ thực tế

```csharp
// LmsObject/SIM_Videos.cs
public partial class SIM_Videos
{
    /// <summary>
    /// Lấy danh sách tương tác của video
    /// Store: InteractionList
    /// </summary>
    /// <param name="videoId">ID của video</param>
    /// <param name="actorId">ID của user đang thao tác</param>
    /// <param name="isAdmin">Có phải admin không</param>
    /// <returns>DataTable danh sách tương tác</returns>
    public DataTable GetInteractions(int? videoId, int? actorId, bool isAdmin)
    {
        return GetDataTable("InteractionList",
            "@VideoID", videoId,
            "@ActorID", actorId,
            "@IsAdmin", isAdmin);
    }

    /// <summary>
    /// Cập nhật tương tác video
    /// Store: InteractionUpdate
    /// </summary>
    /// <param name="videoId">ID của video</param>
    /// <param name="interactionId">ID của tương tác</param>
    /// <param name="timeSeconds">Thời gian (giây)</param>
    /// <param name="type">Loại tương tác</param>
    /// <param name="dataJson">Dữ liệu JSON</param>
    /// <param name="actorId">ID của user đang thao tác</param>
    /// <param name="isAdmin">Có phải admin không</param>
    /// <param name="updatedUser">User cập nhật</param>
    /// <returns>true nếu thành công, false nếu thất bại</returns>
    public bool UpdateInteraction(int? videoId, int? interactionId, int? timeSeconds,
        string type, string dataJson, int? actorId, bool isAdmin, string updatedUser)
    {
        if (!bolIsExistIData)
            objIData = DCore.Data.CreateData();
        try
        {
            objIData.CreateNewStoredProcedure("InteractionUpdate");
            objIData.AddParameter("@VideoID", videoId);
            objIData.AddParameter("@InteractionID", interactionId);
            objIData.AddParameter("@TimeSeconds", timeSeconds);
            objIData.AddParameter("@Type", type);
            objIData.AddParameter("@DataJson", dataJson);
            objIData.AddParameter("@ActorID", actorId);
            objIData.AddParameter("@IsAdmin", isAdmin);
            objIData.AddParameter("@UpdatedUser", updatedUser);
            objIData.ExecNonQuery();
            return true;
        }
        catch (Exception objEx)
        {
            if (bolIsExistIData)
                this.RollBackTransaction();
            new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật tương tác video", objEx);
            this.objErrorException = objEx;
            return false;
        }
        finally
        {
            if (!bolIsExistIData)
                objIData.Disconnect();
        }
    }
}
```

---

## 🔄 BƯỚC 3: THAY THẾ TRONG PRESENTATION LAYER

### Pattern thay thế GetDataTable

**TRƯỚC:**
```csharp
DataTable dt = ServiceRegistry.Content.GetDataTable("InteractionList",
    "@VideoID", videoId,
    "@ActorID", actorId,
    "@IsAdmin", isAdmin);
```

**SAU:**
```csharp
var videos = new SIM_Videos();
DataTable dt = videos.GetInteractions(videoId, actorId, isAdmin);
```

Hoặc viết gọn:
```csharp
DataTable dt = new SIM_Videos().GetInteractions(videoId, actorId, isAdmin);
```

### Pattern thay thế ExecNonQuery

**TRƯỚC:**
```csharp
ServiceRegistry.Content.ExecNonQuery("InteractionUpdate",
    "@VideoID", videoId,
    "@InteractionID", interactionId,
    "@TimeSeconds", timeSeconds,
    "@Type", type,
    "@DataJson", dataJson,
    "@ActorID", actorId,
    "@IsAdmin", isAdmin,
    "@UpdatedUser", updatedUser);
```

**SAU:**
```csharp
var videos = new SIM_Videos();
bool success = videos.UpdateInteraction(
    videoId, interactionId, timeSeconds, type, dataJson,
    actorId, isAdmin, updatedUser);

if (success)
{
    // Xử lý thành công
}
else
{
    // Xử lý thất bại
}
```

### Ví dụ thực tế - File trước/sau

**TRƯỚC (VideoEditor.ascx.cs):**
```csharp
private void LoadInteractions()
{
    DataTable dt = ServiceRegistry.Content.GetDataTable("InteractionList",
        "@VideoID", videoId,
        "@ActorID", actorId,
        "@IsAdmin", isAdmin);

    gvInteractions.DataSource = dt;
    gvInteractions.DataBind();
}

protected void InteractionSaveButton_Click(object sender, EventArgs e)
{
    if (interactionId.HasValue)
    {
        ServiceRegistry.Content.ExecNonQuery("InteractionUpdate",
            "@VideoID", videoId,
            "@InteractionID", interactionId,
            "@TimeSeconds", timeSeconds,
            "@Type", type,
            "@DataJson", dataJson,
            "@ActorID", actorId,
            "@IsAdmin", isAdmin,
            "@UpdatedUser", updatedUser);
    }
    else
    {
        DataTable dt = ServiceRegistry.Content.GetDataTable("InteractionCreate",
            "@VideoID", videoId,
            "@QuestionID", questionId,
            "@OffsetSeconds", offsetSeconds,
            "@Type", type,
            "@DataJson", dataJson,
            "@ActorID", actorId,
            "@IsAdmin", isAdmin,
            "@CreatedUser", createdUser);
    }
}
```

**SAU (VideoEditor.ascx.cs):**
```csharp
private void LoadInteractions()
{
    var videos = new SIM_Videos();
    DataTable dt = videos.GetInteractions(videoId, actorId, isAdmin);

    gvInteractions.DataSource = dt;
    gvInteractions.DataBind();
}

protected void InteractionSaveButton_Click(object sender, EventArgs e)
{
    var videos = new SIM_Videos();

    if (interactionId.HasValue)
    {
        bool success = videos.UpdateInteraction(
            videoId, interactionId, timeSeconds, type, dataJson,
            actorId, isAdmin, updatedUser);

        if (!success)
        {
            ShowError("Cập nhật thất bại");
            return;
        }
    }
    else
    {
        DataTable dt = videos.CreateInteraction(
            videoId, questionId, offsetSeconds, type, dataJson,
            actorId, isAdmin, createdUser);

        if (dt == null || dt.Rows.Count == 0)
        {
            ShowError("Tạo tương tác thất bại");
            return;
        }
    }
}
```

---

## 🎯 BƯỚC 4: TÙY CHỌN - THÊM CACHING QUA SERVICE

### Khi nào cần Service?

✅ **Cần Service khi:**
- Load dropdown/listbox nhiều lần
- Dữ liệu thay đổi ít
- Cần cache để tăng performance
- Cần UI Helpers (InitDropDownList, InitCheckBoxList)

❌ **Không cần Service khi:**
- Dữ liệu thay đổi thường xuyên
- Chỉ load 1 lần
- Query theo điều kiện động

### Template Service

```csharp
// LmsService/[Module]/[Module]Service.cs
using System;
using System.Data;
using LmsObject;

namespace LmsService.[Module]
{
    public partial class [Module]Service
    {
        static bool bolHaveNewData = false;
        static DataTable dtbTable = null;

        /// <summary>
        /// Static Table với caching
        /// </summary>
        public static DataTable Table
        {
            get
            {
                if (dtbTable == null || bolHaveNewData)
                {
                    var obj = new [ObjectName]();
                    dtbTable = obj.[MethodName](params...);
                    DataRow drw = dtbTable.NewRow();
                    dtbTable.Rows.InsertAt(drw, 0); // thêm dòng trống nếu cần
                    bolHaveNewData = false;
                }
                return dtbTable;
            }
            set { dtbTable = value; }
        }

        public static bool HaveNewData
        {
            get { return bolHaveNewData; }
            set { bolHaveNewData = value; }
        }

        #region UI Helpers

        /// <summary>
        /// Khởi tạo DropDownList. Chú ý data chỉ được load một lần.
        /// </summary>
        public static void InitDropDownList(System.Web.UI.WebControls.DropDownList ddl, string condition = "")
        {
            DataTable dtbCopy = null;
            if (!string.IsNullOrEmpty(condition))
            {
                dtbCopy = Table.Copy();
                dtbCopy.DefaultView.RowFilter = "(" + condition + ") or [KeyColumn] is null";
            }
            else
            {
                dtbCopy = Table;
            }

            ddl.DataSource = dtbCopy;
            ddl.DataTextField = [ObjectName].C_[DisplayColumn];
            ddl.DataValueField = [ObjectName].C_[KeyColumn];
            ddl.DataBind();
            ddl.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Chọn--", ""));
        }

        #endregion
    }
}
```

### Ví dụ Service thực tế

```csharp
// LmsService/Lesson/InteractionService.cs
using System;
using System.Data;
using LmsObject;

namespace LmsService.Lesson
{
    public partial class InteractionService
    {
        static bool bolHaveNewData = false;
        static DataTable dtbTable = null;

        public static DataTable Table
        {
            get
            {
                if (dtbTable == null || bolHaveNewData)
                {
                    var videos = new SIM_Videos();
                    dtbTable = videos.GetInteractions(null, null, false);
                    bolHaveNewData = false;
                }
                return dtbTable;
            }
            set { dtbTable = value; }
        }

        public static bool HaveNewData
        {
            get { return bolHaveNewData; }
            set { bolHaveNewData = value; }
        }
    }
}
```

### Gọi Service từ Presentation

```csharp
// Presentation layer
protected void Page_Load(object sender, EventArgs e)
{
    if (!IsPostBack)
    {
        // ✅ Gọi Service (có caching)
        DataTable dt = InteractionService.Table;

        gvInteractions.DataSource = dt;
        gvInteractions.DataBind();
    }
}

protected void btnUpdate_Click(object sender, EventArgs e)
{
    var videos = new SIM_Videos();
    bool success = videos.UpdateInteraction(...);

    if (success)
    {
        // ✅ Refresh cache
        InteractionService.HaveNewData = true;
        LoadInteractions();
    }
}
```

---

## ✅ BƯỚC 5: CHECKLIST KHI REFACTOR

### Checklist cho AI

- [ ] **Đọc file này trước khi bắt đầu**
- [ ] **Grep tìm tất cả `ServiceRegistry.Content`**
- [ ] **Phân tích mỗi kết quả:**
  - [ ] File nào đang gọi?
  - [ ] Stored procedure nào?
  - [ ] Object LmsObject tương ứng?
  - [ ] Có cần caching không?
- [ ] **Tạo method nghiệp vụ trong LmsObject:**
  - [ ] Đúng file partial class (KHÔNG sửa Base/)
  - [ ] XML comment đầy đủ
  - [ ] Sử dụng template đúng
  - [ ] GetDataTable hoặc ExecNonQuery
  - [ ] Exception handling đúng
- [ ] **Thay thế trong Presentation layer:**
  - [ ] Thay `ServiceRegistry.Content.GetDataTable()` → `new Object().Method()`
  - [ ] Thay `ServiceRegistry.Content.ExecNonQuery()` → `new Object().Method()`
  - [ ] Kiểm tra tham số truyền đúng
  - [ ] Xử lý return value nếu cần
- [ ] **Tùy chọn - Tạo Service nếu cần caching:**
  - [ ] Tạo file Service trong LmsService/[Module]/
  - [ ] Implement static Table property
  - [ ] Implement HaveNewData flag
  - [ ] Implement UI Helpers nếu cần
  - [ ] Thay Presentation gọi Service.Table
- [ ] **Test:**
  - [ ] Build thành công
  - [ ] Chạy page/control
  - [ ] Verify functionality

---

## 📋 CHECKLIST CHO USER

### User review checklist

- [ ] **Kiểm tra file LmsObject đã thêm method:**
  - [ ] Method có XML comment
  - [ ] Tham số đúng
  - [ ] Logic đúng
  - [ ] Exception handling đúng
- [ ] **Kiểm tra file Presentation đã thay đổi:**
  - [ ] Không còn `ServiceRegistry.Content`
  - [ ] Gọi method LmsObject đúng
  - [ ] Tham số truyền đúng
  - [ ] Xử lý return value nếu cần
- [ ] **Nếu có Service:**
  - [ ] Caching hoạt động đúng
  - [ ] HaveNewData được set khi data thay đổi
- [ ] **Test:**
  - [ ] Build thành công
  - [ ] Chạy application
  - [ ] Test functionality
  - [ ] Không có lỗi runtime

---

## 🚫 QUY TẮC KHÔNG VI PHẠM

### AI PHẢI TUÂN THỦ

1. **KHÔNG BAO GIỜ SỬA file trong `LmsObject/Base/`**
   - Chỉ sửa partial class (file cùng tên với Base nhưng không có hậu tố Base)

2. **LUÔN dùng template method**
   - GetDataTable cho SELECT
   - ExecNonQuery cho INSERT/UPDATE/DELETE

3. **LUÔN thêm XML comment**
   - Mô tả chức năng
   - Tên stored procedure
   - Mô tả tham số
   - Mô tả return value

4. **LUÔN xử lý exception**
   - Dùng try-catch-finally
   - Rollback transaction nếu cần
   - Log lỗi với SystemError
   - Disconnect nếu tạo mới connection

5. **KIỂM TRA tham số**
   - Nullable type (`int?`, `string`) cho tham số có thể null
   - Pass đúng tham số theo thứ tự

6. **KHÔNG refactor code không liên quan**
   - Chỉ refactor phần liên quan đến ServiceRegistry.Content
   - Không thay đổi logic khác

---

## 📚 TÀI LIỆU THAM KHẢO

- `WEB_ARCHITECTURE_RULES.md` - Quy tắc kiến trúc chi tiết
- `SO_SANH_CACH_GOI.md` - So sánh 2 cách gọi dữ liệu
- `4.SOUREC-MẪU/SimsObject/` - Mẫu Data Layer
- `4.SOUREC-MẪU/SimsService/` - Mẫu Business Layer

---

## 📝 GHI CHÚ CHO AI

### Khi AI nhận yêu cầu refactor

1. **Đọc file này trước** - `AI_REFACTOR_GUIDE.md`
2. **Nếu chưa rõ, hỏi user** trước khi bắt đầu
3. **Theo template** - Không tự ý thay đổi pattern
4. **Báo cáo rõ ràng** - Liệt kê file đã thay đổi, method đã tạo
5. **Công bố số lượng** - Bao nhiêu chỗ đã refactor

### Format báo cáo cho AI

```markdown
## 📊 KẾT QUẢ REFACTOR

### File LmsObject đã thêm method
- `LmsObject/[ObjectName].cs`
  - ✅ Added: MethodName1() - Description
  - ✅ Added: MethodName2() - Description

### File Presentation đã thay đổi
- `InformationWeb/Path/to/File.ascx.cs`
  - Line 127: Replaced ServiceRegistry.Content.GetDataTable → GetInteractions()
  - Line 523: Replaced ServiceRegistry.Content.ExecNonQuery → UpdateInteraction()
  - Line 549: Replaced ServiceRegistry.Content.GetDataTable → CreateInteraction()

### Stored procedures đã thay thế
- `InteractionList` → GetInteractions()
- `InteractionUpdate` → UpdateInteraction()
- `InteractionCreate` → CreateInteraction()

### Tổng kết
- ✅ Method added: 4
- ✅ Lines changed: 6
- ✅ Files modified: 2
```

---

**Phiên bản:** 1.0
**Ngày tạo:** 2026-10-22
**Áp dụng cho:** WEB-LMS-VS2010
**Dành cho:** AI Agent khi refactor code
