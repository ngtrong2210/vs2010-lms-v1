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
using Service;
using GeneralObject;
using GeneralService;
using System.Xml;
using SystemObject;

namespace StudentManager.Student
{
    public partial class frmStudent : FormBase, IForm
    {
        #region Consts

        public const string PERMISSION_ADD = "SIM_Student_Add";
        public const string PERMISSION_DELETE = "SIM_Student_Delete";
        public const string PERMISSION_EDIT = "SIM_Student_Edit";
        public const string PERMISSION_VIEW = "SIM_Student_View";
        public const string PERMISSION_ORDERINDEX_EDIT = "SIM_Student_OrderIndex_Edit";
        public const string PERMISSION_STATUS_FOR_FAILED_EDIT = "SIM_Student_EditStatusForFailed"; // Có quyền bảo lưu hoặc gỡ bảo lưu sinh viên

        #endregion

        #region Variables

        bool bolIsEditing = false; // dang edit hay khong
        SIM_Student itemStudentEditing = new SIM_Student(); // record đang edit
        string strServerPath_StudentImage = "";
        string strLocalFilePath_StudentImage = ""; // file hinh dang chon         
        bool bolAllowSaveOrderIndex = false; // có quyền save thứ tự sv
        bool bolAllowEditStatusForFailed = false; // có quyền thay đổi bảo lưu sinh viên
        bool bolIsRefresh = false;

        DataTable dtbClassSubject;

        DataTable dtbData;

        #endregion

        #region IForm Members

        private static frmStudent _instance = null;

        public static frmStudent Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmStudent();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmStudent()
        {
            InitializeComponent();
        }

        #region Support Functions

        private void CheckPermission()
        {
            // Kiểm tra quyền
            mnuItemAdd.Enabled = btnAdd.Enabled = UserSession.HasPermission(PERMISSION_ADD);
            mnuItemEdit.Text = btnEdit.Text = UserSession.HasPermission(PERMISSION_EDIT) ? "Sửa" : "Xem";

            uClassID_Search.ScienceFilter = UserSession.GetScienceFilter(PERMISSION_VIEW); // quyền xem trên khoa nào
            gvData.RowFilter = uClassID_Search.ScienceFilter; // lọc lại lưới cho quyền view luôn

            bolAllowSaveOrderIndex = UserSession.HasPermission(PERMISSION_ORDERINDEX_EDIT);
            bolAllowEditStatusForFailed = UserSession.HasPermission(PERMISSION_STATUS_FOR_FAILED_EDIT);
            mnuItemQuickUpdateStatus.Enabled = UserSession.HasPermission(PERMISSION_EDIT);
        }

        public void LoadReferenceData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadReferenceData));
            else
            {
                if (bolIsRefresh)
                {
                    uVillageH.RefrehData();
                    uClassID_Search.RefrehData();
                    uClass21.RefrehData();
                    uYearSemester.RefrehData();

                    SystemService.SYS_SettingService.HaveNewData = true;
                    GeneralService.GEN_EthnicityService.HaveNewData = true;
                    GeneralService.GEN_ReligionService.HaveNewData = true;
                    GeneralService.GEN_AreaService.HaveNewData = true;
                    GEN_PreferentialObjectService.HaveNewData = true;
                    GEN_PreferentialObjectService.HaveNewData = true;
                    SIM_StudentPositionService.HaveNewData = true;
                }
                else
                {
                    uVillageH.InitData();
                    uClassID_Search.InitData();
                    uClass21.InitData();
                    uYearSemester.InitData();
                }

                strServerPath_StudentImage = SystemService.SYS_SettingService.GetStringValue("ServerPath_StudentImage"); // đường dẫn hình
                GeneralService.GEN_EthnicityService.InitLookUpEdit(lookupEthnicityID);
                GeneralService.GEN_ReligionService.InitLookUpEdit(lookupReligionID);
                GeneralService.GEN_AreaService.InitLookUpEdit(lookupAreaID);
                GEN_PreferentialObjectService.InitLookUpEdit(lookupPreferentialObjectID);
                GEN_PreferentialObjectService.InitLookUpEdit(lookupPreferentialObjectID2);
                SIM_StudentPositionService.InitLookUpEdit(lookupStudentPositionID);


                uClass21.ClassFilter = "ClassType = 0";
                uClassID_Search.ClassFilter = "ClassType = 0";
                // neu co using GeneralService ở trên cùng thì viết vầy GEN_EthnicityService.InitLookUpEdit() là dc
                uImage.TypeObject = TypeObject.Student;
            }
        }

        /// <summary>
        /// Làm mới dữ liệu trong các combobox hay này nọ...
        /// </summary>
        public void RefreshReferenceData()
        {
            //SIM_ProvinceService.HaveNewData = true;
            LoadReferenceData();
        }

        public void LoadData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadData));
            else
            {

                bool? bolIsInDorm = null;
                if (cbxIsInDorm.SelectedIndex == 1)
                    bolIsInDorm = false;
                else if (cbxIsInDorm.SelectedIndex == 2)
                    bolIsInDorm = true;

                int? intSubType = null;
                if (cbxSubTypeSearch.SelectedIndex > 0)
                    intSubType = cbxSubTypeSearch.SelectedIndex - 1;

                DateTime? dtm = null;
                if (dtmMonth.EditValueDateTime != null)
                {
                    dtm = dtmMonth.EditValueDateTime;
                    dtm = new DateTime(dtm.Value.Year, dtm.Value.Month, 1);
                }
                SIM_Student objStudent = new SIM_Student();

                dtbData = objStudent.Search(
                                            "@CourseID", uClassID_Search.IsRegulation43 ? null : uClassID_Search.CourseIDEditValue,
                                            "@BranchID", uClassID_Search.IsRegulation43 ? null : uClassID_Search.BranchEditValue,
                                            "@TrainingLevelID", uClassID_Search.IsRegulation43 ? null : uClassID_Search.TrainingLevelIDEditValue,
                                            "@TrainingType", uClassID_Search.IsRegulation43 ? null : uClassID_Search.TrainingTypeEditValue,
                                            "@ScienceID", uClassID_Search.IsRegulation43 ? null : uClassID_Search.ScienceIDEditValue,
                                            "@ClassID", uClassID_Search.IsRegulation43 ? null : uClassID_Search.ClassIDEditValue,
                                            "@ClassSubjectID", uClassID_Search.IsRegulation43 ? lookupClassSubjectID.EditValue : null, // theo lớp học phần tính chỉ
                                            "@StudentCode", txtStudentCode_Search.Text,
                                            "@Fullname", txtFullName_Search.TextTrim,
                                            "@FullNameEn", DCore.Filter.FilterVietkey(txtFullName_Search.Text),
                                            "@Status", uStudentStatus2.EditValueInt32,
                                            "@IsInDorm", bolIsInDorm,
                                            "@StartAt", dtm,
                                            "@SubType", intSubType);

                //update tieng anh
                //string strSQL = "";
                //foreach (DataRow drw in dtbData.Rows)
                //{
                //    strSQL += " update SIM_Student Set FullnameEn ='" + DCore.Filter.FilterVietkey(drw["StudentFirstName"].ToString() + " " + drw["StudentLastName"].ToString()).Replace("'","''") + "', " +
                //            "BirthDateTextEn ='" + Libs.MyConvert.ToDateTextEn(Libs.MyConvert.ToInt32(drw["BirthDay"]), Libs.MyConvert.ToInt32(drw["BirthMonth"]), Libs.MyConvert.ToInt32(drw["BirthYear"])) + "' " +
                //            " Where StudentID =" + drw["StudentID"].ToString() + " \r\n";
                //}

                if (dtbData != null)
                {
                    gcData.DataSource = dtbData;
                    SystemService.SYS_GridColumnService.InitGridColumn(gvData, "SIM_Student", bolIsRefresh); // khởi tạo hiện thị cột trên lưới
                    // set order
                    gvData.SetOrder("Order");
                    gvData.SearchAndSelectRow(SIM_Student.C_StudentID, itemStudentEditing.StudentID); // chọn dòng đang edit

                    mnuItemEdit.Enabled = btnEdit.Enabled = gvData.GetFocusedDataRow() != null;
                    mnuItemSave_GroupSmallClassRegister.Enabled = true;
                    btnPrint.Enabled = mnuItemExportToExcel.Enabled = dtbData.Rows.Count > 0;
                    mnuItemSaveOrderIndex.Enabled = btnPrint.Enabled && bolAllowSaveOrderIndex;
                    mnuItemCopyStudent.Enabled = btnPrint.Enabled && btnAdd.Enabled; // có quyền thêm thì dc copy
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
            itemStudentEditing = new SIM_Student();
            itemStudentEditing.BeginTransaction();
            itemStudentEditing.DeletedUser = UserSession.Username;

            int[] arrRowIndex = gvData.GetSelectedRows();
            for (int i = arrRowIndex.Length - 1; i >= 0; i--)
            {
                DataRow drw = gvData.GetDataRow(arrRowIndex[i]);

                // kiểm tra xem có quyền xóa lớp trên khoa này không
                if (UserSession.HasPermission(PERMISSION_DELETE, drw["ScienceID"].ToString()))
                {
                    itemStudentEditing.StudentID = Convert.ToInt64(drw["StudentID"]);
                    if (itemStudentEditing.Delete())
                    {
                        gvData.DeleteRow(arrRowIndex[i]);
                    }
                    else
                    {
                        ErrorManager.Error("Việc xoá thông tin bị lỗi!");
                        break; // ngưng vòng for
                    }
                }
                else
                    MessageManager.Warning("Bạn không có quyền xóa lớp '" + drw["ClassID"].ToString() + "'!");

            }
            itemStudentEditing.CommitTransaction();
            return true;
        }

        /// <summary>
        /// Load dữ liệu vào tab edit
        /// </summary>        
        private void ShowEditForm(long? studentID)
        {
            if (studentID != null)
            {
                uClass21.ScienceFilter = ""; // khi view thì khỏi cần lọc lại. Để tránh tình trạng edit qua khoa khoác thì kiểm tra lúc save edit

                itemStudentEditing = new SIM_Student();
                itemStudentEditing.StudentID = studentID;
                if (!itemStudentEditing.Get()) // edit thì load lên
                {
                    ErrorManager.Error("Việc lấy thông tin chỉnh sửa bị lỗi!");
                    // string str = itemStudentEditing.ErrorException.Message;
                    return;
                }

                uClass21.SpecialBranchIDEditValue = itemStudentEditing.SpecialBranchID; // set theo hồ sơ tuyển sinh chuyển qua
                uClass21.CourseIDEditValue = itemStudentEditing.CourseID;

                uClass21.ClassIDEditValue = itemStudentEditing.ClassID; // gán lớp trước để lấy dc mã khoa, xem có quyền edit không
                btnSaveEdit.Enabled = UserSession.HasPermission(PERMISSION_EDIT, uClass21.ScienceIDEditValue); // có quyền edit hay không                    
                uClass21.ReadOnly = true;
                uStudentStatus1.ReadOnly = true;
                //txtStudentCode.ReadOnly = true;
            }
            else
            {
                uClass21.ScienceFilter = UserSession.GetScienceFilter(PERMISSION_ADD); // lọc lại khoa thêm quyền thêm mới

                itemStudentEditing = new SIM_Student(); // thêm mới thì khởi tạo
                btnSaveEdit.Enabled = true; // luôn luôn true vì đã hiện dc nút thêm mới thì luôn thêm mới dc                    
                uClass21.ReadOnly = false;
                uStudentStatus1.ReadOnly = false;
                //txtStudentCode.ReadOnly = false;
            }

            // gán giá trị vào form
            txtStudentCode.Text = itemStudentEditing.StudentCode;
            txtStudentFirstName.Text = itemStudentEditing.StudentFirstName;
            txtStudentLastName.Text = itemStudentEditing.StudentLastName;
            if (itemStudentEditing.Gender == true)
                rdoMale.Checked = true;
            else
                rdoFemale.Checked = true;
            if (itemStudentEditing.BirthDay != null)
            {
                string strDay = "00" + itemStudentEditing.BirthDay.ToString();
                txtBirthDay.Text = strDay.Substring(strDay.Length - 2, 2);

            }
            else txtBirthDay.Text = "";

            if (itemStudentEditing.BirthMonth != null)
            {
                string strMonth = "00" + itemStudentEditing.BirthMonth.ToString();
                txtBirthMonth.Text = strMonth.Substring(strMonth.Length - 2, 2);
            }
            else
                txtBirthMonth.Text = "";

            txtBirthPlace.Text = itemStudentEditing.BirthPlace;
            txtBirthYear.Text = Convert.ToString(itemStudentEditing.BirthYear);

            txtPersonID.Text = itemStudentEditing.PersonID;
            txtPersionIDPlace.Text = itemStudentEditing.PersionIDPlace;
            dtmPersionIDDate.EditValue = itemStudentEditing.PersionIDDate;
            txtBudget.EditValue = itemStudentEditing.Budget;
            txtFunds.EditValue = itemStudentEditing.Funds;
            lookupEthnicityID.EditValue = itemStudentEditing.EthnicityID;
            lookupReligionID.EditValue = itemStudentEditing.ReligionID;

            #region Hộ khẩu thường trú

            txtLiveAddress.Text = itemStudentEditing.LiveAddress;
            uVillageH.ProvinceEditValue = itemStudentEditing.LiveProvinceID;
            uVillageH.DistrictEditValue = itemStudentEditing.LiveDistrictID;
            uVillageH.WardEditValue = itemStudentEditing.LiveWardID;
            uVillageH.VillageEditValue = itemStudentEditing.LiveVillageID;

            #endregion

            lookupAreaID.EditValue = itemStudentEditing.AreaID;

            lookupPreferentialObjectID.EditValue = itemStudentEditing.PreferentialObjectID;
            lookupPreferentialObjectID2.EditValue = itemStudentEditing.PreferentialObjectID2;
            lookupComponentFamilyID.EditValue = itemStudentEditing.ComponentFamilyID;

            txtContactAddress.Text = itemStudentEditing.ContactAddress;
            txtTel.Text = itemStudentEditing.Tel;
            txtEmail.Text = itemStudentEditing.Email;


            txtFatherAddress.Text = itemStudentEditing.FatherAddress;
            txtFatherJob.Text = itemStudentEditing.FatherJob;
            txtFatherName.Text = itemStudentEditing.FatherName;

            txtMortherAddress.Text = itemStudentEditing.MortherAddress;
            txtMortherJob.Text = itemStudentEditing.MortherJob;
            txtMortherName.Text = itemStudentEditing.MortherName;

            cbxGraduationLevel.Text = itemStudentEditing.GraduationLevel;
            txtGraduationSchool.Text = itemStudentEditing.GraduationSchool;
            if (itemStudentEditing.GraduationYear != null)
                txtGraduationYear.Text = itemStudentEditing.GraduationYear.ToString();
            else
                txtGraduationYear.Text = "";

            calcMark1.EditValue = itemStudentEditing.Mark1;
            calcMark2.EditValue = itemStudentEditing.Mark2;
            calcMark3.EditValue = itemStudentEditing.Mark3;
            txtExamStudentNumber.Text = itemStudentEditing.ExamStudentNumber;

            chkIsReceived.Checked = itemStudentEditing.IsReceived;
            chkIsReceiveCandidateForm.Checked = itemStudentEditing.IsReceiveCandidateForm;
            chkIsReceiveDiploma.Checked = itemStudentEditing.IsReceiveDiploma;
            chkIsReceiveHealthCer.Checked = itemStudentEditing.IsReceiveHealthCer;
            chkIsReceiveImage.Checked = itemStudentEditing.IsReceiveImage;
            chkIsReceiveLearningForm.Checked = itemStudentEditing.IsReceiveLearningForm;
            chkIsReceiveNotifyCopy.Checked = itemStudentEditing.IsReceiveNotifyCopy;
            chkIsReceivePersonCer.Checked = itemStudentEditing.IsReceivePersonCer;
            chkIsReceiveSubjectMark.Checked = itemStudentEditing.IsReceiveSubjectMark;
            chkIsReceiveTempDiploma.Checked = itemStudentEditing.IsReceiveTempDiploma;
            chkIsReceiveTranscripts.Checked = itemStudentEditing.IsReceiveTranscripts;
            chkIsReceiveWorkingCer.Checked = itemStudentEditing.IsReceiveWorkingCer;
            chkIsReceiveMoney.Checked = itemStudentEditing.IsReceiveMoney;

            chkIsUnionCard.Checked = itemStudentEditing.IsUnionCard;
            chkIsUnionBook.Checked = itemStudentEditing.IsUnionBook;
            txtDescription.Text = itemStudentEditing.Description;

            dtmRealLearningDate.EditValue = itemStudentEditing.RealLearningDate;
            lookupStudentPositionID.EditValue = itemStudentEditing.StudentPositionID; // cán sự lớp

            uStudentStatus1.EditValue = itemStudentEditing.Status;
            if (itemStudentEditing.SubType != null)
                cbxSubType.SelectedIndex = itemStudentEditing.SubType.Value;

            chkIsInDorm.Checked = itemStudentEditing.IsInDorm;
            dtmLiveFromDate.EditValue = itemStudentEditing.LiveFromDate;
            dtmLiveToDate.EditValue = itemStudentEditing.LiveToDate;
            dtmReceiveDate.EditValue = itemStudentEditing.ReceivedDate;
            txtTempClass1.Text = itemStudentEditing.TempClass1;
            txtTempClass2.Text = itemStudentEditing.TempClass2;
            txtTempClass3.Text = itemStudentEditing.TempClass3;


            uImage.ObjectID = studentID;
            uImage.LoadData(); // load hình cho sinh viên (nếu có)
            bolIsEditing = true;
            tcData.SelectedTabPage = tpDetail;
            txtStudentCode.Focus();
        }

        /// <summary>
        /// Kiểm tra tính hợp lệ của dữ liệu ở tab edit
        /// </summary>
        /// <returns></returns>
        private bool IsValidEditForm()
        {
            if (txtStudentCode.Text.Trim() == "")
            {
                MessageManager.Warning("Bạn phải nhập mã sinh viên!");
                txtStudentCode.Focus();
                return false;
            }

            if (txtBirthYear.TextTrim == "")
            {
                MessageManager.Warning("Bạn phải nhập năm sinh!");
                txtBirthYear.Focus();
                return false;
            }

            if (txtStudentFirstName.Text.Trim() == "")
            {
                MessageManager.Warning("Bạn phải nhập tên sinh viên!");
                txtStudentFirstName.Focus();
                return false;
            }
            if (uClass21.ClassIDEditValue == null)
            {
                MessageManager.Warning("Bạn phải chọn lớp học!");
                uClass21.Focus();
                return false;
            }
            if (uStudentStatus1.EditValue == null)
            {
                MessageManager.Warning("Sinh viên chưa chọn trạng thái");
                uStudentStatus1.Focus();
                return false;
            }

            CheckStudent();
            if (lblCheckResult.Text == "Mã sinh viên đã tồn tại!")
            {
                MessageManager.Warning("Mã sinh viên đã tồn tại!");
                txtStudentCode.Focus();
                return false;
            }
            if (lblCheckResult.ForeColor == Color.Red)
            {
                if (MessageManager.Confirm("Bạn vẫn muốn lưu hồ sơ này?") != System.Windows.Forms.DialogResult.Yes)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Save dữ liệu ở tab edit
        /// </summary>
        private bool SaveEditForm()
        {
            itemStudentEditing.StudentCode = txtStudentCode.Text;
            itemStudentEditing.StudentFirstName = txtStudentFirstName.TextTrim;
            itemStudentEditing.StudentLastName = txtStudentLastName.TextTrim;
            if (rdoMale.Checked == true)
            {
                itemStudentEditing.Gender = true;
            }
            else
            {
                itemStudentEditing.Gender = false;
            }

            itemStudentEditing.ClassID = uClass21.ClassIDEditValue;

            #region ngày sinh  nơi sinh

            itemStudentEditing.BirthDay = txtBirthDay.EditValueInt32;
            itemStudentEditing.BirthMonth = txtBirthMonth.EditValueInt32;
            itemStudentEditing.BirthYear = txtBirthYear.EditValueInt32;
            itemStudentEditing.BirthPlace = txtBirthPlace.Text;

            string strBirthDateText = "";
            if (itemStudentEditing.BirthYear != null)
            {
                strBirthDateText = itemStudentEditing.BirthYear.ToString();
                if (itemStudentEditing.BirthMonth != null)
                {
                    string strMonth = "00" + itemStudentEditing.BirthMonth.ToString();
                    strBirthDateText = strMonth.Substring(strMonth.Length - 2, 2) + "/" + strBirthDateText;
                    if (itemStudentEditing.BirthDay != null)
                    {
                        string strDay = "00" + itemStudentEditing.BirthDay.ToString();
                        strBirthDateText = strDay.Substring(strDay.Length - 2, 2) + "/" + strBirthDateText;
                    }
                }
            }
            itemStudentEditing.BirthDateText = strBirthDateText;

            itemStudentEditing.FullnameEn = DCore.Filter.FilterVietkey(itemStudentEditing.StudentFirstName + " " + itemStudentEditing.StudentLastName); // En
            itemStudentEditing.BirthDateTextEn = Libs.MyConvert.ToDateTextEn(itemStudentEditing.BirthDay, itemStudentEditing.BirthMonth, itemStudentEditing.BirthYear);

            #endregion

            itemStudentEditing.PersionIDDate = dtmPersionIDDate.EditValueDate;
            itemStudentEditing.PersonID = txtPersonID.TextTrim;
            itemStudentEditing.PersionIDPlace = txtPersionIDPlace.TextTrim;

            itemStudentEditing.EthnicityID = lookupEthnicityID.EditValueString;
            itemStudentEditing.ReligionID = lookupReligionID.EditValueString;

            #region Hộ khẩu thường trú

            itemStudentEditing.LiveAddress = txtLiveAddress.Text;
            itemStudentEditing.LiveProvinceID = uVillageH.ProvinceEditValueString;
            itemStudentEditing.LiveDistrictID = uVillageH.DistrictEditValueString;
            itemStudentEditing.LiveWardID = uVillageH.WardEditValueString;
            itemStudentEditing.LiveVillageID = uVillageH.VillageEditValueString;

            #endregion

            itemStudentEditing.AreaID = lookupAreaID.EditValueString;
            itemStudentEditing.PreferentialObjectID = lookupPreferentialObjectID.EditValueString;
            itemStudentEditing.PreferentialObjectID2 = lookupPreferentialObjectID2.EditValueString;
            itemStudentEditing.ComponentFamilyID = lookupComponentFamilyID.EditValueString;
            itemStudentEditing.Budget = txtBudget.EditValueInt64;
            itemStudentEditing.Funds = txtFunds.EditValueInt64;
            itemStudentEditing.ContactAddress = txtContactAddress.Text;
            itemStudentEditing.Tel = txtTel.Text;
            itemStudentEditing.Email = txtEmail.TextTrim;

            itemStudentEditing.FatherAddress = txtFatherAddress.Text;
            itemStudentEditing.FatherJob = txtFatherJob.Text;
            itemStudentEditing.FatherName = txtFatherName.Text;
            itemStudentEditing.MortherAddress = txtMortherAddress.Text;
            itemStudentEditing.MortherJob = txtMortherJob.Text;
            itemStudentEditing.MortherName = txtMortherName.Text;

            itemStudentEditing.GraduationLevel = cbxGraduationLevel.Text;
            itemStudentEditing.GraduationSchool = txtGraduationSchool.TextTrim;
            itemStudentEditing.GraduationYear = txtGraduationYear.EditValueInt32;


            // chỗ này chưa đúng, Việt che lại
            itemStudentEditing.Mark1 = calcMark1.EditValueInt32;
            itemStudentEditing.Mark2 = calcMark2.EditValueInt32;
            itemStudentEditing.Mark3 = calcMark3.EditValueInt32;
            itemStudentEditing.ExamStudentNumber = txtExamStudentNumber.TextTrim;

            itemStudentEditing.IsReceiveCandidateForm = chkIsReceiveCandidateForm.Checked;
            itemStudentEditing.IsReceived = chkIsReceived.Checked;
            itemStudentEditing.IsReceiveDiploma = chkIsReceiveDiploma.Checked;
            itemStudentEditing.IsReceiveHealthCer = chkIsReceiveHealthCer.Checked;
            itemStudentEditing.IsReceiveImage = chkIsReceiveImage.Checked;
            itemStudentEditing.IsReceiveLearningForm = chkIsReceiveLearningForm.Checked;
            itemStudentEditing.IsReceiveNotifyCopy = chkIsReceiveNotifyCopy.Checked;
            itemStudentEditing.IsReceivePersonCer = chkIsReceivePersonCer.Checked;
            itemStudentEditing.IsReceiveSubjectMark = chkIsReceiveSubjectMark.Checked;
            itemStudentEditing.IsReceiveTempDiploma = chkIsReceiveTempDiploma.Checked;
            itemStudentEditing.IsReceiveTranscripts = chkIsReceiveTranscripts.Checked;
            itemStudentEditing.IsReceiveWorkingCer = chkIsReceiveWorkingCer.Checked;
            itemStudentEditing.IsReceiveMoney = chkIsReceiveMoney.Checked;
            itemStudentEditing.IsUnionCard = chkIsUnionCard.Checked;
            itemStudentEditing.IsUnionBook = chkIsUnionBook.Checked;
            itemStudentEditing.IsOkCollection = true; // đã edit từ sinh viên thì lúc nào cũng là trúng tuyển

            itemStudentEditing.Status = uStudentStatus1.EditValueInt32;
            itemStudentEditing.SubType = cbxSubType.SelectedIndex; // loại dc trợ cấp. XH or CS
            itemStudentEditing.IsInDorm = chkIsInDorm.Checked; // là sinh viên nội trú
            itemStudentEditing.LiveFromDate = dtmLiveFromDate.EditValueDate;
            itemStudentEditing.LiveToDate = dtmLiveToDate.EditValueDate;


            itemStudentEditing.Description = txtDescription.Text;
            itemStudentEditing.RealLearningDate = dtmRealLearningDate.EditValueDate;
            itemStudentEditing.StudentPositionID = lookupStudentPositionID.EditValueInt32; // cán sự lớp

            itemStudentEditing.TempClass1 = txtTempClass1.TextTrim;
            itemStudentEditing.TempClass2 = txtTempClass2.TextTrim;
            itemStudentEditing.TempClass3 = txtTempClass3.TextTrim;

            if (itemStudentEditing.StudentID == null) // add new
            {
                //itemStudentEditing.StudentID = txtStudentID.TextTrim; 
                itemStudentEditing.CreatedUser = UserSession.Username;
                itemStudentEditing.OrderIndex = 0; // mặc định khi thêm mới thứ tự
                itemStudentEditing.ReceivedDate = DateTime.Now;
                if (itemStudentEditing.Add())
                {
                    string strActionLog = "Mã sinh viên: " + txtStudentCode.TextTrim + "\r\n" +
                                    "Họ tên: " + txtStudentFirstName.TextTrim + " " + txtStudentLastName.TextTrim;
                    new SystemObject.SYS_ActionLog().WriteActionLog("Thêm hồ sơ sinh viên", strActionLog, SystemObject.ActionLogType.ADD, 1, UserSession.Username);

                }
                else
                {
                    ErrorManager.Error("Việc cập nhật dữ liệu bị lỗi!" + itemStudentEditing.ErrorException.Message);
                    return false;
                }
            }
            else
            {
                // kiểm tra thử xem có phải thuộc lớp dc edit hông. phòng khi đang view lại chọn lớp khác save
                if (UserSession.HasPermission(PERMISSION_EDIT, uClass21.ScienceIDEditValue))
                {
                    itemStudentEditing.UpdatedUser = UserSession.Username;
                    itemStudentEditing.ReceivedDate = dtmReceiveDate.EditValueDate;
                    if (itemStudentEditing.Update())
                    {

                        string strActionLog = "Mã sinh viên: " + txtStudentCode.TextTrim + "\r\n" +
                                    "Họ tên: " + txtStudentFirstName.TextTrim + " " + txtStudentLastName.TextTrim;
                        new SystemObject.SYS_ActionLog().WriteActionLog("Sửa hồ sơ sinh viên", strActionLog, SystemObject.ActionLogType.EDIT, 1, UserSession.Username);

                    }
                    else
                    {
                        ErrorManager.Error("Việc cập nhật dữ liệu bị lỗi!" + itemStudentEditing.ErrorException.Message);
                        return false;
                    }
                }
                else
                {
                    MessageManager.Warning("Bạn không có quyền sửa lớp trên khoa '" + uClass21.ScienceName + "'!");
                    return false;
                }
            }
            //update lại hình nếu có
            if (!uImage.UpdateObjectID(itemStudentEditing.StudentID, itemStudentEditing.IDB))
            {
                ErrorManager.Error("Việc cập nhật hình bị lỗi!");
                return false;
            }
            // tự động tạo dự kiến thu sinh viên nếu chưa có

            AccountObject.ACC_StudentReceiptPlan objStudentReceiptPlan = new AccountObject.ACC_StudentReceiptPlan();
            string strRs = objStudentReceiptPlan.AutoCreateForStudent(itemStudentEditing.StudentID.Value, UserSession.Username);
            return true;
        }

        private void CheckStudent()
        {
            lblCheckResult.Text = "Đang kiểm tra...";
            SIM_Student obj = new SIM_Student();
            string str = obj.CheckForEdit("@FullName", txtStudentFirstName.TextTrim + " " + txtStudentLastName.TextTrim,
                            "@BirthDay", txtBirthDay.Text,
                            "@BirthMonth", txtBirthMonth.Text,
                            "@BirthYear", txtBirthYear.Text,
                            "@StudentCode", txtStudentCode.TextTrim,
                            "@OldStudentCode", itemStudentEditing.StudentCode);
            if (str != "")
            {
                lblCheckResult.Text = str;
                lblCheckResult.ForeColor = Color.Red;
            }
            else
            {
                lblCheckResult.Text = "Hợp lệ!";
                lblCheckResult.ForeColor = Color.Blue;
            }
        }

        private void LoadSubjectSearch()
        {
            if (uClassID_Search.IsRegulation43)
            {
                lookupClassSubjectID.Visible = true;
                uYearSemester.Visible = true;
                if (uClassID_Search.SpecialBranchSubjectIDEditValue != null)
                {
                    SIM_Class_Subject obj = new SIM_Class_Subject();
                    dtbClassSubject = obj.SearchList43("@SpecialBranchSubjectID", uClassID_Search.SpecialBranchSubjectIDEditValue,
                                                        "@YearID", uYearSemester.YearIDEditValue,
                                                        "@Semester", uYearSemester.SemesterEditValue,
                                                        "@OfficeID", uClassID_Search.OfficeIDEditValue);

                    DataRow drw = dtbClassSubject.NewRow();
                    dtbClassSubject.Rows.InsertAt(drw, 0); // thêm dòng trống  
                    lookupClassSubjectID.InitData(dtbClassSubject, "--Chọn--", "ClassSubjectID", "ClassName",
                        "ClassName", "Tên nhóm", "ClassShortName", "Tên viết tắt", "GroupSmallClass", "Thứ tự nhóm", "UnitText", "ĐVHT", "TheoryQuantity", "LT", "PracticeQuantity", "TH");
                }
                else
                    lookupClassSubjectID.DataSource = null;
            }
            else
            {
                lookupClassSubjectID.Visible = false;
                uYearSemester.Visible = false;
            }
        }

        #endregion

        #region Form Actions

        private void frmStudent_Load(object sender, EventArgs e)
        {
            new Thread(LoadReferenceData).Start();
            //new Thread(LoadData).Start();
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
                SIM_StudentService.HaveNewData = true; //Đánh dấu là danh mục này đã có sự thay đổi, để khi GetAll nó load lại
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataRow drw = gvData.GetFocusedDataRow();
            if (drw != null)
            {
                ShowEditForm(Convert.ToInt64(drw[SIM_Student.C_StudentID]));
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
                    SIM_StudentService.HaveNewData = true;  //Đánh dấu là danh mục này đã có sự thay đổi, để khi GetAll nó load lại
                }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            bolIsEditing = false;
            tcData.SelectedTabPage = tpList;
        }

        private void mnuItemRefresh_Click(object sender, EventArgs e)
        {
            bolIsRefresh = true;
            RefreshReferenceData();
            frmStudent_Load(sender, e);
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

        private void frmStudent_KeyDown(object sender, KeyEventArgs e)
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            new Thread(LoadData).Start();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // print Sinh vien
            string dDatePrint = "";
            DataTable dtbData1 = dtbData.Copy();
            dtbData1.DefaultView.RowFilter = "(Status1=1 Or Status1=2) and IsSelected = 1";
            dtbData1 = dtbData1.DefaultView.ToTable();
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData1, "Report/StudentManager/Student/Student_DanhSachSVDangHoc.repx", false);
            dDatePrint = DateTime.Now.ToString("dd/MM/yyyy");
            frm.SetParameter("pDatePrint", dDatePrint);
            frm.Show();
        }

        private void mnuItemSave_Click(object sender, EventArgs e)
        {
            SIM_Student obj = new SIM_Student();
            obj.BeginTransaction();

            for (int i = 0; i < gvData.RowCount; i++)
            {
                obj.StudentID = Convert.ToInt64(gvData.GetDataRow(i)["StudentID"]);
                obj.OrderIndex = i;
                if (!obj.UpdateOrderIndex())
                {
                    ErrorManager.Error("Việc cập nhật thông tin bị lỗi!");
                    return;
                }
            }
            obj.CommitTransaction();
            MessageManager.Info("Đã cập nhật thứ tự sinh viên!");
        }

        private void mnuItem1_Click(object sender, EventArgs e)
        {
            // print Sinh vien                        
            DataTable dtb = dtbData.Copy();
            dtb.DefaultView.RowFilter = "IsSelected = 1";
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtb, "Report/StudentManager/Student/Student_InDanhSachSinhVien.repx", false);

            frm.Show();
        }

        private void mnuItem2_Click(object sender, EventArgs e)
        {
            // print Sinh vien    
            DataTable dtb = dtbData.Copy();
            dtb.DefaultView.RowFilter = "IsSelected = 1";
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtb, "Report/StudentManager/Student/Student_InDanhSachSinhVien2.repx", false);

            frm.Show();
        }

        private void mnuItemViewHistoryPrintCer_Click(object sender, EventArgs e)
        {
            DataRow drw = gvData.GetFocusedDataRow();
            HistoryPrintCer.frmHistoryPrintCer frm = HistoryPrintCer.frmHistoryPrintCer.Instance;
            if (drw != null)
                frm.StudentCode = drw["StudentCode"].ToString();
            else
                frm.StudentCode = "";
            Global.FormManager.Load("StudentManager.HistoryPrintCer.frmHistoryPrintCer", false);
        }

        private void mnuItemAddHistoryPrintCer_Click(object sender, EventArgs e)
        {
            DataRow drw = gvData.GetFocusedDataRow();
            long? lngStudentID = null;
            if (drw != null)
                lngStudentID = Convert.ToInt64(drw["StudentID"]);

            HistoryPrintCer.frmHistoryPrintCerDetail frm = HistoryPrintCer.frmHistoryPrintCerDetail.Instance;
            frm.LoadData(null, lngStudentID);
            frm.ShowDialog();
        }

        private void mnuItemPrintNotInDorm_Click(object sender, EventArgs e)
        {
            // print Sinh vien                        
            DataTable dtb = dtbData.Copy();
            dtb.DefaultView.RowFilter = "IsInDorm = 0 and IsSelected =1";
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtb, "Report/StudentManager/Student/Student_DanhSachNgoaiTru.repx", false);

            frm.Show();
        }

        private void mnuItemPrintInDorm_Click(object sender, EventArgs e)
        {
            // print Sinh vien  nội trú                     
            DataTable dtb = dtbData.Copy();
            dtb.DefaultView.RowFilter = "IsSelected =1";
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtb, "Report/StudentManager/Student/Student_DanhSachNoiTru.repx", false);

            frm.Show();
        }

        private void txtStudentCode_Leave(object sender, EventArgs e)
        {
            //new Thread(CheckStudent).Start();
        }

        private void mnuItemView_Click(object sender, EventArgs e)
        {
            DataRow drw = gvData.GetFocusedDataRow();
            if (drw != null)
            {
                frmStudentInfor frmView = frmStudentInfor.Instance;
                frmView.LoadData(null, Convert.ToInt64(drw[SIM_Student.C_StudentID]));
                frmView.ShowDialog();
            }
        }

        private void mnuItemCheckAll_Click(object sender, EventArgs e)
        {
            gvData.CheckAll();
        }

        private void mnuItemUnCheckAll_Click(object sender, EventArgs e)
        {
            gvData.UnCheckAll();
        }

        private void uClassID_Search_Regulation43CheckChanged(object sender, EventArgs arg)
        {
            LoadSubjectSearch();
        }

        private void uClassID_Search_SpecialBranchSubjectChanged(object sender, EventArgs arg)
        {
            LoadSubjectSearch();
        }

        private void uClassID_Search_OfficeChanged(object sender, EventArgs arg)
        {
            LoadSubjectSearch();
        }

        private void uClassID_Search_EditValueChanged(object sender, EventArgs arg)
        {
            LoadSubjectSearch();
        }

        private void uYearSemester_EditValueChanged(object sender, EventArgs arg)
        {
            // lọc lại môn học khung cho 43
            //uClassID_Search.YearID = uYearSemester.YearIDEditValueInt32;
            //uClassID_Search.Semester = uYearSemester.SemesterEditValueInt32;
            //uClassID_Search.FilterSpecialBranchSubject();
            // load lại mã môn học lớp
            //LoadSubjectSearch();
        }

        private void mnuItemCopyStudent_Click(object sender, EventArgs e)
        {
            string strStudentIDList = gvData.GetIDListSelected("StudentID");

            //nếu không check chọn thì lấy thêm dòng đang actived
            if (strStudentIDList == "")
            {
                DataRow drw = gvData.GetFocusedDataRow();
                if (drw != null)
                    strStudentIDList = drw["StudentID"].ToString();
            }

            if (strStudentIDList != "")
            {
                frmCopyStudent.Instance.LoadData(strStudentIDList);
                frmCopyStudent.Instance.ShowDialog();
                //if (frmCopyStudent.Instance.IsOk)
                //    LoadData();
            }
            else
                MessageManager.Warning("Bạn chưa check chọn sinh viên!");
        }

        private void mnuItemQuickUpdateStatusSelfDroppedOut_Click(object sender, EventArgs e)
        {
            if (dtbData == null)
            {
                MessageManager.Warning("Bạn chưa tải danh sách sinh viên!");
                return;
            }
            DataRow[] arrSelectedRows = dtbData.Select("IsSelected = 1");
            if (arrSelectedRows.Length == 0)
            {
                MessageManager.Warning("Bạn chưa tích chọn sinh viên!");
                return;
            }
            if (MessageManager.Confirm(String.Format("Bạn thực sự muốn cập nhật {0} sinh viên sang trạng thái 'Tự thôi học'?", arrSelectedRows.Length)) != DialogResult.Yes)
                return;
            SIM_Student objStudent = new SIM_Student();
            objStudent.BeginTransaction();
            objStudent.Status = 7;
            objStudent.UpdatedUser = UserSession.Username;
            int intUpdatedCount = 0;
            int intDeniedCount = 0;
            foreach (DataRow drw in arrSelectedRows)
            {
                if (!UserSession.HasPermission(PERMISSION_EDIT, drw["ScienceID"].ToString()))
                {
                    intDeniedCount++;
                    continue;
                }
                objStudent.StudentID = Convert.ToInt64(drw[SIM_Student.C_StudentID]);
                if (!objStudent.UpdateStatus())
                {
                    ErrorManager.Error("Việc cập nhật trạng thái sinh viên bị lỗi!");
                    return;
                }
                intUpdatedCount++;
            }
            objStudent.CommitTransaction();
            if (intUpdatedCount == 0)
            {
                MessageManager.Warning("Bạn không có quyền cập nhật các sinh viên đã tích chọn!");
                return;
            }
            SIM_StudentService.HaveNewData = true;
            new Thread(LoadData).Start();
            if (intDeniedCount > 0)
                MessageManager.Info(String.Format("Đã cập nhật {0} sinh viên sang trạng thái 'Tự thôi học'. Có {1} sinh viên không được cập nhật do không có quyền.", intUpdatedCount, intDeniedCount));
            else
                MessageManager.Info(String.Format("Đã cập nhật {0} sinh viên sang trạng thái 'Tự thôi học'!", intUpdatedCount));
        }

        private void mau09ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // print Sinh vien  mở lớp ngắn hạn                  
            DataTable dtb = dtbData.Copy();
            dtb.DefaultView.RowFilter = "IsSelected =1";
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtb, "Report/StudentManager/Student/Student_DSMoLop_NganHan.repx", false);

            frm.Show();
        }

        private void mau10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // print Sinh vien  nội trú                     
            DataTable dtb = dtbData.Copy();
            dtb.DefaultView.RowFilter = "IsSelected =1";
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtb, "Report/StudentManager/Student/Student_DSQuyetToanHocNghe_NganHan.repx", false);

            frm.Show();
        }

        private void mau13ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // print Sinh vien  nội trú                     
            DataTable dtb = dtbData.Copy();
            dtb.DefaultView.RowFilter = "IsSelected =1";
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtb, "Report/StudentManager/Student/Student_DSTuyenMoiNghe_NganHan.repx", false);
            frm.SetParameter("pMonth", "THÁNG " + dtmMonth.EditValueDateTime.Value.Month + "/" + dtmMonth.EditValueDateTime.Value.Year);
            frm.Show();
        }

        private void mau14ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // print Sinh vien                        
            DataTable dtb = new DataTable();
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtb, "Report/StudentManager/Student/Student_InDanhSachSinhVien_Mau14.repx", false);

            frm.Show();
        }

        private void mau18ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // print Sinh vien                        
            DataTable dtb = new DataTable();
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtb, "Report/StudentManager/Student/Student_InDanhSachSinhVien_Mau18.repx", false);

            frm.Show();
        }



        private void mnuItemEditData_Click(object sender, EventArgs e)
        {
            SIM_Student obj = new SIM_Student();
            if (obj.UpdateFullnamEn())
            {
                MessageManager.Info("Hiệu chỉnh thông tin thành công");
            }
            else
            {
                MessageManager.Error(obj.ErrorException.ToString());
            }
            #region tạm thời không dùng
            //DataTable dtb = obj.Search();
            //foreach (DataRow drw in dtb.Rows)
            //{
            //    obj.StudentID = Convert.ToInt64(drw["StudentID"]);
            //    obj.FullnameEn = DCore.Filter.FilterVietkey(drw["StudentFirstName"].ToString() + " " + drw["StudentLastName"].ToString());
            //    obj.UpdateFullnamEn();
            //}
            #endregion
        }

        private void ItemMenu_Click(object sender, EventArgs e)
        {
            int iLDN = 0; int iLDCN = 0; int iLDK = 0; int iCM = 0;
            DataTable dtb = dtbData.Copy();
            dtb.DefaultView.RowFilter = "IsSelected =1";
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtb, "Report/StudentManager/Student/Student_DSDangKyHocVanhHoa.repx", false);
            //foreach (DataRow r in dtb.Rows)
            //{
            //    if (Convert.ToInt32(r["PreferentialObjectID"]) == 10)
            //        iLDN += 1;
            //    if (Convert.ToInt32(r["PreferentialObjectID"]) == 15)
            //        iLDCN += 1;
            //    if (Convert.ToInt32(r["PreferentialObjectID"]) == 16)
            //        iLDK += 1;
            //    if (Convert.ToInt32(r["PreferentialObjectID"]) == 1 || Convert.ToInt32(r["PreferentialObjectID"]) == 3)
            //        iCM += 1;
            //}
            //frm.SetParameter("pLDN", iLDN);
            //frm.SetParameter("pLDCN", iLDCN);
            //frm.SetParameter("pLDK", iLDK);
            //frm.SetParameter("pCM", iCM);
            frm.Show();
        }

        private void mnuItemSave_GroupSmallClassRegister_Click(object sender, EventArgs e)
        {
            if (MessageManager.Confirm("Bạn thực sự muốn lưu lại thứ tự nhóm cho các dòng đã sửa?") != System.Windows.Forms.DialogResult.Yes)
                return;

            int count = 0;

            SIM_Student obj = new SIM_Student();
            obj.BeginTransaction();

            for (int i = 0; i < gvData.RowCount; i++)
            {
                DataRow drw = gvData.GetDataRow(i);
                if (Convert.ToBoolean(drw["IsEdit"]))
                {

                    obj.StudentID = Convert.ToInt64(drw["StudentID"]);
                    obj.GroupSmallClassRegister = Libs.MyConvert.ToInt32(drw["GroupSmallClassRegister"]);
                    if (obj.GroupSmallClassRegister == null)
                        obj.GroupSmallClassRegister = 0;
                    if (!obj.UpdateGroupSmallClassRegister())
                    {
                        ErrorManager.Error("Việc cập nhật thông tin bị lỗi!");
                        return;
                    }
                    count++;
                }
            }
            obj.CommitTransaction();
            MessageManager.Info(string.Format("Đã cập nhật thứ tự nhóm cho {0} dòng dữ liệu!", count));
        }

        private void gvData_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRow drw = gvData.GetDataRow(e.RowHandle);
            if (drw != null)
            {
                string col = e.Column.FieldName;
                if (col == "GroupSmallClassRegister")
                {
                    drw["IsEdit"] = true;
                }
            }
        }

    }
}