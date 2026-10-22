Create Procedure dbo.LMS_Content_TrackProgress
(
	@ContentId BigInt,
	@StudentUserId BigInt,
	@WatchedSeconds Int = 0,
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
		From dbo.SIM_ContentItems
		Where SIM_ContentItems.ContentID = @ContentId
			and SIM_ContentItems.IsDeleted = 0
	)
		Throw 50002, N'Nội dung không tồn tại.', 1;

	Declare @LessonId BigInt;
	Declare @CourseID BigInt;

	Select @LessonId = SIM_ContentItems.LessonID
	From dbo.SIM_ContentItems
	Where SIM_ContentItems.ContentID = @ContentId;

	Select @CourseID = SIM_Lessons.CourseID
	From dbo.SIM_Lessons
	Where SIM_Lessons.LessonID = @LessonId;

	If Not Exists
	(
		Select
			1
		From dbo.SIM_Enrollments
		Where SIM_Enrollments.CourseID = @CourseID
			and SIM_Enrollments.StudentUserID = @StudentUserId
			and SIM_Enrollments.Status <> 'CANCELLED'
	)
		Throw 50003, N'Bạn không có quyền truy cập nội dung này.', 1;

	Begin Transaction;

	Merge dbo.SIM_StudentContentProgress as Target
	Using (Select @StudentUserId as StudentUserID, @ContentId as ContentID) as Source
		on Target.StudentUserID = Source.StudentUserID
			and Target.ContentID = Source.ContentID
	When Matched Then
		Update Set
			WatchedSeconds = Target.WatchedSeconds + @WatchedSeconds,
			Completed = Case When @IsCompleted = 1 Then 1 Else Target.Completed End,
			CompletedAt = Case When @IsCompleted = 1 And Target.Completed = 0 Then Getutcdate() Else Target.CompletedAt End,
			LastAccessAt = Getutcdate(),
			UpdatedAt = Getutcdate(),
			UpdatedUser = @UpdatedUser
	When Not Matched Then
		Insert (StudentUserID, ContentID, LessonID, CourseID, Completed, WatchedSeconds, LastAccessAt, CreatedUser, UpdatedUser)
		Values (Source.StudentUserID, Source.ContentID, @LessonId, @CourseID, @IsCompleted, @WatchedSeconds, Getutcdate(), @UpdatedUser, @UpdatedUser);

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
		'CONTENT',
		'ContentProgress',
		Concat(Convert(Nvarchar(100), @ContentId), '-', Convert(Nvarchar(100), @StudentUserId))
	);

	Select
		1;
End
