<%@ Page Title="Soạn môn học" Language="C#" MasterPageFile="~/MasterPages/Cms.Master" CodeBehind="Courses.aspx.cs" Inherits="InformationWeb.Pages.Cms.Courses" %>
<%@ Register Src="~/Controls/Cms/Courses.ascx" TagPrefix="uc" TagName="Courses" %>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server"><uc:Courses ID="CoursesControl" runat="server" /></asp:Content>
