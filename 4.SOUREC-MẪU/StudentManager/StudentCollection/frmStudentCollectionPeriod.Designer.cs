namespace StudentManager.StudentCollection
{
    partial class frmStudentCollectionPeriod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStudentCollectionPeriod));
            this.gcData = new Control.DgGridControl();
            this.mnuPopupGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.gvData = new Control.DgGridView();
            this.tcData = new Control.DgTabControl();
            this.tpList = new Control.DgTabPage();
            this.btnClose = new Control.DgButton();
            this.btnEdit = new Control.DgButton();
            this.btnDelete = new Control.DgButton();
            this.btnAdd = new Control.DgButton();
            this.tpDetail = new Control.DgTabPage();
            this.dgLabel1 = new Control.DgLabel();
            this.cbxCollectionType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtFinishNo = new Control.UCalcEdit();
            this.txtStartNo = new Control.UCalcEdit();
            this.dtmFinishDate = new Control.UDateEdit();
            this.dtmStartDate = new Control.UDateEdit();
            this.uCourseTypeLevel = new DeclarationManager.Education.UCourseTypeLevel();
            this.txtDescription = new Control.URichTextEdit();
            this.btnCancel = new Control.DgButton();
            this.btnSaveEdit = new Control.DgButton();
            this.txtStudentCollectionPeriodName = new Control.UTextEdit();
            this.txtStudentCollectionPeriodID = new Control.UTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).BeginInit();
            this.mnuPopupGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcData)).BeginInit();
            this.tcData.SuspendLayout();
            this.tpList.SuspendLayout();
            this.tpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxCollectionType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcData
            // 
            this.gcData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gcData.ContextMenuStrip = this.mnuPopupGrid;
            this.gcData.Location = new System.Drawing.Point(-1, -1);
            this.gcData.MainView = this.gvData;
            this.gcData.Name = "gcData";
            this.gcData.Size = new System.Drawing.Size(657, 345);
            this.gcData.TabIndex = 0;
            this.gcData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvData});
            this.gcData.DoubleClick += new System.EventHandler(this.btnEdit_Click);
            // 
            // mnuPopupGrid
            // 
            this.mnuPopupGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemAdd,
            this.mnuItemDelete,
            this.mnuItemEdit,
            this.mnuItemSave,
            this.toolStripSeparator3,
            this.mnuItemRefresh,
            this.toolStripSeparator1,
            this.mnuItemExportToExcel,
            this.toolStripSeparator2,
            this.mnuItemClose});
            this.mnuPopupGrid.Name = "mnuPopupGrid";
            this.mnuPopupGrid.Size = new System.Drawing.Size(174, 176);
            // 
            // mnuItemAdd
            // 
            this.mnuItemAdd.Image = global::StudentManager.Properties.Resources.Add;
            this.mnuItemAdd.Name = "mnuItemAdd";
            this.mnuItemAdd.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.mnuItemAdd.Size = new System.Drawing.Size(173, 22);
            this.mnuItemAdd.Text = "Thêm";
            this.mnuItemAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // mnuItemDelete
            // 
            this.mnuItemDelete.Image = global::StudentManager.Properties.Resources.Delete;
            this.mnuItemDelete.Name = "mnuItemDelete";
            this.mnuItemDelete.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.mnuItemDelete.Size = new System.Drawing.Size(173, 22);
            this.mnuItemDelete.Text = "Xóa";
            this.mnuItemDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // mnuItemEdit
            // 
            this.mnuItemEdit.Image = global::StudentManager.Properties.Resources.Edit;
            this.mnuItemEdit.Name = "mnuItemEdit";
            this.mnuItemEdit.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.mnuItemEdit.Size = new System.Drawing.Size(173, 22);
            this.mnuItemEdit.Text = "Sửa";
            this.mnuItemEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // mnuItemSave
            // 
            this.mnuItemSave.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemSave.Image")));
            this.mnuItemSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuItemSave.Name = "mnuItemSave";
            this.mnuItemSave.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.mnuItemSave.Size = new System.Drawing.Size(173, 22);
            this.mnuItemSave.Text = "Lưu";
            this.mnuItemSave.Visible = false;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(170, 6);
            // 
            // mnuItemRefresh
            // 
            this.mnuItemRefresh.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemRefresh.Image")));
            this.mnuItemRefresh.Name = "mnuItemRefresh";
            this.mnuItemRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnuItemRefresh.Size = new System.Drawing.Size(173, 22);
            this.mnuItemRefresh.Text = "Nạp lại";
            this.mnuItemRefresh.Click += new System.EventHandler(this.mnuItemRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(170, 6);
            // 
            // mnuItemExportToExcel
            // 
            this.mnuItemExportToExcel.Image = global::StudentManager.Properties.Resources.excel;
            this.mnuItemExportToExcel.Name = "mnuItemExportToExcel";
            this.mnuItemExportToExcel.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.mnuItemExportToExcel.Size = new System.Drawing.Size(173, 22);
            this.mnuItemExportToExcel.Text = "Xuất excel";
            this.mnuItemExportToExcel.Click += new System.EventHandler(this.mnuItemExportToExcel_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(170, 6);
            // 
            // mnuItemClose
            // 
            this.mnuItemClose.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemClose.Image")));
            this.mnuItemClose.Name = "mnuItemClose";
            this.mnuItemClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuItemClose.Size = new System.Drawing.Size(173, 22);
            this.mnuItemClose.Text = "Đóng";
            this.mnuItemClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gvData
            // 
            this.gvData.GridControl = this.gcData;
            this.gvData.IndicatorWidth = 35;
            this.gvData.IsSelecting = false;
            this.gvData.Name = "gvData";
            this.gvData.OptionsSelection.MultiSelect = true;
            this.gvData.OptionsView.ShowGroupPanel = false;
            this.gvData.ResetGridColumn = true;
            this.gvData.RowFilter = "";
            this.gvData.SummaryCollection = "";
            this.gvData.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gvData_SelectionChanged);
            this.gvData.EndSorting += new System.EventHandler(this.gvData_EndSorting);
            // 
            // tcData
            // 
            this.tcData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcData.Location = new System.Drawing.Point(0, 0);
            this.tcData.Name = "tcData";
            this.tcData.SelectedTabPage = this.tpList;
            this.tcData.SelectIndex = 1;
            this.tcData.Size = new System.Drawing.Size(662, 405);
            this.tcData.TabIndex = 1;
            this.tcData.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpList,
            this.tpDetail});
            this.tcData.SelectedPageChanging += new DevExpress.XtraTab.TabPageChangingEventHandler(this.tcData_SelectedPageChanging);
            // 
            // tpList
            // 
            this.tpList.Controls.Add(this.btnClose);
            this.tpList.Controls.Add(this.btnEdit);
            this.tpList.Controls.Add(this.btnDelete);
            this.tpList.Controls.Add(this.btnAdd);
            this.tpList.Controls.Add(this.gcData);
            this.tpList.Name = "tpList";
            this.tpList.Size = new System.Drawing.Size(656, 379);
            this.tpList.Text = "Danh sách đợt tuyển sinh";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = global::StudentManager.Properties.Resources.Cancel;
            this.btnClose.Location = new System.Drawing.Point(575, 350);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Image = global::StudentManager.Properties.Resources.Edit;
            this.btnEdit.Location = new System.Drawing.Point(167, 350);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Sửa  ";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Image = global::StudentManager.Properties.Resources.Delete;
            this.btnDelete.Location = new System.Drawing.Point(86, 350);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xoá  ";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Image = global::StudentManager.Properties.Resources.Add;
            this.btnAdd.Location = new System.Drawing.Point(5, 350);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Thêm  ";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tpDetail
            // 
            this.tpDetail.Controls.Add(this.dgLabel1);
            this.tpDetail.Controls.Add(this.cbxCollectionType);
            this.tpDetail.Controls.Add(this.txtFinishNo);
            this.tpDetail.Controls.Add(this.txtStartNo);
            this.tpDetail.Controls.Add(this.dtmFinishDate);
            this.tpDetail.Controls.Add(this.dtmStartDate);
            this.tpDetail.Controls.Add(this.uCourseTypeLevel);
            this.tpDetail.Controls.Add(this.txtDescription);
            this.tpDetail.Controls.Add(this.btnCancel);
            this.tpDetail.Controls.Add(this.btnSaveEdit);
            this.tpDetail.Controls.Add(this.txtStudentCollectionPeriodName);
            this.tpDetail.Controls.Add(this.txtStudentCollectionPeriodID);
            this.tpDetail.Name = "tpDetail";
            this.tpDetail.Size = new System.Drawing.Size(656, 379);
            this.tpDetail.Text = "Chi tiết đợt tuyển sinh";
            // 
            // dgLabel1
            // 
            this.dgLabel1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dgLabel1.Location = new System.Drawing.Point(28, 186);
            this.dgLabel1.Name = "dgLabel1";
            this.dgLabel1.Size = new System.Drawing.Size(83, 14);
            this.dgLabel1.TabIndex = 14;
            this.dgLabel1.Text = "Loại xét tuyển:";
            // 
            // cbxCollectionType
            // 
            this.cbxCollectionType.EditValue = "1. Cao đẳng";
            this.cbxCollectionType.Location = new System.Drawing.Point(128, 184);
            this.cbxCollectionType.Name = "cbxCollectionType";
            this.cbxCollectionType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxCollectionType.Properties.Items.AddRange(new object[] {
            "1. Cao đẳng 3 năm",
            "2. Trung cấp 2.5 năm",
            "3. Trung cấp 3 năm",
            "4. Liên thông",
            "5. Trung cấp 1 năm",
            "6. Trung cấp 1.5 năm",
            "7. Trung cấp 2 năm"});
            this.cbxCollectionType.Size = new System.Drawing.Size(167, 20);
            this.cbxCollectionType.TabIndex = 7;
            // 
            // txtFinishNo
            // 
            this.txtFinishNo.Caption = "đến";
            this.txtFinishNo.DisplayMask = "#,###";
            this.txtFinishNo.EditMask = "";
            this.txtFinishNo.EditorLeft = 30;
            this.txtFinishNo.EditValue = 0;
            this.txtFinishNo.EditValueDouble = 0D;
            this.txtFinishNo.EditValueInt32 = 0;
            this.txtFinishNo.EditValueInt64 = ((long)(0));
            this.txtFinishNo.Location = new System.Drawing.Point(444, 24);
            this.txtFinishNo.MaxLength = 0;
            this.txtFinishNo.Name = "txtFinishNo";
            this.txtFinishNo.ReadOnly = false;
            this.txtFinishNo.Size = new System.Drawing.Size(147, 21);
            this.txtFinishNo.TabIndex = 2;
            // 
            // txtStartNo
            // 
            this.txtStartNo.Caption = "Số hồ sơ từ:";
            this.txtStartNo.DisplayMask = "#,###";
            this.txtStartNo.EditMask = "";
            this.txtStartNo.EditorLeft = 80;
            this.txtStartNo.EditValue = 0;
            this.txtStartNo.EditValueDouble = 0D;
            this.txtStartNo.EditValueInt32 = 0;
            this.txtStartNo.EditValueInt64 = ((long)(0));
            this.txtStartNo.Location = new System.Drawing.Point(261, 24);
            this.txtStartNo.MaxLength = 0;
            this.txtStartNo.Name = "txtStartNo";
            this.txtStartNo.ReadOnly = false;
            this.txtStartNo.Size = new System.Drawing.Size(177, 21);
            this.txtStartNo.TabIndex = 1;
            // 
            // dtmFinishDate
            // 
            this.dtmFinishDate.Caption = "Đến ngày:";
            this.dtmFinishDate.EditorLeft = 100;
            this.dtmFinishDate.EditValue = null;
            this.dtmFinishDate.EditValueDate = null;
            this.dtmFinishDate.EditValueDateTime = null;
            this.dtmFinishDate.Location = new System.Drawing.Point(320, 157);
            this.dtmFinishDate.Name = "dtmFinishDate";
            this.dtmFinishDate.ReadOnly = false;
            this.dtmFinishDate.Size = new System.Drawing.Size(271, 21);
            this.dtmFinishDate.TabIndex = 6;
            // 
            // dtmStartDate
            // 
            this.dtmStartDate.Caption = "Từ ngày:";
            this.dtmStartDate.EditorLeft = 100;
            this.dtmStartDate.EditValue = null;
            this.dtmStartDate.EditValueDate = null;
            this.dtmStartDate.EditValueDateTime = null;
            this.dtmStartDate.Location = new System.Drawing.Point(28, 157);
            this.dtmStartDate.Name = "dtmStartDate";
            this.dtmStartDate.ReadOnly = false;
            this.dtmStartDate.Size = new System.Drawing.Size(267, 21);
            this.dtmStartDate.TabIndex = 5;
            // 
            // uCourseTypeLevel
            // 
            this.uCourseTypeLevel.CourseIDEditValue = null;
            this.uCourseTypeLevel.EditorLeft = 100;
            this.uCourseTypeLevel.Location = new System.Drawing.Point(28, 76);
            this.uCourseTypeLevel.Name = "uCourseTypeLevel";
            this.uCourseTypeLevel.ReadOnly = false;
            this.uCourseTypeLevel.ScienceFilter = "";
            this.uCourseTypeLevel.Size = new System.Drawing.Size(563, 77);
            this.uCourseTypeLevel.TabIndex = 4;
            this.uCourseTypeLevel.TrainingLevelIDEditValue = null;
            this.uCourseTypeLevel.TrainingTypeEditValue = null;
            // 
            // txtDescription
            // 
            this.txtDescription.Caption = "Ghi chú:";
            this.txtDescription.EditorLeft = 100;
            this.txtDescription.EditValue = null;
            this.txtDescription.Location = new System.Drawing.Point(28, 210);
            this.txtDescription.MaxLength = 0;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(563, 107);
            this.txtDescription.TabIndex = 8;
            this.txtDescription.TextTrim = "";
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::StudentManager.Properties.Resources.Undo;
            this.btnCancel.Location = new System.Drawing.Point(209, 333);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Trở về";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveEdit
            // 
            this.btnSaveEdit.Image = global::StudentManager.Properties.Resources.Save;
            this.btnSaveEdit.Location = new System.Drawing.Point(128, 333);
            this.btnSaveEdit.Name = "btnSaveEdit";
            this.btnSaveEdit.Size = new System.Drawing.Size(75, 23);
            this.btnSaveEdit.TabIndex = 9;
            this.btnSaveEdit.Text = "Cập nhật";
            this.btnSaveEdit.Click += new System.EventHandler(this.btnSaveEdit_Click);
            // 
            // txtStudentCollectionPeriodName
            // 
            this.txtStudentCollectionPeriodName.AllowNull = true;
            this.txtStudentCollectionPeriodName.Caption = "Tên đợt TS:";
            this.txtStudentCollectionPeriodName.EditorBackColor = System.Drawing.SystemColors.Window;
            this.txtStudentCollectionPeriodName.EditorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.txtStudentCollectionPeriodName.EditorLeft = 100;
            this.txtStudentCollectionPeriodName.EditValue = null;
            this.txtStudentCollectionPeriodName.EditValueDouble = null;
            this.txtStudentCollectionPeriodName.EditValueInt32 = null;
            this.txtStudentCollectionPeriodName.Location = new System.Drawing.Point(28, 50);
            this.txtStudentCollectionPeriodName.MaxLength = 0;
            this.txtStudentCollectionPeriodName.Name = "txtStudentCollectionPeriodName";
            this.txtStudentCollectionPeriodName.PasswordChar = '\0';
            this.txtStudentCollectionPeriodName.ReadOnly = false;
            this.txtStudentCollectionPeriodName.Size = new System.Drawing.Size(563, 21);
            this.txtStudentCollectionPeriodName.TabIndex = 3;
            this.txtStudentCollectionPeriodName.TextTrim = "";
            // 
            // txtStudentCollectionPeriodID
            // 
            this.txtStudentCollectionPeriodID.AllowNull = true;
            this.txtStudentCollectionPeriodID.Caption = "Mã đợt TS:";
            this.txtStudentCollectionPeriodID.EditorBackColor = System.Drawing.SystemColors.Window;
            this.txtStudentCollectionPeriodID.EditorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.txtStudentCollectionPeriodID.EditorLeft = 100;
            this.txtStudentCollectionPeriodID.EditValue = null;
            this.txtStudentCollectionPeriodID.EditValueDouble = null;
            this.txtStudentCollectionPeriodID.EditValueInt32 = null;
            this.txtStudentCollectionPeriodID.Location = new System.Drawing.Point(28, 24);
            this.txtStudentCollectionPeriodID.MaxLength = 0;
            this.txtStudentCollectionPeriodID.Name = "txtStudentCollectionPeriodID";
            this.txtStudentCollectionPeriodID.PasswordChar = '\0';
            this.txtStudentCollectionPeriodID.ReadOnly = false;
            this.txtStudentCollectionPeriodID.Size = new System.Drawing.Size(217, 21);
            this.txtStudentCollectionPeriodID.TabIndex = 0;
            this.txtStudentCollectionPeriodID.TextTrim = "";
            // 
            // frmStudentCollectionPeriod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 405);
            this.Controls.Add(this.tcData);
            this.HelpButton = true;
            this.KeyPreview = true;
            this.Name = "frmStudentCollectionPeriod";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Quản lý đợt tuyển sinh";
            this.Load += new System.EventHandler(this.frmStudentCollectionPeriod_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmStudentCollectionPeriod_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).EndInit();
            this.mnuPopupGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcData)).EndInit();
            this.tcData.ResumeLayout(false);
            this.tpList.ResumeLayout(false);
            this.tpDetail.ResumeLayout(false);
            this.tpDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxCollectionType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion        
        private Control.DgGridControl gcData;
        private Control.DgGridView gvData;
        private Control.DgTabControl tcData;
        private Control.DgTabPage tpList;
        private Control.DgTabPage tpDetail;
        private Control.DgButton btnAdd;
        private Control.DgButton btnDelete;
        private Control.DgButton btnEdit;
        private Control.DgButton btnClose;
        private Control.DgButton btnCancel;
        private Control.DgButton btnSaveEdit;
        private Control.UTextEdit txtStudentCollectionPeriodName;
        private Control.UTextEdit txtStudentCollectionPeriodID;
        private System.Windows.Forms.ContextMenuStrip mnuPopupGrid;
        private System.Windows.Forms.ToolStripMenuItem mnuItemAdd;
        private System.Windows.Forms.ToolStripMenuItem mnuItemDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuItemSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuItemRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuItemExportToExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuItemClose;
        private Control.URichTextEdit txtDescription;
        private DeclarationManager.Education.UCourseTypeLevel uCourseTypeLevel;
        private Control.UCalcEdit txtFinishNo;
        private Control.UCalcEdit txtStartNo;
        private Control.UDateEdit dtmFinishDate;
        private Control.UDateEdit dtmStartDate;
        private Control.DgLabel dgLabel1;
        private DevExpress.XtraEditors.ComboBoxEdit cbxCollectionType;          
    }
}