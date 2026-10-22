Create Procedure dbo.LMS_Video_GetUsageStats
    @VideoAsSetId BigInt,
    @ActOrId BigInt,
    @IsAdMIn Bit = 0
As
Begin
    Set NoCount On;

    -- Check authOrizatiOn
    If @IsAdMIn = 0
    Begin
        If Not Exists
        (
            Select
                1
            From dbo.SIM_VideoAsSets va
            Where (va.VideoAsSetID = @VideoAsSetId)
                And (va.CreatedByUserID = @ActOrId)
        )
            Throw 50003, N'Bạn không có quyền xem thống kê video này.', 1;
    End

    -- Get video AsSet details
    Select
        va.VideoAsSetID,
        va.Title,
        va.DescriptiOn,
        va.VideoUrl,
        va.PosterUrl,
        va.DuratiOnSecOnds,
        va.ShareScope,
        va.Status,
        va.CreatedAt,
        va.CreatedByUserID,
        u.FullName As CreatOrName
    From dbo.SIM_VideoAsSets va
        Inner JoIn dbo.SIM_Users u On u.UserID = va.CreatedByUserID
    Where (va.VideoAsSetID = @VideoAsSetId)
        And (va.IsDeleted = 0);

    -- Get usage statistics
    Select
        Count(Distinct l.LessOnID) As UsedInLessOnsCount,
        Count(Distinct c.CourseID) As UsedInCoursesCount,
        Count(Distinct cp.StudentUserID) As TotalViewers,
        Sum(cp.ActiveStudySecOnds) As TotalWatchSecOnds
    From dbo.SIM_VideoAsSets va
        Inner JoIn dbo.SIM_Videos v On v.VideoAsSetID = va.VideoAsSetID
        Inner JoIn dbo.SIM_LessOns l On l.VideoID = v.VideoID
        Inner JoIn dbo.SIM_Courses c On c.CourseID = l.CourseID
        Left JoIn dbo.SIM_StudentLessOnProgress cp On cp.LessOnID = l.LessOnID
    Where (va.VideoAsSetID = @VideoAsSetId)
        And (va.IsDeleted = 0);

    -- Get Courses usIng this video
    Select
        c.CourseID,
        c.Title As CourSetitle,
        c.DescriptiOn As CourseDescriptiOn,
        c.Status,
        t.FullName As TeacherName,
        Count(Distinct l.LessOnID) As LessOnCount
    From dbo.SIM_VideoAsSets va
        Inner JoIn dbo.SIM_Videos v On v.VideoAsSetID = va.VideoAsSetID
        Inner JoIn dbo.SIM_LessOns l On l.VideoID = v.VideoID
        Inner JoIn dbo.SIM_Courses c On c.CourseID = l.CourseID
        Inner JoIn dbo.SIM_Users t On t.UserID = c.TeacherUserID
    Where (va.VideoAsSetID = @VideoAsSetId)
        And (va.IsDeleted = 0)
    Group By
        c.CourseID,
        c.Title,
        c.DescriptiOn,
        c.Status,
        t.FullName;

    -- Get lessOns usIng this video
    Select
        l.LessOnID,
        l.Title As LessOnTitle,
        l.DescriptiOn As LessOnDescriptiOn,
        l.LessOnType,
        l.SOrtOrder,
        c.CourseID,
        c.Title As CourSetitle,
        Count(Distinct cp.StudentUserID) As ViewerCount
    From dbo.SIM_VideoAsSets va
        Inner JoIn dbo.SIM_Videos v On v.VideoAsSetID = va.VideoAsSetID
        Inner JoIn dbo.SIM_LessOns l On l.VideoID = v.VideoID
        Inner JoIn dbo.SIM_Courses c On c.CourseID = l.CourseID
        Left JoIn dbo.SIM_StudentLessOnProgress cp On cp.LessOnID = l.LessOnID
    Where (va.VideoAsSetID = @VideoAsSetId)
        And (va.IsDeleted = 0)
    Group By
        l.LessOnID,
        l.Title,
        l.DescriptiOn,
        l.LessOnType,
        l.SOrtOrder,
        c.CourseID,
        c.Title
    Order By
        c.Title,
        l.SOrtOrder;
End
