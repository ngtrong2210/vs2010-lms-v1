using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Global;
using SimsObject;


namespace SimsService
{
    public partial class SIM_SubjectPlanService
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
                    SIM_SubjectPlan obj = new SIM_SubjectPlan();
                    dtbTable = obj.GetDataTable("SIM_SubjectPlan_SearchCbx");
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
        public static void InitLookUpEdit(Control.DgGridLookUpEdit lookup)
        {
            InitLookUpEdit(lookup, "");
        }

        /// <summary>
        /// Khởi tạo combobox. Chú ý data chỉ được load một lần, gọi lần 2 là không load nữa.
        /// </summary>
        /// <param name="lookupClass"></param>
        public static void InitLookUpEdit(Control.DgGridLookUpEdit lookup, string condition)
        {
            DataTable dtbCopy = null;
            if (condition != "" && condition != null)
            {
                dtbCopy = Table.Copy();
                dtbCopy.DefaultView.RowFilter = "(" + condition + ")" + " or SubjectPlanID is null";
                //Table.DefaultView.RowFilter = condition;
            }
            else
                dtbCopy = Table;
            lookup.InitData(dtbCopy, "--Chọn--", SIM_SubjectPlan.C_SubjectPlanID, SIM_SubjectPlan.C_Content, SIM_SubjectPlan.C_ContentGroup, "Nhóm", SIM_SubjectPlan.C_Content, "Nội dung dạy", SIM_SubjectPlan.C_Quantity, "Số giờ/học viên");
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
        /// <param name="lookupClass"></param>
        public static void InitLookUpEdit(Control.UGridLookUpEdit lookup, string condition)
        {
            DataTable dtbCopy = null;
            if (condition != "" && condition != null)
            {
                dtbCopy = Table.Copy();
                dtbCopy.DefaultView.RowFilter = "(" + condition + ")" + " or SubjectPlanID is null";
                //Table.DefaultView.RowFilter = condition;
            }
            else
                dtbCopy = Table;
            lookup.InitData(dtbCopy, "--Chọn--", SIM_SubjectPlan.C_SubjectPlanID, SIM_SubjectPlan.C_Content, SIM_SubjectPlan.C_ContentGroup, "Nhóm", SIM_SubjectPlan.C_Content, "Nội dung dạy", SIM_SubjectPlan.C_Quantity, "Số giờ/học viên");
        }



        public static void InitRepositoryLookUpEdit(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repository, string condition = null)
        {
            DataTable dtbCopy = null;
            if (condition != "" && condition != null)
            {
                dtbCopy = Table.Copy();
                dtbCopy.DefaultView.RowFilter = "(" + condition + ")" + " or SubjectPlanID is null";
                //Table.DefaultView.RowFilter = condition;
            }
            else
                dtbCopy = Table.Copy();

            Control.DgGridView.InitRepositoryLookUpEdit(repository, dtbCopy, "--Chọn--", SIM_SubjectPlan.C_SubjectPlanID, SIM_SubjectPlan.C_Content, SIM_SubjectPlan.C_ContentGroup, "Nhóm", SIM_SubjectPlan.C_Content, "Nội dung dạy", SIM_SubjectPlan.C_Quantity, "Số giờ/học viên");
        }

        public static void InitRepositoryLookUpEdit(DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repository, string condition = null)
        {
            DataTable dtbCopy = null;
            if (condition != "" && condition != null)
            {
                dtbCopy = Table.Copy();
                dtbCopy.DefaultView.RowFilter = "(" + condition + ")" + " or SubjectPlanID is null";
                //Table.DefaultView.RowFilter = condition;
            }
            else
                dtbCopy = Table.Copy();

            Control.DgAdvBandedGridView.InitRepositoryLookUpEdit(repository, dtbCopy, "--Chọn--", SIM_SubjectPlan.C_SubjectPlanID, SIM_SubjectPlan.C_Content, SIM_SubjectPlan.C_ContentGroup, "Nhóm", SIM_SubjectPlan.C_Content, "Nội dung dạy", SIM_SubjectPlan.C_Quantity, "Số giờ/học viên");
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
