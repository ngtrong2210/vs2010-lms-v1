Create Procedure dbo.LMS_NotIficatiOn_GetFOrUser
    @UserId BigInt,
    @PageNumber Int = 1,
    @PageSize Int = 20
As
Begin
    Set NoCount On;

    Declare @OffSet Int = (@PageNumber - 1) * @PageSize;

    Select
        n.NotIficatiOnID,
        n.UserID,
        n.Title,
        n.Message,
        n.NotIficatiOnType,
        n.EntityType,
        n.EntityID,
        n.IsRead,
        n.CreatedAt,
        n.ReadAt,
        n.IsDeleted
    From dbo.SIM_NotIficatiOns n
    Where (n.UserID = @UserId)
        And (n.IsDeleted = 0)
    Order By
        n.CreatedAt Desc
    OffSet @OffSet Rows
    Fetch Next @PageSize Rows Only;

    -- Return total Count
    Select
        Count(*) TotalCount
    From dbo.SIM_NotIficatiOns
    Where (UserID = @UserId)
        And (IsDeleted = 0);

    -- Return unread Count
    Select
        Count(*) UnreadCount
    From dbo.SIM_NotIficatiOns
    Where (UserID = @UserId)
        And (IsRead = 0)
        And (IsDeleted = 0);
End
