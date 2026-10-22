Use SIMS_NET
Go
-- Dong bo PositionID theo chuc vu - nhan vien.xlsx (24.09.2026)
Begin Try
Begin Tran
Commit Tran
End Try
Begin Catch
If @@TranCount > 0 Rollback Tran;
Declare @Err nvarchar(4000) = Error_Message();
Raiserror(@Err, 16, 1);
End Catch
Go
