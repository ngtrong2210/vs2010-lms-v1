using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Global;
using SimsObject;
using System.Windows.Forms;


namespace SimsService
{
    public partial class SIM_ScienceService
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
                    SIM_Science obj = new SIM_Science();
                    dtbTable = obj.GetAll();

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
            DataTable dtbCopy = Table.Copy();
            if (condition != "" && condition != null)
            {                
                dtbCopy.DefaultView.RowFilter = "ScienceID is null OR (" + condition + ")";
                //Table.DefaultView.RowFilter = condition;
            }
            lookup.InitData(dtbCopy, "--Chọn--", SIM_Science.C_ScienceID , SIM_Science.C_ScienceName , SIM_Science.C_ScienceID , "Mã ngành", SIM_Science.C_ScienceName, "Tên khoa");
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
            DataTable dtbCopy = Table.Copy();
            if (condition != "" && condition != null)
            {                
                dtbCopy.DefaultView.RowFilter = " SCIENCEID is null OR (" + condition + ")";
                //Table.DefaultView.RowFilter = condition;
            }
            
            lookup.InitData(dtbCopy, "--Chọn--", SIM_Science.C_ScienceID, SIM_Science.C_ScienceName, SIM_Science.C_ScienceID,"Mã khoa", SIM_Science.C_ScienceName, "Tên khoa");            
        }

        /// <summary>
        /// Khởi tạo check combobox. Chú ý data chỉ được load một lần, gọi lần 2 là không load nữa.
        /// </summary>
        /// <param name="lookupArea"></param>
        public static void InitLookUpEdit(Control.UCheckedComboBoxEdit chkCbx, string condition)
        {
            DataTable dtbCopy = Table.Copy();
            if (condition != "" && condition != null)
            {
                dtbCopy.DefaultView.RowFilter = " SCIENCEID is not null And (" + condition + ")";
                //Table.DefaultView.RowFilter = condition;
            }
            else
                dtbCopy.DefaultView.RowFilter = " SCIENCEID is not null";

            chkCbx.InitData(dtbCopy, "--Chọn--", SIM_Science.C_ScienceID, SIM_Science.C_ScienceName);
        }

        public static void InitLookUpEdit(Control.UCheckedComboBoxEdit chkCbx)
        {
            InitLookUpEdit(chkCbx, null);
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
        /// <param name="lookupArea"></param>
        public static void InitLookUpEdit(Control.UGridLookUpEdit lookup, string condition)
        {
            DataTable dtbCopy = Table.Copy();
            if (condition != "" && condition != null)
            {
                dtbCopy.DefaultView.RowFilter = " SCIENCEID is null OR (" + condition + ")";
                //Table.DefaultView.RowFilter = condition;
            }

            lookup.InitData(dtbCopy, "--Chọn--", SIM_Science.C_ScienceID, SIM_Science.C_ScienceName, SIM_Science.C_ScienceID, "Mã khoa", SIM_Science.C_ScienceName, "Tên khoa");
        }          

        #endregion


        public static void InitRepositoryLookUpEdit(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repository)
        {
            Control.DgGridView.InitRepositoryLookUpEdit(repository, Table, "--Chọn khoa--", SIM_Science.C_ScienceID, SIM_Science.C_ScienceName, SIM_Science.C_ScienceID, "Mã khoa", SIM_Science.C_ScienceName , "Tên khoa");
            
        }
    }
}
