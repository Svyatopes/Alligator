CREATE proc dbo.ProductTag_SelectById
			@Id int
AS
BEGIN
	SELECT
		Id,
		Name
	from dbo.ProductTag
	where Id = @Id
END