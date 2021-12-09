CREATE PROCEDURE dbo.Comment_Update
    @Id int,
	@Text varchar(300)

AS
BEGIN
	UPDATE dbo.Comment
   SET Text = @Text
 WHERE Id = @Id;
END
