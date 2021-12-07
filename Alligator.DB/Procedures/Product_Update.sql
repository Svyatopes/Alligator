CREATE proc dbo.Product_Update
			@Id int,
			@Name varchar(100)
AS
BEGIN
	UPDATE dbo.Product Set Name = @Name
	where Id = @id
END
