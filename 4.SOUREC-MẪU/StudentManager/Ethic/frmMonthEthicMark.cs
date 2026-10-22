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
    public partial class frmMonthEthicMark : FormBase, IForm
    {
        #region Consts

        public const string PERMISSION_EDIT = "SIM_MonthEthicMark_Edit";
        public const string PERMISSION_VIEW = "SIM_MonthEthicMark_View";

        #endregion

        #region Variables

        private DataTable dtbData;
        private string strClassID = "";
        private int intYear = 0;
        private int intSemester = 0;
        private DateTime dtmMonth1;
        
        private Decimal iSV;
        private Decimal iXuatSac;
        private Decimal iTot;
        private Decimal iKha;
        private Decimal iTBKha;
        private Decimal iTB,iYeu;        
         
        #endregion

        #region IForm Members

        private static frmMonthEthicMark _instance = null;

        public static frmMonthEthicMark Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmMonthEthicMark();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion


        public frmMonthEthicMark()
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
            
             
             if (Convert.ToInt32( uYearSemester.SemesterEditValue) == 1)
                 dtmMonth1 = new DateTime(uYearSemester.YearIDEditValueInt32.Value, 9, 1);
             else
                 dtmMonth1 = new DateTime(uYearSemester.YearIDEditValueInt32.Value, 2, 1);
            SIM_MonthEthicMark obj =new SIM_MonthEthicMark();
             dtbData = obj.Search(
                             "@ClassID", uClass.ClassIDEditValue,"Semester",uYearSemester.SemesterEditValue,
                             "YearID",uYearSemester.YearIDEditValue,
                             "@FromDate",dtmFromDate.EditValueDateTime,"@ToDate",dtmToDate.EditValueDateTime,
                             "@Month", dtmMonth1.Month);                            

            if (dtbData != null)
            {
                FillData();
                gcData.DataSource = dtbData;

                // set order
                gvData.SetOrder("Order");

                //Nhớ lại giá trị khóa để save
                strClassID = uClass.ClassIDEditValue.ToString();
                intYear = uYearSemester.YearIDEditValueInt32.Value;
                intSemester = uYearSemester.SemesterEditValueInt32.Value;                               

                mnuItemSave.Enabled = btnSave.Enabled = false; // load lại thì không cần save 
                btnPrint.Enabled = mnuItemPrint.Enabled = mnuItemExportToExcel.Enabled = true;                
            }
            else
                ErrorManager.Error("Việc tải thông tin bị lỗi!");
        }

        private void FillData()
        {
            int intRegulationID = uClass.RegulationID.Value;

            // lẤY THÔNG TIN KỶ LUẬT
            DataTable dtbSanction;
            dtbSanction = new SIM_Sanction().Search(
                //"@SigningdateStart", dtmFromDate.EditValueDateTime, "@SigningdateEnd", dtmToDate.EditValueDateTime, 
                                                    "@ClassID", uClass.ClassIDEditValue,
                                                    "@IsNoShowExpiredSanction", chkIsNoShowExpiredSanction.Checked);

            foreach (DataRow drw in dtbData.Rows)
            {                
                String sSanction = "";

                DataRow[] rows = dtbSanction.Select("StudentID='" + drw["StudentID"].ToString() + "'");
                foreach (DataRow drw2 in rows) // mỗi môn chỉ xuất hiện 1 lần vì nó đã lấy lần cuối cùng trong bảng điểm
                {
                    sSanction += drw2["SanctionFormName"];
                    if (drw2["Signingdate"].ToString() != "")
                        sSanction += " ngày " + Convert.ToDateTime(drw2["Signingdate"]).ToString("dd/MM/yyyy");
                    break;
                }
                drw["discipline"] = sSanction;                
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
            if (!uYearSemester.IsValidData())
                return false;

            //if (dtmMonth.EditValueDateTime == null)
            //{
            //    MessageManager.Warning("Bạn phải chọn tháng!");
            //    dtmMonth.Focus();
            //    return false;
            //}
            //if (uYearSemester.SemesterEditValue.ToString() == "1")
            //{
            //    if (dtmMonth.EditValueDateTime.Value.Month != 9)
            //    {
            //        MessageManager.Warning("Bạn phải chọn tháng 9!");
            //        dtmMonth.Focus();
            //        return false;
            //    }
            //}
            //else
            //{
            //    if (dtmMonth.EditValueDateTime.Value.Month != 2)
            //    {
            //        MessageManager.Warning("Bạn phải chọn tháng 2!");
            //        dtmMonth.Focus();
            //        return false;
            //    }
            //}
            return true;
        }

        /// <summary>
        /// Save dữ liệu ở tab edit
        /// </summary>
        private bool SaveData()
        {
            SIM_MonthEthicMark obj = new SIM_MonthEthicMark();
            obj.BeginTransaction();
            foreach (DataRow drw in dtbData.Rows)
            {
                if (drw["IsEdit"].ToString() == "1")
                {

                    SIM_MonthEthicMark item = new SIM_MonthEthicMark();
                    item.IDB = obj.IDB;
                    if (item.Parse(drw))
                    {
                        if (item.Month == null)
                        {
                            item.Month = dtmMonth1;
                            item.YearID = intYear;
                            item.Semester = intSemester;
                            item.CreatedUser = UserSession.Username;

                            if (!item.Add())
                            {
                                ErrorManager.Error("Thêm điểm rèn luyện bị lỗi!");
                                return false;
                            }
                        }
                        else
                        {
                            item.UpdatedUser = UserSession.Username;
                            if (!item.Update())
                            {
                                ErrorManager.Error("Cập nhật điểm rèn luyện bị lỗi!");
                                return false;
                            }
                        }
                    }
                    else
                        ErrorManager.Error("Việc lấy dữ liệu để cập nhật bị lỗi!");
                }
            }
            obj.CommitTransaction();
            return true;
        }

        private void SummaryEthic(DataRow drw, string fieldMark, string fieldLevel)
        {
            SimsService.SIM_EthicMarkService.SummaryEthic(drw, fieldMark, fieldLevel, uClass.RegulationID);
        }

        private void SummaryEthic(DataRow drw)
        {
            SummaryEthic(drw, "StudentEthicMark", "StudentEthicLevel");
            SummaryEthic(drw, "TeacherEthicMark", "TeacherEthicLevel");
            SummaryEthic(drw, "ClassEthicMark", "ClassEthicLevel");            
            SummaryEthic(drw, "EthicMark", "EthicLevel");                       
            drw["IsEdit"] = 1;
        }       
        
        #endregion

        #region Form Actions

        private void frmYearEthicMark_Load(object sender, EventArgs e)
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
                LoadData();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageManager.Confirm("Bạn có thực sự muốn lưu những thay đổi dữ liệu này?") == DialogResult.Yes)
            {
                if (SaveData())
                {
                    //MessageManager.Info("Đã cập nhật dữ liệu thành công!");                    
                    LoadData();
                }
            }
        }        

        private void gvData_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataRow drw = gvData.GetFocusedDataRow();
            if (drw != null)
            {
                btnSave.Enabled = mnuItemSave.Enabled = true;
                SummaryEthic(drw);
                
            }
        }
        
        private void Print(string reportFile, int semester)
        {
            // print Sinh vien
            string strReport = reportFile;
            int St=semester;
            DataTable dtbData = (gvData.DataSource as DataView).Table;
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData, strReport, false);
           
            // Set xep loai tot nghiep
            iTB = 0; iTBKha = 0; iKha = 0; iTot = 0; iXuatSac = 0; iSV = 0;iYeu =0 ;
            for (int j = 0; j < dtbData.Rows.Count; j++)
            {
                iSV += 1;
                if (St == 0)
                {
                    if (Convert.ToString(dtbData.Rows[j]["EthicLevel"]) == "Yếu" || Convert.ToString(dtbData.Rows[j]["EthicLevel"]) == "Kém")
                        iYeu += 1;
                    else if (Convert.ToString(dtbData.Rows[j]["EthicLevel"]) == "Trung bình")
                        iTB += 1;
                    else if (Convert.ToString(dtbData.Rows[j]["EthicLevel"]) == "TB Khá")
                        iTBKha += 1;
                    else if (Convert.ToString(dtbData.Rows[j]["EthicLevel"]) == "Khá")
                        iKha += 1;
                    else if (Convert.ToString(dtbData.Rows[j]["EthicLevel"]) == "Tốt")
                        iTot += 1;
                    else if (Convert.ToString(dtbData.Rows[j]["EthicLevel"]) == "Xuất sắc")
                        iXuatSac += 1;
                }
                else if (St == 1)
                {
                    if (Convert.ToString(dtbData.Rows[j]["EthicLevel1"]) == "Yếu" || Convert.ToString(dtbData.Rows[j]["EthicLevel"]) == "Kém")
                        iYeu += 1;
                    else if (Convert.ToString(dtbData.Rows[j]["EthicLevel1"]) == "Trung bình")
                        iTB += 1;
                    else if (Convert.ToString(dtbData.Rows[j]["EthicLevel1"]) == "TB Khá")
                        iTBKha += 1;
                    else if (Convert.ToString(dtbData.Rows[j]["EthicLevel1"]) == "Khá")
                        iKha += 1;
                    else if (Convert.ToString(dtbData.Rows[j]["EthicLevel1"]) == "Tốt")
                        iTot += 1;
                    else if (Convert.ToString(dtbData.Rows[j]["EthicLevel1"]) == "Xuất sắc")
                        iXuatSac += 1;
                }
                else
                {
                    if (Convert.ToString(dtbData.Rows[j]["EthicLevel2"]) == "Yếu" || Convert.ToString(dtbData.Rows[j]["EthicLevel"]) == "Kém")
                        iYeu += 1;
                    else if (Convert.ToString(dtbData.Rows[j]["EthicLevel2"]) == "Trung bình")
                        iTB += 1;
                    else if (Convert.ToString(dtbData.Rows[j]["EthicLevel2"]) == "TB Khá")
                        iTBKha += 1;
                    else if (Convert.ToString(dtbData.Rows[j]["EthicLevel2"]) == "Khá")
                        iKha += 1;
                    else if (Convert.ToString(dtbData.Rows[j]["EthicLevel2"]) == "Tốt")
                        iTot += 1;
                    else if (Convert.ToString(dtbData.Rows[j]["EthicLevel2"]) == "Xuất sắc")
                        iXuatSac += 1;
                }
            }
            // truyen tham so theo ý riêng
            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);
            frm.SetParameter("pTrainingLevel", uClass.TrainingLevelName);
            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pScience", uClass.ScienceName);
            frm.SetParameter("pClass", uClass.ClassName);
            frm.SetParameter("pYearID", uYearSemester.YearEditValueText );
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
            frm.SetParameter("pYeu", iTB);
            frm.SetParameter("pTLYeu", iYeu * 100 / iSV);
            frm.SetParameter("pSV", iSV);

            frm.Show();
        }
        
        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print("Report/StudentManager/Ethic/Student_DiemRenLuyen_HopHoiDong.repx",0);
        }

        #endregion

        private void uYearSemester_Load(object sender, EventArgs e)
        {

        }

        private void mnuPrintMauXepHangToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mnuItemExportToExcel_Click(object sender, EventArgs e)
        {
            gvData.QuickExportToExcel();
        }

        private void gvData_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (e.Value == null || e.Value.ToString() == "")
                e.Value = DBNull.Value;
        }

    }
}