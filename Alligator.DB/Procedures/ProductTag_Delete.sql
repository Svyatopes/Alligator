create proc dbo.ProductTag_Delete
			@Id int
AS
BEGIN
	DELETE from dbo.ProductTag
	where Id = @id
END
GO
