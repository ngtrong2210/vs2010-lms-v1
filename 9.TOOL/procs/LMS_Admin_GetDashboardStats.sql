Create Procedure dbo.LMS_Admin_GetDashboardStats
    @StartDate Datetime = Null,
    @EndDate Datetime = Null
As
Begin
    Set NoCount On;

    -- Default to last 30 days if not specified
    If @StartDate Is Null Set @StartDate = DateAdd(Day, -30, SysUtcDatetime());
    If @EndDate Is Null Set @EndDate = SysUtcDatetime();

    -- Overall statistics
    Select
        (Select Count(*) From dbo.SIM_Courses Where IsDeleted = 0) As TotalCourses,
        (Select Count(*) From dbo.SIM_Courses Where IsDeleted = 0 And Status = 'PUBLISHED') As PublishedCourses,
        (Select Count(*) From dbo.SIM_Courses Where IsDeleted = 0 And Status = 'DRAFT') As DraftCourses,
        (Select Count(*) From dbo.SIM_Users Where IsDeleted = 0 And RoleName = 'TEACHER') As TotalTeachers,
        (Select Count(*) From dbo.SIM_Users Where IsDeleted = 0 And RoleName = 'STUDENT') As TotalStudents,
        (Select Count(*) From dbo.SIM_Enrollments Where Status = 'ACTIVE') As ActiveEnrollments,
        (Select Count(*) From dbo.SIM_Enrollments Where Status = 'COMPLETED') As CompletedEnrollments;

    -- New enrollments in date range
    Select
        Count(*) As NewEnrollments
    From dbo.SIM_Enrollments
    Where EnrolledAt >= @StartDate And EnrolledAt <= @EndDate;

    -- Course completions in date range
    Select
        Count(*) As Completions
    From dbo.SIM_StudentCourseProgress cp
    Where cp.Status = 'COMPLETED'
        And cp.CompletedAt >= @StartDate
        And cp.CompletedAt <= @EndDate;

    -- Active students in date range
    Select
        Count(Distinct cp.StudentUserID) As ActiveStudents
    From dbo.SIM_StudentCourseProgress cp
    Where cp.LastAccessAt >= @StartDate And cp.LastAccessAt <= @EndDate;

    -- Top 5 Courses by enrollment
    Select Top 5
        c.CourseID,
        c.Title,
        t.FullName As TeacherName,
        Count(e.EnrollmentID) As EnrollmentCount
    From dbo.SIM_Courses c
        Inner Join dbo.SIM_Users t On t.UserID = c.TeacherUserID
        Left Join dbo.SIM_Enrollments e On e.CourseID = c.CourseID And e.Status <> 'CANCELLED'
    Where c.IsDeleted = 0
    Group By
        c.CourseID,
        c.Title,
        t.FullName
    Order By
        EnrollmentCount Desc;

    -- Top 5 Courses by completion rate
    Select Top 5
        c.CourseID,
        c.Title,
        t.FullName As TeacherName,
        Count(e.EnrollmentID) As TotalEnrollments,
        Sum(Case When cp.Status = 'COMPLETED' Then 1 Else 0 End) As CompletedCount,
        Case
            When Count(e.EnrollmentID) > 0 Then
                Cast(Sum(Case When cp.Status = 'COMPLETED' Then 1 Else 0 End) * 100.0 / Count(e.EnrollmentID) As Decimal(10, 2))
            Else 0
        End As CompletionRate
    From dbo.SIM_Courses c
        Inner Join dbo.SIM_Users t On t.UserID = c.TeacherUserID
        Left Join dbo.SIM_Enrollments e On e.CourseID = c.CourseID And e.Status <> 'CANCELLED'
        Left Join dbo.SIM_StudentCourseProgress cp On cp.CourseID = c.CourseID And cp.StudentUserID = e.StudentUserID
    Where c.IsDeleted = 0
    Group By
        c.CourseID,
        c.Title,
        t.FullName
    Having Count(e.EnrollmentID) > 0
    Order By
        CompletionRate Desc;
End
