CREATE proc dbo.Supply_SelectById
			@Id int
AS
BEGIN
	SELECT
		s.Id,
		s.Date,
		sd.Id,
		sd.ProductId,
		sd.SupplyId,
		sd.Amount
	from dbo.[Supply] s
	left join dbo.SupplyDetail sd on 
	s.Id = sd.SupplyId
	where s.Id = @Id	
END
