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
    public partial class Students : CmsStoreControl
    {
        protected override ModuleService Service
        {
            get { return ServiceRegistry.Students; }
        }
        protected override string Operation
        {
            get { return "List"; }
        }
        protected override string PageTitle
        {
            get { return "Học viên"; }
        }
        protected override string PageDescription
        {
            get { return "Theo dõi hồ sơ và tiến độ học tập."; }
        }

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

        protected string StudentProgressStyle(object value)
        {
            decimal progress;
            decimal.TryParse(Convert.ToString(value), out progress);
            progress = Math.Max(0, Math.Min(100, progress));
            return "width:" + progress.ToString("0.##", CultureInfo.InvariantCulture) + "%";
        }

        protected string StudentPercent(object value)
        {
            decimal progress;
            return decimal.TryParse(Convert.ToString(value), out progress)
                ? progress.ToString("0.##", CultureInfo.CurrentCulture)
                : "0";
        }

        protected string StudentStatusClass(object status, object progress)
        {
            decimal value;
            decimal.TryParse(Convert.ToString(progress), out value);
            return value >= 100 ? "badge-soft-primary"
                : Convert.ToString(status) == "ACTIVE" ? "badge-soft-success"
                : "badge-soft-warning";
        }

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
