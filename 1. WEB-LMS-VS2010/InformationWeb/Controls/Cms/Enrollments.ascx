<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Enrollments.ascx.cs" Inherits="InformationWeb.Controls.Cms.Enrollments" %>
<div class="page-heading">
    <div>
        <h1><asp:Literal ID="PageTitleText" runat="server" /></h1>
        <p><asp:Literal ID="PageDescriptionText" runat="server" /></p>
    </div>
</div>
<asp:Label ID="ActionMessageText" runat="server" Visible="false" />
<section class="surface-card mb-4">
    <div class="card-header"><h2 class="h5 mb-0">Thao tác ghi danh</h2></div>
    <div class="card-body">
        <div class="row g-3">
            <div class="col-md-3">
                <label class="form-label">ID môn học</label>
                <asp:TextBox ID="EnrollmentCourseIdText" runat="server" CssClass="form-control" />
            </div>
            <div class="col-md-3">
                <label class="form-label">ID học viên</label>
                <asp:TextBox ID="EnrollmentStudentIdText" runat="server" CssClass="form-control" />
            </div>
            <div class="col-md-2 d-flex align-items-end">
                <asp:Button ID="EnrollButton" runat="server" Text="Ghi danh" CssClass="btn btn-primary" OnClick="EnrollButton_Click" />
            </div>
            <div class="col-md-2">
                <label class="form-label">ID ghi danh</label>
                <asp:TextBox ID="EnrollmentIdText" runat="server" CssClass="form-control" />
            </div>
            <div class="col-md-2 d-flex align-items-end">
                <asp:Button
                    ID="CancelEnrollmentButton"
                    runat="server"
                    Text="Hủy ghi danh"
                    CssClass="btn btn-outline-danger"
                    OnClick="CancelEnrollmentButton_Click"
                />
            </div>
        </div>
    </div>
</section>
<div class="surface-card">
    <div class="card-header d-flex gap-2">
        <asp:TextBox ID="SearchText" runat="server" CssClass="form-control d-none" />
        <asp:Button ID="SearchButton" runat="server" Text="Nạp lại" CssClass="btn btn-primary" OnClick="SearchButton_Click" />
    </div>
    <asp:Label ID="ErrorText" runat="server" CssClass="alert alert-danger m-3" Visible="false" />
    <asp:Label ID="EmptyText" runat="server" CssClass="empty-state" Text="Chưa có dữ liệu ghi danh." Visible="false" />
    <div class="table-responsive">
        <asp:GridView
            ID="DataGrid"
            runat="server"
            CssClass="table table-hover"
            AutoGenerateColumns="true"
            AllowPaging="true"
            PageSize="20"
            OnPageIndexChanging="DataGrid_PageIndexChanging"
        />
    </div>
</div>
