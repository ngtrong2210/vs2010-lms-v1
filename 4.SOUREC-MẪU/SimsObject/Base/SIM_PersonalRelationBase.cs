
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
	public partial class SIM_PersonalRelation
	{	
		#region Member Variables

		private long? lngPersonalRelationID = null;
		private string strFullName = null;//Họ tên
		private bool bolGender = false;//Giới tính
		private int? intBirthDay = null;//Ngày sinh
		private int? intBirthMonth = null;//Tháng sinh
		private int? intBirthYear = null;//Năm sinh
		private string strBirthDateText = null;//Ngày sinh
		private string strPersonID = null;//CMND
		private string strJob = null;//Nghề nghiệp
		private string strAddress = null;//Địa chỉ
		private string strTel = null;//Điện thoại
		private string strDescription = null;
		private DateTime? dtmCreatedDate = null;//Ngày tạo
		private string strCreatedUser = null;//Người tạo
		private DateTime? dtmUpdatedDate = null;//Ngày cập nhật cuối
		private string strUpdatedUser = null;//Người cập nhật cuối
		private bool bolIsDeleted = false;//Đã xóa
		private DateTime? dtmDeletedDate = null;//Ngày xóa
		private string strDeletedUser = null;//Người xóa
		private IData objIData = null;
		private bool bolIsExistIData = false;
		private Exception objErrorException = null;

		#endregion

		#region Properties 

		/// <summary>
		/// PersonalRelationID
		/// 
		/// </summary>
		public long? PersonalRelationID
		{
			get { return  lngPersonalRelationID; }
			set { lngPersonalRelationID = value; }
		}
		/// <summary>
		/// FullName
		/// Họ tên
		/// </summary>
		public string FullName
		{
			get { return  strFullName; }
			set { strFullName = value; }
		}
		/// <summary>
		/// Gender
		/// Giới tính
		/// </summary>
		public bool Gender
		{
			get { return  bolGender; }
			set { bolGender = value; }
		}
		/// <summary>
		/// BirthDay
		/// Ngày sinh
		/// </summary>
		public int? BirthDay
		{
			get { return  intBirthDay; }
			set { intBirthDay = value; }
		}
		/// <summary>
		/// BirthMonth
		/// Tháng sinh
		/// </summary>
		public int? BirthMonth
		{
			get { return  intBirthMonth; }
			set { intBirthMonth = value; }
		}
		/// <summary>
		/// BirthYear
		/// Năm sinh
		/// </summary>
		public int? BirthYear
		{
			get { return  intBirthYear; }
			set { intBirthYear = value; }
		}
		/// <summary>
		/// BirthDateText
		/// Ngày sinh
		/// </summary>
		public string BirthDateText
		{
			get { return  strBirthDateText; }
			set { strBirthDateText = value; }
		}
		/// <summary>
		/// PersonID
		/// CMND
		/// </summary>
		public string PersonID
		{
			get { return  strPersonID; }
			set { strPersonID = value; }
		}
		/// <summary>
		/// Job
		/// Nghề nghiệp
		/// </summary>
		public string Job
		{
			get { return  strJob; }
			set { strJob = value; }
		}
		/// <summary>
		/// Address
		/// Địa chỉ
		/// </summary>
		public string Address
		{
			get { return  strAddress; }
			set { strAddress = value; }
		}
		/// <summary>
		/// Tel
		/// Điện thoại
		/// </summary>
		public string Tel
		{
			get { return  strTel; }
			set { strTel = value; }
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
		/// Ngày xóa
		/// </summary>
		public DateTime? DeletedDate
		{
			get { return  dtmDeletedDate; }
			set { dtmDeletedDate = value; }
		}
		/// <summary>
		/// DeletedUser
		/// Người xóa
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
					if (reader.GetName(i).ToUpper().Equals(C_PersonalRelationID.ToUpper()) && !Convert.IsDBNull(reader[C_PersonalRelationID])) this.lngPersonalRelationID = Convert.ToInt64(reader[C_PersonalRelationID]);
					if (reader.GetName(i).ToUpper().Equals(C_FullName.ToUpper()) && !Convert.IsDBNull(reader[C_FullName])) this.strFullName = Convert.ToString(reader[C_FullName]);
					if (reader.GetName(i).ToUpper().Equals(C_Gender.ToUpper()) && !Convert.IsDBNull(reader[C_Gender])) this.bolGender = Convert.ToBoolean(reader[C_Gender]);
					if (reader.GetName(i).ToUpper().Equals(C_BirthDay.ToUpper()) && !Convert.IsDBNull(reader[C_BirthDay])) this.intBirthDay = Convert.ToInt32(reader[C_BirthDay]);
					if (reader.GetName(i).ToUpper().Equals(C_BirthMonth.ToUpper()) && !Convert.IsDBNull(reader[C_BirthMonth])) this.intBirthMonth = Convert.ToInt32(reader[C_BirthMonth]);
					if (reader.GetName(i).ToUpper().Equals(C_BirthYear.ToUpper()) && !Convert.IsDBNull(reader[C_BirthYear])) this.intBirthYear = Convert.ToInt32(reader[C_BirthYear]);
					if (reader.GetName(i).ToUpper().Equals(C_BirthDateText.ToUpper()) && !Convert.IsDBNull(reader[C_BirthDateText])) this.strBirthDateText = Convert.ToString(reader[C_BirthDateText]);
					if (reader.GetName(i).ToUpper().Equals(C_PersonID.ToUpper()) && !Convert.IsDBNull(reader[C_PersonID])) this.strPersonID = Convert.ToString(reader[C_PersonID]);
					if (reader.GetName(i).ToUpper().Equals(C_Job.ToUpper()) && !Convert.IsDBNull(reader[C_Job])) this.strJob = Convert.ToString(reader[C_Job]);
					if (reader.GetName(i).ToUpper().Equals(C_Address.ToUpper()) && !Convert.IsDBNull(reader[C_Address])) this.strAddress = Convert.ToString(reader[C_Address]);
					if (reader.GetName(i).ToUpper().Equals(C_Tel.ToUpper()) && !Convert.IsDBNull(reader[C_Tel])) this.strTel = Convert.ToString(reader[C_Tel]);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_PersonalRelation", objEx);
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
				if (!Convert.IsDBNull(drw[C_PersonalRelationID])) this.lngPersonalRelationID = Convert.ToInt64(drw[C_PersonalRelationID]);
				if (!Convert.IsDBNull(drw[C_FullName])) this.strFullName = Convert.ToString(drw[C_FullName]);
				if (!Convert.IsDBNull(drw[C_Gender])) this.bolGender = Convert.ToBoolean(drw[C_Gender]);
				if (!Convert.IsDBNull(drw[C_BirthDay])) this.intBirthDay = Convert.ToInt32(drw[C_BirthDay]);
				if (!Convert.IsDBNull(drw[C_BirthMonth])) this.intBirthMonth = Convert.ToInt32(drw[C_BirthMonth]);
				if (!Convert.IsDBNull(drw[C_BirthYear])) this.intBirthYear = Convert.ToInt32(drw[C_BirthYear]);
				if (!Convert.IsDBNull(drw[C_BirthDateText])) this.strBirthDateText = Convert.ToString(drw[C_BirthDateText]);
				if (!Convert.IsDBNull(drw[C_PersonID])) this.strPersonID = Convert.ToString(drw[C_PersonID]);
				if (!Convert.IsDBNull(drw[C_Job])) this.strJob = Convert.ToString(drw[C_Job]);
				if (!Convert.IsDBNull(drw[C_Address])) this.strAddress = Convert.ToString(drw[C_Address]);
				if (!Convert.IsDBNull(drw[C_Tel])) this.strTel = Convert.ToString(drw[C_Tel]);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_PersonalRelation", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_PersonalRelation_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_PersonalRelation_GET");
				objIData.AddParameter(P_PersonalRelationID, this.lngPersonalRelationID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_PersonalRelation", objEx);
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
		/// Store: SIM_PersonalRelation_GET 
		///</summary>
		/// <returns> SIM_PersonalRelation </returns>
		public SIM_PersonalRelation Get(long? lngPersonalRelationID)
		{
			SIM_PersonalRelation obj = new SIM_PersonalRelation();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.PersonalRelationID = lngPersonalRelationID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_PersonalRelation
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_PersonalRelation", objEx);
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
		/// Search : SIM_PersonalRelation
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_PersonalRelation", objEx);
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
		/// Search : SIM_PersonalRelation
		/// Lấy hết dữ liệu
		/// Store: SIM_PersonalRelation_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_PersonalRelation_GETALL");
		}

		///<summary>
		/// Search : SIM_PersonalRelation
		/// Tìm dữ liệu
		/// Store: SIM_PersonalRelation_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_PersonalRelation_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_PersonalRelation
		/// Thêm dữ liệu
		/// Store: SIM_PersonalRelation_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_PersonalRelation_ADD");
				objIData.AddParameter(P_FullName, this.strFullName);
				objIData.AddParameter(P_Gender, this.bolGender);
				objIData.AddParameter(P_BirthDay, this.intBirthDay);
				objIData.AddParameter(P_BirthMonth, this.intBirthMonth);
				objIData.AddParameter(P_BirthYear, this.intBirthYear);
				objIData.AddParameter(P_BirthDateText, this.strBirthDateText);
				objIData.AddParameter(P_PersonID, this.strPersonID);
				objIData.AddParameter(P_Job, this.strJob);
				objIData.AddParameter(P_Address, this.strAddress);
				objIData.AddParameter(P_Tel, this.strTel);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				this.lngPersonalRelationID = Convert.ToInt32(objIData.ExecStoreToString());
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_PersonalRelation", objEx);
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
		/// Update : SIM_PersonalRelation
		/// Cập nhật dữ liệu
		/// Store: SIM_PersonalRelation_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_PersonalRelation_EDIT");
				objIData.AddParameter(P_PersonalRelationID, this.lngPersonalRelationID);
				objIData.AddParameter(P_FullName, this.strFullName);
				objIData.AddParameter(P_Gender, this.bolGender);
				objIData.AddParameter(P_BirthDay, this.intBirthDay);
				objIData.AddParameter(P_BirthMonth, this.intBirthMonth);
				objIData.AddParameter(P_BirthYear, this.intBirthYear);
				objIData.AddParameter(P_BirthDateText, this.strBirthDateText);
				objIData.AddParameter(P_PersonID, this.strPersonID);
				objIData.AddParameter(P_Job, this.strJob);
				objIData.AddParameter(P_Address, this.strAddress);
				objIData.AddParameter(P_Tel, this.strTel);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_PersonalRelation", objEx);
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
		/// Delete : SIM_PersonalRelation
		/// Xóa dữ liệu
		/// Store: SIM_PersonalRelation_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_PersonalRelation_DELETE");
				objIData.AddParameter(P_PersonalRelationID, this.lngPersonalRelationID);
				objIData.AddParameter(P_DeletedUser, this.strDeletedUser);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_PersonalRelation", objEx);
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
		/// Store: SIM_PersonalRelation_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(long? lngPersonalRelationID, string strDeletedUser)
		{
			this.lngPersonalRelationID = lngPersonalRelationID;
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

		public SIM_PersonalRelation()
		{
		}
		public SIM_PersonalRelation(long? lngPersonalRelationID)
		{
			this.lngPersonalRelationID = lngPersonalRelationID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_PersonalRelationID = "@" + C_PersonalRelationID;
		public const String P_FullName = "@" + C_FullName;
		public const String P_Gender = "@" + C_Gender;
		public const String P_BirthDay = "@" + C_BirthDay;
		public const String P_BirthMonth = "@" + C_BirthMonth;
		public const String P_BirthYear = "@" + C_BirthYear;
		public const String P_BirthDateText = "@" + C_BirthDateText;
		public const String P_PersonID = "@" + C_PersonID;
		public const String P_Job = "@" + C_Job;
		public const String P_Address = "@" + C_Address;
		public const String P_Tel = "@" + C_Tel;
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

		public const String C_PersonalRelationID = "PersonalRelationID";
		public const String C_FullName = "FullName";
		public const String C_Gender = "Gender";
		public const String C_BirthDay = "BirthDay";
		public const String C_BirthMonth = "BirthMonth";
		public const String C_BirthYear = "BirthYear";
		public const String C_BirthDateText = "BirthDateText";
		public const String C_PersonID = "PersonID";
		public const String C_Job = "Job";
		public const String C_Address = "Address";
		public const String C_Tel = "Tel";
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
