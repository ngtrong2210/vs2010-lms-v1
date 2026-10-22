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
    /// [LMS] Thông tin ghi danh học viên vào khóa học.
    /// </summary>
    public partial class LMS_Enrollments
    {
        #region Member Variables

        private long lngEnrollmentID = 0;//Khóa chính tự tăng của lượt ghi danh.
        private long lngCourseId = 0;//ID khóa học được ghi danh.
        private long lngStudentUserID = 0;//ID học viên được ghi danh.
        private DateTime dtmEnrolledAt = DateTime.MinValue;//Thời điểm ghi danh học viên theo UTC.
        private DateTime? dtmStartedAt = null;//Thời điểm học viên bắt đầu học theo UTC.
        private DateTime? dtmCompletedAt = null;//Thời điểm học viên hoàn thành khóa học theo UTC.
        private string strStatus = null;//Trạng thái ghi danh: ENROLLED, IN_PROGRESS, COMPLETED hoặc CANCELLED.
        private decimal decProgressPercent = 0;//Tỷ lệ phần trăm hoàn thành khóa học.
        private decimal? decFinalScore = null;//Điểm tổng kết cuối cùng của khóa học.
        private DateTime? dtmLastAccessAt = null;//Thời điểm học viên truy cập khóa học gần nhất theo UTC.
        private long lngCreatedByUserID = 0;//ID người dùng thực hiện ghi danh.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// EnrollmentID
        /// Khóa chính tự tăng của lượt ghi danh.
        /// </summary>
        public long EnrollmentID
        {
            get { return lngEnrollmentID; }
            set { lngEnrollmentID = value; }
        }

        /// <summary>
        /// CourseId
        /// ID khóa học được ghi danh.
        /// </summary>
        public long CourseId
        {
            get { return lngCourseId; }
            set { lngCourseId = value; }
        }

        /// <summary>
        /// StudentUserID
        /// ID học viên được ghi danh.
        /// </summary>
        public long StudentUserID
        {
            get { return lngStudentUserID; }
            set { lngStudentUserID = value; }
        }

        /// <summary>
        /// EnrolledAt
        /// Thời điểm ghi danh học viên theo UTC.
        /// </summary>
        public DateTime EnrolledAt
        {
            get { return dtmEnrolledAt; }
            set { dtmEnrolledAt = value; }
        }

        /// <summary>
        /// StartedAt
        /// Thời điểm học viên bắt đầu học theo UTC.
        /// </summary>
        public DateTime? StartedAt
        {
            get { return dtmStartedAt; }
            set { dtmStartedAt = value; }
        }

        /// <summary>
        /// CompletedAt
        /// Thời điểm học viên hoàn thành khóa học theo UTC.
        /// </summary>
        public DateTime? CompletedAt
        {
            get { return dtmCompletedAt; }
            set { dtmCompletedAt = value; }
        }

        /// <summary>
        /// Status
        /// Trạng thái ghi danh: ENROLLED, IN_PROGRESS, COMPLETED hoặc CANCELLED.
        /// </summary>
        public string Status
        {
            get { return strStatus; }
            set { strStatus = value; }
        }

        /// <summary>
        /// ProgressPercent
        /// Tỷ lệ phần trăm hoàn thành khóa học.
        /// </summary>
        public decimal ProgressPercent
        {
            get { return decProgressPercent; }
            set { decProgressPercent = value; }
        }

        /// <summary>
        /// FinalScore
        /// Điểm tổng kết cuối cùng của khóa học.
        /// </summary>
        public decimal? FinalScore
        {
            get { return decFinalScore; }
            set { decFinalScore = value; }
        }

        /// <summary>
        /// LastAccessAt
        /// Thời điểm học viên truy cập khóa học gần nhất theo UTC.
        /// </summary>
        public DateTime? LastAccessAt
        {
            get { return dtmLastAccessAt; }
            set { dtmLastAccessAt = value; }
        }

        /// <summary>
        /// CreatedByUserID
        /// ID người dùng thực hiện ghi danh.
        /// </summary>
        public long CreatedByUserID
        {
            get { return lngCreatedByUserID; }
            set { lngCreatedByUserID = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_EnrollmentID.ToUpper()) && !Convert.IsDBNull(reader[C_EnrollmentID])) this.lngEnrollmentID = Convert.ToInt64(reader[C_EnrollmentID]);
                    if (reader.GetName(i).ToUpper().Equals(C_CourseId.ToUpper()) && !Convert.IsDBNull(reader[C_CourseId])) this.lngCourseId = Convert.ToInt64(reader[C_CourseId]);
                    if (reader.GetName(i).ToUpper().Equals(C_StudentUserID.ToUpper()) && !Convert.IsDBNull(reader[C_StudentUserID])) this.lngStudentUserID = Convert.ToInt64(reader[C_StudentUserID]);
                    if (reader.GetName(i).ToUpper().Equals(C_EnrolledAt.ToUpper()) && !Convert.IsDBNull(reader[C_EnrolledAt])) this.dtmEnrolledAt = Convert.ToDateTime(reader[C_EnrolledAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_StartedAt.ToUpper()) && !Convert.IsDBNull(reader[C_StartedAt])) this.dtmStartedAt = Convert.ToDateTime(reader[C_StartedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_CompletedAt.ToUpper()) && !Convert.IsDBNull(reader[C_CompletedAt])) this.dtmCompletedAt = Convert.ToDateTime(reader[C_CompletedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_Status.ToUpper()) && !Convert.IsDBNull(reader[C_Status])) this.strStatus = Convert.ToString(reader[C_Status]);
                    if (reader.GetName(i).ToUpper().Equals(C_ProgressPercent.ToUpper()) && !Convert.IsDBNull(reader[C_ProgressPercent])) this.decProgressPercent = Convert.ToDecimal(reader[C_ProgressPercent]);
                    if (reader.GetName(i).ToUpper().Equals(C_FinalScore.ToUpper()) && !Convert.IsDBNull(reader[C_FinalScore])) this.decFinalScore = Convert.ToDecimal(reader[C_FinalScore]);
                    if (reader.GetName(i).ToUpper().Equals(C_LastAccessAt.ToUpper()) && !Convert.IsDBNull(reader[C_LastAccessAt])) this.dtmLastAccessAt = Convert.ToDateTime(reader[C_LastAccessAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedByUserID.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedByUserID])) this.lngCreatedByUserID = Convert.ToInt64(reader[C_CreatedByUserID]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong LMS_Enrollments", objEx);
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
                if (!Convert.IsDBNull(drw[C_EnrollmentID])) this.lngEnrollmentID = Convert.ToInt64(drw[C_EnrollmentID]);
                if (!Convert.IsDBNull(drw[C_CourseId])) this.lngCourseId = Convert.ToInt64(drw[C_CourseId]);
                if (!Convert.IsDBNull(drw[C_StudentUserID])) this.lngStudentUserID = Convert.ToInt64(drw[C_StudentUserID]);
                if (!Convert.IsDBNull(drw[C_EnrolledAt])) this.dtmEnrolledAt = Convert.ToDateTime(drw[C_EnrolledAt]);
                if (!Convert.IsDBNull(drw[C_StartedAt])) this.dtmStartedAt = Convert.ToDateTime(drw[C_StartedAt]);
                if (!Convert.IsDBNull(drw[C_CompletedAt])) this.dtmCompletedAt = Convert.ToDateTime(drw[C_CompletedAt]);
                if (!Convert.IsDBNull(drw[C_Status])) this.strStatus = Convert.ToString(drw[C_Status]);
                if (!Convert.IsDBNull(drw[C_ProgressPercent])) this.decProgressPercent = Convert.ToDecimal(drw[C_ProgressPercent]);
                if (!Convert.IsDBNull(drw[C_FinalScore])) this.decFinalScore = Convert.ToDecimal(drw[C_FinalScore]);
                if (!Convert.IsDBNull(drw[C_LastAccessAt])) this.dtmLastAccessAt = Convert.ToDateTime(drw[C_LastAccessAt]);
                if (!Convert.IsDBNull(drw[C_CreatedByUserID])) this.lngCreatedByUserID = Convert.ToInt64(drw[C_CreatedByUserID]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong LMS_Enrollments", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: LMS_Enrollments_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_EnrollmentID, this.lngEnrollmentID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin LMS_Enrollments", objEx);
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
        /// Store: LMS_Enrollments_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get(long lngEnrollmentID)
        {
            this.lngEnrollmentID = lngEnrollmentID;
            return this.Get();
        }

        ///<summary>
        ///Thêm mới dữ liệu
        /// Store: LMS_Enrollments_ADD
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
                objIData.AddParameter(P_StudentUserID, this.lngStudentUserID);
                objIData.AddParameter(P_EnrolledAt, this.dtmEnrolledAt);
                objIData.AddParameter(P_StartedAt, this.dtmStartedAt);
                objIData.AddParameter(P_CompletedAt, this.dtmCompletedAt);
                objIData.AddParameter(P_Status, this.strStatus);
                objIData.AddParameter(P_ProgressPercent, this.decProgressPercent);
                objIData.AddParameter(P_FinalScore, this.decFinalScore);
                objIData.AddParameter(P_LastAccessAt, this.dtmLastAccessAt);
                objIData.AddParameter(P_CreatedByUserID, this.lngCreatedByUserID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm mới thông tin trong LMS_Enrollments", objEx);
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
        /// Store: LMS_Enrollments_EDIT
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_EnrollmentID, this.lngEnrollmentID);
                objIData.AddParameter(P_CourseId, this.lngCourseId);
                objIData.AddParameter(P_StudentUserID, this.lngStudentUserID);
                objIData.AddParameter(P_EnrolledAt, this.dtmEnrolledAt);
                objIData.AddParameter(P_StartedAt, this.dtmStartedAt);
                objIData.AddParameter(P_CompletedAt, this.dtmCompletedAt);
                objIData.AddParameter(P_Status, this.strStatus);
                objIData.AddParameter(P_ProgressPercent, this.decProgressPercent);
                objIData.AddParameter(P_FinalScore, this.decFinalScore);
                objIData.AddParameter(P_LastAccessAt, this.dtmLastAccessAt);
                objIData.AddParameter(P_CreatedByUserID, this.lngCreatedByUserID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong LMS_Enrollments", objEx);
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
        /// Store: LMS_Enrollments_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_EnrollmentID, this.lngEnrollmentID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong LMS_Enrollments", objEx);
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
        /// Store: LMS_Enrollments_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long lngEnrollmentID)
        {
            this.lngEnrollmentID = lngEnrollmentID;
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

        public LMS_Enrollments()
        {
        }
        public LMS_Enrollments(long lngEnrollmentID)
        {
            this.lngEnrollmentID = lngEnrollmentID;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "LMS_Enrollments";
        public const string StoreGet = "LMS_Enrollments_GET";
        public const string StoreGetAll = "LMS_Enrollments_GETALL";
        public const string StoreSearch = "LMS_Enrollments_SEARCH";
        public const string StoreAdd = "LMS_Enrollments_ADD";
        public const string StoreEdit = "LMS_Enrollments_EDIT";
        public const string StoreDelete = "LMS_Enrollments_DELETE";

        #region Parameter Names

        public const String P_EnrollmentID = "@" + C_EnrollmentID;
        public const String P_CourseId = "@" + C_CourseId;
        public const String P_StudentUserID = "@" + C_StudentUserID;
        public const String P_EnrolledAt = "@" + C_EnrolledAt;
        public const String P_StartedAt = "@" + C_StartedAt;
        public const String P_CompletedAt = "@" + C_CompletedAt;
        public const String P_Status = "@" + C_Status;
        public const String P_ProgressPercent = "@" + C_ProgressPercent;
        public const String P_FinalScore = "@" + C_FinalScore;
        public const String P_LastAccessAt = "@" + C_LastAccessAt;
        public const String P_CreatedByUserID = "@" + C_CreatedByUserID;

        #endregion //Parameter names

        #region Column Names

        public const String C_EnrollmentID = "EnrollmentID";
        public const String C_CourseId = "CourseId";
        public const String C_StudentUserID = "StudentUserID";
        public const String C_EnrolledAt = "EnrolledAt";
        public const String C_StartedAt = "StartedAt";
        public const String C_CompletedAt = "CompletedAt";
        public const String C_Status = "Status";
        public const String C_ProgressPercent = "ProgressPercent";
        public const String C_FinalScore = "FinalScore";
        public const String C_LastAccessAt = "LastAccessAt";
        public const String C_CreatedByUserID = "CreatedByUserID";

        #endregion //Column names

        #endregion Variable Static
    }
}
