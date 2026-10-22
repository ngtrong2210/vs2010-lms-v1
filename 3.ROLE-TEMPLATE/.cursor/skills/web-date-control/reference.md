# reference.md — code gốc copy-paste

Nguồn: `1.WEB -CTT/Controls/Dorm/DormRegister/StudentRegister.ascx` (block `dorm-register`).

## CSS gốc (Style/dorm-bed-view.css)

```css
.dorm-register-lease-label {
    margin-bottom: 0.2rem;
    font-size: 0.75rem;
    font-weight: 600;
    color: #64748b;
}

.dorm-register-date-wrap {
    position: relative;
}

.dorm-register-date-inp {
    height: 42px;
    border: 1px solid #d0d5dd;
    border-radius: 8px;
    padding: 0.5rem 0.875rem;
    font-size: 0.9375rem;
    box-shadow: none;
}

.dorm-register-date-wrap .dorm-register-date-inp {
    padding-right: 2.5rem;
}

.dorm-register-date-native {
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

.dorm-register-date-inp:focus {
    border-color: #86b7fe;
    box-shadow: 0 0 0 0.2rem rgba(13, 110, 253, 0.15);
}

.dorm-register-date-icon {
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

.dorm-register-date-wrap:hover .dorm-register-date-icon,
.dorm-register-date-wrap:focus-within .dorm-register-date-icon {
    color: #0d6efd;
}
```

## Markup gốc

```html
<div class="col-6">
    <label class="form-label dorm-register-lease-label">Từ ngày</label>
    <div class="dorm-register-date-wrap">
        <asp:TextBox ID="txtConfirmStartDate" runat="server" CssClass="form-control dorm-register-date-inp"
            MaxLength="10" placeholder="dd/MM/yyyy" autocomplete="off"
            onkeyup="dormRegisterUpdateLeasePreview(); dormRegisterSyncNativeDate();"
            onchange="dormRegisterUpdateLeasePreview(); dormRegisterSyncNativeDate();"></asp:TextBox>
        <input type="date" id="<%= txtConfirmStartDate.ClientID %>_native" class="dorm-register-date-native" aria-label="Chọn ngày bắt đầu"
            onclick="dormRegisterOpenNativePicker(this);" onchange="dormRegisterPickNativeDate(this);" />
        <span class="dorm-register-date-icon" aria-hidden="true"><i class="bi bi-calendar3"></i></span>
    </div>
</div>
```

HiddenField mirror (trong `ContentTemplate` của `UpdatePanel`):

```html
<asp:HiddenField ID="hidConfirmStartDate" runat="server" Value="" />
<asp:HiddenField ID="hidConfirmQuantity" runat="server" Value="" />
```

## JS gốc

```javascript
function dormRegisterConfirmParseDate(text) {
    if (!text) {
        return null;
    }
    var parts = text.replace(/^\s+|\s+$/g, '').split('/');
    if (parts.length !== 3) {
        return null;
    }
    var day = parseInt(parts[0], 10);
    var month = parseInt(parts[1], 10);
    var year = parseInt(parts[2], 10);
    if (!day || !month || !year || year < 1900) {
        return null;
    }
    var dt = new Date(year, month - 1, day);
    if (dt.getFullYear() !== year || dt.getMonth() !== (month - 1) || dt.getDate() !== day) {
        return null;
    }
    return dt;
}
function dormRegisterConfirmFormatDate(dt) {
    var day = dt.getDate();
    var month = dt.getMonth() + 1;
    var year = dt.getFullYear();
    return (day < 10 ? '0' : '') + day + '/' + (month < 10 ? '0' : '') + month + '/' + year;
}
function dormRegisterConfirmFormatIso(dt) {
    var day = dt.getDate();
    var month = dt.getMonth() + 1;
    var year = dt.getFullYear();
    return year + '-' + (month < 10 ? '0' : '') + month + '-' + (day < 10 ? '0' : '') + day;
}
function dormRegisterOpenNativePicker(nativeEl) {
    if (nativeEl && typeof nativeEl.showPicker === 'function') {
        try {
            nativeEl.showPicker();
        } catch (ex) {
        }
    }
}
function dormRegisterPickNativeDate(nativeEl) {
    var txtStart = document.getElementById('<%= txtConfirmStartDate.ClientID %>');
    if (!txtStart || !nativeEl || !nativeEl.value) {
        return;
    }
    var parts = nativeEl.value.split('-');
    if (parts.length !== 3) {
        return;
    }
    txtStart.value = parts[2] + '/' + parts[1] + '/' + parts[0];
    dormRegisterUpdateLeasePreview();
}
function dormRegisterSyncNativeDate() {
    var txtStart = document.getElementById('<%= txtConfirmStartDate.ClientID %>');
    var nativeEl = document.getElementById('<%= txtConfirmStartDate.ClientID %>_native');
    if (!txtStart || !nativeEl) {
        return;
    }
    var dt = dormRegisterConfirmParseDate(txtStart.value);
    nativeEl.value = dt ? dormRegisterConfirmFormatIso(dt) : '';
}
function dormRegisterSyncLeaseHidden() {
    var txtStart = document.getElementById('<%= txtConfirmStartDate.ClientID %>');
    var txtQty = document.getElementById('<%= txtConfirmQuantity.ClientID %>');
    var hidStart = document.getElementById('<%= hidConfirmStartDate.ClientID %>');
    var hidQty = document.getElementById('<%= hidConfirmQuantity.ClientID %>');
    if (txtStart && hidStart) {
        hidStart.value = txtStart.value;
    }
    if (txtQty && hidQty) {
        hidQty.value = txtQty.value;
    }
}
```

Init + sync sau postback:

```javascript
dormRegisterMoveConfirmModalToBody();
dormRegisterSyncNativeDate();
if (window.Sys && Sys.WebForms && Sys.WebForms.PageRequestManager) {
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
        dormRegisterMoveConfirmModalToBody();
        dormRegisterSyncNativeDate();
    });
}
```

## Nút submit

```html
<asp:LinkButton ID="btnModalConfirm" runat="server" CssClass="btn btn-success btn-sm"
    OnClick="btnModalConfirm_Click" CausesValidation="false"
    OnClientClick="dormRegisterSyncLeaseHidden(); if(!dormRegisterConfirmValidate()){return false;} return true;">
    <i class="bi bi-check2-circle"></i> Xác nhận đăng ký
</asp:LinkButton>
```

## Code-behind C# (validate + đọc hidden)

```csharp
private bool TryParseLeaseInput(out DateTime startDate, out decimal quantity)
{
    startDate = DateTime.MinValue;
    quantity = 0;
    string strStartDate = hidConfirmStartDate.Value;
    if (string.IsNullOrEmpty(strStartDate))
    {
        strStartDate = txtConfirmStartDate.Text;
    }
    string strQuantity = hidConfirmQuantity.Value;
    if (string.IsNullOrEmpty(strQuantity))
    {
        strQuantity = txtConfirmQuantity.Text;
    }
    if (!DateTime.TryParseExact(strStartDate.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate))
    {
        MsgBox.ShowWarning("Vui lòng nhập Từ ngày hợp lệ (dd/MM/yyyy).");
        return false;
    }
    if (!decimal.TryParse(strQuantity.Trim().Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out quantity) || quantity <= 0)
    {
        MsgBox.ShowWarning("Vui lòng nhập Số tháng thuê hợp lệ.");
        return false;
    }
    return true;
}
```

## Biến thể CSS kiểu tra-cuu-van-bang (Telerik)

Nếu form dùng `telerik:RadDatePicker`, xem CSS `.grad-datepicker` trong
`1.WEB -CTT/Controls/Sims/GraduationResult.ascx` — cùng kích thước 42px /
border `#d0d5dd` / radius 8px / icon `bi-calendar3` bên phải.
