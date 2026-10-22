<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CourseEnrollments.ascx.cs" Inherits="InformationWeb.Controls.Cms.CourseEnrollments" %>
<link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/css/pages/cms/enrollment-management.css") %>" />
<section class="enrollment-management-page">
    <header class="d-flex flex-wrap justify-content-between align-items-end gap-3 mb-4">
        <div>
            <span class="eyebrow">QUẢN LÝ ĐĂNG KÝ</span>
            <h1 class="page-title mb-1">Đăng ký khóa học</h1>
            <p class="page-subtitle mb-0">Quản lý việc đăng ký và theo dõi tiến độ học tập của học viên.</p>
        </div>
        <div class="cms-page-actions">
            <asp:Button ID="AddEnrollmentButton" runat="server" CssClass="btn btn-action-save" Text="Đăng ký học viên" OnClick="AddEnrollmentButton_Click" />
        </div>
    </header>

    <asp:Label ID="ActionMessageText" runat="server" Visible="false" />

    <div class="app-card workspace-filters">
        <div class="filter-row">
            <div class="form-group">
                <label>Khóa học</label>
                <asp:DropDownList ID="CourseFilter" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label>Học viên</label>
                <asp:DropDownList ID="StudentFilter" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label>Trạng thái</label>
                <asp:DropDownList ID="StatusFilter" runat="server" CssClass="form-control">
                    <asp:ListItem Value="" Text="--Tất cả--" />
                    <asp:ListItem Value="ENROLLED" Text="Đã đăng ký" />
                    <asp:ListItem Value="IN_PROGRESS" Text="Đang học" />
                    <asp:ListItem Value="COMPLETED" Text="Hoàn thành" />
                    <asp:ListItem Value="DROPPED" Text="Đã bỏ" />
                </asp:DropDownList>
            </div>
            <div class="form-group filter-actions">
                <label>&nbsp;</label>
                <asp:Button ID="FilterButton" runat="server" CssClass="btn btn-secondary" Text="Lọc" OnClick="FilterButton_Click" />
                <asp:Button ID="ResetButton" runat="server" CssClass="btn btn-secondary" Text="Đặt lại" OnClick="ResetButton_Click" />
            </div>
        </div>
    </div>

    <div class="app-card enrollment-list">
        <asp:GridView ID="EnrollmentGrid" runat="server" AutoGenerateColumns="false"
            CssClass="data-table" GridLines="None" AllowPaging="true" PageSize="20"
            OnRowCommand="EnrollmentGrid_RowCommand" OnRowCreated="EnrollmentGrid_RowCreated"
            OnPageIndexChanging="EnrollmentGrid_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="EnrollmentID" HeaderText="ID" HeaderStyle-Width="80" />
                <asp:BoundField DataField="CourseTitle" HeaderText="Khóa học" />
                <asp:BoundField DataField="StudentName" HeaderText="Học viên" HeaderStyle-Width="150" />
                <asp:BoundField DataField="EnrolledAt" HeaderText="Ngày đăng ký" HeaderStyle-Width="120" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="LastAccessAt" HeaderText="Truy cập cuối" HeaderStyle-Width="120" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:TemplateField HeaderText="Tiến độ" HeaderStyle-Width="100">
                    <ItemTemplate>
                        <asp:Label ID="ProgressLabel" runat="server" />
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
                <asp:TemplateField HeaderText="Thao tác" HeaderStyle-Width="150">
                    <ItemTemplate>
                        <asp:Button ID="EditButton" runat="server" CommandName="EditEnrollment"
                            CommandArgument='<%# Eval("EnrollmentID") %>' CssClass="btn btn-sm btn-secondary"
                            Text="Sửa" />
                        <asp:Button ID="DeleteButton" runat="server" CommandName="DeleteEnrollment"
                            CommandArgument='<%# Eval("EnrollmentID") %>' CssClass="btn btn-sm btn-danger"
                            Text="Xóa" OnClientClick="return confirm('Bạn có chắc muốn xóa đăng ký này?');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <div class="empty-data">Không có đăng ký nào.</div>
            </EmptyDataTemplate>
        </asp:GridView>
    </div>

    <asp:Panel ID="EditPanel" runat="server" CssClass="app-card edit-panel" Visible="false">
        <h3 class="card-title">
            <asp:Literal ID="EditPanelTitle" runat="server" />
        </h3>
        <div class="form-row">
            <div class="form-group">
                <label>Khóa học <span class="required">*</span></label>
                <asp:DropDownList ID="CourseList" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="CourseRequired" runat="server" ControlToValidate="CourseList"
                    ErrorMessage="Vui lòng chọn khóa học" CssClass="text-danger" Display="Dynamic" InitialValue="" />
            </div>
            <div class="form-group">
                <label>Học viên <span class="required">*</span></label>
                <asp:DropDownList ID="StudentList" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="StudentRequired" runat="server" ControlToValidate="StudentList"
                    ErrorMessage="Vui lòng chọn học viên" CssClass="text-danger" Display="Dynamic" InitialValue="" />
            </div>
        </div>
        <div class="form-row">
            <div class="form-group">
                <label>Trạng thái</label>
                <asp:DropDownList ID="StatusList" runat="server" CssClass="form-control">
                    <asp:ListItem Value="ENROLLED" Text="Đã đăng ký" />
                    <asp:ListItem Value="IN_PROGRESS" Text="Đang học" />
                    <asp:ListItem Value="COMPLETED" Text="Hoàn thành" />
                    <asp:ListItem Value="DROPPED" Text="Đã bỏ" />
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label>Tiến độ (%)</label>
                <asp:TextBox ID="ProgressPercentText" runat="server" CssClass="form-control" TextMode="Number" Value="0" />
            </div>
        </div>
        <div class="form-group">
            <label>Điểm cuối cùng</label>
            <asp:TextBox ID="FinalScoreText" runat="server" CssClass="form-control" TextMode="Number" />
        </div>
        <div class="form-actions">
            <asp:Button ID="SaveButton" runat="server" CssClass="btn btn-action-save" Text="Lưu" OnClick="SaveButton_Click" />
            <asp:Button ID="CancelButton" runat="server" CssClass="btn btn-secondary" Text="Hủy" OnClick="CancelButton_Click" />
        </div>
        <asp:HiddenField ID="EnrollmentIdValue" runat="server" />
    </asp:Panel>
</section>
