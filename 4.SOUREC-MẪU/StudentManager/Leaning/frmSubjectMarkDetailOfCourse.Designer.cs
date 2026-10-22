namespace StudentManager.Learning
{
    partial class frmSubjectMarkDetailOfCourse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSubjectMarkDetailOfCourse));
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager();
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.btnAutoSummary = new Control.DgButton();
            this.btnSave = new Control.DgButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.chkShowGraduation = new Control.DgCheckEdit();
            this.chkShowSummary2 = new Control.DgCheckEdit();
            this.chkShowSummary1 = new Control.DgCheckEdit();
            this.chkShowTestAverage = new Control.DgCheckEdit();
            this.chkShowExam = new Control.DgCheckEdit();
            this.uYearSemester = new DeclarationManager.Education.UYearSemester();
            this.uClass = new TrainingPlan.FramePlan.UClass1();
            this.btnClose = new Control.DgButton();
            this.btnSearch = new Control.DgButton();
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gcData = new Control.DgGridControl();
            this.mnuPopupGrid = new System.Windows.Forms.ContextMenuStrip();
            this.mnuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemPrint1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemPrint2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.gvData = new Control.DgAdvBandedGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowGraduation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowSummary2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowSummary1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowTestAverage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowExam.Properties)).BeginInit();
            this.dockPanel2.SuspendLayout();
            this.dockPanel2_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).BeginInit();
            this.mnuPopupGrid.SuspendLayout();
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
            this.dockPanel1.Options.ShowCloseButton = false;
            this.dockPanel1.OriginalSize = new System.Drawing.Size(253, 200);
            this.dockPanel1.Size = new System.Drawing.Size(253, 474);
            this.dockPanel1.Text = "THÔNG TIN TÌM KIẾM";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.btnAutoSummary);
            this.dockPanel1_Container.Controls.Add(this.btnSave);
            this.dockPanel1_Container.Controls.Add(this.groupControl1);
            this.dockPanel1_Container.Controls.Add(this.uYearSemester);
            this.dockPanel1_Container.Controls.Add(this.uClass);
            this.dockPanel1_Container.Controls.Add(this.btnClose);
            this.dockPanel1_Container.Controls.Add(this.btnSearch);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(245, 447);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // btnAutoSummary
            // 
            this.btnAutoSummary.Enabled = false;
            this.btnAutoSummary.Image = global::StudentManager.Properties.Resources.sao;
            this.btnAutoSummary.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnAutoSummary.Location = new System.Drawing.Point(4, 240);
            this.btnAutoSummary.Name = "btnAutoSummary";
            this.btnAutoSummary.Size = new System.Drawing.Size(234, 23);
            this.btnAutoSummary.TabIndex = 5;
            this.btnAutoSummary.Text = "Tổng kết tự động điểm học tập";
            this.btnAutoSummary.Click += new System.EventHandler(this.btnAutoSummary_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Enabled = false;
            this.btnSave.Image = global::StudentManager.Properties.Resources.Save;
            this.btnSave.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(3, 416);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(234, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Cập nhật tổng kết toàn khóa";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.chkShowGraduation);
            this.groupControl1.Controls.Add(this.chkShowSummary2);
            this.groupControl1.Controls.Add(this.chkShowSummary1);
            this.groupControl1.Controls.Add(this.chkShowTestAverage);
            this.groupControl1.Controls.Add(this.chkShowExam);
            this.groupControl1.Location = new System.Drawing.Point(3, 278);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(238, 105);
            this.groupControl1.TabIndex = 7;
            this.groupControl1.Text = "Cột hiển thị";
            // 
            // chkShowGraduation
            // 
            this.chkShowGraduation.EnterMoveNextControl = true;
            this.chkShowGraduation.Location = new System.Drawing.Point(5, 80);
            this.chkShowGraduation.Name = "chkShowGraduation";
            this.chkShowGraduation.Properties.Caption = "Môn tốt nghiệp";
            this.chkShowGraduation.Size = new System.Drawing.Size(103, 19);
            this.chkShowGraduation.TabIndex = 7;
            // 
            // chkShowSummary2
            // 
            this.chkShowSummary2.EnterMoveNextControl = true;
            this.chkShowSummary2.Location = new System.Drawing.Point(87, 55);
            this.chkShowSummary2.Name = "chkShowSummary2";
            this.chkShowSummary2.Properties.Caption = "TKM2";
            this.chkShowSummary2.Size = new System.Drawing.Size(47, 19);
            this.chkShowSummary2.TabIndex = 5;
            this.chkShowSummary2.CheckedChanged += new System.EventHandler(this.chkShowColumn_CheckedChanged);
            // 
            // chkShowSummary1
            // 
            this.chkShowSummary1.EnterMoveNextControl = true;
            this.chkShowSummary1.Location = new System.Drawing.Point(5, 55);
            this.chkShowSummary1.Name = "chkShowSummary1";
            this.chkShowSummary1.Properties.Caption = "TKM1";
            this.chkShowSummary1.Size = new System.Drawing.Size(47, 19);
            this.chkShowSummary1.TabIndex = 6;
            this.chkShowSummary1.CheckedChanged += new System.EventHandler(this.chkShowColumn_CheckedChanged);
            // 
            // chkShowTestAverage
            // 
            this.chkShowTestAverage.EnterMoveNextControl = true;
            this.chkShowTestAverage.Location = new System.Drawing.Point(87, 30);
            this.chkShowTestAverage.Name = "chkShowTestAverage";
            this.chkShowTestAverage.Properties.Caption = "GK/TBKT";
            this.chkShowTestAverage.Size = new System.Drawing.Size(74, 19);
            this.chkShowTestAverage.TabIndex = 3;
            this.chkShowTestAverage.CheckedChanged += new System.EventHandler(this.chkShowColumn_CheckedChanged);
            // 
            // chkShowExam
            // 
            this.chkShowExam.EnterMoveNextControl = true;
            this.chkShowExam.Location = new System.Drawing.Point(5, 30);
            this.chkShowExam.Name = "chkShowExam";
            this.chkShowExam.Properties.Caption = "Thi";
            this.chkShowExam.Size = new System.Drawing.Size(47, 19);
            this.chkShowExam.TabIndex = 4;
            this.chkShowExam.CheckedChanged += new System.EventHandler(this.chkShowColumn_CheckedChanged);
            // 
            // uYearSemester
            // 
            this.uYearSemester.EditorLeft = 90;
            this.uYearSemester.Location = new System.Drawing.Point(3, 184);
            this.uYearSemester.Name = "uYearSemester";
            this.uYearSemester.ReadOnly = false;
            this.uYearSemester.SemesterEditValue = null;
            this.uYearSemester.Size = new System.Drawing.Size(235, 46);
            this.uYearSemester.TabIndex = 1;
            this.uYearSemester.YearIDEditValue = null;
            this.uYearSemester.EditValueChanged += new DeclarationManager.Education.UYearSemester.EditValueChangedDelegate(this.uYearSemester_EditValueChanged);
            // 
            // uClass
            // 
            this.uClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uClass.BranchEditValue = null;
            this.uClass.ClassEdit = null;
            this.uClass.ClassFilter = "";
            this.uClass.ClassIDEditValue = null;
            this.uClass.ClassSubject = null;
            this.uClass.ClassSubjectFilter = "";
            this.uClass.ClassSubjectIDEditValue = null;
            this.uClass.CourseIDEditValue = null;
            this.uClass.EditorLeft = 90;
            this.uClass.IsOnlyClass = true;
            this.uClass.IsRegulation43 = false;
            this.uClass.Location = new System.Drawing.Point(3, 3);
            this.uClass.Name = "uClass";
            this.uClass.OfficeIDEditValue = null;
            this.uClass.ReadOnly = false;
            this.uClass.ScienceFilter = "";
            this.uClass.ScienceIDEditValue = null;
            this.uClass.Semester = null;
            this.uClass.Size = new System.Drawing.Size(235, 171);
            this.uClass.SpecialBranchIDEditValue = null;
            this.uClass.SpecialBranchSubjectIDEditValue = null;
            this.uClass.TabIndex = 0;
            this.uClass.TrainingLevelIDEditValue = null;
            this.uClass.TrainingTypeEditValue = null;
            this.uClass.YearID = null;
            this.uClass.EditValueChanged += new TrainingPlan.FramePlan.UClass1.EditValueChangedDelegate(this.uClass_EditValueChanged);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Image = global::StudentManager.Properties.Resources.Cancel;
            this.btnClose.Location = new System.Drawing.Point(128, 387);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(109, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Đóng";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSearch.Image = global::StudentManager.Properties.Resources.Search;
            this.btnSearch.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(3, 389);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(119, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dockPanel2
            // 
            this.dockPanel2.Controls.Add(this.dockPanel2_Container);
            this.dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel2.ID = new System.Guid("5702986f-33f0-4dca-8fbc-e2d48a1e6fbd");
            this.dockPanel2.Location = new System.Drawing.Point(253, 0);
            this.dockPanel2.Name = "dockPanel2";
            this.dockPanel2.Options.ShowAutoHideButton = false;
            this.dockPanel2.Options.ShowCloseButton = false;
            this.dockPanel2.OriginalSize = new System.Drawing.Size(731, 200);
            this.dockPanel2.Size = new System.Drawing.Size(731, 474);
            this.dockPanel2.Text = "DANH SÁCH SINH VIÊN";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dockPanel2_Container.Controls.Add(this.gcData);
            this.dockPanel2_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(723, 447);
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
            this.gcData.Size = new System.Drawing.Size(725, 448);
            this.gcData.TabIndex = 7;
            this.gcData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvData});
            // 
            // mnuPopupGrid
            // 
            this.mnuPopupGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemSave,
            this.mnuItemRefresh,
            this.toolStripSeparator1,
            this.mnuItemPrint,
            this.mnuItemExportToExcel,
            this.toolStripSeparator2,
            this.mnuItemClose});
            this.mnuPopupGrid.Name = "mnuPopupGrid";
            this.mnuPopupGrid.Size = new System.Drawing.Size(226, 126);
            // 
            // mnuItemSave
            // 
            this.mnuItemSave.Enabled = false;
            this.mnuItemSave.Image = global::StudentManager.Properties.Resources.Save;
            this.mnuItemSave.Name = "mnuItemSave";
            this.mnuItemSave.Size = new System.Drawing.Size(225, 22);
            this.mnuItemSave.Text = "Cập nhật tổng kết toàn khóa";
            this.mnuItemSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // mnuItemRefresh
            // 
            this.mnuItemRefresh.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemRefresh.Image")));
            this.mnuItemRefresh.Name = "mnuItemRefresh";
            this.mnuItemRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnuItemRefresh.Size = new System.Drawing.Size(225, 22);
            this.mnuItemRefresh.Text = "Nạp lại";
            this.mnuItemRefresh.Click += new System.EventHandler(this.mnuItemRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(222, 6);
            // 
            // mnuItemPrint
            // 
            this.mnuItemPrint.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemPrint1,
            this.mnuItemPrint2});
            this.mnuItemPrint.Enabled = false;
            this.mnuItemPrint.Image = global::StudentManager.Properties.Resources.print1;
            this.mnuItemPrint.Name = "mnuItemPrint";
            this.mnuItemPrint.Size = new System.Drawing.Size(225, 22);
            this.mnuItemPrint.Text = "In bảng điểm";
            // 
            // mnuItemPrint1
            // 
            this.mnuItemPrint1.Name = "mnuItemPrint1";
            this.mnuItemPrint1.Size = new System.Drawing.Size(126, 22);
            this.mnuItemPrint1.Text = "Mẫu 1";
            this.mnuItemPrint1.Click += new System.EventHandler(this.mnuItemPrint1_Click);
            // 
            // mnuItemPrint2
            // 
            this.mnuItemPrint2.Name = "mnuItemPrint2";
            this.mnuItemPrint2.Size = new System.Drawing.Size(126, 22);
            this.mnuItemPrint2.Text = "Ngắn hạn";
            this.mnuItemPrint2.Visible = false;
            this.mnuItemPrint2.Click += new System.EventHandler(this.mnuItemPrint2_Click);
            // 
            // mnuItemExportToExcel
            // 
            this.mnuItemExportToExcel.Enabled = false;
            this.mnuItemExportToExcel.Image = global::StudentManager.Properties.Resources.excel;
            this.mnuItemExportToExcel.Name = "mnuItemExportToExcel";
            this.mnuItemExportToExcel.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.mnuItemExportToExcel.Size = new System.Drawing.Size(225, 22);
            this.mnuItemExportToExcel.Text = "Xuất excel";
            this.mnuItemExportToExcel.Click += new System.EventHandler(this.mnuItemExportToExcel_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(222, 6);
            // 
            // mnuItemClose
            // 
            this.mnuItemClose.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemClose.Image")));
            this.mnuItemClose.Name = "mnuItemClose";
            this.mnuItemClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuItemClose.Size = new System.Drawing.Size(225, 22);
            this.mnuItemClose.Text = "Đóng";
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
            this.gvData.OptionsBehavior.Editable = false;
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
            this.gvData.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvData_RowCellStyle);
            // 
            // frmSubjectMarkDetailOfCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 474);
            this.Controls.Add(this.dockPanel2);
            this.Controls.Add(this.dockPanel1);
            this.Name = "frmSubjectMarkDetailOfCourse";
            this.ShowIcon = false;
            this.Text = "Tổng kết điểm toàn khóa";
            this.Load += new System.EventHandler(this.frmMakeStudentCode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkShowGraduation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowSummary2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowSummary1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowTestAverage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowExam.Properties)).EndInit();
            this.dockPanel2.ResumeLayout(false);
            this.dockPanel2_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).EndInit();
            this.mnuPopupGrid.ResumeLayout(false);
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
        private Control.DgButton btnClose;
        private System.Windows.Forms.ContextMenuStrip mnuPopupGrid;
        private System.Windows.Forms.ToolStripMenuItem mnuItemRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuItemExportToExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuItemClose;
        private TrainingPlan.FramePlan.UClass1 uClass;
        private DeclarationManager.Education.UYearSemester uYearSemester;
        private Control.DgGridControl gcData;
        private Control.DgAdvBandedGridView gvData;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPrint;
        private System.Windows.Forms.ToolStripMenuItem mnuItemSave;
        private Control.DgCheckEdit chkShowSummary2;
        private Control.DgCheckEdit chkShowExam;
        private Control.DgCheckEdit chkShowTestAverage;
        private Control.DgCheckEdit chkShowSummary1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private Control.DgButton btnSave;
        private Control.DgButton btnAutoSummary;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPrint1;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPrint2;
        private Control.DgCheckEdit chkShowGraduation;
    }
}