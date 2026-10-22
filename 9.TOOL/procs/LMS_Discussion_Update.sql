Create Procedure dbo.LMS_Discussion_Update
    @DiscussionId BigInt,
    @UserId BigInt,
    @Title Nvarchar(500) = Null,
    @Content Nvarchar(Max) = Null,
    @UpdatedUser Nvarchar(100) = Null
As
Begin
    Set NoCount On;
    Set Xact_Abort On;

    If Not Exists
    (
        Select
            1
        From dbo.SIM_Discussions
        Where (DiscussionID = @DiscussionId)
            And (IsDeleted = 0)
    )
        Throw 50002, N'Chủ đề thảo luận không tồn tại.', 1;

    If Not Exists
    (
        Select
            1
        From dbo.SIM_Discussions
        Where (DiscussionID = @DiscussionId)
            And (UserID = @UserId)
            And (IsDeleted = 0)
    )
        Throw 50003, N'Bạn không có quyền chỉnh sửa chủ đề này.', 1;

    Begin Transaction;

    Update dbo.SIM_Discussions
    Set Title = Coalesce(@Title, Title),
        Content = Coalesce(@Content, Content),
        UpdatedAt = SysUtcDatetime(),
        UpdatedUser = @UpdatedUser
    Where DiscussionID = @DiscussionId;

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
        'Update',
        'Discussion',
        'Discussion',
        Convert(Nvarchar(100), @DiscussionId)
    );

    Commit Transaction;

    Select
        1;
End
