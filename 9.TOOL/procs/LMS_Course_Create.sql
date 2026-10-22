Create Procedure dbo.LMS_Course_Create
(
	@Title Nvarchar(200),
	@Description Nvarchar(Max) = Null,
	@ThumbnailUrl Nvarchar(500) = Null,
	@CategoryID BigInt = Null,
	@TeacherUserId BigInt,
	@CreatedUser Nvarchar(100) = Null
)
As
Begin
	Set Nocount On;
	Set Xact_Abort On;

	-- Validate teacher Exists
	If Not Exists
	(
		Select
			1
		From dbo.SIM_Users
		Where SIM_Users.UserID = @TeacherUserId
			and SIM_Users.IsDeleted = 0
	)
		Throw 50002, N'Giáo viên không tồn tại.', 1;

	Begin Transaction;

	Declare @CourseID BigInt;
	Select @CourseID = NextId
	From dbo.Sequence
	Where Name = 'Course';

	Update dbo.Sequence
	Set NextId = NextId + 1
	Where Name = 'Course';

	Insert Into dbo.SIM_Courses
	(
		CourseID,
		Title,
		Description,
		ThumbnailUrl,
		CategoryID,
		TeacherUserID,
		Status,
		TotalDurationMinutes,
		CreatedUser,
		UpdatedUser
	)
	Values
	(
		@CourseID,
		@Title,
		@Description,
		@ThumbnailUrl,
		@CategoryID,
		@TeacherUserId,
		'DRAFT',
		0,
		@CreatedUser,
		@CreatedUser
	);

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
		@TeacherUserId,
		'CREATE',
		'Course',
		'Course',
		Convert(Nvarchar(100), @CourseID)
	);

	Select
		@CourseID as CourseID;
End
