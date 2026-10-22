using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Global;
using SimsObject;


namespace SimsService
{
    public class INS_InsuTypeService
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
                    INS_InsuType objInsuType = new INS_InsuType();
                    dtbTable = objInsuType.GetDataTable("INS_InsuType_SearchCbx");
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
        /// <param name="lookupInsuType"></param>
        public static void InitLookUpEdit(Control.UGridLookUpEdit lookup, string condition)
        {
            DataTable dtbCopy = null;
            if (condition != "" && condition != null)
            {
                dtbCopy = Table.Copy();
                dtbCopy.DefaultView.RowFilter = "(" + condition + ")" + " or InsuTypeID is null";
                //Table.DefaultView.RowFilter = condition;
            }
            else
                dtbCopy = Table;
            lookup.InitData(dtbCopy, "--Chọn--", INS_InsuType.C_InsuTypeID, INS_InsuType.C_InsuTypeName,
                                INS_InsuType.C_InsuTypeCode, "Mã", INS_InsuType.C_InsuTypeName, "Tên");
        }

        public static void InitRepositoryLookUpEdit(DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repository)
        {
            Control.DgGridView.InitRepositoryLookUpEdit(repository, Table, "--Chọn--", INS_InsuType.C_InsuTypeID, INS_InsuType.C_InsuTypeName,
                                INS_InsuType.C_InsuTypeCode, "Mã", INS_InsuType.C_InsuTypeName, "Tên");
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
