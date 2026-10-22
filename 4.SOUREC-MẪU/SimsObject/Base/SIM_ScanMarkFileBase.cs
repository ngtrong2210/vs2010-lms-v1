
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
	public partial class SIM_ScanMarkFile
	{	
		#region Member Variables

		private long? lngScanMarkFileID = null;
		private string strFilePath = null;
		private long? lngFileSize = null;
		private DateTime? dtmFileUpdatedDate = null;//Ngày giờ tạo file
		private long? lngScanMarkID = null;//Mã nhận dạng, là mã tờ giấy in
		private int? intPageIndex = null;//Số trang theo cách cũ. Cách mới không sử dụng, vì tự tính và update vào chi tiết tờ scan luôn rồi
		private DateTime? dtmCreatedDate = null;//Ngày tạo
		private string strCreatedUser = null;//Người tạo
		private bool bolIsUpdated = false;//Đã update điểm 
		private DateTime? dtmUpdatedDate = null;//Ngày cập nhật cuối
		private string strUpdatedUser = null;//Người cập nhật cuối
		private IData objIData = null;
		private bool bolIsExistIData = false;
		private Exception objErrorException = null;

		#endregion

		#region Properties 

		/// <summary>
		/// ScanMarkFileID
		/// 
		/// </summary>
		public long? ScanMarkFileID
		{
			get { return  lngScanMarkFileID; }
			set { lngScanMarkFileID = value; }
		}
		/// <summary>
		/// FilePath
		/// 
		/// </summary>
		public string FilePath
		{
			get { return  strFilePath; }
			set { strFilePath = value; }
		}
		/// <summary>
		/// FileSize
		/// 
		/// </summary>
		public long? FileSize
		{
			get { return  lngFileSize; }
			set { lngFileSize = value; }
		}
		/// <summary>
		/// FileUpdatedDate
		/// Ngày giờ tạo file
		/// </summary>
		public DateTime? FileUpdatedDate
		{
			get { return  dtmFileUpdatedDate; }
			set { dtmFileUpdatedDate = value; }
		}
		/// <summary>
		/// ScanMarkID
		/// Mã nhận dạng, là mã tờ giấy in
		/// </summary>
		public long? ScanMarkID
		{
			get { return  lngScanMarkID; }
			set { lngScanMarkID = value; }
		}
		/// <summary>
		/// PageIndex
		/// Số trang theo cách cũ. Cách mới không sử dụng, vì tự tính và update vào chi tiết tờ scan luôn rồi
		/// </summary>
		public int? PageIndex
		{
			get { return  intPageIndex; }
			set { intPageIndex = value; }
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
		/// IsUpdated
		/// Đã update điểm 
		/// </summary>
		public bool IsUpdated
		{
			get { return  bolIsUpdated; }
			set { bolIsUpdated = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_ScanMarkFileID.ToUpper()) && !Convert.IsDBNull(reader[C_ScanMarkFileID])) this.lngScanMarkFileID = Convert.ToInt64(reader[C_ScanMarkFileID]);
					if (reader.GetName(i).ToUpper().Equals(C_FilePath.ToUpper()) && !Convert.IsDBNull(reader[C_FilePath])) this.strFilePath = Convert.ToString(reader[C_FilePath]);
					if (reader.GetName(i).ToUpper().Equals(C_FileSize.ToUpper()) && !Convert.IsDBNull(reader[C_FileSize])) this.lngFileSize = Convert.ToInt64(reader[C_FileSize]);
					if (reader.GetName(i).ToUpper().Equals(C_FileUpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_FileUpdatedDate])) this.dtmFileUpdatedDate = Convert.ToDateTime(reader[C_FileUpdatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_ScanMarkID.ToUpper()) && !Convert.IsDBNull(reader[C_ScanMarkID])) this.lngScanMarkID = Convert.ToInt64(reader[C_ScanMarkID]);
					if (reader.GetName(i).ToUpper().Equals(C_PageIndex.ToUpper()) && !Convert.IsDBNull(reader[C_PageIndex])) this.intPageIndex = Convert.ToInt32(reader[C_PageIndex]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_IsUpdated.ToUpper()) && !Convert.IsDBNull(reader[C_IsUpdated])) this.bolIsUpdated = Convert.ToBoolean(reader[C_IsUpdated]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(reader[C_UpdatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(reader[C_UpdatedUser]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_ScanMarkFile", objEx);
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
				if (!Convert.IsDBNull(drw[C_ScanMarkFileID])) this.lngScanMarkFileID = Convert.ToInt64(drw[C_ScanMarkFileID]);
				if (!Convert.IsDBNull(drw[C_FilePath])) this.strFilePath = Convert.ToString(drw[C_FilePath]);
				if (!Convert.IsDBNull(drw[C_FileSize])) this.lngFileSize = Convert.ToInt64(drw[C_FileSize]);
				if (!Convert.IsDBNull(drw[C_FileUpdatedDate])) this.dtmFileUpdatedDate = Convert.ToDateTime(drw[C_FileUpdatedDate]);
				if (!Convert.IsDBNull(drw[C_ScanMarkID])) this.lngScanMarkID = Convert.ToInt64(drw[C_ScanMarkID]);
				if (!Convert.IsDBNull(drw[C_PageIndex])) this.intPageIndex = Convert.ToInt32(drw[C_PageIndex]);
				if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
				if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
				if (!Convert.IsDBNull(drw[C_IsUpdated])) this.bolIsUpdated = Convert.ToBoolean(drw[C_IsUpdated]);
				if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
				if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_ScanMarkFile", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_ScanMarkFile_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ScanMarkFile_GET");
				objIData.AddParameter(P_ScanMarkFileID, this.lngScanMarkFileID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_ScanMarkFile", objEx);
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
		/// Store: SIM_ScanMarkFile_GET 
		///</summary>
		/// <returns> SIM_ScanMarkFile </returns>
		public SIM_ScanMarkFile Get(long? lngScanMarkFileID)
		{
			SIM_ScanMarkFile obj = new SIM_ScanMarkFile();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.ScanMarkFileID = lngScanMarkFileID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_ScanMarkFile
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_ScanMarkFile", objEx);
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
		/// Search : SIM_ScanMarkFile
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_ScanMarkFile", objEx);
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
		/// Search : SIM_ScanMarkFile
		/// Lấy hết dữ liệu
		/// Store: SIM_ScanMarkFile_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_ScanMarkFile_GETALL");
		}

		///<summary>
		/// Search : SIM_ScanMarkFile
		/// Tìm dữ liệu
		/// Store: SIM_ScanMarkFile_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_ScanMarkFile_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_ScanMarkFile
		/// Thêm dữ liệu
		/// Store: SIM_ScanMarkFile_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ScanMarkFile_ADD");
				objIData.AddParameter(P_FilePath, this.strFilePath);
				objIData.AddParameter(P_FileSize, this.lngFileSize);
				objIData.AddParameter(P_FileUpdatedDate, this.dtmFileUpdatedDate);
				objIData.AddParameter(P_ScanMarkID, this.lngScanMarkID);
				objIData.AddParameter(P_PageIndex, this.intPageIndex);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				objIData.AddParameter(P_IsUpdated, this.bolIsUpdated);
				this.lngScanMarkFileID = Convert.ToInt32(objIData.ExecStoreToString());
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_ScanMarkFile", objEx);
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
		/// Update : SIM_ScanMarkFile
		/// Cập nhật dữ liệu
		/// Store: SIM_ScanMarkFile_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ScanMarkFile_EDIT");
				objIData.AddParameter(P_ScanMarkFileID, this.lngScanMarkFileID);
				objIData.AddParameter(P_FilePath, this.strFilePath);
				objIData.AddParameter(P_FileSize, this.lngFileSize);
				objIData.AddParameter(P_FileUpdatedDate, this.dtmFileUpdatedDate);
				objIData.AddParameter(P_ScanMarkID, this.lngScanMarkID);
				objIData.AddParameter(P_PageIndex, this.intPageIndex);
				objIData.AddParameter(P_IsUpdated, this.bolIsUpdated);
				objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_ScanMarkFile", objEx);
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
		/// Delete : SIM_ScanMarkFile
		/// Xóa dữ liệu
		/// Store: SIM_ScanMarkFile_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ScanMarkFile_DELETE");
				objIData.AddParameter(P_ScanMarkFileID, this.lngScanMarkFileID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_ScanMarkFile", objEx);
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
		/// Store: SIM_ScanMarkFile_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(long? lngScanMarkFileID)
		{
			this.lngScanMarkFileID = lngScanMarkFileID;
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

		public SIM_ScanMarkFile()
		{
		}
		public SIM_ScanMarkFile(long? lngScanMarkFileID)
		{
			this.lngScanMarkFileID = lngScanMarkFileID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_ScanMarkFileID = "@" + C_ScanMarkFileID;
		public const String P_FilePath = "@" + C_FilePath;
		public const String P_FileSize = "@" + C_FileSize;
		public const String P_FileUpdatedDate = "@" + C_FileUpdatedDate;
		public const String P_ScanMarkID = "@" + C_ScanMarkID;
		public const String P_PageIndex = "@" + C_PageIndex;
		public const String P_CreatedDate = "@" + C_CreatedDate;
		public const String P_CreatedUser = "@" + C_CreatedUser;
		public const String P_IsUpdated = "@" + C_IsUpdated;
		public const String P_UpdatedDate = "@" + C_UpdatedDate;
		public const String P_UpdatedUser = "@" + C_UpdatedUser;

		#endregion //Parameter names

		#region Column Names

		public const String C_ScanMarkFileID = "ScanMarkFileID";
		public const String C_FilePath = "FilePath";
		public const String C_FileSize = "FileSize";
		public const String C_FileUpdatedDate = "FileUpdatedDate";
		public const String C_ScanMarkID = "ScanMarkID";
		public const String C_PageIndex = "PageIndex";
		public const String C_CreatedDate = "CreatedDate";
		public const String C_CreatedUser = "CreatedUser";
		public const String C_IsUpdated = "IsUpdated";
		public const String C_UpdatedDate = "UpdatedDate";
		public const String C_UpdatedUser = "UpdatedUser";

		#endregion //Column names

		#endregion Variable Static		
	}
}
