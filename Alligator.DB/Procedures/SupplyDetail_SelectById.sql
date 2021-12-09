CREATE proc dbo.SupplyDetail_SelectById
			@Id int
AS
BEGIN
	SELECT
		Id,
		SupplyId,
		ProductId,
		Amount
	from dbo.SupplyDetail
	where Id = @Id
END
