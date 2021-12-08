create proc dbo.OrderReview_DeleteById
@Id int
AS
BEGIN
	delete 
	from dbo.[OrderReview]
	where Id=@Id
END