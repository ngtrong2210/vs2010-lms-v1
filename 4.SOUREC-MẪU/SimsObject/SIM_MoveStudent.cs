
#region Using

using System;
using System.Data;
using System.Collections;
using DCore;

#endregion

namespace SimsObject
{
    
	public partial class SIM_MoveStudent
	{	
		
		#region Methods	
		
        /// <summary>
        /// Created by 		: NGUYỄN VĂN VIỆT 
        /// Created date 	: 5/23/2011 
        /// Chuyển lớp sinh viên, hoặc lưu ban Làm công đoạn này để chuyển điểm và các thứ liên quan
        /// Nếu lưu ban thì không chuyển điểm
        /// </summary>	
        public bool DoMoving()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_MoveStudent_DoMoving");                
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_SourceClassID, this.strSourceClassID);
                objIData.AddParameter(P_DesClassID, this.strDesClassID);                
                objIData.AddParameter(P_TypeAction, this.intTypeAction);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_MoveStudent", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

		#endregion
	
	}
}
