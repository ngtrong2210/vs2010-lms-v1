
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
	/// Created date 	: 24/07/2019 
	/// Description 
	/// </summary>	
	public partial class SIM_MethodTest
	{	
		#region Member Variables

		private int? intMethodTestID = null;
		private string strMethodTestCode = null;
		private string strMethodTestName = null;
		private int? intRequestExamCount = null;//Số đề cần soạn
		private double? dblCreateExamRatio = null;//Hệ số soạn đề
		private double? dblDoMarkExamRatio = null;//Hệ số chấm bài
		private string strDescription = null;//Mô tả
		private bool bolIsActived = false;//Đã kích hoạt (Sẵn dùng)
		private long? lngOrderIndex = null;
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
		/// MethodTestID
		/// 
		/// </summary>
		public int? MethodTestID
		{
			get { return  intMethodTestID; }
			set { intMethodTestID = value; }
		}
		/// <summary>
		/// MethodTestCode
		/// 
		/// </summary>
		public string MethodTestCode
		{
			get { return  strMethodTestCode; }
			set { strMethodTestCode = value; }
		}
		/// <summary>
		/// MethodTestName
		/// 
		/// </summary>
		public string MethodTestName
		{
			get { return  strMethodTestName; }
			set { strMethodTestName = value; }
		}
		/// <summary>
		/// RequestExamCount
		/// Số đề cần soạn
		/// </summary>
		public int? RequestExamCount
		{
			get { return  intRequestExamCount; }
			set { intRequestExamCount = value; }
		}
		/// <summary>
		/// CreateExamRatio
		/// Hệ số soạn đề
		/// </summary>
		public double? CreateExamRatio
		{
			get { return  dblCreateExamRatio; }
			set { dblCreateExamRatio = value; }
		}
		/// <summary>
		/// DoMarkExamRatio
		/// Hệ số chấm bài
		/// </summary>
		public double? DoMarkExamRatio
		{
			get { return  dblDoMarkExamRatio; }
			set { dblDoMarkExamRatio = value; }
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
		/// IsActived
		/// Đã kích hoạt (Sẵn dùng)
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
		public long? OrderIndex
		{
			get { return  lngOrderIndex; }
			set { lngOrderIndex = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_MethodTestID.ToUpper()) && !Convert.IsDBNull(reader[C_MethodTestID])) this.intMethodTestID = Convert.ToInt32(reader[C_MethodTestID]);
					if (reader.GetName(i).ToUpper().Equals(C_MethodTestCode.ToUpper()) && !Convert.IsDBNull(reader[C_MethodTestCode])) this.strMethodTestCode = Convert.ToString(reader[C_MethodTestCode]);
					if (reader.GetName(i).ToUpper().Equals(C_MethodTestName.ToUpper()) && !Convert.IsDBNull(reader[C_MethodTestName])) this.strMethodTestName = Convert.ToString(reader[C_MethodTestName]);
					if (reader.GetName(i).ToUpper().Equals(C_RequestExamCount.ToUpper()) && !Convert.IsDBNull(reader[C_RequestExamCount])) this.intRequestExamCount = Convert.ToInt32(reader[C_RequestExamCount]);
					if (reader.GetName(i).ToUpper().Equals(C_CreateExamRatio.ToUpper()) && !Convert.IsDBNull(reader[C_CreateExamRatio])) this.dblCreateExamRatio = Convert.ToDouble(reader[C_CreateExamRatio]);
					if (reader.GetName(i).ToUpper().Equals(C_DoMarkExamRatio.ToUpper()) && !Convert.IsDBNull(reader[C_DoMarkExamRatio])) this.dblDoMarkExamRatio = Convert.ToDouble(reader[C_DoMarkExamRatio]);
					if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
					if (reader.GetName(i).ToUpper().Equals(C_IsActived.ToUpper()) && !Convert.IsDBNull(reader[C_IsActived])) this.bolIsActived = Convert.ToBoolean(reader[C_IsActived]);
					if (reader.GetName(i).ToUpper().Equals(C_OrderIndex.ToUpper()) && !Convert.IsDBNull(reader[C_OrderIndex])) this.lngOrderIndex = Convert.ToInt64(reader[C_OrderIndex]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(reader[C_UpdatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(reader[C_UpdatedUser]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_MethodTest", objEx);
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
				if (!Convert.IsDBNull(drw[C_MethodTestID])) this.intMethodTestID = Convert.ToInt32(drw[C_MethodTestID]);
				if (!Convert.IsDBNull(drw[C_MethodTestCode])) this.strMethodTestCode = Convert.ToString(drw[C_MethodTestCode]);
				if (!Convert.IsDBNull(drw[C_MethodTestName])) this.strMethodTestName = Convert.ToString(drw[C_MethodTestName]);
				if (!Convert.IsDBNull(drw[C_RequestExamCount])) this.intRequestExamCount = Convert.ToInt32(drw[C_RequestExamCount]);
				if (!Convert.IsDBNull(drw[C_CreateExamRatio])) this.dblCreateExamRatio = Convert.ToDouble(drw[C_CreateExamRatio]);
				if (!Convert.IsDBNull(drw[C_DoMarkExamRatio])) this.dblDoMarkExamRatio = Convert.ToDouble(drw[C_DoMarkExamRatio]);
				if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
				if (!Convert.IsDBNull(drw[C_IsActived])) this.bolIsActived = Convert.ToBoolean(drw[C_IsActived]);
				if (!Convert.IsDBNull(drw[C_OrderIndex])) this.lngOrderIndex = Convert.ToInt64(drw[C_OrderIndex]);
				if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
				if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
				if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
				if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_MethodTest", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_MethodTest_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_MethodTest_GET");
				objIData.AddParameter(P_MethodTestID, this.intMethodTestID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_MethodTest", objEx);
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
		/// Store: SIM_MethodTest_GET 
		///</summary>
		/// <returns> SIM_MethodTest </returns>
		public SIM_MethodTest Get(int? intMethodTestID)
		{
			SIM_MethodTest obj = new SIM_MethodTest();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.MethodTestID = intMethodTestID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_MethodTest
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_MethodTest", objEx);
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
		/// Search : SIM_MethodTest
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_MethodTest", objEx);
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
		/// Search : SIM_MethodTest
		/// Lấy hết dữ liệu
		/// Store: SIM_MethodTest_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_MethodTest_GETALL");
		}

		///<summary>
		/// Search : SIM_MethodTest
		/// Tìm dữ liệu
		/// Store: SIM_MethodTest_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_MethodTest_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_MethodTest
		/// Thêm dữ liệu
		/// Store: SIM_MethodTest_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_MethodTest_ADD");
				objIData.AddParameter(P_MethodTestCode, this.strMethodTestCode);
				objIData.AddParameter(P_MethodTestName, this.strMethodTestName);
				objIData.AddParameter(P_RequestExamCount, this.intRequestExamCount);
				objIData.AddParameter(P_CreateExamRatio, this.dblCreateExamRatio);
				objIData.AddParameter(P_DoMarkExamRatio, this.dblDoMarkExamRatio);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_IsActived, this.bolIsActived);
				objIData.AddParameter(P_OrderIndex, this.lngOrderIndex);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				this.intMethodTestID = Convert.ToInt32(objIData.ExecStoreToString());
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_MethodTest", objEx);
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
		/// Update : SIM_MethodTest
		/// Cập nhật dữ liệu
		/// Store: SIM_MethodTest_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_MethodTest_EDIT");
				objIData.AddParameter(P_MethodTestID, this.intMethodTestID);
				objIData.AddParameter(P_MethodTestCode, this.strMethodTestCode);
				objIData.AddParameter(P_MethodTestName, this.strMethodTestName);
				objIData.AddParameter(P_RequestExamCount, this.intRequestExamCount);
				objIData.AddParameter(P_CreateExamRatio, this.dblCreateExamRatio);
				objIData.AddParameter(P_DoMarkExamRatio, this.dblDoMarkExamRatio);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_IsActived, this.bolIsActived);
				objIData.AddParameter(P_OrderIndex, this.lngOrderIndex);
				objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_MethodTest", objEx);
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
		/// Delete : SIM_MethodTest
		/// Xóa dữ liệu
		/// Store: SIM_MethodTest_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_MethodTest_DELETE");
				objIData.AddParameter(P_MethodTestID, this.intMethodTestID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_MethodTest", objEx);
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
		/// Store: SIM_MethodTest_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(int? intMethodTestID)
		{
			this.intMethodTestID = intMethodTestID;
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

		public SIM_MethodTest()
		{
		}
		public SIM_MethodTest(int? intMethodTestID)
		{
			this.intMethodTestID = intMethodTestID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_MethodTestID = "@" + C_MethodTestID;
		public const String P_MethodTestCode = "@" + C_MethodTestCode;
		public const String P_MethodTestName = "@" + C_MethodTestName;
		public const String P_RequestExamCount = "@" + C_RequestExamCount;
		public const String P_CreateExamRatio = "@" + C_CreateExamRatio;
		public const String P_DoMarkExamRatio = "@" + C_DoMarkExamRatio;
		public const String P_Description = "@" + C_Description;
		public const String P_IsActived = "@" + C_IsActived;
		public const String P_OrderIndex = "@" + C_OrderIndex;
		public const String P_CreatedDate = "@" + C_CreatedDate;
		public const String P_CreatedUser = "@" + C_CreatedUser;
		public const String P_UpdatedDate = "@" + C_UpdatedDate;
		public const String P_UpdatedUser = "@" + C_UpdatedUser;

		#endregion //Parameter names

		#region Column Names

		public const String C_MethodTestID = "MethodTestID";
		public const String C_MethodTestCode = "MethodTestCode";
		public const String C_MethodTestName = "MethodTestName";
		public const String C_RequestExamCount = "RequestExamCount";
		public const String C_CreateExamRatio = "CreateExamRatio";
		public const String C_DoMarkExamRatio = "DoMarkExamRatio";
		public const String C_Description = "Description";
		public const String C_IsActived = "IsActived";
		public const String C_OrderIndex = "OrderIndex";
		public const String C_CreatedDate = "CreatedDate";
		public const String C_CreatedUser = "CreatedUser";
		public const String C_UpdatedDate = "UpdatedDate";
		public const String C_UpdatedUser = "UpdatedUser";

		#endregion //Column names

		#endregion Variable Static		
	}
}
