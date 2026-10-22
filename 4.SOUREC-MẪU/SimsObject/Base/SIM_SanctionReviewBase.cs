
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
	/// Created date 	: 9/8/2013 
	/// Description 
	/// </summary>	
	public partial class SIM_SanctionReview
	{	
		#region Member Variables

		private long? lngSanctionReviewID = null;
		private long? lngStudentID = null;
		private int? intYearID = null;
		private int? intSemester = null;
		private string strLetter = null;//Thư mời
		private string strLeaveLearning = null;//TB Bỏ học
		private string strMetParent = null;//PHHS đến
		private string strManagerTeacherNote = null;//Ý kiến GVCN
		private string strStudentRoomNote = null;//Ý kiến P.CTHS
		private string strCouncilNote = null;//Ý kiến HĐKL
		private string strDescription = null;//Ghi chú
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
		/// SanctionReviewID
		/// 
		/// </summary>
		public long? SanctionReviewID
		{
			get { return  lngSanctionReviewID; }
			set { lngSanctionReviewID = value; }
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
		/// Letter
		/// Thư mời
		/// </summary>
		public string Letter
		{
			get { return  strLetter; }
			set { strLetter = value; }
		}
		/// <summary>
		/// LeaveLearning
		/// TB Bỏ học
		/// </summary>
		public string LeaveLearning
		{
			get { return  strLeaveLearning; }
			set { strLeaveLearning = value; }
		}
		/// <summary>
		/// MetParent
		/// PHHS đến
		/// </summary>
		public string MetParent
		{
			get { return  strMetParent; }
			set { strMetParent = value; }
		}
		/// <summary>
		/// ManagerTeacherNote
		/// Ý kiến GVCN
		/// </summary>
		public string ManagerTeacherNote
		{
			get { return  strManagerTeacherNote; }
			set { strManagerTeacherNote = value; }
		}
		/// <summary>
		/// StudentRoomNote
		/// Ý kiến P.CTHS
		/// </summary>
		public string StudentRoomNote
		{
			get { return  strStudentRoomNote; }
			set { strStudentRoomNote = value; }
		}
		/// <summary>
		/// CouncilNote
		/// Ý kiến HĐKL
		/// </summary>
		public string CouncilNote
		{
			get { return  strCouncilNote; }
			set { strCouncilNote = value; }
		}
		/// <summary>
		/// Description
		/// Ghi chú
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
					if (reader.GetName(i).ToUpper().Equals(C_SanctionReviewID.ToUpper()) && !Convert.IsDBNull(reader[C_SanctionReviewID])) this.lngSanctionReviewID = Convert.ToInt64(reader[C_SanctionReviewID]);
					if (reader.GetName(i).ToUpper().Equals(C_StudentID.ToUpper()) && !Convert.IsDBNull(reader[C_StudentID])) this.lngStudentID = Convert.ToInt64(reader[C_StudentID]);
					if (reader.GetName(i).ToUpper().Equals(C_YearID.ToUpper()) && !Convert.IsDBNull(reader[C_YearID])) this.intYearID = Convert.ToInt32(reader[C_YearID]);
					if (reader.GetName(i).ToUpper().Equals(C_Semester.ToUpper()) && !Convert.IsDBNull(reader[C_Semester])) this.intSemester = Convert.ToInt32(reader[C_Semester]);
					if (reader.GetName(i).ToUpper().Equals(C_Letter.ToUpper()) && !Convert.IsDBNull(reader[C_Letter])) this.strLetter = Convert.ToString(reader[C_Letter]);
					if (reader.GetName(i).ToUpper().Equals(C_LeaveLearning.ToUpper()) && !Convert.IsDBNull(reader[C_LeaveLearning])) this.strLeaveLearning = Convert.ToString(reader[C_LeaveLearning]);
					if (reader.GetName(i).ToUpper().Equals(C_MetParent.ToUpper()) && !Convert.IsDBNull(reader[C_MetParent])) this.strMetParent = Convert.ToString(reader[C_MetParent]);
					if (reader.GetName(i).ToUpper().Equals(C_ManagerTeacherNote.ToUpper()) && !Convert.IsDBNull(reader[C_ManagerTeacherNote])) this.strManagerTeacherNote = Convert.ToString(reader[C_ManagerTeacherNote]);
					if (reader.GetName(i).ToUpper().Equals(C_StudentRoomNote.ToUpper()) && !Convert.IsDBNull(reader[C_StudentRoomNote])) this.strStudentRoomNote = Convert.ToString(reader[C_StudentRoomNote]);
					if (reader.GetName(i).ToUpper().Equals(C_CouncilNote.ToUpper()) && !Convert.IsDBNull(reader[C_CouncilNote])) this.strCouncilNote = Convert.ToString(reader[C_CouncilNote]);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_SanctionReview", objEx);
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
				if (!Convert.IsDBNull(drw[C_SanctionReviewID])) this.lngSanctionReviewID = Convert.ToInt64(drw[C_SanctionReviewID]);
				if (!Convert.IsDBNull(drw[C_StudentID])) this.lngStudentID = Convert.ToInt64(drw[C_StudentID]);
				if (!Convert.IsDBNull(drw[C_YearID])) this.intYearID = Convert.ToInt32(drw[C_YearID]);
				if (!Convert.IsDBNull(drw[C_Semester])) this.intSemester = Convert.ToInt32(drw[C_Semester]);
				if (!Convert.IsDBNull(drw[C_Letter])) this.strLetter = Convert.ToString(drw[C_Letter]);
				if (!Convert.IsDBNull(drw[C_LeaveLearning])) this.strLeaveLearning = Convert.ToString(drw[C_LeaveLearning]);
				if (!Convert.IsDBNull(drw[C_MetParent])) this.strMetParent = Convert.ToString(drw[C_MetParent]);
				if (!Convert.IsDBNull(drw[C_ManagerTeacherNote])) this.strManagerTeacherNote = Convert.ToString(drw[C_ManagerTeacherNote]);
				if (!Convert.IsDBNull(drw[C_StudentRoomNote])) this.strStudentRoomNote = Convert.ToString(drw[C_StudentRoomNote]);
				if (!Convert.IsDBNull(drw[C_CouncilNote])) this.strCouncilNote = Convert.ToString(drw[C_CouncilNote]);
				if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
				if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
				if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
				if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
				if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_SanctionReview", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_SanctionReview_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_SanctionReview_GET");
				objIData.AddParameter(P_SanctionReviewID, this.lngSanctionReviewID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_SanctionReview", objEx);
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
		/// Store: SIM_SanctionReview_GET 
		///</summary>
		/// <returns> SIM_SanctionReview </returns>
		public SIM_SanctionReview Get(long? lngSanctionReviewID)
		{
			SIM_SanctionReview obj = new SIM_SanctionReview();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.SanctionReviewID = lngSanctionReviewID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_SanctionReview
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_SanctionReview", objEx);
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
		/// Search : SIM_SanctionReview
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_SanctionReview", objEx);
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
		/// Search : SIM_SanctionReview
		/// Lấy hết dữ liệu
		/// Store: SIM_SanctionReview_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_SanctionReview_GETALL");
		}

		///<summary>
		/// Search : SIM_SanctionReview
		/// Tìm dữ liệu
		/// Store: SIM_SanctionReview_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_SanctionReview_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_SanctionReview
		/// Thêm dữ liệu
		/// Store: SIM_SanctionReview_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_SanctionReview_ADD");
				objIData.AddParameter(P_StudentID, this.lngStudentID);
				objIData.AddParameter(P_YearID, this.intYearID);
				objIData.AddParameter(P_Semester, this.intSemester);
				objIData.AddParameter(P_Letter, this.strLetter);
				objIData.AddParameter(P_LeaveLearning, this.strLeaveLearning);
				objIData.AddParameter(P_MetParent, this.strMetParent);
				objIData.AddParameter(P_ManagerTeacherNote, this.strManagerTeacherNote);
				objIData.AddParameter(P_StudentRoomNote, this.strStudentRoomNote);
				objIData.AddParameter(P_CouncilNote, this.strCouncilNote);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				this.lngSanctionReviewID = Convert.ToInt32(objIData.ExecStoreToString());
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_SanctionReview", objEx);
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
		/// Update : SIM_SanctionReview
		/// Cập nhật dữ liệu
		/// Store: SIM_SanctionReview_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_SanctionReview_EDIT");
				objIData.AddParameter(P_SanctionReviewID, this.lngSanctionReviewID);
				objIData.AddParameter(P_StudentID, this.lngStudentID);
				objIData.AddParameter(P_YearID, this.intYearID);
				objIData.AddParameter(P_Semester, this.intSemester);
				objIData.AddParameter(P_Letter, this.strLetter);
				objIData.AddParameter(P_LeaveLearning, this.strLeaveLearning);
				objIData.AddParameter(P_MetParent, this.strMetParent);
				objIData.AddParameter(P_ManagerTeacherNote, this.strManagerTeacherNote);
				objIData.AddParameter(P_StudentRoomNote, this.strStudentRoomNote);
				objIData.AddParameter(P_CouncilNote, this.strCouncilNote);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_SanctionReview", objEx);
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
		/// Delete : SIM_SanctionReview
		/// Xóa dữ liệu
		/// Store: SIM_SanctionReview_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_SanctionReview_DELETE");
				objIData.AddParameter(P_SanctionReviewID, this.lngSanctionReviewID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_SanctionReview", objEx);
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
		/// Store: SIM_SanctionReview_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(long? lngSanctionReviewID)
		{
			this.lngSanctionReviewID = lngSanctionReviewID;
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

		public SIM_SanctionReview()
		{
		}
		public SIM_SanctionReview(long? lngSanctionReviewID)
		{
			this.lngSanctionReviewID = lngSanctionReviewID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_SanctionReviewID = "@" + C_SanctionReviewID;
		public const String P_StudentID = "@" + C_StudentID;
		public const String P_YearID = "@" + C_YearID;
		public const String P_Semester = "@" + C_Semester;
		public const String P_Letter = "@" + C_Letter;
		public const String P_LeaveLearning = "@" + C_LeaveLearning;
		public const String P_MetParent = "@" + C_MetParent;
		public const String P_ManagerTeacherNote = "@" + C_ManagerTeacherNote;
		public const String P_StudentRoomNote = "@" + C_StudentRoomNote;
		public const String P_CouncilNote = "@" + C_CouncilNote;
		public const String P_Description = "@" + C_Description;
		public const String P_CreatedDate = "@" + C_CreatedDate;
		public const String P_CreatedUser = "@" + C_CreatedUser;
		public const String P_UpdatedDate = "@" + C_UpdatedDate;
		public const String P_UpdatedUser = "@" + C_UpdatedUser;

		#endregion //Parameter names

		#region Column Names

		public const String C_SanctionReviewID = "SanctionReviewID";
		public const String C_StudentID = "StudentID";
		public const String C_YearID = "YearID";
		public const String C_Semester = "Semester";
		public const String C_Letter = "Letter";
		public const String C_LeaveLearning = "LeaveLearning";
		public const String C_MetParent = "MetParent";
		public const String C_ManagerTeacherNote = "ManagerTeacherNote";
		public const String C_StudentRoomNote = "StudentRoomNote";
		public const String C_CouncilNote = "CouncilNote";
		public const String C_Description = "Description";
		public const String C_CreatedDate = "CreatedDate";
		public const String C_CreatedUser = "CreatedUser";
		public const String C_UpdatedDate = "UpdatedDate";
		public const String C_UpdatedUser = "UpdatedUser";

		#endregion //Column names

		#endregion Variable Static		
	}
}
