<%@ Page Title="Thư viện video" Language="C#" MasterPageFile="~/MasterPages/Cms.Master" CodeBehind="VideoLibrary.aspx.cs" Inherits="InformationWeb.Pages.Cms.VideoLibrary" %>
<%@ Register Src="~/Controls/Cms/VideoLibrary.ascx" TagPrefix="uc" TagName="VideoLibrary" %>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <uc:VideoLibrary ID="VideoLibraryControl" runat="server" />
</asp:Content>
