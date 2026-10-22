Create Procedure dbo.LMS_Lesson_Delete
(
	@LessonId BigInt,
	@ActorId BigInt,
	@IsAdmin Bit = 0,
	@UpdatedUser Nvarchar(100) = Null
)
As
Begin
	Set Nocount On;
	Set Xact_Abort On;

	-- Validate lesson Exists
	If Not Exists
	(
		Select
			1
		From dbo.SIM_Lessons
		Where SIM_Lessons.LessonID = @LessonId
			and SIM_Lessons.IsDeleted = 0
	)
		Throw 50002, N'Bài học không tồn tại.', 1;

	-- Check authorization
	Declare @CourseID BigInt;
	Select @CourseID = SIM_Lessons.CourseID
	From dbo.SIM_Lessons
	Where SIM_Lessons.LessonID = @LessonId;

	If @IsAdmin = 0
	Begin
		If Not Exists
		(
			Select
				1
			From dbo.SIM_Courses
			Where SIM_Courses.CourseID = @CourseID
				and SIM_Courses.TeacherUserID = @ActorId
		)
			Throw 50003, N'Bạn không có quyền xóa bài học này.', 1;
	End

	Begin Transaction;

	-- Soft Delete the lesson
	Update dbo.SIM_Lessons
	Set
		IsDeleted = 1,
		DeletedAt = Getutcdate(),
		UpdatedAt = Getutcdate(),
		UpdatedUser = @UpdatedUser
	Where SIM_Lessons.LessonID = @LessonId;

	-- Soft Delete Associated content items
	Update dbo.SIM_ContentItems
	Set
		IsDeleted = 1,
		DeletedAt = Getutcdate(),
		UpdatedAt = Getutcdate(),
		UpdatedUser = @UpdatedUser
	Where SIM_ContentItems.LessonID = @LessonId;

	-- Soft Delete Associated quizzes
	Update dbo.SIM_Quizzes
	Set
		IsDeleted = 1,
		DeletedAt = Getutcdate(),
		UpdatedAt = Getutcdate(),
		UpdatedUser = @UpdatedUser
	Where SIM_Quizzes.LessonID = @LessonId;

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
		@ActorId,
		'Delete',
		'Lesson',
		'Lesson',
		Convert(Nvarchar(100), @LessonId)
	);

	Select
		@LessonId as LessonID;
End
