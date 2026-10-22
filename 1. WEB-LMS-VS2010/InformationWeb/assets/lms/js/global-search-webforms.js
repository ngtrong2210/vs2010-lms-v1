(function () {
    "use strict";
    var tabs = document.querySelectorAll("[data-search-type]");
    var cards = document.querySelectorAll("[data-result-type]");
    var empty = document.querySelector('[data-filter-empty="true"]');
    if (!tabs.length) return;
    function selectType(type, selected) {
        var shown = 0;
        for (var i = 0; i < cards.length; i += 1) {
            var visible = !type || cards[i].getAttribute("data-result-type") === type;
            cards[i].hidden = !visible;
            if (visible) shown += 1;
        }
        for (var j = 0; j < tabs.length; j += 1) {
            var active = tabs[j] === selected;
            tabs[j].className = active ? "type-tab active" : "type-tab";
            tabs[j].setAttribute("aria-pressed", active ? "true" : "false");
        }
        if (empty) empty.hidden = shown !== 0 || cards.length === 0;
    }
    for (var i = 0; i < tabs.length; i += 1) {
        tabs[i].onclick = function () {
            selectType(this.getAttribute("data-search-type") || "", this);
        };
    }
})();
