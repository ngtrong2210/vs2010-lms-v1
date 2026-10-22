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
using Service;
using SimsObject;
using SimsService;


namespace StudentManager.Graduation
{
    public partial class frmExamDate : FormBase,IForm
    {
        #region Consts
        public const string PERMISSION_ADD = "SIM_ExamDate_Add";
        public const string PERMISSION_DELETE = "SIM_ExamDate_Delete";
        public const string PERMISSION_EDIT = "SIM_ExamDate_Edit";
        public const string PERMISSION_VIEW = "SIM_ExamDate_View";

        #endregion

        #region Variables

        bool bolIsEditing = false; // dang edit hay khong
        SIM_ExamDate itemExamDateEditing = new SIM_ExamDate(); // record đang edit

        #endregion

        #region IForm Members

        private static frmExamDate _instance = null;

        public static frmExamDate Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmExamDate();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion


        public frmExamDate()
        {
            InitializeComponent();
        }
        

        #region Support Functions

        private void CheckPermission()
        {
            // Kiểm tra quyền
            mnuItemAdd.Enabled = btnAdd.Enabled = UserSession.HasPermission(PERMISSION_ADD);
            mnuItemEdit.Text = btnEdit.Text = UserSession.HasPermission(PERMISSION_EDIT) ? "Sửa" : "Xem";
        }
        public void LoadReferenceData()
        {
            uYearSemester.InitData();
        }

        /// <summary>
        /// Làm mới dữ liệu trong các combobox hay này nọ...
        /// </summary>
        public void RefreshReferenceData()
        {            
            LoadReferenceData();
        }

        public void LoadData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadData));
            else
            {

                SIM_ExamDate objExamDate = new SIM_ExamDate();
                DataTable dtbExamDate = objExamDate.Search();
                if (dtbExamDate != null)
                {
                    gcData.DataSource = dtbExamDate;
                    SYS_GridColumnService.InitGridColumn(gvData, "SIM_ExamDate"); // khởi tạo hiện thị cột trên lưới
                    gvData.SearchAndSelectRow(SIM_ExamDate.C_ExamDateID, itemExamDateEditing.ExamDateID); // chọn dòng đang edit

                    gvData.SetOrder("Order");
                    mnuItemEdit.Enabled = btnEdit.Enabled = gvData.GetFocusedDataRow() != null;
                    //btnSaveGrid.Enabled = false; // load thì không cần save trên lưới                                   
                }
                else
                {
                    ErrorManager.Error("Việc lấy thông tin bị lỗi!");
                }
            }
        }
        

        /// <summary>
        /// Xóa từng dòng được chọn, bị lỗi chỗ nào thì ngưng chỗ ấy lại
        /// </summary>
        /// <returns></returns>
        private bool DeleteData()
        {            
            int[] arrRowIndex = gvData.GetSelectedRows();
            for (int i = arrRowIndex.Length - 1; i >= 0; i--)
            {
                DataRow drw = gvData.GetDataRow(arrRowIndex[i]);
                itemExamDateEditing.ExamDateID = Convert.ToInt32(drw[SIM_ExamDate.C_ExamDateID]);
                if (itemExamDateEditing.Delete())
                {
                    gvData.DeleteRow(arrRowIndex[i]);                    
                }
                else
                {
                    ErrorManager.Error("Việc xoá thông tin bị lỗi! Kì thi tốt nghiệp đang được sử dụng!");
                    break; // ngưng vòng for
                }
                
            }
            return true;
        }

        /// <summary>
        /// Load dữ liệu vào tab edit
        /// </summary>        
        private void ShowEditForm(int? examDateID)
        {
            itemExamDateEditing = new SIM_ExamDate();
            if (examDateID != null)
            {
                itemExamDateEditing.ExamDateID = examDateID;
                if(!itemExamDateEditing.Get()) // edit thì load lên
                {
                    ErrorManager.Error("Việc lấy thông tin chỉnh sửa bị lỗi!");
                    return;
                }
                btnSaveEdit.Enabled = UserSession.HasPermission(PERMISSION_EDIT); // có quyền edit hay không                                    
            }
            else
            {                
                btnSaveEdit.Enabled = UserSession.HasPermission(PERMISSION_ADD); // có quyền thêm mới hay không                                    
            }

            // gán giá trị vào form
            dtmExamDate.EditValue = itemExamDateEditing.ExamDate;
            txtExamDateName.Text = itemExamDateEditing.ExamDateName;

            txtDescription.Text = itemExamDateEditing.Description;
            uYearSemester.YearIDEditValue = itemExamDateEditing.YearID;
            uYearSemester.SemesterEditValue = itemExamDateEditing.Semester;
            chkIsActived.Checked = itemExamDateEditing.IsActived;
            chkIsDefault.Checked = itemExamDateEditing.IsDefault;
            txtOrderIndex.EditValue = itemExamDateEditing.OrderIndex;
            chkIsGraduation.Checked = itemExamDateEditing.IsGraduation;


            bolIsEditing = true;
            tcData.SelectedTabPage = tpDetail;
            dtmExamDate.Focus();
        }

        /// <summary>
        /// Kiểm tra tính hợp lệ của dữ liệu ở tab edit
        /// </summary>
        /// <returns></returns>
        private bool IsValidEditForm()
        {
            if (dtmExamDate.EditValue == null)
            {
                MessageManager.Warning("Bạn phải chọn ngày cho kì thi tốt nghiệp!");
                dtmExamDate.Focus();
                return false;
            }
            return true;

        }

        /// <summary>
        /// Save dữ liệu ở tab edit
        /// </summary>
        private bool SaveEditForm()
        {
            itemExamDateEditing.ExamDate = dtmExamDate.EditValueDateTime.Value.Date;
            itemExamDateEditing.ExamDateName = txtExamDateName.TextTrim;
            itemExamDateEditing.Description = txtDescription.TextTrim;
            itemExamDateEditing.IsActived = chkIsActived.Checked;
            itemExamDateEditing.IsDefault = chkIsDefault.Checked;
            itemExamDateEditing.OrderIndex = txtOrderIndex.EditValueInt32;
            itemExamDateEditing.YearID = uYearSemester.YearIDEditValueInt32;
            itemExamDateEditing.Semester = uYearSemester.SemesterEditValueInt32;
            itemExamDateEditing.IsGraduation = chkIsGraduation.Checked;

            if (itemExamDateEditing.ExamDateID == null) // add new
            {
                itemExamDateEditing.CreatedUser = UserSession.Username;
                if (itemExamDateEditing.Add())
                    return true;
            }
            else
            {
                itemExamDateEditing.UpdatedUser = UserSession.Username;
                if (itemExamDateEditing.Update())
                    return true;
            }

            // xử lý lỗi ở đây
            ErrorManager.Error("Việc cập nhật dữ liệu bị lỗi!");
            return false;
        }
        
        #endregion

        #region Form Actions

        private void frmExamDate_Load(object sender, EventArgs e)
        {
            new Thread(LoadReferenceData).Start();
            new Thread(LoadData).Start();
            CheckPermission();
            SetToolTip();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvData_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            mnuItemDelete.Enabled = btnDelete.Enabled = gvData.SelectedRowsCount > 0 && UserSession.HasPermission(PERMISSION_DELETE);           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {            
            ShowEditForm(null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageManager.Confirm("Bạn thực sự muốn xóa những dữ liệu này?") == DialogResult.Yes)
            {
                DeleteData();
                mnuItemEdit.Enabled = btnEdit.Enabled = gvData.GetFocusedDataRow() != null;
                SIM_ExamDateService.HaveNewData = true; //Đánh dấu là danh mục này đã có sự thay đổi, để khi GetAll nó load lại
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {            
            DataRow drw = gvData.GetFocusedDataRow();
            if (drw != null)
            {
                ShowEditForm(Convert.ToInt32(drw[SIM_ExamDate.C_ExamDateID]));
            }
        }

        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            if (IsValidEditForm())
                if (SaveEditForm())
                {
                    bolIsEditing = false;
                    new Thread(LoadData).Start();
                    tcData.SelectedTabPage = tpList;
                    SIM_ExamDateService.HaveNewData = true;  //Đánh dấu là danh mục này đã có sự thay đổi, để khi GetAll nó load lại
                }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            bolIsEditing = false;
            tcData.SelectedTabPage = tpList;
        }

        private void mnuItemRefresh_Click(object sender, EventArgs e)
        {
            RefreshReferenceData();
            frmExamDate_Load(sender, e);
        }

        private void mnuItemExportToExcel_Click(object sender, EventArgs e)
        {
            gvData.QuickExportToExcel();
        }
        
        private void tcData_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            if ((!bolIsEditing && e.Page == tpDetail) || (bolIsEditing && e.Page == tpList))
                e.Cancel = true;
        }

        private void frmExamDate_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F1:
                    this.ShowToolTip();
                    break;
                    
                case Keys.F2:
                    if (!bolIsEditing)
                        btnEdit_Click(sender, null);
                    break;
                case Keys.F3:
                //    if (!bolIsEditing)
                //        btnSearch_Click(sender, null);
                //    break;
                case Keys.F4:
                    if (btnDelete.Enabled && !bolIsEditing)
                        btnDelete_Click(sender, null);
                    break;
                case Keys.F5:
                    if (!bolIsEditing)
                        mnuItemRefresh_Click(sender, null);
                    else
                        RefreshReferenceData();
                    break;
                case Keys.F6:
                    if (btnSaveEdit.Enabled && bolIsEditing)
                        btnSaveEdit_Click(sender, null);
                    break;
                case Keys.F7:
                    //btnPrint_Click(sender, null);
                    break;
                case Keys.F8:
                    if (btnAdd.Enabled && !bolIsEditing)
                        btnAdd_Click(sender, null);
                    break;
                case Keys.Escape:
                    if (bolIsEditing)
                        btnCancel_Click(sender, null);
                    break;
            }
        }

        #endregion

        private void gvData_EndSorting(object sender, EventArgs e)
        {
            gvData.SetOrder("Order");
        }

        private void dtmExamDate_EditValueChanged(object sender, EventArgs arg)
        {
            if (dtmExamDate.EditValue != null)
                txtExamDateName.Text = dtmExamDate.EditValueDateTime.Value.ToString("dd/MM/yyyy");
        }

       

    }
}