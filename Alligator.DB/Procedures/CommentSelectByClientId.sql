CREATE PROCEDURE [dbo].[CommentSelectByClientId]
	@ClientId int
AS
BEGIN
	SELECT 
	[Text]
	from dbo.Comment
	where ClientId = @ClientId;
	end


