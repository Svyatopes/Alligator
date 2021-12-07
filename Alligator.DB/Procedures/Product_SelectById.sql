CREATE proc dbo.Product_SelectById
			@Id int
AS
BEGIN
	SELECT
		Id,
		Name
	from dbo.Product
	where Id = @Id
END