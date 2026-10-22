<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="InformationWeb.Controls.Auth.Login" %>
<!DOCTYPE html>
<html lang="vi">
    <head runat="server">
        <meta charset="utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <title>Đăng nhập - Thiên Hà Số</title>
        <link rel="icon" type="image/png" href="<%= ResolveUrl("~/assets/lms/images/brand/thien-ha-so.png") %>" />
        <link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/vendor/bootstrap.min.css") %>" />
        <link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/vendor/bootstrap-icons.min.css") %>" />
        <link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/eduvers/css/style.css") %>" />
        <link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/eduvers/css/responsive.css") %>" />
        <link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/css/index.css") %>" />
        <link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/css/webforms.css?v=20260901-ui10") %>" />
        <link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/css/pages/auth/login.css") %>" />
    </head>
    <body>
        <form id="LoginForm" runat="server">
            <main class="login-page">
                <aside class="system-panel">
                    <div class="brand brand-lockup" aria-label="Thiên Hà Số">
                        <img class="brand-symbol" src="<%= ResolveUrl("~/assets/lms/images/brand/thien-ha-so.png") %>" alt="" />
                        <span class="brand-name">Thiên Hà Số</span>
                    </div>
                    <div class="system-intro">
                        <p class="eyebrow">HỆ THỐNG QUẢN LÝ HỌC TẬP</p>
                        <h1>Không gian học tập dành cho học viên và giảng viên.</h1>
                        <p>Truy cập bài giảng, thực hiện kiểm tra và theo dõi kết quả học tập trên cùng một hệ thống.</p>
                        <ul class="system-features">
                            <li>
                                <i class="bi bi-collection-play"></i>
                                <span>
                                    <strong>Khóa học và bài giảng</strong>
                                    <small>Nội dung được tổ chức theo chương, bài học.</small>
                                </span>
                            </li>
                            <li>
                                <i class="bi bi-patch-question"></i>
                                <span>
                                    <strong>Video và câu hỏi tương tác</strong>
                                    <small>Thực hành ngay trong quá trình xem bài.</small>
                                </span>
                            </li>
                            <li>
                                <i class="bi bi-bar-chart"></i>
                                <span>
                                    <strong>Tiến độ và kết quả</strong>
                                    <small>Theo dõi quá trình học tập theo thời gian.</small>
                                </span>
                            </li>
                        </ul>
                    </div>
                    <div class="support-box">
                        <i class="bi bi-headset"></i>
                        <span>
                            <small>Cần hỗ trợ đăng nhập?</small>
                            <strong>Liên hệ bộ phận quản trị đào tạo</strong>
                        </span>
                    </div>
                </aside>
                <section class="form-panel">
                    <div class="login-card">
                        <div class="mobile-brand brand-lockup" aria-label="Thiên Hà Số">
                            <img class="brand-symbol" src="<%= ResolveUrl("~/assets/lms/images/brand/thien-ha-so.png") %>" alt="" />
                            <span class="brand-name">Thiên Hà Số</span>
                        </div>
                        <header class="form-heading">
                            <span>ĐĂNG NHẬP TÀI KHOẢN</span>
                            <h2>Đăng nhập hệ thống</h2>
                            <p>Sử dụng tài khoản được cấp để truy cập khóa học của bạn.</p>
                        </header>
                        <asp:ValidationSummary
                            ID="ValidationSummary"
                            runat="server"
                            ValidationGroup="Login"
                            CssClass="alert alert-danger py-2"
                        />
                        <asp:Label ID="MessageText" runat="server" CssClass="alert alert-danger py-2 status-message" Visible="false" />
                        <div class="field-group">
                            <label class="form-label" for="UsernameText">Tên đăng nhập</label>
                            <div class="input-wrap">
                                <i class="bi bi-person"></i>
                                <asp:TextBox
                                    ID="UsernameText"
                                    runat="server"
                                    CssClass="form-control"
                                    MaxLength="100"
                                    autocomplete="username"
                                    placeholder="Nhập tên đăng nhập"
                                />
                            </div>
                            <asp:RequiredFieldValidator
                                ID="UsernameRequired"
                                runat="server"
                                ControlToValidate="UsernameText"
                                ErrorMessage="Vui lòng nhập tên đăng nhập."
                                ValidationGroup="Login"
                                Display="Dynamic"
                            />
                        </div>
                        <div class="field-group">
                            <label class="form-label" for="PasswordText">Mật khẩu</label>
                            <div class="input-wrap">
                                <i class="bi bi-lock"></i>
                                <asp:TextBox
                                    ID="PasswordText"
                                    runat="server"
                                    CssClass="form-control"
                                    TextMode="Password"
                                    MaxLength="200"
                                    autocomplete="current-password"
                                    placeholder="Nhập mật khẩu"
                                />
                                <button type="button" data-password-toggle aria-label="Hiện mật khẩu"><i class="bi bi-eye"></i></button>
                            </div>
                            <asp:RequiredFieldValidator
                                ID="PasswordRequired"
                                runat="server"
                                ControlToValidate="PasswordText"
                                ErrorMessage="Vui lòng nhập mật khẩu."
                                ValidationGroup="Login"
                                Display="Dynamic"
                            />
                        </div>
                        <div class="form-options">
                            <label><asp:CheckBox ID="RememberCheck" runat="server" Text=" Ghi nhớ đăng nhập" /></label>
                            <span class="text-secondary">Tài khoản được nhà trường cấp</span>
                        </div>
                        <asp:Button
                            ID="LoginButton"
                            runat="server"
                            Text="Đăng nhập  →"
                            CssClass="btn btn-brand login-button w-100"
                            ValidationGroup="Login"
                            OnClick="LoginButton_Click"
                        />
                        <div class="demo-box">
                            <div class="demo-heading">
                                <strong>Tài khoản dùng thử</strong>
                                <small>Nhấn để điền nhanh</small>
                            </div>
                            <div class="demo-accounts">
                                <button type="button" class="demo-account" data-demo-login="student">
                                    <span>Học viên</span>
                                    <code>student</code>
                                </button>
                                <button type="button" class="demo-account" data-demo-login="teacher">
                                    <span>Giảng viên</span>
                                    <code>teacher</code>
                                </button>
                                <button type="button" class="demo-account" data-demo-login="admin">
                                    <span>Quản trị</span>
                                    <code>admin</code>
                                </button>
                            </div>
                            <p>
                                Mật khẩu dùng chung:
                                <strong>123456</strong>
                            </p>
                        </div>
                        <p class="security-note">
                            <i class="bi bi-shield-check"></i>
                            Không chia sẻ thông tin đăng nhập cho người khác.
                        </p>
                    </div>
                    <footer>© 2026 Thiên Hà Số · Hệ thống quản lý học tập</footer>
                </section>
            </main>
        </form>
        <script src="<%= ResolveUrl("~/assets/lms/js/app.js?v=20260901-ui6") %>"></script>
    </body>
</html>
