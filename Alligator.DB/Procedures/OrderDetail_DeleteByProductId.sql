create proc dbo.OrderDetail_DeleteByProductId
@ProductId int
AS
BEGIN
	delete 
	from dbo.[OrderDetail]
	where ProductId=@ProductId
END
