
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
	/// Created date 	: 12/19/2016 
	/// Description 
	/// </summary>	
	public partial class SIM_SummaryLearningMark
	{	
		#region Member Variables

		private long? lngStudentID = null;//Mã sinh viên
		private int? intYearID = null;//Mã niên học
		private double? dblSummary = null;//TBC năm
		private string strLearningLevel = null;//Xếp loại học tập cả năm
		private int? intFailedSubjectCount = null;//Tổng môn nợ toàn khoá
		private int? intFailedUnitTextSum = null;//Tổng đvht nợ toàn khoá
		private int? intUnitTextSum = null;//Tổng đvht học
		private double? dblSummary1 = null;//TBC học kì 1
		private string strLearningLevel1 = null;//Xếp loại học tập hk 1
		private int? intFailedSubjectCount1 = null;//Tổng môn nợ toàn khoá
		private int? intFailedUnitTextSum1 = null;//Tổng đvht nợ toàn khoá
		private int? intUnitTextSum1 = null;//Tổng đvht học
		private string strStudentLevel1 = null;//Danh hiệu học sinh, học lực và hạnh kiểm xếp lại thành (lưu từ form xét học bổng)
		private double? dblSummary2 = null;//TBC học kì 2
		private string strLearningLevel2 = null;//Xếp loại học tập hk 2
		private int? intFailedSubjectCount2 = null;//Tổng môn nợ toàn khoá
		private int? intFailedUnitTextSum2 = null;//Tổng đvht nợ toàn khoá
		private int? intUnitTextSum2 = null;//Tổng đvht học
		private string strStudentLevel2 = null;//Danh hiệu học sinh, học lực và hạnh kiểm xếp lại thành (lưu từ form xét học bổng)
		private DateTime? dtmCreatedDate = null;//Ngày tạo
		private string strCreatedUser = null;//Người tạo
		private DateTime? dtmUpdatedDate = null;//Ngày cập nhật cuối
		private string strUpdatedUser = null;//Người cập nhật cuối
		private IData objIData = null;
		private bool bolIsExistIData = false;
		private Exception objErrorException = null;

		#endregion

		#region Properties 

		/// <summary>
		/// StudentID
		/// Mã sinh viên
		/// </summary>
		public long? StudentID
		{
			get { return  lngStudentID; }
			set { lngStudentID = value; }
		}
		/// <summary>
		/// YearID
		/// Mã niên học
		/// </summary>
		public int? YearID
		{
			get { return  intYearID; }
			set { intYearID = value; }
		}
		/// <summary>
		/// Summary
		/// TBC năm
		/// </summary>
		public double? Summary
		{
			get { return  dblSummary; }
			set { dblSummary = value; }
		}
		/// <summary>
		/// LearningLevel
		/// Xếp loại học tập cả năm
		/// </summary>
		public string LearningLevel
		{
			get { return  strLearningLevel; }
			set { strLearningLevel = value; }
		}
		/// <summary>
		/// FailedSubjectCount
		/// Tổng môn nợ toàn khoá
		/// </summary>
		public int? FailedSubjectCount
		{
			get { return  intFailedSubjectCount; }
			set { intFailedSubjectCount = value; }
		}
		/// <summary>
		/// FailedUnitTextSum
		/// Tổng đvht nợ toàn khoá
		/// </summary>
		public int? FailedUnitTextSum
		{
			get { return  intFailedUnitTextSum; }
			set { intFailedUnitTextSum = value; }
		}
		/// <summary>
		/// UnitTextSum
		/// Tổng đvht học
		/// </summary>
		public int? UnitTextSum
		{
			get { return  intUnitTextSum; }
			set { intUnitTextSum = value; }
		}
		/// <summary>
		/// Summary1
		/// TBC học kì 1
		/// </summary>
		public double? Summary1
		{
			get { return  dblSummary1; }
			set { dblSummary1 = value; }
		}
		/// <summary>
		/// LearningLevel1
		/// Xếp loại học tập hk 1
		/// </summary>
		public string LearningLevel1
		{
			get { return  strLearningLevel1; }
			set { strLearningLevel1 = value; }
		}
		/// <summary>
		/// FailedSubjectCount1
		/// Tổng môn nợ toàn khoá
		/// </summary>
		public int? FailedSubjectCount1
		{
			get { return  intFailedSubjectCount1; }
			set { intFailedSubjectCount1 = value; }
		}
		/// <summary>
		/// FailedUnitTextSum1
		/// Tổng đvht nợ toàn khoá
		/// </summary>
		public int? FailedUnitTextSum1
		{
			get { return  intFailedUnitTextSum1; }
			set { intFailedUnitTextSum1 = value; }
		}
		/// <summary>
		/// UnitTextSum1
		/// Tổng đvht học
		/// </summary>
		public int? UnitTextSum1
		{
			get { return  intUnitTextSum1; }
			set { intUnitTextSum1 = value; }
		}
		/// <summary>
		/// StudentLevel1
		/// Danh hiệu học sinh, học lực và hạnh kiểm xếp lại thành (lưu từ form xét học bổng)
		/// </summary>
		public string StudentLevel1
		{
			get { return  strStudentLevel1; }
			set { strStudentLevel1 = value; }
		}
		/// <summary>
		/// Summary2
		/// TBC học kì 2
		/// </summary>
		public double? Summary2
		{
			get { return  dblSummary2; }
			set { dblSummary2 = value; }
		}
		/// <summary>
		/// LearningLevel2
		/// Xếp loại học tập hk 2
		/// </summary>
		public string LearningLevel2
		{
			get { return  strLearningLevel2; }
			set { strLearningLevel2 = value; }
		}
		/// <summary>
		/// FailedSubjectCount2
		/// Tổng môn nợ toàn khoá
		/// </summary>
		public int? FailedSubjectCount2
		{
			get { return  intFailedSubjectCount2; }
			set { intFailedSubjectCount2 = value; }
		}
		/// <summary>
		/// FailedUnitTextSum2
		/// Tổng đvht nợ toàn khoá
		/// </summary>
		public int? FailedUnitTextSum2
		{
			get { return  intFailedUnitTextSum2; }
			set { intFailedUnitTextSum2 = value; }
		}
		/// <summary>
		/// UnitTextSum2
		/// Tổng đvht học
		/// </summary>
		public int? UnitTextSum2
		{
			get { return  intUnitTextSum2; }
			set { intUnitTextSum2 = value; }
		}
		/// <summary>
		/// StudentLevel2
		/// Danh hiệu học sinh, học lực và hạnh kiểm xếp lại thành (lưu từ form xét học bổng)
		/// </summary>
		public string StudentLevel2
		{
			get { return  strStudentLevel2; }
			set { strStudentLevel2 = value; }
		}
		/// <summary>
		/// CreatedDate
		/// Ngày tạo
		/// </summary>
		public DateTime? CreatedDate
		{
			get { return  dtmCreatedDate; }
			set { dtmCreatedDate = value; }
		}
		/// <summary>
		/// CreatedUser
		/// Người tạo
		/// </summary>
		public string CreatedUser
		{
			get { return  strCreatedUser; }
			set { strCreatedUser = value; }
		}
		/// <summary>
		/// UpdatedDate
		/// Ngày cập nhật cuối
		/// </summary>
		public DateTime? UpdatedDate
		{
			get { return  dtmUpdatedDate; }
			set { dtmUpdatedDate = value; }
		}
		/// <summary>
		/// UpdatedUser
		/// Người cập nhật cuối
		/// </summary>
		public string UpdatedUser
		{
			get { return  strUpdatedUser; }
			set { strUpdatedUser = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_YearID.ToUpper()) && !Convert.IsDBNull(reader[C_YearID])) this.intYearID = Convert.ToInt32(reader[C_YearID]);
					if (reader.GetName(i).ToUpper().Equals(C_Summary.ToUpper()) && !Convert.IsDBNull(reader[C_Summary])) this.dblSummary = Convert.ToDouble(reader[C_Summary]);
					if (reader.GetName(i).ToUpper().Equals(C_LearningLevel.ToUpper()) && !Convert.IsDBNull(reader[C_LearningLevel])) this.strLearningLevel = Convert.ToString(reader[C_LearningLevel]);
					if (reader.GetName(i).ToUpper().Equals(C_FailedSubjectCount.ToUpper()) && !Convert.IsDBNull(reader[C_FailedSubjectCount])) this.intFailedSubjectCount = Convert.ToInt32(reader[C_FailedSubjectCount]);
					if (reader.GetName(i).ToUpper().Equals(C_FailedUnitTextSum.ToUpper()) && !Convert.IsDBNull(reader[C_FailedUnitTextSum])) this.intFailedUnitTextSum = Convert.ToInt32(reader[C_FailedUnitTextSum]);
					if (reader.GetName(i).ToUpper().Equals(C_UnitTextSum.ToUpper()) && !Convert.IsDBNull(reader[C_UnitTextSum])) this.intUnitTextSum = Convert.ToInt32(reader[C_UnitTextSum]);
					if (reader.GetName(i).ToUpper().Equals(C_Summary1.ToUpper()) && !Convert.IsDBNull(reader[C_Summary1])) this.dblSummary1 = Convert.ToDouble(reader[C_Summary1]);
					if (reader.GetName(i).ToUpper().Equals(C_LearningLevel1.ToUpper()) && !Convert.IsDBNull(reader[C_LearningLevel1])) this.strLearningLevel1 = Convert.ToString(reader[C_LearningLevel1]);
					if (reader.GetName(i).ToUpper().Equals(C_FailedSubjectCount1.ToUpper()) && !Convert.IsDBNull(reader[C_FailedSubjectCount1])) this.intFailedSubjectCount1 = Convert.ToInt32(reader[C_FailedSubjectCount1]);
					if (reader.GetName(i).ToUpper().Equals(C_FailedUnitTextSum1.ToUpper()) && !Convert.IsDBNull(reader[C_FailedUnitTextSum1])) this.intFailedUnitTextSum1 = Convert.ToInt32(reader[C_FailedUnitTextSum1]);
					if (reader.GetName(i).ToUpper().Equals(C_UnitTextSum1.ToUpper()) && !Convert.IsDBNull(reader[C_UnitTextSum1])) this.intUnitTextSum1 = Convert.ToInt32(reader[C_UnitTextSum1]);
					if (reader.GetName(i).ToUpper().Equals(C_StudentLevel1.ToUpper()) && !Convert.IsDBNull(reader[C_StudentLevel1])) this.strStudentLevel1 = Convert.ToString(reader[C_StudentLevel1]);
					if (reader.GetName(i).ToUpper().Equals(C_Summary2.ToUpper()) && !Convert.IsDBNull(reader[C_Summary2])) this.dblSummary2 = Convert.ToDouble(reader[C_Summary2]);
					if (reader.GetName(i).ToUpper().Equals(C_LearningLevel2.ToUpper()) && !Convert.IsDBNull(reader[C_LearningLevel2])) this.strLearningLevel2 = Convert.ToString(reader[C_LearningLevel2]);
					if (reader.GetName(i).ToUpper().Equals(C_FailedSubjectCount2.ToUpper()) && !Convert.IsDBNull(reader[C_FailedSubjectCount2])) this.intFailedSubjectCount2 = Convert.ToInt32(reader[C_FailedSubjectCount2]);
					if (reader.GetName(i).ToUpper().Equals(C_FailedUnitTextSum2.ToUpper()) && !Convert.IsDBNull(reader[C_FailedUnitTextSum2])) this.intFailedUnitTextSum2 = Convert.ToInt32(reader[C_FailedUnitTextSum2]);
					if (reader.GetName(i).ToUpper().Equals(C_UnitTextSum2.ToUpper()) && !Convert.IsDBNull(reader[C_UnitTextSum2])) this.intUnitTextSum2 = Convert.ToInt32(reader[C_UnitTextSum2]);
					if (reader.GetName(i).ToUpper().Equals(C_StudentLevel2.ToUpper()) && !Convert.IsDBNull(reader[C_StudentLevel2])) this.strStudentLevel2 = Convert.ToString(reader[C_StudentLevel2]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(reader[C_UpdatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(reader[C_UpdatedUser]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_SummaryLearningMark", objEx);
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
				if (!Convert.IsDBNull(drw[C_YearID])) this.intYearID = Convert.ToInt32(drw[C_YearID]);
				if (!Convert.IsDBNull(drw[C_Summary])) this.dblSummary = Convert.ToDouble(drw[C_Summary]);
				if (!Convert.IsDBNull(drw[C_LearningLevel])) this.strLearningLevel = Convert.ToString(drw[C_LearningLevel]);
				if (!Convert.IsDBNull(drw[C_FailedSubjectCount])) this.intFailedSubjectCount = Convert.ToInt32(drw[C_FailedSubjectCount]);
				if (!Convert.IsDBNull(drw[C_FailedUnitTextSum])) this.intFailedUnitTextSum = Convert.ToInt32(drw[C_FailedUnitTextSum]);
				if (!Convert.IsDBNull(drw[C_UnitTextSum])) this.intUnitTextSum = Convert.ToInt32(drw[C_UnitTextSum]);
				if (!Convert.IsDBNull(drw[C_Summary1])) this.dblSummary1 = Convert.ToDouble(drw[C_Summary1]);
				if (!Convert.IsDBNull(drw[C_LearningLevel1])) this.strLearningLevel1 = Convert.ToString(drw[C_LearningLevel1]);
				if (!Convert.IsDBNull(drw[C_FailedSubjectCount1])) this.intFailedSubjectCount1 = Convert.ToInt32(drw[C_FailedSubjectCount1]);
				if (!Convert.IsDBNull(drw[C_FailedUnitTextSum1])) this.intFailedUnitTextSum1 = Convert.ToInt32(drw[C_FailedUnitTextSum1]);
				if (!Convert.IsDBNull(drw[C_UnitTextSum1])) this.intUnitTextSum1 = Convert.ToInt32(drw[C_UnitTextSum1]);
				if (!Convert.IsDBNull(drw[C_StudentLevel1])) this.strStudentLevel1 = Convert.ToString(drw[C_StudentLevel1]);
				if (!Convert.IsDBNull(drw[C_Summary2])) this.dblSummary2 = Convert.ToDouble(drw[C_Summary2]);
				if (!Convert.IsDBNull(drw[C_LearningLevel2])) this.strLearningLevel2 = Convert.ToString(drw[C_LearningLevel2]);
				if (!Convert.IsDBNull(drw[C_FailedSubjectCount2])) this.intFailedSubjectCount2 = Convert.ToInt32(drw[C_FailedSubjectCount2]);
				if (!Convert.IsDBNull(drw[C_FailedUnitTextSum2])) this.intFailedUnitTextSum2 = Convert.ToInt32(drw[C_FailedUnitTextSum2]);
				if (!Convert.IsDBNull(drw[C_UnitTextSum2])) this.intUnitTextSum2 = Convert.ToInt32(drw[C_UnitTextSum2]);
				if (!Convert.IsDBNull(drw[C_StudentLevel2])) this.strStudentLevel2 = Convert.ToString(drw[C_StudentLevel2]);
				if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
				if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
				if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
				if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_SummaryLearningMark", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_SummaryLearningMark_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_SummaryLearningMark_GET");
				objIData.AddParameter(P_StudentID, this.lngStudentID);
				objIData.AddParameter(P_YearID, this.intYearID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_SummaryLearningMark", objEx);
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
		/// Store: SIM_SummaryLearningMark_GET 
		///</summary>
		/// <returns> SIM_SummaryLearningMark </returns>
		public SIM_SummaryLearningMark Get(long? lngStudentID, int? intYearID)
		{
			SIM_SummaryLearningMark obj = new SIM_SummaryLearningMark();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.StudentID = lngStudentID;
			obj.YearID = intYearID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_SummaryLearningMark
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_SummaryLearningMark", objEx);
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
		/// Search : SIM_SummaryLearningMark
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_SummaryLearningMark", objEx);
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
		/// Search : SIM_SummaryLearningMark
		/// Lấy hết dữ liệu
		/// Store: SIM_SummaryLearningMark_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_SummaryLearningMark_GETALL");
		}

		///<summary>
		/// Search : SIM_SummaryLearningMark
		/// Tìm dữ liệu
		/// Store: SIM_SummaryLearningMark_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_SummaryLearningMark_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_SummaryLearningMark
		/// Thêm dữ liệu
		/// Store: SIM_SummaryLearningMark_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_SummaryLearningMark_ADD");
				objIData.AddParameter(P_StudentID, this.lngStudentID);
				objIData.AddParameter(P_YearID, this.intYearID);
				objIData.AddParameter(P_Summary, this.dblSummary);
				objIData.AddParameter(P_LearningLevel, this.strLearningLevel);
				objIData.AddParameter(P_FailedSubjectCount, this.intFailedSubjectCount);
				objIData.AddParameter(P_FailedUnitTextSum, this.intFailedUnitTextSum);
				objIData.AddParameter(P_UnitTextSum, this.intUnitTextSum);
				objIData.AddParameter(P_Summary1, this.dblSummary1);
				objIData.AddParameter(P_LearningLevel1, this.strLearningLevel1);
				objIData.AddParameter(P_FailedSubjectCount1, this.intFailedSubjectCount1);
				objIData.AddParameter(P_FailedUnitTextSum1, this.intFailedUnitTextSum1);
				objIData.AddParameter(P_UnitTextSum1, this.intUnitTextSum1);
				objIData.AddParameter(P_StudentLevel1, this.strStudentLevel1);
				objIData.AddParameter(P_Summary2, this.dblSummary2);
				objIData.AddParameter(P_LearningLevel2, this.strLearningLevel2);
				objIData.AddParameter(P_FailedSubjectCount2, this.intFailedSubjectCount2);
				objIData.AddParameter(P_FailedUnitTextSum2, this.intFailedUnitTextSum2);
				objIData.AddParameter(P_UnitTextSum2, this.intUnitTextSum2);
				objIData.AddParameter(P_StudentLevel2, this.strStudentLevel2);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_SummaryLearningMark", objEx);
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
		/// Update : SIM_SummaryLearningMark
		/// Cập nhật dữ liệu
		/// Store: SIM_SummaryLearningMark_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_SummaryLearningMark_EDIT");
				objIData.AddParameter(P_StudentID, this.lngStudentID);
				objIData.AddParameter(P_YearID, this.intYearID);
				objIData.AddParameter(P_Summary, this.dblSummary);
				objIData.AddParameter(P_LearningLevel, this.strLearningLevel);
				objIData.AddParameter(P_FailedSubjectCount, this.intFailedSubjectCount);
				objIData.AddParameter(P_FailedUnitTextSum, this.intFailedUnitTextSum);
				objIData.AddParameter(P_UnitTextSum, this.intUnitTextSum);
				objIData.AddParameter(P_Summary1, this.dblSummary1);
				objIData.AddParameter(P_LearningLevel1, this.strLearningLevel1);
				objIData.AddParameter(P_FailedSubjectCount1, this.intFailedSubjectCount1);
				objIData.AddParameter(P_FailedUnitTextSum1, this.intFailedUnitTextSum1);
				objIData.AddParameter(P_UnitTextSum1, this.intUnitTextSum1);
				objIData.AddParameter(P_StudentLevel1, this.strStudentLevel1);
				objIData.AddParameter(P_Summary2, this.dblSummary2);
				objIData.AddParameter(P_LearningLevel2, this.strLearningLevel2);
				objIData.AddParameter(P_FailedSubjectCount2, this.intFailedSubjectCount2);
				objIData.AddParameter(P_FailedUnitTextSum2, this.intFailedUnitTextSum2);
				objIData.AddParameter(P_UnitTextSum2, this.intUnitTextSum2);
				objIData.AddParameter(P_StudentLevel2, this.strStudentLevel2);
				objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_SummaryLearningMark", objEx);
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
		/// Delete : SIM_SummaryLearningMark
		/// Xóa dữ liệu
		/// Store: SIM_SummaryLearningMark_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_SummaryLearningMark_DELETE");
				objIData.AddParameter(P_StudentID, this.lngStudentID);
				objIData.AddParameter(P_YearID, this.intYearID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_SummaryLearningMark", objEx);
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
		/// Store: SIM_SummaryLearningMark_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(long? lngStudentID, int? intYearID)
		{
			this.lngStudentID = lngStudentID;
			this.intYearID = intYearID;
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

		public SIM_SummaryLearningMark()
		{
		}
		public SIM_SummaryLearningMark(long? lngStudentID, int? intYearID)
		{
			this.lngStudentID = lngStudentID;
			this.intYearID = intYearID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_StudentID = "@" + C_StudentID;
		public const String P_YearID = "@" + C_YearID;
		public const String P_Summary = "@" + C_Summary;
		public const String P_LearningLevel = "@" + C_LearningLevel;
		public const String P_FailedSubjectCount = "@" + C_FailedSubjectCount;
		public const String P_FailedUnitTextSum = "@" + C_FailedUnitTextSum;
		public const String P_UnitTextSum = "@" + C_UnitTextSum;
		public const String P_Summary1 = "@" + C_Summary1;
		public const String P_LearningLevel1 = "@" + C_LearningLevel1;
		public const String P_FailedSubjectCount1 = "@" + C_FailedSubjectCount1;
		public const String P_FailedUnitTextSum1 = "@" + C_FailedUnitTextSum1;
		public const String P_UnitTextSum1 = "@" + C_UnitTextSum1;
		public const String P_StudentLevel1 = "@" + C_StudentLevel1;
		public const String P_Summary2 = "@" + C_Summary2;
		public const String P_LearningLevel2 = "@" + C_LearningLevel2;
		public const String P_FailedSubjectCount2 = "@" + C_FailedSubjectCount2;
		public const String P_FailedUnitTextSum2 = "@" + C_FailedUnitTextSum2;
		public const String P_UnitTextSum2 = "@" + C_UnitTextSum2;
		public const String P_StudentLevel2 = "@" + C_StudentLevel2;
		public const String P_CreatedDate = "@" + C_CreatedDate;
		public const String P_CreatedUser = "@" + C_CreatedUser;
		public const String P_UpdatedDate = "@" + C_UpdatedDate;
		public const String P_UpdatedUser = "@" + C_UpdatedUser;

		#endregion //Parameter names

		#region Column Names

		public const String C_StudentID = "StudentID";
		public const String C_YearID = "YearID";
		public const String C_Summary = "Summary";
		public const String C_LearningLevel = "LearningLevel";
		public const String C_FailedSubjectCount = "FailedSubjectCount";
		public const String C_FailedUnitTextSum = "FailedUnitTextSum";
		public const String C_UnitTextSum = "UnitTextSum";
		public const String C_Summary1 = "Summary1";
		public const String C_LearningLevel1 = "LearningLevel1";
		public const String C_FailedSubjectCount1 = "FailedSubjectCount1";
		public const String C_FailedUnitTextSum1 = "FailedUnitTextSum1";
		public const String C_UnitTextSum1 = "UnitTextSum1";
		public const String C_StudentLevel1 = "StudentLevel1";
		public const String C_Summary2 = "Summary2";
		public const String C_LearningLevel2 = "LearningLevel2";
		public const String C_FailedSubjectCount2 = "FailedSubjectCount2";
		public const String C_FailedUnitTextSum2 = "FailedUnitTextSum2";
		public const String C_UnitTextSum2 = "UnitTextSum2";
		public const String C_StudentLevel2 = "StudentLevel2";
		public const String C_CreatedDate = "CreatedDate";
		public const String C_CreatedUser = "CreatedUser";
		public const String C_UpdatedDate = "UpdatedDate";
		public const String C_UpdatedUser = "UpdatedUser";

		#endregion //Column names

		#endregion Variable Static		
	}
}
