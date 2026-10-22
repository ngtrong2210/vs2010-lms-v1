
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
	public partial class SIM_UnionEthicSummary
	{	
		#region Member Variables

		private long? lngStudentID = null;//Mã sinh viên
		private int? intYearID = null;//Mã niên học
		private int? intEthicMark1 = null;//Điển rèn luyện cả năm của hội đồng
		private string strEthicLevel1 = null;//Xếp loại rèn luyện cả năm
		private int? intEthicMark2 = null;//Điển rèn luyện cả năm của hội đồng
		private string strEthicLevel2 = null;//Xếp loại rèn luyện cả năm
		private int? intEthicMark = null;//Điển rèn luyện cả năm của hội đồng
		private string strEthicLevel = null;//Xếp loại rèn luyện cả năm
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
		/// StudentID
		/// Mã sinh viên
		/// </summary>
		public long? StudentID
		{
			get { return  lngStudentID; }
			set { lngStudentID = value; }
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
		/// EthicMark1
		/// Điển rèn luyện cả năm của hội đồng
		/// </summary>
		public int? EthicMark1
		{
			get { return  intEthicMark1; }
			set { intEthicMark1 = value; }
		}
		/// <summary>
		/// EthicLevel1
		/// Xếp loại rèn luyện cả năm
		/// </summary>
		public string EthicLevel1
		{
			get { return  strEthicLevel1; }
			set { strEthicLevel1 = value; }
		}
		/// <summary>
		/// EthicMark2
		/// Điển rèn luyện cả năm của hội đồng
		/// </summary>
		public int? EthicMark2
		{
			get { return  intEthicMark2; }
			set { intEthicMark2 = value; }
		}
		/// <summary>
		/// EthicLevel2
		/// Xếp loại rèn luyện cả năm
		/// </summary>
		public string EthicLevel2
		{
			get { return  strEthicLevel2; }
			set { strEthicLevel2 = value; }
		}
		/// <summary>
		/// EthicMark
		/// Điển rèn luyện cả năm của hội đồng
		/// </summary>
		public int? EthicMark
		{
			get { return  intEthicMark; }
			set { intEthicMark = value; }
		}
		/// <summary>
		/// EthicLevel
		/// Xếp loại rèn luyện cả năm
		/// </summary>
		public string EthicLevel
		{
			get { return  strEthicLevel; }
			set { strEthicLevel = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_StudentID.ToUpper()) && !Convert.IsDBNull(reader[C_StudentID])) this.lngStudentID = Convert.ToInt64(reader[C_StudentID]);
					if (reader.GetName(i).ToUpper().Equals(C_YearID.ToUpper()) && !Convert.IsDBNull(reader[C_YearID])) this.intYearID = Convert.ToInt32(reader[C_YearID]);
					if (reader.GetName(i).ToUpper().Equals(C_EthicMark1.ToUpper()) && !Convert.IsDBNull(reader[C_EthicMark1])) this.intEthicMark1 = Convert.ToInt32(reader[C_EthicMark1]);
					if (reader.GetName(i).ToUpper().Equals(C_EthicLevel1.ToUpper()) && !Convert.IsDBNull(reader[C_EthicLevel1])) this.strEthicLevel1 = Convert.ToString(reader[C_EthicLevel1]);
					if (reader.GetName(i).ToUpper().Equals(C_EthicMark2.ToUpper()) && !Convert.IsDBNull(reader[C_EthicMark2])) this.intEthicMark2 = Convert.ToInt32(reader[C_EthicMark2]);
					if (reader.GetName(i).ToUpper().Equals(C_EthicLevel2.ToUpper()) && !Convert.IsDBNull(reader[C_EthicLevel2])) this.strEthicLevel2 = Convert.ToString(reader[C_EthicLevel2]);
					if (reader.GetName(i).ToUpper().Equals(C_EthicMark.ToUpper()) && !Convert.IsDBNull(reader[C_EthicMark])) this.intEthicMark = Convert.ToInt32(reader[C_EthicMark]);
					if (reader.GetName(i).ToUpper().Equals(C_EthicLevel.ToUpper()) && !Convert.IsDBNull(reader[C_EthicLevel])) this.strEthicLevel = Convert.ToString(reader[C_EthicLevel]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(reader[C_UpdatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(reader[C_UpdatedUser]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_UnionEthicSummary", objEx);
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
				if (!Convert.IsDBNull(drw[C_StudentID])) this.lngStudentID = Convert.ToInt64(drw[C_StudentID]);
				if (!Convert.IsDBNull(drw[C_YearID])) this.intYearID = Convert.ToInt32(drw[C_YearID]);
				if (!Convert.IsDBNull(drw[C_EthicMark1])) this.intEthicMark1 = Convert.ToInt32(drw[C_EthicMark1]);
				if (!Convert.IsDBNull(drw[C_EthicLevel1])) this.strEthicLevel1 = Convert.ToString(drw[C_EthicLevel1]);
				if (!Convert.IsDBNull(drw[C_EthicMark2])) this.intEthicMark2 = Convert.ToInt32(drw[C_EthicMark2]);
				if (!Convert.IsDBNull(drw[C_EthicLevel2])) this.strEthicLevel2 = Convert.ToString(drw[C_EthicLevel2]);
				if (!Convert.IsDBNull(drw[C_EthicMark])) this.intEthicMark = Convert.ToInt32(drw[C_EthicMark]);
				if (!Convert.IsDBNull(drw[C_EthicLevel])) this.strEthicLevel = Convert.ToString(drw[C_EthicLevel]);
				if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
				if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
				if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
				if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_UnionEthicSummary", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_UnionEthicSummary_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_UnionEthicSummary_GET");
				objIData.AddParameter(P_StudentID, this.lngStudentID);
				objIData.AddParameter(P_YearID, this.intYearID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_UnionEthicSummary", objEx);
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
		/// Store: SIM_UnionEthicSummary_GET 
		///</summary>
		/// <returns> SIM_UnionEthicSummary </returns>
		public SIM_UnionEthicSummary Get(long? lngStudentID, int? intYearID)
		{
			SIM_UnionEthicSummary obj = new SIM_UnionEthicSummary();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.StudentID = lngStudentID;
			obj.YearID = intYearID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_UnionEthicSummary
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_UnionEthicSummary", objEx);
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
		/// Search : SIM_UnionEthicSummary
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_UnionEthicSummary", objEx);
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
		/// Search : SIM_UnionEthicSummary
		/// Lấy hết dữ liệu
		/// Store: SIM_UnionEthicSummary_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_UnionEthicSummary_GETALL");
		}

		///<summary>
		/// Search : SIM_UnionEthicSummary
		/// Tìm dữ liệu
		/// Store: SIM_UnionEthicSummary_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_UnionEthicSummary_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_UnionEthicSummary
		/// Thêm dữ liệu
		/// Store: SIM_UnionEthicSummary_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_UnionEthicSummary_ADD");
				objIData.AddParameter(P_StudentID, this.lngStudentID);
				objIData.AddParameter(P_YearID, this.intYearID);
				objIData.AddParameter(P_EthicMark1, this.intEthicMark1);
				objIData.AddParameter(P_EthicLevel1, this.strEthicLevel1);
				objIData.AddParameter(P_EthicMark2, this.intEthicMark2);
				objIData.AddParameter(P_EthicLevel2, this.strEthicLevel2);
				objIData.AddParameter(P_EthicMark, this.intEthicMark);
				objIData.AddParameter(P_EthicLevel, this.strEthicLevel);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_UnionEthicSummary", objEx);
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
		/// Update : SIM_UnionEthicSummary
		/// Cập nhật dữ liệu
		/// Store: SIM_UnionEthicSummary_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_UnionEthicSummary_EDIT");
				objIData.AddParameter(P_StudentID, this.lngStudentID);
				objIData.AddParameter(P_YearID, this.intYearID);
				objIData.AddParameter(P_EthicMark1, this.intEthicMark1);
				objIData.AddParameter(P_EthicLevel1, this.strEthicLevel1);
				objIData.AddParameter(P_EthicMark2, this.intEthicMark2);
				objIData.AddParameter(P_EthicLevel2, this.strEthicLevel2);
				objIData.AddParameter(P_EthicMark, this.intEthicMark);
				objIData.AddParameter(P_EthicLevel, this.strEthicLevel);
				objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_UnionEthicSummary", objEx);
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
		/// Delete : SIM_UnionEthicSummary
		/// Xóa dữ liệu
		/// Store: SIM_UnionEthicSummary_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_UnionEthicSummary_DELETE");
				objIData.AddParameter(P_StudentID, this.lngStudentID);
				objIData.AddParameter(P_YearID, this.intYearID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_UnionEthicSummary", objEx);
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
		/// Store: SIM_UnionEthicSummary_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(long? lngStudentID, int? intYearID)
		{
			this.lngStudentID = lngStudentID;
			this.intYearID = intYearID;
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

		public SIM_UnionEthicSummary()
		{
		}
		public SIM_UnionEthicSummary(long? lngStudentID, int? intYearID)
		{
			this.lngStudentID = lngStudentID;
			this.intYearID = intYearID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_StudentID = "@" + C_StudentID;
		public const String P_YearID = "@" + C_YearID;
		public const String P_EthicMark1 = "@" + C_EthicMark1;
		public const String P_EthicLevel1 = "@" + C_EthicLevel1;
		public const String P_EthicMark2 = "@" + C_EthicMark2;
		public const String P_EthicLevel2 = "@" + C_EthicLevel2;
		public const String P_EthicMark = "@" + C_EthicMark;
		public const String P_EthicLevel = "@" + C_EthicLevel;
		public const String P_CreatedDate = "@" + C_CreatedDate;
		public const String P_CreatedUser = "@" + C_CreatedUser;
		public const String P_UpdatedDate = "@" + C_UpdatedDate;
		public const String P_UpdatedUser = "@" + C_UpdatedUser;

		#endregion //Parameter names

		#region Column Names

		public const String C_StudentID = "StudentID";
		public const String C_YearID = "YearID";
		public const String C_EthicMark1 = "EthicMark1";
		public const String C_EthicLevel1 = "EthicLevel1";
		public const String C_EthicMark2 = "EthicMark2";
		public const String C_EthicLevel2 = "EthicLevel2";
		public const String C_EthicMark = "EthicMark";
		public const String C_EthicLevel = "EthicLevel";
		public const String C_CreatedDate = "CreatedDate";
		public const String C_CreatedUser = "CreatedUser";
		public const String C_UpdatedDate = "UpdatedDate";
		public const String C_UpdatedUser = "UpdatedUser";

		#endregion //Column names

		#endregion Variable Static		
	}
}
