Create Procedure dbo.LMS_Content_GetByLesson
(
	@LessonId BigInt,
	@StudentUserId BigInt,
	@IsAdmin Bit = 0
)
As
Begin
	Set Nocount On;

	Select
		SIM_ContentItems.ContentID,
		SIM_ContentItems.LessonID,
		SIM_ContentItems.Title,
		SIM_ContentItems.Description,
		SIM_ContentItems.ContentType,
		SIM_ContentItems.ContentText,
		SIM_ContentItems.FileUrl,
		SIM_ContentItems.VideoUrl,
		SIM_ContentItems.DurationMinutes,
		SIM_ContentItems.SortOrder,
		SIM_ContentItems.IsPublished,
		SIM_ContentItems.IsDeleted,
		SIM_ContentItems.CreatedAt,
		SIM_ContentItems.UpdatedAt,
		SIM_StudentContentProgress.Completed,
		SIM_StudentContentProgress.WatchedSeconds,
		SIM_StudentContentProgress.LastAccessAt
	From dbo.SIM_ContentItems
		Left Join dbo.SIM_StudentContentProgress on SIM_StudentContentProgress.ContentID = SIM_ContentItems.ContentID
			and SIM_StudentContentProgress.StudentUserID = @StudentUserId
	Where SIM_ContentItems.LessonID = @LessonId
		and SIM_ContentItems.IsDeleted = 0
	Order By
		SIM_ContentItems.SortOrder,
		SIM_ContentItems.ContentID;
End
