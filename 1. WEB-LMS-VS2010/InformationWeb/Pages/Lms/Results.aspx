<%@ Page Title="Kết quả học tập" Language="C#" MasterPageFile="~/MasterPages/Lms.Master" CodeBehind="Results.aspx.cs" Inherits="InformationWeb.Pages.Lms.Results" %>
<%@ Register Src="~/Controls/Lms/Results.ascx" TagPrefix="uc" TagName="Results" %>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server"><uc:Results ID="ResultsControl" runat="server" /></asp:Content>
