CREATE PROCEDURE dbo.Client_SelectById
	@Id int
as
begin 
 select 
 cl.Id,
 cl.FirstName,
 cl.LastName,
 cl.PhoneNumber,
 cl.Email,
 co.Text
 from dbo.[Client] cl inner join dbo.[Comment] co on cl.Id=co.ClientId
 end