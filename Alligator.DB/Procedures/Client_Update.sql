CREATE PROCEDURE dbo.Client_Update
    @Id int,
	@FirstName varchar(50),
    @LastName varchar(50),
    @Patronymic varchar(50),
    @PhoneNumber varchar(50),
    @Email varchar(200)
    
AS
BEGIN
	UPDATE dbo.Client
   SET FirstName = @FirstName,
      LastName = @LastName,
      Patronymic = @Patronymic,
      PhoneNumber = @PhoneNumber,
      Email = @Email
 WHERE Id = @Id;
END
