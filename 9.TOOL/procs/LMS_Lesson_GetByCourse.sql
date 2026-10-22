Create Procedure dbo.LMS_Lesson_GetByCourse
(
	@CourseID BigInt,
	@ActorId BigInt,
	@IsAdmin Bit = 0
)
As
Begin
	Set Nocount On;

	-- Check authorization (teacher Or admin)
	If @IsAdmin = 0
	Begin
		-- Must be teacher of the Course Or enrolled student
		If Not Exists
		(
			Select
				1
			From dbo.SIM_Courses
			Where SIM_Courses.CourseID = @CourseID
				and SIM_Courses.TeacherUserID = @ActorId
		)
		And Not Exists
		(
			Select
				1
			From dbo.SIM_Enrollments
			Where SIM_Enrollments.CourseID = @CourseID
				and SIM_Enrollments.StudentUserID = @ActorId
				and SIM_Enrollments.Status <> 'CANCELLED'
		)
			Throw 50003, N'Bạn không có quyền xem danh sách bài học của khóa học này.', 1;
	End

	-- Get lessons
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
	Where SIM_Lessons.CourseID = @CourseID
		and SIM_Lessons.IsDeleted = 0
	Order By
		SIM_Lessons.SortOrder,
		SIM_Lessons.LessonID;
End
