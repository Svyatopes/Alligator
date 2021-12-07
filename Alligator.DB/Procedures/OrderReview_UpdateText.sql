create proc dbo.OrderReview_UpdateText
@OrderId int, @Text varchar(300) 
AS
BEGIN
	update dbo.[OrderReview] set Text=@Text	 
	where OrderId=@OrderId
END
