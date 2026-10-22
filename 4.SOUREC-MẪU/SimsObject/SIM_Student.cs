
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
	/// Created date 	: 5/23/2011 
	/// Description 
	/// </summary>	
	public partial class SIM_Student
	{	
		
		#region Methods	
		
        /// <summary>
        /// Lấy danh sách sinh viên, cho điểm rèn luyện cả khoá
        /// Store: SIM_Student_SearchEthicMark
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchEthicMark(string classID)
        {
            return GetDataTable("[SIM_Student_SearchEthicMark]", "@ClassID", classID);
        }

        /// <summary>
        /// Lấy danh sách điểm toàn bộ cho một sinh viên, In sổ  điểm,....
        /// SIM_Student_SearchStudentMarkSummary
        /// </summary>
        /// <param name="studentID"></param>
        /// <returns></returns>
        public DataTable SearchStudentMarkSummary(long? studentID)
        {
            return GetDataTable("SIM_Student_SearchStudentMarkSummary", "@StudentID", studentID);
        }
        /// <summary>
        /// Lấy danh sách điểm toàn bộ cho một sinh viên, In sổ  điểm,....
        /// SIM_Student_SearchStudentMarkSummary_Nghe
        /// </summary>
        /// <param name="studentID"></param>
        /// <returns></returns>
        public DataTable SearchStudentMarkSummary_Nghe(long? studentID)
        {
            return GetDataTable("SIM_Student_SearchStudentMarkSummary_Nghe", "@StudentID", studentID);
        }
        /// <summary>
        /// Lấy danh sách điểm toàn bộ cho một sinh viên, In sổ  điểm của học kỳ,....
        /// SIM_Student_SearchStudentMarkSummary2
        /// </summary>
        /// <param name="studentID"></param>
        /// <returns></returns>
        public DataTable SearchStudentMarkSummary2(long? studentID, int YearID, int Semester)
        {
            return GetDataTable("SIM_Student_SearchStudentMarkSummary2", "@StudentID", studentID, "@YearID", YearID, "@Semester", Semester);
        }
        /// <summary>
        /// Lấy danh sách điểm năm 01 cho một sinh viên, In sổ  điểm,....
        /// SIM_Student_SearchStudentMarkSummary1
        /// </summary>
        /// <param name="studentID"></param>
        /// <returns></returns>
        public DataTable SearchStudentMarkSummary1(long? studentID)
        {
            return GetDataTable("SIM_Student_SearchStudentMarkSummary1", "@StudentID", studentID);
        }
        

        ///<summary>
        /// Lấy thông tin 1 sinh viên
        /// Store: SIM_Student_Search1
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SIM_Student_Search1(long StudentID)
        {
            return GetDataTable("[SIM_Student_Search1]", "@StudentID", StudentID);
        }


        ///<summary>
        /// /// Thống kê theo cơ cấu xã hội
        /// Store: SIM_Student_Socialstructure
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchSocialstructure(string @CourseID)
        {
            return GetDataTable("[SIM_Student_Socialstructure]", "@CourseID", @CourseID);
        }

        /// /// Xét dự thi tốt nghiệp QC14
        /// Store: SIM_ReviewGraduationExam_14
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchReviewGraduationExam_QC14(string @CourseID, string TrainingLevelID, object @SpecialBranchID, object ClassID, int OrderReview, int RegulationID, string ListSpecialType, int specialType)
        {
            return GetDataTable("[SIM_ReviewGraduationExam_14]", "@CourseID", @CourseID, "@TrainingLevelID", @TrainingLevelID, "@SpecialBranchID", @SpecialBranchID, "@ClassID",
                @ClassID, "@OrderReview", OrderReview, "@RegulationID", RegulationID, "@ListSpecialType", ListSpecialType, "@SpecialType", specialType);
        }
        /// /// Xét dự thi tốt nghiệp QC40
        /// Store: SIM_ReviewGraduationExam_40
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchReviewGraduationExam_QC40(string CourseID, string TrainingLevelID, object @specialBranchID, object ClassID, int OrderReview, int RegulationID, string ListSpecialType, int specialType)
        {
            return GetDataTable("[SIM_ReviewGraduationExam_40]", "@CourseID", CourseID, "@TrainingLevelID", TrainingLevelID, "@SpecialBranchID", @specialBranchID, "@ClassID", ClassID, "@OrderReview", OrderReview, "@RegulationID", RegulationID, "@ListSpecialType", ListSpecialType, "@SpecialType", specialType);
        }
        /// /// Xét dự thi tốt nghiệp QC22 VH
        /// Store: SIM_ReviewGraduationExamVH_QC22
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SIM_ReviewGraduationExamVH_QC22(string CourseID, string TrainingLevelID, object @specialBranchID, object ClassID, int OrderReview, int RegulationID, string ListSpecialType, int specialType)
        {
            return GetDataTable("[SIM_ReviewGraduationExamVH_QC22]", "@CourseID", CourseID, "@TrainingLevelID", TrainingLevelID, "@SpecialBranchID", @specialBranchID, "@ClassID", ClassID, "@OrderReview", OrderReview, "@RegulationID", RegulationID, "@ListSpecialType", ListSpecialType, "@SpecialType", specialType);
        }
        /// /// Xét dự thi tốt nghiệp QC40 danh cho Văn hóa
        /// Store: SIM_ReviewGraduationExam_40_5
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchReviewGraduationExam_QC40_5(string @CourseID, string TrainingLevelID, object @specialBranchID, object ClassID, int OrderReview, int RegulationID, string ListSpecialType, int specialType)
        {
            return GetDataTable("[SIM_ReviewGraduationExam_40_5]", "@CourseID", @CourseID, "@TrainingLevelID", @TrainingLevelID, "@SpecialBranchID", @specialBranchID, "@ClassID", @ClassID, "@OrderReview", OrderReview, "@RegulationID", RegulationID, "@ListSpecialType", ListSpecialType,"@SpecialType",specialType);
        }
        /// /// Xét dự thi tốt nghiệp QC25
        /// Store: SIM_ReviewGraduationExam_25
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchReviewGraduationExam_QC25(string @CourseID, string TrainingLevelID, object @specialBranchID, object ClassID, int OrderReview, string ListSpecialType)
        {
            return GetDataTable("[SIM_ReviewGraduationExam_25]", "@CourseID", @CourseID, "@TrainingLevelID", @TrainingLevelID, "@SpecialBranchID", @specialBranchID, "@ClassID", @ClassID, "@OrderReview", OrderReview , "@ListSpecialType", ListSpecialType);
        }
        ///<summary>
        /// /// Xét dự thi tốt nghiệp QC43
        /// Store: SIM_ReviewGraduationExam_43
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchReviewGraduationExam_QC43(string @CourseID, string TrainingLevelID, object specialBranchID, object ClassID, int OrderReview, int RegulationID, string ListSpecialType)
        {
            return GetDataTable("[SIM_ReviewGraduationExam_43]", "@CourseID", @CourseID, "@TrainingLevelID", @TrainingLevelID, "@SpecialBranchID", specialBranchID, "@ClassID", @ClassID, "@OrderReview", OrderReview, "@RegulationID", RegulationID, "@ListSpecialType", ListSpecialType);
        }

        /// <summary>
        /// TC, cđ chuyên nghiệp 2017
        /// </summary>
        public DataTable SearchReviewGraduationExam_QC09(string CourseID, string TrainingLevelID, object @specialBranchID, object ClassID, int OrderReview, int RegulationID, string ListSpecialType, int specialType)
        {
            return GetDataTable("[SIM_ReviewGraduationExam_09]", "@CourseID", CourseID, "@TrainingLevelID", TrainingLevelID, "@SpecialBranchID", @specialBranchID, "@ClassID", ClassID, "@OrderReview", OrderReview, "@RegulationID", RegulationID, "@ListSpecialType", ListSpecialType, "@SpecialType", specialType);
        }

        /// Update : SIM_Student
        /// Cập nhật dữ liệu điểm rèn luyện dinh viên
        /// Store: SIM_Student_UpdateEthicMark 
        ///</summary>
        public bool UpdateEthicMark()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Student_UpdateEthicMark");
                objIData.AddParameter(P_StudentID, this.lngStudentID);             
                objIData.AddParameter(P_EthicMark, this.dblEthicMark);
                objIData.AddParameter(P_EthicLevel, this.strEthicLevel);
                objIData.AddParameter(P_ClassEthicMark, this.dblClassEthicMark);
                objIData.AddParameter(P_ClassEthicLevel, this.strClassEthicLevel);
      
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin điểm rèn luyện SIM_Student", objEx);
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
        /// Update : SIM_Student.
        /// Cập nhật dữ liệu trạng thái sinh viên Set Status
        /// Store: SIM_Student_UpdateStatus
        ///</summary>
        public bool UpdateStatus()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Student_UpdateStatus");
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_Status , this.intStatus);
                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin kỷ luật", objEx);
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
        /// Update : SIM_Student.
        /// Cập nhật thứ tự sinh viên.
        /// Store: UpdateStatic
        ///</summary>
        public bool UpdateOrderIndex()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Student_UpdateOrderIndex");
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_OrderIndex, this.lngOrderIndex);
                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin thứ tự sinh viên", objEx);
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
        /// Cập nhật thứ tự nhóm lớp cho ds lớp
        /// SIM_Student_UpdateGroupSmallClassRegister
        /// </summary>
        /// <returns></returns>
        public bool UpdateGroupSmallClassRegister()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Student_UpdateGroupSmallClassRegister");
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_GroupSmallClassRegister, this.intGroupSmallClassRegister);
                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin thứ tự nhóm lớp sinh viên", objEx);
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
        /// Lấy danh sách sinh viên, tao lai ma so sinh vien. Lấy hết mọi trạng thái
        /// Store: [SIM_Student_SearchForMakeCode]
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchForMakeCode(string classID)
        {
            return GetDataTable("[SIM_Student_SearchForMakeCode]", "@ClassID", classID);
        }


        ///<summary>
        /// Update : SIM_Student
        /// Cập nhật dữ liệu MA SO SINH VIEN
        /// Store: SIM_Student_UpdateStudentCode 
        ///</summary>
        public bool UpdateStudentCode()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Student_UpdateStudentCode");
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_StudentCode, this.strStudentCode);
                objIData.AddParameter(P_OrderIndex, this.lngOrderIndex);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Tạo mã sinh viên không thành công", objEx);
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
        /// Lấy ds sinh viên chỉ các thông tin chính, để sử dụng cho các form tính toán tổng hợp
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchSimpleList(params object[] conditions)
        {
            return GetDataTable("[SIM_Student_SearchSimpleList]", conditions);
        }

        /// <summary>
        /// SP name	: [SIM_Student_SearchForMakeExamSchedule]  	       
	    /// Lấy ds sinh viên có học môn học, trong niên, kì. 
		/// Nếu đã có trong SIM_ExamSchedule thì đánh dấu xoá để không view
        /// SubjectID, YearID, Semester, TestOrder
        /// [SIM_Student_SearchForMakeExamSchedule]
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchForMakeExamSchedule(params object[] conditions)
        {
            return GetDataTable("SIM_Student_SearchForMakeExamSchedule", conditions);
        }

        /// <summary>
        /// DS sinh viên để tổ chức thi tốt nghiệp
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchForMakeGraduationExamSchedule(params object[] conditions)
        {
            return GetDataTable("SIM_Student_SearchForMakeGraduationExamSchedule", conditions);
        }

        /// <summary>
        /// Thống kê theo dân tộc
        /// [SIM_Student_Ethnicity]
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable EthnicityStatistic(params object[] conditions)
        {
            return GetDataTable("SIM_Student_Ethnicity", conditions);
        }

        /// <summary>
        /// Thống kê theo tôn giáo
        /// [SIM_Student_Religion]
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable ReligionStatistic(params object[] conditions)
        {
            return GetDataTable("SIM_Student_Religion", conditions);
        }

        // <summary>
        /// [SIM_StudentCollection_SearchForStatistic]
        /// Get ds lớp để làm thống kê
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchForStatistic(params object[] conditions)
        {
            return GetDataTable("SIM_Student_SearchForStatistic", conditions);
        }

        /// <summary>
        /// Kiểm tra hồ sơ sinh viên khi edit
        /// [SIM_Student_CheckForEdit]        
        /// </summary>
        /// <param name="conditions">@Fullname, @Birthday, @BirthMonth, @BirthYear, @StudentCode</param>
        /// <returns>Trả về chuỗi báo lỗi, nếu '' thì ok</returns>
        public string CheckForEdit(params object[] conditions)
        {
            DataTable dtb = GetDataTable("SIM_Student_CheckForEdit", conditions);
            if (dtb != null && dtb.Rows.Count > 0)
                return dtb.Rows[0][0].ToString();
            return "";
        }

        /// <summary>
        /// Cập nhật điểm tổng kết toàn khóa vào sinh viên
        /// </summary>
        /// <param name="studentID"></param>
        /// <param name="learningSummary"></param>
        /// <param name="learningLevel"></param>
        /// <returns></returns>
        public bool UpdateLearningSummaryOfCourse(long studentID, double? learningSummary, string learningLevel)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Student_UpdateLearningSummaryOfCourse");
                objIData.AddParameter("@StudentID", studentID);
                objIData.AddParameter("@LearningSummary",learningSummary);
                objIData.AddParameter("@LearningLevel", learningLevel);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Cập nhật điểm tổng kết học tập sinh viên thất bại", objEx);
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
        /// Cập nhật lại họ tên tiếng anh 
        /// SIM_Student_UpdateFullnameEn
        /// </summary>
        /// <returns></returns>
        //public bool UpdateFullnamEn()
        //{
        //    if (!bolIsExistIData)
        //        objIData = DCore.Data.CreateData();
        //    try
        //    {
        //        objIData.CreateNewStoredProcedure("SIM_Student_UpdateFullnameEn");
        //        objIData.AddParameter(P_StudentID, this.lngStudentID);
        //        objIData.AddParameter(P_FullnameEn, this.strFullnameEn);

        //        objIData.ExecNonQuery();
        //        return true;
        //    }
        //    catch (Exception objEx)
        //    {
        //        if (bolIsExistIData)
        //            this.RollBackTransaction();
        //        new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin điểm rèn luyện SIM_Student", objEx);
        //        this.objErrorException = objEx;
        //        return false;
        //    }
        //    finally
        //    {
        //        if (!bolIsExistIData)
        //            objIData.Disconnect();
        //    }
        //}
        public bool UpdateFullnamEn()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Student_ProcessFullnameEn");
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi hiệu chỉnh hồ sơ học viên", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }



        public bool UpdateClass()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Student_UpdateClass");
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_ClassID, this.strClassID);
                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);   
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin lớp SIM_Student", objEx);
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
