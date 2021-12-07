create proc dbo.OrderDetail_UpdateAmountByProductId
@ProductId int, @Amount int
AS
BEGIN
	update dbo.[OrderDetail] set Amount=@Amount	 
	where ProductId=@ProductId
END
