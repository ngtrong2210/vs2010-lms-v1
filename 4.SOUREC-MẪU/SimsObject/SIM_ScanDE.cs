
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
	/// Created date 	: 01/08/2022
	/// Description 
	/// </summary>	
    public partial class SIM_ScanDE
	{	
		
		#region Methods	
		
        ///<summary>
        /// Delete : SIM_ScanMarkDetail
        /// Xóa dữ liệu
        /// Store: SIM_ScanMarkDetail_DELETE 
        ///</summary>
        public bool DeleteAll()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_ScanDE_DeleteAll");
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_ScanDE_DeleteAll", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        public bool DeleteList(string listID)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_ScanDE_DeleteList");
                objIData.AddParameter("@ListID", listID);
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
        /// Update : SIM_ScanMarkFile
        /// Đã cập nhật dữ liệu điểm vào sổ điểm
        /// Store: [SIM_ScanMarkFile_SetUpdated] 
        ///</summary>
        public bool SetUpdated()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_ScanDE_SetUpdated");
                objIData.AddParameter(P_ScanFileID, this.lngScanFileID);
                objIData.AddParameter(P_IsUpdated, this.bolIsUpdated);
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

        public bool SetUpdated(string listID, bool isUpdated)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_ScanDE_SetUpdated_Multi");
                objIData.AddParameter("@ListID", listID);
                objIData.AddParameter(P_IsUpdated, isUpdated);
                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_ScanDE_SetUpdated_Multi", objEx);
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
        /// Cập nhật lại thông tin file scan cũ với các trường dữ liệu như
        /// P_ExamStudentNumber
        /// P_SameExamCode
        /// P_PageIndex
        /// </summary>
        /// <returns></returns>
        public bool UpdateScanInfo()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_ScanDE_UpdateScanInfo");                
                objIData.AddParameter(P_ScanFileID, this.lngScanFileID);

                objIData.AddParameter(P_FilePath, this.strFilePath);

                objIData.AddParameter(P_ExamStudentNumber, this.strExamStudentNumber);
                objIData.AddParameter(P_SameExamCode, this.strSameExamCode);
                objIData.AddParameter(P_PageIndex, this.intPageIndex);

                objIData.AddParameter(P_TestScheduleID, this.lngTestScheduleID);
                objIData.AddParameter(P_YearID, this.intYearID);
                objIData.AddParameter(P_Semester, this.intSemester);
                objIData.AddParameter(P_MarkGroup, this.intMarkGroup);
                objIData.AddParameter(P_TestOrder, this.intTestOrder);

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

        /// <summary>
        /// Xóa nội dung chi tiết của file scan (dùng khi lưu dữ liệu scan lại)
        /// </summary>
        /// <returns></returns>
        public bool DeleteDetail()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_ScanDE_DeleteDetail");
                objIData.AddParameter(P_ScanFileID, this.lngScanFileID);                
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_ScanDE_DeleteDetail", objEx);
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
        /// Xử lý dữ liệu sau khi scan, tìm sv, sổ điểm, đề thi --> sau đó chấm điểm
        /// </summary>
        /// <param name="listID"></param>
        /// <returns></returns>
        public bool ProcessResult(string listID)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_ScanDE_ProcessResult");
                objIData.AddParameter("@ListID", listID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xử lý thông tin SIM_ScanDE_ProcessResult", objEx);
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
