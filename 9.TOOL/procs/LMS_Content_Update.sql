Create Procedure dbo.LMS_Content_Update
(
	@ContentItemID BigInt,
	@Title NVarChar(255),
	@Description NVarChar(Max) = Null,
	@ContentType NVarChar(50) = Null,
	@ContentUrl NVarChar(500) = Null,
	@VideoAssetID BigInt = Null,
	@SortOrder Int = Null,
	@Status NVarChar(50) = Null
)
As
Begin
	Set Nocount On;

	-- Verify the content item exists
	If Not Exists (Select 1 From dbo.SIM_ContentItems Where ContentItemID = @ContentItemID)
		Throw 50001, N'Nội dung không tồn tại.', 1;

	Update dbo.SIM_ContentItems
	Set
		Title = IsNull(@Title, Title),
		Description = IsNull(@Description, Description),
		ContentType = IsNull(@ContentType, ContentType),
		ContentUrl = IsNull(@ContentUrl, ContentUrl),
		VideoAssetID = IsNull(@VideoAssetID, VideoAssetID),
		SortOrder = IsNull(@SortOrder, SortOrder),
		Status = IsNull(@Status, Status),
		UpdatedAt = GetDate()
	Where ContentItemID = @ContentItemID;

	Select @@ROWCOUNT as RowsAffected;
End
