
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
    /// Created date 	: 13/06/2025 
    /// Description 
    /// </summary>	
    public partial class SIM_Class_Subject
    {
        #region Member Variables

        private long? lngClassSubjectID = null;
        private int? intSemester = null;//Học kỳ: 1, 2
        private int? intYearID = null;//Mã niên học
        private string strClassID = null;//Mã lớp
        private string strSubjectID = null;//Mã môn
        private int? intTheoryQuantity = null;//Số tiết lý thuyết
        private int? intPracticeQuantity = null;//Số tiết thực hành
        private int? intTestQuantity = null;//Số giờ kiểm tra
        private int? intDoneQuantity = null;//Số tiết đã học
        private int? intUnitText = null;
        private string strTeachingBy = null;//Được dạy bởi giáo viên nào (Mã giáo viên)
        private string strTeachingAtRoom = null;//Mã phòng được dạy, mặc định lấy phòng chính của lớp xuống nếu có.
        private string strTeachingAtRoomPractice = null;//Phòng dành cho tiết thực hành nếu có
        private int? intClassSubjectStatus = null;//0: bình thường, 1: Đã bị ghép, 2: Đã bị tách,3: của lớp ghép, 4: của lớp tách
        private int? intClassSubjectStatusType = null;//Kiểu ghép hoặc tách 0_bình thường hoặc ghép tách cả môn, 1_Chỉ LT, 2_ Chỉ TH. Ghép thì chỉ LT or both Tách thì chỉ TH or both
        private string strBigClassID = null;//Mã lớp ghép sử dụng môn học lớp này
        private int? intStartTestWeek = null;//Tuần bắt đầu thi
        private int? intFinishTestWeek = null;//Tuần kết thúc thi
        private string strTestTeacher1 = null;//Giảng viên coi thi 1
        private string strTestTeacher2 = null;//Giảng viên coi thi 2
        private string strTestAtRoom = null;//Phòng thị lý thuyết
        private string strTestAtRoom2 = null;
        private string strDays = null;//Xác định môn học lớp sắp vào những thứ nào, cách nhau dấu ;
        private int? intClassSubjectSession = null;//Buổi học: 0: bất kì theo buổi của lớp và môn, 1: Sáng, 2: Chiều, 3:Tối
        private string strDaysOfPractice = null;//Xác định môn học lớp sắp vào những thứ nào, cách nhau dấu ;
        private int? intClassSubjectSessionOfPractice = null;//Buổi học: 0: bất kì theo buổi của lớp và môn, 1: Sáng, 2: Chiều, 3:Tối
        private double? dblMarkRatio1 = null;//Hệ số điểm 1
        private double? dblMarkRatio2 = null;//Hệ số điểm 2
        private double? dblMarkRatio3 = null;//Hệ số điểm
        private double? dblMarkRatio4 = null;//Hệ số điểm
        private double? dblMarkRatio5 = null;//Hệ số điểm
        private int? intMark1Number = null;//Số cột điểm hs 1
        private int? intMark2Number = null;//Số cột điểm hs 2
        private int? intTotalFee = null;//Tổng tiền học phí cho học phần này. Lấy từ chương trình khung
        private long? lngOrderIndex = null;
        private bool bolIsLocked = false;//Đã bị khóa, không cho nhập
        private bool bolIsOldData = false;//Là dữ liệu cũ chuyển qua
        private string strCreatedBy = null;
        private DateTime? dtmCreatedAt = null;//Ngày tạo
        private string strModifiedBy = null;//Người sửa
        private DateTime? dtmModifiedAt = null;//Ngày sửa
        private bool bolIsLockedMark = false;//Đã bị khóa, không cho nhập điểm quá trình
        private bool bolIsLockedExam1 = false;//Đã bị khóa, không cho nhập điểm thi lần 1
        private int? intTheoryQuantityOfTraining = null;//Số tiết lý thuyết (theo chương trình)
        private int? intPracticeQuantityOfTraining = null;//Số tiết thực hành (theo chương trình)
        private int? intTestQuantityOfTraining = null;//Số giờ kiểm tra (theo chương trình)
        private int? intMethodTestID = null;//Hình thức thi của môn học lớp này
        private bool bolIsContractTeaching = false;//Là dạy theo hợp đồng (sẽ không tính vào giờ giảng của gv biên chế = ko muốn vượt giờ định mức)
        private bool bolIsContractTeachingOfPractice = false;//Là dạy theo hợp đồng (sẽ không tính vào giờ giảng của gv biên chế = ko muốn vượt giờ định mức) - Cho giờ thực hành
        private string strReplaceTeacherID = null;//Mã gv dạy thay LT
        private string strReplaceTeacherIDOfPractice = null;//Mã gv dạy thay thực hành
        private long? lngTeachingPrice = null;//Đơn giá LT
        private long? lngTeachingPriceForPractice = null;//Đơn giá TH
        private int? intTheoryUnitText = null;//Số chỉ LT
        private int? intPracticeUnitText = null;//Số chỉ TH
        private long? lngClassSubjectSameID = null;//Nhóm môn học lớp tương đương
        private DateTime? dtmScheduleLockedToDate = null;//Khóa thời khóa biểu đến ngày? (từ ngày này trở về trước là bị khóa)
        private string strTeachingByTheory = null;//GV dạy LT (nếu không chọn thì mặc định là TeachingBy). Khi chọn nhiều gv, cột này giờ ý nghĩa ko còn nhiều, tương lai bỏ luôn
        private string strTeachingByPractice = null;//GV dạy TH (nếu không chọn thì mặc định là TeachingBy). Khi chọn nhiều gv, cột này giờ ý nghĩa ko còn nhiều, tương lai bỏ luôn
        private decimal? decMaxPercentOff = null;//% vắng tối đa xét dự thi
        private decimal? decMinTestAverage = null;//Điểm tb tối thiểu xét dự thi
        private bool bolIsLockedTeachingSchedule = false;//Khóa dữ liệu lịch trình giảng dạy
        private bool bolIsIgnoreTeachingTime = false;//Bỏ qua ko tính giờ dạy
        private string strMeetingLink = null;//ID cuộc họp (conference_id in google event). Link html cuộc họp
        private string strMeetingCode = null;//Code cuộc họp (meeting_code in google event). Lấy từ Event qua, để phân biệt lịch thường hay lịch có họp online
        private DateTime? dtmStartRegister = null;//Ngày giờ bắt đầu đăng ký
        private DateTime? dtmFinishRegister = null;//Ngày giờ kết thúc đăng ký, sv ko thể đăng ký hay sửa (cố vấn học tập vẫn còn làm dc)
        private DateTime? dtmCommitRegister = null;//Ngày giờ khóa đăng ký, cố vấn học tập cũng ko thể sửa, xóa hay đăng ký thêm
        private int? intMaxRegister = null;//Số lượng sv tối đa được đăng ký
        private string strTeacherList = null;//Danh sách tên gv (tự động tạo theo SIM_Class_Subject_Teacher)
        private string strRoomList = null;//Danh sách tên phòng LT (tự động tạo theo SIM_Class_Subject_Room)
        private string strTeacherNameList = null;//Danh sách tên gv (tự động tạo theo SIM_Class_Subject_Teacher)
        private string strRoomNameList = null;//Danh sách tên phòng LT (tự động tạo theo SIM_Class_Subject_Room)
        private string strTeacherListTheory = null;//Danh sách tên gv (tự động tạo theo SIM_Class_Subject_Teacher)
        private string strRoomListTheory = null;//Danh sách tên phòng LT (tự động tạo theo SIM_Class_Subject_Room)
        private string strTeacherNameListTheory = null;//Tách LT riêng (khi ko có thì mặc định là theo TeacherNameList), tương tự các phần TH cũng vậy
        private string strRoomNameListTheory = null;//Danh sách tên phòng LT (tự động tạo theo SIM_Class_Subject_Room)
        private string strTeacherListPractice = null;//Danh sách tên gv (tự động tạo theo SIM_Class_Subject_Teacher)
        private string strRoomListPractice = null;//Danh sách tên phòng LT (tự động tạo theo SIM_Class_Subject_Room)
        private string strTeacherNameListPractice = null;//Danh sách tên gv (tự động tạo theo SIM_Class_Subject_Teacher)
        private string strRoomNameListPractice = null;//Danh sách tên phòng LT (tự động tạo theo SIM_Class_Subject_Room)
        private DateTime? dtmStartSetTeacher = null;//Ngày giờ bắt đầu cho phép phân công
        private DateTime? dtmFinishSetTeacher = null;//Ngày giờ kết thúc phân công
        private int? intTestSessionID1 = null;//Mã ca thi 1 (kế hoạch thi)
        private int? intID_dt_mon = null;//Mã chương trình đào tạo chi tiết (hệ thống cũ lưu)
        private int? intTestSessionID2 = null;//Mã ca thi 2 (kế hoạch thi)
        private int? intTestSessionID3 = null;//Mã ca thi  (kế hoạch thi)
        private int? intTestSessionID4 = null;//Mã ca thi  (kế hoạch thi)
        private int? intTestSessionID5 = null;//Mã ca thi  (kế hoạch thi)
        private int? intPlanRowCount = null;//Tổng số dòng kế hoạch (tách dòng trong kế hoạch tuần)
        private bool bolAllowScheduling = false;//Có cho sắp lịch
        private bool bolAllowTestScheduling = false;//Cho phép sắp lịch thi tự động
        private bool bolIsLockedWeekDetailPlan = false;//Khóa kế hoạch tuần
        private DateTime? dtmTestScheduleLockedToDate = null;//Khóa lịch thi đến ngày? (từ ngày này trở về trước là bị khóa)
        private DateTime? dtmScheduleCheckingExtendToDate = null;//Gia hạn sổ lên lớp đến ngày giờ (NSG có xài, TW3 chưa)
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

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
        /// Semester
        /// Học kỳ: 1, 2
        /// </summary>
        public int? Semester
        {
            get { return intSemester; }
            set { intSemester = value; }
        }
        /// <summary>
        /// YearID
        /// Mã niên học
        /// </summary>
        public int? YearID
        {
            get { return intYearID; }
            set { intYearID = value; }
        }
        /// <summary>
        /// ClassID
        /// Mã lớp
        /// </summary>
        public string ClassID
        {
            get { return strClassID; }
            set { strClassID = value; }
        }
        /// <summary>
        /// SubjectID
        /// Mã môn
        /// </summary>
        public string SubjectID
        {
            get { return strSubjectID; }
            set { strSubjectID = value; }
        }
        /// <summary>
        /// TheoryQuantity
        /// Số tiết lý thuyết
        /// </summary>
        public int? TheoryQuantity
        {
            get { return intTheoryQuantity; }
            set { intTheoryQuantity = value; }
        }
        /// <summary>
        /// PracticeQuantity
        /// Số tiết thực hành
        /// </summary>
        public int? PracticeQuantity
        {
            get { return intPracticeQuantity; }
            set { intPracticeQuantity = value; }
        }
        /// <summary>
        /// TestQuantity
        /// Số giờ kiểm tra
        /// </summary>
        public int? TestQuantity
        {
            get { return intTestQuantity; }
            set { intTestQuantity = value; }
        }
        /// <summary>
        /// DoneQuantity
        /// Số tiết đã học
        /// </summary>
        public int? DoneQuantity
        {
            get { return intDoneQuantity; }
            set { intDoneQuantity = value; }
        }
        /// <summary>
        /// UnitText
        /// 
        /// </summary>
        public int? UnitText
        {
            get { return intUnitText; }
            set { intUnitText = value; }
        }
        /// <summary>
        /// TeachingBy
        /// Được dạy bởi giáo viên nào (Mã giáo viên)
        /// </summary>
        public string TeachingBy
        {
            get { return strTeachingBy; }
            set { strTeachingBy = value; }
        }
        /// <summary>
        /// TeachingAtRoom
        /// Mã phòng được dạy, mặc định lấy phòng chính của lớp xuống nếu có.
        /// </summary>
        public string TeachingAtRoom
        {
            get { return strTeachingAtRoom; }
            set { strTeachingAtRoom = value; }
        }
        /// <summary>
        /// TeachingAtRoomPractice
        /// Phòng dành cho tiết thực hành nếu có
        /// </summary>
        public string TeachingAtRoomPractice
        {
            get { return strTeachingAtRoomPractice; }
            set { strTeachingAtRoomPractice = value; }
        }
        /// <summary>
        /// ClassSubjectStatus
        /// 0: bình thường, 1: Đã bị ghép, 2: Đã bị tách,3: của lớp ghép, 4: của lớp tách
        /// </summary>
        public int? ClassSubjectStatus
        {
            get { return intClassSubjectStatus; }
            set { intClassSubjectStatus = value; }
        }
        /// <summary>
        /// ClassSubjectStatusType
        /// Kiểu ghép hoặc tách 0_bình thường hoặc ghép tách cả môn, 1_Chỉ LT, 2_ Chỉ TH. Ghép thì chỉ LT or both Tách thì chỉ TH or both
        /// </summary>
        public int? ClassSubjectStatusType
        {
            get { return intClassSubjectStatusType; }
            set { intClassSubjectStatusType = value; }
        }
        /// <summary>
        /// BigClassID
        /// Mã lớp ghép sử dụng môn học lớp này
        /// </summary>
        public string BigClassID
        {
            get { return strBigClassID; }
            set { strBigClassID = value; }
        }
        /// <summary>
        /// StartTestWeek
        /// Tuần bắt đầu thi
        /// </summary>
        public int? StartTestWeek
        {
            get { return intStartTestWeek; }
            set { intStartTestWeek = value; }
        }
        /// <summary>
        /// FinishTestWeek
        /// Tuần kết thúc thi
        /// </summary>
        public int? FinishTestWeek
        {
            get { return intFinishTestWeek; }
            set { intFinishTestWeek = value; }
        }
        /// <summary>
        /// TestTeacher1
        /// Giảng viên coi thi 1
        /// </summary>
        public string TestTeacher1
        {
            get { return strTestTeacher1; }
            set { strTestTeacher1 = value; }
        }
        /// <summary>
        /// TestTeacher2
        /// Giảng viên coi thi 2
        /// </summary>
        public string TestTeacher2
        {
            get { return strTestTeacher2; }
            set { strTestTeacher2 = value; }
        }
        /// <summary>
        /// TestAtRoom
        /// Phòng thị lý thuyết
        /// </summary>
        public string TestAtRoom
        {
            get { return strTestAtRoom; }
            set { strTestAtRoom = value; }
        }
        /// <summary>
        /// TestAtRoom2
        /// 
        /// </summary>
        public string TestAtRoom2
        {
            get { return strTestAtRoom2; }
            set { strTestAtRoom2 = value; }
        }
        /// <summary>
        /// Days
        /// Xác định môn học lớp sắp vào những thứ nào, cách nhau dấu ;
        /// </summary>
        public string Days
        {
            get { return strDays; }
            set { strDays = value; }
        }
        /// <summary>
        /// ClassSubjectSession
        /// Buổi học: 0: bất kì theo buổi của lớp và môn, 1: Sáng, 2: Chiều, 3:Tối
        /// </summary>
        public int? ClassSubjectSession
        {
            get { return intClassSubjectSession; }
            set { intClassSubjectSession = value; }
        }
        /// <summary>
        /// DaysOfPractice
        /// Xác định môn học lớp sắp vào những thứ nào, cách nhau dấu ;
        /// </summary>
        public string DaysOfPractice
        {
            get { return strDaysOfPractice; }
            set { strDaysOfPractice = value; }
        }
        /// <summary>
        /// ClassSubjectSessionOfPractice
        /// Buổi học: 0: bất kì theo buổi của lớp và môn, 1: Sáng, 2: Chiều, 3:Tối
        /// </summary>
        public int? ClassSubjectSessionOfPractice
        {
            get { return intClassSubjectSessionOfPractice; }
            set { intClassSubjectSessionOfPractice = value; }
        }
        /// <summary>
        /// MarkRatio1
        /// Hệ số điểm 1
        /// </summary>
        public double? MarkRatio1
        {
            get { return dblMarkRatio1; }
            set { dblMarkRatio1 = value; }
        }
        /// <summary>
        /// MarkRatio2
        /// Hệ số điểm 2
        /// </summary>
        public double? MarkRatio2
        {
            get { return dblMarkRatio2; }
            set { dblMarkRatio2 = value; }
        }
        /// <summary>
        /// MarkRatio3
        /// Hệ số điểm
        /// </summary>
        public double? MarkRatio3
        {
            get { return dblMarkRatio3; }
            set { dblMarkRatio3 = value; }
        }
        /// <summary>
        /// MarkRatio4
        /// Hệ số điểm
        /// </summary>
        public double? MarkRatio4
        {
            get { return dblMarkRatio4; }
            set { dblMarkRatio4 = value; }
        }
        /// <summary>
        /// MarkRatio5
        /// Hệ số điểm
        /// </summary>
        public double? MarkRatio5
        {
            get { return dblMarkRatio5; }
            set { dblMarkRatio5 = value; }
        }
        /// <summary>
        /// Mark1Number
        /// Số cột điểm hs 1
        /// </summary>
        public int? Mark1Number
        {
            get { return intMark1Number; }
            set { intMark1Number = value; }
        }
        /// <summary>
        /// Mark2Number
        /// Số cột điểm hs 2
        /// </summary>
        public int? Mark2Number
        {
            get { return intMark2Number; }
            set { intMark2Number = value; }
        }
        /// <summary>
        /// TotalFee
        /// Tổng tiền học phí cho học phần này. Lấy từ chương trình khung
        /// </summary>
        public int? TotalFee
        {
            get { return intTotalFee; }
            set { intTotalFee = value; }
        }
        /// <summary>
        /// OrderIndex
        /// 
        /// </summary>
        public long? OrderIndex
        {
            get { return lngOrderIndex; }
            set { lngOrderIndex = value; }
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
        /// IsOldData
        /// Là dữ liệu cũ chuyển qua
        /// </summary>
        public bool IsOldData
        {
            get { return bolIsOldData; }
            set { bolIsOldData = value; }
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
        /// ModifiedBy
        /// Người sửa
        /// </summary>
        public string ModifiedBy
        {
            get { return strModifiedBy; }
            set { strModifiedBy = value; }
        }
        /// <summary>
        /// ModifiedAt
        /// Ngày sửa
        /// </summary>
        public DateTime? ModifiedAt
        {
            get { return dtmModifiedAt; }
            set { dtmModifiedAt = value; }
        }
        /// <summary>
        /// IsLockedMark
        /// Đã bị khóa, không cho nhập điểm quá trình
        /// </summary>
        public bool IsLockedMark
        {
            get { return bolIsLockedMark; }
            set { bolIsLockedMark = value; }
        }
        /// <summary>
        /// IsLockedExam1
        /// Đã bị khóa, không cho nhập điểm thi lần 1
        /// </summary>
        public bool IsLockedExam1
        {
            get { return bolIsLockedExam1; }
            set { bolIsLockedExam1 = value; }
        }
        /// <summary>
        /// TheoryQuantityOfTraining
        /// Số tiết lý thuyết (theo chương trình)
        /// </summary>
        public int? TheoryQuantityOfTraining
        {
            get { return intTheoryQuantityOfTraining; }
            set { intTheoryQuantityOfTraining = value; }
        }
        /// <summary>
        /// PracticeQuantityOfTraining
        /// Số tiết thực hành (theo chương trình)
        /// </summary>
        public int? PracticeQuantityOfTraining
        {
            get { return intPracticeQuantityOfTraining; }
            set { intPracticeQuantityOfTraining = value; }
        }
        /// <summary>
        /// TestQuantityOfTraining
        /// Số giờ kiểm tra (theo chương trình)
        /// </summary>
        public int? TestQuantityOfTraining
        {
            get { return intTestQuantityOfTraining; }
            set { intTestQuantityOfTraining = value; }
        }
        /// <summary>
        /// MethodTestID
        /// Hình thức thi của môn học lớp này
        /// </summary>
        public int? MethodTestID
        {
            get { return intMethodTestID; }
            set { intMethodTestID = value; }
        }
        /// <summary>
        /// IsContractTeaching
        /// Là dạy theo hợp đồng (sẽ không tính vào giờ giảng của gv biên chế = ko muốn vượt giờ định mức)
        /// </summary>
        public bool IsContractTeaching
        {
            get { return bolIsContractTeaching; }
            set { bolIsContractTeaching = value; }
        }
        /// <summary>
        /// IsContractTeachingOfPractice
        /// Là dạy theo hợp đồng (sẽ không tính vào giờ giảng của gv biên chế = ko muốn vượt giờ định mức) - Cho giờ thực hành
        /// </summary>
        public bool IsContractTeachingOfPractice
        {
            get { return bolIsContractTeachingOfPractice; }
            set { bolIsContractTeachingOfPractice = value; }
        }
        /// <summary>
        /// ReplaceTeacherID
        /// Mã gv dạy thay LT
        /// </summary>
        public string ReplaceTeacherID
        {
            get { return strReplaceTeacherID; }
            set { strReplaceTeacherID = value; }
        }
        /// <summary>
        /// ReplaceTeacherIDOfPractice
        /// Mã gv dạy thay thực hành
        /// </summary>
        public string ReplaceTeacherIDOfPractice
        {
            get { return strReplaceTeacherIDOfPractice; }
            set { strReplaceTeacherIDOfPractice = value; }
        }
        /// <summary>
        /// TeachingPrice
        /// Đơn giá LT
        /// </summary>
        public long? TeachingPrice
        {
            get { return lngTeachingPrice; }
            set { lngTeachingPrice = value; }
        }
        /// <summary>
        /// TeachingPriceForPractice
        /// Đơn giá TH
        /// </summary>
        public long? TeachingPriceForPractice
        {
            get { return lngTeachingPriceForPractice; }
            set { lngTeachingPriceForPractice = value; }
        }
        /// <summary>
        /// TheoryUnitText
        /// Số chỉ LT
        /// </summary>
        public int? TheoryUnitText
        {
            get { return intTheoryUnitText; }
            set { intTheoryUnitText = value; }
        }
        /// <summary>
        /// PracticeUnitText
        /// Số chỉ TH
        /// </summary>
        public int? PracticeUnitText
        {
            get { return intPracticeUnitText; }
            set { intPracticeUnitText = value; }
        }
        /// <summary>
        /// ClassSubjectSameID
        /// Nhóm môn học lớp tương đương
        /// </summary>
        public long? ClassSubjectSameID
        {
            get { return lngClassSubjectSameID; }
            set { lngClassSubjectSameID = value; }
        }
        /// <summary>
        /// ScheduleLockedToDate
        /// Khóa thời khóa biểu đến ngày? (từ ngày này trở về trước là bị khóa)
        /// </summary>
        public DateTime? ScheduleLockedToDate
        {
            get { return dtmScheduleLockedToDate; }
            set { dtmScheduleLockedToDate = value; }
        }
        /// <summary>
        /// TeachingByTheory
        /// GV dạy LT (nếu không chọn thì mặc định là TeachingBy). Khi chọn nhiều gv, cột này giờ ý nghĩa ko còn nhiều, tương lai bỏ luôn
        /// </summary>
        public string TeachingByTheory
        {
            get { return strTeachingByTheory; }
            set { strTeachingByTheory = value; }
        }
        /// <summary>
        /// TeachingByPractice
        /// GV dạy TH (nếu không chọn thì mặc định là TeachingBy). Khi chọn nhiều gv, cột này giờ ý nghĩa ko còn nhiều, tương lai bỏ luôn
        /// </summary>
        public string TeachingByPractice
        {
            get { return strTeachingByPractice; }
            set { strTeachingByPractice = value; }
        }
        /// <summary>
        /// MaxPercentOff
        /// % vắng tối đa xét dự thi
        /// </summary>
        public decimal? MaxPercentOff
        {
            get { return decMaxPercentOff; }
            set { decMaxPercentOff = value; }
        }
        /// <summary>
        /// MinTestAverage
        /// Điểm tb tối thiểu xét dự thi
        /// </summary>
        public decimal? MinTestAverage
        {
            get { return decMinTestAverage; }
            set { decMinTestAverage = value; }
        }
        /// <summary>
        /// IsLockedTeachingSchedule
        /// Khóa dữ liệu lịch trình giảng dạy
        /// </summary>
        public bool IsLockedTeachingSchedule
        {
            get { return bolIsLockedTeachingSchedule; }
            set { bolIsLockedTeachingSchedule = value; }
        }
        /// <summary>
        /// IsIgnoreTeachingTime
        /// Bỏ qua ko tính giờ dạy
        /// </summary>
        public bool IsIgnoreTeachingTime
        {
            get { return bolIsIgnoreTeachingTime; }
            set { bolIsIgnoreTeachingTime = value; }
        }
        /// <summary>
        /// MeetingLink
        /// ID cuộc họp (conference_id in google event). Link html cuộc họp
        /// </summary>
        public string MeetingLink
        {
            get { return strMeetingLink; }
            set { strMeetingLink = value; }
        }
        /// <summary>
        /// MeetingCode
        /// Code cuộc họp (meeting_code in google event). Lấy từ Event qua, để phân biệt lịch thường hay lịch có họp online
        /// </summary>
        public string MeetingCode
        {
            get { return strMeetingCode; }
            set { strMeetingCode = value; }
        }
        /// <summary>
        /// StartRegister
        /// Ngày giờ bắt đầu đăng ký
        /// </summary>
        public DateTime? StartRegister
        {
            get { return dtmStartRegister; }
            set { dtmStartRegister = value; }
        }
        /// <summary>
        /// FinishRegister
        /// Ngày giờ kết thúc đăng ký, sv ko thể đăng ký hay sửa (cố vấn học tập vẫn còn làm dc)
        /// </summary>
        public DateTime? FinishRegister
        {
            get { return dtmFinishRegister; }
            set { dtmFinishRegister = value; }
        }
        /// <summary>
        /// CommitRegister
        /// Ngày giờ khóa đăng ký, cố vấn học tập cũng ko thể sửa, xóa hay đăng ký thêm
        /// </summary>
        public DateTime? CommitRegister
        {
            get { return dtmCommitRegister; }
            set { dtmCommitRegister = value; }
        }
        /// <summary>
        /// MaxRegister
        /// Số lượng sv tối đa được đăng ký
        /// </summary>
        public int? MaxRegister
        {
            get { return intMaxRegister; }
            set { intMaxRegister = value; }
        }
        /// <summary>
        /// TeacherList
        /// Danh sách tên gv (tự động tạo theo SIM_Class_Subject_Teacher)
        /// </summary>
        public string TeacherList
        {
            get { return strTeacherList; }
            set { strTeacherList = value; }
        }
        /// <summary>
        /// RoomList
        /// Danh sách tên phòng LT (tự động tạo theo SIM_Class_Subject_Room)
        /// </summary>
        public string RoomList
        {
            get { return strRoomList; }
            set { strRoomList = value; }
        }
        /// <summary>
        /// TeacherNameList
        /// Danh sách tên gv (tự động tạo theo SIM_Class_Subject_Teacher)
        /// </summary>
        public string TeacherNameList
        {
            get { return strTeacherNameList; }
            set { strTeacherNameList = value; }
        }
        /// <summary>
        /// RoomNameList
        /// Danh sách tên phòng LT (tự động tạo theo SIM_Class_Subject_Room)
        /// </summary>
        public string RoomNameList
        {
            get { return strRoomNameList; }
            set { strRoomNameList = value; }
        }
        /// <summary>
        /// TeacherListTheory
        /// Danh sách tên gv (tự động tạo theo SIM_Class_Subject_Teacher)
        /// </summary>
        public string TeacherListTheory
        {
            get { return strTeacherListTheory; }
            set { strTeacherListTheory = value; }
        }
        /// <summary>
        /// RoomListTheory
        /// Danh sách tên phòng LT (tự động tạo theo SIM_Class_Subject_Room)
        /// </summary>
        public string RoomListTheory
        {
            get { return strRoomListTheory; }
            set { strRoomListTheory = value; }
        }
        /// <summary>
        /// TeacherNameListTheory
        /// Tách LT riêng (khi ko có thì mặc định là theo TeacherNameList), tương tự các phần TH cũng vậy
        /// </summary>
        public string TeacherNameListTheory
        {
            get { return strTeacherNameListTheory; }
            set { strTeacherNameListTheory = value; }
        }
        /// <summary>
        /// RoomNameListTheory
        /// Danh sách tên phòng LT (tự động tạo theo SIM_Class_Subject_Room)
        /// </summary>
        public string RoomNameListTheory
        {
            get { return strRoomNameListTheory; }
            set { strRoomNameListTheory = value; }
        }
        /// <summary>
        /// TeacherListPractice
        /// Danh sách tên gv (tự động tạo theo SIM_Class_Subject_Teacher)
        /// </summary>
        public string TeacherListPractice
        {
            get { return strTeacherListPractice; }
            set { strTeacherListPractice = value; }
        }
        /// <summary>
        /// RoomListPractice
        /// Danh sách tên phòng LT (tự động tạo theo SIM_Class_Subject_Room)
        /// </summary>
        public string RoomListPractice
        {
            get { return strRoomListPractice; }
            set { strRoomListPractice = value; }
        }
        /// <summary>
        /// TeacherNameListPractice
        /// Danh sách tên gv (tự động tạo theo SIM_Class_Subject_Teacher)
        /// </summary>
        public string TeacherNameListPractice
        {
            get { return strTeacherNameListPractice; }
            set { strTeacherNameListPractice = value; }
        }
        /// <summary>
        /// RoomNameListPractice
        /// Danh sách tên phòng LT (tự động tạo theo SIM_Class_Subject_Room)
        /// </summary>
        public string RoomNameListPractice
        {
            get { return strRoomNameListPractice; }
            set { strRoomNameListPractice = value; }
        }
        /// <summary>
        /// StartSetTeacher
        /// Ngày giờ bắt đầu cho phép phân công
        /// </summary>
        public DateTime? StartSetTeacher
        {
            get { return dtmStartSetTeacher; }
            set { dtmStartSetTeacher = value; }
        }
        /// <summary>
        /// FinishSetTeacher
        /// Ngày giờ kết thúc phân công
        /// </summary>
        public DateTime? FinishSetTeacher
        {
            get { return dtmFinishSetTeacher; }
            set { dtmFinishSetTeacher = value; }
        }
        /// <summary>
        /// TestSessionID1
        /// Mã ca thi 1 (kế hoạch thi)
        /// </summary>
        public int? TestSessionID1
        {
            get { return intTestSessionID1; }
            set { intTestSessionID1 = value; }
        }
        /// <summary>
        /// ID_dt_mon
        /// Mã chương trình đào tạo chi tiết (hệ thống cũ lưu)
        /// </summary>
        public int? ID_dt_mon
        {
            get { return intID_dt_mon; }
            set { intID_dt_mon = value; }
        }
        /// <summary>
        /// TestSessionID2
        /// Mã ca thi 2 (kế hoạch thi)
        /// </summary>
        public int? TestSessionID2
        {
            get { return intTestSessionID2; }
            set { intTestSessionID2 = value; }
        }
        /// <summary>
        /// TestSessionID3
        /// Mã ca thi  (kế hoạch thi)
        /// </summary>
        public int? TestSessionID3
        {
            get { return intTestSessionID3; }
            set { intTestSessionID3 = value; }
        }
        /// <summary>
        /// TestSessionID4
        /// Mã ca thi  (kế hoạch thi)
        /// </summary>
        public int? TestSessionID4
        {
            get { return intTestSessionID4; }
            set { intTestSessionID4 = value; }
        }
        /// <summary>
        /// TestSessionID5
        /// Mã ca thi  (kế hoạch thi)
        /// </summary>
        public int? TestSessionID5
        {
            get { return intTestSessionID5; }
            set { intTestSessionID5 = value; }
        }
        /// <summary>
        /// PlanRowCount
        /// Tổng số dòng kế hoạch (tách dòng trong kế hoạch tuần)
        /// </summary>
        public int? PlanRowCount
        {
            get { return intPlanRowCount; }
            set { intPlanRowCount = value; }
        }
        /// <summary>
        /// AllowScheduling
        /// Có cho sắp lịch
        /// </summary>
        public bool AllowScheduling
        {
            get { return bolAllowScheduling; }
            set { bolAllowScheduling = value; }
        }
        /// <summary>
        /// AllowTestScheduling
        /// Cho phép sắp lịch thi tự động
        /// </summary>
        public bool AllowTestScheduling
        {
            get { return bolAllowTestScheduling; }
            set { bolAllowTestScheduling = value; }
        }
        /// <summary>
        /// IsLockedWeekDetailPlan
        /// Khóa kế hoạch tuần
        /// </summary>
        public bool IsLockedWeekDetailPlan
        {
            get { return bolIsLockedWeekDetailPlan; }
            set { bolIsLockedWeekDetailPlan = value; }
        }
        /// <summary>
        /// TestScheduleLockedToDate
        /// Khóa lịch thi đến ngày? (từ ngày này trở về trước là bị khóa)
        /// </summary>
        public DateTime? TestScheduleLockedToDate
        {
            get { return dtmTestScheduleLockedToDate; }
            set { dtmTestScheduleLockedToDate = value; }
        }
        /// <summary>
        /// ScheduleCheckingExtendToDate
        /// Gia hạn sổ lên lớp đến ngày giờ (NSG có xài, TW3 chưa)
        /// </summary>
        public DateTime? ScheduleCheckingExtendToDate
        {
            get { return dtmScheduleCheckingExtendToDate; }
            set { dtmScheduleCheckingExtendToDate = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_ClassSubjectID.ToUpper()) && !Convert.IsDBNull(reader[C_ClassSubjectID])) this.lngClassSubjectID = Convert.ToInt64(reader[C_ClassSubjectID]);
                    if (reader.GetName(i).ToUpper().Equals(C_Semester.ToUpper()) && !Convert.IsDBNull(reader[C_Semester])) this.intSemester = Convert.ToInt32(reader[C_Semester]);
                    if (reader.GetName(i).ToUpper().Equals(C_YearID.ToUpper()) && !Convert.IsDBNull(reader[C_YearID])) this.intYearID = Convert.ToInt32(reader[C_YearID]);
                    if (reader.GetName(i).ToUpper().Equals(C_ClassID.ToUpper()) && !Convert.IsDBNull(reader[C_ClassID])) this.strClassID = Convert.ToString(reader[C_ClassID]);
                    if (reader.GetName(i).ToUpper().Equals(C_SubjectID.ToUpper()) && !Convert.IsDBNull(reader[C_SubjectID])) this.strSubjectID = Convert.ToString(reader[C_SubjectID]);
                    if (reader.GetName(i).ToUpper().Equals(C_TheoryQuantity.ToUpper()) && !Convert.IsDBNull(reader[C_TheoryQuantity])) this.intTheoryQuantity = Convert.ToInt32(reader[C_TheoryQuantity]);
                    if (reader.GetName(i).ToUpper().Equals(C_PracticeQuantity.ToUpper()) && !Convert.IsDBNull(reader[C_PracticeQuantity])) this.intPracticeQuantity = Convert.ToInt32(reader[C_PracticeQuantity]);
                    if (reader.GetName(i).ToUpper().Equals(C_TestQuantity.ToUpper()) && !Convert.IsDBNull(reader[C_TestQuantity])) this.intTestQuantity = Convert.ToInt32(reader[C_TestQuantity]);
                    if (reader.GetName(i).ToUpper().Equals(C_DoneQuantity.ToUpper()) && !Convert.IsDBNull(reader[C_DoneQuantity])) this.intDoneQuantity = Convert.ToInt32(reader[C_DoneQuantity]);
                    if (reader.GetName(i).ToUpper().Equals(C_UnitText.ToUpper()) && !Convert.IsDBNull(reader[C_UnitText])) this.intUnitText = Convert.ToInt32(reader[C_UnitText]);
                    if (reader.GetName(i).ToUpper().Equals(C_TeachingBy.ToUpper()) && !Convert.IsDBNull(reader[C_TeachingBy])) this.strTeachingBy = Convert.ToString(reader[C_TeachingBy]);
                    if (reader.GetName(i).ToUpper().Equals(C_TeachingAtRoom.ToUpper()) && !Convert.IsDBNull(reader[C_TeachingAtRoom])) this.strTeachingAtRoom = Convert.ToString(reader[C_TeachingAtRoom]);
                    if (reader.GetName(i).ToUpper().Equals(C_TeachingAtRoomPractice.ToUpper()) && !Convert.IsDBNull(reader[C_TeachingAtRoomPractice])) this.strTeachingAtRoomPractice = Convert.ToString(reader[C_TeachingAtRoomPractice]);
                    if (reader.GetName(i).ToUpper().Equals(C_ClassSubjectStatus.ToUpper()) && !Convert.IsDBNull(reader[C_ClassSubjectStatus])) this.intClassSubjectStatus = Convert.ToInt32(reader[C_ClassSubjectStatus]);
                    if (reader.GetName(i).ToUpper().Equals(C_ClassSubjectStatusType.ToUpper()) && !Convert.IsDBNull(reader[C_ClassSubjectStatusType])) this.intClassSubjectStatusType = Convert.ToInt32(reader[C_ClassSubjectStatusType]);
                    if (reader.GetName(i).ToUpper().Equals(C_BigClassID.ToUpper()) && !Convert.IsDBNull(reader[C_BigClassID])) this.strBigClassID = Convert.ToString(reader[C_BigClassID]);
                    if (reader.GetName(i).ToUpper().Equals(C_StartTestWeek.ToUpper()) && !Convert.IsDBNull(reader[C_StartTestWeek])) this.intStartTestWeek = Convert.ToInt32(reader[C_StartTestWeek]);
                    if (reader.GetName(i).ToUpper().Equals(C_FinishTestWeek.ToUpper()) && !Convert.IsDBNull(reader[C_FinishTestWeek])) this.intFinishTestWeek = Convert.ToInt32(reader[C_FinishTestWeek]);
                    if (reader.GetName(i).ToUpper().Equals(C_TestTeacher1.ToUpper()) && !Convert.IsDBNull(reader[C_TestTeacher1])) this.strTestTeacher1 = Convert.ToString(reader[C_TestTeacher1]);
                    if (reader.GetName(i).ToUpper().Equals(C_TestTeacher2.ToUpper()) && !Convert.IsDBNull(reader[C_TestTeacher2])) this.strTestTeacher2 = Convert.ToString(reader[C_TestTeacher2]);
                    if (reader.GetName(i).ToUpper().Equals(C_TestAtRoom.ToUpper()) && !Convert.IsDBNull(reader[C_TestAtRoom])) this.strTestAtRoom = Convert.ToString(reader[C_TestAtRoom]);
                    if (reader.GetName(i).ToUpper().Equals(C_TestAtRoom2.ToUpper()) && !Convert.IsDBNull(reader[C_TestAtRoom2])) this.strTestAtRoom2 = Convert.ToString(reader[C_TestAtRoom2]);
                    if (reader.GetName(i).ToUpper().Equals(C_Days.ToUpper()) && !Convert.IsDBNull(reader[C_Days])) this.strDays = Convert.ToString(reader[C_Days]);
                    if (reader.GetName(i).ToUpper().Equals(C_ClassSubjectSession.ToUpper()) && !Convert.IsDBNull(reader[C_ClassSubjectSession])) this.intClassSubjectSession = Convert.ToInt32(reader[C_ClassSubjectSession]);
                    if (reader.GetName(i).ToUpper().Equals(C_DaysOfPractice.ToUpper()) && !Convert.IsDBNull(reader[C_DaysOfPractice])) this.strDaysOfPractice = Convert.ToString(reader[C_DaysOfPractice]);
                    if (reader.GetName(i).ToUpper().Equals(C_ClassSubjectSessionOfPractice.ToUpper()) && !Convert.IsDBNull(reader[C_ClassSubjectSessionOfPractice])) this.intClassSubjectSessionOfPractice = Convert.ToInt32(reader[C_ClassSubjectSessionOfPractice]);
                    if (reader.GetName(i).ToUpper().Equals(C_MarkRatio1.ToUpper()) && !Convert.IsDBNull(reader[C_MarkRatio1])) this.dblMarkRatio1 = Convert.ToDouble(reader[C_MarkRatio1]);
                    if (reader.GetName(i).ToUpper().Equals(C_MarkRatio2.ToUpper()) && !Convert.IsDBNull(reader[C_MarkRatio2])) this.dblMarkRatio2 = Convert.ToDouble(reader[C_MarkRatio2]);
                    if (reader.GetName(i).ToUpper().Equals(C_MarkRatio3.ToUpper()) && !Convert.IsDBNull(reader[C_MarkRatio3])) this.dblMarkRatio3 = Convert.ToDouble(reader[C_MarkRatio3]);
                    if (reader.GetName(i).ToUpper().Equals(C_MarkRatio4.ToUpper()) && !Convert.IsDBNull(reader[C_MarkRatio4])) this.dblMarkRatio4 = Convert.ToDouble(reader[C_MarkRatio4]);
                    if (reader.GetName(i).ToUpper().Equals(C_MarkRatio5.ToUpper()) && !Convert.IsDBNull(reader[C_MarkRatio5])) this.dblMarkRatio5 = Convert.ToDouble(reader[C_MarkRatio5]);
                    if (reader.GetName(i).ToUpper().Equals(C_Mark1Number.ToUpper()) && !Convert.IsDBNull(reader[C_Mark1Number])) this.intMark1Number = Convert.ToInt32(reader[C_Mark1Number]);
                    if (reader.GetName(i).ToUpper().Equals(C_Mark2Number.ToUpper()) && !Convert.IsDBNull(reader[C_Mark2Number])) this.intMark2Number = Convert.ToInt32(reader[C_Mark2Number]);
                    if (reader.GetName(i).ToUpper().Equals(C_TotalFee.ToUpper()) && !Convert.IsDBNull(reader[C_TotalFee])) this.intTotalFee = Convert.ToInt32(reader[C_TotalFee]);
                    if (reader.GetName(i).ToUpper().Equals(C_OrderIndex.ToUpper()) && !Convert.IsDBNull(reader[C_OrderIndex])) this.lngOrderIndex = Convert.ToInt64(reader[C_OrderIndex]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsLocked.ToUpper()) && !Convert.IsDBNull(reader[C_IsLocked])) this.bolIsLocked = Convert.ToBoolean(reader[C_IsLocked]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsOldData.ToUpper()) && !Convert.IsDBNull(reader[C_IsOldData])) this.bolIsOldData = Convert.ToBoolean(reader[C_IsOldData]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedBy.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedBy])) this.strCreatedBy = Convert.ToString(reader[C_CreatedBy]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(reader[C_CreatedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_ModifiedBy.ToUpper()) && !Convert.IsDBNull(reader[C_ModifiedBy])) this.strModifiedBy = Convert.ToString(reader[C_ModifiedBy]);
                    if (reader.GetName(i).ToUpper().Equals(C_ModifiedAt.ToUpper()) && !Convert.IsDBNull(reader[C_ModifiedAt])) this.dtmModifiedAt = Convert.ToDateTime(reader[C_ModifiedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsLockedMark.ToUpper()) && !Convert.IsDBNull(reader[C_IsLockedMark])) this.bolIsLockedMark = Convert.ToBoolean(reader[C_IsLockedMark]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsLockedExam1.ToUpper()) && !Convert.IsDBNull(reader[C_IsLockedExam1])) this.bolIsLockedExam1 = Convert.ToBoolean(reader[C_IsLockedExam1]);
                    if (reader.GetName(i).ToUpper().Equals(C_TheoryQuantityOfTraining.ToUpper()) && !Convert.IsDBNull(reader[C_TheoryQuantityOfTraining])) this.intTheoryQuantityOfTraining = Convert.ToInt32(reader[C_TheoryQuantityOfTraining]);
                    if (reader.GetName(i).ToUpper().Equals(C_PracticeQuantityOfTraining.ToUpper()) && !Convert.IsDBNull(reader[C_PracticeQuantityOfTraining])) this.intPracticeQuantityOfTraining = Convert.ToInt32(reader[C_PracticeQuantityOfTraining]);
                    if (reader.GetName(i).ToUpper().Equals(C_TestQuantityOfTraining.ToUpper()) && !Convert.IsDBNull(reader[C_TestQuantityOfTraining])) this.intTestQuantityOfTraining = Convert.ToInt32(reader[C_TestQuantityOfTraining]);
                    if (reader.GetName(i).ToUpper().Equals(C_MethodTestID.ToUpper()) && !Convert.IsDBNull(reader[C_MethodTestID])) this.intMethodTestID = Convert.ToInt32(reader[C_MethodTestID]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsContractTeaching.ToUpper()) && !Convert.IsDBNull(reader[C_IsContractTeaching])) this.bolIsContractTeaching = Convert.ToBoolean(reader[C_IsContractTeaching]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsContractTeachingOfPractice.ToUpper()) && !Convert.IsDBNull(reader[C_IsContractTeachingOfPractice])) this.bolIsContractTeachingOfPractice = Convert.ToBoolean(reader[C_IsContractTeachingOfPractice]);
                    if (reader.GetName(i).ToUpper().Equals(C_ReplaceTeacherID.ToUpper()) && !Convert.IsDBNull(reader[C_ReplaceTeacherID])) this.strReplaceTeacherID = Convert.ToString(reader[C_ReplaceTeacherID]);
                    if (reader.GetName(i).ToUpper().Equals(C_ReplaceTeacherIDOfPractice.ToUpper()) && !Convert.IsDBNull(reader[C_ReplaceTeacherIDOfPractice])) this.strReplaceTeacherIDOfPractice = Convert.ToString(reader[C_ReplaceTeacherIDOfPractice]);
                    if (reader.GetName(i).ToUpper().Equals(C_TeachingPrice.ToUpper()) && !Convert.IsDBNull(reader[C_TeachingPrice])) this.lngTeachingPrice = Convert.ToInt64(reader[C_TeachingPrice]);
                    if (reader.GetName(i).ToUpper().Equals(C_TeachingPriceForPractice.ToUpper()) && !Convert.IsDBNull(reader[C_TeachingPriceForPractice])) this.lngTeachingPriceForPractice = Convert.ToInt64(reader[C_TeachingPriceForPractice]);
                    if (reader.GetName(i).ToUpper().Equals(C_TheoryUnitText.ToUpper()) && !Convert.IsDBNull(reader[C_TheoryUnitText])) this.intTheoryUnitText = Convert.ToInt32(reader[C_TheoryUnitText]);
                    if (reader.GetName(i).ToUpper().Equals(C_PracticeUnitText.ToUpper()) && !Convert.IsDBNull(reader[C_PracticeUnitText])) this.intPracticeUnitText = Convert.ToInt32(reader[C_PracticeUnitText]);
                    if (reader.GetName(i).ToUpper().Equals(C_ClassSubjectSameID.ToUpper()) && !Convert.IsDBNull(reader[C_ClassSubjectSameID])) this.lngClassSubjectSameID = Convert.ToInt64(reader[C_ClassSubjectSameID]);
                    if (reader.GetName(i).ToUpper().Equals(C_ScheduleLockedToDate.ToUpper()) && !Convert.IsDBNull(reader[C_ScheduleLockedToDate])) this.dtmScheduleLockedToDate = Convert.ToDateTime(reader[C_ScheduleLockedToDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_TeachingByTheory.ToUpper()) && !Convert.IsDBNull(reader[C_TeachingByTheory])) this.strTeachingByTheory = Convert.ToString(reader[C_TeachingByTheory]);
                    if (reader.GetName(i).ToUpper().Equals(C_TeachingByPractice.ToUpper()) && !Convert.IsDBNull(reader[C_TeachingByPractice])) this.strTeachingByPractice = Convert.ToString(reader[C_TeachingByPractice]);
                    if (reader.GetName(i).ToUpper().Equals(C_MaxPercentOff.ToUpper()) && !Convert.IsDBNull(reader[C_MaxPercentOff])) this.decMaxPercentOff = Convert.ToDecimal(reader[C_MaxPercentOff]);
                    if (reader.GetName(i).ToUpper().Equals(C_MinTestAverage.ToUpper()) && !Convert.IsDBNull(reader[C_MinTestAverage])) this.decMinTestAverage = Convert.ToDecimal(reader[C_MinTestAverage]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsLockedTeachingSchedule.ToUpper()) && !Convert.IsDBNull(reader[C_IsLockedTeachingSchedule])) this.bolIsLockedTeachingSchedule = Convert.ToBoolean(reader[C_IsLockedTeachingSchedule]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsIgnoreTeachingTime.ToUpper()) && !Convert.IsDBNull(reader[C_IsIgnoreTeachingTime])) this.bolIsIgnoreTeachingTime = Convert.ToBoolean(reader[C_IsIgnoreTeachingTime]);
                    if (reader.GetName(i).ToUpper().Equals(C_MeetingLink.ToUpper()) && !Convert.IsDBNull(reader[C_MeetingLink])) this.strMeetingLink = Convert.ToString(reader[C_MeetingLink]);
                    if (reader.GetName(i).ToUpper().Equals(C_MeetingCode.ToUpper()) && !Convert.IsDBNull(reader[C_MeetingCode])) this.strMeetingCode = Convert.ToString(reader[C_MeetingCode]);
                    if (reader.GetName(i).ToUpper().Equals(C_StartRegister.ToUpper()) && !Convert.IsDBNull(reader[C_StartRegister])) this.dtmStartRegister = Convert.ToDateTime(reader[C_StartRegister]);
                    if (reader.GetName(i).ToUpper().Equals(C_FinishRegister.ToUpper()) && !Convert.IsDBNull(reader[C_FinishRegister])) this.dtmFinishRegister = Convert.ToDateTime(reader[C_FinishRegister]);
                    if (reader.GetName(i).ToUpper().Equals(C_CommitRegister.ToUpper()) && !Convert.IsDBNull(reader[C_CommitRegister])) this.dtmCommitRegister = Convert.ToDateTime(reader[C_CommitRegister]);
                    if (reader.GetName(i).ToUpper().Equals(C_MaxRegister.ToUpper()) && !Convert.IsDBNull(reader[C_MaxRegister])) this.intMaxRegister = Convert.ToInt32(reader[C_MaxRegister]);
                    if (reader.GetName(i).ToUpper().Equals(C_TeacherList.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherList])) this.strTeacherList = Convert.ToString(reader[C_TeacherList]);
                    if (reader.GetName(i).ToUpper().Equals(C_RoomList.ToUpper()) && !Convert.IsDBNull(reader[C_RoomList])) this.strRoomList = Convert.ToString(reader[C_RoomList]);
                    if (reader.GetName(i).ToUpper().Equals(C_TeacherNameList.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherNameList])) this.strTeacherNameList = Convert.ToString(reader[C_TeacherNameList]);
                    if (reader.GetName(i).ToUpper().Equals(C_RoomNameList.ToUpper()) && !Convert.IsDBNull(reader[C_RoomNameList])) this.strRoomNameList = Convert.ToString(reader[C_RoomNameList]);
                    if (reader.GetName(i).ToUpper().Equals(C_TeacherListTheory.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherListTheory])) this.strTeacherListTheory = Convert.ToString(reader[C_TeacherListTheory]);
                    if (reader.GetName(i).ToUpper().Equals(C_RoomListTheory.ToUpper()) && !Convert.IsDBNull(reader[C_RoomListTheory])) this.strRoomListTheory = Convert.ToString(reader[C_RoomListTheory]);
                    if (reader.GetName(i).ToUpper().Equals(C_TeacherNameListTheory.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherNameListTheory])) this.strTeacherNameListTheory = Convert.ToString(reader[C_TeacherNameListTheory]);
                    if (reader.GetName(i).ToUpper().Equals(C_RoomNameListTheory.ToUpper()) && !Convert.IsDBNull(reader[C_RoomNameListTheory])) this.strRoomNameListTheory = Convert.ToString(reader[C_RoomNameListTheory]);
                    if (reader.GetName(i).ToUpper().Equals(C_TeacherListPractice.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherListPractice])) this.strTeacherListPractice = Convert.ToString(reader[C_TeacherListPractice]);
                    if (reader.GetName(i).ToUpper().Equals(C_RoomListPractice.ToUpper()) && !Convert.IsDBNull(reader[C_RoomListPractice])) this.strRoomListPractice = Convert.ToString(reader[C_RoomListPractice]);
                    if (reader.GetName(i).ToUpper().Equals(C_TeacherNameListPractice.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherNameListPractice])) this.strTeacherNameListPractice = Convert.ToString(reader[C_TeacherNameListPractice]);
                    if (reader.GetName(i).ToUpper().Equals(C_RoomNameListPractice.ToUpper()) && !Convert.IsDBNull(reader[C_RoomNameListPractice])) this.strRoomNameListPractice = Convert.ToString(reader[C_RoomNameListPractice]);
                    if (reader.GetName(i).ToUpper().Equals(C_StartSetTeacher.ToUpper()) && !Convert.IsDBNull(reader[C_StartSetTeacher])) this.dtmStartSetTeacher = Convert.ToDateTime(reader[C_StartSetTeacher]);
                    if (reader.GetName(i).ToUpper().Equals(C_FinishSetTeacher.ToUpper()) && !Convert.IsDBNull(reader[C_FinishSetTeacher])) this.dtmFinishSetTeacher = Convert.ToDateTime(reader[C_FinishSetTeacher]);
                    if (reader.GetName(i).ToUpper().Equals(C_TestSessionID1.ToUpper()) && !Convert.IsDBNull(reader[C_TestSessionID1])) this.intTestSessionID1 = Convert.ToInt32(reader[C_TestSessionID1]);
                    if (reader.GetName(i).ToUpper().Equals(C_ID_dt_mon.ToUpper()) && !Convert.IsDBNull(reader[C_ID_dt_mon])) this.intID_dt_mon = Convert.ToInt32(reader[C_ID_dt_mon]);
                    if (reader.GetName(i).ToUpper().Equals(C_TestSessionID2.ToUpper()) && !Convert.IsDBNull(reader[C_TestSessionID2])) this.intTestSessionID2 = Convert.ToInt32(reader[C_TestSessionID2]);
                    if (reader.GetName(i).ToUpper().Equals(C_TestSessionID3.ToUpper()) && !Convert.IsDBNull(reader[C_TestSessionID3])) this.intTestSessionID3 = Convert.ToInt32(reader[C_TestSessionID3]);
                    if (reader.GetName(i).ToUpper().Equals(C_TestSessionID4.ToUpper()) && !Convert.IsDBNull(reader[C_TestSessionID4])) this.intTestSessionID4 = Convert.ToInt32(reader[C_TestSessionID4]);
                    if (reader.GetName(i).ToUpper().Equals(C_TestSessionID5.ToUpper()) && !Convert.IsDBNull(reader[C_TestSessionID5])) this.intTestSessionID5 = Convert.ToInt32(reader[C_TestSessionID5]);
                    if (reader.GetName(i).ToUpper().Equals(C_PlanRowCount.ToUpper()) && !Convert.IsDBNull(reader[C_PlanRowCount])) this.intPlanRowCount = Convert.ToInt32(reader[C_PlanRowCount]);
                    if (reader.GetName(i).ToUpper().Equals(C_AllowScheduling.ToUpper()) && !Convert.IsDBNull(reader[C_AllowScheduling])) this.bolAllowScheduling = Convert.ToBoolean(reader[C_AllowScheduling]);
                    if (reader.GetName(i).ToUpper().Equals(C_AllowTestScheduling.ToUpper()) && !Convert.IsDBNull(reader[C_AllowTestScheduling])) this.bolAllowTestScheduling = Convert.ToBoolean(reader[C_AllowTestScheduling]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsLockedWeekDetailPlan.ToUpper()) && !Convert.IsDBNull(reader[C_IsLockedWeekDetailPlan])) this.bolIsLockedWeekDetailPlan = Convert.ToBoolean(reader[C_IsLockedWeekDetailPlan]);
                    if (reader.GetName(i).ToUpper().Equals(C_TestScheduleLockedToDate.ToUpper()) && !Convert.IsDBNull(reader[C_TestScheduleLockedToDate])) this.dtmTestScheduleLockedToDate = Convert.ToDateTime(reader[C_TestScheduleLockedToDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_ScheduleCheckingExtendToDate.ToUpper()) && !Convert.IsDBNull(reader[C_ScheduleCheckingExtendToDate])) this.dtmScheduleCheckingExtendToDate = Convert.ToDateTime(reader[C_ScheduleCheckingExtendToDate]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_Class_Subject", objEx);
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
                if (!Convert.IsDBNull(drw[C_ClassSubjectID])) this.lngClassSubjectID = Convert.ToInt64(drw[C_ClassSubjectID]);
                if (!Convert.IsDBNull(drw[C_Semester])) this.intSemester = Convert.ToInt32(drw[C_Semester]);
                if (!Convert.IsDBNull(drw[C_YearID])) this.intYearID = Convert.ToInt32(drw[C_YearID]);
                if (!Convert.IsDBNull(drw[C_ClassID])) this.strClassID = Convert.ToString(drw[C_ClassID]);
                if (!Convert.IsDBNull(drw[C_SubjectID])) this.strSubjectID = Convert.ToString(drw[C_SubjectID]);
                if (!Convert.IsDBNull(drw[C_TheoryQuantity])) this.intTheoryQuantity = Convert.ToInt32(drw[C_TheoryQuantity]);
                if (!Convert.IsDBNull(drw[C_PracticeQuantity])) this.intPracticeQuantity = Convert.ToInt32(drw[C_PracticeQuantity]);
                if (!Convert.IsDBNull(drw[C_TestQuantity])) this.intTestQuantity = Convert.ToInt32(drw[C_TestQuantity]);
                if (!Convert.IsDBNull(drw[C_DoneQuantity])) this.intDoneQuantity = Convert.ToInt32(drw[C_DoneQuantity]);
                if (!Convert.IsDBNull(drw[C_UnitText])) this.intUnitText = Convert.ToInt32(drw[C_UnitText]);
                if (!Convert.IsDBNull(drw[C_TeachingBy])) this.strTeachingBy = Convert.ToString(drw[C_TeachingBy]);
                if (!Convert.IsDBNull(drw[C_TeachingAtRoom])) this.strTeachingAtRoom = Convert.ToString(drw[C_TeachingAtRoom]);
                if (!Convert.IsDBNull(drw[C_TeachingAtRoomPractice])) this.strTeachingAtRoomPractice = Convert.ToString(drw[C_TeachingAtRoomPractice]);
                if (!Convert.IsDBNull(drw[C_ClassSubjectStatus])) this.intClassSubjectStatus = Convert.ToInt32(drw[C_ClassSubjectStatus]);
                if (!Convert.IsDBNull(drw[C_ClassSubjectStatusType])) this.intClassSubjectStatusType = Convert.ToInt32(drw[C_ClassSubjectStatusType]);
                if (!Convert.IsDBNull(drw[C_BigClassID])) this.strBigClassID = Convert.ToString(drw[C_BigClassID]);
                if (!Convert.IsDBNull(drw[C_StartTestWeek])) this.intStartTestWeek = Convert.ToInt32(drw[C_StartTestWeek]);
                if (!Convert.IsDBNull(drw[C_FinishTestWeek])) this.intFinishTestWeek = Convert.ToInt32(drw[C_FinishTestWeek]);
                if (!Convert.IsDBNull(drw[C_TestTeacher1])) this.strTestTeacher1 = Convert.ToString(drw[C_TestTeacher1]);
                if (!Convert.IsDBNull(drw[C_TestTeacher2])) this.strTestTeacher2 = Convert.ToString(drw[C_TestTeacher2]);
                if (!Convert.IsDBNull(drw[C_TestAtRoom])) this.strTestAtRoom = Convert.ToString(drw[C_TestAtRoom]);
                if (!Convert.IsDBNull(drw[C_TestAtRoom2])) this.strTestAtRoom2 = Convert.ToString(drw[C_TestAtRoom2]);
                if (!Convert.IsDBNull(drw[C_Days])) this.strDays = Convert.ToString(drw[C_Days]);
                if (!Convert.IsDBNull(drw[C_ClassSubjectSession])) this.intClassSubjectSession = Convert.ToInt32(drw[C_ClassSubjectSession]);
                if (!Convert.IsDBNull(drw[C_DaysOfPractice])) this.strDaysOfPractice = Convert.ToString(drw[C_DaysOfPractice]);
                if (!Convert.IsDBNull(drw[C_ClassSubjectSessionOfPractice])) this.intClassSubjectSessionOfPractice = Convert.ToInt32(drw[C_ClassSubjectSessionOfPractice]);
                if (!Convert.IsDBNull(drw[C_MarkRatio1])) this.dblMarkRatio1 = Convert.ToDouble(drw[C_MarkRatio1]);
                if (!Convert.IsDBNull(drw[C_MarkRatio2])) this.dblMarkRatio2 = Convert.ToDouble(drw[C_MarkRatio2]);
                if (!Convert.IsDBNull(drw[C_MarkRatio3])) this.dblMarkRatio3 = Convert.ToDouble(drw[C_MarkRatio3]);
                if (!Convert.IsDBNull(drw[C_MarkRatio4])) this.dblMarkRatio4 = Convert.ToDouble(drw[C_MarkRatio4]);
                if (!Convert.IsDBNull(drw[C_MarkRatio5])) this.dblMarkRatio5 = Convert.ToDouble(drw[C_MarkRatio5]);
                if (!Convert.IsDBNull(drw[C_Mark1Number])) this.intMark1Number = Convert.ToInt32(drw[C_Mark1Number]);
                if (!Convert.IsDBNull(drw[C_Mark2Number])) this.intMark2Number = Convert.ToInt32(drw[C_Mark2Number]);
                if (!Convert.IsDBNull(drw[C_TotalFee])) this.intTotalFee = Convert.ToInt32(drw[C_TotalFee]);
                if (!Convert.IsDBNull(drw[C_OrderIndex])) this.lngOrderIndex = Convert.ToInt64(drw[C_OrderIndex]);
                if (!Convert.IsDBNull(drw[C_IsLocked])) this.bolIsLocked = Convert.ToBoolean(drw[C_IsLocked]);
                if (!Convert.IsDBNull(drw[C_IsOldData])) this.bolIsOldData = Convert.ToBoolean(drw[C_IsOldData]);
                if (!Convert.IsDBNull(drw[C_CreatedBy])) this.strCreatedBy = Convert.ToString(drw[C_CreatedBy]);
                if (!Convert.IsDBNull(drw[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(drw[C_CreatedAt]);
                if (!Convert.IsDBNull(drw[C_ModifiedBy])) this.strModifiedBy = Convert.ToString(drw[C_ModifiedBy]);
                if (!Convert.IsDBNull(drw[C_ModifiedAt])) this.dtmModifiedAt = Convert.ToDateTime(drw[C_ModifiedAt]);
                if (!Convert.IsDBNull(drw[C_IsLockedMark])) this.bolIsLockedMark = Convert.ToBoolean(drw[C_IsLockedMark]);
                if (!Convert.IsDBNull(drw[C_IsLockedExam1])) this.bolIsLockedExam1 = Convert.ToBoolean(drw[C_IsLockedExam1]);
                if (!Convert.IsDBNull(drw[C_TheoryQuantityOfTraining])) this.intTheoryQuantityOfTraining = Convert.ToInt32(drw[C_TheoryQuantityOfTraining]);
                if (!Convert.IsDBNull(drw[C_PracticeQuantityOfTraining])) this.intPracticeQuantityOfTraining = Convert.ToInt32(drw[C_PracticeQuantityOfTraining]);
                if (!Convert.IsDBNull(drw[C_TestQuantityOfTraining])) this.intTestQuantityOfTraining = Convert.ToInt32(drw[C_TestQuantityOfTraining]);
                if (!Convert.IsDBNull(drw[C_MethodTestID])) this.intMethodTestID = Convert.ToInt32(drw[C_MethodTestID]);
                if (!Convert.IsDBNull(drw[C_IsContractTeaching])) this.bolIsContractTeaching = Convert.ToBoolean(drw[C_IsContractTeaching]);
                if (!Convert.IsDBNull(drw[C_IsContractTeachingOfPractice])) this.bolIsContractTeachingOfPractice = Convert.ToBoolean(drw[C_IsContractTeachingOfPractice]);
                if (!Convert.IsDBNull(drw[C_ReplaceTeacherID])) this.strReplaceTeacherID = Convert.ToString(drw[C_ReplaceTeacherID]);
                if (!Convert.IsDBNull(drw[C_ReplaceTeacherIDOfPractice])) this.strReplaceTeacherIDOfPractice = Convert.ToString(drw[C_ReplaceTeacherIDOfPractice]);
                if (!Convert.IsDBNull(drw[C_TeachingPrice])) this.lngTeachingPrice = Convert.ToInt64(drw[C_TeachingPrice]);
                if (!Convert.IsDBNull(drw[C_TeachingPriceForPractice])) this.lngTeachingPriceForPractice = Convert.ToInt64(drw[C_TeachingPriceForPractice]);
                if (!Convert.IsDBNull(drw[C_TheoryUnitText])) this.intTheoryUnitText = Convert.ToInt32(drw[C_TheoryUnitText]);
                if (!Convert.IsDBNull(drw[C_PracticeUnitText])) this.intPracticeUnitText = Convert.ToInt32(drw[C_PracticeUnitText]);
                if (!Convert.IsDBNull(drw[C_ClassSubjectSameID])) this.lngClassSubjectSameID = Convert.ToInt64(drw[C_ClassSubjectSameID]);
                if (!Convert.IsDBNull(drw[C_ScheduleLockedToDate])) this.dtmScheduleLockedToDate = Convert.ToDateTime(drw[C_ScheduleLockedToDate]);
                if (!Convert.IsDBNull(drw[C_TeachingByTheory])) this.strTeachingByTheory = Convert.ToString(drw[C_TeachingByTheory]);
                if (!Convert.IsDBNull(drw[C_TeachingByPractice])) this.strTeachingByPractice = Convert.ToString(drw[C_TeachingByPractice]);
                if (!Convert.IsDBNull(drw[C_MaxPercentOff])) this.decMaxPercentOff = Convert.ToDecimal(drw[C_MaxPercentOff]);
                if (!Convert.IsDBNull(drw[C_MinTestAverage])) this.decMinTestAverage = Convert.ToDecimal(drw[C_MinTestAverage]);
                if (!Convert.IsDBNull(drw[C_IsLockedTeachingSchedule])) this.bolIsLockedTeachingSchedule = Convert.ToBoolean(drw[C_IsLockedTeachingSchedule]);
                if (!Convert.IsDBNull(drw[C_IsIgnoreTeachingTime])) this.bolIsIgnoreTeachingTime = Convert.ToBoolean(drw[C_IsIgnoreTeachingTime]);
                if (!Convert.IsDBNull(drw[C_MeetingLink])) this.strMeetingLink = Convert.ToString(drw[C_MeetingLink]);
                if (!Convert.IsDBNull(drw[C_MeetingCode])) this.strMeetingCode = Convert.ToString(drw[C_MeetingCode]);
                if (!Convert.IsDBNull(drw[C_StartRegister])) this.dtmStartRegister = Convert.ToDateTime(drw[C_StartRegister]);
                if (!Convert.IsDBNull(drw[C_FinishRegister])) this.dtmFinishRegister = Convert.ToDateTime(drw[C_FinishRegister]);
                if (!Convert.IsDBNull(drw[C_CommitRegister])) this.dtmCommitRegister = Convert.ToDateTime(drw[C_CommitRegister]);
                if (!Convert.IsDBNull(drw[C_MaxRegister])) this.intMaxRegister = Convert.ToInt32(drw[C_MaxRegister]);
                if (!Convert.IsDBNull(drw[C_TeacherList])) this.strTeacherList = Convert.ToString(drw[C_TeacherList]);
                if (!Convert.IsDBNull(drw[C_RoomList])) this.strRoomList = Convert.ToString(drw[C_RoomList]);
                if (!Convert.IsDBNull(drw[C_TeacherNameList])) this.strTeacherNameList = Convert.ToString(drw[C_TeacherNameList]);
                if (!Convert.IsDBNull(drw[C_RoomNameList])) this.strRoomNameList = Convert.ToString(drw[C_RoomNameList]);
                if (!Convert.IsDBNull(drw[C_TeacherListTheory])) this.strTeacherListTheory = Convert.ToString(drw[C_TeacherListTheory]);
                if (!Convert.IsDBNull(drw[C_RoomListTheory])) this.strRoomListTheory = Convert.ToString(drw[C_RoomListTheory]);
                if (!Convert.IsDBNull(drw[C_TeacherNameListTheory])) this.strTeacherNameListTheory = Convert.ToString(drw[C_TeacherNameListTheory]);
                if (!Convert.IsDBNull(drw[C_RoomNameListTheory])) this.strRoomNameListTheory = Convert.ToString(drw[C_RoomNameListTheory]);
                if (!Convert.IsDBNull(drw[C_TeacherListPractice])) this.strTeacherListPractice = Convert.ToString(drw[C_TeacherListPractice]);
                if (!Convert.IsDBNull(drw[C_RoomListPractice])) this.strRoomListPractice = Convert.ToString(drw[C_RoomListPractice]);
                if (!Convert.IsDBNull(drw[C_TeacherNameListPractice])) this.strTeacherNameListPractice = Convert.ToString(drw[C_TeacherNameListPractice]);
                if (!Convert.IsDBNull(drw[C_RoomNameListPractice])) this.strRoomNameListPractice = Convert.ToString(drw[C_RoomNameListPractice]);
                if (!Convert.IsDBNull(drw[C_StartSetTeacher])) this.dtmStartSetTeacher = Convert.ToDateTime(drw[C_StartSetTeacher]);
                if (!Convert.IsDBNull(drw[C_FinishSetTeacher])) this.dtmFinishSetTeacher = Convert.ToDateTime(drw[C_FinishSetTeacher]);
                if (!Convert.IsDBNull(drw[C_TestSessionID1])) this.intTestSessionID1 = Convert.ToInt32(drw[C_TestSessionID1]);
                if (!Convert.IsDBNull(drw[C_ID_dt_mon])) this.intID_dt_mon = Convert.ToInt32(drw[C_ID_dt_mon]);
                if (!Convert.IsDBNull(drw[C_TestSessionID2])) this.intTestSessionID2 = Convert.ToInt32(drw[C_TestSessionID2]);
                if (!Convert.IsDBNull(drw[C_TestSessionID3])) this.intTestSessionID3 = Convert.ToInt32(drw[C_TestSessionID3]);
                if (!Convert.IsDBNull(drw[C_TestSessionID4])) this.intTestSessionID4 = Convert.ToInt32(drw[C_TestSessionID4]);
                if (!Convert.IsDBNull(drw[C_TestSessionID5])) this.intTestSessionID5 = Convert.ToInt32(drw[C_TestSessionID5]);
                if (!Convert.IsDBNull(drw[C_PlanRowCount])) this.intPlanRowCount = Convert.ToInt32(drw[C_PlanRowCount]);
                if (!Convert.IsDBNull(drw[C_AllowScheduling])) this.bolAllowScheduling = Convert.ToBoolean(drw[C_AllowScheduling]);
                if (!Convert.IsDBNull(drw[C_AllowTestScheduling])) this.bolAllowTestScheduling = Convert.ToBoolean(drw[C_AllowTestScheduling]);
                if (!Convert.IsDBNull(drw[C_IsLockedWeekDetailPlan])) this.bolIsLockedWeekDetailPlan = Convert.ToBoolean(drw[C_IsLockedWeekDetailPlan]);
                if (!Convert.IsDBNull(drw[C_TestScheduleLockedToDate])) this.dtmTestScheduleLockedToDate = Convert.ToDateTime(drw[C_TestScheduleLockedToDate]);
                if (!Convert.IsDBNull(drw[C_ScheduleCheckingExtendToDate])) this.dtmScheduleCheckingExtendToDate = Convert.ToDateTime(drw[C_ScheduleCheckingExtendToDate]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_Class_Subject", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        /// Nạp thông tin item 
        /// Store: SIM_Class_Subject_GET 
        ///</summary>
        /// <returns>true ? Có : False ? Không</returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Class_Subject_GET");
                objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_Class_Subject", objEx);
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
        /// Store: SIM_Class_Subject_GET 
        ///</summary>
        /// <returns> SIM_Class_Subject </returns>
        public SIM_Class_Subject Get(long? lngClassSubjectID)
        {
            SIM_Class_Subject obj = new SIM_Class_Subject();
            if (objIData != null)
                obj.IDB = objIData;
            obj.ClassSubjectID = lngClassSubjectID;
            if (obj.Get())
                return obj;
            this.objErrorException = obj.ErrorException;
            return null;
        }
        ///<summary>
        /// ExecNonQuery : SIM_Class_Subject
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Class_Subject", objEx);
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
        /// Search : SIM_Class_Subject
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Class_Subject", objEx);
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
        /// Search : SIM_Class_Subject
        /// Lấy hết dữ liệu
        /// Store: SIM_Class_Subject_GETALL 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable GetAll()
        {
            return GetDataTable("SIM_Class_Subject_GETALL");
        }

        ///<summary>
        /// Search : SIM_Class_Subject
        /// Tìm dữ liệu
        /// Store: SIM_Class_Subject_SEARCH 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable Search(params object[] pars)
        {
            return GetDataTable("SIM_Class_Subject_SEARCH", pars);
        }

        ///<summary>
        /// Add : SIM_Class_Subject
        /// Thêm dữ liệu
        /// Store: SIM_Class_Subject_ADD 
        ///</summary>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Class_Subject_ADD");
                objIData.AddParameter(P_Semester, this.intSemester);
                objIData.AddParameter(P_YearID, this.intYearID);
                objIData.AddParameter(P_ClassID, this.strClassID);
                objIData.AddParameter(P_SubjectID, this.strSubjectID);
                objIData.AddParameter(P_TheoryQuantity, this.intTheoryQuantity);
                objIData.AddParameter(P_PracticeQuantity, this.intPracticeQuantity);
                objIData.AddParameter(P_TestQuantity, this.intTestQuantity);
                objIData.AddParameter(P_DoneQuantity, this.intDoneQuantity);
                objIData.AddParameter(P_UnitText, this.intUnitText);
                objIData.AddParameter(P_TeachingBy, this.strTeachingBy);
                objIData.AddParameter(P_TeachingAtRoom, this.strTeachingAtRoom);
                objIData.AddParameter(P_TeachingAtRoomPractice, this.strTeachingAtRoomPractice);
                objIData.AddParameter(P_ClassSubjectStatus, this.intClassSubjectStatus);
                objIData.AddParameter(P_ClassSubjectStatusType, this.intClassSubjectStatusType);
                objIData.AddParameter(P_BigClassID, this.strBigClassID);
                objIData.AddParameter(P_StartTestWeek, this.intStartTestWeek);
                objIData.AddParameter(P_FinishTestWeek, this.intFinishTestWeek);
                objIData.AddParameter(P_TestTeacher1, this.strTestTeacher1);
                objIData.AddParameter(P_TestTeacher2, this.strTestTeacher2);
                objIData.AddParameter(P_TestAtRoom, this.strTestAtRoom);
                objIData.AddParameter(P_TestAtRoom2, this.strTestAtRoom2);
                objIData.AddParameter(P_Days, this.strDays);
                objIData.AddParameter(P_ClassSubjectSession, this.intClassSubjectSession);
                objIData.AddParameter(P_DaysOfPractice, this.strDaysOfPractice);
                objIData.AddParameter(P_ClassSubjectSessionOfPractice, this.intClassSubjectSessionOfPractice);
                objIData.AddParameter(P_MarkRatio1, this.dblMarkRatio1);
                objIData.AddParameter(P_MarkRatio2, this.dblMarkRatio2);
                objIData.AddParameter(P_MarkRatio3, this.dblMarkRatio3);
                objIData.AddParameter(P_MarkRatio4, this.dblMarkRatio4);
                objIData.AddParameter(P_MarkRatio5, this.dblMarkRatio5);
                objIData.AddParameter(P_Mark1Number, this.intMark1Number);
                objIData.AddParameter(P_Mark2Number, this.intMark2Number);
                objIData.AddParameter(P_TotalFee, this.intTotalFee);
                objIData.AddParameter(P_OrderIndex, this.lngOrderIndex);
                objIData.AddParameter(P_IsLocked, this.bolIsLocked);
                objIData.AddParameter(P_IsOldData, this.bolIsOldData);
                objIData.AddParameter(P_CreatedBy, this.strCreatedBy);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_ModifiedBy, this.strModifiedBy);
                objIData.AddParameter(P_ModifiedAt, this.dtmModifiedAt);
                objIData.AddParameter(P_IsLockedMark, this.bolIsLockedMark);
                objIData.AddParameter(P_IsLockedExam1, this.bolIsLockedExam1);
                objIData.AddParameter(P_TheoryQuantityOfTraining, this.intTheoryQuantityOfTraining);
                objIData.AddParameter(P_PracticeQuantityOfTraining, this.intPracticeQuantityOfTraining);
                objIData.AddParameter(P_TestQuantityOfTraining, this.intTestQuantityOfTraining);
                objIData.AddParameter(P_MethodTestID, this.intMethodTestID);
                objIData.AddParameter(P_IsContractTeaching, this.bolIsContractTeaching);
                objIData.AddParameter(P_IsContractTeachingOfPractice, this.bolIsContractTeachingOfPractice);
                objIData.AddParameter(P_ReplaceTeacherID, this.strReplaceTeacherID);
                objIData.AddParameter(P_ReplaceTeacherIDOfPractice, this.strReplaceTeacherIDOfPractice);
                objIData.AddParameter(P_TeachingPrice, this.lngTeachingPrice);
                objIData.AddParameter(P_TeachingPriceForPractice, this.lngTeachingPriceForPractice);
                objIData.AddParameter(P_TheoryUnitText, this.intTheoryUnitText);
                objIData.AddParameter(P_PracticeUnitText, this.intPracticeUnitText);
                objIData.AddParameter(P_ClassSubjectSameID, this.lngClassSubjectSameID);
                objIData.AddParameter(P_ScheduleLockedToDate, this.dtmScheduleLockedToDate);
                objIData.AddParameter(P_TeachingByTheory, this.strTeachingByTheory);
                objIData.AddParameter(P_TeachingByPractice, this.strTeachingByPractice);
                objIData.AddParameter(P_MaxPercentOff, this.decMaxPercentOff);
                objIData.AddParameter(P_MinTestAverage, this.decMinTestAverage);
                objIData.AddParameter(P_IsLockedTeachingSchedule, this.bolIsLockedTeachingSchedule);
                objIData.AddParameter(P_IsIgnoreTeachingTime, this.bolIsIgnoreTeachingTime);
                objIData.AddParameter(P_MeetingLink, this.strMeetingLink);
                objIData.AddParameter(P_MeetingCode, this.strMeetingCode);
                objIData.AddParameter(P_StartRegister, this.dtmStartRegister);
                objIData.AddParameter(P_FinishRegister, this.dtmFinishRegister);
                objIData.AddParameter(P_CommitRegister, this.dtmCommitRegister);
                objIData.AddParameter(P_MaxRegister, this.intMaxRegister);
                objIData.AddParameter(P_TeacherList, this.strTeacherList);
                objIData.AddParameter(P_RoomList, this.strRoomList);
                objIData.AddParameter(P_TeacherNameList, this.strTeacherNameList);
                objIData.AddParameter(P_RoomNameList, this.strRoomNameList);
                objIData.AddParameter(P_TeacherListTheory, this.strTeacherListTheory);
                objIData.AddParameter(P_RoomListTheory, this.strRoomListTheory);
                objIData.AddParameter(P_TeacherNameListTheory, this.strTeacherNameListTheory);
                objIData.AddParameter(P_RoomNameListTheory, this.strRoomNameListTheory);
                objIData.AddParameter(P_TeacherListPractice, this.strTeacherListPractice);
                objIData.AddParameter(P_RoomListPractice, this.strRoomListPractice);
                objIData.AddParameter(P_TeacherNameListPractice, this.strTeacherNameListPractice);
                objIData.AddParameter(P_RoomNameListPractice, this.strRoomNameListPractice);
                objIData.AddParameter(P_StartSetTeacher, this.dtmStartSetTeacher);
                objIData.AddParameter(P_FinishSetTeacher, this.dtmFinishSetTeacher);
                objIData.AddParameter(P_TestSessionID1, this.intTestSessionID1);
                objIData.AddParameter(P_ID_dt_mon, this.intID_dt_mon);
                objIData.AddParameter(P_TestSessionID2, this.intTestSessionID2);
                objIData.AddParameter(P_TestSessionID3, this.intTestSessionID3);
                objIData.AddParameter(P_TestSessionID4, this.intTestSessionID4);
                objIData.AddParameter(P_TestSessionID5, this.intTestSessionID5);
                objIData.AddParameter(P_PlanRowCount, this.intPlanRowCount);
                objIData.AddParameter(P_AllowScheduling, this.bolAllowScheduling);
                objIData.AddParameter(P_AllowTestScheduling, this.bolAllowTestScheduling);
                objIData.AddParameter(P_IsLockedWeekDetailPlan, this.bolIsLockedWeekDetailPlan);
                objIData.AddParameter(P_TestScheduleLockedToDate, this.dtmTestScheduleLockedToDate);
                objIData.AddParameter(P_ScheduleCheckingExtendToDate, this.dtmScheduleCheckingExtendToDate);
                this.lngClassSubjectID = Convert.ToInt64(objIData.ExecStoreToString());
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_Class_Subject", objEx);
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
        /// Update : SIM_Class_Subject
        /// Cập nhật dữ liệu
        /// Store: SIM_Class_Subject_EDIT 
        ///</summary>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Class_Subject_EDIT");
                objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
                objIData.AddParameter(P_Semester, this.intSemester);
                objIData.AddParameter(P_YearID, this.intYearID);
                objIData.AddParameter(P_ClassID, this.strClassID);
                objIData.AddParameter(P_SubjectID, this.strSubjectID);
                objIData.AddParameter(P_TheoryQuantity, this.intTheoryQuantity);
                objIData.AddParameter(P_PracticeQuantity, this.intPracticeQuantity);
                objIData.AddParameter(P_TestQuantity, this.intTestQuantity);
                objIData.AddParameter(P_DoneQuantity, this.intDoneQuantity);
                objIData.AddParameter(P_UnitText, this.intUnitText);
                objIData.AddParameter(P_TeachingBy, this.strTeachingBy);
                objIData.AddParameter(P_TeachingAtRoom, this.strTeachingAtRoom);
                objIData.AddParameter(P_TeachingAtRoomPractice, this.strTeachingAtRoomPractice);
                objIData.AddParameter(P_ClassSubjectStatus, this.intClassSubjectStatus);
                objIData.AddParameter(P_ClassSubjectStatusType, this.intClassSubjectStatusType);
                objIData.AddParameter(P_BigClassID, this.strBigClassID);
                objIData.AddParameter(P_StartTestWeek, this.intStartTestWeek);
                objIData.AddParameter(P_FinishTestWeek, this.intFinishTestWeek);
                objIData.AddParameter(P_TestTeacher1, this.strTestTeacher1);
                objIData.AddParameter(P_TestTeacher2, this.strTestTeacher2);
                objIData.AddParameter(P_TestAtRoom, this.strTestAtRoom);
                objIData.AddParameter(P_TestAtRoom2, this.strTestAtRoom2);
                objIData.AddParameter(P_Days, this.strDays);
                objIData.AddParameter(P_ClassSubjectSession, this.intClassSubjectSession);
                objIData.AddParameter(P_DaysOfPractice, this.strDaysOfPractice);
                objIData.AddParameter(P_ClassSubjectSessionOfPractice, this.intClassSubjectSessionOfPractice);
                objIData.AddParameter(P_MarkRatio1, this.dblMarkRatio1);
                objIData.AddParameter(P_MarkRatio2, this.dblMarkRatio2);
                objIData.AddParameter(P_MarkRatio3, this.dblMarkRatio3);
                objIData.AddParameter(P_MarkRatio4, this.dblMarkRatio4);
                objIData.AddParameter(P_MarkRatio5, this.dblMarkRatio5);
                objIData.AddParameter(P_Mark1Number, this.intMark1Number);
                objIData.AddParameter(P_Mark2Number, this.intMark2Number);
                objIData.AddParameter(P_TotalFee, this.intTotalFee);
                objIData.AddParameter(P_OrderIndex, this.lngOrderIndex);
                objIData.AddParameter(P_IsLocked, this.bolIsLocked);
                objIData.AddParameter(P_IsOldData, this.bolIsOldData);
                objIData.AddParameter(P_CreatedBy, this.strCreatedBy);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_ModifiedBy, this.strModifiedBy);
                objIData.AddParameter(P_ModifiedAt, this.dtmModifiedAt);
                objIData.AddParameter(P_IsLockedMark, this.bolIsLockedMark);
                objIData.AddParameter(P_IsLockedExam1, this.bolIsLockedExam1);
                objIData.AddParameter(P_TheoryQuantityOfTraining, this.intTheoryQuantityOfTraining);
                objIData.AddParameter(P_PracticeQuantityOfTraining, this.intPracticeQuantityOfTraining);
                objIData.AddParameter(P_TestQuantityOfTraining, this.intTestQuantityOfTraining);
                objIData.AddParameter(P_MethodTestID, this.intMethodTestID);
                objIData.AddParameter(P_IsContractTeaching, this.bolIsContractTeaching);
                objIData.AddParameter(P_IsContractTeachingOfPractice, this.bolIsContractTeachingOfPractice);
                objIData.AddParameter(P_ReplaceTeacherID, this.strReplaceTeacherID);
                objIData.AddParameter(P_ReplaceTeacherIDOfPractice, this.strReplaceTeacherIDOfPractice);
                objIData.AddParameter(P_TeachingPrice, this.lngTeachingPrice);
                objIData.AddParameter(P_TeachingPriceForPractice, this.lngTeachingPriceForPractice);
                objIData.AddParameter(P_TheoryUnitText, this.intTheoryUnitText);
                objIData.AddParameter(P_PracticeUnitText, this.intPracticeUnitText);
                objIData.AddParameter(P_ClassSubjectSameID, this.lngClassSubjectSameID);
                objIData.AddParameter(P_ScheduleLockedToDate, this.dtmScheduleLockedToDate);
                objIData.AddParameter(P_TeachingByTheory, this.strTeachingByTheory);
                objIData.AddParameter(P_TeachingByPractice, this.strTeachingByPractice);
                objIData.AddParameter(P_MaxPercentOff, this.decMaxPercentOff);
                objIData.AddParameter(P_MinTestAverage, this.decMinTestAverage);
                objIData.AddParameter(P_IsLockedTeachingSchedule, this.bolIsLockedTeachingSchedule);
                objIData.AddParameter(P_IsIgnoreTeachingTime, this.bolIsIgnoreTeachingTime);
                objIData.AddParameter(P_MeetingLink, this.strMeetingLink);
                objIData.AddParameter(P_MeetingCode, this.strMeetingCode);
                objIData.AddParameter(P_StartRegister, this.dtmStartRegister);
                objIData.AddParameter(P_FinishRegister, this.dtmFinishRegister);
                objIData.AddParameter(P_CommitRegister, this.dtmCommitRegister);
                objIData.AddParameter(P_MaxRegister, this.intMaxRegister);
                objIData.AddParameter(P_TeacherList, this.strTeacherList);
                objIData.AddParameter(P_RoomList, this.strRoomList);
                objIData.AddParameter(P_TeacherNameList, this.strTeacherNameList);
                objIData.AddParameter(P_RoomNameList, this.strRoomNameList);
                objIData.AddParameter(P_TeacherListTheory, this.strTeacherListTheory);
                objIData.AddParameter(P_RoomListTheory, this.strRoomListTheory);
                objIData.AddParameter(P_TeacherNameListTheory, this.strTeacherNameListTheory);
                objIData.AddParameter(P_RoomNameListTheory, this.strRoomNameListTheory);
                objIData.AddParameter(P_TeacherListPractice, this.strTeacherListPractice);
                objIData.AddParameter(P_RoomListPractice, this.strRoomListPractice);
                objIData.AddParameter(P_TeacherNameListPractice, this.strTeacherNameListPractice);
                objIData.AddParameter(P_RoomNameListPractice, this.strRoomNameListPractice);
                objIData.AddParameter(P_StartSetTeacher, this.dtmStartSetTeacher);
                objIData.AddParameter(P_FinishSetTeacher, this.dtmFinishSetTeacher);
                objIData.AddParameter(P_TestSessionID1, this.intTestSessionID1);
                objIData.AddParameter(P_ID_dt_mon, this.intID_dt_mon);
                objIData.AddParameter(P_TestSessionID2, this.intTestSessionID2);
                objIData.AddParameter(P_TestSessionID3, this.intTestSessionID3);
                objIData.AddParameter(P_TestSessionID4, this.intTestSessionID4);
                objIData.AddParameter(P_TestSessionID5, this.intTestSessionID5);
                objIData.AddParameter(P_PlanRowCount, this.intPlanRowCount);
                objIData.AddParameter(P_AllowScheduling, this.bolAllowScheduling);
                objIData.AddParameter(P_AllowTestScheduling, this.bolAllowTestScheduling);
                objIData.AddParameter(P_IsLockedWeekDetailPlan, this.bolIsLockedWeekDetailPlan);
                objIData.AddParameter(P_TestScheduleLockedToDate, this.dtmTestScheduleLockedToDate);
                objIData.AddParameter(P_ScheduleCheckingExtendToDate, this.dtmScheduleCheckingExtendToDate);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_Class_Subject", objEx);
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
        /// Delete : SIM_Class_Subject
        /// Xóa dữ liệu
        /// Store: SIM_Class_Subject_DELETE 
        ///</summary>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Class_Subject_DELETE");
                objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_Class_Subject", objEx);
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
        /// Store: SIM_Class_Subject_DELETE 
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long? lngClassSubjectID)
        {
            this.lngClassSubjectID = lngClassSubjectID;
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

        public SIM_Class_Subject()
        {
        }
        public SIM_Class_Subject(long? lngClassSubjectID)
        {
            this.lngClassSubjectID = lngClassSubjectID;
            this.Get();
        }

        #endregion

        #region Variable Static

        #region Parameter Names

        public const String P_ClassSubjectID = "@" + C_ClassSubjectID;
        public const String P_Semester = "@" + C_Semester;
        public const String P_YearID = "@" + C_YearID;
        public const String P_ClassID = "@" + C_ClassID;
        public const String P_SubjectID = "@" + C_SubjectID;
        public const String P_TheoryQuantity = "@" + C_TheoryQuantity;
        public const String P_PracticeQuantity = "@" + C_PracticeQuantity;
        public const String P_TestQuantity = "@" + C_TestQuantity;
        public const String P_DoneQuantity = "@" + C_DoneQuantity;
        public const String P_UnitText = "@" + C_UnitText;
        public const String P_TeachingBy = "@" + C_TeachingBy;
        public const String P_TeachingAtRoom = "@" + C_TeachingAtRoom;
        public const String P_TeachingAtRoomPractice = "@" + C_TeachingAtRoomPractice;
        public const String P_ClassSubjectStatus = "@" + C_ClassSubjectStatus;
        public const String P_ClassSubjectStatusType = "@" + C_ClassSubjectStatusType;
        public const String P_BigClassID = "@" + C_BigClassID;
        public const String P_StartTestWeek = "@" + C_StartTestWeek;
        public const String P_FinishTestWeek = "@" + C_FinishTestWeek;
        public const String P_TestTeacher1 = "@" + C_TestTeacher1;
        public const String P_TestTeacher2 = "@" + C_TestTeacher2;
        public const String P_TestAtRoom = "@" + C_TestAtRoom;
        public const String P_TestAtRoom2 = "@" + C_TestAtRoom2;
        public const String P_Days = "@" + C_Days;
        public const String P_ClassSubjectSession = "@" + C_ClassSubjectSession;
        public const String P_DaysOfPractice = "@" + C_DaysOfPractice;
        public const String P_ClassSubjectSessionOfPractice = "@" + C_ClassSubjectSessionOfPractice;
        public const String P_MarkRatio1 = "@" + C_MarkRatio1;
        public const String P_MarkRatio2 = "@" + C_MarkRatio2;
        public const String P_MarkRatio3 = "@" + C_MarkRatio3;
        public const String P_MarkRatio4 = "@" + C_MarkRatio4;
        public const String P_MarkRatio5 = "@" + C_MarkRatio5;
        public const String P_Mark1Number = "@" + C_Mark1Number;
        public const String P_Mark2Number = "@" + C_Mark2Number;
        public const String P_TotalFee = "@" + C_TotalFee;
        public const String P_OrderIndex = "@" + C_OrderIndex;
        public const String P_IsLocked = "@" + C_IsLocked;
        public const String P_IsOldData = "@" + C_IsOldData;
        public const String P_CreatedBy = "@" + C_CreatedBy;
        public const String P_CreatedAt = "@" + C_CreatedAt;
        public const String P_ModifiedBy = "@" + C_ModifiedBy;
        public const String P_ModifiedAt = "@" + C_ModifiedAt;
        public const String P_IsLockedMark = "@" + C_IsLockedMark;
        public const String P_IsLockedExam1 = "@" + C_IsLockedExam1;
        public const String P_TheoryQuantityOfTraining = "@" + C_TheoryQuantityOfTraining;
        public const String P_PracticeQuantityOfTraining = "@" + C_PracticeQuantityOfTraining;
        public const String P_TestQuantityOfTraining = "@" + C_TestQuantityOfTraining;
        public const String P_MethodTestID = "@" + C_MethodTestID;
        public const String P_IsContractTeaching = "@" + C_IsContractTeaching;
        public const String P_IsContractTeachingOfPractice = "@" + C_IsContractTeachingOfPractice;
        public const String P_ReplaceTeacherID = "@" + C_ReplaceTeacherID;
        public const String P_ReplaceTeacherIDOfPractice = "@" + C_ReplaceTeacherIDOfPractice;
        public const String P_TeachingPrice = "@" + C_TeachingPrice;
        public const String P_TeachingPriceForPractice = "@" + C_TeachingPriceForPractice;
        public const String P_TheoryUnitText = "@" + C_TheoryUnitText;
        public const String P_PracticeUnitText = "@" + C_PracticeUnitText;
        public const String P_ClassSubjectSameID = "@" + C_ClassSubjectSameID;
        public const String P_ScheduleLockedToDate = "@" + C_ScheduleLockedToDate;
        public const String P_TeachingByTheory = "@" + C_TeachingByTheory;
        public const String P_TeachingByPractice = "@" + C_TeachingByPractice;
        public const String P_MaxPercentOff = "@" + C_MaxPercentOff;
        public const String P_MinTestAverage = "@" + C_MinTestAverage;
        public const String P_IsLockedTeachingSchedule = "@" + C_IsLockedTeachingSchedule;
        public const String P_IsIgnoreTeachingTime = "@" + C_IsIgnoreTeachingTime;
        public const String P_MeetingLink = "@" + C_MeetingLink;
        public const String P_MeetingCode = "@" + C_MeetingCode;
        public const String P_StartRegister = "@" + C_StartRegister;
        public const String P_FinishRegister = "@" + C_FinishRegister;
        public const String P_CommitRegister = "@" + C_CommitRegister;
        public const String P_MaxRegister = "@" + C_MaxRegister;
        public const String P_TeacherList = "@" + C_TeacherList;
        public const String P_RoomList = "@" + C_RoomList;
        public const String P_TeacherNameList = "@" + C_TeacherNameList;
        public const String P_RoomNameList = "@" + C_RoomNameList;
        public const String P_TeacherListTheory = "@" + C_TeacherListTheory;
        public const String P_RoomListTheory = "@" + C_RoomListTheory;
        public const String P_TeacherNameListTheory = "@" + C_TeacherNameListTheory;
        public const String P_RoomNameListTheory = "@" + C_RoomNameListTheory;
        public const String P_TeacherListPractice = "@" + C_TeacherListPractice;
        public const String P_RoomListPractice = "@" + C_RoomListPractice;
        public const String P_TeacherNameListPractice = "@" + C_TeacherNameListPractice;
        public const String P_RoomNameListPractice = "@" + C_RoomNameListPractice;
        public const String P_StartSetTeacher = "@" + C_StartSetTeacher;
        public const String P_FinishSetTeacher = "@" + C_FinishSetTeacher;
        public const String P_TestSessionID1 = "@" + C_TestSessionID1;
        public const String P_ID_dt_mon = "@" + C_ID_dt_mon;
        public const String P_TestSessionID2 = "@" + C_TestSessionID2;
        public const String P_TestSessionID3 = "@" + C_TestSessionID3;
        public const String P_TestSessionID4 = "@" + C_TestSessionID4;
        public const String P_TestSessionID5 = "@" + C_TestSessionID5;
        public const String P_PlanRowCount = "@" + C_PlanRowCount;
        public const String P_AllowScheduling = "@" + C_AllowScheduling;
        public const String P_AllowTestScheduling = "@" + C_AllowTestScheduling;
        public const String P_IsLockedWeekDetailPlan = "@" + C_IsLockedWeekDetailPlan;
        public const String P_TestScheduleLockedToDate = "@" + C_TestScheduleLockedToDate;
        public const String P_ScheduleCheckingExtendToDate = "@" + C_ScheduleCheckingExtendToDate;

        #endregion //Parameter names

        #region Column Names

        public const String C_ClassSubjectID = "ClassSubjectID";
        public const String C_Semester = "Semester";
        public const String C_YearID = "YearID";
        public const String C_ClassID = "ClassID";
        public const String C_SubjectID = "SubjectID";
        public const String C_TheoryQuantity = "TheoryQuantity";
        public const String C_PracticeQuantity = "PracticeQuantity";
        public const String C_TestQuantity = "TestQuantity";
        public const String C_DoneQuantity = "DoneQuantity";
        public const String C_UnitText = "UnitText";
        public const String C_TeachingBy = "TeachingBy";
        public const String C_TeachingAtRoom = "TeachingAtRoom";
        public const String C_TeachingAtRoomPractice = "TeachingAtRoomPractice";
        public const String C_ClassSubjectStatus = "ClassSubjectStatus";
        public const String C_ClassSubjectStatusType = "ClassSubjectStatusType";
        public const String C_BigClassID = "BigClassID";
        public const String C_StartTestWeek = "StartTestWeek";
        public const String C_FinishTestWeek = "FinishTestWeek";
        public const String C_TestTeacher1 = "TestTeacher1";
        public const String C_TestTeacher2 = "TestTeacher2";
        public const String C_TestAtRoom = "TestAtRoom";
        public const String C_TestAtRoom2 = "TestAtRoom2";
        public const String C_Days = "Days";
        public const String C_ClassSubjectSession = "ClassSubjectSession";
        public const String C_DaysOfPractice = "DaysOfPractice";
        public const String C_ClassSubjectSessionOfPractice = "ClassSubjectSessionOfPractice";
        public const String C_MarkRatio1 = "MarkRatio1";
        public const String C_MarkRatio2 = "MarkRatio2";
        public const String C_MarkRatio3 = "MarkRatio3";
        public const String C_MarkRatio4 = "MarkRatio4";
        public const String C_MarkRatio5 = "MarkRatio5";
        public const String C_Mark1Number = "Mark1Number";
        public const String C_Mark2Number = "Mark2Number";
        public const String C_TotalFee = "TotalFee";
        public const String C_OrderIndex = "OrderIndex";
        public const String C_IsLocked = "IsLocked";
        public const String C_IsOldData = "IsOldData";
        public const String C_CreatedBy = "CreatedBy";
        public const String C_CreatedAt = "CreatedAt";
        public const String C_ModifiedBy = "ModifiedBy";
        public const String C_ModifiedAt = "ModifiedAt";
        public const String C_IsLockedMark = "IsLockedMark";
        public const String C_IsLockedExam1 = "IsLockedExam1";
        public const String C_TheoryQuantityOfTraining = "TheoryQuantityOfTraining";
        public const String C_PracticeQuantityOfTraining = "PracticeQuantityOfTraining";
        public const String C_TestQuantityOfTraining = "TestQuantityOfTraining";
        public const String C_MethodTestID = "MethodTestID";
        public const String C_IsContractTeaching = "IsContractTeaching";
        public const String C_IsContractTeachingOfPractice = "IsContractTeachingOfPractice";
        public const String C_ReplaceTeacherID = "ReplaceTeacherID";
        public const String C_ReplaceTeacherIDOfPractice = "ReplaceTeacherIDOfPractice";
        public const String C_TeachingPrice = "TeachingPrice";
        public const String C_TeachingPriceForPractice = "TeachingPriceForPractice";
        public const String C_TheoryUnitText = "TheoryUnitText";
        public const String C_PracticeUnitText = "PracticeUnitText";
        public const String C_ClassSubjectSameID = "ClassSubjectSameID";
        public const String C_ScheduleLockedToDate = "ScheduleLockedToDate";
        public const String C_TeachingByTheory = "TeachingByTheory";
        public const String C_TeachingByPractice = "TeachingByPractice";
        public const String C_MaxPercentOff = "MaxPercentOff";
        public const String C_MinTestAverage = "MinTestAverage";
        public const String C_IsLockedTeachingSchedule = "IsLockedTeachingSchedule";
        public const String C_IsIgnoreTeachingTime = "IsIgnoreTeachingTime";
        public const String C_MeetingLink = "MeetingLink";
        public const String C_MeetingCode = "MeetingCode";
        public const String C_StartRegister = "StartRegister";
        public const String C_FinishRegister = "FinishRegister";
        public const String C_CommitRegister = "CommitRegister";
        public const String C_MaxRegister = "MaxRegister";
        public const String C_TeacherList = "TeacherList";
        public const String C_RoomList = "RoomList";
        public const String C_TeacherNameList = "TeacherNameList";
        public const String C_RoomNameList = "RoomNameList";
        public const String C_TeacherListTheory = "TeacherListTheory";
        public const String C_RoomListTheory = "RoomListTheory";
        public const String C_TeacherNameListTheory = "TeacherNameListTheory";
        public const String C_RoomNameListTheory = "RoomNameListTheory";
        public const String C_TeacherListPractice = "TeacherListPractice";
        public const String C_RoomListPractice = "RoomListPractice";
        public const String C_TeacherNameListPractice = "TeacherNameListPractice";
        public const String C_RoomNameListPractice = "RoomNameListPractice";
        public const String C_StartSetTeacher = "StartSetTeacher";
        public const String C_FinishSetTeacher = "FinishSetTeacher";
        public const String C_TestSessionID1 = "TestSessionID1";
        public const String C_ID_dt_mon = "ID_dt_mon";
        public const String C_TestSessionID2 = "TestSessionID2";
        public const String C_TestSessionID3 = "TestSessionID3";
        public const String C_TestSessionID4 = "TestSessionID4";
        public const String C_TestSessionID5 = "TestSessionID5";
        public const String C_PlanRowCount = "PlanRowCount";
        public const String C_AllowScheduling = "AllowScheduling";
        public const String C_AllowTestScheduling = "AllowTestScheduling";
        public const String C_IsLockedWeekDetailPlan = "IsLockedWeekDetailPlan";
        public const String C_TestScheduleLockedToDate = "TestScheduleLockedToDate";
        public const String C_ScheduleCheckingExtendToDate = "ScheduleCheckingExtendToDate";

        #endregion //Column names

        #endregion Variable Static
    }
}


