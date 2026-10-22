using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace LmsObject
{
    /// <summary>
    /// Phần mở rộng nghiệp vụ của SIM_Lessons. Generator không ghi đè file này.
    /// </summary>
    public partial class SIM_Lessons
    {
        #region Custom Data Access Methods

        /// <summary>
        /// Lấy danh sách bài học theo khóa học
        /// </summary>
        public DataTable GetByCourse(long courseID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreSearch);
                objIData.AddParameter("@CourseID", courseID);
                return objIData.ExecStoreToDataTable();
            }
            catch (Exception objEx)
            {
                this.objErrorException = objEx;
                return null;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        /// <summary>
        /// Lấy danh sách bài học theo chương
        /// </summary>
        public DataTable GetByChapter(long chapterID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Lessons_GetByChapter");
                objIData.AddParameter("@ChapterID", chapterID);
                return objIData.ExecStoreToDataTable();
            }
            catch (Exception objEx)
            {
                this.objErrorException = objEx;
                return null;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        /// <summary>
        /// Lấy bài học theo loại
        /// </summary>
        public DataTable GetByType(string lessonType)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Lessons_GetByType");
                objIData.AddParameter("@LessonType", lessonType);
                return objIData.ExecStoreToDataTable();
            }
            catch (Exception objEx)
            {
                this.objErrorException = objEx;
                return null;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        /// <summary>
        /// Cập nhật thứ tự bài học
        /// </summary>
        public bool UpdateSortOrder(long lessonID, int sortOrder)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Lessons_UpdateSortOrder");
                objIData.AddParameter("@LessonID", lessonID);
                objIData.AddParameter("@SortOrder", sortOrder);
                objIData.ExecStoreToDataTable();
                return true;
            }
            catch (Exception objEx)
            {
                this.objErrorException = objEx;
                return false;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        /// <summary>
        /// Xóa bài học theo ID (gọi store, có ActorId và IsAdmin)
        /// </summary>
        public bool Delete(long lessonId, long actorId, bool isAdmin, string updatedUser = null)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_Lesson_Delete");
                objIData.AddParameter("@LessonId", lessonId);
                objIData.AddParameter("@ActorId", actorId);
                objIData.AddParameter("@IsAdmin", isAdmin);
                objIData.AddParameter("@UpdatedUser", updatedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                this.objErrorException = objEx;
                return false;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        /// <summary>
        /// Cập nhật thứ tự bài học
        /// </summary>
        public bool LessonReorder(long id, int sortOrder, long actorId, bool isAdmin)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Lessons_Reorder");
                objIData.AddParameter("@Id", id);
                objIData.AddParameter("@SortOrder", sortOrder);
                objIData.AddParameter("@ActorId", actorId);
                objIData.AddParameter("@IsAdmin", isAdmin);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                this.objErrorException = objEx;
                return false;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        /// <summary>
        /// Lấy chi tiết bài học theo ID (gọi store, có ActorId và IsAdmin)
        /// </summary>
        public DataTable GetById(long lessonId, long actorId, bool isAdmin)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_Lesson_GetById");
                objIData.AddParameter("@Id", lessonId);
                objIData.AddParameter("@ActorId", actorId);
                objIData.AddParameter("@IsAdmin", isAdmin);
                return objIData.ExecStoreToDataTable();
            }
            catch (Exception objEx)
            {
                this.objErrorException = objEx;
                return null;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        /// <summary>
        /// Cập nhật bài học (gọi store)
        /// </summary>
        public bool Update(long lessonId, long chapterId, string title, string description, string lessonType, int durationSeconds, int sortOrder, bool isRequired, int passingScore, string contentHtml, string documentUrl, string assignmentFolderName, DateTime? assignmentStartAt, DateTime? dueAt, int assignmentMaxScore, int maxSubmissionAttempts, int maxSubmissionFileSizeMB, bool allowLateSubmission, string status, long actorId, bool isAdmin, string updatedUser = null)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_Lesson_Update");
                objIData.AddParameter("@Id", lessonId);
                objIData.AddParameter("@ChapterId", chapterId);
                objIData.AddParameter("@Title", title);
                objIData.AddParameter("@Description", description);
                objIData.AddParameter("@LessonType", lessonType);
                objIData.AddParameter("@DurationSeconds", durationSeconds);
                objIData.AddParameter("@SortOrder", sortOrder);
                objIData.AddParameter("@IsRequired", isRequired);
                objIData.AddParameter("@PassingScore", passingScore);
                objIData.AddParameter("@ContentHtml", contentHtml);
                objIData.AddParameter("@DocumentUrl", documentUrl);
                objIData.AddParameter("@AssignmentFolderName", assignmentFolderName);
                objIData.AddParameter("@AssignmentStartAt", assignmentStartAt);
                objIData.AddParameter("@DueAt", dueAt);
                objIData.AddParameter("@AssignmentMaxScore", assignmentMaxScore);
                objIData.AddParameter("@MaxSubmissionAttempts", maxSubmissionAttempts);
                objIData.AddParameter("@MaxSubmissionFileSizeMB", maxSubmissionFileSizeMB);
                objIData.AddParameter("@AllowLateSubmission", allowLateSubmission);
                objIData.AddParameter("@Status", status);
                objIData.AddParameter("@ActorId", actorId);
                objIData.AddParameter("@IsAdmin", isAdmin);
                objIData.AddParameter("@UpdatedUser", updatedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                this.objErrorException = objEx;
                return false;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        /// <summary>
        /// Tạo mới bài học (gọi store)
        /// </summary>
        public DataTable Create(long chapterId, string title, string description, string lessonType, int durationSeconds, int sortOrder, bool isRequired, int passingScore, string contentHtml, string documentUrl, string assignmentFolderName, DateTime? assignmentStartAt, DateTime? dueAt, int assignmentMaxScore, int maxSubmissionAttempts, int maxSubmissionFileSizeMB, bool allowLateSubmission, string status, long actorId, bool isAdmin, string updatedUser = null)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_Lesson_Create");
                objIData.AddParameter("@ChapterId", chapterId);
                objIData.AddParameter("@Title", title);
                objIData.AddParameter("@Description", description);
                objIData.AddParameter("@LessonType", lessonType);
                objIData.AddParameter("@DurationSeconds", durationSeconds);
                objIData.AddParameter("@SortOrder", sortOrder);
                objIData.AddParameter("@IsRequired", isRequired);
                objIData.AddParameter("@PassingScore", passingScore);
                objIData.AddParameter("@ContentHtml", contentHtml);
                objIData.AddParameter("@DocumentUrl", documentUrl);
                objIData.AddParameter("@AssignmentFolderName", assignmentFolderName);
                objIData.AddParameter("@AssignmentStartAt", assignmentStartAt);
                objIData.AddParameter("@DueAt", dueAt);
                objIData.AddParameter("@AssignmentMaxScore", assignmentMaxScore);
                objIData.AddParameter("@MaxSubmissionAttempts", maxSubmissionAttempts);
                objIData.AddParameter("@MaxSubmissionFileSizeMB", maxSubmissionFileSizeMB);
                objIData.AddParameter("@AllowLateSubmission", allowLateSubmission);
                objIData.AddParameter("@Status", status);
                objIData.AddParameter("@ActorId", actorId);
                objIData.AddParameter("@IsAdmin", isAdmin);
                objIData.AddParameter("@UpdatedUser", updatedUser);
                return objIData.ExecStoreToDataTable();
            }
            catch (Exception objEx)
            {
                this.objErrorException = objEx;
                return null;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        /// <summary>
        /// Lấy dữ liệu tương tác của giáo viên
        /// </summary>
        public DataSet GetInteractiveTeacher(long lessonId, long actorUserId, bool isAdmin)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("InteractiveTeacher");
                objIData.AddParameter("@LessonID", lessonId);
                objIData.AddParameter("@ActorUserID", actorUserId);
                objIData.AddParameter("@IsAdmin", isAdmin);
                return objIData.ExecStoreToDataSet();
            }
            catch (Exception objEx)
            {
                this.objErrorException = objEx;
                return null;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        #endregion
    }
}
