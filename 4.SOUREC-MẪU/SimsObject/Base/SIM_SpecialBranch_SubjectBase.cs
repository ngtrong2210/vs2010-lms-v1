
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
	public partial class SIM_SpecialBranch_Subject
	{	
		#region Member Variables

		private int? intSpecialBranchSubjectID = null;
		private int? intSemester = null;//Học kỳ: 1, 2
		private int? intYear = null;//Năm học (1,2,3,4,5)
		private string strSpecialBranchID = null;//Mã chuyên ngành
		private string strTrainingLevelID = null;//Bậc đào tạo
		private string strTrainingType = null;//Loại đào tạo
		private string strCourseID = null;//Mã khoá học
		private string strSubjectID = null;//Mã môn
		private int? intTheoryQuantity = null;//Số tiết lý thuyết
		private int? intPracticeQuantity = null;//Số tiết thực hành
		private int? intTestQuantity = null;//Số giờ kiểm tra
		private int? intUnitText = null;
		private int? intExamWeek = null;//Số tuần ôn thi
		private int? intTheoryFee = null;//Học phí trên 1 chỉ lý thuyết
		private int? intPracticeFee = null;//Học phí trên một chỉ thực hành
		private int? intTotalFee = null;//Tổng học phí cho học phần này = TheoryFee * TheoryQuantity/15 + PracticeFee * PracticeQuantity/30
		private string strCreatedBy = null;
		private DateTime? dtmCreatedAt = null;//Ngày tạo
		private string strModifiedBy = null;//Người sửa
		private DateTime? dtmModifiedAt = null;//Ngày sửa
		private int? intMark1Number = null;//Số cột điểm hs 1
		private int? intMark2Number = null;//Số cột điểm hs 2
		private int? intSBSSameID = null;//Mã nhóm môn tương đương của chương trình khung
		private int? intTheoryUnitText = null;//Số chỉ LT
		private int? intPracticeUnitText = null;//Số chỉ TH
		private IData objIData = null;
		private bool bolIsExistIData = false;
		private Exception objErrorException = null;

		#endregion

		#region Properties 

		/// <summary>
		/// SpecialBranchSubjectID
		/// 
		/// </summary>
		public int? SpecialBranchSubjectID
		{
			get { return  intSpecialBranchSubjectID; }
			set { intSpecialBranchSubjectID = value; }
		}
		/// <summary>
		/// Semester
		/// Học kỳ: 1, 2
		/// </summary>
		public int? Semester
		{
			get { return  intSemester; }
			set { intSemester = value; }
		}
		/// <summary>
		/// Year
		/// Năm học (1,2,3,4,5)
		/// </summary>
		public int? Year
		{
			get { return  intYear; }
			set { intYear = value; }
		}
		/// <summary>
		/// SpecialBranchID
		/// Mã chuyên ngành
		/// </summary>
		public string SpecialBranchID
		{
			get { return  strSpecialBranchID; }
			set { strSpecialBranchID = value; }
		}
		/// <summary>
		/// TrainingLevelID
		/// Bậc đào tạo
		/// </summary>
		public string TrainingLevelID
		{
			get { return  strTrainingLevelID; }
			set { strTrainingLevelID = value; }
		}
		/// <summary>
		/// TrainingType
		/// Loại đào tạo
		/// </summary>
		public string TrainingType
		{
			get { return  strTrainingType; }
			set { strTrainingType = value; }
		}
		/// <summary>
		/// CourseID
		/// Mã khoá học
		/// </summary>
		public string CourseID
		{
			get { return  strCourseID; }
			set { strCourseID = value; }
		}
		/// <summary>
		/// SubjectID
		/// Mã môn
		/// </summary>
		public string SubjectID
		{
			get { return  strSubjectID; }
			set { strSubjectID = value; }
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
		/// ExamWeek
		/// Số tuần ôn thi
		/// </summary>
		public int? ExamWeek
		{
			get { return  intExamWeek; }
			set { intExamWeek = value; }
		}
		/// <summary>
		/// TheoryFee
		/// Học phí trên 1 chỉ lý thuyết
		/// </summary>
		public int? TheoryFee
		{
			get { return  intTheoryFee; }
			set { intTheoryFee = value; }
		}
		/// <summary>
		/// PracticeFee
		/// Học phí trên một chỉ thực hành
		/// </summary>
		public int? PracticeFee
		{
			get { return  intPracticeFee; }
			set { intPracticeFee = value; }
		}
		/// <summary>
		/// TotalFee
		/// Tổng học phí cho học phần này = TheoryFee * TheoryQuantity/15 + PracticeFee * PracticeQuantity/30
		/// </summary>
		public int? TotalFee
		{
			get { return  intTotalFee; }
			set { intTotalFee = value; }
		}
		/// <summary>
		/// CreatedBy
		/// 
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
		/// SBSSameID
		/// Mã nhóm môn tương đương của chương trình khung
		/// </summary>
		public int? SBSSameID
		{
			get { return  intSBSSameID; }
			set { intSBSSameID = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_SpecialBranchSubjectID.ToUpper()) && !Convert.IsDBNull(reader[C_SpecialBranchSubjectID])) this.intSpecialBranchSubjectID = Convert.ToInt32(reader[C_SpecialBranchSubjectID]);
					if (reader.GetName(i).ToUpper().Equals(C_Semester.ToUpper()) && !Convert.IsDBNull(reader[C_Semester])) this.intSemester = Convert.ToInt32(reader[C_Semester]);
					if (reader.GetName(i).ToUpper().Equals(C_Year.ToUpper()) && !Convert.IsDBNull(reader[C_Year])) this.intYear = Convert.ToInt32(reader[C_Year]);
					if (reader.GetName(i).ToUpper().Equals(C_SpecialBranchID.ToUpper()) && !Convert.IsDBNull(reader[C_SpecialBranchID])) this.strSpecialBranchID = Convert.ToString(reader[C_SpecialBranchID]);
					if (reader.GetName(i).ToUpper().Equals(C_TrainingLevelID.ToUpper()) && !Convert.IsDBNull(reader[C_TrainingLevelID])) this.strTrainingLevelID = Convert.ToString(reader[C_TrainingLevelID]);
					if (reader.GetName(i).ToUpper().Equals(C_TrainingType.ToUpper()) && !Convert.IsDBNull(reader[C_TrainingType])) this.strTrainingType = Convert.ToString(reader[C_TrainingType]);
					if (reader.GetName(i).ToUpper().Equals(C_CourseID.ToUpper()) && !Convert.IsDBNull(reader[C_CourseID])) this.strCourseID = Convert.ToString(reader[C_CourseID]);
					if (reader.GetName(i).ToUpper().Equals(C_SubjectID.ToUpper()) && !Convert.IsDBNull(reader[C_SubjectID])) this.strSubjectID = Convert.ToString(reader[C_SubjectID]);
					if (reader.GetName(i).ToUpper().Equals(C_TheoryQuantity.ToUpper()) && !Convert.IsDBNull(reader[C_TheoryQuantity])) this.intTheoryQuantity = Convert.ToInt32(reader[C_TheoryQuantity]);
					if (reader.GetName(i).ToUpper().Equals(C_PracticeQuantity.ToUpper()) && !Convert.IsDBNull(reader[C_PracticeQuantity])) this.intPracticeQuantity = Convert.ToInt32(reader[C_PracticeQuantity]);
					if (reader.GetName(i).ToUpper().Equals(C_TestQuantity.ToUpper()) && !Convert.IsDBNull(reader[C_TestQuantity])) this.intTestQuantity = Convert.ToInt32(reader[C_TestQuantity]);
					if (reader.GetName(i).ToUpper().Equals(C_UnitText.ToUpper()) && !Convert.IsDBNull(reader[C_UnitText])) this.intUnitText = Convert.ToInt32(reader[C_UnitText]);
					if (reader.GetName(i).ToUpper().Equals(C_ExamWeek.ToUpper()) && !Convert.IsDBNull(reader[C_ExamWeek])) this.intExamWeek = Convert.ToInt32(reader[C_ExamWeek]);
					if (reader.GetName(i).ToUpper().Equals(C_TheoryFee.ToUpper()) && !Convert.IsDBNull(reader[C_TheoryFee])) this.intTheoryFee = Convert.ToInt32(reader[C_TheoryFee]);
					if (reader.GetName(i).ToUpper().Equals(C_PracticeFee.ToUpper()) && !Convert.IsDBNull(reader[C_PracticeFee])) this.intPracticeFee = Convert.ToInt32(reader[C_PracticeFee]);
					if (reader.GetName(i).ToUpper().Equals(C_TotalFee.ToUpper()) && !Convert.IsDBNull(reader[C_TotalFee])) this.intTotalFee = Convert.ToInt32(reader[C_TotalFee]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedBy.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedBy])) this.strCreatedBy = Convert.ToString(reader[C_CreatedBy]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(reader[C_CreatedAt]);
					if (reader.GetName(i).ToUpper().Equals(C_ModifiedBy.ToUpper()) && !Convert.IsDBNull(reader[C_ModifiedBy])) this.strModifiedBy = Convert.ToString(reader[C_ModifiedBy]);
					if (reader.GetName(i).ToUpper().Equals(C_ModifiedAt.ToUpper()) && !Convert.IsDBNull(reader[C_ModifiedAt])) this.dtmModifiedAt = Convert.ToDateTime(reader[C_ModifiedAt]);
					if (reader.GetName(i).ToUpper().Equals(C_Mark1Number.ToUpper()) && !Convert.IsDBNull(reader[C_Mark1Number])) this.intMark1Number = Convert.ToInt32(reader[C_Mark1Number]);
					if (reader.GetName(i).ToUpper().Equals(C_Mark2Number.ToUpper()) && !Convert.IsDBNull(reader[C_Mark2Number])) this.intMark2Number = Convert.ToInt32(reader[C_Mark2Number]);
					if (reader.GetName(i).ToUpper().Equals(C_SBSSameID.ToUpper()) && !Convert.IsDBNull(reader[C_SBSSameID])) this.intSBSSameID = Convert.ToInt32(reader[C_SBSSameID]);
					if (reader.GetName(i).ToUpper().Equals(C_TheoryUnitText.ToUpper()) && !Convert.IsDBNull(reader[C_TheoryUnitText])) this.intTheoryUnitText = Convert.ToInt32(reader[C_TheoryUnitText]);
					if (reader.GetName(i).ToUpper().Equals(C_PracticeUnitText.ToUpper()) && !Convert.IsDBNull(reader[C_PracticeUnitText])) this.intPracticeUnitText = Convert.ToInt32(reader[C_PracticeUnitText]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_SpecialBranch_Subject", objEx);
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
				if (!Convert.IsDBNull(drw[C_SpecialBranchSubjectID])) this.intSpecialBranchSubjectID = Convert.ToInt32(drw[C_SpecialBranchSubjectID]);
				if (!Convert.IsDBNull(drw[C_Semester])) this.intSemester = Convert.ToInt32(drw[C_Semester]);
				if (!Convert.IsDBNull(drw[C_Year])) this.intYear = Convert.ToInt32(drw[C_Year]);
				if (!Convert.IsDBNull(drw[C_SpecialBranchID])) this.strSpecialBranchID = Convert.ToString(drw[C_SpecialBranchID]);
				if (!Convert.IsDBNull(drw[C_TrainingLevelID])) this.strTrainingLevelID = Convert.ToString(drw[C_TrainingLevelID]);
				if (!Convert.IsDBNull(drw[C_TrainingType])) this.strTrainingType = Convert.ToString(drw[C_TrainingType]);
				if (!Convert.IsDBNull(drw[C_CourseID])) this.strCourseID = Convert.ToString(drw[C_CourseID]);
				if (!Convert.IsDBNull(drw[C_SubjectID])) this.strSubjectID = Convert.ToString(drw[C_SubjectID]);
				if (!Convert.IsDBNull(drw[C_TheoryQuantity])) this.intTheoryQuantity = Convert.ToInt32(drw[C_TheoryQuantity]);
				if (!Convert.IsDBNull(drw[C_PracticeQuantity])) this.intPracticeQuantity = Convert.ToInt32(drw[C_PracticeQuantity]);
				if (!Convert.IsDBNull(drw[C_TestQuantity])) this.intTestQuantity = Convert.ToInt32(drw[C_TestQuantity]);
				if (!Convert.IsDBNull(drw[C_UnitText])) this.intUnitText = Convert.ToInt32(drw[C_UnitText]);
				if (!Convert.IsDBNull(drw[C_ExamWeek])) this.intExamWeek = Convert.ToInt32(drw[C_ExamWeek]);
				if (!Convert.IsDBNull(drw[C_TheoryFee])) this.intTheoryFee = Convert.ToInt32(drw[C_TheoryFee]);
				if (!Convert.IsDBNull(drw[C_PracticeFee])) this.intPracticeFee = Convert.ToInt32(drw[C_PracticeFee]);
				if (!Convert.IsDBNull(drw[C_TotalFee])) this.intTotalFee = Convert.ToInt32(drw[C_TotalFee]);
				if (!Convert.IsDBNull(drw[C_CreatedBy])) this.strCreatedBy = Convert.ToString(drw[C_CreatedBy]);
				if (!Convert.IsDBNull(drw[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(drw[C_CreatedAt]);
				if (!Convert.IsDBNull(drw[C_ModifiedBy])) this.strModifiedBy = Convert.ToString(drw[C_ModifiedBy]);
				if (!Convert.IsDBNull(drw[C_ModifiedAt])) this.dtmModifiedAt = Convert.ToDateTime(drw[C_ModifiedAt]);
				if (!Convert.IsDBNull(drw[C_Mark1Number])) this.intMark1Number = Convert.ToInt32(drw[C_Mark1Number]);
				if (!Convert.IsDBNull(drw[C_Mark2Number])) this.intMark2Number = Convert.ToInt32(drw[C_Mark2Number]);
				if (!Convert.IsDBNull(drw[C_SBSSameID])) this.intSBSSameID = Convert.ToInt32(drw[C_SBSSameID]);
				if (!Convert.IsDBNull(drw[C_TheoryUnitText])) this.intTheoryUnitText = Convert.ToInt32(drw[C_TheoryUnitText]);
				if (!Convert.IsDBNull(drw[C_PracticeUnitText])) this.intPracticeUnitText = Convert.ToInt32(drw[C_PracticeUnitText]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_SpecialBranch_Subject", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_SpecialBranch_Subject_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_SpecialBranch_Subject_GET");
				objIData.AddParameter(P_SpecialBranchSubjectID, this.intSpecialBranchSubjectID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_SpecialBranch_Subject", objEx);
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
		/// Store: SIM_SpecialBranch_Subject_GET 
		///</summary>
		/// <returns> SIM_SpecialBranch_Subject </returns>
		public SIM_SpecialBranch_Subject Get(int? intSpecialBranchSubjectID)
		{
			SIM_SpecialBranch_Subject obj = new SIM_SpecialBranch_Subject();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.SpecialBranchSubjectID = intSpecialBranchSubjectID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_SpecialBranch_Subject
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_SpecialBranch_Subject", objEx);
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
		/// Search : SIM_SpecialBranch_Subject
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_SpecialBranch_Subject", objEx);
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
		/// Search : SIM_SpecialBranch_Subject
		/// Lấy hết dữ liệu
		/// Store: SIM_SpecialBranch_Subject_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_SpecialBranch_Subject_GETALL");
		}

		///<summary>
		/// Search : SIM_SpecialBranch_Subject
		/// Tìm dữ liệu
		/// Store: SIM_SpecialBranch_Subject_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_SpecialBranch_Subject_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_SpecialBranch_Subject
		/// Thêm dữ liệu
		/// Store: SIM_SpecialBranch_Subject_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_SpecialBranch_Subject_ADD");
				objIData.AddParameter(P_Semester, this.intSemester);
				objIData.AddParameter(P_Year, this.intYear);
				objIData.AddParameter(P_SpecialBranchID, this.strSpecialBranchID);
				objIData.AddParameter(P_TrainingLevelID, this.strTrainingLevelID);
				objIData.AddParameter(P_TrainingType, this.strTrainingType);
				objIData.AddParameter(P_CourseID, this.strCourseID);
				objIData.AddParameter(P_SubjectID, this.strSubjectID);
				objIData.AddParameter(P_TheoryQuantity, this.intTheoryQuantity);
				objIData.AddParameter(P_PracticeQuantity, this.intPracticeQuantity);
				objIData.AddParameter(P_TestQuantity, this.intTestQuantity);
				objIData.AddParameter(P_UnitText, this.intUnitText);
				objIData.AddParameter(P_ExamWeek, this.intExamWeek);
				objIData.AddParameter(P_TheoryFee, this.intTheoryFee);
				objIData.AddParameter(P_PracticeFee, this.intPracticeFee);
				objIData.AddParameter(P_TotalFee, this.intTotalFee);
				objIData.AddParameter(P_CreatedBy, this.strCreatedBy);
				objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
				objIData.AddParameter(P_ModifiedBy, this.strModifiedBy);
				objIData.AddParameter(P_ModifiedAt, this.dtmModifiedAt);
				objIData.AddParameter(P_Mark1Number, this.intMark1Number);
				objIData.AddParameter(P_Mark2Number, this.intMark2Number);
				objIData.AddParameter(P_SBSSameID, this.intSBSSameID);
				objIData.AddParameter(P_TheoryUnitText, this.intTheoryUnitText);
				objIData.AddParameter(P_PracticeUnitText, this.intPracticeUnitText);
				this.intSpecialBranchSubjectID = Convert.ToInt32(objIData.ExecStoreToString());
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_SpecialBranch_Subject", objEx);
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
		/// Update : SIM_SpecialBranch_Subject
		/// Cập nhật dữ liệu
		/// Store: SIM_SpecialBranch_Subject_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_SpecialBranch_Subject_EDIT");
				objIData.AddParameter(P_SpecialBranchSubjectID, this.intSpecialBranchSubjectID);
				objIData.AddParameter(P_Semester, this.intSemester);
				objIData.AddParameter(P_Year, this.intYear);
				objIData.AddParameter(P_SpecialBranchID, this.strSpecialBranchID);
				objIData.AddParameter(P_TrainingLevelID, this.strTrainingLevelID);
				objIData.AddParameter(P_TrainingType, this.strTrainingType);
				objIData.AddParameter(P_CourseID, this.strCourseID);
				objIData.AddParameter(P_SubjectID, this.strSubjectID);
				objIData.AddParameter(P_TheoryQuantity, this.intTheoryQuantity);
				objIData.AddParameter(P_PracticeQuantity, this.intPracticeQuantity);
				objIData.AddParameter(P_TestQuantity, this.intTestQuantity);
				objIData.AddParameter(P_UnitText, this.intUnitText);
				objIData.AddParameter(P_ExamWeek, this.intExamWeek);
				objIData.AddParameter(P_TheoryFee, this.intTheoryFee);
				objIData.AddParameter(P_PracticeFee, this.intPracticeFee);
				objIData.AddParameter(P_TotalFee, this.intTotalFee);
				objIData.AddParameter(P_CreatedBy, this.strCreatedBy);
				objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
				objIData.AddParameter(P_ModifiedBy, this.strModifiedBy);
				objIData.AddParameter(P_ModifiedAt, this.dtmModifiedAt);
				objIData.AddParameter(P_Mark1Number, this.intMark1Number);
				objIData.AddParameter(P_Mark2Number, this.intMark2Number);
				objIData.AddParameter(P_SBSSameID, this.intSBSSameID);
				objIData.AddParameter(P_TheoryUnitText, this.intTheoryUnitText);
				objIData.AddParameter(P_PracticeUnitText, this.intPracticeUnitText);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_SpecialBranch_Subject", objEx);
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
		/// Delete : SIM_SpecialBranch_Subject
		/// Xóa dữ liệu
		/// Store: SIM_SpecialBranch_Subject_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_SpecialBranch_Subject_DELETE");
				objIData.AddParameter(P_SpecialBranchSubjectID, this.intSpecialBranchSubjectID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_SpecialBranch_Subject", objEx);
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
		/// Store: SIM_SpecialBranch_Subject_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(int? intSpecialBranchSubjectID)
		{
			this.intSpecialBranchSubjectID = intSpecialBranchSubjectID;
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

		public SIM_SpecialBranch_Subject()
		{
		}
		public SIM_SpecialBranch_Subject(int? intSpecialBranchSubjectID)
		{
			this.intSpecialBranchSubjectID = intSpecialBranchSubjectID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_SpecialBranchSubjectID = "@" + C_SpecialBranchSubjectID;
		public const String P_Semester = "@" + C_Semester;
		public const String P_Year = "@" + C_Year;
		public const String P_SpecialBranchID = "@" + C_SpecialBranchID;
		public const String P_TrainingLevelID = "@" + C_TrainingLevelID;
		public const String P_TrainingType = "@" + C_TrainingType;
		public const String P_CourseID = "@" + C_CourseID;
		public const String P_SubjectID = "@" + C_SubjectID;
		public const String P_TheoryQuantity = "@" + C_TheoryQuantity;
		public const String P_PracticeQuantity = "@" + C_PracticeQuantity;
		public const String P_TestQuantity = "@" + C_TestQuantity;
		public const String P_UnitText = "@" + C_UnitText;
		public const String P_ExamWeek = "@" + C_ExamWeek;
		public const String P_TheoryFee = "@" + C_TheoryFee;
		public const String P_PracticeFee = "@" + C_PracticeFee;
		public const String P_TotalFee = "@" + C_TotalFee;
		public const String P_CreatedBy = "@" + C_CreatedBy;
		public const String P_CreatedAt = "@" + C_CreatedAt;
		public const String P_ModifiedBy = "@" + C_ModifiedBy;
		public const String P_ModifiedAt = "@" + C_ModifiedAt;
		public const String P_Mark1Number = "@" + C_Mark1Number;
		public const String P_Mark2Number = "@" + C_Mark2Number;
		public const String P_SBSSameID = "@" + C_SBSSameID;
		public const String P_TheoryUnitText = "@" + C_TheoryUnitText;
		public const String P_PracticeUnitText = "@" + C_PracticeUnitText;

		#endregion //Parameter names

		#region Column Names

		public const String C_SpecialBranchSubjectID = "SpecialBranchSubjectID";
		public const String C_Semester = "Semester";
		public const String C_Year = "Year";
		public const String C_SpecialBranchID = "SpecialBranchID";
		public const String C_TrainingLevelID = "TrainingLevelID";
		public const String C_TrainingType = "TrainingType";
		public const String C_CourseID = "CourseID";
		public const String C_SubjectID = "SubjectID";
		public const String C_TheoryQuantity = "TheoryQuantity";
		public const String C_PracticeQuantity = "PracticeQuantity";
		public const String C_TestQuantity = "TestQuantity";
		public const String C_UnitText = "UnitText";
		public const String C_ExamWeek = "ExamWeek";
		public const String C_TheoryFee = "TheoryFee";
		public const String C_PracticeFee = "PracticeFee";
		public const String C_TotalFee = "TotalFee";
		public const String C_CreatedBy = "CreatedBy";
		public const String C_CreatedAt = "CreatedAt";
		public const String C_ModifiedBy = "ModifiedBy";
		public const String C_ModifiedAt = "ModifiedAt";
		public const String C_Mark1Number = "Mark1Number";
		public const String C_Mark2Number = "Mark2Number";
		public const String C_SBSSameID = "SBSSameID";
		public const String C_TheoryUnitText = "TheoryUnitText";
		public const String C_PracticeUnitText = "PracticeUnitText";

		#endregion //Column names

		#endregion Variable Static		
	}
}
