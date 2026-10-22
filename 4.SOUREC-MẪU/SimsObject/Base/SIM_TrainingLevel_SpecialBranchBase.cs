
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
	public partial class SIM_TrainingLevel_SpecialBranch
	{	
		#region Member Variables

		private int? intTrainingLevel_SpecialBranchID = null;
		private string strTrainingLevelID = null;
		private string strSpecialBranchID = null;
		private string strCreatedUser = null;
		private DateTime? dtmCreatedDate = null;//Ngày tạo
		private IData objIData = null;
		private bool bolIsExistIData = false;
		private Exception objErrorException = null;

		#endregion

		#region Properties 

		/// <summary>
		/// TrainingLevel_SpecialBranchID
		/// 
		/// </summary>
		public int? TrainingLevel_SpecialBranchID
		{
			get { return  intTrainingLevel_SpecialBranchID; }
			set { intTrainingLevel_SpecialBranchID = value; }
		}
		/// <summary>
		/// TrainingLevelID
		/// 
		/// </summary>
		public string TrainingLevelID
		{
			get { return  strTrainingLevelID; }
			set { strTrainingLevelID = value; }
		}
		/// <summary>
		/// SpecialBranchID
		/// 
		/// </summary>
		public string SpecialBranchID
		{
			get { return  strSpecialBranchID; }
			set { strSpecialBranchID = value; }
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
		/// CreatedDate
		/// Ngày tạo
		/// </summary>
		public DateTime? CreatedDate
		{
			get { return  dtmCreatedDate; }
			set { dtmCreatedDate = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_TrainingLevel_SpecialBranchID.ToUpper()) && !Convert.IsDBNull(reader[C_TrainingLevel_SpecialBranchID])) this.intTrainingLevel_SpecialBranchID = Convert.ToInt32(reader[C_TrainingLevel_SpecialBranchID]);
					if (reader.GetName(i).ToUpper().Equals(C_TrainingLevelID.ToUpper()) && !Convert.IsDBNull(reader[C_TrainingLevelID])) this.strTrainingLevelID = Convert.ToString(reader[C_TrainingLevelID]);
					if (reader.GetName(i).ToUpper().Equals(C_SpecialBranchID.ToUpper()) && !Convert.IsDBNull(reader[C_SpecialBranchID])) this.strSpecialBranchID = Convert.ToString(reader[C_SpecialBranchID]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_TrainingLevel_SpecialBranch", objEx);
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
				if (!Convert.IsDBNull(drw[C_TrainingLevel_SpecialBranchID])) this.intTrainingLevel_SpecialBranchID = Convert.ToInt32(drw[C_TrainingLevel_SpecialBranchID]);
				if (!Convert.IsDBNull(drw[C_TrainingLevelID])) this.strTrainingLevelID = Convert.ToString(drw[C_TrainingLevelID]);
				if (!Convert.IsDBNull(drw[C_SpecialBranchID])) this.strSpecialBranchID = Convert.ToString(drw[C_SpecialBranchID]);
				if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
				if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_TrainingLevel_SpecialBranch", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_TrainingLevel_SpecialBranch_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_TrainingLevel_SpecialBranch_GET");
				objIData.AddParameter(P_TrainingLevel_SpecialBranchID, this.intTrainingLevel_SpecialBranchID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_TrainingLevel_SpecialBranch", objEx);
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
		/// Store: SIM_TrainingLevel_SpecialBranch_GET 
		///</summary>
		/// <returns> SIM_TrainingLevel_SpecialBranch </returns>
		public SIM_TrainingLevel_SpecialBranch Get(int? intTrainingLevel_SpecialBranchID)
		{
			SIM_TrainingLevel_SpecialBranch obj = new SIM_TrainingLevel_SpecialBranch();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.TrainingLevel_SpecialBranchID = intTrainingLevel_SpecialBranchID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_TrainingLevel_SpecialBranch
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_TrainingLevel_SpecialBranch", objEx);
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
		/// Search : SIM_TrainingLevel_SpecialBranch
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_TrainingLevel_SpecialBranch", objEx);
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
		/// Search : SIM_TrainingLevel_SpecialBranch
		/// Lấy hết dữ liệu
		/// Store: SIM_TrainingLevel_SpecialBranch_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_TrainingLevel_SpecialBranch_GETALL");
		}

		///<summary>
		/// Search : SIM_TrainingLevel_SpecialBranch
		/// Tìm dữ liệu
		/// Store: SIM_TrainingLevel_SpecialBranch_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_TrainingLevel_SpecialBranch_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_TrainingLevel_SpecialBranch
		/// Thêm dữ liệu
		/// Store: SIM_TrainingLevel_SpecialBranch_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_TrainingLevel_SpecialBranch_ADD");
				objIData.AddParameter(P_TrainingLevelID, this.strTrainingLevelID);
				objIData.AddParameter(P_SpecialBranchID, this.strSpecialBranchID);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				this.intTrainingLevel_SpecialBranchID = Convert.ToInt32(objIData.ExecStoreToString());
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_TrainingLevel_SpecialBranch", objEx);
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
		/// Update : SIM_TrainingLevel_SpecialBranch
		/// Cập nhật dữ liệu
		/// Store: SIM_TrainingLevel_SpecialBranch_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_TrainingLevel_SpecialBranch_EDIT");
				objIData.AddParameter(P_TrainingLevel_SpecialBranchID, this.intTrainingLevel_SpecialBranchID);
				objIData.AddParameter(P_TrainingLevelID, this.strTrainingLevelID);
				objIData.AddParameter(P_SpecialBranchID, this.strSpecialBranchID);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_TrainingLevel_SpecialBranch", objEx);
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
		/// Delete : SIM_TrainingLevel_SpecialBranch
		/// Xóa dữ liệu
		/// Store: SIM_TrainingLevel_SpecialBranch_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_TrainingLevel_SpecialBranch_DELETE");
				objIData.AddParameter(P_TrainingLevel_SpecialBranchID, this.intTrainingLevel_SpecialBranchID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_TrainingLevel_SpecialBranch", objEx);
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
		/// Store: SIM_TrainingLevel_SpecialBranch_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(int? intTrainingLevel_SpecialBranchID)
		{
			this.intTrainingLevel_SpecialBranchID = intTrainingLevel_SpecialBranchID;
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

		public SIM_TrainingLevel_SpecialBranch()
		{
		}
		public SIM_TrainingLevel_SpecialBranch(int? intTrainingLevel_SpecialBranchID)
		{
			this.intTrainingLevel_SpecialBranchID = intTrainingLevel_SpecialBranchID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_TrainingLevel_SpecialBranchID = "@" + C_TrainingLevel_SpecialBranchID;
		public const String P_TrainingLevelID = "@" + C_TrainingLevelID;
		public const String P_SpecialBranchID = "@" + C_SpecialBranchID;
		public const String P_CreatedUser = "@" + C_CreatedUser;
		public const String P_CreatedDate = "@" + C_CreatedDate;

		#endregion //Parameter names

		#region Column Names

		public const String C_TrainingLevel_SpecialBranchID = "TrainingLevel_SpecialBranchID";
		public const String C_TrainingLevelID = "TrainingLevelID";
		public const String C_SpecialBranchID = "SpecialBranchID";
		public const String C_CreatedUser = "CreatedUser";
		public const String C_CreatedDate = "CreatedDate";

		#endregion //Column names

		#endregion Variable Static		
	}
}
