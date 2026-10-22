
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
	public partial class SIM_Class_MonthInfo
	{	
		#region Member Variables

		private string strClassID = null;//Mã lớp
		private DateTime? dtmMonth = null;//Tháng
		private int? intYearID = null;//Mã niên học
		private int? intSemester = null;//Học kỳ: 1, 2
		private int? intStudentCountHead = null;//Sỉ số đầu tháng
		private int? intStudentCountDetail = null;//Sỉ số cuối tháng
		private int? intLearningSessionGood = null;//Số tiết học tốt
		private int? intNoPermissionQuantity = null;//Số lượt vắng không phép
		private int? intLevelOrder = null;//Xếp hạng thi đua của tháng
		private string strDescription = null;
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
		/// ClassID
		/// Mã lớp
		/// </summary>
		public string ClassID
		{
			get { return  strClassID; }
			set { strClassID = value; }
		}
		/// <summary>
		/// Month
		/// Tháng
		/// </summary>
		public DateTime? Month
		{
			get { return  dtmMonth; }
			set { dtmMonth = value; }
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
		/// Học kỳ: 1, 2
		/// </summary>
		public int? Semester
		{
			get { return  intSemester; }
			set { intSemester = value; }
		}
		/// <summary>
		/// StudentCountHead
		/// Sỉ số đầu tháng
		/// </summary>
		public int? StudentCountHead
		{
			get { return  intStudentCountHead; }
			set { intStudentCountHead = value; }
		}
		/// <summary>
		/// StudentCountDetail
		/// Sỉ số cuối tháng
		/// </summary>
		public int? StudentCountDetail
		{
			get { return  intStudentCountDetail; }
			set { intStudentCountDetail = value; }
		}
		/// <summary>
		/// LearningSessionGood
		/// Số tiết học tốt
		/// </summary>
		public int? LearningSessionGood
		{
			get { return  intLearningSessionGood; }
			set { intLearningSessionGood = value; }
		}
		/// <summary>
		/// NoPermissionQuantity
		/// Số lượt vắng không phép
		/// </summary>
		public int? NoPermissionQuantity
		{
			get { return  intNoPermissionQuantity; }
			set { intNoPermissionQuantity = value; }
		}
		/// <summary>
		/// LevelOrder
		/// Xếp hạng thi đua của tháng
		/// </summary>
		public int? LevelOrder
		{
			get { return  intLevelOrder; }
			set { intLevelOrder = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_ClassID.ToUpper()) && !Convert.IsDBNull(reader[C_ClassID])) this.strClassID = Convert.ToString(reader[C_ClassID]);
					if (reader.GetName(i).ToUpper().Equals(C_Month.ToUpper()) && !Convert.IsDBNull(reader[C_Month])) this.dtmMonth = Convert.ToDateTime(reader[C_Month]);
					if (reader.GetName(i).ToUpper().Equals(C_YearID.ToUpper()) && !Convert.IsDBNull(reader[C_YearID])) this.intYearID = Convert.ToInt32(reader[C_YearID]);
					if (reader.GetName(i).ToUpper().Equals(C_Semester.ToUpper()) && !Convert.IsDBNull(reader[C_Semester])) this.intSemester = Convert.ToInt32(reader[C_Semester]);
					if (reader.GetName(i).ToUpper().Equals(C_StudentCountHead.ToUpper()) && !Convert.IsDBNull(reader[C_StudentCountHead])) this.intStudentCountHead = Convert.ToInt32(reader[C_StudentCountHead]);
					if (reader.GetName(i).ToUpper().Equals(C_StudentCountDetail.ToUpper()) && !Convert.IsDBNull(reader[C_StudentCountDetail])) this.intStudentCountDetail = Convert.ToInt32(reader[C_StudentCountDetail]);
					if (reader.GetName(i).ToUpper().Equals(C_LearningSessionGood.ToUpper()) && !Convert.IsDBNull(reader[C_LearningSessionGood])) this.intLearningSessionGood = Convert.ToInt32(reader[C_LearningSessionGood]);
					if (reader.GetName(i).ToUpper().Equals(C_NoPermissionQuantity.ToUpper()) && !Convert.IsDBNull(reader[C_NoPermissionQuantity])) this.intNoPermissionQuantity = Convert.ToInt32(reader[C_NoPermissionQuantity]);
					if (reader.GetName(i).ToUpper().Equals(C_LevelOrder.ToUpper()) && !Convert.IsDBNull(reader[C_LevelOrder])) this.intLevelOrder = Convert.ToInt32(reader[C_LevelOrder]);
					if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(reader[C_UpdatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(reader[C_UpdatedUser]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_Class_MonthInfo", objEx);
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
				if (!Convert.IsDBNull(drw[C_Month])) this.dtmMonth = Convert.ToDateTime(drw[C_Month]);
				if (!Convert.IsDBNull(drw[C_YearID])) this.intYearID = Convert.ToInt32(drw[C_YearID]);
				if (!Convert.IsDBNull(drw[C_Semester])) this.intSemester = Convert.ToInt32(drw[C_Semester]);
				if (!Convert.IsDBNull(drw[C_StudentCountHead])) this.intStudentCountHead = Convert.ToInt32(drw[C_StudentCountHead]);
				if (!Convert.IsDBNull(drw[C_StudentCountDetail])) this.intStudentCountDetail = Convert.ToInt32(drw[C_StudentCountDetail]);
				if (!Convert.IsDBNull(drw[C_LearningSessionGood])) this.intLearningSessionGood = Convert.ToInt32(drw[C_LearningSessionGood]);
				if (!Convert.IsDBNull(drw[C_NoPermissionQuantity])) this.intNoPermissionQuantity = Convert.ToInt32(drw[C_NoPermissionQuantity]);
				if (!Convert.IsDBNull(drw[C_LevelOrder])) this.intLevelOrder = Convert.ToInt32(drw[C_LevelOrder]);
				if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
				if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
				if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
				if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
				if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_Class_MonthInfo", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_Class_MonthInfo_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Class_MonthInfo_GET");
				objIData.AddParameter(P_ClassID, this.strClassID);
				objIData.AddParameter(P_Month, this.dtmMonth);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_Class_MonthInfo", objEx);
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
		/// Store: SIM_Class_MonthInfo_GET 
		///</summary>
		/// <returns> SIM_Class_MonthInfo </returns>
		public SIM_Class_MonthInfo Get(string strClassID, DateTime? dtmMonth)
		{
			SIM_Class_MonthInfo obj = new SIM_Class_MonthInfo();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.ClassID = strClassID;
			obj.Month = dtmMonth;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_Class_MonthInfo
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Class_MonthInfo", objEx);
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
		/// Search : SIM_Class_MonthInfo
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Class_MonthInfo", objEx);
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
		/// Search : SIM_Class_MonthInfo
		/// Lấy hết dữ liệu
		/// Store: SIM_Class_MonthInfo_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_Class_MonthInfo_GETALL");
		}

		///<summary>
		/// Search : SIM_Class_MonthInfo
		/// Tìm dữ liệu
		/// Store: SIM_Class_MonthInfo_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_Class_MonthInfo_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_Class_MonthInfo
		/// Thêm dữ liệu
		/// Store: SIM_Class_MonthInfo_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Class_MonthInfo_ADD");
				objIData.AddParameter(P_ClassID, this.strClassID);
				objIData.AddParameter(P_Month, this.dtmMonth);
				objIData.AddParameter(P_YearID, this.intYearID);
				objIData.AddParameter(P_Semester, this.intSemester);
				objIData.AddParameter(P_StudentCountHead, this.intStudentCountHead);
				objIData.AddParameter(P_StudentCountDetail, this.intStudentCountDetail);
				objIData.AddParameter(P_LearningSessionGood, this.intLearningSessionGood);
				objIData.AddParameter(P_NoPermissionQuantity, this.intNoPermissionQuantity);
				objIData.AddParameter(P_LevelOrder, this.intLevelOrder);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_Class_MonthInfo", objEx);
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
		/// Update : SIM_Class_MonthInfo
		/// Cập nhật dữ liệu
		/// Store: SIM_Class_MonthInfo_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Class_MonthInfo_EDIT");
				objIData.AddParameter(P_ClassID, this.strClassID);
				objIData.AddParameter(P_Month, this.dtmMonth);
				objIData.AddParameter(P_YearID, this.intYearID);
				objIData.AddParameter(P_Semester, this.intSemester);
				objIData.AddParameter(P_StudentCountHead, this.intStudentCountHead);
				objIData.AddParameter(P_StudentCountDetail, this.intStudentCountDetail);
				objIData.AddParameter(P_LearningSessionGood, this.intLearningSessionGood);
				objIData.AddParameter(P_NoPermissionQuantity, this.intNoPermissionQuantity);
				objIData.AddParameter(P_LevelOrder, this.intLevelOrder);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_Class_MonthInfo", objEx);
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
		/// Delete : SIM_Class_MonthInfo
		/// Xóa dữ liệu
		/// Store: SIM_Class_MonthInfo_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Class_MonthInfo_DELETE");
				objIData.AddParameter(P_ClassID, this.strClassID);
				objIData.AddParameter(P_Month, this.dtmMonth);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_Class_MonthInfo", objEx);
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
		/// Store: SIM_Class_MonthInfo_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(string strClassID, DateTime? dtmMonth)
		{
			this.strClassID = strClassID;
			this.dtmMonth = dtmMonth;
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

		public SIM_Class_MonthInfo()
		{
		}
		public SIM_Class_MonthInfo(string strClassID, DateTime? dtmMonth)
		{
			this.strClassID = strClassID;
			this.dtmMonth = dtmMonth;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_ClassID = "@" + C_ClassID;
		public const String P_Month = "@" + C_Month;
		public const String P_YearID = "@" + C_YearID;
		public const String P_Semester = "@" + C_Semester;
		public const String P_StudentCountHead = "@" + C_StudentCountHead;
		public const String P_StudentCountDetail = "@" + C_StudentCountDetail;
		public const String P_LearningSessionGood = "@" + C_LearningSessionGood;
		public const String P_NoPermissionQuantity = "@" + C_NoPermissionQuantity;
		public const String P_LevelOrder = "@" + C_LevelOrder;
		public const String P_Description = "@" + C_Description;
		public const String P_CreatedDate = "@" + C_CreatedDate;
		public const String P_CreatedUser = "@" + C_CreatedUser;
		public const String P_UpdatedDate = "@" + C_UpdatedDate;
		public const String P_UpdatedUser = "@" + C_UpdatedUser;

		#endregion //Parameter names

		#region Column Names

		public const String C_ClassID = "ClassID";
		public const String C_Month = "Month";
		public const String C_YearID = "YearID";
		public const String C_Semester = "Semester";
		public const String C_StudentCountHead = "StudentCountHead";
		public const String C_StudentCountDetail = "StudentCountDetail";
		public const String C_LearningSessionGood = "LearningSessionGood";
		public const String C_NoPermissionQuantity = "NoPermissionQuantity";
		public const String C_LevelOrder = "LevelOrder";
		public const String C_Description = "Description";
		public const String C_CreatedDate = "CreatedDate";
		public const String C_CreatedUser = "CreatedUser";
		public const String C_UpdatedDate = "UpdatedDate";
		public const String C_UpdatedUser = "UpdatedUser";

		#endregion //Column names

		#endregion Variable Static		
	}
}
