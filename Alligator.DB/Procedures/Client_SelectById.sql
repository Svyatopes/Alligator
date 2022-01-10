CREATE PROCEDURE dbo.Client_SelectById
  @Id int
AS
BEGIN 
SELECT 
   cl.Id,
   cl.FirstName,
   cl.LastName,
   cl.Patronymic,
   cl.PhoneNumber,
   cl.Email,
   co.Id,
   co.Text
 FROM dbo.[Client] cl left join dbo.[Comment] co on cl.Id=co.ClientId
 where cl.Id = @Id
 END