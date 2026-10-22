
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
	public partial class SIM_LearningLevel_TraininigLevel
	{	
		#region Member Variables

		private int? intLearningLevel_TrainingLevelID = null;
		private int? intLearningLevelID = null;
		private string strTrainingLevelID = null;
		private string strCreatedUser = null;
		private DateTime? dtmCreatedDate = null;//Ngày tạo
		private IData objIData = null;
		private bool bolIsExistIData = false;
		private Exception objErrorException = null;

		#endregion

		#region Properties 

		/// <summary>
		/// LearningLevel_TrainingLevelID
		/// 
		/// </summary>
		public int? LearningLevel_TrainingLevelID
		{
			get { return  intLearningLevel_TrainingLevelID; }
			set { intLearningLevel_TrainingLevelID = value; }
		}
		/// <summary>
		/// LearningLevelID
		/// 
		/// </summary>
		public int? LearningLevelID
		{
			get { return  intLearningLevelID; }
			set { intLearningLevelID = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_LearningLevel_TrainingLevelID.ToUpper()) && !Convert.IsDBNull(reader[C_LearningLevel_TrainingLevelID])) this.intLearningLevel_TrainingLevelID = Convert.ToInt32(reader[C_LearningLevel_TrainingLevelID]);
					if (reader.GetName(i).ToUpper().Equals(C_LearningLevelID.ToUpper()) && !Convert.IsDBNull(reader[C_LearningLevelID])) this.intLearningLevelID = Convert.ToInt32(reader[C_LearningLevelID]);
					if (reader.GetName(i).ToUpper().Equals(C_TrainingLevelID.ToUpper()) && !Convert.IsDBNull(reader[C_TrainingLevelID])) this.strTrainingLevelID = Convert.ToString(reader[C_TrainingLevelID]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_LearningLevel_TraininigLevel", objEx);
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
				if (!Convert.IsDBNull(drw[C_LearningLevel_TrainingLevelID])) this.intLearningLevel_TrainingLevelID = Convert.ToInt32(drw[C_LearningLevel_TrainingLevelID]);
				if (!Convert.IsDBNull(drw[C_LearningLevelID])) this.intLearningLevelID = Convert.ToInt32(drw[C_LearningLevelID]);
				if (!Convert.IsDBNull(drw[C_TrainingLevelID])) this.strTrainingLevelID = Convert.ToString(drw[C_TrainingLevelID]);
				if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
				if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_LearningLevel_TraininigLevel", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_LearningLevel_TraininigLevel_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_LearningLevel_TraininigLevel_GET");
				objIData.AddParameter(P_LearningLevel_TrainingLevelID, this.intLearningLevel_TrainingLevelID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_LearningLevel_TraininigLevel", objEx);
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
		/// Store: SIM_LearningLevel_TraininigLevel_GET 
		///</summary>
		/// <returns> SIM_LearningLevel_TraininigLevel </returns>
		public SIM_LearningLevel_TraininigLevel Get(int? intLearningLevel_TrainingLevelID)
		{
			SIM_LearningLevel_TraininigLevel obj = new SIM_LearningLevel_TraininigLevel();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.LearningLevel_TrainingLevelID = intLearningLevel_TrainingLevelID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_LearningLevel_TraininigLevel
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_LearningLevel_TraininigLevel", objEx);
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
		/// Search : SIM_LearningLevel_TraininigLevel
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_LearningLevel_TraininigLevel", objEx);
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
		/// Search : SIM_LearningLevel_TraininigLevel
		/// Lấy hết dữ liệu
		/// Store: SIM_LearningLevel_TraininigLevel_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_LearningLevel_TraininigLevel_GETALL");
		}

		///<summary>
		/// Search : SIM_LearningLevel_TraininigLevel
		/// Tìm dữ liệu
		/// Store: SIM_LearningLevel_TraininigLevel_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_LearningLevel_TraininigLevel_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_LearningLevel_TraininigLevel
		/// Thêm dữ liệu
		/// Store: SIM_LearningLevel_TraininigLevel_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_LearningLevel_TraininigLevel_ADD");
				objIData.AddParameter(P_LearningLevelID, this.intLearningLevelID);
				objIData.AddParameter(P_TrainingLevelID, this.strTrainingLevelID);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				this.intLearningLevel_TrainingLevelID = Convert.ToInt32(objIData.ExecStoreToString());
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_LearningLevel_TraininigLevel", objEx);
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
		/// Update : SIM_LearningLevel_TraininigLevel
		/// Cập nhật dữ liệu
		/// Store: SIM_LearningLevel_TraininigLevel_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_LearningLevel_TraininigLevel_EDIT");
				objIData.AddParameter(P_LearningLevel_TrainingLevelID, this.intLearningLevel_TrainingLevelID);
				objIData.AddParameter(P_LearningLevelID, this.intLearningLevelID);
				objIData.AddParameter(P_TrainingLevelID, this.strTrainingLevelID);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_LearningLevel_TraininigLevel", objEx);
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
		/// Delete : SIM_LearningLevel_TraininigLevel
		/// Xóa dữ liệu
		/// Store: SIM_LearningLevel_TraininigLevel_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_LearningLevel_TraininigLevel_DELETE");
				objIData.AddParameter(P_LearningLevel_TrainingLevelID, this.intLearningLevel_TrainingLevelID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_LearningLevel_TraininigLevel", objEx);
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
		/// Store: SIM_LearningLevel_TraininigLevel_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(int? intLearningLevel_TrainingLevelID)
		{
			this.intLearningLevel_TrainingLevelID = intLearningLevel_TrainingLevelID;
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

		public SIM_LearningLevel_TraininigLevel()
		{
		}
		public SIM_LearningLevel_TraininigLevel(int? intLearningLevel_TrainingLevelID)
		{
			this.intLearningLevel_TrainingLevelID = intLearningLevel_TrainingLevelID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_LearningLevel_TrainingLevelID = "@" + C_LearningLevel_TrainingLevelID;
		public const String P_LearningLevelID = "@" + C_LearningLevelID;
		public const String P_TrainingLevelID = "@" + C_TrainingLevelID;
		public const String P_CreatedUser = "@" + C_CreatedUser;
		public const String P_CreatedDate = "@" + C_CreatedDate;

		#endregion //Parameter names

		#region Column Names

		public const String C_LearningLevel_TrainingLevelID = "LearningLevel_TrainingLevelID";
		public const String C_LearningLevelID = "LearningLevelID";
		public const String C_TrainingLevelID = "TrainingLevelID";
		public const String C_CreatedUser = "CreatedUser";
		public const String C_CreatedDate = "CreatedDate";

		#endregion //Column names

		#endregion Variable Static		
	}
}
