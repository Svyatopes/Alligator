CREATE PROCEDURE [dbo].[Comment_SelectAllWithClients]

AS
begin 
	SELECT 
	Comment.Id,
	Comment.Text,
	Client.Id,
	Client.FirstName,
	Client.LastName,
	Client.Patronymic,
	Client.PhoneNumber,
	Client.Email
from Comment
inner join Client
on dbo.[Client].[Id] = dbo.[Comment].[ClientId]
end
