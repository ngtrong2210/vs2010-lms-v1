(function () {
    "use strict";
    var jsonInput = document.querySelector('input[id$="PermissionsJsonValue"]');
    var codeInput = document.querySelector('input[id$="SelectedRoleCodeValue"]');
    var codesText = document.querySelector('textarea[id$="PermissionCodesText"]');
    var host = document.querySelector('[data-permission-groups="true"]');
    if (!jsonInput || !host) return;
    var items = [];
    try {
        items = JSON.parse(jsonInput.value || "[]");
    } catch (ignore) {
        items = [];
    }
    var admin = codeInput && codeInput.value === "ADMIN";
    var moduleNames = {
        DASHBOARD: "Tổng quan",
        COURSE: "Khóa học",
        CHAPTER: "Chương",
        LESSON: "Bài học",
        VIDEO: "Video",
        QUESTION: "Câu hỏi",
        STUDENT: "Học viên",
        ENROLLMENT: "Ghi danh",
        REPORT: "Báo cáo",
        SYSTEM: "Hệ thống",
    };
    var moduleIcons = {
        DASHBOARD: "bi-grid",
        COURSE: "bi-journal-bookmark",
        CHAPTER: "bi-list-ol",
        LESSON: "bi-play-btn",
        VIDEO: "bi-camera-video",
        QUESTION: "bi-patch-question",
        STUDENT: "bi-people",
        ENROLLMENT: "bi-person-plus",
        REPORT: "bi-bar-chart",
        SYSTEM: "bi-gear",
    };
    function esc(value) {
        var div = document.createElement("div");
        div.textContent = value == null ? "" : String(value);
        return div.innerHTML;
    }
    var groups = {},
        order = [];
    for (var i = 0; i < items.length; i += 1) {
        var module = items[i].Module || "OTHER";
        if (!groups[module]) {
            groups[module] = [];
            order.push(module);
        }
        groups[module].push(items[i]);
    }
    var html = "";
    for (var g = 0; g < order.length; g += 1) {
        var key = order[g],
            rows = groups[key],
            all = true,
            options = "";
        for (var j = 0; j < rows.length; j += 1) {
            if (!rows[j].IsGranted) all = false;
            options +=
                '<label class="permission-option' +
                (rows[j].IsGranted ? " checked" : "") +
                (admin ? " disabled" : "") +
                '"><input type="checkbox" data-permission-code="' +
                esc(rows[j].Code) +
                '"' +
                (rows[j].IsGranted ? " checked" : "") +
                (admin ? " disabled" : "") +
                "><span><strong>" +
                esc(rows[j].Name) +
                "</strong><small>" +
                esc(rows[j].Code) +
                "</small></span></label>";
        }
        html +=
            '<section class="permission-group" data-permission-module="' +
            esc(key) +
            '"><header><div><i class="bi ' +
            (moduleIcons[key] || "bi-box") +
            '"></i><span><strong>' +
            esc(moduleNames[key] || key) +
            "</strong><small>" +
            rows.length +
            " chức năng</small></span></div>" +
            (admin
                ? ""
                : '<label class="permission-toggle-all"><input type="checkbox" data-toggle-module="' +
                  esc(key) +
                  '"' +
                  (all ? " checked" : "") +
                  "> Chọn nhóm</label>") +
            '</header><div class="permission-grid">' +
            options +
            "</div></section>";
    }
    host.innerHTML = html;
    function updateOption(input) {
        var label = input.parentNode;
        label.className = "permission-option" + (input.checked ? " checked" : "") + (admin ? " disabled" : "");
    }
    var checks = host.querySelectorAll("[data-permission-code]");
    for (var c = 0; c < checks.length; c += 1)
        checks[c].onchange = function () {
            updateOption(this);
        };
    var toggles = host.querySelectorAll("[data-toggle-module]");
    for (var t = 0; t < toggles.length; t += 1)
        toggles[t].onchange = function () {
            var section = this.parentNode.parentNode.parentNode;
            var groupChecks = section.querySelectorAll("[data-permission-code]");
            for (var k = 0; k < groupChecks.length; k += 1) {
                groupChecks[k].checked = this.checked;
                updateOption(groupChecks[k]);
            }
        };
    var form = host.closest("form") || document.forms[0];
    if (form)
        form.addEventListener("submit", function () {
            if (!codesText || admin) return;
            var values = [];
            var selected = host.querySelectorAll("[data-permission-code]:checked");
            for (var n = 0; n < selected.length; n += 1) values.push(selected[n].getAttribute("data-permission-code"));
            codesText.value = values.join("\n");
        });
})();
