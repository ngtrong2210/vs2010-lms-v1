
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
	public partial class SIM_SBSSame
	{	
		#region Member Variables

		private int? intSBSSameID = null;//Mã
		private string strSBSSameCode = null;//Tên nhóm môn tương đương
		private string strSBSSameName = null;//Tên nhóm môn tương đương
		private string strSpecialBranchID = null;//Mã chuyên ngành
		private string strTrainingLevelID = null;//Bậc đào tạo
		private string strTrainingType = null;//Loại đào tạo
		private string strCourseID = null;//Mã khoá học
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
		/// SBSSameID
		/// Mã
		/// </summary>
		public int? SBSSameID
		{
			get { return  intSBSSameID; }
			set { intSBSSameID = value; }
		}
		/// <summary>
		/// SBSSameCode
		/// Tên nhóm môn tương đương
		/// </summary>
		public string SBSSameCode
		{
			get { return  strSBSSameCode; }
			set { strSBSSameCode = value; }
		}
		/// <summary>
		/// SBSSameName
		/// Tên nhóm môn tương đương
		/// </summary>
		public string SBSSameName
		{
			get { return  strSBSSameName; }
			set { strSBSSameName = value; }
		}
		/// <summary>
		/// SpecialBranchID
		/// Mã chuyên ngành
		/// </summary>
		public string SpecialBranchID
		{
			get { return  strSpecialBranchID; }
			set { strSpecialBranchID = value; }
		}
		/// <summary>
		/// TrainingLevelID
		/// Bậc đào tạo
		/// </summary>
		public string TrainingLevelID
		{
			get { return  strTrainingLevelID; }
			set { strTrainingLevelID = value; }
		}
		/// <summary>
		/// TrainingType
		/// Loại đào tạo
		/// </summary>
		public string TrainingType
		{
			get { return  strTrainingType; }
			set { strTrainingType = value; }
		}
		/// <summary>
		/// CourseID
		/// Mã khoá học
		/// </summary>
		public string CourseID
		{
			get { return  strCourseID; }
			set { strCourseID = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_SBSSameID.ToUpper()) && !Convert.IsDBNull(reader[C_SBSSameID])) this.intSBSSameID = Convert.ToInt32(reader[C_SBSSameID]);
					if (reader.GetName(i).ToUpper().Equals(C_SBSSameCode.ToUpper()) && !Convert.IsDBNull(reader[C_SBSSameCode])) this.strSBSSameCode = Convert.ToString(reader[C_SBSSameCode]);
					if (reader.GetName(i).ToUpper().Equals(C_SBSSameName.ToUpper()) && !Convert.IsDBNull(reader[C_SBSSameName])) this.strSBSSameName = Convert.ToString(reader[C_SBSSameName]);
					if (reader.GetName(i).ToUpper().Equals(C_SpecialBranchID.ToUpper()) && !Convert.IsDBNull(reader[C_SpecialBranchID])) this.strSpecialBranchID = Convert.ToString(reader[C_SpecialBranchID]);
					if (reader.GetName(i).ToUpper().Equals(C_TrainingLevelID.ToUpper()) && !Convert.IsDBNull(reader[C_TrainingLevelID])) this.strTrainingLevelID = Convert.ToString(reader[C_TrainingLevelID]);
					if (reader.GetName(i).ToUpper().Equals(C_TrainingType.ToUpper()) && !Convert.IsDBNull(reader[C_TrainingType])) this.strTrainingType = Convert.ToString(reader[C_TrainingType]);
					if (reader.GetName(i).ToUpper().Equals(C_CourseID.ToUpper()) && !Convert.IsDBNull(reader[C_CourseID])) this.strCourseID = Convert.ToString(reader[C_CourseID]);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_SBSSame", objEx);
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
				if (!Convert.IsDBNull(drw[C_SBSSameID])) this.intSBSSameID = Convert.ToInt32(drw[C_SBSSameID]);
				if (!Convert.IsDBNull(drw[C_SBSSameCode])) this.strSBSSameCode = Convert.ToString(drw[C_SBSSameCode]);
				if (!Convert.IsDBNull(drw[C_SBSSameName])) this.strSBSSameName = Convert.ToString(drw[C_SBSSameName]);
				if (!Convert.IsDBNull(drw[C_SpecialBranchID])) this.strSpecialBranchID = Convert.ToString(drw[C_SpecialBranchID]);
				if (!Convert.IsDBNull(drw[C_TrainingLevelID])) this.strTrainingLevelID = Convert.ToString(drw[C_TrainingLevelID]);
				if (!Convert.IsDBNull(drw[C_TrainingType])) this.strTrainingType = Convert.ToString(drw[C_TrainingType]);
				if (!Convert.IsDBNull(drw[C_CourseID])) this.strCourseID = Convert.ToString(drw[C_CourseID]);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_SBSSame", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_SBSSame_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_SBSSame_GET");
				objIData.AddParameter(P_SBSSameID, this.intSBSSameID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_SBSSame", objEx);
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
		/// Store: SIM_SBSSame_GET 
		///</summary>
		/// <returns> SIM_SBSSame </returns>
		public SIM_SBSSame Get(int? intSBSSameID)
		{
			SIM_SBSSame obj = new SIM_SBSSame();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.SBSSameID = intSBSSameID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_SBSSame
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_SBSSame", objEx);
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
		/// Search : SIM_SBSSame
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_SBSSame", objEx);
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
		/// Search : SIM_SBSSame
		/// Lấy hết dữ liệu
		/// Store: SIM_SBSSame_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_SBSSame_GETALL");
		}

		///<summary>
		/// Search : SIM_SBSSame
		/// Tìm dữ liệu
		/// Store: SIM_SBSSame_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_SBSSame_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_SBSSame
		/// Thêm dữ liệu
		/// Store: SIM_SBSSame_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_SBSSame_ADD");
				objIData.AddParameter(P_SBSSameCode, this.strSBSSameCode);
				objIData.AddParameter(P_SBSSameName, this.strSBSSameName);
				objIData.AddParameter(P_SpecialBranchID, this.strSpecialBranchID);
				objIData.AddParameter(P_TrainingLevelID, this.strTrainingLevelID);
				objIData.AddParameter(P_TrainingType, this.strTrainingType);
				objIData.AddParameter(P_CourseID, this.strCourseID);
				objIData.AddParameter(P_RequestUnitText, this.intRequestUnitText);
				objIData.AddParameter(P_RequestSubjectCount, this.intRequestSubjectCount);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				this.intSBSSameID = Convert.ToInt32(objIData.ExecStoreToString());
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_SBSSame", objEx);
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
		/// Update : SIM_SBSSame
		/// Cập nhật dữ liệu
		/// Store: SIM_SBSSame_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_SBSSame_EDIT");
				objIData.AddParameter(P_SBSSameID, this.intSBSSameID);
				objIData.AddParameter(P_SBSSameCode, this.strSBSSameCode);
				objIData.AddParameter(P_SBSSameName, this.strSBSSameName);
				objIData.AddParameter(P_SpecialBranchID, this.strSpecialBranchID);
				objIData.AddParameter(P_TrainingLevelID, this.strTrainingLevelID);
				objIData.AddParameter(P_TrainingType, this.strTrainingType);
				objIData.AddParameter(P_CourseID, this.strCourseID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_SBSSame", objEx);
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
		/// Delete : SIM_SBSSame
		/// Xóa dữ liệu
		/// Store: SIM_SBSSame_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_SBSSame_DELETE");
				objIData.AddParameter(P_SBSSameID, this.intSBSSameID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_SBSSame", objEx);
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
		/// Store: SIM_SBSSame_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(int? intSBSSameID)
		{
			this.intSBSSameID = intSBSSameID;
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

		public SIM_SBSSame()
		{
		}
		public SIM_SBSSame(int? intSBSSameID)
		{
			this.intSBSSameID = intSBSSameID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_SBSSameID = "@" + C_SBSSameID;
		public const String P_SBSSameCode = "@" + C_SBSSameCode;
		public const String P_SBSSameName = "@" + C_SBSSameName;
		public const String P_SpecialBranchID = "@" + C_SpecialBranchID;
		public const String P_TrainingLevelID = "@" + C_TrainingLevelID;
		public const String P_TrainingType = "@" + C_TrainingType;
		public const String P_CourseID = "@" + C_CourseID;
		public const String P_RequestUnitText = "@" + C_RequestUnitText;
		public const String P_RequestSubjectCount = "@" + C_RequestSubjectCount;
		public const String P_Description = "@" + C_Description;
		public const String P_CreatedDate = "@" + C_CreatedDate;
		public const String P_CreatedUser = "@" + C_CreatedUser;
		public const String P_UpdatedDate = "@" + C_UpdatedDate;
		public const String P_UpdatedUser = "@" + C_UpdatedUser;

		#endregion //Parameter names

		#region Column Names

		public const String C_SBSSameID = "SBSSameID";
		public const String C_SBSSameCode = "SBSSameCode";
		public const String C_SBSSameName = "SBSSameName";
		public const String C_SpecialBranchID = "SpecialBranchID";
		public const String C_TrainingLevelID = "TrainingLevelID";
		public const String C_TrainingType = "TrainingType";
		public const String C_CourseID = "CourseID";
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
