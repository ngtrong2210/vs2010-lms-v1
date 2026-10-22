namespace StudentManager.Learning
{
    partial class frmSubjectMark
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSubjectMark));
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.uClass = new TrainingPlan.FramePlan.UClass1();
            this.gcSummary = new Control.DgGridControl();
            this.mnuPopupGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuItem_QuickRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnu_DanhSach = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_DanhSachGiuaKy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_IsRetest = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_IsReLearning = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemPrint_DiemQuaTrinh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_DanhSachCuoiKy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemPrint_TongKet2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemPrintScan1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemPrintScan11 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemPrintScan13 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemPrintScan15 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemPrintScan2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemPrintScan22 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemPrintScan24 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemPrintScan26 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemExportTemplateExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemImportFromExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemReTotalRow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemDeleteAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.gvSummary = new Control.DgGridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtMark1Number = new Control.UCalcEdit();
            this.btnSave = new Control.DgButton();
            this.btnSearch = new Control.DgButton();
            this.txtMark2Number = new Control.UCalcEdit();
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gcData = new Control.DgGridControl();
            this.gvData = new Control.DgAdvBandedGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSummary)).BeginInit();
            this.mnuPopupGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSummary)).BeginInit();
            this.dockPanel2.SuspendLayout();
            this.dockPanel2_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).BeginInit();
            this.SuspendLayout();
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1,
            this.dockPanel2});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.ID = new System.Guid("02219bdd-a6dc-4a42-8ac7-960bcb8240ce");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(247, 200);
            this.dockPanel1.Size = new System.Drawing.Size(247, 538);
            this.dockPanel1.Text = "Tìm kiếm";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.uClass);
            this.dockPanel1_Container.Controls.Add(this.gcSummary);
            this.dockPanel1_Container.Controls.Add(this.txtMark1Number);
            this.dockPanel1_Container.Controls.Add(this.btnSave);
            this.dockPanel1_Container.Controls.Add(this.btnSearch);
            this.dockPanel1_Container.Controls.Add(this.txtMark2Number);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(239, 511);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // uClass
            // 
            this.uClass.BranchEditValue = null;
            this.uClass.ClassEdit = null;
            this.uClass.ClassFilter = "";
            this.uClass.ClassIDEditValue = null;
            this.uClass.ClassSubject = null;
            this.uClass.ClassSubjectFilter = "";
            this.uClass.ClassSubjectIDEditValue = null;
            this.uClass.CourseIDEditValue = null;
            this.uClass.EditorLeft = 90;
            this.uClass.IsOnlyClass = false;
            this.uClass.IsRegulation43 = false;
            this.uClass.Location = new System.Drawing.Point(4, 5);
            this.uClass.Name = "uClass";
            this.uClass.OfficeIDEditValue = null;
            this.uClass.ReadOnly = false;
            this.uClass.ScienceFilter = "";
            this.uClass.ScienceIDEditValue = null;
            this.uClass.Semester = null;
            this.uClass.Size = new System.Drawing.Size(232, 302);
            this.uClass.SpecialBranchIDEditValue = null;
            this.uClass.SpecialBranchSubjectIDEditValue = null;
            this.uClass.TabIndex = 60;
            this.uClass.TrainingLevelIDEditValue = null;
            this.uClass.TrainingTypeEditValue = null;
            this.uClass.YearID = null;
            this.uClass.ClassSubjectChanged += new TrainingPlan.FramePlan.UClass1.ClassSubjectChangedDelegate(this.uClass_EditValueChanged);
            // 
            // gcSummary
            // 
            this.gcSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gcSummary.ContextMenuStrip = this.mnuPopupGrid;
            this.gcSummary.EnterMoveNextControl = true;
            this.gcSummary.Location = new System.Drawing.Point(0, 368);
            this.gcSummary.MainView = this.gvSummary;
            this.gcSummary.Name = "gcSummary";
            this.gcSummary.Size = new System.Drawing.Size(240, 144);
            this.gcSummary.TabIndex = 34;
            this.gcSummary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSummary});
            // 
            // mnuPopupGrid
            // 
            this.mnuPopupGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItem_QuickRegister,
            this.mnuItemSave,
            this.toolStripSeparator3,
            this.mnu_DanhSach,
            this.mnuItemExportToExcel,
            this.mnuItemExportTemplateExcel,
            this.toolStripSeparator5,
            this.mnuItemImportFromExcel,
            this.mnuItemReTotalRow,
            this.mnuItemRefresh,
            this.toolStripSeparator2,
            this.mnuItemDelete,
            this.mnuItemDeleteAll,
            this.toolStripSeparator4,
            this.mnuItemClose});
            this.mnuPopupGrid.Name = "mnuPopupGrid";
            this.mnuPopupGrid.Size = new System.Drawing.Size(218, 270);
            // 
            // mnuItem_QuickRegister
            // 
            this.mnuItem_QuickRegister.Enabled = false;
            this.mnuItem_QuickRegister.ForeColor = System.Drawing.Color.Blue;
            this.mnuItem_QuickRegister.Image = global::StudentManager.Properties.Resources.AddEvent;
            this.mnuItem_QuickRegister.Name = "mnuItem_QuickRegister";
            this.mnuItem_QuickRegister.Size = new System.Drawing.Size(217, 22);
            this.mnuItem_QuickRegister.Text = "Thêm đăng ký học";
            this.mnuItem_QuickRegister.Click += new System.EventHandler(this.mnuItem_QuickRegister_Click);
            // 
            // mnuItemSave
            // 
            this.mnuItemSave.Enabled = false;
            this.mnuItemSave.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemSave.Image")));
            this.mnuItemSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuItemSave.Name = "mnuItemSave";
            this.mnuItemSave.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.mnuItemSave.Size = new System.Drawing.Size(217, 22);
            this.mnuItemSave.Text = "Cập nhật";
            this.mnuItemSave.Visible = false;
            this.mnuItemSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(214, 6);
            // 
            // mnu_DanhSach
            // 
            this.mnu_DanhSach.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_DanhSachGiuaKy,
            this.mnu_IsRetest,
            this.mnu_IsReLearning,
            this.mnuItemPrint_DiemQuaTrinh,
            this.mnu_DanhSachCuoiKy,
            this.mnuItemPrint_TongKet2,
            this.mnuItemPrintScan1,
            this.mnuItemPrintScan2});
            this.mnu_DanhSach.Name = "mnu_DanhSach";
            this.mnu_DanhSach.Size = new System.Drawing.Size(217, 22);
            this.mnu_DanhSach.Text = "In danh sách";
            // 
            // mnu_DanhSachGiuaKy
            // 
            this.mnu_DanhSachGiuaKy.Name = "mnu_DanhSachGiuaKy";
            this.mnu_DanhSachGiuaKy.Size = new System.Drawing.Size(281, 22);
            this.mnu_DanhSachGiuaKy.Text = "Bảng điểm chi tiết";
            this.mnu_DanhSachGiuaKy.Click += new System.EventHandler(this.mnu_DanhSachGiuaKy_Click);
            // 
            // mnu_IsRetest
            // 
            this.mnu_IsRetest.Name = "mnu_IsRetest";
            this.mnu_IsRetest.Size = new System.Drawing.Size(281, 22);
            this.mnu_IsRetest.Text = "Bảng điểm chi tiết thi lại";
            this.mnu_IsRetest.Click += new System.EventHandler(this.mnu_IsRetest_Click);
            // 
            // mnu_IsReLearning
            // 
            this.mnu_IsReLearning.Name = "mnu_IsReLearning";
            this.mnu_IsReLearning.Size = new System.Drawing.Size(281, 22);
            this.mnu_IsReLearning.Text = "Bảng điểm chi tiết học lại";
            this.mnu_IsReLearning.Click += new System.EventHandler(this.mnu_IsReLearning_Click);
            // 
            // mnuItemPrint_DiemQuaTrinh
            // 
            this.mnuItemPrint_DiemQuaTrinh.Name = "mnuItemPrint_DiemQuaTrinh";
            this.mnuItemPrint_DiemQuaTrinh.Size = new System.Drawing.Size(281, 22);
            this.mnuItemPrint_DiemQuaTrinh.Text = "Bảng điểm ngắn hạn";
            this.mnuItemPrint_DiemQuaTrinh.Visible = false;
            this.mnuItemPrint_DiemQuaTrinh.Click += new System.EventHandler(this.mnuItemPrint_DiemQuaTrinh_Click);
            // 
            // mnu_DanhSachCuoiKy
            // 
            this.mnu_DanhSachCuoiKy.Name = "mnu_DanhSachCuoiKy";
            this.mnu_DanhSachCuoiKy.Size = new System.Drawing.Size(281, 22);
            this.mnu_DanhSachCuoiKy.Text = "Bảng điểm tổng kết";
            this.mnu_DanhSachCuoiKy.Visible = false;
            this.mnu_DanhSachCuoiKy.Click += new System.EventHandler(this.mnu_DanhSachCuoiKy_Click);
            // 
            // mnuItemPrint_TongKet2
            // 
            this.mnuItemPrint_TongKet2.Name = "mnuItemPrint_TongKet2";
            this.mnuItemPrint_TongKet2.Size = new System.Drawing.Size(281, 22);
            this.mnuItemPrint_TongKet2.Text = "Bảng điểm tổng kết 2";
            this.mnuItemPrint_TongKet2.Visible = false;
            this.mnuItemPrint_TongKet2.Click += new System.EventHandler(this.mnuItemPrint_TongKet2_Click);
            // 
            // mnuItemPrintScan1
            // 
            this.mnuItemPrintScan1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemPrintScan11,
            this.mnuItemPrintScan13,
            this.mnuItemPrintScan15});
            this.mnuItemPrintScan1.Name = "mnuItemPrintScan1";
            this.mnuItemPrintScan1.Size = new System.Drawing.Size(281, 22);
            this.mnuItemPrintScan1.Text = "Kiểm tra thường xuyên (Hệ số 1) - Scan";
            this.mnuItemPrintScan1.Visible = false;
            // 
            // mnuItemPrintScan11
            // 
            this.mnuItemPrintScan11.Name = "mnuItemPrintScan11";
            this.mnuItemPrintScan11.Size = new System.Drawing.Size(96, 22);
            this.mnuItemPrintScan11.Text = "Tờ 1";
            this.mnuItemPrintScan11.Click += new System.EventHandler(this.mnuItemPrintScan_Click);
            // 
            // mnuItemPrintScan13
            // 
            this.mnuItemPrintScan13.Name = "mnuItemPrintScan13";
            this.mnuItemPrintScan13.Size = new System.Drawing.Size(96, 22);
            this.mnuItemPrintScan13.Text = "Tờ 2";
            this.mnuItemPrintScan13.Click += new System.EventHandler(this.mnuItemPrintScan_Click);
            // 
            // mnuItemPrintScan15
            // 
            this.mnuItemPrintScan15.Name = "mnuItemPrintScan15";
            this.mnuItemPrintScan15.Size = new System.Drawing.Size(96, 22);
            this.mnuItemPrintScan15.Text = "Tờ 3";
            this.mnuItemPrintScan15.Click += new System.EventHandler(this.mnuItemPrintScan_Click);
            // 
            // mnuItemPrintScan2
            // 
            this.mnuItemPrintScan2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemPrintScan22,
            this.mnuItemPrintScan24,
            this.mnuItemPrintScan26});
            this.mnuItemPrintScan2.Name = "mnuItemPrintScan2";
            this.mnuItemPrintScan2.Size = new System.Drawing.Size(281, 22);
            this.mnuItemPrintScan2.Text = "Kiểm tra định kỳ (Hệ số 2) - Scan";
            this.mnuItemPrintScan2.Visible = false;
            // 
            // mnuItemPrintScan22
            // 
            this.mnuItemPrintScan22.Name = "mnuItemPrintScan22";
            this.mnuItemPrintScan22.Size = new System.Drawing.Size(96, 22);
            this.mnuItemPrintScan22.Text = "Tờ 1";
            this.mnuItemPrintScan22.Click += new System.EventHandler(this.mnuItemPrintScan_Click);
            // 
            // mnuItemPrintScan24
            // 
            this.mnuItemPrintScan24.Name = "mnuItemPrintScan24";
            this.mnuItemPrintScan24.Size = new System.Drawing.Size(96, 22);
            this.mnuItemPrintScan24.Text = "Tờ 2";
            this.mnuItemPrintScan24.Click += new System.EventHandler(this.mnuItemPrintScan_Click);
            // 
            // mnuItemPrintScan26
            // 
            this.mnuItemPrintScan26.Name = "mnuItemPrintScan26";
            this.mnuItemPrintScan26.Size = new System.Drawing.Size(96, 22);
            this.mnuItemPrintScan26.Text = "Tờ 3";
            this.mnuItemPrintScan26.Click += new System.EventHandler(this.mnuItemPrintScan_Click);
            // 
            // mnuItemExportToExcel
            // 
            this.mnuItemExportToExcel.Image = global::StudentManager.Properties.Resources.excel;
            this.mnuItemExportToExcel.Name = "mnuItemExportToExcel";
            this.mnuItemExportToExcel.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.mnuItemExportToExcel.Size = new System.Drawing.Size(217, 22);
            this.mnuItemExportToExcel.Text = "Xuất excel";
            this.mnuItemExportToExcel.Click += new System.EventHandler(this.mnuItemExportToExcel_Click);
            // 
            // mnuItemExportTemplateExcel
            // 
            this.mnuItemExportTemplateExcel.Name = "mnuItemExportTemplateExcel";
            this.mnuItemExportTemplateExcel.Size = new System.Drawing.Size(217, 22);
            this.mnuItemExportTemplateExcel.Text = "Xuất excel theo mẫu";
            this.mnuItemExportTemplateExcel.Click += new System.EventHandler(this.mnuItemExportTemplateExcel_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(214, 6);
            // 
            // mnuItemImportFromExcel
            // 
            this.mnuItemImportFromExcel.Enabled = false;
            this.mnuItemImportFromExcel.Name = "mnuItemImportFromExcel";
            this.mnuItemImportFromExcel.Size = new System.Drawing.Size(217, 22);
            this.mnuItemImportFromExcel.Text = "Nhập từ excel";
            this.mnuItemImportFromExcel.Click += new System.EventHandler(this.mnuItemImportFromExcel_Click);
            // 
            // mnuItemReTotalRow
            // 
            this.mnuItemReTotalRow.Enabled = false;
            this.mnuItemReTotalRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.mnuItemReTotalRow.Image = global::StudentManager.Properties.Resources.Process3;
            this.mnuItemReTotalRow.Name = "mnuItemReTotalRow";
            this.mnuItemReTotalRow.Size = new System.Drawing.Size(217, 22);
            this.mnuItemReTotalRow.Text = "Xử lý lại điểm theo quy chế";
            this.mnuItemReTotalRow.Click += new System.EventHandler(this.mnuItemReTotalRow_Click);
            // 
            // mnuItemRefresh
            // 
            this.mnuItemRefresh.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemRefresh.Image")));
            this.mnuItemRefresh.Name = "mnuItemRefresh";
            this.mnuItemRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnuItemRefresh.Size = new System.Drawing.Size(217, 22);
            this.mnuItemRefresh.Text = "Nạp lại";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(214, 6);
            // 
            // mnuItemDelete
            // 
            this.mnuItemDelete.Enabled = false;
            this.mnuItemDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mnuItemDelete.Image = global::StudentManager.Properties.Resources.Delete;
            this.mnuItemDelete.Name = "mnuItemDelete";
            this.mnuItemDelete.Size = new System.Drawing.Size(217, 22);
            this.mnuItemDelete.Text = "Xoá sổ điểm";
            this.mnuItemDelete.Click += new System.EventHandler(this.mnuItemDelete_Click);
            // 
            // mnuItemDeleteAll
            // 
            this.mnuItemDeleteAll.Enabled = false;
            this.mnuItemDeleteAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mnuItemDeleteAll.Image = global::StudentManager.Properties.Resources.Delete;
            this.mnuItemDeleteAll.Name = "mnuItemDeleteAll";
            this.mnuItemDeleteAll.Size = new System.Drawing.Size(217, 22);
            this.mnuItemDeleteAll.Text = "Xoá tất cả";
            this.mnuItemDeleteAll.Click += new System.EventHandler(this.mnuItemDeleteAll_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(214, 6);
            // 
            // mnuItemClose
            // 
            this.mnuItemClose.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemClose.Image")));
            this.mnuItemClose.Name = "mnuItemClose";
            this.mnuItemClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuItemClose.Size = new System.Drawing.Size(217, 22);
            this.mnuItemClose.Text = "Đóng";
            this.mnuItemClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gvSummary
            // 
            this.gvSummary.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gvSummary.GridControl = this.gcSummary;
            this.gvSummary.IndicatorWidth = 35;
            this.gvSummary.IsSelecting = false;
            this.gvSummary.LanguageID = 1;
            this.gvSummary.Name = "gvSummary";
            this.gvSummary.OptionsSelection.MultiSelect = true;
            this.gvSummary.OptionsView.ShowAutoFilterRow = true;
            this.gvSummary.OptionsView.ShowGroupPanel = false;
            this.gvSummary.OptionsView.ShowIndicator = false;
            this.gvSummary.ResetGridColumn = true;
            this.gvSummary.RowFilter = "";
            this.gvSummary.SummaryCollection = "";
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "Phân loại";
            this.gridColumn1.FieldName = "Title";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 120;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Số lượng";
            this.gridColumn2.DisplayFormat.FormatString = "#,##";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn2.FieldName = "Quantity";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 61;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Tỉ lệ (%)";
            this.gridColumn3.DisplayFormat.FormatString = "#,##";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn3.FieldName = "Percent";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 62;
            // 
            // txtMark1Number
            // 
            this.txtMark1Number.Caption = "Số cột HS1:";
            this.txtMark1Number.DisplayMask = "#,###";
            this.txtMark1Number.EditMask = "";
            this.txtMark1Number.EditorLeft = 90;
            this.txtMark1Number.EditValue = ((long)(0));
            this.txtMark1Number.EditValueDouble = 0D;
            this.txtMark1Number.EditValueInt32 = 0;
            this.txtMark1Number.EditValueInt64 = ((long)(0));
            this.txtMark1Number.Location = new System.Drawing.Point(4, 313);
            this.txtMark1Number.MaxLength = 0;
            this.txtMark1Number.Name = "txtMark1Number";
            this.txtMark1Number.ReadOnly = true;
            this.txtMark1Number.Size = new System.Drawing.Size(141, 21);
            this.txtMark1Number.TabIndex = 59;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Image = global::StudentManager.Properties.Resources.Save;
            this.btnSave.Location = new System.Drawing.Point(116, 339);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(114, 23);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Cập nhật";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::StudentManager.Properties.Resources.Search;
            this.btnSearch.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(4, 338);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(106, 23);
            this.btnSearch.TabIndex = 23;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtMark2Number
            // 
            this.txtMark2Number.Caption = " HS2:";
            this.txtMark2Number.DisplayMask = "#,###";
            this.txtMark2Number.EditMask = "";
            this.txtMark2Number.EditorLeft = 35;
            this.txtMark2Number.EditValue = ((long)(0));
            this.txtMark2Number.EditValueDouble = 0D;
            this.txtMark2Number.EditValueInt32 = 0;
            this.txtMark2Number.EditValueInt64 = ((long)(0));
            this.txtMark2Number.Location = new System.Drawing.Point(151, 313);
            this.txtMark2Number.MaxLength = 0;
            this.txtMark2Number.Name = "txtMark2Number";
            this.txtMark2Number.ReadOnly = true;
            this.txtMark2Number.Size = new System.Drawing.Size(84, 21);
            this.txtMark2Number.TabIndex = 58;
            // 
            // dockPanel2
            // 
            this.dockPanel2.Controls.Add(this.dockPanel2_Container);
            this.dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel2.ID = new System.Guid("5702986f-33f0-4dca-8fbc-e2d48a1e6fbd");
            this.dockPanel2.Location = new System.Drawing.Point(247, 0);
            this.dockPanel2.Name = "dockPanel2";
            this.dockPanel2.Options.ShowAutoHideButton = false;
            this.dockPanel2.Options.ShowCloseButton = false;
            this.dockPanel2.OriginalSize = new System.Drawing.Size(682, 200);
            this.dockPanel2.Size = new System.Drawing.Size(682, 538);
            this.dockPanel2.Text = "Dữ liệu";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dockPanel2_Container.Controls.Add(this.gcData);
            this.dockPanel2_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(674, 511);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // gcData
            // 
            this.gcData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gcData.ContextMenuStrip = this.mnuPopupGrid;
            this.gcData.EnterMoveNextControl = true;
            this.gcData.Location = new System.Drawing.Point(-1, 0);
            this.gcData.MainView = this.gvData;
            this.gcData.Name = "gcData";
            this.gcData.Size = new System.Drawing.Size(676, 512);
            this.gcData.TabIndex = 23;
            this.gcData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvData});
            // 
            // gvData
            // 
            this.gvData.Appearance.FocusedCell.BackColor = System.Drawing.Color.Transparent;
            this.gvData.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.Transparent;
            this.gvData.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvData.Appearance.RowSeparator.BackColor = System.Drawing.SystemColors.ControlDark;
            this.gvData.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gvData.CustomizationFormBounds = new System.Drawing.Rectangle(1048, 450, 223, 215);
            this.gvData.GridControl = this.gcData;
            this.gvData.IndicatorWidth = 35;
            this.gvData.IsSelecting = false;
            this.gvData.LanguageID = 1;
            this.gvData.Name = "gvData";
            this.gvData.OptionsCustomization.AllowBandMoving = false;
            this.gvData.OptionsCustomization.AllowColumnMoving = false;
            this.gvData.OptionsCustomization.AllowGroup = false;
            this.gvData.OptionsCustomization.AllowQuickHideColumns = false;
            this.gvData.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gvData.OptionsSelection.InvertSelection = true;
            this.gvData.OptionsSelection.MultiSelect = true;
            this.gvData.OptionsView.ShowGroupPanel = false;
            this.gvData.ResetGridColumn = true;
            this.gvData.RowFilter = "";
            this.gvData.RowSeparatorHeight = 1;
            this.gvData.SummaryCollection = "";
            this.gvData.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gvData_CustomDrawCell);
            this.gvData.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvData_RowCellStyle);
            this.gvData.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvData_ValidateRow);
            this.gvData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvData_KeyDown);
            this.gvData.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gvData_ValidatingEditor);
            // 
            // frmSubjectMark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 538);
            this.Controls.Add(this.dockPanel2);
            this.Controls.Add(this.dockPanel1);
            this.Name = "frmSubjectMark";
            this.ShowIcon = false;
            this.Text = "Sổ điểm sinh viên";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSubjectMark_FormClosing);
            this.Load += new System.EventHandler(this.frmMakeStudentCode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcSummary)).EndInit();
            this.mnuPopupGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvSummary)).EndInit();
            this.dockPanel2.ResumeLayout(false);
            this.dockPanel2_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel2;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private Control.DgButton btnSearch;
        private Control.DgButton btnSave;
        private System.Windows.Forms.ContextMenuStrip mnuPopupGrid;
        private System.Windows.Forms.ToolStripMenuItem mnuItemSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuItemRefresh;
        private System.Windows.Forms.ToolStripMenuItem mnuItemExportToExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuItemClose;
        private Control.DgGridControl gcData;
        private Control.DgAdvBandedGridView gvData;
        private System.Windows.Forms.ToolStripMenuItem mnuItemImportFromExcel;
        private System.Windows.Forms.ToolStripMenuItem mnu_DanhSach;
        private System.Windows.Forms.ToolStripMenuItem mnu_DanhSachGiuaKy;
        private System.Windows.Forms.ToolStripMenuItem mnu_DanhSachCuoiKy;
        private System.Windows.Forms.ToolStripMenuItem mnuItemExportTemplateExcel;
        private Control.UCalcEdit txtMark2Number;
        private System.Windows.Forms.ToolStripMenuItem mnuItemDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPrintScan1;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPrintScan2;
        private Control.UCalcEdit txtMark1Number;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPrintScan11;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPrintScan13;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPrintScan15;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPrintScan22;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPrintScan24;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPrintScan26;
        private Control.DgGridControl gcSummary;
        private Control.DgGridView gvSummary;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPrint_DiemQuaTrinh;
        private System.Windows.Forms.ToolStripMenuItem mnuItemDeleteAll;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPrint_TongKet2;
        private TrainingPlan.FramePlan.UClass1 uClass;
        private System.Windows.Forms.ToolStripMenuItem mnu_IsReLearning;
        private System.Windows.Forms.ToolStripMenuItem mnu_IsRetest;
        private System.Windows.Forms.ToolStripMenuItem mnuItem_QuickRegister;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem mnuItemReTotalRow;
    }
}