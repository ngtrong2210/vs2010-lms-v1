<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Help.ascx.cs" Inherits="InformationWeb.Controls.Cms.Help" %>
<link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/css/pages/cms/help.css") %>" />
<section class="help-container">
    <asp:Label ID="ActionMessageText" runat="server" Visible="false" CssClass="help-alert" />

    <header class="help-header">
        <h1>Trung tâm trợ giúp</h1>
        <p>Tài liệu hướng dẫn và câu hỏi thường gặp về hệ thống LMS.</p>
    </header>

    <div class="help-search-section">
        <div class="help-search-box">
            <asp:TextBox ID="SearchText" runat="server" CssClass="search-input" placeholder="Tìm kiếm câu hỏi hoặc chủ đề..." />
            <asp:Button ID="SearchButton" runat="server" CssClass="search-button" Text="Tìm kiếm" OnClick="SearchButton_Click" />
        </div>
    </div>

    <div class="help-categories">
        <h2>Danh mục</h2>
        <div class="help-category-list">
            <div class="help-category-item active">
                <div class="category-icon">🚀</div>
                <div class="category-name">Bắt đầu</div>
                <div class="category-count">3 bài viết</div>
            </div>
            <div class="help-category-item">
                <div class="category-icon">📚</div>
                <div class="category-name">Quản lý khóa học</div>
                <div class="category-count">3 bài viết</div>
            </div>
            <div class="help-category-item">
                <div class="category-icon">📝</div>
                <div class="category-name">Quản lý bài học</div>
                <div class="category-count">3 bài viết</div>
            </div>
            <div class="help-category-item">
                <div class="category-icon">👥</div>
                <div class="category-name">Quản lý người dùng</div>
                <div class="category-count">3 bài viết</div>
            </div>
            <div class="help-category-item">
                <div class="category-icon">📊</div>
                <div class="category-name">Báo cáo</div>
                <div class="category-count">2 bài viết</div>
            </div>
            <div class="help-category-item">
                <div class="category-icon">⚙️</div>
                <div class="category-name">Cài đặt</div>
                <div class="category-count">2 bài viết</div>
            </div>
        </div>
    </div>

    <div class="help-articles">
        <h2>Bài viết phổ biến</h2>
        <div class="help-article-grid">
            <div class="help-article-card">
                <div class="article-category">Bắt đầu</div>
                <h3 class="article-title">Giới thiệu hệ thống LMS</h3>
                <p class="article-summary">Tìm hiểu tổng quan về hệ thống quản lý học tập (LMS) và các tính năng chính.</p>
                <div class="article-meta">
                    <span class="article-date">📅 15/10/2026</span>
                    <span class="article-views">👁️ 1,234</span>
                </div>
            </div>
            <div class="help-article-card">
                <div class="article-category">Quản lý khóa học</div>
                <h3 class="article-title">Tạo khóa học mới</h3>
                <p class="article-summary">Hướng dẫn từng bước để tạo một khóa học mới với đầy đủ thông tin.</p>
                <div class="article-meta">
                    <span class="article-date">📅 14/10/2026</span>
                    <span class="article-views">👁️ 987</span>
                </div>
            </div>
            <div class="help-article-card">
                <div class="article-category">Quản lý bài học</div>
                <h3 class="article-title">Tạo bài học mới</h3>
                <p class="article-summary">Hướng dẫn tạo bài học với nội dung văn bản, hình ảnh và video.</p>
                <div class="article-meta">
                    <span class="article-date">📅 13/10/2026</span>
                    <span class="article-views">👁️ 856</span>
                </div>
            </div>
            <div class="help-article-card">
                <div class="article-category">Quản lý người dùng</div>
                <h3 class="article-title">Thêm người dùng mới</h3>
                <p class="article-summary">Cách thêm học viên hoặc giảng viên mới vào hệ thống.</p>
                <div class="article-meta">
                    <span class="article-date">📅 12/10/2026</span>
                    <span class="article-views">👁️ 743</span>
                </div>
            </div>
            <div class="help-article-card">
                <div class="article-category">Báo cáo</div>
                <h3 class="article-title">Theo dõi tiến độ học tập</h3>
                <p class="article-summary">Cách xem và theo dõi tiến độ học tập của học viên.</p>
                <div class="article-meta">
                    <span class="article-date">📅 11/10/2026</span>
                    <span class="article-views">👁️ 632</span>
                </div>
            </div>
            <div class="help-article-card">
                <div class="article-category">Cài đặt</div>
                <h3 class="article-title">Cài đặt chung</h3>
                <p class="article-summary">Cấu hình các thông tin cơ bản của hệ thống.</p>
                <div class="article-meta">
                    <span class="article-date">📅 10/10/2026</span>
                    <span class="article-views">👁️ 521</span>
                </div>
            </div>
        </div>
    </div>

    <div class="help-contact-section">
        <h2>Cần hỗ trợ thêm?</h2>
        <p>Nếu bạn không tìm thấy câu trả lời trong tài liệu trợ giúp, hãy liên hệ với đội ngũ hỗ trợ của chúng tôi.</p>
        <div class="help-contact-items">
            <div class="help-contact-item">
                <div class="contact-icon">📧</div>
                <div class="contact-label">Email</div>
                <div class="contact-value">support@lms.com</div>
            </div>
            <div class="help-contact-item">
                <div class="contact-icon">📞</div>
                <div class="contact-label">Điện thoại</div>
                <div class="contact-value">1900 xxxx</div>
            </div>
            <div class="help-contact-item">
                <div class="contact-icon">💬</div>
                <div class="contact-label">Chat trực tuyến</div>
                <div class="contact-value">Thứ 2 - Thứ 6, 8:00 - 17:00</div>
            </div>
        </div>
        <asp:Button ID="ContactButton" runat="server" CssClass="help-contact-button" Text="Liên hệ hỗ trợ" OnClick="ContactButton_Click" />
    </div>
</section>
