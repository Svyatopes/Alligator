CREATE proc dbo.Supply_SelectAll
AS
BEGIN
	SELECT
		sd.Id,
		s.Id,
		s.Date,
		p.Id,
		p.Name,
		c.Id,
		c.Name,
		sd.Amount
	from dbo.[SupplyDetail] sd inner join dbo.[Supply] s on sd.SupplyId = s.Id 
			inner join dbo.[Product] p on sd.ProductId = p.Id
			inner join dbo.[Category] c on p.CategoryId = c.Id
END