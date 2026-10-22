using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using InformationWeb.LmsInfrastructure;

namespace InformationWeb.Handlers.Lms
{
    /// <summary>
    /// HTTP Handler xử lý upload file cho hệ thống LMS.
    /// Hỗ trợ các định dạng: video, hình ảnh, tài liệu, audio.
    /// </summary>
    public sealed class UploadHandler : IHttpHandler, IRequiresSessionState
    {
        /// <summary>Danh sách các định dạng file được phép upload.</summary>
        private static readonly HashSet<string> Allowed = new HashSet<string>(
            StringComparer.OrdinalIgnoreCase
        )
        {
            ".mp4",
            ".webm",
            ".mov",
            ".jpg",
            ".jpeg",
            ".png",
            ".gif",
            ".webp",
            ".pdf",
            ".doc",
            ".docx",
            ".xls",
            ".xlsx",
            ".ppt",
            ".pptx",
            ".zip",
            ".txt",
            ".mp3",
            ".wav",
        };

        /// <summary>Handler không thể tái sử dụng.</summary>
        public bool IsReusable
        {
            get { return false; }
        }

        /// <summary>
        /// Xử lý request upload file. Kiểm tra xác thực, định dạng, kích thước và lưu file.
        /// </summary>
        /// <param name="context">HttpContext của request hiện tại.</param>
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json; charset=utf-8";
            try
            {
                if (!context.Request.IsAuthenticated || UserSession.Current == null)
                {
                    Write(context, 401, false, "Phiên đăng nhập đã hết hạn.", null);
                    return;
                }
                if (
                    !string.Equals(
                        context.Request.Headers["X-LMS-Request"],
                        "1",
                        StringComparison.Ordinal
                    )
                )
                {
                    Write(context, 400, false, "Yêu cầu tải file không hợp lệ.", null);
                    return;
                }
                if (context.Request.Files.Count == 0)
                {
                    Write(context, 400, false, "Chưa chọn file.", null);
                    return;
                }
                HttpPostedFile file = context.Request.Files[0];
                string ext = Path.GetExtension(file.FileName);
                if (!Allowed.Contains(ext))
                {
                    Write(context, 400, false, "Định dạng file không được hỗ trợ.", null);
                    return;
                }
                int maxMb;
                if (
                    !int.TryParse(
                        ConfigurationManager.AppSettings["Media.MaxVideoFileSizeMB"],
                        out maxMb
                    )
                )
                    maxMb = 500;
                if (file.ContentLength <= 0 || file.ContentLength > maxMb * 1024L * 1024L)
                {
                    Write(context, 400, false, "Kích thước file không hợp lệ.", null);
                    return;
                }
                string category = IsVideo(ext) ? "Video" : (IsImage(ext) ? "Image" : "File");
                string virtualFolder =
                    "~/Media/" + category + "/" + DateTime.UtcNow.ToString("yyyy/MM");
                string physicalFolder = context.Server.MapPath(virtualFolder);
                Directory.CreateDirectory(physicalFolder);
                string stored = Guid.NewGuid().ToString("N") + ext.ToLowerInvariant();
                string physical = Path.Combine(physicalFolder, stored);
                file.SaveAs(physical);
                Write(
                    context,
                    200,
                    true,
                    "Tải file thành công.",
                    VirtualPathUtility.ToAbsolute(virtualFolder + "/" + stored)
                );
            }
            catch (Exception ex)
            {
                WebLog.Error("Tải file LMS thất bại.", ex);
                Write(context, 500, false, "Không thể lưu file.", null);
            }
        }

        /// <summary>
        /// Kiểm tra xem phần mở rộng có phải là định dạng video không.
        /// </summary>
        /// <param name="ext">Phần mở rộng file.</param>
        /// <returns>True nếu là video, False nếu không.</returns>
        private static bool IsVideo(string ext)
        {
            return ext.Equals(".mp4", StringComparison.OrdinalIgnoreCase)
                || ext.Equals(".webm", StringComparison.OrdinalIgnoreCase)
                || ext.Equals(".mov", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Kiểm tra xem phần mở rộng có phải là định dạng hình ảnh không.
        /// </summary>
        /// <param name="ext">Phần mở rộng file.</param>
        /// <returns>True nếu là hình ảnh, False nếu không.</returns>
        private static bool IsImage(string ext)
        {
            return ext.Equals(".jpg", StringComparison.OrdinalIgnoreCase)
                || ext.Equals(".jpeg", StringComparison.OrdinalIgnoreCase)
                || ext.Equals(".png", StringComparison.OrdinalIgnoreCase)
                || ext.Equals(".gif", StringComparison.OrdinalIgnoreCase)
                || ext.Equals(".webp", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Ghi phản hồi JSON cho client.
        /// </summary>
        /// <param name="context">HttpContext của request hiện tại.</param>
        /// <param name="status">HTTP status code.</param>
        /// <param name="success">True nếu thành công, False nếu thất bại.</param>
        /// <param name="message">Thông điệp phản hồi.</param>
        /// <param name="url">URL của file đã upload (nếu thành công).</param>
        private static void Write(
            HttpContext context,
            int status,
            bool success,
            string message,
            string url
        )
        {
            context.Response.StatusCode = status;
            context.Response.TrySkipIisCustomErrors = true;
            context.Response.Write(
                new JavaScriptSerializer().Serialize(
                    new
                    {
                        success = success,
                        message = message,
                        url = url,
                    }
                )
            );
        }
    }
}
