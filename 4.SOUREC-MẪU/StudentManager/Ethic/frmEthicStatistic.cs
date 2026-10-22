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

namespace StudentManager.Ethic
{
    public partial class frmEthicStatistic : FormBase, IForm
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

        private static frmEthicStatistic _instance = null;

        public static frmEthicStatistic Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmEthicStatistic();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmEthicStatistic()
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
                uYearSemester.InitData();
            }
        }

        public void LoadData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadData));
            else
            {
                SIM_SummaryEthicMark obj = new SIM_SummaryEthicMark();
                SIM_MonthEthicMark objMonth = new SIM_MonthEthicMark();
                DataTable dtbData = new DataTable();
                
               
                    dtbData = obj.SearchEthicStatistic("@CourseID", uScienceCourseTypeLevel.CourseIDEditValue,
                                           "@TrainingLevelID", uScienceCourseTypeLevel.TrainingLevelIDEditValue,
                                           "@TrainingType", uScienceCourseTypeLevel.TrainingTypeEditValue,
                                           "@ScienceID", uScienceCourseTypeLevel.ScienceIDEditValue,
                                         
                                           "@YearID", uYearSemester.YearIDEditValueInt32,
                                           "@Semester", uYearSemester.SemesterEditValueInt32);
           

                if (dtbData != null)
                {
                    gcData.DataSource = dtbData;
                    SYS_GridColumnService.InitGridColumn(gvData, "SIM_EthicStatistic");

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

        private void frmEthicStatistic_Load(object sender, EventArgs e)
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
            string sReport = "";
            if (uYearSemester.SemesterEditValueInt32 > 0)
            {
                sReport = "Report/StudentManager/Ethic/Student_ThongKeRenLuyen.repx";
            }
            else
            {
                sReport = "Report/StudentManager/Ethic/Student_ThongKeRenLuyenNam.repx";
            }
            Print(sReport);
        }

        private void Print(string reportFile)
        {
            // print Sinh vien
            string strReport = reportFile;
            DataTable dtbData = (gvData.DataSource as DataView).Table;
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData, strReport, false);

            // Set xep loai tot nghiep
            int iTB = 0; int iTBKha = 0; int iKha = 0; int iTot = 0; int iXuatSac = 0; int iSV = 0; int iYeu = 0; int iKem = 0;
            for (int j = 0; j < dtbData.Rows.Count; j++)
            {
                iSV += Convert.ToInt32(dtbData.Rows[j]["StudentQuantity"]);
                iXuatSac += Convert.ToInt32(dtbData.Rows[j]["A"]);
                iTot += Convert.ToInt32(dtbData.Rows[j]["B"]);
                iKha += Convert.ToInt32(dtbData.Rows[j]["C"]);
                iTBKha += Convert.ToInt32(dtbData.Rows[j]["D"]);
                iTB += Convert.ToInt32(dtbData.Rows[j]["E"]);
                iYeu += Convert.ToInt32(dtbData.Rows[j]["F"]);
                iKem += Convert.ToInt32(dtbData.Rows[j]["G"]);

            }
            // truyen tham so theo ý riêng
            frm.SetParameter("pCourse", uScienceCourseTypeLevel.CourseIDEditValue);
            frm.SetParameter("pTrainingType", uScienceCourseTypeLevel.TrainingTypeEditValue);
            frm.SetParameter("pScience", uScienceCourseTypeLevel.ScienceIDEditValue);
            frm.SetParameter("pYearID", uYearSemester.YearEditValueText);
            frm.SetParameter("pSemester", uYearSemester.SemesterEditValue);
            //Truyen tham so tinh trung binh, ti le phan tram
            frm.SetParameter("pXuatSac", iXuatSac);
            frm.SetParameter("pTLXuatSac", iXuatSac * 100 / iSV);
            frm.SetParameter("pTot", iTot);
            frm.SetParameter("pTLTot", iTot * 100 / iSV);
            frm.SetParameter("pKha", iKha);
            frm.SetParameter("pTLKha", iKha * 100 / iSV);
            frm.SetParameter("pTBKha", iTBKha);
            frm.SetParameter("pTLTBKha", iTBKha * 100 / iSV);
            frm.SetParameter("pTB", iTB);
            frm.SetParameter("pTLTB", iTB * 100 / iSV);
            frm.SetParameter("pYeu", iYeu);
            frm.SetParameter("pTLYeu", iYeu * 100 / iSV);
            frm.SetParameter("pKem", iKem);
            frm.SetParameter("pTLKem", iKem * 100 / iSV);
            frm.SetParameter("pSV", iSV);

            frm.Show();
        }
        
        private void mnuPrint2_Click(object sender, EventArgs e)
        {
        }

      
        /// <summary>

    }
}