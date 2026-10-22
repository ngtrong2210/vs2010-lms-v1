
#region Using

using System;
using System.Data;
using System.Collections;
using DCore;

#endregion

namespace SimsObject
{
    /// <summary>
    /// Nguyễn Văn Việt
    /// 2021/12/17
    /// Khóa dữ liệu lớp theo kì
    /// </summary>
    public partial class SIM_Class_SemesterLock
	{

        public const int LEARNING = 1; // học tập (Mark)
        public const int ETHIC = 2; // rèn luyện (EthicMark)       
		
		#region Methods	
			
        /// <summary>
        /// truyền tham số để tạo hay xóa khóa
        /// </summary>
        /// <param name="bolIsLock"></param>
        /// <returns></returns>
        public bool AddOrEdit(bool isLock)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Class_SemesterLock_AddOrEdit");
                objIData.AddParameter(P_YearID, this.intYearID);
                objIData.AddParameter(P_Semester, this.intSemester);
                objIData.AddParameter(P_ClassID, this.strClassID);
                objIData.AddParameter(P_Type, this.intType);
                objIData.AddParameter(P_LockedToDate, this.dtmLockedToDate);
                objIData.AddParameter("@IsLock", isLock);
                objIData.AddParameter(P_CreatedUser, this.strCreatedUser);                
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_Class_SemesterLock_AddOrEdit", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        /// <summary>
        /// Mr Việt sửa lại cho cơ chế khóa theo ngày và nếu chưa khóa vẫn trả ra ngày khóa dự kiến nếu có
        /// Kiểm tra có lock hay không. Nếu có dòng là lock, không có là chưa lock        
        /// </summary>
        /// <returns></returns>
        public bool IsLock(out DateTime? lockedToDate)
        {
            lockedToDate = null;
            DataTable dtb = GetDataTable("SIM_Class_SemesterLock_GetForCheckLock",
                        "@YearID", this.intYearID,
                        "@Semester", this.intSemester,
                        "@ClassID", this.strClassID,
                        "@Type", this.intType);

            if (dtb == null)
                return true; // lỗi thì coi như khóa

            if(dtb.Rows.Count > 0) // tìm được dòng thì lấy ngày dự kiến khóa nếu có và trạng thái khóa 
            {
                if (dtb.Rows[0]["LockedToDate"].ToString() != "")
                    lockedToDate = Convert.ToDateTime(dtb.Rows[0]["LockedToDate"]);

                return Convert.ToBoolean(dtb.Rows[0]["IsLock"]); // 
            }

            return false;
        }

        /// <summary>
        /// Mr Việt sửa lại cho cơ chế khóa theo ngày và nếu chưa khóa vẫn trả ra ngày khóa dự kiến nếu có
        /// </summary>
        /// <param name="yearID"></param>
        /// <param name="semester"></param>
        /// <param name="classID"></param>
        /// <param name="type"></param>
        /// <param name="lockedToDate"></param>
        /// <returns></returns>
        public static bool IsLock(int? yearID, int? semester, string classID, int? type, out DateTime? lockedToDate)
        {

            SIM_Class_SemesterLock obj = new SIM_Class_SemesterLock();
            obj.YearID = yearID;
            obj.Semester = semester;
            obj.ClassID = classID;
            obj.Type = type;

            return obj.IsLock(out lockedToDate);            
        }
        
		#endregion
	
	}
}