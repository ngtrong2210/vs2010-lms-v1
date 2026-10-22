Create Procedure dbo.LMS_Discussion_Create
    @CourseID BigInt,
    @LessonId BigInt = Null,
    @UserId BigInt,
    @Title Nvarchar(500),
    @Content Nvarchar(Max),
    @ParentId BigInt = Null,
    @UpdatedUser Nvarchar(100) = Null
As
Begin
    Set NoCount On;
    Set Xact_Abort On;

    If Not Exists
    (
        Select
            1
        From dbo.SIM_Courses
        Where (CourseID = @CourseID)
            And (IsDeleted = 0)
    )
        Throw 50002, N'Khóa học không tồn tại.', 1;

    If @LessonId Is Not Null And Not Exists
    (
        Select
            1
        From dbo.SIM_Lessons
        Where (LessonID = @LessonId)
            And (CourseID = @CourseID)
            And (IsDeleted = 0)
    )
        Throw 50003, N'Bài học không tồn tại hoặc không thuộc khóa học này.', 1;

    If @ParentId Is Not Null And Not Exists
    (
        Select
            1
        From dbo.SIM_Discussions
        Where (DiscussionID = @ParentId)
            And (IsDeleted = 0)
    )
        Throw 50004, N'Chủ đề cha không tồn tại.', 1;

    Begin Transaction;

    Declare @DiscussionId BigInt;
    Select @DiscussionId = NextId From dbo.Sequence Where Name = 'Discussion';
    Update dbo.Sequence Set NextId = NextId + 1 Where Name = 'Discussion';

    Insert dbo.SIM_Discussions
    (
        DiscussionID,
        CourseID,
        LessonID,
        UserID,
        Title,
        Content,
        ParentID,
        ReplyCount,
        ViewCount,
        CreatedUser,
        UpdatedUser
    )
    Values
    (
        @DiscussionId,
        @CourseID,
        @LessonId,
        @UserId,
        @Title,
        @Content,
        @ParentId,
        0,
        0,
        @UpdatedUser,
        @UpdatedUser
    );

    If @ParentId Is Not Null
    Begin
        Update dbo.SIM_Discussions
        Set ReplyCount = ReplyCount + 1,
            UpdatedAt = SysUtcDatetime(),
            UpdatedUser = @UpdatedUser
        Where DiscussionID = @ParentId;
    End

    Insert dbo.AuditLogs
    (
        UserId,
        Action,
        Module,
        EntityName,
        EntityId
    )
    Values
    (
        @UserId,
        'Create',
        'Discussion',
        'Discussion',
        Convert(Nvarchar(100), @DiscussionId)
    );

    Commit Transaction;

    Select
        @DiscussionId DiscussionID;
End
