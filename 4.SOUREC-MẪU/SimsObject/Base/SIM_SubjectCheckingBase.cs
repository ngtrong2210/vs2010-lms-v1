
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
	public partial class SIM_SubjectChecking
	{	
		#region Member Variables

		private long? lngSubjectCheckingID = null;//Mã tự tăng
		private long? lngStudentID = null;//Mã sinh viên
		private long? lngClassSubjectID = null;//Mã môn học lớp (lớp gốc)
		private DateTime? dtmDate = null;//Ngày học
		private int? intSession = null;//Buổi học (0. Sáng, 1. Chiều, 2. Tối)
		private decimal? decPermissionQuantity = null;//Số tiết nghỉ có phép
		private decimal? decNoPermissionQuantity = null;//Số tiết nghỉ không phép
		private string strDescription = null;//Mô tả
		private DateTime? dtmCreatedDate = null;//Ngày tạo
		private string strCreatedUser = null;//Người tạo
		private DateTime? dtmUpdatedDate = null;//Ngày cập nhật cuối
		private string strUpdatedUser = null;//Người cập nhật cuối
		private bool bolIsPractice = false;//Là điểm danh cho tiết thực hành
		private IData objIData = null;
		private bool bolIsExistIData = false;
		private Exception objErrorException = null;

		#endregion

		#region Properties 

		/// <summary>
		/// SubjectCheckingID
		/// Mã tự tăng
		/// </summary>
		public long? SubjectCheckingID
		{
			get { return  lngSubjectCheckingID; }
			set { lngSubjectCheckingID = value; }
		}
		/// <summary>
		/// StudentID
		/// Mã sinh viên
		/// </summary>
		public long? StudentID
		{
			get { return  lngStudentID; }
			set { lngStudentID = value; }
		}
		/// <summary>
		/// ClassSubjectID
		/// Mã môn học lớp (lớp gốc)
		/// </summary>
		public long? ClassSubjectID
		{
			get { return  lngClassSubjectID; }
			set { lngClassSubjectID = value; }
		}
		/// <summary>
		/// Date
		/// Ngày học
		/// </summary>
		public DateTime? Date
		{
			get { return  dtmDate; }
			set { dtmDate = value; }
		}
		/// <summary>
		/// Session
		/// Buổi học (0. Sáng, 1. Chiều, 2. Tối)
		/// </summary>
		public int? Session
		{
			get { return  intSession; }
			set { intSession = value; }
		}
		/// <summary>
		/// PermissionQuantity
		/// Số tiết nghỉ có phép
		/// </summary>
		public decimal? PermissionQuantity
		{
			get { return  decPermissionQuantity; }
			set { decPermissionQuantity = value; }
		}
		/// <summary>
		/// NoPermissionQuantity
		/// Số tiết nghỉ không phép
		/// </summary>
		public decimal? NoPermissionQuantity
		{
			get { return  decNoPermissionQuantity; }
			set { decNoPermissionQuantity = value; }
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
		/// IsPractice
		/// Là điểm danh cho tiết thực hành
		/// </summary>
		public bool IsPractice
		{
			get { return  bolIsPractice; }
			set { bolIsPractice = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_SubjectCheckingID.ToUpper()) && !Convert.IsDBNull(reader[C_SubjectCheckingID])) this.lngSubjectCheckingID = Convert.ToInt64(reader[C_SubjectCheckingID]);
					if (reader.GetName(i).ToUpper().Equals(C_StudentID.ToUpper()) && !Convert.IsDBNull(reader[C_StudentID])) this.lngStudentID = Convert.ToInt64(reader[C_StudentID]);
					if (reader.GetName(i).ToUpper().Equals(C_ClassSubjectID.ToUpper()) && !Convert.IsDBNull(reader[C_ClassSubjectID])) this.lngClassSubjectID = Convert.ToInt64(reader[C_ClassSubjectID]);
					if (reader.GetName(i).ToUpper().Equals(C_Date.ToUpper()) && !Convert.IsDBNull(reader[C_Date])) this.dtmDate = Convert.ToDateTime(reader[C_Date]);
					if (reader.GetName(i).ToUpper().Equals(C_Session.ToUpper()) && !Convert.IsDBNull(reader[C_Session])) this.intSession = Convert.ToInt32(reader[C_Session]);
					if (reader.GetName(i).ToUpper().Equals(C_PermissionQuantity.ToUpper()) && !Convert.IsDBNull(reader[C_PermissionQuantity])) this.decPermissionQuantity = Convert.ToDecimal(reader[C_PermissionQuantity]);
					if (reader.GetName(i).ToUpper().Equals(C_NoPermissionQuantity.ToUpper()) && !Convert.IsDBNull(reader[C_NoPermissionQuantity])) this.decNoPermissionQuantity = Convert.ToDecimal(reader[C_NoPermissionQuantity]);
					if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(reader[C_UpdatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(reader[C_UpdatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_IsPractice.ToUpper()) && !Convert.IsDBNull(reader[C_IsPractice])) this.bolIsPractice = Convert.ToBoolean(reader[C_IsPractice]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_SubjectChecking", objEx);
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
				if (!Convert.IsDBNull(drw[C_SubjectCheckingID])) this.lngSubjectCheckingID = Convert.ToInt64(drw[C_SubjectCheckingID]);
				if (!Convert.IsDBNull(drw[C_StudentID])) this.lngStudentID = Convert.ToInt64(drw[C_StudentID]);
				if (!Convert.IsDBNull(drw[C_ClassSubjectID])) this.lngClassSubjectID = Convert.ToInt64(drw[C_ClassSubjectID]);
				if (!Convert.IsDBNull(drw[C_Date])) this.dtmDate = Convert.ToDateTime(drw[C_Date]);
				if (!Convert.IsDBNull(drw[C_Session])) this.intSession = Convert.ToInt32(drw[C_Session]);
				if (!Convert.IsDBNull(drw[C_PermissionQuantity])) this.decPermissionQuantity = Convert.ToDecimal(drw[C_PermissionQuantity]);
				if (!Convert.IsDBNull(drw[C_NoPermissionQuantity])) this.decNoPermissionQuantity = Convert.ToDecimal(drw[C_NoPermissionQuantity]);
				if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
				if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
				if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
				if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
				if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
				if (!Convert.IsDBNull(drw[C_IsPractice])) this.bolIsPractice = Convert.ToBoolean(drw[C_IsPractice]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_SubjectChecking", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_SubjectChecking_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_SubjectChecking_GET");
				objIData.AddParameter(P_SubjectCheckingID, this.lngSubjectCheckingID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_SubjectChecking", objEx);
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
		/// Store: SIM_SubjectChecking_GET 
		///</summary>
		/// <returns> SIM_SubjectChecking </returns>
		public SIM_SubjectChecking Get(long? lngSubjectCheckingID)
		{
			SIM_SubjectChecking obj = new SIM_SubjectChecking();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.SubjectCheckingID = lngSubjectCheckingID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_SubjectChecking
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_SubjectChecking", objEx);
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
		/// Search : SIM_SubjectChecking
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_SubjectChecking", objEx);
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
		/// Search : SIM_SubjectChecking
		/// Lấy hết dữ liệu
		/// Store: SIM_SubjectChecking_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_SubjectChecking_GETALL");
		}

		///<summary>
		/// Search : SIM_SubjectChecking
		/// Tìm dữ liệu
		/// Store: SIM_SubjectChecking_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_SubjectChecking_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_SubjectChecking
		/// Thêm dữ liệu
		/// Store: SIM_SubjectChecking_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_SubjectChecking_ADD");
				objIData.AddParameter(P_StudentID, this.lngStudentID);
				objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
				objIData.AddParameter(P_Date, this.dtmDate);
				objIData.AddParameter(P_Session, this.intSession);
				objIData.AddParameter(P_PermissionQuantity, this.decPermissionQuantity);
				objIData.AddParameter(P_NoPermissionQuantity, this.decNoPermissionQuantity);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				objIData.AddParameter(P_IsPractice, this.bolIsPractice);
				this.lngSubjectCheckingID = Convert.ToInt32(objIData.ExecStoreToString());
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_SubjectChecking", objEx);
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
		/// Update : SIM_SubjectChecking
		/// Cập nhật dữ liệu
		/// Store: SIM_SubjectChecking_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_SubjectChecking_EDIT");
				objIData.AddParameter(P_SubjectCheckingID, this.lngSubjectCheckingID);
				objIData.AddParameter(P_StudentID, this.lngStudentID);
				objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
				objIData.AddParameter(P_Date, this.dtmDate);
				objIData.AddParameter(P_Session, this.intSession);
				objIData.AddParameter(P_PermissionQuantity, this.decPermissionQuantity);
				objIData.AddParameter(P_NoPermissionQuantity, this.decNoPermissionQuantity);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
				objIData.AddParameter(P_IsPractice, this.bolIsPractice);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_SubjectChecking", objEx);
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
		/// Delete : SIM_SubjectChecking
		/// Xóa dữ liệu
		/// Store: SIM_SubjectChecking_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_SubjectChecking_DELETE");
				objIData.AddParameter(P_SubjectCheckingID, this.lngSubjectCheckingID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_SubjectChecking", objEx);
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
		/// Store: SIM_SubjectChecking_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(long? lngSubjectCheckingID)
		{
			this.lngSubjectCheckingID = lngSubjectCheckingID;
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

		public SIM_SubjectChecking()
		{
		}
		public SIM_SubjectChecking(long? lngSubjectCheckingID)
		{
			this.lngSubjectCheckingID = lngSubjectCheckingID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_SubjectCheckingID = "@" + C_SubjectCheckingID;
		public const String P_StudentID = "@" + C_StudentID;
		public const String P_ClassSubjectID = "@" + C_ClassSubjectID;
		public const String P_Date = "@" + C_Date;
		public const String P_Session = "@" + C_Session;
		public const String P_PermissionQuantity = "@" + C_PermissionQuantity;
		public const String P_NoPermissionQuantity = "@" + C_NoPermissionQuantity;
		public const String P_Description = "@" + C_Description;
		public const String P_CreatedDate = "@" + C_CreatedDate;
		public const String P_CreatedUser = "@" + C_CreatedUser;
		public const String P_UpdatedDate = "@" + C_UpdatedDate;
		public const String P_UpdatedUser = "@" + C_UpdatedUser;
		public const String P_IsPractice = "@" + C_IsPractice;

		#endregion //Parameter names

		#region Column Names

		public const String C_SubjectCheckingID = "SubjectCheckingID";
		public const String C_StudentID = "StudentID";
		public const String C_ClassSubjectID = "ClassSubjectID";
		public const String C_Date = "Date";
		public const String C_Session = "Session";
		public const String C_PermissionQuantity = "PermissionQuantity";
		public const String C_NoPermissionQuantity = "NoPermissionQuantity";
		public const String C_Description = "Description";
		public const String C_CreatedDate = "CreatedDate";
		public const String C_CreatedUser = "CreatedUser";
		public const String C_UpdatedDate = "UpdatedDate";
		public const String C_UpdatedUser = "UpdatedUser";
		public const String C_IsPractice = "IsPractice";

		#endregion //Column names

		#endregion Variable Static		
	}
}
