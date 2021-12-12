create proc dbo.OrderReview_SelectAll	
AS
BEGIN
	select
	r.Id,
	r.OrderId,
	r.Text,
	o.Id,
	o.Address,
	o.Date
	from dbo.[OrderReview] r inner join dbo.[Order] o on r.OrderId=o.Id 
END
