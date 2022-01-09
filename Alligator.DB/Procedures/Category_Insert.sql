CREATE PROCEDURE dbo.Category_Insert	
	@Name varchar(50)
AS
BEGIN
	INSERT INTO dbo.Category (Name)
	OUTPUT Inserted.ID
	VALUES (@Name)
END
