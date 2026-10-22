using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using InformationWeb.LmsInfrastructure;
using LmsService;

namespace InformationWeb.Controls.Cms
{
    /// <summary>
    /// UserControl quản lý học viên trong CMS.
    /// Cung cấp chức năng xem danh sách, tìm kiếm và theo dõi tiến độ học tập của học viên.
    /// </summary>
    public partial class Students : CmsStoreControl
    {
        /// <summary>
        /// Service quản lý học viên.
        /// </summary>
        protected override ModuleService Service
        {
            get { return ServiceRegistry.Students; }
        }
        /// <summary>
        /// Tên operation để lấy danh sách học viên.
        /// </summary>
        protected override string Operation
        {
            get { return "List"; }
        }
        /// <summary>
        /// Tiêu đề trang quản lý học viên.
        /// </summary>
        protected override string PageTitle
        {
            get { return "Học viên"; }
        }
        /// <summary>
        /// Mô tả trang quản lý học viên.
        /// </summary>
        protected override string PageDescription
        {
            get { return "Theo dõi hồ sơ và tiến độ học tập."; }
        }

        /// <summary>
        /// Các tham số cho service call (tìm kiếm, phân trang).
        /// </summary>
        protected override IDictionary<string, object> Parameters()
        {
            return Values(
                "Search",
                SearchText.Text.Trim(),
                "Status",
                null,
                "Page",
                1,
                "PageSize",
                100
            );
        }

        /// <summary>
        /// Lấy chữ cái đầu tên học viên để hiển thị avatar.
        /// </summary>
        protected string StudentInitials(object value)
        {
            string[] names = Convert
                .ToString(value)
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (names.Length == 0)
                return "HV";
            return Server.HtmlEncode(
                names.Length == 1
                    ? names[0].Substring(0, 1).ToUpperInvariant()
                    : (
                        names[names.Length - 2].Substring(0, 1)
                        + names[names.Length - 1].Substring(0, 1)
                    ).ToUpperInvariant()
            );
        }

        /// <summary>
        /// Lấy style CSS cho thanh tiến độ học tập.
        /// </summary>
        protected string StudentProgressStyle(object value)
        {
            decimal progress;
            decimal.TryParse(Convert.ToString(value), out progress);
            progress = Math.Max(0, Math.Min(100, progress));
            return "width:" + progress.ToString("0.##", CultureInfo.InvariantCulture) + "%";
        }

        /// <summary>
        /// Lấy phần trăm tiến độ học tập dưới dạng chuỗi.
        /// </summary>
        protected string StudentPercent(object value)
        {
            decimal progress;
            return decimal.TryParse(Convert.ToString(value), out progress)
                ? progress.ToString("0.##", CultureInfo.CurrentCulture)
                : "0";
        }

        /// <summary>
        /// Lấy class CSS cho badge trạng thái học viên.
        /// </summary>
        protected string StudentStatusClass(object status, object progress)
        {
            decimal value;
            decimal.TryParse(Convert.ToString(progress), out value);
            return value >= 100 ? "badge-soft-primary"
                : Convert.ToString(status) == "ACTIVE" ? "badge-soft-success"
                : "badge-soft-warning";
        }

        /// <summary>
        /// Lấy nhãn trạng thái học viên (Hoàn thành, Đang học, Tạm khóa).
        /// </summary>
        protected string StudentStatusLabel(object status, object progress)
        {
            decimal value;
            decimal.TryParse(Convert.ToString(progress), out value);
            return value >= 100 ? "Hoàn thành"
                : Convert.ToString(status) == "ACTIVE" ? "Đang học"
                : "Tạm khóa";
        }
    }
}
