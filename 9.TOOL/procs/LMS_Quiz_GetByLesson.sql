Create Procedure dbo.LMS_Quiz_GetByLesson
(
	@LessonId BigInt,
	@ActorId BigInt,
	@IsAdmin Bit = 0
)
As
Begin
	Set Nocount On;

	Select
		LMS_Quizzes.QuizID,
		LMS_Quizzes.LessonID,
		LMS_Quizzes.Title,
		LMS_Quizzes.Description,
		LMS_Quizzes.PassingScore,
		LMS_Quizzes.MaxAttempts,
		LMS_Quizzes.TimeLimitMinutes,
		LMS_Quizzes.RandomizeQuestions,
		LMS_Quizzes.ShowResultsImmediately,
		LMS_Quizzes.Status,
		LMS_Quizzes.CreatedByUserID,
		LMS_Quizzes.CreatedAt,
		LMS_Quizzes.UpdatedAt,
		SIM_Lessons.LessonID,
		SIM_Lessons.Title as LessonTitle,
		SIM_Lessons.Description as LessonDescription,
		SIM_Lessons.LessonType,
		SIM_Courses.CourseID,
		SIM_Courses.Title as CourseTitle
	From dbo.SIM_Lessons
		Inner Join dbo.SIM_Courses on SIM_Courses.CourseID = SIM_Lessons.CourseID
		Inner Join dbo.LMS_Quizzes on LMS_Quizzes.LessonID = SIM_Lessons.LessonID
	Where SIM_Lessons.LessonID = @LessonId
		and SIM_Lessons.IsDeleted = 0
		and LMS_Quizzes.IsDeleted = 0
		and LMS_Quizzes.Status = 'ACTIVE'
		and
		(
			@IsAdmin = 1
			Or SIM_Courses.TeacherUserID = @ActorId
			Or LMS_Quizzes.CreatedByUserID = @ActorId
		);
End
