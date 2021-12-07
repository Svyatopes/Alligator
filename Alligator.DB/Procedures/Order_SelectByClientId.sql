create proc dbo.Order_SelectByClientId
@ClientId int
AS
BEGIN
	select
	id,
	date,
	clientId,
	Address
	from dbo.[Order]
	where id=@ClientId
END
