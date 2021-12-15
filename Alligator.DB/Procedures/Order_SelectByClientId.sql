create proc dbo.Order_SelectByClientId
@ClientId int
AS
BEGIN
	select
	o.id,
	o.date,
	o.Address,
	c.Id,
	c.FirstName,
	c.LastName,
	c.Email,
	c.PhoneNumber
	from dbo.[Order] o inner join dbo.[Client] c on o.ClientId=c.Id
	where o.ClientId=@ClientId
END
