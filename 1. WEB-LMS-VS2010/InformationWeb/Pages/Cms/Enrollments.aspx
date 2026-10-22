<%@ Page Title="Ghi danh" Language="C#" MasterPageFile="~/MasterPages/Cms.Master" CodeBehind="Enrollments.aspx.cs" Inherits="InformationWeb.Pages.Cms.Enrollments" %>
<%@ Register Src="~/Controls/Cms/Enrollments.ascx" TagPrefix="uc" TagName="Enrollments" %>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <uc:Enrollments ID="EnrollmentsControl" runat="server" />
</asp:Content>
