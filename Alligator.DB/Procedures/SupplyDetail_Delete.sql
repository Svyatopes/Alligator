CREATE proc dbo.SupplyDetail_Delete
			@Id int			
AS
BEGIN
	delete from dbo.SupplyDetail
	where Id = @id
END