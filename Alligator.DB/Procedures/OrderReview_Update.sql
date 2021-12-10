create proc dbo.OrderReview_Update
@Id int,
@Text varchar(300) 
AS
BEGIN
	update dbo.[OrderReview] set Text=@Text	 
	where Id=@Id
END
