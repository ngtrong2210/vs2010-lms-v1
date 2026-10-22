Create Procedure dbo.LMS_QuizQuestion_Delete
(
	@Id BigInt,
	@ActorId BigInt,
	@IsAdmin Bit = 0,
	@UpdatedUser Nvarchar(100) = Null
)
As
Begin
	Set Nocount On;

	Update dbo.SIM_QuizQuestions
	Set IsDeleted = 1,
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

	Declare @Rows Int = @@RowCount;

	If @Rows = 0
		Throw 50003, N'Không tìm thấy câu hỏi hoặc bạn không có quyền xóa.', 1;

	If @Rows > 0
	Begin
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
			'Delete',
			'QUIZ',
			'QuizQuestion',
			Convert(Nvarchar(100), @Id)
		);
	End

	Select
		@Rows;
End
