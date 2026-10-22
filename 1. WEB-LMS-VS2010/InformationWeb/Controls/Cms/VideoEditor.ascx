<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VideoEditor.ascx.cs" Inherits="InformationWeb.Controls.Cms.VideoEditor" %>
<link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/css/pages/cms/video-editor.css") %>" />
<link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/css/components/interactive-video-player.css") %>" />
<asp:HiddenField ID="VideoAssetIdValue" runat="server" />
<asp:HiddenField ID="LessonIdValue" runat="server" />
<asp:HiddenField ID="VideoSourceTypeValue" runat="server" />
<asp:HiddenField ID="VideoUrlValue" runat="server" />
<asp:HiddenField ID="PosterUrlValue" runat="server" />
<asp:HiddenField ID="DurationValue" runat="server" />
<asp:HiddenField ID="AllowSeekValue" runat="server" />
<asp:HiddenField ID="AllowSpeedValue" runat="server" />
<asp:HiddenField ID="RequiredWatchValue" runat="server" />
<asp:HiddenField ID="VideoStatusValue" runat="server" />
<asp:HiddenField ID="CanEditValue" runat="server" />
<asp:HiddenField ID="CurrentTimeValue" runat="server" Value="0" />
<asp:HiddenField ID="InteractionsJsonValue" runat="server" />
<section class="video-editor-page">
    <header class="video-editor-header d-flex flex-wrap justify-content-between align-items-center gap-3 mb-4">
        <div>
            <h1 class="page-title video-editor-title mb-1">Biên tập video tương tác</h1>
            <p class="page-subtitle mb-0">
                <asp:Literal ID="EditorTitleText" runat="server" />
                • Thời lượng
                <asp:Literal ID="EditorDurationText" runat="server" />
            </p>
        </div>
        <div class="cms-page-actions video-header-actions">
            <asp:Button
                ID="PreviewButton"
                runat="server"
                Text="Xem như học viên"
                CssClass="btn btn-action-view header-preview-button"
                CausesValidation="false"
                OnClick="PreviewButton_Click"
            />
            <asp:Button
                ID="DuplicateVideoButton"
                runat="server"
                Text="Nhân bản video"
                CssClass="btn btn-action-copy"
                CausesValidation="false"
                OnClientClick="return confirm('Nhân bản video và toàn bộ câu hỏi tương tác?');"
                OnClick="DuplicateVideoButton_Click"
            />
            <label id="UploadLabel" runat="server" class="btn btn-action-upload header-upload-button mb-0">
                <i class="bi bi-cloud-arrow-up"></i>
                Upload video
                <asp:FileUpload
                    ID="VideoFile"
                    runat="server"
                    CssClass="visually-hidden"
                    onchange="document.getElementById(this.getAttribute('data-submit')).click();"
                />
            </label>
            <asp:Button ID="UploadVideoButton" runat="server" Text="Upload" CssClass="visually-hidden" OnClick="UploadVideoButton_Click" />
            <asp:Button
                ID="SaveVideoButton"
                runat="server"
                Text="Lưu video"
                CssClass="btn btn-action-save"
                OnClick="SaveVideoButton_Click"
            />
        </div>
    </header>
    <asp:Label ID="MessageText" runat="server" Visible="false" />
    <asp:Panel ID="EditLockPanel" runat="server" CssClass="alert alert-warning edit-lock-notice" Visible="false">
        <i class="bi bi-lock-fill"></i>
        <div>
            <strong>Video đã có kết quả học tập nên nội dung được khóa.</strong>
            <span>Câu trả lời và điểm cũ được giữ nguyên. Hãy nhân bản video để tiếp tục chỉnh sửa.</span>
        </div>
    </asp:Panel>
    <div class="editor-grid">
        <div class="app-card video-card">
            <div class="video"><asp:Literal ID="EditorPlayerHtml" runat="server" /></div>
            <div class="video-toolbar">
                <div class="current-position">
                    <small>Vị trí hiện tại</small>
                    <strong id="editorCurrentTime">00:00</strong>
                </div>
                <span id="editorSourceBadge" runat="server" class="editor-source-badge local">
                    <i class="bi bi-file-play"></i>
                    <asp:Literal ID="SourceBadgeText" runat="server" />
                </span>
                <asp:Button
                    ID="AddAtCurrentButton"
                    runat="server"
                    Text="Thêm câu hỏi tại vị trí hiện tại"
                    CssClass="btn btn-blue toolbar-add-question"
                    CausesValidation="false"
                    OnClick="AddAtCurrentButton_Click"
                />
            </div>
        </div>
        <aside class="app-card interaction-panel">
            <div class="interaction-panel-header p-3">
                <h2 class="h5 fw-bold mb-1">Câu hỏi tương tác</h2>
                <small class="text-secondary">
                    <asp:Literal ID="InteractionCountText" runat="server" />
                    mốc trong video
                </small>
            </div>
            <div class="interaction-scroll">
                <asp:Repeater
                    ID="InteractionsRepeater"
                    runat="server"
                    OnItemCreated="InteractionsRepeater_ItemCreated"
                    OnItemCommand="InteractionsRepeater_ItemCommand"
                >
                    <ItemTemplate>
                        <div class="interaction" data-seek-time='<%# Eval("TimeSeconds") %>'>
                            <span><%#: FormatDuration(Eval("TimeSeconds")) %></span>
                            <div class="interaction-content">
                                <strong><%#: Eval("QuestionText") %></strong>
                                <small><%#: QuestionTypeLabel(Eval("QuestionType")) %> • <%#: Eval("Score") %> điểm</small>
                            </div>
                            <div class="interaction-actions">
                                <asp:LinkButton
                                    ID="EditInteractionButton"
                                    runat="server"
                                    CssClass="interaction-action edit"
                                    CommandName="EditInteraction"
                                    CommandArgument='<%# Eval("Id") %>'
                                    CausesValidation="false"
                                >
                                    <i class="bi bi-pencil-square"></i>
                                </asp:LinkButton>
                                <asp:LinkButton
                                    ID="DeleteInteractionButton"
                                    runat="server"
                                    CssClass="interaction-action delete"
                                    CommandName="RequestDelete"
                                    CommandArgument='<%# Eval("Id") %>'
                                    CausesValidation="false"
                                >
                                    <i class="bi bi-trash"></i>
                                </asp:LinkButton>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Label
                    ID="InteractionEmptyText"
                    runat="server"
                    CssClass="empty-interactions"
                    Text="Chưa có tương tác cho video này."
                    Visible="false"
                />
            </div>
        </aside>
    </div>
    <div class="app-card p-4 mt-4">
        <div class="d-flex flex-wrap justify-content-between gap-2 mb-2">
            <div>
                <h2 class="timeline-section-title h5 fw-bold mb-1">Dòng thời gian tương tác</h2>
                <small class="timeline-section-hint">Bấm để chọn thời điểm; giữ Ctrl và lăn chuột để phóng to đoạn cần biên tập.</small>
            </div>
            <div class="timeline-info">
                <small>
                    00:00 —
                    <asp:Literal ID="TimelineDurationText" runat="server" />
                </small>
                <div class="timeline-legend">
                    <span>
                        <i class="has-question"></i>
                        Đã có câu hỏi
                    </span>
                    <span>
                        <i class="no-question"></i>
                        Chưa có câu hỏi
                    </span>
                </div>
            </div>
        </div>
        <div id="editorTimelineViewport" class="timeline-viewport">
            <div id="editorTimeline" class="editor-timeline" tabindex="0" role="slider">
                <span id="editorTimelinePlayhead" class="timeline-playhead" style="left: 0%"></span>
                <asp:Repeater ID="TimelineRepeater" runat="server">
                    <ItemTemplate>
                        <button
                            type="button"
                            class="timeline-point"
                            data-seek-time='<%# Eval("TimeSeconds") %>'
                            style='<%# TimelinePosition(Eval("TimeSeconds")) %>'
                        >
                            <i class="bi bi-patch-question-fill"></i>
                            <span><%#: FormatDuration(Eval("TimeSeconds")) %></span>
                        </button>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="timeline-zoom-toolbar">
            <span class="timeline-zoom-hint">
                <i class="bi bi-mouse2"></i>
                Ctrl + lăn chuột trên timeline để zoom
            </span>
            <div class="timeline-zoom-controls">
                <button type="button" data-timeline-zoom="out"><i class="bi bi-dash-lg"></i></button>
                <output id="timelineZoomText">100%</output>
                <button type="button" data-timeline-zoom="in"><i class="bi bi-plus-lg"></i></button>
                <button type="button" class="timeline-zoom-reset" data-timeline-zoom="reset">
                    <i class="bi bi-arrows-collapse"></i>
                    100%
                </button>
            </div>
        </div>
        <div class="timeline-selected-time">
            <i class="bi bi-cursor-fill"></i>
            Đang chọn
            <strong id="timelineSelectedTime">00:00</strong>
        </div>
    </div>
</section>
<asp:UpdatePanel ID="EditorModalUpdatePanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
    <ContentTemplate>
<asp:Panel ID="InteractionEditorPanel" runat="server" CssClass="preview-backdrop" Visible="false">
    <div class="interaction-editor-dialog app-card" role="dialog" aria-modal="true">
        <div class="preview-header">
            <div>
                <small>
                    CHỈNH SỬA CÂU HỎI TẠI
                    <asp:Literal ID="InteractionTimeLabel" runat="server" />
                </small>
                <h2>
                    <i class="bi bi-sliders2-vertical me-2 text-brand"></i>
                    Thiết lập tương tác
                </h2>
            </div>
            <asp:Button
                ID="CloseInteractionButton"
                runat="server"
                Text="×"
                CssClass="btn btn-light btn-sm"
                CausesValidation="false"
                OnClick="CloseInteractionButton_Click"
            />
        </div>
        <asp:HiddenField ID="InteractionIdValue" runat="server" />
        <div class="row g-3">
            <div class="col-md-3">
                <label class="form-label">Thời điểm (giây)</label>
                <asp:TextBox ID="InteractionTimeText" runat="server" CssClass="form-control" />
            </div>
            <div class="col-md-3">
                <label class="form-label">Loại câu hỏi</label>
                <asp:DropDownList ID="QuestionTypeFilter" runat="server" CssClass="form-select">
                    <asp:ListItem Value="">Tất cả loại</asp:ListItem>
                    <asp:ListItem Value="SINGLE_CHOICE">Một lựa chọn</asp:ListItem>
                    <asp:ListItem Value="MULTIPLE_CHOICE">Nhiều lựa chọn</asp:ListItem>
                    <asp:ListItem Value="TRUE_FALSE">Đúng / Sai</asp:ListItem>
                    <asp:ListItem Value="SHORT_ANSWER">Trả lời ngắn</asp:ListItem>
                    <asp:ListItem Value="CLOZE_DRAG_DROP">Kéo thả vào đoạn văn</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-6">
                <label class="form-label">Câu hỏi từ ngân hàng</label>
                <div class="input-group">
                    <asp:DropDownList ID="QuestionList" runat="server" CssClass="form-select" />
                    <asp:Button
                        ID="OpenQuickQuestionButton"
                        runat="server"
                        Text="Tạo mới"
                        CssClass="btn btn-blue"
                        CausesValidation="false"
                        OnClick="OpenQuickQuestionButton_Click"
                    />
                </div>
            </div>
            <div class="col-md-9">
                <label class="form-label">Tìm nội dung câu hỏi</label>
                <div class="input-group">
                    <asp:TextBox ID="QuestionSearchText" runat="server" CssClass="form-control" />
                    <asp:Button
                        ID="SearchQuestionButton"
                        runat="server"
                        Text="Tìm"
                        CssClass="btn btn-action-view"
                        CausesValidation="false"
                        OnClick="SearchQuestionButton_Click"
                    />
                </div>
            </div>
            <div class="col-md-3">
                <label class="form-label">Điểm</label>
                <asp:TextBox ID="InteractionScoreText" runat="server" CssClass="form-control" />
            </div>
            <div class="col-md-3">
                <label class="form-label">Số lần làm</label>
                <asp:TextBox ID="InteractionAttemptText" runat="server" CssClass="form-control" />
            </div>
            <div class="col-md-3">
                <label class="form-label">Trạng thái</label>
                <asp:DropDownList ID="InteractionStatusList" runat="server" CssClass="form-select">
                    <asp:ListItem Value="ACTIVE">Hoạt động</asp:ListItem>
                    <asp:ListItem Value="INACTIVE">Tạm ẩn</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-6 d-flex flex-wrap gap-4 align-items-center">
                <asp:CheckBox ID="InteractionRequiredCheck" runat="server" Text=" Bắt buộc trả lời" />
                <asp:CheckBox ID="InteractionPauseCheck" runat="server" Text=" Tạm dừng video" />
                <asp:CheckBox ID="InteractionSkipCheck" runat="server" Text=" Cho phép bỏ qua" />
            </div>
        </div>
        <div class="interaction-editor-actions">
            <asp:Button
                ID="DeleteFromEditorButton"
                runat="server"
                Text="Xóa"
                CssClass="btn btn-action-delete"
                CausesValidation="false"
                OnClick="DeleteFromEditorButton_Click"
            />
            <div class="d-flex gap-2">
                <asp:Button
                    ID="CancelInteractionButton"
                    runat="server"
                    Text="Đóng"
                    CssClass="btn btn-action-cancel"
                    CausesValidation="false"
                    OnClick="CloseInteractionButton_Click"
                />
                <asp:Button
                    ID="SaveInteractionButton"
                    runat="server"
                    Text="Lưu tương tác"
                    CssClass="btn btn-action-save"
                    OnClick="SaveInteractionButton_Click"
                />
            </div>
        </div>
    </div>
</asp:Panel>
<asp:Panel ID="DeleteConfirmPanel" runat="server" CssClass="preview-backdrop" Visible="false">
    <div class="confirm-dialog app-card">
        <span class="confirm-icon"><i class="bi bi-trash"></i></span>
        <h2>Xóa tương tác?</h2>
        <p>Mốc câu hỏi sẽ không còn xuất hiện trên timeline và Student Player.</p>
        <div class="d-flex justify-content-end gap-2">
            <asp:Button
                ID="CancelDeleteButton"
                runat="server"
                Text="Hủy"
                CssClass="btn btn-action-cancel"
                CausesValidation="false"
                OnClick="CancelDeleteButton_Click"
            />
            <asp:Button
                ID="ConfirmDeleteButton"
                runat="server"
                Text="Xóa tương tác"
                CssClass="btn btn-action-delete"
                CausesValidation="false"
                OnClick="ConfirmDeleteButton_Click"
            />
        </div>
    </div>
</asp:Panel>
<asp:Panel ID="QuickQuestionPanel" runat="server" CssClass="preview-backdrop" Visible="false">
    <div class="quick-question-dialog app-card">
        <div class="preview-header">
            <div>
                <small>Tạo nhanh trong ngân hàng</small>
                <h2>Câu hỏi mới cho video</h2>
            </div>
            <asp:Button
                ID="CloseQuickQuestionButton"
                runat="server"
                Text="×"
                CssClass="btn btn-light btn-sm"
                CausesValidation="false"
                OnClick="CloseQuickQuestionButton_Click"
            />
        </div>
        <div class="row g-3">
            <div class="col-12">
                <label class="form-label">Nội dung câu hỏi</label>
                <asp:TextBox ID="QuickQuestionText" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control" />
            </div>
            <div class="col-md-5">
                <label class="form-label">Loại câu hỏi</label>
                <asp:DropDownList ID="QuickQuestionTypeList" runat="server" CssClass="form-select">
                    <asp:ListItem Value="SINGLE_CHOICE">Một lựa chọn</asp:ListItem>
                    <asp:ListItem Value="MULTIPLE_CHOICE">Nhiều lựa chọn</asp:ListItem>
                    <asp:ListItem Value="TRUE_FALSE">Đúng / Sai</asp:ListItem>
                    <asp:ListItem Value="SHORT_ANSWER">Trả lời ngắn</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-4">
                <label class="form-label">Độ khó</label>
                <asp:DropDownList ID="QuickDifficultyList" runat="server" CssClass="form-select">
                    <asp:ListItem Value="EASY">Dễ</asp:ListItem>
                    <asp:ListItem Value="MEDIUM">Trung bình</asp:ListItem>
                    <asp:ListItem Value="HARD">Khó</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-3">
                <label class="form-label">Điểm mặc định</label>
                <asp:TextBox ID="QuickScoreText" runat="server" CssClass="form-control" Text="10" />
            </div>
            <div class="col-12">
                <label class="form-label">Phương án (MÃ|Nội dung|1 nếu đúng)</label>
                <asp:TextBox
                    ID="QuickOptionsText"
                    runat="server"
                    TextMode="MultiLine"
                    Rows="5"
                    CssClass="form-control"
                    Text="A||1&#10;B||0"
                />
            </div>
            <div class="col-md-5">
                <label class="form-label">Cách chấm trả lời ngắn</label>
                <asp:DropDownList ID="QuickShortModeList" runat="server" CssClass="form-select">
                    <asp:ListItem Value="EXACT_MATCH">Khớp chính xác</asp:ListItem>
                    <asp:ListItem Value="CONTAINS">Có chứa đáp án</asp:ListItem>
                    <asp:ListItem Value="MANUAL_REVIEW">Giảng viên chấm</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-7">
                <label class="form-label">Đáp án mẫu</label>
                <asp:TextBox ID="QuickAnswerText" runat="server" CssClass="form-control" />
            </div>
        </div>
        <div class="d-flex justify-content-end gap-2 mt-4">
            <asp:Button
                ID="CancelQuickQuestionButton"
                runat="server"
                Text="Hủy"
                CssClass="btn btn-action-cancel"
                CausesValidation="false"
                OnClick="CloseQuickQuestionButton_Click"
            />
            <asp:Button
                ID="SaveQuickQuestionButton"
                runat="server"
                Text="Lưu vào ngân hàng"
                CssClass="btn btn-action-save"
                OnClick="SaveQuickQuestionButton_Click"
            />
        </div>
    </div>
</asp:Panel>
<asp:Panel ID="PreviewPanel" runat="server" CssClass="preview-backdrop" Visible="false">
    <div class="preview-dialog app-card">
        <div class="preview-header">
            <div>
                <small>CHẾ ĐỘ XEM HỌC VIÊN • DỮ LIỆU MỚI NHẤT</small>
                <h2><asp:Literal ID="PreviewTitleText" runat="server" /></h2>
            </div>
            <asp:Button
                ID="ClosePreviewButton"
                runat="server"
                Text="×"
                CssClass="btn btn-light btn-sm"
                CausesValidation="false"
                OnClick="ClosePreviewButton_Click"
            />
        </div>
        <div class="preview-player"><asp:Literal ID="PreviewPlayerHtml" runat="server" /></div>
        <div class="preview-list"><asp:Literal ID="PreviewListHtml" runat="server" /></div>
    </div>
</asp:Panel>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="AddAtCurrentButton" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="PreviewButton" EventName="Click" />
        <asp:PostBackTrigger ControlID="SaveInteractionButton" />
        <asp:PostBackTrigger ControlID="ConfirmDeleteButton" />
        <asp:PostBackTrigger ControlID="SaveQuickQuestionButton" />
    </Triggers>
</asp:UpdatePanel>
<script src="<%= ResolveUrl("~/assets/lms/js/interactive-video.js") %>"></script>
<script src="<%= ResolveUrl("~/assets/lms/js/video-editor.js") %>"></script>
