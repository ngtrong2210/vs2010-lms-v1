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
    /// [SIM] Quyền chia sẻ tài nguyên video cho giảng viên.
    /// </summary>
    public partial class SIM_VideoAssetShares
    {
        #region Member Variables

        private long lngVideoAssetShareID = 0;//Khóa chính tự tăng của lượt chia sẻ video.
        private long lngVideoAssetId = 0;//ID tài nguyên video được chia sẻ.
        private long lngTeacherUserID = 0;//ID giáo viên được quyền nhìn thấy và sử dụng video.
        private long lngSharedByUserID = 0;//ID tác giả hoặc quản trị viên thực hiện chia sẻ.
        private DateTime dtmSharedAt = DateTime.MinValue;//Thời điểm cấp quyền chia sẻ theo UTC.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// VideoAssetShareID
        /// Khóa chính tự tăng của lượt chia sẻ video.
        /// </summary>
        public long VideoAssetShareID
        {
            get { return lngVideoAssetShareID; }
            set { lngVideoAssetShareID = value; }
        }

        /// <summary>
        /// VideoAssetId
        /// ID tài nguyên video được chia sẻ.
        /// </summary>
        public long VideoAssetId
        {
            get { return lngVideoAssetId; }
            set { lngVideoAssetId = value; }
        }

        /// <summary>
        /// TeacherUserID
        /// ID giáo viên được quyền nhìn thấy và sử dụng video.
        /// </summary>
        public long TeacherUserID
        {
            get { return lngTeacherUserID; }
            set { lngTeacherUserID = value; }
        }

        /// <summary>
        /// SharedByUserID
        /// ID tác giả hoặc quản trị viên thực hiện chia sẻ.
        /// </summary>
        public long SharedByUserID
        {
            get { return lngSharedByUserID; }
            set { lngSharedByUserID = value; }
        }

        /// <summary>
        /// SharedAt
        /// Thời điểm cấp quyền chia sẻ theo UTC.
        /// </summary>
        public DateTime SharedAt
        {
            get { return dtmSharedAt; }
            set { dtmSharedAt = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_VideoAssetShareID.ToUpper()) && !Convert.IsDBNull(reader[C_VideoAssetShareID])) this.lngVideoAssetShareID = Convert.ToInt64(reader[C_VideoAssetShareID]);
                    if (reader.GetName(i).ToUpper().Equals(C_VideoAssetId.ToUpper()) && !Convert.IsDBNull(reader[C_VideoAssetId])) this.lngVideoAssetId = Convert.ToInt64(reader[C_VideoAssetId]);
                    if (reader.GetName(i).ToUpper().Equals(C_TeacherUserID.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherUserID])) this.lngTeacherUserID = Convert.ToInt64(reader[C_TeacherUserID]);
                    if (reader.GetName(i).ToUpper().Equals(C_SharedByUserID.ToUpper()) && !Convert.IsDBNull(reader[C_SharedByUserID])) this.lngSharedByUserID = Convert.ToInt64(reader[C_SharedByUserID]);
                    if (reader.GetName(i).ToUpper().Equals(C_SharedAt.ToUpper()) && !Convert.IsDBNull(reader[C_SharedAt])) this.dtmSharedAt = Convert.ToDateTime(reader[C_SharedAt]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_VideoAssetShares", objEx);
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
                if (!Convert.IsDBNull(drw[C_VideoAssetShareID])) this.lngVideoAssetShareID = Convert.ToInt64(drw[C_VideoAssetShareID]);
                if (!Convert.IsDBNull(drw[C_VideoAssetId])) this.lngVideoAssetId = Convert.ToInt64(drw[C_VideoAssetId]);
                if (!Convert.IsDBNull(drw[C_TeacherUserID])) this.lngTeacherUserID = Convert.ToInt64(drw[C_TeacherUserID]);
                if (!Convert.IsDBNull(drw[C_SharedByUserID])) this.lngSharedByUserID = Convert.ToInt64(drw[C_SharedByUserID]);
                if (!Convert.IsDBNull(drw[C_SharedAt])) this.dtmSharedAt = Convert.ToDateTime(drw[C_SharedAt]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_VideoAssetShares", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: SIM_VideoAssetShares_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_VideoAssetShareID, this.lngVideoAssetShareID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin SIM_VideoAssetShares", objEx);
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
        /// Store: SIM_VideoAssetShares_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public SIM_VideoAssetShares Get(long lngVideoAssetShareID)
        {
            SIM_VideoAssetShares obj = new SIM_VideoAssetShares();
            if (objIData != null) obj.IDB = objIData;
            obj.VideoAssetShareID = lngVideoAssetShareID;
            if (obj.Get()) return obj;
            this.objErrorException = obj.ErrorException;
            return null;
        }

        ///<summary>
        ///Thêm mới dữ liệu
        /// Store: SIM_VideoAssetShares_ADD
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreAdd);
                objIData.AddParameter(P_VideoAssetId, this.lngVideoAssetId);
                objIData.AddParameter(P_TeacherUserID, this.lngTeacherUserID);
                objIData.AddParameter(P_SharedByUserID, this.lngSharedByUserID);
                objIData.AddParameter(P_SharedAt, this.dtmSharedAt);
                this.lngVideoAssetShareID = Convert.ToInt64(objIData.ExecStoreToString());
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm mới thông tin trong SIM_VideoAssetShares", objEx);
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
        /// Store: SIM_VideoAssetShares_EDIT
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_VideoAssetShareID, this.lngVideoAssetShareID);
                objIData.AddParameter(P_VideoAssetId, this.lngVideoAssetId);
                objIData.AddParameter(P_TeacherUserID, this.lngTeacherUserID);
                objIData.AddParameter(P_SharedByUserID, this.lngSharedByUserID);
                objIData.AddParameter(P_SharedAt, this.dtmSharedAt);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong SIM_VideoAssetShares", objEx);
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
        /// Store: SIM_VideoAssetShares_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_VideoAssetShareID, this.lngVideoAssetShareID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong SIM_VideoAssetShares", objEx);
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
        /// Store: SIM_VideoAssetShares_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long lngVideoAssetShareID)
        {
            this.lngVideoAssetShareID = lngVideoAssetShareID;
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

        public SIM_VideoAssetShares()
        {
        }
        public SIM_VideoAssetShares(long lngVideoAssetShareID)
        {
            this.lngVideoAssetShareID = lngVideoAssetShareID;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "SIM_VideoAssetShares";
        public const string StoreGet = "SIM_VideoAssetShares_GET";
        public const string StoreGetAll = "SIM_VideoAssetShares_GETALL";
        public const string StoreSearch = "SIM_VideoAssetShares_SEARCH";
        public const string StoreAdd = "SIM_VideoAssetShares_ADD";
        public const string StoreEdit = "SIM_VideoAssetShares_EDIT";
        public const string StoreDelete = "SIM_VideoAssetShares_DELETE";

        #region Parameter Names

        public const String P_VideoAssetShareID = "@" + C_VideoAssetShareID;
        public const String P_VideoAssetId = "@" + C_VideoAssetId;
        public const String P_TeacherUserID = "@" + C_TeacherUserID;
        public const String P_SharedByUserID = "@" + C_SharedByUserID;
        public const String P_SharedAt = "@" + C_SharedAt;

        #endregion //Parameter names

        #region Column Names

        public const String C_VideoAssetShareID = "VideoAssetShareID";
        public const String C_VideoAssetId = "VideoAssetId";
        public const String C_TeacherUserID = "TeacherUserID";
        public const String C_SharedByUserID = "SharedByUserID";
        public const String C_SharedAt = "SharedAt";

        #endregion //Column names

        #endregion Variable Static
    }
}
