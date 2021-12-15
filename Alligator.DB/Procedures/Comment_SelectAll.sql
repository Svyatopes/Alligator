CREATE PROCEDURE dbo.Comment_SelectAll
AS
begin 
	SELECT 
	Comment.Id,
	Comment.Text,
	Comment.ClientId,
	Client.Id,
	Client.FirstName,
	Client.LastName,
	Client.Patronymic,
	Client.PhoneNumber,
	Client.Email
from Comment
left join Client
on dbo.[Comment].[ClientId] = dbo.[Client].[Id]
end
