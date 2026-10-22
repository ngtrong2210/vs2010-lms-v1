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
    public partial class frmRegisterClassSubject43 : FormBase, IForm
    {
        #region Consts

        //public const string PERMISSION_ADD = "SIM_RegisterClassSubject43_Add";
        //public const string PERMISSION_DELETE = "SIM_RegisterClassSubject43_Delete";
        public const string PERMISSION_EDIT = "SIM_RegisterClassSubject43_Edit";
        public const string PERMISSION_VIEW = "SIM_RegisterClassSubject43_View";
        #endregion

        #region Variables
        
        DataTable dtbData; // danh sách dữ liệu sinh viên trong lớp
        DataTable dtbStudent; // danh sách sinh viên đăng ký học lại        
        DataTable dtbClassSubject; // Môn học lớp theo môn đăng ký để filter lớp lại theo môn.
        string strClassIDList = ""; // lọc theo danh sách lớp của môn đang chọn

        int intYearID;
        int intSemester;
       
        #endregion

        #region IForm Members

        private static frmRegisterClassSubject43 _instance = null;

        public static frmRegisterClassSubject43 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmRegisterClassSubject43();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmRegisterClassSubject43()
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

            // lấy ds lớp trước
            // get ds lớp học (lớp vật lý)-------------------------------------------------------------------------------------
            SIM_Class objClass = new SIM_Class();
            DataTable dtbClass = objClass.SearchSimpleList(
                                    "@SpecialBranchID", uSpecialBranch.SpecialBranchEditValue,
                                    "@TrainingLevelID", uScienceCourseTypeLevel.TrainingLevelIDEditValue,
                                    "@TrainingType", uScienceCourseTypeLevel.TrainingTypeEditValue,
                                    "@CourseID", uScienceCourseTypeLevel.CourseIDEditValue,
                                    "@ScienceID", uScienceCourseTypeLevel.ScienceIDEditValue,
                                    "@ClassType", 0,
                                    "@IsRegulation43", true);
                                    //"@RegulationID", 43); // qui chế tín chỉ là 43  (tạm thời như vậy, vì họ chưa thực sự là 43, vẫn là 22.
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
            SIM_Student objStudent = new SIM_Student();
            dtbStudent = objStudent.SearchSimpleList("@ListClassID", strClassIDList);
            if (dtbStudent == null)
            {
                ErrorManager.Error("Việc lấy danh sách sinh viên bị lỗi!");
                return;
            }
            gcStudent.DataSource = dtbStudent;
            Service.SYS_GridColumnService.InitGridColumn(gvStudent, "SIM_Student_Register43");

            // lấy danh sách lớp học phần -----------------------------------------------------------------------------
            // get nhóm học phần đã tạo
            SIM_Class_Subject objClassSubject = new SIM_Class_Subject();
            dtbClassSubject = objClassSubject.SearchForRegister43("@TrainingLevelID", uScienceCourseTypeLevel.TrainingLevelIDEditValue,
                                            "@TrainingType", uScienceCourseTypeLevel.TrainingTypeEditValue,
                                            "@YearID", uYearSemester.YearIDEditValue,
                                            "@Semester", uYearSemester.SemesterEditValue);
            if (dtbClassSubject == null)
            {
                ErrorManager.Error("Việc lấy danh sách lớp học phần bị lỗi!");
                return;
            }
            gcClassSubject.DataSource = dtbClassSubject;
            Service.SYS_GridColumnService.InitGridColumn(gvClassSubject, "SIM_Class_Subject_Register43");



            // Lấy ds sinh viên đã đăng ký lớp học phần-----------------------------------------------------------------------
            // ở niên học học kì này, hoặc ở bất kì học kì nào nếu đã đạt
            // Vì cùng niên, kì thì không cho đăng ký nữa, hoặc đã đạt ở kì nào đó rùi thì cũng ko cho đăng ký nữa
            string strSubjectListID = "";
            foreach (DataRow drw in dtbClassSubject.Rows)
                strSubjectListID += "," + drw["SubjectID"].ToString();
            if (strSubjectListID != "")
            {
                SIM_SubjectMark objSubjectMark = new SIM_SubjectMark();
                
                dtbData = objSubjectMark.SearchForRegister43("@SubjectListID", strSubjectListID + ",",
                                                            "@YearID", uYearSemester.YearIDEditValue,
                                                            "@Semester", uYearSemester.SemesterEditValue);
                if (dtbData == null)
                {
                    ErrorManager.Error("Việc lấy danh sách sinh viên đã đăng ký học phần bị lỗi!");
                    return;
                }
                gcData.DataSource = dtbData;
                Service.SYS_GridColumnService.InitGridColumn(gvData, "SIM_SubjectMark_Register43");

                FilterClassSubjectData();
                FilterStudentData();
                FilterSubjectMarkData();

                gvStudent.BestFitColumns();
                gvClassSubject.BestFitColumns();
                gvData.BestFitColumns();

                mnuItemExportToExcel.Enabled = dtbData.Rows.Count > 0; // load lại thì không cần save 
                btnSave.Enabled = mnuItemSave.Enabled = false;
            }
            else
            {
                MessageManager.Warning("Không có lớp học phần để đăng ký!");
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
                    dtbStudent.DefaultView.RowFilter = strFilter;
                }
                else
                    dtbStudent.DefaultView.RowFilter = "StudentID='-1'"; // an het sinh vien

                btnDeleteAll.Enabled = mnuItemDeleteAll.Enabled = dtbData.DefaultView.Count > 0;
                btnAddAll.Enabled = mnuItemAddAll.Enabled = dtbStudent.DefaultView.Count > 0 && (gvClassSubject.SelectedRowsCount > 0 || dtbClassSubject.Select("IsSelected =1").Length > 0);
            }
        }

        private void FilterClassSubjectData()
        {
            if (dtbClassSubject != null)
            {
                // lọc lại lớp học phần theo chuyên ngành và khoá hoặc tất cả
                if (chkShowAllClassSubject.Checked)
                    dtbClassSubject.DefaultView.RowFilter = "";
                else
                {
                    string strFilter = "";
                    if (uSpecialBranch.SpecialBranchEditValue != null)
                        strFilter += " and SpecialBranchID ='" + uSpecialBranch.SpecialBranchEditValue + "'";
                    if (uScienceCourseTypeLevel.CourseIDEditValue != null)
                        strFilter += " and CourseID='" + uScienceCourseTypeLevel.CourseIDEditValue + "'";
                    if (strFilter != "")
                        dtbClassSubject.DefaultView.RowFilter = strFilter.Substring(4);
                }
            }
        }

        private void FilterSubjectMarkData()
        {
            if (dtbData != null)
            {
                DataRow drw = gvClassSubject.GetFocusedDataRow();
                if (drw != null)
                {
                    dtbData.DefaultView.RowFilter = "IsDel = 0 and ClassSubjectID='" + drw["ClassSubjectID"].ToString() + "'"; // hiển thị sv đăng ký lớp học phần đó ra
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
            SIM_SubjectMark item = new SIM_SubjectMark();
            item.BeginTransaction();
          
            foreach(DataRow drw in dtbData.Rows)
            {                
                if (drw["SubjectMarkID"].ToString() != "" && drw["IsDel"].ToString() == "1") // dữ liệu cũ, và bị đánh dấu xoá thì xoá
                {
                    SIM_SubjectMark item2 = new SIM_SubjectMark(); // PHẢI DÙNG CÁI MỚI ĐỂ HÔNG BỊ TRƯỜNG HỢP RÁC TỪ ITEM KHÁC CÒN LẠI khi drw  null thì nó còn data cũ
                    item2.IDB = item.IDB;
                    item2.SubjectMarkID = Convert.ToInt64(drw["SubjectMarkID"]);                  
                    if (!item2.Delete())
                    {
                        ErrorManager.Error("Việc gỡ bỏ đăng ký học phần bị lỗi!");
                        return false;
                    }
                }
                else if (drw["SubjectMarkID"].ToString() != "" && drw["IsEdit"].ToString() == "1") // dữ liệu cũ, và đánh dấu sửa thì sửa
                {
                    SIM_SubjectMark item2 = new SIM_SubjectMark(); 
                    item2.IDB = item.IDB;
                    item2.SubjectMarkID = Convert.ToInt64(drw["SubjectMarkID"]);      
                    item2.StudentID = Convert.ToInt64(drw["StudentID"]);
                    item2.SubjectID = drw["SubjectID"].ToString();
                    item2.OrderLearning = 1; // đăng ký mới thì là lần học đầu tiên của môn này.                                                           
                    item2.ClassSubjectID = Convert.ToInt32(drw["ClassSubjectID"]);
                    item2.CreatedUser = drw["CreatedUser"].ToString();
                    item2.UpdatedUser = UserSession.Username;                    

                    // học phí tín chỉ
                    item2.Money = Convert.ToDecimal(drw["Money"]);
                    item2.IsPayment = Convert.ToBoolean(drw["IsPayment"]);

                    if (!item2.Update())
                    {
                        ErrorManager.Error("Việc cập nhật bị lỗi!");
                        return false;
                    }                    
                }
                else if (drw["SubjectMarkID"].ToString() == "" && drw["IsDel"].ToString() == "0") // mới và không phải xoá
                {
                    SIM_SubjectMark item2 = new SIM_SubjectMark(); // PHẢI DÙNG CÁI MỚI ĐỂ HÔNG BỊ TRƯỜNG HỢP RÁC TỪ ITEM KHÁC CÒN LẠI khi drw  null thì nó còn data cũ
                    item2.IDB = item.IDB;

                    item2.StudentID = Convert.ToInt64(drw["StudentID"]);
                    item2.SubjectID = drw["SubjectID"].ToString();
                    item2.OrderLearning = 1; // đăng ký mới thì là lần học đầu tiên của môn này.                                                           
                    item2.ClassSubjectID = Convert.ToInt32(drw["ClassSubjectID"]);
                    item2.CreatedUser = UserSession.Username;

                    // học phí tín chỉ
                    item2.Money = Convert.ToDecimal(drw["Money"]);
                    item2.IsPayment = Convert.ToBoolean(drw["IsPayment"]);

                    if (!item2.Add())
                    {
                        ErrorManager.Error("Việc đăng ký học phần bị lỗi!");
                        return false;
                    }

                    // cập nhật lại lần học môn này
                    if (!item2.UpdateIsOrderLearning())
                    {
                        ErrorManager.Error("Việc cập nhật lần học bị lỗi!");
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

        private void CheckAllSubjectMark(bool bolValue)
        {
            for(int i=0;i<gvData.RowCount; i++)
            {                
                DataRow drw = gvData.GetDataRow(i);                                
                if(drw["FinalSummary"].ToString()=="") // vầy mới là môn đăng ký học lại và chưa điểm
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
                    //drw["IsSelected"] = false;
                    //drw["IsDel"] = 1; // đã xoá ở lưới dữ liệu


                    // Quét từng môn học lớp để thêm qua dữ liệu sổ điểm
                    for (int j = 0; j < gvClassSubject.RowCount ; j++)
                    {
                        DataRow drwClassSubject = gvClassSubject.GetDataRow(j);
                        if (Convert.ToBoolean(drwClassSubject["IsSelected"]) || gvClassSubject.IsRowSelected(j))
                        {

                            DataRow[] rows = dtbData.Select("StudentID='" + drw["StudentID"].ToString() // sinh viên
                                    + "' And SubjectID='" + drwClassSubject["SubjectID"].ToString() + "'");// có đăng ký môn học này ở kì này rồi.       

                            // có rồi thì bậc lại ở sinh viên
                            if (rows.Length > 0)
                            {
                                rows[0]["IsDel"] = 0;
                            }
                            else // chưa có thì thêm mới dòng ở sinh viên
                            {
                                DataRow drwNew = dtbData.NewRow();
                                drwNew["IsDel"] = 0;
                                drwNew["IsSelected"] = false;
                                drwNew["StudentID"] = drw["StudentID"];
                                drwNew["StudentCode"] = drw["StudentCode"];
                                drwNew["StudentFirstName"] = drw["StudentFirstName"];
                                drwNew["StudentLastName"] = drw["StudentLastName"];
                                drwNew["GenderText"] = drw["GenderText"];
                                drwNew["BirthDateText"] = drw["BirthDateText"];
                                drwNew["ClassOfStudent"] = drw["ClassID"]; // lớp của sinh viên để hiển thị

                                drwNew["ClassSubjectID"] = drwClassSubject["ClassSubjectID"];
                                drwNew["SubjectID"] = drwClassSubject["SubjectID"];

                                // học phí 1 tín chỉ
                                drwNew["Money"] = drwClassSubject["TotalFee"]; // học phí có sẵn theo từng lớp học phần
                                drwNew["IsPayment"] = false;

                                dtbData.Rows.Add(drwNew);
                            }
                        }
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
                    if (drw["FinalSummary"].ToString() == "" && drw["SubjectID"].ToString() != "")
                    {

                        // Đánh dấu xoá ở sổ điểm đăng ký
                        drw["IsSelected"] = false;
                        drw["IsDel"] = 1; // đã xoá ở lưới dữ liệu


                        //// thêm qua dữ liệu
                        //DataRow[] rows = dtbStudent.Select("StudentID='" + drw["StudentID"].ToString()
                        //        + "' And SubjectID='" + drw["SubjectID"].ToString() + "'");

                        //// có rồi thì bậc lại ở dữ liệu
                        //if (rows.Length > 0)
                        //{
                        //    rows[0]["IsDel"] = 0;
                        //}
                        //else // chưa có thì thêm mới dòng ở sinh viên
                        //{
                        //    DataRow drwNew = dtbStudent.NewRow();
                        //    drwNew["IsDel"] = 0;
                        //    drwNew["IsSelected"] = false;
                        //    drwNew["StudentID"] = drw["StudentID"];
                        //    drwNew["StudentCode"] = drw["StudentCode"];
                        //    drwNew["StudentFirstName"] = drw["StudentFirstName"];
                        //    drwNew["StudentLastName"] = drw["StudentLastName"];
                        //    drwNew["GenderText"] = drw["GenderText"];
                        //    drwNew["BirthDateText"] = drw["BirthDateText"];
                        //    drwNew["ClassID"] = drw["ClassID"]; // lớp của sinh viên để hiển thị                            
                        //    drwNew["SubjectID"] = drw["SubjectID"];
                        //    dtbStudent.Rows.Add(drwNew);
                        //}
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
            if (dtbStudent != null && dtbClassSubject != null)
            {
                btnAdd.Enabled = mnuItemAdd.Enabled = (gvStudent.SelectedRowsCount > 0 || dtbStudent.Select("IsSelected =1").Length > 0)
                    && (gvClassSubject.SelectedRowsCount > 0 || dtbClassSubject.Select("IsSelected =1").Length > 0);

                btnAddAll.Enabled = mnuItemAddAll.Enabled = gvStudent.RowCount > 0 && (gvClassSubject.SelectedRowsCount > 0 || dtbClassSubject.Select("IsSelected =1").Length > 0);
            }
            if (dtbData != null)
            {
                btnDelete.Enabled = mnuItemDelete.Enabled = gvData.SelectedRowsCount > 0 || dtbData.Select("IsSelected=1").Length > 0;
                btnDeleteAll.Enabled = mnuItemDeleteAll.Enabled = gvData.RowCount > 0;
            }
        }

        #endregion

        #region Form Actions

        private void frmRegisterClassSubject43_Load(object sender, EventArgs e)
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
                if (drw["FinalSummary"].ToString() != "") // đã có điểm không thể gỡ bỏ
                    e.Appearance.BackColor = Color.LightPink;
                else
                {
                    if (drw["SubjectMarkID"].ToString() == "") // vừa mới thêm vào
                        e.Appearance.BackColor = Color.LightSkyBlue;                    
                }

            }
        }

        private void gvData_ShowingEditor(object sender, CancelEventArgs e)
        {
            DataRow drw = gvData.GetDataRow(gvData.FocusedRowHandle);
            if (drw != null)
            {
                if (drw["FinalSummary"].ToString()!="" || drw["SubjectID"].ToString() =="") // nếu hông cho phép edit vì có điểm rồi hoặc hông phải đăng ký mà của chính lớp
                    e.Cancel = true;
            }
        }

        private void mnuItemCheckAll_Click(object sender, EventArgs e)
        {
            CheckAllSubjectMark(true);
        }

        private void mnuItemUnCheckAll_Click(object sender, EventArgs e)
        {
            CheckAllSubjectMark(false);
        }

        /// <summary>
        /// Chọn lại môn thì phải lọc lại sinh viên đang ký, chọn lại khoa bộ môn, lọc lại lớp học có học môn đó
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void lookupSubjectID_EditValueChanged(object sender, EventArgs arg)
        {
            FilterClassSubjectData();
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

        private void chkShowAllClassSubject_CheckedChanged(object sender, EventArgs e)
        {
            FilterClassSubjectData();
            FilterSubjectMarkData();
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
            FilterSubjectMarkData();
            ShowButtonList();
        }
        
        #endregion

        private void frmRegisterClassSubject43_KeyDown(object sender, KeyEventArgs e)
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
    }
}

