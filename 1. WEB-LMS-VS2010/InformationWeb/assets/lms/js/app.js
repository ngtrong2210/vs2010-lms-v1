(function () {
    function each(selector, callback) {
        var nodes = document.querySelectorAll(selector);
        for (var i = 0; i < nodes.length; i++) callback(nodes[i]);
    }

    function postModule(url, moduleName, operation, values, callback) {
        var pairs = ["module=" + encodeURIComponent(moduleName), "operation=" + encodeURIComponent(operation)];
        for (var key in values)
            if (values.hasOwnProperty(key))
                pairs.push(encodeURIComponent(key) + "=" + encodeURIComponent(values[key] == null ? "" : values[key]));
        var request = new XMLHttpRequest();
        request.open("POST", url, true);
        request.setRequestHeader("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
        request.setRequestHeader("X-LMS-Request", "1");
        request.onreadystatechange = function () {
            if (request.readyState !== 4 || !callback) return;
            var payload = null;
            try {
                payload = JSON.parse(request.responseText || "{}");
            } catch (ignore) {
                payload = null;
            }
            callback(request.status, payload);
        };
        request.send(pairs.join("&"));
    }

    function wireStudySession() {
        var host = document.getElementById("lessonPlayerHost");
        if (!host) return;
        var url = host.getAttribute("data-handler-url");
        var lessonId = host.getAttribute("data-lesson-id");
        var courseId = host.getAttribute("data-course-id");
        var studentId = host.getAttribute("data-student-id");
        if (!url || !lessonId || !studentId) return;
        var studySessionId = "";
        var heartbeatTimer = null;
        var ended = false;
        var clientKey = "wf-" + new Date().getTime() + "-" + Math.floor(Math.random() * 1000000);

        postModule(
            url,
            "learning",
            "StudyStart",
            {
                returnTable: true,
                StudentUserID: studentId,
                CourseID: courseId,
                LessonID: lessonId,
                PageUrl: window.location.pathname,
                ClientSessionKey: clientKey,
            },
            function (status, payload) {
                var row = payload && payload.data && payload.data.length ? payload.data[0] : null;
                if (status < 200 || status >= 300 || !row) return;
                studySessionId = row.StudySessionID || row.studySessionID || "";
                if (!studySessionId) return;
                heartbeatTimer = window.setInterval(function () {
                    postModule(url, "learning", "StudyHeartbeat", {
                        returnTable: true,
                        StudySessionID: studySessionId,
                        StudentUserID: studentId,
                    });
                }, 30000);
            },
        );

        function endSession(completed) {
            if (ended || !studySessionId) return;
            ended = true;
            if (heartbeatTimer) window.clearInterval(heartbeatTimer);
            postModule(url, "learning", "StudyEnd", {
                returnTable: true,
                StudySessionID: studySessionId,
                StudentUserID: studentId,
                IsCompleted: completed ? "true" : "false",
            });
        }
        window.addEventListener("pagehide", function () {
            endSession(false);
        });
        var video = document.getElementById("lessonVideo");
        if (video)
            video.addEventListener("ended", function () {
                endSession(true);
            });
    }

    function wireLessonVideo() {
        var host = document.getElementById("lessonPlayerHost");
        var video = document.getElementById("lessonVideo");
        if (!host || !video) return;
        var lessonId = host.getAttribute("data-lesson-id");
        var videoId = video.getAttribute("data-video-id");
        var allowSeek = (video.getAttribute("data-allow-seek") || "").toLowerCase() === "true";
        var allowSpeed = (video.getAttribute("data-allow-speed") || "").toLowerCase() === "true";
        var maxWatched = Math.max(
            0,
            Number(video.getAttribute("data-max-watched")) || Number(video.getAttribute("data-current-time")) || 0,
        );
        var lastSent = 0;

        video.addEventListener("loadedmetadata", function () {
            var initial = Math.max(0, Number(video.getAttribute("data-current-time")) || 0);
            if (initial && initial < video.duration) video.currentTime = initial;
        });
        video.addEventListener("ratechange", function () {
            if (!allowSpeed && video.playbackRate !== 1) video.playbackRate = 1;
        });
        video.addEventListener("seeking", function () {
            if (!allowSeek && video.currentTime > maxWatched + 2) video.currentTime = maxWatched;
        });
        video.addEventListener("timeupdate", function () {
            if (!video.seeking && video.currentTime > maxWatched) maxWatched = video.currentTime;
            var now = new Date().getTime();
            if (now - lastSent >= 15000) {
                saveProgress();
                lastSent = now;
            }
        });
        video.addEventListener("ended", saveProgress);

        function saveProgress() {
            if (!video.duration || !lessonId || !videoId) return;
            postModule(host.getAttribute("data-handler-url"), "learning", "VideoProgress", {
                StudentId: host.getAttribute("data-student-id") || "0",
                LessonId: lessonId,
                VideoId: videoId,
                CurrentTimeSeconds: Math.max(0, Math.round(video.currentTime)),
                MaxWatchedTimeSeconds: Math.max(0, Math.round(maxWatched)),
                WatchPercent: Math.min(100, Math.round((maxWatched / video.duration) * 10000) / 100),
            });
        }
    }

    function wireNotifications() {
        var center = document.querySelector("[data-notification-center]");
        if (!center) return;
        var toggle = center.querySelector("[data-notification-toggle]");
        var panel = center.querySelector("[data-notification-panel]");
        var list = center.querySelector("[data-notification-list]");
        var count = center.querySelector(".notification-count");
        var readAll = center.querySelector("[data-notification-read-all]");
        var url = center.getAttribute("data-handler-url");
        var loaded = false;

        function loadNotifications() {
            var request = new XMLHttpRequest();
            request.open(
                "GET",
                url + "?module=notifications&operation=List&RecipientUserID=0&Limit=20&UnreadOnly=false",
                true,
            );
            request.onreadystatechange = function () {
                if (request.readyState !== 4) return;
                var payload = null;
                try {
                    payload = JSON.parse(request.responseText || "{}");
                } catch (ignore) {
                    payload = null;
                }
                if (request.status < 200 || request.status >= 300 || !payload || !payload.data) {
                    list.textContent = "Không thể tải thông báo.";
                    return;
                }
                render(payload.data);
                loaded = true;
            };
            request.send();
        }

        function render(rows) {
            while (list.firstChild) list.removeChild(list.firstChild);
            if (!rows.length) {
                list.textContent = "Chưa có thông báo.";
                if (count) count.textContent = "0";
                return;
            }
            var unread = 0;
            for (var i = 0; i < rows.length; i++) {
                var row = rows[i];
                var isRead = row.IsRead === true || String(row.IsRead).toLowerCase() === "true";
                if (!isRead) unread++;
                var item = document.createElement("a");
                item.className = "notification-item" + (isRead ? "" : " unread");
                item.href = row.ActionUrl && String(row.ActionUrl).charAt(0) === "/" ? row.ActionUrl : "#";
                item.setAttribute("data-notification-id", row.Id || "");
                var title = document.createElement("strong");
                title.textContent = row.Title || "Thông báo";
                var message = document.createElement("small");
                message.textContent = row.Message || "";
                item.appendChild(title);
                item.appendChild(message);
                list.appendChild(item);
                item.addEventListener("click", function () {
                    var id = this.getAttribute("data-notification-id");
                    if (id) postModule(url, "notifications", "Read", { NotificationID: id, RecipientUserID: 0 });
                });
            }
            if (count) count.textContent = String(unread);
        }

        toggle.addEventListener("click", function (event) {
            event.stopPropagation();
            panel.hidden = !panel.hidden;
            if (!panel.hidden && !loaded) loadNotifications();
        });
        readAll.addEventListener("click", function (event) {
            event.preventDefault();
            event.stopPropagation();
            postModule(url, "notifications", "ReadAll", { RecipientUserID: 0 }, function (status) {
                if (status >= 200 && status < 300) {
                    loaded = false;
                    loadNotifications();
                }
            });
        });
        document.addEventListener("click", function (event) {
            if (!center.contains(event.target)) panel.hidden = true;
        });
    }

    function wireLessonPlayerUi() {
        var page = document.querySelector("[data-lesson-player-page]");
        if (!page) return;
        var host = page.querySelector("#lessonPlayerHost");
        var curriculum = page.querySelector("[data-lesson-curriculum]");
        var backdrop = page.querySelector(".curriculum-backdrop");
        var focusButton = page.querySelector("[data-lesson-focus-toggle]");
        var sidebarButton = page.querySelector("[data-lesson-sidebar-toggle]");

        function closeCurriculum() {
            if (host) host.classList.add("sidebar-closed");
            if (curriculum) curriculum.classList.remove("is-open");
            if (backdrop) backdrop.classList.remove("is-open");
        }
        function openCurriculum() {
            if (host) host.classList.remove("sidebar-closed");
            if (curriculum) curriculum.classList.add("is-open");
            if (backdrop) backdrop.classList.add("is-open");
        }
        if (sidebarButton)
            sidebarButton.addEventListener("click", function () {
                if (host && host.classList.contains("sidebar-closed")) openCurriculum();
                else closeCurriculum();
            });
        each("[data-lesson-sidebar-close]", function (button) {
            button.addEventListener("click", closeCurriculum);
        });
        if (focusButton)
            focusButton.addEventListener("click", function () {
                var focused = page.classList.toggle("focus-mode");
                var icon = focusButton.querySelector("i");
                if (icon) icon.className = focused ? "bi bi-fullscreen-exit" : "bi bi-arrows-fullscreen";
                focusButton.setAttribute("title", focused ? "Thoát chế độ tập trung" : "Chế độ tập trung");
                if (focused) closeCurriculum();
                else openCurriculum();
            });

        each("[data-lesson-tab]", function (button) {
            button.addEventListener("click", function () {
                var key = button.getAttribute("data-lesson-tab");
                each("[data-lesson-tab]", function (item) {
                    item.classList.toggle("active", item === button);
                });
                each("[data-lesson-tab-panel]", function (panel) {
                    panel.hidden = panel.getAttribute("data-lesson-tab-panel") !== key;
                });
            });
        });
        each("[data-chapter-toggle]", function (button) {
            button.addEventListener("click", function () {
                var list = button.nextElementSibling;
                var icon = button.querySelector("i");
                if (!list) return;
                list.hidden = !list.hidden;
                if (icon) icon.className = list.hidden ? "bi bi-chevron-down" : "bi bi-chevron-up";
            });
        });
        each("[data-video-question-time]", function (button) {
            button.addEventListener("click", function () {
                var video = page.querySelector("#lessonVideo");
                var seconds = parseFloat(button.getAttribute("data-video-question-time") || "0");
                if (video && !isNaN(seconds)) video.currentTime = Math.max(0, seconds);
            });
        });
        if (window.matchMedia && window.matchMedia("(max-width: 1100px)").matches) closeCurriculum();
    }

    document.addEventListener("DOMContentLoaded", function () {
        each("[data-sidebar-toggle]", function (button) {
            button.addEventListener("click", function () {
                var sidebar = document.getElementById("cmsSidebar");
                if (sidebar) sidebar.classList.toggle("open");
            });
        });

        var current = window.location.pathname.toLowerCase();
        each(".cms-nav a,.student-nav a", function (link) {
            var href = (link.getAttribute("href") || "").toLowerCase();
            if (href && href !== "/" && current.indexOf(href) === 0) link.classList.add("active");
        });

        var shell = document.querySelector("[data-cms-shell]");
        var collapseButton = document.querySelector("[data-sidebar-collapse]");
        if (shell && collapseButton) {
            if (window.localStorage && window.localStorage.getItem("cms_sidebar_collapsed") === "1")
                shell.classList.add("sidebar-collapsed");
            collapseButton.addEventListener("click", function () {
                shell.classList.toggle("sidebar-collapsed");
                if (window.localStorage)
                    window.localStorage.setItem(
                        "cms_sidebar_collapsed",
                        shell.classList.contains("sidebar-collapsed") ? "1" : "0",
                    );
                collapseButton.setAttribute(
                    "aria-label",
                    shell.classList.contains("sidebar-collapsed") ? "Mở rộng thanh menu" : "Thu gọn thanh menu",
                );
                collapseButton.setAttribute(
                    "title",
                    shell.classList.contains("sidebar-collapsed") ? "Mở rộng menu" : "Thu gọn menu",
                );
            });
        }

        var desktopMenu = document.querySelector("#cmsSidebar .cms-nav");
        var mobileMenu = document.querySelector("[data-mobile-menu]");
        if (desktopMenu && mobileMenu) {
            var clone = desktopMenu.cloneNode(true);
            clone.removeAttribute("aria-label");
            mobileMenu.appendChild(clone);
            each("[data-mobile-menu] a", function (link) {
                link.addEventListener("click", function () {
                    if (window.bootstrap && window.bootstrap.Offcanvas) {
                        var panel = document.getElementById("mobileMenu");
                        var instance = window.bootstrap.Offcanvas.getInstance(panel);
                        if (instance) instance.hide();
                    }
                });
            });
        }

        var pageTitle = document.querySelector("[data-page-title]");
        if (pageTitle) {
            var titleText = (document.title || "").split(" - ")[0];
            if (titleText) pageTitle.textContent = titleText;
        }

        if (/\/lms\/courses\/\d+\/lessons\/\d+\/?$/i.test(current)) document.body.classList.add("immersive-route");

        each("[data-password-toggle]", function (button) {
            button.addEventListener("click", function () {
                var input = button.parentNode ? button.parentNode.querySelector("input") : null;
                var icon = button.querySelector("i");
                if (!input) return;
                var show = input.type === "password";
                input.type = show ? "text" : "password";
                button.setAttribute("aria-label", show ? "Ẩn mật khẩu" : "Hiện mật khẩu");
                if (icon) icon.className = show ? "bi bi-eye-slash" : "bi bi-eye";
            });
        });

        each("[data-demo-login]", function (button) {
            button.addEventListener("click", function () {
                var form = button.form || document.getElementById("LoginForm");
                var username = form ? form.querySelector('input[autocomplete="username"]') : null;
                var password = form ? form.querySelector('input[autocomplete="current-password"]') : null;
                if (!username || !password) return;
                username.value = button.getAttribute("data-demo-login") || "";
                password.value = "123456";
                username.dispatchEvent(new Event("input", { bubbles: true }));
                password.dispatchEvent(new Event("input", { bubbles: true }));
                username.focus();
            });
        });

        each("[data-confirm]", function (control) {
            control.addEventListener("click", function (event) {
                if (!window.confirm(control.getAttribute("data-confirm"))) event.preventDefault();
            });
        });

        wireLessonPlayerUi();
        wireLessonVideo();
        wireStudySession();
        wireNotifications();
    });
})();
