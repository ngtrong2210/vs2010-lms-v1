namespace StudentManager.Learning
{
    partial class frmReviewContinueLearning
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReviewContinueLearning));
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.btnSave = new Control.DgButton();
            this.btnPrint = new Control.DgButton();
            this.uYearSemester = new DeclarationManager.Education.UYearSemester();
            this.uClass = new TrainingPlan.FramePlan.UClass1();
            this.btnClose = new Control.DgButton();
            this.btnSearch = new Control.DgButton();
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gcData = new Control.DgGridControl();
            this.mnuItemPrint1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemPrint_CanhCao = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuaTrinhHocTap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.gvData = new Control.DgAdvBandedGridView();
            this.mnuItemPrint_HoiDong = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            this.dockPanel2.SuspendLayout();
            this.dockPanel2_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).BeginInit();
            this.mnuItemPrint1.SuspendLayout();
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
            this.dockPanel1.OriginalSize = new System.Drawing.Size(249, 200);
            this.dockPanel1.Size = new System.Drawing.Size(249, 471);
            this.dockPanel1.Text = "THÔNG TIN TÌM KIẾM";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.btnSave);
            this.dockPanel1_Container.Controls.Add(this.btnPrint);
            this.dockPanel1_Container.Controls.Add(this.uYearSemester);
            this.dockPanel1_Container.Controls.Add(this.uClass);
            this.dockPanel1_Container.Controls.Add(this.btnClose);
            this.dockPanel1_Container.Controls.Add(this.btnSearch);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(241, 444);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Enabled = false;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(3, 413);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(74, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Cập nhật";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(83, 413);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(74, 23);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "In";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // uYearSemester
            // 
            this.uYearSemester.EditorLeft = 90;
            this.uYearSemester.Location = new System.Drawing.Point(3, 178);
            this.uYearSemester.Name = "uYearSemester";
            this.uYearSemester.ReadOnly = false;
            this.uYearSemester.SemesterEditValue = null;
            this.uYearSemester.Size = new System.Drawing.Size(231, 46);
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
            this.uClass.IsOnlyClass = false;
            this.uClass.IsRegulation43 = false;
            this.uClass.Location = new System.Drawing.Point(3, 3);
            this.uClass.Name = "uClass";
            this.uClass.OfficeIDEditValue = null;
            this.uClass.ReadOnly = false;
            this.uClass.ScienceFilter = "";
            this.uClass.ScienceIDEditValue = null;
            this.uClass.Semester = null;
            this.uClass.Size = new System.Drawing.Size(231, 179);
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
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(163, 413);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Đóng";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(140, 230);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dockPanel2
            // 
            this.dockPanel2.Controls.Add(this.dockPanel2_Container);
            this.dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel2.ID = new System.Guid("5702986f-33f0-4dca-8fbc-e2d48a1e6fbd");
            this.dockPanel2.Location = new System.Drawing.Point(249, 0);
            this.dockPanel2.Name = "dockPanel2";
            this.dockPanel2.Options.ShowAutoHideButton = false;
            this.dockPanel2.Options.ShowCloseButton = false;
            this.dockPanel2.OriginalSize = new System.Drawing.Size(680, 200);
            this.dockPanel2.Size = new System.Drawing.Size(983, 471);
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
            this.dockPanel2_Container.Size = new System.Drawing.Size(975, 444);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // gcData
            // 
            this.gcData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gcData.ContextMenuStrip = this.mnuItemPrint1;
            this.gcData.EnterMoveNextControl = true;
            this.gcData.Location = new System.Drawing.Point(-1, 0);
            this.gcData.MainView = this.gvData;
            this.gcData.Name = "gcData";
            this.gcData.Size = new System.Drawing.Size(977, 445);
            this.gcData.TabIndex = 7;
            this.gcData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvData});
            // 
            // mnuItemPrint1
            // 
            this.mnuItemPrint1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemSave,
            this.mnuItemRefresh,
            this.toolStripSeparator1,
            this.mnuItemPrint_CanhCao,
            this.mnuItemPrint_HoiDong,
            this.mnuItemPrint,
            this.mnuQuaTrinhHocTap,
            this.mnuItemExportToExcel,
            this.toolStripSeparator2,
            this.mnuItemClose});
            this.mnuItemPrint1.Name = "mnuPopupGrid";
            this.mnuItemPrint1.Size = new System.Drawing.Size(193, 214);
            this.mnuItemPrint1.Text = "Xét hội đồng";
            // 
            // mnuItemSave
            // 
            this.mnuItemSave.Enabled = false;
            this.mnuItemSave.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemSave.Image")));
            this.mnuItemSave.Name = "mnuItemSave";
            this.mnuItemSave.Size = new System.Drawing.Size(192, 22);
            this.mnuItemSave.Text = "Cập nhật";
            // 
            // mnuItemRefresh
            // 
            this.mnuItemRefresh.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemRefresh.Image")));
            this.mnuItemRefresh.Name = "mnuItemRefresh";
            this.mnuItemRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnuItemRefresh.Size = new System.Drawing.Size(192, 22);
            this.mnuItemRefresh.Text = "Nạp lại";
            this.mnuItemRefresh.Click += new System.EventHandler(this.mnuItemRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(189, 6);
            // 
            // mnuItemPrint_CanhCao
            // 
            this.mnuItemPrint_CanhCao.Name = "mnuItemPrint_CanhCao";
            this.mnuItemPrint_CanhCao.Size = new System.Drawing.Size(192, 22);
            this.mnuItemPrint_CanhCao.Text = "In danh sách cảnh cáo";
            this.mnuItemPrint_CanhCao.Click += new System.EventHandler(this.mnuItemPrint_CanhCao_Click);
            // 
            // mnuItemPrint
            // 
            this.mnuItemPrint.Enabled = false;
            this.mnuItemPrint.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemPrint.Image")));
            this.mnuItemPrint.Name = "mnuItemPrint";
            this.mnuItemPrint.Size = new System.Drawing.Size(192, 22);
            this.mnuItemPrint.Text = "In kết quả";
            this.mnuItemPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // mnuQuaTrinhHocTap
            // 
            this.mnuQuaTrinhHocTap.Image = global::StudentManager.Properties.Resources.Process3;
            this.mnuQuaTrinhHocTap.Name = "mnuQuaTrinhHocTap";
            this.mnuQuaTrinhHocTap.Size = new System.Drawing.Size(192, 22);
            this.mnuQuaTrinhHocTap.Text = "Quá trình học tập";
            this.mnuQuaTrinhHocTap.Click += new System.EventHandler(this.mnuQuaTrinhHocTap_Click);
            // 
            // mnuItemExportToExcel
            // 
            this.mnuItemExportToExcel.Enabled = false;
            this.mnuItemExportToExcel.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemExportToExcel.Image")));
            this.mnuItemExportToExcel.Name = "mnuItemExportToExcel";
            this.mnuItemExportToExcel.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.mnuItemExportToExcel.Size = new System.Drawing.Size(192, 22);
            this.mnuItemExportToExcel.Text = "Xuất excel";
            this.mnuItemExportToExcel.Click += new System.EventHandler(this.mnuItemExportToExcel_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(189, 6);
            // 
            // mnuItemClose
            // 
            this.mnuItemClose.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemClose.Image")));
            this.mnuItemClose.Name = "mnuItemClose";
            this.mnuItemClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuItemClose.Size = new System.Drawing.Size(192, 22);
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
            // mnuItemPrint_HoiDong
            // 
            this.mnuItemPrint_HoiDong.Name = "mnuItemPrint_HoiDong";
            this.mnuItemPrint_HoiDong.Size = new System.Drawing.Size(192, 22);
            this.mnuItemPrint_HoiDong.Text = "Xét hội đồng";
            this.mnuItemPrint_HoiDong.Click += new System.EventHandler(this.mnuItemPrint_HoiDong_Click);
            // 
            // frmReviewContinueLearning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 471);
            this.Controls.Add(this.dockPanel2);
            this.Controls.Add(this.dockPanel1);
            this.Name = "frmReviewContinueLearning";
            this.ShowIcon = false;
            this.Text = "Xét học tiếp";
            this.Load += new System.EventHandler(this.frmMakeStudentCode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.dockPanel2.ResumeLayout(false);
            this.dockPanel2_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).EndInit();
            this.mnuItemPrint1.ResumeLayout(false);
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
        private System.Windows.Forms.ContextMenuStrip mnuItemPrint1;
        private System.Windows.Forms.ToolStripMenuItem mnuItemRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuItemExportToExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuItemClose;
        private TrainingPlan.FramePlan.UClass1 uClass;
        private DeclarationManager.Education.UYearSemester uYearSemester;
        private Control.DgGridControl gcData;
        private Control.DgAdvBandedGridView gvData;
        private Control.DgButton btnPrint;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPrint;
        private Control.DgButton btnSave;
        private System.Windows.Forms.ToolStripMenuItem mnuItemSave;
        private System.Windows.Forms.ToolStripMenuItem mnuQuaTrinhHocTap;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPrint_CanhCao;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPrint_HoiDong;
    }
}