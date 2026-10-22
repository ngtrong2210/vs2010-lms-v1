(function (window, document) {
    "use strict";
    var root = document.getElementById("questionBankPage");
    if (!root) return;

    function byId(id) {
        return document.getElementById(id);
    }
    function server(id) {
        return byId(id) || document.querySelector('[id$="_' + id + '"]');
    }
    function currentEditor() {
        return byId("questionEditor");
    }
    function value(id) {
        var element = server(id);
        return element ? element.value : "";
    }
    function setValue(id, next) {
        var element = server(id);
        if (element) element.value = next == null ? "" : String(next);
    }
    function escapeHtml(input) {
        return String(input == null ? "" : input).replace(/[&<>"']/g, function (char) {
            return { "&": "&amp;", "<": "&lt;", ">": "&gt;", '"': "&quot;", "'": "&#39;" }[char];
        });
    }
    function lines(input) {
        return String(input || "")
            .split(/\r?\n/)
            .map(function (item) {
                return item.trim();
            })
            .filter(Boolean);
    }
    function codeFor(index) {
        return String.fromCharCode(65 + index);
    }
    function show() {
        var editor = currentEditor();
        if (!editor) return;
        editor.hidden = false;
        document.body.classList.add("modal-open");
    }
    function close() {
        var editor = currentEditor();
        if (!editor) return;
        editor.hidden = true;
        document.body.classList.remove("modal-open");
        setValue("QuestionEditorOpenValue", "");
    }

    var state = { options: [], blanks: [] };
    function parseState() {
        state.options = lines(value("QuestionOptionsText")).map(function (line, index) {
            var parts = line.split("|");
            return {
                code: (parts[0] || codeFor(index)).trim(),
                text: (parts[1] || "").trim(),
                correct: /^(1|true)$/i.test((parts[2] || "").trim()),
            };
        });
        state.blanks = lines(value("QuestionBlanksText")).map(function (line, index) {
            var parts = line.split("|");
            return { code: (parts[0] || "BLANK_" + (index + 1)).trim(), answer: (parts[1] || "").trim() };
        });
        if (value("QuestionTypeList") !== "SHORT_ANSWER" && state.options.length < 2)
            state.options = [
                { code: "A", text: "", correct: true },
                { code: "B", text: "", correct: false },
            ];
        setValue("questionShortAnswerInput", lines(value("QuestionAnswerKeysText"))[0] || "");
    }

    function resetCreate() {
        setValue("QuestionIdValue", "");
        setValue("QuestionEditorOpenValue", "1");
        setValue("QuestionTypeList", "SINGLE_CHOICE");
        setValue("QuestionTextInput", "");
        setValue("QuestionDescriptionInput", "");
        setValue("QuestionDifficultyList", "EASY");
        setValue("QuestionScoreText", "10");
        setValue("QuestionStatusList", "ACTIVE");
        setValue("ShortAnswerModeList", "EXACT_MATCH");
        setValue("QuestionOptionsText", "A||1\nB||0");
        setValue("QuestionAnswerKeysText", "");
        setValue("QuestionBlanksText", "");
        parseState();
        syncType();
        byId("questionEditorKicker").textContent = "TẠO CÂU HỎI";
        show();
    }

    function normalizeType() {
        var type = value("QuestionTypeList");
        if (type === "TRUE_FALSE")
            state.options = [
                { code: "A", text: "Đúng", correct: true },
                { code: "B", text: "Sai", correct: false },
            ];
        else if (type === "SHORT_ANSWER")
            setValue("ShortAnswerModeList", value("ShortAnswerModeList") || "EXACT_MATCH");
        else {
            if (state.options.length < 2)
                state.options = [
                    { code: "A", text: "", correct: true },
                    { code: "B", text: "", correct: false },
                ];
            if (type === "CLOZE_DRAG_DROP")
                state.options.forEach(function (item) {
                    item.correct = false;
                });
            if (
                type === "SINGLE_CHOICE" &&
                !state.options.some(function (item) {
                    return item.correct;
                })
            )
                state.options[0].correct = true;
        }
        syncType();
    }

    function syncType() {
        var type = value("QuestionTypeList");
        var isShort = type === "SHORT_ANSWER",
            isCloze = type === "CLOZE_DRAG_DROP";
        byId("questionOptionPanel").hidden = isShort;
        byId("questionShortAnswerPanel").hidden = !isShort;
        byId("questionClozeBlankEditor").hidden = !isCloze;
        byId("questionClozeHint").hidden = !isCloze;
        byId("questionTextLabel").textContent = isCloze ? "Đoạn văn có ô trống" : "Nội dung câu hỏi";
        byId("questionShortAnswerField").hidden = value("ShortAnswerModeList") === "MANUAL_REVIEW";
        renderOptions();
        renderBlanks();
    }

    function renderOptions() {
        var type = value("QuestionTypeList"),
            multiple = type === "MULTIPLE_CHOICE",
            cloze = type === "CLOZE_DRAG_DROP";
        byId("questionOptionRows").innerHTML = state.options
            .map(function (item, index) {
                var selector = cloze
                    ? '<span class="cloze-option-marker"><i class="bi bi-grip-vertical"></i></span>'
                    : '<input class="form-check-input" data-option-correct="' +
                      index +
                      '" type="' +
                      (multiple ? "checkbox" : "radio") +
                      '" ' +
                      (item.correct ? 'checked="checked"' : "") +
                      ' name="question-correct-option" />';
                return (
                    '<div class="option-row">' +
                    selector +
                    '<input class="form-control option-code" data-option-code="' +
                    index +
                    '" value="' +
                    escapeHtml(item.code) +
                    '" /><input class="form-control" data-option-text="' +
                    index +
                    '" value="' +
                    escapeHtml(item.text) +
                    '" placeholder="Nội dung phương án" /><button type="button" class="btn btn-action-delete btn-sm" data-option-remove="' +
                    index +
                    '" ' +
                    (state.options.length <= 2 ? 'disabled="disabled"' : "") +
                    '><i class="bi bi-trash"></i></button></div>'
                );
            })
            .join("");
    }

    function renderBlanks() {
        if (value("QuestionTypeList") !== "CLOZE_DRAG_DROP") return;
        byId("questionBlankRows").innerHTML = state.blanks.length
            ? state.blanks
                  .map(function (item, index) {
                      return (
                          '<div class="cloze-blank-row"><span>' +
                          (index + 1) +
                          '</span><input class="form-control" readonly="readonly" value="' +
                          escapeHtml(item.code) +
                          '" /><select class="form-select" data-blank-answer="' +
                          index +
                          '"><option value="">Chọn đáp án đúng</option>' +
                          state.options
                              .map(function (option) {
                                  return (
                                      '<option value="' +
                                      escapeHtml(option.code) +
                                      '" ' +
                                      (option.code === item.answer ? 'selected="selected"' : "") +
                                      ">" +
                                      escapeHtml(option.code + " — " + (option.text || "Chưa nhập nội dung")) +
                                      "</option>"
                                  );
                              })
                              .join("") +
                          '</select><button type="button" class="btn btn-action-delete btn-action-outline btn-sm" data-blank-remove="' +
                          index +
                          '"><i class="bi bi-trash"></i></button></div>'
                      );
                  })
                  .join("")
            : '<p class="text-secondary mb-0">Chưa có ô trống nào.</p>';
    }

    function addOption() {
        state.options.push({ code: codeFor(state.options.length), text: "", correct: false });
        renderOptions();
        renderBlanks();
    }
    function removeOption(index) {
        if (state.options.length <= 2) return;
        var removed = state.options.splice(index, 1)[0];
        state.blanks.forEach(function (blank) {
            if (blank.answer === removed.code) blank.answer = "";
        });
        renderOptions();
        renderBlanks();
    }
    function addBlank() {
        var number = state.blanks.length + 1,
            used = state.blanks.map(function (item) {
                return item.code;
            });
        while (used.indexOf("BLANK_" + number) >= 0) number += 1;
        var code = "BLANK_" + number;
        state.blanks.push({ code: code, answer: "" });
        var textArea = server("QuestionTextInput");
        if (textArea) textArea.value += (textArea.value ? " " : "") + "[[" + code + "]]";
        renderBlanks();
    }
    function removeBlank(index) {
        var blank = state.blanks.splice(index, 1)[0],
            textArea = server("QuestionTextInput");
        if (blank && textArea) textArea.value = textArea.value.split("[[" + blank.code + "]]").join("_____");
        renderBlanks();
    }

    function prepareSubmit() {
        var type = value("QuestionTypeList"),
            isShort = type === "SHORT_ANSWER",
            isCloze = type === "CLOZE_DRAG_DROP";
        if (!value("QuestionTextInput").trim()) {
            window.alert("Nội dung câu hỏi không được để trống.");
            return false;
        }
        if (!isShort && state.options.length < 2) {
            window.alert("Câu hỏi cần ít nhất hai phương án.");
            return false;
        }
        if (isCloze && !state.blanks.length) {
            window.alert("Câu kéo thả cần ít nhất một ô trống.");
            return false;
        }
        if (
            isCloze &&
            state.blanks.some(function (item) {
                return !item.answer;
            })
        ) {
            window.alert("Vui lòng gán đáp án đúng cho từng ô trống.");
            return false;
        }
        if (isShort && value("ShortAnswerModeList") !== "MANUAL_REVIEW" && !value("questionShortAnswerInput").trim()) {
            window.alert("Vui lòng nhập đáp án mẫu.");
            return false;
        }
        if (!isShort)
            state.options.forEach(function (item) {
                if (isCloze)
                    item.correct = state.blanks.some(function (blank) {
                        return blank.answer === item.code;
                    });
            });
        setValue(
            "QuestionOptionsText",
            isShort
                ? ""
                : state.options
                      .map(function (item) {
                          return item.code.trim() + "|" + item.text.trim() + "|" + (item.correct ? "1" : "0");
                      })
                      .join("\n"),
        );
        setValue(
            "QuestionAnswerKeysText",
            isShort && value("ShortAnswerModeList") !== "MANUAL_REVIEW" ? value("questionShortAnswerInput").trim() : "",
        );
        setValue(
            "QuestionBlanksText",
            isCloze
                ? state.blanks
                      .map(function (item) {
                          return item.code + "|" + item.answer;
                      })
                      .join("\n")
                : "",
        );
        setValue("QuestionEditorOpenValue", "1");
        return true;
    }

    root.addEventListener("click", function (event) {
        if (event.target === currentEditor()) {
            close();
            return;
        }
        if (event.target.closest("[data-question-create]")) {
            resetCreate();
            return;
        }
        if (event.target.closest("[data-question-close]")) {
            close();
            return;
        }
        if (event.target.closest("[data-question-add-option]")) {
            addOption();
            return;
        }
        if (event.target.closest("[data-question-add-blank]")) {
            addBlank();
            return;
        }
        var removeOptionButton = event.target.closest("[data-option-remove]");
        if (removeOptionButton) {
            removeOption(Number(removeOptionButton.getAttribute("data-option-remove")));
            return;
        }
        var removeBlankButton = event.target.closest("[data-blank-remove]");
        if (removeBlankButton) removeBlank(Number(removeBlankButton.getAttribute("data-blank-remove")));
    });
    root.addEventListener("input", function (event) {
        var index;
        if (event.target.hasAttribute("data-option-code")) {
            index = Number(event.target.getAttribute("data-option-code"));
            state.options[index].code = event.target.value;
            renderBlanks();
        } else if (event.target.hasAttribute("data-option-text")) {
            index = Number(event.target.getAttribute("data-option-text"));
            state.options[index].text = event.target.value;
            renderBlanks();
        }
    });
    root.addEventListener("change", function (event) {
        var index;
        if (event.target.id === "QuestionTypeList") normalizeType();
        else if (event.target.id === "ShortAnswerModeList") syncType();
        else if (event.target.hasAttribute("data-option-correct")) {
            index = Number(event.target.getAttribute("data-option-correct"));
            if (value("QuestionTypeList") === "MULTIPLE_CHOICE") state.options[index].correct = event.target.checked;
            else
                state.options.forEach(function (item, itemIndex) {
                    item.correct = itemIndex === index;
                });
            renderOptions();
        } else if (event.target.hasAttribute("data-blank-answer")) {
            index = Number(event.target.getAttribute("data-blank-answer"));
            state.blanks[index].answer = event.target.value;
        }
    });
    function initializeEditor() {
        if (!currentEditor()) return;
        parseState();
        syncType();
        if (value("QuestionEditorOpenValue") === "1") {
            byId("questionEditorKicker").textContent = value("QuestionIdValue") ? "CHỈNH SỬA CÂU HỎI" : "TẠO CÂU HỎI";
            show();
        } else {
            document.body.classList.remove("modal-open");
        }
    }

    initializeEditor();
    if (window.Sys && window.Sys.WebForms && window.Sys.WebForms.PageRequestManager) {
        window.Sys.WebForms.PageRequestManager.getInstance().add_endRequest(initializeEditor);
    }
    window.QuestionBankPage = { prepareSubmit: prepareSubmit };
})(window, document);
