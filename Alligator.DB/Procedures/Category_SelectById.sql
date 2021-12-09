CREATE PROCEDURE dbo.Category_SelectById
	@id int
AS
BEGIN
	SELECT 
	Id,
	Name
	from dbo.Category
	where Id = @Id
END
