<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Profile.ascx.cs" Inherits="InformationWeb.Controls.Lms.Profile" %>
<link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/css/pages/lms/simple.css") %>" />
<section>
    <div class="app-card empty">
        <i class="bi bi-person"></i>
        <h1 class="page-title">Hồ sơ cá nhân</h1>
        <p class="page-subtitle">Khu vực này đã sẵn sàng để đồng bộ dữ liệu từ hồ sơ học tập của bạn.</p>
        <span class="d-none">
            <asp:Literal ID="FullNameText" runat="server" />
            <asp:Literal ID="UsernameText" runat="server" />
            <asp:Literal ID="EmailText" runat="server" />
            <asp:Literal ID="StudentCodeText" runat="server" />
        </span>
        <a href="<%= ResolveUrl("~/lms/dashboard") %>" class="btn btn-brand">
            <i class="bi bi-arrow-left"></i>
            Về tổng quan
        </a>
    </div>
</section>
