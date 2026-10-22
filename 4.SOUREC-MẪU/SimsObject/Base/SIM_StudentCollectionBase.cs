
#region Using

using System;
using System.Data;
using System.Collections;
using DCore;

#endregion

namespace SimsObject
{
    /// <summary>
    /// Created by 		: YourName 
    /// Created date 	: 12/18/2016 
    /// Description 
    /// </summary>	
    public partial class SIM_StudentCollection
    {
        #region Member Variables

        private long? lngStudentCollectionID = null;//Mã hồ sơ tuyển sinh
        private string strStudentCollectionPeriodID = null;//Mã đợt tuyển sinh
        private string strExamStudentNumber = null;//Số báo danh thi tuyển sinh
        private string strStudentFirstName = null;
        private string strStudentLastName = null;
        private string strFullnameEn = null;
        private int? intBirthDay = null;//Ngày sinh
        private int? intBirthMonth = null;//Tháng sinh
        private int? intBirthYear = null;//Năm sinh
        private string strBirthDateText = null;//Ngày tháng năm sinh tổ hợp từ 3 giá trị trên
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
        private string strContactName = null;//Tên chủ người liên lạc
        private string strContactAddress = null;//Địa chỉ liên lạc
        private string strContactTel = null;//Điện thoại liên lạc
        private string strComponentFamilyID = null;//Mã thành phần gia đình
        private string strAreaID = null;//Mã Khu vực GEN_Area
        private string strPreferentialObjectID = null;//Mã Đối tượng ưu đãi
        private int? intGraduationYear = null;//Năm tốt nghiệp; ví dụ 2011
        private string strSystem = null;//Hệ (A,B)
        private int? intLevelStudentID = null;//Mã trình độ học vấn
        private double? dblMark1 = null;//Điểm thi tuyển sinh môn 1
        private double? dblMark2 = null;//Điểm thi tuyển sinh môn 2
        private double? dblMark3 = null;//Điểm thi tuyển sinh môn 3
        private double? dblMark4 = null;//Điểm thi môn 4
        private double? dblMark5 = null;
        private double? dblMark6 = null;
        private double? dblMark7 = null;
        private double? dblSummaryMark = null;//Tổng điểm xét tuyển
        private double? dblEthicMark = null;//Tổng điểm rèn luyện
        private string strSpecialBranchID = null;//Mã chuyên ngành NV1
        private string strSpecialBranchID2 = null;//Mã chuyên ngành NV2
        private bool bolIsReceiveDiploma = false;//Có nhận bằng tốt nghiệp
        private bool bolIsReceiveTempDiploma = false;//Có nhận giấy CNTN Tạm thời
        private bool bolIsReceiveImage = false;//Có nhận ảnh
        private bool bolIsReceiveCandidateForm = false;//Có nhận đơn dự tuyển/ Phiếu đăng ký học nghề
        private bool bolIsReceiveTranscripts = false;//Có nhận học bạ
        private bool bolIsReceiveHousehold = false;//Có nhận hộ khẩu
        private bool bolIsReceiveHealthCer = false;//Có nhận Giấy khám sức khỏe
        private bool bolIsReceivePreferentialObjectCer = false;//Đã nhận giấy chứng nhận ưu tiên
        private bool bolIsReceiveNotifyCopy = false;//Có nhận bản sao khai sanh
        private bool bolIsReceiveAssure = false;//Có nhận giấy cam đoan
        private bool bolIsReceived = false;//Đã nhận hồ sơ (Đã nộp hồ sơ)
        private DateTime? dtmReceiveDate = null;//Ngày nhập hồ sơ
        private string strReceiveUser = null;//Người nhận hồ sơ
        private bool bolIsSendNotice = false;//Đã gởi giấy báo
        private DateTime? dtmCreatedDate = null;//Ngày tạo
        private string strCreatedUser = null;//Người tạo
        private DateTime? dtmUpdatedDate = null;//Ngày cập nhật cuối
        private string strUpdatedUser = null;//Người cập nhật cuối
        private bool bolIsDeleted = false;
        private DateTime? dtmDeletedDate = null;
        private string strDeletedUser = null;
        private string strStudentCollectionCode = null;//Số hồ sơ
        private string strFatherName = null;//Tên cha
        private string strFatherJob = null;//Nghề nghiệp cha
        private string strFatherAddress = null;//Địa chỉ cha
        private string strMortherName = null;//Tên mẹ
        private string strMortherJob = null;//Nghề nghiệp mẹ
        private string strMortherAddress = null;//Địa chỉ mẹ
        private int? intGraduationLevel = null;//Loại bằng TN nghề: 1.SX, 2. Gỏi, 3. Khá, 4. TB khá, 5. TB
        private int? intExperience = null;//Số năm kinh nghiệm
        private string strSpecialBranchID3 = null;//Mã chuyên ngành NV3
        private int? intResult = null;//Đã đạt (trúng truyển) nguyện vọng mấy. 1.2.3 (=0 là không đạt hoặc chưa xét)
        private string strPreferentialObjectID2 = null;//Mã Đối tượng ưu đãi
        private string strPreferentialObjectID3 = null;//Mã Đối tượng ưu đãi
        private string strContactEmail = null;
        private bool bolIsReceivePersonCer = false;//Có nhận CMND
        private bool bolIsReceivePersonInfo = false;//Có nhận sơ yếu lý lịch
        private bool bolIsDeptDiploma = false;//Nợ THPT
        private string strCerNo = null;//Số thứ tự hồ sơ in ra
        private string strDescription = null;
        private string strEthicLevel1 = null;
        private string strEthicLevel2 = null;
        private string strEthicLevel3 = null;
        private string strEthicLevel4 = null;
        private string strEthicLevel5 = null;
        private string strEthicLevel6 = null;
        private string strEthicLevel7 = null;
        private string strSpecialBranchIDOk = null;//Nguyện vọng trúng tuyển
        private string strGraduationSchool = null;//Trường tốt nghiệp, địa chỉ, tỉnh thành,...
        private DateTime? dtmLiveDate = null;//Ngày nhập khẩu
        private int? intCompanyID = null;//Mã công ty (Học viên là người của cty đưa đến học)
        private string strRegisterPerson = null;//Người làm đăng ký cho hồ sơ này
        private string strUnits = null;//đơn vị của người nộp hồ sơ này
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

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
        /// StudentCollectionPeriodID
        /// Mã đợt tuyển sinh
        /// </summary>
        public string StudentCollectionPeriodID
        {
            get { return strStudentCollectionPeriodID; }
            set { strStudentCollectionPeriodID = value; }
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
        /// ComponentFamilyID
        /// Mã thành phần gia đình
        /// </summary>
        public string ComponentFamilyID
        {
            get { return strComponentFamilyID; }
            set { strComponentFamilyID = value; }
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
        /// GraduationYear
        /// Năm tốt nghiệp; ví dụ 2011
        /// </summary>
        public int? GraduationYear
        {
            get { return intGraduationYear; }
            set { intGraduationYear = value; }
        }
        /// <summary>
        /// System
        /// Hệ (A,B)
        /// </summary>
        public string System
        {
            get { return strSystem; }
            set { strSystem = value; }
        }
        /// <summary>
        /// LevelStudentID
        /// Mã trình độ học vấn
        /// </summary>
        public int? LevelStudentID
        {
            get { return intLevelStudentID; }
            set { intLevelStudentID = value; }
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
        /// Điểm thi môn 4
        /// </summary>
        public double? Mark4
        {
            get { return dblMark4; }
            set { dblMark4 = value; }
        }
        /// <summary>
        /// Mark5
        /// 
        /// </summary>
        public double? Mark5
        {
            get { return dblMark5; }
            set { dblMark5 = value; }
        }
        /// <summary>
        /// Mark6
        /// 
        /// </summary>
        public double? Mark6
        {
            get { return dblMark6; }
            set { dblMark6 = value; }
        }
        /// <summary>
        /// Mark7
        /// 
        /// </summary>
        public double? Mark7
        {
            get { return dblMark7; }
            set { dblMark7 = value; }
        }
        /// <summary>
        /// SummaryMark
        /// Tổng điểm xét tuyển
        /// </summary>
        public double? SummaryMark
        {
            get { return dblSummaryMark; }
            set { dblSummaryMark = value; }
        }
        /// <summary>
        /// EthicMark
        /// Tổng điểm rèn luyện
        /// </summary>
        public double? EthicMark
        {
            get { return dblEthicMark; }
            set { dblEthicMark = value; }
        }
        /// <summary>
        /// SpecialBranchID
        /// Mã chuyên ngành NV1
        /// </summary>
        public string SpecialBranchID
        {
            get { return strSpecialBranchID; }
            set { strSpecialBranchID = value; }
        }
        /// <summary>
        /// SpecialBranchID2
        /// Mã chuyên ngành NV2
        /// </summary>
        public string SpecialBranchID2
        {
            get { return strSpecialBranchID2; }
            set { strSpecialBranchID2 = value; }
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
        /// IsReceiveImage
        /// Có nhận ảnh
        /// </summary>
        public bool IsReceiveImage
        {
            get { return bolIsReceiveImage; }
            set { bolIsReceiveImage = value; }
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
        /// IsReceiveTranscripts
        /// Có nhận học bạ
        /// </summary>
        public bool IsReceiveTranscripts
        {
            get { return bolIsReceiveTranscripts; }
            set { bolIsReceiveTranscripts = value; }
        }
        /// <summary>
        /// IsReceiveHousehold
        /// Có nhận hộ khẩu
        /// </summary>
        public bool IsReceiveHousehold
        {
            get { return bolIsReceiveHousehold; }
            set { bolIsReceiveHousehold = value; }
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
        /// IsReceivePreferentialObjectCer
        /// Đã nhận giấy chứng nhận ưu tiên
        /// </summary>
        public bool IsReceivePreferentialObjectCer
        {
            get { return bolIsReceivePreferentialObjectCer; }
            set { bolIsReceivePreferentialObjectCer = value; }
        }
        /// <summary>
        /// IsReceiveNotifyCopy
        /// Có nhận bản sao khai sanh
        /// </summary>
        public bool IsReceiveNotifyCopy
        {
            get { return bolIsReceiveNotifyCopy; }
            set { bolIsReceiveNotifyCopy = value; }
        }
        /// <summary>
        /// IsReceiveAssure
        /// Có nhận giấy cam đoan
        /// </summary>
        public bool IsReceiveAssure
        {
            get { return bolIsReceiveAssure; }
            set { bolIsReceiveAssure = value; }
        }
        /// <summary>
        /// IsReceived
        /// Đã nhận hồ sơ (Đã nộp hồ sơ)
        /// </summary>
        public bool IsReceived
        {
            get { return bolIsReceived; }
            set { bolIsReceived = value; }
        }
        /// <summary>
        /// ReceiveDate
        /// Ngày nhập hồ sơ
        /// </summary>
        public DateTime? ReceiveDate
        {
            get { return dtmReceiveDate; }
            set { dtmReceiveDate = value; }
        }
        /// <summary>
        /// ReceiveUser
        /// Người nhận hồ sơ
        /// </summary>
        public string ReceiveUser
        {
            get { return strReceiveUser; }
            set { strReceiveUser = value; }
        }
        /// <summary>
        /// IsSendNotice
        /// Đã gởi giấy báo
        /// </summary>
        public bool IsSendNotice
        {
            get { return bolIsSendNotice; }
            set { bolIsSendNotice = value; }
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
        /// StudentCollectionCode
        /// Số hồ sơ
        /// </summary>
        public string StudentCollectionCode
        {
            get { return strStudentCollectionCode; }
            set { strStudentCollectionCode = value; }
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
        /// GraduationLevel
        /// Loại bằng TN nghề: 1.SX, 2. Gỏi, 3. Khá, 4. TB khá, 5. TB
        /// </summary>
        public int? GraduationLevel
        {
            get { return intGraduationLevel; }
            set { intGraduationLevel = value; }
        }
        /// <summary>
        /// Experience
        /// Số năm kinh nghiệm
        /// </summary>
        public int? Experience
        {
            get { return intExperience; }
            set { intExperience = value; }
        }
        /// <summary>
        /// SpecialBranchID3
        /// Mã chuyên ngành NV3
        /// </summary>
        public string SpecialBranchID3
        {
            get { return strSpecialBranchID3; }
            set { strSpecialBranchID3 = value; }
        }
        /// <summary>
        /// Result
        /// Đã đạt (trúng truyển) nguyện vọng mấy. 1.2.3 (=0 là không đạt hoặc chưa xét)
        /// </summary>
        public int? Result
        {
            get { return intResult; }
            set { intResult = value; }
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
        /// ContactEmail
        /// 
        /// </summary>
        public string ContactEmail
        {
            get { return strContactEmail; }
            set { strContactEmail = value; }
        }
        /// <summary>
        /// IsReceivePersonCer
        /// Có nhận CMND
        /// </summary>
        public bool IsReceivePersonCer
        {
            get { return bolIsReceivePersonCer; }
            set { bolIsReceivePersonCer = value; }
        }
        /// <summary>
        /// IsReceivePersonInfo
        /// Có nhận sơ yếu lý lịch
        /// </summary>
        public bool IsReceivePersonInfo
        {
            get { return bolIsReceivePersonInfo; }
            set { bolIsReceivePersonInfo = value; }
        }
        /// <summary>
        /// IsDeptDiploma
        /// Nợ THPT
        /// </summary>
        public bool IsDeptDiploma
        {
            get { return bolIsDeptDiploma; }
            set { bolIsDeptDiploma = value; }
        }
        /// <summary>
        /// CerNo
        /// Số thứ tự hồ sơ in ra
        /// </summary>
        public string CerNo
        {
            get { return strCerNo; }
            set { strCerNo = value; }
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
        /// EthicLevel1
        /// 
        /// </summary>
        public string EthicLevel1
        {
            get { return strEthicLevel1; }
            set { strEthicLevel1 = value; }
        }
        /// <summary>
        /// EthicLevel2
        /// 
        /// </summary>
        public string EthicLevel2
        {
            get { return strEthicLevel2; }
            set { strEthicLevel2 = value; }
        }
        /// <summary>
        /// EthicLevel3
        /// 
        /// </summary>
        public string EthicLevel3
        {
            get { return strEthicLevel3; }
            set { strEthicLevel3 = value; }
        }
        /// <summary>
        /// EthicLevel4
        /// 
        /// </summary>
        public string EthicLevel4
        {
            get { return strEthicLevel4; }
            set { strEthicLevel4 = value; }
        }
        /// <summary>
        /// EthicLevel5
        /// 
        /// </summary>
        public string EthicLevel5
        {
            get { return strEthicLevel5; }
            set { strEthicLevel5 = value; }
        }
        /// <summary>
        /// EthicLevel6
        /// 
        /// </summary>
        public string EthicLevel6
        {
            get { return strEthicLevel6; }
            set { strEthicLevel6 = value; }
        }
        /// <summary>
        /// EthicLevel7
        /// 
        /// </summary>
        public string EthicLevel7
        {
            get { return strEthicLevel7; }
            set { strEthicLevel7 = value; }
        }
        /// <summary>
        /// SpecialBranchIDOk
        /// Nguyện vọng trúng tuyển
        /// </summary>
        public string SpecialBranchIDOk
        {
            get { return strSpecialBranchIDOk; }
            set { strSpecialBranchIDOk = value; }
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
        /// LiveDate
        /// Ngày nhập khẩu
        /// </summary>
        public DateTime? LiveDate
        {
            get { return dtmLiveDate; }
            set { dtmLiveDate = value; }
        }
        /// <summary>
        /// CompanyID
        /// Mã công ty (Học viên là người của cty đưa đến học)
        /// </summary>
        public int? CompanyID
        {
            get { return intCompanyID; }
            set { intCompanyID = value; }
        }
        /// <summary>
        /// RegisterPerson
        /// Người làm đăng ký cho hồ sơ này
        /// </summary>
        public string RegisterPerson
        {
            get { return strRegisterPerson; }
            set { strRegisterPerson = value; }
        }
        /// <summary>
        /// Units
        /// đơn vị của người nộp hồ sơ này
        /// </summary>
        public string Units
        {
            get { return strUnits; }
            set { strUnits = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_StudentCollectionID.ToUpper()) && !Convert.IsDBNull(reader[C_StudentCollectionID])) this.lngStudentCollectionID = Convert.ToInt64(reader[C_StudentCollectionID]);
                    if (reader.GetName(i).ToUpper().Equals(C_StudentCollectionPeriodID.ToUpper()) && !Convert.IsDBNull(reader[C_StudentCollectionPeriodID])) this.strStudentCollectionPeriodID = Convert.ToString(reader[C_StudentCollectionPeriodID]);
                    if (reader.GetName(i).ToUpper().Equals(C_ExamStudentNumber.ToUpper()) && !Convert.IsDBNull(reader[C_ExamStudentNumber])) this.strExamStudentNumber = Convert.ToString(reader[C_ExamStudentNumber]);
                    if (reader.GetName(i).ToUpper().Equals(C_StudentFirstName.ToUpper()) && !Convert.IsDBNull(reader[C_StudentFirstName])) this.strStudentFirstName = Convert.ToString(reader[C_StudentFirstName]);
                    if (reader.GetName(i).ToUpper().Equals(C_StudentLastName.ToUpper()) && !Convert.IsDBNull(reader[C_StudentLastName])) this.strStudentLastName = Convert.ToString(reader[C_StudentLastName]);
                    if (reader.GetName(i).ToUpper().Equals(C_FullnameEn.ToUpper()) && !Convert.IsDBNull(reader[C_FullnameEn])) this.strFullnameEn = Convert.ToString(reader[C_FullnameEn]);
                    if (reader.GetName(i).ToUpper().Equals(C_BirthDay.ToUpper()) && !Convert.IsDBNull(reader[C_BirthDay])) this.intBirthDay = Convert.ToInt32(reader[C_BirthDay]);
                    if (reader.GetName(i).ToUpper().Equals(C_BirthMonth.ToUpper()) && !Convert.IsDBNull(reader[C_BirthMonth])) this.intBirthMonth = Convert.ToInt32(reader[C_BirthMonth]);
                    if (reader.GetName(i).ToUpper().Equals(C_BirthYear.ToUpper()) && !Convert.IsDBNull(reader[C_BirthYear])) this.intBirthYear = Convert.ToInt32(reader[C_BirthYear]);
                    if (reader.GetName(i).ToUpper().Equals(C_BirthDateText.ToUpper()) && !Convert.IsDBNull(reader[C_BirthDateText])) this.strBirthDateText = Convert.ToString(reader[C_BirthDateText]);
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
                    if (reader.GetName(i).ToUpper().Equals(C_ContactName.ToUpper()) && !Convert.IsDBNull(reader[C_ContactName])) this.strContactName = Convert.ToString(reader[C_ContactName]);
                    if (reader.GetName(i).ToUpper().Equals(C_ContactAddress.ToUpper()) && !Convert.IsDBNull(reader[C_ContactAddress])) this.strContactAddress = Convert.ToString(reader[C_ContactAddress]);
                    if (reader.GetName(i).ToUpper().Equals(C_ContactTel.ToUpper()) && !Convert.IsDBNull(reader[C_ContactTel])) this.strContactTel = Convert.ToString(reader[C_ContactTel]);
                    if (reader.GetName(i).ToUpper().Equals(C_ComponentFamilyID.ToUpper()) && !Convert.IsDBNull(reader[C_ComponentFamilyID])) this.strComponentFamilyID = Convert.ToString(reader[C_ComponentFamilyID]);
                    if (reader.GetName(i).ToUpper().Equals(C_AreaID.ToUpper()) && !Convert.IsDBNull(reader[C_AreaID])) this.strAreaID = Convert.ToString(reader[C_AreaID]);
                    if (reader.GetName(i).ToUpper().Equals(C_PreferentialObjectID.ToUpper()) && !Convert.IsDBNull(reader[C_PreferentialObjectID])) this.strPreferentialObjectID = Convert.ToString(reader[C_PreferentialObjectID]);
                    if (reader.GetName(i).ToUpper().Equals(C_GraduationYear.ToUpper()) && !Convert.IsDBNull(reader[C_GraduationYear])) this.intGraduationYear = Convert.ToInt32(reader[C_GraduationYear]);
                    if (reader.GetName(i).ToUpper().Equals(C_System.ToUpper()) && !Convert.IsDBNull(reader[C_System])) this.strSystem = Convert.ToString(reader[C_System]);
                    if (reader.GetName(i).ToUpper().Equals(C_LevelStudentID.ToUpper()) && !Convert.IsDBNull(reader[C_LevelStudentID])) this.intLevelStudentID = Convert.ToInt32(reader[C_LevelStudentID]);
                    if (reader.GetName(i).ToUpper().Equals(C_Mark1.ToUpper()) && !Convert.IsDBNull(reader[C_Mark1])) this.dblMark1 = Convert.ToDouble(reader[C_Mark1]);
                    if (reader.GetName(i).ToUpper().Equals(C_Mark2.ToUpper()) && !Convert.IsDBNull(reader[C_Mark2])) this.dblMark2 = Convert.ToDouble(reader[C_Mark2]);
                    if (reader.GetName(i).ToUpper().Equals(C_Mark3.ToUpper()) && !Convert.IsDBNull(reader[C_Mark3])) this.dblMark3 = Convert.ToDouble(reader[C_Mark3]);
                    if (reader.GetName(i).ToUpper().Equals(C_Mark4.ToUpper()) && !Convert.IsDBNull(reader[C_Mark4])) this.dblMark4 = Convert.ToDouble(reader[C_Mark4]);
                    if (reader.GetName(i).ToUpper().Equals(C_Mark5.ToUpper()) && !Convert.IsDBNull(reader[C_Mark5])) this.dblMark5 = Convert.ToDouble(reader[C_Mark5]);
                    if (reader.GetName(i).ToUpper().Equals(C_Mark6.ToUpper()) && !Convert.IsDBNull(reader[C_Mark6])) this.dblMark6 = Convert.ToDouble(reader[C_Mark6]);
                    if (reader.GetName(i).ToUpper().Equals(C_Mark7.ToUpper()) && !Convert.IsDBNull(reader[C_Mark7])) this.dblMark7 = Convert.ToDouble(reader[C_Mark7]);
                    if (reader.GetName(i).ToUpper().Equals(C_SummaryMark.ToUpper()) && !Convert.IsDBNull(reader[C_SummaryMark])) this.dblSummaryMark = Convert.ToDouble(reader[C_SummaryMark]);
                    if (reader.GetName(i).ToUpper().Equals(C_EthicMark.ToUpper()) && !Convert.IsDBNull(reader[C_EthicMark])) this.dblEthicMark = Convert.ToDouble(reader[C_EthicMark]);
                    if (reader.GetName(i).ToUpper().Equals(C_SpecialBranchID.ToUpper()) && !Convert.IsDBNull(reader[C_SpecialBranchID])) this.strSpecialBranchID = Convert.ToString(reader[C_SpecialBranchID]);
                    if (reader.GetName(i).ToUpper().Equals(C_SpecialBranchID2.ToUpper()) && !Convert.IsDBNull(reader[C_SpecialBranchID2])) this.strSpecialBranchID2 = Convert.ToString(reader[C_SpecialBranchID2]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsReceiveDiploma.ToUpper()) && !Convert.IsDBNull(reader[C_IsReceiveDiploma])) this.bolIsReceiveDiploma = Convert.ToBoolean(reader[C_IsReceiveDiploma]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsReceiveTempDiploma.ToUpper()) && !Convert.IsDBNull(reader[C_IsReceiveTempDiploma])) this.bolIsReceiveTempDiploma = Convert.ToBoolean(reader[C_IsReceiveTempDiploma]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsReceiveImage.ToUpper()) && !Convert.IsDBNull(reader[C_IsReceiveImage])) this.bolIsReceiveImage = Convert.ToBoolean(reader[C_IsReceiveImage]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsReceiveCandidateForm.ToUpper()) && !Convert.IsDBNull(reader[C_IsReceiveCandidateForm])) this.bolIsReceiveCandidateForm = Convert.ToBoolean(reader[C_IsReceiveCandidateForm]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsReceiveTranscripts.ToUpper()) && !Convert.IsDBNull(reader[C_IsReceiveTranscripts])) this.bolIsReceiveTranscripts = Convert.ToBoolean(reader[C_IsReceiveTranscripts]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsReceiveHousehold.ToUpper()) && !Convert.IsDBNull(reader[C_IsReceiveHousehold])) this.bolIsReceiveHousehold = Convert.ToBoolean(reader[C_IsReceiveHousehold]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsReceiveHealthCer.ToUpper()) && !Convert.IsDBNull(reader[C_IsReceiveHealthCer])) this.bolIsReceiveHealthCer = Convert.ToBoolean(reader[C_IsReceiveHealthCer]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsReceivePreferentialObjectCer.ToUpper()) && !Convert.IsDBNull(reader[C_IsReceivePreferentialObjectCer])) this.bolIsReceivePreferentialObjectCer = Convert.ToBoolean(reader[C_IsReceivePreferentialObjectCer]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsReceiveNotifyCopy.ToUpper()) && !Convert.IsDBNull(reader[C_IsReceiveNotifyCopy])) this.bolIsReceiveNotifyCopy = Convert.ToBoolean(reader[C_IsReceiveNotifyCopy]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsReceiveAssure.ToUpper()) && !Convert.IsDBNull(reader[C_IsReceiveAssure])) this.bolIsReceiveAssure = Convert.ToBoolean(reader[C_IsReceiveAssure]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsReceived.ToUpper()) && !Convert.IsDBNull(reader[C_IsReceived])) this.bolIsReceived = Convert.ToBoolean(reader[C_IsReceived]);
                    if (reader.GetName(i).ToUpper().Equals(C_ReceiveDate.ToUpper()) && !Convert.IsDBNull(reader[C_ReceiveDate])) this.dtmReceiveDate = Convert.ToDateTime(reader[C_ReceiveDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_ReceiveUser.ToUpper()) && !Convert.IsDBNull(reader[C_ReceiveUser])) this.strReceiveUser = Convert.ToString(reader[C_ReceiveUser]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsSendNotice.ToUpper()) && !Convert.IsDBNull(reader[C_IsSendNotice])) this.bolIsSendNotice = Convert.ToBoolean(reader[C_IsSendNotice]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(reader[C_UpdatedDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(reader[C_UpdatedUser]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsDeleted.ToUpper()) && !Convert.IsDBNull(reader[C_IsDeleted])) this.bolIsDeleted = Convert.ToBoolean(reader[C_IsDeleted]);
                    if (reader.GetName(i).ToUpper().Equals(C_DeletedDate.ToUpper()) && !Convert.IsDBNull(reader[C_DeletedDate])) this.dtmDeletedDate = Convert.ToDateTime(reader[C_DeletedDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_DeletedUser.ToUpper()) && !Convert.IsDBNull(reader[C_DeletedUser])) this.strDeletedUser = Convert.ToString(reader[C_DeletedUser]);
                    if (reader.GetName(i).ToUpper().Equals(C_StudentCollectionCode.ToUpper()) && !Convert.IsDBNull(reader[C_StudentCollectionCode])) this.strStudentCollectionCode = Convert.ToString(reader[C_StudentCollectionCode]);
                    if (reader.GetName(i).ToUpper().Equals(C_FatherName.ToUpper()) && !Convert.IsDBNull(reader[C_FatherName])) this.strFatherName = Convert.ToString(reader[C_FatherName]);
                    if (reader.GetName(i).ToUpper().Equals(C_FatherJob.ToUpper()) && !Convert.IsDBNull(reader[C_FatherJob])) this.strFatherJob = Convert.ToString(reader[C_FatherJob]);
                    if (reader.GetName(i).ToUpper().Equals(C_FatherAddress.ToUpper()) && !Convert.IsDBNull(reader[C_FatherAddress])) this.strFatherAddress = Convert.ToString(reader[C_FatherAddress]);
                    if (reader.GetName(i).ToUpper().Equals(C_MortherName.ToUpper()) && !Convert.IsDBNull(reader[C_MortherName])) this.strMortherName = Convert.ToString(reader[C_MortherName]);
                    if (reader.GetName(i).ToUpper().Equals(C_MortherJob.ToUpper()) && !Convert.IsDBNull(reader[C_MortherJob])) this.strMortherJob = Convert.ToString(reader[C_MortherJob]);
                    if (reader.GetName(i).ToUpper().Equals(C_MortherAddress.ToUpper()) && !Convert.IsDBNull(reader[C_MortherAddress])) this.strMortherAddress = Convert.ToString(reader[C_MortherAddress]);
                    if (reader.GetName(i).ToUpper().Equals(C_GraduationLevel.ToUpper()) && !Convert.IsDBNull(reader[C_GraduationLevel])) this.intGraduationLevel = Convert.ToInt32(reader[C_GraduationLevel]);
                    if (reader.GetName(i).ToUpper().Equals(C_Experience.ToUpper()) && !Convert.IsDBNull(reader[C_Experience])) this.intExperience = Convert.ToInt32(reader[C_Experience]);
                    if (reader.GetName(i).ToUpper().Equals(C_SpecialBranchID3.ToUpper()) && !Convert.IsDBNull(reader[C_SpecialBranchID3])) this.strSpecialBranchID3 = Convert.ToString(reader[C_SpecialBranchID3]);
                    if (reader.GetName(i).ToUpper().Equals(C_Result.ToUpper()) && !Convert.IsDBNull(reader[C_Result])) this.intResult = Convert.ToInt32(reader[C_Result]);
                    if (reader.GetName(i).ToUpper().Equals(C_PreferentialObjectID2.ToUpper()) && !Convert.IsDBNull(reader[C_PreferentialObjectID2])) this.strPreferentialObjectID2 = Convert.ToString(reader[C_PreferentialObjectID2]);
                    if (reader.GetName(i).ToUpper().Equals(C_PreferentialObjectID3.ToUpper()) && !Convert.IsDBNull(reader[C_PreferentialObjectID3])) this.strPreferentialObjectID3 = Convert.ToString(reader[C_PreferentialObjectID3]);
                    if (reader.GetName(i).ToUpper().Equals(C_ContactEmail.ToUpper()) && !Convert.IsDBNull(reader[C_ContactEmail])) this.strContactEmail = Convert.ToString(reader[C_ContactEmail]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsReceivePersonCer.ToUpper()) && !Convert.IsDBNull(reader[C_IsReceivePersonCer])) this.bolIsReceivePersonCer = Convert.ToBoolean(reader[C_IsReceivePersonCer]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsReceivePersonInfo.ToUpper()) && !Convert.IsDBNull(reader[C_IsReceivePersonInfo])) this.bolIsReceivePersonInfo = Convert.ToBoolean(reader[C_IsReceivePersonInfo]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsDeptDiploma.ToUpper()) && !Convert.IsDBNull(reader[C_IsDeptDiploma])) this.bolIsDeptDiploma = Convert.ToBoolean(reader[C_IsDeptDiploma]);
                    if (reader.GetName(i).ToUpper().Equals(C_CerNo.ToUpper()) && !Convert.IsDBNull(reader[C_CerNo])) this.strCerNo = Convert.ToString(reader[C_CerNo]);
                    if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
                    if (reader.GetName(i).ToUpper().Equals(C_EthicLevel1.ToUpper()) && !Convert.IsDBNull(reader[C_EthicLevel1])) this.strEthicLevel1 = Convert.ToString(reader[C_EthicLevel1]);
                    if (reader.GetName(i).ToUpper().Equals(C_EthicLevel2.ToUpper()) && !Convert.IsDBNull(reader[C_EthicLevel2])) this.strEthicLevel2 = Convert.ToString(reader[C_EthicLevel2]);
                    if (reader.GetName(i).ToUpper().Equals(C_EthicLevel3.ToUpper()) && !Convert.IsDBNull(reader[C_EthicLevel3])) this.strEthicLevel3 = Convert.ToString(reader[C_EthicLevel3]);
                    if (reader.GetName(i).ToUpper().Equals(C_EthicLevel4.ToUpper()) && !Convert.IsDBNull(reader[C_EthicLevel4])) this.strEthicLevel4 = Convert.ToString(reader[C_EthicLevel4]);
                    if (reader.GetName(i).ToUpper().Equals(C_EthicLevel5.ToUpper()) && !Convert.IsDBNull(reader[C_EthicLevel5])) this.strEthicLevel5 = Convert.ToString(reader[C_EthicLevel5]);
                    if (reader.GetName(i).ToUpper().Equals(C_EthicLevel6.ToUpper()) && !Convert.IsDBNull(reader[C_EthicLevel6])) this.strEthicLevel6 = Convert.ToString(reader[C_EthicLevel6]);
                    if (reader.GetName(i).ToUpper().Equals(C_EthicLevel7.ToUpper()) && !Convert.IsDBNull(reader[C_EthicLevel7])) this.strEthicLevel7 = Convert.ToString(reader[C_EthicLevel7]);
                    if (reader.GetName(i).ToUpper().Equals(C_SpecialBranchIDOk.ToUpper()) && !Convert.IsDBNull(reader[C_SpecialBranchIDOk])) this.strSpecialBranchIDOk = Convert.ToString(reader[C_SpecialBranchIDOk]);
                    if (reader.GetName(i).ToUpper().Equals(C_GraduationSchool.ToUpper()) && !Convert.IsDBNull(reader[C_GraduationSchool])) this.strGraduationSchool = Convert.ToString(reader[C_GraduationSchool]);
                    if (reader.GetName(i).ToUpper().Equals(C_LiveDate.ToUpper()) && !Convert.IsDBNull(reader[C_LiveDate])) this.dtmLiveDate = Convert.ToDateTime(reader[C_LiveDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_CompanyID.ToUpper()) && !Convert.IsDBNull(reader[C_CompanyID])) this.intCompanyID = Convert.ToInt32(reader[C_CompanyID]);
                    if (reader.GetName(i).ToUpper().Equals(C_RegisterPerson.ToUpper()) && !Convert.IsDBNull(reader[C_RegisterPerson])) this.strRegisterPerson = Convert.ToString(reader[C_RegisterPerson]);
                    if (reader.GetName(i).ToUpper().Equals(C_Units.ToUpper()) && !Convert.IsDBNull(reader[C_Units])) this.strUnits = Convert.ToString(reader[C_Units]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_StudentCollection", objEx);
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
                if (!Convert.IsDBNull(drw[C_StudentCollectionID])) this.lngStudentCollectionID = Convert.ToInt64(drw[C_StudentCollectionID]);
                if (!Convert.IsDBNull(drw[C_StudentCollectionPeriodID])) this.strStudentCollectionPeriodID = Convert.ToString(drw[C_StudentCollectionPeriodID]);
                if (!Convert.IsDBNull(drw[C_ExamStudentNumber])) this.strExamStudentNumber = Convert.ToString(drw[C_ExamStudentNumber]);
                if (!Convert.IsDBNull(drw[C_StudentFirstName])) this.strStudentFirstName = Convert.ToString(drw[C_StudentFirstName]);
                if (!Convert.IsDBNull(drw[C_StudentLastName])) this.strStudentLastName = Convert.ToString(drw[C_StudentLastName]);
                if (!Convert.IsDBNull(drw[C_FullnameEn])) this.strFullnameEn = Convert.ToString(drw[C_FullnameEn]);
                if (!Convert.IsDBNull(drw[C_BirthDay])) this.intBirthDay = Convert.ToInt32(drw[C_BirthDay]);
                if (!Convert.IsDBNull(drw[C_BirthMonth])) this.intBirthMonth = Convert.ToInt32(drw[C_BirthMonth]);
                if (!Convert.IsDBNull(drw[C_BirthYear])) this.intBirthYear = Convert.ToInt32(drw[C_BirthYear]);
                if (!Convert.IsDBNull(drw[C_BirthDateText])) this.strBirthDateText = Convert.ToString(drw[C_BirthDateText]);
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
                if (!Convert.IsDBNull(drw[C_ContactName])) this.strContactName = Convert.ToString(drw[C_ContactName]);
                if (!Convert.IsDBNull(drw[C_ContactAddress])) this.strContactAddress = Convert.ToString(drw[C_ContactAddress]);
                if (!Convert.IsDBNull(drw[C_ContactTel])) this.strContactTel = Convert.ToString(drw[C_ContactTel]);
                if (!Convert.IsDBNull(drw[C_ComponentFamilyID])) this.strComponentFamilyID = Convert.ToString(drw[C_ComponentFamilyID]);
                if (!Convert.IsDBNull(drw[C_AreaID])) this.strAreaID = Convert.ToString(drw[C_AreaID]);
                if (!Convert.IsDBNull(drw[C_PreferentialObjectID])) this.strPreferentialObjectID = Convert.ToString(drw[C_PreferentialObjectID]);
                if (!Convert.IsDBNull(drw[C_GraduationYear])) this.intGraduationYear = Convert.ToInt32(drw[C_GraduationYear]);
                if (!Convert.IsDBNull(drw[C_System])) this.strSystem = Convert.ToString(drw[C_System]);
                if (!Convert.IsDBNull(drw[C_LevelStudentID])) this.intLevelStudentID = Convert.ToInt32(drw[C_LevelStudentID]);
                if (!Convert.IsDBNull(drw[C_Mark1])) this.dblMark1 = Convert.ToDouble(drw[C_Mark1]);
                if (!Convert.IsDBNull(drw[C_Mark2])) this.dblMark2 = Convert.ToDouble(drw[C_Mark2]);
                if (!Convert.IsDBNull(drw[C_Mark3])) this.dblMark3 = Convert.ToDouble(drw[C_Mark3]);
                if (!Convert.IsDBNull(drw[C_Mark4])) this.dblMark4 = Convert.ToDouble(drw[C_Mark4]);
                if (!Convert.IsDBNull(drw[C_Mark5])) this.dblMark5 = Convert.ToDouble(drw[C_Mark5]);
                if (!Convert.IsDBNull(drw[C_Mark6])) this.dblMark6 = Convert.ToDouble(drw[C_Mark6]);
                if (!Convert.IsDBNull(drw[C_Mark7])) this.dblMark7 = Convert.ToDouble(drw[C_Mark7]);
                if (!Convert.IsDBNull(drw[C_SummaryMark])) this.dblSummaryMark = Convert.ToDouble(drw[C_SummaryMark]);
                if (!Convert.IsDBNull(drw[C_EthicMark])) this.dblEthicMark = Convert.ToDouble(drw[C_EthicMark]);
                if (!Convert.IsDBNull(drw[C_SpecialBranchID])) this.strSpecialBranchID = Convert.ToString(drw[C_SpecialBranchID]);
                if (!Convert.IsDBNull(drw[C_SpecialBranchID2])) this.strSpecialBranchID2 = Convert.ToString(drw[C_SpecialBranchID2]);
                if (!Convert.IsDBNull(drw[C_IsReceiveDiploma])) this.bolIsReceiveDiploma = Convert.ToBoolean(drw[C_IsReceiveDiploma]);
                if (!Convert.IsDBNull(drw[C_IsReceiveTempDiploma])) this.bolIsReceiveTempDiploma = Convert.ToBoolean(drw[C_IsReceiveTempDiploma]);
                if (!Convert.IsDBNull(drw[C_IsReceiveImage])) this.bolIsReceiveImage = Convert.ToBoolean(drw[C_IsReceiveImage]);
                if (!Convert.IsDBNull(drw[C_IsReceiveCandidateForm])) this.bolIsReceiveCandidateForm = Convert.ToBoolean(drw[C_IsReceiveCandidateForm]);
                if (!Convert.IsDBNull(drw[C_IsReceiveTranscripts])) this.bolIsReceiveTranscripts = Convert.ToBoolean(drw[C_IsReceiveTranscripts]);
                if (!Convert.IsDBNull(drw[C_IsReceiveHousehold])) this.bolIsReceiveHousehold = Convert.ToBoolean(drw[C_IsReceiveHousehold]);
                if (!Convert.IsDBNull(drw[C_IsReceiveHealthCer])) this.bolIsReceiveHealthCer = Convert.ToBoolean(drw[C_IsReceiveHealthCer]);
                if (!Convert.IsDBNull(drw[C_IsReceivePreferentialObjectCer])) this.bolIsReceivePreferentialObjectCer = Convert.ToBoolean(drw[C_IsReceivePreferentialObjectCer]);
                if (!Convert.IsDBNull(drw[C_IsReceiveNotifyCopy])) this.bolIsReceiveNotifyCopy = Convert.ToBoolean(drw[C_IsReceiveNotifyCopy]);
                if (!Convert.IsDBNull(drw[C_IsReceiveAssure])) this.bolIsReceiveAssure = Convert.ToBoolean(drw[C_IsReceiveAssure]);
                if (!Convert.IsDBNull(drw[C_IsReceived])) this.bolIsReceived = Convert.ToBoolean(drw[C_IsReceived]);
                if (!Convert.IsDBNull(drw[C_ReceiveDate])) this.dtmReceiveDate = Convert.ToDateTime(drw[C_ReceiveDate]);
                if (!Convert.IsDBNull(drw[C_ReceiveUser])) this.strReceiveUser = Convert.ToString(drw[C_ReceiveUser]);
                if (!Convert.IsDBNull(drw[C_IsSendNotice])) this.bolIsSendNotice = Convert.ToBoolean(drw[C_IsSendNotice]);
                if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
                if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
                if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
                if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
                if (!Convert.IsDBNull(drw[C_IsDeleted])) this.bolIsDeleted = Convert.ToBoolean(drw[C_IsDeleted]);
                if (!Convert.IsDBNull(drw[C_DeletedDate])) this.dtmDeletedDate = Convert.ToDateTime(drw[C_DeletedDate]);
                if (!Convert.IsDBNull(drw[C_DeletedUser])) this.strDeletedUser = Convert.ToString(drw[C_DeletedUser]);
                if (!Convert.IsDBNull(drw[C_StudentCollectionCode])) this.strStudentCollectionCode = Convert.ToString(drw[C_StudentCollectionCode]);
                if (!Convert.IsDBNull(drw[C_FatherName])) this.strFatherName = Convert.ToString(drw[C_FatherName]);
                if (!Convert.IsDBNull(drw[C_FatherJob])) this.strFatherJob = Convert.ToString(drw[C_FatherJob]);
                if (!Convert.IsDBNull(drw[C_FatherAddress])) this.strFatherAddress = Convert.ToString(drw[C_FatherAddress]);
                if (!Convert.IsDBNull(drw[C_MortherName])) this.strMortherName = Convert.ToString(drw[C_MortherName]);
                if (!Convert.IsDBNull(drw[C_MortherJob])) this.strMortherJob = Convert.ToString(drw[C_MortherJob]);
                if (!Convert.IsDBNull(drw[C_MortherAddress])) this.strMortherAddress = Convert.ToString(drw[C_MortherAddress]);
                if (!Convert.IsDBNull(drw[C_GraduationLevel])) this.intGraduationLevel = Convert.ToInt32(drw[C_GraduationLevel]);
                if (!Convert.IsDBNull(drw[C_Experience])) this.intExperience = Convert.ToInt32(drw[C_Experience]);
                if (!Convert.IsDBNull(drw[C_SpecialBranchID3])) this.strSpecialBranchID3 = Convert.ToString(drw[C_SpecialBranchID3]);
                if (!Convert.IsDBNull(drw[C_Result])) this.intResult = Convert.ToInt32(drw[C_Result]);
                if (!Convert.IsDBNull(drw[C_PreferentialObjectID2])) this.strPreferentialObjectID2 = Convert.ToString(drw[C_PreferentialObjectID2]);
                if (!Convert.IsDBNull(drw[C_PreferentialObjectID3])) this.strPreferentialObjectID3 = Convert.ToString(drw[C_PreferentialObjectID3]);
                if (!Convert.IsDBNull(drw[C_ContactEmail])) this.strContactEmail = Convert.ToString(drw[C_ContactEmail]);
                if (!Convert.IsDBNull(drw[C_IsReceivePersonCer])) this.bolIsReceivePersonCer = Convert.ToBoolean(drw[C_IsReceivePersonCer]);
                if (!Convert.IsDBNull(drw[C_IsReceivePersonInfo])) this.bolIsReceivePersonInfo = Convert.ToBoolean(drw[C_IsReceivePersonInfo]);
                if (!Convert.IsDBNull(drw[C_IsDeptDiploma])) this.bolIsDeptDiploma = Convert.ToBoolean(drw[C_IsDeptDiploma]);
                if (!Convert.IsDBNull(drw[C_CerNo])) this.strCerNo = Convert.ToString(drw[C_CerNo]);
                if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
                if (!Convert.IsDBNull(drw[C_EthicLevel1])) this.strEthicLevel1 = Convert.ToString(drw[C_EthicLevel1]);
                if (!Convert.IsDBNull(drw[C_EthicLevel2])) this.strEthicLevel2 = Convert.ToString(drw[C_EthicLevel2]);
                if (!Convert.IsDBNull(drw[C_EthicLevel3])) this.strEthicLevel3 = Convert.ToString(drw[C_EthicLevel3]);
                if (!Convert.IsDBNull(drw[C_EthicLevel4])) this.strEthicLevel4 = Convert.ToString(drw[C_EthicLevel4]);
                if (!Convert.IsDBNull(drw[C_EthicLevel5])) this.strEthicLevel5 = Convert.ToString(drw[C_EthicLevel5]);
                if (!Convert.IsDBNull(drw[C_EthicLevel6])) this.strEthicLevel6 = Convert.ToString(drw[C_EthicLevel6]);
                if (!Convert.IsDBNull(drw[C_EthicLevel7])) this.strEthicLevel7 = Convert.ToString(drw[C_EthicLevel7]);
                if (!Convert.IsDBNull(drw[C_SpecialBranchIDOk])) this.strSpecialBranchIDOk = Convert.ToString(drw[C_SpecialBranchIDOk]);
                if (!Convert.IsDBNull(drw[C_GraduationSchool])) this.strGraduationSchool = Convert.ToString(drw[C_GraduationSchool]);
                if (!Convert.IsDBNull(drw[C_LiveDate])) this.dtmLiveDate = Convert.ToDateTime(drw[C_LiveDate]);
                if (!Convert.IsDBNull(drw[C_CompanyID])) this.intCompanyID = Convert.ToInt32(drw[C_CompanyID]);
                if (!Convert.IsDBNull(drw[C_RegisterPerson])) this.strRegisterPerson = Convert.ToString(drw[C_RegisterPerson]);
                if (!Convert.IsDBNull(drw[C_Units])) this.strUnits = Convert.ToString(drw[C_Units]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_StudentCollection", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        /// Nạp thông tin item 
        /// Store: SIM_StudentCollection_GET 
        ///</summary>
        /// <returns>true ? Có : False ? Không</returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_StudentCollection_GET");
                objIData.AddParameter(P_StudentCollectionID, this.lngStudentCollectionID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_StudentCollection", objEx);
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
        /// Store: SIM_StudentCollection_GET 
        ///</summary>
        /// <returns> SIM_StudentCollection </returns>
        public SIM_StudentCollection Get(long? lngStudentCollectionID)
        {
            SIM_StudentCollection obj = new SIM_StudentCollection();
            if (objIData != null)
                obj.IDB = objIData;
            obj.StudentCollectionID = lngStudentCollectionID;
            if (obj.Get())
                return obj;
            this.objErrorException = obj.ErrorException;
            return null;
        }
        ///<summary>
        /// ExecNonQuery : SIM_StudentCollection
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_StudentCollection", objEx);
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
        /// Search : SIM_StudentCollection
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_StudentCollection", objEx);
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
        /// Search : SIM_StudentCollection
        /// Lấy hết dữ liệu
        /// Store: SIM_StudentCollection_GETALL 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable GetAll()
        {
            return GetDataTable("SIM_StudentCollection_GETALL");
        }

        ///<summary>
        /// Search : SIM_StudentCollection
        /// Tìm dữ liệu
        /// Store: SIM_StudentCollection_SEARCH 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable Search(params object[] pars)
        {
            return GetDataTable("SIM_StudentCollection_SEARCH", pars);
        }

        ///<summary>
        /// Add : SIM_StudentCollection
        /// Thêm dữ liệu
        /// Store: SIM_StudentCollection_ADD 
        ///</summary>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_StudentCollection_ADD");
                objIData.AddParameter(P_StudentCollectionPeriodID, this.strStudentCollectionPeriodID);
                objIData.AddParameter(P_ExamStudentNumber, this.strExamStudentNumber);
                objIData.AddParameter(P_StudentFirstName, this.strStudentFirstName);
                objIData.AddParameter(P_StudentLastName, this.strStudentLastName);
                objIData.AddParameter(P_FullnameEn, this.strFullnameEn);
                objIData.AddParameter(P_BirthDay, this.intBirthDay);
                objIData.AddParameter(P_BirthMonth, this.intBirthMonth);
                objIData.AddParameter(P_BirthYear, this.intBirthYear);
                objIData.AddParameter(P_BirthDateText, this.strBirthDateText);
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
                objIData.AddParameter(P_ContactName, this.strContactName);
                objIData.AddParameter(P_ContactAddress, this.strContactAddress);
                objIData.AddParameter(P_ContactTel, this.strContactTel);
                objIData.AddParameter(P_ComponentFamilyID, this.strComponentFamilyID);
                objIData.AddParameter(P_AreaID, this.strAreaID);
                objIData.AddParameter(P_PreferentialObjectID, this.strPreferentialObjectID);
                objIData.AddParameter(P_GraduationYear, this.intGraduationYear);
                objIData.AddParameter(P_System, this.strSystem);
                objIData.AddParameter(P_LevelStudentID, this.intLevelStudentID);
                objIData.AddParameter(P_Mark1, this.dblMark1);
                objIData.AddParameter(P_Mark2, this.dblMark2);
                objIData.AddParameter(P_Mark3, this.dblMark3);
                objIData.AddParameter(P_Mark4, this.dblMark4);
                objIData.AddParameter(P_Mark5, this.dblMark5);
                objIData.AddParameter(P_Mark6, this.dblMark6);
                objIData.AddParameter(P_Mark7, this.dblMark7);
                objIData.AddParameter(P_SummaryMark, this.dblSummaryMark);
                objIData.AddParameter(P_EthicMark, this.dblEthicMark);
                objIData.AddParameter(P_SpecialBranchID, this.strSpecialBranchID);
                objIData.AddParameter(P_SpecialBranchID2, this.strSpecialBranchID2);
                objIData.AddParameter(P_IsReceiveDiploma, this.bolIsReceiveDiploma);
                objIData.AddParameter(P_IsReceiveTempDiploma, this.bolIsReceiveTempDiploma);
                objIData.AddParameter(P_IsReceiveImage, this.bolIsReceiveImage);
                objIData.AddParameter(P_IsReceiveCandidateForm, this.bolIsReceiveCandidateForm);
                objIData.AddParameter(P_IsReceiveTranscripts, this.bolIsReceiveTranscripts);
                objIData.AddParameter(P_IsReceiveHousehold, this.bolIsReceiveHousehold);
                objIData.AddParameter(P_IsReceiveHealthCer, this.bolIsReceiveHealthCer);
                objIData.AddParameter(P_IsReceivePreferentialObjectCer, this.bolIsReceivePreferentialObjectCer);
                objIData.AddParameter(P_IsReceiveNotifyCopy, this.bolIsReceiveNotifyCopy);
                objIData.AddParameter(P_IsReceiveAssure, this.bolIsReceiveAssure);
                objIData.AddParameter(P_IsReceived, this.bolIsReceived);
                objIData.AddParameter(P_ReceiveDate, this.dtmReceiveDate);
                objIData.AddParameter(P_ReceiveUser, this.strReceiveUser);
                objIData.AddParameter(P_IsSendNotice, this.bolIsSendNotice);
                objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
                objIData.AddParameter(P_StudentCollectionCode, this.strStudentCollectionCode);
                objIData.AddParameter(P_FatherName, this.strFatherName);
                objIData.AddParameter(P_FatherJob, this.strFatherJob);
                objIData.AddParameter(P_FatherAddress, this.strFatherAddress);
                objIData.AddParameter(P_MortherName, this.strMortherName);
                objIData.AddParameter(P_MortherJob, this.strMortherJob);
                objIData.AddParameter(P_MortherAddress, this.strMortherAddress);
                objIData.AddParameter(P_GraduationLevel, this.intGraduationLevel);
                objIData.AddParameter(P_Experience, this.intExperience);
                objIData.AddParameter(P_SpecialBranchID3, this.strSpecialBranchID3);
                objIData.AddParameter(P_Result, this.intResult);
                objIData.AddParameter(P_PreferentialObjectID2, this.strPreferentialObjectID2);
                objIData.AddParameter(P_PreferentialObjectID3, this.strPreferentialObjectID3);
                objIData.AddParameter(P_ContactEmail, this.strContactEmail);
                objIData.AddParameter(P_IsReceivePersonCer, this.bolIsReceivePersonCer);
                objIData.AddParameter(P_IsReceivePersonInfo, this.bolIsReceivePersonInfo);
                objIData.AddParameter(P_IsDeptDiploma, this.bolIsDeptDiploma);
                objIData.AddParameter(P_CerNo, this.strCerNo);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_EthicLevel1, this.strEthicLevel1);
                objIData.AddParameter(P_EthicLevel2, this.strEthicLevel2);
                objIData.AddParameter(P_EthicLevel3, this.strEthicLevel3);
                objIData.AddParameter(P_EthicLevel4, this.strEthicLevel4);
                objIData.AddParameter(P_EthicLevel5, this.strEthicLevel5);
                objIData.AddParameter(P_EthicLevel6, this.strEthicLevel6);
                objIData.AddParameter(P_EthicLevel7, this.strEthicLevel7);
                objIData.AddParameter(P_SpecialBranchIDOk, this.strSpecialBranchIDOk);
                objIData.AddParameter(P_GraduationSchool, this.strGraduationSchool);
                objIData.AddParameter(P_LiveDate, this.dtmLiveDate);
                objIData.AddParameter(P_CompanyID, this.intCompanyID);
                objIData.AddParameter(P_RegisterPerson, this.strRegisterPerson);
                objIData.AddParameter(P_Units, this.strUnits);
                this.lngStudentCollectionID = Convert.ToInt32(objIData.ExecStoreToString());
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_StudentCollection", objEx);
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
        /// Update : SIM_StudentCollection
        /// Cập nhật dữ liệu
        /// Store: SIM_StudentCollection_EDIT 
        ///</summary>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_StudentCollection_EDIT");
                objIData.AddParameter(P_StudentCollectionID, this.lngStudentCollectionID);
                objIData.AddParameter(P_StudentCollectionPeriodID, this.strStudentCollectionPeriodID);
                objIData.AddParameter(P_ExamStudentNumber, this.strExamStudentNumber);
                objIData.AddParameter(P_StudentFirstName, this.strStudentFirstName);
                objIData.AddParameter(P_StudentLastName, this.strStudentLastName);
                objIData.AddParameter(P_FullnameEn, this.strFullnameEn);
                objIData.AddParameter(P_BirthDay, this.intBirthDay);
                objIData.AddParameter(P_BirthMonth, this.intBirthMonth);
                objIData.AddParameter(P_BirthYear, this.intBirthYear);
                objIData.AddParameter(P_BirthDateText, this.strBirthDateText);
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
                objIData.AddParameter(P_ContactName, this.strContactName);
                objIData.AddParameter(P_ContactAddress, this.strContactAddress);
                objIData.AddParameter(P_ContactTel, this.strContactTel);
                objIData.AddParameter(P_ComponentFamilyID, this.strComponentFamilyID);
                objIData.AddParameter(P_AreaID, this.strAreaID);
                objIData.AddParameter(P_PreferentialObjectID, this.strPreferentialObjectID);
                objIData.AddParameter(P_GraduationYear, this.intGraduationYear);
                objIData.AddParameter(P_System, this.strSystem);
                objIData.AddParameter(P_LevelStudentID, this.intLevelStudentID);
                objIData.AddParameter(P_Mark1, this.dblMark1);
                objIData.AddParameter(P_Mark2, this.dblMark2);
                objIData.AddParameter(P_Mark3, this.dblMark3);
                objIData.AddParameter(P_Mark4, this.dblMark4);
                objIData.AddParameter(P_Mark5, this.dblMark5);
                objIData.AddParameter(P_Mark6, this.dblMark6);
                objIData.AddParameter(P_Mark7, this.dblMark7);
                objIData.AddParameter(P_SummaryMark, this.dblSummaryMark);
                objIData.AddParameter(P_EthicMark, this.dblEthicMark);
                objIData.AddParameter(P_SpecialBranchID, this.strSpecialBranchID);
                objIData.AddParameter(P_SpecialBranchID2, this.strSpecialBranchID2);
                objIData.AddParameter(P_IsReceiveDiploma, this.bolIsReceiveDiploma);
                objIData.AddParameter(P_IsReceiveTempDiploma, this.bolIsReceiveTempDiploma);
                objIData.AddParameter(P_IsReceiveImage, this.bolIsReceiveImage);
                objIData.AddParameter(P_IsReceiveCandidateForm, this.bolIsReceiveCandidateForm);
                objIData.AddParameter(P_IsReceiveTranscripts, this.bolIsReceiveTranscripts);
                objIData.AddParameter(P_IsReceiveHousehold, this.bolIsReceiveHousehold);
                objIData.AddParameter(P_IsReceiveHealthCer, this.bolIsReceiveHealthCer);
                objIData.AddParameter(P_IsReceivePreferentialObjectCer, this.bolIsReceivePreferentialObjectCer);
                objIData.AddParameter(P_IsReceiveNotifyCopy, this.bolIsReceiveNotifyCopy);
                objIData.AddParameter(P_IsReceiveAssure, this.bolIsReceiveAssure);
                objIData.AddParameter(P_IsReceived, this.bolIsReceived);
                objIData.AddParameter(P_ReceiveDate, this.dtmReceiveDate);
                objIData.AddParameter(P_ReceiveUser, this.strReceiveUser);
                objIData.AddParameter(P_IsSendNotice, this.bolIsSendNotice);
                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
                objIData.AddParameter(P_StudentCollectionCode, this.strStudentCollectionCode);
                objIData.AddParameter(P_FatherName, this.strFatherName);
                objIData.AddParameter(P_FatherJob, this.strFatherJob);
                objIData.AddParameter(P_FatherAddress, this.strFatherAddress);
                objIData.AddParameter(P_MortherName, this.strMortherName);
                objIData.AddParameter(P_MortherJob, this.strMortherJob);
                objIData.AddParameter(P_MortherAddress, this.strMortherAddress);
                objIData.AddParameter(P_GraduationLevel, this.intGraduationLevel);
                objIData.AddParameter(P_Experience, this.intExperience);
                objIData.AddParameter(P_SpecialBranchID3, this.strSpecialBranchID3);
                objIData.AddParameter(P_Result, this.intResult);
                objIData.AddParameter(P_PreferentialObjectID2, this.strPreferentialObjectID2);
                objIData.AddParameter(P_PreferentialObjectID3, this.strPreferentialObjectID3);
                objIData.AddParameter(P_ContactEmail, this.strContactEmail);
                objIData.AddParameter(P_IsReceivePersonCer, this.bolIsReceivePersonCer);
                objIData.AddParameter(P_IsReceivePersonInfo, this.bolIsReceivePersonInfo);
                objIData.AddParameter(P_IsDeptDiploma, this.bolIsDeptDiploma);
                objIData.AddParameter(P_CerNo, this.strCerNo);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_EthicLevel1, this.strEthicLevel1);
                objIData.AddParameter(P_EthicLevel2, this.strEthicLevel2);
                objIData.AddParameter(P_EthicLevel3, this.strEthicLevel3);
                objIData.AddParameter(P_EthicLevel4, this.strEthicLevel4);
                objIData.AddParameter(P_EthicLevel5, this.strEthicLevel5);
                objIData.AddParameter(P_EthicLevel6, this.strEthicLevel6);
                objIData.AddParameter(P_EthicLevel7, this.strEthicLevel7);
                objIData.AddParameter(P_SpecialBranchIDOk, this.strSpecialBranchIDOk);
                objIData.AddParameter(P_GraduationSchool, this.strGraduationSchool);
                objIData.AddParameter(P_LiveDate, this.dtmLiveDate);
                objIData.AddParameter(P_CompanyID, this.intCompanyID);
                objIData.AddParameter(P_RegisterPerson, this.strRegisterPerson);
                objIData.AddParameter(P_Units, this.strUnits);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_StudentCollection", objEx);
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
        /// Delete : SIM_StudentCollection
        /// Xóa dữ liệu
        /// Store: SIM_StudentCollection_DELETE 
        ///</summary>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_StudentCollection_DELETE");
                objIData.AddParameter(P_StudentCollectionID, this.lngStudentCollectionID);
                objIData.AddParameter(P_DeletedUser, this.strDeletedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_StudentCollection", objEx);
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
        /// Store: SIM_StudentCollection_DELETE 
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long? lngStudentCollectionID, string strDeletedUser)
        {
            this.lngStudentCollectionID = lngStudentCollectionID;
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

        public SIM_StudentCollection()
        {
        }
        public SIM_StudentCollection(long? lngStudentCollectionID)
        {
            this.lngStudentCollectionID = lngStudentCollectionID;
            this.Get();
        }

        #endregion

        #region Variable Static

        #region Parameter Names

        public const String P_StudentCollectionID = "@" + C_StudentCollectionID;
        public const String P_StudentCollectionPeriodID = "@" + C_StudentCollectionPeriodID;
        public const String P_ExamStudentNumber = "@" + C_ExamStudentNumber;
        public const String P_StudentFirstName = "@" + C_StudentFirstName;
        public const String P_StudentLastName = "@" + C_StudentLastName;
        public const String P_FullnameEn = "@" + C_FullnameEn;
        public const String P_BirthDay = "@" + C_BirthDay;
        public const String P_BirthMonth = "@" + C_BirthMonth;
        public const String P_BirthYear = "@" + C_BirthYear;
        public const String P_BirthDateText = "@" + C_BirthDateText;
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
        public const String P_ContactName = "@" + C_ContactName;
        public const String P_ContactAddress = "@" + C_ContactAddress;
        public const String P_ContactTel = "@" + C_ContactTel;
        public const String P_ComponentFamilyID = "@" + C_ComponentFamilyID;
        public const String P_AreaID = "@" + C_AreaID;
        public const String P_PreferentialObjectID = "@" + C_PreferentialObjectID;
        public const String P_GraduationYear = "@" + C_GraduationYear;
        public const String P_System = "@" + C_System;
        public const String P_LevelStudentID = "@" + C_LevelStudentID;
        public const String P_Mark1 = "@" + C_Mark1;
        public const String P_Mark2 = "@" + C_Mark2;
        public const String P_Mark3 = "@" + C_Mark3;
        public const String P_Mark4 = "@" + C_Mark4;
        public const String P_Mark5 = "@" + C_Mark5;
        public const String P_Mark6 = "@" + C_Mark6;
        public const String P_Mark7 = "@" + C_Mark7;
        public const String P_SummaryMark = "@" + C_SummaryMark;
        public const String P_EthicMark = "@" + C_EthicMark;
        public const String P_SpecialBranchID = "@" + C_SpecialBranchID;
        public const String P_SpecialBranchID2 = "@" + C_SpecialBranchID2;
        public const String P_IsReceiveDiploma = "@" + C_IsReceiveDiploma;
        public const String P_IsReceiveTempDiploma = "@" + C_IsReceiveTempDiploma;
        public const String P_IsReceiveImage = "@" + C_IsReceiveImage;
        public const String P_IsReceiveCandidateForm = "@" + C_IsReceiveCandidateForm;
        public const String P_IsReceiveTranscripts = "@" + C_IsReceiveTranscripts;
        public const String P_IsReceiveHousehold = "@" + C_IsReceiveHousehold;
        public const String P_IsReceiveHealthCer = "@" + C_IsReceiveHealthCer;
        public const String P_IsReceivePreferentialObjectCer = "@" + C_IsReceivePreferentialObjectCer;
        public const String P_IsReceiveNotifyCopy = "@" + C_IsReceiveNotifyCopy;
        public const String P_IsReceiveAssure = "@" + C_IsReceiveAssure;
        public const String P_IsReceived = "@" + C_IsReceived;
        public const String P_ReceiveDate = "@" + C_ReceiveDate;
        public const String P_ReceiveUser = "@" + C_ReceiveUser;
        public const String P_IsSendNotice = "@" + C_IsSendNotice;
        public const String P_CreatedDate = "@" + C_CreatedDate;
        public const String P_CreatedUser = "@" + C_CreatedUser;
        public const String P_UpdatedDate = "@" + C_UpdatedDate;
        public const String P_UpdatedUser = "@" + C_UpdatedUser;
        public const String P_IsDeleted = "@" + C_IsDeleted;
        public const String P_DeletedDate = "@" + C_DeletedDate;
        public const String P_DeletedUser = "@" + C_DeletedUser;
        public const String P_StudentCollectionCode = "@" + C_StudentCollectionCode;
        public const String P_FatherName = "@" + C_FatherName;
        public const String P_FatherJob = "@" + C_FatherJob;
        public const String P_FatherAddress = "@" + C_FatherAddress;
        public const String P_MortherName = "@" + C_MortherName;
        public const String P_MortherJob = "@" + C_MortherJob;
        public const String P_MortherAddress = "@" + C_MortherAddress;
        public const String P_GraduationLevel = "@" + C_GraduationLevel;
        public const String P_Experience = "@" + C_Experience;
        public const String P_SpecialBranchID3 = "@" + C_SpecialBranchID3;
        public const String P_Result = "@" + C_Result;
        public const String P_PreferentialObjectID2 = "@" + C_PreferentialObjectID2;
        public const String P_PreferentialObjectID3 = "@" + C_PreferentialObjectID3;
        public const String P_ContactEmail = "@" + C_ContactEmail;
        public const String P_IsReceivePersonCer = "@" + C_IsReceivePersonCer;
        public const String P_IsReceivePersonInfo = "@" + C_IsReceivePersonInfo;
        public const String P_IsDeptDiploma = "@" + C_IsDeptDiploma;
        public const String P_CerNo = "@" + C_CerNo;
        public const String P_Description = "@" + C_Description;
        public const String P_EthicLevel1 = "@" + C_EthicLevel1;
        public const String P_EthicLevel2 = "@" + C_EthicLevel2;
        public const String P_EthicLevel3 = "@" + C_EthicLevel3;
        public const String P_EthicLevel4 = "@" + C_EthicLevel4;
        public const String P_EthicLevel5 = "@" + C_EthicLevel5;
        public const String P_EthicLevel6 = "@" + C_EthicLevel6;
        public const String P_EthicLevel7 = "@" + C_EthicLevel7;
        public const String P_SpecialBranchIDOk = "@" + C_SpecialBranchIDOk;
        public const String P_GraduationSchool = "@" + C_GraduationSchool;
        public const String P_LiveDate = "@" + C_LiveDate;
        public const String P_CompanyID = "@" + C_CompanyID;
        public const String P_RegisterPerson = "@" + C_RegisterPerson;
        public const String P_Units = "@" + C_Units;

        #endregion //Parameter names

        #region Column Names

        public const String C_StudentCollectionID = "StudentCollectionID";
        public const String C_StudentCollectionPeriodID = "StudentCollectionPeriodID";
        public const String C_ExamStudentNumber = "ExamStudentNumber";
        public const String C_StudentFirstName = "StudentFirstName";
        public const String C_StudentLastName = "StudentLastName";
        public const String C_FullnameEn = "FullnameEn";
        public const String C_BirthDay = "BirthDay";
        public const String C_BirthMonth = "BirthMonth";
        public const String C_BirthYear = "BirthYear";
        public const String C_BirthDateText = "BirthDateText";
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
        public const String C_ContactName = "ContactName";
        public const String C_ContactAddress = "ContactAddress";
        public const String C_ContactTel = "ContactTel";
        public const String C_ComponentFamilyID = "ComponentFamilyID";
        public const String C_AreaID = "AreaID";
        public const String C_PreferentialObjectID = "PreferentialObjectID";
        public const String C_GraduationYear = "GraduationYear";
        public const String C_System = "System";
        public const String C_LevelStudentID = "LevelStudentID";
        public const String C_Mark1 = "Mark1";
        public const String C_Mark2 = "Mark2";
        public const String C_Mark3 = "Mark3";
        public const String C_Mark4 = "Mark4";
        public const String C_Mark5 = "Mark5";
        public const String C_Mark6 = "Mark6";
        public const String C_Mark7 = "Mark7";
        public const String C_SummaryMark = "SummaryMark";
        public const String C_EthicMark = "EthicMark";
        public const String C_SpecialBranchID = "SpecialBranchID";
        public const String C_SpecialBranchID2 = "SpecialBranchID2";
        public const String C_IsReceiveDiploma = "IsReceiveDiploma";
        public const String C_IsReceiveTempDiploma = "IsReceiveTempDiploma";
        public const String C_IsReceiveImage = "IsReceiveImage";
        public const String C_IsReceiveCandidateForm = "IsReceiveCandidateForm";
        public const String C_IsReceiveTranscripts = "IsReceiveTranscripts";
        public const String C_IsReceiveHousehold = "IsReceiveHousehold";
        public const String C_IsReceiveHealthCer = "IsReceiveHealthCer";
        public const String C_IsReceivePreferentialObjectCer = "IsReceivePreferentialObjectCer";
        public const String C_IsReceiveNotifyCopy = "IsReceiveNotifyCopy";
        public const String C_IsReceiveAssure = "IsReceiveAssure";
        public const String C_IsReceived = "IsReceived";
        public const String C_ReceiveDate = "ReceiveDate";
        public const String C_ReceiveUser = "ReceiveUser";
        public const String C_IsSendNotice = "IsSendNotice";
        public const String C_CreatedDate = "CreatedDate";
        public const String C_CreatedUser = "CreatedUser";
        public const String C_UpdatedDate = "UpdatedDate";
        public const String C_UpdatedUser = "UpdatedUser";
        public const String C_IsDeleted = "IsDeleted";
        public const String C_DeletedDate = "DeletedDate";
        public const String C_DeletedUser = "DeletedUser";
        public const String C_StudentCollectionCode = "StudentCollectionCode";
        public const String C_FatherName = "FatherName";
        public const String C_FatherJob = "FatherJob";
        public const String C_FatherAddress = "FatherAddress";
        public const String C_MortherName = "MortherName";
        public const String C_MortherJob = "MortherJob";
        public const String C_MortherAddress = "MortherAddress";
        public const String C_GraduationLevel = "GraduationLevel";
        public const String C_Experience = "Experience";
        public const String C_SpecialBranchID3 = "SpecialBranchID3";
        public const String C_Result = "Result";
        public const String C_PreferentialObjectID2 = "PreferentialObjectID2";
        public const String C_PreferentialObjectID3 = "PreferentialObjectID3";
        public const String C_ContactEmail = "ContactEmail";
        public const String C_IsReceivePersonCer = "IsReceivePersonCer";
        public const String C_IsReceivePersonInfo = "IsReceivePersonInfo";
        public const String C_IsDeptDiploma = "IsDeptDiploma";
        public const String C_CerNo = "CerNo";
        public const String C_Description = "Description";
        public const String C_EthicLevel1 = "EthicLevel1";
        public const String C_EthicLevel2 = "EthicLevel2";
        public const String C_EthicLevel3 = "EthicLevel3";
        public const String C_EthicLevel4 = "EthicLevel4";
        public const String C_EthicLevel5 = "EthicLevel5";
        public const String C_EthicLevel6 = "EthicLevel6";
        public const String C_EthicLevel7 = "EthicLevel7";
        public const String C_SpecialBranchIDOk = "SpecialBranchIDOk";
        public const String C_GraduationSchool = "GraduationSchool";
        public const String C_LiveDate = "LiveDate";
        public const String C_CompanyID = "CompanyID";
        public const String C_RegisterPerson = "RegisterPerson";
        public const String C_Units = "Units";

        #endregion //Column names

        #endregion Variable Static
    }
}


