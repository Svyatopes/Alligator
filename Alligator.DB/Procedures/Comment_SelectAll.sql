CREATE PROCEDURE dbo.Comment_SelectAll
AS
BEGIN 
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
FROM Comment
left join Client
on dbo.[Comment].[ClientId] = dbo.[Client].[Id]
END
