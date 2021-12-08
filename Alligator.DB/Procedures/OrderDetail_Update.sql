create proc dbo.OrderDetail_UpdateAmount
@Id int,
@Amount int
AS
BEGIN
	update dbo.[OrderDetail] set Amount=@Amount	 
	where Id=@Id
END