using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SimsObject;


namespace SimsService
{
    /// <summary>
    /// Đồng bộ từ CĐN Đồng Nai  - 26.9.2023 Mr Việt
    /// Lưu ý: trước khi đồng bộ 04 qua, thấy frmSubjectMark đang TotalRow trực tiếp trên form, cần thiết phải coi lại 
    /// 
    /// </summary>
    public partial class SIM_SubjectMarkService
    {

        public static void TotalRow(DataRow drw)
        {
            if (drw["OrderLearning"].ToString() == "")
                drw["OrderLearning"] = 1;

            if (drw["IsOldData"].ToString() == "")
                drw["IsOldData"] = false;

            if (drw["IsOldMark"].ToString() == "")
                drw["IsOldMark"] = false;

            if (drw["IsTextMark"].ToString() == "")
                drw["IsTextMark"] = false;

            if (drw["IsIgnore"].ToString() == "")
                drw["IsIgnore"] = false;

            // Điểm miễn, reset các cột khác, tự động đạt và kết quả có chữ M
            if (Convert.ToBoolean(drw["IsIgnore"]))
            {
                TotalRow_IsIgnore(drw);
                return;
            }


            int intSpecialType = Convert.ToInt32(drw["SpecialType"]);
            int intRegulationID = Convert.ToInt32(drw["RegulationID"]);

            if (intSpecialType == Global.SubjectSpecialType.TotNghiepLT
               || intSpecialType == Global.SubjectSpecialType.TotNghiepTH
               || intSpecialType == Global.SubjectSpecialType.ChinhTriTotNghiep)
                TotalRow_Graduation(drw);

            // Môn điểm chữ
            else if (Convert.ToBoolean(drw["IsTextMark"]))  // nếu là điểm chữ
            {
                if (Convert.ToBoolean(drw["IsOldData"]) || Convert.ToBoolean(drw["IsOldMark"])) // điểm chữ mà lại là điểm chuyển
                    TotalRow_MarkText_OldData(drw);
                else
                    TotalRow_MarkText(drw); // điểm chữ có điểm quá trình
            }

            // Môn học điểm số thông thường
            else if (Convert.ToBoolean(drw["IsOldData"]) || Convert.ToBoolean(drw["IsOldMark"])) // nếu là điểm chuyển thì chỉ cần nhập cột TKM và đạt hay không thôi
            {

                switch (intRegulationID)
                {
                    case 44: // tc,cd thông tư 04 - 2021
                        TotalRow04_TinChi_OldData(drw);
                        break;
                    case 99: // tc, cđ chuyên nghiệp 2017 Tín chỉ
                        TotalRow09_TinChi_OldData(drw);
                        break;
                    default:
                        TotalRow_OldData(drw);
                        break;
                }

            }
            else
            {
                switch (intRegulationID)
                {
                    // From 2021 -----------------------------------------------------
                    case 4: // tc,cđ thông tư 04 niên chế - 2021
                        TotalRow04(drw);
                        break;
                    case 44: // tc,cđ thông tư 04 Tín chỉ - 2021
                        TotalRow04_TinChi(drw);
                        break;

                    // From 2017 -----------------------------------------------------
                    case 28: // sơ cấp ko thi - tín điểm như 09
                    case 9: // tc, cđ chuyên nghiệp 2017
                        if (intSpecialType == 8)
                            TotalRow09_VanHoa(drw);
                        else
                            TotalRow09(drw);
                        break;
                    case 99: // tc, cđ chuyên nghiệp 2017 Tín chỉ
                        if (intSpecialType == 8)
                            TotalRow09_VanHoa(drw);
                        else
                            TotalRow09_TinChi(drw);
                        break;

                    // Before 2017 -----------------------------------------------------
                    case 14:
                        if (intSpecialType == 8)
                            TotalRow09_VanHoa(drw);
                        else
                            TotalRow14(drw);
                        break;
                    case 22:
                        TotalRow22(drw);
                        break;
                    case 40:
                        TotalRow40(drw);
                        break;
                    case 46:
                        TotalRow46(drw);
                        break;
                    case 25:
                        TotalRow25(drw);
                        break;
                    case 43:
                        TotalRow43(drw); // là quy chế 43 
                        break;


                    default:
                        TotalRow04(drw);
                        break;
                }
            }
        }

        /// <summary>
        /// Miễn
        /// </summary>
        /// <param name="drw"></param>
        public static void TotalRow_IsIgnore(DataRow drw)
        {
            // Tính TBKT luôn 2 hệ số           
            for (int i = 1; i <= 7; i++)
                drw["Mark1" + i.ToString()] = DBNull.Value;


            for (int i = 1; i <= 25; i++)
                drw["Mark2" + i.ToString()] = DBNull.Value;


            drw["TestAverage"] = DBNull.Value;

            for (int i = 1; i <= 3; i++)
            {
                drw["Exam" + i] = DBNull.Value;
                drw["TheoryExam" + i] = DBNull.Value;
                drw["PracticeExam" + i] = DBNull.Value;

                drw["Summary" + i] = DBNull.Value;
                drw["OtherSummary" + i] = DBNull.Value;
                drw["LearningLevel" + i] = DBNull.Value;
            }


            drw["FinalSummary"] = DBNull.Value;
            drw["OtherFinalSummary"] = DBNull.Value;
            drw["LearningLevel"] = "M";
            drw["Passed"] = 1;
        }

        /// <summary>
        ///  Điểm chuyển dạng điểm chữ
        ///  110 đạt
        ///  100 không đạt
        /// </summary>
        /// <param name="drw"></param>
        public static void TotalRow_MarkText_OldData(DataRow drw)
        {
            double? dblSummary1 = null, dblSummary2 = null, dblSummary3 = null;
            if (drw["Summary1"].ToString() != "")
                dblSummary1 = Convert.ToDouble(drw["Summary1"]);
            if (drw["Summary2"].ToString() != "")
                dblSummary2 = Convert.ToDouble(drw["Summary2"]);
            if (drw["Summary3"].ToString() != "")
                dblSummary3 = Convert.ToDouble(drw["Summary3"]);

            // Xét tổng kết môn cuối cùng
            // Xét tổng kết môn cuối cùng
            double? dblFinalSummary = dblSummary1;

            if (dblSummary2 > dblFinalSummary)
                dblFinalSummary = dblSummary2;
            if (dblSummary3 > dblFinalSummary)
                dblFinalSummary = dblSummary3;

            if (dblFinalSummary != null)
                drw["FinalSummary"] = dblFinalSummary;
            else
                drw["FinalSummary"] = DBNull.Value;


            // tính đạt môn :  TKM >=5
            if (dblFinalSummary != null)
            {
                if (dblFinalSummary > 100)
                    drw["Passed"] = 1;
                else
                    drw["Passed"] = 0;
            }
            else
                drw["Passed"] = DBNull.Value;
        }

        /// <summary>
        /// Xử lý điểm chữ, có điểm quá trình
        /// 110 đạt
        /// 100 không đạt
        /// Tất cả điểm quá trình đạt + điểm thi đạt --> TKM đạt
        /// </summary>
        /// <param name="drw"></param>
        private static void TotalRow_MarkText(DataRow drw)
        {
            double? dblExam1 = null, dblExam2 = null, dblExam3 = null, dblSummary1 = null, dblSummary2 = null, dblSummary3 = null;
            int intCount = 0;
            int intMark1Number = Convert.ToInt32(drw["Mark1Number"]);
            int intMark2Number = Convert.ToInt32(drw["Mark2Number"]);
            bool bolHaveFailed = false; // có môn có điểm mà điểm không đạt (chưa có điểm ko tính, như vậy nếu bỏ kt, thi fai cho 0 vô)


            // Tính TBKT luôn 2 hệ số           
            for (int i = 1; i <= 25 && i <= intMark1Number; i++)
            {
                {
                    string strValue = drw["Mark1" + i.ToString()].ToString();
                    if (strValue != "")
                    {
                        double? dblMark = Convert.ToDouble(strValue);
                        if (dblMark <= 100)
                            bolHaveFailed = true;
                    }

                    // nếu có điểm thì tăng số cột, nếu học lại thì chỉ tăng cột khi có nhập điểm (học lại thì không cần đủ số cột)
                    //if (Convert.ToInt32(drw["OrderLearning"]) < 2 || strValue != "")
                    if (strValue != "")
                        intCount++; // tính đủ số cột
                }
            }

            for (int i = 1; i <= 25 && i <= intMark2Number; i++)
            {
                {
                    string strValue = drw["Mark2" + i.ToString()].ToString();
                    if (strValue != "")
                    {
                        double? dblMark = Convert.ToDouble(strValue);
                        if (dblMark <= 100)
                            bolHaveFailed = true;
                    }

                    // nếu có điểm thì tăng số cột, nếu học lại thì chỉ tăng cột khi có nhập điểm (học lại thì không cần đủ số cột)
                    //if (Convert.ToInt32(drw["OrderLearning"]) < 2 || strValue != "")
                    if (strValue != "")
                        intCount += 2; // tính đủ số cột
                }
            }

            if (intCount > 0) // có điểm quá trình
            {
                if (!bolHaveFailed)
                    drw["TestAverage"] = 110; // đạt
                else
                    drw["TestAverage"] = 100; // ko đạt
            }
            else
                drw["TestAverage"] = DBNull.Value;


            // Tính lại điểm thi nếu có thi LT-TH:  theo kiểu 110 và 100 (cả lt, th đều đạt thì điểm thi mới đạt 110, ngược lại là 100)
            bool bolTheoryPracticePassed = TotalTheoryPracticeExam_TextMark(drw);


            // Tính TKM theo điểm tbkt đạt và điểm thi phải đạt
            if (drw["Exam1"].ToString() != "")
            {
                dblExam1 = Convert.ToDouble(drw["Exam1"]);
                dblSummary1 = (!bolHaveFailed && dblExam1 > 100) ? 110 : 100;

            }
            if (drw["Exam2"].ToString() != "")
            {
                dblExam2 = Convert.ToDouble(drw["Exam2"]);
                dblSummary2 = (!bolHaveFailed && dblExam2 > 100) ? 110 : 100;
            }
            if (drw["Exam3"].ToString() != "")
            {
                dblExam3 = Convert.ToDouble(drw["Exam3"]);
                dblSummary3 = (!bolHaveFailed && dblExam3 > 100) ? 110 : 100;
            }



            if (dblSummary1 != null)
                drw["Summary1"] = dblSummary1;
            else
                drw["Summary1"] = DBNull.Value;

            if (dblSummary2 != null)
                drw["Summary2"] = dblSummary2;
            else
                drw["Summary2"] = DBNull.Value;

            if (dblSummary3 != null)
                drw["Summary3"] = dblSummary3;
            else
                drw["Summary3"] = DBNull.Value;


            // Xét tổng kết môn cuối cùng
            double? dblFinalSummary = dblSummary1;

            if (dblSummary2 > dblFinalSummary)
                dblFinalSummary = dblSummary2;
            if (dblSummary3 > dblFinalSummary)
                dblFinalSummary = dblSummary3;

            if (dblFinalSummary != null)
                drw["FinalSummary"] = dblFinalSummary;
            else
                drw["FinalSummary"] = DBNull.Value;


            // tính đạt môn :  TKM >=5
            if (dblFinalSummary != null)
            {
                if (dblFinalSummary > 100) // tk lớn nhất đạt là đạt
                    drw["Passed"] = 1;
                else
                    drw["Passed"] = 0;
            }
            else
                drw["Passed"] = DBNull.Value;
        }  // End TotalRow_TextMark


        public static void TotalRow_OldData(DataRow drw)
        {
            double? dblSummary1 = null, dblSummary2 = null, dblSummary3 = null;
            if (drw["Summary1"].ToString() != "")
                dblSummary1 = Convert.ToDouble(drw["Summary1"]);
            if (drw["Summary2"].ToString() != "")
                dblSummary2 = Convert.ToDouble(drw["Summary2"]);
            if (drw["Summary3"].ToString() != "")
                dblSummary3 = Convert.ToDouble(drw["Summary3"]);

            // Xét tổng kết môn cuối cùng
            // Xét tổng kết môn cuối cùng
            double? dblFinalSummary = dblSummary1;

            if (dblSummary2 > dblFinalSummary)
                dblFinalSummary = dblSummary2;
            if (dblSummary3 > dblFinalSummary)
                dblFinalSummary = dblSummary3;

            if (dblFinalSummary != null)
                drw["FinalSummary"] = dblFinalSummary;
            else
                drw["FinalSummary"] = DBNull.Value;

            // có quy định điểm tối thiểu trong môn học thì xét theo, không thì mặc định là 5
            double dblRequestMinMark = 5;
            try
            {
                if (drw["RequestMinMark"].ToString() != "" && drw["RequestMinMark"].ToString() != "0")
                    dblRequestMinMark = Convert.ToDouble(drw["RequestMinMark"]);
            }
            catch { }

            // tính đạt môn :  TKM >=5
            if (dblFinalSummary != null)
            {
                if (dblFinalSummary >= dblRequestMinMark)
                    drw["Passed"] = 1;
                else
                    drw["Passed"] = 0;
            }
            else
                drw["Passed"] = DBNull.Value;
        }

        public static void TotalRow_Graduation(DataRow drw)
        {
            double? dblExam1 = null, dblExam2 = null, dblExam3 = null, dblSummary1 = null, dblSummary2 = null, dblSummary3 = null;

            // Tính lại điểm thi nếu có thi LT-TH:  thi = (LT + TH)/2
            bool bolTheoryPracticePassed = TotalTheoryPracticeExam(drw);

            // Tính TKM
            if (drw["Exam1"].ToString() != "")
            {
                dblExam1 = dblSummary1 = Convert.ToDouble(drw["Exam1"]);
            }
            if (drw["Exam2"].ToString() != "")
            {
                dblExam2 = dblSummary2 = Convert.ToDouble(drw["Exam2"]);
            }
            if (drw["Exam3"].ToString() != "")
            {
                dblExam3 = dblSummary3 = Convert.ToDouble(drw["Exam3"]);
            }



            if (dblSummary1 != null)
                drw["Summary1"] = dblSummary1;
            else
                drw["Summary1"] = DBNull.Value;

            if (dblSummary2 != null)
                drw["Summary2"] = dblSummary2;
            else
                drw["Summary2"] = DBNull.Value;

            if (dblSummary3 != null)
                drw["Summary3"] = dblSummary3;
            else
                drw["Summary3"] = DBNull.Value;

            // Xét tổng kết môn cuối cùng
            double? dblFinalSummary = dblSummary1;

            if (dblSummary2 > dblFinalSummary)
                dblFinalSummary = dblSummary2;
            if (dblSummary3 > dblFinalSummary)
                dblFinalSummary = dblSummary3;

            if (dblFinalSummary != null)
                drw["FinalSummary"] = dblFinalSummary;
            else
                drw["FinalSummary"] = DBNull.Value;

            // có quy định điểm tối thiểu trong môn học thì xét theo, không thì mặc định là 5
            double dblRequestMinMark = 5;
            try
            {
                if (drw["RequestMinMark"].ToString() != "" && drw["RequestMinMark"].ToString() != "0")
                    dblRequestMinMark = Convert.ToDouble(drw["RequestMinMark"]);
            }
            catch { }

            // tính đạt môn :  TKM >=5
            if (dblFinalSummary != null)
            {
                if (bolTheoryPracticePassed && dblFinalSummary >= dblRequestMinMark)
                    drw["Passed"] = 1;
                else
                    drw["Passed"] = 0;
            }
            else
                drw["Passed"] = DBNull.Value;
        } // End TotalRow14


        /// <summary>
        /// Trả về kq đạt hay không?
        /// Chỉ cần có LT, hoặc TH <=5 là không đạt
        /// </summary>
        /// <param name="drw"></param>
        /// <returns></returns>
        public static bool TotalTheoryPracticeExam(DataRow drw)
        {
            if (!Convert.ToBoolean(drw["IsPractice"])) // là môn lý thuyết
                return true;
            int intTheoryRatio = Convert.ToInt32(drw["TheoryRatio"]);
            int intPracticeRatio = Convert.ToInt32(drw["PracticeRatio"]);

            bool bolTheoryPassed = false;
            bool bolPracticePassed = false;

            double dblMaxTheory = -1;
            double dblMaxPractice = -1;

            for (int i = 1; i < 3; i++)
            {
                double dblTheory = -1;
                double dblPractice = -1;
                int intFlag = 0;
                if (drw["TheoryExam" + i.ToString()].ToString() != "")
                {
                    dblTheory = Convert.ToDouble(drw["TheoryExam" + i.ToString()]);
                    // nếu đạt LT
                    if (dblTheory > 0) // chỉ riêng GTDT là > 0 còn lại phải >=3
                        bolTheoryPassed = true;
                    // lay diem sau cung tu vi tri dang tinh ve truoc
                    dblMaxTheory = dblTheory;
                    intFlag++;
                }
                if (drw["PracticeExam" + i.ToString()].ToString() != "")
                {
                    dblPractice = Convert.ToDouble(drw["PracticeExam" + i.ToString()]);
                    //Nếu đạt TH
                    if (dblPractice > 0) // chỉ riêng GTDT là > 0 còn lại phải >= 5
                        bolPracticePassed = true;
                    // lay diem sau cung tu vi tri dang tinh ve truoc
                    dblMaxPractice = dblPractice;
                    intFlag++;
                }

                if (intFlag > 0 && dblMaxTheory >= 0 && dblMaxPractice >= 0)
                {
                    drw["Exam" + i.ToString()] = Math.Round((dblMaxTheory * intTheoryRatio + dblMaxPractice * intPracticeRatio) / (intTheoryRatio + intPracticeRatio), 1, MidpointRounding.AwayFromZero);
                }
                else
                    drw["Exam" + i.ToString()] = DBNull.Value;

            }
            return bolTheoryPassed && bolPracticePassed; // cả 2 đều có điểm đạt mới là đạt
        }

        /// <summary>
        /// Trả về kq đạt hay không?
        /// Chỉ cần có LT, hoặc TH <= 100 là không đạt
        /// </summary>
        /// <param name="drw"></param>
        /// <returns></returns>
        public static bool TotalTheoryPracticeExam_TextMark(DataRow drw)
        {
            if (!Convert.ToBoolean(drw["IsPractice"])) // là môn lý thuyết
                return true;
            int intTheoryRatio = Convert.ToInt32(drw["TheoryRatio"]);
            int intPracticeRatio = Convert.ToInt32(drw["PracticeRatio"]);

            bool bolTheoryPassed = false;
            bool bolPracticePassed = false;

            double dblMaxTheory = -1;
            double dblMaxPractice = -1;

            for (int i = 1; i < 3; i++)
            {
                double dblTheory = -1;
                double dblPractice = -1;
                int intFlag = 0;
                if (drw["TheoryExam" + i.ToString()].ToString() != "")
                {
                    dblTheory = Convert.ToDouble(drw["TheoryExam" + i.ToString()]);
                    // nếu đạt LT
                    if (dblTheory > 100) // chỉ riêng GTDT là > 0 còn lại phải >=3
                        bolTheoryPassed = true;
                    // lay diem sau cung tu vi tri dang tinh ve truoc
                    dblMaxTheory = dblTheory;
                    intFlag++;
                }
                if (drw["PracticeExam" + i.ToString()].ToString() != "")
                {
                    dblPractice = Convert.ToDouble(drw["PracticeExam" + i.ToString()]);
                    //Nếu đạt TH
                    if (dblPractice > 100) // chỉ riêng GTDT là > 0 còn lại phải >= 5
                        bolPracticePassed = true;
                    // lay diem sau cung tu vi tri dang tinh ve truoc
                    dblMaxPractice = dblPractice;
                    intFlag++;
                }

                if (intFlag > 0 && dblMaxTheory >= 0 && dblMaxPractice >= 0) // có đủ 2 cột điểm LT, TH
                {
                    drw["Exam" + i.ToString()] = bolTheoryPassed && bolPracticePassed ? 110 : 100; // đạt khi cả 2 đạt
                }
                else
                    drw["Exam" + i.ToString()] = DBNull.Value;

            }
            return bolTheoryPassed && bolPracticePassed; // cả 2 đều có điểm đạt mới là đạt
        }

        #region Qui chế cũ 14,22, 40, 46, 43, 25

        public static void TotalRow14(DataRow drw)
        {
            double? dblTBKT = 0, dblExam1 = null, dblExam2 = null, dblSummary1 = null, dblSummary2 = null;
            double? dblTBKT2 = 0;
            int intCount = 0;
            drw["NotAllowExam"] = false;
            int intMark2Number = Convert.ToInt32(drw["Mark2Number"]);


            // Tính TBKT
            for (int i = 1; i <= 25 && i <= intMark2Number; i++)
            {
                string strValue = drw["Mark2" + i.ToString()].ToString();
                if (strValue != "")
                {
                    double a = Convert.ToDouble(strValue);
                    dblTBKT += a * 2;

                    if (a == 0)
                        drw["NotAllowExam"] = true;

                }
                else
                    drw["NotAllowExam"] = true;

                // nếu có điểm thì tăng số cột, nếu học lại thì chỉ tăng cột khi có nhập điểm (học lại thì không cần đủ số cột)

                if (strValue != "")
                    intCount += 2; // tính đủ số cột
            }
            if (intCount > 0)
                drw["TestAverage"] = dblTBKT2 = Math.Round(dblTBKT.Value / intCount, 1, MidpointRounding.AwayFromZero);
            else
                drw["TestAverage"] = DBNull.Value;

            // Tính lại điểm thi nếu có thi LT-TH:  thi = (LT + TH)/2
            bool bolTheoryPracticePassed = TotalTheoryPracticeExam(drw);

            // Tính TKM
            if (drw["Exam1"].ToString() != "")
            {
                dblExam1 = Convert.ToDouble(drw["Exam1"]);
                dblSummary1 = Math.Round((dblTBKT.Value + dblExam1.Value * 3) / (intCount + 3), 1, MidpointRounding.AwayFromZero);
            }
            if (drw["Exam2"].ToString() != "")
            {
                dblExam2 = Convert.ToDouble(drw["Exam2"]);
                dblSummary2 = Math.Round((dblTBKT.Value + dblExam2.Value * 3) / (intCount + 3), 1, MidpointRounding.AwayFromZero);
            }



            if (dblSummary1 != null)
                drw["Summary1"] = dblSummary1;
            else
                drw["Summary1"] = DBNull.Value;
            if (dblSummary2 != null)
                drw["Summary2"] = dblSummary2;
            else
                drw["Summary2"] = DBNull.Value;

            // Xét tổng kết môn cuối cùng
            if (dblSummary1 != null && dblSummary2 != null)
            {
                if (dblSummary2 > dblSummary1)
                    drw["FinalSummary"] = dblSummary2;
                else
                    drw["FinalSummary"] = dblSummary1;
            }
            else
                drw["FinalSummary"] = drw["Summary1"];

            // có quy định điểm tối thiểu trong môn học thì xét theo, không thì mặc định là 5
            double dblRequestMinMark = 5;
            if (drw["RequestMinMark"].ToString() != "" && drw["RequestMinMark"].ToString() != "0")
                dblRequestMinMark = Convert.ToDouble(drw["RequestMinMark"]);

            // tính đạt môn : Thi >=5 và TKM >=5
            if (dblSummary1 != null) // có thi lần 1 mới tính
            {
                if (bolTheoryPracticePassed && (dblExam1 >= dblRequestMinMark || dblExam2 >= dblRequestMinMark) && (dblSummary1 >= dblRequestMinMark || dblSummary2 >= dblRequestMinMark)) // thi và tkm >=5 và LT_TH đạt(dv môn TH)                   
                    drw["Passed"] = 1;
                else
                    drw["Passed"] = 0;
            }
            else
                drw["Passed"] = DBNull.Value;
        } // End TotalRow14


        public static void TotalRow22(DataRow drw)
        {
            double? dblTBKT = 0, dblExam1 = null, dblExam2 = null, dblExam3 = null, dblSummary1 = null, dblSummary2 = null, dblSummary3 = null;
            int intCount = 0;
            int intMark1Number = Convert.ToInt32(drw["Mark1Number"]);
            int intMark2Number = Convert.ToInt32(drw["Mark2Number"]);

            // Tính TBKT luôn 2 hệ số           
            for (int i = 1; i <= 25 && i <= intMark1Number; i++)
            {
                {
                    string strValue = drw["Mark1" + i.ToString()].ToString();
                    if (strValue != "")
                        dblTBKT += Convert.ToDouble(strValue); //nhân hệ số                                            

                    // nếu có điểm thì tăng số cột, nếu học lại thì chỉ tăng cột khi có nhập điểm (học lại thì không cần đủ số cột)
                    //if (Convert.ToInt32(drw["OrderLearning"]) < 2 || strValue != "")
                    if (strValue != "")
                        intCount++; // tính đủ số cột
                }
            }

            for (int i = 1; i <= 25 && i <= intMark2Number; i++)
            {
                {
                    string strValue = drw["Mark2" + i.ToString()].ToString();
                    if (strValue != "")
                        dblTBKT += Convert.ToDouble(strValue) * 2; //nhân hệ số

                    // nếu có điểm thì tăng số cột, nếu học lại thì chỉ tăng cột khi có nhập điểm (học lại thì không cần đủ số cột)
                    //if (Convert.ToInt32(drw["OrderLearning"]) < 2 || strValue != "")
                    if (strValue != "")
                        intCount += 2; // tính đủ số cột
                }
            }

            if (intCount > 0)
                drw["TestAverage"] = dblTBKT = Math.Round(dblTBKT.Value / intCount, 1, MidpointRounding.AwayFromZero);
            else
                drw["TestAverage"] = DBNull.Value;

            // Tính lại điểm thi nếu có thi LT-TH:  thi = (LT + TH)/2
            bool bolTheoryPracticePassed = TotalTheoryPracticeExam(drw);

            // nếu có tbkt thì + chia 10, không thì chia 6
            if (intCount > 0)
                intCount = 10;
            else
                intCount = 6;

            // Tính TMK dựa vào điểm thi
            if (drw["Exam1"].ToString() != "")
            {
                dblExam1 = Convert.ToDouble(drw["Exam1"]);
                dblSummary1 = Math.Round((dblTBKT.Value * 4 + dblExam1.Value * 6) / intCount, 1, MidpointRounding.AwayFromZero);

            }
            if (drw["Exam2"].ToString() != "")
            {
                dblExam2 = Convert.ToDouble(drw["Exam2"]);
                dblSummary2 = Math.Round((dblTBKT.Value * 4 + dblExam2.Value * 6) / intCount, 1, MidpointRounding.AwayFromZero);
            }
            if (drw["Exam3"].ToString() != "")
            {
                dblExam3 = Convert.ToDouble(drw["Exam3"]);
                dblSummary3 = Math.Round((dblTBKT.Value * 4 + dblExam3.Value * 6) / intCount, 1, MidpointRounding.AwayFromZero);
            }



            if (dblSummary1 != null)
                drw["Summary1"] = dblSummary1;
            else
                drw["Summary1"] = DBNull.Value;

            if (dblSummary2 != null)
                drw["Summary2"] = dblSummary2;
            else
                drw["Summary2"] = DBNull.Value;

            if (dblSummary3 != null)
                drw["Summary3"] = dblSummary3;
            else
                drw["Summary3"] = DBNull.Value;


            // Xét tổng kết môn cuối cùng
            double? dblFinalSummary = dblSummary1;

            if (dblSummary2 > dblFinalSummary)
                dblFinalSummary = dblSummary2;
            if (dblSummary3 > dblFinalSummary)
                dblFinalSummary = dblSummary3;

            if (dblFinalSummary != null)
                drw["FinalSummary"] = dblFinalSummary;
            else
                drw["FinalSummary"] = DBNull.Value;

            // có quy định điểm tối thiểu trong môn học thì xét theo, không thì mặc định là 5
            double dblRequestMinMark = 5;
            if (drw["RequestMinMark"].ToString() != "" && drw["RequestMinMark"].ToString() != "0")
                dblRequestMinMark = Convert.ToDouble(drw["RequestMinMark"]);

            // tính đạt môn :  TKM >=5
            if (dblFinalSummary != null)
            {
                if (bolTheoryPracticePassed && dblFinalSummary >= dblRequestMinMark && dblTBKT >= 3) //&& (dblExam1 >= 3 || dblExam2 >= 3) qui chế 22 ko kiểm tra điểm thi
                    drw["Passed"] = 1;
                else
                    drw["Passed"] = 0;
            }
            else
                drw["Passed"] = DBNull.Value;
        }  // End TotalRow40

        public static void TotalRow40(DataRow drw)
        {

            double? dblTBKT = 0, dblExam1 = null, dblExam2 = null, dblExam3 = null, dblSummary1 = null, dblSummary2 = null, dblSummary3 = null;
            int intCount = 0;
            int intMark1Number = Convert.ToInt32(drw["Mark1Number"]);
            int intMark2Number = Convert.ToInt32(drw["Mark2Number"]);

            // Tính TBKT luôn 2 hệ số           
            for (int i = 1; i <= 25 && i <= intMark1Number; i++)
            {
                {
                    string strValue = drw["Mark1" + i.ToString()].ToString();
                    if (strValue != "")
                        dblTBKT += Convert.ToDouble(strValue); //nhân hệ số                                            

                    // nếu có điểm thì tăng số cột, nếu học lại thì chỉ tăng cột khi có nhập điểm (học lại thì không cần đủ số cột)
                    //if (Convert.ToInt32(drw["OrderLearning"]) < 2 || strValue != "")
                    if (strValue != "")
                        intCount++; // tính đủ số cột
                }
            }

            for (int i = 1; i <= 25 && i <= intMark2Number; i++)
            {
                {
                    string strValue = drw["Mark2" + i.ToString()].ToString();
                    if (strValue != "")
                        dblTBKT += Convert.ToDouble(strValue) * 2; //nhân hệ số

                    // nếu có điểm thì tăng số cột, nếu học lại thì chỉ tăng cột khi có nhập điểm (học lại thì không cần đủ số cột)
                    //if (Convert.ToInt32(drw["OrderLearning"]) < 2 || strValue != "")
                    if (strValue != "")
                        intCount += 2; // tính đủ số cột
                }
            }

            if (intCount > 0)
                drw["TestAverage"] = dblTBKT = Math.Round(dblTBKT.Value / intCount, 1, MidpointRounding.AwayFromZero);
            else
                drw["TestAverage"] = DBNull.Value;

            // nếu có tbkt thì + chia đôi, không thì chia 1
            if (intCount > 0)
                intCount = 2;
            else
                intCount = 1;

            // Tính TMK dựa vào điểm thi
            if (drw["Exam1"].ToString() != "")
            {
                dblExam1 = Convert.ToDouble(drw["Exam1"]);
                dblSummary1 = Math.Round((dblTBKT.Value + dblExam1.Value) / intCount, 1, MidpointRounding.AwayFromZero);

            }
            if (drw["Exam2"].ToString() != "")
            {
                dblExam2 = Convert.ToDouble(drw["Exam2"]);
                dblSummary2 = Math.Round((dblTBKT.Value + dblExam2.Value) / intCount, 1, MidpointRounding.AwayFromZero);
            }
            if (drw["Exam3"].ToString() != "")
            {
                dblExam3 = Convert.ToDouble(drw["Exam3"]);
                dblSummary3 = Math.Round((dblTBKT.Value + dblExam3.Value) / intCount, 1, MidpointRounding.AwayFromZero);
            }



            if (dblSummary1 != null)
                drw["Summary1"] = dblSummary1;
            else
                drw["Summary1"] = DBNull.Value;

            if (dblSummary2 != null)
                drw["Summary2"] = dblSummary2;
            else
                drw["Summary2"] = DBNull.Value;

            if (dblSummary3 != null)
                drw["Summary3"] = dblSummary3;
            else
                drw["Summary3"] = DBNull.Value;


            // Xét tổng kết môn cuối cùng
            double? dblFinalSummary = dblSummary1;

            if (dblSummary2 > dblFinalSummary)
                dblFinalSummary = dblSummary2;
            if (dblSummary3 > dblFinalSummary)
                dblFinalSummary = dblSummary3;

            if (dblFinalSummary != null)
                drw["FinalSummary"] = dblFinalSummary;
            else
                drw["FinalSummary"] = DBNull.Value;

            // có quy định điểm tối thiểu trong môn học thì xét theo, không thì mặc định là 5
            double dblRequestMinMark = 5;
            if (drw["RequestMinMark"].ToString() != "" && drw["RequestMinMark"].ToString() != "0")
                dblRequestMinMark = Convert.ToDouble(drw["RequestMinMark"]);

            // tính đạt môn :  TKM >=5
            if (dblFinalSummary != null)
            {
                if (dblFinalSummary >= dblRequestMinMark)
                    drw["Passed"] = 1;
                else
                    drw["Passed"] = 0;
            }
            else
                drw["Passed"] = DBNull.Value;
        }  // End TotalRow40

        public static void TotalRow46(DataRow drw)
        {
            double? dblTBKT = 0, dblExam1 = null, dblExam2 = null, dblExam3 = null, dblSummary1 = null, dblSummary2 = null, dblSummary3 = null;
            int intCount = 0;
            int intMark1Number = Convert.ToInt32(drw["Mark1Number"]);
            int intMark2Number = Convert.ToInt32(drw["Mark2Number"]);

            // Tính TBKT luôn 2 hệ số           
            for (int i = 1; i <= 25 && i <= intMark1Number; i++)
            {
                {
                    string strValue = drw["Mark1" + i.ToString()].ToString();
                    if (strValue != "")
                        dblTBKT += Convert.ToDouble(strValue); //nhân hệ số                                            

                    // nếu có điểm thì tăng số cột, nếu học lại thì chỉ tăng cột khi có nhập điểm (học lại thì không cần đủ số cột)
                    //if (Convert.ToInt32(drw["OrderLearning"]) < 2 || strValue != "")
                    if (strValue != "")
                        intCount++; // tính đủ số cột
                }
            }

            for (int i = 1; i <= 25 && i <= intMark2Number; i++)
            {
                {
                    string strValue = drw["Mark2" + i.ToString()].ToString();
                    if (strValue != "")
                        dblTBKT += Convert.ToDouble(strValue) * 2; //nhân hệ số

                    // nếu có điểm thì tăng số cột, nếu học lại thì chỉ tăng cột khi có nhập điểm (học lại thì không cần đủ số cột)
                    //if (Convert.ToInt32(drw["OrderLearning"]) < 2 || strValue != "")
                    if (strValue != "")
                        intCount += 2; // tính đủ số cột
                }
            }

            if (intCount > 0)
                drw["TestAverage"] = dblTBKT = Math.Round(dblTBKT.Value / intCount, 1, MidpointRounding.AwayFromZero);
            else
                drw["TestAverage"] = DBNull.Value;

            // nếu có tbkt thì + chia đôi, không thì chia 1
            if (intCount > 0)
                intCount = 2;
            else
                intCount = 1;

            // Tính TMK dựa vào điểm thi
            if (drw["Exam1"].ToString() != "")
            {
                dblExam1 = Convert.ToDouble(drw["Exam1"]);
                dblSummary1 = Math.Round((dblTBKT.Value + dblExam1.Value) / intCount, 1, MidpointRounding.AwayFromZero);

            }
            if (drw["Exam2"].ToString() != "")
            {
                dblExam2 = Convert.ToDouble(drw["Exam2"]);
                dblSummary2 = Math.Round((dblTBKT.Value + dblExam2.Value) / intCount, 1, MidpointRounding.AwayFromZero);
            }
            if (drw["Exam3"].ToString() != "")
            {
                dblExam3 = Convert.ToDouble(drw["Exam3"]);
                dblSummary3 = Math.Round((dblTBKT.Value + dblExam3.Value) / intCount, 1, MidpointRounding.AwayFromZero);
            }



            if (dblSummary1 != null)
                drw["Summary1"] = dblSummary1;
            else
                drw["Summary1"] = DBNull.Value;

            if (dblSummary2 != null)
                drw["Summary2"] = dblSummary2;
            else
                drw["Summary2"] = DBNull.Value;

            if (dblSummary3 != null)
                drw["Summary3"] = dblSummary3;
            else
                drw["Summary3"] = DBNull.Value;


            // Xét tổng kết môn cuối cùng
            double? dblFinalSummary = dblSummary1;

            if (dblSummary2 > dblFinalSummary)
                dblFinalSummary = dblSummary2;
            if (dblSummary3 > dblFinalSummary)
                dblFinalSummary = dblSummary3;

            if (dblFinalSummary != null)
                drw["FinalSummary"] = dblFinalSummary;
            else
                drw["FinalSummary"] = DBNull.Value;


            // có quy định điểm tối thiểu trong môn học thì xét theo, không thì mặc định là 5
            double dblRequestMinMark = 5;
            if (drw["RequestMinMark"].ToString() != "" && drw["RequestMinMark"].ToString() != "0")
                dblRequestMinMark = Convert.ToDouble(drw["RequestMinMark"]);

            // tính đạt môn :  TKM >=5
            if (dblFinalSummary != null)
            {
                if (dblFinalSummary >= dblRequestMinMark)
                    drw["Passed"] = 1;
                else
                    drw["Passed"] = 0;
            }
            else
                drw["Passed"] = DBNull.Value;
        } // End TotalRow46

        /// <summary>
        /// Các hệ số tương ứng trong Class_Subject là 1,2,3,4
        /// </summary>
        /// <param name="drw"></param>
        public static void TotalRow43(DataRow drw)
        {
            double? dblExam1 = null, dblExam2 = null, dblExam3 = null, dblSummary1 = null, dblSummary2 = null, dblSummary3 = null, dblTestAverage = null;
            double? dblMark11 = null, dblMark12 = null; // Nhận thức và Chuyên cần
            double dblMarkRatio1 = Convert.ToDouble(drw["MarkRatio1"]);
            double dblMarkRatio2 = Convert.ToDouble(drw["MarkRatio2"]);
            double dblMarkRatio3 = Convert.ToDouble(drw["MarkRatio3"]);
            double dblMarkRatio4 = Convert.ToDouble(drw["MarkRatio4"]);

            // Điểm nhận thức, Điểm chuyên cần------------------------------------------------------------
            if (drw["Mark11"] != null && drw["Mark11"].ToString() != "")
                dblMark11 = Convert.ToDouble(drw["Mark11"]);
            if (drw["Mark11"] != null && drw["Mark12"].ToString() != "")
                dblMark12 = Convert.ToDouble(drw["Mark12"]);


            // Tính TBKT với điểm của hệ số 2-------------------------------------------------
            int intCount = 0;
            double? dblTBKT = 0;

            for (int a = 1; a < 3; a++)
            {
                for (int i = 1; i < 7; i++)
                {
                    string strValue = drw["Mark2" + i.ToString()].ToString();
                    if (strValue != "")
                    {
                        dblTBKT += Convert.ToDouble(strValue);
                        intCount++;
                    }
                }
            }

            if (intCount > 0)
                drw["TestAverage"] = dblTestAverage = Math.Round(dblTBKT.Value / intCount, 1, MidpointRounding.AwayFromZero);
            else
                drw["TestAverage"] = DBNull.Value;




            // Tính TMK dựa vào điểm thi và TBKT và điểm Nhận thức và chuyên cần.---------------------------------            
            double dblSum = 0;
            double dblSumRatio = 0;
            if (dblMark11 != null)
            {
                dblSum = dblMark11.Value * dblMarkRatio1;
                dblSumRatio = dblMarkRatio1;
            }
            if (dblMark12 != null)
            {
                dblSum += dblMark12.Value * dblMarkRatio2;
                dblSumRatio += dblMarkRatio2;
            }
            if (dblTestAverage != null)
            {
                dblSum += dblTestAverage.Value * dblMarkRatio3;
                dblSumRatio += dblMarkRatio3;
            }


            if (drw["Exam1"].ToString() != "")
            {
                dblExam1 = Convert.ToDouble(drw["Exam1"]);
                dblSummary1 = Math.Round((dblSum + dblExam1.Value * dblMarkRatio4) / (dblSumRatio + dblMarkRatio4), 1, MidpointRounding.AwayFromZero);
            }
            if (drw["Exam2"].ToString() != "" && dblTestAverage != null)
            {
                dblExam2 = Convert.ToDouble(drw["Exam2"]);
                dblSummary2 = Math.Round((dblSum + dblExam2.Value * dblMarkRatio4) / (dblSumRatio + dblMarkRatio4), 1, MidpointRounding.AwayFromZero);
            }
            if (drw["Exam3"].ToString() != "" && dblTestAverage != null)
            {
                dblExam3 = Convert.ToDouble(drw["Exam3"]);
                dblSummary3 = Math.Round((dblSum + dblExam3.Value * dblMarkRatio4) / (dblSumRatio + dblMarkRatio4), 1, MidpointRounding.AwayFromZero);
            }



            if (dblSummary1 != null)
                drw["Summary1"] = dblSummary1;
            else
                drw["Summary1"] = DBNull.Value;

            if (dblSummary2 != null)
                drw["Summary2"] = dblSummary2;
            else
                drw["Summary2"] = DBNull.Value;

            if (dblSummary3 != null)
                drw["Summary3"] = dblSummary3;
            else
                drw["Summary3"] = DBNull.Value;


            // Xét tổng kết môn cuối cùng
            double? dblFinalSummary = dblSummary1;

            if (dblSummary2 > dblFinalSummary)
                dblFinalSummary = dblSummary2;
            if (dblSummary3 > dblFinalSummary)
                dblFinalSummary = dblSummary3;

            if (dblFinalSummary != null)
                drw["FinalSummary"] = dblFinalSummary;
            else
                drw["FinalSummary"] = DBNull.Value;


            // Xét Điểm số A,B,C,D, F
            if (dblFinalSummary >= 8.5)
            {
                drw["LearningLevel"] = "A";
                drw["OtherFinalSummary"] = 4;
                drw["Passed"] = 1;
            }
            else if (dblFinalSummary >= 7)
            {
                drw["LearningLevel"] = "B";
                drw["OtherFinalSummary"] = 3;
                drw["Passed"] = 1;
            }
            else if (dblFinalSummary >= 5.5)
            {
                drw["LearningLevel"] = "C";
                drw["OtherFinalSummary"] = 2;
                drw["Passed"] = 1;
            }
            else if (dblFinalSummary >= 4)
            {
                drw["LearningLevel"] = "D";
                drw["OtherFinalSummary"] = 1;
                drw["Passed"] = 1;
            }
            else
            {
                drw["LearningLevel"] = "F";
                drw["OtherFinalSummary"] = 0;
                drw["Passed"] = 0;
            }


        } // End TotalRow46

        /// <summary>
        /// Cột Điểm TP = TestAverage và ứng với hệ số MarkRatio1 trong Class_Subject
        /// Cột điểm thi có hệ số là MarkRatio2 trong Class_subject
        /// </summary>
        /// <param name="drw"></param>
        public static void TotalRow25(DataRow drw)
        {
            double? dblExam1 = null, dblExam2 = null, dblExam3 = null, dblSummary1 = null, dblSummary2 = null, dblSummary3 = null, dblTestAverage = null;

            double dblMarkRatio1 = 1;
            double dblMarkRatio2 = 1;

            if (drw["MarkRatio1"].ToString() != "" && drw["MarkRatio2"].ToString() != "")
            {
                dblMarkRatio1 = Convert.ToDouble(drw["MarkRatio1"]);
                dblMarkRatio2 = Convert.ToDouble(drw["MarkRatio2"]);

            }

            double dblSumRatio = dblMarkRatio1 + dblMarkRatio2;

            // Tính TBKT với điểm của hệ số 2-------------------------------------------------           

            if (drw["TestAverage"].ToString() != "")
                dblTestAverage = Convert.ToDouble(drw["TestAverage"]) * dblMarkRatio1; // Điểm TP đã nhân hệ số (cột HS đầu tiên trong class_subject)
            else
                return; // chưa có điểm này thì không tính luôn.



            if (drw["Exam1"].ToString() != "")
            {
                dblExam1 = Convert.ToDouble(drw["Exam1"]);
                dblSummary1 = Math.Round((dblTestAverage.Value + dblExam1.Value * dblMarkRatio2) / dblSumRatio, 0);
            }
            if (drw["Exam2"].ToString() != "" && dblTestAverage != null)
            {
                dblExam2 = Convert.ToDouble(drw["Exam2"]);
                dblSummary2 = Math.Round((dblTestAverage.Value + dblExam2.Value * dblMarkRatio2) / dblSumRatio, 0);
            }
            if (drw["Exam3"].ToString() != "" && dblTestAverage != null)
            {
                dblExam3 = Convert.ToDouble(drw["Exam3"]);
                dblSummary3 = Math.Round((dblTestAverage.Value + dblExam3.Value * dblMarkRatio2) / dblSumRatio, 0);
            }



            if (dblSummary1 != null)
                drw["Summary1"] = dblSummary1;
            else
                drw["Summary1"] = DBNull.Value;

            if (dblSummary2 != null)
                drw["Summary2"] = dblSummary2;
            else
                drw["Summary2"] = DBNull.Value;

            if (dblSummary3 != null)
                drw["Summary3"] = dblSummary3;
            else
                drw["Summary3"] = DBNull.Value;


            // Xét tổng kết môn cuối cùng
            double? dblFinalSummary = dblSummary1;

            if (dblSummary2 > dblFinalSummary)
                dblFinalSummary = dblSummary2;
            if (dblSummary3 > dblFinalSummary)
                dblFinalSummary = dblSummary3;

            if (dblFinalSummary != null)
                drw["FinalSummary"] = dblFinalSummary;
            else
                drw["FinalSummary"] = DBNull.Value;

            // có quy định điểm tối thiểu trong môn học thì xét theo, không thì mặc định là 5
            double dblRequestMinMark = 5;
            if (drw["RequestMinMark"].ToString() != "" && drw["RequestMinMark"].ToString() != "0")
                dblRequestMinMark = Convert.ToDouble(drw["RequestMinMark"]);

            // tính đạt môn : Thi >=5 và TKM >=5
            if (dblFinalSummary != null) // có thi lần 1 mới tính
            {
                if ((dblExam1 >= dblRequestMinMark || dblExam2 >= dblRequestMinMark) && (dblFinalSummary >= dblRequestMinMark))
                    drw["Passed"] = 1;
                else
                    drw["Passed"] = 0;
            }
            else
                drw["Passed"] = DBNull.Value;

        } // End TotalRow25

        #endregion

        #region Thông tư 09 - 2017

        /// <summary>
        /// Trung cấp, cao đẳng chuyên nghiệp 2017
        /// TBM = (TBKT*4 + Thi * 6)/10
        /// </summary>
        /// <param name="drw"></param>
        public static void TotalRow09(DataRow drw)
        {
            double? dblTBKT = 0, dblExam1 = null, dblExam2 = null, dblExam3 = null, dblSummary1 = null, dblSummary2 = null, dblSummary3 = null;
            int intCount = 0;
            int intMark1Number = Convert.ToInt32(drw["Mark1Number"]);
            int intMark2Number = Convert.ToInt32(drw["Mark2Number"]);

            // Tính TBKT luôn 2 hệ số           
            for (int i = 1; i <= 25 && i <= intMark1Number; i++)
            {
                {
                    string strValue = drw["Mark1" + i.ToString()].ToString();
                    if (strValue != "")
                        dblTBKT += Convert.ToDouble(strValue); //nhân hệ số                                            

                    // nếu có điểm thì tăng số cột, nếu học lại thì chỉ tăng cột khi có nhập điểm (học lại thì không cần đủ số cột)
                    //if (Convert.ToInt32(drw["OrderLearning"]) < 2 || strValue != "")
                    if (strValue != "")
                        intCount++; // tính đủ số cột
                }
            }

            for (int i = 1; i <= 25 && i <= intMark2Number; i++)
            {
                {
                    string strValue = drw["Mark2" + i.ToString()].ToString();
                    if (strValue != "")
                        dblTBKT += Convert.ToDouble(strValue) * 2; //nhân hệ số

                    // nếu có điểm thì tăng số cột, nếu học lại thì chỉ tăng cột khi có nhập điểm (học lại thì không cần đủ số cột)
                    //if (Convert.ToInt32(drw["OrderLearning"]) < 2 || strValue != "")
                    if (strValue != "")
                        intCount += 2; // tính đủ số cột
                }
            }

            if (intCount > 0)
                drw["TestAverage"] = dblTBKT = Math.Round(dblTBKT.Value / intCount, 1, MidpointRounding.AwayFromZero);
            else
                drw["TestAverage"] = DBNull.Value;

            // Tính lại điểm thi nếu có thi LT-TH:  thi = (LT + TH)/2
            bool bolTheoryPracticePassed = TotalTheoryPracticeExam(drw);

            // nếu có tbkt thì + chia 10, không thì chia 6
            if (intCount > 0)
                intCount = 10;
            else
                intCount = 6;

            // Tính TMK dựa vào điểm thi
            if (drw["Exam1"].ToString() != "")
            {
                dblExam1 = Convert.ToDouble(drw["Exam1"]);
                dblSummary1 = Math.Round((dblTBKT.Value * 4 + dblExam1.Value * 6) / intCount, 1, MidpointRounding.AwayFromZero);

            }
            if (drw["Exam2"].ToString() != "")
            {
                dblExam2 = Convert.ToDouble(drw["Exam2"]);
                dblSummary2 = Math.Round((dblTBKT.Value * 4 + dblExam2.Value * 6) / intCount, 1, MidpointRounding.AwayFromZero);
            }
            if (drw["Exam3"].ToString() != "")
            {
                dblExam3 = Convert.ToDouble(drw["Exam3"]);
                dblSummary3 = Math.Round((dblTBKT.Value * 4 + dblExam3.Value * 6) / intCount, 1, MidpointRounding.AwayFromZero);
            }



            if (dblSummary1 != null)
                drw["Summary1"] = dblSummary1;
            else
                drw["Summary1"] = DBNull.Value;

            if (dblSummary2 != null)
                drw["Summary2"] = dblSummary2;
            else
                drw["Summary2"] = DBNull.Value;

            if (dblSummary3 != null)
                drw["Summary3"] = dblSummary3;
            else
                drw["Summary3"] = DBNull.Value;


            // Xét tổng kết môn cuối cùng
            double? dblFinalSummary = dblSummary1;

            if (dblSummary2 > dblFinalSummary)
                dblFinalSummary = dblSummary2;
            if (dblSummary3 > dblFinalSummary)
                dblFinalSummary = dblSummary3;

            if (dblFinalSummary != null)
                drw["FinalSummary"] = dblFinalSummary;
            else
                drw["FinalSummary"] = DBNull.Value;


            // tính đạt môn :  TKM >=5
            if (dblFinalSummary != null)
            {
                if (bolTheoryPracticePassed && dblFinalSummary >= 5) // Qui chế 09 chỉ kiểm tra tổng kết môn >=5. Còn tbkt đã ràng buộc cho học viên đủ điều kiện dự thi.
                    drw["Passed"] = 1;
                else
                    drw["Passed"] = 0;
            }
            else
                drw["Passed"] = DBNull.Value;
        }  // End TotalRow09

        /// <summary>
        /// Trung cấp, cao đẳng chuyên nghiệp 2017 theo tín chỉ
        /// Có điểm quy đổi
        /// TBM = (TBKT*4 + Thi * 6)/10
        /// </summary>
        /// <param name="drw"></param>
        public static void TotalRow09_TinChi(DataRow drw)
        {
            double? dblTBKT = 0, dblExam1 = null, dblExam2 = null, dblExam3 = null, dblSummary1 = null, dblSummary2 = null, dblSummary3 = null;
            int intMark1Number = Convert.ToInt32(drw["Mark1Number"]);
            int intMark2Number = Convert.ToInt32(drw["Mark2Number"]);
            int intCount = 0;

            bool bolHaveEmptyMark = false;

            // Tính TBKT luôn 2 hệ số           
            for (int i = 1; i <= 25 && i <= intMark1Number; i++)
            {
                {
                    string strValue = drw["Mark1" + i.ToString()].ToString();
                    if (strValue != "")
                        dblTBKT += Convert.ToDouble(strValue); //nhân hệ số      
                    else
                        bolHaveEmptyMark = true; // có cột rỗng

                    // nếu có điểm thì tăng số cột, nếu học lại thì chỉ tăng cột khi có nhập điểm (học lại thì không cần đủ số cột)
                    //if (Convert.ToInt32(drw["OrderLearning"]) < 2 || strValue != "")
                    if (strValue != "")
                        intCount++; // tính đủ số cột
                }
            }

            for (int i = 1; i <= 25 && i <= intMark2Number; i++)
            {
                {
                    string strValue = drw["Mark2" + i.ToString()].ToString();
                    if (strValue != "")
                        dblTBKT += Convert.ToDouble(strValue) * 2; //nhân hệ số
                    else
                        bolHaveEmptyMark = true; // có cột rỗng

                    // nếu có điểm thì tăng số cột, nếu học lại thì chỉ tăng cột khi có nhập điểm (học lại thì không cần đủ số cột)
                    //if (Convert.ToInt32(drw["OrderLearning"]) < 2 || strValue != "")
                    if (strValue != "")
                        intCount += 2; // tính đủ số cột
                }
            }

            if (intCount > 0)
                drw["TestAverage"] = dblTBKT = Math.Round(dblTBKT.Value / intCount, 1, MidpointRounding.AwayFromZero);
            else
                drw["TestAverage"] = DBNull.Value;

            // Tính lại điểm thi nếu có thi LT-TH:  thi = (LT + TH)/2
            bool bolTheoryPracticePassed = TotalTheoryPracticeExam(drw);

            // nếu có tbkt thì + chia 10, không thì chia 6
            if (intCount > 0)
                intCount = 10;
            else
                intCount = 6;

            // Tính TMK dựa vào điểm thi
            if (drw["Exam1"].ToString() != "")
            {
                dblExam1 = Convert.ToDouble(drw["Exam1"]);
                dblSummary1 = Math.Round((dblTBKT.Value * 4 + dblExam1.Value * 6) / intCount, 1, MidpointRounding.AwayFromZero);

            }
            if (drw["Exam2"].ToString() != "")
            {
                dblExam2 = Convert.ToDouble(drw["Exam2"]);
                dblSummary2 = Math.Round((dblTBKT.Value * 4 + dblExam2.Value * 6) / intCount, 1, MidpointRounding.AwayFromZero);
            }
            if (drw["Exam3"].ToString() != "")
            {
                dblExam3 = Convert.ToDouble(drw["Exam3"]);
                dblSummary3 = Math.Round((dblTBKT.Value * 4 + dblExam3.Value * 6) / intCount, 1, MidpointRounding.AwayFromZero);
            }


            if (dblSummary1 != null)
                drw["Summary1"] = dblSummary1;
            else
                drw["Summary1"] = DBNull.Value;

            if (dblSummary2 != null)
                drw["Summary2"] = dblSummary2;
            else
                drw["Summary2"] = DBNull.Value;

            if (dblSummary3 != null)
                drw["Summary3"] = dblSummary3;
            else
                drw["Summary3"] = DBNull.Value;


            // Xét tổng kết môn cuối cùng
            double? dblFinalSummary = dblSummary1;

            if (dblSummary2 > dblFinalSummary)
                dblFinalSummary = dblSummary2;
            if (dblSummary3 > dblFinalSummary)
                dblFinalSummary = dblSummary3;

            if (dblFinalSummary != null)
                drw["FinalSummary"] = dblFinalSummary;
            else
                drw["FinalSummary"] = DBNull.Value;


            // tính đạt môn :  TKM >=5
            if (dblFinalSummary != null)
            {
                if (bolTheoryPracticePassed && dblFinalSummary >= 4) // Qui chế 09_Tín chỉ chỉ kiểm tra tổng kết môn >= 4. Còn tbkt đã ràng buộc cho học viên đủ điều kiện dự thi.
                    drw["Passed"] = 1;
                else
                    drw["Passed"] = 0;
            }
            else
                drw["Passed"] = DBNull.Value;

            #region  Xét Điểm số A,B,C,D, F cho điểm lần 1

            if (bolHaveEmptyMark) // chưa đủ cột điểm
            {
                drw["LearningLevel1"] = "I";
                drw["OtherSummary1"] = DBNull.Value;
            }
            //else if (dblSummary1 >= 9) // A+
            //{
            //    drw["LearningLevel1"] = "A+";
            //    drw["OtherSummary1"] = 4;
            //}
            else if (dblSummary1 >= 8.5) // A
            {
                drw["LearningLevel1"] = "A";
                drw["OtherSummary1"] = 4;
            }
            //else if (dblSummary1 >= 7.8) // B+
            //{
            //    drw["LearningLevel1"] = "B+";
            //    drw["OtherSummary1"] = 3;
            //}
            else if (dblSummary1 >= 7) // B
            {
                drw["LearningLevel1"] = "B";
                drw["OtherSummary1"] = 3;
            }
            //else if (dblSummary1 >= 6.3) // C+
            //{
            //    drw["LearningLevel"] = "C+";
            //    drw["OtherSummary1"] = 2;
            //}
            else if (dblSummary1 >= 5.5) // C
            {
                drw["LearningLevel1"] = "C";
                drw["OtherSummary1"] = 2;
            }
            //else if (dblSummary1 >= 4.8) // D+
            //{
            //    drw["LearningLevel1"] = "D+";
            //    drw["OtherSummary1"] = 1;
            //}
            else if (dblSummary1 >= 4) // D
            {
                drw["LearningLevel1"] = "D";
                drw["OtherSummary1"] = 1;
            }
            else if (dblSummary1 != null) // đã có điểm không đạt
            {
                drw["LearningLevel1"] = "F";
                drw["OtherSummary1"] = 0;
            }
            else // đủ cột, chưa điểm thi
            {
                drw["LearningLevel1"] = "X";
                drw["OtherSummary1"] = DBNull.Value;

            }

            #endregion

            #region  Xét Điểm số A,B,C,D, F cho điểm lần 2

            if (bolHaveEmptyMark) // chưa đủ cột điểm
            {
                drw["LearningLevel2"] = "I";
                drw["OtherSummary2"] = DBNull.Value;
            }
            //else if (dblSummary2 >= 9) // A+
            //{
            //    drw["LearningLevel2"] = "A+";
            //    drw["OtherSummary2"] = 4;
            //}
            else if (dblSummary2 >= 8.5) // A
            {
                drw["LearningLevel2"] = "A";
                drw["OtherSummary2"] = 4;
            }
            //else if (dblSummary2 >= 7.8) // B+
            //{
            //    drw["LearningLevel2"] = "B+";
            //    drw["OtherSummary2"] = 3;
            //}
            else if (dblSummary2 >= 7) // B
            {
                drw["LearningLevel2"] = "B";
                drw["OtherSummary2"] = 3;
            }
            //else if (dblSummary2 >= 6.3) // C+
            //{
            //    drw["LearningLevel"] = "C+";
            //    drw["OtherSummary2"] = 2;
            //}
            else if (dblSummary2 >= 5.5) // C
            {
                drw["LearningLevel2"] = "C";
                drw["OtherSummary2"] = 2;
            }
            //else if (dblSummary2 >= 4.8) // D+
            //{
            //    drw["LearningLevel2"] = "D+";
            //    drw["OtherSummary2"] = 1;
            //}
            else if (dblSummary2 >= 4) // D
            {
                drw["LearningLevel2"] = "D";
                drw["OtherSummary2"] = 1;
            }
            else if (dblSummary2 != null) // đã có điểm không đạt
            {
                drw["LearningLevel2"] = "F";
                drw["OtherSummary2"] = 0;
            }
            else // đủ cột, chưa điểm thi
            {
                drw["LearningLevel2"] = "X";
                drw["OtherSummary2"] = DBNull.Value;

            }

            #endregion

            #region  Xét Điểm số A,B,C,D, F cho điểm lần 3

            if (bolHaveEmptyMark) // chưa đủ cột điểm
            {
                drw["LearningLevel3"] = "I";
                drw["OtherSummary3"] = DBNull.Value;
            }
            //else if (dblSummary3 >= 9) // A+
            //{
            //    drw["LearningLevel3"] = "A+";
            //    drw["OtherSummary3"] = 4;
            //}
            else if (dblSummary3 >= 8.5) // A
            {
                drw["LearningLevel3"] = "A";
                drw["OtherSummary3"] = 4;
            }
            //else if (dblSummary3 >= 7.8) // B+
            //{
            //    drw["LearningLevel3"] = "B+";
            //    drw["OtherSummary3"] = 3;
            //}
            else if (dblSummary3 >= 7) // B
            {
                drw["LearningLevel3"] = "B";
                drw["OtherSummary3"] = 3;
            }
            //else if (dblSummary3 >= 6.3) // C+
            //{
            //    drw["LearningLevel"] = "C+";
            //    drw["OtherSummary3"] = 2;
            //}
            else if (dblSummary3 >= 5.5) // C
            {
                drw["LearningLevel3"] = "C";
                drw["OtherSummary3"] = 2;
            }
            //else if (dblSummary3 >= 4.8) // D+
            //{
            //    drw["LearningLevel3"] = "D+";
            //    drw["OtherSummary3"] = 1;
            //}
            else if (dblSummary3 >= 4) // D
            {
                drw["LearningLevel3"] = "D";
                drw["OtherSummary3"] = 1;
            }
            else if (dblSummary3 != null) // đã có điểm không đạt
            {
                drw["LearningLevel3"] = "F";
                drw["OtherSummary3"] = 0;
            }
            else // đủ cột, chưa điểm thi
            {
                drw["LearningLevel3"] = "X";
                drw["OtherSummary3"] = DBNull.Value;

            }

            #endregion

            #region  Xét Điểm số A,B,C,D, F

            if (bolHaveEmptyMark) // chưa đủ cột điểm
            {
                drw["LearningLevel"] = "I";
                drw["OtherFinalSummary"] = DBNull.Value;
            }
            //else if (dblFinalSummary >= 9) // A+
            //{
            //    drw["LearningLevel"] = "A+";
            //    drw["OtherFinalSummary"] = 4;
            //}
            else if (dblFinalSummary >= 8.5) // A
            {
                drw["LearningLevel"] = "A";
                drw["OtherFinalSummary"] = 4;
            }
            //else if (dblFinalSummary >= 7.8) // B+
            //{
            //    drw["LearningLevel"] = "B+";
            //    drw["OtherFinalSummary"] = 3;
            //}
            else if (dblFinalSummary >= 7) // B
            {
                drw["LearningLevel"] = "B";
                drw["OtherFinalSummary"] = 3;
            }
            //else if (dblFinalSummary >= 6.3) // C+
            //{
            //    drw["LearningLevel"] = "C+";
            //    drw["OtherFinalSummary"] = 2;
            //}
            else if (dblFinalSummary >= 5.5) // C
            {
                drw["LearningLevel"] = "C";
                drw["OtherFinalSummary"] = 2;
            }
            //else if (dblFinalSummary >= 4.8) // D+
            //{
            //    drw["LearningLevel"] = "D+";
            //    drw["OtherFinalSummary"] = 1;
            //}
            else if (dblFinalSummary >= 4) // D
            {
                drw["LearningLevel"] = "D";
                drw["OtherFinalSummary"] = 1;
            }
            else if (dblFinalSummary != null) // đã có điểm không đạt
            {
                drw["LearningLevel"] = "F";
                drw["OtherFinalSummary"] = 0;
            }
            else // đủ cột, chưa điểm thi
            {
                drw["LearningLevel"] = "X";
                drw["OtherFinalSummary"] = DBNull.Value;
            }

            #endregion


        }  // End TotalRow99

        private static void TotalRow09_TinChi_OldData(DataRow drw)
        {
            double? dblSummary1 = null, dblSummary2 = null, dblSummary3 = null;
            if (drw["Summary1"].ToString() != "")
                dblSummary1 = Convert.ToDouble(drw["Summary1"]);
            if (drw["Summary2"].ToString() != "")
                dblSummary2 = Convert.ToDouble(drw["Summary2"]);
            if (drw["Summary3"].ToString() != "")
                dblSummary3 = Convert.ToDouble(drw["Summary3"]);

            // Xét tổng kết môn cuối cùng
            double? dblFinalSummary = dblSummary1;

            if (dblSummary2 > dblFinalSummary)
                dblFinalSummary = dblSummary2;
            if (dblSummary3 > dblFinalSummary)
                dblFinalSummary = dblSummary3;

            if (dblFinalSummary != null)
                drw["FinalSummary"] = dblFinalSummary;
            else
                drw["FinalSummary"] = DBNull.Value;


            // có quy định điểm tối thiểu trong môn học thì xét theo, không thì mặc định là 40 (theo thang 100)
            double dblRequestMinMark = 4;
            try
            {
                if (drw["RequestMinMark"].ToString() != "" && drw["RequestMinMark"].ToString() != "0")
                    dblRequestMinMark = Convert.ToDouble(drw["RequestMinMark"]);
            }
            catch { }



            #region Tổng kết điểm lớn nhất

            // tính đạt môn :  TKM >= Min
            if (dblFinalSummary != null)
            {
                if (dblFinalSummary >= dblRequestMinMark) // Qui chế 100_Tín chỉ chỉ kiểm tra tổng kết môn >= 40. Còn tbkt đã ràng buộc cho học viên đủ điều kiện dự thi.
                    drw["Passed"] = 1;
                else
                    drw["Passed"] = 0;
            }
            else
                drw["Passed"] = DBNull.Value;


            if (dblFinalSummary == null) // chưa có điểm
            {
                drw["LearningLevel"] = "";
                drw["OtherFinalSummary"] = DBNull.Value;
            }
            else if (dblFinalSummary >= 8.5) // A
            {
                drw["LearningLevel"] = "A";
                drw["OtherFinalSummary"] = 4;
            }

            else if (dblFinalSummary >= 7) // B
            {
                drw["LearningLevel"] = "B";
                drw["OtherFinalSummary"] = 3;
            }

            else if (dblFinalSummary >= 5.5) // C
            {
                drw["LearningLevel"] = "C";
                drw["OtherFinalSummary"] = 2;
            }

            else if (dblFinalSummary >= 4) // D
            {
                drw["LearningLevel"] = "D";
                drw["OtherFinalSummary"] = 1;
            }
            else // đã có điểm không đạt
            {
                drw["LearningLevel"] = "F";
                drw["OtherFinalSummary"] = 0;
            }

            #endregion


            #region Quy đổi điểm chữ cho TMK lần 1

            if (dblSummary1 == null) // ko có tổng kết lần 1
            {
                drw["LearningLevel1"] = "";
                drw["OtherSummary1"] = DBNull.Value;
            }
            else if (dblSummary1 >= 8.5) // A
            {
                drw["LearningLevel1"] = "A";
                drw["OtherSummary1"] = 4;
            }

            else if (dblSummary1 >= 7) // B
            {
                drw["LearningLevel1"] = "B";
                drw["OtherSummary1"] = 3;
            }

            else if (dblSummary1 >= 5.5) // C
            {
                drw["LearningLevel1"] = "C";
                drw["OtherSummary1"] = 2;
            }

            else if (dblSummary1 >= 4) // D
            {
                drw["LearningLevel1"] = "D";
                drw["OtherSummary1"] = 1;
            }
            else // đã có điểm không đạt
            {
                drw["LearningLevel1"] = "F";
                drw["OtherSummary1"] = 0;
            }

            #endregion


            #region Quy đổi điểm chữ cho TMK lần 2


            if (dblSummary2 == null) // ko có tổng kết lần 2
            {
                drw["LearningLevel2"] = "";
                drw["OtherSummary2"] = DBNull.Value;
            }
            else if (dblSummary2 >= 8.5) // A
            {
                drw["LearningLevel2"] = "A";
                drw["OtherSummary2"] = 4;
            }

            else if (dblSummary2 >= 7) // B
            {
                drw["LearningLevel2"] = "B";
                drw["OtherSummary2"] = 3;
            }

            else if (dblSummary2 >= 5.5) // C
            {
                drw["LearningLevel2"] = "C";
                drw["OtherSummary2"] = 2;
            }

            else if (dblSummary2 >= 4) // D
            {
                drw["LearningLevel2"] = "D";
                drw["OtherSummary2"] = 1;
            }
            else // đã có điểm không đạt
            {
                drw["LearningLevel2"] = "F";
                drw["OtherSummary2"] = 0;
            }

            #endregion
        }

        /// <summary>
        /// Trung cấp, cao đẳng chuyên nghiệp 2017
        /// TBM = (TBKT*4 + Thi * 6)/10
        /// Copy y chang 09 niên cế
        /// </summary>
        /// <param name="drw"></param>
        public static void TotalRow09_VanHoa(DataRow drw)
        {
            double? dblTBKT = 0, dblExam1 = null, dblExam2 = null, dblExam3 = null, dblSummary1 = null, dblSummary2 = null, dblSummary3 = null;
            int intCount = 0;
            int intMark1Number = Convert.ToInt32(drw["Mark1Number"]);
            int intMark2Number = Convert.ToInt32(drw["Mark2Number"]);

            // Tính TBKT luôn 2 hệ số           
            for (int i = 1; i <= 25 && i <= intMark1Number; i++)
            {
                {
                    string strValue = drw["Mark1" + i.ToString()].ToString();
                    if (strValue != "")
                        dblTBKT += Convert.ToDouble(strValue); //nhân hệ số                                            

                    // nếu có điểm thì tăng số cột, nếu học lại thì chỉ tăng cột khi có nhập điểm (học lại thì không cần đủ số cột)
                    //if (Convert.ToInt32(drw["OrderLearning"]) < 2 || strValue != "")
                    if (strValue != "")
                        intCount++; // tính đủ số cột
                }
            }

            for (int i = 1; i <= 25 && i <= intMark2Number; i++)
            {
                {
                    string strValue = drw["Mark2" + i.ToString()].ToString();
                    if (strValue != "")
                        dblTBKT += Convert.ToDouble(strValue) * 2; //nhân hệ số

                    // nếu có điểm thì tăng số cột, nếu học lại thì chỉ tăng cột khi có nhập điểm (học lại thì không cần đủ số cột)
                    //if (Convert.ToInt32(drw["OrderLearning"]) < 2 || strValue != "")
                    if (strValue != "")
                        intCount += 2; // tính đủ số cột
                }
            }

            if (intCount > 0)
                drw["TestAverage"] = dblTBKT = Math.Round(dblTBKT.Value / intCount, 1, MidpointRounding.AwayFromZero);
            else
                drw["TestAverage"] = DBNull.Value;

            // Tính lại điểm thi nếu có thi LT-TH:  thi = (LT + TH)/2
            bool bolTheoryPracticePassed = TotalTheoryPracticeExam(drw);

            // nếu có tbkt thì + chia 10, không thì chia 6
            if (intCount > 0)
                intCount = 10;
            else
                intCount = 6;

            // Tính TMK dựa vào điểm thi
            if (drw["Exam1"].ToString() != "")
            {
                dblExam1 = Convert.ToDouble(drw["Exam1"]);
                dblSummary1 = Math.Round((dblTBKT.Value * 4 + dblExam1.Value * 6) / intCount, 1, MidpointRounding.AwayFromZero);

            }
            if (drw["Exam2"].ToString() != "")
            {
                dblExam2 = Convert.ToDouble(drw["Exam2"]);
                dblSummary2 = Math.Round((dblTBKT.Value * 4 + dblExam2.Value * 6) / intCount, 1, MidpointRounding.AwayFromZero);
            }
            if (drw["Exam3"].ToString() != "")
            {
                dblExam3 = Convert.ToDouble(drw["Exam3"]);
                dblSummary3 = Math.Round((dblTBKT.Value * 4 + dblExam3.Value * 6) / intCount, 1, MidpointRounding.AwayFromZero);
            }



            if (dblSummary1 != null)
                drw["Summary1"] = dblSummary1;
            else
                drw["Summary1"] = DBNull.Value;

            if (dblSummary2 != null)
                drw["Summary2"] = dblSummary2;
            else
                drw["Summary2"] = DBNull.Value;

            if (dblSummary3 != null)
                drw["Summary3"] = dblSummary3;
            else
                drw["Summary3"] = DBNull.Value;


            // Xét tổng kết môn cuối cùng
            double? dblFinalSummary = dblSummary1;

            if (dblSummary2 > dblFinalSummary)
                dblFinalSummary = dblSummary2;
            if (dblSummary3 > dblFinalSummary)
                dblFinalSummary = dblSummary3;

            if (dblFinalSummary != null)
                drw["FinalSummary"] = dblFinalSummary;
            else
                drw["FinalSummary"] = DBNull.Value;


            // tính đạt môn :  TKM >=5
            if (dblFinalSummary != null)
            {
                if (bolTheoryPracticePassed && dblFinalSummary >= 5) // Qui chế 09 chỉ kiểm tra tổng kết môn >=5. Còn tbkt đã ràng buộc cho học viên đủ điều kiện dự thi.
                    drw["Passed"] = 1;
                else
                    drw["Passed"] = 0;
            }
            else
                drw["Passed"] = DBNull.Value;
        }  // End TotalRow09


        #endregion

        #region Thông tư 04 - 2021

        /// <summary>
        /// Trung cấp, cao đẳng chuyên nghiệp 2017
        /// TBM = (TBKT*4 + Thi * 6)/10
        /// </summary>
        /// <param name="drw"></param>
        public static void TotalRow04(DataRow drw)
        {
            double? dblTBKT = 0, dblExam1 = null, dblExam2 = null, dblExam3 = null, dblSummary1 = null, dblSummary2 = null, dblSummary3 = null;
            int intCount = 0;
            int intMark1Number = Convert.ToInt32(drw["Mark1Number"]);
            int intMark2Number = Convert.ToInt32(drw["Mark2Number"]);

            // Tính TBKT luôn 2 hệ số           
            for (int i = 1; i <= 25 && i <= intMark1Number; i++)
            {
                {
                    string strValue = drw["Mark1" + i.ToString()].ToString();
                    if (strValue != "")
                        dblTBKT += Convert.ToDouble(strValue); //nhân hệ số                                            

                    // nếu có điểm thì tăng số cột, nếu học lại thì chỉ tăng cột khi có nhập điểm (học lại thì không cần đủ số cột)
                    //if (Convert.ToInt32(drw["OrderLearning"]) < 2 || strValue != "")
                    if (strValue != "")
                        intCount++; // tính đủ số cột
                }
            }

            for (int i = 1; i <= 25 && i <= intMark2Number; i++)
            {
                {
                    string strValue = drw["Mark2" + i.ToString()].ToString();
                    if (strValue != "")
                        dblTBKT += Convert.ToDouble(strValue) * 2; //nhân hệ số

                    // nếu có điểm thì tăng số cột, nếu học lại thì chỉ tăng cột khi có nhập điểm (học lại thì không cần đủ số cột)
                    //if (Convert.ToInt32(drw["OrderLearning"]) < 2 || strValue != "")
                    if (strValue != "")
                        intCount += 2; // tính đủ số cột
                }
            }

            if (intCount > 0)
                drw["TestAverage"] = dblTBKT = Math.Round(dblTBKT.Value / intCount, 1, MidpointRounding.AwayFromZero);
            else
                drw["TestAverage"] = DBNull.Value;

            // Tính lại điểm thi nếu có thi LT-TH:  thi = (LT + TH)/2
            bool bolTheoryPracticePassed = TotalTheoryPracticeExam(drw);

            // nếu có tbkt thì + chia 10, không thì chia 6
            if (intCount > 0)
                intCount = 10;
            else
                intCount = 6;

            // Tính TMK dựa vào điểm thi
            if (drw["Exam1"].ToString() != "")
            {
                dblExam1 = Convert.ToDouble(drw["Exam1"]);
                dblSummary1 = Math.Round((dblTBKT.Value * 4 + dblExam1.Value * 6) / intCount, 1, MidpointRounding.AwayFromZero);

            }
            if (drw["Exam2"].ToString() != "")
            {
                dblExam2 = Convert.ToDouble(drw["Exam2"]);
                dblSummary2 = Math.Round((dblTBKT.Value * 4 + dblExam2.Value * 6) / intCount, 1, MidpointRounding.AwayFromZero);
            }
            if (drw["Exam3"].ToString() != "")
            {
                dblExam3 = Convert.ToDouble(drw["Exam3"]);
                dblSummary3 = Math.Round((dblTBKT.Value * 4 + dblExam3.Value * 6) / intCount, 1, MidpointRounding.AwayFromZero);
            }



            if (dblSummary1 != null)
                drw["Summary1"] = dblSummary1;
            else
                drw["Summary1"] = DBNull.Value;

            if (dblSummary2 != null)
                drw["Summary2"] = dblSummary2;
            else
                drw["Summary2"] = DBNull.Value;

            if (dblSummary3 != null)
                drw["Summary3"] = dblSummary3;
            else
                drw["Summary3"] = DBNull.Value;


            // Xét tổng kết môn cuối cùng
            double? dblFinalSummary = dblSummary1;

            if (dblSummary2 > dblFinalSummary)
                dblFinalSummary = dblSummary2;
            if (dblSummary3 > dblFinalSummary)
                dblFinalSummary = dblSummary3;

            if (dblFinalSummary != null)
                drw["FinalSummary"] = dblFinalSummary;
            else
                drw["FinalSummary"] = DBNull.Value;


            // tính đạt môn :  TKM >=5
            if (dblFinalSummary != null)
            {
                if (bolTheoryPracticePassed && dblFinalSummary >= 5) // Qui chế 09 chỉ kiểm tra tổng kết môn >=5. Còn tbkt đã ràng buộc cho học viên đủ điều kiện dự thi.
                    drw["Passed"] = 1;
                else
                    drw["Passed"] = 0;
            }
            else
                drw["Passed"] = DBNull.Value;
        }  // End TotalRow09

        /// <summary>
        /// Trung cấp, cao đẳng chuyên nghiệp 2017 theo tín chỉ
        /// Có điểm quy đổi
        /// TBM = (TBKT*4 + Thi * 6)/10
        /// </summary>
        /// <param name="drw"></param>
        public static void TotalRow04_TinChi(DataRow drw)
        {
            double? dblTBKT = 0, dblExam1 = null, dblExam2 = null, dblExam3 = null, dblSummary1 = null, dblSummary2 = null, dblSummary3 = null;
            int intMark1Number = Convert.ToInt32(drw["Mark1Number"]);
            int intMark2Number = Convert.ToInt32(drw["Mark2Number"]);
            int intCount = 0;

            bool bolHaveEmptyMark = false;

            // Tính TBKT luôn 2 hệ số           
            for (int i = 1; i <= 25 && i <= intMark1Number; i++)
            {
                {
                    string strValue = drw["Mark1" + i.ToString()].ToString();
                    if (strValue != "")
                        dblTBKT += Convert.ToDouble(strValue); //nhân hệ số      
                    else
                        bolHaveEmptyMark = true; // có cột rỗng

                    // nếu có điểm thì tăng số cột, nếu học lại thì chỉ tăng cột khi có nhập điểm (học lại thì không cần đủ số cột)
                    //if (Convert.ToInt32(drw["OrderLearning"]) < 2 || strValue != "")
                    if (strValue != "")
                        intCount++; // tính đủ số cột
                }
            }

            for (int i = 1; i <= 25 && i <= intMark2Number; i++)
            {
                {
                    string strValue = drw["Mark2" + i.ToString()].ToString();
                    if (strValue != "")
                        dblTBKT += Convert.ToDouble(strValue) * 2; //nhân hệ số
                    else
                        bolHaveEmptyMark = true; // có cột rỗng

                    // nếu có điểm thì tăng số cột, nếu học lại thì chỉ tăng cột khi có nhập điểm (học lại thì không cần đủ số cột)
                    //if (Convert.ToInt32(drw["OrderLearning"]) < 2 || strValue != "")
                    if (strValue != "")
                        intCount += 2; // tính đủ số cột
                }
            }

            if (intCount > 0)
                drw["TestAverage"] = dblTBKT = Math.Round(dblTBKT.Value / intCount, 1, MidpointRounding.AwayFromZero);
            else
                drw["TestAverage"] = DBNull.Value;

            // Tính lại điểm thi nếu có thi LT-TH:  thi = (LT + TH)/2
            bool bolTheoryPracticePassed = TotalTheoryPracticeExam(drw);

            // nếu có tbkt thì + chia 10, không thì chia 6
            if (intCount > 0)
                intCount = 10;
            else
                intCount = 6;

            // Tính TMK dựa vào điểm thi
            if (drw["Exam1"].ToString() != "")
            {
                dblExam1 = Convert.ToDouble(drw["Exam1"]);
                dblSummary1 = Math.Round((dblTBKT.Value * 4 + dblExam1.Value * 6) / intCount, 1, MidpointRounding.AwayFromZero);

            }
            if (drw["Exam2"].ToString() != "")
            {
                dblExam2 = Convert.ToDouble(drw["Exam2"]);
                dblSummary2 = Math.Round((dblTBKT.Value * 4 + dblExam2.Value * 6) / intCount, 1, MidpointRounding.AwayFromZero);
            }
            if (drw["Exam3"].ToString() != "")
            {
                dblExam3 = Convert.ToDouble(drw["Exam3"]);
                dblSummary3 = Math.Round((dblTBKT.Value * 4 + dblExam3.Value * 6) / intCount, 1, MidpointRounding.AwayFromZero);
            }


            if (dblSummary1 != null)
                drw["Summary1"] = dblSummary1;
            else
                drw["Summary1"] = DBNull.Value;

            if (dblSummary2 != null)
                drw["Summary2"] = dblSummary2;
            else
                drw["Summary2"] = DBNull.Value;

            if (dblSummary3 != null)
                drw["Summary3"] = dblSummary3;
            else
                drw["Summary3"] = DBNull.Value;


            // Xét tổng kết môn cuối cùng
            double? dblFinalSummary = dblSummary1;

            if (dblSummary2 > dblFinalSummary)
                dblFinalSummary = dblSummary2;
            if (dblSummary3 > dblFinalSummary)
                dblFinalSummary = dblSummary3;

            if (dblFinalSummary != null)
                drw["FinalSummary"] = dblFinalSummary;
            else
                drw["FinalSummary"] = DBNull.Value;


            // tính đạt môn :  TKM >=5
            if (dblFinalSummary != null)
            {
                if (bolTheoryPracticePassed && dblFinalSummary >= 4) // Qui chế 09_Tín chỉ chỉ kiểm tra tổng kết môn >= 4. Còn tbkt đã ràng buộc cho học viên đủ điều kiện dự thi.
                    drw["Passed"] = 1;
                else
                    drw["Passed"] = 0;
            }
            else
                drw["Passed"] = DBNull.Value;

            #region  Xét Điểm số A,B,C,D, F cho điểm lần 1

            if (bolHaveEmptyMark) // chưa đủ cột điểm
            {
                drw["LearningLevel1"] = "I";
                drw["OtherSummary1"] = DBNull.Value;
            }
            //else if (dblSummary1 >= 9) // A+
            //{
            //    drw["LearningLevel1"] = "A+";
            //    drw["OtherSummary1"] = 4;
            //}
            else if (dblSummary1 >= 8.5) // A
            {
                drw["LearningLevel1"] = "A";
                drw["OtherSummary1"] = 4;
            }
            //else if (dblSummary1 >= 7.8) // B+
            //{
            //    drw["LearningLevel1"] = "B+";
            //    drw["OtherSummary1"] = 3;
            //}
            else if (dblSummary1 >= 7) // B
            {
                drw["LearningLevel1"] = "B";
                drw["OtherSummary1"] = 3;
            }
            //else if (dblSummary1 >= 6.3) // C+
            //{
            //    drw["LearningLevel"] = "C+";
            //    drw["OtherSummary1"] = 2;
            //}
            else if (dblSummary1 >= 5.5) // C
            {
                drw["LearningLevel1"] = "C";
                drw["OtherSummary1"] = 2;
            }
            //else if (dblSummary1 >= 4.8) // D+
            //{
            //    drw["LearningLevel1"] = "D+";
            //    drw["OtherSummary1"] = 1;
            //}
            else if (dblSummary1 >= 4) // D
            {
                drw["LearningLevel1"] = "D";
                drw["OtherSummary1"] = 1;
            }
            else if (dblSummary1 != null) // đã có điểm không đạt
            {
                drw["LearningLevel1"] = "F";
                drw["OtherSummary1"] = 0;
            }
            else // đủ cột, chưa điểm thi
            {
                drw["LearningLevel1"] = "X";
                drw["OtherSummary1"] = DBNull.Value;

            }

            #endregion

            #region  Xét Điểm số A,B,C,D, F cho điểm lần 2

            if (bolHaveEmptyMark) // chưa đủ cột điểm
            {
                drw["LearningLevel2"] = "I";
                drw["OtherSummary2"] = DBNull.Value;
            }
            //else if (dblSummary2 >= 9) // A+
            //{
            //    drw["LearningLevel2"] = "A+";
            //    drw["OtherSummary2"] = 4;
            //}
            else if (dblSummary2 >= 8.5) // A
            {
                drw["LearningLevel2"] = "A";
                drw["OtherSummary2"] = 4;
            }
            //else if (dblSummary2 >= 7.8) // B+
            //{
            //    drw["LearningLevel2"] = "B+";
            //    drw["OtherSummary2"] = 3;
            //}
            else if (dblSummary2 >= 7) // B
            {
                drw["LearningLevel2"] = "B";
                drw["OtherSummary2"] = 3;
            }
            //else if (dblSummary2 >= 6.3) // C+
            //{
            //    drw["LearningLevel"] = "C+";
            //    drw["OtherSummary2"] = 2;
            //}
            else if (dblSummary2 >= 5.5) // C
            {
                drw["LearningLevel2"] = "C";
                drw["OtherSummary2"] = 2;
            }
            //else if (dblSummary2 >= 4.8) // D+
            //{
            //    drw["LearningLevel2"] = "D+";
            //    drw["OtherSummary2"] = 1;
            //}
            else if (dblSummary2 >= 4) // D
            {
                drw["LearningLevel2"] = "D";
                drw["OtherSummary2"] = 1;
            }
            else if (dblSummary2 != null) // đã có điểm không đạt
            {
                drw["LearningLevel2"] = "F";
                drw["OtherSummary2"] = 0;
            }
            else // đủ cột, chưa điểm thi
            {
                drw["LearningLevel2"] = "X";
                drw["OtherSummary2"] = DBNull.Value;

            }

            #endregion

            #region  Xét Điểm số A,B,C,D, F cho điểm lần 3

            if (bolHaveEmptyMark) // chưa đủ cột điểm
            {
                drw["LearningLevel3"] = "I";
                drw["OtherSummary3"] = DBNull.Value;
            }
            //else if (dblSummary3 >= 9) // A+
            //{
            //    drw["LearningLevel3"] = "A+";
            //    drw["OtherSummary3"] = 4;
            //}
            else if (dblSummary3 >= 8.5) // A
            {
                drw["LearningLevel3"] = "A";
                drw["OtherSummary3"] = 4;
            }
            //else if (dblSummary3 >= 7.8) // B+
            //{
            //    drw["LearningLevel3"] = "B+";
            //    drw["OtherSummary3"] = 3;
            //}
            else if (dblSummary3 >= 7) // B
            {
                drw["LearningLevel3"] = "B";
                drw["OtherSummary3"] = 3;
            }
            //else if (dblSummary3 >= 6.3) // C+
            //{
            //    drw["LearningLevel"] = "C+";
            //    drw["OtherSummary3"] = 2;
            //}
            else if (dblSummary3 >= 5.5) // C
            {
                drw["LearningLevel3"] = "C";
                drw["OtherSummary3"] = 2;
            }
            //else if (dblSummary3 >= 4.8) // D+
            //{
            //    drw["LearningLevel3"] = "D+";
            //    drw["OtherSummary3"] = 1;
            //}
            else if (dblSummary3 >= 4) // D
            {
                drw["LearningLevel3"] = "D";
                drw["OtherSummary3"] = 1;
            }
            else if (dblSummary3 != null) // đã có điểm không đạt
            {
                drw["LearningLevel3"] = "F";
                drw["OtherSummary3"] = 0;
            }
            else // đủ cột, chưa điểm thi
            {
                drw["LearningLevel3"] = "X";
                drw["OtherSummary3"] = DBNull.Value;

            }

            #endregion

            #region  Xét Điểm số A,B,C,D, F

            if (bolHaveEmptyMark) // chưa đủ cột điểm
            {
                drw["LearningLevel"] = "I";
                drw["OtherFinalSummary"] = DBNull.Value;
            }
            //else if (dblFinalSummary >= 9) // A+
            //{
            //    drw["LearningLevel"] = "A+";
            //    drw["OtherFinalSummary"] = 4;
            //}
            else if (dblFinalSummary >= 8.5) // A
            {
                drw["LearningLevel"] = "A";
                drw["OtherFinalSummary"] = 4;
            }
            //else if (dblFinalSummary >= 7.8) // B+
            //{
            //    drw["LearningLevel"] = "B+";
            //    drw["OtherFinalSummary"] = 3;
            //}
            else if (dblFinalSummary >= 7) // B
            {
                drw["LearningLevel"] = "B";
                drw["OtherFinalSummary"] = 3;
            }
            //else if (dblFinalSummary >= 6.3) // C+
            //{
            //    drw["LearningLevel"] = "C+";
            //    drw["OtherFinalSummary"] = 2;
            //}
            else if (dblFinalSummary >= 5.5) // C
            {
                drw["LearningLevel"] = "C";
                drw["OtherFinalSummary"] = 2;
            }
            //else if (dblFinalSummary >= 4.8) // D+
            //{
            //    drw["LearningLevel"] = "D+";
            //    drw["OtherFinalSummary"] = 1;
            //}
            else if (dblFinalSummary >= 4) // D
            {
                drw["LearningLevel"] = "D";
                drw["OtherFinalSummary"] = 1;
            }
            else if (dblFinalSummary != null) // đã có điểm không đạt
            {
                drw["LearningLevel"] = "F";
                drw["OtherFinalSummary"] = 0;
            }
            else // đủ cột, chưa điểm thi
            {
                drw["LearningLevel"] = "X";
                drw["OtherFinalSummary"] = DBNull.Value;
            }

            #endregion


        }  // End TotalRow99

        private static void TotalRow04_TinChi_OldData(DataRow drw)
        {
            double? dblSummary1 = null, dblSummary2 = null, dblSummary3 = null;
            if (drw["Summary1"].ToString() != "")
                dblSummary1 = Convert.ToDouble(drw["Summary1"]);
            if (drw["Summary2"].ToString() != "")
                dblSummary2 = Convert.ToDouble(drw["Summary2"]);
            if (drw["Summary3"].ToString() != "")
                dblSummary3 = Convert.ToDouble(drw["Summary3"]);

            // Xét tổng kết môn cuối cùng
            double? dblFinalSummary = dblSummary1;

            if (dblSummary2 > dblFinalSummary)
                dblFinalSummary = dblSummary2;
            if (dblSummary3 > dblFinalSummary)
                dblFinalSummary = dblSummary3;

            if (dblFinalSummary != null)
                drw["FinalSummary"] = dblFinalSummary;
            else
                drw["FinalSummary"] = DBNull.Value;


            // có quy định điểm tối thiểu trong môn học thì xét theo, không thì mặc định là 40 (theo thang 100)
            double dblRequestMinMark = 4;
            try
            {
                if (drw["RequestMinMark"].ToString() != "" && drw["RequestMinMark"].ToString() != "0")
                    dblRequestMinMark = Convert.ToDouble(drw["RequestMinMark"]);
            }
            catch { }



            #region Tổng kết điểm lớn nhất

            // tính đạt môn :  TKM >= Min
            if (dblFinalSummary != null)
            {
                if (dblFinalSummary >= dblRequestMinMark) // Qui chế 100_Tín chỉ chỉ kiểm tra tổng kết môn >= 40. Còn tbkt đã ràng buộc cho học viên đủ điều kiện dự thi.
                    drw["Passed"] = 1;
                else
                    drw["Passed"] = 0;
            }
            else
                drw["Passed"] = DBNull.Value;


            if (dblFinalSummary == null) // chưa có điểm
            {
                drw["LearningLevel"] = "";
                drw["OtherFinalSummary"] = DBNull.Value;
            }
            else if (dblFinalSummary >= 8.5) // A
            {
                drw["LearningLevel"] = "A";
                drw["OtherFinalSummary"] = 4;
            }

            else if (dblFinalSummary >= 7) // B
            {
                drw["LearningLevel"] = "B";
                drw["OtherFinalSummary"] = 3;
            }

            else if (dblFinalSummary >= 5.5) // C
            {
                drw["LearningLevel"] = "C";
                drw["OtherFinalSummary"] = 2;
            }

            else if (dblFinalSummary >= 4) // D
            {
                drw["LearningLevel"] = "D";
                drw["OtherFinalSummary"] = 1;
            }
            else // đã có điểm không đạt
            {
                drw["LearningLevel"] = "F";
                drw["OtherFinalSummary"] = 0;
            }

            #endregion


            #region Quy đổi điểm chữ cho TMK lần 1

            if (dblSummary1 == null) // ko có tổng kết lần 1
            {
                drw["LearningLevel1"] = "";
                drw["OtherSummary1"] = DBNull.Value;
            }
            else if (dblSummary1 >= 8.5) // A
            {
                drw["LearningLevel1"] = "A";
                drw["OtherSummary1"] = 4;
            }

            else if (dblSummary1 >= 7) // B
            {
                drw["LearningLevel1"] = "B";
                drw["OtherSummary1"] = 3;
            }

            else if (dblSummary1 >= 5.5) // C
            {
                drw["LearningLevel1"] = "C";
                drw["OtherSummary1"] = 2;
            }

            else if (dblSummary1 >= 4) // D
            {
                drw["LearningLevel1"] = "D";
                drw["OtherSummary1"] = 1;
            }
            else // đã có điểm không đạt
            {
                drw["LearningLevel1"] = "F";
                drw["OtherSummary1"] = 0;
            }

            #endregion


            #region Quy đổi điểm chữ cho TMK lần 2


            if (dblSummary2 == null) // ko có tổng kết lần 2
            {
                drw["LearningLevel2"] = "";
                drw["OtherSummary2"] = DBNull.Value;
            }
            else if (dblSummary2 >= 8.5) // A
            {
                drw["LearningLevel2"] = "A";
                drw["OtherSummary2"] = 4;
            }

            else if (dblSummary2 >= 7) // B
            {
                drw["LearningLevel2"] = "B";
                drw["OtherSummary2"] = 3;
            }

            else if (dblSummary2 >= 5.5) // C
            {
                drw["LearningLevel2"] = "C";
                drw["OtherSummary2"] = 2;
            }

            else if (dblSummary2 >= 4) // D
            {
                drw["LearningLevel2"] = "D";
                drw["OtherSummary2"] = 1;
            }
            else // đã có điểm không đạt
            {
                drw["LearningLevel2"] = "F";
                drw["OtherSummary2"] = 0;
            }

            #endregion
        }

        /// <summary>
        /// Trung cấp, cao đẳng chuyên nghiệp 2017
        /// TBM = (TBKT*4 + Thi * 6)/10
        /// Copy y chang 09 niên cế
        /// </summary>
        /// <param name="drw"></param>
        public static void TotalRow04_VanHoa(DataRow drw)
        {
            double? dblTBKT = 0, dblExam1 = null, dblExam2 = null, dblExam3 = null, dblSummary1 = null, dblSummary2 = null, dblSummary3 = null;
            int intCount = 0;
            int intMark1Number = Convert.ToInt32(drw["Mark1Number"]);
            int intMark2Number = Convert.ToInt32(drw["Mark2Number"]);

            // Tính TBKT luôn 2 hệ số           
            for (int i = 1; i <= 25 && i <= intMark1Number; i++)
            {
                {
                    string strValue = drw["Mark1" + i.ToString()].ToString();
                    if (strValue != "")
                        dblTBKT += Convert.ToDouble(strValue); //nhân hệ số                                            

                    // nếu có điểm thì tăng số cột, nếu học lại thì chỉ tăng cột khi có nhập điểm (học lại thì không cần đủ số cột)
                    //if (Convert.ToInt32(drw["OrderLearning"]) < 2 || strValue != "")
                    if (strValue != "")
                        intCount++; // tính đủ số cột
                }
            }

            for (int i = 1; i <= 25 && i <= intMark2Number; i++)
            {
                {
                    string strValue = drw["Mark2" + i.ToString()].ToString();
                    if (strValue != "")
                        dblTBKT += Convert.ToDouble(strValue) * 2; //nhân hệ số

                    // nếu có điểm thì tăng số cột, nếu học lại thì chỉ tăng cột khi có nhập điểm (học lại thì không cần đủ số cột)
                    //if (Convert.ToInt32(drw["OrderLearning"]) < 2 || strValue != "")
                    if (strValue != "")
                        intCount += 2; // tính đủ số cột
                }
            }

            if (intCount > 0)
                drw["TestAverage"] = dblTBKT = Math.Round(dblTBKT.Value / intCount, 1, MidpointRounding.AwayFromZero);
            else
                drw["TestAverage"] = DBNull.Value;

            // Tính lại điểm thi nếu có thi LT-TH:  thi = (LT + TH)/2
            bool bolTheoryPracticePassed = TotalTheoryPracticeExam(drw);

            // nếu có tbkt thì + chia 10, không thì chia 6
            if (intCount > 0)
                intCount = 10;
            else
                intCount = 6;

            // Tính TMK dựa vào điểm thi
            if (drw["Exam1"].ToString() != "")
            {
                dblExam1 = Convert.ToDouble(drw["Exam1"]);
                dblSummary1 = Math.Round((dblTBKT.Value * 4 + dblExam1.Value * 6) / intCount, 1, MidpointRounding.AwayFromZero);

            }
            if (drw["Exam2"].ToString() != "")
            {
                dblExam2 = Convert.ToDouble(drw["Exam2"]);
                dblSummary2 = Math.Round((dblTBKT.Value * 4 + dblExam2.Value * 6) / intCount, 1, MidpointRounding.AwayFromZero);
            }
            if (drw["Exam3"].ToString() != "")
            {
                dblExam3 = Convert.ToDouble(drw["Exam3"]);
                dblSummary3 = Math.Round((dblTBKT.Value * 4 + dblExam3.Value * 6) / intCount, 1, MidpointRounding.AwayFromZero);
            }



            if (dblSummary1 != null)
                drw["Summary1"] = dblSummary1;
            else
                drw["Summary1"] = DBNull.Value;

            if (dblSummary2 != null)
                drw["Summary2"] = dblSummary2;
            else
                drw["Summary2"] = DBNull.Value;

            if (dblSummary3 != null)
                drw["Summary3"] = dblSummary3;
            else
                drw["Summary3"] = DBNull.Value;


            // Xét tổng kết môn cuối cùng
            double? dblFinalSummary = dblSummary1;

            if (dblSummary2 > dblFinalSummary)
                dblFinalSummary = dblSummary2;
            if (dblSummary3 > dblFinalSummary)
                dblFinalSummary = dblSummary3;

            if (dblFinalSummary != null)
                drw["FinalSummary"] = dblFinalSummary;
            else
                drw["FinalSummary"] = DBNull.Value;


            // tính đạt môn :  TKM >=5
            if (dblFinalSummary != null)
            {
                if (bolTheoryPracticePassed && dblFinalSummary >= 5) // Qui chế 09 chỉ kiểm tra tổng kết môn >=5. Còn tbkt đã ràng buộc cho học viên đủ điều kiện dự thi.
                    drw["Passed"] = 1;
                else
                    drw["Passed"] = 0;
            }
            else
                drw["Passed"] = DBNull.Value;
        }  // End TotalRow09


        #endregion

        #region Xử lý xếp loại, thống kê bảng điểm (xài cho tổng kết kì, toàn khóa phần mềm + web)

        /// <summary>
        /// Tổng hợp thống kê xếp loại, tỉ lệ đạt
        /// Copy bên phần mềm sims qua ngày 15/10/2021
        /// </summary>
        public static DataTable SummaryStatistic(DataTable dtbExport, int? regulationID)
        {
            if (regulationID == 44 || regulationID == 99 || regulationID == 43)
                return SummaryStatistic_TinChi(dtbExport, regulationID);

            //                              0           1       2       3       4       5       6       7       8           9
            string[] arrStatisticTitle = { "Xuất sắc", "Giỏi", "Khá", "TB khá", "TB", "Yếu", "Miễn", "Đạt", "K. Đạt", "Chưa có điểm" };
            int[] arrStatisticCount = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            foreach (DataRow drw in dtbExport.Rows)
            {

                if (drw["IsIgnore"].ToString() == "")
                    drw["IsIgnore"] = false;

                if (drw["IsNotRegister"].ToString() == "")
                    drw["IsNotRegister"] = false;

                if (Convert.ToBoolean(drw["IsIgnore"]))
                {
                    arrStatisticCount[6]++; // miễn
                    arrStatisticCount[7]++; // đạt
                }
                else if (drw["FinalSummary"].ToString() == "")
                    arrStatisticCount[9]++; // chưa có điểm
                else
                {
                    double dblFinalSummary = Convert.ToDouble(drw["FinalSummary"]);

                    bool bolPassed = false;
                    if (drw["Passed"].ToString() != "")
                    {
                        if (drw["Passed"].ToString() == "1")
                            bolPassed = Convert.ToBoolean(drw["Passed"]);
                    }
                    if (bolPassed)
                        arrStatisticCount[7]++; // đạt
                    else
                        arrStatisticCount[8]++; // không đạt


                    if (dblFinalSummary >= 9.0 && bolPassed)
                    {
                        arrStatisticCount[0]++; // sx
                    }
                    else if (dblFinalSummary >= 8.0 && bolPassed)
                    {
                        arrStatisticCount[1]++; // g
                    }
                    else if (dblFinalSummary >= 7.0 && bolPassed)
                    {
                        arrStatisticCount[2]++; //khá
                    }
                    else if (dblFinalSummary >= 6.0 && bolPassed)
                    {
                        if (regulationID == 9)
                            arrStatisticCount[3]++; // tb khá
                        else
                            arrStatisticCount[2]++; //khá (qui chế 04 không có tb khá, mà tính luôn cho trung bình)                            
                    }
                    else if (dblFinalSummary >= 5.0 && bolPassed)
                    {
                        arrStatisticCount[4]++; // tb
                    }
                    else  // yếu kém chung
                    {
                        arrStatisticCount[5]++;
                    }
                }
            }

            double a = dtbExport.Rows.Count;

            // Tao table
            DataTable dtbSummary = new DataTable();
            dtbSummary.Columns.Add("Title", typeof(string));
            dtbSummary.Columns.Add("Quantity", typeof(int));
            dtbSummary.Columns.Add("Percent", typeof(double));

            for (int i = 0; i < arrStatisticCount.Length; i++)
            {
                DataRow drw = dtbSummary.NewRow();
                drw["Title"] = arrStatisticTitle[i];
                drw["Quantity"] = arrStatisticCount[i];
                drw["Percent"] = Math.Round(arrStatisticCount[i] / a * 100, 0);
                dtbSummary.Rows.Add(drw);
            }

            return dtbSummary;
        }

        /// <summary>
        /// Tổng hợp thống kê xếp loại, tỉ lệ đạt
        /// </summary>
        private static DataTable SummaryStatistic_TinChi(DataTable dtbExport, int? regulationID)
        {
            string[] arrStatisticTitle = { "A", "B", "C", "D", "F", "Miễn", "I-R", "Đạt", "Không đạt", "Thi >=5", "Thi <5" };
            int[] arrStatisticCount = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            foreach (DataRow drw in dtbExport.Rows)
            {
                if (drw["Exam1"].ToString() != "")
                {
                    double dblExam = Convert.ToDouble(drw["Exam1"]);
                    if (drw["Exam2"].ToString() != "")
                        if (Convert.ToDouble(drw["Exam2"]) > dblExam)
                            dblExam = Convert.ToDouble(drw["Exam2"]);

                    if (drw["Exam3"].ToString() != "")
                        if (Convert.ToDouble(drw["Exam3"]) > dblExam)
                            dblExam = Convert.ToDouble(drw["Exam3"]);
                    if (dblExam >= 5)
                        arrStatisticCount[8]++;
                    else
                        arrStatisticCount[9]++;
                }

                if (drw["IsIgnore"].ToString() == "")
                    drw["IsIgnore"] = false;

                if (Convert.ToBoolean(drw["IsIgnore"]))
                    arrStatisticCount[5]++;
                else if (drw["FinalSummary"].ToString() == "")
                    arrStatisticCount[6]++;
                else
                {
                    //double dblFinalSummary = Convert.ToDouble(drw["FinalSummary"]);
                    string strLevel = drw["LearningLevel"].ToString();

                    bool bolPassed = false;
                    if (drw["Passed"].ToString() != "")
                        bolPassed = Convert.ToBoolean(drw["Passed"]);
                    if (bolPassed)
                        arrStatisticCount[7]++;
                    else
                        arrStatisticCount[8]++;

                    if (strLevel.Contains("A"))
                    {
                        arrStatisticCount[0]++;
                    }
                    else if (strLevel.Contains("B"))
                    {
                        arrStatisticCount[1]++;
                    }
                    else if (strLevel.Contains("C"))
                    {
                        arrStatisticCount[2]++;
                    }
                    else if (strLevel.Contains("D"))
                    {
                        arrStatisticCount[3]++;
                    }
                    else if (strLevel.Contains("F"))
                    {
                        arrStatisticCount[4]++;
                    }
                    //else
                    //    arrStatisticCount[5]++;
                }
            }

            double a = dtbExport.Rows.Count;

            // Tao table
            DataTable dtbSummary = new DataTable();
            dtbSummary.Columns.Add("Title", typeof(string));
            dtbSummary.Columns.Add("Quantity", typeof(int));
            dtbSummary.Columns.Add("Percent", typeof(double));

            for (int i = 0; i < arrStatisticCount.Length; i++)
            {
                DataRow drw = dtbSummary.NewRow();
                drw["Title"] = arrStatisticTitle[i];
                drw["Quantity"] = arrStatisticCount[i];
                drw["Percent"] = Math.Round(arrStatisticCount[i] / a * 100, 0);
                dtbSummary.Rows.Add(drw);
            }

            return dtbSummary;
        }

        /// <summary>
        /// Thống kê xếp loại học tập khi đã có kết quả xếp loại trước ở cột LearningLevel
        /// </summary>
        /// <param name="dtbExport"></param>
        /// <returns></returns>
        public static DataTable SummaryStatistic_OfCourse(DataTable dtbExport, int? regulationID)
        {
            if (regulationID == 44 || regulationID == 99 || regulationID == 43)
                return SummaryStatistic_TinChi_OfCouse(dtbExport, regulationID);

            string[] arrStatisticTitle = { "Xuất sắc", "Giỏi", "Khá", "TB khá", "Trung bình", "Yếu" };
            int[] arrStatisticCount = { 0, 0, 0, 0, 0, 0 };

            foreach (DataRow drw in dtbExport.Rows)
            {
                for (int i = 0; i < arrStatisticTitle.Length; i++)
                {
                    if (drw["LearningLevel"].ToString() == arrStatisticTitle[i])
                    {
                        arrStatisticCount[i]++;
                        break;
                    }
                }
            }

            double a = dtbExport.Rows.Count;

            // Tao table
            DataTable dtbSummary = new DataTable();
            dtbSummary.Columns.Add("Title", typeof(string));
            dtbSummary.Columns.Add("Quantity", typeof(int));
            dtbSummary.Columns.Add("Percent", typeof(double));

            for (int i = 0; i < arrStatisticCount.Length; i++)
            {
                DataRow drw = dtbSummary.NewRow();
                drw["Title"] = arrStatisticTitle[i];
                drw["Quantity"] = arrStatisticCount[i];
                drw["Percent"] = Math.Round(arrStatisticCount[i] / a * 100, 0);
                dtbSummary.Rows.Add(drw);
            }

            return dtbSummary;
        }

        /// <summary>
        /// Thống kê xếp loại học tập khi đã có kết quả xếp loại trước ở cột LearningLevel
        /// </summary>
        /// <param name="dtbExport"></param>
        /// <returns></returns>
        public static DataTable SummaryStatistic_TinChi_OfCouse(DataTable dtbExport, int? regulationID)
        {
            string[] arrStatisticTitle = { "A", "B", "C", "D", "F", "I" };
            int[] arrStatisticCount = { 0, 0, 0, 0, 0, 0 };

            foreach (DataRow drw in dtbExport.Rows)
            {
                for (int i = 0; i < arrStatisticTitle.Length; i++)
                {
                    if (drw["LearningLevel"].ToString() == arrStatisticTitle[i])
                    {
                        arrStatisticCount[i]++;
                        break;
                    }
                }
            }

            double a = dtbExport.Rows.Count;

            // Tao table
            DataTable dtbSummary = new DataTable();
            dtbSummary.Columns.Add("Title", typeof(string));
            dtbSummary.Columns.Add("Quantity", typeof(int));
            dtbSummary.Columns.Add("Percent", typeof(double));

            for (int i = 0; i < arrStatisticCount.Length; i++)
            {
                DataRow drw = dtbSummary.NewRow();
                drw["Title"] = arrStatisticTitle[i];
                drw["Quantity"] = arrStatisticCount[i];
                drw["Percent"] = Math.Round(arrStatisticCount[i] / a * 100, 0);
                dtbSummary.Rows.Add(drw);
            }

            return dtbSummary;
        }


        /// <summary>
        /// Xếp loại theo qui chế cho tổng kết niên kì, toàn khóa
        /// </summary>
        /// <param name="drw">Dòng dữ liệu (nếu các giá trị đầu vào không truyền cụ thể thì truyền drw này)</param>
        /// <param name="regulationID">Mã qui chế của lớp</param>        
        /// <param name="xemTheoNienChe">Cố tình lấy hệ 10 xếp loại và coi như niên chế</param>        
        /// <param name="summary">TBC hệ 10</param>
        /// <param name="otherSummary">TBC hệ 4</param>
        /// <param name="soMonBTTL">Số môn bình thường thi lại để hạ bậc</param>
        /// <param name="sanctionFormID">Mã kỷ luật tới mức hạ bậc</param>        
        /// <returns></returns>
        public static string ToLearningLevel(DataRow drwData, int? regulationID, bool xemTheoNienChe = false,
                                double? summary = null, double? otherSummary = null, int? soMonBTTL = null, string sanctionFormID = null)
        {
            bool flagTinChi = regulationID == 44 || regulationID == 99 || regulationID == 43; // cờ nhận dạng nhóm qui chế là tín chỉ

            #region Chuẩn bị dữ liệu để xếp loại (nếu chưa truyền đầy đủ)

            if (drwData != null)
            {
                // tb hệ 10
                if (summary == null)
                {
                    if (drwData["SummaryLearningMark"].ToString() != "")
                        summary = Convert.ToDouble(drwData["SummaryLearningMark"]);
                }


                if (flagTinChi)
                {
                    // tb hệ 4
                    if (otherSummary == null)
                    {
                        try
                        {
                            if (drwData["OtherSummaryLearningMark"].ToString() != "") // cột này ko có thì thử lấy tên cột SummaryLearningMark, vò có form ko tách 2 cột riêng
                                otherSummary = Convert.ToDouble(drwData["OtherSummaryLearningMark"]);
                        }
                        catch
                        {
                            if (drwData["SummaryLearningMark"].ToString() != "")
                                otherSummary = Convert.ToDouble(drwData["SummaryLearningMark"]);
                        }
                    }
                }

                // số môn bth thi lại
                if (soMonBTTL == null)
                {
                    if (drwData["SoMonBinhThuongThiLai"].ToString() != "")
                        soMonBTTL = Convert.ToInt32(drwData["SoMonBinhThuongThiLai"]);
                }

                // kỷ luật tới mức hạ bậc
                if (sanctionFormID == null)
                    sanctionFormID = drwData["SanctionFormID"].ToString();
            }

            if (soMonBTTL == null)
                soMonBTTL = 0;

            if (sanctionFormID == "")
                sanctionFormID = null;

            #endregion


            string strLevel = "";

            if (regulationID == 44 && xemTheoNienChe == false) // Thông tư 04 tín chỉ
            {
                #region 44

                if (otherSummary >= 3.5)
                {
                    if (sanctionFormID != null || soMonBTTL > 0)
                        strLevel = "Giỏi";
                    else
                        strLevel = "Xuất sắc";
                }
                else if (otherSummary >= 3.0)
                {
                    if (sanctionFormID != null || soMonBTTL > 1)
                        strLevel = "Khá";
                    else
                        strLevel = "Giỏi";
                }
                else if (otherSummary >= 2.5)
                {
                    strLevel = "Khá";
                }
                else if (otherSummary >= 2.0)
                {
                    strLevel = "Trung bình";
                }
                else if (otherSummary != null)
                {
                    strLevel = "Yếu";
                }
                else
                    strLevel = ""; // chưa có tổng kết               

                #endregion
            }
            else if (regulationID == 04 || (regulationID == 44 && xemTheoNienChe == true)) // Thông tư 04 niên chế
            {
                #region 04

                if (summary >= 9)
                {
                    if (sanctionFormID != null || soMonBTTL > 0)
                        strLevel = "Giỏi";
                    else
                        strLevel = "Xuất sắc";
                }
                else if (summary >= 8)
                {
                    if (sanctionFormID != null || soMonBTTL > 1)
                        strLevel = "Khá";
                    else
                        strLevel = "Giỏi";
                }
                else if (summary >= 7)
                {
                    strLevel = "Khá";
                }
                else if (summary >= 5)
                {
                    strLevel = "Trung bình";
                }
                else if (summary != null)
                {
                    strLevel = "Yếu";
                }
                else
                    strLevel = "";

                #endregion
            }
            else if (regulationID == 99 && xemTheoNienChe == false) // Thông tư 09 tín chỉ
            {
                #region 99

                if (otherSummary >= 3.6)
                {
                    if (sanctionFormID != null || soMonBTTL > 0)
                        strLevel = "Giỏi";
                    else
                        strLevel = "Xuất sắc";
                }
                else if (otherSummary >= 3.2)
                {
                    if (sanctionFormID != null || soMonBTTL > 0)
                        strLevel = "Khá";
                    else
                        strLevel = "Giỏi";
                }
                else if (otherSummary >= 2.5)
                {
                    strLevel = "Khá";
                }
                else if (otherSummary >= 2.0)
                {
                    strLevel = "Trung bình";
                }
                else if (otherSummary != null)
                {
                    strLevel = "Yếu";
                }
                else
                    strLevel = ""; // chưa có tổng kết               

                #endregion
            }

            else if (regulationID == 09 || (regulationID == 99 && xemTheoNienChe == true)) // Thông tư 09 niên chế
            {
                #region 09

                if (summary >= 9)
                {
                    if (sanctionFormID != null || soMonBTTL > 0)
                        strLevel = "Giỏi";
                    else
                        strLevel = "Xuất sắc";
                }
                else if (summary >= 8)
                {
                    if (sanctionFormID != null || soMonBTTL > 0)
                        strLevel = "Khá";
                    else
                        strLevel = "Giỏi";
                }
                else if (summary >= 7)
                {
                    strLevel = "Khá";
                }
                else if (summary >= 6)
                {
                    strLevel = "TB khá";
                }
                else if (summary >= 5)
                {
                    strLevel = "Trung bình";
                }
                else if (summary != null)
                {
                    strLevel = "Yếu";
                }
                else
                    strLevel = "";

                #endregion
            }

            return strLevel; // trả kết quả xếp loại                               
        }

        #endregion
    }
}
