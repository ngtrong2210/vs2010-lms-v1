Create Procedure dbo.LMS_ContentItem_Delete
(
	@ContentId BigInt,
	@ActorId BigInt,
	@IsAdmin Bit = 0,
	@UpdatedUser Nvarchar(100) = Null
)
As
Begin
	Set Nocount On;
	Set Xact_Abort On;

	-- Validate content item Exists
	If Not Exists
	(
		Select
			1
		From dbo.SIM_ContentItems
		Where SIM_ContentItems.ContentID = @ContentId
			and SIM_ContentItems.IsDeleted = 0
	)
		Throw 50002, N'Nội dung không tồn tại.', 1;

	-- Check authorization
	Declare @LessonId BigInt;
	Declare @CourseID BigInt;

	Select @LessonId = SIM_ContentItems.LessonID
	From dbo.SIM_ContentItems
	Where SIM_ContentItems.ContentID = @ContentId;

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
			Throw 50003, N'Bạn không có quyền xóa nội dung này.', 1;
	End

	Begin Transaction;

	-- Soft Delete the content item
	Update dbo.SIM_ContentItems
	Set
		IsDeleted = 1,
		DeletedAt = Getutcdate(),
		UpdatedAt = Getutcdate(),
		UpdatedUser = @UpdatedUser
	Where SIM_ContentItems.ContentID = @ContentId;

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
		'CONTENT',
		'ContentItem',
		Convert(Nvarchar(100), @ContentId)
	);

	Select
		@ContentId as ContentID;
End
