
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
	public partial class SIM_Room
	{	
		#region Member Variables

		private string strRoomID = null;//Mã phòng
		private string strRoomName = null;//Tên phòng
		private string strAreaID = null;//Mã dãy nhà
		private int? intSizeForLearning = null;//Sức chứa khi học
		private int? intSizeForTesting = null;//Sức chứa khi thi
		private bool bolIsPracticeRoom = false;//Là phòng thực hành
		private string strCreatedBy = null;
		private DateTime? dtmCreatedAt = null;//Ngày tạo
		private string strModifiedBy = null;//Người sửa
		private DateTime? dtmModifiedAt = null;//Ngày sửa
		private bool bolAllowScheduling = false;//Có cho sắp lịch tự động
		private string strDescription = null;//Mô tả
		private bool bolAllowTestScheduling = false;//Cho phép sắp lịch thi tự động
		private bool bolAllowDuplicateScheduling = false;//Có cho phép trùng phòng không
		private bool bolIsForScheduling = false;//Có dùng cho sắp tkb
		private int? intDepartmentID = null;//Bộ phận quản lý (Mã bộ phận) - Sử dụng cho quản lý tài sản
		private IData objIData = null;
		private bool bolIsExistIData = false;
		private Exception objErrorException = null;

		#endregion

		#region Properties 

		/// <summary>
		/// RoomID
		/// Mã phòng
		/// </summary>
		public string RoomID
		{
			get { return  strRoomID; }
			set { strRoomID = value; }
		}
		/// <summary>
		/// RoomName
		/// Tên phòng
		/// </summary>
		public string RoomName
		{
			get { return  strRoomName; }
			set { strRoomName = value; }
		}
		/// <summary>
		/// AreaID
		/// Mã dãy nhà
		/// </summary>
		public string AreaID
		{
			get { return  strAreaID; }
			set { strAreaID = value; }
		}
		/// <summary>
		/// SizeForLearning
		/// Sức chứa khi học
		/// </summary>
		public int? SizeForLearning
		{
			get { return  intSizeForLearning; }
			set { intSizeForLearning = value; }
		}
		/// <summary>
		/// SizeForTesting
		/// Sức chứa khi thi
		/// </summary>
		public int? SizeForTesting
		{
			get { return  intSizeForTesting; }
			set { intSizeForTesting = value; }
		}
		/// <summary>
		/// IsPracticeRoom
		/// Là phòng thực hành
		/// </summary>
		public bool IsPracticeRoom
		{
			get { return  bolIsPracticeRoom; }
			set { bolIsPracticeRoom = value; }
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
		/// AllowScheduling
		/// Có cho sắp lịch tự động
		/// </summary>
		public bool AllowScheduling
		{
			get { return  bolAllowScheduling; }
			set { bolAllowScheduling = value; }
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
		/// AllowTestScheduling
		/// Cho phép sắp lịch thi tự động
		/// </summary>
		public bool AllowTestScheduling
		{
			get { return  bolAllowTestScheduling; }
			set { bolAllowTestScheduling = value; }
		}
		/// <summary>
		/// AllowDuplicateScheduling
		/// Có cho phép trùng phòng không
		/// </summary>
		public bool AllowDuplicateScheduling
		{
			get { return  bolAllowDuplicateScheduling; }
			set { bolAllowDuplicateScheduling = value; }
		}
		/// <summary>
		/// IsForScheduling
		/// Có dùng cho sắp tkb
		/// </summary>
		public bool IsForScheduling
		{
			get { return  bolIsForScheduling; }
			set { bolIsForScheduling = value; }
		}
		/// <summary>
		/// DepartmentID
		/// Bộ phận quản lý (Mã bộ phận) - Sử dụng cho quản lý tài sản
		/// </summary>
		public int? DepartmentID
		{
			get { return  intDepartmentID; }
			set { intDepartmentID = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_RoomID.ToUpper()) && !Convert.IsDBNull(reader[C_RoomID])) this.strRoomID = Convert.ToString(reader[C_RoomID]);
					if (reader.GetName(i).ToUpper().Equals(C_RoomName.ToUpper()) && !Convert.IsDBNull(reader[C_RoomName])) this.strRoomName = Convert.ToString(reader[C_RoomName]);
					if (reader.GetName(i).ToUpper().Equals(C_AreaID.ToUpper()) && !Convert.IsDBNull(reader[C_AreaID])) this.strAreaID = Convert.ToString(reader[C_AreaID]);
					if (reader.GetName(i).ToUpper().Equals(C_SizeForLearning.ToUpper()) && !Convert.IsDBNull(reader[C_SizeForLearning])) this.intSizeForLearning = Convert.ToInt32(reader[C_SizeForLearning]);
					if (reader.GetName(i).ToUpper().Equals(C_SizeForTesting.ToUpper()) && !Convert.IsDBNull(reader[C_SizeForTesting])) this.intSizeForTesting = Convert.ToInt32(reader[C_SizeForTesting]);
					if (reader.GetName(i).ToUpper().Equals(C_IsPracticeRoom.ToUpper()) && !Convert.IsDBNull(reader[C_IsPracticeRoom])) this.bolIsPracticeRoom = Convert.ToBoolean(reader[C_IsPracticeRoom]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedBy.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedBy])) this.strCreatedBy = Convert.ToString(reader[C_CreatedBy]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(reader[C_CreatedAt]);
					if (reader.GetName(i).ToUpper().Equals(C_ModifiedBy.ToUpper()) && !Convert.IsDBNull(reader[C_ModifiedBy])) this.strModifiedBy = Convert.ToString(reader[C_ModifiedBy]);
					if (reader.GetName(i).ToUpper().Equals(C_ModifiedAt.ToUpper()) && !Convert.IsDBNull(reader[C_ModifiedAt])) this.dtmModifiedAt = Convert.ToDateTime(reader[C_ModifiedAt]);
					if (reader.GetName(i).ToUpper().Equals(C_AllowScheduling.ToUpper()) && !Convert.IsDBNull(reader[C_AllowScheduling])) this.bolAllowScheduling = Convert.ToBoolean(reader[C_AllowScheduling]);
					if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
					if (reader.GetName(i).ToUpper().Equals(C_AllowTestScheduling.ToUpper()) && !Convert.IsDBNull(reader[C_AllowTestScheduling])) this.bolAllowTestScheduling = Convert.ToBoolean(reader[C_AllowTestScheduling]);
					if (reader.GetName(i).ToUpper().Equals(C_AllowDuplicateScheduling.ToUpper()) && !Convert.IsDBNull(reader[C_AllowDuplicateScheduling])) this.bolAllowDuplicateScheduling = Convert.ToBoolean(reader[C_AllowDuplicateScheduling]);
					if (reader.GetName(i).ToUpper().Equals(C_IsForScheduling.ToUpper()) && !Convert.IsDBNull(reader[C_IsForScheduling])) this.bolIsForScheduling = Convert.ToBoolean(reader[C_IsForScheduling]);
					if (reader.GetName(i).ToUpper().Equals(C_DepartmentID.ToUpper()) && !Convert.IsDBNull(reader[C_DepartmentID])) this.intDepartmentID = Convert.ToInt32(reader[C_DepartmentID]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_Room", objEx);
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
				if (!Convert.IsDBNull(drw[C_RoomID])) this.strRoomID = Convert.ToString(drw[C_RoomID]);
				if (!Convert.IsDBNull(drw[C_RoomName])) this.strRoomName = Convert.ToString(drw[C_RoomName]);
				if (!Convert.IsDBNull(drw[C_AreaID])) this.strAreaID = Convert.ToString(drw[C_AreaID]);
				if (!Convert.IsDBNull(drw[C_SizeForLearning])) this.intSizeForLearning = Convert.ToInt32(drw[C_SizeForLearning]);
				if (!Convert.IsDBNull(drw[C_SizeForTesting])) this.intSizeForTesting = Convert.ToInt32(drw[C_SizeForTesting]);
				if (!Convert.IsDBNull(drw[C_IsPracticeRoom])) this.bolIsPracticeRoom = Convert.ToBoolean(drw[C_IsPracticeRoom]);
				if (!Convert.IsDBNull(drw[C_CreatedBy])) this.strCreatedBy = Convert.ToString(drw[C_CreatedBy]);
				if (!Convert.IsDBNull(drw[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(drw[C_CreatedAt]);
				if (!Convert.IsDBNull(drw[C_ModifiedBy])) this.strModifiedBy = Convert.ToString(drw[C_ModifiedBy]);
				if (!Convert.IsDBNull(drw[C_ModifiedAt])) this.dtmModifiedAt = Convert.ToDateTime(drw[C_ModifiedAt]);
				if (!Convert.IsDBNull(drw[C_AllowScheduling])) this.bolAllowScheduling = Convert.ToBoolean(drw[C_AllowScheduling]);
				if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
				if (!Convert.IsDBNull(drw[C_AllowTestScheduling])) this.bolAllowTestScheduling = Convert.ToBoolean(drw[C_AllowTestScheduling]);
				if (!Convert.IsDBNull(drw[C_AllowDuplicateScheduling])) this.bolAllowDuplicateScheduling = Convert.ToBoolean(drw[C_AllowDuplicateScheduling]);
				if (!Convert.IsDBNull(drw[C_IsForScheduling])) this.bolIsForScheduling = Convert.ToBoolean(drw[C_IsForScheduling]);
				if (!Convert.IsDBNull(drw[C_DepartmentID])) this.intDepartmentID = Convert.ToInt32(drw[C_DepartmentID]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_Room", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_Room_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Room_GET");
				objIData.AddParameter(P_RoomID, this.strRoomID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_Room", objEx);
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
		/// Store: SIM_Room_GET 
		///</summary>
		/// <returns> SIM_Room </returns>
		public SIM_Room Get(string strRoomID)
		{
			SIM_Room obj = new SIM_Room();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.RoomID = strRoomID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_Room
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Room", objEx);
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
		/// Search : SIM_Room
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Room", objEx);
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
		/// Search : SIM_Room
		/// Lấy hết dữ liệu
		/// Store: SIM_Room_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_Room_GETALL");
		}

		///<summary>
		/// Search : SIM_Room
		/// Tìm dữ liệu
		/// Store: SIM_Room_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_Room_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_Room
		/// Thêm dữ liệu
		/// Store: SIM_Room_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Room_ADD");
				objIData.AddParameter(P_RoomID, this.strRoomID);
				objIData.AddParameter(P_RoomName, this.strRoomName);
				objIData.AddParameter(P_AreaID, this.strAreaID);
				objIData.AddParameter(P_SizeForLearning, this.intSizeForLearning);
				objIData.AddParameter(P_SizeForTesting, this.intSizeForTesting);
				objIData.AddParameter(P_IsPracticeRoom, this.bolIsPracticeRoom);
				objIData.AddParameter(P_CreatedBy, this.strCreatedBy);
				objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
				objIData.AddParameter(P_ModifiedBy, this.strModifiedBy);
				objIData.AddParameter(P_ModifiedAt, this.dtmModifiedAt);
				objIData.AddParameter(P_AllowScheduling, this.bolAllowScheduling);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_AllowTestScheduling, this.bolAllowTestScheduling);
				objIData.AddParameter(P_AllowDuplicateScheduling, this.bolAllowDuplicateScheduling);
				objIData.AddParameter(P_IsForScheduling, this.bolIsForScheduling);
				objIData.AddParameter(P_DepartmentID, this.intDepartmentID);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_Room", objEx);
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
		/// Update : SIM_Room
		/// Cập nhật dữ liệu
		/// Store: SIM_Room_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Room_EDIT");
				objIData.AddParameter(P_RoomID, this.strRoomID);
				objIData.AddParameter(P_RoomName, this.strRoomName);
				objIData.AddParameter(P_AreaID, this.strAreaID);
				objIData.AddParameter(P_SizeForLearning, this.intSizeForLearning);
				objIData.AddParameter(P_SizeForTesting, this.intSizeForTesting);
				objIData.AddParameter(P_IsPracticeRoom, this.bolIsPracticeRoom);
				objIData.AddParameter(P_CreatedBy, this.strCreatedBy);
				objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
				objIData.AddParameter(P_ModifiedBy, this.strModifiedBy);
				objIData.AddParameter(P_ModifiedAt, this.dtmModifiedAt);
				objIData.AddParameter(P_AllowScheduling, this.bolAllowScheduling);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_AllowTestScheduling, this.bolAllowTestScheduling);
				objIData.AddParameter(P_AllowDuplicateScheduling, this.bolAllowDuplicateScheduling);
				objIData.AddParameter(P_IsForScheduling, this.bolIsForScheduling);
				objIData.AddParameter(P_DepartmentID, this.intDepartmentID);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_Room", objEx);
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
		/// Delete : SIM_Room
		/// Xóa dữ liệu
		/// Store: SIM_Room_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Room_DELETE");
				objIData.AddParameter(P_RoomID, this.strRoomID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_Room", objEx);
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
		/// Store: SIM_Room_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(string strRoomID)
		{
			this.strRoomID = strRoomID;
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

		public SIM_Room()
		{
		}
		public SIM_Room(string strRoomID)
		{
			this.strRoomID = strRoomID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_RoomID = "@" + C_RoomID;
		public const String P_RoomName = "@" + C_RoomName;
		public const String P_AreaID = "@" + C_AreaID;
		public const String P_SizeForLearning = "@" + C_SizeForLearning;
		public const String P_SizeForTesting = "@" + C_SizeForTesting;
		public const String P_IsPracticeRoom = "@" + C_IsPracticeRoom;
		public const String P_CreatedBy = "@" + C_CreatedBy;
		public const String P_CreatedAt = "@" + C_CreatedAt;
		public const String P_ModifiedBy = "@" + C_ModifiedBy;
		public const String P_ModifiedAt = "@" + C_ModifiedAt;
		public const String P_AllowScheduling = "@" + C_AllowScheduling;
		public const String P_Description = "@" + C_Description;
		public const String P_AllowTestScheduling = "@" + C_AllowTestScheduling;
		public const String P_AllowDuplicateScheduling = "@" + C_AllowDuplicateScheduling;
		public const String P_IsForScheduling = "@" + C_IsForScheduling;
		public const String P_DepartmentID = "@" + C_DepartmentID;

		#endregion //Parameter names

		#region Column Names

		public const String C_RoomID = "RoomID";
		public const String C_RoomName = "RoomName";
		public const String C_AreaID = "AreaID";
		public const String C_SizeForLearning = "SizeForLearning";
		public const String C_SizeForTesting = "SizeForTesting";
		public const String C_IsPracticeRoom = "IsPracticeRoom";
		public const String C_CreatedBy = "CreatedBy";
		public const String C_CreatedAt = "CreatedAt";
		public const String C_ModifiedBy = "ModifiedBy";
		public const String C_ModifiedAt = "ModifiedAt";
		public const String C_AllowScheduling = "AllowScheduling";
		public const String C_Description = "Description";
		public const String C_AllowTestScheduling = "AllowTestScheduling";
		public const String C_AllowDuplicateScheduling = "AllowDuplicateScheduling";
		public const String C_IsForScheduling = "IsForScheduling";
		public const String C_DepartmentID = "DepartmentID";

		#endregion //Column names

		#endregion Variable Static		
	}
}
