Create Procedure dbo.LMS_Course_GetList
(
	@TeacherUserId BigInt = Null,
	@Status Varchar(50) = Null,
	@SearchKeyword Nvarchar(200) = Null,
	@CategoryID BigInt = Null,
	@PageNumber Int = 1,
	@PageSize Int = 20
)
As
Begin
	Set Nocount On;

	Declare @Offset Int = (@PageNumber - 1) * @PageSize;

	-- Get Course list
	Select
		SIM_Courses.CourseID,
		SIM_Courses.Title,
		SIM_Courses.Description,
		SIM_Courses.ThumbnailUrl,
		SIM_Courses.TotalDurationMinutes,
		SIM_Courses.Status,
		SIM_Courses.CreatedAt,
		SIM_Courses.UpdatedAt,
		SIM_Courses.TeacherUserID,
		SIM_Users.FullName as TeacherName,
		SIM_Users.Email as TeacherEmail,
		SIM_Categories.CategoryID,
		SIM_Categories.CategoryName,
		(
			Select Count(*)
			From dbo.SIM_Enrollments
			Where SIM_Enrollments.CourseID = SIM_Courses.CourseID
				and SIM_Enrollments.Status <> 'CANCELLED'
		) as EnrolledCount,
		(
			Select Count(*)
			From dbo.SIM_Lessons
			Where SIM_Lessons.CourseID = SIM_Courses.CourseID
				and SIM_Lessons.IsDeleted = 0
		) as LessonCount
	From dbo.SIM_Courses
		Inner Join dbo.SIM_Users on SIM_Users.UserID = SIM_Courses.TeacherUserID
		Left Join dbo.SIM_Categories on SIM_Categories.CategoryID = SIM_Courses.CategoryID
	Where SIM_Courses.IsDeleted = 0
		and (@TeacherUserId is null or SIM_Courses.TeacherUserID = @TeacherUserId)
		and (@Status is null or SIM_Courses.Status = @Status)
		and (@CategoryID is null or SIM_Courses.CategoryID = @CategoryID)
		and (@SearchKeyword is null or SIM_Courses.Title like '%' + @SearchKeyword + '%' or SIM_Courses.Description like '%' + @SearchKeyword + '%')
	Order By
		SIM_Courses.CreatedAt Desc
	Offset @Offset Rows
	Fetch Next @PageSize Rows Only;

	-- Return total Count
	Select
		Count(*) as TotalCount
	From dbo.SIM_Courses
	Where SIM_Courses.IsDeleted = 0
		and (@TeacherUserId is null or SIM_Courses.TeacherUserID = @TeacherUserId)
		and (@Status is null or SIM_Courses.Status = @Status)
		and (@CategoryID is null or SIM_Courses.CategoryID = @CategoryID)
		and (@SearchKeyword is null or SIM_Courses.Title like '%' + @SearchKeyword + '%' or SIM_Courses.Description like '%' + @SearchKeyword + '%');
End
