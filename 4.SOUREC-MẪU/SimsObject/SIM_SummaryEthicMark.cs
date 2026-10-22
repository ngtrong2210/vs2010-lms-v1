
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
	public partial class SIM_SummaryEthicMark
	{	
		
		#region Methods	
		
        /////<summary>
        ///// AddOrUpdate : SIM_SummaryEthicMark
        ///// Cập nhật dữ liệu: thêm hoặc cập nhật điểm rèn luyện
        ///// Tự nó biết phân biệt dựa vào kì truyền vào
        ///// Store: SIM_SummaryEthicMark_EDIT 
        /////</summary>
        //public bool AddOrUpdate(int? semester)
        //{
        //    if (!bolIsExistIData)
        //        objIData = DCore.Data.CreateData();
        //    try
        //    {
        //        objIData.CreateNewStoredProcedure("SIM_SummaryEthicMark_AddOrUpdate");
        //        objIData.AddParameter(P_StudentID, this.lngStudentID);
        //        objIData.AddParameter(P_YearID, this.intYearID);
        //        objIData.AddParameter(P_EthicMark, this.dblEthicMark);
        //        objIData.AddParameter(P_EthicLevel, this.strEthicLevel);
        //        objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
        //        objIData.AddParameter("@Semester", semester);
        //        objIData.ExecNonQuery();
        //        return true;
        //    }
        //    catch (Exception objEx)
        //    {
        //        if (bolIsExistIData)
        //            this.RollBackTransaction();
        //        new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_SummaryEthicMark", objEx);
        //        this.objErrorException = objEx;
        //        return false;
        //    }
        //    finally
        //    {
        //        if (!bolIsExistIData)
        //            objIData.Disconnect();
        //    }
        //}

        /// Lấy thông tin ĐIỂM rèn luyện của sinh viên cho môt sinh viên
        /// Store: SIM_SearchSummaryEthicMark
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchSummaryEthicMark(long StudentID)
        {
            return GetDataTable("[SIM_SearchSummaryEthicMark]", "@StudentID", StudentID);
        }

        /// Lấy thông tin ĐIỂM rèn luyện của sinh viên toàn khóa của một lớp        
        /// Store: SIM_SearchSummaryEthicMark
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchSummaryEthicMark(params object[] conditions)
        {
            return GetDataTable("[SIM_SearchSummaryEthicMark]",conditions);
        }

        /// <summary>
        /// Danh sách niên học, có text để add column cho tổng kết điểm rèn luyện toàn khóa
        /// [SIM_SummaryEthicMark_SearchListYear]
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchListYear(params object[] conditions)
        {
            return GetDataTable("[SIM_SummaryEthicMark_SearchListYear]", conditions);
        }

        /// <summary>
        /// NGUYEN VAN MINH
        /// Lấy danh sách sinh viên, cho điểm rèn luyện cả khoá
        /// Store: SIM_SummaryEthicMark_Statistic
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchEthicStatistic(params object[] conditions)
        {
            return GetDataTable("[SIM_SummaryEthicMark_Statistic]", conditions);
        }


        /// <summary>
        /// [SIM_SummaryEthicMark_AddOrEdit]
        /// Xài cho web.
        /// Hiện tại đang dùng update điểm kết quả cuối niên học, học kỳ. Chứ không có điểm gv, sinh viên, ...
        /// </summary>
        /// <returns></returns>
        public bool AddOrEdit()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_SummaryEthicMark_AddOrEdit");
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_YearID, this.intYearID);
                objIData.AddParameter(P_EthicMark, this.dblEthicMark);
                objIData.AddParameter(P_EthicLevel, this.strEthicLevel);
                objIData.AddParameter(P_EthicMark1, this.dblEthicMark1);
                objIData.AddParameter(P_EthicLevel1, this.strEthicLevel1);
                objIData.AddParameter(P_EthicMark2, this.dblEthicMark2);
                objIData.AddParameter(P_EthicLevel2, this.strEthicLevel2);
                objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_SummaryEthicMark_AddOrEdit", objEx);
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
        /// [SIM_SummaryEthicMark_AddOrEditFull]
        /// Xài cho web.
        /// Hiện tại đang dùng update điểm kết quả cuối niên học, học kỳ. có điểm gv, sinh viên, ...
        /// </summary>
        /// <returns></returns>
        public bool AddOrEditFull()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_SummaryEthicMark_AddOrEditFull");
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_YearID, this.intYearID);


                objIData.AddParameter(P_StudentEthicMark, this.dblStudentEthicMark);
                objIData.AddParameter(P_StudentEthicLevel, this.strStudentEthicLevel);
                objIData.AddParameter(P_StudentEthicMark1, this.dblStudentEthicMark1);
                objIData.AddParameter(P_StudentEthicLevel1, this.strStudentEthicLevel1);
                objIData.AddParameter(P_StudentEthicMark2, this.dblStudentEthicMark2);
                objIData.AddParameter(P_StudentEthicLevel2, this.strStudentEthicLevel2);

                objIData.AddParameter(P_TeacherEthicMark, this.dblTeacherEthicMark);
                objIData.AddParameter(P_TeacherEthicLevel, this.strTeacherEthicLevel);
                objIData.AddParameter(P_TeacherEthicMark1, this.dblTeacherEthicMark1);
                objIData.AddParameter(P_TeacherComment1, this.strTeacherComment1);
                objIData.AddParameter(P_TeacherComment2, this.strTeacherComment2);
                objIData.AddParameter(P_TeacherEthicLevel1, this.strTeacherEthicLevel1);
                objIData.AddParameter(P_TeacherEthicMark2, this.dblTeacherEthicMark2);
                objIData.AddParameter(P_TeacherEthicLevel2, this.strTeacherEthicLevel2);

                objIData.AddParameter(P_ClassEthicMark, this.dblClassEthicMark);
                objIData.AddParameter(P_ClassEthicLevel, this.strClassEthicLevel);
                objIData.AddParameter(P_ClassEthicMark1, this.dblClassEthicMark1);
                objIData.AddParameter(P_ClassEthicLevel1, this.strClassEthicLevel1);
                objIData.AddParameter(P_ClassEthicMark2, this.dblClassEthicMark2);
                objIData.AddParameter(P_ClassEthicLevel2, this.strClassEthicLevel2);

                objIData.AddParameter(P_EthicMark, this.dblEthicMark);
                objIData.AddParameter(P_EthicLevel, this.strEthicLevel);
                objIData.AddParameter(P_EthicMark1, this.dblEthicMark1);
                objIData.AddParameter(P_EthicLevel1, this.strEthicLevel1);
                objIData.AddParameter(P_EthicMark2, this.dblEthicMark2);
                objIData.AddParameter(P_EthicLevel2, this.strEthicLevel2);

                objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_SummaryEthicMark_AddOrEditFull", objEx);
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
