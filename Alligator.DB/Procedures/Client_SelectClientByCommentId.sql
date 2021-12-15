CREATE PROCEDURE [dbo].[Client_SelectClientByCommentId]
			@Id int
AS
BEGIN
	SELECT
		Client.FirstName,
		Client.LastName,
		Client.Patronymic,
		Client.PhoneNumber,
		Client.Email,
		Comment.Text
FROM Client
inner join Comment
on dbo.[Client].[Id] = dbo.[Comment].[ClientId]
where Client.Id = @Id
END 
