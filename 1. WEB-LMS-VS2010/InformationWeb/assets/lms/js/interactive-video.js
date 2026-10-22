(function () {
    var youtubeCallbacks = [],
        youtubeLoading = false;
    function youtubeReady(callback) {
        if (window.YT && window.YT.Player) {
            callback();
            return;
        }
        youtubeCallbacks.push(callback);
        if (youtubeLoading) return;
        youtubeLoading = true;
        var previous = window.onYouTubeIframeAPIReady;
        window.onYouTubeIframeAPIReady = function () {
            if (typeof previous === "function") previous();
            var callbacks = youtubeCallbacks.slice(0);
            youtubeCallbacks.length = 0;
            for (var i = 0; i < callbacks.length; i++) callbacks[i]();
        };
        var script = document.createElement("script");
        script.src = "https://www.youtube.com/iframe_api";
        document.head.appendChild(script);
    }
    window.LmsYouTube = window.LmsYouTube || { ready: youtubeReady };
    function parseJson(id) {
        var node = document.getElementById(id);
        if (!node) return [];
        try {
            return JSON.parse(node.value || node.textContent || "[]");
        } catch (ignore) {
            return [];
        }
    }
    function formatTime(value) {
        var s = Math.max(0, Math.round(Number(value) || 0));
        return String(Math.floor(s / 60)).padStart
            ? String(Math.floor(s / 60)).padStart(2, "0") + ":" + String(s % 60).padStart(2, "0")
            : ("0" + Math.floor(s / 60)).slice(-2) + ":" + ("0" + (s % 60)).slice(-2);
    }
    function post(url, moduleName, operation, values, done) {
        var fields = [
            "module=" + encodeURIComponent(moduleName),
            "operation=" + encodeURIComponent(operation),
            "returnTable=true",
        ];
        for (var key in values)
            if (values.hasOwnProperty(key))
                fields.push(encodeURIComponent(key) + "=" + encodeURIComponent(values[key] == null ? "" : values[key]));
        var xhr = new XMLHttpRequest();
        xhr.open("POST", url, true);
        xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
        xhr.setRequestHeader("X-LMS-Request", "1");
        xhr.onreadystatechange = function () {
            if (xhr.readyState !== 4) return;
            var data = null;
            try {
                data = JSON.parse(xhr.responseText || "{}");
            } catch (ignore) {}
            done(xhr.status, data);
        };
        xhr.send(fields.join("&"));
    }
    function normalizeOptions(value) {
        if (Array.isArray(value)) return value;
        if (!value) return [];
        try {
            return JSON.parse(value);
        } catch (ignore) {
            return [];
        }
    }
    function wire(host) {
        var interactions = parseJson(host.getAttribute("data-interactions-id"))
            .filter(function (x) {
                return String(x.status || "ACTIVE").toUpperCase() === "ACTIVE";
            })
            .sort(function (a, b) {
                return Number(a.time) - Number(b.time);
            });
        var video = host.querySelector(".interactive-video-element,video");
        var youtubeHost = host.querySelector(".interactive-youtube");
        var youtubePlayer = null,
            youtubeTimer = null;
        var track = host.querySelector(".interaction-track");
        var progress = host.querySelector(".interaction-track-progress");
        var playhead = host.querySelector(".interaction-playhead");
        var current = host.querySelector(".timeline-current strong");
        var duration = Math.max(1, Number(host.getAttribute("data-duration")) || 1),
            active = null,
            fired = {},
            lastTime = Math.max(0, Number(host.getAttribute("data-initial-time")) || 0);
        function marker(item, index) {
            if (item.answered) fired[item.id] = true;
            var button = document.createElement("button");
            button.type = "button";
            button.className = "timeline-question" + (item.answered ? " answered" : "");
            button.style.left = Math.min(99, Math.max(1, (Number(item.time) / duration) * 100)) + "%";
            button.innerHTML =
                '<i class="bi ' +
                (item.answered ? "bi-check-circle-fill" : "bi-patch-question-fill") +
                '"></i><span>' +
                formatTime(item.time) +
                "</span>";
            button.onclick = function () {
                open(item);
            };
            track.appendChild(button);
        }
        for (var i = 0; i < interactions.length; i++) marker(interactions[i], i);
        function update(time) {
            var percent = Math.min(100, Math.max(0, (time / duration) * 100));
            if (progress) progress.style.width = percent + "%";
            if (playhead) playhead.style.left = percent + "%";
            if (current) current.textContent = formatTime(time);
        }
        function tick(time) {
            update(time);
            for (var i = 0; i < interactions.length; i++) {
                var item = interactions[i],
                    at = Number(item.time) || 0;
                if (!fired[item.id] && lastTime <= at && time >= at && time - at < 1.5) {
                    fired[item.id] = true;
                    open(item);
                    break;
                }
            }
            lastTime = time;
        }
        if (video) {
            video.addEventListener("loadedmetadata", function () {
                if (isFinite(video.duration) && video.duration > 0) duration = video.duration;
                var initial = Math.max(0, Number(host.getAttribute("data-initial-time")) || 0);
                if (initial && initial < duration) video.currentTime = initial;
                update(initial);
            });
            video.addEventListener("timeupdate", function () {
                tick(video.currentTime);
            });
            video.addEventListener("seeking", function () {
                lastTime = video.currentTime;
            });
        }
        if (youtubeHost)
            youtubeReady(function () {
                youtubePlayer = new window.YT.Player(youtubeHost, {
                    videoId: youtubeHost.getAttribute("data-youtube-id"),
                    playerVars: { playsinline: 1, rel: 0 },
                    events: {
                        onReady: function (event) {
                            duration = event.target.getDuration() || duration;
                            var initial = Math.max(0, Number(host.getAttribute("data-initial-time")) || 0);
                            if (initial) event.target.seekTo(initial, true);
                            update(initial);
                        },
                        onStateChange: function (event) {
                            if (event.data === window.YT.PlayerState.PLAYING && !youtubeTimer)
                                youtubeTimer = window.setInterval(function () {
                                    if (youtubePlayer && youtubePlayer.getCurrentTime)
                                        tick(youtubePlayer.getCurrentTime());
                                }, 250);
                            else if (event.data !== window.YT.PlayerState.PLAYING && youtubeTimer) {
                                window.clearInterval(youtubeTimer);
                                youtubeTimer = null;
                            }
                        },
                    },
                });
            });
        function pauseMedia() {
            if (video) video.pause();
            if (youtubePlayer && youtubePlayer.pauseVideo) youtubePlayer.pauseVideo();
        }
        function playMedia() {
            if (video) video.play();
            if (youtubePlayer && youtubePlayer.playVideo) youtubePlayer.playVideo();
        }
        function seekMedia(time) {
            if (video) video.currentTime = time;
            if (youtubePlayer && youtubePlayer.seekTo) youtubePlayer.seekTo(time, true);
        }
        if (track)
            track.addEventListener("click", function (event) {
                if (event.target.closest && event.target.closest(".timeline-question")) return;
                var rect = track.getBoundingClientRect(),
                    time = ((event.clientX - rect.left) / rect.width) * duration;
                seekMedia(time);
                update(time);
            });
        function open(item) {
            if (active) return;
            active = item;
            if (item.pauseVideo !== false) pauseMedia();
            var options = normalizeOptions(item.options),
                type = String(item.type || "SINGLE_CHOICE").toUpperCase();
            var backdrop = document.createElement("div");
            backdrop.className = "interaction-backdrop";
            var modal = document.createElement("div");
            modal.className = "interaction-modal app-card";
            var fields =
                '<p class="text-secondary mb-1">Câu hỏi tại ' +
                formatTime(item.time) +
                "</p><h2>" +
                escapeHtml(item.label || "Câu hỏi") +
                '</h2><div class="interaction-answer-fields">';
            if (type === "CLOZE_DRAG_DROP") {
                var template = String(item.label || ""),
                    blanks = template.match(/\[\[([A-Za-z0-9_]+)\]\]/g) || [];
                fields += '<p class="lh-lg">' + escapeHtml(template) + "</p>";
                for (var b = 0; b < blanks.length; b++) {
                    var codeName = blanks[b].slice(2, -2);
                    fields +=
                        '<label class="d-block mb-2"><strong>' +
                        escapeHtml(codeName) +
                        '</strong><select class="form-select mt-1" data-cloze="' +
                        escapeAttr(codeName) +
                        '"><option value="">-- Chọn đáp án --</option>';
                    for (var c = 0; c < options.length; c++) {
                        var co = options[c],
                            cv = co.OptionCode || co.optionCode || co.Code || co.code || "";
                        fields +=
                            '<option value="' +
                            escapeAttr(cv) +
                            '">' +
                            escapeHtml(co.OptionText || co.optionText || co.Text || co.text || "") +
                            "</option>";
                    }
                    fields += "</select></label>";
                }
            } else if (type === "SHORT_ANSWER")
                fields += '<textarea class="form-control" rows="3" data-answer-text></textarea>';
            else
                for (var j = 0; j < options.length; j++) {
                    var o = options[j],
                        code = o.OptionCode || o.optionCode || o.Code || o.code || "";
                    fields +=
                        '<label class="interaction-answer"><input type="' +
                        (type === "MULTIPLE_CHOICE" ? "checkbox" : "radio") +
                        '" name="interactive-answer" value="' +
                        escapeAttr(code) +
                        '"><span>' +
                        escapeHtml(code) +
                        "</span><strong>" +
                        escapeHtml(o.OptionText || o.optionText || o.Text || o.text || "") +
                        "</strong></label>";
                }
            fields +=
                '</div><div class="interaction-error alert alert-danger mt-3" hidden></div><div class="d-flex justify-content-end gap-2 mt-3">' +
                (item.allowSkip || !item.required
                    ? '<button type="button" class="btn btn-action-cancel" data-skip>Bỏ qua</button>'
                    : "") +
                '<button type="button" class="btn btn-action-save" data-submit>Gửi câu trả lời</button></div>';
            modal.innerHTML = fields;
            backdrop.appendChild(modal);
            host.appendChild(backdrop);
            var skip = modal.querySelector("[data-skip]");
            if (skip) skip.onclick = close;
            modal.querySelector("[data-submit]").onclick = function () {
                var answers = [],
                    text = modal.querySelector("[data-answer-text]"),
                    cloze = modal.querySelectorAll("[data-cloze]");
                if (text) answers.push(text.value);
                else if (cloze.length) {
                    for (var q = 0; q < cloze.length; q++)
                        if (cloze[q].value) answers.push(cloze[q].getAttribute("data-cloze") + "=" + cloze[q].value);
                } else {
                    var checked = modal.querySelectorAll("input:checked");
                    for (var k = 0; k < checked.length; k++) answers.push(checked[k].value);
                }
                if (!answers.length || !answers.join("").trim()) {
                    showError("Vui lòng chọn hoặc nhập câu trả lời.");
                    return;
                }
                submit(item, answers, modal);
            };
            function showError(text) {
                var node = modal.querySelector(".interaction-error");
                node.textContent = text;
                node.hidden = false;
            }
            function close() {
                if (item.required && !item.allowSkip) return;
                if (backdrop.parentNode) backdrop.parentNode.removeChild(backdrop);
                active = null;
                playMedia();
            }
            function submit(question, answers, dialog) {
                var mode = host.getAttribute("data-mode"),
                    joined = answers
                        .map(function (x) {
                            return String(x).trim().toUpperCase();
                        })
                        .filter(Boolean)
                        .sort()
                        .join("|"),
                    values,
                    moduleName,
                    operation;
                if (mode === "student") {
                    moduleName = "learning";
                    operation = "Answer";
                    values = {
                        StudentId: host.getAttribute("data-student-id"),
                        LessonId: host.getAttribute("data-lesson-id"),
                        VideoId: host.getAttribute("data-video-id"),
                        InteractionId: question.id,
                        QuestionId: question.questionId,
                        AnswerText: joined,
                        TimeInVideoSeconds: Math.round(question.time),
                        TimeSpentSeconds: 0,
                    };
                } else {
                    moduleName = "content";
                    operation = "InteractionPreview";
                    values = {
                        VideoId: host.getAttribute("data-video-id"),
                        InteractionId: question.id,
                        QuestionId: question.questionId,
                        AnswerText: joined,
                        ActorId: 0,
                        IsAdmin: false,
                    };
                }
                post(host.getAttribute("data-handler-url"), moduleName, operation, values, function (status, payload) {
                    if (status < 200 || status >= 300 || !payload || !payload.success) {
                        showError((payload && payload.message) || "Không thể gửi câu trả lời.");
                        return;
                    }
                    var row = (payload.data && payload.data[0]) || {},
                        raw = row.IsCorrect,
                        pending = raw === null || raw === undefined || raw === "",
                        correct = raw === true || String(raw).toLowerCase() === "true",
                        state = pending ? "pending" : correct ? "correct" : "wrong";
                    dialog.innerHTML =
                        '<div class="interaction-result ' +
                        state +
                        '"><i class="bi ' +
                        (pending ? "bi-hourglass-split" : correct ? "bi-check-circle-fill" : "bi-x-circle-fill") +
                        '"></i><h3>' +
                        (pending ? "Đang chờ giảng viên chấm" : correct ? "Chính xác!" : "Chưa chính xác") +
                        "</h3><strong>+" +
                        escapeHtml(row.ScoreAwarded || row.Score || 0) +
                        " điểm</strong><p>" +
                        escapeHtml(row.Explanation || "") +
                        '</p><button type="button" class="btn btn-brand w-100 mt-2">Tiếp tục bài học <i class="bi bi-arrow-right"></i></button></div>';
                    dialog.querySelector("button").onclick = function () {
                        if (backdrop.parentNode) backdrop.parentNode.removeChild(backdrop);
                        active = null;
                        playMedia();
                    };
                });
            }
        }
    }
    function escapeHtml(value) {
        var node = document.createElement("div");
        node.textContent = value == null ? "" : String(value);
        return node.innerHTML;
    }
    function escapeAttr(value) {
        return escapeHtml(value).replace(/"/g, "&quot;");
    }
    document.addEventListener("DOMContentLoaded", function () {
        var hosts = document.querySelectorAll("[data-interactive-video]");
        for (var i = 0; i < hosts.length; i++) wire(hosts[i]);
    });
})();
