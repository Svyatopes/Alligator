create proc dbo.OrderDetail_UpdateAmount
@OrderId int, @Amount int
AS
BEGIN
	update dbo.[OrderDetail] set Amount=@Amount	 
	where OrderId=@OrderId
END