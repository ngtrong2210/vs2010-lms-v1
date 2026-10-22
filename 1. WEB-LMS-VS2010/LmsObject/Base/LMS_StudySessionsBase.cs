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
    /// [LMS] Phiên đo thời gian học viên ở lại môn học, chương hoặc bài học.
    /// </summary>
    public partial class LMS_StudySessions
    {
        #region Member Variables

        private Guid guiStudySessionID = Guid.Empty;//Cột StudySessionID của bảng LMS_StudySessions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private long lngStudentUserID = 0;//Cột StudentUserID của bảng LMS_StudySessions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private long? lngClassSubjectID = null;//Cột ClassSubjectID của bảng LMS_StudySessions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private long? lngCourseID = null;//Cột CourseID của bảng LMS_StudySessions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private long? lngChapterID = null;//Cột ChapterID của bảng LMS_StudySessions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private long? lngLessonID = null;//Cột LessonID của bảng LMS_StudySessions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private DateTime dtmStartedAt = DateTime.MinValue;//Cột StartedAt của bảng LMS_StudySessions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private DateTime dtmLastHeartbeatAt = DateTime.MinValue;//Thời điểm gần nhất trình duyệt xác nhận học viên vẫn đang ở trang học.
        private DateTime? dtmEndedAt = null;//Cột EndedAt của bảng LMS_StudySessions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private int intActiveDurationSeconds = 0;//Tổng số giây hoạt động hợp lệ, được cộng qua mỗi heartbeat.
        private string strPageUrl = null;//Cột PageUrl của bảng LMS_StudySessions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private string strClientSessionKey = null;//Cột ClientSessionKey của bảng LMS_StudySessions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private bool bolIsCompleted = false;//Cột IsCompleted của bảng LMS_StudySessions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private bool bolIsAggregated = false;//Cờ cho biết thời lượng phiên đã được cộng vào tiến độ bài học.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// StudySessionID
        /// Cột StudySessionID của bảng LMS_StudySessions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public Guid StudySessionID
        {
            get { return guiStudySessionID; }
            set { guiStudySessionID = value; }
        }

        /// <summary>
        /// StudentUserID
        /// Cột StudentUserID của bảng LMS_StudySessions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public long StudentUserID
        {
            get { return lngStudentUserID; }
            set { lngStudentUserID = value; }
        }

        /// <summary>
        /// ClassSubjectID
        /// Cột ClassSubjectID của bảng LMS_StudySessions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public long? ClassSubjectID
        {
            get { return lngClassSubjectID; }
            set { lngClassSubjectID = value; }
        }

        /// <summary>
        /// CourseID
        /// Cột CourseID của bảng LMS_StudySessions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public long? CourseID
        {
            get { return lngCourseID; }
            set { lngCourseID = value; }
        }

        /// <summary>
        /// ChapterID
        /// Cột ChapterID của bảng LMS_StudySessions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public long? ChapterID
        {
            get { return lngChapterID; }
            set { lngChapterID = value; }
        }

        /// <summary>
        /// LessonID
        /// Cột LessonID của bảng LMS_StudySessions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public long? LessonID
        {
            get { return lngLessonID; }
            set { lngLessonID = value; }
        }

        /// <summary>
        /// StartedAt
        /// Cột StartedAt của bảng LMS_StudySessions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public DateTime StartedAt
        {
            get { return dtmStartedAt; }
            set { dtmStartedAt = value; }
        }

        /// <summary>
        /// LastHeartbeatAt
        /// Thời điểm gần nhất trình duyệt xác nhận học viên vẫn đang ở trang học.
        /// </summary>
        public DateTime LastHeartbeatAt
        {
            get { return dtmLastHeartbeatAt; }
            set { dtmLastHeartbeatAt = value; }
        }

        /// <summary>
        /// EndedAt
        /// Cột EndedAt của bảng LMS_StudySessions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public DateTime? EndedAt
        {
            get { return dtmEndedAt; }
            set { dtmEndedAt = value; }
        }

        /// <summary>
        /// ActiveDurationSeconds
        /// Tổng số giây hoạt động hợp lệ, được cộng qua mỗi heartbeat.
        /// </summary>
        public int ActiveDurationSeconds
        {
            get { return intActiveDurationSeconds; }
            set { intActiveDurationSeconds = value; }
        }

        /// <summary>
        /// PageUrl
        /// Cột PageUrl của bảng LMS_StudySessions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public string PageUrl
        {
            get { return strPageUrl; }
            set { strPageUrl = value; }
        }

        /// <summary>
        /// ClientSessionKey
        /// Cột ClientSessionKey của bảng LMS_StudySessions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public string ClientSessionKey
        {
            get { return strClientSessionKey; }
            set { strClientSessionKey = value; }
        }

        /// <summary>
        /// IsCompleted
        /// Cột IsCompleted của bảng LMS_StudySessions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public bool IsCompleted
        {
            get { return bolIsCompleted; }
            set { bolIsCompleted = value; }
        }

        /// <summary>
        /// IsAggregated
        /// Cờ cho biết thời lượng phiên đã được cộng vào tiến độ bài học.
        /// </summary>
        public bool IsAggregated
        {
            get { return bolIsAggregated; }
            set { bolIsAggregated = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_StudySessionID.ToUpper()) && !Convert.IsDBNull(reader[C_StudySessionID])) this.guiStudySessionID = (reader[C_StudySessionID] is Guid ? (Guid)reader[C_StudySessionID] : new Guid(Convert.ToString(reader[C_StudySessionID])));
                    if (reader.GetName(i).ToUpper().Equals(C_StudentUserID.ToUpper()) && !Convert.IsDBNull(reader[C_StudentUserID])) this.lngStudentUserID = Convert.ToInt64(reader[C_StudentUserID]);
                    if (reader.GetName(i).ToUpper().Equals(C_ClassSubjectID.ToUpper()) && !Convert.IsDBNull(reader[C_ClassSubjectID])) this.lngClassSubjectID = Convert.ToInt64(reader[C_ClassSubjectID]);
                    if (reader.GetName(i).ToUpper().Equals(C_CourseID.ToUpper()) && !Convert.IsDBNull(reader[C_CourseID])) this.lngCourseID = Convert.ToInt64(reader[C_CourseID]);
                    if (reader.GetName(i).ToUpper().Equals(C_ChapterID.ToUpper()) && !Convert.IsDBNull(reader[C_ChapterID])) this.lngChapterID = Convert.ToInt64(reader[C_ChapterID]);
                    if (reader.GetName(i).ToUpper().Equals(C_LessonID.ToUpper()) && !Convert.IsDBNull(reader[C_LessonID])) this.lngLessonID = Convert.ToInt64(reader[C_LessonID]);
                    if (reader.GetName(i).ToUpper().Equals(C_StartedAt.ToUpper()) && !Convert.IsDBNull(reader[C_StartedAt])) this.dtmStartedAt = Convert.ToDateTime(reader[C_StartedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_LastHeartbeatAt.ToUpper()) && !Convert.IsDBNull(reader[C_LastHeartbeatAt])) this.dtmLastHeartbeatAt = Convert.ToDateTime(reader[C_LastHeartbeatAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_EndedAt.ToUpper()) && !Convert.IsDBNull(reader[C_EndedAt])) this.dtmEndedAt = Convert.ToDateTime(reader[C_EndedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_ActiveDurationSeconds.ToUpper()) && !Convert.IsDBNull(reader[C_ActiveDurationSeconds])) this.intActiveDurationSeconds = Convert.ToInt32(reader[C_ActiveDurationSeconds]);
                    if (reader.GetName(i).ToUpper().Equals(C_PageUrl.ToUpper()) && !Convert.IsDBNull(reader[C_PageUrl])) this.strPageUrl = Convert.ToString(reader[C_PageUrl]);
                    if (reader.GetName(i).ToUpper().Equals(C_ClientSessionKey.ToUpper()) && !Convert.IsDBNull(reader[C_ClientSessionKey])) this.strClientSessionKey = Convert.ToString(reader[C_ClientSessionKey]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsCompleted.ToUpper()) && !Convert.IsDBNull(reader[C_IsCompleted])) this.bolIsCompleted = Convert.ToBoolean(reader[C_IsCompleted]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsAggregated.ToUpper()) && !Convert.IsDBNull(reader[C_IsAggregated])) this.bolIsAggregated = Convert.ToBoolean(reader[C_IsAggregated]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong LMS_StudySessions", objEx);
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
                if (!Convert.IsDBNull(drw[C_StudySessionID])) this.guiStudySessionID = (drw[C_StudySessionID] is Guid ? (Guid)drw[C_StudySessionID] : new Guid(Convert.ToString(drw[C_StudySessionID])));
                if (!Convert.IsDBNull(drw[C_StudentUserID])) this.lngStudentUserID = Convert.ToInt64(drw[C_StudentUserID]);
                if (!Convert.IsDBNull(drw[C_ClassSubjectID])) this.lngClassSubjectID = Convert.ToInt64(drw[C_ClassSubjectID]);
                if (!Convert.IsDBNull(drw[C_CourseID])) this.lngCourseID = Convert.ToInt64(drw[C_CourseID]);
                if (!Convert.IsDBNull(drw[C_ChapterID])) this.lngChapterID = Convert.ToInt64(drw[C_ChapterID]);
                if (!Convert.IsDBNull(drw[C_LessonID])) this.lngLessonID = Convert.ToInt64(drw[C_LessonID]);
                if (!Convert.IsDBNull(drw[C_StartedAt])) this.dtmStartedAt = Convert.ToDateTime(drw[C_StartedAt]);
                if (!Convert.IsDBNull(drw[C_LastHeartbeatAt])) this.dtmLastHeartbeatAt = Convert.ToDateTime(drw[C_LastHeartbeatAt]);
                if (!Convert.IsDBNull(drw[C_EndedAt])) this.dtmEndedAt = Convert.ToDateTime(drw[C_EndedAt]);
                if (!Convert.IsDBNull(drw[C_ActiveDurationSeconds])) this.intActiveDurationSeconds = Convert.ToInt32(drw[C_ActiveDurationSeconds]);
                if (!Convert.IsDBNull(drw[C_PageUrl])) this.strPageUrl = Convert.ToString(drw[C_PageUrl]);
                if (!Convert.IsDBNull(drw[C_ClientSessionKey])) this.strClientSessionKey = Convert.ToString(drw[C_ClientSessionKey]);
                if (!Convert.IsDBNull(drw[C_IsCompleted])) this.bolIsCompleted = Convert.ToBoolean(drw[C_IsCompleted]);
                if (!Convert.IsDBNull(drw[C_IsAggregated])) this.bolIsAggregated = Convert.ToBoolean(drw[C_IsAggregated]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong LMS_StudySessions", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: LMS_StudySessions_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_StudySessionID, this.guiStudySessionID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin LMS_StudySessions", objEx);
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
        /// Store: LMS_StudySessions_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get(Guid guiStudySessionID)
        {
            this.guiStudySessionID = guiStudySessionID;
            return this.Get();
        }

        ///<summary>
        ///Thêm mới dữ liệu
        /// Store: LMS_StudySessions_ADD
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreAdd);
                objIData.AddParameter(P_StudySessionID, this.guiStudySessionID);
                objIData.AddParameter(P_StudentUserID, this.lngStudentUserID);
                objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
                objIData.AddParameter(P_CourseID, this.lngCourseID);
                objIData.AddParameter(P_ChapterID, this.lngChapterID);
                objIData.AddParameter(P_LessonID, this.lngLessonID);
                objIData.AddParameter(P_StartedAt, this.dtmStartedAt);
                objIData.AddParameter(P_LastHeartbeatAt, this.dtmLastHeartbeatAt);
                objIData.AddParameter(P_EndedAt, this.dtmEndedAt);
                objIData.AddParameter(P_ActiveDurationSeconds, this.intActiveDurationSeconds);
                objIData.AddParameter(P_PageUrl, this.strPageUrl);
                objIData.AddParameter(P_ClientSessionKey, this.strClientSessionKey);
                objIData.AddParameter(P_IsCompleted, this.bolIsCompleted);
                objIData.AddParameter(P_IsAggregated, this.bolIsAggregated);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm mới thông tin trong LMS_StudySessions", objEx);
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
        /// Store: LMS_StudySessions_EDIT
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_StudySessionID, this.guiStudySessionID);
                objIData.AddParameter(P_StudentUserID, this.lngStudentUserID);
                objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
                objIData.AddParameter(P_CourseID, this.lngCourseID);
                objIData.AddParameter(P_ChapterID, this.lngChapterID);
                objIData.AddParameter(P_LessonID, this.lngLessonID);
                objIData.AddParameter(P_StartedAt, this.dtmStartedAt);
                objIData.AddParameter(P_LastHeartbeatAt, this.dtmLastHeartbeatAt);
                objIData.AddParameter(P_EndedAt, this.dtmEndedAt);
                objIData.AddParameter(P_ActiveDurationSeconds, this.intActiveDurationSeconds);
                objIData.AddParameter(P_PageUrl, this.strPageUrl);
                objIData.AddParameter(P_ClientSessionKey, this.strClientSessionKey);
                objIData.AddParameter(P_IsCompleted, this.bolIsCompleted);
                objIData.AddParameter(P_IsAggregated, this.bolIsAggregated);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong LMS_StudySessions", objEx);
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
        /// Store: LMS_StudySessions_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_StudySessionID, this.guiStudySessionID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong LMS_StudySessions", objEx);
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
        /// Store: LMS_StudySessions_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(Guid guiStudySessionID)
        {
            this.guiStudySessionID = guiStudySessionID;
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

        public LMS_StudySessions()
        {
        }
        public LMS_StudySessions(Guid guiStudySessionID)
        {
            this.guiStudySessionID = guiStudySessionID;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "LMS_StudySessions";
        public const string StoreGet = "LMS_StudySessions_GET";
        public const string StoreGetAll = "LMS_StudySessions_GETALL";
        public const string StoreSearch = "LMS_StudySessions_SEARCH";
        public const string StoreAdd = "LMS_StudySessions_ADD";
        public const string StoreEdit = "LMS_StudySessions_EDIT";
        public const string StoreDelete = "LMS_StudySessions_DELETE";

        #region Parameter Names

        public const String P_StudySessionID = "@" + C_StudySessionID;
        public const String P_StudentUserID = "@" + C_StudentUserID;
        public const String P_ClassSubjectID = "@" + C_ClassSubjectID;
        public const String P_CourseID = "@" + C_CourseID;
        public const String P_ChapterID = "@" + C_ChapterID;
        public const String P_LessonID = "@" + C_LessonID;
        public const String P_StartedAt = "@" + C_StartedAt;
        public const String P_LastHeartbeatAt = "@" + C_LastHeartbeatAt;
        public const String P_EndedAt = "@" + C_EndedAt;
        public const String P_ActiveDurationSeconds = "@" + C_ActiveDurationSeconds;
        public const String P_PageUrl = "@" + C_PageUrl;
        public const String P_ClientSessionKey = "@" + C_ClientSessionKey;
        public const String P_IsCompleted = "@" + C_IsCompleted;
        public const String P_IsAggregated = "@" + C_IsAggregated;

        #endregion //Parameter names

        #region Column Names

        public const String C_StudySessionID = "StudySessionID";
        public const String C_StudentUserID = "StudentUserID";
        public const String C_ClassSubjectID = "ClassSubjectID";
        public const String C_CourseID = "CourseID";
        public const String C_ChapterID = "ChapterID";
        public const String C_LessonID = "LessonID";
        public const String C_StartedAt = "StartedAt";
        public const String C_LastHeartbeatAt = "LastHeartbeatAt";
        public const String C_EndedAt = "EndedAt";
        public const String C_ActiveDurationSeconds = "ActiveDurationSeconds";
        public const String C_PageUrl = "PageUrl";
        public const String C_ClientSessionKey = "ClientSessionKey";
        public const String C_IsCompleted = "IsCompleted";
        public const String C_IsAggregated = "IsAggregated";

        #endregion //Column names

        #endregion Variable Static
    }
}
