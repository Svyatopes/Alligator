create proc dbo.OrderReview_DeleteByOrderId
@OrderId int
AS
BEGIN
	delete 
	from dbo.[OrderReview]
	where OrderId=@OrderId
END