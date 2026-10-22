Create Procedure dbo.LMS_Chapter_Create
(
	@CourseID BigInt,
	@Title NVarChar(255),
	@Description NVarChar(Max) = Null,
	@SortOrder Int = 0,
	@Status NVarChar(50) = 'DRAFT',
	@CreatedByUserId BigInt
)
As
Begin
	Set Nocount On;

	-- Verify the course exists
	If Not Exists (Select 1 From dbo.SIM_Courses Where CourseID = @CourseID)
		Throw 50001, N'Khóa học không tồn tại.', 1;

	-- If SortOrder is 0, append to end
	If @SortOrder = 0
		Select @SortOrder = IsNull(Max(SortOrder), 0) + 1
		From dbo.SIM_Chapters
		Where CourseID = @CourseID;

	Insert Into dbo.SIM_Chapters
	(
		CourseID,
		Title,
		Description,
		SortOrder,
		Status,
		CreatedAt,
		UpdatedAt,
		IsDeleted
	)
	Values
	(
		@CourseID,
		@Title,
		@Description,
		@SortOrder,
		@Status,
		GetDate(),
		GetDate(),
		0
	);

	Select Cast(SCOPE_IDENTITY() as BigInt) as ChapterID;
End
