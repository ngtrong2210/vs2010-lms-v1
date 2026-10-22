<%@ Page Title="Nội dung môn học" Language="C#" MasterPageFile="~/MasterPages/Cms.Master" ValidateRequest="false" CodeBehind="ContentBuilder.aspx.cs" Inherits="InformationWeb.Pages.Cms.ContentBuilder" %>
<%@ Register Src="~/Controls/Cms/ContentBuilder.ascx" TagPrefix="uc" TagName="ContentBuilder" %>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <uc:ContentBuilder ID="ContentBuilderControl" runat="server" />
</asp:Content>
