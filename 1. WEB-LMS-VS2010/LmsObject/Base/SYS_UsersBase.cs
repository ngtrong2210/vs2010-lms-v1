#region Using

using System;
using System.Data;
using System.Collections;
using DCore;

#endregion

namespace LmsObject
{
    /// <summary>
    /// Created by 		: Generator
    /// Created date 	: 2025
    /// [SYS] Tài khoản quản trị viên, giảng viên và học viên.
    /// </summary>
    public partial class SYS_Users
{
    /// <summary>
    /// [SYS] Tài khoản quản trị viên, giảng viên và học viên.
    /// </summary>
    public partial class SYS_Users
    {
        #region Member Variables

        private long lngUserID = 0;//Khóa chính tự tăng của người dùng.
        private string strUsername = null;//Tên đăng nhập duy nhất của người dùng.
        private string strPasswordHash = null;//Chuỗi mật khẩu đã băm; không lưu mật khẩu dạng rõ.
        private string strFullName = null;//Họ và tên đầy đủ của người dùng.
        private string strEmail = null;//Địa chỉ email duy nhất của người dùng.
        private string strStudentCode = null;//Mã học viên; chỉ có giá trị với tài khoản học viên.
        private string strTeacherCode = null;//Mã giảng viên; chỉ có giá trị với tài khoản giảng viên.
        private string strAvatarUrl = null;//Đường dẫn ảnh đại diện của người dùng.
        private string strStatus = null;//Trạng thái tài khoản: ACTIVE, INACTIVE hoặc LOCKED.
        private DateTime? dtmLastLoginAt = null;//Thời điểm đăng nhập thành công gần nhất theo UTC.
        private DateTime dtmCreatedAt = DateTime.MinValue;//Thời điểm tạo tài khoản theo UTC.
        private DateTime? dtmUpdatedAt = null;//Thời điểm cập nhật tài khoản gần nhất theo UTC.
        private long? lngCreatedByUserID = null;//ID người dùng đã tạo tài khoản này.
        private long? lngUpdatedByUserID = null;//ID người dùng cập nhật tài khoản gần nhất.
        private bool bolIsDeleted = false;//Cờ xóa mềm: 1 là đã xóa, 0 là đang sử dụng.
        private int intDataGroupID = 0;//Mã đơn vị hoặc nhóm dữ liệu sở hữu tài khoản.
        private string strStudentID = null;//Mã hồ sơ học viên liên kết với tài khoản, nếu người dùng là học viên.
        private string strTeacherID = null;//Mã hồ sơ giảng viên liên kết với tài khoản, nếu người dùng là giảng viên.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// Khóa chính tự tăng của người dùng.
        /// </summary>
        public long UserID
        {
            get { return lngUserID; }
            set { lngUserID = value; }
        }

        /// <summary>
        /// Tên đăng nhập duy nhất của người dùng.
        /// </summary>
        public string Username
        {
            get { return strUsername; }
            set { strUsername = value; }
        }

        /// <summary>
        /// Chuỗi mật khẩu đã băm; không lưu mật khẩu dạng rõ.
        /// </summary>
        public string PasswordHash
        {
            get { return strPasswordHash; }
            set { strPasswordHash = value; }
        }

        /// <summary>
        /// Họ và tên đầy đủ của người dùng.
        /// </summary>
        public string FullName
        {
            get { return strFullName; }
            set { strFullName = value; }
        }

        /// <summary>
        /// Địa chỉ email duy nhất của người dùng.
        /// </summary>
        public string Email
        {
            get { return strEmail; }
            set { strEmail = value; }
        }

        /// <summary>
        /// Mã học viên; chỉ có giá trị với tài khoản học viên.
        /// </summary>
        public string StudentCode
        {
            get { return strStudentCode; }
            set { strStudentCode = value; }
        }

        /// <summary>
        /// Mã giảng viên; chỉ có giá trị với tài khoản giảng viên.
        /// </summary>
        public string TeacherCode
        {
            get { return strTeacherCode; }
            set { strTeacherCode = value; }
        }

        /// <summary>
        /// Đường dẫn ảnh đại diện của người dùng.
        /// </summary>
        public string AvatarUrl
        {
            get { return strAvatarUrl; }
            set { strAvatarUrl = value; }
        }

        /// <summary>
        /// Trạng thái tài khoản: ACTIVE, INACTIVE hoặc LOCKED.
        /// </summary>
        public string Status
        {
            get { return strStatus; }
            set { strStatus = value; }
        }

        /// <summary>
        /// Thời điểm đăng nhập thành công gần nhất theo UTC.
        /// </summary>
        public DateTime? LastLoginAt
        {
            get { return dtmLastLoginAt; }
            set { dtmLastLoginAt = value; }
        }

        /// <summary>
        /// Thời điểm tạo tài khoản theo UTC.
        /// </summary>
        public DateTime CreatedAt
        {
            get { return dtmCreatedAt; }
            set { dtmCreatedAt = value; }
        }

        /// <summary>
        /// Thời điểm cập nhật tài khoản gần nhất theo UTC.
        /// </summary>
        public DateTime? UpdatedAt
        {
            get { return dtmUpdatedAt; }
            set { dtmUpdatedAt = value; }
        }

        /// <summary>
        /// ID người dùng đã tạo tài khoản này.
        /// </summary>
        public long? CreatedByUserID
        {
            get { return lngCreatedByUserID; }
            set { lngCreatedByUserID = value; }
        }

        /// <summary>
        /// ID người dùng cập nhật tài khoản gần nhất.
        /// </summary>
        public long? UpdatedByUserID
        {
            get { return lngUpdatedByUserID; }
            set { lngUpdatedByUserID = value; }
        }

        /// <summary>
        /// Cờ xóa mềm: 1 là đã xóa, 0 là đang sử dụng.
        /// </summary>
        public bool IsDeleted
        {
            get { return bolIsDeleted; }
            set { bolIsDeleted = value; }
        }

        /// <summary>
        /// Mã đơn vị hoặc nhóm dữ liệu sở hữu tài khoản.
        /// </summary>
        public int DataGroupID
        {
            get { return intDataGroupID; }
            set { intDataGroupID = value; }
        }

        /// <summary>
        /// Mã hồ sơ học viên liên kết với tài khoản, nếu người dùng là học viên.
        /// </summary>
        public string StudentID
        {
            get { return strStudentID; }
            set { strStudentID = value; }
        }

        /// <summary>
        /// Mã hồ sơ giảng viên liên kết với tài khoản, nếu người dùng là giảng viên.
        /// </summary>
        public string TeacherID
        {
            get { return strTeacherID; }
            set { strTeacherID = value; }
        }

        /// <summary>
        /// IData - Đối tượng IData truy xuất dữ liệu.
        ///	Nếu null thì các tác vụ của đối tượng tự tạo connect và depose mỗi khi được gọi
        /// </summary>
        public IData IDB
        {
            get { return objIData; }
            set { objIData = value; bolIsExistIData = (value != null); }
        }

        /// <summary>
        /// ErrorException - Đối tượng lỗi nhận trả về khi method được thực thi.
        ///	Nếu null thì các tác vụ của đối tượng tự tạo connect và depose mỗi khi được gọi
        /// </summary>
        public Exception ErrorException
        {
            get { return objErrorException; }
            set { objErrorException = value; }
        }

        #endregion

        #region Methods

        ///<summary>
        /// Chuyển từ một IDataReader thành đối tượng
        ///</summary>
        /// <returns>true ? Có : False ? Không</returns>
        public bool Parse(IDataReader reader)
        {
            try
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    if (reader.GetName(i).ToUpper().Equals(C_UserID.ToUpper()) && !Convert.IsDBNull(reader[C_UserID])) this.lngUserID = Convert.ToInt64(reader[C_UserID]);
                    if (reader.GetName(i).ToUpper().Equals(C_Username.ToUpper()) && !Convert.IsDBNull(reader[C_Username])) this.strUsername = Convert.ToString(reader[C_Username]);
                    if (reader.GetName(i).ToUpper().Equals(C_PasswordHash.ToUpper()) && !Convert.IsDBNull(reader[C_PasswordHash])) this.strPasswordHash = Convert.ToString(reader[C_PasswordHash]);
                    if (reader.GetName(i).ToUpper().Equals(C_FullName.ToUpper()) && !Convert.IsDBNull(reader[C_FullName])) this.strFullName = Convert.ToString(reader[C_FullName]);
                    if (reader.GetName(i).ToUpper().Equals(C_Email.ToUpper()) && !Convert.IsDBNull(reader[C_Email])) this.strEmail = Convert.ToString(reader[C_Email]);
                    if (reader.GetName(i).ToUpper().Equals(C_StudentCode.ToUpper()) && !Convert.IsDBNull(reader[C_StudentCode])) this.strStudentCode = Convert.ToString(reader[C_StudentCode]);
                    if (reader.GetName(i).ToUpper().Equals(C_TeacherCode.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherCode])) this.strTeacherCode = Convert.ToString(reader[C_TeacherCode]);
                    if (reader.GetName(i).ToUpper().Equals(C_AvatarUrl.ToUpper()) && !Convert.IsDBNull(reader[C_AvatarUrl])) this.strAvatarUrl = Convert.ToString(reader[C_AvatarUrl]);
                    if (reader.GetName(i).ToUpper().Equals(C_Status.ToUpper()) && !Convert.IsDBNull(reader[C_Status])) this.strStatus = Convert.ToString(reader[C_Status]);
                    if (reader.GetName(i).ToUpper().Equals(C_LastLoginAt.ToUpper()) && !Convert.IsDBNull(reader[C_LastLoginAt])) this.dtmLastLoginAt = Convert.ToDateTime(reader[C_LastLoginAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(reader[C_CreatedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedAt])) this.dtmUpdatedAt = Convert.ToDateTime(reader[C_UpdatedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedByUserID.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedByUserID])) this.lngCreatedByUserID = Convert.ToInt64(reader[C_CreatedByUserID]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedByUserID.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedByUserID])) this.lngUpdatedByUserID = Convert.ToInt64(reader[C_UpdatedByUserID]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsDeleted.ToUpper()) && !Convert.IsDBNull(reader[C_IsDeleted])) this.bolIsDeleted = Convert.ToBoolean(reader[C_IsDeleted]);
                    if (reader.GetName(i).ToUpper().Equals(C_DataGroupID.ToUpper()) && !Convert.IsDBNull(reader[C_DataGroupID])) this.intDataGroupID = Convert.ToInt32(reader[C_DataGroupID]);
                    if (reader.GetName(i).ToUpper().Equals(C_StudentID.ToUpper()) && !Convert.IsDBNull(reader[C_StudentID])) this.strStudentID = Convert.ToString(reader[C_StudentID]);
                    if (reader.GetName(i).ToUpper().Equals(C_TeacherID.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherID])) this.strTeacherID = Convert.ToString(reader[C_TeacherID]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi chuyển đổi dữ liệu từ IDataReader sang SYS_Users", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        public bool Parse(DataRow drw)
        {
            try
            {
                if (!Convert.IsDBNull(drw[C_UserID])) this.lngUserID = Convert.ToInt64(drw[C_UserID]);
                if (!Convert.IsDBNull(drw[C_Username])) this.strUsername = Convert.ToString(drw[C_Username]);
                if (!Convert.IsDBNull(drw[C_PasswordHash])) this.strPasswordHash = Convert.ToString(drw[C_PasswordHash]);
                if (!Convert.IsDBNull(drw[C_FullName])) this.strFullName = Convert.ToString(drw[C_FullName]);
                if (!Convert.IsDBNull(drw[C_Email])) this.strEmail = Convert.ToString(drw[C_Email]);
                if (!Convert.IsDBNull(drw[C_StudentCode])) this.strStudentCode = Convert.ToString(drw[C_StudentCode]);
                if (!Convert.IsDBNull(drw[C_TeacherCode])) this.strTeacherCode = Convert.ToString(drw[C_TeacherCode]);
                if (!Convert.IsDBNull(drw[C_AvatarUrl])) this.strAvatarUrl = Convert.ToString(drw[C_AvatarUrl]);
                if (!Convert.IsDBNull(drw[C_Status])) this.strStatus = Convert.ToString(drw[C_Status]);
                if (!Convert.IsDBNull(drw[C_LastLoginAt])) this.dtmLastLoginAt = Convert.ToDateTime(drw[C_LastLoginAt]);
                if (!Convert.IsDBNull(drw[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(drw[C_CreatedAt]);
                if (!Convert.IsDBNull(drw[C_UpdatedAt])) this.dtmUpdatedAt = Convert.ToDateTime(drw[C_UpdatedAt]);
                if (!Convert.IsDBNull(drw[C_CreatedByUserID])) this.lngCreatedByUserID = Convert.ToInt64(drw[C_CreatedByUserID]);
                if (!Convert.IsDBNull(drw[C_UpdatedByUserID])) this.lngUpdatedByUserID = Convert.ToInt64(drw[C_UpdatedByUserID]);
                if (!Convert.IsDBNull(drw[C_IsDeleted])) this.bolIsDeleted = Convert.ToBoolean(drw[C_IsDeleted]);
                if (!Convert.IsDBNull(drw[C_DataGroupID])) this.intDataGroupID = Convert.ToInt32(drw[C_DataGroupID]);
                if (!Convert.IsDBNull(drw[C_StudentID])) this.strStudentID = Convert.ToString(drw[C_StudentID]);
                if (!Convert.IsDBNull(drw[C_TeacherID])) this.strTeacherID = Convert.ToString(drw[C_TeacherID]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi chuyển đổi dữ liệu từ DataRow sang SYS_Users", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        public bool Get()
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_UserID, this.lngUserID);
                IDataReader reader = objIData.ExecStoreToDataReader();
                bool result = reader.Read() && Parse(reader);
                reader.Close();
                return result;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData) this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin trong SYS_Users", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        public SYS_Users Get(long lngUserID)
        {
            SYS_Users obj = new SYS_Users();
            if (objIData != null) obj.IDB = objIData;
            obj.UserID = lngUserID;
            if (obj.Get()) return obj;
            this.objErrorException = obj.ErrorException;
            return null;
        }

        public bool ExecNonQuery(string storeName, params object[] pars)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(storeName);
                objIData.AddParameter(pars);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData) this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SYS_Users", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        public DataTable GetDataTable(string storeName, params object[] pars)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(storeName);
                objIData.AddParameter(pars);
                return objIData.ExecStoreToDataTable();
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData) this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SYS_Users", objEx);
                this.objErrorException = objEx;
                return null;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        public DataTable GetAll()
        {
            return GetDataTable(StoreGetAll);
        }

        public DataTable Search(params object[] pars)
        {
            return GetDataTable(StoreSearch, pars);
        }

        public bool Add()
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreAdd);
                objIData.AddParameter(P_Username, this.strUsername);
                objIData.AddParameter(P_PasswordHash, this.strPasswordHash);
                objIData.AddParameter(P_FullName, this.strFullName);
                objIData.AddParameter(P_Email, this.strEmail);
                objIData.AddParameter(P_StudentCode, this.strStudentCode);
                objIData.AddParameter(P_TeacherCode, this.strTeacherCode);
                objIData.AddParameter(P_AvatarUrl, this.strAvatarUrl);
                objIData.AddParameter(P_Status, this.strStatus);
                objIData.AddParameter(P_LastLoginAt, this.dtmLastLoginAt);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_UpdatedAt, this.dtmUpdatedAt);
                objIData.AddParameter(P_CreatedByUserID, this.lngCreatedByUserID);
                objIData.AddParameter(P_UpdatedByUserID, this.lngUpdatedByUserID);
                objIData.AddParameter(P_IsDeleted, this.bolIsDeleted);
                objIData.AddParameter(P_DataGroupID, this.intDataGroupID);
                objIData.AddParameter(P_StudentID, this.strStudentID);
                objIData.AddParameter(P_TeacherID, this.strTeacherID);
                this.lngUserID = Convert.ToInt64(objIData.ExecStoreToString());
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData) this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin trong SYS_Users", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        public bool Update()
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_UserID, this.lngUserID);
                objIData.AddParameter(P_Username, this.strUsername);
                objIData.AddParameter(P_PasswordHash, this.strPasswordHash);
                objIData.AddParameter(P_FullName, this.strFullName);
                objIData.AddParameter(P_Email, this.strEmail);
                objIData.AddParameter(P_StudentCode, this.strStudentCode);
                objIData.AddParameter(P_TeacherCode, this.strTeacherCode);
                objIData.AddParameter(P_AvatarUrl, this.strAvatarUrl);
                objIData.AddParameter(P_Status, this.strStatus);
                objIData.AddParameter(P_LastLoginAt, this.dtmLastLoginAt);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_UpdatedAt, this.dtmUpdatedAt);
                objIData.AddParameter(P_CreatedByUserID, this.lngCreatedByUserID);
                objIData.AddParameter(P_UpdatedByUserID, this.lngUpdatedByUserID);
                objIData.AddParameter(P_IsDeleted, this.bolIsDeleted);
                objIData.AddParameter(P_DataGroupID, this.intDataGroupID);
                objIData.AddParameter(P_StudentID, this.strStudentID);
                objIData.AddParameter(P_TeacherID, this.strTeacherID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData) this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong SYS_Users", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        public bool Delete()
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_UserID, this.lngUserID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData) this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong SYS_Users", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        #endregion

        #region Transaction methods

        public bool BeginTransaction()
        {
            objIData = DCore.Data.CreateData();
            try { objIData.Connect(); objIData.BeginTransaction(); bolIsExistIData = true; return true; }
            catch (Exception objEx) { this.objErrorException = objEx; return false; }
        }

        public void CommitTransaction() { objIData.CommitTransaction(); objIData.Disconnect(); bolIsExistIData = false; }
        public void RollBackTransaction() { objIData.RollBackTransaction(); objIData.Disconnect(); bolIsExistIData = false; }

        #endregion

        #region Constructor

        public SYS_Users() { }
        public SYS_Users(long lngUserID)
        {
            this.lngUserID = lngUserID;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "SYS_Users";
        public const string StoreGet = "SYS_Users_GET";
        public const string StoreGetAll = "SYS_Users_GETALL";
        public const string StoreSearch = "SYS_Users_SEARCH";
        public const string StoreAdd = "SYS_Users_ADD";
        public const string StoreEdit = "SYS_Users_EDIT";
        public const string StoreDelete = "SYS_Users_DELETE";

        #region Parameter Names

        public const string P_UserID = "@" + C_UserID;
        public const string P_Username = "@" + C_Username;
        public const string P_PasswordHash = "@" + C_PasswordHash;
        public const string P_FullName = "@" + C_FullName;
        public const string P_Email = "@" + C_Email;
        public const string P_StudentCode = "@" + C_StudentCode;
        public const string P_TeacherCode = "@" + C_TeacherCode;
        public const string P_AvatarUrl = "@" + C_AvatarUrl;
        public const string P_Status = "@" + C_Status;
        public const string P_LastLoginAt = "@" + C_LastLoginAt;
        public const string P_CreatedAt = "@" + C_CreatedAt;
        public const string P_UpdatedAt = "@" + C_UpdatedAt;
        public const string P_CreatedByUserID = "@" + C_CreatedByUserID;
        public const string P_UpdatedByUserID = "@" + C_UpdatedByUserID;
        public const string P_IsDeleted = "@" + C_IsDeleted;
        public const string P_DataGroupID = "@" + C_DataGroupID;
        public const string P_StudentID = "@" + C_StudentID;
        public const string P_TeacherID = "@" + C_TeacherID;

        #endregion

        #region Column Names

        public const string C_UserID = "UserID";
        public const string C_Username = "Username";
        public const string C_PasswordHash = "PasswordHash";
        public const string C_FullName = "FullName";
        public const string C_Email = "Email";
        public const string C_StudentCode = "StudentCode";
        public const string C_TeacherCode = "TeacherCode";
        public const string C_AvatarUrl = "AvatarUrl";
        public const string C_Status = "Status";
        public const string C_LastLoginAt = "LastLoginAt";
        public const string C_CreatedAt = "CreatedAt";
        public const string C_UpdatedAt = "UpdatedAt";
        public const string C_CreatedByUserID = "CreatedByUserID";
        public const string C_UpdatedByUserID = "UpdatedByUserID";
        public const string C_IsDeleted = "IsDeleted";
        public const string C_DataGroupID = "DataGroupID";
        public const string C_StudentID = "StudentID";
        public const string C_TeacherID = "TeacherID";

        #endregion

        #endregion
    }
}
