
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
	/// Created date 	: 19/05/2020 
	/// Description 
	/// </summary>	
	public partial class SIM_ClassSubjectSame
	{	
		#region Member Variables

		private long? lngClassSubjectSameID = null;//Mã
		private string strClassSubjectSameCode = null;//Tên nhóm môn tương đương
		private string strClassSubjectSameName = null;//Tên nhóm môn tương đương
		private string strClassID = null;//Mã chuyên ngành
		private int? intRequestUnitText = null;//Tổng tín chỉ yêu cầu của nhóm tương đương
		private int? intRequestSubjectCount = null;//Tổng số môn yêu cầu của nhóm tương đương
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
		/// ClassSubjectSameID
		/// Mã
		/// </summary>
		public long? ClassSubjectSameID
		{
			get { return  lngClassSubjectSameID; }
			set { lngClassSubjectSameID = value; }
		}
		/// <summary>
		/// ClassSubjectSameCode
		/// Tên nhóm môn tương đương
		/// </summary>
		public string ClassSubjectSameCode
		{
			get { return  strClassSubjectSameCode; }
			set { strClassSubjectSameCode = value; }
		}
		/// <summary>
		/// ClassSubjectSameName
		/// Tên nhóm môn tương đương
		/// </summary>
		public string ClassSubjectSameName
		{
			get { return  strClassSubjectSameName; }
			set { strClassSubjectSameName = value; }
		}
		/// <summary>
		/// ClassID
		/// Mã chuyên ngành
		/// </summary>
		public string ClassID
		{
			get { return  strClassID; }
			set { strClassID = value; }
		}
		/// <summary>
		/// RequestUnitText
		/// Tổng tín chỉ yêu cầu của nhóm tương đương
		/// </summary>
		public int? RequestUnitText
		{
			get { return  intRequestUnitText; }
			set { intRequestUnitText = value; }
		}
		/// <summary>
		/// RequestSubjectCount
		/// Tổng số môn yêu cầu của nhóm tương đương
		/// </summary>
		public int? RequestSubjectCount
		{
			get { return  intRequestSubjectCount; }
			set { intRequestSubjectCount = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_ClassSubjectSameID.ToUpper()) && !Convert.IsDBNull(reader[C_ClassSubjectSameID])) this.lngClassSubjectSameID = Convert.ToInt64(reader[C_ClassSubjectSameID]);
					if (reader.GetName(i).ToUpper().Equals(C_ClassSubjectSameCode.ToUpper()) && !Convert.IsDBNull(reader[C_ClassSubjectSameCode])) this.strClassSubjectSameCode = Convert.ToString(reader[C_ClassSubjectSameCode]);
					if (reader.GetName(i).ToUpper().Equals(C_ClassSubjectSameName.ToUpper()) && !Convert.IsDBNull(reader[C_ClassSubjectSameName])) this.strClassSubjectSameName = Convert.ToString(reader[C_ClassSubjectSameName]);
					if (reader.GetName(i).ToUpper().Equals(C_ClassID.ToUpper()) && !Convert.IsDBNull(reader[C_ClassID])) this.strClassID = Convert.ToString(reader[C_ClassID]);
					if (reader.GetName(i).ToUpper().Equals(C_RequestUnitText.ToUpper()) && !Convert.IsDBNull(reader[C_RequestUnitText])) this.intRequestUnitText = Convert.ToInt32(reader[C_RequestUnitText]);
					if (reader.GetName(i).ToUpper().Equals(C_RequestSubjectCount.ToUpper()) && !Convert.IsDBNull(reader[C_RequestSubjectCount])) this.intRequestSubjectCount = Convert.ToInt32(reader[C_RequestSubjectCount]);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_ClassSubjectSame", objEx);
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
				if (!Convert.IsDBNull(drw[C_ClassSubjectSameID])) this.lngClassSubjectSameID = Convert.ToInt64(drw[C_ClassSubjectSameID]);
				if (!Convert.IsDBNull(drw[C_ClassSubjectSameCode])) this.strClassSubjectSameCode = Convert.ToString(drw[C_ClassSubjectSameCode]);
				if (!Convert.IsDBNull(drw[C_ClassSubjectSameName])) this.strClassSubjectSameName = Convert.ToString(drw[C_ClassSubjectSameName]);
				if (!Convert.IsDBNull(drw[C_ClassID])) this.strClassID = Convert.ToString(drw[C_ClassID]);
				if (!Convert.IsDBNull(drw[C_RequestUnitText])) this.intRequestUnitText = Convert.ToInt32(drw[C_RequestUnitText]);
				if (!Convert.IsDBNull(drw[C_RequestSubjectCount])) this.intRequestSubjectCount = Convert.ToInt32(drw[C_RequestSubjectCount]);
				if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
				if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
				if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
				if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
				if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_ClassSubjectSame", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_ClassSubjectSame_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ClassSubjectSame_GET");
				objIData.AddParameter(P_ClassSubjectSameID, this.lngClassSubjectSameID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_ClassSubjectSame", objEx);
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
		/// Store: SIM_ClassSubjectSame_GET 
		///</summary>
		/// <returns> SIM_ClassSubjectSame </returns>
		public SIM_ClassSubjectSame Get(long? lngClassSubjectSameID)
		{
			SIM_ClassSubjectSame obj = new SIM_ClassSubjectSame();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.ClassSubjectSameID = lngClassSubjectSameID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_ClassSubjectSame
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_ClassSubjectSame", objEx);
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
		/// Search : SIM_ClassSubjectSame
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_ClassSubjectSame", objEx);
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
		/// Search : SIM_ClassSubjectSame
		/// Lấy hết dữ liệu
		/// Store: SIM_ClassSubjectSame_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_ClassSubjectSame_GETALL");
		}

		///<summary>
		/// Search : SIM_ClassSubjectSame
		/// Tìm dữ liệu
		/// Store: SIM_ClassSubjectSame_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_ClassSubjectSame_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_ClassSubjectSame
		/// Thêm dữ liệu
		/// Store: SIM_ClassSubjectSame_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ClassSubjectSame_ADD");
				objIData.AddParameter(P_ClassSubjectSameCode, this.strClassSubjectSameCode);
				objIData.AddParameter(P_ClassSubjectSameName, this.strClassSubjectSameName);
				objIData.AddParameter(P_ClassID, this.strClassID);
				objIData.AddParameter(P_RequestUnitText, this.intRequestUnitText);
				objIData.AddParameter(P_RequestSubjectCount, this.intRequestSubjectCount);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				this.lngClassSubjectSameID = Convert.ToInt32(objIData.ExecStoreToString());
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_ClassSubjectSame", objEx);
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
		/// Update : SIM_ClassSubjectSame
		/// Cập nhật dữ liệu
		/// Store: SIM_ClassSubjectSame_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ClassSubjectSame_EDIT");
				objIData.AddParameter(P_ClassSubjectSameID, this.lngClassSubjectSameID);
				objIData.AddParameter(P_ClassSubjectSameCode, this.strClassSubjectSameCode);
				objIData.AddParameter(P_ClassSubjectSameName, this.strClassSubjectSameName);
				objIData.AddParameter(P_ClassID, this.strClassID);
				objIData.AddParameter(P_RequestUnitText, this.intRequestUnitText);
				objIData.AddParameter(P_RequestSubjectCount, this.intRequestSubjectCount);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_ClassSubjectSame", objEx);
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
		/// Delete : SIM_ClassSubjectSame
		/// Xóa dữ liệu
		/// Store: SIM_ClassSubjectSame_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ClassSubjectSame_DELETE");
				objIData.AddParameter(P_ClassSubjectSameID, this.lngClassSubjectSameID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_ClassSubjectSame", objEx);
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
		/// Store: SIM_ClassSubjectSame_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(long? lngClassSubjectSameID)
		{
			this.lngClassSubjectSameID = lngClassSubjectSameID;
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

		public SIM_ClassSubjectSame()
		{
		}
		public SIM_ClassSubjectSame(long? lngClassSubjectSameID)
		{
			this.lngClassSubjectSameID = lngClassSubjectSameID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_ClassSubjectSameID = "@" + C_ClassSubjectSameID;
		public const String P_ClassSubjectSameCode = "@" + C_ClassSubjectSameCode;
		public const String P_ClassSubjectSameName = "@" + C_ClassSubjectSameName;
		public const String P_ClassID = "@" + C_ClassID;
		public const String P_RequestUnitText = "@" + C_RequestUnitText;
		public const String P_RequestSubjectCount = "@" + C_RequestSubjectCount;
		public const String P_Description = "@" + C_Description;
		public const String P_CreatedDate = "@" + C_CreatedDate;
		public const String P_CreatedUser = "@" + C_CreatedUser;
		public const String P_UpdatedDate = "@" + C_UpdatedDate;
		public const String P_UpdatedUser = "@" + C_UpdatedUser;

		#endregion //Parameter names

		#region Column Names

		public const String C_ClassSubjectSameID = "ClassSubjectSameID";
		public const String C_ClassSubjectSameCode = "ClassSubjectSameCode";
		public const String C_ClassSubjectSameName = "ClassSubjectSameName";
		public const String C_ClassID = "ClassID";
		public const String C_RequestUnitText = "RequestUnitText";
		public const String C_RequestSubjectCount = "RequestSubjectCount";
		public const String C_Description = "Description";
		public const String C_CreatedDate = "CreatedDate";
		public const String C_CreatedUser = "CreatedUser";
		public const String C_UpdatedDate = "UpdatedDate";
		public const String C_UpdatedUser = "UpdatedUser";

		#endregion //Column names

		#endregion Variable Static		
	}
}
