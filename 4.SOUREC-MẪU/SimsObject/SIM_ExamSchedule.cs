
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
	/// Created date 	: 6/14/2012 
	/// Description 
	/// </summary>	
	public partial class SIM_ExamSchedule
	{	
		
		#region Methods	
		
        ///// <summary>
        ///// Kiểm tra việc login user. Chứ không có save session
        ///// </summary>
        ///// <param name="username"></param>
        ///// <param name="pass"></param>
        ///// <returns></returns>
        //public int CheckLogin(string loginName, string pass, out SIM_ExamSchedule user)
        //{
        //    user = (new SIM_ExamSchedule()).GetByLoginName(loginName);
        //    if (user != null)
        //    {
        //        if (user.Password != DCore.Cryptography.EncryptPass(pass))
        //            return -1; // sai mat khau
        //    }
        //    else
        //        return -2; // sai username
        //    if (user.IsActived == false)
        //        return 0; // chua duoc active

        //    return 1; // login thanh cong
        //}


        /////<summary>
        ///// Nạp thông tin item 
        ///// Store: SIM_ExamSchedule_GET 
        /////</summary>
        ///// <returns>true ? Có : False ? Không</returns>
        //public SIM_ExamSchedule GetByLoginName(string loginName)
        //{
        //    DataTable dtb = Search("@LoginName", loginName);
        //    if (dtb != null)
        //        if (dtb.Rows.Count > 0)
        //        {
        //            SIM_ExamSchedule obj = new SIM_ExamSchedule();
        //            obj.Username = dtb.Rows[0]["Username"].ToString();
        //            if (obj.Get())
        //            {
        //                obj.FullName = obj.FirstName + " " + obj.LastName;
        //                return obj;
        //            }
        //        }
        //    return null;


        //}		
		#endregion
	
	}
}
