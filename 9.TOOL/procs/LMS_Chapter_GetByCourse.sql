Create Procedure dbo.LMS_Chapter_GetByCourse
(
	@CourseID BigInt
)
As
Begin
	Set Nocount On;

	Select
		SIM_Chapters.ChapterID,
		SIM_Chapters.CourseID,
		SIM_Chapters.Title,
		SIM_Chapters.Description,
		SIM_Chapters.SortOrder,
		SIM_Chapters.Status,
		SIM_Chapters.CreatedAt,
		SIM_Chapters.UpdatedAt
	From dbo.SIM_Chapters
	Where SIM_Chapters.CourseID = @CourseID
		and SIM_Chapters.IsDeleted = 0
	Order By
		SIM_Chapters.SortOrder,
		SIM_Chapters.ChapterID;
End
