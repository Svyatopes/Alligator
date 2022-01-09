CREATE proc [dbo].[SupplyDetail_SelectBySupplyId]
			@SupplyId int
AS
BEGIN	
	SELECT
		sd.Id,
		sd.ProductId,
		sd.SupplyId,
		sd.Amount,		
		p.Id,
		p.Name
		
				
	from dbo.[SupplyDetail] sd 
	left join dbo.[Product] p on 
	sd.ProductId = p.Id 
							  
							   
	where sd.SupplyId = @SupplyId		
	
END