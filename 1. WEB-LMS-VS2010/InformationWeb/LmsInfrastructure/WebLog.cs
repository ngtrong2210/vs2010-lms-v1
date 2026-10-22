using System;
using System.Configuration;
using System.IO;
using System.Web;

namespace InformationWeb.LmsInfrastructure
{
    /// <summary>
    /// Lớp tiện ích ghi log lỗi hệ thống.
    /// </summary>
    public static class WebLog
    {
        private static readonly object Sync = new object();

        /// <summary>
        /// Ghi thông tin lỗi vào file log.
        /// </summary>
        /// <param name="message">Thông điệp mô tả lỗi.</param>
        /// <param name="exception">Đối tượng exception chứa chi tiết lỗi.</param>
        public static void Error(string message, Exception exception)
        {
            try
            {
                string configured = ConfigurationManager.AppSettings["Storage.LogPath"] ?? "~/App_Data/Logs";
                string folder = HttpContext.Current != null ? HttpContext.Current.Server.MapPath(configured) : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "Logs");
                Directory.CreateDirectory(folder);
                string file = Path.Combine(folder, "lms-" + DateTime.UtcNow.ToString("yyyyMMdd") + ".log");
                string content = string.Format("{0:u} | {1}\r\n{2}\r\n", DateTime.UtcNow, message ?? string.Empty, exception == null ? string.Empty : exception.ToString());
                lock (Sync) File.AppendAllText(file, content);
            }
            catch { }
        }
    }
}
