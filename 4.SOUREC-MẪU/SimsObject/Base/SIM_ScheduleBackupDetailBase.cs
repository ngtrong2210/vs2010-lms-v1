
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
	public partial class SIM_ScheduleBackupDetail
	{	
		#region Member Variables

		private long? lngBackupDetailID = null;
		private long? lngBackupID = null;
		private int? intDay = null;//Thứ tính từ 0-6
		private DateTime? dtmDate = null;//Ngày dạy
		private int? intWeek = null;//Tuần nào của niên học 1-50
		private int? intLessionTime = null;//Tiết học
		private long? lngClassSubjectID = null;
		private string strClassID = null;
		private string strSubjectID = null;
		private int? intYearID = null;
		private int? intSemester = null;
		private string strTeacherID = null;
		private string strRoomID = null;//Mã phòng
		private bool bolIsPractice = false;//Là môn thực hành
		private bool bolDone = false;//Đã dạy
		private int? intLearningSession = null;
		private bool bolIsTemplate = false;//Là lịch mẫu tạo ra
		private int? intAddLession = null;//Tiết cộng thêm so với thời lượng, mục đích để kiểm tra trùng giờ
		private bool bolIsReplace = false;//Dạy bù ko chấm công
		private string strScheduleContent = null;
		private string strCreatedBy = null;
		private DateTime? dtmCreatedAt = null;//Ngày tạo
		private IData objIData = null;
		private bool bolIsExistIData = false;
		private Exception objErrorException = null;

		#endregion

		#region Properties 

		/// <summary>
		/// BackupDetailID
		/// 
		/// </summary>
		public long? BackupDetailID
		{
			get { return  lngBackupDetailID; }
			set { lngBackupDetailID = value; }
		}
		/// <summary>
		/// BackupID
		/// 
		/// </summary>
		public long? BackupID
		{
			get { return  lngBackupID; }
			set { lngBackupID = value; }
		}
		/// <summary>
		/// Day
		/// Thứ tính từ 0-6
		/// </summary>
		public int? Day
		{
			get { return  intDay; }
			set { intDay = value; }
		}
		/// <summary>
		/// Date
		/// Ngày dạy
		/// </summary>
		public DateTime? Date
		{
			get { return  dtmDate; }
			set { dtmDate = value; }
		}
		/// <summary>
		/// Week
		/// Tuần nào của niên học 1-50
		/// </summary>
		public int? Week
		{
			get { return  intWeek; }
			set { intWeek = value; }
		}
		/// <summary>
		/// LessionTime
		/// Tiết học
		/// </summary>
		public int? LessionTime
		{
			get { return  intLessionTime; }
			set { intLessionTime = value; }
		}
		/// <summary>
		/// ClassSubjectID
		/// 
		/// </summary>
		public long? ClassSubjectID
		{
			get { return  lngClassSubjectID; }
			set { lngClassSubjectID = value; }
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
		/// SubjectID
		/// 
		/// </summary>
		public string SubjectID
		{
			get { return  strSubjectID; }
			set { strSubjectID = value; }
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
		/// TeacherID
		/// 
		/// </summary>
		public string TeacherID
		{
			get { return  strTeacherID; }
			set { strTeacherID = value; }
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
		/// Là môn thực hành
		/// </summary>
		public bool IsPractice
		{
			get { return  bolIsPractice; }
			set { bolIsPractice = value; }
		}
		/// <summary>
		/// Done
		/// Đã dạy
		/// </summary>
		public bool Done
		{
			get { return  bolDone; }
			set { bolDone = value; }
		}
		/// <summary>
		/// LearningSession
		/// 
		/// </summary>
		public int? LearningSession
		{
			get { return  intLearningSession; }
			set { intLearningSession = value; }
		}
		/// <summary>
		/// IsTemplate
		/// Là lịch mẫu tạo ra
		/// </summary>
		public bool IsTemplate
		{
			get { return  bolIsTemplate; }
			set { bolIsTemplate = value; }
		}
		/// <summary>
		/// AddLession
		/// Tiết cộng thêm so với thời lượng, mục đích để kiểm tra trùng giờ
		/// </summary>
		public int? AddLession
		{
			get { return  intAddLession; }
			set { intAddLession = value; }
		}
		/// <summary>
		/// IsReplace
		/// Dạy bù ko chấm công
		/// </summary>
		public bool IsReplace
		{
			get { return  bolIsReplace; }
			set { bolIsReplace = value; }
		}
		/// <summary>
		/// ScheduleContent
		/// 
		/// </summary>
		public string ScheduleContent
		{
			get { return  strScheduleContent; }
			set { strScheduleContent = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_BackupDetailID.ToUpper()) && !Convert.IsDBNull(reader[C_BackupDetailID])) this.lngBackupDetailID = Convert.ToInt64(reader[C_BackupDetailID]);
					if (reader.GetName(i).ToUpper().Equals(C_BackupID.ToUpper()) && !Convert.IsDBNull(reader[C_BackupID])) this.lngBackupID = Convert.ToInt64(reader[C_BackupID]);
					if (reader.GetName(i).ToUpper().Equals(C_Day.ToUpper()) && !Convert.IsDBNull(reader[C_Day])) this.intDay = Convert.ToInt32(reader[C_Day]);
					if (reader.GetName(i).ToUpper().Equals(C_Date.ToUpper()) && !Convert.IsDBNull(reader[C_Date])) this.dtmDate = Convert.ToDateTime(reader[C_Date]);
					if (reader.GetName(i).ToUpper().Equals(C_Week.ToUpper()) && !Convert.IsDBNull(reader[C_Week])) this.intWeek = Convert.ToInt32(reader[C_Week]);
					if (reader.GetName(i).ToUpper().Equals(C_LessionTime.ToUpper()) && !Convert.IsDBNull(reader[C_LessionTime])) this.intLessionTime = Convert.ToInt32(reader[C_LessionTime]);
					if (reader.GetName(i).ToUpper().Equals(C_ClassSubjectID.ToUpper()) && !Convert.IsDBNull(reader[C_ClassSubjectID])) this.lngClassSubjectID = Convert.ToInt64(reader[C_ClassSubjectID]);
					if (reader.GetName(i).ToUpper().Equals(C_ClassID.ToUpper()) && !Convert.IsDBNull(reader[C_ClassID])) this.strClassID = Convert.ToString(reader[C_ClassID]);
					if (reader.GetName(i).ToUpper().Equals(C_SubjectID.ToUpper()) && !Convert.IsDBNull(reader[C_SubjectID])) this.strSubjectID = Convert.ToString(reader[C_SubjectID]);
					if (reader.GetName(i).ToUpper().Equals(C_YearID.ToUpper()) && !Convert.IsDBNull(reader[C_YearID])) this.intYearID = Convert.ToInt32(reader[C_YearID]);
					if (reader.GetName(i).ToUpper().Equals(C_Semester.ToUpper()) && !Convert.IsDBNull(reader[C_Semester])) this.intSemester = Convert.ToInt32(reader[C_Semester]);
					if (reader.GetName(i).ToUpper().Equals(C_TeacherID.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherID])) this.strTeacherID = Convert.ToString(reader[C_TeacherID]);
					if (reader.GetName(i).ToUpper().Equals(C_RoomID.ToUpper()) && !Convert.IsDBNull(reader[C_RoomID])) this.strRoomID = Convert.ToString(reader[C_RoomID]);
					if (reader.GetName(i).ToUpper().Equals(C_IsPractice.ToUpper()) && !Convert.IsDBNull(reader[C_IsPractice])) this.bolIsPractice = Convert.ToBoolean(reader[C_IsPractice]);
					if (reader.GetName(i).ToUpper().Equals(C_Done.ToUpper()) && !Convert.IsDBNull(reader[C_Done])) this.bolDone = Convert.ToBoolean(reader[C_Done]);
					if (reader.GetName(i).ToUpper().Equals(C_LearningSession.ToUpper()) && !Convert.IsDBNull(reader[C_LearningSession])) this.intLearningSession = Convert.ToInt32(reader[C_LearningSession]);
					if (reader.GetName(i).ToUpper().Equals(C_IsTemplate.ToUpper()) && !Convert.IsDBNull(reader[C_IsTemplate])) this.bolIsTemplate = Convert.ToBoolean(reader[C_IsTemplate]);
					if (reader.GetName(i).ToUpper().Equals(C_AddLession.ToUpper()) && !Convert.IsDBNull(reader[C_AddLession])) this.intAddLession = Convert.ToInt32(reader[C_AddLession]);
					if (reader.GetName(i).ToUpper().Equals(C_IsReplace.ToUpper()) && !Convert.IsDBNull(reader[C_IsReplace])) this.bolIsReplace = Convert.ToBoolean(reader[C_IsReplace]);
					if (reader.GetName(i).ToUpper().Equals(C_ScheduleContent.ToUpper()) && !Convert.IsDBNull(reader[C_ScheduleContent])) this.strScheduleContent = Convert.ToString(reader[C_ScheduleContent]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedBy.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedBy])) this.strCreatedBy = Convert.ToString(reader[C_CreatedBy]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(reader[C_CreatedAt]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_ScheduleBackupDetail", objEx);
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
				if (!Convert.IsDBNull(drw[C_BackupDetailID])) this.lngBackupDetailID = Convert.ToInt64(drw[C_BackupDetailID]);
				if (!Convert.IsDBNull(drw[C_BackupID])) this.lngBackupID = Convert.ToInt64(drw[C_BackupID]);
				if (!Convert.IsDBNull(drw[C_Day])) this.intDay = Convert.ToInt32(drw[C_Day]);
				if (!Convert.IsDBNull(drw[C_Date])) this.dtmDate = Convert.ToDateTime(drw[C_Date]);
				if (!Convert.IsDBNull(drw[C_Week])) this.intWeek = Convert.ToInt32(drw[C_Week]);
				if (!Convert.IsDBNull(drw[C_LessionTime])) this.intLessionTime = Convert.ToInt32(drw[C_LessionTime]);
				if (!Convert.IsDBNull(drw[C_ClassSubjectID])) this.lngClassSubjectID = Convert.ToInt64(drw[C_ClassSubjectID]);
				if (!Convert.IsDBNull(drw[C_ClassID])) this.strClassID = Convert.ToString(drw[C_ClassID]);
				if (!Convert.IsDBNull(drw[C_SubjectID])) this.strSubjectID = Convert.ToString(drw[C_SubjectID]);
				if (!Convert.IsDBNull(drw[C_YearID])) this.intYearID = Convert.ToInt32(drw[C_YearID]);
				if (!Convert.IsDBNull(drw[C_Semester])) this.intSemester = Convert.ToInt32(drw[C_Semester]);
				if (!Convert.IsDBNull(drw[C_TeacherID])) this.strTeacherID = Convert.ToString(drw[C_TeacherID]);
				if (!Convert.IsDBNull(drw[C_RoomID])) this.strRoomID = Convert.ToString(drw[C_RoomID]);
				if (!Convert.IsDBNull(drw[C_IsPractice])) this.bolIsPractice = Convert.ToBoolean(drw[C_IsPractice]);
				if (!Convert.IsDBNull(drw[C_Done])) this.bolDone = Convert.ToBoolean(drw[C_Done]);
				if (!Convert.IsDBNull(drw[C_LearningSession])) this.intLearningSession = Convert.ToInt32(drw[C_LearningSession]);
				if (!Convert.IsDBNull(drw[C_IsTemplate])) this.bolIsTemplate = Convert.ToBoolean(drw[C_IsTemplate]);
				if (!Convert.IsDBNull(drw[C_AddLession])) this.intAddLession = Convert.ToInt32(drw[C_AddLession]);
				if (!Convert.IsDBNull(drw[C_IsReplace])) this.bolIsReplace = Convert.ToBoolean(drw[C_IsReplace]);
				if (!Convert.IsDBNull(drw[C_ScheduleContent])) this.strScheduleContent = Convert.ToString(drw[C_ScheduleContent]);
				if (!Convert.IsDBNull(drw[C_CreatedBy])) this.strCreatedBy = Convert.ToString(drw[C_CreatedBy]);
				if (!Convert.IsDBNull(drw[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(drw[C_CreatedAt]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_ScheduleBackupDetail", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_ScheduleBackupDetail_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ScheduleBackupDetail_GET");
				objIData.AddParameter(P_BackupDetailID, this.lngBackupDetailID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_ScheduleBackupDetail", objEx);
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
		/// Store: SIM_ScheduleBackupDetail_GET 
		///</summary>
		/// <returns> SIM_ScheduleBackupDetail </returns>
		public SIM_ScheduleBackupDetail Get(long? lngBackupDetailID)
		{
			SIM_ScheduleBackupDetail obj = new SIM_ScheduleBackupDetail();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.BackupDetailID = lngBackupDetailID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_ScheduleBackupDetail
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_ScheduleBackupDetail", objEx);
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
		/// Search : SIM_ScheduleBackupDetail
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_ScheduleBackupDetail", objEx);
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
		/// Search : SIM_ScheduleBackupDetail
		/// Lấy hết dữ liệu
		/// Store: SIM_ScheduleBackupDetail_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_ScheduleBackupDetail_GETALL");
		}

		///<summary>
		/// Search : SIM_ScheduleBackupDetail
		/// Tìm dữ liệu
		/// Store: SIM_ScheduleBackupDetail_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_ScheduleBackupDetail_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_ScheduleBackupDetail
		/// Thêm dữ liệu
		/// Store: SIM_ScheduleBackupDetail_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ScheduleBackupDetail_ADD");
				objIData.AddParameter(P_BackupID, this.lngBackupID);
				objIData.AddParameter(P_Day, this.intDay);
				objIData.AddParameter(P_Date, this.dtmDate);
				objIData.AddParameter(P_Week, this.intWeek);
				objIData.AddParameter(P_LessionTime, this.intLessionTime);
				objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
				objIData.AddParameter(P_ClassID, this.strClassID);
				objIData.AddParameter(P_SubjectID, this.strSubjectID);
				objIData.AddParameter(P_YearID, this.intYearID);
				objIData.AddParameter(P_Semester, this.intSemester);
				objIData.AddParameter(P_TeacherID, this.strTeacherID);
				objIData.AddParameter(P_RoomID, this.strRoomID);
				objIData.AddParameter(P_IsPractice, this.bolIsPractice);
				objIData.AddParameter(P_Done, this.bolDone);
				objIData.AddParameter(P_LearningSession, this.intLearningSession);
				objIData.AddParameter(P_IsTemplate, this.bolIsTemplate);
				objIData.AddParameter(P_AddLession, this.intAddLession);
				objIData.AddParameter(P_IsReplace, this.bolIsReplace);
				objIData.AddParameter(P_ScheduleContent, this.strScheduleContent);
				objIData.AddParameter(P_CreatedBy, this.strCreatedBy);
				objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
				this.lngBackupDetailID = Convert.ToInt32(objIData.ExecStoreToString());
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_ScheduleBackupDetail", objEx);
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
		/// Update : SIM_ScheduleBackupDetail
		/// Cập nhật dữ liệu
		/// Store: SIM_ScheduleBackupDetail_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ScheduleBackupDetail_EDIT");
				objIData.AddParameter(P_BackupDetailID, this.lngBackupDetailID);
				objIData.AddParameter(P_BackupID, this.lngBackupID);
				objIData.AddParameter(P_Day, this.intDay);
				objIData.AddParameter(P_Date, this.dtmDate);
				objIData.AddParameter(P_Week, this.intWeek);
				objIData.AddParameter(P_LessionTime, this.intLessionTime);
				objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
				objIData.AddParameter(P_ClassID, this.strClassID);
				objIData.AddParameter(P_SubjectID, this.strSubjectID);
				objIData.AddParameter(P_YearID, this.intYearID);
				objIData.AddParameter(P_Semester, this.intSemester);
				objIData.AddParameter(P_TeacherID, this.strTeacherID);
				objIData.AddParameter(P_RoomID, this.strRoomID);
				objIData.AddParameter(P_IsPractice, this.bolIsPractice);
				objIData.AddParameter(P_Done, this.bolDone);
				objIData.AddParameter(P_LearningSession, this.intLearningSession);
				objIData.AddParameter(P_IsTemplate, this.bolIsTemplate);
				objIData.AddParameter(P_AddLession, this.intAddLession);
				objIData.AddParameter(P_IsReplace, this.bolIsReplace);
				objIData.AddParameter(P_ScheduleContent, this.strScheduleContent);
				objIData.AddParameter(P_CreatedBy, this.strCreatedBy);
				objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_ScheduleBackupDetail", objEx);
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
		/// Delete : SIM_ScheduleBackupDetail
		/// Xóa dữ liệu
		/// Store: SIM_ScheduleBackupDetail_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ScheduleBackupDetail_DELETE");
				objIData.AddParameter(P_BackupDetailID, this.lngBackupDetailID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_ScheduleBackupDetail", objEx);
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
		/// Store: SIM_ScheduleBackupDetail_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(long? lngBackupDetailID)
		{
			this.lngBackupDetailID = lngBackupDetailID;
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

		public SIM_ScheduleBackupDetail()
		{
		}
		public SIM_ScheduleBackupDetail(long? lngBackupDetailID)
		{
			this.lngBackupDetailID = lngBackupDetailID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_BackupDetailID = "@" + C_BackupDetailID;
		public const String P_BackupID = "@" + C_BackupID;
		public const String P_Day = "@" + C_Day;
		public const String P_Date = "@" + C_Date;
		public const String P_Week = "@" + C_Week;
		public const String P_LessionTime = "@" + C_LessionTime;
		public const String P_ClassSubjectID = "@" + C_ClassSubjectID;
		public const String P_ClassID = "@" + C_ClassID;
		public const String P_SubjectID = "@" + C_SubjectID;
		public const String P_YearID = "@" + C_YearID;
		public const String P_Semester = "@" + C_Semester;
		public const String P_TeacherID = "@" + C_TeacherID;
		public const String P_RoomID = "@" + C_RoomID;
		public const String P_IsPractice = "@" + C_IsPractice;
		public const String P_Done = "@" + C_Done;
		public const String P_LearningSession = "@" + C_LearningSession;
		public const String P_IsTemplate = "@" + C_IsTemplate;
		public const String P_AddLession = "@" + C_AddLession;
		public const String P_IsReplace = "@" + C_IsReplace;
		public const String P_ScheduleContent = "@" + C_ScheduleContent;
		public const String P_CreatedBy = "@" + C_CreatedBy;
		public const String P_CreatedAt = "@" + C_CreatedAt;

		#endregion //Parameter names

		#region Column Names

		public const String C_BackupDetailID = "BackupDetailID";
		public const String C_BackupID = "BackupID";
		public const String C_Day = "Day";
		public const String C_Date = "Date";
		public const String C_Week = "Week";
		public const String C_LessionTime = "LessionTime";
		public const String C_ClassSubjectID = "ClassSubjectID";
		public const String C_ClassID = "ClassID";
		public const String C_SubjectID = "SubjectID";
		public const String C_YearID = "YearID";
		public const String C_Semester = "Semester";
		public const String C_TeacherID = "TeacherID";
		public const String C_RoomID = "RoomID";
		public const String C_IsPractice = "IsPractice";
		public const String C_Done = "Done";
		public const String C_LearningSession = "LearningSession";
		public const String C_IsTemplate = "IsTemplate";
		public const String C_AddLession = "AddLession";
		public const String C_IsReplace = "IsReplace";
		public const String C_ScheduleContent = "ScheduleContent";
		public const String C_CreatedBy = "CreatedBy";
		public const String C_CreatedAt = "CreatedAt";

		#endregion //Column names

		#endregion Variable Static		
	}
}
