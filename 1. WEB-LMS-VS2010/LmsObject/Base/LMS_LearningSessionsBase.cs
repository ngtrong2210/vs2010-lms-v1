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
    /// [LMS] Phiên học theo dõi thời lượng xem và hành vi học tập.
    /// </summary>
    public partial class LMS_LearningSessions
    {
        #region Member Variables

        private long lngLearningSessionID = 0;//Khóa chính tự tăng của phiên học.
        private Guid guiSessionId = Guid.Empty;//Mã UUID duy nhất dùng nhận diện phiên học.
        private long lngStudentUserID = 0;//ID học viên tham gia phiên học.
        private long lngCourseId = 0;//ID khóa học của phiên học.
        private long lngLessonId = 0;//ID bài học của phiên học.
        private long? lngVideoId = null;//ID video đang học; có thể rỗng với bài học không phải video.
        private DateTime dtmStartedAt = DateTime.MinValue;//Thời điểm bắt đầu phiên học theo UTC.
        private DateTime? dtmEndedAt = null;//Thời điểm kết thúc phiên học theo UTC.
        private int intWatchDurationSeconds = 0;//Tổng thời lượng xem trong phiên, đơn vị giây.
        private decimal decLastPositionSeconds = 0;//Vị trí phát cuối cùng trong phiên, đơn vị giây.
        private decimal decMaxPositionSeconds = 0;//Vị trí xa nhất đã xem trong phiên, đơn vị giây.
        private int intSeekCount = 0;//Số lần tua video trong phiên.
        private int intPauseCount = 0;//Số lần tạm dừng video trong phiên.
        private int intInteractionCount = 0;//Số tương tác đã kích hoạt trong phiên.
        private bool bolCompleted = false;//Cờ cho biết phiên đã hoàn thành nội dung học.
        private long? lngVideoVersionID = null;//ID phiên bản video được sử dụng trong phiên học.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// LearningSessionID
        /// Khóa chính tự tăng của phiên học.
        /// </summary>
        public long LearningSessionID
        {
            get { return lngLearningSessionID; }
            set { lngLearningSessionID = value; }
        }

        /// <summary>
        /// SessionId
        /// Mã UUID duy nhất dùng nhận diện phiên học.
        /// </summary>
        public Guid SessionId
        {
            get { return guiSessionId; }
            set { guiSessionId = value; }
        }

        /// <summary>
        /// StudentUserID
        /// ID học viên tham gia phiên học.
        /// </summary>
        public long StudentUserID
        {
            get { return lngStudentUserID; }
            set { lngStudentUserID = value; }
        }

        /// <summary>
        /// CourseId
        /// ID khóa học của phiên học.
        /// </summary>
        public long CourseId
        {
            get { return lngCourseId; }
            set { lngCourseId = value; }
        }

        /// <summary>
        /// LessonId
        /// ID bài học của phiên học.
        /// </summary>
        public long LessonId
        {
            get { return lngLessonId; }
            set { lngLessonId = value; }
        }

        /// <summary>
        /// VideoId
        /// ID video đang học; có thể rỗng với bài học không phải video.
        /// </summary>
        public long? VideoId
        {
            get { return lngVideoId; }
            set { lngVideoId = value; }
        }

        /// <summary>
        /// StartedAt
        /// Thời điểm bắt đầu phiên học theo UTC.
        /// </summary>
        public DateTime StartedAt
        {
            get { return dtmStartedAt; }
            set { dtmStartedAt = value; }
        }

        /// <summary>
        /// EndedAt
        /// Thời điểm kết thúc phiên học theo UTC.
        /// </summary>
        public DateTime? EndedAt
        {
            get { return dtmEndedAt; }
            set { dtmEndedAt = value; }
        }

        /// <summary>
        /// WatchDurationSeconds
        /// Tổng thời lượng xem trong phiên, đơn vị giây.
        /// </summary>
        public int WatchDurationSeconds
        {
            get { return intWatchDurationSeconds; }
            set { intWatchDurationSeconds = value; }
        }

        /// <summary>
        /// LastPositionSeconds
        /// Vị trí phát cuối cùng trong phiên, đơn vị giây.
        /// </summary>
        public decimal LastPositionSeconds
        {
            get { return decLastPositionSeconds; }
            set { decLastPositionSeconds = value; }
        }

        /// <summary>
        /// MaxPositionSeconds
        /// Vị trí xa nhất đã xem trong phiên, đơn vị giây.
        /// </summary>
        public decimal MaxPositionSeconds
        {
            get { return decMaxPositionSeconds; }
            set { decMaxPositionSeconds = value; }
        }

        /// <summary>
        /// SeekCount
        /// Số lần tua video trong phiên.
        /// </summary>
        public int SeekCount
        {
            get { return intSeekCount; }
            set { intSeekCount = value; }
        }

        /// <summary>
        /// PauseCount
        /// Số lần tạm dừng video trong phiên.
        /// </summary>
        public int PauseCount
        {
            get { return intPauseCount; }
            set { intPauseCount = value; }
        }

        /// <summary>
        /// InteractionCount
        /// Số tương tác đã kích hoạt trong phiên.
        /// </summary>
        public int InteractionCount
        {
            get { return intInteractionCount; }
            set { intInteractionCount = value; }
        }

        /// <summary>
        /// Completed
        /// Cờ cho biết phiên đã hoàn thành nội dung học.
        /// </summary>
        public bool Completed
        {
            get { return bolCompleted; }
            set { bolCompleted = value; }
        }

        /// <summary>
        /// VideoVersionID
        /// ID phiên bản video được sử dụng trong phiên học.
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
                    if (reader.GetName(i).ToUpper().Equals(C_LearningSessionID.ToUpper()) && !Convert.IsDBNull(reader[C_LearningSessionID])) this.lngLearningSessionID = Convert.ToInt64(reader[C_LearningSessionID]);
                    if (reader.GetName(i).ToUpper().Equals(C_SessionId.ToUpper()) && !Convert.IsDBNull(reader[C_SessionId])) this.guiSessionId = (reader[C_SessionId] is Guid ? (Guid)reader[C_SessionId] : new Guid(Convert.ToString(reader[C_SessionId])));
                    if (reader.GetName(i).ToUpper().Equals(C_StudentUserID.ToUpper()) && !Convert.IsDBNull(reader[C_StudentUserID])) this.lngStudentUserID = Convert.ToInt64(reader[C_StudentUserID]);
                    if (reader.GetName(i).ToUpper().Equals(C_CourseId.ToUpper()) && !Convert.IsDBNull(reader[C_CourseId])) this.lngCourseId = Convert.ToInt64(reader[C_CourseId]);
                    if (reader.GetName(i).ToUpper().Equals(C_LessonId.ToUpper()) && !Convert.IsDBNull(reader[C_LessonId])) this.lngLessonId = Convert.ToInt64(reader[C_LessonId]);
                    if (reader.GetName(i).ToUpper().Equals(C_VideoId.ToUpper()) && !Convert.IsDBNull(reader[C_VideoId])) this.lngVideoId = Convert.ToInt64(reader[C_VideoId]);
                    if (reader.GetName(i).ToUpper().Equals(C_StartedAt.ToUpper()) && !Convert.IsDBNull(reader[C_StartedAt])) this.dtmStartedAt = Convert.ToDateTime(reader[C_StartedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_EndedAt.ToUpper()) && !Convert.IsDBNull(reader[C_EndedAt])) this.dtmEndedAt = Convert.ToDateTime(reader[C_EndedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_WatchDurationSeconds.ToUpper()) && !Convert.IsDBNull(reader[C_WatchDurationSeconds])) this.intWatchDurationSeconds = Convert.ToInt32(reader[C_WatchDurationSeconds]);
                    if (reader.GetName(i).ToUpper().Equals(C_LastPositionSeconds.ToUpper()) && !Convert.IsDBNull(reader[C_LastPositionSeconds])) this.decLastPositionSeconds = Convert.ToDecimal(reader[C_LastPositionSeconds]);
                    if (reader.GetName(i).ToUpper().Equals(C_MaxPositionSeconds.ToUpper()) && !Convert.IsDBNull(reader[C_MaxPositionSeconds])) this.decMaxPositionSeconds = Convert.ToDecimal(reader[C_MaxPositionSeconds]);
                    if (reader.GetName(i).ToUpper().Equals(C_SeekCount.ToUpper()) && !Convert.IsDBNull(reader[C_SeekCount])) this.intSeekCount = Convert.ToInt32(reader[C_SeekCount]);
                    if (reader.GetName(i).ToUpper().Equals(C_PauseCount.ToUpper()) && !Convert.IsDBNull(reader[C_PauseCount])) this.intPauseCount = Convert.ToInt32(reader[C_PauseCount]);
                    if (reader.GetName(i).ToUpper().Equals(C_InteractionCount.ToUpper()) && !Convert.IsDBNull(reader[C_InteractionCount])) this.intInteractionCount = Convert.ToInt32(reader[C_InteractionCount]);
                    if (reader.GetName(i).ToUpper().Equals(C_Completed.ToUpper()) && !Convert.IsDBNull(reader[C_Completed])) this.bolCompleted = Convert.ToBoolean(reader[C_Completed]);
                    if (reader.GetName(i).ToUpper().Equals(C_VideoVersionID.ToUpper()) && !Convert.IsDBNull(reader[C_VideoVersionID])) this.lngVideoVersionID = Convert.ToInt64(reader[C_VideoVersionID]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong LMS_LearningSessions", objEx);
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
                if (!Convert.IsDBNull(drw[C_LearningSessionID])) this.lngLearningSessionID = Convert.ToInt64(drw[C_LearningSessionID]);
                if (!Convert.IsDBNull(drw[C_SessionId])) this.guiSessionId = (drw[C_SessionId] is Guid ? (Guid)drw[C_SessionId] : new Guid(Convert.ToString(drw[C_SessionId])));
                if (!Convert.IsDBNull(drw[C_StudentUserID])) this.lngStudentUserID = Convert.ToInt64(drw[C_StudentUserID]);
                if (!Convert.IsDBNull(drw[C_CourseId])) this.lngCourseId = Convert.ToInt64(drw[C_CourseId]);
                if (!Convert.IsDBNull(drw[C_LessonId])) this.lngLessonId = Convert.ToInt64(drw[C_LessonId]);
                if (!Convert.IsDBNull(drw[C_VideoId])) this.lngVideoId = Convert.ToInt64(drw[C_VideoId]);
                if (!Convert.IsDBNull(drw[C_StartedAt])) this.dtmStartedAt = Convert.ToDateTime(drw[C_StartedAt]);
                if (!Convert.IsDBNull(drw[C_EndedAt])) this.dtmEndedAt = Convert.ToDateTime(drw[C_EndedAt]);
                if (!Convert.IsDBNull(drw[C_WatchDurationSeconds])) this.intWatchDurationSeconds = Convert.ToInt32(drw[C_WatchDurationSeconds]);
                if (!Convert.IsDBNull(drw[C_LastPositionSeconds])) this.decLastPositionSeconds = Convert.ToDecimal(drw[C_LastPositionSeconds]);
                if (!Convert.IsDBNull(drw[C_MaxPositionSeconds])) this.decMaxPositionSeconds = Convert.ToDecimal(drw[C_MaxPositionSeconds]);
                if (!Convert.IsDBNull(drw[C_SeekCount])) this.intSeekCount = Convert.ToInt32(drw[C_SeekCount]);
                if (!Convert.IsDBNull(drw[C_PauseCount])) this.intPauseCount = Convert.ToInt32(drw[C_PauseCount]);
                if (!Convert.IsDBNull(drw[C_InteractionCount])) this.intInteractionCount = Convert.ToInt32(drw[C_InteractionCount]);
                if (!Convert.IsDBNull(drw[C_Completed])) this.bolCompleted = Convert.ToBoolean(drw[C_Completed]);
                if (!Convert.IsDBNull(drw[C_VideoVersionID])) this.lngVideoVersionID = Convert.ToInt64(drw[C_VideoVersionID]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong LMS_LearningSessions", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: LMS_LearningSessions_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_LearningSessionID, this.lngLearningSessionID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin LMS_LearningSessions", objEx);
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
        /// Store: LMS_LearningSessions_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get(long lngLearningSessionID)
        {
            this.lngLearningSessionID = lngLearningSessionID;
            return this.Get();
        }

        ///<summary>
        ///Thêm mới dữ liệu
        /// Store: LMS_LearningSessions_ADD
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreAdd);
                objIData.AddParameter(P_SessionId, this.guiSessionId);
                objIData.AddParameter(P_StudentUserID, this.lngStudentUserID);
                objIData.AddParameter(P_CourseId, this.lngCourseId);
                objIData.AddParameter(P_LessonId, this.lngLessonId);
                objIData.AddParameter(P_VideoId, this.lngVideoId);
                objIData.AddParameter(P_StartedAt, this.dtmStartedAt);
                objIData.AddParameter(P_EndedAt, this.dtmEndedAt);
                objIData.AddParameter(P_WatchDurationSeconds, this.intWatchDurationSeconds);
                objIData.AddParameter(P_LastPositionSeconds, this.decLastPositionSeconds);
                objIData.AddParameter(P_MaxPositionSeconds, this.decMaxPositionSeconds);
                objIData.AddParameter(P_SeekCount, this.intSeekCount);
                objIData.AddParameter(P_PauseCount, this.intPauseCount);
                objIData.AddParameter(P_InteractionCount, this.intInteractionCount);
                objIData.AddParameter(P_Completed, this.bolCompleted);
                objIData.AddParameter(P_VideoVersionID, this.lngVideoVersionID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm mới thông tin trong LMS_LearningSessions", objEx);
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
        /// Store: LMS_LearningSessions_EDIT
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_LearningSessionID, this.lngLearningSessionID);
                objIData.AddParameter(P_SessionId, this.guiSessionId);
                objIData.AddParameter(P_StudentUserID, this.lngStudentUserID);
                objIData.AddParameter(P_CourseId, this.lngCourseId);
                objIData.AddParameter(P_LessonId, this.lngLessonId);
                objIData.AddParameter(P_VideoId, this.lngVideoId);
                objIData.AddParameter(P_StartedAt, this.dtmStartedAt);
                objIData.AddParameter(P_EndedAt, this.dtmEndedAt);
                objIData.AddParameter(P_WatchDurationSeconds, this.intWatchDurationSeconds);
                objIData.AddParameter(P_LastPositionSeconds, this.decLastPositionSeconds);
                objIData.AddParameter(P_MaxPositionSeconds, this.decMaxPositionSeconds);
                objIData.AddParameter(P_SeekCount, this.intSeekCount);
                objIData.AddParameter(P_PauseCount, this.intPauseCount);
                objIData.AddParameter(P_InteractionCount, this.intInteractionCount);
                objIData.AddParameter(P_Completed, this.bolCompleted);
                objIData.AddParameter(P_VideoVersionID, this.lngVideoVersionID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong LMS_LearningSessions", objEx);
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
        /// Store: LMS_LearningSessions_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_LearningSessionID, this.lngLearningSessionID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong LMS_LearningSessions", objEx);
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
        /// Store: LMS_LearningSessions_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long lngLearningSessionID)
        {
            this.lngLearningSessionID = lngLearningSessionID;
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

        public LMS_LearningSessions()
        {
        }
        public LMS_LearningSessions(long lngLearningSessionID)
        {
            this.lngLearningSessionID = lngLearningSessionID;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "LMS_LearningSessions";
        public const string StoreGet = "LMS_LearningSessions_GET";
        public const string StoreGetAll = "LMS_LearningSessions_GETALL";
        public const string StoreSearch = "LMS_LearningSessions_SEARCH";
        public const string StoreAdd = "LMS_LearningSessions_ADD";
        public const string StoreEdit = "LMS_LearningSessions_EDIT";
        public const string StoreDelete = "LMS_LearningSessions_DELETE";

        #region Parameter Names

        public const String P_LearningSessionID = "@" + C_LearningSessionID;
        public const String P_SessionId = "@" + C_SessionId;
        public const String P_StudentUserID = "@" + C_StudentUserID;
        public const String P_CourseId = "@" + C_CourseId;
        public const String P_LessonId = "@" + C_LessonId;
        public const String P_VideoId = "@" + C_VideoId;
        public const String P_StartedAt = "@" + C_StartedAt;
        public const String P_EndedAt = "@" + C_EndedAt;
        public const String P_WatchDurationSeconds = "@" + C_WatchDurationSeconds;
        public const String P_LastPositionSeconds = "@" + C_LastPositionSeconds;
        public const String P_MaxPositionSeconds = "@" + C_MaxPositionSeconds;
        public const String P_SeekCount = "@" + C_SeekCount;
        public const String P_PauseCount = "@" + C_PauseCount;
        public const String P_InteractionCount = "@" + C_InteractionCount;
        public const String P_Completed = "@" + C_Completed;
        public const String P_VideoVersionID = "@" + C_VideoVersionID;

        #endregion //Parameter names

        #region Column Names

        public const String C_LearningSessionID = "LearningSessionID";
        public const String C_SessionId = "SessionId";
        public const String C_StudentUserID = "StudentUserID";
        public const String C_CourseId = "CourseId";
        public const String C_LessonId = "LessonId";
        public const String C_VideoId = "VideoId";
        public const String C_StartedAt = "StartedAt";
        public const String C_EndedAt = "EndedAt";
        public const String C_WatchDurationSeconds = "WatchDurationSeconds";
        public const String C_LastPositionSeconds = "LastPositionSeconds";
        public const String C_MaxPositionSeconds = "MaxPositionSeconds";
        public const String C_SeekCount = "SeekCount";
        public const String C_PauseCount = "PauseCount";
        public const String C_InteractionCount = "InteractionCount";
        public const String C_Completed = "Completed";
        public const String C_VideoVersionID = "VideoVersionID";

        #endregion //Column names

        #endregion Variable Static
    }
}
