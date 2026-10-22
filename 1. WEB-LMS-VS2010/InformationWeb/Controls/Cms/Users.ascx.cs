using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using InformationWeb.LmsInfrastructure;
using LmsService;

namespace InformationWeb.Controls.Cms
{
    public partial class Users : CmsStoreControl
    {
        protected override ModuleService Service
        {
            get { return ServiceRegistry.Administration; }
        }
        protected override string Operation
        {
            get { return "UserList"; }
        }
        protected override string PageTitle
        {
            get { return "Quản lý người dùng"; }
        }
        protected override string PageDescription
        {
            get { return "Tạo tài khoản, gán vai trò và kiểm soát trạng thái truy cập."; }
        }

        protected override IDictionary<string, object> Parameters()
        {
            return Values(
                "Search",
                SearchText.Text.Trim(),
                "RoleCode",
                NullIfEmpty(RoleFilterList.SelectedValue),
                "Status",
                NullIfEmpty(StatusFilterList.SelectedValue),
                "Page",
                1,
                "PageSize",
                100
            );
        }

        protected override void AuthorizeCurrentUser()
        {
            base.AuthorizeCurrentUser();
            if (CurrentUser != null && !CurrentUser.IsAdmin)
                RedirectForbidden();
        }

        protected override void LoadData()
        {
            try
            {
                DataSet data = Service.GetDataSet(Operation, ConvertToParams(Parameters()));
                DataTable table = data != null && data.Tables.Count > 0 ? data.Tables[0] : null;
                int total = table == null ? 0 : table.Rows.Count;
                if (
                    data != null
                    && data.Tables.Count > 1
                    && data.Tables[1].Rows.Count > 0
                    && data.Tables[1].Columns.Contains("TotalItems")
                )
                    total = Convert.ToInt32(data.Tables[1].Rows[0]["TotalItems"]);
                UserTotalText.Text = total.ToString(CultureInfo.InvariantCulture);
                UserShownText.Text = Math.Min(
                        table == null ? 0 : table.Rows.Count,
                        DataGrid.PageSize
                    )
                    .ToString(CultureInfo.InvariantCulture);
                WebData.Bind(DataGrid, table, EmptyText, ErrorText);
            }
            catch (Exception ex)
            {
                WebLog.Error("Nạp danh sách người dùng thất bại.", ex);
                UserTotalText.Text = UserShownText.Text = "0";
                WebData.Bind(DataGrid, null, EmptyText, ErrorText);
            }
        }

        protected void CreateUserButton_Click(object sender, System.EventArgs e)
        {
            string username = NewUsernameText.Text.Trim(),
                fullName = NewFullNameText.Text.Trim(),
                email = NewEmailText.Text.Trim();
            long userId;
            long.TryParse(EditUserIdValue.Value, out userId);
            if (username.Length == 0 || fullName.Length == 0 || email.Length == 0)
            {
                UserModalOpenValue.Value = "1";
                ShowActionResult(
                    ActionMessageText,
                    "Vui lòng nhập tên đăng nhập, họ tên và email.",
                    false
                );
                return;
            }
            try
            {
                List<string> roles = new List<string>();
                foreach (ListItem item in UserRolesList.Items)
                    if (item.Selected)
                        roles.Add(item.Value);
                if (roles.Count == 0)
                    throw new System.ArgumentException("Người dùng phải có ít nhất một vai trò.");
                string rolesJson =
                    new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(roles);
                object passwordHash = null;
                if (userId <= 0 || !string.IsNullOrWhiteSpace(NewPasswordText.Text))
                    passwordHash = SystemAdministrationService.HashPassword(NewPasswordText.Text);
                IDictionary<string, object> values = Values(
                    "FullName",
                    fullName,
                    "Email",
                    email,
                    "StudentCode",
                    NullIfEmpty(StudentCodeText.Text),
                    "TeacherCode",
                    NullIfEmpty(TeacherCodeText.Text),
                    "AvatarUrl",
                    NullIfEmpty(AvatarUrlText.Text),
                    "Status",
                    UserStatusList.SelectedValue,
                    "RoleCodesJson",
                    rolesJson,
                    "ActorUserID",
                    CurrentUser.UserID
                );
                bool ok;
                if (userId > 0)
                {
                    values["UserID"] = userId;
                    values["PasswordHash"] = passwordHash;
                    ok = Service.ExecNonQuery("UserUpdate", ConvertToParams(values));
                }
                else
                {
                    values["Username"] = username;
                    values["PasswordHash"] = passwordHash;
                    DataTable created = Service.GetDataTable("UserCreate", ConvertToParams(values));
                    ok = created != null && created.Rows.Count > 0;
                }
                ShowActionResult(
                    ActionMessageText,
                    ok
                        ? (userId > 0 ? "Đã cập nhật người dùng." : "Đã tạo người dùng.")
                        : "Không thể lưu người dùng.",
                    ok
                );
                if (ok)
                {
                    ResetUserForm();
                    LoadData();
                }
            }
            catch (System.Exception ex)
            {
                UserModalOpenValue.Value = "1";
                ShowActionResult(ActionMessageText, ex.Message, false);
            }
        }

        protected void DataGrid_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            ScriptManager manager = ScriptManager.GetCurrent(Page);
            Control edit = e.Row.FindControl("EditUserButton");
            if (manager != null && edit != null)
                manager.RegisterAsyncPostBackControl(edit);
        }

        protected void DataGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            long userId;
            if (
                !long.TryParse(System.Convert.ToString(e.CommandArgument), out userId)
                || userId <= 0
            )
                return;
            try
            {
                if (e.CommandName == "EditUser")
                {
                    LoadUserForm(userId);
                    UserModalUpdatePanel.Update();
                }
                else if (e.CommandName == "SetActive" || e.CommandName == "SetLocked")
                {
                    string status = e.CommandName == "SetActive" ? "ACTIVE" : "LOCKED";
                    bool ok = Service.ExecNonQuery(
                        "UserStatus",
                        Values(
                            "UserID",
                            userId,
                            "Status",
                            status,
                            "ActorUserID",
                            CurrentUser.UserID
                        )
                    );
                    ShowActionResult(
                        ActionMessageText,
                        ok
                            ? (status == "ACTIVE" ? "Đã mở tài khoản." : "Đã khóa tài khoản.")
                            : "Không thể đổi trạng thái tài khoản.",
                        ok
                    );
                    if (ok)
                        LoadData();
                }
            }
            catch (System.Exception ex)
            {
                ShowActionResult(ActionMessageText, ex.Message, false);
                LoadData();
            }
        }

        protected void CancelUserButton_Click(object sender, System.EventArgs e)
        {
            ResetUserForm();
            LoadData();
        }

        private void LoadUserForm(long userId)
        {
            DataSet data = Service.GetDataSet("UserGet", ConvertToParams(Values("UserID", userId)));
            if (data == null || data.Tables.Count == 0 || data.Tables[0].Rows.Count == 0)
                throw new System.InvalidOperationException("Không tìm thấy người dùng.");
            DataRow row = data.Tables[0].Rows[0];
            EditUserIdValue.Value = userId.ToString();
            NewUsernameText.Text = WebData.Text(row, "Username");
            NewUsernameText.Enabled = false;
            NewPasswordText.Text = string.Empty;
            NewFullNameText.Text = WebData.Text(row, "FullName");
            NewEmailText.Text = WebData.Text(row, "Email");
            StudentCodeText.Text = WebData.Text(row, "StudentCode");
            TeacherCodeText.Text = WebData.Text(row, "TeacherCode");
            AvatarUrlText.Text = WebData.Text(row, "AvatarUrl");
            string status = WebData.Text(row, "Status");
            if (UserStatusList.Items.FindByValue(status) != null)
                UserStatusList.SelectedValue = status;
            foreach (ListItem item in UserRolesList.Items)
                item.Selected = false;
            if (data.Tables.Count > 1)
                foreach (DataRow role in data.Tables[1].Rows)
                {
                    ListItem item = UserRolesList.Items.FindByValue(WebData.Text(role, "Code"));
                    if (item != null)
                        item.Selected = true;
                }
            UserFormTitle.Text = "Cập nhật người dùng";
            CreateUserButton.Text = "Lưu người dùng";
            CancelUserButton.Visible = true;
            UserModalOpenValue.Value = "1";
            LoadData();
        }

        private void ResetUserForm()
        {
            EditUserIdValue.Value = string.Empty;
            NewUsernameText.Enabled = true;
            NewUsernameText.Text = string.Empty;
            NewPasswordText.Text = string.Empty;
            NewFullNameText.Text = string.Empty;
            NewEmailText.Text = string.Empty;
            StudentCodeText.Text = string.Empty;
            TeacherCodeText.Text = string.Empty;
            AvatarUrlText.Text = string.Empty;
            UserStatusList.SelectedValue = "ACTIVE";
            foreach (ListItem item in UserRolesList.Items)
                item.Selected = item.Value == "STUDENT";
            UserFormTitle.Text = "Thêm người dùng mới";
            CreateUserButton.Text = "Lưu người dùng";
            CancelUserButton.Visible = false;
            UserModalOpenValue.Value = "0";
        }

        protected string UserInitials(object value)
        {
            string[] parts = Convert
                .ToString(value)
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0)
                return "U";
            string initials =
                parts.Length == 1
                    ? parts[0].Substring(0, 1)
                    : parts[parts.Length - 2].Substring(0, 1)
                        + parts[parts.Length - 1].Substring(0, 1);
            return Server.HtmlEncode(initials.ToUpperInvariant());
        }

        protected string UserBusinessCode(object teacherCode, object studentCode)
        {
            string value = Convert.ToString(teacherCode);
            if (value.Length == 0)
                value = Convert.ToString(studentCode);
            return Server.HtmlEncode(value.Length == 0 ? "—" : value);
        }

        protected string UserStatusLabel(object value)
        {
            string status = Convert.ToString(value).ToUpperInvariant();
            if (status == "ACTIVE")
                return "Đang hoạt động";
            if (status == "INACTIVE")
                return "Ngừng hoạt động";
            if (status == "LOCKED")
                return "Đã khóa";
            return Server.HtmlEncode(status);
        }

        protected string UserStatusClass(object value)
        {
            string status = Convert.ToString(value).ToUpperInvariant();
            if (status == "ACTIVE")
                return "badge-soft-success";
            if (status == "LOCKED")
                return "badge-soft-danger";
            return "badge-soft-warning";
        }

        protected string UserLastLogin(object value)
        {
            if (value == null || value == DBNull.Value)
                return "Chưa đăng nhập";
            DateTime date;
            return DateTime.TryParse(
                Convert.ToString(value, CultureInfo.InvariantCulture),
                out date
            )
                ? date.ToString("dd/MM/yyyy HH:mm")
                : "Chưa đăng nhập";
        }

        private static object NullIfEmpty(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? (object)null : value.Trim();
        }

        private static object[] ConvertToParams(IDictionary<string, object> parameters)
        {
            List<object> list = new List<object>();
            foreach (var kvp in parameters)
            {
                list.Add("@" + kvp.Key);
                list.Add(kvp.Value ?? DBNull.Value);
            }
            return list.ToArray();
        }
    }
}
