CREATE proc dbo.ProductTag_SelectAll
AS
BEGIN
	SELECT
		Id,
		Name
	from dbo.ProductTag
END
