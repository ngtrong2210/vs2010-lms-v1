<%@ Page Title="Báo cáo" Language="C#" MasterPageFile="~/MasterPages/Cms.Master" CodeBehind="Reports.aspx.cs" Inherits="InformationWeb.Pages.Cms.Reports" %>
<%@ Register Src="~/Controls/Cms/Reports.ascx" TagPrefix="uc" TagName="Reports" %>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server"><uc:Reports ID="ReportsControl" runat="server" /></asp:Content>
