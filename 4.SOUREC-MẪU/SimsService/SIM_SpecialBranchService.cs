using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Global;
using SimsObject;

namespace SimsService
{
    public partial class SIM_SpecialBranchService
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
                    SIM_SpecialBranch objSpecialBranch = new SIM_SpecialBranch();
                    dtbTable = objSpecialBranch.Search();
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
                dtbCopy.DefaultView.RowFilter = "SpecialBranchID is null or (" + condition + ")";
                //Table.DefaultView.RowFilter = condition;
            }
            else
                dtbCopy = Table;
            lookup.InitData(dtbCopy, "--Chọn--", SIM_SpecialBranch.C_BranchID , SIM_SpecialBranch.C_SpecialBranchName, SIM_SpecialBranch.C_SpecialBranchID, "Mã chuyên ngành", SIM_SpecialBranch.C_SpecialBranchName, "Tên chuyên ngành");
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
            if (condition != "" && condition != null)
            {
                dtbCopy = Table.Copy();
                dtbCopy.DefaultView.RowFilter = "SpecialBranchID is null or (" + condition + ")";
                //Table.DefaultView.RowFilter = condition;
            }
            else
                dtbCopy = Table;
            lookup.InitData(dtbCopy, "--Chọn--", SIM_SpecialBranch.C_SpecialBranchID, SIM_SpecialBranch.C_SpecialBranchName, SIM_SpecialBranch.C_SpecialBranchID, "Mã chuyên ngành", SIM_SpecialBranch.C_SpecialBranchName, "Tên chuyên ngành");
        }

        public static void InitLookUpEdit(Control.UGridLookUpEdit lookup)
        {
            InitLookUpEdit(lookup, "");
        }

        /// <summary>
        /// Khởi tạo combobox. Chú ý data chỉ được load một lần, gọi lần 2 là không load nữa.
        /// </summary>
        /// <param name="lookupRoom"></param>
        public static void InitLookUpEdit(Control.UGridLookUpEdit lookup, string condition)
        {
            DataTable dtbCopy = null;
            if (condition != "" && condition != null)
            {
                dtbCopy = Table.Copy();
                dtbCopy.DefaultView.RowFilter = "SpecialBranchID is null or (" + condition + ")";
                //Table.DefaultView.RowFilter = condition;
            }
            else
                dtbCopy = Table;
            lookup.InitData(dtbCopy, "--Chọn--", SIM_SpecialBranch.C_SpecialBranchID, SIM_SpecialBranch.C_SpecialBranchName, SIM_SpecialBranch.C_SpecialBranchID, "Mã chuyên ngành", SIM_SpecialBranch.C_SpecialBranchName, "Tên chuyên ngành");
        }
        /// <summary>
        /// Khởi tạo check combobox box. Chú ý data chỉ được load một lần, gọi lần 2 là không load nữa.
        /// </summary>
        /// <param name="lookupRoom"></param>
        public static void InitLookUpEdit(Control.UCheckedComboBoxEdit checkCbx)
        {
            InitLookUpEdit(checkCbx, null);
        }
        /// <summary>
        /// Khởi tạo check combobox box. Chú ý data chỉ được load một lần, gọi lần 2 là không load nữa.
        /// </summary>
        /// <param name="lookupRoom"></param>
        public static void InitLookUpEdit(Control.UCheckedComboBoxEdit checkCbx, string condition)
        {
            DataTable dtbCopy = Table.Copy();
            if (condition != "" && condition != null)
            {
                dtbCopy.DefaultView.RowFilter = "SpecialBranchID is not null and (" + condition + ")";
                //Table.DefaultView.RowFilter = condition;
            }
            else
                dtbCopy.DefaultView.RowFilter = "SpecialBranchID is not null";

            checkCbx.InitData(dtbCopy, "--Chọn--", SIM_SpecialBranch.C_SpecialBranchID, SIM_SpecialBranch.C_SpecialBranchName);
        }
        
        public static void InitRepositoryLookUpEdit(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repository)
        {
            Control.DgGridView.InitRepositoryLookUpEdit(repository, Table, "--Chọn chuyên ngành--", SIM_SpecialBranch.C_SpecialBranchID , SIM_SpecialBranch.C_SpecialBranchName , SIM_SpecialBranch.C_SpecialBranchID, "Mã chuyên ngành", SIM_SpecialBranch.C_SpecialBranchName, "Tên chuyên ngành");
        }

        #endregion


    }
}
