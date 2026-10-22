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
using System.Collections;
namespace StudentManager.Learning
{
    public partial class frmExamStudentList : FormBase, IForm
    {
        #region Consts

        public const string PERMISSION_EDIT = "SIM_ExamStudentList_Edit";
        public const string PERMISSION_VIEW = "SIM_ExamStudentList_View";

        #endregion

        #region Variables

        DataTable dtbData = null;
        SIM_Class_Subject objClassSubject = null;
        DataTable dtbClassSubject = null;

        #endregion

        #region IForm Members

        private static frmExamStudentList _instance = null;

        public static frmExamStudentList Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmExamStudentList();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmExamStudentList()
        {
            InitializeComponent();
        }

        #region Support Functions

        private void CheckPermission()
        {
            // Kiểm tra quyền
            //gvData.OptionsBehavior.Editable = UserSession.HasPermission(PERMISSION_VIEW);
            uClass.ScienceFilter = UserSession.GetScienceFilter(PERMISSION_VIEW); // quyền xem trên khoa nào            
            string str = UserSession.GetSubjectGroupFilter(PERMISSION_VIEW);
            if (str != "")
                str = "( " + str + " ) Or TeachingBy ='" + UserSession.Username + "'";

            uClass.ClassSubjectFilter= str; // quyền xem trên bộ môn nào
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
                    SIM_SubjectMark obj = new SIM_SubjectMark();

                    int? intTestOrder = 1;
                    if (rdoTestOrder2.Checked == true)
                        intTestOrder = 2;
                    else if (rdoTestOrder3.Checked == true)
                        intTestOrder = 3;

                    dtbData = obj.GetDataTable("SIM_SubjectMark_SearchForEdit", "@ClassSubjectID", uClass.ClassSubjectIDEditValue, "@TestOrder", intTestOrder);

                    gcData.DataSource = dtbData;
                    SYS_GridColumnService.InitGridColumn(gvData, "SIM_ExamStudentList");
                    btnSave.Enabled = mnuItemSave.Enabled = false;

                    // set order
                    gvData.SetOrder("Order");
                    ModifyGrid();

                    mnuItemExportToExcel.Enabled = mnuItemExportTemplateExcel.Enabled = mnuItemPrint.Enabled = mnuItemPrintForScan.Enabled = mnuItemPrint2.Enabled = dtbData.Rows.Count > 0;

                    // có quyền cập nhật của khoa này của bộ môn này không                                        
                    SIM_Class_Subject objClassSubject = new SIM_Class_Subject().Get(uClass.ClassSubjectIDEditValue);
                    string strSubjectGroupID = new SIM_Subject().Get(objClassSubject.SubjectID).SubjectGroupID;
                    btnReview.Enabled = gvData.OptionsBehavior.Editable = dtbData.Rows.Count > 0
                                            && (UserSession.HasPermission(PERMISSION_EDIT, uClass.ScienceIDEditValue, strSubjectGroupID) // có quyền trên khoa, bộ môn
                                                || objClassSubject.TeachingBy == UserSession.Username);  // hoặc là giảng viên dạy môn đó                                                           

                    chkIsAllowExam_CheckedChanged(null, null);

                }
                catch (Exception objEx)
                {
                    ErrorManager.Error(objEx);
                    SYS_ErrorLogService.Write(Enums.ActionType.View, "frmExamStudentList->LoadData", objEx, 0);
                }
            }
        }

        
        private void ModifyGrid()
        {
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gvData.Columns)
            {

                switch (col.FieldName)
                {
                }

            }
        }

        private void CheckRow(bool isChecked)
        {
            foreach (int i in gvData.GetSelectedRows())
            {
                DataRow drw = gvData.GetDataRow(i);
                drw["AllowExam"] = isChecked;
                drw["IsEdit"] = 1;                
            }
            btnSave.Enabled = mnuItemSave.Enabled = true;
        }

        #endregion

        #region Form Actions

        private void frmExamStudentList_Load(object sender, EventArgs e)
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

            if (uClass.ClassIDEditValue == null)
            {
                MessageManager.Warning("Bạn phải chọn lớp học!");
                uClass.Focus();
                return false;
            }

            if (uClass.ClassSubjectIDEditValue == null)
            {
                MessageManager.Warning("Bạn phải chọn môn học!");
                uClass.Focus();
                return false;
            }

            return true;
        }

   
        private void btnReview_Click(object sender, EventArgs e)
        {
            #region Cách cũ

            //double dtestAver = 0;
            //int intper = 0;
            //// Kiem tra quy che de dua dieu kien vao danh sach du thi
            //switch (uClass.RegulationID)
            //{
            //    case 14: // cao đẳng, tc nghề
            //        dtestAver = 5;
            //        intper = 20;
            //        break;

            //    case 22: // trung cấp chuyên nghiệp không tính trung bình kiểm tra vô điều kiện
            //        dtestAver = 3;
            //        intper = 20;
            //        break;

            //    case 40: // trung cấp chuyên nghiệp không tính trung bình kiểm tra vô điều kiện
            //        dtestAver = -1;
            //        intper = 20;
            //        break;

            //    case 46: // trung cấp vừa học vừa làm
            //        dtestAver = -1;
            //        intper = 20;
            //        break;

            //    case 9: // trung cấp, cao đẳng chuyên nghiệp (TBKT >=5, đi học 70%)
            //        dtestAver = 5;
            //        intper = 30;
            //        break;
            //    case 99: // trung cấp, cao đẳng chuyên nghiệp TÍN CHỈ (TBKT >=5, đi học 70%)
            //        dtestAver = 5;
            //        intper = 30;
            //        break;               
            //    default: // mặc định khi là tín chỉ thì giống trung cấp, cao đẳng mới
            //        dtestAver = 5;
            //        intper = 30;
            //        break;
            //}

            //// neu la diem chuyen hoac cung chinh la ngan hang, ko co xet diem tbkt
            //if (objClassSubject.IsOldData)
            //    dtestAver = 0;
            
            //foreach (DataRow drw in dtbData.Rows)
            //{
            //    if (drw["TestAverage"].ToString()!="" && Convert.ToDouble(drw["TestAverage"]) >= dtestAver && Convert.ToInt32(drw["PercentOff"]) <= intper && !Convert.ToBoolean(drw["NotAllowExam"]))
            //    {
            //        drw["AllowExam"] = true;
            //        drw["AllowExamDescription"] = drw["Receivables"]; // nợ học phí hay ko
                    
            //    }
            //    else
            //    {
            //        drw["AllowExam"] = false;
            //        if (Convert.ToInt32(drw["PercentOff"]) > intper)
            //            drw["AllowExamDescription"] = "Cấm thi ĐD";
            //        else
            //            drw["AllowExamDescription"] = "Cấm thi QT";
            //    }
            //    drw["IsEdit"] = 1;
            //}           

            #endregion

            foreach (DataRow drw in dtbData.Rows)
            {
                if (drw["ReviewExam"].ToString() == "x") // được dự thi
                    drw["AllowExam"] = true;
                else
                    drw["AllowExam"] = false;

                if (drw["RemainMoneyText"].ToString() != "")
                    drw["AllowExamDescription"] = drw["RemainMoneyText"];
                else
                    drw["AllowExamDescription"] = drw["ReviewExam"];

                drw["IsEdit"] = 1;
            }

            btnSave.Enabled = mnuItemSave.Enabled = true;            
        }

      
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageManager.Confirm("Bạn có thực sự muốn lưu những thay đổi dữ liệu này?") == DialogResult.Yes)
            {
                if (SaveData())
                {
                    //MessageManager.Info("Đã cập nhật dữ liệu thành công!");
                    btnSave.Enabled = mnuItemSave.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Save dữ liệu ở tab edit
        /// </summary>
        private bool SaveData()
        {
            int intOrderTest = 1;
            if (rdoTestOrder2.Checked == true)
                intOrderTest = 2;
            else if (rdoTestOrder3.Checked == true)
                intOrderTest = 3;

            SIM_SubjectMark item = new SIM_SubjectMark();
            item.BeginTransaction();

            // reset số thứ tự trước
            //item.ClassSubjectID = objClassSubject.ClassSubjectID;
            //item.UpdatedUser = UserSession.Username;
            //item.ResetOrderIndexExam(intOrderTest);

            int intOrderIndex = 1;
            for (int i = 0; i < dtbData.Rows.Count; i++)
            {
                DataRow drw = dtbData.Rows[i];

                if (Convert.ToBoolean(drw["IsEdit"]))
                {
                    item.SubjectMarkID = Convert.ToInt64(drw["SubjectMarkID"]);
                    item.AllowExam = Convert.ToBoolean(drw["AllowExam"]);
                    item.AllowExamDescription = drw["AllowExamDescription"].ToString(); // chỉ lưu ghi chú nếu có nợ học phí                    
                    if (item.AllowExam)
                    {
                        item.OrderIndexExam = intOrderIndex++;
                        //item.TestDay = dtmTestDay.EditValueDateTime.Value.Date;
                    }
                    else
                    {
                        item.OrderIndexExam = -1;
                        //item.TestDay = null;
                    }

                    if (!item.UpdateAllowExam(intOrderTest))
                    {
                        ErrorManager.Error("Cập nhật không thành công!");
                        return false;
                    }
                }
            }

            item.CommitTransaction();
            return true;
        }

        
        private void mnuItemCheck_Click(object sender, EventArgs e)
        {
            CheckRow(true);
        }

        private void mnuUnCheck_Click(object sender, EventArgs e)
        {
            CheckRow(false);
        }

        private void gvData_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataRow drw = gvData.GetFocusedDataRow();
            if (drw != null)
                drw["IsEdit"] = 1;
            btnSave.Enabled = mnuItemSave.Enabled = true;
        }

        private void mnuItemExportTemplateExcel_Click(object sender, EventArgs e)
        {
            Hashtable hstReplaceValues = new Hashtable();
            hstReplaceValues.Add("{Ngành}", uClass.SpecialBranchName);
            hstReplaceValues.Add("{Lớp}", uClass.ClassIDEditValue);
            hstReplaceValues.Add("{Môn}", uClass.ClassSubjectName);
            hstReplaceValues.Add("{Niên}", uClass.UYearSemester.YearEditValueText);
            hstReplaceValues.Add("{Kì}", uClass.Semester.ToString());
            hstReplaceValues.Add("{Lần}", rdoTestOrder1.Checked ? "1" : "2");

            if (!gvData.ExportTemplateExcel("Mã SV", hstReplaceValues, Application.StartupPath + "/Report/StudentManager/Learning/DanhSachDuThi.xls"))
                MessageManager.Warning("File mẫu chưa đúng định dạng hoặc chưa có cột ''Mã SV''!");
        }

        private void chkIsAllowExam_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsAllowExam.Checked)
                gvData.RowFilter = "AllowExam = 1";
            else
                gvData.RowFilter = "";            
        }

        private void mnuItemExportToExcel_Click(object sender, EventArgs e)
        {
            gvData.QuickExportToExcel();
        }

        private void mnuItemPrint2_Click(object sender, EventArgs e)
        {
            // In danh sách sinh viên không đủ tư cách dự thi
            DataTable dtbData2 = (gvData.DataSource as DataView).Table.Copy();
            dtbData2.DefaultView.RowFilter = "Isnull(AllowExam,0) =0 ";
            dtbData2 = dtbData2.DefaultView.ToTable();
            string strreport = "";
            switch (uClass.RegulationID)
            {
                case 14: // cao đẳng, tc nghề
                    strreport = "Report/StudentManager/Learning/Leaning_DSCamThi_QC14.repx";
                    break;
                case 22: // trung cấp chuyên nghiệp
                case 40:
                case 46:
                    strreport = "Report/StudentManager/Learning/Leaning_DSCamThi_QC22.repx";
                    break;
                case 4:
                case 9: // trung cấp, cao đẳng chuyên nghiệp 2017
                    strreport = "Report/StudentManager/Learning/Leaning_DSCamThi_QC09.repx";
                    break;
                default: // trung cấp, cao đẳng chuyên nghiệp 2017
                    strreport = "Report/StudentManager/Learning/Leaning_DSCamThi_QC09.repx";
                    break;

            }
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData2, strreport, false);
            if (rdoTestOrder1.Checked == true)
                frm.SetParameter("pOrderTest", 1);
            else
                frm.SetParameter("pOrderTest", 2);
            frm.Show();
        }

        private void mnuItemPrintForScan_Click(object sender, EventArgs e)
        {
            //if (btnSave.Enabled)
            //    btnSave_Click(sender, e);
            //if (btnSave.Enabled)
            //    return; // chưa lưu được thì thôi ko in

            //// print danh sách sinh viên dự thi có thể bao gồm cả sv không đủ điều kiện
            //long? lngScanMarkID = SaveForScan(uClass.ClassSubjectIDEditValue.Value, rdoTestOrder1.Checked ? 1 : 2);
            //if (lngScanMarkID != null)
            //{
            //    DataTable dtbData2 = dtbData.DefaultView.ToTable();
            //    string strreport = "";
            //    switch (uClass.RegulationID)
            //    {
            //        case 14: // cao đẳng, tc nghề
            //            strreport = "Report/StudentManager/Learning/Leaning_DSThi_QC14_Scan.repx";
            //            break;
            //        case 22:
            //        case 46: // trung cấp vừa học vừa làm
            //        case 40: // trung cấp chuyên nghiệp
            //            strreport = "Report/StudentManager/Learning/Leaning_DSThi_QC22_Scan.repx";
            //            break;
            //        case 9: // trung cấp chuyên nghiệp
            //            strreport = "Report/StudentManager/Learning/Leaning_DSThi_QC09_Scan.repx";
            //            break;
            //        default:
            //            strreport = "Report/StudentManager/Learning/Leaning_DSThi_QC09_Scan.repx";
            //            break;
            //    }

            //    SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData2, strreport, false);
            //    frm.SetParameter("par_Recognize", lngScanMarkID); // mã môn học lớp
            //    frm.SetParameter("par_OrderTest", rdoTestOrder1.Checked ? 1 : 2); // lần thi
            //    frm.SetParameter("par_Class", uClass.ClassName); // tên lớp
            //    frm.SetParameter("par_Semester", uClass.Semester);
            //    frm.SetParameter("par_Year", uClass.UYearSemester.YearEditValueText);
            //    frm.SetParameter("par_PrintDate", DateTime.Now.ToString("dd / MM / yyyy"));
            //    frm.Show();
            //}
        }

        private void mnuItemPrint_Click(object sender, EventArgs e)
        {
            //if (btnSave.Enabled)            
            //    btnSave_Click(sender, e);
            //if (btnSave.Enabled)
            //    return; // chưa save dc thì thôi

            // print danh sách sinh viên dự thi
            DataTable dtbData2 = (gvData.DataSource as DataView).Table.Copy();
            dtbData2.DefaultView.RowFilter = "Isnull(AllowExam,0) =1 ";
            dtbData2 = dtbData2.DefaultView.ToTable();
          
            string strreport = "";

            if (rdoTestOrder1.Checked)
                strreport = "Report/StudentManager/Learning/Leaning_DSThi_QC14.repx";
            else
                strreport = "Report/StudentManager/Learning/Leaning_DSThi_QC14_Lan2.repx";

            #region tam thoi khong dung
            //switch (uClass.RegulationID)
            //{
            //    case 14: // cao đẳng, tc nghề
            //        if(intTestOrder==1)
            //            strreport = "Report/StudentManager/Learning/Leaning_DSThi_QC14.repx";
            //        else
            //            strreport = "Report/StudentManager/Learning/Leaning_DSThi_QC14_Lan2.repx";
            //        break;
            //    case 22: // trung cấp chuyên nghiệp
            //    case 40:
            //    case 46:
            //        strreport = "Report/StudentManager/Learning/Leaning_DSThi_QC22.repx";
            //        break;
                
            //    case 25:
            //        strreport = "Report/StudentManager/Learning/Leaning_DSThi_QC25.repx";
            //        break;
            //    case 43:
            //        strreport = "Report/StudentManager/Learning/Leaning_DSThi_QC43.repx";
            //        break;
            //    default:
            //        strreport = "Report/StudentManager/Learning/Leaning_DSThi_QC22.repx";
            //        break;
            //}
            #endregion

            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData2, strreport, false);
            frm.SetParameter("par_Recognize", uClass.ClassSubjectIDEditValue);
            frm.SetParameter("pClass", uClass.ClassName);
            frm.Show();
        }

      

        #endregion

        private void uClass_ClassSubjectChanged(object sender, EventArgs arg)
        {
            if (uClass.ClassSubjectIDEditValue != null)
            {
                btnSearch_Click(null, null);
                objClassSubject = new SIM_Class_Subject().Get(uClass.ClassSubjectIDEditValue);
            }
            else
            {
                objClassSubject = null;
                dtbData = null;
                mnuItemPrint.Enabled = mnuItemPrintForScan.Enabled = mnuItemPrint2.Enabled = btnReview.Enabled = btnSave.Enabled = mnuItemExportToExcel.Enabled = false;
            }
        }

     
    }
}
