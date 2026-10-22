<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.ascx.cs" Inherits="InformationWeb.Controls.Cms.Dashboard" %>
<link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/css/pages/cms/dashboard.css") %>" />
<section>
    <header class="d-flex flex-wrap justify-content-between align-items-end gap-3 mb-4">
        <div>
            <h1 class="page-title mb-1">Tổng quan hệ thống</h1>
            <p class="page-subtitle mb-0">Số liệu mới nhất được tổng hợp trực tiếp từ SQL Server.</p>
        </div>
        <div class="cms-page-actions">
            <asp:Button ID="RefreshButton" runat="server" Text="Làm mới" CssClass="btn btn-action-refresh" OnClick="RefreshButton_Click" />
        </div>
    </header>
    <asp:Label ID="ErrorText" runat="server" CssClass="alert alert-danger status-message" Visible="false" />
    <div class="row g-3 mb-4">
        <div class="col-6 col-xl-3">
            <div class="stat app-card">
                <div>
                    <span>Tổng khóa học</span>
                    <strong><asp:Literal ID="TotalCoursesText" runat="server" /></strong>
                    <small>Trong cơ sở dữ liệu</small>
                </div>
                <i class="bi bi-journals green"></i>
            </div>
        </div>
        <div class="col-6 col-xl-3">
            <div class="stat app-card">
                <div>
                    <span>Tổng học viên</span>
                    <strong><asp:Literal ID="TotalStudentsText" runat="server" /></strong>
                    <small>Tài khoản học viên</small>
                </div>
                <i class="bi bi-people blue"></i>
            </div>
        </div>
        <div class="col-6 col-xl-3">
            <div class="stat app-card">
                <div>
                    <span>Tổng bài học</span>
                    <strong><asp:Literal ID="TotalLessonsText" runat="server" /></strong>
                    <small>Nội dung đang quản lý</small>
                </div>
                <i class="bi bi-list-task yellow"></i>
            </div>
        </div>
        <div class="col-6 col-xl-3">
            <div class="stat app-card">
                <div>
                    <span>Điểm trung bình</span>
                    <strong><asp:Literal ID="AverageScoreText" runat="server" /></strong>
                    <small>Từ kết quả học tập</small>
                </div>
                <i class="bi bi-star red"></i>
            </div>
        </div>
    </div>
    <div class="row g-4">
        <div class="col-xl-8">
            <div class="app-card p-4 h-100">
                <div class="d-flex justify-content-between mb-3">
                    <div>
                        <h2 class="h5 fw-bold mb-1">Khóa học trong hệ thống</h2>
                        <small class="text-secondary">Dữ liệu thật về bài học và học viên ghi danh</small>
                    </div>
                    <a class="small text-brand fw-bold" href="<%= ResolveUrl("~/cms/courses") %>">Quản lý khóa học</a>
                </div>
                <asp:Label ID="EmptyText" runat="server" CssClass="empty-state" Text="Chưa có khóa học." Visible="false" />
                <div class="table-responsive">
                    <asp:GridView ID="DataGrid" runat="server" CssClass="table align-middle mb-0" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="Khóa học">
                                <ItemTemplate>
                                    <strong><%# Eval("Title") %></strong>
                                    <small class="d-block text-secondary"><%# Eval("Code") %></small>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="TeacherName" HeaderText="Giảng viên" />
                            <asp:BoundField DataField="LessonCount" HeaderText="Bài học" />
                            <asp:BoundField DataField="StudentCount" HeaderText="Học viên" />
                            <asp:TemplateField HeaderText="Trạng thái">
                                <ItemTemplate><span class='<%# "badge " + CourseStatusClass(Eval("Status")) %>'><%# CourseStatusLabel(Eval("Status")) %></span></ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="col-xl-4">
            <div class="app-card p-4 mb-4">
                <h2 class="h5 fw-bold">Chất lượng học tập</h2>
                <div class="metric">
                    <span>Tỷ lệ hoàn thành</span>
                    <strong>
                        <asp:Literal ID="CompletionRateText" runat="server" />
                        %
                    </strong>
                    <div class="progress"><div id="completionRateBar" runat="server" class="progress-bar"></div></div>
                </div>
                <div class="metric">
                    <span>Điểm trung bình</span>
                    <strong><asp:Literal ID="QualityAverageScoreText" runat="server" /></strong>
                </div>
            </div>
            <div class="app-card p-4">
                <h2 class="h5 fw-bold">Kho nội dung</h2>
                <div class="content-counts">
                    <span>
                        <i class="bi bi-play-btn"></i>
                        <strong><asp:Literal ID="TotalVideosText" runat="server" /></strong>
                        <small>Video</small>
                    </span>
                    <span>
                        <i class="bi bi-patch-question"></i>
                        <strong><asp:Literal ID="TotalQuestionsText" runat="server" /></strong>
                        <small>Câu hỏi</small>
                    </span>
                    <span>
                        <i class="bi bi-person-video3"></i>
                        <strong><asp:Literal ID="TotalTeachersText" runat="server" /></strong>
                        <small>Giảng viên</small>
                    </span>
                </div>
            </div>
        </div>
    </div>
</section>
