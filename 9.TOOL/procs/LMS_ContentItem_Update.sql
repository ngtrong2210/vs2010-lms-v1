Create Procedure dbo.LMS_ContentItem_Update
(
	@ContentId BigInt,
	@Title Nvarchar(200) = Null,
	@ContentType Varchar(50) = Null,
	@ContentUrl Nvarchar(500) = Null,
	@ContentText Nvarchar(Max) = Null,
	@SortOrder Int = Null,
	@DurationMinutes Int = Null,
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
			Throw 50003, N'Bạn không có quyền cập nhật nội dung này.', 1;
	End

	Begin Transaction;

	Update dbo.SIM_ContentItems
	Set
		Title = Isnull(@Title, SIM_ContentItems.Title),
		ContentType = Isnull(@ContentType, SIM_ContentItems.ContentType),
		ContentUrl = Isnull(@ContentUrl, SIM_ContentItems.ContentUrl),
		ContentText = Isnull(@ContentText, SIM_ContentItems.ContentText),
		SortOrder = Isnull(@SortOrder, SIM_ContentItems.SortOrder),
		DurationMinutes = Isnull(@DurationMinutes, SIM_ContentItems.DurationMinutes),
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
		'Update',
		'CONTENT',
		'ContentItem',
		Convert(Nvarchar(100), @ContentId)
	);

	Select
		@ContentId as ContentID;
End
