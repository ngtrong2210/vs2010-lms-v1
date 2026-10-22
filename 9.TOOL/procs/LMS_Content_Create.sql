Create Procedure dbo.LMS_Content_Create
(
	@LessonID BigInt,
	@ChapterID BigInt = Null,
	@Title NVarChar(255),
	@Description NVarChar(Max) = Null,
	@ContentType NVarChar(50),
	@ContentUrl NVarChar(500) = Null,
	@VideoAssetID BigInt = Null,
	@SortOrder Int = 0,
	@Status NVarChar(50) = 'DRAFT',
	@CreatedByUserId BigInt
)
As
Begin
	Set Nocount On;

	-- Verify the lesson exists
	If Not Exists (Select 1 From dbo.SIM_Lessons Where LessonID = @LessonID)
		Throw 50001, N'Bài học không tồn tại.', 1;

	-- If SortOrder is 0, append to end
	If @SortOrder = 0
		Select @SortOrder = IsNull(Max(SortOrder), 0) + 1
		From dbo.SIM_ContentItems
		Where LessonID = @LessonID;

	Insert Into dbo.SIM_ContentItems
	(
		LessonID,
		ChapterID,
		Title,
		Description,
		ContentType,
		ContentUrl,
		VideoAssetID,
		SortOrder,
		Status,
		CreatedAt,
		UpdatedAt,
		IsDeleted
	)
	Values
	(
		@LessonID,
		@ChapterID,
		@Title,
		@Description,
		@ContentType,
		@ContentUrl,
		@VideoAssetID,
		@SortOrder,
		@Status,
		GetDate(),
		GetDate(),
		0
	);

	Select Cast(SCOPE_IDENTITY() as BigInt) as ContentItemID;
End
