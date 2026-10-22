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
using SimsObject;
using SimsService;


namespace StudentManager.StudentCollection
{
    public partial class frmStudentCollectionPeriod : FormBase,IForm
    {
        #region Consts

        public const string PERMISSION_ADD = "SIM_StudentCollectionPeriod_Add";
        public const string PERMISSION_DELETE = "SIM_StudentCollectionPeriod_Delete";
        public const string PERMISSION_EDIT = "SIM_StudentCollectionPeriod_Edit";
        public const string PERMISSION_VIEW = "SIM_StudentCollectionPeriod_View";

        #endregion

        #region Variables

        bool bolIsEditing = false; // dang edit hay khong
        SIM_StudentCollectionPeriod itemStudentCollectionPeriodEditing = new SIM_StudentCollectionPeriod(); // record đang edit

        #endregion

        #region IForm Members

        private static frmStudentCollectionPeriod _instance = null;

        public static frmStudentCollectionPeriod Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmStudentCollectionPeriod();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmStudentCollectionPeriod()
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
            uCourseTypeLevel.InitData();
            
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

                SIM_StudentCollectionPeriod objStudentCollectionPeriod = new SIM_StudentCollectionPeriod();
                DataTable dtbStudentCollectionPeriod = objStudentCollectionPeriod.Search();
                if (dtbStudentCollectionPeriod != null)
                {
                    gcData.DataSource = dtbStudentCollectionPeriod;
                    Service.SYS_GridColumnService.InitGridColumn(gvData, "SIM_StudentCollectionPeriod"); // khởi tạo hiện thị cột trên lưới
                    gvData.SearchAndSelectRow(SIM_StudentCollectionPeriod.C_StudentCollectionPeriodID, itemStudentCollectionPeriodEditing.StudentCollectionPeriodID); // chọn dòng đang edit

                    gvData.SetOrder("Order");
                    mnuItemEdit.Enabled = btnEdit.Enabled = gvData.GetFocusedDataRow() != null;
                    gvData.BestFitColumns();
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
                itemStudentCollectionPeriodEditing.StudentCollectionPeriodID = drw[SIM_StudentCollectionPeriod.C_StudentCollectionPeriodID].ToString();                
                if (itemStudentCollectionPeriodEditing.Delete2())
                {
                    gvData.DeleteRow(arrRowIndex[i]);                    
                }
                else
                {
                    ErrorManager.Error("Việc xoá thông tin bị lỗi! Do đã tồn tại hồ sơ tuyển sinh trong đợt này!");
                    break; // ngưng vòng for
                }
                
            }
            return true;
        }

        /// <summary>
        /// Load dữ liệu vào tab edit
        /// </summary>        
        private void ShowEditForm(string provinceID)
        {
            itemStudentCollectionPeriodEditing = new SIM_StudentCollectionPeriod(); 
            if (provinceID != null)
            {
                itemStudentCollectionPeriodEditing.StudentCollectionPeriodID = provinceID;
                if(!itemStudentCollectionPeriodEditing.Get()) // edit thì load lên
                {
                    ErrorManager.Error("Việc lấy thông tin chỉnh sửa bị lỗi!");
                    return;
                }
                btnSaveEdit.Enabled = UserSession.HasPermission(PERMISSION_EDIT); // có quyền edit hay không                    
                txtStudentCollectionPeriodID.ReadOnly = true;
            }
            else
            {                
                btnSaveEdit.Enabled = UserSession.HasPermission(PERMISSION_ADD); // có quyền thêm mới hay không                    
                txtStudentCollectionPeriodID.ReadOnly = false;
            }

            // gán giá trị vào form
            txtStudentCollectionPeriodID.Text = itemStudentCollectionPeriodEditing.StudentCollectionPeriodID;
            txtStudentCollectionPeriodName.Text = itemStudentCollectionPeriodEditing.StudentCollectionPeriodName;
            
            txtStartNo.EditValue = itemStudentCollectionPeriodEditing.StartNo;
            txtFinishNo.EditValue = itemStudentCollectionPeriodEditing.FinishNo;

            dtmStartDate.EditValue = itemStudentCollectionPeriodEditing.StartDate;
            dtmFinishDate.EditValue = itemStudentCollectionPeriodEditing.FinishDate;

            uCourseTypeLevel.CourseIDEditValue = itemStudentCollectionPeriodEditing.CourseID;
            uCourseTypeLevel.TrainingTypeEditValue = itemStudentCollectionPeriodEditing.TrainingType;
            uCourseTypeLevel.TrainingLevelIDEditValue = itemStudentCollectionPeriodEditing.TrainingLevelID;
            if (itemStudentCollectionPeriodEditing.CollectionType != null)
                cbxCollectionType.SelectedIndex = itemStudentCollectionPeriodEditing.CollectionType.Value - 1;
            else
                cbxCollectionType.SelectedIndex = 0;

            txtDescription.Text = itemStudentCollectionPeriodEditing.Description;


            bolIsEditing = true;
            tcData.SelectedTabPage = tpDetail;
            txtStudentCollectionPeriodID.Focus();

        }

        /// <summary>
        /// Kiểm tra tính hợp lệ của dữ liệu ở tab edit
        /// </summary>
        /// <returns></returns>
        private bool IsValidEditForm()
        {
            if (txtStudentCollectionPeriodID.Text.Trim() == "")
            {
                MessageManager.Warning("Bạn phải nhập mã đợt tuyển sinh!");
                txtStudentCollectionPeriodID.Focus();
                return false;
            }
            if (txtStudentCollectionPeriodName.Text.Trim() == "")
            {
                MessageManager.Warning("Bạn phải nhập tên đợt tuyển sinh!");
                txtStudentCollectionPeriodName.Focus();
                return false;
            }
            if (txtStartNo.EditValue == null)
            {
                MessageManager.Warning("Bạn phải nhập số hồ sơ bắt đầu!");
                txtStartNo.Focus();
                return false;
            }
            if (txtFinishNo.EditValue == null)
            {
                MessageManager.Warning("Bạn phải nhập số hồ sơ kết thúc!");
                txtFinishNo.Focus();
                return false;
            }

            return uCourseTypeLevel.IsValidData();                      

        }

        /// <summary>
        /// Save dữ liệu ở tab edit
        /// </summary>
        private bool SaveEditForm()
        {
            itemStudentCollectionPeriodEditing.StudentCollectionPeriodID = txtStudentCollectionPeriodID.TextTrim; 
            itemStudentCollectionPeriodEditing.StudentCollectionPeriodName = txtStudentCollectionPeriodName.TextTrim;

            itemStudentCollectionPeriodEditing.StartNo = txtStartNo.EditValueInt32;
            itemStudentCollectionPeriodEditing.FinishNo = txtFinishNo.EditValueInt32;

            itemStudentCollectionPeriodEditing.StartDate = dtmStartDate.EditValueDateTime;
            itemStudentCollectionPeriodEditing.FinishDate = dtmFinishDate.EditValueDateTime;

            itemStudentCollectionPeriodEditing.CourseID = uCourseTypeLevel.CourseIDEditValue;
            itemStudentCollectionPeriodEditing.TrainingType = uCourseTypeLevel.TrainingTypeEditValue;
            itemStudentCollectionPeriodEditing.TrainingLevelID = uCourseTypeLevel.TrainingLevelIDEditValue;

            itemStudentCollectionPeriodEditing.CollectionType = cbxCollectionType.SelectedIndex + 1;
            itemStudentCollectionPeriodEditing.Description = txtDescription.TextTrim;
            
            if (!txtStudentCollectionPeriodID.ReadOnly) // add new
            {
                
                itemStudentCollectionPeriodEditing.CreatedUser = UserSession.Username;
                if (itemStudentCollectionPeriodEditing.Add())
                    return true;
                else
                {
                    if (itemStudentCollectionPeriodEditing.ErrorException.Message.Contains("PRIMARY KEY") || itemStudentCollectionPeriodEditing.ErrorException.Message.Contains("UNIQUE KEY"))
                        ErrorManager.Error("Trùng mã đợt tuyển sinh!");
                    else
                        ErrorManager.Error("Việc thêm thông tin bị lỗi!");
                    return false;
                }
            }
            else
            {                
                itemStudentCollectionPeriodEditing.UpdatedUser = UserSession.Username;
                if (itemStudentCollectionPeriodEditing.Update())
                    return true;
                else
                {
                    if (itemStudentCollectionPeriodEditing.ErrorException.Message.Contains("PRIMARY KEY") || itemStudentCollectionPeriodEditing.ErrorException.Message.Contains("UNIQUE KEY"))
                        ErrorManager.Error("Trùng mã đợt tuyển sinh!");
                    else
                        ErrorManager.Error("Việc thêm thông tin bị lỗi!");
                    return false;
                }
            }

            // xử lý lỗi ở đây
            ErrorManager.Error("Việc cập nhật dữ liệu bị lỗi!");
            return false;
        }
        
        #endregion

        #region Form Actions

        private void frmStudentCollectionPeriod_Load(object sender, EventArgs e)
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
                SIM_StudentCollectionPeriodService.HaveNewData = true; //Đánh dấu là danh mục này đã có sự thay đổi, để khi GetAll nó load lại
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {            
            DataRow drw = gvData.GetFocusedDataRow();
            if (drw != null)
            {                
                ShowEditForm(drw[SIM_StudentCollectionPeriod.C_StudentCollectionPeriodID].ToString());
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
                    SIM_StudentCollectionPeriodService.HaveNewData = true;  //Đánh dấu là danh mục này đã có sự thay đổi, để khi GetAll nó load lại
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
            frmStudentCollectionPeriod_Load(sender, e);
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

        private void frmStudentCollectionPeriod_KeyDown(object sender, KeyEventArgs e)
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

    }
}