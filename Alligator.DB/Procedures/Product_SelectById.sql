CREATE proc [dbo].[Product_SelectById]
			@Id int
AS
BEGIN
	SELECT
		p.Id,
		p.Name,
		c.Id,
		c.Name,
		pt.Id,
		pt.Name
	from dbo.Product p 
	inner join dbo.Category c 
	on p.CategoryId = c.Id
	left join dbo.Product_ProductTag ppt 
	on p.Id = ppt.ProductId
	inner join dbo.ProductTag pt
	on ppt.ProductTagId = pt.Id
	where p.Id = @Id
END