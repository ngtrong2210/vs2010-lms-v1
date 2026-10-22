(function (window, document) {
    "use strict";

    var page = document.getElementById("academicPage");
    if (!page) return;

    function byId(id) {
        return document.getElementById(id) || document.querySelector('[id$="_' + id + '"]');
    }
    function value(id) {
        var element = byId(id);
        return element ? element.value : "";
    }
    function setValue(id, next) {
        var element = byId(id);
        if (element) element.value = next == null ? "" : String(next);
    }
    function escapeHtml(input) {
        return String(input == null ? "" : input).replace(/[&<>"']/g, function (char) {
            return { "&": "&amp;", "<": "&lt;", ">": "&gt;", '"': "&quot;", "'": "&#39;" }[char];
        });
    }
    function text(input, fallback) {
        return input === undefined || input === null || input === "" ? fallback || "" : String(input);
    }
    function number(input, fallback) {
        var result = Number(input);
        return isFinite(result) ? result : fallback || 0;
    }
    function lower(input) {
        return text(input).toLocaleLowerCase("vi-VN");
    }
    function bool(input) {
        return input === true || input === 1 || input === "1" || String(input).toLowerCase() === "true";
    }
    function first(row, names, fallback) {
        for (var index = 0; index < names.length; index += 1) {
            if (row && row[names[index]] !== undefined && row[names[index]] !== null) return row[names[index]];
        }
        return fallback;
    }
    function json(id, fallback) {
        try {
            return JSON.parse(value(id) || "");
        } catch (error) {
            return fallback;
        }
    }
    function rows(source) {
        return Array.isArray(source) ? source : [];
    }
    function attr(input) {
        return escapeHtml(text(input));
    }

    var raw = json("AcademicCatalogJsonValue", {});
    var data = {
        years: rows(raw.years || raw.Years),
        sciences: rows(raw.sciences || raw.Sciences),
        cohorts: rows(raw.cohorts || raw.Cohorts),
        classes: rows(raw.classes || raw.Classes),
        subjects: rows(raw.subjects || raw.Subjects),
        teachers: rows(raw.teachers || raw.Teachers),
        students: rows(raw.students || raw.Students),
        offerings: rows(raw.offerings || raw.ClassSubjects),
        timetables: rows(raw.timetables || raw.Timetables),
    };
    var isAdmin = value("AcademicIsAdminValue") === "1";
    var state = {
        activeTab: window.localStorage.getItem("cms-academic-active-tab") || "offerings",
        viewModes: {
            offerings:
                window.localStorage.getItem("cms-academic-view-offerings") ||
                window.localStorage.getItem("cms-academic-offering-view") ||
                "list",
            classes: window.localStorage.getItem("cms-academic-view-classes") || "cards",
            subjects: window.localStorage.getItem("cms-academic-view-subjects") || "cards",
            students: window.localStorage.getItem("cms-academic-view-students") || "list",
        },
        selectedStudents: [],
        assignClassId: "",
    };
    if (!/^(offerings|timetable|classes|subjects|students|catalog)$/.test(state.activeTab))
        state.activeTab = "offerings";

    var labels = {
        offerings: [
            "môn học lớp",
            "Thu hẹp theo từ khóa, năm học, học kỳ và lớp hành chính",
            "Tên môn, mã môn, lớp hoặc giảng viên...",
        ],
        timetable: [
            "thời khóa biểu",
            "Tìm lịch theo môn, lớp, phòng, năm học và học kỳ",
            "Tên môn, lớp hoặc phòng học...",
        ],
        classes: ["lớp", "Tìm theo mã lớp, tên lớp, khoa hoặc khóa tuyển sinh", "Mã lớp, tên lớp hoặc khóa..."],
        subjects: ["môn học", "Tìm theo mã môn, tên môn hoặc khoa phụ trách", "Mã môn hoặc tên môn học..."],
        students: ["học viên", "Tìm theo tên, mã sinh viên, email hoặc lớp", "Tên, mã sinh viên hoặc email..."],
        catalog: ["danh mục gốc", "Tìm trong năm học, khoa và khóa tuyển sinh", "Tên hoặc mã danh mục..."],
    };

    function mapYear(row) {
        return {
            id: first(row, ["YearID", "yearId"]),
            name: first(row, ["YearName", "yearName"]),
            startAt: first(row, ["StartAt", "startAt"]),
            finishAt: first(row, ["FinishAt", "finishAt"]),
        };
    }
    function mapScience(row) {
        return {
            id: first(row, ["ScienceID", "scienceId"]),
            name: first(row, ["ScienceName", "scienceName"]),
            shortName: first(row, ["ScienceShortName", "scienceShortName"]),
        };
    }
    function mapCohort(row) {
        return {
            id: first(row, ["CourseID", "courseId"]),
            name: first(row, ["CourseName", "courseName"]),
            startYear: first(row, ["StartYear", "startYear"]),
            finishYear: first(row, ["FinishYear", "finishYear"]),
        };
    }
    function mapClass(row) {
        return {
            id: first(row, ["ClassID", "classId"]),
            name: first(row, ["ClassName", "className"]),
            scienceId: first(row, ["ScienceID", "scienceId"]),
            science: first(row, ["ScienceName", "scienceName"]),
            cohortId: first(row, ["CourseID", "courseId"]),
            cohort: first(row, ["CourseName", "courseName"]),
            size: number(first(row, ["ClassSize", "classSize"])),
            students: number(first(row, ["StudentCount", "studentCount"])),
        };
    }
    function mapSubject(row) {
        return {
            id: first(row, ["SubjectID", "subjectId"]),
            name: first(row, ["SubjectName", "subjectName"]),
            scienceId: first(row, ["ScienceID", "scienceId"]),
            science: first(row, ["ScienceName", "scienceName"]),
            credit: number(first(row, ["CreditCount", "creditCount"])),
            theory: number(first(row, ["TheoryQuantity", "theoryQuantity"])),
            practice: number(first(row, ["PracticeQuantity", "practiceQuantity"])),
        };
    }
    function mapTeacher(row) {
        return {
            id: first(row, ["TeacherID", "teacherId"]),
            name: first(row, ["TeacherName", "teacherName", "FullName", "fullName"]),
        };
    }
    function mapStudent(row) {
        return {
            userId: number(first(row, ["UserID", "UserId", "userId"])),
            id: first(row, ["StudentID", "StudentId", "studentId", "StudentCode"]),
            name: first(row, ["FullName", "fullName"]),
            classId: first(row, ["ClassID", "classId"]),
            className: first(row, ["ClassName", "className"]),
            email: first(row, ["Email", "email"]),
            mobile: first(row, ["Mobile", "mobile", "PhoneNumber"]),
        };
    }
    function mapOffering(row) {
        return {
            id: number(first(row, ["ClassSubjectID", "classSubjectId"])),
            yearId: first(row, ["YearID", "yearId"]),
            year: first(row, ["YearName", "yearName"]),
            semester: first(row, ["Semester", "semester"]),
            classId: first(row, ["ClassID", "classId"]),
            className: first(row, ["ClassName", "className"]),
            subjectId: first(row, ["SubjectID", "subjectId"]),
            subjectName: first(row, ["SubjectName", "subjectName"]),
            teacherId: first(row, ["TeacherID", "teacherId"]),
            teacherName: first(row, ["TeacherName", "teacherName"]),
            onlineCourseId: number(first(row, ["OnlineCourseID", "onlineCourseId"])),
            onlineCourseTitle: first(row, ["OnlineCourseTitle", "onlineCourseTitle"]),
            chapters: number(first(row, ["ChapterCount", "chapterCount"])),
            lessons: number(first(row, ["LessonCount", "lessonCount"])),
            students: number(first(row, ["StudentCount", "studentCount"])),
            theory: number(first(row, ["TheoryQuantity", "theoryQuantity"])),
            practice: number(first(row, ["PracticeQuantity", "practiceQuantity"])),
            credit: number(first(row, ["CreditCount", "creditCount"])),
        };
    }
    function mapTimetable(row) {
        return {
            id: number(first(row, ["TimetableID", "timetableId"])),
            classSubjectId: number(first(row, ["ClassSubjectID", "classSubjectId"])),
            day: number(first(row, ["DayOfWeek", "dayOfWeek"])),
            startPeriod: first(row, ["StartPeriod", "startPeriod"]),
            endPeriod: first(row, ["EndPeriod", "endPeriod"]),
            startTime: first(row, ["StartTime", "startTime"]),
            endTime: first(row, ["EndTime", "endTime"]),
            room: first(row, ["RoomName", "roomName"]),
            from: first(row, ["EffectiveFrom", "effectiveFrom"]),
            to: first(row, ["EffectiveTo", "effectiveTo"]),
            yearId: first(row, ["YearID", "yearId"]),
            year: first(row, ["YearName", "yearName"]),
            semester: first(row, ["Semester", "semester"]),
            classId: first(row, ["ClassID", "classId"]),
            className: first(row, ["ClassName", "className"]),
            subjectId: first(row, ["SubjectID", "subjectId"]),
            subjectName: first(row, ["SubjectName", "subjectName"]),
        };
    }

    data.years = data.years.map(mapYear);
    data.sciences = data.sciences.map(mapScience);
    data.cohorts = data.cohorts.map(mapCohort);
    data.classes = data.classes.map(mapClass);
    data.subjects = data.subjects.map(mapSubject);
    data.teachers = data.teachers.map(mapTeacher);
    data.students = data.students.map(mapStudent);
    data.offerings = data.offerings.map(mapOffering);
    data.timetables = data.timetables.map(mapTimetable);

    function dateText(input) {
        if (!input) return "—";
        var parsed = new Date(input);
        return isNaN(parsed.getTime()) ? text(input).slice(0, 10) : parsed.toLocaleDateString("vi-VN");
    }
    function timeText(input) {
        if (!input) return "—";
        var match = text(input).match(/(\d{1,2}):(\d{2})/);
        return match ? ("0" + match[1]).slice(-2) + ":" + match[2] : text(input);
    }
    function dayLabel(day) {
        return (
            { 2: "Thứ Hai", 3: "Thứ Ba", 4: "Thứ Tư", 5: "Thứ Năm", 6: "Thứ Sáu", 7: "Thứ Bảy", 8: "Chủ nhật" }[
                number(day)
            ] || "—"
        );
    }
    function contains(values, keyword) {
        if (!keyword) return true;
        for (var index = 0; index < values.length; index += 1)
            if (lower(values[index]).indexOf(keyword) >= 0) return true;
        return false;
    }
    function filterValue(id) {
        return value(id);
    }
    function keyword() {
        return lower(value("academicKeyword").trim());
    }
    function option(valueText, labelText) {
        return '<option value="' + attr(valueText) + '">' + escapeHtml(labelText) + "</option>";
    }
    function fillSelect(id, items, valueName, labelName, firstLabel) {
        var select = byId(id);
        if (!select) return;
        var current = select.value;
        var html = '<option value="">' + escapeHtml(firstLabel) + "</option>";
        items.forEach(function (item) {
            html += option(item[valueName], item[labelName]);
        });
        select.innerHTML = html;
        if (
            [].some.call(select.options, function (item) {
                return item.value === current;
            })
        )
            select.value = current;
    }

    function initOptions() {
        fillSelect("academicYearFilter", data.years, "id", "name", "Tất cả năm học");
        fillSelect("academicClassFilter", data.classes, "id", "name", "Tất cả lớp");
        fillSelect("academicStudentClassFilter", data.classes, "id", "name", "Tất cả lớp");
        fillSelect("academicScienceFilter", data.sciences, "name", "name", "Tất cả khoa");
        fillSelect("academicParentCode", data.sciences, "id", "name", "Chọn khoa");
        fillSelect("academicCohortId", data.cohorts, "id", "name", "Chọn khóa");
        fillSelect("academicYearId", data.years, "id", "name", "Chọn năm");
        fillSelect("academicClassId", data.classes, "id", "name", "Chọn lớp");
        fillSelect("academicSubjectId", data.subjects, "id", "name", "Chọn môn");
        fillSelect("academicTeacherId", data.teachers, "id", "name", "Chưa phân công");
        var courseSelect = byId("academicClassSubjectId");
        if (courseSelect) {
            courseSelect.innerHTML =
                '<option value="">Chọn môn học lớp</option>' +
                data.offerings
                    .map(function (item) {
                        return option(
                            item.id,
                            item.className + " · " + item.subjectName + " · " + item.year + " HK" + item.semester,
                        );
                    })
                    .join("");
        }
        byId("academicCountOfferings").textContent = data.offerings.length;
        byId("academicCountTimetables").textContent = data.timetables.length;
        byId("academicCountClasses").textContent = data.classes.length;
        byId("academicCountSubjects").textContent = data.subjects.length;
        byId("academicCountStudents").textContent = data.students.length;
        byId("academicCountCatalog").textContent = data.years.length + data.sciences.length + data.cohorts.length;
    }

    function filteredOfferings() {
        var term = keyword(),
            year = filterValue("academicYearFilter"),
            semester = filterValue("academicSemesterFilter"),
            classId = filterValue("academicClassFilter");
        return data.offerings.filter(function (item) {
            return (
                (!year || text(item.yearId) === year) &&
                (!semester || text(item.semester) === semester) &&
                (!classId || text(item.classId) === classId) &&
                contains(
                    [
                        item.subjectId,
                        item.subjectName,
                        item.classId,
                        item.className,
                        item.teacherName,
                        item.onlineCourseTitle,
                    ],
                    term,
                )
            );
        });
    }
    function filteredTimetables() {
        var term = keyword(),
            year = filterValue("academicYearFilter"),
            semester = filterValue("academicSemesterFilter"),
            classId = filterValue("academicClassFilter");
        return data.timetables.filter(function (item) {
            return (
                (!year || text(item.yearId) === year) &&
                (!semester || text(item.semester) === semester) &&
                (!classId || text(item.classId) === classId) &&
                contains([item.subjectId, item.subjectName, item.classId, item.className, item.room], term)
            );
        });
    }
    function filteredClasses() {
        var term = keyword(),
            science = filterValue("academicScienceFilter");
        return data.classes.filter(function (item) {
            return (
                (!science || item.science === science) &&
                contains([item.id, item.name, item.science, item.cohort], term)
            );
        });
    }
    function filteredSubjects() {
        var term = keyword(),
            science = filterValue("academicScienceFilter");
        return data.subjects.filter(function (item) {
            return (!science || item.science === science) && contains([item.id, item.name, item.science], term);
        });
    }
    function filteredStudents() {
        var term = keyword(),
            classId = filterValue("academicStudentClassFilter");
        return data.students.filter(function (item) {
            return (
                (!classId || text(item.classId) === classId) &&
                contains([item.id, item.name, item.email, item.mobile, item.classId, item.className], term)
            );
        });
    }

    function empty(message) {
        return '<div class="app-card empty-cell">' + escapeHtml(message) + "</div>";
    }
    function offeringList(items) {
        if (!items.length) return empty("Không có môn học lớp phù hợp bộ lọc.");
        return (
            '<div class="app-card table-card"><div class="table-card-heading"><div><strong>Môn học lớp đang mở</strong><small>Mỗi dòng là một môn của một lớp trong một năm và học kỳ.</small></div></div><div class="table-responsive"><table class="table align-middle academic-table"><thead><tr><th>STT</th><th>Năm / Học kỳ</th><th>Lớp</th><th>Môn học</th><th>Giảng viên</th><th>Nội dung LMS</th><th>Quy mô</th></tr></thead><tbody>' +
            items
                .map(function (item, index) {
                    var course = item.onlineCourseId
                        ? '<a class="course-link" href="/cms/courses/' +
                          item.onlineCourseId +
                          '/content"><i class="bi bi-box-arrow-up-right"></i><span><strong>' +
                          escapeHtml(item.onlineCourseTitle || item.subjectName) +
                          "</strong><small>" +
                          item.chapters +
                          " chương · " +
                          item.lessons +
                          " bài</small></span></a>"
                        : '<span class="badge badge-soft-warning">Chưa tạo nội dung</span>';
                    return (
                        "<tr><td>" +
                        (index + 1) +
                        "</td><td><strong>" +
                        escapeHtml(item.year) +
                        "</strong><small>Học kỳ " +
                        escapeHtml(item.semester) +
                        "</small></td><td><strong>" +
                        escapeHtml(item.className) +
                        "</strong><small>" +
                        escapeHtml(item.classId) +
                        "</small></td><td><strong>" +
                        escapeHtml(item.subjectName) +
                        "</strong><small>" +
                        escapeHtml(item.subjectId) +
                        " · " +
                        item.credit +
                        " tín chỉ</small></td><td>" +
                        escapeHtml(item.teacherName || "Chưa phân công") +
                        "</td><td>" +
                        course +
                        "</td><td><strong>" +
                        item.students +
                        " học viên</strong><small>" +
                        item.theory +
                        " LT · " +
                        item.practice +
                        " TH</small></td></tr>"
                    );
                })
                .join("") +
            "</tbody></table></div></div>"
        );
    }
    function offeringCards(items) {
        if (!items.length) return empty("Không có môn học lớp phù hợp bộ lọc.");
        return (
            '<div class="offering-grid">' +
            items
                .map(function (item) {
                    return (
                        '<article class="app-card offering-card"><header><span class="offering-icon"><i class="bi bi-journal-bookmark-fill"></i></span><span class="badge badge-soft-primary">' +
                        escapeHtml(item.year) +
                        " · HK" +
                        escapeHtml(item.semester) +
                        '</span></header><div class="offering-card-title"><h3>' +
                        escapeHtml(item.subjectName) +
                        "</h3><small>" +
                        escapeHtml(item.subjectId) +
                        " · " +
                        item.credit +
                        " tín chỉ</small></div><dl><div><dt>Lớp</dt><dd>" +
                        escapeHtml(item.className) +
                        "</dd></div><div><dt>Giảng viên</dt><dd>" +
                        escapeHtml(item.teacherName || "Chưa phân công") +
                        "</dd></div><div><dt>Học viên</dt><dd>" +
                        item.students +
                        " học viên</dd></div><div><dt>Khối lượng</dt><dd>" +
                        item.theory +
                        " LT · " +
                        item.practice +
                        " TH</dd></div></dl><footer>" +
                        (item.onlineCourseId
                            ? '<a class="btn btn-action-view btn-sm" href="/cms/courses/' +
                              item.onlineCourseId +
                              '/content"><i class="bi bi-box-arrow-up-right"></i> Mở nội dung LMS</a>'
                            : '<span class="badge badge-soft-warning">Chưa tạo nội dung LMS</span>') +
                        "</footer></article>"
                    );
                })
                .join("") +
            "</div>"
        );
    }
    function timetable(items) {
        var actionHeader = isAdmin ? '<th class="action-cell">Thao tác</th>' : "";
        if (!items.length)
            return (
                '<div class="app-card table-card"><div class="table-card-heading timetable-heading"><div><strong>Thời khóa biểu</strong><small>Lịch học của từng môn học lớp trong năm học.</small></div>' +
                (isAdmin
                    ? '<button type="button" class="btn btn-action-create btn-sm" data-academic-create="TIMETABLE"><i class="bi bi-calendar2-plus"></i> Thêm lịch học</button>'
                    : "") +
                "</div>" +
                empty("Không có lịch học phù hợp bộ lọc.") +
                "</div>"
            );
        return (
            '<div class="app-card table-card"><div class="table-card-heading timetable-heading"><div><strong>Thời khóa biểu</strong><small>Lịch học của từng môn học lớp trong năm học.</small></div>' +
            (isAdmin
                ? '<button type="button" class="btn btn-action-create btn-sm" data-academic-create="TIMETABLE"><i class="bi bi-calendar2-plus"></i> Thêm lịch học</button>'
                : "") +
            '</div><div class="table-responsive"><table class="table align-middle academic-table timetable-table"><thead><tr><th>STT</th><th>Thứ</th><th>Thời gian</th><th>Lớp / Môn học</th><th>Phòng</th><th>Hiệu lực</th>' +
            actionHeader +
            "</tr></thead><tbody>" +
            items
                .map(function (item, index) {
                    return (
                        "<tr><td>" +
                        (index + 1) +
                        '</td><td><span class="day-badge">' +
                        dayLabel(item.day) +
                        "</span></td><td><strong>" +
                        timeText(item.startTime) +
                        " – " +
                        timeText(item.endTime) +
                        "</strong><small>Tiết " +
                        text(item.startPeriod, "—") +
                        " – " +
                        text(item.endPeriod, "—") +
                        "</small></td><td><strong>" +
                        escapeHtml(item.subjectName) +
                        "</strong><small>" +
                        escapeHtml(item.className) +
                        " · " +
                        escapeHtml(item.year) +
                        " · HK" +
                        escapeHtml(item.semester) +
                        "</small></td><td>" +
                        escapeHtml(item.room || "Chưa xếp phòng") +
                        "</td><td>" +
                        dateText(item.from) +
                        " – " +
                        dateText(item.to) +
                        "</td>" +
                        (isAdmin
                            ? '<td class="action-cell"><button type="button" class="btn btn-action-view btn-sm" data-academic-timetable="' +
                              item.id +
                              '"><i class="bi bi-pencil-square"></i> Sửa lịch</button></td>'
                            : "") +
                        "</tr>"
                    );
                })
                .join("") +
            "</tbody></table></div></div>"
        );
    }
    function classCards(items) {
        if (!items.length) return empty("Không có lớp phù hợp bộ lọc.");
        return (
            '<div class="catalog-grid">' +
            items
                .map(function (item) {
                    return (
                        '<article class="app-card catalog-card"><header><span class="catalog-icon blue"><i class="bi bi-people"></i></span><span class="status-dot"></span></header><strong>' +
                        escapeHtml(item.name) +
                        "</strong><small>" +
                        escapeHtml(item.id) +
                        " · " +
                        escapeHtml(item.science) +
                        "</small><dl><div><dt>Khóa</dt><dd>" +
                        escapeHtml(item.cohort) +
                        "</dd></div><div><dt>Sĩ số</dt><dd>" +
                        item.students +
                        "/" +
                        item.size +
                        "</dd></div></dl>" +
                        (isAdmin
                            ? '<button type="button" class="btn btn-action-view btn-sm" data-academic-assign="' +
                              attr(item.id) +
                              '"><i class="bi bi-person-check"></i> Phân học viên</button>'
                            : "") +
                        "</article>"
                    );
                })
                .join("") +
            (isAdmin && !keyword() && !filterValue("academicScienceFilter")
                ? '<button type="button" class="app-card catalog-add" data-academic-create="CLASS"><i class="bi bi-plus-circle"></i><span>Thêm lớp hành chính</span></button>'
                : "") +
            "</div>"
        );
    }
    function classList(items) {
        if (!items.length) return empty("Không có lớp phù hợp bộ lọc.");
        return (
            '<div class="app-card table-card"><div class="table-responsive"><table class="table align-middle academic-table"><thead><tr><th>STT</th><th>Lớp</th><th>Khoa</th><th>Khóa</th><th>Sĩ số</th>' +
            (isAdmin ? "<th>Thao tác</th>" : "") +
            "</tr></thead><tbody>" +
            items
                .map(function (item, index) {
                    return (
                        "<tr><td>" +
                        (index + 1) +
                        "</td><td><strong>" +
                        escapeHtml(item.name) +
                        "</strong><small>" +
                        escapeHtml(item.id) +
                        "</small></td><td>" +
                        escapeHtml(item.science) +
                        "</td><td>" +
                        escapeHtml(item.cohort) +
                        "</td><td>" +
                        item.students +
                        "/" +
                        item.size +
                        " học viên</td>" +
                        (isAdmin
                            ? '<td><button type="button" class="btn btn-action-view btn-sm" data-academic-assign="' +
                              attr(item.id) +
                              '"><i class="bi bi-person-check"></i> Phân học viên</button></td>'
                            : "") +
                        "</tr>"
                    );
                })
                .join("") +
            "</tbody></table></div></div>"
        );
    }
    function subjectCards(items) {
        if (!items.length) return empty("Không có môn học phù hợp bộ lọc.");
        return (
            '<div class="catalog-grid">' +
            items
                .map(function (item) {
                    return (
                        '<article class="app-card catalog-card"><header><span class="catalog-icon green"><i class="bi bi-book"></i></span><span class="credit-badge">' +
                        item.credit +
                        " TC</span></header><strong>" +
                        escapeHtml(item.name) +
                        "</strong><small>" +
                        escapeHtml(item.id) +
                        " · " +
                        escapeHtml(item.science) +
                        "</small><dl><div><dt>Lý thuyết</dt><dd>" +
                        item.theory +
                        " tiết</dd></div><div><dt>Thực hành</dt><dd>" +
                        item.practice +
                        " tiết</dd></div></dl></article>"
                    );
                })
                .join("") +
            (isAdmin && !keyword() && !filterValue("academicScienceFilter")
                ? '<button type="button" class="app-card catalog-add" data-academic-create="SUBJECT"><i class="bi bi-plus-circle"></i><span>Thêm môn học</span></button>'
                : "") +
            "</div>"
        );
    }
    function subjectList(items) {
        if (!items.length) return empty("Không có môn học phù hợp bộ lọc.");
        return (
            '<div class="app-card table-card"><div class="table-responsive"><table class="table align-middle academic-table"><thead><tr><th>STT</th><th>Môn học</th><th>Khoa</th><th>Tín chỉ</th><th>Lý thuyết</th><th>Thực hành</th></tr></thead><tbody>' +
            items
                .map(function (item, index) {
                    return (
                        "<tr><td>" +
                        (index + 1) +
                        "</td><td><strong>" +
                        escapeHtml(item.name) +
                        "</strong><small>" +
                        escapeHtml(item.id) +
                        "</small></td><td>" +
                        escapeHtml(item.science) +
                        "</td><td>" +
                        item.credit +
                        " tín chỉ</td><td>" +
                        item.theory +
                        " tiết</td><td>" +
                        item.practice +
                        " tiết</td></tr>"
                    );
                })
                .join("") +
            "</tbody></table></div></div>"
        );
    }
    function studentCards(items) {
        if (!items.length) return empty("Không có học viên phù hợp bộ lọc.");
        return (
            '<div class="student-grid">' +
            items
                .map(function (item) {
                    return (
                        '<article class="app-card student-card"><span class="catalog-icon blue"><i class="bi bi-person"></i></span><div><strong>' +
                        escapeHtml(item.name) +
                        "</strong><small>" +
                        escapeHtml(item.id) +
                        " · " +
                        escapeHtml(item.className || "Chưa xếp lớp") +
                        "</small><span>" +
                        escapeHtml(item.email || "Chưa có email") +
                        '</span></div><span class="badge badge-soft-success">Đang học</span></article>'
                    );
                })
                .join("") +
            "</div>"
        );
    }
    function studentList(items) {
        if (!items.length) return empty("Không có học viên phù hợp bộ lọc.");
        return (
            '<div class="app-card table-card"><div class="table-responsive"><table class="table align-middle academic-table"><thead><tr><th>STT</th><th>Học viên</th><th>Mã sinh viên</th><th>Lớp</th><th>Liên hệ</th><th>Trạng thái</th></tr></thead><tbody>' +
            items
                .map(function (item, index) {
                    return (
                        "<tr><td>" +
                        (index + 1) +
                        "</td><td><strong>" +
                        escapeHtml(item.name) +
                        "</strong></td><td>" +
                        escapeHtml(item.id) +
                        "</td><td>" +
                        escapeHtml(item.className) +
                        "</td><td><span>" +
                        escapeHtml(item.email || "—") +
                        "</span><small>" +
                        escapeHtml(item.mobile) +
                        '</small></td><td><span class="badge badge-soft-success">Đang học</span></td></tr>'
                    );
                })
                .join("") +
            "</tbody></table></div></div>"
        );
    }
    function catalog() {
        var term = keyword();
        var years = data.years.filter(function (item) {
                return contains([item.id, item.name], term);
            }),
            sciences = data.sciences.filter(function (item) {
                return contains([item.id, item.name, item.shortName], term);
            }),
            cohorts = data.cohorts.filter(function (item) {
                return contains([item.id, item.name, item.startYear, item.finishYear], term);
            });
        function section(title, subtitle, icon, type, items, itemHtml) {
            return (
                '<section class="app-card mini-catalog"><header><div><strong>' +
                title +
                "</strong><small>" +
                subtitle +
                "</small></div>" +
                (isAdmin
                    ? '<button type="button" data-academic-create="' + type + '"><i class="bi bi-plus"></i></button>'
                    : "") +
                "</header>" +
                items.map(itemHtml).join("") +
                "</section>"
            );
        }
        return (
            '<div class="catalog-sections">' +
            section("Năm học", "Chu kỳ tổ chức đào tạo", "calendar3", "YEAR", years, function (item) {
                return (
                    '<div><span><i class="bi bi-calendar3"></i>' +
                    escapeHtml(item.name) +
                    "</span><small>" +
                    dateText(item.startAt) +
                    " – " +
                    dateText(item.finishAt) +
                    "</small></div>"
                );
            }) +
            section("Khoa", "Đơn vị chuyên môn", "building", "SCIENCE", sciences, function (item) {
                return (
                    '<div><span><i class="bi bi-building"></i>' +
                    escapeHtml(item.name) +
                    "</span><small>" +
                    escapeHtml(item.id) +
                    "</small></div>"
                );
            }) +
            section("Khóa tuyển sinh", "K18, K19...", "mortarboard", "COHORT", cohorts, function (item) {
                return (
                    '<div><span><i class="bi bi-mortarboard"></i>' +
                    escapeHtml(item.name) +
                    "</span><small>" +
                    escapeHtml(item.startYear) +
                    " – " +
                    escapeHtml(item.finishYear) +
                    "</small></div>"
                );
            }) +
            "</div>"
        );
    }

    function render() {
        var result = byId("academicResults");
        if (!result) return;
        var mode = state.viewModes[state.activeTab] || "list";
        if (state.activeTab === "offerings")
            result.innerHTML =
                mode === "cards" ? offeringCards(filteredOfferings()) : offeringList(filteredOfferings());
        else if (state.activeTab === "timetable") result.innerHTML = timetable(filteredTimetables());
        else if (state.activeTab === "classes")
            result.innerHTML = mode === "cards" ? classCards(filteredClasses()) : classList(filteredClasses());
        else if (state.activeTab === "subjects")
            result.innerHTML = mode === "cards" ? subjectCards(filteredSubjects()) : subjectList(filteredSubjects());
        else if (state.activeTab === "students")
            result.innerHTML = mode === "cards" ? studentCards(filteredStudents()) : studentList(filteredStudents());
        else result.innerHTML = catalog();
    }

    function syncToolbar() {
        var meta = labels[state.activeTab];
        byId("academicFilterTitle").textContent = "Lọc " + meta[0];
        byId("academicFilterSubtitle").textContent = meta[1];
        byId("academicKeyword").placeholder = meta[2];
        var offeringFilters = state.activeTab === "offerings" || state.activeTab === "timetable";
        document.querySelector(".academic-filter-year").hidden = !offeringFilters;
        document.querySelector(".academic-filter-semester").hidden = !offeringFilters;
        document.querySelector(".academic-filter-class").hidden = !offeringFilters;
        document.querySelector(".academic-filter-science").hidden = !(
            state.activeTab === "classes" || state.activeTab === "subjects"
        );
        document.querySelector(".academic-filter-student-class").hidden = state.activeTab !== "students";
        var supportsMode = /^(offerings|classes|subjects|students)$/.test(state.activeTab);
        byId("academicViewModeField").hidden = !supportsMode;
        [].forEach.call(document.querySelectorAll("[data-view-mode]"), function (button) {
            button.classList.toggle(
                "active",
                button.getAttribute("data-view-mode") === (state.viewModes[state.activeTab] || "list"),
            );
        });
        [].forEach.call(document.querySelectorAll("[data-academic-tab]"), function (button) {
            button.classList.toggle("active", button.getAttribute("data-academic-tab") === state.activeTab);
        });
    }

    function showModal(id) {
        var modal = byId(id);
        if (modal) {
            modal.hidden = false;
            document.body.classList.add("modal-open");
        }
    }
    function closeModal(id) {
        var modal = byId(id);
        if (modal) modal.hidden = true;
        if (!document.querySelector(".modal-mask:not([hidden])")) document.body.classList.remove("modal-open");
    }
    function resetForm(type) {
        setValue("academicEntityType", type);
        setValue("academicTimetableId", "");
        setValue("academicCode", "");
        setValue("academicName", "");
        setValue("academicParentCode", "");
        setValue("academicCohortId", "");
        setValue("academicStartAt", "");
        setValue("academicFinishAt", "");
        var year = new Date().getFullYear();
        setValue("academicStartYear", year);
        setValue("academicFinishYear", year + 4);
        setValue("academicCreditCount", 3);
        setValue("academicTheoryQuantity", 30);
        setValue("academicPracticeQuantity", 30);
        setValue("academicYearId", "");
        setValue("academicSemester", "");
        setValue("academicClassId", "");
        setValue("academicSubjectId", "");
        setValue("academicTeacherId", "");
        setValue("academicClassSubjectId", "");
        setValue("academicDayOfWeek", "");
        setValue("academicStartPeriod", 1);
        setValue("academicEndPeriod", 3);
        setValue("academicStartTime", "07:00");
        setValue("academicEndTime", "09:30");
        setValue("academicRoomName", "");
        setValue("academicEffectiveFrom", "");
        setValue("academicEffectiveTo", "");
    }
    function fieldGroup(selector, visible) {
        [].forEach.call(document.querySelectorAll(selector), function (item) {
            item.hidden = !visible;
        });
    }
    function syncForm(type) {
        fieldGroup(".academic-form-basic", type !== "CLASS_SUBJECT" && type !== "TIMETABLE");
        fieldGroup(".academic-form-parent", type === "SUBJECT" || type === "CLASS");
        fieldGroup(".academic-form-cohort", type === "CLASS");
        fieldGroup(".academic-form-year-date", type === "YEAR");
        fieldGroup(".academic-form-cohort-year", type === "COHORT");
        fieldGroup(".academic-form-subject-metric", type === "SUBJECT");
        fieldGroup(".academic-form-offering", type === "CLASS_SUBJECT");
        fieldGroup(".academic-form-timetable", type === "TIMETABLE");
        var titles = {
            YEAR: "Thêm năm học",
            SCIENCE: "Thêm khoa",
            COHORT: "Thêm khóa tuyển sinh",
            SUBJECT: "Thêm môn học",
            CLASS: "Thêm lớp hành chính",
            CLASS_SUBJECT: "Mở môn học cho lớp",
            TIMETABLE: value("academicTimetableId") ? "Cập nhật lịch học" : "Thêm lịch học",
        };
        byId("academicFormTitle").textContent = titles[type] || "Thêm danh mục";
    }
    function openCreate(type) {
        if (!isAdmin) return;
        resetForm(type);
        syncForm(type);
        showModal("academicFormModal");
    }
    function openTimetable(id) {
        var item = data.timetables.filter(function (row) {
            return row.id === number(id);
        })[0];
        if (!item) return;
        resetForm("TIMETABLE");
        setValue("academicTimetableId", item.id);
        setValue("academicClassSubjectId", item.classSubjectId);
        setValue("academicDayOfWeek", item.day);
        setValue("academicStartPeriod", item.startPeriod);
        setValue("academicEndPeriod", item.endPeriod);
        setValue("academicStartTime", timeText(item.startTime));
        setValue("academicEndTime", timeText(item.endTime));
        setValue("academicRoomName", item.room);
        setValue("academicEffectiveFrom", text(item.from).slice(0, 10));
        setValue("academicEffectiveTo", text(item.to).slice(0, 10));
        syncForm("TIMETABLE");
        showModal("academicFormModal");
    }
    function openAssign(classId) {
        if (!isAdmin) return;
        var item = data.classes.filter(function (row) {
            return text(row.id) === text(classId);
        })[0];
        if (!item) return;
        state.assignClassId = item.id;
        state.selectedStudents = data.students
            .filter(function (student) {
                return text(student.classId) === text(item.id);
            })
            .map(function (student) {
                return student.userId;
            });
        byId("academicAssignTitle").textContent = item.name;
        setValue("academicStudentSearch", "");
        renderStudentSelect();
        showModal("academicAssignModal");
    }
    function renderStudentSelect() {
        var term = lower(value("academicStudentSearch"));
        var list = data.students.filter(function (student) {
            return !term || contains([student.name, student.id], term);
        });
        byId("academicStudentSelectList").innerHTML = list
            .map(function (student) {
                var selected = state.selectedStudents.indexOf(student.userId) >= 0;
                return (
                    '<label class="' +
                    (selected ? "selected" : "") +
                    '"><input type="checkbox" data-student-id="' +
                    student.userId +
                    '" ' +
                    (selected ? 'checked="checked"' : "") +
                    " /><span><strong>" +
                    escapeHtml(student.name) +
                    "</strong><small>" +
                    escapeHtml(student.id) +
                    " · " +
                    escapeHtml(student.className || "Chưa xếp lớp") +
                    "</small></span></label>"
                );
            })
            .join("");
        byId("academicSelectionCount").textContent = "Đã chọn " + state.selectedStudents.length + " học viên";
    }

    function optional(input) {
        return input === "" || input === null || input === undefined ? null : input;
    }
    function prepareCatalogSubmit() {
        var type = value("academicEntityType");
        var payload = {
            entityType: type,
            dataGroupId: 1,
            code: optional(value("academicCode").trim()),
            name: optional(value("academicName").trim()),
            shortName: null,
            parentCode: optional(value("academicParentCode")),
            startYear: optional(value("academicStartYear")),
            finishYear: optional(value("academicFinishYear")),
            startAt: optional(value("academicStartAt")),
            finishAt: optional(value("academicFinishAt")),
            yearId: optional(value("academicYearId")),
            semester: optional(value("academicSemester")),
            classSubjectId: optional(value("academicClassSubjectId")),
            classId: optional(value("academicClassId")),
            subjectId: type === "CLASS" ? optional(value("academicCohortId")) : optional(value("academicSubjectId")),
            teacherId: optional(value("academicTeacherId")),
            classSize: 40,
            creditCount: number(value("academicCreditCount")),
            theoryQuantity: number(value("academicTheoryQuantity")),
            practiceQuantity: number(value("academicPracticeQuantity")),
            timetableId: optional(value("academicTimetableId")),
            dayOfWeek: optional(value("academicDayOfWeek")),
            startPeriod: optional(value("academicStartPeriod")),
            endPeriod: optional(value("academicEndPeriod")),
            startTime: optional(value("academicStartTime")),
            endTime: optional(value("academicEndTime")),
            roomName: optional(value("academicRoomName").trim()),
            effectiveFrom: optional(value("academicEffectiveFrom")),
            effectiveTo: optional(value("academicEffectiveTo")),
        };
        if (type !== "CLASS_SUBJECT" && type !== "TIMETABLE" && (!payload.code || !payload.name)) {
            window.alert("Mã và tên danh mục không được để trống.");
            return false;
        }
        if (
            type === "CLASS_SUBJECT" &&
            (!payload.yearId || !payload.semester || !payload.classId || !payload.subjectId)
        ) {
            window.alert("Vui lòng chọn năm học, học kỳ, lớp và môn học.");
            return false;
        }
        if (type === "TIMETABLE" && (!payload.classSubjectId || !payload.dayOfWeek)) {
            window.alert("Vui lòng chọn môn học lớp và thứ học.");
            return false;
        }
        setValue("AcademicFormJsonValue", JSON.stringify(payload));
        return true;
    }
    function prepareAssignSubmit() {
        if (!state.assignClassId || !state.selectedStudents.length) {
            window.alert("Vui lòng chọn ít nhất một học viên.");
            return false;
        }
        setValue("AcademicAssignClassIdValue", state.assignClassId);
        setValue("AcademicAssignStudentIdsValue", JSON.stringify(state.selectedStudents));
        return true;
    }

    page.addEventListener("click", function (event) {
        var create = event.target.closest("[data-academic-create]");
        if (create) {
            openCreate(create.getAttribute("data-academic-create"));
            return;
        }
        var close = event.target.closest("[data-academic-close]");
        if (close) {
            closeModal(close.getAttribute("data-academic-close"));
            return;
        }
        var tab = event.target.closest("[data-academic-tab]");
        if (tab) {
            state.activeTab = tab.getAttribute("data-academic-tab");
            window.localStorage.setItem("cms-academic-active-tab", state.activeTab);
            syncToolbar();
            render();
            return;
        }
        var mode = event.target.closest("[data-view-mode]");
        if (mode) {
            state.viewModes[state.activeTab] = mode.getAttribute("data-view-mode");
            window.localStorage.setItem("cms-academic-view-" + state.activeTab, state.viewModes[state.activeTab]);
            syncToolbar();
            render();
            return;
        }
        var edit = event.target.closest("[data-academic-timetable]");
        if (edit) {
            openTimetable(edit.getAttribute("data-academic-timetable"));
            return;
        }
        var assign = event.target.closest("[data-academic-assign]");
        if (assign) {
            openAssign(assign.getAttribute("data-academic-assign"));
            return;
        }
        var student = event.target.closest("[data-student-id]");
        if (student) {
            var id = number(student.getAttribute("data-student-id"));
            var position = state.selectedStudents.indexOf(id);
            if (student.checked && position < 0) state.selectedStudents.push(id);
            if (!student.checked && position >= 0) state.selectedStudents.splice(position, 1);
            renderStudentSelect();
        }
    });
    [
        "academicKeyword",
        "academicYearFilter",
        "academicSemesterFilter",
        "academicClassFilter",
        "academicScienceFilter",
        "academicStudentClassFilter",
    ].forEach(function (id) {
        var element = byId(id);
        if (element) element.addEventListener(id === "academicKeyword" ? "input" : "change", render);
    });
    byId("academicStudentSearch").addEventListener("input", renderStudentSelect);
    [].forEach.call(document.querySelectorAll(".modal-mask"), function (modal) {
        modal.addEventListener("click", function (event) {
            if (event.target === modal) closeModal(modal.id);
        });
    });

    if (!isAdmin) byId("academicAdminActions").hidden = true;
    initOptions();
    syncToolbar();
    render();
    window.AcademicStructurePage = {
        prepareCatalogSubmit: prepareCatalogSubmit,
        prepareAssignSubmit: prepareAssignSubmit,
    };
})(window, document);
