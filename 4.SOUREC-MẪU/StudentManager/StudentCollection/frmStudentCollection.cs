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
using DataAccess;

namespace StudentManager.StudentCollection
{
    public partial class frmStudentCollection : FormBase, IForm
    {
        #region Consts

        public const string PERMISSION_ADD = "SIM_StudentCollection_Add";
        public const string PERMISSION_DELETE = "SIM_StudentCollection_Delete";
        public const string PERMISSION_EDIT = "SIM_StudentCollection_Edit";
        public const string PERMISSION_VIEW = "SIM_StudentCollection_View";

        #endregion

        
        #region Variables
         
        bool bolIsEditing = false; // dang edit hay khong
        private string strClassID = "";
        private int intYear = 0;
        private int intSemester = 0;
        private string strListIDDeleted = "";
        private bool bolIsRefresh = false;

       // SIM_StudentCollection itemStudentEditing = new SIM_StudentCollection(); // record đang edit

        #endregion

        #region IForm Members

        private static frmStudentCollection _instance = null;

        public static frmStudentCollection Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmStudentCollection();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmStudentCollection()
        {
            InitializeComponent();
        }
        
        #region Support Functions

        private void CheckPermission()
        {
            // Kiểm tra quyền            
            mnuItemAdd.Enabled = btnAdd.Enabled = UserSession.HasPermission(PERMISSION_ADD);
            mnuItemEdit.Text = btnEdit.Text = UserSession.HasPermission(PERMISSION_EDIT) ? "Sửa" : "Xem";                       
        }        

        public void LoadReferenceData()
        {
            uPeriod.InitData();
            uSpecialBranch.InitData();
        }

        public void RefreshReferenceData()
        {
            uPeriod.RefrehData();
            uSpecialBranch.RefrehData();
        }

        public void LoadData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadData));
            else
            {
                int iNV = 0;
                if (rdioNV1.Checked == true)
                    iNV = 1;
                if (rdioNV2.Checked == true)
                    iNV = 2;
                if (rdioNV3.Checked == true)
                    iNV = 3;
                SIM_StudentCollection obj = new SIM_StudentCollection();
                DataTable dtbData = null;
                if (cbxResult.SelectedIndex == 0) // lấy cà danh sách
                {
                    dtbData=obj.Search(
                                "@StudentCollectionPeriodID", uPeriod.StudentCollectionPeriodIDEditValue,
                                "@CourseID", uPeriod.CourseIDEditValue,
                                "@TrainingType", uPeriod.TrainingTypeEditValue,
                                "@TrainingLevelID", uPeriod.TrainingLevelIDEditValue,
                                "@BranchID", uSpecialBranch.BranchEditValue,
                                "@SpecialBranchID", uSpecialBranch.SpecialBranchEditValue,
                                "@FromDate", txtFromDate.EditValue,
                                "@ToDate", txtToDate.EditValue,
                                "@StudentCollectionCode", txtStudentCollectionCode.TextTrim,
                                "@FullName", txtFullName.TextTrim, "@Aspirations", iNV);
                }
                else // lấy danh sách trung tuyển
                {
                    dtbData=obj.Search(
                                "@StudentCollectionPeriodID", uPeriod.StudentCollectionPeriodIDEditValue,
                                "@CourseID", uPeriod.CourseIDEditValue,
                                "@TrainingType", uPeriod.TrainingTypeEditValue,
                                "@TrainingLevelID", uPeriod.TrainingLevelIDEditValue,
                                "@BranchID", uSpecialBranch.BranchEditValue,
                                "@SpecialBranchID", uSpecialBranch.SpecialBranchEditValue,
                                "@FromDate", txtFromDate.EditValue,
                                "@ToDate", txtToDate.EditValue,
                                "@StudentCollectionCode", txtStudentCollectionCode.TextTrim,
                                "@FullName", txtFullName.TextTrim, "@Aspirations", iNV, "@Result", cbxResult.SelectedIndex);
                
                }

                if (dtbData != null)
                {
                    gcData.DataSource = dtbData;
                    SystemService.SYS_GridColumnService.InitGridColumn(gvData, "SIM_StudentCollection",bolIsRefresh);

                    mnuItemEdit.Enabled = btnEdit.Enabled = gvData.GetFocusedDataRow() != null;
                    btnPrint.Enabled = mnuItemExportToExcel.Enabled = dtbData.Rows.Count > 0;
                    bolIsRefresh = false;
                }
                else
                {
                    ErrorManager.Error("Việc load thông tin bị lỗi!");
                }
            }
        }

        private void ShowEditForm(long? studentCollectionID)
        {
            frmStudentCollectionDetail frmEdit = frmStudentCollectionDetail.Instance;
            frmEdit.StudentCollectionPeriodID = uPeriod.StudentCollectionPeriodIDEditValue;
            frmEdit.LoadData(studentCollectionID);
            frmEdit.ShowDialog();

            if (frmEdit.IsOk && frmEdit.StudentCollectionIDNew != null)
            {
                LoadData();
                gvData.SearchAndSelectRow("StudentCollectionID", frmEdit.StudentCollectionIDNew);
            }
        }

        /// <summary>
        /// Xóa từng dòng được chọn, bị lỗi chỗ nào thì ngưng quay về ban đầu
        /// </summary>
        /// <returns></returns>
        private bool DeleteData()
        {
             SIM_StudentCollection obj = new SIM_StudentCollection();
             obj.BeginTransaction();
             obj.DeletedUser = UserSession.Username;

            int[] arrRowIndex = gvData.GetSelectedRows();
            for (int i = arrRowIndex.Length - 1; i >= 0; i--)
            {
                DataRow drw = gvData.GetDataRow(arrRowIndex[i]);
               
                    obj.StudentCollectionID = Convert.ToInt64(drw["StudentCollectionID"]);
                    if (obj.Delete())
                    {
                        gvData.DeleteRow(arrRowIndex[i]);
                    }
                    else
                    {
                        ErrorManager.Error("Việc xoá thông tin bị lỗi!");
                        break; // ngưng vòng for
                    }               
            }
            obj.CommitTransaction();
            return true;
        }

                
        #endregion

        #region Form Actions

        private void frmStudentCollection_Load(object sender, EventArgs e)
        {       
            CheckPermission();
            SetToolTip();
            LoadReferenceData();
        }
                    
        private void btnSearch_Click(object sender, EventArgs e)
        {
            new Thread(LoadData).Start();
        }
                       
        private void gvData_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            btnEdit.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataRow drw = gvData.GetFocusedDataRow();
            if (drw != null)
            {
                ShowEditForm(Convert.ToInt64(drw["StudentCollectionID"]));
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ShowEditForm(null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageManager.Confirm("Bạn thực sự muốn xóa những dữ liệu này?") == DialogResult.Yes)
            {
                DeleteData();
                mnuItemEdit.Enabled = btnEdit.Enabled = gvData.GetFocusedDataRow() != null;                
            }           
        }
        
        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string strMau = "CaoDang"; // mặc định là cao đẳng thôi
            switch (uPeriod.CollectionType)
            {
                case Global.StudentCollectionType.SoCap:
                    strMau = "SoCap";
                    break;
                case Global.StudentCollectionType.TrungCap25:
                case Global.StudentCollectionType.TrungCap35:
                    strMau = "TrungCap";
                    break;
                case Global.StudentCollectionType.CaoDang:
                    strMau = "CaoDang";
                    break;
                case Global.StudentCollectionType.LienThong:
                    strMau = "LienThong";
                    break;
            }

            // print Sinh vien
            DataTable dtbData = (gvData.DataSource as DataView).Table;
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData, "Report/StudentCollection/TS_DS_HoSoTuyenSinh_" + strMau + ".repx", false);

            frm.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuItemExportToExcel_Click(object sender, EventArgs e)
        {
            gvData.QuickExportToExcel();
        }

        private void mnuItemRefresh_Click(object sender, EventArgs e)
        {
            bolIsRefresh = true;
            uPeriod.RefrehData();
            uSpecialBranch.RefrehData();
            btnSearch_Click(null, null);
        }

        private void gvData_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            mnuItemDelete.Enabled = btnDelete.Enabled = gvData.SelectedRowsCount > 0 && UserSession.HasPermission(PERMISSION_DELETE);  
        }

        private void frmStudentCollection_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F1:
                    this.ShowToolTip();
                    break;

                case Keys.F3:
                    btnSearch_Click(sender, null);
                    break;
                case Keys.F4:                    
                    break;
                case Keys.F5:
                    mnuItemRefresh_Click(sender, null);
                    break;
                case Keys.F6:
                    
                    break;
                case Keys.F7:
                    //btnPrint_Click(sender, null);
                    break;
                case Keys.F8:
                    if (btnAdd.Enabled)
                        btnAdd_Click(sender, null);
                    break;
                case Keys.F12:
                    uPeriod.Reset();
                    uSpecialBranch.Reset();
                    break;
            }
        }

        private void uPeriod_EditValueChanged(object sender, EventArgs arg)
        {
            if (uPeriod.LearningLevel > 0)
                uSpecialBranch.SpecialBranchFilter = "LearningLevel = " + uPeriod.LearningLevel.ToString();
            else
                uSpecialBranch.SpecialBranchFilter = "";
        }

        private void mnuPrint2_Click(object sender, EventArgs e)
        {
            // print Sinh vien
            DataTable dtbStudentCollection = null;
            DataTable dtbData1 = null;

            string sReport = "Report/StudentCollection/TS_DS_KiemTraHoSo.repx";
            
            if (uPeriod.TrainingLevelIDEditValue == "1")
                sReport = "Report/StudentCollection/TS_DSCD_KiemTraHoSo.repx";
            else if (uPeriod.TrainingLevelIDEditValue == "3")
                sReport = "Report/StudentCollection/TS_DSTC3_KiemTraHoSo.repx";            
                
            DataTable dtbData = (gvData.DataSource as DataView).Table;
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData, sReport, false);
            //Tinh tong ho so nop trong dot
            SIM_StudentCollection obj = new SIM_StudentCollection();
            ISIM_SpecialBranchDAO obj1 = new SIM_SpecialBranchDAO();

            dtbData1 = obj1.Search();
            dtbData1.Columns.Add("NV1", typeof(double));
            dtbData1.Columns.Add("NV2", typeof(double));
            dtbData1.Columns.Add("NV3", typeof(double));
            dtbStudentCollection = (gvData.DataSource as DataView).Table;

            if (dtbStudentCollection != null)
            {
                foreach (DataRow drw in dtbData1.Rows)
                {
                    int iSpec1; int iSpec2; int iSpec3;
                    iSpec1 = 0; iSpec2 = 0; iSpec3 = 0;
                    foreach (DataRow drw2 in dtbStudentCollection.Rows)
                    {
                        if (drw2["SpecialBranchID"].ToString() == drw["SpecialBranchID"].ToString())
                            iSpec1 += 1;
                        if (drw2["SpecialBranchID2"].ToString() == drw["SpecialBranchID"].ToString())
                            iSpec2 += 1;
                        if (drw2["SpecialBranchID3"].ToString() == drw["SpecialBranchID"].ToString())
                            iSpec3 += 1;

                    }
                    drw["NV1"] = iSpec1;
                    drw["NV2"] = iSpec2;
                    drw["NV3"] = iSpec3;
                }
                
                // if(uPeriod.CollectionType == Global.StudentCollectionType.CaoDang) nếu có dùng thì dùng cái này để phân biệt
                //if (uPeriod.TrainingLevelIDEditValue == "2")
                //    dtbData1.DefaultView.RowFilter = "Isnull(LearningLevel,'')=2";
                //else if (uPeriod.TrainingLevelIDEditValue == "3" || uPeriod.TrainingLevelIDEditValue == "1")
                //    dtbData1.DefaultView.RowFilter = "Isnull(LearningLevel,'')=3";
                //else
                //    dtbData1.DefaultView.RowFilter = "Isnull(LearningLevel,'')=4";
                //dtbData1 = dtbData1.DefaultView.ToTable();

                //Danh sách môn theo tham số tùy đặt tên mà gán lại
                int i = 1;
                foreach (DataRow drw in dtbData1.Rows)
                {
                    frm.SetParameter("pSpecialBranch" + i.ToString(), drw["SpecialBranchName"].ToString());
                    frm.SetParameter("pSpecialBranchShortName" + i.ToString(), drw["SpecialBranchShortName"].ToString());
                    frm.SetParameter("pNV1" + i.ToString(), drw["NV1"].ToString());
                    frm.SetParameter("pNV2" + i.ToString(), drw["NV2"].ToString());
                    frm.SetParameter("pNV3" + i.ToString(), drw["NV3"].ToString());
                    i++;
                }
            }
            frm.Show();
        }

        private void mnuPrint3_Click(object sender, EventArgs e)
        {
            // print Sinh vien
            DataTable dtbStudentCollection = null;
            DataTable dtbData1 = null;

            string sReport = "Report/StudentCollection/TS_DS_KiemTraHoSo1.repx";
            if (uPeriod.TrainingLevelIDEditValue == "1")
                sReport = "Report/StudentCollection/TS_DSCD_KiemTraHoSo1.repx";
            else if (uPeriod.TrainingLevelIDEditValue == "3")
                sReport = "Report/StudentCollection/TS_DSTC3_KiemTraHoSo1.repx";  
                
            DataTable dtbData = (gvData.DataSource as DataView).Table;
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData, sReport, false);
            //Tinh tong ho so nop trong dot
            SIM_StudentCollection obj = new SIM_StudentCollection();
            ISIM_SpecialBranchDAO obj1 = new SIM_SpecialBranchDAO();
            dtbData1 = obj1.Search();
            dtbData1.Columns.Add("NV1", typeof(double));
            dtbData1.Columns.Add("NV2", typeof(double));
            dtbData1.Columns.Add("NV3", typeof(double));
            dtbStudentCollection = (gvData.DataSource as DataView).Table;

            if (dtbStudentCollection != null)
            {
                foreach (DataRow drw in dtbData1.Rows)
                {
                    int iSpec1; int iSpec2; int iSpec3;
                    iSpec1 = 0; iSpec2 = 0; iSpec3 = 0;
                    foreach (DataRow drw2 in dtbStudentCollection.Rows)
                    {
                        if (drw2["SpecialBranchID"].ToString() == drw["SpecialBranchID"].ToString())
                            iSpec1 += 1;
                        if (drw2["SpecialBranchID2"].ToString() == drw["SpecialBranchID"].ToString())
                            iSpec2 += 1;
                        if (drw2["SpecialBranchID3"].ToString() == drw["SpecialBranchID"].ToString())
                            iSpec3 += 1;

                    }
                    drw["NV1"] = iSpec1;
                    drw["NV2"] = iSpec2;
                    drw["NV3"] = iSpec3;
                }
                //if (uPeriod.TrainingLevelIDEditValue.ToString() == "2" || uPeriod.TrainingLevelIDEditValue.ToString() == "3")
                //    dtbData1.DefaultView.RowFilter = "Isnull(LearningLevel,'')=2";
                //else if (uPeriod.TrainingLevelIDEditValue.ToString() == "3" || uPeriod.TrainingLevelIDEditValue.ToString() == "1")
                //    dtbData1.DefaultView.RowFilter = "Isnull(LearningLevel,'')=3";
                //else
                //    dtbData1.DefaultView.RowFilter = "Isnull(LearningLevel,'')=4";
                //dtbData1 = dtbData1.DefaultView.ToTable();

                //Danh sách môn theo tham số tùy đặt tên mà gán lại
                int i = 1;
                foreach (DataRow drw in dtbData1.Rows)
                {
                    frm.SetParameter("pSpecialBranch" + i.ToString(), drw["SpecialBranchName"].ToString());
                    frm.SetParameter("pSpecialBranchShortName" + i.ToString(), drw["SpecialBranchShortName"].ToString());
                    frm.SetParameter("pNV1" + i.ToString(), drw["NV1"].ToString());
                    frm.SetParameter("pNV2" + i.ToString(), drw["NV2"].ToString());
                    frm.SetParameter("pNV3" + i.ToString(), drw["NV3"].ToString());
                    i++;
                }
            }
            frm.Show();
        }

    }
}