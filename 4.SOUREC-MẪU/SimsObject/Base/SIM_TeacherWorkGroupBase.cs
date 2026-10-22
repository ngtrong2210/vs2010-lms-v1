
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
	/// Created date 	: 8/3/2022 
	/// Description 
	/// </summary>	
	public partial class SIM_TeacherWorkGroup
	{	
		#region Member Variables

		private int? intTeacherWorkGroupID = null;//Mã chức vụ
		private string strTeacherWorkGroupCode = null;//Tên chức vụ
		private string strTeacherWorkGroupName = null;//Tên chức vụ
		private string strTeacherWorkGroupShortName = null;//Tên chức vụ
		private string strDescription = null;//Mô tả
		private int? intOrderIndex = null;
		private bool bolIsActived = false;
		private bool bolIsDefault = false;
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
		/// TeacherWorkGroupID
		/// Mã chức vụ
		/// </summary>
		public int? TeacherWorkGroupID
		{
			get { return  intTeacherWorkGroupID; }
			set { intTeacherWorkGroupID = value; }
		}
		/// <summary>
		/// TeacherWorkGroupCode
		/// Tên chức vụ
		/// </summary>
		public string TeacherWorkGroupCode
		{
			get { return  strTeacherWorkGroupCode; }
			set { strTeacherWorkGroupCode = value; }
		}
		/// <summary>
		/// TeacherWorkGroupName
		/// Tên chức vụ
		/// </summary>
		public string TeacherWorkGroupName
		{
			get { return  strTeacherWorkGroupName; }
			set { strTeacherWorkGroupName = value; }
		}
		/// <summary>
		/// TeacherWorkGroupShortName
		/// Tên chức vụ
		/// </summary>
		public string TeacherWorkGroupShortName
		{
			get { return  strTeacherWorkGroupShortName; }
			set { strTeacherWorkGroupShortName = value; }
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
		/// IsActived
		/// 
		/// </summary>
		public bool IsActived
		{
			get { return  bolIsActived; }
			set { bolIsActived = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_TeacherWorkGroupID.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherWorkGroupID])) this.intTeacherWorkGroupID = Convert.ToInt32(reader[C_TeacherWorkGroupID]);
					if (reader.GetName(i).ToUpper().Equals(C_TeacherWorkGroupCode.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherWorkGroupCode])) this.strTeacherWorkGroupCode = Convert.ToString(reader[C_TeacherWorkGroupCode]);
					if (reader.GetName(i).ToUpper().Equals(C_TeacherWorkGroupName.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherWorkGroupName])) this.strTeacherWorkGroupName = Convert.ToString(reader[C_TeacherWorkGroupName]);
					if (reader.GetName(i).ToUpper().Equals(C_TeacherWorkGroupShortName.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherWorkGroupShortName])) this.strTeacherWorkGroupShortName = Convert.ToString(reader[C_TeacherWorkGroupShortName]);
					if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
					if (reader.GetName(i).ToUpper().Equals(C_OrderIndex.ToUpper()) && !Convert.IsDBNull(reader[C_OrderIndex])) this.intOrderIndex = Convert.ToInt32(reader[C_OrderIndex]);
					if (reader.GetName(i).ToUpper().Equals(C_IsActived.ToUpper()) && !Convert.IsDBNull(reader[C_IsActived])) this.bolIsActived = Convert.ToBoolean(reader[C_IsActived]);
					if (reader.GetName(i).ToUpper().Equals(C_IsDefault.ToUpper()) && !Convert.IsDBNull(reader[C_IsDefault])) this.bolIsDefault = Convert.ToBoolean(reader[C_IsDefault]);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_TeacherWorkGroup", objEx);
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
				if (!Convert.IsDBNull(drw[C_TeacherWorkGroupID])) this.intTeacherWorkGroupID = Convert.ToInt32(drw[C_TeacherWorkGroupID]);
				if (!Convert.IsDBNull(drw[C_TeacherWorkGroupCode])) this.strTeacherWorkGroupCode = Convert.ToString(drw[C_TeacherWorkGroupCode]);
				if (!Convert.IsDBNull(drw[C_TeacherWorkGroupName])) this.strTeacherWorkGroupName = Convert.ToString(drw[C_TeacherWorkGroupName]);
				if (!Convert.IsDBNull(drw[C_TeacherWorkGroupShortName])) this.strTeacherWorkGroupShortName = Convert.ToString(drw[C_TeacherWorkGroupShortName]);
				if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
				if (!Convert.IsDBNull(drw[C_OrderIndex])) this.intOrderIndex = Convert.ToInt32(drw[C_OrderIndex]);
				if (!Convert.IsDBNull(drw[C_IsActived])) this.bolIsActived = Convert.ToBoolean(drw[C_IsActived]);
				if (!Convert.IsDBNull(drw[C_IsDefault])) this.bolIsDefault = Convert.ToBoolean(drw[C_IsDefault]);
				if (!Convert.IsDBNull(drw[C_IsSystem])) this.bolIsSystem = Convert.ToBoolean(drw[C_IsSystem]);
				if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
				if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
				if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
				if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_TeacherWorkGroup", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_TeacherWorkGroup_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_TeacherWorkGroup_GET");
				objIData.AddParameter(P_TeacherWorkGroupID, this.intTeacherWorkGroupID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_TeacherWorkGroup", objEx);
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
		/// Store: SIM_TeacherWorkGroup_GET 
		///</summary>
		/// <returns> SIM_TeacherWorkGroup </returns>
		public SIM_TeacherWorkGroup Get(int? intTeacherWorkGroupID)
		{
			SIM_TeacherWorkGroup obj = new SIM_TeacherWorkGroup();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.TeacherWorkGroupID = intTeacherWorkGroupID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_TeacherWorkGroup
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_TeacherWorkGroup", objEx);
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
		/// Search : SIM_TeacherWorkGroup
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_TeacherWorkGroup", objEx);
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
		/// Search : SIM_TeacherWorkGroup
		/// Lấy hết dữ liệu
		/// Store: SIM_TeacherWorkGroup_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_TeacherWorkGroup_GETALL");
		}

		///<summary>
		/// Search : SIM_TeacherWorkGroup
		/// Tìm dữ liệu
		/// Store: SIM_TeacherWorkGroup_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_TeacherWorkGroup_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_TeacherWorkGroup
		/// Thêm dữ liệu
		/// Store: SIM_TeacherWorkGroup_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_TeacherWorkGroup_ADD");
				objIData.AddParameter(P_TeacherWorkGroupCode, this.strTeacherWorkGroupCode);
				objIData.AddParameter(P_TeacherWorkGroupName, this.strTeacherWorkGroupName);
				objIData.AddParameter(P_TeacherWorkGroupShortName, this.strTeacherWorkGroupShortName);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_OrderIndex, this.intOrderIndex);
				objIData.AddParameter(P_IsActived, this.bolIsActived);
				objIData.AddParameter(P_IsDefault, this.bolIsDefault);
				objIData.AddParameter(P_IsSystem, this.bolIsSystem);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				this.intTeacherWorkGroupID = Convert.ToInt32(objIData.ExecStoreToString());
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_TeacherWorkGroup", objEx);
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
		/// Update : SIM_TeacherWorkGroup
		/// Cập nhật dữ liệu
		/// Store: SIM_TeacherWorkGroup_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_TeacherWorkGroup_EDIT");
				objIData.AddParameter(P_TeacherWorkGroupID, this.intTeacherWorkGroupID);
				objIData.AddParameter(P_TeacherWorkGroupCode, this.strTeacherWorkGroupCode);
				objIData.AddParameter(P_TeacherWorkGroupName, this.strTeacherWorkGroupName);
				objIData.AddParameter(P_TeacherWorkGroupShortName, this.strTeacherWorkGroupShortName);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_OrderIndex, this.intOrderIndex);
				objIData.AddParameter(P_IsActived, this.bolIsActived);
				objIData.AddParameter(P_IsDefault, this.bolIsDefault);
				objIData.AddParameter(P_IsSystem, this.bolIsSystem);
				objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_TeacherWorkGroup", objEx);
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
		/// Delete : SIM_TeacherWorkGroup
		/// Xóa dữ liệu
		/// Store: SIM_TeacherWorkGroup_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_TeacherWorkGroup_DELETE");
				objIData.AddParameter(P_TeacherWorkGroupID, this.intTeacherWorkGroupID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_TeacherWorkGroup", objEx);
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
		/// Store: SIM_TeacherWorkGroup_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(int? intTeacherWorkGroupID)
		{
			this.intTeacherWorkGroupID = intTeacherWorkGroupID;
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

		public SIM_TeacherWorkGroup()
		{
		}
		public SIM_TeacherWorkGroup(int? intTeacherWorkGroupID)
		{
			this.intTeacherWorkGroupID = intTeacherWorkGroupID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_TeacherWorkGroupID = "@" + C_TeacherWorkGroupID;
		public const String P_TeacherWorkGroupCode = "@" + C_TeacherWorkGroupCode;
		public const String P_TeacherWorkGroupName = "@" + C_TeacherWorkGroupName;
		public const String P_TeacherWorkGroupShortName = "@" + C_TeacherWorkGroupShortName;
		public const String P_Description = "@" + C_Description;
		public const String P_OrderIndex = "@" + C_OrderIndex;
		public const String P_IsActived = "@" + C_IsActived;
		public const String P_IsDefault = "@" + C_IsDefault;
		public const String P_IsSystem = "@" + C_IsSystem;
		public const String P_CreatedDate = "@" + C_CreatedDate;
		public const String P_CreatedUser = "@" + C_CreatedUser;
		public const String P_UpdatedDate = "@" + C_UpdatedDate;
		public const String P_UpdatedUser = "@" + C_UpdatedUser;

		#endregion //Parameter names

		#region Column Names

		public const String C_TeacherWorkGroupID = "TeacherWorkGroupID";
		public const String C_TeacherWorkGroupCode = "TeacherWorkGroupCode";
		public const String C_TeacherWorkGroupName = "TeacherWorkGroupName";
		public const String C_TeacherWorkGroupShortName = "TeacherWorkGroupShortName";
		public const String C_Description = "Description";
		public const String C_OrderIndex = "OrderIndex";
		public const String C_IsActived = "IsActived";
		public const String C_IsDefault = "IsDefault";
		public const String C_IsSystem = "IsSystem";
		public const String C_CreatedDate = "CreatedDate";
		public const String C_CreatedUser = "CreatedUser";
		public const String C_UpdatedDate = "UpdatedDate";
		public const String C_UpdatedUser = "UpdatedUser";

		#endregion //Column names

		#endregion Variable Static		
	}
}
