<%@ Page Title="Chi tiết môn học" Language="C#" MasterPageFile="~/MasterPages/Lms.Master" CodeBehind="Course.aspx.cs" Inherits="InformationWeb.Pages.Lms.Course" %>
<%@ Register Src="~/Controls/Lms/Course.ascx" TagPrefix="uc" TagName="Course" %>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server"><uc:Course ID="CourseControl" runat="server" /></asp:Content>
