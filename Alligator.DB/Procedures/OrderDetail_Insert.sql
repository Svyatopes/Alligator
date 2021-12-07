create proc dbo.OrderDetail_Insert
@Amount int, @orderId int, @ProductId int 
AS
BEGIN
	insert into dbo.[OrderDetail] (Amount, OrderId,ProductId) values (@Amount, @orderId, @ProductId);
END
