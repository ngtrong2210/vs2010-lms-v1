<%@ Page Title="Tìm kiếm" Language="C#" MasterPageFile="~/MasterPages/Cms.Master" CodeBehind="Search.aspx.cs" Inherits="InformationWeb.Pages.Cms.Search" %>
<%@ Register Src="~/Controls/Cms/Search.ascx" TagPrefix="uc" TagName="Search" %>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server"><uc:Search ID="SearchControl" runat="server" /></asp:Content>
