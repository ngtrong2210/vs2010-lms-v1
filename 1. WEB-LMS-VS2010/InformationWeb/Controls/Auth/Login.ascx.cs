using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InformationWeb.LmsInfrastructure;
using LmsObject;

namespace InformationWeb.Controls.Auth
{
    public partial class Login : UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.IsAuthenticated && UserSession.Current != null)
                RedirectByRole(UserSession.Current);
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;
            try
            {
                string message;
                SYS_Users user = Login(UsernameText.Text, PasswordText.Text, out message);
                if (user == null)
                {
                    ShowError(message);
                    return;
                }
                UserSession.SignIn(user, RememberCheck.Checked);
                string returnUrl = Request.QueryString["returnUrl"];
                if (IsReturnUrlAllowed(user, returnUrl))
                    Response.Redirect(returnUrl, false);
                else
                    RedirectByRole(user);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                WebLog.Error("Đăng nhập thất bại.", ex);
                ShowError(
                    ex is ArgumentException ? ex.Message : "Không thể đăng nhập. Vui lòng thử lại."
                );
            }
        }

        private SYS_Users Login(string username, string password, out string message)
        {
            message = string.Empty;
            username = ValidateRequiredText(username, 100, "tên đăng nhập");
            password = ValidateRequiredText(password, 200, "mật khẩu");

            SYS_Users data = new SYS_Users();
            DataTable table = data.GetDataTable("LMS_Auth_GetUserByUsername", "@Username", username);
            if (table == null || table.Rows.Count == 0)
            {
                message = "Tên đăng nhập hoặc mật khẩu không đúng.";
                return null;
            }

            DataRow row = table.Rows[0];
            string status = GetText(row, "Status");
            if (!string.Equals(status, "ACTIVE", StringComparison.OrdinalIgnoreCase))
            {
                message = "Tài khoản đang bị khóa hoặc ngừng hoạt động.";
                return null;
            }

            bool verified;
            try { verified = BCrypt.Net.BCrypt.Verify(password, GetText(row, "PasswordHash")); }
            catch { verified = false; }
            if (!verified)
            {
                message = "Tên đăng nhập hoặc mật khẩu không đúng.";
                return null;
            }

            SYS_Users user = MapUser(row);
            LoadPermissions(user);
            data.ExecNonQuery("LMS_Auth_UpdateLastLogin", "@UserId", user.UserID);
            return user;
        }

        private static void LoadPermissions(SYS_Users user)
        {
            DataTable permissions = user.GetDataTable("LMS_Auth_GetUserPermissions", "@UserId", user.UserID);
            if (permissions == null) return;
            foreach (DataRow permission in permissions.Rows)
            {
                string code = GetText(permission, "Code");
                if (code.Length > 0) user.Permissions.Add(code);
            }
        }

        private static SYS_Users MapUser(DataRow row)
        {
            SYS_Users user = new SYS_Users();
            user.Parse(row);
            user.UserID = GetNumber(row, "Id", GetNumber(row, "UserID", 0));
            user.Username = GetText(row, "Username");
            user.FullName = GetText(row, "FullName");
            user.Email = GetText(row, "Email");
            user.StudentCode = GetText(row, "StudentCode");
            user.TeacherCode = GetText(row, "TeacherCode");
            user.Role = GetText(row, "Role");
            return user;
        }

        private static string GetText(DataRow row, string column)
        {
            return row.Table.Columns.Contains(column) && row[column] != DBNull.Value ? Convert.ToString(row[column]) : string.Empty;
        }

        private static long GetNumber(DataRow row, string column, long fallback)
        {
            return row.Table.Columns.Contains(column) && row[column] != DBNull.Value ? Convert.ToInt64(row[column]) : fallback;
        }

        private static string ValidateRequiredText(string value, int maxLength, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException(string.Format("{0} không được để trống.", fieldName));
            if (value.Length > maxLength)
                throw new ArgumentException(string.Format("{0} không được vượt quá {1} ký tự.", fieldName, maxLength));
            return value.Trim();
        }

        private void RedirectByRole(SYS_Users user)
        {
            Response.Redirect(
                ResolveUrl(user.IsStudent ? "~/lms/dashboard" : "~/cms/dashboard"),
                false
            );
            Context.ApplicationInstance.CompleteRequest();
        }

        private bool IsLocalUrl(string url)
        {
            return !string.IsNullOrWhiteSpace(url)
                && url[0] == '/'
                && (url.Length == 1 || (url[1] != '/' && url[1] != '\\'))
                && !url.Contains("://");
        }

        private bool IsReturnUrlAllowed(SYS_Users user, string url)
        {
            if (user == null || !IsLocalUrl(url))
                return false;

            string path = url;
            int queryIndex = path.IndexOf('?');
            if (queryIndex >= 0)
                path = path.Substring(0, queryIndex);
            int fragmentIndex = path.IndexOf('#');
            if (fragmentIndex >= 0)
                path = path.Substring(0, fragmentIndex);

            // Không điều hướng lại các đường dẫn vật lý và không đưa người dùng
            // sang khu vực của vai trò khác sau khi đăng nhập.
            if (path.StartsWith("/Pages/", StringComparison.OrdinalIgnoreCase))
                return false;
            if (
                path.Equals("/cms", StringComparison.OrdinalIgnoreCase)
                || path.StartsWith("/cms/", StringComparison.OrdinalIgnoreCase)
            )
                return !user.IsStudent;
            if (
                path.Equals("/lms", StringComparison.OrdinalIgnoreCase)
                || path.StartsWith("/lms/", StringComparison.OrdinalIgnoreCase)
            )
                return user.IsStudent;
            return true;
        }

        private void ShowError(string message)
        {
            MessageText.Text = Server.HtmlEncode(message);
            MessageText.Visible = true;
        }
    }
}
