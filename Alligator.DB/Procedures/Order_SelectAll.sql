create proc dbo.Order_SelectAll	
AS
BEGIN
	select
	id,
	date,
	clientId,
	Address
	from dbo.[Order]
END