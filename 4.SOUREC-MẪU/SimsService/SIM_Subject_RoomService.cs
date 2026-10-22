using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Global;
using SimsObject;

namespace SimsService
{
    public partial class SIM_Subject_RoomService
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
                    SIM_Subject_Room objSubject_Room = new SIM_Subject_Room();
                    dtbTable = objSubject_Room.Search(); // search để có nhiều trường hơn
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
        /// Chọn phòng chứ hông phải chọn môn  học phòng
        /// </summary>
        /// <param name="lookupCategory"></param>
        public static void InitLookUpEdit(Control.DgLookUpEdit lookup)
        {
            InitLookUpEdit(lookup, "");
        }

        /// <summary>
        /// Khởi tạo combobox. Chú ý data chỉ được load một lần, gọi lần 2 là không load nữa.
        /// Chọn phòng chứ hông phải chọn môn  học phòng
        /// </summary>
        /// <param name="lookupSubject_Room"></param>
        public static void InitLookUpEdit(Control.DgLookUpEdit lookup, string condition)
        {
            DataTable dtbCopy = null;
            if (condition != "" && condition != null)
            {
                dtbCopy = Table.Copy();
                dtbCopy.DefaultView.RowFilter = "(" + condition + ")" + " or SubjectRoomID is null";
                //Table.DefaultView.RowFilter = condition;
            }
            else
                dtbCopy = Table;
            lookup.InitData(dtbCopy, "--Chọn--", SIM_Subject_Room.C_RoomID, SIM_Room.C_RoomName, SIM_Room.C_RoomID, "Mã phòng", SIM_Room.C_RoomName, "Tên phòng");
        }

        /// <summary>
        /// Khởi tạo combobox. Chú ý data chỉ được load một lần, gọi lần 2 là không load nữa.
        /// Chọn phòng chứ hông phải chọn môn  học phòng
        /// </summary>
        /// <param name="lookupCategory"></param>
        public static void InitLookUpEdit(Control.ULookUpEdit lookup)
        {
            InitLookUpEdit(lookup, "");
        }

        /// <summary>
        /// Khởi tạo combobox. Chú ý data chỉ được load một lần, gọi lần 2 là không load nữa.
        /// Chọn phòng chứ hông phải chọn môn  học phòng
        /// </summary>
        /// <param name="lookupSubject_Room"></param>
        public static void InitLookUpEdit(Control.ULookUpEdit lookup, string condition)
        {
            DataTable dtbCopy = null;
            if (condition != "" && condition != null)
            {
                dtbCopy = Table.Copy();
                dtbCopy.DefaultView.RowFilter = "(" + condition + ")" + " or SubjectRoomID is null";
                //Table.DefaultView.RowFilter = condition;
            }
            else
                dtbCopy = Table;
            lookup.InitData(dtbCopy, "--Chọn--", SIM_Subject_Room.C_RoomID, SIM_Room.C_RoomName, SIM_Room.C_RoomID, "Mã phòng", SIM_Room.C_RoomName, "Tên phòng");
        }

        /// <summary>
        /// Chọn phòng chứ hông phải chọn môn  học phòng
        /// </summary>
        public static void InitRepositoryLookUpEdit(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repository)
        {
            InitRepositoryLookUpEdit(repository, null);
        }

        /// <summary>
        /// Chọn phòng chứ hông phải chọn môn  học phòng
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="condition"></param>
        public static void InitRepositoryLookUpEdit(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repository, string condition)
        {
            DataTable dtbCopy = null;
            if (condition != null && condition!="")
            {
                dtbCopy = Table.Copy();
                dtbCopy.DefaultView.RowFilter = "(" + condition + ")" + " or SubjectRoomID is null";
                //Table.DefaultView.RowFilter = condition;
            }
            else
                dtbCopy = Table;
            Control.DgGridView.InitRepositoryLookUpEdit(repository, dtbCopy, "", SIM_Subject_Room.C_RoomID, SIM_Room.C_RoomName, SIM_Room.C_RoomID, "Mã phòng", SIM_Room.C_RoomName, "Tên phòng");
        }

        #endregion


    }
}
