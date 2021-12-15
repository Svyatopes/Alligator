﻿CREATE PROCEDURE dbo.Client_SelectByCommentId
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
	FROM dbo.[Client] cl inner join dbo.[Comment] co on cl.Id=co.ClientId
	WHERE co.Id=@commentId
END