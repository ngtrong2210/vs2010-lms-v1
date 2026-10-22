<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CourseProgress.ascx.cs" Inherits="InformationWeb.Controls.Cms.CourseProgress" %>
<link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/css/pages/cms/progress-tracking.css") %>" />
<section class="progress-tracking-page">
    <header class="d-flex flex-wrap justify-content-between align-items-end gap-3 mb-4">
        <div>
            <span class="eyebrow">THEO DÕI TIẾN ĐỘ</span>
            <h1 class="page-title mb-1">Tiến độ học tập</h1>
            <p class="page-subtitle mb-0">Theo dõi tiến độ học tập và kết quả của học viên theo từng khóa học.</p>
        </div>
    </header>

    <asp:Label ID="ActionMessageText" runat="server" Visible="false" />

    <div class="app-card workspace-filters">
        <div class="filter-row">
            <div class="form-group">
                <label>Khóa học</label>
                <asp:DropDownList ID="CourseFilter" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="CourseFilter_SelectedIndexChanged" />
            </div>
            <div class="form-group">
                <label>Học viên</label>
                <asp:DropDownList ID="StudentFilter" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="StudentFilter_SelectedIndexChanged" />
            </div>
            <div class="form-group">
                <label>Lớp học</label>
                <asp:DropDownList ID="ClassFilter" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ClassFilter_SelectedIndexChanged" />
            </div>
            <div class="form-group filter-actions">
                <label>&nbsp;</label>
                <asp:Button ID="ExportButton" runat="server" CssClass="btn btn-secondary" Text="Xuất báo cáo" OnClick="ExportButton_Click" />
            </div>
        </div>
    </div>

    <div class="app-card progress-summary">
        <h3 class="card-title">Tổng quan</h3>
        <div class="summary-grid">
            <div class="summary-item">
                <div class="summary-label">Tổng học viên</div>
                <div class="summary-value"><asp:Literal ID="TotalStudentsText" runat="server" /></div>
            </div>
            <div class="summary-item">
                <div class="summary-label">Đang học</div>
                <div class="summary-value status-inprogress"><asp:Literal ID="InProgressText" runat="server" /></div>
            </div>
            <div class="summary-item">
                <div class="summary-label">Hoàn thành</div>
                <div class="summary-value status-completed"><asp:Literal ID="CompletedText" runat="server" /></div>
            </div>
            <div class="summary-item">
                <div class="summary-label">Điểm trung bình</div>
                <div class="summary-value"><asp:Literal ID="AverageScoreText" runat="server" /></div>
            </div>
        </div>
    </div>

    <div class="app-card progress-list">
        <h3 class="card-title">Chi tiết tiến độ</h3>
        <asp:GridView ID="ProgressGrid" runat="server" AutoGenerateColumns="false"
            CssClass="data-table" GridLines="None" AllowPaging="true" PageSize="20"
            OnRowCommand="ProgressGrid_RowCommand" OnRowCreated="ProgressGrid_RowCreated"
            OnPageIndexChanging="ProgressGrid_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="EnrollmentID" HeaderText="ID" HeaderStyle-Width="80" />
                <asp:BoundField DataField="StudentName" HeaderText="Học viên" HeaderStyle-Width="150" />
                <asp:BoundField DataField="CourseTitle" HeaderText="Khóa học" />
                <asp:BoundField DataField="ClassName" HeaderText="Lớp" HeaderStyle-Width="120" />
                <asp:TemplateField HeaderText="Bài học" HeaderStyle-Width="80">
                    <ItemTemplate>
                        <asp:Label ID="LessonsCompletedLabel" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tiến độ" HeaderStyle-Width="120">
                    <ItemTemplate>
                        <div class="progress-bar-container">
                            <div class="progress-bar" id="ProgressBar" runat="server"></div>
                            <asp:Label ID="ProgressLabel" runat="server" CssClass="progress-text" />
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Điểm" HeaderStyle-Width="80">
                    <ItemTemplate>
                        <asp:Label ID="ScoreLabel" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Trạng thái" HeaderStyle-Width="120">
                    <ItemTemplate>
                        <asp:Label ID="StatusLabel" runat="server" CssClass="status-badge" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Hoạt động cuối" HeaderStyle-Width="120">
                    <ItemTemplate>
                        <asp:Label ID="LastActivityLabel" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Thao tác" HeaderStyle-Width="100">
                    <ItemTemplate>
                        <asp:Button ID="ViewButton" runat="server" CommandName="ViewProgress"
                            CommandArgument='<%# Eval("EnrollmentID") %>' CssClass="btn btn-sm btn-secondary"
                            Text="Chi tiết" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <div class="empty-data">Không có dữ liệu tiến độ.</div>
            </EmptyDataTemplate>
        </asp:GridView>
    </div>

    <asp:Panel ID="DetailPanel" runat="server" CssClass="app-card detail-panel" Visible="false">
        <h3 class="card-title">
            Chi tiết tiến độ - <asp:Literal ID="DetailStudentName" runat="server" />
        </h3>
        <div class="detail-header">
            <div class="detail-info">
                <span>Khóa học: <asp:Literal ID="DetailCourseTitle" runat="server" /></span>
                <span>Lớp: <asp:Literal ID="DetailClassName" runat="server" /></span>
            </div>
            <asp:Button ID="CloseDetailButton" runat="server" CssClass="btn btn-secondary" Text="Đóng" OnClick="CloseDetailButton_Click" />
        </div>
        <asp:GridView ID="LessonProgressGrid" runat="server" AutoGenerateColumns="false"
            CssClass="data-table" GridLines="None">
            <Columns>
                <asp:BoundField DataField="LessonID" HeaderText="ID" HeaderStyle-Width="80" />
                <asp:BoundField DataField="LessonTitle" HeaderText="Bài học" />
                <asp:BoundField DataField="ChapterTitle" HeaderText="Chương" HeaderStyle-Width="150" />
                <asp:TemplateField HeaderText="Trạng thái" HeaderStyle-Width="120">
                    <ItemTemplate>
                        <asp:Label ID="LessonStatusLabel" runat="server" CssClass="status-badge" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Điểm" HeaderStyle-Width="80">
                    <ItemTemplate>
                        <asp:Label ID="LessonScoreLabel" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="CompletedAt" HeaderText="Hoàn thành" HeaderStyle-Width="120" DataFormatString="{0:dd/MM/yyyy HH:mm}" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
</section>
