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
namespace StudentManager.Learning
{
    public partial class frmReRegister : FormBase, IForm
    {
        #region Consts
        
        public const string PERMISSION_EDIT = "SIM_ReRegister_Edit";
        public const string PERMISSION_VIEW = "SIM_ReRegister_View";
        
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

        private static frmReRegister _instance = null;

        public static frmReRegister Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmReRegister();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmReRegister()
        {
            InitializeComponent();
        }
       
        #region Support Functions

        private void CheckPermission()
        {
            // Kiểm tra quyền        
            gvData.OptionsBehavior.Editable = UserSession.HasPermission(PERMISSION_EDIT); // có quyền edit trên khoa đó thì mới cho edit    
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
                txtLearningMoney.EditValue = objAcc.GetDefaultMoney(AccountObject.ReceiptSegmentGroup.HocLai, null, null, null);
                txtExamMoney.EditValue = objAcc.GetDefaultMoney(AccountObject.ReceiptSegmentGroup.ThiLai, null, null, null);
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

            //if (uClass.CourseIDEditValue == null)
            //{
            //    MessageManager.Warning("Bạn phải chọn khóa học!");
            //    uClass.Focus();
            //    return false;
            //}
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

            return uYearSemester.IsValidData(); // fai chọn niên kỳ đăng ký
        }
      
        public void LoadData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadData));
            else
            {
                try
                {
                    SIM_ReRegister obj = new SIM_ReRegister();
                    dtbData = obj.SearchDeptSubject("@ScienceID", uClass.ScienceIDEditValue,
                                                    "@CourseID", uClass.CourseIDEditValue,
                                                    "@TrainingLevelID", uClass.TrainingLevelIDEditValue,
                                                    "@TrainingType", uClass.TrainingTypeEditValue,
                                                    "@BranchID",uClass.BranchEditValue,
                                                    "@SpecialBranchID",uClass.SpecialBranchIDEditValue,
                                                    "@ClassID",uClass.ClassIDEditValue,
                                                    "@YearID",uYearSemester.YearIDEditValue, 
                                                    "@Semester",uYearSemester.SemesterEditValue,

                                                    "@YearID1", uYearSemester1.YearIDEditValue, // niên kì học môn đó
                                                    "@Semester1", uYearSemester1.SemesterEditValue);

                    gcData.DataSource = dtbData;
                    SYS_GridColumnService.InitGridColumn(gvData, "SIM_ReRegister_DeptSubject");
                    // set order
                    gvData.SetOrder("Order");
                    gvData.BestFitColumns();
                    //ModifyGrid();

                    intYearID = uYearSemester.YearIDEditValueInt32;
                    intSemester = uYearSemester.SemesterEditValueInt32;
                    strYearText = uYearSemester.YearEditValueText;
                    btnPrint.Enabled = mnuItemExportToExcel.Enabled = dtbData.Rows.Count > 0;                                        
                    btnSave.Enabled = mnuItemSave.Enabled = false;                                                               
                }
                catch (Exception objEx)
                {
                    ErrorManager.Error(objEx);
                    SYS_ErrorLogService.Write(Enums.ActionType.View, "frmReRegister->LoadData", objEx, 0);
                }
            }
        }
     
        private void ModifyGrid()
        {
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gvData.Columns)
            {

                switch (col.FieldName)
                {
                    case "Schoolfees":
                        col.DisplayFormat.FormatString = "#,###";
                        col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        break;
                }

            }
        }

        /// <summary>
        /// Save dữ liệu
        /// </summary>
        private bool SaveData()
        {
            SIM_ReRegister item = new SIM_ReRegister();
            item.BeginTransaction();

            foreach(DataRow drw in dtbData.Rows)
            {                
                if (drw["IsEdit"].ToString() == "1")
                {
                    SIM_ReRegister item2 = new SIM_ReRegister(); // PHẢI DÙNG CÁI MỚI ĐỂ HÔNG BỊ TRƯỜNG HỢP RÁC TỪ ITEM KHÁC CÒN LẠI khi drw  null thì nó còn data cũ
                    item2.IDB = item.IDB;

                    if (item2.Parse(drw))
                    {
                        if (item2.ReRegisterID == null)// thêm mới
                        {
                            if (Convert.ToBoolean(drw["IsLearningRegister"]) || item2.IsExamRegister) // nếu có check 1 trong 2
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
                            // nếu là edit mà hông còn check chọn thi hay học lại thì xoá
                            if (!Convert.ToBoolean(drw["IsLearningRegister"]) && !item2.IsExamRegister)
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
        
        #endregion

        #region Form Actions

        private void frmReRegister_Load(object sender, EventArgs e)
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
            if (strFieldName == "IsLearningRegister")
            {                
                
                if(Convert.ToBoolean(drw["IsLearningRegister"]))
                {
                drw["IsExamRegister"] = 0; // mỗi lần chỉ đăng ký 1 thứ thi hoặc học
                drw["Money"] = txtLearningMoney.EditValueInt32;                
                drw["YearID"] = intYearID;
                drw["Semester"] = intSemester;
                drw["YearText"] = strYearText;
                }
            }
            else if (strFieldName == "IsExamRegister")
            {              
                if (Convert.ToBoolean(drw["IsExamRegister"]))
                {
                    drw["IsLearningRegister"] = 0; // mỗi lần chỉ đăng ký 1 thứ thi hoặc học
                    drw["Money"] = txtExamMoney.EditValueInt32;
                    drw["YearID"] = intYearID;
                    drw["Semester"] = intSemester;
                    drw["YearText"] = strYearText;
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
                int intYearID1 = Convert.ToInt32(drw["YearID1"]);
                int intSemester1 = Convert.ToInt32(drw["Semester1"]);

                // khong can rang buoc thoi diem
                /*
                if (gvData.FocusedColumn.FieldName == "IsExamRegister")
                    // chỉ đăng ký thi lại khi xét môn ở niên kì, cùng niên kỳ đăng ký
                    e.Cancel = !(intYearID1 == intYearID && intSemester1 == intSemester);

                // chỉ đăng ký học lại khi trước ít nhất 1 kỳ
                else if (gvData.FocusedColumn.FieldName == "IsLearningRegister")
                    e.Cancel = !(intYearID1 < intYearID || (intYearID1 == intYearID && intSemester1 < intSemester));
                 */ 
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // print danh sach du dieu kien tot nghiep
            DataTable dtbData = (gvData.DataSource as DataView).Table;
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData, "Report/StudentManager/Learning/Leaning_HocLai_QC14.repx", false);

            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);

            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pClass", uClass.ClassIDEditValue);
            frm.SetParameter("pSemester", uYearSemester.SemesterEditValue);
            frm.SetParameter("pYearID", uYearSemester.YearEditValueText);

            frm.Show();  
            
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

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            if (uClass.ClassIDEditValue == null)
            {
                MessageManager.Warning("Vui lòng chọn lớp để in danh sách nợ môn!");
                return;
            }
            SIM_ReRegister objAll = new SIM_ReRegister();
            DataTable dtb = objAll.GetDataTable("SIM_ReviewGraduationExamALL", "@ClassID", uClass.ClassIDEditValue);
            dtb.DefaultView.RowFilter = "SubjectDebitList <> ''";
            dtb = dtb.DefaultView.ToTable();
            if (dtb != null || dtb.Rows.Count > 0)
            {
                string sReport = "Report/StudentManager/Learning/Leaning_DSHocLai.repx";
                SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtb, sReport, false);
                frm.SetParameter("pCourse", "KHỐI " + uClass.TrainingLevelName.ToUpper() + " " + uClass.CourseName.ToUpper());
                frm.SetParameter("pSpecialBranch", "NGHỀ " + uClass.SpecialBranchName.ToUpper() + " (LỚP:" + uClass.ClassName.ToUpper() + ")");
                frm.Show();
            }
            else
            {
                MessageManager.Warning("Lỗi in danh sách nợ môn");
            }
        }
    }
}