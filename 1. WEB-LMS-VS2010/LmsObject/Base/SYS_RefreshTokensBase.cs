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
    /// [SYS] Refresh token phục vụ xác thực và gia hạn phiên.
    /// </summary>
    public partial class SYS_RefreshTokens
    {
        #region Member Variables

        private long lngRefreshTokenID = 0;//Khóa chính tự tăng của refresh token.
        private long lngUserId = 0;//ID người dùng sở hữu refresh token.
        private string strTokenHash = null;//Giá trị refresh token đã được băm.
        private DateTime dtmExpiresAt = DateTime.MinValue;//Thời điểm refresh token hết hạn theo UTC.
        private DateTime dtmCreatedAt = DateTime.MinValue;//Thời điểm phát hành refresh token theo UTC.
        private DateTime? dtmRevokedAt = null;//Thời điểm refresh token bị thu hồi theo UTC.
        private string strCreatedIp = null;//Địa chỉ IP yêu cầu phát hành refresh token.
        private string strRevokedIp = null;//Địa chỉ IP thực hiện thu hồi refresh token.
        private bool bolIsRevoked = false;//Cờ cho biết refresh token đã bị thu hồi hay chưa.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// RefreshTokenID
        /// Khóa chính tự tăng của refresh token.
        /// </summary>
        public long RefreshTokenID
        {
            get { return lngRefreshTokenID; }
            set { lngRefreshTokenID = value; }
        }

        /// <summary>
        /// UserId
        /// ID người dùng sở hữu refresh token.
        /// </summary>
        public long UserId
        {
            get { return lngUserId; }
            set { lngUserId = value; }
        }

        /// <summary>
        /// TokenHash
        /// Giá trị refresh token đã được băm.
        /// </summary>
        public string TokenHash
        {
            get { return strTokenHash; }
            set { strTokenHash = value; }
        }

        /// <summary>
        /// ExpiresAt
        /// Thời điểm refresh token hết hạn theo UTC.
        /// </summary>
        public DateTime ExpiresAt
        {
            get { return dtmExpiresAt; }
            set { dtmExpiresAt = value; }
        }

        /// <summary>
        /// CreatedAt
        /// Thời điểm phát hành refresh token theo UTC.
        /// </summary>
        public DateTime CreatedAt
        {
            get { return dtmCreatedAt; }
            set { dtmCreatedAt = value; }
        }

        /// <summary>
        /// RevokedAt
        /// Thời điểm refresh token bị thu hồi theo UTC.
        /// </summary>
        public DateTime? RevokedAt
        {
            get { return dtmRevokedAt; }
            set { dtmRevokedAt = value; }
        }

        /// <summary>
        /// CreatedIp
        /// Địa chỉ IP yêu cầu phát hành refresh token.
        /// </summary>
        public string CreatedIp
        {
            get { return strCreatedIp; }
            set { strCreatedIp = value; }
        }

        /// <summary>
        /// RevokedIp
        /// Địa chỉ IP thực hiện thu hồi refresh token.
        /// </summary>
        public string RevokedIp
        {
            get { return strRevokedIp; }
            set { strRevokedIp = value; }
        }

        /// <summary>
        /// IsRevoked
        /// Cờ cho biết refresh token đã bị thu hồi hay chưa.
        /// </summary>
        public bool IsRevoked
        {
            get { return bolIsRevoked; }
            set { bolIsRevoked = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_RefreshTokenID.ToUpper()) && !Convert.IsDBNull(reader[C_RefreshTokenID])) this.lngRefreshTokenID = Convert.ToInt64(reader[C_RefreshTokenID]);
                    if (reader.GetName(i).ToUpper().Equals(C_UserId.ToUpper()) && !Convert.IsDBNull(reader[C_UserId])) this.lngUserId = Convert.ToInt64(reader[C_UserId]);
                    if (reader.GetName(i).ToUpper().Equals(C_TokenHash.ToUpper()) && !Convert.IsDBNull(reader[C_TokenHash])) this.strTokenHash = Convert.ToString(reader[C_TokenHash]);
                    if (reader.GetName(i).ToUpper().Equals(C_ExpiresAt.ToUpper()) && !Convert.IsDBNull(reader[C_ExpiresAt])) this.dtmExpiresAt = Convert.ToDateTime(reader[C_ExpiresAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(reader[C_CreatedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_RevokedAt.ToUpper()) && !Convert.IsDBNull(reader[C_RevokedAt])) this.dtmRevokedAt = Convert.ToDateTime(reader[C_RevokedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedIp.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedIp])) this.strCreatedIp = Convert.ToString(reader[C_CreatedIp]);
                    if (reader.GetName(i).ToUpper().Equals(C_RevokedIp.ToUpper()) && !Convert.IsDBNull(reader[C_RevokedIp])) this.strRevokedIp = Convert.ToString(reader[C_RevokedIp]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsRevoked.ToUpper()) && !Convert.IsDBNull(reader[C_IsRevoked])) this.bolIsRevoked = Convert.ToBoolean(reader[C_IsRevoked]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SYS_RefreshTokens", objEx);
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
                if (!Convert.IsDBNull(drw[C_RefreshTokenID])) this.lngRefreshTokenID = Convert.ToInt64(drw[C_RefreshTokenID]);
                if (!Convert.IsDBNull(drw[C_UserId])) this.lngUserId = Convert.ToInt64(drw[C_UserId]);
                if (!Convert.IsDBNull(drw[C_TokenHash])) this.strTokenHash = Convert.ToString(drw[C_TokenHash]);
                if (!Convert.IsDBNull(drw[C_ExpiresAt])) this.dtmExpiresAt = Convert.ToDateTime(drw[C_ExpiresAt]);
                if (!Convert.IsDBNull(drw[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(drw[C_CreatedAt]);
                if (!Convert.IsDBNull(drw[C_RevokedAt])) this.dtmRevokedAt = Convert.ToDateTime(drw[C_RevokedAt]);
                if (!Convert.IsDBNull(drw[C_CreatedIp])) this.strCreatedIp = Convert.ToString(drw[C_CreatedIp]);
                if (!Convert.IsDBNull(drw[C_RevokedIp])) this.strRevokedIp = Convert.ToString(drw[C_RevokedIp]);
                if (!Convert.IsDBNull(drw[C_IsRevoked])) this.bolIsRevoked = Convert.ToBoolean(drw[C_IsRevoked]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SYS_RefreshTokens", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: SYS_RefreshTokens_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_RefreshTokenID, this.lngRefreshTokenID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin SYS_RefreshTokens", objEx);
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
        /// Store: SYS_RefreshTokens_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public SYS_RefreshTokens Get(long lngRefreshTokenID)
        {
            SYS_RefreshTokens obj = new SYS_RefreshTokens();
            if (objIData != null) obj.IDB = objIData;
            obj.RefreshTokenID = lngRefreshTokenID;
            if (obj.Get()) return obj;
            this.objErrorException = obj.ErrorException;
            return null;
        }

        ///<summary>
        ///Thêm mới dữ liệu
        /// Store: SYS_RefreshTokens_ADD
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
                objIData.AddParameter(P_TokenHash, this.strTokenHash);
                objIData.AddParameter(P_ExpiresAt, this.dtmExpiresAt);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_RevokedAt, this.dtmRevokedAt);
                objIData.AddParameter(P_CreatedIp, this.strCreatedIp);
                objIData.AddParameter(P_RevokedIp, this.strRevokedIp);
                objIData.AddParameter(P_IsRevoked, this.bolIsRevoked);
                this.lngRefreshTokenID = Convert.ToInt64(objIData.ExecStoreToString());
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm mới thông tin trong SYS_RefreshTokens", objEx);
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
        /// Store: SYS_RefreshTokens_EDIT
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_RefreshTokenID, this.lngRefreshTokenID);
                objIData.AddParameter(P_UserId, this.lngUserId);
                objIData.AddParameter(P_TokenHash, this.strTokenHash);
                objIData.AddParameter(P_ExpiresAt, this.dtmExpiresAt);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_RevokedAt, this.dtmRevokedAt);
                objIData.AddParameter(P_CreatedIp, this.strCreatedIp);
                objIData.AddParameter(P_RevokedIp, this.strRevokedIp);
                objIData.AddParameter(P_IsRevoked, this.bolIsRevoked);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong SYS_RefreshTokens", objEx);
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
        /// Store: SYS_RefreshTokens_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_RefreshTokenID, this.lngRefreshTokenID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong SYS_RefreshTokens", objEx);
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
        /// Store: SYS_RefreshTokens_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long lngRefreshTokenID)
        {
            this.lngRefreshTokenID = lngRefreshTokenID;
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

        public SYS_RefreshTokens()
        {
        }
        public SYS_RefreshTokens(long lngRefreshTokenID)
        {
            this.lngRefreshTokenID = lngRefreshTokenID;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "SYS_RefreshTokens";
        public const string StoreGet = "SYS_RefreshTokens_GET";
        public const string StoreGetAll = "SYS_RefreshTokens_GETALL";
        public const string StoreSearch = "SYS_RefreshTokens_SEARCH";
        public const string StoreAdd = "SYS_RefreshTokens_ADD";
        public const string StoreEdit = "SYS_RefreshTokens_EDIT";
        public const string StoreDelete = "SYS_RefreshTokens_DELETE";

        #region Parameter Names

        public const String P_RefreshTokenID = "@" + C_RefreshTokenID;
        public const String P_UserId = "@" + C_UserId;
        public const String P_TokenHash = "@" + C_TokenHash;
        public const String P_ExpiresAt = "@" + C_ExpiresAt;
        public const String P_CreatedAt = "@" + C_CreatedAt;
        public const String P_RevokedAt = "@" + C_RevokedAt;
        public const String P_CreatedIp = "@" + C_CreatedIp;
        public const String P_RevokedIp = "@" + C_RevokedIp;
        public const String P_IsRevoked = "@" + C_IsRevoked;

        #endregion //Parameter names

        #region Column Names

        public const String C_RefreshTokenID = "RefreshTokenID";
        public const String C_UserId = "UserId";
        public const String C_TokenHash = "TokenHash";
        public const String C_ExpiresAt = "ExpiresAt";
        public const String C_CreatedAt = "CreatedAt";
        public const String C_RevokedAt = "RevokedAt";
        public const String C_CreatedIp = "CreatedIp";
        public const String C_RevokedIp = "RevokedIp";
        public const String C_IsRevoked = "IsRevoked";

        #endregion //Column names

        #endregion Variable Static
    }
}
