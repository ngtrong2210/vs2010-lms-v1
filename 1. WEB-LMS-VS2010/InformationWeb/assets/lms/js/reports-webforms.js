(function (document) {
    "use strict";
    function server(id) {
        return document.getElementById(id) || document.querySelector('[id$="_' + id + '"]');
    }
    var select = server("ReportTypeList"),
        submit = server("SearchButton");
    if (!select || !submit) return;
    var labels = {
        CourseOverview: "Tổng quan khóa học",
        StudentProgress: "Tiến độ học viên",
        LessonCompletion: "Hoàn thành bài học",
        QuestionPerformance: "Hiệu quả câu hỏi",
        VideoEngagement: "Tương tác video",
    };
    function sync() {
        var title = labels[select.value] || "Báo cáo đào tạo";
        document.getElementById("activeReportTitle").textContent = title;
        document.getElementById("activeReportChartTitle").textContent = "Biểu đồ " + title;
        [].forEach.call(document.querySelectorAll("[data-report-type]"), function (button) {
            button.classList.toggle("active", button.getAttribute("data-report-type") === select.value);
        });
    }
    document.addEventListener("click", function (event) {
        var button = event.target.closest("[data-report-type]");
        if (!button) return;
        select.value = button.getAttribute("data-report-type");
        sync();
        submit.click();
    });
    select.addEventListener("change", sync);
    sync();
})(document);
