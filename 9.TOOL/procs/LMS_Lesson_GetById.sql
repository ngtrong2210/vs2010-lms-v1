Create Procedure dbo.LMS_Lesson_GetById
(
	@LessonID BigInt
)
As
Begin
	Set Nocount On;

	Select
		SIM_Lessons.LessonID,
		SIM_Lessons.CourseID,
		SIM_Lessons.ChapterID,
		SIM_Lessons.Title,
		SIM_Lessons.Description,
		SIM_Lessons.LessonType,
		SIM_Lessons.SortOrder,
		SIM_Lessons.DurationMinutes,
		SIM_Lessons.VideoID,
		SIM_Videos.VideoAssetID,
		SIM_VideoAssets.Title as VideoTitle,
		SIM_VideoAssets.VideoUrl,
		SIM_VideoAssets.PosterUrl,
		SIM_VideoAssets.DurationSeconds as VideoDurationSeconds,
		(
			Select Count(*)
			From dbo.SIM_ContentItems
			Where SIM_ContentItems.LessonID = SIM_Lessons.LessonID
				and SIM_ContentItems.IsDeleted = 0
		) as ContentCount,
		(
			Select Count(*)
			From dbo.SIM_Quizzes
			Where SIM_Quizzes.LessonID = SIM_Lessons.LessonID
				and SIM_Quizzes.IsDeleted = 0
		) as QuizCount
	From dbo.SIM_Lessons
		Left Join dbo.SIM_Videos on SIM_Videos.VideoID = SIM_Lessons.VideoID
		Left Join dbo.SIM_VideoAssets on SIM_VideoAssets.VideoAssetID = SIM_Videos.VideoAssetID
	Where SIM_Lessons.LessonID = @LessonID
		and SIM_Lessons.IsDeleted = 0;
End
