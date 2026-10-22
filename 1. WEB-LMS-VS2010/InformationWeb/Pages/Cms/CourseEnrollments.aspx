<%@ Page Title="Quản lý đăng ký" Language="C#" MasterPageFile="~/MasterPages/Cms.Master" CodeBehind="CourseEnrollments.aspx.cs" Inherits="InformationWeb.Pages.Cms.CourseEnrollments" %>
<%@ Register Src="~/Controls/Cms/CourseEnrollments.ascx" TagPrefix="uc" TagName="CourseEnrollments" %>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server"><uc:CourseEnrollments ID="CourseEnrollmentsControl" runat="server" /></asp:Content>
