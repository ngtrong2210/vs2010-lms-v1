Create Procedure dbo.LMS_Chapter_Reorder
(
	@CourseID BigInt,
	@ChapterIDs NVarChar(Max) -- Comma-separated chapter IDs in desired order
)
As
Begin
	Set Nocount On;

	-- Verify the course exists
	If Not Exists (Select 1 From dbo.SIM_Courses Where CourseID = @CourseID)
		Throw 50001, N'Khóa học không tồn tại.', 1;

	-- Parse the chapter IDs and update sort order
	-- Using a simple approach with XML parsing
	Declare @Xml Xml = N'<r>' + Replace(@ChapterIDs, ',', '</r><r>') + '</r>';

	-- Update sort order based on position in the list
	With CTE As
	(
		Select
			Cast(r.n.value('.', 'BigInt') as BigInt) as ChapterID,
			Row_Number() Over (Order By (Select 1)) as NewSortOrder
		From @Xml.nodes('//r') as r(n)
	)
	Update c
	Set SortOrder = cte.NewSortOrder,
		UpdatedAt = GetDate()
	From dbo.SIM_Chapters c
	Inner Join CTE cte on c.ChapterID = cte.ChapterID
	Where c.CourseID = @CourseID;

	Select @@ROWCOUNT as RowsAffected;
End
