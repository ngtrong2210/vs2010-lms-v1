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
    /// [LMS] Bài làm học viên nộp cho bài tập, gồm file, nội dung và kết quả chấm.
    /// </summary>
    public partial class LMS_AssignmentSubmissions
    {
        #region Member Variables

        private long lngAssignmentSubmissionID = 0;//Cột AssignmentSubmissionID của bảng LMS_AssignmentSubmissions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private long lngLessonID = 0;//Cột LessonID của bảng LMS_AssignmentSubmissions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private long lngCourseID = 0;//Cột CourseID của bảng LMS_AssignmentSubmissions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private long lngStudentUserID = 0;//Cột StudentUserID của bảng LMS_AssignmentSubmissions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private int intAttemptNumber = 0;//Cột AttemptNumber của bảng LMS_AssignmentSubmissions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private string strSubmissionText = null;//Cột SubmissionText của bảng LMS_AssignmentSubmissions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private string strFileUrl = null;//Đường dẫn tương đối tới file học viên nộp trong /Media/File/Assignments/.
        private string strOriginalFileName = null;//Cột OriginalFileName của bảng LMS_AssignmentSubmissions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private string strStoredFileName = null;//Cột StoredFileName của bảng LMS_AssignmentSubmissions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private long? lngFileSize = null;//Cột FileSize của bảng LMS_AssignmentSubmissions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private string strMimeType = null;//Cột MimeType của bảng LMS_AssignmentSubmissions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private DateTime dtmSubmittedAt = DateTime.MinValue;//Cột SubmittedAt của bảng LMS_AssignmentSubmissions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private string strSubmissionStatus = null;//Trạng thái bài nộp: nháp, đã nộp, đã chấm hoặc trả lại.
        private decimal? decScore = null;//Cột Score của bảng LMS_AssignmentSubmissions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private string strFeedback = null;//Cột Feedback của bảng LMS_AssignmentSubmissions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private long? lngGradedByUserID = null;//Cột GradedByUserID của bảng LMS_AssignmentSubmissions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private DateTime? dtmGradedAt = null;//Cột GradedAt của bảng LMS_AssignmentSubmissions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private bool bolIsLate = false;//Cho biết bài được nộp sau hạn cuối hay không.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// AssignmentSubmissionID
        /// Cột AssignmentSubmissionID của bảng LMS_AssignmentSubmissions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public long AssignmentSubmissionID
        {
            get { return lngAssignmentSubmissionID; }
            set { lngAssignmentSubmissionID = value; }
        }

        /// <summary>
        /// LessonID
        /// Cột LessonID của bảng LMS_AssignmentSubmissions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public long LessonID
        {
            get { return lngLessonID; }
            set { lngLessonID = value; }
        }

        /// <summary>
        /// CourseID
        /// Cột CourseID của bảng LMS_AssignmentSubmissions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public long CourseID
        {
            get { return lngCourseID; }
            set { lngCourseID = value; }
        }

        /// <summary>
        /// StudentUserID
        /// Cột StudentUserID của bảng LMS_AssignmentSubmissions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public long StudentUserID
        {
            get { return lngStudentUserID; }
            set { lngStudentUserID = value; }
        }

        /// <summary>
        /// AttemptNumber
        /// Cột AttemptNumber của bảng LMS_AssignmentSubmissions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public int AttemptNumber
        {
            get { return intAttemptNumber; }
            set { intAttemptNumber = value; }
        }

        /// <summary>
        /// SubmissionText
        /// Cột SubmissionText của bảng LMS_AssignmentSubmissions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public string SubmissionText
        {
            get { return strSubmissionText; }
            set { strSubmissionText = value; }
        }

        /// <summary>
        /// FileUrl
        /// Đường dẫn tương đối tới file học viên nộp trong /Media/File/Assignments/.
        /// </summary>
        public string FileUrl
        {
            get { return strFileUrl; }
            set { strFileUrl = value; }
        }

        /// <summary>
        /// OriginalFileName
        /// Cột OriginalFileName của bảng LMS_AssignmentSubmissions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public string OriginalFileName
        {
            get { return strOriginalFileName; }
            set { strOriginalFileName = value; }
        }

        /// <summary>
        /// StoredFileName
        /// Cột StoredFileName của bảng LMS_AssignmentSubmissions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public string StoredFileName
        {
            get { return strStoredFileName; }
            set { strStoredFileName = value; }
        }

        /// <summary>
        /// FileSize
        /// Cột FileSize của bảng LMS_AssignmentSubmissions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public long? FileSize
        {
            get { return lngFileSize; }
            set { lngFileSize = value; }
        }

        /// <summary>
        /// MimeType
        /// Cột MimeType của bảng LMS_AssignmentSubmissions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public string MimeType
        {
            get { return strMimeType; }
            set { strMimeType = value; }
        }

        /// <summary>
        /// SubmittedAt
        /// Cột SubmittedAt của bảng LMS_AssignmentSubmissions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public DateTime SubmittedAt
        {
            get { return dtmSubmittedAt; }
            set { dtmSubmittedAt = value; }
        }

        /// <summary>
        /// SubmissionStatus
        /// Trạng thái bài nộp: nháp, đã nộp, đã chấm hoặc trả lại.
        /// </summary>
        public string SubmissionStatus
        {
            get { return strSubmissionStatus; }
            set { strSubmissionStatus = value; }
        }

        /// <summary>
        /// Score
        /// Cột Score của bảng LMS_AssignmentSubmissions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public decimal? Score
        {
            get { return decScore; }
            set { decScore = value; }
        }

        /// <summary>
        /// Feedback
        /// Cột Feedback của bảng LMS_AssignmentSubmissions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public string Feedback
        {
            get { return strFeedback; }
            set { strFeedback = value; }
        }

        /// <summary>
        /// GradedByUserID
        /// Cột GradedByUserID của bảng LMS_AssignmentSubmissions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public long? GradedByUserID
        {
            get { return lngGradedByUserID; }
            set { lngGradedByUserID = value; }
        }

        /// <summary>
        /// GradedAt
        /// Cột GradedAt của bảng LMS_AssignmentSubmissions, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public DateTime? GradedAt
        {
            get { return dtmGradedAt; }
            set { dtmGradedAt = value; }
        }

        /// <summary>
        /// IsLate
        /// Cho biết bài được nộp sau hạn cuối hay không.
        /// </summary>
        public bool IsLate
        {
            get { return bolIsLate; }
            set { bolIsLate = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_AssignmentSubmissionID.ToUpper()) && !Convert.IsDBNull(reader[C_AssignmentSubmissionID])) this.lngAssignmentSubmissionID = Convert.ToInt64(reader[C_AssignmentSubmissionID]);
                    if (reader.GetName(i).ToUpper().Equals(C_LessonID.ToUpper()) && !Convert.IsDBNull(reader[C_LessonID])) this.lngLessonID = Convert.ToInt64(reader[C_LessonID]);
                    if (reader.GetName(i).ToUpper().Equals(C_CourseID.ToUpper()) && !Convert.IsDBNull(reader[C_CourseID])) this.lngCourseID = Convert.ToInt64(reader[C_CourseID]);
                    if (reader.GetName(i).ToUpper().Equals(C_StudentUserID.ToUpper()) && !Convert.IsDBNull(reader[C_StudentUserID])) this.lngStudentUserID = Convert.ToInt64(reader[C_StudentUserID]);
                    if (reader.GetName(i).ToUpper().Equals(C_AttemptNumber.ToUpper()) && !Convert.IsDBNull(reader[C_AttemptNumber])) this.intAttemptNumber = Convert.ToInt32(reader[C_AttemptNumber]);
                    if (reader.GetName(i).ToUpper().Equals(C_SubmissionText.ToUpper()) && !Convert.IsDBNull(reader[C_SubmissionText])) this.strSubmissionText = Convert.ToString(reader[C_SubmissionText]);
                    if (reader.GetName(i).ToUpper().Equals(C_FileUrl.ToUpper()) && !Convert.IsDBNull(reader[C_FileUrl])) this.strFileUrl = Convert.ToString(reader[C_FileUrl]);
                    if (reader.GetName(i).ToUpper().Equals(C_OriginalFileName.ToUpper()) && !Convert.IsDBNull(reader[C_OriginalFileName])) this.strOriginalFileName = Convert.ToString(reader[C_OriginalFileName]);
                    if (reader.GetName(i).ToUpper().Equals(C_StoredFileName.ToUpper()) && !Convert.IsDBNull(reader[C_StoredFileName])) this.strStoredFileName = Convert.ToString(reader[C_StoredFileName]);
                    if (reader.GetName(i).ToUpper().Equals(C_FileSize.ToUpper()) && !Convert.IsDBNull(reader[C_FileSize])) this.lngFileSize = Convert.ToInt64(reader[C_FileSize]);
                    if (reader.GetName(i).ToUpper().Equals(C_MimeType.ToUpper()) && !Convert.IsDBNull(reader[C_MimeType])) this.strMimeType = Convert.ToString(reader[C_MimeType]);
                    if (reader.GetName(i).ToUpper().Equals(C_SubmittedAt.ToUpper()) && !Convert.IsDBNull(reader[C_SubmittedAt])) this.dtmSubmittedAt = Convert.ToDateTime(reader[C_SubmittedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_SubmissionStatus.ToUpper()) && !Convert.IsDBNull(reader[C_SubmissionStatus])) this.strSubmissionStatus = Convert.ToString(reader[C_SubmissionStatus]);
                    if (reader.GetName(i).ToUpper().Equals(C_Score.ToUpper()) && !Convert.IsDBNull(reader[C_Score])) this.decScore = Convert.ToDecimal(reader[C_Score]);
                    if (reader.GetName(i).ToUpper().Equals(C_Feedback.ToUpper()) && !Convert.IsDBNull(reader[C_Feedback])) this.strFeedback = Convert.ToString(reader[C_Feedback]);
                    if (reader.GetName(i).ToUpper().Equals(C_GradedByUserID.ToUpper()) && !Convert.IsDBNull(reader[C_GradedByUserID])) this.lngGradedByUserID = Convert.ToInt64(reader[C_GradedByUserID]);
                    if (reader.GetName(i).ToUpper().Equals(C_GradedAt.ToUpper()) && !Convert.IsDBNull(reader[C_GradedAt])) this.dtmGradedAt = Convert.ToDateTime(reader[C_GradedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsLate.ToUpper()) && !Convert.IsDBNull(reader[C_IsLate])) this.bolIsLate = Convert.ToBoolean(reader[C_IsLate]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong LMS_AssignmentSubmissions", objEx);
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
                if (!Convert.IsDBNull(drw[C_AssignmentSubmissionID])) this.lngAssignmentSubmissionID = Convert.ToInt64(drw[C_AssignmentSubmissionID]);
                if (!Convert.IsDBNull(drw[C_LessonID])) this.lngLessonID = Convert.ToInt64(drw[C_LessonID]);
                if (!Convert.IsDBNull(drw[C_CourseID])) this.lngCourseID = Convert.ToInt64(drw[C_CourseID]);
                if (!Convert.IsDBNull(drw[C_StudentUserID])) this.lngStudentUserID = Convert.ToInt64(drw[C_StudentUserID]);
                if (!Convert.IsDBNull(drw[C_AttemptNumber])) this.intAttemptNumber = Convert.ToInt32(drw[C_AttemptNumber]);
                if (!Convert.IsDBNull(drw[C_SubmissionText])) this.strSubmissionText = Convert.ToString(drw[C_SubmissionText]);
                if (!Convert.IsDBNull(drw[C_FileUrl])) this.strFileUrl = Convert.ToString(drw[C_FileUrl]);
                if (!Convert.IsDBNull(drw[C_OriginalFileName])) this.strOriginalFileName = Convert.ToString(drw[C_OriginalFileName]);
                if (!Convert.IsDBNull(drw[C_StoredFileName])) this.strStoredFileName = Convert.ToString(drw[C_StoredFileName]);
                if (!Convert.IsDBNull(drw[C_FileSize])) this.lngFileSize = Convert.ToInt64(drw[C_FileSize]);
                if (!Convert.IsDBNull(drw[C_MimeType])) this.strMimeType = Convert.ToString(drw[C_MimeType]);
                if (!Convert.IsDBNull(drw[C_SubmittedAt])) this.dtmSubmittedAt = Convert.ToDateTime(drw[C_SubmittedAt]);
                if (!Convert.IsDBNull(drw[C_SubmissionStatus])) this.strSubmissionStatus = Convert.ToString(drw[C_SubmissionStatus]);
                if (!Convert.IsDBNull(drw[C_Score])) this.decScore = Convert.ToDecimal(drw[C_Score]);
                if (!Convert.IsDBNull(drw[C_Feedback])) this.strFeedback = Convert.ToString(drw[C_Feedback]);
                if (!Convert.IsDBNull(drw[C_GradedByUserID])) this.lngGradedByUserID = Convert.ToInt64(drw[C_GradedByUserID]);
                if (!Convert.IsDBNull(drw[C_GradedAt])) this.dtmGradedAt = Convert.ToDateTime(drw[C_GradedAt]);
                if (!Convert.IsDBNull(drw[C_IsLate])) this.bolIsLate = Convert.ToBoolean(drw[C_IsLate]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong LMS_AssignmentSubmissions", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: LMS_AssignmentSubmissions_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_AssignmentSubmissionID, this.lngAssignmentSubmissionID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin LMS_AssignmentSubmissions", objEx);
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
        /// Store: LMS_AssignmentSubmissions_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get(long lngAssignmentSubmissionID)
        {
            this.lngAssignmentSubmissionID = lngAssignmentSubmissionID;
            return this.Get();
        }

        ///<summary>
        ///Thêm mới dữ liệu
        /// Store: LMS_AssignmentSubmissions_ADD
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreAdd);
                objIData.AddParameter(P_LessonID, this.lngLessonID);
                objIData.AddParameter(P_CourseID, this.lngCourseID);
                objIData.AddParameter(P_StudentUserID, this.lngStudentUserID);
                objIData.AddParameter(P_AttemptNumber, this.intAttemptNumber);
                objIData.AddParameter(P_SubmissionText, this.strSubmissionText);
                objIData.AddParameter(P_FileUrl, this.strFileUrl);
                objIData.AddParameter(P_OriginalFileName, this.strOriginalFileName);
                objIData.AddParameter(P_StoredFileName, this.strStoredFileName);
                objIData.AddParameter(P_FileSize, this.lngFileSize);
                objIData.AddParameter(P_MimeType, this.strMimeType);
                objIData.AddParameter(P_SubmittedAt, this.dtmSubmittedAt);
                objIData.AddParameter(P_SubmissionStatus, this.strSubmissionStatus);
                objIData.AddParameter(P_Score, this.decScore);
                objIData.AddParameter(P_Feedback, this.strFeedback);
                objIData.AddParameter(P_GradedByUserID, this.lngGradedByUserID);
                objIData.AddParameter(P_GradedAt, this.dtmGradedAt);
                objIData.AddParameter(P_IsLate, this.bolIsLate);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm mới thông tin trong LMS_AssignmentSubmissions", objEx);
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
        /// Store: LMS_AssignmentSubmissions_EDIT
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_AssignmentSubmissionID, this.lngAssignmentSubmissionID);
                objIData.AddParameter(P_LessonID, this.lngLessonID);
                objIData.AddParameter(P_CourseID, this.lngCourseID);
                objIData.AddParameter(P_StudentUserID, this.lngStudentUserID);
                objIData.AddParameter(P_AttemptNumber, this.intAttemptNumber);
                objIData.AddParameter(P_SubmissionText, this.strSubmissionText);
                objIData.AddParameter(P_FileUrl, this.strFileUrl);
                objIData.AddParameter(P_OriginalFileName, this.strOriginalFileName);
                objIData.AddParameter(P_StoredFileName, this.strStoredFileName);
                objIData.AddParameter(P_FileSize, this.lngFileSize);
                objIData.AddParameter(P_MimeType, this.strMimeType);
                objIData.AddParameter(P_SubmittedAt, this.dtmSubmittedAt);
                objIData.AddParameter(P_SubmissionStatus, this.strSubmissionStatus);
                objIData.AddParameter(P_Score, this.decScore);
                objIData.AddParameter(P_Feedback, this.strFeedback);
                objIData.AddParameter(P_GradedByUserID, this.lngGradedByUserID);
                objIData.AddParameter(P_GradedAt, this.dtmGradedAt);
                objIData.AddParameter(P_IsLate, this.bolIsLate);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong LMS_AssignmentSubmissions", objEx);
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
        /// Store: LMS_AssignmentSubmissions_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_AssignmentSubmissionID, this.lngAssignmentSubmissionID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong LMS_AssignmentSubmissions", objEx);
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
        /// Store: LMS_AssignmentSubmissions_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long lngAssignmentSubmissionID)
        {
            this.lngAssignmentSubmissionID = lngAssignmentSubmissionID;
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

        public LMS_AssignmentSubmissions()
        {
        }
        public LMS_AssignmentSubmissions(long lngAssignmentSubmissionID)
        {
            this.lngAssignmentSubmissionID = lngAssignmentSubmissionID;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "LMS_AssignmentSubmissions";
        public const string StoreGet = "LMS_AssignmentSubmissions_GET";
        public const string StoreGetAll = "LMS_AssignmentSubmissions_GETALL";
        public const string StoreSearch = "LMS_AssignmentSubmissions_SEARCH";
        public const string StoreAdd = "LMS_AssignmentSubmissions_ADD";
        public const string StoreEdit = "LMS_AssignmentSubmissions_EDIT";
        public const string StoreDelete = "LMS_AssignmentSubmissions_DELETE";

        #region Parameter Names

        public const String P_AssignmentSubmissionID = "@" + C_AssignmentSubmissionID;
        public const String P_LessonID = "@" + C_LessonID;
        public const String P_CourseID = "@" + C_CourseID;
        public const String P_StudentUserID = "@" + C_StudentUserID;
        public const String P_AttemptNumber = "@" + C_AttemptNumber;
        public const String P_SubmissionText = "@" + C_SubmissionText;
        public const String P_FileUrl = "@" + C_FileUrl;
        public const String P_OriginalFileName = "@" + C_OriginalFileName;
        public const String P_StoredFileName = "@" + C_StoredFileName;
        public const String P_FileSize = "@" + C_FileSize;
        public const String P_MimeType = "@" + C_MimeType;
        public const String P_SubmittedAt = "@" + C_SubmittedAt;
        public const String P_SubmissionStatus = "@" + C_SubmissionStatus;
        public const String P_Score = "@" + C_Score;
        public const String P_Feedback = "@" + C_Feedback;
        public const String P_GradedByUserID = "@" + C_GradedByUserID;
        public const String P_GradedAt = "@" + C_GradedAt;
        public const String P_IsLate = "@" + C_IsLate;

        #endregion //Parameter names

        #region Column Names

        public const String C_AssignmentSubmissionID = "AssignmentSubmissionID";
        public const String C_LessonID = "LessonID";
        public const String C_CourseID = "CourseID";
        public const String C_StudentUserID = "StudentUserID";
        public const String C_AttemptNumber = "AttemptNumber";
        public const String C_SubmissionText = "SubmissionText";
        public const String C_FileUrl = "FileUrl";
        public const String C_OriginalFileName = "OriginalFileName";
        public const String C_StoredFileName = "StoredFileName";
        public const String C_FileSize = "FileSize";
        public const String C_MimeType = "MimeType";
        public const String C_SubmittedAt = "SubmittedAt";
        public const String C_SubmissionStatus = "SubmissionStatus";
        public const String C_Score = "Score";
        public const String C_Feedback = "Feedback";
        public const String C_GradedByUserID = "GradedByUserID";
        public const String C_GradedAt = "GradedAt";
        public const String C_IsLate = "IsLate";

        #endregion //Column names

        #endregion Variable Static
    }
}
