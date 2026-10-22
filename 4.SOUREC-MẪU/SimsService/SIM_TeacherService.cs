using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Global;
using SimsObject;


namespace SimsService
{
    public partial class SIM_TeacherService
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
                    SIM_Teacher objTeacher = new SIM_Teacher();
                    dtbTable = objTeacher.Search();
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

        #region Init LookupEdit

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
        /// <param name="lookupRoom"></param>
        public static void InitLookUpEdit(Control.DgLookUpEdit lookup, string condition)
        {
            DataTable dtbCopy = null;
            if (condition != "" && condition != null)
            {
                dtbCopy = Table.Copy();
                dtbCopy.DefaultView.RowFilter = "(" + condition + ")" + " or TeacherID is null";
                //Table.DefaultView.RowFilter = condition;
            }
            else
                dtbCopy = Table;
            lookup.InitData(dtbCopy, "--Chọn--", SIM_Teacher.C_TeacherID, "FullName", SIM_Teacher.C_TeacherID, "Mã giáo viên", "FullName", "Tên giáo viên");
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
        /// <param name="lookupRoom"></param>
        public static void InitLookUpEdit(Control.ULookUpEdit lookup, string condition)
        {
            DataTable dtbCopy = null;
            if (condition != null && condition != "")
            {
                dtbCopy = Table.Copy();
                dtbCopy.DefaultView.RowFilter = "(" + condition + ")" + " or TeacherID is null";
                //Table.DefaultView.RowFilter = condition;
            }
            else
                dtbCopy = Table;
            lookup.InitData(dtbCopy, "--Chọn--", SIM_Teacher.C_TeacherID, "FullName", SIM_Teacher.C_TeacherID, "Mã giáo viên", "FullName", "Tên giáo viên");
        }

        public static void InitRepositoryLookUpEdit(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repository)
        {
            InitRepositoryLookUpEdit(repository, null);
        }

        public static void InitRepositoryLookUpEdit(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repository, string condition)
        {
            DataTable dtbCopy = null;
            if ( condition != null && condition != "")
            {
                dtbCopy = Table.Copy();
                dtbCopy.DefaultView.RowFilter = "(" + condition + ")" + " or TeacherID is null";
                //Table.DefaultView.RowFilter = condition;
            }
            else
                dtbCopy = Table;
            Control.DgGridView.InitRepositoryLookUpEdit(repository, dtbCopy, "", SIM_Teacher.C_TeacherID ,"FullName" , SIM_Teacher.C_TeacherID, "Mã giáo viên", "FullName", "Tên giáo viên");
        }

        #endregion


        #region Init GridLookupEdit

        /// <summary>
        /// Khởi tạo combobox. Chú ý data chỉ được load một lần, gọi lần 2 là không load nữa.
        /// </summary>
        /// <param name="lookupCategory"></param>
        public static void InitGridLookUpEdit(Control.DgGridLookUpEdit lookup)
        {
            InitGridLookUpEdit(lookup, "");
        }

        /// <summary>
        /// Khởi tạo combobox. Chú ý data chỉ được load một lần, gọi lần 2 là không load nữa.
        /// </summary>
        /// <param name="lookupRoom"></param>
        public static void InitGridLookUpEdit(Control.DgGridLookUpEdit lookup, string condition)
        {
            DataTable dtbCopy = null;
            if (condition != "" && condition != null)
            {
                dtbCopy = Table.Copy();
                dtbCopy.DefaultView.RowFilter = "(" + condition + ")" + " or TeacherID is null";
                //Table.DefaultView.RowFilter = condition;
            }
            else
                dtbCopy = Table;
            lookup.InitData(dtbCopy, "--Chọn--", SIM_Teacher.C_TeacherID, "FullName", SIM_Teacher.C_TeacherID, "Mã giáo viên", "FullName", "Tên giáo viên");
        }

        /// <summary>
        /// Khởi tạo combobox. Chú ý data chỉ được load một lần, gọi lần 2 là không load nữa.
        /// </summary>
        /// <param name="lookupCategory"></param>
        public static void InitGridLookUpEdit(Control.UGridLookUpEdit lookup)
        {
            InitGridLookUpEdit(lookup, "");
        }

        /// <summary>
        /// Khởi tạo combobox. Chú ý data chỉ được load một lần, gọi lần 2 là không load nữa.
        /// </summary>
        /// <param name="lookupRoom"></param>
        public static void InitGridLookUpEdit(Control.UGridLookUpEdit lookup, string condition)
        {
            DataTable dtbCopy = null;
            if (condition != null && condition != "")
            {
                dtbCopy = Table.Copy();
                dtbCopy.DefaultView.RowFilter = "(" + condition + ")" + " or TeacherID is null";
                //Table.DefaultView.RowFilter = condition;
            }
            else
                dtbCopy = Table;
            lookup.InitData(dtbCopy, "--Chọn--", SIM_Teacher.C_TeacherID, "FullName", SIM_Teacher.C_TeacherID, "Mã giáo viên", "FullName", "Tên giáo viên");
        }

        public static void InitRepositoryLookUpEdit(DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repository)
        {
            InitRepositoryLookUpEdit(repository, null);
        }

        public static void InitRepositoryLookUpEdit(DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repository, string condition)
        {
            DataTable dtbCopy = null;
            if (condition != null && condition != "")
            {
                dtbCopy = Table.Copy();
                dtbCopy.DefaultView.RowFilter = "(" + condition + ")" + " or TeacherID is null";
                //Table.DefaultView.RowFilter = condition;
            }
            else
                dtbCopy = Table;
            Control.DgAdvBandedGridView.InitRepositoryLookUpEdit(repository, dtbCopy, "", SIM_Teacher.C_TeacherID, "FullName", SIM_Teacher.C_TeacherID, "Mã giáo viên", "FullName", "Tên giáo viên");
        }


        public static void InitRepositoryLookUpEdit(Control.DgAdvBandedGridView gvData, string fieldName)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repository = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            repository.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            InitRepositoryLookUpEdit(repository);
            gvData.Columns[fieldName].ColumnEdit = repository;
        }

        public static void InitRepositoryLookUpEdit(Control.DgGridView gvData, string fieldName)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repository = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            repository.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            InitRepositoryLookUpEdit(repository);
            gvData.Columns[fieldName].ColumnEdit = repository;
        }

        #endregion


    }
}
