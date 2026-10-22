
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
	/// Created date 	: 11/2/2024 
	/// Description 
	/// </summary>	
	public partial class SIM_ClassTimeStatus
	{	
		#region Member Variables

		private Guid? guiClassTimeStatusID = null;
		private long? lngClassTimeStatusGroupID = null;//Mã nhóm lớp để quản lý tiết nghỉ của 1 ds lớp (dựa vào mã này khi edit theo ds)
		private string strClassID = null;
		private int? intYearID = null;
		private int? intSemester = null;
		private int? intLessionTime = null;//Tiết học thứ mấy tính từ 0-16
		private int? intDay = null;//Thứ trong tuần: tính từ 0-6
		private int? intStatus = null;//Trạng thái giáo viên 1:Họp, 2:Bận, 3: Nghỉ
		private IData objIData = null;
		private bool bolIsExistIData = false;
		private Exception objErrorException = null;

		#endregion

		#region Properties 

		/// <summary>
		/// ClassTimeStatusID
		/// 
		/// </summary>
		public Guid? ClassTimeStatusID
		{
			get { return  guiClassTimeStatusID; }
			set { guiClassTimeStatusID = value; }
		}
		/// <summary>
		/// ClassTimeStatusGroupID
		/// Mã nhóm lớp để quản lý tiết nghỉ của 1 ds lớp (dựa vào mã này khi edit theo ds)
		/// </summary>
		public long? ClassTimeStatusGroupID
		{
			get { return  lngClassTimeStatusGroupID; }
			set { lngClassTimeStatusGroupID = value; }
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
		/// LessionTime
		/// Tiết học thứ mấy tính từ 0-16
		/// </summary>
		public int? LessionTime
		{
			get { return  intLessionTime; }
			set { intLessionTime = value; }
		}
		/// <summary>
		/// Day
		/// Thứ trong tuần: tính từ 0-6
		/// </summary>
		public int? Day
		{
			get { return  intDay; }
			set { intDay = value; }
		}
		/// <summary>
		/// Status
		/// Trạng thái giáo viên 1:Họp, 2:Bận, 3: Nghỉ
		/// </summary>
		public int? Status
		{
			get { return  intStatus; }
			set { intStatus = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_ClassTimeStatusID.ToUpper()) && !Convert.IsDBNull(reader[C_ClassTimeStatusID])) this.guiClassTimeStatusID = new Guid(reader[C_ClassTimeStatusID].ToString());
					if (reader.GetName(i).ToUpper().Equals(C_ClassTimeStatusGroupID.ToUpper()) && !Convert.IsDBNull(reader[C_ClassTimeStatusGroupID])) this.lngClassTimeStatusGroupID = Convert.ToInt64(reader[C_ClassTimeStatusGroupID]);
					if (reader.GetName(i).ToUpper().Equals(C_ClassID.ToUpper()) && !Convert.IsDBNull(reader[C_ClassID])) this.strClassID = Convert.ToString(reader[C_ClassID]);
					if (reader.GetName(i).ToUpper().Equals(C_YearID.ToUpper()) && !Convert.IsDBNull(reader[C_YearID])) this.intYearID = Convert.ToInt32(reader[C_YearID]);
					if (reader.GetName(i).ToUpper().Equals(C_Semester.ToUpper()) && !Convert.IsDBNull(reader[C_Semester])) this.intSemester = Convert.ToInt32(reader[C_Semester]);
					if (reader.GetName(i).ToUpper().Equals(C_LessionTime.ToUpper()) && !Convert.IsDBNull(reader[C_LessionTime])) this.intLessionTime = Convert.ToInt32(reader[C_LessionTime]);
					if (reader.GetName(i).ToUpper().Equals(C_Day.ToUpper()) && !Convert.IsDBNull(reader[C_Day])) this.intDay = Convert.ToInt32(reader[C_Day]);
					if (reader.GetName(i).ToUpper().Equals(C_Status.ToUpper()) && !Convert.IsDBNull(reader[C_Status])) this.intStatus = Convert.ToInt32(reader[C_Status]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_ClassTimeStatus", objEx);
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
				if (!Convert.IsDBNull(drw[C_ClassTimeStatusID])) this.guiClassTimeStatusID = new Guid(drw[C_ClassTimeStatusID].ToString());
				if (!Convert.IsDBNull(drw[C_ClassTimeStatusGroupID])) this.lngClassTimeStatusGroupID = Convert.ToInt64(drw[C_ClassTimeStatusGroupID]);
				if (!Convert.IsDBNull(drw[C_ClassID])) this.strClassID = Convert.ToString(drw[C_ClassID]);
				if (!Convert.IsDBNull(drw[C_YearID])) this.intYearID = Convert.ToInt32(drw[C_YearID]);
				if (!Convert.IsDBNull(drw[C_Semester])) this.intSemester = Convert.ToInt32(drw[C_Semester]);
				if (!Convert.IsDBNull(drw[C_LessionTime])) this.intLessionTime = Convert.ToInt32(drw[C_LessionTime]);
				if (!Convert.IsDBNull(drw[C_Day])) this.intDay = Convert.ToInt32(drw[C_Day]);
				if (!Convert.IsDBNull(drw[C_Status])) this.intStatus = Convert.ToInt32(drw[C_Status]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_ClassTimeStatus", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_ClassTimeStatus_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ClassTimeStatus_GET");
				objIData.AddParameter(P_ClassTimeStatusID, this.guiClassTimeStatusID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_ClassTimeStatus", objEx);
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
		/// Store: SIM_ClassTimeStatus_GET 
		///</summary>
		/// <returns> SIM_ClassTimeStatus </returns>
		public SIM_ClassTimeStatus Get(Guid? guiClassTimeStatusID)
		{
			SIM_ClassTimeStatus obj = new SIM_ClassTimeStatus();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.ClassTimeStatusID = guiClassTimeStatusID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_ClassTimeStatus
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_ClassTimeStatus", objEx);
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
		/// Search : SIM_ClassTimeStatus
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_ClassTimeStatus", objEx);
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
		/// Search : SIM_ClassTimeStatus
		/// Lấy hết dữ liệu
		/// Store: SIM_ClassTimeStatus_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_ClassTimeStatus_GETALL");
		}

		///<summary>
		/// Search : SIM_ClassTimeStatus
		/// Tìm dữ liệu
		/// Store: SIM_ClassTimeStatus_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_ClassTimeStatus_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_ClassTimeStatus
		/// Thêm dữ liệu
		/// Store: SIM_ClassTimeStatus_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ClassTimeStatus_ADD");
				objIData.AddParameter(P_ClassTimeStatusID, this.guiClassTimeStatusID);
				objIData.AddParameter(P_ClassTimeStatusGroupID, this.lngClassTimeStatusGroupID);
				objIData.AddParameter(P_ClassID, this.strClassID);
				objIData.AddParameter(P_YearID, this.intYearID);
				objIData.AddParameter(P_Semester, this.intSemester);
				objIData.AddParameter(P_LessionTime, this.intLessionTime);
				objIData.AddParameter(P_Day, this.intDay);
				objIData.AddParameter(P_Status, this.intStatus);
				this.guiClassTimeStatusID =  new Guid(objIData.ExecStoreToString());
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_ClassTimeStatus", objEx);
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
		/// Update : SIM_ClassTimeStatus
		/// Cập nhật dữ liệu
		/// Store: SIM_ClassTimeStatus_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ClassTimeStatus_EDIT");
				objIData.AddParameter(P_ClassTimeStatusID, this.guiClassTimeStatusID);
				objIData.AddParameter(P_ClassTimeStatusGroupID, this.lngClassTimeStatusGroupID);
				objIData.AddParameter(P_ClassID, this.strClassID);
				objIData.AddParameter(P_YearID, this.intYearID);
				objIData.AddParameter(P_Semester, this.intSemester);
				objIData.AddParameter(P_LessionTime, this.intLessionTime);
				objIData.AddParameter(P_Day, this.intDay);
				objIData.AddParameter(P_Status, this.intStatus);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_ClassTimeStatus", objEx);
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
		/// Delete : SIM_ClassTimeStatus
		/// Xóa dữ liệu
		/// Store: SIM_ClassTimeStatus_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ClassTimeStatus_DELETE");
				objIData.AddParameter(P_ClassTimeStatusID, this.guiClassTimeStatusID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_ClassTimeStatus", objEx);
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
		/// Store: SIM_ClassTimeStatus_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(Guid? guiClassTimeStatusID)
		{
			this.guiClassTimeStatusID = guiClassTimeStatusID;
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

		public SIM_ClassTimeStatus()
		{
		}
		public SIM_ClassTimeStatus(Guid? guiClassTimeStatusID)
		{
			this.guiClassTimeStatusID = guiClassTimeStatusID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_ClassTimeStatusID = "@" + C_ClassTimeStatusID;
		public const String P_ClassTimeStatusGroupID = "@" + C_ClassTimeStatusGroupID;
		public const String P_ClassID = "@" + C_ClassID;
		public const String P_YearID = "@" + C_YearID;
		public const String P_Semester = "@" + C_Semester;
		public const String P_LessionTime = "@" + C_LessionTime;
		public const String P_Day = "@" + C_Day;
		public const String P_Status = "@" + C_Status;

		#endregion //Parameter names

		#region Column Names

		public const String C_ClassTimeStatusID = "ClassTimeStatusID";
		public const String C_ClassTimeStatusGroupID = "ClassTimeStatusGroupID";
		public const String C_ClassID = "ClassID";
		public const String C_YearID = "YearID";
		public const String C_Semester = "Semester";
		public const String C_LessionTime = "LessionTime";
		public const String C_Day = "Day";
		public const String C_Status = "Status";

		#endregion //Column names

		#endregion Variable Static		
	}
}
