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
namespace StudentManager.Graduation
{
    public partial class frmRegisterGraduationPractice : FormBase, IForm
    {
        #region Consts

        public const string PERMISSION_EDIT = "SIM_RegisterGraduationPractice_Edit";
        public const string PERMISSION_VIEW = "SIM_RegisterGraduationPractice_View";
        
        #endregion

        private string strClassID = "";
        private int? intYearID = 0;
        private int? intSemester = 0;
        private string strYearText = "";
        private string strListIDDeleted = "";
        private DataTable dtbData = null;

        #region Variables
         
        bool bolIsEditing = false; // dang edit hay khong
       // SIM_ReRegister itemStudentEditing = new SIM_ReRegister(); // record đang edit

        #endregion

        #region IForm Members

        private static frmRegisterGraduationPractice _instance = null;

        public static frmRegisterGraduationPractice Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmRegisterGraduationPractice();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmRegisterGraduationPractice()
        {
            InitializeComponent();
        }
       
        #region Support Functions

        private void CheckPermission()
        {
            // Kiểm tra quyền        
            mnuItemCheckAll.Enabled = mnuItemUnCheckAll.Enabled = gvData.OptionsBehavior.Editable = UserSession.HasPermission(PERMISSION_EDIT); // có quyền edit trên khoa đó thì mới cho edit    
        }

        public void LoadReferenceData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadReferenceData));
            else
            {
                uClass.ClassFilter = "ClassType = 0";// chỉ lọc ra lớp bình thường
                uClass.InitData();
                uYearSemester.InitData();
                uYearSemester1.InitData(false); // của môn học lớp

                // load tien mac dinh
                AccountObject.ACC_ReceiptSegment objAcc = new AccountObject.ACC_ReceiptSegment();
                
                txtMoney.EditValue = objAcc.GetDefaultMoney(AccountObject.ReceiptSegmentGroup.ThucTapTotNghiep, null, null, null);
            }
        }

        private bool IsValidData()
        {
            //if (uClass.ScienceIDEditValue == null)
            //{
            //    MessageManager.Warning("Bạn phải chọn khoa!");
            //    uClass.Focus();
            //    return false;
            //}

            if (uClass.CourseIDEditValue == null)
            {
                MessageManager.Warning("Bạn phải chọn khóa học!");
                uClass.Focus();
                return false;
            }
            //if (uClass.TrainingLevelIDEditValue == null)
            //{
            //    MessageManager.Warning("Bạn phải chọn bậc đào tạo!");
            //    uClass.Focus();
            //    return false;
            //} 
            //if (uClass.BranchEditValue  == null)
            //{
            //    MessageManager.Warning("Bạn phải chọn ngành học!");
            //    uClass.Focus();
            //    return false;
            //}
            //if (uClass.SpecialBranchIDEditValue == null)
            //{
            //    MessageManager.Warning("Bạn phải chọn chuyên ngành!");
            //    uClass.Focus();
            //    return false;
            //} 

            //return uYearSemester1.IsValidData(); // fai chọn niên kỳ đăng ký
            return true;
        }
      
        public void LoadData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadData));
            else
            {
                try
                {
                    SIM_RegisterGraduationPractice obj = new SIM_RegisterGraduationPractice();
                    dtbData = obj.Search("@ScienceID", uClass.ScienceIDEditValue,
                                        "@CourseID", uClass.CourseIDEditValue,
                                        "@TrainingLevelID", uClass.TrainingLevelIDEditValue,
                                        "@TrainingType", uClass.TrainingTypeEditValue,
                                        "@BranchID",uClass.BranchEditValue,
                                        "@SpecialBranchID",uClass.SpecialBranchIDEditValue,
                                        "@ClassID",uClass.ClassIDEditValue,                                                   
                                        "@YearID", uYearSemester1.YearIDEditValue, // niên kì đã đăng ký
                                        "@Semester", uYearSemester1.SemesterEditValue);

                    gcData.DataSource = dtbData;
                    SYS_GridColumnService.InitGridColumn(gvData, "SIM_RegisterGraduationPractice");
                    // set order
                    gvData.SetOrder("Order");
                    gvData.BestFitColumns();
                    //ModifyGrid();

                    intYearID = uYearSemester.YearIDEditValueInt32;
                    intSemester = uYearSemester.SemesterEditValueInt32;
                    strYearText = uYearSemester.YearEditValueText;
                    btExportExcel.Enabled = mnuItemExportToExcel.Enabled = dtbData.Rows.Count > 0;                                        
                    btnSave.Enabled = mnuItemSave.Enabled = false;                                                               
                }
                catch (Exception objEx)
                {
                    ErrorManager.Error(objEx);
                    SYS_ErrorLogService.Write(Enums.ActionType.View, "frmRegisterGraduationPractice->LoadData", objEx, 0);
                }
            }
        }
     
        //private void ModifyGrid()
        //{
        //    foreach (DevExpress.XtraGrid.Columns.GridColumn col in gvData.Columns)
        //    {

        //        switch (col.FieldName)
        //        {
        //            case "Schoolfees":
        //                col.DisplayFormat.FormatString = "#,###";
        //                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
        //                break;
        //        }

        //    }
        //}

        /// <summary>
        /// Save dữ liệu
        /// </summary>
        private bool SaveData()
        {
            SIM_RegisterGraduationPractice item = new SIM_RegisterGraduationPractice();
            item.BeginTransaction();

            foreach(DataRow drw in dtbData.Rows)
            {                
                if (drw["IsEdit"].ToString() == "1")
                {
                    SIM_RegisterGraduationPractice item2 = new SIM_RegisterGraduationPractice(); // PHẢI DÙNG CÁI MỚI ĐỂ HÔNG BỊ TRƯỜNG HỢP RÁC TỪ ITEM KHÁC CÒN LẠI khi drw  null thì nó còn data cũ
                    item2.IDB = item.IDB;

                    if (item2.Parse(drw))
                    {
                        if (item2.RegisterGraduationPracticeID == null)// thêm mới
                        {
                            if (Convert.ToBoolean(drw["IsRegister"])) // nếu có check
                            {
                                item2.CreatedUser = UserSession.Username;                                
                                if (!item2.Add())
                                {
                                    ErrorManager.Error("Việc thêm đăng ký bị lỗi!");
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            // nếu là edit mà hông còn check chọn thì xoá
                            if (!Convert.ToBoolean(drw["IsRegister"]))
                            {
                                if (!item2.Delete())
                                {
                                    ErrorManager.Error("Việc gỡ bỏ đăng ký bị lỗi!");
                                    return false;
                                }
                            }
                            else
                            {
                                item2.UpdatedUser = UserSession.Username;
                                if (!item2.Update())
                                {
                                    ErrorManager.Error("Việc cập nhật đăng ký bị lỗi!");
                                    return false;
                                }
                            }
                        }
                    }
                    else
                    {
                        ErrorManager.Error("Việc chuyển dữ liệu từ lưới để lưu bị lỗi!");
                        item.RollBackTransaction();// Parse hong co dung tới db nên nó hông có rollback
                        return false;
                    }
                }
            }

            item.CommitTransaction();
            return true;
        }


        private void CheckAll(bool bolValue)
        {
            if (bolValue)
            {
                foreach(int i in gvData.GetSelectedRows())                
                {
                    DataRow drw = gvData.GetDataRow(i);
                    if (drw["ReceiptNo"].ToString() == "")
                    {
                        drw["IsRegister"] = true;
                        drw["Money"] = txtMoney.EditValueInt32;
                        if (dtmDate.EditValueDateTime != null)
                            drw["Date"] = dtmDate.EditValueDateTime;
                        else
                            drw["Date"] = DBNull.Value;
                        drw["YearID"] = intYearID;
                        drw["Semester"] = intSemester;
                        drw["YearText"] = strYearText;
                        drw["IsEdit"] = 1;
                        
                    }
                }
            }
            else
            {
                foreach (int i in gvData.GetSelectedRows())
                {
                    DataRow drw = gvData.GetDataRow(i);
                    if (drw["ReceiptNo"].ToString() == "")
                    {
                        drw["IsRegister"] = false;
                        drw["Money"] = DBNull.Value;
                        drw["Date"] = DBNull.Value;
                        drw["YearID"] = DBNull.Value;
                        drw["Semester"] = DBNull.Value;
                        drw["YearText"] = DBNull.Value;
                        drw["IsEdit"] = 1;
                    }
                }
            }

            btnSave.Enabled = mnuItemSave.Enabled = true;

        }
        
        #endregion

        #region Form Actions

        private void frmRegisterGraduationPractice_Load(object sender, EventArgs e)
        {
            CheckPermission();
            SetToolTip();
            new Thread(LoadReferenceData).Start();        
        }
      
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                new Thread(LoadData).Start();
            }
        }

        /// <summary>
        private void gvData_EndSorting(object sender, EventArgs e)
        {
            // set order
            gvData.SetOrder("Order");
        }        
                      
        private void btnSave_Click(object sender, EventArgs e)
        {            
                if (SaveData())
                    new Thread(LoadData).Start();
        }
        
        #endregion

        private void gvData_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            string strFieldName = gvData.FocusedColumn.FieldName;
            DataRow drw = gvData.GetFocusedDataRow();
            if (strFieldName == "IsRegister")
            {

                if (Convert.ToBoolean(drw["IsRegister"]))
                {
                    drw["Money"] = txtMoney.EditValueInt32;
                    if (dtmDate.EditValueDateTime != null)
                        drw["Date"] = dtmDate.EditValueDateTime;
                    else
                        drw["Date"] = DBNull.Value;

                    drw["YearID"] = intYearID;
                    drw["Semester"] = intSemester;
                    drw["YearText"] = strYearText;
                }
                else
                {
                    drw["Money"] = DBNull.Value;
                    drw["Date"] = DBNull.Value;
                    drw["YearID"] = DBNull.Value;
                    drw["Semester"] = DBNull.Value;
                    drw["YearText"] = DBNull.Value;
                }
            }
           
            drw["IsEdit"] = 1;
            mnuItemSave.Enabled = btnSave.Enabled = true;
        }

        private void gvData_ShowingEditor(object sender, CancelEventArgs e)
        {
            DataRow drw = gvData.GetFocusedDataRow();
            if (drw != null)
            {               
                if (gvData.FocusedColumn.FieldName == "IsRegister")
                    // thu tiền rui thì ko cho gỡ ra
                    e.Cancel = drw["ReceiptNo"].ToString() != "";
            }
        }        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuItemExportToExcel_Click(object sender, EventArgs e)
        {
            gvData.QuickExportToExcel();
        }

        private void mnuItemRefresh_Click(object sender, EventArgs e)
        {
            uClass.RefrehData();
            btnSearch_Click(null, null);
        }

        private void btExportExcel_Click(object sender, EventArgs e)
        {
            gvData.QuickExportToExcel();
        }

        private void mnuItemCheckAll_Click(object sender, EventArgs e)
        {
            CheckAll(true);
        }

        private void mnuItemUnCheckAll_Click(object sender, EventArgs e)
        {
            CheckAll(false);
        }
    }
}