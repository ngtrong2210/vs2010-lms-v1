Create Procedure dbo.LMS_Teacher_GetCourseAnalytics
    @TeacherUserId BigInt,
    @CourseId BigInt = Null
As
Begin
    Set NoCount On;

    -- Validate teacher exists
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

    -- If CourseId is specified, validate it belongs to this teacher
    If @CourseId Is Not Null
    Begin
        If Not Exists
        (
            Select
                1
            From dbo.SIM_Courses
            Where (CourseID = @CourseId)
                And (TeacherUserID = @TeacherUserId)
                And (IsDeleted = 0)
        )
            Throw 50003, N'Khóa học không tồn tại hoặc bạn không có quyền truy cập.', 1;
    End

    -- Course-level statistics (Table 0)
    -- If CourseId is specified, return stats for that course only
    -- Otherwise, return stats for all courses by this teacher
    Select
        c.CourseID As Id,
        c.Title,
        c.Description,
        c.ThumbnailUrl,
        (Select Count(*)
         From dbo.SIM_Enrollments e
         Where e.CourseID = c.CourseID
           And e.Status <> 'CANCELLED') As TotalEnrollments,
        (Select Count(*)
         From dbo.SIM_Enrollments e
         Where e.CourseID = c.CourseID
           And e.Status = 'ACTIVE') As ActiveEnrollments,
        (Select Count(*)
         From dbo.SIM_Enrollments e
         Inner Join dbo.SIM_StudentCourseProgress cp On cp.CourseID = c.CourseID And cp.StudentUserID = e.StudentUserID
         Where e.CourseID = c.CourseID
           And e.Status <> 'CANCELLED'
           And cp.ProgressPercent = 100) As CompletedEnrollments,
        IsNull((Select Avg(cp.ProgressPercent)
                 From dbo.SIM_StudentCourseProgress cp
                 Inner Join dbo.SIM_Enrollments e On e.CourseID = c.CourseID And e.StudentUserID = cp.StudentUserID
                 Where cp.CourseID = c.CourseID
                   And e.Status <> 'CANCELLED'), 0) As AverageProgressPercent,
        IsNull((Select Avg(lp.Score)
                 From dbo.SIM_StudentLessonProgress lp
                 Inner Join dbo.SIM_Enrollments e On e.CourseID = c.CourseID And e.StudentUserID = lp.StudentUserID
                 Where lp.CourseID = c.CourseID
                   And lp.Score Is Not Null
                   And e.Status <> 'CANCELLED'), 0) As AverageScore,
        IsNull((Select Sum(cp.ActiveStudySeconds)
                 From dbo.SIM_StudentCourseProgress cp
                 Where cp.CourseID = c.CourseID), 0) As TotalLearningSeconds,
        c.CreatedAt,
        c.PublishedAt
    From dbo.SIM_Courses c
    Where c.TeacherUserID = @TeacherUserId
      And c.IsDeleted = 0
      And (@CourseId Is Null Or c.CourseID = @CourseId)
    Order By c.CreatedAt Desc;

    -- Student progress details (Table 1)
    -- Only returned if a specific CourseId is provided
    If @CourseId Is Not Null
    Begin
        Select
            u.UserID As StudentId,
            u.FullName As StudentName,
            u.Email As StudentEmail,
            e.EnrolledAt,
            e.Status As EnrollmentStatus,
            cp.ProgressPercent,
            cp.StartedAt,
            cp.CompletedAt,
            cp.LastAccessAt,
            IsNull(cp.ActiveStudySeconds, 0) As LearningSeconds,
            IsNull((Select Avg(lp2.Score)
                     From dbo.SIM_StudentLessonProgress lp2
                     Where lp2.CourseID = @CourseId
                       And lp2.StudentUserID = u.UserID
                       And lp2.Score Is Not Null), 0) As AverageScore,
            (Select Count(*)
             From dbo.SIM_StudentLessonProgress lp2
             Where lp2.CourseID = @CourseId
               And lp2.StudentUserID = u.UserID
               And lp2.Completed = 1) As CompletedLessonsCount,
            (Select Count(*)
             From dbo.SIM_Lessons l
             Where l.CourseID = @CourseId
               And l.IsDeleted = 0) As TotalLessonsCount
        From dbo.SIM_Enrollments e
            Inner Join dbo.SIM_Users u On u.UserID = e.StudentUserID
            Left Join dbo.SIM_StudentCourseProgress cp On cp.CourseID = e.CourseID And cp.StudentUserID = e.StudentUserID
        Where e.CourseID = @CourseId
          And e.Status <> 'CANCELLED'
          And u.IsDeleted = 0
        Order By cp.LastAccessAt Desc, e.EnrolledAt Desc;
    End

    -- Lesson-level statistics (Table 2)
    -- Only returned if a specific CourseId is provided
    If @CourseId Is Not Null
    Begin
        Select
            l.LessonID As Id,
            l.Title,
            l.SortOrder,
            ch.Title As ChapterTitle,
            (Select Count(*)
             From dbo.SIM_StudentLessonProgress lp
             Where lp.LessonID = l.LessonID
               And lp.CourseID = @CourseId) As ViewedCount,
            (Select Count(*)
             From dbo.SIM_StudentLessonProgress lp
             Where lp.LessonID = l.LessonID
               And lp.CourseID = @CourseId
               And lp.Completed = 1) As CompletedCount,
            IsNull((Select Avg(lp.Score)
                     From dbo.SIM_StudentLessonProgress lp
                     Where lp.LessonID = l.LessonID
                       And lp.CourseID = @CourseId
                       And lp.Score Is Not Null), 0) As AverageScore,
            IsNull((Select Sum(lp.StudySeconds)
                     From dbo.SIM_StudentLessonProgress lp
                     Where lp.LessonID = l.LessonID
                       And lp.CourseID = @CourseId), 0) As TotalStudySeconds
        From dbo.SIM_Lessons l
            Left Join dbo.SIM_Chapters ch On ch.ChapterID = l.ChapterID
        Where l.CourseID = @CourseId
          And l.IsDeleted = 0
        Order By ch.SortOrder, l.SortOrder;
    End
End
