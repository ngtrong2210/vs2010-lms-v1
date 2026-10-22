
#region Using

using System;
using System.Data;
using System.Collections;
using DCore;

#endregion

namespace SimsObject
{
    /// <summary>
    /// DCore: 17/06/2021  For Soft
    /// Created by 		: YourName 
    /// Created date 	: 2/20/2023 
    /// Description 
    /// </summary>	
    public partial class SIM_RequestSchedule
    {
        #region Member Variables

        private long? lngRequestScheduleID = null;
        private long? lngClassSubjectID = null;
        private string strClassID = null;
        private string strSubjectID = null;
        private int? intYearID = null;
        private int? intSemester = null;
        private int? intDay = null;//Thứ tính từ 0-6
        private DateTime? dtmDate = null;//Ngày dạy (cho phép null, vì có trường hợp chỉ báo nghỉ, chưa chọn bù)
        private int? intWeek = null;//Tuần nào của niên học 1-50
        private int? intFromLessionTime = null;//Từ tiết học nào
        private int? intToLessionTime = null;//Tiết học
        private string strTeacherID = null;
        private string strRoomID = null;//Mã phòng
        private bool bolIsPractice = false;//Là môn thực hành
        private int? intLearningSession = null;
        private int? intAddLession = null;//Tiết cộng thêm so với thời lượng, mục đích để kiểm tra trùng giờ
        private string strScheduleContent = null;
        private string strDescription = null;
        private int? intOldDay = null;//Thứ tính từ 0-6
        private DateTime? dtmOldDate = null;//Ngày dạy
        private int? intOldWeek = null;//Tuần nào của niên học 1-50
        private int? intOldFromLessionTime = null;//Từ tiết học nào
        private int? intOldToLessionTime = null;//Tiết học
        private string strOldTeacherID = null;//Gv dạy bù (có thể khác sv gv báo nghỉ)
        private string strOldRoomID = null;//Mã phòng dạy bù (có thể đổi sv phòng ban đầu)
        private bool? bolIsReviewed = null;//Đã chấp nhận đăng ký dạy bù
        private DateTime? dtmReviewedDate = null;//Ngày duyệt đăng ký
        private string strReviewedUser = null;
        private string strReviewedComment = null;
        private DateTime? dtmCreatedDate = null;//Ngày tạo
        private string strCreatedUser = null;//Người tạo
        private DateTime? dtmUpdatedDate = null;//Ngày cập nhật cuối
        private string strUpdatedUser = null;//Người cập nhật cuối
        private bool? bolIsReviewed1 = null;//Đã chấp nhận đăng ký dạy bù
        private DateTime? dtmReviewedDate1 = null;//Ngày duyệt đăng ký
        private string strReviewedUser1 = null;
        private string strReviewedComment1 = null;
        private long? lngWithinRequestScheduleID = null;//Mã YC tham chiếu khi đổi cặp (khi này sẽ kiểm tra 2 cặp này có khớp lệch được không, và khi duyệt là duyệt cả cặp)
        private bool bolIsDuplicate = false;//Có dấu hiệu bị trùng
        private string strDuplicateDesc = null;//Mô tả cảnh báo trùng
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// RequestScheduleID
        /// 
        /// </summary>
        public long? RequestScheduleID
        {
            get { return lngRequestScheduleID; }
            set { lngRequestScheduleID = value; }
        }
        /// <summary>
        /// ClassSubjectID
        /// 
        /// </summary>
        public long? ClassSubjectID
        {
            get { return lngClassSubjectID; }
            set { lngClassSubjectID = value; }
        }
        /// <summary>
        /// ClassID
        /// 
        /// </summary>
        public string ClassID
        {
            get { return strClassID; }
            set { strClassID = value; }
        }
        /// <summary>
        /// SubjectID
        /// 
        /// </summary>
        public string SubjectID
        {
            get { return strSubjectID; }
            set { strSubjectID = value; }
        }
        /// <summary>
        /// YearID
        /// 
        /// </summary>
        public int? YearID
        {
            get { return intYearID; }
            set { intYearID = value; }
        }
        /// <summary>
        /// Semester
        /// 
        /// </summary>
        public int? Semester
        {
            get { return intSemester; }
            set { intSemester = value; }
        }
        /// <summary>
        /// Day
        /// Thứ tính từ 0-6
        /// </summary>
        public int? Day
        {
            get { return intDay; }
            set { intDay = value; }
        }
        /// <summary>
        /// Date
        /// Ngày dạy (cho phép null, vì có trường hợp chỉ báo nghỉ, chưa chọn bù)
        /// </summary>
        public DateTime? Date
        {
            get { return dtmDate; }
            set { dtmDate = value; }
        }
        /// <summary>
        /// Week
        /// Tuần nào của niên học 1-50
        /// </summary>
        public int? Week
        {
            get { return intWeek; }
            set { intWeek = value; }
        }
        /// <summary>
        /// FromLessionTime
        /// Từ tiết học nào
        /// </summary>
        public int? FromLessionTime
        {
            get { return intFromLessionTime; }
            set { intFromLessionTime = value; }
        }
        /// <summary>
        /// ToLessionTime
        /// Tiết học
        /// </summary>
        public int? ToLessionTime
        {
            get { return intToLessionTime; }
            set { intToLessionTime = value; }
        }
        /// <summary>
        /// TeacherID
        /// 
        /// </summary>
        public string TeacherID
        {
            get { return strTeacherID; }
            set { strTeacherID = value; }
        }
        /// <summary>
        /// RoomID
        /// Mã phòng
        /// </summary>
        public string RoomID
        {
            get { return strRoomID; }
            set { strRoomID = value; }
        }
        /// <summary>
        /// IsPractice
        /// Là môn thực hành
        /// </summary>
        public bool IsPractice
        {
            get { return bolIsPractice; }
            set { bolIsPractice = value; }
        }
        /// <summary>
        /// LearningSession
        /// 
        /// </summary>
        public int? LearningSession
        {
            get { return intLearningSession; }
            set { intLearningSession = value; }
        }
        /// <summary>
        /// AddLession
        /// Tiết cộng thêm so với thời lượng, mục đích để kiểm tra trùng giờ
        /// </summary>
        public int? AddLession
        {
            get { return intAddLession; }
            set { intAddLession = value; }
        }
        /// <summary>
        /// ScheduleContent
        /// 
        /// </summary>
        public string ScheduleContent
        {
            get { return strScheduleContent; }
            set { strScheduleContent = value; }
        }
        /// <summary>
        /// Description
        /// 
        /// </summary>
        public string Description
        {
            get { return strDescription; }
            set { strDescription = value; }
        }
        /// <summary>
        /// OldDay
        /// Thứ tính từ 0-6
        /// </summary>
        public int? OldDay
        {
            get { return intOldDay; }
            set { intOldDay = value; }
        }
        /// <summary>
        /// OldDate
        /// Ngày dạy
        /// </summary>
        public DateTime? OldDate
        {
            get { return dtmOldDate; }
            set { dtmOldDate = value; }
        }
        /// <summary>
        /// OldWeek
        /// Tuần nào của niên học 1-50
        /// </summary>
        public int? OldWeek
        {
            get { return intOldWeek; }
            set { intOldWeek = value; }
        }
        /// <summary>
        /// OldFromLessionTime
        /// Từ tiết học nào
        /// </summary>
        public int? OldFromLessionTime
        {
            get { return intOldFromLessionTime; }
            set { intOldFromLessionTime = value; }
        }
        /// <summary>
        /// OldToLessionTime
        /// Tiết học
        /// </summary>
        public int? OldToLessionTime
        {
            get { return intOldToLessionTime; }
            set { intOldToLessionTime = value; }
        }
        /// <summary>
        /// OldTeacherID
        /// Gv dạy bù (có thể khác sv gv báo nghỉ)
        /// </summary>
        public string OldTeacherID
        {
            get { return strOldTeacherID; }
            set { strOldTeacherID = value; }
        }
        /// <summary>
        /// OldRoomID
        /// Mã phòng dạy bù (có thể đổi sv phòng ban đầu)
        /// </summary>
        public string OldRoomID
        {
            get { return strOldRoomID; }
            set { strOldRoomID = value; }
        }
        /// <summary>
        /// IsReviewed
        /// Đã chấp nhận đăng ký dạy bù
        /// </summary>
        public bool? IsReviewed
        {
            get { return bolIsReviewed; }
            set { bolIsReviewed = value; }
        }
        /// <summary>
        /// ReviewedDate
        /// Ngày duyệt đăng ký
        /// </summary>
        public DateTime? ReviewedDate
        {
            get { return dtmReviewedDate; }
            set { dtmReviewedDate = value; }
        }
        /// <summary>
        /// ReviewedUser
        /// 
        /// </summary>
        public string ReviewedUser
        {
            get { return strReviewedUser; }
            set { strReviewedUser = value; }
        }
        /// <summary>
        /// ReviewedComment
        /// 
        /// </summary>
        public string ReviewedComment
        {
            get { return strReviewedComment; }
            set { strReviewedComment = value; }
        }
        /// <summary>
        /// CreatedDate
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate
        {
            get { return dtmCreatedDate; }
            set { dtmCreatedDate = value; }
        }
        /// <summary>
        /// CreatedUser
        /// Người tạo
        /// </summary>
        public string CreatedUser
        {
            get { return strCreatedUser; }
            set { strCreatedUser = value; }
        }
        /// <summary>
        /// UpdatedDate
        /// Ngày cập nhật cuối
        /// </summary>
        public DateTime? UpdatedDate
        {
            get { return dtmUpdatedDate; }
            set { dtmUpdatedDate = value; }
        }
        /// <summary>
        /// UpdatedUser
        /// Người cập nhật cuối
        /// </summary>
        public string UpdatedUser
        {
            get { return strUpdatedUser; }
            set { strUpdatedUser = value; }
        }
        /// <summary>
        /// IsReviewed1
        /// Đã chấp nhận đăng ký dạy bù
        /// </summary>
        public bool? IsReviewed1
        {
            get { return bolIsReviewed1; }
            set { bolIsReviewed1 = value; }
        }
        /// <summary>
        /// ReviewedDate1
        /// Ngày duyệt đăng ký
        /// </summary>
        public DateTime? ReviewedDate1
        {
            get { return dtmReviewedDate1; }
            set { dtmReviewedDate1 = value; }
        }
        /// <summary>
        /// ReviewedUser1
        /// 
        /// </summary>
        public string ReviewedUser1
        {
            get { return strReviewedUser1; }
            set { strReviewedUser1 = value; }
        }
        /// <summary>
        /// ReviewedComment1
        /// 
        /// </summary>
        public string ReviewedComment1
        {
            get { return strReviewedComment1; }
            set { strReviewedComment1 = value; }
        }
        /// <summary>
        /// WithinRequestScheduleID
        /// Mã YC tham chiếu khi đổi cặp (khi này sẽ kiểm tra 2 cặp này có khớp lệch được không, và khi duyệt là duyệt cả cặp)
        /// </summary>
        public long? WithinRequestScheduleID
        {
            get { return lngWithinRequestScheduleID; }
            set { lngWithinRequestScheduleID = value; }
        }
        /// <summary>
        /// IsDuplicate
        /// Có dấu hiệu bị trùng
        /// </summary>
        public bool IsDuplicate
        {
            get { return bolIsDuplicate; }
            set { bolIsDuplicate = value; }
        }
        /// <summary>
        /// DuplicateDesc
        /// Mô tả cảnh báo trùng
        /// </summary>
        public string DuplicateDesc
        {
            get { return strDuplicateDesc; }
            set { strDuplicateDesc = value; }
        }

        /// <summary>
        /// IData - Đối tượng IData truy xuất dữ liệu.
        ///	Nếu null thì các tác vụ của đối tượng tự tạo connect và depose mỗi khi được gọi				
        /// </summary>
        public IData IDB
        {
            get { return objIData; }
            set
            {
                objIData = value;
                bolIsExistIData = (value != null);
            }
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
                    if (reader.GetName(i).ToUpper().Equals(C_RequestScheduleID.ToUpper()) && !Convert.IsDBNull(reader[C_RequestScheduleID])) this.lngRequestScheduleID = Convert.ToInt64(reader[C_RequestScheduleID]);
                    if (reader.GetName(i).ToUpper().Equals(C_ClassSubjectID.ToUpper()) && !Convert.IsDBNull(reader[C_ClassSubjectID])) this.lngClassSubjectID = Convert.ToInt64(reader[C_ClassSubjectID]);
                    if (reader.GetName(i).ToUpper().Equals(C_ClassID.ToUpper()) && !Convert.IsDBNull(reader[C_ClassID])) this.strClassID = Convert.ToString(reader[C_ClassID]);
                    if (reader.GetName(i).ToUpper().Equals(C_SubjectID.ToUpper()) && !Convert.IsDBNull(reader[C_SubjectID])) this.strSubjectID = Convert.ToString(reader[C_SubjectID]);
                    if (reader.GetName(i).ToUpper().Equals(C_YearID.ToUpper()) && !Convert.IsDBNull(reader[C_YearID])) this.intYearID = Convert.ToInt32(reader[C_YearID]);
                    if (reader.GetName(i).ToUpper().Equals(C_Semester.ToUpper()) && !Convert.IsDBNull(reader[C_Semester])) this.intSemester = Convert.ToInt32(reader[C_Semester]);
                    if (reader.GetName(i).ToUpper().Equals(C_Day.ToUpper()) && !Convert.IsDBNull(reader[C_Day])) this.intDay = Convert.ToInt32(reader[C_Day]);
                    if (reader.GetName(i).ToUpper().Equals(C_Date.ToUpper()) && !Convert.IsDBNull(reader[C_Date])) this.dtmDate = Convert.ToDateTime(reader[C_Date]);
                    if (reader.GetName(i).ToUpper().Equals(C_Week.ToUpper()) && !Convert.IsDBNull(reader[C_Week])) this.intWeek = Convert.ToInt32(reader[C_Week]);
                    if (reader.GetName(i).ToUpper().Equals(C_FromLessionTime.ToUpper()) && !Convert.IsDBNull(reader[C_FromLessionTime])) this.intFromLessionTime = Convert.ToInt32(reader[C_FromLessionTime]);
                    if (reader.GetName(i).ToUpper().Equals(C_ToLessionTime.ToUpper()) && !Convert.IsDBNull(reader[C_ToLessionTime])) this.intToLessionTime = Convert.ToInt32(reader[C_ToLessionTime]);
                    if (reader.GetName(i).ToUpper().Equals(C_TeacherID.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherID])) this.strTeacherID = Convert.ToString(reader[C_TeacherID]);
                    if (reader.GetName(i).ToUpper().Equals(C_RoomID.ToUpper()) && !Convert.IsDBNull(reader[C_RoomID])) this.strRoomID = Convert.ToString(reader[C_RoomID]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsPractice.ToUpper()) && !Convert.IsDBNull(reader[C_IsPractice])) this.bolIsPractice = Convert.ToBoolean(reader[C_IsPractice]);
                    if (reader.GetName(i).ToUpper().Equals(C_LearningSession.ToUpper()) && !Convert.IsDBNull(reader[C_LearningSession])) this.intLearningSession = Convert.ToInt32(reader[C_LearningSession]);
                    if (reader.GetName(i).ToUpper().Equals(C_AddLession.ToUpper()) && !Convert.IsDBNull(reader[C_AddLession])) this.intAddLession = Convert.ToInt32(reader[C_AddLession]);
                    if (reader.GetName(i).ToUpper().Equals(C_ScheduleContent.ToUpper()) && !Convert.IsDBNull(reader[C_ScheduleContent])) this.strScheduleContent = Convert.ToString(reader[C_ScheduleContent]);
                    if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
                    if (reader.GetName(i).ToUpper().Equals(C_OldDay.ToUpper()) && !Convert.IsDBNull(reader[C_OldDay])) this.intOldDay = Convert.ToInt32(reader[C_OldDay]);
                    if (reader.GetName(i).ToUpper().Equals(C_OldDate.ToUpper()) && !Convert.IsDBNull(reader[C_OldDate])) this.dtmOldDate = Convert.ToDateTime(reader[C_OldDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_OldWeek.ToUpper()) && !Convert.IsDBNull(reader[C_OldWeek])) this.intOldWeek = Convert.ToInt32(reader[C_OldWeek]);
                    if (reader.GetName(i).ToUpper().Equals(C_OldFromLessionTime.ToUpper()) && !Convert.IsDBNull(reader[C_OldFromLessionTime])) this.intOldFromLessionTime = Convert.ToInt32(reader[C_OldFromLessionTime]);
                    if (reader.GetName(i).ToUpper().Equals(C_OldToLessionTime.ToUpper()) && !Convert.IsDBNull(reader[C_OldToLessionTime])) this.intOldToLessionTime = Convert.ToInt32(reader[C_OldToLessionTime]);
                    if (reader.GetName(i).ToUpper().Equals(C_OldTeacherID.ToUpper()) && !Convert.IsDBNull(reader[C_OldTeacherID])) this.strOldTeacherID = Convert.ToString(reader[C_OldTeacherID]);
                    if (reader.GetName(i).ToUpper().Equals(C_OldRoomID.ToUpper()) && !Convert.IsDBNull(reader[C_OldRoomID])) this.strOldRoomID = Convert.ToString(reader[C_OldRoomID]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsReviewed.ToUpper()) && !Convert.IsDBNull(reader[C_IsReviewed])) this.bolIsReviewed = Convert.ToBoolean(reader[C_IsReviewed]);
                    if (reader.GetName(i).ToUpper().Equals(C_ReviewedDate.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewedDate])) this.dtmReviewedDate = Convert.ToDateTime(reader[C_ReviewedDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_ReviewedUser.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewedUser])) this.strReviewedUser = Convert.ToString(reader[C_ReviewedUser]);
                    if (reader.GetName(i).ToUpper().Equals(C_ReviewedComment.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewedComment])) this.strReviewedComment = Convert.ToString(reader[C_ReviewedComment]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(reader[C_UpdatedDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(reader[C_UpdatedUser]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsReviewed1.ToUpper()) && !Convert.IsDBNull(reader[C_IsReviewed1])) this.bolIsReviewed1 = Convert.ToBoolean(reader[C_IsReviewed1]);
                    if (reader.GetName(i).ToUpper().Equals(C_ReviewedDate1.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewedDate1])) this.dtmReviewedDate1 = Convert.ToDateTime(reader[C_ReviewedDate1]);
                    if (reader.GetName(i).ToUpper().Equals(C_ReviewedUser1.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewedUser1])) this.strReviewedUser1 = Convert.ToString(reader[C_ReviewedUser1]);
                    if (reader.GetName(i).ToUpper().Equals(C_ReviewedComment1.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewedComment1])) this.strReviewedComment1 = Convert.ToString(reader[C_ReviewedComment1]);
                    if (reader.GetName(i).ToUpper().Equals(C_WithinRequestScheduleID.ToUpper()) && !Convert.IsDBNull(reader[C_WithinRequestScheduleID])) this.lngWithinRequestScheduleID = Convert.ToInt64(reader[C_WithinRequestScheduleID]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsDuplicate.ToUpper()) && !Convert.IsDBNull(reader[C_IsDuplicate])) this.bolIsDuplicate = Convert.ToBoolean(reader[C_IsDuplicate]);
                    if (reader.GetName(i).ToUpper().Equals(C_DuplicateDesc.ToUpper()) && !Convert.IsDBNull(reader[C_DuplicateDesc])) this.strDuplicateDesc = Convert.ToString(reader[C_DuplicateDesc]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_RequestSchedule", objEx);
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
                if (!Convert.IsDBNull(drw[C_RequestScheduleID])) this.lngRequestScheduleID = Convert.ToInt64(drw[C_RequestScheduleID]);
                if (!Convert.IsDBNull(drw[C_ClassSubjectID])) this.lngClassSubjectID = Convert.ToInt64(drw[C_ClassSubjectID]);
                if (!Convert.IsDBNull(drw[C_ClassID])) this.strClassID = Convert.ToString(drw[C_ClassID]);
                if (!Convert.IsDBNull(drw[C_SubjectID])) this.strSubjectID = Convert.ToString(drw[C_SubjectID]);
                if (!Convert.IsDBNull(drw[C_YearID])) this.intYearID = Convert.ToInt32(drw[C_YearID]);
                if (!Convert.IsDBNull(drw[C_Semester])) this.intSemester = Convert.ToInt32(drw[C_Semester]);
                if (!Convert.IsDBNull(drw[C_Day])) this.intDay = Convert.ToInt32(drw[C_Day]);
                if (!Convert.IsDBNull(drw[C_Date])) this.dtmDate = Convert.ToDateTime(drw[C_Date]);
                if (!Convert.IsDBNull(drw[C_Week])) this.intWeek = Convert.ToInt32(drw[C_Week]);
                if (!Convert.IsDBNull(drw[C_FromLessionTime])) this.intFromLessionTime = Convert.ToInt32(drw[C_FromLessionTime]);
                if (!Convert.IsDBNull(drw[C_ToLessionTime])) this.intToLessionTime = Convert.ToInt32(drw[C_ToLessionTime]);
                if (!Convert.IsDBNull(drw[C_TeacherID])) this.strTeacherID = Convert.ToString(drw[C_TeacherID]);
                if (!Convert.IsDBNull(drw[C_RoomID])) this.strRoomID = Convert.ToString(drw[C_RoomID]);
                if (!Convert.IsDBNull(drw[C_IsPractice])) this.bolIsPractice = Convert.ToBoolean(drw[C_IsPractice]);
                if (!Convert.IsDBNull(drw[C_LearningSession])) this.intLearningSession = Convert.ToInt32(drw[C_LearningSession]);
                if (!Convert.IsDBNull(drw[C_AddLession])) this.intAddLession = Convert.ToInt32(drw[C_AddLession]);
                if (!Convert.IsDBNull(drw[C_ScheduleContent])) this.strScheduleContent = Convert.ToString(drw[C_ScheduleContent]);
                if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
                if (!Convert.IsDBNull(drw[C_OldDay])) this.intOldDay = Convert.ToInt32(drw[C_OldDay]);
                if (!Convert.IsDBNull(drw[C_OldDate])) this.dtmOldDate = Convert.ToDateTime(drw[C_OldDate]);
                if (!Convert.IsDBNull(drw[C_OldWeek])) this.intOldWeek = Convert.ToInt32(drw[C_OldWeek]);
                if (!Convert.IsDBNull(drw[C_OldFromLessionTime])) this.intOldFromLessionTime = Convert.ToInt32(drw[C_OldFromLessionTime]);
                if (!Convert.IsDBNull(drw[C_OldToLessionTime])) this.intOldToLessionTime = Convert.ToInt32(drw[C_OldToLessionTime]);
                if (!Convert.IsDBNull(drw[C_OldTeacherID])) this.strOldTeacherID = Convert.ToString(drw[C_OldTeacherID]);
                if (!Convert.IsDBNull(drw[C_OldRoomID])) this.strOldRoomID = Convert.ToString(drw[C_OldRoomID]);
                if (!Convert.IsDBNull(drw[C_IsReviewed])) this.bolIsReviewed = Convert.ToBoolean(drw[C_IsReviewed]);
                if (!Convert.IsDBNull(drw[C_ReviewedDate])) this.dtmReviewedDate = Convert.ToDateTime(drw[C_ReviewedDate]);
                if (!Convert.IsDBNull(drw[C_ReviewedUser])) this.strReviewedUser = Convert.ToString(drw[C_ReviewedUser]);
                if (!Convert.IsDBNull(drw[C_ReviewedComment])) this.strReviewedComment = Convert.ToString(drw[C_ReviewedComment]);
                if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
                if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
                if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
                if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
                if (!Convert.IsDBNull(drw[C_IsReviewed1])) this.bolIsReviewed1 = Convert.ToBoolean(drw[C_IsReviewed1]);
                if (!Convert.IsDBNull(drw[C_ReviewedDate1])) this.dtmReviewedDate1 = Convert.ToDateTime(drw[C_ReviewedDate1]);
                if (!Convert.IsDBNull(drw[C_ReviewedUser1])) this.strReviewedUser1 = Convert.ToString(drw[C_ReviewedUser1]);
                if (!Convert.IsDBNull(drw[C_ReviewedComment1])) this.strReviewedComment1 = Convert.ToString(drw[C_ReviewedComment1]);
                if (!Convert.IsDBNull(drw[C_WithinRequestScheduleID])) this.lngWithinRequestScheduleID = Convert.ToInt64(drw[C_WithinRequestScheduleID]);
                if (!Convert.IsDBNull(drw[C_IsDuplicate])) this.bolIsDuplicate = Convert.ToBoolean(drw[C_IsDuplicate]);
                if (!Convert.IsDBNull(drw[C_DuplicateDesc])) this.strDuplicateDesc = Convert.ToString(drw[C_DuplicateDesc]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_RequestSchedule", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        /// Nạp thông tin item 
        /// Store: SIM_RequestSchedule_GET 
        ///</summary>
        /// <returns>true ? Có : False ? Không</returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_RequestSchedule_GET");
                objIData.AddParameter(P_RequestScheduleID, this.lngRequestScheduleID);
                IDataReader reader = objIData.ExecStoreToDataReader();
                if (reader.Read())
                {
                    if (Parse(reader))
                    {
                        reader.Close();
                        return true;
                    }
                }
                reader.Close();
                return false;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_RequestSchedule", objEx);
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
        /// Nạp thông tin item 
        /// Store: SIM_RequestSchedule_GET 
        ///</summary>
        /// <returns> SIM_RequestSchedule </returns>
        public SIM_RequestSchedule Get(long? lngRequestScheduleID)
        {
            SIM_RequestSchedule obj = new SIM_RequestSchedule();
            if (objIData != null)
                obj.IDB = objIData;
            obj.RequestScheduleID = lngRequestScheduleID;
            if (obj.Get())
                return obj;
            this.objErrorException = obj.ErrorException;
            return null;
        }
        ///<summary>
        /// ExecNonQuery : SIM_RequestSchedule
        /// Thực hiện store trả về true/false
        /// <returns> true/false </returns>
        ///</summary>
        public bool ExecNonQuery(string storeName, params object[] pars)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(storeName);
                objIData.AddParameter(pars);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_RequestSchedule", objEx);
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
        /// Search : SIM_RequestSchedule
        /// Tìm dữ liệu
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable GetDataTable(string storeName, params object[] pars)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(storeName);
                objIData.AddParameter(pars);
                return objIData.ExecStoreToDataTable();
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_RequestSchedule", objEx);
                this.objErrorException = objEx;
                return null;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        ///<summary>
        /// Search : SIM_RequestSchedule
        /// Lấy hết dữ liệu
        /// Store: SIM_RequestSchedule_GETALL 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable GetAll()
        {
            return GetDataTable("SIM_RequestSchedule_GETALL");
        }

        ///<summary>
        /// Search : SIM_RequestSchedule
        /// Tìm dữ liệu
        /// Store: SIM_RequestSchedule_SEARCH 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable Search(params object[] pars)
        {
            return GetDataTable("SIM_RequestSchedule_SEARCH", pars);
        }

        ///<summary>
        /// Add : SIM_RequestSchedule
        /// Thêm dữ liệu
        /// Store: SIM_RequestSchedule_ADD 
        ///</summary>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_RequestSchedule_ADD");
                objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
                objIData.AddParameter(P_ClassID, this.strClassID);
                objIData.AddParameter(P_SubjectID, this.strSubjectID);
                objIData.AddParameter(P_YearID, this.intYearID);
                objIData.AddParameter(P_Semester, this.intSemester);
                objIData.AddParameter(P_Day, this.intDay);
                objIData.AddParameter(P_Date, this.dtmDate);
                objIData.AddParameter(P_Week, this.intWeek);
                objIData.AddParameter(P_FromLessionTime, this.intFromLessionTime);
                objIData.AddParameter(P_ToLessionTime, this.intToLessionTime);
                objIData.AddParameter(P_TeacherID, this.strTeacherID);
                objIData.AddParameter(P_RoomID, this.strRoomID);
                objIData.AddParameter(P_IsPractice, this.bolIsPractice);
                objIData.AddParameter(P_LearningSession, this.intLearningSession);
                objIData.AddParameter(P_AddLession, this.intAddLession);
                objIData.AddParameter(P_ScheduleContent, this.strScheduleContent);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_OldDay, this.intOldDay);
                objIData.AddParameter(P_OldDate, this.dtmOldDate);
                objIData.AddParameter(P_OldWeek, this.intOldWeek);
                objIData.AddParameter(P_OldFromLessionTime, this.intOldFromLessionTime);
                objIData.AddParameter(P_OldToLessionTime, this.intOldToLessionTime);
                objIData.AddParameter(P_OldTeacherID, this.strOldTeacherID);
                objIData.AddParameter(P_OldRoomID, this.strOldRoomID);
                objIData.AddParameter(P_IsReviewed, this.bolIsReviewed);
                objIData.AddParameter(P_ReviewedDate, this.dtmReviewedDate);
                objIData.AddParameter(P_ReviewedUser, this.strReviewedUser);
                objIData.AddParameter(P_ReviewedComment, this.strReviewedComment);
                objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
                objIData.AddParameter(P_IsReviewed1, this.bolIsReviewed1);
                objIData.AddParameter(P_ReviewedDate1, this.dtmReviewedDate1);
                objIData.AddParameter(P_ReviewedUser1, this.strReviewedUser1);
                objIData.AddParameter(P_ReviewedComment1, this.strReviewedComment1);
                objIData.AddParameter(P_WithinRequestScheduleID, this.lngWithinRequestScheduleID);
                objIData.AddParameter(P_IsDuplicate, this.bolIsDuplicate);
                objIData.AddParameter(P_DuplicateDesc, this.strDuplicateDesc);
                this.lngRequestScheduleID = Convert.ToInt32(objIData.ExecStoreToString());
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_RequestSchedule", objEx);
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
        /// Update : SIM_RequestSchedule
        /// Cập nhật dữ liệu
        /// Store: SIM_RequestSchedule_EDIT 
        ///</summary>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_RequestSchedule_EDIT");
                objIData.AddParameter(P_RequestScheduleID, this.lngRequestScheduleID);
                objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
                objIData.AddParameter(P_ClassID, this.strClassID);
                objIData.AddParameter(P_SubjectID, this.strSubjectID);
                objIData.AddParameter(P_YearID, this.intYearID);
                objIData.AddParameter(P_Semester, this.intSemester);
                objIData.AddParameter(P_Day, this.intDay);
                objIData.AddParameter(P_Date, this.dtmDate);
                objIData.AddParameter(P_Week, this.intWeek);
                objIData.AddParameter(P_FromLessionTime, this.intFromLessionTime);
                objIData.AddParameter(P_ToLessionTime, this.intToLessionTime);
                objIData.AddParameter(P_TeacherID, this.strTeacherID);
                objIData.AddParameter(P_RoomID, this.strRoomID);
                objIData.AddParameter(P_IsPractice, this.bolIsPractice);
                objIData.AddParameter(P_LearningSession, this.intLearningSession);
                objIData.AddParameter(P_AddLession, this.intAddLession);
                objIData.AddParameter(P_ScheduleContent, this.strScheduleContent);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_OldDay, this.intOldDay);
                objIData.AddParameter(P_OldDate, this.dtmOldDate);
                objIData.AddParameter(P_OldWeek, this.intOldWeek);
                objIData.AddParameter(P_OldFromLessionTime, this.intOldFromLessionTime);
                objIData.AddParameter(P_OldToLessionTime, this.intOldToLessionTime);
                objIData.AddParameter(P_OldTeacherID, this.strOldTeacherID);
                objIData.AddParameter(P_OldRoomID, this.strOldRoomID);
                objIData.AddParameter(P_IsReviewed, this.bolIsReviewed);
                objIData.AddParameter(P_ReviewedDate, this.dtmReviewedDate);
                objIData.AddParameter(P_ReviewedUser, this.strReviewedUser);
                objIData.AddParameter(P_ReviewedComment, this.strReviewedComment);
                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
                objIData.AddParameter(P_IsReviewed1, this.bolIsReviewed1);
                objIData.AddParameter(P_ReviewedDate1, this.dtmReviewedDate1);
                objIData.AddParameter(P_ReviewedUser1, this.strReviewedUser1);
                objIData.AddParameter(P_ReviewedComment1, this.strReviewedComment1);
                objIData.AddParameter(P_WithinRequestScheduleID, this.lngWithinRequestScheduleID);
                objIData.AddParameter(P_IsDuplicate, this.bolIsDuplicate);
                objIData.AddParameter(P_DuplicateDesc, this.strDuplicateDesc);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_RequestSchedule", objEx);
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
        /// Delete : SIM_RequestSchedule
        /// Xóa dữ liệu
        /// Store: SIM_RequestSchedule_DELETE 
        ///</summary>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_RequestSchedule_DELETE");
                objIData.AddParameter(P_RequestScheduleID, this.lngRequestScheduleID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_RequestSchedule", objEx);
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
        /// Store: SIM_RequestSchedule_DELETE 
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long? lngRequestScheduleID)
        {
            this.lngRequestScheduleID = lngRequestScheduleID;
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

        public SIM_RequestSchedule()
        {
        }
        public SIM_RequestSchedule(long? lngRequestScheduleID)
        {
            this.lngRequestScheduleID = lngRequestScheduleID;
            this.Get();
        }

        #endregion

        #region Variable Static

        #region Parameter Names

        public const String P_RequestScheduleID = "@" + C_RequestScheduleID;
        public const String P_ClassSubjectID = "@" + C_ClassSubjectID;
        public const String P_ClassID = "@" + C_ClassID;
        public const String P_SubjectID = "@" + C_SubjectID;
        public const String P_YearID = "@" + C_YearID;
        public const String P_Semester = "@" + C_Semester;
        public const String P_Day = "@" + C_Day;
        public const String P_Date = "@" + C_Date;
        public const String P_Week = "@" + C_Week;
        public const String P_FromLessionTime = "@" + C_FromLessionTime;
        public const String P_ToLessionTime = "@" + C_ToLessionTime;
        public const String P_TeacherID = "@" + C_TeacherID;
        public const String P_RoomID = "@" + C_RoomID;
        public const String P_IsPractice = "@" + C_IsPractice;
        public const String P_LearningSession = "@" + C_LearningSession;
        public const String P_AddLession = "@" + C_AddLession;
        public const String P_ScheduleContent = "@" + C_ScheduleContent;
        public const String P_Description = "@" + C_Description;
        public const String P_OldDay = "@" + C_OldDay;
        public const String P_OldDate = "@" + C_OldDate;
        public const String P_OldWeek = "@" + C_OldWeek;
        public const String P_OldFromLessionTime = "@" + C_OldFromLessionTime;
        public const String P_OldToLessionTime = "@" + C_OldToLessionTime;
        public const String P_OldTeacherID = "@" + C_OldTeacherID;
        public const String P_OldRoomID = "@" + C_OldRoomID;
        public const String P_IsReviewed = "@" + C_IsReviewed;
        public const String P_ReviewedDate = "@" + C_ReviewedDate;
        public const String P_ReviewedUser = "@" + C_ReviewedUser;
        public const String P_ReviewedComment = "@" + C_ReviewedComment;
        public const String P_CreatedDate = "@" + C_CreatedDate;
        public const String P_CreatedUser = "@" + C_CreatedUser;
        public const String P_UpdatedDate = "@" + C_UpdatedDate;
        public const String P_UpdatedUser = "@" + C_UpdatedUser;
        public const String P_IsReviewed1 = "@" + C_IsReviewed1;
        public const String P_ReviewedDate1 = "@" + C_ReviewedDate1;
        public const String P_ReviewedUser1 = "@" + C_ReviewedUser1;
        public const String P_ReviewedComment1 = "@" + C_ReviewedComment1;
        public const String P_WithinRequestScheduleID = "@" + C_WithinRequestScheduleID;
        public const String P_IsDuplicate = "@" + C_IsDuplicate;
        public const String P_DuplicateDesc = "@" + C_DuplicateDesc;

        #endregion //Parameter names

        #region Column Names

        public const String C_RequestScheduleID = "RequestScheduleID";
        public const String C_ClassSubjectID = "ClassSubjectID";
        public const String C_ClassID = "ClassID";
        public const String C_SubjectID = "SubjectID";
        public const String C_YearID = "YearID";
        public const String C_Semester = "Semester";
        public const String C_Day = "Day";
        public const String C_Date = "Date";
        public const String C_Week = "Week";
        public const String C_FromLessionTime = "FromLessionTime";
        public const String C_ToLessionTime = "ToLessionTime";
        public const String C_TeacherID = "TeacherID";
        public const String C_RoomID = "RoomID";
        public const String C_IsPractice = "IsPractice";
        public const String C_LearningSession = "LearningSession";
        public const String C_AddLession = "AddLession";
        public const String C_ScheduleContent = "ScheduleContent";
        public const String C_Description = "Description";
        public const String C_OldDay = "OldDay";
        public const String C_OldDate = "OldDate";
        public const String C_OldWeek = "OldWeek";
        public const String C_OldFromLessionTime = "OldFromLessionTime";
        public const String C_OldToLessionTime = "OldToLessionTime";
        public const String C_OldTeacherID = "OldTeacherID";
        public const String C_OldRoomID = "OldRoomID";
        public const String C_IsReviewed = "IsReviewed";
        public const String C_ReviewedDate = "ReviewedDate";
        public const String C_ReviewedUser = "ReviewedUser";
        public const String C_ReviewedComment = "ReviewedComment";
        public const String C_CreatedDate = "CreatedDate";
        public const String C_CreatedUser = "CreatedUser";
        public const String C_UpdatedDate = "UpdatedDate";
        public const String C_UpdatedUser = "UpdatedUser";
        public const String C_IsReviewed1 = "IsReviewed1";
        public const String C_ReviewedDate1 = "ReviewedDate1";
        public const String C_ReviewedUser1 = "ReviewedUser1";
        public const String C_ReviewedComment1 = "ReviewedComment1";
        public const String C_WithinRequestScheduleID = "WithinRequestScheduleID";
        public const String C_IsDuplicate = "IsDuplicate";
        public const String C_DuplicateDesc = "DuplicateDesc";

        #endregion //Column names

        #endregion Variable Static
    }
}


