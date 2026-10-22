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
    /// [SYS] Quan hệ giữa vai trò và quyền được cấp.
    /// </summary>
    public partial class SYS_RolePermissions
    {
        #region Member Variables

        private long lngRoleId = 0;//ID vai trò được cấp quyền.
        private long lngPermissionId = 0;//ID quyền được cấp cho vai trò.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// RoleId
        /// ID vai trò được cấp quyền.
        /// </summary>
        public long RoleId
        {
            get { return lngRoleId; }
            set { lngRoleId = value; }
        }

        /// <summary>
        /// PermissionId
        /// ID quyền được cấp cho vai trò.
        /// </summary>
        public long PermissionId
        {
            get { return lngPermissionId; }
            set { lngPermissionId = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_RoleId.ToUpper()) && !Convert.IsDBNull(reader[C_RoleId])) this.lngRoleId = Convert.ToInt64(reader[C_RoleId]);
                    if (reader.GetName(i).ToUpper().Equals(C_PermissionId.ToUpper()) && !Convert.IsDBNull(reader[C_PermissionId])) this.lngPermissionId = Convert.ToInt64(reader[C_PermissionId]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SYS_RolePermissions", objEx);
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
                if (!Convert.IsDBNull(drw[C_RoleId])) this.lngRoleId = Convert.ToInt64(drw[C_RoleId]);
                if (!Convert.IsDBNull(drw[C_PermissionId])) this.lngPermissionId = Convert.ToInt64(drw[C_PermissionId]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SYS_RolePermissions", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: SYS_RolePermissions_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_RoleId, this.lngRoleId);
                objIData.AddParameter(P_PermissionId, this.lngPermissionId);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin SYS_RolePermissions", objEx);
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
        /// Store: SYS_RolePermissions_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public SYS_RolePermissions Get(long lngRoleId, long lngPermissionId)
        {
            SYS_RolePermissions obj = new SYS_RolePermissions();
            if (objIData != null) obj.IDB = objIData;
            obj.RoleId = lngRoleId;
            obj.PermissionId = lngPermissionId;
            if (obj.Get()) return obj;
            this.objErrorException = obj.ErrorException;
            return null;
        }

        ///<summary>
        ///Thêm mới dữ liệu
        /// Store: SYS_RolePermissions_ADD
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreAdd);
                objIData.AddParameter(P_RoleId, this.lngRoleId);
                objIData.AddParameter(P_PermissionId, this.lngPermissionId);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm mới thông tin trong SYS_RolePermissions", objEx);
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
        /// Store: SYS_RolePermissions_EDIT
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_RoleId, this.lngRoleId);
                objIData.AddParameter(P_PermissionId, this.lngPermissionId);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong SYS_RolePermissions", objEx);
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
        /// Store: SYS_RolePermissions_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_RoleId, this.lngRoleId);
                objIData.AddParameter(P_PermissionId, this.lngPermissionId);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong SYS_RolePermissions", objEx);
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
        /// Store: SYS_RolePermissions_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long lngRoleId, long lngPermissionId)
        {
            this.lngRoleId = lngRoleId;
            this.lngPermissionId = lngPermissionId;
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

        public SYS_RolePermissions()
        {
        }
        public SYS_RolePermissions(long lngRoleId, long lngPermissionId)
        {
            this.lngRoleId = lngRoleId;
            this.lngPermissionId = lngPermissionId;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "SYS_RolePermissions";
        public const string StoreGet = "SYS_RolePermissions_GET";
        public const string StoreGetAll = "SYS_RolePermissions_GETALL";
        public const string StoreSearch = "SYS_RolePermissions_SEARCH";
        public const string StoreAdd = "SYS_RolePermissions_ADD";
        public const string StoreEdit = "SYS_RolePermissions_EDIT";
        public const string StoreDelete = "SYS_RolePermissions_DELETE";

        #region Parameter Names

        public const String P_RoleId = "@" + C_RoleId;
        public const String P_PermissionId = "@" + C_PermissionId;

        #endregion //Parameter names

        #region Column Names

        public const String C_RoleId = "RoleId";
        public const String C_PermissionId = "PermissionId";

        #endregion //Column names

        #endregion Variable Static
    }
}
