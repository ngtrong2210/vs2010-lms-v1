
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
	public partial class SIM_ScheduleBackup
	{	
		#region Member Variables

		private long? lngBackupID = null;
		private DateTime? dtmBackupDateTime = null;
		private int? intYearID = null;
		private int? intSemester = null;
		private int? intWeek = null;
		private string strScienceID = null;
		private string strCourseID = null;
		private string strBranchID = null;
		private string strSpecialBranchID = null;
		private string strTrainingLevelID = null;
		private string strTrainingType = null;
		private string strClassID = null;
		private string strCreatedUser = null;
		private DateTime? dtmCreatedDate = null;
		private IData objIData = null;
		private bool bolIsExistIData = false;
		private Exception objErrorException = null;

		#endregion

		#region Properties 

		/// <summary>
		/// BackupID
		/// 
		/// </summary>
		public long? BackupID
		{
			get { return  lngBackupID; }
			set { lngBackupID = value; }
		}
		/// <summary>
		/// BackupDateTime
		/// 
		/// </summary>
		public DateTime? BackupDateTime
		{
			get { return  dtmBackupDateTime; }
			set { dtmBackupDateTime = value; }
		}
		/// <summary>
		/// YearID
		/// 
		/// </summary>
		public int? YearID
		{
			get { return  intYearID; }
			set { intYearID = value; }
		}
		/// <summary>
		/// Semester
		/// 
		/// </summary>
		public int? Semester
		{
			get { return  intSemester; }
			set { intSemester = value; }
		}
		/// <summary>
		/// Week
		/// 
		/// </summary>
		public int? Week
		{
			get { return  intWeek; }
			set { intWeek = value; }
		}
		/// <summary>
		/// ScienceID
		/// 
		/// </summary>
		public string ScienceID
		{
			get { return  strScienceID; }
			set { strScienceID = value; }
		}
		/// <summary>
		/// CourseID
		/// 
		/// </summary>
		public string CourseID
		{
			get { return  strCourseID; }
			set { strCourseID = value; }
		}
		/// <summary>
		/// BranchID
		/// 
		/// </summary>
		public string BranchID
		{
			get { return  strBranchID; }
			set { strBranchID = value; }
		}
		/// <summary>
		/// SpecialBranchID
		/// 
		/// </summary>
		public string SpecialBranchID
		{
			get { return  strSpecialBranchID; }
			set { strSpecialBranchID = value; }
		}
		/// <summary>
		/// TrainingLevelID
		/// 
		/// </summary>
		public string TrainingLevelID
		{
			get { return  strTrainingLevelID; }
			set { strTrainingLevelID = value; }
		}
		/// <summary>
		/// TrainingType
		/// 
		/// </summary>
		public string TrainingType
		{
			get { return  strTrainingType; }
			set { strTrainingType = value; }
		}
		/// <summary>
		/// ClassID
		/// 
		/// </summary>
		public string ClassID
		{
			get { return  strClassID; }
			set { strClassID = value; }
		}
		/// <summary>
		/// CreatedUser
		/// 
		/// </summary>
		public string CreatedUser
		{
			get { return  strCreatedUser; }
			set { strCreatedUser = value; }
		}
		/// <summary>
		/// CreatedDate
		/// 
		/// </summary>
		public DateTime? CreatedDate
		{
			get { return  dtmCreatedDate; }
			set { dtmCreatedDate = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_BackupID.ToUpper()) && !Convert.IsDBNull(reader[C_BackupID])) this.lngBackupID = Convert.ToInt64(reader[C_BackupID]);
					if (reader.GetName(i).ToUpper().Equals(C_BackupDateTime.ToUpper()) && !Convert.IsDBNull(reader[C_BackupDateTime])) this.dtmBackupDateTime = Convert.ToDateTime(reader[C_BackupDateTime]);
					if (reader.GetName(i).ToUpper().Equals(C_YearID.ToUpper()) && !Convert.IsDBNull(reader[C_YearID])) this.intYearID = Convert.ToInt32(reader[C_YearID]);
					if (reader.GetName(i).ToUpper().Equals(C_Semester.ToUpper()) && !Convert.IsDBNull(reader[C_Semester])) this.intSemester = Convert.ToInt32(reader[C_Semester]);
					if (reader.GetName(i).ToUpper().Equals(C_Week.ToUpper()) && !Convert.IsDBNull(reader[C_Week])) this.intWeek = Convert.ToInt32(reader[C_Week]);
					if (reader.GetName(i).ToUpper().Equals(C_ScienceID.ToUpper()) && !Convert.IsDBNull(reader[C_ScienceID])) this.strScienceID = Convert.ToString(reader[C_ScienceID]);
					if (reader.GetName(i).ToUpper().Equals(C_CourseID.ToUpper()) && !Convert.IsDBNull(reader[C_CourseID])) this.strCourseID = Convert.ToString(reader[C_CourseID]);
					if (reader.GetName(i).ToUpper().Equals(C_BranchID.ToUpper()) && !Convert.IsDBNull(reader[C_BranchID])) this.strBranchID = Convert.ToString(reader[C_BranchID]);
					if (reader.GetName(i).ToUpper().Equals(C_SpecialBranchID.ToUpper()) && !Convert.IsDBNull(reader[C_SpecialBranchID])) this.strSpecialBranchID = Convert.ToString(reader[C_SpecialBranchID]);
					if (reader.GetName(i).ToUpper().Equals(C_TrainingLevelID.ToUpper()) && !Convert.IsDBNull(reader[C_TrainingLevelID])) this.strTrainingLevelID = Convert.ToString(reader[C_TrainingLevelID]);
					if (reader.GetName(i).ToUpper().Equals(C_TrainingType.ToUpper()) && !Convert.IsDBNull(reader[C_TrainingType])) this.strTrainingType = Convert.ToString(reader[C_TrainingType]);
					if (reader.GetName(i).ToUpper().Equals(C_ClassID.ToUpper()) && !Convert.IsDBNull(reader[C_ClassID])) this.strClassID = Convert.ToString(reader[C_ClassID]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_ScheduleBackup", objEx);
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
				if (!Convert.IsDBNull(drw[C_BackupID])) this.lngBackupID = Convert.ToInt64(drw[C_BackupID]);
				if (!Convert.IsDBNull(drw[C_BackupDateTime])) this.dtmBackupDateTime = Convert.ToDateTime(drw[C_BackupDateTime]);
				if (!Convert.IsDBNull(drw[C_YearID])) this.intYearID = Convert.ToInt32(drw[C_YearID]);
				if (!Convert.IsDBNull(drw[C_Semester])) this.intSemester = Convert.ToInt32(drw[C_Semester]);
				if (!Convert.IsDBNull(drw[C_Week])) this.intWeek = Convert.ToInt32(drw[C_Week]);
				if (!Convert.IsDBNull(drw[C_ScienceID])) this.strScienceID = Convert.ToString(drw[C_ScienceID]);
				if (!Convert.IsDBNull(drw[C_CourseID])) this.strCourseID = Convert.ToString(drw[C_CourseID]);
				if (!Convert.IsDBNull(drw[C_BranchID])) this.strBranchID = Convert.ToString(drw[C_BranchID]);
				if (!Convert.IsDBNull(drw[C_SpecialBranchID])) this.strSpecialBranchID = Convert.ToString(drw[C_SpecialBranchID]);
				if (!Convert.IsDBNull(drw[C_TrainingLevelID])) this.strTrainingLevelID = Convert.ToString(drw[C_TrainingLevelID]);
				if (!Convert.IsDBNull(drw[C_TrainingType])) this.strTrainingType = Convert.ToString(drw[C_TrainingType]);
				if (!Convert.IsDBNull(drw[C_ClassID])) this.strClassID = Convert.ToString(drw[C_ClassID]);
				if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
				if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_ScheduleBackup", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_ScheduleBackup_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ScheduleBackup_GET");
				objIData.AddParameter(P_BackupID, this.lngBackupID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_ScheduleBackup", objEx);
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
		/// Store: SIM_ScheduleBackup_GET 
		///</summary>
		/// <returns> SIM_ScheduleBackup </returns>
		public SIM_ScheduleBackup Get(long? lngBackupID)
		{
			SIM_ScheduleBackup obj = new SIM_ScheduleBackup();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.BackupID = lngBackupID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_ScheduleBackup
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_ScheduleBackup", objEx);
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
		/// Search : SIM_ScheduleBackup
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_ScheduleBackup", objEx);
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
		/// Search : SIM_ScheduleBackup
		/// Lấy hết dữ liệu
		/// Store: SIM_ScheduleBackup_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_ScheduleBackup_GETALL");
		}

		///<summary>
		/// Search : SIM_ScheduleBackup
		/// Tìm dữ liệu
		/// Store: SIM_ScheduleBackup_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_ScheduleBackup_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_ScheduleBackup
		/// Thêm dữ liệu
		/// Store: SIM_ScheduleBackup_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ScheduleBackup_ADD");
				objIData.AddParameter(P_BackupDateTime, this.dtmBackupDateTime);
				objIData.AddParameter(P_YearID, this.intYearID);
				objIData.AddParameter(P_Semester, this.intSemester);
				objIData.AddParameter(P_Week, this.intWeek);
				objIData.AddParameter(P_ScienceID, this.strScienceID);
				objIData.AddParameter(P_CourseID, this.strCourseID);
				objIData.AddParameter(P_BranchID, this.strBranchID);
				objIData.AddParameter(P_SpecialBranchID, this.strSpecialBranchID);
				objIData.AddParameter(P_TrainingLevelID, this.strTrainingLevelID);
				objIData.AddParameter(P_TrainingType, this.strTrainingType);
				objIData.AddParameter(P_ClassID, this.strClassID);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				this.lngBackupID = Convert.ToInt32(objIData.ExecStoreToString());
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_ScheduleBackup", objEx);
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
		/// Update : SIM_ScheduleBackup
		/// Cập nhật dữ liệu
		/// Store: SIM_ScheduleBackup_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ScheduleBackup_EDIT");
				objIData.AddParameter(P_BackupID, this.lngBackupID);
				objIData.AddParameter(P_BackupDateTime, this.dtmBackupDateTime);
				objIData.AddParameter(P_YearID, this.intYearID);
				objIData.AddParameter(P_Semester, this.intSemester);
				objIData.AddParameter(P_Week, this.intWeek);
				objIData.AddParameter(P_ScienceID, this.strScienceID);
				objIData.AddParameter(P_CourseID, this.strCourseID);
				objIData.AddParameter(P_BranchID, this.strBranchID);
				objIData.AddParameter(P_SpecialBranchID, this.strSpecialBranchID);
				objIData.AddParameter(P_TrainingLevelID, this.strTrainingLevelID);
				objIData.AddParameter(P_TrainingType, this.strTrainingType);
				objIData.AddParameter(P_ClassID, this.strClassID);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_ScheduleBackup", objEx);
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
		/// Delete : SIM_ScheduleBackup
		/// Xóa dữ liệu
		/// Store: SIM_ScheduleBackup_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ScheduleBackup_DELETE");
				objIData.AddParameter(P_BackupID, this.lngBackupID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_ScheduleBackup", objEx);
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
		/// Store: SIM_ScheduleBackup_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(long? lngBackupID)
		{
			this.lngBackupID = lngBackupID;
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

		public SIM_ScheduleBackup()
		{
		}
		public SIM_ScheduleBackup(long? lngBackupID)
		{
			this.lngBackupID = lngBackupID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_BackupID = "@" + C_BackupID;
		public const String P_BackupDateTime = "@" + C_BackupDateTime;
		public const String P_YearID = "@" + C_YearID;
		public const String P_Semester = "@" + C_Semester;
		public const String P_Week = "@" + C_Week;
		public const String P_ScienceID = "@" + C_ScienceID;
		public const String P_CourseID = "@" + C_CourseID;
		public const String P_BranchID = "@" + C_BranchID;
		public const String P_SpecialBranchID = "@" + C_SpecialBranchID;
		public const String P_TrainingLevelID = "@" + C_TrainingLevelID;
		public const String P_TrainingType = "@" + C_TrainingType;
		public const String P_ClassID = "@" + C_ClassID;
		public const String P_CreatedUser = "@" + C_CreatedUser;
		public const String P_CreatedDate = "@" + C_CreatedDate;

		#endregion //Parameter names

		#region Column Names

		public const String C_BackupID = "BackupID";
		public const String C_BackupDateTime = "BackupDateTime";
		public const String C_YearID = "YearID";
		public const String C_Semester = "Semester";
		public const String C_Week = "Week";
		public const String C_ScienceID = "ScienceID";
		public const String C_CourseID = "CourseID";
		public const String C_BranchID = "BranchID";
		public const String C_SpecialBranchID = "SpecialBranchID";
		public const String C_TrainingLevelID = "TrainingLevelID";
		public const String C_TrainingType = "TrainingType";
		public const String C_ClassID = "ClassID";
		public const String C_CreatedUser = "CreatedUser";
		public const String C_CreatedDate = "CreatedDate";

		#endregion //Column names

		#endregion Variable Static		
	}
}
