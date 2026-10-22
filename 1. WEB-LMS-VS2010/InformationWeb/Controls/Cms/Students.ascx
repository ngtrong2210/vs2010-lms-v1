<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Students.ascx.cs" Inherits="InformationWeb.Controls.Cms.Students" %>
<link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/css/pages/cms/students.css") %>" />
<section>
    <header class="d-flex flex-wrap justify-content-between align-items-end gap-3 mb-4">
        <div>
            <h1 class="page-title mb-1"><asp:Literal ID="PageTitleText" runat="server" /></h1>
            <p class="page-subtitle mb-0"><asp:Literal ID="PageDescriptionText" runat="server" /></p>
        </div>
        <div class="cms-page-actions">
            <a class="btn btn-action-create" href="<%= ResolveUrl("~/cms/users") %>">
                <i class="bi bi-person-plus"></i>
                Thêm học viên
            </a>
        </div>
    </header>
    <div class="app-card p-3 mb-3">
        <div class="row g-2 align-items-center flex-wrap">
            <div class="col cms-control-slot cms-control-slot-grow">
                <asp:TextBox ID="SearchText" runat="server" CssClass="form-control" placeholder="Tìm theo tên, mã học viên hoặc email..." />
            </div>
            <div class="col-auto cms-control-actions">
                <asp:Button
                    ID="SearchButton"
                    runat="server"
                    Text="Tìm kiếm"
                    CssClass="btn btn-action-filter"
                    OnClick="SearchButton_Click"
                />
            </div>
        </div>
    </div>
    <asp:Label ID="ErrorText" runat="server" CssClass="alert alert-danger" Visible="false" />
    <div class="app-card p-2">
        <asp:Label ID="EmptyText" runat="server" CssClass="empty-state" Text="Chưa có học viên." Visible="false" />
        <div class="table-responsive">
            <asp:GridView
                ID="DataGrid"
                runat="server"
                CssClass="table align-middle mb-0"
                AutoGenerateColumns="false"
                AllowPaging="true"
                PageSize="20"
                OnPageIndexChanging="DataGrid_PageIndexChanging"
            >
                <Columns>
                    <asp:TemplateField HeaderText="Học viên">
                        <ItemTemplate>
                            <div class="d-flex align-items-center gap-2">
                                <span class="avatar"><%# StudentInitials(Eval("FullName")) %></span>
                                <div>
                                    <strong><%# Eval("FullName") %></strong>
                                    <small class="d-block text-secondary"><%# Eval("Email") %></small>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="StudentCode" HeaderText="Mã HV" />
                    <asp:BoundField DataField="CourseCount" HeaderText="Khóa học" />
                    <asp:TemplateField HeaderText="Tiến độ">
                        <ItemTemplate>
                            <div class="d-flex align-items-center gap-2">
                                <div class="progress student-progress">
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
                        <ItemTemplate><span class='<%# "badge " + StudentStatusClass(Eval("Status"), Eval("ProgressPercent")) %>'><%# StudentStatusLabel(Eval("Status"), Eval("ProgressPercent")) %></span></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <a class="btn btn-action-view btn-sm" title="Xem hồ sơ" href='<%# ResolveUrl("~/cms/users?search=" + Server.UrlEncode(Convert.ToString(Eval("StudentCode")))) %>'>
                                <i class="bi bi-chevron-right"></i>
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</section>
