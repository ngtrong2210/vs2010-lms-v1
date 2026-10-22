namespace StudentManager.RewardSanction
{
    partial class frmSanctionReview
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSanctionReview));
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager();
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.cbxNoPermissionMin = new DevExpress.XtraEditors.ComboBoxEdit();
            this.dgLabel3 = new Control.DgLabel();
            this.dtmToDate = new Control.UDateEdit();
            this.btnSave = new Control.DgButton();
            this.dtmFromDate = new Control.UDateEdit();
            this.uClass = new TrainingPlan.FramePlan.UClass1();
            this.btnPrint = new Control.DgButton();
            this.btnClose = new Control.DgButton();
            this.btnSearch = new Control.DgButton();
            this.uYearSemester = new DeclarationManager.Education.UYearSemester();
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gcData = new Control.DgGridControl();
            this.mnuPopupGrid = new System.Windows.Forms.ContextMenuStrip();
            this.mnuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuQuaTrinhHocTap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemPrint3 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemPrint1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemPrint2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrint8 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrint7 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemPrint4 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemPrint5 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemPrint6 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrint9 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemPrintDS_DeNghiRa_HDKL = new System.Windows.Forms.ToolStripMenuItem();
            this.gvData = new Control.DgGridView();
            this.cbxCouncilNote = new DevExpress.XtraEditors.ComboBoxEdit();
            this.dgLabel1 = new Control.DgLabel();
            this.mnuItemPrint_DSHS_YKHDKL = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxNoPermissionMin.Properties)).BeginInit();
            this.dockPanel2.SuspendLayout();
            this.dockPanel2_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).BeginInit();
            this.mnuPopupGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxCouncilNote.Properties)).BeginInit();
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
            this.dockPanel1.OriginalSize = new System.Drawing.Size(242, 200);
            this.dockPanel1.Size = new System.Drawing.Size(242, 469);
            this.dockPanel1.Text = "Thông tin tìm kiếm";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.cbxCouncilNote);
            this.dockPanel1_Container.Controls.Add(this.cbxNoPermissionMin);
            this.dockPanel1_Container.Controls.Add(this.dgLabel1);
            this.dockPanel1_Container.Controls.Add(this.dgLabel3);
            this.dockPanel1_Container.Controls.Add(this.dtmToDate);
            this.dockPanel1_Container.Controls.Add(this.btnSave);
            this.dockPanel1_Container.Controls.Add(this.dtmFromDate);
            this.dockPanel1_Container.Controls.Add(this.uClass);
            this.dockPanel1_Container.Controls.Add(this.btnPrint);
            this.dockPanel1_Container.Controls.Add(this.btnClose);
            this.dockPanel1_Container.Controls.Add(this.btnSearch);
            this.dockPanel1_Container.Controls.Add(this.uYearSemester);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(234, 442);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // cbxNoPermissionMin
            // 
            this.cbxNoPermissionMin.EditValue = "1";
            this.cbxNoPermissionMin.Location = new System.Drawing.Point(119, 306);
            this.cbxNoPermissionMin.Name = "cbxNoPermissionMin";
            this.cbxNoPermissionMin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxNoPermissionMin.Properties.Items.AddRange(new object[] {
            "1",
            "5",
            "8",
            "15",
            "20",
            "40"});
            this.cbxNoPermissionMin.Properties.NullText = "--Chọn--";
            this.cbxNoPermissionMin.Size = new System.Drawing.Size(112, 20);
            this.cbxNoPermissionMin.TabIndex = 57;
            // 
            // dgLabel3
            // 
            this.dgLabel3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dgLabel3.Location = new System.Drawing.Point(3, 309);
            this.dgLabel3.Name = "dgLabel3";
            this.dgLabel3.Size = new System.Drawing.Size(105, 14);
            this.dgLabel3.TabIndex = 58;
            this.dgLabel3.Text = "Số ngày nghỉ    >=";
            // 
            // dtmToDate
            // 
            this.dtmToDate.Caption = "Đến  ngày:";
            this.dtmToDate.EditorLeft = 90;
            this.dtmToDate.EditValue = null;
            this.dtmToDate.EditValueDateTime = null;
            this.dtmToDate.Location = new System.Drawing.Point(3, 279);
            this.dtmToDate.Name = "dtmToDate";
            this.dtmToDate.ReadOnly = false;
            this.dtmToDate.Size = new System.Drawing.Size(228, 21);
            this.dtmToDate.TabIndex = 56;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Image = global::StudentManager.Properties.Resources.Save;
            this.btnSave.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(119, 387);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 23);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Cập nhật";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtmFromDate
            // 
            this.dtmFromDate.Caption = "Từ ngày:";
            this.dtmFromDate.EditorLeft = 90;
            this.dtmFromDate.EditValue = null;
            this.dtmFromDate.EditValueDateTime = null;
            this.dtmFromDate.Location = new System.Drawing.Point(3, 252);
            this.dtmFromDate.Name = "dtmFromDate";
            this.dtmFromDate.ReadOnly = false;
            this.dtmFromDate.Size = new System.Drawing.Size(228, 21);
            this.dtmFromDate.TabIndex = 55;
            // 
            // uClass
            // 
            this.uClass.BranchEditValue = null;
            this.uClass.ClassFilter = "";
            this.uClass.ClassIDEditValue = null;
            this.uClass.CourseIDEditValue = null;
            this.uClass.EditorLeft = 90;
            this.uClass.IsRegulation43 = false;
            this.uClass.Location = new System.Drawing.Point(3, 3);
            this.uClass.Name = "uClass";
            this.uClass.ReadOnly = false;
            this.uClass.ScienceFilter = "";
            this.uClass.ScienceIDEditValue = null;
            this.uClass.Semester = null;
            this.uClass.Size = new System.Drawing.Size(228, 179);
            this.uClass.SpecialBranchIDEditValue = null;
            this.uClass.SpecialBranchSubjectIDEditValue = null;
            this.uClass.TabIndex = 56;
            this.uClass.TrainingLevelIDEditValue = null;
            this.uClass.TrainingTypeEditValue = null;
            this.uClass.YearID = null;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Enabled = false;
            this.btnPrint.Image = global::StudentManager.Properties.Resources.print;
            this.btnPrint.Location = new System.Drawing.Point(12, 416);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(104, 23);
            this.btnPrint.TabIndex = 55;
            this.btnPrint.Text = "In danh sách";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = global::StudentManager.Properties.Resources.Cancel;
            this.btnClose.Location = new System.Drawing.Point(119, 416);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(104, 23);
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = global::StudentManager.Properties.Resources.Search;
            this.btnSearch.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(12, 387);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(104, 23);
            this.btnSearch.TabIndex = 23;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // uYearSemester
            // 
            this.uYearSemester.EditorLeft = 90;
            this.uYearSemester.Location = new System.Drawing.Point(3, 188);
            this.uYearSemester.Name = "uYearSemester";
            this.uYearSemester.ReadOnly = false;
            this.uYearSemester.SemesterEditValue = null;
            this.uYearSemester.Size = new System.Drawing.Size(228, 48);
            this.uYearSemester.TabIndex = 2;
            this.uYearSemester.YearIDEditValue = null;
            // 
            // dockPanel2
            // 
            this.dockPanel2.Controls.Add(this.dockPanel2_Container);
            this.dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel2.ID = new System.Guid("5702986f-33f0-4dca-8fbc-e2d48a1e6fbd");
            this.dockPanel2.Location = new System.Drawing.Point(242, 0);
            this.dockPanel2.Name = "dockPanel2";
            this.dockPanel2.Options.ShowAutoHideButton = false;
            this.dockPanel2.Options.ShowCloseButton = false;
            this.dockPanel2.OriginalSize = new System.Drawing.Size(687, 200);
            this.dockPanel2.Size = new System.Drawing.Size(687, 469);
            this.dockPanel2.Text = "Danh sách sinh viên";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dockPanel2_Container.Controls.Add(this.gcData);
            this.dockPanel2_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(679, 442);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // gcData
            // 
            this.gcData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gcData.ContextMenuStrip = this.mnuPopupGrid;
            gridLevelNode1.RelationName = "Level1";
            gridLevelNode2.RelationName = "Level2";
            this.gcData.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1,
            gridLevelNode2});
            this.gcData.Location = new System.Drawing.Point(0, 3);
            this.gcData.MainView = this.gvData;
            this.gcData.Name = "gcData";
            this.gcData.Size = new System.Drawing.Size(679, 439);
            this.gcData.TabIndex = 32;
            this.gcData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvData});
            // 
            // mnuPopupGrid
            // 
            this.mnuPopupGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemSave,
            this.toolStripSeparator3,
            this.mnuItemRefresh,
            this.toolStripSeparator1,
            this.mnuQuaTrinhHocTap,
            this.mnuItemExportToExcel,
            this.toolStripSeparator2,
            this.mnuItemClose,
            this.mnuItemPrint3});
            this.mnuPopupGrid.Name = "mnuPopupGrid";
            this.mnuPopupGrid.Size = new System.Drawing.Size(168, 176);
            // 
            // mnuItemSave
            // 
            this.mnuItemSave.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemSave.Image")));
            this.mnuItemSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuItemSave.Name = "mnuItemSave";
            this.mnuItemSave.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.mnuItemSave.Size = new System.Drawing.Size(167, 22);
            this.mnuItemSave.Text = "Lưu";
            this.mnuItemSave.Visible = false;
            this.mnuItemSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(164, 6);
            // 
            // mnuItemRefresh
            // 
            this.mnuItemRefresh.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemRefresh.Image")));
            this.mnuItemRefresh.Name = "mnuItemRefresh";
            this.mnuItemRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnuItemRefresh.Size = new System.Drawing.Size(167, 22);
            this.mnuItemRefresh.Text = "Nạp lại";
            this.mnuItemRefresh.Click += new System.EventHandler(this.mnuItemRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(164, 6);
            // 
            // mnuQuaTrinhHocTap
            // 
            this.mnuQuaTrinhHocTap.Image = global::StudentManager.Properties.Resources.Process3;
            this.mnuQuaTrinhHocTap.Name = "mnuQuaTrinhHocTap";
            this.mnuQuaTrinhHocTap.Size = new System.Drawing.Size(167, 22);
            this.mnuQuaTrinhHocTap.Text = "Quá trình học tập";
            this.mnuQuaTrinhHocTap.Click += new System.EventHandler(this.mnuQuaTrinhHocTap_Click);
            // 
            // mnuItemExportToExcel
            // 
            this.mnuItemExportToExcel.Image = global::StudentManager.Properties.Resources.excel;
            this.mnuItemExportToExcel.Name = "mnuItemExportToExcel";
            this.mnuItemExportToExcel.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.mnuItemExportToExcel.Size = new System.Drawing.Size(167, 22);
            this.mnuItemExportToExcel.Text = "Xuất excel";
            this.mnuItemExportToExcel.Click += new System.EventHandler(this.mnuItemExportToExcel_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(164, 6);
            // 
            // mnuItemClose
            // 
            this.mnuItemClose.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemClose.Image")));
            this.mnuItemClose.Name = "mnuItemClose";
            this.mnuItemClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuItemClose.Size = new System.Drawing.Size(167, 22);
            this.mnuItemClose.Text = "Đóng";
            // 
            // mnuItemPrint3
            // 
            this.mnuItemPrint3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemPrint1,
            this.mnuItemPrint2,
            this.mnuPrint8,
            this.mnuPrint7,
            this.mnuItemPrint4,
            this.mnuItemPrint5,
            this.mnuItemPrint6,
            this.mnuPrint9,
            this.mnuItemPrintDS_DeNghiRa_HDKL,
            this.mnuItemPrint_DSHS_YKHDKL});
            this.mnuItemPrint3.Name = "mnuItemPrint3";
            this.mnuItemPrint3.Size = new System.Drawing.Size(167, 22);
            this.mnuItemPrint3.Text = "In";
            // 
            // mnuItemPrint1
            // 
            this.mnuItemPrint1.Name = "mnuItemPrint1";
            this.mnuItemPrint1.Size = new System.Drawing.Size(271, 22);
            this.mnuItemPrint1.Text = "Danh sách xét kỷ luật";
            this.mnuItemPrint1.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // mnuItemPrint2
            // 
            this.mnuItemPrint2.Name = "mnuItemPrint2";
            this.mnuItemPrint2.Size = new System.Drawing.Size(271, 22);
            this.mnuItemPrint2.Text = "Biên bản hợp đề nghị";
            this.mnuItemPrint2.Click += new System.EventHandler(this.mnuItemPrint2_Click);
            // 
            // mnuPrint8
            // 
            this.mnuPrint8.Name = "mnuPrint8";
            this.mnuPrint8.Size = new System.Drawing.Size(271, 22);
            this.mnuPrint8.Text = "Thư mời";
            this.mnuPrint8.Click += new System.EventHandler(this.mnuPrint8_Click);
            // 
            // mnuPrint7
            // 
            this.mnuPrint7.Name = "mnuPrint7";
            this.mnuPrint7.Size = new System.Drawing.Size(271, 22);
            this.mnuPrint7.Text = "Thông báo";
            this.mnuPrint7.Click += new System.EventHandler(this.mnuPrint7_Click);
            // 
            // mnuItemPrint4
            // 
            this.mnuItemPrint4.Name = "mnuItemPrint4";
            this.mnuItemPrint4.Size = new System.Drawing.Size(271, 22);
            this.mnuItemPrint4.Text = "Khiển trách";
            this.mnuItemPrint4.Click += new System.EventHandler(this.mnuItemPrint4_Click);
            // 
            // mnuItemPrint5
            // 
            this.mnuItemPrint5.Name = "mnuItemPrint5";
            this.mnuItemPrint5.Size = new System.Drawing.Size(271, 22);
            this.mnuItemPrint5.Text = "Cảnh cáo";
            this.mnuItemPrint5.Click += new System.EventHandler(this.mnuItemPrint5_Click);
            // 
            // mnuItemPrint6
            // 
            this.mnuItemPrint6.Name = "mnuItemPrint6";
            this.mnuItemPrint6.Size = new System.Drawing.Size(271, 22);
            this.mnuItemPrint6.Text = "Thôi học";
            this.mnuItemPrint6.Click += new System.EventHandler(this.mnuItemPrint6_Click);
            // 
            // mnuPrint9
            // 
            this.mnuPrint9.Name = "mnuPrint9";
            this.mnuPrint9.Size = new System.Drawing.Size(271, 22);
            this.mnuPrint9.Text = "Thống kê số buổi vắng";
            this.mnuPrint9.Click += new System.EventHandler(this.mnuPrint9_Click);
            // 
            // mnuItemPrintDS_DeNghiRa_HDKL
            // 
            this.mnuItemPrintDS_DeNghiRa_HDKL.Name = "mnuItemPrintDS_DeNghiRa_HDKL";
            this.mnuItemPrintDS_DeNghiRa_HDKL.Size = new System.Drawing.Size(271, 22);
            this.mnuItemPrintDS_DeNghiRa_HDKL.Text = "Danh sách đề nghị ra HĐKL";
            this.mnuItemPrintDS_DeNghiRa_HDKL.Click += new System.EventHandler(this.mnuItemPrintDS_DeNghiRa_HDKL_Click);
            // 
            // gvData
            // 
            this.gvData.GridControl = this.gcData;
            this.gvData.IsSelecting = false;
            this.gvData.Name = "gvData";
            this.gvData.OptionsSelection.MultiSelect = true;
            this.gvData.OptionsView.ColumnAutoWidth = false;
            this.gvData.OptionsView.ShowGroupPanel = false;
            this.gvData.ResetGridColumn = true;
            this.gvData.RowFilter = "";
            this.gvData.EndSorting += new System.EventHandler(this.gvData_EndSorting);
            this.gvData.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvData_ValidateRow);
            // 
            // cbxCouncilNote
            // 
            this.cbxCouncilNote.EditValue = "";
            this.cbxCouncilNote.Location = new System.Drawing.Point(93, 332);
            this.cbxCouncilNote.Name = "cbxCouncilNote";
            this.cbxCouncilNote.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxCouncilNote.Properties.Items.AddRange(new object[] {
            "",
            "Khiển trách",
            "Cảnh cáo",
            "BTH"});
            this.cbxCouncilNote.Properties.NullText = "--Chọn--";
            this.cbxCouncilNote.Size = new System.Drawing.Size(138, 20);
            this.cbxCouncilNote.TabIndex = 59;
            // 
            // dgLabel1
            // 
            this.dgLabel1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dgLabel1.Location = new System.Drawing.Point(3, 335);
            this.dgLabel1.Name = "dgLabel1";
            this.dgLabel1.Size = new System.Drawing.Size(71, 14);
            this.dgLabel1.TabIndex = 60;
            this.dgLabel1.Text = "Ý kiến HĐKL:";
            // 
            // mnuItemPrint_DSHS_YKHDKL
            // 
            this.mnuItemPrint_DSHS_YKHDKL.Name = "mnuItemPrint_DSHS_YKHDKL";
            this.mnuItemPrint_DSHS_YKHDKL.Size = new System.Drawing.Size(271, 22);
            this.mnuItemPrint_DSHS_YKHDKL.Text = "Danh sách học sinh theo ý kiến HĐKL";
            this.mnuItemPrint_DSHS_YKHDKL.Click += new System.EventHandler(this.mnuItemPrint_DSHS_YKHDKL_Click);
            // 
            // frmSanctionReview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 469);
            this.Controls.Add(this.dockPanel2);
            this.Controls.Add(this.dockPanel1);
            this.Name = "frmSanctionReview";
            this.Text = "Xét kỷ luật học sinh";
            this.Load += new System.EventHandler(this.frmSanctionReview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.dockPanel1_Container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxNoPermissionMin.Properties)).EndInit();
            this.dockPanel2.ResumeLayout(false);
            this.dockPanel2_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).EndInit();
            this.mnuPopupGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxCouncilNote.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel2;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DeclarationManager.Education.UYearSemester uYearSemester;
        private Control.DgButton btnSearch;
        
        private Control.DgButton btnClose;
        private Control.DgButton btnPrint;
        private Control.DgGridControl gcData;
        private Control.DgGridView gvData;
        private System.Windows.Forms.ContextMenuStrip mnuPopupGrid;
        private System.Windows.Forms.ToolStripMenuItem mnuItemSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuItemRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuItemExportToExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuItemClose;
        private TrainingPlan.FramePlan.UClass1 uClass;
        private Control.DgButton btnSave;
        private Control.UDateEdit dtmToDate;
        private Control.UDateEdit dtmFromDate;
        private DevExpress.XtraEditors.ComboBoxEdit cbxNoPermissionMin;
        private Control.DgLabel dgLabel3;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPrint3;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPrint1;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPrint2;
        private System.Windows.Forms.ToolStripMenuItem mnuPrint8;
        private System.Windows.Forms.ToolStripMenuItem mnuPrint7;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPrint4;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPrint5;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPrint6;
        private System.Windows.Forms.ToolStripMenuItem mnuQuaTrinhHocTap;
        private System.Windows.Forms.ToolStripMenuItem mnuPrint9;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPrintDS_DeNghiRa_HDKL;
        private DevExpress.XtraEditors.ComboBoxEdit cbxCouncilNote;
        private Control.DgLabel dgLabel1;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPrint_DSHS_YKHDKL;
    }
}