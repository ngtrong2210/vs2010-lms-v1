<%@ Page Title="Biên tập video" Language="C#" MasterPageFile="~/MasterPages/Cms.Master" CodeBehind="VideoEditor.aspx.cs" Inherits="InformationWeb.Pages.Cms.VideoEditor" %>
<%@ Register Src="~/Controls/Cms/VideoEditor.ascx" TagPrefix="uc" TagName="VideoEditor" %>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <uc:VideoEditor ID="VideoEditorControl" runat="server" />
</asp:Content>
