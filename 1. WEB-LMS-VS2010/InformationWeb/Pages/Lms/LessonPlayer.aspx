<%@ Page Title="Bài học" Language="C#" MasterPageFile="~/MasterPages/Lms.Master" ValidateRequest="false" CodeBehind="LessonPlayer.aspx.cs" Inherits="InformationWeb.Pages.Lms.LessonPlayer" %>
<%@ Register Src="~/Controls/Lms/LessonPlayer.ascx" TagPrefix="uc" TagName="LessonPlayer" %>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <uc:LessonPlayer ID="LessonPlayerControl" runat="server" />
</asp:Content>
