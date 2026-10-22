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
using DataAccess;
namespace StudentManager.StudentCollection
{
    public partial class frmStudentCollectionStatistic : FormBase, IForm
    {
        #region Consts
        
        public const string PERMISSION_VIEW = "SIM_StudentCollectionStatistic_View";

        #endregion

        #region Variable
                
        DataTable dtbData;
        DataTable dtbEthnicity; // dan toc 
        DataTable dtbReligion; // tôn giáo

        DataTable dtbStudentCollection; // Sinh viên
        bool bolIsFirstSearch = true;
        
        private string strReport_Header = "";
        private string strReport_Place = "";

        private bool bolHaveNormalSubject = false; // có môn bình thường trong cả kì hay năm không, có thì chỉ tính môn bình thường, không thì chỉ tính môn văn hoá        

        #endregion

        #region IForm Members

        private static frmStudentCollectionStatistic _instance = null;

        public static frmStudentCollectionStatistic Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmStudentCollectionStatistic();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmStudentCollectionStatistic()
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
            uPeriod.InitData();
            uSpecialBranch.InitData();            
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
                int? intResult = null;
                if (cbxResult.SelectedIndex == 1)
                    intResult = 1;
                else if (cbxResult.SelectedIndex == 2)
                    intResult = 0;

                SIM_StudentCollection obj = new SIM_StudentCollection();
                dtbData = obj.GetDataTable("SIM_SpecialBranch_SearchForCollection","@StudentCollectionPeriodIDList", uPeriod.StudentCollectionPeriodIDEditValue); // lấy nghề theo đợt

                dtbStudentCollection = obj.SearchForStatistic(
                            "@StudentCollectionPeriodIDList", uPeriod.StudentCollectionPeriodIDEditValue);
                

                if (dtbData != null)
                {
                    RepairGrid(); // khởi tạo cột cơ bản
                    RepairDataAndGrid(); // khởi tạo môn học vào data và lưới
                    FillData(); // điền điểm vào

                    gcData.DataSource = dtbData;

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
            GridBand gbSpecialBranch = new GridBand();
            BandedGridColumn gcolOrder = new BandedGridColumn();
            BandedGridColumn gcolBranchID = new BandedGridColumn();
            BandedGridColumn gcolBranchName = new BandedGridColumn();
            BandedGridColumn gcolSpecialBranchID = new BandedGridColumn();
            BandedGridColumn gcolSpecialBranchName = new BandedGridColumn();

            gvData.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { gbSpecialBranch });

            gvData.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
                                    gcolOrder,
                                    gcolSpecialBranchID,
                                    gcolSpecialBranchName});

            // 
            // gbSpecialBranch
            // 
            gbSpecialBranch.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            gbSpecialBranch.AppearanceHeader.Options.UseFont = true;
            gbSpecialBranch.AppearanceHeader.Options.UseTextOptions = true;
            gbSpecialBranch.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gbSpecialBranch.Caption = "NGÀNH NGHỀ";
            gbSpecialBranch.Name = "gbSpecialBranch";
            gbSpecialBranch.Width = 300;

            gbSpecialBranch.Columns.Add(gcolOrder);
            
            gbSpecialBranch.Columns.Add(gcolBranchID);
            gbSpecialBranch.Columns.Add(gcolBranchName);

            gbSpecialBranch.Columns.Add(gcolSpecialBranchID);
            gbSpecialBranch.Columns.Add(gcolSpecialBranchName);            

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
            // gcolSpecialBranchID
            // 
            gcolSpecialBranchID.AppearanceHeader.Options.UseTextOptions = true;
            gcolSpecialBranchID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolSpecialBranchID.Caption = "Mã nghề";
            gcolSpecialBranchID.FieldName = "SpecialBranchID";
            gcolSpecialBranchID.Name = "gcolSpecialBranchID";
            gcolSpecialBranchID.Visible = true;

            // 
            // gcolSpecialBranchName
            // 
            gcolSpecialBranchName.AppearanceHeader.Options.UseTextOptions = true;
            gcolSpecialBranchName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolSpecialBranchName.Caption = "Tên nghề";
            gcolSpecialBranchName.FieldName = "SpecialBranchName";
            gcolSpecialBranchName.Name = "gcolSpecialBranchName";
            gcolSpecialBranchName.Visible = true;


            
            gbSpecialBranch.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;            
        }

        private void RepairDataAndGrid()
        {
            

            dtbReligion = GEN_ReligionService.Table;
            GridBand band = new GridBand();
            band.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            band.AppearanceHeader.Options.UseFont = true;
            band.AppearanceHeader.Options.UseTextOptions = true;
            band.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            band.Caption = "NGUYỆN VỌNG";
            band.Name = "gbaspiration";
            gvData.Bands.Add(band);

            for (int i = 1; i < 4;i++ )
            {
                string strNV = "NV" + i ;
                if (strNV != "")
                {
                    dtbData.Columns.Add(strNV, typeof(double));

                    BandedGridColumn gcol = new BandedGridColumn();
                    gcol.AppearanceHeader.Options.UseTextOptions = true;
                    gcol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gcol.Caption = strNV;
                    gcol.FieldName = strNV;
                    gcol.Name = "gcol" + strNV;
                    gcol.Visible = true;

                    gvData.Columns.Add(gcol);
                    band.Columns.Add(gcol);
                }
            }


        }  

        private void FillData()
        {

            foreach (DataRow drw in dtbData.Rows)
            {
                int iSpec1 ; int iSpec2 ; int iSpec3 ;
                iSpec1 = 0; iSpec2 = 0; iSpec3 = 0;
                foreach (DataRow drw2 in dtbStudentCollection.Rows)
                {
                    if (drw2["SpecialBranchID"].ToString() ==drw["SpecialBranchID"].ToString())
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