
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
	public partial class SIM_Scholarship
	{	
		#region Member Variables

		private long? lngScholarshipID = null;
		private long? lngStudentID = null;
		private int? intYearID = null;//Mã niên học
		private int? intSemester = null;//Học kì
		private string strScholarshipLevel = null;
		private int? intScholarshipMonth = null;
        private decimal? decScholarshipMoney = null;
		private string strDescription = null;
		private bool bolIsActived = false;//Đã có giá trị quyết định
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
		/// ScholarshipID
		/// 
		/// </summary>
		public long? ScholarshipID
		{
			get { return  lngScholarshipID; }
			set { lngScholarshipID = value; }
		}
		/// <summary>
		/// StudentID
		/// 
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
		/// Semester
		/// Học kì
		/// </summary>
		public int? Semester
		{
			get { return  intSemester; }
			set { intSemester = value; }
		}
		/// <summary>
		/// ScholarshipLevel
		/// 
		/// </summary>
		public string ScholarshipLevel
		{
			get { return  strScholarshipLevel; }
			set { strScholarshipLevel = value; }
		}
		/// <summary>
		/// ScholarshipMonth
		/// 
		/// </summary>
		public int? ScholarshipMonth
		{
			get { return  intScholarshipMonth; }
			set { intScholarshipMonth = value; }
		}
		/// <summary>
		/// ScholarshipMoney
		/// 
		/// </summary>
		public decimal? ScholarshipMoney
		{
            get { return decScholarshipMoney; }
			set { decScholarshipMoney = value; }
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
		/// IsActived
		/// Đã có giá trị quyết định
		/// </summary>
		public bool IsActived
		{
			get { return  bolIsActived; }
			set { bolIsActived = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_ScholarshipID.ToUpper()) && !Convert.IsDBNull(reader[C_ScholarshipID])) this.lngScholarshipID = Convert.ToInt64(reader[C_ScholarshipID]);
					if (reader.GetName(i).ToUpper().Equals(C_StudentID.ToUpper()) && !Convert.IsDBNull(reader[C_StudentID])) this.lngStudentID = Convert.ToInt64(reader[C_StudentID]);
					if (reader.GetName(i).ToUpper().Equals(C_YearID.ToUpper()) && !Convert.IsDBNull(reader[C_YearID])) this.intYearID = Convert.ToInt32(reader[C_YearID]);
					if (reader.GetName(i).ToUpper().Equals(C_Semester.ToUpper()) && !Convert.IsDBNull(reader[C_Semester])) this.intSemester = Convert.ToInt32(reader[C_Semester]);
					if (reader.GetName(i).ToUpper().Equals(C_ScholarshipLevel.ToUpper()) && !Convert.IsDBNull(reader[C_ScholarshipLevel])) this.strScholarshipLevel = Convert.ToString(reader[C_ScholarshipLevel]);
					if (reader.GetName(i).ToUpper().Equals(C_ScholarshipMonth.ToUpper()) && !Convert.IsDBNull(reader[C_ScholarshipMonth])) this.intScholarshipMonth = Convert.ToInt32(reader[C_ScholarshipMonth]);
                    if (reader.GetName(i).ToUpper().Equals(C_ScholarshipMoney.ToUpper()) && !Convert.IsDBNull(reader[C_ScholarshipMoney])) this.decScholarshipMoney = Convert.ToDecimal(reader[C_ScholarshipMoney]);
					if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
					if (reader.GetName(i).ToUpper().Equals(C_IsActived.ToUpper()) && !Convert.IsDBNull(reader[C_IsActived])) this.bolIsActived = Convert.ToBoolean(reader[C_IsActived]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(reader[C_UpdatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(reader[C_UpdatedUser]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_Scholarship", objEx);
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
				if (!Convert.IsDBNull(drw[C_ScholarshipID])) this.lngScholarshipID = Convert.ToInt64(drw[C_ScholarshipID]);
				if (!Convert.IsDBNull(drw[C_StudentID])) this.lngStudentID = Convert.ToInt64(drw[C_StudentID]);
				if (!Convert.IsDBNull(drw[C_YearID])) this.intYearID = Convert.ToInt32(drw[C_YearID]);
				if (!Convert.IsDBNull(drw[C_Semester])) this.intSemester = Convert.ToInt32(drw[C_Semester]);
				if (!Convert.IsDBNull(drw[C_ScholarshipLevel])) this.strScholarshipLevel = Convert.ToString(drw[C_ScholarshipLevel]);
				if (!Convert.IsDBNull(drw[C_ScholarshipMonth])) this.intScholarshipMonth = Convert.ToInt32(drw[C_ScholarshipMonth]);
				if (!Convert.IsDBNull(drw[C_ScholarshipMoney])) this.decScholarshipMoney = Convert.ToDecimal(drw[C_ScholarshipMoney]);
				if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
				if (!Convert.IsDBNull(drw[C_IsActived])) this.bolIsActived = Convert.ToBoolean(drw[C_IsActived]);
				if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
				if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
				if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
				if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_Scholarship", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_Scholarship_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Scholarship_GET");
				objIData.AddParameter(P_ScholarshipID, this.lngScholarshipID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_Scholarship", objEx);
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
		/// Store: SIM_Scholarship_GET 
		///</summary>
		/// <returns> SIM_Scholarship </returns>
		public SIM_Scholarship Get(long? lngScholarshipID)
		{
			SIM_Scholarship obj = new SIM_Scholarship();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.ScholarshipID = lngScholarshipID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_Scholarship
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Scholarship", objEx);
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
		/// Search : SIM_Scholarship
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Scholarship", objEx);
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
		/// Search : SIM_Scholarship
		/// Lấy hết dữ liệu
		/// Store: SIM_Scholarship_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_Scholarship_GETALL");
		}

		///<summary>
		/// Search : SIM_Scholarship
		/// Tìm dữ liệu
		/// Store: SIM_Scholarship_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_Scholarship_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_Scholarship
		/// Thêm dữ liệu
		/// Store: SIM_Scholarship_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Scholarship_ADD");
				objIData.AddParameter(P_StudentID, this.lngStudentID);
				objIData.AddParameter(P_YearID, this.intYearID);
				objIData.AddParameter(P_Semester, this.intSemester);
				objIData.AddParameter(P_ScholarshipLevel, this.strScholarshipLevel);
				objIData.AddParameter(P_ScholarshipMonth, this.intScholarshipMonth);
				objIData.AddParameter(P_ScholarshipMoney, this.decScholarshipMoney);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_IsActived, this.bolIsActived);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				this.lngScholarshipID = Convert.ToInt32(objIData.ExecStoreToString());
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_Scholarship", objEx);
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
		/// Update : SIM_Scholarship
		/// Cập nhật dữ liệu
		/// Store: SIM_Scholarship_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Scholarship_EDIT");
				objIData.AddParameter(P_ScholarshipID, this.lngScholarshipID);
				objIData.AddParameter(P_StudentID, this.lngStudentID);
				objIData.AddParameter(P_YearID, this.intYearID);
				objIData.AddParameter(P_Semester, this.intSemester);
				objIData.AddParameter(P_ScholarshipLevel, this.strScholarshipLevel);
				objIData.AddParameter(P_ScholarshipMonth, this.intScholarshipMonth);
				objIData.AddParameter(P_ScholarshipMoney, this.decScholarshipMoney);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_IsActived, this.bolIsActived);
				objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_Scholarship", objEx);
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
		/// Delete : SIM_Scholarship
		/// Xóa dữ liệu
		/// Store: SIM_Scholarship_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Scholarship_DELETE");
				objIData.AddParameter(P_ScholarshipID, this.lngScholarshipID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_Scholarship", objEx);
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
		/// Store: SIM_Scholarship_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(long? lngScholarshipID)
		{
			this.lngScholarshipID = lngScholarshipID;
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

		public SIM_Scholarship()
		{
		}
		public SIM_Scholarship(long? lngScholarshipID)
		{
			this.lngScholarshipID = lngScholarshipID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_ScholarshipID = "@" + C_ScholarshipID;
		public const String P_StudentID = "@" + C_StudentID;
		public const String P_YearID = "@" + C_YearID;
		public const String P_Semester = "@" + C_Semester;
		public const String P_ScholarshipLevel = "@" + C_ScholarshipLevel;
		public const String P_ScholarshipMonth = "@" + C_ScholarshipMonth;
		public const String P_ScholarshipMoney = "@" + C_ScholarshipMoney;
		public const String P_Description = "@" + C_Description;
		public const String P_IsActived = "@" + C_IsActived;
		public const String P_CreatedDate = "@" + C_CreatedDate;
		public const String P_CreatedUser = "@" + C_CreatedUser;
		public const String P_UpdatedDate = "@" + C_UpdatedDate;
		public const String P_UpdatedUser = "@" + C_UpdatedUser;

		#endregion //Parameter names

		#region Column Names

		public const String C_ScholarshipID = "ScholarshipID";
		public const String C_StudentID = "StudentID";
		public const String C_YearID = "YearID";
		public const String C_Semester = "Semester";
		public const String C_ScholarshipLevel = "ScholarshipLevel";
		public const String C_ScholarshipMonth = "ScholarshipMonth";
		public const String C_ScholarshipMoney = "ScholarshipMoney";
		public const String C_Description = "Description";
		public const String C_IsActived = "IsActived";
		public const String C_CreatedDate = "CreatedDate";
		public const String C_CreatedUser = "CreatedUser";
		public const String C_UpdatedDate = "UpdatedDate";
		public const String C_UpdatedUser = "UpdatedUser";

		#endregion //Column names

		#endregion Variable Static		
	}
}
