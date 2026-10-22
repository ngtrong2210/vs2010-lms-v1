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

namespace StudentManager.Student
{
    public partial class frmStudentForCollection : FormBase,IForm
    {
        #region Consts

        public const string PERMISSION_ADD = "SIM_StudentForCollection_Add";
        public const string PERMISSION_DELETE = "SIM_StudentForCollection_Delete";
        public const string PERMISSION_EDIT = "SIM_StudentForCollection_Edit";
        public const string PERMISSION_VIEW = "SIM_StudentForCollection_View";
        public const string PERMISSION_EDIT_RECEIPT = "SIM_StudentForCollection_EditReceipt";


        #endregion

        #region Variables

        bool bolIsEditing = false; // dang edit hay khong
        SIM_Student itemStudentEditing = new SIM_Student(); // record đang edit
        string strServerPath_StudentImage = "";
        string strLocalFilePath_StudentImage = ""; // file hinh dang chon         
        
        DataTable dtbData;

        #endregion

        #region IForm Members

        private static frmStudentForCollection _instance = null;

        public static frmStudentForCollection Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmStudentForCollection();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmStudentForCollection()
        {
            InitializeComponent();
        }
        
        #region Support Functions

        private void CheckPermission()
        {
            // Kiểm tra quyền
            mnuItemAdd.Enabled = btnAdd.Enabled = UserSession.HasPermission(PERMISSION_ADD);
            mnuItemEdit.Text = btnEdit.Text = UserSession.HasPermission(PERMISSION_EDIT) ? "Sửa" : "Xem";

            //uClassID_Search.ScienceFilter = UserSession.GetScienceFilter(PERMISSION_VIEW); // quyền xem trên khoa nào
            //gvData.RowFilter = uClassID_Search.ScienceFilter; // lọc lại lưới cho quyền view luôn        

            btnStudentReceiptPlan.Enabled = btnReceipt.Enabled = btnReceipt5.Enabled = UserSession.HasPermission(PERMISSION_EDIT_RECEIPT); // thu tiền học phí hoặc lệ phí xt
        }

        public void LoadReferenceData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadReferenceData));
            else
            {
                strServerPath_StudentImage = SystemService.SYS_SettingService.GetStringValue("ServerPath_StudentImage"); // đường dẫn hình
                GeneralService.GEN_EthnicityService.InitLookUpEdit(lookupEthnicityID);
                GeneralService.GEN_ReligionService.InitLookUpEdit(lookupReligionID);                
                GeneralService.GEN_AreaService.InitLookUpEdit(lookupAreaID);

                uVillageH.InitData();

                GEN_PreferentialObjectService.InitLookUpEdit(lookupPreferentialObjectID);
                GEN_PreferentialObjectService.InitLookUpEdit(lookupPreferentialObjectID2);
                GEN_ComponentFamilyService.InitLookUpEdit(lookupComponentFamilyID);

                GEN_SourceInfoService.InitGridLookUpEdit(lookupSourceInfoID);
                
                uClassID_Search.ClassFilter = "ClassType = 0";
                uClass21.ClassFilter = "ClassType = 0";                
                uClassID_Search.InitData();
                uClass21.InitData();

                // neu co using GeneralService ở trên cùng thì viết vầy GEN_EthnicityService.InitLookUpEdit() là dc
                
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
                DateTime? dtmTo = null;
                if (dtmToDate.EditValue != null)
                    dtmTo = dtmToDate.EditValueDateTime.Value.AddDays(1);

                SIM_Student objStudent = new SIM_Student();

                bool? bolIsCollecting = null;
                if (chkIsCollecting.Checked)
                    bolIsCollecting = true;
                dtbData = objStudent.GetDataTable("SIM_Student_SearchForCollection",
                                            "@CourseID", uClassID_Search.CourseIDEditValue,
                                            "@BranchID", uClassID_Search.BranchEditValue,
                                            "@TrainingLevelID", uClassID_Search.TrainingLevelIDEditValue,
                                            "@TrainingType", uClassID_Search.TrainingTypeEditValue,
                                            "@ScienceID", uClassID_Search.ScienceIDEditValue,
                                            "@StudentCode", txtStudentCode_Search.Text,
                                            "@ClassID", uClassID_Search.ClassIDEditValue,
                                            "@FullNameEn", DCore.Filter.FilterVietkey( txtFullName_Search.Text),
                                            "@IsCollecting",bolIsCollecting,
                                            "@ReceiptSegmentGroupID_HP", AccountObject.ReceiptSegmentGroup.HocPhi,
                                            "@ReceiptSegmentGroupID_TS", AccountObject.ReceiptSegmentGroup.TuyenSinh,
                                            "@FromDate", dtmFromDate.EditValue,
                                            "@ToDate", dtmTo);
                if (dtbData != null)
                {
                    gcData.DataSource = dtbData;
                    SYS_GridColumnService.InitGridColumn(gvData, "SIM_StudentCollection"); // khởi tạo hiện thị cột trên lưới
                    // set order
                    gvData.SetOrder("Order");
                    gvData.SearchAndSelectRow(SIM_Student.C_StudentID, itemStudentEditing.StudentID); // chọn dòng đang edit

                    mnuItemEdit.Enabled = btnEdit.Enabled = gvData.GetFocusedDataRow() != null;
                    btnPrint.Enabled = mnuItemExportToExcel.Enabled = dtbData.Rows.Count > 0;                    
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
                //if (UserSession.HasPermission(PERMISSION_DELETE, drw["ScienceID"].ToString()))
                if (drw["ReceiptNo"].ToString() == "")
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
                    MessageManager.Warning("Hồ sơ '" + drw["StudentCode"].ToString() + "'đã tồn tại phiếu thu học phí '" + drw["ReceiptNo"].ToString() + "'nên không thể xoá!");
                //else
                //    MessageManager.Warning("Bạn không có quyền xóa lớp '" + drw["ClassID"].ToString() + "'!");

            }
            itemStudentEditing.CommitTransaction();
            return true;
        }

        /// <summary>
        /// Load dữ liệu vào tab edit
        /// </summary>        
        private void ShowEditForm(long?  studentID)
        {
            if (studentID != null)
            {               
                itemStudentEditing = new SIM_Student();
                itemStudentEditing.StudentID = studentID;
                if(!itemStudentEditing.Get()) // edit thì load lên
                {
                    ErrorManager.Error("Việc lấy thông tin chỉnh sửa bị lỗi!");                   
                    return;
                }
                

                btnSaveEdit.Enabled =  UserSession.HasPermission(PERMISSION_EDIT); // có quyền edit hay không   
                if (itemStudentEditing.Status > 0)
                    btnSaveEdit.Enabled = false;// nếu hồ sơ đã là HS thì ko cho sửa                                                                           
            }
            else
            {                
                itemStudentEditing = new SIM_Student(); // thêm mới thì khởi tạo
                btnSaveEdit.Enabled = true; // luôn luôn true vì đã hiện dc nút thêm mới thì luôn thêm mới dc                                          
            }

            // gán giá trị vào form    
            uClass21.Reset();
            uClass21.ClassIDEditValue = itemStudentEditing.ClassID;
            if (itemStudentEditing.ClassID == null || itemStudentEditing.ClassID == "")
            {
                uClass21.SpecialBranchIDEditValue = itemStudentEditing.SpecialBranchID;
                uClass21.CourseIDEditValue = itemStudentEditing.CourseID;
            }                       

            txtStudentCode.Text = itemStudentEditing.StudentCode;
            txtStudentFirstName.Text = itemStudentEditing.StudentFirstName;
            txtStudentLastName.Text = itemStudentEditing.StudentLastName  ;
            if (itemStudentEditing .Gender == true )
                rdoMale.Checked = true;
            else
                rdoFemale.Checked = true;
            if (itemStudentEditing.BirthDay != null)
            {
                string strDay = "00" + itemStudentEditing.BirthDay.ToString();
                txtBirthDay.Text = strDay.Substring(strDay.Length - 2, 2);
            }
            else
                txtBirthDay.Text = "";

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
            chkIsOkCollection.Checked = itemStudentEditing.IsOkCollection;

            txtDescription.Text = itemStudentEditing.Description;
            lookupSourceInfoID.EditValue = itemStudentEditing.SourceInfoID;
            dtmReceivedDate.EditValue = itemStudentEditing.ReceivedDate;
            if (studentID == null)
                dtmReceivedDate.EditValue = DateTime.Now;
            

            //if (itemStudentEditing.Image != null && itemStudentEditing.Image != "")
            //{
            //    if (System.IO.File.Exists(strServerPath_StudentImage + itemStudentEditing.Image))
            //        picStudent.Image = new Bitmap(strServerPath_StudentImage + itemStudentEditing.Image);
            //    else
            //        picStudent.Image = null;
            //}
            //else
            //    picStudent.Image = null;
            //strLocalFilePath_StudentImage = "";


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

            if (dtmReceivedDate.EditValueDateTime == null)
            {
                MessageManager.Warning("Bạn phải nhập ngày nhận hồ sơ!");
                dtmReceivedDate.Focus();
                return false;
            }

            if (uClass21.ClassIDEditValue == null)
            {
                MessageManager.Warning("Bạn phải chọn lớp đang còn tuyển sinh!");
                uClass21.Focus();
                return false;
            }

            // chỉ xét lúc thêm mới, sửa thì vẫn sửa, khi hồ sơ chưa là học sinh
            if (itemStudentEditing.StudentID == null && !uClass21.IsCollecting)
            {
                MessageManager.Warning("Bạn phải chọn lớp đang còn tuyển sinh!");
                uClass21.Focus();
                return false;
            }

            //if (uClass21.ClassIDEditValue == null)
            //{
            //    if (uClass21.CourseIDEditValue == null)
            //    {
            //        MessageManager.Warning("Bạn phải chọn khoá học!");
            //        uClass21.Focus();
            //        return false;
            //    }
            //}

            //// chỉ xét lúc thêm mới, sửa thì vẫn sửa, khi hồ sơ chưa là học sinh
            //if (itemStudentEditing.StudentID == null && uClass21.ClassIDEditValue != null && !uClass21.IsCollecting)
            //{
            //    MessageManager.Warning("Bạn phải chọn lớp đang còn tuyển sinh!");
            //    uClass21.Focus();
            //    return false;
            //}

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

            itemStudentEditing.SpecialBranchID = uClass21.SpecialBranchIDEditValue;
            itemStudentEditing.CourseID = uClass21.CourseIDEditValue;
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

            itemStudentEditing.PersionIDDate = dtmPersionIDDate.EditValueDateTime;
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
            itemStudentEditing.IsOkCollection = chkIsOkCollection.Checked;

            itemStudentEditing.Description = txtDescription.Text;

            itemStudentEditing.SourceInfoID = lookupSourceInfoID.EditValueInt32;
            itemStudentEditing.ReceivedDate = dtmReceivedDate.EditValueDateTime;
            
            // save hinh
            if (strLocalFilePath_StudentImage != "") // có chọn hình
            {
                if (System.IO.Directory.Exists(strServerPath_StudentImage))
                {
                    string strFileImage = itemStudentEditing.StudentCode + "." + strLocalFilePath_StudentImage.Substring(strLocalFilePath_StudentImage.Length - 3);
                    System.IO.File.Copy(strLocalFilePath_StudentImage, strServerPath_StudentImage + strFileImage);
                    itemStudentEditing.Image = strFileImage;
                }
                else
                {
                    ErrorManager.Error("Không tồn tại đường dẫn chứa tập tin hình ảnh sinh viên!");
                    return false;
                }
            }


            if (itemStudentEditing.StudentID == null) // add new
            {
                //itemStudentEditing.StudentID = txtStudentID.TextTrim; 
                itemStudentEditing.CreatedUser = UserSession.Username;
                itemStudentEditing.OrderIndex = 0; // mặc định khi thêm mới thứ tự
                itemStudentEditing.Status = 0; // là TS, chưa là SV khi thêm mới
                if (itemStudentEditing.Add())
                {
                    string strActionLog = "Mã sinh viên: " + txtStudentCode.TextTrim + "\r\n" +
                                    "Họ tên: " + txtStudentFirstName.TextTrim + " " + txtStudentLastName.TextTrim;
                    new SystemObject.SYS_ActionLog().WriteActionLog("Thêm hồ sơ tuyển sinh", strActionLog, SystemObject.ActionLogType.ADD, 1, UserSession.Username);                    
                }
                else
                {
                    ErrorManager.Error("Việc cập nhật dữ liệu bị lỗi!" + itemStudentEditing.ErrorException.Message);
                    return false;
                }
            }
            else
            {
                itemStudentEditing.UpdatedUser = UserSession.Username;
                if (itemStudentEditing.Update())
                {

                    string strActionLog = "Mã sinh viên: " + txtStudentCode.TextTrim + "\r\n" +
                                "Họ tên: " + txtStudentFirstName.TextTrim + " " + txtStudentLastName.TextTrim;
                    new SystemObject.SYS_ActionLog().WriteActionLog("Sửa hồ sơ tuyển sinh", strActionLog, SystemObject.ActionLogType.EDIT, 1, UserSession.Username);                    
                }
                else
                {
                    ErrorManager.Error("Việc cập nhật dữ liệu bị lỗi!" + itemStudentEditing.ErrorException.Message);
                    return false;
                }
            }

            // tự động tạo dự kiến thu sinh viên nếu chưa có
            if (chkIsOkCollection.Checked && uClass21.ClassIDEditValue!=null)
            {
                AccountObject.ACC_StudentReceiptPlan objStudentReceiptPlan = new AccountObject.ACC_StudentReceiptPlan();
                string strRs = objStudentReceiptPlan.AutoCreateForStudent(itemStudentEditing.StudentID.Value, UserSession.Username);                
            }
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
        
        #endregion

        #region Form Actions

        private void frmStudentForCollection_Load(object sender, EventArgs e)
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
            RefreshReferenceData();
            frmStudentForCollection_Load(sender, e);
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

        private void frmStudentForCollection_KeyDown(object sender, KeyEventArgs e)
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
           // dtbData1.DefaultView.RowFilter = "Status1=1 Or Status1=2";
            //dtbData1 = dtbData1.DefaultView.ToTable();
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData1, "Report/StudentManager/Student/Student_DanhSachTuyenSinh_Nganh.repx", false);
            dDatePrint = DateTime.Now.ToString("dd/MM/yyyy");
            frm.SetParameter("pDatePrint",dDatePrint);
            frm.Show();
        }        

        private void picStudent_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "*.jpg;*.png;*.bmp;*.gif | *.jpg;*.png;*.bmp;*.gif | *.* | *.*";
            dlg.Multiselect = false;
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                picStudent.Image = new Bitmap(dlg.FileName);                
                strLocalFilePath_StudentImage = dlg.FileName; // nhớ file này để chọn                
            }
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
            dtb.DefaultView.RowFilter = "IsInDorm = 0";
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtb, "Report/StudentManager/Student/Student_DanhSachNgoaiTru.repx", false);

            frm.Show();
        }

        private void mnuItemPrintInDorm_Click(object sender, EventArgs e)
        {
            // print Sinh vien  nội trú                     
            DataTable dtb = dtbData.Copy();
            dtb.DefaultView.RowFilter = "IsInDorm = 1";
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtb, "Report/StudentManager/Student/Student_DanhSachNoiTru.repx", false);

            frm.Show();
        }

        private void txtStudentCode_Leave(object sender, EventArgs e)
        {            
            //new Thread(CheckStudent).Start();
        }
       

        private void btnStudentReceiptPlan_Click(object sender, EventArgs e)
        {            
            if (itemStudentEditing != null && itemStudentEditing.StudentID != null)
            {
                // Tự tạo kế hoạch thu sinh viên

                Account.Declaration.frmReceiptPlanEdit frmEdit = Account.Declaration.frmReceiptPlanEdit.Instance;
                frmEdit.StudentID = itemStudentEditing.StudentID;
                frmEdit.ClassID = itemStudentEditing.ClassID;
                frmEdit.ReceiptPlanID = 0;
                frmEdit.LoadData();
                frmEdit.ShowDialog();
            }
            else
                MessageManager.Warning("Chỉ tạo kế hoạch thu khi chỉnh sửa sinh viên!");
        }

        private void btnReceipt_Click(object sender, EventArgs e)
        {
            if (itemStudentEditing != null && itemStudentEditing.StudentID != null)
            {
                // tự động tạo dự kiến thu sinh viên nếu chưa có
                AccountObject.ACC_StudentReceiptPlan objStudentReceiptPlan = new AccountObject.ACC_StudentReceiptPlan();
                string strRs = objStudentReceiptPlan.AutoCreateForStudent(itemStudentEditing.StudentID.Value, UserSession.Username);
                if (strRs != "")
                {
                    MessageManager.Warning(strRs);
                    return;
                }

                // tìm phiếu thu cũ
                AccountObject.ACC_Receipt obj = new AccountObject.ACC_Receipt();
                DataTable dtb = obj.Search("@StudentID", itemStudentEditing.StudentID, "@ReceiptSegmentGroupID", AccountObject.ReceiptSegmentGroup.HocPhi);

                Account.Declaration.frmReceipt frmEdit = Account.Declaration.frmReceipt.Instance;
                frmEdit.ResetData();

                frmEdit.StudentID = itemStudentEditing.StudentID.Value;
                if (dtb != null && dtb.Rows.Count > 0)
                    frmEdit.LoadData(Convert.ToInt64(dtb.Rows[0]["ReceiptID"]));
                else
                    frmEdit.LoadStudentInfo(itemStudentEditing, null, null, null, false);
                
                frmEdit.ShowDialog();
            }
            else
                MessageManager.Warning("Chỉ tạo phiếu thu khi chỉnh sửa sinh viên!");
        }

        private void mnuItemPrintGiayBaoTrungTuyen_Click(object sender, EventArgs e)
        {
            // print danh sach giay bao trung tuyen 
            string dDatePrint = "";                   
            DataTable dtbData2 = dtbData.Copy();
            dtbData2.DefaultView.RowFilter = "IsSelected = 1";
            dtbData2 = dtbData2.DefaultView.ToTable();
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData2, "Report/StudentManager/Student/Student_GiayBaoTrungTuyen.repx", false);
            dDatePrint = "Thành phố Hồ Chí Minh, ngày " + DateTime.Now.ToString("dd") + " tháng " + DateTime.Now.ToString("MM") + " năm " + DateTime.Now.ToString("yyyy");
            frm.SetParameter("pDatePrint", dDatePrint);
            frm.Show();
        }

        private void mnuItemGiayBaoNhapHoc_Click(object sender, EventArgs e)
        {            
            // print danh sach giay bao nhap hoc
            string dDatePrint = "";   
            DataTable dtbData2 = dtbData.Copy();
            dtbData2.DefaultView.RowFilter = "IsSelected = 1";
            dtbData2 = dtbData2.DefaultView.ToTable();
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData2, "Report/StudentManager/Student/Student_GiayBaoNhapHoc.repx", false);
            dDatePrint = "Thành phố Hồ Chí Minh, ngày " + DateTime.Now.ToString("dd") + " tháng " + DateTime.Now.ToString("MM") + " năm " + DateTime.Now.ToString("yyyy");
            frm.SetParameter("pDatePrint", dDatePrint);
            frm.Show();
        }

        private void btnReceipt5_Click(object sender, EventArgs e)
        {
            if (itemStudentEditing != null && itemStudentEditing.StudentID != null)
            {
                // tìm phiếu thu cũ
                AccountObject.ACC_Receipt obj = new AccountObject.ACC_Receipt();
                DataTable dtb = obj.Search("@StudentID", itemStudentEditing.StudentID, "@ReceiptSegmentGroupID", AccountObject.ReceiptSegmentGroup.TuyenSinh);

                Account.Declaration.frmOtherReceipt frmEdit = Account.Declaration.frmOtherReceipt.Instance;                
                frmEdit.ReceiptSegmentGroupID = AccountObject.ReceiptSegmentGroup.TuyenSinh;
                frmEdit.StudentID = itemStudentEditing.StudentID.Value;
                
                if (dtb != null && dtb.Rows.Count > 0)
                    frmEdit.LoadData(Convert.ToInt64(dtb.Rows[0]["ReceiptID"]));
                else
                    frmEdit.LoadStudentInfo(itemStudentEditing, null, null, null, false);

                frmEdit.ShowDialog();
            }
            else
                MessageManager.Warning("Chỉ tạo phiếu thu khi chỉnh sửa sinh viên!");
        }

        private void txtTel_Load(object sender, EventArgs e)
        {

        }

        private void tpDetail_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtContactName2_Load(object sender, EventArgs e)
        {

        }

        private void txtContactName_Load(object sender, EventArgs e)
        {

        }

        private void txtContactTel_Load(object sender, EventArgs e)
        {

        }

        private void mnupPrint1_Click(object sender, EventArgs e)
        {
            // print Sinh vien
            string dDatePrint = "";
            DataTable dtbData1 = dtbData.Copy();
            // dtbData1.DefaultView.RowFilter = "Status1=1 Or Status1=2";
            //dtbData1 = dtbData1.DefaultView.ToTable();
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData1, "Report/StudentManager/Student/Student_DanhSachTuyenSinh_TinhThanh.repx", false);
            dDatePrint = DateTime.Now.ToString("dd/MM/yyyy");
            frm.SetParameter("pDatePrint", dDatePrint);
            frm.Show();
        }

        private void mnuPrint2_Click(object sender, EventArgs e)
        {
            // print Sinh vien
            string dDatePrint = "";
            DataTable dtbData1 = dtbData.Copy();
            // dtbData1.DefaultView.RowFilter = "Status1=1 Or Status1=2";
            //dtbData1 = dtbData1.DefaultView.ToTable();
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData1, "Report/StudentManager/Student/Student_DanhSachTuyenSinh_KenhTS.repx", false);
            dDatePrint = DateTime.Now.ToString("dd/MM/yyyy");
            frm.SetParameter("pDatePrint", dDatePrint);
            frm.Show();
        }

        private void chkIsCollecting_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsCollecting.Checked)            
                uClassID_Search.ClassFilter = "ClassType = 0 and IsCollecting = 1";                
            else

                uClassID_Search.ClassFilter = "ClassType = 0";
            uClassID_Search.InitData();            
        }

    }
}