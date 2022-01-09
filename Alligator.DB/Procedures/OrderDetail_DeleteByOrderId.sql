create proc dbo.OrderDetail_DeleteByOrderId
@OrderId int
AS
BEGIN
	delete 
	from dbo.[OrderDetail]
	where OrderId=@OrderId
END
