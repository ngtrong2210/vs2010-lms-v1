<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Search.ascx.cs" Inherits="InformationWeb.Controls.Cms.Search" %>
<link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/css/pages/cms/global-search.css") %>" />
<link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/css/pages/cms/global-search-webforms.css") %>" />
<section>
    <header class="search-page-header mb-4">
        <div class="d-flex flex-wrap justify-content-between align-items-start gap-3">
            <div>
                <span class="search-kicker">
                    <i class="bi bi-stars"></i>
                    TÌM KIẾM TOÀN HỆ THỐNG
                </span>
                <h1 class="page-title mb-1"><asp:Literal ID="PageTitleText" runat="server" /></h1>
                <p class="page-subtitle mb-0"><asp:Literal ID="PageDescriptionText" runat="server" /></p>
            </div>
        </div>
        <div class="page-search">
            <i class="bi bi-search"></i>
            <asp:TextBox
                ID="SearchText"
                runat="server"
                aria-label="Từ khóa tìm kiếm toàn hệ thống"
                placeholder="Nhập ít nhất 2 ký tự..."
                autocomplete="off"
            />
            <asp:Button ID="SearchButton" runat="server" Text="Tìm kiếm" CssClass="btn btn-action-filter" OnClick="SearchButton_Click" />
        </div>
        <asp:Label ID="SearchValidationText" runat="server" CssClass="search-validation" Visible="false" />
    </header>
    <asp:Label ID="ErrorText" runat="server" CssClass="alert alert-danger" Visible="false" />

    <asp:Panel ID="SearchResultsPanel" runat="server" Visible="false">
        <div class="search-summary app-card mb-3">
            <div>
                <span>KẾT QUẢ CHO</span>
                <strong>
                    “
                    <asp:Literal ID="SearchedTermText" runat="server" />
                    ”
                </strong>
            </div>
            <span class="result-total">
                <asp:Literal ID="SearchTotalText" runat="server" />
                kết quả
            </span>
        </div>
        <div class="type-tabs mb-3" role="tablist" aria-label="Lọc loại kết quả">
            <button type="button" class="type-tab active" data-search-type="">
                <i class="bi bi-grid"></i>
                Tất cả
                <span><asp:Literal ID="AllCountText" runat="server" /></span>
            </button>
            <button type="button" class="type-tab" data-search-type="COURSE">
                <i class="bi bi-journal-bookmark"></i>
                Khóa học
                <span><asp:Literal ID="CourseCountText" runat="server" /></span>
            </button>
            <button type="button" class="type-tab" data-search-type="LESSON">
                <i class="bi bi-play-btn"></i>
                Bài học
                <span><asp:Literal ID="LessonCountText" runat="server" /></span>
            </button>
            <button type="button" class="type-tab" data-search-type="VIDEO">
                <i class="bi bi-collection-play"></i>
                Video
                <span><asp:Literal ID="VideoCountText" runat="server" /></span>
            </button>
            <button type="button" class="type-tab" data-search-type="QUESTION">
                <i class="bi bi-patch-question"></i>
                Câu hỏi
                <span><asp:Literal ID="QuestionCountText" runat="server" /></span>
            </button>
            <button type="button" class="type-tab" data-search-type="STUDENT">
                <i class="bi bi-people"></i>
                Học viên
                <span><asp:Literal ID="StudentCountText" runat="server" /></span>
            </button>
        </div>
        <div class="result-list" data-search-results="true">
            <asp:Repeater ID="SearchResultsRepeater" runat="server">
                <ItemTemplate>
                    <a href='<%# SearchTargetUrl(Eval("TargetUrl")) %>' class="result-card app-card" data-result-type='<%# System.Web.HttpUtility.HtmlAttributeEncode(Convert.ToString(Eval("ResultType"))) %>'>
                        <span class='<%# "result-icon type-" + Convert.ToString(Eval("ResultType")).ToLowerInvariant() %>'><i class='<%# "bi " + SearchIcon(Eval("Icon")) %>'></i></span>
                        <span class="result-copy">
                            <span class="result-heading">
                                <span class="result-type"><%# SearchTypeLabel(Eval("ResultType")) %></span>
                                <span class='<%# "status-dot " + SearchStatusClass(Eval("Status")) %>'><%# SearchStatusLabel(Eval("Status")) %></span>
                            </span>
                            <strong><%# Server.HtmlEncode(Convert.ToString(Eval("Title"))) %></strong>
                            <small><%# Server.HtmlEncode(Convert.ToString(Eval("Subtitle"))) %></small>
                            <asp:PlaceHolder runat="server" Visible='<%# !string.IsNullOrWhiteSpace(Convert.ToString(Eval("Description"))) %>'>
                                <span class="result-description"><%# Server.HtmlEncode(Convert.ToString(Eval("Description"))) %></span>
                            </asp:PlaceHolder>
                        </span>
                        <span class="result-open">
                            <span>Mở</span>
                            <i class="bi bi-arrow-right"></i>
                        </span>
                    </a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <asp:Panel ID="NoSearchResultsPanel" runat="server" CssClass="app-card search-state" Visible="false">
            <span class="empty-icon"><i class="bi bi-search"></i></span>
            <h2>Chưa tìm thấy dữ liệu phù hợp</h2>
            <p>Thử tìm bằng mã khóa học, tên bài học, nội dung câu hỏi, tên video hoặc mã học viên.</p>
        </asp:Panel>
        <div class="app-card search-state search-filter-empty" data-filter-empty="true" hidden>
            <span class="empty-icon"><i class="bi bi-filter"></i></span>
            <h2>Không có kết quả thuộc nhóm này</h2>
            <p>Chọn “Tất cả” hoặc một nhóm khác để xem kết quả.</p>
        </div>
    </asp:Panel>

    <asp:Panel ID="SearchGuidePanel" runat="server" CssClass="search-guide">
        <article class="app-card guide-card">
            <span><i class="bi bi-journal-bookmark"></i></span>
            <div>
                <strong>Khóa học và bài học</strong>
                <p>Tìm theo mã, tiêu đề, chương, mô tả hoặc tên giảng viên.</p>
                <small>Ví dụ: VUE-001, Composition API</small>
            </div>
        </article>
        <article class="app-card guide-card">
            <span><i class="bi bi-collection-play"></i></span>
            <div>
                <strong>Video dùng chung</strong>
                <p>Tìm theo tên hiển thị, tên tệp hoặc đường dẫn video trong thư viện.</p>
                <small>Ví dụ: Bài mở đầu, z3.mp4</small>
            </div>
        </article>
        <article class="app-card guide-card">
            <span><i class="bi bi-patch-question"></i></span>
            <div>
                <strong>Ngân hàng câu hỏi</strong>
                <p>Tìm trực tiếp trong nội dung, giải thích, loại và độ khó câu hỏi.</p>
                <small>Ví dụ: Vue Router, câu hỏi đúng sai</small>
            </div>
        </article>
        <article class="app-card guide-card">
            <span><i class="bi bi-people"></i></span>
            <div>
                <strong>Học viên</strong>
                <p>Tìm theo họ tên, mã học viên, tài khoản hoặc địa chỉ email.</p>
                <small>Ví dụ: HV001, Nguyễn Văn Học</small>
            </div>
        </article>
    </asp:Panel>

    <asp:Label ID="EmptyText" runat="server" Visible="false" />
    <asp:GridView ID="DataGrid" runat="server" AutoGenerateColumns="true" CssClass="d-none" aria-hidden="true" />
</section>
<script src="<%= ResolveUrl("~/assets/lms/js/global-search-webforms.js") %>"></script>
