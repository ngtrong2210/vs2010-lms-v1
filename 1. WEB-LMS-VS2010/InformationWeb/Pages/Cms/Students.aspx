<%@ Page Title="Học viên" Language="C#" MasterPageFile="~/MasterPages/Cms.Master" CodeBehind="Students.aspx.cs" Inherits="InformationWeb.Pages.Cms.Students" %>
<%@ Register Src="~/Controls/Cms/Students.ascx" TagPrefix="uc" TagName="Students" %>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server"><uc:Students ID="StudentsControl" runat="server" /></asp:Content>
