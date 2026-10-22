using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using Libs;
using Global;
using SystemService;
using SimsObject;
using SimsService;


namespace StudentManager
{
    public partial class frmCopyStudent : FormBase,IForm
    {
        #region Consts

        #endregion

        #region Variables       

        #endregion

        #region Properties

        DataTable dtbData = null;

        public DataTable DataTable
        {
            get { return dtbData; }
            set { dtbData = value; }
        }

        string strStudentIDList = "";

        public string StudentIDList
        {
            get { return strStudentIDList; }
            set { strStudentIDList = value; }
        }

        private bool bolIsOk = false;

        public bool IsOk
        {
            get { return bolIsOk; }
            set { bolIsOk = value; }
        }

        #endregion

        #region IForm Members

        private static frmCopyStudent _instance = null;

        public static frmCopyStudent Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmCopyStudent();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmCopyStudent()
        {
            InitializeComponent();
        }        

        #region Support Functions

        private void CheckPermission()
        {
            
        }

        public void LoadReferenceData()
        {
            uClass21.InitData();
        }

        /// <summary>
        /// Làm mới dữ liệu trong các combobox hay này nọ...
        /// </summary>
        public void RefreshReferenceData()
        {
            uClass21.RefrehData();
        }
        
        public void LoadData(string studentIDList)
        {
            this.strStudentIDList = studentIDList;
            LoadData();
        }
        public void LoadData()
        {
            bolIsOk = false;

            SIM_Student objStudent = new SIM_Student();
            dtbData = objStudent.Search("@StudentIDList", "," + strStudentIDList + ",");
            if (dtbData != null)
            {                
                gcData.DataSource = dtbData;
                Service.SYS_GridColumnService.InitGridColumn(gvData, "SIM_StudentSelected"); // khởi tạo hiện thị cột trên lưới                
                gvData.BestFitColumns();
                btnSaveEdit.Enabled = mnuItemSave.Enabled = true;
                gvData.CheckAll(); // mặc định là chọn hết
                uClass21.Focus();
            }
            else
            {
                ErrorManager.Error("Việc lấy thông tin bị lỗi!");
                btnSaveEdit.Enabled = mnuItemSave.Enabled = false;
            }
        }         

        /// <summary>
        /// Kiểm tra tính hợp lệ của dữ liệu ở tab edit
        /// </summary>
        /// <returns></returns>
        private bool IsValidEditForm()
        {            
            if (uClass21.ClassIDEditValue == null)
            {
                MessageManager.Warning("Bạn phải chọn lớp học để copy sinh viên sang!");
                uClass21.Focus();
                return false;
            }

           
            if (gvData.GetIDListSelected("StudentID")=="")
            {
                MessageManager.Warning("Bạn phải chọn sinh viên để copy!");
                gvData.Focus();
                return false;
            }
            return true;

        }

        /// <summary>
        /// Save dữ liệu ở tab edit
        /// </summary>
        private bool CopyStudent()
        {
            foreach (DataRow drw in dtbData.Rows)
            {
                SIM_Student objStudent = new SIM_Student();
                objStudent.StudentID = Convert.ToInt64(drw["StudentID"]);
                if (objStudent.Get())
                {
                    objStudent.ClassID = uClass21.ClassIDEditValue;
                    objStudent.CreatedUser = UserSession.Username;
                    objStudent.StudentCode = drw["StudentCode"].ToString();

                    if (!objStudent.Add())
                    {
                        ErrorManager.Error("Việc sao chép dữ liệu bị lỗi!");
                        drw["ResultCopy"] = "-1";
                        return false;
                    }
                    drw["ResultCopy"] = "1";
                }
                else
                {
                    ErrorManager.Error("Việc lấy dữ liệu sao chép bị lỗi!");
                    drw["ResultCopy"] = "-1";
                    return false;

                }
            }
            return true;
        }
        
        #endregion

        #region Form Actions

        private void frmCopyStudent_Load(object sender, EventArgs e)
        {
            LoadReferenceData();
            
            //new Thread(LoadReferenceData).Start();
            //new Thread(LoadData).Start();
            CheckPermission();
            SetToolTip();
        }

        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            if (IsValidEditForm())
                if (CopyStudent())
                {
                    bolIsOk = true;
                    this.Close();
                }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void frmCopyStudent_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F1:
                    this.ShowToolTip();
                    break;
                    
                case Keys.F2:
                    
                    break;
                case Keys.F3:
                //    if (!bolIsEditing)
                //        btnSearch_Click(sender, null);
                //    break;
                case Keys.F4:
                    
                    break;
                case Keys.F5:
                   
                    break;
                case Keys.F6:
                    if (btnSaveEdit.Enabled)
                        btnSaveEdit_Click(sender, null);
                    break;
                case Keys.F7:
                    //btnPrint_Click(sender, null);
                    break;
                case Keys.F8:
                    
                    break;
                case Keys.Escape:                    
                        btnCancel_Click(sender, null);
                    break;
            }
        }
               
        #endregion

        private void mnuItemCheck_Click(object sender, EventArgs e)
        {
            gvData.CheckSelected();
        }

        private void mnuItemUnCheck_Click(object sender, EventArgs e)
        {
            gvData.UnCheckSelected();
        }

        private void mnuItemClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvData_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            DataRow drw = gvData.GetDataRow(e.RowHandle);
            if (drw != null)
            {
                switch (drw["ResultCopy"].ToString())
                {
                    case "1": e.Appearance.BackColor = Color.LightGreen;
                        break;
                    case "-1": e.Appearance.BackColor = Color.Red;
                        break;
                }
            }
        }

   

    }
}