
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
	/// Created date 	: 8/3/2022 
	/// Description 
	/// </summary>	
	public partial class SIM_Student_PersonalRelation
	{	
		#region Member Variables

		private long? lngStudent_PersionalRelationID = null;
		private long? lngStudentID = null;
		private long? lngPersonalRelationID = null;
		private int? intRelationTypeID = null;
		private IData objIData = null;
		private bool bolIsExistIData = false;
		private Exception objErrorException = null;

		#endregion

		#region Properties 

		/// <summary>
		/// Student_PersionalRelationID
		/// 
		/// </summary>
		public long? Student_PersionalRelationID
		{
			get { return  lngStudent_PersionalRelationID; }
			set { lngStudent_PersionalRelationID = value; }
		}
		/// <summary>
		/// StudentID
		/// 
		/// </summary>
		public long? StudentID
		{
			get { return  lngStudentID; }
			set { lngStudentID = value; }
		}
		/// <summary>
		/// PersonalRelationID
		/// 
		/// </summary>
		public long? PersonalRelationID
		{
			get { return  lngPersonalRelationID; }
			set { lngPersonalRelationID = value; }
		}
		/// <summary>
		/// RelationTypeID
		/// 
		/// </summary>
		public int? RelationTypeID
		{
			get { return  intRelationTypeID; }
			set { intRelationTypeID = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_Student_PersionalRelationID.ToUpper()) && !Convert.IsDBNull(reader[C_Student_PersionalRelationID])) this.lngStudent_PersionalRelationID = Convert.ToInt64(reader[C_Student_PersionalRelationID]);
					if (reader.GetName(i).ToUpper().Equals(C_StudentID.ToUpper()) && !Convert.IsDBNull(reader[C_StudentID])) this.lngStudentID = Convert.ToInt64(reader[C_StudentID]);
					if (reader.GetName(i).ToUpper().Equals(C_PersonalRelationID.ToUpper()) && !Convert.IsDBNull(reader[C_PersonalRelationID])) this.lngPersonalRelationID = Convert.ToInt64(reader[C_PersonalRelationID]);
					if (reader.GetName(i).ToUpper().Equals(C_RelationTypeID.ToUpper()) && !Convert.IsDBNull(reader[C_RelationTypeID])) this.intRelationTypeID = Convert.ToInt32(reader[C_RelationTypeID]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_Student_PersonalRelation", objEx);
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
				if (!Convert.IsDBNull(drw[C_Student_PersionalRelationID])) this.lngStudent_PersionalRelationID = Convert.ToInt64(drw[C_Student_PersionalRelationID]);
				if (!Convert.IsDBNull(drw[C_StudentID])) this.lngStudentID = Convert.ToInt64(drw[C_StudentID]);
				if (!Convert.IsDBNull(drw[C_PersonalRelationID])) this.lngPersonalRelationID = Convert.ToInt64(drw[C_PersonalRelationID]);
				if (!Convert.IsDBNull(drw[C_RelationTypeID])) this.intRelationTypeID = Convert.ToInt32(drw[C_RelationTypeID]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_Student_PersonalRelation", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_Student_PersonalRelation_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Student_PersonalRelation_GET");
				objIData.AddParameter(P_Student_PersionalRelationID, this.lngStudent_PersionalRelationID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_Student_PersonalRelation", objEx);
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
		/// Store: SIM_Student_PersonalRelation_GET 
		///</summary>
		/// <returns> SIM_Student_PersonalRelation </returns>
		public SIM_Student_PersonalRelation Get(long? lngStudent_PersionalRelationID)
		{
			SIM_Student_PersonalRelation obj = new SIM_Student_PersonalRelation();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.Student_PersionalRelationID = lngStudent_PersionalRelationID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_Student_PersonalRelation
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Student_PersonalRelation", objEx);
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
		/// Search : SIM_Student_PersonalRelation
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Student_PersonalRelation", objEx);
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
		/// Search : SIM_Student_PersonalRelation
		/// Lấy hết dữ liệu
		/// Store: SIM_Student_PersonalRelation_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_Student_PersonalRelation_GETALL");
		}

		///<summary>
		/// Search : SIM_Student_PersonalRelation
		/// Tìm dữ liệu
		/// Store: SIM_Student_PersonalRelation_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_Student_PersonalRelation_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_Student_PersonalRelation
		/// Thêm dữ liệu
		/// Store: SIM_Student_PersonalRelation_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Student_PersonalRelation_ADD");
				objIData.AddParameter(P_StudentID, this.lngStudentID);
				objIData.AddParameter(P_PersonalRelationID, this.lngPersonalRelationID);
				objIData.AddParameter(P_RelationTypeID, this.intRelationTypeID);
				this.lngStudent_PersionalRelationID = Convert.ToInt32(objIData.ExecStoreToString());
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_Student_PersonalRelation", objEx);
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
		/// Update : SIM_Student_PersonalRelation
		/// Cập nhật dữ liệu
		/// Store: SIM_Student_PersonalRelation_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Student_PersonalRelation_EDIT");
				objIData.AddParameter(P_Student_PersionalRelationID, this.lngStudent_PersionalRelationID);
				objIData.AddParameter(P_StudentID, this.lngStudentID);
				objIData.AddParameter(P_PersonalRelationID, this.lngPersonalRelationID);
				objIData.AddParameter(P_RelationTypeID, this.intRelationTypeID);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_Student_PersonalRelation", objEx);
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
		/// Delete : SIM_Student_PersonalRelation
		/// Xóa dữ liệu
		/// Store: SIM_Student_PersonalRelation_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Student_PersonalRelation_DELETE");
				objIData.AddParameter(P_Student_PersionalRelationID, this.lngStudent_PersionalRelationID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_Student_PersonalRelation", objEx);
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
		/// Store: SIM_Student_PersonalRelation_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(long? lngStudent_PersionalRelationID)
		{
			this.lngStudent_PersionalRelationID = lngStudent_PersionalRelationID;
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

		public SIM_Student_PersonalRelation()
		{
		}
		public SIM_Student_PersonalRelation(long? lngStudent_PersionalRelationID)
		{
			this.lngStudent_PersionalRelationID = lngStudent_PersionalRelationID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_Student_PersionalRelationID = "@" + C_Student_PersionalRelationID;
		public const String P_StudentID = "@" + C_StudentID;
		public const String P_PersonalRelationID = "@" + C_PersonalRelationID;
		public const String P_RelationTypeID = "@" + C_RelationTypeID;

		#endregion //Parameter names

		#region Column Names

		public const String C_Student_PersionalRelationID = "Student_PersionalRelationID";
		public const String C_StudentID = "StudentID";
		public const String C_PersonalRelationID = "PersonalRelationID";
		public const String C_RelationTypeID = "RelationTypeID";

		#endregion //Column names

		#endregion Variable Static		
	}
}
