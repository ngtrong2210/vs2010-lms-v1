Create Procedure dbo.LMS_Lesson_Update
(
	@LessonId BigInt,
	@Title Nvarchar(200) = Null,
	@Description Nvarchar(Max) = Null,
	@LessonType Varchar(50) = Null,
	@SortOrder Int = Null,
	@DurationMinutes Int = Null,
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
			Throw 50003, N'Bạn không có quyền cập nhật bài học này.', 1;
	End

	Begin Transaction;

	Update dbo.SIM_Lessons
	Set
		Title = Isnull(@Title, SIM_Lessons.Title),
		Description = Isnull(@Description, SIM_Lessons.Description),
		LessonType = Isnull(@LessonType, SIM_Lessons.LessonType),
		SortOrder = Isnull(@SortOrder, SIM_Lessons.SortOrder),
		DurationMinutes = Isnull(@DurationMinutes, SIM_Lessons.DurationMinutes),
		UpdatedAt = Getutcdate(),
		UpdatedUser = @UpdatedUser
	Where SIM_Lessons.LessonID = @LessonId;

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
		'Update',
		'Lesson',
		'Lesson',
		Convert(Nvarchar(100), @LessonId)
	);

	Select
		@LessonId as LessonID;
End
