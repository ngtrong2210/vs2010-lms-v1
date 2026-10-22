Create Procedure dbo.LMS_QuizAttempt_GetHistory
(
	@QuizId BigInt,
	@StudentUserId BigInt
)
As
Begin
	Set Nocount On;

	-- Validate quiz Exists
	If Not Exists
	(
		Select
			1
		From dbo.SIM_Quizzes
		Where SIM_Quizzes.QuizID = @QuizId
			and SIM_Quizzes.IsDeleted = 0
	)
		Throw 50002, N'Bài kiểm tra không tồn tại.', 1;

	-- Get attempt history for the student
	Select
		SIM_QuizAttempts.QuizAttemptID,
		SIM_QuizAttempts.QuizID,
		SIM_Quizzes.Title as QuizTitle,
		SIM_Quizzes.PassingScore,
		SIM_QuizAttempts.StudentUserID,
		SIM_Users.FullName as StudentName,
		SIM_QuizAttempts.AttemptNumber,
		SIM_QuizAttempts.AttemptStatus,
		SIM_QuizAttempts.StartedAt,
		SIM_QuizAttempts.SubmittedAt,
		SIM_QuizAttempts.Score,
		SIM_QuizAttempts.MaxScore,
		SIM_QuizAttempts.ScorePercent,
		SIM_QuizAttempts.Passed,
		SIM_QuizAttempts.CreatedAt
	From dbo.SIM_QuizAttempts
		Inner Join dbo.SIM_Quizzes on SIM_Quizzes.QuizID = SIM_QuizAttempts.QuizID
		Inner Join dbo.SIM_Users on SIM_Users.UserID = SIM_QuizAttempts.StudentUserID
	Where SIM_QuizAttempts.QuizID = @QuizId
		and SIM_QuizAttempts.StudentUserID = @StudentUserId
	Order By
		SIM_QuizAttempts.StartedAt Desc;

	-- Get attempt Count
	Select
		Count(*) as TotalAttempts,
		Sum(Case When SIM_QuizAttempts.Passed = 1 Then 1 Else 0 End) as PassedAttempts,
		Max(SIM_QuizAttempts.ScorePercent) as BestScore
	From dbo.SIM_QuizAttempts
	Where SIM_QuizAttempts.QuizID = @QuizId
		and SIM_QuizAttempts.StudentUserID = @StudentUserId;
End
