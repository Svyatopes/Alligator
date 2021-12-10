CREATE PROCEDURE dbo.Category_Update
	@id int,
	@Name varchar(50)
AS
BEGIN
	UPDATE dbo.Category 
	Set Name = @Name
	where Id = @id
END