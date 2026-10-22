using System;
using System.Web.UI.WebControls;

namespace InformationWeb.Pages.Cms
{
    public partial class CourseEnrollments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CourseEnrollmentsControl.LoadData();
            }
        }
    }
}
