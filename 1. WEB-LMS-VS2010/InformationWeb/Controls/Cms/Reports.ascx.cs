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
    public partial class Reports : CmsStoreControl
    {
        protected override ModuleService Service
        {
            get { return ServiceRegistry.Reports; }
        }
        protected override string Operation
        {
            get
            {
                return
                    ReportTypeList == null
                    || string.IsNullOrWhiteSpace(ReportTypeList.SelectedValue)
                    ? "Dashboard"
                    : ReportTypeList.SelectedValue;
            }
        }
        protected override string PageTitle
        {
            get { return "Báo cáo học tập"; }
        }
        protected override string PageDescription
        {
            get { return "Phân tích hiệu quả học tập theo nhiều góc nhìn."; }
        }
    }
}
