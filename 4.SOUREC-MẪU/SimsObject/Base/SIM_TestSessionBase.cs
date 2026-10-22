
#region Using

using System;
using System.Data;
using System.Collections;
using DCore;

#endregion

namespace SimsObject
{
    /// <summary>
	/// Created by 		: NGUYỄN VĂN VIỆT 
	/// Created date 	: 30/07/2011 
	/// Description 
	/// </summary>	
	public partial class SIM_TestSession
	{	
		#region Member Variables

		private int? intTestSessionID = null;//Mã ca thi
		private string strTestSessionName = null;//Tên ca thi
		private DateTime? dtmStartTime = null;//Giờ bắt đầu
		private DateTime? dtmFinishTime = null;//Giờ kết thúc
		private int? intStartLession = null;//Tiết bắt đầu
		private int? intFinishLession = null;//Tiết kết thúc
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
		/// TestSessionID
		/// Mã ca thi
		/// </summary>
		public int? TestSessionID
		{
			get { return  intTestSessionID; }
			set { intTestSessionID = value; }
		}
		/// <summary>
		/// TestSessionName
		/// Tên ca thi
		/// </summary>
		public string TestSessionName
		{
			get { return  strTestSessionName; }
			set { strTestSessionName = value; }
		}
		/// <summary>
		/// StartTime
		/// Giờ bắt đầu
		/// </summary>
		public DateTime? StartTime
		{
			get { return  dtmStartTime; }
			set { dtmStartTime = value; }
		}
		/// <summary>
		/// FinishTime
		/// Giờ kết thúc
		/// </summary>
		public DateTime? FinishTime
		{
			get { return  dtmFinishTime; }
			set { dtmFinishTime = value; }
		}
		/// <summary>
		/// StartLession
		/// Tiết bắt đầu
		/// </summary>
		public int? StartLession
		{
			get { return  intStartLession; }
			set { intStartLession = value; }
		}
		/// <summary>
		/// FinishLession
		/// Tiết kết thúc
		/// </summary>
		public int? FinishLession
		{
			get { return  intFinishLession; }
			set { intFinishLession = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_TestSessionID.ToUpper()) && !Convert.IsDBNull(reader[C_TestSessionID])) this.intTestSessionID = Convert.ToInt32(reader[C_TestSessionID]);
					if (reader.GetName(i).ToUpper().Equals(C_TestSessionName.ToUpper()) && !Convert.IsDBNull(reader[C_TestSessionName])) this.strTestSessionName = Convert.ToString(reader[C_TestSessionName]);
					if (reader.GetName(i).ToUpper().Equals(C_StartTime.ToUpper()) && !Convert.IsDBNull(reader[C_StartTime])) this.dtmStartTime = Convert.ToDateTime(reader[C_StartTime]);
					if (reader.GetName(i).ToUpper().Equals(C_FinishTime.ToUpper()) && !Convert.IsDBNull(reader[C_FinishTime])) this.dtmFinishTime = Convert.ToDateTime(reader[C_FinishTime]);
					if (reader.GetName(i).ToUpper().Equals(C_StartLession.ToUpper()) && !Convert.IsDBNull(reader[C_StartLession])) this.intStartLession = Convert.ToInt32(reader[C_StartLession]);
					if (reader.GetName(i).ToUpper().Equals(C_FinishLession.ToUpper()) && !Convert.IsDBNull(reader[C_FinishLession])) this.intFinishLession = Convert.ToInt32(reader[C_FinishLession]);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_TestSession", objEx);
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
				if (!Convert.IsDBNull(drw[C_TestSessionID])) this.intTestSessionID = Convert.ToInt32(drw[C_TestSessionID]);
				if (!Convert.IsDBNull(drw[C_TestSessionName])) this.strTestSessionName = Convert.ToString(drw[C_TestSessionName]);
				if (!Convert.IsDBNull(drw[C_StartTime])) this.dtmStartTime = Convert.ToDateTime(drw[C_StartTime]);
				if (!Convert.IsDBNull(drw[C_FinishTime])) this.dtmFinishTime = Convert.ToDateTime(drw[C_FinishTime]);
				if (!Convert.IsDBNull(drw[C_StartLession])) this.intStartLession = Convert.ToInt32(drw[C_StartLession]);
				if (!Convert.IsDBNull(drw[C_FinishLession])) this.intFinishLession = Convert.ToInt32(drw[C_FinishLession]);
				if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
				if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
				if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
				if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
				if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_TestSession", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_TestSession_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_TestSession_GET");
				objIData.AddParameter(P_TestSessionID, this.intTestSessionID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_TestSession", objEx);
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
		/// Store: SIM_TestSession_GET 
		///</summary>
		/// <returns> SIM_TestSession </returns>
		public SIM_TestSession Get(int? intTestSessionID)
		{
			SIM_TestSession obj = new SIM_TestSession();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.TestSessionID = intTestSessionID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_TestSession
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_TestSession", objEx);
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
		/// Search : SIM_TestSession
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_TestSession", objEx);
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
		/// Search : SIM_TestSession
		/// Lấy hết dữ liệu
		/// Store: SIM_TestSession_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_TestSession_GETALL");
		}

		///<summary>
		/// Search : SIM_TestSession
		/// Tìm dữ liệu
		/// Store: SIM_TestSession_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_TestSession_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_TestSession
		/// Thêm dữ liệu
		/// Store: SIM_TestSession_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_TestSession_ADD");
				objIData.AddParameter(P_TestSessionName, this.strTestSessionName);
				objIData.AddParameter(P_StartTime, this.dtmStartTime);
				objIData.AddParameter(P_FinishTime, this.dtmFinishTime);
				objIData.AddParameter(P_StartLession, this.intStartLession);
				objIData.AddParameter(P_FinishLession, this.intFinishLession);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				this.intTestSessionID = Convert.ToInt32(objIData.ExecStoreToString());
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_TestSession", objEx);
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
		/// Update : SIM_TestSession
		/// Cập nhật dữ liệu
		/// Store: SIM_TestSession_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_TestSession_EDIT");
				objIData.AddParameter(P_TestSessionID, this.intTestSessionID);
				objIData.AddParameter(P_TestSessionName, this.strTestSessionName);
				objIData.AddParameter(P_StartTime, this.dtmStartTime);
				objIData.AddParameter(P_FinishTime, this.dtmFinishTime);
				objIData.AddParameter(P_StartLession, this.intStartLession);
				objIData.AddParameter(P_FinishLession, this.intFinishLession);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_TestSession", objEx);
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
		/// Delete : SIM_TestSession
		/// Xóa dữ liệu
		/// Store: SIM_TestSession_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_TestSession_DELETE");
				objIData.AddParameter(P_TestSessionID, this.intTestSessionID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_TestSession", objEx);
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
		/// Store: SIM_TestSession_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(int? intTestSessionID)
		{
			this.intTestSessionID = intTestSessionID;
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

		public SIM_TestSession()
		{
		}
		public SIM_TestSession(int? intTestSessionID)
		{
			this.intTestSessionID = intTestSessionID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_TestSessionID = "@" + C_TestSessionID;
		public const String P_TestSessionName = "@" + C_TestSessionName;
		public const String P_StartTime = "@" + C_StartTime;
		public const String P_FinishTime = "@" + C_FinishTime;
		public const String P_StartLession = "@" + C_StartLession;
		public const String P_FinishLession = "@" + C_FinishLession;
		public const String P_Description = "@" + C_Description;
		public const String P_CreatedDate = "@" + C_CreatedDate;
		public const String P_CreatedUser = "@" + C_CreatedUser;
		public const String P_UpdatedDate = "@" + C_UpdatedDate;
		public const String P_UpdatedUser = "@" + C_UpdatedUser;

		#endregion //Parameter names

		#region Column Names

		public const String C_TestSessionID = "TestSessionID";
		public const String C_TestSessionName = "TestSessionName";
		public const String C_StartTime = "StartTime";
		public const String C_FinishTime = "FinishTime";
		public const String C_StartLession = "StartLession";
		public const String C_FinishLession = "FinishLession";
		public const String C_Description = "Description";
		public const String C_CreatedDate = "CreatedDate";
		public const String C_CreatedUser = "CreatedUser";
		public const String C_UpdatedDate = "UpdatedDate";
		public const String C_UpdatedUser = "UpdatedUser";

		#endregion //Column names

		#endregion Variable Static		
	}
}
