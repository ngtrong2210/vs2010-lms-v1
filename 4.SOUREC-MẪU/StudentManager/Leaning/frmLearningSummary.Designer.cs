namespace StudentManager.Learning
{
    partial class frmLearningSummary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLearningSummary));
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager();
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.btnUpdate = new Control.DgButton();
            this.rdoAll = new Control.DgRatioButton();
            this.txtStudentCode_Search = new Control.UTextEdit();
            this.rdo0 = new Control.DgRatioButton();
            this.rdo1 = new Control.DgRatioButton();
            this.txtFullName_Search = new Control.UTextEdit();
            this.uYearSemester = new DeclarationManager.Education.UYearSemester();
            this.btnClose = new Control.DgButton();
            this.uClass = new TrainingPlan.FramePlan.UClass1();
            this.btnSearch = new Control.DgButton();
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gcData = new Control.DgGridControl();
            this.mnuPopupGrid = new System.Windows.Forms.ContextMenuStrip();
            this.mnuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.gvData = new Control.DgGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
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
            this.dockPanel1.OriginalSize = new System.Drawing.Size(242, 200);
            this.dockPanel1.Size = new System.Drawing.Size(242, 447);
            this.dockPanel1.Text = "Thông tin tìm kiếm";
            this.dockPanel1.Click += new System.EventHandler(this.dockPanel1_Click);
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.btnUpdate);
            this.dockPanel1_Container.Controls.Add(this.rdoAll);
            this.dockPanel1_Container.Controls.Add(this.txtStudentCode_Search);
            this.dockPanel1_Container.Controls.Add(this.rdo0);
            this.dockPanel1_Container.Controls.Add(this.rdo1);
            this.dockPanel1_Container.Controls.Add(this.txtFullName_Search);
            this.dockPanel1_Container.Controls.Add(this.uYearSemester);
            this.dockPanel1_Container.Controls.Add(this.btnClose);
            this.dockPanel1_Container.Controls.Add(this.uClass);
            this.dockPanel1_Container.Controls.Add(this.btnSearch);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(234, 420);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Image = global::StudentManager.Properties.Resources.Save;
            this.btnUpdate.Location = new System.Drawing.Point(117, 359);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(111, 23);
            this.btnUpdate.TabIndex = 62;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Checked = true;
            this.rdoAll.EnterMoveNextControl = true;
            this.rdoAll.Location = new System.Drawing.Point(5, 324);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(55, 17);
            this.rdoAll.TabIndex = 8;
            this.rdoAll.TabStop = true;
            this.rdoAll.Text = "Tất cả";
            this.rdoAll.UseVisualStyleBackColor = true;
            // 
            // txtStudentCode_Search
            // 
            this.txtStudentCode_Search.AllowNull = true;
            this.txtStudentCode_Search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStudentCode_Search.Caption = "Mã sinh viên:";
            this.txtStudentCode_Search.EditorBackColor = System.Drawing.SystemColors.Window;
            this.txtStudentCode_Search.EditorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.txtStudentCode_Search.EditorLeft = 90;
            this.txtStudentCode_Search.EditValue = null;
            this.txtStudentCode_Search.EditValueDouble = null;
            this.txtStudentCode_Search.EditValueInt32 = null;
            this.txtStudentCode_Search.EnterMoveNext = true;
            this.txtStudentCode_Search.FontSize = 9F;
            this.txtStudentCode_Search.Location = new System.Drawing.Point(3, 263);
            this.txtStudentCode_Search.MaxLength = 0;
            this.txtStudentCode_Search.Name = "txtStudentCode_Search";
            this.txtStudentCode_Search.PasswordChar = '\0';
            this.txtStudentCode_Search.ReadOnly = false;
            this.txtStudentCode_Search.Size = new System.Drawing.Size(227, 21);
            this.txtStudentCode_Search.TabIndex = 8;
            this.txtStudentCode_Search.TextTrim = "";
            // 
            // rdo0
            // 
            this.rdo0.AutoSize = true;
            this.rdo0.EnterMoveNextControl = true;
            this.rdo0.Location = new System.Drawing.Point(87, 324);
            this.rdo0.Name = "rdo0";
            this.rdo0.Size = new System.Drawing.Size(66, 17);
            this.rdo0.TabIndex = 9;
            this.rdo0.TabStop = true;
            this.rdo0.Text = "Niên chế";
            this.rdo0.UseVisualStyleBackColor = true;
            // 
            // rdo1
            // 
            this.rdo1.AutoSize = true;
            this.rdo1.EnterMoveNextControl = true;
            this.rdo1.Location = new System.Drawing.Point(173, 324);
            this.rdo1.Name = "rdo1";
            this.rdo1.Size = new System.Drawing.Size(55, 17);
            this.rdo1.TabIndex = 10;
            this.rdo1.TabStop = true;
            this.rdo1.Text = "Tín chỉ";
            this.rdo1.UseVisualStyleBackColor = true;
            // 
            // txtFullName_Search
            // 
            this.txtFullName_Search.AllowNull = true;
            this.txtFullName_Search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFullName_Search.Caption = "Họ tên:";
            this.txtFullName_Search.EditorBackColor = System.Drawing.SystemColors.Window;
            this.txtFullName_Search.EditorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.txtFullName_Search.EditorLeft = 90;
            this.txtFullName_Search.EditValue = null;
            this.txtFullName_Search.EditValueDouble = null;
            this.txtFullName_Search.EditValueInt32 = null;
            this.txtFullName_Search.EnterMoveNext = true;
            this.txtFullName_Search.FontSize = 9F;
            this.txtFullName_Search.Location = new System.Drawing.Point(3, 288);
            this.txtFullName_Search.MaxLength = 0;
            this.txtFullName_Search.Name = "txtFullName_Search";
            this.txtFullName_Search.PasswordChar = '\0';
            this.txtFullName_Search.ReadOnly = false;
            this.txtFullName_Search.Size = new System.Drawing.Size(227, 21);
            this.txtFullName_Search.TabIndex = 9;
            this.txtFullName_Search.TextTrim = "";
            // 
            // uYearSemester
            // 
            this.uYearSemester.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uYearSemester.EditorLeft = 90;
            this.uYearSemester.Location = new System.Drawing.Point(3, 208);
            this.uYearSemester.Name = "uYearSemester";
            this.uYearSemester.ReadOnly = false;
            this.uYearSemester.SemesterEditValue = null;
            this.uYearSemester.Size = new System.Drawing.Size(227, 46);
            this.uYearSemester.TabIndex = 40;
            this.uYearSemester.YearIDEditValue = null;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Image = global::StudentManager.Properties.Resources.Cancel;
            this.btnClose.Location = new System.Drawing.Point(9, 388);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(219, 23);
            this.btnClose.TabIndex = 58;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            this.uClass.Location = new System.Drawing.Point(3, 5);
            this.uClass.Name = "uClass";
            this.uClass.OfficeIDEditValue = null;
            this.uClass.ReadOnly = false;
            this.uClass.ScienceFilter = "";
            this.uClass.ScienceIDEditValue = null;
            this.uClass.Semester = null;
            this.uClass.Size = new System.Drawing.Size(228, 197);
            this.uClass.SpecialBranchIDEditValue = null;
            this.uClass.SpecialBranchSubjectIDEditValue = null;
            this.uClass.TabIndex = 56;
            this.uClass.TrainingLevelIDEditValue = null;
            this.uClass.TrainingTypeEditValue = null;
            this.uClass.YearID = null;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = global::StudentManager.Properties.Resources.Search;
            this.btnSearch.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(8, 359);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(103, 23);
            this.btnSearch.TabIndex = 23;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
            this.dockPanel2.Size = new System.Drawing.Size(703, 447);
            this.dockPanel2.Text = "Danh sách điểm sinh viên";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dockPanel2_Container.Controls.Add(this.gcData);
            this.dockPanel2_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(695, 420);
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
            this.gcData.Size = new System.Drawing.Size(697, 421);
            this.gcData.TabIndex = 33;
            this.gcData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvData});
            // 
            // mnuPopupGrid
            // 
            this.mnuPopupGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemRefresh,
            this.toolStripSeparator1,
            this.mnuItemExportToExcel,
            this.toolStripSeparator2,
            this.mnuItemClose});
            this.mnuPopupGrid.Name = "mnuPopupGrid";
            this.mnuPopupGrid.Size = new System.Drawing.Size(168, 82);
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
            this.mnuItemClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gvData
            // 
            this.gvData.GridControl = this.gcData;
            this.gvData.IndicatorWidth = 35;
            this.gvData.IsSelecting = false;
            this.gvData.LanguageID = 1;
            this.gvData.Name = "gvData";
            this.gvData.OptionsSelection.MultiSelect = true;
            this.gvData.OptionsView.ColumnAutoWidth = false;
            this.gvData.OptionsView.ShowAutoFilterRow = true;
            this.gvData.ResetGridColumn = true;
            this.gvData.RowFilter = "";
            this.gvData.SummaryCollection = "";
            this.gvData.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvData_ValidateRow);
            // 
            // frmLearningSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 447);
            this.Controls.Add(this.dockPanel2);
            this.Controls.Add(this.dockPanel1);
            this.Name = "frmLearningSummary";
            this.ShowIcon = false;
            this.Text = "Tổng hợp sổ điểm";
            this.Load += new System.EventHandler(this.frmLearningSummary_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLearningSummary_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.dockPanel1_Container.PerformLayout();
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
        private System.Windows.Forms.ContextMenuStrip mnuPopupGrid;
        private System.Windows.Forms.ToolStripMenuItem mnuItemRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuItemExportToExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuItemClose;
        private TrainingPlan.FramePlan.UClass1 uClass;
        private Control.DgGridControl gcData;
        private Control.DgGridView gvData;
        private Control.DgButton btnClose;
        private DeclarationManager.Education.UYearSemester uYearSemester;
        private Control.UTextEdit txtStudentCode_Search;
        private Control.UTextEdit txtFullName_Search;
        private Control.DgRatioButton rdoAll;
        private Control.DgRatioButton rdo0;
        private Control.DgRatioButton rdo1;
        private Control.DgButton btnUpdate;
    }
}