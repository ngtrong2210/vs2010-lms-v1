using System;
using System.Data;
using LmsObject;
using LmsService.Core;

namespace LmsService
{
    public sealed class AuthService
    {
        public SYS_Users Login(string username, string password, out string message)
        {
            message = string.Empty;
            username = Core.InputGuard.RequiredText(username, 100, "tên đăng nhập");
            password = Core.InputGuard.RequiredText(password, 200, "mật khẩu");

            SYS_Users data = new SYS_Users();
            DataTable table = data.GetDataTable("LMS_Auth_GetUserByUsername", "@Username", username);
            if (table == null || table.Rows.Count == 0)
            {
                message = "Tên đăng nhập hoặc mật khẩu không đúng.";
                return null;
            }

            DataRow row = table.Rows[0];
            if (!string.Equals(Text(row, "Status"), "ACTIVE", StringComparison.OrdinalIgnoreCase))
            {
                message = "Tài khoản đang bị khóa hoặc ngừng hoạt động.";
                return null;
            }

            bool verified;
            try { verified = BCrypt.Net.BCrypt.Verify(password, Text(row, "PasswordHash")); }
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

        public SYS_Users GetById(long userId)
        {
            Core.InputGuard.PositiveId(userId, "người dùng");
            SYS_Users data = new SYS_Users();
            DataTable table = data.GetDataTable("LMS_Auth_GetUserById", "@UserId", userId);
            if (table == null || table.Rows.Count == 0) return null;
            SYS_Users user = MapUser(table.Rows[0]);
            LoadPermissions(user);
            return user;
        }

        private static void LoadPermissions(SYS_Users user)
        {
            DataTable permissions = user.GetDataTable("LMS_Auth_GetUserPermissions", "@UserId", user.UserID);
            if (permissions == null) return;
            foreach (DataRow permission in permissions.Rows)
            {
                string code = Text(permission, "Code");
                if (code.Length > 0) user.Permissions.Add(code);
            }
        }

        private static SYS_Users MapUser(DataRow row)
        {
            SYS_Users user = new SYS_Users();
            user.Parse(row);
            user.UserID = Number(row, "Id", Number(row, "UserID", 0));
            user.Username = Text(row, "Username");
            user.FullName = Text(row, "FullName");
            user.Email = Text(row, "Email");
            user.StudentCode = Text(row, "StudentCode");
            user.TeacherCode = Text(row, "TeacherCode");
            user.Role = Text(row, "Role");
            return user;
        }

        private static string Text(DataRow row, string column)
        {
            return row.Table.Columns.Contains(column) && row[column] != DBNull.Value ? Convert.ToString(row[column]) : string.Empty;
        }

        private static long Number(DataRow row, string column, long fallback)
        {
            return row.Table.Columns.Contains(column) && row[column] != DBNull.Value ? Convert.ToInt64(row[column]) : fallback;
        }
    }
}
