using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Global;
using SimsObject;


namespace SimsService
{
    public partial class SIM_SessionService
    {        
        static DataTable dtbTable = null;

        public static DataTable Table
        {
            get
            {
                if (dtbTable == null)
                {
                    CreateData();
                }
                return dtbTable;
            }
            set {dtbTable = value; }
        }

        private static void CreateData()
        {
            dtbTable = new DataTable();
            dtbTable.Columns.Add("Session", typeof(int));
            dtbTable.Columns.Add("SessionText", typeof(string));

            DataRow drw = dtbTable.NewRow();          
            drw["SessionText"] = "--Chọn--";
            dtbTable.Rows.Add(drw);

            drw = dtbTable.NewRow();
            drw["Session"] = 1;
            drw["SessionText"] = "Sáng";
            dtbTable.Rows.Add(drw);
            drw = dtbTable.NewRow();

            drw = dtbTable.NewRow();
            drw["Session"] = 2;
            drw["SessionText"] = "Chiều";
            dtbTable.Rows.Add(drw);

            drw = dtbTable.NewRow();
            drw["Session"] = 3;
            drw["SessionText"] = "Tối";
            dtbTable.Rows.Add(drw);
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
                dtbCopy.DefaultView.RowFilter = "(" + condition + ")" + " or Session is null";
                //Table.DefaultView.RowFilter = condition;
            }
            else
                dtbCopy = Table;
            lookup.InitData(dtbCopy, "--Chọn--", "Session", "SessionText", "SessionText", "Buổi học");            
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
                dtbCopy.DefaultView.RowFilter = "(" + condition + ")" + " or Session is null";
                //Table.DefaultView.RowFilter = condition;
            }
            else
                dtbCopy = Table;
            lookup.InitData(dtbCopy, "--Chọn--", "Session", "SessionText", "SessionText", "Buổi học");
        }


        #endregion


        public static void InitRepositoryLookUpEdit(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repository)
        {
            Control.DgGridView.InitRepositoryLookUpEdit(repository, Table, "", "Session", "SessionText", "SessionText", "Buổi học");            
        }
    }
}
