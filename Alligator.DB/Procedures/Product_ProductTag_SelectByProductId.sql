create proc dbo.Product_ProductTag_SelectByProductId
			@ProductId int
AS
BEGIN
	select 
		Id,
		ProductId,
		ProductTagId
	from dbo.Product_ProductTag 
	WHERE ProductId = @ProductId
END
GO
