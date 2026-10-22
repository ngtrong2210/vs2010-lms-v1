using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using InformationWeb.LmsInfrastructure;
using System.Web.UI;

namespace InformationWeb.Controls.Cms
{
    public partial class Settings : LmsControl
    {
        private class SettingsTab
        {
            public string TabName { get; set; }
            public string Title { get; set; }
            public string Icon { get; set; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        public void LoadData()
        {
            BindSettingsNav();
            LoadGeneralSettings();
            LoadSecuritySettings();
            LoadCourseSettings();
            LoadNotificationSettings();
            LoadStorageSettings();
        }

        private void BindSettingsNav()
        {
            List<SettingsTab> tabs = new List<SettingsTab>
            {
                new SettingsTab { TabName = "General", Title = "Cài đặt chung", Icon = "⚙️" },
                new SettingsTab { TabName = "Security", Title = "Bảo mật", Icon = "🔒" },
                new SettingsTab { TabName = "Course", Title = "Khóa học", Icon = "📚" },
                new SettingsTab { TabName = "Notification", Title = "Thông báo", Icon = "🔔" },
                new SettingsTab { TabName = "Storage", Title = "Lưu trữ", Icon = "💾" }
            };

            Repeater navRepeater = (Repeater)FindControl("SettingsNavRepeater");
            if (navRepeater != null)
            {
                navRepeater.DataSource = tabs;
                navRepeater.DataBind();
            }
        }

        private void LoadGeneralSettings()
        {
            TextBox systemName = (TextBox)FindControl("SystemNameText");
            TextBox logoUrl = (TextBox)FindControl("LogoUrlText");
            TextBox supportEmail = (TextBox)FindControl("SupportEmailText");
            TextBox supportPhone = (TextBox)FindControl("SupportPhoneText");
            DropDownList timeZone = (DropDownList)FindControl("TimeZoneList");
            DropDownList language = (DropDownList)FindControl("LanguageList");

            if (systemName != null) systemName.Text = GetSetting("SystemName", "Hệ thống LMS");
            if (logoUrl != null) logoUrl.Text = GetSetting("LogoUrl", "");
            if (supportEmail != null) supportEmail.Text = GetSetting("SupportEmail", "support@lms.com");
            if (supportPhone != null) supportPhone.Text = GetSetting("SupportPhone", "");
            if (timeZone != null) timeZone.SelectedValue = GetSetting("TimeZone", "Asia/Ho_Chi_Minh");
            if (language != null) language.SelectedValue = GetSetting("DefaultLanguage", "vi-VN");
        }

        private void LoadSecuritySettings()
        {
            CheckBox strongPassword = (CheckBox)FindControl("StrongPasswordCheck");
            TextBox sessionTimeout = (TextBox)FindControl("SessionTimeoutText");
            TextBox maxLoginAttempts = (TextBox)FindControl("MaxLoginAttemptsText");
            TextBox lockoutDuration = (TextBox)FindControl("LockoutDurationText");
            CheckBox enable2FA = (CheckBox)FindControl("Enable2FACheck");

            if (strongPassword != null) strongPassword.Checked = GetSettingBool("StrongPassword", true);
            if (sessionTimeout != null) sessionTimeout.Text = GetSetting("SessionTimeout", "60");
            if (maxLoginAttempts != null) maxLoginAttempts.Text = GetSetting("MaxLoginAttempts", "5");
            if (lockoutDuration != null) lockoutDuration.Text = GetSetting("LockoutDuration", "30");
            if (enable2FA != null) enable2FA.Checked = GetSettingBool("Enable2FA", false);
        }

        private void LoadCourseSettings()
        {
            TextBox defaultPassingScore = (TextBox)FindControl("DefaultPassingScoreText");
            CheckBox allowExpiredView = (CheckBox)FindControl("AllowExpiredViewCheck");
            CheckBox autoComplete = (CheckBox)FindControl("AutoCompleteCheck");
            CheckBox allowDownload = (CheckBox)FindControl("AllowDownloadCheck");

            if (defaultPassingScore != null) defaultPassingScore.Text = GetSetting("DefaultPassingScore", "60");
            if (allowExpiredView != null) allowExpiredView.Checked = GetSettingBool("AllowExpiredView", false);
            if (autoComplete != null) autoComplete.Checked = GetSettingBool("AutoComplete", true);
            if (allowDownload != null) allowDownload.Checked = GetSettingBool("AllowDownload", true);
        }

        private void LoadNotificationSettings()
        {
            CheckBox emailEnrollment = (CheckBox)FindControl("EmailEnrollmentCheck");
            CheckBox emailCompletion = (CheckBox)FindControl("EmailCompletionCheck");
            CheckBox emailReminder = (CheckBox)FindControl("EmailReminderCheck");
            TextBox reminderDays = (TextBox)FindControl("ReminderDaysText");

            if (emailEnrollment != null) emailEnrollment.Checked = GetSettingBool("EmailEnrollment", true);
            if (emailCompletion != null) emailCompletion.Checked = GetSettingBool("EmailCompletion", true);
            if (emailReminder != null) emailReminder.Checked = GetSettingBool("EmailReminder", true);
            if (reminderDays != null) reminderDays.Text = GetSetting("ReminderDays", "7");
        }

        private void LoadStorageSettings()
        {
            TextBox maxFileSize = (TextBox)FindControl("MaxFileSizeText");
            TextBox allowedExtensions = (TextBox)FindControl("AllowedExtensionsText");
            HtmlGenericControl storageUsedBar = (HtmlGenericControl)FindControl("StorageUsedBar");
            Literal storageUsedText = (Literal)FindControl("StorageUsedText");

            if (maxFileSize != null) maxFileSize.Text = GetSetting("MaxFileSize", "100");
            if (allowedExtensions != null) allowedExtensions.Text = GetSetting("AllowedExtensions", ".pdf,.doc,.docx,.ppt,.pptx,.jpg,.jpeg,.png,.gif,.mp4,.mp3");

            long usedSpace = GetUsedSpace();
            long totalSpace = GetTotalSpace();
            decimal percent = totalSpace > 0 ? (decimal)usedSpace / totalSpace * 100 : 0;

            if (storageUsedBar != null) storageUsedBar.Style.Add("width", percent.ToString("0") + "%");
            if (storageUsedText != null) storageUsedText.Text = FormatBytes(usedSpace) + " / " + FormatBytes(totalSpace) + " (" + percent.ToString("0") + "%)";
        }

        protected void SettingsNavRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "SwitchTab")
            {
                string tabName = e.CommandArgument.ToString();
                SwitchTab(tabName);
            }
        }

        private void SwitchTab(string tabName)
        {
            Panel generalPanel = (Panel)FindControl("GeneralSettingsPanel");
            Panel securityPanel = (Panel)FindControl("SecuritySettingsPanel");
            Panel coursePanel = (Panel)FindControl("CourseSettingsPanel");
            Panel notificationPanel = (Panel)FindControl("NotificationSettingsPanel");
            Panel storagePanel = (Panel)FindControl("StorageSettingsPanel");

            if (generalPanel != null) generalPanel.CssClass = "settings-panel";
            if (securityPanel != null) securityPanel.CssClass = "settings-panel";
            if (coursePanel != null) coursePanel.CssClass = "settings-panel";
            if (notificationPanel != null) notificationPanel.CssClass = "settings-panel";
            if (storagePanel != null) storagePanel.CssClass = "settings-panel";

            Repeater navRepeater = (Repeater)FindControl("SettingsNavRepeater");
            if (navRepeater != null)
            {
                foreach (RepeaterItem item in navRepeater.Items)
                {
                    LinkButton navButton = (LinkButton)item.FindControl("NavButton");
                    if (navButton != null)
                    {
                        navButton.CssClass = "settings-nav-item";
                    }
                }

                foreach (RepeaterItem item in navRepeater.Items)
                {
                    LinkButton navButton = (LinkButton)item.FindControl("NavButton");
                    if (navButton != null && navButton.CommandArgument.ToString() == tabName)
                    {
                        navButton.CssClass = "settings-nav-item active";
                    }
                }
            }

            switch (tabName)
            {
                case "General":
                    if (generalPanel != null) generalPanel.CssClass = "settings-panel active";
                    break;
                case "Security":
                    if (securityPanel != null) securityPanel.CssClass = "settings-panel active";
                    break;
                case "Course":
                    if (coursePanel != null) coursePanel.CssClass = "settings-panel active";
                    break;
                case "Notification":
                    if (notificationPanel != null) notificationPanel.CssClass = "settings-panel active";
                    break;
                case "Storage":
                    if (storagePanel != null) storagePanel.CssClass = "settings-panel active";
                    break;
            }
        }

        protected void SaveGeneralButton_Click(object sender, EventArgs e)
        {
            TextBox systemName = (TextBox)FindControl("SystemNameText");
            TextBox logoUrl = (TextBox)FindControl("LogoUrlText");
            TextBox supportEmail = (TextBox)FindControl("SupportEmailText");
            TextBox supportPhone = (TextBox)FindControl("SupportPhoneText");
            DropDownList timeZone = (DropDownList)FindControl("TimeZoneList");
            DropDownList language = (DropDownList)FindControl("LanguageList");

            if (systemName != null) SaveSetting("SystemName", systemName.Text);
            if (logoUrl != null) SaveSetting("LogoUrl", logoUrl.Text);
            if (supportEmail != null) SaveSetting("SupportEmail", supportEmail.Text);
            if (supportPhone != null) SaveSetting("SupportPhone", supportPhone.Text);
            if (timeZone != null) SaveSetting("TimeZone", timeZone.SelectedValue);
            if (language != null) SaveSetting("DefaultLanguage", language.SelectedValue);

            ShowMessage("Lưu cài đặt chung thành công", false);
        }

        protected void SaveSecurityButton_Click(object sender, EventArgs e)
        {
            CheckBox strongPassword = (CheckBox)FindControl("StrongPasswordCheck");
            TextBox sessionTimeout = (TextBox)FindControl("SessionTimeoutText");
            TextBox maxLoginAttempts = (TextBox)FindControl("MaxLoginAttemptsText");
            TextBox lockoutDuration = (TextBox)FindControl("LockoutDurationText");
            CheckBox enable2FA = (CheckBox)FindControl("Enable2FACheck");

            if (strongPassword != null) SaveSetting("StrongPassword", strongPassword.Checked.ToString());
            if (sessionTimeout != null) SaveSetting("SessionTimeout", sessionTimeout.Text);
            if (maxLoginAttempts != null) SaveSetting("MaxLoginAttempts", maxLoginAttempts.Text);
            if (lockoutDuration != null) SaveSetting("LockoutDuration", lockoutDuration.Text);
            if (enable2FA != null) SaveSetting("Enable2FA", enable2FA.Checked.ToString());

            ShowMessage("Lưu cài đặt bảo mật thành công", false);
        }

        protected void SaveCourseButton_Click(object sender, EventArgs e)
        {
            TextBox defaultPassingScore = (TextBox)FindControl("DefaultPassingScoreText");
            CheckBox allowExpiredView = (CheckBox)FindControl("AllowExpiredViewCheck");
            CheckBox autoComplete = (CheckBox)FindControl("AutoCompleteCheck");
            CheckBox allowDownload = (CheckBox)FindControl("AllowDownloadCheck");

            if (defaultPassingScore != null) SaveSetting("DefaultPassingScore", defaultPassingScore.Text);
            if (allowExpiredView != null) SaveSetting("AllowExpiredView", allowExpiredView.Checked.ToString());
            if (autoComplete != null) SaveSetting("AutoComplete", autoComplete.Checked.ToString());
            if (allowDownload != null) SaveSetting("AllowDownload", allowDownload.Checked.ToString());

            ShowMessage("Lưu cài đặt khóa học thành công", false);
        }

        protected void SaveNotificationButton_Click(object sender, EventArgs e)
        {
            CheckBox emailEnrollment = (CheckBox)FindControl("EmailEnrollmentCheck");
            CheckBox emailCompletion = (CheckBox)FindControl("EmailCompletionCheck");
            CheckBox emailReminder = (CheckBox)FindControl("EmailReminderCheck");
            TextBox reminderDays = (TextBox)FindControl("ReminderDaysText");

            if (emailEnrollment != null) SaveSetting("EmailEnrollment", emailEnrollment.Checked.ToString());
            if (emailCompletion != null) SaveSetting("EmailCompletion", emailCompletion.Checked.ToString());
            if (emailReminder != null) SaveSetting("EmailReminder", emailReminder.Checked.ToString());
            if (reminderDays != null) SaveSetting("ReminderDays", reminderDays.Text);

            ShowMessage("Lưu cài đặt thông báo thành công", false);
        }

        protected void SaveStorageButton_Click(object sender, EventArgs e)
        {
            TextBox maxFileSize = (TextBox)FindControl("MaxFileSizeText");
            TextBox allowedExtensions = (TextBox)FindControl("AllowedExtensionsText");

            if (maxFileSize != null) SaveSetting("MaxFileSize", maxFileSize.Text);
            if (allowedExtensions != null) SaveSetting("AllowedExtensions", allowedExtensions.Text);

            ShowMessage("Lưu cài đặt lưu trữ thành công", false);
            LoadStorageSettings();
        }

        private string GetSetting(string key, string defaultValue)
        {
            try
            {
                object value = ServiceRegistry.System.GetSetting(key);
                return value != null ? value.ToString() : defaultValue;
            }
            catch
            {
                return defaultValue;
            }
        }

        private bool GetSettingBool(string key, bool defaultValue)
        {
            string value = GetSetting(key, defaultValue.ToString());
            bool result;
            return bool.TryParse(value, out result) ? result : defaultValue;
        }

        private void SaveSetting(string key, string value)
        {
            try
            {
                ServiceRegistry.System.SaveSetting(key, value);
            }
            catch { }
        }

        private long GetUsedSpace()
        {
            try
            {
                object value = ServiceRegistry.System.GetSetting("UsedSpace");
                return value != null ? Convert.ToInt64(value) : 0;
            }
            catch
            {
                return 0;
            }
        }

        private long GetTotalSpace()
        {
            try
            {
                object value = ServiceRegistry.System.GetSetting("TotalSpace");
                return value != null ? Convert.ToInt64(value) : 10737418240; // 10GB default
            }
            catch
            {
                return 10737418240;
            }
        }

        private string FormatBytes(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            int order = 0;
            double size = bytes;

            while (size >= 1024 && order < sizes.Length - 1)
            {
                order++;
                size /= 1024;
            }

            return size.ToString("0.##") + " " + sizes[order];
        }

        private void ShowMessage(string message, bool isError)
        {
            Label msgLabel = (Label)FindControl("ActionMessageText");
            if (msgLabel != null)
            {
                msgLabel.Visible = true;
                msgLabel.Text = message;
                msgLabel.CssClass = isError ? "settings-alert error" : "settings-alert success";
            }
        }
    }
}
