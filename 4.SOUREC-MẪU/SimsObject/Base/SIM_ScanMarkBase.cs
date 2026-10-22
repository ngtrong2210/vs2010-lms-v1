
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
	/// Created date 	: 9/11/2013 
	/// Description 
	/// </summary>	
	public partial class SIM_ScanMark
	{	
		#region Member Variables

		private long? lngScanMarkID = null;//Mã nhận dạng mỗi lần in
		private long? lngPageID = null;//Mã lớp học phần. hoặc mã lịch tổ chức khi (dùng cho trộn sinh viên)
		private int? intExamOrder = null;//Lần thi
		private int? intPageNo = null;//Dùng cho điểm quá trình. Số tờ: 1,3,5 là hệ số 1  ;  2,4,6 là hệ số 2
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
		/// ScanMarkID
		/// Mã nhận dạng mỗi lần in
		/// </summary>
		public long? ScanMarkID
		{
			get { return  lngScanMarkID; }
			set { lngScanMarkID = value; }
		}
		/// <summary>
		/// PageID
		/// Mã lớp học phần. hoặc mã lịch tổ chức khi (dùng cho trộn sinh viên)
		/// </summary>
		public long? PageID
		{
			get { return  lngPageID; }
			set { lngPageID = value; }
		}
		/// <summary>
		/// ExamOrder
		/// Lần thi
		/// </summary>
		public int? ExamOrder
		{
			get { return  intExamOrder; }
			set { intExamOrder = value; }
		}
		/// <summary>
		/// PageNo
		/// Dùng cho điểm quá trình. Số tờ: 1,3,5 là hệ số 1  ;  2,4,6 là hệ số 2
		/// </summary>
		public int? PageNo
		{
			get { return  intPageNo; }
			set { intPageNo = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_ScanMarkID.ToUpper()) && !Convert.IsDBNull(reader[C_ScanMarkID])) this.lngScanMarkID = Convert.ToInt64(reader[C_ScanMarkID]);
					if (reader.GetName(i).ToUpper().Equals(C_PageID.ToUpper()) && !Convert.IsDBNull(reader[C_PageID])) this.lngPageID = Convert.ToInt64(reader[C_PageID]);
					if (reader.GetName(i).ToUpper().Equals(C_ExamOrder.ToUpper()) && !Convert.IsDBNull(reader[C_ExamOrder])) this.intExamOrder = Convert.ToInt32(reader[C_ExamOrder]);
					if (reader.GetName(i).ToUpper().Equals(C_PageNo.ToUpper()) && !Convert.IsDBNull(reader[C_PageNo])) this.intPageNo = Convert.ToInt32(reader[C_PageNo]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(reader[C_UpdatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(reader[C_UpdatedUser]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_ScanMark", objEx);
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
				if (!Convert.IsDBNull(drw[C_ScanMarkID])) this.lngScanMarkID = Convert.ToInt64(drw[C_ScanMarkID]);
				if (!Convert.IsDBNull(drw[C_PageID])) this.lngPageID = Convert.ToInt64(drw[C_PageID]);
				if (!Convert.IsDBNull(drw[C_ExamOrder])) this.intExamOrder = Convert.ToInt32(drw[C_ExamOrder]);
				if (!Convert.IsDBNull(drw[C_PageNo])) this.intPageNo = Convert.ToInt32(drw[C_PageNo]);
				if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
				if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
				if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
				if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_ScanMark", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_ScanMark_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ScanMark_GET");
				objIData.AddParameter(P_ScanMarkID, this.lngScanMarkID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_ScanMark", objEx);
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
		/// Store: SIM_ScanMark_GET 
		///</summary>
		/// <returns> SIM_ScanMark </returns>
		public SIM_ScanMark Get(long? lngScanMarkID)
		{
			SIM_ScanMark obj = new SIM_ScanMark();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.ScanMarkID = lngScanMarkID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_ScanMark
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_ScanMark", objEx);
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
		/// Search : SIM_ScanMark
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_ScanMark", objEx);
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
		/// Search : SIM_ScanMark
		/// Lấy hết dữ liệu
		/// Store: SIM_ScanMark_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_ScanMark_GETALL");
		}

		///<summary>
		/// Search : SIM_ScanMark
		/// Tìm dữ liệu
		/// Store: SIM_ScanMark_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_ScanMark_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_ScanMark
		/// Thêm dữ liệu
		/// Store: SIM_ScanMark_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ScanMark_ADD");
				objIData.AddParameter(P_PageID, this.lngPageID);
				objIData.AddParameter(P_ExamOrder, this.intExamOrder);
				objIData.AddParameter(P_PageNo, this.intPageNo);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				this.lngScanMarkID = Convert.ToInt32(objIData.ExecStoreToString());
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_ScanMark", objEx);
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
		/// Update : SIM_ScanMark
		/// Cập nhật dữ liệu
		/// Store: SIM_ScanMark_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ScanMark_EDIT");
				objIData.AddParameter(P_ScanMarkID, this.lngScanMarkID);
				objIData.AddParameter(P_PageID, this.lngPageID);
				objIData.AddParameter(P_ExamOrder, this.intExamOrder);
				objIData.AddParameter(P_PageNo, this.intPageNo);
				objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_ScanMark", objEx);
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
		/// Delete : SIM_ScanMark
		/// Xóa dữ liệu
		/// Store: SIM_ScanMark_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ScanMark_DELETE");
				objIData.AddParameter(P_ScanMarkID, this.lngScanMarkID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_ScanMark", objEx);
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
		/// Store: SIM_ScanMark_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(long? lngScanMarkID)
		{
			this.lngScanMarkID = lngScanMarkID;
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

		public SIM_ScanMark()
		{
		}
		public SIM_ScanMark(long? lngScanMarkID)
		{
			this.lngScanMarkID = lngScanMarkID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_ScanMarkID = "@" + C_ScanMarkID;
		public const String P_PageID = "@" + C_PageID;
		public const String P_ExamOrder = "@" + C_ExamOrder;
		public const String P_PageNo = "@" + C_PageNo;
		public const String P_CreatedDate = "@" + C_CreatedDate;
		public const String P_CreatedUser = "@" + C_CreatedUser;
		public const String P_UpdatedDate = "@" + C_UpdatedDate;
		public const String P_UpdatedUser = "@" + C_UpdatedUser;

		#endregion //Parameter names

		#region Column Names

		public const String C_ScanMarkID = "ScanMarkID";
		public const String C_PageID = "PageID";
		public const String C_ExamOrder = "ExamOrder";
		public const String C_PageNo = "PageNo";
		public const String C_CreatedDate = "CreatedDate";
		public const String C_CreatedUser = "CreatedUser";
		public const String C_UpdatedDate = "UpdatedDate";
		public const String C_UpdatedUser = "UpdatedUser";

		#endregion //Column names

		#endregion Variable Static		
	}
}
