<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.ascx.cs" Inherits="InformationWeb.Controls.Cms.Dashboard" %>
<section>
    <header class="page-header">
        <div>
            <h1 class="page-title">Tổng quan hệ thống</h1>
            <p class="page-subtitle">Số liệu mới nhất được tổng hợp trực tiếp từ SQL Server.</p>
        </div>
        <div class="page-actions">
            <asp:Button ID="RefreshButton" runat="server" Text="Làm mới" CssClass="btn btn-secondary" OnClick="RefreshButton_Click" />
        </div>
    </header>
    <asp:Label ID="ErrorText" runat="server" CssClass="alert alert-danger" Visible="false" />
    <div class="grid grid-4 gap-4 mb-4">
        <div class="stat-card stat-card-primary">
            <div class="stat-card-icon">
                <i class="bi bi-journals"></i>
            </div>
            <div class="stat-card-content">
                <span class="stat-card-label">Tổng khóa học</span>
                <strong class="stat-card-value"><asp:Literal ID="TotalCoursesText" runat="server" /></strong>
                <small class="stat-card-desc">Trong cơ sở dữ liệu</small>
            </div>
        </div>
        <div class="stat-card stat-card-success">
            <div class="stat-card-icon">
                <i class="bi bi-people"></i>
            </div>
            <div class="stat-card-content">
                <span class="stat-card-label">Tổng học viên</span>
                <strong class="stat-card-value"><asp:Literal ID="TotalStudentsText" runat="server" /></strong>
                <small class="stat-card-desc">Tài khoản học viên</small>
            </div>
        </div>
        <div class="stat-card stat-card-warning">
            <div class="stat-card-icon">
                <i class="bi bi-list-task"></i>
            </div>
            <div class="stat-card-content">
                <span class="stat-card-label">Tổng bài học</span>
                <strong class="stat-card-value"><asp:Literal ID="TotalLessonsText" runat="server" /></strong>
                <small class="stat-card-desc">Nội dung đang quản lý</small>
            </div>
        </div>
        <div class="stat-card stat-card-danger">
            <div class="stat-card-icon">
                <i class="bi bi-star"></i>
            </div>
            <div class="stat-card-content">
                <span class="stat-card-label">Điểm trung bình</span>
                <strong class="stat-card-value"><asp:Literal ID="AverageScoreText" runat="server" /></strong>
                <small class="stat-card-desc">Từ kết quả học tập</small>
            </div>
        </div>
    </div>
    <div class="grid grid-2-1 gap-4">
        <div class="card">
            <div class="card-header">
                <div>
                    <h2 class="card-title">Khóa học trong hệ thống</h2>
                    <small class="card-subtitle">Dữ liệu thật về bài học và học viên ghi danh</small>
                </div>
                <a class="btn btn-link" href="<%= ResolveUrl("~/cms/courses") %>">Quản lý khóa học</a>
            </div>
            <asp:Label ID="EmptyText" runat="server" CssClass="empty-state" Text="Chưa có khóa học." Visible="false" />
            <div class="table-container">
                <asp:GridView ID="DataGrid" runat="server" CssClass="lms-table" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField HeaderText="Khóa học">
                            <ItemTemplate>
                                <strong><%# Eval("Title") %></strong>
                                <small class="d-block text-muted"><%# Eval("Code") %></small>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="TeacherName" HeaderText="Giảng viên" />
                        <asp:BoundField DataField="LessonCount" HeaderText="Bài học" />
                        <asp:BoundField DataField="StudentCount" HeaderText="Học viên" />
                        <asp:TemplateField HeaderText="Trạng thái">
                            <ItemTemplate><span class='<%# "badge badge-" + CourseStatusClass(Eval("Status")) %>'><%# CourseStatusLabel(Eval("Status")) %></span></ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="card card-full">
            <div class="card card-default mb-4">
                <h2 class="card-title">Chất lượng học tập</h2>
                <div class="metric-item">
                    <span class="metric-label">Tỷ lệ hoàn thành</span>
                    <strong class="metric-value">
                        <asp:Literal ID="CompletionRateText" runat="server" />
                        %
                    </strong>
                    <div class="progress"><div id="completionRateBar" runat="server" class="progress-bar"></div></div>
                </div>
                <div class="metric-item">
                    <span class="metric-label">Điểm trung bình</span>
                    <strong class="metric-value"><asp:Literal ID="QualityAverageScoreText" runat="server" /></strong>
                </div>
            </div>
            <div class="card card-default">
                <h2 class="card-title">Kho nội dung</h2>
                <div class="content-counts">
                    <span class="content-count-item">
                        <i class="bi bi-play-btn"></i>
                        <strong><asp:Literal ID="TotalVideosText" runat="server" /></strong>
                        <small>Video</small>
                    </span>
                    <span class="content-count-item">
                        <i class="bi bi-patch-question"></i>
                        <strong><asp:Literal ID="TotalQuestionsText" runat="server" /></strong>
                        <small>Câu hỏi</small>
                    </span>
                    <span class="content-count-item">
                        <i class="bi bi-person-video3"></i>
                        <strong><asp:Literal ID="TotalTeachersText" runat="server" /></strong>
                        <small>Giảng viên</small>
                    </span>
                </div>
            </div>
        </div>
    </div>
</section>
