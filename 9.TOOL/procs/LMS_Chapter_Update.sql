Create Procedure dbo.LMS_Chapter_Update
(
	@ChapterID BigInt,
	@Title NVarChar(255),
	@Description NVarChar(Max) = Null,
	@SortOrder Int = Null,
	@Status NVarChar(50) = Null
)
As
Begin
	Set Nocount On;

	-- Verify the chapter exists
	If Not Exists (Select 1 From dbo.SIM_Chapters Where ChapterID = @ChapterID)
		Throw 50001, N'Chương không tồn tại.', 1;

	Update dbo.SIM_Chapters
	Set
		Title = IsNull(@Title, Title),
		Description = IsNull(@Description, Description),
		SortOrder = IsNull(@SortOrder, SortOrder),
		Status = IsNull(@Status, Status),
		UpdatedAt = GetDate()
	Where ChapterID = @ChapterID;

	Select @@ROWCOUNT as RowsAffected;
End
