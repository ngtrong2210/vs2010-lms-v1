(function (window, document) {
    "use strict";

    function close() {
        var modal = document.getElementById("courseSettingsModal");
        if (!modal) return;
        modal.hidden = true;
        document.body.classList.remove("modal-open");
        var openValue = document.getElementById("CourseSettingsOpenValue");
        if (openValue) openValue.value = "";
    }

    function initializeModal() {
        var modal = document.getElementById("courseSettingsModal");
        if (!modal) return;
        var openValue =
            document.getElementById("CourseSettingsOpenValue") ||
            document.querySelector('[id$="_CourseSettingsOpenValue"]');
        if ((openValue || {}).value === "1") {
            modal.hidden = false;
            document.body.classList.add("modal-open");
        } else {
            modal.hidden = true;
            document.body.classList.remove("modal-open");
        }
        modal.onclick = function (event) {
            if (event.target === modal || event.target.closest("[data-course-settings-close]")) close();
        };
    }

    initializeModal();
    if (window.Sys && window.Sys.WebForms && window.Sys.WebForms.PageRequestManager) {
        window.Sys.WebForms.PageRequestManager.getInstance().add_endRequest(initializeModal);
    }
})(window, document);
