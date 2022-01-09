create proc dbo.Order_SelectAll	
AS
BEGIN
	select
	o.id,
	o.date,
	o.Address,
	c.Id,
	c.FirstName,
	c.LastName
	from dbo.[Order] o inner join dbo.[Client] c on o.ClientId=c.Id	
END