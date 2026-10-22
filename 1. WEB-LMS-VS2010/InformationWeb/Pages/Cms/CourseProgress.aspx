<%@ Page Title="Theo dõi tiến độ" Language="C#" MasterPageFile="~/MasterPages/Cms.Master" CodeBehind="CourseProgress.aspx.cs" Inherits="InformationWeb.Pages.Cms.CourseProgress" %>
<%@ Register Src="~/Controls/Cms/CourseProgress.ascx" TagPrefix="uc" TagName="CourseProgress" %>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server"><uc:CourseProgress ID="CourseProgressControl" runat="server" /></asp:Content>
