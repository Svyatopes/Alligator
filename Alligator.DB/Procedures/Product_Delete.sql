CREATE proc dbo.Product_Delete
			@Id int
AS
BEGIN
	delete from dbo.Product
	where Id = @id
END