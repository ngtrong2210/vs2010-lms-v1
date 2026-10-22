using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using InformationWeb.LmsInfrastructure;
using LmsService;

namespace InformationWeb.Controls.Cms
{
    public partial class Roles : CmsStoreControl
    {
        private long _selectedRoleId;
        protected override ModuleService Service
        {
            get { return ServiceRegistry.Administration; }
        }
        protected override string Operation
        {
            get { return "RoleList"; }
        }
        protected override string PageTitle
        {
            get { return "Vai trò và phân quyền"; }
        }
        protected override string PageDescription
        {
            get { return "Quản lý chính xác chức năng mà từng nhóm người dùng được phép sử dụng."; }
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
                DataTable roles = Service.GetDataTable(Operation, ConvertToParams(Parameters()));
                _selectedRoleId = SelectedRoleId(roles);
                DataRow selected = FindRole(roles, _selectedRoleId);
                if (selected != null)
                {
                    RoleIdText.Text = _selectedRoleId.ToString(CultureInfo.InvariantCulture);
                    string code = WebData.Text(selected, “Code”);
                    SelectedRoleCodeValue.Value = code;
                    SelectedRoleCodeText.Text = Server.HtmlEncode(code);
                    SelectedRoleNameText.Text = Server.HtmlEncode(WebData.Text(selected, “Name”));
                    SelectedRoleDescriptionText.Text =
                        code == “ADMIN”
                            ? “Quản trị viên luôn có toàn bộ quyền để tránh khóa hệ thống.”
                            : “Chọn các quyền cần cấp rồi nhấn “Lưu phân quyền”.”;
                    SavePermissionsButton.Enabled = code != “ADMIN”;
                }
                RoleCountText.Text = (roles == null ? 0 : roles.Rows.Count).ToString(
                    CultureInfo.InvariantCulture
                );
                RolesRepeater.DataSource = roles;
                RolesRepeater.DataBind();
                DataGrid.DataSource = roles;
                DataGrid.DataBind();
                EmptyText.Visible = roles == null || roles.Rows.Count == 0;
                ErrorText.Visible = false;
                if (_selectedRoleId > 0)
                    LoadRolePermissions(_selectedRoleId);
            }
            catch (Exception ex)
            {
                WebLog.Error("Nạp vai trò và phân quyền thất bại.", ex);
                ErrorText.Text = Server.HtmlEncode("Không thể nạp dữ liệu phân quyền.");
                ErrorText.Visible = true;
            }
        }

        protected void SavePermissionsButton_Click(object sender, System.EventArgs e)
        {
            long roleId;
            if (!long.TryParse(RoleIdText.Text, out roleId) || roleId <= 0)
            {
                ShowActionResult(ActionMessageText, "ID vai trò không hợp lệ.", false);
                return;
            }
            HashSet<string> unique = new HashSet<string>(System.StringComparer.OrdinalIgnoreCase);
            foreach (
                string item in PermissionCodesText.Text.Split(
                    new char[] { ',', ';', '\r', '\n' },
                    System.StringSplitOptions.RemoveEmptyEntries
                )
            )
            {
                string code = item.Trim();
                if (code.Length > 0)
                    unique.Add(code);
            }
            string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(
                new List<string>(unique)
            );
            bool ok = Service.ExecNonQuery(
                "RolePermissionsSave",
                Values(
                    "RoleID",
                    roleId,
                    "PermissionCodesJson",
                    json,
                    "ActorUserID",
                    CurrentUser.UserID
                )
            );
            ShowActionResult(
                ActionMessageText,
                ok ? "Đã lưu quyền cho vai trò." : "Không thể lưu phân quyền.",
                ok
            );
            if (ok)
                LoadData();
        }

        protected void RolesGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "SelectRole")
                return;
            long roleId;
            if (
                !long.TryParse(System.Convert.ToString(e.CommandArgument), out roleId)
                || roleId <= 0
            )
                return;
            try
            {
                LoadRolePermissions(roleId);
            }
            catch (System.Exception ex)
            {
                ShowActionResult(ActionMessageText, ex.Message, false);
            }
        }

        private void LoadRolePermissions(long roleId)
        {
            DataTable table = Service.GetDataTable("RolePermissions", ConvertToParams(Values("RoleID", roleId)));
            if (table == null)
                throw new System.InvalidOperationException("Không thể nạp danh sách quyền.");
            RoleIdText.Text = roleId.ToString();
            List<string> granted = new List<string>();
            foreach (DataRow row in table.Rows)
                if (
                    row["IsGranted"] != System.DBNull.Value
                    && System.Convert.ToBoolean(row["IsGranted"])
                )
                    granted.Add(WebData.Text(row, "Code"));
            PermissionCodesText.Text = string.Join(System.Environment.NewLine, granted.ToArray());
            PermissionsGrid.DataSource = table;
            PermissionsGrid.DataBind();
            PermissionEmptyText.Visible = table.Rows.Count == 0;
            List<Dictionary<string, object>> items = new List<Dictionary<string, object>>();
            foreach (DataRow row in table.Rows)
            {
                Dictionary<string, object> item = new Dictionary<string, object>();
                item["Code"] = WebData.Text(row, "Code");
                item["Name"] = WebData.Text(row, "Name");
                item["Module"] = WebData.Text(row, "Module");
                item["IsGranted"] =
                    row["IsGranted"] != DBNull.Value && Convert.ToBoolean(row["IsGranted"]);
                items.Add(item);
            }
            PermissionsJsonValue.Value = new JavaScriptSerializer().Serialize(items);
            GrantedPermissionCountText.Text = granted.Count.ToString(CultureInfo.InvariantCulture);
            PermissionCountText.Text = table.Rows.Count.ToString(CultureInfo.InvariantCulture);
        }

        protected string RoleUrl(object value)
        {
            return ResolveUrl("~/cms/roles?roleId=" + Server.UrlEncode(Convert.ToString(value)));
        }

        protected string RoleCardClass(object value)
        {
            return WebDataLong(value) == _selectedRoleId
                ? "role-card-button active"
                : "role-card-button";
        }

        protected string RoleIcon(object value)
        {
            string code = Convert.ToString(value).ToUpperInvariant();
            if (code == "ADMIN")
                return "bi-shield-lock";
            if (code == "TEACHER")
                return "bi-person-video3";
            if (code == "STUDENT")
                return "bi-mortarboard";
            return "bi-person-badge";
        }

        private long SelectedRoleId(DataTable roles)
        {
            long id;
            if (
                long.TryParse(Convert.ToString(Request.QueryString["roleId"]), out id)
                && FindRole(roles, id) != null
            )
                return id;
            if (long.TryParse(RoleIdText.Text, out id) && FindRole(roles, id) != null)
                return id;
            if (roles != null)
                foreach (DataRow row in roles.Rows)
                    if (WebData.Text(row, "Code") == "TEACHER")
                        return WebData.Long(row, "RoleID");
            return roles != null && roles.Rows.Count > 0
                ? WebData.Long(roles.Rows[0], "RoleID")
                : 0;
        }

        private static DataRow FindRole(DataTable roles, long id)
        {
            if (roles == null)
                return null;
            foreach (DataRow row in roles.Rows)
                if (WebData.Long(row, "RoleID") == id)
                    return row;
            return null;
        }

        private static long WebDataLong(object value)
        {
            long result;
            return long.TryParse(Convert.ToString(value), out result) ? result : 0;
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
