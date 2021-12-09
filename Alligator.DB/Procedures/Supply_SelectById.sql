CREATE proc dbo.Supply_SelectById
			@Id int
AS
BEGIN
	SELECT
		Id,
		Date
	from dbo.Supply
	where Id = @Id
END
