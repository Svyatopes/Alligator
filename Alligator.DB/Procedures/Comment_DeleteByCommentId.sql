CREATE PROCEDURE [dbo].[Comment_DeleteByCommentId]
	@Id int 
AS
BEGIN 
DELETE FROM dbo.Comment
      WHERE Id  = @Id
END
