create proc dbo.Order_SelectByAddress
@Address varchar
AS
BEGIN
	select
	id,
	date,
	clientId,
	Address
	from dbo.[Order]
	where Address=@Address
END