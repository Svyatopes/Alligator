create proc dbo.OrderDetail_Insert
@Amount int,
@OrderId int, 
@ProductId int 
AS
BEGIN
	insert into dbo.[OrderDetail] (Amount, OrderId,ProductId)
	values (@Amount, @OrderId, @ProductId)
END
