using System;
using System.Data;
using System.Web.UI.WebControls;
using InformationWeb.LmsInfrastructure;
using LmsService.Course;

namespace InformationWeb.Controls.Cms
{
    /// <summary>
    /// UserControl quản lý danh mục khóa học trong CMS.
    /// Cung cấp chức năng thêm, sửa, xóa và hiển thị danh sách danh mục.
    /// </summary>
    public partial class CourseCategories : LmsControl
    {
        /// <summary>
        /// Xử lý sự kiện Load: tải dữ liệu khi không phải PostBack.
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        /// <summary>
        /// Tải dữ liệu danh mục khóa học.
        /// </summary>
        public void LoadData()
        {
            BindCategoryGrid();
        }

        /// <summary>
        /// Binding dữ liệu danh mục vào GridView.
        /// </summary>
        private void BindCategoryGrid()
        {
            DataTable dtb = CategoryService.GetCategoryList();
            CategoryGrid.DataSource = dtb;
            CategoryGrid.DataBind();
        }

        /// <summary>
        /// Xử lý sự kiện click nút thêm danh mục mới.
        /// Hiển thị form nhập liệu trống.
        /// </summary>
        protected void AddCategoryButton_Click(object sender, EventArgs e)
        {
            EditPanel.Visible = true;
            EditPanelTitle.Text = "Thêm danh mục mới";
            ClearForm();
            CategoryIdValue.Value = "";
        }

        /// <summary>
        /// Xử lý các lệnh từ GridView (Edit, Delete).
        /// </summary>
        protected void CategoryGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            long categoryId = Convert.ToInt64(e.CommandArgument);

            if (e.CommandName == "EditCategory")
            {
                EditCategory(categoryId);
            }
            else if (e.CommandName == "DeleteCategory")
            {
                DeleteCategory(categoryId);
            }
        }

        /// <summary>
        /// Xử lý sự kiện RowCreated để định dạng hiển thị trạng thái danh mục.
        /// </summary>
        protected void CategoryGrid_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = (DataRowView)e.Row.DataItem;
                string status = WebData.Text(drv, "Status");

                Label statusLabel = (Label)e.Row.FindControl("StatusLabel");
                if (statusLabel != null)
                {
                    statusLabel.Text = status == "ACTIVE" ? "Hoạt động" : "Tạm dừng";
                    statusLabel.CssClass = "status-badge " + (status == "ACTIVE" ? "status-active" : "status-inactive");
                }
            }
        }

        protected void CategoryGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CategoryGrid.PageIndex = e.NewPageIndex;
            BindCategoryGrid();
        }

        private void EditCategory(long categoryId)
        {
            DataTable dtb = CategoryService.GetCategoryList();
            DataRow[] rows = dtb.Select("CourseCategoryID = " + categoryId);

            if (rows.Length > 0)
            {
                DataRow row = rows[0];
                EditPanel.Visible = true;
                EditPanelTitle.Text = "Chỉnh sửa danh mục";
                CategoryIdValue.Value = categoryId.ToString();
                CodeText.Text = WebData.Text(row, "Code");
                NameText.Text = WebData.Text(row, "Name");
                DescriptionText.Text = WebData.Text(row, "Description");
                SortOrderText.Text = WebData.Text(row, "SortOrder");
                StatusList.SelectedValue = WebData.Text(row, "Status");
            }
        }

        private void DeleteCategory(long categoryId)
        {
            bool result = CategoryService.DeleteCategory(categoryId);

            if (result)
            {
                ShowMessage("Xóa danh mục thành công", false);
                BindCategoryGrid();
            }
            else
            {
                ShowMessage("Có lỗi xảy ra khi xóa danh mục", true);
            }
        }

        /// <summary>
        /// Xử lý sự kiện click nút lưu: thêm mới hoặc cập nhật danh mục.
        /// </summary>
        protected void SaveButton_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            string code = CodeText.Text.Trim();
            string name = NameText.Text.Trim();
            string description = DescriptionText.Text.Trim();
            int sortOrder = Convert.ToInt32(SortOrderText.Text);
            string status = StatusList.SelectedValue;

            long categoryId = 0;
            if (!string.IsNullOrEmpty(CategoryIdValue.Value))
            {
                categoryId = Convert.ToInt64(CategoryIdValue.Value);
            }

            bool result = false;

            if (categoryId > 0)
            {
                result = CategoryService.UpdateCategory(categoryId, code, name, description, sortOrder, status);
            }
            else
            {
                result = CategoryService.CreateCategory(code, name, description, sortOrder, status);
            }

            if (result)
            {
                ShowMessage("Lưu danh mục thành công", false);
                EditPanel.Visible = false;
                BindCategoryGrid();
            }
            else
            {
                ShowMessage("Có lỗi xảy ra khi lưu danh mục", true);
            }
        }

        /// <summary>
        /// Xử lý sự kiện click nút hủy: đóng form và xóa dữ liệu.
        /// </summary>
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            EditPanel.Visible = false;
            ClearForm();
        }

        /// <summary>
        /// Xóa dữ liệu form nhập liệu về trạng thái mặc định.
        /// </summary>
        private void ClearForm()
        {
            CodeText.Text = "";
            NameText.Text = "";
            DescriptionText.Text = "";
            SortOrderText.Text = "0";
            StatusList.SelectedValue = "ACTIVE";
        }

        /// <summary>
        /// Hiển thị thông báo kết quả thực hiện thao tác.
        /// </summary>
        /// <param name="message">Nội dung thông báo</param>
        /// <param name="isError">True nếu là lỗi, False nếu thành công</param>
        private void ShowMessage(string message, bool isError)
        {
            ActionMessageText.Visible = true;
            ActionMessageText.Text = message;
            ActionMessageText.CssClass = isError ? "alert alert-danger" : "alert alert-success";
        }
    }
}
