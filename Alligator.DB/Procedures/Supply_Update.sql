CREATE proc dbo.Supply_Update
			@Id int,
			@Date date
AS
BEGIN
	UPDATE dbo.Supply Set Date = @Date
	where Id = @id
END