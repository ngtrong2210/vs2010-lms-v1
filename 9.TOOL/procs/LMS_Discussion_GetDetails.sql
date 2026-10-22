Create Procedure dbo.LMS_Discussion_GetDetails
    @DiscussionId BigInt
As
Begin
    Set NoCount On;

    -- Main discussion
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
        -- Course Info
        c.Title As CourseTitle,
        -- Lesson Info
        l.Title As LessonTitle,
        -- Parent Info
        p.Title As ParentTitle,
        p.UserID As ParentUserID,
        pu.FullName As ParentUserName
    From dbo.SIM_Discussions d
        Inner Join dbo.SIM_Users u On u.UserID = d.UserID
        Inner Join dbo.SIM_Courses c On c.CourseID = d.CourseID
        Left Join dbo.SIM_Lessons l On l.LessonID = d.LessonID
        Left Join dbo.SIM_Discussions p On p.DiscussionID = d.ParentID
        Left Join dbo.SIM_Users pu On pu.UserID = p.UserID
    Where (d.DiscussionID = @DiscussionId)
        And (d.IsDeleted = 0);

    -- Replies (If parent discussion)
    Select
        d.DiscussionID,
        d.UserID,
        u.FullName As UserName,
        u.Email As UserEmail,
        d.Content,
        d.CreatedAt,
        d.UpdatedAt
    From dbo.SIM_Discussions d
        Inner Join dbo.SIM_Users u On u.UserID = d.UserID
    Where (d.ParentID = @DiscussionId)
        And (d.IsDeleted = 0)
    Order By
        d.CreatedAt Asc;
End
