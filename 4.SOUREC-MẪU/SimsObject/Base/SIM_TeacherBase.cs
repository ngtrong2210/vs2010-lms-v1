
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
	/// Created date 	: 8/7/2022 
	/// Description 
	/// </summary>	
	public partial class SIM_Teacher
	{	
		#region Member Variables

		private string strTeacherID = null;
		private string strTeacherFirstName = null;//Họ và chữ đệm giáo viên
		private string strTeacherLastName = null;//Tên giáo viên
		private string strTeacherShortName = null;
		private string strSubjectGroupID = null;
		private string strLevelA = null;//Học hàm
		private string strLevelB = null;//Học vị
		private string strEmail = null;
		private string strTel = null;//Điện thoại
		private int? intTeacherTypeID = null;//Loại giáo viên
		private string strBirthDateText = null;//Ngày tháng năm sinh tổ hợp từ 3 giá trị trên
		private string strPersonID = null;//Số CMND
		private DateTime? dtmPersionIDDate = null;//Ngày cấp
		private string strPersionIDPlace = null;//Nơi cấp
		private bool bolGender = false;//Giới tính
		private string strEthnicityID = null;//Mã dân tộc
		private string strReligionID = null;//Mã tôn giáo
		private int? intParty = null;//Đoàn/ Đảng/ Không. 0. Không có, 1. Đoàn. 2. Đảng
		private string strOriginPlace = null;//Nguyên quán
		private string strLiveAddress = null;//Địa chỉ hộ khẩu thường trú
		private int? intDegreeTitleID = null;//Mã học hàm
		private int? intDegreeID = null;//Mã học vị
		private string strSpecialBranch = null;//Chuyên môn
		private string strOtherSpecialBranch = null;//Chuyên môn khác
		private string strTeachingLevel = null;//Trình độ sư phạm
		private string strComputerLevel = null;//Trình độ tin học
		private string strForeignLanguageLevel = null;//Trình độ ngoại ngữ
		private string strTaxCode = null;//Mã số thuế
		private int? intStatus = null;//Trạng thái giáo viên 1: Đang dạy, 2: Đã chuyển không còn dạy, 3: Nghỉ hưu, 4: Nghỉ dạy
		private bool bolAllowScheduling = false;//Cho phép sắp lịch hay hông. Không chọn thì khi sắp lịch nó hông sắp,và khi phân công cũng không load lên phân luôn
		private int? intMaxQuantityOfDay = null;//Số tiết dạy tối đa một ngày
		private int? intMaxQuantityOfSession = null;//Số tiết dạy tối đa 1 buổi
		private int? intMaxSessionOfDay = null;//Số buổi dạy tối đa
		private int? intMaxTheoryQuantityOfSemester = null;//Số tiết lý thuyết tối đa trong kỳ
		private int? intMaxPracticeQuantityOfSemester = null;//Số tiết thực hành tối đa trong kỳ
		private int? intMinTheoryQuantityOfYear = null;//Số tiết lý thuyết tối thiểu trong năm(chỉ tiêu LT)
		private int? intMinPracticeQuantityOfYear = null;//Số tiết thực hành tối thiểu trong năm (chỉ tiêu thực hành)
		private double? dblRatioMinQuantityOfYear = null;//Hệ số chức vụ (0.1 = 10%,  1.2 = 120%). Dùng để nhân với chi tiêu tối thiểu để ra chỉ tiêu tối thiểu thực sự
		private bool bolIsMorning = false;//Dạy buổi sáng
		private bool bolIsEvening = false;//Dạy buổi chiều
		private bool bolIsNight = false;//Dạy buổi tối
		private string strDescription = null;
		private bool bolAllowTestScheduling = false;//Cho phép sắp lịch thi tự động
		private string strCreatedBy = null;//Người tạo
		private DateTime? dtmCreatedAt = null;//Ngày tạo
		private string strModifiedBy = null;//Người sửa
		private DateTime? dtmModifiedAt = null;//Ngày sửa
		private IData objIData = null;
		private bool bolIsExistIData = false;
		private Exception objErrorException = null;

		#endregion

		#region Properties 

		/// <summary>
		/// TeacherID
		/// 
		/// </summary>
		public string TeacherID
		{
			get { return  strTeacherID; }
			set { strTeacherID = value; }
		}
		/// <summary>
		/// TeacherFirstName
		/// Họ và chữ đệm giáo viên
		/// </summary>
		public string TeacherFirstName
		{
			get { return  strTeacherFirstName; }
			set { strTeacherFirstName = value; }
		}
		/// <summary>
		/// TeacherLastName
		/// Tên giáo viên
		/// </summary>
		public string TeacherLastName
		{
			get { return  strTeacherLastName; }
			set { strTeacherLastName = value; }
		}
		/// <summary>
		/// TeacherShortName
		/// 
		/// </summary>
		public string TeacherShortName
		{
			get { return  strTeacherShortName; }
			set { strTeacherShortName = value; }
		}
		/// <summary>
		/// SubjectGroupID
		/// 
		/// </summary>
		public string SubjectGroupID
		{
			get { return  strSubjectGroupID; }
			set { strSubjectGroupID = value; }
		}
		/// <summary>
		/// LevelA
		/// Học hàm
		/// </summary>
		public string LevelA
		{
			get { return  strLevelA; }
			set { strLevelA = value; }
		}
		/// <summary>
		/// LevelB
		/// Học vị
		/// </summary>
		public string LevelB
		{
			get { return  strLevelB; }
			set { strLevelB = value; }
		}
		/// <summary>
		/// Email
		/// 
		/// </summary>
		public string Email
		{
			get { return  strEmail; }
			set { strEmail = value; }
		}
		/// <summary>
		/// Tel
		/// Điện thoại
		/// </summary>
		public string Tel
		{
			get { return  strTel; }
			set { strTel = value; }
		}
		/// <summary>
		/// TeacherTypeID
		/// Loại giáo viên
		/// </summary>
		public int? TeacherTypeID
		{
			get { return  intTeacherTypeID; }
			set { intTeacherTypeID = value; }
		}
		/// <summary>
		/// BirthDateText
		/// Ngày tháng năm sinh tổ hợp từ 3 giá trị trên
		/// </summary>
		public string BirthDateText
		{
			get { return  strBirthDateText; }
			set { strBirthDateText = value; }
		}
		/// <summary>
		/// PersonID
		/// Số CMND
		/// </summary>
		public string PersonID
		{
			get { return  strPersonID; }
			set { strPersonID = value; }
		}
		/// <summary>
		/// PersionIDDate
		/// Ngày cấp
		/// </summary>
		public DateTime? PersionIDDate
		{
			get { return  dtmPersionIDDate; }
			set { dtmPersionIDDate = value; }
		}
		/// <summary>
		/// PersionIDPlace
		/// Nơi cấp
		/// </summary>
		public string PersionIDPlace
		{
			get { return  strPersionIDPlace; }
			set { strPersionIDPlace = value; }
		}
		/// <summary>
		/// Gender
		/// Giới tính
		/// </summary>
		public bool Gender
		{
			get { return  bolGender; }
			set { bolGender = value; }
		}
		/// <summary>
		/// EthnicityID
		/// Mã dân tộc
		/// </summary>
		public string EthnicityID
		{
			get { return  strEthnicityID; }
			set { strEthnicityID = value; }
		}
		/// <summary>
		/// ReligionID
		/// Mã tôn giáo
		/// </summary>
		public string ReligionID
		{
			get { return  strReligionID; }
			set { strReligionID = value; }
		}
		/// <summary>
		/// Party
		/// Đoàn/ Đảng/ Không. 0. Không có, 1. Đoàn. 2. Đảng
		/// </summary>
		public int? Party
		{
			get { return  intParty; }
			set { intParty = value; }
		}
		/// <summary>
		/// OriginPlace
		/// Nguyên quán
		/// </summary>
		public string OriginPlace
		{
			get { return  strOriginPlace; }
			set { strOriginPlace = value; }
		}
		/// <summary>
		/// LiveAddress
		/// Địa chỉ hộ khẩu thường trú
		/// </summary>
		public string LiveAddress
		{
			get { return  strLiveAddress; }
			set { strLiveAddress = value; }
		}
		/// <summary>
		/// DegreeTitleID
		/// Mã học hàm
		/// </summary>
		public int? DegreeTitleID
		{
			get { return  intDegreeTitleID; }
			set { intDegreeTitleID = value; }
		}
		/// <summary>
		/// DegreeID
		/// Mã học vị
		/// </summary>
		public int? DegreeID
		{
			get { return  intDegreeID; }
			set { intDegreeID = value; }
		}
		/// <summary>
		/// SpecialBranch
		/// Chuyên môn
		/// </summary>
		public string SpecialBranch
		{
			get { return  strSpecialBranch; }
			set { strSpecialBranch = value; }
		}
		/// <summary>
		/// OtherSpecialBranch
		/// Chuyên môn khác
		/// </summary>
		public string OtherSpecialBranch
		{
			get { return  strOtherSpecialBranch; }
			set { strOtherSpecialBranch = value; }
		}
		/// <summary>
		/// TeachingLevel
		/// Trình độ sư phạm
		/// </summary>
		public string TeachingLevel
		{
			get { return  strTeachingLevel; }
			set { strTeachingLevel = value; }
		}
		/// <summary>
		/// ComputerLevel
		/// Trình độ tin học
		/// </summary>
		public string ComputerLevel
		{
			get { return  strComputerLevel; }
			set { strComputerLevel = value; }
		}
		/// <summary>
		/// ForeignLanguageLevel
		/// Trình độ ngoại ngữ
		/// </summary>
		public string ForeignLanguageLevel
		{
			get { return  strForeignLanguageLevel; }
			set { strForeignLanguageLevel = value; }
		}
		/// <summary>
		/// TaxCode
		/// Mã số thuế
		/// </summary>
		public string TaxCode
		{
			get { return  strTaxCode; }
			set { strTaxCode = value; }
		}
		/// <summary>
		/// Status
		/// Trạng thái giáo viên 1: Đang dạy, 2: Đã chuyển không còn dạy, 3: Nghỉ hưu, 4: Nghỉ dạy
		/// </summary>
		public int? Status
		{
			get { return  intStatus; }
			set { intStatus = value; }
		}
		/// <summary>
		/// AllowScheduling
		/// Cho phép sắp lịch hay hông. Không chọn thì khi sắp lịch nó hông sắp,và khi phân công cũng không load lên phân luôn
		/// </summary>
		public bool AllowScheduling
		{
			get { return  bolAllowScheduling; }
			set { bolAllowScheduling = value; }
		}
		/// <summary>
		/// MaxQuantityOfDay
		/// Số tiết dạy tối đa một ngày
		/// </summary>
		public int? MaxQuantityOfDay
		{
			get { return  intMaxQuantityOfDay; }
			set { intMaxQuantityOfDay = value; }
		}
		/// <summary>
		/// MaxQuantityOfSession
		/// Số tiết dạy tối đa 1 buổi
		/// </summary>
		public int? MaxQuantityOfSession
		{
			get { return  intMaxQuantityOfSession; }
			set { intMaxQuantityOfSession = value; }
		}
		/// <summary>
		/// MaxSessionOfDay
		/// Số buổi dạy tối đa
		/// </summary>
		public int? MaxSessionOfDay
		{
			get { return  intMaxSessionOfDay; }
			set { intMaxSessionOfDay = value; }
		}
		/// <summary>
		/// MaxTheoryQuantityOfSemester
		/// Số tiết lý thuyết tối đa trong kỳ
		/// </summary>
		public int? MaxTheoryQuantityOfSemester
		{
			get { return  intMaxTheoryQuantityOfSemester; }
			set { intMaxTheoryQuantityOfSemester = value; }
		}
		/// <summary>
		/// MaxPracticeQuantityOfSemester
		/// Số tiết thực hành tối đa trong kỳ
		/// </summary>
		public int? MaxPracticeQuantityOfSemester
		{
			get { return  intMaxPracticeQuantityOfSemester; }
			set { intMaxPracticeQuantityOfSemester = value; }
		}
		/// <summary>
		/// MinTheoryQuantityOfYear
		/// Số tiết lý thuyết tối thiểu trong năm(chỉ tiêu LT)
		/// </summary>
		public int? MinTheoryQuantityOfYear
		{
			get { return  intMinTheoryQuantityOfYear; }
			set { intMinTheoryQuantityOfYear = value; }
		}
		/// <summary>
		/// MinPracticeQuantityOfYear
		/// Số tiết thực hành tối thiểu trong năm (chỉ tiêu thực hành)
		/// </summary>
		public int? MinPracticeQuantityOfYear
		{
			get { return  intMinPracticeQuantityOfYear; }
			set { intMinPracticeQuantityOfYear = value; }
		}
		/// <summary>
		/// RatioMinQuantityOfYear
		/// Hệ số chức vụ (0.1 = 10%,  1.2 = 120%). Dùng để nhân với chi tiêu tối thiểu để ra chỉ tiêu tối thiểu thực sự
		/// </summary>
		public double? RatioMinQuantityOfYear
		{
			get { return  dblRatioMinQuantityOfYear; }
			set { dblRatioMinQuantityOfYear = value; }
		}
		/// <summary>
		/// IsMorning
		/// Dạy buổi sáng
		/// </summary>
		public bool IsMorning
		{
			get { return  bolIsMorning; }
			set { bolIsMorning = value; }
		}
		/// <summary>
		/// IsEvening
		/// Dạy buổi chiều
		/// </summary>
		public bool IsEvening
		{
			get { return  bolIsEvening; }
			set { bolIsEvening = value; }
		}
		/// <summary>
		/// IsNight
		/// Dạy buổi tối
		/// </summary>
		public bool IsNight
		{
			get { return  bolIsNight; }
			set { bolIsNight = value; }
		}
		/// <summary>
		/// Description
		/// 
		/// </summary>
		public string Description
		{
			get { return  strDescription; }
			set { strDescription = value; }
		}
		/// <summary>
		/// AllowTestScheduling
		/// Cho phép sắp lịch thi tự động
		/// </summary>
		public bool AllowTestScheduling
		{
			get { return  bolAllowTestScheduling; }
			set { bolAllowTestScheduling = value; }
		}
		/// <summary>
		/// CreatedBy
		/// Người tạo
		/// </summary>
		public string CreatedBy
		{
			get { return  strCreatedBy; }
			set { strCreatedBy = value; }
		}
		/// <summary>
		/// CreatedAt
		/// Ngày tạo
		/// </summary>
		public DateTime? CreatedAt
		{
			get { return  dtmCreatedAt; }
			set { dtmCreatedAt = value; }
		}
		/// <summary>
		/// ModifiedBy
		/// Người sửa
		/// </summary>
		public string ModifiedBy
		{
			get { return  strModifiedBy; }
			set { strModifiedBy = value; }
		}
		/// <summary>
		/// ModifiedAt
		/// Ngày sửa
		/// </summary>
		public DateTime? ModifiedAt
		{
			get { return  dtmModifiedAt; }
			set { dtmModifiedAt = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_TeacherID.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherID])) this.strTeacherID = Convert.ToString(reader[C_TeacherID]);
					if (reader.GetName(i).ToUpper().Equals(C_TeacherFirstName.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherFirstName])) this.strTeacherFirstName = Convert.ToString(reader[C_TeacherFirstName]);
					if (reader.GetName(i).ToUpper().Equals(C_TeacherLastName.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherLastName])) this.strTeacherLastName = Convert.ToString(reader[C_TeacherLastName]);
					if (reader.GetName(i).ToUpper().Equals(C_TeacherShortName.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherShortName])) this.strTeacherShortName = Convert.ToString(reader[C_TeacherShortName]);
					if (reader.GetName(i).ToUpper().Equals(C_SubjectGroupID.ToUpper()) && !Convert.IsDBNull(reader[C_SubjectGroupID])) this.strSubjectGroupID = Convert.ToString(reader[C_SubjectGroupID]);
					if (reader.GetName(i).ToUpper().Equals(C_LevelA.ToUpper()) && !Convert.IsDBNull(reader[C_LevelA])) this.strLevelA = Convert.ToString(reader[C_LevelA]);
					if (reader.GetName(i).ToUpper().Equals(C_LevelB.ToUpper()) && !Convert.IsDBNull(reader[C_LevelB])) this.strLevelB = Convert.ToString(reader[C_LevelB]);
					if (reader.GetName(i).ToUpper().Equals(C_Email.ToUpper()) && !Convert.IsDBNull(reader[C_Email])) this.strEmail = Convert.ToString(reader[C_Email]);
					if (reader.GetName(i).ToUpper().Equals(C_Tel.ToUpper()) && !Convert.IsDBNull(reader[C_Tel])) this.strTel = Convert.ToString(reader[C_Tel]);
					if (reader.GetName(i).ToUpper().Equals(C_TeacherTypeID.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherTypeID])) this.intTeacherTypeID = Convert.ToInt32(reader[C_TeacherTypeID]);
					if (reader.GetName(i).ToUpper().Equals(C_BirthDateText.ToUpper()) && !Convert.IsDBNull(reader[C_BirthDateText])) this.strBirthDateText = Convert.ToString(reader[C_BirthDateText]);
					if (reader.GetName(i).ToUpper().Equals(C_PersonID.ToUpper()) && !Convert.IsDBNull(reader[C_PersonID])) this.strPersonID = Convert.ToString(reader[C_PersonID]);
					if (reader.GetName(i).ToUpper().Equals(C_PersionIDDate.ToUpper()) && !Convert.IsDBNull(reader[C_PersionIDDate])) this.dtmPersionIDDate = Convert.ToDateTime(reader[C_PersionIDDate]);
					if (reader.GetName(i).ToUpper().Equals(C_PersionIDPlace.ToUpper()) && !Convert.IsDBNull(reader[C_PersionIDPlace])) this.strPersionIDPlace = Convert.ToString(reader[C_PersionIDPlace]);
					if (reader.GetName(i).ToUpper().Equals(C_Gender.ToUpper()) && !Convert.IsDBNull(reader[C_Gender])) this.bolGender = Convert.ToBoolean(reader[C_Gender]);
					if (reader.GetName(i).ToUpper().Equals(C_EthnicityID.ToUpper()) && !Convert.IsDBNull(reader[C_EthnicityID])) this.strEthnicityID = Convert.ToString(reader[C_EthnicityID]);
					if (reader.GetName(i).ToUpper().Equals(C_ReligionID.ToUpper()) && !Convert.IsDBNull(reader[C_ReligionID])) this.strReligionID = Convert.ToString(reader[C_ReligionID]);
					if (reader.GetName(i).ToUpper().Equals(C_Party.ToUpper()) && !Convert.IsDBNull(reader[C_Party])) this.intParty = Convert.ToInt32(reader[C_Party]);
					if (reader.GetName(i).ToUpper().Equals(C_OriginPlace.ToUpper()) && !Convert.IsDBNull(reader[C_OriginPlace])) this.strOriginPlace = Convert.ToString(reader[C_OriginPlace]);
					if (reader.GetName(i).ToUpper().Equals(C_LiveAddress.ToUpper()) && !Convert.IsDBNull(reader[C_LiveAddress])) this.strLiveAddress = Convert.ToString(reader[C_LiveAddress]);
					if (reader.GetName(i).ToUpper().Equals(C_DegreeTitleID.ToUpper()) && !Convert.IsDBNull(reader[C_DegreeTitleID])) this.intDegreeTitleID = Convert.ToInt32(reader[C_DegreeTitleID]);
					if (reader.GetName(i).ToUpper().Equals(C_DegreeID.ToUpper()) && !Convert.IsDBNull(reader[C_DegreeID])) this.intDegreeID = Convert.ToInt32(reader[C_DegreeID]);
					if (reader.GetName(i).ToUpper().Equals(C_SpecialBranch.ToUpper()) && !Convert.IsDBNull(reader[C_SpecialBranch])) this.strSpecialBranch = Convert.ToString(reader[C_SpecialBranch]);
					if (reader.GetName(i).ToUpper().Equals(C_OtherSpecialBranch.ToUpper()) && !Convert.IsDBNull(reader[C_OtherSpecialBranch])) this.strOtherSpecialBranch = Convert.ToString(reader[C_OtherSpecialBranch]);
					if (reader.GetName(i).ToUpper().Equals(C_TeachingLevel.ToUpper()) && !Convert.IsDBNull(reader[C_TeachingLevel])) this.strTeachingLevel = Convert.ToString(reader[C_TeachingLevel]);
					if (reader.GetName(i).ToUpper().Equals(C_ComputerLevel.ToUpper()) && !Convert.IsDBNull(reader[C_ComputerLevel])) this.strComputerLevel = Convert.ToString(reader[C_ComputerLevel]);
					if (reader.GetName(i).ToUpper().Equals(C_ForeignLanguageLevel.ToUpper()) && !Convert.IsDBNull(reader[C_ForeignLanguageLevel])) this.strForeignLanguageLevel = Convert.ToString(reader[C_ForeignLanguageLevel]);
					if (reader.GetName(i).ToUpper().Equals(C_TaxCode.ToUpper()) && !Convert.IsDBNull(reader[C_TaxCode])) this.strTaxCode = Convert.ToString(reader[C_TaxCode]);
					if (reader.GetName(i).ToUpper().Equals(C_Status.ToUpper()) && !Convert.IsDBNull(reader[C_Status])) this.intStatus = Convert.ToInt32(reader[C_Status]);
					if (reader.GetName(i).ToUpper().Equals(C_AllowScheduling.ToUpper()) && !Convert.IsDBNull(reader[C_AllowScheduling])) this.bolAllowScheduling = Convert.ToBoolean(reader[C_AllowScheduling]);
					if (reader.GetName(i).ToUpper().Equals(C_MaxQuantityOfDay.ToUpper()) && !Convert.IsDBNull(reader[C_MaxQuantityOfDay])) this.intMaxQuantityOfDay = Convert.ToInt32(reader[C_MaxQuantityOfDay]);
					if (reader.GetName(i).ToUpper().Equals(C_MaxQuantityOfSession.ToUpper()) && !Convert.IsDBNull(reader[C_MaxQuantityOfSession])) this.intMaxQuantityOfSession = Convert.ToInt32(reader[C_MaxQuantityOfSession]);
					if (reader.GetName(i).ToUpper().Equals(C_MaxSessionOfDay.ToUpper()) && !Convert.IsDBNull(reader[C_MaxSessionOfDay])) this.intMaxSessionOfDay = Convert.ToInt32(reader[C_MaxSessionOfDay]);
					if (reader.GetName(i).ToUpper().Equals(C_MaxTheoryQuantityOfSemester.ToUpper()) && !Convert.IsDBNull(reader[C_MaxTheoryQuantityOfSemester])) this.intMaxTheoryQuantityOfSemester = Convert.ToInt32(reader[C_MaxTheoryQuantityOfSemester]);
					if (reader.GetName(i).ToUpper().Equals(C_MaxPracticeQuantityOfSemester.ToUpper()) && !Convert.IsDBNull(reader[C_MaxPracticeQuantityOfSemester])) this.intMaxPracticeQuantityOfSemester = Convert.ToInt32(reader[C_MaxPracticeQuantityOfSemester]);
					if (reader.GetName(i).ToUpper().Equals(C_MinTheoryQuantityOfYear.ToUpper()) && !Convert.IsDBNull(reader[C_MinTheoryQuantityOfYear])) this.intMinTheoryQuantityOfYear = Convert.ToInt32(reader[C_MinTheoryQuantityOfYear]);
					if (reader.GetName(i).ToUpper().Equals(C_MinPracticeQuantityOfYear.ToUpper()) && !Convert.IsDBNull(reader[C_MinPracticeQuantityOfYear])) this.intMinPracticeQuantityOfYear = Convert.ToInt32(reader[C_MinPracticeQuantityOfYear]);
					if (reader.GetName(i).ToUpper().Equals(C_RatioMinQuantityOfYear.ToUpper()) && !Convert.IsDBNull(reader[C_RatioMinQuantityOfYear])) this.dblRatioMinQuantityOfYear = Convert.ToDouble(reader[C_RatioMinQuantityOfYear]);
					if (reader.GetName(i).ToUpper().Equals(C_IsMorning.ToUpper()) && !Convert.IsDBNull(reader[C_IsMorning])) this.bolIsMorning = Convert.ToBoolean(reader[C_IsMorning]);
					if (reader.GetName(i).ToUpper().Equals(C_IsEvening.ToUpper()) && !Convert.IsDBNull(reader[C_IsEvening])) this.bolIsEvening = Convert.ToBoolean(reader[C_IsEvening]);
					if (reader.GetName(i).ToUpper().Equals(C_IsNight.ToUpper()) && !Convert.IsDBNull(reader[C_IsNight])) this.bolIsNight = Convert.ToBoolean(reader[C_IsNight]);
					if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
					if (reader.GetName(i).ToUpper().Equals(C_AllowTestScheduling.ToUpper()) && !Convert.IsDBNull(reader[C_AllowTestScheduling])) this.bolAllowTestScheduling = Convert.ToBoolean(reader[C_AllowTestScheduling]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedBy.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedBy])) this.strCreatedBy = Convert.ToString(reader[C_CreatedBy]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(reader[C_CreatedAt]);
					if (reader.GetName(i).ToUpper().Equals(C_ModifiedBy.ToUpper()) && !Convert.IsDBNull(reader[C_ModifiedBy])) this.strModifiedBy = Convert.ToString(reader[C_ModifiedBy]);
					if (reader.GetName(i).ToUpper().Equals(C_ModifiedAt.ToUpper()) && !Convert.IsDBNull(reader[C_ModifiedAt])) this.dtmModifiedAt = Convert.ToDateTime(reader[C_ModifiedAt]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_Teacher", objEx);
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
				if (!Convert.IsDBNull(drw[C_TeacherID])) this.strTeacherID = Convert.ToString(drw[C_TeacherID]);
				if (!Convert.IsDBNull(drw[C_TeacherFirstName])) this.strTeacherFirstName = Convert.ToString(drw[C_TeacherFirstName]);
				if (!Convert.IsDBNull(drw[C_TeacherLastName])) this.strTeacherLastName = Convert.ToString(drw[C_TeacherLastName]);
				if (!Convert.IsDBNull(drw[C_TeacherShortName])) this.strTeacherShortName = Convert.ToString(drw[C_TeacherShortName]);
				if (!Convert.IsDBNull(drw[C_SubjectGroupID])) this.strSubjectGroupID = Convert.ToString(drw[C_SubjectGroupID]);
				if (!Convert.IsDBNull(drw[C_LevelA])) this.strLevelA = Convert.ToString(drw[C_LevelA]);
				if (!Convert.IsDBNull(drw[C_LevelB])) this.strLevelB = Convert.ToString(drw[C_LevelB]);
				if (!Convert.IsDBNull(drw[C_Email])) this.strEmail = Convert.ToString(drw[C_Email]);
				if (!Convert.IsDBNull(drw[C_Tel])) this.strTel = Convert.ToString(drw[C_Tel]);
				if (!Convert.IsDBNull(drw[C_TeacherTypeID])) this.intTeacherTypeID = Convert.ToInt32(drw[C_TeacherTypeID]);
				if (!Convert.IsDBNull(drw[C_BirthDateText])) this.strBirthDateText = Convert.ToString(drw[C_BirthDateText]);
				if (!Convert.IsDBNull(drw[C_PersonID])) this.strPersonID = Convert.ToString(drw[C_PersonID]);
				if (!Convert.IsDBNull(drw[C_PersionIDDate])) this.dtmPersionIDDate = Convert.ToDateTime(drw[C_PersionIDDate]);
				if (!Convert.IsDBNull(drw[C_PersionIDPlace])) this.strPersionIDPlace = Convert.ToString(drw[C_PersionIDPlace]);
				if (!Convert.IsDBNull(drw[C_Gender])) this.bolGender = Convert.ToBoolean(drw[C_Gender]);
				if (!Convert.IsDBNull(drw[C_EthnicityID])) this.strEthnicityID = Convert.ToString(drw[C_EthnicityID]);
				if (!Convert.IsDBNull(drw[C_ReligionID])) this.strReligionID = Convert.ToString(drw[C_ReligionID]);
				if (!Convert.IsDBNull(drw[C_Party])) this.intParty = Convert.ToInt32(drw[C_Party]);
				if (!Convert.IsDBNull(drw[C_OriginPlace])) this.strOriginPlace = Convert.ToString(drw[C_OriginPlace]);
				if (!Convert.IsDBNull(drw[C_LiveAddress])) this.strLiveAddress = Convert.ToString(drw[C_LiveAddress]);
				if (!Convert.IsDBNull(drw[C_DegreeTitleID])) this.intDegreeTitleID = Convert.ToInt32(drw[C_DegreeTitleID]);
				if (!Convert.IsDBNull(drw[C_DegreeID])) this.intDegreeID = Convert.ToInt32(drw[C_DegreeID]);
				if (!Convert.IsDBNull(drw[C_SpecialBranch])) this.strSpecialBranch = Convert.ToString(drw[C_SpecialBranch]);
				if (!Convert.IsDBNull(drw[C_OtherSpecialBranch])) this.strOtherSpecialBranch = Convert.ToString(drw[C_OtherSpecialBranch]);
				if (!Convert.IsDBNull(drw[C_TeachingLevel])) this.strTeachingLevel = Convert.ToString(drw[C_TeachingLevel]);
				if (!Convert.IsDBNull(drw[C_ComputerLevel])) this.strComputerLevel = Convert.ToString(drw[C_ComputerLevel]);
				if (!Convert.IsDBNull(drw[C_ForeignLanguageLevel])) this.strForeignLanguageLevel = Convert.ToString(drw[C_ForeignLanguageLevel]);
				if (!Convert.IsDBNull(drw[C_TaxCode])) this.strTaxCode = Convert.ToString(drw[C_TaxCode]);
				if (!Convert.IsDBNull(drw[C_Status])) this.intStatus = Convert.ToInt32(drw[C_Status]);
				if (!Convert.IsDBNull(drw[C_AllowScheduling])) this.bolAllowScheduling = Convert.ToBoolean(drw[C_AllowScheduling]);
				if (!Convert.IsDBNull(drw[C_MaxQuantityOfDay])) this.intMaxQuantityOfDay = Convert.ToInt32(drw[C_MaxQuantityOfDay]);
				if (!Convert.IsDBNull(drw[C_MaxQuantityOfSession])) this.intMaxQuantityOfSession = Convert.ToInt32(drw[C_MaxQuantityOfSession]);
				if (!Convert.IsDBNull(drw[C_MaxSessionOfDay])) this.intMaxSessionOfDay = Convert.ToInt32(drw[C_MaxSessionOfDay]);
				if (!Convert.IsDBNull(drw[C_MaxTheoryQuantityOfSemester])) this.intMaxTheoryQuantityOfSemester = Convert.ToInt32(drw[C_MaxTheoryQuantityOfSemester]);
				if (!Convert.IsDBNull(drw[C_MaxPracticeQuantityOfSemester])) this.intMaxPracticeQuantityOfSemester = Convert.ToInt32(drw[C_MaxPracticeQuantityOfSemester]);
				if (!Convert.IsDBNull(drw[C_MinTheoryQuantityOfYear])) this.intMinTheoryQuantityOfYear = Convert.ToInt32(drw[C_MinTheoryQuantityOfYear]);
				if (!Convert.IsDBNull(drw[C_MinPracticeQuantityOfYear])) this.intMinPracticeQuantityOfYear = Convert.ToInt32(drw[C_MinPracticeQuantityOfYear]);
				if (!Convert.IsDBNull(drw[C_RatioMinQuantityOfYear])) this.dblRatioMinQuantityOfYear = Convert.ToDouble(drw[C_RatioMinQuantityOfYear]);
				if (!Convert.IsDBNull(drw[C_IsMorning])) this.bolIsMorning = Convert.ToBoolean(drw[C_IsMorning]);
				if (!Convert.IsDBNull(drw[C_IsEvening])) this.bolIsEvening = Convert.ToBoolean(drw[C_IsEvening]);
				if (!Convert.IsDBNull(drw[C_IsNight])) this.bolIsNight = Convert.ToBoolean(drw[C_IsNight]);
				if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
				if (!Convert.IsDBNull(drw[C_AllowTestScheduling])) this.bolAllowTestScheduling = Convert.ToBoolean(drw[C_AllowTestScheduling]);
				if (!Convert.IsDBNull(drw[C_CreatedBy])) this.strCreatedBy = Convert.ToString(drw[C_CreatedBy]);
				if (!Convert.IsDBNull(drw[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(drw[C_CreatedAt]);
				if (!Convert.IsDBNull(drw[C_ModifiedBy])) this.strModifiedBy = Convert.ToString(drw[C_ModifiedBy]);
				if (!Convert.IsDBNull(drw[C_ModifiedAt])) this.dtmModifiedAt = Convert.ToDateTime(drw[C_ModifiedAt]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_Teacher", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_Teacher_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Teacher_GET");
				objIData.AddParameter(P_TeacherID, this.strTeacherID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_Teacher", objEx);
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
		/// Store: SIM_Teacher_GET 
		///</summary>
		/// <returns> SIM_Teacher </returns>
		public SIM_Teacher Get(string strTeacherID)
		{
			SIM_Teacher obj = new SIM_Teacher();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.TeacherID = strTeacherID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_Teacher
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Teacher", objEx);
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
		/// Search : SIM_Teacher
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Teacher", objEx);
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
		/// Search : SIM_Teacher
		/// Lấy hết dữ liệu
		/// Store: SIM_Teacher_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_Teacher_GETALL");
		}

		///<summary>
		/// Search : SIM_Teacher
		/// Tìm dữ liệu
		/// Store: SIM_Teacher_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_Teacher_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_Teacher
		/// Thêm dữ liệu
		/// Store: SIM_Teacher_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Teacher_ADD");
				objIData.AddParameter(P_TeacherID, this.strTeacherID);
				objIData.AddParameter(P_TeacherFirstName, this.strTeacherFirstName);
				objIData.AddParameter(P_TeacherLastName, this.strTeacherLastName);
				objIData.AddParameter(P_TeacherShortName, this.strTeacherShortName);
				objIData.AddParameter(P_SubjectGroupID, this.strSubjectGroupID);
				objIData.AddParameter(P_LevelA, this.strLevelA);
				objIData.AddParameter(P_LevelB, this.strLevelB);
				objIData.AddParameter(P_Email, this.strEmail);
				objIData.AddParameter(P_Tel, this.strTel);
				objIData.AddParameter(P_TeacherTypeID, this.intTeacherTypeID);
				objIData.AddParameter(P_BirthDateText, this.strBirthDateText);
				objIData.AddParameter(P_PersonID, this.strPersonID);
				objIData.AddParameter(P_PersionIDDate, this.dtmPersionIDDate);
				objIData.AddParameter(P_PersionIDPlace, this.strPersionIDPlace);
				objIData.AddParameter(P_Gender, this.bolGender);
				objIData.AddParameter(P_EthnicityID, this.strEthnicityID);
				objIData.AddParameter(P_ReligionID, this.strReligionID);
				objIData.AddParameter(P_Party, this.intParty);
				objIData.AddParameter(P_OriginPlace, this.strOriginPlace);
				objIData.AddParameter(P_LiveAddress, this.strLiveAddress);
				objIData.AddParameter(P_DegreeTitleID, this.intDegreeTitleID);
				objIData.AddParameter(P_DegreeID, this.intDegreeID);
				objIData.AddParameter(P_SpecialBranch, this.strSpecialBranch);
				objIData.AddParameter(P_OtherSpecialBranch, this.strOtherSpecialBranch);
				objIData.AddParameter(P_TeachingLevel, this.strTeachingLevel);
				objIData.AddParameter(P_ComputerLevel, this.strComputerLevel);
				objIData.AddParameter(P_ForeignLanguageLevel, this.strForeignLanguageLevel);
				objIData.AddParameter(P_TaxCode, this.strTaxCode);
				objIData.AddParameter(P_Status, this.intStatus);
				objIData.AddParameter(P_AllowScheduling, this.bolAllowScheduling);
				objIData.AddParameter(P_MaxQuantityOfDay, this.intMaxQuantityOfDay);
				objIData.AddParameter(P_MaxQuantityOfSession, this.intMaxQuantityOfSession);
				objIData.AddParameter(P_MaxSessionOfDay, this.intMaxSessionOfDay);
				objIData.AddParameter(P_MaxTheoryQuantityOfSemester, this.intMaxTheoryQuantityOfSemester);
				objIData.AddParameter(P_MaxPracticeQuantityOfSemester, this.intMaxPracticeQuantityOfSemester);
				objIData.AddParameter(P_MinTheoryQuantityOfYear, this.intMinTheoryQuantityOfYear);
				objIData.AddParameter(P_MinPracticeQuantityOfYear, this.intMinPracticeQuantityOfYear);
				objIData.AddParameter(P_RatioMinQuantityOfYear, this.dblRatioMinQuantityOfYear);
				objIData.AddParameter(P_IsMorning, this.bolIsMorning);
				objIData.AddParameter(P_IsEvening, this.bolIsEvening);
				objIData.AddParameter(P_IsNight, this.bolIsNight);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_AllowTestScheduling, this.bolAllowTestScheduling);
				objIData.AddParameter(P_CreatedBy, this.strCreatedBy);
				objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
				objIData.AddParameter(P_ModifiedBy, this.strModifiedBy);
				objIData.AddParameter(P_ModifiedAt, this.dtmModifiedAt);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_Teacher", objEx);
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
		/// Update : SIM_Teacher
		/// Cập nhật dữ liệu
		/// Store: SIM_Teacher_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Teacher_EDIT");
				objIData.AddParameter(P_TeacherID, this.strTeacherID);
				objIData.AddParameter(P_TeacherFirstName, this.strTeacherFirstName);
				objIData.AddParameter(P_TeacherLastName, this.strTeacherLastName);
				objIData.AddParameter(P_TeacherShortName, this.strTeacherShortName);
				objIData.AddParameter(P_SubjectGroupID, this.strSubjectGroupID);
				objIData.AddParameter(P_LevelA, this.strLevelA);
				objIData.AddParameter(P_LevelB, this.strLevelB);
				objIData.AddParameter(P_Email, this.strEmail);
				objIData.AddParameter(P_Tel, this.strTel);
				objIData.AddParameter(P_TeacherTypeID, this.intTeacherTypeID);
				objIData.AddParameter(P_BirthDateText, this.strBirthDateText);
				objIData.AddParameter(P_PersonID, this.strPersonID);
				objIData.AddParameter(P_PersionIDDate, this.dtmPersionIDDate);
				objIData.AddParameter(P_PersionIDPlace, this.strPersionIDPlace);
				objIData.AddParameter(P_Gender, this.bolGender);
				objIData.AddParameter(P_EthnicityID, this.strEthnicityID);
				objIData.AddParameter(P_ReligionID, this.strReligionID);
				objIData.AddParameter(P_Party, this.intParty);
				objIData.AddParameter(P_OriginPlace, this.strOriginPlace);
				objIData.AddParameter(P_LiveAddress, this.strLiveAddress);
				objIData.AddParameter(P_DegreeTitleID, this.intDegreeTitleID);
				objIData.AddParameter(P_DegreeID, this.intDegreeID);
				objIData.AddParameter(P_SpecialBranch, this.strSpecialBranch);
				objIData.AddParameter(P_OtherSpecialBranch, this.strOtherSpecialBranch);
				objIData.AddParameter(P_TeachingLevel, this.strTeachingLevel);
				objIData.AddParameter(P_ComputerLevel, this.strComputerLevel);
				objIData.AddParameter(P_ForeignLanguageLevel, this.strForeignLanguageLevel);
				objIData.AddParameter(P_TaxCode, this.strTaxCode);
				objIData.AddParameter(P_Status, this.intStatus);
				objIData.AddParameter(P_AllowScheduling, this.bolAllowScheduling);
				objIData.AddParameter(P_MaxQuantityOfDay, this.intMaxQuantityOfDay);
				objIData.AddParameter(P_MaxQuantityOfSession, this.intMaxQuantityOfSession);
				objIData.AddParameter(P_MaxSessionOfDay, this.intMaxSessionOfDay);
				objIData.AddParameter(P_MaxTheoryQuantityOfSemester, this.intMaxTheoryQuantityOfSemester);
				objIData.AddParameter(P_MaxPracticeQuantityOfSemester, this.intMaxPracticeQuantityOfSemester);
				objIData.AddParameter(P_MinTheoryQuantityOfYear, this.intMinTheoryQuantityOfYear);
				objIData.AddParameter(P_MinPracticeQuantityOfYear, this.intMinPracticeQuantityOfYear);
				objIData.AddParameter(P_RatioMinQuantityOfYear, this.dblRatioMinQuantityOfYear);
				objIData.AddParameter(P_IsMorning, this.bolIsMorning);
				objIData.AddParameter(P_IsEvening, this.bolIsEvening);
				objIData.AddParameter(P_IsNight, this.bolIsNight);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_AllowTestScheduling, this.bolAllowTestScheduling);
				objIData.AddParameter(P_CreatedBy, this.strCreatedBy);
				objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
				objIData.AddParameter(P_ModifiedBy, this.strModifiedBy);
				objIData.AddParameter(P_ModifiedAt, this.dtmModifiedAt);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_Teacher", objEx);
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
		/// Delete : SIM_Teacher
		/// Xóa dữ liệu
		/// Store: SIM_Teacher_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Teacher_DELETE");
				objIData.AddParameter(P_TeacherID, this.strTeacherID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_Teacher", objEx);
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
		/// Store: SIM_Teacher_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(string strTeacherID)
		{
			this.strTeacherID = strTeacherID;
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

		public SIM_Teacher()
		{
		}
		public SIM_Teacher(string strTeacherID)
		{
			this.strTeacherID = strTeacherID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_TeacherID = "@" + C_TeacherID;
		public const String P_TeacherFirstName = "@" + C_TeacherFirstName;
		public const String P_TeacherLastName = "@" + C_TeacherLastName;
		public const String P_TeacherShortName = "@" + C_TeacherShortName;
		public const String P_SubjectGroupID = "@" + C_SubjectGroupID;
		public const String P_LevelA = "@" + C_LevelA;
		public const String P_LevelB = "@" + C_LevelB;
		public const String P_Email = "@" + C_Email;
		public const String P_Tel = "@" + C_Tel;
		public const String P_TeacherTypeID = "@" + C_TeacherTypeID;
		public const String P_BirthDateText = "@" + C_BirthDateText;
		public const String P_PersonID = "@" + C_PersonID;
		public const String P_PersionIDDate = "@" + C_PersionIDDate;
		public const String P_PersionIDPlace = "@" + C_PersionIDPlace;
		public const String P_Gender = "@" + C_Gender;
		public const String P_EthnicityID = "@" + C_EthnicityID;
		public const String P_ReligionID = "@" + C_ReligionID;
		public const String P_Party = "@" + C_Party;
		public const String P_OriginPlace = "@" + C_OriginPlace;
		public const String P_LiveAddress = "@" + C_LiveAddress;
		public const String P_DegreeTitleID = "@" + C_DegreeTitleID;
		public const String P_DegreeID = "@" + C_DegreeID;
		public const String P_SpecialBranch = "@" + C_SpecialBranch;
		public const String P_OtherSpecialBranch = "@" + C_OtherSpecialBranch;
		public const String P_TeachingLevel = "@" + C_TeachingLevel;
		public const String P_ComputerLevel = "@" + C_ComputerLevel;
		public const String P_ForeignLanguageLevel = "@" + C_ForeignLanguageLevel;
		public const String P_TaxCode = "@" + C_TaxCode;
		public const String P_Status = "@" + C_Status;
		public const String P_AllowScheduling = "@" + C_AllowScheduling;
		public const String P_MaxQuantityOfDay = "@" + C_MaxQuantityOfDay;
		public const String P_MaxQuantityOfSession = "@" + C_MaxQuantityOfSession;
		public const String P_MaxSessionOfDay = "@" + C_MaxSessionOfDay;
		public const String P_MaxTheoryQuantityOfSemester = "@" + C_MaxTheoryQuantityOfSemester;
		public const String P_MaxPracticeQuantityOfSemester = "@" + C_MaxPracticeQuantityOfSemester;
		public const String P_MinTheoryQuantityOfYear = "@" + C_MinTheoryQuantityOfYear;
		public const String P_MinPracticeQuantityOfYear = "@" + C_MinPracticeQuantityOfYear;
		public const String P_RatioMinQuantityOfYear = "@" + C_RatioMinQuantityOfYear;
		public const String P_IsMorning = "@" + C_IsMorning;
		public const String P_IsEvening = "@" + C_IsEvening;
		public const String P_IsNight = "@" + C_IsNight;
		public const String P_Description = "@" + C_Description;
		public const String P_AllowTestScheduling = "@" + C_AllowTestScheduling;
		public const String P_CreatedBy = "@" + C_CreatedBy;
		public const String P_CreatedAt = "@" + C_CreatedAt;
		public const String P_ModifiedBy = "@" + C_ModifiedBy;
		public const String P_ModifiedAt = "@" + C_ModifiedAt;

		#endregion //Parameter names

		#region Column Names

		public const String C_TeacherID = "TeacherID";
		public const String C_TeacherFirstName = "TeacherFirstName";
		public const String C_TeacherLastName = "TeacherLastName";
		public const String C_TeacherShortName = "TeacherShortName";
		public const String C_SubjectGroupID = "SubjectGroupID";
		public const String C_LevelA = "LevelA";
		public const String C_LevelB = "LevelB";
		public const String C_Email = "Email";
		public const String C_Tel = "Tel";
		public const String C_TeacherTypeID = "TeacherTypeID";
		public const String C_BirthDateText = "BirthDateText";
		public const String C_PersonID = "PersonID";
		public const String C_PersionIDDate = "PersionIDDate";
		public const String C_PersionIDPlace = "PersionIDPlace";
		public const String C_Gender = "Gender";
		public const String C_EthnicityID = "EthnicityID";
		public const String C_ReligionID = "ReligionID";
		public const String C_Party = "Party";
		public const String C_OriginPlace = "OriginPlace";
		public const String C_LiveAddress = "LiveAddress";
		public const String C_DegreeTitleID = "DegreeTitleID";
		public const String C_DegreeID = "DegreeID";
		public const String C_SpecialBranch = "SpecialBranch";
		public const String C_OtherSpecialBranch = "OtherSpecialBranch";
		public const String C_TeachingLevel = "TeachingLevel";
		public const String C_ComputerLevel = "ComputerLevel";
		public const String C_ForeignLanguageLevel = "ForeignLanguageLevel";
		public const String C_TaxCode = "TaxCode";
		public const String C_Status = "Status";
		public const String C_AllowScheduling = "AllowScheduling";
		public const String C_MaxQuantityOfDay = "MaxQuantityOfDay";
		public const String C_MaxQuantityOfSession = "MaxQuantityOfSession";
		public const String C_MaxSessionOfDay = "MaxSessionOfDay";
		public const String C_MaxTheoryQuantityOfSemester = "MaxTheoryQuantityOfSemester";
		public const String C_MaxPracticeQuantityOfSemester = "MaxPracticeQuantityOfSemester";
		public const String C_MinTheoryQuantityOfYear = "MinTheoryQuantityOfYear";
		public const String C_MinPracticeQuantityOfYear = "MinPracticeQuantityOfYear";
		public const String C_RatioMinQuantityOfYear = "RatioMinQuantityOfYear";
		public const String C_IsMorning = "IsMorning";
		public const String C_IsEvening = "IsEvening";
		public const String C_IsNight = "IsNight";
		public const String C_Description = "Description";
		public const String C_AllowTestScheduling = "AllowTestScheduling";
		public const String C_CreatedBy = "CreatedBy";
		public const String C_CreatedAt = "CreatedAt";
		public const String C_ModifiedBy = "ModifiedBy";
		public const String C_ModifiedAt = "ModifiedAt";

		#endregion //Column names

		#endregion Variable Static		
	}
}
