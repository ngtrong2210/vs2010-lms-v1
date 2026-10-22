Create Procedure dbo.LMS_Video_GetByLessOn
    @LessOnId BigInt,
    @ActOrId BigInt,
    @IsAdMIn Bit = 0
As
Begin
    Set NoCount On;

    Select
        v.VideoID,
        v.Title,
        v.VideoUrl,
        v.PosterUrl,
        v.DuratiOnSecOnds,
        v.AllowSeek,
        v.AllowSpeed,
        v.RequiredWatchPercent,
        v.Status,
        v.CurrentVideOversiOnID,
        vv.VersiOnNumber,
        vv.VersiOnStatus,
        vv.VideoUrl As VersiOnVideoUrl,
        vv.PosterUrl As VersiOnPosterUrl,
        vv.DuratiOnSecOnds As VersiOnDuratiOnSecOnds,
        vv.FileSize,
        vv.MimeType,
        vv.SourceType,
        va.VideoAsSetID,
        va.CreatedByUserID As AsSetCreatedByUserID,
        va.ShareScope,
        l.LessOnID,
        l.Title As LessOnTitle,
        l.DescriptiOn As LessOnDescriptiOn,
        l.LessOnType,
        c.CourseID,
        c.Title As CourSetitle
    From dbo.SIM_LessOns l
        Inner JoIn dbo.SIM_Courses c On c.CourseID = l.CourseID
        Inner JoIn dbo.SIM_Videos v On v.VideoID = l.VideoID
        Inner JoIn dbo.SIM_VideoAsSets va On va.VideoAsSetID = v.VideoAsSetId
        Inner JoIn dbo.SIM_VideOversiOns vv On vv.VideOversiOnID = v.CurrentVideOversiOnID
    Where (l.LessOnID = @LessOnId)
        And (l.IsDeleted = 0)
        And (v.Status = 'ACTIVE')
        And (va.IsDeleted = 0)
        And (va.Status = 'ACTIVE')
        And (vv.VersiOnStatus = 'PUBLISHED')
        And
        (
            @IsAdMIn = 1
            Or c.TeacherUserID = @ActOrId
            Or va.CreatedByUserID = @ActOrId
            Or va.ShareScope = 'SCHOOL'
            Or Exists
                (
                    Select
                        1
                    From dbo.SIM_VideoAsSetShares vAs
                    Where (vAs.VideoAsSetID = va.VideoAsSetID)
                        And (vAs.TeacherUserID = @ActOrId)
                )
        );
End;
