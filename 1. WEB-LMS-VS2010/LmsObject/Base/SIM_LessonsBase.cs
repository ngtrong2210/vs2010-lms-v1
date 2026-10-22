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
    /// [SIM] Các bài học thuộc chương và khóa học.
    /// </summary>
    public partial class SIM_Lessons
    {
        #region Member Variables

        private long lngLessonID = 0;//Khóa chính tự tăng của bài học.
        private long lngCourseId = 0;//ID khóa học chứa bài học.
        private long lngChapterId = 0;//ID chương chứa bài học.
        private string strTitle = null;//Tên hiển thị của bài học.
        private string strDescription = null;//Mô tả nội dung của bài học.
        private string strLessonType = null;//Loại bài học: VIDEO, INTERACTIVE_VIDEO, QUIZ hoặc DOCUMENT.
        private int intDurationSeconds = 0;//Thời lượng dự kiến của bài học tính bằng giây.
        private int intSortOrder = 0;//Thứ tự hiển thị của bài học trong chương.
        private bool bolIsRequired = false;//Cờ cho biết bài học có bắt buộc hoàn thành hay không.
        private decimal? decPassingScore = null;//Điểm tối thiểu để đạt bài học; rỗng nếu không áp dụng.
        private string strStatus = null;//Trạng thái sử dụng của bài học.
        private DateTime dtmCreatedAt = DateTime.MinValue;//Thời điểm tạo bài học theo UTC.
        private DateTime? dtmUpdatedAt = null;//Thời điểm cập nhật bài học gần nhất theo UTC.
        private bool bolIsDeleted = false;//Cờ xóa mềm của bài học.
        private long? lngVideoID = null;//ID video tương tác độc lập được bài học tham chiếu; nhiều bài học có thể dùng chung một video.
        private long? lngVideoVersionID = null;//ID phiên bản video được bài học ghim; thay phiên bản khác không ảnh hưởng bài học này.
        private string strContentHtml = null;//Nội dung bài học được giảng viên soạn bằng trình biên tập.
        private string strDocumentUrl = null;//Đường dẫn tài liệu chính của bài học trong /Media/File/.
        private string strAssignmentFolderName = null;//Tên thư mục bài tập dùng tổ chức file nộp của học viên.
        private DateTime? dtmDueAt = null;//Hạn cuối nộp bài tập.
        private int intMaxSubmissionFileSizeMB = 0;//Dung lượng tối đa tính bằng MB cho mỗi file bài nộp.
        private bool bolAllowLateSubmission = false;//Cho phép học viên nộp bài sau hạn hay không.
        private DateTime? dtmAssignmentStartAt = null;//Thời điểm học viên bắt đầu được nộp bài tập.
        private decimal decAssignmentMaxScore = 0;//Điểm tối đa giáo viên có thể chấm cho bài tập.
        private int intMaxSubmissionAttempts = 0;//Số lần nộp tối đa được phép cho bài tập.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// LessonID
        /// Khóa chính tự tăng của bài học.
        /// </summary>
        public long LessonID
        {
            get { return lngLessonID; }
            set { lngLessonID = value; }
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
        /// ChapterId
        /// ID chương chứa bài học.
        /// </summary>
        public long ChapterId
        {
            get { return lngChapterId; }
            set { lngChapterId = value; }
        }

        /// <summary>
        /// Title
        /// Tên hiển thị của bài học.
        /// </summary>
        public string Title
        {
            get { return strTitle; }
            set { strTitle = value; }
        }

        /// <summary>
        /// Description
        /// Mô tả nội dung của bài học.
        /// </summary>
        public string Description
        {
            get { return strDescription; }
            set { strDescription = value; }
        }

        /// <summary>
        /// LessonType
        /// Loại bài học: VIDEO, INTERACTIVE_VIDEO, QUIZ hoặc DOCUMENT.
        /// </summary>
        public string LessonType
        {
            get { return strLessonType; }
            set { strLessonType = value; }
        }

        /// <summary>
        /// DurationSeconds
        /// Thời lượng dự kiến của bài học tính bằng giây.
        /// </summary>
        public int DurationSeconds
        {
            get { return intDurationSeconds; }
            set { intDurationSeconds = value; }
        }

        /// <summary>
        /// SortOrder
        /// Thứ tự hiển thị của bài học trong chương.
        /// </summary>
        public int SortOrder
        {
            get { return intSortOrder; }
            set { intSortOrder = value; }
        }

        /// <summary>
        /// IsRequired
        /// Cờ cho biết bài học có bắt buộc hoàn thành hay không.
        /// </summary>
        public bool IsRequired
        {
            get { return bolIsRequired; }
            set { bolIsRequired = value; }
        }

        /// <summary>
        /// PassingScore
        /// Điểm tối thiểu để đạt bài học; rỗng nếu không áp dụng.
        /// </summary>
        public decimal? PassingScore
        {
            get { return decPassingScore; }
            set { decPassingScore = value; }
        }

        /// <summary>
        /// Status
        /// Trạng thái sử dụng của bài học.
        /// </summary>
        public string Status
        {
            get { return strStatus; }
            set { strStatus = value; }
        }

        /// <summary>
        /// CreatedAt
        /// Thời điểm tạo bài học theo UTC.
        /// </summary>
        public DateTime CreatedAt
        {
            get { return dtmCreatedAt; }
            set { dtmCreatedAt = value; }
        }

        /// <summary>
        /// UpdatedAt
        /// Thời điểm cập nhật bài học gần nhất theo UTC.
        /// </summary>
        public DateTime? UpdatedAt
        {
            get { return dtmUpdatedAt; }
            set { dtmUpdatedAt = value; }
        }

        /// <summary>
        /// IsDeleted
        /// Cờ xóa mềm của bài học.
        /// </summary>
        public bool IsDeleted
        {
            get { return bolIsDeleted; }
            set { bolIsDeleted = value; }
        }

        /// <summary>
        /// VideoID
        /// ID video tương tác độc lập được bài học tham chiếu; nhiều bài học có thể dùng chung một video.
        /// </summary>
        public long? VideoID
        {
            get { return lngVideoID; }
            set { lngVideoID = value; }
        }

        /// <summary>
        /// VideoVersionID
        /// ID phiên bản video được bài học ghim; thay phiên bản khác không ảnh hưởng bài học này.
        /// </summary>
        public long? VideoVersionID
        {
            get { return lngVideoVersionID; }
            set { lngVideoVersionID = value; }
        }

        /// <summary>
        /// ContentHtml
        /// Nội dung bài học được giảng viên soạn bằng trình biên tập.
        /// </summary>
        public string ContentHtml
        {
            get { return strContentHtml; }
            set { strContentHtml = value; }
        }

        /// <summary>
        /// DocumentUrl
        /// Đường dẫn tài liệu chính của bài học trong /Media/File/.
        /// </summary>
        public string DocumentUrl
        {
            get { return strDocumentUrl; }
            set { strDocumentUrl = value; }
        }

        /// <summary>
        /// AssignmentFolderName
        /// Tên thư mục bài tập dùng tổ chức file nộp của học viên.
        /// </summary>
        public string AssignmentFolderName
        {
            get { return strAssignmentFolderName; }
            set { strAssignmentFolderName = value; }
        }

        /// <summary>
        /// DueAt
        /// Hạn cuối nộp bài tập.
        /// </summary>
        public DateTime? DueAt
        {
            get { return dtmDueAt; }
            set { dtmDueAt = value; }
        }

        /// <summary>
        /// MaxSubmissionFileSizeMB
        /// Dung lượng tối đa tính bằng MB cho mỗi file bài nộp.
        /// </summary>
        public int MaxSubmissionFileSizeMB
        {
            get { return intMaxSubmissionFileSizeMB; }
            set { intMaxSubmissionFileSizeMB = value; }
        }

        /// <summary>
        /// AllowLateSubmission
        /// Cho phép học viên nộp bài sau hạn hay không.
        /// </summary>
        public bool AllowLateSubmission
        {
            get { return bolAllowLateSubmission; }
            set { bolAllowLateSubmission = value; }
        }

        /// <summary>
        /// AssignmentStartAt
        /// Thời điểm học viên bắt đầu được nộp bài tập.
        /// </summary>
        public DateTime? AssignmentStartAt
        {
            get { return dtmAssignmentStartAt; }
            set { dtmAssignmentStartAt = value; }
        }

        /// <summary>
        /// AssignmentMaxScore
        /// Điểm tối đa giáo viên có thể chấm cho bài tập.
        /// </summary>
        public decimal AssignmentMaxScore
        {
            get { return decAssignmentMaxScore; }
            set { decAssignmentMaxScore = value; }
        }

        /// <summary>
        /// MaxSubmissionAttempts
        /// Số lần nộp tối đa được phép cho bài tập.
        /// </summary>
        public int MaxSubmissionAttempts
        {
            get { return intMaxSubmissionAttempts; }
            set { intMaxSubmissionAttempts = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_LessonID.ToUpper()) && !Convert.IsDBNull(reader[C_LessonID])) this.lngLessonID = Convert.ToInt64(reader[C_LessonID]);
                    if (reader.GetName(i).ToUpper().Equals(C_CourseId.ToUpper()) && !Convert.IsDBNull(reader[C_CourseId])) this.lngCourseId = Convert.ToInt64(reader[C_CourseId]);
                    if (reader.GetName(i).ToUpper().Equals(C_ChapterId.ToUpper()) && !Convert.IsDBNull(reader[C_ChapterId])) this.lngChapterId = Convert.ToInt64(reader[C_ChapterId]);
                    if (reader.GetName(i).ToUpper().Equals(C_Title.ToUpper()) && !Convert.IsDBNull(reader[C_Title])) this.strTitle = Convert.ToString(reader[C_Title]);
                    if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
                    if (reader.GetName(i).ToUpper().Equals(C_LessonType.ToUpper()) && !Convert.IsDBNull(reader[C_LessonType])) this.strLessonType = Convert.ToString(reader[C_LessonType]);
                    if (reader.GetName(i).ToUpper().Equals(C_DurationSeconds.ToUpper()) && !Convert.IsDBNull(reader[C_DurationSeconds])) this.intDurationSeconds = Convert.ToInt32(reader[C_DurationSeconds]);
                    if (reader.GetName(i).ToUpper().Equals(C_SortOrder.ToUpper()) && !Convert.IsDBNull(reader[C_SortOrder])) this.intSortOrder = Convert.ToInt32(reader[C_SortOrder]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsRequired.ToUpper()) && !Convert.IsDBNull(reader[C_IsRequired])) this.bolIsRequired = Convert.ToBoolean(reader[C_IsRequired]);
                    if (reader.GetName(i).ToUpper().Equals(C_PassingScore.ToUpper()) && !Convert.IsDBNull(reader[C_PassingScore])) this.decPassingScore = Convert.ToDecimal(reader[C_PassingScore]);
                    if (reader.GetName(i).ToUpper().Equals(C_Status.ToUpper()) && !Convert.IsDBNull(reader[C_Status])) this.strStatus = Convert.ToString(reader[C_Status]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(reader[C_CreatedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedAt])) this.dtmUpdatedAt = Convert.ToDateTime(reader[C_UpdatedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsDeleted.ToUpper()) && !Convert.IsDBNull(reader[C_IsDeleted])) this.bolIsDeleted = Convert.ToBoolean(reader[C_IsDeleted]);
                    if (reader.GetName(i).ToUpper().Equals(C_VideoID.ToUpper()) && !Convert.IsDBNull(reader[C_VideoID])) this.lngVideoID = Convert.ToInt64(reader[C_VideoID]);
                    if (reader.GetName(i).ToUpper().Equals(C_VideoVersionID.ToUpper()) && !Convert.IsDBNull(reader[C_VideoVersionID])) this.lngVideoVersionID = Convert.ToInt64(reader[C_VideoVersionID]);
                    if (reader.GetName(i).ToUpper().Equals(C_ContentHtml.ToUpper()) && !Convert.IsDBNull(reader[C_ContentHtml])) this.strContentHtml = Convert.ToString(reader[C_ContentHtml]);
                    if (reader.GetName(i).ToUpper().Equals(C_DocumentUrl.ToUpper()) && !Convert.IsDBNull(reader[C_DocumentUrl])) this.strDocumentUrl = Convert.ToString(reader[C_DocumentUrl]);
                    if (reader.GetName(i).ToUpper().Equals(C_AssignmentFolderName.ToUpper()) && !Convert.IsDBNull(reader[C_AssignmentFolderName])) this.strAssignmentFolderName = Convert.ToString(reader[C_AssignmentFolderName]);
                    if (reader.GetName(i).ToUpper().Equals(C_DueAt.ToUpper()) && !Convert.IsDBNull(reader[C_DueAt])) this.dtmDueAt = Convert.ToDateTime(reader[C_DueAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_MaxSubmissionFileSizeMB.ToUpper()) && !Convert.IsDBNull(reader[C_MaxSubmissionFileSizeMB])) this.intMaxSubmissionFileSizeMB = Convert.ToInt32(reader[C_MaxSubmissionFileSizeMB]);
                    if (reader.GetName(i).ToUpper().Equals(C_AllowLateSubmission.ToUpper()) && !Convert.IsDBNull(reader[C_AllowLateSubmission])) this.bolAllowLateSubmission = Convert.ToBoolean(reader[C_AllowLateSubmission]);
                    if (reader.GetName(i).ToUpper().Equals(C_AssignmentStartAt.ToUpper()) && !Convert.IsDBNull(reader[C_AssignmentStartAt])) this.dtmAssignmentStartAt = Convert.ToDateTime(reader[C_AssignmentStartAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_AssignmentMaxScore.ToUpper()) && !Convert.IsDBNull(reader[C_AssignmentMaxScore])) this.decAssignmentMaxScore = Convert.ToDecimal(reader[C_AssignmentMaxScore]);
                    if (reader.GetName(i).ToUpper().Equals(C_MaxSubmissionAttempts.ToUpper()) && !Convert.IsDBNull(reader[C_MaxSubmissionAttempts])) this.intMaxSubmissionAttempts = Convert.ToInt32(reader[C_MaxSubmissionAttempts]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_Lessons", objEx);
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
                if (!Convert.IsDBNull(drw[C_LessonID])) this.lngLessonID = Convert.ToInt64(drw[C_LessonID]);
                if (!Convert.IsDBNull(drw[C_CourseId])) this.lngCourseId = Convert.ToInt64(drw[C_CourseId]);
                if (!Convert.IsDBNull(drw[C_ChapterId])) this.lngChapterId = Convert.ToInt64(drw[C_ChapterId]);
                if (!Convert.IsDBNull(drw[C_Title])) this.strTitle = Convert.ToString(drw[C_Title]);
                if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
                if (!Convert.IsDBNull(drw[C_LessonType])) this.strLessonType = Convert.ToString(drw[C_LessonType]);
                if (!Convert.IsDBNull(drw[C_DurationSeconds])) this.intDurationSeconds = Convert.ToInt32(drw[C_DurationSeconds]);
                if (!Convert.IsDBNull(drw[C_SortOrder])) this.intSortOrder = Convert.ToInt32(drw[C_SortOrder]);
                if (!Convert.IsDBNull(drw[C_IsRequired])) this.bolIsRequired = Convert.ToBoolean(drw[C_IsRequired]);
                if (!Convert.IsDBNull(drw[C_PassingScore])) this.decPassingScore = Convert.ToDecimal(drw[C_PassingScore]);
                if (!Convert.IsDBNull(drw[C_Status])) this.strStatus = Convert.ToString(drw[C_Status]);
                if (!Convert.IsDBNull(drw[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(drw[C_CreatedAt]);
                if (!Convert.IsDBNull(drw[C_UpdatedAt])) this.dtmUpdatedAt = Convert.ToDateTime(drw[C_UpdatedAt]);
                if (!Convert.IsDBNull(drw[C_IsDeleted])) this.bolIsDeleted = Convert.ToBoolean(drw[C_IsDeleted]);
                if (!Convert.IsDBNull(drw[C_VideoID])) this.lngVideoID = Convert.ToInt64(drw[C_VideoID]);
                if (!Convert.IsDBNull(drw[C_VideoVersionID])) this.lngVideoVersionID = Convert.ToInt64(drw[C_VideoVersionID]);
                if (!Convert.IsDBNull(drw[C_ContentHtml])) this.strContentHtml = Convert.ToString(drw[C_ContentHtml]);
                if (!Convert.IsDBNull(drw[C_DocumentUrl])) this.strDocumentUrl = Convert.ToString(drw[C_DocumentUrl]);
                if (!Convert.IsDBNull(drw[C_AssignmentFolderName])) this.strAssignmentFolderName = Convert.ToString(drw[C_AssignmentFolderName]);
                if (!Convert.IsDBNull(drw[C_DueAt])) this.dtmDueAt = Convert.ToDateTime(drw[C_DueAt]);
                if (!Convert.IsDBNull(drw[C_MaxSubmissionFileSizeMB])) this.intMaxSubmissionFileSizeMB = Convert.ToInt32(drw[C_MaxSubmissionFileSizeMB]);
                if (!Convert.IsDBNull(drw[C_AllowLateSubmission])) this.bolAllowLateSubmission = Convert.ToBoolean(drw[C_AllowLateSubmission]);
                if (!Convert.IsDBNull(drw[C_AssignmentStartAt])) this.dtmAssignmentStartAt = Convert.ToDateTime(drw[C_AssignmentStartAt]);
                if (!Convert.IsDBNull(drw[C_AssignmentMaxScore])) this.decAssignmentMaxScore = Convert.ToDecimal(drw[C_AssignmentMaxScore]);
                if (!Convert.IsDBNull(drw[C_MaxSubmissionAttempts])) this.intMaxSubmissionAttempts = Convert.ToInt32(drw[C_MaxSubmissionAttempts]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_Lessons", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: SIM_Lessons_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_LessonID, this.lngLessonID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin SIM_Lessons", objEx);
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
        /// Store: SIM_Lessons_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get(long lngLessonID)
        {
            this.lngLessonID = lngLessonID;
            return this.Get();
        }

        ///<summary>
        ///Thêm mới dữ liệu
        /// Store: SIM_Lessons_ADD
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreAdd);
                objIData.AddParameter(P_CourseId, this.lngCourseId);
                objIData.AddParameter(P_ChapterId, this.lngChapterId);
                objIData.AddParameter(P_Title, this.strTitle);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_LessonType, this.strLessonType);
                objIData.AddParameter(P_DurationSeconds, this.intDurationSeconds);
                objIData.AddParameter(P_SortOrder, this.intSortOrder);
                objIData.AddParameter(P_IsRequired, this.bolIsRequired);
                objIData.AddParameter(P_PassingScore, this.decPassingScore);
                objIData.AddParameter(P_Status, this.strStatus);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_UpdatedAt, this.dtmUpdatedAt);
                objIData.AddParameter(P_IsDeleted, this.bolIsDeleted);
                objIData.AddParameter(P_VideoID, this.lngVideoID);
                objIData.AddParameter(P_VideoVersionID, this.lngVideoVersionID);
                objIData.AddParameter(P_ContentHtml, this.strContentHtml);
                objIData.AddParameter(P_DocumentUrl, this.strDocumentUrl);
                objIData.AddParameter(P_AssignmentFolderName, this.strAssignmentFolderName);
                objIData.AddParameter(P_DueAt, this.dtmDueAt);
                objIData.AddParameter(P_MaxSubmissionFileSizeMB, this.intMaxSubmissionFileSizeMB);
                objIData.AddParameter(P_AllowLateSubmission, this.bolAllowLateSubmission);
                objIData.AddParameter(P_AssignmentStartAt, this.dtmAssignmentStartAt);
                objIData.AddParameter(P_AssignmentMaxScore, this.decAssignmentMaxScore);
                objIData.AddParameter(P_MaxSubmissionAttempts, this.intMaxSubmissionAttempts);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm mới thông tin trong SIM_Lessons", objEx);
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
        /// Store: SIM_Lessons_EDIT
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_LessonID, this.lngLessonID);
                objIData.AddParameter(P_CourseId, this.lngCourseId);
                objIData.AddParameter(P_ChapterId, this.lngChapterId);
                objIData.AddParameter(P_Title, this.strTitle);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_LessonType, this.strLessonType);
                objIData.AddParameter(P_DurationSeconds, this.intDurationSeconds);
                objIData.AddParameter(P_SortOrder, this.intSortOrder);
                objIData.AddParameter(P_IsRequired, this.bolIsRequired);
                objIData.AddParameter(P_PassingScore, this.decPassingScore);
                objIData.AddParameter(P_Status, this.strStatus);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_UpdatedAt, this.dtmUpdatedAt);
                objIData.AddParameter(P_IsDeleted, this.bolIsDeleted);
                objIData.AddParameter(P_VideoID, this.lngVideoID);
                objIData.AddParameter(P_VideoVersionID, this.lngVideoVersionID);
                objIData.AddParameter(P_ContentHtml, this.strContentHtml);
                objIData.AddParameter(P_DocumentUrl, this.strDocumentUrl);
                objIData.AddParameter(P_AssignmentFolderName, this.strAssignmentFolderName);
                objIData.AddParameter(P_DueAt, this.dtmDueAt);
                objIData.AddParameter(P_MaxSubmissionFileSizeMB, this.intMaxSubmissionFileSizeMB);
                objIData.AddParameter(P_AllowLateSubmission, this.bolAllowLateSubmission);
                objIData.AddParameter(P_AssignmentStartAt, this.dtmAssignmentStartAt);
                objIData.AddParameter(P_AssignmentMaxScore, this.decAssignmentMaxScore);
                objIData.AddParameter(P_MaxSubmissionAttempts, this.intMaxSubmissionAttempts);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong SIM_Lessons", objEx);
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
        /// Store: SIM_Lessons_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_LessonID, this.lngLessonID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong SIM_Lessons", objEx);
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
        /// Store: SIM_Lessons_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long lngLessonID)
        {
            this.lngLessonID = lngLessonID;
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

        public SIM_Lessons()
        {
        }
        public SIM_Lessons(long lngLessonID)
        {
            this.lngLessonID = lngLessonID;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "SIM_Lessons";
        public const string StoreGet = "SIM_Lessons_GET";
        public const string StoreGetAll = "SIM_Lessons_GETALL";
        public const string StoreSearch = "SIM_Lessons_SEARCH";
        public const string StoreAdd = "SIM_Lessons_ADD";
        public const string StoreEdit = "SIM_Lessons_EDIT";
        public const string StoreDelete = "SIM_Lessons_DELETE";

        #region Parameter Names

        public const String P_LessonID = "@" + C_LessonID;
        public const String P_CourseId = "@" + C_CourseId;
        public const String P_ChapterId = "@" + C_ChapterId;
        public const String P_Title = "@" + C_Title;
        public const String P_Description = "@" + C_Description;
        public const String P_LessonType = "@" + C_LessonType;
        public const String P_DurationSeconds = "@" + C_DurationSeconds;
        public const String P_SortOrder = "@" + C_SortOrder;
        public const String P_IsRequired = "@" + C_IsRequired;
        public const String P_PassingScore = "@" + C_PassingScore;
        public const String P_Status = "@" + C_Status;
        public const String P_CreatedAt = "@" + C_CreatedAt;
        public const String P_UpdatedAt = "@" + C_UpdatedAt;
        public const String P_IsDeleted = "@" + C_IsDeleted;
        public const String P_VideoID = "@" + C_VideoID;
        public const String P_VideoVersionID = "@" + C_VideoVersionID;
        public const String P_ContentHtml = "@" + C_ContentHtml;
        public const String P_DocumentUrl = "@" + C_DocumentUrl;
        public const String P_AssignmentFolderName = "@" + C_AssignmentFolderName;
        public const String P_DueAt = "@" + C_DueAt;
        public const String P_MaxSubmissionFileSizeMB = "@" + C_MaxSubmissionFileSizeMB;
        public const String P_AllowLateSubmission = "@" + C_AllowLateSubmission;
        public const String P_AssignmentStartAt = "@" + C_AssignmentStartAt;
        public const String P_AssignmentMaxScore = "@" + C_AssignmentMaxScore;
        public const String P_MaxSubmissionAttempts = "@" + C_MaxSubmissionAttempts;

        #endregion //Parameter names

        #region Column Names

        public const String C_LessonID = "LessonID";
        public const String C_CourseId = "CourseId";
        public const String C_ChapterId = "ChapterId";
        public const String C_Title = "Title";
        public const String C_Description = "Description";
        public const String C_LessonType = "LessonType";
        public const String C_DurationSeconds = "DurationSeconds";
        public const String C_SortOrder = "SortOrder";
        public const String C_IsRequired = "IsRequired";
        public const String C_PassingScore = "PassingScore";
        public const String C_Status = "Status";
        public const String C_CreatedAt = "CreatedAt";
        public const String C_UpdatedAt = "UpdatedAt";
        public const String C_IsDeleted = "IsDeleted";
        public const String C_VideoID = "VideoID";
        public const String C_VideoVersionID = "VideoVersionID";
        public const String C_ContentHtml = "ContentHtml";
        public const String C_DocumentUrl = "DocumentUrl";
        public const String C_AssignmentFolderName = "AssignmentFolderName";
        public const String C_DueAt = "DueAt";
        public const String C_MaxSubmissionFileSizeMB = "MaxSubmissionFileSizeMB";
        public const String C_AllowLateSubmission = "AllowLateSubmission";
        public const String C_AssignmentStartAt = "AssignmentStartAt";
        public const String C_AssignmentMaxScore = "AssignmentMaxScore";
        public const String C_MaxSubmissionAttempts = "MaxSubmissionAttempts";

        #endregion //Column names

        #endregion Variable Static
    }
}
