<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Students.ascx.cs" Inherits="InformationWeb.Controls.Cms.Students" %>
<section>
    <header class="page-header">
        <div>
            <h1 class="page-title"><asp:Literal ID="PageTitleText" runat="server" /></h1>
            <p class="page-subtitle"><asp:Literal ID="PageDescriptionText" runat="server" /></p>
        </div>
        <div class="page-actions">
            <a class="btn btn-primary" href="<%= ResolveUrl("~/cms/users") %>">
                <i class="bi bi-person-plus"></i>
                Thêm học viên
            </a>
        </div>
    </header>
    <div class="card card-filter mb-3">
        <div class="filter-group">
            <asp:TextBox ID="SearchText" runat="server" CssClass="form-control" placeholder="Tìm theo tên, mã học viên hoặc email..." />
            <asp:Button
                ID="SearchButton"
                runat="server"
                Text="Tìm kiếm"
                CssClass="btn btn-secondary"
                OnClick="SearchButton_Click"
            />
        </div>
    </div>
    <asp:Label ID="ErrorText" runat="server" CssClass="alert alert-danger" Visible="false" />
    <div class="card">
        <asp:Label ID="EmptyText" runat="server" CssClass="empty-state" Text="Chưa có học viên." Visible="false" />
        <div class="table-container">
            <asp:GridView
                ID="DataGrid"
                runat="server"
                CssClass="lms-table"
                AutoGenerateColumns="false"
                AllowPaging="true"
                PageSize="20"
                OnPageIndexChanging="DataGrid_PageIndexChanging"
            >
                <Columns>
                    <asp:TemplateField HeaderText="Học viên">
                        <ItemTemplate>
                            <div class="user-cell">
                                <span class="user-avatar-sm"><%# StudentInitials(Eval("FullName")) %></span>
                                <div>
                                    <strong><%# Eval("FullName") %></strong>
                                    <small class="d-block text-muted"><%# Eval("Email") %></small>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="StudentCode" HeaderText="Mã HV" />
                    <asp:BoundField DataField="CourseCount" HeaderText="Khóa học" />
                    <asp:TemplateField HeaderText="Tiến độ">
                        <ItemTemplate>
                            <div class="progress-cell">
                                <div class="progress">
                                    <div class="progress-bar" style='<%# StudentProgressStyle(Eval("ProgressPercent")) %>'></div>
                                </div>
                                <small><%# StudentPercent(Eval("ProgressPercent")) %>%</small>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Điểm TB">
                        <ItemTemplate><b><%# Eval("AverageScore", "{0:0.##}") %></b></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Trạng thái">
                        <ItemTemplate><span class='<%# "badge badge-" + StudentStatusClass(Eval("Status"), Eval("ProgressPercent")) %>'><%# StudentStatusLabel(Eval("Status"), Eval("ProgressPercent")) %></span></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <a class="btn btn-icon" title="Xem hồ sơ" href='<%# ResolveUrl("~/cms/users?search=" + Server.UrlEncode(Convert.ToString(Eval("StudentCode")))) %>'>
                                <i class="bi bi-chevron-right"></i>
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</section>
