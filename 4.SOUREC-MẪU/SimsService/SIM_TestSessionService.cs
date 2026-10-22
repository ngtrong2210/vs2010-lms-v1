using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Global;
using SimsObject;


namespace SimsService
{
    public partial class SIM_TestSessionService
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
                    SIM_TestSession objTestSessionDAO = new SIM_TestSession();
                    dtbTable = objTestSessionDAO.GetDataTable("SIM_TestSession_SearchCbx");
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
        /// <param name="lookupTestSession"></param>
        public static void InitLookUpEdit(Control.DgLookUpEdit lookup, string condition)
        {
            DataTable dtbCopy = null;
            if (condition != "" && condition != null)
            {
                dtbCopy = Table.Copy();
                dtbCopy.DefaultView.RowFilter = "(" + condition + ")" + " or TestSessionID is null";
                //Table.DefaultView.RowFilter = condition;
            }
            else
                dtbCopy = Table;
            lookup.InitData(dtbCopy, "--Chọn--", SIM_TestSession.C_TestSessionID, SIM_TestSession.C_TestSessionName, SIM_TestSession.C_TestSessionID, "Mã ca", SIM_TestSession.C_TestSessionName, "Tên ca thi", SIM_TestSession.C_Description, "Ghi chú");
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
        /// <param name="lookupTestSession"></param>
        public static void InitLookUpEdit(Control.ULookUpEdit lookup, string condition)
        {
            DataTable dtbCopy = null;
            if (condition != "" && condition != null)
            {
                dtbCopy = Table.Copy();
                dtbCopy.DefaultView.RowFilter = "(" + condition + ")" + " or TestSessionID is null";
                //Table.DefaultView.RowFilter = condition;
            }
            else
                dtbCopy = Table;
            lookup.InitData(dtbCopy, "--Chọn--", SIM_TestSession.C_TestSessionID, SIM_TestSession.C_TestSessionName, SIM_TestSession.C_TestSessionID, "Mã ca", SIM_TestSession.C_TestSessionName, "Tên ca thi", SIM_TestSession.C_Description, "Ghi chú");
        }



        public static void InitRepositoryLookUpEdit(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repository)
        {
            Control.DgGridView.InitRepositoryLookUpEdit(repository, Table, "--Chọn ca thi--", SIM_TestSession.C_TestSessionID, SIM_TestSession.C_TestSessionName, SIM_TestSession.C_TestSessionID, "Mã ca", SIM_TestSession.C_TestSessionName, "Tên ca thi", SIM_TestSession.C_Description, "Ghi chú");
        }

        public static void InitRepositoryLookUpEdit(DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repository)
        {
            Control.DgGridView.InitRepositoryLookUpEdit(repository, Table, "--Chọn ca thi--", SIM_TestSession.C_TestSessionID, SIM_TestSession.C_TestSessionName, SIM_TestSession.C_TestSessionID, "Mã ca", SIM_TestSession.C_TestSessionName, "Tên ca thi", SIM_TestSession.C_Description, "Ghi chú");
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
