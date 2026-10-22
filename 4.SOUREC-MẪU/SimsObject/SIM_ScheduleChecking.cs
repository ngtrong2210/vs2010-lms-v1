
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
	/// Created date 	: 3/20/2012 
	/// Description 
	/// </summary>	
	public partial class SIM_ScheduleChecking
	{	
		
		#region Methods	
                
        ///<summary>
        /// Update : SIM_ScheduleChecking
        /// Cập nhật dữ liệu duyệt
        /// Store: SIM_ScheduleChecking_UpdateReview1 
        ///</summary>
        public bool UpdateReview1()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_ScheduleChecking_UpdateReview1");
                objIData.AddParameter(P_ScheduleCheckingID, this.lngScheduleCheckingID);
                objIData.AddParameter(P_IsReviewed1, this.bolIsReviewed1);
                objIData.AddParameter(P_ReviewComment1, this.strReviewComment1);
                objIData.AddParameter(P_ReviewUser1, this.strReviewUser1);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_ScheduleChecking_UpdateReview1", objEx);
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
        /// Update : SIM_ScheduleChecking
        /// Cập nhật dữ liệu duyệt
        /// Store: SIM_ScheduleChecking_UpdateReview2
        ///</summary>
        public bool UpdateReview2()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_ScheduleChecking_UpdateReview2");
                objIData.AddParameter(P_ScheduleCheckingID, this.lngScheduleCheckingID);
                objIData.AddParameter(P_IsReviewed2, this.bolIsReviewed2);
                objIData.AddParameter(P_ReviewComment2, this.strReviewComment2);
                objIData.AddParameter(P_ReviewUser2, this.strReviewUser2);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_ScheduleChecking_UpdateReview2", objEx);
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
        /// Update : SIM_ScheduleChecking
        /// Cập nhật dữ liệu duyệt
        /// Store: SIM_ScheduleChecking_UpdateReview 
        ///</summary>
        public bool UpdateReview()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_ScheduleChecking_UpdateReview");
                objIData.AddParameter(P_ScheduleCheckingID, this.lngScheduleCheckingID);
                objIData.AddParameter(P_IsReviewed, this.bolIsReviewed);
                objIData.AddParameter(P_ReviewComment, this.strReviewComment);
                objIData.AddParameter(P_ReviewUser, this.strReviewUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_ScheduleChecking_UpdateReview", objEx);
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
        /// Search lên y như cách của Sổ đầu bài, để biết cái nào thuộc quyền của mình mà copy
        /// Chỉ khác là ta tìm theo quyền edit thay gì quyền view
        /// Không cần điểm danh, chỉ lấy ngày thực sự có tkb
        /// Có sổ đầu bài rồi thì bỏ qua, ko đè.
        /// Nếu có truyền 3 tham số sau thì fai truyền cho đủ 3 để copy cho đúng một ngày
        /// </summary>
        /// <param name="loginName">Tìm theo gv đăng nhập để copy theo quyền</param>
        /// <param name="sessionIndex">Thứ tự buổi sẽ copy</param>
        /// <param name="destDate">Tạo cho ngày (thực dạy)</param>
        /// <param name="destSessionID">Tạo cho buổi (thực dạy)</param>
        /// <returns></returns>
        public bool CopyFromTeachingSchedule(string loginName, int? sessionIndex = null, DateTime? destDate = null, int? destSession = null)
        {

            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_ScheduleChecking_CopyFromTeachingSchedule");
                objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
                objIData.AddParameter("@LoginName", loginName);

                objIData.AddParameter("@SessionIndex", sessionIndex);
                objIData.AddParameter("@DestDate", destDate);
                objIData.AddParameter("@DestSession", destSession);

                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_ScheduleChecking_CopyFromTeachingSchedule", objEx);
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
       /// Xóa sổ lên lớp
       /// </summary>
       /// <param name="lngScheduleCheckingID"></param>
       /// <param name="isDeleteChecking">Truyền true nếu muốn xóa điểm danh, false thì sẽ kiểm tra: tồn tại điểm danh là không xóa được</param>
       /// <returns></returns>
        public bool Delete(long? scheduleCheckingID, bool isDeleteChecking = false)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_ScheduleChecking_DELETE");
                objIData.AddParameter(P_ScheduleCheckingID, scheduleCheckingID);
                objIData.AddParameter("@IsDeleteChecking", isDeleteChecking);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_ScheduleChecking", objEx);
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
        /// **** Ý tưởng này chưa khả thi, vì lý do họ ko ghi sổ lên lớp trước nên ko có id để edit, đồng thời nếu họ đổi nhóm thì không còn đúng
        ///         --> nên hiện tại vẫn đang dùng cách xử lý trong store
        ///         
        /// Mr Việt     - 17/06/2022 CDCĐ ĐT
        /// Cập nhật thông tin vắng: Số vắng và Ds tên học sinh vắng
        /// OffStudentCount và OffStudentList
        /// </summary>
        /// <returns></returns>
        //public bool UpdateOffStudent()
        //{
        //    if (!bolIsExistIData)
        //        objIData = DCore.Data.CreateData();
        //    try
        //    {
        //        objIData.CreateNewStoredProcedure("SIM_ScheduleChecking_UpdateOffStudent");
        //        objIData.AddParameter(P_ScheduleCheckingID, this.lngScheduleCheckingID);
        //        objIData.AddParameter(P_IsReviewed, this.bolIsReviewed);
        //        objIData.AddParameter(P_ReviewComment, this.strReviewComment);
        //        objIData.AddParameter(P_ReviewUser, this.strReviewUser);
        //        objIData.ExecNonQuery();
        //        return true;
        //    }
        //    catch (Exception objEx)
        //    {
        //        if (bolIsExistIData)
        //            this.RollBackTransaction();
        //        new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_ScheduleChecking_UpdateOffStudent", objEx);
        //        this.objErrorException = objEx;
        //        return false;
        //    }
        //    finally
        //    {
        //        if (!bolIsExistIData)
        //            objIData.Disconnect();
        //    }
        //}


        ///<summary>
        /// Update : AddOrEdit_Import
        /// Cập nhật dữ liệu cho việc import vì không đủ các cột
        /// Store: SIM_ScheduleChecking_AddOrEdit_Import 
        ///</summary>
        public bool AddOrEdit_Import()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_ScheduleChecking_AddOrEdit_Import");
                
                objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
                objIData.AddParameter(P_Date, this.dtmDate);
                objIData.AddParameter(P_Session, this.intSession);

                objIData.AddParameter(P_TheoryQuantity, this.decTheoryQuantity);
                objIData.AddParameter(P_PracticeQuantity, this.decPracticeQuantity);
                objIData.AddParameter(P_TestQuantity, this.decTestQuantity);

                objIData.AddParameter(P_TeacherID, this.strTeacherID);
                objIData.AddParameter(P_LearningContent, this.strLearningContent);
                objIData.AddParameter(P_RequestContent, this.strRequestContent);                               
                objIData.AddParameter(P_Description, this.strDescription);

                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
                objIData.AddParameter(P_IsTeachingSchedule, this.bolIsTeachingSchedule);                                
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_ScheduleChecking", objEx);
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
