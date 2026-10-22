Create Procedure dbo.LMS_QuizQuestion_Create
(
	@Id BigInt = Null,
	@QuizId BigInt,
	@QuestionText Nvarchar(Max),
	@QuestionType Varchar(50),
	@Points Decimal(8, 2) = 1.0,
	@CorrectAnswerText Nvarchar(Max) = Null,
	@Option1 Nvarchar(500) = Null,
	@Option2 Nvarchar(500) = Null,
	@Option3 Nvarchar(500) = Null,
	@Option4 Nvarchar(500) = Null,
	@Option5 Nvarchar(500) = Null,
	@CorrectOption Int = Null,
	@Explanation Nvarchar(Max) = Null,
	@SortOrder Int = 0,
	@ActorId BigInt,
	@CreatedUser Nvarchar(100) = Null
)
As
Begin
	Set Nocount On;

	If Nullif(Ltrim(Rtrim(@QuestionText)), '') Is Null
		Or @Points <= 0
		Throw 50001, N'Dữ liệu câu hỏi không hợp lệ.', 1;

	If @QuestionType = 'MULTIPLE_CHOICE' And @CorrectOption Is Null
		Throw 50001, N'Câu hỏi trắc nghiệm phải có đáp án đúng.', 1;

	If Not Exists
	(
		Select
			1
		From dbo.SIM_Quizzes
			Inner Join dbo.SIM_Lessons on SIM_Lessons.LessonID = SIM_Quizzes.LessonID
			Inner Join dbo.SIM_Courses on SIM_Courses.CourseID = SIM_Lessons.CourseID
		Where SIM_Quizzes.QuizID = @QuizId
			and SIM_Quizzes.IsDeleted = 0
			and SIM_Courses.TeacherUserID = @ActorId
	)
		Throw 50003, N'Bạn không có quyền tạo câu hỏi cho bài kiểm tra này.', 1;

	Insert Into dbo.SIM_QuizQuestions
	(
		QuizID,
		QuestionText,
		QuestionType,
		Points,
		CorrectAnswerText,
		Option1,
		Option2,
		Option3,
		Option4,
		Option5,
		CorrectOption,
		Explanation,
		SortOrder,
		CreatedByUserID,
		CreatedUser,
		UpdatedUser
	)
	Values
	(
		@QuizId,
		@QuestionText,
		@QuestionType,
		@Points,
		@CorrectAnswerText,
		@Option1,
		@Option2,
		@Option3,
		@Option4,
		@Option5,
		@CorrectOption,
		@Explanation,
		@SortOrder,
		@ActorId,
		@CreatedUser,
		@CreatedUser
	);

	Declare @QuestionId BigInt = Scope_Identity();

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
		'QuizQuestion',
		Convert(Nvarchar(100), @QuestionId)
	);

	Select
		@QuestionId;
End
