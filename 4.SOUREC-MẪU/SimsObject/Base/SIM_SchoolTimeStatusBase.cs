
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
	public partial class SIM_SchoolTimeStatus
	{	
		#region Member Variables

		private int? intLessionTime = null;//Tiết học thứ mấy tính từ 1-15
		private int? intDay = null;//Thứ trong tuần: tính từ 0-6
		private int? intStatus = null;//Trạng thái trường 0:Bình thường, 1:Họp, 2:Bận, 3: Nghỉ
		private IData objIData = null;
		private bool bolIsExistIData = false;
		private Exception objErrorException = null;

		#endregion

		#region Properties 

		/// <summary>
		/// LessionTime
		/// Tiết học thứ mấy tính từ 1-15
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
		/// Trạng thái trường 0:Bình thường, 1:Họp, 2:Bận, 3: Nghỉ
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
					if (reader.GetName(i).ToUpper().Equals(C_LessionTime.ToUpper()) && !Convert.IsDBNull(reader[C_LessionTime])) this.intLessionTime = Convert.ToInt32(reader[C_LessionTime]);
					if (reader.GetName(i).ToUpper().Equals(C_Day.ToUpper()) && !Convert.IsDBNull(reader[C_Day])) this.intDay = Convert.ToInt32(reader[C_Day]);
					if (reader.GetName(i).ToUpper().Equals(C_Status.ToUpper()) && !Convert.IsDBNull(reader[C_Status])) this.intStatus = Convert.ToInt32(reader[C_Status]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_SchoolTimeStatus", objEx);
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
				if (!Convert.IsDBNull(drw[C_LessionTime])) this.intLessionTime = Convert.ToInt32(drw[C_LessionTime]);
				if (!Convert.IsDBNull(drw[C_Day])) this.intDay = Convert.ToInt32(drw[C_Day]);
				if (!Convert.IsDBNull(drw[C_Status])) this.intStatus = Convert.ToInt32(drw[C_Status]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_SchoolTimeStatus", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_SchoolTimeStatus_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_SchoolTimeStatus_GET");
				objIData.AddParameter(P_LessionTime, this.intLessionTime);
				objIData.AddParameter(P_Day, this.intDay);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_SchoolTimeStatus", objEx);
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
		/// Store: SIM_SchoolTimeStatus_GET 
		///</summary>
		/// <returns> SIM_SchoolTimeStatus </returns>
		public SIM_SchoolTimeStatus Get(int? intLessionTime, int? intDay)
		{
			SIM_SchoolTimeStatus obj = new SIM_SchoolTimeStatus();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.LessionTime = intLessionTime;
			obj.Day = intDay;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_SchoolTimeStatus
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_SchoolTimeStatus", objEx);
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
		/// Search : SIM_SchoolTimeStatus
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_SchoolTimeStatus", objEx);
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
		/// Search : SIM_SchoolTimeStatus
		/// Lấy hết dữ liệu
		/// Store: SIM_SchoolTimeStatus_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_SchoolTimeStatus_GETALL");
		}

		///<summary>
		/// Search : SIM_SchoolTimeStatus
		/// Tìm dữ liệu
		/// Store: SIM_SchoolTimeStatus_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_SchoolTimeStatus_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_SchoolTimeStatus
		/// Thêm dữ liệu
		/// Store: SIM_SchoolTimeStatus_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_SchoolTimeStatus_ADD");
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_SchoolTimeStatus", objEx);
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
		/// Update : SIM_SchoolTimeStatus
		/// Cập nhật dữ liệu
		/// Store: SIM_SchoolTimeStatus_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_SchoolTimeStatus_EDIT");
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_SchoolTimeStatus", objEx);
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
		/// Delete : SIM_SchoolTimeStatus
		/// Xóa dữ liệu
		/// Store: SIM_SchoolTimeStatus_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_SchoolTimeStatus_DELETE");
				objIData.AddParameter(P_LessionTime, this.intLessionTime);
				objIData.AddParameter(P_Day, this.intDay);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_SchoolTimeStatus", objEx);
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
		/// Store: SIM_SchoolTimeStatus_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(int? intLessionTime, int? intDay)
		{
			this.intLessionTime = intLessionTime;
			this.intDay = intDay;
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

		public SIM_SchoolTimeStatus()
		{
		}
		public SIM_SchoolTimeStatus(int? intLessionTime, int? intDay)
		{
			this.intLessionTime = intLessionTime;
			this.intDay = intDay;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_LessionTime = "@" + C_LessionTime;
		public const String P_Day = "@" + C_Day;
		public const String P_Status = "@" + C_Status;

		#endregion //Parameter names

		#region Column Names

		public const String C_LessionTime = "LessionTime";
		public const String C_Day = "Day";
		public const String C_Status = "Status";

		#endregion //Column names

		#endregion Variable Static		
	}
}
