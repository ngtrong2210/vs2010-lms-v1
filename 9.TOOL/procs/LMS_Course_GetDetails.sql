Create Procedure dbo.LMS_Course_GetDetails
(
	@CourseId BigInt,
	@StudentUserId BigInt = Null,
	@IsAdmin Bit = 0
)
As
Begin
	Set Nocount On;

	Select
		SIM_Courses.CourseID,
		SIM_Courses.Title,
		SIM_Courses.Description,
		SIM_Courses.ThumbnailUrl,
		SIM_Courses.CourseType,
		SIM_Courses.Level,
		SIM_Courses.Language,
		SIM_Courses.Price,
		SIM_Courses.DurationMinutes,
		SIM_Courses.Requirements,
		SIM_Courses.WhatYouWillLearn,
		SIM_Courses.TeacherUserID,
		SIM_Users.FullName as TeacherName,
		SIM_Users.Email as TeacherEmail,
		SIM_Users.PhoneNumber as TeacherPhone,
		SIM_Courses.Status,
		SIM_Courses.IsPublished,
		SIM_Courses.CreatedAt,
		SIM_Courses.UpdatedAt,
		SIM_Courses.IsDeleted,
		-- Progress Info If student is provided
		SIM_StudentCourseProgress.ProgressPercent,
		SIM_StudentCourseProgress.Status as EnrollmentStatus,
		SIM_StudentCourseProgress.CompletedAt,
		SIM_Enrollments.EnrolledAt,
		SIM_Enrollments.EnrollmentID
	From dbo.SIM_Courses
		Inner Join dbo.SIM_Users on SIM_Users.UserID = SIM_Courses.TeacherUserID
		Left Join dbo.SIM_Enrollments on SIM_Enrollments.CourseID = SIM_Courses.CourseID
			and SIM_Enrollments.StudentUserID = @StudentUserId
			and SIM_Enrollments.IsDeleted = 0
		Left Join dbo.SIM_StudentCourseProgress on SIM_StudentCourseProgress.StudentUserID = @StudentUserId
			and SIM_StudentCourseProgress.CourseID = SIM_Courses.CourseID
	Where SIM_Courses.CourseID = @CourseId
		and SIM_Courses.IsDeleted = 0
		and (
			@IsAdmin = 1
			or SIM_Courses.IsPublished = 1
			or @StudentUserId is not null
		);

	-- Return lessons for the Course
	Select
		SIM_Lessons.LessonID,
		SIM_Lessons.CourseID,
		SIM_Lessons.Title,
		SIM_Lessons.Description,
		SIM_Lessons.ThumbnailUrl,
		SIM_Lessons.DurationMinutes,
		SIM_Lessons.SortOrder,
		SIM_Lessons.IsPublished,
		SIM_Lessons.IsDeleted,
		SIM_Lessons.CreatedAt,
		SIM_Lessons.UpdatedAt,
		-- Student progress on lesson
		SIM_StudentLessonProgress.ProgressPercent,
		SIM_StudentLessonProgress.Completed,
		SIM_StudentLessonProgress.CompletedAt,
		SIM_StudentLessonProgress.LastAccessAt
	From dbo.SIM_Lessons
		Left Join dbo.SIM_StudentLessonProgress on SIM_StudentLessonProgress.LessonID = SIM_Lessons.LessonID
			and SIM_StudentLessonProgress.StudentUserID = @StudentUserId
	Where SIM_Lessons.CourseID = @CourseId
		and SIM_Lessons.IsDeleted = 0
		and (
			@IsAdmin = 1
			or SIM_Lessons.IsPublished = 1
		)
	Order By
		SIM_Lessons.SortOrder,
		SIM_Lessons.LessonID;

	-- Return lesson statistics
	Select
		SIM_Lessons.LessonID,
		SIM_Lessons.Title,
		Count(SIM_StudentLessonProgress.StudentUserID) as TotalStudentsViewed,
		Sum(Cast(SIM_StudentLessonProgress.Completed as Int)) as TotalStudentsCompleted,
		Avg(SIM_StudentLessonProgress.ActiveStudySeconds) as AvgStudySeconds
	From dbo.SIM_Lessons
		Left Join dbo.SIM_StudentLessonProgress on SIM_StudentLessonProgress.LessonID = SIM_Lessons.LessonID
	Where SIM_Lessons.CourseID = @CourseId
		and SIM_Lessons.IsDeleted = 0
	Group By
		SIM_Lessons.LessonID,
		SIM_Lessons.Title
	Order By
		SIM_Lessons.SortOrder,
		SIM_Lessons.LessonID;
End
