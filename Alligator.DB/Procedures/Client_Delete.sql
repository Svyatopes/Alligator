CREATE PROCEDURE dbo.Client_Delete
    @Id int
AS
DELETE FROM dbo.Client
      WHERE Id  = @Id;
GO
