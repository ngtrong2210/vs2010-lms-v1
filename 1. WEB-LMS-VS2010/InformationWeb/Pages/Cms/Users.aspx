<%@ Page Title="Người dùng" Language="C#" MasterPageFile="~/MasterPages/Cms.Master" CodeBehind="Users.aspx.cs" Inherits="InformationWeb.Pages.Cms.Users" %>
<%@ Register Src="~/Controls/Cms/Users.ascx" TagPrefix="uc" TagName="Users" %>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server"><uc:Users ID="UsersControl" runat="server" /></asp:Content>
