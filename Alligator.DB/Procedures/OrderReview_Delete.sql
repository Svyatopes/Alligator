create proc dbo.OrderReview_Delete
@Id int
AS
BEGIN
	delete 
	from dbo.[OrderReview]
	where Id=@Id
END