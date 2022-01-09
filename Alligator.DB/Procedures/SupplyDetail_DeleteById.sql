CREATE proc dbo.SupplyDetail_DeleteById
			@Id int			
AS
BEGIN
	delete from dbo.SupplyDetail
	where Id = @Id
END