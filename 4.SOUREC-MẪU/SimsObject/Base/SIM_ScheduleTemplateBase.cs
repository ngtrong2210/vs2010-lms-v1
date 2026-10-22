
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
    /// Created date 	: 05/07/2024 
    /// Description 
    /// </summary>	
    public partial class SIM_ScheduleTemplate
    {
        #region Member Variables

        private int? intScheduleTemplateID = null;
        private string strDays = null;//Thứ tính từ 0-6
        private int? intFromWeek = null;//Từ tuần
        private int? intToWeek = null;//Đến tuần
        private int? intFromLessionTime = null;//Từ tiết học nào
        private int? intLenTime = null;//Đến tiết học nào
        private long? lngClassSubjectID = null;
        private string strClassID = null;
        private string strSubjectID = null;
        private int? intYearID = null;
        private int? intSemester = null;
        private string strTeacherID = null;
        private string strRoomID = null;
        private bool bolIsPractice = false;//Là môn thực hành
        private int? intAddLession = null;//Tiết cộng thêm so với thời lượng, mục đích để kiểm tra trùng giờ
        private int? intLearningSession = null;
        private string strScheduleContent = null;
        private string strDescription = null;
        private long? lngSubjectPlanID = null;//Mã kế hoạch (mục nội dung dạy). Dùng cho lái xe (lấy từ SIM_SubjectPlan)
        private DateTime? dtmStartTime = null;//Giờ bắt đầu của ô lịch (luôn lưu dù có hay ko chọn LearningSession --> tính nhanh và ko bị ảnh ảnh hưởng khi sửa ca)
        private DateTime? dtmFinishTime = null;//Giờ kết thúc của ô lịch (luôn lưu dù có hay ko chọn LearningSession --> tính nhanh và ko bị ảnh ảnh hưởng khi sửa ca)
        private decimal? decTimeLen = null;//Tổng thời lượng ca học của ô lịch (theo đơn vị giờ nếu có nhập từ giờ đến giờ)
        private string strTimeLenText = null;//Thời lượng dạng text (đổi từ TimeLen sang dạng hh:mm)
        private DateTime? dtmStartDate = null;//Ngày bắt đầu (nếu có thì tuần bắt đầu sẽ ko còn ý nghĩa nhiều)
        private DateTime? dtmFinishDate = null;//Ngày kết thúc (nếu có thì tuần kết thúc ko còn ý nghĩa nhiều)
        private int? intLearningSession2 = null;//Ca học thứ 2 trong cùng dòng này
        private int? intFromLessionTime2 = null;//Từ tiết học nào (2)
        private int? intLenTime2 = null;//Đến tiết học nào  (2)
        private DateTime? dtmStartTime2 = null;//Giờ bắt đầu của ô lịch (luôn lưu dù có hay ko chọn LearningSession --> tính nhanh và ko bị ảnh ảnh hưởng khi sửa ca)
        private DateTime? dtmFinishTime2 = null;//Giờ kết thúc của ô lịch (luôn lưu dù có hay ko chọn LearningSession --> tính nhanh và ko bị ảnh ảnh hưởng khi sửa ca)
        private decimal? decTimeLen2 = null;//Tổng thời lượng ca học của ô lịch (theo đơn vị giờ nếu có nhập từ giờ đến giờ)
        private string strTimeLenText2 = null;//Thời lượng dạng text (đổi từ TimeLen sang dạng hh:mm)
        private int? intLearningSession3 = null;//Ca học thứ 3 trong cùng dòng này
        private int? intFromLessionTime3 = null;//Từ tiết học nào (3)
        private int? intLenTime3 = null;//Đến tiết học nào  (3)
        private DateTime? dtmStartTime3 = null;//Giờ bắt đầu của ô lịch (luôn lưu dù có hay ko chọn LearningSession --> tính nhanh và ko bị ảnh ảnh hưởng khi sửa ca)
        private DateTime? dtmFinishTime3 = null;//Giờ kết thúc của ô lịch (luôn lưu dù có hay ko chọn LearningSession --> tính nhanh và ko bị ảnh ảnh hưởng khi sửa ca)
        private decimal? decTimeLen3 = null;//Tổng thời lượng ca học của ô lịch (theo đơn vị giờ nếu có nhập từ giờ đến giờ)
        private string strTimeLenText3 = null;//Thời lượng dạng text (đổi từ TimeLen sang dạng hh:mm)
        private decimal? decTimeLenQuantity = null;//Số giờ cần sắp theo đv giờ trong kế hoạch
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// ScheduleTemplateID
        /// 
        /// </summary>
        public int? ScheduleTemplateID
        {
            get { return intScheduleTemplateID; }
            set { intScheduleTemplateID = value; }
        }
        /// <summary>
        /// Days
        /// Thứ tính từ 0-6
        /// </summary>
        public string Days
        {
            get { return strDays; }
            set { strDays = value; }
        }
        /// <summary>
        /// FromWeek
        /// Từ tuần
        /// </summary>
        public int? FromWeek
        {
            get { return intFromWeek; }
            set { intFromWeek = value; }
        }
        /// <summary>
        /// ToWeek
        /// Đến tuần
        /// </summary>
        public int? ToWeek
        {
            get { return intToWeek; }
            set { intToWeek = value; }
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
        /// LenTime
        /// Đến tiết học nào
        /// </summary>
        public int? LenTime
        {
            get { return intLenTime; }
            set { intLenTime = value; }
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
        /// 
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
        /// AddLession
        /// Tiết cộng thêm so với thời lượng, mục đích để kiểm tra trùng giờ
        /// </summary>
        public int? AddLession
        {
            get { return intAddLession; }
            set { intAddLession = value; }
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
        /// StartDate
        /// Ngày bắt đầu (nếu có thì tuần bắt đầu sẽ ko còn ý nghĩa nhiều)
        /// </summary>
        public DateTime? StartDate
        {
            get { return dtmStartDate; }
            set { dtmStartDate = value; }
        }
        /// <summary>
        /// FinishDate
        /// Ngày kết thúc (nếu có thì tuần kết thúc ko còn ý nghĩa nhiều)
        /// </summary>
        public DateTime? FinishDate
        {
            get { return dtmFinishDate; }
            set { dtmFinishDate = value; }
        }
        /// <summary>
        /// LearningSession2
        /// Ca học thứ 2 trong cùng dòng này
        /// </summary>
        public int? LearningSession2
        {
            get { return intLearningSession2; }
            set { intLearningSession2 = value; }
        }
        /// <summary>
        /// FromLessionTime2
        /// Từ tiết học nào (2)
        /// </summary>
        public int? FromLessionTime2
        {
            get { return intFromLessionTime2; }
            set { intFromLessionTime2 = value; }
        }
        /// <summary>
        /// LenTime2
        /// Đến tiết học nào  (2)
        /// </summary>
        public int? LenTime2
        {
            get { return intLenTime2; }
            set { intLenTime2 = value; }
        }
        /// <summary>
        /// StartTime2
        /// Giờ bắt đầu của ô lịch (luôn lưu dù có hay ko chọn LearningSession --> tính nhanh và ko bị ảnh ảnh hưởng khi sửa ca)
        /// </summary>
        public DateTime? StartTime2
        {
            get { return dtmStartTime2; }
            set { dtmStartTime2 = value; }
        }
        /// <summary>
        /// FinishTime2
        /// Giờ kết thúc của ô lịch (luôn lưu dù có hay ko chọn LearningSession --> tính nhanh và ko bị ảnh ảnh hưởng khi sửa ca)
        /// </summary>
        public DateTime? FinishTime2
        {
            get { return dtmFinishTime2; }
            set { dtmFinishTime2 = value; }
        }
        /// <summary>
        /// TimeLen2
        /// Tổng thời lượng ca học của ô lịch (theo đơn vị giờ nếu có nhập từ giờ đến giờ)
        /// </summary>
        public decimal? TimeLen2
        {
            get { return decTimeLen2; }
            set { decTimeLen2 = value; }
        }
        /// <summary>
        /// TimeLenText2
        /// Thời lượng dạng text (đổi từ TimeLen sang dạng hh:mm)
        /// </summary>
        public string TimeLenText2
        {
            get { return strTimeLenText2; }
            set { strTimeLenText2 = value; }
        }
        /// <summary>
        /// LearningSession3
        /// Ca học thứ 3 trong cùng dòng này
        /// </summary>
        public int? LearningSession3
        {
            get { return intLearningSession3; }
            set { intLearningSession3 = value; }
        }
        /// <summary>
        /// FromLessionTime3
        /// Từ tiết học nào (3)
        /// </summary>
        public int? FromLessionTime3
        {
            get { return intFromLessionTime3; }
            set { intFromLessionTime3 = value; }
        }
        /// <summary>
        /// LenTime3
        /// Đến tiết học nào  (3)
        /// </summary>
        public int? LenTime3
        {
            get { return intLenTime3; }
            set { intLenTime3 = value; }
        }
        /// <summary>
        /// StartTime3
        /// Giờ bắt đầu của ô lịch (luôn lưu dù có hay ko chọn LearningSession --> tính nhanh và ko bị ảnh ảnh hưởng khi sửa ca)
        /// </summary>
        public DateTime? StartTime3
        {
            get { return dtmStartTime3; }
            set { dtmStartTime3 = value; }
        }
        /// <summary>
        /// FinishTime3
        /// Giờ kết thúc của ô lịch (luôn lưu dù có hay ko chọn LearningSession --> tính nhanh và ko bị ảnh ảnh hưởng khi sửa ca)
        /// </summary>
        public DateTime? FinishTime3
        {
            get { return dtmFinishTime3; }
            set { dtmFinishTime3 = value; }
        }
        /// <summary>
        /// TimeLen3
        /// Tổng thời lượng ca học của ô lịch (theo đơn vị giờ nếu có nhập từ giờ đến giờ)
        /// </summary>
        public decimal? TimeLen3
        {
            get { return decTimeLen3; }
            set { decTimeLen3 = value; }
        }
        /// <summary>
        /// TimeLenText3
        /// Thời lượng dạng text (đổi từ TimeLen sang dạng hh:mm)
        /// </summary>
        public string TimeLenText3
        {
            get { return strTimeLenText3; }
            set { strTimeLenText3 = value; }
        }
        /// <summary>
        /// TimeLenQuantity
        /// Số giờ cần sắp theo đv giờ trong kế hoạch
        /// </summary>
        public decimal? TimeLenQuantity
        {
            get { return decTimeLenQuantity; }
            set { decTimeLenQuantity = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_ScheduleTemplateID.ToUpper()) && !Convert.IsDBNull(reader[C_ScheduleTemplateID])) this.intScheduleTemplateID = Convert.ToInt32(reader[C_ScheduleTemplateID]);
                    if (reader.GetName(i).ToUpper().Equals(C_Days.ToUpper()) && !Convert.IsDBNull(reader[C_Days])) this.strDays = Convert.ToString(reader[C_Days]);
                    if (reader.GetName(i).ToUpper().Equals(C_FromWeek.ToUpper()) && !Convert.IsDBNull(reader[C_FromWeek])) this.intFromWeek = Convert.ToInt32(reader[C_FromWeek]);
                    if (reader.GetName(i).ToUpper().Equals(C_ToWeek.ToUpper()) && !Convert.IsDBNull(reader[C_ToWeek])) this.intToWeek = Convert.ToInt32(reader[C_ToWeek]);
                    if (reader.GetName(i).ToUpper().Equals(C_FromLessionTime.ToUpper()) && !Convert.IsDBNull(reader[C_FromLessionTime])) this.intFromLessionTime = Convert.ToInt32(reader[C_FromLessionTime]);
                    if (reader.GetName(i).ToUpper().Equals(C_LenTime.ToUpper()) && !Convert.IsDBNull(reader[C_LenTime])) this.intLenTime = Convert.ToInt32(reader[C_LenTime]);
                    if (reader.GetName(i).ToUpper().Equals(C_ClassSubjectID.ToUpper()) && !Convert.IsDBNull(reader[C_ClassSubjectID])) this.lngClassSubjectID = Convert.ToInt64(reader[C_ClassSubjectID]);
                    if (reader.GetName(i).ToUpper().Equals(C_ClassID.ToUpper()) && !Convert.IsDBNull(reader[C_ClassID])) this.strClassID = Convert.ToString(reader[C_ClassID]);
                    if (reader.GetName(i).ToUpper().Equals(C_SubjectID.ToUpper()) && !Convert.IsDBNull(reader[C_SubjectID])) this.strSubjectID = Convert.ToString(reader[C_SubjectID]);
                    if (reader.GetName(i).ToUpper().Equals(C_YearID.ToUpper()) && !Convert.IsDBNull(reader[C_YearID])) this.intYearID = Convert.ToInt32(reader[C_YearID]);
                    if (reader.GetName(i).ToUpper().Equals(C_Semester.ToUpper()) && !Convert.IsDBNull(reader[C_Semester])) this.intSemester = Convert.ToInt32(reader[C_Semester]);
                    if (reader.GetName(i).ToUpper().Equals(C_TeacherID.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherID])) this.strTeacherID = Convert.ToString(reader[C_TeacherID]);
                    if (reader.GetName(i).ToUpper().Equals(C_RoomID.ToUpper()) && !Convert.IsDBNull(reader[C_RoomID])) this.strRoomID = Convert.ToString(reader[C_RoomID]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsPractice.ToUpper()) && !Convert.IsDBNull(reader[C_IsPractice])) this.bolIsPractice = Convert.ToBoolean(reader[C_IsPractice]);
                    if (reader.GetName(i).ToUpper().Equals(C_AddLession.ToUpper()) && !Convert.IsDBNull(reader[C_AddLession])) this.intAddLession = Convert.ToInt32(reader[C_AddLession]);
                    if (reader.GetName(i).ToUpper().Equals(C_LearningSession.ToUpper()) && !Convert.IsDBNull(reader[C_LearningSession])) this.intLearningSession = Convert.ToInt32(reader[C_LearningSession]);
                    if (reader.GetName(i).ToUpper().Equals(C_ScheduleContent.ToUpper()) && !Convert.IsDBNull(reader[C_ScheduleContent])) this.strScheduleContent = Convert.ToString(reader[C_ScheduleContent]);
                    if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
                    if (reader.GetName(i).ToUpper().Equals(C_SubjectPlanID.ToUpper()) && !Convert.IsDBNull(reader[C_SubjectPlanID])) this.lngSubjectPlanID = Convert.ToInt64(reader[C_SubjectPlanID]);
                    if (reader.GetName(i).ToUpper().Equals(C_StartTime.ToUpper()) && !Convert.IsDBNull(reader[C_StartTime])) this.dtmStartTime = Convert.ToDateTime(reader[C_StartTime]);
                    if (reader.GetName(i).ToUpper().Equals(C_FinishTime.ToUpper()) && !Convert.IsDBNull(reader[C_FinishTime])) this.dtmFinishTime = Convert.ToDateTime(reader[C_FinishTime]);
                    if (reader.GetName(i).ToUpper().Equals(C_TimeLen.ToUpper()) && !Convert.IsDBNull(reader[C_TimeLen])) this.decTimeLen = Convert.ToDecimal(reader[C_TimeLen]);
                    if (reader.GetName(i).ToUpper().Equals(C_TimeLenText.ToUpper()) && !Convert.IsDBNull(reader[C_TimeLenText])) this.strTimeLenText = Convert.ToString(reader[C_TimeLenText]);
                    if (reader.GetName(i).ToUpper().Equals(C_StartDate.ToUpper()) && !Convert.IsDBNull(reader[C_StartDate])) this.dtmStartDate = Convert.ToDateTime(reader[C_StartDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_FinishDate.ToUpper()) && !Convert.IsDBNull(reader[C_FinishDate])) this.dtmFinishDate = Convert.ToDateTime(reader[C_FinishDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_LearningSession2.ToUpper()) && !Convert.IsDBNull(reader[C_LearningSession2])) this.intLearningSession2 = Convert.ToInt32(reader[C_LearningSession2]);
                    if (reader.GetName(i).ToUpper().Equals(C_FromLessionTime2.ToUpper()) && !Convert.IsDBNull(reader[C_FromLessionTime2])) this.intFromLessionTime2 = Convert.ToInt32(reader[C_FromLessionTime2]);
                    if (reader.GetName(i).ToUpper().Equals(C_LenTime2.ToUpper()) && !Convert.IsDBNull(reader[C_LenTime2])) this.intLenTime2 = Convert.ToInt32(reader[C_LenTime2]);
                    if (reader.GetName(i).ToUpper().Equals(C_StartTime2.ToUpper()) && !Convert.IsDBNull(reader[C_StartTime2])) this.dtmStartTime2 = Convert.ToDateTime(reader[C_StartTime2]);
                    if (reader.GetName(i).ToUpper().Equals(C_FinishTime2.ToUpper()) && !Convert.IsDBNull(reader[C_FinishTime2])) this.dtmFinishTime2 = Convert.ToDateTime(reader[C_FinishTime2]);
                    if (reader.GetName(i).ToUpper().Equals(C_TimeLen2.ToUpper()) && !Convert.IsDBNull(reader[C_TimeLen2])) this.decTimeLen2 = Convert.ToDecimal(reader[C_TimeLen2]);
                    if (reader.GetName(i).ToUpper().Equals(C_TimeLenText2.ToUpper()) && !Convert.IsDBNull(reader[C_TimeLenText2])) this.strTimeLenText2 = Convert.ToString(reader[C_TimeLenText2]);
                    if (reader.GetName(i).ToUpper().Equals(C_LearningSession3.ToUpper()) && !Convert.IsDBNull(reader[C_LearningSession3])) this.intLearningSession3 = Convert.ToInt32(reader[C_LearningSession3]);
                    if (reader.GetName(i).ToUpper().Equals(C_FromLessionTime3.ToUpper()) && !Convert.IsDBNull(reader[C_FromLessionTime3])) this.intFromLessionTime3 = Convert.ToInt32(reader[C_FromLessionTime3]);
                    if (reader.GetName(i).ToUpper().Equals(C_LenTime3.ToUpper()) && !Convert.IsDBNull(reader[C_LenTime3])) this.intLenTime3 = Convert.ToInt32(reader[C_LenTime3]);
                    if (reader.GetName(i).ToUpper().Equals(C_StartTime3.ToUpper()) && !Convert.IsDBNull(reader[C_StartTime3])) this.dtmStartTime3 = Convert.ToDateTime(reader[C_StartTime3]);
                    if (reader.GetName(i).ToUpper().Equals(C_FinishTime3.ToUpper()) && !Convert.IsDBNull(reader[C_FinishTime3])) this.dtmFinishTime3 = Convert.ToDateTime(reader[C_FinishTime3]);
                    if (reader.GetName(i).ToUpper().Equals(C_TimeLen3.ToUpper()) && !Convert.IsDBNull(reader[C_TimeLen3])) this.decTimeLen3 = Convert.ToDecimal(reader[C_TimeLen3]);
                    if (reader.GetName(i).ToUpper().Equals(C_TimeLenText3.ToUpper()) && !Convert.IsDBNull(reader[C_TimeLenText3])) this.strTimeLenText3 = Convert.ToString(reader[C_TimeLenText3]);
                    if (reader.GetName(i).ToUpper().Equals(C_TimeLenQuantity.ToUpper()) && !Convert.IsDBNull(reader[C_TimeLenQuantity])) this.decTimeLenQuantity = Convert.ToDecimal(reader[C_TimeLenQuantity]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_ScheduleTemplate", objEx);
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
                if (!Convert.IsDBNull(drw[C_ScheduleTemplateID])) this.intScheduleTemplateID = Convert.ToInt32(drw[C_ScheduleTemplateID]);
                if (!Convert.IsDBNull(drw[C_Days])) this.strDays = Convert.ToString(drw[C_Days]);
                if (!Convert.IsDBNull(drw[C_FromWeek])) this.intFromWeek = Convert.ToInt32(drw[C_FromWeek]);
                if (!Convert.IsDBNull(drw[C_ToWeek])) this.intToWeek = Convert.ToInt32(drw[C_ToWeek]);
                if (!Convert.IsDBNull(drw[C_FromLessionTime])) this.intFromLessionTime = Convert.ToInt32(drw[C_FromLessionTime]);
                if (!Convert.IsDBNull(drw[C_LenTime])) this.intLenTime = Convert.ToInt32(drw[C_LenTime]);
                if (!Convert.IsDBNull(drw[C_ClassSubjectID])) this.lngClassSubjectID = Convert.ToInt64(drw[C_ClassSubjectID]);
                if (!Convert.IsDBNull(drw[C_ClassID])) this.strClassID = Convert.ToString(drw[C_ClassID]);
                if (!Convert.IsDBNull(drw[C_SubjectID])) this.strSubjectID = Convert.ToString(drw[C_SubjectID]);
                if (!Convert.IsDBNull(drw[C_YearID])) this.intYearID = Convert.ToInt32(drw[C_YearID]);
                if (!Convert.IsDBNull(drw[C_Semester])) this.intSemester = Convert.ToInt32(drw[C_Semester]);
                if (!Convert.IsDBNull(drw[C_TeacherID])) this.strTeacherID = Convert.ToString(drw[C_TeacherID]);
                if (!Convert.IsDBNull(drw[C_RoomID])) this.strRoomID = Convert.ToString(drw[C_RoomID]);
                if (!Convert.IsDBNull(drw[C_IsPractice])) this.bolIsPractice = Convert.ToBoolean(drw[C_IsPractice]);
                if (!Convert.IsDBNull(drw[C_AddLession])) this.intAddLession = Convert.ToInt32(drw[C_AddLession]);
                if (!Convert.IsDBNull(drw[C_LearningSession])) this.intLearningSession = Convert.ToInt32(drw[C_LearningSession]);
                if (!Convert.IsDBNull(drw[C_ScheduleContent])) this.strScheduleContent = Convert.ToString(drw[C_ScheduleContent]);
                if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
                if (!Convert.IsDBNull(drw[C_SubjectPlanID])) this.lngSubjectPlanID = Convert.ToInt64(drw[C_SubjectPlanID]);
                if (!Convert.IsDBNull(drw[C_StartTime])) this.dtmStartTime = Convert.ToDateTime(drw[C_StartTime]);
                if (!Convert.IsDBNull(drw[C_FinishTime])) this.dtmFinishTime = Convert.ToDateTime(drw[C_FinishTime]);
                if (!Convert.IsDBNull(drw[C_TimeLen])) this.decTimeLen = Convert.ToDecimal(drw[C_TimeLen]);
                if (!Convert.IsDBNull(drw[C_TimeLenText])) this.strTimeLenText = Convert.ToString(drw[C_TimeLenText]);
                if (!Convert.IsDBNull(drw[C_StartDate])) this.dtmStartDate = Convert.ToDateTime(drw[C_StartDate]);
                if (!Convert.IsDBNull(drw[C_FinishDate])) this.dtmFinishDate = Convert.ToDateTime(drw[C_FinishDate]);
                if (!Convert.IsDBNull(drw[C_LearningSession2])) this.intLearningSession2 = Convert.ToInt32(drw[C_LearningSession2]);
                if (!Convert.IsDBNull(drw[C_FromLessionTime2])) this.intFromLessionTime2 = Convert.ToInt32(drw[C_FromLessionTime2]);
                if (!Convert.IsDBNull(drw[C_LenTime2])) this.intLenTime2 = Convert.ToInt32(drw[C_LenTime2]);
                if (!Convert.IsDBNull(drw[C_StartTime2])) this.dtmStartTime2 = Convert.ToDateTime(drw[C_StartTime2]);
                if (!Convert.IsDBNull(drw[C_FinishTime2])) this.dtmFinishTime2 = Convert.ToDateTime(drw[C_FinishTime2]);
                if (!Convert.IsDBNull(drw[C_TimeLen2])) this.decTimeLen2 = Convert.ToDecimal(drw[C_TimeLen2]);
                if (!Convert.IsDBNull(drw[C_TimeLenText2])) this.strTimeLenText2 = Convert.ToString(drw[C_TimeLenText2]);
                if (!Convert.IsDBNull(drw[C_LearningSession3])) this.intLearningSession3 = Convert.ToInt32(drw[C_LearningSession3]);
                if (!Convert.IsDBNull(drw[C_FromLessionTime3])) this.intFromLessionTime3 = Convert.ToInt32(drw[C_FromLessionTime3]);
                if (!Convert.IsDBNull(drw[C_LenTime3])) this.intLenTime3 = Convert.ToInt32(drw[C_LenTime3]);
                if (!Convert.IsDBNull(drw[C_StartTime3])) this.dtmStartTime3 = Convert.ToDateTime(drw[C_StartTime3]);
                if (!Convert.IsDBNull(drw[C_FinishTime3])) this.dtmFinishTime3 = Convert.ToDateTime(drw[C_FinishTime3]);
                if (!Convert.IsDBNull(drw[C_TimeLen3])) this.decTimeLen3 = Convert.ToDecimal(drw[C_TimeLen3]);
                if (!Convert.IsDBNull(drw[C_TimeLenText3])) this.strTimeLenText3 = Convert.ToString(drw[C_TimeLenText3]);
                if (!Convert.IsDBNull(drw[C_TimeLenQuantity])) this.decTimeLenQuantity = Convert.ToDecimal(drw[C_TimeLenQuantity]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_ScheduleTemplate", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        /// Nạp thông tin item 
        /// Store: SIM_ScheduleTemplate_GET 
        ///</summary>
        /// <returns>true ? Có : False ? Không</returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_ScheduleTemplate_GET");
                objIData.AddParameter(P_ScheduleTemplateID, this.intScheduleTemplateID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_ScheduleTemplate", objEx);
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
        /// Store: SIM_ScheduleTemplate_GET 
        ///</summary>
        /// <returns> SIM_ScheduleTemplate </returns>
        public SIM_ScheduleTemplate Get(int? intScheduleTemplateID)
        {
            SIM_ScheduleTemplate obj = new SIM_ScheduleTemplate();
            if (objIData != null)
                obj.IDB = objIData;
            obj.ScheduleTemplateID = intScheduleTemplateID;
            if (obj.Get())
                return obj;
            this.objErrorException = obj.ErrorException;
            return null;
        }
        ///<summary>
        /// ExecNonQuery : SIM_ScheduleTemplate
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_ScheduleTemplate", objEx);
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
        /// Search : SIM_ScheduleTemplate
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_ScheduleTemplate", objEx);
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
        /// Search : SIM_ScheduleTemplate
        /// Lấy hết dữ liệu
        /// Store: SIM_ScheduleTemplate_GETALL 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable GetAll()
        {
            return GetDataTable("SIM_ScheduleTemplate_GETALL");
        }

        ///<summary>
        /// Search : SIM_ScheduleTemplate
        /// Tìm dữ liệu
        /// Store: SIM_ScheduleTemplate_SEARCH 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable Search(params object[] pars)
        {
            return GetDataTable("SIM_ScheduleTemplate_SEARCH", pars);
        }

        ///<summary>
        /// Add : SIM_ScheduleTemplate
        /// Thêm dữ liệu
        /// Store: SIM_ScheduleTemplate_ADD 
        ///</summary>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_ScheduleTemplate_ADD");
                objIData.AddParameter(P_Days, this.strDays);
                objIData.AddParameter(P_FromWeek, this.intFromWeek);
                objIData.AddParameter(P_ToWeek, this.intToWeek);
                objIData.AddParameter(P_FromLessionTime, this.intFromLessionTime);
                objIData.AddParameter(P_LenTime, this.intLenTime);
                objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
                objIData.AddParameter(P_ClassID, this.strClassID);
                objIData.AddParameter(P_SubjectID, this.strSubjectID);
                objIData.AddParameter(P_YearID, this.intYearID);
                objIData.AddParameter(P_Semester, this.intSemester);
                objIData.AddParameter(P_TeacherID, this.strTeacherID);
                objIData.AddParameter(P_RoomID, this.strRoomID);
                objIData.AddParameter(P_IsPractice, this.bolIsPractice);
                objIData.AddParameter(P_AddLession, this.intAddLession);
                objIData.AddParameter(P_LearningSession, this.intLearningSession);
                objIData.AddParameter(P_ScheduleContent, this.strScheduleContent);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_SubjectPlanID, this.lngSubjectPlanID);
                objIData.AddParameter(P_StartTime, this.dtmStartTime);
                objIData.AddParameter(P_FinishTime, this.dtmFinishTime);
                objIData.AddParameter(P_TimeLen, this.decTimeLen);
                objIData.AddParameter(P_TimeLenText, this.strTimeLenText);
                objIData.AddParameter(P_StartDate, this.dtmStartDate);
                objIData.AddParameter(P_FinishDate, this.dtmFinishDate);
                objIData.AddParameter(P_LearningSession2, this.intLearningSession2);
                objIData.AddParameter(P_FromLessionTime2, this.intFromLessionTime2);
                objIData.AddParameter(P_LenTime2, this.intLenTime2);
                objIData.AddParameter(P_StartTime2, this.dtmStartTime2);
                objIData.AddParameter(P_FinishTime2, this.dtmFinishTime2);
                objIData.AddParameter(P_TimeLen2, this.decTimeLen2);
                objIData.AddParameter(P_TimeLenText2, this.strTimeLenText2);
                objIData.AddParameter(P_LearningSession3, this.intLearningSession3);
                objIData.AddParameter(P_FromLessionTime3, this.intFromLessionTime3);
                objIData.AddParameter(P_LenTime3, this.intLenTime3);
                objIData.AddParameter(P_StartTime3, this.dtmStartTime3);
                objIData.AddParameter(P_FinishTime3, this.dtmFinishTime3);
                objIData.AddParameter(P_TimeLen3, this.decTimeLen3);
                objIData.AddParameter(P_TimeLenText3, this.strTimeLenText3);
                objIData.AddParameter(P_TimeLenQuantity, this.decTimeLenQuantity);
                this.intScheduleTemplateID = Convert.ToInt32(objIData.ExecStoreToString());
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_ScheduleTemplate", objEx);
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
        /// Update : SIM_ScheduleTemplate
        /// Cập nhật dữ liệu
        /// Store: SIM_ScheduleTemplate_EDIT 
        ///</summary>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_ScheduleTemplate_EDIT");
                objIData.AddParameter(P_ScheduleTemplateID, this.intScheduleTemplateID);
                objIData.AddParameter(P_Days, this.strDays);
                objIData.AddParameter(P_FromWeek, this.intFromWeek);
                objIData.AddParameter(P_ToWeek, this.intToWeek);
                objIData.AddParameter(P_FromLessionTime, this.intFromLessionTime);
                objIData.AddParameter(P_LenTime, this.intLenTime);
                objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
                objIData.AddParameter(P_ClassID, this.strClassID);
                objIData.AddParameter(P_SubjectID, this.strSubjectID);
                objIData.AddParameter(P_YearID, this.intYearID);
                objIData.AddParameter(P_Semester, this.intSemester);
                objIData.AddParameter(P_TeacherID, this.strTeacherID);
                objIData.AddParameter(P_RoomID, this.strRoomID);
                objIData.AddParameter(P_IsPractice, this.bolIsPractice);
                objIData.AddParameter(P_AddLession, this.intAddLession);
                objIData.AddParameter(P_LearningSession, this.intLearningSession);
                objIData.AddParameter(P_ScheduleContent, this.strScheduleContent);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_SubjectPlanID, this.lngSubjectPlanID);
                objIData.AddParameter(P_StartTime, this.dtmStartTime);
                objIData.AddParameter(P_FinishTime, this.dtmFinishTime);
                objIData.AddParameter(P_TimeLen, this.decTimeLen);
                objIData.AddParameter(P_TimeLenText, this.strTimeLenText);
                objIData.AddParameter(P_StartDate, this.dtmStartDate);
                objIData.AddParameter(P_FinishDate, this.dtmFinishDate);
                objIData.AddParameter(P_LearningSession2, this.intLearningSession2);
                objIData.AddParameter(P_FromLessionTime2, this.intFromLessionTime2);
                objIData.AddParameter(P_LenTime2, this.intLenTime2);
                objIData.AddParameter(P_StartTime2, this.dtmStartTime2);
                objIData.AddParameter(P_FinishTime2, this.dtmFinishTime2);
                objIData.AddParameter(P_TimeLen2, this.decTimeLen2);
                objIData.AddParameter(P_TimeLenText2, this.strTimeLenText2);
                objIData.AddParameter(P_LearningSession3, this.intLearningSession3);
                objIData.AddParameter(P_FromLessionTime3, this.intFromLessionTime3);
                objIData.AddParameter(P_LenTime3, this.intLenTime3);
                objIData.AddParameter(P_StartTime3, this.dtmStartTime3);
                objIData.AddParameter(P_FinishTime3, this.dtmFinishTime3);
                objIData.AddParameter(P_TimeLen3, this.decTimeLen3);
                objIData.AddParameter(P_TimeLenText3, this.strTimeLenText3);
                objIData.AddParameter(P_TimeLenQuantity, this.decTimeLenQuantity);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_ScheduleTemplate", objEx);
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
        /// Delete : SIM_ScheduleTemplate
        /// Xóa dữ liệu
        /// Store: SIM_ScheduleTemplate_DELETE 
        ///</summary>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_ScheduleTemplate_DELETE");
                objIData.AddParameter(P_ScheduleTemplateID, this.intScheduleTemplateID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_ScheduleTemplate", objEx);
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
        /// Store: SIM_ScheduleTemplate_DELETE 
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(int? intScheduleTemplateID)
        {
            this.intScheduleTemplateID = intScheduleTemplateID;
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

        public SIM_ScheduleTemplate()
        {
        }
        public SIM_ScheduleTemplate(int? intScheduleTemplateID)
        {
            this.intScheduleTemplateID = intScheduleTemplateID;
            this.Get();
        }

        #endregion

        #region Variable Static

        #region Parameter Names

        public const String P_ScheduleTemplateID = "@" + C_ScheduleTemplateID;
        public const String P_Days = "@" + C_Days;
        public const String P_FromWeek = "@" + C_FromWeek;
        public const String P_ToWeek = "@" + C_ToWeek;
        public const String P_FromLessionTime = "@" + C_FromLessionTime;
        public const String P_LenTime = "@" + C_LenTime;
        public const String P_ClassSubjectID = "@" + C_ClassSubjectID;
        public const String P_ClassID = "@" + C_ClassID;
        public const String P_SubjectID = "@" + C_SubjectID;
        public const String P_YearID = "@" + C_YearID;
        public const String P_Semester = "@" + C_Semester;
        public const String P_TeacherID = "@" + C_TeacherID;
        public const String P_RoomID = "@" + C_RoomID;
        public const String P_IsPractice = "@" + C_IsPractice;
        public const String P_AddLession = "@" + C_AddLession;
        public const String P_LearningSession = "@" + C_LearningSession;
        public const String P_ScheduleContent = "@" + C_ScheduleContent;
        public const String P_Description = "@" + C_Description;
        public const String P_SubjectPlanID = "@" + C_SubjectPlanID;
        public const String P_StartTime = "@" + C_StartTime;
        public const String P_FinishTime = "@" + C_FinishTime;
        public const String P_TimeLen = "@" + C_TimeLen;
        public const String P_TimeLenText = "@" + C_TimeLenText;
        public const String P_StartDate = "@" + C_StartDate;
        public const String P_FinishDate = "@" + C_FinishDate;
        public const String P_LearningSession2 = "@" + C_LearningSession2;
        public const String P_FromLessionTime2 = "@" + C_FromLessionTime2;
        public const String P_LenTime2 = "@" + C_LenTime2;
        public const String P_StartTime2 = "@" + C_StartTime2;
        public const String P_FinishTime2 = "@" + C_FinishTime2;
        public const String P_TimeLen2 = "@" + C_TimeLen2;
        public const String P_TimeLenText2 = "@" + C_TimeLenText2;
        public const String P_LearningSession3 = "@" + C_LearningSession3;
        public const String P_FromLessionTime3 = "@" + C_FromLessionTime3;
        public const String P_LenTime3 = "@" + C_LenTime3;
        public const String P_StartTime3 = "@" + C_StartTime3;
        public const String P_FinishTime3 = "@" + C_FinishTime3;
        public const String P_TimeLen3 = "@" + C_TimeLen3;
        public const String P_TimeLenText3 = "@" + C_TimeLenText3;
        public const String P_TimeLenQuantity = "@" + C_TimeLenQuantity;

        #endregion //Parameter names

        #region Column Names

        public const String C_ScheduleTemplateID = "ScheduleTemplateID";
        public const String C_Days = "Days";
        public const String C_FromWeek = "FromWeek";
        public const String C_ToWeek = "ToWeek";
        public const String C_FromLessionTime = "FromLessionTime";
        public const String C_LenTime = "LenTime";
        public const String C_ClassSubjectID = "ClassSubjectID";
        public const String C_ClassID = "ClassID";
        public const String C_SubjectID = "SubjectID";
        public const String C_YearID = "YearID";
        public const String C_Semester = "Semester";
        public const String C_TeacherID = "TeacherID";
        public const String C_RoomID = "RoomID";
        public const String C_IsPractice = "IsPractice";
        public const String C_AddLession = "AddLession";
        public const String C_LearningSession = "LearningSession";
        public const String C_ScheduleContent = "ScheduleContent";
        public const String C_Description = "Description";
        public const String C_SubjectPlanID = "SubjectPlanID";
        public const String C_StartTime = "StartTime";
        public const String C_FinishTime = "FinishTime";
        public const String C_TimeLen = "TimeLen";
        public const String C_TimeLenText = "TimeLenText";
        public const String C_StartDate = "StartDate";
        public const String C_FinishDate = "FinishDate";
        public const String C_LearningSession2 = "LearningSession2";
        public const String C_FromLessionTime2 = "FromLessionTime2";
        public const String C_LenTime2 = "LenTime2";
        public const String C_StartTime2 = "StartTime2";
        public const String C_FinishTime2 = "FinishTime2";
        public const String C_TimeLen2 = "TimeLen2";
        public const String C_TimeLenText2 = "TimeLenText2";
        public const String C_LearningSession3 = "LearningSession3";
        public const String C_FromLessionTime3 = "FromLessionTime3";
        public const String C_LenTime3 = "LenTime3";
        public const String C_StartTime3 = "StartTime3";
        public const String C_FinishTime3 = "FinishTime3";
        public const String C_TimeLen3 = "TimeLen3";
        public const String C_TimeLenText3 = "TimeLenText3";
        public const String C_TimeLenQuantity = "TimeLenQuantity";

        #endregion //Column names

        #endregion Variable Static
    }
}


