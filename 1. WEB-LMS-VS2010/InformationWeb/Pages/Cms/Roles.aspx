<%@ Page Title="Phân quyền" Language="C#" MasterPageFile="~/MasterPages/Cms.Master" CodeBehind="Roles.aspx.cs" Inherits="InformationWeb.Pages.Cms.Roles" %>
<%@ Register Src="~/Controls/Cms/Roles.ascx" TagPrefix="uc" TagName="Roles" %>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server"><uc:Roles ID="RolesControl" runat="server" /></asp:Content>
