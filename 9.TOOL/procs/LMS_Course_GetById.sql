Create Procedure dbo.LMS_Course_GetById
(
	@CourseID BigInt
)
As
Begin
	Set Nocount On;

	Select
		SIM_Courses.CourseID,
		SIM_Courses.Title,
		SIM_Courses.Description,
		SIM_Courses.CoverImageID,
		SIM_Courses.CategoryID,
		SIM_Courses.Level,
		SIM_Courses.Language,
		SIM_Courses.Price,
		SIM_Courses.DurationHours,
		SIM_Courses.EnrolledCount,
		SIM_Courses.TeacherUserID,
		SIM_Courses.Status,
		SIM_Courses.PublishedAt,
		SIM_Courses.CreatedAt,
		SIM_Courses.UpdatedAt,
		SIM_Courses.IsDeleted,
		(
			Select Count(*)
			From dbo.SIM_Enrollments
			Where SIM_Enrollments.CourseID = SIM_Courses.CourseID
				and SIM_Enrollments.Status <> 'CANCELLED'
		) as ActiveEnrollments,
		(
			Select Count(*)
			From dbo.SIM_Chapters
			Where SIM_Chapters.CourseID = SIM_Courses.CourseID
				and SIM_Chapters.IsDeleted = 0
		) as ChapterCount,
		(
			Select Count(*)
			From dbo.SIM_Lessons
			Where SIM_Lessons.CourseID = SIM_Courses.CourseID
				and SIM_Lessons.IsDeleted = 0
		) as LessonCount
	From dbo.SIM_Courses
	Where SIM_Courses.CourseID = @CourseID;
End
