Create Procedure dbo.LMS_Lesson_AttachVideo
(
	@LessonId BigInt,
	@VideoId BigInt,
	@ActorId BigInt,
	@IsAdmin Bit = 0,
	@UpdatedUser Nvarchar(100) = Null
)
As
Begin
	Set Nocount On;
	Set Xact_Abort On;

	-- Validate lesson Exists
	If Not Exists
	(
		Select
			1
		From dbo.SIM_Lessons
		Where SIM_Lessons.LessonID = @LessonId
			and SIM_Lessons.IsDeleted = 0
	)
		Throw 50002, N'Bài học không tồn tại.', 1;

	-- Validate video Exists
	If Not Exists
	(
		Select
			1
		From dbo.SIM_Videos
		Where SIM_Videos.VideoID = @VideoId
	)
		Throw 50003, N'Video không tồn tại.', 1;

	-- Check authorization
	Declare @CourseID BigInt;
	Select @CourseID = SIM_Lessons.CourseID
	From dbo.SIM_Lessons
	Where SIM_Lessons.LessonID = @LessonId;

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
			Throw 50004, N'Bạn không có quyền cập nhật bài học này.', 1;
	End

	Begin Transaction;

	Update dbo.SIM_Lessons
	Set
		VideoID = @VideoId,
		UpdatedAt = Getutcdate(),
		UpdatedUser = @UpdatedUser
	Where SIM_Lessons.LessonID = @LessonId;

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
		'ATTACH',
		'Lesson',
		'LessonVideo',
		Concat(Convert(Nvarchar(100), @LessonId), '-', Convert(Nvarchar(100), @VideoId))
	);

	Select
		@LessonId as LessonID,
		@VideoId as VideoID;
End
