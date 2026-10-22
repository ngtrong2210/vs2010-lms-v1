Create Procedure dbo.LMS_QuizAttempt_Create
(
	@QuizId BigInt,
	@StudentUserId BigInt,
	@CreatedUser Nvarchar(100) = Null
)
As
Begin
	Set Nocount On;

	If Not Exists
	(
		Select
			1
		From dbo.SIM_Quizzes
			Inner Join dbo.SIM_Lessons on SIM_Lessons.LessonID = SIM_Quizzes.LessonID
			Inner Join dbo.SIM_Courses on SIM_Courses.CourseID = SIM_Lessons.CourseID
			Inner Join dbo.SIM_Enrollments on SIM_Enrollments.CourseID = SIM_Courses.CourseID
				and SIM_Enrollments.StudentUserID = @StudentUserId
		Where SIM_Quizzes.QuizID = @QuizId
			and SIM_Quizzes.IsDeleted = 0
			and SIM_Quizzes.Status = 'ACTIVE'
			and SIM_Enrollments.Status <> 'CANCELLED'
	)
		Throw 50003, N'Bạn không có quyền bắt đầu bài kiểm tra này.', 1;

	Declare @MaxAttempts Int;
	Declare @CurrentAttempts Int;

	Select
		@MaxAttempts = MaxAttempts
	From dbo.SIM_Quizzes
	Where SIM_Quizzes.QuizID = @QuizId;

	Select
		@CurrentAttempts = Count(*)
	From dbo.SIM_QuizAttempts
	Where SIM_QuizAttempts.QuizID = @QuizId
		and SIM_QuizAttempts.StudentUserID = @StudentUserId;

	If @MaxAttempts > 0 And @CurrentAttempts >= @MaxAttempts
		Throw 50002, N'Bạn đã vượt quá số lần thử tối đa cho bài kiểm tra này.', 1;

	Declare @AttemptNumber Int = @CurrentAttempts + 1;

	Insert Into dbo.SIM_QuizAttempts
	(
		QuizID,
		StudentUserID,
		AttemptNumber,
		AttemptStatus,
		StartedAt,
		CreatedUser,
		UpdatedUser
	)
	Values
	(
		@QuizId,
		@StudentUserId,
		@AttemptNumber,
		'IN_PROGRESS',
		Getutcdate(),
		@CreatedUser,
		@CreatedUser
	);

	Declare @QuizAttemptId BigInt = Scope_Identity();

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
		'Create',
		'QUIZ',
		'QuizAttempt',
		Convert(Nvarchar(100), @QuizAttemptId)
	);

	Select
		@QuizAttemptId;
End
