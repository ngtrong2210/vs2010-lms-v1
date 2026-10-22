Create Procedure dbo.LMS_Lesson_Create
(
	@CourseID BigInt,
	@Title Nvarchar(200),
	@Description Nvarchar(Max) = Null,
	@LessonType Varchar(50) = 'CONTENT',
	@SortOrder Int = 0,
	@DurationMinutes Int = 0,
	@ActorId BigInt,
	@IsAdmin Bit = 0,
	@CreatedUser Nvarchar(100) = Null
)
As
Begin
	Set Nocount On;
	Set Xact_Abort On;

	-- Validate Course Exists
	If Not Exists
	(
		Select
			1
		From dbo.SIM_Courses
		Where SIM_Courses.CourseID = @CourseID
			and SIM_Courses.IsDeleted = 0
	)
		Throw 50002, N'Khóa học không tồn tại.', 1;

	-- Check authorization
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
			Throw 50003, N'Bạn không có quyền tạo bài học trong khóa học này.', 1;
	End

	Begin Transaction;

	Declare @LessonId BigInt;
	Select @LessonId = NextId
	From dbo.Sequence
	Where Name = 'Lesson';

	Update dbo.Sequence
	Set NextId = NextId + 1
	Where Name = 'Lesson';

	Insert Into dbo.SIM_Lessons
	(
		LessonID,
		CourseID,
		Title,
		Description,
		LessonType,
		SortOrder,
		DurationMinutes,
		CreatedUser,
		UpdatedUser
	)
	Values
	(
		@LessonId,
		@CourseID,
		@Title,
		@Description,
		@LessonType,
		@SortOrder,
		@DurationMinutes,
		@CreatedUser,
		@CreatedUser
	);

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
		'Create',
		'Lesson',
		'Lesson',
		Convert(Nvarchar(100), @LessonId)
	);

	Select
		@LessonId as LessonID;
End
