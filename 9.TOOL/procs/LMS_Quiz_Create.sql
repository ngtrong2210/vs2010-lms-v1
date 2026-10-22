Create Procedure dbo.LMS_Quiz_Create
(
	@Id BigInt = Null,
	@LessonId BigInt,
	@Title Nvarchar(200),
	@Description Nvarchar(Max) = Null,
	@PassingScore Decimal(8, 2),
	@MaxAttempts Int,
	@TimeLimitMinutes Int = Null,
	@ShuffleQuestions Bit = 0,
	@Status Varchar(30),
	@ActorId BigInt,
	@CreatedUser Nvarchar(100) = Null
)
As
Begin
	Set Nocount On;

	If Nullif(Ltrim(Rtrim(@Title)), '') Is Null
		Or @PassingScore < 0
		Or @PassingScore > 100
		Or @MaxAttempts < 0
		Throw 50001, N'Dữ liệu bài kiểm tra không hợp lệ.', 1;

	If Not Exists
	(
		Select
			1
		From dbo.SIM_Lessons
			Inner Join dbo.SIM_Courses on SIM_Courses.CourseID = SIM_Lessons.CourseID
		Where SIM_Lessons.LessonID = @LessonId
			and SIM_Lessons.IsDeleted = 0
			and SIM_Lessons.LessonType = 'QUIZ'
			and SIM_Courses.TeacherUserID = @ActorId
	)
		Throw 50003, N'Bạn không có quyền tạo bài kiểm tra cho bài học này.', 1;

	Insert Into dbo.LMS_Quizzes
	(
		LessonID,
		Title,
		Description,
		PassingScore,
		MaxAttempts,
		TimeLimitMinutes,
		ShuffleQuestions,
		Status,
		CreatedByUserID,
		CreatedAt,
		UpdatedAt
	)
	Values
	(
		@LessonId,
		@Title,
		@Description,
		@PassingScore,
		@MaxAttempts,
		@TimeLimitMinutes,
		@ShuffleQuestions,
		@Status,
		@ActorId,
		Getutcdate(),
		Getutcdate()
	);

	Declare @QuizId BigInt = Scope_Identity();

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
		'QUIZ',
		'Quiz',
		Convert(Nvarchar(100), @QuizId)
	);

	Select
		@QuizId;
End
