CREATE PROCEDURE dbo.Comment_Delete
	@Id int
AS
BEGIN
DELETE FROM dbo.Comment
      WHERE Id  = @Id;
END
