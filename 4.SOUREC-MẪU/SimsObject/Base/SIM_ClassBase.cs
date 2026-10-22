
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
    /// Created date 	: 09/04/2025 
    /// Description 
    /// </summary>	
    public partial class SIM_Class
    {
        #region Member Variables

        private string strClassID = null;
        private string strClassName = null;//Tên lớp
        private string strClassShortName = null;//Tên lớp viết tắc
        private int? intRegulationID = null;//Mã qui chế đào tạo
        private string strScienceID = null;
        private string strBranchID = null;
        private string strSpecialBranchID = null;//Mã chuyên ngành
        private string strTrainingLevelID = null;//Bậc đào tạo (Hệ đào tạo)
        private string strTrainingType = null;//Loại đào tạo
        private string strCourseID = null;//Mã khóa học
        private int? intClassSize = null;//Sỉ số lớp
        private int? intClassType = null;//Loại lớp: 0_Bình thường | 1_Ghép | 2_Tách | 3_Lớp học phần của tín chỉ (ko tồn tại lớp vật lý này)
        private long? lngClassSubjectID = null;//Nếu là lớp tách thì đây là mã môn học của lớp cha  mà nó được tách
        private string strSubjectUsedID = null;//Mã môn được ghép, để truy xuất nhanh
        private bool bolAllowScheduling = false;//Có cho sắp lịch
        private bool bolAllowTestScheduling = false;//Cho phép sắp lịch thi tự động
        private DateTime? dtmStartAt = null;//Ngày bắt đầu
        private DateTime? dtmFinishAt = null;//Ngày kết thúc
        private int? intMainSession = null;//Buổi học chính: 0: Không có buổi chủ đạo, 1: Sáng, 2: Chiều, 3:Tối
        private string strMainRoom = null;//Phòng học chính
        private bool bolIsActived = false;//Trạng thái đang học
        private int? intGroupSmallClass = null;
        private int? intSpecialBranchSubjectID = null;//Mã môn học theo chương trình đào tạo khung, khi lớp này là lớp logic của tín chỉ
        private string strManagerTeacherID = null;//Giáo viên chủ nhiệm
        private decimal? decFee = null;//Học phí học kì của sinh viên (trong tỉnh)
        private decimal? decOtherFee = null;//Học phí học kì của sinh viên (ngoài tỉnh)
        private bool bolIsCollecting = false;//Đang tuyển sinh
        private bool bolIsRegulation43 = false;//Là lớp tín chỉ phải không?
        private string strOfficeID = null;//Mã văn phòng chi nhánh
        private int? intUnitTextOfCourse = null;//Tổng số tín chỉ (không bao gồm tín chỉ tốt nghiệp. dùng xét tư cách dự thi tốt nghiệp)
        private string strContractNo = null;//Số hợp đồng đào tạo
        private DateTime? dtmContractDate = null;//Ngày hợp đồng
        private string strDecisionNo = null;//Số quyết định
        private DateTime? dtmDecisionDate = null;//Ngày quyết định
        private bool bolIsSubjectCounting = false;//Có đếm lượt môn
        private bool bolIsTempClass = false;//Là lớp tạm, để chứa học sinh từ tuyển sinh, chưa phân ngành, để lên kế hoạch thu rùi thu tiền
        private string strDescription = null;
        private string strCreatedBy = null;
        private DateTime? dtmCreatedAt = null;//Ngày tạo
        private string strModifiedBy = null;//Người sửa
        private DateTime? dtmModifiedAt = null;//Ngày sửa
        private long? lngTClassID = null;
        private bool bolIsTempClass1 = false;//Là lớp văn hóa 1 (sẽ dò theo cột TempClass1 trong SIM_Student khi nhập điểm hay là gì đó)
        private bool bolIsLogicClass = false;//Là lớp ảo (để xếp lịch)
        private bool bolIsTechClass = false;//Là lớp thuộc khối KỸ THUẬT
        private int? intGraduationTitleID = null;//Danh hiệu văn bằng tốt nghiệp
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

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
        /// ClassName
        /// Tên lớp
        /// </summary>
        public string ClassName
        {
            get { return strClassName; }
            set { strClassName = value; }
        }
        /// <summary>
        /// ClassShortName
        /// Tên lớp viết tắc
        /// </summary>
        public string ClassShortName
        {
            get { return strClassShortName; }
            set { strClassShortName = value; }
        }
        /// <summary>
        /// RegulationID
        /// Mã qui chế đào tạo
        /// </summary>
        public int? RegulationID
        {
            get { return intRegulationID; }
            set { intRegulationID = value; }
        }
        /// <summary>
        /// ScienceID
        /// 
        /// </summary>
        public string ScienceID
        {
            get { return strScienceID; }
            set { strScienceID = value; }
        }
        /// <summary>
        /// BranchID
        /// 
        /// </summary>
        public string BranchID
        {
            get { return strBranchID; }
            set { strBranchID = value; }
        }
        /// <summary>
        /// SpecialBranchID
        /// Mã chuyên ngành
        /// </summary>
        public string SpecialBranchID
        {
            get { return strSpecialBranchID; }
            set { strSpecialBranchID = value; }
        }
        /// <summary>
        /// TrainingLevelID
        /// Bậc đào tạo (Hệ đào tạo)
        /// </summary>
        public string TrainingLevelID
        {
            get { return strTrainingLevelID; }
            set { strTrainingLevelID = value; }
        }
        /// <summary>
        /// TrainingType
        /// Loại đào tạo
        /// </summary>
        public string TrainingType
        {
            get { return strTrainingType; }
            set { strTrainingType = value; }
        }
        /// <summary>
        /// CourseID
        /// Mã khóa học
        /// </summary>
        public string CourseID
        {
            get { return strCourseID; }
            set { strCourseID = value; }
        }
        /// <summary>
        /// ClassSize
        /// Sỉ số lớp
        /// </summary>
        public int? ClassSize
        {
            get { return intClassSize; }
            set { intClassSize = value; }
        }
        /// <summary>
        /// ClassType
        /// Loại lớp: 0_Bình thường | 1_Ghép | 2_Tách | 3_Lớp học phần của tín chỉ (ko tồn tại lớp vật lý này)
        /// </summary>
        public int? ClassType
        {
            get { return intClassType; }
            set { intClassType = value; }
        }
        /// <summary>
        /// ClassSubjectID
        /// Nếu là lớp tách thì đây là mã môn học của lớp cha  mà nó được tách
        /// </summary>
        public long? ClassSubjectID
        {
            get { return lngClassSubjectID; }
            set { lngClassSubjectID = value; }
        }
        /// <summary>
        /// SubjectUsedID
        /// Mã môn được ghép, để truy xuất nhanh
        /// </summary>
        public string SubjectUsedID
        {
            get { return strSubjectUsedID; }
            set { strSubjectUsedID = value; }
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
        /// StartAt
        /// Ngày bắt đầu
        /// </summary>
        public DateTime? StartAt
        {
            get { return dtmStartAt; }
            set { dtmStartAt = value; }
        }
        /// <summary>
        /// FinishAt
        /// Ngày kết thúc
        /// </summary>
        public DateTime? FinishAt
        {
            get { return dtmFinishAt; }
            set { dtmFinishAt = value; }
        }
        /// <summary>
        /// MainSession
        /// Buổi học chính: 0: Không có buổi chủ đạo, 1: Sáng, 2: Chiều, 3:Tối
        /// </summary>
        public int? MainSession
        {
            get { return intMainSession; }
            set { intMainSession = value; }
        }
        /// <summary>
        /// MainRoom
        /// Phòng học chính
        /// </summary>
        public string MainRoom
        {
            get { return strMainRoom; }
            set { strMainRoom = value; }
        }
        /// <summary>
        /// IsActived
        /// Trạng thái đang học
        /// </summary>
        public bool IsActived
        {
            get { return bolIsActived; }
            set { bolIsActived = value; }
        }
        /// <summary>
        /// GroupSmallClass
        /// 
        /// </summary>
        public int? GroupSmallClass
        {
            get { return intGroupSmallClass; }
            set { intGroupSmallClass = value; }
        }
        /// <summary>
        /// SpecialBranchSubjectID
        /// Mã môn học theo chương trình đào tạo khung, khi lớp này là lớp logic của tín chỉ
        /// </summary>
        public int? SpecialBranchSubjectID
        {
            get { return intSpecialBranchSubjectID; }
            set { intSpecialBranchSubjectID = value; }
        }
        /// <summary>
        /// ManagerTeacherID
        /// Giáo viên chủ nhiệm
        /// </summary>
        public string ManagerTeacherID
        {
            get { return strManagerTeacherID; }
            set { strManagerTeacherID = value; }
        }
        /// <summary>
        /// Fee
        /// Học phí học kì của sinh viên (trong tỉnh)
        /// </summary>
        public decimal? Fee
        {
            get { return decFee; }
            set { decFee = value; }
        }
        /// <summary>
        /// OtherFee
        /// Học phí học kì của sinh viên (ngoài tỉnh)
        /// </summary>
        public decimal? OtherFee
        {
            get { return decOtherFee; }
            set { decOtherFee = value; }
        }
        /// <summary>
        /// IsCollecting
        /// Đang tuyển sinh
        /// </summary>
        public bool IsCollecting
        {
            get { return bolIsCollecting; }
            set { bolIsCollecting = value; }
        }
        /// <summary>
        /// IsRegulation43
        /// Là lớp tín chỉ phải không?
        /// </summary>
        public bool IsRegulation43
        {
            get { return bolIsRegulation43; }
            set { bolIsRegulation43 = value; }
        }
        /// <summary>
        /// OfficeID
        /// Mã văn phòng chi nhánh
        /// </summary>
        public string OfficeID
        {
            get { return strOfficeID; }
            set { strOfficeID = value; }
        }
        /// <summary>
        /// UnitTextOfCourse
        /// Tổng số tín chỉ (không bao gồm tín chỉ tốt nghiệp. dùng xét tư cách dự thi tốt nghiệp)
        /// </summary>
        public int? UnitTextOfCourse
        {
            get { return intUnitTextOfCourse; }
            set { intUnitTextOfCourse = value; }
        }
        /// <summary>
        /// ContractNo
        /// Số hợp đồng đào tạo
        /// </summary>
        public string ContractNo
        {
            get { return strContractNo; }
            set { strContractNo = value; }
        }
        /// <summary>
        /// ContractDate
        /// Ngày hợp đồng
        /// </summary>
        public DateTime? ContractDate
        {
            get { return dtmContractDate; }
            set { dtmContractDate = value; }
        }
        /// <summary>
        /// DecisionNo
        /// Số quyết định
        /// </summary>
        public string DecisionNo
        {
            get { return strDecisionNo; }
            set { strDecisionNo = value; }
        }
        /// <summary>
        /// DecisionDate
        /// Ngày quyết định
        /// </summary>
        public DateTime? DecisionDate
        {
            get { return dtmDecisionDate; }
            set { dtmDecisionDate = value; }
        }
        /// <summary>
        /// IsSubjectCounting
        /// Có đếm lượt môn
        /// </summary>
        public bool IsSubjectCounting
        {
            get { return bolIsSubjectCounting; }
            set { bolIsSubjectCounting = value; }
        }
        /// <summary>
        /// IsTempClass
        /// Là lớp tạm, để chứa học sinh từ tuyển sinh, chưa phân ngành, để lên kế hoạch thu rùi thu tiền
        /// </summary>
        public bool IsTempClass
        {
            get { return bolIsTempClass; }
            set { bolIsTempClass = value; }
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
        /// TClassID
        /// 
        /// </summary>
        public long? TClassID
        {
            get { return lngTClassID; }
            set { lngTClassID = value; }
        }
        /// <summary>
        /// IsTempClass1
        /// Là lớp văn hóa 1 (sẽ dò theo cột TempClass1 trong SIM_Student khi nhập điểm hay là gì đó)
        /// </summary>
        public bool IsTempClass1
        {
            get { return bolIsTempClass1; }
            set { bolIsTempClass1 = value; }
        }
        /// <summary>
        /// IsLogicClass
        /// Là lớp ảo (để xếp lịch)
        /// </summary>
        public bool IsLogicClass
        {
            get { return bolIsLogicClass; }
            set { bolIsLogicClass = value; }
        }
        /// <summary>
        /// IsTechClass
        /// Là lớp thuộc khối KỸ THUẬT
        /// </summary>
        public bool IsTechClass
        {
            get { return bolIsTechClass; }
            set { bolIsTechClass = value; }
        }
        /// <summary>
        /// GraduationTitleID
        /// Danh hiệu văn bằng tốt nghiệp
        /// </summary>
        public int? GraduationTitleID
        {
            get { return intGraduationTitleID; }
            set { intGraduationTitleID = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_ClassID.ToUpper()) && !Convert.IsDBNull(reader[C_ClassID])) this.strClassID = Convert.ToString(reader[C_ClassID]);
                    if (reader.GetName(i).ToUpper().Equals(C_ClassName.ToUpper()) && !Convert.IsDBNull(reader[C_ClassName])) this.strClassName = Convert.ToString(reader[C_ClassName]);
                    if (reader.GetName(i).ToUpper().Equals(C_ClassShortName.ToUpper()) && !Convert.IsDBNull(reader[C_ClassShortName])) this.strClassShortName = Convert.ToString(reader[C_ClassShortName]);
                    if (reader.GetName(i).ToUpper().Equals(C_RegulationID.ToUpper()) && !Convert.IsDBNull(reader[C_RegulationID])) this.intRegulationID = Convert.ToInt32(reader[C_RegulationID]);
                    if (reader.GetName(i).ToUpper().Equals(C_ScienceID.ToUpper()) && !Convert.IsDBNull(reader[C_ScienceID])) this.strScienceID = Convert.ToString(reader[C_ScienceID]);
                    if (reader.GetName(i).ToUpper().Equals(C_BranchID.ToUpper()) && !Convert.IsDBNull(reader[C_BranchID])) this.strBranchID = Convert.ToString(reader[C_BranchID]);
                    if (reader.GetName(i).ToUpper().Equals(C_SpecialBranchID.ToUpper()) && !Convert.IsDBNull(reader[C_SpecialBranchID])) this.strSpecialBranchID = Convert.ToString(reader[C_SpecialBranchID]);
                    if (reader.GetName(i).ToUpper().Equals(C_TrainingLevelID.ToUpper()) && !Convert.IsDBNull(reader[C_TrainingLevelID])) this.strTrainingLevelID = Convert.ToString(reader[C_TrainingLevelID]);
                    if (reader.GetName(i).ToUpper().Equals(C_TrainingType.ToUpper()) && !Convert.IsDBNull(reader[C_TrainingType])) this.strTrainingType = Convert.ToString(reader[C_TrainingType]);
                    if (reader.GetName(i).ToUpper().Equals(C_CourseID.ToUpper()) && !Convert.IsDBNull(reader[C_CourseID])) this.strCourseID = Convert.ToString(reader[C_CourseID]);
                    if (reader.GetName(i).ToUpper().Equals(C_ClassSize.ToUpper()) && !Convert.IsDBNull(reader[C_ClassSize])) this.intClassSize = Convert.ToInt32(reader[C_ClassSize]);
                    if (reader.GetName(i).ToUpper().Equals(C_ClassType.ToUpper()) && !Convert.IsDBNull(reader[C_ClassType])) this.intClassType = Convert.ToInt32(reader[C_ClassType]);
                    if (reader.GetName(i).ToUpper().Equals(C_ClassSubjectID.ToUpper()) && !Convert.IsDBNull(reader[C_ClassSubjectID])) this.lngClassSubjectID = Convert.ToInt64(reader[C_ClassSubjectID]);
                    if (reader.GetName(i).ToUpper().Equals(C_SubjectUsedID.ToUpper()) && !Convert.IsDBNull(reader[C_SubjectUsedID])) this.strSubjectUsedID = Convert.ToString(reader[C_SubjectUsedID]);
                    if (reader.GetName(i).ToUpper().Equals(C_AllowScheduling.ToUpper()) && !Convert.IsDBNull(reader[C_AllowScheduling])) this.bolAllowScheduling = Convert.ToBoolean(reader[C_AllowScheduling]);
                    if (reader.GetName(i).ToUpper().Equals(C_AllowTestScheduling.ToUpper()) && !Convert.IsDBNull(reader[C_AllowTestScheduling])) this.bolAllowTestScheduling = Convert.ToBoolean(reader[C_AllowTestScheduling]);
                    if (reader.GetName(i).ToUpper().Equals(C_StartAt.ToUpper()) && !Convert.IsDBNull(reader[C_StartAt])) this.dtmStartAt = Convert.ToDateTime(reader[C_StartAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_FinishAt.ToUpper()) && !Convert.IsDBNull(reader[C_FinishAt])) this.dtmFinishAt = Convert.ToDateTime(reader[C_FinishAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_MainSession.ToUpper()) && !Convert.IsDBNull(reader[C_MainSession])) this.intMainSession = Convert.ToInt32(reader[C_MainSession]);
                    if (reader.GetName(i).ToUpper().Equals(C_MainRoom.ToUpper()) && !Convert.IsDBNull(reader[C_MainRoom])) this.strMainRoom = Convert.ToString(reader[C_MainRoom]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsActived.ToUpper()) && !Convert.IsDBNull(reader[C_IsActived])) this.bolIsActived = Convert.ToBoolean(reader[C_IsActived]);
                    if (reader.GetName(i).ToUpper().Equals(C_GroupSmallClass.ToUpper()) && !Convert.IsDBNull(reader[C_GroupSmallClass])) this.intGroupSmallClass = Convert.ToInt32(reader[C_GroupSmallClass]);
                    if (reader.GetName(i).ToUpper().Equals(C_SpecialBranchSubjectID.ToUpper()) && !Convert.IsDBNull(reader[C_SpecialBranchSubjectID])) this.intSpecialBranchSubjectID = Convert.ToInt32(reader[C_SpecialBranchSubjectID]);
                    if (reader.GetName(i).ToUpper().Equals(C_ManagerTeacherID.ToUpper()) && !Convert.IsDBNull(reader[C_ManagerTeacherID])) this.strManagerTeacherID = Convert.ToString(reader[C_ManagerTeacherID]);
                    if (reader.GetName(i).ToUpper().Equals(C_Fee.ToUpper()) && !Convert.IsDBNull(reader[C_Fee])) this.decFee = Convert.ToDecimal(reader[C_Fee]);
                    if (reader.GetName(i).ToUpper().Equals(C_OtherFee.ToUpper()) && !Convert.IsDBNull(reader[C_OtherFee])) this.decOtherFee = Convert.ToDecimal(reader[C_OtherFee]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsCollecting.ToUpper()) && !Convert.IsDBNull(reader[C_IsCollecting])) this.bolIsCollecting = Convert.ToBoolean(reader[C_IsCollecting]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsRegulation43.ToUpper()) && !Convert.IsDBNull(reader[C_IsRegulation43])) this.bolIsRegulation43 = Convert.ToBoolean(reader[C_IsRegulation43]);
                    if (reader.GetName(i).ToUpper().Equals(C_OfficeID.ToUpper()) && !Convert.IsDBNull(reader[C_OfficeID])) this.strOfficeID = Convert.ToString(reader[C_OfficeID]);
                    if (reader.GetName(i).ToUpper().Equals(C_UnitTextOfCourse.ToUpper()) && !Convert.IsDBNull(reader[C_UnitTextOfCourse])) this.intUnitTextOfCourse = Convert.ToInt32(reader[C_UnitTextOfCourse]);
                    if (reader.GetName(i).ToUpper().Equals(C_ContractNo.ToUpper()) && !Convert.IsDBNull(reader[C_ContractNo])) this.strContractNo = Convert.ToString(reader[C_ContractNo]);
                    if (reader.GetName(i).ToUpper().Equals(C_ContractDate.ToUpper()) && !Convert.IsDBNull(reader[C_ContractDate])) this.dtmContractDate = Convert.ToDateTime(reader[C_ContractDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_DecisionNo.ToUpper()) && !Convert.IsDBNull(reader[C_DecisionNo])) this.strDecisionNo = Convert.ToString(reader[C_DecisionNo]);
                    if (reader.GetName(i).ToUpper().Equals(C_DecisionDate.ToUpper()) && !Convert.IsDBNull(reader[C_DecisionDate])) this.dtmDecisionDate = Convert.ToDateTime(reader[C_DecisionDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsSubjectCounting.ToUpper()) && !Convert.IsDBNull(reader[C_IsSubjectCounting])) this.bolIsSubjectCounting = Convert.ToBoolean(reader[C_IsSubjectCounting]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsTempClass.ToUpper()) && !Convert.IsDBNull(reader[C_IsTempClass])) this.bolIsTempClass = Convert.ToBoolean(reader[C_IsTempClass]);
                    if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedBy.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedBy])) this.strCreatedBy = Convert.ToString(reader[C_CreatedBy]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(reader[C_CreatedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_ModifiedBy.ToUpper()) && !Convert.IsDBNull(reader[C_ModifiedBy])) this.strModifiedBy = Convert.ToString(reader[C_ModifiedBy]);
                    if (reader.GetName(i).ToUpper().Equals(C_ModifiedAt.ToUpper()) && !Convert.IsDBNull(reader[C_ModifiedAt])) this.dtmModifiedAt = Convert.ToDateTime(reader[C_ModifiedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_TClassID.ToUpper()) && !Convert.IsDBNull(reader[C_TClassID])) this.lngTClassID = Convert.ToInt64(reader[C_TClassID]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsTempClass1.ToUpper()) && !Convert.IsDBNull(reader[C_IsTempClass1])) this.bolIsTempClass1 = Convert.ToBoolean(reader[C_IsTempClass1]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsLogicClass.ToUpper()) && !Convert.IsDBNull(reader[C_IsLogicClass])) this.bolIsLogicClass = Convert.ToBoolean(reader[C_IsLogicClass]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsTechClass.ToUpper()) && !Convert.IsDBNull(reader[C_IsTechClass])) this.bolIsTechClass = Convert.ToBoolean(reader[C_IsTechClass]);
                    if (reader.GetName(i).ToUpper().Equals(C_GraduationTitleID.ToUpper()) && !Convert.IsDBNull(reader[C_GraduationTitleID])) this.intGraduationTitleID = Convert.ToInt32(reader[C_GraduationTitleID]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_Class", objEx);
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
                if (!Convert.IsDBNull(drw[C_ClassID])) this.strClassID = Convert.ToString(drw[C_ClassID]);
                if (!Convert.IsDBNull(drw[C_ClassName])) this.strClassName = Convert.ToString(drw[C_ClassName]);
                if (!Convert.IsDBNull(drw[C_ClassShortName])) this.strClassShortName = Convert.ToString(drw[C_ClassShortName]);
                if (!Convert.IsDBNull(drw[C_RegulationID])) this.intRegulationID = Convert.ToInt32(drw[C_RegulationID]);
                if (!Convert.IsDBNull(drw[C_ScienceID])) this.strScienceID = Convert.ToString(drw[C_ScienceID]);
                if (!Convert.IsDBNull(drw[C_BranchID])) this.strBranchID = Convert.ToString(drw[C_BranchID]);
                if (!Convert.IsDBNull(drw[C_SpecialBranchID])) this.strSpecialBranchID = Convert.ToString(drw[C_SpecialBranchID]);
                if (!Convert.IsDBNull(drw[C_TrainingLevelID])) this.strTrainingLevelID = Convert.ToString(drw[C_TrainingLevelID]);
                if (!Convert.IsDBNull(drw[C_TrainingType])) this.strTrainingType = Convert.ToString(drw[C_TrainingType]);
                if (!Convert.IsDBNull(drw[C_CourseID])) this.strCourseID = Convert.ToString(drw[C_CourseID]);
                if (!Convert.IsDBNull(drw[C_ClassSize])) this.intClassSize = Convert.ToInt32(drw[C_ClassSize]);
                if (!Convert.IsDBNull(drw[C_ClassType])) this.intClassType = Convert.ToInt32(drw[C_ClassType]);
                if (!Convert.IsDBNull(drw[C_ClassSubjectID])) this.lngClassSubjectID = Convert.ToInt64(drw[C_ClassSubjectID]);
                if (!Convert.IsDBNull(drw[C_SubjectUsedID])) this.strSubjectUsedID = Convert.ToString(drw[C_SubjectUsedID]);
                if (!Convert.IsDBNull(drw[C_AllowScheduling])) this.bolAllowScheduling = Convert.ToBoolean(drw[C_AllowScheduling]);
                if (!Convert.IsDBNull(drw[C_AllowTestScheduling])) this.bolAllowTestScheduling = Convert.ToBoolean(drw[C_AllowTestScheduling]);
                if (!Convert.IsDBNull(drw[C_StartAt])) this.dtmStartAt = Convert.ToDateTime(drw[C_StartAt]);
                if (!Convert.IsDBNull(drw[C_FinishAt])) this.dtmFinishAt = Convert.ToDateTime(drw[C_FinishAt]);
                if (!Convert.IsDBNull(drw[C_MainSession])) this.intMainSession = Convert.ToInt32(drw[C_MainSession]);
                if (!Convert.IsDBNull(drw[C_MainRoom])) this.strMainRoom = Convert.ToString(drw[C_MainRoom]);
                if (!Convert.IsDBNull(drw[C_IsActived])) this.bolIsActived = Convert.ToBoolean(drw[C_IsActived]);
                if (!Convert.IsDBNull(drw[C_GroupSmallClass])) this.intGroupSmallClass = Convert.ToInt32(drw[C_GroupSmallClass]);
                if (!Convert.IsDBNull(drw[C_SpecialBranchSubjectID])) this.intSpecialBranchSubjectID = Convert.ToInt32(drw[C_SpecialBranchSubjectID]);
                if (!Convert.IsDBNull(drw[C_ManagerTeacherID])) this.strManagerTeacherID = Convert.ToString(drw[C_ManagerTeacherID]);
                if (!Convert.IsDBNull(drw[C_Fee])) this.decFee = Convert.ToDecimal(drw[C_Fee]);
                if (!Convert.IsDBNull(drw[C_OtherFee])) this.decOtherFee = Convert.ToDecimal(drw[C_OtherFee]);
                if (!Convert.IsDBNull(drw[C_IsCollecting])) this.bolIsCollecting = Convert.ToBoolean(drw[C_IsCollecting]);
                if (!Convert.IsDBNull(drw[C_IsRegulation43])) this.bolIsRegulation43 = Convert.ToBoolean(drw[C_IsRegulation43]);
                if (!Convert.IsDBNull(drw[C_OfficeID])) this.strOfficeID = Convert.ToString(drw[C_OfficeID]);
                if (!Convert.IsDBNull(drw[C_UnitTextOfCourse])) this.intUnitTextOfCourse = Convert.ToInt32(drw[C_UnitTextOfCourse]);
                if (!Convert.IsDBNull(drw[C_ContractNo])) this.strContractNo = Convert.ToString(drw[C_ContractNo]);
                if (!Convert.IsDBNull(drw[C_ContractDate])) this.dtmContractDate = Convert.ToDateTime(drw[C_ContractDate]);
                if (!Convert.IsDBNull(drw[C_DecisionNo])) this.strDecisionNo = Convert.ToString(drw[C_DecisionNo]);
                if (!Convert.IsDBNull(drw[C_DecisionDate])) this.dtmDecisionDate = Convert.ToDateTime(drw[C_DecisionDate]);
                if (!Convert.IsDBNull(drw[C_IsSubjectCounting])) this.bolIsSubjectCounting = Convert.ToBoolean(drw[C_IsSubjectCounting]);
                if (!Convert.IsDBNull(drw[C_IsTempClass])) this.bolIsTempClass = Convert.ToBoolean(drw[C_IsTempClass]);
                if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
                if (!Convert.IsDBNull(drw[C_CreatedBy])) this.strCreatedBy = Convert.ToString(drw[C_CreatedBy]);
                if (!Convert.IsDBNull(drw[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(drw[C_CreatedAt]);
                if (!Convert.IsDBNull(drw[C_ModifiedBy])) this.strModifiedBy = Convert.ToString(drw[C_ModifiedBy]);
                if (!Convert.IsDBNull(drw[C_ModifiedAt])) this.dtmModifiedAt = Convert.ToDateTime(drw[C_ModifiedAt]);
                if (!Convert.IsDBNull(drw[C_TClassID])) this.lngTClassID = Convert.ToInt64(drw[C_TClassID]);
                if (!Convert.IsDBNull(drw[C_IsTempClass1])) this.bolIsTempClass1 = Convert.ToBoolean(drw[C_IsTempClass1]);
                if (!Convert.IsDBNull(drw[C_IsLogicClass])) this.bolIsLogicClass = Convert.ToBoolean(drw[C_IsLogicClass]);
                if (!Convert.IsDBNull(drw[C_IsTechClass])) this.bolIsTechClass = Convert.ToBoolean(drw[C_IsTechClass]);
                if (!Convert.IsDBNull(drw[C_GraduationTitleID])) this.intGraduationTitleID = Convert.ToInt32(drw[C_GraduationTitleID]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_Class", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        /// Nạp thông tin item 
        /// Store: SIM_Class_GET 
        ///</summary>
        /// <returns>true ? Có : False ? Không</returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Class_GET");
                objIData.AddParameter(P_ClassID, this.strClassID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_Class", objEx);
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
        /// Store: SIM_Class_GET 
        ///</summary>
        /// <returns> SIM_Class </returns>
        public SIM_Class Get(string strClassID)
        {
            SIM_Class obj = new SIM_Class();
            if (objIData != null)
                obj.IDB = objIData;
            obj.ClassID = strClassID;
            if (obj.Get())
                return obj;
            this.objErrorException = obj.ErrorException;
            return null;
        }
        ///<summary>
        /// ExecNonQuery : SIM_Class
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Class", objEx);
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
        /// Search : SIM_Class
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Class", objEx);
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
        /// Search : SIM_Class
        /// Lấy hết dữ liệu
        /// Store: SIM_Class_GETALL 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable GetAll()
        {
            return GetDataTable("SIM_Class_GETALL");
        }

        ///<summary>
        /// Search : SIM_Class
        /// Tìm dữ liệu
        /// Store: SIM_Class_SEARCH 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable Search(params object[] pars)
        {
            return GetDataTable("SIM_Class_SEARCH", pars);
        }

        ///<summary>
        /// Add : SIM_Class
        /// Thêm dữ liệu
        /// Store: SIM_Class_ADD 
        ///</summary>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Class_ADD");
                objIData.AddParameter(P_ClassID, this.strClassID);
                objIData.AddParameter(P_ClassName, this.strClassName);
                objIData.AddParameter(P_ClassShortName, this.strClassShortName);
                objIData.AddParameter(P_RegulationID, this.intRegulationID);
                objIData.AddParameter(P_ScienceID, this.strScienceID);
                objIData.AddParameter(P_BranchID, this.strBranchID);
                objIData.AddParameter(P_SpecialBranchID, this.strSpecialBranchID);
                objIData.AddParameter(P_TrainingLevelID, this.strTrainingLevelID);
                objIData.AddParameter(P_TrainingType, this.strTrainingType);
                objIData.AddParameter(P_CourseID, this.strCourseID);
                objIData.AddParameter(P_ClassSize, this.intClassSize);
                objIData.AddParameter(P_ClassType, this.intClassType);
                objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
                objIData.AddParameter(P_SubjectUsedID, this.strSubjectUsedID);
                objIData.AddParameter(P_AllowScheduling, this.bolAllowScheduling);
                objIData.AddParameter(P_AllowTestScheduling, this.bolAllowTestScheduling);
                objIData.AddParameter(P_StartAt, this.dtmStartAt);
                objIData.AddParameter(P_FinishAt, this.dtmFinishAt);
                objIData.AddParameter(P_MainSession, this.intMainSession);
                objIData.AddParameter(P_MainRoom, this.strMainRoom);
                objIData.AddParameter(P_IsActived, this.bolIsActived);
                objIData.AddParameter(P_GroupSmallClass, this.intGroupSmallClass);
                objIData.AddParameter(P_SpecialBranchSubjectID, this.intSpecialBranchSubjectID);
                objIData.AddParameter(P_ManagerTeacherID, this.strManagerTeacherID);
                objIData.AddParameter(P_Fee, this.decFee);
                objIData.AddParameter(P_OtherFee, this.decOtherFee);
                objIData.AddParameter(P_IsCollecting, this.bolIsCollecting);
                objIData.AddParameter(P_IsRegulation43, this.bolIsRegulation43);
                objIData.AddParameter(P_OfficeID, this.strOfficeID);
                objIData.AddParameter(P_UnitTextOfCourse, this.intUnitTextOfCourse);
                objIData.AddParameter(P_ContractNo, this.strContractNo);
                objIData.AddParameter(P_ContractDate, this.dtmContractDate);
                objIData.AddParameter(P_DecisionNo, this.strDecisionNo);
                objIData.AddParameter(P_DecisionDate, this.dtmDecisionDate);
                objIData.AddParameter(P_IsSubjectCounting, this.bolIsSubjectCounting);
                objIData.AddParameter(P_IsTempClass, this.bolIsTempClass);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_CreatedBy, this.strCreatedBy);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_ModifiedBy, this.strModifiedBy);
                objIData.AddParameter(P_ModifiedAt, this.dtmModifiedAt);
                objIData.AddParameter(P_TClassID, this.lngTClassID);
                objIData.AddParameter(P_IsTempClass1, this.bolIsTempClass1);
                objIData.AddParameter(P_IsLogicClass, this.bolIsLogicClass);
                objIData.AddParameter(P_IsTechClass, this.bolIsTechClass);
                objIData.AddParameter(P_GraduationTitleID, this.intGraduationTitleID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_Class", objEx);
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
        /// Update : SIM_Class
        /// Cập nhật dữ liệu
        /// Store: SIM_Class_EDIT 
        ///</summary>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Class_EDIT");
                objIData.AddParameter(P_ClassID, this.strClassID);
                objIData.AddParameter(P_ClassName, this.strClassName);
                objIData.AddParameter(P_ClassShortName, this.strClassShortName);
                objIData.AddParameter(P_RegulationID, this.intRegulationID);
                objIData.AddParameter(P_ScienceID, this.strScienceID);
                objIData.AddParameter(P_BranchID, this.strBranchID);
                objIData.AddParameter(P_SpecialBranchID, this.strSpecialBranchID);
                objIData.AddParameter(P_TrainingLevelID, this.strTrainingLevelID);
                objIData.AddParameter(P_TrainingType, this.strTrainingType);
                objIData.AddParameter(P_CourseID, this.strCourseID);
                objIData.AddParameter(P_ClassSize, this.intClassSize);
                objIData.AddParameter(P_ClassType, this.intClassType);
                objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
                objIData.AddParameter(P_SubjectUsedID, this.strSubjectUsedID);
                objIData.AddParameter(P_AllowScheduling, this.bolAllowScheduling);
                objIData.AddParameter(P_AllowTestScheduling, this.bolAllowTestScheduling);
                objIData.AddParameter(P_StartAt, this.dtmStartAt);
                objIData.AddParameter(P_FinishAt, this.dtmFinishAt);
                objIData.AddParameter(P_MainSession, this.intMainSession);
                objIData.AddParameter(P_MainRoom, this.strMainRoom);
                objIData.AddParameter(P_IsActived, this.bolIsActived);
                objIData.AddParameter(P_GroupSmallClass, this.intGroupSmallClass);
                objIData.AddParameter(P_SpecialBranchSubjectID, this.intSpecialBranchSubjectID);
                objIData.AddParameter(P_ManagerTeacherID, this.strManagerTeacherID);
                objIData.AddParameter(P_Fee, this.decFee);
                objIData.AddParameter(P_OtherFee, this.decOtherFee);
                objIData.AddParameter(P_IsCollecting, this.bolIsCollecting);
                objIData.AddParameter(P_IsRegulation43, this.bolIsRegulation43);
                objIData.AddParameter(P_OfficeID, this.strOfficeID);
                objIData.AddParameter(P_UnitTextOfCourse, this.intUnitTextOfCourse);
                objIData.AddParameter(P_ContractNo, this.strContractNo);
                objIData.AddParameter(P_ContractDate, this.dtmContractDate);
                objIData.AddParameter(P_DecisionNo, this.strDecisionNo);
                objIData.AddParameter(P_DecisionDate, this.dtmDecisionDate);
                objIData.AddParameter(P_IsSubjectCounting, this.bolIsSubjectCounting);
                objIData.AddParameter(P_IsTempClass, this.bolIsTempClass);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_CreatedBy, this.strCreatedBy);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_ModifiedBy, this.strModifiedBy);
                objIData.AddParameter(P_ModifiedAt, this.dtmModifiedAt);
                objIData.AddParameter(P_TClassID, this.lngTClassID);
                objIData.AddParameter(P_IsTempClass1, this.bolIsTempClass1);
                objIData.AddParameter(P_IsLogicClass, this.bolIsLogicClass);
                objIData.AddParameter(P_IsTechClass, this.bolIsTechClass);
                objIData.AddParameter(P_GraduationTitleID, this.intGraduationTitleID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_Class", objEx);
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
        /// Delete : SIM_Class
        /// Xóa dữ liệu
        /// Store: SIM_Class_DELETE 
        ///</summary>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Class_DELETE");
                objIData.AddParameter(P_ClassID, this.strClassID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_Class", objEx);
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
        /// Store: SIM_Class_DELETE 
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(string strClassID)
        {
            this.strClassID = strClassID;
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

        public SIM_Class()
        {
        }
        public SIM_Class(string strClassID)
        {
            this.strClassID = strClassID;
            this.Get();
        }

        #endregion

        #region Variable Static

        #region Parameter Names

        public const String P_ClassID = "@" + C_ClassID;
        public const String P_ClassName = "@" + C_ClassName;
        public const String P_ClassShortName = "@" + C_ClassShortName;
        public const String P_RegulationID = "@" + C_RegulationID;
        public const String P_ScienceID = "@" + C_ScienceID;
        public const String P_BranchID = "@" + C_BranchID;
        public const String P_SpecialBranchID = "@" + C_SpecialBranchID;
        public const String P_TrainingLevelID = "@" + C_TrainingLevelID;
        public const String P_TrainingType = "@" + C_TrainingType;
        public const String P_CourseID = "@" + C_CourseID;
        public const String P_ClassSize = "@" + C_ClassSize;
        public const String P_ClassType = "@" + C_ClassType;
        public const String P_ClassSubjectID = "@" + C_ClassSubjectID;
        public const String P_SubjectUsedID = "@" + C_SubjectUsedID;
        public const String P_AllowScheduling = "@" + C_AllowScheduling;
        public const String P_AllowTestScheduling = "@" + C_AllowTestScheduling;
        public const String P_StartAt = "@" + C_StartAt;
        public const String P_FinishAt = "@" + C_FinishAt;
        public const String P_MainSession = "@" + C_MainSession;
        public const String P_MainRoom = "@" + C_MainRoom;
        public const String P_IsActived = "@" + C_IsActived;
        public const String P_GroupSmallClass = "@" + C_GroupSmallClass;
        public const String P_SpecialBranchSubjectID = "@" + C_SpecialBranchSubjectID;
        public const String P_ManagerTeacherID = "@" + C_ManagerTeacherID;
        public const String P_Fee = "@" + C_Fee;
        public const String P_OtherFee = "@" + C_OtherFee;
        public const String P_IsCollecting = "@" + C_IsCollecting;
        public const String P_IsRegulation43 = "@" + C_IsRegulation43;
        public const String P_OfficeID = "@" + C_OfficeID;
        public const String P_UnitTextOfCourse = "@" + C_UnitTextOfCourse;
        public const String P_ContractNo = "@" + C_ContractNo;
        public const String P_ContractDate = "@" + C_ContractDate;
        public const String P_DecisionNo = "@" + C_DecisionNo;
        public const String P_DecisionDate = "@" + C_DecisionDate;
        public const String P_IsSubjectCounting = "@" + C_IsSubjectCounting;
        public const String P_IsTempClass = "@" + C_IsTempClass;
        public const String P_Description = "@" + C_Description;
        public const String P_CreatedBy = "@" + C_CreatedBy;
        public const String P_CreatedAt = "@" + C_CreatedAt;
        public const String P_ModifiedBy = "@" + C_ModifiedBy;
        public const String P_ModifiedAt = "@" + C_ModifiedAt;
        public const String P_TClassID = "@" + C_TClassID;
        public const String P_IsTempClass1 = "@" + C_IsTempClass1;
        public const String P_IsLogicClass = "@" + C_IsLogicClass;
        public const String P_IsTechClass = "@" + C_IsTechClass;
        public const String P_GraduationTitleID = "@" + C_GraduationTitleID;

        #endregion //Parameter names

        #region Column Names

        public const String C_ClassID = "ClassID";
        public const String C_ClassName = "ClassName";
        public const String C_ClassShortName = "ClassShortName";
        public const String C_RegulationID = "RegulationID";
        public const String C_ScienceID = "ScienceID";
        public const String C_BranchID = "BranchID";
        public const String C_SpecialBranchID = "SpecialBranchID";
        public const String C_TrainingLevelID = "TrainingLevelID";
        public const String C_TrainingType = "TrainingType";
        public const String C_CourseID = "CourseID";
        public const String C_ClassSize = "ClassSize";
        public const String C_ClassType = "ClassType";
        public const String C_ClassSubjectID = "ClassSubjectID";
        public const String C_SubjectUsedID = "SubjectUsedID";
        public const String C_AllowScheduling = "AllowScheduling";
        public const String C_AllowTestScheduling = "AllowTestScheduling";
        public const String C_StartAt = "StartAt";
        public const String C_FinishAt = "FinishAt";
        public const String C_MainSession = "MainSession";
        public const String C_MainRoom = "MainRoom";
        public const String C_IsActived = "IsActived";
        public const String C_GroupSmallClass = "GroupSmallClass";
        public const String C_SpecialBranchSubjectID = "SpecialBranchSubjectID";
        public const String C_ManagerTeacherID = "ManagerTeacherID";
        public const String C_Fee = "Fee";
        public const String C_OtherFee = "OtherFee";
        public const String C_IsCollecting = "IsCollecting";
        public const String C_IsRegulation43 = "IsRegulation43";
        public const String C_OfficeID = "OfficeID";
        public const String C_UnitTextOfCourse = "UnitTextOfCourse";
        public const String C_ContractNo = "ContractNo";
        public const String C_ContractDate = "ContractDate";
        public const String C_DecisionNo = "DecisionNo";
        public const String C_DecisionDate = "DecisionDate";
        public const String C_IsSubjectCounting = "IsSubjectCounting";
        public const String C_IsTempClass = "IsTempClass";
        public const String C_Description = "Description";
        public const String C_CreatedBy = "CreatedBy";
        public const String C_CreatedAt = "CreatedAt";
        public const String C_ModifiedBy = "ModifiedBy";
        public const String C_ModifiedAt = "ModifiedAt";
        public const String C_TClassID = "TClassID";
        public const String C_IsTempClass1 = "IsTempClass1";
        public const String C_IsLogicClass = "IsLogicClass";
        public const String C_IsTechClass = "IsTechClass";
        public const String C_GraduationTitleID = "GraduationTitleID";

        #endregion //Column names

        #endregion Variable Static
    }
}


