
#region Using

using System;
using System.Data;
using System.Collections;
using DCore;

#endregion

namespace SimsObject
{
    /// <summary>
	/// Created by 		: NGUYỄN VĂN VIỆT 
	/// Created date 	: 5/12/2012 
	/// Description 
	/// </summary>	
	public partial class SIM_SubjectMark
	{	
		
		#region Methods	
		
        /// <summary>
        /// NGUYỄN VĂN VIỆT
        /// Danh sách sinh viên đăng ký dự thi tốt nghiệp, để edit cũng là để view
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable GraduationExamRegister(params object[] conditions)
        {
            return GetDataTable("[SIM_SubjectMark_GraduationExamRegister]", conditions);
        }

        /// <summary>
        /// Allow Register: Xem thử với sinh viên đó, môn học lớp đó, có đc quyền thi tốt nghiệp nữa hông
        /// SIM_SubjectMark_GraduationExamRegister_Allow
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable GraduationExamRegister_Allow(params object[] conditions)
        {
            return GetDataTable("[SIM_SubjectMark_GraduationExamRegister_Allow]", conditions);
        }        

           

        /// <summary>
        /// NGUYỄN VĂN VIỆT
        /// Lấy danh sách sinh viên theo một môn học lớp: Sinh viên của lớp đó, hoặc có sẵn sổ điểm do add trước khi học lại, chuyển lớp, hoặc tín chỉ
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchForEdit(params object[] conditions)
        {
            return GetDataTable("[SIM_SubjectMark_SearchForEdit]", conditions);
        }

        /// <summary>
        /// NGUYỄN VĂN VIỆT
        /// Lấy dữ liệu bảng điểm cuối cùng của lớp, nếu cùng môn mà học nhiều lần thì lấy lần cuối cùng.
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchFinal(params object[] conditions)
        {
            return GetDataTable("[SIM_SubjectMark_SearchFinal]", conditions);
        }

        /// <summary>
        /// NGUYỄN VĂN VIỆT
        /// Lấy dữ liệu bảng điểm lần học đầu tiên
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchFirst(params object[] conditions)
        {
            return GetDataTable("[SIM_SubjectMark_SearchFirst]", conditions);
        }

        /// Lấy dữ liệu bảng điểm của các môn tốt nghiệp.
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchSubjectMark_Graduation(params object[] conditions)
        {
            return GetDataTable("[SIM_SubjectMark_Graduation]", conditions);
        }
       
        /// <summary>
        /// Bỏ store này, bỏ phương thức này
        /// </summary>
        /// <param name="studentID"></param>
        /// <returns></returns>
        public DataTable _SearchAllOfStudent(long studentID)
        {
            return GetDataTable("[SIM_SubjectMark_SearchAllOfStudent]", "@StudentID", studentID);
        }

        /// Lấy danh điểm sinh viên đã đăng ký học phần tín chỉ.
        /// Store: SIM_SubjectMark_SearchForRegister43
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchForRegister43(params object[] conditions)
        {
            return GetDataTable("SIM_SubjectMark_SearchForRegister43", conditions);
        }
        

        /// <summary>
        /// Lấy danh sách sinh viên dự thi theo từng môn học
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable ExamStudentList(long classSubjectID, int? intTestOrder, int ? YearID, int ? SemesterID)
        {
            return GetDataTable("[SIM_SubjectMark_ExamStudentList]", "@ClassSubjectID", classSubjectID, "@TestOrder", intTestOrder, "@YearID", YearID, "SemesterID", SemesterID);
        }



        /// Lấy danh sách sinh viên nợ môn học
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable DebtClassSubjectSummary(int? YearID, int? Semester, object ClassID, object ScienceID, string CourseID, string TrainingLevelID, string BranchID, string SpecialBranchID)
        {
            return GetDataTable("[SIM_DebtClassSubjectSummary]", "@YearID", YearID, "@Semester", Semester, "@ClassID", ClassID, "@ScienceID", ScienceID, "@CourseID", CourseID, "@TrainingLevelID", TrainingLevelID, "@BranchID", BranchID, "@SpecialBranchID", SpecialBranchID);
        }
        
        /// <summary>
        /// Lấy danh sách các môn nợ theo từng sinh viên.
        /// Đang không sử dụng
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable _DebtClassSubject(int StudentID)
        {
            return GetDataTable("[SIM_DebtClassSubjectSummaryDetail]", "@StudentID", StudentID);
        }

        /// Lấy danh sách sinh vien dat hoc bong QC14
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable ReviewScholarship_QC14(int? YearID, int? Semester, object ClassID, object ScienceID, object CourseID, 
                                            string TrainingLevelID, object BranchID, object SpecialBranchID, 
                                            object receiptDate, object quotaPer)
        {
            return GetDataTable("[SIM_ReviewScholarship_QC14]", "@YearID", YearID, "@Semester", Semester, "@ClassID", ClassID, "@ScienceID", ScienceID, "@CourseID",
                CourseID, "@TrainingLevelID", TrainingLevelID, "@BranchID", BranchID, "@SpecialBranchID", SpecialBranchID,
                "@ReceiptDate", receiptDate, "@QuotaPer", quotaPer);
                
        }

        /// Lấy danh sách sinh vien dat hoc bong QC09
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable ReviewScholarship_QC09(int? YearID, int? Semester, object ClassID, object ScienceID, object CourseID,
                                            string TrainingLevelID, object BranchID, object SpecialBranchID,
                                            object receiptDate, object quotaPer)
        {
            return GetDataTable("[SIM_ReviewScholarship_QC09]", "@YearID", YearID, "@Semester", Semester, "@ClassID", ClassID, "@ScienceID", ScienceID, "@CourseID",
                CourseID, "@TrainingLevelID", TrainingLevelID, "@BranchID", BranchID, "@SpecialBranchID", SpecialBranchID,
                "@ReceiptDate", receiptDate, "@QuotaPer", quotaPer);

        }
        /// Lấy danh sách sinh vien dat hoc bong QC04
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable ReviewScholarship_QC04(int? YearID, int? Semester, object ClassID, object ScienceID, object CourseID,
                                            string TrainingLevelID, object BranchID, object SpecialBranchID,
                                            object receiptDate, object quotaPer)
        {
            return GetDataTable("[SIM_ReviewScholarship_QC04]", "@YearID", YearID, "@Semester", Semester, "@ClassID", ClassID, "@ScienceID", ScienceID, "@CourseID",
                CourseID, "@TrainingLevelID", TrainingLevelID, "@BranchID", BranchID, "@SpecialBranchID", SpecialBranchID,
                "@ReceiptDate", receiptDate, "@QuotaPer", quotaPer);

        }
        /// Lấy danh sách sinh vien dat hoc bong QC 25
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable ReviewScholarship_QC25(int? YearID, int? Semester, object ClassID, object ScienceID, object CourseID, string TrainingLevelID, object BranchID, object SpecialBranchID)
        {
            return GetDataTable("[SIM_ReviewScholarship_QC25]", "@YearID", YearID, "@Semester", Semester, "@ClassID", ClassID, "@ScienceID", ScienceID, "@CourseID", CourseID, "@TrainingLevelID", TrainingLevelID, "@BranchID", BranchID, "@SpecialBranchID", SpecialBranchID);
        }

        /// Lấy danh sách sinh vien dat hoc bong QC40
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable ReviewScholarship_QC40(int? YearID, int? Semester, object ClassID, object ScienceID, object CourseID, string TrainingLevelID, object BranchID, object SpecialBranchID)
        {
            return GetDataTable("[SIM_ReviewScholarship_QC40]", "@YearID", YearID, "@Semester", Semester, "@ClassID", ClassID, "@ScienceID", ScienceID, "@CourseID", CourseID, "@TrainingLevelID", TrainingLevelID, "@BranchID", BranchID, "@SpecialBranchID", SpecialBranchID);
        }

        /// Lấy danh sách sinh vien dat hoc bong
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable ReviewScholarship_QC43(int? YearID, int? Semester, object ClassID, object ScienceID, object CourseID, string TrainingLevelID, object BranchID, object SpecialBranchID, int RegulationID)
        {
            return GetDataTable("[SIM_ReviewScholarship_QC43]", "@YearID", YearID, "@Semester", Semester, "@ClassID", ClassID, "@ScienceID", ScienceID, "@CourseID", CourseID, "@TrainingLevelID", TrainingLevelID, "@BranchID", BranchID, "@SpecialBranchID", SpecialBranchID);
        }

        ///<summary>
        /// Update : SIM_SubjectMark
        /// Cập nhật dữ liệu sinh viên được dư thi kết thúc môn học
        /// Cập nhật luôn STT trong ds dự thi
        /// Store: SIM_SubjectMark_UpdateAllowExam 
        ///</summary>
        public bool UpdateAllowExam(int orderTest = 1)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_SubjectMark_UpdateAllowExam");
                objIData.AddParameter(P_SubjectMarkID, this.lngSubjectMarkID);                
                objIData.AddParameter(P_AllowExam, this.bolAllowExam );
                objIData.AddParameter(P_AllowExamDescription, this.strAllowExamDescription);
                objIData.AddParameter(P_OrderIndexExam, this.intOrderIndexExam); // thứ tự trong ds dự thi
                objIData.AddParameter("@OrderTest",orderTest); // lần thi
                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin thành công", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        /// <summary>
        /// Update số thứ tự trong sổ điểm để cho việc scan điể quá trình
        /// SIM_SubjectMark_UpdateOrderIndex
        /// </summary>
        /// <returns></returns>
        public bool UpdateOrderIndex()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_SubjectMark_UpdateOrderIndex");
                objIData.AddParameter(P_SubjectMarkID, this.lngSubjectMarkID);                                
                objIData.AddParameter(P_OrderIndex, this.intOrderIndex); // thứ tự trong ds scan điểm quá trình
                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin thành công", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        /// <summary>
        /// Reset số thứ tự trong sổ điểm để cho việc scan điểm thi
        /// SIM_SubjectMark_ResetOrderIndexExam
        /// </summary>
        /// <returns></returns>
        public bool ResetOrderIndexExam(int orderTest = 1)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_SubjectMark_ResetOrderIndexExam");
                objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
                objIData.AddParameter("@OrderTest", orderTest); // lần thi
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin thành công", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        /// <summary>
        /// Reset số thứ tự trong sổ điểm để cho việc scan điể quá trình
        /// SIM_SubjectMark_ResetOrderIndex
        /// </summary>
        /// <returns></returns>
        public bool ResetOrderIndex()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_SubjectMark_ResetOrderIndex");
                objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin thành công", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        /// <summary>
        /// Lấy ds môn học lớp của lớp tín chỉ ở một niên kì. Môn học lớp nào có sinh viên đăng ký học thì lấy
        /// Dùng cho tổng kết môn
        /// </summary>
        /// <param name="yearID"></param>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable GetListSubject43(params object[] conditions)
        {
            return GetDataTable("SIM_SubjectMark_ListSubject43", conditions);
        }

        /// <summary>
        /// NGUYỄN VĂN VIỆT
        /// Lấy dữ liệu bảng điểm cho lớp tín chỉ. DS sổ điểm của sv học những môn ở đúng niên kì đó. Không lấy lần cuối cùng.
        /// SIM_SubjectMark_SearchOfClass43
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchOfClass43(params object[] conditions)
        {
            return GetDataTable("SIM_SubjectMark_SearchOfClass43", conditions);
        }

        /// <summary>
        /// Duyệt kết quả học tập cho sinh viên, xem lên lớp hay ở lại
        /// Xét theo năm học. QC 22
        /// [SIM_SubjectMark_ReviewContinueLearning22]
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable ReviewContinueLearning22(params object[] conditions)
        {
            return GetDataTable("SIM_SubjectMark_ReviewContinueLearning22", conditions);
        }

        /// <summary>
        /// Duyệt kết quả học tập cho sinh viên, xem lên lớp hay ở lại
        /// Xét theo năm học. QC 40
        /// [SIM_SubjectMark_ReviewContinueLearning40]
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable ReviewContinueLearning40(params object[] conditions)
        {
            return GetDataTable("SIM_SubjectMark_ReviewContinueLearning40", conditions);
        }

        /// <summary>
        /// Thống kê chất lượng đào tạo
        /// [SIM_QualityTraining_Search]
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable QualityTraining_Search(params object[] conditions)
        {
            return GetDataTable("SIM_QualityTraining_Search", conditions);
        }

        /// <summary>
        /// Duyệt kết quả học tập cho sinh viên, xem lên lớp hay ở lại
        /// Xét theo năm học hoặc theo kì. QC 43
        /// [SIM_SubjectMark_ReviewContinueLearning43]
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable ReviewContinueLearning43(params object[] conditions)
        {
            return GetDataTable("SIM_SubjectMark_ReviewContinueLearning43", conditions);
        }

        /// <summary>
        /// Thống kê số liệu xét hội đồng
        /// [SIM_SubjectMark_ConsiderCouncil]
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable ConsiderCouncil(params object[] conditions)
        {
            return GetDataTable("SIM_SubjectMark_ConsiderCouncil", conditions);
        }
        ///<summary>
        /// Update : SIM_SubjectMark
        /// Cập nhật đăng ký dự thi
        /// Store: [SIM_SubjectMark_EditExamRegister] 
        ///</summary>
        public bool UpdateExamRegister()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_SubjectMark_EditExamRegister");
                objIData.AddParameter(P_SubjectMarkID, this.lngSubjectMarkID);                
                objIData.AddParameter(P_HaveExamRegister, this.bolHaveExamRegister);                
                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_SubjectMark", objEx);
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
        /// Import : SIM_SubjectMark
        /// Nhập điểm từ excel. Có thì edit, không thì thêm mới những cột Điểm TB, Thi và Tổng kết
        /// Store: [SIM_SubjectMark_Import] 
        ///</summary>
        public bool Import()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_SubjectMark_Import");
                objIData.AddParameter(P_SubjectMarkID, this.lngSubjectMarkID);
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_SubjectID, this.strSubjectID);                
                objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);                
                objIData.AddParameter(P_TestAverage, this.dblTestAverage);
                objIData.AddParameter(P_Exam1, this.dblExam1);
                objIData.AddParameter(P_Exam2, this.dblExam2);
                objIData.AddParameter(P_Exam3, this.dblExam3);
                objIData.AddParameter(P_Summary1, this.dblSummary1);
                objIData.AddParameter(P_Summary2, this.dblSummary2);
                objIData.AddParameter(P_Summary3, this.dblSummary3);                
                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
                this.lngSubjectMarkID = Convert.ToInt32(objIData.ExecStoreToString());
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi import thông tin SIM_SubjectMark", objEx);
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
        /// Delete : SIM_SubjectMark
        /// Xóa dữ liệu sổ điểm của một môn học lớp
        /// Store: [SIM_SubjectMark_DeleteOfClassSubject] 
        ///</summary>
        public bool DeleteOfClassSubject()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_SubjectMark_DeleteOfClassSubject");
                objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin sổ điểm của môn học lớp SIM_SubjectMark", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }





        public bool UpdateIsLast(string subjectID = null)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_SubjectMark_UpdateIsLast");
                objIData.AddParameter("@SubjectID", subjectID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật SIM_SubjectMark_UpdateIsLast trong SIM_SubjectMark", objEx);
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
        /// Update : SIM_SubjectMark
        /// Cập nhật dữ liệu
        /// Store: SIM_SubjectMark_AutoUpdateOrderLearningFor43
        ///</summary>
        public bool UpdateIsOrderLearning()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_SubjectMark_AutoUpdateOrderLearning");
                objIData.AddParameter(P_SubjectMarkID, this.lngSubjectMarkID);
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_SubjectID, this.strSubjectID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_SubjectMark", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        /// <summary>
        /// Cập nhật học phí
        /// Money and IsPayment
        /// </summary>
        /// <returns></returns>
        public bool UpdateMoney()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_SubjectMark_UpdateMoney");
                objIData.AddParameter(P_SubjectMarkID, this.lngSubjectMarkID);
                objIData.AddParameter(P_Money, this.decMoney); // học phí tín chỉ
                objIData.AddParameter(P_IsPayment, this.bolIsPayment); // đã thu
                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin thành công", objEx);
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
        /// Đăng ký nhanh học viên vào sổ điểm
        /// Store: SIM_SubjectMark_QuickRegister 
        /// Tham số:
        ///     StudentID: mã sinh viên
        ///     ClassSubjectID: môn học lớp (nếu ghép hay tách thì store tự xử lý lưu sổ điểm về lớp gốc)
        ///     P_CreatedUser
        ///</summary>        
        /// <param name="isTeacher">Là giáo viên đăng ký hộ. Là sv đăng đăng ký thì kiểm FinishRegister, nếu là gv, quản lý thì không cần ngày này</param>
        /// <returns></returns>
        public bool QuickRegister(bool isTeacher = false)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_SubjectMark_QuickRegister");
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
                objIData.AddParameter("@IsTeacher", isTeacher);
                objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
                this.lngSubjectMarkID = Convert.ToInt64(objIData.ExecStoreToString());
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_SubjectMark_QuickRegister", objEx);
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
        /// Đăng ký nhanh học viên vào sổ điểm theo tín chỉ (sv đăng ký tín chỉ trên web)
        /// Store: SIM_SubjectMark_QuickRegister43 
        ///</summary>
        public bool QuickRegister43()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_SubjectMark_QuickRegister43");
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
                objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
                this.lngSubjectMarkID = Convert.ToInt64(objIData.ExecStoreToString());
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_SubjectMark_QuickRegister43", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

		#endregion
	
	}
}
