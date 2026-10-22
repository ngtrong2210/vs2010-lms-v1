using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Global;
using SimsObject;


namespace SimsService
{
    public partial class SIM_TrainingLevelService
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
                    SIM_TrainingLevel objTrainingLevel = new SIM_TrainingLevel();
                    dtbTable = objTrainingLevel.GetAll();
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
        /// <param name="lookupTrainingLevel"></param>
        public static void InitLookUpEdit(Control.DgLookUpEdit lookup, string condition)
        {
            DataTable dtbCopy = null;
            if (condition != "" && condition != null)
            {
                dtbCopy = Table.Copy();
                dtbCopy.DefaultView.RowFilter = "TrainingLevelID is null or (" + condition + ")";
                //Table.DefaultView.RowFilter = condition;
            }
            else
                dtbCopy = Table;
            lookup.InitData(dtbCopy, "--Chọn--", SIM_TrainingLevel.C_TrainingLevelID, SIM_TrainingLevel.C_TrainingLevelName, SIM_TrainingLevel.C_TrainingLevelID, "Mã bậc đào tạo", SIM_TrainingLevel.C_TrainingLevelName, "Tên bậc đào tạo");
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
        /// <param name="lookupTrainingLevel"></param>
        public static void InitLookUpEdit(Control.ULookUpEdit lookup, string condition)
        {            
            DataTable dtbCopy = null;
            if (condition != "" && condition != null)
            {
                dtbCopy = Table.Copy();
                dtbCopy.DefaultView.RowFilter = "TrainingLevelID is null or (" + condition + ")";
                //Table.DefaultView.RowFilter = condition;
            }
            else
                dtbCopy = Table;
            lookup.InitData(dtbCopy, "--Chọn--", SIM_TrainingLevel.C_TrainingLevelID, SIM_TrainingLevel.C_TrainingLevelName, SIM_TrainingLevel.C_TrainingLevelID, "Mã bậc đào tạo", SIM_TrainingLevel.C_TrainingLevelName, "Tên bậc đào tạo");
        }

        public static void InitLookUpEdit(Control.UGridLookUpEdit lookup)
        {
            InitLookUpEdit(lookup, "");
        }

        /// <summary>
        /// Khởi tạo combobox. Chú ý data chỉ được load một lần, gọi lần 2 là không load nữa.
        /// </summary>
        /// <param name="lookupTrainingLevel"></param>
        public static void InitLookUpEdit(Control.UGridLookUpEdit lookup, string condition)
        {
            DataTable dtbCopy = null;
            if (condition != "" && condition != null)
            {
                dtbCopy = Table.Copy();
                dtbCopy.DefaultView.RowFilter = "TrainingLevelID is null or (" + condition + ")";
                //Table.DefaultView.RowFilter = condition;
            }
            else
                dtbCopy = Table;
            lookup.InitData(dtbCopy, "--Chọn--", SIM_TrainingLevel.C_TrainingLevelID, SIM_TrainingLevel.C_TrainingLevelName, SIM_TrainingLevel.C_TrainingLevelID, "Mã bậc đào tạo", SIM_TrainingLevel.C_TrainingLevelName, "Tên bậc đào tạo");
        }


        /// <summary>
        /// Khởi tạo check combobox. Chú ý data chỉ được load một lần, gọi lần 2 là không load nữa.
        /// </summary>
        /// <param name="lookupTrainingLevel"></param>
        public static void InitLookUpEdit(Control.UCheckedComboBoxEdit checkCbx, string condition)
        {
            DataTable dtbCopy = dtbCopy = Table.Copy();
            if (condition != "" && condition != null)
            {
                dtbCopy.DefaultView.RowFilter = "TrainingLevelID is not null and (" + condition + ")";
                //Table.DefaultView.RowFilter = condition;
            }
            else
                dtbCopy.DefaultView.RowFilter = "TrainingLevelID is not null";

            checkCbx.InitData(dtbCopy, "--Chọn--", SIM_TrainingLevel.C_TrainingLevelID, SIM_TrainingLevel.C_TrainingLevelName);
        }
        public static void InitLookUpEdit(Control.UCheckedComboBoxEdit checkCbx)
        {
            InitLookUpEdit(checkCbx, null);
        }

        #endregion


        public static void InitRepositoryLookUpEdit(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repository)
        {
            Control.DgGridView.InitRepositoryLookUpEdit(repository, Table, "--Chọn bậc đào tạo--", SIM_TrainingLevel.C_TrainingLevelID, SIM_TrainingLevel.C_TrainingLevelName, SIM_TrainingLevel.C_TrainingLevelID, "Mã bậc đào tạo", SIM_TrainingLevel.C_TrainingLevelName, "Tên bậc đào tạo");
        }
    }
}
