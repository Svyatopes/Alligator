create proc dbo.OrderDetail_SelectAll	
AS
BEGIN
	select
	id,	
	OrderId,
	ProductId
	from dbo.[OrderDetail]
END
