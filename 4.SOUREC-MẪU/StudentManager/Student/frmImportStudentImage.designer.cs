namespace StudentManager.Student
{
    partial class frmImportStudentImage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportStudentImage));
            this.gvData = new Control.DgGridView();
            this.gcData = new Control.DgGridControl();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.lstFile = new System.Windows.Forms.ListView();
            this.mnuPopupListFile = new System.Windows.Forms.ContextMenuStrip();
            this.mnuItemAddFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemDeleteFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemRefreshFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemScanFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemDeleteMarkData = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemSelectNewFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemSelectScannedFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemSelectMarkUpdated = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemClose2 = new System.Windows.Forms.ToolStripMenuItem();
            this.imgIconLargeLocal = new System.Windows.Forms.ImageList();
            this.imgIconSmallLocal = new System.Windows.Forms.ImageList();
            this.btnAddFile = new Control.DgButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.btnScan = new Control.DgButton();
            this.btnClose = new Control.DgButton();
            this.btnDelete = new Control.DgButton();
            this.btnSave = new Control.DgButton();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStatus = new DevExpress.XtraBars.BarStaticItem();
            this.barProgress = new DevExpress.XtraBars.BarEditItem();
            this.progressBar = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.barStatusCaption = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.timer1 = new System.Windows.Forms.Timer();
            this.barPercent = new DevExpress.XtraBars.BarStaticItem();
            this.timer2 = new System.Windows.Forms.Timer();
            this.picImage = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).BeginInit();
            this.mnuPopupListFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gvData
            // 
            this.gvData.GridControl = this.gcData;
            this.gvData.IndicatorWidth = 35;
            this.gvData.IsSelecting = false;
            this.gvData.Name = "gvData";
            this.gvData.OptionsView.ColumnAutoWidth = false;
            this.gvData.OptionsView.ShowGroupPanel = false;
            this.gvData.ResetGridColumn = true;
            this.gvData.RowFilter = "";
            this.gvData.SummaryCollection = "";
            this.gvData.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvData_RowCellStyle);
            // 
            // gcData
            // 
            this.gcData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcData.Location = new System.Drawing.Point(0, 0);
            this.gcData.MainView = this.gvData;
            this.gcData.Name = "gcData";
            this.gcData.Size = new System.Drawing.Size(479, 574);
            this.gcData.TabIndex = 8;
            this.gcData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvData});
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "*.jpg;*.bmp;*.png|*.jpg; *.bmp; *.png";
            this.openFileDialog.Multiselect = true;
            // 
            // lstFile
            // 
            this.lstFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFile.ContextMenuStrip = this.mnuPopupListFile;
            this.lstFile.LargeImageList = this.imgIconLargeLocal;
            this.lstFile.Location = new System.Drawing.Point(0, 0);
            this.lstFile.Name = "lstFile";
            this.lstFile.Size = new System.Drawing.Size(512, 539);
            this.lstFile.SmallImageList = this.imgIconSmallLocal;
            this.lstFile.TabIndex = 9;
            this.lstFile.UseCompatibleStateImageBehavior = false;
            this.lstFile.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstFile_ItemSelectionChanged);
            this.lstFile.SelectedIndexChanged += new System.EventHandler(this.lstFile_SelectedIndexChanged);
            // 
            // mnuPopupListFile
            // 
            this.mnuPopupListFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemAddFile,
            this.mnuItemDeleteFile,
            this.toolStripSeparator1,
            this.mnuItemRefreshFile,
            this.mnuItemScanFile,
            this.mnuItemDeleteMarkData,
            this.toolStripSeparator3,
            this.mnuItemSelectNewFile,
            this.mnuItemSelectScannedFile,
            this.mnuItemSelectMarkUpdated,
            this.toolStripSeparator4,
            this.mnuItemClose2});
            this.mnuPopupListFile.Name = "mnuPopupGrid";
            this.mnuPopupListFile.Size = new System.Drawing.Size(218, 220);
            // 
            // mnuItemAddFile
            // 
            this.mnuItemAddFile.Image = global::StudentManager.Properties.Resources.Add;
            this.mnuItemAddFile.Name = "mnuItemAddFile";
            this.mnuItemAddFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuItemAddFile.Size = new System.Drawing.Size(217, 22);
            this.mnuItemAddFile.Text = "Thêm ảnh";
            this.mnuItemAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // mnuItemDeleteFile
            // 
            this.mnuItemDeleteFile.Image = global::StudentManager.Properties.Resources.Delete;
            this.mnuItemDeleteFile.Name = "mnuItemDeleteFile";
            this.mnuItemDeleteFile.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.mnuItemDeleteFile.Size = new System.Drawing.Size(217, 22);
            this.mnuItemDeleteFile.Text = "Gỡ bỏ ảnh";
            this.mnuItemDeleteFile.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(214, 6);
            // 
            // mnuItemRefreshFile
            // 
            this.mnuItemRefreshFile.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemRefreshFile.Image")));
            this.mnuItemRefreshFile.Name = "mnuItemRefreshFile";
            this.mnuItemRefreshFile.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnuItemRefreshFile.Size = new System.Drawing.Size(217, 22);
            this.mnuItemRefreshFile.Text = "Nạp lại";
            // 
            // mnuItemScanFile
            // 
            this.mnuItemScanFile.Image = global::StudentManager.Properties.Resources.print1;
            this.mnuItemScanFile.Name = "mnuItemScanFile";
            this.mnuItemScanFile.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.mnuItemScanFile.Size = new System.Drawing.Size(217, 22);
            this.mnuItemScanFile.Text = "Scan";
            this.mnuItemScanFile.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // mnuItemDeleteMarkData
            // 
            this.mnuItemDeleteMarkData.Name = "mnuItemDeleteMarkData";
            this.mnuItemDeleteMarkData.Size = new System.Drawing.Size(217, 22);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(214, 6);
            // 
            // mnuItemSelectNewFile
            // 
            this.mnuItemSelectNewFile.Name = "mnuItemSelectNewFile";
            this.mnuItemSelectNewFile.Size = new System.Drawing.Size(217, 22);
            this.mnuItemSelectNewFile.Text = "Chọn file chưa scan";
            this.mnuItemSelectNewFile.ToolTipText = "1";
            // 
            // mnuItemSelectScannedFile
            // 
            this.mnuItemSelectScannedFile.Name = "mnuItemSelectScannedFile";
            this.mnuItemSelectScannedFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.mnuItemSelectScannedFile.Size = new System.Drawing.Size(217, 22);
            this.mnuItemSelectScannedFile.Text = "Chọn file đã scan";
            this.mnuItemSelectScannedFile.ToolTipText = "2";
            // 
            // mnuItemSelectMarkUpdated
            // 
            this.mnuItemSelectMarkUpdated.Name = "mnuItemSelectMarkUpdated";
            this.mnuItemSelectMarkUpdated.Size = new System.Drawing.Size(217, 22);
            this.mnuItemSelectMarkUpdated.Text = "Chọn file đã cập nhật điểm";
            this.mnuItemSelectMarkUpdated.ToolTipText = "3";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(214, 6);
            // 
            // mnuItemClose2
            // 
            this.mnuItemClose2.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemClose2.Image")));
            this.mnuItemClose2.Name = "mnuItemClose2";
            this.mnuItemClose2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuItemClose2.Size = new System.Drawing.Size(217, 22);
            this.mnuItemClose2.Text = "Đóng";
            // 
            // imgIconLargeLocal
            // 
            this.imgIconLargeLocal.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgIconLargeLocal.ImageStream")));
            this.imgIconLargeLocal.TransparentColor = System.Drawing.Color.Transparent;
            this.imgIconLargeLocal.Images.SetKeyName(0, "");
            this.imgIconLargeLocal.Images.SetKeyName(1, "");
            this.imgIconLargeLocal.Images.SetKeyName(2, "");
            this.imgIconLargeLocal.Images.SetKeyName(3, "");
            this.imgIconLargeLocal.Images.SetKeyName(4, "");
            this.imgIconLargeLocal.Images.SetKeyName(5, "");
            this.imgIconLargeLocal.Images.SetKeyName(6, "");
            this.imgIconLargeLocal.Images.SetKeyName(7, "");
            this.imgIconLargeLocal.Images.SetKeyName(8, "");
            this.imgIconLargeLocal.Images.SetKeyName(9, "");
            this.imgIconLargeLocal.Images.SetKeyName(10, "");
            this.imgIconLargeLocal.Images.SetKeyName(11, "");
            this.imgIconLargeLocal.Images.SetKeyName(12, "");
            // 
            // imgIconSmallLocal
            // 
            this.imgIconSmallLocal.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgIconSmallLocal.ImageStream")));
            this.imgIconSmallLocal.TransparentColor = System.Drawing.Color.Transparent;
            this.imgIconSmallLocal.Images.SetKeyName(0, "");
            this.imgIconSmallLocal.Images.SetKeyName(1, "");
            this.imgIconSmallLocal.Images.SetKeyName(2, "");
            this.imgIconSmallLocal.Images.SetKeyName(3, "");
            this.imgIconSmallLocal.Images.SetKeyName(4, "");
            this.imgIconSmallLocal.Images.SetKeyName(5, "");
            this.imgIconSmallLocal.Images.SetKeyName(6, "");
            this.imgIconSmallLocal.Images.SetKeyName(7, "");
            this.imgIconSmallLocal.Images.SetKeyName(8, "");
            this.imgIconSmallLocal.Images.SetKeyName(9, "");
            this.imgIconSmallLocal.Images.SetKeyName(10, "");
            this.imgIconSmallLocal.Images.SetKeyName(11, "");
            this.imgIconSmallLocal.Images.SetKeyName(12, "");
            // 
            // btnAddFile
            // 
            this.btnAddFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddFile.Image = global::StudentManager.Properties.Resources.Add;
            this.btnAddFile.Location = new System.Drawing.Point(12, 545);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(84, 23);
            this.btnAddFile.TabIndex = 10;
            this.btnAddFile.Text = "Thêm";
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.picImage);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnScan);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnClose);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnDelete);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnSave);
            this.splitContainerControl1.Panel1.Controls.Add(this.lstFile);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnAddFile);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gcData);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1000, 574);
            this.splitContainerControl1.SplitterPosition = 516;
            this.splitContainerControl1.TabIndex = 12;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // btnScan
            // 
            this.btnScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScan.Enabled = false;
            this.btnScan.Image = global::StudentManager.Properties.Resources.icon_refresh;
            this.btnScan.Location = new System.Drawing.Point(248, 545);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(84, 23);
            this.btnScan.TabIndex = 14;
            this.btnScan.Text = "Kiểm tra";
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = global::StudentManager.Properties.Resources.Cancel;
            this.btnClose.Location = new System.Drawing.Point(428, 545);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 23);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Image = global::StudentManager.Properties.Resources.Delete;
            this.btnDelete.Location = new System.Drawing.Point(102, 545);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(84, 23);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Image = global::StudentManager.Properties.Resources.Save;
            this.btnSave.Location = new System.Drawing.Point(338, 545);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Cập nhật";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barStatus,
            this.barProgress,
            this.barStatusCaption});
            this.barManager1.MaxItemId = 5;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.progressBar});
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStatus),
            new DevExpress.XtraBars.LinkPersistInfo(this.barProgress),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStatusCaption)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barStatus
            // 
            this.barStatus.AutoSize = DevExpress.XtraBars.BarStaticItemSize.None;
            this.barStatus.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.barStatus.Caption = "Ready";
            this.barStatus.Id = 0;
            this.barStatus.Name = "barStatus";
            this.barStatus.TextAlignment = System.Drawing.StringAlignment.Near;
            this.barStatus.Width = 150;
            // 
            // barProgress
            // 
            this.barProgress.Caption = "...";
            this.barProgress.Edit = this.progressBar;
            this.barProgress.EditHeight = 18;
            this.barProgress.EditValue = "";
            this.barProgress.Id = 1;
            this.barProgress.Name = "barProgress";
            this.barProgress.Width = 400;
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            // 
            // barStatusCaption
            // 
            this.barStatusCaption.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.barStatusCaption.Id = 4;
            this.barStatusCaption.Name = "barStatusCaption";
            this.barStatusCaption.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1000, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 574);
            this.barDockControlBottom.Size = new System.Drawing.Size(1000, 25);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 574);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1000, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 574);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // barPercent
            // 
            this.barPercent.Id = 2;
            this.barPercent.Name = "barPercent";
            this.barPercent.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // picImage
            // 
            this.picImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picImage.Location = new System.Drawing.Point(409, 413);
            this.picImage.Name = "picImage";
            this.picImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.picImage.Size = new System.Drawing.Size(102, 125);
            this.picImage.TabIndex = 56;
            // 
            // frmImportStudentImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 599);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmImportStudentImage";
            this.Text = "Cập nhật ảnh sinh viên";
            this.Load += new System.EventHandler(this.frmImportStudentImage_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmImportStudentImage_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).EndInit();
            this.mnuPopupListFile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Control.DgGridView gvData;
        private Control.DgGridControl gcData;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ListView lstFile;
        private Control.DgButton btnAddFile;
        private System.Windows.Forms.ImageList imgIconLargeLocal;
        private System.Windows.Forms.ImageList imgIconSmallLocal;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private Control.DgButton btnSave;
        private Control.DgButton btnClose;
        private Control.DgButton btnDelete;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarStaticItem barStatus;
        private DevExpress.XtraBars.BarEditItem barProgress;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar progressBar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarStaticItem barPercent;
        private DevExpress.XtraBars.BarStaticItem barStatusCaption;
        private System.Windows.Forms.ContextMenuStrip mnuPopupListFile;
        private System.Windows.Forms.ToolStripMenuItem mnuItemRefreshFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuItemSelectNewFile;
        private System.Windows.Forms.ToolStripMenuItem mnuItemSelectScannedFile;
        private System.Windows.Forms.ToolStripMenuItem mnuItemSelectMarkUpdated;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mnuItemClose2;
        private System.Windows.Forms.ToolStripMenuItem mnuItemAddFile;
        private System.Windows.Forms.ToolStripMenuItem mnuItemDeleteFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuItemScanFile;
        private System.Windows.Forms.ToolStripMenuItem mnuItemDeleteMarkData;
        private System.Windows.Forms.Timer timer2;
        private Control.DgButton btnScan;
        private DevExpress.XtraEditors.PictureEdit picImage;
    }
}

