
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
	/// Created date 	: 05/12/2019 
	/// Description 
	/// </summary>	
	public partial class SIM_UnionEventRegister
	{	
		#region Member Variables

		private long? lngUnionEventRegisterID = null;
		private long? lngStudentID = null;//Mã sinh viên tự sinh
		private int? intUnionEventID = null;
		private DateTime? dtmRegisterDate = null;//Ngày tạo
		private bool bolIsChecking = false;//Có tham gia (có điểm danh)
		private int? intMark = null;
		private string strComment = null;//Nhận xét
		private string strDescription = null;//Mô tả
		private DateTime? dtmCreatedDate = null;//Ngày tạo
		private string strCreatedUser = null;//Người tạo
		private DateTime? dtmUpdatedDate = null;//Ngày cập nhật cuối
		private string strUpdatedUser = null;//Cho điểm đánh giá
		private IData objIData = null;
		private bool bolIsExistIData = false;
		private Exception objErrorException = null;

		#endregion

		#region Properties 

		/// <summary>
		/// UnionEventRegisterID
		/// 
		/// </summary>
		public long? UnionEventRegisterID
		{
			get { return  lngUnionEventRegisterID; }
			set { lngUnionEventRegisterID = value; }
		}
		/// <summary>
		/// StudentID
		/// Mã sinh viên tự sinh
		/// </summary>
		public long? StudentID
		{
			get { return  lngStudentID; }
			set { lngStudentID = value; }
		}
		/// <summary>
		/// UnionEventID
		/// 
		/// </summary>
		public int? UnionEventID
		{
			get { return  intUnionEventID; }
			set { intUnionEventID = value; }
		}
		/// <summary>
		/// RegisterDate
		/// Ngày tạo
		/// </summary>
		public DateTime? RegisterDate
		{
			get { return  dtmRegisterDate; }
			set { dtmRegisterDate = value; }
		}
		/// <summary>
		/// IsChecking
		/// Có tham gia (có điểm danh)
		/// </summary>
		public bool IsChecking
		{
			get { return  bolIsChecking; }
			set { bolIsChecking = value; }
		}
		/// <summary>
		/// Mark
		/// 
		/// </summary>
		public int? Mark
		{
			get { return  intMark; }
			set { intMark = value; }
		}
		/// <summary>
		/// Comment
		/// Nhận xét
		/// </summary>
		public string Comment
		{
			get { return  strComment; }
			set { strComment = value; }
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
		/// Cho điểm đánh giá
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
					if (reader.GetName(i).ToUpper().Equals(C_UnionEventRegisterID.ToUpper()) && !Convert.IsDBNull(reader[C_UnionEventRegisterID])) this.lngUnionEventRegisterID = Convert.ToInt64(reader[C_UnionEventRegisterID]);
					if (reader.GetName(i).ToUpper().Equals(C_StudentID.ToUpper()) && !Convert.IsDBNull(reader[C_StudentID])) this.lngStudentID = Convert.ToInt64(reader[C_StudentID]);
					if (reader.GetName(i).ToUpper().Equals(C_UnionEventID.ToUpper()) && !Convert.IsDBNull(reader[C_UnionEventID])) this.intUnionEventID = Convert.ToInt32(reader[C_UnionEventID]);
					if (reader.GetName(i).ToUpper().Equals(C_RegisterDate.ToUpper()) && !Convert.IsDBNull(reader[C_RegisterDate])) this.dtmRegisterDate = Convert.ToDateTime(reader[C_RegisterDate]);
					if (reader.GetName(i).ToUpper().Equals(C_IsChecking.ToUpper()) && !Convert.IsDBNull(reader[C_IsChecking])) this.bolIsChecking = Convert.ToBoolean(reader[C_IsChecking]);
					if (reader.GetName(i).ToUpper().Equals(C_Mark.ToUpper()) && !Convert.IsDBNull(reader[C_Mark])) this.intMark = Convert.ToInt32(reader[C_Mark]);
					if (reader.GetName(i).ToUpper().Equals(C_Comment.ToUpper()) && !Convert.IsDBNull(reader[C_Comment])) this.strComment = Convert.ToString(reader[C_Comment]);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_UnionEventRegister", objEx);
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
				if (!Convert.IsDBNull(drw[C_UnionEventRegisterID])) this.lngUnionEventRegisterID = Convert.ToInt64(drw[C_UnionEventRegisterID]);
				if (!Convert.IsDBNull(drw[C_StudentID])) this.lngStudentID = Convert.ToInt64(drw[C_StudentID]);
				if (!Convert.IsDBNull(drw[C_UnionEventID])) this.intUnionEventID = Convert.ToInt32(drw[C_UnionEventID]);
				if (!Convert.IsDBNull(drw[C_RegisterDate])) this.dtmRegisterDate = Convert.ToDateTime(drw[C_RegisterDate]);
				if (!Convert.IsDBNull(drw[C_IsChecking])) this.bolIsChecking = Convert.ToBoolean(drw[C_IsChecking]);
				if (!Convert.IsDBNull(drw[C_Mark])) this.intMark = Convert.ToInt32(drw[C_Mark]);
				if (!Convert.IsDBNull(drw[C_Comment])) this.strComment = Convert.ToString(drw[C_Comment]);
				if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
				if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
				if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
				if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
				if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_UnionEventRegister", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_UnionEventRegister_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_UnionEventRegister_GET");
				objIData.AddParameter(P_UnionEventRegisterID, this.lngUnionEventRegisterID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_UnionEventRegister", objEx);
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
		/// Store: SIM_UnionEventRegister_GET 
		///</summary>
		/// <returns> SIM_UnionEventRegister </returns>
		public SIM_UnionEventRegister Get(long? lngUnionEventRegisterID)
		{
			SIM_UnionEventRegister obj = new SIM_UnionEventRegister();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.UnionEventRegisterID = lngUnionEventRegisterID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_UnionEventRegister
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_UnionEventRegister", objEx);
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
		/// Search : SIM_UnionEventRegister
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_UnionEventRegister", objEx);
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
		/// Search : SIM_UnionEventRegister
		/// Lấy hết dữ liệu
		/// Store: SIM_UnionEventRegister_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_UnionEventRegister_GETALL");
		}

		///<summary>
		/// Search : SIM_UnionEventRegister
		/// Tìm dữ liệu
		/// Store: SIM_UnionEventRegister_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_UnionEventRegister_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_UnionEventRegister
		/// Thêm dữ liệu
		/// Store: SIM_UnionEventRegister_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_UnionEventRegister_ADD");
				objIData.AddParameter(P_StudentID, this.lngStudentID);
				objIData.AddParameter(P_UnionEventID, this.intUnionEventID);
				objIData.AddParameter(P_RegisterDate, this.dtmRegisterDate);
				objIData.AddParameter(P_IsChecking, this.bolIsChecking);
				objIData.AddParameter(P_Mark, this.intMark);
				objIData.AddParameter(P_Comment, this.strComment);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				this.lngUnionEventRegisterID = Convert.ToInt32(objIData.ExecStoreToString());
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_UnionEventRegister", objEx);
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
		/// Update : SIM_UnionEventRegister
		/// Cập nhật dữ liệu
		/// Store: SIM_UnionEventRegister_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_UnionEventRegister_EDIT");
				objIData.AddParameter(P_UnionEventRegisterID, this.lngUnionEventRegisterID);
				objIData.AddParameter(P_StudentID, this.lngStudentID);
				objIData.AddParameter(P_UnionEventID, this.intUnionEventID);
				objIData.AddParameter(P_RegisterDate, this.dtmRegisterDate);
				objIData.AddParameter(P_IsChecking, this.bolIsChecking);
				objIData.AddParameter(P_Mark, this.intMark);
				objIData.AddParameter(P_Comment, this.strComment);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_UnionEventRegister", objEx);
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
		/// Delete : SIM_UnionEventRegister
		/// Xóa dữ liệu
		/// Store: SIM_UnionEventRegister_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_UnionEventRegister_DELETE");
				objIData.AddParameter(P_UnionEventRegisterID, this.lngUnionEventRegisterID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_UnionEventRegister", objEx);
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
		/// Store: SIM_UnionEventRegister_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(long? lngUnionEventRegisterID)
		{
			this.lngUnionEventRegisterID = lngUnionEventRegisterID;
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

		public SIM_UnionEventRegister()
		{
		}
		public SIM_UnionEventRegister(long? lngUnionEventRegisterID)
		{
			this.lngUnionEventRegisterID = lngUnionEventRegisterID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_UnionEventRegisterID = "@" + C_UnionEventRegisterID;
		public const String P_StudentID = "@" + C_StudentID;
		public const String P_UnionEventID = "@" + C_UnionEventID;
		public const String P_RegisterDate = "@" + C_RegisterDate;
		public const String P_IsChecking = "@" + C_IsChecking;
		public const String P_Mark = "@" + C_Mark;
		public const String P_Comment = "@" + C_Comment;
		public const String P_Description = "@" + C_Description;
		public const String P_CreatedDate = "@" + C_CreatedDate;
		public const String P_CreatedUser = "@" + C_CreatedUser;
		public const String P_UpdatedDate = "@" + C_UpdatedDate;
		public const String P_UpdatedUser = "@" + C_UpdatedUser;

		#endregion //Parameter names

		#region Column Names

		public const String C_UnionEventRegisterID = "UnionEventRegisterID";
		public const String C_StudentID = "StudentID";
		public const String C_UnionEventID = "UnionEventID";
		public const String C_RegisterDate = "RegisterDate";
		public const String C_IsChecking = "IsChecking";
		public const String C_Mark = "Mark";
		public const String C_Comment = "Comment";
		public const String C_Description = "Description";
		public const String C_CreatedDate = "CreatedDate";
		public const String C_CreatedUser = "CreatedUser";
		public const String C_UpdatedDate = "UpdatedDate";
		public const String C_UpdatedUser = "UpdatedUser";

		#endregion //Column names

		#endregion Variable Static		
	}
}
