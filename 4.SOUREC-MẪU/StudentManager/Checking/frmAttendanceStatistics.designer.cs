namespace  StudentManager.Checking
{
    partial class frmAttendanceStatistics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAttendanceStatistics));
            this.btnClose = new Control.DgButton();
            this.mnuPopupGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemUnCheckDoneAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemPrint1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSearch = new Control.DgButton();
            this.dockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.chkShowAllDate = new Control.DgCheckEdit();
            this.uClass = new TrainingPlan.FramePlan.UClass1();
            this.dtmTo = new Control.UDateEdit();
            this.dtmFrom = new Control.UDateEdit();
            this.btnPrint = new Control.DgButton();
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gcData = new Control.DgGridControl();
            this.gvData = new Control.DgAdvBandedGridView();
            this.mnuPopupGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowAllDate.Properties)).BeginInit();
            this.dockPanel2.SuspendLayout();
            this.dockPanel2_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Image = global::StudentManager.Properties.Resources.Cancel;
            this.btnClose.Location = new System.Drawing.Point(120, 444);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(106, 26);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // mnuPopupGrid
            // 
            this.mnuPopupGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemEdit,
            this.toolStripSeparator3,
            this.mnuItemSave,
            this.toolStripSeparator1,
            this.mnuItemUnCheckDoneAll,
            this.toolStripSeparator2,
            this.mnuItemExportToExcel,
            this.mnuItemPrint,
            this.mnuItemRefresh,
            this.toolStripSeparator4,
            this.mnuItemClose});
            this.mnuPopupGrid.Name = "mnuPopupGrid";
            this.mnuPopupGrid.Size = new System.Drawing.Size(179, 182);
            this.mnuPopupGrid.Opening += new System.ComponentModel.CancelEventHandler(this.mnuPopupGrid_Opening);
            // 
            // mnuItemEdit
            // 
            this.mnuItemEdit.Enabled = false;
            this.mnuItemEdit.Image = global::StudentManager.Properties.Resources.Edit;
            this.mnuItemEdit.Name = "mnuItemEdit";
            this.mnuItemEdit.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.mnuItemEdit.Size = new System.Drawing.Size(178, 22);
            this.mnuItemEdit.Text = "Xem chi tiết lịch";
            this.mnuItemEdit.Visible = false;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(175, 6);
            this.toolStripSeparator3.Visible = false;
            // 
            // mnuItemSave
            // 
            this.mnuItemSave.Enabled = false;
            this.mnuItemSave.Image = global::StudentManager.Properties.Resources.Save;
            this.mnuItemSave.Name = "mnuItemSave";
            this.mnuItemSave.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.mnuItemSave.Size = new System.Drawing.Size(178, 22);
            this.mnuItemSave.Text = "Cập nhật";
            this.mnuItemSave.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(175, 6);
            // 
            // mnuItemUnCheckDoneAll
            // 
            this.mnuItemUnCheckDoneAll.Enabled = false;
            this.mnuItemUnCheckDoneAll.Image = global::StudentManager.Properties.Resources.UnCheckIcon;
            this.mnuItemUnCheckDoneAll.Name = "mnuItemUnCheckDoneAll";
            this.mnuItemUnCheckDoneAll.Size = new System.Drawing.Size(178, 22);
            this.mnuItemUnCheckDoneAll.Text = "Xóa";
            this.mnuItemUnCheckDoneAll.Visible = false;
            this.mnuItemUnCheckDoneAll.Click += new System.EventHandler(this.mnuItemUnCheckDoneAll_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(175, 6);
            // 
            // mnuItemExportToExcel
            // 
            this.mnuItemExportToExcel.Enabled = false;
            this.mnuItemExportToExcel.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemExportToExcel.Image")));
            this.mnuItemExportToExcel.Name = "mnuItemExportToExcel";
            this.mnuItemExportToExcel.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.mnuItemExportToExcel.Size = new System.Drawing.Size(178, 22);
            this.mnuItemExportToExcel.Text = "Xuất excel";
            this.mnuItemExportToExcel.Click += new System.EventHandler(this.mnuItemExportToExcel_Click);
            // 
            // mnuItemPrint
            // 
            this.mnuItemPrint.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemPrint1});
            this.mnuItemPrint.Enabled = false;
            this.mnuItemPrint.Image = global::StudentManager.Properties.Resources.print1;
            this.mnuItemPrint.Name = "mnuItemPrint";
            this.mnuItemPrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.mnuItemPrint.Size = new System.Drawing.Size(178, 22);
            this.mnuItemPrint.Text = "In";
            // 
            // mnuItemPrint1
            // 
            this.mnuItemPrint1.Name = "mnuItemPrint1";
            this.mnuItemPrint1.Size = new System.Drawing.Size(161, 22);
            this.mnuItemPrint1.Text = "Bảng điểm danh";
            this.mnuItemPrint1.Click += new System.EventHandler(this.mnuItemPrint1_Click);
            // 
            // mnuItemRefresh
            // 
            this.mnuItemRefresh.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemRefresh.Image")));
            this.mnuItemRefresh.Name = "mnuItemRefresh";
            this.mnuItemRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnuItemRefresh.Size = new System.Drawing.Size(178, 22);
            this.mnuItemRefresh.Text = "Nạp lại";
            this.mnuItemRefresh.Click += new System.EventHandler(this.mnuItemRefresh_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(175, 6);
            // 
            // mnuItemClose
            // 
            this.mnuItemClose.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemClose.Image")));
            this.mnuItemClose.Name = "mnuItemClose";
            this.mnuItemClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuItemClose.Size = new System.Drawing.Size(178, 22);
            this.mnuItemClose.Text = "Đóng";
            this.mnuItemClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::StudentManager.Properties.Resources.Search;
            this.btnSearch.Location = new System.Drawing.Point(8, 411);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(218, 28);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dockManager
            // 
            this.dockManager.Form = this;
            this.dockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1,
            this.dockPanel2});
            this.dockManager.TopZIndexControls.AddRange(new string[] {
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
            this.dockPanel1.ID = new System.Guid("b8c64fba-05aa-4fea-8092-fc1d617412cd");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Options.ShowCloseButton = false;
            this.dockPanel1.OriginalSize = new System.Drawing.Size(239, 200);
            this.dockPanel1.Size = new System.Drawing.Size(239, 510);
            this.dockPanel1.Text = "Tìm kiếm";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.chkShowAllDate);
            this.dockPanel1_Container.Controls.Add(this.uClass);
            this.dockPanel1_Container.Controls.Add(this.dtmTo);
            this.dockPanel1_Container.Controls.Add(this.dtmFrom);
            this.dockPanel1_Container.Controls.Add(this.btnClose);
            this.dockPanel1_Container.Controls.Add(this.btnPrint);
            this.dockPanel1_Container.Controls.Add(this.btnSearch);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(231, 483);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // chkShowAllDate
            // 
            this.chkShowAllDate.EnterMoveNextControl = true;
            this.chkShowAllDate.Location = new System.Drawing.Point(71, 323);
            this.chkShowAllDate.Name = "chkShowAllDate";
            this.chkShowAllDate.Properties.Caption = "Hiển thị tất cả ngày";
            this.chkShowAllDate.Size = new System.Drawing.Size(131, 19);
            this.chkShowAllDate.TabIndex = 8;
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
            //this.uClass.IsOnlyClass = false;
            this.uClass.IsRegulation43 = false;
            this.uClass.Location = new System.Drawing.Point(3, 5);
            this.uClass.Name = "uClass";
            this.uClass.OfficeIDEditValue = null;
            this.uClass.ReadOnly = false;
            this.uClass.ScienceFilter = "";
            this.uClass.ScienceIDEditValue = null;
            this.uClass.Semester = null;
            this.uClass.Size = new System.Drawing.Size(225, 258);
            this.uClass.SpecialBranchIDEditValue = null;
            this.uClass.SpecialBranchSubjectIDEditValue = null;
            this.uClass.TabIndex = 0;
            this.uClass.TrainingLevelIDEditValue = null;
            this.uClass.TrainingTypeEditValue = null;
            this.uClass.YearID = null;
            // 
            // dtmTo
            // 
            this.dtmTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtmTo.Caption = "Đến  ngày:";
            this.dtmTo.EditorLeft = 70;
            this.dtmTo.EditValue = null;
            this.dtmTo.EditValueDate = null;
            this.dtmTo.EditValueDateTime = null;
            this.dtmTo.FormatString = "d";
            this.dtmTo.Location = new System.Drawing.Point(3, 296);
            this.dtmTo.Name = "dtmTo";
            this.dtmTo.ReadOnly = false;
            this.dtmTo.Size = new System.Drawing.Size(225, 21);
            this.dtmTo.TabIndex = 3;
            // 
            // dtmFrom
            // 
            this.dtmFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtmFrom.Caption = "Từ ngày:";
            this.dtmFrom.EditorLeft = 70;
            this.dtmFrom.EditValue = null;
            this.dtmFrom.EditValueDate = null;
            this.dtmFrom.EditValueDateTime = null;
            this.dtmFrom.FormatString = "d";
            this.dtmFrom.Location = new System.Drawing.Point(3, 269);
            this.dtmFrom.Name = "dtmFrom";
            this.dtmFrom.ReadOnly = false;
            this.dtmFrom.Size = new System.Drawing.Size(225, 21);
            this.dtmFrom.TabIndex = 2;
            // 
            // btnPrint
            // 
            this.btnPrint.Enabled = false;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(8, 444);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(106, 26);
            this.btnPrint.TabIndex = 12;
            this.btnPrint.Text = "In";
            // 
            // dockPanel2
            // 
            this.dockPanel2.Controls.Add(this.dockPanel2_Container);
            this.dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel2.FloatSize = new System.Drawing.Size(200, 185);
            this.dockPanel2.ID = new System.Guid("5757db7c-9438-4317-8d68-86d3c607e392");
            this.dockPanel2.Location = new System.Drawing.Point(239, 0);
            this.dockPanel2.Name = "dockPanel2";
            this.dockPanel2.Options.ShowAutoHideButton = false;
            this.dockPanel2.Options.ShowCloseButton = false;
            this.dockPanel2.OriginalSize = new System.Drawing.Size(889, 200);
            this.dockPanel2.Size = new System.Drawing.Size(556, 510);
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Controls.Add(this.gcData);
            this.dockPanel2_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(548, 483);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // gcData
            // 
            this.gcData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gcData.ContextMenuStrip = this.mnuPopupGrid;
            this.gcData.EnterMoveNextControl = true;
            this.gcData.Location = new System.Drawing.Point(-1, -1);
            this.gcData.MainView = this.gvData;
            this.gcData.Name = "gcData";
            this.gcData.Size = new System.Drawing.Size(550, 485);
            this.gcData.TabIndex = 14;
            this.gcData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvData});
            // 
            // gvData
            // 
            this.gvData.Appearance.EvenRow.BackColor = System.Drawing.Color.Cornsilk;
            this.gvData.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvData.Appearance.FocusedCell.BackColor = System.Drawing.Color.Transparent;
            this.gvData.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.Transparent;
            this.gvData.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvData.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gvData.Appearance.OddRow.Options.UseBackColor = true;
            this.gvData.Appearance.RowSeparator.BackColor = System.Drawing.SystemColors.ControlDark;
            this.gvData.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gvData.CustomizationFormBounds = new System.Drawing.Rectangle(1048, 450, 223, 215);
            this.gvData.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gvData.GridControl = this.gcData;
            this.gvData.IndicatorWidth = 35;
            this.gvData.IsSelecting = false;
            this.gvData.LanguageID = 1;
            this.gvData.Name = "gvData";
            this.gvData.OptionsCustomization.AllowBandMoving = false;
            this.gvData.OptionsCustomization.AllowColumnMoving = false;
            this.gvData.OptionsCustomization.AllowGroup = false;
            this.gvData.OptionsCustomization.AllowQuickHideColumns = false;
            this.gvData.OptionsCustomization.AllowRowSizing = true;
            this.gvData.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gvData.OptionsSelection.InvertSelection = true;
            this.gvData.OptionsSelection.MultiSelect = true;
            this.gvData.OptionsView.ShowAutoFilterRow = true;
            this.gvData.OptionsView.ShowGroupPanel = false;
            this.gvData.ResetGridColumn = true;
            this.gvData.RowFilter = "";
            this.gvData.SummaryCollection = "";
            this.gvData.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvData_RowCellStyle);
            this.gvData.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gvData_ShowingEditor);
            this.gvData.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvData_ValidateRow);
            this.gvData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmStudentChecking_KeyDown);
            this.gvData.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gvData_ValidatingEditor);
            // 
            // frmAttendanceStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 510);
            this.ContextMenuStrip = this.mnuPopupGrid;
            this.Controls.Add(this.dockPanel2);
            this.Controls.Add(this.dockPanel1);
            this.HelpButton = true;
            this.KeyPreview = true;
            this.Name = "frmAttendanceStatistics";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Thống kê điểm danh";
            this.Load += new System.EventHandler(this.frmSchedule_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmStudentChecking_KeyDown);
            this.mnuPopupGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkShowAllDate.Properties)).EndInit();
            this.dockPanel2.ResumeLayout(false);
            this.dockPanel2_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion        

        private Control.DgButton btnClose;
        private Control.DgButton btnSearch;
        private DevExpress.XtraBars.Docking.DockManager dockManager;
        private Control.DgButton btnPrint;
        private System.Windows.Forms.ContextMenuStrip mnuPopupGrid;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuItemExportToExcel;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPrint;
        private System.Windows.Forms.ToolStripMenuItem mnuItemRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mnuItemClose;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel2;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private TrainingPlan.FramePlan.UClass1 uClass;
        private Control.UDateEdit dtmTo;
        private Control.UDateEdit dtmFrom;
        private System.Windows.Forms.ToolStripMenuItem mnuItemEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private Control.DgGridControl gcData;
        private Control.DgAdvBandedGridView gvData;
        private System.Windows.Forms.ToolStripMenuItem mnuItemSave;
        private System.Windows.Forms.ToolStripMenuItem mnuItemUnCheckDoneAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private Control.DgCheckEdit chkShowAllDate;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPrint1;   
    }
}