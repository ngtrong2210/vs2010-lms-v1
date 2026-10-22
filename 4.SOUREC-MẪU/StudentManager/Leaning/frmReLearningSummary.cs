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
    public partial class frmReLearningSummary : FormBase, IForm
    {
        #region Consts
        
        public const string PERMISSION_EDIT = "SIM_ReRegister_Edit";
        public const string PERMISSION_VIEW = "SIM_ReRegister_View";
        
        #endregion

        private DataTable dtbData = null;

        #region Variables
         
        bool bolIsEditing = false; // dang edit hay khong
       // SIM_ReRegister itemStudentEditing = new SIM_ReRegister(); // record đang edit

        #endregion

        #region IForm Members

        private static frmReLearningSummary _instance = null;

        public static frmReLearningSummary Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmReLearningSummary();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmReLearningSummary()
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
                uYearSemester.InitData();
                uYearSemester1.InitData(); // của môn học lớp
            }
        }

        private bool IsValidData()
        {
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
                try
                {
                    SIM_SubjectMark obj = new SIM_SubjectMark();
                    dtbData = obj.GetDataTable("SIM_SubjectMark_SearchReLearning",
                                                    "@ScienceID", uClass.ScienceIDEditValue,
                                                    "@CourseID", uClass.CourseIDEditValue,
                                                    "@TrainingLevelID", uClass.TrainingLevelIDEditValue,
                                                    "@TrainingType", uClass.TrainingTypeEditValue,
                                                    "@BranchID",uClass.BranchEditValue,
                                                    "@SpecialBranchID",uClass.SpecialBranchIDEditValue,
                                                    "@ClassID",uClass.ClassIDEditValue,
                                                    "@YearID",uYearSemester.YearIDEditValue, 
                                                    "@Semester",uYearSemester.SemesterEditValue,

                                                    "@YearID1", uYearSemester1.YearIDEditValue, // niên kì học môn đó
                                                    "@Semester1", uYearSemester1.SemesterEditValue);

                    gcData.DataSource = dtbData;
                    SYS_GridColumnService.InitGridColumn(gvData, "SIM_ReLearningSummary");
                    // set order
                    gvData.SetOrder("Order");
                    gvData.BestFitColumns();
                    //ModifyGrid();

                    mnuItemExportToExcel.Enabled = dtbData.Rows.Count > 0;                                                            
                }
                catch (Exception objEx)
                {
                    ErrorManager.Error(objEx);
                    SYS_ErrorLogService.Write(Enums.ActionType.View, "frmReLearningSummary->LoadData", objEx, 0);
                }
            }
        }
     
        private void ModifyGrid()
        {
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gvData.Columns)
            {

                switch (col.FieldName)
                {
                    case "Schoolfees":
                        col.DisplayFormat.FormatString = "#,###";
                        col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        break;
                }

            }
        }
        #endregion

        #region Form Actions

        private void frmReLearningSummary_Load(object sender, EventArgs e)
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

        /// <summary>
        private void gvData_EndSorting(object sender, EventArgs e)
        {
            // set order
            gvData.SetOrder("Order");
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
            uClass.RefrehData();
            btnSearch_Click(null, null);
        }

        private void dockPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}