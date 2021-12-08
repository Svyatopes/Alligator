CREATE PROCEDURE dbo.Category_SelectAll
AS
BEGIN
	SELECT 
	Id,
	Name
	from dbo.Category
END