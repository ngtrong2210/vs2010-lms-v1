
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
	public partial class SIM_OtherWord
	{	
		#region Member Variables

		private int? intOtherWordID = null;
		private string strOtherWordName = null;//Tên chức vụ
		private double? dblRatio = null;//Hệ số chức vụ
		private int? intOtherWordGroupID = null;
		private bool bolIsActived = false;
		private int? intOrderIndex = null;
		private string strDescription = null;//Mô tả chức vụ
		private string strCreatedUser = null;
		private DateTime? dtmCreatedDate = null;
		private string strUpdatedUser = null;
		private DateTime? dtmUpdatedDate = null;
		private IData objIData = null;
		private bool bolIsExistIData = false;
		private Exception objErrorException = null;

		#endregion

		#region Properties 

		/// <summary>
		/// OtherWordID
		/// 
		/// </summary>
		public int? OtherWordID
		{
			get { return  intOtherWordID; }
			set { intOtherWordID = value; }
		}
		/// <summary>
		/// OtherWordName
		/// Tên chức vụ
		/// </summary>
		public string OtherWordName
		{
			get { return  strOtherWordName; }
			set { strOtherWordName = value; }
		}
		/// <summary>
		/// Ratio
		/// Hệ số chức vụ
		/// </summary>
		public double? Ratio
		{
			get { return  dblRatio; }
			set { dblRatio = value; }
		}
		/// <summary>
		/// OtherWordGroupID
		/// 
		/// </summary>
		public int? OtherWordGroupID
		{
			get { return  intOtherWordGroupID; }
			set { intOtherWordGroupID = value; }
		}
		/// <summary>
		/// IsActived
		/// 
		/// </summary>
		public bool IsActived
		{
			get { return  bolIsActived; }
			set { bolIsActived = value; }
		}
		/// <summary>
		/// OrderIndex
		/// 
		/// </summary>
		public int? OrderIndex
		{
			get { return  intOrderIndex; }
			set { intOrderIndex = value; }
		}
		/// <summary>
		/// Description
		/// Mô tả chức vụ
		/// </summary>
		public string Description
		{
			get { return  strDescription; }
			set { strDescription = value; }
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
		/// 
		/// </summary>
		public DateTime? CreatedDate
		{
			get { return  dtmCreatedDate; }
			set { dtmCreatedDate = value; }
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
		/// UpdatedDate
		/// 
		/// </summary>
		public DateTime? UpdatedDate
		{
			get { return  dtmUpdatedDate; }
			set { dtmUpdatedDate = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_OtherWordID.ToUpper()) && !Convert.IsDBNull(reader[C_OtherWordID])) this.intOtherWordID = Convert.ToInt32(reader[C_OtherWordID]);
					if (reader.GetName(i).ToUpper().Equals(C_OtherWordName.ToUpper()) && !Convert.IsDBNull(reader[C_OtherWordName])) this.strOtherWordName = Convert.ToString(reader[C_OtherWordName]);
					if (reader.GetName(i).ToUpper().Equals(C_Ratio.ToUpper()) && !Convert.IsDBNull(reader[C_Ratio])) this.dblRatio = Convert.ToDouble(reader[C_Ratio]);
					if (reader.GetName(i).ToUpper().Equals(C_OtherWordGroupID.ToUpper()) && !Convert.IsDBNull(reader[C_OtherWordGroupID])) this.intOtherWordGroupID = Convert.ToInt32(reader[C_OtherWordGroupID]);
					if (reader.GetName(i).ToUpper().Equals(C_IsActived.ToUpper()) && !Convert.IsDBNull(reader[C_IsActived])) this.bolIsActived = Convert.ToBoolean(reader[C_IsActived]);
					if (reader.GetName(i).ToUpper().Equals(C_OrderIndex.ToUpper()) && !Convert.IsDBNull(reader[C_OrderIndex])) this.intOrderIndex = Convert.ToInt32(reader[C_OrderIndex]);
					if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(reader[C_UpdatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(reader[C_UpdatedDate]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_OtherWord", objEx);
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
				if (!Convert.IsDBNull(drw[C_OtherWordID])) this.intOtherWordID = Convert.ToInt32(drw[C_OtherWordID]);
				if (!Convert.IsDBNull(drw[C_OtherWordName])) this.strOtherWordName = Convert.ToString(drw[C_OtherWordName]);
				if (!Convert.IsDBNull(drw[C_Ratio])) this.dblRatio = Convert.ToDouble(drw[C_Ratio]);
				if (!Convert.IsDBNull(drw[C_OtherWordGroupID])) this.intOtherWordGroupID = Convert.ToInt32(drw[C_OtherWordGroupID]);
				if (!Convert.IsDBNull(drw[C_IsActived])) this.bolIsActived = Convert.ToBoolean(drw[C_IsActived]);
				if (!Convert.IsDBNull(drw[C_OrderIndex])) this.intOrderIndex = Convert.ToInt32(drw[C_OrderIndex]);
				if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
				if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
				if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
				if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
				if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_OtherWord", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_OtherWord_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_OtherWord_GET");
				objIData.AddParameter(P_OtherWordID, this.intOtherWordID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_OtherWord", objEx);
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
		/// Store: SIM_OtherWord_GET 
		///</summary>
		/// <returns> SIM_OtherWord </returns>
		public SIM_OtherWord Get(int? intOtherWordID)
		{
			SIM_OtherWord obj = new SIM_OtherWord();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.OtherWordID = intOtherWordID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_OtherWord
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_OtherWord", objEx);
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
		/// Search : SIM_OtherWord
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_OtherWord", objEx);
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
		/// Search : SIM_OtherWord
		/// Lấy hết dữ liệu
		/// Store: SIM_OtherWord_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_OtherWord_GETALL");
		}

		///<summary>
		/// Search : SIM_OtherWord
		/// Tìm dữ liệu
		/// Store: SIM_OtherWord_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_OtherWord_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_OtherWord
		/// Thêm dữ liệu
		/// Store: SIM_OtherWord_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_OtherWord_ADD");
				objIData.AddParameter(P_OtherWordName, this.strOtherWordName);
				objIData.AddParameter(P_Ratio, this.dblRatio);
				objIData.AddParameter(P_OtherWordGroupID, this.intOtherWordGroupID);
				objIData.AddParameter(P_IsActived, this.bolIsActived);
				objIData.AddParameter(P_OrderIndex, this.intOrderIndex);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				this.intOtherWordID = Convert.ToInt32(objIData.ExecStoreToString());
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_OtherWord", objEx);
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
		/// Update : SIM_OtherWord
		/// Cập nhật dữ liệu
		/// Store: SIM_OtherWord_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_OtherWord_EDIT");
				objIData.AddParameter(P_OtherWordID, this.intOtherWordID);
				objIData.AddParameter(P_OtherWordName, this.strOtherWordName);
				objIData.AddParameter(P_Ratio, this.dblRatio);
				objIData.AddParameter(P_OtherWordGroupID, this.intOtherWordGroupID);
				objIData.AddParameter(P_IsActived, this.bolIsActived);
				objIData.AddParameter(P_OrderIndex, this.intOrderIndex);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_OtherWord", objEx);
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
		/// Delete : SIM_OtherWord
		/// Xóa dữ liệu
		/// Store: SIM_OtherWord_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_OtherWord_DELETE");
				objIData.AddParameter(P_OtherWordID, this.intOtherWordID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_OtherWord", objEx);
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
		/// Store: SIM_OtherWord_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(int? intOtherWordID)
		{
			this.intOtherWordID = intOtherWordID;
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

		public SIM_OtherWord()
		{
		}
		public SIM_OtherWord(int? intOtherWordID)
		{
			this.intOtherWordID = intOtherWordID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_OtherWordID = "@" + C_OtherWordID;
		public const String P_OtherWordName = "@" + C_OtherWordName;
		public const String P_Ratio = "@" + C_Ratio;
		public const String P_OtherWordGroupID = "@" + C_OtherWordGroupID;
		public const String P_IsActived = "@" + C_IsActived;
		public const String P_OrderIndex = "@" + C_OrderIndex;
		public const String P_Description = "@" + C_Description;
		public const String P_CreatedUser = "@" + C_CreatedUser;
		public const String P_CreatedDate = "@" + C_CreatedDate;
		public const String P_UpdatedUser = "@" + C_UpdatedUser;
		public const String P_UpdatedDate = "@" + C_UpdatedDate;

		#endregion //Parameter names

		#region Column Names

		public const String C_OtherWordID = "OtherWordID";
		public const String C_OtherWordName = "OtherWordName";
		public const String C_Ratio = "Ratio";
		public const String C_OtherWordGroupID = "OtherWordGroupID";
		public const String C_IsActived = "IsActived";
		public const String C_OrderIndex = "OrderIndex";
		public const String C_Description = "Description";
		public const String C_CreatedUser = "CreatedUser";
		public const String C_CreatedDate = "CreatedDate";
		public const String C_UpdatedUser = "UpdatedUser";
		public const String C_UpdatedDate = "UpdatedDate";

		#endregion //Column names

		#endregion Variable Static		
	}
}
