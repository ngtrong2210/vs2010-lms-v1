
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
	public partial class SIM_Class_Subject_Room
	{	
		#region Member Variables

		private long? lngCSRoomID = null;
		private long? lngClassSubjectID = null;
		private string strRoomID = null;
		private int? intFromLession = null;//Dự kiến dạy từ tiết (0_là ko quy định)
		private int? intToLession = null;//Dự kiến dạy đến tiết (0_không quy định)
		private int? intFromWeek = null;//Dự kiến dạy từ tuần
		private int? intToWeek = null;//Dự kiến dạy đến tuần
		private bool bolForTheory = false;//Học lý thuyết?
		private bool bolForPractice = false;//Học thực hành?
		private bool bolIsMainRoom = false;//Là phòng học chính
		private int? intIsActived = null;//Kích hoạt
		private int? intOrderIndex = null;
		private string strDescription = null;
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
		/// CSRoomID
		/// 
		/// </summary>
		public long? CSRoomID
		{
			get { return  lngCSRoomID; }
			set { lngCSRoomID = value; }
		}
		/// <summary>
		/// ClassSubjectID
		/// 
		/// </summary>
		public long? ClassSubjectID
		{
			get { return  lngClassSubjectID; }
			set { lngClassSubjectID = value; }
		}
		/// <summary>
		/// RoomID
		/// 
		/// </summary>
		public string RoomID
		{
			get { return  strRoomID; }
			set { strRoomID = value; }
		}
		/// <summary>
		/// FromLession
		/// Dự kiến dạy từ tiết (0_là ko quy định)
		/// </summary>
		public int? FromLession
		{
			get { return  intFromLession; }
			set { intFromLession = value; }
		}
		/// <summary>
		/// ToLession
		/// Dự kiến dạy đến tiết (0_không quy định)
		/// </summary>
		public int? ToLession
		{
			get { return  intToLession; }
			set { intToLession = value; }
		}
		/// <summary>
		/// FromWeek
		/// Dự kiến dạy từ tuần
		/// </summary>
		public int? FromWeek
		{
			get { return  intFromWeek; }
			set { intFromWeek = value; }
		}
		/// <summary>
		/// ToWeek
		/// Dự kiến dạy đến tuần
		/// </summary>
		public int? ToWeek
		{
			get { return  intToWeek; }
			set { intToWeek = value; }
		}
		/// <summary>
		/// ForTheory
		/// Học lý thuyết?
		/// </summary>
		public bool ForTheory
		{
			get { return  bolForTheory; }
			set { bolForTheory = value; }
		}
		/// <summary>
		/// ForPractice
		/// Học thực hành?
		/// </summary>
		public bool ForPractice
		{
			get { return  bolForPractice; }
			set { bolForPractice = value; }
		}
		/// <summary>
		/// IsMainRoom
		/// Là phòng học chính
		/// </summary>
		public bool IsMainRoom
		{
			get { return  bolIsMainRoom; }
			set { bolIsMainRoom = value; }
		}
		/// <summary>
		/// IsActived
		/// Kích hoạt
		/// </summary>
		public int? IsActived
		{
			get { return  intIsActived; }
			set { intIsActived = value; }
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
		/// 
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
					if (reader.GetName(i).ToUpper().Equals(C_CSRoomID.ToUpper()) && !Convert.IsDBNull(reader[C_CSRoomID])) this.lngCSRoomID = Convert.ToInt64(reader[C_CSRoomID]);
					if (reader.GetName(i).ToUpper().Equals(C_ClassSubjectID.ToUpper()) && !Convert.IsDBNull(reader[C_ClassSubjectID])) this.lngClassSubjectID = Convert.ToInt64(reader[C_ClassSubjectID]);
					if (reader.GetName(i).ToUpper().Equals(C_RoomID.ToUpper()) && !Convert.IsDBNull(reader[C_RoomID])) this.strRoomID = Convert.ToString(reader[C_RoomID]);
					if (reader.GetName(i).ToUpper().Equals(C_FromLession.ToUpper()) && !Convert.IsDBNull(reader[C_FromLession])) this.intFromLession = Convert.ToInt32(reader[C_FromLession]);
					if (reader.GetName(i).ToUpper().Equals(C_ToLession.ToUpper()) && !Convert.IsDBNull(reader[C_ToLession])) this.intToLession = Convert.ToInt32(reader[C_ToLession]);
					if (reader.GetName(i).ToUpper().Equals(C_FromWeek.ToUpper()) && !Convert.IsDBNull(reader[C_FromWeek])) this.intFromWeek = Convert.ToInt32(reader[C_FromWeek]);
					if (reader.GetName(i).ToUpper().Equals(C_ToWeek.ToUpper()) && !Convert.IsDBNull(reader[C_ToWeek])) this.intToWeek = Convert.ToInt32(reader[C_ToWeek]);
					if (reader.GetName(i).ToUpper().Equals(C_ForTheory.ToUpper()) && !Convert.IsDBNull(reader[C_ForTheory])) this.bolForTheory = Convert.ToBoolean(reader[C_ForTheory]);
					if (reader.GetName(i).ToUpper().Equals(C_ForPractice.ToUpper()) && !Convert.IsDBNull(reader[C_ForPractice])) this.bolForPractice = Convert.ToBoolean(reader[C_ForPractice]);
					if (reader.GetName(i).ToUpper().Equals(C_IsMainRoom.ToUpper()) && !Convert.IsDBNull(reader[C_IsMainRoom])) this.bolIsMainRoom = Convert.ToBoolean(reader[C_IsMainRoom]);
					if (reader.GetName(i).ToUpper().Equals(C_IsActived.ToUpper()) && !Convert.IsDBNull(reader[C_IsActived])) this.intIsActived = Convert.ToInt32(reader[C_IsActived]);
					if (reader.GetName(i).ToUpper().Equals(C_OrderIndex.ToUpper()) && !Convert.IsDBNull(reader[C_OrderIndex])) this.intOrderIndex = Convert.ToInt32(reader[C_OrderIndex]);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_Class_Subject_Room", objEx);
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
				if (!Convert.IsDBNull(drw[C_CSRoomID])) this.lngCSRoomID = Convert.ToInt64(drw[C_CSRoomID]);
				if (!Convert.IsDBNull(drw[C_ClassSubjectID])) this.lngClassSubjectID = Convert.ToInt64(drw[C_ClassSubjectID]);
				if (!Convert.IsDBNull(drw[C_RoomID])) this.strRoomID = Convert.ToString(drw[C_RoomID]);
				if (!Convert.IsDBNull(drw[C_FromLession])) this.intFromLession = Convert.ToInt32(drw[C_FromLession]);
				if (!Convert.IsDBNull(drw[C_ToLession])) this.intToLession = Convert.ToInt32(drw[C_ToLession]);
				if (!Convert.IsDBNull(drw[C_FromWeek])) this.intFromWeek = Convert.ToInt32(drw[C_FromWeek]);
				if (!Convert.IsDBNull(drw[C_ToWeek])) this.intToWeek = Convert.ToInt32(drw[C_ToWeek]);
				if (!Convert.IsDBNull(drw[C_ForTheory])) this.bolForTheory = Convert.ToBoolean(drw[C_ForTheory]);
				if (!Convert.IsDBNull(drw[C_ForPractice])) this.bolForPractice = Convert.ToBoolean(drw[C_ForPractice]);
				if (!Convert.IsDBNull(drw[C_IsMainRoom])) this.bolIsMainRoom = Convert.ToBoolean(drw[C_IsMainRoom]);
				if (!Convert.IsDBNull(drw[C_IsActived])) this.intIsActived = Convert.ToInt32(drw[C_IsActived]);
				if (!Convert.IsDBNull(drw[C_OrderIndex])) this.intOrderIndex = Convert.ToInt32(drw[C_OrderIndex]);
				if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
				if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
				if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
				if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
				if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_Class_Subject_Room", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_Class_Subject_Room_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Class_Subject_Room_GET");
				objIData.AddParameter(P_CSRoomID, this.lngCSRoomID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_Class_Subject_Room", objEx);
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
		/// Store: SIM_Class_Subject_Room_GET 
		///</summary>
		/// <returns> SIM_Class_Subject_Room </returns>
		public SIM_Class_Subject_Room Get(long? lngCSRoomID)
		{
			SIM_Class_Subject_Room obj = new SIM_Class_Subject_Room();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.CSRoomID = lngCSRoomID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_Class_Subject_Room
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Class_Subject_Room", objEx);
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
		/// Search : SIM_Class_Subject_Room
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Class_Subject_Room", objEx);
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
		/// Search : SIM_Class_Subject_Room
		/// Lấy hết dữ liệu
		/// Store: SIM_Class_Subject_Room_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_Class_Subject_Room_GETALL");
		}

		///<summary>
		/// Search : SIM_Class_Subject_Room
		/// Tìm dữ liệu
		/// Store: SIM_Class_Subject_Room_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_Class_Subject_Room_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_Class_Subject_Room
		/// Thêm dữ liệu
		/// Store: SIM_Class_Subject_Room_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Class_Subject_Room_ADD");
				objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
				objIData.AddParameter(P_RoomID, this.strRoomID);
				objIData.AddParameter(P_FromLession, this.intFromLession);
				objIData.AddParameter(P_ToLession, this.intToLession);
				objIData.AddParameter(P_FromWeek, this.intFromWeek);
				objIData.AddParameter(P_ToWeek, this.intToWeek);
				objIData.AddParameter(P_ForTheory, this.bolForTheory);
				objIData.AddParameter(P_ForPractice, this.bolForPractice);
				objIData.AddParameter(P_IsMainRoom, this.bolIsMainRoom);
				objIData.AddParameter(P_IsActived, this.intIsActived);
				objIData.AddParameter(P_OrderIndex, this.intOrderIndex);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				this.lngCSRoomID = Convert.ToInt32(objIData.ExecStoreToString());
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_Class_Subject_Room", objEx);
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
		/// Update : SIM_Class_Subject_Room
		/// Cập nhật dữ liệu
		/// Store: SIM_Class_Subject_Room_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Class_Subject_Room_EDIT");
				objIData.AddParameter(P_CSRoomID, this.lngCSRoomID);
				objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
				objIData.AddParameter(P_RoomID, this.strRoomID);
				objIData.AddParameter(P_FromLession, this.intFromLession);
				objIData.AddParameter(P_ToLession, this.intToLession);
				objIData.AddParameter(P_FromWeek, this.intFromWeek);
				objIData.AddParameter(P_ToWeek, this.intToWeek);
				objIData.AddParameter(P_ForTheory, this.bolForTheory);
				objIData.AddParameter(P_ForPractice, this.bolForPractice);
				objIData.AddParameter(P_IsMainRoom, this.bolIsMainRoom);
				objIData.AddParameter(P_IsActived, this.intIsActived);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_Class_Subject_Room", objEx);
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
		/// Delete : SIM_Class_Subject_Room
		/// Xóa dữ liệu
		/// Store: SIM_Class_Subject_Room_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Class_Subject_Room_DELETE");
				objIData.AddParameter(P_CSRoomID, this.lngCSRoomID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_Class_Subject_Room", objEx);
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
		/// Store: SIM_Class_Subject_Room_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(long? lngCSRoomID)
		{
			this.lngCSRoomID = lngCSRoomID;
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

		public SIM_Class_Subject_Room()
		{
		}
		public SIM_Class_Subject_Room(long? lngCSRoomID)
		{
			this.lngCSRoomID = lngCSRoomID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_CSRoomID = "@" + C_CSRoomID;
		public const String P_ClassSubjectID = "@" + C_ClassSubjectID;
		public const String P_RoomID = "@" + C_RoomID;
		public const String P_FromLession = "@" + C_FromLession;
		public const String P_ToLession = "@" + C_ToLession;
		public const String P_FromWeek = "@" + C_FromWeek;
		public const String P_ToWeek = "@" + C_ToWeek;
		public const String P_ForTheory = "@" + C_ForTheory;
		public const String P_ForPractice = "@" + C_ForPractice;
		public const String P_IsMainRoom = "@" + C_IsMainRoom;
		public const String P_IsActived = "@" + C_IsActived;
		public const String P_OrderIndex = "@" + C_OrderIndex;
		public const String P_Description = "@" + C_Description;
		public const String P_CreatedDate = "@" + C_CreatedDate;
		public const String P_CreatedUser = "@" + C_CreatedUser;
		public const String P_UpdatedDate = "@" + C_UpdatedDate;
		public const String P_UpdatedUser = "@" + C_UpdatedUser;

		#endregion //Parameter names

		#region Column Names

		public const String C_CSRoomID = "CSRoomID";
		public const String C_ClassSubjectID = "ClassSubjectID";
		public const String C_RoomID = "RoomID";
		public const String C_FromLession = "FromLession";
		public const String C_ToLession = "ToLession";
		public const String C_FromWeek = "FromWeek";
		public const String C_ToWeek = "ToWeek";
		public const String C_ForTheory = "ForTheory";
		public const String C_ForPractice = "ForPractice";
		public const String C_IsMainRoom = "IsMainRoom";
		public const String C_IsActived = "IsActived";
		public const String C_OrderIndex = "OrderIndex";
		public const String C_Description = "Description";
		public const String C_CreatedDate = "CreatedDate";
		public const String C_CreatedUser = "CreatedUser";
		public const String C_UpdatedDate = "UpdatedDate";
		public const String C_UpdatedUser = "UpdatedUser";

		#endregion //Column names

		#endregion Variable Static		
	}
}
