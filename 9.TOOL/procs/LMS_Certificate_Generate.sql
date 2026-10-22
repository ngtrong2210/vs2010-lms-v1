Create Procedure dbo.LMS_Certificate_Generate
    @StudentUserId BigInt,
    @CourseID BigInt,
    @GeneratedByUserId BigInt,
    @UpdatedUser NVarchar(100) = Null
As
Begin
    Set NoCount On;
    Set Xact_Abort On;

    If Exists
        (
            Select
                1
            From dbo.SIM_Certificates
            Where (StudentUserID = @StudentUserId)
                And (CourseID = @CourseID)
                And (IsDeleted = 0)
        )
        Throw 50002, N'Chá»©ng chá»‰ Ä‘Ã£ tá»“n táº¡i cho khÃ³a há»c nÃ y.', 1;

    Declare @CourseProgress Decimal(5, 2);
    Declare @Coursestatus NVarchar(50);

    Select
        @CourseProgress = ProgressPercent,
        @Coursestatus = Status
    From dbo.SIM_StudentCourseProgress
    Where (StudentUserID = @StudentUserId)
        And (CourseID = @CourseID);

    If @CourseProgress Is Null Or @CourseProgress < 100
        Throw 50003, N'Há»c viÃªn chÆ°a hoÃ n thÃ nh khÃ³a há»c.', 1;

    If @Coursestatus <> 'COMPLETED'
        Throw 50004, N'Tiáº¿n Ä‘á»™ khÃ³a há»c chÆ°a á»Ÿ tráº¡ng thÃ¡i hoÃ n thÃ nh.', 1;

    Declare @CertificateNumber NVarchar(50) = 'CERT-' + Format(SysUtcDatetime(), 'yyyyMMdd') + '-' + Convert(NVarchar(10), @StudentUserId) + '-' + Convert(NVarchar(10), @CourseID);

    Begin Transaction;

    Insert dbo.SIM_Certificates
    (
        StudentUserID,
        CourseID,
        IssuedAt,
        ExpiresAt,
        CertIficateNumber,
        Status,
        CreatedByUserID,
        CreatedUser,
        UpdatedUser
    )
    Values
    (
        @StudentUserId,
        @CourseID,
        SysUtcDatetime(),
        DateAdd(Year, 1, SysUtcDatetime()),
        @CertificateNumber,
        'ACTIVE',
        @GeneratedByUserId,
        @UpdatedUser,
        @UpdatedUser
    );

    Declare @CertificateId BigInt = Scope_Identity();

    Commit Transaction;

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
        @GeneratedByUserId,
        'GENERATE',
        'CERTIFICATE',
        'Certificate',
        Convert(NVarchar(100), @CertificateId)
    );

    Select
        @CertificateId CertificateID,
        @CertificateNumber CertificateNumber;
End
