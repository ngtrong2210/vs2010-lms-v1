<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Course.ascx.cs" Inherits="InformationWeb.Controls.Lms.Course" %>
<div class="page-heading">
    <div>
        <span class="badge text-bg-light"><asp:Literal ID="CourseCodeText" runat="server" /></span>
        <h1><asp:Literal ID="CourseTitleText" runat="server" /></h1>
        <p><asp:Literal ID="CourseDescriptionText" runat="server" /></p>
    </div>
    <a class="btn btn-outline-secondary" href="<%= ResolveUrl("~/lms/courses") %>">Quay lại</a>
</div>
<asp:Label ID="ErrorText" runat="server" CssClass="alert alert-danger status-message" Visible="false" />
<asp:Label
    ID="EmptyText"
    runat="server"
    CssClass="empty-state"
    Text="Không tìm thấy môn học hoặc bạn chưa được ghi danh."
    Visible="false"
/>
<div class="row g-4">
    <div class="col-lg-4">
        <section class="surface-card h-100">
            <div class="card-header"><h2 class="h5 mb-0">Chương học</h2></div>
            <div class="table-responsive">
                <asp:GridView ID="ChapterGrid" runat="server" CssClass="table table-hover mb-0" AutoGenerateColumns="true" />
            </div>
        </section>
    </div>
    <div class="col-lg-8">
        <section class="surface-card">
            <div class="card-header d-flex justify-content-between">
                <h2 class="h5 mb-0">Danh sách bài học</h2>
                <span>
                    Tiến độ:
                    <strong><asp:Literal ID="ProgressText" runat="server" /></strong>
                    %
                </span>
            </div>
            <div class="table-responsive">
                <asp:GridView ID="LessonGrid" runat="server" CssClass="table table-hover mb-0" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="Title" HeaderText="Bài học" />
                        <asp:BoundField DataField="LessonType" HeaderText="Loại" />
                        <asp:BoundField DataField="ProgressPercent" HeaderText="Tiến độ (%)" />
                        <asp:BoundField DataField="Score" HeaderText="Điểm" />
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate><a class="btn btn-sm btn-primary" href='<%# LessonUrl(Eval("Id")) %>'>Mở bài</a></ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </section>
    </div>
</div>
