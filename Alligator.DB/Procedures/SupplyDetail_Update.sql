CREATE proc dbo.SupplyDetail_Update
			@Id int,
			@Amount int
AS
BEGIN
	UPDATE dbo.SupplyDetail Set Amount = @Amount
	where Id = @id
END
