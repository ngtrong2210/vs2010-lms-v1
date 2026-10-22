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

namespace StudentManager.Graduation
{
    public partial class frmGraduationStatistics : FormBase, IForm
    {
        #region Consts



        #endregion

        private string strClassID = "";
        private int intYear = 0;
        private string strListIDDeleted = "";
        private DateTime dtmMonth1;
        #region Variables
         
        bool bolIsEditing = false; // dang edit hay khong
       // SIM_YearEthicStatistic itemStudentEditing = new SIM_YearEthicStatistic(); // record đang edit

        #endregion

        #region IForm Members

        private static frmGraduationStatistics _instance = null;

        public static frmGraduationStatistics Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmGraduationStatistics();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmGraduationStatistics()
        {
            InitializeComponent();
        }
        public void LoadReferenceData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadReferenceData));
            else
            {
             
                uScienceCourseTypeLevel.InitData();
                SIM_ExamDateService.InitLookUpEdit(lookupExamDate);
            }
        }

        public void LoadData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadData));
            else
            {
                SIM_GraduationResult obj = new SIM_GraduationResult();
                DataTable dtbData = new DataTable();

                dtbData = obj.Search_Graduation_Statistics("@CourseID", uScienceCourseTypeLevel.CourseIDEditValue,
                                           "@TrainingLevelID", uScienceCourseTypeLevel.TrainingLevelIDEditValue,
                                           "@TrainingType", uScienceCourseTypeLevel.TrainingTypeEditValue,
                                           "@ScienceID", uScienceCourseTypeLevel.ScienceIDEditValue,

                                           "@ExamDateID", lookupExamDate.EditValue);

                if (dtbData != null)
                {
                    gcData.DataSource = dtbData;
                    SYS_GridColumnService.InitGridColumn(gvData, "SIM_GraduationStatistics");

                    // set order
                    gvData.SetOrder("Order");
                    ModifyGrid();

                    mnuItemExportToExcel.Enabled = mnuItemPrint.Enabled = dtbData.Rows.Count > 0;
                }
                else
                {
                    //ErrorManager.Error(obj.ErrorException);
                    ErrorManager.Error("Việc lấy thông tin bị lỗi!");
                }
            }
        }

        #region Support Functions

        private void CheckPermission()
        {
            // Kiểm tra quyền
           
        }

        private void ModifyGrid()
        {
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gvData.Columns)
            {
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                col.DisplayFormat.FormatString = "#,###";
            }
        }
      

        
        #endregion

        #region Form Actions

        private void frmGraduationStatistics_Load(object sender, EventArgs e)
        {
       
            CheckPermission();
            SetToolTip();
            new Thread(LoadReferenceData).Start();        
        }

       

     
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                new Thread(LoadData).Start();
            }
        }

        private bool IsValidData()
        {
            //if (uYearSemester.YearIDEditValue == null)
            //{
            //    MessageManager.Warning("Bạn phải chọn niên học!");
            //    uYearSemester.Focus();
            //    return false;
            //}

            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuItemExportToExcel_Click(object sender, EventArgs e)
        {
            gvData.QuickExportToExcel();
        }

        private void mnuPrint1_Click(object sender, EventArgs e)
        {
            // print Sinh vien
            DataTable dtbData = (gvData.DataSource as DataView).Table;
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData, "Report/StudentManager/Graduation/Graduation_ThongKeTotNghiep.repx", false);

            // truyen tham so theo ý riêng
            frm.SetParameter("pCourse", uScienceCourseTypeLevel.CourseIDEditValue);
            frm.SetParameter("pTrainingType", uScienceCourseTypeLevel.TrainingTypeEditValue);
            frm.SetParameter("pTrainingLevel", uScienceCourseTypeLevel.TrainingLevelIDEditValue);
            frm.SetParameter("pExamDate", lookupExamDate.EditValueText);
            frm.Show();
        }

        private void mnuPrint2_Click(object sender, EventArgs e)
        {
            // print Sinh vien
            DataTable dtbData = (gvData.DataSource as DataView).Table;
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData, "Report/StudentManager/Ethic/Student_ThongKeRenLuyenThang.repx", false);

            // truyen tham so theo ý riêng
            // truyen tham so theo ý riêng
            frm.SetParameter("pCourse", uScienceCourseTypeLevel.CourseIDEditValue);
            frm.SetParameter("pTrainingType", uScienceCourseTypeLevel.TrainingTypeEditValue);
            frm.SetParameter("pTrainingLevel", uScienceCourseTypeLevel.TrainingLevelIDEditValue);
            frm.SetParameter("pScience", uScienceCourseTypeLevel.ScienceIDEditValue);
          
            frm.Show();
        }

      
        /// <summary>

    }
}