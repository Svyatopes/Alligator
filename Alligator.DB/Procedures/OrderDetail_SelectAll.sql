﻿create proc dbo.OrderDetail_SelectAll	
AS
BEGIN
	select
	od.id,	
	od.OrderId,
	od.ProductId,
	o.Id,
	o.Address,
	o.Date,
	p.Id,
	p.Name,
	p.CategoryId
	from dbo.[OrderDetail] od inner join dbo.[Order] o on od.OrderId=o.Id inner join dbo.[Product] p on od.ProductId=p.Id
END
