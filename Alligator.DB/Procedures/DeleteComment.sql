CREATE PROCEDURE [dbo].[DeleteComment]
	@Id int,
	@Text varchar(300),
	@ClientId int
AS
DELETE FROM [dbo].[Comment]
      WHERE Id  = @Id;
	  go
