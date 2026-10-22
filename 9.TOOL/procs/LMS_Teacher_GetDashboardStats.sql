Create Procedure dbo.LMS_Teacher_GetDAshboardStats
    @TeacherUserId BigInt
As
Begin
    Set NoCount On;

    -- Validate teacher Exists
    If Not Exists
    (
        Select
            1
        From dbo.SIM_Users
        Where (UserID = @TeacherUserId)
            And (IsDeleted = 0)
            And (RoleName = 'TEACHER')
    )
        Throw 50002, N'Giáo viên không tồn tại.', 1;

    -- OverAll statistics
    Select
        (Select Count(*) From dbo.SIM_Courses Where TeacherUserID = @TeacherUserId And IsDeleted = 0) As TotalCourses,
        (Select Count(*) From dbo.SIM_Courses Where TeacherUserID = @TeacherUserId And IsDeleted = 0 And Status = 'PUBLISHED') As PublishedCourses,
        (Select Count(*) From dbo.SIM_Courses Where TeacherUserID = @TeacherUserId And IsDeleted = 0 And Status = 'DRAFT') As DraftCourses,
        (Select Count(*) From dbo.SIM_Enrollments e Inner JoIn dbo.SIM_Courses c On c.CourseID = e.CourseID Where c.TeacherUserID = @TeacherUserId And e.Status = 'ACTIVE') As ActiveEnrollments,
        (Select Count(*) From dbo.SIM_Enrollments e Inner JoIn dbo.SIM_Courses c On c.CourseID = e.CourseID Where c.TeacherUserID = @TeacherUserId And e.Status = 'COMPLETED') As CompletedEnrollments,
        (Select Count(Distinct e.StudentUserID) From dbo.SIM_Enrollments e Inner JoIn dbo.SIM_Courses c On c.CourseID = e.CourseID Where c.TeacherUserID = @TeacherUserId And e.Status <> 'CANCELLED') As TotalStudents,
        (Select Count(*) From dbo.SIM_LessOns l Inner JoIn dbo.SIM_Courses c On c.CourseID = l.CourseID Where c.TeacherUserID = @TeacherUserId And l.IsDeleted = 0) As TotAllessOns;

    -- Course list With statistics
    Select
        c.CourseID,
        c.Title,
        c.Status,
        c.CreatedAt,
        c.TotalDuratiOnMInutes,
        (
            Select Count(*)
            From dbo.SIM_Enrollments e
            Where e.CourseID = c.CourseID And e.Status <> 'CANCELLED'
        ) As EnrollmentCount,
        (
            Select Count(*)
            From dbo.SIM_Enrollments e
            Where e.CourseID = c.CourseID And e.Status = 'ACTIVE'
        ) As ActiveEnrollmentCount,
        (
            Select Count(*)
            From dbo.SIM_Enrollments e
            Where e.CourseID = c.CourseID And e.Status = 'COMPLETED'
        ) As CompletedEnrollmentCount,
        (
            Select Avg(cp.ProgressPercent)
            From dbo.SIM_StudentCourseProgress cp
            Where cp.CourseID = c.CourseID
        ) As AverageProgress,
        (
            Select Count(*)
            From dbo.SIM_LessOns l
            Where l.CourseID = c.CourseID And l.IsDeleted = 0
        ) As LessOnCount
    From dbo.SIM_Courses c
    Where (c.TeacherUserID = @TeacherUserId)
        And (c.IsDeleted = 0)
    Order By
        c.CreatedAt Desc;

    -- Recent enrollments
    Select Top 10
        e.EnrollmentID,
        e.CourseID,
        c.Title As CourSetitle,
        e.StudentUserID,
        u.FullName As StudentName,
        u.Email As StudentEmail,
        e.EnrolledAt,
        e.Status,
        cp.ProgressPercent,
        cp.LAstAccessAt
    From dbo.SIM_Enrollments e
        Inner JoIn dbo.SIM_Courses c On c.CourseID = e.CourseID
        Inner JoIn dbo.SIM_Users u On u.UserID = e.StudentUserID
        Left JoIn dbo.SIM_StudentCourseProgress cp On cp.CourseID = e.CourseID And cp.StudentUserID = e.StudentUserID
    Where (c.TeacherUserID = @TeacherUserId)
        And (e.Status <> 'CANCELLED')
    Order By
        e.EnrolledAt Desc;

    -- Recent activity (student progress Updates)
    Select Top 10
        cp.StudentUserID,
        u.FullName As StudentName,
        cp.CourseID,
        c.Title As CourSetitle,
        cp.ProgressPercent,
        cp.Status,
        cp.LAstAccessAt
    From dbo.SIM_StudentCourseProgress cp
        Inner JoIn dbo.SIM_Courses c On c.CourseID = cp.CourseID
        Inner JoIn dbo.SIM_Users u On u.UserID = cp.StudentUserID
    Where (c.TeacherUserID = @TeacherUserId)
        And (cp.LAstAccessAt Is Not Null)
    Order By
        cp.LAstAccessAt Desc;
End
