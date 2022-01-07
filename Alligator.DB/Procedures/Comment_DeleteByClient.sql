CREATE PROCEDURE [dbo].[Comment_DeleteByClient]
	@ClientId int 
AS
BEGIN
DELETE FROM dbo.Comment
      WHERE ClientId  = @ClientId
END

