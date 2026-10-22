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
using DCore;
using SimsObject;
using SimsService;
using Service;
using GeneralObject;
using GeneralService;

namespace StudentManager.Student
{
    public partial class frmMakeStudentList : FormBase, IForm
    {
        #region Consts        
                
        public const string PERMISSION_VIEW = "SIM_MakeStudentList_View";

        #endregion

        private string strClassID = "";
        private string strListIDDeleted = "";

        #region Variables
         
        bool bolIsEditing = false; // dang edit hay khong
       // SIM_YearEthicMark itemStudentEditing = new SIM_YearEthicMark(); // record đang edit

        #endregion

        #region IForm Members

        private static frmMakeStudentList _instance = null;

        public static frmMakeStudentList Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmMakeStudentList();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmMakeStudentList()
        {
            InitializeComponent();
        }

        #region Support Functions

        public void LoadReferenceData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadReferenceData));
            else
            {
                uClass.ClassFilter = "ClassType = 0";// chỉ lọc ra lớp bình thường
                uClass.InitData();

            }
        }

        public void LoadData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadData));
            else
            {
                SIM_Student obj = new SIM_Student();
                DataTable dtbData = obj.GetDataTable("SIM_StudentList_Search");
                if (dtbData != null)
                {
                    gcData.DataSource = dtbData;
                    SYS_GridColumnService.InitGridColumn(gvData, "SIM_Student");

                    // set order
                    gvData.SetOrder("Order");
                    mnuItemSave.Enabled = btnSave.Enabled = false;// load lại thì không cần save 
                    gvData.Columns["StudentCode"].OptionsColumn.AllowEdit = true;
                }
                else
                {
                    //ErrorManager.Error(obj.ErrorException);
                    ErrorManager.Error("Việc lấy thông tin bị lỗi!");
                }
            }            
        }        

        private void CheckPermission()
        {
            // Kiểm tra quyền
           
        }
   
        #endregion

        #region Form Actions

        private void frmMakeStudentList_Load(object sender, EventArgs e)
        {
       
            CheckPermission();
            SetToolTip();
            //new Thread(LoadReferenceData).Start();        
            LoadData();
        }
            
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (btnSave.Enabled)
                {
                    DialogResult dlrConfirm = MessageManager.Confirm("Bạn có muốn lưu lại thông tin thay đổi trước khi nạp lại dữ liệu?");
                    if (dlrConfirm == DialogResult.Cancel)
                        return;
                    else if (dlrConfirm == DialogResult.Yes)
                        if (!SaveData())
                            return;// lưu không thành công thì return
                }
                new Thread(LoadData).Start();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageManager.Confirm("Bạn có thực sự muốn lưu những thay đổi dữ liệu này?") == DialogResult.Yes)
            {
                if (SaveData())
                {
                    //MessageManager.Info("Đã cập nhật dữ liệu thành công!");
                    btnSave.Enabled = mnuItemSave.Enabled = false;                    
                }
            }
        }

        private bool IsValidData()
        {
           
            if (uClass.ClassIDEditValue == null)
            {
                MessageManager.Warning("Bạn phải chọn lớp học!");
                uClass.Focus();
                return false;
            }

            return true;
        }
        /// <summary>
        /// Save dữ liệu ở tab edit
        /// </summary>
        private bool SaveData()
        {
            SIM_Student item = new SIM_Student();
            item.BeginTransaction();
            for (int i = 0; i < gvData.RowCount; i++)
            {
                DataRow drw = gvData.GetDataRow(i);
                if (drw["StudentCode"].ToString() != "") // neu khac nhau thi moi luu
                {

                    item.StudentID = Convert.ToInt64(drw[SIM_Student.C_StudentID]);
                    item.StudentCode = drw["StudentCode"].ToString();
                    item.OrderIndex = Convert.ToInt32(drw["OrderIndex"]);
                    if (!item.UpdateStudentCode())
                    {
                        ErrorManager.Error("Tạo mã số sinh viên không thành công!");
                        return false;
                    }
                }
            }
            item.CommitTransaction();
            return true;
        }

        private void gvData_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataRow drw = gvData.GetFocusedDataRow();
            if (drw != null)
            {
                if (drw["StudentCode"].ToString().Trim() != "")
                {
                    SIM_Student obj = new SIM_Student();
                    DataTable dtb = obj.Search("@StudentCode", drw["StudentCode"].ToString().Trim());
                    if (dtb != null && dtb.Rows.Count > 0)
                    {
                        SIM_StudentList obj2 = new SIM_StudentList();
                        obj2.CreatedUser = UserSession.Username;
                        obj2.StudentID = Convert.ToInt64(dtb.Rows[0]["StudentID"]);
                        obj2.OrderIndex = gvData.RowCount;
                        obj2.Delete(); // xoa neu da co
                        if (obj2.Add())// them vao
                            LoadData();
                    }
                }
            }
        }

        private void mnuItemExportToExcel_Click(object sender, EventArgs e)
        {
            gvData.QuickExportToExcel();
        }

        private void mnuItemDelete_Click(object sender, EventArgs e)
        {
            SIM_StudentList obj = new SIM_StudentList();            
            foreach (int i in gvData.GetSelectedRows())
            {
                obj.StudentID = Convert.ToInt64(gvData.GetDataRow(i)["StudentID"]);
                obj.Delete();
            }
            LoadData();
        }        

    }
}