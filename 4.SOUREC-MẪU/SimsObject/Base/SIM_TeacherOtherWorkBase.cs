
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
	public partial class SIM_TeacherOtherWork
	{	
		#region Member Variables

		private int? intTeacherOtherWorkID = null;//Mã niên học
		private int? intYearID = null;//Mã niên học
		private int? intSemester = null;
		private string strTeacherID = null;//Mã giảng viên, Nếu = ___ (3 dấu gạch chân)  là dòng giá trị cấu hình cho năm đó, nếu hông có thì tự load năm cũ add vào
		private int? intOtherWordID = null;
		private decimal? decRatio = null;//Hệ số chức vụ
		private decimal? decQuantity = null;
		private string strCreatedUser = null;
		private DateTime? dtmCreatedDate = null;//Ngày tạo
		private string strUpdatedUser = null;//Người sửa
		private DateTime? dtmUpdatedDate = null;//Ngày sửa
		private IData objIData = null;
		private bool bolIsExistIData = false;
		private Exception objErrorException = null;

		#endregion

		#region Properties 

		/// <summary>
		/// TeacherOtherWorkID
		/// Mã niên học
		/// </summary>
		public int? TeacherOtherWorkID
		{
			get { return  intTeacherOtherWorkID; }
			set { intTeacherOtherWorkID = value; }
		}
		/// <summary>
		/// YearID
		/// Mã niên học
		/// </summary>
		public int? YearID
		{
			get { return  intYearID; }
			set { intYearID = value; }
		}
		/// <summary>
		/// Semester
		/// 
		/// </summary>
		public int? Semester
		{
			get { return  intSemester; }
			set { intSemester = value; }
		}
		/// <summary>
		/// TeacherID
		/// Mã giảng viên, Nếu = ___ (3 dấu gạch chân)  là dòng giá trị cấu hình cho năm đó, nếu hông có thì tự load năm cũ add vào
		/// </summary>
		public string TeacherID
		{
			get { return  strTeacherID; }
			set { strTeacherID = value; }
		}
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
		/// Ratio
		/// Hệ số chức vụ
		/// </summary>
		public decimal? Ratio
		{
			get { return  decRatio; }
			set { decRatio = value; }
		}
		/// <summary>
		/// Quantity
		/// 
		/// </summary>
		public decimal? Quantity
		{
			get { return  decQuantity; }
			set { decQuantity = value; }
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
		/// UpdatedUser
		/// Người sửa
		/// </summary>
		public string UpdatedUser
		{
			get { return  strUpdatedUser; }
			set { strUpdatedUser = value; }
		}
		/// <summary>
		/// UpdatedDate
		/// Ngày sửa
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
					if (reader.GetName(i).ToUpper().Equals(C_TeacherOtherWorkID.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherOtherWorkID])) this.intTeacherOtherWorkID = Convert.ToInt32(reader[C_TeacherOtherWorkID]);
					if (reader.GetName(i).ToUpper().Equals(C_YearID.ToUpper()) && !Convert.IsDBNull(reader[C_YearID])) this.intYearID = Convert.ToInt32(reader[C_YearID]);
					if (reader.GetName(i).ToUpper().Equals(C_Semester.ToUpper()) && !Convert.IsDBNull(reader[C_Semester])) this.intSemester = Convert.ToInt32(reader[C_Semester]);
					if (reader.GetName(i).ToUpper().Equals(C_TeacherID.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherID])) this.strTeacherID = Convert.ToString(reader[C_TeacherID]);
					if (reader.GetName(i).ToUpper().Equals(C_OtherWordID.ToUpper()) && !Convert.IsDBNull(reader[C_OtherWordID])) this.intOtherWordID = Convert.ToInt32(reader[C_OtherWordID]);
					if (reader.GetName(i).ToUpper().Equals(C_Ratio.ToUpper()) && !Convert.IsDBNull(reader[C_Ratio])) this.decRatio = Convert.ToDecimal(reader[C_Ratio]);
					if (reader.GetName(i).ToUpper().Equals(C_Quantity.ToUpper()) && !Convert.IsDBNull(reader[C_Quantity])) this.decQuantity = Convert.ToDecimal(reader[C_Quantity]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(reader[C_UpdatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(reader[C_UpdatedDate]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_TeacherOtherWork", objEx);
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
				if (!Convert.IsDBNull(drw[C_TeacherOtherWorkID])) this.intTeacherOtherWorkID = Convert.ToInt32(drw[C_TeacherOtherWorkID]);
				if (!Convert.IsDBNull(drw[C_YearID])) this.intYearID = Convert.ToInt32(drw[C_YearID]);
				if (!Convert.IsDBNull(drw[C_Semester])) this.intSemester = Convert.ToInt32(drw[C_Semester]);
				if (!Convert.IsDBNull(drw[C_TeacherID])) this.strTeacherID = Convert.ToString(drw[C_TeacherID]);
				if (!Convert.IsDBNull(drw[C_OtherWordID])) this.intOtherWordID = Convert.ToInt32(drw[C_OtherWordID]);
				if (!Convert.IsDBNull(drw[C_Ratio])) this.decRatio = Convert.ToDecimal(drw[C_Ratio]);
				if (!Convert.IsDBNull(drw[C_Quantity])) this.decQuantity = Convert.ToDecimal(drw[C_Quantity]);
				if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
				if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
				if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
				if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_TeacherOtherWork", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_TeacherOtherWork_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_TeacherOtherWork_GET");
				objIData.AddParameter(P_TeacherOtherWorkID, this.intTeacherOtherWorkID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_TeacherOtherWork", objEx);
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
		/// Store: SIM_TeacherOtherWork_GET 
		///</summary>
		/// <returns> SIM_TeacherOtherWork </returns>
		public SIM_TeacherOtherWork Get(int? intTeacherOtherWorkID)
		{
			SIM_TeacherOtherWork obj = new SIM_TeacherOtherWork();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.TeacherOtherWorkID = intTeacherOtherWorkID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_TeacherOtherWork
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_TeacherOtherWork", objEx);
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
		/// Search : SIM_TeacherOtherWork
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_TeacherOtherWork", objEx);
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
		/// Search : SIM_TeacherOtherWork
		/// Lấy hết dữ liệu
		/// Store: SIM_TeacherOtherWork_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_TeacherOtherWork_GETALL");
		}

		///<summary>
		/// Search : SIM_TeacherOtherWork
		/// Tìm dữ liệu
		/// Store: SIM_TeacherOtherWork_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_TeacherOtherWork_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_TeacherOtherWork
		/// Thêm dữ liệu
		/// Store: SIM_TeacherOtherWork_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_TeacherOtherWork_ADD");
				objIData.AddParameter(P_YearID, this.intYearID);
				objIData.AddParameter(P_Semester, this.intSemester);
				objIData.AddParameter(P_TeacherID, this.strTeacherID);
				objIData.AddParameter(P_OtherWordID, this.intOtherWordID);
				objIData.AddParameter(P_Ratio, this.decRatio);
				objIData.AddParameter(P_Quantity, this.decQuantity);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				this.intTeacherOtherWorkID = Convert.ToInt32(objIData.ExecStoreToString());
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_TeacherOtherWork", objEx);
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
		/// Update : SIM_TeacherOtherWork
		/// Cập nhật dữ liệu
		/// Store: SIM_TeacherOtherWork_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_TeacherOtherWork_EDIT");
				objIData.AddParameter(P_TeacherOtherWorkID, this.intTeacherOtherWorkID);
				objIData.AddParameter(P_YearID, this.intYearID);
				objIData.AddParameter(P_Semester, this.intSemester);
				objIData.AddParameter(P_TeacherID, this.strTeacherID);
				objIData.AddParameter(P_OtherWordID, this.intOtherWordID);
				objIData.AddParameter(P_Ratio, this.decRatio);
				objIData.AddParameter(P_Quantity, this.decQuantity);
				objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_TeacherOtherWork", objEx);
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
		/// Delete : SIM_TeacherOtherWork
		/// Xóa dữ liệu
		/// Store: SIM_TeacherOtherWork_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_TeacherOtherWork_DELETE");
				objIData.AddParameter(P_TeacherOtherWorkID, this.intTeacherOtherWorkID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_TeacherOtherWork", objEx);
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
		/// Store: SIM_TeacherOtherWork_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(int? intTeacherOtherWorkID)
		{
			this.intTeacherOtherWorkID = intTeacherOtherWorkID;
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

		public SIM_TeacherOtherWork()
		{
		}
		public SIM_TeacherOtherWork(int? intTeacherOtherWorkID)
		{
			this.intTeacherOtherWorkID = intTeacherOtherWorkID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_TeacherOtherWorkID = "@" + C_TeacherOtherWorkID;
		public const String P_YearID = "@" + C_YearID;
		public const String P_Semester = "@" + C_Semester;
		public const String P_TeacherID = "@" + C_TeacherID;
		public const String P_OtherWordID = "@" + C_OtherWordID;
		public const String P_Ratio = "@" + C_Ratio;
		public const String P_Quantity = "@" + C_Quantity;
		public const String P_CreatedUser = "@" + C_CreatedUser;
		public const String P_CreatedDate = "@" + C_CreatedDate;
		public const String P_UpdatedUser = "@" + C_UpdatedUser;
		public const String P_UpdatedDate = "@" + C_UpdatedDate;

		#endregion //Parameter names

		#region Column Names

		public const String C_TeacherOtherWorkID = "TeacherOtherWorkID";
		public const String C_YearID = "YearID";
		public const String C_Semester = "Semester";
		public const String C_TeacherID = "TeacherID";
		public const String C_OtherWordID = "OtherWordID";
		public const String C_Ratio = "Ratio";
		public const String C_Quantity = "Quantity";
		public const String C_CreatedUser = "CreatedUser";
		public const String C_CreatedDate = "CreatedDate";
		public const String C_UpdatedUser = "UpdatedUser";
		public const String C_UpdatedDate = "UpdatedDate";

		#endregion //Column names

		#endregion Variable Static		
	}
}
