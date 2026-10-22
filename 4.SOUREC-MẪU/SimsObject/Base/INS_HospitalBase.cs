
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
	public partial class INS_Hospital
	{	
		#region Member Variables

		private int? intHospitalID = null;//Bệnh viện
		private string strHospitalCode = null;//Mã
		private string strHospitalName = null;//Tên
		private string strAddress = null;
		private string strTel = null;
		private string strEmail = null;
		private string strProvinceID = null;
		private string strDistrictID = null;
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
		/// HospitalID
		/// Bệnh viện
		/// </summary>
		public int? HospitalID
		{
			get { return  intHospitalID; }
			set { intHospitalID = value; }
		}
		/// <summary>
		/// HospitalCode
		/// Mã
		/// </summary>
		public string HospitalCode
		{
			get { return  strHospitalCode; }
			set { strHospitalCode = value; }
		}
		/// <summary>
		/// HospitalName
		/// Tên
		/// </summary>
		public string HospitalName
		{
			get { return  strHospitalName; }
			set { strHospitalName = value; }
		}
		/// <summary>
		/// Address
		/// 
		/// </summary>
		public string Address
		{
			get { return  strAddress; }
			set { strAddress = value; }
		}
		/// <summary>
		/// Tel
		/// 
		/// </summary>
		public string Tel
		{
			get { return  strTel; }
			set { strTel = value; }
		}
		/// <summary>
		/// Email
		/// 
		/// </summary>
		public string Email
		{
			get { return  strEmail; }
			set { strEmail = value; }
		}
		/// <summary>
		/// ProvinceID
		/// 
		/// </summary>
		public string ProvinceID
		{
			get { return  strProvinceID; }
			set { strProvinceID = value; }
		}
		/// <summary>
		/// DistrictID
		/// 
		/// </summary>
		public string DistrictID
		{
			get { return  strDistrictID; }
			set { strDistrictID = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_HospitalID.ToUpper()) && !Convert.IsDBNull(reader[C_HospitalID])) this.intHospitalID = Convert.ToInt32(reader[C_HospitalID]);
					if (reader.GetName(i).ToUpper().Equals(C_HospitalCode.ToUpper()) && !Convert.IsDBNull(reader[C_HospitalCode])) this.strHospitalCode = Convert.ToString(reader[C_HospitalCode]);
					if (reader.GetName(i).ToUpper().Equals(C_HospitalName.ToUpper()) && !Convert.IsDBNull(reader[C_HospitalName])) this.strHospitalName = Convert.ToString(reader[C_HospitalName]);
					if (reader.GetName(i).ToUpper().Equals(C_Address.ToUpper()) && !Convert.IsDBNull(reader[C_Address])) this.strAddress = Convert.ToString(reader[C_Address]);
					if (reader.GetName(i).ToUpper().Equals(C_Tel.ToUpper()) && !Convert.IsDBNull(reader[C_Tel])) this.strTel = Convert.ToString(reader[C_Tel]);
					if (reader.GetName(i).ToUpper().Equals(C_Email.ToUpper()) && !Convert.IsDBNull(reader[C_Email])) this.strEmail = Convert.ToString(reader[C_Email]);
					if (reader.GetName(i).ToUpper().Equals(C_ProvinceID.ToUpper()) && !Convert.IsDBNull(reader[C_ProvinceID])) this.strProvinceID = Convert.ToString(reader[C_ProvinceID]);
					if (reader.GetName(i).ToUpper().Equals(C_DistrictID.ToUpper()) && !Convert.IsDBNull(reader[C_DistrictID])) this.strDistrictID = Convert.ToString(reader[C_DistrictID]);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong INS_Hospital", objEx);
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
				if (!Convert.IsDBNull(drw[C_HospitalID])) this.intHospitalID = Convert.ToInt32(drw[C_HospitalID]);
				if (!Convert.IsDBNull(drw[C_HospitalCode])) this.strHospitalCode = Convert.ToString(drw[C_HospitalCode]);
				if (!Convert.IsDBNull(drw[C_HospitalName])) this.strHospitalName = Convert.ToString(drw[C_HospitalName]);
				if (!Convert.IsDBNull(drw[C_Address])) this.strAddress = Convert.ToString(drw[C_Address]);
				if (!Convert.IsDBNull(drw[C_Tel])) this.strTel = Convert.ToString(drw[C_Tel]);
				if (!Convert.IsDBNull(drw[C_Email])) this.strEmail = Convert.ToString(drw[C_Email]);
				if (!Convert.IsDBNull(drw[C_ProvinceID])) this.strProvinceID = Convert.ToString(drw[C_ProvinceID]);
				if (!Convert.IsDBNull(drw[C_DistrictID])) this.strDistrictID = Convert.ToString(drw[C_DistrictID]);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong INS_Hospital", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: INS_Hospital_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("INS_Hospital_GET");
				objIData.AddParameter(P_HospitalID, this.intHospitalID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin INS_Hospital", objEx);
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
		/// Store: INS_Hospital_GET 
		///</summary>
		/// <returns> INS_Hospital </returns>
		public INS_Hospital Get(int? intHospitalID)
		{
			INS_Hospital obj = new INS_Hospital();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.HospitalID = intHospitalID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : INS_Hospital
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong INS_Hospital", objEx);
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
		/// Search : INS_Hospital
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong INS_Hospital", objEx);
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
		/// Search : INS_Hospital
		/// Lấy hết dữ liệu
		/// Store: INS_Hospital_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("INS_Hospital_GETALL");
		}

		///<summary>
		/// Search : INS_Hospital
		/// Tìm dữ liệu
		/// Store: INS_Hospital_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("INS_Hospital_SEARCH",pars);
		}

		///<summary>
		/// Add : INS_Hospital
		/// Thêm dữ liệu
		/// Store: INS_Hospital_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("INS_Hospital_ADD");
				objIData.AddParameter(P_HospitalCode, this.strHospitalCode);
				objIData.AddParameter(P_HospitalName, this.strHospitalName);
				objIData.AddParameter(P_Address, this.strAddress);
				objIData.AddParameter(P_Tel, this.strTel);
				objIData.AddParameter(P_Email, this.strEmail);
				objIData.AddParameter(P_ProvinceID, this.strProvinceID);
				objIData.AddParameter(P_DistrictID, this.strDistrictID);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_OrderIndex, this.intOrderIndex);
				objIData.AddParameter(P_IsDefault, this.bolIsDefault);
				objIData.AddParameter(P_IsActived, this.bolIsActived);
				objIData.AddParameter(P_IsSystem, this.bolIsSystem);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				this.intHospitalID = Convert.ToInt32(objIData.ExecStoreToString());
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin INS_Hospital", objEx);
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
		/// Update : INS_Hospital
		/// Cập nhật dữ liệu
		/// Store: INS_Hospital_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("INS_Hospital_EDIT");
				objIData.AddParameter(P_HospitalID, this.intHospitalID);
				objIData.AddParameter(P_HospitalCode, this.strHospitalCode);
				objIData.AddParameter(P_HospitalName, this.strHospitalName);
				objIData.AddParameter(P_Address, this.strAddress);
				objIData.AddParameter(P_Tel, this.strTel);
				objIData.AddParameter(P_Email, this.strEmail);
				objIData.AddParameter(P_ProvinceID, this.strProvinceID);
				objIData.AddParameter(P_DistrictID, this.strDistrictID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin INS_Hospital", objEx);
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
		/// Delete : INS_Hospital
		/// Xóa dữ liệu
		/// Store: INS_Hospital_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("INS_Hospital_DELETE");
				objIData.AddParameter(P_HospitalID, this.intHospitalID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin INS_Hospital", objEx);
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
		/// Store: INS_Hospital_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(int? intHospitalID)
		{
			this.intHospitalID = intHospitalID;
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

		public INS_Hospital()
		{
		}
		public INS_Hospital(int? intHospitalID)
		{
			this.intHospitalID = intHospitalID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_HospitalID = "@" + C_HospitalID;
		public const String P_HospitalCode = "@" + C_HospitalCode;
		public const String P_HospitalName = "@" + C_HospitalName;
		public const String P_Address = "@" + C_Address;
		public const String P_Tel = "@" + C_Tel;
		public const String P_Email = "@" + C_Email;
		public const String P_ProvinceID = "@" + C_ProvinceID;
		public const String P_DistrictID = "@" + C_DistrictID;
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

		public const String C_HospitalID = "HospitalID";
		public const String C_HospitalCode = "HospitalCode";
		public const String C_HospitalName = "HospitalName";
		public const String C_Address = "Address";
		public const String C_Tel = "Tel";
		public const String C_Email = "Email";
		public const String C_ProvinceID = "ProvinceID";
		public const String C_DistrictID = "DistrictID";
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
