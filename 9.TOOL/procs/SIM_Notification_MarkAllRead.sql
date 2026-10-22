
Create Procedure dbo.SIM_NotIficatiOn_MarkAllRead
    @UserId BigInt,
    @UpdatedUser NVarchar(100) = Null
As
Begin
    Set NoCount On;
    Set Xact_AbOrt On;

    Begin Transaction;

    Update dbo.SIM_NotIficatiOns
    Set IsRead = 1,
        ReadAt = SysUtcDatetime(),
        UpdatedAt = SysUtcDatetime(),
        UpdatedUser = @UpdatedUser
    Where (UserID = @UserId)
        And (IsRead = 0)
        And (IsDeleted = 0);

    Insert dbo.AuditLogs
    (
        UserId,
        ActiOn,
        Module,
        EntityName,
        EntityId
    )
    Values
    (
        @UserId,
        'Update',
        'NotIfICATIOn',
        'NotIficatiOn',
        'All'
    );

    Commit Transaction;

    Select
        @@ROWCount MarkedCount;
End
