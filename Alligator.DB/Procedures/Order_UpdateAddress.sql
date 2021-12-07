create proc dbo.Order_UpdateAddress
@ClientId int, @Address varchar(200)
AS
BEGIN
	update dbo.[Order] set Address=@Address	 
	where ClientId=@ClientId
END