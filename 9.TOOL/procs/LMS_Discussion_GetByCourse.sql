Create Procedure dbo.LMS_Discussion_GetByCourse
    @CourseID BigInt,
    @LessonId BigInt = Null,
    @PageNumber Int = 1,
    @PageSize Int = 20
As
Begin
    Set NoCount On;

    Declare @Offset Int = (@PageNumber - 1) * @PageSize;

    Select
        d.DiscussionID,
        d.CourseID,
        d.LessonID,
        d.UserID,
        u.FullName As UserName,
        u.Email As UserEmail,
        d.Title,
        d.Content,
        d.ParentID,
        d.ReplyCount,
        d.ViewCount,
        d.CreatedAt,
        d.UpdatedAt,
        d.IsDeleted,
        -- Parent Info
        p.Title As ParentTitle,
        p.UserID As ParentUserID,
        -- Lesson Info
        l.Title As LessonTitle
    From dbo.SIM_Discussions d
        Inner Join dbo.SIM_Users u On u.UserID = d.UserID
        Left Join dbo.SIM_Discussions p On p.DiscussionID = d.ParentID
        Left Join dbo.SIM_Lessons l On l.LessonID = d.LessonID
    Where (d.CourseID = @CourseID)
        And (d.IsDeleted = 0)
        And (@LessonId Is Null Or d.LessonID = @LessonId)
    Order By
        d.CreatedAt Desc
    Offset @Offset Rows
    Fetch Next @PageSize Rows Only;

    -- Return total Count
    Select
        Count(*) TotalCount
    From dbo.SIM_Discussions
    Where (CourseID = @CourseID)
        And (IsDeleted = 0)
        And (@LessonId Is Null Or LessonID = @LessonId);
End
