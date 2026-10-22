
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
	/// Created date 	: 2/18/2017 
	/// Description 
	/// </summary>	
	public partial class SIM_Branch
	{	
		#region Member Variables

		private string strBranchID = null;//Mã ngành
		private string strBranchName = null;//Tên ngành
		private string strScienceID = null;
		private string strCreatedBy = null;
		private DateTime? dtmCreatedAt = null;//Ngày tạo
		private string strModifiedBy = null;//Người sửa
		private DateTime? dtmModifiedAt = null;//Ngày sửa
		private string strBranchShortName = null;
		private IData objIData = null;
		private bool bolIsExistIData = false;
		private Exception objErrorException = null;

		#endregion

		#region Properties 

		/// <summary>
		/// BranchID
		/// Mã ngành
		/// </summary>
		public string BranchID
		{
			get { return  strBranchID; }
			set { strBranchID = value; }
		}
		/// <summary>
		/// BranchName
		/// Tên ngành
		/// </summary>
		public string BranchName
		{
			get { return  strBranchName; }
			set { strBranchName = value; }
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
		/// CreatedBy
		/// 
		/// </summary>
		public string CreatedBy
		{
			get { return  strCreatedBy; }
			set { strCreatedBy = value; }
		}
		/// <summary>
		/// CreatedAt
		/// Ngày tạo
		/// </summary>
		public DateTime? CreatedAt
		{
			get { return  dtmCreatedAt; }
			set { dtmCreatedAt = value; }
		}
		/// <summary>
		/// ModifiedBy
		/// Người sửa
		/// </summary>
		public string ModifiedBy
		{
			get { return  strModifiedBy; }
			set { strModifiedBy = value; }
		}
		/// <summary>
		/// ModifiedAt
		/// Ngày sửa
		/// </summary>
		public DateTime? ModifiedAt
		{
			get { return  dtmModifiedAt; }
			set { dtmModifiedAt = value; }
		}
		/// <summary>
		/// BranchShortName
		/// 
		/// </summary>
		public string BranchShortName
		{
			get { return  strBranchShortName; }
			set { strBranchShortName = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_BranchID.ToUpper()) && !Convert.IsDBNull(reader[C_BranchID])) this.strBranchID = Convert.ToString(reader[C_BranchID]);
					if (reader.GetName(i).ToUpper().Equals(C_BranchName.ToUpper()) && !Convert.IsDBNull(reader[C_BranchName])) this.strBranchName = Convert.ToString(reader[C_BranchName]);
					if (reader.GetName(i).ToUpper().Equals(C_ScienceID.ToUpper()) && !Convert.IsDBNull(reader[C_ScienceID])) this.strScienceID = Convert.ToString(reader[C_ScienceID]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedBy.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedBy])) this.strCreatedBy = Convert.ToString(reader[C_CreatedBy]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(reader[C_CreatedAt]);
					if (reader.GetName(i).ToUpper().Equals(C_ModifiedBy.ToUpper()) && !Convert.IsDBNull(reader[C_ModifiedBy])) this.strModifiedBy = Convert.ToString(reader[C_ModifiedBy]);
					if (reader.GetName(i).ToUpper().Equals(C_ModifiedAt.ToUpper()) && !Convert.IsDBNull(reader[C_ModifiedAt])) this.dtmModifiedAt = Convert.ToDateTime(reader[C_ModifiedAt]);
					if (reader.GetName(i).ToUpper().Equals(C_BranchShortName.ToUpper()) && !Convert.IsDBNull(reader[C_BranchShortName])) this.strBranchShortName = Convert.ToString(reader[C_BranchShortName]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_Branch", objEx);
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
				if (!Convert.IsDBNull(drw[C_BranchID])) this.strBranchID = Convert.ToString(drw[C_BranchID]);
				if (!Convert.IsDBNull(drw[C_BranchName])) this.strBranchName = Convert.ToString(drw[C_BranchName]);
				if (!Convert.IsDBNull(drw[C_ScienceID])) this.strScienceID = Convert.ToString(drw[C_ScienceID]);
				if (!Convert.IsDBNull(drw[C_CreatedBy])) this.strCreatedBy = Convert.ToString(drw[C_CreatedBy]);
				if (!Convert.IsDBNull(drw[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(drw[C_CreatedAt]);
				if (!Convert.IsDBNull(drw[C_ModifiedBy])) this.strModifiedBy = Convert.ToString(drw[C_ModifiedBy]);
				if (!Convert.IsDBNull(drw[C_ModifiedAt])) this.dtmModifiedAt = Convert.ToDateTime(drw[C_ModifiedAt]);
				if (!Convert.IsDBNull(drw[C_BranchShortName])) this.strBranchShortName = Convert.ToString(drw[C_BranchShortName]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_Branch", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_Branch_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Branch_GET");
				objIData.AddParameter(P_BranchID, this.strBranchID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_Branch", objEx);
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
		/// Store: SIM_Branch_GET 
		///</summary>
		/// <returns> SIM_Branch </returns>
		public SIM_Branch Get(string strBranchID)
		{
			SIM_Branch obj = new SIM_Branch();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.BranchID = strBranchID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_Branch
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Branch", objEx);
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
		/// Search : SIM_Branch
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Branch", objEx);
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
		/// Search : SIM_Branch
		/// Lấy hết dữ liệu
		/// Store: SIM_Branch_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_Branch_GETALL");
		}

		///<summary>
		/// Search : SIM_Branch
		/// Tìm dữ liệu
		/// Store: SIM_Branch_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_Branch_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_Branch
		/// Thêm dữ liệu
		/// Store: SIM_Branch_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Branch_ADD");
				objIData.AddParameter(P_BranchID, this.strBranchID);
				objIData.AddParameter(P_BranchName, this.strBranchName);
				objIData.AddParameter(P_ScienceID, this.strScienceID);
				objIData.AddParameter(P_CreatedBy, this.strCreatedBy);
				objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
				objIData.AddParameter(P_ModifiedBy, this.strModifiedBy);
				objIData.AddParameter(P_ModifiedAt, this.dtmModifiedAt);
				objIData.AddParameter(P_BranchShortName, this.strBranchShortName);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_Branch", objEx);
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
		/// Update : SIM_Branch
		/// Cập nhật dữ liệu
		/// Store: SIM_Branch_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Branch_EDIT");
				objIData.AddParameter(P_BranchID, this.strBranchID);
				objIData.AddParameter(P_BranchName, this.strBranchName);
				objIData.AddParameter(P_ScienceID, this.strScienceID);
				objIData.AddParameter(P_CreatedBy, this.strCreatedBy);
				objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
				objIData.AddParameter(P_ModifiedBy, this.strModifiedBy);
				objIData.AddParameter(P_ModifiedAt, this.dtmModifiedAt);
				objIData.AddParameter(P_BranchShortName, this.strBranchShortName);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_Branch", objEx);
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
		/// Delete : SIM_Branch
		/// Xóa dữ liệu
		/// Store: SIM_Branch_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Branch_DELETE");
				objIData.AddParameter(P_BranchID, this.strBranchID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_Branch", objEx);
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
		/// Store: SIM_Branch_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(string strBranchID)
		{
			this.strBranchID = strBranchID;
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

		public SIM_Branch()
		{
		}
		public SIM_Branch(string strBranchID)
		{
			this.strBranchID = strBranchID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_BranchID = "@" + C_BranchID;
		public const String P_BranchName = "@" + C_BranchName;
		public const String P_ScienceID = "@" + C_ScienceID;
		public const String P_CreatedBy = "@" + C_CreatedBy;
		public const String P_CreatedAt = "@" + C_CreatedAt;
		public const String P_ModifiedBy = "@" + C_ModifiedBy;
		public const String P_ModifiedAt = "@" + C_ModifiedAt;
		public const String P_BranchShortName = "@" + C_BranchShortName;

		#endregion //Parameter names

		#region Column Names

		public const String C_BranchID = "BranchID";
		public const String C_BranchName = "BranchName";
		public const String C_ScienceID = "ScienceID";
		public const String C_CreatedBy = "CreatedBy";
		public const String C_CreatedAt = "CreatedAt";
		public const String C_ModifiedBy = "ModifiedBy";
		public const String C_ModifiedAt = "ModifiedAt";
		public const String C_BranchShortName = "BranchShortName";

		#endregion //Column names

		#endregion Variable Static		
	}
}
