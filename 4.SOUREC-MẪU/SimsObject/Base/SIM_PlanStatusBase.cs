
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
	public partial class SIM_PlanStatus
	{	
		#region Member Variables

		private int? intPlanStatusID = null;//Mã trạng thái kế hoạch
		private string strPlanStatusName = null;//Tên trạng thái kế hoạch
		private string strPlanStatusShortName = null;
		private long? lngBackColor = null;//Mã màu nền
		private bool bolIsSystem = false;//Nếu là hệ thống thì không cho xoá và hiện thị lên chỗ chọn biểu đồ
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
		/// PlanStatusID
		/// Mã trạng thái kế hoạch
		/// </summary>
		public int? PlanStatusID
		{
			get { return  intPlanStatusID; }
			set { intPlanStatusID = value; }
		}
		/// <summary>
		/// PlanStatusName
		/// Tên trạng thái kế hoạch
		/// </summary>
		public string PlanStatusName
		{
			get { return  strPlanStatusName; }
			set { strPlanStatusName = value; }
		}
		/// <summary>
		/// PlanStatusShortName
		/// 
		/// </summary>
		public string PlanStatusShortName
		{
			get { return  strPlanStatusShortName; }
			set { strPlanStatusShortName = value; }
		}
		/// <summary>
		/// BackColor
		/// Mã màu nền
		/// </summary>
		public long? BackColor
		{
			get { return  lngBackColor; }
			set { lngBackColor = value; }
		}
		/// <summary>
		/// IsSystem
		/// Nếu là hệ thống thì không cho xoá và hiện thị lên chỗ chọn biểu đồ
		/// </summary>
		public bool IsSystem
		{
			get { return  bolIsSystem; }
			set { bolIsSystem = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_PlanStatusID.ToUpper()) && !Convert.IsDBNull(reader[C_PlanStatusID])) this.intPlanStatusID = Convert.ToInt32(reader[C_PlanStatusID]);
					if (reader.GetName(i).ToUpper().Equals(C_PlanStatusName.ToUpper()) && !Convert.IsDBNull(reader[C_PlanStatusName])) this.strPlanStatusName = Convert.ToString(reader[C_PlanStatusName]);
					if (reader.GetName(i).ToUpper().Equals(C_PlanStatusShortName.ToUpper()) && !Convert.IsDBNull(reader[C_PlanStatusShortName])) this.strPlanStatusShortName = Convert.ToString(reader[C_PlanStatusShortName]);
					if (reader.GetName(i).ToUpper().Equals(C_BackColor.ToUpper()) && !Convert.IsDBNull(reader[C_BackColor])) this.lngBackColor = Convert.ToInt64(reader[C_BackColor]);
					if (reader.GetName(i).ToUpper().Equals(C_IsSystem.ToUpper()) && !Convert.IsDBNull(reader[C_IsSystem])) this.bolIsSystem = Convert.ToBoolean(reader[C_IsSystem]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedBy.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedBy])) this.strCreatedBy = Convert.ToString(reader[C_CreatedBy]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(reader[C_CreatedAt]);
					if (reader.GetName(i).ToUpper().Equals(C_ModifiedBy.ToUpper()) && !Convert.IsDBNull(reader[C_ModifiedBy])) this.strModifiedBy = Convert.ToString(reader[C_ModifiedBy]);
					if (reader.GetName(i).ToUpper().Equals(C_ModifiedAt.ToUpper()) && !Convert.IsDBNull(reader[C_ModifiedAt])) this.dtmModifiedAt = Convert.ToDateTime(reader[C_ModifiedAt]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_PlanStatus", objEx);
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
				if (!Convert.IsDBNull(drw[C_PlanStatusID])) this.intPlanStatusID = Convert.ToInt32(drw[C_PlanStatusID]);
				if (!Convert.IsDBNull(drw[C_PlanStatusName])) this.strPlanStatusName = Convert.ToString(drw[C_PlanStatusName]);
				if (!Convert.IsDBNull(drw[C_PlanStatusShortName])) this.strPlanStatusShortName = Convert.ToString(drw[C_PlanStatusShortName]);
				if (!Convert.IsDBNull(drw[C_BackColor])) this.lngBackColor = Convert.ToInt64(drw[C_BackColor]);
				if (!Convert.IsDBNull(drw[C_IsSystem])) this.bolIsSystem = Convert.ToBoolean(drw[C_IsSystem]);
				if (!Convert.IsDBNull(drw[C_CreatedBy])) this.strCreatedBy = Convert.ToString(drw[C_CreatedBy]);
				if (!Convert.IsDBNull(drw[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(drw[C_CreatedAt]);
				if (!Convert.IsDBNull(drw[C_ModifiedBy])) this.strModifiedBy = Convert.ToString(drw[C_ModifiedBy]);
				if (!Convert.IsDBNull(drw[C_ModifiedAt])) this.dtmModifiedAt = Convert.ToDateTime(drw[C_ModifiedAt]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_PlanStatus", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_PlanStatus_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_PlanStatus_GET");
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_PlanStatus", objEx);
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
		/// Store: SIM_PlanStatus_GET 
		///</summary>
		/// <returns> SIM_PlanStatus </returns>
		public SIM_PlanStatus Get(int? intPlanStatusID)
		{
			SIM_PlanStatus obj = new SIM_PlanStatus();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.PlanStatusID = intPlanStatusID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_PlanStatus
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_PlanStatus", objEx);
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
		/// Search : SIM_PlanStatus
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_PlanStatus", objEx);
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
		/// Search : SIM_PlanStatus
		/// Lấy hết dữ liệu
		/// Store: SIM_PlanStatus_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_PlanStatus_GETALL");
		}

		///<summary>
		/// Search : SIM_PlanStatus
		/// Tìm dữ liệu
		/// Store: SIM_PlanStatus_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_PlanStatus_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_PlanStatus
		/// Thêm dữ liệu
		/// Store: SIM_PlanStatus_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_PlanStatus_ADD");
				objIData.AddParameter(P_PlanStatusName, this.strPlanStatusName);
				objIData.AddParameter(P_PlanStatusShortName, this.strPlanStatusShortName);
				objIData.AddParameter(P_BackColor, this.lngBackColor);
				objIData.AddParameter(P_IsSystem, this.bolIsSystem);
				objIData.AddParameter(P_CreatedBy, this.strCreatedBy);
				objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
				objIData.AddParameter(P_ModifiedBy, this.strModifiedBy);
				objIData.AddParameter(P_ModifiedAt, this.dtmModifiedAt);
				this.intPlanStatusID = Convert.ToInt32(objIData.ExecStoreToString());
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_PlanStatus", objEx);
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
		/// Update : SIM_PlanStatus
		/// Cập nhật dữ liệu
		/// Store: SIM_PlanStatus_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_PlanStatus_EDIT");
				objIData.AddParameter(P_PlanStatusID, this.intPlanStatusID);
				objIData.AddParameter(P_PlanStatusName, this.strPlanStatusName);
				objIData.AddParameter(P_PlanStatusShortName, this.strPlanStatusShortName);
				objIData.AddParameter(P_BackColor, this.lngBackColor);
				objIData.AddParameter(P_IsSystem, this.bolIsSystem);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_PlanStatus", objEx);
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
		/// Delete : SIM_PlanStatus
		/// Xóa dữ liệu
		/// Store: SIM_PlanStatus_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_PlanStatus_DELETE");
				objIData.AddParameter(P_PlanStatusID, this.intPlanStatusID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_PlanStatus", objEx);
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
		/// Store: SIM_PlanStatus_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(int? intPlanStatusID)
		{
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

		public SIM_PlanStatus()
		{
		}
		public SIM_PlanStatus(int? intPlanStatusID)
		{
			this.intPlanStatusID = intPlanStatusID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_PlanStatusID = "@" + C_PlanStatusID;
		public const String P_PlanStatusName = "@" + C_PlanStatusName;
		public const String P_PlanStatusShortName = "@" + C_PlanStatusShortName;
		public const String P_BackColor = "@" + C_BackColor;
		public const String P_IsSystem = "@" + C_IsSystem;
		public const String P_CreatedBy = "@" + C_CreatedBy;
		public const String P_CreatedAt = "@" + C_CreatedAt;
		public const String P_ModifiedBy = "@" + C_ModifiedBy;
		public const String P_ModifiedAt = "@" + C_ModifiedAt;

		#endregion //Parameter names

		#region Column Names

		public const String C_PlanStatusID = "PlanStatusID";
		public const String C_PlanStatusName = "PlanStatusName";
		public const String C_PlanStatusShortName = "PlanStatusShortName";
		public const String C_BackColor = "BackColor";
		public const String C_IsSystem = "IsSystem";
		public const String C_CreatedBy = "CreatedBy";
		public const String C_CreatedAt = "CreatedAt";
		public const String C_ModifiedBy = "ModifiedBy";
		public const String C_ModifiedAt = "ModifiedAt";

		#endregion //Column names

		#endregion Variable Static		
	}
}
