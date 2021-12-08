CREATE PROCEDURE dbo.Comment_Delete
	@Id int
AS
DELETE FROM dbo.Comment
      WHERE Id  = @Id;
	  go
