
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
	public partial class SIM_ClassSubjectReport
	{	
		#region Member Variables

		private long? lngClassSubjectID = null;//Mã môn học lớp (kể cả login cho tách ghép)
		private string strGeneralInfo = null;//Tình hình chung
		private string strTimeInfo = null;//Ý thức chấp hành nội quy, giờ giấc
		private string strSpecialInfo = null;//Trường hợp đặc biệt
		private string strTeachingTime = null;//Thời gian giảng dạy
		private string strTeachingContent = null;//Nội dung giảng dạy
		private string strTeacherSpecialInfo = null;//Trường hợp đặc biệt của GV
		private string strSuggest = null;//Ý kiến, đề nghị
		private string strStudentSpecialInfo = null;//Trường hợp đặc biệt của học sinh (Quản lý học sinh sinh viên cá biệt)
		private DateTime? dtmCreatedDate = null;//Ngày tạo
		private string strCreatedUser = null;//Người tạo
		private DateTime? dtmUpdatedDate = null;//Ngày cập nhật cuối
		private string strUpdatedUser = null;//Người cập nhật cuối
		private string strContentFile = null;//Tên tập tin giáo án cho từng buổi (chỉ chứa tên file)
		private bool bolIsReviewed1 = false;//Đã chấp nhận đăng ký dạy bù
		private DateTime? dtmReviewedDate1 = null;//Ngày duyệt đăng ký
		private string strReviewedUser1 = null;
		private string strReviewedComment1 = null;
		private bool bolIsReviewed = false;//Đã chấp nhận đăng ký dạy bù
		private DateTime? dtmReviewedDate = null;//Ngày duyệt đăng ký
		private string strReviewedUser = null;
		private string strReviewedComment = null;
		private IData objIData = null;
		private bool bolIsExistIData = false;
		private Exception objErrorException = null;

		#endregion

		#region Properties 

		/// <summary>
		/// ClassSubjectID
		/// Mã môn học lớp (kể cả login cho tách ghép)
		/// </summary>
		public long? ClassSubjectID
		{
			get { return  lngClassSubjectID; }
			set { lngClassSubjectID = value; }
		}
		/// <summary>
		/// GeneralInfo
		/// Tình hình chung
		/// </summary>
		public string GeneralInfo
		{
			get { return  strGeneralInfo; }
			set { strGeneralInfo = value; }
		}
		/// <summary>
		/// TimeInfo
		/// Ý thức chấp hành nội quy, giờ giấc
		/// </summary>
		public string TimeInfo
		{
			get { return  strTimeInfo; }
			set { strTimeInfo = value; }
		}
		/// <summary>
		/// SpecialInfo
		/// Trường hợp đặc biệt
		/// </summary>
		public string SpecialInfo
		{
			get { return  strSpecialInfo; }
			set { strSpecialInfo = value; }
		}
		/// <summary>
		/// TeachingTime
		/// Thời gian giảng dạy
		/// </summary>
		public string TeachingTime
		{
			get { return  strTeachingTime; }
			set { strTeachingTime = value; }
		}
		/// <summary>
		/// TeachingContent
		/// Nội dung giảng dạy
		/// </summary>
		public string TeachingContent
		{
			get { return  strTeachingContent; }
			set { strTeachingContent = value; }
		}
		/// <summary>
		/// TeacherSpecialInfo
		/// Trường hợp đặc biệt của GV
		/// </summary>
		public string TeacherSpecialInfo
		{
			get { return  strTeacherSpecialInfo; }
			set { strTeacherSpecialInfo = value; }
		}
		/// <summary>
		/// Suggest
		/// Ý kiến, đề nghị
		/// </summary>
		public string Suggest
		{
			get { return  strSuggest; }
			set { strSuggest = value; }
		}
		/// <summary>
		/// StudentSpecialInfo
		/// Trường hợp đặc biệt của học sinh (Quản lý học sinh sinh viên cá biệt)
		/// </summary>
		public string StudentSpecialInfo
		{
			get { return  strStudentSpecialInfo; }
			set { strStudentSpecialInfo = value; }
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
		/// ContentFile
		/// Tên tập tin giáo án cho từng buổi (chỉ chứa tên file)
		/// </summary>
		public string ContentFile
		{
			get { return  strContentFile; }
			set { strContentFile = value; }
		}
		/// <summary>
		/// IsReviewed1
		/// Đã chấp nhận đăng ký dạy bù
		/// </summary>
		public bool IsReviewed1
		{
			get { return  bolIsReviewed1; }
			set { bolIsReviewed1 = value; }
		}
		/// <summary>
		/// ReviewedDate1
		/// Ngày duyệt đăng ký
		/// </summary>
		public DateTime? ReviewedDate1
		{
			get { return  dtmReviewedDate1; }
			set { dtmReviewedDate1 = value; }
		}
		/// <summary>
		/// ReviewedUser1
		/// 
		/// </summary>
		public string ReviewedUser1
		{
			get { return  strReviewedUser1; }
			set { strReviewedUser1 = value; }
		}
		/// <summary>
		/// ReviewedComment1
		/// 
		/// </summary>
		public string ReviewedComment1
		{
			get { return  strReviewedComment1; }
			set { strReviewedComment1 = value; }
		}
		/// <summary>
		/// IsReviewed
		/// Đã chấp nhận đăng ký dạy bù
		/// </summary>
		public bool IsReviewed
		{
			get { return  bolIsReviewed; }
			set { bolIsReviewed = value; }
		}
		/// <summary>
		/// ReviewedDate
		/// Ngày duyệt đăng ký
		/// </summary>
		public DateTime? ReviewedDate
		{
			get { return  dtmReviewedDate; }
			set { dtmReviewedDate = value; }
		}
		/// <summary>
		/// ReviewedUser
		/// 
		/// </summary>
		public string ReviewedUser
		{
			get { return  strReviewedUser; }
			set { strReviewedUser = value; }
		}
		/// <summary>
		/// ReviewedComment
		/// 
		/// </summary>
		public string ReviewedComment
		{
			get { return  strReviewedComment; }
			set { strReviewedComment = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_ClassSubjectID.ToUpper()) && !Convert.IsDBNull(reader[C_ClassSubjectID])) this.lngClassSubjectID = Convert.ToInt64(reader[C_ClassSubjectID]);
					if (reader.GetName(i).ToUpper().Equals(C_GeneralInfo.ToUpper()) && !Convert.IsDBNull(reader[C_GeneralInfo])) this.strGeneralInfo = Convert.ToString(reader[C_GeneralInfo]);
					if (reader.GetName(i).ToUpper().Equals(C_TimeInfo.ToUpper()) && !Convert.IsDBNull(reader[C_TimeInfo])) this.strTimeInfo = Convert.ToString(reader[C_TimeInfo]);
					if (reader.GetName(i).ToUpper().Equals(C_SpecialInfo.ToUpper()) && !Convert.IsDBNull(reader[C_SpecialInfo])) this.strSpecialInfo = Convert.ToString(reader[C_SpecialInfo]);
					if (reader.GetName(i).ToUpper().Equals(C_TeachingTime.ToUpper()) && !Convert.IsDBNull(reader[C_TeachingTime])) this.strTeachingTime = Convert.ToString(reader[C_TeachingTime]);
					if (reader.GetName(i).ToUpper().Equals(C_TeachingContent.ToUpper()) && !Convert.IsDBNull(reader[C_TeachingContent])) this.strTeachingContent = Convert.ToString(reader[C_TeachingContent]);
					if (reader.GetName(i).ToUpper().Equals(C_TeacherSpecialInfo.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherSpecialInfo])) this.strTeacherSpecialInfo = Convert.ToString(reader[C_TeacherSpecialInfo]);
					if (reader.GetName(i).ToUpper().Equals(C_Suggest.ToUpper()) && !Convert.IsDBNull(reader[C_Suggest])) this.strSuggest = Convert.ToString(reader[C_Suggest]);
					if (reader.GetName(i).ToUpper().Equals(C_StudentSpecialInfo.ToUpper()) && !Convert.IsDBNull(reader[C_StudentSpecialInfo])) this.strStudentSpecialInfo = Convert.ToString(reader[C_StudentSpecialInfo]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(reader[C_UpdatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(reader[C_UpdatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_ContentFile.ToUpper()) && !Convert.IsDBNull(reader[C_ContentFile])) this.strContentFile = Convert.ToString(reader[C_ContentFile]);
					if (reader.GetName(i).ToUpper().Equals(C_IsReviewed1.ToUpper()) && !Convert.IsDBNull(reader[C_IsReviewed1])) this.bolIsReviewed1 = Convert.ToBoolean(reader[C_IsReviewed1]);
					if (reader.GetName(i).ToUpper().Equals(C_ReviewedDate1.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewedDate1])) this.dtmReviewedDate1 = Convert.ToDateTime(reader[C_ReviewedDate1]);
					if (reader.GetName(i).ToUpper().Equals(C_ReviewedUser1.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewedUser1])) this.strReviewedUser1 = Convert.ToString(reader[C_ReviewedUser1]);
					if (reader.GetName(i).ToUpper().Equals(C_ReviewedComment1.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewedComment1])) this.strReviewedComment1 = Convert.ToString(reader[C_ReviewedComment1]);
					if (reader.GetName(i).ToUpper().Equals(C_IsReviewed.ToUpper()) && !Convert.IsDBNull(reader[C_IsReviewed])) this.bolIsReviewed = Convert.ToBoolean(reader[C_IsReviewed]);
					if (reader.GetName(i).ToUpper().Equals(C_ReviewedDate.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewedDate])) this.dtmReviewedDate = Convert.ToDateTime(reader[C_ReviewedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_ReviewedUser.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewedUser])) this.strReviewedUser = Convert.ToString(reader[C_ReviewedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_ReviewedComment.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewedComment])) this.strReviewedComment = Convert.ToString(reader[C_ReviewedComment]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_ClassSubjectReport", objEx);
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
				if (!Convert.IsDBNull(drw[C_ClassSubjectID])) this.lngClassSubjectID = Convert.ToInt64(drw[C_ClassSubjectID]);
				if (!Convert.IsDBNull(drw[C_GeneralInfo])) this.strGeneralInfo = Convert.ToString(drw[C_GeneralInfo]);
				if (!Convert.IsDBNull(drw[C_TimeInfo])) this.strTimeInfo = Convert.ToString(drw[C_TimeInfo]);
				if (!Convert.IsDBNull(drw[C_SpecialInfo])) this.strSpecialInfo = Convert.ToString(drw[C_SpecialInfo]);
				if (!Convert.IsDBNull(drw[C_TeachingTime])) this.strTeachingTime = Convert.ToString(drw[C_TeachingTime]);
				if (!Convert.IsDBNull(drw[C_TeachingContent])) this.strTeachingContent = Convert.ToString(drw[C_TeachingContent]);
				if (!Convert.IsDBNull(drw[C_TeacherSpecialInfo])) this.strTeacherSpecialInfo = Convert.ToString(drw[C_TeacherSpecialInfo]);
				if (!Convert.IsDBNull(drw[C_Suggest])) this.strSuggest = Convert.ToString(drw[C_Suggest]);
				if (!Convert.IsDBNull(drw[C_StudentSpecialInfo])) this.strStudentSpecialInfo = Convert.ToString(drw[C_StudentSpecialInfo]);
				if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
				if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
				if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
				if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
				if (!Convert.IsDBNull(drw[C_ContentFile])) this.strContentFile = Convert.ToString(drw[C_ContentFile]);
				if (!Convert.IsDBNull(drw[C_IsReviewed1])) this.bolIsReviewed1 = Convert.ToBoolean(drw[C_IsReviewed1]);
				if (!Convert.IsDBNull(drw[C_ReviewedDate1])) this.dtmReviewedDate1 = Convert.ToDateTime(drw[C_ReviewedDate1]);
				if (!Convert.IsDBNull(drw[C_ReviewedUser1])) this.strReviewedUser1 = Convert.ToString(drw[C_ReviewedUser1]);
				if (!Convert.IsDBNull(drw[C_ReviewedComment1])) this.strReviewedComment1 = Convert.ToString(drw[C_ReviewedComment1]);
				if (!Convert.IsDBNull(drw[C_IsReviewed])) this.bolIsReviewed = Convert.ToBoolean(drw[C_IsReviewed]);
				if (!Convert.IsDBNull(drw[C_ReviewedDate])) this.dtmReviewedDate = Convert.ToDateTime(drw[C_ReviewedDate]);
				if (!Convert.IsDBNull(drw[C_ReviewedUser])) this.strReviewedUser = Convert.ToString(drw[C_ReviewedUser]);
				if (!Convert.IsDBNull(drw[C_ReviewedComment])) this.strReviewedComment = Convert.ToString(drw[C_ReviewedComment]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_ClassSubjectReport", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_ClassSubjectReport_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ClassSubjectReport_GET");
				objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_ClassSubjectReport", objEx);
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
		/// Store: SIM_ClassSubjectReport_GET 
		///</summary>
		/// <returns> SIM_ClassSubjectReport </returns>
		public SIM_ClassSubjectReport Get(long? lngClassSubjectID)
		{
			SIM_ClassSubjectReport obj = new SIM_ClassSubjectReport();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.ClassSubjectID = lngClassSubjectID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_ClassSubjectReport
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_ClassSubjectReport", objEx);
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
		/// Search : SIM_ClassSubjectReport
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_ClassSubjectReport", objEx);
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
		/// Search : SIM_ClassSubjectReport
		/// Lấy hết dữ liệu
		/// Store: SIM_ClassSubjectReport_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_ClassSubjectReport_GETALL");
		}

		///<summary>
		/// Search : SIM_ClassSubjectReport
		/// Tìm dữ liệu
		/// Store: SIM_ClassSubjectReport_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_ClassSubjectReport_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_ClassSubjectReport
		/// Thêm dữ liệu
		/// Store: SIM_ClassSubjectReport_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ClassSubjectReport_ADD");
				objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
				objIData.AddParameter(P_GeneralInfo, this.strGeneralInfo);
				objIData.AddParameter(P_TimeInfo, this.strTimeInfo);
				objIData.AddParameter(P_SpecialInfo, this.strSpecialInfo);
				objIData.AddParameter(P_TeachingTime, this.strTeachingTime);
				objIData.AddParameter(P_TeachingContent, this.strTeachingContent);
				objIData.AddParameter(P_TeacherSpecialInfo, this.strTeacherSpecialInfo);
				objIData.AddParameter(P_Suggest, this.strSuggest);
				objIData.AddParameter(P_StudentSpecialInfo, this.strStudentSpecialInfo);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				objIData.AddParameter(P_ContentFile, this.strContentFile);
				objIData.AddParameter(P_IsReviewed1, this.bolIsReviewed1);
				objIData.AddParameter(P_ReviewedDate1, this.dtmReviewedDate1);
				objIData.AddParameter(P_ReviewedUser1, this.strReviewedUser1);
				objIData.AddParameter(P_ReviewedComment1, this.strReviewedComment1);
				objIData.AddParameter(P_IsReviewed, this.bolIsReviewed);
				objIData.AddParameter(P_ReviewedDate, this.dtmReviewedDate);
				objIData.AddParameter(P_ReviewedUser, this.strReviewedUser);
				objIData.AddParameter(P_ReviewedComment, this.strReviewedComment);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_ClassSubjectReport", objEx);
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
		/// Update : SIM_ClassSubjectReport
		/// Cập nhật dữ liệu
		/// Store: SIM_ClassSubjectReport_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ClassSubjectReport_EDIT");
				objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
				objIData.AddParameter(P_GeneralInfo, this.strGeneralInfo);
				objIData.AddParameter(P_TimeInfo, this.strTimeInfo);
				objIData.AddParameter(P_SpecialInfo, this.strSpecialInfo);
				objIData.AddParameter(P_TeachingTime, this.strTeachingTime);
				objIData.AddParameter(P_TeachingContent, this.strTeachingContent);
				objIData.AddParameter(P_TeacherSpecialInfo, this.strTeacherSpecialInfo);
				objIData.AddParameter(P_Suggest, this.strSuggest);
				objIData.AddParameter(P_StudentSpecialInfo, this.strStudentSpecialInfo);
				objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
				objIData.AddParameter(P_ContentFile, this.strContentFile);
				objIData.AddParameter(P_IsReviewed1, this.bolIsReviewed1);
				objIData.AddParameter(P_ReviewedDate1, this.dtmReviewedDate1);
				objIData.AddParameter(P_ReviewedUser1, this.strReviewedUser1);
				objIData.AddParameter(P_ReviewedComment1, this.strReviewedComment1);
				objIData.AddParameter(P_IsReviewed, this.bolIsReviewed);
				objIData.AddParameter(P_ReviewedDate, this.dtmReviewedDate);
				objIData.AddParameter(P_ReviewedUser, this.strReviewedUser);
				objIData.AddParameter(P_ReviewedComment, this.strReviewedComment);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_ClassSubjectReport", objEx);
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
		/// Delete : SIM_ClassSubjectReport
		/// Xóa dữ liệu
		/// Store: SIM_ClassSubjectReport_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ClassSubjectReport_DELETE");
				objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_ClassSubjectReport", objEx);
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
		/// Store: SIM_ClassSubjectReport_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(long? lngClassSubjectID)
		{
			this.lngClassSubjectID = lngClassSubjectID;
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

		public SIM_ClassSubjectReport()
		{
		}
		public SIM_ClassSubjectReport(long? lngClassSubjectID)
		{
			this.lngClassSubjectID = lngClassSubjectID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_ClassSubjectID = "@" + C_ClassSubjectID;
		public const String P_GeneralInfo = "@" + C_GeneralInfo;
		public const String P_TimeInfo = "@" + C_TimeInfo;
		public const String P_SpecialInfo = "@" + C_SpecialInfo;
		public const String P_TeachingTime = "@" + C_TeachingTime;
		public const String P_TeachingContent = "@" + C_TeachingContent;
		public const String P_TeacherSpecialInfo = "@" + C_TeacherSpecialInfo;
		public const String P_Suggest = "@" + C_Suggest;
		public const String P_StudentSpecialInfo = "@" + C_StudentSpecialInfo;
		public const String P_CreatedDate = "@" + C_CreatedDate;
		public const String P_CreatedUser = "@" + C_CreatedUser;
		public const String P_UpdatedDate = "@" + C_UpdatedDate;
		public const String P_UpdatedUser = "@" + C_UpdatedUser;
		public const String P_ContentFile = "@" + C_ContentFile;
		public const String P_IsReviewed1 = "@" + C_IsReviewed1;
		public const String P_ReviewedDate1 = "@" + C_ReviewedDate1;
		public const String P_ReviewedUser1 = "@" + C_ReviewedUser1;
		public const String P_ReviewedComment1 = "@" + C_ReviewedComment1;
		public const String P_IsReviewed = "@" + C_IsReviewed;
		public const String P_ReviewedDate = "@" + C_ReviewedDate;
		public const String P_ReviewedUser = "@" + C_ReviewedUser;
		public const String P_ReviewedComment = "@" + C_ReviewedComment;

		#endregion //Parameter names

		#region Column Names

		public const String C_ClassSubjectID = "ClassSubjectID";
		public const String C_GeneralInfo = "GeneralInfo";
		public const String C_TimeInfo = "TimeInfo";
		public const String C_SpecialInfo = "SpecialInfo";
		public const String C_TeachingTime = "TeachingTime";
		public const String C_TeachingContent = "TeachingContent";
		public const String C_TeacherSpecialInfo = "TeacherSpecialInfo";
		public const String C_Suggest = "Suggest";
		public const String C_StudentSpecialInfo = "StudentSpecialInfo";
		public const String C_CreatedDate = "CreatedDate";
		public const String C_CreatedUser = "CreatedUser";
		public const String C_UpdatedDate = "UpdatedDate";
		public const String C_UpdatedUser = "UpdatedUser";
		public const String C_ContentFile = "ContentFile";
		public const String C_IsReviewed1 = "IsReviewed1";
		public const String C_ReviewedDate1 = "ReviewedDate1";
		public const String C_ReviewedUser1 = "ReviewedUser1";
		public const String C_ReviewedComment1 = "ReviewedComment1";
		public const String C_IsReviewed = "IsReviewed";
		public const String C_ReviewedDate = "ReviewedDate";
		public const String C_ReviewedUser = "ReviewedUser";
		public const String C_ReviewedComment = "ReviewedComment";

		#endregion //Column names

		#endregion Variable Static		
	}
}
