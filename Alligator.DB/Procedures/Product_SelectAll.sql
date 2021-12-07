CREATE proc dbo.Product_SelectAll
AS
BEGIN
	SELECT
		Id,
		Name
	from dbo.Product
END
