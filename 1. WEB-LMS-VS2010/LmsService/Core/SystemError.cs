using System;
using System.Data;

namespace LmsService.Core
{
    /// <summary>
    /// Helper class để log error vào database
    /// Dùng DCore để ghi log lỗi hệ thống
    /// </summary>
    public class SystemError
    {
        private string _connectionString;

        public SystemError(string connectionString, string message, Exception exception)
        {
            _connectionString = connectionString;
            LogError(message, exception);
        }

        private void LogError(string message, Exception exception)
        {
            try
            {
                // Log error vào database hoặc file
                // Đối với web application, có thể sử dụng Event Log hoặc file log
                // Đây là implementation cơ bản
                string errorMessage = string.IsNullOrEmpty(message) ? "Unknown error" : message;
                string exceptionMessage = exception != null ? exception.Message : "";
                string stackTrace = exception != null ? exception.StackTrace : "";

                // Log vào System Event Log hoặc file
                System.Diagnostics.EventLog.WriteEntry("LMS Application",
                    $"Error: {errorMessage}\nException: {exceptionMessage}\nStackTrace: {stackTrace}",
                    System.Diagnostics.EventLogEntryType.Error);
            }
            catch
            {
                // Silent fail để tránh vòng lặp error
            }
        }

        /// <summary>
        /// Log error với custom context
        /// </summary>
        public static void Log(string connectionString, string context, Exception exception)
        {
            new SystemError(connectionString, context, exception);
        }
    }
}
