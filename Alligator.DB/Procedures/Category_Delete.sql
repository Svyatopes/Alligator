CREATE PROCEDURE dbo.Category_Delete
			@Id int			
AS
BEGIN
	delete from dbo.Category
	WHERE Id = @id
END
GO
