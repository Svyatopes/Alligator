create proc dbo.Order_Update
@Id int, 
@ClientId int,
@Address varchar(200),
@Date date
AS
BEGIN
	update dbo.[Order] set ClientId=@ClientId,
	Address=@Address, 
	Date=@Date
	where Id=@Id
END