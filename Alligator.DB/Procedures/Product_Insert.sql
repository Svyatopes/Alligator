CREATE proc dbo.Product_Insert
			@Name varchar(100)
AS
BEGIN
	INSERT INTO dbo.Product (Name) VALUES (@Name)
END
