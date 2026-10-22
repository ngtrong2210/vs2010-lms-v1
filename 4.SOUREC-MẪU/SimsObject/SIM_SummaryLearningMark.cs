
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
	/// Created date 	: 5/26/2012 
	/// Description 
	/// </summary>	
	public partial class SIM_SummaryLearningMark
	{	
		
		#region Methods	
		
        ///<summary>
        /// Add or Update : SIM_SummaryLearningMark
        /// Thêm or Cập nhật dữ liệu: phân biệt = kì
        /// Store: SIM_SummaryLearningMark_EDIT 
        ///</summary>
        public bool AddOrUpdate(int? semester)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_SummaryLearningMark_AddOrUpdate");
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_YearID, this.intYearID);
                objIData.AddParameter(P_Summary, this.dblSummary);
                objIData.AddParameter(P_LearningLevel, this.strLearningLevel);                
                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
                objIData.AddParameter("@Semester", semester);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_SummaryLearningMark", objEx);
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
        /// [SIM_SubjectMark_AutoSummary]
        /// Cập nhật tự động tổng kết học tập
        /// </summary>
        /// <param name="pars"></param>
        /// <returns></returns>
        public bool AutoLearningSummary( params object[] pars)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_SummaryLearningMark_AutoSummary");
                objIData.AddParameter(pars);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store SIM_SubjectMark_AutoSummary trong SIM_SummaryLearningMark", objEx);
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
        /// Tổng kết năm, cho tín chỉ 09
        /// </summary>
        /// <param name="pars"></param>
        /// <returns></returns>
        public bool AutoLearningSummary43(params object[] pars)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_SummaryLearningMark_AutoSummary43");
                objIData.AddParameter(pars);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store SIM_SubjectMark_AutoSummary trong SIM_SummaryLearningMark", objEx);
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
        /// SIM_SummaryLearningMark_AutoSummaryOfCourse
        /// Tổng kết toàn khoá (ngoại trừ dòng lớp tín chỉ)
        /// </summary>
        /// <param name="pars"></param>
        /// <returns></returns>
        public bool AutoLearningSummaryOfCourse(params object[] pars)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_SummaryLearningMark_AutoSummaryOfCourse");
                objIData.AddParameter(pars);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store SIM_SummaryLearningMark_AutoSummaryOfCourse trong SIM_Student", objEx);
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
        /// SIM_SummaryLearningMark_AutoSummaryOfCourse43
        /// Tổng kết toàn khoá cho các dòng lớp tín chỉ
        /// </summary>
        /// <param name="pars"></param>
        /// <returns></returns>
        public bool AutoLearningSummaryOfCourse43(params object[] pars)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_SummaryLearningMark_AutoSummaryOfCourse43");
                objIData.AddParameter(pars);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store SIM_SummaryLearningMark_AutoSummaryOfCourse43 trong SIM_Student", objEx);
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
