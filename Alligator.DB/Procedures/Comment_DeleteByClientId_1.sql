CREATE PROCEDURE [dbo].[Comment_DeleteByClientId_1]
	@ClientId int 
AS
BEGIN
DELETE FROM dbo.Comment
      WHERE ClientId  = @ClientId
END

