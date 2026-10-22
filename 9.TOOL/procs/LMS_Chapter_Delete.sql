Create Procedure dbo.LMS_Chapter_Delete
(
	@ChapterID BigInt
)
As
Begin
	Set Nocount On;

	-- Verify the chapter exists
	If Not Exists (Select 1 From dbo.SIM_Chapters Where ChapterID = @ChapterID)
		Throw 50001, N'Chương không tồn tại.', 1;

	-- Soft delete the chapter
	Update dbo.SIM_Chapters
	Set IsDeleted = 1,
		UpdatedAt = GetDate()
	Where ChapterID = @ChapterID;

	-- Also soft delete all lessons in this chapter
	Update dbo.SIM_Lessons
	Set IsDeleted = 1,
		UpdatedAt = GetDate()
	Where ChapterID = @ChapterID;

	Select @@ROWCOUNT as RowsAffected;
End
