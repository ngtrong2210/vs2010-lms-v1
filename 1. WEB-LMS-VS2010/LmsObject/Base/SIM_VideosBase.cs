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
    /// [SIM] Video tương tác độc lập đã soạn sẵn, có thể được nhiều bài học tham chiếu mà không nhân bản.
    /// </summary>
    public partial class SIM_Videos
    {
        #region Member Variables

        private long lngVideoID = 0;//Khóa chính tự tăng của cấu hình video bài học.
        private string strTitle = null;//Tên hiển thị của video trong bài học.
        private string strVideoUrl = null;//Đường dẫn phát video; giữ để tương thích dữ liệu cũ.
        private string strPosterUrl = null;//Đường dẫn ảnh đại diện của video.
        private int intDurationSeconds = 0;//Thời lượng video tính bằng giây.
        private bool bolAllowSeek = false;//Cờ cho phép học viên tua đến vị trí chưa xem.
        private bool bolAllowSpeed = false;//Cờ cho phép học viên thay đổi tốc độ phát.
        private decimal decRequiredWatchPercent = 0;//Tỷ lệ phần trăm video phải xem để được tính hoàn thành.
        private string strStatus = null;//Trạng thái sử dụng của video.
        private DateTime dtmCreatedAt = DateTime.MinValue;//Thời điểm tạo cấu hình video theo UTC.
        private DateTime? dtmUpdatedAt = null;//Thời điểm cập nhật cấu hình video gần nhất theo UTC.
        private long? lngVideoAssetId = null;//ID tệp trong thư viện video được bài học sử dụng.
        private long? lngCurrentVideoVersionID = null;//ID phiên bản mới nhất dùng cho lần gắn video tiếp theo và màn hình biên tập.
        private string strSourceType = null;//Loại nguồn phát hiện tại của video tương tác: LOCAL hoặc YOUTUBE.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// VideoID
        /// Khóa chính tự tăng của cấu hình video bài học.
        /// </summary>
        public long VideoID
        {
            get { return lngVideoID; }
            set { lngVideoID = value; }
        }

        /// <summary>
        /// Title
        /// Tên hiển thị của video trong bài học.
        /// </summary>
        public string Title
        {
            get { return strTitle; }
            set { strTitle = value; }
        }

        /// <summary>
        /// VideoUrl
        /// Đường dẫn phát video; giữ để tương thích dữ liệu cũ.
        /// </summary>
        public string VideoUrl
        {
            get { return strVideoUrl; }
            set { strVideoUrl = value; }
        }

        /// <summary>
        /// PosterUrl
        /// Đường dẫn ảnh đại diện của video.
        /// </summary>
        public string PosterUrl
        {
            get { return strPosterUrl; }
            set { strPosterUrl = value; }
        }

        /// <summary>
        /// DurationSeconds
        /// Thời lượng video tính bằng giây.
        /// </summary>
        public int DurationSeconds
        {
            get { return intDurationSeconds; }
            set { intDurationSeconds = value; }
        }

        /// <summary>
        /// AllowSeek
        /// Cờ cho phép học viên tua đến vị trí chưa xem.
        /// </summary>
        public bool AllowSeek
        {
            get { return bolAllowSeek; }
            set { bolAllowSeek = value; }
        }

        /// <summary>
        /// AllowSpeed
        /// Cờ cho phép học viên thay đổi tốc độ phát.
        /// </summary>
        public bool AllowSpeed
        {
            get { return bolAllowSpeed; }
            set { bolAllowSpeed = value; }
        }

        /// <summary>
        /// RequiredWatchPercent
        /// Tỷ lệ phần trăm video phải xem để được tính hoàn thành.
        /// </summary>
        public decimal RequiredWatchPercent
        {
            get { return decRequiredWatchPercent; }
            set { decRequiredWatchPercent = value; }
        }

        /// <summary>
        /// Status
        /// Trạng thái sử dụng của video.
        /// </summary>
        public string Status
        {
            get { return strStatus; }
            set { strStatus = value; }
        }

        /// <summary>
        /// CreatedAt
        /// Thời điểm tạo cấu hình video theo UTC.
        /// </summary>
        public DateTime CreatedAt
        {
            get { return dtmCreatedAt; }
            set { dtmCreatedAt = value; }
        }

        /// <summary>
        /// UpdatedAt
        /// Thời điểm cập nhật cấu hình video gần nhất theo UTC.
        /// </summary>
        public DateTime? UpdatedAt
        {
            get { return dtmUpdatedAt; }
            set { dtmUpdatedAt = value; }
        }

        /// <summary>
        /// VideoAssetId
        /// ID tệp trong thư viện video được bài học sử dụng.
        /// </summary>
        public long? VideoAssetId
        {
            get { return lngVideoAssetId; }
            set { lngVideoAssetId = value; }
        }

        /// <summary>
        /// CurrentVideoVersionID
        /// ID phiên bản mới nhất dùng cho lần gắn video tiếp theo và màn hình biên tập.
        /// </summary>
        public long? CurrentVideoVersionID
        {
            get { return lngCurrentVideoVersionID; }
            set { lngCurrentVideoVersionID = value; }
        }

        /// <summary>
        /// SourceType
        /// Loại nguồn phát hiện tại của video tương tác: LOCAL hoặc YOUTUBE.
        /// </summary>
        public string SourceType
        {
            get { return strSourceType; }
            set { strSourceType = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_VideoID.ToUpper()) && !Convert.IsDBNull(reader[C_VideoID])) this.lngVideoID = Convert.ToInt64(reader[C_VideoID]);
                    if (reader.GetName(i).ToUpper().Equals(C_Title.ToUpper()) && !Convert.IsDBNull(reader[C_Title])) this.strTitle = Convert.ToString(reader[C_Title]);
                    if (reader.GetName(i).ToUpper().Equals(C_VideoUrl.ToUpper()) && !Convert.IsDBNull(reader[C_VideoUrl])) this.strVideoUrl = Convert.ToString(reader[C_VideoUrl]);
                    if (reader.GetName(i).ToUpper().Equals(C_PosterUrl.ToUpper()) && !Convert.IsDBNull(reader[C_PosterUrl])) this.strPosterUrl = Convert.ToString(reader[C_PosterUrl]);
                    if (reader.GetName(i).ToUpper().Equals(C_DurationSeconds.ToUpper()) && !Convert.IsDBNull(reader[C_DurationSeconds])) this.intDurationSeconds = Convert.ToInt32(reader[C_DurationSeconds]);
                    if (reader.GetName(i).ToUpper().Equals(C_AllowSeek.ToUpper()) && !Convert.IsDBNull(reader[C_AllowSeek])) this.bolAllowSeek = Convert.ToBoolean(reader[C_AllowSeek]);
                    if (reader.GetName(i).ToUpper().Equals(C_AllowSpeed.ToUpper()) && !Convert.IsDBNull(reader[C_AllowSpeed])) this.bolAllowSpeed = Convert.ToBoolean(reader[C_AllowSpeed]);
                    if (reader.GetName(i).ToUpper().Equals(C_RequiredWatchPercent.ToUpper()) && !Convert.IsDBNull(reader[C_RequiredWatchPercent])) this.decRequiredWatchPercent = Convert.ToDecimal(reader[C_RequiredWatchPercent]);
                    if (reader.GetName(i).ToUpper().Equals(C_Status.ToUpper()) && !Convert.IsDBNull(reader[C_Status])) this.strStatus = Convert.ToString(reader[C_Status]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(reader[C_CreatedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedAt])) this.dtmUpdatedAt = Convert.ToDateTime(reader[C_UpdatedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_VideoAssetId.ToUpper()) && !Convert.IsDBNull(reader[C_VideoAssetId])) this.lngVideoAssetId = Convert.ToInt64(reader[C_VideoAssetId]);
                    if (reader.GetName(i).ToUpper().Equals(C_CurrentVideoVersionID.ToUpper()) && !Convert.IsDBNull(reader[C_CurrentVideoVersionID])) this.lngCurrentVideoVersionID = Convert.ToInt64(reader[C_CurrentVideoVersionID]);
                    if (reader.GetName(i).ToUpper().Equals(C_SourceType.ToUpper()) && !Convert.IsDBNull(reader[C_SourceType])) this.strSourceType = Convert.ToString(reader[C_SourceType]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_Videos", objEx);
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
                if (!Convert.IsDBNull(drw[C_VideoID])) this.lngVideoID = Convert.ToInt64(drw[C_VideoID]);
                if (!Convert.IsDBNull(drw[C_Title])) this.strTitle = Convert.ToString(drw[C_Title]);
                if (!Convert.IsDBNull(drw[C_VideoUrl])) this.strVideoUrl = Convert.ToString(drw[C_VideoUrl]);
                if (!Convert.IsDBNull(drw[C_PosterUrl])) this.strPosterUrl = Convert.ToString(drw[C_PosterUrl]);
                if (!Convert.IsDBNull(drw[C_DurationSeconds])) this.intDurationSeconds = Convert.ToInt32(drw[C_DurationSeconds]);
                if (!Convert.IsDBNull(drw[C_AllowSeek])) this.bolAllowSeek = Convert.ToBoolean(drw[C_AllowSeek]);
                if (!Convert.IsDBNull(drw[C_AllowSpeed])) this.bolAllowSpeed = Convert.ToBoolean(drw[C_AllowSpeed]);
                if (!Convert.IsDBNull(drw[C_RequiredWatchPercent])) this.decRequiredWatchPercent = Convert.ToDecimal(drw[C_RequiredWatchPercent]);
                if (!Convert.IsDBNull(drw[C_Status])) this.strStatus = Convert.ToString(drw[C_Status]);
                if (!Convert.IsDBNull(drw[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(drw[C_CreatedAt]);
                if (!Convert.IsDBNull(drw[C_UpdatedAt])) this.dtmUpdatedAt = Convert.ToDateTime(drw[C_UpdatedAt]);
                if (!Convert.IsDBNull(drw[C_VideoAssetId])) this.lngVideoAssetId = Convert.ToInt64(drw[C_VideoAssetId]);
                if (!Convert.IsDBNull(drw[C_CurrentVideoVersionID])) this.lngCurrentVideoVersionID = Convert.ToInt64(drw[C_CurrentVideoVersionID]);
                if (!Convert.IsDBNull(drw[C_SourceType])) this.strSourceType = Convert.ToString(drw[C_SourceType]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_Videos", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: SIM_Videos_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_VideoID, this.lngVideoID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin SIM_Videos", objEx);
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
        /// Store: SIM_Videos_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get(long lngVideoID)
        {
            this.lngVideoID = lngVideoID;
            return this.Get();
        }

        ///<summary>
        ///Thêm mới dữ liệu
        /// Store: SIM_Videos_ADD
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreAdd);
                objIData.AddParameter(P_Title, this.strTitle);
                objIData.AddParameter(P_VideoUrl, this.strVideoUrl);
                objIData.AddParameter(P_PosterUrl, this.strPosterUrl);
                objIData.AddParameter(P_DurationSeconds, this.intDurationSeconds);
                objIData.AddParameter(P_AllowSeek, this.bolAllowSeek);
                objIData.AddParameter(P_AllowSpeed, this.bolAllowSpeed);
                objIData.AddParameter(P_RequiredWatchPercent, this.decRequiredWatchPercent);
                objIData.AddParameter(P_Status, this.strStatus);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_UpdatedAt, this.dtmUpdatedAt);
                objIData.AddParameter(P_VideoAssetId, this.lngVideoAssetId);
                objIData.AddParameter(P_CurrentVideoVersionID, this.lngCurrentVideoVersionID);
                objIData.AddParameter(P_SourceType, this.strSourceType);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm mới thông tin trong SIM_Videos", objEx);
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
        /// Store: SIM_Videos_EDIT
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_VideoID, this.lngVideoID);
                objIData.AddParameter(P_Title, this.strTitle);
                objIData.AddParameter(P_VideoUrl, this.strVideoUrl);
                objIData.AddParameter(P_PosterUrl, this.strPosterUrl);
                objIData.AddParameter(P_DurationSeconds, this.intDurationSeconds);
                objIData.AddParameter(P_AllowSeek, this.bolAllowSeek);
                objIData.AddParameter(P_AllowSpeed, this.bolAllowSpeed);
                objIData.AddParameter(P_RequiredWatchPercent, this.decRequiredWatchPercent);
                objIData.AddParameter(P_Status, this.strStatus);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_UpdatedAt, this.dtmUpdatedAt);
                objIData.AddParameter(P_VideoAssetId, this.lngVideoAssetId);
                objIData.AddParameter(P_CurrentVideoVersionID, this.lngCurrentVideoVersionID);
                objIData.AddParameter(P_SourceType, this.strSourceType);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong SIM_Videos", objEx);
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
        /// Store: SIM_Videos_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_VideoID, this.lngVideoID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong SIM_Videos", objEx);
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
        /// Store: SIM_Videos_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long lngVideoID)
        {
            this.lngVideoID = lngVideoID;
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

        public SIM_Videos()
        {
        }
        public SIM_Videos(long lngVideoID)
        {
            this.lngVideoID = lngVideoID;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "SIM_Videos";
        public const string StoreGet = "SIM_Videos_GET";
        public const string StoreGetAll = "SIM_Videos_GETALL";
        public const string StoreSearch = "SIM_Videos_SEARCH";
        public const string StoreAdd = "SIM_Videos_ADD";
        public const string StoreEdit = "SIM_Videos_EDIT";
        public const string StoreDelete = "SIM_Videos_DELETE";

        #region Parameter Names

        public const String P_VideoID = "@" + C_VideoID;
        public const String P_Title = "@" + C_Title;
        public const String P_VideoUrl = "@" + C_VideoUrl;
        public const String P_PosterUrl = "@" + C_PosterUrl;
        public const String P_DurationSeconds = "@" + C_DurationSeconds;
        public const String P_AllowSeek = "@" + C_AllowSeek;
        public const String P_AllowSpeed = "@" + C_AllowSpeed;
        public const String P_RequiredWatchPercent = "@" + C_RequiredWatchPercent;
        public const String P_Status = "@" + C_Status;
        public const String P_CreatedAt = "@" + C_CreatedAt;
        public const String P_UpdatedAt = "@" + C_UpdatedAt;
        public const String P_VideoAssetId = "@" + C_VideoAssetId;
        public const String P_CurrentVideoVersionID = "@" + C_CurrentVideoVersionID;
        public const String P_SourceType = "@" + C_SourceType;

        #endregion //Parameter names

        #region Column Names

        public const String C_VideoID = "VideoID";
        public const String C_Title = "Title";
        public const String C_VideoUrl = "VideoUrl";
        public const String C_PosterUrl = "PosterUrl";
        public const String C_DurationSeconds = "DurationSeconds";
        public const String C_AllowSeek = "AllowSeek";
        public const String C_AllowSpeed = "AllowSpeed";
        public const String C_RequiredWatchPercent = "RequiredWatchPercent";
        public const String C_Status = "Status";
        public const String C_CreatedAt = "CreatedAt";
        public const String C_UpdatedAt = "UpdatedAt";
        public const String C_VideoAssetId = "VideoAssetId";
        public const String C_CurrentVideoVersionID = "CurrentVideoVersionID";
        public const String C_SourceType = "SourceType";

        #endregion //Column names

        #endregion Variable Static
    }
}
