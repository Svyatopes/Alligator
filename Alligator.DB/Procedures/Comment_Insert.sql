CREATE PROCEDURE dbo.InsertComment
	@Text varchar(300),
	@ClientId int
AS
INSERT INTO dbo.Comment
           (Text,
           ClientId)
     VALUES
           (@Text
           ,@ClientId)
           GO
