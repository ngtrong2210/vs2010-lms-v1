<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContentBuilder.ascx.cs" Inherits="InformationWeb.Controls.Cms.ContentBuilder" %>
<link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/css/pages/cms/content-builder.css") %>" />
<link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/css/pages/cms/content-builder-webforms.css") %>" />
<section class="content-builder-page">
    <header class="d-flex flex-wrap justify-content-between align-items-end gap-3 mb-4">
        <div>
            <span class="builder-eyebrow">SOẠN MÔN HỌC LỚP</span>
            <h1 class="page-title"><asp:Literal ID="HeadingText" runat="server" /></h1>
            <p class="page-subtitle mb-0">Tổ chức chương, bài học, học liệu và bài tập cho đúng lớp trong năm học.</p>
        </div>
        <div class="d-flex flex-wrap gap-2">
            <a class="btn btn-action-view" href="<%= ResolveUrl("~/cms/videos") %>">
                <i class="bi bi-collection-play"></i>
                Thư viện video
            </a>
            <button type="button" class="btn btn-action-create" data-open-chapter="true">
                <i class="bi bi-plus-lg"></i>
                Thêm chương
            </button>
        </div>
    </header>

    <asp:Label ID="MessageText" runat="server" CssClass="status-message" Visible="false" />

    <asp:Panel ID="ChapterDisplayToolbar" runat="server" CssClass="chapter-display-toolbar app-card">
        <div>
            <i class="bi bi-layout-text-sidebar-reverse"></i>
            <span>
                <strong>
                    <asp:Literal ID="ChapterCountText" runat="server" />
                    chương
                </strong>
                <small>Chọn chương để xem hoặc thu gọn danh sách bài học.</small>
            </span>
        </div>
        <div class="chapter-display-actions">
            <button type="button" class="btn btn-action-view btn-sm" data-expand-all="true">
                <i class="bi bi-arrows-expand"></i>
                Mở tất cả
            </button>
            <button type="button" class="btn btn-action-cancel btn-sm" data-collapse-all="true">
                <i class="bi bi-arrows-collapse"></i>
                Thu gọn
            </button>
        </div>
    </asp:Panel>

    <div class="builder">
        <asp:Repeater
            ID="ChapterRepeater"
            runat="server"
            OnItemCreated="ChapterRepeater_ItemCreated"
            OnItemCommand="ChapterRepeater_ItemCommand"
        >
            <ItemTemplate>
                <article class="app-card chapter-card" data-chapter-card="<%# Eval("Id") %>">
                    <header>
                        <button
                            type="button"
                            class="chapter-toggle"
                            data-toggle-chapter="<%# Eval("Id") %>"
                            title="Thu gọn / mở chương"
                            aria-expanded="true"
                        >
                            <i class="bi bi-chevron-down"></i>
                        </button>
                        <span class="number"><%# Container.ItemIndex + 1 %></span>
                        <div class="chapter-copy">
                            <strong><%#: Eval("Title") %></strong>
                            <small><%# LessonCount(Eval("Id")) %> bài • <%# StatusLabel(Eval("Status")) %></small>
                        </div>
                        <div class="chapter-header-actions ms-auto">
                            <button
                                type="button"
                                class="btn chapter-add-button btn-sm"
                                data-open-lesson="<%# Eval("Id") %>"
                                data-next-order="<%# LessonCount(Eval("Id")) + 1 %>"
                            >
                                <i class="bi bi-plus-lg"></i>
                                Thêm bài học
                            </button>
                            <asp:LinkButton
                                ID="ChapterEditTreeButton"
                                runat="server"
                                CssClass="btn btn-action-edit btn-sm"
                                CommandName="EditItem"
                                CommandArgument='<%# Eval("Id") %>'
                                CausesValidation="false"
                                ToolTip="Sửa chương"
                            >
                                <i class="bi bi-pencil"></i>
                            </asp:LinkButton>
                            <asp:LinkButton
                                ID="ChapterDeleteTreeButton"
                                runat="server"
                                CssClass="btn btn-action-delete btn-action-outline btn-sm"
                                CommandName="DeleteItem"
                                CommandArgument='<%# Eval("Id") %>'
                                CausesValidation="false"
                                ToolTip="Xóa chương"
                                OnClientClick="return confirm('Xóa chương sẽ xóa cả bài học trong chương. Tiếp tục?');"
                            >
                                <i class="bi bi-trash"></i>
                            </asp:LinkButton>
                        </div>
                    </header>
                    <div class="chapter-lessons">
                        <asp:Repeater
                            ID="LessonRepeater"
                            runat="server"
                            DataSource='<%# LessonsForChapter(Eval("Id")) %>'
                            OnItemCreated="LessonRepeater_ItemCreated"
                            OnItemCommand="LessonRepeater_ItemCommand"
                        >
                            <ItemTemplate>
                                <div class="lesson">
                                    <span class='<%# "type " + LessonTypeClass(Eval("LessonType")) %>'><i class='<%# "bi " + LessonTypeIcon(Eval("LessonType")) %>'></i></span>
                                    <div class="lesson-copy">
                                        <strong><%#: Eval("Title") %></strong>
                                        <small><%# LessonTypeLabel(Eval("LessonType")) %> • <%# FormatDuration(Eval("DurationSeconds")) %><%# VideoTitleSuffix(Container.DataItem) %></small>
                                    </div>
                                    <span class='<%# "badge " + StatusBadgeClass(Eval("Status")) %>'><%# StatusLabel(Eval("Status")) %></span>
                                    <div class="lesson-actions">
                                        <asp:HyperLink
                                            ID="VideoEditorLink"
                                            runat="server"
                                            CssClass="btn btn-action-view btn-sm"
                                            NavigateUrl='<%# VideoEditorUrl(Container.DataItem) %>'
                                            Visible='<%# HasEditableVideo(Container.DataItem) %>'
                                            ToolTip="Biên tập video mẫu"
                                        >
                                            <i class="bi bi-sliders"></i>
                                        </asp:HyperLink>
                                        <asp:LinkButton
                                            ID="VideoPickerTreeButton"
                                            runat="server"
                                            CssClass="btn btn-blue btn-sm"
                                            CommandName="OpenVideoPicker"
                                            CommandArgument='<%# Eval("Id") %>'
                                            CausesValidation="false"
                                            Visible='<%# IsVideoLesson(Eval("LessonType")) %>'
                                            ToolTip="Chọn video từ thư viện"
                                        >
                                            <i class="bi bi-collection-play"></i>
                                        </asp:LinkButton>
                                        <asp:LinkButton
                                            ID="LessonEditTreeButton"
                                            runat="server"
                                            CssClass="btn btn-action-edit btn-sm"
                                            CommandName="EditItem"
                                            CommandArgument='<%# Eval("Id") %>'
                                            CausesValidation="false"
                                            ToolTip="Sửa bài học"
                                        >
                                            <i class="bi bi-pencil"></i>
                                        </asp:LinkButton>
                                        <asp:LinkButton
                                            ID="LessonDeleteTreeButton"
                                            runat="server"
                                            CssClass="btn btn-action-delete btn-action-outline btn-sm"
                                            CommandName="DeleteItem"
                                            CommandArgument='<%# Eval("Id") %>'
                                            CausesValidation="false"
                                            ToolTip="Xóa bài học"
                                            OnClientClick="return confirm('Xóa bài học này?');"
                                        >
                                            <i class="bi bi-trash"></i>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Panel ID="EmptyLessonsPanel" runat="server" CssClass="empty-lessons" Visible='<%# LessonCount(Eval("Id")) == 0 %>'>
                            Chương này chưa có bài học.
                        </asp:Panel>
                        <button type="button" class="add-lesson" data-open-lesson="<%# Eval("Id") %>" data-next-order="<%# LessonCount(Eval("Id")) + 1 %>">
                            <i class="bi bi-plus-circle"></i>
                            Thêm bài học
                        </button>
                    </div>
                </article>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Panel ID="EmptyContentPanel" runat="server" CssClass="app-card empty-state" Visible="false">
            <i class="bi bi-journal-plus"></i>
            <h2>Chưa có chương</h2>
            <p><asp:Label ID="EmptyText" runat="server" Text="Tạo chương đầu tiên để bắt đầu xây dựng nội dung môn học lớp." /></p>
            <button type="button" class="btn btn-action-create" data-open-chapter="true">
                <i class="bi bi-plus-lg"></i>
                Thêm chương
            </button>
        </asp:Panel>
    </div>

    <asp:UpdatePanel ID="ContentEditorModalUpdatePanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
        <ContentTemplate>
    <div id="chapterModal" class="modal-mask" <%= ChapterModalOpenValue.Value == "1" ? "" : "hidden=\"hidden\"" %>>
        <section class="app-card form-modal" role="dialog" aria-modal="true" aria-labelledby="chapterModalTitle">
            <div class="modal-heading">
                <div>
                    <small>Chương môn học</small>
                    <h2 id="chapterModalTitle"><asp:Literal ID="ChapterFormTitle" runat="server" Text="Thêm chương" /></h2>
                </div>
                <button type="button" class="btn-close" data-close-modal="chapterModal" aria-label="Đóng"></button>
            </div>
            <asp:HiddenField ID="ChapterIdValue" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="ChapterModalOpenValue" runat="server" ClientIDMode="Static" />
            <div class="row g-3">
                <div class="col-12">
                    <label class="form-label">Tên chương</label>
                    <asp:TextBox ID="ChapterTitleText" runat="server" ClientIDMode="Static" CssClass="form-control" MaxLength="500" />
                </div>
                <div class="col-12">
                    <label class="form-label">Mô tả</label>
                    <asp:TextBox
                        ID="ChapterDescriptionText"
                        runat="server"
                        ClientIDMode="Static"
                        CssClass="form-control"
                        TextMode="MultiLine"
                        Rows="3"
                        MaxLength="1000"
                    />
                </div>
                <div class="col-md-6">
                    <label class="form-label">Thứ tự</label>
                    <asp:TextBox ID="ChapterSortOrderText" runat="server" ClientIDMode="Static" CssClass="form-control" Text="1" />
                </div>
                <div class="col-md-6">
                    <label class="form-label">Trạng thái</label>
                    <asp:DropDownList ID="ChapterStatusList" runat="server" ClientIDMode="Static" CssClass="form-select">
                        <asp:ListItem Value="ACTIVE">Hoạt động</asp:ListItem>
                        <asp:ListItem Value="INACTIVE">Tạm ẩn</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="modal-actions">
                <button type="button" class="btn btn-action-cancel btn-action-outline" data-close-modal="chapterModal">
                    <i class="bi bi-x-lg"></i>
                    Hủy
                </button>
                <asp:Button
                    ID="CancelChapterButton"
                    runat="server"
                    Text="Hủy sửa chương"
                    CssClass="d-none"
                    Visible="false"
                    CausesValidation="false"
                    OnClick="CancelChapterButton_Click"
                />
                <asp:Button
                    ID="AddChapterButton"
                    runat="server"
                    Text="Lưu chương"
                    CssClass="btn btn-action-save"
                    OnClientClick="return ContentBuilderPage.prepareSubmit('chapter');"
                    OnClick="AddChapterButton_Click"
                />
            </div>
        </section>
    </div>

    <div id="lessonModal" class="modal-mask" <%= LessonModalOpenValue.Value == "1" ? "" : "hidden=\"hidden\"" %>>
        <section class="app-card form-modal lesson-form-modal" role="dialog" aria-modal="true" aria-labelledby="lessonModalTitle">
            <div class="modal-heading">
                <div>
                    <small>Bài học</small>
                    <h2 id="lessonModalTitle"><asp:Literal ID="LessonFormTitle" runat="server" Text="Thêm bài học" /></h2>
                </div>
                <button type="button" class="btn-close" data-close-modal="lessonModal" aria-label="Đóng"></button>
            </div>
            <asp:HiddenField ID="LessonIdValue" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="LessonModalOpenValue" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="QuestionBankJsonValue" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="QuizSelectedJsonValue" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="InteractiveMappingsJsonValue" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="InteractiveOriginalIdsValue" runat="server" ClientIDMode="Static" />
            <div class="d-none"><asp:TextBox ID="LessonChapterIdText" runat="server" ClientIDMode="Static" /></div>
            <div class="row g-3">
                <div class="col-12">
                    <div class="lesson-overview-grid">
                        <div class="lesson-field lesson-field-title">
                            <label class="form-label">Tên bài học</label>
                            <asp:TextBox
                                ID="LessonTitleText"
                                runat="server"
                                ClientIDMode="Static"
                                CssClass="form-control"
                                MaxLength="500"
                            />
                        </div>
                        <div class="lesson-field lesson-field-type">
                            <label class="form-label">Loại bài</label>
                            <asp:DropDownList ID="LessonTypeList" runat="server" ClientIDMode="Static" CssClass="form-select">
                                <asp:ListItem Value="INTERACTIVE_VIDEO">Video tương tác</asp:ListItem>
                                <asp:ListItem Value="VIDEO">Video</asp:ListItem>
                                <asp:ListItem Value="QUIZ">Bài kiểm tra</asp:ListItem>
                                <asp:ListItem Value="EDITOR">Bài học (soạn thảo + tài liệu)</asp:ListItem>
                                <asp:ListItem Value="INTERACTIVE_CONTENT">Bài học tương tác</asp:ListItem>
                                <asp:ListItem Value="ASSIGNMENT">Bài tập nộp file</asp:ListItem>
                                <asp:ListItem Value="DOCUMENT">Tài liệu</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="lesson-field lesson-field-status">
                            <label class="form-label">Trạng thái</label>
                            <asp:DropDownList ID="LessonStatusList" runat="server" ClientIDMode="Static" CssClass="form-select">
                                <asp:ListItem Value="ACTIVE">Hoạt động</asp:ListItem>
                                <asp:ListItem Value="INACTIVE">Tạm ẩn</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="lesson-field lesson-field-description">
                            <label class="form-label">Mô tả</label>
                            <asp:TextBox
                                ID="LessonDescriptionText"
                                runat="server"
                                ClientIDMode="Static"
                                CssClass="form-control"
                                TextMode="MultiLine"
                                Rows="2"
                                MaxLength="1000"
                            />
                        </div>
                        <div class="lesson-field lesson-field-order">
                            <label class="form-label">Thứ tự</label>
                            <asp:TextBox ID="LessonSortOrderText" runat="server" ClientIDMode="Static" CssClass="form-control" Text="1" />
                        </div>
                        <div class="lesson-field lesson-field-score">
                            <label class="form-label">Điểm đạt</label>
                            <asp:TextBox
                                ID="LessonPassingScoreText"
                                runat="server"
                                ClientIDMode="Static"
                                CssClass="form-control"
                                Text="50"
                            />
                        </div>
                        <label class="lesson-required-toggle">
                            <asp:CheckBox
                                ID="LessonRequiredCheck"
                                runat="server"
                                ClientIDMode="Static"
                                Checked="true"
                                CssClass="builder-check"
                            />
                            <span>Bài học bắt buộc</span>
                        </label>
                    </div>
                </div>
                <div class="col-12" data-lesson-types="EDITOR,DOCUMENT,INTERACTIVE_CONTENT">
                    <label class="form-label">
                        <i class="bi bi-pencil-square"></i>
                        Nội dung soạn thảo
                    </label>
                    <div class="editor-toolbar">
                        <button type="button" data-editor-command="bold"><i class="bi bi-type-bold"></i></button>
                        <button type="button" data-editor-command="italic"><i class="bi bi-type-italic"></i></button>
                        <button type="button" data-editor-command="list"><i class="bi bi-list-ul"></i></button>
                        <button type="button" data-editor-command="heading"><i class="bi bi-type-h3"></i></button>
                    </div>
                    <asp:TextBox
                        ID="LessonContentText"
                        runat="server"
                        ClientIDMode="Static"
                        CssClass="form-control lesson-rich-editor"
                        TextMode="MultiLine"
                        Rows="8"
                    />
                </div>
                <div class="col-md-8" data-lesson-types="EDITOR,DOCUMENT,INTERACTIVE_CONTENT">
                    <label class="form-label">
                        <i class="bi bi-link-45deg"></i>
                        Đường dẫn tài liệu
                    </label>
                    <asp:TextBox ID="LessonDocumentUrlText" runat="server" ClientIDMode="Static" CssClass="form-control" MaxLength="1000" />
                </div>
                <div class="col-md-4">
                    <label class="form-label">Thời lượng (giây)</label>
                    <asp:TextBox ID="LessonDurationText" runat="server" ClientIDMode="Static" CssClass="form-control" Text="0" />
                </div>

                <div class="col-12 interactive-authoring-heading" data-lesson-types="INTERACTIVE_CONTENT">
                    <div>
                        <span class="builder-eyebrow">ĐỌC HIỂU VÀ TƯƠNG TÁC</span>
                        <h3>Câu hỏi trong bài</h3>
                        <p>Chọn câu hỏi dùng chung từ ngân hàng, sau đó cấu hình điểm và số lần thử riêng cho bài này.</p>
                    </div>
                    <div class="d-flex flex-wrap gap-2">
                        <button type="button" class="btn btn-action-view btn-sm" data-open-interactive-preview="true">
                            <i class="bi bi-eye"></i>
                            Xem như học viên
                        </button>
                        <a class="btn btn-action-create btn-sm" href="<%= ResolveUrl("~/cms/questions") %>">
                            <i class="bi bi-plus-lg"></i>
                            Tạo câu hỏi
                        </a>
                    </div>
                </div>
                <div class="col-md-6" data-lesson-types="INTERACTIVE_CONTENT">
                    <label class="form-label">
                        <i class="bi bi-check2-circle"></i>
                        Điều kiện hoàn thành
                    </label>
                    <asp:DropDownList ID="InteractiveCompletionList" runat="server" ClientIDMode="Static" CssClass="form-select">
                        <asp:ListItem Value="REQUIRED_QUESTIONS">Hoàn thành câu hỏi bắt buộc</asp:ListItem>
                        <asp:ListItem Value="ALL_QUESTIONS">Trả lời tất cả câu hỏi</asp:ListItem>
                        <asp:ListItem Value="PASSING_SCORE">Đạt điểm tối thiểu</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-3" data-lesson-types="INTERACTIVE_CONTENT">
                    <label class="form-label">
                        <i class="bi bi-bullseye"></i>
                        Điểm đạt (%)
                    </label>
                    <asp:TextBox ID="InteractivePassingScoreText" runat="server" ClientIDMode="Static" CssClass="form-control" Text="70" />
                </div>
                <div class="col-md-3 interactive-checks" data-lesson-types="INTERACTIVE_CONTENT">
                    <label>
                        <asp:CheckBox ID="InteractiveRequireReadingCheck" runat="server" ClientIDMode="Static" Checked="true" />
                        Phải đọc hết bài
                    </label>
                    <label>
                        <asp:CheckBox ID="InteractiveShowResultCheck" runat="server" ClientIDMode="Static" Checked="true" />
                        Hiện đúng / sai ngay
                    </label>
                    <label>
                        <asp:CheckBox ID="InteractiveShowScoreCheck" runat="server" ClientIDMode="Static" Checked="true" />
                        Hiện điểm
                    </label>
                </div>
                <div class="col-12 interactive-question-workspace" data-lesson-types="INTERACTIVE_CONTENT">
                    <section class="interactive-bank-panel">
                        <header class="interactive-panel-heading">
                            <div>
                                <span>NGÂN HÀNG CÂU HỎI</span>
                                <h4>Tìm và chọn câu hỏi</h4>
                            </div>
                            <strong id="interactiveQuestionTotal">0 câu</strong>
                        </header>
                        <div class="interactive-bank-toolbar">
                            <label class="interactive-search-box">
                                <i class="bi bi-search"></i>
                                <input
                                    id="interactiveQuestionSearch"
                                    class="form-control"
                                    placeholder="Tìm nhanh theo nội dung câu hỏi..."
                                />
                            </label>
                            <select id="interactiveQuestionType" class="form-select" aria-label="Lọc loại câu hỏi">
                                <option value="">Tất cả loại câu hỏi</option>
                                <option value="SINGLE_CHOICE">Một lựa chọn</option>
                                <option value="MULTIPLE_CHOICE">Nhiều lựa chọn</option>
                                <option value="TRUE_FALSE">Đúng / Sai</option>
                                <option value="SHORT_ANSWER">Trả lời ngắn</option>
                                <option value="CLOZE_DRAG_DROP">Kéo thả vào đoạn văn</option>
                            </select>
                        </div>
                        <div id="interactiveQuestionPicker" class="interactive-question-picker"></div>
                    </section>
                    <section class="interactive-selected-panel">
                        <header class="interactive-panel-heading">
                            <div>
                                <span>CÂU HỎI TRONG BÀI</span>
                                <h4>Sắp xếp và thiết lập</h4>
                            </div>
                            <strong id="interactiveSelectedCount">0 đã chọn</strong>
                        </header>
                        <div id="interactiveSelectedList" class="interactive-selected-list"></div>
                    </section>
                </div>

                <div class="col-md-4" data-lesson-types="QUIZ">
                    <label class="form-label">
                        <i class="bi bi-bullseye"></i>
                        Điểm đạt (%)
                    </label>
                    <asp:TextBox ID="QuizPassingScoreText" runat="server" ClientIDMode="Static" CssClass="form-control" Text="50" />
                </div>
                <div class="col-md-4" data-lesson-types="QUIZ">
                    <label class="form-label">
                        <i class="bi bi-clock"></i>
                        Thời gian (phút)
                    </label>
                    <asp:TextBox ID="QuizTimeLimitText" runat="server" ClientIDMode="Static" CssClass="form-control" Text="30" />
                </div>
                <div class="col-md-4" data-lesson-types="QUIZ">
                    <label class="form-label">
                        <i class="bi bi-arrow-repeat"></i>
                        Số lượt làm
                    </label>
                    <asp:TextBox ID="QuizMaxAttemptsText" runat="server" ClientIDMode="Static" CssClass="form-control" Text="1" />
                </div>
                <div class="col-12 check-row" data-lesson-types="QUIZ">
                    <asp:CheckBox
                        ID="QuizShuffleCheck"
                        runat="server"
                        ClientIDMode="Static"
                        Text=" Đảo thứ tự câu hỏi khi học viên làm bài"
                    />
                </div>
                <div class="col-12" data-lesson-types="QUIZ">
                    <div class="quiz-bank-heading">
                        <div>
                            <span class="builder-eyebrow">SOẠN BÀI KIỂM TRA</span>
                            <h3 class="mb-0">Câu hỏi trong bài</h3>
                        </div>
                        <div class="quiz-bank-heading__actions">
                            <span id="quizBankSelected" class="quiz-bank-selected">0 đã chọn</span>
                            <a href="<%= ResolveUrl("~/cms/questions") %>" class="btn btn-action-view btn-sm">
                                <i class="bi bi-plus-lg"></i>
                                Quản lý ngân hàng
                            </a>
                        </div>
                    </div>
                    <div class="quiz-question-workspace">
                        <section class="quiz-bank-panel">
                            <header class="quiz-workspace-heading">
                                <div>
                                    <span>NGÂN HÀNG CÂU HỎI</span>
                                    <h4>Tìm và chọn câu hỏi</h4>
                                </div>
                                <strong id="quizQuestionTotal">0 câu</strong>
                            </header>
                            <div class="quiz-bank-toolbar">
                                <label class="quiz-search-box">
                                    <i class="bi bi-search"></i>
                                    <input id="quizQuestionSearch" class="form-control" placeholder="Tìm nhanh theo nội dung câu hỏi..." />
                                </label>
                                <select id="quizQuestionType" class="form-select" aria-label="Lọc loại câu hỏi bài kiểm tra">
                                    <option value="">Tất cả loại câu hỏi</option>
                                    <option value="SINGLE_CHOICE">Một lựa chọn</option>
                                    <option value="MULTIPLE_CHOICE">Nhiều lựa chọn</option>
                                    <option value="TRUE_FALSE">Đúng / Sai</option>
                                    <option value="SHORT_ANSWER">Trả lời ngắn</option>
                                    <option value="CLOZE_DRAG_DROP">Kéo thả vào đoạn văn</option>
                                </select>
                            </div>
                            <div id="quizQuestionPicker" class="quiz-question-picker"></div>
                        </section>
                        <section class="quiz-selected-panel">
                            <header class="quiz-workspace-heading">
                                <div>
                                    <span>CÂU HỎI TRONG BÀI</span>
                                    <h4>Sắp xếp thứ tự làm bài</h4>
                                </div>
                                <strong id="quizSelectedCount">0 đã chọn</strong>
                            </header>
                            <div id="quizSelectedList" class="quiz-selected-list"></div>
                        </section>
                    </div>
                </div>

                <div class="col-12 assignment-panel" data-lesson-types="ASSIGNMENT">
                    <div class="assignment-heading">
                        <span><i class="bi bi-folder2-open"></i></span>
                        <div>
                            <strong>Cấu hình bài tập nộp file</strong>
                            <small>Thiết lập thư mục, thời gian và giới hạn bài nộp.</small>
                        </div>
                    </div>
                    <div class="row g-3">
                        <div class="col-md-6">
                            <label class="form-label">Thư mục bài nộp</label>
                            <asp:TextBox
                                ID="LessonAssignmentFolderText"
                                runat="server"
                                ClientIDMode="Static"
                                CssClass="form-control"
                                MaxLength="250"
                            />
                        </div>
                        <div class="col-md-3">
                            <label class="form-label">Bắt đầu bài tập</label>
                            <asp:TextBox
                                ID="LessonAssignmentStartText"
                                runat="server"
                                ClientIDMode="Static"
                                CssClass="form-control"
                                placeholder="dd/MM/yyyy HH:mm"
                            />
                        </div>
                        <div class="col-md-3">
                            <label class="form-label">Hạn nộp</label>
                            <asp:TextBox
                                ID="LessonDueAtText"
                                runat="server"
                                ClientIDMode="Static"
                                CssClass="form-control"
                                placeholder="dd/MM/yyyy HH:mm"
                            />
                        </div>
                        <div class="col-md-3">
                            <label class="form-label">Điểm tối đa</label>
                            <asp:TextBox ID="LessonMaxScoreText" runat="server" ClientIDMode="Static" CssClass="form-control" Text="100" />
                        </div>
                        <div class="col-md-3">
                            <label class="form-label">Số lần nộp</label>
                            <asp:TextBox ID="LessonMaxAttemptsText" runat="server" ClientIDMode="Static" CssClass="form-control" Text="3" />
                        </div>
                        <div class="col-md-3">
                            <label class="form-label">Dung lượng (MB)</label>
                            <asp:TextBox
                                ID="LessonMaxFileSizeText"
                                runat="server"
                                ClientIDMode="Static"
                                CssClass="form-control"
                                Text="50"
                            />
                        </div>
                        <div class="col-md-3 check-row">
                            <asp:CheckBox ID="LessonAllowLateCheck" runat="server" ClientIDMode="Static" Text=" Cho phép nộp muộn" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-actions">
                <button type="button" class="btn btn-action-cancel btn-action-outline" data-close-modal="lessonModal">
                    <i class="bi bi-x-lg"></i>
                    Hủy
                </button>
                <asp:Button
                    ID="CancelLessonButton"
                    runat="server"
                    Text="Hủy sửa"
                    CssClass="d-none"
                    Visible="false"
                    CausesValidation="false"
                    OnClick="CancelLessonButton_Click"
                />
                <asp:Button
                    ID="AddLessonButton"
                    runat="server"
                    Text="Lưu bài học"
                    CssClass="btn btn-action-save"
                    OnClientClick="return ContentBuilderPage.prepareSubmit('lesson');"
                    OnClick="AddLessonButton_Click"
                />
            </div>
        </section>
    </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="CancelChapterButton" />
            <asp:PostBackTrigger ControlID="AddChapterButton" />
            <asp:PostBackTrigger ControlID="CancelLessonButton" />
            <asp:PostBackTrigger ControlID="AddLessonButton" />
        </Triggers>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="VideoPickerUpdatePanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
        <ContentTemplate>
    <asp:Panel ID="VideoPickerPanel" runat="server" CssClass="modal-mask" Visible="false">
        <section class="app-card library-modal" role="dialog" aria-modal="true" aria-labelledby="videoPickerTitle">
            <div class="modal-heading">
                <div>
                    <small>Thư viện video</small>
                    <h2 id="videoPickerTitle">Chọn video tham chiếu</h2>
                    <p>Video được dùng chung; kết quả học vẫn tách riêng theo từng bài.</p>
                </div>
                <asp:Button
                    ID="CloseVideoPickerButton"
                    runat="server"
                    Text=""
                    CssClass="btn-close"
                    CausesValidation="false"
                    OnClick="CloseVideoPickerButton_Click"
                />
            </div>
            <asp:HiddenField ID="VideoTargetLessonValue" runat="server" />
            <div class="library-toolbar">
                <asp:TextBox ID="VideoSearchText" runat="server" CssClass="form-control" placeholder="Tìm video theo tiêu đề..." />
                <asp:Button
                    ID="SearchVideosButton"
                    runat="server"
                    Text="Tìm"
                    CssClass="btn btn-action-view"
                    CausesValidation="false"
                    OnClick="SearchVideosButton_Click"
                />
                <a class="btn btn-action-create text-nowrap" href="<%= ResolveUrl("~/cms/videos") %>">
                    <i class="bi bi-plus-lg"></i>
                    Quản lý video
                </a>
            </div>
            <div class="video-list">
                <asp:Repeater
                    ID="VideoAssetsRepeater"
                    runat="server"
                    OnItemCreated="VideoAssetsRepeater_ItemCreated"
                    OnItemCommand="VideoAssetsRepeater_ItemCommand"
                >
                    <ItemTemplate>
                        <asp:LinkButton
                            ID="AttachVideoButton"
                            runat="server"
                            CssClass="video-item"
                            CommandName="AttachVideo"
                            CommandArgument='<%# VideoVersionId(Container.DataItem) %>'
                            CausesValidation="false"
                        >
                            <span class="video-icon"><i class="bi bi-play-fill"></i></span>
                            <div>
                                <strong><%#: Eval("Title") %></strong>
                                <small><%# FormatDuration(Eval("DurationSeconds")) %> • Đang dùng ở <%# ItemText(Container.DataItem, "UsageCount") %> bài</small>
                            </div>
                            <i class="bi bi-chevron-right"></i>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Label
                    ID="VideoPickerEmptyText"
                    runat="server"
                    CssClass="empty-lessons"
                    Text="Không tìm thấy video phù hợp."
                    Visible="false"
                />
            </div>
        </section>
    </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <div class="content-builder-course-contract" aria-hidden="true">
        <asp:TextBox ID="CodeText" runat="server" MaxLength="100" />
        <asp:TextBox ID="CourseTitleText" runat="server" MaxLength="500" />
        <asp:TextBox ID="SlugText" runat="server" MaxLength="500" />
        <asp:TextBox ID="ShortDescriptionText" runat="server" TextMode="MultiLine" />
        <asp:TextBox ID="DescriptionText" runat="server" TextMode="MultiLine" />
        <asp:TextBox ID="TeacherIdText" runat="server" />
        <asp:TextBox ID="CategoryIdText" runat="server" />
        <asp:TextBox ID="LevelText" runat="server" />
        <asp:TextBox ID="PassingScoreText" runat="server" Text="50" />
        <asp:DropDownList ID="StatusList" runat="server">
            <asp:ListItem Value="DRAFT">Bản nháp</asp:ListItem>
            <asp:ListItem Value="PUBLISHED">Đã xuất bản</asp:ListItem>
            <asp:ListItem Value="ARCHIVED">Lưu trữ</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="SaveButton" runat="server" Text="Lưu môn học" OnClick="SaveButton_Click" />
        <asp:GridView ID="ContentGrid" runat="server" AutoGenerateColumns="false" DataKeyNames="Id" OnRowCommand="ContentGrid_RowCommand">
            <Columns><asp:BoundField DataField="Id" /></Columns>
        </asp:GridView>
        <asp:GridView ID="LessonGrid" runat="server" AutoGenerateColumns="false" DataKeyNames="Id" OnRowCommand="LessonGrid_RowCommand">
            <Columns><asp:BoundField DataField="Id" /></Columns>
        </asp:GridView>
    </div>
</section>
<script src="<%= ResolveUrl("~/assets/lms/js/content-builder-webforms.js") %>"></script>
