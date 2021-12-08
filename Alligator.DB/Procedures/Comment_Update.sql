CREATE PROCEDURE dbo.CommentUpdate
    @Id int,
	@Text varchar(300)

AS
	UPDATE dbo.Comment
   SET Text = @Text
 WHERE Id = @Id;
go
