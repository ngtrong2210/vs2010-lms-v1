
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
	/// Created date 	: 09/03/2020 
	/// Description 
	/// </summary>	
	public partial class INS_InsuPeriod
	{	
		#region Member Variables

		private int? intInsuPeriodID = null;//Đợt cấp bảo hiểm
		private string strInsuPeriodCode = null;//Mã
		private string strInsuPeriodName = null;//Tên
		private DateTime? dtmStartDate = null;
		private DateTime? dtmFinishDate = null;
		private string strDescription = null;//Mô tả
		private int? intOrderIndex = null;
		private bool bolIsDefault = false;
		private bool bolIsActived = false;
		private bool bolIsSystem = false;
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
		/// InsuPeriodID
		/// Đợt cấp bảo hiểm
		/// </summary>
		public int? InsuPeriodID
		{
			get { return  intInsuPeriodID; }
			set { intInsuPeriodID = value; }
		}
		/// <summary>
		/// InsuPeriodCode
		/// Mã
		/// </summary>
		public string InsuPeriodCode
		{
			get { return  strInsuPeriodCode; }
			set { strInsuPeriodCode = value; }
		}
		/// <summary>
		/// InsuPeriodName
		/// Tên
		/// </summary>
		public string InsuPeriodName
		{
			get { return  strInsuPeriodName; }
			set { strInsuPeriodName = value; }
		}
		/// <summary>
		/// StartDate
		/// 
		/// </summary>
		public DateTime? StartDate
		{
			get { return  dtmStartDate; }
			set { dtmStartDate = value; }
		}
		/// <summary>
		/// FinishDate
		/// 
		/// </summary>
		public DateTime? FinishDate
		{
			get { return  dtmFinishDate; }
			set { dtmFinishDate = value; }
		}
		/// <summary>
		/// Description
		/// Mô tả
		/// </summary>
		public string Description
		{
			get { return  strDescription; }
			set { strDescription = value; }
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
		/// IsDefault
		/// 
		/// </summary>
		public bool IsDefault
		{
			get { return  bolIsDefault; }
			set { bolIsDefault = value; }
		}
		/// <summary>
		/// IsActived
		/// 
		/// </summary>
		public bool IsActived
		{
			get { return  bolIsActived; }
			set { bolIsActived = value; }
		}
		/// <summary>
		/// IsSystem
		/// 
		/// </summary>
		public bool IsSystem
		{
			get { return  bolIsSystem; }
			set { bolIsSystem = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_InsuPeriodID.ToUpper()) && !Convert.IsDBNull(reader[C_InsuPeriodID])) this.intInsuPeriodID = Convert.ToInt32(reader[C_InsuPeriodID]);
					if (reader.GetName(i).ToUpper().Equals(C_InsuPeriodCode.ToUpper()) && !Convert.IsDBNull(reader[C_InsuPeriodCode])) this.strInsuPeriodCode = Convert.ToString(reader[C_InsuPeriodCode]);
					if (reader.GetName(i).ToUpper().Equals(C_InsuPeriodName.ToUpper()) && !Convert.IsDBNull(reader[C_InsuPeriodName])) this.strInsuPeriodName = Convert.ToString(reader[C_InsuPeriodName]);
					if (reader.GetName(i).ToUpper().Equals(C_StartDate.ToUpper()) && !Convert.IsDBNull(reader[C_StartDate])) this.dtmStartDate = Convert.ToDateTime(reader[C_StartDate]);
					if (reader.GetName(i).ToUpper().Equals(C_FinishDate.ToUpper()) && !Convert.IsDBNull(reader[C_FinishDate])) this.dtmFinishDate = Convert.ToDateTime(reader[C_FinishDate]);
					if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
					if (reader.GetName(i).ToUpper().Equals(C_OrderIndex.ToUpper()) && !Convert.IsDBNull(reader[C_OrderIndex])) this.intOrderIndex = Convert.ToInt32(reader[C_OrderIndex]);
					if (reader.GetName(i).ToUpper().Equals(C_IsDefault.ToUpper()) && !Convert.IsDBNull(reader[C_IsDefault])) this.bolIsDefault = Convert.ToBoolean(reader[C_IsDefault]);
					if (reader.GetName(i).ToUpper().Equals(C_IsActived.ToUpper()) && !Convert.IsDBNull(reader[C_IsActived])) this.bolIsActived = Convert.ToBoolean(reader[C_IsActived]);
					if (reader.GetName(i).ToUpper().Equals(C_IsSystem.ToUpper()) && !Convert.IsDBNull(reader[C_IsSystem])) this.bolIsSystem = Convert.ToBoolean(reader[C_IsSystem]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(reader[C_UpdatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(reader[C_UpdatedUser]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong INS_InsuPeriod", objEx);
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
				if (!Convert.IsDBNull(drw[C_InsuPeriodID])) this.intInsuPeriodID = Convert.ToInt32(drw[C_InsuPeriodID]);
				if (!Convert.IsDBNull(drw[C_InsuPeriodCode])) this.strInsuPeriodCode = Convert.ToString(drw[C_InsuPeriodCode]);
				if (!Convert.IsDBNull(drw[C_InsuPeriodName])) this.strInsuPeriodName = Convert.ToString(drw[C_InsuPeriodName]);
				if (!Convert.IsDBNull(drw[C_StartDate])) this.dtmStartDate = Convert.ToDateTime(drw[C_StartDate]);
				if (!Convert.IsDBNull(drw[C_FinishDate])) this.dtmFinishDate = Convert.ToDateTime(drw[C_FinishDate]);
				if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
				if (!Convert.IsDBNull(drw[C_OrderIndex])) this.intOrderIndex = Convert.ToInt32(drw[C_OrderIndex]);
				if (!Convert.IsDBNull(drw[C_IsDefault])) this.bolIsDefault = Convert.ToBoolean(drw[C_IsDefault]);
				if (!Convert.IsDBNull(drw[C_IsActived])) this.bolIsActived = Convert.ToBoolean(drw[C_IsActived]);
				if (!Convert.IsDBNull(drw[C_IsSystem])) this.bolIsSystem = Convert.ToBoolean(drw[C_IsSystem]);
				if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
				if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
				if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
				if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong INS_InsuPeriod", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: INS_InsuPeriod_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("INS_InsuPeriod_GET");
				objIData.AddParameter(P_InsuPeriodID, this.intInsuPeriodID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin INS_InsuPeriod", objEx);
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
		/// Store: INS_InsuPeriod_GET 
		///</summary>
		/// <returns> INS_InsuPeriod </returns>
		public INS_InsuPeriod Get(int? intInsuPeriodID)
		{
			INS_InsuPeriod obj = new INS_InsuPeriod();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.InsuPeriodID = intInsuPeriodID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : INS_InsuPeriod
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong INS_InsuPeriod", objEx);
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
		/// Search : INS_InsuPeriod
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong INS_InsuPeriod", objEx);
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
		/// Search : INS_InsuPeriod
		/// Lấy hết dữ liệu
		/// Store: INS_InsuPeriod_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("INS_InsuPeriod_GETALL");
		}

		///<summary>
		/// Search : INS_InsuPeriod
		/// Tìm dữ liệu
		/// Store: INS_InsuPeriod_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("INS_InsuPeriod_SEARCH",pars);
		}

		///<summary>
		/// Add : INS_InsuPeriod
		/// Thêm dữ liệu
		/// Store: INS_InsuPeriod_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("INS_InsuPeriod_ADD");
				objIData.AddParameter(P_InsuPeriodCode, this.strInsuPeriodCode);
				objIData.AddParameter(P_InsuPeriodName, this.strInsuPeriodName);
				objIData.AddParameter(P_StartDate, this.dtmStartDate);
				objIData.AddParameter(P_FinishDate, this.dtmFinishDate);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_OrderIndex, this.intOrderIndex);
				objIData.AddParameter(P_IsDefault, this.bolIsDefault);
				objIData.AddParameter(P_IsActived, this.bolIsActived);
				objIData.AddParameter(P_IsSystem, this.bolIsSystem);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				this.intInsuPeriodID = Convert.ToInt32(objIData.ExecStoreToString());
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin INS_InsuPeriod", objEx);
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
		/// Update : INS_InsuPeriod
		/// Cập nhật dữ liệu
		/// Store: INS_InsuPeriod_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("INS_InsuPeriod_EDIT");
				objIData.AddParameter(P_InsuPeriodID, this.intInsuPeriodID);
				objIData.AddParameter(P_InsuPeriodCode, this.strInsuPeriodCode);
				objIData.AddParameter(P_InsuPeriodName, this.strInsuPeriodName);
				objIData.AddParameter(P_StartDate, this.dtmStartDate);
				objIData.AddParameter(P_FinishDate, this.dtmFinishDate);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_OrderIndex, this.intOrderIndex);
				objIData.AddParameter(P_IsDefault, this.bolIsDefault);
				objIData.AddParameter(P_IsActived, this.bolIsActived);
				objIData.AddParameter(P_IsSystem, this.bolIsSystem);
				objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin INS_InsuPeriod", objEx);
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
		/// Delete : INS_InsuPeriod
		/// Xóa dữ liệu
		/// Store: INS_InsuPeriod_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("INS_InsuPeriod_DELETE");
				objIData.AddParameter(P_InsuPeriodID, this.intInsuPeriodID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin INS_InsuPeriod", objEx);
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
		/// Store: INS_InsuPeriod_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(int? intInsuPeriodID)
		{
			this.intInsuPeriodID = intInsuPeriodID;
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

		public INS_InsuPeriod()
		{
		}
		public INS_InsuPeriod(int? intInsuPeriodID)
		{
			this.intInsuPeriodID = intInsuPeriodID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_InsuPeriodID = "@" + C_InsuPeriodID;
		public const String P_InsuPeriodCode = "@" + C_InsuPeriodCode;
		public const String P_InsuPeriodName = "@" + C_InsuPeriodName;
		public const String P_StartDate = "@" + C_StartDate;
		public const String P_FinishDate = "@" + C_FinishDate;
		public const String P_Description = "@" + C_Description;
		public const String P_OrderIndex = "@" + C_OrderIndex;
		public const String P_IsDefault = "@" + C_IsDefault;
		public const String P_IsActived = "@" + C_IsActived;
		public const String P_IsSystem = "@" + C_IsSystem;
		public const String P_CreatedDate = "@" + C_CreatedDate;
		public const String P_CreatedUser = "@" + C_CreatedUser;
		public const String P_UpdatedDate = "@" + C_UpdatedDate;
		public const String P_UpdatedUser = "@" + C_UpdatedUser;

		#endregion //Parameter names

		#region Column Names

		public const String C_InsuPeriodID = "InsuPeriodID";
		public const String C_InsuPeriodCode = "InsuPeriodCode";
		public const String C_InsuPeriodName = "InsuPeriodName";
		public const String C_StartDate = "StartDate";
		public const String C_FinishDate = "FinishDate";
		public const String C_Description = "Description";
		public const String C_OrderIndex = "OrderIndex";
		public const String C_IsDefault = "IsDefault";
		public const String C_IsActived = "IsActived";
		public const String C_IsSystem = "IsSystem";
		public const String C_CreatedDate = "CreatedDate";
		public const String C_CreatedUser = "CreatedUser";
		public const String C_UpdatedDate = "UpdatedDate";
		public const String C_UpdatedUser = "UpdatedUser";

		#endregion //Column names

		#endregion Variable Static		
	}
}
