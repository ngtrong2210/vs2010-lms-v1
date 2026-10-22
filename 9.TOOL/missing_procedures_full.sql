GO
-- =============================================
-- Procedure: LMS_Certificate_Generate
-- =============================================
 
Text                                                                                                                                                                                                                                                           
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE dbo.LMS_Certificate_Generate
    @StudentUserId Bigint,
    @CourseId Bigint,
    @GeneratedByUserId Bigint,
    @UpdatedUser NVARCHAR(100) = NULL
As
Begin
    Set Nocount On;
    Set Xact_abort On;

    If Exists
        (
            Se
lect
                1
            From dbo.SIM_Certificates
            Where (StudentUserID = @StudentUserId)
                And (CourseID = @CourseId)
                And (IsDeleted = 0)
        )
        Throw 50002, N'Chứng chỉ đã tồn tại 
cho khóa học này.', 1;

    Declare @CourseProgress Decimal(5, 2);
    Declare @CourseStatus Nvarchar(50);

    Select
        @CourseProgress = ProgressPercent,
        @CourseStatus = Status
    From dbo.SIM_StudentCourseProgress
    Where (StudentU
serID = @StudentUserId)
        And (CourseID = @CourseId);

    If @CourseProgress Is Null Or @CourseProgress < 100
        Throw 50003, N'Học viên chưa hoàn thành khóa học.', 1;

    If @CourseStatus <> 'COMPLETED'
        Throw 50004, N'Tiến
 độ khóa học chưa ở trạng thái hoàn thành.', 1;

    Declare @CertificateNumber Nvarchar(50) = 'CERT-' + Format(Sysutcdatetime(), 'yyyyMMdd') + '-' + Convert(Nvarchar(10), @StudentUserId) + '-' + Convert(Nvarchar(10), @CourseId);

    Begin 
Transaction;

    Insert dbo.SIM_Certificates
    (
        StudentUserID,
        CourseID,
        IssuedAt,
        ExpiresAt,
        CertificateNumber,
        Status,
        CreatedByUserID,
        CreatedUser,
        UpdatedUser
    )
    Values

    (
        @StudentUserId,
        @CourseId,
        Sysutcdatetime(),
        Dateadd(Year, 1, Sysutcdatetime()),
        @CertificateNumber,
        'ACTIVE',
        @GeneratedByUserId,
        @UpdatedUser,
        @UpdatedUser
    );

    Declar
e @CertificateId Bigint = Scope_identity();

    Commit Transaction;

    Insert dbo.AuditLogs
    (
        UserId,
        Action,
        Module,
        EntityName,
        EntityId
    )
    Values
    (
        @GeneratedByUserId,
        'GENERATE'
,
        'CERTIFICATE',
        'Certificate',
        Convert(Nvarchar(100), @CertificateId)
    );

    Select
        @CertificateId CertificateID,
        @CertificateNumber CertificateNumber;
End
                                                     
 
GO
-- =============================================
-- Procedure: LMS_Certificate_GetByUser
-- =============================================
 
Text                                                                                                                                                                                                                                                           
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE dbo.LMS_Certificate_GetByUser
    @UserId Bigint,
    @IsAdmin Bit = 0
As
Begin
    Set Nocount On;

    Select
        sc.CertificateID,
        sc.StudentUserID,
        sc.CourseID,
        sc.IssuedAt,
        sc.ExpiresAt,
        sc
.CertificateNumber,
        sc.CertificateUrl,
        sc.Status,
        c.Title As CourseTitle,
        c.Description As CourseDescription,
        u.FullName As StudentName,
        u.Email As StudentEmail,
        t.FullName As TeacherName
    From db
o.SIM_Certificates sc
        Inner Join dbo.SIM_Courses c On c.CourseID = sc.CourseID
        Inner Join dbo.SIM_Users u On u.UserID = sc.StudentUserID
        Inner Join dbo.SIM_Users t On t.UserID = c.TeacherUserID
    Where (sc.StudentUserID = @UserId
)
        And (sc.IsDeleted = 0)
    Order By
        sc.IssuedAt Desc;
End
                                                                                                                                                                                   
 
GO
-- =============================================
-- Procedure: LMS_Content_GetByLesson
-- =============================================
 
Text                                                                                                                                                                                                                                                           
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE dbo.LMS_Content_GetByLesson
    @LessonId Bigint,
    @StudentUserId Bigint,
    @IsAdmin Bit = 0
As
Begin
    Set Nocount On;

    Select
        ci.ContentID,
        ci.LessonID,
        ci.Title,
        ci.Description,
        ci.Con
tentType,
        ci.ContentText,
        ci.FileUrl,
        ci.VideoUrl,
        ci.DurationMinutes,
        ci.SortOrder,
        ci.IsPublished,
        ci.IsDeleted,
        ci.CreatedAt,
        ci.UpdatedAt,
        p.Completed,
        p.WatchedSe
conds,
        p.LastAccessAt
    From dbo.SIM_ContentItems ci
        Left Join dbo.SIM_StudentContentProgress p On p.ContentID = ci.ContentID And p.StudentUserID = @StudentUserId
    Where (ci.LessonID = @LessonId)
        And (ci.IsDeleted = 0)
    Ord
er By
        ci.SortOrder,
        ci.ContentID;
End
                                                                                                                                                                                                         
 
GO
-- =============================================
-- Procedure: LMS_Content_TrackProgress
-- =============================================
 
Text                                                                                                                                                                                                                                                           
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE dbo.LMS_Content_TrackProgress
    @ContentId Bigint,
    @StudentUserId Bigint,
    @WatchedSeconds Int = 0,
    @IsCompleted Bit = 0,
    @UpdatedUser NVARCHAR(100) = NULL
As
Begin
    Set Nocount On;
    Set Xact_abort On;

    If Not E
xists
    (
        Select
            1
        From dbo.SIM_ContentItems
        Where (ContentID = @ContentId)
            And (IsDeleted = 0)
    )
        Throw 50002, N'Nội dung không tồn tại.', 1;

    Declare @LessonId Bigint;
    Declare @
CourseId Bigint;
    Select @LessonId = LessonID From dbo.SIM_ContentItems Where ContentID = @ContentId;
    Select @CourseId = CourseId From dbo.SIM_Lessons Where LessonID = @LessonId;

    If Not Exists
    (
        Select
            1
        From db
o.SIM_Enrollments e
        Where (e.CourseID = @CourseId)
            And (e.StudentUserID = @StudentUserId)
            And (e.Status <> 'CANCELLED')
    )
        Throw 50003, N'Bạn không có quyền truy cập nội dung này.', 1;

    Begin Trans
action;

    Merge dbo.SIM_StudentContentProgress As Target
    Using (Select @StudentUserId StudentUserID, @ContentId ContentID) As Source
        On Target.StudentUserID = Source.StudentUserID And Target.ContentID = Source.ContentID
    When Matched The
n
        Update Set 
            WatchedSeconds = Target.WatchedSeconds + @WatchedSeconds,
            Completed = Iif(@IsCompleted = 1, 1, Target.Completed),
            CompletedAt = Iif(@IsCompleted = 1 And Target.Completed = 0, Sysutcdatetime(), Targ
et.CompletedAt),
            LastAccessAt = Sysutcdatetime(),
            UpdatedAt = Sysutcdatetime(),
            UpdatedUser = @UpdatedUser
    When Not Matched Then
        Insert (StudentUserID, ContentID, LessonID, CourseID, Completed, WatchedSecond
s, LastAccessAt, CreatedUser, UpdatedUser)
        Values (Source.StudentUserID, Source.ContentID, @LessonId, @CourseId, @IsCompleted, @WatchedSeconds, Sysutcdatetime(), @UpdatedUser, @UpdatedUser);

    Commit Transaction;

    Insert dbo.AuditLogs
    (

        UserId,
        Action,
        Module,
        EntityName,
        EntityId
    )
    Values
    (
        @StudentUserId,
        'TRACK',
        'CONTENT',
        'ContentProgress',
        Concat(Convert(Nvarchar(100), @ContentId), '-', Con
vert(Nvarchar(100), @StudentUserId))
    );

    Select
        1;
End
                                                                                                                                                                                        
 
GO
-- =============================================
-- Procedure: LMS_Course_GetDetails
-- =============================================
 
Text                                                                                                                                                                                                                                                           
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE dbo.LMS_Course_GetDetails
    @CourseId Bigint,
    @StudentUserId Bigint = Null,
    @IsAdmin Bit = 0
As
Begin
    Set Nocount On;

    Select
        c.CourseID,
        c.Title,
        c.Description,
        c.ThumbnailUrl,
        c.
CourseType,
        c.Level,
        c.Language,
        c.Price,
        c.DurationMinutes,
        c.Requirements,
        c.WhatYouWillLearn,
        c.TeacherUserID,
        t.FullName As TeacherName,
        t.Email As TeacherEmail,
        t.PhoneNu
mber As TeacherPhone,
        c.Status,
        c.IsPublished,
        c.CreatedAt,
        c.UpdatedAt,
        c.IsDeleted,
        -- Progress info if student is provided
        p.ProgressPercent,
        p.Status As EnrollmentStatus,
        p.Comple
tedAt,
        e.EnrolledAt,
        e.EnrollmentID
    From dbo.SIM_Courses c
        Inner Join dbo.SIM_Users t On t.UserID = c.TeacherUserID
        Left Join dbo.SIM_Enrollments e On e.CourseID = c.CourseID And e.StudentUserID = @StudentUserId And e.I
sDeleted = 0
        Left Join dbo.SIM_StudentCourseProgress p On p.StudentUserID = @StudentUserId And p.CourseID = c.CourseID
    Where (c.CourseID = @CourseId)
        And (c.IsDeleted = 0)
        And
        (
            @IsAdmin = 1
            Or c
.IsPublished = 1
            Or @StudentUserId Is Not Null
        );

    -- Return lessons for the course
    Select
        l.LessonID,
        l.CourseId,
        l.Title,
        l.Description,
        l.ThumbnailUrl,
        l.DurationMinutes,
     
   l.SortOrder,
        l.IsPublished,
        l.IsDeleted,
        l.CreatedAt,
        l.UpdatedAt,
        -- Student progress on lesson
        lp.ProgressPercent,
        lp.Completed,
        lp.CompletedAt,
        lp.LastAccessAt
    From dbo.SIM_
Lessons l
        Left Join dbo.SIM_StudentLessonProgress lp On lp.LessonID = l.LessonID And lp.StudentUserID = @StudentUserId
    Where (l.CourseId = @CourseId)
        And (l.IsDeleted = 0)
        And
        (
            @IsAdmin = 1
            Or l
.IsPublished = 1
        )
    Order By
        l.SortOrder,
        l.LessonID;

    -- Return lesson statistics
    Select
        l.LessonID,
        l.Title,
        Count(lp.StudentUserID) As TotalStudentsViewed,
        Sum(Cast(lp.Completed As Int)
) As TotalStudentsCompleted,
        Avg(lp.ActiveStudySeconds) As AvgStudySeconds
    From dbo.SIM_Lessons l
        Left Join dbo.SIM_StudentLessonProgress lp On lp.LessonID = l.LessonID
    Where (l.CourseId = @CourseId)
        And (l.IsDeleted = 0)
 
   Group By
        l.LessonID,
        l.Title
    Order By
        l.SortOrder,
        l.LessonID;
End
                                                                                                                                                     
 
GO
-- =============================================
-- Procedure: LMS_Discussion_Create
-- =============================================
 
Text                                                                                                                                                                                                                                                           
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE   PROCEDURE dbo.LMS_Discussion_Create
    @CourseId Bigint,
    @LessonId Bigint = Null,
    @UserId Bigint,
    @Title NVARCHAR(500),
    @Content NVARCHAR(MAX),
    @ParentId Bigint = Null,
    @UpdatedUser NVARCHAR(100) = NULL
As
Begin
    Set N
ocount On;
    Set Xact_abort On;

    If Not Exists
    (
        Select
            1
        From dbo.SIM_Courses
        Where (CourseID = @CourseId)
            And (IsDeleted = 0)
    )
        Throw 50002, N'Khóa học không tồn tại.', 1;

  
  If @LessonId Is Not Null And Not Exists
    (
        Select
            1
        From dbo.SIM_Lessons
        Where (LessonID = @LessonId)
            And (CourseId = @CourseId)
            And (IsDeleted = 0)
    )
        Throw 50003, N'Bài học k
hông tồn tại hoặc không thuộc khóa học này.', 1;

    If @ParentId Is Not Null And Not Exists
    (
        Select
            1
        From dbo.SIM_Discussions
        Where (DiscussionID = @ParentId)
            And (IsDeleted = 0)
    )

        Throw 50004, N'Chủ đề cha không tồn tại.', 1;

    Begin Transaction;

    Declare @DiscussionId Bigint;
    Select @DiscussionId = NextId From dbo.Sequence Where Name = 'Discussion';
    Update dbo.Sequence Set NextId = NextId + 1 Where
 Name = 'Discussion';

    Insert dbo.SIM_Discussions
    (
        DiscussionID,
        CourseID,
        LessonID,
        UserID,
        Title,
        Content,
        ParentID,
        ReplyCount,
        ViewCount,
        CreatedUser,
        Upd
atedUser
    )
    Values
    (
        @DiscussionId,
        @CourseId,
        @LessonId,
        @UserId,
        @Title,
        @Content,
        @ParentId,
        0,
        0,
        @UpdatedUser,
        @UpdatedUser
    );

    If @ParentId Is
 Not Null
    Begin
        Update dbo.SIM_Discussions
        Set ReplyCount = ReplyCount + 1,
            UpdatedAt = Sysutcdatetime(),
            UpdatedUser = @UpdatedUser
        Where DiscussionID = @ParentId;
    End

    Insert dbo.AuditLogs
    
(
        UserId,
        Action,
        Module,
        EntityName,
        EntityId
    )
    Values
    (
        @UserId,
        'CREATE',
        'DISCUSSION',
        'Discussion',
        Convert(Nvarchar(100), @DiscussionId)
    );

    Commit T
ransaction;

    Select
        @DiscussionId DiscussionID;
End
                                                                                                                                                                                               
 
GO
-- =============================================
-- Procedure: LMS_Discussion_GetByCourse
-- =============================================
 
Text                                                                                                                                                                                                                                                           
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE   PROCEDURE dbo.LMS_Discussion_GetByCourse
    @CourseId Bigint,
    @LessonId Bigint = Null,
    @PageNumber Int = 1,
    @PageSize Int = 20
As
Begin
    Set Nocount On;

    Declare @Offset Int = (@PageNumber - 1) * @PageSize;

    Select
       
 d.DiscussionID,
        d.CourseID,
        d.LessonID,
        d.UserID,
        u.FullName As UserName,
        u.Email As UserEmail,
        d.Title,
        d.Content,
        d.ParentID,
        d.ReplyCount,
        d.ViewCount,
        d.CreatedAt
,
        d.UpdatedAt,
        d.IsDeleted,
        -- Parent info
        p.Title As ParentTitle,
        p.UserID As ParentUserID,
        -- Lesson info
        l.Title As LessonTitle
    From dbo.SIM_Discussions d
        Inner Join dbo.SIM_Users u On
 u.UserID = d.UserID
        Left Join dbo.SIM_Discussions p On p.DiscussionID = d.ParentID
        Left Join dbo.SIM_Lessons l On l.LessonID = d.LessonID
    Where (d.CourseID = @CourseId)
        And (d.IsDeleted = 0)
        And (@LessonId Is Null Or d
.LessonID = @LessonId)
    Order By
        d.CreatedAt Desc
    Offset @Offset Rows
    Fetch Next @PageSize Rows Only;

    -- Return total count
    Select
        Count(*) TotalCount
    From dbo.SIM_Discussions
    Where (CourseID = @CourseId)
      
  And (IsDeleted = 0)
        And (@LessonId Is Null Or LessonID = @LessonId);
End
                                                                                                                                                                            
 
GO
-- =============================================
-- Procedure: LMS_Discussion_GetDetails
-- =============================================
 
Text                                                                                                                                                                                                                                                           
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE   PROCEDURE dbo.LMS_Discussion_GetDetails
    @DiscussionId Bigint
As
Begin
    Set Nocount On;

    -- Main discussion
    Select
        d.DiscussionID,
        d.CourseID,
        d.LessonID,
        d.UserID,
        u.FullName As UserName,
   
     u.Email As UserEmail,
        d.Title,
        d.Content,
        d.ParentID,
        d.ReplyCount,
        d.ViewCount,
        d.CreatedAt,
        d.UpdatedAt,
        d.IsDeleted,
        -- Course info
        c.Title As CourseTitle,
        -- 
Lesson info
        l.Title As LessonTitle,
        -- Parent info
        p.Title As ParentTitle,
        p.UserID As ParentUserID,
        pu.FullName As ParentUserName
    From dbo.SIM_Discussions d
        Inner Join dbo.SIM_Users u On u.UserID = d.Us
erID
        Inner Join dbo.SIM_Courses c On c.CourseID = d.CourseID
        Left Join dbo.SIM_Lessons l On l.LessonID = d.LessonID
        Left Join dbo.SIM_Discussions p On p.DiscussionID = d.ParentID
        Left Join dbo.SIM_Users pu On pu.UserID = p.
UserID
    Where (d.DiscussionID = @DiscussionId)
        And (d.IsDeleted = 0);

    -- Replies (if parent discussion)
    Select
        d.DiscussionID,
        d.UserID,
        u.FullName As UserName,
        u.Email As UserEmail,
        d.Content,
 
       d.CreatedAt,
        d.UpdatedAt
    From dbo.SIM_Discussions d
        Inner Join dbo.SIM_Users u On u.UserID = d.UserID
    Where (d.ParentID = @DiscussionId)
        And (d.IsDeleted = 0)
    Order By
        d.CreatedAt Asc;
End
               
 
GO
-- =============================================
-- Procedure: LMS_Discussion_Update
-- =============================================
 
Text                                                                                                                                                                                                                                                           
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE   PROCEDURE dbo.LMS_Discussion_Update
    @DiscussionId Bigint,
    @UserId Bigint,
    @Title NVARCHAR(500) = Null,
    @Content NVARCHAR(MAX) = Null,
    @UpdatedUser NVARCHAR(100) = NULL
As
Begin
    Set Nocount On;
    Set Xact_abort On;

    I
f Not Exists
    (
        Select
            1
        From dbo.SIM_Discussions
        Where (DiscussionID = @DiscussionId)
            And (IsDeleted = 0)
    )
        Throw 50002, N'Chủ đề thảo luận không tồn tại.', 1;

    If Not Exist
s
    (
        Select
            1
        From dbo.SIM_Discussions
        Where (DiscussionID = @DiscussionId)
            And (UserID = @UserId)
            And (IsDeleted = 0)
    )
        Throw 50003, N'Bạn không có quyền chỉnh sửa chủ
 đề này.', 1;

    Begin Transaction;

    Update dbo.SIM_Discussions
    Set Title = Coalesce(@Title, Title),
        Content = Coalesce(@Content, Content),
        UpdatedAt = Sysutcdatetime(),
        UpdatedUser = @UpdatedUser
    Where Discussion
ID = @DiscussionId;

    Insert dbo.AuditLogs
    (
        UserId,
        Action,
        Module,
        EntityName,
        EntityId
    )
    Values
    (
        @UserId,
        'UPDATE',
        'DISCUSSION',
        'Discussion',
        Convert(
Nvarchar(100), @DiscussionId)
    );

    Commit Transaction;

    Select
        1;
End
                                                                                                                                                                      
 
GO
-- =============================================
-- Procedure: LMS_Enrollment_GetByStudent
-- =============================================
 
Text                                                                                                                                                                                                                                                           
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE dbo.LMS_Enrollment_GetByStudent
    @StudentUserId Bigint,
    @IsAdmin Bit = 0
As
Begin
    Set Nocount On;

    Select
        e.EnrollmentID,
        e.StudentUserID,
        e.CourseID,
        e.EnrolledAt,
        e.Status,
        
e.CompletionPercent,
        e.CourseProgressPercent,
        c.Title As CourseTitle,
        c.Description As CourseDescription,
        c.ThumbnailUrl,
        c.CourseType,
        c.Level,
        c.Language,
        c.Price,
        c.DurationMinutes
,
        c.TeacherUserID,
        t.FullName As TeacherName,
        t.Email As TeacherEmail,
        p.ProgressPercent,
        p.Status As ProgressStatus,
        p.CompletedAt
    From dbo.SIM_Enrollments e
        Inner Join dbo.SIM_Courses c On c.Co
urseID = e.CourseID
        Inner Join dbo.SIM_Users t On t.UserID = c.TeacherUserID
        Left Join dbo.SIM_StudentCourseProgress p On p.StudentUserID = e.StudentUserID And p.CourseID = e.CourseID
    Where (e.StudentUserID = @StudentUserId)
        An
d (e.IsDeleted = 0)
    Order By
        e.EnrolledAt Desc;
End
                                                                                                                                                                                               
 
GO
-- =============================================
-- Procedure: LMS_Lesson_TrackProgress
-- =============================================
 
Text                                                                                                                                                                                                                                                           
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE dbo.LMS_Lesson_TrackProgress
    @LessonId Bigint,
    @StudentUserId Bigint,
    @AccessedSeconds Int = 0,
    @IsCompleted Bit = 0,
    @UpdatedUser NVARCHAR(100) = NULL
As
Begin
    Set Nocount On;
    Set Xact_abort On;

    If Not Ex
ists
    (
        Select
            1
        From dbo.SIM_Lessons
        Where (LessonID = @LessonId)
            And (IsDeleted = 0)
    )
        Throw 50002, N'Bài học không tồn tại.', 1;

    If Not Exists
    (
        Select
            
1
        From dbo.SIM_Enrollments e
            Inner Join dbo.SIM_Courses c On c.CourseID = e.CourseID
            Inner Join dbo.SIM_Lessons l On l.CourseId = c.CourseID
        Where (l.LessonID = @LessonId)
            And (e.StudentUserID = @Student
UserId)
            And (e.Status <> 'CANCELLED')
    )
        Throw 50003, N'Bạn không có quyền truy cập bài học này.', 1;

    Declare @CourseId Bigint;
    Select @CourseId = CourseId From dbo.SIM_Lessons Where LessonID = @LessonId;

    B
egin Transaction;

    Merge dbo.SIM_StudentLessonProgress As Target
    Using (Select @StudentUserId StudentUserID, @CourseId CourseID, @LessonId LessonID) As Source
        On Target.StudentUserID = Source.StudentUserID And Target.LessonID = Source.Less
onID
    When Matched Then
        Update Set 
            ActiveStudySeconds = Target.ActiveStudySeconds + @AccessedSeconds,
            Completed = Iif(@IsCompleted = 1, 1, Target.Completed),
            CompletedAt = Iif(@IsCompleted = 1 And Target.Com
pleted = 0, Sysutcdatetime(), Target.CompletedAt),
            LastAccessAt = Sysutcdatetime(),
            UpdatedAt = Sysutcdatetime(),
            UpdatedUser = @UpdatedUser
    When Not Matched Then
        Insert (StudentUserID, CourseID, LessonID, P
rogressPercent, Score, AttemptCount, Completed, CompletedAt, LastAccessAt, ActiveStudySeconds, CreatedUser, UpdatedUser)
        Values (Source.StudentUserID, Source.CourseID, Source.LessonID, 0, 0, 0, @IsCompleted, Iif(@IsCompleted = 1, Sysutcdatetime(),
 Null), Sysutcdatetime(), @AccessedSeconds, @UpdatedUser, @UpdatedUser);

    Update dbo.SIM_Enrollments
    Set LastAccessAt = Sysutcdatetime(),
        UpdatedUser = @UpdatedUser
    Where (StudentUserID = @StudentUserId)
        And (CourseID = @Course
Id);

    Commit Transaction;

    Insert dbo.AuditLogs
    (
        UserId,
        Action,
        Module,
        EntityName,
        EntityId
    )
    Values
    (
        @StudentUserId,
        'TRACK',
        'LESSON',
        'LessonProgress',

        Concat(Convert(Nvarchar(100), @LessonId), '-', Convert(Nvarchar(100), @StudentUserId))
    );

    Select
        1;
End
                                                                                                                              
 
GO
-- =============================================
-- Procedure: LMS_Notification_GetForUser
-- =============================================
 
Text                                                                                                                                                                                                                                                           
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE   PROCEDURE dbo.LMS_Notification_GetForUser
    @UserId Bigint,
    @PageNumber Int = 1,
    @PageSize Int = 20
As
Begin
    Set Nocount On;

    Declare @Offset Int = (@PageNumber - 1) * @PageSize;

    Select
        n.NotificationID,
        n.U
serID,
        n.Title,
        n.Message,
        n.NotificationType,
        n.EntityType,
        n.EntityID,
        n.IsRead,
        n.CreatedAt,
        n.ReadAt,
        n.IsDeleted
    From dbo.SIM_Notifications n
    Where (n.UserID = @UserId)
 
       And (n.IsDeleted = 0)
    Order By
        n.CreatedAt Desc
    Offset @Offset Rows
    Fetch Next @PageSize Rows Only;

    -- Return total count
    Select
        Count(*) TotalCount
    From dbo.SIM_Notifications
    Where (UserID = @UserId)
  
      And (IsDeleted = 0);

    -- Return unread count
    Select
        Count(*) UnreadCount
    From dbo.SIM_Notifications
    Where (UserID = @UserId)
        And (IsRead = 0)
        And (IsDeleted = 0);
End
                                          
 
GO
-- =============================================
-- Procedure: LMS_Notification_MarkAllAsRead
-- =============================================
 
Text                                                                                                                                                                                                                                                           
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE   PROCEDURE dbo.LMS_Notification_MarkAllAsRead
    @UserId Bigint,
    @UpdatedUser NVARCHAR(100) = NULL
As
Begin
    Set Nocount On;
    Set Xact_abort On;

    Begin Transaction;

    Update dbo.SIM_Notifications
    Set IsRead = 1,
        ReadA
t = Sysutcdatetime(),
        UpdatedAt = Sysutcdatetime(),
        UpdatedUser = @UpdatedUser
    Where (UserID = @UserId)
        And (IsRead = 0)
        And (IsDeleted = 0);

    Insert dbo.AuditLogs
    (
        UserId,
        Action,
        Modul
e,
        EntityName,
        EntityId
    )
    Values
    (
        @UserId,
        'UPDATE',
        'NOTIFICATION',
        'Notification',
        'ALL'
    );

    Commit Transaction;

    Select
        @@ROWCOUNT MarkedCount;
End
               
 
GO
-- =============================================
-- Procedure: LMS_Notification_MarkAsRead
-- =============================================
 
Text                                                                                                                                                                                                                                                           
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE   PROCEDURE dbo.LMS_Notification_MarkAsRead
    @NotificationId Bigint,
    @UserId Bigint,
    @UpdatedUser NVARCHAR(100) = NULL
As
Begin
    Set Nocount On;
    Set Xact_abort On;

    If Not Exists
    (
        Select
            1
        From
 dbo.SIM_Notifications
        Where (NotificationID = @NotificationId)
            And (UserID = @UserId)
            And (IsDeleted = 0)
    )
        Throw 50002, N'Thông báo không tồn tại hoặc bạn không có quyền truy cập.', 1;

    Be
gin Transaction;

    Update dbo.SIM_Notifications
    Set IsRead = 1,
        ReadAt = Sysutcdatetime(),
        UpdatedAt = Sysutcdatetime(),
        UpdatedUser = @UpdatedUser
    Where NotificationID = @NotificationId;

    Insert dbo.AuditLogs
    (

        UserId,
        Action,
        Module,
        EntityName,
        EntityId
    )
    Values
    (
        @UserId,
        'UPDATE',
        'NOTIFICATION',
        'Notification',
        Convert(Nvarchar(100), @NotificationId)
    );

    Comm
it Transaction;

    Select
        1;
End
                                                                                                                                                                                                                    
 
GO
-- =============================================
-- Procedure: LMS_Quiz_Create
-- =============================================
 
Text                                                                                                                                                                                                                                                           
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE dbo.LMS_Quiz_Create
    @Id Bigint = Null,
    @LessonId Bigint,
    @Title Nvarchar(200),
    @Description Nvarchar(Max) = Null,
    @PassingScore Decimal(8, 2),
    @MaxAttempts Int,
    @TimeLimitMinutes Int = Null,
    @ShuffleQuesti
ons Bit = 0,
    @Status Varchar(30),
    @ActorId Bigint,
    @CreatedUser NVARCHAR(100) = NULL
As
Begin
    Set Nocount On;

    If Nullif(Ltrim(Rtrim(@Title)), '') Is Null
        Or @PassingScore < 0
        Or @PassingScore > 100
        Or @MaxAttem
pts < 0
        Throw 50001, N'Dữ liệu bài kiểm tra không hợp lệ.', 1;

    If Not Exists
        (
            Select
                1
            From dbo.SIM_Lessons l
                Inner Join dbo.SIM_Courses c On c.CourseID = l.CourseId

            Where (l.LessonID = @LessonId)
                And (l.IsDeleted = 0)
                And (l.LessonType = 'QUIZ')
                And (c.TeacherUserID = @ActorId)
        )
        Throw 50003, N'Bạn không có quyền tạo bài kiểm tra 
cho bài học này.', 1;

    Insert dbo.LMS_Quizzes
    (
        LessonID,
        Title,
        Description,
        PassingScore,
        MaxAttempts,
        TimeLimitMinutes,
        ShuffleQuestions,
        Status,
        CreatedByUserID,
     
   CreatedAt,
        UpdatedAt
    )
    Values
    (
        @LessonId,
        @Title,
        @Description,
        @PassingScore,
        @MaxAttempts,
        @TimeLimitMinutes,
        @ShuffleQuestions,
        @Status,
        @ActorId,
        S
ysutcdatetime(),
        Sysutcdatetime()
    );

    Declare @QuizId Bigint = Scope_identity();

    Insert dbo.AuditLogs
    (
        UserId,
        Action,
        Module,
        EntityName,
        EntityId
    )
    Values
    (
        @ActorId,

        'CREATE',
        'QUIZ',
        'Quiz',
        Convert(Nvarchar(100), @QuizId)
    );

    Select
        @QuizId;
End
                                                                                                                             
 
GO
-- =============================================
-- Procedure: LMS_Quiz_Delete
-- =============================================
 
Text                                                                                                                                                                                                                                                           
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE dbo.LMS_Quiz_Delete
    @Id Bigint,
    @ActorId Bigint,
    @IsAdmin Bit = 0,
    @UpdatedUser NVARCHAR(100) = NULL
As
Begin
    Set Nocount On;

    Update dbo.SIM_Quizzes
    Set IsDeleted = 1,
        UpdatedAt = Sysutcdatetime(),
   
     UpdatedUser = @UpdatedUser
    Where (QuizID = @Id)
        And (IsDeleted = 0)
        And
        (
            @IsAdmin = 1
            Or CreatedByUserID = @ActorId
            Or Exists
                (
                    Select
              
          1
                    From dbo.SIM_Lessons l
                        Inner Join dbo.SIM_Courses c On c.CourseID = l.CourseId
                    Where (l.LessonID = dbo.SIM_Quizzes.LessonID)
                        And (c.TeacherUserID = @ActorI
d)
                )
        );

    Declare @Rows Int = @@Rowcount;

    If @Rows = 0
        Throw 50003, N'Không tìm thấy bài kiểm tra hoặc bạn không có quyền xóa.', 1;

    If @Rows > 0
    Begin
        Update dbo.SIM_QuizQuestions
  
      Set IsDeleted = 1,
            UpdatedAt = Sysutcdatetime()
        Where (QuizID = @Id)
            And (IsDeleted = 0);

        Insert dbo.AuditLogs
        (
            UserId,
            Action,
            Module,
            EntityName,
   
         EntityId
        )
        Values
        (
            @ActorId,
            'DELETE',
            'QUIZ',
            'Quiz',
            Convert(Nvarchar(100), @Id)
        );
    End

    Select
        @Rows;
End
                            
 
GO
-- =============================================
-- Procedure: LMS_Quiz_GetByLesson
-- =============================================
 
Text                                                                                                                                                                                                                                                           
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE dbo.LMS_Quiz_GetByLesson
    @LessonId Bigint,
    @ActorId Bigint,
    @IsAdmin Bit = 0
As
Begin
    Set Nocount On;

    Select
        q.QuizID,
        q.LessonID,
        q.Title,
        q.Description,
        q.PassingScore,
      
  q.MaxAttempts,
        q.TimeLimitMinutes,
        q.RandomizeQuestions,
        q.ShowResultsImmediately,
        q.Status,
        q.CreatedByUserID,
        q.CreatedAt,
        q.UpdatedAt,
        l.LessonID,
        l.Title As LessonTitle,
       
 l.Description As LessonDescription,
        l.LessonType,
        c.CourseID,
        c.Title As CourseTitle
    From dbo.SIM_Lessons l
        Inner Join dbo.SIM_Courses c On c.CourseID = l.CourseId
        Inner Join dbo.SIM_Quizzes q On q.LessonID = l
.LessonID
    Where (l.LessonID = @LessonId)
        And (l.IsDeleted = 0)
        And (q.IsDeleted = 0)
        And (q.Status = 'ACTIVE')
        And
        (
            @IsAdmin = 1
            Or c.TeacherUserID = @ActorId
            Or q.CreatedByU
serID = @ActorId
        );
End
                                                                                                                                                                                                                               
 
GO
-- =============================================
-- Procedure: LMS_Quiz_GetQuestions
-- =============================================
 
Text                                                                                                                                                                                                                                                           
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE dbo.LMS_Quiz_GetQuestions
    @QuizId Bigint,
    @ActorId Bigint,
    @IsAdmin Bit = 0
As
Begin
    Set Nocount On;

    Select
        qq.QuestionID,
        qq.QuizID,
        qq.QuestionText,
        qq.QuestionType,
        qq.Points
,
        qq.CorrectAnswerText,
        qq.Option1,
        qq.Option2,
        qq.Option3,
        qq.Option4,
        qq.Option5,
        qq.CorrectOption,
        qq.Explanation,
        qq.SortOrder,
        qq.CreatedByUserID,
        qq.CreatedAt,
 
       qq.UpdatedAt
    From dbo.SIM_Quizzes q
        Inner Join dbo.SIM_QuizQuestions qq On qq.QuizID = q.QuizID
    Where (q.QuizID = @QuizId)
        And (q.IsDeleted = 0)
        And (qq.IsDeleted = 0)
        And
        (
            @IsAdmin = 1
 
           Or q.CreatedByUserID = @ActorId
            Or Exists
                (
                    Select
                        1
                    From dbo.SIM_Lessons l
                        Inner Join dbo.SIM_Courses c On c.CourseID = l.Cours
eId
                    Where (l.LessonID = q.LessonID)
                        And (c.TeacherUserID = @ActorId)
                )
        )
    Order By
        qq.SortOrder,
        qq.QuestionID;
End
                                                    
 
GO
-- =============================================
-- Procedure: LMS_Quiz_Update
-- =============================================
 
Text                                                                                                                                                                                                                                                           
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE dbo.LMS_Quiz_Update
    @Id Bigint,
    @Title Nvarchar(200),
    @Description Nvarchar(Max) = Null,
    @PassingScore Decimal(8, 2),
    @MaxAttempts Int,
    @TimeLimitMinutes Int = Null,
    @ShuffleQuestions Bit = 0,
    @Status Varc
har(30),
    @ActorId Bigint,
    @IsAdmin Bit = 0
As
Begin
    Set Nocount On;

    If Nullif(Ltrim(Rtrim(@Title)), '') Is Null
        Or @PassingScore < 0
        Or @PassingScore > 100
        Or @MaxAttempts < 0
        Throw 50001, N'Dữ liệu bà
i kiểm tra không hợp lệ.', 1;

    Update dbo.LMS_Quizzes
    Set
        Title = @Title,
        Description = @Description,
        PassingScore = @PassingScore,
        MaxAttempts = @MaxAttempts,
        TimeLimitMinutes = @TimeLimitMinutes,
  
      ShuffleQuestions = @ShuffleQuestions,
        Status = @Status,
        UpdatedAt = Sysutcdatetime()
    Where (QuizID = @Id)
        And
        (
            @IsAdmin = 1
            Or CreatedByUserID = @ActorId
            Or Exists
            
    (
                    Select
                        1
                    From dbo.SIM_Lessons l
                        Inner Join dbo.SIM_Courses c On c.CourseID = l.CourseId
                    Where (l.LessonID = dbo.LMS_Quizzes.LessonID)
       
                 And (c.TeacherUserID = @ActorId)
                )
        );

    If @@Rowcount = 0
        Throw 50003, N'Không tìm thấy bài kiểm tra hoặc bạn không có quyền sửa.', 1;

    Insert dbo.AuditLogs
    (
        UserId,
   
     Action,
        Module,
        EntityName,
        EntityId
    )
    Values
    (
        @ActorId,
        'UPDATE',
        'QUIZ',
        'Quiz',
        Convert(Nvarchar(100), @Id)
    );

    Select
        @Id;
End
                          
 
GO
-- =============================================
-- Procedure: LMS_QuizAttempt_Create
-- =============================================
 
Text                                                                                                                                                                                                                                                           
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE dbo.LMS_QuizAttempt_Create
    @QuizId Bigint,
    @StudentUserId Bigint,
    @CreatedUser NVARCHAR(100) = NULL
As
Begin
    Set Nocount On;

    If Not Exists
        (
            Select
                1
            From dbo.SIM_Quizze
s q
                Inner Join dbo.SIM_Lessons l On l.LessonID = q.LessonID
                Inner Join dbo.SIM_Courses c On c.CourseID = l.CourseId
                Inner Join dbo.SIM_Enrollments e On e.CourseID = c.CourseID And e.StudentUserID = @StudentU
serId
            Where (q.QuizID = @QuizId)
                And (q.IsDeleted = 0)
                And (q.Status = 'ACTIVE')
                And (e.Status <> 'CANCELLED')
        )
        Throw 50003, N'Bạn không có quyền bắt đầu bài kiểm t
ra này.', 1;

    Declare @MaxAttempts Int;
    Declare @CurrentAttempts Int;

    Select
        @MaxAttempts = MaxAttempts
    From dbo.SIM_Quizzes
    Where (QuizID = @QuizId);

    Select
        @CurrentAttempts = Count(*)
    From dbo.SIM_QuizAttem
pts
    Where (QuizID = @QuizId)
        And (StudentUserID = @StudentUserId);

    If @MaxAttempts > 0 And @CurrentAttempts >= @MaxAttempts
        Throw 50002, N'Bạn đã vượt quá số lần thử tối đa cho bài kiểm tra này.', 1;

    Decl
are @AttemptNumber Int = @CurrentAttempts + 1;

    Insert dbo.SIM_QuizAttempts
    (
        QuizID,
        StudentUserID,
        AttemptNumber,
        AttemptStatus,
        StartedAt,
        CreatedUser,
        UpdatedUser
    )
    Values
    (
 
       @QuizId,
        @StudentUserId,
        @AttemptNumber,
        'IN_PROGRESS',
        Sysutcdatetime(),
        @CreatedUser,
        @CreatedUser
    );

    Declare @QuizAttemptId Bigint = Scope_identity();

    Insert dbo.AuditLogs
    (
     
   UserId,
        Action,
        Module,
        EntityName,
        EntityId
    )
    Values
    (
        @StudentUserId,
        'CREATE',
        'QUIZ',
        'QuizAttempt',
        Convert(Nvarchar(100), @QuizAttemptId)
    );

    Select
     
   @QuizAttemptId;
End
                                                                                                                                                                                                                                        
 
GO
-- =============================================
-- Procedure: LMS_QuizAttempt_GetDetails
-- =============================================
 
Text                                                                                                                                                                                                                                                           
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE dbo.LMS_QuizAttempt_GetDetails
    @QuizAttemptId Bigint,
    @ActorId Bigint,
    @IsAdmin Bit = 0
As
Begin
    Set Nocount On;

    Select
        qa.QuizAttemptID,
        qa.QuizID,
        qa.StudentUserID,
        u.FullName As Stud
entName,
        u.Email As StudentEmail,
        qa.AttemptNumber,
        qa.StartedAt,
        qa.SubmittedAt,
        qa.Score,
        qa.MaxScore,
        qa.ScorePercent,
        qa.Passed,
        qa.AttemptStatus,
        q.Title As QuizTitle,
  
      q.PassingScore,
        q.TimeLimitMinutes,
        l.LessonID,
        l.Title As LessonTitle,
        c.CourseID,
        c.Title As CourseTitle
    From dbo.SIM_QuizAttempts qa
        Inner Join dbo.SIM_Quizzes q On q.QuizID = qa.QuizID
        
Inner Join dbo.SIM_Lessons l On l.LessonID = q.LessonID
        Inner Join dbo.SIM_Courses c On c.CourseID = l.CourseId
        Inner Join dbo.SIM_Users u On u.UserID = qa.StudentUserID
    Where (qa.QuizAttemptID = @QuizAttemptId)
        And
        (
 
           @IsAdmin = 1
            Or qa.StudentUserID = @ActorId
            Or c.TeacherUserID = @ActorId
        );

    Select
        qaa.QuizAttemptAnswerID,
        qaa.QuizAttemptID,
        qaa.QuestionID,
        qq.QuestionText,
        qq.Que
stionType,
        qq.Points,
        qq.Option1,
        qq.Option2,
        qq.Option3,
        qq.Option4,
        qq.Option5,
        qq.CorrectOption,
        qq.CorrectAnswerText,
        qq.Explanation,
        qaa.AnswerText,
        qaa.IsCorrect
,
        qaa.ScoreAwarded
    From dbo.SIM_QuizAttemptAnswers qaa
        Inner Join dbo.SIM_QuizQuestions qq On qq.QuestionID = qaa.QuestionID
    Where (qaa.QuizAttemptID = @QuizAttemptId)
    Order By
        qq.SortOrder,
        qq.QuestionID;
End
 
 
GO
-- =============================================
-- Procedure: LMS_QuizQuestion_Create
-- =============================================
 
Text                                                                                                                                                                                                                                                           
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE dbo.LMS_QuizQuestion_Create
    @Id Bigint = Null,
    @QuizId Bigint,
    @QuestionText Nvarchar(Max),
    @QuestionType Varchar(50),
    @Points Decimal(8, 2) = 1.0,
    @CorrectAnswerText Nvarchar(Max) = Null,
    @Option1 Nvarchar(500
) = Null,
    @Option2 Nvarchar(500) = Null,
    @Option3 Nvarchar(500) = Null,
    @Option4 Nvarchar(500) = Null,
    @Option5 Nvarchar(500) = Null,
    @CorrectOption Int = Null,
    @Explanation Nvarchar(Max) = Null,
    @SortOrder Int = 0,
    @ActorI
d Bigint,
    @CreatedUser NVARCHAR(100) = NULL
As
Begin
    Set Nocount On;

    If Nullif(Ltrim(Rtrim(@QuestionText)), '') Is Null
        Or @Points <= 0
        Throw 50001, N'Dữ liệu câu hỏi không hợp lệ.', 1;

    If @QuestionType = 'MUL
TIPLE_CHOICE' And @CorrectOption Is Null
        Throw 50001, N'Câu hỏi trắc nghiệm phải có đáp án đúng.', 1;

    If Not Exists
        (
            Select
                1
            From dbo.SIM_Quizzes q
                Inner Join db
o.SIM_Lessons l On l.LessonID = q.LessonID
                Inner Join dbo.SIM_Courses c On c.CourseID = l.CourseId
            Where (q.QuizID = @QuizId)
                And (q.IsDeleted = 0)
                And (c.TeacherUserID = @ActorId)
        )
    
    Throw 50003, N'Bạn không có quyền tạo câu hỏi cho bài kiểm tra này.', 1;

    Insert dbo.SIM_QuizQuestions
    (
        QuizID,
        QuestionText,
        QuestionType,
        Points,
        CorrectAnswerText,
        Option1,
   
     Option2,
        Option3,
        Option4,
        Option5,
        CorrectOption,
        Explanation,
        SortOrder,
        CreatedByUserID,
        CreatedUser,
        UpdatedUser
    )
    Values
    (
        @QuizId,
        @QuestionText
,
        @QuestionType,
        @Points,
        @CorrectAnswerText,
        @Option1,
        @Option2,
        @Option3,
        @Option4,
        @Option5,
        @CorrectOption,
        @Explanation,
        @SortOrder,
        @ActorId,
        @Cr
eatedUser,
        @CreatedUser
    );

    Declare @QuestionId Bigint = Scope_identity();

    Insert dbo.AuditLogs
    (
        UserId,
        Action,
        Module,
        EntityName,
        EntityId
    )
    Values
    (
        @ActorId,
      
  'CREATE',
        'QUIZ',
        'QuizQuestion',
        Convert(Nvarchar(100), @QuestionId)
    );

    Select
        @QuestionId;
End
                                                                                                                   
 
GO
-- =============================================
-- Procedure: LMS_QuizQuestion_Delete
-- =============================================
 
Text                                                                                                                                                                                                                                                           
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE dbo.LMS_QuizQuestion_Delete
    @Id Bigint,
    @ActorId Bigint,
    @IsAdmin Bit = 0,
    @UpdatedUser NVARCHAR(100) = NULL
As
Begin
    Set Nocount On;

    Update dbo.SIM_QuizQuestions
    Set IsDeleted = 1,
        UpdatedAt = Sysutcd
atetime(),
        UpdatedUser = @UpdatedUser
    Where (QuestionID = @Id)
        And (IsDeleted = 0)
        And
        (
            @IsAdmin = 1
            Or CreatedByUserID = @ActorId
            Or Exists
                (
                    Sel
ect
                        1
                    From dbo.SIM_Quizzes q
                        Inner Join dbo.SIM_Lessons l On l.LessonID = q.LessonID
                        Inner Join dbo.SIM_Courses c On c.CourseID = l.CourseId
                    Wh
ere (q.QuizID = dbo.SIM_QuizQuestions.QuizID)
                        And (c.TeacherUserID = @ActorId)
                )
        );

    Declare @Rows Int = @@Rowcount;

    If @Rows = 0
        Throw 50003, N'Không tìm thấy câu hỏi hoặc bạn kh
ông có quyền xóa.', 1;

    If @Rows > 0
    Begin
        Insert dbo.AuditLogs
        (
            UserId,
            Action,
            Module,
            EntityName,
            EntityId
        )
        Values
        (
            @ActorId
,
            'DELETE',
            'QUIZ',
            'QuizQuestion',
            Convert(Nvarchar(100), @Id)
        );
    End

    Select
        @Rows;
End
                                                                                             
 
GO
-- =============================================
-- Procedure: LMS_QuizQuestion_Update
-- =============================================
 
Text                                                                                                                                                                                                                                                           
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE dbo.LMS_QuizQuestion_Update
    @Id Bigint,
    @QuestionText Nvarchar(Max),
    @QuestionType Varchar(50),
    @Points Decimal(8, 2) = 1.0,
    @CorrectAnswerText Nvarchar(Max) = Null,
    @Option1 Nvarchar(500) = Null,
    @Option2 Nvar
char(500) = Null,
    @Option3 Nvarchar(500) = Null,
    @Option4 Nvarchar(500) = Null,
    @Option5 Nvarchar(500) = Null,
    @CorrectOption Int = Null,
    @Explanation Nvarchar(Max) = Null,
    @SortOrder Int = 0,
    @ActorId Bigint,
    @IsAdmin Bit 
= 0,
    @UpdatedUser NVARCHAR(100) = NULL
As
Begin
    Set Nocount On;

    If Nullif(Ltrim(Rtrim(@QuestionText)), '') Is Null
        Or @Points <= 0
        Throw 50001, N'Dữ liệu câu hỏi không hợp lệ.', 1;

    If @QuestionType = 'MULTIPLE
_CHOICE' And @CorrectOption Is Null
        Throw 50001, N'Câu hỏi trắc nghiệm phải có đáp án đúng.', 1;

    Update dbo.SIM_QuizQuestions
    Set
        QuestionText = @QuestionText,
        QuestionType = @QuestionType,
        Points = 
@Points,
        CorrectAnswerText = @CorrectAnswerText,
        Option1 = @Option1,
        Option2 = @Option2,
        Option3 = @Option3,
        Option4 = @Option4,
        Option5 = @Option5,
        CorrectOption = @CorrectOption,
        Explanatio
n = @Explanation,
        SortOrder = @SortOrder,
        UpdatedAt = Sysutcdatetime(),
        UpdatedUser = @UpdatedUser
    Where (QuestionID = @Id)
        And (IsDeleted = 0)
        And
        (
            @IsAdmin = 1
            Or CreatedByUser
ID = @ActorId
            Or Exists
                (
                    Select
                        1
                    From dbo.SIM_Quizzes q
                        Inner Join dbo.SIM_Lessons l On l.LessonID = q.LessonID
                        I
nner Join dbo.SIM_Courses c On c.CourseID = l.CourseId
                    Where (q.QuizID = dbo.SIM_QuizQuestions.QuizID)
                        And (c.TeacherUserID = @ActorId)
                )
        );

    If @@Rowcount = 0
        Throw 50003, N'
Không tìm thấy câu hỏi hoặc bạn không có quyền sửa.', 1;

    Insert dbo.AuditLogs
    (
        UserId,
        Action,
        Module,
        EntityName,
        EntityId
    )
    Values
    (
        @ActorId,
        'UPDATE',
     
   'QUIZ',
        'QuizQuestion',
        Convert(Nvarchar(100), @Id)
    );

    Select
        @Id;
End
                                                                                                                                                    
 
GO
-- =============================================
-- Procedure: LMS_Survey_SubmitResponse
-- =============================================
 
Text                                                                                                                                                                                                                                                           
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE   PROCEDURE dbo.LMS_Survey_SubmitResponse
    @SurveyId Bigint,
    @StudentUserId Bigint,
    @ActorId Bigint,
    @UpdatedUser NVARCHAR(100) = NULL
As
Begin
    Set Nocount On;
    Set Xact_abort On;

    If Not Exists
    (
        Select
      
      1
        From dbo.SIM_Surveys
        Where (SurveyID = @SurveyId)
            And (IsDeleted = 0)
    )
        Throw 50002, N'Khảo sát không tồn tại.', 1;

    If Exists
    (
        Select
            1
        From dbo.SIM_SurveyRespon
ses
        Where (SurveyID = @SurveyId)
            And (StudentUserID = @StudentUserId)
            And (IsDeleted = 0)
    )
        Throw 50003, N'Bạn đã tham gia khảo sát này rồi.', 1;

    Declare @CourseId Bigint;
    Select @CourseId = C
ourseID From dbo.SIM_Surveys Where SurveyID = @SurveyId;

    Begin Transaction;

    Declare @ResponseId Bigint;
    Select @ResponseId = NextId From dbo.Sequence Where Name = 'SurveyResponse';
    Update dbo.Sequence Set NextId = NextId + 1 Where Name =
 'SurveyResponse';

    Insert dbo.SIM_SurveyResponses
    (
        ResponseID,
        SurveyID,
        StudentUserID,
        SubmittedAt,
        CreatedUser,
        UpdatedUser
    )
    Values
    (
        @ResponseId,
        @SurveyId,
        
@StudentUserId,
        Sysutcdatetime(),
        @UpdatedUser,
        @UpdatedUser
    );

    Insert dbo.AuditLogs
    (
        UserId,
        Action,
        Module,
        EntityName,
        EntityId
    )
    Values
    (
        @ActorId,
     
   'SUBMIT',
        'SURVEY',
        'SurveyResponse',
        Convert(Nvarchar(100), @ResponseId)
    );

    Commit Transaction;

    Select
        @ResponseId ResponseID;
End
                                                                          
 
GO
-- =============================================
-- Procedure: LMS_SurveyAnswer_Create
-- =============================================
 
Text                                                                                                                                                                                                                                                           
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE   PROCEDURE dbo.LMS_SurveyAnswer_Create
    @ResponseId Bigint,
    @QuestionId Bigint,
    @AnswerText NVARCHAR(MAX) = NULL,
    @SelectedOptionId Bigint = NULL,
    @NumericValue Decimal(10,2) = NULL,
    @ActorId Bigint,
    @UpdatedUser NVARCHA
R(100) = NULL
As
Begin
    Set Nocount On;
    Set Xact_abort On;

    If Not Exists
    (
        Select
            1
        From dbo.SIM_SurveyResponses
        Where (ResponseID = @ResponseId)
            And (IsDeleted = 0)
    )
        Throw 50002
, N'Phản hồi khảo sát không tồn tại.', 1;

    If Not Exists
    (
        Select
            1
        From dbo.SIM_SurveyQuestions
        Where (QuestionID = @QuestionId)
            And (IsDeleted = 0)
    )
        Throw 50003, N'Câu h�
�i không tồn tại.', 1;

    If Exists
    (
        Select
            1
        From dbo.SIM_SurveyAnswers
        Where (ResponseID = @ResponseId)
            And (QuestionID = @QuestionId)
            And (IsDeleted = 0)
    )
        Throw 50004,
 N'Bạn đã trả lời câu hỏi này rồi.', 1;

    Begin Transaction;

    Declare @AnswerId Bigint;
    Select @AnswerId = NextId From dbo.Sequence Where Name = 'SurveyAnswer';
    Update dbo.Sequence Set NextId = NextId + 1 Where Name = 'SurveyA
nswer';

    Insert dbo.SIM_SurveyAnswers
    (
        AnswerID,
        ResponseID,
        QuestionID,
        AnswerText,
        SelectedOptionID,
        NumericValue,
        CreatedUser,
        UpdatedUser
    )
    Values
    (
        @AnswerId
,
        @ResponseId,
        @QuestionId,
        @AnswerText,
        @SelectedOptionId,
        @NumericValue,
        @UpdatedUser,
        @UpdatedUser
    );

    Insert dbo.AuditLogs
    (
        UserId,
        Action,
        Module,
        En
tityName,
        EntityId
    )
    Values
    (
        @ActorId,
        'CREATE',
        'SURVEY',
        'SurveyAnswer',
        Convert(Nvarchar(100), @AnswerId)
    );

    Commit Transaction;

    Select
        @AnswerId AnswerID;
End
         
 
GO
-- =============================================
-- Procedure: LMS_Video_DetachFromLesson
-- =============================================
 
Text                                                                                                                                                                                                                                                           
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE dbo.LMS_Video_DetachFromLesson
    @LessonId Bigint,
    @ActorId Bigint,
    @IsAdmin Bit = 0
As
Begin
    Set Nocount On;

    If Not Exists
        (
            Select
                1
            From dbo.SIM_Lessons
               
 Inner Join dbo.SIM_Courses On dbo.SIM_Courses.CourseID = dbo.SIM_Lessons.CourseID
            Where (dbo.SIM_Lessons.LessonID = @LessonId)
                And (dbo.SIM_Lessons.IsDeleted = 0)
                And (dbo.SIM_Lessons.LessonType In ('VIDEO', 'I
NTERACTIVE_VIDEO'))
                And (@IsAdmin = 1 Or dbo.SIM_Courses.TeacherUserID = @ActorId)
        )
        Throw 50003, N'Bạn không có quyền quản lý bài học này.', 1;

    Declare @OldVideoId Bigint,
        @OldVideoVersionID Bigin
t;

    Select
        @OldVideoId = VideoID,
        @OldVideoVersionID = VideoVersionID
    From dbo.SIM_Lessons
    Where (LessonID = @LessonId);

    If @OldVideoId Is Null
        Throw 50003, N'Bài học này chưa có video đính kèm.', 1;

    
Update dbo.SIM_Lessons
    Set
        VideoID = Null,
        VideoVersionID = Null,
        DurationSeconds = Null,
        UpdatedAt = Sysutcdatetime()
    Where (LessonID = @LessonId);

    Insert dbo.AuditLogs
    (
        UserID,
        Action,
  
      Module,
        EntityName,
        EntityID,
        OldValuesJson
    )
    Values
    (
        @ActorId,
        'DETACH',
        'VIDEO_LIBRARY',
        'Lesson',
        Convert(Nvarchar(100), @LessonId),
        (
            Select
       
         @OldVideoId VideoID,
                @OldVideoVersionID VideoVersionID
            For Json Path, Without_array_wrapper
        )
    );

    Select
        @OldVideoId;
End;
                                                                       
 
GO
-- =============================================
-- Procedure: LMS_Video_GetByLesson
-- =============================================
 
Text                                                                                                                                                                                                                                                           
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE dbo.LMS_Video_GetByLesson
    @LessonId Bigint,
    @ActorId Bigint,
    @IsAdmin Bit = 0
As
Begin
    Set Nocount On;

    Select
        v.VideoID,
        v.Title,
        v.VideoUrl,
        v.PosterUrl,
        v.DurationSeconds,
   
     v.AllowSeek,
        v.AllowSpeed,
        v.RequiredWatchPercent,
        v.Status,
        v.CurrentVideoVersionID,
        vv.VersionNumber,
        vv.VersionStatus,
        vv.VideoUrl As VersionVideoUrl,
        vv.PosterUrl As VersionPosterUrl
,
        vv.DurationSeconds As VersionDurationSeconds,
        vv.FileSize,
        vv.MimeType,
        vv.SourceType,
        va.VideoAssetID,
        va.CreatedByUserID As AssetCreatedByUserID,
        va.ShareScope,
        l.LessonID,
        l.Titl
e As LessonTitle,
        l.Description As LessonDescription,
        l.LessonType,
        c.CourseID,
        c.Title As CourseTitle
    From dbo.SIM_Lessons l
        Inner Join dbo.SIM_Courses c On c.CourseID = l.CourseId
        Inner Join dbo.SIM_Vi
deos v On v.VideoID = l.VideoID
        Inner Join dbo.SIM_VideoAssets va On va.VideoAssetID = v.VideoAssetId
        Inner Join dbo.SIM_VideoVersions vv On vv.VideoVersionID = v.CurrentVideoVersionID
    Where (l.LessonID = @LessonId)
        And (l.IsDe
leted = 0)
        And (v.Status = 'ACTIVE')
        And (va.IsDeleted = 0)
        And (va.Status = 'ACTIVE')
        And (vv.VersionStatus = 'PUBLISHED')
        And
        (
            @IsAdmin = 1
            Or c.TeacherUserID = @ActorId
          
  Or va.CreatedByUserID = @ActorId
            Or va.ShareScope = 'SCHOOL'
            Or Exists
                (
                    Select
                        1
                    From dbo.SIM_VideoAssetShares vas
                    Where (vas.Vi
deoAssetID = va.VideoAssetID)
                        And (vas.TeacherUserID = @ActorId)
                )
        );
End;
                                                                                                                                    
 
GO
-- =============================================
-- Procedure: SIM_Notification_GetList
-- =============================================
 
Text                                                                                                                                                                                                                                                           
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE   PROCEDURE dbo.SIM_Notification_GetList
    @RecipientUserID Bigint,
    @Limit Int = 20,
    @UnreadOnly Bit = 0
As
Begin
    Set Nocount On;

    Set @Limit = Case When @Limit < 1 Then 1 When @Limit > 100 Then 100 Else @Limit End;

    Select To
p (@Limit)
        n.NotificationID Id,
        n.NotificationType,
        n.Title,
        n.Message,
        n.EntityType ReferenceType,
        n.EntityID ReferenceID,
        Null ActionUrl,
        n.IsRead,
        n.ReadAt,
        n.CreatedAt,
  
      u.FullName ActorName,
        u.AvatarUrl ActorAvatarUrl
    From dbo.SIM_Notifications n
    Left Join dbo.SYS_Users u On u.UserID = n.CreatedUser
    Where (n.UserID = @RecipientUserID)
        And (@UnreadOnly = 0 Or n.IsRead = 0)
        And (n.
IsDeleted = 0)
    Order By
        n.IsRead,
        n.CreatedAt Desc,
        n.NotificationID Desc;

    Select
        Count(*)
    From dbo.SIM_Notifications
    Where (UserID = @RecipientUserID)
        And (IsRead = 0)
        And (IsDeleted = 0);

End
                                                                                                                                                                                                                                                           
 
GO
-- =============================================
-- Procedure: SIM_Notification_MarkAllRead
-- =============================================
 
Text                                                                                                                                                                                                                                                           
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE   PROCEDURE dbo.SIM_Notification_MarkAllRead
    @UserId Bigint,
    @UpdatedUser NVARCHAR(100) = NULL
As
Begin
    Set Nocount On;
    Set Xact_abort On;

    Begin Transaction;

    Update dbo.SIM_Notifications
    Set IsRead = 1,
        ReadAt
 = Sysutcdatetime(),
        UpdatedAt = Sysutcdatetime(),
        UpdatedUser = @UpdatedUser
    Where (UserID = @UserId)
        And (IsRead = 0)
        And (IsDeleted = 0);

    Insert dbo.AuditLogs
    (
        UserId,
        Action,
        Module
,
        EntityName,
        EntityId
    )
    Values
    (
        @UserId,
        'UPDATE',
        'NOTIFICATION',
        'Notification',
        'ALL'
    );

    Commit Transaction;

    Select
        @@ROWCOUNT MarkedCount;
End
                
 
GO
-- =============================================
-- Procedure: SIM_Notification_MarkRead
-- =============================================
 
Text                                                                                                                                                                                                                                                           
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE   PROCEDURE dbo.SIM_Notification_MarkRead
    @NotificationId Bigint,
    @UserId Bigint,
    @UpdatedUser NVARCHAR(100) = NULL
As
Begin
    Set Nocount On;
    Set Xact_abort On;

    If Not Exists
    (
        Select
            1
        From 
dbo.SIM_Notifications
        Where (NotificationID = @NotificationId)
            And (UserID = @UserId)
            And (IsDeleted = 0)
    )
        Throw 50002, N'Thông báo không tồn tại hoặc bạn không có quyền truy cập.', 1;

    Beg
in Transaction;

    Update dbo.SIM_Notifications
    Set IsRead = 1,
        ReadAt = Sysutcdatetime(),
        UpdatedAt = Sysutcdatetime(),
        UpdatedUser = @UpdatedUser
    Where NotificationID = @NotificationId;

    Insert dbo.AuditLogs
    (
 
       UserId,
        Action,
        Module,
        EntityName,
        EntityId
    )
    Values
    (
        @UserId,
        'UPDATE',
        'NOTIFICATION',
        'Notification',
        Convert(Nvarchar(100), @NotificationId)
    );

    Commi
t Transaction;

    Select
        1;
End
                                                                                                                                                                                                                     
 
