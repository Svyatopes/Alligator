CREATE proc dbo.Product_Insert
			@Name varchar(100),
			@CategoryId int
AS
BEGIN
	INSERT INTO dbo.Product (Name, CategoryId) 
	VALUES (@Name, @CategoryId)
END
GO
