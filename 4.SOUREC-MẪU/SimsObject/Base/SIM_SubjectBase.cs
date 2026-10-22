
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
	public partial class SIM_Subject
	{	
		#region Member Variables

		private string strSubjectID = null;//Mã môn học
		private string strSubjectName = null;//Tên môn học
		private string strSubjectShortName = null;//Tên môn viết tắc
		private string strSubjectGroupID = null;//Mã bộ môn
		private int? intTheoryQuantity = null;//Số tiết lý thuyết
		private int? intPracticeQuantity = null;//Số tiết thực hành
		private int? intTestQuantity = null;//Số giờ kiểm tra
		private int? intUnitText = null;
		private string strSetType = null;//Khối kiến thức
		private int? intTheoryRoomType = null;//Loại phòng học lý thuyết: 0: Không cần phòng, 1: Bất cứ phòng nào, 2: Bất cứ phòng lý thuyết nào,3: Theo danh sách được chọn
		private int? intPracticeRoomType = null;//Loại phòng học thực hành: 0: Không cần phòng, 1: Bất cứ phòng nào, 2: Bất cứ phòng thực hành nào,3: Theo danh sách được chọn
		private int? intSubjectType = null;//Dùng lên kế hoạch tuần và sắp lịch. 0: Cả lý thuyết và thực hành, 1: Là môn lý thuyết, 2: là môn thực hành
		private int? intSubjectKind = null;//Dùng để tính hệ số giờ giảng. 0: Tích hợp, 1: Là môn lý thuyết, 2: là môn thực hành
		private string strQuantityGroupForSession = null;//Số tiết cho mỗi buổi được cho phép. VD: 5;3 là cho phép sắp 5, hoặc 3 cho mỗi buổi. Không dc sắp 1,2,3,...
		private bool bolAllowScheduling = false;//Cho phép sếp lịch hay không?
		private bool bolIsPacingDay = false;//Phải sếp cách ngày
		private bool bolIsMorning = false;//Sắp buổi sáng
		private bool bolIsEvening = false;//Sắp buổi chiều
		private bool bolIsNight = false;//Sắp lịch buổi tối
		private bool bolIsTeachingAtOutSchool = false;//Dạy ở ngoài trường?
		private int? intMinuteOfLession = null;//Số phút của một tiết học
		private int? intSubjectSet = null;//Khối môn: 0. Khối môn học chung, 1. Khối môn kỹ thuật, 2. Khối môn kinh tế
		private bool bolAllowTestScheduling = false;//Cho phép sắp lịch thi tự động
		private int? intMinuteOfTheoryTest = null;//Số phút thi lý thuyết
		private int? intMinuteOfPracticeTest = null;//Số phút thi thực hành
		private int? intSpecialType = null;//Loại đặc trưng: 1_Bình thường, 2. Tốt nghiệp LT, 3. Tốt nghiệp TH, 4. CT tốt nghiệp, 5. Tốt nghiệp Văn hoá, 6. GD thể chất, 7. GD quốc phòng,8. Văn hóa,9. Môn thực tập
		private string strCreatedBy = null;//Chỉ sắp buổi sáng
		private DateTime? dtmCreatedAt = null;//Ngày tạo
		private string strModifiedBy = null;//Người sửa
		private DateTime? dtmModifiedAt = null;//Ngày sửa
		private int? intMark1Number = null;//Số cột điểm hs 1
		private int? intMark2Number = null;//Số cột điểm hs 2
		private double? dblPracticeQuantityRatio = null;//Hệ số qui đổi giờ TH
		private int? intLearningLevel = null;//Trình độ chương trình học Null: môn chung, 1. Sơ cấp, 2. Trung cấp, 3. Cao đẳng
		private bool bolIsTextMark = false;//Là môn tính điểm chữ Đ, hoặc CĐ. Khi đó lưu sổ điểm Đạt = 110, chưa đặt là 100
		private bool bolIsPractice = false;//Là môn thực hành (có điểm thi thực hành)
		private int? intTheoryRatio = null;//Hệ số thi LT
		private int? intPracticeRatio = null;//Hệ số thi TH
		private int? intOrderIndex = null;
		private bool bolIsOnlyForScheduling = false;
		private long? lngTSubjectID = null;
		private double? dblRequestMinMark = null;//Yêu cầu điểm tối thiểu để đạt môn
		private int? intTheoryUnitText = null;//Số chỉ LT
		private int? intPracticeUnitText = null;//Số chỉ TH
		private int? intOtherRatio = null;//Hệ số thi khác (ngoài lý thuyết, thực hành, ...)
		private bool bolIsInternational = false;//Là môn quốc tế
		private bool bolIsForeignLanguage = false;//Là môn ngoại ngữ
		private double? dblRequestMinTheoryExam = null;//Yêu cầu điểm tối thiểu để đạt môn (điểm thi LT)
		private double? dblRequestMinPracticeExam = null;//Yêu cầu điểm tối thiểu để đạt môn (điểm thi thực hành)
		private double? dblRequestMinOtherExam = null;//Yêu cầu điểm tối thiểu để đạt môn (Điểm thi khác)
		private bool bolAnswerIndexIsNumber = false;//Chỉ mục của đáp án là số khi Exam
		private IData objIData = null;
		private bool bolIsExistIData = false;
		private Exception objErrorException = null;

		#endregion

		#region Properties 

		/// <summary>
		/// SubjectID
		/// Mã môn học
		/// </summary>
		public string SubjectID
		{
			get { return  strSubjectID; }
			set { strSubjectID = value; }
		}
		/// <summary>
		/// SubjectName
		/// Tên môn học
		/// </summary>
		public string SubjectName
		{
			get { return  strSubjectName; }
			set { strSubjectName = value; }
		}
		/// <summary>
		/// SubjectShortName
		/// Tên môn viết tắc
		/// </summary>
		public string SubjectShortName
		{
			get { return  strSubjectShortName; }
			set { strSubjectShortName = value; }
		}
		/// <summary>
		/// SubjectGroupID
		/// Mã bộ môn
		/// </summary>
		public string SubjectGroupID
		{
			get { return  strSubjectGroupID; }
			set { strSubjectGroupID = value; }
		}
		/// <summary>
		/// TheoryQuantity
		/// Số tiết lý thuyết
		/// </summary>
		public int? TheoryQuantity
		{
			get { return  intTheoryQuantity; }
			set { intTheoryQuantity = value; }
		}
		/// <summary>
		/// PracticeQuantity
		/// Số tiết thực hành
		/// </summary>
		public int? PracticeQuantity
		{
			get { return  intPracticeQuantity; }
			set { intPracticeQuantity = value; }
		}
		/// <summary>
		/// TestQuantity
		/// Số giờ kiểm tra
		/// </summary>
		public int? TestQuantity
		{
			get { return  intTestQuantity; }
			set { intTestQuantity = value; }
		}
		/// <summary>
		/// UnitText
		/// 
		/// </summary>
		public int? UnitText
		{
			get { return  intUnitText; }
			set { intUnitText = value; }
		}
		/// <summary>
		/// SetType
		/// Khối kiến thức
		/// </summary>
		public string SetType
		{
			get { return  strSetType; }
			set { strSetType = value; }
		}
		/// <summary>
		/// TheoryRoomType
		/// Loại phòng học lý thuyết: 0: Không cần phòng, 1: Bất cứ phòng nào, 2: Bất cứ phòng lý thuyết nào,3: Theo danh sách được chọn
		/// </summary>
		public int? TheoryRoomType
		{
			get { return  intTheoryRoomType; }
			set { intTheoryRoomType = value; }
		}
		/// <summary>
		/// PracticeRoomType
		/// Loại phòng học thực hành: 0: Không cần phòng, 1: Bất cứ phòng nào, 2: Bất cứ phòng thực hành nào,3: Theo danh sách được chọn
		/// </summary>
		public int? PracticeRoomType
		{
			get { return  intPracticeRoomType; }
			set { intPracticeRoomType = value; }
		}
		/// <summary>
		/// SubjectType
		/// Dùng lên kế hoạch tuần và sắp lịch. 0: Cả lý thuyết và thực hành, 1: Là môn lý thuyết, 2: là môn thực hành
		/// </summary>
		public int? SubjectType
		{
			get { return  intSubjectType; }
			set { intSubjectType = value; }
		}
		/// <summary>
		/// SubjectKind
		/// Dùng để tính hệ số giờ giảng. 0: Tích hợp, 1: Là môn lý thuyết, 2: là môn thực hành
		/// </summary>
		public int? SubjectKind
		{
			get { return  intSubjectKind; }
			set { intSubjectKind = value; }
		}
		/// <summary>
		/// QuantityGroupForSession
		/// Số tiết cho mỗi buổi được cho phép. VD: 5;3 là cho phép sắp 5, hoặc 3 cho mỗi buổi. Không dc sắp 1,2,3,...
		/// </summary>
		public string QuantityGroupForSession
		{
			get { return  strQuantityGroupForSession; }
			set { strQuantityGroupForSession = value; }
		}
		/// <summary>
		/// AllowScheduling
		/// Cho phép sếp lịch hay không?
		/// </summary>
		public bool AllowScheduling
		{
			get { return  bolAllowScheduling; }
			set { bolAllowScheduling = value; }
		}
		/// <summary>
		/// IsPacingDay
		/// Phải sếp cách ngày
		/// </summary>
		public bool IsPacingDay
		{
			get { return  bolIsPacingDay; }
			set { bolIsPacingDay = value; }
		}
		/// <summary>
		/// IsMorning
		/// Sắp buổi sáng
		/// </summary>
		public bool IsMorning
		{
			get { return  bolIsMorning; }
			set { bolIsMorning = value; }
		}
		/// <summary>
		/// IsEvening
		/// Sắp buổi chiều
		/// </summary>
		public bool IsEvening
		{
			get { return  bolIsEvening; }
			set { bolIsEvening = value; }
		}
		/// <summary>
		/// IsNight
		/// Sắp lịch buổi tối
		/// </summary>
		public bool IsNight
		{
			get { return  bolIsNight; }
			set { bolIsNight = value; }
		}
		/// <summary>
		/// IsTeachingAtOutSchool
		/// Dạy ở ngoài trường?
		/// </summary>
		public bool IsTeachingAtOutSchool
		{
			get { return  bolIsTeachingAtOutSchool; }
			set { bolIsTeachingAtOutSchool = value; }
		}
		/// <summary>
		/// MinuteOfLession
		/// Số phút của một tiết học
		/// </summary>
		public int? MinuteOfLession
		{
			get { return  intMinuteOfLession; }
			set { intMinuteOfLession = value; }
		}
		/// <summary>
		/// SubjectSet
		/// Khối môn: 0. Khối môn học chung, 1. Khối môn kỹ thuật, 2. Khối môn kinh tế
		/// </summary>
		public int? SubjectSet
		{
			get { return  intSubjectSet; }
			set { intSubjectSet = value; }
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
		/// MinuteOfTheoryTest
		/// Số phút thi lý thuyết
		/// </summary>
		public int? MinuteOfTheoryTest
		{
			get { return  intMinuteOfTheoryTest; }
			set { intMinuteOfTheoryTest = value; }
		}
		/// <summary>
		/// MinuteOfPracticeTest
		/// Số phút thi thực hành
		/// </summary>
		public int? MinuteOfPracticeTest
		{
			get { return  intMinuteOfPracticeTest; }
			set { intMinuteOfPracticeTest = value; }
		}
		/// <summary>
		/// SpecialType
		/// Loại đặc trưng: 1_Bình thường, 2. Tốt nghiệp LT, 3. Tốt nghiệp TH, 4. CT tốt nghiệp, 5. Tốt nghiệp Văn hoá, 6. GD thể chất, 7. GD quốc phòng,8. Văn hóa,9. Môn thực tập
		/// </summary>
		public int? SpecialType
		{
			get { return  intSpecialType; }
			set { intSpecialType = value; }
		}
		/// <summary>
		/// CreatedBy
		/// Chỉ sắp buổi sáng
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
		/// Mark1Number
		/// Số cột điểm hs 1
		/// </summary>
		public int? Mark1Number
		{
			get { return  intMark1Number; }
			set { intMark1Number = value; }
		}
		/// <summary>
		/// Mark2Number
		/// Số cột điểm hs 2
		/// </summary>
		public int? Mark2Number
		{
			get { return  intMark2Number; }
			set { intMark2Number = value; }
		}
		/// <summary>
		/// PracticeQuantityRatio
		/// Hệ số qui đổi giờ TH
		/// </summary>
		public double? PracticeQuantityRatio
		{
			get { return  dblPracticeQuantityRatio; }
			set { dblPracticeQuantityRatio = value; }
		}
		/// <summary>
		/// LearningLevel
		/// Trình độ chương trình học Null: môn chung, 1. Sơ cấp, 2. Trung cấp, 3. Cao đẳng
		/// </summary>
		public int? LearningLevel
		{
			get { return  intLearningLevel; }
			set { intLearningLevel = value; }
		}
		/// <summary>
		/// IsTextMark
		/// Là môn tính điểm chữ Đ, hoặc CĐ. Khi đó lưu sổ điểm Đạt = 110, chưa đặt là 100
		/// </summary>
		public bool IsTextMark
		{
			get { return  bolIsTextMark; }
			set { bolIsTextMark = value; }
		}
		/// <summary>
		/// IsPractice
		/// Là môn thực hành (có điểm thi thực hành)
		/// </summary>
		public bool IsPractice
		{
			get { return  bolIsPractice; }
			set { bolIsPractice = value; }
		}
		/// <summary>
		/// TheoryRatio
		/// Hệ số thi LT
		/// </summary>
		public int? TheoryRatio
		{
			get { return  intTheoryRatio; }
			set { intTheoryRatio = value; }
		}
		/// <summary>
		/// PracticeRatio
		/// Hệ số thi TH
		/// </summary>
		public int? PracticeRatio
		{
			get { return  intPracticeRatio; }
			set { intPracticeRatio = value; }
		}
		/// <summary>
		/// OrderIndex
		/// 
		/// </summary>
		public int? OrderIndex
		{
			get { return  intOrderIndex; }
			set { intOrderIndex = value; }
		}
		/// <summary>
		/// IsOnlyForScheduling
		/// 
		/// </summary>
		public bool IsOnlyForScheduling
		{
			get { return  bolIsOnlyForScheduling; }
			set { bolIsOnlyForScheduling = value; }
		}
		/// <summary>
		/// TSubjectID
		/// 
		/// </summary>
		public long? TSubjectID
		{
			get { return  lngTSubjectID; }
			set { lngTSubjectID = value; }
		}
		/// <summary>
		/// RequestMinMark
		/// Yêu cầu điểm tối thiểu để đạt môn
		/// </summary>
		public double? RequestMinMark
		{
			get { return  dblRequestMinMark; }
			set { dblRequestMinMark = value; }
		}
		/// <summary>
		/// TheoryUnitText
		/// Số chỉ LT
		/// </summary>
		public int? TheoryUnitText
		{
			get { return  intTheoryUnitText; }
			set { intTheoryUnitText = value; }
		}
		/// <summary>
		/// PracticeUnitText
		/// Số chỉ TH
		/// </summary>
		public int? PracticeUnitText
		{
			get { return  intPracticeUnitText; }
			set { intPracticeUnitText = value; }
		}
		/// <summary>
		/// OtherRatio
		/// Hệ số thi khác (ngoài lý thuyết, thực hành, ...)
		/// </summary>
		public int? OtherRatio
		{
			get { return  intOtherRatio; }
			set { intOtherRatio = value; }
		}
		/// <summary>
		/// IsInternational
		/// Là môn quốc tế
		/// </summary>
		public bool IsInternational
		{
			get { return  bolIsInternational; }
			set { bolIsInternational = value; }
		}
		/// <summary>
		/// IsForeignLanguage
		/// Là môn ngoại ngữ
		/// </summary>
		public bool IsForeignLanguage
		{
			get { return  bolIsForeignLanguage; }
			set { bolIsForeignLanguage = value; }
		}
		/// <summary>
		/// RequestMinTheoryExam
		/// Yêu cầu điểm tối thiểu để đạt môn (điểm thi LT)
		/// </summary>
		public double? RequestMinTheoryExam
		{
			get { return  dblRequestMinTheoryExam; }
			set { dblRequestMinTheoryExam = value; }
		}
		/// <summary>
		/// RequestMinPracticeExam
		/// Yêu cầu điểm tối thiểu để đạt môn (điểm thi thực hành)
		/// </summary>
		public double? RequestMinPracticeExam
		{
			get { return  dblRequestMinPracticeExam; }
			set { dblRequestMinPracticeExam = value; }
		}
		/// <summary>
		/// RequestMinOtherExam
		/// Yêu cầu điểm tối thiểu để đạt môn (Điểm thi khác)
		/// </summary>
		public double? RequestMinOtherExam
		{
			get { return  dblRequestMinOtherExam; }
			set { dblRequestMinOtherExam = value; }
		}
		/// <summary>
		/// AnswerIndexIsNumber
		/// Chỉ mục của đáp án là số khi Exam
		/// </summary>
		public bool AnswerIndexIsNumber
		{
			get { return  bolAnswerIndexIsNumber; }
			set { bolAnswerIndexIsNumber = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_SubjectID.ToUpper()) && !Convert.IsDBNull(reader[C_SubjectID])) this.strSubjectID = Convert.ToString(reader[C_SubjectID]);
					if (reader.GetName(i).ToUpper().Equals(C_SubjectName.ToUpper()) && !Convert.IsDBNull(reader[C_SubjectName])) this.strSubjectName = Convert.ToString(reader[C_SubjectName]);
					if (reader.GetName(i).ToUpper().Equals(C_SubjectShortName.ToUpper()) && !Convert.IsDBNull(reader[C_SubjectShortName])) this.strSubjectShortName = Convert.ToString(reader[C_SubjectShortName]);
					if (reader.GetName(i).ToUpper().Equals(C_SubjectGroupID.ToUpper()) && !Convert.IsDBNull(reader[C_SubjectGroupID])) this.strSubjectGroupID = Convert.ToString(reader[C_SubjectGroupID]);
					if (reader.GetName(i).ToUpper().Equals(C_TheoryQuantity.ToUpper()) && !Convert.IsDBNull(reader[C_TheoryQuantity])) this.intTheoryQuantity = Convert.ToInt32(reader[C_TheoryQuantity]);
					if (reader.GetName(i).ToUpper().Equals(C_PracticeQuantity.ToUpper()) && !Convert.IsDBNull(reader[C_PracticeQuantity])) this.intPracticeQuantity = Convert.ToInt32(reader[C_PracticeQuantity]);
					if (reader.GetName(i).ToUpper().Equals(C_TestQuantity.ToUpper()) && !Convert.IsDBNull(reader[C_TestQuantity])) this.intTestQuantity = Convert.ToInt32(reader[C_TestQuantity]);
					if (reader.GetName(i).ToUpper().Equals(C_UnitText.ToUpper()) && !Convert.IsDBNull(reader[C_UnitText])) this.intUnitText = Convert.ToInt32(reader[C_UnitText]);
					if (reader.GetName(i).ToUpper().Equals(C_SetType.ToUpper()) && !Convert.IsDBNull(reader[C_SetType])) this.strSetType = Convert.ToString(reader[C_SetType]);
					if (reader.GetName(i).ToUpper().Equals(C_TheoryRoomType.ToUpper()) && !Convert.IsDBNull(reader[C_TheoryRoomType])) this.intTheoryRoomType = Convert.ToInt32(reader[C_TheoryRoomType]);
					if (reader.GetName(i).ToUpper().Equals(C_PracticeRoomType.ToUpper()) && !Convert.IsDBNull(reader[C_PracticeRoomType])) this.intPracticeRoomType = Convert.ToInt32(reader[C_PracticeRoomType]);
					if (reader.GetName(i).ToUpper().Equals(C_SubjectType.ToUpper()) && !Convert.IsDBNull(reader[C_SubjectType])) this.intSubjectType = Convert.ToInt32(reader[C_SubjectType]);
					if (reader.GetName(i).ToUpper().Equals(C_SubjectKind.ToUpper()) && !Convert.IsDBNull(reader[C_SubjectKind])) this.intSubjectKind = Convert.ToInt32(reader[C_SubjectKind]);
					if (reader.GetName(i).ToUpper().Equals(C_QuantityGroupForSession.ToUpper()) && !Convert.IsDBNull(reader[C_QuantityGroupForSession])) this.strQuantityGroupForSession = Convert.ToString(reader[C_QuantityGroupForSession]);
					if (reader.GetName(i).ToUpper().Equals(C_AllowScheduling.ToUpper()) && !Convert.IsDBNull(reader[C_AllowScheduling])) this.bolAllowScheduling = Convert.ToBoolean(reader[C_AllowScheduling]);
					if (reader.GetName(i).ToUpper().Equals(C_IsPacingDay.ToUpper()) && !Convert.IsDBNull(reader[C_IsPacingDay])) this.bolIsPacingDay = Convert.ToBoolean(reader[C_IsPacingDay]);
					if (reader.GetName(i).ToUpper().Equals(C_IsMorning.ToUpper()) && !Convert.IsDBNull(reader[C_IsMorning])) this.bolIsMorning = Convert.ToBoolean(reader[C_IsMorning]);
					if (reader.GetName(i).ToUpper().Equals(C_IsEvening.ToUpper()) && !Convert.IsDBNull(reader[C_IsEvening])) this.bolIsEvening = Convert.ToBoolean(reader[C_IsEvening]);
					if (reader.GetName(i).ToUpper().Equals(C_IsNight.ToUpper()) && !Convert.IsDBNull(reader[C_IsNight])) this.bolIsNight = Convert.ToBoolean(reader[C_IsNight]);
					if (reader.GetName(i).ToUpper().Equals(C_IsTeachingAtOutSchool.ToUpper()) && !Convert.IsDBNull(reader[C_IsTeachingAtOutSchool])) this.bolIsTeachingAtOutSchool = Convert.ToBoolean(reader[C_IsTeachingAtOutSchool]);
					if (reader.GetName(i).ToUpper().Equals(C_MinuteOfLession.ToUpper()) && !Convert.IsDBNull(reader[C_MinuteOfLession])) this.intMinuteOfLession = Convert.ToInt32(reader[C_MinuteOfLession]);
					if (reader.GetName(i).ToUpper().Equals(C_SubjectSet.ToUpper()) && !Convert.IsDBNull(reader[C_SubjectSet])) this.intSubjectSet = Convert.ToInt32(reader[C_SubjectSet]);
					if (reader.GetName(i).ToUpper().Equals(C_AllowTestScheduling.ToUpper()) && !Convert.IsDBNull(reader[C_AllowTestScheduling])) this.bolAllowTestScheduling = Convert.ToBoolean(reader[C_AllowTestScheduling]);
					if (reader.GetName(i).ToUpper().Equals(C_MinuteOfTheoryTest.ToUpper()) && !Convert.IsDBNull(reader[C_MinuteOfTheoryTest])) this.intMinuteOfTheoryTest = Convert.ToInt32(reader[C_MinuteOfTheoryTest]);
					if (reader.GetName(i).ToUpper().Equals(C_MinuteOfPracticeTest.ToUpper()) && !Convert.IsDBNull(reader[C_MinuteOfPracticeTest])) this.intMinuteOfPracticeTest = Convert.ToInt32(reader[C_MinuteOfPracticeTest]);
					if (reader.GetName(i).ToUpper().Equals(C_SpecialType.ToUpper()) && !Convert.IsDBNull(reader[C_SpecialType])) this.intSpecialType = Convert.ToInt32(reader[C_SpecialType]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedBy.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedBy])) this.strCreatedBy = Convert.ToString(reader[C_CreatedBy]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(reader[C_CreatedAt]);
					if (reader.GetName(i).ToUpper().Equals(C_ModifiedBy.ToUpper()) && !Convert.IsDBNull(reader[C_ModifiedBy])) this.strModifiedBy = Convert.ToString(reader[C_ModifiedBy]);
					if (reader.GetName(i).ToUpper().Equals(C_ModifiedAt.ToUpper()) && !Convert.IsDBNull(reader[C_ModifiedAt])) this.dtmModifiedAt = Convert.ToDateTime(reader[C_ModifiedAt]);
					if (reader.GetName(i).ToUpper().Equals(C_Mark1Number.ToUpper()) && !Convert.IsDBNull(reader[C_Mark1Number])) this.intMark1Number = Convert.ToInt32(reader[C_Mark1Number]);
					if (reader.GetName(i).ToUpper().Equals(C_Mark2Number.ToUpper()) && !Convert.IsDBNull(reader[C_Mark2Number])) this.intMark2Number = Convert.ToInt32(reader[C_Mark2Number]);
					if (reader.GetName(i).ToUpper().Equals(C_PracticeQuantityRatio.ToUpper()) && !Convert.IsDBNull(reader[C_PracticeQuantityRatio])) this.dblPracticeQuantityRatio = Convert.ToDouble(reader[C_PracticeQuantityRatio]);
					if (reader.GetName(i).ToUpper().Equals(C_LearningLevel.ToUpper()) && !Convert.IsDBNull(reader[C_LearningLevel])) this.intLearningLevel = Convert.ToInt32(reader[C_LearningLevel]);
					if (reader.GetName(i).ToUpper().Equals(C_IsTextMark.ToUpper()) && !Convert.IsDBNull(reader[C_IsTextMark])) this.bolIsTextMark = Convert.ToBoolean(reader[C_IsTextMark]);
					if (reader.GetName(i).ToUpper().Equals(C_IsPractice.ToUpper()) && !Convert.IsDBNull(reader[C_IsPractice])) this.bolIsPractice = Convert.ToBoolean(reader[C_IsPractice]);
					if (reader.GetName(i).ToUpper().Equals(C_TheoryRatio.ToUpper()) && !Convert.IsDBNull(reader[C_TheoryRatio])) this.intTheoryRatio = Convert.ToInt32(reader[C_TheoryRatio]);
					if (reader.GetName(i).ToUpper().Equals(C_PracticeRatio.ToUpper()) && !Convert.IsDBNull(reader[C_PracticeRatio])) this.intPracticeRatio = Convert.ToInt32(reader[C_PracticeRatio]);
					if (reader.GetName(i).ToUpper().Equals(C_OrderIndex.ToUpper()) && !Convert.IsDBNull(reader[C_OrderIndex])) this.intOrderIndex = Convert.ToInt32(reader[C_OrderIndex]);
					if (reader.GetName(i).ToUpper().Equals(C_IsOnlyForScheduling.ToUpper()) && !Convert.IsDBNull(reader[C_IsOnlyForScheduling])) this.bolIsOnlyForScheduling = Convert.ToBoolean(reader[C_IsOnlyForScheduling]);
					if (reader.GetName(i).ToUpper().Equals(C_TSubjectID.ToUpper()) && !Convert.IsDBNull(reader[C_TSubjectID])) this.lngTSubjectID = Convert.ToInt64(reader[C_TSubjectID]);
					if (reader.GetName(i).ToUpper().Equals(C_RequestMinMark.ToUpper()) && !Convert.IsDBNull(reader[C_RequestMinMark])) this.dblRequestMinMark = Convert.ToDouble(reader[C_RequestMinMark]);
					if (reader.GetName(i).ToUpper().Equals(C_TheoryUnitText.ToUpper()) && !Convert.IsDBNull(reader[C_TheoryUnitText])) this.intTheoryUnitText = Convert.ToInt32(reader[C_TheoryUnitText]);
					if (reader.GetName(i).ToUpper().Equals(C_PracticeUnitText.ToUpper()) && !Convert.IsDBNull(reader[C_PracticeUnitText])) this.intPracticeUnitText = Convert.ToInt32(reader[C_PracticeUnitText]);
					if (reader.GetName(i).ToUpper().Equals(C_OtherRatio.ToUpper()) && !Convert.IsDBNull(reader[C_OtherRatio])) this.intOtherRatio = Convert.ToInt32(reader[C_OtherRatio]);
					if (reader.GetName(i).ToUpper().Equals(C_IsInternational.ToUpper()) && !Convert.IsDBNull(reader[C_IsInternational])) this.bolIsInternational = Convert.ToBoolean(reader[C_IsInternational]);
					if (reader.GetName(i).ToUpper().Equals(C_IsForeignLanguage.ToUpper()) && !Convert.IsDBNull(reader[C_IsForeignLanguage])) this.bolIsForeignLanguage = Convert.ToBoolean(reader[C_IsForeignLanguage]);
					if (reader.GetName(i).ToUpper().Equals(C_RequestMinTheoryExam.ToUpper()) && !Convert.IsDBNull(reader[C_RequestMinTheoryExam])) this.dblRequestMinTheoryExam = Convert.ToDouble(reader[C_RequestMinTheoryExam]);
					if (reader.GetName(i).ToUpper().Equals(C_RequestMinPracticeExam.ToUpper()) && !Convert.IsDBNull(reader[C_RequestMinPracticeExam])) this.dblRequestMinPracticeExam = Convert.ToDouble(reader[C_RequestMinPracticeExam]);
					if (reader.GetName(i).ToUpper().Equals(C_RequestMinOtherExam.ToUpper()) && !Convert.IsDBNull(reader[C_RequestMinOtherExam])) this.dblRequestMinOtherExam = Convert.ToDouble(reader[C_RequestMinOtherExam]);
					if (reader.GetName(i).ToUpper().Equals(C_AnswerIndexIsNumber.ToUpper()) && !Convert.IsDBNull(reader[C_AnswerIndexIsNumber])) this.bolAnswerIndexIsNumber = Convert.ToBoolean(reader[C_AnswerIndexIsNumber]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_Subject", objEx);
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
				if (!Convert.IsDBNull(drw[C_SubjectID])) this.strSubjectID = Convert.ToString(drw[C_SubjectID]);
				if (!Convert.IsDBNull(drw[C_SubjectName])) this.strSubjectName = Convert.ToString(drw[C_SubjectName]);
				if (!Convert.IsDBNull(drw[C_SubjectShortName])) this.strSubjectShortName = Convert.ToString(drw[C_SubjectShortName]);
				if (!Convert.IsDBNull(drw[C_SubjectGroupID])) this.strSubjectGroupID = Convert.ToString(drw[C_SubjectGroupID]);
				if (!Convert.IsDBNull(drw[C_TheoryQuantity])) this.intTheoryQuantity = Convert.ToInt32(drw[C_TheoryQuantity]);
				if (!Convert.IsDBNull(drw[C_PracticeQuantity])) this.intPracticeQuantity = Convert.ToInt32(drw[C_PracticeQuantity]);
				if (!Convert.IsDBNull(drw[C_TestQuantity])) this.intTestQuantity = Convert.ToInt32(drw[C_TestQuantity]);
				if (!Convert.IsDBNull(drw[C_UnitText])) this.intUnitText = Convert.ToInt32(drw[C_UnitText]);
				if (!Convert.IsDBNull(drw[C_SetType])) this.strSetType = Convert.ToString(drw[C_SetType]);
				if (!Convert.IsDBNull(drw[C_TheoryRoomType])) this.intTheoryRoomType = Convert.ToInt32(drw[C_TheoryRoomType]);
				if (!Convert.IsDBNull(drw[C_PracticeRoomType])) this.intPracticeRoomType = Convert.ToInt32(drw[C_PracticeRoomType]);
				if (!Convert.IsDBNull(drw[C_SubjectType])) this.intSubjectType = Convert.ToInt32(drw[C_SubjectType]);
				if (!Convert.IsDBNull(drw[C_SubjectKind])) this.intSubjectKind = Convert.ToInt32(drw[C_SubjectKind]);
				if (!Convert.IsDBNull(drw[C_QuantityGroupForSession])) this.strQuantityGroupForSession = Convert.ToString(drw[C_QuantityGroupForSession]);
				if (!Convert.IsDBNull(drw[C_AllowScheduling])) this.bolAllowScheduling = Convert.ToBoolean(drw[C_AllowScheduling]);
				if (!Convert.IsDBNull(drw[C_IsPacingDay])) this.bolIsPacingDay = Convert.ToBoolean(drw[C_IsPacingDay]);
				if (!Convert.IsDBNull(drw[C_IsMorning])) this.bolIsMorning = Convert.ToBoolean(drw[C_IsMorning]);
				if (!Convert.IsDBNull(drw[C_IsEvening])) this.bolIsEvening = Convert.ToBoolean(drw[C_IsEvening]);
				if (!Convert.IsDBNull(drw[C_IsNight])) this.bolIsNight = Convert.ToBoolean(drw[C_IsNight]);
				if (!Convert.IsDBNull(drw[C_IsTeachingAtOutSchool])) this.bolIsTeachingAtOutSchool = Convert.ToBoolean(drw[C_IsTeachingAtOutSchool]);
				if (!Convert.IsDBNull(drw[C_MinuteOfLession])) this.intMinuteOfLession = Convert.ToInt32(drw[C_MinuteOfLession]);
				if (!Convert.IsDBNull(drw[C_SubjectSet])) this.intSubjectSet = Convert.ToInt32(drw[C_SubjectSet]);
				if (!Convert.IsDBNull(drw[C_AllowTestScheduling])) this.bolAllowTestScheduling = Convert.ToBoolean(drw[C_AllowTestScheduling]);
				if (!Convert.IsDBNull(drw[C_MinuteOfTheoryTest])) this.intMinuteOfTheoryTest = Convert.ToInt32(drw[C_MinuteOfTheoryTest]);
				if (!Convert.IsDBNull(drw[C_MinuteOfPracticeTest])) this.intMinuteOfPracticeTest = Convert.ToInt32(drw[C_MinuteOfPracticeTest]);
				if (!Convert.IsDBNull(drw[C_SpecialType])) this.intSpecialType = Convert.ToInt32(drw[C_SpecialType]);
				if (!Convert.IsDBNull(drw[C_CreatedBy])) this.strCreatedBy = Convert.ToString(drw[C_CreatedBy]);
				if (!Convert.IsDBNull(drw[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(drw[C_CreatedAt]);
				if (!Convert.IsDBNull(drw[C_ModifiedBy])) this.strModifiedBy = Convert.ToString(drw[C_ModifiedBy]);
				if (!Convert.IsDBNull(drw[C_ModifiedAt])) this.dtmModifiedAt = Convert.ToDateTime(drw[C_ModifiedAt]);
				if (!Convert.IsDBNull(drw[C_Mark1Number])) this.intMark1Number = Convert.ToInt32(drw[C_Mark1Number]);
				if (!Convert.IsDBNull(drw[C_Mark2Number])) this.intMark2Number = Convert.ToInt32(drw[C_Mark2Number]);
				if (!Convert.IsDBNull(drw[C_PracticeQuantityRatio])) this.dblPracticeQuantityRatio = Convert.ToDouble(drw[C_PracticeQuantityRatio]);
				if (!Convert.IsDBNull(drw[C_LearningLevel])) this.intLearningLevel = Convert.ToInt32(drw[C_LearningLevel]);
				if (!Convert.IsDBNull(drw[C_IsTextMark])) this.bolIsTextMark = Convert.ToBoolean(drw[C_IsTextMark]);
				if (!Convert.IsDBNull(drw[C_IsPractice])) this.bolIsPractice = Convert.ToBoolean(drw[C_IsPractice]);
				if (!Convert.IsDBNull(drw[C_TheoryRatio])) this.intTheoryRatio = Convert.ToInt32(drw[C_TheoryRatio]);
				if (!Convert.IsDBNull(drw[C_PracticeRatio])) this.intPracticeRatio = Convert.ToInt32(drw[C_PracticeRatio]);
				if (!Convert.IsDBNull(drw[C_OrderIndex])) this.intOrderIndex = Convert.ToInt32(drw[C_OrderIndex]);
				if (!Convert.IsDBNull(drw[C_IsOnlyForScheduling])) this.bolIsOnlyForScheduling = Convert.ToBoolean(drw[C_IsOnlyForScheduling]);
				if (!Convert.IsDBNull(drw[C_TSubjectID])) this.lngTSubjectID = Convert.ToInt64(drw[C_TSubjectID]);
				if (!Convert.IsDBNull(drw[C_RequestMinMark])) this.dblRequestMinMark = Convert.ToDouble(drw[C_RequestMinMark]);
				if (!Convert.IsDBNull(drw[C_TheoryUnitText])) this.intTheoryUnitText = Convert.ToInt32(drw[C_TheoryUnitText]);
				if (!Convert.IsDBNull(drw[C_PracticeUnitText])) this.intPracticeUnitText = Convert.ToInt32(drw[C_PracticeUnitText]);
				if (!Convert.IsDBNull(drw[C_OtherRatio])) this.intOtherRatio = Convert.ToInt32(drw[C_OtherRatio]);
				if (!Convert.IsDBNull(drw[C_IsInternational])) this.bolIsInternational = Convert.ToBoolean(drw[C_IsInternational]);
				if (!Convert.IsDBNull(drw[C_IsForeignLanguage])) this.bolIsForeignLanguage = Convert.ToBoolean(drw[C_IsForeignLanguage]);
				if (!Convert.IsDBNull(drw[C_RequestMinTheoryExam])) this.dblRequestMinTheoryExam = Convert.ToDouble(drw[C_RequestMinTheoryExam]);
				if (!Convert.IsDBNull(drw[C_RequestMinPracticeExam])) this.dblRequestMinPracticeExam = Convert.ToDouble(drw[C_RequestMinPracticeExam]);
				if (!Convert.IsDBNull(drw[C_RequestMinOtherExam])) this.dblRequestMinOtherExam = Convert.ToDouble(drw[C_RequestMinOtherExam]);
				if (!Convert.IsDBNull(drw[C_AnswerIndexIsNumber])) this.bolAnswerIndexIsNumber = Convert.ToBoolean(drw[C_AnswerIndexIsNumber]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_Subject", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_Subject_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Subject_GET");
				objIData.AddParameter(P_SubjectID, this.strSubjectID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_Subject", objEx);
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
		/// Store: SIM_Subject_GET 
		///</summary>
		/// <returns> SIM_Subject </returns>
		public SIM_Subject Get(string strSubjectID)
		{
			SIM_Subject obj = new SIM_Subject();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.SubjectID = strSubjectID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_Subject
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Subject", objEx);
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
		/// Search : SIM_Subject
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Subject", objEx);
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
		/// Search : SIM_Subject
		/// Lấy hết dữ liệu
		/// Store: SIM_Subject_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_Subject_GETALL");
		}

		///<summary>
		/// Search : SIM_Subject
		/// Tìm dữ liệu
		/// Store: SIM_Subject_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_Subject_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_Subject
		/// Thêm dữ liệu
		/// Store: SIM_Subject_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Subject_ADD");
				objIData.AddParameter(P_SubjectID, this.strSubjectID);
				objIData.AddParameter(P_SubjectName, this.strSubjectName);
				objIData.AddParameter(P_SubjectShortName, this.strSubjectShortName);
				objIData.AddParameter(P_SubjectGroupID, this.strSubjectGroupID);
				objIData.AddParameter(P_TheoryQuantity, this.intTheoryQuantity);
				objIData.AddParameter(P_PracticeQuantity, this.intPracticeQuantity);
				objIData.AddParameter(P_TestQuantity, this.intTestQuantity);
				objIData.AddParameter(P_UnitText, this.intUnitText);
				objIData.AddParameter(P_SetType, this.strSetType);
				objIData.AddParameter(P_TheoryRoomType, this.intTheoryRoomType);
				objIData.AddParameter(P_PracticeRoomType, this.intPracticeRoomType);
				objIData.AddParameter(P_SubjectType, this.intSubjectType);
				objIData.AddParameter(P_SubjectKind, this.intSubjectKind);
				objIData.AddParameter(P_QuantityGroupForSession, this.strQuantityGroupForSession);
				objIData.AddParameter(P_AllowScheduling, this.bolAllowScheduling);
				objIData.AddParameter(P_IsPacingDay, this.bolIsPacingDay);
				objIData.AddParameter(P_IsMorning, this.bolIsMorning);
				objIData.AddParameter(P_IsEvening, this.bolIsEvening);
				objIData.AddParameter(P_IsNight, this.bolIsNight);
				objIData.AddParameter(P_IsTeachingAtOutSchool, this.bolIsTeachingAtOutSchool);
				objIData.AddParameter(P_MinuteOfLession, this.intMinuteOfLession);
				objIData.AddParameter(P_SubjectSet, this.intSubjectSet);
				objIData.AddParameter(P_AllowTestScheduling, this.bolAllowTestScheduling);
				objIData.AddParameter(P_MinuteOfTheoryTest, this.intMinuteOfTheoryTest);
				objIData.AddParameter(P_MinuteOfPracticeTest, this.intMinuteOfPracticeTest);
				objIData.AddParameter(P_SpecialType, this.intSpecialType);
				objIData.AddParameter(P_CreatedBy, this.strCreatedBy);
				objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
				objIData.AddParameter(P_ModifiedBy, this.strModifiedBy);
				objIData.AddParameter(P_ModifiedAt, this.dtmModifiedAt);
				objIData.AddParameter(P_Mark1Number, this.intMark1Number);
				objIData.AddParameter(P_Mark2Number, this.intMark2Number);
				objIData.AddParameter(P_PracticeQuantityRatio, this.dblPracticeQuantityRatio);
				objIData.AddParameter(P_LearningLevel, this.intLearningLevel);
				objIData.AddParameter(P_IsTextMark, this.bolIsTextMark);
				objIData.AddParameter(P_IsPractice, this.bolIsPractice);
				objIData.AddParameter(P_TheoryRatio, this.intTheoryRatio);
				objIData.AddParameter(P_PracticeRatio, this.intPracticeRatio);
				objIData.AddParameter(P_OrderIndex, this.intOrderIndex);
				objIData.AddParameter(P_IsOnlyForScheduling, this.bolIsOnlyForScheduling);
				objIData.AddParameter(P_TSubjectID, this.lngTSubjectID);
				objIData.AddParameter(P_RequestMinMark, this.dblRequestMinMark);
				objIData.AddParameter(P_TheoryUnitText, this.intTheoryUnitText);
				objIData.AddParameter(P_PracticeUnitText, this.intPracticeUnitText);
				objIData.AddParameter(P_OtherRatio, this.intOtherRatio);
				objIData.AddParameter(P_IsInternational, this.bolIsInternational);
				objIData.AddParameter(P_IsForeignLanguage, this.bolIsForeignLanguage);
				objIData.AddParameter(P_RequestMinTheoryExam, this.dblRequestMinTheoryExam);
				objIData.AddParameter(P_RequestMinPracticeExam, this.dblRequestMinPracticeExam);
				objIData.AddParameter(P_RequestMinOtherExam, this.dblRequestMinOtherExam);
				objIData.AddParameter(P_AnswerIndexIsNumber, this.bolAnswerIndexIsNumber);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_Subject", objEx);
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
		/// Update : SIM_Subject
		/// Cập nhật dữ liệu
		/// Store: SIM_Subject_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Subject_EDIT");
				objIData.AddParameter(P_SubjectID, this.strSubjectID);
				objIData.AddParameter(P_SubjectName, this.strSubjectName);
				objIData.AddParameter(P_SubjectShortName, this.strSubjectShortName);
				objIData.AddParameter(P_SubjectGroupID, this.strSubjectGroupID);
				objIData.AddParameter(P_TheoryQuantity, this.intTheoryQuantity);
				objIData.AddParameter(P_PracticeQuantity, this.intPracticeQuantity);
				objIData.AddParameter(P_TestQuantity, this.intTestQuantity);
				objIData.AddParameter(P_UnitText, this.intUnitText);
				objIData.AddParameter(P_SetType, this.strSetType);
				objIData.AddParameter(P_TheoryRoomType, this.intTheoryRoomType);
				objIData.AddParameter(P_PracticeRoomType, this.intPracticeRoomType);
				objIData.AddParameter(P_SubjectType, this.intSubjectType);
				objIData.AddParameter(P_SubjectKind, this.intSubjectKind);
				objIData.AddParameter(P_QuantityGroupForSession, this.strQuantityGroupForSession);
				objIData.AddParameter(P_AllowScheduling, this.bolAllowScheduling);
				objIData.AddParameter(P_IsPacingDay, this.bolIsPacingDay);
				objIData.AddParameter(P_IsMorning, this.bolIsMorning);
				objIData.AddParameter(P_IsEvening, this.bolIsEvening);
				objIData.AddParameter(P_IsNight, this.bolIsNight);
				objIData.AddParameter(P_IsTeachingAtOutSchool, this.bolIsTeachingAtOutSchool);
				objIData.AddParameter(P_MinuteOfLession, this.intMinuteOfLession);
				objIData.AddParameter(P_SubjectSet, this.intSubjectSet);
				objIData.AddParameter(P_AllowTestScheduling, this.bolAllowTestScheduling);
				objIData.AddParameter(P_MinuteOfTheoryTest, this.intMinuteOfTheoryTest);
				objIData.AddParameter(P_MinuteOfPracticeTest, this.intMinuteOfPracticeTest);
				objIData.AddParameter(P_SpecialType, this.intSpecialType);
				objIData.AddParameter(P_CreatedBy, this.strCreatedBy);
				objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
				objIData.AddParameter(P_ModifiedBy, this.strModifiedBy);
				objIData.AddParameter(P_ModifiedAt, this.dtmModifiedAt);
				objIData.AddParameter(P_Mark1Number, this.intMark1Number);
				objIData.AddParameter(P_Mark2Number, this.intMark2Number);
				objIData.AddParameter(P_PracticeQuantityRatio, this.dblPracticeQuantityRatio);
				objIData.AddParameter(P_LearningLevel, this.intLearningLevel);
				objIData.AddParameter(P_IsTextMark, this.bolIsTextMark);
				objIData.AddParameter(P_IsPractice, this.bolIsPractice);
				objIData.AddParameter(P_TheoryRatio, this.intTheoryRatio);
				objIData.AddParameter(P_PracticeRatio, this.intPracticeRatio);
				objIData.AddParameter(P_OrderIndex, this.intOrderIndex);
				objIData.AddParameter(P_IsOnlyForScheduling, this.bolIsOnlyForScheduling);
				objIData.AddParameter(P_TSubjectID, this.lngTSubjectID);
				objIData.AddParameter(P_RequestMinMark, this.dblRequestMinMark);
				objIData.AddParameter(P_TheoryUnitText, this.intTheoryUnitText);
				objIData.AddParameter(P_PracticeUnitText, this.intPracticeUnitText);
				objIData.AddParameter(P_OtherRatio, this.intOtherRatio);
				objIData.AddParameter(P_IsInternational, this.bolIsInternational);
				objIData.AddParameter(P_IsForeignLanguage, this.bolIsForeignLanguage);
				objIData.AddParameter(P_RequestMinTheoryExam, this.dblRequestMinTheoryExam);
				objIData.AddParameter(P_RequestMinPracticeExam, this.dblRequestMinPracticeExam);
				objIData.AddParameter(P_RequestMinOtherExam, this.dblRequestMinOtherExam);
				objIData.AddParameter(P_AnswerIndexIsNumber, this.bolAnswerIndexIsNumber);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_Subject", objEx);
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
		/// Delete : SIM_Subject
		/// Xóa dữ liệu
		/// Store: SIM_Subject_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Subject_DELETE");
				objIData.AddParameter(P_SubjectID, this.strSubjectID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_Subject", objEx);
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
		/// Store: SIM_Subject_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(string strSubjectID)
		{
			this.strSubjectID = strSubjectID;
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

		public SIM_Subject()
		{
		}
		public SIM_Subject(string strSubjectID)
		{
			this.strSubjectID = strSubjectID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_SubjectID = "@" + C_SubjectID;
		public const String P_SubjectName = "@" + C_SubjectName;
		public const String P_SubjectShortName = "@" + C_SubjectShortName;
		public const String P_SubjectGroupID = "@" + C_SubjectGroupID;
		public const String P_TheoryQuantity = "@" + C_TheoryQuantity;
		public const String P_PracticeQuantity = "@" + C_PracticeQuantity;
		public const String P_TestQuantity = "@" + C_TestQuantity;
		public const String P_UnitText = "@" + C_UnitText;
		public const String P_SetType = "@" + C_SetType;
		public const String P_TheoryRoomType = "@" + C_TheoryRoomType;
		public const String P_PracticeRoomType = "@" + C_PracticeRoomType;
		public const String P_SubjectType = "@" + C_SubjectType;
		public const String P_SubjectKind = "@" + C_SubjectKind;
		public const String P_QuantityGroupForSession = "@" + C_QuantityGroupForSession;
		public const String P_AllowScheduling = "@" + C_AllowScheduling;
		public const String P_IsPacingDay = "@" + C_IsPacingDay;
		public const String P_IsMorning = "@" + C_IsMorning;
		public const String P_IsEvening = "@" + C_IsEvening;
		public const String P_IsNight = "@" + C_IsNight;
		public const String P_IsTeachingAtOutSchool = "@" + C_IsTeachingAtOutSchool;
		public const String P_MinuteOfLession = "@" + C_MinuteOfLession;
		public const String P_SubjectSet = "@" + C_SubjectSet;
		public const String P_AllowTestScheduling = "@" + C_AllowTestScheduling;
		public const String P_MinuteOfTheoryTest = "@" + C_MinuteOfTheoryTest;
		public const String P_MinuteOfPracticeTest = "@" + C_MinuteOfPracticeTest;
		public const String P_SpecialType = "@" + C_SpecialType;
		public const String P_CreatedBy = "@" + C_CreatedBy;
		public const String P_CreatedAt = "@" + C_CreatedAt;
		public const String P_ModifiedBy = "@" + C_ModifiedBy;
		public const String P_ModifiedAt = "@" + C_ModifiedAt;
		public const String P_Mark1Number = "@" + C_Mark1Number;
		public const String P_Mark2Number = "@" + C_Mark2Number;
		public const String P_PracticeQuantityRatio = "@" + C_PracticeQuantityRatio;
		public const String P_LearningLevel = "@" + C_LearningLevel;
		public const String P_IsTextMark = "@" + C_IsTextMark;
		public const String P_IsPractice = "@" + C_IsPractice;
		public const String P_TheoryRatio = "@" + C_TheoryRatio;
		public const String P_PracticeRatio = "@" + C_PracticeRatio;
		public const String P_OrderIndex = "@" + C_OrderIndex;
		public const String P_IsOnlyForScheduling = "@" + C_IsOnlyForScheduling;
		public const String P_TSubjectID = "@" + C_TSubjectID;
		public const String P_RequestMinMark = "@" + C_RequestMinMark;
		public const String P_TheoryUnitText = "@" + C_TheoryUnitText;
		public const String P_PracticeUnitText = "@" + C_PracticeUnitText;
		public const String P_OtherRatio = "@" + C_OtherRatio;
		public const String P_IsInternational = "@" + C_IsInternational;
		public const String P_IsForeignLanguage = "@" + C_IsForeignLanguage;
		public const String P_RequestMinTheoryExam = "@" + C_RequestMinTheoryExam;
		public const String P_RequestMinPracticeExam = "@" + C_RequestMinPracticeExam;
		public const String P_RequestMinOtherExam = "@" + C_RequestMinOtherExam;
		public const String P_AnswerIndexIsNumber = "@" + C_AnswerIndexIsNumber;

		#endregion //Parameter names

		#region Column Names

		public const String C_SubjectID = "SubjectID";
		public const String C_SubjectName = "SubjectName";
		public const String C_SubjectShortName = "SubjectShortName";
		public const String C_SubjectGroupID = "SubjectGroupID";
		public const String C_TheoryQuantity = "TheoryQuantity";
		public const String C_PracticeQuantity = "PracticeQuantity";
		public const String C_TestQuantity = "TestQuantity";
		public const String C_UnitText = "UnitText";
		public const String C_SetType = "SetType";
		public const String C_TheoryRoomType = "TheoryRoomType";
		public const String C_PracticeRoomType = "PracticeRoomType";
		public const String C_SubjectType = "SubjectType";
		public const String C_SubjectKind = "SubjectKind";
		public const String C_QuantityGroupForSession = "QuantityGroupForSession";
		public const String C_AllowScheduling = "AllowScheduling";
		public const String C_IsPacingDay = "IsPacingDay";
		public const String C_IsMorning = "IsMorning";
		public const String C_IsEvening = "IsEvening";
		public const String C_IsNight = "IsNight";
		public const String C_IsTeachingAtOutSchool = "IsTeachingAtOutSchool";
		public const String C_MinuteOfLession = "MinuteOfLession";
		public const String C_SubjectSet = "SubjectSet";
		public const String C_AllowTestScheduling = "AllowTestScheduling";
		public const String C_MinuteOfTheoryTest = "MinuteOfTheoryTest";
		public const String C_MinuteOfPracticeTest = "MinuteOfPracticeTest";
		public const String C_SpecialType = "SpecialType";
		public const String C_CreatedBy = "CreatedBy";
		public const String C_CreatedAt = "CreatedAt";
		public const String C_ModifiedBy = "ModifiedBy";
		public const String C_ModifiedAt = "ModifiedAt";
		public const String C_Mark1Number = "Mark1Number";
		public const String C_Mark2Number = "Mark2Number";
		public const String C_PracticeQuantityRatio = "PracticeQuantityRatio";
		public const String C_LearningLevel = "LearningLevel";
		public const String C_IsTextMark = "IsTextMark";
		public const String C_IsPractice = "IsPractice";
		public const String C_TheoryRatio = "TheoryRatio";
		public const String C_PracticeRatio = "PracticeRatio";
		public const String C_OrderIndex = "OrderIndex";
		public const String C_IsOnlyForScheduling = "IsOnlyForScheduling";
		public const String C_TSubjectID = "TSubjectID";
		public const String C_RequestMinMark = "RequestMinMark";
		public const String C_TheoryUnitText = "TheoryUnitText";
		public const String C_PracticeUnitText = "PracticeUnitText";
		public const String C_OtherRatio = "OtherRatio";
		public const String C_IsInternational = "IsInternational";
		public const String C_IsForeignLanguage = "IsForeignLanguage";
		public const String C_RequestMinTheoryExam = "RequestMinTheoryExam";
		public const String C_RequestMinPracticeExam = "RequestMinPracticeExam";
		public const String C_RequestMinOtherExam = "RequestMinOtherExam";
		public const String C_AnswerIndexIsNumber = "AnswerIndexIsNumber";

		#endregion //Column names

		#endregion Variable Static		
	}
}
