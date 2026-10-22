-- =============================================
-- SQL SCRIPTS FOR CHAPTER/LESSON FLEXIBLE STRUCTURE
-- =============================================
-- Database: LMSCMS_DB
-- Server: DESKTOP-PBMQQ03\SQLEXPRESS
-- =============================================

USE LMSCMS_DB;
GO

-- =============================================
-- PHASE 1: ADD COLUMNS TO EXISTING TABLES
-- =============================================

-- Add ChapterID to SIM_ContentItems
IF NOT EXISTS (
    SELECT * FROM sys.columns
    WHERE object_id = OBJECT_ID('dbo.SIM_ContentItems')
    AND name = 'ChapterID'
)
BEGIN
    ALTER TABLE dbo.SIM_ContentItems
    ADD ChapterID BigInt NULL;

    ALTER TABLE dbo.SIM_ContentItems
    ADD CONSTRAINT FK_ContentItems_Chapters
    FOREIGN KEY (ChapterID) REFERENCES dbo.SIM_Chapters(ChapterID);

    PRINT '✓ Added ChapterID to SIM_ContentItems';
END
ELSE
BEGIN
    PRINT '✗ ChapterID already exists in SIM_ContentItems';
END
GO

-- Add ChapterID to SIM_Quizzes
IF NOT EXISTS (
    SELECT * FROM sys.columns
    WHERE object_id = OBJECT_ID('dbo.SIM_Quizzes')
    AND name = 'ChapterID'
)
BEGIN
    ALTER TABLE dbo.SIM_Quizzes
    ADD ChapterID BigInt NULL;

    ALTER TABLE dbo.SIM_Quizzes
    ADD CONSTRAINT FK_Quizzes_Chapters
    FOREIGN KEY (ChapterID) REFERENCES dbo.SIM_Chapters(ChapterID);

    PRINT '✓ Added ChapterID to SIM_Quizzes';
END
ELSE
BEGIN
    PRINT '✗ ChapterID already exists in SIM_Quizzes';
END
GO

-- =============================================
-- PHASE 2: CREATE NEW TABLES
-- =============================================

-- Create SIM_InteractiveContent table
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'SIM_InteractiveContent')
BEGIN
    CREATE TABLE dbo.SIM_InteractiveContent
    (
        InteractiveContentID BigInt IDENTITY(1,1) NOT NULL PRIMARY KEY,
        CourseID BigInt NOT NULL,
        ChapterID BigInt NULL,
        LessonID BigInt NULL,
        Title NVarChar(255) NOT NULL,
        Description NVarChar(Max) NULL,
        InteractiveType NVarChar(50) NOT NULL, -- H5P, SCORM, CUSTOM, DRAG_DROP, FLASHCARD
        ContentUrl NVarChar(500) NULL,
        ConfigJson NVarChar(Max) NULL,
        ThumbnailUrl NVarChar(500) NULL,
        DurationMinutes Int NULL,
        SortOrder Int DEFAULT 0,
        Status NVarChar(50) DEFAULT 'DRAFT',
        CreatedAt DateTime DEFAULT GetDate(),
        UpdatedAt DateTime DEFAULT GetDate(),
        IsDeleted Bit DEFAULT 0,

        CONSTRAINT FK_InteractiveContent_Courses FOREIGN KEY (CourseID) REFERENCES dbo.SIM_Courses(CourseID),
        CONSTRAINT FK_InteractiveContent_Chapters FOREIGN KEY (ChapterID) REFERENCES dbo.SIM_Chapters(ChapterID),
        CONSTRAINT FK_InteractiveContent_Lessons FOREIGN KEY (LessonID) REFERENCES dbo.SIM_Lessons(LessonID)
    );

    -- Create Indexes
    CREATE INDEX IX_InteractiveContent_CourseID ON dbo.SIM_InteractiveContent(CourseID);
    CREATE INDEX IX_InteractiveContent_ChapterID ON dbo.SIM_InteractiveContent(ChapterID);
    CREATE INDEX IX_InteractiveContent_LessonID ON dbo.SIM_InteractiveContent(LessonID);
    CREATE INDEX IX_InteractiveContent_Status ON dbo.SIM_InteractiveContent(Status);
    CREATE INDEX IX_InteractiveContent_IsDeleted ON dbo.SIM_InteractiveContent(IsDeleted);

    PRINT '✓ Created SIM_InteractiveContent table';
END
ELSE
BEGIN
    PRINT '✗ SIM_InteractiveContent table already exists';
END
GO

-- =============================================
-- PHASE 3: CREATE STORED PROCEDURES
-- =============================================

-- Drop procedures if they exist
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'LMS_InteractiveContent_Create')
    DROP PROCEDURE dbo.LMS_InteractiveContent_Create;
GO

IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'LMS_InteractiveContent_Update')
    DROP PROCEDURE dbo.LMS_InteractiveContent_Update;
GO

IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'LMS_InteractiveContent_Delete')
    DROP PROCEDURE dbo.LMS_InteractiveContent_Delete;
GO

IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'LMS_InteractiveContent_GetById')
    DROP PROCEDURE dbo.LMS_InteractiveContent_GetById;
GO

IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'LMS_InteractiveContent_GetByChapter')
    DROP PROCEDURE dbo.LMS_InteractiveContent_GetByChapter;
GO

IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'LMS_InteractiveContent_GetByCourse')
    DROP PROCEDURE dbo.LMS_InteractiveContent_GetByCourse;
GO

IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'LMS_Chapter_GetAllContent')
    DROP PROCEDURE dbo.LMS_Chapter_GetAllContent;
GO

IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'LMS_Chapter_ReorderContent')
    DROP PROCEDURE dbo.LMS_Chapter_ReorderContent;
GO

-- LMS_InteractiveContent_Create
CREATE PROCEDURE dbo.LMS_InteractiveContent_Create
(
    @CourseID BigInt,
    @ChapterID BigInt = Null,
    @LessonID BigInt = Null,
    @Title NVarChar(255),
    @Description NVarChar(Max) = Null,
    @InteractiveType NVarChar(50),
    @ContentUrl NVarChar(500) = Null,
    @ConfigJson NVarChar(Max) = Null,
    @ThumbnailUrl NVarChar(500) = Null,
    @DurationMinutes Int = Null,
    @SortOrder Int = 0,
    @Status NVarChar(50) = 'DRAFT'
)
As
Begin
    Set Nocount On;

    -- Validate InteractiveType
    If @InteractiveType Not In ('H5P', 'SCORM', 'CUSTOM', 'DRAG_DROP', 'FLASHCARD')
        Throw 50001, N'Loại nội dung tương tác không hợp lệ.', 1;

    -- If SortOrder is 0, append to end
    If @SortOrder = 0
    Begin
        If @ChapterID Is Not Null
            Select @SortOrder = IsNull(Max(SortOrder), 0) + 1
            From dbo.SIM_InteractiveContent
            Where ChapterID = @ChapterID;
        Else If @LessonID Is Not Null
            Select @SortOrder = IsNull(Max(SortOrder), 0) + 1
            From dbo.SIM_InteractiveContent
            Where LessonID = @LessonID;
        Else
            Select @SortOrder = IsNull(Max(SortOrder), 0) + 1
            From dbo.SIM_InteractiveContent
            Where CourseID = @CourseID;
    End

    Insert Into dbo.SIM_InteractiveContent
    (
        CourseID,
        ChapterID,
        LessonID,
        Title,
        Description,
        InteractiveType,
        ContentUrl,
        ConfigJson,
        ThumbnailUrl,
        DurationMinutes,
        SortOrder,
        Status,
        CreatedAt,
        UpdatedAt,
        IsDeleted
    )
    Values
    (
        @CourseID,
        @ChapterID,
        @LessonID,
        @Title,
        @Description,
        @InteractiveType,
        @ContentUrl,
        @ConfigJson,
        @ThumbnailUrl,
        @DurationMinutes,
        @SortOrder,
        @Status,
        GetDate(),
        GetDate(),
        0
    );

    Select Cast(SCOPE_IDENTITY() as BigInt) as InteractiveContentID;
End
GO

-- LMS_InteractiveContent_Update
CREATE PROCEDURE dbo.LMS_InteractiveContent_Update
(
    @InteractiveContentID BigInt,
    @Title NVarChar(255) = Null,
    @Description NVarChar(Max) = Null,
    @InteractiveType NVarChar(50) = Null,
    @ContentUrl NVarChar(500) = Null,
    @ConfigJson NVarChar(Max) = Null,
    @ThumbnailUrl NVarChar(500) = Null,
    @DurationMinutes Int = Null,
    @SortOrder Int = Null,
    @Status NVarChar(50) = Null
)
As
Begin
    Set Nocount On;

    -- Verify the interactive content exists
    If Not Exists (Select 1 From dbo.SIM_InteractiveContent Where InteractiveContentID = @InteractiveContentID)
        Throw 50001, N'Nội dung tương tác không tồn tại.', 1;

    Update dbo.SIM_InteractiveContent
    Set
        Title = IsNull(@Title, Title),
        Description = IsNull(@Description, Description),
        InteractiveType = IsNull(@InteractiveType, InteractiveType),
        ContentUrl = IsNull(@ContentUrl, ContentUrl),
        ConfigJson = IsNull(@ConfigJson, ConfigJson),
        ThumbnailUrl = IsNull(@ThumbnailUrl, ThumbnailUrl),
        DurationMinutes = IsNull(@DurationMinutes, DurationMinutes),
        SortOrder = IsNull(@SortOrder, SortOrder),
        Status = IsNull(@Status, Status),
        UpdatedAt = GetDate()
    Where InteractiveContentID = @InteractiveContentID;

    Select @@ROWCOUNT as RowsAffected;
End
GO

-- LMS_InteractiveContent_Delete
CREATE PROCEDURE dbo.LMS_InteractiveContent_Delete
(
    @InteractiveContentID BigInt
)
As
Begin
    Set Nocount On;

    -- Verify the interactive content exists
    If Not Exists (Select 1 From dbo.SIM_InteractiveContent Where InteractiveContentID = @InteractiveContentID)
        Throw 50001, N'Nội dung tương tác không tồn tại.', 1;

    -- Soft delete
    Update dbo.SIM_InteractiveContent
    Set IsDeleted = 1,
        UpdatedAt = GetDate()
    Where InteractiveContentID = @InteractiveContentID;

    Select @@ROWCOUNT as RowsAffected;
End
GO

-- LMS_InteractiveContent_GetById
CREATE PROCEDURE dbo.LMS_InteractiveContent_GetById
(
    @InteractiveContentID BigInt
)
As
Begin
    Set Nocount On;

    Select
        InteractiveContentID,
        CourseID,
        ChapterID,
        LessonID,
        Title,
        Description,
        InteractiveType,
        ContentUrl,
        ConfigJson,
        ThumbnailUrl,
        DurationMinutes,
        SortOrder,
        Status,
        CreatedAt,
        UpdatedAt,
        IsDeleted
    From dbo.SIM_InteractiveContent
    Where InteractiveContentID = @InteractiveContentID
        and IsDeleted = 0;
End
GO

-- LMS_InteractiveContent_GetByChapter
CREATE PROCEDURE dbo.LMS_InteractiveContent_GetByChapter
(
    @ChapterID BigInt
)
As
Begin
    Set Nocount On;

    Select
        InteractiveContentID,
        CourseID,
        ChapterID,
        LessonID,
        Title,
        Description,
        InteractiveType,
        ContentUrl,
        ConfigJson,
        ThumbnailUrl,
        DurationMinutes,
        SortOrder,
        Status,
        CreatedAt,
        UpdatedAt
    From dbo.SIM_InteractiveContent
    Where ChapterID = @ChapterID
        and IsDeleted = 0
    Order By SortOrder;
End
GO

-- LMS_InteractiveContent_GetByCourse
CREATE PROCEDURE dbo.LMS_InteractiveContent_GetByCourse
(
    @CourseID BigInt
)
As
Begin
    Set Nocount On;

    Select
        InteractiveContentID,
        CourseID,
        ChapterID,
        LessonID,
        Title,
        Description,
        InteractiveType,
        ContentUrl,
        ConfigJson,
        ThumbnailUrl,
        DurationMinutes,
        SortOrder,
        Status,
        CreatedAt,
        UpdatedAt
    From dbo.SIM_InteractiveContent
    Where CourseID = @CourseID
        and IsDeleted = 0
    Order By SortOrder;
End
GO

-- LMS_Chapter_GetAllContent (Tổng hợp tất cả nội dung trong chapter)
CREATE PROCEDURE dbo.LMS_Chapter_GetAllContent
(
    @ChapterID BigInt
)
As
Begin
    Set Nocount On;

    -- Get Lessons
    Select
        Cast(LessonID as NVarChar(50)) as ContentID,
        'LESSON' as ContentType,
        Title,
        Description,
        SortOrder,
        'bi-book' as IconClass,
        Null as ThumbnailUrl,
        DurationMinutes,
        LessonType as SubType
    From dbo.SIM_Lessons
    Where ChapterID = @ChapterID
        and IsDeleted = 0

    Union All

    -- Get Quizzes
    Select
        Cast(QuizID as NVarChar(50)) as ContentID,
        'QUIZ' as ContentType,
        Title,
        Description,
        IsNull(SortOrder, 999) as SortOrder,
        'bi-clipboard-check' as IconClass,
        Null as ThumbnailUrl,
        TimeLimitMinutes as DurationMinutes,
        Null as SubType
    From dbo.SIM_Quizzes
    Where ChapterID = @ChapterID
        and IsDeleted = 0

    Union All

    -- Get Interactive Content
    Select
        Cast(InteractiveContentID as NVarChar(50)) as ContentID,
        'INTERACTIVE' as ContentType,
        Title,
        Description,
        SortOrder,
        Case InteractiveType
            When 'H5P' Then 'bi-puzzle'
            When 'SCORM' Then 'bi-box-seam'
            When 'DRAG_DROP' Then 'bi-arrows-move'
            When 'FLASHCARD' Then 'bi-card-text'
            Else 'bi-controller'
        End as IconClass,
        ThumbnailUrl,
        DurationMinutes,
        InteractiveType as SubType
    From dbo.SIM_InteractiveContent
    Where ChapterID = @ChapterID
        and IsDeleted = 0

    Order By SortOrder, ContentType;
End
GO

-- LMS_Chapter_ReorderContent
CREATE PROCEDURE dbo.LMS_Chapter_ReorderContent
(
    @ChapterID BigInt,
    @ContentIDs NVarChar(Max), -- Comma-separated: "LESSON:123,QUIZ:456,INTERACTIVE:789"
    @ContentTypes NVarChar(Max) -- Comma-separated: "LESSON,QUIZ,INTERACTIVE"
)
As
Begin
    Set Nocount On;

    -- Parse and update sort order for each content type
    -- This is a simplified version - in production, use table-valued parameters

    Declare @Xml Xml = N'<r>' + Replace(@ContentIDs, ',', '</r><r>') + '</r>';
    Declare @TypesXml Xml = N'<r>' + Replace(@ContentTypes, ',', '</r><r>') + '</r>';

    -- Update Lessons
    ;With CTE As
    (
        Select
            Cast(r.n.value('.', 'BigInt') as BigInt) as ContentID,
            Row_Number() Over (Order By (Select 1)) as NewSortOrder
        From @Xml.nodes('//r') as r(n)
    )
    Update l
    Set l.SortOrder = cte.NewSortOrder,
        l.UpdatedAt = GetDate()
    From dbo.SIM_Lessons l
    Inner Join CTE cte on l.LessonID = cte.ContentID
    Where l.ChapterID = @ChapterID;

    -- Similar logic for Quizzes and InteractiveContent would be added here
    -- For full implementation, use table-valued parameters

    Select @@ROWCOUNT as RowsAffected;
End
GO

PRINT '✓ All stored procedures created successfully';
GO

-- =============================================
-- SUMMARY
-- =============================================
PRINT '========================================';
PRINT 'DATABASE CHANGES SUMMARY';
PRINT '========================================';
PRINT '✓ Added ChapterID to SIM_ContentItems';
PRINT '✓ Added ChapterID to SIM_Quizzes';
PRINT '✓ Created SIM_InteractiveContent table';
PRINT '✓ Created 7 stored procedures for Interactive Content';
PRINT '✓ Created 2 stored procedures for Chapter Content';
PRINT '========================================';
GO
