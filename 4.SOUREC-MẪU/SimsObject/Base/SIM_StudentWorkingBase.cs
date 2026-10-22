
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
	public partial class SIM_StudentWorking
	{	
		#region Member Variables

		private long? lngStudentWorkingID = null;
		private long? lngStudentID = null;
		private string strCompany = null;//Tên công ty
		private string strAddress = null;//Địa chỉ làm việc
		private string strPositionID = null;//Vị trí
		private string strWorking = null;//Công việc
		private long? lngMoney = null;//Mức lương
		private DateTime? dtmStartDate = null;//Từ ngày
		private DateTime? dtmFinishDate = null;//Đến ngày
		private string strDescription = null;//Mô tả
		private DateTime? dtmCreatedDate = null;//Ngày tạo
		private string strCreatedUser = null;//Người tạo
		private DateTime? dtmUpdatedDate = null;//Ngày cập nhật cuối
		private string strUpdatedUser = null;//Người cập nhật cuối
		private bool bolIsDeleted = false;//Đã xóa
		private DateTime? dtmDeletedDate = null;//Ngày cập nhật cuối
		private string strDeletedUser = null;//Người cập nhật cuối
		private IData objIData = null;
		private bool bolIsExistIData = false;
		private Exception objErrorException = null;

		#endregion

		#region Properties 

		/// <summary>
		/// StudentWorkingID
		/// 
		/// </summary>
		public long? StudentWorkingID
		{
			get { return  lngStudentWorkingID; }
			set { lngStudentWorkingID = value; }
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
		/// Company
		/// Tên công ty
		/// </summary>
		public string Company
		{
			get { return  strCompany; }
			set { strCompany = value; }
		}
		/// <summary>
		/// Address
		/// Địa chỉ làm việc
		/// </summary>
		public string Address
		{
			get { return  strAddress; }
			set { strAddress = value; }
		}
		/// <summary>
		/// PositionID
		/// Vị trí
		/// </summary>
		public string PositionID
		{
			get { return  strPositionID; }
			set { strPositionID = value; }
		}
		/// <summary>
		/// Working
		/// Công việc
		/// </summary>
		public string Working
		{
			get { return  strWorking; }
			set { strWorking = value; }
		}
		/// <summary>
		/// Money
		/// Mức lương
		/// </summary>
		public long? Money
		{
			get { return  lngMoney; }
			set { lngMoney = value; }
		}
		/// <summary>
		/// StartDate
		/// Từ ngày
		/// </summary>
		public DateTime? StartDate
		{
			get { return  dtmStartDate; }
			set { dtmStartDate = value; }
		}
		/// <summary>
		/// FinishDate
		/// Đến ngày
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
		/// IsDeleted
		/// Đã xóa
		/// </summary>
		public bool IsDeleted
		{
			get { return  bolIsDeleted; }
			set { bolIsDeleted = value; }
		}
		/// <summary>
		/// DeletedDate
		/// Ngày cập nhật cuối
		/// </summary>
		public DateTime? DeletedDate
		{
			get { return  dtmDeletedDate; }
			set { dtmDeletedDate = value; }
		}
		/// <summary>
		/// DeletedUser
		/// Người cập nhật cuối
		/// </summary>
		public string DeletedUser
		{
			get { return  strDeletedUser; }
			set { strDeletedUser = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_StudentWorkingID.ToUpper()) && !Convert.IsDBNull(reader[C_StudentWorkingID])) this.lngStudentWorkingID = Convert.ToInt64(reader[C_StudentWorkingID]);
					if (reader.GetName(i).ToUpper().Equals(C_StudentID.ToUpper()) && !Convert.IsDBNull(reader[C_StudentID])) this.lngStudentID = Convert.ToInt64(reader[C_StudentID]);
					if (reader.GetName(i).ToUpper().Equals(C_Company.ToUpper()) && !Convert.IsDBNull(reader[C_Company])) this.strCompany = Convert.ToString(reader[C_Company]);
					if (reader.GetName(i).ToUpper().Equals(C_Address.ToUpper()) && !Convert.IsDBNull(reader[C_Address])) this.strAddress = Convert.ToString(reader[C_Address]);
					if (reader.GetName(i).ToUpper().Equals(C_PositionID.ToUpper()) && !Convert.IsDBNull(reader[C_PositionID])) this.strPositionID = Convert.ToString(reader[C_PositionID]);
					if (reader.GetName(i).ToUpper().Equals(C_Working.ToUpper()) && !Convert.IsDBNull(reader[C_Working])) this.strWorking = Convert.ToString(reader[C_Working]);
					if (reader.GetName(i).ToUpper().Equals(C_Money.ToUpper()) && !Convert.IsDBNull(reader[C_Money])) this.lngMoney = Convert.ToInt64(reader[C_Money]);
					if (reader.GetName(i).ToUpper().Equals(C_StartDate.ToUpper()) && !Convert.IsDBNull(reader[C_StartDate])) this.dtmStartDate = Convert.ToDateTime(reader[C_StartDate]);
					if (reader.GetName(i).ToUpper().Equals(C_FinishDate.ToUpper()) && !Convert.IsDBNull(reader[C_FinishDate])) this.dtmFinishDate = Convert.ToDateTime(reader[C_FinishDate]);
					if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(reader[C_UpdatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(reader[C_UpdatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_IsDeleted.ToUpper()) && !Convert.IsDBNull(reader[C_IsDeleted])) this.bolIsDeleted = Convert.ToBoolean(reader[C_IsDeleted]);
					if (reader.GetName(i).ToUpper().Equals(C_DeletedDate.ToUpper()) && !Convert.IsDBNull(reader[C_DeletedDate])) this.dtmDeletedDate = Convert.ToDateTime(reader[C_DeletedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_DeletedUser.ToUpper()) && !Convert.IsDBNull(reader[C_DeletedUser])) this.strDeletedUser = Convert.ToString(reader[C_DeletedUser]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_StudentWorking", objEx);
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
				if (!Convert.IsDBNull(drw[C_StudentWorkingID])) this.lngStudentWorkingID = Convert.ToInt64(drw[C_StudentWorkingID]);
				if (!Convert.IsDBNull(drw[C_StudentID])) this.lngStudentID = Convert.ToInt64(drw[C_StudentID]);
				if (!Convert.IsDBNull(drw[C_Company])) this.strCompany = Convert.ToString(drw[C_Company]);
				if (!Convert.IsDBNull(drw[C_Address])) this.strAddress = Convert.ToString(drw[C_Address]);
				if (!Convert.IsDBNull(drw[C_PositionID])) this.strPositionID = Convert.ToString(drw[C_PositionID]);
				if (!Convert.IsDBNull(drw[C_Working])) this.strWorking = Convert.ToString(drw[C_Working]);
				if (!Convert.IsDBNull(drw[C_Money])) this.lngMoney = Convert.ToInt64(drw[C_Money]);
				if (!Convert.IsDBNull(drw[C_StartDate])) this.dtmStartDate = Convert.ToDateTime(drw[C_StartDate]);
				if (!Convert.IsDBNull(drw[C_FinishDate])) this.dtmFinishDate = Convert.ToDateTime(drw[C_FinishDate]);
				if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
				if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
				if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
				if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
				if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
				if (!Convert.IsDBNull(drw[C_IsDeleted])) this.bolIsDeleted = Convert.ToBoolean(drw[C_IsDeleted]);
				if (!Convert.IsDBNull(drw[C_DeletedDate])) this.dtmDeletedDate = Convert.ToDateTime(drw[C_DeletedDate]);
				if (!Convert.IsDBNull(drw[C_DeletedUser])) this.strDeletedUser = Convert.ToString(drw[C_DeletedUser]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_StudentWorking", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_StudentWorking_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_StudentWorking_GET");
				objIData.AddParameter(P_StudentWorkingID, this.lngStudentWorkingID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_StudentWorking", objEx);
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
		/// Store: SIM_StudentWorking_GET 
		///</summary>
		/// <returns> SIM_StudentWorking </returns>
		public SIM_StudentWorking Get(long? lngStudentWorkingID)
		{
			SIM_StudentWorking obj = new SIM_StudentWorking();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.StudentWorkingID = lngStudentWorkingID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_StudentWorking
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_StudentWorking", objEx);
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
		/// Search : SIM_StudentWorking
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_StudentWorking", objEx);
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
		/// Search : SIM_StudentWorking
		/// Lấy hết dữ liệu
		/// Store: SIM_StudentWorking_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_StudentWorking_GETALL");
		}

		///<summary>
		/// Search : SIM_StudentWorking
		/// Tìm dữ liệu
		/// Store: SIM_StudentWorking_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_StudentWorking_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_StudentWorking
		/// Thêm dữ liệu
		/// Store: SIM_StudentWorking_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_StudentWorking_ADD");
				objIData.AddParameter(P_StudentID, this.lngStudentID);
				objIData.AddParameter(P_Company, this.strCompany);
				objIData.AddParameter(P_Address, this.strAddress);
				objIData.AddParameter(P_PositionID, this.strPositionID);
				objIData.AddParameter(P_Working, this.strWorking);
				objIData.AddParameter(P_Money, this.lngMoney);
				objIData.AddParameter(P_StartDate, this.dtmStartDate);
				objIData.AddParameter(P_FinishDate, this.dtmFinishDate);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				this.lngStudentWorkingID = Convert.ToInt32(objIData.ExecStoreToString());
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_StudentWorking", objEx);
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
		/// Update : SIM_StudentWorking
		/// Cập nhật dữ liệu
		/// Store: SIM_StudentWorking_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_StudentWorking_EDIT");
				objIData.AddParameter(P_StudentWorkingID, this.lngStudentWorkingID);
				objIData.AddParameter(P_StudentID, this.lngStudentID);
				objIData.AddParameter(P_Company, this.strCompany);
				objIData.AddParameter(P_Address, this.strAddress);
				objIData.AddParameter(P_PositionID, this.strPositionID);
				objIData.AddParameter(P_Working, this.strWorking);
				objIData.AddParameter(P_Money, this.lngMoney);
				objIData.AddParameter(P_StartDate, this.dtmStartDate);
				objIData.AddParameter(P_FinishDate, this.dtmFinishDate);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_StudentWorking", objEx);
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
		/// Delete : SIM_StudentWorking
		/// Xóa dữ liệu
		/// Store: SIM_StudentWorking_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_StudentWorking_DELETE");
				objIData.AddParameter(P_StudentWorkingID, this.lngStudentWorkingID);
				objIData.AddParameter(P_DeletedUser, this.strDeletedUser);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_StudentWorking", objEx);
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
		/// Store: SIM_StudentWorking_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(long? lngStudentWorkingID, string strDeletedUser)
		{
			this.lngStudentWorkingID = lngStudentWorkingID;
			this.strDeletedUser = strDeletedUser;
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

		public SIM_StudentWorking()
		{
		}
		public SIM_StudentWorking(long? lngStudentWorkingID)
		{
			this.lngStudentWorkingID = lngStudentWorkingID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_StudentWorkingID = "@" + C_StudentWorkingID;
		public const String P_StudentID = "@" + C_StudentID;
		public const String P_Company = "@" + C_Company;
		public const String P_Address = "@" + C_Address;
		public const String P_PositionID = "@" + C_PositionID;
		public const String P_Working = "@" + C_Working;
		public const String P_Money = "@" + C_Money;
		public const String P_StartDate = "@" + C_StartDate;
		public const String P_FinishDate = "@" + C_FinishDate;
		public const String P_Description = "@" + C_Description;
		public const String P_CreatedDate = "@" + C_CreatedDate;
		public const String P_CreatedUser = "@" + C_CreatedUser;
		public const String P_UpdatedDate = "@" + C_UpdatedDate;
		public const String P_UpdatedUser = "@" + C_UpdatedUser;
		public const String P_IsDeleted = "@" + C_IsDeleted;
		public const String P_DeletedDate = "@" + C_DeletedDate;
		public const String P_DeletedUser = "@" + C_DeletedUser;

		#endregion //Parameter names

		#region Column Names

		public const String C_StudentWorkingID = "StudentWorkingID";
		public const String C_StudentID = "StudentID";
		public const String C_Company = "Company";
		public const String C_Address = "Address";
		public const String C_PositionID = "PositionID";
		public const String C_Working = "Working";
		public const String C_Money = "Money";
		public const String C_StartDate = "StartDate";
		public const String C_FinishDate = "FinishDate";
		public const String C_Description = "Description";
		public const String C_CreatedDate = "CreatedDate";
		public const String C_CreatedUser = "CreatedUser";
		public const String C_UpdatedDate = "UpdatedDate";
		public const String C_UpdatedUser = "UpdatedUser";
		public const String C_IsDeleted = "IsDeleted";
		public const String C_DeletedDate = "DeletedDate";
		public const String C_DeletedUser = "DeletedUser";

		#endregion //Column names

		#endregion Variable Static		
	}
}
