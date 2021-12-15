CREATE PROCEDURE dbo.Client_SelectById
	@Id int
AS
BEGIN 
SELECT 
	 cl.Id,
	 cl.FirstName,
	 cl.LastName,
	 cl.PhoneNumber,
	 cl.Email,
	 co.Text
 FROM dbo.[Client] cl inner join dbo.[Comment] co on cl.Id=co.ClientId
 END