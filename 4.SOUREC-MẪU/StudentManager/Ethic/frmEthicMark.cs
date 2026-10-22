using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using DevExpress.XtraGrid.Views.BandedGrid;
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
    public partial class frmEthicMark : FormBase, IForm
    {
        #region Consts

        public const string PERMISSION_EDIT = "SIM_EthicMark_Edit";
        public const string PERMISSION_VIEW = "SIM_EthicMark_View";
        #endregion

        #region Variables

        
        private DataTable dtbData;
        private DataTable dtbEthicMark;
        private DataTable dtbYear;

        private string strClassID = "";
        private int intYear = 0;
        private string strListIDDeleted = "";
        private Decimal iSV;
        private Decimal iXuatSac;
        private Decimal iTot;
        private Decimal iKha;
        private Decimal iTBKha;
        private Decimal iTB, iYeu;
                
        #endregion

        #region IForm Members

        private static frmEthicMark _instance = null;

        public static frmEthicMark Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmEthicMark();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmEthicMark()
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

            }
        }

        private bool IsValidData()
        {

            if (uClass.CourseIDEditValue == null)
            {
                MessageManager.Warning("Bạn phải chọn khoá học!");
                uClass.Focus();
                return false;
            }
            if (uClass.TrainingLevelIDEditValue == null)
            {
                MessageManager.Warning("Bạn phải chọn bậc đào tạo!");
                uClass.Focus();
                return false;
            }

            return true;
        }   

        public void LoadData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadData));
            else
            {
                SIM_Student objStudent = new SIM_Student();
                dtbData = objStudent.Search("@ScienceID", uClass.ScienceIDEditValue,
                                    "@CourseID", uClass.CourseIDEditValue,
                                    "@TrainingLevelID", uClass.TrainingLevelIDEditValue,
                                    "@TrainingType", uClass.TrainingTypeEditValue,
                                    "@BranchID", uClass.BranchEditValue,
                                    "@SpecialBranchID", uClass.SpecialBranchIDEditValue,
                                    "@ClassID", uClass.ClassIDEditValue,
                                    "@StatusList",";1;2;5;6;7"); // bỏ đình chỉ và đuổi học ra

                SIM_SummaryEthicMark obj = new SIM_SummaryEthicMark();
                dtbEthicMark = obj.SearchSummaryEthicMark("@ScienceID", uClass.ScienceIDEditValue,
                                    "@CourseID", uClass.CourseIDEditValue,
                                    "@TrainingLevelID", uClass.TrainingLevelIDEditValue,
                                    "@TrainingType", uClass.TrainingTypeEditValue,
                                    "@BranchID", uClass.BranchEditValue,
                                    "@SpecialBranchID", uClass.SpecialBranchIDEditValue,
                                    "@ClassID", uClass.ClassIDEditValue);

                dtbYear = obj.SearchListYear("@CourseID", uClass.CourseIDEditValue,"@ClassID",uClass.ClassIDEditValue);
                dtbYear.Columns.Add("YearIndex", typeof(int)); // thứ tự niên học để làm mã cột tĩnh

                if (dtbData != null)
                {
                    RepairGrid(); // khởi tạo cột cơ bản
                    RepairDataAndGrid(); // khởi tạo môn học vào data và lưới
                    FillData(); // điền điểm vào

                    gcData.DataSource = dtbData;
                    
                    // set order
                    gvData.SetOrder("Order");                                  
                    
                    mnuItemSave.Enabled = btnSave.Enabled = dtbData.Rows.Count > 0 && UserSession.HasPermission(PERMISSION_EDIT); // load lại thì không cần save 
                    btnPrint.Enabled = mnuItemExportToExcel.Enabled = dtbData.Rows.Count > 0;
                }
                else
                {
                    //ErrorManager.Error(obj.ErrorException);
                    ErrorManager.Error("Việc lấy thông tin bị lỗi!");
                }
            }
        }

        /// <summary>
        /// Khởi tạo 53 cột cho 53 tuần cho lưới
        /// </summary>
        private void RepairGrid()
        {
            // Xóa hết grid 
            gvData.Bands.Clear();
            gvData.Columns.Clear();

            // Student
            GridBand gbStudent = new GridBand(); ;
            BandedGridColumn gcolOrder = new BandedGridColumn();
            BandedGridColumn gcolStudentCode = new BandedGridColumn();
            BandedGridColumn gcolStudentFirstName = new BandedGridColumn();
            BandedGridColumn gcolStudentLastName = new BandedGridColumn();
            BandedGridColumn gcolBirthday = new BandedGridColumn();
            BandedGridColumn gcolGenderText = new BandedGridColumn();

            

            gvData.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            gbStudent});
            gvData.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            gcolOrder,
            gcolStudentCode,
            gcolStudentFirstName,
            gcolStudentLastName,
            gcolBirthday,
            gcolGenderText});
            gvData.CustomizationFormBounds = new System.Drawing.Rectangle(1048, 450, 223, 215);
            gvData.GridControl = gcData;
            gvData.Name = "gvData";
            gvData.OptionsCustomization.AllowBandMoving = false;
            gvData.OptionsCustomization.AllowColumnMoving = false;
            gvData.OptionsCustomization.AllowGroup = false;
            gvData.OptionsCustomization.AllowQuickHideColumns = false;
            gvData.OptionsSelection.EnableAppearanceFocusedRow = false;
            gvData.OptionsSelection.InvertSelection = true;
            gvData.OptionsSelection.MultiSelect = true;
            gvData.OptionsView.ShowGroupPanel = false;
            gvData.RowSeparatorHeight = 1;
            // 
            // gbStudent
            // 
            gbStudent.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            gbStudent.AppearanceHeader.Options.UseFont = true;
            gbStudent.AppearanceHeader.Options.UseTextOptions = true;
            gbStudent.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gbStudent.Caption = "SINH VIÊN";
            gbStudent.Columns.Add(gcolOrder);
            gbStudent.Columns.Add(gcolStudentCode);
            gbStudent.Columns.Add(gcolStudentFirstName);
            gbStudent.Columns.Add(gcolStudentLastName);
            gbStudent.Columns.Add(gcolBirthday);
            gbStudent.Columns.Add(gcolGenderText);
            gbStudent.Name = "gbStudent";
            gbStudent.Width = 300;
            // 
            // gcolOrder
            // 
            gcolOrder.AppearanceHeader.Options.UseTextOptions = true;
            gcolOrder.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolOrder.Caption = "STT";
            gcolOrder.FieldName = "Order";
            gcolOrder.Name = "gcolOrder";
            gcolOrder.Visible = true;
            // 
            // gcolStudentCode
            // 
            gcolStudentCode.AppearanceHeader.Options.UseTextOptions = true;
            gcolStudentCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolStudentCode.Caption = "Mã SV";
            gcolStudentCode.FieldName = "StudentCode";
            gcolStudentCode.Name = "gcolStudentCode";
            gcolStudentCode.Visible = true;
            // 
            // gcolStudentFirstName
            // 
            gcolStudentFirstName.AppearanceHeader.Options.UseTextOptions = true;
            gcolStudentFirstName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolStudentFirstName.Caption = "Họ đệm";
            gcolStudentFirstName.FieldName = "StudentFirstName";
            gcolStudentFirstName.Name = "gcolStudentFirstName";
            gcolStudentFirstName.Visible = true;
            // 
            // gcolStudentLastName
            // 
            gcolStudentLastName.AppearanceHeader.Options.UseTextOptions = true;
            gcolStudentLastName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolStudentLastName.Caption = "Tên";
            gcolStudentLastName.FieldName = "StudentLastName";
            gcolStudentLastName.Name = "gcolStudentLastName";
            gcolStudentLastName.Visible = true;

            // gcolBirthday            
            gcolBirthday.Caption = "Ngày sinh";
            gcolBirthday.FieldName = "BirthDateText";
            gcolBirthday.Name = "gcolBirthday";

            gcolBirthday.Visible = true;
            gcolBirthday.AppearanceHeader.Options.UseTextOptions = true;
            gcolBirthday.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolBirthday.AppearanceCell.Options.UseTextOptions = true;
            gcolBirthday.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

            // gcolGenderText

            gcolGenderText.Caption = "Giới tính";
            gcolGenderText.FieldName = "GenderText";
            gcolGenderText.Name = "gcolGenderText";
            gcolGenderText.Visible = true;
            gcolGenderText.AppearanceHeader.Options.UseTextOptions = true;
            gcolGenderText.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolGenderText.AppearanceCell.Options.UseTextOptions = true;
            gcolGenderText.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            

            gbStudent.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;            

        }

        private void RepairDataAndGrid()
        {
            //int intRegulationID = uClass.RegulationID.Value;

            int i = 1;
            foreach (DataRow drw in dtbYear.Rows)
            {
                drw["YearIndex"] = i; // tĩnh tên cột

                //string strYearID = drw["YearID"].ToString();
                string strYearText = drw["YearText"].ToString();

                dtbData.Columns.Add("EthicMark_" + i.ToString(), typeof(double));
                dtbData.Columns.Add("EthicLevel_" + i.ToString(), typeof(string));



                // Add năm học vào
                GridBand gbYear = new GridBand();
                gbYear.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
                gbYear.AppearanceHeader.Options.UseFont = true;
                gbYear.AppearanceHeader.Options.UseTextOptions = true;
                gbYear.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gbYear.Caption = strYearText;
                gbYear.Name = "gbYear" + i.ToString();
                gbYear.Width = 375;


                // 
                // gcolEthicMark_
                //                
                BandedGridColumn gcolEthicMark = new BandedGridColumn();
                gcolEthicMark.AppearanceHeader.Options.UseTextOptions = true;
                gcolEthicMark.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gcolEthicMark.Caption = "Điểm";
                gcolEthicMark.FieldName = "EthicMark_" + i.ToString();
                gcolEthicMark.Name = "gcolEthicMark_" + i.ToString();
                gcolEthicMark.Visible = true;

                // 
                // gcolEthicLevel_
                //                
                BandedGridColumn gcolEthicLevel = new BandedGridColumn();
                gcolEthicLevel.AppearanceHeader.Options.UseTextOptions = true;
                gcolEthicLevel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gcolEthicLevel.Caption = "Loại";
                gcolEthicLevel.FieldName = "EthicLevel_" + i.ToString();
                gcolEthicLevel.Name = "gcolEthicLevel_" + i.ToString();
                gcolEthicLevel.Visible = true;
                gcolEthicLevel.AppearanceCell.BackColor = Color.LightBlue;
                gcolEthicLevel.AppearanceCell.Options.UseBackColor = true;



                // add column vao grid
                gvData.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
                                           gcolEthicMark,gcolEthicLevel});

                // add cot vao band subject
                gbYear.Columns.Add(gcolEthicMark);
                gbYear.Columns.Add(gcolEthicLevel);

                gvData.Bands.Add(gbYear);
                i++;

            }



            // Summary
            GridBand gbSummary = new GridBand();
            BandedGridColumn gcolSummaryEthicMark = new BandedGridColumn();
            BandedGridColumn gcolSummaryEthicLevel = new BandedGridColumn();

            gvData.Bands.Add(gbSummary);
            gvData.Columns.Add(gcolSummaryEthicMark);
            gvData.Columns.Add(gcolSummaryEthicLevel);

            // 
            // gbSummary
            // 
            gbSummary.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            gbSummary.AppearanceHeader.Options.UseFont = true;
            gbSummary.AppearanceHeader.Options.UseTextOptions = true;
            gbSummary.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gbSummary.Caption = "TỔNG KẾT";
            gbSummary.Name = "gbSummary";
            gbSummary.Width = 300;
            gbSummary.Columns.Add(gcolSummaryEthicMark);
            gbSummary.Columns.Add(gcolSummaryEthicLevel);

            // 
            // gcolSummaryLearningMark
            // 
            gcolSummaryEthicMark.AppearanceHeader.Options.UseTextOptions = true;
            gcolSummaryEthicMark.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolSummaryEthicMark.Caption = "TBC";
            gcolSummaryEthicMark.FieldName = "EthicMark";
            gcolSummaryEthicMark.Name = "gcolSummaryEthicMark";
            gcolSummaryEthicMark.Visible = true;
            // 
            // gcolEthicLevel
            // 
            gcolSummaryEthicLevel.AppearanceHeader.Options.UseTextOptions = true;
            gcolSummaryEthicLevel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolSummaryEthicLevel.Caption = "Xếp loại";
            gcolSummaryEthicLevel.FieldName = "EthicLevel";
            gcolSummaryEthicLevel.Name = "gcolEthicLevel";
            gcolSummaryEthicLevel.Visible = true;
        }

        private void FillData()
        {            
            foreach (DataRow drw in dtbData.Rows)
            {

                double dblTotalMark = 0;
                int intCount = 0;

                DataRow[] rows = dtbEthicMark.Select("StudentID='" + drw["StudentID"].ToString() + "'");
                foreach (DataRow drw2 in rows) 
                {
                    string strYearID = drw2["YearID"].ToString();
                    DataRow []rowYears = dtbYear.Select("YearID='" + strYearID + "'");
                    if (rowYears.Length > 0)
                    {
                        string strIndex = rowYears[0]["YearIndex"].ToString();
                        drw["EthicMark_" + strIndex ] = drw2["EthicMark"];
                        drw["EthicLevel_" + strIndex] = drw2["EthicLevel"];

                        // cộng dồn để tính điểm tổng kết   
                        if (drw2["EthicMark"].ToString()== "")     
                                dblTotalMark +=0;
                        else
                            dblTotalMark += Convert.ToDouble(drw2["EthicMark"]);
                        intCount++;
                    }
                }
                if (intCount > 0)
                    drw["EthicMark"] = Math.Round(dblTotalMark / intCount, 1);
                SummaryEthic(drw, "EthicMark", "EthicLevel");
            }
        }

        #region Tính điểm rèn luyện theo năm

        private void SummaryEthic(DataRow drw, string fieldMark, string fieldLevel)
        {
            SimsService.SIM_EthicMarkService.SummaryEthic(drw, fieldMark, fieldLevel, uClass.RegulationID);               
        }      

        #endregion        

        /// <summary>
        /// Save dữ liệu ở tab edit
        /// </summary>
        private bool SaveData()
        {
                   
            SIM_Student item = new SIM_Student();
            item.BeginTransaction();
            foreach (DataRow drw in dtbData.Rows)
            {               
                item.StudentID = Convert.ToInt64(drw[SIM_Student.C_StudentID]);
                if (drw["EthicMark"].ToString() != "")
                    item.EthicMark = Convert.ToDouble(drw["EthicMark"]);
                else
                    item.EthicMark = null;
                item.EthicLevel = drw["EthicLevel"].ToString();
                
                if (!item.UpdateEthicMark())
                {
                    ErrorManager.Error("Cập nhật điểm rèn luyện sinh viên bị lỗi!");
                    return false;
                }
            }
            item.CommitTransaction();
            return true;
        }
                 
        #endregion

        #region Form Actions

        private void frmEthicMark_Load(object sender, EventArgs e)
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
           
        private void btnPrint_Click(object sender, EventArgs e)
        {
            // print Sinh vien
            DataTable dtbData = (gvData.DataSource as DataView).Table;
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData, "Report/StudentManager/Ethic/Student_DiemRenLuyen_TK.repx", false);
            
            // Set xep loai tot nghiep
            iTB = 0; iTBKha = 0; iKha = 0; iTot = 0; iXuatSac = 0; iSV = 0; iYeu = 0;
            for (int j = 0; j < dtbData.Rows.Count; j++)
            {
                iSV += 1;

                if (Convert.ToString(dtbData.Rows[j]["EthicLevel"]) == "Yếu" || Convert.ToString(dtbData.Rows[j]["EthicLevel"]) == "Kém")
                        iYeu += 1;
                    else if (Convert.ToString(dtbData.Rows[j]["EthicLevel"]) == "Trung bình")
                        iTB += 1;
                    else if (Convert.ToString(dtbData.Rows[j]["EthicLevel"]) == "TB khá")
                        iTBKha += 1;
                    else if (Convert.ToString(dtbData.Rows[j]["EthicLevel"]) == "Khá")
                        iKha += 1;
                    else if (Convert.ToString(dtbData.Rows[j]["EthicLevel"]) == "Tốt")
                        iTot += 1;
                    else if (Convert.ToString(dtbData.Rows[j]["EthicLevel"]) == "Xuất sắc")
                        iXuatSac += 1;
            }
           // Nam tong ket cua diem ren luyen

            int i = 1;
            foreach (DataRow drw in dtbYear.Rows)
            {
                frm.SetParameter("pYearText"+i.ToString(), drw["YearText"].ToString());
                i++;
            }
            // truyen tham so theo ý riêng
            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);
            frm.SetParameter("pTrainingLevel", uClass.TrainingLevelName);
            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pScience", uClass.ScienceName);
            frm.SetParameter("pClass", uClass.ClassName);
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

        #endregion

        private void mnuItemExportToExcel_Click(object sender, EventArgs e)
        {
            gvData.QuickExportToExcel();
        }
    }
}