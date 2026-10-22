<%@ Page Title="Môn học của tôi" Language="C#" MasterPageFile="~/MasterPages/Lms.Master" CodeBehind="Courses.aspx.cs" Inherits="InformationWeb.Pages.Lms.Courses" %>
<%@ Register Src="~/Controls/Lms/Courses.ascx" TagPrefix="uc" TagName="Courses" %>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server"><uc:Courses ID="CoursesControl" runat="server" /></asp:Content>
