<%@ Page Title="Thư viện khóa học" Language="C#" MasterPageFile="~/MasterPages/Cms.Master" CodeBehind="CourseLibrary.aspx.cs" Inherits="InformationWeb.Pages.Cms.CourseLibrary" %>
<%@ Register Src="~/Controls/Cms/CourseLibrary.ascx" TagPrefix="uc" TagName="CourseLibrary" %>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server"><uc:CourseLibrary ID="CourseLibraryControl" runat="server" /></asp:Content>
