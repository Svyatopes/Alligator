CREATE PROCEDURE [dbo].[DeleteComment]
	@Id int
AS
DELETE FROM [dbo].[Comment]
      WHERE Id  = @Id;
	  go
