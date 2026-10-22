
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
	public partial class SIM_ReferenceClass
	{	
		#region Member Variables

		private int? intYearID = null;
		private int? intSemester = null;
		private string strClassID = null;
		private string strReferenceClassID = null;
		private int? intGroupSmallClass = null;
		private IData objIData = null;
		private bool bolIsExistIData = false;
		private Exception objErrorException = null;

		#endregion

		#region Properties 

		/// <summary>
		/// YearID
		/// 
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
		/// ClassID
		/// 
		/// </summary>
		public string ClassID
		{
			get { return  strClassID; }
			set { strClassID = value; }
		}
		/// <summary>
		/// ReferenceClassID
		/// 
		/// </summary>
		public string ReferenceClassID
		{
			get { return  strReferenceClassID; }
			set { strReferenceClassID = value; }
		}
		/// <summary>
		/// GroupSmallClass
		/// 
		/// </summary>
		public int? GroupSmallClass
		{
			get { return  intGroupSmallClass; }
			set { intGroupSmallClass = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_YearID.ToUpper()) && !Convert.IsDBNull(reader[C_YearID])) this.intYearID = Convert.ToInt32(reader[C_YearID]);
					if (reader.GetName(i).ToUpper().Equals(C_Semester.ToUpper()) && !Convert.IsDBNull(reader[C_Semester])) this.intSemester = Convert.ToInt32(reader[C_Semester]);
					if (reader.GetName(i).ToUpper().Equals(C_ClassID.ToUpper()) && !Convert.IsDBNull(reader[C_ClassID])) this.strClassID = Convert.ToString(reader[C_ClassID]);
					if (reader.GetName(i).ToUpper().Equals(C_ReferenceClassID.ToUpper()) && !Convert.IsDBNull(reader[C_ReferenceClassID])) this.strReferenceClassID = Convert.ToString(reader[C_ReferenceClassID]);
					if (reader.GetName(i).ToUpper().Equals(C_GroupSmallClass.ToUpper()) && !Convert.IsDBNull(reader[C_GroupSmallClass])) this.intGroupSmallClass = Convert.ToInt32(reader[C_GroupSmallClass]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_ReferenceClass", objEx);
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
				if (!Convert.IsDBNull(drw[C_YearID])) this.intYearID = Convert.ToInt32(drw[C_YearID]);
				if (!Convert.IsDBNull(drw[C_Semester])) this.intSemester = Convert.ToInt32(drw[C_Semester]);
				if (!Convert.IsDBNull(drw[C_ClassID])) this.strClassID = Convert.ToString(drw[C_ClassID]);
				if (!Convert.IsDBNull(drw[C_ReferenceClassID])) this.strReferenceClassID = Convert.ToString(drw[C_ReferenceClassID]);
				if (!Convert.IsDBNull(drw[C_GroupSmallClass])) this.intGroupSmallClass = Convert.ToInt32(drw[C_GroupSmallClass]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_ReferenceClass", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_ReferenceClass_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ReferenceClass_GET");
				objIData.AddParameter(P_YearID, this.intYearID);
				objIData.AddParameter(P_Semester, this.intSemester);
				objIData.AddParameter(P_ClassID, this.strClassID);
				objIData.AddParameter(P_ReferenceClassID, this.strReferenceClassID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_ReferenceClass", objEx);
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
		/// Store: SIM_ReferenceClass_GET 
		///</summary>
		/// <returns> SIM_ReferenceClass </returns>
		public SIM_ReferenceClass Get(int? intYearID, int? intSemester, string strClassID, string strReferenceClassID)
		{
			SIM_ReferenceClass obj = new SIM_ReferenceClass();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.YearID = intYearID;
			obj.Semester = intSemester;
			obj.ClassID = strClassID;
			obj.ReferenceClassID = strReferenceClassID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_ReferenceClass
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_ReferenceClass", objEx);
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
		/// Search : SIM_ReferenceClass
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_ReferenceClass", objEx);
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
		/// Search : SIM_ReferenceClass
		/// Lấy hết dữ liệu
		/// Store: SIM_ReferenceClass_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_ReferenceClass_GETALL");
		}

		///<summary>
		/// Search : SIM_ReferenceClass
		/// Tìm dữ liệu
		/// Store: SIM_ReferenceClass_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_ReferenceClass_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_ReferenceClass
		/// Thêm dữ liệu
		/// Store: SIM_ReferenceClass_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ReferenceClass_ADD");
				objIData.AddParameter(P_YearID, this.intYearID);
				objIData.AddParameter(P_Semester, this.intSemester);
				objIData.AddParameter(P_ClassID, this.strClassID);
				objIData.AddParameter(P_ReferenceClassID, this.strReferenceClassID);
				objIData.AddParameter(P_GroupSmallClass, this.intGroupSmallClass);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_ReferenceClass", objEx);
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
		/// Update : SIM_ReferenceClass
		/// Cập nhật dữ liệu
		/// Store: SIM_ReferenceClass_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ReferenceClass_EDIT");
				objIData.AddParameter(P_YearID, this.intYearID);
				objIData.AddParameter(P_Semester, this.intSemester);
				objIData.AddParameter(P_ClassID, this.strClassID);
				objIData.AddParameter(P_ReferenceClassID, this.strReferenceClassID);
				objIData.AddParameter(P_GroupSmallClass, this.intGroupSmallClass);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_ReferenceClass", objEx);
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
		/// Delete : SIM_ReferenceClass
		/// Xóa dữ liệu
		/// Store: SIM_ReferenceClass_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ReferenceClass_DELETE");
				objIData.AddParameter(P_YearID, this.intYearID);
				objIData.AddParameter(P_Semester, this.intSemester);
				objIData.AddParameter(P_ClassID, this.strClassID);
				objIData.AddParameter(P_ReferenceClassID, this.strReferenceClassID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_ReferenceClass", objEx);
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
		/// Store: SIM_ReferenceClass_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(int? intYearID, int? intSemester, string strClassID, string strReferenceClassID)
		{
			this.intYearID = intYearID;
			this.intSemester = intSemester;
			this.strClassID = strClassID;
			this.strReferenceClassID = strReferenceClassID;
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

		public SIM_ReferenceClass()
		{
		}
		public SIM_ReferenceClass(int? intYearID, int? intSemester, string strClassID, string strReferenceClassID)
		{
			this.intYearID = intYearID;
			this.intSemester = intSemester;
			this.strClassID = strClassID;
			this.strReferenceClassID = strReferenceClassID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_YearID = "@" + C_YearID;
		public const String P_Semester = "@" + C_Semester;
		public const String P_ClassID = "@" + C_ClassID;
		public const String P_ReferenceClassID = "@" + C_ReferenceClassID;
		public const String P_GroupSmallClass = "@" + C_GroupSmallClass;

		#endregion //Parameter names

		#region Column Names

		public const String C_YearID = "YearID";
		public const String C_Semester = "Semester";
		public const String C_ClassID = "ClassID";
		public const String C_ReferenceClassID = "ReferenceClassID";
		public const String C_GroupSmallClass = "GroupSmallClass";

		#endregion //Column names

		#endregion Variable Static		
	}
}
