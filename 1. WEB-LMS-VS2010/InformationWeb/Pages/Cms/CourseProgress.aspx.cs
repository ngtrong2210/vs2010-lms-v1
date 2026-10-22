using System;
using System.Web.UI.WebControls;

namespace InformationWeb.Pages.Cms
{
    public partial class CourseProgress : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CourseProgressControl.LoadData();
            }
        }
    }
}
