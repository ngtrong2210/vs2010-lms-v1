Create Procedure dbo.LMS_Enrollment_GetByCourse
(
	@CourseID BigInt,
	@ActorId BigInt,
	@IsAdmin Bit = 0,
	@Status Varchar(50) = Null,
	@PageNumber Int = 1,
	@PageSize Int = 20
)
As
Begin
	Set Nocount On;

	-- Check authorization
	If @IsAdmin = 0
	Begin
		If Not Exists
		(
			Select
				1
			From dbo.SIM_Courses
			Where SIM_Courses.CourseID = @CourseID
				and SIM_Courses.TeacherUserID = @ActorId
		)
			Throw 50003, N'Bạn không có quyền xem danh sách học viên của khóa học này.', 1;
	End

	Declare @Offset Int = (@PageNumber - 1) * @PageSize;

	-- Get enrollments
	Select
		SIM_Enrollments.EnrollmentID,
		SIM_Enrollments.CourseID,
		SIM_Enrollments.StudentUserID,
		SIM_Users.FullName as StudentName,
		SIM_Users.Email as StudentEmail,
		SIM_Users.Phone as StudentPhone,
		SIM_Enrollments.EnrolledAt,
		SIM_Enrollments.Status,
		SIM_StudentCourseProgress.ProgressPercent,
		SIM_StudentCourseProgress.Status as ProgressStatus,
		SIM_StudentCourseProgress.StartedAt,
		SIM_StudentCourseProgress.CompletedAt,
		SIM_StudentCourseProgress.LastAccessAt,
		SIM_StudentCourseProgress.ActiveStudySeconds
	From dbo.SIM_Enrollments
		Inner Join dbo.SIM_Users on SIM_Users.UserID = SIM_Enrollments.StudentUserID
		Left Join dbo.SIM_StudentCourseProgress on SIM_StudentCourseProgress.CourseID = SIM_Enrollments.CourseID
			and SIM_StudentCourseProgress.StudentUserID = SIM_Enrollments.StudentUserID
	Where SIM_Enrollments.CourseID = @CourseID
		and (@Status is null or SIM_Enrollments.Status = @Status)
	Order By
		SIM_Enrollments.EnrolledAt Desc
	Offset @Offset Rows
	Fetch Next @PageSize Rows Only;

	-- Return total Count
	Select
		Count(*) as TotalCount
	From dbo.SIM_Enrollments
	Where SIM_Enrollments.CourseID = @CourseID
		and (@Status is null or SIM_Enrollments.Status = @Status);

	-- Return statistics
	Select
		Count(*) as TotalEnrolled,
		Sum(Case When SIM_Enrollments.Status = 'ACTIVE' Then 1 Else 0 End) as ActiveEnrollments,
		Sum(Case When SIM_Enrollments.Status = 'COMPLETED' Then 1 Else 0 End) as CompletedEnrollments,
		Sum(Case When SIM_Enrollments.Status = 'CANCELLED' Then 1 Else 0 End) as CancelledEnrollments,
		Avg(SIM_StudentCourseProgress.ProgressPercent) as AverageProgress
	From dbo.SIM_Enrollments
		Left Join dbo.SIM_StudentCourseProgress on SIM_StudentCourseProgress.CourseID = SIM_Enrollments.CourseID
			and SIM_StudentCourseProgress.StudentUserID = SIM_Enrollments.StudentUserID
	Where SIM_Enrollments.CourseID = @CourseID;
End
