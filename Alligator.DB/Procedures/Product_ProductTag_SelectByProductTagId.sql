create proc dbo.Product_ProductTag_SelectByProductTagId
			@ProductTagId int
AS
BEGIN
	select 
		Id,
		ProductId,
		ProductTagId
	from dbo.Product_ProductTag 
	WHERE ProductTagId = @ProductTagId
END
GO
