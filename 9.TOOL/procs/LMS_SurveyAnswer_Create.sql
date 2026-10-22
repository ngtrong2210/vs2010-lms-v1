Create Procedure dbo.LMS_SurveyAnswer_Create
    @RespOnseId BigInt,
    @QuestiOnId BigInt,
    @AnswerText NVarchar(Max) = Null,
    @SelectedOptiOnId BigInt = Null,
    @NumericValue Decimal(10,2) = Null,
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
        From dbo.SIM_SurveyRespOnses
        Where (RespOnseID = @RespOnseId)
            And (IsDeleted = 0)
    )
        Throw 50002, N'Phản hồi khảo sát không tồn tại.', 1;

    If Not Exists
    (
        Select
            1
        From dbo.SIM_SurveyQuestiOns
        Where (QuestiOnID = @QuestiOnId)
            And (IsDeleted = 0)
    )
        Throw 50003, N'Câu hỏi không tồn tại.', 1;

    If Exists
    (
        Select
            1
        From dbo.SIM_SurveyAnswers
        Where (RespOnseID = @RespOnseId)
            And (QuestiOnID = @QuestiOnId)
            And (IsDeleted = 0)
    )
        Throw 50004, N’Bạn đã trả lời câu hỏi này rồi.’, 1;

    Begin Transaction;

    Declare @AnswerId BigInt;
    Select @AnswerId = NextId From dbo.Sequence Where Name = 'SurveyAnswer';
    Update dbo.Sequence Set NextId = NextId + 1 Where Name = 'SurveyAnswer';

    Insert dbo.SIM_SurveyAnswers
    (
        AnswerID,
        RespOnseID,
        QuestiOnID,
        AnswerText,
        SelectedOptiOnID,
        NumericValue,
        CreatedUser,
        UpdatedUser
    )
    Values
    (
        @AnswerId,
        @RespOnseId,
        @QuestiOnId,
        @AnswerText,
        @SelectedOptiOnId,
        @NumericValue,
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
        'Create',
        'SURVEY',
        'SurveyAnswer',
        COnvert(NVarchar(100), @AnswerId)
    );

    Commit Transaction;

    Select
        @AnswerId AnswerID;
End
