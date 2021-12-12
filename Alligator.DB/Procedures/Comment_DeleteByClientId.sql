CREATE PROCEDURE [dbo].[Comment_DeleteByClientId]
	@Id int
as
BEGIN
DELETE FROM dbo.Comment
      WHERE ClientId = @Id
END
