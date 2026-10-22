using System;
using System.Collections.Generic;
using System.Data;
using DCore;

namespace LmsObject
{
    /// <summary>
    /// Phần mở rộng nghiệp vụ của SYS_Users. Generator không ghi đè file này.
    /// </summary>
    public partial class SYS_Users
    {
        private readonly HashSet<string> _permissions = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        public string Role { get; set; }
        public ICollection<string> Permissions { get { return _permissions; } }
        public bool IsAdmin { get { return string.Equals(Role, "ADMIN", StringComparison.OrdinalIgnoreCase); } }
        public bool IsTeacher { get { return string.Equals(Role, "TEACHER", StringComparison.OrdinalIgnoreCase); } }
        public bool IsStudent { get { return string.Equals(Role, "STUDENT", StringComparison.OrdinalIgnoreCase); } }

        public bool HasPermission(string code)
        {
            return IsAdmin || (!string.IsNullOrWhiteSpace(code) && _permissions.Contains(code));
        }

        /// <summary>
        /// Gọi stored procedure trả nhiều result set bằng chính IData/DCore của source cũ.
        /// </summary>
        public DataSet GetDataSet(string storeName, params object[] pars)
        {
            IData data = DCore.Data.CreateData();
            try
            {
                data.CreateNewStoredProcedure(storeName);
                data.AddParameter(pars);
                return data.ExecStoreToDataSet();
            }
            finally
            {
                data.Disconnect();
            }
        }

        #region Enhanced Load Methods

        /// <summary>
        /// Load dữ liệu từ IDataReader vào object hiện tại.
        /// Method này sử dụng logic Parse đã có trong Base class.
        /// </summary>
        public bool LoadFromDataReader(IDataReader reader)
        {
            try
            {
                return Parse(reader);
            }
            catch (Exception ex)
            {
                objErrorException = ex;
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataReader trong SYS_Users", ex);
                return false;
            }
        }

        /// <summary>
        /// Load dữ liệu từ DataRow vào object hiện tại.
        /// </summary>
        public bool LoadFromDataRow(DataRow row)
        {
            try
            {
                if (row == null) return false;

                if (row.Table.Columns.Contains(C_UserID) && !Convert.IsDBNull(row[C_UserID])) this.lngUserID = Convert.ToInt64(row[C_UserID]);
                if (row.Table.Columns.Contains(C_Username) && !Convert.IsDBNull(row[C_Username])) this.strUsername = Convert.ToString(row[C_Username]);
                if (row.Table.Columns.Contains(C_PasswordHash) && !Convert.IsDBNull(row[C_PasswordHash])) this.strPasswordHash = Convert.ToString(row[C_PasswordHash]);
                if (row.Table.Columns.Contains(C_FullName) && !Convert.IsDBNull(row[C_FullName])) this.strFullName = Convert.ToString(row[C_FullName]);
                if (row.Table.Columns.Contains(C_Email) && !Convert.IsDBNull(row[C_Email])) this.strEmail = Convert.ToString(row[C_Email]);
                if (row.Table.Columns.Contains(C_StudentCode) && !Convert.IsDBNull(row[C_StudentCode])) this.strStudentCode = Convert.ToString(row[C_StudentCode]);
                if (row.Table.Columns.Contains(C_TeacherCode) && !Convert.IsDBNull(row[C_TeacherCode])) this.strTeacherCode = Convert.ToString(row[C_TeacherCode]);
                if (row.Table.Columns.Contains(C_AvatarUrl) && !Convert.IsDBNull(row[C_AvatarUrl])) this.strAvatarUrl = Convert.ToString(row[C_AvatarUrl]);
                if (row.Table.Columns.Contains(C_Status) && !Convert.IsDBNull(row[C_Status])) this.strStatus = Convert.ToString(row[C_Status]);
                if (row.Table.Columns.Contains(C_LastLoginAt) && !Convert.IsDBNull(row[C_LastLoginAt])) this.dtmLastLoginAt = Convert.ToDateTime(row[C_LastLoginAt]);
                if (row.Table.Columns.Contains(C_CreatedAt) && !Convert.IsDBNull(row[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(row[C_CreatedAt]);
                if (row.Table.Columns.Contains(C_UpdatedAt) && !Convert.IsDBNull(row[C_UpdatedAt])) this.dtmUpdatedAt = Convert.ToDateTime(row[C_UpdatedAt]);
                if (row.Table.Columns.Contains(C_CreatedByUserID) && !Convert.IsDBNull(row[C_CreatedByUserID])) this.lngCreatedByUserID = Convert.ToInt64(row[C_CreatedByUserID]);
                if (row.Table.Columns.Contains(C_UpdatedByUserID) && !Convert.IsDBNull(row[C_UpdatedByUserID])) this.lngUpdatedByUserID = Convert.ToInt64(row[C_UpdatedByUserID]);
                if (row.Table.Columns.Contains(C_IsDeleted) && !Convert.IsDBNull(row[C_IsDeleted])) this.bolIsDeleted = Convert.ToBoolean(row[C_IsDeleted]);
                if (row.Table.Columns.Contains(C_DataGroupID) && !Convert.IsDBNull(row[C_DataGroupID])) this.intDataGroupID = Convert.ToInt32(row[C_DataGroupID]);
                if (row.Table.Columns.Contains(C_StudentID) && !Convert.IsDBNull(row[C_StudentID])) this.strStudentID = Convert.ToString(row[C_StudentID]);
                if (row.Table.Columns.Contains(C_TeacherID) && !Convert.IsDBNull(row[C_TeacherID])) this.strTeacherID = Convert.ToString(row[C_TeacherID]);

                return true;
            }
            catch (Exception ex)
            {
                objErrorException = ex;
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataRow trong SYS_Users", ex);
                return false;
            }
        }

        /// <summary>
        /// Load user theo ID và trả về object mới.
        /// </summary>
        public static SYS_Users LoadById(long userId)
        {
            SYS_Users user = new SYS_Users();
            user.UserID = userId;
            if (user.Get())
            {
                return user;
            }
            return null;
        }

        /// <summary>
        /// Load user theo Username và trả về object mới.
        /// </summary>
        public static SYS_Users LoadByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) return null;

            SYS_Users user = new SYS_Users();
            DataTable dt = user.GetDataTable(StoreSearch, "@Username", username);
            if (dt != null && dt.Rows.Count > 0)
            {
                user.LoadFromDataRow(dt.Rows[0]);
                return user;
            }
            return null;
        }

        /// <summary>
        /// Load user theo Email và trả về object mới.
        /// </summary>
        public static SYS_Users LoadByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return null;

            SYS_Users user = new SYS_Users();
            DataTable dt = user.GetDataTable(StoreSearch, "@Email", email);
            if (dt != null && dt.Rows.Count > 0)
            {
                user.LoadFromDataRow(dt.Rows[0]);
                return user;
            }
            return null;
        }

        /// <summary>
        /// Load tất cả users từ database.
        /// </summary>
        public static List<SYS_Users> LoadAll()
        {
            List<SYS_Users> users = new List<SYS_Users>();
            SYS_Users temp = new SYS_Users();
            DataTable dt = temp.GetDataTable(StoreGetAll);

            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    SYS_Users user = new SYS_Users();
                    if (user.LoadFromDataRow(row))
                    {
                        users.Add(user);
                    }
                }
            }
            return users;
        }

        /// <summary>
        /// Search users với điều kiện tùy chỉnh.
        /// </summary>
        public static List<SYS_Users> Search(string condition = "")
        {
            List<SYS_Users> users = new List<SYS_Users>();
            SYS_Users temp = new SYS_Users();
            DataTable dt;

            if (string.IsNullOrEmpty(condition))
            {
                dt = temp.GetDataTable(StoreGetAll);
            }
            else
            {
                dt = temp.Search(condition);
            }

            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    SYS_Users user = new SYS_Users();
                    if (user.LoadFromDataRow(row))
                    {
                        users.Add(user);
                    }
                }
            }
            return users;
        }

        /// <summary>
        /// Load user kèm permissions từ database.
        /// </summary>
        public static SYS_Users LoadWithPermissions(long userId)
        {
            SYS_Users user = LoadById(userId);
            if (user != null)
            {
                user.LoadPermissions();
            }
            return user;
        }

        /// <summary>
        /// Load permissions cho user hiện tại từ database.
        /// </summary>
        public void LoadPermissions()
        {
            _permissions.Clear();

            try
            {
                // Load role từ SYS_PermissionGroup
                DataTable dtRole = GetDataTable("SYS_PermissionGroup_GET_BY_USERID", "@UserID", this.lngUserID);
                if (dtRole != null && dtRole.Rows.Count > 0)
                {
                    Role = Convert.ToString(dtRole.Rows[0]["RoleCode"] ?? "");
                }

                // Load permissions từ SYS_PermissionCategory
                DataTable dtPerms = GetDataTable("SYS_PermissionCategory_GET_BY_USERID", "@UserID", this.lngUserID);
                if (dtPerms != null)
                {
                    foreach (DataRow row in dtPerms.Rows)
                    {
                        string permCode = Convert.ToString(row["PermissionCode"] ?? "");
                        if (!string.IsNullOrWhiteSpace(permCode))
                        {
                            _permissions.Add(permCode);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objErrorException = ex;
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadPermissions trong SYS_Users", ex);
            }
        }

        /// <summary>
        /// Load data vào object hiện tại (alias cho Get() method).
        /// </summary>
        public bool Load()
        {
            return Get();
        }

        /// <summary>
        /// Tạo một instance mới và load dữ liệu từ IDataReader.
        /// </summary>
        public static SYS_Users CreateFromDataReader(IDataReader reader)
        {
            SYS_Users user = new SYS_Users();
            user.LoadFromDataReader(reader);
            return user;
        }

        /// <summary>
        /// Tạo một instance mới và load dữ liệu từ DataRow.
        /// </summary>
        public static SYS_Users CreateFromDataRow(DataRow row)
        {
            SYS_Users user = new SYS_Users();
            user.LoadFromDataRow(row);
            return user;
        }

        /// <summary>
        /// Convert DataTable sang List<SYS_Users>.
        /// </summary>
        public static List<SYS_Users> FromDataTable(DataTable dt)
        {
            List<SYS_Users> users = new List<SYS_Users>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    SYS_Users user = CreateFromDataRow(row);
                    users.Add(user);
                }
            }
            return users;
        }

        #endregion
    }
}
