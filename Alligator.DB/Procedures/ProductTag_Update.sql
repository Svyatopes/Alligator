CREATE proc dbo.ProductTag_Update
			@Id int,
			@Name varchar
AS
BEGIN
	UPDATE dbo.ProductTag Set Name = @Name
	where Id = @id
END
