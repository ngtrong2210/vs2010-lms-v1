(function (window, document) {
    "use strict";

    var storageKey = "lms-content-builder-collapsed:" + window.location.pathname;
    var questionBank = [];
    var quizSelected = [];
    var interactiveMappings = [];

    function byId(id) {
        return document.getElementById(id) || document.querySelector('[id$="_' + id + '"]');
    }
    function all(selector) {
        return Array.prototype.slice.call(document.querySelectorAll(selector));
    }
    function setValue(id, value) {
        var node = byId(id);
        if (node) node.value = value == null ? "" : value;
    }
    function setChecked(id, value) {
        var wrapper = byId(id);
        var input = wrapper && wrapper.tagName === "INPUT" ? wrapper : wrapper ? wrapper.querySelector("input") : null;
        if (input) input.checked = !!value;
    }
    function parseField(id, fallback) {
        try {
            return JSON.parse((byId(id) && byId(id).value) || "") || fallback;
        } catch (error) {
            return fallback;
        }
    }
    function create(tag, className, text) {
        var node = document.createElement(tag);
        if (className) node.className = className;
        if (text != null) node.textContent = text;
        return node;
    }
    function actionButton(className, icon, title, handler) {
        var button = create("button", className);
        button.type = "button";
        button.title = title;
        var iconNode = create("i", "bi " + icon);
        button.appendChild(iconNode);
        button.addEventListener("click", handler);
        return button;
    }
    function questionTypeLabel(type) {
        return (
            {
                SINGLE_CHOICE: "Một lựa chọn",
                MULTIPLE_CHOICE: "Nhiều lựa chọn",
                TRUE_FALSE: "Đúng / Sai",
                SHORT_ANSWER: "Trả lời ngắn",
                CLOZE_DRAG_DROP: "Kéo thả vào đoạn văn",
            }[type] ||
            type ||
            "Câu hỏi"
        );
    }
    function normalizeQuestion(question) {
        return {
            id: Number(question.id || question.Id || question.questionId || question.QuestionID || 0),
            text:
                question.text ||
                question.QuestionText ||
                question.questionText ||
                question.Description ||
                question.description ||
                "",
            type: question.type || question.QuestionType || question.questionType || "",
            score: Number(question.score || question.Score || question.DefaultScore || question.defaultScore || 0),
        };
    }
    function loadAuthoringState() {
        questionBank = parseField("QuestionBankJsonValue", [])
            .map(normalizeQuestion)
            .filter(function (item) {
                return item.id > 0;
            });
        quizSelected = parseField("QuizSelectedJsonValue", [])
            .map(normalizeQuestion)
            .filter(function (item) {
                return item.id > 0;
            });
        interactiveMappings = parseField("InteractiveMappingsJsonValue", [])
            .map(function (mapping, index) {
                var question = normalizeQuestion(mapping);
                return {
                    id: Number(mapping.id || mapping.ContentInteractionID || 0),
                    questionId: Number(mapping.questionId || mapping.QuestionID || question.id || 0),
                    questionText: mapping.questionText || mapping.QuestionText || question.text,
                    questionType: mapping.questionType || mapping.QuestionType || question.type,
                    required: mapping.required !== false && mapping.Required !== false,
                    allowRetry: mapping.allowRetry !== false && mapping.AllowRetry !== false,
                    score: Number(mapping.score || mapping.Score || question.score || 0),
                    attemptLimit: Math.max(1, Number(mapping.attemptLimit || mapping.AttemptLimit || 2)),
                    sortOrder: index + 1,
                    status: "ACTIVE",
                };
            })
            .filter(function (item) {
                return item.questionId > 0;
            });
    }
    function syncAuthoringHidden() {
        setValue("QuizSelectedJsonValue", JSON.stringify(quizSelected));
        setValue("InteractiveMappingsJsonValue", JSON.stringify(interactiveMappings));
    }
    function findQuestion(id) {
        for (var i = 0; i < questionBank.length; i += 1) if (questionBank[i].id === Number(id)) return questionBank[i];
        return null;
    }
    function matchesQuestion(question, search, type) {
        return (
            (!type || question.type === type) &&
            (!search || (question.text || "").toLocaleLowerCase().indexOf(search) >= 0)
        );
    }

    function renderQuizAuthoring() {
        var picker = byId("quizQuestionPicker"),
            selectedList = byId("quizSelectedList");
        if (!picker || !selectedList) return;
        var search = ((byId("quizQuestionSearch") && byId("quizQuestionSearch").value) || "")
            .trim()
            .toLocaleLowerCase();
        var type = (byId("quizQuestionType") && byId("quizQuestionType").value) || "";
        var selectedIds = quizSelected.map(function (item) {
            return item.id;
        });
        var filtered = questionBank.filter(function (question) {
            return matchesQuestion(question, search, type);
        });
        picker.innerHTML = "";
        filtered.forEach(function (question) {
            var selected = selectedIds.indexOf(question.id) >= 0;
            var label = create("label", "quiz-question-option" + (selected ? " is-selected" : ""));
            var checkbox = create("input", "form-check-input");
            checkbox.type = "checkbox";
            checkbox.checked = selected;
            var copy = create("span");
            copy.appendChild(create("strong", "", question.text));
            copy.appendChild(create("small", "", questionTypeLabel(question.type) + " · " + question.score + " điểm"));
            checkbox.addEventListener("change", function () {
                if (
                    checkbox.checked &&
                    quizSelected
                        .map(function (item) {
                            return item.id;
                        })
                        .indexOf(question.id) < 0
                )
                    quizSelected.push(question);
                if (!checkbox.checked)
                    quizSelected = quizSelected.filter(function (item) {
                        return item.id !== question.id;
                    });
                syncAuthoringHidden();
                renderQuizAuthoring();
            });
            label.appendChild(checkbox);
            label.appendChild(copy);
            picker.appendChild(label);
        });
        if (!filtered.length)
            picker.appendChild(create("p", "quiz-bank-state mb-0", "Không tìm thấy câu hỏi phù hợp với bộ lọc."));

        selectedList.innerHTML = "";
        if (!quizSelected.length) {
            var empty = create("div", "quiz-selected-empty");
            empty.appendChild(create("i", "bi bi-ui-checks-grid"));
            empty.appendChild(create("strong", "", "Chưa chọn câu hỏi"));
            empty.appendChild(create("span", "", "Tìm câu hỏi ở cột bên trái và tích chọn để thêm vào bài kiểm tra."));
            selectedList.appendChild(empty);
        }
        quizSelected.forEach(function (question, index) {
            var article = create("article", "quiz-selected-item");
            article.appendChild(create("span", "quiz-selected-order", String(index + 1)));
            var copy = create("div", "quiz-selected-copy");
            copy.appendChild(create("strong", "", question.text));
            copy.appendChild(create("small", "", questionTypeLabel(question.type) + " · " + question.score + " điểm"));
            article.appendChild(copy);
            var actions = create("div", "quiz-order-actions");
            var up = actionButton("btn btn-action-view btn-sm", "bi-arrow-up", "Đưa câu hỏi lên", function () {
                moveQuiz(index, -1);
            });
            up.disabled = index === 0;
            var down = actionButton("btn btn-action-view btn-sm", "bi-arrow-down", "Đưa câu hỏi xuống", function () {
                moveQuiz(index, 1);
            });
            down.disabled = index === quizSelected.length - 1;
            actions.appendChild(up);
            actions.appendChild(down);
            article.appendChild(actions);
            article.appendChild(
                actionButton(
                    "btn btn-action-delete btn-action-outline btn-sm",
                    "bi-trash",
                    "Bỏ câu hỏi khỏi bài kiểm tra",
                    function () {
                        quizSelected.splice(index, 1);
                        syncAuthoringHidden();
                        renderQuizAuthoring();
                    },
                ),
            );
            selectedList.appendChild(article);
        });
        var selectedText = quizSelected.length + " đã chọn";
        if (byId("quizBankSelected")) byId("quizBankSelected").textContent = selectedText;
        if (byId("quizSelectedCount")) byId("quizSelectedCount").textContent = selectedText;
        if (byId("quizQuestionTotal")) byId("quizQuestionTotal").textContent = questionBank.length + " câu";
    }
    function moveQuiz(index, direction) {
        var target = index + direction;
        if (target < 0 || target >= quizSelected.length) return;
        var item = quizSelected.splice(index, 1)[0];
        quizSelected.splice(target, 0, item);
        syncAuthoringHidden();
        renderQuizAuthoring();
    }

    function renderInteractiveAuthoring() {
        var picker = byId("interactiveQuestionPicker"),
            selectedList = byId("interactiveSelectedList");
        if (!picker || !selectedList) return;
        var search = ((byId("interactiveQuestionSearch") && byId("interactiveQuestionSearch").value) || "")
            .trim()
            .toLocaleLowerCase();
        var type = (byId("interactiveQuestionType") && byId("interactiveQuestionType").value) || "";
        var selectedIds = interactiveMappings.map(function (item) {
            return item.questionId;
        });
        var filtered = questionBank.filter(function (question) {
            return matchesQuestion(question, search, type);
        });
        picker.innerHTML = "";
        filtered.forEach(function (question) {
            var label = create("label", "interactive-bank-row");
            var checkbox = create("input", "form-check-input");
            checkbox.type = "checkbox";
            checkbox.checked = selectedIds.indexOf(question.id) >= 0;
            var copy = create("span", "interactive-bank-copy");
            copy.appendChild(create("strong", "", question.text));
            copy.appendChild(
                create("small", "", questionTypeLabel(question.type) + " · Mặc định " + question.score + " điểm"),
            );
            checkbox.addEventListener("change", function () {
                if (
                    checkbox.checked &&
                    interactiveMappings
                        .map(function (item) {
                            return item.questionId;
                        })
                        .indexOf(question.id) < 0
                )
                    interactiveMappings.push({
                        id: 0,
                        questionId: question.id,
                        questionText: question.text,
                        questionType: question.type,
                        required: true,
                        allowRetry: true,
                        score: question.score,
                        attemptLimit: 2,
                        sortOrder: interactiveMappings.length + 1,
                        status: "ACTIVE",
                    });
                if (!checkbox.checked)
                    interactiveMappings = interactiveMappings.filter(function (item) {
                        return item.questionId !== question.id;
                    });
                syncAuthoringHidden();
                renderInteractiveAuthoring();
            });
            label.appendChild(checkbox);
            label.appendChild(copy);
            picker.appendChild(label);
        });
        if (!filtered.length)
            picker.appendChild(create("p", "interactive-bank-state", "Không tìm thấy câu hỏi phù hợp."));

        selectedList.innerHTML = "";
        if (!interactiveMappings.length) {
            var empty = create("div", "interactive-selected-empty");
            empty.appendChild(create("i", "bi bi-ui-checks-grid"));
            empty.appendChild(create("strong", "", "Chưa chọn câu hỏi"));
            empty.appendChild(create("span", "", "Tìm câu hỏi ở cột bên trái và tích chọn để thêm vào bài học."));
            selectedList.appendChild(empty);
        }
        interactiveMappings.forEach(function (mapping, index) {
            var article = create("article");
            article.appendChild(create("span", "interactive-order", String(index + 1)));
            var copy = create("div", "interactive-selected-copy");
            copy.appendChild(create("strong", "", mapping.questionText));
            copy.appendChild(create("small", "", questionTypeLabel(mapping.questionType)));
            article.appendChild(copy);
            var scoreLabel = create("label", "", "Điểm "),
                score = create("input");
            score.type = "number";
            score.min = "0";
            score.max = "10000";
            score.value = mapping.score;
            score.addEventListener("change", function () {
                mapping.score = Number(score.value) || 0;
                syncAuthoringHidden();
            });
            scoreLabel.appendChild(score);
            article.appendChild(scoreLabel);
            var attemptLabel = create("label", "", "Lượt "),
                attempt = create("input");
            attempt.type = "number";
            attempt.min = "1";
            attempt.max = "100";
            attempt.value = mapping.attemptLimit;
            attempt.disabled = !mapping.allowRetry;
            attempt.addEventListener("change", function () {
                mapping.attemptLimit = Math.max(1, Number(attempt.value) || 1);
                syncAuthoringHidden();
            });
            attemptLabel.appendChild(attempt);
            article.appendChild(attemptLabel);
            var requiredLabel = create("label", "compact-check"),
                required = create("input");
            required.type = "checkbox";
            required.checked = mapping.required;
            required.addEventListener("change", function () {
                mapping.required = required.checked;
                syncAuthoringHidden();
            });
            requiredLabel.appendChild(required);
            requiredLabel.appendChild(document.createTextNode(" Bắt buộc"));
            article.appendChild(requiredLabel);
            var retryLabel = create("label", "compact-check"),
                retry = create("input");
            retry.type = "checkbox";
            retry.checked = mapping.allowRetry;
            retry.addEventListener("change", function () {
                mapping.allowRetry = retry.checked;
                attempt.disabled = !mapping.allowRetry;
                if (!mapping.allowRetry) mapping.attemptLimit = 1;
                syncAuthoringHidden();
            });
            retryLabel.appendChild(retry);
            retryLabel.appendChild(document.createTextNode(" Thử lại"));
            article.appendChild(retryLabel);
            var actions = create("div", "interactive-order-actions");
            var up = actionButton("btn btn-action-view btn-sm", "bi-arrow-up", "Đưa câu hỏi lên", function () {
                moveInteractive(index, -1);
            });
            up.disabled = index === 0;
            var down = actionButton("btn btn-action-view btn-sm", "bi-arrow-down", "Đưa câu hỏi xuống", function () {
                moveInteractive(index, 1);
            });
            down.disabled = index === interactiveMappings.length - 1;
            actions.appendChild(up);
            actions.appendChild(down);
            article.appendChild(actions);
            article.appendChild(
                actionButton("btn btn-action-delete btn-sm", "bi-trash", "Bỏ khỏi bài", function () {
                    interactiveMappings.splice(index, 1);
                    syncAuthoringHidden();
                    renderInteractiveAuthoring();
                }),
            );
            selectedList.appendChild(article);
        });
        if (byId("interactiveQuestionTotal"))
            byId("interactiveQuestionTotal").textContent = questionBank.length + " câu";
        if (byId("interactiveSelectedCount"))
            byId("interactiveSelectedCount").textContent = interactiveMappings.length + " đã chọn";
    }
    function moveInteractive(index, direction) {
        var target = index + direction;
        if (target < 0 || target >= interactiveMappings.length) return;
        var item = interactiveMappings.splice(index, 1)[0];
        interactiveMappings.splice(target, 0, item);
        interactiveMappings.forEach(function (mapping, mappingIndex) {
            mapping.sortOrder = mappingIndex + 1;
        });
        syncAuthoringHidden();
        renderInteractiveAuthoring();
    }

    function openInteractivePreview() {
        var old = byId("interactivePreviewRuntime");
        if (old && old.parentNode) old.parentNode.removeChild(old);
        var overlay = create("div", "modal-mask");
        overlay.id = "interactivePreviewRuntime";
        var modal = create("section", "app-card interactive-preview-modal");
        var heading = create("div", "modal-heading"),
            headingCopy = create("div");
        headingCopy.appendChild(create("small", "", "Xem như học viên"));
        headingCopy.appendChild(
            create("h2", "", (byId("LessonTitleText") && byId("LessonTitleText").value) || "Bài học tương tác"),
        );
        var close = create("button", "btn-close");
        close.type = "button";
        close.addEventListener("click", function () {
            overlay.parentNode.removeChild(overlay);
        });
        heading.appendChild(headingCopy);
        heading.appendChild(close);
        modal.appendChild(heading);
        var layout = create("div", "interactive-preview-layout"),
            content = create("article", "interactive-preview-content");
        content.innerHTML =
            (byId("LessonContentText") && byId("LessonContentText").value) || "<p>Chưa có nội dung soạn thảo.</p>";
        var questions = create("aside");
        questions.appendChild(create("h3", "", "Câu hỏi trong bài"));
        interactiveMappings.forEach(function (mapping, index) {
            var card = create("button");
            card.type = "button";
            card.appendChild(create("strong", "", String(index + 1)));
            card.appendChild(create("span", "", mapping.questionText));
            questions.appendChild(card);
        });
        if (!interactiveMappings.length) questions.appendChild(create("span", "", "Chưa chọn câu hỏi."));
        layout.appendChild(content);
        layout.appendChild(questions);
        modal.appendChild(layout);
        overlay.appendChild(modal);
        document.body.appendChild(overlay);
    }

    function openModal(id) {
        var node = byId(id);
        if (node) node.removeAttribute("hidden");
    }
    function closeModal(id) {
        var node = byId(id);
        if (node) node.setAttribute("hidden", "hidden");
        setValue(id === "chapterModal" ? "ChapterModalOpenValue" : "LessonModalOpenValue", "");
    }
    function resetChapter() {
        setValue("ChapterIdValue", "");
        setValue("ChapterTitleText", "");
        setValue("ChapterDescriptionText", "");
        setValue("ChapterSortOrderText", String(all("[data-chapter-card]").length + 1));
        setValue("ChapterStatusList", "ACTIVE");
        var title = byId("chapterModalTitle");
        if (title) title.textContent = "Thêm chương";
    }
    function resetLesson(chapterId, sortOrder) {
        setValue("LessonIdValue", "");
        setValue("LessonChapterIdText", chapterId);
        setValue("LessonTitleText", "");
        setValue("LessonDescriptionText", "");
        setValue("LessonTypeList", "INTERACTIVE_VIDEO");
        setValue("LessonStatusList", "ACTIVE");
        setValue("LessonDurationText", "0");
        setValue("LessonSortOrderText", sortOrder || "1");
        setValue("LessonPassingScoreText", "50");
        setValue("LessonContentText", "");
        setValue("LessonDocumentUrlText", "");
        setValue("LessonAssignmentFolderText", "");
        setValue("LessonAssignmentStartText", "");
        setValue("LessonDueAtText", "");
        setValue("LessonMaxScoreText", "100");
        setValue("LessonMaxAttemptsText", "3");
        setValue("LessonMaxFileSizeText", "50");
        setValue("QuizPassingScoreText", "50");
        setValue("QuizTimeLimitText", "30");
        setValue("QuizMaxAttemptsText", "1");
        setChecked("QuizShuffleCheck", false);
        setValue("InteractiveCompletionList", "REQUIRED_QUESTIONS");
        setValue("InteractivePassingScoreText", "70");
        setChecked("InteractiveRequireReadingCheck", true);
        setChecked("InteractiveShowResultCheck", true);
        setChecked("InteractiveShowScoreCheck", true);
        setChecked("LessonRequiredCheck", true);
        setChecked("LessonAllowLateCheck", false);
        quizSelected = [];
        interactiveMappings = [];
        setValue("InteractiveOriginalIdsValue", "[]");
        syncAuthoringHidden();
        var title = byId("lessonModalTitle");
        if (title) title.textContent = "Thêm bài học";
        syncLessonSections();
    }
    function syncLessonSections() {
        var list = byId("LessonTypeList"),
            type = list ? list.value : "";
        all("[data-lesson-types]").forEach(function (node) {
            node.style.display =
                (node.getAttribute("data-lesson-types") || "").split(",").indexOf(type) >= 0 ? "" : "none";
        });
        var modal = document.querySelector("#lessonModal .lesson-form-modal");
        if (modal) modal.classList.toggle("fullscreen-form-modal", type === "QUIZ" || type === "INTERACTIVE_CONTENT");
        if (type === "QUIZ") renderQuizAuthoring();
        if (type === "INTERACTIVE_CONTENT") renderInteractiveAuthoring();
    }
    function readCollapsed() {
        try {
            return JSON.parse(window.sessionStorage.getItem(storageKey) || "[]");
        } catch (error) {
            return [];
        }
    }
    function saveCollapsed() {
        try {
            window.sessionStorage.setItem(
                storageKey,
                JSON.stringify(
                    all("[data-chapter-card].is-collapsed").map(function (node) {
                        return node.getAttribute("data-chapter-card");
                    }),
                ),
            );
        } catch (error) {}
    }
    function setCollapsed(card, collapsed) {
        if (!card) return;
        card.classList.toggle("is-collapsed", collapsed);
        var toggle = card.querySelector("[data-toggle-chapter]");
        if (toggle) toggle.setAttribute("aria-expanded", collapsed ? "false" : "true");
    }
    function applyCollapsed() {
        var collapsed = readCollapsed();
        all("[data-chapter-card]").forEach(function (card) {
            setCollapsed(card, collapsed.indexOf(card.getAttribute("data-chapter-card")) >= 0);
        });
    }
    function wrapSelection(prefix, suffix) {
        var area = byId("LessonContentText");
        if (!area) return;
        var start = area.selectionStart || 0,
            end = area.selectionEnd || 0,
            value = area.value || "";
        area.value = value.substring(0, start) + prefix + value.substring(start, end) + suffix + value.substring(end);
        area.focus();
        area.selectionStart = start + prefix.length;
        area.selectionEnd = end + prefix.length;
    }

    document.addEventListener("click", function (event) {
        var target = event.target.closest
            ? event.target.closest(
                  "[data-open-chapter],[data-open-lesson],[data-close-modal],[data-toggle-chapter],[data-expand-all],[data-collapse-all],[data-editor-command],[data-open-interactive-preview]",
              )
            : null;
        if (!target) return;
        if (target.hasAttribute("data-open-chapter")) {
            resetChapter();
            setValue("ChapterModalOpenValue", "1");
            openModal("chapterModal");
        } else if (target.hasAttribute("data-open-lesson")) {
            resetLesson(target.getAttribute("data-open-lesson"), target.getAttribute("data-next-order"));
            setValue("LessonModalOpenValue", "1");
            openModal("lessonModal");
        } else if (target.hasAttribute("data-close-modal")) closeModal(target.getAttribute("data-close-modal"));
        else if (target.hasAttribute("data-toggle-chapter")) {
            var card = target.closest("[data-chapter-card]");
            setCollapsed(card, !card.classList.contains("is-collapsed"));
            saveCollapsed();
        } else if (target.hasAttribute("data-expand-all")) {
            all("[data-chapter-card]").forEach(function (card) {
                setCollapsed(card, false);
            });
            saveCollapsed();
        } else if (target.hasAttribute("data-collapse-all")) {
            all("[data-chapter-card]").forEach(function (card) {
                setCollapsed(card, true);
            });
            saveCollapsed();
        } else if (target.hasAttribute("data-open-interactive-preview")) openInteractivePreview();
        else {
            var command = target.getAttribute("data-editor-command");
            if (command === "bold") wrapSelection("<strong>", "</strong>");
            else if (command === "italic") wrapSelection("<em>", "</em>");
            else if (command === "list") wrapSelection("<ul><li>", "</li></ul>");
            else wrapSelection("<h3>", "</h3>");
        }
    });
    document.addEventListener("keydown", function (event) {
        if (event.key !== "Escape") return;
        var preview = byId("interactivePreviewRuntime"),
            lesson = byId("lessonModal"),
            chapter = byId("chapterModal");
        if (preview && preview.parentNode) preview.parentNode.removeChild(preview);
        else if (lesson && !lesson.hasAttribute("hidden")) closeModal("lessonModal");
        else if (chapter && !chapter.hasAttribute("hidden")) closeModal("chapterModal");
    });

    function bindFilter(id, eventName, renderer) {
        var node = byId(id);
        if (!node || node.getAttribute("data-content-builder-bound-" + eventName) === "1") return;
        node.addEventListener(eventName, renderer);
        node.setAttribute("data-content-builder-bound-" + eventName, "1");
    }
    function initializeDynamicState() {
        var lessonType = byId("LessonTypeList");
        if (lessonType && lessonType.getAttribute("data-content-builder-bound-change") !== "1") {
            lessonType.addEventListener("change", syncLessonSections);
            lessonType.setAttribute("data-content-builder-bound-change", "1");
        }
        bindFilter("quizQuestionSearch", "input", renderQuizAuthoring);
        bindFilter("quizQuestionType", "change", renderQuizAuthoring);
        bindFilter("interactiveQuestionSearch", "input", renderInteractiveAuthoring);
        bindFilter("interactiveQuestionType", "change", renderInteractiveAuthoring);
        loadAuthoringState();
        applyCollapsed();
        syncLessonSections();
    }

    initializeDynamicState();
    if (window.Sys && window.Sys.WebForms && window.Sys.WebForms.PageRequestManager) {
        window.Sys.WebForms.PageRequestManager.getInstance().add_endRequest(initializeDynamicState);
    }

    window.ContentBuilderPage = {
        prepareSubmit: function (type) {
            syncAuthoringHidden();
            setValue(type === "chapter" ? "ChapterModalOpenValue" : "LessonModalOpenValue", "1");
            return true;
        },
    };
})(window, document);
