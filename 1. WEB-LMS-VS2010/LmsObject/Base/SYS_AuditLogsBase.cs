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
    /// [SYS] Nhật ký thao tác và thay đổi dữ liệu quan trọng.
    /// </summary>
    public partial class SYS_AuditLogs
    {
        #region Member Variables

        private long lngAuditLogID = 0;//Khóa chính tự tăng của bản ghi nhật ký.
        private long? lngUserId = null;//ID người dùng thực hiện thao tác; có thể rỗng với tác vụ hệ thống.
        private string strAction = null;//Tên hành động được ghi nhận.
        private string strModule = null;//Phân hệ phát sinh hành động.
        private string strEntityName = null;//Tên loại dữ liệu bị tác động.
        private string strEntityId = null;//Khóa định danh của bản ghi bị tác động.
        private string strOldValuesJson = null;//Dữ liệu trước thay đổi ở định dạng JSON.
        private string strNewValuesJson = null;//Dữ liệu sau thay đổi ở định dạng JSON.
        private string strIpAddress = null;//Địa chỉ IP của thiết bị thực hiện thao tác.
        private string strUserAgent = null;//Thông tin trình duyệt hoặc ứng dụng khách.
        private DateTime dtmCreatedAt = DateTime.MinValue;//Thời điểm ghi nhận hành động theo UTC.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// AuditLogID
        /// Khóa chính tự tăng của bản ghi nhật ký.
        /// </summary>
        public long AuditLogID
        {
            get { return lngAuditLogID; }
            set { lngAuditLogID = value; }
        }

        /// <summary>
        /// UserId
        /// ID người dùng thực hiện thao tác; có thể rỗng với tác vụ hệ thống.
        /// </summary>
        public long? UserId
        {
            get { return lngUserId; }
            set { lngUserId = value; }
        }

        /// <summary>
        /// Action
        /// Tên hành động được ghi nhận.
        /// </summary>
        public string Action
        {
            get { return strAction; }
            set { strAction = value; }
        }

        /// <summary>
        /// Module
        /// Phân hệ phát sinh hành động.
        /// </summary>
        public string Module
        {
            get { return strModule; }
            set { strModule = value; }
        }

        /// <summary>
        /// EntityName
        /// Tên loại dữ liệu bị tác động.
        /// </summary>
        public string EntityName
        {
            get { return strEntityName; }
            set { strEntityName = value; }
        }

        /// <summary>
        /// EntityId
        /// Khóa định danh của bản ghi bị tác động.
        /// </summary>
        public string EntityId
        {
            get { return strEntityId; }
            set { strEntityId = value; }
        }

        /// <summary>
        /// OldValuesJson
        /// Dữ liệu trước thay đổi ở định dạng JSON.
        /// </summary>
        public string OldValuesJson
        {
            get { return strOldValuesJson; }
            set { strOldValuesJson = value; }
        }

        /// <summary>
        /// NewValuesJson
        /// Dữ liệu sau thay đổi ở định dạng JSON.
        /// </summary>
        public string NewValuesJson
        {
            get { return strNewValuesJson; }
            set { strNewValuesJson = value; }
        }

        /// <summary>
        /// IpAddress
        /// Địa chỉ IP của thiết bị thực hiện thao tác.
        /// </summary>
        public string IpAddress
        {
            get { return strIpAddress; }
            set { strIpAddress = value; }
        }

        /// <summary>
        /// UserAgent
        /// Thông tin trình duyệt hoặc ứng dụng khách.
        /// </summary>
        public string UserAgent
        {
            get { return strUserAgent; }
            set { strUserAgent = value; }
        }

        /// <summary>
        /// CreatedAt
        /// Thời điểm ghi nhận hành động theo UTC.
        /// </summary>
        public DateTime CreatedAt
        {
            get { return dtmCreatedAt; }
            set { dtmCreatedAt = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_AuditLogID.ToUpper()) && !Convert.IsDBNull(reader[C_AuditLogID])) this.lngAuditLogID = Convert.ToInt64(reader[C_AuditLogID]);
                    if (reader.GetName(i).ToUpper().Equals(C_UserId.ToUpper()) && !Convert.IsDBNull(reader[C_UserId])) this.lngUserId = Convert.ToInt64(reader[C_UserId]);
                    if (reader.GetName(i).ToUpper().Equals(C_Action.ToUpper()) && !Convert.IsDBNull(reader[C_Action])) this.strAction = Convert.ToString(reader[C_Action]);
                    if (reader.GetName(i).ToUpper().Equals(C_Module.ToUpper()) && !Convert.IsDBNull(reader[C_Module])) this.strModule = Convert.ToString(reader[C_Module]);
                    if (reader.GetName(i).ToUpper().Equals(C_EntityName.ToUpper()) && !Convert.IsDBNull(reader[C_EntityName])) this.strEntityName = Convert.ToString(reader[C_EntityName]);
                    if (reader.GetName(i).ToUpper().Equals(C_EntityId.ToUpper()) && !Convert.IsDBNull(reader[C_EntityId])) this.strEntityId = Convert.ToString(reader[C_EntityId]);
                    if (reader.GetName(i).ToUpper().Equals(C_OldValuesJson.ToUpper()) && !Convert.IsDBNull(reader[C_OldValuesJson])) this.strOldValuesJson = Convert.ToString(reader[C_OldValuesJson]);
                    if (reader.GetName(i).ToUpper().Equals(C_NewValuesJson.ToUpper()) && !Convert.IsDBNull(reader[C_NewValuesJson])) this.strNewValuesJson = Convert.ToString(reader[C_NewValuesJson]);
                    if (reader.GetName(i).ToUpper().Equals(C_IpAddress.ToUpper()) && !Convert.IsDBNull(reader[C_IpAddress])) this.strIpAddress = Convert.ToString(reader[C_IpAddress]);
                    if (reader.GetName(i).ToUpper().Equals(C_UserAgent.ToUpper()) && !Convert.IsDBNull(reader[C_UserAgent])) this.strUserAgent = Convert.ToString(reader[C_UserAgent]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(reader[C_CreatedAt]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SYS_AuditLogs", objEx);
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
                if (!Convert.IsDBNull(drw[C_AuditLogID])) this.lngAuditLogID = Convert.ToInt64(drw[C_AuditLogID]);
                if (!Convert.IsDBNull(drw[C_UserId])) this.lngUserId = Convert.ToInt64(drw[C_UserId]);
                if (!Convert.IsDBNull(drw[C_Action])) this.strAction = Convert.ToString(drw[C_Action]);
                if (!Convert.IsDBNull(drw[C_Module])) this.strModule = Convert.ToString(drw[C_Module]);
                if (!Convert.IsDBNull(drw[C_EntityName])) this.strEntityName = Convert.ToString(drw[C_EntityName]);
                if (!Convert.IsDBNull(drw[C_EntityId])) this.strEntityId = Convert.ToString(drw[C_EntityId]);
                if (!Convert.IsDBNull(drw[C_OldValuesJson])) this.strOldValuesJson = Convert.ToString(drw[C_OldValuesJson]);
                if (!Convert.IsDBNull(drw[C_NewValuesJson])) this.strNewValuesJson = Convert.ToString(drw[C_NewValuesJson]);
                if (!Convert.IsDBNull(drw[C_IpAddress])) this.strIpAddress = Convert.ToString(drw[C_IpAddress]);
                if (!Convert.IsDBNull(drw[C_UserAgent])) this.strUserAgent = Convert.ToString(drw[C_UserAgent]);
                if (!Convert.IsDBNull(drw[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(drw[C_CreatedAt]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SYS_AuditLogs", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: SYS_AuditLogs_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_AuditLogID, this.lngAuditLogID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin SYS_AuditLogs", objEx);
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
        /// Store: SYS_AuditLogs_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public SYS_AuditLogs Get(long lngAuditLogID)
        {
            SYS_AuditLogs obj = new SYS_AuditLogs();
            if (objIData != null) obj.IDB = objIData;
            obj.AuditLogID = lngAuditLogID;
            if (obj.Get()) return obj;
            this.objErrorException = obj.ErrorException;
            return null;
        }

        ///<summary>
        ///Thêm mới dữ liệu
        /// Store: SYS_AuditLogs_ADD
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
                objIData.AddParameter(P_Action, this.strAction);
                objIData.AddParameter(P_Module, this.strModule);
                objIData.AddParameter(P_EntityName, this.strEntityName);
                objIData.AddParameter(P_EntityId, this.strEntityId);
                objIData.AddParameter(P_OldValuesJson, this.strOldValuesJson);
                objIData.AddParameter(P_NewValuesJson, this.strNewValuesJson);
                objIData.AddParameter(P_IpAddress, this.strIpAddress);
                objIData.AddParameter(P_UserAgent, this.strUserAgent);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                this.lngAuditLogID = Convert.ToInt64(objIData.ExecStoreToString());
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm mới thông tin trong SYS_AuditLogs", objEx);
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
        /// Store: SYS_AuditLogs_EDIT
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_AuditLogID, this.lngAuditLogID);
                objIData.AddParameter(P_UserId, this.lngUserId);
                objIData.AddParameter(P_Action, this.strAction);
                objIData.AddParameter(P_Module, this.strModule);
                objIData.AddParameter(P_EntityName, this.strEntityName);
                objIData.AddParameter(P_EntityId, this.strEntityId);
                objIData.AddParameter(P_OldValuesJson, this.strOldValuesJson);
                objIData.AddParameter(P_NewValuesJson, this.strNewValuesJson);
                objIData.AddParameter(P_IpAddress, this.strIpAddress);
                objIData.AddParameter(P_UserAgent, this.strUserAgent);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong SYS_AuditLogs", objEx);
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
        /// Store: SYS_AuditLogs_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_AuditLogID, this.lngAuditLogID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong SYS_AuditLogs", objEx);
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
        /// Store: SYS_AuditLogs_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long lngAuditLogID)
        {
            this.lngAuditLogID = lngAuditLogID;
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

        public SYS_AuditLogs()
        {
        }
        public SYS_AuditLogs(long lngAuditLogID)
        {
            this.lngAuditLogID = lngAuditLogID;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "SYS_AuditLogs";
        public const string StoreGet = "SYS_AuditLogs_GET";
        public const string StoreGetAll = "SYS_AuditLogs_GETALL";
        public const string StoreSearch = "SYS_AuditLogs_SEARCH";
        public const string StoreAdd = "SYS_AuditLogs_ADD";
        public const string StoreEdit = "SYS_AuditLogs_EDIT";
        public const string StoreDelete = "SYS_AuditLogs_DELETE";

        #region Parameter Names

        public const String P_AuditLogID = "@" + C_AuditLogID;
        public const String P_UserId = "@" + C_UserId;
        public const String P_Action = "@" + C_Action;
        public const String P_Module = "@" + C_Module;
        public const String P_EntityName = "@" + C_EntityName;
        public const String P_EntityId = "@" + C_EntityId;
        public const String P_OldValuesJson = "@" + C_OldValuesJson;
        public const String P_NewValuesJson = "@" + C_NewValuesJson;
        public const String P_IpAddress = "@" + C_IpAddress;
        public const String P_UserAgent = "@" + C_UserAgent;
        public const String P_CreatedAt = "@" + C_CreatedAt;

        #endregion //Parameter names

        #region Column Names

        public const String C_AuditLogID = "AuditLogID";
        public const String C_UserId = "UserId";
        public const String C_Action = "Action";
        public const String C_Module = "Module";
        public const String C_EntityName = "EntityName";
        public const String C_EntityId = "EntityId";
        public const String C_OldValuesJson = "OldValuesJson";
        public const String C_NewValuesJson = "NewValuesJson";
        public const String C_IpAddress = "IpAddress";
        public const String C_UserAgent = "UserAgent";
        public const String C_CreatedAt = "CreatedAt";

        #endregion //Column names

        #endregion Variable Static
    }
}
