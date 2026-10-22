
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
	public partial class SIM_WeekDetailPlan
	{	
		#region Member Variables

		private int? intWeek = null;//Tuần thứ mấy của niên học
		private long? lngClassSubjectID = null;//Môn học lớp nào
		private bool bolIsPractice = false;//Là thực hành
		private int? intQuantity = null;//Số lượng tiết dạy
		private string strCreatedBy = null;
		private DateTime? dtmCreatedAt = null;//Ngày tạo
		private string strModifiedBy = null;//Người sửa
		private DateTime? dtmModifiedAt = null;//Ngày sửa
		private int? intYearID = null;//Mã niên học, mon hoc o nhiu năm
		private IData objIData = null;
		private bool bolIsExistIData = false;
		private Exception objErrorException = null;

		#endregion

		#region Properties 

		/// <summary>
		/// Week
		/// Tuần thứ mấy của niên học
		/// </summary>
		public int? Week
		{
			get { return  intWeek; }
			set { intWeek = value; }
		}
		/// <summary>
		/// ClassSubjectID
		/// Môn học lớp nào
		/// </summary>
		public long? ClassSubjectID
		{
			get { return  lngClassSubjectID; }
			set { lngClassSubjectID = value; }
		}
		/// <summary>
		/// IsPractice
		/// Là thực hành
		/// </summary>
		public bool IsPractice
		{
			get { return  bolIsPractice; }
			set { bolIsPractice = value; }
		}
		/// <summary>
		/// Quantity
		/// Số lượng tiết dạy
		/// </summary>
		public int? Quantity
		{
			get { return  intQuantity; }
			set { intQuantity = value; }
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
		/// YearID
		/// Mã niên học, mon hoc o nhiu năm
		/// </summary>
		public int? YearID
		{
			get { return  intYearID; }
			set { intYearID = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_Week.ToUpper()) && !Convert.IsDBNull(reader[C_Week])) this.intWeek = Convert.ToInt32(reader[C_Week]);
					if (reader.GetName(i).ToUpper().Equals(C_ClassSubjectID.ToUpper()) && !Convert.IsDBNull(reader[C_ClassSubjectID])) this.lngClassSubjectID = Convert.ToInt64(reader[C_ClassSubjectID]);
					if (reader.GetName(i).ToUpper().Equals(C_IsPractice.ToUpper()) && !Convert.IsDBNull(reader[C_IsPractice])) this.bolIsPractice = Convert.ToBoolean(reader[C_IsPractice]);
					if (reader.GetName(i).ToUpper().Equals(C_Quantity.ToUpper()) && !Convert.IsDBNull(reader[C_Quantity])) this.intQuantity = Convert.ToInt32(reader[C_Quantity]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedBy.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedBy])) this.strCreatedBy = Convert.ToString(reader[C_CreatedBy]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(reader[C_CreatedAt]);
					if (reader.GetName(i).ToUpper().Equals(C_ModifiedBy.ToUpper()) && !Convert.IsDBNull(reader[C_ModifiedBy])) this.strModifiedBy = Convert.ToString(reader[C_ModifiedBy]);
					if (reader.GetName(i).ToUpper().Equals(C_ModifiedAt.ToUpper()) && !Convert.IsDBNull(reader[C_ModifiedAt])) this.dtmModifiedAt = Convert.ToDateTime(reader[C_ModifiedAt]);
					if (reader.GetName(i).ToUpper().Equals(C_YearID.ToUpper()) && !Convert.IsDBNull(reader[C_YearID])) this.intYearID = Convert.ToInt32(reader[C_YearID]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_WeekDetailPlan", objEx);
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
				if (!Convert.IsDBNull(drw[C_Week])) this.intWeek = Convert.ToInt32(drw[C_Week]);
				if (!Convert.IsDBNull(drw[C_ClassSubjectID])) this.lngClassSubjectID = Convert.ToInt64(drw[C_ClassSubjectID]);
				if (!Convert.IsDBNull(drw[C_IsPractice])) this.bolIsPractice = Convert.ToBoolean(drw[C_IsPractice]);
				if (!Convert.IsDBNull(drw[C_Quantity])) this.intQuantity = Convert.ToInt32(drw[C_Quantity]);
				if (!Convert.IsDBNull(drw[C_CreatedBy])) this.strCreatedBy = Convert.ToString(drw[C_CreatedBy]);
				if (!Convert.IsDBNull(drw[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(drw[C_CreatedAt]);
				if (!Convert.IsDBNull(drw[C_ModifiedBy])) this.strModifiedBy = Convert.ToString(drw[C_ModifiedBy]);
				if (!Convert.IsDBNull(drw[C_ModifiedAt])) this.dtmModifiedAt = Convert.ToDateTime(drw[C_ModifiedAt]);
				if (!Convert.IsDBNull(drw[C_YearID])) this.intYearID = Convert.ToInt32(drw[C_YearID]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_WeekDetailPlan", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_WeekDetailPlan_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_WeekDetailPlan_GET");
				objIData.AddParameter(P_Week, this.intWeek);
				objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
				objIData.AddParameter(P_IsPractice, this.bolIsPractice);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_WeekDetailPlan", objEx);
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
		/// Store: SIM_WeekDetailPlan_GET 
		///</summary>
		/// <returns> SIM_WeekDetailPlan </returns>
		public SIM_WeekDetailPlan Get(int? intWeek, long? lngClassSubjectID, bool bolIsPractice)
		{
			SIM_WeekDetailPlan obj = new SIM_WeekDetailPlan();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.Week = intWeek;
			obj.ClassSubjectID = lngClassSubjectID;
			obj.IsPractice = bolIsPractice;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_WeekDetailPlan
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_WeekDetailPlan", objEx);
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
		/// Search : SIM_WeekDetailPlan
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_WeekDetailPlan", objEx);
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
		/// Search : SIM_WeekDetailPlan
		/// Lấy hết dữ liệu
		/// Store: SIM_WeekDetailPlan_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_WeekDetailPlan_GETALL");
		}

		///<summary>
		/// Search : SIM_WeekDetailPlan
		/// Tìm dữ liệu
		/// Store: SIM_WeekDetailPlan_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_WeekDetailPlan_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_WeekDetailPlan
		/// Thêm dữ liệu
		/// Store: SIM_WeekDetailPlan_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_WeekDetailPlan_ADD");
				objIData.AddParameter(P_Week, this.intWeek);
				objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
				objIData.AddParameter(P_IsPractice, this.bolIsPractice);
				objIData.AddParameter(P_Quantity, this.intQuantity);
				objIData.AddParameter(P_CreatedBy, this.strCreatedBy);
				objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
				objIData.AddParameter(P_ModifiedBy, this.strModifiedBy);
				objIData.AddParameter(P_ModifiedAt, this.dtmModifiedAt);
				objIData.AddParameter(P_YearID, this.intYearID);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_WeekDetailPlan", objEx);
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
		/// Update : SIM_WeekDetailPlan
		/// Cập nhật dữ liệu
		/// Store: SIM_WeekDetailPlan_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_WeekDetailPlan_EDIT");
				objIData.AddParameter(P_Week, this.intWeek);
				objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
				objIData.AddParameter(P_IsPractice, this.bolIsPractice);
				objIData.AddParameter(P_Quantity, this.intQuantity);
				objIData.AddParameter(P_CreatedBy, this.strCreatedBy);
				objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
				objIData.AddParameter(P_ModifiedBy, this.strModifiedBy);
				objIData.AddParameter(P_ModifiedAt, this.dtmModifiedAt);
				objIData.AddParameter(P_YearID, this.intYearID);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_WeekDetailPlan", objEx);
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
		/// Delete : SIM_WeekDetailPlan
		/// Xóa dữ liệu
		/// Store: SIM_WeekDetailPlan_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_WeekDetailPlan_DELETE");
				objIData.AddParameter(P_Week, this.intWeek);
				objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
				objIData.AddParameter(P_IsPractice, this.bolIsPractice);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_WeekDetailPlan", objEx);
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
		/// Store: SIM_WeekDetailPlan_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(int? intWeek, long? lngClassSubjectID, bool bolIsPractice)
		{
			this.intWeek = intWeek;
			this.lngClassSubjectID = lngClassSubjectID;
			this.bolIsPractice = bolIsPractice;
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

		public SIM_WeekDetailPlan()
		{
		}
		public SIM_WeekDetailPlan(int? intWeek, long? lngClassSubjectID, bool bolIsPractice)
		{
			this.intWeek = intWeek;
			this.lngClassSubjectID = lngClassSubjectID;
			this.bolIsPractice = bolIsPractice;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_Week = "@" + C_Week;
		public const String P_ClassSubjectID = "@" + C_ClassSubjectID;
		public const String P_IsPractice = "@" + C_IsPractice;
		public const String P_Quantity = "@" + C_Quantity;
		public const String P_CreatedBy = "@" + C_CreatedBy;
		public const String P_CreatedAt = "@" + C_CreatedAt;
		public const String P_ModifiedBy = "@" + C_ModifiedBy;
		public const String P_ModifiedAt = "@" + C_ModifiedAt;
		public const String P_YearID = "@" + C_YearID;

		#endregion //Parameter names

		#region Column Names

		public const String C_Week = "Week";
		public const String C_ClassSubjectID = "ClassSubjectID";
		public const String C_IsPractice = "IsPractice";
		public const String C_Quantity = "Quantity";
		public const String C_CreatedBy = "CreatedBy";
		public const String C_CreatedAt = "CreatedAt";
		public const String C_ModifiedBy = "ModifiedBy";
		public const String C_ModifiedAt = "ModifiedAt";
		public const String C_YearID = "YearID";

		#endregion //Column names

		#endregion Variable Static		
	}
}
