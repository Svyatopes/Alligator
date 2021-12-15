create proc dbo.OrderDetail_SelectByProductId	
@ProductId int
AS
BEGIN
	select
	od.id,	
	od.OrderId,
	od.ProductId,
	od.Amount,
	o.Id,
	o.Address,
	o.Date,
	p.Id,
	p.Name,
	p.CategoryId
	from dbo.[OrderDetail] od inner join dbo.[Order] o on od.OrderId=o.Id 
	inner join dbo.[Product] p on od.ProductId=p.Id
	where od.ProductId=@ProductId
END