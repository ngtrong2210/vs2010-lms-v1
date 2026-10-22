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
    /// [SYS] Quan hệ nhiều-nhiều giữa tài khoản và vai trò.
    /// </summary>
    public partial class SYS_UserRoles
    {
        #region Member Variables

        private long lngUserId = 0;//ID người dùng được gán vai trò.
        private long lngRoleId = 0;//ID vai trò được gán cho người dùng.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// UserId
        /// ID người dùng được gán vai trò.
        /// </summary>
        public long UserId
        {
            get { return lngUserId; }
            set { lngUserId = value; }
        }

        /// <summary>
        /// RoleId
        /// ID vai trò được gán cho người dùng.
        /// </summary>
        public long RoleId
        {
            get { return lngRoleId; }
            set { lngRoleId = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_UserId.ToUpper()) && !Convert.IsDBNull(reader[C_UserId])) this.lngUserId = Convert.ToInt64(reader[C_UserId]);
                    if (reader.GetName(i).ToUpper().Equals(C_RoleId.ToUpper()) && !Convert.IsDBNull(reader[C_RoleId])) this.lngRoleId = Convert.ToInt64(reader[C_RoleId]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SYS_UserRoles", objEx);
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
                if (!Convert.IsDBNull(drw[C_UserId])) this.lngUserId = Convert.ToInt64(drw[C_UserId]);
                if (!Convert.IsDBNull(drw[C_RoleId])) this.lngRoleId = Convert.ToInt64(drw[C_RoleId]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SYS_UserRoles", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: SYS_UserRoles_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_UserId, this.lngUserId);
                objIData.AddParameter(P_RoleId, this.lngRoleId);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin SYS_UserRoles", objEx);
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
        /// Store: SYS_UserRoles_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public SYS_UserRoles Get(long lngUserId, long lngRoleId)
        {
            SYS_UserRoles obj = new SYS_UserRoles();
            if (objIData != null) obj.IDB = objIData;
            obj.UserId = lngUserId;
            obj.RoleId = lngRoleId;
            if (obj.Get()) return obj;
            this.objErrorException = obj.ErrorException;
            return null;
        }

        ///<summary>
        ///Thêm mới dữ liệu
        /// Store: SYS_UserRoles_ADD
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreAdd);
                objIData.AddParameter(P_UserId, this.lngUserId);
                objIData.AddParameter(P_RoleId, this.lngRoleId);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm mới thông tin trong SYS_UserRoles", objEx);
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
        /// Store: SYS_UserRoles_EDIT
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_UserId, this.lngUserId);
                objIData.AddParameter(P_RoleId, this.lngRoleId);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong SYS_UserRoles", objEx);
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
        /// Store: SYS_UserRoles_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_UserId, this.lngUserId);
                objIData.AddParameter(P_RoleId, this.lngRoleId);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong SYS_UserRoles", objEx);
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
        /// Store: SYS_UserRoles_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long lngUserId, long lngRoleId)
        {
            this.lngUserId = lngUserId;
            this.lngRoleId = lngRoleId;
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

        public SYS_UserRoles()
        {
        }
        public SYS_UserRoles(long lngUserId, long lngRoleId)
        {
            this.lngUserId = lngUserId;
            this.lngRoleId = lngRoleId;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "SYS_UserRoles";
        public const string StoreGet = "SYS_UserRoles_GET";
        public const string StoreGetAll = "SYS_UserRoles_GETALL";
        public const string StoreSearch = "SYS_UserRoles_SEARCH";
        public const string StoreAdd = "SYS_UserRoles_ADD";
        public const string StoreEdit = "SYS_UserRoles_EDIT";
        public const string StoreDelete = "SYS_UserRoles_DELETE";

        #region Parameter Names

        public const String P_UserId = "@" + C_UserId;
        public const String P_RoleId = "@" + C_RoleId;

        #endregion //Parameter names

        #region Column Names

        public const String C_UserId = "UserId";
        public const String C_RoleId = "RoleId";

        #endregion //Column names

        #endregion Variable Static
    }
}
