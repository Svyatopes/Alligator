CREATE PROCEDURE [dbo].[Comment_DeleteByClientId]
@ClientId int 
AS
BEGIN
DELETE FROM dbo.Comment
      WHERE ClientId  = @ClientId
END
