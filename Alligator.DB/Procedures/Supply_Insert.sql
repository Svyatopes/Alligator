CREATE proc dbo.Supply
			@Date date
AS
BEGIN
	INSERT INTO dbo.Supply (Date) VALUES (@Date)
END
