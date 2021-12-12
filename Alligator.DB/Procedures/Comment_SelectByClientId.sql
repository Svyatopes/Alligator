CREATE PROCEDURE dbo.Comment_SelectByClientId
	@ClientId int
AS
BEGIN
	SELECT 
	Id,
	Text,
	ClientId
	from dbo.Comment
	where ClientId = @ClientId;
	end
--create PROCEDURE dbo.Comment_SelectById  
--AS  
--BEGIN  
--SELECT 
--  cl.Id,
--  cl.FirstName,
--  cl.LastName,
--  cl.Patronymic,
--  cl.PhoneNumber,
--  cl.Email,
--  co.Id,
--  co.ClientId,
--  co.Text
--FROM dbo.[Client] cl INNER JOIN dbo.[Comment] co on cl.Id = co.ClientId
--END 


