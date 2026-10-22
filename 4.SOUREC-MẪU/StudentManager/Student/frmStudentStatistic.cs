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
using DevExpress.XtraGrid.Views.BandedGrid;
using SystemService;

namespace StudentManager.Student
{
    public partial class frmStudentStatistic : FormBase, IForm
    {
        #region Consts
        
        public const string PERMISSION_VIEW = "SIM_StudentStatistic_View";

        #endregion

        #region Variable
                
        DataTable dtbData;
        DataTable dtbEthnicity; // dan toc 
        DataTable dtbReligion; // tôn giáo

        DataTable dtbStudentEthnicity; // dan toc 
        DataTable dtbStudentReligion; // tôn giáo
        bool bolIsFirstSearch = true;
        
        private string strReport_Header = "";
        private string strReport_Place = "";

        private bool bolHaveNormalSubject = false; // có môn bình thường trong cả kì hay năm không, có thì chỉ tính môn bình thường, không thì chỉ tính môn văn hoá        

        #endregion

        #region IForm Members

        private static frmStudentStatistic _instance = null;

        public static frmStudentStatistic Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmStudentStatistic();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmStudentStatistic()
        {
            InitializeComponent();
        }

        #region Support Functions

        private void CheckPermission()
        {
            // Kiểm tra quyền                        
            gvData.OptionsBehavior.Editable = false;
            //mnuItemSave.Enabled = btnSave.Enabled = UserSession.HasPermission(PERMISSION_EDIT);
        }

        public void LoadReferenceData()
        {
            uScienceCourseTypeLevel.InitData();
            uSpecialBranch.InitData();
            uYearID.InitData();
        }
     

        private void GetSetting()
        {
            if (SYS_SettingService.HaveNewData || bolIsFirstSearch)
            {
                strReport_Header = SYS_SettingService.GetStringValue("Report_Header");
                strReport_Place = SYS_SettingService.GetStringValue("Report_Place");               
            }
        }

        public void LoadData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadData));
            else
            {
                SIM_Student objStudent = new SIM_Student();                

                dtbData = objStudent.SearchForStatistic("@ScienceIDList", uScienceCourseTypeLevel.ScienceIDEditValue,
                                                "@CourseIDList",uScienceCourseTypeLevel.CourseIDEditValue,
                                                "@TrainingLevelIDList",uScienceCourseTypeLevel.TrainingLevelIDEditValue,
                                                "@TrainingType",uScienceCourseTypeLevel.TrainingTypeEditValue,
                                                "@BranchID",uSpecialBranch.BranchEditValue,
                                                "@SpecialBranchIDList",uSpecialBranch.SpecialBranchEditValue,
                                                "@YearID",uYearID.YearIDEditValue,
                                                "@Status",uStudentStatus.EditValue);
                dtbStudentEthnicity = objStudent.EthnicityStatistic("@Status", uStudentStatus.EditValue);
                dtbStudentReligion = objStudent.ReligionStatistic("@Status", uStudentStatus.EditValue);


                if (dtbData != null)
                {
                    RepairGrid(); // khởi tạo cột cơ bản
                    RepairDataAndGrid(); // khởi tạo môn học vào data và lưới
                    FillData(); // điền điểm vào

                    gcData.DataSource = dtbData;

                    // set order                    
                    ModifyGrid();                   

                    gvData.BestFitColumns();
                    btnExportExcel.Enabled = mnuItemPrint.Enabled = mnuItemExportToExcel.Enabled = dtbData.Rows.Count > 0;
                    
                    GetSetting();
                    bolIsFirstSearch = true;
                }
                else
                {
                    //ErrorManager.Error(obj.ErrorException);
                    ErrorManager.Error("Việc lấy thông tin thống kê bị lỗi!");
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

            // Student
            GridBand gbClass = new GridBand();
            GridBand gbGender = new GridBand();
            BandedGridColumn gcolOrder = new BandedGridColumn();
            BandedGridColumn gcolClassID = new BandedGridColumn();
            BandedGridColumn gcolClassName = new BandedGridColumn();
            BandedGridColumn gcolClassSize = new BandedGridColumn();
            BandedGridColumn gcolBoy = new BandedGridColumn();
            BandedGridColumn gcolGirl = new BandedGridColumn();

            gvData.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { gbClass, gbGender });

            gvData.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
                                    gcolOrder,
                                    gcolClassID,
                                    gcolClassName,
                                    gcolClassSize,
                                    gcolBoy,
                                    gcolGirl});

            
            // 
            // gbClass
            // 
            gbClass.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            gbClass.AppearanceHeader.Options.UseFont = true;
            gbClass.AppearanceHeader.Options.UseTextOptions = true;
            gbClass.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gbClass.Caption = "LỚP HỌC";
            gbClass.Columns.Add(gcolOrder);
            gbClass.Columns.Add(gcolClassID);
            gbClass.Columns.Add(gcolClassName);
            gbClass.Columns.Add(gcolClassSize);
            gbClass.Columns.Add(gcolBoy);
            gbClass.Columns.Add(gcolGirl);            
            gbClass.Name = "gbClass";
            gbClass.Width = 300;
           
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
            // gcolClassID
            // 
            gcolClassID.AppearanceHeader.Options.UseTextOptions = true;
            gcolClassID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolClassID.Caption = "Mã lớp";
            gcolClassID.FieldName = "ClassID";
            gcolClassID.Name = "gcolClassID";
            gcolClassID.Visible = true;

            // 
            // gcolClassName
            // 
            gcolClassName.AppearanceHeader.Options.UseTextOptions = true;
            gcolClassName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolClassName.Caption = "Tên lớp";
            gcolClassName.FieldName = "ClassName";
            gcolClassName.Name = "gcolClassName";
            gcolClassName.Visible = true;
            // 
            // gcolClassSize
            // 
            gcolClassSize.AppearanceHeader.Options.UseTextOptions = true;
            gcolClassSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolClassSize.Caption = "Sỉ số";
            gcolClassSize.FieldName = "CountStudent";
            gcolClassSize.Name = "gcolClassSize";
            gcolClassSize.Visible = true;

             // 
            // gbGender
            // 
            gbGender.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            gbGender.AppearanceHeader.Options.UseFont = true;
            gbGender.AppearanceHeader.Options.UseTextOptions = true;
            gbGender.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gbGender.Caption = "GỚI TÍNH";
            gbGender.Columns.Add(gcolBoy);
            gbGender.Columns.Add(gcolGirl);            
            gbGender.Name = "gbGender";            

            // 
            // gcolBoy
            // 
            gcolBoy.AppearanceHeader.Options.UseTextOptions = true;
            gcolBoy.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolBoy.Caption = "Nam";
            gcolBoy.FieldName = "Boy";
            gcolBoy.Name = "gcolBoy";
            gcolBoy.Visible = true;

            // 
            // gcolGirl
            // 
            gcolGirl.AppearanceHeader.Options.UseTextOptions = true;
            gcolGirl.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolGirl.Caption = "Nữ";
            gcolGirl.FieldName = "Girl";
            gcolGirl.Name = "gcolGirl";
            gcolGirl.Visible = true;
            
            gbClass.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;            
        }

        private void RepairDataAndGrid()
        {
            #region Tôn giáo

            dtbReligion = GEN_ReligionService.Table;
            GridBand band = new GridBand();
            band.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            band.AppearanceHeader.Options.UseFont = true;
            band.AppearanceHeader.Options.UseTextOptions = true;
            band.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            band.Caption = "TÔN GIÁO";
            band.Name = "gbReligion";
            gvData.Bands.Add(band);

            foreach (DataRow drw in dtbReligion.Rows)
            {
                string strID = drw[GEN_Religion.C_ReligionID].ToString();
                if (strID != "")
                {
                    string strFieldName = "Religion_" + strID;

                    dtbData.Columns.Add(strFieldName, typeof(double));

                    BandedGridColumn gcol = new BandedGridColumn();
                    gcol.AppearanceHeader.Options.UseTextOptions = true;
                    gcol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gcol.Caption = drw[GEN_Religion.C_ReligionName].ToString();
                    gcol.FieldName = strFieldName;
                    gcol.Name = "gcol" + strFieldName;
                    gcol.Visible = true;

                    gvData.Columns.Add(gcol);
                    band.Columns.Add(gcol);
                }
            }

            #endregion

            #region Dân tộc


            dtbEthnicity = GEN_EthnicityService.Table;
            string[] types = { "1", "0", "2" };
            string[] titles = { "Dân tộc phía Nam", "Kinh", "Dân tộc phía Bắc" };
            for (int t = 0; t < 3; t++)
            {
                DataRow[] rows = dtbEthnicity.Select("Type = " + types[t]);
                if (rows.Length > 0)
                {
                    GridBand gbType = new GridBand();
                    gbType.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
                    gbType.AppearanceHeader.Options.UseFont = true;
                    gbType.AppearanceHeader.Options.UseTextOptions = true;
                    gbType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gbType.Caption = titles[t];
                    gbType.Name = "gbEthnity" + types[t];
                    gvData.Bands.Add(gbType);

                    foreach (DataRow drw in rows)
                    {
                        string strEthicinityID = drw[GEN_Ethnicity.C_EthnicityID].ToString().Trim();
                        string strFieldName = "Ethnicity_" + strEthicinityID;

                        dtbData.Columns.Add(strFieldName, typeof(double));

                        BandedGridColumn gcol = new BandedGridColumn();
                        gcol.AppearanceHeader.Options.UseTextOptions = true;
                        gcol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gcol.Caption = drw[GEN_Ethnicity.C_EthnicityName].ToString();
                        gcol.FieldName = strFieldName;
                        gcol.Name = "gcol" + strFieldName;
                        gcol.Visible = true;

                        gvData.Columns.Add(gcol);
                        gbType.Columns.Add(gcol);
                    }
                }
            }

            #endregion
        }  

        private void FillData()
        {

            foreach (DataRow drw in dtbData.Rows)
            {
                DataRow[] rows = dtbStudentEthnicity.Select("ClassID='" + drw["ClassID"].ToString() + "'");
                foreach (DataRow drw2 in rows)
                {
                    //drw["Ethnicity_" + drw2["EthnicityID"].ToString().Trim()] = drw2["Counter"];
                }

                rows = dtbStudentReligion.Select("ClassID='" + drw["ClassID"].ToString() + "'");
                foreach (DataRow drw2 in rows)
                {
                    //drw["Religion_" + drw2["ReligionID"].ToString().Trim()] = drw2["Counter"];
                }
            }
        }
     
        private void ModifyGrid()
        {

          

        }                   

        private void ExportToHTML()
        {
            string strHead = HeaderToHTML();

            string strFileName = "SubjectMarkDetail.htm";

            string str = "";
            string strRow = "";          

            int n = gvData.RowCount;
            int m = gvData.Columns.Count;
            
            for (int i = n - 1; i >= 0; i--)
            {                
                DataRow drw = gvData.GetDataRow(i);                
                strRow = "";

                for (int j = 0; j < m; j++)
                {
                    string strColumn=gvData.Columns[j].FieldName;
                    if (gvData.Columns[j].Visible)
                    {
                        string strStyle = "";
                        string strValue = drw[gvData.Columns[j].FieldName].ToString();
                        if (strValue.Length < 1)
                            strValue = "&nbsp;";
                        if (strColumn == "StudentFirstName")
                            strStyle = " style='text-align:left; border-right:none; min-width:100px' ";
                        else if (strColumn == "StudentCode")
                            strStyle = " style='min-width:60px' ";
                        else if (strColumn == "EthicLevel")
                            strStyle = " style='min-width:50px' ";
                        else if (strColumn == "LearningLevel")
                            strStyle = " style='min-width:50px' ";
                        else if (strColumn == "StudentLastName")
                            strStyle = " style='text-align:left; border-left:none' ";
                        
                        strRow += "<td " + strStyle + ">" + strValue + "</td>";
                    }
                }
                strRow = "<tr>" + strRow + "</tr>\r\n";
                str = strRow + str;
            }

            
            str = "<table>" + strHead + str +  "</table>";

            //cộng thêm thống kê
            str += "</br>" + StatisticToHTML();

            string strTitle = "<table><tr><td colspan='2'>BẢNG TỔNG KẾT ĐIỂM ";           


            string strFileContent = Libs.Files.ReadFile(strFileName);            
            strFileContent = strFileContent.Replace("{TITLE}", strTitle);
            strFileContent = strFileContent.Replace("{DETAIL}", str);

            strFileContent = strFileContent.Replace("{HEADER}", strReport_Header);
            strFileContent = strFileContent.Replace("{PLACE}", strReport_Place);

            string strFileNameAs =  "_" + strFileName;
            Libs.Files.WriteFile(strFileNameAs, strFileContent);
            System.Diagnostics.Process.Start(strFileNameAs);
        }        
        
        private string HeaderToHTML()
        {
            string strRow0 = "<tr style='background-color:#cccccc; font-weight:bold'>";
            string strRow1 = "<tr style='background-color:#cccccc; font-weight:bold'>";
            string strRow2 = "<tr style='background-color:#cccccc; font-weight:bold'>";
            
            int intColspan0 = 1, intColspan1=1;
            GridBand prevBand0 = null, prevBand1 = null;

            // tiêu đề cấp 2
            foreach (BandedGridColumn gcol in gvData.Columns)
            {
                if (!gcol.Visible)
                    continue;

                if(gcol.FieldName=="StudentFirstName")
                    strRow2 += "<td colspan='2'>Họ và tên</td>";                    
                else if(gcol.FieldName!="StudentLastName")                
                    strRow2 += "<td>" + gcol.Caption + "</td>";


                // tiêu đề cấp 1
                GridBand band1 = gcol.OwnerBand;
                if (prevBand1 == null)
                {
                    prevBand1 = band1;
                }
                else
                {

                    // nếu qua band mới thì xử band cũ của cấp 1
                    if (prevBand1.Name != band1.Name)
                    {
                        if (prevBand1.BandLevel == 1) // đúng band cấp 1 thì cộng vô
                        {
                            strRow1 += "<td colspan='" + intColspan1.ToString() + "'>" + prevBand1.Caption + "</td>";

                            // rồi tính tiếp cho cấp 0
                            GridBand band0 = band1.ParentBand;
                            if (prevBand0 == null)
                            {
                                prevBand0 = band0;
                            }
                            else
                            {

                                if (prevBand0.Name != band0.Name) //    cộng dồn vào tiêu đề cấp 0
                                {
                                    strRow0 += "<td colspan='" + intColspan0.ToString() + "' >" + prevBand0.Caption + "</td>";
                                    intColspan0 = 0;
                                    prevBand0 = band0;
                                }
                            }
                        }
                        else // nếu cấp 0 luôn rồi thì cho vào tiều đề cấp 0
                        {
                            strRow0 += "<td colspan='" + intColspan0.ToString() + "' rowspan='2' >" + prevBand1.Caption + "</td>";
                            intColspan0 = 0;
                        }

                        // reset colpan cho tieu đề cấp 1
                        intColspan1 = 1;
                        prevBand1 = band1;
                    }
                    else
                        intColspan1++; // tăng colspan                
                    intColspan0++;
                }

            }

            strRow0 += "<td colspan='" + intColspan0.ToString() + "' >" + prevBand0.Caption + "</td>";
            strRow1 += "<td colspan='" + intColspan1.ToString() + "'>" + prevBand1.Caption + "</td>";

            strRow0 += "</tr>\r\n";
            strRow1 += "</tr>\r\n";
            strRow2 += "</tr>\r\n";

            return strRow0 + strRow1 + strRow2;
        }

        private string StatisticToHTML()
        {
            double dblCount = gvData.RowCount;
            string[] strCaption = { "Xuất sắc", "Giỏi", "Khá", "TB khá", "Trung bình", "Yếu kém" };
            string strRow = "<table><tr>";
            for (int i = 0; i < 6; i++)
            {
                strRow += "<td style='background-color:#cccccc;'>" + strCaption[i] + "</td><td>";                  
            }
            strRow += "</tr></table>";

            return strRow;
        }

        #endregion


        #region Form Actions

        private void frmMakeStudentCode_Load(object sender, EventArgs e)
        {

            CheckPermission();
            SetToolTip();
            LoadReferenceData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

       
       
        private void gvData_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {  
                                    
        }
      
     
        private void btnPrint_Click(object sender, EventArgs e)
        {
            //ExportToHTML();
        }

        private void mnuItemExportToExcel_Click(object sender, EventArgs e)
        {
            gvData.QuickExportToExcel();
        }       
        
        #endregion

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            gvData.QuickExportToExcel();
        }

    }
}