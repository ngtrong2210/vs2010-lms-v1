Create Procedure dbo.LMS_Course_Update
(
	@CourseID BigInt,
	@Title Nvarchar(200) = Null,
	@Description Nvarchar(Max) = Null,
	@ThumbnailUrl Nvarchar(500) = Null,
	@CategoryID BigInt = Null,
	@Status Varchar(50) = Null,
	@TeacherUserId BigInt,
	@ActorId BigInt,
	@IsAdmin Bit = 0,
	@UpdatedUser Nvarchar(100) = Null
)
As
Begin
	Set Nocount On;
	Set Xact_Abort On;

	-- Validate Course Exists
	If Not Exists
	(
		Select
			1
		From dbo.SIM_Courses
		Where SIM_Courses.CourseID = @CourseID
			and SIM_Courses.IsDeleted = 0
	)
		Throw 50002, N'Khóa học không tồn tại.', 1;

	-- Check authorization
	If @IsAdmin = 0
	Begin
		If Not Exists
		(
			Select
				1
			From dbo.SIM_Courses
			Where SIM_Courses.CourseID = @CourseID
				and SIM_Courses.TeacherUserID = @ActorId
		)
			Throw 50003, N'Bạn không có quyền cập nhật khóa học này.', 1;
	End

	Begin Transaction;

	Update dbo.SIM_Courses
	Set
		Title = Isnull(@Title, SIM_Courses.Title),
		Description = Isnull(@Description, SIM_Courses.Description),
		ThumbnailUrl = Isnull(@ThumbnailUrl, SIM_Courses.ThumbnailUrl),
		CategoryID = Isnull(@CategoryID, SIM_Courses.CategoryID),
		Status = Isnull(@Status, SIM_Courses.Status),
		UpdatedAt = Getutcdate(),
		UpdatedUser = @UpdatedUser
	Where SIM_Courses.CourseID = @CourseID;

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
		@ActorId,
		'Update',
		'Course',
		'Course',
		Convert(Nvarchar(100), @CourseID)
	);

	Select
		@CourseID as CourseID;
End
