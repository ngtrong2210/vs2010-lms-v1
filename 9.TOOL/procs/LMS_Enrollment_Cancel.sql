Create Procedure dbo.LMS_Enrollment_Cancel
    @EnrollmentId BigInt,
    @ActorId BigInt,
    @IsAdmin Bit = 0,
    @UpdatedUser Nvarchar(100) = Null
As
Begin
    Set NoCount On;
    Set Xact_Abort On;

    -- Get enrollment details
    Declare @CourseID BigInt;
    Declare @StudentUserId BigInt;
    Declare @CurrentStatus Varchar(50);

    Select
        @CourseID = CourseID,
        @StudentUserId = StudentUserID,
        @CurrentStatus = Status
    From dbo.SIM_Enrollments
    Where (EnrollmentID = @EnrollmentId);

    -- Validate enrollment Exists
    If @CourseID Is Null
        Throw 50002, N'Đăng ký không tồn tại.', 1;

    -- Check authorization
    If @IsAdmin = 0 And @ActorId <> @StudentUserId
    Begin
        -- Must be teacher of the Course
        If Not Exists
        (
            Select
                1
            From dbo.SIM_Courses
            Where (CourseID = @CourseID)
                And (TeacherUserID = @ActorId)
        )
            Throw 50003, N'Bạn không có quyền hủy đăng ký này.', 1;
    End

    -- Check If already cancelled
    If @CurrentStatus = 'CANCELLED'
        Throw 50004, N'Đăng ký này đã bị hủy.', 1;

    -- Cannot cancel If already completed
    If @CurrentStatus = 'COMPLETED'
        Throw 50005, N'Không thể hủy đăng ký đã hoàn thành.', 1;

    Begin Transaction;

    Update dbo.SIM_Enrollments
    Set
        Status = 'CANCELLED',
        CancelledAt = SysUtcDatetime(),
        UpdatedAt = SysUtcDatetime(),
        UpdatedUser = @UpdatedUser
    Where (EnrollmentID = @EnrollmentId);

    -- Update Course progress
    Update dbo.SIM_StudentCourseProgress
    Set
        Status = 'CANCELLED',
        UpdatedAt = SysUtcDatetime(),
        UpdatedUser = @UpdatedUser
    Where (StudentUserID = @StudentUserId)
        And (CourseID = @CourseID);

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
        @ActorId,
        'CANCEL',
        'ENROLLMENT',
        'Enrollment',
        Convert(Nvarchar(100), @EnrollmentId)
    );

    Select
        @EnrollmentId EnrollmentID;
End
