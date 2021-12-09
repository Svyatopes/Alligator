CREATE proc dbo.SupplyDetail_SelectAll
AS
BEGIN
	SELECT
		Id,
		SupplyId,
		ProductId,
		Amount
	from dbo.SupplyDetail
END