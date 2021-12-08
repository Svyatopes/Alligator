CREATE PROCEDURE [dbo].[CommentSelectByClientId]
	@ClientId int
AS
BEGIN
	SELECT 
	[Id],
	[Text],
	[ClientId]
	from dbo.Comment
	where ClientId = @ClientId;
	end


