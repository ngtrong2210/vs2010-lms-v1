
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
    /// Created date 	: 2/19/2025 
    /// Description 
    /// </summary>	
    public partial class SIM_TestSchedule
    {
        #region Member Variables

        private long? lngScheduleID = null;//Mã lịch thi
        private int? intDay = null;//Thứ tính từ 0-6
        private DateTime? dtmDate = null;//Ngày thi
        private int? intWeek = null;//Tuần nào của niên học 1-50
        private int? intTestSessionID = null;//Mã ca thi
        private long? lngClassSubjectID = null;//Mã lớp học phần
        private string strClassID = null;//Mã lớp học
        private string strSubjectID = null;//Mã môn học
        private int? intYearID = null;
        private int? intSemester = null;
        private string strTeacherID1 = null;//Giảng viên coi thi
        private string strTeacherID2 = null;//Giảng viên coi thi
        private string strTeacherID3 = null;//Giảng viên coi thi
        private string strRoomID = null;//Mã phòng thi
        private string strRoomID2 = null;//Mã phòng thi
        private bool bolIsPractice = false;//Thi thực hành
        private int? intTestOrder = null;//Lần thi
        private int? intExamDateID = null;//Mã kì thi, dành cho tổ chức thi
        private bool bolIsLocked = false;//Đã bị khóa, không cho nhập
        private string strCreatedUser = null;//Người tạo lịch thi
        private DateTime? dtmCreatedDate = null;//Ngày tạo
        private DateTime? dtmStartAt = null;//Ngày giờ bắt đầu
        private DateTime? dtmFinishAt = null;//Ngày giờ kết thúc
        private int? intMarkGroup = null;//Nhóm cột (0_Mặc định là Exam như cũ, 1_Nhóm 1 (HS1/Midtern), 2_Nhóm 2 (HS2/Final), 3_Nhóm 3(HW)
        private string strDescription = null;
        private string strSignedData = null;//Dữ liệu đã ký mã hóa
        private string strSignedUser = null;
        private DateTime? dtmSignedDate = null;
        private bool bolIsMakeTestSchedule = false;//Là lịch kiểm tra thường xuyên/ định kỳ online (gv tự tạo ko phải lịch thi kết thúc môn, không hiển thị trên lịch học, ko kiểm trùng)
        private bool bolIsAutoTest = false;//0 là phải chờ quản trị viên cho thi; 1 là tự động cho thi
        private bool bolIsActived = false;//Kích hoạt (do dùng cho gv tổ chức kiểm tra, cho nên kích hoạt thì học sinh mới thấy)
        private int? intMethodTestID = null;//Hình thức thi của lịch thi này, khi tạo thì lưu theo qua từ kế hoạch thi luôn
        private int? intStudentCount = null;//Số thí sinh (nhập lại)
        private string strReviewTeacherID1 = null;//Giám thị 1 (lấy trong gv)
        private string strReviewTeacherID2 = null;//Giám thị 2
        private string strReviewTeacherID3 = null;//Giám thị 3
        private string strControlTeacherID = null;//Giáo viên điều hành
        private string strNoteTeacherID = null;//Giáo viên thư ký
        private string strFollowTeacherID = null;//Gv giám sát
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// ScheduleID
        /// Mã lịch thi
        /// </summary>
        public long? ScheduleID
        {
            get { return lngScheduleID; }
            set { lngScheduleID = value; }
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
        /// Ngày thi
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
        /// TestSessionID
        /// Mã ca thi
        /// </summary>
        public int? TestSessionID
        {
            get { return intTestSessionID; }
            set { intTestSessionID = value; }
        }
        /// <summary>
        /// ClassSubjectID
        /// Mã lớp học phần
        /// </summary>
        public long? ClassSubjectID
        {
            get { return lngClassSubjectID; }
            set { lngClassSubjectID = value; }
        }
        /// <summary>
        /// ClassID
        /// Mã lớp học
        /// </summary>
        public string ClassID
        {
            get { return strClassID; }
            set { strClassID = value; }
        }
        /// <summary>
        /// SubjectID
        /// Mã môn học
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
        /// TeacherID1
        /// Giảng viên coi thi
        /// </summary>
        public string TeacherID1
        {
            get { return strTeacherID1; }
            set { strTeacherID1 = value; }
        }
        /// <summary>
        /// TeacherID2
        /// Giảng viên coi thi
        /// </summary>
        public string TeacherID2
        {
            get { return strTeacherID2; }
            set { strTeacherID2 = value; }
        }
        /// <summary>
        /// TeacherID3
        /// Giảng viên coi thi
        /// </summary>
        public string TeacherID3
        {
            get { return strTeacherID3; }
            set { strTeacherID3 = value; }
        }
        /// <summary>
        /// RoomID
        /// Mã phòng thi
        /// </summary>
        public string RoomID
        {
            get { return strRoomID; }
            set { strRoomID = value; }
        }
        /// <summary>
        /// RoomID2
        /// Mã phòng thi
        /// </summary>
        public string RoomID2
        {
            get { return strRoomID2; }
            set { strRoomID2 = value; }
        }
        /// <summary>
        /// IsPractice
        /// Thi thực hành
        /// </summary>
        public bool IsPractice
        {
            get { return bolIsPractice; }
            set { bolIsPractice = value; }
        }
        /// <summary>
        /// TestOrder
        /// Lần thi
        /// </summary>
        public int? TestOrder
        {
            get { return intTestOrder; }
            set { intTestOrder = value; }
        }
        /// <summary>
        /// ExamDateID
        /// Mã kì thi, dành cho tổ chức thi
        /// </summary>
        public int? ExamDateID
        {
            get { return intExamDateID; }
            set { intExamDateID = value; }
        }
        /// <summary>
        /// IsLocked
        /// Đã bị khóa, không cho nhập
        /// </summary>
        public bool IsLocked
        {
            get { return bolIsLocked; }
            set { bolIsLocked = value; }
        }
        /// <summary>
        /// CreatedUser
        /// Người tạo lịch thi
        /// </summary>
        public string CreatedUser
        {
            get { return strCreatedUser; }
            set { strCreatedUser = value; }
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
        /// StartAt
        /// Ngày giờ bắt đầu
        /// </summary>
        public DateTime? StartAt
        {
            get { return dtmStartAt; }
            set { dtmStartAt = value; }
        }
        /// <summary>
        /// FinishAt
        /// Ngày giờ kết thúc
        /// </summary>
        public DateTime? FinishAt
        {
            get { return dtmFinishAt; }
            set { dtmFinishAt = value; }
        }
        /// <summary>
        /// MarkGroup
        /// Nhóm cột (0_Mặc định là Exam như cũ, 1_Nhóm 1 (HS1/Midtern), 2_Nhóm 2 (HS2/Final), 3_Nhóm 3(HW)
        /// </summary>
        public int? MarkGroup
        {
            get { return intMarkGroup; }
            set { intMarkGroup = value; }
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
        /// SignedData
        /// Dữ liệu đã ký mã hóa
        /// </summary>
        public string SignedData
        {
            get { return strSignedData; }
            set { strSignedData = value; }
        }
        /// <summary>
        /// SignedUser
        /// 
        /// </summary>
        public string SignedUser
        {
            get { return strSignedUser; }
            set { strSignedUser = value; }
        }
        /// <summary>
        /// SignedDate
        /// 
        /// </summary>
        public DateTime? SignedDate
        {
            get { return dtmSignedDate; }
            set { dtmSignedDate = value; }
        }
        /// <summary>
        /// IsMakeTestSchedule
        /// Là lịch kiểm tra thường xuyên/ định kỳ online (gv tự tạo ko phải lịch thi kết thúc môn, không hiển thị trên lịch học, ko kiểm trùng)
        /// </summary>
        public bool IsMakeTestSchedule
        {
            get { return bolIsMakeTestSchedule; }
            set { bolIsMakeTestSchedule = value; }
        }
        /// <summary>
        /// IsAutoTest
        /// 0 là phải chờ quản trị viên cho thi; 1 là tự động cho thi
        /// </summary>
        public bool IsAutoTest
        {
            get { return bolIsAutoTest; }
            set { bolIsAutoTest = value; }
        }
        /// <summary>
        /// IsActived
        /// Kích hoạt (do dùng cho gv tổ chức kiểm tra, cho nên kích hoạt thì học sinh mới thấy)
        /// </summary>
        public bool IsActived
        {
            get { return bolIsActived; }
            set { bolIsActived = value; }
        }
        /// <summary>
        /// MethodTestID
        /// Hình thức thi của lịch thi này, khi tạo thì lưu theo qua từ kế hoạch thi luôn
        /// </summary>
        public int? MethodTestID
        {
            get { return intMethodTestID; }
            set { intMethodTestID = value; }
        }
        /// <summary>
        /// StudentCount
        /// Số thí sinh (nhập lại)
        /// </summary>
        public int? StudentCount
        {
            get { return intStudentCount; }
            set { intStudentCount = value; }
        }
        /// <summary>
        /// ReviewTeacherID1
        /// Giám thị 1 (lấy trong gv)
        /// </summary>
        public string ReviewTeacherID1
        {
            get { return strReviewTeacherID1; }
            set { strReviewTeacherID1 = value; }
        }
        /// <summary>
        /// ReviewTeacherID2
        /// Giám thị 2
        /// </summary>
        public string ReviewTeacherID2
        {
            get { return strReviewTeacherID2; }
            set { strReviewTeacherID2 = value; }
        }
        /// <summary>
        /// ReviewTeacherID3
        /// Giám thị 3
        /// </summary>
        public string ReviewTeacherID3
        {
            get { return strReviewTeacherID3; }
            set { strReviewTeacherID3 = value; }
        }
        /// <summary>
        /// ControlTeacherID
        /// Giáo viên điều hành
        /// </summary>
        public string ControlTeacherID
        {
            get { return strControlTeacherID; }
            set { strControlTeacherID = value; }
        }
        /// <summary>
        /// NoteTeacherID
        /// Giáo viên thư ký
        /// </summary>
        public string NoteTeacherID
        {
            get { return strNoteTeacherID; }
            set { strNoteTeacherID = value; }
        }
        /// <summary>
        /// FollowTeacherID
        /// Gv giám sát
        /// </summary>
        public string FollowTeacherID
        {
            get { return strFollowTeacherID; }
            set { strFollowTeacherID = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_ScheduleID.ToUpper()) && !Convert.IsDBNull(reader[C_ScheduleID])) this.lngScheduleID = Convert.ToInt64(reader[C_ScheduleID]);
                    if (reader.GetName(i).ToUpper().Equals(C_Day.ToUpper()) && !Convert.IsDBNull(reader[C_Day])) this.intDay = Convert.ToInt32(reader[C_Day]);
                    if (reader.GetName(i).ToUpper().Equals(C_Date.ToUpper()) && !Convert.IsDBNull(reader[C_Date])) this.dtmDate = Convert.ToDateTime(reader[C_Date]);
                    if (reader.GetName(i).ToUpper().Equals(C_Week.ToUpper()) && !Convert.IsDBNull(reader[C_Week])) this.intWeek = Convert.ToInt32(reader[C_Week]);
                    if (reader.GetName(i).ToUpper().Equals(C_TestSessionID.ToUpper()) && !Convert.IsDBNull(reader[C_TestSessionID])) this.intTestSessionID = Convert.ToInt32(reader[C_TestSessionID]);
                    if (reader.GetName(i).ToUpper().Equals(C_ClassSubjectID.ToUpper()) && !Convert.IsDBNull(reader[C_ClassSubjectID])) this.lngClassSubjectID = Convert.ToInt64(reader[C_ClassSubjectID]);
                    if (reader.GetName(i).ToUpper().Equals(C_ClassID.ToUpper()) && !Convert.IsDBNull(reader[C_ClassID])) this.strClassID = Convert.ToString(reader[C_ClassID]);
                    if (reader.GetName(i).ToUpper().Equals(C_SubjectID.ToUpper()) && !Convert.IsDBNull(reader[C_SubjectID])) this.strSubjectID = Convert.ToString(reader[C_SubjectID]);
                    if (reader.GetName(i).ToUpper().Equals(C_YearID.ToUpper()) && !Convert.IsDBNull(reader[C_YearID])) this.intYearID = Convert.ToInt32(reader[C_YearID]);
                    if (reader.GetName(i).ToUpper().Equals(C_Semester.ToUpper()) && !Convert.IsDBNull(reader[C_Semester])) this.intSemester = Convert.ToInt32(reader[C_Semester]);
                    if (reader.GetName(i).ToUpper().Equals(C_TeacherID1.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherID1])) this.strTeacherID1 = Convert.ToString(reader[C_TeacherID1]);
                    if (reader.GetName(i).ToUpper().Equals(C_TeacherID2.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherID2])) this.strTeacherID2 = Convert.ToString(reader[C_TeacherID2]);
                    if (reader.GetName(i).ToUpper().Equals(C_TeacherID3.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherID3])) this.strTeacherID3 = Convert.ToString(reader[C_TeacherID3]);
                    if (reader.GetName(i).ToUpper().Equals(C_RoomID.ToUpper()) && !Convert.IsDBNull(reader[C_RoomID])) this.strRoomID = Convert.ToString(reader[C_RoomID]);
                    if (reader.GetName(i).ToUpper().Equals(C_RoomID2.ToUpper()) && !Convert.IsDBNull(reader[C_RoomID2])) this.strRoomID2 = Convert.ToString(reader[C_RoomID2]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsPractice.ToUpper()) && !Convert.IsDBNull(reader[C_IsPractice])) this.bolIsPractice = Convert.ToBoolean(reader[C_IsPractice]);
                    if (reader.GetName(i).ToUpper().Equals(C_TestOrder.ToUpper()) && !Convert.IsDBNull(reader[C_TestOrder])) this.intTestOrder = Convert.ToInt32(reader[C_TestOrder]);
                    if (reader.GetName(i).ToUpper().Equals(C_ExamDateID.ToUpper()) && !Convert.IsDBNull(reader[C_ExamDateID])) this.intExamDateID = Convert.ToInt32(reader[C_ExamDateID]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsLocked.ToUpper()) && !Convert.IsDBNull(reader[C_IsLocked])) this.bolIsLocked = Convert.ToBoolean(reader[C_IsLocked]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_StartAt.ToUpper()) && !Convert.IsDBNull(reader[C_StartAt])) this.dtmStartAt = Convert.ToDateTime(reader[C_StartAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_FinishAt.ToUpper()) && !Convert.IsDBNull(reader[C_FinishAt])) this.dtmFinishAt = Convert.ToDateTime(reader[C_FinishAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_MarkGroup.ToUpper()) && !Convert.IsDBNull(reader[C_MarkGroup])) this.intMarkGroup = Convert.ToInt32(reader[C_MarkGroup]);
                    if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
                    if (reader.GetName(i).ToUpper().Equals(C_SignedData.ToUpper()) && !Convert.IsDBNull(reader[C_SignedData])) this.strSignedData = Convert.ToString(reader[C_SignedData]);
                    if (reader.GetName(i).ToUpper().Equals(C_SignedUser.ToUpper()) && !Convert.IsDBNull(reader[C_SignedUser])) this.strSignedUser = Convert.ToString(reader[C_SignedUser]);
                    if (reader.GetName(i).ToUpper().Equals(C_SignedDate.ToUpper()) && !Convert.IsDBNull(reader[C_SignedDate])) this.dtmSignedDate = Convert.ToDateTime(reader[C_SignedDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsMakeTestSchedule.ToUpper()) && !Convert.IsDBNull(reader[C_IsMakeTestSchedule])) this.bolIsMakeTestSchedule = Convert.ToBoolean(reader[C_IsMakeTestSchedule]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsAutoTest.ToUpper()) && !Convert.IsDBNull(reader[C_IsAutoTest])) this.bolIsAutoTest = Convert.ToBoolean(reader[C_IsAutoTest]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsActived.ToUpper()) && !Convert.IsDBNull(reader[C_IsActived])) this.bolIsActived = Convert.ToBoolean(reader[C_IsActived]);
                    if (reader.GetName(i).ToUpper().Equals(C_MethodTestID.ToUpper()) && !Convert.IsDBNull(reader[C_MethodTestID])) this.intMethodTestID = Convert.ToInt32(reader[C_MethodTestID]);
                    if (reader.GetName(i).ToUpper().Equals(C_StudentCount.ToUpper()) && !Convert.IsDBNull(reader[C_StudentCount])) this.intStudentCount = Convert.ToInt32(reader[C_StudentCount]);
                    if (reader.GetName(i).ToUpper().Equals(C_ReviewTeacherID1.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewTeacherID1])) this.strReviewTeacherID1 = Convert.ToString(reader[C_ReviewTeacherID1]);
                    if (reader.GetName(i).ToUpper().Equals(C_ReviewTeacherID2.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewTeacherID2])) this.strReviewTeacherID2 = Convert.ToString(reader[C_ReviewTeacherID2]);
                    if (reader.GetName(i).ToUpper().Equals(C_ReviewTeacherID3.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewTeacherID3])) this.strReviewTeacherID3 = Convert.ToString(reader[C_ReviewTeacherID3]);
                    if (reader.GetName(i).ToUpper().Equals(C_ControlTeacherID.ToUpper()) && !Convert.IsDBNull(reader[C_ControlTeacherID])) this.strControlTeacherID = Convert.ToString(reader[C_ControlTeacherID]);
                    if (reader.GetName(i).ToUpper().Equals(C_NoteTeacherID.ToUpper()) && !Convert.IsDBNull(reader[C_NoteTeacherID])) this.strNoteTeacherID = Convert.ToString(reader[C_NoteTeacherID]);
                    if (reader.GetName(i).ToUpper().Equals(C_FollowTeacherID.ToUpper()) && !Convert.IsDBNull(reader[C_FollowTeacherID])) this.strFollowTeacherID = Convert.ToString(reader[C_FollowTeacherID]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_TestSchedule", objEx);
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
                if (!Convert.IsDBNull(drw[C_ScheduleID])) this.lngScheduleID = Convert.ToInt64(drw[C_ScheduleID]);
                if (!Convert.IsDBNull(drw[C_Day])) this.intDay = Convert.ToInt32(drw[C_Day]);
                if (!Convert.IsDBNull(drw[C_Date])) this.dtmDate = Convert.ToDateTime(drw[C_Date]);
                if (!Convert.IsDBNull(drw[C_Week])) this.intWeek = Convert.ToInt32(drw[C_Week]);
                if (!Convert.IsDBNull(drw[C_TestSessionID])) this.intTestSessionID = Convert.ToInt32(drw[C_TestSessionID]);
                if (!Convert.IsDBNull(drw[C_ClassSubjectID])) this.lngClassSubjectID = Convert.ToInt64(drw[C_ClassSubjectID]);
                if (!Convert.IsDBNull(drw[C_ClassID])) this.strClassID = Convert.ToString(drw[C_ClassID]);
                if (!Convert.IsDBNull(drw[C_SubjectID])) this.strSubjectID = Convert.ToString(drw[C_SubjectID]);
                if (!Convert.IsDBNull(drw[C_YearID])) this.intYearID = Convert.ToInt32(drw[C_YearID]);
                if (!Convert.IsDBNull(drw[C_Semester])) this.intSemester = Convert.ToInt32(drw[C_Semester]);
                if (!Convert.IsDBNull(drw[C_TeacherID1])) this.strTeacherID1 = Convert.ToString(drw[C_TeacherID1]);
                if (!Convert.IsDBNull(drw[C_TeacherID2])) this.strTeacherID2 = Convert.ToString(drw[C_TeacherID2]);
                if (!Convert.IsDBNull(drw[C_TeacherID3])) this.strTeacherID3 = Convert.ToString(drw[C_TeacherID3]);
                if (!Convert.IsDBNull(drw[C_RoomID])) this.strRoomID = Convert.ToString(drw[C_RoomID]);
                if (!Convert.IsDBNull(drw[C_RoomID2])) this.strRoomID2 = Convert.ToString(drw[C_RoomID2]);
                if (!Convert.IsDBNull(drw[C_IsPractice])) this.bolIsPractice = Convert.ToBoolean(drw[C_IsPractice]);
                if (!Convert.IsDBNull(drw[C_TestOrder])) this.intTestOrder = Convert.ToInt32(drw[C_TestOrder]);
                if (!Convert.IsDBNull(drw[C_ExamDateID])) this.intExamDateID = Convert.ToInt32(drw[C_ExamDateID]);
                if (!Convert.IsDBNull(drw[C_IsLocked])) this.bolIsLocked = Convert.ToBoolean(drw[C_IsLocked]);
                if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
                if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
                if (!Convert.IsDBNull(drw[C_StartAt])) this.dtmStartAt = Convert.ToDateTime(drw[C_StartAt]);
                if (!Convert.IsDBNull(drw[C_FinishAt])) this.dtmFinishAt = Convert.ToDateTime(drw[C_FinishAt]);
                if (!Convert.IsDBNull(drw[C_MarkGroup])) this.intMarkGroup = Convert.ToInt32(drw[C_MarkGroup]);
                if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
                if (!Convert.IsDBNull(drw[C_SignedData])) this.strSignedData = Convert.ToString(drw[C_SignedData]);
                if (!Convert.IsDBNull(drw[C_SignedUser])) this.strSignedUser = Convert.ToString(drw[C_SignedUser]);
                if (!Convert.IsDBNull(drw[C_SignedDate])) this.dtmSignedDate = Convert.ToDateTime(drw[C_SignedDate]);
                if (!Convert.IsDBNull(drw[C_IsMakeTestSchedule])) this.bolIsMakeTestSchedule = Convert.ToBoolean(drw[C_IsMakeTestSchedule]);
                if (!Convert.IsDBNull(drw[C_IsAutoTest])) this.bolIsAutoTest = Convert.ToBoolean(drw[C_IsAutoTest]);
                if (!Convert.IsDBNull(drw[C_IsActived])) this.bolIsActived = Convert.ToBoolean(drw[C_IsActived]);
                if (!Convert.IsDBNull(drw[C_MethodTestID])) this.intMethodTestID = Convert.ToInt32(drw[C_MethodTestID]);
                if (!Convert.IsDBNull(drw[C_StudentCount])) this.intStudentCount = Convert.ToInt32(drw[C_StudentCount]);
                if (!Convert.IsDBNull(drw[C_ReviewTeacherID1])) this.strReviewTeacherID1 = Convert.ToString(drw[C_ReviewTeacherID1]);
                if (!Convert.IsDBNull(drw[C_ReviewTeacherID2])) this.strReviewTeacherID2 = Convert.ToString(drw[C_ReviewTeacherID2]);
                if (!Convert.IsDBNull(drw[C_ReviewTeacherID3])) this.strReviewTeacherID3 = Convert.ToString(drw[C_ReviewTeacherID3]);
                if (!Convert.IsDBNull(drw[C_ControlTeacherID])) this.strControlTeacherID = Convert.ToString(drw[C_ControlTeacherID]);
                if (!Convert.IsDBNull(drw[C_NoteTeacherID])) this.strNoteTeacherID = Convert.ToString(drw[C_NoteTeacherID]);
                if (!Convert.IsDBNull(drw[C_FollowTeacherID])) this.strFollowTeacherID = Convert.ToString(drw[C_FollowTeacherID]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_TestSchedule", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        /// Nạp thông tin item 
        /// Store: SIM_TestSchedule_GET 
        ///</summary>
        /// <returns>true ? Có : False ? Không</returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_TestSchedule_GET");
                objIData.AddParameter(P_ScheduleID, this.lngScheduleID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_TestSchedule", objEx);
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
        /// Store: SIM_TestSchedule_GET 
        ///</summary>
        /// <returns> SIM_TestSchedule </returns>
        public SIM_TestSchedule Get(long? lngScheduleID)
        {
            SIM_TestSchedule obj = new SIM_TestSchedule();
            if (objIData != null)
                obj.IDB = objIData;
            obj.ScheduleID = lngScheduleID;
            if (obj.Get())
                return obj;
            this.objErrorException = obj.ErrorException;
            return null;
        }
        ///<summary>
        /// ExecNonQuery : SIM_TestSchedule
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_TestSchedule", objEx);
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
        /// Search : SIM_TestSchedule
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_TestSchedule", objEx);
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
        /// Search : SIM_TestSchedule
        /// Lấy hết dữ liệu
        /// Store: SIM_TestSchedule_GETALL 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable GetAll()
        {
            return GetDataTable("SIM_TestSchedule_GETALL");
        }

        ///<summary>
        /// Search : SIM_TestSchedule
        /// Tìm dữ liệu
        /// Store: SIM_TestSchedule_SEARCH 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable Search(params object[] pars)
        {
            return GetDataTable("SIM_TestSchedule_SEARCH", pars);
        }

        ///<summary>
        /// Add : SIM_TestSchedule
        /// Thêm dữ liệu
        /// Store: SIM_TestSchedule_ADD 
        ///</summary>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_TestSchedule_ADD");
                objIData.AddParameter(P_Day, this.intDay);
                objIData.AddParameter(P_Date, this.dtmDate);
                objIData.AddParameter(P_Week, this.intWeek);
                objIData.AddParameter(P_TestSessionID, this.intTestSessionID);
                objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
                objIData.AddParameter(P_ClassID, this.strClassID);
                objIData.AddParameter(P_SubjectID, this.strSubjectID);
                objIData.AddParameter(P_YearID, this.intYearID);
                objIData.AddParameter(P_Semester, this.intSemester);
                objIData.AddParameter(P_TeacherID1, this.strTeacherID1);
                objIData.AddParameter(P_TeacherID2, this.strTeacherID2);
                objIData.AddParameter(P_TeacherID3, this.strTeacherID3);
                objIData.AddParameter(P_RoomID, this.strRoomID);
                objIData.AddParameter(P_RoomID2, this.strRoomID2);
                objIData.AddParameter(P_IsPractice, this.bolIsPractice);
                objIData.AddParameter(P_TestOrder, this.intTestOrder);
                objIData.AddParameter(P_ExamDateID, this.intExamDateID);
                objIData.AddParameter(P_IsLocked, this.bolIsLocked);
                objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
                objIData.AddParameter(P_StartAt, this.dtmStartAt);
                objIData.AddParameter(P_FinishAt, this.dtmFinishAt);
                objIData.AddParameter(P_MarkGroup, this.intMarkGroup);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_SignedData, this.strSignedData);
                objIData.AddParameter(P_SignedUser, this.strSignedUser);
                objIData.AddParameter(P_SignedDate, this.dtmSignedDate);
                objIData.AddParameter(P_IsMakeTestSchedule, this.bolIsMakeTestSchedule);
                objIData.AddParameter(P_IsAutoTest, this.bolIsAutoTest);
                objIData.AddParameter(P_IsActived, this.bolIsActived);
                objIData.AddParameter(P_MethodTestID, this.intMethodTestID);
                objIData.AddParameter(P_StudentCount, this.intStudentCount);
                objIData.AddParameter(P_ReviewTeacherID1, this.strReviewTeacherID1);
                objIData.AddParameter(P_ReviewTeacherID2, this.strReviewTeacherID2);
                objIData.AddParameter(P_ReviewTeacherID3, this.strReviewTeacherID3);
                objIData.AddParameter(P_ControlTeacherID, this.strControlTeacherID);
                objIData.AddParameter(P_NoteTeacherID, this.strNoteTeacherID);
                objIData.AddParameter(P_FollowTeacherID, this.strFollowTeacherID);
                this.lngScheduleID = Convert.ToInt64(objIData.ExecStoreToString());
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_TestSchedule", objEx);
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
        /// Update : SIM_TestSchedule
        /// Cập nhật dữ liệu
        /// Store: SIM_TestSchedule_EDIT 
        ///</summary>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_TestSchedule_EDIT");
                objIData.AddParameter(P_ScheduleID, this.lngScheduleID);
                objIData.AddParameter(P_Day, this.intDay);
                objIData.AddParameter(P_Date, this.dtmDate);
                objIData.AddParameter(P_Week, this.intWeek);
                objIData.AddParameter(P_TestSessionID, this.intTestSessionID);
                objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
                objIData.AddParameter(P_ClassID, this.strClassID);
                objIData.AddParameter(P_SubjectID, this.strSubjectID);
                objIData.AddParameter(P_YearID, this.intYearID);
                objIData.AddParameter(P_Semester, this.intSemester);
                objIData.AddParameter(P_TeacherID1, this.strTeacherID1);
                objIData.AddParameter(P_TeacherID2, this.strTeacherID2);
                objIData.AddParameter(P_TeacherID3, this.strTeacherID3);
                objIData.AddParameter(P_RoomID, this.strRoomID);
                objIData.AddParameter(P_RoomID2, this.strRoomID2);
                objIData.AddParameter(P_IsPractice, this.bolIsPractice);
                objIData.AddParameter(P_TestOrder, this.intTestOrder);
                objIData.AddParameter(P_ExamDateID, this.intExamDateID);
                objIData.AddParameter(P_IsLocked, this.bolIsLocked);
                objIData.AddParameter(P_StartAt, this.dtmStartAt);
                objIData.AddParameter(P_FinishAt, this.dtmFinishAt);
                objIData.AddParameter(P_MarkGroup, this.intMarkGroup);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_SignedData, this.strSignedData);
                objIData.AddParameter(P_SignedUser, this.strSignedUser);
                objIData.AddParameter(P_SignedDate, this.dtmSignedDate);
                objIData.AddParameter(P_IsMakeTestSchedule, this.bolIsMakeTestSchedule);
                objIData.AddParameter(P_IsAutoTest, this.bolIsAutoTest);
                objIData.AddParameter(P_IsActived, this.bolIsActived);
                objIData.AddParameter(P_MethodTestID, this.intMethodTestID);
                objIData.AddParameter(P_StudentCount, this.intStudentCount);
                objIData.AddParameter(P_ReviewTeacherID1, this.strReviewTeacherID1);
                objIData.AddParameter(P_ReviewTeacherID2, this.strReviewTeacherID2);
                objIData.AddParameter(P_ReviewTeacherID3, this.strReviewTeacherID3);
                objIData.AddParameter(P_ControlTeacherID, this.strControlTeacherID);
                objIData.AddParameter(P_NoteTeacherID, this.strNoteTeacherID);
                objIData.AddParameter(P_FollowTeacherID, this.strFollowTeacherID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_TestSchedule", objEx);
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
        /// Delete : SIM_TestSchedule
        /// Xóa dữ liệu
        /// Store: SIM_TestSchedule_DELETE 
        ///</summary>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_TestSchedule_DELETE");
                objIData.AddParameter(P_ScheduleID, this.lngScheduleID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_TestSchedule", objEx);
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
        /// Store: SIM_TestSchedule_DELETE 
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long? lngScheduleID)
        {
            this.lngScheduleID = lngScheduleID;
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

        public SIM_TestSchedule()
        {
        }
        public SIM_TestSchedule(long? lngScheduleID)
        {
            this.lngScheduleID = lngScheduleID;
            this.Get();
        }

        #endregion

        #region Variable Static

        #region Parameter Names

        public const String P_ScheduleID = "@" + C_ScheduleID;
        public const String P_Day = "@" + C_Day;
        public const String P_Date = "@" + C_Date;
        public const String P_Week = "@" + C_Week;
        public const String P_TestSessionID = "@" + C_TestSessionID;
        public const String P_ClassSubjectID = "@" + C_ClassSubjectID;
        public const String P_ClassID = "@" + C_ClassID;
        public const String P_SubjectID = "@" + C_SubjectID;
        public const String P_YearID = "@" + C_YearID;
        public const String P_Semester = "@" + C_Semester;
        public const String P_TeacherID1 = "@" + C_TeacherID1;
        public const String P_TeacherID2 = "@" + C_TeacherID2;
        public const String P_TeacherID3 = "@" + C_TeacherID3;
        public const String P_RoomID = "@" + C_RoomID;
        public const String P_RoomID2 = "@" + C_RoomID2;
        public const String P_IsPractice = "@" + C_IsPractice;
        public const String P_TestOrder = "@" + C_TestOrder;
        public const String P_ExamDateID = "@" + C_ExamDateID;
        public const String P_IsLocked = "@" + C_IsLocked;
        public const String P_CreatedUser = "@" + C_CreatedUser;
        public const String P_CreatedDate = "@" + C_CreatedDate;
        public const String P_StartAt = "@" + C_StartAt;
        public const String P_FinishAt = "@" + C_FinishAt;
        public const String P_MarkGroup = "@" + C_MarkGroup;
        public const String P_Description = "@" + C_Description;
        public const String P_SignedData = "@" + C_SignedData;
        public const String P_SignedUser = "@" + C_SignedUser;
        public const String P_SignedDate = "@" + C_SignedDate;
        public const String P_IsMakeTestSchedule = "@" + C_IsMakeTestSchedule;
        public const String P_IsAutoTest = "@" + C_IsAutoTest;
        public const String P_IsActived = "@" + C_IsActived;
        public const String P_MethodTestID = "@" + C_MethodTestID;
        public const String P_StudentCount = "@" + C_StudentCount;
        public const String P_ReviewTeacherID1 = "@" + C_ReviewTeacherID1;
        public const String P_ReviewTeacherID2 = "@" + C_ReviewTeacherID2;
        public const String P_ReviewTeacherID3 = "@" + C_ReviewTeacherID3;
        public const String P_ControlTeacherID = "@" + C_ControlTeacherID;
        public const String P_NoteTeacherID = "@" + C_NoteTeacherID;
        public const String P_FollowTeacherID = "@" + C_FollowTeacherID;

        #endregion //Parameter names

        #region Column Names

        public const String C_ScheduleID = "ScheduleID";
        public const String C_Day = "Day";
        public const String C_Date = "Date";
        public const String C_Week = "Week";
        public const String C_TestSessionID = "TestSessionID";
        public const String C_ClassSubjectID = "ClassSubjectID";
        public const String C_ClassID = "ClassID";
        public const String C_SubjectID = "SubjectID";
        public const String C_YearID = "YearID";
        public const String C_Semester = "Semester";
        public const String C_TeacherID1 = "TeacherID1";
        public const String C_TeacherID2 = "TeacherID2";
        public const String C_TeacherID3 = "TeacherID3";
        public const String C_RoomID = "RoomID";
        public const String C_RoomID2 = "RoomID2";
        public const String C_IsPractice = "IsPractice";
        public const String C_TestOrder = "TestOrder";
        public const String C_ExamDateID = "ExamDateID";
        public const String C_IsLocked = "IsLocked";
        public const String C_CreatedUser = "CreatedUser";
        public const String C_CreatedDate = "CreatedDate";
        public const String C_StartAt = "StartAt";
        public const String C_FinishAt = "FinishAt";
        public const String C_MarkGroup = "MarkGroup";
        public const String C_Description = "Description";
        public const String C_SignedData = "SignedData";
        public const String C_SignedUser = "SignedUser";
        public const String C_SignedDate = "SignedDate";
        public const String C_IsMakeTestSchedule = "IsMakeTestSchedule";
        public const String C_IsAutoTest = "IsAutoTest";
        public const String C_IsActived = "IsActived";
        public const String C_MethodTestID = "MethodTestID";
        public const String C_StudentCount = "StudentCount";
        public const String C_ReviewTeacherID1 = "ReviewTeacherID1";
        public const String C_ReviewTeacherID2 = "ReviewTeacherID2";
        public const String C_ReviewTeacherID3 = "ReviewTeacherID3";
        public const String C_ControlTeacherID = "ControlTeacherID";
        public const String C_NoteTeacherID = "NoteTeacherID";
        public const String C_FollowTeacherID = "FollowTeacherID";

        #endregion //Column names

        #endregion Variable Static
    }
}


