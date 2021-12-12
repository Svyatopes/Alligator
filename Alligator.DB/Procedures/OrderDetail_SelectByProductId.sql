create proc dbo.OrderDetail_SelectByProductId	
@ProductId int
AS
BEGIN
	select
	id,	
	OrderId,
	ProductId
	from dbo.[OrderDetail]
	where ProductId=@ProductId
END