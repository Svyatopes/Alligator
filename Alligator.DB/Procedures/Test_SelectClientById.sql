CREATE PROCEDURE [dbo].[Test_SelectClientById]
	@Id int
	
AS
begin
	SELECT 
	cl.Id,
	cl.FirstName,
	co.Id,
	co.Text	
	from dbo.[Client] cl inner join dbo.[Comment] co on cl.Id=co.ClientId
	where co.ClientId=@Id
END
