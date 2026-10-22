
#region Using

using System;
using System.Data;
using System.Collections;
using DCore;

#endregion

namespace SimsObject
{
    /// <summary>
    /// Created by 		: NGUYỄN VĂN VIỆT 
    /// Created date 	: 5/12/2011 
    /// Description 
    /// </summary>	
    public partial class SIM_Class
    {

        
        ///<summary>
        /// Xóa danh sách lớp, với mã là một chuỗi cách nhau dấu, ví dụ 'CN03','CN04' mà có thể sử dụng in trong query
        /// Store này tự kiểm tra và xoá luôn môn học lớp của nó
        /// Store: SIM_Class_DeleteList
        /// </summary>
        /// <param name="item">SIM_Class_Subject</param>
        /// <returns>bool</returns>
        public bool DeleteListClass(string listID)
        {
            return this.ExecNonQuery("SIM_Class_DeleteList", "@ListID", listID);
        }

        /// <summary>
        /// Lấy lớp ghép (lớp lớn)
        /// Store: SIM_Class_SearchBigClass
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchBigClass(params object[] conditions)
        {
            return GetDataTable("SIM_Class_SearchBigClass", conditions);
        }

        /// <summary>
        /// Lấy lớp bị tách (lớp cha)
        /// Store: SIM_Class_SearchSmallClass
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchSmallClass(params object[] conditions)
        {
            return GetDataTable("SIM_Class_SearchSmallClass", conditions);
        }

        /// <summary>
        /// NGUYỄN VĂN VIỆT
        /// Lấy danh sách lớp cha để add vào lớp ghép
        /// Store: SIM_Class_SearchForBigClass
        /// </summary>
        /// <param name="conditions">YearID,Semester,SubjectID là bắt buộc</param>
        /// <returns></returns>
        public DataTable SearchForBigClass(params object[] conditions)
        {
            return GetDataTable("SIM_Class_SearchForBigClass", conditions);
        }

        /// <summary>
        /// Lấy danh sách lớp tách để hỗ trợ kiểm tra trong sắp lịch tự động
        /// ClassID,OriginClassID, -1 as "ClassIndex", -1 as "OriginClassIndex"
        /// [SIM_Class_SearchBigAndSmallForAutoScheduling]
        /// </summary>
        /// <returns></returns>
        public DataTable SearchBigAndSmallForAutoScheduling(params object[] conditions)
        {
            return GetDataTable("SIM_Class_SearchBigAndSmallForAutoScheduling", conditions);
        }


        /// <summary>
        /// DS lớp để sắp tự động, hoặc chuẩn bị sắp lịch 
        /// Mặc định là chỉ lấy Actived = 1, Muốn lấy hết thì truyền null vào (ví dụ lấy cho Chuẩn bị dữ liệu sắp lịch)
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchForAutoScheduling(params object[] conditions)
        {
            return GetDataTable("SIM_Class_SearchForAutoScheduling", conditions);
        }


        ///<summary>
        /// Xóa danh dau mon hoc lop khi xoa mot lop tách, xóa lớp tách, và xóa luôn môn học của lớp tách
        /// Store: SIM_Class_DeleteForSmallClass
        /// </summary>
        /// <param name="item">SIM_Class_Subject</param>
        /// <returns>bool</returns>
        public bool DeleteForSmallClass(int? classSubjectID)
        {
            return ExecNonQuery("SIM_Class_DeleteForSmallClass", "@ClassSubjectID", classSubjectID);
        }

        /// <summary>
        /// Tìm kiếm SIM_Class. Get danh sách lớp con của một lớp bị tách
        /// Store: SIM_Class_SearchChildrenClass
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchChildrenClass(int? classSubjectID)
        {
            return GetDataTable("SIM_Class_SearchChildrenClass", "@ClassSubjectID", classSubjectID);
        }


        /// <summary>
        /// Lấy mã lớp cha của lớp tách hoặc ghép
        /// </summary>
        /// <param name="classID">mã lớp tách ghép cần tìm lớp cha</param>
        /// <returns>Mã lớp cha</returns>
        public object GetReferenceClassID(object classID)
        {
            try
            {
                if (classID == null)
                    return null;

                SIM_Class item = Get(classID.ToString());
                if (item != null)
                {
                    if (item.ClassType == 1)//ghep thi phai tim trong Class_Subject
                    {
                        return (new SIM_Class_Subject().Search("@BigClassID", classID)).Rows[0]["ClassID"].ToString();
                    }
                    else if (item.ClassType == 2) // tách thì tìm theo mã môn học lớp của lớp tách đó luôn
                    {
                        return (new SIM_Class_Subject().Get(item.ClassSubjectID.Value)).ClassID;
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
            finally
            {
            }
        }


        /// <summary>
        /// Lấy danh sách lớp đơn giản.     
        /// SubjectID, YearID, Semester là khi muốn tìm lớp có học môn đó ở niên kì đó
        /// [SIM_Class_SearchSimpleList]
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchSimpleList(params object[] conditions)
        {
            return GetDataTable("SIM_Class_SearchSimpleList", conditions);
        }

        /// <summary>
        /// Lấy ds lớp có sv đăng ký thi tốt nghiệp ở đợt
        /// SIM_Class_SearchForGraduationExamSchedule
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchForGraduationExamSchedule(params object[] conditions)
        {
            return GetDataTable("SIM_Class_SearchForGraduationExamSchedule", conditions);
        }

        /// <summary>
        /// Lấy tổng đơn vị học trình của môn học lớp, hoặc tổng tín chỉ của chương trình khung
        /// SIM_SpecialBranch_Subject_GetUnitTextOfCourse
        /// SIM_Class_Subject_GetUnitTextOfCourse
        /// </summary>
        /// <param name="isRegulation43">true: SIM_SpecialBranch_Subject_GetUnitTextOfCourse | false: SIM_Class_Subject_GetUnitTextOfCourse</param>
        /// <returns></returns>
        public int GetUnitTextOfCourse(bool isRegulation43 = true)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                if (isRegulation43)
                {
                    objIData.CreateNewStoredProcedure("SIM_SpecialBranch_Subject_GetUnitTextOfCourse");
                    objIData.AddParameter(P_SpecialBranchID, this.strSpecialBranchID);
                    objIData.AddParameter(P_TrainingLevelID, this.strTrainingLevelID);
                    objIData.AddParameter(P_TrainingType, this.strTrainingType);
                    objIData.AddParameter(P_CourseID, this.strCourseID);
                }
                else
                {
                    objIData.CreateNewStoredProcedure("SIM_Class_Subject_GetUnitTextOfCourse");
                    objIData.AddParameter(P_ClassID, this.strClassID);
                }

                return Convert.ToInt32(objIData.ExecStoreToString());

            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi lấy tổng tín chỉ của chương trình khung", objEx);
                this.objErrorException = objEx;
                return 0;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }


        /// <summary>
        /// Lấy danh sách lớp và giáo viên chủ nhiệm.     
        /// [SIM_Class_SearchHomeroomTeacher]
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchHomeroomTeacher(params object[] conditions)
        {
            return GetDataTable("SIM_Class_SearchHomeroomTeacher", conditions);
        }

        /// <summary>
        /// NGUYỄN VĂN Minh
        /// Lấy sĩ số sinh viên
        /// Store: SIM_Class_GetSize
        /// </summary>
        /// <param name="conditions">ClassID là bắt buộc</param>
        /// <returns></returns>
        public DataTable SIM_Class_GetSize(params object[] conditions)
        {
            return GetDataTable("SIM_Class_GetSize", conditions);
        }


        public int GetRealClassSize()
        {

            if (this.strClassID == null)
                return 0;

            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {

                objIData.CreateNewStoredProcedure("SIM_Class_GetRealClassSize");
                objIData.AddParameter(P_ClassID, this.strClassID);
                return Convert.ToInt32(objIData.ExecStoreToString());
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi lấy sỉ số thật của lớp bị lỗi", objEx);
                this.objErrorException = objEx;
                return 0;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }
    }
}
