<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Settings.ascx.cs" Inherits="InformationWeb.Controls.Cms.Settings" %>
<link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/css/pages/cms/settings.css") %>" />
<section class="settings-container">
    <header class="settings-header">
        <h1>Cài đặt hệ thống</h1>
        <p>Cấu hình các tham số và tùy chọn của hệ thống LMS.</p>
    </header>

    <asp:Label ID="ActionMessageText" runat="server" Visible="false" CssClass="settings-alert" />

    <div class="settings-nav">
        <asp:Repeater ID="SettingsNavRepeater" runat="server" OnItemCommand="SettingsNavRepeater_ItemCommand">
            <ItemTemplate>
                <asp:LinkButton ID="NavButton" runat="server" CommandName="SwitchTab" CommandArgument='<%# Eval("TabName") %>'
                    CssClass="settings-nav-item">
                    <asp:Literal ID="NavText" runat="server" Text='<%# Eval("Title") %>' />
                </asp:LinkButton>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <div class="settings-content">
        <asp:Panel ID="GeneralSettingsPanel" runat="server" CssClass="settings-panel active" Visible="true">
            <h2>Cài đặt chung</h2>
            <div class="settings-form-group">
                <label>Tên hệ thống</label>
                <asp:TextBox ID="SystemNameText" runat="server" CssClass="form-control" />
            </div>
            <div class="settings-form-group">
                <label>Logo URL</label>
                <asp:TextBox ID="LogoUrlText" runat="server" CssClass="form-control" />
            </div>
            <div class="settings-form-group">
                <label>Email hỗ trợ</label>
                <asp:TextBox ID="SupportEmailText" runat="server" CssClass="form-control" />
            </div>
            <div class="settings-form-group">
                <label>Số điện thoại hỗ trợ</label>
                <asp:TextBox ID="SupportPhoneText" runat="server" CssClass="form-control" />
            </div>
            <div class="settings-form-group">
                <label>Múi giờ</label>
                <asp:DropDownList ID="TimeZoneList" runat="server" CssClass="form-control">
                    <asp:ListItem Value="Asia/Ho_Chi_Minh" Text="GMT+7 (Vietnam)" />
                    <asp:ListItem Value="Asia/Bangkok" Text="GMT+7 (Bangkok)" />
                    <asp:ListItem Value="Asia/Singapore" Text="GMT+8 (Singapore)" />
                    <asp:ListItem Value="UTC" Text="UTC" />
                </asp:DropDownList>
            </div>
            <div class="settings-form-group">
                <label>Ngôn ngữ mặc định</label>
                <asp:DropDownList ID="LanguageList" runat="server" CssClass="form-control">
                    <asp:ListItem Value="vi-VN" Text="Tiếng Việt" />
                    <asp:ListItem Value="en-US" Text="English" />
                </asp:DropDownList>
            </div>
            <div class="settings-action-bar">
                <asp:Button ID="SaveGeneralButton" runat="server" CssClass="btn btn-primary" Text="Lưu cài đặt" OnClick="SaveGeneralButton_Click" />
            </div>
        </asp:Panel>

        <asp:Panel ID="SecuritySettingsPanel" runat="server" CssClass="settings-panel" Visible="false">
            <h2>Cài đặt bảo mật</h2>
            <div class="settings-form-group">
                <label class="checkbox-label">
                    <asp:CheckBox ID="StrongPasswordCheck" runat="server" />
                    Yêu cầu mật khẩu mạnh
                </label>
                <span class="help-text">Mật khẩu phải có ít nhất 8 ký tự, bao gồm chữ hoa, chữ thường và số.</span>
            </div>
            <div class="settings-form-group">
                <label>Thời gian hết hạn session (phút)</label>
                <asp:TextBox ID="SessionTimeoutText" runat="server" CssClass="form-control" TextMode="Number" Value="60" />
            </div>
            <div class="settings-form-group">
                <label>Số lần đăng nhập thất bại tối đa</label>
                <asp:TextBox ID="MaxLoginAttemptsText" runat="server" CssClass="form-control" TextMode="Number" Value="5" />
            </div>
            <div class="settings-form-group">
                <label>Thời gian khóa tài khoản (phút)</label>
                <asp:TextBox ID="LockoutDurationText" runat="server" CssClass="form-control" TextMode="Number" Value="30" />
            </div>
            <div class="settings-form-group">
                <label class="checkbox-label">
                    <asp:CheckBox ID="Enable2FACheck" runat="server" />
                    Bật xác thực 2FA
                </label>
            </div>
            <div class="settings-action-bar">
                <asp:Button ID="SaveSecurityButton" runat="server" CssClass="btn btn-primary" Text="Lưu cài đặt" OnClick="SaveSecurityButton_Click" />
            </div>
        </asp:Panel>

        <asp:Panel ID="CourseSettingsPanel" runat="server" CssClass="settings-panel" Visible="false">
            <h2>Cài đặt khóa học</h2>
            <div class="settings-form-group">
                <label>Điểm qua mặc định (%)</label>
                <asp:TextBox ID="DefaultPassingScoreText" runat="server" CssClass="form-control" TextMode="Number" Value="60" />
            </div>
            <div class="settings-form-group">
                <label class="checkbox-label">
                    <asp:CheckBox ID="AllowExpiredViewCheck" runat="server" />
                    Cho phép xem nội dung sau khi hết hạn
                </label>
            </div>
            <div class="settings-form-group">
                <label class="checkbox-label">
                    <asp:CheckBox ID="AutoCompleteCheck" runat="server" />
                    Tự động hoàn thành khi hoàn thành tất cả bài học
                </label>
            </div>
            <div class="settings-form-group">
                <label class="checkbox-label">
                    <asp:CheckBox ID="AllowDownloadCheck" runat="server" />
                    Cho phép tải xuống tài liệu
                </label>
            </div>
            <div class="settings-action-bar">
                <asp:Button ID="SaveCourseButton" runat="server" CssClass="btn btn-primary" Text="Lưu cài đặt" OnClick="SaveCourseButton_Click" />
            </div>
        </asp:Panel>

        <asp:Panel ID="NotificationSettingsPanel" runat="server" CssClass="settings-panel" Visible="false">
            <h2>Cài đặt thông báo</h2>
            <div class="settings-form-group">
                <label class="checkbox-label">
                    <asp:CheckBox ID="EmailEnrollmentCheck" runat="server" />
                    Gửi email khi đăng ký khóa học mới
                </label>
            </div>
            <div class="settings-form-group">
                <label class="checkbox-label">
                    <asp:CheckBox ID="EmailCompletionCheck" runat="server" />
                    Gửi email khi hoàn thành khóa học
                </label>
            </div>
            <div class="settings-form-group">
                <label class="checkbox-label">
                    <asp:CheckBox ID="EmailReminderCheck" runat="server" />
                    Gửi email nhắc nhở trước khi hết hạn
                </label>
            </div>
            <div class="settings-form-group">
                <label>Số ngày nhắc nhở trước khi hết hạn</label>
                <asp:TextBox ID="ReminderDaysText" runat="server" CssClass="form-control" TextMode="Number" Value="7" />
            </div>
            <div class="settings-action-bar">
                <asp:Button ID="SaveNotificationButton" runat="server" CssClass="btn btn-primary" Text="Lưu cài đặt" OnClick="SaveNotificationButton_Click" />
            </div>
        </asp:Panel>

        <asp:Panel ID="StorageSettingsPanel" runat="server" CssClass="settings-panel" Visible="false">
            <h2>Cài đặt lưu trữ</h2>
            <div class="settings-form-group">
                <label>Kích thước file tối đa (MB)</label>
                <asp:TextBox ID="MaxFileSizeText" runat="server" CssClass="form-control" TextMode="Number" Value="100" />
            </div>
            <div class="settings-form-group">
                <label>Loại file cho phép tải lên</label>
                <asp:TextBox ID="AllowedExtensionsText" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
                <span class="help-text">Ngăn cách bằng dấu phẩy, ví dụ: .pdf,.doc,.docx,.jpg,.png,.mp4</span>
            </div>
            <div class="settings-form-group">
                <label>Thông báo sử dụng</label>
                <div class="storage-info">
                    <div class="storage-bar">
                        <div class="storage-used" id="StorageUsedBar" runat="server"></div>
                    </div>
                    <div class="storage-text">
                        <asp:Literal ID="StorageUsedText" runat="server" />
                    </div>
                </div>
            </div>
            <div class="settings-action-bar">
                <asp:Button ID="SaveStorageButton" runat="server" CssClass="btn btn-primary" Text="Lưu cài đặt" OnClick="SaveStorageButton_Click" />
            </div>
        </asp:Panel>
    </div>
</section>
