namespace StudentManager.RewardSanction
{
    partial class frmSanctionStatistic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSanctionStatistic));
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager();
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.lookupSanctionForm = new Control.ULookUpEdit();
            this.txtDecisionNo = new Control.UTextEdit();
            this.cbxIsActived = new DevExpress.XtraEditors.ComboBoxEdit();
            this.dgLabel1 = new Control.DgLabel();
            this.btnAdd = new Control.DgButton();
            this.btnDelete = new Control.DgButton();
            this.uClass = new TrainingPlan.FramePlan.UClass1();
            this.btnPrint = new Control.DgButton();
            this.btnClose = new Control.DgButton();
            this.btnEdit = new Control.DgButton();
            this.btnSearch = new Control.DgButton();
            this.uYearSemester = new DeclarationManager.Education.UYearSemester();
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gcData = new Control.DgGridControl();
            this.mnuPopupGrid = new System.Windows.Forms.ContextMenuStrip();
            this.mnuItemAddMulti = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemEditMulti = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemPrintMulti = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.gvData = new Control.DgGridView();
            this.DateEnd = new Control.UDateEdit();
            this.dateStart = new Control.UDateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxIsActived.Properties)).BeginInit();
            this.dockPanel2.SuspendLayout();
            this.dockPanel2_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).BeginInit();
            this.mnuPopupGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).BeginInit();
            this.SuspendLayout();
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.repositoryItemComboBox1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.repositoryItemComboBox1.Appearance.Options.UseBackColor = true;
            this.repositoryItemComboBox1.Appearance.Options.UseFont = true;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Items.AddRange(new object[] {
            "Tất cả",
            "Đã có hiệu lực",
            "Chưa có hiệu lực"});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
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
            this.dockPanel1_Container.Controls.Add(this.DateEnd);
            this.dockPanel1_Container.Controls.Add(this.lookupSanctionForm);
            this.dockPanel1_Container.Controls.Add(this.dateStart);
            this.dockPanel1_Container.Controls.Add(this.txtDecisionNo);
            this.dockPanel1_Container.Controls.Add(this.cbxIsActived);
            this.dockPanel1_Container.Controls.Add(this.dgLabel1);
            this.dockPanel1_Container.Controls.Add(this.btnAdd);
            this.dockPanel1_Container.Controls.Add(this.btnDelete);
            this.dockPanel1_Container.Controls.Add(this.uClass);
            this.dockPanel1_Container.Controls.Add(this.btnPrint);
            this.dockPanel1_Container.Controls.Add(this.btnClose);
            this.dockPanel1_Container.Controls.Add(this.btnEdit);
            this.dockPanel1_Container.Controls.Add(this.btnSearch);
            this.dockPanel1_Container.Controls.Add(this.uYearSemester);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(234, 442);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // lookupSanctionForm
            // 
            this.lookupSanctionForm.Caption = "Hình thức KL:";
            this.lookupSanctionForm.DataSource = null;
            this.lookupSanctionForm.EditorLeft = 90;
            this.lookupSanctionForm.EditValue = null;
            this.lookupSanctionForm.Location = new System.Drawing.Point(3, 252);
            this.lookupSanctionForm.Name = "lookupSanctionForm";
            this.lookupSanctionForm.ReadOnly = false;
            this.lookupSanctionForm.RowFilter = "";
            this.lookupSanctionForm.Size = new System.Drawing.Size(228, 21);
            this.lookupSanctionForm.TabIndex = 59;
            this.lookupSanctionForm.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // txtDecisionNo
            // 
            this.txtDecisionNo.Caption = "Số quyết định:";
            this.txtDecisionNo.EditorLeft = 90;
            this.txtDecisionNo.EditValue = null;
            this.txtDecisionNo.EditValueDouble = null;
            this.txtDecisionNo.EditValueInt32 = null;
            this.txtDecisionNo.Location = new System.Drawing.Point(4, 229);
            this.txtDecisionNo.MaxLength = 0;
            this.txtDecisionNo.Name = "txtDecisionNo";
            this.txtDecisionNo.PasswordChar = '\0';
            this.txtDecisionNo.ReadOnly = false;
            this.txtDecisionNo.Size = new System.Drawing.Size(227, 21);
            this.txtDecisionNo.TabIndex = 3;
            this.txtDecisionNo.TextTrim = "";
            // 
            // cbxIsActived
            // 
            this.cbxIsActived.EditValue = "Tất cả";
            this.cbxIsActived.Location = new System.Drawing.Point(93, 275);
            this.cbxIsActived.Name = "cbxIsActived";
            this.cbxIsActived.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxIsActived.Properties.Items.AddRange(new object[] {
            "Tất cả",
            "Đã có hiệu lực",
            "Chưa có hiệu lực"});
            this.cbxIsActived.Size = new System.Drawing.Size(139, 20);
            this.cbxIsActived.TabIndex = 2;
            // 
            // dgLabel1
            // 
            this.dgLabel1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dgLabel1.Location = new System.Drawing.Point(4, 278);
            this.dgLabel1.Name = "dgLabel1";
            this.dgLabel1.Size = new System.Drawing.Size(60, 14);
            this.dgLabel1.TabIndex = 59;
            this.dgLabel1.Text = "Trạng thái:";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Image = global::StudentManager.Properties.Resources.Add;
            this.btnAdd.Location = new System.Drawing.Point(119, 358);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(104, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Enabled = false;
            this.btnDelete.Image = global::StudentManager.Properties.Resources.Delete;
            this.btnDelete.Location = new System.Drawing.Point(12, 387);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(104, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
            this.uClass.Size = new System.Drawing.Size(228, 171);
            this.uClass.SpecialBranchIDEditValue = null;
            this.uClass.SpecialBranchSubjectIDEditValue = null;
            this.uClass.TabIndex = 0;
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
            this.btnPrint.TabIndex = 7;
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
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Enabled = false;
            this.btnEdit.Image = global::StudentManager.Properties.Resources.Edit;
            this.btnEdit.Location = new System.Drawing.Point(119, 387);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(104, 23);
            this.btnEdit.TabIndex = 17;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = global::StudentManager.Properties.Resources.Search;
            this.btnSearch.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(12, 358);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(104, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // uYearSemester
            // 
            this.uYearSemester.EditorLeft = 90;
            this.uYearSemester.Location = new System.Drawing.Point(4, 179);
            this.uYearSemester.Name = "uYearSemester";
            this.uYearSemester.ReadOnly = false;
            this.uYearSemester.SemesterEditValue = null;
            this.uYearSemester.Size = new System.Drawing.Size(228, 48);
            this.uYearSemester.TabIndex = 1;
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
            this.dockPanel2.Text = "DANH SÁCH SINH VIÊN BỊ KỶ LUẬT";
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
            this.gcData.Location = new System.Drawing.Point(0, 0);
            this.gcData.MainView = this.gvData;
            this.gcData.Name = "gcData";
            this.gcData.Size = new System.Drawing.Size(679, 439);
            this.gcData.TabIndex = 32;
            this.gcData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvData});
            this.gcData.DoubleClick += new System.EventHandler(this.btnEdit_Click);
            // 
            // mnuPopupGrid
            // 
            this.mnuPopupGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemAddMulti,
            this.mnuItemEditMulti,
            this.mnuItemPrintMulti,
            this.toolStripSeparator4,
            this.mnuItemAdd,
            this.mnuItemDelete,
            this.mnuItemEdit,
            this.toolStripSeparator3,
            this.mnuItemRefresh,
            this.toolStripSeparator1,
            this.mnuItemExportToExcel,
            this.toolStripSeparator2,
            this.mnuItemClose});
            this.mnuPopupGrid.Name = "mnuPopupGrid";
            this.mnuPopupGrid.Size = new System.Drawing.Size(196, 248);
            // 
            // mnuItemAddMulti
            // 
            this.mnuItemAddMulti.Name = "mnuItemAddMulti";
            this.mnuItemAddMulti.Size = new System.Drawing.Size(195, 22);
            this.mnuItemAddMulti.Text = "Thêm hàng loạt";
            this.mnuItemAddMulti.Click += new System.EventHandler(this.mnuItemAddMulti_Click);
            // 
            // mnuItemEditMulti
            // 
            this.mnuItemEditMulti.Enabled = false;
            this.mnuItemEditMulti.Name = "mnuItemEditMulti";
            this.mnuItemEditMulti.Size = new System.Drawing.Size(195, 22);
            this.mnuItemEditMulti.Text = "Chỉnh sửa hết";
            this.mnuItemEditMulti.Click += new System.EventHandler(this.mnuItemEditMulti_Click);
            // 
            // mnuItemPrintMulti
            // 
            this.mnuItemPrintMulti.Enabled = false;
            this.mnuItemPrintMulti.Name = "mnuItemPrintMulti";
            this.mnuItemPrintMulti.Size = new System.Drawing.Size(195, 22);
            this.mnuItemPrintMulti.Text = "In biên bản họp kỷ luật";
            this.mnuItemPrintMulti.Click += new System.EventHandler(this.mnuItemPrintMulti_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(192, 6);
            // 
            // mnuItemAdd
            // 
            this.mnuItemAdd.Enabled = false;
            this.mnuItemAdd.Image = global::StudentManager.Properties.Resources.Add;
            this.mnuItemAdd.Name = "mnuItemAdd";
            this.mnuItemAdd.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.mnuItemAdd.Size = new System.Drawing.Size(195, 22);
            this.mnuItemAdd.Text = "Thêm";
            this.mnuItemAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // mnuItemDelete
            // 
            this.mnuItemDelete.Enabled = false;
            this.mnuItemDelete.Image = global::StudentManager.Properties.Resources.Delete;
            this.mnuItemDelete.Name = "mnuItemDelete";
            this.mnuItemDelete.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.mnuItemDelete.Size = new System.Drawing.Size(195, 22);
            this.mnuItemDelete.Text = "Xóa";
            this.mnuItemDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // mnuItemEdit
            // 
            this.mnuItemEdit.Enabled = false;
            this.mnuItemEdit.Image = global::StudentManager.Properties.Resources.Edit;
            this.mnuItemEdit.Name = "mnuItemEdit";
            this.mnuItemEdit.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.mnuItemEdit.Size = new System.Drawing.Size(195, 22);
            this.mnuItemEdit.Text = "Sửa";
            this.mnuItemEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(192, 6);
            // 
            // mnuItemRefresh
            // 
            this.mnuItemRefresh.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemRefresh.Image")));
            this.mnuItemRefresh.Name = "mnuItemRefresh";
            this.mnuItemRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnuItemRefresh.Size = new System.Drawing.Size(195, 22);
            this.mnuItemRefresh.Text = "Nạp lại";
            this.mnuItemRefresh.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(192, 6);
            // 
            // mnuItemExportToExcel
            // 
            this.mnuItemExportToExcel.Image = global::StudentManager.Properties.Resources.excel;
            this.mnuItemExportToExcel.Name = "mnuItemExportToExcel";
            this.mnuItemExportToExcel.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.mnuItemExportToExcel.Size = new System.Drawing.Size(195, 22);
            this.mnuItemExportToExcel.Text = "Xuất excel";
            this.mnuItemExportToExcel.Click += new System.EventHandler(this.mnuItemExportToExcel_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(192, 6);
            // 
            // mnuItemClose
            // 
            this.mnuItemClose.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemClose.Image")));
            this.mnuItemClose.Name = "mnuItemClose";
            this.mnuItemClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuItemClose.Size = new System.Drawing.Size(195, 22);
            this.mnuItemClose.Text = "Đóng";
            this.mnuItemClose.Click += new System.EventHandler(this.btnClose_Click);
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
            this.gvData.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gvData_SelectionChanged);
            this.gvData.EndSorting += new System.EventHandler(this.gvData_EndSorting);
            this.gvData.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvData_ValidateRow);
            // 
            // DateEnd
            // 
            this.DateEnd.Caption = "Đến  ngày:";
            this.DateEnd.EditorLeft = 90;
            this.DateEnd.EditValue = null;
            this.DateEnd.EditValueDateTime = null;
            this.DateEnd.Location = new System.Drawing.Point(3, 320);
            this.DateEnd.Name = "DateEnd";
            this.DateEnd.ReadOnly = false;
            this.DateEnd.Size = new System.Drawing.Size(228, 21);
            this.DateEnd.TabIndex = 57;
            // 
            // dateStart
            // 
            this.dateStart.Caption = "Từ ngày:";
            this.dateStart.EditorLeft = 90;
            this.dateStart.EditValue = null;
            this.dateStart.EditValueDateTime = null;
            this.dateStart.Location = new System.Drawing.Point(3, 297);
            this.dateStart.Name = "dateStart";
            this.dateStart.ReadOnly = false;
            this.dateStart.Size = new System.Drawing.Size(228, 21);
            this.dateStart.TabIndex = 56;
            // 
            // frmSanctionStatistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 469);
            this.Controls.Add(this.dockPanel2);
            this.Controls.Add(this.dockPanel1);
            this.Name = "frmSanctionStatistic";
            this.Text = "Thống kê kỷ luật";
            this.Load += new System.EventHandler(this.frmSanctionStatistic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.dockPanel1_Container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxIsActived.Properties)).EndInit();
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
        private DeclarationManager.Education.UYearSemester uYearSemester;
        private Control.DgButton btnSearch;
        private Control.DgButton btnEdit;
        private Control.DgButton btnClose;
        private Control.DgButton btnPrint;
        private Control.DgGridControl gcData;
        private Control.DgGridView gvData;
        private System.Windows.Forms.ContextMenuStrip mnuPopupGrid;
        private System.Windows.Forms.ToolStripMenuItem mnuItemAdd;
        private System.Windows.Forms.ToolStripMenuItem mnuItemDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuItemRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuItemExportToExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuItemClose;
        private TrainingPlan.FramePlan.UClass1 uClass;
        private Control.DgButton btnAdd;
        private Control.DgButton btnDelete;
        private Control.DgLabel dgLabel1;
        private System.Windows.Forms.ToolStripMenuItem mnuItemAddMulti;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.ComboBoxEdit cbxIsActived;
        private System.Windows.Forms.ToolStripMenuItem mnuItemEditMulti;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mnuItemEdit;
        private Control.UTextEdit txtDecisionNo;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPrintMulti;
        private Control.ULookUpEdit lookupSanctionForm;
        private Control.UDateEdit DateEnd;
        private Control.UDateEdit dateStart;
    }
}