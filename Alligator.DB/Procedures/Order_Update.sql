create proc dbo.Order_Update
@Id int, 
@Address varchar(200),
@Date date
AS
BEGIN
	update dbo.[Order] set Address=@Address, 
	Date=@Date
	where Id=@Id
END