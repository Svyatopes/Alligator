CREATE proc dbo.ProductTag_Update
			@Id int,
			@Name varchar(50)
AS
BEGIN
	UPDATE dbo.ProductTag Set Name = @Name
	where Id = @id
END
