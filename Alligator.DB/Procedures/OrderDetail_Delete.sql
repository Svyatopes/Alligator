create proc dbo.OrderDetail_Delete
@Id int
AS
BEGIN
	delete 
	from dbo.[OrderDetail]
	where Id=@Id
END