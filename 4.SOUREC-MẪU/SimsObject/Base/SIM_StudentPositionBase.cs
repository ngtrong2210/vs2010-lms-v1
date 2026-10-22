
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
	/// Created date 	: 25/09/2018 
	/// Description 
	/// </summary>	
	public partial class SIM_StudentPosition
	{	
		#region Member Variables

		private int? intStudentPositionID = null;//Mã chức vụ
		private string strStudentPositionCode = null;//Tên chức vụ
		private string strStudentPositionName = null;//Tên chức vụ
		private decimal? decAddMark = null;//Điểm cộng (để xét học bỗng)
		private int? intOrderIndex = null;
		private bool bolIsDefault = false;
		private bool bolIsActived = false;
		private bool bolIsSystem = false;
		private string strDescription = null;//Mô tả
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
		/// StudentPositionID
		/// Mã chức vụ
		/// </summary>
		public int? StudentPositionID
		{
			get { return  intStudentPositionID; }
			set { intStudentPositionID = value; }
		}
		/// <summary>
		/// StudentPositionCode
		/// Tên chức vụ
		/// </summary>
		public string StudentPositionCode
		{
			get { return  strStudentPositionCode; }
			set { strStudentPositionCode = value; }
		}
		/// <summary>
		/// StudentPositionName
		/// Tên chức vụ
		/// </summary>
		public string StudentPositionName
		{
			get { return  strStudentPositionName; }
			set { strStudentPositionName = value; }
		}
		/// <summary>
		/// AddMark
		/// Điểm cộng (để xét học bỗng)
		/// </summary>
		public decimal? AddMark
		{
			get { return  decAddMark; }
			set { decAddMark = value; }
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
		/// IsDefault
		/// 
		/// </summary>
		public bool IsDefault
		{
			get { return  bolIsDefault; }
			set { bolIsDefault = value; }
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
		/// IsSystem
		/// 
		/// </summary>
		public bool IsSystem
		{
			get { return  bolIsSystem; }
			set { bolIsSystem = value; }
		}
		/// <summary>
		/// Description
		/// Mô tả
		/// </summary>
		public string Description
		{
			get { return  strDescription; }
			set { strDescription = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_StudentPositionID.ToUpper()) && !Convert.IsDBNull(reader[C_StudentPositionID])) this.intStudentPositionID = Convert.ToInt32(reader[C_StudentPositionID]);
					if (reader.GetName(i).ToUpper().Equals(C_StudentPositionCode.ToUpper()) && !Convert.IsDBNull(reader[C_StudentPositionCode])) this.strStudentPositionCode = Convert.ToString(reader[C_StudentPositionCode]);
					if (reader.GetName(i).ToUpper().Equals(C_StudentPositionName.ToUpper()) && !Convert.IsDBNull(reader[C_StudentPositionName])) this.strStudentPositionName = Convert.ToString(reader[C_StudentPositionName]);
					if (reader.GetName(i).ToUpper().Equals(C_AddMark.ToUpper()) && !Convert.IsDBNull(reader[C_AddMark])) this.decAddMark = Convert.ToDecimal(reader[C_AddMark]);
					if (reader.GetName(i).ToUpper().Equals(C_OrderIndex.ToUpper()) && !Convert.IsDBNull(reader[C_OrderIndex])) this.intOrderIndex = Convert.ToInt32(reader[C_OrderIndex]);
					if (reader.GetName(i).ToUpper().Equals(C_IsDefault.ToUpper()) && !Convert.IsDBNull(reader[C_IsDefault])) this.bolIsDefault = Convert.ToBoolean(reader[C_IsDefault]);
					if (reader.GetName(i).ToUpper().Equals(C_IsActived.ToUpper()) && !Convert.IsDBNull(reader[C_IsActived])) this.bolIsActived = Convert.ToBoolean(reader[C_IsActived]);
					if (reader.GetName(i).ToUpper().Equals(C_IsSystem.ToUpper()) && !Convert.IsDBNull(reader[C_IsSystem])) this.bolIsSystem = Convert.ToBoolean(reader[C_IsSystem]);
					if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(reader[C_UpdatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(reader[C_UpdatedUser]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_StudentPosition", objEx);
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
				if (!Convert.IsDBNull(drw[C_StudentPositionID])) this.intStudentPositionID = Convert.ToInt32(drw[C_StudentPositionID]);
				if (!Convert.IsDBNull(drw[C_StudentPositionCode])) this.strStudentPositionCode = Convert.ToString(drw[C_StudentPositionCode]);
				if (!Convert.IsDBNull(drw[C_StudentPositionName])) this.strStudentPositionName = Convert.ToString(drw[C_StudentPositionName]);
				if (!Convert.IsDBNull(drw[C_AddMark])) this.decAddMark = Convert.ToDecimal(drw[C_AddMark]);
				if (!Convert.IsDBNull(drw[C_OrderIndex])) this.intOrderIndex = Convert.ToInt32(drw[C_OrderIndex]);
				if (!Convert.IsDBNull(drw[C_IsDefault])) this.bolIsDefault = Convert.ToBoolean(drw[C_IsDefault]);
				if (!Convert.IsDBNull(drw[C_IsActived])) this.bolIsActived = Convert.ToBoolean(drw[C_IsActived]);
				if (!Convert.IsDBNull(drw[C_IsSystem])) this.bolIsSystem = Convert.ToBoolean(drw[C_IsSystem]);
				if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
				if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
				if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
				if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
				if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_StudentPosition", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_StudentPosition_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_StudentPosition_GET");
				objIData.AddParameter(P_StudentPositionID, this.intStudentPositionID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_StudentPosition", objEx);
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
		/// Store: SIM_StudentPosition_GET 
		///</summary>
		/// <returns> SIM_StudentPosition </returns>
		public SIM_StudentPosition Get(int? intStudentPositionID)
		{
			SIM_StudentPosition obj = new SIM_StudentPosition();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.StudentPositionID = intStudentPositionID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_StudentPosition
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_StudentPosition", objEx);
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
		/// Search : SIM_StudentPosition
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_StudentPosition", objEx);
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
		/// Search : SIM_StudentPosition
		/// Lấy hết dữ liệu
		/// Store: SIM_StudentPosition_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_StudentPosition_GETALL");
		}

		///<summary>
		/// Search : SIM_StudentPosition
		/// Tìm dữ liệu
		/// Store: SIM_StudentPosition_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_StudentPosition_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_StudentPosition
		/// Thêm dữ liệu
		/// Store: SIM_StudentPosition_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_StudentPosition_ADD");
				objIData.AddParameter(P_StudentPositionCode, this.strStudentPositionCode);
				objIData.AddParameter(P_StudentPositionName, this.strStudentPositionName);
				objIData.AddParameter(P_AddMark, this.decAddMark);
				objIData.AddParameter(P_OrderIndex, this.intOrderIndex);
				objIData.AddParameter(P_IsDefault, this.bolIsDefault);
				objIData.AddParameter(P_IsActived, this.bolIsActived);
				objIData.AddParameter(P_IsSystem, this.bolIsSystem);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				this.intStudentPositionID = Convert.ToInt32(objIData.ExecStoreToString());
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_StudentPosition", objEx);
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
		/// Update : SIM_StudentPosition
		/// Cập nhật dữ liệu
		/// Store: SIM_StudentPosition_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_StudentPosition_EDIT");
				objIData.AddParameter(P_StudentPositionID, this.intStudentPositionID);
				objIData.AddParameter(P_StudentPositionCode, this.strStudentPositionCode);
				objIData.AddParameter(P_StudentPositionName, this.strStudentPositionName);
				objIData.AddParameter(P_AddMark, this.decAddMark);
				objIData.AddParameter(P_OrderIndex, this.intOrderIndex);
				objIData.AddParameter(P_IsDefault, this.bolIsDefault);
				objIData.AddParameter(P_IsActived, this.bolIsActived);
				objIData.AddParameter(P_IsSystem, this.bolIsSystem);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_StudentPosition", objEx);
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
		/// Delete : SIM_StudentPosition
		/// Xóa dữ liệu
		/// Store: SIM_StudentPosition_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_StudentPosition_DELETE");
				objIData.AddParameter(P_StudentPositionID, this.intStudentPositionID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_StudentPosition", objEx);
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
		/// Store: SIM_StudentPosition_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(int? intStudentPositionID)
		{
			this.intStudentPositionID = intStudentPositionID;
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

		public SIM_StudentPosition()
		{
		}
		public SIM_StudentPosition(int? intStudentPositionID)
		{
			this.intStudentPositionID = intStudentPositionID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_StudentPositionID = "@" + C_StudentPositionID;
		public const String P_StudentPositionCode = "@" + C_StudentPositionCode;
		public const String P_StudentPositionName = "@" + C_StudentPositionName;
		public const String P_AddMark = "@" + C_AddMark;
		public const String P_OrderIndex = "@" + C_OrderIndex;
		public const String P_IsDefault = "@" + C_IsDefault;
		public const String P_IsActived = "@" + C_IsActived;
		public const String P_IsSystem = "@" + C_IsSystem;
		public const String P_Description = "@" + C_Description;
		public const String P_CreatedDate = "@" + C_CreatedDate;
		public const String P_CreatedUser = "@" + C_CreatedUser;
		public const String P_UpdatedDate = "@" + C_UpdatedDate;
		public const String P_UpdatedUser = "@" + C_UpdatedUser;

		#endregion //Parameter names

		#region Column Names

		public const String C_StudentPositionID = "StudentPositionID";
		public const String C_StudentPositionCode = "StudentPositionCode";
		public const String C_StudentPositionName = "StudentPositionName";
		public const String C_AddMark = "AddMark";
		public const String C_OrderIndex = "OrderIndex";
		public const String C_IsDefault = "IsDefault";
		public const String C_IsActived = "IsActived";
		public const String C_IsSystem = "IsSystem";
		public const String C_Description = "Description";
		public const String C_CreatedDate = "CreatedDate";
		public const String C_CreatedUser = "CreatedUser";
		public const String C_UpdatedDate = "UpdatedDate";
		public const String C_UpdatedUser = "UpdatedUser";

		#endregion //Column names

		#endregion Variable Static		
	}
}
