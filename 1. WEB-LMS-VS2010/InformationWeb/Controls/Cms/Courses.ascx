<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Courses.ascx.cs" Inherits="InformationWeb.Controls.Cms.Courses" %>
<link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/css/pages/cms/course-management.css") %>" />
<section class="teaching-workspace-page">
    <header class="d-flex flex-wrap justify-content-between align-items-end gap-3 mb-4">
        <div>
            <span class="eyebrow">GIẢNG DẠY THEO NĂM HỌC</span>
            <h1 class="page-title mb-1"><asp:Literal ID="PageTitleText" runat="server" /></h1>
            <p class="page-subtitle mb-0"><asp:Literal ID="PageDescriptionText" runat="server" /></p>
        </div>
        <div class="cms-page-actions">
            <a class="btn btn-action-view" href="<%= ResolveUrl("~/cms/academic") %>">
                <i class="bi bi-diagram-3"></i>
                Cơ cấu đào tạo
            </a>
            <a class="btn btn-action-save" href="<%= ResolveUrl("~/cms/assignments") %>">
                <i class="bi bi-clipboard-check"></i>
                Chấm bài
            </a>
        </div>
    </header>
    <asp:Label ID="ActionMessageText" runat="server" Visible="false" />
    <div class="app-card workspace-filters">
        <label class="search-field">
            <span>Tìm nhanh</span>
            <div class="input-icon">
                <i class="bi bi-search"></i>
                <asp:TextBox ID="SearchText" runat="server" CssClass="form-control" placeholder="Tên môn, lớp hoặc giảng viên..." />
            </div>
        </label>
        <label>
            <span>Năm học</span>
            <asp:DropDownList ID="YearFilterList" runat="server" CssClass="form-select">
                <asp:ListItem Value="">Tất cả năm học</asp:ListItem>
            </asp:DropDownList>
        </label>
        <label>
            <span>Học kỳ</span>
            <asp:DropDownList ID="SemesterFilterList" runat="server" CssClass="form-select">
                <asp:ListItem Value="">Tất cả học kỳ</asp:ListItem>
                <asp:ListItem Value="1">Học kỳ 1</asp:ListItem>
                <asp:ListItem Value="2">Học kỳ 2</asp:ListItem>
                <asp:ListItem Value="3">Học kỳ hè</asp:ListItem>
            </asp:DropDownList>
        </label>
        <label>
            <span>Trạng thái nội dung</span>
            <asp:DropDownList ID="CourseStatusFilterList" runat="server" CssClass="form-select">
                <asp:ListItem Value="">Tất cả trạng thái</asp:ListItem>
                <asp:ListItem Value="EMPTY">Chưa khởi tạo</asp:ListItem>
                <asp:ListItem Value="DRAFT">Bản nháp</asp:ListItem>
                <asp:ListItem Value="PUBLISHED">Đã xuất bản</asp:ListItem>
                <asp:ListItem Value="ARCHIVED">Lưu trữ</asp:ListItem>
            </asp:DropDownList>
        </label>
        <div class="cms-control-actions">
            <asp:Button
                ID="SearchButton"
                runat="server"
                Text="Áp dụng bộ lọc"
                CssClass="btn btn-action-filter"
                OnClick="SearchButton_Click"
            />
        </div>
    </div>
    <asp:Label ID="ErrorText" runat="server" CssClass="alert alert-danger" Visible="false" />
    <div class="app-card table-card">
        <div class="table-card-heading">
            <div>
                <strong>Danh sách môn học lớp</strong>
                <small>Mỗi dòng là một môn của một lớp trong một năm học; không tạo khóa học rời.</small>
            </div>
        </div>
        <asp:Label ID="EmptyText" runat="server" CssClass="empty-state" Text="Không có môn học lớp phù hợp bộ lọc." Visible="false" />
        <div class="table-responsive">
            <asp:GridView
                ID="DataGrid"
                runat="server"
                CssClass="table align-middle mb-0 workspace-table"
                AutoGenerateColumns="false"
                AllowPaging="true"
                PageSize="20"
                OnPageIndexChanging="DataGrid_PageIndexChanging"
                OnRowCreated="DataGrid_RowCreated"
                OnRowCommand="DataGrid_RowCommand"
            >
                <Columns>
                    <asp:TemplateField HeaderText="Năm học / Học kỳ">
                        <ItemTemplate>
                            <strong><%# Eval("YearName") %></strong>
                            <small>Học kỳ <%# Eval("Semester") %></small>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Lớp / Môn học">
                        <ItemTemplate>
                            <div class="subject-cell">
                                <span class="subject-icon"><i class="bi bi-journal-bookmark-fill"></i></span>
                                <div>
                                    <strong><%# Eval("SubjectName") %></strong>
                                    <small><%# Eval("ClassName") %> · <%# Eval("SubjectID") %></small>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="TeacherName" HeaderText="Giảng viên" />
                    <asp:TemplateField HeaderText="Nội dung">
                        <ItemTemplate>
                            <span class="badge badge-soft-primary"><%# CourseStatusLabel(Eval("OnlineCourseID"), Eval("OnlineCourseStatus")) %></span>
                            <small><%# Eval("ChapterCount") %> chương · <%# Eval("LessonCount") %> bài</small>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Học viên">
                        <ItemTemplate>
                            <strong><%# Eval("StudentCount") %></strong>
                            <small>học viên của lớp</small>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField
                        HeaderText="Thao tác"
                        ItemStyle-CssClass="text-end action-cell"
                        HeaderStyle-CssClass="text-end action-cell"
                    >
                        <ItemTemplate>
                            <asp:HyperLink
                                ID="EditCourseLink"
                                runat="server"
                                CssClass="btn btn-action-view btn-sm"
                                NavigateUrl='<%# CourseContentUrl(Eval("OnlineCourseID")) %>'
                                Visible='<%# HasCourse(Eval("OnlineCourseID")) %>'
                            >
                                <i class="bi bi-pencil-square"></i>
                                Soạn bài
                            </asp:HyperLink>
                            <asp:LinkButton
                                ID="OpenSettingsButton"
                                runat="server"
                                CssClass="btn btn-action-edit btn-sm ms-1"
                                CommandName="OpenSettings"
                                CommandArgument='<%# Eval("OnlineCourseID") %>'
                                CausesValidation="false"
                                Visible='<%# HasCourse(Eval("OnlineCourseID")) %>'
                            >
                                <i class="bi bi-sliders"></i>
                                Thiết lập
                            </asp:LinkButton>
                            <asp:LinkButton
                                ID="EnsureWorkspaceButton"
                                runat="server"
                                CssClass="btn btn-action-create btn-sm"
                                CommandName="EnsureWorkspace"
                                CommandArgument='<%# Eval("ClassSubjectID") %>'
                                CausesValidation="false"
                                Visible='<%# !HasCourse(Eval("OnlineCourseID")) %>'
                            >
                                <i class="bi bi-plus-circle"></i>
                                Khởi tạo nội dung
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <asp:UpdatePanel ID="CourseSettingsUpdatePanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
        <ContentTemplate>
    <div id="courseSettingsModal" class="modal-mask" hidden="hidden">
        <section class="app-card form-modal" role="dialog" aria-modal="true" aria-labelledby="courseSettingsTitle">
            <div class="modal-heading">
                <div>
                    <small>Thiết lập môn học lớp</small>
                    <h2 id="courseSettingsTitle"><asp:Literal ID="CourseSettingsTitleText" runat="server" /></h2>
                    <p><asp:Literal ID="CourseSettingsContextText" runat="server" /></p>
                </div>
                <button type="button" class="btn-close" data-course-settings-close="courseSettingsModal" aria-label="Đóng"></button>
            </div>
            <div class="row g-3">
                <div class="col-12">
                    <label class="form-label">Mô tả ngắn</label>
                    <asp:TextBox
                        ID="CourseSettingsShortDescriptionText"
                        runat="server"
                        CssClass="form-control"
                        TextMode="MultiLine"
                        Rows="3"
                    />
                </div>
                <div class="col-md-6">
                    <label class="form-label">Điểm đạt toàn môn</label>
                    <asp:TextBox ID="CourseSettingsPassingScoreText" runat="server" CssClass="form-control" />
                </div>
                <div class="col-md-6">
                    <label class="form-label">Trạng thái</label>
                    <asp:DropDownList ID="CourseSettingsStatusList" runat="server" CssClass="form-select">
                        <asp:ListItem Value="DRAFT">Bản nháp</asp:ListItem>
                        <asp:ListItem Value="PUBLISHED">Đã xuất bản</asp:ListItem>
                        <asp:ListItem Value="ARCHIVED">Lưu trữ</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="modal-actions">
                <button type="button" class="btn btn-action-cancel" data-course-settings-close="courseSettingsModal">
                    <i class="bi bi-x-lg"></i>
                    Hủy
                </button>
                <asp:Button
                    ID="CourseSettingsSaveButton"
                    runat="server"
                    Text="Lưu thiết lập"
                    CssClass="btn btn-action-save"
                    OnClick="CourseSettingsSaveButton_Click"
                />
            </div>
        </section>
    </div>
    <asp:HiddenField ID="CourseSettingsOpenValue" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="CourseSettingsIdValue" runat="server" />
    <asp:HiddenField ID="CourseSettingsCodeValue" runat="server" />
    <asp:HiddenField ID="CourseSettingsTitleValue" runat="server" />
    <asp:HiddenField ID="CourseSettingsSlugValue" runat="server" />
    <asp:HiddenField ID="CourseSettingsThumbnailValue" runat="server" />
    <asp:HiddenField ID="CourseSettingsDescriptionValue" runat="server" />
    <asp:HiddenField ID="CourseSettingsTeacherIdValue" runat="server" />
    <asp:HiddenField ID="CourseSettingsCategoryIdValue" runat="server" />
    <asp:HiddenField ID="CourseSettingsClassSubjectIdValue" runat="server" />
    <asp:HiddenField ID="CourseSettingsLevelValue" runat="server" />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="CourseSettingsSaveButton" />
        </Triggers>
    </asp:UpdatePanel>
</section>
<script src="<%= ResolveUrl("~/assets/lms/js/course-management-webforms.js") %>"></script>
