CREATE PROCEDURE [dbo].[CommentSelectAll]
AS
BEGIN
	SELECT
		Id,
		Text,
		ClientId
	from dbo.Comment
end
