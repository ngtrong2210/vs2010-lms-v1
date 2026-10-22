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
using DevExpress.XtraGrid.Views.BandedGrid;
using System.Collections;
namespace StudentManager.Learning
{
    public partial class frmRegisterLogicClass : FormBase, IForm
    {
        #region Consts


        public const string PERMISSION_EDIT = "frmRegisterLogicClass_Edit";
        public const string PERMISSION_VIEW = "frmRegisterLogicClass_View";
        #endregion

        #region Variables

        bool bolIsRefresh = false;

        DataTable dtbData; // danh sách dữ liệu sinh viên trong lớp
        DataTable dtbStudent; // danh sách sinh viên đăng ký học lại        
        DataTable dtbLogicClass; // Môn học lớp theo môn đăng ký để filter lớp lại theo môn.
        string strClassIDList = ""; // lọc theo danh sách lớp của môn đang chọn

        int intYearID;
        int intSemester;
       
        #endregion

        #region IForm Members

        private static frmRegisterLogicClass _instance = null;

        public static frmRegisterLogicClass Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmRegisterLogicClass();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmRegisterLogicClass()
        {
            InitializeComponent();
        }

        #region Support Functions

        private void CheckPermission()
        {
            // Kiểm tra quyền                        
            gvData.OptionsBehavior.Editable = UserSession.HasPermission(PERMISSION_EDIT);
            //mnuItemSave.Enabled = btnSave.Enabled = UserSession.HasPermission(PERMISSION_EDIT);
        }

        public void LoadReferenceData()
        {
            uScienceCourseTypeLevel.InitData();
            uSpecialBranch.InitData();
            uYearSemester.InitData();
        }

        private void GetListClassID()
        {
            // get list class
            strClassIDList = "";
            for (int i = 0; i < clbClass.ItemCount; i++)
            {
                if (clbClass.GetItemChecked(i))
                {
                    strClassIDList += "," + clbClass.GetItemValue(i).ToString();
                }
            }
            if (strClassIDList != "")
                strClassIDList += ",";
        }

        private bool IsValidData()
        {
            if (
                uScienceCourseTypeLevel.TrainingLevelIDEditValue == null ||
                uScienceCourseTypeLevel.TrainingTypeEditValue == null)
            {
                MessageManager.Warning("Bạn phải chọn bậc - loại đào tạo!");
                return false;
            }
            //if (!uSpecialBranch.IsValidData())
            //    return false;
            if (!uYearSemester.IsValidData())
                return false;
            return true;
        }

        public void LoadData()
        {
            intYearID = uYearSemester.YearIDEditValueInt32.Value;
            intSemester = uYearSemester.SemesterEditValueInt32.Value;

            // lấy ds lớp trước
            // get ds lớp học (lớp vật lý)-------------------------------------------------------------------------------------
            SIM_Class objClass = new SIM_Class();
            DataTable dtbClass = objClass.SearchSimpleList(
                                    "@ScienceID", uScienceCourseTypeLevel.ScienceIDEditValue,
                                    "@CourseID", uScienceCourseTypeLevel.CourseIDEditValue,
                                    "@TrainingLevelID", uScienceCourseTypeLevel.TrainingLevelIDEditValue,
                                    "@TrainingType", uScienceCourseTypeLevel.TrainingTypeEditValue,
                                    "@SpecialBranchID", uSpecialBranch.SpecialBranchEditValue,                                                                        
                                    "@ClassType", 0);                                    
            if (dtbClass == null)
            {
                ErrorManager.Error("Việc lấy danh sách lớp học bị lỗi!");
                return;
            }
            clbClass.DataSource = dtbClass;
            clbClass.ValueMember = "ClassID";
            clbClass.DisplayMember = "ClassID";
            clbClass.CheckAll();
            GetListClassID();



            // Lấy ds sinh viên của danh sách lớp-------------------------------------------------------------------------------            
            dtbStudent = objClass.GetDataTable("SIM_Student_SearchForRegisterLogicClass",
                                    "@ListClassID", strClassIDList,
                                    "@YearID", intYearID,
                                    "@Semester", intSemester);
            if (dtbStudent == null)
            {
                ErrorManager.Error("Việc lấy danh sách sinh viên bị lỗi!");
                return;
            }
            gcStudent.DataSource = dtbStudent;
            SystemService.SYS_GridColumnService.InitGridColumn(gvStudent, "SIM_Student_SearchForRegisterLogicClass",bolIsRefresh);

            // lấy danh sách lớp logic -----------------------------------------------------------------------------            
            dtbLogicClass = objClass.GetDataTable("SIM_Class_SearchLogicClass",
                                            //"@ScienceID", uScienceCourseTypeLevel.ScienceIDEditValue,
                                            //"@CourseID", uScienceCourseTypeLevel.CourseIDEditValue,
                                            //"@TrainingLevelID", uScienceCourseTypeLevel.TrainingLevelIDEditValue,
                                            //"@TrainingType", uScienceCourseTypeLevel.TrainingTypeEditValue,
                                            //"@SpecialBranchID", uSpecialBranch.SpecialBranchEditValue,                                                                        
                                            "@YearID", intYearID,
                                            "@Semester", intSemester);
            if (dtbLogicClass == null)
            {
                ErrorManager.Error("Việc lấy danh sách lớp ảo bị lỗi!");
                return;
            }
            gcLogicClass.DataSource = dtbLogicClass;
            SystemService.SYS_GridColumnService.InitGridColumn(gvLogicClass, "SIM_Class_SearchLogicClass",bolIsRefresh);



            // Lấy ds sinh viên đã đăng ký lớp học phần-----------------------------------------------------------------------
            // ở niên học học kì này
            // Vì cùng niên, kì thì không cho đăng ký nữa
            if (dtbLogicClass.Rows.Count > 0)
            {
                dtbData = objClass.GetDataTable("SIM_RegisterLogicClass_SearchForRegister",
                                                    "@YearID", intYearID,
                                                    "@Semester", intSemester);
                if (dtbData == null)
                {
                    ErrorManager.Error("Việc lấy danh sách sinh viên đã đăng ký bị lỗi!");
                    return;
                }
                gcData.DataSource = dtbData;
                SystemService.SYS_GridColumnService.InitGridColumn(gvData, "SIM_RegisterLogicClass_SearchForRegister",bolIsRefresh);

                FilterLogicClassData();
                FilterStudentData();
                FilterRegisterData();

                gvStudent.BestFitColumns();
                gvLogicClass.BestFitColumns();
                gvData.BestFitColumns();

                mnuItemExportToExcel.Enabled = dtbData.Rows.Count > 0; // load lại thì không cần save 
                btnSave.Enabled = mnuItemSave.Enabled = false;
                bolIsRefresh = false;
            }
            else
            {
                MessageManager.Warning("Không có lớp ảo nào để đăng ký! Thử kiểm tra danh mục lớp hoặc phân môn học lớp cho lớp ảo vào niên kỳ đang chọn!");
            }

        }

        private void FilterStudentData()
        {
            if (dtbData != null)
            {
                if (strClassIDList != "")
                {
                    string strFilter = strClassIDList;
                    strFilter = strFilter.Replace(",", "' or ClassID='");
                    strFilter = strFilter.Substring(4);
                    strFilter = strFilter.Substring(0, strFilter.Length - 12);
                    dtbStudent.DefaultView.RowFilter = "IsDel = 0 and (" + strFilter + ")";
                }
                else
                    dtbStudent.DefaultView.RowFilter = "StudentID='-1'"; // an het sinh vien

                btnDeleteAll.Enabled = mnuItemDeleteAll.Enabled = dtbData.DefaultView.Count > 0;
                btnAddAll.Enabled = mnuItemAddAll.Enabled = dtbStudent.DefaultView.Count > 0 && (gvLogicClass.SelectedRowsCount > 0 || dtbLogicClass.Select("IsSelected =1").Length > 0);
            }
        }

        private void FilterLogicClassData()
        {
            if (dtbLogicClass != null)
            {
                // lọc lại lớp học phần theo chuyên ngành và khoá hoặc tất cả
                if (chkShowAllLogicClass.Checked)
                    dtbLogicClass.DefaultView.RowFilter = "";
                else
                {
                    string strFilter = "";
                    if (uSpecialBranch.SpecialBranchEditValue != null)
                        strFilter += " and SpecialBranchID ='" + uSpecialBranch.SpecialBranchEditValue + "'";
                    if (uScienceCourseTypeLevel.CourseIDEditValue != null)
                        strFilter += " and CourseID='" + uScienceCourseTypeLevel.CourseIDEditValue + "'";
                    if (strFilter != "")
                        dtbLogicClass.DefaultView.RowFilter = strFilter.Substring(4);
                }
            }
        }

        private void FilterRegisterData()
        {
            if (dtbData != null)
            {
                DataRow drw = gvLogicClass.GetFocusedDataRow();
                if (drw != null)
                {
                    dtbData.DefaultView.RowFilter = "IsDel = 0 and LogicClassID='" + drw["ClassID"].ToString() + "'"; // hiển thị sv đăng ký lớp ảo đó ra
                }
                else
                    dtbData.DefaultView.RowFilter = "StudentID='-1'"; // ẩn hết sinh viên nếu không đang chọn lớp học phần nào
            }
        }

        /// <summary>
        /// Save dữ liệu ở tab edit
        /// </summary>
        private bool SaveData()
        {
            SIM_RegisterLogicClass item = new SIM_RegisterLogicClass();
            item.BeginTransaction();
          
            foreach(DataRow drw in dtbData.Rows)
            {                
                if (drw["RegisterLogicClassID"].ToString() != "" && drw["IsDel"].ToString() == "1") // dữ liệu cũ, và bị đánh dấu xoá thì xoá
                {
                    SIM_RegisterLogicClass item2 = new SIM_RegisterLogicClass(); // PHẢI DÙNG CÁI MỚI ĐỂ HÔNG BỊ TRƯỜNG HỢP RÁC TỪ ITEM KHÁC CÒN LẠI khi drw  null thì nó còn data cũ
                    item2.IDB = item.IDB;
                    item2.RegisterLogicClassID = Convert.ToInt64(drw["RegisterLogicClassID"]);                  
                    if (!item2.Delete())
                    {
                        ErrorManager.Error("Việc gỡ bỏ đăng ký lớp ảo bị lỗi!");
                        return false;
                    }
                }
                else if (drw["RegisterLogicClassID"].ToString() != "" && drw["IsEdit"].ToString() == "1") // dữ liệu cũ, và đánh dấu sửa thì sửa
                {
                    SIM_RegisterLogicClass item2 = new SIM_RegisterLogicClass(); 
                    item2.IDB = item.IDB;
                    item2.RegisterLogicClassID = Convert.ToInt64(drw["RegisterLogicClassID"]);
                    
                    item2.StudentID = Convert.ToInt64(drw["StudentID"]);
                    item2.ClassID = drw["LogicClassID"].ToString();
                    item2.YearID = intYearID;
                    item2.Semester = intSemester;
                    item2.GroupSmallClassRegister = Libs.MyConvert.ToInt32(drw["GroupSmallClassRegister"]);
                    if (item2.GroupSmallClassRegister == null)
                        item2.GroupSmallClassRegister = 0;

                    item2.CreatedUser = drw["CreatedUser"].ToString();
                    item2.UpdatedUser = UserSession.Username;                    

                    if (!item2.Update())
                    {
                        ErrorManager.Error("Việc cập nhật bị lỗi!");
                        return false;
                    }                    
                }
                else if (drw["RegisterLogicClassID"].ToString() == "" && drw["IsDel"].ToString() == "0") // mới và không phải xoá
                {
                    SIM_RegisterLogicClass item2 = new SIM_RegisterLogicClass(); // PHẢI DÙNG CÁI MỚI ĐỂ HÔNG BỊ TRƯỜNG HỢP RÁC TỪ ITEM KHÁC CÒN LẠI khi drw  null thì nó còn data cũ
                    item2.IDB = item.IDB;

                    item2.StudentID = Convert.ToInt64(drw["StudentID"]);
                    item2.ClassID = drw["LogicClassID"].ToString();
                    item2.YearID = intYearID;
                    item2.Semester = intSemester;
                    item2.GroupSmallClassRegister = Libs.MyConvert.ToInt32(drw["GroupSmallClassRegister"]);
                    if (item2.GroupSmallClassRegister == null)
                        item2.GroupSmallClassRegister = 0;

                    item2.CreatedUser = UserSession.Username;
                    
                    if (!item2.Add())
                    {
                        ErrorManager.Error("Việc đăng ký học phần bị lỗi!");
                        return false;
                    }
                }
            }

            item.CommitTransaction();
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

        private void CheckAllStudentData(bool bolValue)
        {
            for(int i=0;i<gvStudent.RowCount; i++)
            {                
                DataRow drw = gvStudent.GetDataRow(i);                                
                        drw["IsSelected"] = bolValue;
            }
        }

        private void CheckAllRegisterData(bool bolValue)
        {
            for(int i=0;i<gvData.RowCount; i++)
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
                if (isAddAll || Convert.ToBoolean(drw["IsSelected"]) || gvStudent.IsRowSelected(i))
                {
                    // Đánh dấu xoá ở dữ liệu ( không cần vì add liên tục sv đó cho nhiều lớp học phần khác nhau)
                    drw["IsSelected"] = false;
                    drw["IsDel"] = 1; // đã xoá ở lưới dữ liệu sv
                    
                    DataRow drwLogicClass = gvLogicClass.GetFocusedDataRow();
                        
                    DataRow[] rows = dtbData.Select("StudentID=" + drw["StudentID"].ToString()); // sinh viên                             

                    // có rồi thì bậc lại ở sinh viên và gán đúng lớp đang chọn
                    if (rows.Length > 0)
                    {
                        rows[0]["IsDel"] = 0;
                        rows[0]["IsEdit"] = 1;
                        rows[0]["LogicClassID"] = drwLogicClass["ClassID"];
                    }
                    else // chưa có thì thêm mới dòng ở đăng ký
                    {
                        DataRow drwNew = dtbData.NewRow();
                        drwNew["IsDel"] = 0;
                        drwNew["IsEdit"] = 1;
                        drwNew["IsSelected"] = false;
                        drwNew["StudentID"] = drw["StudentID"];
                        drwNew["StudentCode"] = drw["StudentCode"];
                        drwNew["StudentFirstName"] = drw["StudentFirstName"];
                        drwNew["StudentLastName"] = drw["StudentLastName"];
                        drwNew["GenderText"] = drw["GenderText"];
                        drwNew["BirthDateText"] = drw["BirthDateText"];
                        drwNew["ClassOfStudent"] = drw["ClassID"]; // lớp của sinh viên

                        drwNew["LogicClassID"] = drwLogicClass["ClassID"];                        

                        dtbData.Rows.Add(drwNew);
                    }                     
                }
            }            
            ShowButtonList();
            if (isAddAll)
                btnAddAll.Enabled = mnuItemAddAll.Enabled = false;
            btnAdd.Enabled = mnuItemAdd.Enabled = false;

            btnSave.Enabled = mnuItemSave.Enabled = true;
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
                if (isDelAll || Convert.ToBoolean(drw["IsSelected"]) || gvData.IsRowSelected(i))
                {
                    // Đánh dấu xoá ở đăng ký
                    drw["IsSelected"] = false;
                    drw["IsDel"] = 1; // đã xoá ở lưới dữ liệu


                    // thêm qua dữ liệu
                    DataRow[] rows = dtbStudent.Select("StudentID=" + drw["StudentID"].ToString());
                    // có rồi thì bậc lại ở dữ liệu
                    if (rows.Length > 0)
                    {
                        rows[0]["IsDel"] = 0;
                    }
                    else // chưa có thì thêm mới dòng ở sinh viên
                    {
                        DataRow drwNew = dtbStudent.NewRow();
                        drwNew["IsDel"] = 0;
                        drwNew["IsSelected"] = false;
                        drwNew["StudentID"] = drw["StudentID"];
                        drwNew["StudentCode"] = drw["StudentCode"];
                        drwNew["StudentFirstName"] = drw["StudentFirstName"];
                        drwNew["StudentLastName"] = drw["StudentLastName"];
                        drwNew["GenderText"] = drw["GenderText"];
                        drwNew["BirthDateText"] = drw["BirthDateText"];
                        drwNew["ClassID"] = drw["ClassOfStudent"]; // lớp của sinh viên để hiển thị                                                        
                        dtbStudent.Rows.Add(drwNew);
                    }
                }
            }
            ShowButtonList();
            if (isDelAll)
                btnDeleteAll.Enabled = mnuItemDeleteAll.Enabled = false;
            btnDelete.Enabled = mnuItemDelete.Enabled = false;
            btnSave.Enabled = mnuItemSave.Enabled = true;
        }

        private void ShowButtonList()
        {
            if (dtbStudent != null && dtbLogicClass != null)
            {
                btnAdd.Enabled = mnuItemAdd.Enabled = (gvStudent.SelectedRowsCount > 0 || dtbStudent.Select("IsSelected =1").Length > 0)
                    && (gvLogicClass.SelectedRowsCount > 0 || dtbLogicClass.Select("IsSelected =1").Length > 0);

                btnAddAll.Enabled = mnuItemAddAll.Enabled = gvStudent.RowCount > 0 && (gvLogicClass.SelectedRowsCount > 0 || dtbLogicClass.Select("IsSelected =1").Length > 0);
            }
            if (dtbData != null)
            {
                btnDelete.Enabled = mnuItemDelete.Enabled = gvData.SelectedRowsCount > 0 || dtbData.Select("IsSelected=1").Length > 0;
                btnDeleteAll.Enabled = mnuItemDeleteAll.Enabled = gvData.RowCount > 0;
            }
        }

        #endregion

        #region Form Actions

        private void frmRegisterLogicClass_Load(object sender, EventArgs e)
        {

            CheckPermission();
            SetToolTip();
            LoadReferenceData();
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
            FilterStudentData();            
        }

        private void gvData_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataRow drw = gvData.GetFocusedDataRow();
            if (drw != null)
            {
                btnDelete.Enabled = mnuItemDelete.Enabled = gvData.SelectedRowsCount > 0;
                drw["IsEdit"] = 1;
                btnSave.Enabled = mnuItemSave.Enabled = true;
            }
        }

        private void gvData_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            DataRow drw = gvData.GetDataRow(e.RowHandle);
            if (drw != null)
            {
                //if (drw["FinalSummary"].ToString() != "") // đã có điểm không thể gỡ bỏ
                //    e.Appearance.BackColor = Color.LightPink;
                //else
                {
                    if (drw["RegisterLogicClassID"].ToString() == "") // vừa mới thêm vào
                        e.Appearance.BackColor = Color.LightSkyBlue;                    
                }

            }
        }

        private void gvData_ShowingEditor(object sender, CancelEventArgs e)
        {
            //DataRow drw = gvData.GetDataRow(gvData.FocusedRowHandle);
            //if (drw != null)
            //{
            //    if (drw["FinalSummary"].ToString()!="" || drw["SubjectID"].ToString() =="") // nếu hông cho phép edit vì có điểm rồi hoặc hông phải đăng ký mà của chính lớp
            //        e.Cancel = true;
            //}
        }

        private void mnuItemCheckAll_Click(object sender, EventArgs e)
        {
            CheckAllRegisterData(true);
        }

        private void mnuItemUnCheckAll_Click(object sender, EventArgs e)
        {
            CheckAllRegisterData(false);
        }

        /// <summary>
        /// Chọn lại môn thì phải lọc lại sinh viên đang ký, chọn lại khoa bộ môn, lọc lại lớp học có học môn đó
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void lookupSubjectID_EditValueChanged(object sender, EventArgs arg)
        {
            FilterLogicClassData();
            FilterStudentData();
        }

        private void uYearSemester_EditValueChanged(object sender, EventArgs arg)
        {           
        }
               
        private void gvReRegister_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            btnAdd.Enabled = mnuItemAdd.Enabled =  gvStudent.SelectedRowsCount > 0;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (uYearSemester.IsValidData())
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

        

        private void mnuItemCheckAll1_Click(object sender, EventArgs e)
        {
            CheckAllStudentData(true);
        }

        private void mnuItemUnCheckAll1_Click(object sender, EventArgs e)
        {
            CheckAllStudentData(false);
        }

        private void cbxStudentTypeView_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterStudentData();
        }

        private void clbClass_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            GetListClassID();
            FilterStudentData();
        }

        private void chkShowAllLogicClass_CheckedChanged(object sender, EventArgs e)
        {
            FilterLogicClassData();
            FilterRegisterData();
            ShowButtonList();
        }

        private void gvStudent_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            ShowButtonList();
        }

        private void gvData_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            ShowButtonList();
        }

        private void gvClassSubject_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            ShowButtonList();
        }        

        private void gvClassSubject_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            FilterRegisterData();
            ShowButtonList();
        }
        
        #endregion

        private void frmRegisterLogicClass_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F1:
                    this.ShowToolTip();
                    break;

                case Keys.F3:
                    btnSearch_Click(sender, null);
                    break;
                //case Keys.F4:
                //    if (mnuItemDelete.Enabled)
                //        mnuItemDelete_Click(sender, null);
                //    break;
                case Keys.F5:
                    btnSearch_Click(sender, null);
                    break;
                case Keys.F7:
                    //btnPrint_Click(sender, null);
                    break;
                case Keys.F12:
                    uScienceCourseTypeLevel.Reset();
                    uSpecialBranch.Reset();
                    uYearSemester.Reset();
                    break;
            }
        }

        private void mnuItemRefresh1_Click(object sender, EventArgs e)
        {
            bolIsRefresh = true;
            btnSearch_Click(null, null);
        }

        private void mnuItemRefresh_Click(object sender, EventArgs e)
        {
            bolIsRefresh = true;
            btnSearch_Click(null, null);
        }
    }
}

