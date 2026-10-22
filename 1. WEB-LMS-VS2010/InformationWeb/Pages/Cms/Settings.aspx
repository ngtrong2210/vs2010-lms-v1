<%@ Page Title="Cài đặt hệ thống" Language="C#" MasterPageFile="~/MasterPages/Cms.Master" CodeBehind="Settings.aspx.cs" Inherits="InformationWeb.Pages.Cms.Settings" %>
<%@ Register Src="~/Controls/Cms/Settings.ascx" TagPrefix="uc" TagName="Settings" %>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server"><uc:Settings ID="SettingsControl" runat="server" /></asp:Content>
