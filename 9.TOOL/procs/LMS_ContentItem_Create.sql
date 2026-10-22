Create Procedure dbo.LMS_ContentItem_Create
(
	@LessonId BigInt,
	@Title Nvarchar(200),
	@ContentType Varchar(50),
	@ContentUrl Nvarchar(500) = Null,
	@ContentText Nvarchar(Max) = Null,
	@SortOrder Int = 0,
	@DurationMinutes Int = 0,
	@ActorId BigInt,
	@IsAdmin Bit = 0,
	@CreatedUser Nvarchar(100) = Null
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
			Throw 50003, N'Bạn không có quyền tạo nội dung trong bài học này.', 1;
	End

	Begin Transaction;

	Declare @ContentId BigInt;
	Select @ContentId = NextId
	From dbo.Sequence
	Where Name = 'ContentItem';

	Update dbo.Sequence
	Set NextId = NextId + 1
	Where Name = 'ContentItem';

	Insert Into dbo.SIM_ContentItems
	(
		ContentID,
		LessonID,
		Title,
		ContentType,
		ContentUrl,
		ContentText,
		SortOrder,
		DurationMinutes,
		CreatedUser,
		UpdatedUser
	)
	Values
	(
		@ContentId,
		@LessonId,
		@Title,
		@ContentType,
		@ContentUrl,
		@ContentText,
		@SortOrder,
		@DurationMinutes,
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
		@ActorId,
		'Create',
		'CONTENT',
		'ContentItem',
		Convert(Nvarchar(100), @ContentId)
	);

	Select
		@ContentId as ContentID;
End
