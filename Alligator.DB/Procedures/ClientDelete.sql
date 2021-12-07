CREATE PROCEDURE [dbo].[ClientDelete]
    @Id int,
	@FirstName varchar(50),
    @LastName varchar(50),
    @Patronymic varchar(50),
    @PhoneNumber varchar(50),
    @Email varchar(50)
AS
DELETE FROM [dbo].[Client]
      WHERE Id  = @Id;
GO
