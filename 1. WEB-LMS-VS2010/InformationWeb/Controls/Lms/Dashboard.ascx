<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.ascx.cs" Inherits="InformationWeb.Controls.Lms.Dashboard" %>
<link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/css/pages/lms/dashboard.css") %>" />
<section>
    <div class="welcome app-card mb-4">
        <div>
            <span class="welcome-label">HỌC TẬP MỖI NGÀY</span>
            <h1><asp:Literal ID="PageTitleText" runat="server" /></h1>
            <p><asp:Literal ID="PageDescriptionText" runat="server" /></p>
            <asp:HyperLink ID="ContinueButton" runat="server" CssClass="btn btn-brand">
                Tiếp tục học
                <i class="bi bi-arrow-right ms-1"></i>
            </asp:HyperLink>
        </div>
        <div class="goal">
            <span class="goal-ring">
                <asp:Literal ID="RecentProgressText" runat="server" />
                <small>%</small>
            </span>
            <div>
                <strong>Tiến độ gần nhất</strong>
                <small><asp:Literal ID="RecentCourseTitleText" runat="server" /></small>
            </div>
        </div>
    </div>
    <asp:Button ID="RefreshButton" runat="server" Text="Làm mới" CssClass="d-none" OnClick="RefreshButton_Click" />
    <asp:Label ID="ErrorText" runat="server" CssClass="alert alert-danger status-message" Visible="false" />
    <div class="row g-3 mb-4">
        <div class="col-6 col-lg-3">
            <div class="stat app-card">
                <span class="stat-icon green"><i class="bi bi-journal-play"></i></span>
                <div>
                    <strong><asp:Literal ID="ActiveCourseCountText" runat="server" /></strong>
                    <small>Môn học đang học</small>
                </div>
            </div>
        </div>
        <div class="col-6 col-lg-3">
            <div class="stat app-card">
                <span class="stat-icon blue"><i class="bi bi-check2-circle"></i></span>
                <div>
                    <strong><asp:Literal ID="CompletedLessonCountText" runat="server" /></strong>
                    <small>Bài học hoàn thành</small>
                </div>
            </div>
        </div>
        <div class="col-6 col-lg-3">
            <div class="stat app-card">
                <span class="stat-icon yellow"><i class="bi bi-star"></i></span>
                <div>
                    <strong><asp:Literal ID="AverageScoreText" runat="server" /></strong>
                    <small>Điểm trung bình</small>
                </div>
            </div>
        </div>
        <div class="col-6 col-lg-3">
            <div class="stat app-card">
                <span class="stat-icon red"><i class="bi bi-clock"></i></span>
                <div>
                    <strong><asp:Literal ID="LearningTimeText" runat="server" /></strong>
                    <small>Thời gian học</small>
                </div>
            </div>
        </div>
    </div>
    <div class="d-flex justify-content-between align-items-end mb-3">
        <div>
            <h2 class="h4 fw-bold mb-1">Tiếp tục học</h2>
            <span class="page-subtitle">Môn học bạn truy cập gần đây</span>
        </div>
        <a class="text-brand fw-semibold small" href="<%= ResolveUrl("~/lms/courses") %>">
            Xem tất cả
            <i class="bi bi-arrow-right"></i>
        </a>
    </div>
    <div class="row g-4">
        <asp:Repeater ID="CourseRepeater" runat="server">
            <ItemTemplate>
                <div class="col-lg-6">
                    <article class="course app-card">
                        <div class="course-cover">
                            <i class="bi bi-code-slash"></i>
                            <span><%# Html(Eval("Code")) %></span>
                        </div>
                        <div class="p-3 flex-grow-1">
                            <span class="badge badge-soft-success mb-2">Môn học lớp</span>
                            <h3><%# Html(Eval("Title")) %></h3>
                            <div class="small text-secondary mb-3">
                                <i class="bi bi-person me-1"></i>
                                <%# Html(Eval("TeacherName")) %>
                            </div>
                            <div class="d-flex justify-content-between small mb-1">
                                <span>Tiến độ</span>
                                <b><%# Html(Eval("ProgressPercent")) %>%</b>
                            </div>
                            <div class="progress course-progress mb-3">
                                <div class="progress-bar" style='<%# "width:" + Html(Eval("ProgressPercent")) + "%" %>'></div>
                            </div>
                            <a class="btn btn-action-view btn-sm" href='<%# CourseUrl(Eval("Id"), Eval("ContinueLessonId")) %>'>
                                <i class="bi bi-arrow-right-circle"></i>
                                Mở môn học
                            </a>
                        </div>
                    </article>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <asp:Label
        ID="EmptyText"
        runat="server"
        CssClass="app-card empty-state"
        Text="Bạn chưa được phân vào môn học lớp nào."
        Visible="false"
    />
</section>
