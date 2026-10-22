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
    /// [SYS] Danh mục vai trò sử dụng trong hệ thống.
    /// </summary>
    public partial class SYS_Roles
    {
        #region Member Variables

        private long lngRoleID = 0;//Khóa chính tự tăng của vai trò.
        private string strCode = null;//Mã kỹ thuật duy nhất của vai trò, ví dụ ADMIN, TEACHER, STUDENT.
        private string strName = null;//Tên hiển thị của vai trò.
        private string strDescription = null;//Mô tả phạm vi và mục đích của vai trò.
        private string strStatus = null;//Trạng thái sử dụng của vai trò.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// RoleID
        /// Khóa chính tự tăng của vai trò.
        /// </summary>
        public long RoleID
        {
            get { return lngRoleID; }
            set { lngRoleID = value; }
        }

        /// <summary>
        /// Code
        /// Mã kỹ thuật duy nhất của vai trò, ví dụ ADMIN, TEACHER, STUDENT.
        /// </summary>
        public string Code
        {
            get { return strCode; }
            set { strCode = value; }
        }

        /// <summary>
        /// Name
        /// Tên hiển thị của vai trò.
        /// </summary>
        public string Name
        {
            get { return strName; }
            set { strName = value; }
        }

        /// <summary>
        /// Description
        /// Mô tả phạm vi và mục đích của vai trò.
        /// </summary>
        public string Description
        {
            get { return strDescription; }
            set { strDescription = value; }
        }

        /// <summary>
        /// Status
        /// Trạng thái sử dụng của vai trò.
        /// </summary>
        public string Status
        {
            get { return strStatus; }
            set { strStatus = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_RoleID.ToUpper()) && !Convert.IsDBNull(reader[C_RoleID])) this.lngRoleID = Convert.ToInt64(reader[C_RoleID]);
                    if (reader.GetName(i).ToUpper().Equals(C_Code.ToUpper()) && !Convert.IsDBNull(reader[C_Code])) this.strCode = Convert.ToString(reader[C_Code]);
                    if (reader.GetName(i).ToUpper().Equals(C_Name.ToUpper()) && !Convert.IsDBNull(reader[C_Name])) this.strName = Convert.ToString(reader[C_Name]);
                    if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
                    if (reader.GetName(i).ToUpper().Equals(C_Status.ToUpper()) && !Convert.IsDBNull(reader[C_Status])) this.strStatus = Convert.ToString(reader[C_Status]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SYS_Roles", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        /// Chuyển từ một DataRow thành đối tượng
        ///</summary>
        /// <returns>true ? Có : False? Không</returns>
        public bool Parse(DataRow drw)
        {
            try
            {
                if (!Convert.IsDBNull(drw[C_RoleID])) this.lngRoleID = Convert.ToInt64(drw[C_RoleID]);
                if (!Convert.IsDBNull(drw[C_Code])) this.strCode = Convert.ToString(drw[C_Code]);
                if (!Convert.IsDBNull(drw[C_Name])) this.strName = Convert.ToString(drw[C_Name]);
                if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
                if (!Convert.IsDBNull(drw[C_Status])) this.strStatus = Convert.ToString(drw[C_Status]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SYS_Roles", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: SYS_Roles_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_RoleID, this.lngRoleID);
                IDataReader reader = objIData.ExecStoreToDataReader();
                if (reader.Read())
                {
                    this.Parse(reader);
                    reader.Close();
                    return true;
                }
                else
                {
                    reader.Close();
                    return false;
                }
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin SYS_Roles", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: SYS_Roles_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public SYS_Roles Get(long lngRoleID)
        {
            SYS_Roles obj = new SYS_Roles();
            if (objIData != null) obj.IDB = objIData;
            obj.RoleID = lngRoleID;
            if (obj.Get()) return obj;
            this.objErrorException = obj.ErrorException;
            return null;
        }

        ///<summary>
        ///Thêm mới dữ liệu
        /// Store: SYS_Roles_ADD
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreAdd);
                objIData.AddParameter(P_Code, this.strCode);
                objIData.AddParameter(P_Name, this.strName);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_Status, this.strStatus);
                this.lngRoleID = Convert.ToInt64(objIData.ExecStoreToString());
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm mới thông tin trong SYS_Roles", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        ///<summary>
        ///Cập nhật dữ liệu
        /// Store: SYS_Roles_EDIT
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_RoleID, this.lngRoleID);
                objIData.AddParameter(P_Code, this.strCode);
                objIData.AddParameter(P_Name, this.strName);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_Status, this.strStatus);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong SYS_Roles", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        ///<summary>
        ///Xóa dữ liệu
        /// Store: SYS_Roles_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_RoleID, this.lngRoleID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong SYS_Roles", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        ///<summary>
        ///Xóa dữ liệu
        /// Store: SYS_Roles_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long lngRoleID)
        {
            this.lngRoleID = lngRoleID;
            return this.Delete();
        }

        #endregion

        #region Transaction methods

        ///<summary>
        /// Bắt đầu một Transaction.
        ///</summary>
        /// <returns> true: ket noi thanh con; false: khong ket noi duoc </returns>
        public bool BeginTransaction()
        {
            objIData = DCore.Data.CreateData();
            try
            {
                objIData.Connect();
                objIData.BeginTransaction();
                bolIsExistIData = true;
                return true;
            }
            catch (Exception objEx)
            {
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        /// Hoàn thành một Transaction.
        ///</summary>
        public void CommitTransaction()
        {
            objIData.CommitTransaction();
            objIData.Disconnect();
            bolIsExistIData = false;
        }

        ///<summary>
        /// Rollback một Transaction.
        ///</summary>
        public void RollBackTransaction()
        {
            objIData.RollBackTransaction();
            objIData.Disconnect();
            bolIsExistIData = false;
        }

        #endregion

        #region Constructor

        public SYS_Roles()
        {
        }
        public SYS_Roles(long lngRoleID)
        {
            this.lngRoleID = lngRoleID;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "SYS_Roles";
        public const string StoreGet = "SYS_Roles_GET";
        public const string StoreGetAll = "SYS_Roles_GETALL";
        public const string StoreSearch = "SYS_Roles_SEARCH";
        public const string StoreAdd = "SYS_Roles_ADD";
        public const string StoreEdit = "SYS_Roles_EDIT";
        public const string StoreDelete = "SYS_Roles_DELETE";

        #region Parameter Names

        public const String P_RoleID = "@" + C_RoleID;
        public const String P_Code = "@" + C_Code;
        public const String P_Name = "@" + C_Name;
        public const String P_Description = "@" + C_Description;
        public const String P_Status = "@" + C_Status;

        #endregion //Parameter names

        #region Column Names

        public const String C_RoleID = "RoleID";
        public const String C_Code = "Code";
        public const String C_Name = "Name";
        public const String C_Description = "Description";
        public const String C_Status = "Status";

        #endregion //Column names

        #endregion Variable Static
    }
}
