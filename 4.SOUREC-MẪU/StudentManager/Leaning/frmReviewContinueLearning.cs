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

namespace StudentManager.Learning
{
    public partial class frmReviewContinueLearning : FormBase, IForm
    {
        #region Consts
        
        public const string PERMISSION_EDIT = "SIM_ReviewContinueLearning_Edit";
        public const string PERMISSION_VIEW = "SIM_ReviewContinueLearning_View";

        #endregion

        #region Variable

        int? intRegulationIDCurrent = null;

        private string strClassID = "";
        DataTable dtbData;
        DataTable dtbClassSubject;
        DataTable dtbSubjectMark;
        bool bolIsRefresh = false;
        int intYearID;
        int? intSemester = null;

        private string strReport_Header = "";
        private string strReport_Place = "";

        private bool bolHaveNormalSubject = false; // có môn bình thường trong cả kì hay năm không, có thì chỉ tính môn bình thường, không thì chỉ tính môn văn hoá

        // đếm sinh viên theo thứ tự Xs, G, K, TB k, TB, yeu kem
        private int[] arrStatisticCount = { 0, 0, 0, 0, 0, 0 };

        #endregion

        #region IForm Members

        private static frmReviewContinueLearning _instance = null;

        public static frmReviewContinueLearning Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmReviewContinueLearning();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmReviewContinueLearning()
        {
            InitializeComponent();
        }

        #region Support Functions

        private void CheckPermission()
        {
            // Kiểm tra quyền                        
            //gvData.OptionsBehavior.Editable = UserSession.HasPermission(PERMISSION_EDIT);            
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
            if (!uClass.IsValidData())
                return false;
            return true;
        }

        private void GetSetting()
        {
            if (SYS_SettingService.HaveNewData || bolIsRefresh || dtbData == null) // mới hoặc có nạp lại
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
                string strQuery = "SIM_SubjectMark_ReviewContinueLearning99";

                intRegulationIDCurrent = uClass.RegulationID;

                SIM_SubjectMark obj = new SIM_SubjectMark();
                if (intRegulationIDCurrent == 43) // tín chỉ 43
                {
                    int intStartYear = new DataAccess.SIM_CourseDAO().Get(uClass.CourseIDEditValue).StartYear.Value;
                    int intYear = uYearSemester.YearIDEditValueInt32.Value - intStartYear + 1;
                    
                    dtbData = obj.GetDataTable("SIM_SubjectMark_ReviewContinueLearning43", "@ClassID", uClass.ClassIDEditValue,
                                                    "@YearID", uYearSemester.YearIDEditValue,
                                                    "@Semester", uYearSemester.SemesterEditValue,
                                                    "@Year", intYear);
                }

                else if (intRegulationIDCurrent == 40 || intRegulationIDCurrent == 46) // tc chuyen nghiep qui che moi thay cho 40 & 46 cũ
                    dtbData = obj.GetDataTable("SIM_SubjectMark_ReviewContinueLearning40", "@ClassID", uClass.ClassIDEditValue,
                                                   "@YearID", uYearSemester.YearIDEditValue);

                else if (intRegulationIDCurrent == 22) // tc chuyen nghiep 22
                {
                    dtbData = obj.GetDataTable("SIM_SubjectMark_ReviewContinueLearning22", "@ClassID", uClass.ClassIDEditValue,
                                                    "@YearID", uYearSemester.YearIDEditValue);
                    strQuery = "SIM_SubjectMark_ReviewContinueLearning22";
                }
                else if (intRegulationIDCurrent == 9 || intRegulationIDCurrent == 999) // tc, cđ chuyên nghiệp 2017 or sơ cấp 2017
                {
                    dtbData = obj.GetDataTable("SIM_SubjectMark_ReviewContinueLearning09", "@ClassID", uClass.ClassIDEditValue,
                                                    "@YearID", uYearSemester.YearIDEditValue);
                    strQuery = "SIM_SubjectMark_ReviewContinueLearning09";
                }

                else if (intRegulationIDCurrent == 99) // tc, cđ tín chỉ 2017
                {
                    strQuery = "SIM_SubjectMark_ReviewContinueLearning99";
                    dtbData = obj.GetDataTable("SIM_SubjectMark_ReviewContinueLearning99", "@ClassID", uClass.ClassIDEditValue,
                                                    "@YearID", uYearSemester.YearIDEditValue, "@Semester", uYearSemester.SemesterEditValue);
                }
                else // xử lý xét niên chế sau
                {
                    strQuery = "SIM_SubjectMark_ReviewContinueLearning04";
                    dtbData = obj.GetDataTable("SIM_SubjectMark_ReviewContinueLearning04", "@ClassID", uClass.ClassIDEditValue,
                                                   "@YearID", uYearSemester.YearIDEditValue);                    
                }

                if (dtbData != null)
                {
                    gcData.DataSource = dtbData;
                    SystemService.SYS_GridColumnService.InitGridColumn(gvData, strQuery, bolIsRefresh);
                    gvData.BestFitColumns();

                    //ModifyGrid();

                    gvData.BestFitColumns();
                    btnPrint.Enabled = mnuItemPrint.Enabled = mnuItemPrint_CanhCao.Enabled = mnuItemExportToExcel.Enabled = dtbData.Rows.Count > 0;
                    btnSave.Enabled = mnuItemSave.Enabled = dtbData.Rows.Count > 0 && UserSession.HasPermission(PERMISSION_EDIT); // tong ket thi lan 1 thoi thi khong luu

                    intYearID = uYearSemester.YearIDEditValueInt32.Value;
                    intSemester = uYearSemester.SemesterEditValueInt32;

                    //GetSetting();
                    bolIsRefresh = false;
                }
                else
                {
                    //ErrorManager.Error(obj.ErrorException);
                    ErrorManager.Error("Việc lấy thông tin điểm bị lỗi!");
                }
            }
        }

        /// <summary>
        /// Cập nhật tổng kết điểm học tập. Vừa thêm, vừa cập nhật nếu cả có
        /// </summary>
        /// <returns></returns>
        private bool SaveData()
        {
            SIM_ReviewContinueLearning item = new SIM_ReviewContinueLearning();
            item.BeginTransaction();
            item.YearID = intYearID;
            item.Semester = intSemester;
            item.UpdatedUser = UserSession.Username; // them hay update deu dung truong nay

            for (int i = 0; i < dtbData.Rows.Count; i++)
            {
                DataRow drw = gvData.GetDataRow(i);
                if (drw["SummaryAll"].ToString() != "") // có điểm tổng kết mới lưu
                {
                    item.StudentID = Convert.ToInt32(drw["StudentID"]);
                    item.Summary = Convert.ToDouble(drw["SummaryAll"]);
                    item.LearningLevel = drw["Result"].ToString();
                    // Học tiếp =0; 1 cảnh báo; 2 cảnh báo mức 2; 3 Điều chỉnh tiến độ; 4 buộc thôi học.
                    if (drw["Result"].ToString() != "")
                    {
                        if (drw["Result"].ToString() == "Học tiếp")
                            item.Result = 0;
                        else if (drw["Result"].ToString() == "Cảnh báo")
                            item.Result = 1;
                        else if (drw["Result"].ToString() == "Điều chỉnh tiến độ học")
                            item.Result = 3;
                        else if (drw["Result"].ToString() == "Thôi học")
                            item.Result = 4;
                    }
                    if (!item.AddOrUpdate())
                    {
                        ErrorManager.Error("Việc cập nhật tổng kết điểm học tập bị lỗi!");
                        return false;
                    }
                    // cập nhật lại để thống kê kết quả xét học tiếp.

                }
            }
            item.CommitTransaction();
            
            return true;
        }

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
                else if (strResult == "Cảnh cáo")
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
            // print danh sach sinh vien duoc hoc bong            
            string sReport = "Report/StudentManager/Learning/ReviewContinueLearning99.repx";
            if ( intRegulationIDCurrent == 22)
                sReport ="Report/StudentManager/Learning/ReviewContinueLearning22.repx";
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData, sReport, false);
            frm.SetParameter("pTitle", "DANH SÁCH HỌC SINH SINH VIÊN HỌC TIẾP, CẢNH CÁO, BUỘC THÔI HỌC");
            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingLevel", uClass.TrainingLevelName);
            frm.SetParameter("pScience", uClass.ScienceName);
            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pClass", uClass.ClassIDEditValue);
            frm.SetParameter("pCountAll", dtbData.Rows.Count);
            frm.SetParameter("pCountPassed", dtbData.Select("Result='Lên lớp'").Length);
            frm.SetParameter("pCountFailed", dtbData.Select("Result <> 'Lên lớp'").Length);


            frm.Show();
        }


        private void mnuItemExportToExcel_Click(object sender, EventArgs e)
        {
            gvData.QuickExportToExcel();
        }

        private void mnuQuaTrinhHocTap_Click(object sender, EventArgs e)
        {
            DataRow drw = gvData.GetFocusedDataRow();
            if (drw != null)
            {
                StudentManager.Student.frmStudentInfor frmView = StudentManager.Student.frmStudentInfor.Instance;
                frmView.LoadData(null, Convert.ToInt64(drw[SIM_Student.C_StudentID]));
                frmView.ShowDialog();
            }
        }

        private void mnuItemRefresh_Click(object sender, EventArgs e)
        {
            bolIsRefresh = true;
            btnSearch_Click(null, null);
        }

        private void mnuItemPrint_CanhCao_Click(object sender, EventArgs e)
        {
            // print danh sach sinh vien duoc hoc bong            
            DataTable dtbPrint = dtbData.Copy();
            dtbPrint.DefaultView.RowFilter = "Result = 'Cảnh cáo'";
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbPrint, "Report/StudentManager/Learning/ReviewContinueLearning99.repx", false);
            frm.SetParameter("pTitle", "DANH SÁCH HỌC SINH SINH VIÊN CẢNH CÁO");
            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingLevel", uClass.TrainingLevelName);
            frm.SetParameter("pScience", uClass.ScienceName);
            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pClass", uClass.ClassIDEditValue);
            frm.SetParameter("pCountAll", dtbPrint.DefaultView.Count);
            //frm.SetParameter("pCountPassed", dtbData.Select("Result='Lên lớp'").Length);
            //frm.SetParameter("pCountFailed", dtbData.Select("Result <> 'Lên lớp'").Length);


            frm.Show();
        }

        private void mnuItemPrint_HoiDong_Click(object sender, EventArgs e)
        {
            // print danh sach sinh vien duoc hoc bong            
            string sReport = "Report/StudentManager/Learning/ReviewContinueLearning_HD99.repx";
            if (intRegulationIDCurrent == 22)
                sReport = "Report/StudentManager/Learning/ReviewContinueLearning22.repx";
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData, sReport, false);
            frm.SetParameter("pTitle", "DANH SÁCH HỌC SINH SINH VIÊN HỌC TIẾP, CẢNH CÁO, BUỘC THÔI HỌC");
            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingLevel", uClass.TrainingLevelName);
            frm.SetParameter("pScience", uClass.ScienceName);
            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pClass", uClass.ClassIDEditValue);
            frm.SetParameter("pCountAll", dtbData.Rows.Count);
            frm.SetParameter("pCountPassed", dtbData.Select("Result='Lên lớp'").Length);
            frm.SetParameter("pCountFailed", dtbData.Select("Result <> 'Lên lớp'").Length);


            frm.Show();
        }

    }
}