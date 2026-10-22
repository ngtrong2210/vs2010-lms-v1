using System;
using System.Collections.Generic;
using System.Data;
using LmsObject;

namespace LmsService
{
    /// <summary>
    /// Dịch vụ quản lý thông báo hệ thống LMS.
    /// Cung cấp các chức năng: tạo thông báo, lấy danh sách, đánh dấu đã đọc, xóa.
    /// </summary>
    public sealed class NotificationService : ModuleService
    {
        public NotificationService() : base(Map(
            "GetList", "dbo.LMS_Notification_GetList",
            "GetUnreadCount", "dbo.LMS_Notification_GetUnreadCount",
            "Create", "dbo.LMS_Notification_Create",
            "MarkAsRead", "dbo.LMS_Notification_MarkAsRead",
            "MarkAllAsRead", "dbo.LMS_Notification_MarkAllAsRead",
            "Delete", "dbo.LMS_Notification_Delete",
            "DeleteExpired", "dbo.LMS_Notification_DeleteExpired")) { }

        /// <summary>
        /// Lấy danh sách thông báo cho người dùng cụ thể.
        /// </summary>
        /// <param name="recipientUserId">ID người nhận thông báo</param>
        /// <param name="limit">Số lượng tối đa trả về (mặc định 20)</param>
        /// <param name="offset">Vị trí bắt đầu (phân trang)</param>
        /// <returns>Danh sách thông báo</returns>
        public DataTable GetNotifications(long recipientUserId, int limit = 20, int offset = 0)
        {
            SYS_Users data = new SYS_Users();
            return data.GetDataTable(Procedure("GetList"),
                "@RecipientUserID", recipientUserId,
                "@Limit", limit,
                "@Offset", offset);
        }

        /// <summary>
        /// Lấy số lượng thông báo chưa đọc của người dùng.
        /// </summary>
        /// <param name="recipientUserId">ID người nhận thông báo</param>
        /// <returns>Số lượng thông báo chưa đọc</returns>
        public int GetUnreadCount(long recipientUserId)
        {
            SYS_Users data = new SYS_Users();
            DataTable result = data.GetDataTable(Procedure("GetUnreadCount"),
                "@RecipientUserID", recipientUserId);
            if (result != null && result.Rows.Count > 0)
            {
                return Convert.ToInt32(result.Rows[0]["UnreadCount"]);
            }
            return 0;
        }

        /// <summary>
        /// Tạo thông báo mới cho một hoặc nhiều người nhận.
        /// </summary>
        /// <param name="notificationType">Loại thông báo (ENROLLMENT, ANSWER_SUBMITTED, LESSON_COMPLETED, etc.)</param>
        /// <param name="title">Tiêu đề thông báo</param>
        /// <param name="message">Nội dung chi tiết</param>
        /// <param name="recipientUserIds">Danh sách ID người nhận</param>
        /// <param name="actorUserId">ID người dùng thực hiện hành động (có thể null)</param>
        /// <param name="referenceType">Loại dữ liệu tham chiếu (COURSE, LESSON, STUDENT_ANSWER, etc.)</param>
        /// <param name="referenceId">ID của dữ liệu tham chiếu</param>
        /// <param name="actionUrl">Đường dẫn điều hướng khi click vào thông báo</param>
        /// <param name="expiresAt">Thời gian hết hiệu lực (có thể null)</param>
        /// <returns>True nếu tạo thành công</returns>
        public bool CreateNotification(
            string notificationType,
            string title,
            string message,
            List<long> recipientUserIds,
            long? actorUserId = null,
            string referenceType = null,
            long? referenceId = null,
            string actionUrl = null,
            DateTime? expiresAt = null)
        {
            if (recipientUserIds == null || recipientUserIds.Count == 0)
                return false;

            SYS_Users executor = new SYS_Users();
            executor.BeginTransaction();

            try
            {
                foreach (long recipientId in recipientUserIds)
                {
                    executor.ExecNonQuery(
                        Procedure("Create"),
                        "@NotificationType", notificationType,
                        "@Title", title,
                        "@Message", message,
                        "@RecipientUserID", recipientId,
                        "@ActorUserID", actorUserId.HasValue ? (object)actorUserId.Value : DBNull.Value,
                        "@ReferenceType", referenceType ?? (object)DBNull.Value,
                        "@ReferenceID", referenceId.HasValue ? (object)referenceId.Value : DBNull.Value,
                        "@ActionUrl", actionUrl ?? (object)DBNull.Value,
                        "@ExpiresAt", expiresAt.HasValue ? (object)expiresAt.Value : DBNull.Value
                    );
                }

                executor.CommitTransaction();
                return true;
            }
            catch
            {
                try { executor.RollBackTransaction(); } catch { }
                return false;
            }
        }

        /// <summary>
        /// Đánh dấu một thông báo đã đọc.
        /// </summary>
        /// <param name="notificationId">ID thông báo</param>
        /// <param name="recipientUserId">ID người nhận (để kiểm tra quyền)</param>
        /// <returns>True nếu đánh dấu thành công</returns>
        public bool MarkAsRead(long notificationId, long recipientUserId)
        {
            SYS_Users data = new SYS_Users();
            return data.ExecNonQuery(Procedure("MarkAsRead"),
                "@NotificationID", notificationId,
                "@RecipientUserID", recipientUserId);
        }

        /// <summary>
        /// Đánh dấu tất cả thông báo của người dùng đã đọc.
        /// </summary>
        /// <param name="recipientUserId">ID người nhận</param>
        /// <returns>True nếu đánh dấu thành công</returns>
        public bool MarkAllAsRead(long recipientUserId)
        {
            SYS_Users data = new SYS_Users();
            return data.ExecNonQuery(Procedure("MarkAllAsRead"),
                "@RecipientUserID", recipientUserId);
        }

        /// <summary>
        /// Xóa một thông báo.
        /// </summary>
        /// <param name="notificationId">ID thông báo</param>
        /// <param name="recipientUserId">ID người nhận (để kiểm tra quyền)</param>
        /// <returns>True nếu xóa thành công</returns>
        public bool DeleteNotification(long notificationId, long recipientUserId)
        {
            SYS_Users data = new SYS_Users();
            return data.ExecNonQuery(Procedure("Delete"),
                "@NotificationID", notificationId,
                "@RecipientUserID", recipientUserId);
        }

        /// <summary>
        /// Xóa các thông báo đã hết hạn.
        /// </summary>
        /// <returns>Số lượng thông báo đã xóa</returns>
        public int DeleteExpiredNotifications()
        {
            SYS_Users data = new SYS_Users();
            try
            {
                data.ExecNonQuery(Procedure("DeleteExpired"));
                return 1; // Trả về 1 nếu thành công, actual count có thể cần stored procedure trả về
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Tạo thông báo liên quan đến việc ghi danh học viên vào lớp học.
        /// </summary>
        public bool CreateEnrollmentNotification(long classId, long recipientUserId, long actorUserId, string className)
        {
            return CreateNotification(
                "ENROLLMENT",
                "Đã được ghi danh vào lớp học",
                $"Bạn đã được ghi danh vào lớp học: {className}",
                new List<long> { recipientUserId },
                actorUserId,
                "CLASS",
                classId,
                $"/Class/View/{classId}"
            );
        }

        /// <summary>
        /// Tạo thông báo khi học viên nộp bài tập.
        /// </summary>
        public bool CreateSubmissionNotification(long submissionId, long teacherId, long studentId, string assignmentTitle)
        {
            return CreateNotification(
                "ANSWER_SUBMITTED",
                "Bài tập mới đã được nộp",
                $"Học viên đã nộp bài tập: {assignmentTitle}",
                new List<long> { teacherId },
                studentId,
                "SUBMISSION",
                submissionId,
                $"/Assignment/Grade/{submissionId}"
            );
        }

        /// <summary>
        /// Tạo thông báo khi học viên hoàn thành bài học.
        /// </summary>
        public bool CreateLessonCompletedNotification(long lessonId, long studentId, string lessonTitle)
        {
            return CreateNotification(
                "LESSON_COMPLETED",
                "Đã hoàn thành bài học",
                $"Bạn đã hoàn thành bài học: {lessonTitle}",
                new List<long> { studentId },
                null,
                "LESSON",
                lessonId,
                $"/Lesson/View/{lessonId}"
            );
        }

        /// <summary>
        /// Tạo thông báo khi giảng viên chấm điểm bài tập.
        /// </summary>
        public bool CreateGradedNotification(long submissionId, long studentId, long teacherId, string assignmentTitle, decimal score)
        {
            return CreateNotification(
                "ASSIGNMENT_GRADED",
                "Bài tập đã được chấm điểm",
                $"Bài tập '{assignmentTitle}' của bạn đã được chấm điểm: {score}",
                new List<long> { studentId },
                teacherId,
                "SUBMISSION",
                submissionId,
                $"/Assignment/View/{submissionId}"
            );
        }

        /// <summary>
        /// Tạo thông báo hệ thống gửi đến nhiều người dùng.
        /// </summary>
        public bool CreateSystemNotification(string title, string message, List<long> recipientUserIds, string actionUrl = null)
        {
            return CreateNotification(
                "SYSTEM",
                title,
                message,
                recipientUserIds,
                null,
                null,
                null,
                actionUrl
            );
        }
    }
}
