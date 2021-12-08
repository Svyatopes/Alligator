create proc dbo.OrderReview_Insert
@OrderId int,
@Text varchar(300) 
AS
BEGIN
	insert into dbo.[OrderReview] (OrderId, Text)
	values (@OrderId, @Text)
END