using System;
using System.Web.UI.WebControls;

namespace InformationWeb.Pages.Cms
{
    /// <summary>
    /// Trang quản lý danh mục khóa học trong CMS.
    /// </summary>
    public partial class CourseCategories : System.Web.UI.Page
    {
        /// <summary>
        /// Xử lý sự kiện Load: tải dữ liệu danh mục khi không phải PostBack.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CourseCategoriesControl.LoadData();
            }
        }
    }
}
