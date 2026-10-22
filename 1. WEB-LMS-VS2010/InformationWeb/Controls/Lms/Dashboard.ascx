<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.ascx.cs" Inherits="InformationWeb.Controls.Lms.Dashboard" %>
<section>
    <div class="welcome-card mb-4">
        <div class="welcome-content">
            <span class="welcome-badge">HỌC TẬP MỖI NGÀY</span>
            <h1><asp:Literal ID="PageTitleText" runat="server" /></h1>
            <p><asp:Literal ID="PageDescriptionText" runat="server" /></p>
            <asp:HyperLink ID="ContinueButton" runat="server" CssClass="btn btn-primary">
                Tiếp tục học
                <i class="bi bi-arrow-right"></i>
            </asp:HyperLink>
        </div>
        <div class="welcome-progress">
            <div class="progress-ring">
                <asp:Literal ID="RecentProgressText" runat="server" />
                <small>%</small>
            </div>
            <div>
                <strong>Tiến độ gần nhất</strong>
                <small><asp:Literal ID="RecentCourseTitleText" runat="server" /></small>
            </div>
        </div>
    </div>
    <asp:Button ID="RefreshButton" runat="server" Text="Làm mới" CssClass="d-none" OnClick="RefreshButton_Click" />
    <asp:Label ID="ErrorText" runat="server" CssClass="alert alert-danger" Visible="false" />
    <div class="grid grid-4 gap-4 mb-4">
        <div class="stat-card stat-card-primary">
            <div class="stat-card-icon">
                <i class="bi bi-journal-play"></i>
            </div>
            <div class="stat-card-content">
                <span class="stat-card-label">Môn học đang học</span>
                <strong class="stat-card-value"><asp:Literal ID="ActiveCourseCountText" runat="server" /></strong>
            </div>
        </div>
        <div class="stat-card stat-card-success">
            <div class="stat-card-icon">
                <i class="bi bi-check2-circle"></i>
            </div>
            <div class="stat-card-content">
                <span class="stat-card-label">Bài học hoàn thành</span>
                <strong class="stat-card-value"><asp:Literal ID="CompletedLessonCountText" runat="server" /></strong>
            </div>
        </div>
        <div class="stat-card stat-card-warning">
            <div class="stat-card-icon">
                <i class="bi bi-star"></i>
            </div>
            <div class="stat-card-content">
                <span class="stat-card-label">Điểm trung bình</span>
                <strong class="stat-card-value"><asp:Literal ID="AverageScoreText" runat="server" /></strong>
            </div>
        </div>
        <div class="stat-card stat-card-danger">
            <div class="stat-card-icon">
                <i class="bi bi-clock"></i>
            </div>
            <div class="stat-card-content">
                <span class="stat-card-label">Thời gian học</span>
                <strong class="stat-card-value"><asp:Literal ID="LearningTimeText" runat="server" /></strong>
            </div>
        </div>
    </div>
    <div class="section-header mb-3">
        <div>
            <h2 class="section-title">Tiếp tục học</h2>
            <span class="section-subtitle">Môn học bạn truy cập gần đây</span>
        </div>
        <a class="btn btn-link" href="<%= ResolveUrl("~/lms/courses") %>">
            Xem tất cả
            <i class="bi bi-arrow-right"></i>
        </a>
    </div>
    <div class="grid grid-2 gap-4">
        <asp:Repeater ID="CourseRepeater" runat="server">
            <ItemTemplate>
                <article class="course-card">
                    <div class="course-card-cover">
                        <i class="bi bi-code-slash"></i>
                        <span><%# Html(Eval("Code")) %></span>
                    </div>
                    <div class="course-card-body">
                        <span class="badge badge-success mb-2">Môn học lớp</span>
                        <h3><%# Html(Eval("Title")) %></h3>
                        <div class="course-card-meta">
                            <i class="bi bi-person"></i>
                            <%# Html(Eval("TeacherName")) %>
                        </div>
                        <div class="course-card-progress">
                            <div class="progress-label">
                                <span>Tiến độ</span>
                                <strong><%# Html(Eval("ProgressPercent")) %>%</strong>
                            </div>
                            <div class="progress">
                                <div class="progress-bar" style='<%# "width:" + Html(Eval("ProgressPercent")) + "%" %>'></div>
                            </div>
                        </div>
                        <a class="btn btn-outline btn-full" href='<%# CourseUrl(Eval("Id"), Eval("ContinueLessonId")) %>'>
                            <i class="bi bi-arrow-right-circle"></i>
                            Mở môn học
                        </a>
                    </div>
                </article>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <asp:Label
        ID="EmptyText"
        runat="server"
        CssClass="empty-state"
        Text="Bạn chưa được phân vào môn học lớp nào."
        Visible="false"
    />
</section>
