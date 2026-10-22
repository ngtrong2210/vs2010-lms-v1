Create Procedure dbo.LMS_QuizAttempt_SaveAnswer
(
	@QuizAttemptId BigInt,
	@QuestionId BigInt,
	@AnswerText Nvarchar(Max) = Null,
	@SelectedOption Int = Null,
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

	-- Validate the question Exists And belongs to the quiz
	Declare @QuizId BigInt;
	Select @QuizId = QuizID From dbo.SIM_QuizAttempts Where SIM_QuizAttempts.QuizAttemptID = @QuizAttemptId;

	If Not Exists
	(
		Select
			1
		From dbo.SIM_QuizQuestions
		Where SIM_QuizQuestions.QuestionID = @QuestionId
			and SIM_QuizQuestions.QuizID = @QuizId
			and SIM_QuizQuestions.IsDeleted = 0
	)
		Throw 50003, N'Câu hỏi không tồn tại trong bài kiểm tra này.', 1;

	-- Get question details for grading
	Declare @QuestionType Varchar(50);
	Declare @CorrectOption Int;
	Declare @CorrectAnswerText Nvarchar(Max);
	Declare @Points Decimal(8, 2);

	Select
		@QuestionType = QuestionType,
		@CorrectOption = CorrectOption,
		@CorrectAnswerText = CorrectAnswerText,
		@Points = Points
	From dbo.SIM_QuizQuestions
	Where SIM_QuizQuestions.QuestionID = @QuestionId;

	-- Determine If answer is correct
	Declare @IsCorrect Bit = 0;
	Declare @ScoreAwarded Decimal(8, 2) = 0;

	If @QuestionType = 'MULTIPLE_CHOICE'
	Begin
		If @SelectedOption = @CorrectOption
		Begin
			Set @IsCorrect = 1;
			Set @ScoreAwarded = @Points;
		End
	End
	Else If @QuestionType = 'TRUE_FALSE'
	Begin
		If @SelectedOption = @CorrectOption
		Begin
			Set @IsCorrect = 1;
			Set @ScoreAwarded = @Points;
		End
	End
	Else If @QuestionType = 'SHORT_ANSWER'
	Begin
		-- Simple comparison for short answer (can be enhanced With fuzzy matching)
		If Ltrim(Rtrim(@AnswerText)) = Ltrim(Rtrim(@CorrectAnswerText))
		Begin
			Set @IsCorrect = 1;
			Set @ScoreAwarded = @Points;
		End
	End
	Else If @QuestionType = 'ESSAY'
	Begin
		-- Essay questions require manual grading
		Set @IsCorrect = Null;
		Set @ScoreAwarded = 0;
	End

	Begin Transaction;

	Merge dbo.SIM_QuizAttemptAnswers As Target
	Using (Select @QuizAttemptId QuizAttemptID, @QuestionId QuestionID) As Source
		On Target.QuizAttemptID = Source.QuizAttemptID And Target.QuestionID = Source.QuestionID
	When Matched Then
		Update Set
			AnswerText = @AnswerText,
			SelectedOption = @SelectedOption,
			IsCorrect = @IsCorrect,
			ScoreAwarded = @ScoreAwarded,
			UpdatedAt = Getutcdate(),
			UpdatedUser = @UpdatedUser
	When Not Matched Then
		Insert (QuizAttemptID, QuestionID, AnswerText, SelectedOption, IsCorrect, ScoreAwarded, CreatedUser, UpdatedUser)
		Values (Source.QuizAttemptID, Source.QuestionID, @AnswerText, @SelectedOption, @IsCorrect, @ScoreAwarded, @UpdatedUser, @UpdatedUser);

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
		'Save',
		'QUIZ',
		'QuizAttemptAnswer',
		Concat(Convert(Nvarchar(100), @QuizAttemptId), '-', Convert(Nvarchar(100), @QuestionId))
	);

	Select
		@QuestionId QuestionID,
		@AnswerText AnswerText,
		@SelectedOption SelectedOption,
		@IsCorrect IsCorrect,
		@ScoreAwarded ScoreAwarded;
End
