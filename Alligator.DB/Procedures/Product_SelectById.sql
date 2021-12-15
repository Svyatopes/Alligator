CREATE proc dbo.Product_SelectById
			@Id int
AS
BEGIN
	SELECT
		p.Id,
		p.Name,
		c.Id,
		c.Name
	from dbo.Product p inner join dbo.Category c on p.CategoryId = c.Id
	where p.Id = @Id
END