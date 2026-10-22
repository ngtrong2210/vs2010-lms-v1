
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
	public partial class SIM_ExamSchedule
	{	
		#region Member Variables

		private long? lngExamScheduleID = null;
		private long? lngSubjectMarkID = null;//Mã sổ điểm
		private long? lngTestScheduleID = null;//Mã lịch thi
		private string strExamCode = null;//SBD = mã số dự thi
		private int? intOrderIndex = null;//Số thứ tự sinh viên trong phòng thi
		private DateTime? dtmCreatedDate = null;//Ngày tạo
		private string strCreatedUser = null;//Người tạo
		private DateTime? dtmUpdatedDate = null;//Ngày cập nhật cuối
		private string strUpdatedUser = null;//Người cập nhật cuối
		private long? lngSameExamID = null;//Mã đề thi tương đương, phân cố định cho sinh viên trước khi thi
		private IData objIData = null;
		private bool bolIsExistIData = false;
		private Exception objErrorException = null;

		#endregion

		#region Properties 

		/// <summary>
		/// ExamScheduleID
		/// 
		/// </summary>
		public long? ExamScheduleID
		{
			get { return  lngExamScheduleID; }
			set { lngExamScheduleID = value; }
		}
		/// <summary>
		/// SubjectMarkID
		/// Mã sổ điểm
		/// </summary>
		public long? SubjectMarkID
		{
			get { return  lngSubjectMarkID; }
			set { lngSubjectMarkID = value; }
		}
		/// <summary>
		/// TestScheduleID
		/// Mã lịch thi
		/// </summary>
		public long? TestScheduleID
		{
			get { return  lngTestScheduleID; }
			set { lngTestScheduleID = value; }
		}
		/// <summary>
		/// ExamCode
		/// SBD = mã số dự thi
		/// </summary>
		public string ExamCode
		{
			get { return  strExamCode; }
			set { strExamCode = value; }
		}
		/// <summary>
		/// OrderIndex
		/// Số thứ tự sinh viên trong phòng thi
		/// </summary>
		public int? OrderIndex
		{
			get { return  intOrderIndex; }
			set { intOrderIndex = value; }
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
		/// SameExamID
		/// Mã đề thi tương đương, phân cố định cho sinh viên trước khi thi
		/// </summary>
		public long? SameExamID
		{
			get { return  lngSameExamID; }
			set { lngSameExamID = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_ExamScheduleID.ToUpper()) && !Convert.IsDBNull(reader[C_ExamScheduleID])) this.lngExamScheduleID = Convert.ToInt64(reader[C_ExamScheduleID]);
					if (reader.GetName(i).ToUpper().Equals(C_SubjectMarkID.ToUpper()) && !Convert.IsDBNull(reader[C_SubjectMarkID])) this.lngSubjectMarkID = Convert.ToInt64(reader[C_SubjectMarkID]);
					if (reader.GetName(i).ToUpper().Equals(C_TestScheduleID.ToUpper()) && !Convert.IsDBNull(reader[C_TestScheduleID])) this.lngTestScheduleID = Convert.ToInt64(reader[C_TestScheduleID]);
					if (reader.GetName(i).ToUpper().Equals(C_ExamCode.ToUpper()) && !Convert.IsDBNull(reader[C_ExamCode])) this.strExamCode = Convert.ToString(reader[C_ExamCode]);
					if (reader.GetName(i).ToUpper().Equals(C_OrderIndex.ToUpper()) && !Convert.IsDBNull(reader[C_OrderIndex])) this.intOrderIndex = Convert.ToInt32(reader[C_OrderIndex]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(reader[C_UpdatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(reader[C_UpdatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_SameExamID.ToUpper()) && !Convert.IsDBNull(reader[C_SameExamID])) this.lngSameExamID = Convert.ToInt64(reader[C_SameExamID]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_ExamSchedule", objEx);
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
				if (!Convert.IsDBNull(drw[C_ExamScheduleID])) this.lngExamScheduleID = Convert.ToInt64(drw[C_ExamScheduleID]);
				if (!Convert.IsDBNull(drw[C_SubjectMarkID])) this.lngSubjectMarkID = Convert.ToInt64(drw[C_SubjectMarkID]);
				if (!Convert.IsDBNull(drw[C_TestScheduleID])) this.lngTestScheduleID = Convert.ToInt64(drw[C_TestScheduleID]);
				if (!Convert.IsDBNull(drw[C_ExamCode])) this.strExamCode = Convert.ToString(drw[C_ExamCode]);
				if (!Convert.IsDBNull(drw[C_OrderIndex])) this.intOrderIndex = Convert.ToInt32(drw[C_OrderIndex]);
				if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
				if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
				if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
				if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
				if (!Convert.IsDBNull(drw[C_SameExamID])) this.lngSameExamID = Convert.ToInt64(drw[C_SameExamID]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_ExamSchedule", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_ExamSchedule_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ExamSchedule_GET");
				objIData.AddParameter(P_ExamScheduleID, this.lngExamScheduleID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_ExamSchedule", objEx);
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
		/// Store: SIM_ExamSchedule_GET 
		///</summary>
		/// <returns> SIM_ExamSchedule </returns>
		public SIM_ExamSchedule Get(long? lngExamScheduleID)
		{
			SIM_ExamSchedule obj = new SIM_ExamSchedule();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.ExamScheduleID = lngExamScheduleID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_ExamSchedule
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_ExamSchedule", objEx);
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
		/// Search : SIM_ExamSchedule
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_ExamSchedule", objEx);
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
		/// Search : SIM_ExamSchedule
		/// Lấy hết dữ liệu
		/// Store: SIM_ExamSchedule_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_ExamSchedule_GETALL");
		}

		///<summary>
		/// Search : SIM_ExamSchedule
		/// Tìm dữ liệu
		/// Store: SIM_ExamSchedule_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_ExamSchedule_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_ExamSchedule
		/// Thêm dữ liệu
		/// Store: SIM_ExamSchedule_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ExamSchedule_ADD");
				objIData.AddParameter(P_SubjectMarkID, this.lngSubjectMarkID);
				objIData.AddParameter(P_TestScheduleID, this.lngTestScheduleID);
				objIData.AddParameter(P_ExamCode, this.strExamCode);
				objIData.AddParameter(P_OrderIndex, this.intOrderIndex);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				objIData.AddParameter(P_SameExamID, this.lngSameExamID);
				this.lngExamScheduleID = Convert.ToInt32(objIData.ExecStoreToString());
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_ExamSchedule", objEx);
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
		/// Update : SIM_ExamSchedule
		/// Cập nhật dữ liệu
		/// Store: SIM_ExamSchedule_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ExamSchedule_EDIT");
				objIData.AddParameter(P_ExamScheduleID, this.lngExamScheduleID);
				objIData.AddParameter(P_SubjectMarkID, this.lngSubjectMarkID);
				objIData.AddParameter(P_TestScheduleID, this.lngTestScheduleID);
				objIData.AddParameter(P_ExamCode, this.strExamCode);
				objIData.AddParameter(P_OrderIndex, this.intOrderIndex);
				objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
				objIData.AddParameter(P_SameExamID, this.lngSameExamID);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_ExamSchedule", objEx);
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
		/// Delete : SIM_ExamSchedule
		/// Xóa dữ liệu
		/// Store: SIM_ExamSchedule_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ExamSchedule_DELETE");
				objIData.AddParameter(P_ExamScheduleID, this.lngExamScheduleID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_ExamSchedule", objEx);
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
		/// Store: SIM_ExamSchedule_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(long? lngExamScheduleID)
		{
			this.lngExamScheduleID = lngExamScheduleID;
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

		public SIM_ExamSchedule()
		{
		}
		public SIM_ExamSchedule(long? lngExamScheduleID)
		{
			this.lngExamScheduleID = lngExamScheduleID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_ExamScheduleID = "@" + C_ExamScheduleID;
		public const String P_SubjectMarkID = "@" + C_SubjectMarkID;
		public const String P_TestScheduleID = "@" + C_TestScheduleID;
		public const String P_ExamCode = "@" + C_ExamCode;
		public const String P_OrderIndex = "@" + C_OrderIndex;
		public const String P_CreatedDate = "@" + C_CreatedDate;
		public const String P_CreatedUser = "@" + C_CreatedUser;
		public const String P_UpdatedDate = "@" + C_UpdatedDate;
		public const String P_UpdatedUser = "@" + C_UpdatedUser;
		public const String P_SameExamID = "@" + C_SameExamID;

		#endregion //Parameter names

		#region Column Names

		public const String C_ExamScheduleID = "ExamScheduleID";
		public const String C_SubjectMarkID = "SubjectMarkID";
		public const String C_TestScheduleID = "TestScheduleID";
		public const String C_ExamCode = "ExamCode";
		public const String C_OrderIndex = "OrderIndex";
		public const String C_CreatedDate = "CreatedDate";
		public const String C_CreatedUser = "CreatedUser";
		public const String C_UpdatedDate = "UpdatedDate";
		public const String C_UpdatedUser = "UpdatedUser";
		public const String C_SameExamID = "SameExamID";

		#endregion //Column names

		#endregion Variable Static		
	}
}
