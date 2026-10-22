(function () {
    "use strict";
    var source = document.querySelector('input[id$="SettingsJsonValue"]');
    var save = document.querySelector('input[id$="SettingsSaveJsonValue"]');
    var host = document.querySelector('[data-settings-host="true"]');
    if (!source || !save || !host) return;
    var items = [];
    try {
        items = JSON.parse(source.value || "[]");
    } catch (ignore) {
        items = [];
    }
    var categoryMeta = {
        GENERAL: {
            name: "Thông tin chung",
            description: "Tên hệ thống, đơn vị vận hành và kênh hỗ trợ.",
            icon: "bi-building",
        },
        LEARNING: {
            name: "Quy tắc học tập",
            description: "Giá trị mặc định áp dụng khi tạo nội dung đào tạo.",
            icon: "bi-mortarboard",
        },
        SECURITY: {
            name: "Bảo mật và vận hành",
            description: "Kiểm soát phiên đăng nhập và trạng thái bảo trì.",
            icon: "bi-shield-lock",
        },
    };
    var typeIcons = { NUMBER: "bi-123", EMAIL: "bi-envelope", URL: "bi-link-45deg" };
    var inputTypes = { NUMBER: "number", EMAIL: "email", URL: "url" };
    function esc(value) {
        var div = document.createElement("div");
        div.textContent = value == null ? "" : String(value);
        return div.innerHTML;
    }
    function attr(value) {
        return esc(value).replace(/"/g, "&quot;");
    }
    var groups = {},
        order = [];
    for (var i = 0; i < items.length; i += 1) {
        var category = items[i].Category || "OTHER";
        if (!groups[category]) {
            groups[category] = [];
            order.push(category);
        }
        groups[category].push(items[i]);
    }
    var html = "";
    for (var g = 0; g < order.length; g += 1) {
        var key = order[g],
            meta = categoryMeta[key] || { name: key, description: "Cấu hình hệ thống.", icon: "bi-sliders" },
            fields = "";
        for (var j = 0; j < groups[key].length; j += 1) {
            var item = groups[key][j],
                dataType = item.DataType || "TEXT",
                booleanField = dataType === "BOOLEAN";
            if (booleanField)
                fields +=
                    '<label class="setting-field is-boolean"><span><strong>' +
                    esc(item.SettingName) +
                    "</strong><small>" +
                    esc(item.Description) +
                    '</small></span><input class="form-check-input" type="checkbox" data-setting-key="' +
                    attr(item.SettingKey) +
                    '" data-setting-type="BOOLEAN"' +
                    (String(item.SettingValue).toLowerCase() === "true" ? " checked" : "") +
                    "></label>";
            else
                fields +=
                    '<label class="setting-field"><span><strong>' +
                    esc(item.SettingName) +
                    "</strong><small>" +
                    esc(item.Description) +
                    '</small></span><div class="setting-input-wrap"><i class="bi ' +
                    (typeIcons[dataType] || "bi-fonts") +
                    '"></i><input class="form-control" type="' +
                    (inputTypes[dataType] || "text") +
                    '" data-setting-key="' +
                    attr(item.SettingKey) +
                    '" data-setting-type="' +
                    attr(dataType) +
                    '" value="' +
                    attr(item.SettingValue) +
                    '"' +
                    (dataType === "NUMBER" ? ' min="0"' : "") +
                    "></div></label>";
        }
        html +=
            '<section class="app-card settings-group"><header><div class="settings-group-icon"><i class="bi ' +
            meta.icon +
            '"></i></div><div><span class="system-kicker">' +
            esc(key) +
            "</span><h2>" +
            esc(meta.name) +
            "</h2><p>" +
            esc(meta.description) +
            '</p></div></header><div class="settings-grid">' +
            fields +
            "</div></section>";
    }
    host.innerHTML = html;
    var form = host.closest("form") || document.forms[0];
    if (form)
        form.addEventListener("submit", function () {
            var controls = host.querySelectorAll("[data-setting-key]"),
                payload = [];
            for (var k = 0; k < controls.length; k += 1)
                payload.push({
                    SettingKey: controls[k].getAttribute("data-setting-key"),
                    SettingValue:
                        controls[k].getAttribute("data-setting-type") === "BOOLEAN"
                            ? String(controls[k].checked)
                            : controls[k].value,
                });
            save.value = JSON.stringify(payload);
        });
})();
