
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
	public partial class SIM_LevelStudent
	{	
		#region Member Variables

		private int? intLevelStudentID = null;
		private string strLevelStudentName = null;//Trình độ học vấn của học sinh sinh viên
		private bool bolIsBasicLevel = false;//Là trình độ cơ sở (ví dụ trung học cơ sở, hoặc dưới)
		private bool bolIsActived = false;
		private DateTime? dtmCreatedDate = null;//Ngày tạo
		private string strCreatedUser = null;//Người tạo
		private DateTime? dtmUpdatedDate = null;//Ngày cập nhật cuối
		private string strUpdatedUser = null;//Người cập nhật cuối
		private string strLevelValue = null;//Bậc của trình độ văn hóa (cấp 1,2,3); 4. TC, 5. CĐ, 6. ĐH, 7. Cao Học
		private IData objIData = null;
		private bool bolIsExistIData = false;
		private Exception objErrorException = null;

		#endregion

		#region Properties 

		/// <summary>
		/// LevelStudentID
		/// 
		/// </summary>
		public int? LevelStudentID
		{
			get { return  intLevelStudentID; }
			set { intLevelStudentID = value; }
		}
		/// <summary>
		/// LevelStudentName
		/// Trình độ học vấn của học sinh sinh viên
		/// </summary>
		public string LevelStudentName
		{
			get { return  strLevelStudentName; }
			set { strLevelStudentName = value; }
		}
		/// <summary>
		/// IsBasicLevel
		/// Là trình độ cơ sở (ví dụ trung học cơ sở, hoặc dưới)
		/// </summary>
		public bool IsBasicLevel
		{
			get { return  bolIsBasicLevel; }
			set { bolIsBasicLevel = value; }
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
		/// LevelValue
		/// Bậc của trình độ văn hóa (cấp 1,2,3); 4. TC, 5. CĐ, 6. ĐH, 7. Cao Học
		/// </summary>
		public string LevelValue
		{
			get { return  strLevelValue; }
			set { strLevelValue = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_LevelStudentID.ToUpper()) && !Convert.IsDBNull(reader[C_LevelStudentID])) this.intLevelStudentID = Convert.ToInt32(reader[C_LevelStudentID]);
					if (reader.GetName(i).ToUpper().Equals(C_LevelStudentName.ToUpper()) && !Convert.IsDBNull(reader[C_LevelStudentName])) this.strLevelStudentName = Convert.ToString(reader[C_LevelStudentName]);
					if (reader.GetName(i).ToUpper().Equals(C_IsBasicLevel.ToUpper()) && !Convert.IsDBNull(reader[C_IsBasicLevel])) this.bolIsBasicLevel = Convert.ToBoolean(reader[C_IsBasicLevel]);
					if (reader.GetName(i).ToUpper().Equals(C_IsActived.ToUpper()) && !Convert.IsDBNull(reader[C_IsActived])) this.bolIsActived = Convert.ToBoolean(reader[C_IsActived]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(reader[C_UpdatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(reader[C_UpdatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_LevelValue.ToUpper()) && !Convert.IsDBNull(reader[C_LevelValue])) this.strLevelValue = Convert.ToString(reader[C_LevelValue]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_LevelStudent", objEx);
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
				if (!Convert.IsDBNull(drw[C_LevelStudentID])) this.intLevelStudentID = Convert.ToInt32(drw[C_LevelStudentID]);
				if (!Convert.IsDBNull(drw[C_LevelStudentName])) this.strLevelStudentName = Convert.ToString(drw[C_LevelStudentName]);
				if (!Convert.IsDBNull(drw[C_IsBasicLevel])) this.bolIsBasicLevel = Convert.ToBoolean(drw[C_IsBasicLevel]);
				if (!Convert.IsDBNull(drw[C_IsActived])) this.bolIsActived = Convert.ToBoolean(drw[C_IsActived]);
				if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
				if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
				if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
				if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
				if (!Convert.IsDBNull(drw[C_LevelValue])) this.strLevelValue = Convert.ToString(drw[C_LevelValue]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_LevelStudent", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_LevelStudent_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_LevelStudent_GET");
				objIData.AddParameter(P_LevelStudentID, this.intLevelStudentID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_LevelStudent", objEx);
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
		/// Store: SIM_LevelStudent_GET 
		///</summary>
		/// <returns> SIM_LevelStudent </returns>
		public SIM_LevelStudent Get(int? intLevelStudentID)
		{
			SIM_LevelStudent obj = new SIM_LevelStudent();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.LevelStudentID = intLevelStudentID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_LevelStudent
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_LevelStudent", objEx);
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
		/// Search : SIM_LevelStudent
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_LevelStudent", objEx);
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
		/// Search : SIM_LevelStudent
		/// Lấy hết dữ liệu
		/// Store: SIM_LevelStudent_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_LevelStudent_GETALL");
		}

		///<summary>
		/// Search : SIM_LevelStudent
		/// Tìm dữ liệu
		/// Store: SIM_LevelStudent_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_LevelStudent_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_LevelStudent
		/// Thêm dữ liệu
		/// Store: SIM_LevelStudent_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_LevelStudent_ADD");
				objIData.AddParameter(P_LevelStudentName, this.strLevelStudentName);
				objIData.AddParameter(P_IsBasicLevel, this.bolIsBasicLevel);
				objIData.AddParameter(P_IsActived, this.bolIsActived);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				objIData.AddParameter(P_LevelValue, this.strLevelValue);
				this.intLevelStudentID = Convert.ToInt32(objIData.ExecStoreToString());
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_LevelStudent", objEx);
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
		/// Update : SIM_LevelStudent
		/// Cập nhật dữ liệu
		/// Store: SIM_LevelStudent_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_LevelStudent_EDIT");
				objIData.AddParameter(P_LevelStudentID, this.intLevelStudentID);
				objIData.AddParameter(P_LevelStudentName, this.strLevelStudentName);
				objIData.AddParameter(P_IsBasicLevel, this.bolIsBasicLevel);
				objIData.AddParameter(P_IsActived, this.bolIsActived);
				objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
				objIData.AddParameter(P_LevelValue, this.strLevelValue);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_LevelStudent", objEx);
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
		/// Delete : SIM_LevelStudent
		/// Xóa dữ liệu
		/// Store: SIM_LevelStudent_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_LevelStudent_DELETE");
				objIData.AddParameter(P_LevelStudentID, this.intLevelStudentID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_LevelStudent", objEx);
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
		/// Store: SIM_LevelStudent_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(int? intLevelStudentID)
		{
			this.intLevelStudentID = intLevelStudentID;
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

		public SIM_LevelStudent()
		{
		}
		public SIM_LevelStudent(int? intLevelStudentID)
		{
			this.intLevelStudentID = intLevelStudentID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_LevelStudentID = "@" + C_LevelStudentID;
		public const String P_LevelStudentName = "@" + C_LevelStudentName;
		public const String P_IsBasicLevel = "@" + C_IsBasicLevel;
		public const String P_IsActived = "@" + C_IsActived;
		public const String P_CreatedDate = "@" + C_CreatedDate;
		public const String P_CreatedUser = "@" + C_CreatedUser;
		public const String P_UpdatedDate = "@" + C_UpdatedDate;
		public const String P_UpdatedUser = "@" + C_UpdatedUser;
		public const String P_LevelValue = "@" + C_LevelValue;

		#endregion //Parameter names

		#region Column Names

		public const String C_LevelStudentID = "LevelStudentID";
		public const String C_LevelStudentName = "LevelStudentName";
		public const String C_IsBasicLevel = "IsBasicLevel";
		public const String C_IsActived = "IsActived";
		public const String C_CreatedDate = "CreatedDate";
		public const String C_CreatedUser = "CreatedUser";
		public const String C_UpdatedDate = "UpdatedDate";
		public const String C_UpdatedUser = "UpdatedUser";
		public const String C_LevelValue = "LevelValue";

		#endregion //Column names

		#endregion Variable Static		
	}
}
