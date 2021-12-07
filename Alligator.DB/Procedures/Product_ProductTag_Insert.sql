create proc dbo.Product_ProductTag_Insert
			@ProductId int,
			@ProductTagId int
AS
BEGIN
	insert into dbo.Product_ProductTag (ProductId,ProductTagId)
	values (@ProductId,@ProductTagId)
END
GO
