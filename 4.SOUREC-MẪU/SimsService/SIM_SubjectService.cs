using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SimsObject;


namespace SimsService
{
    public partial class SIM_SubjectService
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
                    SIM_Subject objSubjectDAO = new SIM_Subject();
                    dtbTable = objSubjectDAO.GetDataTable("SIM_Subject_SearchCBX");
                    DataRow drw = dtbTable.NewRow();
                    
                    dtbTable.Rows.InsertAt(drw, 0); // thêm dòng trống
                    bolHaveNewData = false;
                }
                return dtbTable;
            }
            set {dtbTable = value; }
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
        /// <param name="lookupSubject"></param>
        public static void InitLookUpEdit(Control.DgLookUpEdit lookup, string condition)
        {
            DataTable dtbCopy = null;
            if (condition != "" && condition != null)
            {
                dtbCopy = Table.Copy();
                dtbCopy.DefaultView.RowFilter = "(" + condition + ")" + " or SubjectID is null";
                //Table.DefaultView.RowFilter = condition;
            }
            else
                dtbCopy = Table;
            lookup.InitData(dtbCopy, "--Chọn--", SIM_Subject.C_SubjectID, SIM_Subject.C_SubjectName , SIM_Subject.C_SubjectID, "Mã môn", SIM_Subject.C_SubjectName, "Tên môn");
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
        /// <param name="lookupSubject"></param>
        public static void InitLookUpEdit(Control.ULookUpEdit lookup, string condition)
        {
            DataTable dtbCopy = null;
            if (condition != "" && condition != null)
            {
                dtbCopy = Table.Copy();
                dtbCopy.DefaultView.RowFilter = "(" + condition + ")" + " or SubjectID is null";
                //Table.DefaultView.RowFilter = condition;
            }
            else
                dtbCopy = Table;
            lookup.InitData(dtbCopy, "--Chọn--", SIM_Subject.C_SubjectID, SIM_Subject.C_SubjectName, SIM_Subject.C_SubjectID, "Mã môn", SIM_Subject.C_SubjectName, "Tên môn");
        }



        public static void InitRepositoryLookUpEdit(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repository)
        {
            Control.DgGridView.InitRepositoryLookUpEdit(repository, Table, "--Chọn--", SIM_Subject.C_SubjectID, SIM_Subject.C_SubjectName, SIM_Subject.C_SubjectID, "Mã môn", SIM_Subject.C_SubjectName, "Tên môn");
        }

        #endregion


        #region Init GridLookupEdit

        /// <summary>
        /// Khởi tạo combobox. Chú ý data chỉ được load một lần, gọi lần 2 là không load nữa.
        /// </summary>
        /// <param name="lookupCategory"></param>
        public static void InitLookUpEdit(Control.DgGridLookUpEdit lookup)
        {
            InitLookUpEdit(lookup, "");
        }

        /// <summary>
        /// Khởi tạo combobox. Chú ý data chỉ được load một lần, gọi lần 2 là không load nữa.
        /// </summary>
        /// <param name="lookupSubject"></param>
        public static void InitLookUpEdit(Control.DgGridLookUpEdit lookup, string condition)
        {
            DataTable dtbCopy = null;
            if (condition != "" && condition != null)
            {
                dtbCopy = Table.Copy();
                dtbCopy.DefaultView.RowFilter = "(" + condition + ")" + " or SubjectID is null";
                //Table.DefaultView.RowFilter = condition;
            }
            else
                dtbCopy = Table;
            lookup.InitData(dtbCopy, "--Chọn--", SIM_Subject.C_SubjectID, SIM_Subject.C_SubjectName, SIM_Subject.C_SubjectID, "Mã môn", SIM_Subject.C_SubjectName, "Tên môn", "SubjectGroupName", "Bộ môn");
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
        /// <param name="lookupSubject"></param>
        public static void InitLookUpEdit(Control.UGridLookUpEdit lookup, string condition)
        {
            DataTable dtbCopy = null;
            if (condition != "" && condition != null)
            {
                dtbCopy = Table.Copy();
                dtbCopy.DefaultView.RowFilter = "(" + condition + ")" + " or SubjectID is null";
                //Table.DefaultView.RowFilter = condition;
            }
            else
                dtbCopy = Table;
            lookup.InitData(dtbCopy, "--Chọn--", SIM_Subject.C_SubjectID, SIM_Subject.C_SubjectName, SIM_Subject.C_SubjectID, "Mã môn", SIM_Subject.C_SubjectName, "Tên môn", "SubjectGroupName", "Bộ môn");
        }



        public static void InitRepositoryLookUpEdit(DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repository)
        {
            Control.DgGridView.InitRepositoryLookUpEdit(repository, Table, "--Chọn--", SIM_Subject.C_SubjectID, SIM_Subject.C_SubjectName, SIM_Subject.C_SubjectID, "Mã môn", SIM_Subject.C_SubjectName, "Tên môn", "SubjectGroupName", "Bộ môn");
        }

        #endregion

        public static int CalculatorUnitText(int? theory, int? practice, int? test)
        {
            if (theory == null)
                theory = 0;
            if (practice == null)
                practice = 0;
            if (test == null)
                test = 0;
            int a = Convert.ToInt32( Math.Round(theory.Value / 15.0,1));
            int b = Convert.ToInt32( Math.Round((practice.Value + test.Value) / 40.0,1));

            if (a == 0 && theory > 0) a = 1;
            if (b == 0 && practice + test > 0) b = 1;

            return Convert.ToInt32(a + b);
        }
    }
}
