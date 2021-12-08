create proc dbo.Order_Insert
@Date date, 
@ClientId int, 
@Address varchar(200) 
AS
BEGIN
	insert into dbo.[Order] (Date, ClientId, Address) 
	values (@Date, @ClientId, @Address);
END

