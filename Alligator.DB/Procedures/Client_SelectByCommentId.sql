CREATE PROCEDURE dbo.Client_SelectByCommentId
	@commentId int
AS
BEGIN
	SELECT 
	cl.Id,	
	cl.FirstName,
	cl.LastName,
	cl.Patronymic,
	cl.PhoneNumber,
	cl.Email
	FROM dbo.[Client] cl 
	WHERE Id=@commentId
END