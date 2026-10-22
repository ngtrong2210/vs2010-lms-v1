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
using DataAccess;
using Microsoft.Office;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;

using System.Linq;
//thư viện thêm t để in mẫu word
using Aspose.Words;
using Aspose.Words.Tables;
//using Lib.Report.AsposeWordExtension;
using System.IO;


namespace StudentManager.StudentCollection
{
    public partial class frmStudentCollectionResult : FormBase, IForm
    {
        #region Consts
        
        public const string PERMISSION_VIEW = "SIM_StudentCollectionResult_View";
        public const string PERMISSION_EDIT = "SIM_StudentCollectionResult_Edit";

        #endregion

        
        #region Variables
         
        bool bolIsEditing = false; // dang edit hay khong
        private string strClassID = "";
        private int intYear = 0;
        private int intSemester = 0;
        private string strListIDDeleted = "";
        private string sPath = string.Empty;
        private string sFileName = string.Empty;
        private byte[] sByte = new byte[0];
        string file;
        string path;
        string path2;
        private bool bolIsRefresh = false;
        private DataTable dtbData = null;

       // SIM_StudentCollection itemStudentEditing = new SIM_StudentCollection(); // record đang edit

        #endregion

        #region IForm Members

        private static frmStudentCollectionResult _instance = null;

        public static frmStudentCollectionResult Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmStudentCollectionResult();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmStudentCollectionResult()
        {
            InitializeComponent();
        }
        
        #region Support Functions

        private void CheckPermission()
        {
            // Kiểm tra quyền
            gvData.OptionsBehavior.Editable = UserSession.HasPermission(PERMISSION_EDIT);
           
        }        

        public void LoadReferenceData()
        {
            uPeriod.InitData();
            uSpecialBranch.InitData();
            SimsService.SIM_ClassService.InitLookUpEdit(lookupClassID);
        }

        public void RefreshReferenceData()
        {
            uPeriod.RefrehData();
            uSpecialBranch.RefrehData();
            SimsService.SIM_ClassService.HaveNewData = true;
            SimsService.SIM_ClassService.InitLookUpEdit(lookupClassID);
        }

        public void LoadData()
        {

            SIM_StudentCollection obj = new SIM_StudentCollection();
            dtbData = obj.Search(
                           "@StudentCollectionPeriodID", uPeriod.StudentCollectionPeriodIDEditValue,
                           "@CourseID", uPeriod.CourseIDEditValue,
                           "@TrainingType", uPeriod.TrainingTypeEditValue,
                           "@TrainingLevelID", uPeriod.TrainingLevelIDEditValue,
                           "@BranchID", uSpecialBranch.BranchEditValue,
                           "@SpecialBranchID", uSpecialBranch.SpecialBranchEditValue,
                           "@FromDate", txtFromDate.EditValue,
                           "@ToDate", txtToDate.EditValue,
                           "@StudentCollectionCode", txtStudentCollectionCode.TextTrim,
                           "@FullName", txtFullName.TextTrim,
                           "@Result", cbxResult.SelectedIndex);
            if (dtbData != null)
            {
                gcData.DataSource = dtbData;
                SystemService.SYS_GridColumnService.InitGridColumn(gvData, "SIM_StudentCollectionResult",bolIsRefresh);
                //Nhớ lại giá trị khóa để save
                btnPrint0.Enabled = btnPrint1.Enabled = mnuItemPrint.Enabled = mnuItemExportToExcel.Enabled = dtbData.Rows.Count > 0;
                mnuItemEdit.Enabled = gvData.GetFocusedDataRow() != null;
                mnuItemUpdateCerNo.Enabled = false;
                bolIsRefresh = false;//

            }
            else
                ErrorManager.Error("Việc load thông tin bị lỗi!");
        }

        private void FilterClass()
        {
            if (uPeriod.StudentCollectionPeriodIDEditValue != null && uSpecialBranch.SpecialBranchEditValue != null)
            {
                string strFilter ="CourseID = '" + uPeriod.CourseIDEditValue 
                    + "' and TrainingLevelID = '" + uPeriod.TrainingLevelIDEditValue
                    + "' and TrainingType = '" + uPeriod.TrainingTypeEditValue 
                    + "' and SpecialBranchID = '" + uSpecialBranch.SpecialBranchEditValue + "'";
                strFilter = "(" + strFilter + ") OR IsTempClass = 1"; // hoặc lấy lớp tạm ra
                
                lookupClassID.RowFilter = strFilter;
            }
            else
                lookupClassID.RowFilter = "ClassID = '-1'";                
        }

        private void ShowEditForm(long? studentCollectionID)
        {
            frmStudentCollectionDetail frmEdit = frmStudentCollectionDetail.Instance;
            frmEdit.LoadData(studentCollectionID);
            frmEdit.ShowDialog();

            if (frmEdit.IsOk && frmEdit.StudentCollectionIDNew != null)
            {
                LoadData();
                gvData.SearchAndSelectRow("StudentCollectionID", frmEdit.StudentCollectionIDNew);
            }
        }
                
        #endregion

        #region Form Actions

        private void frmStudentCollectionResult_Load(object sender, EventArgs e)
        {       
            CheckPermission();
            SetToolTip();
            LoadReferenceData();            
        }
                    
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //new Thread(LoadData).Start();
            if (uPeriod.StudentCollectionPeriodIDEditValue == null)
            {
                MessageManager.Warning("Bạn phải chọn đợt tuyển sinh");
                return;
            }
            LoadData();
        }                               
        private void mnuItemExportToExcel_Click(object sender, EventArgs e)
        {
            gvData.QuickExportToExcel();
        }

        private void mnuItemRefresh_Click(object sender, EventArgs e)
        {
            bolIsRefresh = true;
            uPeriod.RefrehData();
            uSpecialBranch.RefrehData();
            Service.SIM_ClassService.HaveNewData = true;
            Service.SIM_ClassService.InitLookUpEdit(lookupClassID);
            btnSearch_Click(null, null);
        }

        private void uPeriod_EditValueChanged(object sender, EventArgs arg)
        {
            if (uPeriod.LearningLevel > 0)
                uSpecialBranch.SpecialBranchFilter = "LearningLevel = " + uPeriod.LearningLevel.ToString();
            else
                uSpecialBranch.SpecialBranchFilter = "";

            FilterClass();
        }

        private void uSpecialBranch_EditValueChanged(object sender, EventArgs arg)
        {
            FilterClass();
        }

        private void frmStudentCollectionResult_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F1:
                    this.ShowToolTip();
                    break;

                case Keys.F3:
                    btnSearch_Click(sender, null);
                    break;
                case Keys.F4:
                    break;
                case Keys.F5:
                    mnuItemRefresh_Click(sender, null);
                    break;
                case Keys.F6:

                    break;
                case Keys.F7:
                    //btnPrint_Click(sender, null);
                    break;
                case Keys.F8:

                    break;
                case Keys.F12:
                    uPeriod.Reset();
                    uSpecialBranch.Reset();
                    break;
            }
        }

        private void mnuItemEdit_Click(object sender, EventArgs e)
        {
            DataRow drw = gvData.GetFocusedDataRow();
            if (drw != null)
            {
                ShowEditForm(Convert.ToInt64(drw["StudentCollectionID"]));
            }
        }

        private void btnFillToClass_Click(object sender, EventArgs e)
        {
            if (lookupClassID.EditValue != null)
            {
                DataRow[] rows = dtbData.Select("IsSelected = 1");
                string strListID = "";
                foreach (DataRow drw in rows)
                {
                    strListID += drw["StudentCollectionID"].ToString() + ";";
                }
                if (strListID != "")
                {
                    strListID = ";" + strListID;
                    SIM_StudentCollection obj = new SIM_StudentCollection();
                    if (obj.FillToClass(strListID, lookupClassID.EditValueString, UserSession.Username)) // nếu không cần lớp thì đưa vào lớp 0 (lớp chưa phân, chỉ để thu tiền hoặc học văn hoá)
                    {
                        MessageManager.Info("Đã chuyển hồ sơ thành công!");
                    }
                    else
                    {
                        ErrorManager.Error("Việc chuyển hồ sơ bị lỗi!");
                    }
                }
            }
        }   
        
        #endregion

        private void btnPrint0_Click(object sender, EventArgs e)
        {
            // print danh sach giay bao KHONG trung tuyen
            // Tuỳ loại đợt tuyển sinh mà in mẫu
            string strMau = "CaoDang";
            switch (uPeriod.CollectionType)
            {
                case Global.StudentCollectionType.SoCap:
                    strMau = "SoCap";
                    break;
                case Global.StudentCollectionType.TrungCap25:
                case Global.StudentCollectionType.TrungCap35:
                    strMau = "TrungCap";
                    break;
                case Global.StudentCollectionType.CaoDang:
                    strMau = "CaoDang";
                    break;
                case Global.StudentCollectionType.LienThong:
                    strMau = "LienThong";
                    break;
            }

            DataTable dtbData2 = dtbData.Copy();
            dtbData2.DefaultView.RowFilter = "Result = 0 and IsSelected = 1";
            dtbData2 = dtbData2.DefaultView.ToTable();
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData2, "Report/StudentCollection/TS_DSKhongTrungTuyen_" + strMau + ".repx", false);

            frm.Show();
        }

        private void btnPrint1_Click(object sender, EventArgs e)
        {
            // print danh sach giay bao trung tuyen
            // Tuỳ loại đợt tuyển sinh mà in mẫu
            string strMau = "CaoDang";
            switch (uPeriod.CollectionType)
            {
                case Global.StudentCollectionType.SoCap:
                    strMau = "SoCap";
                    break;
                case Global.StudentCollectionType.TrungCap25:
                case Global.StudentCollectionType.TrungCap35:
                    strMau = "TrungCap";
                    break;
                case Global.StudentCollectionType.CaoDang:
                    strMau = "CaoDang";
                    break;
                case Global.StudentCollectionType.LienThong:
                    strMau = "LienThong";
                    break;
            }

            DataTable dtbData2 = dtbData.Copy();
            dtbData2.DefaultView.RowFilter = "Result > 0 and IsSelected = 1";
            dtbData2 = dtbData2.DefaultView.ToTable();
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData2, "Report/StudentCollection/TS_DSTrungTuyen_" + strMau + ".repx", false);

            frm.Show();
        }

        /// <summary>
        /// Giấy báo trúng tuyển
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuItemPrintNote1_Click(object sender, EventArgs e)
        {
            // print danh sach giay bao trung tuyen
            // Tuỳ loại đợt tuyển sinh mà in mẫu
            //string strMau = "CaoDang";
            //switch (uPeriod.CollectionType)
            //{
            //    case Global.StudentCollectionType.SoCap:
            //        strMau = "SoCap";
            //        break;
            //    case Global.StudentCollectionType.TrungCap25:
            //    case Global.StudentCollectionType.TrungCap35:
            //        strMau = "TrungCap";
            //        break;
            //    case Global.StudentCollectionType.CaoDang:
            //        strMau = "CaoDang";
            //        break;
            //    case Global.StudentCollectionType.LienThong:
            //        strMau = "LienThong";
            //        break;
            //}

            DataTable dtbData2 = dtbData.Copy();
            dtbData2.DefaultView.RowFilter = "Result > 0 and IsSelected = 1";
            dtbData2 = dtbData2.DefaultView.ToTable();
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData2, "Report/StudentCollection/TS_GiayBaoTrungTuyen.repx", false);

            frm.Show();
        }
        private void mnuItemPrintNote2_Click(object sender, EventArgs e)
        {
            // print danh sach giay bao trung tuyen
            // Tuỳ loại đợt tuyển sinh mà in mẫu
            string strMau = "TrungCap";
            //switch (uPeriod.CollectionType)
            //{
            //    case Global.StudentCollectionType.SoCap:
            //        strMau = "SoCap";
            //        break;
            //    case Global.StudentCollectionType.TrungCap25:
            //    case Global.StudentCollectionType.TrungCap35:
            //        strMau = "TrungCap";
            //        break;
            //    case Global.StudentCollectionType.CaoDang:
            //        strMau = "CaoDang";
            //        break;
            //    case Global.StudentCollectionType.LienThong:
            //        strMau = "LienThong";
            //        break;
            //}

            DataTable dtbData2 = dtbData.Copy();
            dtbData2.DefaultView.RowFilter = "Result > 0 and IsSelected = 1";
            dtbData2 = dtbData2.DefaultView.ToTable();
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData2, "Report/StudentCollection/TS_GiayBaoTrungTuyen_" + strMau + ".repx", false);

            frm.Show();
        }
        /// <summary>
        /// Giấy báo không trúng tuyển
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuItemPrintNote0_Click(object sender, EventArgs e)
        {
            // print danh sach giay bao khong trung tuyen
            // Tuỳ loại đợt tuyển sinh mà in mẫu
            string strMau = "CaoDang";
            switch (uPeriod.CollectionType)
            {
                case Global.StudentCollectionType.SoCap:
                    strMau = "SoCap";
                    break;
                case Global.StudentCollectionType.TrungCap25:
                case Global.StudentCollectionType.TrungCap35:
                    strMau = "TrungCap";
                    break;
                case Global.StudentCollectionType.CaoDang:
                    strMau = "CaoDang";
                    break;
                case Global.StudentCollectionType.LienThong:
                    strMau = "LienThong";
                    break;
            }

            DataTable dtbData2 = dtbData.Copy();
            dtbData2.DefaultView.RowFilter = "Result = 0 and IsSelected = 1";
            dtbData2 = dtbData2.DefaultView.ToTable();
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData2, "Report/StudentCollection/TS_GiayBaoKhongTrungTuyen_" + strMau + ".repx", false);

            frm.Show();
        }

        /// <summary>
        /// In giấy báo nhập học
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuItemPrintNode3_Click(object sender, EventArgs e)
        {
            // print danh sach giay bao khong trung tuyen
            // Tuỳ loại đợt tuyển sinh mà in mẫu
            string strMau = "CaoDang";
            switch (uPeriod.CollectionType)
            {
                case Global.StudentCollectionType.SoCap:
                    strMau = "SoCap";
                    break;
                case Global.StudentCollectionType.TrungCap25:                
                    strMau = "TrungCap";
                    break;
                case Global.StudentCollectionType.TrungCap35:
                    strMau = "TrungCap3";
                    break;
                case Global.StudentCollectionType.CaoDang:
                    if (uPeriod.TrainingLevelIDEditValue == "3")
                        strMau = "CaoDangQuocTe";
                    else
                        strMau = "CaoDang";
                    break;
                case Global.StudentCollectionType.LienThong:
                    strMau = "LienThong";
                    break;
            }

            DataTable dtbData2 = dtbData.Copy();
            dtbData2.DefaultView.RowFilter = "Result > 0 and IsSelected = 1";
            dtbData2 = dtbData2.DefaultView.ToTable();
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData2, "Report/StudentCollection/TS_GiayBaoNhapHoc_" + strMau + ".repx", false);

            frm.Show();
        }

        private void ModifyGrid()
        {
            for (int i = 5; i <= 7; i++)
            {
                gvData.Columns["Mark" + i.ToString()].Visible = false;
            }

            if (uPeriod.StudentCollectionPeriodIDEditValue != null)
            {
                // chỉnh lại thông tin xét tuyển ứng với từng loại bậc xét tuyển
                switch (uPeriod.CollectionType)
                {

                    case Global.StudentCollectionType.TrungCap35:
                        string[] caption = { "", "Lớp 6", "Lớp 7", "Lớp 8", "Lớp 9" };
                        for (int i = 1; i <= 4; i++)
                        {
                            gvData.Columns["Mark" + i.ToString()].Visible = true;
                            gvData.Columns["Mark" + i.ToString()].Caption = caption[i];
                        }

                        gvData.Columns["SummaryMark"].Visible = true;

                        //cbxExperience.Visible = false;
                        //cbxGraduationLevel.Visible = false;
                        //lblGraduationLevel.Visible = false;
                        //lblExperience.Visible = false;
                        break;

                    case Global.StudentCollectionType.LienThong:
                        for (int i = 1; i <= 7; i++)
                        {
                            gvData.Columns["Mark" + i.ToString()].Visible = false;
                        }

                        gvData.Columns["SummaryMark"].Visible = false;

                        //cbxExperience.Visible = true;
                        //cbxGraduationLevel.Visible = true;
                        //lblGraduationLevel.Visible = true;
                        //lblExperience.Visible = true;
                        break;
                    default:
                        string[] caption2 = { "", "Lớp 10", "Lớp 11", "Lớp 12" };
                        for (int i = 1; i <= 3; i++)
                        {
                            gvData.Columns["Mark" + i.ToString()].Visible = true;
                            gvData.Columns["Mark" + i.ToString()].Caption = caption2[i];
                        }

                        gvData.Columns["Mark4"].Visible = false;

                        gvData.Columns["SummaryMark"].Visible = true;

                        break;
                }
            }
        }

        private void mnuItemUpdateCerNo_Click(object sender, EventArgs e)
        {
            SIM_StudentCollection obj = new SIM_StudentCollection();
            obj.BeginTransaction();
            obj.UpdatedUser = UserSession.Username;

            for (int i = 0; i <= gvData.RowCount; i++)
            {                
                DataRow drw = gvData.GetDataRow(i);
                if (drw != null)
                {
                    obj.StudentCollectionID = Convert.ToInt64(drw["StudentCollectionID"]);
                    obj.Result = Convert.ToInt32(drw["Result"]);
                    obj.CerNo = drw["CerNo"].ToString();
                    if (!obj.UpdateResult())
                    {
                        ErrorManager.Error("Cập nhật thứ tự hồ sơ bị lỗi!");
                        return;
                    }
                }
            }

            obj.CommitTransaction();
            MessageManager.Info("Đã cập nhật thành công!");
        }

        private void gvData_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            mnuItemUpdateCerNo.Enabled = true;
        }

        private void mnuItemPrint_BiaThu_Click(object sender, EventArgs e)
        {
            DataTable dtbData2 = dtbData.Copy();
            dtbData2.DefaultView.RowFilter = "IsSelected = 1";
            dtbData2 = dtbData2.DefaultView.ToTable();
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData2, "Report/StudentCollection/TS_BiaThu.repx", false);

            frm.Show();
        }

        private void mnuPrint4_Click(object sender, EventArgs e)
        {
            DataRow drw = gvData.GetFocusedDataRow();

            int sStudentID = Convert.ToInt32(drw["StudentID"]);
            if (sStudentID <= 0)
            {
                MessageManager.Warning("Bạn phải chọn dữ liệu để in!");
                return;
            }


            SoanFileMau(sStudentID, "XacNhanSV");
        }
        private void SoanFileMau(int sSinhVien, string sFile)
        {
            string filename = "";
            try
            {
                // print danh sach 
                SIM_Student obj = new SIM_Student();
                DataTable dt = obj.GetDataTable("SIM_Student_Search1", "@StudentID", sSinhVien);
                if (dt.Rows.Count == 0)
                    return;
                //ID1 = NhanSuID;
                //string path2;

                filename = sFile + ".doc";
                path2 = @"\Template\FileSinhVien\" + filename;
                Process[] localByName = Process.GetProcessesByName("WinWord");
                if (localByName.Length > 0)
                {
                    foreach (Process p in localByName)
                    {
                        if (p.MainWindowTitle.ToString().StartsWith(filename))
                        {
                            p.Kill();
                            break;
                        }
                    }
                }

                file = sFile + ".doc";
                path = @"\Template\FileSinhVien\" + sFile + ".doc";
                string Mau1 = Application.StartupPath.ToString() + @"\Template\FileSinhVien\" + sFile + ".doc";

                string sServerPath = Application.StartupPath + @"Template\FileSinhVien\" + sFile + ".doc";
                //clsRun.CheckVersionReports(sServerPath, Mau1);

                AttachFile(path, file);

                ReplaceHoSo(dt, path, sByte);

            }
            catch (Exception ex)
            {
                Process[] localByName = Process.GetProcessesByName("WinWord");
                if (localByName.Length > 0)
                {
                    foreach (Process p in localByName)
                    {
                        if (p.MainWindowTitle.ToString().StartsWith(filename))
                        {
                            p.Kill();
                            break;
                        }
                    }
                }
                XtraMessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ReplaceHoSo(DataTable DT, string path, byte[] sby)
        {
            object missing = System.Reflection.Missing.Value;
            object oFalse = false;
            object oTrue = true;
            object replaceAll = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll;
            object oWrap = Microsoft.Office.Interop.Word.WdFindWrap.wdFindContinue;
            object filename = path;
            Microsoft.Office.Interop.Word.Application wApp = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document word = new Microsoft.Office.Interop.Word.Document();

            try
            {
                {
                    word = wApp.Documents.Open(ref filename, ref
						missing, ref oFalse, ref missing,
                        ref missing, ref missing, ref missing, ref missing, ref
						missing, ref missing, ref missing, ref oTrue);//,

                    wApp.Visible = true;
                    Microsoft.Office.Interop.Word.Selection selection = wApp.Selection;

                    object MatchWholeWord = true;
                    object findText = "";
                    object oReplace = "";
                    foreach (DataColumn dc in DT.Columns)
                    {
                        findText = "@" + dc.ColumnName;
                        string sValue = "";
                        wApp.Selection.Find.Replacement.ClearFormatting(); // Error: System.StackOverflowException
                        wApp.Selection.Find.MatchWholeWord = true;

                        if (dc.DataType == Type.GetType("System.Decimal") || dc.DataType == Type.GetType("System.Double"))
                        {
                            string sChuoi = Convert.ToDecimal(DT.Rows[0][dc.ColumnName]).ToString("N");
                            string sTam = sChuoi.Substring(sChuoi.Length - 2);
                            if (Convert.ToInt32(sTam) == 0)
                                sValue = Convert.ToDecimal(DT.Rows[0][dc.ColumnName]).ToString("N00");
                            else
                                sValue = sChuoi;
                        }
                        else if (dc.DataType == Type.GetType("System.DateTime"))
                            sValue = "1"; //DateToString(Convert.ToString(DT.Rows[0][dc.ColumnName]));
                        else
                        {
                            if (dc.ColumnName == "StudentName")
                            {
                                sValue = Convert.ToString(DT.Rows[0][dc.ColumnName]).ToUpper();
                            }
                            else
                            {
                                sValue = Convert.ToString(DT.Rows[0][dc.ColumnName]);
                            }

                        }
                        oReplace = sValue;

                        selection.Find.Execute(ref findText, ref oFalse, ref MatchWholeWord, ref oFalse,
                            ref oFalse, ref oFalse, ref oTrue, ref oWrap, ref oFalse, ref oReplace,
                            ref replaceAll, ref oFalse, ref oFalse, ref oFalse, ref oFalse);
                    }
                    if (sby.Length > 0)
                    {
                        sByte = sby;
                        sPath = path;
                        sFileName = path.Substring(path.LastIndexOf('\\'));
                        sFileName = sFileName.Replace("\\", "");

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void AttachFile(string sPath, string sFile/*, byte[] arrFile*/)
        {
            try
            {
                sPath = System.Windows.Forms.Application.StartupPath + @"\Template\FileSinhVien\";
                //if (arrFile.Length != 0)
                {
                    if (!Directory.Exists(sPath))
                    {
                        Directory.CreateDirectory(sPath);
                    }
                    sPath += sFile;
                    path = sPath;

                }
            }
            catch
            {
                throw;
            }
        }
        private void mnuTrungTuyen2_Click(object sender, EventArgs e)
        {
            string strMau = "CaoDang";
           
            switch (uPeriod.CollectionType)
            {
                case Global.StudentCollectionType.SoCap:
                    strMau = "SoCap";
                    break;
                case Global.StudentCollectionType.TrungCap25:
                    strMau = "TrungCap";
                    break;
                case Global.StudentCollectionType.TrungCap35:
                    strMau = "TrungCap3";
                    break;
                case Global.StudentCollectionType.CaoDang:
                    strMau = "CaoDang";
                    break;
                case Global.StudentCollectionType.LienThong:
                    strMau = "LienThong";
                    break;
            }

            // print Sinh vien
            DataTable dtbStudentCollection = null;
            DataTable dtbData1 = null;
            
       
            DataTable dtbData = (gvData.DataSource as DataView).Table;

            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData, "Report/StudentCollection/TS_DSTrungTuyen2_" + strMau + ".repx", false);
            //Tinh tong ho so nop trong dot
            SIM_StudentCollection obj = new SIM_StudentCollection();
            ISIM_SpecialBranchDAO obj1 = new SIM_SpecialBranchDAO();
            dtbData1 = obj1.Search();
            dtbData1.Columns.Add("NV1", typeof(double));
            dtbData1.Columns.Add("NV2", typeof(double));
            dtbData1.Columns.Add("NV3", typeof(double));
            dtbStudentCollection = (gvData.DataSource as DataView).Table;

            if (dtbStudentCollection != null)
            {
                foreach (DataRow drw in dtbData1.Rows)
                {
                    int iSpec1; int iSpec2; int iSpec3;
                    iSpec1 = 0; iSpec2 = 0; iSpec3 = 0;
                    foreach (DataRow drw2 in dtbStudentCollection.Rows)
                    {
                        if (drw2["SpecialBranchID"].ToString() == drw["SpecialBranchID"].ToString())
                            iSpec1 += 1;
                        if (drw2["SpecialBranchID2"].ToString() == drw["SpecialBranchID"].ToString())
                            iSpec2 += 1;
                        if (drw2["SpecialBranchID3"].ToString() == drw["SpecialBranchID"].ToString())
                            iSpec3 += 1;

                    }
                    drw["NV1"] = iSpec1;
                    drw["NV2"] = iSpec2;
                    drw["NV3"] = iSpec3;
                }
                if (uPeriod.TrainingLevelIDEditValue.ToString() == "2" || uPeriod.TrainingLevelIDEditValue.ToString() == "3")
                    dtbData1.DefaultView.RowFilter = "Isnull(LearningLevel,'')=2";
                else if (uPeriod.TrainingLevelIDEditValue.ToString() == "3" || uPeriod.TrainingLevelIDEditValue.ToString() == "1")
                    dtbData1.DefaultView.RowFilter = "Isnull(LearningLevel,'')=3";
                else
                    dtbData1.DefaultView.RowFilter = "Isnull(LearningLevel,'')=4";
                dtbData1 = dtbData1.DefaultView.ToTable();
                //Danh sách môn theo tham số tùy đặt tên mà gán lại
                int i = 1;
                foreach (DataRow drw in dtbData1.Rows)
                {
                    frm.SetParameter("pSpecialBranch" + i.ToString(), drw["SpecialBranchName"].ToString());
                    frm.SetParameter("pSpecialBranchShortName" + i.ToString(), drw["SpecialBranchShortName"].ToString());
                    frm.SetParameter("pNV1" + i.ToString(), drw["NV1"].ToString());
                    frm.SetParameter("pNV2" + i.ToString(), drw["NV2"].ToString());
                    frm.SetParameter("pNV3" + i.ToString(), drw["NV3"].ToString());
                    i++;
                }
            }
            frm.Show();
        }

        private void mnuItemSelect_Click(object sender, EventArgs e)
        {
            gvData.CheckSelected();
        }

        private void mnuItemUnSelect_Click(object sender, EventArgs e)
        {
            gvData.UnCheckSelected();
        }

        private void mnuPrint_DSTrungTuyen_Click(object sender, EventArgs e)
        {
            DataTable dtbData = (gvData.DataSource as DataView).Table;

            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData, "Report/StudentCollection/TS_DSTrungTuyen.repx", false);
            frm.SetParameter("pTrainingLevel",uPeriod.CourseTypeLevelEditor.TrainingLevelIName.ToUpper());
            frm.SetParameter("pPeriod",uPeriod.StudentCollectionPeriodName.ToUpper());
            frm.SetParameter("pLearningLevel", uPeriod.CourseTypeLevelEditor.TrainingTypeName.ToUpper());
            frm.SetParameter("pCourse", uPeriod.CourseTypeLevelEditor.CourseName.ToUpper());
            frm.Show();
        }

        private void mnuGiayXacNhan_Click(object sender, EventArgs e)
        {
            if (uSpecialBranch.SpecialBranchEditValue == null)
            {
                MessageManager.Info("Bạn phải chọn nghề trước khi in!");
                return;
            }

            DataTable dtbData2 = dtbData.Copy();

            dtbData2.DefaultView.RowFilter = "Result > 0 and IsSelected = 1";
            dtbData2 = dtbData2.DefaultView.ToTable();
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData2, "Report/StudentCollection/TS_GiayXacNhan.repx", false);

            frm.Show();
        }

        private void btn_NhapHoc_Word_Click(object sender, EventArgs e)
        {

            // Áp dụng bộ lọc
            DataTable dtbData2 = dtbData.Copy();
            dtbData2.DefaultView.RowFilter = "IsSelected = 1";

            DataTable filteredData = dtbData2.DefaultView.ToTable();

            if (filteredData.Rows.Count > 0)
            {
                foreach (DataRow row in filteredData.Rows)
                {
                    Aspose.Words.Document reportStudent = new Aspose.Words.Document(System.Windows.Forms.Application.StartupPath + @"\Template\FileSinhVien\Mau_GiayNhapHoc.doc");

                    // Truyền dữ liệu vào file template
                    reportStudent.MailMerge.Execute(new[] { "StudentName" }, new[] { row["StudentName"].ToString() });
                    reportStudent.MailMerge.Execute(new[] { "NS" }, new[] { row["BirthDateText"].ToString() });
                    reportStudent.MailMerge.Execute(new[] { "GenderText" }, new[] { row["GenderText"].ToString() });


                    reportStudent.MailMerge.Execute(new[] { "Coursename" }, new[] { row["Coursename"].ToString() });

                    reportStudent.MailMerge.Execute(new[] { "TrainingLevelName" }, new[] { row["TrainingLevelName"].ToString() });
                      reportStudent.MailMerge.Execute(new[] { "TrainingLevelName_UP" }, new[] { row["TrainingLevelName"].ToString().ToUpper()});

                    reportStudent.MailMerge.Execute(new[] { "Liveaddress" }, new[] { row["Liveaddress"].ToString() });
                    reportStudent.MailMerge.Execute(new[] { "SpecialBranchName" }, new[] { row["SpecialBranchName"].ToString() });


                    reportStudent.MailMerge.Execute(new[] { "Money_HP" }, new[] { row["Money_HP"].ToString() });


                    reportStudent.MailMerge.Execute(new[] { "Tiendongphuc" }, new[] { row["Tiendongphuc"].ToString() });
               


                    reportStudent.MailMerge.Execute(new[] { "DAY" }, new[] { DateTime.Now.ToString("dd") });
                    reportStudent.MailMerge.Execute(new[] { "MONTH" }, new[] { DateTime.Now.Month.ToString() });
                    reportStudent.MailMerge.Execute(new[] { "YEAR" }, new[] { DateTime.Now.Year.ToString() });


                    // Đường dẫn lưu tệp cho từng sinh viên
                    string savePath = System.Windows.Forms.Application.StartupPath
                      + @"\Template\FileSinhVien\XN_SinhVien\"
                      + row["StudentCollectionID"].ToString()
                      + "_GiayNhapHoc_"
                      + DateTime.Now.ToString("yyyyMMdd_HHmmss")
                      + ".doc";
                    SaveAndOpenFile(savePath, reportStudent);
                }
            }
            else
            {
                MessageBox.Show("Không có sinh viên nào được chọn để in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void SaveAndOpenFile(string filePath, Aspose.Words.Document document)
        {
            document.Save(filePath);
            if (File.Exists(filePath))
            {
                System.Diagnostics.Process.Start(filePath);
            }
            else
            {
                MessageBox.Show("Không thể mở tệp đã lưu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}