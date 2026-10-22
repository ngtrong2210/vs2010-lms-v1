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
namespace StudentManager.Learning
{
    public partial class frmLearningSummary : FormBase, IForm
    {
        #region Consts
        public const string PERMISSION_VIEW = "SIM_SubjectMark_LearningSummary_View";
        public const string PERMISSION_EDIT_MONEY = "SIM_SubjectMark_LearningSummary_EditMoney";
        
        #endregion

        private DataTable dtbData = null;

        #region Variables
         
        bool bolIsEditing = false; // dang edit hay khong
        bool bolIsRefresh = false;
       // SIM_ReRegister itemStudentEditing = new SIM_ReRegister(); // record đang edit

        #endregion

        #region IForm Members

        private static frmLearningSummary _instance = null;

        public static frmLearningSummary Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmLearningSummary();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmLearningSummary()
        {
            InitializeComponent();
        }
       
        #region Support Functions

        private void CheckPermission()
        {
            // Kiểm tra quyền                    
        }

        public void LoadReferenceData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadReferenceData));
            else
            {
                uClass.ClassFilter = "ClassType = 0";// chỉ lọc ra lớp bình thường
                uClass.InitData();
                uYearSemester.InitData(); // của môn học lớp
            }
        }

        private bool IsValidData()
        {
            if (uClass.ScienceIDEditValue == null && uClass.CourseIDEditValue == null && uClass.TrainingLevelIDEditValue == null  && uClass.TrainingTypeEditValue == null
                && uClass.BranchEditValue == null && uClass.SpecialBranchIDEditValue == null && uClass.ClassIDEditValue == null
                     && txtFullName_Search.TextTrim == "" && txtStudentCode_Search.TextTrim == "")
            {
                MessageManager.Warning("Bạn phải chọn ít nhất một điều kiện tìm kiếm!");
                return false;
            }
            //if (uClass.ScienceIDEditValue == null)
            //{
            //    MessageManager.Warning("Bạn phải chọn khoa!");
            //    uClass.Focus();
            //    return false;
            //}

            //if (uClass.CourseIDEditValue == null)
            //{
            //    MessageManager.Warning("Bạn phải chọn khóa học!");
            //    uClass.Focus();
            //    return false;
            //}
            //if (uClass.TrainingLevelIDEditValue == null)
            //{
            //    MessageManager.Warning("Bạn phải chọn bậc đào tạo!");
            //    uClass.Focus();
            //    return false;
            //} 
            //if (uClass.BranchEditValue  == null)
            //{
            //    MessageManager.Warning("Bạn phải chọn ngành học!");
            //    uClass.Focus();
            //    return false;
            //}
            //if (uClass.SpecialBranchIDEditValue == null)
            //{
            //    MessageManager.Warning("Bạn phải chọn chuyên ngành!");
            //    uClass.Focus();
            //    return false;
            //} 

            //return uYearSemester.IsValidData(); // fai chọn niên kỳ đăng ký
            return true;
        }

        public void LoadData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadData));
            else
            {
                bool? bolIsRegulation43 = null;
                if (rdo0.Checked)
                    bolIsRegulation43 = false;
                else if (rdo1.Checked)
                    bolIsRegulation43 = true;

                SIM_SubjectMark obj = new SIM_SubjectMark();
                dtbData = obj.GetDataTable("SIM_SubjectMark_SearchLearningSummary",
                                                "@ScienceID", uClass.ScienceIDEditValue,
                                                "@CourseID", uClass.CourseIDEditValue,
                                                "@TrainingLevelID", uClass.TrainingLevelIDEditValue,
                                                "@TrainingType", uClass.TrainingTypeEditValue,
                                                "@BranchID", uClass.BranchEditValue,
                                                "@SpecialBranchID", uClass.SpecialBranchIDEditValue,
                                                "@ClassID", uClass.ClassIDEditValue,
                                                "@YearID", uYearSemester.YearIDEditValue,
                                                "@Semester", uYearSemester.SemesterEditValue,
                                                "@IsRegulation43", bolIsRegulation43,

                                                "@StudentCode", txtStudentCode_Search.TextTrim, // niên kì học môn đó
                                                "@Fullname", txtFullName_Search.TextTrim,
                                                "@FullNameEn", DCore.Filter.FilterVietkey(txtFullName_Search.Text));
                if (dtbData != null)
                {
                    gcData.DataSource = dtbData;
                    SystemService.SYS_GridColumnService.InitGridColumn(gvData, "SIM_LearningSummary",bolIsRefresh);
                    //gvData.BestFitColumns();
                    //ModifyGrid();

                    mnuItemExportToExcel.Enabled = dtbData.Rows.Count > 0;
                    btnUpdate.Enabled = false;
                    gvData.OptionsBehavior.Editable = mnuItemExportToExcel.Enabled && rdo1.Checked && UserSession.HasPermission(PERMISSION_EDIT_MONEY); // Có dữ liệu và có quyền edit học phí tín chỉ
                    bolIsRefresh = false;
                }
                else
                {
                    ErrorManager.Error("Tải dữ liệu bị lỗi!");
                    SYS_ErrorLogService.Write(Enums.ActionType.View, "frmLearningSummary->LoadData",obj.ErrorException, 0);
                }
            }
        }
     
        private void ModifyGrid()
        {
            //foreach (DevExpress.XtraGrid.Columns.GridColumn col in gvData.Columns)
            //{
            //    switch (col.FieldName)
            //    {
            //        case "Money":
            //            col.DisplayFormat.FormatString = "#,###";
            //            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //            break;
            //        case "IsPayment":
            //            break;
            //        default:
            //            col.OptionsColumn.AllowEdit = false;
            //            break;
            //    }

            //}
        }

        private bool UpdateMoney()
        {
            SIM_SubjectMark obj = new SIM_SubjectMark();
            obj.BeginTransaction();
            obj.UpdatedUser = UserSession.Username;
            foreach (DataRow drw in dtbData.Rows)
            {
                if (Convert.ToBoolean(drw["IsEdit"]))
                {
                    obj.SubjectMarkID = Convert.ToInt64(drw["SubjectMarkID"]);
                    obj.Money = Convert.ToDecimal(drw["Money"]);
                    obj.IsPayment = Convert.ToBoolean(drw["IsPayment"]);
                    if (!obj.UpdateMoney())
                    {
                        ErrorManager.Error("Cập nhật học phí bị lỗi!");
                        return false;
                    }
                    drw["IsEdit"] = false;

                }
            }
            obj.CommitTransaction();
            return true;
        }
        #endregion

        #region Form Actions

        private void frmLearningSummary_Load(object sender, EventArgs e)
        {
            CheckPermission();
            SetToolTip();
            new Thread(LoadReferenceData).Start();        
        }
      
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                new Thread(LoadData).Start();
            }
        }                     
        
        #endregion
        

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // print danh sach du dieu kien tot nghiep
            DataTable dtbData = (gvData.DataSource as DataView).Table;
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData, "Report/StudentManager/Learning/Leaning_HocLai_QC14.repx", false);

            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);

            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pClass", uClass.ClassIDEditValue);
            frm.SetParameter("pSemester", uYearSemester.SemesterEditValue);
            frm.SetParameter("pYearID", uYearSemester.YearEditValueText);

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
            uClass.RefrehData();            
            btnSearch_Click(null, null);
        }

        private void dockPanel1_Click(object sender, EventArgs e)
        {

        }

        private void frmLearningSummary_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // cập nhật học phí
            if (UpdateMoney())
                btnUpdate.Enabled = false;

        }

        private void gvData_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataRow drw = gvData.GetFocusedDataRow();
            if (drw != null)
            {
                drw["IsEdit"] = true;
                btnUpdate.Enabled = true;
            }
        }
    }
}