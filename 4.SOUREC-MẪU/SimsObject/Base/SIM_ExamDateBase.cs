
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
	/// Created date 	: 11/20/2016 
	/// Description 
	/// </summary>	
	public partial class SIM_ExamDate
	{	
		#region Member Variables

		private int? intExamDateID = null;//Mã kì thi
		private DateTime? dtmExamDate = null;
		private string strExamDateName = null;//Tên kì thi tốt nghiệp
		private string strDescription = null;//Mô tả
		private bool bolIsDefault = false;//Là dữ liệu mặc định
		private bool bolIsActived = false;//Đã kích hoạt (Sẵn dùng)
		private long? lngOrderIndex = null;
		private DateTime? dtmCreatedDate = null;//Ngày tạo
		private string strCreatedUser = null;//Người tạo
		private DateTime? dtmUpdatedDate = null;//Ngày cập nhật cuối
		private string strUpdatedUser = null;//Người cập nhật cuối
		private int? intYearID = null;
		private int? intSemester = null;
		private DateTime? dtmStartAt = null;//Ngày bắt đầu
		private DateTime? dtmFinishAt = null;//Ngày kết thúc
		private bool bolIsGraduation = false;//Là kỳ thi tốt nghiệp
		private IData objIData = null;
		private bool bolIsExistIData = false;
		private Exception objErrorException = null;

		#endregion

		#region Properties 

		/// <summary>
		/// ExamDateID
		/// Mã kì thi
		/// </summary>
		public int? ExamDateID
		{
			get { return  intExamDateID; }
			set { intExamDateID = value; }
		}
		/// <summary>
		/// ExamDate
		/// 
		/// </summary>
		public DateTime? ExamDate
		{
			get { return  dtmExamDate; }
			set { dtmExamDate = value; }
		}
		/// <summary>
		/// ExamDateName
		/// Tên kì thi tốt nghiệp
		/// </summary>
		public string ExamDateName
		{
			get { return  strExamDateName; }
			set { strExamDateName = value; }
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
		/// StartAt
		/// Ngày bắt đầu
		/// </summary>
		public DateTime? StartAt
		{
			get { return  dtmStartAt; }
			set { dtmStartAt = value; }
		}
		/// <summary>
		/// FinishAt
		/// Ngày kết thúc
		/// </summary>
		public DateTime? FinishAt
		{
			get { return  dtmFinishAt; }
			set { dtmFinishAt = value; }
		}
		/// <summary>
		/// IsGraduation
		/// Là kỳ thi tốt nghiệp
		/// </summary>
		public bool IsGraduation
		{
			get { return  bolIsGraduation; }
			set { bolIsGraduation = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_ExamDateID.ToUpper()) && !Convert.IsDBNull(reader[C_ExamDateID])) this.intExamDateID = Convert.ToInt32(reader[C_ExamDateID]);
					if (reader.GetName(i).ToUpper().Equals(C_ExamDate.ToUpper()) && !Convert.IsDBNull(reader[C_ExamDate])) this.dtmExamDate = Convert.ToDateTime(reader[C_ExamDate]);
					if (reader.GetName(i).ToUpper().Equals(C_ExamDateName.ToUpper()) && !Convert.IsDBNull(reader[C_ExamDateName])) this.strExamDateName = Convert.ToString(reader[C_ExamDateName]);
					if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
					if (reader.GetName(i).ToUpper().Equals(C_IsDefault.ToUpper()) && !Convert.IsDBNull(reader[C_IsDefault])) this.bolIsDefault = Convert.ToBoolean(reader[C_IsDefault]);
					if (reader.GetName(i).ToUpper().Equals(C_IsActived.ToUpper()) && !Convert.IsDBNull(reader[C_IsActived])) this.bolIsActived = Convert.ToBoolean(reader[C_IsActived]);
					if (reader.GetName(i).ToUpper().Equals(C_OrderIndex.ToUpper()) && !Convert.IsDBNull(reader[C_OrderIndex])) this.lngOrderIndex = Convert.ToInt64(reader[C_OrderIndex]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(reader[C_UpdatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(reader[C_UpdatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_YearID.ToUpper()) && !Convert.IsDBNull(reader[C_YearID])) this.intYearID = Convert.ToInt32(reader[C_YearID]);
					if (reader.GetName(i).ToUpper().Equals(C_Semester.ToUpper()) && !Convert.IsDBNull(reader[C_Semester])) this.intSemester = Convert.ToInt32(reader[C_Semester]);
					if (reader.GetName(i).ToUpper().Equals(C_StartAt.ToUpper()) && !Convert.IsDBNull(reader[C_StartAt])) this.dtmStartAt = Convert.ToDateTime(reader[C_StartAt]);
					if (reader.GetName(i).ToUpper().Equals(C_FinishAt.ToUpper()) && !Convert.IsDBNull(reader[C_FinishAt])) this.dtmFinishAt = Convert.ToDateTime(reader[C_FinishAt]);
					if (reader.GetName(i).ToUpper().Equals(C_IsGraduation.ToUpper()) && !Convert.IsDBNull(reader[C_IsGraduation])) this.bolIsGraduation = Convert.ToBoolean(reader[C_IsGraduation]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_ExamDate", objEx);
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
				if (!Convert.IsDBNull(drw[C_ExamDateID])) this.intExamDateID = Convert.ToInt32(drw[C_ExamDateID]);
				if (!Convert.IsDBNull(drw[C_ExamDate])) this.dtmExamDate = Convert.ToDateTime(drw[C_ExamDate]);
				if (!Convert.IsDBNull(drw[C_ExamDateName])) this.strExamDateName = Convert.ToString(drw[C_ExamDateName]);
				if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
				if (!Convert.IsDBNull(drw[C_IsDefault])) this.bolIsDefault = Convert.ToBoolean(drw[C_IsDefault]);
				if (!Convert.IsDBNull(drw[C_IsActived])) this.bolIsActived = Convert.ToBoolean(drw[C_IsActived]);
				if (!Convert.IsDBNull(drw[C_OrderIndex])) this.lngOrderIndex = Convert.ToInt64(drw[C_OrderIndex]);
				if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
				if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
				if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
				if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
				if (!Convert.IsDBNull(drw[C_YearID])) this.intYearID = Convert.ToInt32(drw[C_YearID]);
				if (!Convert.IsDBNull(drw[C_Semester])) this.intSemester = Convert.ToInt32(drw[C_Semester]);
				if (!Convert.IsDBNull(drw[C_StartAt])) this.dtmStartAt = Convert.ToDateTime(drw[C_StartAt]);
				if (!Convert.IsDBNull(drw[C_FinishAt])) this.dtmFinishAt = Convert.ToDateTime(drw[C_FinishAt]);
				if (!Convert.IsDBNull(drw[C_IsGraduation])) this.bolIsGraduation = Convert.ToBoolean(drw[C_IsGraduation]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_ExamDate", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_ExamDate_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ExamDate_GET");
				objIData.AddParameter(P_ExamDateID, this.intExamDateID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_ExamDate", objEx);
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
		/// Store: SIM_ExamDate_GET 
		///</summary>
		/// <returns> SIM_ExamDate </returns>
		public SIM_ExamDate Get(int? intExamDateID)
		{
			SIM_ExamDate obj = new SIM_ExamDate();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.ExamDateID = intExamDateID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_ExamDate
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_ExamDate", objEx);
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
		/// Search : SIM_ExamDate
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_ExamDate", objEx);
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
		/// Search : SIM_ExamDate
		/// Lấy hết dữ liệu
		/// Store: SIM_ExamDate_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_ExamDate_GETALL");
		}

		///<summary>
		/// Search : SIM_ExamDate
		/// Tìm dữ liệu
		/// Store: SIM_ExamDate_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_ExamDate_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_ExamDate
		/// Thêm dữ liệu
		/// Store: SIM_ExamDate_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ExamDate_ADD");
				objIData.AddParameter(P_ExamDate, this.dtmExamDate);
				objIData.AddParameter(P_ExamDateName, this.strExamDateName);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_IsDefault, this.bolIsDefault);
				objIData.AddParameter(P_IsActived, this.bolIsActived);
				objIData.AddParameter(P_OrderIndex, this.lngOrderIndex);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				objIData.AddParameter(P_YearID, this.intYearID);
				objIData.AddParameter(P_Semester, this.intSemester);
				objIData.AddParameter(P_StartAt, this.dtmStartAt);
				objIData.AddParameter(P_FinishAt, this.dtmFinishAt);
				objIData.AddParameter(P_IsGraduation, this.bolIsGraduation);
				this.intExamDateID = Convert.ToInt32(objIData.ExecStoreToString());
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_ExamDate", objEx);
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
		/// Update : SIM_ExamDate
		/// Cập nhật dữ liệu
		/// Store: SIM_ExamDate_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ExamDate_EDIT");
				objIData.AddParameter(P_ExamDateID, this.intExamDateID);
				objIData.AddParameter(P_ExamDate, this.dtmExamDate);
				objIData.AddParameter(P_ExamDateName, this.strExamDateName);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_IsDefault, this.bolIsDefault);
				objIData.AddParameter(P_IsActived, this.bolIsActived);
				objIData.AddParameter(P_OrderIndex, this.lngOrderIndex);
				objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
				objIData.AddParameter(P_YearID, this.intYearID);
				objIData.AddParameter(P_Semester, this.intSemester);
				objIData.AddParameter(P_StartAt, this.dtmStartAt);
				objIData.AddParameter(P_FinishAt, this.dtmFinishAt);
				objIData.AddParameter(P_IsGraduation, this.bolIsGraduation);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_ExamDate", objEx);
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
		/// Delete : SIM_ExamDate
		/// Xóa dữ liệu
		/// Store: SIM_ExamDate_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ExamDate_DELETE");
				objIData.AddParameter(P_ExamDateID, this.intExamDateID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_ExamDate", objEx);
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
		/// Store: SIM_ExamDate_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(int? intExamDateID)
		{
			this.intExamDateID = intExamDateID;
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

		public SIM_ExamDate()
		{
		}
		public SIM_ExamDate(int? intExamDateID)
		{
			this.intExamDateID = intExamDateID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_ExamDateID = "@" + C_ExamDateID;
		public const String P_ExamDate = "@" + C_ExamDate;
		public const String P_ExamDateName = "@" + C_ExamDateName;
		public const String P_Description = "@" + C_Description;
		public const String P_IsDefault = "@" + C_IsDefault;
		public const String P_IsActived = "@" + C_IsActived;
		public const String P_OrderIndex = "@" + C_OrderIndex;
		public const String P_CreatedDate = "@" + C_CreatedDate;
		public const String P_CreatedUser = "@" + C_CreatedUser;
		public const String P_UpdatedDate = "@" + C_UpdatedDate;
		public const String P_UpdatedUser = "@" + C_UpdatedUser;
		public const String P_YearID = "@" + C_YearID;
		public const String P_Semester = "@" + C_Semester;
		public const String P_StartAt = "@" + C_StartAt;
		public const String P_FinishAt = "@" + C_FinishAt;
		public const String P_IsGraduation = "@" + C_IsGraduation;

		#endregion //Parameter names

		#region Column Names

		public const String C_ExamDateID = "ExamDateID";
		public const String C_ExamDate = "ExamDate";
		public const String C_ExamDateName = "ExamDateName";
		public const String C_Description = "Description";
		public const String C_IsDefault = "IsDefault";
		public const String C_IsActived = "IsActived";
		public const String C_OrderIndex = "OrderIndex";
		public const String C_CreatedDate = "CreatedDate";
		public const String C_CreatedUser = "CreatedUser";
		public const String C_UpdatedDate = "UpdatedDate";
		public const String C_UpdatedUser = "UpdatedUser";
		public const String C_YearID = "YearID";
		public const String C_Semester = "Semester";
		public const String C_StartAt = "StartAt";
		public const String C_FinishAt = "FinishAt";
		public const String C_IsGraduation = "IsGraduation";

		#endregion //Column names

		#endregion Variable Static		
	}
}
