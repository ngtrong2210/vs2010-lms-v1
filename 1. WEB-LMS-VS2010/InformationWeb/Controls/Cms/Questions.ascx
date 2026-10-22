<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Questions.ascx.cs" Inherits="InformationWeb.Controls.Cms.Questions" %>
<link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/css/pages/cms/question-bank.css") %>" />
<section id="questionBankPage">
    <header class="d-flex flex-wrap justify-content-between align-items-end gap-3 mb-4">
        <div>
            <h1 class="page-title mb-1"><asp:Literal ID="PageTitleText" runat="server" /></h1>
            <p class="page-subtitle mb-0"><asp:Literal ID="PageDescriptionText" runat="server" /></p>
        </div>
        <div class="cms-page-actions">
            <button type="button" class="btn btn-action-create" data-question-create="true">
                <i class="bi bi-plus-lg"></i>
                Thêm câu hỏi
            </button>
        </div>
    </header>
    <asp:Label ID="ActionMessageText" runat="server" Visible="false" />
    <div class="app-card p-3 mb-3">
        <div class="row g-2">
            <div class="col-md-7">
                <asp:TextBox ID="SearchText" runat="server" CssClass="form-control" placeholder="Tìm nội dung câu hỏi..." />
            </div>
            <div class="col-md-3">
                <asp:DropDownList ID="QuestionTypeFilterList" runat="server" CssClass="form-select">
                    <asp:ListItem Value="">Tất cả loại</asp:ListItem>
                    <asp:ListItem Value="SINGLE_CHOICE">Một lựa chọn</asp:ListItem>
                    <asp:ListItem Value="MULTIPLE_CHOICE">Nhiều lựa chọn</asp:ListItem>
                    <asp:ListItem Value="TRUE_FALSE">Đúng / Sai</asp:ListItem>
                    <asp:ListItem Value="SHORT_ANSWER">Trả lời ngắn</asp:ListItem>
                    <asp:ListItem Value="CLOZE_DRAG_DROP">Kéo thả vào đoạn văn</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-2">
                <asp:Button
                    ID="SearchButton"
                    runat="server"
                    Text="Tìm kiếm"
                    CssClass="btn btn-action-filter w-100"
                    OnClick="SearchButton_Click"
                />
            </div>
        </div>
    </div>
    <asp:Label ID="ErrorText" runat="server" CssClass="alert alert-danger" Visible="false" />
    <div class="app-card p-2">
        <asp:Label ID="EmptyText" runat="server" CssClass="empty-state" Text="Không có câu hỏi phù hợp." Visible="false" />
        <div class="table-responsive">
            <asp:GridView
                ID="DataGrid"
                runat="server"
                CssClass="table align-middle mb-0"
                AutoGenerateColumns="false"
                AllowPaging="true"
                PageSize="20"
                OnPageIndexChanging="DataGrid_PageIndexChanging"
                OnRowCreated="DataGrid_RowCreated"
                OnRowCommand="DataGrid_RowCommand"
            >
                <Columns>
                    <asp:TemplateField HeaderText="Câu hỏi">
                        <ItemTemplate>
                            <strong><%# QuestionDisplayText(Eval("QuestionType"), Eval("QuestionText"), Eval("Description")) %></strong>
                            <small class="d-block text-secondary">Cập nhật <%# QuestionDateText(Eval("CreatedAt")) %></small>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Loại">
                        <ItemTemplate><span class="badge badge-soft-primary"><%# QuestionTypeLabel(Eval("QuestionType")) %></span></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Độ khó">
                        <ItemTemplate><span class='<%# "badge " + QuestionDifficultyClass(Eval("Difficulty")) %>'><%# QuestionDifficultyLabel(Eval("Difficulty")) %></span></ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="DefaultScore" HeaderText="Điểm" />
                    <asp:TemplateField HeaderText="Trạng thái">
                        <ItemTemplate><span class='<%# "badge " + QuestionStatusClass(Eval("Status")) %>'><%# QuestionStatusLabel(Eval("Status")) %></span></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Thao tác" ItemStyle-CssClass="text-end" HeaderStyle-CssClass="text-end">
                        <ItemTemplate>
                            <asp:LinkButton
                                ID="EditQuestionButton"
                                runat="server"
                                CssClass="btn btn-action-edit btn-sm"
                                ToolTip="Chỉnh sửa"
                                CommandName="EditQuestion"
                                CommandArgument='<%# Eval("Id") %>'
                                CausesValidation="false"
                            >
                                <i class="bi bi-pencil"></i>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <asp:UpdatePanel ID="QuestionEditorUpdatePanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
        <ContentTemplate>
    <div id="questionEditor" class="editor-backdrop" hidden="hidden">
        <section class="editor-dialog app-card" role="dialog" aria-modal="true" aria-labelledby="questionEditorHeading">
            <div class="d-flex justify-content-between align-items-start gap-3 mb-3">
                <div>
                    <small id="questionEditorKicker" class="editor-kicker">TẠO CÂU HỎI</small>
                    <h2 id="questionEditorHeading" class="h4 fw-bold mb-0">Nội dung và đáp án</h2>
                </div>
                <button type="button" class="btn btn-light btn-sm" data-question-close="true"><i class="bi bi-x-lg"></i></button>
            </div>
            <div class="row g-3">
                <div class="col-12">
                    <label id="questionTextLabel" class="form-label">Nội dung câu hỏi</label>
                    <asp:TextBox ID="QuestionTextInput" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
                    <small id="questionClozeHint" class="text-secondary" hidden="hidden">
                        Đặt marker
                        <b>[[BLANK_1]]</b>
                        tại vị trí cần kéo đáp án vào.
                    </small>
                </div>
                <div class="col-md-4">
                    <label class="form-label">Loại câu hỏi</label>
                    <asp:DropDownList ID="QuestionTypeList" runat="server" CssClass="form-select" ClientIDMode="Static">
                        <asp:ListItem Value="SINGLE_CHOICE">Một lựa chọn</asp:ListItem>
                        <asp:ListItem Value="MULTIPLE_CHOICE">Nhiều lựa chọn</asp:ListItem>
                        <asp:ListItem Value="TRUE_FALSE">Đúng / Sai</asp:ListItem>
                        <asp:ListItem Value="SHORT_ANSWER">Trả lời ngắn</asp:ListItem>
                        <asp:ListItem Value="CLOZE_DRAG_DROP">Kéo thả vào đoạn văn</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <label class="form-label">Độ khó</label>
                    <asp:DropDownList ID="QuestionDifficultyList" runat="server" CssClass="form-select">
                        <asp:ListItem Value="EASY">Dễ</asp:ListItem>
                        <asp:ListItem Value="MEDIUM">Trung bình</asp:ListItem>
                        <asp:ListItem Value="HARD">Khó</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <label class="form-label">Điểm</label>
                    <asp:TextBox ID="QuestionScoreText" runat="server" CssClass="form-control" Text="1" />
                </div>
                <div class="col-md-3">
                    <label class="form-label">Trạng thái</label>
                    <asp:DropDownList ID="QuestionStatusList" runat="server" CssClass="form-select">
                        <asp:ListItem Value="ACTIVE">Hoạt động</asp:ListItem>
                        <asp:ListItem Value="INACTIVE">Tạm ẩn</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-12">
                    <label class="form-label">Giải thích đáp án</label>
                    <asp:TextBox ID="QuestionDescriptionInput" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2" />
                </div>
            </div>

            <div id="questionOptionPanel" class="answer-panel mt-4">
                <div class="d-flex justify-content-between align-items-center mb-2">
                    <h3 class="h6 fw-bold mb-0">Các phương án</h3>
                    <button type="button" class="btn btn-action-create btn-sm" data-question-add-option="true">
                        <i class="bi bi-plus-lg"></i>
                        Thêm phương án
                    </button>
                </div>
                <div id="questionOptionRows"></div>
                <div id="questionClozeBlankEditor" class="cloze-blank-editor mt-4" hidden="hidden">
                    <div class="d-flex justify-content-between align-items-center gap-2 mb-2">
                        <div>
                            <h3 class="h6 fw-bold mb-1">Các ô trống</h3>
                            <small>Gán đáp án đúng cho từng vị trí trong đoạn văn.</small>
                        </div>
                        <button type="button" class="btn btn-action-create btn-sm" data-question-add-blank="true">
                            <i class="bi bi-plus-lg"></i>
                            Thêm ô trống
                        </button>
                    </div>
                    <div id="questionBlankRows"></div>
                </div>
            </div>
            <div id="questionShortAnswerPanel" class="answer-panel mt-4" hidden="hidden">
                <div class="row g-3">
                    <div class="col-md-4">
                        <label class="form-label">Cách chấm</label>
                        <asp:DropDownList ID="ShortAnswerModeList" runat="server" CssClass="form-select" ClientIDMode="Static">
                            <asp:ListItem Value="EXACT_MATCH">Khớp chính xác</asp:ListItem>
                            <asp:ListItem Value="CONTAINS">Có chứa đáp án</asp:ListItem>
                            <asp:ListItem Value="MANUAL_REVIEW">Giảng viên chấm</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div id="questionShortAnswerField" class="col-md-8">
                        <label class="form-label">Đáp án mẫu</label>
                        <input id="questionShortAnswerInput" class="form-control" />
                    </div>
                </div>
            </div>

            <asp:TextBox ID="QuestionOptionsText" runat="server" CssClass="d-none" TextMode="MultiLine" Rows="6" ClientIDMode="Static" />
            <asp:TextBox ID="QuestionAnswerKeysText" runat="server" CssClass="d-none" TextMode="MultiLine" Rows="6" ClientIDMode="Static" />
            <asp:TextBox ID="QuestionBlanksText" runat="server" CssClass="d-none" TextMode="MultiLine" Rows="6" ClientIDMode="Static" />
            <asp:HiddenField ID="QuestionIdValue" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="QuestionEditorOpenValue" runat="server" ClientIDMode="Static" />
            <div class="d-flex justify-content-end gap-2 mt-4">
                <button type="button" class="btn btn-action-cancel" data-question-close="true">
                    <i class="bi bi-x-lg"></i>
                    Hủy
                </button>
                <asp:Button
                    ID="CreateQuestionButton"
                    runat="server"
                    Text="Lưu câu hỏi"
                    CssClass="btn btn-action-save"
                    OnClick="CreateQuestionButton_Click"
                    OnClientClick="return QuestionBankPage.prepareSubmit();"
                />
            </div>
        </section>
    </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="CreateQuestionButton" />
        </Triggers>
    </asp:UpdatePanel>
</section>
<script src="<%= ResolveUrl("~/assets/lms/js/question-bank-webforms.js") %>"></script>
