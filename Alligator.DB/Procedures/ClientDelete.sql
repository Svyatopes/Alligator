CREATE PROCEDURE [dbo].[ClientDelete]
    @Id int
AS
DELETE FROM [dbo].[Client]
      WHERE Id  = @Id;
GO
