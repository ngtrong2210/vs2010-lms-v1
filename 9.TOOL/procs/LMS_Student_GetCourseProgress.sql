Create Procedure dbo.LMS_Student_GetCourseProgress
    @StudentUserId BigInt,
    @CourseID BigInt
As
Begin
    Set NoCount On;

    -- Validate enrollment
    If Not Exists
    (
        Select
            1
        From dbo.SIM_Enrollments e
        Where (e.CourseID = @CourseID)
            And (e.StudentUserID = @StudentUserId)
            And (e.Status <> 'CANCELLED')
    )
        Throw 50002, N'Bạn chưa đăng ký khóa học này.', 1;

    -- Get Course details
    Select
        c.CourseID,
        c.Title,
        c.DescriptiOn,
        c.ThumbnailUrl,
        c.TotalDuratiOnMInutes,
        cp.ProgressPercent,
        cp.Status,
        cp.StartedAt,
        cp.CompletedAt,
        cp.LAstAccessAt,
        cp.ActiveStudySecOnds,
        e.EnrolledAt,
        e.Status As EnrollmentStatus
    From dbo.SIM_Courses c
        Left JoIn dbo.SIM_StudentCourseProgress cp On cp.CourseID = c.CourseID And cp.StudentUserID = @StudentUserId
        Inner JoIn dbo.SIM_Enrollments e On e.CourseID = c.CourseID And e.StudentUserID = @StudentUserId
    Where (c.CourseID = @CourseID)
        And (c.IsDeleted = 0);

    -- Get lessOns With progress
    Select
        l.LessOnID,
        l.Title,
        l.DescriptiOn,
        l.LessOnType,
        l.SOrtOrder,
        l.DuratiOnMInutes,
        lp.ProgressPercent,
        lp.ScOre,
        lp.AttemptCount,
        lp.Completed,
        lp.CompletedAt,
        lp.LAstAccessAt,
        lp.ActiveStudySecOnds,
        Case
            When l.LessOnType = 'QUIZ' Then
            (
                Select Count(*)
                From dbo.SIM_QuizAttempts qa
                Where qa.QuizID = (Select QuizID From dbo.SIM_Quizzes Where LessOnID = l.LessOnID)
                    And qa.StudentUserID = @StudentUserId
            )
            Else 0
        End As QuizAttempts
    From dbo.SIM_LessOns l
        Left JoIn dbo.SIM_StudentLessOnProgress lp On lp.LessOnID = l.LessOnID And lp.StudentUserID = @StudentUserId
    Where (l.CourseID = @CourseID)
        And (l.IsDeleted = 0)
    Order By
        l.SOrtOrder,
        l.LessOnID;

    -- Get cOntent progress fOr cOntent-bAsed lessOns
    Select
        ci.COntentID,
        ci.LessOnID,
        ci.Title,
        ci.COntentType,
        ci.SOrtOrder,
        ci.DuratiOnMInutes,
        scp.Completed,
        scp.WatchedSecOnds,
        scp.LAstAccessAt
    From dbo.SIM_COntentItems ci
        Inner JoIn dbo.SIM_LessOns l On l.LessOnID = ci.LessOnID
        Left JoIn dbo.SIM_StudentCOntentProgress scp On scp.COntentID = ci.COntentID And scp.StudentUserID = @StudentUserId
    Where (l.CourseID = @CourseID)
        And (ci.IsDeleted = 0)
    Order By
        l.SOrtOrder,
        ci.SOrtOrder,
        ci.COntentID;

    -- Get quiz attempts fOr this Course
    Select
        qa.QuizAttemptID,
        qa.QuizID,
        q.Title As QuizTitle,
        l.LessOnID,
        l.Title As LessOnTitle,
        qa.AttemptNumber,
        qa.AttemptStatus,
        qa.StartedAt,
        qa.SubmittedAt,
        qa.ScOre,
        qa.MaxScOre,
        qa.ScOrePercent,
        qa.PAssed
    From dbo.SIM_QuizAttempts qa
        Inner JoIn dbo.SIM_Quizzes q On q.QuizID = qa.QuizID
        Inner JoIn dbo.SIM_LessOns l On l.LessOnID = q.LessOnID
    Where (qa.StudentUserID = @StudentUserId)
        And (l.CourseID = @CourseID)
    Order By
        qa.StartedAt Desc;
End
