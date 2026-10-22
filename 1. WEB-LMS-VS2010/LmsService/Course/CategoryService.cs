using System;
using System.Data;
using LmsObject;

namespace LmsService.Course
{
    public partial class CategoryService
    {
        static bool bolHaveNewData = false;
        static DataTable dtbTable = null;

        public static DataTable Table
        {
            get
            {
                if (dtbTable == null || bolHaveNewData)
                {
                    SIM_CourseCategories obj = new SIM_CourseCategories();
                    dtbTable = obj.GetDataTable("SIM_CourseCategories_SEARCHCBX");
                    DataRow drw = dtbTable.NewRow();
                    dtbTable.Rows.InsertAt(drw, 0);
                    bolHaveNewData = false;
                }
                return dtbTable;
            }
            set { dtbTable = value; }
        }

        public static bool HaveNewData
        {
            get { return bolHaveNewData; }
            set { bolHaveNewData = value; }
        }

        #region UI Helpers

        public static void InitDropDownList(System.Web.UI.WebControls.DropDownList ddl, string condition = "")
        {
            DataTable dtbCopy = null;
            if (!string.IsNullOrEmpty(condition))
            {
                dtbCopy = Table.Copy();
                dtbCopy.DefaultView.RowFilter = "(" + condition + ") or " + SIM_CourseCategories.C_CourseCategoryID + " is null";
            }
            else
            {
                dtbCopy = Table;
            }

            ddl.DataSource = dtbCopy;
            ddl.DataTextField = SIM_CourseCategories.C_Name;
            ddl.DataValueField = SIM_CourseCategories.C_CourseCategoryID;
            ddl.DataBind();
            ddl.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Chọn danh mục--", ""));
        }

        #endregion

        #region Business Logic

        public static bool CreateCategory(string code, string name, string description, int sortOrder, string status)
        {
            SIM_CourseCategories obj = new SIM_CourseCategories();
            obj.Code = code;
            obj.Name = name;
            obj.Description = description;
            obj.SortOrder = sortOrder;
            obj.Status = status;

            bool result = obj.Add();
            if (result)
            {
                HaveNewData = true;
            }
            return result;
        }

        public static bool UpdateCategory(long categoryId, string code, string name, string description, int sortOrder, string status)
        {
            SIM_CourseCategories obj = new SIM_CourseCategories();
            obj.CourseCategoryID = categoryId;
            if (!obj.Get())
                return false;

            obj.Code = code;
            obj.Name = name;
            obj.Description = description;
            obj.SortOrder = sortOrder;
            obj.Status = status;

            bool result = obj.Update();
            if (result)
            {
                HaveNewData = true;
            }
            return result;
        }

        public static bool DeleteCategory(long categoryId)
        {
            SIM_CourseCategories obj = new SIM_CourseCategories();
            obj.CourseCategoryID = categoryId;
            bool result = obj.Delete();
            if (result)
            {
                HaveNewData = true;
            }
            return result;
        }

        public static DataTable GetCategoryList(string condition = "")
        {
            SIM_CourseCategories obj = new SIM_CourseCategories();
            if (string.IsNullOrEmpty(condition))
                return obj.GetDataTable("SIM_CourseCategories_SEARCHCBX");
            else
                return obj.Search(condition);
        }

        public static DataTable GetActiveCategories()
        {
            SIM_CourseCategories obj = new SIM_CourseCategories();
            return obj.GetActiveCategories();
        }

        #endregion
    }
}
