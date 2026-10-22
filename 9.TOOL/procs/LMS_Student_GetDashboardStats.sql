Create Procedure dbo.LMS_Student_GetDashboardStats
    @StudentUserId BigInt
As
Begin
    Set NoCount On;

    -- Validate student exists
    If Not Exists
    (
        Select
            1
        From dbo.SIM_Users
        Where (UserID = @StudentUserId)
            And (IsDeleted = 0)
            And (RoleName = 'STUDENT')
    )
        Throw 50002, N'Học viên không tồn tại.', 1;

    -- Overall statistics (Table 0)
    Select
        (Select Count(*)
         From dbo.SIM_Enrollments e
         Inner Join dbo.SIM_Courses c On c.CourseID = e.CourseID
         Where e.StudentUserID = @StudentUserId
           And e.Status = 'ACTIVE'
           And c.IsDeleted = 0) As ActiveCourseCount,
        (Select Count(*)
         From dbo.SIM_StudentLessonProgress lp
         Where lp.StudentUserID = @StudentUserId
           And lp.Completed = 1
           And lp.IsDeleted = 0) As CompletedLessonCount,
        IsNull((Select Avg(lp.Score)
                 From dbo.SIM_StudentLessonProgress lp
                 Where lp.StudentUserID = @StudentUserId
                   And lp.Score Is Not Null
                   And lp.IsDeleted = 0), 0) As AverageScore,
        IsNull((Select Sum(cp.ActiveStudySeconds)
                 From dbo.SIM_StudentCourseProgress cp
                 Where cp.StudentUserID = @StudentUserId
                   And cp.IsDeleted = 0), 0) As LearningSeconds;

    -- Recent courses with progress (Table 1)
    Select Top 10
        c.CourseID As Id,
        c.Title,
        c.Description,
        c.ThumbnailUrl,
        cp.ProgressPercent,
        cp.Status As ProgressStatus,
        cp.StartedAt,
        cp.CompletedAt,
        cp.LastAccessAt,
        e.EnrolledAt,
        e.Status As EnrollmentStatus,
        u.FullName As TeacherName,
        -- Find the next incomplete lesson to continue
        (Select Top 1 l.LessonID
         From dbo.SIM_Lessons l
         Inner Join dbo.SIM_Chapters ch On ch.ChapterID = l.ChapterID
         Where ch.CourseID = c.CourseID
           And l.IsDeleted = 0
           And ch.IsDeleted = 0
           And Not Exists (
               Select 1
               From dbo.SIM_StudentLessonProgress lp2
               Where lp2.StudentUserID = @StudentUserId
                 And lp2.LessonID = l.LessonID
                 And lp2.Completed = 1
                 And lp2.IsDeleted = 0
           )
         Order By ch.SortOrder, l.SortOrder
        ) As ContinueLessonId
    From dbo.SIM_Enrollments e
        Inner Join dbo.SIM_Courses c On c.CourseID = e.CourseID
        Left Join dbo.SIM_StudentCourseProgress cp On cp.CourseID = c.CourseID And cp.StudentUserID = e.StudentUserID
        Inner Join dbo.SIM_Users u On u.UserID = c.TeacherUserID
    Where e.StudentUserID = @StudentUserId
        And e.Status <> 'CANCELLED'
        And c.IsDeleted = 0
    Order By cp.LastAccessAt Desc, e.EnrolledAt Desc;
End
