create proc dbo.Order_DeleteByClientId
@ClientId int
AS
BEGIN
	delete 
	from dbo.[Order] 
	where ClientId=@ClientId
END