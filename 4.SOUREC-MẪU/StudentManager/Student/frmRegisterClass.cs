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
using GeneralObject;
using GeneralService;
using DevExpress.XtraGrid.Views.BandedGrid;
using System.Collections;

namespace StudentManager.Student
{
    /// <summary>
    /// 11.10.2023
    /// TW3 Copy từ CĐN Đồng Nai, sync from ĐTháp vì chỉnh sửa chạy được và không giới hạn từ năm 2022
    /// </summary>
    public partial class frmRegisterClass : FormBase, IForm
    {
        #region Consts

        public const string PERMISSION_EDIT = "frmRegisterClass_Edit";
        public const string PERMISSION_VIEW = "frmRegisterClass_View";

        #endregion

        #region Variables
        
        DataTable dtbData; // danh sách dữ liệu sinh viên đã đăng ký
        DataTable dtbStudent; // sv chưa đăng ký
        private bool bolHavePermissionEdit = false;
        private bool bolIsRefresh = false;
       
        #endregion

        #region IForm Members

        private static frmRegisterClass _instance = null;

        public static frmRegisterClass Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmRegisterClass();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmRegisterClass()
        {
            InitializeComponent();
        }

        #region Support Functions

        private void CheckPermission()
        {
            // Kiểm tra quyền                                    
            bolHavePermissionEdit = UserSession.HasPermission(PERMISSION_EDIT);
        }

        public void LoadReferenceData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadReferenceData));
            else
            {
                if (bolIsRefresh)
                {
                    Service.SIM_CourseService.HaveNewData = true;
                    SimsService.SIM_ClassService.HaveNewData = true;
                    uSpecialBranch.RefrehData();
                    uClass.RefrehData();
                }
                else
                {
                    uSpecialBranch.InitData();
                    uClass.InitData();
                }
                Service.SIM_TrainingLevelService.InitLookUpEdit(lookupTrainingLevelID);
                Service.SIM_CourseService.InitLookUpEdit(lookupCourseID);                
                SimsService.SIM_ClassService.InitLookUpEdit(lookupClassID);
            }
        }

        private bool IsValidData()
        {
            if (lookupCourseID.EditValue == null)
            {
                MessageManager.Warning("Bạn phải chọn khoá học!");
                lookupCourseID.Focus();
                return false;
            }
            //if (lookupClassID.EditValue == null)
            //{
            //    MessageManager.Warning("Bạn phải chọn lớp học!");
            //    lookupClassID.Focus();
            //    return false;
            //}
            return true;
        }

        private bool IsValidData_NonMessage()
        {
            if (lookupCourseID.EditValue == null)
            {
                //MessageManager.Warning("Bạn phải chọn khoá học!");
                lookupCourseID.Focus();
                return false;
            }
            if (lookupClassID.EditValue == null)
            {
                //MessageManager.Warning("Bạn phải chọn lớp học!");
                lookupClassID.Focus();
                return false;
            }
            return true;
        }

        public void LoadData()
        {

            SIM_Student obj = new SIM_Student();
            dtbData = obj.GetDataTable("SIM_Student_SearchForRegisterClass",
                                        "@TrainingLevelID", lookupTrainingLevelID.EditValue,
                                        "@CourseID", lookupCourseID.EditValue,
                                        "@BranchID", uSpecialBranch.BranchEditValue,
                                        "@SpecialBranchID", uSpecialBranch.SpecialBranchEditValue
                                        );
                                        //"@ClassID",lookupClassID.EditValue);        giờ không cần filter theo lớp nữa, mà lớp chỉ để filter sinh viên
            if (dtbData != null)
            {
                dtbStudent = dtbData.Copy();

                gcData.DataSource = dtbData;
                gcStudent.DataSource = dtbStudent;

                FilterData();
                FilterStudent();

              
                SystemService.SYS_GridColumnService.InitGridColumn(gvStudent, "SIM_RegisterClass_StudentList",bolIsRefresh);
                SystemService.SYS_GridColumnService.InitGridColumn(gvData, "SIM_RegisterClass_DataList",bolIsRefresh);

                gvStudent.BestFitColumns();
                gvData.BestFitColumns();
                
                mnuItemExportToExcel.Enabled = dtbData.Rows.Count > 0; // load lại thì không cần save 
                btnSave.Enabled = mnuItemSave.Enabled = false;
                bolIsRefresh = false;
            }
            else
            {
                //ErrorManager.Error(obj.ErrorException);
                ErrorManager.Error("Việc lấy thông tin sinh viên bị lỗi!");
            }
        }

        // dữ liệu đã đăng ký của lớp
        private void FilterData()
        {
            if (dtbData != null)
            {
                string strFilter = "";
               
                if (uClass.ClassIDEditValue != null)
                {
                    gvData.RowFilter = "ClassID = '" + uClass.ClassIDEditValue + "'" + strFilter;
                }
                else
                    gvData.RowFilter = "StudentID='-1'"; // ẩn hết sinh viên

                btnDeleteAll.Enabled = mnuItemDeleteAll.Enabled = dtbData.DefaultView.Count > 0 && bolHavePermissionEdit;
                btnAddAll.Enabled = mnuItemAddAll.Enabled = gvData.RowCount > 0 && uClass.ClassIDEditValue != null && bolHavePermissionEdit;
            }
        }

        private void FilterStudent()
        {
            if (dtbStudent != null)
            {

                // Hiển thị tất cả sv, ko cần phân loại chưa đăng ký và đăng ký nữa (để có thể chuyển qua, chuyển lại)
                string strFilter = ""; // = " and IsTempClass = 1 "; // chỉ hiển thị sv chưa đăng ký

                if (lookupClassID.EditValue != null)
                {
                    gvStudent.RowFilter = "ClassID = '" + lookupClassID.EditValue + "'" + strFilter;
                }
                else
                    gvStudent.RowFilter = "StudentID='-1'"; // ẩn hết sinh viên
                
                btnAddAll.Enabled = mnuItemAddAll.Enabled = gvStudent.RowCount > 0 && uClass.ClassIDEditValue != null && bolHavePermissionEdit;
            }
        }


        private void FilterSpecialBranch()
        {
            if (lookupTrainingLevelID.EditValue != null)
            {
                DataRow[] rows = Service.SIM_TrainingLevelService.Table.Select("TrainingLevelID = '" + lookupTrainingLevelID.EditValueString + "'");
                if (rows.Length > 0)
                    uSpecialBranch.SpecialBranchFilter = "LearningLevel = " + rows[0]["LearningLevel"];
            }
            else
                uSpecialBranch.SpecialBranchFilter = "";
        }

        private void FilterClass()
        {
            string strFilter = "";
            if (!chkIsAllClass.Checked)
            {
                if (lookupTrainingLevelID.EditValue != null)
                    strFilter += "and TrainingLevelID ='" + lookupTrainingLevelID.EditValue + "'";

                if (uSpecialBranch.SpecialBranchEditValue != null)
                    strFilter += "and SpecialBranchID = '" + uSpecialBranch.SpecialBranchEditValue + "' ";

                else if (uSpecialBranch.BranchEditValue != null)
                    strFilter += "and BranchID = '" + uSpecialBranch.BranchEditValue + "'";


                if (lookupCourseID.EditValue != null)
                    strFilter += "and CourseID = '" + lookupCourseID.EditValue + "'";

                if (strFilter != "")
                    strFilter = strFilter.Substring(3);
            }

            lookupClassID.RowFilter = strFilter;
        }


        /// <summary>
        /// Save dữ liệu ở tab edit
        /// </summary>
        private bool SaveData()
        {
            SIM_Student item = new SIM_Student();
            item.BeginTransaction();

            string strLogDetail = "";
            foreach(DataRow drw in dtbData.Rows)
            {
                if (drw["IsEdit"].ToString() == "1")
                {
                    item.StudentID = Convert.ToInt64(drw["StudentID"]);
                    item.ClassID = drw["ClassID"].ToString();
                    item.UpdatedUser = UserSession.Username;
                    if(!item.UpdateClass())
                    {
                        ErrorManager.Error("Việc đăng ký lớp học bị lỗi!");
                        return false;
                    }

                    // nhớ log
                    strLogDetail += "Sinh viên: " + drw["StudentCode"] + " - " + drw["StudentFirstName"] + " " + drw["StudentLastName"]
                                    + "\t\t Đã được chuyển từ lớp:  " + drw["CurrentClassID"] + "\t\t  --> " + drw["ClassID"]
                                    + "\r\n";
                }
            }
            item.CommitTransaction();

            // Ghi log
            new SystemObject.SYS_ActionLog().WriteActionLog("Phân lớp sinh viên", strLogDetail, SystemObject.ActionLogType.EDIT, 2, UserSession.Username);

            return true;
        }

        private void ModifyGrid()
        {
            #region Commom

            //foreach (DevExpress.XtraGrid.Columns.GridColumn col in gvData.Columns)
            //{
            //    col.OptionsColumn.AllowEdit = true;

            //    switch (col.FieldName)
            //    {
            //        case "Order":
            //            col.Caption = "STT";
            //            col.OptionsColumn.AllowEdit = false;
            //            break;
            //        case "StudentFirstName":
            //            col.Caption = "Họ lót";
            //            col.OptionsColumn.AllowEdit = false;
            //            break;
            //        case "StudentLastName":
            //            col.Caption = "Tên";
            //            col.OptionsColumn.AllowEdit = false;
            //            break;
            //        case "GenderText":
            //            col.Caption = "Giới tính";
            //            col.OptionsColumn.AllowEdit = false;
            //            break;                   
            //        default:
            //            col.Visible = false;
            //            break;
            //    }

            //}

            #endregion
        }

        private void CheckAllStudent(bool bolValue)
        {
            for (int i = 0; i < gvStudent.RowCount; i++)
            {
                DataRow drw = gvStudent.GetDataRow(i);
                drw["IsSelected"] = bolValue;
            }
        }

        private void CheckAllData(bool bolValue)
        {
            for (int i = 0; i < gvData.RowCount; i++)
            {
                DataRow drw = gvData.GetDataRow(i);
                drw["IsSelected"] = bolValue;
            }
        }

        /// <summary>
        /// Add sinh vien vào lớp
        /// </summary>
        /// <param name="isAddAll"></param>
        private void AddStudent(bool isAddAll)
        {
            for (int i = gvStudent.RowCount - 1; i >= 0; i--)
            {
                DataRow drw = gvStudent.GetDataRow(i);
                if (isAddAll || gvStudent.IsRowSelected(i))
                {
                    // Đánh dấu xoá ở dữ liệu
                    drw["ClassID"] = uClass.ClassIDEditValue; // gán lớp học
                    drw["IsTempClass"] = 0;
                    drw["IsEdit"] = 1; // có thay đổi

                    // gán ngược qua dữ liệu đã đăng ký
                    dtbData = dtbStudent.Copy();
                    gcData.DataSource = dtbData;
                    FilterData();
                }
            }
            if (isAddAll)
            {
                btnAdd.Enabled = mnuItemAdd.Enabled =  btnAddAll.Enabled = mnuItemAddAll.Enabled =  false;                
            }
            else
            {
                btnAdd.Enabled = mnuItemAdd.Enabled =  false;
                btnAddAll.Enabled = mnuItemAddAll.Enabled =  gvStudent.RowCount > 0 && bolHavePermissionEdit;
            }
            btnDeleteAll.Enabled = mnuItemDeleteAll.Enabled =  gvData.RowCount > 0 && bolHavePermissionEdit;
            btnSave.Enabled = mnuItemSave.Enabled = bolHavePermissionEdit;
        }

        /// <summary>
        /// Add sinh vien vào lớp
        /// </summary>
        /// <param name="isAddAll"></param>
        private void DelStudent(bool isDelAll)
        {
            for (int i = gvData.RowCount - 1; i >= 0; i--)
            {
                DataRow drw = gvData.GetDataRow(i);
                if (isDelAll || gvData.IsRowSelected(i))
                {
                    // Đánh dấu xoá ở dữ liệu
                    drw["ClassID"] = lookupClassID.EditValueString; // gán lớp học bên trái
                    drw["IsTempClass"] = 1;
                    drw["IsEdit"] = 1; // có thay đổi

                    // gán ngược qua dữ liệu đã đăng ký
                    dtbStudent = dtbData.Copy();
                    gcStudent.DataSource = dtbStudent;
                    FilterStudent();
                }
            }
            if (isDelAll)
                btnDelete.Enabled = mnuItemDelete.Enabled =  btnDeleteAll.Enabled = mnuItemDeleteAll.Enabled =  false;
            else
            {
                btnDelete.Enabled = mnuItemDelete.Enabled =  false;
                btnDeleteAll.Enabled = mnuItemDeleteAll.Enabled =  gvData.RowCount > 0 && bolHavePermissionEdit;
            }
            btnAddAll.Enabled = mnuItemAddAll.Enabled =  gvStudent.RowCount > 0 && uClass.ClassIDEditValue != null && bolHavePermissionEdit;
            btnSave.Enabled = mnuItemSave.Enabled = bolHavePermissionEdit;
        } 

        #endregion

        #region Form Actions

        private void frmRegisterClass_Load(object sender, EventArgs e)
        {

            CheckPermission();
            SetToolTip();
            new Thread(LoadReferenceData).Start();
        }

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
                
                LoadData();
                //new Thread(LoadData).Start();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageManager.Confirm("Bạn có thực sự muốn lưu những thay đổi dữ liệu này?") == DialogResult.Yes)
            {
                if (SaveData())
                {
                    //MessageManager.Info("Đã cập nhật dữ liệu thành công!");
                    LoadData();
                    //new Thread(LoadData).Start();
                }
            }
        }

        private void uClass_EditValueChanged(object sender, EventArgs arg)
        {
            FilterData();            
        }

        private void gvData_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            btnDelete.Enabled = mnuItemDelete.Enabled =  gvData.SelectedRowsCount > 0;
        }

        private void gvData_ShowingEditor(object sender, CancelEventArgs e)
        {
           
        }

        private void mnuItemCheckAll_Click(object sender, EventArgs e)
        {
            CheckAllData(true);
        }

        private void mnuItemUnCheckAll_Click(object sender, EventArgs e)
        {
            CheckAllData(false);
        }

            
        private void gvStudent_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            btnAdd.Enabled = mnuItemAdd.Enabled = gvStudent.SelectedRowsCount > 0 && uClass.ClassIDEditValue != null && bolHavePermissionEdit;
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            AddStudent(true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddStudent(false);
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            DelStudent(true);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DelStudent(false);
        }

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (IsValidData_NonMessage())
            {
                if (btnSave.Enabled)
                {
                    DialogResult dlrConfirm = MessageManager.Confirm("Bạn có muốn lưu lại thông tin thay đổi trước khi đóng màn hình?");
                    if (dlrConfirm == DialogResult.Cancel)
                        return;
                    else if (dlrConfirm == DialogResult.Yes)
                        if (!SaveData())
                            return;// lưu không thành công thì return

                    LoadData(); //load leen cho chac, neu khong lat no mo form len nua thi kho
                }
                //new Thread(LoadData).Start();
                this.Close();
            }
        }

        private void mnuItemExportToExcel_Click(object sender, EventArgs e)
        {
            gvData.QuickExportToExcel();
        }

        private void gvStudent_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            btnAdd.Enabled = mnuItemAdd.Enabled = gvStudent.SelectedRowsCount > 0 && uClass.ClassIDEditValue != null && bolHavePermissionEdit;
        }

        private void gvData_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            btnDelete.Enabled = mnuItemDelete.Enabled = gvData.SelectedRowsCount > 0 && bolHavePermissionEdit;
        }

        private void mnuItemCheckAll1_Click(object sender, EventArgs e)
        {
            CheckAllStudent(true);
        }

        private void mnuItemUnCheckAll1_Click(object sender, EventArgs e)
        {
            CheckAllStudent(false);
        }

        private void lookupTrainingLevelID_EditValueChanged(object sender, EventArgs arg)
        {
            uClass.TrainingLevelIDEditValue = lookupTrainingLevelID.EditValue;

            FilterSpecialBranch();

            if (!chkIsAllClass.Checked)
                FilterClass();
        }

        private void uSpecialBranch_EditValueChanged(object sender, EventArgs arg)
        {            
            uClass.SpecialBranchIDEditValue = uSpecialBranch.SpecialBranchEditValue;

            if (!chkIsAllClass.Checked)
                FilterClass();
        }


        private void lookupCourseID_EditValueChanged(object sender, EventArgs arg)
        {
            uClass.CourseIDEditValue = lookupCourseID.EditValueString;

            if (!chkIsAllClass.Checked)
                FilterClass();
        }

        
        private void mnuItemRefresh1_Click(object sender, EventArgs e)
        {
            bolIsRefresh = true;
            LoadReferenceData();
            btnSearch_Click(null, null);
        }

        private void mnuItemRefresh_Click(object sender, EventArgs e)
        {
            bolIsRefresh = true;
            btnSearch_Click(null, null);
        }

        private void chkIsAllClass_CheckedChanged(object sender, EventArgs e)
        {
            FilterClass();
        }

        private void lookupClassID_EditValueChanged(object sender, EventArgs arg)
        {
            FilterStudent(); 
        }

        private void gvStudent_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            DataRow drw = gvStudent.GetDataRow(e.RowHandle);
            if (drw != null && Convert.ToBoolean(drw["IsEdit"]))
            {
                e.Appearance.BackColor = Color.LightPink;
            }
        }


        private void gvData_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            DataRow drw = gvData.GetDataRow(e.RowHandle);
            if (drw != null && Convert.ToBoolean(drw["IsEdit"]))
            {
                e.Appearance.BackColor = Color.LightPink;
            }
        }

        

        
    }
}

