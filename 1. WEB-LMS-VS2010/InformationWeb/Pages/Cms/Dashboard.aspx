<%@ Page Title="Tổng quan" Language="C#" MasterPageFile="~/MasterPages/Cms.Master" CodeBehind="Dashboard.aspx.cs" Inherits="InformationWeb.Pages.Cms.Dashboard" %>
<%@ Register Src="~/Controls/Cms/Dashboard.ascx" TagPrefix="uc" TagName="Dashboard" %>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server"><uc:Dashboard ID="DashboardControl" runat="server" /></asp:Content>
