using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Global;
using SimsObject;


namespace SimsService
{
    public class SIM_SpecialTypeService
    {
        static bool bolHaveNewData = false;
        static DataTable dtbTable = null;

        public static DataTable Table
        {
            get
            {
                if (dtbTable == null || bolHaveNewData)
                {
                    dtbTable = new DataTable();
                    dtbTable.Columns.Add("SpecialType", typeof(int));
                    dtbTable.Columns.Add("SpecialTypeText", typeof(string));
                    int[] intSpecialTypes = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                    string[] strSpecialTypeTexts = { "Bình thường", "Tốt nghiệp LT", "Tốt nghiệp TH", "CT tốt nghiệp", "Tốt nghiệp văn hoá", "GD thể chất", "GD quốc phòng", "Văn hoá", "Thực tập" };

                    DataRow drw = dtbTable.NewRow();
                    dtbTable.Rows.Add(drw);

                    for (int i = 0; i < intSpecialTypes.Length; i++)
                    {
                        drw = dtbTable.NewRow();
                        drw["SpecialType"] = intSpecialTypes[i];
                        drw["SpecialTypeText"] = strSpecialTypeTexts[i];
                        dtbTable.Rows.Add(drw);
                        drw = dtbTable.NewRow();
                    }

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
        /// <param name="lookupSchool"></param>
        public static void InitLookUpEdit(Control.UGridLookUpEdit lookup, string condition)
        {
            DataTable dtbCopy = null;
            if (condition != "" && condition != null)
            {
                dtbCopy = Table.Copy();
                dtbCopy.DefaultView.RowFilter = "(" + condition + ")" + " or SchoolID is null";
                //Table.DefaultView.RowFilter = condition;
            }
            else
                dtbCopy = Table;

            lookup.InitData(dtbCopy, "--Chọn--", "SpecialType", "SpecialTypeText", "SpecialTypeText", "Đặc trưng môn");
        }

        #endregion 

        #region Init repository

        public static void InitRepositoryLookUpEdit(DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repository)
        {
            Control.DgGridView.InitRepositoryLookUpEdit(repository, Table.Copy(), "--Chọn--", "SpecialType", "SpecialTypeText",
                                        "SpecialType", "Mã", "SpecialTypeText", "Đặc trưng môn");
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
