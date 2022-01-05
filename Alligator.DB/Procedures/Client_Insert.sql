CREATE PROCEDURE dbo.Client_Insert
	@FirstName varchar(50),
    @LastName varchar(50),
    @Patronymic varchar(50),
    @PhoneNumber varchar(50),
    @Email varchar(50)
AS
BEGIN
INSERT INTO dbo.Client
           (FirstName,
            LastName,
            Patronymic,
            PhoneNumber,
            Email)
     OUTPUT Inserted.ID
     VALUES
           (@FirstName,
            @LastName,
           @Patronymic,
           @PhoneNumber,
           @Email)
END
