CREATE proc dbo.Supply_Insert
			@Date datetime
AS
BEGIN
	INSERT INTO dbo.Supply (Date) 
	VALUES (@Date) 
	select scope_identity()
END
