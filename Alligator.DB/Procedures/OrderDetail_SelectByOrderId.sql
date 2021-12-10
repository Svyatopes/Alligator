create proc dbo.OrderDetail_SelectByOrderId	
@OrderId int
AS
BEGIN
	select
	id,	
	OrderId,
	ProductId
	from dbo.[OrderDetail]
	where OrderId=@OrderId
END
