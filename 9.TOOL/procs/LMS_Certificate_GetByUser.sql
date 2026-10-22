Create Procedure dbo.LMS_Certificate_GetByUser
    @UserId BigInt,
    @IsAdmin Bit = 0
As
Begin
    Set NoCount On;

    Select
        sc.CertificateID,
        sc.StudentUserID,
        sc.CourseID,
        sc.IssuedAt,
        sc.ExpiresAt,
        sc.CertificateNumber,
        sc.CertificateUrl,
        sc.Status,
        c.Title As CourseTitle,
        c.Description As CourseDescription,
        u.FullName As StudentName,
        u.Email As StudentEmail,
        t.FullName As TeacherName
    From dbo.SIM_Certificates sc
        Inner Join dbo.SIM_Courses c On c.CourseID = sc.CourseID
        Inner Join dbo.SIM_Users u On u.UserID = sc.StudentUserID
        Inner Join dbo.SIM_Users t On t.UserID = c.TeacherUserID
    Where (sc.StudentUserID = @UserId)
        And (sc.IsDeleted = 0)
    Order By
        sc.IssuedAt Desc;
End
