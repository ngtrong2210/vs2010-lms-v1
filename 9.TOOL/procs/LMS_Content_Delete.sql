Create Procedure dbo.LMS_Content_Delete
(
	@ContentItemID BigInt
)
As
Begin
	Set Nocount On;

	-- Verify the content item exists
	If Not Exists (Select 1 From dbo.SIM_ContentItems Where ContentItemID = @ContentItemID)
		Throw 50001, N'Nội dung không tồn tại.', 1;

	-- Soft delete the content item
	Update dbo.SIM_ContentItems
	Set IsDeleted = 1,
		UpdatedAt = GetDate()
	Where ContentItemID = @ContentItemID;

	Select @@ROWCOUNT as RowsAffected;
End
