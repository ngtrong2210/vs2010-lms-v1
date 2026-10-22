<%@ Page Title="Chấm bài" Language="C#" MasterPageFile="~/MasterPages/Cms.Master" CodeBehind="AssignmentGrading.aspx.cs" Inherits="InformationWeb.Pages.Cms.AssignmentGrading" %>
<%@ Register Src="~/Controls/Cms/AssignmentGrading.ascx" TagPrefix="uc" TagName="AssignmentGrading" %>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <uc:AssignmentGrading ID="AssignmentGradingControl" runat="server" />
</asp:Content>
