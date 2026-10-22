using System;
using System.Data;
using System.Web.UI.WebControls;
using InformationWeb.LmsInfrastructure;
using LmsService.Course;

namespace InformationWeb.Controls.Cms
{
    public partial class CourseCategories : LmsControl
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        public void LoadData()
        {
            BindCategoryGrid();
        }

        private void BindCategoryGrid()
        {
            DataTable dtb = CategoryService.GetCategoryList();
            CategoryGrid.DataSource = dtb;
            CategoryGrid.DataBind();
        }

        protected void AddCategoryButton_Click(object sender, EventArgs e)
        {
            EditPanel.Visible = true;
            EditPanelTitle.Text = "Thêm danh mục mới";
            ClearForm();
            CategoryIdValue.Value = "";
        }

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

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            EditPanel.Visible = false;
            ClearForm();
        }

        private void ClearForm()
        {
            CodeText.Text = "";
            NameText.Text = "";
            DescriptionText.Text = "";
            SortOrderText.Text = "0";
            StatusList.SelectedValue = "ACTIVE";
        }

        private void ShowMessage(string message, bool isError)
        {
            ActionMessageText.Visible = true;
            ActionMessageText.Text = message;
            ActionMessageText.CssClass = isError ? "alert alert-danger" : "alert alert-success";
        }
    }
}
