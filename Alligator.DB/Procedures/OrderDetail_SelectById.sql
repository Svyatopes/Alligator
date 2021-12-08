create proc dbo.OrderDetail_SelectById	
@Id int
AS
BEGIN
	select
	id,	
	OrderId,
	ProductId
	from dbo.[OrderDetail]
	where Id=@Id
End
