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
    public partial class frmMakeStudentCode : FormBase, IForm
    {
        #region Consts        
                
        public const string PERMISSION_VIEW = "SIM_MakeStudentCode_View";

        #endregion

        private string strClassID = "";
        private string strListIDDeleted = "";

        #region Variables
         
        bool bolIsEditing = false; // dang edit hay khong
       // SIM_YearEthicMark itemStudentEditing = new SIM_YearEthicMark(); // record đang edit

        #endregion

        #region IForm Members

        private static frmMakeStudentCode _instance = null;

        public static frmMakeStudentCode Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmMakeStudentCode();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmMakeStudentCode()
        {
            InitializeComponent();
        }
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
                    DataTable dtbData = obj.SearchForMakeCode(uClass.ClassIDEditValue.ToString());
                    if (dtbData != null)
                    {
                        gcData.DataSource = dtbData;
                        SYS_GridColumnService.InitGridColumn(gvData, "SIM_MakeStudentCode");

                        // set order
                        gvData.SetOrder("Order");
                        btnCreate.Enabled = dtbData.Rows.Count > 0;
                        mnuItemSave.Enabled = btnSave.Enabled = false;// load lại thì không cần save 
                    }
                    else
                    {
                        //ErrorManager.Error(obj.ErrorException);
                        ErrorManager.Error("Việc lấy thông tin bị lỗi!");
                    }
            }
        }
        #region Support Functions

        private void CheckPermission()
        {
            // Kiểm tra quyền
           
        }
   
        #endregion

        #region Form Actions

        private void frmMakeStudentCode_Load(object sender, EventArgs e)
        {
       
            CheckPermission();
            SetToolTip();
            new Thread(LoadReferenceData).Start();        
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

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtPrefixCode.TextTrim != "" && txtStartCode.TextTrim != "")
            {
                int intLenOrder = txtStartCode.TextTrim.Length;

                int intStartOrder;
                if (int.TryParse(txtStartCode.TextTrim, out intStartOrder))
                {

                    for (int i = 0; i < gvData.RowCount; i++)
                    {
                        string a = "0000000000" + intStartOrder.ToString();
                        gvData.GetDataRow(i)["StudentCode"] = txtPrefixCode.TextTrim + a.Substring(a.Length - intLenOrder);
                        gvData.GetDataRow(i)["OrderIndex"] = i;
                        intStartOrder++;
                    }
                }
                btnSave.Enabled = mnuItemSave.Enabled = true;
            }
        }



        /// <summary>
        ///  Nếu itemOld = null thì là thêm mới với itemNew


    }
}