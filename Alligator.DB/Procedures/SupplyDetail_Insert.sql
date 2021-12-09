CREATE proc dbo.SupplyDetail_Insert
			@Amount int,
			@SupplyId int,
			@ProductId int
AS
BEGIN
	INSERT INTO dbo.SupplyDetail (Amount, SupplyId, ProductId) VALUES (@Amount, @SupplyId, @ProductId)
END
