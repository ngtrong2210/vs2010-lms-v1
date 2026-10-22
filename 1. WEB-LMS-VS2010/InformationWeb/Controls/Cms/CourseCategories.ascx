<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CourseCategories.ascx.cs" Inherits="InformationWeb.Controls.Cms.CourseCategories" %>
<link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/css/pages/cms/category-management.css") %>" />
<section class="category-management-page">
    <header class="d-flex flex-wrap justify-content-between align-items-end gap-3 mb-4">
        <div>
            <span class="eyebrow">QUẢN LÝ DANH MỤC</span>
            <h1 class="page-title mb-1">Danh mục khóa học</h1>
            <p class="page-subtitle mb-0">Tổ chức khóa học vào các danh mục để quản lý và tìm kiếm dễ dàng hơn.</p>
        </div>
        <div class="cms-page-actions">
            <asp:Button ID="AddCategoryButton" runat="server" CssClass="btn btn-action-save" Text="Thêm danh mục" OnClick="AddCategoryButton_Click" />
        </div>
    </header>

    <asp:Label ID="ActionMessageText" runat="server" Visible="false" />

    <div class="app-card category-list">
        <asp:GridView ID="CategoryGrid" runat="server" AutoGenerateColumns="false"
            CssClass="data-table" GridLines="None" AllowPaging="true" PageSize="20"
            OnRowCommand="CategoryGrid_RowCommand" OnRowCreated="CategoryGrid_RowCreated"
            OnPageIndexChanging="CategoryGrid_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="CourseCategoryID" HeaderText="ID" HeaderStyle-Width="80" />
                <asp:BoundField DataField="Code" HeaderText="Mã" HeaderStyle-Width="120" />
                <asp:BoundField DataField="Name" HeaderText="Tên danh mục" />
                <asp:BoundField DataField="Description" HeaderText="Mô tả" />
                <asp:BoundField DataField="SortOrder" HeaderText="Thứ tự" HeaderStyle-Width="100" />
                <asp:TemplateField HeaderText="Trạng thái" HeaderStyle-Width="120">
                    <ItemTemplate>
                        <asp:Label ID="StatusLabel" runat="server" CssClass="status-badge" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Thao tác" HeaderStyle-Width="150">
                    <ItemTemplate>
                        <asp:Button ID="EditButton" runat="server" CommandName="EditCategory"
                            CommandArgument='<%# Eval("CourseCategoryID") %>' CssClass="btn btn-sm btn-secondary"
                            Text="Sửa" />
                        <asp:Button ID="DeleteButton" runat="server" CommandName="DeleteCategory"
                            CommandArgument='<%# Eval("CourseCategoryID") %>' CssClass="btn btn-sm btn-danger"
                            Text="Xóa" OnClientClick="return confirm('Bạn có chắc muốn xóa danh mục này?');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <div class="empty-data">Không có danh mục nào. Hãy thêm danh mục mới.</div>
            </EmptyDataTemplate>
        </asp:GridView>
    </div>

    <asp:Panel ID="EditPanel" runat="server" CssClass="app-card edit-panel" Visible="false">
        <h3 class="card-title">
            <asp:Literal ID="EditPanelTitle" runat="server" />
        </h3>
        <div class="form-row">
            <div class="form-group">
                <label>Mã danh mục</label>
                <asp:TextBox ID="CodeText" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label>Tên danh mục <span class="required">*</span></label>
                <asp:TextBox ID="NameText" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="NameRequired" runat="server" ControlToValidate="NameText"
                    ErrorMessage="Vui lòng nhập tên danh mục" CssClass="text-danger" Display="Dynamic" />
            </div>
        </div>
        <div class="form-group">
            <label>Mô tả</label>
            <asp:TextBox ID="DescriptionText" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
        </div>
        <div class="form-row">
            <div class="form-group">
                <label>Thứ tự</label>
                <asp:TextBox ID="SortOrderText" runat="server" CssClass="form-control" TextMode="Number" Value="0" />
            </div>
            <div class="form-group">
                <label>Trạng thái</label>
                <asp:DropDownList ID="StatusList" runat="server" CssClass="form-control">
                    <asp:ListItem Value="ACTIVE" Text="Hoạt động" />
                    <asp:ListItem Value="INACTIVE" Text="Tạm dừng" />
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-actions">
            <asp:Button ID="SaveButton" runat="server" CssClass="btn btn-action-save" Text="Lưu" OnClick="SaveButton_Click" />
            <asp:Button ID="CancelButton" runat="server" CssClass="btn btn-secondary" Text="Hủy" OnClick="CancelButton_Click" />
        </div>
        <asp:HiddenField ID="CategoryIdValue" runat="server" />
    </asp:Panel>
</section>
