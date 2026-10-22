Create Procedure dbo.LMS_VideoLibrary_GetAvailable
    @UserId BigInt = Null,
    @SearchKeyword Nvarchar(200) = Null,
    @CategoryID BigInt = Null,
    @PageNumber Int = 1,
    @PageSize Int = 20
As
Begin
    Set NoCount On;

    Declare @Offset Int = (@PageNumber - 1) * @PageSize;

    -- Get available videos
    Select
        v.VideoID,
        v.Title,
        v.Description,
        v.ThumbnailUrl,
        v.VideoUrl,
        v.DurationMinutes,
        v.CategoryID,
        cat.CategoryName,
        v.ViewCount,
        v.IsPublished,
        v.CreatedAt,
        v.UpdatedAt,
        v.CreatedBy
    From dbo.SIM_VideoLibrary v
        Left Join dbo.SIM_Categories cat On cat.CategoryID = v.CategoryID
    Where (v.IsDeleted = 0)
        And (v.IsPublished = 1)
        And (@SearchKeyword Is Null Or v.Title Like '%' + @SearchKeyword + '%' Or v.Description Like '%' + @SearchKeyword + '%')
        And (@CategoryID Is Null Or v.CategoryID = @CategoryID)
    Order By
        v.CreatedAt Desc
    Offset @Offset Rows
    Fetch Next @PageSize Rows Only;

    -- Return total Count
    Select
        Count(*) TotalCount
    From dbo.SIM_VideoLibrary v
    Where (v.IsDeleted = 0)
        And (v.IsPublished = 1)
        And (@SearchKeyword Is Null Or v.Title Like '%' + @SearchKeyword + '%' Or v.Description Like '%' + @SearchKeyword + '%')
        And (@CategoryID Is Null Or v.CategoryID = @CategoryID);
End
