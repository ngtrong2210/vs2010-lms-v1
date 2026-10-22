Create Procedure dbo.LMS_Enrollment_GetByStudent
(
	@StudentUserId BigInt,
	@ActorId BigInt,
	@IsAdmin Bit = 0,
	@Status Varchar(50) = Null
)
As
Begin
	Set Nocount On;

	-- Check authorization (can Only View own enrollments unless admin)
	If @IsAdmin = 0 And @ActorId <> @StudentUserId
		Throw 50003, N'Bạn không có quyền xem danh sách khóa học của học viên này.', 1;

	-- Get enrollments
	Select
		SIM_Enrollments.EnrollmentID,
		SIM_Enrollments.CourseID,
		SIM_Courses.Title as CourseTitle,
		SIM_Courses.Description as CourseDescription,
		SIM_Courses.ThumbnailUrl,
		SIM_Courses.TotalDurationMinutes,
		SIM_Courses.Status as CourseStatus,
		SIM_Users.FullName as TeacherName,
		SIM_Users.Email as TeacherEmail,
		SIM_Enrollments.EnrolledAt,
		SIM_Enrollments.Status as EnrollmentStatus,
		SIM_StudentCourseProgress.ProgressPercent,
		SIM_StudentCourseProgress.Status as ProgressStatus,
		SIM_StudentCourseProgress.StartedAt,
		SIM_StudentCourseProgress.CompletedAt,
		SIM_StudentCourseProgress.LastAccessAt,
		SIM_StudentCourseProgress.ActiveStudySeconds
	From dbo.SIM_Enrollments
		Inner Join dbo.SIM_Courses on SIM_Courses.CourseID = SIM_Enrollments.CourseID
		Inner Join dbo.SIM_Users on SIM_Users.UserID = SIM_Courses.TeacherUserID
		Left Join dbo.SIM_StudentCourseProgress on SIM_StudentCourseProgress.CourseID = SIM_Enrollments.CourseID
			and SIM_StudentCourseProgress.StudentUserID = SIM_Enrollments.StudentUserID
	Where SIM_Enrollments.StudentUserID = @StudentUserId
		and (@Status is null or SIM_Enrollments.Status = @Status)
		and SIM_Courses.IsDeleted = 0
	Order By
		SIM_Enrollments.EnrolledAt Desc,
		SIM_Courses.Title;
End
