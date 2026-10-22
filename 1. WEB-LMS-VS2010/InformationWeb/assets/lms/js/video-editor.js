(function () {
    function formatTime(value) {
        var seconds = Math.max(0, Math.round(Number(value) || 0));
        return (
            String(Math.floor(seconds / 60)).replace(/^(.{1})$/, "0$1") +
            ":" +
            String(seconds % 60).replace(/^(.{1})$/, "0$1")
        );
    }
    function ready() {
        var player = document.getElementById("videoEditorPlayer");
        var youtubeNode = document.getElementById("videoEditorYoutube"),
            youtubePlayer = null,
            youtubeTimer = null;
        var timeField = document.querySelector('input[id$="CurrentTimeValue"]');
        var durationField = document.querySelector('input[id$="DurationValue"]');
        var currentLabel = document.getElementById("editorCurrentTime");
        var selectedLabel = document.getElementById("timelineSelectedTime");
        var timeline = document.getElementById("editorTimeline");
        var viewport = document.getElementById("editorTimelineViewport");
        var playhead = document.getElementById("editorTimelinePlayhead");
        if (!timeline || !timeField || !durationField) return;
        var zoom = 1;
        function duration() {
            return Math.max(1, Number(durationField.value) || (player && player.duration) || 1);
        }
        function setTime(value, pause) {
            var time = Math.min(duration(), Math.max(0, Number(value) || 0));
            timeField.value = String(Math.round(time));
            if (player) {
                if (pause) player.pause();
                if (Math.abs(player.currentTime - time) > 0.25) player.currentTime = time;
            }
            if (youtubePlayer && pause) {
                youtubePlayer.pauseVideo();
                youtubePlayer.seekTo(time, true);
            }
            var text = formatTime(time);
            if (currentLabel) currentLabel.textContent = text;
            if (selectedLabel) selectedLabel.textContent = text;
            if (playhead) playhead.style.left = Math.min(100, (time / duration()) * 100) + "%";
        }
        if (player) {
            player.addEventListener("timeupdate", function () {
                setTime(player.currentTime, false);
            });
            player.addEventListener("loadedmetadata", function () {
                if (isFinite(player.duration) && player.duration > 0) {
                    durationField.value = String(Math.round(player.duration));
                    setTime(player.currentTime, false);
                }
            });
        }
        if (youtubeNode && window.LmsYouTube)
            window.LmsYouTube.ready(function () {
                youtubePlayer = new window.YT.Player(youtubeNode, {
                    videoId: youtubeNode.getAttribute("data-youtube-id"),
                    playerVars: { playsinline: 1, rel: 0 },
                    events: {
                        onReady: function (event) {
                            durationField.value = String(Math.round(event.target.getDuration() || duration()));
                            setTime(event.target.getCurrentTime(), false);
                        },
                        onStateChange: function (event) {
                            if (event.data === window.YT.PlayerState.PLAYING && !youtubeTimer)
                                youtubeTimer = window.setInterval(function () {
                                    setTime(youtubePlayer.getCurrentTime(), false);
                                }, 250);
                            else if (event.data !== window.YT.PlayerState.PLAYING && youtubeTimer) {
                                window.clearInterval(youtubeTimer);
                                youtubeTimer = null;
                            }
                        },
                    },
                });
            });
        timeline.addEventListener("click", function (event) {
            if (event.target.closest && event.target.closest(".timeline-point")) return;
            var rect = timeline.getBoundingClientRect();
            if (!rect.width) return;
            setTime(((event.clientX - rect.left) / rect.width) * duration(), true);
        });
        var seekers = document.querySelectorAll("[data-seek-time]");
        for (var i = 0; i < seekers.length; i++)
            seekers[i].addEventListener("click", function (event) {
                if (
                    event.target.closest &&
                    event.target.closest("a,button") &&
                    !event.currentTarget.classList.contains("timeline-point")
                )
                    return;
                if (event.currentTarget.tagName === "BUTTON") event.preventDefault();
                setTime(event.currentTarget.getAttribute("data-seek-time"), true);
            });
        function applyZoom(next, anchor) {
            zoom = Math.min(24, Math.max(1, next));
            timeline.style.width = Math.round(zoom * 100) + "%";
            var output = document.getElementById("timelineZoomText");
            if (output) output.textContent = Math.round(zoom * 100) + "%";
            if (viewport && anchor != null)
                viewport.scrollLeft = Math.max(0, anchor * timeline.offsetWidth - viewport.clientWidth / 2);
        }
        if (viewport)
            viewport.addEventListener(
                "wheel",
                function (event) {
                    if (!event.ctrlKey) return;
                    event.preventDefault();
                    var rect = timeline.getBoundingClientRect();
                    var anchor = Math.min(1, Math.max(0, (event.clientX - rect.left) / rect.width));
                    applyZoom(zoom * (event.deltaY < 0 ? 1.25 : 0.8), anchor);
                },
                { passive: false },
            );
        var zoomButtons = document.querySelectorAll("[data-timeline-zoom]");
        for (var z = 0; z < zoomButtons.length; z++)
            zoomButtons[z].addEventListener("click", function () {
                var action = this.getAttribute("data-timeline-zoom");
                applyZoom(
                    action === "reset" ? 1 : zoom * (action === "in" ? 1.25 : 0.8),
                    (Number(timeField.value) || 0) / duration(),
                );
            });
        setTime(timeField.value, false);
    }
    document.addEventListener("DOMContentLoaded", ready);
})();
