CREATE PROCEDURE dbo.Category_Update
	@id int,
	@Category varchar(50)
AS
BEGIN
	UPDATE dbo.Category Set Category = @Category
	where Id = @id
END