create proc dbo.Product_ProductTag_Delete
			@ProductId int,
			@ProductTagId int
AS
BEGIN
	delete from dbo.Product_ProductTag 
	WHERE ProductId = @ProductId AND ProductTagId = @ProductTagId
END
GO
