CREATE proc dbo.Supply_Delete
			@Id int
AS
BEGIN
	delete from dbo.Supply
	where Id = @id
END