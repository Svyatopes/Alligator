CREATE proc dbo.SupplyDetail
			@Amount int
AS
BEGIN
	INSERT INTO dbo.SupplyDetail (Amount) VALUES (@Amount)
END
