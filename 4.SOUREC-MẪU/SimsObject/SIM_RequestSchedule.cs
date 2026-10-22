
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
	/// Created date 	: 11/11/2011 
	/// Description 
	/// </summary>	
	public partial class SIM_RequestSchedule
	{	
		
		#region Methods	

        /// <summary>
        /// Xử lý tạo lịch dạy bù + đánh dấu lịch báo nghỉ
        /// Lệnh này thực hiện sau khi đã kiểm tra trùng này nọ ok, và chỉ làm khi Duyệt = true
        /// </summary>
        /// <returns></returns>
        public bool DoReviewed()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_RequestSchedule_DoReviewed");
                objIData.AddParameter(P_RequestScheduleID, this.lngRequestScheduleID);                
                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_RequestSchedule_DoReviewed", objEx);
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
        /// Xử lý hủy duyệt lịch: Xóa lịch bù đã tạo + Hủy đánh dấu báo nghỉ
        /// Lệnh này thực hiện khi chuyển từ Duyệt sang bỏ duyệt
        /// </summary>
        /// <returns></returns>
        public bool UndoReviewed()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_RequestSchedule_UndoReviewed");
                objIData.AddParameter(P_RequestScheduleID, this.lngRequestScheduleID);
                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_RequestSchedule_UndoReviewed", objEx);
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
        /// Update : SIM_RequestSchedule
        /// Cập nhật dữ liệu
        /// Store: SIM_RequestSchedule_EDIT 
        ///</summary>
        public bool UpdateReview1()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_RequestSchedule_UpdateReview1");
                objIData.AddParameter(P_RequestScheduleID, this.lngRequestScheduleID);

                objIData.AddParameter(P_IsReviewed1, this.bolIsReviewed1);
                objIData.AddParameter(P_ReviewedDate1, this.dtmReviewedDate1);
                objIData.AddParameter(P_ReviewedUser1, this.strReviewedUser1);
                objIData.AddParameter(P_ReviewedComment1, this.strReviewedComment1);

                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);                   
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_RequestSchedule_UpdateReview", objEx);
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
        /// Update : SIM_RequestSchedule
        /// Cập nhật dữ liệu
        /// Store: SIM_RequestSchedule_EDIT 
        ///</summary>
        public bool UpdateReview()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_RequestSchedule_UpdateReview");
                objIData.AddParameter(P_RequestScheduleID, this.lngRequestScheduleID);

                objIData.AddParameter(P_IsReviewed, this.bolIsReviewed);
                objIData.AddParameter(P_ReviewedDate, this.dtmReviewedDate);
                objIData.AddParameter(P_ReviewedUser, this.strReviewedUser);
                objIData.AddParameter(P_ReviewedComment, this.strReviewedComment);

                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);                
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_RequestSchedule_UpdateReview", objEx);
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
