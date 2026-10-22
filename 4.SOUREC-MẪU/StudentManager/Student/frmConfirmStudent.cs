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

namespace StudentManager.Student
{
    public partial class frmConfirmStudent : FormBase, IForm
    {
        #region Consts
                        
        public const string PERMISSION_VIEW = "SIM_ConfirmStudent_View";

        #endregion

        private string strClassID = "";
        private int intYear = 0;
        private string strListIDDeleted = "";

        #region Variables
         
        bool bolIsEditing = false; // dang edit hay khong
        DataTable dtbData;
        #endregion

        #region IForm Members

        private static frmConfirmStudent _instance = null;

        public static frmConfirmStudent Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmConfirmStudent();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        #region Support Functions

        public frmConfirmStudent()
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

            }
        }

        public void LoadData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadData));
            else
            {
                try
                {
                    dtbData = new SIM_Student().Search("@ClassID", uClass.ClassIDEditValue,
                                                        "@StatusList", ";1;"); // chỉ có đang học mới cho in giấy xác nhận

                    gcData.DataSource = dtbData;
                    SYS_GridColumnService.InitGridColumn(gvData, "SIM_Student");
                    // set order
                    gvData.SetOrder("Order");


                }
                catch (Exception objEx)
                {
                    ErrorManager.Error(objEx);
                    SYS_ErrorLogService.Write(Enums.ActionType.View, "frmConfirmStudent->LoadData", objEx, 0);
                }
            }
        }
        
        private void CheckPermission()
        {
            // Kiểm tra quyền
           
        }        
        
        #endregion

        #region Form Actions

        private void frmConfirmStudent_Load(object sender, EventArgs e)
        {
       
            CheckPermission();
            SetToolTip();
            new Thread(LoadReferenceData).Start();        
        }            

        private void btnSearch_Click(object sender, EventArgs e)
        {

            new Thread(LoadData).Start();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
        }

        private bool IsValidData()
        {
           
            if (uClass.ClassIDEditValue == null)
            {
                MessageManager.Warning("Bạn phải chọn lớp học!");
                uClass.Focus();
                return false;
            }
           
            return true;
        }

        private void mnuPopupGrid_Opening(object sender, CancelEventArgs e)
        {
            if (dtbData != null)
                if (dtbData.Rows.Count > 0)
                {
                    mnuItemCheckingAll.Enabled = mnuItemUnCheckingAll.Enabled = true;
                    return;
                }
            mnuItemCheckingAll.Enabled = mnuItemUnCheckingAll.Enabled  = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuItemVayVon_Click(object sender, EventArgs e)
        {
            // print Sinh vien
            // print Sinh vien                        
            DataTable dtbData2 = dtbData.Copy();
            dtbData2.DefaultView.RowFilter = "IsSelected = 1";

            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData2, "Report/StudentManager/Student/Student_GiayChungNhanSinhVien2.repx", false);
            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);
            frm.SetParameter("pTrainingLevel", uClass.TrainingLevelName);
            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pScience", uClass.ScienceName);
            frm.SetParameter("pPrint", "ngày " + Convert.ToString(DateTime.Today.Day) + " tháng " + Convert.ToString(DateTime.Today.Month) + " năm " + Convert.ToString(DateTime.Today.Year));

            frm.Show();
        }

        private void mnuItemCN_Click(object sender, EventArgs e)
        {
            // print Sinh vien                        
            DataTable dtbData2 = dtbData.Copy();
            dtbData2.DefaultView.RowFilter = "IsSelected = 1";
            
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData2, "Report/StudentManager/Student/Student_GiayChungNhanSinhVien.repx", false);
            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);
            frm.SetParameter("pTrainingLevel", uClass.TrainingLevelName);
            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pPrint", "ngày " + Convert.ToString(DateTime.Today.Day) + " tháng " + Convert.ToString(DateTime.Today.Month) + " năm " + Convert.ToString(DateTime.Today.Year));
            frm.SetParameter("pScience", uClass.ScienceName);

            frm.Show();
        }

        #endregion

        private void mnuMauDonMienGiam_Click(object sender, EventArgs e)
        {
            // mau don mien giam                     
            DataTable dtbData2 = dtbData.Copy();
            dtbData2.DefaultView.RowFilter = "IsSelected = 1";

            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData2, "Report/StudentManager/Student/Student_GiayVaoLop.repx", false);
            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);
            frm.SetParameter("pTrainingLevel", uClass.TrainingLevelName);
            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pScience", uClass.ScienceName);
            frm.SetParameter("pPrint", "ngày " + Convert.ToString(DateTime.Today.Day) + " tháng " + Convert.ToString(DateTime.Today.Month) + " năm " + Convert.ToString(DateTime.Today.Year));
            frm.Show();
        }

        private void mnuMauTroCap_Click(object sender, EventArgs e)
        {
            //Mau don tro cap vay tien theo 49                     
            DataTable dtbData2 = dtbData.Copy();
            dtbData2.DefaultView.RowFilter = "IsSelected = 1";

            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData2, "Report/StudentManager/Student/Student_ThongTinHocVien.repx", false);
            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);
            frm.SetParameter("pTrainingLevel", uClass.TrainingLevelName);
            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pScience", uClass.ScienceName);
            frm.SetParameter("pPrint", "ngày " + Convert.ToString(DateTime.Today.Day) + " tháng " + Convert.ToString(DateTime.Today.Month) + " năm " + Convert.ToString(DateTime.Today.Year));
            frm.Show();
        }

        private void mnuNghiPhep_Click(object sender, EventArgs e)
        {
            // Mau don nghi phep                        
            DataTable dtbData2 = dtbData.Copy();
            dtbData2.DefaultView.RowFilter = "IsSelected = 1";

            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData2, "Report/StudentManager/Student/Student_GiayChungNhanNghiPhep.repx", false);
            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);
            frm.SetParameter("pTrainingLevel", uClass.TrainingLevelName);
            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pScience", uClass.ScienceName);
            frm.SetParameter("pPrint", "ngày " + Convert.ToString(DateTime.Today.Day) + " tháng " + Convert.ToString(DateTime.Today.Month) + " năm " + Convert.ToString(DateTime.Today.Year));
            frm.Show();
        }

        private void mnuPrint6_Click(object sender, EventArgs e)
        {
            // print Sinh vien
            // print Sinh vien                        
            DataTable dtbData2 = dtbData.Copy();
            dtbData2.DefaultView.RowFilter = "IsSelected = 1";

            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData2, "Report/StudentManager/Student/Student_GiayXacNhanVayVon2.repx", false);
            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);
            frm.SetParameter("pTrainingLevel", uClass.TrainingLevelName);
            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pScience", uClass.ScienceName);
            frm.SetParameter("pPrint", "ngày " + Convert.ToString(DateTime.Today.Day) + " tháng " + Convert.ToString(DateTime.Today.Month) + " năm " + Convert.ToString(DateTime.Today.Year));

            frm.Show();
        }

        private void mnu_Print7_Click(object sender, EventArgs e)
        {
            // print Sinh vien                        
            DataTable dtbData2 = dtbData.Copy();
            dtbData2.DefaultView.RowFilter = "IsSelected = 1";

            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData2, "Report/StudentManager/Student/Student_TheSinhVien.repx", false);
            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);
            frm.SetParameter("pTrainingLevel", uClass.TrainingLevelName);
            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pPrint", "ngày " + Convert.ToString(DateTime.Today.Day) + " tháng " + Convert.ToString(DateTime.Today.Month) + " năm " + Convert.ToString(DateTime.Today.Year));
            frm.SetParameter("pScience", uClass.ScienceName);

            frm.Show();
        }

        private void mnuItemCheckingAll_Click(object sender, EventArgs e)
        {
            foreach(DataRow drw in dtbData.Rows)
                drw["IsSelected"] = true;                
        }

        private void mnuItemUnCheckingAll_Click(object sender, EventArgs e)
        {
            foreach (DataRow drw in dtbData.Rows)
                drw["IsSelected"] = false;      
        }

    }
}