
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
	public partial class SIM_ScheduleChecking
	{	
		#region Member Variables

		private long? lngScheduleCheckingID = null;//Mã kiểm tra lịch học
		private long? lngClassSubjectID = null;//Mã môn học lớp
		private DateTime? dtmDate = null;//Ngày dạy
		private int? intSession = null;//Buổi học (0. Sáng, 1. Chiều, 2. Tối)
		private decimal? decTheoryQuantity = null;//Số tiết lý thuyết
		private decimal? decPracticeQuantity = null;//Số tiết thực hành
		private decimal? decTestQuantity = null;//Số giờ kiểm tra
		private string strTeacherID = null;//Mã giáo viên dạy
		private string strLearningContent = null;//Tóm tắt nội dung bài dạy, kiểm tra
		private string strRequestContent = null;//Nội dung yêu cầu (ví dụ trang bị cơ sở vật chất)
		private int? intOffStudentCount = null;//Số học sinh vắng (xử lý lưu luôn khi điểm danh)
		private string strContentFile = null;//Tên tập tin giáo án cho từng buổi (chỉ chứa tên file)
		private string strDescription = null;//Ghi chú
		private DateTime? dtmCreatedDate = null;//Ngày tạo
		private string strCreatedUser = null;//Người tạo
		private DateTime? dtmUpdatedDate = null;//Ngày cập nhật cuối
		private string strUpdatedUser = null;//Người cập nhật cuối
		private bool? bolIsReviewed = null;//Duyệt nội dung tập tin
		private string strReviewComment = null;
		private string strReviewUser = null;
		private string strRoomID = null;//Phòng
		private int? intWeek = null;//Tuần
		private bool? bolIsReviewed1 = null;//Đã chấp nhận đăng ký dạy bù
		private DateTime? dtmReviewDate1 = null;//Ngày duyệt đăng ký
		private string strReviewUser1 = null;
		private string strReviewComment1 = null;
		private bool? bolIsReviewed2 = null;//Đã chấp nhận đăng ký dạy bù
		private DateTime? dtmReviewDate2 = null;//Ngày duyệt đăng ký
		private string strReviewUser2 = null;
		private string strReviewComment2 = null;
		private DateTime? dtmReviewDate = null;//Ngày duyệt đăng ký
		private bool bolIsTeachingSchedule = false;//Là dữ liệu Lịch trình giảng dạy (giống như kế hoạch ban đầu khi vừa có tkb là gv fai lên kế hoạch này, lưu lại ko sửa khi dạy)
		private string strOffStudentList = null;//Danh sách tên học sinh vắng (xử lý lưu luôn khi điểm danh)
		private string strRating = null;//Đánh giá buổi học (A,B,C,D)
		private IData objIData = null;
		private bool bolIsExistIData = false;
		private Exception objErrorException = null;

		#endregion

		#region Properties 

		/// <summary>
		/// ScheduleCheckingID
		/// Mã kiểm tra lịch học
		/// </summary>
		public long? ScheduleCheckingID
		{
			get { return  lngScheduleCheckingID; }
			set { lngScheduleCheckingID = value; }
		}
		/// <summary>
		/// ClassSubjectID
		/// Mã môn học lớp
		/// </summary>
		public long? ClassSubjectID
		{
			get { return  lngClassSubjectID; }
			set { lngClassSubjectID = value; }
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
		/// Session
		/// Buổi học (0. Sáng, 1. Chiều, 2. Tối)
		/// </summary>
		public int? Session
		{
			get { return  intSession; }
			set { intSession = value; }
		}
		/// <summary>
		/// TheoryQuantity
		/// Số tiết lý thuyết
		/// </summary>
		public decimal? TheoryQuantity
		{
			get { return  decTheoryQuantity; }
			set { decTheoryQuantity = value; }
		}
		/// <summary>
		/// PracticeQuantity
		/// Số tiết thực hành
		/// </summary>
		public decimal? PracticeQuantity
		{
			get { return  decPracticeQuantity; }
			set { decPracticeQuantity = value; }
		}
		/// <summary>
		/// TestQuantity
		/// Số giờ kiểm tra
		/// </summary>
		public decimal? TestQuantity
		{
			get { return  decTestQuantity; }
			set { decTestQuantity = value; }
		}
		/// <summary>
		/// TeacherID
		/// Mã giáo viên dạy
		/// </summary>
		public string TeacherID
		{
			get { return  strTeacherID; }
			set { strTeacherID = value; }
		}
		/// <summary>
		/// LearningContent
		/// Tóm tắt nội dung bài dạy, kiểm tra
		/// </summary>
		public string LearningContent
		{
			get { return  strLearningContent; }
			set { strLearningContent = value; }
		}
		/// <summary>
		/// RequestContent
		/// Nội dung yêu cầu (ví dụ trang bị cơ sở vật chất)
		/// </summary>
		public string RequestContent
		{
			get { return  strRequestContent; }
			set { strRequestContent = value; }
		}
		/// <summary>
		/// OffStudentCount
		/// Số học sinh vắng (xử lý lưu luôn khi điểm danh)
		/// </summary>
		public int? OffStudentCount
		{
			get { return  intOffStudentCount; }
			set { intOffStudentCount = value; }
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
		/// IsReviewed
		/// Duyệt nội dung tập tin
		/// </summary>
		public bool? IsReviewed
		{
			get { return  bolIsReviewed; }
			set { bolIsReviewed = value; }
		}
		/// <summary>
		/// ReviewComment
		/// 
		/// </summary>
		public string ReviewComment
		{
			get { return  strReviewComment; }
			set { strReviewComment = value; }
		}
		/// <summary>
		/// ReviewUser
		/// 
		/// </summary>
		public string ReviewUser
		{
			get { return  strReviewUser; }
			set { strReviewUser = value; }
		}
		/// <summary>
		/// RoomID
		/// Phòng
		/// </summary>
		public string RoomID
		{
			get { return  strRoomID; }
			set { strRoomID = value; }
		}
		/// <summary>
		/// Week
		/// Tuần
		/// </summary>
		public int? Week
		{
			get { return  intWeek; }
			set { intWeek = value; }
		}
		/// <summary>
		/// IsReviewed1
		/// Đã chấp nhận đăng ký dạy bù
		/// </summary>
		public bool? IsReviewed1
		{
			get { return  bolIsReviewed1; }
			set { bolIsReviewed1 = value; }
		}
		/// <summary>
		/// ReviewDate1
		/// Ngày duyệt đăng ký
		/// </summary>
		public DateTime? ReviewDate1
		{
			get { return  dtmReviewDate1; }
			set { dtmReviewDate1 = value; }
		}
		/// <summary>
		/// ReviewUser1
		/// 
		/// </summary>
		public string ReviewUser1
		{
			get { return  strReviewUser1; }
			set { strReviewUser1 = value; }
		}
		/// <summary>
		/// ReviewComment1
		/// 
		/// </summary>
		public string ReviewComment1
		{
			get { return  strReviewComment1; }
			set { strReviewComment1 = value; }
		}
		/// <summary>
		/// IsReviewed2
		/// Đã chấp nhận đăng ký dạy bù
		/// </summary>
		public bool? IsReviewed2
		{
			get { return  bolIsReviewed2; }
			set { bolIsReviewed2 = value; }
		}
		/// <summary>
		/// ReviewDate2
		/// Ngày duyệt đăng ký
		/// </summary>
		public DateTime? ReviewDate2
		{
			get { return  dtmReviewDate2; }
			set { dtmReviewDate2 = value; }
		}
		/// <summary>
		/// ReviewUser2
		/// 
		/// </summary>
		public string ReviewUser2
		{
			get { return  strReviewUser2; }
			set { strReviewUser2 = value; }
		}
		/// <summary>
		/// ReviewComment2
		/// 
		/// </summary>
		public string ReviewComment2
		{
			get { return  strReviewComment2; }
			set { strReviewComment2 = value; }
		}
		/// <summary>
		/// ReviewDate
		/// Ngày duyệt đăng ký
		/// </summary>
		public DateTime? ReviewDate
		{
			get { return  dtmReviewDate; }
			set { dtmReviewDate = value; }
		}
		/// <summary>
		/// IsTeachingSchedule
		/// Là dữ liệu Lịch trình giảng dạy (giống như kế hoạch ban đầu khi vừa có tkb là gv fai lên kế hoạch này, lưu lại ko sửa khi dạy)
		/// </summary>
		public bool IsTeachingSchedule
		{
			get { return  bolIsTeachingSchedule; }
			set { bolIsTeachingSchedule = value; }
		}
		/// <summary>
		/// OffStudentList
		/// Danh sách tên học sinh vắng (xử lý lưu luôn khi điểm danh)
		/// </summary>
		public string OffStudentList
		{
			get { return  strOffStudentList; }
			set { strOffStudentList = value; }
		}
		/// <summary>
		/// Rating
		/// Đánh giá buổi học (A,B,C,D)
		/// </summary>
		public string Rating
		{
			get { return  strRating; }
			set { strRating = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_ScheduleCheckingID.ToUpper()) && !Convert.IsDBNull(reader[C_ScheduleCheckingID])) this.lngScheduleCheckingID = Convert.ToInt64(reader[C_ScheduleCheckingID]);
					if (reader.GetName(i).ToUpper().Equals(C_ClassSubjectID.ToUpper()) && !Convert.IsDBNull(reader[C_ClassSubjectID])) this.lngClassSubjectID = Convert.ToInt64(reader[C_ClassSubjectID]);
					if (reader.GetName(i).ToUpper().Equals(C_Date.ToUpper()) && !Convert.IsDBNull(reader[C_Date])) this.dtmDate = Convert.ToDateTime(reader[C_Date]);
					if (reader.GetName(i).ToUpper().Equals(C_Session.ToUpper()) && !Convert.IsDBNull(reader[C_Session])) this.intSession = Convert.ToInt32(reader[C_Session]);
					if (reader.GetName(i).ToUpper().Equals(C_TheoryQuantity.ToUpper()) && !Convert.IsDBNull(reader[C_TheoryQuantity])) this.decTheoryQuantity = Convert.ToDecimal(reader[C_TheoryQuantity]);
					if (reader.GetName(i).ToUpper().Equals(C_PracticeQuantity.ToUpper()) && !Convert.IsDBNull(reader[C_PracticeQuantity])) this.decPracticeQuantity = Convert.ToDecimal(reader[C_PracticeQuantity]);
					if (reader.GetName(i).ToUpper().Equals(C_TestQuantity.ToUpper()) && !Convert.IsDBNull(reader[C_TestQuantity])) this.decTestQuantity = Convert.ToDecimal(reader[C_TestQuantity]);
					if (reader.GetName(i).ToUpper().Equals(C_TeacherID.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherID])) this.strTeacherID = Convert.ToString(reader[C_TeacherID]);
					if (reader.GetName(i).ToUpper().Equals(C_LearningContent.ToUpper()) && !Convert.IsDBNull(reader[C_LearningContent])) this.strLearningContent = Convert.ToString(reader[C_LearningContent]);
					if (reader.GetName(i).ToUpper().Equals(C_RequestContent.ToUpper()) && !Convert.IsDBNull(reader[C_RequestContent])) this.strRequestContent = Convert.ToString(reader[C_RequestContent]);
					if (reader.GetName(i).ToUpper().Equals(C_OffStudentCount.ToUpper()) && !Convert.IsDBNull(reader[C_OffStudentCount])) this.intOffStudentCount = Convert.ToInt32(reader[C_OffStudentCount]);
					if (reader.GetName(i).ToUpper().Equals(C_ContentFile.ToUpper()) && !Convert.IsDBNull(reader[C_ContentFile])) this.strContentFile = Convert.ToString(reader[C_ContentFile]);
					if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(reader[C_UpdatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(reader[C_UpdatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_IsReviewed.ToUpper()) && !Convert.IsDBNull(reader[C_IsReviewed])) this.bolIsReviewed = Convert.ToBoolean(reader[C_IsReviewed]);
					if (reader.GetName(i).ToUpper().Equals(C_ReviewComment.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewComment])) this.strReviewComment = Convert.ToString(reader[C_ReviewComment]);
					if (reader.GetName(i).ToUpper().Equals(C_ReviewUser.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewUser])) this.strReviewUser = Convert.ToString(reader[C_ReviewUser]);
					if (reader.GetName(i).ToUpper().Equals(C_RoomID.ToUpper()) && !Convert.IsDBNull(reader[C_RoomID])) this.strRoomID = Convert.ToString(reader[C_RoomID]);
					if (reader.GetName(i).ToUpper().Equals(C_Week.ToUpper()) && !Convert.IsDBNull(reader[C_Week])) this.intWeek = Convert.ToInt32(reader[C_Week]);
					if (reader.GetName(i).ToUpper().Equals(C_IsReviewed1.ToUpper()) && !Convert.IsDBNull(reader[C_IsReviewed1])) this.bolIsReviewed1 = Convert.ToBoolean(reader[C_IsReviewed1]);
					if (reader.GetName(i).ToUpper().Equals(C_ReviewDate1.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewDate1])) this.dtmReviewDate1 = Convert.ToDateTime(reader[C_ReviewDate1]);
					if (reader.GetName(i).ToUpper().Equals(C_ReviewUser1.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewUser1])) this.strReviewUser1 = Convert.ToString(reader[C_ReviewUser1]);
					if (reader.GetName(i).ToUpper().Equals(C_ReviewComment1.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewComment1])) this.strReviewComment1 = Convert.ToString(reader[C_ReviewComment1]);
					if (reader.GetName(i).ToUpper().Equals(C_IsReviewed2.ToUpper()) && !Convert.IsDBNull(reader[C_IsReviewed2])) this.bolIsReviewed2 = Convert.ToBoolean(reader[C_IsReviewed2]);
					if (reader.GetName(i).ToUpper().Equals(C_ReviewDate2.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewDate2])) this.dtmReviewDate2 = Convert.ToDateTime(reader[C_ReviewDate2]);
					if (reader.GetName(i).ToUpper().Equals(C_ReviewUser2.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewUser2])) this.strReviewUser2 = Convert.ToString(reader[C_ReviewUser2]);
					if (reader.GetName(i).ToUpper().Equals(C_ReviewComment2.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewComment2])) this.strReviewComment2 = Convert.ToString(reader[C_ReviewComment2]);
					if (reader.GetName(i).ToUpper().Equals(C_ReviewDate.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewDate])) this.dtmReviewDate = Convert.ToDateTime(reader[C_ReviewDate]);
					if (reader.GetName(i).ToUpper().Equals(C_IsTeachingSchedule.ToUpper()) && !Convert.IsDBNull(reader[C_IsTeachingSchedule])) this.bolIsTeachingSchedule = Convert.ToBoolean(reader[C_IsTeachingSchedule]);
					if (reader.GetName(i).ToUpper().Equals(C_OffStudentList.ToUpper()) && !Convert.IsDBNull(reader[C_OffStudentList])) this.strOffStudentList = Convert.ToString(reader[C_OffStudentList]);
					if (reader.GetName(i).ToUpper().Equals(C_Rating.ToUpper()) && !Convert.IsDBNull(reader[C_Rating])) this.strRating = Convert.ToString(reader[C_Rating]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_ScheduleChecking", objEx);
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
				if (!Convert.IsDBNull(drw[C_ScheduleCheckingID])) this.lngScheduleCheckingID = Convert.ToInt64(drw[C_ScheduleCheckingID]);
				if (!Convert.IsDBNull(drw[C_ClassSubjectID])) this.lngClassSubjectID = Convert.ToInt64(drw[C_ClassSubjectID]);
				if (!Convert.IsDBNull(drw[C_Date])) this.dtmDate = Convert.ToDateTime(drw[C_Date]);
				if (!Convert.IsDBNull(drw[C_Session])) this.intSession = Convert.ToInt32(drw[C_Session]);
				if (!Convert.IsDBNull(drw[C_TheoryQuantity])) this.decTheoryQuantity = Convert.ToDecimal(drw[C_TheoryQuantity]);
				if (!Convert.IsDBNull(drw[C_PracticeQuantity])) this.decPracticeQuantity = Convert.ToDecimal(drw[C_PracticeQuantity]);
				if (!Convert.IsDBNull(drw[C_TestQuantity])) this.decTestQuantity = Convert.ToDecimal(drw[C_TestQuantity]);
				if (!Convert.IsDBNull(drw[C_TeacherID])) this.strTeacherID = Convert.ToString(drw[C_TeacherID]);
				if (!Convert.IsDBNull(drw[C_LearningContent])) this.strLearningContent = Convert.ToString(drw[C_LearningContent]);
				if (!Convert.IsDBNull(drw[C_RequestContent])) this.strRequestContent = Convert.ToString(drw[C_RequestContent]);
				if (!Convert.IsDBNull(drw[C_OffStudentCount])) this.intOffStudentCount = Convert.ToInt32(drw[C_OffStudentCount]);
				if (!Convert.IsDBNull(drw[C_ContentFile])) this.strContentFile = Convert.ToString(drw[C_ContentFile]);
				if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
				if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
				if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
				if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
				if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
				if (!Convert.IsDBNull(drw[C_IsReviewed])) this.bolIsReviewed = Convert.ToBoolean(drw[C_IsReviewed]);
				if (!Convert.IsDBNull(drw[C_ReviewComment])) this.strReviewComment = Convert.ToString(drw[C_ReviewComment]);
				if (!Convert.IsDBNull(drw[C_ReviewUser])) this.strReviewUser = Convert.ToString(drw[C_ReviewUser]);
				if (!Convert.IsDBNull(drw[C_RoomID])) this.strRoomID = Convert.ToString(drw[C_RoomID]);
				if (!Convert.IsDBNull(drw[C_Week])) this.intWeek = Convert.ToInt32(drw[C_Week]);
				if (!Convert.IsDBNull(drw[C_IsReviewed1])) this.bolIsReviewed1 = Convert.ToBoolean(drw[C_IsReviewed1]);
				if (!Convert.IsDBNull(drw[C_ReviewDate1])) this.dtmReviewDate1 = Convert.ToDateTime(drw[C_ReviewDate1]);
				if (!Convert.IsDBNull(drw[C_ReviewUser1])) this.strReviewUser1 = Convert.ToString(drw[C_ReviewUser1]);
				if (!Convert.IsDBNull(drw[C_ReviewComment1])) this.strReviewComment1 = Convert.ToString(drw[C_ReviewComment1]);
				if (!Convert.IsDBNull(drw[C_IsReviewed2])) this.bolIsReviewed2 = Convert.ToBoolean(drw[C_IsReviewed2]);
				if (!Convert.IsDBNull(drw[C_ReviewDate2])) this.dtmReviewDate2 = Convert.ToDateTime(drw[C_ReviewDate2]);
				if (!Convert.IsDBNull(drw[C_ReviewUser2])) this.strReviewUser2 = Convert.ToString(drw[C_ReviewUser2]);
				if (!Convert.IsDBNull(drw[C_ReviewComment2])) this.strReviewComment2 = Convert.ToString(drw[C_ReviewComment2]);
				if (!Convert.IsDBNull(drw[C_ReviewDate])) this.dtmReviewDate = Convert.ToDateTime(drw[C_ReviewDate]);
				if (!Convert.IsDBNull(drw[C_IsTeachingSchedule])) this.bolIsTeachingSchedule = Convert.ToBoolean(drw[C_IsTeachingSchedule]);
				if (!Convert.IsDBNull(drw[C_OffStudentList])) this.strOffStudentList = Convert.ToString(drw[C_OffStudentList]);
				if (!Convert.IsDBNull(drw[C_Rating])) this.strRating = Convert.ToString(drw[C_Rating]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_ScheduleChecking", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_ScheduleChecking_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ScheduleChecking_GET");
				objIData.AddParameter(P_ScheduleCheckingID, this.lngScheduleCheckingID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_ScheduleChecking", objEx);
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
		/// Store: SIM_ScheduleChecking_GET 
		///</summary>
		/// <returns> SIM_ScheduleChecking </returns>
		public SIM_ScheduleChecking Get(long? lngScheduleCheckingID)
		{
			SIM_ScheduleChecking obj = new SIM_ScheduleChecking();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.ScheduleCheckingID = lngScheduleCheckingID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_ScheduleChecking
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_ScheduleChecking", objEx);
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
		/// Search : SIM_ScheduleChecking
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_ScheduleChecking", objEx);
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
		/// Search : SIM_ScheduleChecking
		/// Lấy hết dữ liệu
		/// Store: SIM_ScheduleChecking_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_ScheduleChecking_GETALL");
		}

		///<summary>
		/// Search : SIM_ScheduleChecking
		/// Tìm dữ liệu
		/// Store: SIM_ScheduleChecking_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_ScheduleChecking_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_ScheduleChecking
		/// Thêm dữ liệu
		/// Store: SIM_ScheduleChecking_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ScheduleChecking_ADD");
				objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
				objIData.AddParameter(P_Date, this.dtmDate);
				objIData.AddParameter(P_Session, this.intSession);
				objIData.AddParameter(P_TheoryQuantity, this.decTheoryQuantity);
				objIData.AddParameter(P_PracticeQuantity, this.decPracticeQuantity);
				objIData.AddParameter(P_TestQuantity, this.decTestQuantity);
				objIData.AddParameter(P_TeacherID, this.strTeacherID);
				objIData.AddParameter(P_LearningContent, this.strLearningContent);
				objIData.AddParameter(P_RequestContent, this.strRequestContent);
				objIData.AddParameter(P_OffStudentCount, this.intOffStudentCount);
				objIData.AddParameter(P_ContentFile, this.strContentFile);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				objIData.AddParameter(P_IsReviewed, this.bolIsReviewed);
				objIData.AddParameter(P_ReviewComment, this.strReviewComment);
				objIData.AddParameter(P_ReviewUser, this.strReviewUser);
				objIData.AddParameter(P_RoomID, this.strRoomID);
				objIData.AddParameter(P_Week, this.intWeek);
				objIData.AddParameter(P_IsReviewed1, this.bolIsReviewed1);
				objIData.AddParameter(P_ReviewDate1, this.dtmReviewDate1);
				objIData.AddParameter(P_ReviewUser1, this.strReviewUser1);
				objIData.AddParameter(P_ReviewComment1, this.strReviewComment1);
				objIData.AddParameter(P_IsReviewed2, this.bolIsReviewed2);
				objIData.AddParameter(P_ReviewDate2, this.dtmReviewDate2);
				objIData.AddParameter(P_ReviewUser2, this.strReviewUser2);
				objIData.AddParameter(P_ReviewComment2, this.strReviewComment2);
				objIData.AddParameter(P_ReviewDate, this.dtmReviewDate);
				objIData.AddParameter(P_IsTeachingSchedule, this.bolIsTeachingSchedule);
				objIData.AddParameter(P_OffStudentList, this.strOffStudentList);
				objIData.AddParameter(P_Rating, this.strRating);
				this.lngScheduleCheckingID = Convert.ToInt32(objIData.ExecStoreToString());
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_ScheduleChecking", objEx);
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
		/// Update : SIM_ScheduleChecking
		/// Cập nhật dữ liệu
		/// Store: SIM_ScheduleChecking_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ScheduleChecking_EDIT");
				objIData.AddParameter(P_ScheduleCheckingID, this.lngScheduleCheckingID);
				objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
				objIData.AddParameter(P_Date, this.dtmDate);
				objIData.AddParameter(P_Session, this.intSession);
				objIData.AddParameter(P_TheoryQuantity, this.decTheoryQuantity);
				objIData.AddParameter(P_PracticeQuantity, this.decPracticeQuantity);
				objIData.AddParameter(P_TestQuantity, this.decTestQuantity);
				objIData.AddParameter(P_TeacherID, this.strTeacherID);
				objIData.AddParameter(P_LearningContent, this.strLearningContent);
				objIData.AddParameter(P_RequestContent, this.strRequestContent);
				objIData.AddParameter(P_OffStudentCount, this.intOffStudentCount);
				objIData.AddParameter(P_ContentFile, this.strContentFile);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
				objIData.AddParameter(P_IsReviewed, this.bolIsReviewed);
				objIData.AddParameter(P_ReviewComment, this.strReviewComment);
				objIData.AddParameter(P_ReviewUser, this.strReviewUser);
				objIData.AddParameter(P_RoomID, this.strRoomID);
				objIData.AddParameter(P_Week, this.intWeek);
				objIData.AddParameter(P_IsReviewed1, this.bolIsReviewed1);
				objIData.AddParameter(P_ReviewDate1, this.dtmReviewDate1);
				objIData.AddParameter(P_ReviewUser1, this.strReviewUser1);
				objIData.AddParameter(P_ReviewComment1, this.strReviewComment1);
				objIData.AddParameter(P_IsReviewed2, this.bolIsReviewed2);
				objIData.AddParameter(P_ReviewDate2, this.dtmReviewDate2);
				objIData.AddParameter(P_ReviewUser2, this.strReviewUser2);
				objIData.AddParameter(P_ReviewComment2, this.strReviewComment2);
				objIData.AddParameter(P_ReviewDate, this.dtmReviewDate);
				objIData.AddParameter(P_IsTeachingSchedule, this.bolIsTeachingSchedule);
				objIData.AddParameter(P_OffStudentList, this.strOffStudentList);
				objIData.AddParameter(P_Rating, this.strRating);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_ScheduleChecking", objEx);
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
		/// Delete : SIM_ScheduleChecking
		/// Xóa dữ liệu
		/// Store: SIM_ScheduleChecking_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ScheduleChecking_DELETE");
				objIData.AddParameter(P_ScheduleCheckingID, this.lngScheduleCheckingID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_ScheduleChecking", objEx);
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
		/// Store: SIM_ScheduleChecking_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(long? lngScheduleCheckingID)
		{
			this.lngScheduleCheckingID = lngScheduleCheckingID;
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

		public SIM_ScheduleChecking()
		{
		}
		public SIM_ScheduleChecking(long? lngScheduleCheckingID)
		{
			this.lngScheduleCheckingID = lngScheduleCheckingID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_ScheduleCheckingID = "@" + C_ScheduleCheckingID;
		public const String P_ClassSubjectID = "@" + C_ClassSubjectID;
		public const String P_Date = "@" + C_Date;
		public const String P_Session = "@" + C_Session;
		public const String P_TheoryQuantity = "@" + C_TheoryQuantity;
		public const String P_PracticeQuantity = "@" + C_PracticeQuantity;
		public const String P_TestQuantity = "@" + C_TestQuantity;
		public const String P_TeacherID = "@" + C_TeacherID;
		public const String P_LearningContent = "@" + C_LearningContent;
		public const String P_RequestContent = "@" + C_RequestContent;
		public const String P_OffStudentCount = "@" + C_OffStudentCount;
		public const String P_ContentFile = "@" + C_ContentFile;
		public const String P_Description = "@" + C_Description;
		public const String P_CreatedDate = "@" + C_CreatedDate;
		public const String P_CreatedUser = "@" + C_CreatedUser;
		public const String P_UpdatedDate = "@" + C_UpdatedDate;
		public const String P_UpdatedUser = "@" + C_UpdatedUser;
		public const String P_IsReviewed = "@" + C_IsReviewed;
		public const String P_ReviewComment = "@" + C_ReviewComment;
		public const String P_ReviewUser = "@" + C_ReviewUser;
		public const String P_RoomID = "@" + C_RoomID;
		public const String P_Week = "@" + C_Week;
		public const String P_IsReviewed1 = "@" + C_IsReviewed1;
		public const String P_ReviewDate1 = "@" + C_ReviewDate1;
		public const String P_ReviewUser1 = "@" + C_ReviewUser1;
		public const String P_ReviewComment1 = "@" + C_ReviewComment1;
		public const String P_IsReviewed2 = "@" + C_IsReviewed2;
		public const String P_ReviewDate2 = "@" + C_ReviewDate2;
		public const String P_ReviewUser2 = "@" + C_ReviewUser2;
		public const String P_ReviewComment2 = "@" + C_ReviewComment2;
		public const String P_ReviewDate = "@" + C_ReviewDate;
		public const String P_IsTeachingSchedule = "@" + C_IsTeachingSchedule;
		public const String P_OffStudentList = "@" + C_OffStudentList;
		public const String P_Rating = "@" + C_Rating;

		#endregion //Parameter names

		#region Column Names

		public const String C_ScheduleCheckingID = "ScheduleCheckingID";
		public const String C_ClassSubjectID = "ClassSubjectID";
		public const String C_Date = "Date";
		public const String C_Session = "Session";
		public const String C_TheoryQuantity = "TheoryQuantity";
		public const String C_PracticeQuantity = "PracticeQuantity";
		public const String C_TestQuantity = "TestQuantity";
		public const String C_TeacherID = "TeacherID";
		public const String C_LearningContent = "LearningContent";
		public const String C_RequestContent = "RequestContent";
		public const String C_OffStudentCount = "OffStudentCount";
		public const String C_ContentFile = "ContentFile";
		public const String C_Description = "Description";
		public const String C_CreatedDate = "CreatedDate";
		public const String C_CreatedUser = "CreatedUser";
		public const String C_UpdatedDate = "UpdatedDate";
		public const String C_UpdatedUser = "UpdatedUser";
		public const String C_IsReviewed = "IsReviewed";
		public const String C_ReviewComment = "ReviewComment";
		public const String C_ReviewUser = "ReviewUser";
		public const String C_RoomID = "RoomID";
		public const String C_Week = "Week";
		public const String C_IsReviewed1 = "IsReviewed1";
		public const String C_ReviewDate1 = "ReviewDate1";
		public const String C_ReviewUser1 = "ReviewUser1";
		public const String C_ReviewComment1 = "ReviewComment1";
		public const String C_IsReviewed2 = "IsReviewed2";
		public const String C_ReviewDate2 = "ReviewDate2";
		public const String C_ReviewUser2 = "ReviewUser2";
		public const String C_ReviewComment2 = "ReviewComment2";
		public const String C_ReviewDate = "ReviewDate";
		public const String C_IsTeachingSchedule = "IsTeachingSchedule";
		public const String C_OffStudentList = "OffStudentList";
		public const String C_Rating = "Rating";

		#endregion //Column names

		#endregion Variable Static		
	}
}
