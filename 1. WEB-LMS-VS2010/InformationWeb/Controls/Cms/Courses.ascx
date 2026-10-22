<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Courses.ascx.cs" Inherits="InformationWeb.Controls.Cms.Courses" %>
<section>
    <header class="page-header">
        <div>
            <span class="badge badge-info mb-2">GIẢNG DẠY THEO NĂM HỌC</span>
            <h1 class="page-title"><asp:Literal ID="PageTitleText" runat="server" /></h1>
            <p class="page-subtitle"><asp:Literal ID="PageDescriptionText" runat="server" /></p>
        </div>
        <div class="page-actions">
            <a class="btn btn-outline" href="<%= ResolveUrl("~/cms/academic") %>">
                <i class="bi bi-diagram-3"></i>
                Cơ cấu đào tạo
            </a>
            <a class="btn btn-outline" href="<%= ResolveUrl("~/cms/assignments") %>">
                <i class="bi bi-clipboard-check"></i>
                Chấm bài
            </a>
        </div>
    </header>
    <asp:Label ID="ActionMessageText" runat="server" Visible="false" />
    <div class="card card-filter mb-3">
        <div class="filter-group">
            <div class="filter-field">
                <label>Tìm nhanh</label>
                <div class="input-group">
                    <i class="bi bi-search"></i>
                    <asp:TextBox ID="SearchText" runat="server" CssClass="form-control" placeholder="Tên môn, lớp hoặc giảng viên..." />
                </div>
            </div>
            <div class="filter-field">
                <label>Năm học</label>
                <asp:DropDownList ID="YearFilterList" runat="server" CssClass="form-select">
                    <asp:ListItem Value="">Tất cả năm học</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="filter-field">
                <label>Học kỳ</label>
                <asp:DropDownList ID="SemesterFilterList" runat="server" CssClass="form-select">
                    <asp:ListItem Value="">Tất cả học kỳ</asp:ListItem>
                    <asp:ListItem Value="1">Học kỳ 1</asp:ListItem>
                    <asp:ListItem Value="2">Học kỳ 2</asp:ListItem>
                    <asp:ListItem Value="3">Học kỳ hè</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="filter-field">
                <label>Trạng thái nội dung</label>
                <asp:DropDownList ID="CourseStatusFilterList" runat="server" CssClass="form-select">
                    <asp:ListItem Value="">Tất cả trạng thái</asp:ListItem>
                    <asp:ListItem Value="EMPTY">Chưa khởi tạo</asp:ListItem>
                    <asp:ListItem Value="DRAFT">Bản nháp</asp:ListItem>
                    <asp:ListItem Value="PUBLISHED">Đã xuất bản</asp:ListItem>
                    <asp:ListItem Value="ARCHIVED">Lưu trữ</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="filter-actions">
                <asp:Button
                    ID="SearchButton"
                    runat="server"
                    Text="Áp dụng bộ lọc"
                    CssClass="btn btn-secondary"
                    OnClick="SearchButton_Click"
                />
            </div>
        </div>
    </div>
    <asp:Label ID="ErrorText" runat="server" CssClass="alert alert-danger" Visible="false" />
    <div class="card">
        <div class="card-header">
            <div>
                <strong>Danh sách môn học lớp</strong>
                <small>Mỗi dòng là một môn của một lớp trong một năm học; không tạo khóa học rời.</small>
            </div>
        </div>
        <asp:Label ID="EmptyText" runat="server" CssClass="empty-state" Text="Không có môn học lớp phù hợp bộ lọc." Visible="false" />
        <div class="table-container">
            <asp:GridView
                ID="DataGrid"
                runat="server"
                CssClass="lms-table"
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
                            <span class="badge badge-info"><%# CourseStatusLabel(Eval("OnlineCourseID"), Eval("OnlineCourseStatus")) %></span>
                            <small><%# Eval("ChapterCount") %> chương · <%# Eval("LessonCount") %> bài</small>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Học viên">
                        <ItemTemplate>
                            <strong><%# Eval("StudentCount") %></strong>
                            <small>học viên của lớp</small>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Thao tác">
                        <ItemTemplate>
                            <asp:HyperLink
                                ID="EditCourseLink"
                                runat="server"
                                CssClass="btn btn-sm btn-outline"
                                NavigateUrl='<%# CourseContentUrl(Eval("OnlineCourseID")) %>'
                                Visible='<%# HasCourse(Eval("OnlineCourseID")) %>'
                            >
                                <i class="bi bi-pencil-square"></i>
                                Soạn bài
                            </asp:HyperLink>
                            <asp:LinkButton
                                ID="OpenSettingsButton"
                                runat="server"
                                CssClass="btn btn-sm btn-outline"
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
                                CssClass="btn btn-sm btn-primary"
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
    <div id="courseSettingsModal" class="modal-backdrop" hidden="hidden">
        <section class="modal" role="dialog" aria-modal="true" aria-labelledby="courseSettingsTitle">
            <div class="modal-header">
                <div>
                    <small>Thiết lập môn học lớp</small>
                    <h2 id="courseSettingsTitle"><asp:Literal ID="CourseSettingsTitleText" runat="server" /></h2>
                    <p><asp:Literal ID="CourseSettingsContextText" runat="server" /></p>
                </div>
                <button type="button" class="btn-close" data-course-settings-close="courseSettingsModal" aria-label="Đóng"></button>
            </div>
            <div class="modal-body">
                <div class="form-group">
                    <label class="form-label">Mô tả ngắn</label>
                    <asp:TextBox
                        ID="CourseSettingsShortDescriptionText"
                        runat="server"
                        CssClass="form-control"
                        TextMode="MultiLine"
                        Rows="3"
                    />
                </div>
                <div class="grid grid-2 gap-4">
                    <div class="form-group">
                        <label class="form-label">Điểm đạt toàn môn</label>
                        <asp:TextBox ID="CourseSettingsPassingScoreText" runat="server" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                        <label class="form-label">Trạng thái</label>
                        <asp:DropDownList ID="CourseSettingsStatusList" runat="server" CssClass="form-select">
                            <asp:ListItem Value="DRAFT">Bản nháp</asp:ListItem>
                            <asp:ListItem Value="PUBLISHED">Đã xuất bản</asp:ListItem>
                            <asp:ListItem Value="ARCHIVED">Lưu trữ</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-course-settings-close="courseSettingsModal">
                    Hủy
                </button>
                <asp:Button
                    ID="CourseSettingsSaveButton"
                    runat="server"
                    Text="Lưu thiết lập"
                    CssClass="btn btn-primary"
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
