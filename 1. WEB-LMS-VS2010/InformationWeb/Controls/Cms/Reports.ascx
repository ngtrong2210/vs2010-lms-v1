<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Reports.ascx.cs" Inherits="InformationWeb.Controls.Cms.Reports" %>
<link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/css/pages/cms/reports.css") %>" />
<section>
    <header class="d-flex flex-wrap justify-content-between align-items-end gap-3 mb-4">
        <div>
            <h1 class="page-title mb-1"><asp:Literal ID="PageTitleText" runat="server" /></h1>
            <p class="page-subtitle mb-0"><asp:Literal ID="PageDescriptionText" runat="server" /></p>
        </div>
        <div class="cms-page-actions">
            <button type="button" class="btn btn-action-export" onclick="window.print()">
                <i class="bi bi-file-earmark-excel"></i>
                Xuất báo cáo
            </button>
        </div>
    </header>
    <div class="row g-3 mb-4" aria-label="Loại báo cáo">
        <div class="col-md-6 col-xl">
            <button type="button" class="report-card app-card" data-report-type="CourseOverview">
                <i class="bi bi-journal-text"></i>
                <span>Tổng quan khóa học</span>
            </button>
        </div>
        <div class="col-md-6 col-xl">
            <button type="button" class="report-card app-card" data-report-type="StudentProgress">
                <i class="bi bi-people"></i>
                <span>Tiến độ học viên</span>
            </button>
        </div>
        <div class="col-md-6 col-xl">
            <button type="button" class="report-card app-card" data-report-type="LessonCompletion">
                <i class="bi bi-check2-square"></i>
                <span>Hoàn thành bài học</span>
            </button>
        </div>
        <div class="col-md-6 col-xl">
            <button type="button" class="report-card app-card" data-report-type="QuestionPerformance">
                <i class="bi bi-patch-question"></i>
                <span>Hiệu quả câu hỏi</span>
            </button>
        </div>
        <div class="col-md-6 col-xl">
            <button type="button" class="report-card app-card" data-report-type="VideoEngagement">
                <i class="bi bi-play-btn"></i>
                <span>Tương tác video</span>
            </button>
        </div>
    </div>
    <div class="app-card p-4">
        <div class="d-flex flex-wrap justify-content-between align-items-end gap-3 mb-4">
            <div>
                <h2 id="activeReportTitle" class="h5 fw-bold mb-1">Tổng quan khóa học</h2>
                <small class="text-secondary">Dữ liệu được lấy trực tiếp từ SQL Server theo loại đang chọn.</small>
            </div>
            <div class="d-flex flex-wrap gap-2">
                <asp:TextBox ID="SearchText" runat="server" CssClass="d-none" />
                <asp:DropDownList ID="ReportTypeList" runat="server" CssClass="form-select" ClientIDMode="Static">
                    <asp:ListItem Value="CourseOverview" Selected="True">Tổng quan khóa học</asp:ListItem>
                    <asp:ListItem Value="StudentProgress">Tiến độ học viên</asp:ListItem>
                    <asp:ListItem Value="LessonCompletion">Hoàn thành bài học</asp:ListItem>
                    <asp:ListItem Value="QuestionPerformance">Hiệu quả câu hỏi</asp:ListItem>
                    <asp:ListItem Value="VideoEngagement">Tương tác video</asp:ListItem>
                </asp:DropDownList>
                <asp:Button
                    ID="SearchButton"
                    runat="server"
                    Text="Nạp báo cáo"
                    CssClass="btn btn-action-filter"
                    OnClick="SearchButton_Click"
                    ClientIDMode="Static"
                />
            </div>
        </div>
        <div class="report-placeholder mb-4">
            <i class="bi bi-bar-chart-line"></i>
            <strong id="activeReportChartTitle">Biểu đồ Tổng quan khóa học</strong>
            <span>Dữ liệu chi tiết được tổng hợp theo bộ lọc đang chọn.</span>
            <div class="bars">
                <i style="height: 47%"></i>
                <i style="height: 64%"></i>
                <i style="height: 81%"></i>
                <i style="height: 33%"></i>
                <i style="height: 50%"></i>
                <i style="height: 67%"></i>
                <i style="height: 84%"></i>
                <i style="height: 36%"></i>
                <i style="height: 53%"></i>
                <i style="height: 70%"></i>
                <i style="height: 87%"></i>
                <i style="height: 39%"></i>
            </div>
        </div>
        <asp:Label ID="ErrorText" runat="server" CssClass="alert alert-danger" Visible="false" />
        <asp:Label ID="EmptyText" runat="server" CssClass="empty-state" Text="Chưa có số liệu." Visible="false" />
        <div class="table-responsive">
            <asp:GridView
                ID="DataGrid"
                runat="server"
                CssClass="table align-middle mb-0"
                AutoGenerateColumns="true"
                AllowPaging="true"
                PageSize="50"
                OnPageIndexChanging="DataGrid_PageIndexChanging"
            />
        </div>
    </div>
</section>
<script src="<%= ResolveUrl("~/assets/lms/js/reports-webforms.js") %>"></script>
