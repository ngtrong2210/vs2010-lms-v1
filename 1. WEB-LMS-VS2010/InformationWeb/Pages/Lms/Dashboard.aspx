<%@ Page Title="Tổng quan học tập" Language="C#" MasterPageFile="~/MasterPages/Lms.Master" CodeBehind="Dashboard.aspx.cs" Inherits="InformationWeb.Pages.Lms.Dashboard" %>
<%@ Register Src="~/Controls/Lms/Dashboard.ascx" TagPrefix="uc" TagName="Dashboard" %>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server"><uc:Dashboard ID="DashboardControl" runat="server" /></asp:Content>
