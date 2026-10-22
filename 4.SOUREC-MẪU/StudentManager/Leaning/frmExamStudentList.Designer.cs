namespace StudentManager.Learning
{
    partial class frmExamStudentList
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExamStudentList));
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.chkIsAllowExam = new Control.DgCheckEdit();
            this.btnReview = new Control.DgButton();
            this.btnSave = new Control.DgButton();
            this.rdoTestOrder1 = new Control.DgRatioButton();
            this.rdoTestOrder2 = new Control.DgRatioButton();
            this.uClass = new TrainingPlan.FramePlan.UClass1();
            this.btnClose = new Control.DgButton();
            this.btnSearch = new Control.DgButton();
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gcData = new Control.DgGridControl();
            this.mnuPopupGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuItemCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUnCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemPrintForScan = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemPrint2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemExportTemplateExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.gvData = new Control.DgGridView();
            this.rdoTestOrder3 = new Control.DgRatioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsAllowExam.Properties)).BeginInit();
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
            this.dockPanel1.Size = new System.Drawing.Size(242, 509);
            this.dockPanel1.Text = "Thông tin tìm kiếm";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.rdoTestOrder3);
            this.dockPanel1_Container.Controls.Add(this.chkIsAllowExam);
            this.dockPanel1_Container.Controls.Add(this.btnReview);
            this.dockPanel1_Container.Controls.Add(this.btnSave);
            this.dockPanel1_Container.Controls.Add(this.rdoTestOrder1);
            this.dockPanel1_Container.Controls.Add(this.rdoTestOrder2);
            this.dockPanel1_Container.Controls.Add(this.uClass);
            this.dockPanel1_Container.Controls.Add(this.btnClose);
            this.dockPanel1_Container.Controls.Add(this.btnSearch);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(234, 482);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // chkIsAllowExam
            // 
            this.chkIsAllowExam.EnterMoveNextControl = true;
            this.chkIsAllowExam.Location = new System.Drawing.Point(6, 339);
            this.chkIsAllowExam.Name = "chkIsAllowExam";
            this.chkIsAllowExam.Properties.Caption = "Chỉ hiển thị sinh viên được thi";
            this.chkIsAllowExam.Size = new System.Drawing.Size(181, 19);
            this.chkIsAllowExam.TabIndex = 64;
            this.chkIsAllowExam.CheckedChanged += new System.EventHandler(this.chkIsAllowExam_CheckedChanged);
            // 
            // btnReview
            // 
            this.btnReview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReview.Image = global::StudentManager.Properties.Resources.process;
            this.btnReview.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnReview.Location = new System.Drawing.Point(118, 427);
            this.btnReview.Name = "btnReview";
            this.btnReview.Size = new System.Drawing.Size(104, 23);
            this.btnReview.TabIndex = 62;
            this.btnReview.Text = "Xét duyệt";
            this.btnReview.Click += new System.EventHandler(this.btnReview_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Image = global::StudentManager.Properties.Resources.Save;
            this.btnSave.Location = new System.Drawing.Point(8, 456);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 23);
            this.btnSave.TabIndex = 61;
            this.btnSave.Text = "Cập nhật";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // rdoTestOrder1
            // 
            this.rdoTestOrder1.AutoSize = true;
            this.rdoTestOrder1.Checked = true;
            this.rdoTestOrder1.EnterMoveNextControl = true;
            this.rdoTestOrder1.Location = new System.Drawing.Point(8, 319);
            this.rdoTestOrder1.Name = "rdoTestOrder1";
            this.rdoTestOrder1.Size = new System.Drawing.Size(51, 17);
            this.rdoTestOrder1.TabIndex = 60;
            this.rdoTestOrder1.TabStop = true;
            this.rdoTestOrder1.Text = "Lần 1";
            this.rdoTestOrder1.UseVisualStyleBackColor = true;
            // 
            // rdoTestOrder2
            // 
            this.rdoTestOrder2.AutoSize = true;
            this.rdoTestOrder2.EnterMoveNextControl = true;
            this.rdoTestOrder2.Location = new System.Drawing.Point(83, 319);
            this.rdoTestOrder2.Name = "rdoTestOrder2";
            this.rdoTestOrder2.Size = new System.Drawing.Size(51, 17);
            this.rdoTestOrder2.TabIndex = 59;
            this.rdoTestOrder2.TabStop = true;
            this.rdoTestOrder2.Text = "Lần 2";
            this.rdoTestOrder2.UseVisualStyleBackColor = true;
            this.rdoTestOrder2.CheckedChanged += new System.EventHandler(this.uClass_ClassSubjectChanged);
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
            this.uClass.Location = new System.Drawing.Point(3, 3);
            this.uClass.Name = "uClass";
            this.uClass.OfficeIDEditValue = null;
            this.uClass.ReadOnly = false;
            this.uClass.ScienceFilter = "";
            this.uClass.ScienceIDEditValue = null;
            this.uClass.Semester = null;
            this.uClass.Size = new System.Drawing.Size(228, 310);
            this.uClass.SpecialBranchIDEditValue = null;
            this.uClass.SpecialBranchSubjectIDEditValue = null;
            this.uClass.TabIndex = 56;
            this.uClass.TrainingLevelIDEditValue = null;
            this.uClass.TrainingTypeEditValue = null;
            this.uClass.YearID = null;
            this.uClass.ClassSubjectChanged += new TrainingPlan.FramePlan.UClass1.ClassSubjectChangedDelegate(this.uClass_ClassSubjectChanged);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = global::StudentManager.Properties.Resources.Cancel;
            this.btnClose.Location = new System.Drawing.Point(119, 456);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(104, 23);
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "Đóng";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = global::StudentManager.Properties.Resources.Search;
            this.btnSearch.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(8, 427);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(104, 23);
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
            this.dockPanel2.Size = new System.Drawing.Size(687, 509);
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
            this.dockPanel2_Container.Size = new System.Drawing.Size(679, 482);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // gcData
            // 
            this.gcData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gcData.ContextMenuStrip = this.mnuPopupGrid;
            this.gcData.EnterMoveNextControl = true;
            gridLevelNode1.RelationName = "Level1";
            gridLevelNode2.RelationName = "Level2";
            this.gcData.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1,
            gridLevelNode2});
            this.gcData.Location = new System.Drawing.Point(0, 0);
            this.gcData.MainView = this.gvData;
            this.gcData.Name = "gcData";
            this.gcData.Size = new System.Drawing.Size(679, 479);
            this.gcData.TabIndex = 32;
            this.gcData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvData});
            // 
            // mnuPopupGrid
            // 
            this.mnuPopupGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemCheck,
            this.mnuUnCheck,
            this.mnuItemSave,
            this.toolStripSeparator3,
            this.mnuItemRefresh,
            this.toolStripSeparator1,
            this.toolStripMenuItem1,
            this.mnuItemExportToExcel,
            this.mnuItemExportTemplateExcel,
            this.toolStripSeparator2,
            this.mnuItemClose});
            this.mnuPopupGrid.Name = "mnuPopupGrid";
            this.mnuPopupGrid.Size = new System.Drawing.Size(183, 198);
            // 
            // mnuItemCheck
            // 
            this.mnuItemCheck.Name = "mnuItemCheck";
            this.mnuItemCheck.Size = new System.Drawing.Size(182, 22);
            this.mnuItemCheck.Text = "Chọn";
            this.mnuItemCheck.Click += new System.EventHandler(this.mnuItemCheck_Click);
            // 
            // mnuUnCheck
            // 
            this.mnuUnCheck.Name = "mnuUnCheck";
            this.mnuUnCheck.Size = new System.Drawing.Size(182, 22);
            this.mnuUnCheck.Text = "Bỏ chọn";
            this.mnuUnCheck.Click += new System.EventHandler(this.mnuUnCheck_Click);
            // 
            // mnuItemSave
            // 
            this.mnuItemSave.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemSave.Image")));
            this.mnuItemSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuItemSave.Name = "mnuItemSave";
            this.mnuItemSave.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.mnuItemSave.Size = new System.Drawing.Size(182, 22);
            this.mnuItemSave.Text = "Lưu";
            this.mnuItemSave.Visible = false;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(179, 6);
            // 
            // mnuItemRefresh
            // 
            this.mnuItemRefresh.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemRefresh.Image")));
            this.mnuItemRefresh.Name = "mnuItemRefresh";
            this.mnuItemRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnuItemRefresh.Size = new System.Drawing.Size(182, 22);
            this.mnuItemRefresh.Text = "Nạp lại";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(179, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemPrint,
            this.mnuItemPrintForScan,
            this.toolStripSeparator4,
            this.mnuItemPrint2});
            this.toolStripMenuItem1.Image = global::StudentManager.Properties.Resources.print1;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
            this.toolStripMenuItem1.Text = "In";
            // 
            // mnuItemPrint
            // 
            this.mnuItemPrint.Name = "mnuItemPrint";
            this.mnuItemPrint.Size = new System.Drawing.Size(200, 22);
            this.mnuItemPrint.Text = "Danh sách dự thi";
            this.mnuItemPrint.Click += new System.EventHandler(this.mnuItemPrint_Click);
            // 
            // mnuItemPrintForScan
            // 
            this.mnuItemPrintForScan.Name = "mnuItemPrintForScan";
            this.mnuItemPrintForScan.Size = new System.Drawing.Size(200, 22);
            this.mnuItemPrintForScan.Text = "Danh sách dự thi - scan";
            this.mnuItemPrintForScan.Click += new System.EventHandler(this.mnuItemPrintForScan_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(197, 6);
            // 
            // mnuItemPrint2
            // 
            this.mnuItemPrint2.Name = "mnuItemPrint2";
            this.mnuItemPrint2.Size = new System.Drawing.Size(200, 22);
            this.mnuItemPrint2.Text = "Danh sách không dự thi";
            this.mnuItemPrint2.Click += new System.EventHandler(this.mnuItemPrint2_Click);
            // 
            // mnuItemExportToExcel
            // 
            this.mnuItemExportToExcel.Image = global::StudentManager.Properties.Resources.excel;
            this.mnuItemExportToExcel.Name = "mnuItemExportToExcel";
            this.mnuItemExportToExcel.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.mnuItemExportToExcel.Size = new System.Drawing.Size(182, 22);
            this.mnuItemExportToExcel.Text = "Xuất excel";
            this.mnuItemExportToExcel.Click += new System.EventHandler(this.mnuItemExportToExcel_Click);
            // 
            // mnuItemExportTemplateExcel
            // 
            this.mnuItemExportTemplateExcel.Image = global::StudentManager.Properties.Resources.excel;
            this.mnuItemExportTemplateExcel.Name = "mnuItemExportTemplateExcel";
            this.mnuItemExportTemplateExcel.Size = new System.Drawing.Size(182, 22);
            this.mnuItemExportTemplateExcel.Text = "Xuất excel theo mẫu";
            this.mnuItemExportTemplateExcel.Click += new System.EventHandler(this.mnuItemExportTemplateExcel_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(179, 6);
            // 
            // mnuItemClose
            // 
            this.mnuItemClose.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemClose.Image")));
            this.mnuItemClose.Name = "mnuItemClose";
            this.mnuItemClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuItemClose.Size = new System.Drawing.Size(182, 22);
            this.mnuItemClose.Text = "Đóng";
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
            this.gvData.OptionsView.ShowGroupPanel = false;
            this.gvData.ResetGridColumn = true;
            this.gvData.RowFilter = "";
            this.gvData.SummaryCollection = "";
            this.gvData.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvData_ValidateRow);
            // 
            // rdoTestOrder3
            // 
            this.rdoTestOrder3.AutoSize = true;
            this.rdoTestOrder3.EnterMoveNextControl = true;
            this.rdoTestOrder3.Location = new System.Drawing.Point(149, 319);
            this.rdoTestOrder3.Name = "rdoTestOrder3";
            this.rdoTestOrder3.Size = new System.Drawing.Size(51, 17);
            this.rdoTestOrder3.TabIndex = 62;
            this.rdoTestOrder3.TabStop = true;
            this.rdoTestOrder3.Text = "Lần 3";
            this.rdoTestOrder3.UseVisualStyleBackColor = true;
            // 
            // frmExamStudentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 509);
            this.Controls.Add(this.dockPanel2);
            this.Controls.Add(this.dockPanel1);
            this.Name = "frmExamStudentList";
            this.Text = "Danh sách sinh viên dự thi";
            this.Load += new System.EventHandler(this.frmExamStudentList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.dockPanel1_Container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsAllowExam.Properties)).EndInit();
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
        private Control.DgRatioButton rdoTestOrder1;
        private Control.DgRatioButton rdoTestOrder2;
        private Control.DgButton btnSave;
        private Control.DgButton btnReview;
        private System.Windows.Forms.ToolStripMenuItem mnuItemCheck;
        private System.Windows.Forms.ToolStripMenuItem mnuUnCheck;
        private System.Windows.Forms.ToolStripMenuItem mnuItemExportTemplateExcel;
        private Control.DgCheckEdit chkIsAllowExam;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPrint;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPrintForScan;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPrint2;
        private Control.DgRatioButton rdoTestOrder3;
    }
}