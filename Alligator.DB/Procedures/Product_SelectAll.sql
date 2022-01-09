CREATE proc dbo.Product_SelectAll
AS
BEGIN
	SELECT
		p.Id,
		p.Name,
		c.Id,
		c.Name

		
	from dbo.Product p left join dbo.Category c on p.CategoryId = c.Id
END
