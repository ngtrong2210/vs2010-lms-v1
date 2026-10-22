Create Procedure dbo.LMS_Quiz_Update
(
	@Id BigInt,
	@Title Nvarchar(200),
	@Description Nvarchar(Max) = Null,
	@PassingScore Decimal(8, 2),
	@MaxAttempts Int,
	@TimeLimitMinutes Int = Null,
	@ShuffleQuestions Bit = 0,
	@Status Varchar(30),
	@ActorId BigInt,
	@IsAdmin Bit = 0
)
As
Begin
	Set Nocount On;

	If Nullif(Ltrim(Rtrim(@Title)), '') Is Null
		Or @PassingScore < 0
		Or @PassingScore > 100
		Or @MaxAttempts < 0
		Throw 50001, N'Dữ liệu bài kiểm tra không hợp lệ.', 1;

	Update dbo.LMS_Quizzes
	Set
		Title = @Title,
		Description = @Description,
		PassingScore = @PassingScore,
		MaxAttempts = @MaxAttempts,
		TimeLimitMinutes = @TimeLimitMinutes,
		ShuffleQuestions = @ShuffleQuestions,
		Status = @Status,
		UpdatedAt = Getutcdate()
	Where LMS_Quizzes.QuizID = @Id
		and
		(
			@IsAdmin = 1
			Or LMS_Quizzes.CreatedByUserID = @ActorId
			Or Exists
			(
				Select
					1
				From dbo.SIM_Lessons
					Inner Join dbo.SIM_Courses on SIM_Courses.CourseID = SIM_Lessons.CourseID
				Where SIM_Lessons.LessonID = LMS_Quizzes.LessonID
					and SIM_Courses.TeacherUserID = @ActorId
			)
		);

	If @@RowCount = 0
		Throw 50003, N'Không tìm thấy bài kiểm tra hoặc bạn không có quyền sửa.', 1;

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
		'QUIZ',
		'Quiz',
		Convert(Nvarchar(100), @Id)
	);

	Select
		@Id;
End
