
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
	public partial class SIM_School
	{	
		#region Member Variables

		private int? intSchoolID = null;//Mã quận/huyện
		private string strSchoolCode = null;//Tên quận/huyện
		private string strSchoolName = null;//Tên quận/huyện
		private string strProvinceID = null;//Mã Tỉnh thành
		private string strDescription = null;//Mô tả
		private bool bolIsDefault = false;//Là dữ liệu mặc định
		private bool bolIsActived = false;//Đã kích hoạt (Sẵn dùng)
		private long? lngOrderIndex = null;
		private DateTime? dtmCreatedDate = null;//Ngày tạo
		private string strCreatedUser = null;//Người tạo
		private DateTime? dtmUpdatedDate = null;//Ngày cập nhật cuối
		private string strUpdatedUser = null;//Người cập nhật cuối
		private string strArea = null;
		private string strAddress = null;
		private string strLevelList = null;//DS cấp học. Ví dụ cấp 2,3 thì ghi là:  2,3 (lọc lại trường khi chọn trình độ văn hóa của hs)
		private IData objIData = null;
		private bool bolIsExistIData = false;
		private Exception objErrorException = null;

		#endregion

		#region Properties 

		/// <summary>
		/// SchoolID
		/// Mã quận/huyện
		/// </summary>
		public int? SchoolID
		{
			get { return  intSchoolID; }
			set { intSchoolID = value; }
		}
		/// <summary>
		/// SchoolCode
		/// Tên quận/huyện
		/// </summary>
		public string SchoolCode
		{
			get { return  strSchoolCode; }
			set { strSchoolCode = value; }
		}
		/// <summary>
		/// SchoolName
		/// Tên quận/huyện
		/// </summary>
		public string SchoolName
		{
			get { return  strSchoolName; }
			set { strSchoolName = value; }
		}
		/// <summary>
		/// ProvinceID
		/// Mã Tỉnh thành
		/// </summary>
		public string ProvinceID
		{
			get { return  strProvinceID; }
			set { strProvinceID = value; }
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
		/// IsDefault
		/// Là dữ liệu mặc định
		/// </summary>
		public bool IsDefault
		{
			get { return  bolIsDefault; }
			set { bolIsDefault = value; }
		}
		/// <summary>
		/// IsActived
		/// Đã kích hoạt (Sẵn dùng)
		/// </summary>
		public bool IsActived
		{
			get { return  bolIsActived; }
			set { bolIsActived = value; }
		}
		/// <summary>
		/// OrderIndex
		/// 
		/// </summary>
		public long? OrderIndex
		{
			get { return  lngOrderIndex; }
			set { lngOrderIndex = value; }
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
		/// Area
		/// 
		/// </summary>
		public string Area
		{
			get { return  strArea; }
			set { strArea = value; }
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
		/// LevelList
		/// DS cấp học. Ví dụ cấp 2,3 thì ghi là:  2,3 (lọc lại trường khi chọn trình độ văn hóa của hs)
		/// </summary>
		public string LevelList
		{
			get { return  strLevelList; }
			set { strLevelList = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_SchoolID.ToUpper()) && !Convert.IsDBNull(reader[C_SchoolID])) this.intSchoolID = Convert.ToInt32(reader[C_SchoolID]);
					if (reader.GetName(i).ToUpper().Equals(C_SchoolCode.ToUpper()) && !Convert.IsDBNull(reader[C_SchoolCode])) this.strSchoolCode = Convert.ToString(reader[C_SchoolCode]);
					if (reader.GetName(i).ToUpper().Equals(C_SchoolName.ToUpper()) && !Convert.IsDBNull(reader[C_SchoolName])) this.strSchoolName = Convert.ToString(reader[C_SchoolName]);
					if (reader.GetName(i).ToUpper().Equals(C_ProvinceID.ToUpper()) && !Convert.IsDBNull(reader[C_ProvinceID])) this.strProvinceID = Convert.ToString(reader[C_ProvinceID]);
					if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
					if (reader.GetName(i).ToUpper().Equals(C_IsDefault.ToUpper()) && !Convert.IsDBNull(reader[C_IsDefault])) this.bolIsDefault = Convert.ToBoolean(reader[C_IsDefault]);
					if (reader.GetName(i).ToUpper().Equals(C_IsActived.ToUpper()) && !Convert.IsDBNull(reader[C_IsActived])) this.bolIsActived = Convert.ToBoolean(reader[C_IsActived]);
					if (reader.GetName(i).ToUpper().Equals(C_OrderIndex.ToUpper()) && !Convert.IsDBNull(reader[C_OrderIndex])) this.lngOrderIndex = Convert.ToInt64(reader[C_OrderIndex]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(reader[C_UpdatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(reader[C_UpdatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_Area.ToUpper()) && !Convert.IsDBNull(reader[C_Area])) this.strArea = Convert.ToString(reader[C_Area]);
					if (reader.GetName(i).ToUpper().Equals(C_Address.ToUpper()) && !Convert.IsDBNull(reader[C_Address])) this.strAddress = Convert.ToString(reader[C_Address]);
					if (reader.GetName(i).ToUpper().Equals(C_LevelList.ToUpper()) && !Convert.IsDBNull(reader[C_LevelList])) this.strLevelList = Convert.ToString(reader[C_LevelList]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_School", objEx);
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
				if (!Convert.IsDBNull(drw[C_SchoolID])) this.intSchoolID = Convert.ToInt32(drw[C_SchoolID]);
				if (!Convert.IsDBNull(drw[C_SchoolCode])) this.strSchoolCode = Convert.ToString(drw[C_SchoolCode]);
				if (!Convert.IsDBNull(drw[C_SchoolName])) this.strSchoolName = Convert.ToString(drw[C_SchoolName]);
				if (!Convert.IsDBNull(drw[C_ProvinceID])) this.strProvinceID = Convert.ToString(drw[C_ProvinceID]);
				if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
				if (!Convert.IsDBNull(drw[C_IsDefault])) this.bolIsDefault = Convert.ToBoolean(drw[C_IsDefault]);
				if (!Convert.IsDBNull(drw[C_IsActived])) this.bolIsActived = Convert.ToBoolean(drw[C_IsActived]);
				if (!Convert.IsDBNull(drw[C_OrderIndex])) this.lngOrderIndex = Convert.ToInt64(drw[C_OrderIndex]);
				if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
				if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
				if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
				if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
				if (!Convert.IsDBNull(drw[C_Area])) this.strArea = Convert.ToString(drw[C_Area]);
				if (!Convert.IsDBNull(drw[C_Address])) this.strAddress = Convert.ToString(drw[C_Address]);
				if (!Convert.IsDBNull(drw[C_LevelList])) this.strLevelList = Convert.ToString(drw[C_LevelList]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_School", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_School_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_School_GET");
				objIData.AddParameter(P_SchoolID, this.intSchoolID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_School", objEx);
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
		/// Store: SIM_School_GET 
		///</summary>
		/// <returns> SIM_School </returns>
		public SIM_School Get(int? intSchoolID)
		{
			SIM_School obj = new SIM_School();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.SchoolID = intSchoolID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_School
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_School", objEx);
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
		/// Search : SIM_School
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_School", objEx);
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
		/// Search : SIM_School
		/// Lấy hết dữ liệu
		/// Store: SIM_School_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_School_GETALL");
		}

		///<summary>
		/// Search : SIM_School
		/// Tìm dữ liệu
		/// Store: SIM_School_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_School_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_School
		/// Thêm dữ liệu
		/// Store: SIM_School_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_School_ADD");
				objIData.AddParameter(P_SchoolCode, this.strSchoolCode);
				objIData.AddParameter(P_SchoolName, this.strSchoolName);
				objIData.AddParameter(P_ProvinceID, this.strProvinceID);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_IsDefault, this.bolIsDefault);
				objIData.AddParameter(P_IsActived, this.bolIsActived);
				objIData.AddParameter(P_OrderIndex, this.lngOrderIndex);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				objIData.AddParameter(P_Area, this.strArea);
				objIData.AddParameter(P_Address, this.strAddress);
				objIData.AddParameter(P_LevelList, this.strLevelList);
				this.intSchoolID = Convert.ToInt32(objIData.ExecStoreToString());
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_School", objEx);
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
		/// Update : SIM_School
		/// Cập nhật dữ liệu
		/// Store: SIM_School_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_School_EDIT");
				objIData.AddParameter(P_SchoolID, this.intSchoolID);
				objIData.AddParameter(P_SchoolCode, this.strSchoolCode);
				objIData.AddParameter(P_SchoolName, this.strSchoolName);
				objIData.AddParameter(P_ProvinceID, this.strProvinceID);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_IsDefault, this.bolIsDefault);
				objIData.AddParameter(P_IsActived, this.bolIsActived);
				objIData.AddParameter(P_OrderIndex, this.lngOrderIndex);
				objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
				objIData.AddParameter(P_Area, this.strArea);
				objIData.AddParameter(P_Address, this.strAddress);
				objIData.AddParameter(P_LevelList, this.strLevelList);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_School", objEx);
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
		/// Delete : SIM_School
		/// Xóa dữ liệu
		/// Store: SIM_School_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_School_DELETE");
				objIData.AddParameter(P_SchoolID, this.intSchoolID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_School", objEx);
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
		/// Store: SIM_School_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(int? intSchoolID)
		{
			this.intSchoolID = intSchoolID;
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

		public SIM_School()
		{
		}
		public SIM_School(int? intSchoolID)
		{
			this.intSchoolID = intSchoolID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_SchoolID = "@" + C_SchoolID;
		public const String P_SchoolCode = "@" + C_SchoolCode;
		public const String P_SchoolName = "@" + C_SchoolName;
		public const String P_ProvinceID = "@" + C_ProvinceID;
		public const String P_Description = "@" + C_Description;
		public const String P_IsDefault = "@" + C_IsDefault;
		public const String P_IsActived = "@" + C_IsActived;
		public const String P_OrderIndex = "@" + C_OrderIndex;
		public const String P_CreatedDate = "@" + C_CreatedDate;
		public const String P_CreatedUser = "@" + C_CreatedUser;
		public const String P_UpdatedDate = "@" + C_UpdatedDate;
		public const String P_UpdatedUser = "@" + C_UpdatedUser;
		public const String P_Area = "@" + C_Area;
		public const String P_Address = "@" + C_Address;
		public const String P_LevelList = "@" + C_LevelList;

		#endregion //Parameter names

		#region Column Names

		public const String C_SchoolID = "SchoolID";
		public const String C_SchoolCode = "SchoolCode";
		public const String C_SchoolName = "SchoolName";
		public const String C_ProvinceID = "ProvinceID";
		public const String C_Description = "Description";
		public const String C_IsDefault = "IsDefault";
		public const String C_IsActived = "IsActived";
		public const String C_OrderIndex = "OrderIndex";
		public const String C_CreatedDate = "CreatedDate";
		public const String C_CreatedUser = "CreatedUser";
		public const String C_UpdatedDate = "UpdatedDate";
		public const String C_UpdatedUser = "UpdatedUser";
		public const String C_Area = "Area";
		public const String C_Address = "Address";
		public const String C_LevelList = "LevelList";

		#endregion //Column names

		#endregion Variable Static		
	}
}
