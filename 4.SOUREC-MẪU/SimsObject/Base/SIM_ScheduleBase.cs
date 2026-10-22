
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
    /// Created date 	: 12/1/2023 
    /// Description 
    /// </summary>	
    public partial class SIM_Schedule
    {
        #region Member Variables

        private long? lngScheduleID = null;
        private int? intDay = null;//Thứ tính từ 0-6
        private DateTime? dtmDate = null;//Ngày dạy
        private int? intWeek = null;//Tuần nào của niên học 1-50
        private int? intLessionTime = null;//Tiết học
        private long? lngClassSubjectID = null;
        private string strClassID = null;
        private string strSubjectID = null;
        private int? intYearID = null;
        private int? intSemester = null;
        private string strTeacherID = null;
        private string strRoomID = null;//Mã phòng
        private bool bolIsPractice = false;//Là môn thực hành
        private bool bolDone = false;//Đã dạy
        private int? intLearningSession = null;//Mã ca học (nếu có)
        private bool bolIsTemplate = false;//Là lịch mẫu tạo ra
        private int? intAddLession = null;//Tiết cộng thêm so với thời lượng, mục đích để kiểm tra trùng giờ
        private bool bolIsReplace = false;//Là lịch dạy bù
        private bool bolIsOff = false;//Là lịch Báo nghỉ (không chấm công)
        private string strScheduleContent = null;
        private string strDescription = null;
        private string strCreatedBy = null;
        private DateTime? dtmCreatedAt = null;//Ngày tạo
        private long? lngRequestScheduleID = null;//Mã đăng ký đổi lịch (IsReplace thì là lịch mới, IsOff thì lịch cũ bị đổi)
        private bool bolIsFinish = false;//Ngày kết thúc (cũng là ngày thi)
        private int? intQuantity = null;//Tổng tiết trong buổi
        private int? intDoneQuantity = null;//Tổng tiết đã dạy
        private int? intSumQuantity = null;//Tổng tiết cộng dồn tính đến buổi
        private int? intScheduleIndex = null;//Thứ tự của buổi
        private int? intCSTotalQuantity = null;//Tổng tiết theo môn học lớp
        private int? intScheduleTotalQuantity = null;//Tổng tiết theo lịch
        private string strIndexInfo = null;
        private bool bolIsVir = false;//Đánh dấu tiết ảo
        private string strVirList = null;//Ds tiết ảo (dùng cho nguyên ô lịch get,set lúc edit ô lịch)
        private int? intVirQuantity = null;//Tổng tiết ảo của ô lịch (khi view trên web là phải trừ số lượng này mới đúng)
        private long? lngSubjectPlanID = null;//Mã kế hoạch (mục nội dung dạy). Dùng cho lái xe (lấy từ SIM_SubjectPlan)
        private DateTime? dtmStartTime = null;//Giờ bắt đầu của ô lịch (luôn lưu dù có hay ko chọn LearningSession --> tính nhanh và ko bị ảnh ảnh hưởng khi sửa ca)
        private DateTime? dtmFinishTime = null;//Giờ kết thúc của ô lịch (luôn lưu dù có hay ko chọn LearningSession --> tính nhanh và ko bị ảnh ảnh hưởng khi sửa ca)
        private decimal? decTimeLen = null;//Tổng thời lượng ca học của ô lịch (theo đơn vị giờ nếu có nhập từ giờ đến giờ)
        private string strTimeLenText = null;//Thời lượng dạng text (đổi từ TimeLen sang dạng hh:mm)
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// ScheduleID
        /// 
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
        /// Ngày dạy
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
        /// LessionTime
        /// Tiết học
        /// </summary>
        public int? LessionTime
        {
            get { return intLessionTime; }
            set { intLessionTime = value; }
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
        /// Done
        /// Đã dạy
        /// </summary>
        public bool Done
        {
            get { return bolDone; }
            set { bolDone = value; }
        }
        /// <summary>
        /// LearningSession
        /// Mã ca học (nếu có)
        /// </summary>
        public int? LearningSession
        {
            get { return intLearningSession; }
            set { intLearningSession = value; }
        }
        /// <summary>
        /// IsTemplate
        /// Là lịch mẫu tạo ra
        /// </summary>
        public bool IsTemplate
        {
            get { return bolIsTemplate; }
            set { bolIsTemplate = value; }
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
        /// IsReplace
        /// Là lịch dạy bù
        /// </summary>
        public bool IsReplace
        {
            get { return bolIsReplace; }
            set { bolIsReplace = value; }
        }
        /// <summary>
        /// IsOff
        /// Là lịch Báo nghỉ (không chấm công)
        /// </summary>
        public bool IsOff
        {
            get { return bolIsOff; }
            set { bolIsOff = value; }
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
        /// CreatedBy
        /// 
        /// </summary>
        public string CreatedBy
        {
            get { return strCreatedBy; }
            set { strCreatedBy = value; }
        }
        /// <summary>
        /// CreatedAt
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedAt
        {
            get { return dtmCreatedAt; }
            set { dtmCreatedAt = value; }
        }
        /// <summary>
        /// RequestScheduleID
        /// Mã đăng ký đổi lịch (IsReplace thì là lịch mới, IsOff thì lịch cũ bị đổi)
        /// </summary>
        public long? RequestScheduleID
        {
            get { return lngRequestScheduleID; }
            set { lngRequestScheduleID = value; }
        }
        /// <summary>
        /// IsFinish
        /// Ngày kết thúc (cũng là ngày thi)
        /// </summary>
        public bool IsFinish
        {
            get { return bolIsFinish; }
            set { bolIsFinish = value; }
        }
        /// <summary>
        /// Quantity
        /// Tổng tiết trong buổi
        /// </summary>
        public int? Quantity
        {
            get { return intQuantity; }
            set { intQuantity = value; }
        }
        /// <summary>
        /// DoneQuantity
        /// Tổng tiết đã dạy
        /// </summary>
        public int? DoneQuantity
        {
            get { return intDoneQuantity; }
            set { intDoneQuantity = value; }
        }
        /// <summary>
        /// SumQuantity
        /// Tổng tiết cộng dồn tính đến buổi
        /// </summary>
        public int? SumQuantity
        {
            get { return intSumQuantity; }
            set { intSumQuantity = value; }
        }
        /// <summary>
        /// ScheduleIndex
        /// Thứ tự của buổi
        /// </summary>
        public int? ScheduleIndex
        {
            get { return intScheduleIndex; }
            set { intScheduleIndex = value; }
        }
        /// <summary>
        /// CSTotalQuantity
        /// Tổng tiết theo môn học lớp
        /// </summary>
        public int? CSTotalQuantity
        {
            get { return intCSTotalQuantity; }
            set { intCSTotalQuantity = value; }
        }
        /// <summary>
        /// ScheduleTotalQuantity
        /// Tổng tiết theo lịch
        /// </summary>
        public int? ScheduleTotalQuantity
        {
            get { return intScheduleTotalQuantity; }
            set { intScheduleTotalQuantity = value; }
        }
        /// <summary>
        /// IndexInfo
        /// 
        /// </summary>
        public string IndexInfo
        {
            get { return strIndexInfo; }
            set { strIndexInfo = value; }
        }
        /// <summary>
        /// IsVir
        /// Đánh dấu tiết ảo
        /// </summary>
        public bool IsVir
        {
            get { return bolIsVir; }
            set { bolIsVir = value; }
        }
        /// <summary>
        /// VirList
        /// Ds tiết ảo (dùng cho nguyên ô lịch get,set lúc edit ô lịch)
        /// </summary>
        public string VirList
        {
            get { return strVirList; }
            set { strVirList = value; }
        }
        /// <summary>
        /// VirQuantity
        /// Tổng tiết ảo của ô lịch (khi view trên web là phải trừ số lượng này mới đúng)
        /// </summary>
        public int? VirQuantity
        {
            get { return intVirQuantity; }
            set { intVirQuantity = value; }
        }
        /// <summary>
        /// SubjectPlanID
        /// Mã kế hoạch (mục nội dung dạy). Dùng cho lái xe (lấy từ SIM_SubjectPlan)
        /// </summary>
        public long? SubjectPlanID
        {
            get { return lngSubjectPlanID; }
            set { lngSubjectPlanID = value; }
        }
        /// <summary>
        /// StartTime
        /// Giờ bắt đầu của ô lịch (luôn lưu dù có hay ko chọn LearningSession --> tính nhanh và ko bị ảnh ảnh hưởng khi sửa ca)
        /// </summary>
        public DateTime? StartTime
        {
            get { return dtmStartTime; }
            set { dtmStartTime = value; }
        }
        /// <summary>
        /// FinishTime
        /// Giờ kết thúc của ô lịch (luôn lưu dù có hay ko chọn LearningSession --> tính nhanh và ko bị ảnh ảnh hưởng khi sửa ca)
        /// </summary>
        public DateTime? FinishTime
        {
            get { return dtmFinishTime; }
            set { dtmFinishTime = value; }
        }
        /// <summary>
        /// TimeLen
        /// Tổng thời lượng ca học của ô lịch (theo đơn vị giờ nếu có nhập từ giờ đến giờ)
        /// </summary>
        public decimal? TimeLen
        {
            get { return decTimeLen; }
            set { decTimeLen = value; }
        }
        /// <summary>
        /// TimeLenText
        /// Thời lượng dạng text (đổi từ TimeLen sang dạng hh:mm)
        /// </summary>
        public string TimeLenText
        {
            get { return strTimeLenText; }
            set { strTimeLenText = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_LessionTime.ToUpper()) && !Convert.IsDBNull(reader[C_LessionTime])) this.intLessionTime = Convert.ToInt32(reader[C_LessionTime]);
                    if (reader.GetName(i).ToUpper().Equals(C_ClassSubjectID.ToUpper()) && !Convert.IsDBNull(reader[C_ClassSubjectID])) this.lngClassSubjectID = Convert.ToInt64(reader[C_ClassSubjectID]);
                    if (reader.GetName(i).ToUpper().Equals(C_ClassID.ToUpper()) && !Convert.IsDBNull(reader[C_ClassID])) this.strClassID = Convert.ToString(reader[C_ClassID]);
                    if (reader.GetName(i).ToUpper().Equals(C_SubjectID.ToUpper()) && !Convert.IsDBNull(reader[C_SubjectID])) this.strSubjectID = Convert.ToString(reader[C_SubjectID]);
                    if (reader.GetName(i).ToUpper().Equals(C_YearID.ToUpper()) && !Convert.IsDBNull(reader[C_YearID])) this.intYearID = Convert.ToInt32(reader[C_YearID]);
                    if (reader.GetName(i).ToUpper().Equals(C_Semester.ToUpper()) && !Convert.IsDBNull(reader[C_Semester])) this.intSemester = Convert.ToInt32(reader[C_Semester]);
                    if (reader.GetName(i).ToUpper().Equals(C_TeacherID.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherID])) this.strTeacherID = Convert.ToString(reader[C_TeacherID]);
                    if (reader.GetName(i).ToUpper().Equals(C_RoomID.ToUpper()) && !Convert.IsDBNull(reader[C_RoomID])) this.strRoomID = Convert.ToString(reader[C_RoomID]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsPractice.ToUpper()) && !Convert.IsDBNull(reader[C_IsPractice])) this.bolIsPractice = Convert.ToBoolean(reader[C_IsPractice]);
                    if (reader.GetName(i).ToUpper().Equals(C_Done.ToUpper()) && !Convert.IsDBNull(reader[C_Done])) this.bolDone = Convert.ToBoolean(reader[C_Done]);
                    if (reader.GetName(i).ToUpper().Equals(C_LearningSession.ToUpper()) && !Convert.IsDBNull(reader[C_LearningSession])) this.intLearningSession = Convert.ToInt32(reader[C_LearningSession]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsTemplate.ToUpper()) && !Convert.IsDBNull(reader[C_IsTemplate])) this.bolIsTemplate = Convert.ToBoolean(reader[C_IsTemplate]);
                    if (reader.GetName(i).ToUpper().Equals(C_AddLession.ToUpper()) && !Convert.IsDBNull(reader[C_AddLession])) this.intAddLession = Convert.ToInt32(reader[C_AddLession]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsReplace.ToUpper()) && !Convert.IsDBNull(reader[C_IsReplace])) this.bolIsReplace = Convert.ToBoolean(reader[C_IsReplace]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsOff.ToUpper()) && !Convert.IsDBNull(reader[C_IsOff])) this.bolIsOff = Convert.ToBoolean(reader[C_IsOff]);
                    if (reader.GetName(i).ToUpper().Equals(C_ScheduleContent.ToUpper()) && !Convert.IsDBNull(reader[C_ScheduleContent])) this.strScheduleContent = Convert.ToString(reader[C_ScheduleContent]);
                    if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedBy.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedBy])) this.strCreatedBy = Convert.ToString(reader[C_CreatedBy]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(reader[C_CreatedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_RequestScheduleID.ToUpper()) && !Convert.IsDBNull(reader[C_RequestScheduleID])) this.lngRequestScheduleID = Convert.ToInt64(reader[C_RequestScheduleID]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsFinish.ToUpper()) && !Convert.IsDBNull(reader[C_IsFinish])) this.bolIsFinish = Convert.ToBoolean(reader[C_IsFinish]);
                    if (reader.GetName(i).ToUpper().Equals(C_Quantity.ToUpper()) && !Convert.IsDBNull(reader[C_Quantity])) this.intQuantity = Convert.ToInt32(reader[C_Quantity]);
                    if (reader.GetName(i).ToUpper().Equals(C_DoneQuantity.ToUpper()) && !Convert.IsDBNull(reader[C_DoneQuantity])) this.intDoneQuantity = Convert.ToInt32(reader[C_DoneQuantity]);
                    if (reader.GetName(i).ToUpper().Equals(C_SumQuantity.ToUpper()) && !Convert.IsDBNull(reader[C_SumQuantity])) this.intSumQuantity = Convert.ToInt32(reader[C_SumQuantity]);
                    if (reader.GetName(i).ToUpper().Equals(C_ScheduleIndex.ToUpper()) && !Convert.IsDBNull(reader[C_ScheduleIndex])) this.intScheduleIndex = Convert.ToInt32(reader[C_ScheduleIndex]);
                    if (reader.GetName(i).ToUpper().Equals(C_CSTotalQuantity.ToUpper()) && !Convert.IsDBNull(reader[C_CSTotalQuantity])) this.intCSTotalQuantity = Convert.ToInt32(reader[C_CSTotalQuantity]);
                    if (reader.GetName(i).ToUpper().Equals(C_ScheduleTotalQuantity.ToUpper()) && !Convert.IsDBNull(reader[C_ScheduleTotalQuantity])) this.intScheduleTotalQuantity = Convert.ToInt32(reader[C_ScheduleTotalQuantity]);
                    if (reader.GetName(i).ToUpper().Equals(C_IndexInfo.ToUpper()) && !Convert.IsDBNull(reader[C_IndexInfo])) this.strIndexInfo = Convert.ToString(reader[C_IndexInfo]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsVir.ToUpper()) && !Convert.IsDBNull(reader[C_IsVir])) this.bolIsVir = Convert.ToBoolean(reader[C_IsVir]);
                    if (reader.GetName(i).ToUpper().Equals(C_VirList.ToUpper()) && !Convert.IsDBNull(reader[C_VirList])) this.strVirList = Convert.ToString(reader[C_VirList]);
                    if (reader.GetName(i).ToUpper().Equals(C_VirQuantity.ToUpper()) && !Convert.IsDBNull(reader[C_VirQuantity])) this.intVirQuantity = Convert.ToInt32(reader[C_VirQuantity]);
                    if (reader.GetName(i).ToUpper().Equals(C_SubjectPlanID.ToUpper()) && !Convert.IsDBNull(reader[C_SubjectPlanID])) this.lngSubjectPlanID = Convert.ToInt64(reader[C_SubjectPlanID]);
                    if (reader.GetName(i).ToUpper().Equals(C_StartTime.ToUpper()) && !Convert.IsDBNull(reader[C_StartTime])) this.dtmStartTime = Convert.ToDateTime(reader[C_StartTime]);
                    if (reader.GetName(i).ToUpper().Equals(C_FinishTime.ToUpper()) && !Convert.IsDBNull(reader[C_FinishTime])) this.dtmFinishTime = Convert.ToDateTime(reader[C_FinishTime]);
                    if (reader.GetName(i).ToUpper().Equals(C_TimeLen.ToUpper()) && !Convert.IsDBNull(reader[C_TimeLen])) this.decTimeLen = Convert.ToDecimal(reader[C_TimeLen]);
                    if (reader.GetName(i).ToUpper().Equals(C_TimeLenText.ToUpper()) && !Convert.IsDBNull(reader[C_TimeLenText])) this.strTimeLenText = Convert.ToString(reader[C_TimeLenText]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_Schedule", objEx);
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
                if (!Convert.IsDBNull(drw[C_LessionTime])) this.intLessionTime = Convert.ToInt32(drw[C_LessionTime]);
                if (!Convert.IsDBNull(drw[C_ClassSubjectID])) this.lngClassSubjectID = Convert.ToInt64(drw[C_ClassSubjectID]);
                if (!Convert.IsDBNull(drw[C_ClassID])) this.strClassID = Convert.ToString(drw[C_ClassID]);
                if (!Convert.IsDBNull(drw[C_SubjectID])) this.strSubjectID = Convert.ToString(drw[C_SubjectID]);
                if (!Convert.IsDBNull(drw[C_YearID])) this.intYearID = Convert.ToInt32(drw[C_YearID]);
                if (!Convert.IsDBNull(drw[C_Semester])) this.intSemester = Convert.ToInt32(drw[C_Semester]);
                if (!Convert.IsDBNull(drw[C_TeacherID])) this.strTeacherID = Convert.ToString(drw[C_TeacherID]);
                if (!Convert.IsDBNull(drw[C_RoomID])) this.strRoomID = Convert.ToString(drw[C_RoomID]);
                if (!Convert.IsDBNull(drw[C_IsPractice])) this.bolIsPractice = Convert.ToBoolean(drw[C_IsPractice]);
                if (!Convert.IsDBNull(drw[C_Done])) this.bolDone = Convert.ToBoolean(drw[C_Done]);
                if (!Convert.IsDBNull(drw[C_LearningSession])) this.intLearningSession = Convert.ToInt32(drw[C_LearningSession]);
                if (!Convert.IsDBNull(drw[C_IsTemplate])) this.bolIsTemplate = Convert.ToBoolean(drw[C_IsTemplate]);
                if (!Convert.IsDBNull(drw[C_AddLession])) this.intAddLession = Convert.ToInt32(drw[C_AddLession]);
                if (!Convert.IsDBNull(drw[C_IsReplace])) this.bolIsReplace = Convert.ToBoolean(drw[C_IsReplace]);
                if (!Convert.IsDBNull(drw[C_IsOff])) this.bolIsOff = Convert.ToBoolean(drw[C_IsOff]);
                if (!Convert.IsDBNull(drw[C_ScheduleContent])) this.strScheduleContent = Convert.ToString(drw[C_ScheduleContent]);
                if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
                if (!Convert.IsDBNull(drw[C_CreatedBy])) this.strCreatedBy = Convert.ToString(drw[C_CreatedBy]);
                if (!Convert.IsDBNull(drw[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(drw[C_CreatedAt]);
                if (!Convert.IsDBNull(drw[C_RequestScheduleID])) this.lngRequestScheduleID = Convert.ToInt64(drw[C_RequestScheduleID]);
                if (!Convert.IsDBNull(drw[C_IsFinish])) this.bolIsFinish = Convert.ToBoolean(drw[C_IsFinish]);
                if (!Convert.IsDBNull(drw[C_Quantity])) this.intQuantity = Convert.ToInt32(drw[C_Quantity]);
                if (!Convert.IsDBNull(drw[C_DoneQuantity])) this.intDoneQuantity = Convert.ToInt32(drw[C_DoneQuantity]);
                if (!Convert.IsDBNull(drw[C_SumQuantity])) this.intSumQuantity = Convert.ToInt32(drw[C_SumQuantity]);
                if (!Convert.IsDBNull(drw[C_ScheduleIndex])) this.intScheduleIndex = Convert.ToInt32(drw[C_ScheduleIndex]);
                if (!Convert.IsDBNull(drw[C_CSTotalQuantity])) this.intCSTotalQuantity = Convert.ToInt32(drw[C_CSTotalQuantity]);
                if (!Convert.IsDBNull(drw[C_ScheduleTotalQuantity])) this.intScheduleTotalQuantity = Convert.ToInt32(drw[C_ScheduleTotalQuantity]);
                if (!Convert.IsDBNull(drw[C_IndexInfo])) this.strIndexInfo = Convert.ToString(drw[C_IndexInfo]);
                if (!Convert.IsDBNull(drw[C_IsVir])) this.bolIsVir = Convert.ToBoolean(drw[C_IsVir]);
                if (!Convert.IsDBNull(drw[C_VirList])) this.strVirList = Convert.ToString(drw[C_VirList]);
                if (!Convert.IsDBNull(drw[C_VirQuantity])) this.intVirQuantity = Convert.ToInt32(drw[C_VirQuantity]);
                if (!Convert.IsDBNull(drw[C_SubjectPlanID])) this.lngSubjectPlanID = Convert.ToInt64(drw[C_SubjectPlanID]);
                if (!Convert.IsDBNull(drw[C_StartTime])) this.dtmStartTime = Convert.ToDateTime(drw[C_StartTime]);
                if (!Convert.IsDBNull(drw[C_FinishTime])) this.dtmFinishTime = Convert.ToDateTime(drw[C_FinishTime]);
                if (!Convert.IsDBNull(drw[C_TimeLen])) this.decTimeLen = Convert.ToDecimal(drw[C_TimeLen]);
                if (!Convert.IsDBNull(drw[C_TimeLenText])) this.strTimeLenText = Convert.ToString(drw[C_TimeLenText]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_Schedule", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        /// Nạp thông tin item 
        /// Store: SIM_Schedule_GET 
        ///</summary>
        /// <returns>true ? Có : False ? Không</returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Schedule_GET");
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_Schedule", objEx);
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
        /// Store: SIM_Schedule_GET 
        ///</summary>
        /// <returns> SIM_Schedule </returns>
        public SIM_Schedule Get(long? lngScheduleID)
        {
            SIM_Schedule obj = new SIM_Schedule();
            if (objIData != null)
                obj.IDB = objIData;
            obj.ScheduleID = lngScheduleID;
            if (obj.Get())
                return obj;
            this.objErrorException = obj.ErrorException;
            return null;
        }
        ///<summary>
        /// ExecNonQuery : SIM_Schedule
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Schedule", objEx);
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
        /// Search : SIM_Schedule
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Schedule", objEx);
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
        /// Search : SIM_Schedule
        /// Lấy hết dữ liệu
        /// Store: SIM_Schedule_GETALL 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable GetAll()
        {
            return GetDataTable("SIM_Schedule_GETALL");
        }

        ///<summary>
        /// Search : SIM_Schedule
        /// Tìm dữ liệu
        /// Store: SIM_Schedule_SEARCH 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable Search(params object[] pars)
        {
            return GetDataTable("SIM_Schedule_SEARCH", pars);
        }

        ///<summary>
        /// Add : SIM_Schedule
        /// Thêm dữ liệu
        /// Store: SIM_Schedule_ADD 
        ///</summary>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Schedule_ADD");
                objIData.AddParameter(P_Day, this.intDay);
                objIData.AddParameter(P_Date, this.dtmDate);
                objIData.AddParameter(P_Week, this.intWeek);
                objIData.AddParameter(P_LessionTime, this.intLessionTime);
                objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
                objIData.AddParameter(P_ClassID, this.strClassID);
                objIData.AddParameter(P_SubjectID, this.strSubjectID);
                objIData.AddParameter(P_YearID, this.intYearID);
                objIData.AddParameter(P_Semester, this.intSemester);
                objIData.AddParameter(P_TeacherID, this.strTeacherID);
                objIData.AddParameter(P_RoomID, this.strRoomID);
                objIData.AddParameter(P_IsPractice, this.bolIsPractice);
                objIData.AddParameter(P_Done, this.bolDone);
                objIData.AddParameter(P_LearningSession, this.intLearningSession);
                objIData.AddParameter(P_IsTemplate, this.bolIsTemplate);
                objIData.AddParameter(P_AddLession, this.intAddLession);
                objIData.AddParameter(P_IsReplace, this.bolIsReplace);
                objIData.AddParameter(P_IsOff, this.bolIsOff);
                objIData.AddParameter(P_ScheduleContent, this.strScheduleContent);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_CreatedBy, this.strCreatedBy);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_RequestScheduleID, this.lngRequestScheduleID);
                objIData.AddParameter(P_IsFinish, this.bolIsFinish);
                objIData.AddParameter(P_Quantity, this.intQuantity);
                objIData.AddParameter(P_DoneQuantity, this.intDoneQuantity);
                objIData.AddParameter(P_SumQuantity, this.intSumQuantity);
                objIData.AddParameter(P_ScheduleIndex, this.intScheduleIndex);
                objIData.AddParameter(P_CSTotalQuantity, this.intCSTotalQuantity);
                objIData.AddParameter(P_ScheduleTotalQuantity, this.intScheduleTotalQuantity);
                objIData.AddParameter(P_IndexInfo, this.strIndexInfo);
                objIData.AddParameter(P_IsVir, this.bolIsVir);
                objIData.AddParameter(P_VirList, this.strVirList);
                objIData.AddParameter(P_VirQuantity, this.intVirQuantity);
                objIData.AddParameter(P_SubjectPlanID, this.lngSubjectPlanID);
                objIData.AddParameter(P_StartTime, this.dtmStartTime);
                objIData.AddParameter(P_FinishTime, this.dtmFinishTime);
                objIData.AddParameter(P_TimeLen, this.decTimeLen);
                objIData.AddParameter(P_TimeLenText, this.strTimeLenText);
                this.lngScheduleID = Convert.ToInt32(objIData.ExecStoreToString());
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_Schedule", objEx);
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
        /// Update : SIM_Schedule
        /// Cập nhật dữ liệu
        /// Store: SIM_Schedule_EDIT 
        ///</summary>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Schedule_EDIT");
                objIData.AddParameter(P_ScheduleID, this.lngScheduleID);
                objIData.AddParameter(P_Day, this.intDay);
                objIData.AddParameter(P_Date, this.dtmDate);
                objIData.AddParameter(P_Week, this.intWeek);
                objIData.AddParameter(P_LessionTime, this.intLessionTime);
                objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
                objIData.AddParameter(P_ClassID, this.strClassID);
                objIData.AddParameter(P_SubjectID, this.strSubjectID);
                objIData.AddParameter(P_YearID, this.intYearID);
                objIData.AddParameter(P_Semester, this.intSemester);
                objIData.AddParameter(P_TeacherID, this.strTeacherID);
                objIData.AddParameter(P_RoomID, this.strRoomID);
                objIData.AddParameter(P_IsPractice, this.bolIsPractice);
                objIData.AddParameter(P_Done, this.bolDone);
                objIData.AddParameter(P_LearningSession, this.intLearningSession);
                objIData.AddParameter(P_IsTemplate, this.bolIsTemplate);
                objIData.AddParameter(P_AddLession, this.intAddLession);
                objIData.AddParameter(P_IsReplace, this.bolIsReplace);
                objIData.AddParameter(P_IsOff, this.bolIsOff);
                objIData.AddParameter(P_ScheduleContent, this.strScheduleContent);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_CreatedBy, this.strCreatedBy);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_RequestScheduleID, this.lngRequestScheduleID);
                objIData.AddParameter(P_IsFinish, this.bolIsFinish);
                objIData.AddParameter(P_Quantity, this.intQuantity);
                objIData.AddParameter(P_DoneQuantity, this.intDoneQuantity);
                objIData.AddParameter(P_SumQuantity, this.intSumQuantity);
                objIData.AddParameter(P_ScheduleIndex, this.intScheduleIndex);
                objIData.AddParameter(P_CSTotalQuantity, this.intCSTotalQuantity);
                objIData.AddParameter(P_ScheduleTotalQuantity, this.intScheduleTotalQuantity);
                objIData.AddParameter(P_IndexInfo, this.strIndexInfo);
                objIData.AddParameter(P_IsVir, this.bolIsVir);
                objIData.AddParameter(P_VirList, this.strVirList);
                objIData.AddParameter(P_VirQuantity, this.intVirQuantity);
                objIData.AddParameter(P_SubjectPlanID, this.lngSubjectPlanID);
                objIData.AddParameter(P_StartTime, this.dtmStartTime);
                objIData.AddParameter(P_FinishTime, this.dtmFinishTime);
                objIData.AddParameter(P_TimeLen, this.decTimeLen);
                objIData.AddParameter(P_TimeLenText, this.strTimeLenText);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_Schedule", objEx);
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
        /// Delete : SIM_Schedule
        /// Xóa dữ liệu
        /// Store: SIM_Schedule_DELETE 
        ///</summary>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Schedule_DELETE");
                objIData.AddParameter(P_ScheduleID, this.lngScheduleID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_Schedule", objEx);
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
        /// Store: SIM_Schedule_DELETE 
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

        public SIM_Schedule()
        {
        }
        public SIM_Schedule(long? lngScheduleID)
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
        public const String P_LessionTime = "@" + C_LessionTime;
        public const String P_ClassSubjectID = "@" + C_ClassSubjectID;
        public const String P_ClassID = "@" + C_ClassID;
        public const String P_SubjectID = "@" + C_SubjectID;
        public const String P_YearID = "@" + C_YearID;
        public const String P_Semester = "@" + C_Semester;
        public const String P_TeacherID = "@" + C_TeacherID;
        public const String P_RoomID = "@" + C_RoomID;
        public const String P_IsPractice = "@" + C_IsPractice;
        public const String P_Done = "@" + C_Done;
        public const String P_LearningSession = "@" + C_LearningSession;
        public const String P_IsTemplate = "@" + C_IsTemplate;
        public const String P_AddLession = "@" + C_AddLession;
        public const String P_IsReplace = "@" + C_IsReplace;
        public const String P_IsOff = "@" + C_IsOff;
        public const String P_ScheduleContent = "@" + C_ScheduleContent;
        public const String P_Description = "@" + C_Description;
        public const String P_CreatedBy = "@" + C_CreatedBy;
        public const String P_CreatedAt = "@" + C_CreatedAt;
        public const String P_RequestScheduleID = "@" + C_RequestScheduleID;
        public const String P_IsFinish = "@" + C_IsFinish;
        public const String P_Quantity = "@" + C_Quantity;
        public const String P_DoneQuantity = "@" + C_DoneQuantity;
        public const String P_SumQuantity = "@" + C_SumQuantity;
        public const String P_ScheduleIndex = "@" + C_ScheduleIndex;
        public const String P_CSTotalQuantity = "@" + C_CSTotalQuantity;
        public const String P_ScheduleTotalQuantity = "@" + C_ScheduleTotalQuantity;
        public const String P_IndexInfo = "@" + C_IndexInfo;
        public const String P_IsVir = "@" + C_IsVir;
        public const String P_VirList = "@" + C_VirList;
        public const String P_VirQuantity = "@" + C_VirQuantity;
        public const String P_SubjectPlanID = "@" + C_SubjectPlanID;
        public const String P_StartTime = "@" + C_StartTime;
        public const String P_FinishTime = "@" + C_FinishTime;
        public const String P_TimeLen = "@" + C_TimeLen;
        public const String P_TimeLenText = "@" + C_TimeLenText;

        #endregion //Parameter names

        #region Column Names

        public const String C_ScheduleID = "ScheduleID";
        public const String C_Day = "Day";
        public const String C_Date = "Date";
        public const String C_Week = "Week";
        public const String C_LessionTime = "LessionTime";
        public const String C_ClassSubjectID = "ClassSubjectID";
        public const String C_ClassID = "ClassID";
        public const String C_SubjectID = "SubjectID";
        public const String C_YearID = "YearID";
        public const String C_Semester = "Semester";
        public const String C_TeacherID = "TeacherID";
        public const String C_RoomID = "RoomID";
        public const String C_IsPractice = "IsPractice";
        public const String C_Done = "Done";
        public const String C_LearningSession = "LearningSession";
        public const String C_IsTemplate = "IsTemplate";
        public const String C_AddLession = "AddLession";
        public const String C_IsReplace = "IsReplace";
        public const String C_IsOff = "IsOff";
        public const String C_ScheduleContent = "ScheduleContent";
        public const String C_Description = "Description";
        public const String C_CreatedBy = "CreatedBy";
        public const String C_CreatedAt = "CreatedAt";
        public const String C_RequestScheduleID = "RequestScheduleID";
        public const String C_IsFinish = "IsFinish";
        public const String C_Quantity = "Quantity";
        public const String C_DoneQuantity = "DoneQuantity";
        public const String C_SumQuantity = "SumQuantity";
        public const String C_ScheduleIndex = "ScheduleIndex";
        public const String C_CSTotalQuantity = "CSTotalQuantity";
        public const String C_ScheduleTotalQuantity = "ScheduleTotalQuantity";
        public const String C_IndexInfo = "IndexInfo";
        public const String C_IsVir = "IsVir";
        public const String C_VirList = "VirList";
        public const String C_VirQuantity = "VirQuantity";
        public const String C_SubjectPlanID = "SubjectPlanID";
        public const String C_StartTime = "StartTime";
        public const String C_FinishTime = "FinishTime";
        public const String C_TimeLen = "TimeLen";
        public const String C_TimeLenText = "TimeLenText";

        #endregion //Column names

        #endregion Variable Static
    }
}


