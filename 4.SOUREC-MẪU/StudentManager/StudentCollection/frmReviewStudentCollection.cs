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

namespace StudentManager.StudentCollection
{
    public partial class frmReviewStudentCollection : FormBase, IForm
    {
        #region Consts

        public const string PERMISSION_EDIT = "SIM_ReviewStudentCollection_Edit";
        public const string PERMISSION_VIEW = "SIM_ReviewStudentCollection_View";

        #endregion       

        #region Variables

        DataTable dtbData;
        int intResult = 0; // nguyện vọng đang chọn để xét

        #endregion

        #region IForm Members

        private static frmReviewStudentCollection _instance = null;

        public static frmReviewStudentCollection Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmReviewStudentCollection();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmReviewStudentCollection()
        {
            InitializeComponent();
        }
        
        #region Support Functions

        private void CheckPermission()
        {
            // Kiểm tra quyền
            gvData.OptionsBehavior.Editable = UserSession.HasPermission(PERMISSION_EDIT);
           
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

        private bool IsValidData()
        {
            if (uPeriod.StudentCollectionPeriodIDEditValue==null)
            {
                MessageManager.Warning("Bạn phải chọn đợt tuyển sinh!");
                uPeriod.Focus();
                return false;
            }
            if (uSpecialBranch.SpecialBranchEditValue == null)
            {
                MessageManager.Warning("Bạn phải chọn chuyên ngành!");
                uSpecialBranch.Focus();
                return false;
            }

            if (cbxResult.SelectedIndex < 1)
            {
                MessageManager.Warning("Bạn phải chọn nguyện vọng cần xét!");
                cbxResult.Focus();
                return false;
            }
            return true;
        }

        public void LoadData()
        {
            SIM_StudentCollection obj = new SIM_StudentCollection();
            dtbData = obj.SearchForReview(
                            "@StudentCollectionPeriodID", uPeriod.StudentCollectionPeriodIDEditValue,
                            "@CourseID", uPeriod.CourseIDEditValue,
                            "@TrainingType", uPeriod.TrainingTypeEditValue,
                            "@TrainingLevelID", uPeriod.TrainingLevelIDEditValue,                            
                            "@SpecialBranchID", uSpecialBranch.SpecialBranchEditValue,
                            "@FromDate", txtFromDate.EditValue,
                            "@ToDate", txtToDate.EditValue,
                            "@StudentCollectionCode", txtStudentCollectionCode.TextTrim,
                            "@FullName", txtFullName.TextTrim,
                            "@Result", cbxResult.SelectedIndex);
            if (dtbData != null)
            {
                gcData.DataSource = dtbData;
                SYS_GridColumnService.InitGridColumn(gvData, "SIM_ReviewStudentCollection");

                // set order
                gvData.SetOrder("Order");

                ModifyGrid();

                //Nhớ lại giá trị khóa để save                    
                btnReview.Enabled = btnPrint.Enabled = mnuItemExportToExcel.Enabled = dtbData.Rows.Count > 0;
                mnuItemEdit.Enabled = gvData.GetFocusedDataRow() != null;
                btnSave.Enabled = false;
                intResult = cbxResult.SelectedIndex;
            }
            else
                ErrorManager.Error("Việc load thông tin bị lỗi!");
        }

        private void ShowEditForm(long? studentCollectionID)
        {
            frmStudentCollectionDetail frmEdit = frmStudentCollectionDetail.Instance;
            frmEdit.StudentCollectionID = studentCollectionID;
            frmEdit.ShowDialog();

            if (frmEdit.IsOk && frmEdit.StudentCollectionIDNew != null)
            {
                LoadData();
                gvData.SearchAndSelectRow("StudentCollectionID", frmEdit.StudentCollectionIDNew);
            }
        }

        private bool ReviewStudentCollection()
        {
            
            // lấy dữ liệu ra và sort theo tổng điểm giảm dần
            DataTable dtb = dtbData.Copy();
            dtb.DefaultView.Sort = "TotalMark DESC";
            dtb.DefaultView.RowFilter = "TotalMark >= " + txtMinMark.EditValue.ToString();
            dtb = dtb.DefaultView.ToTable();

            // reset dtbdata bỏ check trúng tuyển
            foreach (DataRow drw in dtbData.Rows)
                drw["IsOk"] = false;

            // đánh dấu vào data dòng hồ sơ trúng tuyển
            int i = 0;
            while (i < txtMaxQuantity.EditValueInt32 && i < dtb.Rows.Count)
            {
                DataRow[] rows = dtbData.Select("StudentCollectionID=" + dtb.Rows[i]["StudentCollectionID"].ToString());
                rows[0]["IsOk"] = true;
                i++;
            }

            return true;
        }

        private bool SaveData()
        {
            SIM_StudentCollection item = new SIM_StudentCollection();
            item.CreatedUser = UserSession.Username;
            item.BeginTransaction();

            foreach (DataRow drw in dtbData.Rows)
            {
                item.StudentCollectionID = Convert.ToInt64(drw["StudentCollectionID"]);
                item.Result = Convert.ToInt32(drw["IsOk"]) * intResult;
                item.CerNo = drw["CerNo"].ToString();
                if (!item.UpdateResult())
                {
                    ErrorManager.Error("Việc cập nhật thông tin xét tuyển bị lỗi!");
                    return false;
                }
            }
            item.CommitTransaction();
            return true;
        }
                
        #endregion

        #region Form Actions

        private void frmReviewStudentCollection_Load(object sender, EventArgs e)
        {       
            CheckPermission();
            SetToolTip();
            LoadReferenceData();
        }
                    
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (IsValidData())
                //new Thread(LoadData).Start();
                LoadData();
        }                             

        private void gvData_EndSorting(object sender, EventArgs e)
        {
            // set order
            gvData.SetOrder("Order");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
                btnSave.Enabled = false;
        }

        private void btnReview_Click(object sender, EventArgs e)
        {
            if (txtMinMark.EditValue == null || txtMinMark.EditValueInt32 < 0)
            {
                MessageManager.Warning("Bạn phải nhập điểm xét tuyển!");
                txtMinMark.Focus();
                return;
            }
            if (txtMaxQuantity.EditValue == null || txtMaxQuantity.EditValueInt32 <= 0)
            {
                MessageManager.Warning("Bạn phải nhập chỉ tiêu!");
                txtMaxQuantity.Focus();
                return;
            }

            if (ReviewStudentCollection())
                btnSave.Enabled = true;
        }
 
        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string strMau = "CaoDang";
            //switch (uPeriod.CollectionType)
            //{
            //    case Global.StudentCollectionType.SoCap:
            //        strMau = "SoCap";
            //        break;
            //    case Global.StudentCollectionType.TrungCap25:
            //        strMau = "TrungCap";
            //        break;
            //    case Global.StudentCollectionType.TrungCap35:
            //        strMau = "TrungCap3";
            //        break;
            //    case Global.StudentCollectionType.CaoDang:
            //        strMau = "CaoDang";
            //        break;
            //    case Global.StudentCollectionType.LienThong:
            //        strMau = "LienThong";
            //        break;
            //}

            // print danh sach du dieu kien du thi
            DataTable dtbData2 = dtbData.Copy();            
            dtbData2 = dtbData2.DefaultView.ToTable();
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData2, "Report/StudentCollection/TS_XetDuyet_" + strMau + ".repx", false);
            //SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData2, "Report/StudentCollection/TS_XetDuyet.repx", false);
            frm.SetParameter("pTrainingLevel",uPeriod.CourseTypeLevelEditor.TrainingLevelIName.ToUpper());
            frm.SetParameter("pPeriod", uPeriod.StudentCollectionPeriodName.ToUpper());
            frm.Show();
        }

        private void mnuItemExportToExcel_Click(object sender, EventArgs e)
        {
            gvData.QuickExportToExcel();
        }

        private void mnuItemRefresh_Click(object sender, EventArgs e)
        {
            uPeriod.RefrehData();
            uSpecialBranch.RefrehData();
            btnSearch_Click(null, null);
        }

        private void frmReviewStudentCollection_KeyDown(object sender, KeyEventArgs e)
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
                    break;
                case Keys.F12:
                    uPeriod.Reset();
                    uSpecialBranch.Reset();
                    break;
            }
        }

        private void mnuItemEdit_Click(object sender, EventArgs e)
        {

            DataRow drw = gvData.GetFocusedDataRow();
            if (drw != null)
            {
                ShowEditForm(Convert.ToInt64(drw["StudentCollectionID"]));
            }
        }

        private void ModifyGrid()
        {
            //for (int i = 5; i <= 7; i++)
            //{
            //    gvData.Columns["Mark" + i.ToString()].Visible = false;
            //}

            //if (uPeriod.StudentCollectionPeriodIDEditValue != null)
            //{
            //    // chỉnh lại thông tin xét tuyển ứng với từng loại bậc xét tuyển
            //    switch (uPeriod.CollectionType)
            //    {

            //        case Global.StudentCollectionType.TrungCap35:
            //            string[] caption = { "", "Lớp 6", "Lớp 7", "Lớp 8", "Lớp 9" };
            //            for (int i = 1; i <= 4; i++)
            //            {
            //                gvData.Columns["Mark" + i.ToString()].Visible = true;
            //                gvData.Columns["Mark" + i.ToString()].Caption = caption[i];
            //            }

            //            gvData.Columns["SummaryMark"].Visible = true;

            //            //cbxExperience.Visible = false;
            //            //cbxGraduationLevel.Visible = false;
            //            //lblGraduationLevel.Visible = false;
            //            //lblExperience.Visible = false;
            //            break;

            //        case Global.StudentCollectionType.LienThong:
            //            for (int i = 1; i <= 7; i++)
            //            {
            //                gvData.Columns["Mark" + i.ToString()].Visible = false;
            //            }

            //            gvData.Columns["SummaryMark"].Visible = false;

            //            //cbxExperience.Visible = true;
            //            //cbxGraduationLevel.Visible = true;
            //            //lblGraduationLevel.Visible = true;
            //            //lblExperience.Visible = true;
            //            break;
            //        default:
            //            string[] caption2 = { "", "Lớp 10", "Lớp 11", "Lớp 12" };
            //            for (int i = 1; i <= 3; i++)
            //            {
            //                gvData.Columns["Mark" + i.ToString()].Visible = true;
            //                gvData.Columns["Mark" + i.ToString()].Caption = caption2[i];
            //            }

            //            gvData.Columns["Mark4"].Visible = false;

            //            gvData.Columns["SummaryMark"].Visible = true;

            //            break;
            //    }
            //}
        }

        private void gvData_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            mnuItemSave.Enabled = btnSave.Enabled = true;
        }

        private void uPeriod_EditValueChanged(object sender, EventArgs arg)
        {
            if (uPeriod.LearningLevel > 0)
                uSpecialBranch.SpecialBranchFilter = "LearningLevel = " + uPeriod.LearningLevel.ToString();
            else
                uSpecialBranch.SpecialBranchFilter = "";
        }
    }
}