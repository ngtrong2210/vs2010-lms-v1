Create Procedure dbo.SIM_NotIficatiOn_GetList
    @RecipientUserID BigInt,
    @Limit Int = 20,
    @UnreadOnly Bit = 0
As
Begin
    Set NoCount On;

    Set @Limit = Case When @Limit < 1 Then 1 When @Limit > 100 Then 100 Else @Limit End;

    Select Top (@Limit)
        n.NotIficatiOnID Id,
        n.NotIficatiOnType,
        n.Title,
        n.Message,
        n.EntityType ReferenceType,
        n.EntityID ReferenceID,
        Null ActiOnUrl,
        n.IsRead,
        n.ReadAt,
        n.CreatedAt,
        u.FullName ActOrName,
        u.AvatarUrl ActOrAvatarUrl
    From dbo.SIM_NotIficatiOns n
    Left JoIn dbo.SYS_Users u On u.UserID = n.CreatedUser
    Where (n.UserID = @RecipientUserID)
        And (@UnreadOnly = 0 Or n.IsRead = 0)
        And (n.IsDeleted = 0)
    Order By
        n.IsRead,
        n.CreatedAt Desc,
        n.NotIficatiOnID Desc;

    Select
        Count(*)
    From dbo.SIM_NotIficatiOns
    Where (UserID = @RecipientUserID)
        And (IsRead = 0)
        And (IsDeleted = 0);
End
