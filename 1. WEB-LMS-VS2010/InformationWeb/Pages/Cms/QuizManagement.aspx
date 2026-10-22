<%@ Page Title="Quản lý bài kiểm tra" Language="C#" MasterPageFile="~/MasterPages/Cms.Master" CodeBehind="QuizManagement.aspx.cs" Inherits="InformationWeb.Pages.Cms.QuizManagement" %>
<%@ Register Src="~/Controls/Cms/QuizManagement.ascx" TagPrefix="uc" TagName="QuizManagement" %>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server"><uc:QuizManagement ID="QuizManagementControl" runat="server" /></asp:Content>
