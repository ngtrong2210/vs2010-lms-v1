
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
	/// Created date 	: 7/14/2012 
	/// Description 
	/// </summary>	
	public partial class SIM_StudentCollection
	{	
		
		#region Methods	
		
				
        ///<summary>
        /// Update : SIM_StudentCollection
        /// Cập nhật dữ liệu
        /// Store: SIM_StudentCollection_UpdateResult 
        ///</summary>
        public bool UpdateResult()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_StudentCollection_UpdateResult");
                objIData.AddParameter(P_StudentCollectionID, this.lngStudentCollectionID);                
                objIData.AddParameter(P_Result, this.intResult);
                objIData.AddParameter(P_CerNo, this.strCerNo);
                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trúng tuyển SIM_StudentCollection", objEx);
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
        /// NGUYỄN VĂN VIỆT
        /// Danh sách HỒ SƠ TUYỂN SINH, để duyệt xét tuyển
        /// [SIM_StudentCollection_SearchForReview]
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchForReview(params object[] conditions)
        {
            return GetDataTable("[SIM_StudentCollection_SearchForReview]", conditions);
        }

        ///<summary>
        /// [SIM_StudentCollection_FillToClass]
        /// Chuyển hồ sơ tuyển sinh vào lớp học        
        ///</summary>
        public bool FillToClass(string listStudentCollectionID, string classID, string createdUser)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_StudentCollection_FillToClass");
                objIData.AddParameter("@ListStudentCollectionID", listStudentCollectionID);
                objIData.AddParameter("@ClassID", classID);
                objIData.AddParameter("@CreatedUser", createdUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi chuyển thông hồ sơ sinh viên vào lớp học", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        // <summary>
        /// Thống kê theo dân tộc
        /// [SIM_StudentCollection_Ethnicity]
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable EthnicityStatistic(params object[] conditions)
        {
            return GetDataTable("SIM_StudentCollection_Ethnicity", conditions);
        }

        /// <summary>
        /// Thống kê theo tôn giáo
        /// [SIM_StudentCollection_Religion]
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable ReligionStatistic(params object[] conditions)
        {
            return GetDataTable("SIM_StudentCollection_Religion", conditions);
        }

        /// <summary> 
        /// Danh sách cac nghề
        /// [SIM_SpecialBranch_Search]
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SpecialBranchStatistic(params object[] conditions)
        {
            return GetDataTable("SIM_SpecialBranch_Search", conditions);
        }

        // <summary>
        /// SIM_Class_SearchForStatistic
        /// Get ds lớp để làm thống kê tuyển sinh theo nghề
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchForStatistic(params object[] conditions)
        {
            return GetDataTable("SIM_StudentCollection_SearchForStatistic", conditions);
        }

        /// <summary>
        /// SIM_StudentCollection_CheckForEdit
        /// Kiểm tra tính hợp lệ của hồ sơ tuyển sinh
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public string CheckForEdit(params object[] conditions)
        {
            DataTable dtb = GetDataTable("SIM_StudentCollection_CheckForEdit", conditions);
            if (dtb != null && dtb.Rows.Count > 0)
                return dtb.Rows[0][0].ToString();
            return "";
        }

        /// <summary>
        /// Xoá hẳn một id hoặc một StudentCollectionCode
        /// </summary>
        /// <returns></returns>
        public bool Remove()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_StudentCollection_Remove");
                objIData.AddParameter(P_StudentCollectionCode, this.strStudentCollectionCode);                
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_StudentCollection", objEx);
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
