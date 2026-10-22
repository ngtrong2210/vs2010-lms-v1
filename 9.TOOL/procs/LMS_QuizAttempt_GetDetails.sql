Create Procedure dbo.LMS_QuizAttempt_GetDetails
(
	@QuizAttemptId BigInt,
	@ActorId BigInt,
	@IsAdmin Bit = 0
)
As
Begin
	Set Nocount On;

	Select
		SIM_QuizAttempts.QuizAttemptID,
		SIM_QuizAttempts.QuizID,
		SIM_QuizAttempts.StudentUserID,
		SIM_Users.FullName as StudentName,
		SIM_Users.Email as StudentEmail,
		SIM_QuizAttempts.AttemptNumber,
		SIM_QuizAttempts.StartedAt,
		SIM_QuizAttempts.SubmittedAt,
		SIM_QuizAttempts.Score,
		SIM_QuizAttempts.MaxScore,
		SIM_QuizAttempts.ScorePercent,
		SIM_QuizAttempts.Passed,
		SIM_QuizAttempts.AttemptStatus,
		SIM_Quizzes.Title as QuizTitle,
		SIM_Quizzes.PassingScore,
		SIM_Quizzes.TimeLimitMinutes,
		SIM_Lessons.LessonID,
		SIM_Lessons.Title as LessonTitle,
		SIM_Courses.CourseID,
		SIM_Courses.Title as CourseTitle
	From dbo.SIM_QuizAttempts
		Inner Join dbo.SIM_Quizzes on SIM_Quizzes.QuizID = SIM_QuizAttempts.QuizID
		Inner Join dbo.SIM_Lessons on SIM_Lessons.LessonID = SIM_Quizzes.LessonID
		Inner Join dbo.SIM_Courses on SIM_Courses.CourseID = SIM_Lessons.CourseID
		Inner Join dbo.SIM_Users on SIM_Users.UserID = SIM_QuizAttempts.StudentUserID
	Where SIM_QuizAttempts.QuizAttemptID = @QuizAttemptId
		and
		(
			@IsAdmin = 1
			Or SIM_QuizAttempts.StudentUserID = @ActorId
			Or SIM_Courses.TeacherUserID = @ActorId
		);

	Select
		SIM_QuizAttemptAnswers.QuizAttemptAnswerID,
		SIM_QuizAttemptAnswers.QuizAttemptID,
		SIM_QuizAttemptAnswers.QuestionID,
		SIM_QuizQuestions.QuestionText,
		SIM_QuizQuestions.QuestionType,
		SIM_QuizQuestions.Points,
		SIM_QuizQuestions.Option1,
		SIM_QuizQuestions.Option2,
		SIM_QuizQuestions.Option3,
		SIM_QuizQuestions.Option4,
		SIM_QuizQuestions.Option5,
		SIM_QuizQuestions.CorrectOption,
		SIM_QuizQuestions.CorrectAnswerText,
		SIM_QuizQuestions.Explanation,
		SIM_QuizAttemptAnswers.AnswerText,
		SIM_QuizAttemptAnswers.IsCorrect,
		SIM_QuizAttemptAnswers.ScoreAwarded
	From dbo.SIM_QuizAttemptAnswers
		Inner Join dbo.SIM_QuizQuestions on SIM_QuizQuestions.QuestionID = SIM_QuizAttemptAnswers.QuestionID
	Where SIM_QuizAttemptAnswers.QuizAttemptID = @QuizAttemptId
	Order By
		SIM_QuizQuestions.SortOrder,
		SIM_QuizQuestions.QuestionID;
End
