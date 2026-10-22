# SO SÁNH 2 CÁCH GỌI DỮ LIỆU TRONG LMS

---

## 🔍 TỔNG QUAN

Tài liệu này so sánh 2 cách gọi dữ liệu trong dự án WEB-LMS-VS2010:

1. **Cách 1 (CŨ)**: Gọi trực tiếp `ServiceRegistry.Content` - KHÔNG KHUYẾN NGHỊ
2. **Cách 2 (MỚI)**: Gọi thông qua `LmsObject` - CHUẨN KIẾN TRÚC

---

## 📝 CÁCH 1 (CŨ - KHÔNG KHUYẾN NGHỊ)

### Code mẫu

```csharp
DataTable dt = ServiceRegistry.InteractiveContent.GetDataTable("get_list", param1, param2);
```

Hoặc:

```csharp
ServiceRegistry.Content.ExecNonQuery("InteractionUpdate", param1, param2, param3);
```

### Đặc điểm

- ❌ Gọi trực tiếp `ServiceRegistry.Content` (global registry)
- ❌ Truyền string tên stored procedure (`"get_list"`, `"InteractionUpdate"`)
- ❌ Logic nghiệp vụ nằm ở Presentation layer
- ❌ Không có caching
- ❌ Khó test unit
- ❌ Không tuân thủ kiến trúc n-tier
- ❌ Không có type safety (string SP name dễ sai)
- ❌ Code lặp lại nhiều nơi

### Ví dụ thực tế (trước khi refactor)

```csharp
// VideoEditor.ascx.cs - Line 127
DataTable dt = ServiceRegistry.Content.GetDataTable("InteractionList",
    "@VideoID", videoId,
    "@ActorID", actorId,
    "@IsAdmin", isAdmin);

// VideoEditor.ascx.cs - Line 523
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

---

## ✅ CÁCH 2 (MỚI - CHUẨN KIẾN TRÚC)

### Code mẫu

```csharp
var interactiveContent = new LMS_InteractiveContents();
DataTable dt = interactiveContent.GetInteractions(videoId, actorId, isAdmin);
```

Hoặc viết gọn:

```csharp
DataTable dt = new LMS_InteractiveContents().GetInteractions(videoId, actorId, isAdmin);
```

### Đặc điểm

- ✅ Gọi thông qua `LmsObject` (Data Layer)
- ✅ Method nghiệp vụ có tên rõ ràng (`GetInteractions`)
- ✅ Tham số được định nghĩa rõ ràng (`videoId, actorId, isAdmin`)
- ✅ Logic nghiệp vụ nằm ở đúng layer
- ✅ Có thể thêm caching qua Service nếu cần
- ✅ Dễ test unit
- ✅ Tuân thủ kiến trúc n-tier
- ✅ Type safety (compile-time check)
- ✅ Method tái sử dụng

### Ví dụ thực tế (sau khi refactor)

```csharp
// LmsObject/SIM_Videos.cs - Method nghiệp vụ
public partial class SIM_Videos
{
    /// <summary>
    /// Lấy danh sách tương tác của video
    /// Store: InteractionList
    /// </summary>
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

// VideoEditor.ascx.cs - Gọi method nghiệp vụ
DataTable dt = new SIM_Videos().GetInteractions(videoId, actorId, isAdmin);

bool success = new SIM_Videos().UpdateInteraction(
    videoId, interactionId, timeSeconds, type, dataJson,
    actorId, isAdmin, updatedUser);
```

---

## 📊 BẢNG SO SÁNH CHI TIẾT

| Tiêu chí | Cách 1 (ServiceRegistry) | Cách 2 (LmsObject) |
|----------|-------------------------|-------------------|
| **Layer** | Violate (gọi ServiceRegistry global) | Data Layer (LmsObject) |
| **Kiểu gọi** | `ServiceRegistry.Content.GetDataTable("SP_Name")` | `new Object().Method()` |
| **Tham số** | String SP name + params tuần tự | Method parameters rõ ràng |
| **Type Safety** | ❌ String SP name dễ sai | ✅ Compile-time check |
| **Tái sử dụng** | ❌ Code lặp lại nhiều nơi | ✅ Method tái sử dụng |
| **Caching** | ❌ Không có | ✅ Có thể qua Service |
| **Test** | ❌ Khó mock | ✅ Dễ mock và test |
| **Maintain** | ❌ Phải search string SP | ✅ Tìm theo method name |
| **IntelliSense** | ❌ Không hỗ trợ | ✅ IDE gợi ý method |
| **Refactoring** | ❌ Đổi string dễ | ✅ Đổi method name dễ |
| **Architecture** | ❌ Không tuân thủ n-tier | ✅ Tuân thủ n-tier |
| **Code Review** | ❌ Khó review logic | ✅ Method tách biệt |

---

## 🎯 KIẾN TRÚC ĐÚNG (Theo WEB_ARCHITECTURE_RULES.md)

```
┌─────────────────────────────────────────────────────────┐
│                  InformationWeb (Presentation)           │
│  - Web Forms Pages (.aspx + .aspx.cs)                    │
│  - User Controls (.ascx + .ascx.cs)                      │
└──────────────────────┬──────────────────────────────────┘
                       │ GỌI LmsService (UI helpers, caching)
                       │ GỌI TRỰC TIẾP LmsObject (data methods)
                       ▼
┌─────────────────────────────────────────────────────────┐
│                   LmsService (Business)                  │
│  - Services theo module (Auth, User, Course...)          │
│  - UI Helpers (Init controls, caching)                   │
│  - Business Logic (tính toán, xử lý nghiệp vụ)           │
└──────────────────────┬──────────────────────────────────┘
                       │ GỌI LmsObject
                       ▼
┌─────────────────────────────────────────────────────────┐
│                    LmsObject (Data)                      │
│  - Base/ (Auto-generated CRUD)                           │
│  - Partial classes (Custom logic + DCore calls)          │
│  - Direct database access via DCore                      │
└──────────────────────┬──────────────────────────────────┘
                       │ SQL STORED PROCEDURES
                       ▼
                    Database
```

---

## 💡 FLOW CHUẨN

### Flow 1: Không cần caching (Trực tiếp từ Presentation)

```csharp
// Presentation layer (VideoEditor.ascx.cs)
protected void LoadInteractions()
{
    // ✅ ĐÚNG - Gọi trực tiếp LmsObject
    var videos = new SIM_Videos();
    DataTable dt = videos.GetInteractions(videoId, actorId, isAdmin);

    gvInteractions.DataSource = dt;
    gvInteractions.DataBind();
}
```

**Flow:**
```
Presentation (VideoEditor.ascx.cs)
    ↓ Gọi new SIM_Videos().GetInteractions()
Data (LmsObject/SIM_Videos.cs)
    ↓ GetDataTable("InteractionList")
Database
```

---

### Flow 2: Cần caching (Qua Service)

```csharp
// Business layer (LmsService/Lesson/InteractionService.cs)
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

// Presentation layer (VideoEditor.ascx.cs)
protected void LoadInteractions()
{
    // ✅ ĐÚNG - Gọi Service (có caching)
    DataTable dt = InteractionService.Table;

    gvInteractions.DataSource = dt;
    gvInteractions.DataBind();
}
```

**Flow:**
```
Presentation (VideoEditor.ascx.cs)
    ↓ Gọi InteractionService.Table
Business (LmsService/Lesson/InteractionService.cs)
    ↓ Kiểm tra bolHaveNewData
    ↓ Nếu true hoặc null:
    ↓   Gọi new SIM_Videos().GetInteractions()
Data (LmsObject/SIM_Videos.cs)
    ↓ GetDataTable("InteractionList")
Database
```

---

## 🔄 VÍ DỤ REFACTOR THỰC TẾ

### Trước refactor (Cách 1)

```csharp
// VideoEditor.ascx.cs - Line 127
private void LoadInteractions()
{
    DataTable dt = ServiceRegistry.Content.GetDataTable("InteractionList",
        "@VideoID", videoId,
        "@ActorID", actorId,
        "@IsAdmin", isAdmin);

    gvInteractions.DataSource = dt;
    gvInteractions.DataBind();
}

// VideoEditor.ascx.cs - Line 523
protected void InteractionSaveButton_Click(object sender, EventArgs e)
{
    if (interactionId.HasValue)
    {
        // Update
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
        // Create
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

---

### Sau refactor (Cách 2)

```csharp
// LmsObject/SIM_Videos.cs - Thêm method nghiệp vụ
public partial class SIM_Videos
{
    public DataTable GetInteractions(int? videoId, int? actorId, bool isAdmin)
    {
        return GetDataTable("InteractionList",
            "@VideoID", videoId,
            "@ActorID", actorId,
            "@IsAdmin", isAdmin);
    }

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

    public DataTable CreateInteraction(int? videoId, int? questionId, int? offsetSeconds,
        string type, string dataJson, int? actorId, bool isAdmin, string createdUser)
    {
        return GetDataTable("InteractionCreate",
            "@VideoID", videoId,
            "@QuestionID", questionId,
            "@OffsetSeconds", offsetSeconds,
            "@Type", type,
            "@DataJson", dataJson,
            "@ActorID", actorId,
            "@IsAdmin", isAdmin,
            "@CreatedUser", createdUser);
    }

    public bool DeleteInteraction(int? videoId, int? interactionId, int? actorId, bool isAdmin)
    {
        if (!bolIsExistIData)
            objIData = DCore.Data.CreateData();
        try
        {
            objIData.CreateNewStoredProcedure("InteractionDelete");
            objIData.AddParameter("@VideoID", videoId);
            objIData.AddParameter("@InteractionID", interactionId);
            objIData.AddParameter("@ActorID", actorId);
            objIData.AddParameter("@IsAdmin", isAdmin);
            objIData.ExecNonQuery();
            return true;
        }
        catch (Exception objEx)
        {
            if (bolIsExistIData)
                this.RollBackTransaction();
            new SystemError(SystemConfig.ConnectionString, "Lỗi xóa tương tác video", objEx);
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

// VideoEditor.ascx.cs - Gọi method nghiệp vụ
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
        // Update
        bool success = videos.UpdateInteraction(
            videoId, interactionId, timeSeconds, type, dataJson,
            actorId, isAdmin, updatedUser);
    }
    else
    {
        // Create
        DataTable dt = videos.CreateInteraction(
            videoId, questionId, offsetSeconds, type, dataJson,
            actorId, isAdmin, createdUser);
    }
}
```

---

## 📋 CHECKLIST REFACTOR

### Bước 1: Tìm các chỗ dùng ServiceRegistry.Content

```bash
# Grep trong project
grep -r "ServiceRegistry.Content" InformationWeb/
```

### Bước 2: Tạo method nghiệp vụ trong LmsObject

- [ ] Xác định object LmsObject tương ứng
- [ ] Tạo method trong partial class
- [ ] Định nghĩa tham số rõ ràng
- [ ] Implement logic gọi stored procedure
- [ ] Thêm exception handling
- [ ] Thêm XML comment

### Bước 3: Thay thế trong Presentation layer

- [ ] Thay `ServiceRegistry.Content.GetDataTable()` → `new Object().Method()`
- [ ] Thay `ServiceRegistry.Content.ExecNonQuery()` → `new Object().Method()`
- [ ] Kiểm tra tham số truyền đúng
- [ ] Test functionality

### Bước 4: Tùy chọn - Thêm caching

- [ ] Tạo Service nếu cần caching
- [ ] Implement static Table property
- [ ] Implement HaveNewData flag
- [ ] Thay Presentation gọi Service.Table

---

## ⚠️ QUY TẮC QUAN TRỌNG

### LUÔN LUÔN NHỚ

1. **Base files không sửa** (Chỉ sửa partial class trong LmsObject)
2. **Partial class có thể gọi DCore trực tiếp**
3. **Service dùng static DataTable với caching**
4. **Service cung cấp UI Helpers (init controls)**
5. **Presentation có thể gọi Service hoặc LmsObject trực tiếp**
6. **Set HaveNewData = true khi data thay đổi**
7. **Exception handling với SystemError**
8. **KHÔNG dùng ServiceRegistry.Content nữa**

### NẾU VI PHẠM

- Code khó maintain
- Logic lộn xộn
- Bug khó tìm
- Không tái sử dụng được
- Vi phạm kiến trúc n-tier

---

## 📚 TÀI LIỆU THAM KHẢO

- `WEB_ARCHITECTURE_RULES.md` - Quy tắc kiến trúc dự án
- `BAO_CAO_KY_THUAT.md` - Báo cáo kỹ thuật refactor video interactions
- `4.SOUREC-MẪU/SimsObject/` - Cấu trúc Data Layer mẫu
- `4.SOUREC-MẪU/SimsService/` - Cấu trúc Business Layer mẫu

---

## 📝 GHI CHÚ

- Tài liệu này áp dụng cho toàn bộ dự án WEB-LMS-VS2010
- Khi refactor, luôn tuân thủ pattern trong `WEB_ARCHITECTURE_RULES.md`
- Mọi dev phải đọc và tuân thủ quy tắc này

---

**Phiên bản:** 1.0
**Ngày tạo:** 2026-10-22
**Áp dụng cho:** WEB-LMS-VS2010
