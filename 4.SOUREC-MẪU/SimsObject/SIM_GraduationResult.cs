
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
	/// Created date 	: 5/29/2012 
	/// Description 
	/// </summary>	
	public partial class SIM_GraduationResult
	{	
		
		#region Methods	
     

        /// Thống kê số liệu sinh viên tốt nghiệp.
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable Search_Graduation_Statistics(params object[] conditions)
        {
            return GetDataTable("[SIM_Graduation_Statistics]", conditions);
        }

        
        ///<summary>
        /// Add : SIM_GraduationResult
        /// Thêm dữ liệu
        /// Store: SIM_GraduationResult_AddOrEdit
        ///</summary>
        public bool AddOrEdit()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_GraduationResult_AddOrEdit");
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_ExamDateID, this.intExamDateID);
                objIData.AddParameter(P_HaveExamRegister1, this.bolHaveExamRegister1);
                objIData.AddParameter(P_HaveExamRegister2, this.bolHaveExamRegister2);
                objIData.AddParameter(P_HaveExamRegister3, this.bolHaveExamRegister3);
                objIData.AddParameter(P_Money, this.dblMoney);
                objIData.AddParameter(P_DecisionNo, this.strDecisionNo);
                objIData.AddParameter(P_Signingdate, this.dtmSigningdate);
                objIData.AddParameter(P_Signer, this.strSigner);
                objIData.AddParameter(P_YearID, this.intYearID);
                objIData.AddParameter(P_Mark1, this.dblMark1);
                objIData.AddParameter(P_Mark2, this.dblMark2);
                objIData.AddParameter(P_Mark3, this.dblMark3);
                objIData.AddParameter(P_SummaryLearningMark, this.dblSummaryLearningMark);
                objIData.AddParameter(P_GraduationExamAverage, this.dblGraduationExamAverage);
                objIData.AddParameter(P_GraduationRankingAverage, this.dblGraduationRankingAverage);
                objIData.AddParameter(P_GraduationLevel, this.strGraduationLevel);
                objIData.AddParameter(P_SpecialType, this.SpecialType);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_ResultReview, this.intResultReview);
                objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm hoặc sửa thông tin SIM_GraduationResult", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        public bool ExamRegister(string listSpecialType)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_GraduationResult_ExamRegister");
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_ExamDateID, this.intExamDateID);
                objIData.AddParameter(P_Money, this.dblMoney);
                objIData.AddParameter("@ListSpecialType", listSpecialType);
                objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
                this.lngGraduationResultID = Convert.ToInt32(objIData.ExecStoreToString());
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm hoặc sửa thông tin đăng ký dự thi tốt nghiệp SIM_GraduationResult", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        public bool ExamRegister(string classID, string listSpecialType)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_GraduationResult_ExamRegister");
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_ExamDateID, this.intExamDateID);
                objIData.AddParameter(P_Money, this.dblMoney);
                objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm hoặc sửa thông tin đăng ký dự thi tốt nghiệp SIM_GraduationResult", objEx);
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
        /// Delete : SIM_GraduationResult
        /// Xóa dữ liệu có liên quan tới ResultReview
        /// Store: SIM_GraduationResult_Delete2 
        ///</summary>
        public bool Delete2()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_GraduationResult_Delete2");
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_ExamDateID, this.intExamDateID);
                objIData.AddParameter(P_ResultReview, this.intResultReview);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_GraduationResult", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        public bool Delete2(bool? haveExamRegister1, bool? haveExamRegister2, bool? haveExamRegister3)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_GraduationResult_Delete2");
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_ExamDateID, this.intExamDateID);
                objIData.AddParameter(P_HaveExamRegister1, haveExamRegister1);
                objIData.AddParameter(P_HaveExamRegister2, haveExamRegister2);
                objIData.AddParameter(P_HaveExamRegister3, haveExamRegister3);
                objIData.AddParameter(P_ResultReview, this.intResultReview);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_GraduationResult", objEx);
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
        /// Lấy kết quả tốt nghiệp của sinh viên
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable Search_Graduation_Result(params object[] conditions)
        {
            return GetDataTable("[SIM_GraduationResult_SearchResult]", conditions);
        }

		#endregion
	
	}
}
