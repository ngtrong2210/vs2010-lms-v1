<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CourseLibrary.ascx.cs" Inherits="InformationWeb.Controls.Cms.CourseLibrary" %>
<link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/css/pages/cms/course-library.css") %>" />
<section class="course-library-page">
    <header class="d-flex flex-wrap justify-content-between align-items-end gap-3 mb-4">
        <div>
            <span class="eyebrow">THƯ VIỆN KHÓA HỌC</span>
            <h1 class="page-title mb-1">Quản lý khóa học</h1>
            <p class="page-subtitle mb-0">Tạo, chỉnh sửa và quản lý toàn bộ khóa học trong hệ thống.</p>
        </div>
        <div class="cms-page-actions">
            <asp:Button ID="AddCourseButton" runat="server" CssClass="btn btn-action-save" Text="Thêm khóa học" OnClick="AddCourseButton_Click" />
        </div>
    </header>

    <asp:Label ID="ActionMessageText" runat="server" Visible="false" />

    <div class="app-card workspace-filters">
        <div class="filter-row">
            <div class="form-group">
                <label>Tìm kiếm</label>
                <asp:TextBox ID="SearchText" runat="server" CssClass="form-control" placeholder="Nhập từ khóa..." />
            </div>
            <div class="form-group">
                <label>Danh mục</label>
                <asp:DropDownList ID="CategoryFilter" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label>Trạng thái</label>
                <asp:DropDownList ID="StatusFilter" runat="server" CssClass="form-control">
                    <asp:ListItem Value="" Text="--Tất cả--" />
                    <asp:ListItem Value="DRAFT" Text="Nháp" />
                    <asp:ListItem Value="PUBLISHED" Text="Đã xuất bản" />
                    <asp:ListItem Value="ARCHIVED" Text="Lưu trữ" />
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label>Giảng viên</label>
                <asp:DropDownList ID="TeacherFilter" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group filter-actions">
                <label>&nbsp;</label>
                <asp:Button ID="FilterButton" runat="server" CssClass="btn btn-secondary" Text="Lọc" OnClick="FilterButton_Click" />
                <asp:Button ID="ResetButton" runat="server" CssClass="btn btn-secondary" Text="Đặt lại" OnClick="ResetButton_Click" />
            </div>
        </div>
    </div>

    <div class="app-card course-list">
        <asp:GridView ID="CourseGrid" runat="server" AutoGenerateColumns="false"
            CssClass="data-table" GridLines="None" AllowPaging="true" PageSize="20"
            OnRowCommand="CourseGrid_RowCommand" OnRowCreated="CourseGrid_RowCreated"
            OnPageIndexChanging="CourseGrid_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="CourseID" HeaderText="ID" HeaderStyle-Width="80" />
                <asp:BoundField DataField="Code" HeaderText="Mã" HeaderStyle-Width="120" />
                <asp:BoundField DataField="Title" HeaderText="Tên khóa học" />
                <asp:BoundField DataField="CategoryName" HeaderText="Danh mục" HeaderStyle-Width="150" />
                <asp:BoundField DataField="TeacherName" HeaderText="Giảng viên" HeaderStyle-Width="150" />
                <asp:BoundField DataField="Level" HeaderText="Cấp độ" HeaderStyle-Width="100" />
                <asp:TemplateField HeaderText="Trạng thái" HeaderStyle-Width="120">
                    <ItemTemplate>
                        <asp:Label ID="StatusLabel" runat="server" CssClass="status-badge" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Thao tác" HeaderStyle-Width="200">
                    <ItemTemplate>
                        <asp:Button ID="EditButton" runat="server" CommandName="EditCourse"
                            CommandArgument='<%# Eval("CourseID") %>' CssClass="btn btn-sm btn-secondary"
                            Text="Sửa" />
                        <asp:Button ID="PublishButton" runat="server" CommandName="PublishCourse"
                            CommandArgument='<%# Eval("CourseID") %>' CssClass="btn btn-sm btn-success"
                            Text="Xuất bản" Visible='<%# Eval("Status").ToString() == "DRAFT" %>' />
                        <asp:Button ID="ArchiveButton" runat="server" CommandName="ArchiveCourse"
                            CommandArgument='<%# Eval("CourseID") %>' CssClass="btn btn-sm btn-warning"
                            Text="Lưu trữ" Visible='<%# Eval("Status").ToString() == "PUBLISHED" %>' />
                        <asp:Button ID="DeleteButton" runat="server" CommandName="DeleteCourse"
                            CommandArgument='<%# Eval("CourseID") %>' CssClass="btn btn-sm btn-danger"
                            Text="Xóa" OnClientClick="return confirm('Bạn có chắc muốn xóa khóa học này?');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <div class="empty-data">Không có khóa học nào. Hãy thêm khóa học mới.</div>
            </EmptyDataTemplate>
        </asp:GridView>
    </div>

    <asp:Panel ID="EditPanel" runat="server" CssClass="app-card edit-panel" Visible="false">
        <h3 class="card-title">
            <asp:Literal ID="EditPanelTitle" runat="server" />
        </h3>
        <div class="form-row">
            <div class="form-group">
                <label>Mã khóa học</label>
                <asp:TextBox ID="CodeText" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label>Tên khóa học <span class="required">*</span></label>
                <asp:TextBox ID="TitleText" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="TitleRequired" runat="server" ControlToValidate="TitleText"
                    ErrorMessage="Vui lòng nhập tên khóa học" CssClass="text-danger" Display="Dynamic" />
            </div>
        </div>
        <div class="form-row">
            <div class="form-group">
                <label>Slug (URL)</label>
                <asp:TextBox ID="SlugText" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label>Thumbnail URL</label>
                <asp:TextBox ID="ThumbnailUrlText" runat="server" CssClass="form-control" />
            </div>
        </div>
        <div class="form-group">
            <label>Mô tả ngắn</label>
            <asp:TextBox ID="ShortDescriptionText" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2" />
        </div>
        <div class="form-group">
            <label>Mô tả chi tiết</label>
            <asp:TextBox ID="DescriptionText" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5" />
        </div>
        <div class="form-row">
            <div class="form-group">
                <label>Giảng viên <span class="required">*</span></label>
                <asp:DropDownList ID="TeacherList" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="TeacherRequired" runat="server" ControlToValidate="TeacherList"
                    ErrorMessage="Vui lòng chọn giảng viên" CssClass="text-danger" Display="Dynamic" InitialValue="" />
            </div>
            <div class="form-group">
                <label>Danh mục</label>
                <asp:DropDownList ID="CategoryList" runat="server" CssClass="form-control" />
            </div>
        </div>
        <div class="form-row">
            <div class="form-group">
                <label>Cấp độ</label>
                <asp:DropDownList ID="LevelList" runat="server" CssClass="form-control">
                    <asp:ListItem Value="BEGINNER" Text="Cơ bản" />
                    <asp:ListItem Value="INTERMEDIATE" Text="Trung cấp" />
                    <asp:ListItem Value="ADVANCED" Text="Nâng cao" />
                    <asp:ListItem Value="EXPERT" Text="Chuyên gia" />
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label>Điểm qua (%)</label>
                <asp:TextBox ID="PassingScoreText" runat="server" CssClass="form-control" TextMode="Number" Value="60" />
            </div>
        </div>
        <div class="form-row">
            <div class="form-group">
                <label>Môn học (liên kết ClassSubject)</label>
                <asp:DropDownList ID="ClassSubjectList" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label>Trạng thái</label>
                <asp:DropDownList ID="StatusList" runat="server" CssClass="form-control">
                    <asp:ListItem Value="DRAFT" Text="Nháp" />
                    <asp:ListItem Value="PUBLISHED" Text="Đã xuất bản" />
                    <asp:ListItem Value="ARCHIVED" Text="Lưu trữ" />
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-actions">
            <asp:Button ID="SaveButton" runat="server" CssClass="btn btn-action-save" Text="Lưu" OnClick="SaveButton_Click" />
            <asp:Button ID="CancelButton" runat="server" CssClass="btn btn-secondary" Text="Hủy" OnClick="CancelButton_Click" />
        </div>
        <asp:HiddenField ID="CourseIdValue" runat="server" />
    </asp:Panel>
</section>
