Create Procedure dbo.LMS_Enrollment_EnrollStudent
    @CourseID BigInt,
    @StudentUserId BigInt,
    @ActorId BigInt,
    @UpdatedUser Nvarchar(100) = Null
As
Begin
    Set NoCount On;
    Set Xact_Abort On;

    -- Validate Course Exists
    If Not Exists
    (
        Select
            1
        From dbo.SIM_Courses
        Where (CourseID = @CourseID)
            And (IsDeleted = 0)
    )
        Throw 50002, N'Khóa học không tồn tại.', 1;

    -- Validate student Exists
    If Not Exists
    (
        Select
            1
        From dbo.SIM_Users
        Where (UserID = @StudentUserId)
            And (IsDeleted = 0)
    )
        Throw 50003, N'Học viên không tồn tại.', 1;

    -- Check If already enrolled
    If Exists
    (
        Select
            1
        From dbo.SIM_Enrollments
        Where (CourseID = @CourseID)
            And (StudentUserID = @StudentUserId)
            And (Status <> 'CANCELLED')
    )
        Throw 50004, N'Học viên đã đăng ký khóa học này.', 1;

    -- Check authorization (admin Or teacher of the Course)
    If Not Exists
    (
        Select
            1
        From dbo.SIM_Courses c
        Where (c.CourseID = @CourseID)
            And (c.TeacherUserID = @ActorId)
    )
        Throw 50005, N'Bạn không có quyền đăng ký học viên vào khóa học này.', 1;

    Begin Transaction;

    Declare @EnrollmentId BigInt;
    Select @EnrollmentId = NextId From dbo.Sequence Where Name = 'Enrollment';
    Update dbo.Sequence Set NextId = NextId + 1 Where Name = 'Enrollment';

    Insert dbo.SIM_Enrollments
    (
        EnrollmentID,
        CourseID,
        StudentUserID,
        EnrolledAt,
        Status,
        CreatedUser,
        UpdatedUser
    )
    Values
    (
        @EnrollmentId,
        @CourseID,
        @StudentUserId,
        SysUtcDatetime(),
        'ACTIVE',
        @UpdatedUser,
        @UpdatedUser
    );

    -- Initialize Course progress
    Merge dbo.SIM_StudentCourseProgress As Target
    Using (Select @StudentUserId StudentUserID, @CourseID CourseID) As Source
        On Target.StudentUserID = Source.StudentUserID And Target.CourseID = Source.CourseID
    When Not Matched Then
        Insert (StudentUserID, CourseID, ProgressPercent, Status, StartedAt, LastAccessAt, ActiveStudySeconds, CreatedUser, UpdatedUser)
        Values (Source.StudentUserID, Source.CourseID, 0, 'Not_STARTED', SysUtcDatetime(), Null, 0, @UpdatedUser, @UpdatedUser);

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
        'ENROLL',
        'ENROLLMENT',
        'Enrollment',
        Convert(Nvarchar(100), @EnrollmentId)
    );

    Select
        @EnrollmentId EnrollmentID;
End
