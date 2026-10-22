<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Users.ascx.cs" Inherits="InformationWeb.Controls.Cms.Users" %>
<link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/css/pages/cms/system-management.css") %>" />
<link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/css/pages/cms/system-management-webforms.css") %>" />
<section class="system-page">
    <header class="system-page-header">
        <div>
            <span class="system-kicker">
                <i class="bi bi-person-gear"></i>
                QUẢN TRỊ HỆ THỐNG
            </span>
            <h1 class="page-title mb-1"><asp:Literal ID="PageTitleText" runat="server" /></h1>
            <p class="page-subtitle mb-0"><asp:Literal ID="PageDescriptionText" runat="server" /></p>
        </div>
        <div class="cms-page-actions">
            <button type="button" class="btn btn-action-create" data-user-create="true">
                <i class="bi bi-person-plus"></i>
                Thêm người dùng
            </button>
        </div>
    </header>
    <asp:Label ID="ActionMessageText" runat="server" Visible="false" />
    <div class="app-card system-filter-card">
        <label class="system-filter-field system-filter-field--search">
            <span>Tìm kiếm</span>
            <span class="system-search-control">
                <i class="bi bi-search"></i>
                <asp:TextBox ID="SearchText" runat="server" CssClass="form-control" placeholder="Tên, tài khoản hoặc email..." />
            </span>
        </label>
        <label class="system-filter-field">
            <span>Vai trò</span>
            <asp:DropDownList ID="RoleFilterList" runat="server" CssClass="form-select">
                <asp:ListItem Value="">Tất cả vai trò</asp:ListItem>
                <asp:ListItem Value="ADMIN">Quản trị</asp:ListItem>
                <asp:ListItem Value="TEACHER">Giảng viên</asp:ListItem>
                <asp:ListItem Value="STUDENT">Học viên</asp:ListItem>
            </asp:DropDownList>
        </label>
        <label class="system-filter-field">
            <span>Trạng thái</span>
            <asp:DropDownList ID="StatusFilterList" runat="server" CssClass="form-select">
                <asp:ListItem Value="">Tất cả trạng thái</asp:ListItem>
                <asp:ListItem Value="ACTIVE">Đang hoạt động</asp:ListItem>
                <asp:ListItem Value="INACTIVE">Ngừng hoạt động</asp:ListItem>
                <asp:ListItem Value="LOCKED">Đã khóa</asp:ListItem>
            </asp:DropDownList>
        </label>
        <div class="cms-control-actions">
            <asp:Button ID="SearchButton" runat="server" Text="Áp dụng" CssClass="btn btn-action-filter" OnClick="SearchButton_Click" />
        </div>
    </div>
    <div class="app-card system-table-card">
        <header class="system-data-header">
            <div>
                <span>Danh sách tài khoản</span>
                <small>
                    <asp:Literal ID="UserTotalText" runat="server" />
                    người dùng trong hệ thống
                </small>
            </div>
            <span class="system-data-count">
                <asp:Literal ID="UserShownText" runat="server" />
                kết quả trang này
            </span>
        </header>
        <asp:Label ID="ErrorText" runat="server" CssClass="alert alert-danger m-3" Visible="false" />
        <asp:Label
            ID="EmptyText"
            runat="server"
            CssClass="empty-state"
            Text="Không tìm thấy người dùng. Thử thay đổi từ khóa hoặc bộ lọc."
            Visible="false"
        />
        <div class="table-responsive system-table-scroll">
            <asp:GridView
                ID="DataGrid"
                runat="server"
                CssClass="table align-middle mb-0"
                AutoGenerateColumns="false"
                DataKeyNames="UserID"
                AllowPaging="true"
                PageSize="20"
                OnPageIndexChanging="DataGrid_PageIndexChanging"
                OnRowCreated="DataGrid_RowCreated"
                OnRowCommand="DataGrid_RowCommand"
            >
                <Columns>
                    <asp:TemplateField HeaderText="STT" HeaderStyle-CssClass="system-index-heading" ItemStyle-CssClass="system-index-cell">
                        <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Người dùng">
                        <ItemTemplate>
                            <div class="system-user-cell">
                                <span class="avatar"><%# UserInitials(Eval("FullName")) %></span>
                                <div>
                                    <strong><%# Server.HtmlEncode(Convert.ToString(Eval("FullName"))) %></strong>
                                    <small><%# Server.HtmlEncode(Convert.ToString(Eval("Username"))) %> · <%# Server.HtmlEncode(Convert.ToString(Eval("Email"))) %></small>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Vai trò">
                        <ItemTemplate><span class="badge badge-soft-primary"><%# Server.HtmlEncode(Convert.ToString(Eval("RoleNames"))) %></span></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField
                        HeaderText="Mã nghiệp vụ"
                        HeaderStyle-CssClass="system-column-code"
                        ItemStyle-CssClass="system-column-code"
                    >
                        <ItemTemplate><%# UserBusinessCode(Eval("TeacherCode"), Eval("StudentCode")) %></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Trạng thái">
                        <ItemTemplate><span class='<%# "badge " + UserStatusClass(Eval("Status")) %>'><%# UserStatusLabel(Eval("Status")) %></span></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField
                        HeaderText="Lần đăng nhập cuối"
                        HeaderStyle-CssClass="system-column-date"
                        ItemStyle-CssClass="system-column-date"
                    >
                        <ItemTemplate><%# UserLastLogin(Eval("LastLoginAt")) %></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField
                        HeaderText="Thao tác"
                        HeaderStyle-CssClass="system-action-heading"
                        ItemStyle-CssClass="system-action-cell"
                    >
                        <ItemTemplate>
                            <div class="system-row-actions">
                                <asp:LinkButton
                                    ID="EditUserButton"
                                    runat="server"
                                    CssClass="user-action-button is-edit"
                                    CommandName="EditUser"
                                    CommandArgument='<%# Eval("UserID") %>'
                                    CausesValidation="false"
                                >
                                    <i class="bi bi-pencil-square"></i>
                                    Sửa
                                </asp:LinkButton>
                                <asp:LinkButton
                                    ID="ActivateUserButton"
                                    runat="server"
                                    CssClass="user-action-button is-unlock"
                                    CommandName="SetActive"
                                    CommandArgument='<%# Eval("UserID") %>'
                                    CausesValidation="false"
                                    Visible='<%# Convert.ToString(Eval("Status")) != "ACTIVE" %>'
                                >
                                    <i class="bi bi-unlock"></i>
                                    Mở khóa
                                </asp:LinkButton>
                                <asp:LinkButton
                                    ID="LockUserButton"
                                    runat="server"
                                    CssClass="user-action-button is-lock"
                                    CommandName="SetLocked"
                                    CommandArgument='<%# Eval("UserID") %>'
                                    CausesValidation="false"
                                    Visible='<%# Convert.ToString(Eval("Status")) == "ACTIVE" %>'
                                    OnClientClick="return confirm('Khóa tài khoản này?');"
                                >
                                    <i class="bi bi-lock"></i>
                                    Khóa
                                </asp:LinkButton>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <asp:UpdatePanel ID="UserModalUpdatePanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
        <ContentTemplate>
    <asp:Panel ID="UserModalPanel" runat="server" CssClass="system-modal-backdrop user-modal-backdrop">
        <section class="system-modal" role="dialog" aria-modal="true" aria-labelledby="system-user-modal-title">
            <header class="system-modal-header">
                <div>
                    <small>
                        <i class="bi bi-person-vcard"></i>
                        Thông tin tài khoản
                    </small>
                    <h2 id="system-user-modal-title"><asp:Literal ID="UserFormTitle" runat="server" Text="Thêm người dùng mới" /></h2>
                    <p>Thông tin được dùng để đăng nhập và phân quyền trong hệ thống.</p>
                </div>
                <button type="button" class="system-modal-close" aria-label="Đóng" data-user-close="true">
                    <i class="bi bi-x-lg"></i>
                </button>
            </header>
            <asp:HiddenField ID="EditUserIdValue" runat="server" />
            <asp:HiddenField ID="UserModalOpenValue" runat="server" Value="0" />
            <div class="system-form-grid">
                <label>
                    <span>Tên đăng nhập *</span>
                    <asp:TextBox ID="NewUsernameText" runat="server" CssClass="form-control" MaxLength="100" />
                </label>
                <label>
                    <span>Họ và tên *</span>
                    <asp:TextBox ID="NewFullNameText" runat="server" CssClass="form-control" MaxLength="250" />
                </label>
                <label>
                    <span>Email *</span>
                    <asp:TextBox ID="NewEmailText" runat="server" CssClass="form-control" MaxLength="250" />
                </label>
                <label>
                    <span>Mật khẩu</span>
                    <asp:TextBox
                        ID="NewPasswordText"
                        runat="server"
                        CssClass="form-control"
                        TextMode="Password"
                        MaxLength="100"
                        placeholder="Tối thiểu 6 ký tự"
                    />
                </label>
                <label>
                    <span>Mã giảng viên</span>
                    <asp:TextBox ID="TeacherCodeText" runat="server" CssClass="form-control" MaxLength="100" placeholder="Ví dụ: GV0001" />
                </label>
                <label>
                    <span>Mã học viên</span>
                    <asp:TextBox ID="StudentCodeText" runat="server" CssClass="form-control" MaxLength="100" placeholder="Ví dụ: HV0001" />
                </label>
                <label class="system-avatar-field">
                    <span>Ảnh đại diện</span>
                    <asp:TextBox ID="AvatarUrlText" runat="server" CssClass="form-control" MaxLength="1000" />
                </label>
                <label>
                    <span>Trạng thái</span>
                    <asp:DropDownList ID="UserStatusList" runat="server" CssClass="form-select">
                        <asp:ListItem Value="ACTIVE">Đang hoạt động</asp:ListItem>
                        <asp:ListItem Value="INACTIVE">Ngừng hoạt động</asp:ListItem>
                        <asp:ListItem Value="LOCKED">Đã khóa</asp:ListItem>
                    </asp:DropDownList>
                </label>
            </div>
            <fieldset class="system-role-fieldset">
                <legend>Vai trò được cấp *</legend>
                <asp:CheckBoxList
                    ID="UserRolesList"
                    runat="server"
                    RepeatDirection="Horizontal"
                    RepeatLayout="Flow"
                    CssClass="system-role-options"
                >
                    <asp:ListItem Value="STUDENT" Selected="True">Học viên</asp:ListItem>
                    <asp:ListItem Value="TEACHER">Giảng viên</asp:ListItem>
                    <asp:ListItem Value="ADMIN">Quản trị</asp:ListItem>
                </asp:CheckBoxList>
            </fieldset>
            <footer class="system-modal-actions">
                <button type="button" class="btn btn-action-cancel" data-user-close="true">
                    <i class="bi bi-x-lg"></i>
                    Hủy
                </button>
                <asp:Button
                    ID="CancelUserButton"
                    runat="server"
                    Text="Hủy sửa"
                    CssClass="d-none"
                    Visible="false"
                    CausesValidation="false"
                    OnClick="CancelUserButton_Click"
                />
                <asp:Button
                    ID="CreateUserButton"
                    runat="server"
                    Text="Lưu người dùng"
                    CssClass="btn btn-action-save"
                    OnClick="CreateUserButton_Click"
                />
            </footer>
        </section>
    </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="CancelUserButton" />
            <asp:PostBackTrigger ControlID="CreateUserButton" />
        </Triggers>
    </asp:UpdatePanel>
</section>
<script src="<%= ResolveUrl("~/assets/lms/js/system-users-webforms.js") %>"></script>
