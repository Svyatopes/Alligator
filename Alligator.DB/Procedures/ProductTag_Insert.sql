CREATE proc dbo.ProductTag_Insert
			@Name varchar
AS
BEGIN
	INSERT INTO dbo.ProductTag (Name) VALUES (@Name)
END
