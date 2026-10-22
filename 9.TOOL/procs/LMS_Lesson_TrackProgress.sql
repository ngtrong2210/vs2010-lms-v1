Create Procedure dbo.LMS_Lesson_TrackProgress
(
	@LessonId BigInt,
	@StudentUserId BigInt,
	@AccessedSeconds Int = 0,
	@IsCompleted Bit = 0,
	@UpdatedUser Nvarchar(100) = Null
)
As
Begin
	Set Nocount On;
	Set Xact_Abort On;

	If Not Exists
	(
		Select
			1
		From dbo.SIM_Lessons
		Where SIM_Lessons.LessonID = @LessonId
			and SIM_Lessons.IsDeleted = 0
	)
		Throw 50002, N'Bài học không tồn tại.', 1;

	If Not Exists
	(
		Select
			1
		From dbo.SIM_Enrollments
			Inner Join dbo.SIM_Courses on SIM_Courses.CourseID = SIM_Enrollments.CourseID
			Inner Join dbo.SIM_Lessons on SIM_Lessons.CourseID = SIM_Courses.CourseID
		Where SIM_Lessons.LessonID = @LessonId
			and SIM_Enrollments.StudentUserID = @StudentUserId
			and SIM_Enrollments.Status <> 'CANCELLED'
	)
		Throw 50003, N'Bạn không có quyền truy cập bài học này.', 1;

	Declare @CourseID BigInt;
	Select @CourseID = SIM_Lessons.CourseID
	From dbo.SIM_Lessons
	Where SIM_Lessons.LessonID = @LessonId;

	Begin Transaction;

	Merge dbo.SIM_StudentLessonProgress as Target
	Using (Select @StudentUserId as StudentUserID, @CourseID as CourseID, @LessonId as LessonID) as Source
		on Target.StudentUserID = Source.StudentUserID
			and Target.LessonID = Source.LessonID
	When Matched Then
		Update Set
			ActiveStudySeconds = Target.ActiveStudySeconds + @AccessedSeconds,
			Completed = Case When @IsCompleted = 1 Then 1 Else Target.Completed End,
			CompletedAt = Case When @IsCompleted = 1 And Target.Completed = 0 Then Getutcdate() Else Target.CompletedAt End,
			LastAccessAt = Getutcdate(),
			UpdatedAt = Getutcdate(),
			UpdatedUser = @UpdatedUser
	When Not Matched Then
		Insert (StudentUserID, CourseID, LessonID, ProgressPercent, Score, AttemptCount, Completed, CompletedAt, LastAccessAt, ActiveStudySeconds, CreatedUser, UpdatedUser)
		Values (Source.StudentUserID, Source.CourseID, Source.LessonID, 0, 0, 0, @IsCompleted, Case When @IsCompleted = 1 Then Getutcdate() Else Null End, Getutcdate(), @AccessedSeconds, @UpdatedUser, @UpdatedUser);

	Update dbo.SIM_Enrollments
	Set LastAccessAt = Getutcdate(),
		UpdatedUser = @UpdatedUser
	Where SIM_Enrollments.StudentUserID = @StudentUserId
		and SIM_Enrollments.CourseID = @CourseID;

	Commit Transaction;

	Insert Into dbo.AuditLogs
	(
		UserId,
		Action,
		Module,
		EntityName,
		EntityId
	)
	Values
	(
		@StudentUserId,
		'TRACK',
		'Lesson',
		'LessonProgress',
		Concat(Convert(Nvarchar(100), @LessonId), '-', Convert(Nvarchar(100), @StudentUserId))
	);

	Select
		1;
End
