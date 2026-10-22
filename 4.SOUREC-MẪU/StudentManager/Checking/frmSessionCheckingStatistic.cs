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
    public partial class frmSessionCheckingStatistic : FormBase, IForm
    {
        #region Consts

       
        public const string PERMISSION_VIEW = "SIM_DateCheckingStatistic_View";
        #endregion
        
        #region Variables
         
        bool bolIsEditing = false; // dang edit hay khong
       // SIM_YearDateCheckingStatistic itemStudentEditing = new SIM_YearDateCheckingStatistic(); // record đang edit

        #endregion

        #region IForm Members

        private static frmSessionCheckingStatistic _instance = null;

        public static frmSessionCheckingStatistic Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmSessionCheckingStatistic();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmSessionCheckingStatistic()
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

        DataTable dtbData = null;
        
        public void LoadData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadData));
            else
            {
                SIM_SubjectMark objSubjectMark = new SIM_SubjectMark();
                dtbData = objSubjectMark.ConsiderCouncil("@ClassID", uClass.ClassIDEditValue,"@YearID",uYearSemester.YearIDEditValue,"@Semester",uYearSemester.SemesterEditValue
                    ,"@FromDate",dtmFromDate.EditValueDateTime,"@ToDate",dtmToDate.EditValueDateTime);
                FillData();
                if (dtbData != null)
                {
                    gcData.DataSource = dtbData;
                   
                    // set order
                    gvData.SetOrder("Order");
                    mnuItemExportToExcel.Enabled = dtbData.Rows.Count > 0;

                }
                else
                {
                    //ErrorManager.Error(obj.ErrorException);
                    ErrorManager.Error("Việc lấy thông tin bị lỗi!");
                }
            }
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

        #region Support Functions

        private void CheckPermission()
        {
            // Kiểm tra quyền
           
        }   
        
        #endregion

        #region Form Actions

        private void frmSessionCheckingStatistic_Load(object sender, EventArgs e)
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
                new Thread(LoadData).Start();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuItemExportToExcel_Click(object sender, EventArgs e)
        {
            gvData.QuickExportToExcel();
        }
        
        private void Print_HocTap(string reportFile)
        {
            // print Sinh vien
            string strReport = reportFile;
            DataTable dtbData = (gvData.DataSource as DataView).Table;
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData, strReport, false);

            // Set xep loai tot nghiep
            int iTB = 0; int iTBKha = 0; int iKha = 0; int iTot = 0; int iXuatSac = 0; int iSV = 0; int iYeu = 0; 
            for (int j = 0; j < dtbData.Rows.Count; j++)
            {
                iSV += 1;

                if (Convert.ToString(dtbData.Rows[j]["LearningLevel"]) == "Yếu" || Convert.ToString(dtbData.Rows[j]["LearningLevel"]) == "Kém")
                        iYeu += 1;
                else if (Convert.ToString(dtbData.Rows[j]["LearningLevel"]) == "Trung bình")
                        iTB += 1;
                else if (Convert.ToString(dtbData.Rows[j]["LearningLevel"]) == "TB khá")
                        iTBKha += 1;
                else if (Convert.ToString(dtbData.Rows[j]["LearningLevel"]) == "Khá")
                        iKha += 1;
                else if (Convert.ToString(dtbData.Rows[j]["LearningLevel"]) == "Giỏi")
                        iTot += 1;
                else if (Convert.ToString(dtbData.Rows[j]["LearningLevel"]) == "Xuất sắc")
                        iXuatSac += 1;
            }
            // truyen tham so theo ý riêng
            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);
            frm.SetParameter("pTrainingLevel", uClass.TrainingLevelName);
            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pScience", uClass.ScienceName);
            frm.SetParameter("pClass", uClass.ClassName);
            frm.SetParameter("pYearID", uYearSemester.YearEditValueText);
            frm.SetParameter("pSemester", uYearSemester.SemesterEditValue);
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
        
        private void mnuPrintBangDiem_TongKet_Click(object sender, EventArgs e)
        {
            Print_HocTap("Report/StudentManager/Ethic/Student_HocTap_HocKy.repx");
        }
        
        private void Print_RenLuyen(string reportFile)
        {
            // print Sinh vien
            string strReport = reportFile;
            DataTable dtbData = (gvData.DataSource as DataView).Table;
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData, strReport, false);

            // Set xep loai tot nghiep
            int iTB = 0; int iTBKha = 0; int iKha = 0; int iTot = 0; int iXuatSac = 0; int iSV = 0; int iYeu = 0;
            for (int j = 0; j < dtbData.Rows.Count; j++)
            {
                iSV += 1;

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
            // truyen tham so theo ý riêng
            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);
            frm.SetParameter("pTrainingLevel", uClass.TrainingLevelName);
            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pScience", uClass.ScienceName);
            frm.SetParameter("pClass", uClass.ClassName);
            frm.SetParameter("pYearID", uYearSemester.YearEditValueText);
            frm.SetParameter("pSemester", uYearSemester.SemesterEditValue);
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

        private void mnuPrint_TongKetDiem_GiaoVien_Click(object sender, EventArgs e)
        {
            Print_RenLuyen("Report/StudentManager/Ethic/Student_HocTapGiaoVien.repx");
        }

        private void mnuPrint_TKDMau_Click(object sender, EventArgs e)
        {
            Print_HocTap("Report/StudentManager/Ethic/Student_HocTapGiaoVien_Mau.repx");
        }

        private void mnuPrint_BienBan1_Click(object sender, EventArgs e)
        {
            Print_RenLuyen("Report/StudentManager/Ethic/Student_HocTap_HopLop1.repx");
        }

        private void mnuPrint_BienBan2_Click(object sender, EventArgs e)
        {
            Print_RenLuyen("Report/StudentManager/Ethic/Student_HocTap_HopLop2.repx");
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
      

        
        


    }
}