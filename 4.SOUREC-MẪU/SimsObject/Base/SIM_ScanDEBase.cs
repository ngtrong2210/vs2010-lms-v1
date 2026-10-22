
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
	/// Created date 	: 8/9/2022 
	/// Description 
	/// </summary>	
	public partial class SIM_ScanDE
	{	
		#region Member Variables

		private long? lngScanFileID = null;
		private string strFileName = null;//Chỉ chứa tên file
		private string strFilePath = null;
		private long? lngFileSize = null;
		private DateTime? dtmFileUpdatedDate = null;//Ngày giờ tạo file
		private string strExamStudentNumber = null;//Số báo danh nhận dạng được từ scan
		private string strSameExamCode = null;//Mã đề tương đương scan được
		private int? intPageIndex = null;//Số tờ  scan được (nếu 1 doneExam có nhiều hơn 2 trang, tính từ 0)
		private long? lngTestScheduleID = null;//Mã lịch thi, ca thi (update khi chọn ca thi để lưu kq)
		private int? intYearID = null;//Niên kì (chọn trên form scan hoặc tự động xử lý nếu có truyền ca thi)
		private int? intSemester = null;//Niên kì (chọn trên form scan hoặc tự động xử lý nếu có truyền ca thi)
		private int? intMarkGroup = null;//Nhóm cột (0_Mặc định là Exam như cũ, 1_Nhóm 1 (HS1/Midtern), 2_Nhóm 2 (HS2/Final), 3_Nhóm 3(HW) (update khi lưu kq scan)
		private int? intTestOrder = null;//Lần thi/ kiểm tra (update khi lưu kq scan)
		private long? lngStudentID = null;//Mã HSSV so khớp được khi lưu kết quả
		private long? lngSameExamID = null;//Mã đề tương đương tìm được (khi scan)
		private int? intQuestionCount = null;//Tổng số câu của đề tương đương tìm được
		private long? lngExamID = null;//Mã đề gốc kéo theo từ đề tương đương
		private string strSubjectID = null;//Mã môn kéo theo từ đề tương đương
		private long? lngClassSubjectID = null;//Mã môn học lớp xử lý được (có 2 cách: 1_dựa vào mã ca thi; 2_dựa vào niên, kì)
		private int? intTrueAnswerCount = null;//Số câu trả lời đúng
		private double? dblMark = null;//Tổng số điểm thi
		private bool bolPassed = false;//Đạt? Null là chưa có điểm
		private bool bolIsUpdated = false;//Đã update kết quả thi vào sổ điểm
		private string strErrorCodeList = null;//Ds mã lỗi, cách nhau dấu ,
		private string strErrorDesc = null;//Mô tả lỗi
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
		/// ScanFileID
		/// 
		/// </summary>
		public long? ScanFileID
		{
			get { return  lngScanFileID; }
			set { lngScanFileID = value; }
		}
		/// <summary>
		/// FileName
		/// Chỉ chứa tên file
		/// </summary>
		public string FileName
		{
			get { return  strFileName; }
			set { strFileName = value; }
		}
		/// <summary>
		/// FilePath
		/// 
		/// </summary>
		public string FilePath
		{
			get { return  strFilePath; }
			set { strFilePath = value; }
		}
		/// <summary>
		/// FileSize
		/// 
		/// </summary>
		public long? FileSize
		{
			get { return  lngFileSize; }
			set { lngFileSize = value; }
		}
		/// <summary>
		/// FileUpdatedDate
		/// Ngày giờ tạo file
		/// </summary>
		public DateTime? FileUpdatedDate
		{
			get { return  dtmFileUpdatedDate; }
			set { dtmFileUpdatedDate = value; }
		}
		/// <summary>
		/// ExamStudentNumber
		/// Số báo danh nhận dạng được từ scan
		/// </summary>
		public string ExamStudentNumber
		{
			get { return  strExamStudentNumber; }
			set { strExamStudentNumber = value; }
		}
		/// <summary>
		/// SameExamCode
		/// Mã đề tương đương scan được
		/// </summary>
		public string SameExamCode
		{
			get { return  strSameExamCode; }
			set { strSameExamCode = value; }
		}
		/// <summary>
		/// PageIndex
		/// Số tờ  scan được (nếu 1 doneExam có nhiều hơn 2 trang, tính từ 0)
		/// </summary>
		public int? PageIndex
		{
			get { return  intPageIndex; }
			set { intPageIndex = value; }
		}
		/// <summary>
		/// TestScheduleID
		/// Mã lịch thi, ca thi (update khi chọn ca thi để lưu kq)
		/// </summary>
		public long? TestScheduleID
		{
			get { return  lngTestScheduleID; }
			set { lngTestScheduleID = value; }
		}
		/// <summary>
		/// YearID
		/// Niên kì (chọn trên form scan hoặc tự động xử lý nếu có truyền ca thi)
		/// </summary>
		public int? YearID
		{
			get { return  intYearID; }
			set { intYearID = value; }
		}
		/// <summary>
		/// Semester
		/// Niên kì (chọn trên form scan hoặc tự động xử lý nếu có truyền ca thi)
		/// </summary>
		public int? Semester
		{
			get { return  intSemester; }
			set { intSemester = value; }
		}
		/// <summary>
		/// MarkGroup
		/// Nhóm cột (0_Mặc định là Exam như cũ, 1_Nhóm 1 (HS1/Midtern), 2_Nhóm 2 (HS2/Final), 3_Nhóm 3(HW) (update khi lưu kq scan)
		/// </summary>
		public int? MarkGroup
		{
			get { return  intMarkGroup; }
			set { intMarkGroup = value; }
		}
		/// <summary>
		/// TestOrder
		/// Lần thi/ kiểm tra (update khi lưu kq scan)
		/// </summary>
		public int? TestOrder
		{
			get { return  intTestOrder; }
			set { intTestOrder = value; }
		}
		/// <summary>
		/// StudentID
		/// Mã HSSV so khớp được khi lưu kết quả
		/// </summary>
		public long? StudentID
		{
			get { return  lngStudentID; }
			set { lngStudentID = value; }
		}
		/// <summary>
		/// SameExamID
		/// Mã đề tương đương tìm được (khi scan)
		/// </summary>
		public long? SameExamID
		{
			get { return  lngSameExamID; }
			set { lngSameExamID = value; }
		}
		/// <summary>
		/// QuestionCount
		/// Tổng số câu của đề tương đương tìm được
		/// </summary>
		public int? QuestionCount
		{
			get { return  intQuestionCount; }
			set { intQuestionCount = value; }
		}
		/// <summary>
		/// ExamID
		/// Mã đề gốc kéo theo từ đề tương đương
		/// </summary>
		public long? ExamID
		{
			get { return  lngExamID; }
			set { lngExamID = value; }
		}
		/// <summary>
		/// SubjectID
		/// Mã môn kéo theo từ đề tương đương
		/// </summary>
		public string SubjectID
		{
			get { return  strSubjectID; }
			set { strSubjectID = value; }
		}
		/// <summary>
		/// ClassSubjectID
		/// Mã môn học lớp xử lý được (có 2 cách: 1_dựa vào mã ca thi; 2_dựa vào niên, kì)
		/// </summary>
		public long? ClassSubjectID
		{
			get { return  lngClassSubjectID; }
			set { lngClassSubjectID = value; }
		}
		/// <summary>
		/// TrueAnswerCount
		/// Số câu trả lời đúng
		/// </summary>
		public int? TrueAnswerCount
		{
			get { return  intTrueAnswerCount; }
			set { intTrueAnswerCount = value; }
		}
		/// <summary>
		/// Mark
		/// Tổng số điểm thi
		/// </summary>
		public double? Mark
		{
			get { return  dblMark; }
			set { dblMark = value; }
		}
		/// <summary>
		/// Passed
		/// Đạt? Null là chưa có điểm
		/// </summary>
		public bool Passed
		{
			get { return  bolPassed; }
			set { bolPassed = value; }
		}
		/// <summary>
		/// IsUpdated
		/// Đã update kết quả thi vào sổ điểm
		/// </summary>
		public bool IsUpdated
		{
			get { return  bolIsUpdated; }
			set { bolIsUpdated = value; }
		}
		/// <summary>
		/// ErrorCodeList
		/// Ds mã lỗi, cách nhau dấu ,
		/// </summary>
		public string ErrorCodeList
		{
			get { return  strErrorCodeList; }
			set { strErrorCodeList = value; }
		}
		/// <summary>
		/// ErrorDesc
		/// Mô tả lỗi
		/// </summary>
		public string ErrorDesc
		{
			get { return  strErrorDesc; }
			set { strErrorDesc = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_ScanFileID.ToUpper()) && !Convert.IsDBNull(reader[C_ScanFileID])) this.lngScanFileID = Convert.ToInt64(reader[C_ScanFileID]);
					if (reader.GetName(i).ToUpper().Equals(C_FileName.ToUpper()) && !Convert.IsDBNull(reader[C_FileName])) this.strFileName = Convert.ToString(reader[C_FileName]);
					if (reader.GetName(i).ToUpper().Equals(C_FilePath.ToUpper()) && !Convert.IsDBNull(reader[C_FilePath])) this.strFilePath = Convert.ToString(reader[C_FilePath]);
					if (reader.GetName(i).ToUpper().Equals(C_FileSize.ToUpper()) && !Convert.IsDBNull(reader[C_FileSize])) this.lngFileSize = Convert.ToInt64(reader[C_FileSize]);
					if (reader.GetName(i).ToUpper().Equals(C_FileUpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_FileUpdatedDate])) this.dtmFileUpdatedDate = Convert.ToDateTime(reader[C_FileUpdatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_ExamStudentNumber.ToUpper()) && !Convert.IsDBNull(reader[C_ExamStudentNumber])) this.strExamStudentNumber = Convert.ToString(reader[C_ExamStudentNumber]);
					if (reader.GetName(i).ToUpper().Equals(C_SameExamCode.ToUpper()) && !Convert.IsDBNull(reader[C_SameExamCode])) this.strSameExamCode = Convert.ToString(reader[C_SameExamCode]);
					if (reader.GetName(i).ToUpper().Equals(C_PageIndex.ToUpper()) && !Convert.IsDBNull(reader[C_PageIndex])) this.intPageIndex = Convert.ToInt32(reader[C_PageIndex]);
					if (reader.GetName(i).ToUpper().Equals(C_TestScheduleID.ToUpper()) && !Convert.IsDBNull(reader[C_TestScheduleID])) this.lngTestScheduleID = Convert.ToInt64(reader[C_TestScheduleID]);
					if (reader.GetName(i).ToUpper().Equals(C_YearID.ToUpper()) && !Convert.IsDBNull(reader[C_YearID])) this.intYearID = Convert.ToInt32(reader[C_YearID]);
					if (reader.GetName(i).ToUpper().Equals(C_Semester.ToUpper()) && !Convert.IsDBNull(reader[C_Semester])) this.intSemester = Convert.ToInt32(reader[C_Semester]);
					if (reader.GetName(i).ToUpper().Equals(C_MarkGroup.ToUpper()) && !Convert.IsDBNull(reader[C_MarkGroup])) this.intMarkGroup = Convert.ToInt32(reader[C_MarkGroup]);
					if (reader.GetName(i).ToUpper().Equals(C_TestOrder.ToUpper()) && !Convert.IsDBNull(reader[C_TestOrder])) this.intTestOrder = Convert.ToInt32(reader[C_TestOrder]);
					if (reader.GetName(i).ToUpper().Equals(C_StudentID.ToUpper()) && !Convert.IsDBNull(reader[C_StudentID])) this.lngStudentID = Convert.ToInt64(reader[C_StudentID]);
					if (reader.GetName(i).ToUpper().Equals(C_SameExamID.ToUpper()) && !Convert.IsDBNull(reader[C_SameExamID])) this.lngSameExamID = Convert.ToInt64(reader[C_SameExamID]);
					if (reader.GetName(i).ToUpper().Equals(C_QuestionCount.ToUpper()) && !Convert.IsDBNull(reader[C_QuestionCount])) this.intQuestionCount = Convert.ToInt32(reader[C_QuestionCount]);
					if (reader.GetName(i).ToUpper().Equals(C_ExamID.ToUpper()) && !Convert.IsDBNull(reader[C_ExamID])) this.lngExamID = Convert.ToInt64(reader[C_ExamID]);
					if (reader.GetName(i).ToUpper().Equals(C_SubjectID.ToUpper()) && !Convert.IsDBNull(reader[C_SubjectID])) this.strSubjectID = Convert.ToString(reader[C_SubjectID]);
					if (reader.GetName(i).ToUpper().Equals(C_ClassSubjectID.ToUpper()) && !Convert.IsDBNull(reader[C_ClassSubjectID])) this.lngClassSubjectID = Convert.ToInt64(reader[C_ClassSubjectID]);
					if (reader.GetName(i).ToUpper().Equals(C_TrueAnswerCount.ToUpper()) && !Convert.IsDBNull(reader[C_TrueAnswerCount])) this.intTrueAnswerCount = Convert.ToInt32(reader[C_TrueAnswerCount]);
					if (reader.GetName(i).ToUpper().Equals(C_Mark.ToUpper()) && !Convert.IsDBNull(reader[C_Mark])) this.dblMark = Convert.ToDouble(reader[C_Mark]);
					if (reader.GetName(i).ToUpper().Equals(C_Passed.ToUpper()) && !Convert.IsDBNull(reader[C_Passed])) this.bolPassed = Convert.ToBoolean(reader[C_Passed]);
					if (reader.GetName(i).ToUpper().Equals(C_IsUpdated.ToUpper()) && !Convert.IsDBNull(reader[C_IsUpdated])) this.bolIsUpdated = Convert.ToBoolean(reader[C_IsUpdated]);
					if (reader.GetName(i).ToUpper().Equals(C_ErrorCodeList.ToUpper()) && !Convert.IsDBNull(reader[C_ErrorCodeList])) this.strErrorCodeList = Convert.ToString(reader[C_ErrorCodeList]);
					if (reader.GetName(i).ToUpper().Equals(C_ErrorDesc.ToUpper()) && !Convert.IsDBNull(reader[C_ErrorDesc])) this.strErrorDesc = Convert.ToString(reader[C_ErrorDesc]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(reader[C_UpdatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(reader[C_UpdatedUser]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_ScanDE", objEx);
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
				if (!Convert.IsDBNull(drw[C_ScanFileID])) this.lngScanFileID = Convert.ToInt64(drw[C_ScanFileID]);
				if (!Convert.IsDBNull(drw[C_FileName])) this.strFileName = Convert.ToString(drw[C_FileName]);
				if (!Convert.IsDBNull(drw[C_FilePath])) this.strFilePath = Convert.ToString(drw[C_FilePath]);
				if (!Convert.IsDBNull(drw[C_FileSize])) this.lngFileSize = Convert.ToInt64(drw[C_FileSize]);
				if (!Convert.IsDBNull(drw[C_FileUpdatedDate])) this.dtmFileUpdatedDate = Convert.ToDateTime(drw[C_FileUpdatedDate]);
				if (!Convert.IsDBNull(drw[C_ExamStudentNumber])) this.strExamStudentNumber = Convert.ToString(drw[C_ExamStudentNumber]);
				if (!Convert.IsDBNull(drw[C_SameExamCode])) this.strSameExamCode = Convert.ToString(drw[C_SameExamCode]);
				if (!Convert.IsDBNull(drw[C_PageIndex])) this.intPageIndex = Convert.ToInt32(drw[C_PageIndex]);
				if (!Convert.IsDBNull(drw[C_TestScheduleID])) this.lngTestScheduleID = Convert.ToInt64(drw[C_TestScheduleID]);
				if (!Convert.IsDBNull(drw[C_YearID])) this.intYearID = Convert.ToInt32(drw[C_YearID]);
				if (!Convert.IsDBNull(drw[C_Semester])) this.intSemester = Convert.ToInt32(drw[C_Semester]);
				if (!Convert.IsDBNull(drw[C_MarkGroup])) this.intMarkGroup = Convert.ToInt32(drw[C_MarkGroup]);
				if (!Convert.IsDBNull(drw[C_TestOrder])) this.intTestOrder = Convert.ToInt32(drw[C_TestOrder]);
				if (!Convert.IsDBNull(drw[C_StudentID])) this.lngStudentID = Convert.ToInt64(drw[C_StudentID]);
				if (!Convert.IsDBNull(drw[C_SameExamID])) this.lngSameExamID = Convert.ToInt64(drw[C_SameExamID]);
				if (!Convert.IsDBNull(drw[C_QuestionCount])) this.intQuestionCount = Convert.ToInt32(drw[C_QuestionCount]);
				if (!Convert.IsDBNull(drw[C_ExamID])) this.lngExamID = Convert.ToInt64(drw[C_ExamID]);
				if (!Convert.IsDBNull(drw[C_SubjectID])) this.strSubjectID = Convert.ToString(drw[C_SubjectID]);
				if (!Convert.IsDBNull(drw[C_ClassSubjectID])) this.lngClassSubjectID = Convert.ToInt64(drw[C_ClassSubjectID]);
				if (!Convert.IsDBNull(drw[C_TrueAnswerCount])) this.intTrueAnswerCount = Convert.ToInt32(drw[C_TrueAnswerCount]);
				if (!Convert.IsDBNull(drw[C_Mark])) this.dblMark = Convert.ToDouble(drw[C_Mark]);
				if (!Convert.IsDBNull(drw[C_Passed])) this.bolPassed = Convert.ToBoolean(drw[C_Passed]);
				if (!Convert.IsDBNull(drw[C_IsUpdated])) this.bolIsUpdated = Convert.ToBoolean(drw[C_IsUpdated]);
				if (!Convert.IsDBNull(drw[C_ErrorCodeList])) this.strErrorCodeList = Convert.ToString(drw[C_ErrorCodeList]);
				if (!Convert.IsDBNull(drw[C_ErrorDesc])) this.strErrorDesc = Convert.ToString(drw[C_ErrorDesc]);
				if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
				if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
				if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
				if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_ScanDE", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_ScanDE_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ScanDE_GET");
				objIData.AddParameter(P_ScanFileID, this.lngScanFileID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_ScanDE", objEx);
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
		/// Store: SIM_ScanDE_GET 
		///</summary>
		/// <returns> SIM_ScanDE </returns>
		public SIM_ScanDE Get(long? lngScanFileID)
		{
			SIM_ScanDE obj = new SIM_ScanDE();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.ScanFileID = lngScanFileID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_ScanDE
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_ScanDE", objEx);
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
		/// Search : SIM_ScanDE
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_ScanDE", objEx);
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
		/// Search : SIM_ScanDE
		/// Lấy hết dữ liệu
		/// Store: SIM_ScanDE_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_ScanDE_GETALL");
		}

		///<summary>
		/// Search : SIM_ScanDE
		/// Tìm dữ liệu
		/// Store: SIM_ScanDE_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_ScanDE_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_ScanDE
		/// Thêm dữ liệu
		/// Store: SIM_ScanDE_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ScanDE_ADD");
				objIData.AddParameter(P_FileName, this.strFileName);
				objIData.AddParameter(P_FilePath, this.strFilePath);
				objIData.AddParameter(P_FileSize, this.lngFileSize);
				objIData.AddParameter(P_FileUpdatedDate, this.dtmFileUpdatedDate);
				objIData.AddParameter(P_ExamStudentNumber, this.strExamStudentNumber);
				objIData.AddParameter(P_SameExamCode, this.strSameExamCode);
				objIData.AddParameter(P_PageIndex, this.intPageIndex);
				objIData.AddParameter(P_TestScheduleID, this.lngTestScheduleID);
				objIData.AddParameter(P_YearID, this.intYearID);
				objIData.AddParameter(P_Semester, this.intSemester);
				objIData.AddParameter(P_MarkGroup, this.intMarkGroup);
				objIData.AddParameter(P_TestOrder, this.intTestOrder);
				objIData.AddParameter(P_StudentID, this.lngStudentID);
				objIData.AddParameter(P_SameExamID, this.lngSameExamID);
				objIData.AddParameter(P_QuestionCount, this.intQuestionCount);
				objIData.AddParameter(P_ExamID, this.lngExamID);
				objIData.AddParameter(P_SubjectID, this.strSubjectID);
				objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
				objIData.AddParameter(P_TrueAnswerCount, this.intTrueAnswerCount);
				objIData.AddParameter(P_Mark, this.dblMark);
				objIData.AddParameter(P_Passed, this.bolPassed);
				objIData.AddParameter(P_IsUpdated, this.bolIsUpdated);
				objIData.AddParameter(P_ErrorCodeList, this.strErrorCodeList);
				objIData.AddParameter(P_ErrorDesc, this.strErrorDesc);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				this.lngScanFileID = Convert.ToInt32(objIData.ExecStoreToString());
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_ScanDE", objEx);
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
		/// Update : SIM_ScanDE
		/// Cập nhật dữ liệu
		/// Store: SIM_ScanDE_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ScanDE_EDIT");
				objIData.AddParameter(P_ScanFileID, this.lngScanFileID);
				objIData.AddParameter(P_FileName, this.strFileName);
				objIData.AddParameter(P_FilePath, this.strFilePath);
				objIData.AddParameter(P_FileSize, this.lngFileSize);
				objIData.AddParameter(P_FileUpdatedDate, this.dtmFileUpdatedDate);
				objIData.AddParameter(P_ExamStudentNumber, this.strExamStudentNumber);
				objIData.AddParameter(P_SameExamCode, this.strSameExamCode);
				objIData.AddParameter(P_PageIndex, this.intPageIndex);
				objIData.AddParameter(P_TestScheduleID, this.lngTestScheduleID);
				objIData.AddParameter(P_YearID, this.intYearID);
				objIData.AddParameter(P_Semester, this.intSemester);
				objIData.AddParameter(P_MarkGroup, this.intMarkGroup);
				objIData.AddParameter(P_TestOrder, this.intTestOrder);
				objIData.AddParameter(P_StudentID, this.lngStudentID);
				objIData.AddParameter(P_SameExamID, this.lngSameExamID);
				objIData.AddParameter(P_QuestionCount, this.intQuestionCount);
				objIData.AddParameter(P_ExamID, this.lngExamID);
				objIData.AddParameter(P_SubjectID, this.strSubjectID);
				objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
				objIData.AddParameter(P_TrueAnswerCount, this.intTrueAnswerCount);
				objIData.AddParameter(P_Mark, this.dblMark);
				objIData.AddParameter(P_Passed, this.bolPassed);
				objIData.AddParameter(P_IsUpdated, this.bolIsUpdated);
				objIData.AddParameter(P_ErrorCodeList, this.strErrorCodeList);
				objIData.AddParameter(P_ErrorDesc, this.strErrorDesc);
				objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_ScanDE", objEx);
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
		/// Delete : SIM_ScanDE
		/// Xóa dữ liệu
		/// Store: SIM_ScanDE_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ScanDE_DELETE");
				objIData.AddParameter(P_ScanFileID, this.lngScanFileID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_ScanDE", objEx);
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
		/// Store: SIM_ScanDE_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(long? lngScanFileID)
		{
			this.lngScanFileID = lngScanFileID;
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

		public SIM_ScanDE()
		{
		}
		public SIM_ScanDE(long? lngScanFileID)
		{
			this.lngScanFileID = lngScanFileID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_ScanFileID = "@" + C_ScanFileID;
		public const String P_FileName = "@" + C_FileName;
		public const String P_FilePath = "@" + C_FilePath;
		public const String P_FileSize = "@" + C_FileSize;
		public const String P_FileUpdatedDate = "@" + C_FileUpdatedDate;
		public const String P_ExamStudentNumber = "@" + C_ExamStudentNumber;
		public const String P_SameExamCode = "@" + C_SameExamCode;
		public const String P_PageIndex = "@" + C_PageIndex;
		public const String P_TestScheduleID = "@" + C_TestScheduleID;
		public const String P_YearID = "@" + C_YearID;
		public const String P_Semester = "@" + C_Semester;
		public const String P_MarkGroup = "@" + C_MarkGroup;
		public const String P_TestOrder = "@" + C_TestOrder;
		public const String P_StudentID = "@" + C_StudentID;
		public const String P_SameExamID = "@" + C_SameExamID;
		public const String P_QuestionCount = "@" + C_QuestionCount;
		public const String P_ExamID = "@" + C_ExamID;
		public const String P_SubjectID = "@" + C_SubjectID;
		public const String P_ClassSubjectID = "@" + C_ClassSubjectID;
		public const String P_TrueAnswerCount = "@" + C_TrueAnswerCount;
		public const String P_Mark = "@" + C_Mark;
		public const String P_Passed = "@" + C_Passed;
		public const String P_IsUpdated = "@" + C_IsUpdated;
		public const String P_ErrorCodeList = "@" + C_ErrorCodeList;
		public const String P_ErrorDesc = "@" + C_ErrorDesc;
		public const String P_CreatedDate = "@" + C_CreatedDate;
		public const String P_CreatedUser = "@" + C_CreatedUser;
		public const String P_UpdatedDate = "@" + C_UpdatedDate;
		public const String P_UpdatedUser = "@" + C_UpdatedUser;

		#endregion //Parameter names

		#region Column Names

		public const String C_ScanFileID = "ScanFileID";
		public const String C_FileName = "FileName";
		public const String C_FilePath = "FilePath";
		public const String C_FileSize = "FileSize";
		public const String C_FileUpdatedDate = "FileUpdatedDate";
		public const String C_ExamStudentNumber = "ExamStudentNumber";
		public const String C_SameExamCode = "SameExamCode";
		public const String C_PageIndex = "PageIndex";
		public const String C_TestScheduleID = "TestScheduleID";
		public const String C_YearID = "YearID";
		public const String C_Semester = "Semester";
		public const String C_MarkGroup = "MarkGroup";
		public const String C_TestOrder = "TestOrder";
		public const String C_StudentID = "StudentID";
		public const String C_SameExamID = "SameExamID";
		public const String C_QuestionCount = "QuestionCount";
		public const String C_ExamID = "ExamID";
		public const String C_SubjectID = "SubjectID";
		public const String C_ClassSubjectID = "ClassSubjectID";
		public const String C_TrueAnswerCount = "TrueAnswerCount";
		public const String C_Mark = "Mark";
		public const String C_Passed = "Passed";
		public const String C_IsUpdated = "IsUpdated";
		public const String C_ErrorCodeList = "ErrorCodeList";
		public const String C_ErrorDesc = "ErrorDesc";
		public const String C_CreatedDate = "CreatedDate";
		public const String C_CreatedUser = "CreatedUser";
		public const String C_UpdatedDate = "UpdatedDate";
		public const String C_UpdatedUser = "UpdatedUser";

		#endregion //Column names

		#endregion Variable Static		
	}
}
