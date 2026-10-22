---
name: web-date-control
description: >-
  Tạo/copy control nhập ngày (date input) cho ASP.NET WebForms: TextBox
  dd/MM/yyyy + input type=date trong suốt phủ icon lịch để bấm mở lịch native,
  đồng bộ 2 chiều, mirror sang HiddenField khi modal nằm ngoài form. Có CSS
  đồng bộ kiểu trang tra-cuu-van-bang (grad-inp / grad-date-icon). Use when
  user nói control ngày, nhập ngày, icon lịch không bấm được, datepicker,
  date input, chọn ngày, web date control, dd/MM/yyyy.
---

# Web Date Control (ASP.NET WebForms)

Control nhập ngày dùng lại: **TextBox hiển thị `dd/MM/yyyy`** + **`<input type="date">` trong suốt phủ lên icon lịch** → bấm icon là mở lịch của trình duyệt. Không cần jQuery UI / datepicker ngoài.

## Khi nào dùng

- Cần chọn ngày trên WebForms nhưng project **không có** Telerik (`RadDatePicker`) hoặc không muốn thêm thư viện.
- User muốn bấm vào **icon lịch** để chọn ngày (thay vì gõ tay `dd/MM/yyyy`).
- Cần CSS khớp trang tra cứu (`/tra-cuu-van-bang` → `GraduationResult.ascx`).

Nếu project **đã có Telerik**: dùng `telerik:RadDatePicker` + CSS `.grad-datepicker` (xem `GraduationResult.ascx`) — **không** dùng skill này.

## Ba thành phần bắt buộc

| # | Thành phần | Vai trò |
|---|-----------|---------|
| 1 | `<asp:TextBox>` | Hiển thị + nhập tay `dd/MM/yyyy`, là nguồn dữ liệu chính |
| 2 | `<input type="date">` phủ icon | Mở lịch native, `opacity: 0`, `z-index` cao hơn icon |
| 3 | JS đồng bộ 2 chiều | `change` native → textbox; gõ tay → native; giữ ISO `yyyy-MM-dd` |

Chi tiết đầy đủ copy-paste: [reference.md](reference.md).

## Quy ước đặt tên

- Wrapper: `.<block>-date-wrap` (`position: relative`)
- TextBox: `.<block>-date-inp`
- Input native: `.<block>-date-native` + id `<%= txt.ClientID %>_native`
- Icon: `.<block>-date-icon`

`<block>` = tiền tố form (vd. `dorm-register`, `report-stat`). Đổi tên theo form, **không** giữ `dorm-register` khi sang form khác.

## CSS (chỉ đổi `<block>`)

```css
.<block>-date-wrap {
    position: relative;
}
.<block>-date-inp {
    height: 42px;
    border: 1px solid #d0d5dd;
    border-radius: 8px;
    padding: 0.5rem 0.875rem;
    font-size: 0.9375rem;
    box-shadow: none;
}
.<block>-date-wrap .<block>-date-inp {
    padding-right: 2.5rem;
}
.<block>-date-inp:focus {
    border-color: #86b7fe;
    box-shadow: 0 0 0 0.2rem rgba(13, 110, 253, 0.15);
}
.<block>-date-native {
    position: absolute;
    right: 0;
    top: 0;
    width: 42px;
    height: 100%;
    margin: 0;
    padding: 0;
    border: 0;
    background: transparent;
    opacity: 0;
    cursor: pointer;
    z-index: 3;
}
.<block>-date-icon {
    position: absolute;
    right: 12px;
    top: 50%;
    margin-top: -8px;
    color: #6c757d;
    font-size: 1rem;
    line-height: 1;
    pointer-events: none;
    z-index: 2;
}
.<block>-date-wrap:hover .<block>-date-icon,
.<block>-date-wrap:focus-within .<block>-date-icon {
    color: #0d6efd;
}
```

**Điểm cốt lõi:** `.date-native` phải `opacity: 0` + `z-index: 3` **cao hơn** `.date-icon` và `cursor: pointer`. Icon giữ `pointer-events: none` để không nuốt click.

## Markup

```html
<div class="<block>-date-wrap">
    <asp:TextBox ID="txtDate" runat="server" CssClass="form-control <block>-date-inp"
        MaxLength="10" placeholder="dd/MM/yyyy" autocomplete="off"
        onkeyup="dateSyncNative(this);" onchange="dateSyncNative(this);"></asp:TextBox>
    <input type="date" id="<%= txtDate.ClientID %>_native" class="<block>-date-native"
        aria-label="Chọn ngày" onclick="dateOpenPicker(this);" onchange="datePickNative(this);" />
    <span class="<block>-date-icon" aria-hidden="true"><i class="bi bi-calendar3"></i></span>
</div>
```

`<input type="date">` là **HTML thuần** — dùng `<%= txtDate.ClientID %>` render id được, không cần designer.

## JS (đổi tên hàm theo `<block>`)

```javascript
function dateParse(text) {
    if (!text) { return null; }
    var parts = text.replace(/^\s+|\s+$/g, '').split('/');
    if (parts.length !== 3) { return null; }
    var day = parseInt(parts[0], 10);
    var month = parseInt(parts[1], 10);
    var year = parseInt(parts[2], 10);
    if (!day || !month || !year || year < 1900) { return null; }
    var dt = new Date(year, month - 1, day);
    if (dt.getFullYear() !== year || dt.getMonth() !== (month - 1) || dt.getDate() !== day) { return null; }
    return dt;
}
function dateFormatIso(dt) {
    var day = dt.getDate();
    var month = dt.getMonth() + 1;
    var year = dt.getFullYear();
    return year + '-' + (month < 10 ? '0' : '') + month + '-' + (day < 10 ? '0' : '') + day;
}
function dateOpenPicker(nativeEl) {
    if (nativeEl && typeof nativeEl.showPicker === 'function') {
        try { nativeEl.showPicker(); } catch (ex) { }
    }
}
function datePickNative(nativeEl) {
    var txt = document.getElementById('<%= txtDate.ClientID %>');
    if (!txt || !nativeEl || !nativeEl.value) { return; }
    var parts = nativeEl.value.split('-');
    if (parts.length !== 3) { return; }
    txt.value = parts[2] + '/' + parts[1] + '/' + parts[0];
}
function dateSyncNative(txtEl) {
    var nativeEl = document.getElementById('<%= txtDate.ClientID %>_native');
    if (!txtEl || !nativeEl) { return; }
    var dt = dateParse(txtEl.value);
    nativeEl.value = dt ? dateFormatIso(dt) : '';
}
```

## Bẫy bắt buộc xử lý

### 1. Modal bị JS chuyển ra `document.body` → nằm NGOÀI `<form>`

Nếu form có kiểu `moveModalToBody()` (Bootstrap modal), server control trong modal **không post value**. Phải mirror sang `HiddenField` **đặt trong `UpdatePanel`**:

```html
<!-- Trong ContentTemplate của UpdatePanel -->
<asp:HiddenField ID="hidDate" runat="server" Value="" />
```

```javascript
function dateSyncHidden() {
    var txt = document.getElementById('<%= txtDate.ClientID %>');
    var hid = document.getElementById('<%= hidDate.ClientID %>');
    if (txt && hid) { hid.value = txt.value; }
}
```

Gọi `dateSyncHidden()` trong preview/validate **và** trong `OnClientClick` của nút submit:

```html
OnClientClick="dateSyncHidden(); return true;"
```

Code-behind đọc hidden trước, fallback textbox:

```csharp
string strDate = hidDate.Value;
if (string.IsNullOrEmpty(strDate)) { strDate = txtDate.Text; }
DateTime dtmDate;
if (!DateTime.TryParseExact(strDate.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture,
        DateTimeStyles.None, out dtmDate)) { /* cảnh báo */ }
```

### 2. Đồng bộ lại sau async postback

Modal ngoài UpdatePanel nên `__doPostBack` không cập nhật lại textbox/native. Thêm vào `add_endRequest`:

```javascript
Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
    dateSyncNative(document.getElementById('<%= txtDate.ClientID %>'));
});
```

### 3. Không dùng `type="date"` cho dữ liệu gửi lên server

`<input type="date">` là **chỉ để chọn cho tiện**, không phải nguồn submit. Server luôn nhận `dd/MM/yyyy` từ textbox/hidden.

## Kiểm tra trước khi xong

```
Task Progress:
- [ ] 1. CSS: .date-native opacity 0, z-index 3 > .date-icon, cursor pointer
- [ ] 2. Icon có pointer-events: none
- [ ] 3. Input native có id <ClientID>_native
- [ ] 4. Nếu trong modal move-to-body: có HiddenField trong UpdatePanel + sync khi submit
- [ ] 5. Có add_endRequest sync lại sau postback
- [ ] 6. Validate server: DateTime.TryParseExact "dd/MM/yyyy" InvariantCulture
- [ ] 7. Đổi tên `<block>` khớp form mới, không giữ tiền tố form cũ
```

## Lỗi thường gặp

| Triệu chứng | Nguyên nhân |
|-------------|-------------|
| Bấm icon lịch không có gì xảy ra | Thiếu `<input type="date">` phủ, hoặc `z-index` native thấp hơn icon, hoặc icon chưa `pointer-events: none` |
| Chọn ngày xong textbox không đổi | Thiếu `onchange="datePickNative(this)"` |
| Submit lên server mất ngày | Modal ngoài `<form>` → chưa mirror sang HiddenField trong UpdatePanel |
| Sau postback icon lịch lệch ngày | Chưa gọi `dateSyncNative` trong `add_endRequest` |
| Hiển thị `MM/dd/yyyy` | `type="date"` hiển thị theo locale trình duyệt — luôn ép lại `dd/MM/yyyy` vào textbox |
