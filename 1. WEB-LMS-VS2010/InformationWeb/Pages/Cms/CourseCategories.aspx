<%@ Page Title="Danh mục khóa học" Language="C#" MasterPageFile="~/MasterPages/Cms.Master" CodeBehind="CourseCategories.aspx.cs" Inherits="InformationWeb.Pages.Cms.CourseCategories" %>
<%@ Register Src="~/Controls/Cms/CourseCategories.ascx" TagPrefix="uc" TagName="CourseCategories" %>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server"><uc:CourseCategories ID="CourseCategoriesControl" runat="server" /></asp:Content>
