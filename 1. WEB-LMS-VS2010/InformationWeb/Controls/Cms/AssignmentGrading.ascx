<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AssignmentGrading.ascx.cs" Inherits="InformationWeb.Controls.Cms.AssignmentGrading" %>
<link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/css/pages/cms/assignment-grading.css") %>" />
<link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/css/pages/cms/assignment-grading-webforms.css") %>" />
<section class="grading-page">
    <header class="d-flex flex-wrap justify-content-between align-items-end gap-3 mb-4">
        <div>
            <span class="grading-eyebrow">BÀI TẬP MÔN HỌC LỚP</span>
            <h1 class="page-title mb-1"><asp:Literal ID="PageTitleText" runat="server" /></h1>
            <p class="page-subtitle mb-0"><asp:Literal ID="PageDescriptionText" runat="server" /></p>
        </div>
        <div class="cms-page-actions">
            <a class="btn btn-action-view" href="<%= ResolveUrl("~/cms/courses") %>">
                <i class="bi bi-journal-text"></i>
                Soạn môn học lớp
            </a>
        </div>
    </header>
    <asp:Label ID="ActionMessageText" runat="server" Visible="false" />
    <div class="app-card grading-filters">
        <label class="grading-search">
            <span>Tìm học viên hoặc bài tập</span>
            <div class="grading-search-control">
                <div>
                    <i class="bi bi-search"></i>
                    <asp:TextBox
                        ID="SearchText"
                        runat="server"
                        CssClass="form-control"
                        placeholder="Mã sinh viên, họ tên, môn học, tên bài tập..."
                    />
                </div>
                <asp:Button ID="SearchButton" runat="server" Text="Tìm kiếm" CssClass="btn btn-action-view" OnClick="SearchButton_Click" />
            </div>
        </label>
        <label>
            <span>Môn học lớp</span>
            <asp:DropDownList ID="ClassSubjectFilterList" runat="server" CssClass="form-select">
                <asp:ListItem Value="">Tất cả môn học lớp</asp:ListItem>
            </asp:DropDownList>
        </label>
        <label>
            <span>Trạng thái</span>
            <asp:DropDownList ID="SubmissionStatusFilterList" runat="server" CssClass="form-select">
                <asp:ListItem Value="">Tất cả trạng thái</asp:ListItem>
                <asp:ListItem Value="SUBMITTED">Chờ chấm</asp:ListItem>
                <asp:ListItem Value="GRADED">Đã chấm</asp:ListItem>
                <asp:ListItem Value="RETURNED">Đã trả bổ sung</asp:ListItem>
                <asp:ListItem Value="DRAFT">Bản nháp</asp:ListItem>
            </asp:DropDownList>
        </label>
        <label>
            <span>Số dòng mỗi trang</span>
            <span class="form-control grading-page-size">20 dòng</span>
        </label>
    </div>
    <asp:Label ID="ErrorText" runat="server" CssClass="alert alert-danger" Visible="false" />
    <div class="app-card grading-table-card">
        <asp:Label ID="EmptyText" runat="server" CssClass="empty-state" Text="Chưa có bài nộp phù hợp." Visible="false" />
        <div class="table-responsive">
            <asp:GridView
                ID="DataGrid"
                runat="server"
                CssClass="table align-middle mb-0 grading-table"
                AutoGenerateColumns="false"
                AllowPaging="true"
                PageSize="20"
                OnPageIndexChanging="DataGrid_PageIndexChanging"
                OnRowCreated="DataGrid_RowCreated"
                OnRowCommand="DataGrid_RowCommand"
            >
                <Columns>
                    <asp:TemplateField HeaderText="STT"><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
                    <asp:TemplateField HeaderText="Học viên">
                        <ItemTemplate>
                            <strong><%# Server.HtmlEncode(Convert.ToString(Eval("StudentName"))) %></strong>
                            <small><%# Server.HtmlEncode(Convert.ToString(Eval("StudentCode"))) %> · <%# Server.HtmlEncode(Convert.ToString(Eval("ClassName"))) %></small>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Môn học lớp">
                        <ItemTemplate>
                            <strong><%# Server.HtmlEncode(Convert.ToString(Eval("SubjectName"))) %></strong>
                            <small><%# Server.HtmlEncode(Convert.ToString(Eval("YearName"))) %> · HK<%# Eval("Semester") %></small>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Bài tập">
                        <ItemTemplate>
                            <strong><%# Server.HtmlEncode(Convert.ToString(Eval("LessonTitle"))) %></strong>
                            <small><%# Server.HtmlEncode(Convert.ToString(Eval("ChapterTitle"))) %></small>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Lần nộp"><ItemTemplate>Lần <%# Eval("AttemptNumber") %></ItemTemplate></asp:TemplateField>
                    <asp:TemplateField HeaderText="Thời gian">
                        <ItemTemplate>
                            <strong><%# FormatSubmissionDate(Eval("SubmittedAt")) %></strong>
                            <small class="late-text"><%# IsTrue(Eval("IsLate")) ? "Nộp trễ" : string.Empty %></small>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Trạng thái">
                        <ItemTemplate><span class='<%# "badge " + SubmissionStatusClass(Eval("SubmissionStatus")) %>'><%# SubmissionStatusText(Eval("SubmissionStatus")) %></span></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Điểm">
                        <ItemTemplate><strong><%# SubmissionScoreText(Eval("Score"), Eval("AssignmentMaxScore")) %></strong></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Thao tác" ItemStyle-CssClass="text-end" HeaderStyle-CssClass="text-end">
                        <ItemTemplate>
                            <asp:LinkButton
                                ID="OpenGradingButton"
                                runat="server"
                                CssClass="btn btn-action-edit btn-sm"
                                CommandName="OpenGrading"
                                CommandArgument='<%# Eval("AssignmentSubmissionID") %>'
                                CausesValidation="false"
                            >
                                <i class="bi bi-clipboard-check"></i>
                                <%# Convert.ToString(Eval("SubmissionStatus")) == "GRADED" ? "Xem / sửa điểm" : "Chấm bài" %>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <asp:UpdatePanel ID="GradingModalUpdatePanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
        <ContentTemplate>
    <asp:Panel ID="GradingModal" runat="server" CssClass="modal-mask" Visible="false" data-grading-modal="true">
        <div class="app-card grading-modal" role="dialog" aria-modal="true" aria-labelledby="grading-modal-title">
            <div class="modal-heading">
                <div>
                    <small>
                        CHẤM BÀI · LẦN
                        <asp:Literal ID="SelectedAttemptText" runat="server" />
                    </small>
                    <h2 id="grading-modal-title"><asp:Literal ID="SelectedLessonText" runat="server" /></h2>
                    <p><asp:Literal ID="SelectedStudentText" runat="server" /></p>
                </div>
                <button type="button" class="btn-close" aria-label="Đóng" data-grading-close="true"></button>
            </div>
            <div class="submission-context">
                <div>
                    <span>Môn học lớp</span>
                    <strong><asp:Literal ID="SelectedSubjectText" runat="server" /></strong>
                </div>
                <div>
                    <span>Thời gian nộp</span>
                    <strong><asp:Literal ID="SelectedSubmittedAtText" runat="server" /></strong>
                </div>
            </div>
            <div class="submission-content">
                <h3>Nội dung học viên nộp</h3>
                <p><asp:Literal ID="SelectedSubmissionText" runat="server" /></p>
                <asp:HyperLink
                    ID="SelectedFileLink"
                    runat="server"
                    CssClass="btn btn-action-view btn-sm grading-file-link"
                    Target="_blank"
                    rel="noopener"
                />
            </div>
            <asp:TextBox ID="SubmissionIdText" runat="server" CssClass="d-none" aria-hidden="true" />
            <asp:DropDownList ID="GradeActionList" runat="server" CssClass="d-none" aria-hidden="true">
                <asp:ListItem Value="GRADE">Lưu điểm</asp:ListItem>
                <asp:ListItem Value="RETURN">Trả bài để bổ sung</asp:ListItem>
            </asp:DropDownList>
            <div class="row g-3">
                <div class="col-md-4">
                    <label class="form-label">
                        Điểm (tối đa
                        <asp:Literal ID="SelectedMaxScoreText" runat="server" />
                        )
                    </label>
                    <asp:TextBox ID="GradeScoreText" runat="server" CssClass="form-control" />
                </div>
                <div class="col-md-8">
                    <label class="form-label">Nhận xét của giảng viên</label>
                    <asp:TextBox
                        ID="GradeFeedbackText"
                        runat="server"
                        CssClass="form-control"
                        TextMode="MultiLine"
                        Rows="4"
                        placeholder="Nêu rõ phần đạt và phần cần bổ sung..."
                    />
                </div>
            </div>
            <div class="modal-actions">
                <button type="button" class="btn btn-action-cancel" data-grading-close="true">
                    <i class="bi bi-x-lg"></i>
                    Đóng
                </button>
                <asp:LinkButton ID="ReturnButton" runat="server" CssClass="btn btn-action-delete" OnClick="ReturnButton_Click">
                    <i class="bi bi-arrow-return-left"></i>
                    Trả bổ sung
                </asp:LinkButton>
                <asp:Button ID="GradeButton" runat="server" Text="Lưu điểm" CssClass="btn btn-action-save" OnClick="GradeButton_Click" />
            </div>
        </div>
    </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="ReturnButton" />
            <asp:PostBackTrigger ControlID="GradeButton" />
        </Triggers>
    </asp:UpdatePanel>
</section>
<script src="<%= ResolveUrl("~/assets/lms/js/assignment-grading-webforms.js") %>"></script>
