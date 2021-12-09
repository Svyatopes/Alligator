CREATE proc dbo.Supply_Insert
			@Date date
AS
BEGIN
	INSERT INTO dbo.Supply (Date) VALUES (@Date)
END
