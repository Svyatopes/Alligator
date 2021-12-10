create proc dbo.OrderDetail_Update
@Id int,
@Amount int
AS
BEGIN
	update dbo.[OrderDetail] set Amount=@Amount	 
	where Id=@Id
END