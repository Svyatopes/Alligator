CREATE proc dbo.SupplyDetail_DeleteBySupplyId
			@SupplyId int			
AS
BEGIN
	delete from dbo.SupplyDetail
	where SupplyId = @SupplyId
END