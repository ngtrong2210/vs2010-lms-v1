<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VideoLibrary.ascx.cs" Inherits="InformationWeb.Controls.Cms.VideoLibrary" %>
<link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/css/pages/cms/video-library.css") %>" />
<section class="video-library-page">
    <header class="d-flex flex-wrap justify-content-between align-items-end gap-3 mb-4">
        <div>
            <h1 class="page-title mb-1">Thư viện video</h1>
            <p class="page-subtitle mb-0">Video mặc định chỉ tác giả nhìn thấy; có thể chia sẻ cho giáo viên khác hoặc toàn trường.</p>
        </div>
        <div class="cms-page-actions">
            <asp:LinkButton ID="OpenCreateButton" runat="server" CssClass="btn btn-action-create" OnClick="OpenCreateButton_Click">
                <i class="bi bi-cloud-arrow-up"></i>
                Thêm video
            </asp:LinkButton>
        </div>
    </header>
    <asp:Label ID="MessageText" runat="server" Visible="false" />
    <div class="app-card filter-card mb-3">
        <div class="filter-grid">
            <label class="filter-field search-field">
                <span>Tìm nhanh</span>
                <span class="search-box">
                    <i class="bi bi-search"></i>
                    <asp:TextBox ID="SearchText" runat="server" CssClass="form-control" placeholder="Tên video, tên file hoặc tác giả..." />
                </span>
            </label>
            <label class="filter-field">
                <span>Quyền truy cập</span>
                <asp:DropDownList ID="AccessFilter" runat="server" CssClass="form-select">
                    <asp:ListItem Value="ALL">Tất cả được phép xem</asp:ListItem>
                    <asp:ListItem Value="MINE">Video của tôi</asp:ListItem>
                    <asp:ListItem Value="SHARED">Được chia sẻ với tôi</asp:ListItem>
                    <asp:ListItem Value="SCHOOL">Chia sẻ toàn trường</asp:ListItem>
                </asp:DropDownList>
            </label>
            <label class="filter-field">
                <span>Tình trạng dùng</span>
                <asp:DropDownList ID="UsageFilter" runat="server" CssClass="form-select">
                    <asp:ListItem Value="ALL">Tất cả</asp:ListItem>
                    <asp:ListItem Value="USED">Đang dùng</asp:ListItem>
                    <asp:ListItem Value="UNUSED">Chưa sử dụng</asp:ListItem>
                </asp:DropDownList>
            </label>
            <label class="filter-field">
                <span>Trạng thái</span>
                <asp:DropDownList ID="StatusFilter" runat="server" CssClass="form-select">
                    <asp:ListItem Value="ALL">Tất cả</asp:ListItem>
                    <asp:ListItem Value="ACTIVE">Hoạt động</asp:ListItem>
                    <asp:ListItem Value="INACTIVE">Tạm ẩn</asp:ListItem>
                </asp:DropDownList>
            </label>
            <div class="filter-search-action">
                <asp:Button ID="SearchButton" runat="server" Text="Tìm kiếm" CssClass="btn btn-action-view" OnClick="SearchButton_Click" />
            </div>
        </div>
        <div class="filter-footer">
            <span>
                <i class="bi bi-collection-play"></i>
                Tìm thấy
                <strong><asp:Literal ID="ResultCountText" runat="server" /></strong>
                video
            </span>
            <asp:Button
                ID="ClearFiltersButton"
                runat="server"
                Text="Xóa bộ lọc"
                CssClass="btn btn-action-cancel btn-sm"
                CausesValidation="false"
                OnClick="ClearFiltersButton_Click"
            />
        </div>
    </div>
    <div class="app-card p-2">
        <asp:Label ID="EmptyText" runat="server" CssClass="empty-state" Text="Không có video phù hợp với bộ lọc." Visible="false" />
        <div class="table-responsive">
            <table class="table align-middle mb-0">
                <thead>
                    <tr>
                        <th>Video</th>
                        <th>Quyền truy cập</th>
                        <th>
                            Thời lượng /
                            <br />
                            Sử dụng
                        </th>
                        <th>
                            Người tạo
                            <br />
                            / Ngày tạo
                        </th>
                        <th class="text-end">Thao tác</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater
                        ID="VideosRepeater"
                        runat="server"
                        OnItemCreated="VideosRepeater_ItemCreated"
                        OnItemCommand="VideosRepeater_ItemCommand"
                    >
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <div class="video-name">
                                        <span class="video-thumb" style='<%# ThumbnailStyle(Eval("PosterUrl"), Container.ItemIndex) %>'><i class="bi bi-play-fill"></i></span>
                                        <div>
                                            <strong><%#: Eval("Title") %></strong>
                                            <span class="video-source-badge local">
                                                <i class="bi bi-file-play"></i>
                                                Tải lên
                                            </span>
                                            <small><%#: SourceDescription(Eval("OriginalFileName"), Eval("VideoUrl")) %></small>
                                        </div>
                                    </div>
                                </td>
                                <td>
                                    <span class='<%# AccessCss(Eval("AccessType")) %>'>
                                        <i class='<%# AccessIcon(Eval("AccessType")) %>'></i>
                                        <%#: AccessLabel(Eval("AccessType"), Eval("ShareScope"), Eval("SharedTeacherCount")) %>
                                    </span>
                                </td>
                                <td>
                                    <div class="video-usage-summary">
                                        <strong>
                                            <i class="bi bi-clock"></i>
                                            <%#: FormatDuration(Eval("DurationSeconds")) %>
                                        </strong>
                                        <span class="badge badge-soft-primary"><%#: Eval("UsageCount") %> bài học</span>
                                    </div>
                                </td>
                                <td>
                                    <div class="video-creator-summary">
                                        <strong class="author-name"><%#: Eval("CreatedByName") %></strong>
                                        <span>
                                            <i class="bi bi-calendar3"></i>
                                            <%#: FormatDate(Eval("CreatedAt")) %>
                                        </span>
                                    </div>
                                </td>
                                <td class="text-end action-cell">
                                    <div class="video-action-group">
                                        <asp:LinkButton
                                            ID="EditInfoButton"
                                            runat="server"
                                            CssClass="btn btn-action-edit btn-sm edit-button"
                                            CommandName="EditInfo"
                                            CommandArgument='<%# Eval("Id") %>'
                                            Visible='<%# ToBool(Eval("CanEdit")) %>'
                                            CausesValidation="false"
                                        >
                                            <i class="bi bi-pencil-square"></i>
                                            <span>Thông tin</span>
                                        </asp:LinkButton>
                                        <asp:HyperLink
                                            ID="OpenEditorLink"
                                            runat="server"
                                            CssClass="btn btn-action-view btn-sm"
                                            NavigateUrl='<%# EditorUrl(Eval("FirstVideoId")) %>'
                                            Visible='<%# ToLong(Eval("FirstVideoId")) > 0 && ToBool(Eval("CanOpenEditor")) %>'
                                        >
                                            <i class='<%# ToBool(Eval("CanEdit")) ? "bi bi-sliders" : "bi bi-eye" %>'></i>
                                            <span><%# ToBool(Eval("CanEdit")) ? "Soạn tương tác" : "Xem video" %></span>
                                        </asp:HyperLink>
                                        <asp:LinkButton
                                            ID="DuplicateButton"
                                            runat="server"
                                            CssClass="btn btn-action-copy btn-sm"
                                            CommandName="Duplicate"
                                            CommandArgument='<%# Eval("Id") %>'
                                            Visible='<%# ToBool(Eval("CanDuplicate")) %>'
                                            CausesValidation="false"
                                            OnClientClick="return confirm('Nhân bản video và toàn bộ câu hỏi tương tác?');"
                                        >
                                            <i class="bi bi-copy"></i>
                                            <span>Nhân bản</span>
                                        </asp:LinkButton>
                                        <asp:LinkButton
                                            ID="ShareButton"
                                            runat="server"
                                            CssClass="btn btn-action-share btn-sm share-button"
                                            CommandName="Share"
                                            CommandArgument='<%# Eval("Id") %>'
                                            Visible='<%# ToBool(Eval("CanShare")) %>'
                                            CausesValidation="false"
                                        >
                                            <i class="bi bi-share"></i>
                                            <span>Chia sẻ</span>
                                        </asp:LinkButton>
                                        <asp:LinkButton
                                            ID="DeleteButton"
                                            runat="server"
                                            CssClass="btn btn-action-delete btn-sm"
                                            CommandName="DeleteVideo"
                                            CommandArgument='<%# Eval("Id") %>'
                                            Visible='<%# ToBool(Eval("IsOwner")) || ToBool(Eval("CanDelete")) %>'
                                            Enabled='<%# ToBool(Eval("CanDelete")) %>'
                                            CausesValidation="false"
                                            OnClientClick="return confirm('Xóa video khỏi thư viện?');"
                                        >
                                            <i class="bi bi-trash"></i>
                                            <span>Xóa</span>
                                        </asp:LinkButton>
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>
</section>
<asp:UpdatePanel ID="VideoModalUpdatePanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
    <ContentTemplate>
<asp:Panel ID="VideoModalPanel" runat="server" CssClass="modal-mask" Visible="false">
    <div class="app-card upload-modal" role="dialog" aria-modal="true">
        <div class="modal-heading">
            <div>
                <small><asp:Literal ID="VideoModalEyebrow" runat="server" /></small>
                <h2><asp:Literal ID="VideoModalTitle" runat="server" /></h2>
                <p><asp:Literal ID="VideoModalDescription" runat="server" /></p>
            </div>
            <asp:LinkButton
                ID="CloseVideoModalButton"
                runat="server"
                CssClass="btn-close"
                CausesValidation="false"
                OnClick="CloseVideoModalButton_Click"
            />
        </div>
        <asp:HiddenField ID="VideoAssetIdValue" runat="server" />
        <asp:HiddenField ID="VideoUrlValue" runat="server" />
        <asp:HiddenField ID="ExistingFileSizeValue" runat="server" />
        <asp:HiddenField ID="ExistingOriginalFileValue" runat="server" />
        <asp:HiddenField ID="ExistingMimeValue" runat="server" />
        <label class="drop-zone">
            <i class="bi bi-cloud-arrow-up"></i>
            <strong>Chọn file video</strong>
            <span>MP4, WebM, OGV hoặc MOV; file lưu trong project.</span>
            <asp:FileUpload ID="VideoFile" runat="server" CssClass="visually-hidden" />
        </label>
        <asp:Literal ID="VideoPreviewHtml" runat="server" />
        <div class="row g-3 mt-1">
            <div class="col-md-6">
                <label class="form-label">Tên video</label>
                <asp:TextBox ID="VideoTitleText" runat="server" CssClass="form-control" MaxLength="500" />
            </div>
            <div class="col-md-3">
                <label class="form-label">Thời lượng (giây)</label>
                <asp:TextBox ID="DurationText" runat="server" CssClass="form-control" />
            </div>
            <div class="col-md-3">
                <label class="form-label">Trạng thái</label>
                <asp:DropDownList ID="VideoStatusList" runat="server" CssClass="form-select">
                    <asp:ListItem Value="ACTIVE">Hoạt động</asp:ListItem>
                    <asp:ListItem Value="INACTIVE">Tạm ẩn</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-12">
                <label class="form-label">URL tương đối trong project</label>
                <asp:TextBox ID="VideoUrlText" runat="server" CssClass="form-control" ReadOnly="true" />
            </div>
        </div>
        <asp:Panel ID="SyncNoticePanel" runat="server" CssClass="version-panel sync-panel" Visible="false">
            <div class="version-panel-heading">
                <div>
                    <span class="version-badge">
                        <i class="bi bi-arrow-repeat"></i>
                        Đồng bộ an toàn
                    </span>
                    <h3>
                        <asp:Literal ID="UsageCountText" runat="server" />
                        bài học sẽ nhận nội dung mới
                    </h3>
                    <p>Tiến độ xem chưa có điểm sẽ được đặt lại để học viên bắt đầu đúng nội dung vừa cập nhật.</p>
                </div>
                <span class="usage-total">Chưa có kết quả</span>
            </div>
        </asp:Panel>
        <div class="modal-actions">
            <asp:Button
                ID="CancelVideoButton"
                runat="server"
                Text="Hủy"
                CssClass="btn btn-action-cancel"
                CausesValidation="false"
                OnClick="CloseVideoModalButton_Click"
            />
            <asp:Button
                ID="SaveVideoButton"
                runat="server"
                Text="Lưu vào thư viện"
                CssClass="btn btn-action-save"
                OnClick="SaveVideoButton_Click"
            />
        </div>
    </div>
</asp:Panel>
<asp:Panel ID="ShareModalPanel" runat="server" CssClass="modal-mask" Visible="false">
    <div class="app-card upload-modal share-modal" role="dialog" aria-modal="true">
        <div class="modal-heading">
            <div>
                <small>Quyền truy cập video</small>
                <h2>
                    Chia sẻ “
                    <asp:Literal ID="ShareVideoTitleText" runat="server" />
                    ”
                </h2>
                <p>Chỉ cấp quyền nhìn thấy và sử dụng trong bài học; người nhận không thể xóa hoặc chia sẻ lại.</p>
            </div>
            <asp:LinkButton
                ID="CloseShareButton"
                runat="server"
                CssClass="btn-close"
                CausesValidation="false"
                OnClick="CloseShareButton_Click"
            />
        </div>
        <asp:HiddenField ID="ShareAssetIdValue" runat="server" />
        <asp:RadioButtonList ID="ShareScopeList" runat="server" CssClass="scope-options" RepeatLayout="Flow">
            <asp:ListItem Value="PRIVATE">Chỉ mình tôi — Chỉ tác giả và quản trị viên nhìn thấy.</asp:ListItem>
            <asp:ListItem Value="SELECTED">Giáo viên được chọn — Chia sẻ cho giáo viên cụ thể.</asp:ListItem>
            <asp:ListItem Value="SCHOOL">Toàn trường — Mọi giáo viên đều có thể sử dụng.</asp:ListItem>
        </asp:RadioButtonList>
        <div class="teacher-picker">
            <div class="teacher-picker-head">
                <span>
                    <i class="bi bi-search"></i>
                    Chọn giáo viên được chia sẻ
                </span>
            </div>
            <div class="teacher-list"><asp:CheckBoxList ID="SharedTeachersList" runat="server" RepeatLayout="Flow" /></div>
        </div>
        <div class="modal-actions">
            <asp:Button
                ID="CancelShareButton"
                runat="server"
                Text="Hủy"
                CssClass="btn btn-action-cancel"
                CausesValidation="false"
                OnClick="CloseShareButton_Click"
            />
            <asp:Button
                ID="SaveSharingButton"
                runat="server"
                Text="Lưu chia sẻ"
                CssClass="btn btn-action-share"
                OnClick="SaveSharingButton_Click"
            />
        </div>
    </div>
</asp:Panel>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="OpenCreateButton" EventName="Click" />
        <asp:PostBackTrigger ControlID="SaveVideoButton" />
        <asp:PostBackTrigger ControlID="SaveSharingButton" />
    </Triggers>
</asp:UpdatePanel>
