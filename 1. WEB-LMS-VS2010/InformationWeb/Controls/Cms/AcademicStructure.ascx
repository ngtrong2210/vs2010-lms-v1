<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AcademicStructure.ascx.cs" Inherits="InformationWeb.Controls.Cms.AcademicStructure" %>
<link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/css/pages/cms/academic-structure.css") %>" />
<link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/css/pages/cms/academic-timetable.css") %>" />
<link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/css/pages/cms/academic-dialogs.css") %>" />
<link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/css/pages/cms/academic-webforms.css") %>" />
<section id="academicPage" class="academic-page">
    <header class="academic-heading">
        <div>
            <span class="eyebrow">CƠ CẤU ĐÀO TẠO</span>
            <h1 class="page-title">Khóa · Khoa · Lớp · Môn học</h1>
            <p class="page-subtitle"><asp:Literal ID="PageDescriptionText" runat="server" /></p>
            <span class="d-none"><asp:Literal ID="PageTitleText" runat="server" /></span>
        </div>
        <div id="academicAdminActions" class="cms-page-actions">
            <button type="button" class="btn btn-action-create" data-academic-create="CLASS_SUBJECT">
                <i class="bi bi-calendar2-plus"></i>
                Mở môn cho lớp
            </button>
        </div>
    </header>
    <asp:Label ID="ActionMessageText" runat="server" Visible="false" />
    <asp:Label ID="ErrorText" runat="server" CssClass="alert alert-danger" Visible="false" />
    <asp:Label ID="EmptyText" runat="server" CssClass="empty-state" Text="Chưa có dữ liệu." Visible="false" />

    <div class="app-card academic-toolbar">
        <div class="toolbar-title">
            <i class="bi bi-funnel"></i>
            <div>
                <strong id="academicFilterTitle">Lọc môn học lớp</strong>
                <small id="academicFilterSubtitle">Thu hẹp theo từ khóa, năm học, học kỳ và lớp hành chính</small>
            </div>
        </div>
        <label class="keyword-filter">
            <span>Tìm nhanh</span>
            <div class="filter-search">
                <i class="bi bi-search"></i>
                <input id="academicKeyword" class="form-control" placeholder="Tên môn, mã môn, lớp hoặc giảng viên..." />
            </div>
        </label>
        <label class="academic-filter academic-filter-year">
            <span>Năm học</span>
            <select id="academicYearFilter" class="form-select">
                <option value="">Tất cả năm học</option>
            </select>
        </label>
        <label class="academic-filter academic-filter-semester">
            <span>Học kỳ</span>
            <select id="academicSemesterFilter" class="form-select">
                <option value="">Tất cả học kỳ</option>
                <option value="1">Học kỳ 1</option>
                <option value="2">Học kỳ 2</option>
                <option value="3">Học kỳ hè</option>
            </select>
        </label>
        <label class="academic-filter academic-filter-class">
            <span>Lớp</span>
            <select id="academicClassFilter" class="form-select">
                <option value="">Tất cả lớp</option>
            </select>
        </label>
        <label class="academic-filter academic-filter-science" hidden="hidden">
            <span>Khoa</span>
            <select id="academicScienceFilter" class="form-select">
                <option value="">Tất cả khoa</option>
            </select>
        </label>
        <label class="academic-filter academic-filter-student-class" hidden="hidden">
            <span>Lớp</span>
            <select id="academicStudentClassFilter" class="form-select">
                <option value="">Tất cả lớp</option>
            </select>
        </label>
        <div id="academicViewModeField" class="view-mode-field">
            <span>Hiển thị</span>
            <div class="view-mode-switch" role="group" aria-label="Chế độ hiển thị">
                <button type="button" data-view-mode="list" class="active">
                    <i class="bi bi-list-ul"></i>
                    <span>Danh sách</span>
                </button>
                <button type="button" data-view-mode="cards">
                    <i class="bi bi-grid"></i>
                    <span>Dạng thẻ</span>
                </button>
            </div>
        </div>
    </div>

    <nav class="academic-tabs" aria-label="Nhóm dữ liệu đào tạo">
        <button type="button" class="academic-tab academic-tab-offerings active" data-academic-tab="offerings">
            <i class="bi bi-calendar2-week"></i>
            Môn học lớp
            <span id="academicCountOfferings">0</span>
        </button>
        <button type="button" class="academic-tab academic-tab-timetable" data-academic-tab="timetable">
            <i class="bi bi-clock-history"></i>
            Thời khóa biểu
            <span id="academicCountTimetables">0</span>
        </button>
        <button type="button" class="academic-tab academic-tab-classes" data-academic-tab="classes">
            <i class="bi bi-people"></i>
            Lớp
            <span id="academicCountClasses">0</span>
        </button>
        <button type="button" class="academic-tab academic-tab-subjects" data-academic-tab="subjects">
            <i class="bi bi-book"></i>
            Môn học
            <span id="academicCountSubjects">0</span>
        </button>
        <button type="button" class="academic-tab academic-tab-students" data-academic-tab="students">
            <i class="bi bi-person-badge"></i>
            Học viên
            <span id="academicCountStudents">0</span>
        </button>
        <button type="button" class="academic-tab academic-tab-catalog" data-academic-tab="catalog">
            <i class="bi bi-diagram-3"></i>
            Danh mục gốc
            <span id="academicCountCatalog">0</span>
        </button>
    </nav>
    <div id="academicResults"></div>

    <div id="academicFormModal" class="modal-mask" hidden="hidden">
        <section class="app-card academic-modal" role="dialog" aria-modal="true" aria-labelledby="academicFormTitle">
            <div class="modal-heading">
                <div>
                    <small>Danh mục đào tạo</small>
                    <h2 id="academicFormTitle">Thêm danh mục</h2>
                </div>
                <button type="button" class="btn-close" data-academic-close="academicFormModal" aria-label="Đóng"></button>
            </div>
            <input id="academicEntityType" type="hidden" value="CLASS_SUBJECT" />
            <input id="academicTimetableId" type="hidden" />
            <div class="row g-3">
                <div class="col-md-5 academic-form-basic">
                    <label class="form-label">Mã</label>
                    <input id="academicCode" class="form-control" />
                </div>
                <div class="col-md-7 academic-form-basic">
                    <label class="form-label">Tên hiển thị</label>
                    <input id="academicName" class="form-control" />
                </div>
                <div class="col-md-6 academic-form-parent">
                    <label class="form-label">Khoa</label>
                    <select id="academicParentCode" class="form-select">
                        <option value="">Chọn khoa</option>
                    </select>
                </div>
                <div class="col-md-6 academic-form-cohort">
                    <label class="form-label">Khóa tuyển sinh</label>
                    <select id="academicCohortId" class="form-select">
                        <option value="">Chọn khóa</option>
                    </select>
                </div>
                <div class="col-md-6 academic-form-year-date">
                    <label class="form-label">Bắt đầu</label>
                    <input id="academicStartAt" class="form-control" type="date" />
                </div>
                <div class="col-md-6 academic-form-year-date">
                    <label class="form-label">Kết thúc</label>
                    <input id="academicFinishAt" class="form-control" type="date" />
                </div>
                <div class="col-md-6 academic-form-cohort-year">
                    <label class="form-label">Năm bắt đầu</label>
                    <input id="academicStartYear" class="form-control" type="number" />
                </div>
                <div class="col-md-6 academic-form-cohort-year">
                    <label class="form-label">Năm kết thúc</label>
                    <input id="academicFinishYear" class="form-control" type="number" />
                </div>
                <div class="col-md-4 academic-form-subject-metric">
                    <label class="form-label">Tín chỉ</label>
                    <input id="academicCreditCount" class="form-control" type="number" min="0" value="3" />
                </div>
                <div class="col-md-4 academic-form-subject-metric">
                    <label class="form-label">Tiết lý thuyết</label>
                    <input id="academicTheoryQuantity" class="form-control" type="number" min="0" value="30" />
                </div>
                <div class="col-md-4 academic-form-subject-metric">
                    <label class="form-label">Tiết thực hành</label>
                    <input id="academicPracticeQuantity" class="form-control" type="number" min="0" value="30" />
                </div>
                <div class="col-md-6 academic-form-offering">
                    <label class="form-label">Năm học</label>
                    <select id="academicYearId" class="form-select">
                        <option value="">Chọn năm</option>
                    </select>
                </div>
                <div class="col-md-6 academic-form-offering">
                    <label class="form-label">Học kỳ</label>
                    <select id="academicSemester" class="form-select">
                        <option value="">Chọn học kỳ</option>
                        <option value="1">Học kỳ 1</option>
                        <option value="2">Học kỳ 2</option>
                        <option value="3">Học kỳ hè</option>
                    </select>
                </div>
                <div class="col-md-6 academic-form-offering">
                    <label class="form-label">Lớp</label>
                    <select id="academicClassId" class="form-select">
                        <option value="">Chọn lớp</option>
                    </select>
                </div>
                <div class="col-md-6 academic-form-offering">
                    <label class="form-label">Môn học</label>
                    <select id="academicSubjectId" class="form-select">
                        <option value="">Chọn môn</option>
                    </select>
                </div>
                <div class="col-12 academic-form-offering">
                    <label class="form-label">Giảng viên</label>
                    <select id="academicTeacherId" class="form-select">
                        <option value="">Chưa phân công</option>
                    </select>
                </div>
                <div class="col-12 academic-form-timetable">
                    <label class="form-label">Môn học lớp</label>
                    <select id="academicClassSubjectId" class="form-select">
                        <option value="">Chọn môn học lớp</option>
                    </select>
                </div>
                <div class="col-md-4 academic-form-timetable">
                    <label class="form-label">Thứ</label>
                    <select id="academicDayOfWeek" class="form-select">
                        <option value="">Chọn thứ</option>
                        <option value="2">Thứ Hai</option>
                        <option value="3">Thứ Ba</option>
                        <option value="4">Thứ Tư</option>
                        <option value="5">Thứ Năm</option>
                        <option value="6">Thứ Sáu</option>
                        <option value="7">Thứ Bảy</option>
                        <option value="8">Chủ nhật</option>
                    </select>
                </div>
                <div class="col-md-4 academic-form-timetable">
                    <label class="form-label">Tiết bắt đầu</label>
                    <input id="academicStartPeriod" class="form-control" type="number" min="1" max="30" value="1" />
                </div>
                <div class="col-md-4 academic-form-timetable">
                    <label class="form-label">Tiết kết thúc</label>
                    <input id="academicEndPeriod" class="form-control" type="number" min="1" max="30" value="3" />
                </div>
                <div class="col-md-4 academic-form-timetable">
                    <label class="form-label">Giờ bắt đầu</label>
                    <input id="academicStartTime" class="form-control" type="time" value="07:00" />
                </div>
                <div class="col-md-4 academic-form-timetable">
                    <label class="form-label">Giờ kết thúc</label>
                    <input id="academicEndTime" class="form-control" type="time" value="09:30" />
                </div>
                <div class="col-md-4 academic-form-timetable">
                    <label class="form-label">Phòng học</label>
                    <input id="academicRoomName" class="form-control" placeholder="Ví dụ: LAB.02" />
                </div>
                <div class="col-md-6 academic-form-timetable">
                    <label class="form-label">Hiệu lực từ ngày</label>
                    <input id="academicEffectiveFrom" class="form-control" type="date" />
                </div>
                <div class="col-md-6 academic-form-timetable">
                    <label class="form-label">Hiệu lực đến ngày</label>
                    <input id="academicEffectiveTo" class="form-control" type="date" />
                </div>
            </div>
            <div class="modal-actions">
                <button type="button" class="btn btn-action-cancel" data-academic-close="academicFormModal">
                    <i class="bi bi-x-lg"></i>
                    Hủy
                </button>
                <asp:Button
                    ID="AcademicSaveButton"
                    runat="server"
                    Text="Lưu danh mục"
                    CssClass="btn btn-action-save"
                    OnClick="AcademicSaveButton_Click"
                    OnClientClick="return AcademicStructurePage.prepareCatalogSubmit();"
                />
            </div>
        </section>
    </div>

    <div id="academicAssignModal" class="modal-mask" hidden="hidden">
        <section class="app-card academic-modal assign-modal" role="dialog" aria-modal="true" aria-labelledby="academicAssignTitle">
            <div class="modal-heading">
                <div>
                    <small>Phân học viên</small>
                    <h2 id="academicAssignTitle">Lớp</h2>
                    <p>Chọn nhiều học viên; hệ thống tự ghi danh các môn LMS của lớp.</p>
                </div>
                <button type="button" class="btn-close" data-academic-close="academicAssignModal" aria-label="Đóng"></button>
            </div>
            <label class="search-students">
                <i class="bi bi-search"></i>
                <input id="academicStudentSearch" placeholder="Tìm theo tên hoặc mã sinh viên..." />
            </label>
            <div id="academicStudentSelectList" class="student-select-list"></div>
            <div class="modal-actions">
                <span id="academicSelectionCount" class="selection-count">Đã chọn 0 học viên</span>
                <button type="button" class="btn btn-action-cancel" data-academic-close="academicAssignModal">Hủy</button>
                <asp:Button
                    ID="AcademicAssignButton"
                    runat="server"
                    Text="Phân vào lớp"
                    CssClass="btn btn-action-save"
                    OnClick="AcademicAssignButton_Click"
                    OnClientClick="return AcademicStructurePage.prepareAssignSubmit();"
                />
            </div>
        </section>
    </div>

    <asp:HiddenField ID="AcademicCatalogJsonValue" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="AcademicFormJsonValue" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="AcademicAssignClassIdValue" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="AcademicAssignStudentIdsValue" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="AcademicIsAdminValue" runat="server" ClientIDMode="Static" />
    <asp:TextBox ID="SearchText" runat="server" CssClass="d-none" />
    <asp:Button ID="SearchButton" runat="server" Text="Cập nhật dữ liệu" CssClass="d-none" OnClick="SearchButton_Click" />
    <div class="d-none" aria-hidden="true">
        <asp:GridView ID="DataGrid" runat="server" AutoGenerateColumns="true" />
        <asp:GridView ID="YearsGrid" runat="server" AutoGenerateColumns="true" />
        <asp:GridView ID="SciencesGrid" runat="server" AutoGenerateColumns="true" />
        <asp:GridView ID="CohortsGrid" runat="server" AutoGenerateColumns="true" />
        <asp:GridView ID="ClassesGrid" runat="server" AutoGenerateColumns="true" />
        <asp:GridView ID="SubjectsGrid" runat="server" AutoGenerateColumns="true" />
        <asp:GridView ID="TeachersGrid" runat="server" AutoGenerateColumns="true" />
        <asp:GridView ID="StudentsGrid" runat="server" AutoGenerateColumns="true" />
        <asp:GridView ID="ClassSubjectsGrid" runat="server" AutoGenerateColumns="true" />
        <asp:GridView ID="TimetablesGrid" runat="server" AutoGenerateColumns="true" />
    </div>
</section>
<script src="<%= ResolveUrl("~/assets/lms/js/academic-webforms.js") %>"></script>
