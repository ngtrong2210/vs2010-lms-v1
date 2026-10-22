<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Results.ascx.cs" Inherits="InformationWeb.Controls.Lms.Results" %>
<link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/css/pages/lms/results.css") %>" />
<section>
    <header class="mb-4">
        <h1 class="page-title"><asp:Literal ID="PageTitleText" runat="server" /></h1>
        <p class="page-subtitle"><asp:Literal ID="PageDescriptionText" runat="server" /></p>
        <asp:Button ID="RefreshButton" runat="server" Text="Cập nhật" CssClass="d-none" OnClick="RefreshButton_Click" />
    </header>
    <asp:Label ID="ErrorText" runat="server" CssClass="alert alert-danger status-message" Visible="false" />
    <asp:GridView ID="DataGrid" runat="server" CssClass="d-none" AutoGenerateColumns="true" />
    <asp:Label
        ID="EmptyText"
        runat="server"
        CssClass="app-card p-5 text-center text-secondary"
        Text="Chưa có kết quả học tập."
        Visible="false"
    />
    <div class="row g-4">
        <asp:Repeater ID="CourseResultsRepeater" runat="server">
            <ItemTemplate>
                <div class="col-lg-6">
                    <article class="app-card p-4">
                        <div class="d-flex justify-content-between gap-3">
                            <div>
                                <span class="badge badge-soft-primary"><%# Eval("Code") %></span>
                                <h2 class="h5 fw-bold mt-2"><%# Eval("Title") %></h2>
                            </div>
                            <strong class="result-score"><%# ScoreText(Eval("FinalScore")) %></strong>
                        </div>
                        <div class="d-flex justify-content-between small mt-3">
                            <span>Tiến độ</span>
                            <b><%# Eval("ProgressPercent") %>%</b>
                        </div>
                        <div class="progress result-progress my-2"><div class="progress-bar" style='<%# ProgressStyle(Eval("ProgressPercent")) %>'></div></div>
                        <div class="small text-secondary"><%# Eval("CorrectCount") %>/<%# Eval("AnswerCount") %> câu trả lời đúng</div>
                    </article>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <asp:GridView ID="LessonGrid" runat="server" CssClass="d-none" AutoGenerateColumns="true" />
</section>
