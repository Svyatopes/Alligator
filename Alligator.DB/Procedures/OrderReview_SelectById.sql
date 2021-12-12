create proc dbo.OrderReview_SelectById
@Id int
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
	where r.Id=@Id
END