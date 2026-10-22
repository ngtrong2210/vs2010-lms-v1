
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
	public partial class SIM_ClassFile
	{	
		#region Member Variables

		private long? lngFileID = null;
		private string strClassID = null;
		private string strFileTitle = null;
		private string strFileName = null;
		private string strFilePath = null;
		private int? intFileTypeID = null;
		private string strDescription = null;
		private DateTime? dtmCreatedDate = null;
		private string strCreatedUser = null;
		private DateTime? dtmUpdatedDate = null;
		private string strUpdatedUser = null;
		private bool bolIsDeleted = false;
		private DateTime? dtmDeletedDate = null;
		private string strDeletedUser = null;
		private IData objIData = null;
		private bool bolIsExistIData = false;
		private Exception objErrorException = null;

		#endregion

		#region Properties 

		/// <summary>
		/// FileID
		/// 
		/// </summary>
		public long? FileID
		{
			get { return  lngFileID; }
			set { lngFileID = value; }
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
		/// FileTitle
		/// 
		/// </summary>
		public string FileTitle
		{
			get { return  strFileTitle; }
			set { strFileTitle = value; }
		}
		/// <summary>
		/// FileName
		/// 
		/// </summary>
		public string FileName
		{
			get { return  strFileName; }
			set { strFileName = value; }
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
		/// FileTypeID
		/// 
		/// </summary>
		public int? FileTypeID
		{
			get { return  intFileTypeID; }
			set { intFileTypeID = value; }
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
		/// 
		/// </summary>
		public DateTime? CreatedDate
		{
			get { return  dtmCreatedDate; }
			set { dtmCreatedDate = value; }
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
		/// UpdatedDate
		/// 
		/// </summary>
		public DateTime? UpdatedDate
		{
			get { return  dtmUpdatedDate; }
			set { dtmUpdatedDate = value; }
		}
		/// <summary>
		/// UpdatedUser
		/// 
		/// </summary>
		public string UpdatedUser
		{
			get { return  strUpdatedUser; }
			set { strUpdatedUser = value; }
		}
		/// <summary>
		/// IsDeleted
		/// 
		/// </summary>
		public bool IsDeleted
		{
			get { return  bolIsDeleted; }
			set { bolIsDeleted = value; }
		}
		/// <summary>
		/// DeletedDate
		/// 
		/// </summary>
		public DateTime? DeletedDate
		{
			get { return  dtmDeletedDate; }
			set { dtmDeletedDate = value; }
		}
		/// <summary>
		/// DeletedUser
		/// 
		/// </summary>
		public string DeletedUser
		{
			get { return  strDeletedUser; }
			set { strDeletedUser = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_FileID.ToUpper()) && !Convert.IsDBNull(reader[C_FileID])) this.lngFileID = Convert.ToInt64(reader[C_FileID]);
					if (reader.GetName(i).ToUpper().Equals(C_ClassID.ToUpper()) && !Convert.IsDBNull(reader[C_ClassID])) this.strClassID = Convert.ToString(reader[C_ClassID]);
					if (reader.GetName(i).ToUpper().Equals(C_FileTitle.ToUpper()) && !Convert.IsDBNull(reader[C_FileTitle])) this.strFileTitle = Convert.ToString(reader[C_FileTitle]);
					if (reader.GetName(i).ToUpper().Equals(C_FileName.ToUpper()) && !Convert.IsDBNull(reader[C_FileName])) this.strFileName = Convert.ToString(reader[C_FileName]);
					if (reader.GetName(i).ToUpper().Equals(C_FilePath.ToUpper()) && !Convert.IsDBNull(reader[C_FilePath])) this.strFilePath = Convert.ToString(reader[C_FilePath]);
					if (reader.GetName(i).ToUpper().Equals(C_FileTypeID.ToUpper()) && !Convert.IsDBNull(reader[C_FileTypeID])) this.intFileTypeID = Convert.ToInt32(reader[C_FileTypeID]);
					if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(reader[C_UpdatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(reader[C_UpdatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_IsDeleted.ToUpper()) && !Convert.IsDBNull(reader[C_IsDeleted])) this.bolIsDeleted = Convert.ToBoolean(reader[C_IsDeleted]);
					if (reader.GetName(i).ToUpper().Equals(C_DeletedDate.ToUpper()) && !Convert.IsDBNull(reader[C_DeletedDate])) this.dtmDeletedDate = Convert.ToDateTime(reader[C_DeletedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_DeletedUser.ToUpper()) && !Convert.IsDBNull(reader[C_DeletedUser])) this.strDeletedUser = Convert.ToString(reader[C_DeletedUser]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_ClassFile", objEx);
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
				if (!Convert.IsDBNull(drw[C_FileID])) this.lngFileID = Convert.ToInt64(drw[C_FileID]);
				if (!Convert.IsDBNull(drw[C_ClassID])) this.strClassID = Convert.ToString(drw[C_ClassID]);
				if (!Convert.IsDBNull(drw[C_FileTitle])) this.strFileTitle = Convert.ToString(drw[C_FileTitle]);
				if (!Convert.IsDBNull(drw[C_FileName])) this.strFileName = Convert.ToString(drw[C_FileName]);
				if (!Convert.IsDBNull(drw[C_FilePath])) this.strFilePath = Convert.ToString(drw[C_FilePath]);
				if (!Convert.IsDBNull(drw[C_FileTypeID])) this.intFileTypeID = Convert.ToInt32(drw[C_FileTypeID]);
				if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
				if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
				if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
				if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
				if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
				if (!Convert.IsDBNull(drw[C_IsDeleted])) this.bolIsDeleted = Convert.ToBoolean(drw[C_IsDeleted]);
				if (!Convert.IsDBNull(drw[C_DeletedDate])) this.dtmDeletedDate = Convert.ToDateTime(drw[C_DeletedDate]);
				if (!Convert.IsDBNull(drw[C_DeletedUser])) this.strDeletedUser = Convert.ToString(drw[C_DeletedUser]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_ClassFile", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_ClassFile_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ClassFile_GET");
				objIData.AddParameter(P_FileID, this.lngFileID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_ClassFile", objEx);
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
		/// Store: SIM_ClassFile_GET 
		///</summary>
		/// <returns> SIM_ClassFile </returns>
		public SIM_ClassFile Get(long? lngFileID)
		{
			SIM_ClassFile obj = new SIM_ClassFile();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.FileID = lngFileID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_ClassFile
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_ClassFile", objEx);
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
		/// Search : SIM_ClassFile
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_ClassFile", objEx);
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
		/// Search : SIM_ClassFile
		/// Lấy hết dữ liệu
		/// Store: SIM_ClassFile_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_ClassFile_GETALL");
		}

		///<summary>
		/// Search : SIM_ClassFile
		/// Tìm dữ liệu
		/// Store: SIM_ClassFile_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_ClassFile_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_ClassFile
		/// Thêm dữ liệu
		/// Store: SIM_ClassFile_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ClassFile_ADD");
				objIData.AddParameter(P_ClassID, this.strClassID);
				objIData.AddParameter(P_FileTitle, this.strFileTitle);
				objIData.AddParameter(P_FileName, this.strFileName);
				objIData.AddParameter(P_FilePath, this.strFilePath);
				objIData.AddParameter(P_FileTypeID, this.intFileTypeID);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				this.lngFileID = Convert.ToInt32(objIData.ExecStoreToString());
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_ClassFile", objEx);
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
		/// Update : SIM_ClassFile
		/// Cập nhật dữ liệu
		/// Store: SIM_ClassFile_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ClassFile_EDIT");
				objIData.AddParameter(P_FileID, this.lngFileID);
				objIData.AddParameter(P_ClassID, this.strClassID);
				objIData.AddParameter(P_FileTitle, this.strFileTitle);
				objIData.AddParameter(P_FileName, this.strFileName);
				objIData.AddParameter(P_FilePath, this.strFilePath);
				objIData.AddParameter(P_FileTypeID, this.intFileTypeID);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_ClassFile", objEx);
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
		/// Delete : SIM_ClassFile
		/// Xóa dữ liệu
		/// Store: SIM_ClassFile_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ClassFile_DELETE");
				objIData.AddParameter(P_FileID, this.lngFileID);
				objIData.AddParameter(P_DeletedUser, this.strDeletedUser);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_ClassFile", objEx);
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
		/// Store: SIM_ClassFile_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(long? lngFileID, string strDeletedUser)
		{
			this.lngFileID = lngFileID;
			this.strDeletedUser = strDeletedUser;
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

		public SIM_ClassFile()
		{
		}
		public SIM_ClassFile(long? lngFileID)
		{
			this.lngFileID = lngFileID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_FileID = "@" + C_FileID;
		public const String P_ClassID = "@" + C_ClassID;
		public const String P_FileTitle = "@" + C_FileTitle;
		public const String P_FileName = "@" + C_FileName;
		public const String P_FilePath = "@" + C_FilePath;
		public const String P_FileTypeID = "@" + C_FileTypeID;
		public const String P_Description = "@" + C_Description;
		public const String P_CreatedDate = "@" + C_CreatedDate;
		public const String P_CreatedUser = "@" + C_CreatedUser;
		public const String P_UpdatedDate = "@" + C_UpdatedDate;
		public const String P_UpdatedUser = "@" + C_UpdatedUser;
		public const String P_IsDeleted = "@" + C_IsDeleted;
		public const String P_DeletedDate = "@" + C_DeletedDate;
		public const String P_DeletedUser = "@" + C_DeletedUser;

		#endregion //Parameter names

		#region Column Names

		public const String C_FileID = "FileID";
		public const String C_ClassID = "ClassID";
		public const String C_FileTitle = "FileTitle";
		public const String C_FileName = "FileName";
		public const String C_FilePath = "FilePath";
		public const String C_FileTypeID = "FileTypeID";
		public const String C_Description = "Description";
		public const String C_CreatedDate = "CreatedDate";
		public const String C_CreatedUser = "CreatedUser";
		public const String C_UpdatedDate = "UpdatedDate";
		public const String C_UpdatedUser = "UpdatedUser";
		public const String C_IsDeleted = "IsDeleted";
		public const String C_DeletedDate = "DeletedDate";
		public const String C_DeletedUser = "DeletedUser";

		#endregion //Column names

		#endregion Variable Static		
	}
}
