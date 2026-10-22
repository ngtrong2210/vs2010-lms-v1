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

namespace StudentManager.Checking
{
    public partial class frmSubjectChecking : FormBase, IForm
    {
        #region Consts

        public const string PERMISSION_EDIT = "SIM_SubjectChecking_Edit";
        public const string PERMISSION_VIEW = "SIM_SubjectChecking_View";

        #endregion

        private string strClassID = "";
        private int intClassSubject = 0;
        private string strListIDDeleted = "";

        #region Variables
         
        bool bolIsEditing = false; // dang edit hay khong
       // SIM_SubjectChecking itemStudentEditing = new SIM_SubjectChecking(); // record đang edit

        #endregion

        #region IForm Members

        private static frmSubjectChecking _instance = null;

        public static frmSubjectChecking Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmSubjectChecking();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion


        public frmSubjectChecking()
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
                SIM_SubjectChecking obj = new SIM_SubjectChecking();

                DataTable dtbData = obj.Search(
                                "@ClassID", uClass.IsRegulation43 ? null : uClass.ClassIDEditValue.ToString(),
                                "@ClassSubjectID", uClass.ClassSubjectIDEditValue.ToString(),
                                "@Date", txtDate.EditValueDateTime.Value.Date);

                if (dtbData != null)
                {
                    gcData.DataSource = dtbData;
                    SYS_GridColumnService.InitGridColumn(gvData, "SIM_SubjectChecking");

                    // set order
                    gvData.SetOrder("Order");

                    //Nhớ lại giá trị khóa để save
                    //strClassID = uClassSubject.ClassIDEditValue.ToString();
                    //intYear = uYearSemester.YearIDEditValueInt32.Value;
                    //intSemester = uYearSemester.SemesterEditValueInt32.Value;
                    strListIDDeleted = "";

                    mnuItemSave.Enabled = btnSave.Enabled = false; // load lại thì không cần save 
                    mnuItemExportToExcel.Enabled = dtbData.Rows.Count > 0;

                }
                else
                {
                    ErrorManager.Error("Việc tải thông tin bị lỗi!");
                }
            }
        }

        #region Support Functions

        private void CheckPermission()
        {
            // Kiểm tra quyền
            gvData.OptionsBehavior.Editable = UserSession.HasPermission(PERMISSION_EDIT);
        }
   

      

        
        #endregion

        #region Form Actions

        private void frmSubjectChecking_Load(object sender, EventArgs e)
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
                    //MessageManager.Info("Đã cập nhật dữ liệu thành công!");
                    btnSave.Enabled = mnuItemSave.Enabled = false;
                    btnSearch_Click(sender, e);
                }
            }
        }

        private bool IsValidData()
        {
           
            if (!uClass.IsRegulation43 && uClass.ClassIDEditValue == null)
            {
                MessageManager.Warning("Bạn phải chọn lớp học!");
                uClass.Focus();
                return false;
            }
            if (uClass.ClassSubjectIDEditValue ==null)
            {
                MessageManager.Warning("Bạn phải chọn môn học!");
                uClass.Focus();
                return false;
            }

            if (txtDate.EditValueDateTime == null)
            {
                MessageManager.Warning("Bạn phải chọn ngày!");
                txtDate.Focus();
                return false;
            }

            //if (uYearSemester.SemesterEditValueInt32 < 1)
            //{
            //    MessageManager.Warning("Bạn phải chọn học kỳ!");
            //    uYearSemester.Focus();
            //    return false;
            //}
            return true;
        }
        /// <summary>
        /// Save dữ liệu ở tab edit
        /// </summary>
        private bool SaveData()
        {
            string strSubject = "";
            SIM_SubjectChecking obj = new SIM_SubjectChecking();
            obj.BeginTransaction();

            for (int i = 0; i < gvData.RowCount; i++)
            {
                DataRow drw = gvData.GetDataRow(i);

                SIM_SubjectChecking item = new SIM_SubjectChecking();
                item.IDB = obj.IDB;
                if (drw.RowState == DataRowState.Modified)
                {
                    if (drw[SIM_SubjectChecking.C_SubjectCheckingID].ToString() == "")
                    {
                        if (drw[SIM_SubjectChecking.C_NoPermissionQuantity].ToString() != "" || drw[SIM_SubjectChecking.C_PermissionQuantity].ToString() != "")
                        {

                            item.ClassSubjectID = Convert.ToInt64(uClass.ClassSubjectIDEditValue.ToString ());
                            item.StudentID = Convert.ToInt64(drw[SIM_SubjectChecking.C_StudentID]);
                            item.Date = txtDate.EditValueDateTime.Value.Date;
                            if (drw[SIM_SubjectChecking.C_NoPermissionQuantity].ToString() != "")
                            {
                                item.NoPermissionQuantity = Convert.ToInt32(drw[SIM_SubjectChecking.C_NoPermissionQuantity]);
                            }
                            else
                            {
                                item.NoPermissionQuantity = 0;
                            }
                            if (drw[SIM_SubjectChecking.C_PermissionQuantity].ToString() != "")
                            {
                                item.PermissionQuantity = Convert.ToInt32(drw[SIM_SubjectChecking.C_PermissionQuantity]);
                            }
                            else
                            {
                                item.PermissionQuantity = 0;
                            }
                            item.Description = drw[SIM_SubjectChecking.C_Description].ToString();
                            item.CreatedUser = UserSession.Username;
                            if (!item.Add())
                            {
                                ErrorManager.Error("Cập nhật điểm danh bị lỗi!");
                                return false;
                            }
                        }
                    }
                    else
                    {
                        if (drw[SIM_SubjectChecking.C_NoPermissionQuantity].ToString() == "" && drw[SIM_SubjectChecking.C_PermissionQuantity].ToString() == "")
                        {

                            item.SubjectCheckingID = Convert.ToInt64(drw[SIM_SubjectChecking.C_SubjectCheckingID]);
                            item.Delete();
                        }
                        else if (item.Parse(drw))
                        {
                            item.UpdatedUser = UserSession.Username;
                            if (!item.Update())
                            {
                                ErrorManager.Error("Cập nhật môn học lớp bị lỗi!");
                                return false;
                            }
                        }
                        else
                        {
                            ErrorManager.Error("Cập nhật môn học lớp bị lỗi!");
                        }
                    }
                }
            }
            obj.CommitTransaction();
            return true;
        }

        private void gvData_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            int iQuiChe = 0;
            DataTable dtbData = (gvData.DataSource as DataView).Table;
            string strreport = "";
            if (uClass.RegulationID == null)
                iQuiChe = 43;
            else
                iQuiChe = uClass.RegulationID.Value;
            switch (iQuiChe)
            {
                case 14: // cao đẳng, tc nghề
                    strreport = "Report/StudentManager/Learning/Leaning_DiemDanhMon_QC14.repx";
                    break;
                case 40: // trung cấp chuyên nghiệp
                    strreport = "Report/StudentManager/Learning/Leaning_DiemDanhMon_QC40.repx";
                    break;
                case 22: // trung cấp chuyên nghiệp
                    strreport = "Report/StudentManager/Learning/Leaning_DiemDanhMon_QC22.repx";
                    break;
                case 46: // trung cấp vừa học vừa làm
                    strreport = "Report/StudentManager/Learning/Leaning_DiemDanhMon_QC46.repx";
                    break;
                case 43: // tín chỉ
                    strreport = "Report/StudentManager/Learning/Leaning_DiemDanhMon_QC43.repx";
                    break;
                case 25:
                    strreport = "Report/StudentManager/Learning/Leaning_DiemDanhMon_QC25.repx";
                    break;
            }
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData, strreport, false);

            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);

            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pClass", uClass.ClassIDEditValue);
            frm.SetParameter("pSemester", uClass.Semester);
            frm.SetParameter("pYearID", uClass.UYearSemester.YearEditValueText);

            //Truyen tham so tinh trung binh, ti le phan tram
            DataRow drw = uClass.ClassSubject.Select("ClassSubjectID = " + uClass.ClassSubjectIDEditValue.ToString())[0];
            frm.SetParameter("pSubject", drw["SubjectName"].ToString());
            frm.SetParameter("pClassShortName", drw["ClassShortName"].ToString());
            frm.SetParameter("pUnitText", drw["UnitText"].ToString());

            frm.SetParameter("pTheo", drw["TheoryQuantity"].ToString());
            frm.SetParameter("pPrac", drw["PracticeQuantity"].ToString());


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

        /// <summary>
        ///  Nếu itemOld = null thì là thêm mới với itemNew


    }
}