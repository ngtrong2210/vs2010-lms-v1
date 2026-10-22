
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
	public partial class SIM_SummaryPlan
	{	
		#region Member Variables

		private int? intYearID = null;//Niên học
		private string strClassID = null;//Mã Lớp
		private int? intFromWeek = null;//Từ tuần nào của niên học
		private int? intToWeek = null;//Đến tuần nào của niên học
		private int? intPlanStatusID = null;//Trạng thái là gì: 0: Chưa xác định, 1: Học kì một, 2: Học kì 2, 3: Quân sự,  4: Thực tập môn, 5: Thi hết môn, 6: Thi học kỳ I, 7: Thi học kì II,  8: Thực tập tốt nghiệp, 9: Đồ án tốt nghiệp,10: Nghỉ tết, 11: Nghỉ hè,....
		private string strCreatedBy = null;
		private DateTime? dtmCreatedAt = null;//Ngày tạo
		private string strModifiedBy = null;//Người sửa
		private DateTime? dtmModifiedAt = null;//Ngày sửa
		private IData objIData = null;
		private bool bolIsExistIData = false;
		private Exception objErrorException = null;

		#endregion

		#region Properties 

		/// <summary>
		/// YearID
		/// Niên học
		/// </summary>
		public int? YearID
		{
			get { return  intYearID; }
			set { intYearID = value; }
		}
		/// <summary>
		/// ClassID
		/// Mã Lớp
		/// </summary>
		public string ClassID
		{
			get { return  strClassID; }
			set { strClassID = value; }
		}
		/// <summary>
		/// FromWeek
		/// Từ tuần nào của niên học
		/// </summary>
		public int? FromWeek
		{
			get { return  intFromWeek; }
			set { intFromWeek = value; }
		}
		/// <summary>
		/// ToWeek
		/// Đến tuần nào của niên học
		/// </summary>
		public int? ToWeek
		{
			get { return  intToWeek; }
			set { intToWeek = value; }
		}
		/// <summary>
		/// PlanStatusID
		/// Trạng thái là gì: 0: Chưa xác định, 1: Học kì một, 2: Học kì 2, 3: Quân sự,  4: Thực tập môn, 5: Thi hết môn, 6: Thi học kỳ I, 7: Thi học kì II,  8: Thực tập tốt nghiệp, 9: Đồ án tốt nghiệp,10: Nghỉ tết, 11: Nghỉ hè,....
		/// </summary>
		public int? PlanStatusID
		{
			get { return  intPlanStatusID; }
			set { intPlanStatusID = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_YearID.ToUpper()) && !Convert.IsDBNull(reader[C_YearID])) this.intYearID = Convert.ToInt32(reader[C_YearID]);
					if (reader.GetName(i).ToUpper().Equals(C_ClassID.ToUpper()) && !Convert.IsDBNull(reader[C_ClassID])) this.strClassID = Convert.ToString(reader[C_ClassID]);
					if (reader.GetName(i).ToUpper().Equals(C_FromWeek.ToUpper()) && !Convert.IsDBNull(reader[C_FromWeek])) this.intFromWeek = Convert.ToInt32(reader[C_FromWeek]);
					if (reader.GetName(i).ToUpper().Equals(C_ToWeek.ToUpper()) && !Convert.IsDBNull(reader[C_ToWeek])) this.intToWeek = Convert.ToInt32(reader[C_ToWeek]);
					if (reader.GetName(i).ToUpper().Equals(C_PlanStatusID.ToUpper()) && !Convert.IsDBNull(reader[C_PlanStatusID])) this.intPlanStatusID = Convert.ToInt32(reader[C_PlanStatusID]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedBy.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedBy])) this.strCreatedBy = Convert.ToString(reader[C_CreatedBy]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(reader[C_CreatedAt]);
					if (reader.GetName(i).ToUpper().Equals(C_ModifiedBy.ToUpper()) && !Convert.IsDBNull(reader[C_ModifiedBy])) this.strModifiedBy = Convert.ToString(reader[C_ModifiedBy]);
					if (reader.GetName(i).ToUpper().Equals(C_ModifiedAt.ToUpper()) && !Convert.IsDBNull(reader[C_ModifiedAt])) this.dtmModifiedAt = Convert.ToDateTime(reader[C_ModifiedAt]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_SummaryPlan", objEx);
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
				if (!Convert.IsDBNull(drw[C_YearID])) this.intYearID = Convert.ToInt32(drw[C_YearID]);
				if (!Convert.IsDBNull(drw[C_ClassID])) this.strClassID = Convert.ToString(drw[C_ClassID]);
				if (!Convert.IsDBNull(drw[C_FromWeek])) this.intFromWeek = Convert.ToInt32(drw[C_FromWeek]);
				if (!Convert.IsDBNull(drw[C_ToWeek])) this.intToWeek = Convert.ToInt32(drw[C_ToWeek]);
				if (!Convert.IsDBNull(drw[C_PlanStatusID])) this.intPlanStatusID = Convert.ToInt32(drw[C_PlanStatusID]);
				if (!Convert.IsDBNull(drw[C_CreatedBy])) this.strCreatedBy = Convert.ToString(drw[C_CreatedBy]);
				if (!Convert.IsDBNull(drw[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(drw[C_CreatedAt]);
				if (!Convert.IsDBNull(drw[C_ModifiedBy])) this.strModifiedBy = Convert.ToString(drw[C_ModifiedBy]);
				if (!Convert.IsDBNull(drw[C_ModifiedAt])) this.dtmModifiedAt = Convert.ToDateTime(drw[C_ModifiedAt]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_SummaryPlan", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_SummaryPlan_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_SummaryPlan_GET");
				objIData.AddParameter(P_YearID, this.intYearID);
				objIData.AddParameter(P_ClassID, this.strClassID);
				objIData.AddParameter(P_FromWeek, this.intFromWeek);
				objIData.AddParameter(P_PlanStatusID, this.intPlanStatusID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_SummaryPlan", objEx);
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
		/// Store: SIM_SummaryPlan_GET 
		///</summary>
		/// <returns> SIM_SummaryPlan </returns>
		public SIM_SummaryPlan Get(int? intYearID, string strClassID, int? intFromWeek, int? intPlanStatusID)
		{
			SIM_SummaryPlan obj = new SIM_SummaryPlan();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.YearID = intYearID;
			obj.ClassID = strClassID;
			obj.FromWeek = intFromWeek;
			obj.PlanStatusID = intPlanStatusID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_SummaryPlan
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_SummaryPlan", objEx);
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
		/// Search : SIM_SummaryPlan
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_SummaryPlan", objEx);
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
		/// Search : SIM_SummaryPlan
		/// Lấy hết dữ liệu
		/// Store: SIM_SummaryPlan_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_SummaryPlan_GETALL");
		}

		///<summary>
		/// Search : SIM_SummaryPlan
		/// Tìm dữ liệu
		/// Store: SIM_SummaryPlan_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_SummaryPlan_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_SummaryPlan
		/// Thêm dữ liệu
		/// Store: SIM_SummaryPlan_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_SummaryPlan_ADD");
				objIData.AddParameter(P_YearID, this.intYearID);
				objIData.AddParameter(P_ClassID, this.strClassID);
				objIData.AddParameter(P_FromWeek, this.intFromWeek);
				objIData.AddParameter(P_ToWeek, this.intToWeek);
				objIData.AddParameter(P_PlanStatusID, this.intPlanStatusID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_SummaryPlan", objEx);
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
		/// Update : SIM_SummaryPlan
		/// Cập nhật dữ liệu
		/// Store: SIM_SummaryPlan_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_SummaryPlan_EDIT");
				objIData.AddParameter(P_YearID, this.intYearID);
				objIData.AddParameter(P_ClassID, this.strClassID);
				objIData.AddParameter(P_FromWeek, this.intFromWeek);
				objIData.AddParameter(P_ToWeek, this.intToWeek);
				objIData.AddParameter(P_PlanStatusID, this.intPlanStatusID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_SummaryPlan", objEx);
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
		/// Delete : SIM_SummaryPlan
		/// Xóa dữ liệu
		/// Store: SIM_SummaryPlan_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_SummaryPlan_DELETE");
				objIData.AddParameter(P_YearID, this.intYearID);
				objIData.AddParameter(P_ClassID, this.strClassID);
				objIData.AddParameter(P_FromWeek, this.intFromWeek);
				objIData.AddParameter(P_PlanStatusID, this.intPlanStatusID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_SummaryPlan", objEx);
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
		/// Store: SIM_SummaryPlan_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(int? intYearID, string strClassID, int? intFromWeek, int? intPlanStatusID)
		{
			this.intYearID = intYearID;
			this.strClassID = strClassID;
			this.intFromWeek = intFromWeek;
			this.intPlanStatusID = intPlanStatusID;
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

		public SIM_SummaryPlan()
		{
		}
		public SIM_SummaryPlan(int? intYearID, string strClassID, int? intFromWeek, int? intPlanStatusID)
		{
			this.intYearID = intYearID;
			this.strClassID = strClassID;
			this.intFromWeek = intFromWeek;
			this.intPlanStatusID = intPlanStatusID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_YearID = "@" + C_YearID;
		public const String P_ClassID = "@" + C_ClassID;
		public const String P_FromWeek = "@" + C_FromWeek;
		public const String P_ToWeek = "@" + C_ToWeek;
		public const String P_PlanStatusID = "@" + C_PlanStatusID;
		public const String P_CreatedBy = "@" + C_CreatedBy;
		public const String P_CreatedAt = "@" + C_CreatedAt;
		public const String P_ModifiedBy = "@" + C_ModifiedBy;
		public const String P_ModifiedAt = "@" + C_ModifiedAt;

		#endregion //Parameter names

		#region Column Names

		public const String C_YearID = "YearID";
		public const String C_ClassID = "ClassID";
		public const String C_FromWeek = "FromWeek";
		public const String C_ToWeek = "ToWeek";
		public const String C_PlanStatusID = "PlanStatusID";
		public const String C_CreatedBy = "CreatedBy";
		public const String C_CreatedAt = "CreatedAt";
		public const String C_ModifiedBy = "ModifiedBy";
		public const String C_ModifiedAt = "ModifiedAt";

		#endregion //Column names

		#endregion Variable Static		
	}
}
