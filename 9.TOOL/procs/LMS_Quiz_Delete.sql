Create Procedure dbo.LMS_Quiz_Delete
(
	@Id BigInt,
	@ActorId BigInt,
	@IsAdmin Bit = 0,
	@UpdatedUser Nvarchar(100) = Null
)
As
Begin
	Set Nocount On;

	Update dbo.SIM_Quizzes
	Set IsDeleted = 1,
		UpdatedAt = Getutcdate(),
		UpdatedUser = @UpdatedUser
	Where SIM_Quizzes.QuizID = @Id
		and SIM_Quizzes.IsDeleted = 0
		and
		(
			@IsAdmin = 1
			Or SIM_Quizzes.CreatedByUserID = @ActorId
			Or Exists
			(
				Select
					1
				From dbo.SIM_Lessons
					Inner Join dbo.SIM_Courses on SIM_Courses.CourseID = SIM_Lessons.CourseID
				Where SIM_Lessons.LessonID = SIM_Quizzes.LessonID
					and SIM_Courses.TeacherUserID = @ActorId
			)
		);

	Declare @Rows Int = @@RowCount;

	If @Rows = 0
		Throw 50003, N'Không tìm thấy bài kiểm tra hoặc bạn không có quyền xóa.', 1;

	If @Rows > 0
	Begin
		Update dbo.SIM_QuizQuestions
		Set IsDeleted = 1,
			UpdatedAt = Getutcdate()
		Where SIM_QuizQuestions.QuizID = @Id
			and SIM_QuizQuestions.IsDeleted = 0;

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
			'Quiz',
			Convert(Nvarchar(100), @Id)
		);
	End

	Select
		@Rows;
End
