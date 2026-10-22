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
    /// [SIM] Lịch sử phiên bản bất biến của video; bài học ghim một phiên bản cụ thể để tránh thay đổi nội dung ngoài ý muốn.
    /// </summary>
    public partial class SIM_VideoVersions
    {
        #region Member Variables

        private long lngVideoVersionID = 0;//Khóa chính tự tăng của phiên bản video.
        private long lngVideoID = 0;//ID video gốc sở hữu phiên bản.
        private int intVersionNumber = 0;//Số phiên bản tăng dần trong phạm vi một video.
        private string strTitle = null;//Tên video được chụp tại thời điểm tạo phiên bản.
        private string strVideoUrl = null;//Đường dẫn file video tương đối trong project của phiên bản.
        private string strPosterUrl = null;//Đường dẫn ảnh đại diện của phiên bản video.
        private int intDurationSeconds = 0;//Thời lượng của file thuộc phiên bản, tính bằng giây.
        private bool bolAllowSeek = false;//Cho phép học viên tua video trong phiên bản.
        private bool bolAllowSpeed = false;//Cho phép học viên thay đổi tốc độ phát.
        private decimal decRequiredWatchPercent = 0;//Tỷ lệ xem tối thiểu để hoàn thành phiên bản video.
        private string strOriginalFileName = null;//Tên gốc của file video khi được tải lên.
        private long? lngFileSize = null;//Kích thước file của phiên bản video, tính bằng byte.
        private string strMimeType = null;//Kiểu MIME của file video thuộc phiên bản.
        private string strChangeSummary = null;//Nội dung mô tả lý do tạo phiên bản mới.
        private string strVersionStatus = null;//Trạng thái phiên bản: DRAFT, PUBLISHED hoặc ARCHIVED.
        private long lngCreatedByUserID = 0;//ID người dùng tạo phiên bản.
        private DateTime dtmCreatedAt = DateTime.MinValue;//Thời điểm tạo phiên bản theo UTC.
        private long? lngPublishedByUserID = null;//ID người dùng xuất bản phiên bản.
        private DateTime? dtmPublishedAt = null;//Thời điểm xuất bản phiên bản theo UTC.
        private byte[] bytRowVersion = null;//Dấu phiên bản hàng do SQL Server quản lý để kiểm soát đồng thời.
        private string strSourceType = null;//Loại nguồn được chụp tại phiên bản video: LOCAL hoặc YOUTUBE.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// VideoVersionID
        /// Khóa chính tự tăng của phiên bản video.
        /// </summary>
        public long VideoVersionID
        {
            get { return lngVideoVersionID; }
            set { lngVideoVersionID = value; }
        }

        /// <summary>
        /// VideoID
        /// ID video gốc sở hữu phiên bản.
        /// </summary>
        public long VideoID
        {
            get { return lngVideoID; }
            set { lngVideoID = value; }
        }

        /// <summary>
        /// VersionNumber
        /// Số phiên bản tăng dần trong phạm vi một video.
        /// </summary>
        public int VersionNumber
        {
            get { return intVersionNumber; }
            set { intVersionNumber = value; }
        }

        /// <summary>
        /// Title
        /// Tên video được chụp tại thời điểm tạo phiên bản.
        /// </summary>
        public string Title
        {
            get { return strTitle; }
            set { strTitle = value; }
        }

        /// <summary>
        /// VideoUrl
        /// Đường dẫn file video tương đối trong project của phiên bản.
        /// </summary>
        public string VideoUrl
        {
            get { return strVideoUrl; }
            set { strVideoUrl = value; }
        }

        /// <summary>
        /// PosterUrl
        /// Đường dẫn ảnh đại diện của phiên bản video.
        /// </summary>
        public string PosterUrl
        {
            get { return strPosterUrl; }
            set { strPosterUrl = value; }
        }

        /// <summary>
        /// DurationSeconds
        /// Thời lượng của file thuộc phiên bản, tính bằng giây.
        /// </summary>
        public int DurationSeconds
        {
            get { return intDurationSeconds; }
            set { intDurationSeconds = value; }
        }

        /// <summary>
        /// AllowSeek
        /// Cho phép học viên tua video trong phiên bản.
        /// </summary>
        public bool AllowSeek
        {
            get { return bolAllowSeek; }
            set { bolAllowSeek = value; }
        }

        /// <summary>
        /// AllowSpeed
        /// Cho phép học viên thay đổi tốc độ phát.
        /// </summary>
        public bool AllowSpeed
        {
            get { return bolAllowSpeed; }
            set { bolAllowSpeed = value; }
        }

        /// <summary>
        /// RequiredWatchPercent
        /// Tỷ lệ xem tối thiểu để hoàn thành phiên bản video.
        /// </summary>
        public decimal RequiredWatchPercent
        {
            get { return decRequiredWatchPercent; }
            set { decRequiredWatchPercent = value; }
        }

        /// <summary>
        /// OriginalFileName
        /// Tên gốc của file video khi được tải lên.
        /// </summary>
        public string OriginalFileName
        {
            get { return strOriginalFileName; }
            set { strOriginalFileName = value; }
        }

        /// <summary>
        /// FileSize
        /// Kích thước file của phiên bản video, tính bằng byte.
        /// </summary>
        public long? FileSize
        {
            get { return lngFileSize; }
            set { lngFileSize = value; }
        }

        /// <summary>
        /// MimeType
        /// Kiểu MIME của file video thuộc phiên bản.
        /// </summary>
        public string MimeType
        {
            get { return strMimeType; }
            set { strMimeType = value; }
        }

        /// <summary>
        /// ChangeSummary
        /// Nội dung mô tả lý do tạo phiên bản mới.
        /// </summary>
        public string ChangeSummary
        {
            get { return strChangeSummary; }
            set { strChangeSummary = value; }
        }

        /// <summary>
        /// VersionStatus
        /// Trạng thái phiên bản: DRAFT, PUBLISHED hoặc ARCHIVED.
        /// </summary>
        public string VersionStatus
        {
            get { return strVersionStatus; }
            set { strVersionStatus = value; }
        }

        /// <summary>
        /// CreatedByUserID
        /// ID người dùng tạo phiên bản.
        /// </summary>
        public long CreatedByUserID
        {
            get { return lngCreatedByUserID; }
            set { lngCreatedByUserID = value; }
        }

        /// <summary>
        /// CreatedAt
        /// Thời điểm tạo phiên bản theo UTC.
        /// </summary>
        public DateTime CreatedAt
        {
            get { return dtmCreatedAt; }
            set { dtmCreatedAt = value; }
        }

        /// <summary>
        /// PublishedByUserID
        /// ID người dùng xuất bản phiên bản.
        /// </summary>
        public long? PublishedByUserID
        {
            get { return lngPublishedByUserID; }
            set { lngPublishedByUserID = value; }
        }

        /// <summary>
        /// PublishedAt
        /// Thời điểm xuất bản phiên bản theo UTC.
        /// </summary>
        public DateTime? PublishedAt
        {
            get { return dtmPublishedAt; }
            set { dtmPublishedAt = value; }
        }

        /// <summary>
        /// RowVersion
        /// Dấu phiên bản hàng do SQL Server quản lý để kiểm soát đồng thời.
        /// </summary>
        public byte[] RowVersion
        {
            get { return bytRowVersion; }
            set { bytRowVersion = value; }
        }

        /// <summary>
        /// SourceType
        /// Loại nguồn được chụp tại phiên bản video: LOCAL hoặc YOUTUBE.
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
                    if (reader.GetName(i).ToUpper().Equals(C_VideoVersionID.ToUpper()) && !Convert.IsDBNull(reader[C_VideoVersionID])) this.lngVideoVersionID = Convert.ToInt64(reader[C_VideoVersionID]);
                    if (reader.GetName(i).ToUpper().Equals(C_VideoID.ToUpper()) && !Convert.IsDBNull(reader[C_VideoID])) this.lngVideoID = Convert.ToInt64(reader[C_VideoID]);
                    if (reader.GetName(i).ToUpper().Equals(C_VersionNumber.ToUpper()) && !Convert.IsDBNull(reader[C_VersionNumber])) this.intVersionNumber = Convert.ToInt32(reader[C_VersionNumber]);
                    if (reader.GetName(i).ToUpper().Equals(C_Title.ToUpper()) && !Convert.IsDBNull(reader[C_Title])) this.strTitle = Convert.ToString(reader[C_Title]);
                    if (reader.GetName(i).ToUpper().Equals(C_VideoUrl.ToUpper()) && !Convert.IsDBNull(reader[C_VideoUrl])) this.strVideoUrl = Convert.ToString(reader[C_VideoUrl]);
                    if (reader.GetName(i).ToUpper().Equals(C_PosterUrl.ToUpper()) && !Convert.IsDBNull(reader[C_PosterUrl])) this.strPosterUrl = Convert.ToString(reader[C_PosterUrl]);
                    if (reader.GetName(i).ToUpper().Equals(C_DurationSeconds.ToUpper()) && !Convert.IsDBNull(reader[C_DurationSeconds])) this.intDurationSeconds = Convert.ToInt32(reader[C_DurationSeconds]);
                    if (reader.GetName(i).ToUpper().Equals(C_AllowSeek.ToUpper()) && !Convert.IsDBNull(reader[C_AllowSeek])) this.bolAllowSeek = Convert.ToBoolean(reader[C_AllowSeek]);
                    if (reader.GetName(i).ToUpper().Equals(C_AllowSpeed.ToUpper()) && !Convert.IsDBNull(reader[C_AllowSpeed])) this.bolAllowSpeed = Convert.ToBoolean(reader[C_AllowSpeed]);
                    if (reader.GetName(i).ToUpper().Equals(C_RequiredWatchPercent.ToUpper()) && !Convert.IsDBNull(reader[C_RequiredWatchPercent])) this.decRequiredWatchPercent = Convert.ToDecimal(reader[C_RequiredWatchPercent]);
                    if (reader.GetName(i).ToUpper().Equals(C_OriginalFileName.ToUpper()) && !Convert.IsDBNull(reader[C_OriginalFileName])) this.strOriginalFileName = Convert.ToString(reader[C_OriginalFileName]);
                    if (reader.GetName(i).ToUpper().Equals(C_FileSize.ToUpper()) && !Convert.IsDBNull(reader[C_FileSize])) this.lngFileSize = Convert.ToInt64(reader[C_FileSize]);
                    if (reader.GetName(i).ToUpper().Equals(C_MimeType.ToUpper()) && !Convert.IsDBNull(reader[C_MimeType])) this.strMimeType = Convert.ToString(reader[C_MimeType]);
                    if (reader.GetName(i).ToUpper().Equals(C_ChangeSummary.ToUpper()) && !Convert.IsDBNull(reader[C_ChangeSummary])) this.strChangeSummary = Convert.ToString(reader[C_ChangeSummary]);
                    if (reader.GetName(i).ToUpper().Equals(C_VersionStatus.ToUpper()) && !Convert.IsDBNull(reader[C_VersionStatus])) this.strVersionStatus = Convert.ToString(reader[C_VersionStatus]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedByUserID.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedByUserID])) this.lngCreatedByUserID = Convert.ToInt64(reader[C_CreatedByUserID]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(reader[C_CreatedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_PublishedByUserID.ToUpper()) && !Convert.IsDBNull(reader[C_PublishedByUserID])) this.lngPublishedByUserID = Convert.ToInt64(reader[C_PublishedByUserID]);
                    if (reader.GetName(i).ToUpper().Equals(C_PublishedAt.ToUpper()) && !Convert.IsDBNull(reader[C_PublishedAt])) this.dtmPublishedAt = Convert.ToDateTime(reader[C_PublishedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_RowVersion.ToUpper()) && !Convert.IsDBNull(reader[C_RowVersion])) this.bytRowVersion = (byte[])reader[C_RowVersion];
                    if (reader.GetName(i).ToUpper().Equals(C_SourceType.ToUpper()) && !Convert.IsDBNull(reader[C_SourceType])) this.strSourceType = Convert.ToString(reader[C_SourceType]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_VideoVersions", objEx);
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
                if (!Convert.IsDBNull(drw[C_VideoVersionID])) this.lngVideoVersionID = Convert.ToInt64(drw[C_VideoVersionID]);
                if (!Convert.IsDBNull(drw[C_VideoID])) this.lngVideoID = Convert.ToInt64(drw[C_VideoID]);
                if (!Convert.IsDBNull(drw[C_VersionNumber])) this.intVersionNumber = Convert.ToInt32(drw[C_VersionNumber]);
                if (!Convert.IsDBNull(drw[C_Title])) this.strTitle = Convert.ToString(drw[C_Title]);
                if (!Convert.IsDBNull(drw[C_VideoUrl])) this.strVideoUrl = Convert.ToString(drw[C_VideoUrl]);
                if (!Convert.IsDBNull(drw[C_PosterUrl])) this.strPosterUrl = Convert.ToString(drw[C_PosterUrl]);
                if (!Convert.IsDBNull(drw[C_DurationSeconds])) this.intDurationSeconds = Convert.ToInt32(drw[C_DurationSeconds]);
                if (!Convert.IsDBNull(drw[C_AllowSeek])) this.bolAllowSeek = Convert.ToBoolean(drw[C_AllowSeek]);
                if (!Convert.IsDBNull(drw[C_AllowSpeed])) this.bolAllowSpeed = Convert.ToBoolean(drw[C_AllowSpeed]);
                if (!Convert.IsDBNull(drw[C_RequiredWatchPercent])) this.decRequiredWatchPercent = Convert.ToDecimal(drw[C_RequiredWatchPercent]);
                if (!Convert.IsDBNull(drw[C_OriginalFileName])) this.strOriginalFileName = Convert.ToString(drw[C_OriginalFileName]);
                if (!Convert.IsDBNull(drw[C_FileSize])) this.lngFileSize = Convert.ToInt64(drw[C_FileSize]);
                if (!Convert.IsDBNull(drw[C_MimeType])) this.strMimeType = Convert.ToString(drw[C_MimeType]);
                if (!Convert.IsDBNull(drw[C_ChangeSummary])) this.strChangeSummary = Convert.ToString(drw[C_ChangeSummary]);
                if (!Convert.IsDBNull(drw[C_VersionStatus])) this.strVersionStatus = Convert.ToString(drw[C_VersionStatus]);
                if (!Convert.IsDBNull(drw[C_CreatedByUserID])) this.lngCreatedByUserID = Convert.ToInt64(drw[C_CreatedByUserID]);
                if (!Convert.IsDBNull(drw[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(drw[C_CreatedAt]);
                if (!Convert.IsDBNull(drw[C_PublishedByUserID])) this.lngPublishedByUserID = Convert.ToInt64(drw[C_PublishedByUserID]);
                if (!Convert.IsDBNull(drw[C_PublishedAt])) this.dtmPublishedAt = Convert.ToDateTime(drw[C_PublishedAt]);
                if (!Convert.IsDBNull(drw[C_RowVersion])) this.bytRowVersion = (byte[])drw[C_RowVersion];
                if (!Convert.IsDBNull(drw[C_SourceType])) this.strSourceType = Convert.ToString(drw[C_SourceType]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_VideoVersions", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: SIM_VideoVersions_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_VideoVersionID, this.lngVideoVersionID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin SIM_VideoVersions", objEx);
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
        /// Store: SIM_VideoVersions_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get(long lngVideoVersionID)
        {
            this.lngVideoVersionID = lngVideoVersionID;
            return this.Get();
        }

        ///<summary>
        ///Thêm mới dữ liệu
        /// Store: SIM_VideoVersions_ADD
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreAdd);
                objIData.AddParameter(P_VideoID, this.lngVideoID);
                objIData.AddParameter(P_VersionNumber, this.intVersionNumber);
                objIData.AddParameter(P_Title, this.strTitle);
                objIData.AddParameter(P_VideoUrl, this.strVideoUrl);
                objIData.AddParameter(P_PosterUrl, this.strPosterUrl);
                objIData.AddParameter(P_DurationSeconds, this.intDurationSeconds);
                objIData.AddParameter(P_AllowSeek, this.bolAllowSeek);
                objIData.AddParameter(P_AllowSpeed, this.bolAllowSpeed);
                objIData.AddParameter(P_RequiredWatchPercent, this.decRequiredWatchPercent);
                objIData.AddParameter(P_OriginalFileName, this.strOriginalFileName);
                objIData.AddParameter(P_FileSize, this.lngFileSize);
                objIData.AddParameter(P_MimeType, this.strMimeType);
                objIData.AddParameter(P_ChangeSummary, this.strChangeSummary);
                objIData.AddParameter(P_VersionStatus, this.strVersionStatus);
                objIData.AddParameter(P_CreatedByUserID, this.lngCreatedByUserID);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_PublishedByUserID, this.lngPublishedByUserID);
                objIData.AddParameter(P_PublishedAt, this.dtmPublishedAt);
                objIData.AddParameter(P_RowVersion, this.bytRowVersion);
                objIData.AddParameter(P_SourceType, this.strSourceType);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm mới thông tin trong SIM_VideoVersions", objEx);
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
        /// Store: SIM_VideoVersions_EDIT
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_VideoVersionID, this.lngVideoVersionID);
                objIData.AddParameter(P_VideoID, this.lngVideoID);
                objIData.AddParameter(P_VersionNumber, this.intVersionNumber);
                objIData.AddParameter(P_Title, this.strTitle);
                objIData.AddParameter(P_VideoUrl, this.strVideoUrl);
                objIData.AddParameter(P_PosterUrl, this.strPosterUrl);
                objIData.AddParameter(P_DurationSeconds, this.intDurationSeconds);
                objIData.AddParameter(P_AllowSeek, this.bolAllowSeek);
                objIData.AddParameter(P_AllowSpeed, this.bolAllowSpeed);
                objIData.AddParameter(P_RequiredWatchPercent, this.decRequiredWatchPercent);
                objIData.AddParameter(P_OriginalFileName, this.strOriginalFileName);
                objIData.AddParameter(P_FileSize, this.lngFileSize);
                objIData.AddParameter(P_MimeType, this.strMimeType);
                objIData.AddParameter(P_ChangeSummary, this.strChangeSummary);
                objIData.AddParameter(P_VersionStatus, this.strVersionStatus);
                objIData.AddParameter(P_CreatedByUserID, this.lngCreatedByUserID);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_PublishedByUserID, this.lngPublishedByUserID);
                objIData.AddParameter(P_PublishedAt, this.dtmPublishedAt);
                objIData.AddParameter(P_RowVersion, this.bytRowVersion);
                objIData.AddParameter(P_SourceType, this.strSourceType);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong SIM_VideoVersions", objEx);
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
        /// Store: SIM_VideoVersions_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_VideoVersionID, this.lngVideoVersionID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong SIM_VideoVersions", objEx);
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
        /// Store: SIM_VideoVersions_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long lngVideoVersionID)
        {
            this.lngVideoVersionID = lngVideoVersionID;
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

        public SIM_VideoVersions()
        {
        }
        public SIM_VideoVersions(long lngVideoVersionID)
        {
            this.lngVideoVersionID = lngVideoVersionID;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "SIM_VideoVersions";
        public const string StoreGet = "SIM_VideoVersions_GET";
        public const string StoreGetAll = "SIM_VideoVersions_GETALL";
        public const string StoreSearch = "SIM_VideoVersions_SEARCH";
        public const string StoreAdd = "SIM_VideoVersions_ADD";
        public const string StoreEdit = "SIM_VideoVersions_EDIT";
        public const string StoreDelete = "SIM_VideoVersions_DELETE";

        #region Parameter Names

        public const String P_VideoVersionID = "@" + C_VideoVersionID;
        public const String P_VideoID = "@" + C_VideoID;
        public const String P_VersionNumber = "@" + C_VersionNumber;
        public const String P_Title = "@" + C_Title;
        public const String P_VideoUrl = "@" + C_VideoUrl;
        public const String P_PosterUrl = "@" + C_PosterUrl;
        public const String P_DurationSeconds = "@" + C_DurationSeconds;
        public const String P_AllowSeek = "@" + C_AllowSeek;
        public const String P_AllowSpeed = "@" + C_AllowSpeed;
        public const String P_RequiredWatchPercent = "@" + C_RequiredWatchPercent;
        public const String P_OriginalFileName = "@" + C_OriginalFileName;
        public const String P_FileSize = "@" + C_FileSize;
        public const String P_MimeType = "@" + C_MimeType;
        public const String P_ChangeSummary = "@" + C_ChangeSummary;
        public const String P_VersionStatus = "@" + C_VersionStatus;
        public const String P_CreatedByUserID = "@" + C_CreatedByUserID;
        public const String P_CreatedAt = "@" + C_CreatedAt;
        public const String P_PublishedByUserID = "@" + C_PublishedByUserID;
        public const String P_PublishedAt = "@" + C_PublishedAt;
        public const String P_RowVersion = "@" + C_RowVersion;
        public const String P_SourceType = "@" + C_SourceType;

        #endregion //Parameter names

        #region Column Names

        public const String C_VideoVersionID = "VideoVersionID";
        public const String C_VideoID = "VideoID";
        public const String C_VersionNumber = "VersionNumber";
        public const String C_Title = "Title";
        public const String C_VideoUrl = "VideoUrl";
        public const String C_PosterUrl = "PosterUrl";
        public const String C_DurationSeconds = "DurationSeconds";
        public const String C_AllowSeek = "AllowSeek";
        public const String C_AllowSpeed = "AllowSpeed";
        public const String C_RequiredWatchPercent = "RequiredWatchPercent";
        public const String C_OriginalFileName = "OriginalFileName";
        public const String C_FileSize = "FileSize";
        public const String C_MimeType = "MimeType";
        public const String C_ChangeSummary = "ChangeSummary";
        public const String C_VersionStatus = "VersionStatus";
        public const String C_CreatedByUserID = "CreatedByUserID";
        public const String C_CreatedAt = "CreatedAt";
        public const String C_PublishedByUserID = "PublishedByUserID";
        public const String C_PublishedAt = "PublishedAt";
        public const String C_RowVersion = "RowVersion";
        public const String C_SourceType = "SourceType";

        #endregion //Column names

        #endregion Variable Static
    }
}
