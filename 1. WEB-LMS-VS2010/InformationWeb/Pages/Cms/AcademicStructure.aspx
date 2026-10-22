<%@ Page Title="Cơ cấu đào tạo" Language="C#" MasterPageFile="~/MasterPages/Cms.Master" CodeBehind="AcademicStructure.aspx.cs" Inherits="InformationWeb.Pages.Cms.AcademicStructure" %>
<%@ Register Src="~/Controls/Cms/AcademicStructure.ascx" TagPrefix="uc" TagName="AcademicStructure" %>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <uc:AcademicStructure ID="AcademicStructureControl" runat="server" />
</asp:Content>
