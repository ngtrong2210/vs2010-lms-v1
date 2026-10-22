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
    /// [LMS] Tiến độ xem video chi tiết của học viên.
    /// </summary>
    public partial class LMS_StudentVideoProgress
    {
        #region Member Variables

        private long lngStudentVideoProgressID = 0;//Khóa chính tự tăng của tiến độ video.
        private long lngStudentUserID = 0;//ID học viên xem video.
        private long lngCourseId = 0;//ID khóa học chứa video.
        private long lngLessonId = 0;//ID bài học chứa video.
        private long lngVideoId = 0;//ID video được theo dõi.
        private decimal decCurrentTimeSeconds = 0;//Vị trí phát hiện tại của học viên, đơn vị giây.
        private decimal decMaxWatchedTimeSeconds = 0;//Vị trí xa nhất học viên đã xem hợp lệ, đơn vị giây.
        private decimal decWatchedSeconds = 0;//Tổng thời lượng xem hợp lệ, đơn vị giây.
        private decimal decWatchPercent = 0;//Tỷ lệ phần trăm video đã xem hợp lệ.
        private bool bolCompleted = false;//Cờ cho biết video đã đạt điều kiện hoàn thành.
        private DateTime dtmStartedAt = DateTime.MinValue;//Thời điểm bắt đầu xem video theo UTC.
        private DateTime? dtmCompletedAt = null;//Thời điểm hoàn thành video theo UTC.
        private DateTime dtmLastAccessAt = DateTime.MinValue;//Thời điểm truy cập video gần nhất theo UTC.
        private DateTime dtmCreatedAt = DateTime.MinValue;//Thời điểm tạo bản ghi tiến độ video theo UTC.
        private DateTime? dtmUpdatedAt = null;//Thời điểm cập nhật tiến độ video gần nhất theo UTC.
        private byte[] bytRowVersion = null;//Phiên bản hàng tự động dùng kiểm soát cập nhật đồng thời.
        private long? lngVideoVersionID = null;//ID phiên bản video mà học viên đã xem và phát sinh tiến độ.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// StudentVideoProgressID
        /// Khóa chính tự tăng của tiến độ video.
        /// </summary>
        public long StudentVideoProgressID
        {
            get { return lngStudentVideoProgressID; }
            set { lngStudentVideoProgressID = value; }
        }

        /// <summary>
        /// StudentUserID
        /// ID học viên xem video.
        /// </summary>
        public long StudentUserID
        {
            get { return lngStudentUserID; }
            set { lngStudentUserID = value; }
        }

        /// <summary>
        /// CourseId
        /// ID khóa học chứa video.
        /// </summary>
        public long CourseId
        {
            get { return lngCourseId; }
            set { lngCourseId = value; }
        }

        /// <summary>
        /// LessonId
        /// ID bài học chứa video.
        /// </summary>
        public long LessonId
        {
            get { return lngLessonId; }
            set { lngLessonId = value; }
        }

        /// <summary>
        /// VideoId
        /// ID video được theo dõi.
        /// </summary>
        public long VideoId
        {
            get { return lngVideoId; }
            set { lngVideoId = value; }
        }

        /// <summary>
        /// CurrentTimeSeconds
        /// Vị trí phát hiện tại của học viên, đơn vị giây.
        /// </summary>
        public decimal CurrentTimeSeconds
        {
            get { return decCurrentTimeSeconds; }
            set { decCurrentTimeSeconds = value; }
        }

        /// <summary>
        /// MaxWatchedTimeSeconds
        /// Vị trí xa nhất học viên đã xem hợp lệ, đơn vị giây.
        /// </summary>
        public decimal MaxWatchedTimeSeconds
        {
            get { return decMaxWatchedTimeSeconds; }
            set { decMaxWatchedTimeSeconds = value; }
        }

        /// <summary>
        /// WatchedSeconds
        /// Tổng thời lượng xem hợp lệ, đơn vị giây.
        /// </summary>
        public decimal WatchedSeconds
        {
            get { return decWatchedSeconds; }
            set { decWatchedSeconds = value; }
        }

        /// <summary>
        /// WatchPercent
        /// Tỷ lệ phần trăm video đã xem hợp lệ.
        /// </summary>
        public decimal WatchPercent
        {
            get { return decWatchPercent; }
            set { decWatchPercent = value; }
        }

        /// <summary>
        /// Completed
        /// Cờ cho biết video đã đạt điều kiện hoàn thành.
        /// </summary>
        public bool Completed
        {
            get { return bolCompleted; }
            set { bolCompleted = value; }
        }

        /// <summary>
        /// StartedAt
        /// Thời điểm bắt đầu xem video theo UTC.
        /// </summary>
        public DateTime StartedAt
        {
            get { return dtmStartedAt; }
            set { dtmStartedAt = value; }
        }

        /// <summary>
        /// CompletedAt
        /// Thời điểm hoàn thành video theo UTC.
        /// </summary>
        public DateTime? CompletedAt
        {
            get { return dtmCompletedAt; }
            set { dtmCompletedAt = value; }
        }

        /// <summary>
        /// LastAccessAt
        /// Thời điểm truy cập video gần nhất theo UTC.
        /// </summary>
        public DateTime LastAccessAt
        {
            get { return dtmLastAccessAt; }
            set { dtmLastAccessAt = value; }
        }

        /// <summary>
        /// CreatedAt
        /// Thời điểm tạo bản ghi tiến độ video theo UTC.
        /// </summary>
        public DateTime CreatedAt
        {
            get { return dtmCreatedAt; }
            set { dtmCreatedAt = value; }
        }

        /// <summary>
        /// UpdatedAt
        /// Thời điểm cập nhật tiến độ video gần nhất theo UTC.
        /// </summary>
        public DateTime? UpdatedAt
        {
            get { return dtmUpdatedAt; }
            set { dtmUpdatedAt = value; }
        }

        /// <summary>
        /// RowVersion
        /// Phiên bản hàng tự động dùng kiểm soát cập nhật đồng thời.
        /// </summary>
        public byte[] RowVersion
        {
            get { return bytRowVersion; }
            set { bytRowVersion = value; }
        }

        /// <summary>
        /// VideoVersionID
        /// ID phiên bản video mà học viên đã xem và phát sinh tiến độ.
        /// </summary>
        public long? VideoVersionID
        {
            get { return lngVideoVersionID; }
            set { lngVideoVersionID = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_StudentVideoProgressID.ToUpper()) && !Convert.IsDBNull(reader[C_StudentVideoProgressID])) this.lngStudentVideoProgressID = Convert.ToInt64(reader[C_StudentVideoProgressID]);
                    if (reader.GetName(i).ToUpper().Equals(C_StudentUserID.ToUpper()) && !Convert.IsDBNull(reader[C_StudentUserID])) this.lngStudentUserID = Convert.ToInt64(reader[C_StudentUserID]);
                    if (reader.GetName(i).ToUpper().Equals(C_CourseId.ToUpper()) && !Convert.IsDBNull(reader[C_CourseId])) this.lngCourseId = Convert.ToInt64(reader[C_CourseId]);
                    if (reader.GetName(i).ToUpper().Equals(C_LessonId.ToUpper()) && !Convert.IsDBNull(reader[C_LessonId])) this.lngLessonId = Convert.ToInt64(reader[C_LessonId]);
                    if (reader.GetName(i).ToUpper().Equals(C_VideoId.ToUpper()) && !Convert.IsDBNull(reader[C_VideoId])) this.lngVideoId = Convert.ToInt64(reader[C_VideoId]);
                    if (reader.GetName(i).ToUpper().Equals(C_CurrentTimeSeconds.ToUpper()) && !Convert.IsDBNull(reader[C_CurrentTimeSeconds])) this.decCurrentTimeSeconds = Convert.ToDecimal(reader[C_CurrentTimeSeconds]);
                    if (reader.GetName(i).ToUpper().Equals(C_MaxWatchedTimeSeconds.ToUpper()) && !Convert.IsDBNull(reader[C_MaxWatchedTimeSeconds])) this.decMaxWatchedTimeSeconds = Convert.ToDecimal(reader[C_MaxWatchedTimeSeconds]);
                    if (reader.GetName(i).ToUpper().Equals(C_WatchedSeconds.ToUpper()) && !Convert.IsDBNull(reader[C_WatchedSeconds])) this.decWatchedSeconds = Convert.ToDecimal(reader[C_WatchedSeconds]);
                    if (reader.GetName(i).ToUpper().Equals(C_WatchPercent.ToUpper()) && !Convert.IsDBNull(reader[C_WatchPercent])) this.decWatchPercent = Convert.ToDecimal(reader[C_WatchPercent]);
                    if (reader.GetName(i).ToUpper().Equals(C_Completed.ToUpper()) && !Convert.IsDBNull(reader[C_Completed])) this.bolCompleted = Convert.ToBoolean(reader[C_Completed]);
                    if (reader.GetName(i).ToUpper().Equals(C_StartedAt.ToUpper()) && !Convert.IsDBNull(reader[C_StartedAt])) this.dtmStartedAt = Convert.ToDateTime(reader[C_StartedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_CompletedAt.ToUpper()) && !Convert.IsDBNull(reader[C_CompletedAt])) this.dtmCompletedAt = Convert.ToDateTime(reader[C_CompletedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_LastAccessAt.ToUpper()) && !Convert.IsDBNull(reader[C_LastAccessAt])) this.dtmLastAccessAt = Convert.ToDateTime(reader[C_LastAccessAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(reader[C_CreatedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedAt])) this.dtmUpdatedAt = Convert.ToDateTime(reader[C_UpdatedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_RowVersion.ToUpper()) && !Convert.IsDBNull(reader[C_RowVersion])) this.bytRowVersion = (byte[])reader[C_RowVersion];
                    if (reader.GetName(i).ToUpper().Equals(C_VideoVersionID.ToUpper()) && !Convert.IsDBNull(reader[C_VideoVersionID])) this.lngVideoVersionID = Convert.ToInt64(reader[C_VideoVersionID]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong LMS_StudentVideoProgress", objEx);
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
                if (!Convert.IsDBNull(drw[C_StudentVideoProgressID])) this.lngStudentVideoProgressID = Convert.ToInt64(drw[C_StudentVideoProgressID]);
                if (!Convert.IsDBNull(drw[C_StudentUserID])) this.lngStudentUserID = Convert.ToInt64(drw[C_StudentUserID]);
                if (!Convert.IsDBNull(drw[C_CourseId])) this.lngCourseId = Convert.ToInt64(drw[C_CourseId]);
                if (!Convert.IsDBNull(drw[C_LessonId])) this.lngLessonId = Convert.ToInt64(drw[C_LessonId]);
                if (!Convert.IsDBNull(drw[C_VideoId])) this.lngVideoId = Convert.ToInt64(drw[C_VideoId]);
                if (!Convert.IsDBNull(drw[C_CurrentTimeSeconds])) this.decCurrentTimeSeconds = Convert.ToDecimal(drw[C_CurrentTimeSeconds]);
                if (!Convert.IsDBNull(drw[C_MaxWatchedTimeSeconds])) this.decMaxWatchedTimeSeconds = Convert.ToDecimal(drw[C_MaxWatchedTimeSeconds]);
                if (!Convert.IsDBNull(drw[C_WatchedSeconds])) this.decWatchedSeconds = Convert.ToDecimal(drw[C_WatchedSeconds]);
                if (!Convert.IsDBNull(drw[C_WatchPercent])) this.decWatchPercent = Convert.ToDecimal(drw[C_WatchPercent]);
                if (!Convert.IsDBNull(drw[C_Completed])) this.bolCompleted = Convert.ToBoolean(drw[C_Completed]);
                if (!Convert.IsDBNull(drw[C_StartedAt])) this.dtmStartedAt = Convert.ToDateTime(drw[C_StartedAt]);
                if (!Convert.IsDBNull(drw[C_CompletedAt])) this.dtmCompletedAt = Convert.ToDateTime(drw[C_CompletedAt]);
                if (!Convert.IsDBNull(drw[C_LastAccessAt])) this.dtmLastAccessAt = Convert.ToDateTime(drw[C_LastAccessAt]);
                if (!Convert.IsDBNull(drw[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(drw[C_CreatedAt]);
                if (!Convert.IsDBNull(drw[C_UpdatedAt])) this.dtmUpdatedAt = Convert.ToDateTime(drw[C_UpdatedAt]);
                if (!Convert.IsDBNull(drw[C_RowVersion])) this.bytRowVersion = (byte[])drw[C_RowVersion];
                if (!Convert.IsDBNull(drw[C_VideoVersionID])) this.lngVideoVersionID = Convert.ToInt64(drw[C_VideoVersionID]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong LMS_StudentVideoProgress", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: LMS_StudentVideoProgress_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_StudentVideoProgressID, this.lngStudentVideoProgressID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin LMS_StudentVideoProgress", objEx);
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
        /// Store: LMS_StudentVideoProgress_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get(long lngStudentVideoProgressID)
        {
            this.lngStudentVideoProgressID = lngStudentVideoProgressID;
            return this.Get();
        }

        ///<summary>
        ///Thêm mới dữ liệu
        /// Store: LMS_StudentVideoProgress_ADD
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreAdd);
                objIData.AddParameter(P_StudentUserID, this.lngStudentUserID);
                objIData.AddParameter(P_CourseId, this.lngCourseId);
                objIData.AddParameter(P_LessonId, this.lngLessonId);
                objIData.AddParameter(P_VideoId, this.lngVideoId);
                objIData.AddParameter(P_CurrentTimeSeconds, this.decCurrentTimeSeconds);
                objIData.AddParameter(P_MaxWatchedTimeSeconds, this.decMaxWatchedTimeSeconds);
                objIData.AddParameter(P_WatchedSeconds, this.decWatchedSeconds);
                objIData.AddParameter(P_WatchPercent, this.decWatchPercent);
                objIData.AddParameter(P_Completed, this.bolCompleted);
                objIData.AddParameter(P_StartedAt, this.dtmStartedAt);
                objIData.AddParameter(P_CompletedAt, this.dtmCompletedAt);
                objIData.AddParameter(P_LastAccessAt, this.dtmLastAccessAt);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_UpdatedAt, this.dtmUpdatedAt);
                objIData.AddParameter(P_RowVersion, this.bytRowVersion);
                objIData.AddParameter(P_VideoVersionID, this.lngVideoVersionID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm mới thông tin trong LMS_StudentVideoProgress", objEx);
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
        /// Store: LMS_StudentVideoProgress_EDIT
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_StudentVideoProgressID, this.lngStudentVideoProgressID);
                objIData.AddParameter(P_StudentUserID, this.lngStudentUserID);
                objIData.AddParameter(P_CourseId, this.lngCourseId);
                objIData.AddParameter(P_LessonId, this.lngLessonId);
                objIData.AddParameter(P_VideoId, this.lngVideoId);
                objIData.AddParameter(P_CurrentTimeSeconds, this.decCurrentTimeSeconds);
                objIData.AddParameter(P_MaxWatchedTimeSeconds, this.decMaxWatchedTimeSeconds);
                objIData.AddParameter(P_WatchedSeconds, this.decWatchedSeconds);
                objIData.AddParameter(P_WatchPercent, this.decWatchPercent);
                objIData.AddParameter(P_Completed, this.bolCompleted);
                objIData.AddParameter(P_StartedAt, this.dtmStartedAt);
                objIData.AddParameter(P_CompletedAt, this.dtmCompletedAt);
                objIData.AddParameter(P_LastAccessAt, this.dtmLastAccessAt);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_UpdatedAt, this.dtmUpdatedAt);
                objIData.AddParameter(P_RowVersion, this.bytRowVersion);
                objIData.AddParameter(P_VideoVersionID, this.lngVideoVersionID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong LMS_StudentVideoProgress", objEx);
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
        /// Store: LMS_StudentVideoProgress_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_StudentVideoProgressID, this.lngStudentVideoProgressID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong LMS_StudentVideoProgress", objEx);
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
        /// Store: LMS_StudentVideoProgress_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long lngStudentVideoProgressID)
        {
            this.lngStudentVideoProgressID = lngStudentVideoProgressID;
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

        public LMS_StudentVideoProgress()
        {
        }
        public LMS_StudentVideoProgress(long lngStudentVideoProgressID)
        {
            this.lngStudentVideoProgressID = lngStudentVideoProgressID;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "LMS_StudentVideoProgress";
        public const string StoreGet = "LMS_StudentVideoProgress_GET";
        public const string StoreGetAll = "LMS_StudentVideoProgress_GETALL";
        public const string StoreSearch = "LMS_StudentVideoProgress_SEARCH";
        public const string StoreAdd = "LMS_StudentVideoProgress_ADD";
        public const string StoreEdit = "LMS_StudentVideoProgress_EDIT";
        public const string StoreDelete = "LMS_StudentVideoProgress_DELETE";

        #region Parameter Names

        public const String P_StudentVideoProgressID = "@" + C_StudentVideoProgressID;
        public const String P_StudentUserID = "@" + C_StudentUserID;
        public const String P_CourseId = "@" + C_CourseId;
        public const String P_LessonId = "@" + C_LessonId;
        public const String P_VideoId = "@" + C_VideoId;
        public const String P_CurrentTimeSeconds = "@" + C_CurrentTimeSeconds;
        public const String P_MaxWatchedTimeSeconds = "@" + C_MaxWatchedTimeSeconds;
        public const String P_WatchedSeconds = "@" + C_WatchedSeconds;
        public const String P_WatchPercent = "@" + C_WatchPercent;
        public const String P_Completed = "@" + C_Completed;
        public const String P_StartedAt = "@" + C_StartedAt;
        public const String P_CompletedAt = "@" + C_CompletedAt;
        public const String P_LastAccessAt = "@" + C_LastAccessAt;
        public const String P_CreatedAt = "@" + C_CreatedAt;
        public const String P_UpdatedAt = "@" + C_UpdatedAt;
        public const String P_RowVersion = "@" + C_RowVersion;
        public const String P_VideoVersionID = "@" + C_VideoVersionID;

        #endregion //Parameter names

        #region Column Names

        public const String C_StudentVideoProgressID = "StudentVideoProgressID";
        public const String C_StudentUserID = "StudentUserID";
        public const String C_CourseId = "CourseId";
        public const String C_LessonId = "LessonId";
        public const String C_VideoId = "VideoId";
        public const String C_CurrentTimeSeconds = "CurrentTimeSeconds";
        public const String C_MaxWatchedTimeSeconds = "MaxWatchedTimeSeconds";
        public const String C_WatchedSeconds = "WatchedSeconds";
        public const String C_WatchPercent = "WatchPercent";
        public const String C_Completed = "Completed";
        public const String C_StartedAt = "StartedAt";
        public const String C_CompletedAt = "CompletedAt";
        public const String C_LastAccessAt = "LastAccessAt";
        public const String C_CreatedAt = "CreatedAt";
        public const String C_UpdatedAt = "UpdatedAt";
        public const String C_RowVersion = "RowVersion";
        public const String C_VideoVersionID = "VideoVersionID";

        #endregion //Column names

        #endregion Variable Static
    }
}
