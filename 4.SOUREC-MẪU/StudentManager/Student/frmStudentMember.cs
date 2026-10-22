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
using GeneralService;
using SystemObject;

namespace StudentManager.Student
{
    public partial class frmStudentMember : FormBase, IForm
    {
        #region Consts
        public const string PERMISSION_ADD = "SIM_StudentMember_Add";
        public const string PERMISSION_DELETE = "SIM_StudentMember_Delete";
        public const string PERMISSION_EDIT = "SIM_StudentMember_Edit";
        public const string PERMISSION_VIEW = "SIM_StudentMember_View";

        #endregion

        #region Variables

        DataTable dtbData;
        bool bolIsParent = false;
        bool bolIsRefresh = false;

        #endregion

        #region IForm Members

        private static frmStudentMember _instance = null;

        public static frmStudentMember Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmStudentMember();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion


        public frmStudentMember()
        {
            InitializeComponent();
        }

        #region Support Functions

        private void CheckPermission()
        {
            //string strOfficeFilter = UserSession.GetOfficeFilter(PERMISSION_VIEW); // lọc lại lớp theo quyền chi nhánh
            //uClass.OfficeFilter = strOfficeFilter;
            //gvData.RowFilter = strOfficeFilter.Replace("OfficeID", "RegisterOfficeID"); // filter theo nơi đăng ký
            //uRegisterOffice.OfficeFilter = strOfficeFilter;

        }

        public void LoadReferenceData()
        {
            if (bolIsRefresh)
            {
                uClass.RefrehData();
            }
            else
            {
                uClass.InitData();
            }
        }

        public void LoadData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadData));
            else
            {
                bolIsParent = rdoIsParent.Checked;
                SIM_Student obj = new SIM_Student();
                dtbData = obj.GetDataTable("SIM_Student_Search_Member",
                                    "@Keyword", txtKeyword.TextTrim,
                                    "@CourseID", uClass.CourseIDEditValue,
                                    "@BranchID", uClass.BranchEditValue,
                                    "@TrainingLevelID", uClass.TrainingLevelIDEditValue,
                                    "@TrainingType", uClass.TrainingTypeEditValue,
                                    "@ScienceID", uClass.ScienceIDEditValue,
                                    "@ClassID", uClass.ClassIDEditValue,
                                    "@IsParentOfStudent", bolIsParent);
                if (dtbData != null)
                {
                    ModifyData(); // xoá bớt dòng trùng
                    gcData.DataSource = dtbData;
                    SystemService.SYS_GridColumnService.InitGridColumn(gvData, "SIM_Student_Member", bolIsRefresh);
                    ModifyGrid();
                    mnuItemExportToExcel.Enabled = dtbData.Rows.Count > 0;
                    btnSave.Enabled = mnuItemSave.Enabled = dtbData.Select("IsNew =1").Length > 0; // có dòng cần thêm mới thì bậc lưu
                    bolIsRefresh = false;
                }
                else
                {
                    ErrorManager.Error("Việc lấy thông tin bị lỗi!");
                }
            }
        }

        private void ModifyData()
        {
            // xoá bớt dòng nếu trùng mã phiếu thu (trùng khi một phiếu thu của 2 đăng ký lớp khác nhau)
            long lngIDPrev = -1;
            int i = dtbData.Rows.Count - 1;
            while (i >= 0)
            {
                long lngID = Convert.ToInt64(dtbData.Rows[i][SIM_Student.C_StudentID]);
                if (lngID == lngIDPrev)
                    dtbData.Rows.RemoveAt(i);
                else
                    lngIDPrev = lngID;
                i--;
            }
        }

        private void ModifyGrid()
        {
        }

        /// <summary>
        /// Xóa từng dòng được chọn, bị lỗi chỗ nào thì ngưng chỗ ấy lại
        /// </summary>
        /// <returns></returns>
        private bool DeleteData()
        {
            SYS_User objUser = new SYS_User();

            int[] arrRowIndex = gvData.GetSelectedRows();
            for (int i = arrRowIndex.Length - 1; i >= 0; i--)
            {
                DataRow drw = gvData.GetDataRow(arrRowIndex[i]);
                if (drw["Username"].ToString() != "")
                {
                    //if (!UserSession.HasPermissionForOffice(PERMISSION_DELETE, drw["RegisterOfficeID"].ToString()))
                    //{
                    //    MessageManager.Warning("Bạn không có quyền xoá tài khoản học viên của chi nhánh '"
                    //        + new SIM_Office().Get(Convert.ToInt32(drw["RegisterOfficeID"])).OfficeName + "'");
                    //    return false;
                    //}

                    if (!objUser.Delete(drw["Username"].ToString(), UserSession.Username))
                    {
                        ErrorManager.Error("Dữ liệu đang sử dụng bạn không xóa được!");
                        return false;
                    }
                    gvData.DeleteRow(arrRowIndex[i]);
                }
            }
            return true;
        }

        /// <summary>
        /// Save dữ liệu ở lưới
        /// </summary>
        private bool SaveData()
        {
            if (dtbData != null)
            {
                SYS_User item0 = new SYS_User();
                item0.BeginTransaction();
                foreach (DataRow drw in dtbData.Rows)
                {
                    if (drw.RowState == DataRowState.Modified || Convert.ToBoolean(drw["IsNew"])) // nếu dòng đó có sửa hoặc là thêm mới
                    {
                        SYS_User item = new SYS_User();
                        item.IDB = item0.IDB;

                        item.Username = drw["Username"].ToString();
                        item.LoginName = drw["LoginName"].ToString();
                        if (drw["Password"].ToString() != "")
                            item.Password = Libs.DGCCrypt.EncryptPass(drw["Password"].ToString());
                        else
                            item.Password = drw["CurentPassword"].ToString(); // nếu k đổi mật khẩu thì mật khẩu như cũ

                        item.FirstName = drw["StudentFirstName"].ToString();
                        item.LastName = drw["StudentLastName"].ToString();
                        item.FullName = item.FirstName + " " + item.LastName;
                        if (drw["IsActived"] == null || drw["IsActived"].ToString()== "" || !Convert.ToBoolean(drw["IsActived"]))
                            item.IsActived = false;
                        else
                            item.IsActived = true;
                        item.IsParentOfStudent = bolIsParent;
                        item.StudentID = Convert.ToInt64(drw["StudentID"]);

                        item.CreatedUser = UserSession.Username;
                        if (!item.AddOrEdit())
                        {
                            ErrorManager.Error("Việc cập nhật thông tin bị lỗi!");
                            return false;
                        }

                        //if (Convert.ToBoolean(drw["IsNew"]))
                        //{
                        //    item.CreatedUser = UserSession.Username;
                        //    if (!item.Add())
                        //    {
                        //        ErrorManager.Error("Việc thêm thông tin bị lỗi!");
                        //        return false;
                        //    }
                        //}
                        //else
                        //{

                        //    item.UpdatedUser = UserSession.Username;
                        //    if (!item.Update())
                        //    {
                        //        ErrorManager.Error("Việc cập nhật thông tin bị lỗi!");
                        //        return false;
                        //    }
                        //}                        
                    }
                }
                item0.CommitTransaction();
                return true;
            }
            return true;
        }

        private string CheckValidate(DataRow drw)
        {
            if (drw == null)
                return "";
            SIM_Student item = new SIM_Student();
            if (item.Parse(drw))
            {
                //if (item.StudentCode == "" || item.StudentCode == null)
                //    return "Bạn phải nhập mã sinh viên!";
                //if (item.StudentName == "" || item.StudentName == null)
                //    return "Bạn phải nhập tên lớp!";
                //if (item.TrainingLevelID == null)
                //    return "Bạn phải chọn cấp độ!";
                //if (item.OfficeID == null)
                //    return "Bạn phải chọn chi nhánh!";
            }
            return "";
        }

        #endregion

        #region Form Actions

        private void frmStudentMember_Load(object sender, EventArgs e)
        {
            LoadReferenceData();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageManager.Confirm("Bạn thực sự muốn xóa những dữ liệu này?") == DialogResult.Yes)
            {
                DeleteData();
                SIM_StudentService.HaveNewData = true; //Đánh dấu là danh mục này đã có sự thay đổi, để khi GetAll nó load lại
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                new Thread(LoadData).Start();
                SIM_StudentService.HaveNewData = true;  //Đánh dấu là danh mục này đã có sự thay đổi, để khi GetAll nó load lại
                btnSave.Enabled = mnuItemSave.Enabled = false;
            }
        }

        private void mnuItemRefresh_Click(object sender, EventArgs e)
        {
            bolIsRefresh = true;
            LoadReferenceData();
            new Thread(LoadData).Start();
        }

        private void mnuItemExportToExcel_Click(object sender, EventArgs e)
        {
            gvData.QuickExportToExcel();
        }

        private void frmStudentMember_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F1:
                    this.ShowToolTip();
                    break;

                case Keys.F4:
                    if (btnDelete.Enabled)
                        btnDelete_Click(sender, null);
                    break;
                case Keys.F5:
                    mnuItemRefresh_Click(sender, null);
                    break;
                case Keys.F6:
                    if (mnuItemSave.Enabled)
                        btnSave_Click(sender, null);
                    break;
                case Keys.F7:
                    //btnPrint_Click(sender, null);
                    break;
                case Keys.F8:
                    gvData.AddNewRow();
                    break;
                case Keys.Escape:
                    break;
            }
        }

        #endregion

        #region Grid Actions

        private void gvData_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (!gvData.IsNewItemRow(gvData.FocusedRowHandle))
            {
                if (!UserSession.HasPermission(PERMISSION_EDIT, gvData.GetFocusedDataRow()["ScienceID"].ToString()))
                    e.Cancel = true;
                else
                {
                    //switch (gvData.FocusedColumn.FieldName)
                    //{
                    //    case SIM_Student.C_StudentID:                        
                    //        e.Cancel = true;
                    //        break;
                    //}
                }
            }
        }

        private void gvData_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (gvData.FocusedRowHandle == -999997)
                return;
            string strError = "";
            switch (gvData.FocusedColumn.FieldName)
            {
                case SIM_Student.C_StudentCode:
                    e.Valid = Libs.ValidationHelper.ValidateEmptyString(e.Value, "Mã không được bỏ trống!", ref strError);
                    if (e.Valid == true)
                    {
                        if (gvData.SearchRow(SIM_Student.C_StudentCode, e.Value, gvData.FocusedRowHandle) >= 0)
                        {
                            strError = "Đã tồn tại mã dữ liệu này!";
                            e.Valid = false;
                        }
                    }
                    break;

            }

            if (strError != "")
                e.ErrorText = strError;
        }

        private void gvData_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            // kiểm tra ràng buộc dữ liệu tại đây
            DataRow drw = gvData.GetFocusedDataRow();
            string strError = CheckValidate(gvData.GetFocusedDataRow());
            if (strError != "")
            {
                e.ErrorText = strError;
                e.Valid = false;
            }
            else
                btnSave.Enabled = mnuItemSave.Enabled = true;
        }

        private void gvData_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
        }

        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            new Thread(LoadData).Start();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

    }
}