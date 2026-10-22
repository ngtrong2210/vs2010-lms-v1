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
    public partial class frmSummaryEthicMark : FormBase, IForm
    {
        #region Consts

        public const string PERMISSION_EDIT = "SIM_SummaryEthicMark_Edit";
        public const string PERMISSION_VIEW = "SIM_SummaryEthicMark_View";

        #endregion

        #region Variables

        private DataTable dtbData;
        private string strClassID = "";
        private int intYear = 0;
        private string strListIDDeleted = "";
        private Decimal iSV;
        private Decimal iXuatSac;
        private Decimal iTot;
        private Decimal iKha;
        private Decimal iTBKha,iKem;
        private Decimal iTB,iYeu;        
         
        #endregion

        #region IForm Members

        private static frmSummaryEthicMark _instance = null;

        public static frmSummaryEthicMark Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmSummaryEthicMark();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion


        public frmSummaryEthicMark()
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

            dtbData = new SIM_SummaryEthicMark().Search("@CourseID",uClass.CourseIDEditValue,
                             "@TrainingLevelID",uClass.TrainingLevelIDEditValue,
                             "@BranchID",uClass.BranchEditValue,
                            "@ClassID", uClass.ClassIDEditValue,
                            "@YearID", uYearSemester.YearIDEditValueInt32);

            if (dtbData != null)
            {
                gcData.DataSource = dtbData;

                //Nhớ lại giá trị khóa để save
                if (uClass.ClassIDEditValue ==null)
                    mnuItemSave.Enabled = btnSave.Enabled = false;
                else
                    strClassID = uClass.ClassIDEditValue.ToString();
                intYear = uYearSemester.YearIDEditValueInt32.Value;
                strListIDDeleted = "";

                mnuItemSave.Enabled = btnSave.Enabled = false; // load lại thì không cần save 
                mnuItemSummaryFromMonth.Enabled = btnSummaryFromMonth.Enabled = btnSummaryFromSemester.Enabled = dtbData.Rows.Count > 0 && UserSession.HasPermission(PERMISSION_EDIT);
            }
            else
                ErrorManager.Error("Việc tải thông tin bị lỗi!");
        }

        private void SummaryFromMonth()
        {
            SIM_MonthEthicMark obj = new SIM_MonthEthicMark();
            DataTable dtbMonth = obj.SearchSummary("@ClassID", strClassID, "@YearID", intYear);
            if (dtbMonth != null)
            {
                foreach (DataRow drw in dtbMonth.Rows)
                {
                    DataRow[] rows = dtbData.Select("StudentID='" + drw["StudentID"].ToString() + "'");
                    if (rows.Length > 0)
                    {
                        rows[0]["StudentEthicMark1"] = drw["StudentEthicMark1"];
                        rows[0]["StudentEthicMark2"] = drw["StudentEthicMark2"];

                        rows[0]["TeacherEthicMark1"] = drw["TeacherEthicMark1"];
                        rows[0]["TeacherEthicMark2"] = drw["TeacherEthicMark2"];

                        rows[0]["ClassEthicMark1"] = drw["ClassEthicMark1"];
                        rows[0]["ClassEthicMark2"] = drw["ClassEthicMark2"];
                        
                        rows[0]["EthicMark1"] = drw["EthicMark1"];
                        rows[0]["EthicMark2"] = drw["EthicMark2"];
                       
                        SummaryEthic(rows[0]);
                    }
                }
                MessageManager.Info("Đã tổng hợp hoàn tất!");
                btnSave.Enabled = mnuItemSave.Enabled = true;
            }
            else
                ErrorManager.Error("Việc tải thông tin bị lỗi!");
        }

        private void SummaryFromSemester()
        {
            SIM_SemesterEthicMark obj = new SIM_SemesterEthicMark();
            DataTable dtb= obj.GetDataTable("SIM_SemesterEthicMark_Summary","@ClassID", strClassID, "@YearID", intYear);
            if (dtb != null)
            {
                foreach (DataRow drw in dtb.Rows)
                {
                    DataRow[] rows = dtbData.Select("StudentID='" + drw["StudentID"].ToString() + "'");
                    if (rows.Length > 0)
                    {
                        rows[0]["EthicMark1"] = drw["EthicMark1"];
                        rows[0]["EthicMark2"] = drw["EthicMark2"];
                        SummaryEthic(rows[0]);
                    }
                }
                MessageManager.Info("Đã tổng hợp hoàn tất!");
                btnSave.Enabled = mnuItemSave.Enabled = true;
            }
            else
                ErrorManager.Error("Việc tải thông tin bị lỗi!");
        }


        #region Support Functions

        private void CheckPermission()
        {
            // Kiểm tra quyền
            gvData.OptionsBehavior.Editable = UserSession.HasPermission(PERMISSION_EDIT);
        }
         
        
        #endregion

        #region Form Actions

        private void frmYearEthicMark_Load(object sender, EventArgs e)
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
                LoadData();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageManager.Confirm("Bạn có thực sự muốn lưu những thay đổi dữ liệu này?") == DialogResult.Yes)
            {
                if (SaveData())
                {                                    
                    LoadData();
                }
            }
        }

        private bool IsValidData()
        {
           
            if (uClass.CourseIDEditValue == null)
            {
                MessageManager.Warning("Bạn phải chọn khóa học!");
                uClass.Focus();
                return false;
            }
            if (uClass.TrainingLevelIDEditValue == null)
            {
                MessageManager.Warning("Bạn phải chọn bậc đào tạo!");
                uClass.Focus();
                return false;
            }
            if (uYearSemester.YearIDEditValueInt32 < 1 || uYearSemester.YearIDEditValue==null)
            {
                MessageManager.Warning("Bạn phải chọn năm học!");
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
            SIM_SummaryEthicMark obj = new SIM_SummaryEthicMark();
            obj.BeginTransaction();
            foreach(DataRow drw in dtbData.Rows)
            {
                if (drw["IsEdit"].ToString() == "1")
                {

                    SIM_SummaryEthicMark item = new SIM_SummaryEthicMark();
                    item.IDB = obj.IDB;
                    if (item.Parse(drw))
                    {
                        if (item.YearID == null)
                        {
                            item.YearID = intYear;
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
     
        #region Tính điểm rèn luyện theo năm

        private void SummaryEthic(DataRow drw, string fieldMark, string fieldLevel)
        {
            SimsService.SIM_EthicMarkService.SummaryEthic(drw, fieldMark, fieldLevel, uClass.RegulationID);
            
        }

        private void SummaryEthic(DataRow drw)
        {
            SummaryEthic(drw, "StudentEthicMark1", "StudentEthicLevel1");
            SummaryEthic(drw, "StudentEthicMark2", "StudentEthicLevel2");
            SummaryEthic(drw, "TeacherEthicMark1", "TeacherEthicLevel1");
            SummaryEthic(drw, "TeacherEthicMark2", "TeacherEthicLevel2");

            SummaryEthic(drw, "ClassEthicMark1", "ClassEthicLevel1");
            SummaryEthic(drw, "ClassEthicMark2", "ClassEthicLevel2");
            SummaryEthic(drw, "EthicMark1", "EthicLevel1");
            SummaryEthic(drw, "EthicMark2", "EthicLevel2");

            if (drw["StudentEthicMark1"].ToString() != "" && drw["StudentEthicMark2"].ToString() != "")
            {
                drw["StudentEthicMark"] = Math.Round(Convert.ToDecimal((Convert.ToDecimal(drw["StudentEthicMark1"]) + Convert.ToDecimal(drw["StudentEthicMark2"])) / 2), 0, MidpointRounding.AwayFromZero);
                SummaryEthic(drw, "StudentEthicMark", "StudentEthicLevel");
            }
            else if (drw["StudentEthicMark1"].ToString() != "")
            {
                drw["StudentEthicMark"] = drw["StudentEthicMark1"];
                SummaryEthic(drw, "StudentEthicMark", "StudentEthicLevel");
            }
            else
            {
                drw["StudentEthicMark"] = DBNull.Value;
                drw["StudentEthicLevel"] = "";
            }

            if (drw["TeacherEthicMark1"].ToString() != "" && drw["TeacherEthicMark2"].ToString() != "")
            {
                drw["TeacherEthicMark"] = Math.Round(Convert.ToDecimal((Convert.ToDecimal(drw["TeacherEthicMark1"]) + Convert.ToDecimal(drw["TeacherEthicMark2"])) / 2), 0, MidpointRounding.AwayFromZero);
                SummaryEthic(drw, "TeacherEthicMark", "TeacherEthicLevel");
            }
            else if (drw["TeacherEthicMark1"].ToString() != "")
            {
                drw["TeacherEthicMark"] = drw["TeacherEthicMark1"];
                SummaryEthic(drw, "TeacherEthicMark", "TeacherEthicLevel");
            }
            else
            {
                drw["TeacherEthicMark"] = DBNull.Value;
                drw["TeacherEthicLevel"] = "";
            }

            if (drw["ClassEthicMark1"].ToString() != "" && drw["ClassEthicMark2"].ToString() != "")
            {
                drw["ClassEthicMark"] = Math.Round(Convert.ToDecimal((Convert.ToDecimal(drw["ClassEthicMark1"]) + Convert.ToDecimal(drw["ClassEthicMark2"])) / 2), 0, MidpointRounding.AwayFromZero);
                SummaryEthic(drw, "ClassEthicMark", "ClassEthicLevel");
            }
            else if (drw["ClassEthicMark1"].ToString() != "")
            {
                drw["ClassEthicMark"] = drw["ClassEthicMark1"];
                SummaryEthic(drw, "ClassEthicMark", "ClassEthicLevel");
            }
            else
            {
                drw["ClassEthicMark"] = DBNull.Value;
                drw["ClassEthicLevel"] = "";
            }

            if (drw["EthicMark1"].ToString() != "" && drw["EthicMark2"].ToString() != "")
            {
                drw["EthicMark"] = Math.Round(Convert.ToDecimal((Convert.ToDecimal(drw["EthicMark1"]) + Convert.ToDecimal(drw["EthicMark2"])) / 2), 0, MidpointRounding.AwayFromZero);
                SummaryEthic(drw, "EthicMark", "EthicLevel");
            }
            else if (drw["EthicMark1"].ToString() != "" && drw["EthicMark2"].ToString() == "")
            {
                drw["EthicMark"] = drw["EthicMark1"];
                SummaryEthic(drw, "EthicMark", "EthicLevel");
            }
            else if (drw["EthicMark1"].ToString() == "" && drw["EthicMark2"].ToString() != "")
            {
                drw["EthicMark"] = drw["EthicMark2"];
                SummaryEthic(drw, "EthicMark", "EthicLevel");
            }
            else
            {
                drw["EthicMark"] = DBNull.Value;
                drw["EthicLevel"] = "";
            }

            drw["IsEdit"] = 1;
        }

        #endregion

        private void gvData_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataRow drw = gvData.GetFocusedDataRow();
            if (drw != null)
            {
                SummaryEthic(drw);
                btnSave.Enabled = mnuItemSave.Enabled = true;
            }
        }
        private void PrintModelRankEthicMark(int semester)
        {

            string strReport = "Report/StudentManager/Ethic/Student_DiemRenLuyen_MauXepHang.repx";
            int St = semester;
            DataTable dtbData = (gvData.DataSource as DataView).Table;
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData, strReport, false);
            // truyen tham so theo ý riêng
            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);
            frm.SetParameter("pTrainingLevel", uClass.TrainingLevelName);
            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pScience", uClass.ScienceName);
            frm.SetParameter("pClass", uClass.ClassName);
            frm.SetParameter("pYearID", uYearSemester.YearEditValueText);
            frm.SetParameter("pSemester", semester);
            frm.Show();
        }
        private void Print(string reportFile, int semester)
        {
            // print Sinh vien
            string strReport = reportFile;
            int St=semester;
            DataTable dtbData = (gvData.DataSource as DataView).Table;
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData, strReport, false);
           
            // Set xep loai tot nghiep
            iTB = 0; iTBKha = 0; iKha = 0; iTot = 0; iXuatSac = 0; iSV = 0; iYeu = 0; iKem = 0;
            for (int j = 0; j < dtbData.Rows.Count; j++)
            {
                iSV += 1;
                if (St == 0)
                {
                    if (Convert.ToString(dtbData.Rows[j]["EthicLevel"]) == "Kém")
                        iKem += 1;
                    else if (Convert.ToString(dtbData.Rows[j]["EthicLevel"]) == "Yếu")
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
                    if (Convert.ToString(dtbData.Rows[j]["EthicLevel1"]) == "Kém")
                        iKem += 1;
                    else if (Convert.ToString(dtbData.Rows[j]["EthicLevel1"]) == "Yếu")
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
                    if (Convert.ToString(dtbData.Rows[j]["EthicLevel2"]) == "Kém")
                        iKem += 1;
                    else if (Convert.ToString(dtbData.Rows[j]["EthicLevel2"]) == "Yếu")
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
            frm.SetParameter("pSemester", semester);
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
            frm.SetParameter("pKem", iKem);
            frm.SetParameter("pTLKem", iKem * 100 / iSV);
            frm.SetParameter("pSV", iSV);
            

            frm.Show();
        }
        
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (uClass.ClassIDEditValue==null)
                Print("Report/StudentManager/Ethic/Student_DiemRenLuyen_Nam.repx",0);
            else
                Print("Report/StudentManager/Ethic/Student_DiemRenLuyenLop_Nam.repx", 0);
        }

        private void mnuItemPrint1_Click(object sender, EventArgs e)
        {
            if (uClass.ClassIDEditValue==null)
                Print("Report/StudentManager/Ethic/Student_DiemRenLuyen_HK1.repx", 1);
            else
                Print("Report/StudentManager/Ethic/Student_DiemRenLuyenLop_HK1.repx", 1);
        }

        private void mnuItemPrint2_Click(object sender, EventArgs e)
        {
            if (uClass.ClassIDEditValue ==null)
                Print("Report/StudentManager/Ethic/Student_DiemRenLuyen_HK2.repx", 2);
            else
                Print("Report/StudentManager/Ethic/Student_DiemRenLuyenLop_HK2.repx", 2);
        }

        private void btnSummaryFromMonth_Click(object sender, EventArgs e)
        {
            SummaryFromMonth();
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

        private void btnSummaryFromSemester_Click(object sender, EventArgs e)
        {
            SummaryFromSemester();
        }

        private void mnuItemPrint_RankEthicMark_HKI_Click(object sender, EventArgs e)
        {
            PrintModelRankEthicMark(1);
        }

        private void mnuItemPrint_RankEthicMark_HKII_Click(object sender, EventArgs e)
        {
            PrintModelRankEthicMark(2);
        }

        private void mnuItemDelete_Click(object sender, EventArgs e)
        {
            if (MessageManager.Confirm("Bạn có chắc chắn muốn xóa dữ liệu ở những dòng đang chọn!") == System.Windows.Forms.DialogResult.Yes)
            {
                string strLogDetail = "";

                SIM_SummaryEthicMark obj = new SIM_SummaryEthicMark();
                obj.BeginTransaction();

                foreach (int i in gvData.GetSelectedRows())
                {
                    DataRow drw = gvData.GetDataRow(i);

                    if (drw != null && drw["YearID"].ToString() != "" && drw["StudentID"].ToString() != "")
                    {
                        obj.StudentID = Convert.ToInt64(drw["StudentID"]);
                        obj.YearID = Convert.ToInt32(drw["YearID"]);
                        if (!obj.Delete())
                        {
                            ErrorManager.Error("Việc xoá dữ liệu bị lỗi!\r\n" + obj.ErrorException.Message);
                            return;
                        }

                        // nhớ log
                        strLogDetail += "Sinh viên: " + gvData.GetDataRow(i)["StudentCode"] + " - " + gvData.GetDataRow(i)["StudentFirstName"] + " " + gvData.GetDataRow(i)["StudentLastName"] + "\r\n";
                    }
                }

                obj.CommitTransaction();
                gvData.DeleteSelectedRows();
                btnSave.Enabled = mnuItemSave.Enabled = false;

                // ghi log
                string strActionLog =
                                  "Lớp học: " + uClass.ClassIDEditValue + "\r\n" +
                                  "Niên học: " + uClass.UYearSemester.YearEditValueText + "\r\n" +
                                  strLogDetail;

                new SystemObject.SYS_ActionLog().WriteActionLog("Xóa điểm rèn luyện năm học", strActionLog, SystemObject.ActionLogType.DEL, 4, UserSession.Username);
            }
        }

        private void gvData_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            mnuItemDelete.Enabled = btnDelete.Enabled = gvData.SelectedRowsCount > 0 && UserSession.HasPermission(PERMISSION_EDIT); // dùng chung quyền edit
        }
        /// <summary>
        ///  Nếu itemOld = null thì là thêm mới với itemNew


    }
}