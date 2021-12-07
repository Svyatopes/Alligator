CREATE proc [dbo].[Product_Insert]
			@Name varchar
AS
BEGIN
	INSERT INTO dbo.Product (Name) VALUES (@Name)
END
