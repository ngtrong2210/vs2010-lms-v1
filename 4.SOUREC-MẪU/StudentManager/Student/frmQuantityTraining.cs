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
using DevExpress.XtraGrid.Views.BandedGrid;
using SystemService;

namespace StudentManager.Student
{
    public partial class frmQuantityTraining : FormBase, IForm
    {
        #region Consts

        public const string PERMISSION_ADD = "SIM_SummaryLearningMark_Add";
        public const string PERMISSION_DELETE = "SIM_SummaryLearningMark_Delete";
        public const string PERMISSION_EDIT = "SIM_SummaryLearningMark_Edit";
        public const string PERMISSION_VIEW = "SIM_SummaryLearningMark_View";
        #endregion

        #region Variable

        private string strClassID = "";
        DataTable dtbData;
        DataTable dtbClassSubject;
        DataTable dtbSubjectMark;
        bool bolIsFirstSearch = true;
        int intYearID;
        int? intSemester = null;

        private string strReport_Header = "";
        private string strReport_Place = "";

        private bool bolHaveNormalSubject = false; // có môn bình thường trong cả kì hay năm không, có thì chỉ tính môn bình thường, không thì chỉ tính môn văn hoá

        // đếm sinh viên theo thứ tự Xs, G, K, TB k, TB, yeu kem
        private int[] arrStatisticCount = { 0, 0, 0, 0, 0, 0 };

        #endregion

        #region IForm Members

        private static frmQuantityTraining _instance = null;

        public static frmQuantityTraining Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmQuantityTraining();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmQuantityTraining()
        {
            InitializeComponent();
        }

        #region Support Functions

        private void CheckPermission()
        {
            // Kiểm tra quyền                        
            gvData.OptionsBehavior.Editable = UserSession.HasPermission(PERMISSION_EDIT);
            //mnuItemSave.Enabled = btnSave.Enabled = UserSession.HasPermission(PERMISSION_EDIT);
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
            }
        }

        private bool IsValidData()
        {
            if (uYearSemester.YearIDEditValue == null)
            {
                MessageManager.Warning("Bạn phải chọn năm học!");
                uYearSemester.Focus();
                return false;
            }
      
            return true;
        }

        private void GetSetting()
        {
            if (SYS_SettingService.HaveNewData || bolIsFirstSearch)
            {
                strReport_Header = SYS_SettingService.GetStringValue("Report_Header");
                strReport_Place = SYS_SettingService.GetStringValue("Report_Place");
            }
        }

        public void LoadData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadData));
            else
            {
                SIM_SubjectMark obj = new SIM_SubjectMark();
                dtbData = obj.QualityTraining_Search("@CourseID", uClass.CourseIDEditValue,
                                                      "@ScienceID",uClass.ScienceIDEditValue,
                                                      "@SpecialBranchID",uClass.SpecialBranchIDEditValue,
                                                      "@TrainingLevelID",uClass.TrainingLevelIDEditValue,
                                                      "@BranchID",uClass.BranchEditValue,
                                                      "@ClassID",uClass.ClassIDEditValue,
                                                      "@YearID", uYearSemester.YearIDEditValue);

                if (dtbData != null)
                {
                    gcData.DataSource = dtbData;

                    // set order
                    gvData.SetOrder("Order");
                    ModifyGrid();

                    gvData.BestFitColumns();
                    btnPrint.Enabled = mnuItemPrint.Enabled = mnuItemExportToExcel.Enabled = dtbData.Rows.Count > 0;
                    btnSave.Enabled = mnuItemSave.Enabled = dtbData.Rows.Count > 0 && UserSession.HasPermission(PERMISSION_EDIT); // tong ket thi lan 1 thoi thi khong luu

                    intYearID = uYearSemester.YearIDEditValueInt32.Value;
                    intSemester = uYearSemester.SemesterEditValueInt32;

                    GetSetting();
                    bolIsFirstSearch = true;
                }
                else
                {
                    //MessageManager.Error(obj.ErrorException);
                    MessageManager.Error("Việc lấy thông tin điểm bị lỗi!");
                }
            }
        }

        /// <summary>
        /// Cập nhật tổng kết điểm học tập. Vừa thêm, vừa cập nhật nếu cả có
        /// </summary>
        /// <returns></returns>
        private bool SaveData()
        {
            return true;
            SIM_SummaryLearningMark item = new SIM_SummaryLearningMark();
            item.BeginTransaction();
            item.YearID = intYearID;
            item.UpdatedUser = UserSession.Username; // them hay update deu dung truong nay

            for (int i = 0; i < dtbData.Rows.Count; i++)
            {
                DataRow drw = gvData.GetDataRow(i);
                if (drw["SummaryLearningMark"].ToString() != "") // có điểm tổng kết mới lưu
                {
                    item.StudentID = Convert.ToInt32(drw["StudentID"]);
                    item.Summary = Convert.ToDouble(drw["SummaryLearningMark"]);
                    item.LearningLevel = drw["LearningLevel"].ToString();

                    if (!item.AddOrUpdate(intSemester))
                    {
                        MessageManager.Error("Việc cập nhật tổng kết điểm học tập bị lỗi!");
                        return false;
                    }

                }
            }
            item.CommitTransaction();
            return true;
        }

        private void ModifyGrid()
        {

            switch (uClass.RegulationID)
            {
                case 14: // cao đẳng, tc nghề
                    ModifyGrid14();
                    break;
                case 40: // trung cấp chuyên nghiệp
                    ModifyGrid40();
                    break;
                case 46: // trung cấp vừa học vừa làm
                    ModifyGrid46();
                    break;
                case 43:
                    ModifyGrid43();
                    break;
            }

        }

        #region Ẩn cột trên lưới theo từng qui chế

        private void ModifyGrid14()
        {
        }

        private void ModifyGrid40()
        {

        }

        private void ModifyGrid46()
        {

        }

        private void ModifyGrid43()
        {

        }

        #endregion

        #endregion


        #region Form Actions

        private void frmMakeStudentCode_Load(object sender, EventArgs e)
        {

            CheckPermission();
            SetToolTip();
            new Thread(LoadReferenceData).Start();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (IsValidData())
                new Thread(LoadData).Start();
        }

        private void uYearSemester_EditValueChanged(object sender, EventArgs arg)
        {
            if (uYearSemester.YearIDEditValue != null && uClass.ClassIDEditValue != null)
                new Thread(LoadData).Start();
        }

        private void uClass_EditValueChanged(object sender, EventArgs arg)
        {
            if (uYearSemester.YearIDEditValue != null && uClass.ClassIDEditValue != null)
                new Thread(LoadData).Start();
        }

        #endregion

        private void gvData_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.CellValue != null)
            {

                string strResult = e.CellValue.ToString();

                if (strResult == "Thôi học")
                    e.Appearance.BackColor = Color.Red;
                else if (strResult == "Ở lại lớp")
                    e.Appearance.BackColor = Color.Yellow;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
                btnSave.Enabled = mnuItemSave.Enabled = false;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string sReport = "";
            if (uYearSemester.SemesterEditValue.ToString() == "1")
            {
                sReport = "Report/StudentManager/Learning/Leaning_ChatLuongDaoTao_HocKy_QC14.repx";
            }
            else if (uYearSemester.SemesterEditValue.ToString() == "2")
            {
                sReport =  "Report/StudentManager/Learning/Leaning_ChatLuongDaoTao_HocKy2_QC14.repx";
            }
            else
                sReport =  "Report/StudentManager/Learning/Leaning_ChatLuongDaoTao_Nam_QC14.repx";

            // print danh sach sinh vien duoc hoc bong            
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData, sReport, false);
            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingLevel", uClass.TrainingLevelName);
            frm.SetParameter("pScience", uClass.ScienceName);
            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pClass", uClass.ClassIDEditValue);
            frm.SetParameter("pCountAll", dtbData.Rows.Count);
            frm.SetParameter("pYearID", uYearSemester.YearEditValueText);
            frm.SetParameter("pSemester", uYearSemester.SemesterEditValue);
            frm.Show();
        }


        private void mnuItemExportToExcel_Click(object sender, EventArgs e)
        {
            gvData.QuickExportToExcel();
        }

    }
}