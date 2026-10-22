<%@ Page Title="Ngân hàng câu hỏi" Language="C#" MasterPageFile="~/MasterPages/Cms.Master" CodeBehind="Questions.aspx.cs" Inherits="InformationWeb.Pages.Cms.Questions" %>
<%@ Register Src="~/Controls/Cms/Questions.ascx" TagPrefix="uc" TagName="Questions" %>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server"><uc:Questions ID="QuestionsControl" runat="server" /></asp:Content>
