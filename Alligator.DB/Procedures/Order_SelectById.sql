create proc dbo.Order_SelectById
@Id int
AS
BEGIN
	select
	id,
	date,
	clientId,
	Address
	from dbo.[Order]
	where id=@Id
END
