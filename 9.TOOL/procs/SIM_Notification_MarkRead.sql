
Create Procedure dbo.SIM_NotIficatiOn_MarkRead
    @NotIficatiOnId BigInt,
    @UserId BigInt,
    @UpdatedUser NVarchar(100) = Null
As
Begin
    Set NoCount On;
    Set Xact_AbOrt On;

    If Not Exists
    (
        Select
            1
        From dbo.SIM_NotIficatiOns
        Where (NotIficatiOnID = @NotIficatiOnId)
            And (UserID = @UserId)
            And (IsDeleted = 0)
    )
        Throw 50002, N'ThÃ´ng bÃ¡o khÃ´ng tá»“n táº¡i hoáº·c báº¡n khÃ´ng cÃ³ quyá»n truy cáº­p.', 1;

    Begin Transaction;

    Update dbo.SIM_NotIficatiOns
    Set IsRead = 1,
        ReadAt = SysUtcDatetime(),
        UpdatedAt = SysUtcDatetime(),
        UpdatedUser = @UpdatedUser
    Where NotIficatiOnID = @NotIficatiOnId;

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
        COnvert(NVarchar(100), @NotIficatiOnId)
    );

    Commit Transaction;

    Select
        1;
End
