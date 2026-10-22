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
namespace StudentManager.Graduation
{
    public partial class frmReviewGraduationExam : FormBase, IForm
    {
        #region Consts

        public const string PERMISSION_EDIT = "SIM_ReviewGraduationExam_Edit";
        public const string PERMISSION_VIEW = "SIM_ReviewGraduationExam_View";

        #endregion

        #region Variables

        private string strClassID = "";
        private int intYear = 0;
        private int intSemester = 0;
        private string strListIDDeleted = "";
        string sReport = "";
        DataTable dtbData;

        #endregion

        #region IForm Members

        private static frmReviewGraduationExam _instance = null;

        public static frmReviewGraduationExam Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmReviewGraduationExam();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion


        public frmReviewGraduationExam()
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

            }
        }

        public void LoadData()
        {

            SIM_Student obj = new SIM_Student();
            string strSpecialTypeList = "";
            int intSpecialType = 0;
            if (OptNghe.Checked == true)
            {
                strSpecialTypeList = "," + Global.SubjectSpecialType.BinhThuong.ToString() + "," + Global.SubjectSpecialType.VanHoa.ToString() + ","
                     + Global.SubjectSpecialType.GiaoDucQuocPhong.ToString() + "," + Global.SubjectSpecialType.GiaoDucTheChat.ToString() + ","
                     + Global.SubjectSpecialType.ChinhTri.ToString() + ",";
                intSpecialType = Global.SubjectSpecialType.TotNghiepLT;
            }
            else if (OptTNCT.Checked == true)
            {
                strSpecialTypeList = "," + Global.SubjectSpecialType.ChinhTri.ToString() + ",";
                intSpecialType = Global.SubjectSpecialType.ChinhTriTotNghiep;
            }
            else
            {
                strSpecialTypeList = "," + Global.SubjectSpecialType.VanHoa.ToString() + ",";
                intSpecialType = Global.SubjectSpecialType.TotNghiepVanHoa;
            }
            if (uClass.RegulationID == 14) // Tinh cho cac he nghe
                dtbData = obj.SearchReviewGraduationExam_QC14(uClass.CourseIDEditValue.ToString(), uClass.TrainingLevelIDEditValue.ToString(), uClass.SpecialBranchIDEditValue,
                                          uClass.ClassIDEditValue, cbxOrderReview.SelectedIndex, uClass.RegulationID.Value, strSpecialTypeList, intSpecialType
                                         );
            else if (uClass.RegulationID == 40 || uClass.RegulationID == 46 || uClass.RegulationID == 22) // Tinh cho trung cap chuyen nghiep
            {
                if (intSpecialType == 5) // Van hóa của 22 học riêng đối với Tw3
                {
                    dtbData = obj.SIM_ReviewGraduationExamVH_QC22(uClass.CourseIDEditValue.ToString(), uClass.TrainingLevelIDEditValue.ToString(), uClass.SpecialBranchIDEditValue,
                                                 uClass.ClassIDEditValue, cbxOrderReview.SelectedIndex, uClass.RegulationID.Value, strSpecialTypeList, intSpecialType
                                                );
                }
                else
                {
                    dtbData = obj.SearchReviewGraduationExam_QC40(uClass.CourseIDEditValue.ToString(), uClass.TrainingLevelIDEditValue.ToString(), uClass.SpecialBranchIDEditValue,
                                               uClass.ClassIDEditValue, cbxOrderReview.SelectedIndex, uClass.RegulationID.Value, strSpecialTypeList, intSpecialType
                                              );
                }
            }
            else if (uClass.RegulationID == 25) // Tinh cho CD chinh qui theo nien che
                dtbData = obj.SearchReviewGraduationExam_QC25(uClass.CourseIDEditValue.ToString(), uClass.TrainingLevelIDEditValue.ToString(), uClass.SpecialBranchIDEditValue,
                                          uClass.ClassIDEditValue, cbxOrderReview.SelectedIndex, strSpecialTypeList
                                         );
            else if (uClass.RegulationID == 43) // Tinh cho CD,DH theo tin chi
                dtbData = obj.SearchReviewGraduationExam_QC43(uClass.CourseIDEditValue.ToString(), uClass.TrainingLevelIDEditValue.ToString(), uClass.SpecialBranchIDEditValue,
                                          uClass.ClassIDEditValue, cbxOrderReview.SelectedIndex, uClass.RegulationID.Value, strSpecialTypeList
                                         );
            else if (uClass.RegulationID == 9 || uClass.RegulationID == 4) // Tc, cđ chuyên nghiệp 2017
            {
                // Dự thi tốt nghiệp chính trị tính riêng do tính lại TBC chính trị.
                dtbData = obj.SearchReviewGraduationExam_QC09(uClass.CourseIDEditValue.ToString(), uClass.TrainingLevelIDEditValue.ToString(), uClass.SpecialBranchIDEditValue,
                                             uClass.ClassIDEditValue, cbxOrderReview.SelectedIndex, uClass.RegulationID.Value, strSpecialTypeList, intSpecialType
                                            );
            }

            if (dtbData != null)
            {
                gcData.DataSource = dtbData;
                SYS_GridColumnService.InitGridColumn(gvData, "SIM_ReviewGraduationExam");

                ModifyGrid();

                btnPrint1.Enabled = btnPrint2.Enabled = mnuItemExportToExcel.Enabled = btnReview.Enabled = dtbData.Rows.Count > 0;
                btnReview.Enabled = dtbData.Rows.Count > 0 && UserSession.HasPermission(PERMISSION_EDIT);
                chkIsNotShowReviewed_CheckedChanged(null, null);
            }
            else
                ErrorManager.Error("Việc tải thông tin bị lỗi!");
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

        private void frmReviewGraduationExam_Load(object sender, EventArgs e)
        {
            CheckPermission();
            SetToolTip();
            new Thread(LoadReferenceData).Start();
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            if (IsValidData())
            {
                LoadData();
                //new Thread(LoadData).Start();
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
            if (uClass.BranchEditValue == null)
            {
                MessageManager.Warning("Bạn phải chọn ngành học!");
                uClass.Focus();
                return false;
            }
            if (uClass.SpecialBranchIDEditValue == null)
            {
                MessageManager.Warning("Bạn phải chọn chuyên ngành!");
                uClass.Focus();
                return false;
            }
            if (cbxOrderReview.SelectedIndex < 1)
            {
                MessageManager.Warning("Bạn phải chọn đợt thi tốt nghiệp!");
                uClass.Focus();
                return false;
            }
            return true;
        }



        private void btnReview_Click(object sender, EventArgs e)
        {
            if (cbxOrderReview.SelectedIndex < 1)
                cbxOrderReview.SelectedIndex = 1;

            foreach (DataRow drw in dtbData.Rows)
            {
                if (drw["OrderReview_Prev"].ToString() == "") // chưa đạt ở lần xét trước thì mới xét lại
                {
                    if (drw["PassedUnitText"].ToString() == "") // chưa học môn nào
                    {
                        drw["ReviewResult"] = "Không đủ đk";
                    }
                    else if (OptNghe.Checked)
                    {

                        if (Convert.ToInt32(drw["FailedUnitText"]) == 0)  // tích luỹ đủ tín chỉ                                                
                        {
                            drw["ReviewResult"] = "Đủ điều kiện";
                        }
                        else
                        {
                            int intRegulation = uClass.RegulationID.Value;
                            double dblMinOfEnd = 4;
                            double dblMinOfCourse = 4.5;
                            if (intRegulation == 9)
                                dblMinOfCourse = 4;

                            // qc 22 cũ (tc chuyên nghiệp): tb năm cuối < 4 or tb tích lũy < 4.5 là đuổi luôn
                            // qc09 2017 (tc,cđ chuyên nghiệp): tb năm cuối or tb tích lũy < 4 đuổi học luôn
                            if (!Convert.ToBoolean(drw["IsRegulation43"]) && (intRegulation == 22 || intRegulation == 40 || intRegulation == 46 || intRegulation == 9))
                            {
                                if (drw["SummaryLearningMark"].ToString() != "" && Convert.ToDouble(drw["SummaryLearningMark"]) >= dblMinOfCourse
                                        && drw["SummaryOfEndYear"].ToString() != "" && Convert.ToDouble(drw["SummaryOfEndYear"]) >= dblMinOfEnd)
                                    drw["ReviewResult"] = "Học trả nợ";
                                else
                                    drw["ReviewResult"] = "Buộc thôi học";
                            }
                            else
                                drw["ReviewResult"] = "Không đủ đk";
                        }

                    }
                    else if (OptTNCT.Checked && Convert.ToInt32(drw["FailedUnitText"]) == 0)
                    {
                        drw["ReviewResult"] = "Đủ điều kiện";
                    }
                    else if (OptVanHoa.Checked && Convert.ToInt32(drw["FailedUnitText"]) == 0)
                    {
                        drw["ReviewResult"] = "Đủ điều kiện";
                    }
                    else
                    {
                        drw["ReviewResult"] = "Không đủ đk";
                    }
                }
            }
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbxOrderReview.SelectedIndex < 1)
                cbxOrderReview.SelectedIndex = 1;

            if (SaveData())
            {
                //MessageManager.Info("Đã cập nhật dữ liệu thành công!");
                btnSave.Enabled = mnuItemSave.Enabled = false;
                btnSearch_Click(sender, e);
            }
        }

        private bool SaveData()
        {
            SIM_GraduationExamReview obj = new SIM_GraduationExamReview();
            obj.BeginTransaction();
            int iTotNghiep = 0;
            if (OptNghe.Checked == true)
            {
                iTotNghiep = Global.SubjectSpecialType.TotNghiepLT;
            }
            if (OptTNCT.Checked == true)
            {
                iTotNghiep = Global.SubjectSpecialType.ChinhTriTotNghiep;
            }
            if (OptVanHoa.Checked == true)
            {
                iTotNghiep = Global.SubjectSpecialType.TotNghiepVanHoa;
            }
            for (int i = 0; i < gvData.RowCount; i++)
            {
                DataRow drw = gvData.GetDataRow(i);

                SIM_GraduationExamReview item = new SIM_GraduationExamReview();
                item.IDB = obj.IDB;
                if (drw.RowState == DataRowState.Modified && drw["OrderReview_Prev"].ToString() == "") // chưa đạt ở lần xét trước thì mới xét lại)
                {
                    // Xoa du lieu 
                    item.SpecialType = iTotNghiep;
                    item.StudentID = Convert.ToInt64(drw[SIM_GraduationExamReview.C_StudentID]);
                    item.Delete();

                    // Insert lai moi hoan toan
                    if (drw["ReviewResult"].ToString() == "Đủ điều kiện")
                    {
                        item.OrderReview = cbxOrderReview.SelectedIndex;
                        if (drw["SummaryEthicMark"].ToString() == "")
                        {
                            item.SummaryEthicMark = 0;
                        }
                        else
                        {
                            item.SummaryEthicMark = Convert.ToDouble(drw["SummaryEthicMark"]);
                        }
                        item.SpecialType = iTotNghiep;

                        item.LearningLevel = Convert.ToString(drw[SIM_GraduationExamReview.C_LearningLevel]);
                        item.StudentID = Convert.ToInt64(drw[SIM_GraduationExamReview.C_StudentID]);
                        item.SummaryLearningMark = Libs.MyConvert.ToDouble(drw["SummaryLearningMark"]);
                        item.EthicLevel = Convert.ToString(drw["EthicLevel"]);
                        item.OrderReview = cbxOrderReview.SelectedIndex;
                        item.CreatedUser = UserSession.Username;
                        if (!item.Add())
                        {
                            ErrorManager.Error("Cập nhật danh sách sinh viên dự thi tốt nghiệp bị lỗi!");
                            return false;
                        }

                    }
                }
            }
            obj.CommitTransaction();
            return true;
        }

        private void btnPrint1_Click(object sender, EventArgs e)
        {
            // print danh sach du dieu kien du thi

            DataTable dtbData2 = dtbData.Copy();
            dtbData2.DefaultView.RowFilter = "ReviewResult <>'' and ReviewResult is not null and (ReviewResult = 'Đạt' or ReviewResult ='Đủ điều kiện') and IsSelected = 1"
                + (chkIsNotShowReviewed.Checked ? "and OrderReview_Prev is null" : "");

            dtbData2 = dtbData2.DefaultView.ToTable();

            sReport = "Report/StudentManager/Graduation/Graduation_XetDuThiTN_QC14.repx";
            switch (uClass.RegulationID)
            {
                case 14:
                    if (uClass.TrainingLevelIDEditValue.ToString().Contains("NH") || uClass.TrainingLevelIDEditValue.ToString().Contains("SCN"))
                        sReport = "Report/StudentManager/Graduation/Graduation_XetDuThiTN_QC14NH.repx";
                    else
                    {
                        if(OptVanHoa.Checked)
                            sReport = "Report/StudentManager/Graduation/Graduation_XetDuThiTN_QC14_VH.repx";
                        else
                            sReport = "Report/StudentManager/Graduation/Graduation_XetDuThiTN_QC14.repx";
                    }
                    break;
                case 22:
                   if (OptVanHoa.Checked)
                       sReport = "Report/StudentManager/Graduation/Graduation_XetDuThiTNVH_QC22.repx";
                    else
                        sReport = "Report/StudentManager/Graduation/Graduation_XetDuThiTN_QC22.repx";
                    break;
                case 40:
                case 46:
                    if (OptVanHoa.Checked)
                        sReport = "Report/StudentManager/Graduation/Graduation_XetDuThiTN_QC14_VH.repx";
                    else
                        sReport = "Report/StudentManager/Graduation/Graduation_XetDuThiTN_QC22.repx";
                    break;
                case 25:
                    sReport = "Report/StudentManager/Graduation/Graduation_XetDuThiTN_QC25.repx";
                    break;
                case 9: // TC, CĐ chuyên nghiệp 2017
                    if (OptTNCT.Checked)
                        sReport = "Report/StudentManager/Graduation/Graduation_XetDuThiTNCT_QC09.repx";
                    else
                        sReport = "Report/StudentManager/Graduation/Graduation_XetDuThiTN_QC09.repx";
                    break;
                default:
                    sReport = "Report/StudentManager/Graduation/Graduation_XetDuThiTN_QC09.repx";
                    break;

            }

            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData2, sReport, false);
            frm.SetParameter("pClass", uClass.ClassName.ToUpper());
            frm.Show();
        }

        private void btnPrint2_Click(object sender, EventArgs e)
        {
            // print danh sach khong du thi 
            DataTable dtbData2 = dtbData.Copy();
            dtbData2.DefaultView.RowFilter = "ReviewResult <> 'Đủ điều kiện'";
                //+ (chkIsNotShowReviewed.Checked ? " and OrderReview_Prev is null" : "");
            dtbData2 = dtbData2.DefaultView.ToTable();
            
            sReport = "Report/StudentManager/Graduation/Graduation_XetKhongDuThiTN_QC14.repx";
            switch (uClass.RegulationID)
            {
                case 14:
                    if(OptVanHoa.Checked)
                        sReport = "Report/StudentManager/Graduation/Graduation_XetKhongDuThiTN_QC14_VH.repx";
                    else
                        sReport = "Report/StudentManager/Graduation/Graduation_XetKhongDuThiTN_QC14.repx";
                    break;
                case 22:
                      if (OptVanHoa.Checked)
                       sReport = "Report/StudentManager/Graduation/Graduation_XetKhongDuThiTNVH_QC22.repx";
                    else
                        sReport = "Report/StudentManager/Graduation/Graduation_XetDuThiTN_QC22.repx";
                    break;
                case 40:
                case 46:
                    sReport = "Report/StudentManager/Graduation/Graduation_XetKhongDuThiTN_QC22.repx";
                    break;
                case 25:
                    sReport = "Report/StudentManager/Graduation/Graduation_XetKhongDuThiTN_QC25.repx";
                    break;
                case 9: // TC, CĐ chuyên nghiệp 2017
                    sReport = "Report/StudentManager/Graduation/Graduation_XetKhongDuThiTN_QC09.repx";
                    break;
                default: // TC, CĐ chuyên nghiệp 2017
                    sReport = "Report/StudentManager/Graduation/Graduation_XetKhongDuThiTN_QC09.repx";
                    break;
            }
            
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData2, sReport, false);
            frm.SetParameter("pClass", uClass.ClassName.ToUpper());
            frm.Show();
        }

        private void gvData_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "ReviewResult")
            {
                DataRow drw = gvData.GetDataRow(e.RowHandle);
                if (drw["ReviewResult"].ToString() == "")
                    e.Appearance.BackColor = Color.Orange;
            }

        }
        private void Control1()
        {
            if (OptXetKhoaLuan.Checked == true)
                txtDiem.Visible = true;
            else
                txtDiem.Visible = false;
        }
        private void OptTNCT_CheckedChanged(object sender, EventArgs e)
        {
            Control1();
        }

        private void OptNghe_CheckedChanged(object sender, EventArgs e)
        {
            Control1();
        }

        private void OptVanHoa_CheckedChanged(object sender, EventArgs e)
        {
            Control1();
        }

        private void OptXetKhoaLuan_CheckedChanged(object sender, EventArgs e)
        {
            Control1();
        }

        private void mnuItemRefresh_Click(object sender, EventArgs e)
        {
            uClass.RefrehData();
            btnSearch_Click(null, null);
        }

        private void mnuItemExportToExcel_Click(object sender, EventArgs e)
        {
            gvData.QuickExportToExcel();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuDSTongHop_Click(object sender, EventArgs e)
        {
            // print danh sach khong du thi                         
            DataTable dtbData2 = dtbData.DefaultView.ToTable();

            sReport = "Report/StudentManager/Graduation/Graduation_XetTongHopThiTN_QC14.repx";
            switch (uClass.RegulationID)
            {
                case 14:
                    sReport = "Report/StudentManager/Graduation/Graduation_XetTongHopThiTN_QC14.repx";
                    break;
                case 22:
                case 40:
                case 46:
                    sReport = "Report/StudentManager/Graduation/Graduation_XetTongHopThiTN_QC22.repx";
                    break;
                case 25:
                    sReport = "Report/StudentManager/Graduation/Graduation_XetKhongDuThiTN_QC25.repx";
                    break;
                case 9: // TC, CĐ chuyên nghiệp 2017
                    sReport = "Report/StudentManager/Graduation/Graduation_XetTongHopThiTN_QC09.repx";
                    break;
               default: // TC, CĐ chuyên nghiệp 2017
                    sReport = "Report/StudentManager/Graduation/Graduation_XetKhongDuThiTN_QC09.repx";
                    break;
            }

            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData2, sReport, false);
            frm.SetParameter("pCourse", "KHỐI " + uClass.TrainingLevelName.ToUpper() + " " + uClass.CourseName.ToUpper() );
            frm.SetParameter("pSpecialBranch", "NGHỀ " + uClass.SpecialBranchName.ToUpper() + " (LỚP:" + uClass.ClassName.ToUpper() + ")");
            frm.Show();
        }

        private void mnuQuaTrinhHocTapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRow drw = gvData.GetFocusedDataRow();
            if (drw != null)
            {
                StudentManager.Student.frmStudentInfor frmView = StudentManager.Student.frmStudentInfor.Instance;
                frmView.LoadData(null, Convert.ToInt64(drw[SIM_Student.C_StudentID]));
                frmView.ShowDialog();
            }
        }

        private void chkIsNotShowReviewed_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsNotShowReviewed.Checked)
                gvData.RowFilter = "OrderReview_Prev is null";
            else
                gvData.RowFilter = "";
        }

        private void mnuDSTongHop_VH_Click(object sender, EventArgs e)
        {
            // print danh sach khong du thi                         
            DataTable dtbData2 = dtbData.DefaultView.ToTable();

            sReport = "Report/StudentManager/Graduation/Graduation_XetTongHopThiTNVH_QC22.repx";

            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData2, sReport, false);
            frm.SetParameter("pCourse", "KHỐI " + uClass.TrainingLevelName.ToUpper() + " " + uClass.CourseName.ToUpper());
            frm.SetParameter("pSpecialBranch", "NGHỀ " + uClass.SpecialBranchName.ToUpper() + " (LỚP:" + uClass.ClassName.ToUpper() + ")");
            frm.SetParameter("pClass", uClass.ClassName.ToUpper());
            frm.Show();
        }

        private void mnuItemCheckAll_Click(object sender, EventArgs e)
        {
            gvData.CheckAll();
        }

        private void mnuItemUnCheckAll_Click(object sender, EventArgs e)
        {
            gvData.UnCheckAll();
        }

        /// <summary>
        ///  Nếu itemOld = null thì là thêm mới với itemNew

        #endregion
    }
}