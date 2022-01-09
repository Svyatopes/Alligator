create proc dbo.Order_SelectAll	
AS
BEGIN
	select
	id,
	date,
	Address,
	ClientId
	from dbo.[Order]
END