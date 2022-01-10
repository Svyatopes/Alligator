CREATE proc [dbo].[Product_Update]
			@Id int,
			@Name varchar(100),
			@CategoryId int
AS
BEGIN
	UPDATE dbo.Product Set Name = @Name, CategoryId = @CategoryId
	where Id = @id
END