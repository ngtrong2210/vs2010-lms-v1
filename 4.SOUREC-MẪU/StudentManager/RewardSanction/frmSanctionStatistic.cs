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

namespace StudentManager.RewardSanction
{
    public partial class frmSanctionStatistic : FormBase, IForm
    {
        #region Consts

        public const string PERMISSION_ADD = "SIM_SanctionStatistic_Add";
        public const string PERMISSION_DELETE = "SIM_SanctionStatistic_Delete";
        public const string PERMISSION_EDIT = "SIM_SanctionStatistic_Edit";
        public const string PERMISSION_VIEW = "SIM_SanctionStatistic_View";
        #endregion

        private string strDecisionNo = "";

        #region Variables       
        
        private DataTable dtbData;

        #endregion

        #region IForm Members

        private static frmSanctionStatistic _instance = null;

        public static frmSanctionStatistic Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmSanctionStatistic();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        #region Support Functions

        public frmSanctionStatistic()
        {
            InitializeComponent();
        }

        public void LoadReferenceData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadReferenceData));
            else
            {
                uClass.ClassFilter = "ClassType = 0";// chỉ lọc ra lớp bình thường
                uClass.InitData();
                uYearSemester.InitData();
                GEN_SanctionFormService.InitLookUpEdit(lookupSanctionForm);

            }
        }

        public void LoadData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadData));
            else
            {
                    bool? bolIsActived = null;
                    if(cbxIsActived.SelectedIndex==1)
                        bolIsActived =true;
                    else if(cbxIsActived.SelectedIndex==2)
                        bolIsActived = false;

                    SIM_Sanction obj = new SIM_Sanction();
                    dtbData = obj.Search(
                                    "@ScienceID", uClass.ScienceIDEditValue,
                                    "@CourseID", uClass.CourseIDEditValue,
                                    "@TrainingLevelID", uClass.TrainingLevelIDEditValue,
                                    "@TrainingType", uClass.TrainingTypeEditValue,
                                    "@BranchID", uClass.BranchEditValue,
                                    "@SpecialBranchID", uClass.SpecialBranchIDEditValue,
                                    "@ClassID", uClass.ClassIDEditValue,
                                    "@YearID", uYearSemester.YearIDEditValueInt32,
                                    "@Semester", uYearSemester.SemesterEditValueInt32,
                                    "@DecisionNo", txtDecisionNo.TextTrim,
                                    "@SigningdateStart", dateStart.EditValueDateTime,
                                    "@SigningdateEnd", DateEnd.EditValueDateTime,
                                    "@IsActived", bolIsActived,
                                    "@SanctionFormID",lookupSanctionForm.EditValue);
                    if (dtbData != null)
                    {
                        gcData.DataSource = dtbData;
                        SYS_GridColumnService.InitGridColumn(gvData, "SIM_Sanction");

                        // set order
                        gvData.SetOrder("Order");

                        //Nhớ lại giá trị khóa để save
                        strDecisionNo = txtDecisionNo.TextTrim;

                        btnEdit.Enabled = mnuItemEdit.Enabled = btnPrint.Enabled = dtbData.Rows.Count > 0;
                        mnuItemEditMulti.Enabled = mnuItemPrintMulti.Enabled = dtbData.Rows.Count > 0 && txtDecisionNo.TextTrim != "";


                    }
                    else
                        ErrorManager.Error("Việc tải thông tin bị lỗi!");
                 
            }
        }       

        private void CheckPermission()
        {
            // Kiểm tra quyền
            btnAdd.Enabled = mnuItemAdd.Enabled = mnuItemAddMulti.Enabled = UserSession.HasPermission(PERMISSION_ADD);
            btnEdit.Text = mnuItemEdit.Text = UserSession.HasPermission(PERMISSION_EDIT) ? "Sửa" : "Xem";
            mnuItemEditMulti.Text = UserSession.HasPermission(PERMISSION_EDIT) ? "Sửa hết" : "Xem hết";
        }      
        
        #endregion

        #region Form Actions

        private void frmSanctionStatistic_Load(object sender, EventArgs e)
        {
       
            CheckPermission();
            SetToolTip();
            new Thread(LoadReferenceData).Start();        
        }       

        private void btnSearch_Click(object sender, EventArgs e)
        {
            new Thread(LoadData).Start();
        }
     
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
                frmSanction frmEdit = frmSanction.Instance;
                frmEdit.LoadData(Convert.ToInt64(drw[SIM_Sanction.C_SanctionID]), Convert.ToInt64(drw[SIM_Sanction.C_StudentID]));
                frmEdit.ShowDialog();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            frmSanction frmEdit = frmSanction.Instance;
            frmEdit.ShowDialog();
            if (frmEdit.IsOk)
                LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataRow drw = gvData.GetFocusedDataRow();// Lấy dữ liệu dòng được chọn.
            if (drw != null)
            {
                if (MessageManager.Confirm("Bạn có chắc muốn xóa dòng dữ liệu này?") == System.Windows.Forms.DialogResult.Yes)
                {
                    SIM_Sanction objSaction = new SIM_Sanction();
                    SIM_Student objStudent = new SIM_Student();

                    objSaction.BeginTransaction(); // lay mot doi tuong lam chinh de transaction
                    objStudent.IDB = objSaction.IDB; // doi tuong transaction stutent giong voi saction

                    objSaction.SanctionID = Convert.ToInt64(drw[SIM_Sanction.C_SanctionID]);
                    objStudent.StudentID = Convert.ToInt64(drw["StudentID"]);

                    if (!objSaction.Delete())
                    {
                        ErrorManager.Error("Xóa thông tin kỷ luật thất bại");
                        return;
                    }

                    // update sinh vien ve dang hoc neu trang thai cua 
                    if (Convert.ToBoolean(drw["IsSuspended"].ToString()) == true)
                    {
                        objStudent.UpdatedUser = UserSession.Username;
                        objStudent.Status = 1;
                        if (!objStudent.UpdateStatus())
                        {
                            ErrorManager.Error("Cập nhật thông tin Hồ sơ SV thất bại");
                            return;
                        }
                    }
                    objSaction.CommitTransaction();

                    gvData.DeleteRow(gvData.FocusedRowHandle);
                }
            }
        }

        private void mnuItemAddMulti_Click(object sender, EventArgs e)
        {
            frmSanctionMulti frmEdit = frmSanctionMulti.Instance;
            
            frmEdit.ShowDialog();
            if (frmEdit.IsOk)
                LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuItemExportToExcel_Click(object sender, EventArgs e)
        {
            gvData.QuickExportToExcel();
        }
       
        #endregion

        private void gvData_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            btnDelete.Enabled = mnuItemDelete.Enabled = gvData.SelectedRowsCount > 0 && UserSession.HasPermission(PERMISSION_DELETE);
        }

        private void mnuItemEditMulti_Click(object sender, EventArgs e)
        {
            frmSanctionMulti frmEdit = frmSanctionMulti.Instance;
            frmEdit.Data = dtbData.Copy();
            frmEdit.ShowDialog();
            if (frmEdit.IsOk)
                LoadData();
        }

        private void mnuItemPrintMulti_Click(object sender, EventArgs e)
        {
            DataTable dtbData2 = dtbData.Copy();
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData2, "Report/StudentManager/Student/Student_BienBanHopKyLuat.repx", false);

            frm.Show();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string strReportPath = "Report/StudentManager/Student/Student_KyLuat.repx";
            DataTable dtbData2 = dtbData.Copy();
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData2, strReportPath, false);
            if (uClass.SpecialBranchName.ToString() != "")
                frm.SetParameter("pSpecialBranchName", uClass.SpecialBranchName.ToString());
            else
                frm.SetParameter("pSpecialBranchName", "");
            if (uClass.CourseName.ToString() != "")
                frm.SetParameter("pCourseName", uClass.CourseName.ToString());
            else
                frm.SetParameter("pCourseName", "");
            if (lookupSanctionForm.EditValue != null)
                frm.SetParameter("pSanctionFormName", lookupSanctionForm.Text.ToUpper());
            else
                frm.SetParameter("pSanctionFormName", "");
            frm.Show();
        }


    }
}