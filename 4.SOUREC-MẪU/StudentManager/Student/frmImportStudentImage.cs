using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Collections;
using Libs;
using Global;
using SimsObject;
using Service;


namespace StudentManager.Student
{
    public partial class frmImportStudentImage : FormBase, IForm
    {
        #region Variables

        private IconListManager _iconListManager;
        DataTable dtbData; // data detail

        bool bolIsScanCommit = false;
        Hashtable hstItemListView = new Hashtable();
        bool bolIsRefresh = false;

        #endregion

        #region IForm Members

        private static frmImportStudentImage _instance = null;

        public static frmImportStudentImage Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmImportStudentImage();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmImportStudentImage()
        {
            InitializeComponent();
        }

        #region Support Functions

        private bool Scan()
        {
            string strIDList = ",";
            foreach (ListViewItem item in lstFile.Items)
            {
                strIDList += item.Text +",";
            }

            SIM_Student obj = new SIM_Student();
            dtbData= obj.GetDataTable("SIM_Student_SearchForImportImage", "@StudentIDList", strIDList);
            if (dtbData != null)
            {
                gcData.DataSource = dtbData;
                SystemService.SYS_GridColumnService.InitGridColumn(gvData, "SIM_Student_ImportImage", bolIsRefresh);
                return true;
            }
            else
            {
                ErrorManager.Error("Việc tải thông tin bị lỗi!");
                return false;
            }

        }

        private void SaveData()
        {
            int intCount = dtbData.Rows.Count;
            int intPos = 0;

            barStatus.Caption = "Đang cập nhật dữ liệu...";
            barStatusCaption.Caption = "";
            foreach (DataRow drw in dtbData.Rows)
            {

                //update Progresss statas
                intPos++;
                barProgress.EditValue = Convert.ToInt32((float)intPos / (float)intCount * 100);
                barStatusCaption.Caption = drw["StudentCode"].ToString() + "(" + barProgress.EditValue.ToString() + " %)";

                ListViewItem lvItem = lstFile.Items[drw["StudentCode"].ToString()];
                if (lvItem != null)
                {
                    string strFilePath = lvItem.ToolTipText;
                    picImage.Image = (System.Drawing.Image)System.Drawing.Image.FromFile(strFilePath).Clone();

                    SystemObject.SYS_ImageData objImageData = new SystemObject.SYS_ImageData();
                    objImageData.ObjectID = Convert.ToInt64(drw["StudentID"]);
                    objImageData.TypeObject = SystemObject.TypeObject.Student;

                    MemoryStream msm = new MemoryStream();
                    picImage.Image.Save(msm, System.Drawing.Imaging.ImageFormat.Jpeg);
                    objImageData.ImageData = msm.ToArray();
                    if (!objImageData.AddOrEdit())
                    {
                        MessageManager.Error("Thêm mới hình ảnh bị lỗi.");
                        return;
                    }
                }
               
            }

            barProgress.EditValue = 100;
            btnSave.Enabled = false;
            barStatus.Caption = "Đã cập nhật thành công!";
            barProgress.EditValue = 0;
            string strActionLog = "";
            new SystemObject.SYS_ActionLog().WriteActionLog("Nhập ảnh sinh viên", strActionLog, SystemObject.ActionLogType.EDIT, 1, UserSession.Username);
        }

        private void AddFilesToListView(string[] strFilePaths, string[] fileNames)
        {
            for(int i = 0; i< strFilePaths.Length;i++)
            {
                string strFileName = fileNames[i];
                string strFilePath = strFilePaths[i];

                bool bolDuplicate = false;
                foreach (ListViewItem item in lstFile.Items)
                {
                    if (item.Text == strFileName)
                    {
                        bolDuplicate = true;
                        item.Selected = true;
                        break;
                    }
                }

                if (!bolDuplicate)
                {
                    string[] s = strFilePath.Split('\\');
                    string strFile = strFileName.Substring(0, strFileName.Length - 4);
                    ListViewItem itemNew = lstFile.Items.Add(strFile, strFile, _iconListManager.AddFileIcon(strFilePath));
                    itemNew.ToolTipText = strFilePath;
                    itemNew.Text = strFile;
                    itemNew.Selected = true;
                }                                             
            }            
        }

        #endregion
        
        #region Form Actions
        
        private void frmImportStudentImage_Load(object sender, EventArgs e)
        {            
            _iconListManager = new IconListManager(imgIconSmallLocal, imgIconLargeLocal);
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true; // lệnh này để Thread không bị warning            
        }

        private void btnScan_Click(object sender, EventArgs e)
        {            
            Scan();            
            //new Thread(Scan).Start();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Scan())
                SaveData();         
            
            //new Thread(SaveData).Start();
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (openFileDialog.FileNames.Length > 0)
                {
                    AddFilesToListView(openFileDialog.FileNames,openFileDialog.SafeFileNames);
                    btnScan.Enabled = true;
                    btnSave.Enabled = true;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstFile.SelectedItems)
            {
                lstFile.Items.Remove(item);
            }
            if (lstFile.Items.Count == 0)
                btnScan.Enabled = false;
        }
      
        private void lstFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstFile.SelectedItems.Count > 0)
            {
                if (File.Exists(lstFile.SelectedItems[0].ToolTipText))
                {
                    if (picImage.Image != null)
                        picImage.Image.Dispose(); // giải phóng bộ nhớ cũ
                    Image img = Bitmap.FromFile(lstFile.SelectedItems[0].ToolTipText);
                    picImage.Image = img;                    
                }
            }
        }

        private void lstFile_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            btnScan.Enabled = btnDelete.Enabled = mnuItemDeleteFile.Enabled = lstFile.SelectedItems.Count > 0;
        }        

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (bolIsScanCommit)
            {
                bolIsScanCommit = false;             
                timer1.Enabled = false;                
            }
        }

        #endregion       

        private void frmImportStudentImage_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F1:
                    this.ShowToolTip();
                    break;

                case Keys.F3:
                    break;

                case Keys.F5:
                    bolIsRefresh = true;
                    btnScan_Click(null, null);
                    break;

                case Keys.F7:
                    //btnPrint_Click(sender, null);
                    break;
                case Keys.Escape:                    
                    break;

            }
        }
      
        private void mnuItemClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvData_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //DataRow drw = gvData.GetDataRow(e.RowHandle);
            //if (drw != null)
            //    if (Convert.ToBoolean(drw["IsLocked"]))
            //        e.Appearance.ForeColor = Color.Brown;
        }

       
    }
}

