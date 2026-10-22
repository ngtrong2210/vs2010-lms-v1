
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
	public partial class SIM_Class_Subject_Charge
	{	
		#region Member Variables

		private long? lngClassSubjectID = null;
		private int? intTheoryQuantity = null;//Số tiết lý thuyết
		private int? intPracticeQuantity = null;//Số tiết thực hành
		private double? dblQuantityOfMonth = null;//Số giờ chuẩn trong tháng 
		private double? dblQuantityOfPractice = null;//Số giờ thực hành sau khi tính
		private double? dblRatioSalary = null;//Hệ số lương
		private double? dblMinSalary = null;//Mức lương tối thiểu
		private double? dblLessonMoney = null;//Tiền một giờ giảng chuẩn của giảng viên
		private double? dblTheoryTestQuantity = null;//Số bài kiểm tra định kỳ LT
		private double? dblPracticeTestQuantity = null;//Số bài kt định kỳ TH
		private double? dblTheoryTestRatio = null;//Hệ số bài kt đk LT
		private double? dblPracticeTestRatio = null;//Hệ số bài kt đk TH
		private double? dblReviewTheoryTestRatio = null;//Hệ số chấm bài kt đk LT. SL tăng theo sv và Số bài kt định kỳ
		private double? dblReviewPracticeTestRatio = null;//Hệ số chấm bài kt đk TH. SL tăng theo sv và số bài kt đk
		private double? dblSummaryListRatio = null;//Hệ số tổng hợp danh sách so với một giờ chuẩn
		private double? dblReviewTheoryExamRatio = null;//Hệ số chấm bài thi kết thúc môn LT. SL theo số lượng sv, và thi 1 lần
		private double? dblReviewPracticeExamRatio = null;//Hệ số chấm bài thi kết thúc môn TH. SL theo số lượng sv, và thi 1 lần
		private double? dblInputMarkRatio = null;//Hệ số làm phách vào điểm
		private double? dblTrackRatio = null;//Hệ số giám sát
		private double? dblPageForExam = null;//Số tiền mỗi tờ giấy làm bài thi kết thúc môn
		private double? dblDeviceMoney = null;//Số tiền cho một vật tư thực tập
		private int? intDeviceQuantity = null;//Số vật tư thực tập
		private double? dblTotalMoney = null;//Tổng chi phí mở lớp
		private double? dblObject1Money = null;//Số tiền học phí cho đối tượng 1
		private double? dblObject2Money = null;//Số tiền học phí cho đối tượng 2
		private double? dblScienceRatio = null;//Hệ số tiền cho Khoa (trích từ tổng tiền giờ chuẩn GV)
		private double? dblSchoolRatio = null;//Hệ số tiền cho Trường (trích từ tổng tiền giờ chuẩn GV)
		private double? dblTeacherRealMoney = null;//Số tiền thực nhận của GV
		private string strDescription = null;//Mô tả
		private string strCreatedUser = null;
		private DateTime? dtmCreatedDate = null;//Ngày tạo
		private string strUpdatedUser = null;//Người sửa
		private DateTime? dtmUpdatedDate = null;//Ngày sửa
		private IData objIData = null;
		private bool bolIsExistIData = false;
		private Exception objErrorException = null;

		#endregion

		#region Properties 

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
		/// TheoryQuantity
		/// Số tiết lý thuyết
		/// </summary>
		public int? TheoryQuantity
		{
			get { return  intTheoryQuantity; }
			set { intTheoryQuantity = value; }
		}
		/// <summary>
		/// PracticeQuantity
		/// Số tiết thực hành
		/// </summary>
		public int? PracticeQuantity
		{
			get { return  intPracticeQuantity; }
			set { intPracticeQuantity = value; }
		}
		/// <summary>
		/// QuantityOfMonth
		/// Số giờ chuẩn trong tháng 
		/// </summary>
		public double? QuantityOfMonth
		{
			get { return  dblQuantityOfMonth; }
			set { dblQuantityOfMonth = value; }
		}
		/// <summary>
		/// QuantityOfPractice
		/// Số giờ thực hành sau khi tính
		/// </summary>
		public double? QuantityOfPractice
		{
			get { return  dblQuantityOfPractice; }
			set { dblQuantityOfPractice = value; }
		}
		/// <summary>
		/// RatioSalary
		/// Hệ số lương
		/// </summary>
		public double? RatioSalary
		{
			get { return  dblRatioSalary; }
			set { dblRatioSalary = value; }
		}
		/// <summary>
		/// MinSalary
		/// Mức lương tối thiểu
		/// </summary>
		public double? MinSalary
		{
			get { return  dblMinSalary; }
			set { dblMinSalary = value; }
		}
		/// <summary>
		/// LessonMoney
		/// Tiền một giờ giảng chuẩn của giảng viên
		/// </summary>
		public double? LessonMoney
		{
			get { return  dblLessonMoney; }
			set { dblLessonMoney = value; }
		}
		/// <summary>
		/// TheoryTestQuantity
		/// Số bài kiểm tra định kỳ LT
		/// </summary>
		public double? TheoryTestQuantity
		{
			get { return  dblTheoryTestQuantity; }
			set { dblTheoryTestQuantity = value; }
		}
		/// <summary>
		/// PracticeTestQuantity
		/// Số bài kt định kỳ TH
		/// </summary>
		public double? PracticeTestQuantity
		{
			get { return  dblPracticeTestQuantity; }
			set { dblPracticeTestQuantity = value; }
		}
		/// <summary>
		/// TheoryTestRatio
		/// Hệ số bài kt đk LT
		/// </summary>
		public double? TheoryTestRatio
		{
			get { return  dblTheoryTestRatio; }
			set { dblTheoryTestRatio = value; }
		}
		/// <summary>
		/// PracticeTestRatio
		/// Hệ số bài kt đk TH
		/// </summary>
		public double? PracticeTestRatio
		{
			get { return  dblPracticeTestRatio; }
			set { dblPracticeTestRatio = value; }
		}
		/// <summary>
		/// ReviewTheoryTestRatio
		/// Hệ số chấm bài kt đk LT. SL tăng theo sv và Số bài kt định kỳ
		/// </summary>
		public double? ReviewTheoryTestRatio
		{
			get { return  dblReviewTheoryTestRatio; }
			set { dblReviewTheoryTestRatio = value; }
		}
		/// <summary>
		/// ReviewPracticeTestRatio
		/// Hệ số chấm bài kt đk TH. SL tăng theo sv và số bài kt đk
		/// </summary>
		public double? ReviewPracticeTestRatio
		{
			get { return  dblReviewPracticeTestRatio; }
			set { dblReviewPracticeTestRatio = value; }
		}
		/// <summary>
		/// SummaryListRatio
		/// Hệ số tổng hợp danh sách so với một giờ chuẩn
		/// </summary>
		public double? SummaryListRatio
		{
			get { return  dblSummaryListRatio; }
			set { dblSummaryListRatio = value; }
		}
		/// <summary>
		/// ReviewTheoryExamRatio
		/// Hệ số chấm bài thi kết thúc môn LT. SL theo số lượng sv, và thi 1 lần
		/// </summary>
		public double? ReviewTheoryExamRatio
		{
			get { return  dblReviewTheoryExamRatio; }
			set { dblReviewTheoryExamRatio = value; }
		}
		/// <summary>
		/// ReviewPracticeExamRatio
		/// Hệ số chấm bài thi kết thúc môn TH. SL theo số lượng sv, và thi 1 lần
		/// </summary>
		public double? ReviewPracticeExamRatio
		{
			get { return  dblReviewPracticeExamRatio; }
			set { dblReviewPracticeExamRatio = value; }
		}
		/// <summary>
		/// InputMarkRatio
		/// Hệ số làm phách vào điểm
		/// </summary>
		public double? InputMarkRatio
		{
			get { return  dblInputMarkRatio; }
			set { dblInputMarkRatio = value; }
		}
		/// <summary>
		/// TrackRatio
		/// Hệ số giám sát
		/// </summary>
		public double? TrackRatio
		{
			get { return  dblTrackRatio; }
			set { dblTrackRatio = value; }
		}
		/// <summary>
		/// PageForExam
		/// Số tiền mỗi tờ giấy làm bài thi kết thúc môn
		/// </summary>
		public double? PageForExam
		{
			get { return  dblPageForExam; }
			set { dblPageForExam = value; }
		}
		/// <summary>
		/// DeviceMoney
		/// Số tiền cho một vật tư thực tập
		/// </summary>
		public double? DeviceMoney
		{
			get { return  dblDeviceMoney; }
			set { dblDeviceMoney = value; }
		}
		/// <summary>
		/// DeviceQuantity
		/// Số vật tư thực tập
		/// </summary>
		public int? DeviceQuantity
		{
			get { return  intDeviceQuantity; }
			set { intDeviceQuantity = value; }
		}
		/// <summary>
		/// TotalMoney
		/// Tổng chi phí mở lớp
		/// </summary>
		public double? TotalMoney
		{
			get { return  dblTotalMoney; }
			set { dblTotalMoney = value; }
		}
		/// <summary>
		/// Object1Money
		/// Số tiền học phí cho đối tượng 1
		/// </summary>
		public double? Object1Money
		{
			get { return  dblObject1Money; }
			set { dblObject1Money = value; }
		}
		/// <summary>
		/// Object2Money
		/// Số tiền học phí cho đối tượng 2
		/// </summary>
		public double? Object2Money
		{
			get { return  dblObject2Money; }
			set { dblObject2Money = value; }
		}
		/// <summary>
		/// ScienceRatio
		/// Hệ số tiền cho Khoa (trích từ tổng tiền giờ chuẩn GV)
		/// </summary>
		public double? ScienceRatio
		{
			get { return  dblScienceRatio; }
			set { dblScienceRatio = value; }
		}
		/// <summary>
		/// SchoolRatio
		/// Hệ số tiền cho Trường (trích từ tổng tiền giờ chuẩn GV)
		/// </summary>
		public double? SchoolRatio
		{
			get { return  dblSchoolRatio; }
			set { dblSchoolRatio = value; }
		}
		/// <summary>
		/// TeacherRealMoney
		/// Số tiền thực nhận của GV
		/// </summary>
		public double? TeacherRealMoney
		{
			get { return  dblTeacherRealMoney; }
			set { dblTeacherRealMoney = value; }
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
		/// CreatedUser
		/// 
		/// </summary>
		public string CreatedUser
		{
			get { return  strCreatedUser; }
			set { strCreatedUser = value; }
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
		/// UpdatedUser
		/// Người sửa
		/// </summary>
		public string UpdatedUser
		{
			get { return  strUpdatedUser; }
			set { strUpdatedUser = value; }
		}
		/// <summary>
		/// UpdatedDate
		/// Ngày sửa
		/// </summary>
		public DateTime? UpdatedDate
		{
			get { return  dtmUpdatedDate; }
			set { dtmUpdatedDate = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_TheoryQuantity.ToUpper()) && !Convert.IsDBNull(reader[C_TheoryQuantity])) this.intTheoryQuantity = Convert.ToInt32(reader[C_TheoryQuantity]);
					if (reader.GetName(i).ToUpper().Equals(C_PracticeQuantity.ToUpper()) && !Convert.IsDBNull(reader[C_PracticeQuantity])) this.intPracticeQuantity = Convert.ToInt32(reader[C_PracticeQuantity]);
					if (reader.GetName(i).ToUpper().Equals(C_QuantityOfMonth.ToUpper()) && !Convert.IsDBNull(reader[C_QuantityOfMonth])) this.dblQuantityOfMonth = Convert.ToDouble(reader[C_QuantityOfMonth]);
					if (reader.GetName(i).ToUpper().Equals(C_QuantityOfPractice.ToUpper()) && !Convert.IsDBNull(reader[C_QuantityOfPractice])) this.dblQuantityOfPractice = Convert.ToDouble(reader[C_QuantityOfPractice]);
					if (reader.GetName(i).ToUpper().Equals(C_RatioSalary.ToUpper()) && !Convert.IsDBNull(reader[C_RatioSalary])) this.dblRatioSalary = Convert.ToDouble(reader[C_RatioSalary]);
					if (reader.GetName(i).ToUpper().Equals(C_MinSalary.ToUpper()) && !Convert.IsDBNull(reader[C_MinSalary])) this.dblMinSalary = Convert.ToDouble(reader[C_MinSalary]);
					if (reader.GetName(i).ToUpper().Equals(C_LessonMoney.ToUpper()) && !Convert.IsDBNull(reader[C_LessonMoney])) this.dblLessonMoney = Convert.ToDouble(reader[C_LessonMoney]);
					if (reader.GetName(i).ToUpper().Equals(C_TheoryTestQuantity.ToUpper()) && !Convert.IsDBNull(reader[C_TheoryTestQuantity])) this.dblTheoryTestQuantity = Convert.ToDouble(reader[C_TheoryTestQuantity]);
					if (reader.GetName(i).ToUpper().Equals(C_PracticeTestQuantity.ToUpper()) && !Convert.IsDBNull(reader[C_PracticeTestQuantity])) this.dblPracticeTestQuantity = Convert.ToDouble(reader[C_PracticeTestQuantity]);
					if (reader.GetName(i).ToUpper().Equals(C_TheoryTestRatio.ToUpper()) && !Convert.IsDBNull(reader[C_TheoryTestRatio])) this.dblTheoryTestRatio = Convert.ToDouble(reader[C_TheoryTestRatio]);
					if (reader.GetName(i).ToUpper().Equals(C_PracticeTestRatio.ToUpper()) && !Convert.IsDBNull(reader[C_PracticeTestRatio])) this.dblPracticeTestRatio = Convert.ToDouble(reader[C_PracticeTestRatio]);
					if (reader.GetName(i).ToUpper().Equals(C_ReviewTheoryTestRatio.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewTheoryTestRatio])) this.dblReviewTheoryTestRatio = Convert.ToDouble(reader[C_ReviewTheoryTestRatio]);
					if (reader.GetName(i).ToUpper().Equals(C_ReviewPracticeTestRatio.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewPracticeTestRatio])) this.dblReviewPracticeTestRatio = Convert.ToDouble(reader[C_ReviewPracticeTestRatio]);
					if (reader.GetName(i).ToUpper().Equals(C_SummaryListRatio.ToUpper()) && !Convert.IsDBNull(reader[C_SummaryListRatio])) this.dblSummaryListRatio = Convert.ToDouble(reader[C_SummaryListRatio]);
					if (reader.GetName(i).ToUpper().Equals(C_ReviewTheoryExamRatio.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewTheoryExamRatio])) this.dblReviewTheoryExamRatio = Convert.ToDouble(reader[C_ReviewTheoryExamRatio]);
					if (reader.GetName(i).ToUpper().Equals(C_ReviewPracticeExamRatio.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewPracticeExamRatio])) this.dblReviewPracticeExamRatio = Convert.ToDouble(reader[C_ReviewPracticeExamRatio]);
					if (reader.GetName(i).ToUpper().Equals(C_InputMarkRatio.ToUpper()) && !Convert.IsDBNull(reader[C_InputMarkRatio])) this.dblInputMarkRatio = Convert.ToDouble(reader[C_InputMarkRatio]);
					if (reader.GetName(i).ToUpper().Equals(C_TrackRatio.ToUpper()) && !Convert.IsDBNull(reader[C_TrackRatio])) this.dblTrackRatio = Convert.ToDouble(reader[C_TrackRatio]);
					if (reader.GetName(i).ToUpper().Equals(C_PageForExam.ToUpper()) && !Convert.IsDBNull(reader[C_PageForExam])) this.dblPageForExam = Convert.ToDouble(reader[C_PageForExam]);
					if (reader.GetName(i).ToUpper().Equals(C_DeviceMoney.ToUpper()) && !Convert.IsDBNull(reader[C_DeviceMoney])) this.dblDeviceMoney = Convert.ToDouble(reader[C_DeviceMoney]);
					if (reader.GetName(i).ToUpper().Equals(C_DeviceQuantity.ToUpper()) && !Convert.IsDBNull(reader[C_DeviceQuantity])) this.intDeviceQuantity = Convert.ToInt32(reader[C_DeviceQuantity]);
					if (reader.GetName(i).ToUpper().Equals(C_TotalMoney.ToUpper()) && !Convert.IsDBNull(reader[C_TotalMoney])) this.dblTotalMoney = Convert.ToDouble(reader[C_TotalMoney]);
					if (reader.GetName(i).ToUpper().Equals(C_Object1Money.ToUpper()) && !Convert.IsDBNull(reader[C_Object1Money])) this.dblObject1Money = Convert.ToDouble(reader[C_Object1Money]);
					if (reader.GetName(i).ToUpper().Equals(C_Object2Money.ToUpper()) && !Convert.IsDBNull(reader[C_Object2Money])) this.dblObject2Money = Convert.ToDouble(reader[C_Object2Money]);
					if (reader.GetName(i).ToUpper().Equals(C_ScienceRatio.ToUpper()) && !Convert.IsDBNull(reader[C_ScienceRatio])) this.dblScienceRatio = Convert.ToDouble(reader[C_ScienceRatio]);
					if (reader.GetName(i).ToUpper().Equals(C_SchoolRatio.ToUpper()) && !Convert.IsDBNull(reader[C_SchoolRatio])) this.dblSchoolRatio = Convert.ToDouble(reader[C_SchoolRatio]);
					if (reader.GetName(i).ToUpper().Equals(C_TeacherRealMoney.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherRealMoney])) this.dblTeacherRealMoney = Convert.ToDouble(reader[C_TeacherRealMoney]);
					if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(reader[C_UpdatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(reader[C_UpdatedDate]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_Class_Subject_Charge", objEx);
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
				if (!Convert.IsDBNull(drw[C_TheoryQuantity])) this.intTheoryQuantity = Convert.ToInt32(drw[C_TheoryQuantity]);
				if (!Convert.IsDBNull(drw[C_PracticeQuantity])) this.intPracticeQuantity = Convert.ToInt32(drw[C_PracticeQuantity]);
				if (!Convert.IsDBNull(drw[C_QuantityOfMonth])) this.dblQuantityOfMonth = Convert.ToDouble(drw[C_QuantityOfMonth]);
				if (!Convert.IsDBNull(drw[C_QuantityOfPractice])) this.dblQuantityOfPractice = Convert.ToDouble(drw[C_QuantityOfPractice]);
				if (!Convert.IsDBNull(drw[C_RatioSalary])) this.dblRatioSalary = Convert.ToDouble(drw[C_RatioSalary]);
				if (!Convert.IsDBNull(drw[C_MinSalary])) this.dblMinSalary = Convert.ToDouble(drw[C_MinSalary]);
				if (!Convert.IsDBNull(drw[C_LessonMoney])) this.dblLessonMoney = Convert.ToDouble(drw[C_LessonMoney]);
				if (!Convert.IsDBNull(drw[C_TheoryTestQuantity])) this.dblTheoryTestQuantity = Convert.ToDouble(drw[C_TheoryTestQuantity]);
				if (!Convert.IsDBNull(drw[C_PracticeTestQuantity])) this.dblPracticeTestQuantity = Convert.ToDouble(drw[C_PracticeTestQuantity]);
				if (!Convert.IsDBNull(drw[C_TheoryTestRatio])) this.dblTheoryTestRatio = Convert.ToDouble(drw[C_TheoryTestRatio]);
				if (!Convert.IsDBNull(drw[C_PracticeTestRatio])) this.dblPracticeTestRatio = Convert.ToDouble(drw[C_PracticeTestRatio]);
				if (!Convert.IsDBNull(drw[C_ReviewTheoryTestRatio])) this.dblReviewTheoryTestRatio = Convert.ToDouble(drw[C_ReviewTheoryTestRatio]);
				if (!Convert.IsDBNull(drw[C_ReviewPracticeTestRatio])) this.dblReviewPracticeTestRatio = Convert.ToDouble(drw[C_ReviewPracticeTestRatio]);
				if (!Convert.IsDBNull(drw[C_SummaryListRatio])) this.dblSummaryListRatio = Convert.ToDouble(drw[C_SummaryListRatio]);
				if (!Convert.IsDBNull(drw[C_ReviewTheoryExamRatio])) this.dblReviewTheoryExamRatio = Convert.ToDouble(drw[C_ReviewTheoryExamRatio]);
				if (!Convert.IsDBNull(drw[C_ReviewPracticeExamRatio])) this.dblReviewPracticeExamRatio = Convert.ToDouble(drw[C_ReviewPracticeExamRatio]);
				if (!Convert.IsDBNull(drw[C_InputMarkRatio])) this.dblInputMarkRatio = Convert.ToDouble(drw[C_InputMarkRatio]);
				if (!Convert.IsDBNull(drw[C_TrackRatio])) this.dblTrackRatio = Convert.ToDouble(drw[C_TrackRatio]);
				if (!Convert.IsDBNull(drw[C_PageForExam])) this.dblPageForExam = Convert.ToDouble(drw[C_PageForExam]);
				if (!Convert.IsDBNull(drw[C_DeviceMoney])) this.dblDeviceMoney = Convert.ToDouble(drw[C_DeviceMoney]);
				if (!Convert.IsDBNull(drw[C_DeviceQuantity])) this.intDeviceQuantity = Convert.ToInt32(drw[C_DeviceQuantity]);
				if (!Convert.IsDBNull(drw[C_TotalMoney])) this.dblTotalMoney = Convert.ToDouble(drw[C_TotalMoney]);
				if (!Convert.IsDBNull(drw[C_Object1Money])) this.dblObject1Money = Convert.ToDouble(drw[C_Object1Money]);
				if (!Convert.IsDBNull(drw[C_Object2Money])) this.dblObject2Money = Convert.ToDouble(drw[C_Object2Money]);
				if (!Convert.IsDBNull(drw[C_ScienceRatio])) this.dblScienceRatio = Convert.ToDouble(drw[C_ScienceRatio]);
				if (!Convert.IsDBNull(drw[C_SchoolRatio])) this.dblSchoolRatio = Convert.ToDouble(drw[C_SchoolRatio]);
				if (!Convert.IsDBNull(drw[C_TeacherRealMoney])) this.dblTeacherRealMoney = Convert.ToDouble(drw[C_TeacherRealMoney]);
				if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
				if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
				if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
				if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
				if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_Class_Subject_Charge", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_Class_Subject_Charge_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Class_Subject_Charge_GET");
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_Class_Subject_Charge", objEx);
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
		/// Store: SIM_Class_Subject_Charge_GET 
		///</summary>
		/// <returns> SIM_Class_Subject_Charge </returns>
		public SIM_Class_Subject_Charge Get(long? lngClassSubjectID)
		{
			SIM_Class_Subject_Charge obj = new SIM_Class_Subject_Charge();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.ClassSubjectID = lngClassSubjectID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_Class_Subject_Charge
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Class_Subject_Charge", objEx);
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
		/// Search : SIM_Class_Subject_Charge
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Class_Subject_Charge", objEx);
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
		/// Search : SIM_Class_Subject_Charge
		/// Lấy hết dữ liệu
		/// Store: SIM_Class_Subject_Charge_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_Class_Subject_Charge_GETALL");
		}

		///<summary>
		/// Search : SIM_Class_Subject_Charge
		/// Tìm dữ liệu
		/// Store: SIM_Class_Subject_Charge_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_Class_Subject_Charge_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_Class_Subject_Charge
		/// Thêm dữ liệu
		/// Store: SIM_Class_Subject_Charge_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Class_Subject_Charge_ADD");
				objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
				objIData.AddParameter(P_TheoryQuantity, this.intTheoryQuantity);
				objIData.AddParameter(P_PracticeQuantity, this.intPracticeQuantity);
				objIData.AddParameter(P_QuantityOfMonth, this.dblQuantityOfMonth);
				objIData.AddParameter(P_QuantityOfPractice, this.dblQuantityOfPractice);
				objIData.AddParameter(P_RatioSalary, this.dblRatioSalary);
				objIData.AddParameter(P_MinSalary, this.dblMinSalary);
				objIData.AddParameter(P_LessonMoney, this.dblLessonMoney);
				objIData.AddParameter(P_TheoryTestQuantity, this.dblTheoryTestQuantity);
				objIData.AddParameter(P_PracticeTestQuantity, this.dblPracticeTestQuantity);
				objIData.AddParameter(P_TheoryTestRatio, this.dblTheoryTestRatio);
				objIData.AddParameter(P_PracticeTestRatio, this.dblPracticeTestRatio);
				objIData.AddParameter(P_ReviewTheoryTestRatio, this.dblReviewTheoryTestRatio);
				objIData.AddParameter(P_ReviewPracticeTestRatio, this.dblReviewPracticeTestRatio);
				objIData.AddParameter(P_SummaryListRatio, this.dblSummaryListRatio);
				objIData.AddParameter(P_ReviewTheoryExamRatio, this.dblReviewTheoryExamRatio);
				objIData.AddParameter(P_ReviewPracticeExamRatio, this.dblReviewPracticeExamRatio);
				objIData.AddParameter(P_InputMarkRatio, this.dblInputMarkRatio);
				objIData.AddParameter(P_TrackRatio, this.dblTrackRatio);
				objIData.AddParameter(P_PageForExam, this.dblPageForExam);
				objIData.AddParameter(P_DeviceMoney, this.dblDeviceMoney);
				objIData.AddParameter(P_DeviceQuantity, this.intDeviceQuantity);
				objIData.AddParameter(P_TotalMoney, this.dblTotalMoney);
				objIData.AddParameter(P_Object1Money, this.dblObject1Money);
				objIData.AddParameter(P_Object2Money, this.dblObject2Money);
				objIData.AddParameter(P_ScienceRatio, this.dblScienceRatio);
				objIData.AddParameter(P_SchoolRatio, this.dblSchoolRatio);
				objIData.AddParameter(P_TeacherRealMoney, this.dblTeacherRealMoney);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_Class_Subject_Charge", objEx);
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
		/// Update : SIM_Class_Subject_Charge
		/// Cập nhật dữ liệu
		/// Store: SIM_Class_Subject_Charge_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Class_Subject_Charge_EDIT");
				objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
				objIData.AddParameter(P_TheoryQuantity, this.intTheoryQuantity);
				objIData.AddParameter(P_PracticeQuantity, this.intPracticeQuantity);
				objIData.AddParameter(P_QuantityOfMonth, this.dblQuantityOfMonth);
				objIData.AddParameter(P_QuantityOfPractice, this.dblQuantityOfPractice);
				objIData.AddParameter(P_RatioSalary, this.dblRatioSalary);
				objIData.AddParameter(P_MinSalary, this.dblMinSalary);
				objIData.AddParameter(P_LessonMoney, this.dblLessonMoney);
				objIData.AddParameter(P_TheoryTestQuantity, this.dblTheoryTestQuantity);
				objIData.AddParameter(P_PracticeTestQuantity, this.dblPracticeTestQuantity);
				objIData.AddParameter(P_TheoryTestRatio, this.dblTheoryTestRatio);
				objIData.AddParameter(P_PracticeTestRatio, this.dblPracticeTestRatio);
				objIData.AddParameter(P_ReviewTheoryTestRatio, this.dblReviewTheoryTestRatio);
				objIData.AddParameter(P_ReviewPracticeTestRatio, this.dblReviewPracticeTestRatio);
				objIData.AddParameter(P_SummaryListRatio, this.dblSummaryListRatio);
				objIData.AddParameter(P_ReviewTheoryExamRatio, this.dblReviewTheoryExamRatio);
				objIData.AddParameter(P_ReviewPracticeExamRatio, this.dblReviewPracticeExamRatio);
				objIData.AddParameter(P_InputMarkRatio, this.dblInputMarkRatio);
				objIData.AddParameter(P_TrackRatio, this.dblTrackRatio);
				objIData.AddParameter(P_PageForExam, this.dblPageForExam);
				objIData.AddParameter(P_DeviceMoney, this.dblDeviceMoney);
				objIData.AddParameter(P_DeviceQuantity, this.intDeviceQuantity);
				objIData.AddParameter(P_TotalMoney, this.dblTotalMoney);
				objIData.AddParameter(P_Object1Money, this.dblObject1Money);
				objIData.AddParameter(P_Object2Money, this.dblObject2Money);
				objIData.AddParameter(P_ScienceRatio, this.dblScienceRatio);
				objIData.AddParameter(P_SchoolRatio, this.dblSchoolRatio);
				objIData.AddParameter(P_TeacherRealMoney, this.dblTeacherRealMoney);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_Class_Subject_Charge", objEx);
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
		/// Delete : SIM_Class_Subject_Charge
		/// Xóa dữ liệu
		/// Store: SIM_Class_Subject_Charge_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Class_Subject_Charge_DELETE");
				objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_Class_Subject_Charge", objEx);
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
		/// Store: SIM_Class_Subject_Charge_DELETE 
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

		public SIM_Class_Subject_Charge()
		{
		}
		public SIM_Class_Subject_Charge(long? lngClassSubjectID)
		{
			this.lngClassSubjectID = lngClassSubjectID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_ClassSubjectID = "@" + C_ClassSubjectID;
		public const String P_TheoryQuantity = "@" + C_TheoryQuantity;
		public const String P_PracticeQuantity = "@" + C_PracticeQuantity;
		public const String P_QuantityOfMonth = "@" + C_QuantityOfMonth;
		public const String P_QuantityOfPractice = "@" + C_QuantityOfPractice;
		public const String P_RatioSalary = "@" + C_RatioSalary;
		public const String P_MinSalary = "@" + C_MinSalary;
		public const String P_LessonMoney = "@" + C_LessonMoney;
		public const String P_TheoryTestQuantity = "@" + C_TheoryTestQuantity;
		public const String P_PracticeTestQuantity = "@" + C_PracticeTestQuantity;
		public const String P_TheoryTestRatio = "@" + C_TheoryTestRatio;
		public const String P_PracticeTestRatio = "@" + C_PracticeTestRatio;
		public const String P_ReviewTheoryTestRatio = "@" + C_ReviewTheoryTestRatio;
		public const String P_ReviewPracticeTestRatio = "@" + C_ReviewPracticeTestRatio;
		public const String P_SummaryListRatio = "@" + C_SummaryListRatio;
		public const String P_ReviewTheoryExamRatio = "@" + C_ReviewTheoryExamRatio;
		public const String P_ReviewPracticeExamRatio = "@" + C_ReviewPracticeExamRatio;
		public const String P_InputMarkRatio = "@" + C_InputMarkRatio;
		public const String P_TrackRatio = "@" + C_TrackRatio;
		public const String P_PageForExam = "@" + C_PageForExam;
		public const String P_DeviceMoney = "@" + C_DeviceMoney;
		public const String P_DeviceQuantity = "@" + C_DeviceQuantity;
		public const String P_TotalMoney = "@" + C_TotalMoney;
		public const String P_Object1Money = "@" + C_Object1Money;
		public const String P_Object2Money = "@" + C_Object2Money;
		public const String P_ScienceRatio = "@" + C_ScienceRatio;
		public const String P_SchoolRatio = "@" + C_SchoolRatio;
		public const String P_TeacherRealMoney = "@" + C_TeacherRealMoney;
		public const String P_Description = "@" + C_Description;
		public const String P_CreatedUser = "@" + C_CreatedUser;
		public const String P_CreatedDate = "@" + C_CreatedDate;
		public const String P_UpdatedUser = "@" + C_UpdatedUser;
		public const String P_UpdatedDate = "@" + C_UpdatedDate;

		#endregion //Parameter names

		#region Column Names

		public const String C_ClassSubjectID = "ClassSubjectID";
		public const String C_TheoryQuantity = "TheoryQuantity";
		public const String C_PracticeQuantity = "PracticeQuantity";
		public const String C_QuantityOfMonth = "QuantityOfMonth";
		public const String C_QuantityOfPractice = "QuantityOfPractice";
		public const String C_RatioSalary = "RatioSalary";
		public const String C_MinSalary = "MinSalary";
		public const String C_LessonMoney = "LessonMoney";
		public const String C_TheoryTestQuantity = "TheoryTestQuantity";
		public const String C_PracticeTestQuantity = "PracticeTestQuantity";
		public const String C_TheoryTestRatio = "TheoryTestRatio";
		public const String C_PracticeTestRatio = "PracticeTestRatio";
		public const String C_ReviewTheoryTestRatio = "ReviewTheoryTestRatio";
		public const String C_ReviewPracticeTestRatio = "ReviewPracticeTestRatio";
		public const String C_SummaryListRatio = "SummaryListRatio";
		public const String C_ReviewTheoryExamRatio = "ReviewTheoryExamRatio";
		public const String C_ReviewPracticeExamRatio = "ReviewPracticeExamRatio";
		public const String C_InputMarkRatio = "InputMarkRatio";
		public const String C_TrackRatio = "TrackRatio";
		public const String C_PageForExam = "PageForExam";
		public const String C_DeviceMoney = "DeviceMoney";
		public const String C_DeviceQuantity = "DeviceQuantity";
		public const String C_TotalMoney = "TotalMoney";
		public const String C_Object1Money = "Object1Money";
		public const String C_Object2Money = "Object2Money";
		public const String C_ScienceRatio = "ScienceRatio";
		public const String C_SchoolRatio = "SchoolRatio";
		public const String C_TeacherRealMoney = "TeacherRealMoney";
		public const String C_Description = "Description";
		public const String C_CreatedUser = "CreatedUser";
		public const String C_CreatedDate = "CreatedDate";
		public const String C_UpdatedUser = "UpdatedUser";
		public const String C_UpdatedDate = "UpdatedDate";

		#endregion //Column names

		#endregion Variable Static		
	}
}
