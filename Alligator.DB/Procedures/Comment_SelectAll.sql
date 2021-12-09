CREATE PROCEDURE dbo.Comment_SelectAll
AS
BEGIN
	SELECT
		Id,
		Text,
		ClientId
	from dbo.Comment
end
