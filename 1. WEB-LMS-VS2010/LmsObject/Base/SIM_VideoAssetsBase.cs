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
    /// [SIM] Thư viện tài nguyên video dùng lại cho nhiều bài học.
    /// </summary>
    public partial class SIM_VideoAssets
    {
        #region Member Variables

        private long lngVideoAssetID = 0;//Khóa chính tự tăng của tài nguyên video.
        private string strTitle = null;//Tên hiển thị của tài nguyên video.
        private string strVideoUrl = null;//Đường dẫn tệp video trong vùng lưu trữ dự án.
        private string strPosterUrl = null;//Đường dẫn ảnh đại diện của tài nguyên video.
        private int intDurationSeconds = 0;//Thời lượng tài nguyên video tính bằng giây.
        private string strOriginalFileName = null;//Tên gốc của tệp khi được tải lên.
        private long? lngFileSize = null;//Kích thước tệp video tính bằng byte.
        private string strMimeType = null;//Kiểu nội dung MIME của tệp video.
        private long? lngSourceVideoId = null;//ID video nguồn dùng khi chuyển đổi dữ liệu cũ sang thư viện.
        private long lngCreatedByUserID = 0;//ID người dùng tải lên hoặc tạo tài nguyên video.
        private string strShareScope = null;//Phạm vi chia sẻ: riêng tư, một số giáo viên được chọn hoặc toàn trường.
        private DateTime dtmCreatedAt = DateTime.MinValue;//Thời điểm tạo tài nguyên video theo UTC.
        private DateTime? dtmUpdatedAt = null;//Thời điểm cập nhật tài nguyên video gần nhất theo UTC.
        private string strStatus = null;//Trạng thái sử dụng của tài nguyên video.
        private bool bolIsDeleted = false;//Cờ xóa mềm của tài nguyên video.
        private string strSourceType = null;//Loại nguồn video trong thư viện: LOCAL là file tải lên Media, YOUTUBE là liên kết YouTube.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// VideoAssetID
        /// Khóa chính tự tăng của tài nguyên video.
        /// </summary>
        public long VideoAssetID
        {
            get { return lngVideoAssetID; }
            set { lngVideoAssetID = value; }
        }

        /// <summary>
        /// Title
        /// Tên hiển thị của tài nguyên video.
        /// </summary>
        public string Title
        {
            get { return strTitle; }
            set { strTitle = value; }
        }

        /// <summary>
        /// VideoUrl
        /// Đường dẫn tệp video trong vùng lưu trữ dự án.
        /// </summary>
        public string VideoUrl
        {
            get { return strVideoUrl; }
            set { strVideoUrl = value; }
        }

        /// <summary>
        /// PosterUrl
        /// Đường dẫn ảnh đại diện của tài nguyên video.
        /// </summary>
        public string PosterUrl
        {
            get { return strPosterUrl; }
            set { strPosterUrl = value; }
        }

        /// <summary>
        /// DurationSeconds
        /// Thời lượng tài nguyên video tính bằng giây.
        /// </summary>
        public int DurationSeconds
        {
            get { return intDurationSeconds; }
            set { intDurationSeconds = value; }
        }

        /// <summary>
        /// OriginalFileName
        /// Tên gốc của tệp khi được tải lên.
        /// </summary>
        public string OriginalFileName
        {
            get { return strOriginalFileName; }
            set { strOriginalFileName = value; }
        }

        /// <summary>
        /// FileSize
        /// Kích thước tệp video tính bằng byte.
        /// </summary>
        public long? FileSize
        {
            get { return lngFileSize; }
            set { lngFileSize = value; }
        }

        /// <summary>
        /// MimeType
        /// Kiểu nội dung MIME của tệp video.
        /// </summary>
        public string MimeType
        {
            get { return strMimeType; }
            set { strMimeType = value; }
        }

        /// <summary>
        /// SourceVideoId
        /// ID video nguồn dùng khi chuyển đổi dữ liệu cũ sang thư viện.
        /// </summary>
        public long? SourceVideoId
        {
            get { return lngSourceVideoId; }
            set { lngSourceVideoId = value; }
        }

        /// <summary>
        /// CreatedByUserID
        /// ID người dùng tải lên hoặc tạo tài nguyên video.
        /// </summary>
        public long CreatedByUserID
        {
            get { return lngCreatedByUserID; }
            set { lngCreatedByUserID = value; }
        }

        /// <summary>
        /// ShareScope
        /// Phạm vi chia sẻ: riêng tư, một số giáo viên được chọn hoặc toàn trường.
        /// </summary>
        public string ShareScope
        {
            get { return strShareScope; }
            set { strShareScope = value; }
        }

        /// <summary>
        /// CreatedAt
        /// Thời điểm tạo tài nguyên video theo UTC.
        /// </summary>
        public DateTime CreatedAt
        {
            get { return dtmCreatedAt; }
            set { dtmCreatedAt = value; }
        }

        /// <summary>
        /// UpdatedAt
        /// Thời điểm cập nhật tài nguyên video gần nhất theo UTC.
        /// </summary>
        public DateTime? UpdatedAt
        {
            get { return dtmUpdatedAt; }
            set { dtmUpdatedAt = value; }
        }

        /// <summary>
        /// Status
        /// Trạng thái sử dụng của tài nguyên video.
        /// </summary>
        public string Status
        {
            get { return strStatus; }
            set { strStatus = value; }
        }

        /// <summary>
        /// IsDeleted
        /// Cờ xóa mềm của tài nguyên video.
        /// </summary>
        public bool IsDeleted
        {
            get { return bolIsDeleted; }
            set { bolIsDeleted = value; }
        }

        /// <summary>
        /// SourceType
        /// Loại nguồn video trong thư viện: LOCAL là file tải lên Media, YOUTUBE là liên kết YouTube.
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
                    if (reader.GetName(i).ToUpper().Equals(C_VideoAssetID.ToUpper()) && !Convert.IsDBNull(reader[C_VideoAssetID])) this.lngVideoAssetID = Convert.ToInt64(reader[C_VideoAssetID]);
                    if (reader.GetName(i).ToUpper().Equals(C_Title.ToUpper()) && !Convert.IsDBNull(reader[C_Title])) this.strTitle = Convert.ToString(reader[C_Title]);
                    if (reader.GetName(i).ToUpper().Equals(C_VideoUrl.ToUpper()) && !Convert.IsDBNull(reader[C_VideoUrl])) this.strVideoUrl = Convert.ToString(reader[C_VideoUrl]);
                    if (reader.GetName(i).ToUpper().Equals(C_PosterUrl.ToUpper()) && !Convert.IsDBNull(reader[C_PosterUrl])) this.strPosterUrl = Convert.ToString(reader[C_PosterUrl]);
                    if (reader.GetName(i).ToUpper().Equals(C_DurationSeconds.ToUpper()) && !Convert.IsDBNull(reader[C_DurationSeconds])) this.intDurationSeconds = Convert.ToInt32(reader[C_DurationSeconds]);
                    if (reader.GetName(i).ToUpper().Equals(C_OriginalFileName.ToUpper()) && !Convert.IsDBNull(reader[C_OriginalFileName])) this.strOriginalFileName = Convert.ToString(reader[C_OriginalFileName]);
                    if (reader.GetName(i).ToUpper().Equals(C_FileSize.ToUpper()) && !Convert.IsDBNull(reader[C_FileSize])) this.lngFileSize = Convert.ToInt64(reader[C_FileSize]);
                    if (reader.GetName(i).ToUpper().Equals(C_MimeType.ToUpper()) && !Convert.IsDBNull(reader[C_MimeType])) this.strMimeType = Convert.ToString(reader[C_MimeType]);
                    if (reader.GetName(i).ToUpper().Equals(C_SourceVideoId.ToUpper()) && !Convert.IsDBNull(reader[C_SourceVideoId])) this.lngSourceVideoId = Convert.ToInt64(reader[C_SourceVideoId]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedByUserID.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedByUserID])) this.lngCreatedByUserID = Convert.ToInt64(reader[C_CreatedByUserID]);
                    if (reader.GetName(i).ToUpper().Equals(C_ShareScope.ToUpper()) && !Convert.IsDBNull(reader[C_ShareScope])) this.strShareScope = Convert.ToString(reader[C_ShareScope]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(reader[C_CreatedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedAt])) this.dtmUpdatedAt = Convert.ToDateTime(reader[C_UpdatedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_Status.ToUpper()) && !Convert.IsDBNull(reader[C_Status])) this.strStatus = Convert.ToString(reader[C_Status]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsDeleted.ToUpper()) && !Convert.IsDBNull(reader[C_IsDeleted])) this.bolIsDeleted = Convert.ToBoolean(reader[C_IsDeleted]);
                    if (reader.GetName(i).ToUpper().Equals(C_SourceType.ToUpper()) && !Convert.IsDBNull(reader[C_SourceType])) this.strSourceType = Convert.ToString(reader[C_SourceType]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_VideoAssets", objEx);
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
                if (!Convert.IsDBNull(drw[C_VideoAssetID])) this.lngVideoAssetID = Convert.ToInt64(drw[C_VideoAssetID]);
                if (!Convert.IsDBNull(drw[C_Title])) this.strTitle = Convert.ToString(drw[C_Title]);
                if (!Convert.IsDBNull(drw[C_VideoUrl])) this.strVideoUrl = Convert.ToString(drw[C_VideoUrl]);
                if (!Convert.IsDBNull(drw[C_PosterUrl])) this.strPosterUrl = Convert.ToString(drw[C_PosterUrl]);
                if (!Convert.IsDBNull(drw[C_DurationSeconds])) this.intDurationSeconds = Convert.ToInt32(drw[C_DurationSeconds]);
                if (!Convert.IsDBNull(drw[C_OriginalFileName])) this.strOriginalFileName = Convert.ToString(drw[C_OriginalFileName]);
                if (!Convert.IsDBNull(drw[C_FileSize])) this.lngFileSize = Convert.ToInt64(drw[C_FileSize]);
                if (!Convert.IsDBNull(drw[C_MimeType])) this.strMimeType = Convert.ToString(drw[C_MimeType]);
                if (!Convert.IsDBNull(drw[C_SourceVideoId])) this.lngSourceVideoId = Convert.ToInt64(drw[C_SourceVideoId]);
                if (!Convert.IsDBNull(drw[C_CreatedByUserID])) this.lngCreatedByUserID = Convert.ToInt64(drw[C_CreatedByUserID]);
                if (!Convert.IsDBNull(drw[C_ShareScope])) this.strShareScope = Convert.ToString(drw[C_ShareScope]);
                if (!Convert.IsDBNull(drw[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(drw[C_CreatedAt]);
                if (!Convert.IsDBNull(drw[C_UpdatedAt])) this.dtmUpdatedAt = Convert.ToDateTime(drw[C_UpdatedAt]);
                if (!Convert.IsDBNull(drw[C_Status])) this.strStatus = Convert.ToString(drw[C_Status]);
                if (!Convert.IsDBNull(drw[C_IsDeleted])) this.bolIsDeleted = Convert.ToBoolean(drw[C_IsDeleted]);
                if (!Convert.IsDBNull(drw[C_SourceType])) this.strSourceType = Convert.ToString(drw[C_SourceType]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_VideoAssets", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: SIM_VideoAssets_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_VideoAssetID, this.lngVideoAssetID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin SIM_VideoAssets", objEx);
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
        /// Store: SIM_VideoAssets_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get(long lngVideoAssetID)
        {
            this.lngVideoAssetID = lngVideoAssetID;
            return this.Get();
        }

        ///<summary>
        ///Thêm mới dữ liệu
        /// Store: SIM_VideoAssets_ADD
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
                objIData.AddParameter(P_OriginalFileName, this.strOriginalFileName);
                objIData.AddParameter(P_FileSize, this.lngFileSize);
                objIData.AddParameter(P_MimeType, this.strMimeType);
                objIData.AddParameter(P_SourceVideoId, this.lngSourceVideoId);
                objIData.AddParameter(P_CreatedByUserID, this.lngCreatedByUserID);
                objIData.AddParameter(P_ShareScope, this.strShareScope);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_UpdatedAt, this.dtmUpdatedAt);
                objIData.AddParameter(P_Status, this.strStatus);
                objIData.AddParameter(P_IsDeleted, this.bolIsDeleted);
                objIData.AddParameter(P_SourceType, this.strSourceType);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm mới thông tin trong SIM_VideoAssets", objEx);
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
        /// Store: SIM_VideoAssets_EDIT
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_VideoAssetID, this.lngVideoAssetID);
                objIData.AddParameter(P_Title, this.strTitle);
                objIData.AddParameter(P_VideoUrl, this.strVideoUrl);
                objIData.AddParameter(P_PosterUrl, this.strPosterUrl);
                objIData.AddParameter(P_DurationSeconds, this.intDurationSeconds);
                objIData.AddParameter(P_OriginalFileName, this.strOriginalFileName);
                objIData.AddParameter(P_FileSize, this.lngFileSize);
                objIData.AddParameter(P_MimeType, this.strMimeType);
                objIData.AddParameter(P_SourceVideoId, this.lngSourceVideoId);
                objIData.AddParameter(P_CreatedByUserID, this.lngCreatedByUserID);
                objIData.AddParameter(P_ShareScope, this.strShareScope);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_UpdatedAt, this.dtmUpdatedAt);
                objIData.AddParameter(P_Status, this.strStatus);
                objIData.AddParameter(P_IsDeleted, this.bolIsDeleted);
                objIData.AddParameter(P_SourceType, this.strSourceType);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong SIM_VideoAssets", objEx);
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
        /// Store: SIM_VideoAssets_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_VideoAssetID, this.lngVideoAssetID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong SIM_VideoAssets", objEx);
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
        /// Store: SIM_VideoAssets_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long lngVideoAssetID)
        {
            this.lngVideoAssetID = lngVideoAssetID;
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

        public SIM_VideoAssets()
        {
        }
        public SIM_VideoAssets(long lngVideoAssetID)
        {
            this.lngVideoAssetID = lngVideoAssetID;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "SIM_VideoAssets";
        public const string StoreGet = "SIM_VideoAssets_GET";
        public const string StoreGetAll = "SIM_VideoAssets_GETALL";
        public const string StoreSearch = "SIM_VideoAssets_SEARCH";
        public const string StoreAdd = "SIM_VideoAssets_ADD";
        public const string StoreEdit = "SIM_VideoAssets_EDIT";
        public const string StoreDelete = "SIM_VideoAssets_DELETE";

        #region Parameter Names

        public const String P_VideoAssetID = "@" + C_VideoAssetID;
        public const String P_Title = "@" + C_Title;
        public const String P_VideoUrl = "@" + C_VideoUrl;
        public const String P_PosterUrl = "@" + C_PosterUrl;
        public const String P_DurationSeconds = "@" + C_DurationSeconds;
        public const String P_OriginalFileName = "@" + C_OriginalFileName;
        public const String P_FileSize = "@" + C_FileSize;
        public const String P_MimeType = "@" + C_MimeType;
        public const String P_SourceVideoId = "@" + C_SourceVideoId;
        public const String P_CreatedByUserID = "@" + C_CreatedByUserID;
        public const String P_ShareScope = "@" + C_ShareScope;
        public const String P_CreatedAt = "@" + C_CreatedAt;
        public const String P_UpdatedAt = "@" + C_UpdatedAt;
        public const String P_Status = "@" + C_Status;
        public const String P_IsDeleted = "@" + C_IsDeleted;
        public const String P_SourceType = "@" + C_SourceType;

        #endregion //Parameter names

        #region Column Names

        public const String C_VideoAssetID = "VideoAssetID";
        public const String C_Title = "Title";
        public const String C_VideoUrl = "VideoUrl";
        public const String C_PosterUrl = "PosterUrl";
        public const String C_DurationSeconds = "DurationSeconds";
        public const String C_OriginalFileName = "OriginalFileName";
        public const String C_FileSize = "FileSize";
        public const String C_MimeType = "MimeType";
        public const String C_SourceVideoId = "SourceVideoId";
        public const String C_CreatedByUserID = "CreatedByUserID";
        public const String C_ShareScope = "ShareScope";
        public const String C_CreatedAt = "CreatedAt";
        public const String C_UpdatedAt = "UpdatedAt";
        public const String C_Status = "Status";
        public const String C_IsDeleted = "IsDeleted";
        public const String C_SourceType = "SourceType";

        #endregion //Column names

        #endregion Variable Static
    }
}
