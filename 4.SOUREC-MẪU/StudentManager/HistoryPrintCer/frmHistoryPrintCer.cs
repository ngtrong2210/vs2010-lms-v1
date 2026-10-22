using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using Libs;
using Global;
using DCore;
using SimsObject;
using SimsService;
using Service;
using GeneralObject;
using GeneralService;

namespace StudentManager.HistoryPrintCer
{
    public partial class frmHistoryPrintCer : FormBase, IForm
    {
        #region Consts

        public const string PERMISSION_ADD = "SIM_HistoryPrintCer_Add";
        public const string PERMISSION_DELETE = "SIM_HistoryPrintCer_Delete";
        public const string PERMISSION_EDIT = "SIM_HistoryPrintCer_Edit";
        public const string PERMISSION_VIEW = "SIM_HistoryPrintCer_View";
        #endregion

        #region Variables
         
        bool bolIsEditing = false; // dang edit hay khong
       // SIM_HistoryPrintCer itemStudentEditing = new SIM_HistoryPrintCer(); // record đang edit

        #endregion

        #region IForm Members

        private static frmHistoryPrintCer _instance = null;

        public static frmHistoryPrintCer Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmHistoryPrintCer();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public string StudentCode
        {            
            set { txtStudentCode.Text = value; }
        }

        public frmHistoryPrintCer()
        {
            InitializeComponent();
        }

        #region Support Functions

        private void CheckPermission()
        {
            // Kiểm tra quyền
            // Kiểm tra quyền
            mnuItemAdd.Enabled = btnAdd.Enabled = UserSession.HasPermission(PERMISSION_ADD);
            mnuItemEdit.Text = btnEdit.Text = UserSession.HasPermission(PERMISSION_EDIT) ? "Sửa" : "Xem";
        }

        public void LoadReferenceData()
        {
            uClass.ClassFilter = "ClassType = 0";// chỉ lọc ra lớp bình thường
            uClass.InitData();
        }

        public void LoadData()
        {
            
                    SIM_HistoryPrintCer obj = new SIM_HistoryPrintCer();
                    DataTable dtbData = obj.Search("@CourseID", uClass.CourseIDEditValue, 
                                            "@BranchID", uClass.BranchEditValue,
                                            "@TrainingLevelID", uClass.TrainingLevelIDEditValue, 
                                            "@TrainingType", uClass.TrainingTypeEditValue,
                                            "@ScienceID", uClass.ScienceIDEditValue,                                           
                                            "@ClassID", uClass.ClassIDEditValue,                                            
                                            "@StudentCode",txtStudentCode.TextTrim,
                                            "@FullName",txtFullName.TextTrim);
                    if (dtbData != null)
                    {

                        gcData.DataSource = dtbData;
                        SYS_GridColumnService.InitGridColumn(gvData, "SIM_HistoryPrintCer");

                        // set order
                        gvData.SetOrder("Order");

                        //Nhớ lại giá trị khóa để save
                        btnEdit.Enabled = mnuItemEdit.Enabled =mnuItemExportToExcel.Enabled=  dtbData.Rows.Count > 0;
                    }
                    else
                        ErrorManager.Error("Việc tải thông tin bị lỗi!");
        }
                      
        #endregion

        #region Form Actions

        private void frmHistoryPrintCer_Load(object sender, EventArgs e)
        {                   
            CheckPermission();
            SetToolTip();
            LoadReferenceData();
            if (txtStudentCode.TextTrim != "")
                LoadData();
        }
            
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {

            LoadData();
           
        }
       
        
        /// <summary>
        /// Save dữ liệu ở tab editgv
        /// </summary>     
        private void gvData_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            btnEdit.Enabled = true;
        }

        private void gvData_EndSorting(object sender, EventArgs e)
        {
            // set order
            gvData.SetOrder("Order");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataRow drw = gvData.GetFocusedDataRow();
            if (drw != null)
            {
                frmHistoryPrintCerDetail frmEdit = frmHistoryPrintCerDetail.Instance;
                frmEdit.LoadData(Convert.ToInt64(drw[SIM_HistoryPrintCer.C_HistoryPrintCerID]), null);
                frmEdit.ShowDialog();
                if (frmEdit.IsOk)
                    LoadData();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmHistoryPrintCerDetail frmEdit = frmHistoryPrintCerDetail.Instance;
            frmEdit.LoadData();
            frmEdit.ShowDialog();
            if (frmEdit.IsOk)
                LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageManager.Confirm("Bạn muốn xoá dữ liệu đang chọn?") == System.Windows.Forms.DialogResult.Yes)
            {
                SIM_HistoryPrintCer objHistoryPrintCer = new SIM_HistoryPrintCer();
                objHistoryPrintCer.BeginTransaction();
                foreach (int i in gvData.GetSelectedRows())
                {
                    DataRow drw = gvData.GetDataRow(i);
                    objHistoryPrintCer.HistoryPrintCerID = Convert.ToInt64(drw[SIM_HistoryPrintCer.C_HistoryPrintCerID]);
                    if (!objHistoryPrintCer.Delete())
                    {
                        ErrorManager.Error("Xóa thông tin lịch sử thất bại");
                        return;
                    }
                }
                objHistoryPrintCer.CommitTransaction();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // print Sinh vien
            DataTable dtbData = (gvData.DataSource as DataView).Table;
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData, "Report/StudentManager/Student/Student_DSHSSV_NhanGiay.repx", false);

            frm.Show();
        }

        private void mnuItemExportToExcel_Click(object sender, EventArgs e)
        {
            gvData.QuickExportToExcel();
        }

        private void gvData_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            btnDelete.Enabled = mnuItemDelete.Enabled = gvData.SelectedRowsCount > 0 && UserSession.HasPermission(PERMISSION_DELETE);
        }

        /// <summary>
        ///  Nếu itemOld = null thì là thêm mới với itemNew
        

    }
}