Create Procedure dbo.LMS_Quiz_GetById
(
	@QuizID BigInt
)
As
Begin
	Set Nocount On;

	Select
		SIM_Quizzes.QuizID,
		SIM_Quizzes.LessonID,
		SIM_Quizzes.CourseID,
		SIM_Quizzes.Title,
		SIM_Quizzes.Description,
		SIM_Quizzes.PassingScore,
		SIM_Quizzes.TimeLimitMinutes,
		SIM_Quizzes.MaxAttempts,
		SIM_Quizzes.RandomizeQuestions,
		SIM_Quizzes.ShowResultsImmediately,
		SIM_Quizzes.Status,
		SIM_Quizzes.CreatedAt,
		SIM_Quizzes.UpdatedAt,
		(
			Select Count(*)
			From dbo.SIM_QuizQuestions
			Where SIM_QuizQuestions.QuizID = SIM_Quizzes.QuizID
				and SIM_QuizQuestions.IsDeleted = 0
		) as QuestionCount
	From dbo.SIM_Quizzes
	Where SIM_Quizzes.QuizID = @QuizID
		and SIM_Quizzes.IsDeleted = 0;
End
