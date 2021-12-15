CREATE proc dbo.Product_SelectAll
AS
BEGIN
	SELECT
		p.Id,
		p.Name,
		p.Id,
		c.Name
	from dbo.Product p inner join dbo.Category c on p.CategoryId = c.Id
END
