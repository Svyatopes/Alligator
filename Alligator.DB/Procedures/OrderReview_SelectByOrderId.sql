create proc dbo.OrderReview_SelectByOrderId
@orderId int
AS
BEGIN
	select
	r.Id,
	r.OrderId,
	r.Text,
	o.Id,
	o.Address,
	o.Date,
	c.Id,
	c.FirstName,
	c.LastName,
	c.Email,
	c.PhoneNumber
	from dbo.[OrderReview] r inner join dbo.[Order] o on r.OrderId=o.Id 
	inner join dbo.[Client] c on o.ClientId=c.Id
	where r.OrderId=@orderId
END
