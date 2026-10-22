Create Procedure dbo.LMS_QuizQuestion_Update
(
	@Id BigInt,
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
	@IsAdmin Bit = 0,
	@UpdatedUser Nvarchar(100) = Null
)
As
Begin
	Set Nocount On;

	If Nullif(Ltrim(Rtrim(@QuestionText)), '') Is Null
		Or @Points <= 0
		Throw 50001, N'Dữ liệu câu hỏi không hợp lệ.', 1;

	If @QuestionType = 'MULTIPLE_CHOICE' And @CorrectOption Is Null
		Throw 50001, N'Câu hỏi trắc nghiệm phải có đáp án đúng.', 1;

	Update dbo.SIM_QuizQuestions
	Set
		QuestionText = @QuestionText,
		QuestionType = @QuestionType,
		Points = @Points,
		CorrectAnswerText = @CorrectAnswerText,
		Option1 = @Option1,
		Option2 = @Option2,
		Option3 = @Option3,
		Option4 = @Option4,
		Option5 = @Option5,
		CorrectOption = @CorrectOption,
		Explanation = @Explanation,
		SortOrder = @SortOrder,
		UpdatedAt = Getutcdate(),
		UpdatedUser = @UpdatedUser
	Where SIM_QuizQuestions.QuestionID = @Id
		and SIM_QuizQuestions.IsDeleted = 0
		and
		(
			@IsAdmin = 1
			Or SIM_QuizQuestions.CreatedByUserID = @ActorId
			Or Exists
			(
				Select
					1
				From dbo.SIM_Quizzes
					Inner Join dbo.SIM_Lessons on SIM_Lessons.LessonID = SIM_Quizzes.LessonID
					Inner Join dbo.SIM_Courses on SIM_Courses.CourseID = SIM_Lessons.CourseID
				Where SIM_Quizzes.QuizID = SIM_QuizQuestions.QuizID
					and SIM_Courses.TeacherUserID = @ActorId
			)
		);

	If @@RowCount = 0
		Throw 50003, N'Không tìm thấy câu hỏi hoặc bạn không có quyền sửa.', 1;

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
		'QuizQuestion',
		Convert(Nvarchar(100), @Id)
	);

	Select
		@Id;
End
