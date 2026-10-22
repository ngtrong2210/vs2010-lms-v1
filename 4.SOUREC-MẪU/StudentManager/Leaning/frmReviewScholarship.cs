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
    public partial class frmReviewScholarship : FormBase, IForm
    {
        #region Consts

        public const string PERMISSION_VIEW = "SIM_ReviewScholarship_View";

        #endregion

        #region Variables

        private string strClassID = "";
        private int intYear = 0;
        private int intSemester = 0;
        private string strListIDDeleted = "";
        private int intRegulationID = 0;
        private DataTable dtbData = null;
        
         
        bool bolIsEditing = false; // dang edit hay khong
        bool bolIsRefresh = false;
       // ACC_Receipt itemStudentEditing = new ACC_Receipt(); // record đang edit

        #endregion

        #region IForm Members

        private static frmReviewScholarship _instance = null;

        public static frmReviewScholarship Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmReviewScholarship();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion


        public frmReviewScholarship()
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
                SimsService.SIM_RegulationService.InitLookUpEdit(LookupRegulationID);
            }
            txtChiTieu.EditValue = 8;
        }

        public void LoadData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadData));
            else
            {
                SIM_SubjectMark obj = new SIM_SubjectMark();

                if (uClass.ClassIDEditValue == null)
                    intRegulationID = LookupRegulationID.EditValueInt32.Value;
                else
                    intRegulationID = uClass.RegulationID.Value;
                if (intRegulationID == 14)
                {
                    dtbData = obj.ReviewScholarship_QC14(
                                                  uYearSemester.YearIDEditValueInt32, uYearSemester.SemesterEditValueInt32, uClass.ClassIDEditValue, uClass.ScienceIDEditValue,
                                                  uClass.CourseIDEditValue, uClass.TrainingLevelIDEditValue.ToString(), uClass.BranchEditValue, uClass.SpecialBranchIDEditValue,
                                                  dtmReceiptDate.EditValueDate,
                                                  txtChiTieu.EditValue
                                                 );
                }
               
                else if (intRegulationID == 4)
                {
                    dtbData = obj.ReviewScholarship_QC04(
                                                  uYearSemester.YearIDEditValueInt32, uYearSemester.SemesterEditValueInt32, uClass.ClassIDEditValue, uClass.ScienceIDEditValue,
                                                  uClass.CourseIDEditValue, uClass.TrainingLevelIDEditValue.ToString(), uClass.BranchEditValue, uClass.SpecialBranchIDEditValue,
                                                  dtmReceiptDate.EditValueDate,
                                                  txtChiTieu.EditValue
                                                 );
                }

                else if (intRegulationID == 43)
                {
                    dtbData = obj.ReviewScholarship_QC43(
                                                 uYearSemester.YearIDEditValueInt32, uYearSemester.SemesterEditValueInt32, uClass.ClassIDEditValue, uClass.ScienceIDEditValue,
                                                 uClass.CourseIDEditValue, uClass.TrainingLevelIDEditValue.ToString(), uClass.BranchEditValue, uClass.SpecialBranchIDEditValue, uClass.RegulationID.Value
                                                );
                }
                else if (intRegulationID == 40)
                {
                    dtbData = obj.ReviewScholarship_QC40(
                                                 uYearSemester.YearIDEditValueInt32, uYearSemester.SemesterEditValueInt32, uClass.ClassIDEditValue, uClass.ScienceIDEditValue,
                                                 uClass.CourseIDEditValue, uClass.TrainingLevelIDEditValue.ToString(), uClass.BranchEditValue, uClass.SpecialBranchIDEditValue);
                }
                else if (intRegulationID == 9)
                {
                    dtbData = obj.ReviewScholarship_QC09(
                                                  uYearSemester.YearIDEditValueInt32, uYearSemester.SemesterEditValueInt32, uClass.ClassIDEditValue, uClass.ScienceIDEditValue,
                                                  uClass.CourseIDEditValue, uClass.TrainingLevelIDEditValue.ToString(), uClass.BranchEditValue, uClass.SpecialBranchIDEditValue,
                                                  dtmReceiptDate.EditValueDate,
                                                  txtChiTieu.EditValue
                                                 );
                }
                else
                {
                    dtbData = obj.ReviewScholarship_QC09(
                                                  uYearSemester.YearIDEditValueInt32, uYearSemester.SemesterEditValueInt32, uClass.ClassIDEditValue, uClass.ScienceIDEditValue,
                                                  uClass.CourseIDEditValue, uClass.TrainingLevelIDEditValue.ToString(), uClass.BranchEditValue, uClass.SpecialBranchIDEditValue,
                                                  dtmReceiptDate.EditValueDate,
                                                  txtChiTieu.EditValue
                                                 );
                }

                // Them mot datatable moi de chuyen dtbData vao do theo chi tieu
                //if (txtChiTieu.EditValue != null)
                //{
                //    while (dtbData.Rows.Count > txtChiTieu.EditValueInt32.Value)
                //        dtbData.Rows.RemoveAt(dtbData.Rows.Count - 1);
                //}

                if (dtbData != null)
                {
                    Decimal Tong = 0;

                    for (int i = 0; i < dtbData.Rows.Count; i++)
                    {
                        Tong += Convert.ToInt64(dtbData.Rows[i]["Money"]);
                        if (i == Convert.ToInt64(txtChiTieu.EditValueInt32))
                            break;
                        dtbData.Rows[i]["Progressive"] = Tong;

                    }
                    gcData.DataSource = dtbData;
                    btnSave.Enabled = mnuItemSave.Enabled = dtbData.Rows.Count > 0;

                    SystemService.SYS_GridColumnService.InitGridColumn(gvData, "SIM_ReviewScholarship", bolIsRefresh);
                    ModifyGrid();
                    bolIsRefresh = false;
                }
                else
                    ErrorManager.Error("Việc tải thông tin bị lỗi!");

            }
        }

        private bool SaveData()
        {
            SIM_Scholarship obj = new SIM_Scholarship();
            obj.BeginTransaction();

            obj.YearID = uYearSemester.YearIDEditValueInt32;
            obj.Semester = uYearSemester.SemesterEditValueInt32;
            obj.CreatedUser = obj.UpdatedUser = UserSession.Username;

            foreach (DataRow drw in dtbData.Rows)
            {
                obj.StudentID = Convert.ToInt64(drw["StudentID"]);
                obj.ScholarshipLevel = drw["RewardLevel"].ToString();
                obj.ScholarshipMonth = Convert.ToInt32( drw["Month"]);
                obj.ScholarshipMoney = Convert.ToDecimal(drw["Money"]);
                
                if (!obj.AddOrEdit())
                {
                    ErrorManager.Error("Việc cập nhật thông tin học bổng bị lỗi!");
                    return false;
                }
            }
            obj.CommitTransaction();
            return true;
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

        private void frmReviewScholarship_Load(object sender, EventArgs e)
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

        private bool IsValidData()
        {

            if (!uClass.IsValidData())
                return false;

            if (!uYearSemester.IsValidData())
                return false;

            if (LookupRegulationID.EditValue  == null)
            {
                MessageManager.Warning("Bạn phải chọn công thức!");
                LookupRegulationID.Focus();
                return false;
            }
            
            return true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // print danh sach sinh vien duoc hoc bong
            DataTable dtbData = (gvData.DataSource as DataView).Table;
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData, "Report/StudentManager/Learning/Leaning_XetHocBong_QC14.repx", false);
            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);
            frm.SetParameter("pScience", uClass.ScienceName);
            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pClass", uClass.ClassName);
            frm.SetParameter("pSemester", uYearSemester.SemesterEditValue);
            frm.SetParameter("pYearID", uYearSemester.YearEditValueText);
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

        private void mnuItemExportToExcel_Click(object sender, EventArgs e)
        {
            gvData.QuickExportToExcel();
        }

        private void mnuItemRefresh_Click(object sender, EventArgs e)
        {
            bolIsRefresh = true;
            new Thread(LoadData).Start();
        }

        private void mnuPopup_Print_Click(object sender, EventArgs e)
        {
            btnPrint_Click(null, null);
        }

        private void mnuItemSave_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
                btnSave.Enabled = mnuItemSave.Enabled = false;
        }

        /// <summary>
        ///  Nếu itemOld = null thì là thêm mới với itemNew

  #endregion
    }
}