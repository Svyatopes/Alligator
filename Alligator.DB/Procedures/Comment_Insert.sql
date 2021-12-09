CREATE PROCEDURE dbo.Comment_insert
	@Text varchar(300),
	@ClientId int
AS
BEGIN
INSERT INTO dbo.Comment
           (Text,
           ClientId)
     VALUES
           (@Text
           ,@ClientId)
END
