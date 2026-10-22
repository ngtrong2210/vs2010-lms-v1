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

namespace StudentManager.Checking
{
    public partial class frmDateChecking : FormBase, IForm
    {
        #region Consts

        public const string PERMISSION_EDIT = "SIM_DateChecking_Edit";
        public const string PERMISSION_VIEW = "SIM_DateChecking_View";

        #endregion

        private string strClassID = "";
        private int intClassSubject = 0;
        private string strListIDDeleted = "";

        #region Variables
         
        bool bolIsEditing = false; // dang edit hay khong
       // SIM_DateChecking itemStudentEditing = new SIM_DateChecking(); // record đang edit

        #endregion

        #region IForm Members

        private static frmDateChecking _instance = null;

        public static frmDateChecking Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmDateChecking();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmDateChecking()
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
                try
                {
                    DataTable dtbData = new SIM_DateChecking().Search(
                                    "@ClassID", uClass.ClassIDEditValue.ToString(),
                                    "@Date",dateChecking.EditValueDateTime.Value.Date);

                    gcData.DataSource = dtbData;
                    SYS_GridColumnService.InitGridColumn(gvData, "SIM_DateChecking");

                    // set order
                    gvData.SetOrder("Order");

                    //Nhớ lại giá trị khóa để save
                    //strClassID = uClass.ClassIDEditValue.ToString();
                    //intYear = uYearSemester.YearIDEditValueInt32.Value;
                    //intSemester = uYearSemester.SemesterEditValueInt32.Value;
                    strListIDDeleted = "";

                    mnuItemSave.Enabled = btnSave.Enabled = false; // load lại thì không cần save 
                    mnuItemExportToExcel.Enabled = dtbData.Rows.Count > 0;
       
                }
                catch (Exception objEx)
                {
                    ErrorManager.Error(objEx);
                    SYS_ErrorLogService.Write(Enums.ActionType.View, "frmDateChecking->LoadData", objEx, 0);
                }
            }
        }

        #region Support Functions

        private void CheckPermission()
        {
            // Kiểm tra quyền
            gvData.OptionsBehavior.Editable = UserSession.HasPermission(PERMISSION_EDIT);
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
                    btnSearch_Click(sender, e);
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


            if (dateChecking.EditValue =="")
            {
                MessageManager.Warning("Bạn phải chọn ngày nghỉ!");
                dateChecking.Focus();
                return false;
            }
            return true;
        }
        /// <summary>
        /// Save dữ liệu ở tab edit
        /// </summary>
        private bool SaveData()
        {
            SIM_DateChecking obj = new SIM_DateChecking();
            obj.BeginTransaction();

            for (int i = 0; i < gvData.RowCount; i++)
            {
                DataRow drw = gvData.GetDataRow(i);

                SIM_DateChecking item = new SIM_DateChecking();
                item.IDB = obj.IDB;
                if (drw["IsEdit"].ToString()=="1")
                {                    
                    // nếu chưa có thì thêm mới.
                    if (drw[SIM_DateChecking.C_DateCheckingID].ToString() == "")
                    {
                        // Và chỉ thêm mới khi có giá trị
                        if (drw[SIM_DateChecking.C_NoPermissionQuantity].ToString() != "" || drw[SIM_DateChecking.C_PermissionQuantity].ToString() != "")
                        {
                            item.StudentID = Convert.ToInt64(drw[SIM_DateChecking.C_StudentID]);
                            item.Date = dateChecking.EditValueDateTime.Value.Date;
                            if (drw[SIM_DateChecking.C_NoPermissionQuantity].ToString() != "")                            
                                item.NoPermissionQuantity = Convert.ToInt32(drw[SIM_DateChecking.C_NoPermissionQuantity]);                            
                            else                            
                                item.NoPermissionQuantity = 0;
                            
                            if (drw[SIM_DateChecking.C_PermissionQuantity].ToString() != "")                            
                                item.PermissionQuantity = Convert.ToInt32(drw[SIM_DateChecking.C_PermissionQuantity]);                          
                            else                            
                                item.PermissionQuantity = 0;
                            
                            item.Description = drw[SIM_DateChecking.C_Description].ToString();
                            item.CreatedUser = UserSession.Username;
                            if (!item.Add())
                            {
                                ErrorManager.Error("Cập nhật điểm danh bị lỗi!");
                                return false;
                            }
                        }
                    }
                    else // có rồi thì hoặc thêm mới hoặc sửa
                    {
                        if (item.Parse(drw)) // sửa lại giá trị cũ
                        {
                            // không có giá trị nghỉ thì xóa
                            if (item.NoPermissionQuantity == null && item.PermissionQuantity == null && item.Session1 == "" && item.Session2 == "" && item.Session3 == "" && item.Session4 == "")
                            {
                                item.DateCheckingID = Convert.ToInt64(drw[SIM_DateChecking.C_DateCheckingID]);
                                item.Delete();
                            }
                            else
                            {
                                item.UpdatedUser = UserSession.Username;
                                if (!item.Update())
                                {
                                    ErrorManager.Error("Cập nhật môn học lớp bị lỗi!");
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            ErrorManager.Error("Cập nhật môn học lớp bị lỗi!");
                        }
                    }
                    drw["IsEdit"] = 0;
                }
            }
            obj.CommitTransaction();
            return true;
        }

        private void gvData_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataRow drw = gvData.GetFocusedDataRow();
            if (drw != null)
            {
                drw["IsEdit"] = 1;
                btnSave.Enabled = true;
            }
        }

        private void frmDateChecking_Load(object sender, EventArgs e)
        {
            LoadReferenceData();
            CheckPermission();
            SetToolTip();
            dateChecking.EditValue = DateTime.Now;
        }

        private void gvData_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (e.Value != null)
                if (e.Value.ToString().Trim() == "")
                    e.Value = DBNull.Value;
        }

        private void mnuItemExportToExcel_Click(object sender, EventArgs e)
        {
            gvData.QuickExportToExcel();
        }

        /// <summary>
        ///  Nếu itemOld = null thì là thêm mới với itemNew


    }
}