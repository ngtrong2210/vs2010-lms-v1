(function () {
    "use strict";

    function getModal() {
        return document.querySelector(".user-modal-backdrop");
    }
    function setOpen(open) {
        var modal = getModal();
        if (!modal) return;
        var openValue = modal.querySelector('input[id$="UserModalOpenValue"]');
        modal.className = open
            ? "system-modal-backdrop user-modal-backdrop is-open"
            : "system-modal-backdrop user-modal-backdrop";
        if (openValue) openValue.value = open ? "1" : "0";
        document.body.classList[open ? "add" : "remove"]("system-modal-open");
    }
    function resetCreateForm() {
        var modal = getModal();
        if (!modal) return;
        var edit = modal.querySelector('input[id$="EditUserIdValue"]');
        if (edit) edit.value = "";
        var fields = modal.querySelectorAll('input[type="text"],input[type="password"]');
        for (var i = 0; i < fields.length; i += 1) {
            fields[i].value = "";
            fields[i].disabled = false;
        }
        var status = modal.querySelector('select[id$="UserStatusList"]');
        if (status) status.value = "ACTIVE";
        var roles = modal.querySelectorAll('[id$="UserRolesList"] input[type="checkbox"]');
        for (var j = 0; j < roles.length; j += 1) roles[j].checked = j === 0;
        var title = modal.querySelector("h2");
        if (title) title.textContent = "Thêm người dùng mới";
        var save = modal.querySelector('input[id$="CreateUserButton"]');
        if (save) save.value = "Lưu người dùng";
    }

    function initializeModal() {
        var modal = getModal();
        if (!modal) return;
        var openValue = modal.querySelector('input[id$="UserModalOpenValue"]');
        var create = document.querySelector('[data-user-create="true"]');
        if (create)
            create.onclick = function () {
                resetCreateForm();
                setOpen(true);
            };
        var closes = modal.querySelectorAll('[data-user-close="true"]');
        for (var i = 0; i < closes.length; i += 1)
            closes[i].onclick = function () {
                setOpen(false);
            };
        modal.onclick = function (event) {
            if (event.target === modal) setOpen(false);
        };
        if (openValue && openValue.value === "1") setOpen(true);
        else document.body.classList.remove("system-modal-open");
    }

    document.addEventListener("keydown", function (event) {
        if (event.keyCode === 27) setOpen(false);
    });
    initializeModal();
    if (window.Sys && window.Sys.WebForms && window.Sys.WebForms.PageRequestManager) {
        window.Sys.WebForms.PageRequestManager.getInstance().add_endRequest(initializeModal);
    }
})();
