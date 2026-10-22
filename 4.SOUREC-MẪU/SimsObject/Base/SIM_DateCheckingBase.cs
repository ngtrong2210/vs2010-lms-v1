
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
	public partial class SIM_DateChecking
	{	
		#region Member Variables

		private long? lngDateCheckingID = null;//Mã tự tăng
		private long? lngStudentID = null;//Mã sinh viên
		private int? intYearID = null;//Mã niên học
		private int? intSemester = null;//Học kỳ: 1, 2
		private DateTime? dtmDate = null;//Ngày học
		private int? intPermissionQuantity = null;//Số tiết nghỉ có phép
		private int? intNoPermissionQuantity = null;//Số tiết nghỉ không phép
		private string strSession1 = null;//Vắng ca 1,null là không vắng, P.Có phép, K. Không phép
		private string strSession2 = null;//Vắng ca 2,null là không vắng, P.Có phép, K. Không phép
		private string strSession3 = null;//Vắng ca 3,null là không vắng, P.Có phép, K. Không phép
		private string strSession4 = null;//Vắng ca 4,null là không vắng, P.Có phép, K. Không phép
		private string strSession5 = null;//Vắng ca 4,null là không vắng, P.Có phép, K. Không phép
		private string strSession6 = null;//Vắng ca 4,null là không vắng, P.Có phép, K. Không phép
		private string strDescription = null;//Mô tả
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
		/// DateCheckingID
		/// Mã tự tăng
		/// </summary>
		public long? DateCheckingID
		{
			get { return  lngDateCheckingID; }
			set { lngDateCheckingID = value; }
		}
		/// <summary>
		/// StudentID
		/// Mã sinh viên
		/// </summary>
		public long? StudentID
		{
			get { return  lngStudentID; }
			set { lngStudentID = value; }
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
		/// Date
		/// Ngày học
		/// </summary>
		public DateTime? Date
		{
			get { return  dtmDate; }
			set { dtmDate = value; }
		}
		/// <summary>
		/// PermissionQuantity
		/// Số tiết nghỉ có phép
		/// </summary>
		public int? PermissionQuantity
		{
			get { return  intPermissionQuantity; }
			set { intPermissionQuantity = value; }
		}
		/// <summary>
		/// NoPermissionQuantity
		/// Số tiết nghỉ không phép
		/// </summary>
		public int? NoPermissionQuantity
		{
			get { return  intNoPermissionQuantity; }
			set { intNoPermissionQuantity = value; }
		}
		/// <summary>
		/// Session1
		/// Vắng ca 1,null là không vắng, P.Có phép, K. Không phép
		/// </summary>
		public string Session1
		{
			get { return  strSession1; }
			set { strSession1 = value; }
		}
		/// <summary>
		/// Session2
		/// Vắng ca 2,null là không vắng, P.Có phép, K. Không phép
		/// </summary>
		public string Session2
		{
			get { return  strSession2; }
			set { strSession2 = value; }
		}
		/// <summary>
		/// Session3
		/// Vắng ca 3,null là không vắng, P.Có phép, K. Không phép
		/// </summary>
		public string Session3
		{
			get { return  strSession3; }
			set { strSession3 = value; }
		}
		/// <summary>
		/// Session4
		/// Vắng ca 4,null là không vắng, P.Có phép, K. Không phép
		/// </summary>
		public string Session4
		{
			get { return  strSession4; }
			set { strSession4 = value; }
		}
		/// <summary>
		/// Session5
		/// Vắng ca 4,null là không vắng, P.Có phép, K. Không phép
		/// </summary>
		public string Session5
		{
			get { return  strSession5; }
			set { strSession5 = value; }
		}
		/// <summary>
		/// Session6
		/// Vắng ca 4,null là không vắng, P.Có phép, K. Không phép
		/// </summary>
		public string Session6
		{
			get { return  strSession6; }
			set { strSession6 = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_DateCheckingID.ToUpper()) && !Convert.IsDBNull(reader[C_DateCheckingID])) this.lngDateCheckingID = Convert.ToInt64(reader[C_DateCheckingID]);
					if (reader.GetName(i).ToUpper().Equals(C_StudentID.ToUpper()) && !Convert.IsDBNull(reader[C_StudentID])) this.lngStudentID = Convert.ToInt64(reader[C_StudentID]);
					if (reader.GetName(i).ToUpper().Equals(C_YearID.ToUpper()) && !Convert.IsDBNull(reader[C_YearID])) this.intYearID = Convert.ToInt32(reader[C_YearID]);
					if (reader.GetName(i).ToUpper().Equals(C_Semester.ToUpper()) && !Convert.IsDBNull(reader[C_Semester])) this.intSemester = Convert.ToInt32(reader[C_Semester]);
					if (reader.GetName(i).ToUpper().Equals(C_Date.ToUpper()) && !Convert.IsDBNull(reader[C_Date])) this.dtmDate = Convert.ToDateTime(reader[C_Date]);
					if (reader.GetName(i).ToUpper().Equals(C_PermissionQuantity.ToUpper()) && !Convert.IsDBNull(reader[C_PermissionQuantity])) this.intPermissionQuantity = Convert.ToInt32(reader[C_PermissionQuantity]);
					if (reader.GetName(i).ToUpper().Equals(C_NoPermissionQuantity.ToUpper()) && !Convert.IsDBNull(reader[C_NoPermissionQuantity])) this.intNoPermissionQuantity = Convert.ToInt32(reader[C_NoPermissionQuantity]);
					if (reader.GetName(i).ToUpper().Equals(C_Session1.ToUpper()) && !Convert.IsDBNull(reader[C_Session1])) this.strSession1 = Convert.ToString(reader[C_Session1]);
					if (reader.GetName(i).ToUpper().Equals(C_Session2.ToUpper()) && !Convert.IsDBNull(reader[C_Session2])) this.strSession2 = Convert.ToString(reader[C_Session2]);
					if (reader.GetName(i).ToUpper().Equals(C_Session3.ToUpper()) && !Convert.IsDBNull(reader[C_Session3])) this.strSession3 = Convert.ToString(reader[C_Session3]);
					if (reader.GetName(i).ToUpper().Equals(C_Session4.ToUpper()) && !Convert.IsDBNull(reader[C_Session4])) this.strSession4 = Convert.ToString(reader[C_Session4]);
					if (reader.GetName(i).ToUpper().Equals(C_Session5.ToUpper()) && !Convert.IsDBNull(reader[C_Session5])) this.strSession5 = Convert.ToString(reader[C_Session5]);
					if (reader.GetName(i).ToUpper().Equals(C_Session6.ToUpper()) && !Convert.IsDBNull(reader[C_Session6])) this.strSession6 = Convert.ToString(reader[C_Session6]);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_DateChecking", objEx);
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
				if (!Convert.IsDBNull(drw[C_DateCheckingID])) this.lngDateCheckingID = Convert.ToInt64(drw[C_DateCheckingID]);
				if (!Convert.IsDBNull(drw[C_StudentID])) this.lngStudentID = Convert.ToInt64(drw[C_StudentID]);
				if (!Convert.IsDBNull(drw[C_YearID])) this.intYearID = Convert.ToInt32(drw[C_YearID]);
				if (!Convert.IsDBNull(drw[C_Semester])) this.intSemester = Convert.ToInt32(drw[C_Semester]);
				if (!Convert.IsDBNull(drw[C_Date])) this.dtmDate = Convert.ToDateTime(drw[C_Date]);
				if (!Convert.IsDBNull(drw[C_PermissionQuantity])) this.intPermissionQuantity = Convert.ToInt32(drw[C_PermissionQuantity]);
				if (!Convert.IsDBNull(drw[C_NoPermissionQuantity])) this.intNoPermissionQuantity = Convert.ToInt32(drw[C_NoPermissionQuantity]);
				if (!Convert.IsDBNull(drw[C_Session1])) this.strSession1 = Convert.ToString(drw[C_Session1]);
				if (!Convert.IsDBNull(drw[C_Session2])) this.strSession2 = Convert.ToString(drw[C_Session2]);
				if (!Convert.IsDBNull(drw[C_Session3])) this.strSession3 = Convert.ToString(drw[C_Session3]);
				if (!Convert.IsDBNull(drw[C_Session4])) this.strSession4 = Convert.ToString(drw[C_Session4]);
				if (!Convert.IsDBNull(drw[C_Session5])) this.strSession5 = Convert.ToString(drw[C_Session5]);
				if (!Convert.IsDBNull(drw[C_Session6])) this.strSession6 = Convert.ToString(drw[C_Session6]);
				if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
				if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
				if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
				if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
				if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_DateChecking", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_DateChecking_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_DateChecking_GET");
				objIData.AddParameter(P_DateCheckingID, this.lngDateCheckingID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_DateChecking", objEx);
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
		/// Store: SIM_DateChecking_GET 
		///</summary>
		/// <returns> SIM_DateChecking </returns>
		public SIM_DateChecking Get(long? lngDateCheckingID)
		{
			SIM_DateChecking obj = new SIM_DateChecking();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.DateCheckingID = lngDateCheckingID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_DateChecking
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_DateChecking", objEx);
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
		/// Search : SIM_DateChecking
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_DateChecking", objEx);
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
		/// Search : SIM_DateChecking
		/// Lấy hết dữ liệu
		/// Store: SIM_DateChecking_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_DateChecking_GETALL");
		}

		///<summary>
		/// Search : SIM_DateChecking
		/// Tìm dữ liệu
		/// Store: SIM_DateChecking_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_DateChecking_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_DateChecking
		/// Thêm dữ liệu
		/// Store: SIM_DateChecking_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_DateChecking_ADD");
				objIData.AddParameter(P_StudentID, this.lngStudentID);
				objIData.AddParameter(P_YearID, this.intYearID);
				objIData.AddParameter(P_Semester, this.intSemester);
				objIData.AddParameter(P_Date, this.dtmDate);
				objIData.AddParameter(P_PermissionQuantity, this.intPermissionQuantity);
				objIData.AddParameter(P_NoPermissionQuantity, this.intNoPermissionQuantity);
				objIData.AddParameter(P_Session1, this.strSession1);
				objIData.AddParameter(P_Session2, this.strSession2);
				objIData.AddParameter(P_Session3, this.strSession3);
				objIData.AddParameter(P_Session4, this.strSession4);
				objIData.AddParameter(P_Session5, this.strSession5);
				objIData.AddParameter(P_Session6, this.strSession6);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				this.lngDateCheckingID = Convert.ToInt32(objIData.ExecStoreToString());
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_DateChecking", objEx);
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
		/// Update : SIM_DateChecking
		/// Cập nhật dữ liệu
		/// Store: SIM_DateChecking_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_DateChecking_EDIT");
				objIData.AddParameter(P_DateCheckingID, this.lngDateCheckingID);
				objIData.AddParameter(P_StudentID, this.lngStudentID);
				objIData.AddParameter(P_YearID, this.intYearID);
				objIData.AddParameter(P_Semester, this.intSemester);
				objIData.AddParameter(P_Date, this.dtmDate);
				objIData.AddParameter(P_PermissionQuantity, this.intPermissionQuantity);
				objIData.AddParameter(P_NoPermissionQuantity, this.intNoPermissionQuantity);
				objIData.AddParameter(P_Session1, this.strSession1);
				objIData.AddParameter(P_Session2, this.strSession2);
				objIData.AddParameter(P_Session3, this.strSession3);
				objIData.AddParameter(P_Session4, this.strSession4);
				objIData.AddParameter(P_Session5, this.strSession5);
				objIData.AddParameter(P_Session6, this.strSession6);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_DateChecking", objEx);
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
		/// Delete : SIM_DateChecking
		/// Xóa dữ liệu
		/// Store: SIM_DateChecking_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_DateChecking_DELETE");
				objIData.AddParameter(P_DateCheckingID, this.lngDateCheckingID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_DateChecking", objEx);
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
		/// Store: SIM_DateChecking_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(long? lngDateCheckingID)
		{
			this.lngDateCheckingID = lngDateCheckingID;
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

		public SIM_DateChecking()
		{
		}
		public SIM_DateChecking(long? lngDateCheckingID)
		{
			this.lngDateCheckingID = lngDateCheckingID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_DateCheckingID = "@" + C_DateCheckingID;
		public const String P_StudentID = "@" + C_StudentID;
		public const String P_YearID = "@" + C_YearID;
		public const String P_Semester = "@" + C_Semester;
		public const String P_Date = "@" + C_Date;
		public const String P_PermissionQuantity = "@" + C_PermissionQuantity;
		public const String P_NoPermissionQuantity = "@" + C_NoPermissionQuantity;
		public const String P_Session1 = "@" + C_Session1;
		public const String P_Session2 = "@" + C_Session2;
		public const String P_Session3 = "@" + C_Session3;
		public const String P_Session4 = "@" + C_Session4;
		public const String P_Session5 = "@" + C_Session5;
		public const String P_Session6 = "@" + C_Session6;
		public const String P_Description = "@" + C_Description;
		public const String P_CreatedDate = "@" + C_CreatedDate;
		public const String P_CreatedUser = "@" + C_CreatedUser;
		public const String P_UpdatedDate = "@" + C_UpdatedDate;
		public const String P_UpdatedUser = "@" + C_UpdatedUser;

		#endregion //Parameter names

		#region Column Names

		public const String C_DateCheckingID = "DateCheckingID";
		public const String C_StudentID = "StudentID";
		public const String C_YearID = "YearID";
		public const String C_Semester = "Semester";
		public const String C_Date = "Date";
		public const String C_PermissionQuantity = "PermissionQuantity";
		public const String C_NoPermissionQuantity = "NoPermissionQuantity";
		public const String C_Session1 = "Session1";
		public const String C_Session2 = "Session2";
		public const String C_Session3 = "Session3";
		public const String C_Session4 = "Session4";
		public const String C_Session5 = "Session5";
		public const String C_Session6 = "Session6";
		public const String C_Description = "Description";
		public const String C_CreatedDate = "CreatedDate";
		public const String C_CreatedUser = "CreatedUser";
		public const String C_UpdatedDate = "UpdatedDate";
		public const String C_UpdatedUser = "UpdatedUser";

		#endregion //Column names

		#endregion Variable Static		
	}
}
