using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Global;
using SimsObject;


namespace SimsService
{
    public class INS_InsuPeriodService
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
                    INS_InsuPeriod objInsuPeriod = new INS_InsuPeriod();
                    dtbTable = objInsuPeriod.GetDataTable("INS_InsuPeriod_SearchCbx");
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
        public static void InitLookUpEdit(Control.UGridLookUpEdit lookup)
        {
            InitLookUpEdit(lookup, "");
        }

        /// <summary>
        /// Khởi tạo combobox. Chú ý data chỉ được load một lần, gọi lần 2 là không load nữa.
        /// </summary>
        /// <param name="lookupInsuPeriod"></param>
        public static void InitLookUpEdit(Control.UGridLookUpEdit lookup, string condition)
        {
            DataTable dtbCopy = null;
            if (condition != "" && condition != null)
            {
                dtbCopy = Table.Copy();
                dtbCopy.DefaultView.RowFilter = "(" + condition + ")" + " or InsuPeriodID is null";
                //Table.DefaultView.RowFilter = condition;
            }
            else
                dtbCopy = Table;
            lookup.InitData(dtbCopy, "--Chọn--", INS_InsuPeriod.C_InsuPeriodID, INS_InsuPeriod.C_InsuPeriodName,
                                INS_InsuPeriod.C_InsuPeriodCode, "Mã", INS_InsuPeriod.C_InsuPeriodName, "Tên");
        }

        public static void InitRepositoryLookUpEdit(DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repository)
        {
            Control.DgGridView.InitRepositoryLookUpEdit(repository, Table, "--Chọn--", INS_InsuPeriod.C_InsuPeriodID, INS_InsuPeriod.C_InsuPeriodName,
                                INS_InsuPeriod.C_InsuPeriodCode, "Mã", INS_InsuPeriod.C_InsuPeriodName, "Tên");
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
