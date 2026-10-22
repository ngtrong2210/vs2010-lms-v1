<%@ Page Title="Trợ giúp" Language="C#" MasterPageFile="~/MasterPages/Cms.Master" CodeBehind="Help.aspx.cs" Inherits="InformationWeb.Pages.Cms.Help" %>
<%@ Register Src="~/Controls/Cms/Help.ascx" TagPrefix="uc" TagName="Help" %>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server"><uc:Help ID="HelpControl" runat="server" /></asp:Content>
