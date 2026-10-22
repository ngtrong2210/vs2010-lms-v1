<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Roles.ascx.cs" Inherits="InformationWeb.Controls.Cms.Roles" %>
<link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/css/pages/cms/system-management.css") %>" />
<link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/css/pages/cms/system-management-webforms.css") %>" />
<section class="system-page">
    <header class="system-page-header">
        <div>
            <span class="system-kicker">
                <i class="bi bi-shield-check"></i>
                KIỂM SOÁT TRUY CẬP
            </span>
            <h1 class="page-title mb-1"><asp:Literal ID="PageTitleText" runat="server" /></h1>
            <p class="page-subtitle mb-0"><asp:Literal ID="PageDescriptionText" runat="server" /></p>
        </div>
        <div class="cms-page-actions">
            <asp:Button
                ID="SavePermissionsButton"
                runat="server"
                Text="Lưu phân quyền"
                CssClass="btn btn-action-save"
                OnClick="SavePermissionsButton_Click"
            />
        </div>
    </header>
    <asp:Label ID="ActionMessageText" runat="server" Visible="false" />
    <asp:Label ID="ErrorText" runat="server" CssClass="alert alert-danger" Visible="false" />
    <div class="role-layout">
        <aside class="app-card role-list-card">
            <header>
                <h2>Nhóm vai trò</h2>
                <small>
                    <asp:Literal ID="RoleCountText" runat="server" />
                    vai trò hệ thống
                </small>
            </header>
            <asp:Repeater ID="RolesRepeater" runat="server">
                <ItemTemplate>
                    <a class='<%# RoleCardClass(Eval("RoleID")) %>' href='<%# RoleUrl(Eval("RoleID")) %>'>
                        <i class='<%# "bi " + RoleIcon(Eval("Code")) %>'></i>
                        <span>
                            <strong><%# Server.HtmlEncode(Convert.ToString(Eval("Name"))) %></strong>
                            <small><%# Eval("UserCount") %> người dùng · <%# Eval("PermissionCount") %> quyền</small>
                        </span>
                        <i class="bi bi-chevron-right"></i>
                    </a>
                </ItemTemplate>
            </asp:Repeater>
        </aside>
        <div class="app-card permission-panel">
            <header class="permission-panel-header">
                <div>
                    <span class="system-kicker"><asp:Literal ID="SelectedRoleCodeText" runat="server" /></span>
                    <h2><asp:Literal ID="SelectedRoleNameText" runat="server" /></h2>
                    <p><asp:Literal ID="SelectedRoleDescriptionText" runat="server" /></p>
                </div>
                <span class="permission-count">
                    <strong><asp:Literal ID="GrantedPermissionCountText" runat="server" /></strong>
                    <small>
                        /
                        <asp:Literal ID="PermissionCountText" runat="server" />
                        quyền
                    </small>
                </span>
            </header>
            <asp:Label ID="PermissionEmptyText" runat="server" CssClass="empty-state" Text="Chọn một vai trò để xem quyền." />
            <div class="permission-groups" data-permission-groups="true"></div>
        </div>
    </div>
    <asp:TextBox ID="SearchText" runat="server" CssClass="d-none" />
    <asp:Button ID="SearchButton" runat="server" Text="Nạp lại" CssClass="d-none" OnClick="SearchButton_Click" />
    <asp:TextBox ID="RoleIdText" runat="server" CssClass="d-none" />
    <asp:TextBox ID="PermissionCodesText" runat="server" CssClass="d-none" TextMode="MultiLine" />
    <asp:HiddenField ID="PermissionsJsonValue" runat="server" />
    <asp:HiddenField ID="SelectedRoleCodeValue" runat="server" />
    <asp:Label ID="EmptyText" runat="server" Visible="false" />
    <asp:GridView ID="DataGrid" runat="server" CssClass="d-none" AutoGenerateColumns="true" OnRowCommand="RolesGrid_RowCommand" />
    <asp:GridView ID="PermissionsGrid" runat="server" CssClass="d-none" AutoGenerateColumns="true" />
</section>
<script src="<%= ResolveUrl("~/assets/lms/js/system-roles-webforms.js") %>"></script>
