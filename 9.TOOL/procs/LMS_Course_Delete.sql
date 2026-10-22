Create Procedure dbo.LMS_Course_Delete
(
	@CourseID BigInt,
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
			Throw 50003, N'Bạn không có quyền xóa khóa học này.', 1;
	End

	-- Check If Course has active enrollments
	If Exists
	(
		Select
			1
		From dbo.SIM_Enrollments
		Where SIM_Enrollments.CourseID = @CourseID
			and SIM_Enrollments.Status = 'ACTIVE'
	)
		Throw 50004, N'Không thể xóa khóa học có học viên đang học.', 1;

	Begin Transaction;

	-- Soft Delete the Course
	Update dbo.SIM_Courses
	Set
		IsDeleted = 1,
		DeletedAt = Getutcdate(),
		UpdatedAt = Getutcdate(),
		UpdatedUser = @UpdatedUser
	Where SIM_Courses.CourseID = @CourseID;

	-- Soft Delete Associated lessons
	Update dbo.SIM_Lessons
	Set
		IsDeleted = 1,
		DeletedAt = Getutcdate(),
		UpdatedAt = Getutcdate(),
		UpdatedUser = @UpdatedUser
	Where SIM_Lessons.CourseID = @CourseID;

	-- Soft Delete Associated content items
	Update dbo.SIM_ContentItems
	Set
		IsDeleted = 1,
		DeletedAt = Getutcdate(),
		UpdatedAt = Getutcdate(),
		UpdatedUser = @UpdatedUser
	Where SIM_ContentItems.LessonID In
	(
		Select
			SIM_Lessons.LessonID
		From dbo.SIM_Lessons
		Where SIM_Lessons.CourseID = @CourseID
	);

	-- Soft Delete Associated quizzes
	Update dbo.SIM_Quizzes
	Set
		IsDeleted = 1,
		DeletedAt = Getutcdate(),
		UpdatedAt = Getutcdate(),
		UpdatedUser = @UpdatedUser
	Where SIM_Quizzes.LessonID In
	(
		Select
			SIM_Lessons.LessonID
		From dbo.SIM_Lessons
		Where SIM_Lessons.CourseID = @CourseID
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
		@ActorId,
		'Delete',
		'Course',
		'Course',
		Convert(Nvarchar(100), @CourseID)
	);

	Select
		@CourseID as CourseID;
End
