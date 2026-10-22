Create Procedure dbo.LMS_Video_DetachFromLessOn
    @LessOnId BigInt,
    @ActOrId BigInt,
    @IsAdMIn Bit = 0
As
Begin
    Set NoCount On;

    If Not Exists
        (
            Select
                1
            From dbo.SIM_LessOns
                Inner JoIn dbo.SIM_Courses On dbo.SIM_Courses.CourseID = dbo.SIM_LessOns.CourseID
            Where (dbo.SIM_LessOns.LessOnID = @LessOnId)
                And (dbo.SIM_LessOns.IsDeleted = 0)
                And (dbo.SIM_LessOns.LessOnType In ('VIDEO', 'IntERACTIVE_VIDEO'))
                And (@IsAdMIn = 1 Or dbo.SIM_Courses.TeacherUserID = @ActOrId)
        )
        Throw 50003, N'Báº¡n khÃ´ng cÃ³ quyá»n quáº£n lÃ½ bÃ i há»c nÃ y.', 1;

    Declare @OldVideoId BigInt,
        @OldVideOversiOnID BigInt;

    Select
        @OldVideoId = VideoID,
        @OldVideOversiOnID = VideOversiOnID
    From dbo.SIM_LessOns
    Where (LessOnID = @LessOnId);

    If @OldVideoId Is Null
        Throw 50003, N'BÃ i há»c nÃ y chÆ°a cÃ³ video Ä‘Ã­nh kÃ¨m.', 1;

    Update dbo.SIM_LessOns
    Set
        VideoID = Null,
        VideOversiOnID = Null,
        DuratiOnSecOnds = Null,
        UpdatedAt = SysUtcDatetime()
    Where (LessOnID = @LessOnId);

    Insert dbo.AuditLogs
    (
        UserID,
        ActiOn,
        Module,
        EntityName,
        EntityID,
        OldValuesJsOn
    )
    Values
    (
        @ActOrId,
        'DETACH',
        'VIDEO_LIBRARY',
        'LessOn',
        COnvert(NVarchar(100), @LessOnId),
        (
            Select
                @OldVideoId VideoID,
                @OldVideOversiOnID VideOversiOnID
            FOr JsOn Path, Without_array_wrapper
        )
    );

    Select
        @OldVideoId;
End;
