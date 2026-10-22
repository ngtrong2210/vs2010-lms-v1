using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Global;
using SimsObject;


namespace SimsService
{
    public partial class SIM_ExamDateService
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
                    SIM_ExamDate objExamDateDAO = new SIM_ExamDate();
                    dtbTable = objExamDateDAO.GetDataTable("SIM_ExamDate_SearchCbx");
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
        /// <param name="lookupExamDate"></param>
        public static void InitLookUpEdit(Control.DgLookUpEdit lookup, string condition)
        {
            DataTable dtbCopy = null;
            if (condition != "" && condition != null)
            {
                dtbCopy = Table.Copy();
                dtbCopy.DefaultView.RowFilter = "(" + condition + ")" + " or ExamDateID is null";
                //Table.DefaultView.RowFilter = condition;
            }
            else
                dtbCopy = Table;
            lookup.InitData(dtbCopy, "--Chọn--", SIM_ExamDate.C_ExamDateID, SIM_ExamDate.C_ExamDateName, SIM_ExamDate.C_ExamDate, "Ngày thi", SIM_ExamDate.C_ExamDateName, "Tên kì thi");
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
        /// <param name="lookupExamDate"></param>
        public static void InitLookUpEdit(Control.ULookUpEdit lookup, string condition)
        {
            DataTable dtbCopy = Table.Copy();
            if (condition != "" && condition != null)
            {
                dtbCopy.DefaultView.RowFilter = "(" + condition + ")" + " or ExamDateID is null";
                dtbCopy = dtbCopy.DefaultView.ToTable();
            }

            lookup.InitData(dtbCopy, "--Chọn--", SIM_ExamDate.C_ExamDateID, SIM_ExamDate.C_ExamDateName, SIM_ExamDate.C_ExamDate, "Ngày thi", SIM_ExamDate.C_ExamDateName, "Tên kì thi");
        }



        public static void InitRepositoryLookUpEdit(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repository)
        {
            Control.DgGridView.InitRepositoryLookUpEdit(repository, Table, "--Chọn kì thi--", SIM_ExamDate.C_ExamDateID, SIM_ExamDate.C_ExamDateName, SIM_ExamDate.C_ExamDate, "Ngày thi", SIM_ExamDate.C_ExamDateName, "Tên kì thi");
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
        /// <param name="lookupExamDate"></param>
        public static void InitLookUpEdit(Control.UGridLookUpEdit lookup, string condition)
        {
            DataTable dtbCopy = Table.Copy();
            if (condition != "" && condition != null)
            {
                dtbCopy.DefaultView.RowFilter = "(" + condition + ")" + " or ExamDateID is null";
                dtbCopy = dtbCopy.DefaultView.ToTable();
            }

            lookup.InitData(dtbCopy, "--Chọn--", SIM_ExamDate.C_ExamDateID, SIM_ExamDate.C_ExamDateName, SIM_ExamDate.C_ExamDate, "Ngày thi", SIM_ExamDate.C_ExamDateName, "Tên kì thi");
        }


        public static void InitLookUpEdit(Control.UCheckedComboBoxEdit lookup)
        {
            InitLookUpEdit(lookup, "");
        }

        /// <summary>
        /// Khởi tạo combobox. Chú ý data chỉ được load một lần, gọi lần 2 là không load nữa.
        /// </summary>
        /// <param name="lookupStudentCollectionPeriod"></param>
        public static void InitLookUpEdit(Control.UCheckedComboBoxEdit lookup, string condition)
        {
            DataTable dtbCopy = Table.Copy();
            if (condition != "" && condition != null)
                dtbCopy.DefaultView.RowFilter = "(" + condition + ")" + " or ExamDateID is null";

            lookup.InitData(dtbCopy, "--Chọn--", SIM_ExamDate.C_ExamDateID, SIM_ExamDate.C_ExamDateName);
        }



        public static void InitRepositoryLookUpEdit(DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repository, string condition = null)
        {
            DataTable dtbCopy = Table.Copy();
            if (condition != "" && condition != null)
                dtbCopy.DefaultView.RowFilter = "(" + condition + ")" + " or ExamDateID is null";

            Control.DgGridView.InitRepositoryLookUpEdit(repository, dtbCopy, "--Chọn kì thi--", SIM_ExamDate.C_ExamDateID, SIM_ExamDate.C_ExamDateName, SIM_ExamDate.C_ExamDate, "Ngày thi", SIM_ExamDate.C_ExamDateName, "Tên kì thi");
        }

        public static void InitRepositoryLookUpEdit(Control.DgAdvBandedGridView gvData, string fieldName, string condition = null)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repository = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            repository.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            InitRepositoryLookUpEdit(repository, condition);
            gvData.Columns[fieldName].ColumnEdit = repository;
        }

        public static void InitRepositoryLookUpEdit(Control.DgGridView gvData, string fieldName, string condition = null)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repository = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            repository.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            InitRepositoryLookUpEdit(repository, condition);
            gvData.Columns[fieldName].ColumnEdit = repository;
        }


        #endregion


    }
}
