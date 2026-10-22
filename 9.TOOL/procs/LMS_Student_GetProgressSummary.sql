Create Procedure dbo.LMS_Student_GetProgressSummary
    @StudentUserId BigInt,
    @CourseID BigInt = Null
As
Begin
    Set NoCount On;

    -- Get Course progress Summary
    If @CourseID Is Not Null
    Begin
        -- SIngle Course progress
        Select
            cp.CourseID,
            c.Title As CourSetitle,
            c.DescriptiOn As CourseDescriptiOn,
            cp.ProgressPercent,
            cp.Status,
            cp.StartedAt,
            cp.CompletedAt,
            cp.LAstAccessAt,
            cp.ActiveStudySecOnds,
            e.EnrolledAt,
            e.Status As EnrollmentStatus
        From dbo.SIM_StudentCourseProgress cp
            Inner JoIn dbo.SIM_Courses c On c.CourseID = cp.CourseID
            Inner JoIn dbo.SIM_Enrollments e On e.CourseID = cp.CourseID And e.StudentUserID = cp.StudentUserID
        Where (cp.StudentUserID = @StudentUserId)
            And (cp.CourseID = @CourseID)
            And (cp.IsDeleted = 0);

        -- LessOn progress fOr this Course
        Select
            lp.LessOnID,
            l.Title As LessOnTitle,
            l.LessOnType,
            lp.ProgressPercent,
            lp.ScOre,
            lp.AttemptCount,
            lp.Completed,
            lp.CompletedAt,
            lp.LAstAccessAt,
            lp.ActiveStudySecOnds
        From dbo.SIM_StudentLessOnProgress lp
            Inner JoIn dbo.SIM_LessOns l On l.LessOnID = lp.LessOnID
        Where (lp.StudentUserID = @StudentUserId)
            And (lp.CourseID = @CourseID)
            And (lp.IsDeleted = 0)
        Order By
            l.SOrtOrder,
            l.LessOnID;
    End
    Else
    Begin
        -- All Courses progress
        Select
            cp.CourseID,
            c.Title As CourSetitle,
            c.DescriptiOn As CourseDescriptiOn,
            c.ThumbnailUrl,
            cp.ProgressPercent,
            cp.Status,
            cp.StartedAt,
            cp.CompletedAt,
            cp.LAstAccessAt,
            cp.ActiveStudySecOnds,
            e.EnrolledAt,
            e.Status As EnrollmentStatus,
            u.FullName As TeacherName
        From dbo.SIM_StudentCourseProgress cp
            Inner JoIn dbo.SIM_Courses c On c.CourseID = cp.CourseID
            Inner JoIn dbo.SIM_Enrollments e On e.CourseID = cp.CourseID And e.StudentUserID = cp.StudentUserID
            Inner JoIn dbo.SIM_Users u On u.UserID = c.TeacherUserID
        Where (cp.StudentUserID = @StudentUserId)
            And (cp.IsDeleted = 0)
        Order By
            cp.LAstAccessAt Desc,
            c.Title;
    End

    -- OverAll statistics
    Select
        Count(*) As TotalEnrolledCourses,
        Sum(Case When cp.Status = 'COMPLETED' Then 1 Else 0 End) As CompletedCourses,
        Sum(Case When cp.Status = 'In_PROGRESS' Then 1 Else 0 End) As InProgressCourses,
        Avg(cp.ProgressPercent) As AverageProgress,
        Sum(cp.ActiveStudySecOnds) As TotalStudySecOnds
    From dbo.SIM_StudentCourseProgress cp
        Inner JoIn dbo.SIM_Enrollments e On e.CourseID = cp.CourseID And e.StudentUserID = cp.StudentUserID
    Where (cp.StudentUserID = @StudentUserId)
        And (cp.IsDeleted = 0);
End
