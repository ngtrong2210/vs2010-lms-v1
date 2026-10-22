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
    /// [LMS] Tiến độ và kết quả học tập theo từng bài học.
    /// </summary>
    public partial class LMS_StudentLessonProgress
    {
        #region Member Variables

        private long lngStudentLessonProgressID = 0;//Khóa chính tự tăng của tiến độ bài học.
        private long lngStudentUserID = 0;//ID học viên có tiến độ học.
        private long lngCourseId = 0;//ID khóa học chứa bài học.
        private long lngLessonId = 0;//ID bài học được theo dõi.
        private decimal decProgressPercent = 0;//Tỷ lệ phần trăm hoàn thành bài học.
        private decimal decScore = 0;//Điểm cao nhất hoặc hiện tại của bài học.
        private int intAttemptCount = 0;//Tổng số lần học viên thực hiện bài học.
        private bool bolCompleted = false;//Cờ cho biết bài học đã hoàn thành.
        private DateTime? dtmCompletedAt = null;//Thời điểm hoàn thành bài học theo UTC.
        private DateTime dtmLastAccessAt = DateTime.MinValue;//Thời điểm truy cập bài học gần nhất theo UTC.
        private DateTime dtmCreatedAt = DateTime.MinValue;//Thời điểm tạo bản ghi tiến độ theo UTC.
        private DateTime? dtmUpdatedAt = null;//Thời điểm cập nhật tiến độ gần nhất theo UTC.
        private int intActiveStudySeconds = 0;//Tổng số giây học hợp lệ được backend tổng hợp từ các phiên heartbeat.
        private decimal decReadingProgressPercent = 0;//Phần trăm nội dung học viên đã đọc.
        private decimal decLastScrollPercent = 0;//Vị trí cuộn gần nhất để khôi phục khi học tiếp.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// StudentLessonProgressID
        /// Khóa chính tự tăng của tiến độ bài học.
        /// </summary>
        public long StudentLessonProgressID
        {
            get { return lngStudentLessonProgressID; }
            set { lngStudentLessonProgressID = value; }
        }

        /// <summary>
        /// StudentUserID
        /// ID học viên có tiến độ học.
        /// </summary>
        public long StudentUserID
        {
            get { return lngStudentUserID; }
            set { lngStudentUserID = value; }
        }

        /// <summary>
        /// CourseId
        /// ID khóa học chứa bài học.
        /// </summary>
        public long CourseId
        {
            get { return lngCourseId; }
            set { lngCourseId = value; }
        }

        /// <summary>
        /// LessonId
        /// ID bài học được theo dõi.
        /// </summary>
        public long LessonId
        {
            get { return lngLessonId; }
            set { lngLessonId = value; }
        }

        /// <summary>
        /// ProgressPercent
        /// Tỷ lệ phần trăm hoàn thành bài học.
        /// </summary>
        public decimal ProgressPercent
        {
            get { return decProgressPercent; }
            set { decProgressPercent = value; }
        }

        /// <summary>
        /// Score
        /// Điểm cao nhất hoặc hiện tại của bài học.
        /// </summary>
        public decimal Score
        {
            get { return decScore; }
            set { decScore = value; }
        }

        /// <summary>
        /// AttemptCount
        /// Tổng số lần học viên thực hiện bài học.
        /// </summary>
        public int AttemptCount
        {
            get { return intAttemptCount; }
            set { intAttemptCount = value; }
        }

        /// <summary>
        /// Completed
        /// Cờ cho biết bài học đã hoàn thành.
        /// </summary>
        public bool Completed
        {
            get { return bolCompleted; }
            set { bolCompleted = value; }
        }

        /// <summary>
        /// CompletedAt
        /// Thời điểm hoàn thành bài học theo UTC.
        /// </summary>
        public DateTime? CompletedAt
        {
            get { return dtmCompletedAt; }
            set { dtmCompletedAt = value; }
        }

        /// <summary>
        /// LastAccessAt
        /// Thời điểm truy cập bài học gần nhất theo UTC.
        /// </summary>
        public DateTime LastAccessAt
        {
            get { return dtmLastAccessAt; }
            set { dtmLastAccessAt = value; }
        }

        /// <summary>
        /// CreatedAt
        /// Thời điểm tạo bản ghi tiến độ theo UTC.
        /// </summary>
        public DateTime CreatedAt
        {
            get { return dtmCreatedAt; }
            set { dtmCreatedAt = value; }
        }

        /// <summary>
        /// UpdatedAt
        /// Thời điểm cập nhật tiến độ gần nhất theo UTC.
        /// </summary>
        public DateTime? UpdatedAt
        {
            get { return dtmUpdatedAt; }
            set { dtmUpdatedAt = value; }
        }

        /// <summary>
        /// ActiveStudySeconds
        /// Tổng số giây học hợp lệ được backend tổng hợp từ các phiên heartbeat.
        /// </summary>
        public int ActiveStudySeconds
        {
            get { return intActiveStudySeconds; }
            set { intActiveStudySeconds = value; }
        }

        /// <summary>
        /// ReadingProgressPercent
        /// Phần trăm nội dung học viên đã đọc.
        /// </summary>
        public decimal ReadingProgressPercent
        {
            get { return decReadingProgressPercent; }
            set { decReadingProgressPercent = value; }
        }

        /// <summary>
        /// LastScrollPercent
        /// Vị trí cuộn gần nhất để khôi phục khi học tiếp.
        /// </summary>
        public decimal LastScrollPercent
        {
            get { return decLastScrollPercent; }
            set { decLastScrollPercent = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_StudentLessonProgressID.ToUpper()) && !Convert.IsDBNull(reader[C_StudentLessonProgressID])) this.lngStudentLessonProgressID = Convert.ToInt64(reader[C_StudentLessonProgressID]);
                    if (reader.GetName(i).ToUpper().Equals(C_StudentUserID.ToUpper()) && !Convert.IsDBNull(reader[C_StudentUserID])) this.lngStudentUserID = Convert.ToInt64(reader[C_StudentUserID]);
                    if (reader.GetName(i).ToUpper().Equals(C_CourseId.ToUpper()) && !Convert.IsDBNull(reader[C_CourseId])) this.lngCourseId = Convert.ToInt64(reader[C_CourseId]);
                    if (reader.GetName(i).ToUpper().Equals(C_LessonId.ToUpper()) && !Convert.IsDBNull(reader[C_LessonId])) this.lngLessonId = Convert.ToInt64(reader[C_LessonId]);
                    if (reader.GetName(i).ToUpper().Equals(C_ProgressPercent.ToUpper()) && !Convert.IsDBNull(reader[C_ProgressPercent])) this.decProgressPercent = Convert.ToDecimal(reader[C_ProgressPercent]);
                    if (reader.GetName(i).ToUpper().Equals(C_Score.ToUpper()) && !Convert.IsDBNull(reader[C_Score])) this.decScore = Convert.ToDecimal(reader[C_Score]);
                    if (reader.GetName(i).ToUpper().Equals(C_AttemptCount.ToUpper()) && !Convert.IsDBNull(reader[C_AttemptCount])) this.intAttemptCount = Convert.ToInt32(reader[C_AttemptCount]);
                    if (reader.GetName(i).ToUpper().Equals(C_Completed.ToUpper()) && !Convert.IsDBNull(reader[C_Completed])) this.bolCompleted = Convert.ToBoolean(reader[C_Completed]);
                    if (reader.GetName(i).ToUpper().Equals(C_CompletedAt.ToUpper()) && !Convert.IsDBNull(reader[C_CompletedAt])) this.dtmCompletedAt = Convert.ToDateTime(reader[C_CompletedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_LastAccessAt.ToUpper()) && !Convert.IsDBNull(reader[C_LastAccessAt])) this.dtmLastAccessAt = Convert.ToDateTime(reader[C_LastAccessAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(reader[C_CreatedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedAt])) this.dtmUpdatedAt = Convert.ToDateTime(reader[C_UpdatedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_ActiveStudySeconds.ToUpper()) && !Convert.IsDBNull(reader[C_ActiveStudySeconds])) this.intActiveStudySeconds = Convert.ToInt32(reader[C_ActiveStudySeconds]);
                    if (reader.GetName(i).ToUpper().Equals(C_ReadingProgressPercent.ToUpper()) && !Convert.IsDBNull(reader[C_ReadingProgressPercent])) this.decReadingProgressPercent = Convert.ToDecimal(reader[C_ReadingProgressPercent]);
                    if (reader.GetName(i).ToUpper().Equals(C_LastScrollPercent.ToUpper()) && !Convert.IsDBNull(reader[C_LastScrollPercent])) this.decLastScrollPercent = Convert.ToDecimal(reader[C_LastScrollPercent]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong LMS_StudentLessonProgress", objEx);
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
                if (!Convert.IsDBNull(drw[C_StudentLessonProgressID])) this.lngStudentLessonProgressID = Convert.ToInt64(drw[C_StudentLessonProgressID]);
                if (!Convert.IsDBNull(drw[C_StudentUserID])) this.lngStudentUserID = Convert.ToInt64(drw[C_StudentUserID]);
                if (!Convert.IsDBNull(drw[C_CourseId])) this.lngCourseId = Convert.ToInt64(drw[C_CourseId]);
                if (!Convert.IsDBNull(drw[C_LessonId])) this.lngLessonId = Convert.ToInt64(drw[C_LessonId]);
                if (!Convert.IsDBNull(drw[C_ProgressPercent])) this.decProgressPercent = Convert.ToDecimal(drw[C_ProgressPercent]);
                if (!Convert.IsDBNull(drw[C_Score])) this.decScore = Convert.ToDecimal(drw[C_Score]);
                if (!Convert.IsDBNull(drw[C_AttemptCount])) this.intAttemptCount = Convert.ToInt32(drw[C_AttemptCount]);
                if (!Convert.IsDBNull(drw[C_Completed])) this.bolCompleted = Convert.ToBoolean(drw[C_Completed]);
                if (!Convert.IsDBNull(drw[C_CompletedAt])) this.dtmCompletedAt = Convert.ToDateTime(drw[C_CompletedAt]);
                if (!Convert.IsDBNull(drw[C_LastAccessAt])) this.dtmLastAccessAt = Convert.ToDateTime(drw[C_LastAccessAt]);
                if (!Convert.IsDBNull(drw[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(drw[C_CreatedAt]);
                if (!Convert.IsDBNull(drw[C_UpdatedAt])) this.dtmUpdatedAt = Convert.ToDateTime(drw[C_UpdatedAt]);
                if (!Convert.IsDBNull(drw[C_ActiveStudySeconds])) this.intActiveStudySeconds = Convert.ToInt32(drw[C_ActiveStudySeconds]);
                if (!Convert.IsDBNull(drw[C_ReadingProgressPercent])) this.decReadingProgressPercent = Convert.ToDecimal(drw[C_ReadingProgressPercent]);
                if (!Convert.IsDBNull(drw[C_LastScrollPercent])) this.decLastScrollPercent = Convert.ToDecimal(drw[C_LastScrollPercent]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong LMS_StudentLessonProgress", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: LMS_StudentLessonProgress_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_StudentLessonProgressID, this.lngStudentLessonProgressID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin LMS_StudentLessonProgress", objEx);
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
        /// Store: LMS_StudentLessonProgress_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get(long lngStudentLessonProgressID)
        {
            this.lngStudentLessonProgressID = lngStudentLessonProgressID;
            return this.Get();
        }

        ///<summary>
        ///Thêm mới dữ liệu
        /// Store: LMS_StudentLessonProgress_ADD
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
                objIData.AddParameter(P_ProgressPercent, this.decProgressPercent);
                objIData.AddParameter(P_Score, this.decScore);
                objIData.AddParameter(P_AttemptCount, this.intAttemptCount);
                objIData.AddParameter(P_Completed, this.bolCompleted);
                objIData.AddParameter(P_CompletedAt, this.dtmCompletedAt);
                objIData.AddParameter(P_LastAccessAt, this.dtmLastAccessAt);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_UpdatedAt, this.dtmUpdatedAt);
                objIData.AddParameter(P_ActiveStudySeconds, this.intActiveStudySeconds);
                objIData.AddParameter(P_ReadingProgressPercent, this.decReadingProgressPercent);
                objIData.AddParameter(P_LastScrollPercent, this.decLastScrollPercent);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm mới thông tin trong LMS_StudentLessonProgress", objEx);
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
        /// Store: LMS_StudentLessonProgress_EDIT
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_StudentLessonProgressID, this.lngStudentLessonProgressID);
                objIData.AddParameter(P_StudentUserID, this.lngStudentUserID);
                objIData.AddParameter(P_CourseId, this.lngCourseId);
                objIData.AddParameter(P_LessonId, this.lngLessonId);
                objIData.AddParameter(P_ProgressPercent, this.decProgressPercent);
                objIData.AddParameter(P_Score, this.decScore);
                objIData.AddParameter(P_AttemptCount, this.intAttemptCount);
                objIData.AddParameter(P_Completed, this.bolCompleted);
                objIData.AddParameter(P_CompletedAt, this.dtmCompletedAt);
                objIData.AddParameter(P_LastAccessAt, this.dtmLastAccessAt);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_UpdatedAt, this.dtmUpdatedAt);
                objIData.AddParameter(P_ActiveStudySeconds, this.intActiveStudySeconds);
                objIData.AddParameter(P_ReadingProgressPercent, this.decReadingProgressPercent);
                objIData.AddParameter(P_LastScrollPercent, this.decLastScrollPercent);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong LMS_StudentLessonProgress", objEx);
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
        /// Store: LMS_StudentLessonProgress_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_StudentLessonProgressID, this.lngStudentLessonProgressID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong LMS_StudentLessonProgress", objEx);
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
        /// Store: LMS_StudentLessonProgress_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long lngStudentLessonProgressID)
        {
            this.lngStudentLessonProgressID = lngStudentLessonProgressID;
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

        public LMS_StudentLessonProgress()
        {
        }
        public LMS_StudentLessonProgress(long lngStudentLessonProgressID)
        {
            this.lngStudentLessonProgressID = lngStudentLessonProgressID;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "LMS_StudentLessonProgress";
        public const string StoreGet = "LMS_StudentLessonProgress_GET";
        public const string StoreGetAll = "LMS_StudentLessonProgress_GETALL";
        public const string StoreSearch = "LMS_StudentLessonProgress_SEARCH";
        public const string StoreAdd = "LMS_StudentLessonProgress_ADD";
        public const string StoreEdit = "LMS_StudentLessonProgress_EDIT";
        public const string StoreDelete = "LMS_StudentLessonProgress_DELETE";

        #region Parameter Names

        public const String P_StudentLessonProgressID = "@" + C_StudentLessonProgressID;
        public const String P_StudentUserID = "@" + C_StudentUserID;
        public const String P_CourseId = "@" + C_CourseId;
        public const String P_LessonId = "@" + C_LessonId;
        public const String P_ProgressPercent = "@" + C_ProgressPercent;
        public const String P_Score = "@" + C_Score;
        public const String P_AttemptCount = "@" + C_AttemptCount;
        public const String P_Completed = "@" + C_Completed;
        public const String P_CompletedAt = "@" + C_CompletedAt;
        public const String P_LastAccessAt = "@" + C_LastAccessAt;
        public const String P_CreatedAt = "@" + C_CreatedAt;
        public const String P_UpdatedAt = "@" + C_UpdatedAt;
        public const String P_ActiveStudySeconds = "@" + C_ActiveStudySeconds;
        public const String P_ReadingProgressPercent = "@" + C_ReadingProgressPercent;
        public const String P_LastScrollPercent = "@" + C_LastScrollPercent;

        #endregion //Parameter names

        #region Column Names

        public const String C_StudentLessonProgressID = "StudentLessonProgressID";
        public const String C_StudentUserID = "StudentUserID";
        public const String C_CourseId = "CourseId";
        public const String C_LessonId = "LessonId";
        public const String C_ProgressPercent = "ProgressPercent";
        public const String C_Score = "Score";
        public const String C_AttemptCount = "AttemptCount";
        public const String C_Completed = "Completed";
        public const String C_CompletedAt = "CompletedAt";
        public const String C_LastAccessAt = "LastAccessAt";
        public const String C_CreatedAt = "CreatedAt";
        public const String C_UpdatedAt = "UpdatedAt";
        public const String C_ActiveStudySeconds = "ActiveStudySeconds";
        public const String C_ReadingProgressPercent = "ReadingProgressPercent";
        public const String C_LastScrollPercent = "LastScrollPercent";

        #endregion //Column names

        #endregion Variable Static
    }
}
