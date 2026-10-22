
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
	public partial class SIM_SpecialBranch_Subject_Item
	{	
		#region Member Variables

		private long? lngSBSItemID = null;//Mã định mức vật tư cho chương trình khung
		private long? lngSpecialBranchSubjectID = null;//Mã chương trình khung
		private long? lngItemID = null;//Mã vật tư
		private decimal? decQuotaQuantity = null;//Số lượng định mức (trên đầu học sinh, cho cả môn)
		private string strDescription = null;
		private IData objIData = null;
		private bool bolIsExistIData = false;
		private Exception objErrorException = null;

		#endregion

		#region Properties 

		/// <summary>
		/// SBSItemID
		/// Mã định mức vật tư cho chương trình khung
		/// </summary>
		public long? SBSItemID
		{
			get { return  lngSBSItemID; }
			set { lngSBSItemID = value; }
		}
		/// <summary>
		/// SpecialBranchSubjectID
		/// Mã chương trình khung
		/// </summary>
		public long? SpecialBranchSubjectID
		{
			get { return  lngSpecialBranchSubjectID; }
			set { lngSpecialBranchSubjectID = value; }
		}
		/// <summary>
		/// ItemID
		/// Mã vật tư
		/// </summary>
		public long? ItemID
		{
			get { return  lngItemID; }
			set { lngItemID = value; }
		}
		/// <summary>
		/// QuotaQuantity
		/// Số lượng định mức (trên đầu học sinh, cho cả môn)
		/// </summary>
		public decimal? QuotaQuantity
		{
			get { return  decQuotaQuantity; }
			set { decQuotaQuantity = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_SBSItemID.ToUpper()) && !Convert.IsDBNull(reader[C_SBSItemID])) this.lngSBSItemID = Convert.ToInt64(reader[C_SBSItemID]);
					if (reader.GetName(i).ToUpper().Equals(C_SpecialBranchSubjectID.ToUpper()) && !Convert.IsDBNull(reader[C_SpecialBranchSubjectID])) this.lngSpecialBranchSubjectID = Convert.ToInt64(reader[C_SpecialBranchSubjectID]);
					if (reader.GetName(i).ToUpper().Equals(C_ItemID.ToUpper()) && !Convert.IsDBNull(reader[C_ItemID])) this.lngItemID = Convert.ToInt64(reader[C_ItemID]);
					if (reader.GetName(i).ToUpper().Equals(C_QuotaQuantity.ToUpper()) && !Convert.IsDBNull(reader[C_QuotaQuantity])) this.decQuotaQuantity = Convert.ToDecimal(reader[C_QuotaQuantity]);
					if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_SpecialBranch_Subject_Item", objEx);
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
				if (!Convert.IsDBNull(drw[C_SBSItemID])) this.lngSBSItemID = Convert.ToInt64(drw[C_SBSItemID]);
				if (!Convert.IsDBNull(drw[C_SpecialBranchSubjectID])) this.lngSpecialBranchSubjectID = Convert.ToInt64(drw[C_SpecialBranchSubjectID]);
				if (!Convert.IsDBNull(drw[C_ItemID])) this.lngItemID = Convert.ToInt64(drw[C_ItemID]);
				if (!Convert.IsDBNull(drw[C_QuotaQuantity])) this.decQuotaQuantity = Convert.ToDecimal(drw[C_QuotaQuantity]);
				if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_SpecialBranch_Subject_Item", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_SpecialBranch_Subject_Item_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_SpecialBranch_Subject_Item_GET");
				objIData.AddParameter(P_SBSItemID, this.lngSBSItemID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_SpecialBranch_Subject_Item", objEx);
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
		/// Store: SIM_SpecialBranch_Subject_Item_GET 
		///</summary>
		/// <returns> SIM_SpecialBranch_Subject_Item </returns>
		public SIM_SpecialBranch_Subject_Item Get(long? lngSBSItemID)
		{
			SIM_SpecialBranch_Subject_Item obj = new SIM_SpecialBranch_Subject_Item();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.SBSItemID = lngSBSItemID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_SpecialBranch_Subject_Item
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_SpecialBranch_Subject_Item", objEx);
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
		/// Search : SIM_SpecialBranch_Subject_Item
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_SpecialBranch_Subject_Item", objEx);
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
		/// Search : SIM_SpecialBranch_Subject_Item
		/// Lấy hết dữ liệu
		/// Store: SIM_SpecialBranch_Subject_Item_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_SpecialBranch_Subject_Item_GETALL");
		}

		///<summary>
		/// Search : SIM_SpecialBranch_Subject_Item
		/// Tìm dữ liệu
		/// Store: SIM_SpecialBranch_Subject_Item_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_SpecialBranch_Subject_Item_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_SpecialBranch_Subject_Item
		/// Thêm dữ liệu
		/// Store: SIM_SpecialBranch_Subject_Item_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_SpecialBranch_Subject_Item_ADD");
				objIData.AddParameter(P_SpecialBranchSubjectID, this.lngSpecialBranchSubjectID);
				objIData.AddParameter(P_ItemID, this.lngItemID);
				objIData.AddParameter(P_QuotaQuantity, this.decQuotaQuantity);
				objIData.AddParameter(P_Description, this.strDescription);
				this.lngSBSItemID = Convert.ToInt32(objIData.ExecStoreToString());
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_SpecialBranch_Subject_Item", objEx);
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
		/// Update : SIM_SpecialBranch_Subject_Item
		/// Cập nhật dữ liệu
		/// Store: SIM_SpecialBranch_Subject_Item_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_SpecialBranch_Subject_Item_EDIT");
				objIData.AddParameter(P_SBSItemID, this.lngSBSItemID);
				objIData.AddParameter(P_SpecialBranchSubjectID, this.lngSpecialBranchSubjectID);
				objIData.AddParameter(P_ItemID, this.lngItemID);
				objIData.AddParameter(P_QuotaQuantity, this.decQuotaQuantity);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_SpecialBranch_Subject_Item", objEx);
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
		/// Delete : SIM_SpecialBranch_Subject_Item
		/// Xóa dữ liệu
		/// Store: SIM_SpecialBranch_Subject_Item_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_SpecialBranch_Subject_Item_DELETE");
				objIData.AddParameter(P_SBSItemID, this.lngSBSItemID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_SpecialBranch_Subject_Item", objEx);
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
		/// Store: SIM_SpecialBranch_Subject_Item_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(long? lngSBSItemID)
		{
			this.lngSBSItemID = lngSBSItemID;
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

		public SIM_SpecialBranch_Subject_Item()
		{
		}
		public SIM_SpecialBranch_Subject_Item(long? lngSBSItemID)
		{
			this.lngSBSItemID = lngSBSItemID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_SBSItemID = "@" + C_SBSItemID;
		public const String P_SpecialBranchSubjectID = "@" + C_SpecialBranchSubjectID;
		public const String P_ItemID = "@" + C_ItemID;
		public const String P_QuotaQuantity = "@" + C_QuotaQuantity;
		public const String P_Description = "@" + C_Description;

		#endregion //Parameter names

		#region Column Names

		public const String C_SBSItemID = "SBSItemID";
		public const String C_SpecialBranchSubjectID = "SpecialBranchSubjectID";
		public const String C_ItemID = "ItemID";
		public const String C_QuotaQuantity = "QuotaQuantity";
		public const String C_Description = "Description";

		#endregion //Column names

		#endregion Variable Static		
	}
}
