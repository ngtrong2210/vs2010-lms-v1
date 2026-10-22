Create Procedure dbo.LMS_Survey_SubmitRespOnse
    @SurveyId BigInt,
    @StudentUserId BigInt,
    @ActOrId BigInt,
    @UpdatedUser NVarchar(100) = Null
As
Begin
    Set NoCount On;
    Set Xact_AbOrt On;

    If Not Exists
    (
        Select
            1
        From dbo.SIM_Surveys
        Where (SurveyID = @SurveyId)
            And (IsDeleted = 0)
    )
        Throw 50002, N'Kháº£o sÃ¡t khÃ´ng tá»“n táº¡i.', 1;

    If Exists
    (
        Select
            1
        From dbo.SIM_SurveyRespOnses
        Where (SurveyID = @SurveyId)
            And (StudentUserID = @StudentUserId)
            And (IsDeleted = 0)
    )
        Throw 50003, N'Báº¡n Ä‘Ã£ tham gia kháº£o sÃ¡t nÃ y rá»“i.', 1;

    Declare @CourseID BigInt;
    Select @CourseID = CourseID From dbo.SIM_Surveys Where SurveyID = @SurveyId;

    Begin Transaction;

    Declare @RespOnseId BigInt;
    Select @RespOnseId = NextId From dbo.Sequence Where Name = 'SurveyRespOnse';
    Update dbo.Sequence Set NextId = NextId + 1 Where Name = 'SurveyRespOnse';

    Insert dbo.SIM_SurveyRespOnses
    (
        RespOnseID,
        SurveyID,
        StudentUserID,
        SubmittedAt,
        CreatedUser,
        UpdatedUser
    )
    Values
    (
        @RespOnseId,
        @SurveyId,
        @StudentUserId,
        SysUtcDatetime(),
        @UpdatedUser,
        @UpdatedUser
    );

    Insert dbo.AuditLogs
    (
        UserId,
        ActiOn,
        Module,
        EntityName,
        EntityId
    )
    Values
    (
        @ActOrId,
        'SUBMIT',
        'SURVEY',
        'SurveyRespOnse',
        COnvert(NVarchar(100), @RespOnseId)
    );

    Commit Transaction;

    Select
        @RespOnseId RespOnseID;
End
