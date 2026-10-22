
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
    /// Created date 	: 17/05/2025 
    /// Description 
    /// </summary>	
    public partial class SIM_Student
    {
        #region Member Variables

        private long? lngStudentID = null;//Mã sinh viên tự sinh
        private string strStudentCode = null;//Mã số sinh viên, cho phép sửa, nhưng nó phải là duy nhất
        private string strStudentFirstName = null;
        private string strStudentLastName = null;
        private string strFullnameEn = null;
        private string strClassID = null;
        private int? intBirthDay = null;//Ngày sinh
        private int? intBirthMonth = null;//Tháng sinh
        private int? intBirthYear = null;//Năm sinh
        private string strBirthDateText = null;//Ngày tháng năm sinh tổ hợp từ 3 giá trị trên
        private string strBirthDateTextEn = null;//Ngày tháng năm sinh tổ hợp từ 3 giá trị trên
        private bool bolGender = false;//Giới tính
        private string strEthnicityID = null;//Mã dân tộc
        private string strReligionID = null;//Mã tôn giáo
        private string strBirthPlace = null;//Nơi sinh
        private string strOriginPlace = null;//Nguyên quán
        private string strLiveAddress = null;//Địa chỉ hộ khẩu thường trú
        private string strLiveProvinceID = null;//Tỉnh thành hộ khẩu tt
        private string strLiveDistrictID = null;//Quận huyện hktt
        private string strLiveWardID = null;//Phường xã hộ khẩu thường trú
        private string strLiveVillageID = null;//Thôn/ấp/khóm hộ khẩu trường trú
        private string strTel = null;//Điện thoại
        private string strEmail = null;
        private string strPersonID = null;//Số CMND
        private DateTime? dtmPersionIDDate = null;//Ngày cấp
        private string strPersionIDPlace = null;//Nơi cấp
        private string strAreaID = null;//Mã Khu vực GEN_Area
        private string strPreferentialObjectID = null;//Mã Đối tượng ưu đãi
        private string strPreferentialObjectID2 = null;//Mã Đối tượng ưu đãi
        private string strPreferentialObjectID3 = null;//Mã Đối tượng ưu đãi
        private string strComponentFamilyID = null;//Mã thành phần gia đình
        private double? dblClassEthicMark = null;//Tổng điểm rèn luyện trong lớp toàn khoá của sinh viên
        private string strClassEthicLevel = null;//Xếp loại rèn luyện lớp toàn khóa
        private double? dblEthicMark = null;//Tổng điểm rèn luyện hội dồng toàn khoá của sinh viên
        private string strEthicLevel = null;//Xếp loại rèn luyện hội đồng toàn khóa
        private double? dblLearningSummary = null;//Tổng kết điểm học tập toàn khóa
        private string strLearningLevel = null;//Xếp loại học tập toàn khóa
        private int? intFailedSubjectCount = null;//Tổng môn nợ toàn khoá
        private int? intFailedUnitTextSum = null;//Tổng đvht nợ toàn khoá
        private int? intUnitTextSum = null;//Tổng đvht học
        private int? intAllowGraduateAt = null;//Được dự thi tốt nghiệp ở lần xét thứ mấy. Nếu null là chưa được xét hoặc chưa đạt.
        private string strFatherName = null;//Tên cha
        private string strFatherJob = null;//Nghề nghiệp cha
        private string strFatherAddress = null;//Địa chỉ cha
        private string strMortherName = null;//Tên mẹ
        private string strMortherJob = null;//Nghề nghiệp mẹ
        private string strMortherAddress = null;//Địa chỉ mẹ
        private string strContactName = null;//Tên chủ người liên lạc
        private string strContactAddress = null;//Địa chỉ liên lạc
        private string strContactTel = null;//Điện thoại liên lạc
        private string strContactName2 = null;//Tên chủ người liên lạc 2
        private string strContactAddress2 = null;//Địa chỉ liên lạc 2
        private string strContactTel2 = null;//Điện thoại liên lạc 2
        private int? intSubType = null;//Loại đối tượng được trợ. 0. Không có. 1. Trợ cấp XH. 2. Trợ cấp chính sách
        private bool bolIsInDorm = false;//Đang ở nội trú
        private DateTime? dtmLiveFromDate = null;//Ở từ ngày
        private DateTime? dtmLiveToDate = null;//Ở đến ngày
        private double? dblSemesterMoney = null;//Học phí học kì phải đóng
        private string strSpecialBranchID = null;//Nghề trúng tuyển, để khi đang ở lớp văn hóa thì lấy nghề này hiển thị trong một số mẫu xác nhận
        private string strCourseID = null;//Khoá học, dùng cho tuyển sinh khi chưa có lớp
        private string strGraduationLevel = null;//Cấp bậc tốt nghiệp: THCS, THPT
        private int? intGraduationYear = null;//Năm tốt nghiệp; ví dụ 2011
        private string strGraduationSchool = null;//Trường tốt nghiệp, địa chỉ, tỉnh thành,...
        private string strExamStudentNumber = null;//Số báo danh thi tuyển sinh
        private double? dblMark1 = null;//Điểm thi tuyển sinh môn 1
        private double? dblMark2 = null;//Điểm thi tuyển sinh môn 2
        private double? dblMark3 = null;//Điểm thi tuyển sinh môn 3
        private double? dblMark4 = null;//Điểm thi tuyển sinh môn 4
        private bool bolIsReceiveLearningForm = false;//Có nhận phiếu đăng ký nhập học
        private bool bolIsReceiveCandidateForm = false;//Có nhận đơn dự tuyển/ Phiếu đăng ký học nghề
        private bool bolIsReceivePersonCer = false;//Có nhận sơ yếu lý lịch bản thân
        private bool bolIsReceiveNotifyCopy = false;//Có nhận bản sao khai sanh + CMND
        private bool bolIsReceiveTranscripts = false;//Có nhận học bạ
        private bool bolIsReceiveTranscripts2 = false;//Có nhận học bạ
        private bool bolIsReceiveDiploma = false;//Có nhận bằng tốt nghiệp
        private bool bolIsReceiveTempDiploma = false;//Có nhận giấy CNTN Tạm thời
        private bool bolIsReceiveSubjectMark = false;//Có nhận bảng điểm
        private bool bolIsReceiveHealthCer = false;//Có nhận Giấy khám sức khỏe
        private bool bolIsReceiveWorkingCer = false;//Giấy xác nhận thời gian công tác
        private bool bolIsReceived = false;//Đã nhận bìa thư đựng hồ sơ
        private bool bolIsReceiveAssure = false;//Có nhận ảnh
        private bool bolIsReceivePreferentialObjectCer = false;//Có Giấy chứng nhận thuộc diện ưu tiên
        private bool bolIsReceiveImage = false;//Có nhận giấy tờ ưu tiên
        private bool bolIsReceiveMoney = false;//Đã thu học phí
        private bool bolIsUnionCard = false;//Có thẻ đoàn
        private bool bolIsUnionBook = false;//Có sổ đoàn
        private bool bolIsOkCollection = false;//Có sổ đoàn
        private string strImage = null;//Đã trúng tuyển
        private int? intStatus = null;//Trạng thái SV. 0.Chua xet tuyen.  1: Đang học, 2: Tốt nghiệp, 3: Đình chỉ, 4: Đuổi học, 5. Bảo lưu, 6. Lưu ban
        private int? intSourceInfoID = null;//N
        private long? lngFunds = null;//Quỹ đầu tư
        private long? lngBudget = null;//Ngân sách
        private string strDescription = null;//Mô tả
        private long? lngOrderIndex = null;
        private DateTime? dtmReceivedDate = null;//Ngày nhận hồ sơ
        private DateTime? dtmRealLearningDate = null;//Ngày thực học
        private long? lngStudentCollectionID = null;//Mã hồ sơ tuyển sinh
        private int? intStudentPositionID = null;//Mã cán bộ lớp
        private DateTime? dtmCreatedDate = null;//Ngày tạo
        private string strCreatedUser = null;//Người tạo
        private DateTime? dtmUpdatedDate = null;//Ngày cập nhật cuối
        private string strUpdatedUser = null;//Người cập nhật cuối
        private bool bolIsDeleted = false;
        private DateTime? dtmDeletedDate = null;
        private string strDeletedUser = null;
        private string strTempClass1 = null;
        private string strTempClass2 = null;
        private string strTempClass3 = null;
        private string strSystem = null;
        private int? intGroupSmallClassRegister = null;
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// StudentID
        /// Mã sinh viên tự sinh
        /// </summary>
        public long? StudentID
        {
            get { return lngStudentID; }
            set { lngStudentID = value; }
        }
        /// <summary>
        /// StudentCode
        /// Mã số sinh viên, cho phép sửa, nhưng nó phải là duy nhất
        /// </summary>
        public string StudentCode
        {
            get { return strStudentCode; }
            set { strStudentCode = value; }
        }
        /// <summary>
        /// StudentFirstName
        /// 
        /// </summary>
        public string StudentFirstName
        {
            get { return strStudentFirstName; }
            set { strStudentFirstName = value; }
        }
        /// <summary>
        /// StudentLastName
        /// 
        /// </summary>
        public string StudentLastName
        {
            get { return strStudentLastName; }
            set { strStudentLastName = value; }
        }
        /// <summary>
        /// FullnameEn
        /// 
        /// </summary>
        public string FullnameEn
        {
            get { return strFullnameEn; }
            set { strFullnameEn = value; }
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
        /// BirthDay
        /// Ngày sinh
        /// </summary>
        public int? BirthDay
        {
            get { return intBirthDay; }
            set { intBirthDay = value; }
        }
        /// <summary>
        /// BirthMonth
        /// Tháng sinh
        /// </summary>
        public int? BirthMonth
        {
            get { return intBirthMonth; }
            set { intBirthMonth = value; }
        }
        /// <summary>
        /// BirthYear
        /// Năm sinh
        /// </summary>
        public int? BirthYear
        {
            get { return intBirthYear; }
            set { intBirthYear = value; }
        }
        /// <summary>
        /// BirthDateText
        /// Ngày tháng năm sinh tổ hợp từ 3 giá trị trên
        /// </summary>
        public string BirthDateText
        {
            get { return strBirthDateText; }
            set { strBirthDateText = value; }
        }
        /// <summary>
        /// BirthDateTextEn
        /// Ngày tháng năm sinh tổ hợp từ 3 giá trị trên
        /// </summary>
        public string BirthDateTextEn
        {
            get { return strBirthDateTextEn; }
            set { strBirthDateTextEn = value; }
        }
        /// <summary>
        /// Gender
        /// Giới tính
        /// </summary>
        public bool Gender
        {
            get { return bolGender; }
            set { bolGender = value; }
        }
        /// <summary>
        /// EthnicityID
        /// Mã dân tộc
        /// </summary>
        public string EthnicityID
        {
            get { return strEthnicityID; }
            set { strEthnicityID = value; }
        }
        /// <summary>
        /// ReligionID
        /// Mã tôn giáo
        /// </summary>
        public string ReligionID
        {
            get { return strReligionID; }
            set { strReligionID = value; }
        }
        /// <summary>
        /// BirthPlace
        /// Nơi sinh
        /// </summary>
        public string BirthPlace
        {
            get { return strBirthPlace; }
            set { strBirthPlace = value; }
        }
        /// <summary>
        /// OriginPlace
        /// Nguyên quán
        /// </summary>
        public string OriginPlace
        {
            get { return strOriginPlace; }
            set { strOriginPlace = value; }
        }
        /// <summary>
        /// LiveAddress
        /// Địa chỉ hộ khẩu thường trú
        /// </summary>
        public string LiveAddress
        {
            get { return strLiveAddress; }
            set { strLiveAddress = value; }
        }
        /// <summary>
        /// LiveProvinceID
        /// Tỉnh thành hộ khẩu tt
        /// </summary>
        public string LiveProvinceID
        {
            get { return strLiveProvinceID; }
            set { strLiveProvinceID = value; }
        }
        /// <summary>
        /// LiveDistrictID
        /// Quận huyện hktt
        /// </summary>
        public string LiveDistrictID
        {
            get { return strLiveDistrictID; }
            set { strLiveDistrictID = value; }
        }
        /// <summary>
        /// LiveWardID
        /// Phường xã hộ khẩu thường trú
        /// </summary>
        public string LiveWardID
        {
            get { return strLiveWardID; }
            set { strLiveWardID = value; }
        }
        /// <summary>
        /// LiveVillageID
        /// Thôn/ấp/khóm hộ khẩu trường trú
        /// </summary>
        public string LiveVillageID
        {
            get { return strLiveVillageID; }
            set { strLiveVillageID = value; }
        }
        /// <summary>
        /// Tel
        /// Điện thoại
        /// </summary>
        public string Tel
        {
            get { return strTel; }
            set { strTel = value; }
        }
        /// <summary>
        /// Email
        /// 
        /// </summary>
        public string Email
        {
            get { return strEmail; }
            set { strEmail = value; }
        }
        /// <summary>
        /// PersonID
        /// Số CMND
        /// </summary>
        public string PersonID
        {
            get { return strPersonID; }
            set { strPersonID = value; }
        }
        /// <summary>
        /// PersionIDDate
        /// Ngày cấp
        /// </summary>
        public DateTime? PersionIDDate
        {
            get { return dtmPersionIDDate; }
            set { dtmPersionIDDate = value; }
        }
        /// <summary>
        /// PersionIDPlace
        /// Nơi cấp
        /// </summary>
        public string PersionIDPlace
        {
            get { return strPersionIDPlace; }
            set { strPersionIDPlace = value; }
        }
        /// <summary>
        /// AreaID
        /// Mã Khu vực GEN_Area
        /// </summary>
        public string AreaID
        {
            get { return strAreaID; }
            set { strAreaID = value; }
        }
        /// <summary>
        /// PreferentialObjectID
        /// Mã Đối tượng ưu đãi
        /// </summary>
        public string PreferentialObjectID
        {
            get { return strPreferentialObjectID; }
            set { strPreferentialObjectID = value; }
        }
        /// <summary>
        /// PreferentialObjectID2
        /// Mã Đối tượng ưu đãi
        /// </summary>
        public string PreferentialObjectID2
        {
            get { return strPreferentialObjectID2; }
            set { strPreferentialObjectID2 = value; }
        }
        /// <summary>
        /// PreferentialObjectID3
        /// Mã Đối tượng ưu đãi
        /// </summary>
        public string PreferentialObjectID3
        {
            get { return strPreferentialObjectID3; }
            set { strPreferentialObjectID3 = value; }
        }
        /// <summary>
        /// ComponentFamilyID
        /// Mã thành phần gia đình
        /// </summary>
        public string ComponentFamilyID
        {
            get { return strComponentFamilyID; }
            set { strComponentFamilyID = value; }
        }
        /// <summary>
        /// ClassEthicMark
        /// Tổng điểm rèn luyện trong lớp toàn khoá của sinh viên
        /// </summary>
        public double? ClassEthicMark
        {
            get { return dblClassEthicMark; }
            set { dblClassEthicMark = value; }
        }
        /// <summary>
        /// ClassEthicLevel
        /// Xếp loại rèn luyện lớp toàn khóa
        /// </summary>
        public string ClassEthicLevel
        {
            get { return strClassEthicLevel; }
            set { strClassEthicLevel = value; }
        }
        /// <summary>
        /// EthicMark
        /// Tổng điểm rèn luyện hội dồng toàn khoá của sinh viên
        /// </summary>
        public double? EthicMark
        {
            get { return dblEthicMark; }
            set { dblEthicMark = value; }
        }
        /// <summary>
        /// EthicLevel
        /// Xếp loại rèn luyện hội đồng toàn khóa
        /// </summary>
        public string EthicLevel
        {
            get { return strEthicLevel; }
            set { strEthicLevel = value; }
        }
        /// <summary>
        /// LearningSummary
        /// Tổng kết điểm học tập toàn khóa
        /// </summary>
        public double? LearningSummary
        {
            get { return dblLearningSummary; }
            set { dblLearningSummary = value; }
        }
        /// <summary>
        /// LearningLevel
        /// Xếp loại học tập toàn khóa
        /// </summary>
        public string LearningLevel
        {
            get { return strLearningLevel; }
            set { strLearningLevel = value; }
        }
        /// <summary>
        /// FailedSubjectCount
        /// Tổng môn nợ toàn khoá
        /// </summary>
        public int? FailedSubjectCount
        {
            get { return intFailedSubjectCount; }
            set { intFailedSubjectCount = value; }
        }
        /// <summary>
        /// FailedUnitTextSum
        /// Tổng đvht nợ toàn khoá
        /// </summary>
        public int? FailedUnitTextSum
        {
            get { return intFailedUnitTextSum; }
            set { intFailedUnitTextSum = value; }
        }
        /// <summary>
        /// UnitTextSum
        /// Tổng đvht học
        /// </summary>
        public int? UnitTextSum
        {
            get { return intUnitTextSum; }
            set { intUnitTextSum = value; }
        }
        /// <summary>
        /// AllowGraduateAt
        /// Được dự thi tốt nghiệp ở lần xét thứ mấy. Nếu null là chưa được xét hoặc chưa đạt.
        /// </summary>
        public int? AllowGraduateAt
        {
            get { return intAllowGraduateAt; }
            set { intAllowGraduateAt = value; }
        }
        /// <summary>
        /// FatherName
        /// Tên cha
        /// </summary>
        public string FatherName
        {
            get { return strFatherName; }
            set { strFatherName = value; }
        }
        /// <summary>
        /// FatherJob
        /// Nghề nghiệp cha
        /// </summary>
        public string FatherJob
        {
            get { return strFatherJob; }
            set { strFatherJob = value; }
        }
        /// <summary>
        /// FatherAddress
        /// Địa chỉ cha
        /// </summary>
        public string FatherAddress
        {
            get { return strFatherAddress; }
            set { strFatherAddress = value; }
        }
        /// <summary>
        /// MortherName
        /// Tên mẹ
        /// </summary>
        public string MortherName
        {
            get { return strMortherName; }
            set { strMortherName = value; }
        }
        /// <summary>
        /// MortherJob
        /// Nghề nghiệp mẹ
        /// </summary>
        public string MortherJob
        {
            get { return strMortherJob; }
            set { strMortherJob = value; }
        }
        /// <summary>
        /// MortherAddress
        /// Địa chỉ mẹ
        /// </summary>
        public string MortherAddress
        {
            get { return strMortherAddress; }
            set { strMortherAddress = value; }
        }
        /// <summary>
        /// ContactName
        /// Tên chủ người liên lạc
        /// </summary>
        public string ContactName
        {
            get { return strContactName; }
            set { strContactName = value; }
        }
        /// <summary>
        /// ContactAddress
        /// Địa chỉ liên lạc
        /// </summary>
        public string ContactAddress
        {
            get { return strContactAddress; }
            set { strContactAddress = value; }
        }
        /// <summary>
        /// ContactTel
        /// Điện thoại liên lạc
        /// </summary>
        public string ContactTel
        {
            get { return strContactTel; }
            set { strContactTel = value; }
        }
        /// <summary>
        /// ContactName2
        /// Tên chủ người liên lạc 2
        /// </summary>
        public string ContactName2
        {
            get { return strContactName2; }
            set { strContactName2 = value; }
        }
        /// <summary>
        /// ContactAddress2
        /// Địa chỉ liên lạc 2
        /// </summary>
        public string ContactAddress2
        {
            get { return strContactAddress2; }
            set { strContactAddress2 = value; }
        }
        /// <summary>
        /// ContactTel2
        /// Điện thoại liên lạc 2
        /// </summary>
        public string ContactTel2
        {
            get { return strContactTel2; }
            set { strContactTel2 = value; }
        }
        /// <summary>
        /// SubType
        /// Loại đối tượng được trợ. 0. Không có. 1. Trợ cấp XH. 2. Trợ cấp chính sách
        /// </summary>
        public int? SubType
        {
            get { return intSubType; }
            set { intSubType = value; }
        }
        /// <summary>
        /// IsInDorm
        /// Đang ở nội trú
        /// </summary>
        public bool IsInDorm
        {
            get { return bolIsInDorm; }
            set { bolIsInDorm = value; }
        }
        /// <summary>
        /// LiveFromDate
        /// Ở từ ngày
        /// </summary>
        public DateTime? LiveFromDate
        {
            get { return dtmLiveFromDate; }
            set { dtmLiveFromDate = value; }
        }
        /// <summary>
        /// LiveToDate
        /// Ở đến ngày
        /// </summary>
        public DateTime? LiveToDate
        {
            get { return dtmLiveToDate; }
            set { dtmLiveToDate = value; }
        }
        /// <summary>
        /// SemesterMoney
        /// Học phí học kì phải đóng
        /// </summary>
        public double? SemesterMoney
        {
            get { return dblSemesterMoney; }
            set { dblSemesterMoney = value; }
        }
        /// <summary>
        /// SpecialBranchID
        /// Nghề trúng tuyển, để khi đang ở lớp văn hóa thì lấy nghề này hiển thị trong một số mẫu xác nhận
        /// </summary>
        public string SpecialBranchID
        {
            get { return strSpecialBranchID; }
            set { strSpecialBranchID = value; }
        }
        /// <summary>
        /// CourseID
        /// Khoá học, dùng cho tuyển sinh khi chưa có lớp
        /// </summary>
        public string CourseID
        {
            get { return strCourseID; }
            set { strCourseID = value; }
        }
        /// <summary>
        /// GraduationLevel
        /// Cấp bậc tốt nghiệp: THCS, THPT
        /// </summary>
        public string GraduationLevel
        {
            get { return strGraduationLevel; }
            set { strGraduationLevel = value; }
        }
        /// <summary>
        /// GraduationYear
        /// Năm tốt nghiệp; ví dụ 2011
        /// </summary>
        public int? GraduationYear
        {
            get { return intGraduationYear; }
            set { intGraduationYear = value; }
        }
        /// <summary>
        /// GraduationSchool
        /// Trường tốt nghiệp, địa chỉ, tỉnh thành,...
        /// </summary>
        public string GraduationSchool
        {
            get { return strGraduationSchool; }
            set { strGraduationSchool = value; }
        }
        /// <summary>
        /// ExamStudentNumber
        /// Số báo danh thi tuyển sinh
        /// </summary>
        public string ExamStudentNumber
        {
            get { return strExamStudentNumber; }
            set { strExamStudentNumber = value; }
        }
        /// <summary>
        /// Mark1
        /// Điểm thi tuyển sinh môn 1
        /// </summary>
        public double? Mark1
        {
            get { return dblMark1; }
            set { dblMark1 = value; }
        }
        /// <summary>
        /// Mark2
        /// Điểm thi tuyển sinh môn 2
        /// </summary>
        public double? Mark2
        {
            get { return dblMark2; }
            set { dblMark2 = value; }
        }
        /// <summary>
        /// Mark3
        /// Điểm thi tuyển sinh môn 3
        /// </summary>
        public double? Mark3
        {
            get { return dblMark3; }
            set { dblMark3 = value; }
        }
        /// <summary>
        /// Mark4
        /// Điểm thi tuyển sinh môn 4
        /// </summary>
        public double? Mark4
        {
            get { return dblMark4; }
            set { dblMark4 = value; }
        }
        /// <summary>
        /// IsReceiveLearningForm
        /// Có nhận phiếu đăng ký nhập học
        /// </summary>
        public bool IsReceiveLearningForm
        {
            get { return bolIsReceiveLearningForm; }
            set { bolIsReceiveLearningForm = value; }
        }
        /// <summary>
        /// IsReceiveCandidateForm
        /// Có nhận đơn dự tuyển/ Phiếu đăng ký học nghề
        /// </summary>
        public bool IsReceiveCandidateForm
        {
            get { return bolIsReceiveCandidateForm; }
            set { bolIsReceiveCandidateForm = value; }
        }
        /// <summary>
        /// IsReceivePersonCer
        /// Có nhận sơ yếu lý lịch bản thân
        /// </summary>
        public bool IsReceivePersonCer
        {
            get { return bolIsReceivePersonCer; }
            set { bolIsReceivePersonCer = value; }
        }
        /// <summary>
        /// IsReceiveNotifyCopy
        /// Có nhận bản sao khai sanh + CMND
        /// </summary>
        public bool IsReceiveNotifyCopy
        {
            get { return bolIsReceiveNotifyCopy; }
            set { bolIsReceiveNotifyCopy = value; }
        }
        /// <summary>
        /// IsReceiveTranscripts
        /// Có nhận học bạ
        /// </summary>
        public bool IsReceiveTranscripts
        {
            get { return bolIsReceiveTranscripts; }
            set { bolIsReceiveTranscripts = value; }
        }
        /// <summary>
        /// IsReceiveTranscripts2
        /// Có nhận học bạ
        /// </summary>
        public bool IsReceiveTranscripts2
        {
            get { return bolIsReceiveTranscripts2; }
            set { bolIsReceiveTranscripts2 = value; }
        }
        /// <summary>
        /// IsReceiveDiploma
        /// Có nhận bằng tốt nghiệp
        /// </summary>
        public bool IsReceiveDiploma
        {
            get { return bolIsReceiveDiploma; }
            set { bolIsReceiveDiploma = value; }
        }
        /// <summary>
        /// IsReceiveTempDiploma
        /// Có nhận giấy CNTN Tạm thời
        /// </summary>
        public bool IsReceiveTempDiploma
        {
            get { return bolIsReceiveTempDiploma; }
            set { bolIsReceiveTempDiploma = value; }
        }
        /// <summary>
        /// IsReceiveSubjectMark
        /// Có nhận bảng điểm
        /// </summary>
        public bool IsReceiveSubjectMark
        {
            get { return bolIsReceiveSubjectMark; }
            set { bolIsReceiveSubjectMark = value; }
        }
        /// <summary>
        /// IsReceiveHealthCer
        /// Có nhận Giấy khám sức khỏe
        /// </summary>
        public bool IsReceiveHealthCer
        {
            get { return bolIsReceiveHealthCer; }
            set { bolIsReceiveHealthCer = value; }
        }
        /// <summary>
        /// IsReceiveWorkingCer
        /// Giấy xác nhận thời gian công tác
        /// </summary>
        public bool IsReceiveWorkingCer
        {
            get { return bolIsReceiveWorkingCer; }
            set { bolIsReceiveWorkingCer = value; }
        }
        /// <summary>
        /// IsReceived
        /// Đã nhận bìa thư đựng hồ sơ
        /// </summary>
        public bool IsReceived
        {
            get { return bolIsReceived; }
            set { bolIsReceived = value; }
        }
        /// <summary>
        /// IsReceiveAssure
        /// Có nhận ảnh
        /// </summary>
        public bool IsReceiveAssure
        {
            get { return bolIsReceiveAssure; }
            set { bolIsReceiveAssure = value; }
        }
        /// <summary>
        /// IsReceivePreferentialObjectCer
        /// Có Giấy chứng nhận thuộc diện ưu tiên
        /// </summary>
        public bool IsReceivePreferentialObjectCer
        {
            get { return bolIsReceivePreferentialObjectCer; }
            set { bolIsReceivePreferentialObjectCer = value; }
        }
        /// <summary>
        /// IsReceiveImage
        /// Có nhận giấy tờ ưu tiên
        /// </summary>
        public bool IsReceiveImage
        {
            get { return bolIsReceiveImage; }
            set { bolIsReceiveImage = value; }
        }
        /// <summary>
        /// IsReceiveMoney
        /// Đã thu học phí
        /// </summary>
        public bool IsReceiveMoney
        {
            get { return bolIsReceiveMoney; }
            set { bolIsReceiveMoney = value; }
        }
        /// <summary>
        /// IsUnionCard
        /// Có thẻ đoàn
        /// </summary>
        public bool IsUnionCard
        {
            get { return bolIsUnionCard; }
            set { bolIsUnionCard = value; }
        }
        /// <summary>
        /// IsUnionBook
        /// Có sổ đoàn
        /// </summary>
        public bool IsUnionBook
        {
            get { return bolIsUnionBook; }
            set { bolIsUnionBook = value; }
        }
        /// <summary>
        /// IsOkCollection
        /// Có sổ đoàn
        /// </summary>
        public bool IsOkCollection
        {
            get { return bolIsOkCollection; }
            set { bolIsOkCollection = value; }
        }
        /// <summary>
        /// Image
        /// Đã trúng tuyển
        /// </summary>
        public string Image
        {
            get { return strImage; }
            set { strImage = value; }
        }
        /// <summary>
        /// Status
        /// Trạng thái SV. 0.Chua xet tuyen.  1: Đang học, 2: Tốt nghiệp, 3: Đình chỉ, 4: Đuổi học, 5. Bảo lưu, 6. Lưu ban
        /// </summary>
        public int? Status
        {
            get { return intStatus; }
            set { intStatus = value; }
        }
        /// <summary>
        /// SourceInfoID
        /// N
        /// </summary>
        public int? SourceInfoID
        {
            get { return intSourceInfoID; }
            set { intSourceInfoID = value; }
        }
        /// <summary>
        /// Funds
        /// Quỹ đầu tư
        /// </summary>
        public long? Funds
        {
            get { return lngFunds; }
            set { lngFunds = value; }
        }
        /// <summary>
        /// Budget
        /// Ngân sách
        /// </summary>
        public long? Budget
        {
            get { return lngBudget; }
            set { lngBudget = value; }
        }
        /// <summary>
        /// Description
        /// Mô tả
        /// </summary>
        public string Description
        {
            get { return strDescription; }
            set { strDescription = value; }
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
        /// ReceivedDate
        /// Ngày nhận hồ sơ
        /// </summary>
        public DateTime? ReceivedDate
        {
            get { return dtmReceivedDate; }
            set { dtmReceivedDate = value; }
        }
        /// <summary>
        /// RealLearningDate
        /// Ngày thực học
        /// </summary>
        public DateTime? RealLearningDate
        {
            get { return dtmRealLearningDate; }
            set { dtmRealLearningDate = value; }
        }
        /// <summary>
        /// StudentCollectionID
        /// Mã hồ sơ tuyển sinh
        /// </summary>
        public long? StudentCollectionID
        {
            get { return lngStudentCollectionID; }
            set { lngStudentCollectionID = value; }
        }
        /// <summary>
        /// StudentPositionID
        /// Mã cán bộ lớp
        /// </summary>
        public int? StudentPositionID
        {
            get { return intStudentPositionID; }
            set { intStudentPositionID = value; }
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
        /// IsDeleted
        /// 
        /// </summary>
        public bool IsDeleted
        {
            get { return bolIsDeleted; }
            set { bolIsDeleted = value; }
        }
        /// <summary>
        /// DeletedDate
        /// 
        /// </summary>
        public DateTime? DeletedDate
        {
            get { return dtmDeletedDate; }
            set { dtmDeletedDate = value; }
        }
        /// <summary>
        /// DeletedUser
        /// 
        /// </summary>
        public string DeletedUser
        {
            get { return strDeletedUser; }
            set { strDeletedUser = value; }
        }
        /// <summary>
        /// TempClass1
        /// 
        /// </summary>
        public string TempClass1
        {
            get { return strTempClass1; }
            set { strTempClass1 = value; }
        }
        /// <summary>
        /// TempClass2
        /// 
        /// </summary>
        public string TempClass2
        {
            get { return strTempClass2; }
            set { strTempClass2 = value; }
        }
        /// <summary>
        /// TempClass3
        /// 
        /// </summary>
        public string TempClass3
        {
            get { return strTempClass3; }
            set { strTempClass3 = value; }
        }
        /// <summary>
        /// System
        /// 
        /// </summary>
        public string System
        {
            get { return strSystem; }
            set { strSystem = value; }
        }
        /// <summary>
        /// GroupSmallClassRegister
        /// 
        /// </summary>
        public int? GroupSmallClassRegister
        {
            get { return intGroupSmallClassRegister; }
            set { intGroupSmallClassRegister = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_StudentID.ToUpper()) && !Convert.IsDBNull(reader[C_StudentID])) this.lngStudentID = Convert.ToInt64(reader[C_StudentID]);
                    if (reader.GetName(i).ToUpper().Equals(C_StudentCode.ToUpper()) && !Convert.IsDBNull(reader[C_StudentCode])) this.strStudentCode = Convert.ToString(reader[C_StudentCode]);
                    if (reader.GetName(i).ToUpper().Equals(C_StudentFirstName.ToUpper()) && !Convert.IsDBNull(reader[C_StudentFirstName])) this.strStudentFirstName = Convert.ToString(reader[C_StudentFirstName]);
                    if (reader.GetName(i).ToUpper().Equals(C_StudentLastName.ToUpper()) && !Convert.IsDBNull(reader[C_StudentLastName])) this.strStudentLastName = Convert.ToString(reader[C_StudentLastName]);
                    if (reader.GetName(i).ToUpper().Equals(C_FullnameEn.ToUpper()) && !Convert.IsDBNull(reader[C_FullnameEn])) this.strFullnameEn = Convert.ToString(reader[C_FullnameEn]);
                    if (reader.GetName(i).ToUpper().Equals(C_ClassID.ToUpper()) && !Convert.IsDBNull(reader[C_ClassID])) this.strClassID = Convert.ToString(reader[C_ClassID]);
                    if (reader.GetName(i).ToUpper().Equals(C_BirthDay.ToUpper()) && !Convert.IsDBNull(reader[C_BirthDay])) this.intBirthDay = Convert.ToInt32(reader[C_BirthDay]);
                    if (reader.GetName(i).ToUpper().Equals(C_BirthMonth.ToUpper()) && !Convert.IsDBNull(reader[C_BirthMonth])) this.intBirthMonth = Convert.ToInt32(reader[C_BirthMonth]);
                    if (reader.GetName(i).ToUpper().Equals(C_BirthYear.ToUpper()) && !Convert.IsDBNull(reader[C_BirthYear])) this.intBirthYear = Convert.ToInt32(reader[C_BirthYear]);
                    if (reader.GetName(i).ToUpper().Equals(C_BirthDateText.ToUpper()) && !Convert.IsDBNull(reader[C_BirthDateText])) this.strBirthDateText = Convert.ToString(reader[C_BirthDateText]);
                    if (reader.GetName(i).ToUpper().Equals(C_BirthDateTextEn.ToUpper()) && !Convert.IsDBNull(reader[C_BirthDateTextEn])) this.strBirthDateTextEn = Convert.ToString(reader[C_BirthDateTextEn]);
                    if (reader.GetName(i).ToUpper().Equals(C_Gender.ToUpper()) && !Convert.IsDBNull(reader[C_Gender])) this.bolGender = Convert.ToBoolean(reader[C_Gender]);
                    if (reader.GetName(i).ToUpper().Equals(C_EthnicityID.ToUpper()) && !Convert.IsDBNull(reader[C_EthnicityID])) this.strEthnicityID = Convert.ToString(reader[C_EthnicityID]);
                    if (reader.GetName(i).ToUpper().Equals(C_ReligionID.ToUpper()) && !Convert.IsDBNull(reader[C_ReligionID])) this.strReligionID = Convert.ToString(reader[C_ReligionID]);
                    if (reader.GetName(i).ToUpper().Equals(C_BirthPlace.ToUpper()) && !Convert.IsDBNull(reader[C_BirthPlace])) this.strBirthPlace = Convert.ToString(reader[C_BirthPlace]);
                    if (reader.GetName(i).ToUpper().Equals(C_OriginPlace.ToUpper()) && !Convert.IsDBNull(reader[C_OriginPlace])) this.strOriginPlace = Convert.ToString(reader[C_OriginPlace]);
                    if (reader.GetName(i).ToUpper().Equals(C_LiveAddress.ToUpper()) && !Convert.IsDBNull(reader[C_LiveAddress])) this.strLiveAddress = Convert.ToString(reader[C_LiveAddress]);
                    if (reader.GetName(i).ToUpper().Equals(C_LiveProvinceID.ToUpper()) && !Convert.IsDBNull(reader[C_LiveProvinceID])) this.strLiveProvinceID = Convert.ToString(reader[C_LiveProvinceID]);
                    if (reader.GetName(i).ToUpper().Equals(C_LiveDistrictID.ToUpper()) && !Convert.IsDBNull(reader[C_LiveDistrictID])) this.strLiveDistrictID = Convert.ToString(reader[C_LiveDistrictID]);
                    if (reader.GetName(i).ToUpper().Equals(C_LiveWardID.ToUpper()) && !Convert.IsDBNull(reader[C_LiveWardID])) this.strLiveWardID = Convert.ToString(reader[C_LiveWardID]);
                    if (reader.GetName(i).ToUpper().Equals(C_LiveVillageID.ToUpper()) && !Convert.IsDBNull(reader[C_LiveVillageID])) this.strLiveVillageID = Convert.ToString(reader[C_LiveVillageID]);
                    if (reader.GetName(i).ToUpper().Equals(C_Tel.ToUpper()) && !Convert.IsDBNull(reader[C_Tel])) this.strTel = Convert.ToString(reader[C_Tel]);
                    if (reader.GetName(i).ToUpper().Equals(C_Email.ToUpper()) && !Convert.IsDBNull(reader[C_Email])) this.strEmail = Convert.ToString(reader[C_Email]);
                    if (reader.GetName(i).ToUpper().Equals(C_PersonID.ToUpper()) && !Convert.IsDBNull(reader[C_PersonID])) this.strPersonID = Convert.ToString(reader[C_PersonID]);
                    if (reader.GetName(i).ToUpper().Equals(C_PersionIDDate.ToUpper()) && !Convert.IsDBNull(reader[C_PersionIDDate])) this.dtmPersionIDDate = Convert.ToDateTime(reader[C_PersionIDDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_PersionIDPlace.ToUpper()) && !Convert.IsDBNull(reader[C_PersionIDPlace])) this.strPersionIDPlace = Convert.ToString(reader[C_PersionIDPlace]);
                    if (reader.GetName(i).ToUpper().Equals(C_AreaID.ToUpper()) && !Convert.IsDBNull(reader[C_AreaID])) this.strAreaID = Convert.ToString(reader[C_AreaID]);
                    if (reader.GetName(i).ToUpper().Equals(C_PreferentialObjectID.ToUpper()) && !Convert.IsDBNull(reader[C_PreferentialObjectID])) this.strPreferentialObjectID = Convert.ToString(reader[C_PreferentialObjectID]);
                    if (reader.GetName(i).ToUpper().Equals(C_PreferentialObjectID2.ToUpper()) && !Convert.IsDBNull(reader[C_PreferentialObjectID2])) this.strPreferentialObjectID2 = Convert.ToString(reader[C_PreferentialObjectID2]);
                    if (reader.GetName(i).ToUpper().Equals(C_PreferentialObjectID3.ToUpper()) && !Convert.IsDBNull(reader[C_PreferentialObjectID3])) this.strPreferentialObjectID3 = Convert.ToString(reader[C_PreferentialObjectID3]);
                    if (reader.GetName(i).ToUpper().Equals(C_ComponentFamilyID.ToUpper()) && !Convert.IsDBNull(reader[C_ComponentFamilyID])) this.strComponentFamilyID = Convert.ToString(reader[C_ComponentFamilyID]);
                    if (reader.GetName(i).ToUpper().Equals(C_ClassEthicMark.ToUpper()) && !Convert.IsDBNull(reader[C_ClassEthicMark])) this.dblClassEthicMark = Convert.ToDouble(reader[C_ClassEthicMark]);
                    if (reader.GetName(i).ToUpper().Equals(C_ClassEthicLevel.ToUpper()) && !Convert.IsDBNull(reader[C_ClassEthicLevel])) this.strClassEthicLevel = Convert.ToString(reader[C_ClassEthicLevel]);
                    if (reader.GetName(i).ToUpper().Equals(C_EthicMark.ToUpper()) && !Convert.IsDBNull(reader[C_EthicMark])) this.dblEthicMark = Convert.ToDouble(reader[C_EthicMark]);
                    if (reader.GetName(i).ToUpper().Equals(C_EthicLevel.ToUpper()) && !Convert.IsDBNull(reader[C_EthicLevel])) this.strEthicLevel = Convert.ToString(reader[C_EthicLevel]);
                    if (reader.GetName(i).ToUpper().Equals(C_LearningSummary.ToUpper()) && !Convert.IsDBNull(reader[C_LearningSummary])) this.dblLearningSummary = Convert.ToDouble(reader[C_LearningSummary]);
                    if (reader.GetName(i).ToUpper().Equals(C_LearningLevel.ToUpper()) && !Convert.IsDBNull(reader[C_LearningLevel])) this.strLearningLevel = Convert.ToString(reader[C_LearningLevel]);
                    if (reader.GetName(i).ToUpper().Equals(C_FailedSubjectCount.ToUpper()) && !Convert.IsDBNull(reader[C_FailedSubjectCount])) this.intFailedSubjectCount = Convert.ToInt32(reader[C_FailedSubjectCount]);
                    if (reader.GetName(i).ToUpper().Equals(C_FailedUnitTextSum.ToUpper()) && !Convert.IsDBNull(reader[C_FailedUnitTextSum])) this.intFailedUnitTextSum = Convert.ToInt32(reader[C_FailedUnitTextSum]);
                    if (reader.GetName(i).ToUpper().Equals(C_UnitTextSum.ToUpper()) && !Convert.IsDBNull(reader[C_UnitTextSum])) this.intUnitTextSum = Convert.ToInt32(reader[C_UnitTextSum]);
                    if (reader.GetName(i).ToUpper().Equals(C_AllowGraduateAt.ToUpper()) && !Convert.IsDBNull(reader[C_AllowGraduateAt])) this.intAllowGraduateAt = Convert.ToInt32(reader[C_AllowGraduateAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_FatherName.ToUpper()) && !Convert.IsDBNull(reader[C_FatherName])) this.strFatherName = Convert.ToString(reader[C_FatherName]);
                    if (reader.GetName(i).ToUpper().Equals(C_FatherJob.ToUpper()) && !Convert.IsDBNull(reader[C_FatherJob])) this.strFatherJob = Convert.ToString(reader[C_FatherJob]);
                    if (reader.GetName(i).ToUpper().Equals(C_FatherAddress.ToUpper()) && !Convert.IsDBNull(reader[C_FatherAddress])) this.strFatherAddress = Convert.ToString(reader[C_FatherAddress]);
                    if (reader.GetName(i).ToUpper().Equals(C_MortherName.ToUpper()) && !Convert.IsDBNull(reader[C_MortherName])) this.strMortherName = Convert.ToString(reader[C_MortherName]);
                    if (reader.GetName(i).ToUpper().Equals(C_MortherJob.ToUpper()) && !Convert.IsDBNull(reader[C_MortherJob])) this.strMortherJob = Convert.ToString(reader[C_MortherJob]);
                    if (reader.GetName(i).ToUpper().Equals(C_MortherAddress.ToUpper()) && !Convert.IsDBNull(reader[C_MortherAddress])) this.strMortherAddress = Convert.ToString(reader[C_MortherAddress]);
                    if (reader.GetName(i).ToUpper().Equals(C_ContactName.ToUpper()) && !Convert.IsDBNull(reader[C_ContactName])) this.strContactName = Convert.ToString(reader[C_ContactName]);
                    if (reader.GetName(i).ToUpper().Equals(C_ContactAddress.ToUpper()) && !Convert.IsDBNull(reader[C_ContactAddress])) this.strContactAddress = Convert.ToString(reader[C_ContactAddress]);
                    if (reader.GetName(i).ToUpper().Equals(C_ContactTel.ToUpper()) && !Convert.IsDBNull(reader[C_ContactTel])) this.strContactTel = Convert.ToString(reader[C_ContactTel]);
                    if (reader.GetName(i).ToUpper().Equals(C_ContactName2.ToUpper()) && !Convert.IsDBNull(reader[C_ContactName2])) this.strContactName2 = Convert.ToString(reader[C_ContactName2]);
                    if (reader.GetName(i).ToUpper().Equals(C_ContactAddress2.ToUpper()) && !Convert.IsDBNull(reader[C_ContactAddress2])) this.strContactAddress2 = Convert.ToString(reader[C_ContactAddress2]);
                    if (reader.GetName(i).ToUpper().Equals(C_ContactTel2.ToUpper()) && !Convert.IsDBNull(reader[C_ContactTel2])) this.strContactTel2 = Convert.ToString(reader[C_ContactTel2]);
                    if (reader.GetName(i).ToUpper().Equals(C_SubType.ToUpper()) && !Convert.IsDBNull(reader[C_SubType])) this.intSubType = Convert.ToInt32(reader[C_SubType]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsInDorm.ToUpper()) && !Convert.IsDBNull(reader[C_IsInDorm])) this.bolIsInDorm = Convert.ToBoolean(reader[C_IsInDorm]);
                    if (reader.GetName(i).ToUpper().Equals(C_LiveFromDate.ToUpper()) && !Convert.IsDBNull(reader[C_LiveFromDate])) this.dtmLiveFromDate = Convert.ToDateTime(reader[C_LiveFromDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_LiveToDate.ToUpper()) && !Convert.IsDBNull(reader[C_LiveToDate])) this.dtmLiveToDate = Convert.ToDateTime(reader[C_LiveToDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_SemesterMoney.ToUpper()) && !Convert.IsDBNull(reader[C_SemesterMoney])) this.dblSemesterMoney = Convert.ToDouble(reader[C_SemesterMoney]);
                    if (reader.GetName(i).ToUpper().Equals(C_SpecialBranchID.ToUpper()) && !Convert.IsDBNull(reader[C_SpecialBranchID])) this.strSpecialBranchID = Convert.ToString(reader[C_SpecialBranchID]);
                    if (reader.GetName(i).ToUpper().Equals(C_CourseID.ToUpper()) && !Convert.IsDBNull(reader[C_CourseID])) this.strCourseID = Convert.ToString(reader[C_CourseID]);
                    if (reader.GetName(i).ToUpper().Equals(C_GraduationLevel.ToUpper()) && !Convert.IsDBNull(reader[C_GraduationLevel])) this.strGraduationLevel = Convert.ToString(reader[C_GraduationLevel]);
                    if (reader.GetName(i).ToUpper().Equals(C_GraduationYear.ToUpper()) && !Convert.IsDBNull(reader[C_GraduationYear])) this.intGraduationYear = Convert.ToInt32(reader[C_GraduationYear]);
                    if (reader.GetName(i).ToUpper().Equals(C_GraduationSchool.ToUpper()) && !Convert.IsDBNull(reader[C_GraduationSchool])) this.strGraduationSchool = Convert.ToString(reader[C_GraduationSchool]);
                    if (reader.GetName(i).ToUpper().Equals(C_ExamStudentNumber.ToUpper()) && !Convert.IsDBNull(reader[C_ExamStudentNumber])) this.strExamStudentNumber = Convert.ToString(reader[C_ExamStudentNumber]);
                    if (reader.GetName(i).ToUpper().Equals(C_Mark1.ToUpper()) && !Convert.IsDBNull(reader[C_Mark1])) this.dblMark1 = Convert.ToDouble(reader[C_Mark1]);
                    if (reader.GetName(i).ToUpper().Equals(C_Mark2.ToUpper()) && !Convert.IsDBNull(reader[C_Mark2])) this.dblMark2 = Convert.ToDouble(reader[C_Mark2]);
                    if (reader.GetName(i).ToUpper().Equals(C_Mark3.ToUpper()) && !Convert.IsDBNull(reader[C_Mark3])) this.dblMark3 = Convert.ToDouble(reader[C_Mark3]);
                    if (reader.GetName(i).ToUpper().Equals(C_Mark4.ToUpper()) && !Convert.IsDBNull(reader[C_Mark4])) this.dblMark4 = Convert.ToDouble(reader[C_Mark4]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsReceiveLearningForm.ToUpper()) && !Convert.IsDBNull(reader[C_IsReceiveLearningForm])) this.bolIsReceiveLearningForm = Convert.ToBoolean(reader[C_IsReceiveLearningForm]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsReceiveCandidateForm.ToUpper()) && !Convert.IsDBNull(reader[C_IsReceiveCandidateForm])) this.bolIsReceiveCandidateForm = Convert.ToBoolean(reader[C_IsReceiveCandidateForm]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsReceivePersonCer.ToUpper()) && !Convert.IsDBNull(reader[C_IsReceivePersonCer])) this.bolIsReceivePersonCer = Convert.ToBoolean(reader[C_IsReceivePersonCer]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsReceiveNotifyCopy.ToUpper()) && !Convert.IsDBNull(reader[C_IsReceiveNotifyCopy])) this.bolIsReceiveNotifyCopy = Convert.ToBoolean(reader[C_IsReceiveNotifyCopy]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsReceiveTranscripts.ToUpper()) && !Convert.IsDBNull(reader[C_IsReceiveTranscripts])) this.bolIsReceiveTranscripts = Convert.ToBoolean(reader[C_IsReceiveTranscripts]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsReceiveTranscripts2.ToUpper()) && !Convert.IsDBNull(reader[C_IsReceiveTranscripts2])) this.bolIsReceiveTranscripts2 = Convert.ToBoolean(reader[C_IsReceiveTranscripts2]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsReceiveDiploma.ToUpper()) && !Convert.IsDBNull(reader[C_IsReceiveDiploma])) this.bolIsReceiveDiploma = Convert.ToBoolean(reader[C_IsReceiveDiploma]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsReceiveTempDiploma.ToUpper()) && !Convert.IsDBNull(reader[C_IsReceiveTempDiploma])) this.bolIsReceiveTempDiploma = Convert.ToBoolean(reader[C_IsReceiveTempDiploma]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsReceiveSubjectMark.ToUpper()) && !Convert.IsDBNull(reader[C_IsReceiveSubjectMark])) this.bolIsReceiveSubjectMark = Convert.ToBoolean(reader[C_IsReceiveSubjectMark]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsReceiveHealthCer.ToUpper()) && !Convert.IsDBNull(reader[C_IsReceiveHealthCer])) this.bolIsReceiveHealthCer = Convert.ToBoolean(reader[C_IsReceiveHealthCer]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsReceiveWorkingCer.ToUpper()) && !Convert.IsDBNull(reader[C_IsReceiveWorkingCer])) this.bolIsReceiveWorkingCer = Convert.ToBoolean(reader[C_IsReceiveWorkingCer]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsReceived.ToUpper()) && !Convert.IsDBNull(reader[C_IsReceived])) this.bolIsReceived = Convert.ToBoolean(reader[C_IsReceived]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsReceiveAssure.ToUpper()) && !Convert.IsDBNull(reader[C_IsReceiveAssure])) this.bolIsReceiveAssure = Convert.ToBoolean(reader[C_IsReceiveAssure]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsReceivePreferentialObjectCer.ToUpper()) && !Convert.IsDBNull(reader[C_IsReceivePreferentialObjectCer])) this.bolIsReceivePreferentialObjectCer = Convert.ToBoolean(reader[C_IsReceivePreferentialObjectCer]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsReceiveImage.ToUpper()) && !Convert.IsDBNull(reader[C_IsReceiveImage])) this.bolIsReceiveImage = Convert.ToBoolean(reader[C_IsReceiveImage]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsReceiveMoney.ToUpper()) && !Convert.IsDBNull(reader[C_IsReceiveMoney])) this.bolIsReceiveMoney = Convert.ToBoolean(reader[C_IsReceiveMoney]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsUnionCard.ToUpper()) && !Convert.IsDBNull(reader[C_IsUnionCard])) this.bolIsUnionCard = Convert.ToBoolean(reader[C_IsUnionCard]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsUnionBook.ToUpper()) && !Convert.IsDBNull(reader[C_IsUnionBook])) this.bolIsUnionBook = Convert.ToBoolean(reader[C_IsUnionBook]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsOkCollection.ToUpper()) && !Convert.IsDBNull(reader[C_IsOkCollection])) this.bolIsOkCollection = Convert.ToBoolean(reader[C_IsOkCollection]);
                    if (reader.GetName(i).ToUpper().Equals(C_Image.ToUpper()) && !Convert.IsDBNull(reader[C_Image])) this.strImage = Convert.ToString(reader[C_Image]);
                    if (reader.GetName(i).ToUpper().Equals(C_Status.ToUpper()) && !Convert.IsDBNull(reader[C_Status])) this.intStatus = Convert.ToInt32(reader[C_Status]);
                    if (reader.GetName(i).ToUpper().Equals(C_SourceInfoID.ToUpper()) && !Convert.IsDBNull(reader[C_SourceInfoID])) this.intSourceInfoID = Convert.ToInt32(reader[C_SourceInfoID]);
                    if (reader.GetName(i).ToUpper().Equals(C_Funds.ToUpper()) && !Convert.IsDBNull(reader[C_Funds])) this.lngFunds = Convert.ToInt64(reader[C_Funds]);
                    if (reader.GetName(i).ToUpper().Equals(C_Budget.ToUpper()) && !Convert.IsDBNull(reader[C_Budget])) this.lngBudget = Convert.ToInt64(reader[C_Budget]);
                    if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
                    if (reader.GetName(i).ToUpper().Equals(C_OrderIndex.ToUpper()) && !Convert.IsDBNull(reader[C_OrderIndex])) this.lngOrderIndex = Convert.ToInt64(reader[C_OrderIndex]);
                    if (reader.GetName(i).ToUpper().Equals(C_ReceivedDate.ToUpper()) && !Convert.IsDBNull(reader[C_ReceivedDate])) this.dtmReceivedDate = Convert.ToDateTime(reader[C_ReceivedDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_RealLearningDate.ToUpper()) && !Convert.IsDBNull(reader[C_RealLearningDate])) this.dtmRealLearningDate = Convert.ToDateTime(reader[C_RealLearningDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_StudentCollectionID.ToUpper()) && !Convert.IsDBNull(reader[C_StudentCollectionID])) this.lngStudentCollectionID = Convert.ToInt64(reader[C_StudentCollectionID]);
                    if (reader.GetName(i).ToUpper().Equals(C_StudentPositionID.ToUpper()) && !Convert.IsDBNull(reader[C_StudentPositionID])) this.intStudentPositionID = Convert.ToInt32(reader[C_StudentPositionID]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(reader[C_UpdatedDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(reader[C_UpdatedUser]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsDeleted.ToUpper()) && !Convert.IsDBNull(reader[C_IsDeleted])) this.bolIsDeleted = Convert.ToBoolean(reader[C_IsDeleted]);
                    if (reader.GetName(i).ToUpper().Equals(C_DeletedDate.ToUpper()) && !Convert.IsDBNull(reader[C_DeletedDate])) this.dtmDeletedDate = Convert.ToDateTime(reader[C_DeletedDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_DeletedUser.ToUpper()) && !Convert.IsDBNull(reader[C_DeletedUser])) this.strDeletedUser = Convert.ToString(reader[C_DeletedUser]);
                    if (reader.GetName(i).ToUpper().Equals(C_TempClass1.ToUpper()) && !Convert.IsDBNull(reader[C_TempClass1])) this.strTempClass1 = Convert.ToString(reader[C_TempClass1]);
                    if (reader.GetName(i).ToUpper().Equals(C_TempClass2.ToUpper()) && !Convert.IsDBNull(reader[C_TempClass2])) this.strTempClass2 = Convert.ToString(reader[C_TempClass2]);
                    if (reader.GetName(i).ToUpper().Equals(C_TempClass3.ToUpper()) && !Convert.IsDBNull(reader[C_TempClass3])) this.strTempClass3 = Convert.ToString(reader[C_TempClass3]);
                    if (reader.GetName(i).ToUpper().Equals(C_System.ToUpper()) && !Convert.IsDBNull(reader[C_System])) this.strSystem = Convert.ToString(reader[C_System]);
                    if (reader.GetName(i).ToUpper().Equals(C_GroupSmallClassRegister.ToUpper()) && !Convert.IsDBNull(reader[C_GroupSmallClassRegister])) this.intGroupSmallClassRegister = Convert.ToInt32(reader[C_GroupSmallClassRegister]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_Student", objEx);
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
                if (!Convert.IsDBNull(drw[C_StudentID])) this.lngStudentID = Convert.ToInt64(drw[C_StudentID]);
                if (!Convert.IsDBNull(drw[C_StudentCode])) this.strStudentCode = Convert.ToString(drw[C_StudentCode]);
                if (!Convert.IsDBNull(drw[C_StudentFirstName])) this.strStudentFirstName = Convert.ToString(drw[C_StudentFirstName]);
                if (!Convert.IsDBNull(drw[C_StudentLastName])) this.strStudentLastName = Convert.ToString(drw[C_StudentLastName]);
                if (!Convert.IsDBNull(drw[C_FullnameEn])) this.strFullnameEn = Convert.ToString(drw[C_FullnameEn]);
                if (!Convert.IsDBNull(drw[C_ClassID])) this.strClassID = Convert.ToString(drw[C_ClassID]);
                if (!Convert.IsDBNull(drw[C_BirthDay])) this.intBirthDay = Convert.ToInt32(drw[C_BirthDay]);
                if (!Convert.IsDBNull(drw[C_BirthMonth])) this.intBirthMonth = Convert.ToInt32(drw[C_BirthMonth]);
                if (!Convert.IsDBNull(drw[C_BirthYear])) this.intBirthYear = Convert.ToInt32(drw[C_BirthYear]);
                if (!Convert.IsDBNull(drw[C_BirthDateText])) this.strBirthDateText = Convert.ToString(drw[C_BirthDateText]);
                if (!Convert.IsDBNull(drw[C_BirthDateTextEn])) this.strBirthDateTextEn = Convert.ToString(drw[C_BirthDateTextEn]);
                if (!Convert.IsDBNull(drw[C_Gender])) this.bolGender = Convert.ToBoolean(drw[C_Gender]);
                if (!Convert.IsDBNull(drw[C_EthnicityID])) this.strEthnicityID = Convert.ToString(drw[C_EthnicityID]);
                if (!Convert.IsDBNull(drw[C_ReligionID])) this.strReligionID = Convert.ToString(drw[C_ReligionID]);
                if (!Convert.IsDBNull(drw[C_BirthPlace])) this.strBirthPlace = Convert.ToString(drw[C_BirthPlace]);
                if (!Convert.IsDBNull(drw[C_OriginPlace])) this.strOriginPlace = Convert.ToString(drw[C_OriginPlace]);
                if (!Convert.IsDBNull(drw[C_LiveAddress])) this.strLiveAddress = Convert.ToString(drw[C_LiveAddress]);
                if (!Convert.IsDBNull(drw[C_LiveProvinceID])) this.strLiveProvinceID = Convert.ToString(drw[C_LiveProvinceID]);
                if (!Convert.IsDBNull(drw[C_LiveDistrictID])) this.strLiveDistrictID = Convert.ToString(drw[C_LiveDistrictID]);
                if (!Convert.IsDBNull(drw[C_LiveWardID])) this.strLiveWardID = Convert.ToString(drw[C_LiveWardID]);
                if (!Convert.IsDBNull(drw[C_LiveVillageID])) this.strLiveVillageID = Convert.ToString(drw[C_LiveVillageID]);
                if (!Convert.IsDBNull(drw[C_Tel])) this.strTel = Convert.ToString(drw[C_Tel]);
                if (!Convert.IsDBNull(drw[C_Email])) this.strEmail = Convert.ToString(drw[C_Email]);
                if (!Convert.IsDBNull(drw[C_PersonID])) this.strPersonID = Convert.ToString(drw[C_PersonID]);
                if (!Convert.IsDBNull(drw[C_PersionIDDate])) this.dtmPersionIDDate = Convert.ToDateTime(drw[C_PersionIDDate]);
                if (!Convert.IsDBNull(drw[C_PersionIDPlace])) this.strPersionIDPlace = Convert.ToString(drw[C_PersionIDPlace]);
                if (!Convert.IsDBNull(drw[C_AreaID])) this.strAreaID = Convert.ToString(drw[C_AreaID]);
                if (!Convert.IsDBNull(drw[C_PreferentialObjectID])) this.strPreferentialObjectID = Convert.ToString(drw[C_PreferentialObjectID]);
                if (!Convert.IsDBNull(drw[C_PreferentialObjectID2])) this.strPreferentialObjectID2 = Convert.ToString(drw[C_PreferentialObjectID2]);
                if (!Convert.IsDBNull(drw[C_PreferentialObjectID3])) this.strPreferentialObjectID3 = Convert.ToString(drw[C_PreferentialObjectID3]);
                if (!Convert.IsDBNull(drw[C_ComponentFamilyID])) this.strComponentFamilyID = Convert.ToString(drw[C_ComponentFamilyID]);
                if (!Convert.IsDBNull(drw[C_ClassEthicMark])) this.dblClassEthicMark = Convert.ToDouble(drw[C_ClassEthicMark]);
                if (!Convert.IsDBNull(drw[C_ClassEthicLevel])) this.strClassEthicLevel = Convert.ToString(drw[C_ClassEthicLevel]);
                if (!Convert.IsDBNull(drw[C_EthicMark])) this.dblEthicMark = Convert.ToDouble(drw[C_EthicMark]);
                if (!Convert.IsDBNull(drw[C_EthicLevel])) this.strEthicLevel = Convert.ToString(drw[C_EthicLevel]);
                if (!Convert.IsDBNull(drw[C_LearningSummary])) this.dblLearningSummary = Convert.ToDouble(drw[C_LearningSummary]);
                if (!Convert.IsDBNull(drw[C_LearningLevel])) this.strLearningLevel = Convert.ToString(drw[C_LearningLevel]);
                if (!Convert.IsDBNull(drw[C_FailedSubjectCount])) this.intFailedSubjectCount = Convert.ToInt32(drw[C_FailedSubjectCount]);
                if (!Convert.IsDBNull(drw[C_FailedUnitTextSum])) this.intFailedUnitTextSum = Convert.ToInt32(drw[C_FailedUnitTextSum]);
                if (!Convert.IsDBNull(drw[C_UnitTextSum])) this.intUnitTextSum = Convert.ToInt32(drw[C_UnitTextSum]);
                if (!Convert.IsDBNull(drw[C_AllowGraduateAt])) this.intAllowGraduateAt = Convert.ToInt32(drw[C_AllowGraduateAt]);
                if (!Convert.IsDBNull(drw[C_FatherName])) this.strFatherName = Convert.ToString(drw[C_FatherName]);
                if (!Convert.IsDBNull(drw[C_FatherJob])) this.strFatherJob = Convert.ToString(drw[C_FatherJob]);
                if (!Convert.IsDBNull(drw[C_FatherAddress])) this.strFatherAddress = Convert.ToString(drw[C_FatherAddress]);
                if (!Convert.IsDBNull(drw[C_MortherName])) this.strMortherName = Convert.ToString(drw[C_MortherName]);
                if (!Convert.IsDBNull(drw[C_MortherJob])) this.strMortherJob = Convert.ToString(drw[C_MortherJob]);
                if (!Convert.IsDBNull(drw[C_MortherAddress])) this.strMortherAddress = Convert.ToString(drw[C_MortherAddress]);
                if (!Convert.IsDBNull(drw[C_ContactName])) this.strContactName = Convert.ToString(drw[C_ContactName]);
                if (!Convert.IsDBNull(drw[C_ContactAddress])) this.strContactAddress = Convert.ToString(drw[C_ContactAddress]);
                if (!Convert.IsDBNull(drw[C_ContactTel])) this.strContactTel = Convert.ToString(drw[C_ContactTel]);
                if (!Convert.IsDBNull(drw[C_ContactName2])) this.strContactName2 = Convert.ToString(drw[C_ContactName2]);
                if (!Convert.IsDBNull(drw[C_ContactAddress2])) this.strContactAddress2 = Convert.ToString(drw[C_ContactAddress2]);
                if (!Convert.IsDBNull(drw[C_ContactTel2])) this.strContactTel2 = Convert.ToString(drw[C_ContactTel2]);
                if (!Convert.IsDBNull(drw[C_SubType])) this.intSubType = Convert.ToInt32(drw[C_SubType]);
                if (!Convert.IsDBNull(drw[C_IsInDorm])) this.bolIsInDorm = Convert.ToBoolean(drw[C_IsInDorm]);
                if (!Convert.IsDBNull(drw[C_LiveFromDate])) this.dtmLiveFromDate = Convert.ToDateTime(drw[C_LiveFromDate]);
                if (!Convert.IsDBNull(drw[C_LiveToDate])) this.dtmLiveToDate = Convert.ToDateTime(drw[C_LiveToDate]);
                if (!Convert.IsDBNull(drw[C_SemesterMoney])) this.dblSemesterMoney = Convert.ToDouble(drw[C_SemesterMoney]);
                if (!Convert.IsDBNull(drw[C_SpecialBranchID])) this.strSpecialBranchID = Convert.ToString(drw[C_SpecialBranchID]);
                if (!Convert.IsDBNull(drw[C_CourseID])) this.strCourseID = Convert.ToString(drw[C_CourseID]);
                if (!Convert.IsDBNull(drw[C_GraduationLevel])) this.strGraduationLevel = Convert.ToString(drw[C_GraduationLevel]);
                if (!Convert.IsDBNull(drw[C_GraduationYear])) this.intGraduationYear = Convert.ToInt32(drw[C_GraduationYear]);
                if (!Convert.IsDBNull(drw[C_GraduationSchool])) this.strGraduationSchool = Convert.ToString(drw[C_GraduationSchool]);
                if (!Convert.IsDBNull(drw[C_ExamStudentNumber])) this.strExamStudentNumber = Convert.ToString(drw[C_ExamStudentNumber]);
                if (!Convert.IsDBNull(drw[C_Mark1])) this.dblMark1 = Convert.ToDouble(drw[C_Mark1]);
                if (!Convert.IsDBNull(drw[C_Mark2])) this.dblMark2 = Convert.ToDouble(drw[C_Mark2]);
                if (!Convert.IsDBNull(drw[C_Mark3])) this.dblMark3 = Convert.ToDouble(drw[C_Mark3]);
                if (!Convert.IsDBNull(drw[C_Mark4])) this.dblMark4 = Convert.ToDouble(drw[C_Mark4]);
                if (!Convert.IsDBNull(drw[C_IsReceiveLearningForm])) this.bolIsReceiveLearningForm = Convert.ToBoolean(drw[C_IsReceiveLearningForm]);
                if (!Convert.IsDBNull(drw[C_IsReceiveCandidateForm])) this.bolIsReceiveCandidateForm = Convert.ToBoolean(drw[C_IsReceiveCandidateForm]);
                if (!Convert.IsDBNull(drw[C_IsReceivePersonCer])) this.bolIsReceivePersonCer = Convert.ToBoolean(drw[C_IsReceivePersonCer]);
                if (!Convert.IsDBNull(drw[C_IsReceiveNotifyCopy])) this.bolIsReceiveNotifyCopy = Convert.ToBoolean(drw[C_IsReceiveNotifyCopy]);
                if (!Convert.IsDBNull(drw[C_IsReceiveTranscripts])) this.bolIsReceiveTranscripts = Convert.ToBoolean(drw[C_IsReceiveTranscripts]);
                if (!Convert.IsDBNull(drw[C_IsReceiveTranscripts2])) this.bolIsReceiveTranscripts2 = Convert.ToBoolean(drw[C_IsReceiveTranscripts2]);
                if (!Convert.IsDBNull(drw[C_IsReceiveDiploma])) this.bolIsReceiveDiploma = Convert.ToBoolean(drw[C_IsReceiveDiploma]);
                if (!Convert.IsDBNull(drw[C_IsReceiveTempDiploma])) this.bolIsReceiveTempDiploma = Convert.ToBoolean(drw[C_IsReceiveTempDiploma]);
                if (!Convert.IsDBNull(drw[C_IsReceiveSubjectMark])) this.bolIsReceiveSubjectMark = Convert.ToBoolean(drw[C_IsReceiveSubjectMark]);
                if (!Convert.IsDBNull(drw[C_IsReceiveHealthCer])) this.bolIsReceiveHealthCer = Convert.ToBoolean(drw[C_IsReceiveHealthCer]);
                if (!Convert.IsDBNull(drw[C_IsReceiveWorkingCer])) this.bolIsReceiveWorkingCer = Convert.ToBoolean(drw[C_IsReceiveWorkingCer]);
                if (!Convert.IsDBNull(drw[C_IsReceived])) this.bolIsReceived = Convert.ToBoolean(drw[C_IsReceived]);
                if (!Convert.IsDBNull(drw[C_IsReceiveAssure])) this.bolIsReceiveAssure = Convert.ToBoolean(drw[C_IsReceiveAssure]);
                if (!Convert.IsDBNull(drw[C_IsReceivePreferentialObjectCer])) this.bolIsReceivePreferentialObjectCer = Convert.ToBoolean(drw[C_IsReceivePreferentialObjectCer]);
                if (!Convert.IsDBNull(drw[C_IsReceiveImage])) this.bolIsReceiveImage = Convert.ToBoolean(drw[C_IsReceiveImage]);
                if (!Convert.IsDBNull(drw[C_IsReceiveMoney])) this.bolIsReceiveMoney = Convert.ToBoolean(drw[C_IsReceiveMoney]);
                if (!Convert.IsDBNull(drw[C_IsUnionCard])) this.bolIsUnionCard = Convert.ToBoolean(drw[C_IsUnionCard]);
                if (!Convert.IsDBNull(drw[C_IsUnionBook])) this.bolIsUnionBook = Convert.ToBoolean(drw[C_IsUnionBook]);
                if (!Convert.IsDBNull(drw[C_IsOkCollection])) this.bolIsOkCollection = Convert.ToBoolean(drw[C_IsOkCollection]);
                if (!Convert.IsDBNull(drw[C_Image])) this.strImage = Convert.ToString(drw[C_Image]);
                if (!Convert.IsDBNull(drw[C_Status])) this.intStatus = Convert.ToInt32(drw[C_Status]);
                if (!Convert.IsDBNull(drw[C_SourceInfoID])) this.intSourceInfoID = Convert.ToInt32(drw[C_SourceInfoID]);
                if (!Convert.IsDBNull(drw[C_Funds])) this.lngFunds = Convert.ToInt64(drw[C_Funds]);
                if (!Convert.IsDBNull(drw[C_Budget])) this.lngBudget = Convert.ToInt64(drw[C_Budget]);
                if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
                if (!Convert.IsDBNull(drw[C_OrderIndex])) this.lngOrderIndex = Convert.ToInt64(drw[C_OrderIndex]);
                if (!Convert.IsDBNull(drw[C_ReceivedDate])) this.dtmReceivedDate = Convert.ToDateTime(drw[C_ReceivedDate]);
                if (!Convert.IsDBNull(drw[C_RealLearningDate])) this.dtmRealLearningDate = Convert.ToDateTime(drw[C_RealLearningDate]);
                if (!Convert.IsDBNull(drw[C_StudentCollectionID])) this.lngStudentCollectionID = Convert.ToInt64(drw[C_StudentCollectionID]);
                if (!Convert.IsDBNull(drw[C_StudentPositionID])) this.intStudentPositionID = Convert.ToInt32(drw[C_StudentPositionID]);
                if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
                if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
                if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
                if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
                if (!Convert.IsDBNull(drw[C_IsDeleted])) this.bolIsDeleted = Convert.ToBoolean(drw[C_IsDeleted]);
                if (!Convert.IsDBNull(drw[C_DeletedDate])) this.dtmDeletedDate = Convert.ToDateTime(drw[C_DeletedDate]);
                if (!Convert.IsDBNull(drw[C_DeletedUser])) this.strDeletedUser = Convert.ToString(drw[C_DeletedUser]);
                if (!Convert.IsDBNull(drw[C_TempClass1])) this.strTempClass1 = Convert.ToString(drw[C_TempClass1]);
                if (!Convert.IsDBNull(drw[C_TempClass2])) this.strTempClass2 = Convert.ToString(drw[C_TempClass2]);
                if (!Convert.IsDBNull(drw[C_TempClass3])) this.strTempClass3 = Convert.ToString(drw[C_TempClass3]);
                if (!Convert.IsDBNull(drw[C_System])) this.strSystem = Convert.ToString(drw[C_System]);
                if (!Convert.IsDBNull(drw[C_GroupSmallClassRegister])) this.intGroupSmallClassRegister = Convert.ToInt32(drw[C_GroupSmallClassRegister]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_Student", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        /// Nạp thông tin item 
        /// Store: SIM_Student_GET 
        ///</summary>
        /// <returns>true ? Có : False ? Không</returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Student_GET");
                objIData.AddParameter(P_StudentID, this.lngStudentID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_Student", objEx);
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
        /// Store: SIM_Student_GET 
        ///</summary>
        /// <returns> SIM_Student </returns>
        public SIM_Student Get(long? lngStudentID)
        {
            SIM_Student obj = new SIM_Student();
            if (objIData != null)
                obj.IDB = objIData;
            obj.StudentID = lngStudentID;
            if (obj.Get())
                return obj;
            this.objErrorException = obj.ErrorException;
            return null;
        }
        ///<summary>
        /// ExecNonQuery : SIM_Student
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Student", objEx);
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
        /// Search : SIM_Student
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Student", objEx);
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
        /// Search : SIM_Student
        /// Lấy hết dữ liệu
        /// Store: SIM_Student_GETALL 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable GetAll()
        {
            return GetDataTable("SIM_Student_GETALL");
        }

        ///<summary>
        /// Search : SIM_Student
        /// Tìm dữ liệu
        /// Store: SIM_Student_SEARCH 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable Search(params object[] pars)
        {
            return GetDataTable("SIM_Student_SEARCH", pars);
        }

        ///<summary>
        /// Add : SIM_Student
        /// Thêm dữ liệu
        /// Store: SIM_Student_ADD 
        ///</summary>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Student_ADD");
                objIData.AddParameter(P_StudentCode, this.strStudentCode);
                objIData.AddParameter(P_StudentFirstName, this.strStudentFirstName);
                objIData.AddParameter(P_StudentLastName, this.strStudentLastName);
                objIData.AddParameter(P_FullnameEn, this.strFullnameEn);
                objIData.AddParameter(P_ClassID, this.strClassID);
                objIData.AddParameter(P_BirthDay, this.intBirthDay);
                objIData.AddParameter(P_BirthMonth, this.intBirthMonth);
                objIData.AddParameter(P_BirthYear, this.intBirthYear);
                objIData.AddParameter(P_BirthDateText, this.strBirthDateText);
                objIData.AddParameter(P_BirthDateTextEn, this.strBirthDateTextEn);
                objIData.AddParameter(P_Gender, this.bolGender);
                objIData.AddParameter(P_EthnicityID, this.strEthnicityID);
                objIData.AddParameter(P_ReligionID, this.strReligionID);
                objIData.AddParameter(P_BirthPlace, this.strBirthPlace);
                objIData.AddParameter(P_OriginPlace, this.strOriginPlace);
                objIData.AddParameter(P_LiveAddress, this.strLiveAddress);
                objIData.AddParameter(P_LiveProvinceID, this.strLiveProvinceID);
                objIData.AddParameter(P_LiveDistrictID, this.strLiveDistrictID);
                objIData.AddParameter(P_LiveWardID, this.strLiveWardID);
                objIData.AddParameter(P_LiveVillageID, this.strLiveVillageID);
                objIData.AddParameter(P_Tel, this.strTel);
                objIData.AddParameter(P_Email, this.strEmail);
                objIData.AddParameter(P_PersonID, this.strPersonID);
                objIData.AddParameter(P_PersionIDDate, this.dtmPersionIDDate);
                objIData.AddParameter(P_PersionIDPlace, this.strPersionIDPlace);
                objIData.AddParameter(P_AreaID, this.strAreaID);
                objIData.AddParameter(P_PreferentialObjectID, this.strPreferentialObjectID);
                objIData.AddParameter(P_PreferentialObjectID2, this.strPreferentialObjectID2);
                objIData.AddParameter(P_PreferentialObjectID3, this.strPreferentialObjectID3);
                objIData.AddParameter(P_ComponentFamilyID, this.strComponentFamilyID);
                objIData.AddParameter(P_ClassEthicMark, this.dblClassEthicMark);
                objIData.AddParameter(P_ClassEthicLevel, this.strClassEthicLevel);
                objIData.AddParameter(P_EthicMark, this.dblEthicMark);
                objIData.AddParameter(P_EthicLevel, this.strEthicLevel);
                objIData.AddParameter(P_LearningSummary, this.dblLearningSummary);
                objIData.AddParameter(P_LearningLevel, this.strLearningLevel);
                objIData.AddParameter(P_FailedSubjectCount, this.intFailedSubjectCount);
                objIData.AddParameter(P_FailedUnitTextSum, this.intFailedUnitTextSum);
                objIData.AddParameter(P_UnitTextSum, this.intUnitTextSum);
                objIData.AddParameter(P_AllowGraduateAt, this.intAllowGraduateAt);
                objIData.AddParameter(P_FatherName, this.strFatherName);
                objIData.AddParameter(P_FatherJob, this.strFatherJob);
                objIData.AddParameter(P_FatherAddress, this.strFatherAddress);
                objIData.AddParameter(P_MortherName, this.strMortherName);
                objIData.AddParameter(P_MortherJob, this.strMortherJob);
                objIData.AddParameter(P_MortherAddress, this.strMortherAddress);
                objIData.AddParameter(P_ContactName, this.strContactName);
                objIData.AddParameter(P_ContactAddress, this.strContactAddress);
                objIData.AddParameter(P_ContactTel, this.strContactTel);
                objIData.AddParameter(P_ContactName2, this.strContactName2);
                objIData.AddParameter(P_ContactAddress2, this.strContactAddress2);
                objIData.AddParameter(P_ContactTel2, this.strContactTel2);
                objIData.AddParameter(P_SubType, this.intSubType);
                objIData.AddParameter(P_IsInDorm, this.bolIsInDorm);
                objIData.AddParameter(P_LiveFromDate, this.dtmLiveFromDate);
                objIData.AddParameter(P_LiveToDate, this.dtmLiveToDate);
                objIData.AddParameter(P_SemesterMoney, this.dblSemesterMoney);
                objIData.AddParameter(P_SpecialBranchID, this.strSpecialBranchID);
                objIData.AddParameter(P_CourseID, this.strCourseID);
                objIData.AddParameter(P_GraduationLevel, this.strGraduationLevel);
                objIData.AddParameter(P_GraduationYear, this.intGraduationYear);
                objIData.AddParameter(P_GraduationSchool, this.strGraduationSchool);
                objIData.AddParameter(P_ExamStudentNumber, this.strExamStudentNumber);
                objIData.AddParameter(P_Mark1, this.dblMark1);
                objIData.AddParameter(P_Mark2, this.dblMark2);
                objIData.AddParameter(P_Mark3, this.dblMark3);
                objIData.AddParameter(P_Mark4, this.dblMark4);
                objIData.AddParameter(P_IsReceiveLearningForm, this.bolIsReceiveLearningForm);
                objIData.AddParameter(P_IsReceiveCandidateForm, this.bolIsReceiveCandidateForm);
                objIData.AddParameter(P_IsReceivePersonCer, this.bolIsReceivePersonCer);
                objIData.AddParameter(P_IsReceiveNotifyCopy, this.bolIsReceiveNotifyCopy);
                objIData.AddParameter(P_IsReceiveTranscripts, this.bolIsReceiveTranscripts);
                objIData.AddParameter(P_IsReceiveTranscripts2, this.bolIsReceiveTranscripts2);
                objIData.AddParameter(P_IsReceiveDiploma, this.bolIsReceiveDiploma);
                objIData.AddParameter(P_IsReceiveTempDiploma, this.bolIsReceiveTempDiploma);
                objIData.AddParameter(P_IsReceiveSubjectMark, this.bolIsReceiveSubjectMark);
                objIData.AddParameter(P_IsReceiveHealthCer, this.bolIsReceiveHealthCer);
                objIData.AddParameter(P_IsReceiveWorkingCer, this.bolIsReceiveWorkingCer);
                objIData.AddParameter(P_IsReceived, this.bolIsReceived);
                objIData.AddParameter(P_IsReceiveAssure, this.bolIsReceiveAssure);
                objIData.AddParameter(P_IsReceivePreferentialObjectCer, this.bolIsReceivePreferentialObjectCer);
                objIData.AddParameter(P_IsReceiveImage, this.bolIsReceiveImage);
                objIData.AddParameter(P_IsReceiveMoney, this.bolIsReceiveMoney);
                objIData.AddParameter(P_IsUnionCard, this.bolIsUnionCard);
                objIData.AddParameter(P_IsUnionBook, this.bolIsUnionBook);
                objIData.AddParameter(P_IsOkCollection, this.bolIsOkCollection);
                objIData.AddParameter(P_Image, this.strImage);
                objIData.AddParameter(P_Status, this.intStatus);
                objIData.AddParameter(P_SourceInfoID, this.intSourceInfoID);
                objIData.AddParameter(P_Funds, this.lngFunds);
                objIData.AddParameter(P_Budget, this.lngBudget);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_OrderIndex, this.lngOrderIndex);
                objIData.AddParameter(P_ReceivedDate, this.dtmReceivedDate);
                objIData.AddParameter(P_RealLearningDate, this.dtmRealLearningDate);
                objIData.AddParameter(P_StudentCollectionID, this.lngStudentCollectionID);
                objIData.AddParameter(P_StudentPositionID, this.intStudentPositionID);
                objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
                objIData.AddParameter(P_TempClass1, this.strTempClass1);
                objIData.AddParameter(P_TempClass2, this.strTempClass2);
                objIData.AddParameter(P_TempClass3, this.strTempClass3);
                objIData.AddParameter(P_System, this.strSystem);
                objIData.AddParameter(P_GroupSmallClassRegister, this.intGroupSmallClassRegister);
                this.lngStudentID = Convert.ToInt32(objIData.ExecStoreToString());
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_Student", objEx);
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
        /// Update : SIM_Student
        /// Cập nhật dữ liệu
        /// Store: SIM_Student_EDIT 
        ///</summary>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Student_EDIT");
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_StudentCode, this.strStudentCode);
                objIData.AddParameter(P_StudentFirstName, this.strStudentFirstName);
                objIData.AddParameter(P_StudentLastName, this.strStudentLastName);
                objIData.AddParameter(P_FullnameEn, this.strFullnameEn);
                objIData.AddParameter(P_ClassID, this.strClassID);
                objIData.AddParameter(P_BirthDay, this.intBirthDay);
                objIData.AddParameter(P_BirthMonth, this.intBirthMonth);
                objIData.AddParameter(P_BirthYear, this.intBirthYear);
                objIData.AddParameter(P_BirthDateText, this.strBirthDateText);
                objIData.AddParameter(P_BirthDateTextEn, this.strBirthDateTextEn);
                objIData.AddParameter(P_Gender, this.bolGender);
                objIData.AddParameter(P_EthnicityID, this.strEthnicityID);
                objIData.AddParameter(P_ReligionID, this.strReligionID);
                objIData.AddParameter(P_BirthPlace, this.strBirthPlace);
                objIData.AddParameter(P_OriginPlace, this.strOriginPlace);
                objIData.AddParameter(P_LiveAddress, this.strLiveAddress);
                objIData.AddParameter(P_LiveProvinceID, this.strLiveProvinceID);
                objIData.AddParameter(P_LiveDistrictID, this.strLiveDistrictID);
                objIData.AddParameter(P_LiveWardID, this.strLiveWardID);
                objIData.AddParameter(P_LiveVillageID, this.strLiveVillageID);
                objIData.AddParameter(P_Tel, this.strTel);
                objIData.AddParameter(P_Email, this.strEmail);
                objIData.AddParameter(P_PersonID, this.strPersonID);
                objIData.AddParameter(P_PersionIDDate, this.dtmPersionIDDate);
                objIData.AddParameter(P_PersionIDPlace, this.strPersionIDPlace);
                objIData.AddParameter(P_AreaID, this.strAreaID);
                objIData.AddParameter(P_PreferentialObjectID, this.strPreferentialObjectID);
                objIData.AddParameter(P_PreferentialObjectID2, this.strPreferentialObjectID2);
                objIData.AddParameter(P_PreferentialObjectID3, this.strPreferentialObjectID3);
                objIData.AddParameter(P_ComponentFamilyID, this.strComponentFamilyID);
                objIData.AddParameter(P_ClassEthicMark, this.dblClassEthicMark);
                objIData.AddParameter(P_ClassEthicLevel, this.strClassEthicLevel);
                objIData.AddParameter(P_EthicMark, this.dblEthicMark);
                objIData.AddParameter(P_EthicLevel, this.strEthicLevel);
                objIData.AddParameter(P_LearningSummary, this.dblLearningSummary);
                objIData.AddParameter(P_LearningLevel, this.strLearningLevel);
                objIData.AddParameter(P_FailedSubjectCount, this.intFailedSubjectCount);
                objIData.AddParameter(P_FailedUnitTextSum, this.intFailedUnitTextSum);
                objIData.AddParameter(P_UnitTextSum, this.intUnitTextSum);
                objIData.AddParameter(P_AllowGraduateAt, this.intAllowGraduateAt);
                objIData.AddParameter(P_FatherName, this.strFatherName);
                objIData.AddParameter(P_FatherJob, this.strFatherJob);
                objIData.AddParameter(P_FatherAddress, this.strFatherAddress);
                objIData.AddParameter(P_MortherName, this.strMortherName);
                objIData.AddParameter(P_MortherJob, this.strMortherJob);
                objIData.AddParameter(P_MortherAddress, this.strMortherAddress);
                objIData.AddParameter(P_ContactName, this.strContactName);
                objIData.AddParameter(P_ContactAddress, this.strContactAddress);
                objIData.AddParameter(P_ContactTel, this.strContactTel);
                objIData.AddParameter(P_ContactName2, this.strContactName2);
                objIData.AddParameter(P_ContactAddress2, this.strContactAddress2);
                objIData.AddParameter(P_ContactTel2, this.strContactTel2);
                objIData.AddParameter(P_SubType, this.intSubType);
                objIData.AddParameter(P_IsInDorm, this.bolIsInDorm);
                objIData.AddParameter(P_LiveFromDate, this.dtmLiveFromDate);
                objIData.AddParameter(P_LiveToDate, this.dtmLiveToDate);
                objIData.AddParameter(P_SemesterMoney, this.dblSemesterMoney);
                objIData.AddParameter(P_SpecialBranchID, this.strSpecialBranchID);
                objIData.AddParameter(P_CourseID, this.strCourseID);
                objIData.AddParameter(P_GraduationLevel, this.strGraduationLevel);
                objIData.AddParameter(P_GraduationYear, this.intGraduationYear);
                objIData.AddParameter(P_GraduationSchool, this.strGraduationSchool);
                objIData.AddParameter(P_ExamStudentNumber, this.strExamStudentNumber);
                objIData.AddParameter(P_Mark1, this.dblMark1);
                objIData.AddParameter(P_Mark2, this.dblMark2);
                objIData.AddParameter(P_Mark3, this.dblMark3);
                objIData.AddParameter(P_Mark4, this.dblMark4);
                objIData.AddParameter(P_IsReceiveLearningForm, this.bolIsReceiveLearningForm);
                objIData.AddParameter(P_IsReceiveCandidateForm, this.bolIsReceiveCandidateForm);
                objIData.AddParameter(P_IsReceivePersonCer, this.bolIsReceivePersonCer);
                objIData.AddParameter(P_IsReceiveNotifyCopy, this.bolIsReceiveNotifyCopy);
                objIData.AddParameter(P_IsReceiveTranscripts, this.bolIsReceiveTranscripts);
                objIData.AddParameter(P_IsReceiveTranscripts2, this.bolIsReceiveTranscripts2);
                objIData.AddParameter(P_IsReceiveDiploma, this.bolIsReceiveDiploma);
                objIData.AddParameter(P_IsReceiveTempDiploma, this.bolIsReceiveTempDiploma);
                objIData.AddParameter(P_IsReceiveSubjectMark, this.bolIsReceiveSubjectMark);
                objIData.AddParameter(P_IsReceiveHealthCer, this.bolIsReceiveHealthCer);
                objIData.AddParameter(P_IsReceiveWorkingCer, this.bolIsReceiveWorkingCer);
                objIData.AddParameter(P_IsReceived, this.bolIsReceived);
                objIData.AddParameter(P_IsReceiveAssure, this.bolIsReceiveAssure);
                objIData.AddParameter(P_IsReceivePreferentialObjectCer, this.bolIsReceivePreferentialObjectCer);
                objIData.AddParameter(P_IsReceiveImage, this.bolIsReceiveImage);
                objIData.AddParameter(P_IsReceiveMoney, this.bolIsReceiveMoney);
                objIData.AddParameter(P_IsUnionCard, this.bolIsUnionCard);
                objIData.AddParameter(P_IsUnionBook, this.bolIsUnionBook);
                objIData.AddParameter(P_IsOkCollection, this.bolIsOkCollection);
                objIData.AddParameter(P_Image, this.strImage);
                objIData.AddParameter(P_Status, this.intStatus);
                objIData.AddParameter(P_SourceInfoID, this.intSourceInfoID);
                objIData.AddParameter(P_Funds, this.lngFunds);
                objIData.AddParameter(P_Budget, this.lngBudget);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_OrderIndex, this.lngOrderIndex);
                objIData.AddParameter(P_ReceivedDate, this.dtmReceivedDate);
                objIData.AddParameter(P_RealLearningDate, this.dtmRealLearningDate);
                objIData.AddParameter(P_StudentCollectionID, this.lngStudentCollectionID);
                objIData.AddParameter(P_StudentPositionID, this.intStudentPositionID);
                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
                objIData.AddParameter(P_TempClass1, this.strTempClass1);
                objIData.AddParameter(P_TempClass2, this.strTempClass2);
                objIData.AddParameter(P_TempClass3, this.strTempClass3);
                objIData.AddParameter(P_System, this.strSystem);
                objIData.AddParameter(P_GroupSmallClassRegister, this.intGroupSmallClassRegister);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_Student", objEx);
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
        /// Delete : SIM_Student
        /// Xóa dữ liệu
        /// Store: SIM_Student_DELETE 
        ///</summary>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Student_DELETE");
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_DeletedUser, this.strDeletedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_Student", objEx);
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
        /// Store: SIM_Student_DELETE 
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long? lngStudentID, string strDeletedUser)
        {
            this.lngStudentID = lngStudentID;
            this.strDeletedUser = strDeletedUser;
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

        public SIM_Student()
        {
        }
        public SIM_Student(long? lngStudentID)
        {
            this.lngStudentID = lngStudentID;
            this.Get();
        }

        #endregion

        #region Variable Static

        #region Parameter Names

        public const String P_StudentID = "@" + C_StudentID;
        public const String P_StudentCode = "@" + C_StudentCode;
        public const String P_StudentFirstName = "@" + C_StudentFirstName;
        public const String P_StudentLastName = "@" + C_StudentLastName;
        public const String P_FullnameEn = "@" + C_FullnameEn;
        public const String P_ClassID = "@" + C_ClassID;
        public const String P_BirthDay = "@" + C_BirthDay;
        public const String P_BirthMonth = "@" + C_BirthMonth;
        public const String P_BirthYear = "@" + C_BirthYear;
        public const String P_BirthDateText = "@" + C_BirthDateText;
        public const String P_BirthDateTextEn = "@" + C_BirthDateTextEn;
        public const String P_Gender = "@" + C_Gender;
        public const String P_EthnicityID = "@" + C_EthnicityID;
        public const String P_ReligionID = "@" + C_ReligionID;
        public const String P_BirthPlace = "@" + C_BirthPlace;
        public const String P_OriginPlace = "@" + C_OriginPlace;
        public const String P_LiveAddress = "@" + C_LiveAddress;
        public const String P_LiveProvinceID = "@" + C_LiveProvinceID;
        public const String P_LiveDistrictID = "@" + C_LiveDistrictID;
        public const String P_LiveWardID = "@" + C_LiveWardID;
        public const String P_LiveVillageID = "@" + C_LiveVillageID;
        public const String P_Tel = "@" + C_Tel;
        public const String P_Email = "@" + C_Email;
        public const String P_PersonID = "@" + C_PersonID;
        public const String P_PersionIDDate = "@" + C_PersionIDDate;
        public const String P_PersionIDPlace = "@" + C_PersionIDPlace;
        public const String P_AreaID = "@" + C_AreaID;
        public const String P_PreferentialObjectID = "@" + C_PreferentialObjectID;
        public const String P_PreferentialObjectID2 = "@" + C_PreferentialObjectID2;
        public const String P_PreferentialObjectID3 = "@" + C_PreferentialObjectID3;
        public const String P_ComponentFamilyID = "@" + C_ComponentFamilyID;
        public const String P_ClassEthicMark = "@" + C_ClassEthicMark;
        public const String P_ClassEthicLevel = "@" + C_ClassEthicLevel;
        public const String P_EthicMark = "@" + C_EthicMark;
        public const String P_EthicLevel = "@" + C_EthicLevel;
        public const String P_LearningSummary = "@" + C_LearningSummary;
        public const String P_LearningLevel = "@" + C_LearningLevel;
        public const String P_FailedSubjectCount = "@" + C_FailedSubjectCount;
        public const String P_FailedUnitTextSum = "@" + C_FailedUnitTextSum;
        public const String P_UnitTextSum = "@" + C_UnitTextSum;
        public const String P_AllowGraduateAt = "@" + C_AllowGraduateAt;
        public const String P_FatherName = "@" + C_FatherName;
        public const String P_FatherJob = "@" + C_FatherJob;
        public const String P_FatherAddress = "@" + C_FatherAddress;
        public const String P_MortherName = "@" + C_MortherName;
        public const String P_MortherJob = "@" + C_MortherJob;
        public const String P_MortherAddress = "@" + C_MortherAddress;
        public const String P_ContactName = "@" + C_ContactName;
        public const String P_ContactAddress = "@" + C_ContactAddress;
        public const String P_ContactTel = "@" + C_ContactTel;
        public const String P_ContactName2 = "@" + C_ContactName2;
        public const String P_ContactAddress2 = "@" + C_ContactAddress2;
        public const String P_ContactTel2 = "@" + C_ContactTel2;
        public const String P_SubType = "@" + C_SubType;
        public const String P_IsInDorm = "@" + C_IsInDorm;
        public const String P_LiveFromDate = "@" + C_LiveFromDate;
        public const String P_LiveToDate = "@" + C_LiveToDate;
        public const String P_SemesterMoney = "@" + C_SemesterMoney;
        public const String P_SpecialBranchID = "@" + C_SpecialBranchID;
        public const String P_CourseID = "@" + C_CourseID;
        public const String P_GraduationLevel = "@" + C_GraduationLevel;
        public const String P_GraduationYear = "@" + C_GraduationYear;
        public const String P_GraduationSchool = "@" + C_GraduationSchool;
        public const String P_ExamStudentNumber = "@" + C_ExamStudentNumber;
        public const String P_Mark1 = "@" + C_Mark1;
        public const String P_Mark2 = "@" + C_Mark2;
        public const String P_Mark3 = "@" + C_Mark3;
        public const String P_Mark4 = "@" + C_Mark4;
        public const String P_IsReceiveLearningForm = "@" + C_IsReceiveLearningForm;
        public const String P_IsReceiveCandidateForm = "@" + C_IsReceiveCandidateForm;
        public const String P_IsReceivePersonCer = "@" + C_IsReceivePersonCer;
        public const String P_IsReceiveNotifyCopy = "@" + C_IsReceiveNotifyCopy;
        public const String P_IsReceiveTranscripts = "@" + C_IsReceiveTranscripts;
        public const String P_IsReceiveTranscripts2 = "@" + C_IsReceiveTranscripts2;
        public const String P_IsReceiveDiploma = "@" + C_IsReceiveDiploma;
        public const String P_IsReceiveTempDiploma = "@" + C_IsReceiveTempDiploma;
        public const String P_IsReceiveSubjectMark = "@" + C_IsReceiveSubjectMark;
        public const String P_IsReceiveHealthCer = "@" + C_IsReceiveHealthCer;
        public const String P_IsReceiveWorkingCer = "@" + C_IsReceiveWorkingCer;
        public const String P_IsReceived = "@" + C_IsReceived;
        public const String P_IsReceiveAssure = "@" + C_IsReceiveAssure;
        public const String P_IsReceivePreferentialObjectCer = "@" + C_IsReceivePreferentialObjectCer;
        public const String P_IsReceiveImage = "@" + C_IsReceiveImage;
        public const String P_IsReceiveMoney = "@" + C_IsReceiveMoney;
        public const String P_IsUnionCard = "@" + C_IsUnionCard;
        public const String P_IsUnionBook = "@" + C_IsUnionBook;
        public const String P_IsOkCollection = "@" + C_IsOkCollection;
        public const String P_Image = "@" + C_Image;
        public const String P_Status = "@" + C_Status;
        public const String P_SourceInfoID = "@" + C_SourceInfoID;
        public const String P_Funds = "@" + C_Funds;
        public const String P_Budget = "@" + C_Budget;
        public const String P_Description = "@" + C_Description;
        public const String P_OrderIndex = "@" + C_OrderIndex;
        public const String P_ReceivedDate = "@" + C_ReceivedDate;
        public const String P_RealLearningDate = "@" + C_RealLearningDate;
        public const String P_StudentCollectionID = "@" + C_StudentCollectionID;
        public const String P_StudentPositionID = "@" + C_StudentPositionID;
        public const String P_CreatedDate = "@" + C_CreatedDate;
        public const String P_CreatedUser = "@" + C_CreatedUser;
        public const String P_UpdatedDate = "@" + C_UpdatedDate;
        public const String P_UpdatedUser = "@" + C_UpdatedUser;
        public const String P_IsDeleted = "@" + C_IsDeleted;
        public const String P_DeletedDate = "@" + C_DeletedDate;
        public const String P_DeletedUser = "@" + C_DeletedUser;
        public const String P_TempClass1 = "@" + C_TempClass1;
        public const String P_TempClass2 = "@" + C_TempClass2;
        public const String P_TempClass3 = "@" + C_TempClass3;
        public const String P_System = "@" + C_System;
        public const String P_GroupSmallClassRegister = "@" + C_GroupSmallClassRegister;

        #endregion //Parameter names

        #region Column Names

        public const String C_StudentID = "StudentID";
        public const String C_StudentCode = "StudentCode";
        public const String C_StudentFirstName = "StudentFirstName";
        public const String C_StudentLastName = "StudentLastName";
        public const String C_FullnameEn = "FullnameEn";
        public const String C_ClassID = "ClassID";
        public const String C_BirthDay = "BirthDay";
        public const String C_BirthMonth = "BirthMonth";
        public const String C_BirthYear = "BirthYear";
        public const String C_BirthDateText = "BirthDateText";
        public const String C_BirthDateTextEn = "BirthDateTextEn";
        public const String C_Gender = "Gender";
        public const String C_EthnicityID = "EthnicityID";
        public const String C_ReligionID = "ReligionID";
        public const String C_BirthPlace = "BirthPlace";
        public const String C_OriginPlace = "OriginPlace";
        public const String C_LiveAddress = "LiveAddress";
        public const String C_LiveProvinceID = "LiveProvinceID";
        public const String C_LiveDistrictID = "LiveDistrictID";
        public const String C_LiveWardID = "LiveWardID";
        public const String C_LiveVillageID = "LiveVillageID";
        public const String C_Tel = "Tel";
        public const String C_Email = "Email";
        public const String C_PersonID = "PersonID";
        public const String C_PersionIDDate = "PersionIDDate";
        public const String C_PersionIDPlace = "PersionIDPlace";
        public const String C_AreaID = "AreaID";
        public const String C_PreferentialObjectID = "PreferentialObjectID";
        public const String C_PreferentialObjectID2 = "PreferentialObjectID2";
        public const String C_PreferentialObjectID3 = "PreferentialObjectID3";
        public const String C_ComponentFamilyID = "ComponentFamilyID";
        public const String C_ClassEthicMark = "ClassEthicMark";
        public const String C_ClassEthicLevel = "ClassEthicLevel";
        public const String C_EthicMark = "EthicMark";
        public const String C_EthicLevel = "EthicLevel";
        public const String C_LearningSummary = "LearningSummary";
        public const String C_LearningLevel = "LearningLevel";
        public const String C_FailedSubjectCount = "FailedSubjectCount";
        public const String C_FailedUnitTextSum = "FailedUnitTextSum";
        public const String C_UnitTextSum = "UnitTextSum";
        public const String C_AllowGraduateAt = "AllowGraduateAt";
        public const String C_FatherName = "FatherName";
        public const String C_FatherJob = "FatherJob";
        public const String C_FatherAddress = "FatherAddress";
        public const String C_MortherName = "MortherName";
        public const String C_MortherJob = "MortherJob";
        public const String C_MortherAddress = "MortherAddress";
        public const String C_ContactName = "ContactName";
        public const String C_ContactAddress = "ContactAddress";
        public const String C_ContactTel = "ContactTel";
        public const String C_ContactName2 = "ContactName2";
        public const String C_ContactAddress2 = "ContactAddress2";
        public const String C_ContactTel2 = "ContactTel2";
        public const String C_SubType = "SubType";
        public const String C_IsInDorm = "IsInDorm";
        public const String C_LiveFromDate = "LiveFromDate";
        public const String C_LiveToDate = "LiveToDate";
        public const String C_SemesterMoney = "SemesterMoney";
        public const String C_SpecialBranchID = "SpecialBranchID";
        public const String C_CourseID = "CourseID";
        public const String C_GraduationLevel = "GraduationLevel";
        public const String C_GraduationYear = "GraduationYear";
        public const String C_GraduationSchool = "GraduationSchool";
        public const String C_ExamStudentNumber = "ExamStudentNumber";
        public const String C_Mark1 = "Mark1";
        public const String C_Mark2 = "Mark2";
        public const String C_Mark3 = "Mark3";
        public const String C_Mark4 = "Mark4";
        public const String C_IsReceiveLearningForm = "IsReceiveLearningForm";
        public const String C_IsReceiveCandidateForm = "IsReceiveCandidateForm";
        public const String C_IsReceivePersonCer = "IsReceivePersonCer";
        public const String C_IsReceiveNotifyCopy = "IsReceiveNotifyCopy";
        public const String C_IsReceiveTranscripts = "IsReceiveTranscripts";
        public const String C_IsReceiveTranscripts2 = "IsReceiveTranscripts2";
        public const String C_IsReceiveDiploma = "IsReceiveDiploma";
        public const String C_IsReceiveTempDiploma = "IsReceiveTempDiploma";
        public const String C_IsReceiveSubjectMark = "IsReceiveSubjectMark";
        public const String C_IsReceiveHealthCer = "IsReceiveHealthCer";
        public const String C_IsReceiveWorkingCer = "IsReceiveWorkingCer";
        public const String C_IsReceived = "IsReceived";
        public const String C_IsReceiveAssure = "IsReceiveAssure";
        public const String C_IsReceivePreferentialObjectCer = "IsReceivePreferentialObjectCer";
        public const String C_IsReceiveImage = "IsReceiveImage";
        public const String C_IsReceiveMoney = "IsReceiveMoney";
        public const String C_IsUnionCard = "IsUnionCard";
        public const String C_IsUnionBook = "IsUnionBook";
        public const String C_IsOkCollection = "IsOkCollection";
        public const String C_Image = "Image";
        public const String C_Status = "Status";
        public const String C_SourceInfoID = "SourceInfoID";
        public const String C_Funds = "Funds";
        public const String C_Budget = "Budget";
        public const String C_Description = "Description";
        public const String C_OrderIndex = "OrderIndex";
        public const String C_ReceivedDate = "ReceivedDate";
        public const String C_RealLearningDate = "RealLearningDate";
        public const String C_StudentCollectionID = "StudentCollectionID";
        public const String C_StudentPositionID = "StudentPositionID";
        public const String C_CreatedDate = "CreatedDate";
        public const String C_CreatedUser = "CreatedUser";
        public const String C_UpdatedDate = "UpdatedDate";
        public const String C_UpdatedUser = "UpdatedUser";
        public const String C_IsDeleted = "IsDeleted";
        public const String C_DeletedDate = "DeletedDate";
        public const String C_DeletedUser = "DeletedUser";
        public const String C_TempClass1 = "TempClass1";
        public const String C_TempClass2 = "TempClass2";
        public const String C_TempClass3 = "TempClass3";
        public const String C_System = "System";
        public const String C_GroupSmallClassRegister = "GroupSmallClassRegister";

        #endregion //Column names

        #endregion Variable Static
    }
}


