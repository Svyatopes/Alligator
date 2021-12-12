CREATE PROCEDURE dbo.Comment_insert
	@Text varchar(300),
	@Id int
AS
BEGIN
INSERT INTO dbo.Comment
           (Text,
           ClientId)
     VALUES
           (@Text
           ,@Id)
END
