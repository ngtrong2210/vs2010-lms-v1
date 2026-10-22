<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LessonPlayer.ascx.cs" Inherits="InformationWeb.Controls.Lms.LessonPlayer" %>
<link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/css/pages/lms/lesson-player.css?v=20260901-ui11") %>" />
<link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/css/pages/lms/lesson-player-webforms.css?v=20260901-ui1") %>" />
<link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/css/pages/lms/lesson-discussion.css?v=20260901-ui11") %>" />
<link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/css/components/interactive-video-player.css?v=20260901-ui11") %>" />
<link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/css/components/interactive-content-viewer.css?v=20260901-ui11") %>" />
<link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/css/components/interactive-content-viewer-webforms.css?v=20260901-ui1") %>" />
<section class="lesson-player-page <%= LessonPageCss %>" data-lesson-player-page>
    <header class="lesson-player-header">
        <a class="lesson-back-link" href="<%= ResolveUrl("~/lms/courses") %>">
            <i class="bi bi-arrow-left"></i>
            <span>Trở về môn học</span>
        </a>
        <div class="lesson-header-context">
            <span><asp:Literal ID="CourseTitleText" runat="server" /></span>
            <div>
                <span class="course-progress-track"><i style="width: <%= CourseProgressPercent %>%"></i></span>
                <small><%= CompletedLessons %>/<%= LessonCount %> bài · <%= CourseProgressPercent %>%</small>
            </div>
        </div>
        <div class="lesson-header-actions">
            <span title="Tổng thời gian học trong môn học">
                <i class="bi bi-clock"></i>
                <%= StudyTimeText %>
            </span>
            <button type="button" title="Chế độ tập trung" aria-label="Chế độ tập trung" data-lesson-focus-toggle>
                <i class="bi bi-arrows-fullscreen"></i>
            </button>
            <button
                type="button"
                title="Ẩn hoặc hiện nội dung môn học"
                aria-label="Ẩn hoặc hiện nội dung môn học"
                data-lesson-sidebar-toggle
            >
                <i class="bi bi-layout-sidebar-reverse"></i>
            </button>
        </div>
    </header>

    <asp:Label ID="SuccessText" runat="server" CssClass="alert alert-success status-message lesson-status-message" Visible="false" />
    <asp:Label ID="ErrorText" runat="server" CssClass="alert alert-danger status-message lesson-status-message" Visible="false" />
    <asp:Label
        ID="EmptyText"
        runat="server"
        CssClass="empty-state"
        Text="Không tìm thấy bài học hoặc bạn chưa được ghi danh."
        Visible="false"
    />

    <div
        id="lessonPlayerHost"
        class="player-grid"
        data-lesson-id="<%= LessonId %>"
        data-course-id="<%= CourseId %>"
        data-student-id="<%= CurrentUser == null ? 0 : CurrentUser.UserID %>"
        data-handler-url='<%= ResolveUrl("~/Handlers/Lms/Module.ashx") %>'
    >
        <asp:HiddenField ID="VideoInteractionsJsonValue" runat="server" />
        <div class="video-area">
            <div class="current-lesson-heading <%= LessonTypeCss %>-surface">
                <span class="lesson-type-icon <%= LessonTypeCss %>"><i class="bi <%= LessonTypeIconCss %>"></i></span>
                <div>
                    <small><%= LessonTypeLabel %></small>
                    <h1><asp:Literal ID="LessonTitleText" runat="server" /></h1>
                </div>
                <span class="lesson-watch-status">
                    Đã xem
                    <asp:Literal ID="WatchPercentText" runat="server" />
                    %
                </span>
            </div>
            <div class="video-stage">
                <asp:Panel ID="VideoPanel" runat="server" CssClass="lesson-video-host">
                    <asp:Literal ID="VideoHostHtml" runat="server" />
                </asp:Panel>
                <asp:Panel ID="ContentPanel" runat="server" CssClass="learning-content editor-content document-content">
                    <div class="lesson-html"><asp:Literal ID="ContentHtmlText" runat="server" /></div>
                </asp:Panel>
                <asp:Panel ID="DocumentPanel" runat="server" CssClass="learning-content editor-content document-content" Visible="false">
                    <asp:Literal ID="DocumentHtml" runat="server" />
                </asp:Panel>
                <asp:Panel ID="AssignmentPanel" runat="server" CssClass="learning-content assignment-content" Visible="false">
                    <div class="assignment-heading">
                        <span class="content-type-icon"><i class="bi bi-clipboard-check-fill"></i></span>
                        <div>
                            <small>Bài tập cần nộp</small>
                            <h2><asp:Literal ID="AssignmentTitleText" runat="server" /></h2>
                        </div>
                        <asp:Literal ID="AssignmentMetaHtml" runat="server" />
                    </div>
                    <section class="assignment-requirements">
                        <h3>
                            <i class="bi bi-list-check"></i>
                            Yêu cầu bài tập
                        </h3>
                        <div class="lesson-html"><asp:Literal ID="AssignmentDescriptionHtml" runat="server" /></div>
                    </section>
                    <div class="assignment-form">
                        <div class="submission-heading">
                            <div>
                                <small>NỘP BÀI</small>
                                <h3>Chọn cách hoàn thành bài tập</h3>
                            </div>
                        </div>
                        <label class="submission-editor">
                            <span>Nội dung bài làm</span>
                            <asp:TextBox
                                ID="AssignmentText"
                                runat="server"
                                TextMode="MultiLine"
                                Rows="7"
                                CssClass="form-control"
                                placeholder="Nhập nội dung bài làm của bạn tại đây..."
                            />
                        </label>
                        <label class="submission-upload">
                            <asp:FileUpload ID="AssignmentFile" runat="server" CssClass="visually-hidden" />
                            <i class="bi bi-cloud-arrow-up"></i>
                            <strong>Chọn file bài làm</strong>
                            <span>PDF, Word, Excel, PowerPoint, ZIP, TXT hoặc ảnh</span>
                        </label>
                        <div class="assignment-actions">
                            <button type="submit" name="lessonAction" value="assignmentDraft" class="btn btn-action-view">
                                <i class="bi bi-floppy"></i>
                                Lưu nháp
                            </button>
                            <button
                                type="submit"
                                name="lessonAction"
                                value="assignmentSubmit"
                                class="btn btn-action-save assignment-submit"
                                data-confirm="Bạn chắc chắn muốn nộp bài?"
                            >
                                <i class="bi bi-send-check"></i>
                                Nộp bài ngay
                            </button>
                        </div>
                    </div>
                    <div class="submission-history">
                        <h3>Lịch sử nộp bài</h3>
                        <asp:Literal ID="AssignmentHistoryHtml" runat="server" />
                    </div>
                </asp:Panel>
                <asp:Panel ID="QuizPanel" runat="server" CssClass="learning-content quiz-content" Visible="false">
                    <div class="content-type-icon"><i class="bi bi-ui-checks"></i></div>
                    <h2>Bài kiểm tra</h2>
                    <asp:Literal ID="QuizHtml" runat="server" />
                </asp:Panel>
                <asp:Panel
                    ID="InteractivePanel"
                    runat="server"
                    CssClass="interactive-content-viewer interactive-content-webforms"
                    Visible="false"
                >
                    <header class="interactive-webforms-heading">
                        <span class="content-type-icon"><i class="bi bi-journal-check"></i></span>
                        <div>
                            <span>NỘI DUNG TƯƠNG TÁC</span>
                            <h2>Kiểm tra mức độ hiểu bài</h2>
                            <p>Trả lời ngay trong lúc học. Mỗi kết quả được lưu để bạn có thể tiếp tục sau khi tải lại trang.</p>
                        </div>
                    </header>
                    <div class="interactive-webforms-body"><asp:Literal ID="InteractiveHtml" runat="server" /></div>
                </asp:Panel>
            </div>
            <div class="lesson-meta">
                <div>
                    <p><asp:Literal ID="LessonDescriptionText" runat="server" /></p>
                </div>
                <div class="score">
                    <strong><%= CurrentScoreText %></strong>
                    <small>Điểm hiện tại</small>
                </div>
            </div>
        </div>

        <div class="lesson-support-column">
            <nav class="lesson-tabs" aria-label="Nội dung bổ sung của bài học">
                <button type="button" class="active" data-lesson-tab="overview">
                    <i class="bi bi-info-circle"></i>
                    Tổng quan
                </button>
                <button type="button" data-lesson-tab="resources">
                    <i class="bi bi-folder2-open"></i>
                    Tài nguyên
                </button>
                <button type="button" data-lesson-tab="discussion">
                    <i class="bi bi-chat-dots"></i>
                    Thảo luận
                    <span><%= DiscussionCount %></span>
                </button>
            </nav>
            <div data-lesson-tab-panel="overview">
                <asp:Panel ID="VideoInteractionPanel" runat="server" CssClass="app-card p-4 mt-4 interaction-overview-card">
                    <h2 class="h5 fw-bold">Mốc câu hỏi tương tác</h2>
                    <asp:Literal ID="VideoQuestionsHtml" runat="server" />
                </asp:Panel>
                <asp:Panel ID="CompletionPanel" runat="server" CssClass="lesson-completion app-card mt-4" Visible="false">
                    <div>
                        <strong>Hoàn thành nội dung này?</strong>
                        <small>Hệ thống ghi nhận tiến độ khi bạn đang học trên trang.</small>
                    </div>
                    <button type="button" class="btn btn-action-save">
                        <i class="bi bi-check2-circle"></i>
                        Đánh dấu hoàn thành
                    </button>
                </asp:Panel>
            </div>
            <section class="lesson-resource-tab app-card" data-lesson-tab-panel="resources" hidden>
                <asp:Literal ID="ResourceHtml" runat="server" />
            </section>
            <section class="lesson-discussion" data-lesson-tab-panel="discussion" hidden>
                <div class="discussion-heading">
                    <div>
                        <span>THẢO LUẬN</span>
                        <h2>Trao đổi về bài học</h2>
                        <p>Đặt câu hỏi và chia sẻ nội dung với lớp học.</p>
                    </div>
                    <strong><%= DiscussionCount %> bình luận</strong>
                </div>
                <div class="discussion-composer">
                    <asp:TextBox
                        ID="CommentText"
                        runat="server"
                        TextMode="MultiLine"
                        Rows="3"
                        CssClass="form-control"
                        MaxLength="5000"
                        placeholder="Nhập bình luận hoặc câu hỏi..."
                    />
                    <div>
                        <small>Tối đa 5.000 ký tự</small>
                        <button type="submit" name="lessonAction" value="commentCreate" class="btn-comment-primary">
                            <i class="bi bi-send-fill"></i>
                            Gửi bình luận
                        </button>
                    </div>
                </div>
                <div class="discussion-list"><asp:Literal ID="CommentsHtml" runat="server" /></div>
            </section>
            <nav class="lesson-navigation" aria-label="Điều hướng bài học"><%= LessonNavigationHtml %></nav>
        </div>

        <button type="button" class="curriculum-backdrop" aria-label="Đóng nội dung môn học" data-lesson-sidebar-close></button>
        <aside class="content-panel" data-lesson-curriculum>
            <div class="curriculum-heading">
                <div>
                    <strong>Nội dung môn học</strong>
                    <small><%= CompletedLessons %>/<%= LessonCount %> bài đã hoàn thành</small>
                </div>
                <button type="button" title="Đóng danh sách" aria-label="Đóng danh sách" data-lesson-sidebar-close>
                    <i class="bi bi-x-lg"></i>
                </button>
            </div>
            <div class="chapter-list"><%= CurriculumHtml %></div>
        </aside>
    </div>
</section>
<script src="<%= ResolveUrl("~/assets/lms/js/interactive-video.js") %>"></script>
