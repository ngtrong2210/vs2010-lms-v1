Create Procedure dbo.LMS_Quiz_GetQuestions
(
	@QuizId BigInt,
	@StudentUserId BigInt,
	@IsAdmin Bit = 0
)
As
Begin
	Set Nocount On;

	-- Check If student Has access to the quiz
	If @IsAdmin = 0
	Begin
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
			Throw 50003, N'Bạn không có quyền truy cập bài kiểm tra này.', 1;
	End

	-- Get quiz details
	Select
		SIM_Quizzes.QuizID,
		SIM_Quizzes.Title,
		SIM_Quizzes.Description,
		SIM_Quizzes.PassingScore,
		SIM_Quizzes.TimeLimitMinutes,
		SIM_Quizzes.MaxAttempts,
		SIM_Quizzes.ShuffleQuestions,
		SIM_Quizzes.ShowResultsImmediately,
		SIM_Quizzes.LessonID,
		SIM_Lessons.Title as LessonTitle,
		SIM_Courses.CourseID,
		SIM_Courses.Title as CourseTitle
	From dbo.SIM_Quizzes
		Inner Join dbo.SIM_Lessons on SIM_Lessons.LessonID = SIM_Quizzes.LessonID
		Inner Join dbo.SIM_Courses on SIM_Courses.CourseID = SIM_Lessons.CourseID
	Where SIM_Quizzes.QuizID = @QuizId
		and SIM_Quizzes.IsDeleted = 0;

	-- Get questions (hide correct answers for students)
	Select
		SIM_QuizQuestions.QuestionID,
		SIM_QuizQuestions.QuizID,
		SIM_QuizQuestions.QuestionText,
		SIM_QuizQuestions.QuestionType,
		SIM_QuizQuestions.Points,
		SIM_QuizQuestions.SortOrder,
		SIM_QuizQuestions.Option1,
		SIM_QuizQuestions.Option2,
		SIM_QuizQuestions.Option3,
		SIM_QuizQuestions.Option4,
		SIM_QuizQuestions.Option5,
		Case When @IsAdmin = 1 Then SIM_QuizQuestions.CorrectOption Else Null End as CorrectOption,
		Case When @IsAdmin = 1 Then SIM_QuizQuestions.CorrectAnswerText Else Null End as CorrectAnswerText,
		SIM_QuizQuestions.Explanation
	From dbo.SIM_QuizQuestions
	Where SIM_QuizQuestions.QuizID = @QuizId
		and SIM_QuizQuestions.IsDeleted = 0
	Order By
		Case When
			(Select ShuffleQuestions From dbo.SIM_Quizzes Where SIM_Quizzes.QuizID = @QuizId) = 1
			Then Newid()
			Else 0
		End,
		SIM_QuizQuestions.SortOrder,
		SIM_QuizQuestions.QuestionID;
End
