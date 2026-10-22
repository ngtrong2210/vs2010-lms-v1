Create Procedure dbo.LMS_QuizAttempt_Submit
(
	@QuizAttemptId BigInt,
	@StudentUserId BigInt,
	@UpdatedUser Nvarchar(100) = Null
)
As
Begin
	Set Nocount On;
	Set Xact_Abort On;

	-- Validate the attempt Exists And belongs to the student
	If Not Exists
	(
		Select
			1
		From dbo.SIM_QuizAttempts
		Where SIM_QuizAttempts.QuizAttemptID = @QuizAttemptId
			and SIM_QuizAttempts.StudentUserID = @StudentUserId
			and SIM_QuizAttempts.AttemptStatus = 'IN_PROGRESS'
	)
		Throw 50002, N'Bài kiểm tra không tồn tại hoặc đã được nộp.', 1;

	Declare @QuizId BigInt;
	Declare @PassingScore Decimal(5, 2);
	Declare @MaxScore Decimal(10, 2);

	Select
		@QuizId = QuizID
	From dbo.SIM_QuizAttempts
	Where SIM_QuizAttempts.QuizAttemptID = @QuizAttemptId;

	Select
		@PassingScore = PassingScore
	From dbo.SIM_Quizzes
	Where SIM_Quizzes.QuizID = @QuizId;

	-- Calculate total score
	Declare @TotalScore Decimal(10, 2) = 0;
	Declare @TotalMaxScore Decimal(10, 2) = 0;

	Select
		@TotalScore = Sum(Cast(SIM_QuizAttemptAnswers.IsCorrect As Int) * SIM_QuizQuestions.Points),
		@TotalMaxScore = Sum(SIM_QuizQuestions.Points)
	From dbo.SIM_QuizAttemptAnswers
		Inner Join dbo.SIM_QuizQuestions on SIM_QuizQuestions.QuestionID = SIM_QuizAttemptAnswers.QuestionID
	Where SIM_QuizAttemptAnswers.QuizAttemptID = @QuizAttemptId;

	Set @MaxScore = IsNull(@TotalMaxScore, 0);

	Declare @ScorePercent Decimal(5, 2);
	If @MaxScore > 0
		Set @ScorePercent = (@TotalScore / @MaxScore) * 100;
	Else
		Set @ScorePercent = 0;

	Declare @Passed Bit = 0;
	If @ScorePercent >= @PassingScore
		Set @Passed = 1;

	Begin Transaction;

	Update dbo.SIM_QuizAttempts
	Set
		AttemptStatus = 'SUBMITTED',
		SubmittedAt = Getutcdate(),
		Score = @TotalScore,
		MaxScore = @MaxScore,
		ScorePercent = @ScorePercent,
		Passed = @Passed,
		UpdatedAt = Getutcdate(),
		UpdatedUser = @UpdatedUser
	Where SIM_QuizAttempts.QuizAttemptID = @QuizAttemptId;

	-- Update lesson progress If quiz is passed
	If @Passed = 1
	Begin
		Declare @LessonId BigInt;
		Select @LessonId = LessonID From dbo.SIM_Quizzes Where SIM_Quizzes.QuizID = @QuizId;

		Merge dbo.SIM_StudentLessonProgress As Target
		Using (Select @StudentUserId StudentUserID, @LessonId LessonID) As Source
			On Target.StudentUserID = Source.StudentUserID And Target.LessonID = Source.LessonID
		When Matched Then
			Update Set
				Completed = 1,
				CompletedAt = Getutcdate(),
				UpdatedAt = Getutcdate(),
				UpdatedUser = @UpdatedUser
		When Not Matched Then
			Insert (StudentUserID, LessonID, CourseID, ProgressPercent, Score, AttemptCount, Completed, CompletedAt, LastAccessAt, ActiveStudySeconds, CreatedUser, UpdatedUser)
			Values (Source.StudentUserID, Source.LessonID,
				(Select CourseID From dbo.SIM_Lessons Where SIM_Lessons.LessonID = @LessonId),
				100, @ScorePercent, 1, 1, Getutcdate(), Getutcdate(), 0, @UpdatedUser, @UpdatedUser);
	End

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
		'SUBMIT',
		'QUIZ',
		'QuizAttempt',
		Convert(Nvarchar(100), @QuizAttemptId)
	);

	Select
		@QuizAttemptId QuizAttemptID,
		@TotalScore Score,
		@MaxScore MaxScore,
		@ScorePercent ScorePercent,
		@Passed Passed;
End
