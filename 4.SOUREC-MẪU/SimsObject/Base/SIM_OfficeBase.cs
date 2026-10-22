
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
	public partial class SIM_Office
	{	
		#region Member Variables

		private string strOfficeID = null;
		private string strOfficeName = null;
		private bool bolIsMainOffice = false;
		private string strDescription = null;
		private IData objIData = null;
		private bool bolIsExistIData = false;
		private Exception objErrorException = null;

		#endregion

		#region Properties 

		/// <summary>
		/// OfficeID
		/// 
		/// </summary>
		public string OfficeID
		{
			get { return  strOfficeID; }
			set { strOfficeID = value; }
		}
		/// <summary>
		/// OfficeName
		/// 
		/// </summary>
		public string OfficeName
		{
			get { return  strOfficeName; }
			set { strOfficeName = value; }
		}
		/// <summary>
		/// IsMainOffice
		/// 
		/// </summary>
		public bool IsMainOffice
		{
			get { return  bolIsMainOffice; }
			set { bolIsMainOffice = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_OfficeID.ToUpper()) && !Convert.IsDBNull(reader[C_OfficeID])) this.strOfficeID = Convert.ToString(reader[C_OfficeID]);
					if (reader.GetName(i).ToUpper().Equals(C_OfficeName.ToUpper()) && !Convert.IsDBNull(reader[C_OfficeName])) this.strOfficeName = Convert.ToString(reader[C_OfficeName]);
					if (reader.GetName(i).ToUpper().Equals(C_IsMainOffice.ToUpper()) && !Convert.IsDBNull(reader[C_IsMainOffice])) this.bolIsMainOffice = Convert.ToBoolean(reader[C_IsMainOffice]);
					if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_Office", objEx);
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
				if (!Convert.IsDBNull(drw[C_OfficeID])) this.strOfficeID = Convert.ToString(drw[C_OfficeID]);
				if (!Convert.IsDBNull(drw[C_OfficeName])) this.strOfficeName = Convert.ToString(drw[C_OfficeName]);
				if (!Convert.IsDBNull(drw[C_IsMainOffice])) this.bolIsMainOffice = Convert.ToBoolean(drw[C_IsMainOffice]);
				if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_Office", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_Office_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Office_GET");
				objIData.AddParameter(P_OfficeID, this.strOfficeID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_Office", objEx);
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
		/// Store: SIM_Office_GET 
		///</summary>
		/// <returns> SIM_Office </returns>
		public SIM_Office Get(string strOfficeID)
		{
			SIM_Office obj = new SIM_Office();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.OfficeID = strOfficeID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_Office
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Office", objEx);
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
		/// Search : SIM_Office
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Office", objEx);
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
		/// Search : SIM_Office
		/// Lấy hết dữ liệu
		/// Store: SIM_Office_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_Office_GETALL");
		}

		///<summary>
		/// Search : SIM_Office
		/// Tìm dữ liệu
		/// Store: SIM_Office_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_Office_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_Office
		/// Thêm dữ liệu
		/// Store: SIM_Office_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Office_ADD");
				objIData.AddParameter(P_OfficeID, this.strOfficeID);
				objIData.AddParameter(P_OfficeName, this.strOfficeName);
				objIData.AddParameter(P_IsMainOffice, this.bolIsMainOffice);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_Office", objEx);
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
		/// Update : SIM_Office
		/// Cập nhật dữ liệu
		/// Store: SIM_Office_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Office_EDIT");
				objIData.AddParameter(P_OfficeID, this.strOfficeID);
				objIData.AddParameter(P_OfficeName, this.strOfficeName);
				objIData.AddParameter(P_IsMainOffice, this.bolIsMainOffice);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_Office", objEx);
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
		/// Delete : SIM_Office
		/// Xóa dữ liệu
		/// Store: SIM_Office_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Office_DELETE");
				objIData.AddParameter(P_OfficeID, this.strOfficeID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_Office", objEx);
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
		/// Store: SIM_Office_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(string strOfficeID)
		{
			this.strOfficeID = strOfficeID;
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

		public SIM_Office()
		{
		}
		public SIM_Office(string strOfficeID)
		{
			this.strOfficeID = strOfficeID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_OfficeID = "@" + C_OfficeID;
		public const String P_OfficeName = "@" + C_OfficeName;
		public const String P_IsMainOffice = "@" + C_IsMainOffice;
		public const String P_Description = "@" + C_Description;

		#endregion //Parameter names

		#region Column Names

		public const String C_OfficeID = "OfficeID";
		public const String C_OfficeName = "OfficeName";
		public const String C_IsMainOffice = "IsMainOffice";
		public const String C_Description = "Description";

		#endregion //Column names

		#endregion Variable Static		
	}
}
