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


