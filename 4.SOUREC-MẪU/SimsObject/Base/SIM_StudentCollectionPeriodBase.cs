
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
	/// Created date 	: 11/28/2012 
	/// Description 
	/// </summary>	
	public partial class SIM_StudentCollectionPeriod
	{	
		#region Member Variables

		private string strStudentCollectionPeriodID = null;//Mã đợt tuyển sinh
		private string strStudentCollectionPeriodName = null;//Tên đợt tuyển sinh
		private int? intStartNo = null;//Số bắt đầu hồ sơ
		private int? intFinishNo = null;//Số kết thúc hồ sơ
		private DateTime? dtmStartDate = null;//Ngày bắt đầu
		private DateTime? dtmFinishDate = null;//Ngày kết thúc
		private string strCourseID = null;//Mã Khoá học
		private string strTrainingType = null;//Loại đào tạo
		private string strTrainingLevelID = null;//Mã bậc đào tạo
		private int? intCollectionType = null;//Loại tuyển sinh: 1. Xét 4  điểm tk của 4 năm cuối cấp (CĐ), 2. Xét 6 môn văn hóa (dành cho TC),  3. Xét tốt nghiệp nghề (dành cho liên thông)
		private string strDescription = null;
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
		/// StudentCollectionPeriodID
		/// Mã đợt tuyển sinh
		/// </summary>
		public string StudentCollectionPeriodID
		{
			get { return  strStudentCollectionPeriodID; }
			set { strStudentCollectionPeriodID = value; }
		}
		/// <summary>
		/// StudentCollectionPeriodName
		/// Tên đợt tuyển sinh
		/// </summary>
		public string StudentCollectionPeriodName
		{
			get { return  strStudentCollectionPeriodName; }
			set { strStudentCollectionPeriodName = value; }
		}
		/// <summary>
		/// StartNo
		/// Số bắt đầu hồ sơ
		/// </summary>
		public int? StartNo
		{
			get { return  intStartNo; }
			set { intStartNo = value; }
		}
		/// <summary>
		/// FinishNo
		/// Số kết thúc hồ sơ
		/// </summary>
		public int? FinishNo
		{
			get { return  intFinishNo; }
			set { intFinishNo = value; }
		}
		/// <summary>
		/// StartDate
		/// Ngày bắt đầu
		/// </summary>
		public DateTime? StartDate
		{
			get { return  dtmStartDate; }
			set { dtmStartDate = value; }
		}
		/// <summary>
		/// FinishDate
		/// Ngày kết thúc
		/// </summary>
		public DateTime? FinishDate
		{
			get { return  dtmFinishDate; }
			set { dtmFinishDate = value; }
		}
		/// <summary>
		/// CourseID
		/// Mã Khoá học
		/// </summary>
		public string CourseID
		{
			get { return  strCourseID; }
			set { strCourseID = value; }
		}
		/// <summary>
		/// TrainingType
		/// Loại đào tạo
		/// </summary>
		public string TrainingType
		{
			get { return  strTrainingType; }
			set { strTrainingType = value; }
		}
		/// <summary>
		/// TrainingLevelID
		/// Mã bậc đào tạo
		/// </summary>
		public string TrainingLevelID
		{
			get { return  strTrainingLevelID; }
			set { strTrainingLevelID = value; }
		}
		/// <summary>
		/// CollectionType
		/// Loại tuyển sinh: 1. Xét 4  điểm tk của 4 năm cuối cấp (CĐ), 2. Xét 6 môn văn hóa (dành cho TC),  3. Xét tốt nghiệp nghề (dành cho liên thông)
		/// </summary>
		public int? CollectionType
		{
			get { return  intCollectionType; }
			set { intCollectionType = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_StudentCollectionPeriodID.ToUpper()) && !Convert.IsDBNull(reader[C_StudentCollectionPeriodID])) this.strStudentCollectionPeriodID = Convert.ToString(reader[C_StudentCollectionPeriodID]);
					if (reader.GetName(i).ToUpper().Equals(C_StudentCollectionPeriodName.ToUpper()) && !Convert.IsDBNull(reader[C_StudentCollectionPeriodName])) this.strStudentCollectionPeriodName = Convert.ToString(reader[C_StudentCollectionPeriodName]);
					if (reader.GetName(i).ToUpper().Equals(C_StartNo.ToUpper()) && !Convert.IsDBNull(reader[C_StartNo])) this.intStartNo = Convert.ToInt32(reader[C_StartNo]);
					if (reader.GetName(i).ToUpper().Equals(C_FinishNo.ToUpper()) && !Convert.IsDBNull(reader[C_FinishNo])) this.intFinishNo = Convert.ToInt32(reader[C_FinishNo]);
					if (reader.GetName(i).ToUpper().Equals(C_StartDate.ToUpper()) && !Convert.IsDBNull(reader[C_StartDate])) this.dtmStartDate = Convert.ToDateTime(reader[C_StartDate]);
					if (reader.GetName(i).ToUpper().Equals(C_FinishDate.ToUpper()) && !Convert.IsDBNull(reader[C_FinishDate])) this.dtmFinishDate = Convert.ToDateTime(reader[C_FinishDate]);
					if (reader.GetName(i).ToUpper().Equals(C_CourseID.ToUpper()) && !Convert.IsDBNull(reader[C_CourseID])) this.strCourseID = Convert.ToString(reader[C_CourseID]);
					if (reader.GetName(i).ToUpper().Equals(C_TrainingType.ToUpper()) && !Convert.IsDBNull(reader[C_TrainingType])) this.strTrainingType = Convert.ToString(reader[C_TrainingType]);
					if (reader.GetName(i).ToUpper().Equals(C_TrainingLevelID.ToUpper()) && !Convert.IsDBNull(reader[C_TrainingLevelID])) this.strTrainingLevelID = Convert.ToString(reader[C_TrainingLevelID]);
					if (reader.GetName(i).ToUpper().Equals(C_CollectionType.ToUpper()) && !Convert.IsDBNull(reader[C_CollectionType])) this.intCollectionType = Convert.ToInt32(reader[C_CollectionType]);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_StudentCollectionPeriod", objEx);
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
				if (!Convert.IsDBNull(drw[C_StudentCollectionPeriodID])) this.strStudentCollectionPeriodID = Convert.ToString(drw[C_StudentCollectionPeriodID]);
				if (!Convert.IsDBNull(drw[C_StudentCollectionPeriodName])) this.strStudentCollectionPeriodName = Convert.ToString(drw[C_StudentCollectionPeriodName]);
				if (!Convert.IsDBNull(drw[C_StartNo])) this.intStartNo = Convert.ToInt32(drw[C_StartNo]);
				if (!Convert.IsDBNull(drw[C_FinishNo])) this.intFinishNo = Convert.ToInt32(drw[C_FinishNo]);
				if (!Convert.IsDBNull(drw[C_StartDate])) this.dtmStartDate = Convert.ToDateTime(drw[C_StartDate]);
				if (!Convert.IsDBNull(drw[C_FinishDate])) this.dtmFinishDate = Convert.ToDateTime(drw[C_FinishDate]);
				if (!Convert.IsDBNull(drw[C_CourseID])) this.strCourseID = Convert.ToString(drw[C_CourseID]);
				if (!Convert.IsDBNull(drw[C_TrainingType])) this.strTrainingType = Convert.ToString(drw[C_TrainingType]);
				if (!Convert.IsDBNull(drw[C_TrainingLevelID])) this.strTrainingLevelID = Convert.ToString(drw[C_TrainingLevelID]);
				if (!Convert.IsDBNull(drw[C_CollectionType])) this.intCollectionType = Convert.ToInt32(drw[C_CollectionType]);
				if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
				if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
				if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
				if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
				if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_StudentCollectionPeriod", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_StudentCollectionPeriod_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_StudentCollectionPeriod_GET");
				objIData.AddParameter(P_StudentCollectionPeriodID, this.strStudentCollectionPeriodID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_StudentCollectionPeriod", objEx);
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
		/// Store: SIM_StudentCollectionPeriod_GET 
		///</summary>
		/// <returns> SIM_StudentCollectionPeriod </returns>
		public SIM_StudentCollectionPeriod Get(string strStudentCollectionPeriodID)
		{
			SIM_StudentCollectionPeriod obj = new SIM_StudentCollectionPeriod();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.StudentCollectionPeriodID = strStudentCollectionPeriodID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_StudentCollectionPeriod
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_StudentCollectionPeriod", objEx);
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
		/// Search : SIM_StudentCollectionPeriod
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_StudentCollectionPeriod", objEx);
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
		/// Search : SIM_StudentCollectionPeriod
		/// Lấy hết dữ liệu
		/// Store: SIM_StudentCollectionPeriod_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_StudentCollectionPeriod_GETALL");
		}

		///<summary>
		/// Search : SIM_StudentCollectionPeriod
		/// Tìm dữ liệu
		/// Store: SIM_StudentCollectionPeriod_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_StudentCollectionPeriod_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_StudentCollectionPeriod
		/// Thêm dữ liệu
		/// Store: SIM_StudentCollectionPeriod_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_StudentCollectionPeriod_ADD");
				objIData.AddParameter(P_StudentCollectionPeriodID, this.strStudentCollectionPeriodID);
				objIData.AddParameter(P_StudentCollectionPeriodName, this.strStudentCollectionPeriodName);
				objIData.AddParameter(P_StartNo, this.intStartNo);
				objIData.AddParameter(P_FinishNo, this.intFinishNo);
				objIData.AddParameter(P_StartDate, this.dtmStartDate);
				objIData.AddParameter(P_FinishDate, this.dtmFinishDate);
				objIData.AddParameter(P_CourseID, this.strCourseID);
				objIData.AddParameter(P_TrainingType, this.strTrainingType);
				objIData.AddParameter(P_TrainingLevelID, this.strTrainingLevelID);
				objIData.AddParameter(P_CollectionType, this.intCollectionType);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_StudentCollectionPeriod", objEx);
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
		/// Update : SIM_StudentCollectionPeriod
		/// Cập nhật dữ liệu
		/// Store: SIM_StudentCollectionPeriod_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_StudentCollectionPeriod_EDIT");
				objIData.AddParameter(P_StudentCollectionPeriodID, this.strStudentCollectionPeriodID);
				objIData.AddParameter(P_StudentCollectionPeriodName, this.strStudentCollectionPeriodName);
				objIData.AddParameter(P_StartNo, this.intStartNo);
				objIData.AddParameter(P_FinishNo, this.intFinishNo);
				objIData.AddParameter(P_StartDate, this.dtmStartDate);
				objIData.AddParameter(P_FinishDate, this.dtmFinishDate);
				objIData.AddParameter(P_CourseID, this.strCourseID);
				objIData.AddParameter(P_TrainingType, this.strTrainingType);
				objIData.AddParameter(P_TrainingLevelID, this.strTrainingLevelID);
				objIData.AddParameter(P_CollectionType, this.intCollectionType);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_StudentCollectionPeriod", objEx);
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
		/// Delete : SIM_StudentCollectionPeriod
		/// Xóa dữ liệu
		/// Store: SIM_StudentCollectionPeriod_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_StudentCollectionPeriod_DELETE");
				objIData.AddParameter(P_StudentCollectionPeriodID, this.strStudentCollectionPeriodID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_StudentCollectionPeriod", objEx);
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
		/// Store: SIM_StudentCollectionPeriod_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(string strStudentCollectionPeriodID)
		{
			this.strStudentCollectionPeriodID = strStudentCollectionPeriodID;
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

		public SIM_StudentCollectionPeriod()
		{
		}
		public SIM_StudentCollectionPeriod(string strStudentCollectionPeriodID)
		{
			this.strStudentCollectionPeriodID = strStudentCollectionPeriodID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_StudentCollectionPeriodID = "@" + C_StudentCollectionPeriodID;
		public const String P_StudentCollectionPeriodName = "@" + C_StudentCollectionPeriodName;
		public const String P_StartNo = "@" + C_StartNo;
		public const String P_FinishNo = "@" + C_FinishNo;
		public const String P_StartDate = "@" + C_StartDate;
		public const String P_FinishDate = "@" + C_FinishDate;
		public const String P_CourseID = "@" + C_CourseID;
		public const String P_TrainingType = "@" + C_TrainingType;
		public const String P_TrainingLevelID = "@" + C_TrainingLevelID;
		public const String P_CollectionType = "@" + C_CollectionType;
		public const String P_Description = "@" + C_Description;
		public const String P_CreatedDate = "@" + C_CreatedDate;
		public const String P_CreatedUser = "@" + C_CreatedUser;
		public const String P_UpdatedDate = "@" + C_UpdatedDate;
		public const String P_UpdatedUser = "@" + C_UpdatedUser;

		#endregion //Parameter names

		#region Column Names

		public const String C_StudentCollectionPeriodID = "StudentCollectionPeriodID";
		public const String C_StudentCollectionPeriodName = "StudentCollectionPeriodName";
		public const String C_StartNo = "StartNo";
		public const String C_FinishNo = "FinishNo";
		public const String C_StartDate = "StartDate";
		public const String C_FinishDate = "FinishDate";
		public const String C_CourseID = "CourseID";
		public const String C_TrainingType = "TrainingType";
		public const String C_TrainingLevelID = "TrainingLevelID";
		public const String C_CollectionType = "CollectionType";
		public const String C_Description = "Description";
		public const String C_CreatedDate = "CreatedDate";
		public const String C_CreatedUser = "CreatedUser";
		public const String C_UpdatedDate = "UpdatedDate";
		public const String C_UpdatedUser = "UpdatedUser";

		#endregion //Column names

		#endregion Variable Static		
	}
}
