using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Global;
using SimsObject;
using System.Windows.Forms;


namespace SimsService
{
    public partial class SIM_CourseService
    {
        static bool bolHaveNewData = false;
        static DataTable dtbTable = null;

        public static DataTable Table
        {
            get
            {
                if (dtbTable == null || bolHaveNewData)
                {
                    // Neu cache thì cache ở đây
                    SIM_Course objArea = new SIM_Course();
                    dtbTable = objArea.Search();
                    DataRow drw = dtbTable.NewRow();

                    dtbTable.Rows.InsertAt(drw, 0); // thêm dòng trống
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

        #region Init DgLookUpEdit

        /// <summary>
        /// Khởi tạo combobox. Chú ý data chỉ được load một lần, gọi lần 2 là không load nữa.
        /// </summary>
        /// <param name="lookupCategory"></param>
        public static void InitLookUpEdit(Control.DgLookUpEdit lookup)
        {
            InitLookUpEdit(lookup, "");
        }

        /// <summary>
        /// Khởi tạo combobox. Chú ý data chỉ được load một lần, gọi lần 2 là không load nữa.
        /// </summary>
        /// <param name="lookupArea"></param>
        public static void InitLookUpEdit(Control.DgLookUpEdit lookup, string condition)
        {
            DataTable dtbCopy = null;
            if (condition != "" && condition != null)
            {
                dtbCopy = Table.Copy();
                dtbCopy.DefaultView.RowFilter = "CourseID is null or (" + condition + ")";
                //Table.DefaultView.RowFilter = condition;
            }
            else
                dtbCopy = Table;
            lookup.InitData(dtbCopy, "--Chọn--", SIM_Course.C_CourseID, SIM_Course.C_CourseName , SIM_Course.C_CourseID , "Mã ngành", SIM_Course.C_CourseName , "Tên khóa học");
        }


        /// <summary>
        /// Khởi tạo combobox. Chú ý data chỉ được load một lần, gọi lần 2 là không load nữa.
        /// </summary>
        /// <param name="lookupCategory"></param>
        public static void InitLookUpEdit(Control.ULookUpEdit lookup)
        {
            InitLookUpEdit(lookup, "");
        }

        /// <summary>
        /// Khởi tạo combobox. Chú ý data chỉ được load một lần, gọi lần 2 là không load nữa.
        /// </summary>
        /// <param name="lookupArea"></param>
        public static void InitLookUpEdit(Control.ULookUpEdit lookup, string condition)
        {
            DataTable dtbCopy = null;
            if (condition != "" && condition != null)
            {
                dtbCopy = Table.Copy();
                dtbCopy.DefaultView.RowFilter = "CourseID is null or (" + condition + ")";
                //Table.DefaultView.RowFilter = condition;
            }
            else
                dtbCopy = Table;
            lookup.InitData(dtbCopy, "--Chọn--", SIM_Course.C_CourseID , SIM_Course.C_CourseName , SIM_Course.C_CourseID , "Mã khóa học", SIM_Course.C_CourseName , "Tên khóa học");
        }

        /// <summary>
        /// Khởi tạo Check combobox. Chú ý data chỉ được load một lần, gọi lần 2 là không load nữa.
        /// </summary>
        /// <param name="lookupArea"></param>
        public static void InitLookUpEdit(Control.UCheckedComboBoxEdit checkCbx)
        {
            InitLookUpEdit(checkCbx, "");
        }
        /// <summary>
        /// Khởi tạo Check combobox. Chú ý data chỉ được load một lần, gọi lần 2 là không load nữa.
        /// </summary>
        /// <param name="lookupArea"></param>
        public static void InitLookUpEdit(Control.UCheckedComboBoxEdit checkCbx, string condition)
        {
            DataTable dtbCopy = null;
            if (condition != "" && condition != null)
            {
                dtbCopy = Table.Copy();
                dtbCopy.DefaultView.RowFilter = "CourseID is not null And (" + condition + ")";
                //Table.DefaultView.RowFilter = condition;
            }
            else
                dtbCopy = Table;
            checkCbx.InitData(dtbCopy, "--Chọn--", SIM_Course.C_CourseID, SIM_Course.C_CourseName);
        }


        /// <summary>
        /// Khởi tạo combobox. Chú ý data chỉ được load một lần, gọi lần 2 là không load nữa.
        /// </summary>
        /// <param name="lookupCategory"></param>
        public static void InitLookUpEdit(Control.UGridLookUpEdit lookup)
        {
            InitLookUpEdit(lookup, "");
        }

        /// <summary>
        /// Khởi tạo combobox. Chú ý data chỉ được load một lần, gọi lần 2 là không load nữa.
        /// </summary>
        /// <param name="lookupArea"></param>
        public static void InitLookUpEdit(Control.UGridLookUpEdit lookup, string condition)
        {
            DataTable dtbCopy = null;
            if (condition != "" && condition != null)
            {
                dtbCopy = Table.Copy();
                dtbCopy.DefaultView.RowFilter = "CourseID is null or (" + condition + ")";
                //Table.DefaultView.RowFilter = condition;
            }
            else
                dtbCopy = Table;
            lookup.InitData(dtbCopy, "--Chọn--", SIM_Course.C_CourseID, SIM_Course.C_CourseName, SIM_Course.C_CourseID, "Mã khóa học", SIM_Course.C_CourseName, "Tên khóa học");
        }

        #endregion

        public static void InitRepositoryLookUpEdit(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repository)
        {
            Control.DgGridView.InitRepositoryLookUpEdit(repository, Table, "--Chọn khóa học--", SIM_Course.C_CourseID , SIM_Course.C_CourseName , SIM_Course.C_CourseID , "Mã khóa học", SIM_Course.C_CourseName , "Tên khóa học");
        }

        public static string GetPreviousCourseID(string courseID)
        {
            DataTable dtb = Table.Copy();            
            dtb.DefaultView.RowFilter = "CourseID < '" + courseID + "' and CourseID<>''";
            dtb.DefaultView.Sort = "CourseID DESC";
            if (dtb.DefaultView.Table.Rows.Count > 0)
                return dtb.DefaultView[0][SIM_Course.C_CourseID].ToString();
            return null;
        }

    }
}
