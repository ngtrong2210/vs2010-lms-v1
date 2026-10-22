
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
	public partial class SIM_Subject_Room
	{	
		#region Member Variables

		private int? intSubjectRoomID = null;
		private string strSubjectID = null;//Mã môn học
		private string strRoomID = null;//Mã phòng
		private bool bolIsPractice = false;//Là học thực hành
		private IData objIData = null;
		private bool bolIsExistIData = false;
		private Exception objErrorException = null;

		#endregion

		#region Properties 

		/// <summary>
		/// SubjectRoomID
		/// 
		/// </summary>
		public int? SubjectRoomID
		{
			get { return  intSubjectRoomID; }
			set { intSubjectRoomID = value; }
		}
		/// <summary>
		/// SubjectID
		/// Mã môn học
		/// </summary>
		public string SubjectID
		{
			get { return  strSubjectID; }
			set { strSubjectID = value; }
		}
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
		/// IsPractice
		/// Là học thực hành
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
					if (reader.GetName(i).ToUpper().Equals(C_SubjectRoomID.ToUpper()) && !Convert.IsDBNull(reader[C_SubjectRoomID])) this.intSubjectRoomID = Convert.ToInt32(reader[C_SubjectRoomID]);
					if (reader.GetName(i).ToUpper().Equals(C_SubjectID.ToUpper()) && !Convert.IsDBNull(reader[C_SubjectID])) this.strSubjectID = Convert.ToString(reader[C_SubjectID]);
					if (reader.GetName(i).ToUpper().Equals(C_RoomID.ToUpper()) && !Convert.IsDBNull(reader[C_RoomID])) this.strRoomID = Convert.ToString(reader[C_RoomID]);
					if (reader.GetName(i).ToUpper().Equals(C_IsPractice.ToUpper()) && !Convert.IsDBNull(reader[C_IsPractice])) this.bolIsPractice = Convert.ToBoolean(reader[C_IsPractice]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_Subject_Room", objEx);
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
				if (!Convert.IsDBNull(drw[C_SubjectRoomID])) this.intSubjectRoomID = Convert.ToInt32(drw[C_SubjectRoomID]);
				if (!Convert.IsDBNull(drw[C_SubjectID])) this.strSubjectID = Convert.ToString(drw[C_SubjectID]);
				if (!Convert.IsDBNull(drw[C_RoomID])) this.strRoomID = Convert.ToString(drw[C_RoomID]);
				if (!Convert.IsDBNull(drw[C_IsPractice])) this.bolIsPractice = Convert.ToBoolean(drw[C_IsPractice]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_Subject_Room", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_Subject_Room_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Subject_Room_GET");
				objIData.AddParameter(P_SubjectRoomID, this.intSubjectRoomID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_Subject_Room", objEx);
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
		/// Store: SIM_Subject_Room_GET 
		///</summary>
		/// <returns> SIM_Subject_Room </returns>
		public SIM_Subject_Room Get(int? intSubjectRoomID)
		{
			SIM_Subject_Room obj = new SIM_Subject_Room();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.SubjectRoomID = intSubjectRoomID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_Subject_Room
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Subject_Room", objEx);
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
		/// Search : SIM_Subject_Room
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Subject_Room", objEx);
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
		/// Search : SIM_Subject_Room
		/// Lấy hết dữ liệu
		/// Store: SIM_Subject_Room_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_Subject_Room_GETALL");
		}

		///<summary>
		/// Search : SIM_Subject_Room
		/// Tìm dữ liệu
		/// Store: SIM_Subject_Room_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_Subject_Room_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_Subject_Room
		/// Thêm dữ liệu
		/// Store: SIM_Subject_Room_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Subject_Room_ADD");
				objIData.AddParameter(P_SubjectID, this.strSubjectID);
				objIData.AddParameter(P_RoomID, this.strRoomID);
				objIData.AddParameter(P_IsPractice, this.bolIsPractice);
				this.intSubjectRoomID = Convert.ToInt32(objIData.ExecStoreToString());
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_Subject_Room", objEx);
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
		/// Update : SIM_Subject_Room
		/// Cập nhật dữ liệu
		/// Store: SIM_Subject_Room_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Subject_Room_EDIT");
				objIData.AddParameter(P_SubjectRoomID, this.intSubjectRoomID);
				objIData.AddParameter(P_SubjectID, this.strSubjectID);
				objIData.AddParameter(P_RoomID, this.strRoomID);
				objIData.AddParameter(P_IsPractice, this.bolIsPractice);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_Subject_Room", objEx);
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
		/// Delete : SIM_Subject_Room
		/// Xóa dữ liệu
		/// Store: SIM_Subject_Room_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Subject_Room_DELETE");
				objIData.AddParameter(P_SubjectRoomID, this.intSubjectRoomID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_Subject_Room", objEx);
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
		/// Store: SIM_Subject_Room_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(int? intSubjectRoomID)
		{
			this.intSubjectRoomID = intSubjectRoomID;
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

		public SIM_Subject_Room()
		{
		}
		public SIM_Subject_Room(int? intSubjectRoomID)
		{
			this.intSubjectRoomID = intSubjectRoomID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_SubjectRoomID = "@" + C_SubjectRoomID;
		public const String P_SubjectID = "@" + C_SubjectID;
		public const String P_RoomID = "@" + C_RoomID;
		public const String P_IsPractice = "@" + C_IsPractice;

		#endregion //Parameter names

		#region Column Names

		public const String C_SubjectRoomID = "SubjectRoomID";
		public const String C_SubjectID = "SubjectID";
		public const String C_RoomID = "RoomID";
		public const String C_IsPractice = "IsPractice";

		#endregion //Column names

		#endregion Variable Static		
	}
}
