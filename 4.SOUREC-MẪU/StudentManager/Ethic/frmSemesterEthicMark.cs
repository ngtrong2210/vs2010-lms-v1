using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using System.Collections;
using Libs;
using Global;
using DCore;
using SimsObject;
using SimsService;
using Service;
using GeneralObject;
using GeneralService;
using Global;

namespace StudentManager.Ethic
{
    public partial class frmSemesterEthicMark : FormBase, IForm
    {
        #region Consts

        public const string PERMISSION_ADD = "SIM_SemesterEthicMark_Add";
        public const string PERMISSION_DELETE = "SIM_SemesterEthicMark_Delete";
        public const string PERMISSION_EDIT = "SIM_SemesterEthicMark_Edit";
        public const string PERMISSION_VIEW = "SIM_SemesterEthicMark_View";
        #endregion

        private string strClassID = "";
        private int intYear = 0;
        private int intSemester = 0;
        private bool bolIsRefresh = false;

        #region Variables
         
        bool bolIsEditing = false; // dang edit hay khong
       // SIM_SemesterEthicMark itemStudentEditing = new SIM_SemesterEthicMark(); // record đang edit

        #endregion

        #region IForm Members

        private static frmSemesterEthicMark _instance = null;

        public static frmSemesterEthicMark Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmSemesterEthicMark();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmSemesterEthicMark()
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
                if (bolIsRefresh)
                {
                    uClass.RefrehData();
                    uYearSemester.RefrehData();
                }
                else
                {
                    uClass.InitData();
                    uYearSemester.InitData();
                }
            }
        }
        DataTable dtbData = null;
        public void LoadData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadData));
            else
            {
                try
                {
                    dtbData = new SIM_SemesterEthicMark().Search(
                                    "@ClassID", uClass.ClassIDEditValue,
                                    "@Year", uYearSemester.YearIDEditValueInt32,
                                    "@Semester", uYearSemester.SemesterEditValueInt32);

                    gcData.DataSource = dtbData;
                    SystemService.SYS_GridColumnService.InitGridColumn(gvData, "SIM_SemesterEthicMark", bolIsRefresh);

                    //Nhớ lại giá trị khóa để save
                    strClassID = uClass.ClassIDEditValue.ToString();
                    intYear = uYearSemester.YearIDEditValueInt32.Value;
                    intSemester = uYearSemester.SemesterEditValueInt32.Value;
                    mnuItemExportToExcel.Enabled = mnuItemExportTemplate.Enabled = mnuItemImportFromExcel.Enabled = true;
                    mnuItemSave.Enabled = btnSave.Enabled = false; // load lại thì không cần save 
                    bolIsRefresh = false;
                }
                catch (Exception objEx)
                {
                    ErrorManager.Error(objEx);
                    SYS_ErrorLogService.Write(Enums.ActionType.View, "frmSpecialBranch_Subject->LoadData", objEx, 0);
                }
            }
        }

        private bool IsValidData()
        {

            if (uClass.ClassIDEditValue == null)
            {
                MessageManager.Warning("Bạn phải chọn lớp học!");
                uClass.Focus();
                return false;
            }
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
            SIM_SemesterEthicMark obj = new SIM_SemesterEthicMark();
            obj.BeginTransaction();

            for (int i = 0; i < gvData.RowCount; i++)
            {
                DataRow drw = gvData.GetDataRow(i);
                if (drw.RowState == DataRowState.Modified)
                {
                    SIM_SemesterEthicMark item = new SIM_SemesterEthicMark();
                    item.IDB = obj.IDB;
                    if (item.Parse(drw))
                    {
                        if (item.SemesterEthicMarkID == null) // thêm mới nếu chưa có và có điểm
                        {
                            if (item.Mark != null)
                            {
                                item.Semester = intSemester;
                                item.YearID = intYear;

                                item.CreatedUser = UserSession.Username;
                                if (!item.Add())
                                {
                                    ErrorManager.Error("Cập nhật điểm rèn luyện sinh viên bị lỗi!");
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            if (item.Mark == null) // xoá rèn luyện
                            {
                                if (item.Delete())
                                {
                                    ErrorManager.Error("Xoá điểm rèn luyện sinh viên bị lỗi!");
                                    return false;
                                }
                            }
                            else // sửa
                            {
                                item.UpdatedUser = UserSession.Username;
                                if (!item.Update())
                                {
                                    ErrorManager.Error("Cập nhật điểm rèn luyện sinh viên bị lỗi!");
                                    return false;
                                }
                            }
                        }
                    }
                    else
                    {
                        ErrorManager.Error("Lấy dữ liệu cập nhật bị lỗi!");
                        obj.RollBackTransaction();
                        return false;
                    }
                }
            }
            obj.CommitTransaction();
            return true;
        }

        private void ImportFromExcel()
        {
            if (gvData.QuickImportFromExcel("Mã SV", ",Họ đệm,Tên,Ngày sinh,GT,", Application.StartupPath + "\\MauExcel\\Hoc sinh") > 0)
            {
                for (int i = 0; i < gvData.RowCount; i++)
                {
                    DataRow drw = gvData.GetDataRow(i);
                    TotalRow(drw);
                }
                btnSave.Enabled = mnuItemSave.Enabled = true;
            }
        }

        private void TotalRow(DataRow drw)
        {
            int sum = 0;
            bool bolFlag = false;
            for (int i = 1; i <= 10; i++)
            {
                if (drw["Mark" + i.ToString()].ToString() != "")
                {
                    sum += Convert.ToInt32(drw["Mark" + i.ToString()]);
                    bolFlag = true;
                }
            }

            // neu co diem
            if (bolFlag)
            {
                drw["Mark"] = sum;
                SummaryEthic(drw, "Mark", "Level"); // xếp loại
            }
            else
            {
                drw["Mark"] = DBNull.Value;
                drw["Level"] = DBNull.Value;
            }

        }

        private void SummaryEthic(DataRow drw, string fieldMark, string fieldLevel)
        {
            SimsService.SIM_EthicMarkService.SummaryEthic(drw, fieldMark, fieldLevel, uClass.RegulationID); // xếp loại
        }

        #endregion

        #region Form Actions

        private void frmSemesterEthicMark_Load(object sender, EventArgs e)
        {
            CheckPermission();
            SetToolTip();
            new Thread(LoadReferenceData).Start();        
        }

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
            if (SaveData())
            {
                //MessageManager.Info("Đã cập nhật dữ liệu thành công!");
                btnSave.Enabled = mnuItemSave.Enabled = false;
                btnSearch_Click(sender, e);
            }
        }

        private void gvData_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataRow drw = gvData.GetFocusedDataRow();
            TotalRow(drw);
            btnSave.Enabled = true;
        }

        private void mnuItemExportToExcel_Click(object sender, EventArgs e)
        {
            gvData.QuickExportToExcel();
        }

        private void mnuItemRefresh_Click(object sender, EventArgs e)
        {
            bolIsRefresh = true;
            LoadReferenceData();
            btnSearch_Click(sender, e);
        }

        private void gvData_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (e.Value == null || e.Value.ToString() == "")
                e.Value = DBNull.Value;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void mnuItemImportFromExcel_Click(object sender, EventArgs e)
        {
            ImportFromExcel();
        }

        private void mnuItemExportTemplate_Click(object sender, EventArgs e)
        {
            Hashtable hstReplaceValues = new Hashtable();
            hstReplaceValues.Add("{Khoa}", uClass.ScienceName);
            hstReplaceValues.Add("{Ngành}", uClass.SpecialBranchName);
            hstReplaceValues.Add("{Lớp}", uClass.ClassName);
            hstReplaceValues.Add("{Môn}", uClass.SubjectName);
            hstReplaceValues.Add("{Niên}", uClass.UYearSemester.YearEditValueText);
            hstReplaceValues.Add("{Kì}", uClass.Semester);

            if (!gvData.ExportTemplateExcel("Mã SV", hstReplaceValues, Application.StartupPath + "\\MauExcel\\Hoc sinh\\Chi tiet diem ren luyen hoc ky.xls", Application.StartupPath + "\\MauExcel\\Hoc sinh"))
                MessageManager.Warning("File mẫu chưa đúng định dạng hoặc chưa có cột ''Mã SV''!");
        }

        #endregion

        private void mnuPrint_Click(object sender, EventArgs e)
        {
            
        }

        private void mnuPrint_m1_Click(object sender, EventArgs e)
        {
            string strReport = "Report/StudentManager/Ethic/Student_DiemRenLuyen1.repx";
            if (dtbData.Rows.Count <= 0)
                return;
            
            // Set xep loai tot nghiep
            int iTB = 0; int iTBKha = 0; int iKha = 0; int iTot = 0; int iXuatSac = 0; int iSV = 0; int iYeu = 0;
            for (int j = 0; j < dtbData.Rows.Count; j++)
            {

                iSV += 1;
                if (Convert.ToString(dtbData.Rows[j]["Level"]) == "Yếu" || Convert.ToString(dtbData.Rows[j]["Level"]) == "Kém")
                    iYeu += 1;
                else if (Convert.ToString(dtbData.Rows[j]["Level"]) == "Trung bình")
                    iTB += 1;
                else if (Convert.ToString(dtbData.Rows[j]["Level"]) == "TB khá")
                    iTBKha += 1;
                else if (Convert.ToString(dtbData.Rows[j]["Level"]) == "Khá")
                    iKha += 1;
                else if (Convert.ToString(dtbData.Rows[j]["Level"]) == "Tốt")
                    iTot += 1;
                else if (Convert.ToString(dtbData.Rows[j]["Level"]) == "Xuất sắc")
                    iXuatSac += 1;
            }
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData, strReport, false);

            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);
            frm.SetParameter("pTrainingLevel", uClass.TrainingLevelName);

            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pClass", uClass.ClassName);
            frm.SetParameter("pSemester", uYearSemester.SemesterEditValue);
            frm.SetParameter("pYear", uYearSemester.YearEditValueText);

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
            frm.SetParameter("pSV", iSV);
           
            frm.Show();
        }

        private void mnu_printM2_Click(object sender, EventArgs e)
        {
            string strReport = "Report/StudentManager/Ethic/Student_DiemRenLuyen2.repx";
            if (dtbData.Rows.Count <= 0)
                return;

            // Set xep loai tot nghiep
            int iTB = 0; int iTBKha = 0; int iKha = 0; int iTot = 0; int iXuatSac = 0; int iSV = 0; int iYeu = 0;
            for (int j = 0; j < dtbData.Rows.Count; j++)
            {

                iSV += 1;
                if (Convert.ToString(dtbData.Rows[j]["Level"]) == "Yếu" || Convert.ToString(dtbData.Rows[j]["Level"]) == "Kém")
                    iYeu += 1;
                else if (Convert.ToString(dtbData.Rows[j]["Level"]) == "Trung bình")
                    iTB += 1;
                else if (Convert.ToString(dtbData.Rows[j]["Level"]) == "TB khá")
                    iTBKha += 1;
                else if (Convert.ToString(dtbData.Rows[j]["Level"]) == "Khá")
                    iKha += 1;
                else if (Convert.ToString(dtbData.Rows[j]["Level"]) == "Tốt")
                    iTot += 1;
                else if (Convert.ToString(dtbData.Rows[j]["Level"]) == "Xuất sắc")
                    iXuatSac += 1;
            }
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData, strReport, false);

            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);
            frm.SetParameter("pTrainingLevel", uClass.TrainingLevelName);

            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pClass", uClass.ClassName);
            frm.SetParameter("pSemester", uYearSemester.SemesterEditValue);
            frm.SetParameter("pYear", uYearSemester.YearEditValueText);

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
            frm.SetParameter("pSV", iSV);

            frm.Show();
        }
    }
}