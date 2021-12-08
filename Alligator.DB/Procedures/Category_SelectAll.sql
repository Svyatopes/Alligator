CREATE PROCEDURE dbo.Category_SelectAll
AS
BEGIN
	SELECT 
	Id,
	Category
	from dbo.Category
END