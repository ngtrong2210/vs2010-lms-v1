namespace StudentManager.StudentCollection
{
    partial class frmStudentCollectionResult
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStudentCollectionResult));
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager();
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.btnFillToClass = new Control.DgButton();
            this.lookupClassID = new Control.ULookUpEdit();
            this.dgLabel1 = new Control.DgLabel();
            this.cbxResult = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnPrint1 = new Control.DgButton();
            this.txtFullName = new Control.UTextEdit();
            this.txtStudentCollectionCode = new Control.UTextEdit();
            this.uSpecialBranch = new DeclarationManager.Education.USpecialBranch();
            this.txtToDate = new Control.UDateEdit();
            this.uPeriod = new StudentManager.StudentCollection.UStudentCollectionPeriod();
            this.txtFromDate = new Control.UDateEdit();
            this.btnPrint0 = new Control.DgButton();
            this.btnClose = new Control.DgButton();
            this.btnSearch = new Control.DgButton();
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gcData = new Control.DgGridControl();
            this.mnuPopupGrid = new System.Windows.Forms.ContextMenuStrip();
            this.mnuItemSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemUnSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemUpdateCerNo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemPrintNote1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemPrintNote2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemPrintNode3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemPrintNote0 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemPrint_BiaThu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrint_DSTrungTuyen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrint4 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrint_DSTrungTuyen2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrint_DSTrungTuyen3 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGiayXacNhan = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_NhapHoc_Word = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.gvData = new Control.DgGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxResult.Properties)).BeginInit();
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
            this.dockPanel1.Size = new System.Drawing.Size(242, 469);
            this.dockPanel1.Text = "Thông tin tìm kiếm";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.btnFillToClass);
            this.dockPanel1_Container.Controls.Add(this.lookupClassID);
            this.dockPanel1_Container.Controls.Add(this.dgLabel1);
            this.dockPanel1_Container.Controls.Add(this.cbxResult);
            this.dockPanel1_Container.Controls.Add(this.btnPrint1);
            this.dockPanel1_Container.Controls.Add(this.txtFullName);
            this.dockPanel1_Container.Controls.Add(this.txtStudentCollectionCode);
            this.dockPanel1_Container.Controls.Add(this.uSpecialBranch);
            this.dockPanel1_Container.Controls.Add(this.txtToDate);
            this.dockPanel1_Container.Controls.Add(this.uPeriod);
            this.dockPanel1_Container.Controls.Add(this.txtFromDate);
            this.dockPanel1_Container.Controls.Add(this.btnPrint0);
            this.dockPanel1_Container.Controls.Add(this.btnClose);
            this.dockPanel1_Container.Controls.Add(this.btnSearch);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(234, 442);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // btnFillToClass
            // 
            this.btnFillToClass.Location = new System.Drawing.Point(191, 312);
            this.btnFillToClass.Name = "btnFillToClass";
            this.btnFillToClass.Size = new System.Drawing.Size(36, 23);
            this.btnFillToClass.TabIndex = 85;
            this.btnFillToClass.Text = ">>";
            this.btnFillToClass.Click += new System.EventHandler(this.btnFillToClass_Click);
            // 
            // lookupClassID
            // 
            this.lookupClassID.AllowNull = true;
            this.lookupClassID.Caption = "Lớp:";
            this.lookupClassID.DataSource = null;
            this.lookupClassID.EditorLeft = 30;
            this.lookupClassID.EditValue = null;
            this.lookupClassID.EnterEditValue = null;
            this.lookupClassID.IsTimeout = false;
            this.lookupClassID.Location = new System.Drawing.Point(8, 312);
            this.lookupClassID.Name = "lookupClassID";
            this.lookupClassID.ReadOnly = false;
            this.lookupClassID.RowFilter = "";
            this.lookupClassID.Size = new System.Drawing.Size(182, 21);
            this.lookupClassID.TabIndex = 84;
            this.lookupClassID.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // dgLabel1
            // 
            this.dgLabel1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dgLabel1.Location = new System.Drawing.Point(7, 271);
            this.dgLabel1.Name = "dgLabel1";
            this.dgLabel1.Size = new System.Drawing.Size(60, 14);
            this.dgLabel1.TabIndex = 83;
            this.dgLabel1.Text = "Trạng thái:";
            // 
            // cbxResult
            // 
            this.cbxResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxResult.EditValue = "4. Trúng tuyển";
            this.cbxResult.Location = new System.Drawing.Point(97, 268);
            this.cbxResult.Name = "cbxResult";
            this.cbxResult.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxResult.Properties.Items.AddRange(new object[] {
            "0. Chờ xét hoặc chưa đạt",
            "1. Trúng tuyển NV1",
            "2. Trúng tuyển NV2",
            "3. Trúng tuyển NV3",
            "4. Trúng tuyển"});
            this.cbxResult.Size = new System.Drawing.Size(134, 20);
            this.cbxResult.TabIndex = 82;
            // 
            // btnPrint1
            // 
            this.btnPrint1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint1.Enabled = false;
            this.btnPrint1.Image = global::StudentManager.Properties.Resources.print;
            this.btnPrint1.Location = new System.Drawing.Point(12, 416);
            this.btnPrint1.Name = "btnPrint1";
            this.btnPrint1.Size = new System.Drawing.Size(104, 23);
            this.btnPrint1.TabIndex = 56;
            this.btnPrint1.Text = "Trúng tuyển";
            this.btnPrint1.Click += new System.EventHandler(this.btnPrint1_Click);
            // 
            // txtFullName
            // 
            this.txtFullName.AllowNull = true;
            this.txtFullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFullName.Caption = "Họ tên:";
            this.txtFullName.EditorBackColor = System.Drawing.SystemColors.Window;
            this.txtFullName.EditorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.txtFullName.EditorLeft = 90;
            this.txtFullName.EditValue = null;
            this.txtFullName.EditValueDecimal = null;
            this.txtFullName.EditValueDouble = null;
            this.txtFullName.EditValueInt32 = null;
            this.txtFullName.EnterMoveNext = true;
            this.txtFullName.FontSize = 9F;
            this.txtFullName.Location = new System.Drawing.Point(8, 241);
            this.txtFullName.MaxLength = 0;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.PasswordChar = '\0';
            this.txtFullName.ReadOnly = false;
            this.txtFullName.Size = new System.Drawing.Size(223, 21);
            this.txtFullName.TabIndex = 61;
            this.txtFullName.TextTrim = "";
            // 
            // txtStudentCollectionCode
            // 
            this.txtStudentCollectionCode.AllowNull = true;
            this.txtStudentCollectionCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStudentCollectionCode.Caption = "Số HS:";
            this.txtStudentCollectionCode.EditorBackColor = System.Drawing.SystemColors.Window;
            this.txtStudentCollectionCode.EditorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.txtStudentCollectionCode.EditorLeft = 90;
            this.txtStudentCollectionCode.EditValue = null;
            this.txtStudentCollectionCode.EditValueDecimal = null;
            this.txtStudentCollectionCode.EditValueDouble = null;
            this.txtStudentCollectionCode.EditValueInt32 = null;
            this.txtStudentCollectionCode.EnterMoveNext = true;
            this.txtStudentCollectionCode.FontSize = 9F;
            this.txtStudentCollectionCode.Location = new System.Drawing.Point(8, 214);
            this.txtStudentCollectionCode.MaxLength = 0;
            this.txtStudentCollectionCode.Name = "txtStudentCollectionCode";
            this.txtStudentCollectionCode.PasswordChar = '\0';
            this.txtStudentCollectionCode.ReadOnly = false;
            this.txtStudentCollectionCode.Size = new System.Drawing.Size(223, 21);
            this.txtStudentCollectionCode.TabIndex = 60;
            this.txtStudentCollectionCode.TextTrim = "";
            // 
            // uSpecialBranch
            // 
            this.uSpecialBranch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uSpecialBranch.BranchEditValue = null;
            this.uSpecialBranch.BranchFilter = "";
            this.uSpecialBranch.EditorLeft = 90;
            this.uSpecialBranch.Location = new System.Drawing.Point(8, 110);
            this.uSpecialBranch.Name = "uSpecialBranch";
            this.uSpecialBranch.ReadOnly = false;
            this.uSpecialBranch.Size = new System.Drawing.Size(223, 46);
            this.uSpecialBranch.SpecialBranchEditValue = null;
            this.uSpecialBranch.SpecialBranchFilter = "";
            this.uSpecialBranch.TabIndex = 59;
            this.uSpecialBranch.EditValueChanged += new DeclarationManager.Education.USpecialBranch.EditValueChangedDelegate(this.uSpecialBranch_EditValueChanged);
            // 
            // txtToDate
            // 
            this.txtToDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToDate.Caption = "Đến ngày:";
            this.txtToDate.EditorLeft = 90;
            this.txtToDate.EditValue = null;
            this.txtToDate.EditValueDate = null;
            this.txtToDate.EditValueDateTime = null;
            this.txtToDate.FormatString = "d";
            this.txtToDate.Location = new System.Drawing.Point(8, 187);
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.ReadOnly = false;
            this.txtToDate.Size = new System.Drawing.Size(223, 21);
            this.txtToDate.TabIndex = 52;
            // 
            // uPeriod
            // 
            this.uPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uPeriod.CollectionType = -1;
            this.uPeriod.CourseIDEditValue = null;
            this.uPeriod.EditorLeft = 90;
            this.uPeriod.LearningLevel = -1;
            this.uPeriod.Location = new System.Drawing.Point(8, 3);
            this.uPeriod.Name = "uPeriod";
            this.uPeriod.ReadOnly = false;
            this.uPeriod.Size = new System.Drawing.Size(223, 104);
            this.uPeriod.StudentCollectionPeriodIDEditValue = null;
            this.uPeriod.TabIndex = 58;
            this.uPeriod.TrainingLevelIDEditValue = null;
            this.uPeriod.TrainingTypeEditValue = null;
            this.uPeriod.EditValueChanged += new StudentManager.StudentCollection.UStudentCollectionPeriod.EditValueChangedDelegate(this.uPeriod_EditValueChanged);
            // 
            // txtFromDate
            // 
            this.txtFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFromDate.Caption = "Từ ngày:";
            this.txtFromDate.EditorLeft = 90;
            this.txtFromDate.EditValue = null;
            this.txtFromDate.EditValueDate = null;
            this.txtFromDate.EditValueDateTime = null;
            this.txtFromDate.FormatString = "d";
            this.txtFromDate.Location = new System.Drawing.Point(8, 161);
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.ReadOnly = false;
            this.txtFromDate.Size = new System.Drawing.Size(223, 21);
            this.txtFromDate.TabIndex = 51;
            // 
            // btnPrint0
            // 
            this.btnPrint0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint0.Enabled = false;
            this.btnPrint0.Image = global::StudentManager.Properties.Resources.print;
            this.btnPrint0.Location = new System.Drawing.Point(122, 387);
            this.btnPrint0.Name = "btnPrint0";
            this.btnPrint0.Size = new System.Drawing.Size(104, 23);
            this.btnPrint0.TabIndex = 55;
            this.btnPrint0.Text = "Không đạt";
            this.btnPrint0.Click += new System.EventHandler(this.btnPrint0_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = global::StudentManager.Properties.Resources.Cancel;
            this.btnClose.Location = new System.Drawing.Point(122, 416);
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
            this.btnSearch.Location = new System.Drawing.Point(12, 387);
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
            this.dockPanel2.Size = new System.Drawing.Size(687, 469);
            this.dockPanel2.Text = "Hồ sơ tuyển sinh";
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
            this.gcData.EnterMoveNextControl = true;
            this.gcData.Location = new System.Drawing.Point(0, 0);
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
            this.mnuItemSelect,
            this.mnuItemUnSelect,
            this.mnuItemEdit,
            this.mnuItemUpdateCerNo,
            this.mnuItemRefresh,
            this.toolStripSeparator1,
            this.mnuItemPrint,
            this.mnuItemExportToExcel,
            this.toolStripSeparator2,
            this.mnuItemClose});
            this.mnuPopupGrid.Name = "mnuPopupGrid";
            this.mnuPopupGrid.Size = new System.Drawing.Size(190, 214);
            // 
            // mnuItemSelect
            // 
            this.mnuItemSelect.Name = "mnuItemSelect";
            this.mnuItemSelect.Size = new System.Drawing.Size(189, 22);
            this.mnuItemSelect.Text = "Chọn";
            this.mnuItemSelect.Click += new System.EventHandler(this.mnuItemSelect_Click);
            // 
            // mnuItemUnSelect
            // 
            this.mnuItemUnSelect.Name = "mnuItemUnSelect";
            this.mnuItemUnSelect.Size = new System.Drawing.Size(189, 22);
            this.mnuItemUnSelect.Text = "Bỏ chọn";
            this.mnuItemUnSelect.Click += new System.EventHandler(this.mnuItemUnSelect_Click);
            // 
            // mnuItemEdit
            // 
            this.mnuItemEdit.Image = global::StudentManager.Properties.Resources.Edit;
            this.mnuItemEdit.Name = "mnuItemEdit";
            this.mnuItemEdit.Size = new System.Drawing.Size(189, 22);
            this.mnuItemEdit.Text = "Xem chi tiết";
            this.mnuItemEdit.Click += new System.EventHandler(this.mnuItemEdit_Click);
            // 
            // mnuItemUpdateCerNo
            // 
            this.mnuItemUpdateCerNo.Name = "mnuItemUpdateCerNo";
            this.mnuItemUpdateCerNo.Size = new System.Drawing.Size(189, 22);
            this.mnuItemUpdateCerNo.Text = "Cập nhật thứ tự hồ sơ";
            this.mnuItemUpdateCerNo.Click += new System.EventHandler(this.mnuItemUpdateCerNo_Click);
            // 
            // mnuItemRefresh
            // 
            this.mnuItemRefresh.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemRefresh.Image")));
            this.mnuItemRefresh.Name = "mnuItemRefresh";
            this.mnuItemRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnuItemRefresh.Size = new System.Drawing.Size(189, 22);
            this.mnuItemRefresh.Text = "Nạp lại";
            this.mnuItemRefresh.Click += new System.EventHandler(this.mnuItemRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(186, 6);
            // 
            // mnuItemPrint
            // 
            this.mnuItemPrint.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemPrintNote1,
            this.mnuItemPrintNote2,
            this.mnuItemPrintNode3,
            this.toolStripSeparator3,
            this.mnuItemPrintNote0,
            this.mnuItemPrint_BiaThu,
            this.mnuPrint_DSTrungTuyen,
            this.mnuPrint4,
            this.mnuPrint_DSTrungTuyen2,
            this.mnuPrint_DSTrungTuyen3,
            this.mnuGiayXacNhan,
            this.btn_NhapHoc_Word});
            this.mnuItemPrint.Enabled = false;
            this.mnuItemPrint.Image = global::StudentManager.Properties.Resources.print1;
            this.mnuItemPrint.Name = "mnuItemPrint";
            this.mnuItemPrint.Size = new System.Drawing.Size(189, 22);
            this.mnuItemPrint.Text = "In giấy báo";
            // 
            // mnuItemPrintNote1
            // 
            this.mnuItemPrintNote1.Name = "mnuItemPrintNote1";
            this.mnuItemPrintNote1.Size = new System.Drawing.Size(245, 22);
            this.mnuItemPrintNote1.Text = "Giấy báo trúng tuyển";
            this.mnuItemPrintNote1.Click += new System.EventHandler(this.mnuItemPrintNote1_Click);
            // 
            // mnuItemPrintNote2
            // 
            this.mnuItemPrintNote2.Name = "mnuItemPrintNote2";
            this.mnuItemPrintNote2.Size = new System.Drawing.Size(245, 22);
            this.mnuItemPrintNote2.Text = "Giấy báo trúng tuyển trung cấp";
            this.mnuItemPrintNote2.Visible = false;
            this.mnuItemPrintNote2.Click += new System.EventHandler(this.mnuItemPrintNote2_Click);
            // 
            // mnuItemPrintNode3
            // 
            this.mnuItemPrintNode3.Name = "mnuItemPrintNode3";
            this.mnuItemPrintNode3.Size = new System.Drawing.Size(245, 22);
            this.mnuItemPrintNode3.Text = "Giấy báo nhập học";
            this.mnuItemPrintNode3.Visible = false;
            this.mnuItemPrintNode3.Click += new System.EventHandler(this.mnuItemPrintNode3_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(242, 6);
            // 
            // mnuItemPrintNote0
            // 
            this.mnuItemPrintNote0.Name = "mnuItemPrintNote0";
            this.mnuItemPrintNote0.Size = new System.Drawing.Size(245, 22);
            this.mnuItemPrintNote0.Text = "Giấy báo không trúng tuyển";
            this.mnuItemPrintNote0.Click += new System.EventHandler(this.mnuItemPrintNote0_Click);
            // 
            // mnuItemPrint_BiaThu
            // 
            this.mnuItemPrint_BiaThu.Name = "mnuItemPrint_BiaThu";
            this.mnuItemPrint_BiaThu.Size = new System.Drawing.Size(245, 22);
            this.mnuItemPrint_BiaThu.Text = "Bìa thư";
            this.mnuItemPrint_BiaThu.Click += new System.EventHandler(this.mnuItemPrint_BiaThu_Click);
            // 
            // mnuPrint_DSTrungTuyen
            // 
            this.mnuPrint_DSTrungTuyen.Name = "mnuPrint_DSTrungTuyen";
            this.mnuPrint_DSTrungTuyen.Size = new System.Drawing.Size(245, 22);
            this.mnuPrint_DSTrungTuyen.Text = "Danh sách dự xét và trúng tuyển";
            this.mnuPrint_DSTrungTuyen.Click += new System.EventHandler(this.mnuPrint_DSTrungTuyen_Click);
            // 
            // mnuPrint4
            // 
            this.mnuPrint4.Name = "mnuPrint4";
            this.mnuPrint4.Size = new System.Drawing.Size(245, 22);
            this.mnuPrint4.Text = "Danh sách gởi giấy báo";
            this.mnuPrint4.Visible = false;
            this.mnuPrint4.Click += new System.EventHandler(this.mnuPrint4_Click);
            // 
            // mnuPrint_DSTrungTuyen2
            // 
            this.mnuPrint_DSTrungTuyen2.Name = "mnuPrint_DSTrungTuyen2";
            this.mnuPrint_DSTrungTuyen2.Size = new System.Drawing.Size(245, 22);
            this.mnuPrint_DSTrungTuyen2.Text = "Giấy báo nhập học file Word";
            this.mnuPrint_DSTrungTuyen2.Click += new System.EventHandler(this.mnuPrint4_Click);
            // 
            // mnuPrint_DSTrungTuyen3
            // 
            this.mnuPrint_DSTrungTuyen3.Name = "mnuPrint_DSTrungTuyen3";
            this.mnuPrint_DSTrungTuyen3.Size = new System.Drawing.Size(245, 22);
            this.mnuPrint_DSTrungTuyen3.Text = "Danh sách trúng tuyển 3";
            this.mnuPrint_DSTrungTuyen3.Visible = false;
            this.mnuPrint_DSTrungTuyen3.Click += new System.EventHandler(this.mnuTrungTuyen2_Click);
            // 
            // mnuGiayXacNhan
            // 
            this.mnuGiayXacNhan.Name = "mnuGiayXacNhan";
            this.mnuGiayXacNhan.Size = new System.Drawing.Size(245, 22);
            this.mnuGiayXacNhan.Text = "Giấy xác nhận nhập học";
            this.mnuGiayXacNhan.Visible = false;
            this.mnuGiayXacNhan.Click += new System.EventHandler(this.mnuGiayXacNhan_Click);
            // 
            // btn_NhapHoc_Word
            // 
            this.btn_NhapHoc_Word.Name = "btn_NhapHoc_Word";
            this.btn_NhapHoc_Word.Size = new System.Drawing.Size(245, 22);
            this.btn_NhapHoc_Word.Text = "Giấy xác nhận nhập học - word";
            this.btn_NhapHoc_Word.Click += new System.EventHandler(this.btn_NhapHoc_Word_Click);
            // 
            // mnuItemExportToExcel
            // 
            this.mnuItemExportToExcel.Image = global::StudentManager.Properties.Resources.excel;
            this.mnuItemExportToExcel.Name = "mnuItemExportToExcel";
            this.mnuItemExportToExcel.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.mnuItemExportToExcel.Size = new System.Drawing.Size(189, 22);
            this.mnuItemExportToExcel.Text = "Xuất excel";
            this.mnuItemExportToExcel.Click += new System.EventHandler(this.mnuItemExportToExcel_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(186, 6);
            // 
            // mnuItemClose
            // 
            this.mnuItemClose.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemClose.Image")));
            this.mnuItemClose.Name = "mnuItemClose";
            this.mnuItemClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuItemClose.Size = new System.Drawing.Size(189, 22);
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
            this.gvData.SummaryDisplayFormat = null;
            this.gvData.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvData_ValidateRow);
            // 
            // frmStudentCollectionResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 469);
            this.Controls.Add(this.dockPanel2);
            this.Controls.Add(this.dockPanel1);
            this.KeyPreview = true;
            this.Name = "frmStudentCollectionResult";
            this.ShowIcon = false;
            this.Text = "Kết quả tuyển sinh";
            this.Load += new System.EventHandler(this.frmStudentCollectionResult_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmStudentCollectionResult_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.dockPanel1_Container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxResult.Properties)).EndInit();
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
        private Control.DgButton btnPrint0;
        private Control.DgGridControl gcData;
        private Control.DgGridView gvData;
        private System.Windows.Forms.ContextMenuStrip mnuPopupGrid;
        private System.Windows.Forms.ToolStripMenuItem mnuItemRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuItemExportToExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuItemClose;
        private UStudentCollectionPeriod uPeriod;
        private Control.UTextEdit txtFullName;
        private Control.UTextEdit txtStudentCollectionCode;
        private DeclarationManager.Education.USpecialBranch uSpecialBranch;
        private Control.UDateEdit txtToDate;
        private Control.UDateEdit txtFromDate;
        private Control.DgButton btnPrint1;
        private Control.DgLabel dgLabel1;
        private DevExpress.XtraEditors.ComboBoxEdit cbxResult;
        private Control.DgButton btnFillToClass;
        private Control.ULookUpEdit lookupClassID;
        private System.Windows.Forms.ToolStripMenuItem mnuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPrint;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPrintNote1;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPrintNode3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPrintNote0;
        private System.Windows.Forms.ToolStripMenuItem mnuItemUpdateCerNo;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPrint_BiaThu;
        private System.Windows.Forms.ToolStripMenuItem mnuPrint4;
        private System.Windows.Forms.ToolStripMenuItem mnuPrint_DSTrungTuyen2;
        private System.Windows.Forms.ToolStripMenuItem mnuPrint_DSTrungTuyen3;
        private System.Windows.Forms.ToolStripMenuItem mnuItemSelect;
        private System.Windows.Forms.ToolStripMenuItem mnuItemUnSelect;
        private System.Windows.Forms.ToolStripMenuItem mnuPrint_DSTrungTuyen;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPrintNote2;
        private System.Windows.Forms.ToolStripMenuItem mnuGiayXacNhan;
        private System.Windows.Forms.ToolStripMenuItem btn_NhapHoc_Word;
    }
}