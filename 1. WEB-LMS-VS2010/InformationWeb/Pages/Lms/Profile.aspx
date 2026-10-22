<%@ Page Title="Hồ sơ" Language="C#" MasterPageFile="~/MasterPages/Lms.Master" CodeBehind="Profile.aspx.cs" Inherits="InformationWeb.Pages.Lms.Profile" %>
<%@ Register Src="~/Controls/Lms/Profile.ascx" TagPrefix="uc" TagName="Profile" %>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server"><uc:Profile ID="ProfileControl" runat="server" /></asp:Content>
