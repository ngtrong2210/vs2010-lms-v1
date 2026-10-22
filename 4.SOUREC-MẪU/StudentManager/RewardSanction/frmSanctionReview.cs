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
    public partial class frmSanctionReview : FormBase, IForm
    {
        #region Consts

        public const string PERMISSION_EDIT = "SIM_SanctionReview_Edit";
        public const string PERMISSION_VIEW = "SIM_SanctionReview_View";

        #endregion

        #region Variables

        private int intYearID = 0;
        private int intSemester = 0;
        private DataTable dtbData = null;
        
        #endregion

        #region IForm Members

        private static frmSanctionReview _instance = null;

        public static frmSanctionReview Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmSanctionReview();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion


        #region Support Functions

        public frmSanctionReview()
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

            }
        }

        public void LoadData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadData));
            else
            {
                SIM_SanctionReview obj = new SIM_SanctionReview();
                dtbData = obj.Search(
                                "@CourseID", uClass.CourseIDEditValue,
                                "@BranchID", uClass.BranchEditValue,
                                "@TrainingLevelID", uClass.TrainingLevelIDEditValue,
                                "@TrainingType", uClass.TrainingTypeEditValue,
                                "@ScienceID", uClass.ScienceIDEditValue,
                                "@ClassID", uClass.ClassIDEditValue,
                                "@YearID", uYearSemester.YearIDEditValueInt32,
                                "@Semester", uYearSemester.SemesterEditValueInt32,
                                "@FromDate", dtmFromDate.EditValueDateTime,
                                "@ToDate", dtmToDate.EditValueDateTime,
                                "@NoPermissionMin",cbxNoPermissionMin.Text,
                                "@CouncilNote",cbxCouncilNote.Text);

                if (dtbData != null)
                {
                    dtbData.Columns.Add("IsEdit", typeof(int));
                    gcData.DataSource = dtbData;
                    SYS_GridColumnService.InitGridColumn(gvData, "SIM_SanctionReview");

                    // set order
                    gvData.SetOrder("Order");

                    //Nhớ lại giá trị khóa để save
                    intYearID = uYearSemester.YearIDEditValueInt32.Value;
                    intSemester = uYearSemester.SemesterEditValueInt32.Value;
                    mnuItemSave.Enabled = btnSave.Enabled = false; // load lại thì không cần save 
                    btnPrint.Enabled = dtbData.Rows.Count > 0;
                }
                else
                {
                    btnPrint.Enabled = btnSave.Enabled = false;
                    ErrorManager.Error("Việc tải thông tin bị lỗi!");
                }
            }
        }

        
        private void CheckPermission()
        {
            // Kiểm tra quyền
            gvData.OptionsBehavior.Editable = UserSession.HasPermission(PERMISSION_EDIT);
        }

        private bool IsValidData()
        {
            if (uYearSemester.YearIDEditValueInt32 < 1)
            {
                MessageManager.Warning("Bạn phải chọn năm học!");
                uYearSemester.Focus();
                return false;
            }

            if (uYearSemester.SemesterEditValueInt32 < 1)
            {
                MessageManager.Warning("Bạn phải chọn học kỳ!");
                uYearSemester.Focus();
                return false;
            }

            return true;
        }
        /// <summary>
        /// Save dữ liệu ở tab edit
        /// </summary>
        private bool SaveData()
        {
            SIM_SanctionReview obj = new SIM_SanctionReview();
            obj.BeginTransaction();

            foreach (DataRow drw in dtbData.Rows)
            {
                if (drw["IsEdit"].ToString() == "1")
                {
                    SIM_SanctionReview item = new SIM_SanctionReview();
                    item.IDB = obj.IDB;
                    if (item.Parse(drw))
                    {
                        item.YearID = intYearID; // gán lại năm thật
                        item.Semester = intSemester; // học kì thật
                        item.StudentID = Convert.ToInt64(drw["StudentID1"]); // fai là studentID của sinh viên, vì có thể là thêm mới                            
                        if (drw["SanctionReviewID"].ToString() == "")
                        {
                            item.CreatedUser = UserSession.Username;
                            if (!item.Add())
                            {
                                ErrorManager.Error("Cập nhật điểm rèn luyện sinh viên bị lỗi!");
                                return false;
                            }
                        }
                        else
                        {
                            item.UpdatedUser = UserSession.Username;
                            if (!item.Update())
                            {
                                ErrorManager.Error("Cập nhật môn học lớp bị lỗi!");
                                return false;
                            }
                        }
                    }
                    else
                    {
                        ErrorManager.Error("Việc tạo thông tin bị lỗi!");
                    }
                }
            }
            obj.CommitTransaction();
            return true;
        }
                 
        #endregion

        #region Form Actions

        private void frmSanctionReview_Load(object sender, EventArgs e)
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
                if (btnSave.Enabled)
                {
                    DialogResult dlrConfirm = MessageManager.Confirm("Bạn có muốn lưu lại thông tin thay đổi trước khi nạp lại dữ liệu?");
                    if (dlrConfirm == DialogResult.Cancel)
                        return;
                    else if (dlrConfirm == DialogResult.Yes)
                        if (!SaveData())
                            return;// lưu không thành công thì return                    
                }
                new Thread(LoadData).Start();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageManager.Confirm("Bạn có thực sự muốn lưu những thay đổi dữ liệu này?") == DialogResult.Yes)
            {
                if (SaveData())
                {                    
                    btnSave.Enabled = mnuItemSave.Enabled = false;
                    btnSearch_Click(sender, e);
                }
            }
        }       

        private void gvData_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataRow  drw = gvData.GetFocusedDataRow();
            if (drw != null)
            {
                drw["IsEdit"] = 1;
                btnSave.Enabled = mnuItemSave.Enabled = true;
            }
        }

        private void gvData_EndSorting(object sender, EventArgs e)
        {
            // set order
            gvData.SetOrder("Order");
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
            uYearSemester.RefrehData();
            btnSearch_Click(null, null);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // print Sinh vien
            string dDatePrint = "";
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData, "Report/StudentManager/Student/Student_XetKyLuat.repx", false);
            dDatePrint = DateTime.Now.ToString("dd/MM/yyyy");
            frm.SetParameter("pDatePrint", dDatePrint);
            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);
            frm.SetParameter("pTrainingLevel", uClass.TrainingLevelName);
            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pScience", uClass.ScienceName);
            frm.SetParameter("pFromDate", Convert.ToDateTime(dtmFromDate.EditValueDateTime).ToString("dd/MM/yyyy"));
            frm.SetParameter("pToDate", Convert.ToDateTime(dtmToDate.EditValueDateTime).ToString("dd/MM/yyyy"));
            frm.Show();
        }

        private void mnuItemPrint2_Click(object sender, EventArgs e)
        {
            // print Sinh vien
            string dDatePrint = "";
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData, "Report/StudentManager/Student/Student_XetKyLuat-BienBanHop.repx", false);
            dDatePrint = DateTime.Now.ToString("dd/MM/yyyy");
            frm.SetParameter("pDatePrint", dDatePrint);
            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);
            frm.SetParameter("pTrainingLevel", uClass.TrainingLevelName);
            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pScience", uClass.ScienceName);
            frm.SetParameter("pFromDate", Convert.ToDateTime(dtmFromDate.EditValueDateTime).ToString("dd/MM/yyyy"));
            frm.SetParameter("pToDate", Convert.ToDateTime(dtmToDate.EditValueDateTime).ToString("dd/MM/yyyy"));
            frm.Show();
        }

        private void mnuPrint8_Click(object sender, EventArgs e)
        {
            // print Sinh vien
            string dDatePrint = "";
            DataTable dtbData2 = dtbData.Copy();
            dtbData2.DefaultView.RowFilter = "IsSelected = 1";
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData2, "Report/StudentManager/Student/Student_ThuMoi.repx", false);
            dDatePrint = DateTime.Now.ToString("dd/MM/yyyy");
            frm.SetParameter("pDatePrint", dDatePrint);
            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);
            frm.SetParameter("pTrainingLevel", uClass.TrainingLevelName);
            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pScience", uClass.ScienceName);
            frm.SetParameter("pFromDate", Convert.ToDateTime(dtmFromDate.EditValueDateTime).ToString("dd/MM/yyyy"));
            frm.SetParameter("pToDate", Convert.ToDateTime(dtmToDate.EditValueDateTime).ToString("dd/MM/yyyy"));
            frm.SetParameter("pPrint", "ngày " + Convert.ToString(DateTime.Today.Day) + " tháng " + Convert.ToString(DateTime.Today.Month) + " năm " + Convert.ToString(DateTime.Today.Year));
            frm.Show();
        }

        private void mnuPrint7_Click(object sender, EventArgs e)
        {
            // print Sinh vien
            string dDatePrint = "";
            DataTable dtbData2 = dtbData.Copy();
            dtbData2.DefaultView.RowFilter = "IsSelected = 1";
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData2, "Report/StudentManager/Student/Student_ThongBao.repx", false);
            dDatePrint = DateTime.Now.ToString("dd/MM/yyyy");
            frm.SetParameter("pDatePrint", dDatePrint);
            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);
            frm.SetParameter("pTrainingLevel", uClass.TrainingLevelName);
            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pScience", uClass.ScienceName);
            frm.SetParameter("pFromDate", Convert.ToDateTime(dtmFromDate.EditValueDateTime).ToString("dd/MM/yyyy"));
            frm.SetParameter("pToDate", Convert.ToDateTime(dtmToDate.EditValueDateTime).ToString("dd/MM/yyyy"));
            frm.SetParameter("pPrint", "ngày " + Convert.ToString(DateTime.Today.Day) + " tháng " + Convert.ToString(DateTime.Today.Month) + " năm " + Convert.ToString(DateTime.Today.Year));
            frm.Show();
        }

        private void mnuItemPrint4_Click(object sender, EventArgs e)
        {
            // print Sinh vien
            string dDatePrint = "";
            DataTable dtbData2 = dtbData.Copy();
            dtbData2.DefaultView.RowFilter = "IsSelected = 1";
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData2, "Report/StudentManager/Student/Student_KhienTrach.repx", false);
            dDatePrint = DateTime.Now.ToString("dd/MM/yyyy");
            frm.SetParameter("pDatePrint", dDatePrint);
            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);
            frm.SetParameter("pTrainingLevel", uClass.TrainingLevelName);
            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pScience", uClass.ScienceName);
            frm.SetParameter("pFromDate", Convert.ToDateTime(dtmFromDate.EditValueDateTime).ToString("dd/MM/yyyy"));
            frm.SetParameter("pToDate", Convert.ToDateTime(dtmToDate.EditValueDateTime).ToString("dd/MM/yyyy"));
            frm.SetParameter("pPrint", "ngày " + Convert.ToString(DateTime.Today.Day) + " tháng " + Convert.ToString(DateTime.Today.Month) + " năm " + Convert.ToString(DateTime.Today.Year));
            frm.Show();
        }

        private void mnuItemPrint5_Click(object sender, EventArgs e)
        {
            // print Sinh vien
            string dDatePrint = "";
            DataTable dtbData2 = dtbData.Copy();
            dtbData2.DefaultView.RowFilter = "IsSelected = 1";
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData2, "Report/StudentManager/Student/Student_CanhCao.repx", false);
            dDatePrint = DateTime.Now.ToString("dd/MM/yyyy");
            frm.SetParameter("pDatePrint", dDatePrint);
            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);
            frm.SetParameter("pTrainingLevel", uClass.TrainingLevelName);
            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pScience", uClass.ScienceName);
            frm.SetParameter("pFromDate", Convert.ToDateTime(dtmFromDate.EditValueDateTime).ToString("dd/MM/yyyy"));
            frm.SetParameter("pToDate", Convert.ToDateTime(dtmToDate.EditValueDateTime).ToString("dd/MM/yyyy"));
            frm.SetParameter("pPrint", "ngày " + Convert.ToString(DateTime.Today.Day) + " tháng " + Convert.ToString(DateTime.Today.Month) + " năm " + Convert.ToString(DateTime.Today.Year));
            frm.Show();
        }

        private void mnuItemPrint6_Click(object sender, EventArgs e)
        {
            // print Sinh vien
            string dDatePrint = "";
            DataTable dtbData2 = dtbData.Copy();
            dtbData2.DefaultView.RowFilter = "IsSelected = 1";
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData2, "Report/StudentManager/Student/Student_ThoiHoc.repx", false);
            dDatePrint = DateTime.Now.ToString("dd/MM/yyyy");
            frm.SetParameter("pDatePrint", dDatePrint);
            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);
            frm.SetParameter("pTrainingLevel", uClass.TrainingLevelName);
            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pScience", uClass.ScienceName);
            frm.SetParameter("pFromDate", Convert.ToDateTime(dtmFromDate.EditValueDateTime).ToString("dd/MM/yyyy"));
            frm.SetParameter("pToDate", Convert.ToDateTime(dtmToDate.EditValueDateTime).ToString("dd/MM/yyyy"));
            frm.SetParameter("pPrint", "ngày " + Convert.ToString(DateTime.Today.Day) + " tháng " + Convert.ToString(DateTime.Today.Month) + " năm " + Convert.ToString(DateTime.Today.Year));
            frm.Show();
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

        private void mnuPrint9_Click(object sender, EventArgs e)
        {
            // print Sinh vien
            string dDatePrint = "";
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData, "Report/StudentManager/Student/Student_XetKyLuat_TKBuoiVang.repx", false);
            dDatePrint = DateTime.Now.ToString("dd/MM/yyyy");
            if (uClass.ClassName != "")
                frm.SetParameter("pClass", "LỚP " + uClass.ClassName);
            frm.SetParameter("pDatePrint", dDatePrint);
            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);
            frm.SetParameter("pTrainingLevel", uClass.TrainingLevelName);
            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pScience", uClass.ScienceName);
            frm.SetParameter("pFromDate", Convert.ToDateTime(dtmFromDate.EditValueDateTime).ToString("dd/MM/yyyy"));
            frm.SetParameter("pToDate", Convert.ToDateTime(dtmToDate.EditValueDateTime).ToString("dd/MM/yyyy"));
            frm.Show();
        }

        private void mnuItemPrintDS_DeNghiRa_HDKL_Click(object sender, EventArgs e)
        {
            // print Sinh vien
            string dDatePrint = "";
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData, "Report/StudentManager/Student/Student_XetKyLuat_DS_DeNghiRa_HDKL.repx", false);
            dDatePrint = DateTime.Now.ToString("dd/MM/yyyy");
            frm.SetParameter("pClass", uClass.ClassName);
            frm.SetParameter("pDatePrint", dDatePrint);
            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);
            frm.SetParameter("pTrainingLevel", uClass.TrainingLevelName);
            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pScience", uClass.ScienceName);
            frm.SetParameter("pSemester", uYearSemester.SemesterEditValue.ToString());
            frm.SetParameter("pYearID",  uYearSemester.YearEditValueText);
            frm.SetParameter("pFromDate", Convert.ToDateTime(dtmFromDate.EditValueDateTime).ToString("dd/MM/yyyy"));
            frm.SetParameter("pToDate", Convert.ToDateTime(dtmToDate.EditValueDateTime).ToString("dd/MM/yyyy"));
            frm.Show();
        }

        private void mnuItemPrint_DSHS_YKHDKL_Click(object sender, EventArgs e)
        {
            // print Sinh vien
            string dDatePrint = "";
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData, "Report/StudentManager/Student/Student_XetKyLuat_DSHS_YKHDKL.repx", false);
            dDatePrint = DateTime.Now.ToString("dd/MM/yyyy");
            frm.SetParameter("pClass", uClass.ClassName);
            frm.SetParameter("pDatePrint", dDatePrint);
            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);
            frm.SetParameter("pTrainingLevel", uClass.TrainingLevelName);
            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pScience", uClass.ScienceName);
            frm.SetParameter("pSemester", uYearSemester.SemesterEditValue.ToString());
            frm.SetParameter("pYearID", uYearSemester.YearEditValueText);
            frm.SetParameter("pFromDate", Convert.ToDateTime(dtmFromDate.EditValueDateTime).ToString("dd/MM/yyyy"));
            frm.SetParameter("pToDate", Convert.ToDateTime(dtmToDate.EditValueDateTime).ToString("dd/MM/yyyy"));

            frm.SetParameter("pCouncilNote", cbxCouncilNote.Text);
            frm.Show();
        }

          

    }
}