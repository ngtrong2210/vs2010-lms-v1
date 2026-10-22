(function () {
    "use strict";

    function getModal() {
        return document.querySelector('[data-grading-modal="true"]');
    }
    function closeModal() {
        var modal = getModal();
        if (!modal) return;
        modal.style.display = "none";
        document.body.classList.remove("grading-modal-open");
    }

    function initializeModal() {
        var modal = getModal();
        if (!modal) {
            document.body.classList.remove("grading-modal-open");
            return;
        }
        document.body.classList.add("grading-modal-open");
        var buttons = modal.querySelectorAll('[data-grading-close="true"]');
        for (var i = 0; i < buttons.length; i += 1) buttons[i].onclick = closeModal;
        modal.onclick = function (event) {
            if (event.target === modal) closeModal();
        };
        var score = modal.querySelector('input[type="text"]:not(.d-none)');
        if (score) score.focus();
    }

    document.onkeydown = function (event) {
        if ((event || window.event).keyCode === 27) closeModal();
    };
    initializeModal();
    if (window.Sys && window.Sys.WebForms && window.Sys.WebForms.PageRequestManager) {
        window.Sys.WebForms.PageRequestManager.getInstance().add_endRequest(initializeModal);
    }
})();
